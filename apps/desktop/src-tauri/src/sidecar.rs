//! Descoberta, spawn e supervisão do processo Python.
//!
//! O contrato com o Python é uma linha em **stdout** (ver
//! `services/sidecar/src/sidecar/__main__.py`):
//!
//! ```text
//! SIDECAR_READY {"pid":123,"version":"0.1.0","zmq_port":54321,"pub_port":54322}
//! ```
//!
//! O sidecar escolhe a porta efêmera; nós só lemos. Isso evita a corrida clássica
//! de "achar uma porta livre, fechá-la e passar adiante" — entre o teste e o bind
//! outro processo pode pegar a mesma porta.
//!
//! Toda transição de estado vira o evento `zmq://sidecar` para a UI, que assim
//! nunca precisa perguntar "está no ar?".

use std::io;
use std::process::Stdio;
use std::sync::Arc;
use std::time::Duration;

use serde::{Deserialize, Serialize};
use tauri::{AppHandle, Emitter};
use tokio::io::{AsyncBufReadExt, BufReader, Lines};
use tokio::process::{Child, ChildStdout, Command};
use tokio::sync::watch;

/// Prefixo da linha de handshake. Tem que casar com `__main__.READY_PREFIX`.
const READY_PREFIX: &str = "SIDECAR_READY ";

/// Tópico escutado pela UI: `listen("zmq://sidecar", ...)`.
pub const STATUS_TOPIC: &str = "sidecar";

const HANDSHAKE_TIMEOUT: Duration = Duration::from_secs(20);
const BACKOFF_BASE: Duration = Duration::from_millis(500);

/// Quantas tentativas seguidas antes de desistir. Sem isto, um sidecar que não
/// sobe (pyzmq faltando, por exemplo) vira um laço infinito de spawn.
const MAX_CONSECUTIVE_FAILURES: u32 = 5;

#[cfg(windows)]
const EXE_SUFFIX: &str = ".exe";
#[cfg(not(windows))]
const EXE_SUFFIX: &str = "";

/// O que o handshake traz do Python.
#[derive(Debug, Clone, Serialize, Deserialize)]
pub struct Ports {
    pub pid: u32,
    pub version: String,
    pub zmq_port: u16,
    pub pub_port: u16,
}

/// Estado do sidecar, espelhado em `@protocol` (`SidecarStatus`) e emitido como
/// `zmq://sidecar` a cada transição.
#[derive(Debug, Clone, Serialize)]
#[serde(tag = "state", rename_all = "lowercase")]
pub enum Status {
    Starting,
    Ready {
        pid: u32,
        version: String,
        zmq_port: u16,
        pub_port: u16,
    },
    Exited {
        code: Option<i32>,
    },
    Error {
        message: String,
    },
    /// Desistimos depois de `MAX_CONSECUTIVE_FAILURES`. Não haverá mais tentativa.
    Stopped {
        attempts: u32,
    },
}

#[derive(Debug, thiserror::Error)]
pub enum SidecarError {
    #[error("nenhum candidato executável: nem o binário empacotado ao lado do app, nem `uv`, nem `python`")]
    NotFound,
    #[error("não consegui subir o sidecar: {0}")]
    Spawn(#[from] io::Error),
    #[error("handshake inválido: {0}")]
    Handshake(String),
    #[error("o sidecar não emitiu o handshake em {HANDSHAKE_TIMEOUT:?}")]
    Timeout,
}

/// Dono do processo filho. Barato de clonar (é `Arc` por dentro) e seguro de
/// compartilhar com os comandos do Tauri.
pub struct Sidecar {
    /// `tokio::sync::Mutex` e não `std::sync::Mutex` porque `wait()` é assíncrono.
    child: tokio::sync::Mutex<Option<Child>>,
    /// Porta atual (ou `None` enquanto não estiver no ar). Os dois consumidores
    /// são a thread do SUB e o vigia do DEALER.
    ports: watch::Sender<Option<Ports>>,
}

impl Sidecar {
    pub fn new() -> Arc<Self> {
        let (ports, _rx) = watch::channel(None);
        Arc::new(Self {
            child: tokio::sync::Mutex::new(None),
            ports,
        })
    }

    /// Canal para acompanhar a porta. Cada chamada dá um receptor independente.
    pub fn ports(&self) -> watch::Receiver<Option<Ports>> {
        self.ports.subscribe()
    }

    pub fn status(&self) -> Status {
        match self.ports.borrow().clone() {
            Some(p) => Status::Ready {
                pid: p.pid,
                version: p.version,
                zmq_port: p.zmq_port,
                pub_port: p.pub_port,
            },
            None => Status::Starting,
        }
    }

    /// Sobe o sidecar, espera o handshake e publica as portas.
    pub async fn start(&self) -> Result<Ports, SidecarError> {
        // Nunca deixar dois sidecars vivos: eles brigariam pela mesma porta HTTP e
        // o segundo subiria numa porta efêmera diferente (e ficaria órfão).
        self.kill_now();

        let mut child = self.spawn_candidate()?;

        let stdout = child
            .stdout
            .take()
            .ok_or_else(|| SidecarError::Handshake("stdout indisponível".into()))?;

        let (ports, lines) = match tokio::time::timeout(HANDSHAKE_TIMEOUT, read_handshake(stdout)).await
        {
            Ok(Ok(pair)) => pair,
            Ok(Err(err)) => {
                let _ = child.start_kill();
                return Err(err);
            }
            Err(_) => {
                let _ = child.start_kill();
                return Err(SidecarError::Timeout);
            }
        };

        // Continuar drenando o stdout e reemitir no nosso stderr: se o pipe encher,
        // o `print()` do Python bloqueia e o sidecar trava de forma silenciosa.
        tokio::spawn(drain(lines));

        let ports = Ports {
            // O pid do handshake é o do Python; o do `Child` é a fonte de verdade
            // para quem mata. Coincidem, mas o segundo nunca mente.
            pid: child.id().unwrap_or(ports.pid),
            ..ports
        };

        *self.child.lock().await = Some(child);
        let _ = self.ports.send(Some(ports.clone()));
        Ok(ports)
    }

    /// Mata o processo e zera a porta publicada.
    pub async fn stop(&self) {
        let taken = self.child.lock().await.take();
        if let Some(mut child) = taken {
            let _ = child.start_kill();
            let _ = child.wait().await;
        }
        let _ = self.ports.send(None);
    }

    /// Versão síncrona, para o desligamento do app (onde não dá para esperar).
    ///
    /// Se o lock estiver ocupado não insistimos: o `kill_on_drop` mata o filho
    /// quando o `Child` for descartado.
    pub fn kill_now(&self) {
        if let Ok(mut guard) = self.child.try_lock() {
            if let Some(child) = guard.as_mut() {
                let _ = child.start_kill();
            }
        }
    }

    /// Sobe o sidecar e mantém vivo, com backoff.
    pub async fn supervise(self: &Arc<Self>, app: AppHandle) {
        let mut failures: u32 = 0;

        loop {
            self.announce(&app, Status::Starting);

            match self.start().await {
                Ok(ports) => {
                    failures = 0;
                    self.announce(
                        &app,
                        Status::Ready {
                            pid: ports.pid,
                            version: ports.version,
                            zmq_port: ports.zmq_port,
                            pub_port: ports.pub_port,
                        },
                    );
                    let code = self.wait_for_exit().await;
                    let _ = self.ports.send(None);
                    self.announce(&app, Status::Exited { code });
                }
                Err(err) => {
                    failures += 1;
                    self.announce(
                        &app,
                        Status::Error {
                            message: err.to_string(),
                        },
                    );
                    if failures >= MAX_CONSECUTIVE_FAILURES {
                        self.announce(&app, Status::Stopped { attempts: failures });
                        return;
                    }
                }
            }

            // 500 ms, 1 s, 2 s, 4 s, 8 s. Um sidecar que morre no boot não deve
            // virar um laço apertado de spawn.
            let backoff = BACKOFF_BASE * 2u32.pow(failures.min(4));
            tokio::time::sleep(backoff).await;
        }
    }

    async fn wait_for_exit(&self) -> Option<i32> {
        let mut guard = self.child.lock().await;
        let child = guard.as_mut()?;
        match child.wait().await {
            Ok(status) => status.code(),
            Err(err) => {
                eprintln!("sidecar: falha esperando o processo sair: {err}");
                None
            }
        }
    }

    /// Tenta cada candidato em ordem e devolve o primeiro que conseguir subir.
    ///
    /// Ordem: binário empacotado (produção) → `uv run` (dev, garante as deps do
    /// `pyproject.toml`) → `python -m` (dev, sem uv instalado).
    fn spawn_candidate(&self) -> Result<Child, SidecarError> {
        let candidates = candidates();
        if candidates.is_empty() {
            return Err(SidecarError::NotFound);
        }

        let mut last_error: Option<io::Error> = None;
        for mut command in candidates {
            command
                .stdin(Stdio::null())
                .stdout(Stdio::piped())
                // O log do Python aparece no terminal que subiu o app: em dev é
                // exatamente o que se quer, e em produção vai para o console do SO.
                .stderr(Stdio::inherit())
                // Sem isto, um Rust que morre sem limpar deixa o Python órfão.
                .kill_on_drop(true);

            match command.spawn() {
                Ok(child) => return Ok(child),
                Err(err) => {
                    eprintln!("sidecar: `{}` não subiu: {err}", command.as_std().get_program().to_string_lossy());
                    last_error = Some(err);
                }
            }
        }

        Err(SidecarError::Spawn(last_error.unwrap_or_else(|| {
            io::Error::new(io::ErrorKind::NotFound, "nenhum comando executável")
        })))
    }

    fn announce(&self, app: &AppHandle, status: Status) {
        let topic = format!("{}://{}", crate::zmq_bridge::EVENT_SCHEME, STATUS_TOPIC);
        if let Err(err) = app.emit(&topic, status) {
            eprintln!("sidecar: falha ao emitir {topic}: {err}");
        }
    }
}

/// Monta os comandos possíveis, na ordem de tentativa.
fn candidates() -> Vec<Command> {
    let mut out = Vec::new();

    // 1) Produção: o PyInstaller é copiado para o lado do executável principal
    //    pelo `externalBin` (o Tauri remove o sufixo do target triple ao empacotar).
    //    Em dev, sempre executar o código-fonte para refletir alterações sem rebuild.
    #[cfg(not(dev))]
    {
        if let Some(dir) = std::env::current_exe()
            .ok()
            .and_then(|exe| exe.parent().map(|p| p.to_path_buf()))
        {
            let packaged = dir.join(format!("sidecar{EXE_SUFFIX}"));
            if packaged.exists() {
                out.push(Command::new(packaged));
            }
        }
    }

    // 2) e 3) Dev.
    if let Some(dir) = sidecar_dir() {
        let mut uv = Command::new("uv");
        uv.args(["run", "--no-progress", "python", "-m", "sidecar"])
            .current_dir(&dir);
        out.push(uv);

        let mut python = Command::new("python");
        python.args(["-m", "sidecar"]).current_dir(&dir);
        out.push(python);
    }

    out
}

/// Diretório do projeto Python, resolvido em tempo de compilação.
///
/// `CARGO_MANIFEST_DIR` aponta para `apps/desktop/src-tauri` na máquina de quem
/// compila, então três níveis acima está a raiz do repositório. Só serve para o
/// binário de desenvolvimento: num app empacotado esse caminho não existe, e é
/// por isso que o candidato empacotado vem antes na lista.
fn sidecar_dir() -> Option<std::path::PathBuf> {
    let manifest = std::path::PathBuf::from(env!("CARGO_MANIFEST_DIR"));
    let root = manifest.parent()?.parent()?.parent()?;
    let dir = root.join("services").join("sidecar");
    dir.join("pyproject.toml").is_file().then_some(dir)
}

/// Lê o stdout até a linha de handshake, devolvendo o resto para continuar drenando.
async fn read_handshake(
    stdout: ChildStdout,
) -> Result<(Ports, Lines<BufReader<ChildStdout>>), SidecarError> {
    let mut lines = BufReader::new(stdout).lines();

    while let Some(line) = lines.next_line().await? {
        if let Some(json) = line.strip_prefix(READY_PREFIX) {
            let ports = serde_json::from_str::<Ports>(json)
                .map_err(|err| SidecarError::Handshake(format!("{err} (linha: {json})")))?;
            return Ok((ports, lines));
        }
        // Qualquer outra coisa em stdout é ruído de biblioteca; não é fatal.
        eprintln!("sidecar(stdout): {line}");
    }

    Err(SidecarError::Handshake(
        "o processo terminou sem emitir o handshake".into(),
    ))
}

/// Consome o stdout restante para o pipe nunca encher.
async fn drain(mut lines: Lines<BufReader<ChildStdout>>) {
    loop {
        match lines.next_line().await {
            Ok(Some(line)) => eprintln!("sidecar(stdout): {line}"),
            Ok(None) => return,
            Err(_) => return,
        }
    }
}
