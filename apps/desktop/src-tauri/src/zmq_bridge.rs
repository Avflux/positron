//! DEALER para comandos e SUB para eventos — os únicos sockets do sistema.
//!
//! Duas decisões que valem explicação:
//!
//! 1. **DEALER/ROUTER, não REQ/REP.** REQ casa um pedido com uma resposta e trava
//!    o socket nesse meio-tempo: sem timeout, uma resposta perdida congela a UI
//!    para sempre. Com DEALER cada envelope carrega `id`, então dá para
//!    correlacionar, ignorar resposta atrasada e desistir.
//!
//! 2. **Nenhuma operação de socket dentro do runtime async.** ZMQ é bloqueante
//!    por natureza; `recv` aqui espera em `spawn_blocking`, e o SUB roda numa
//!    thread crua. Fazer `recv` direto numa task travaria o executor inteiro.

use std::sync::atomic::{AtomicU64, Ordering};
use std::sync::{Arc, Mutex, MutexGuard};
use std::time::Duration;

use serde_json::{json, Value};
use tauri::{AppHandle, Emitter};
use tokio::sync::watch;
use zmq::{Context, Socket, DEALER, SUB};

use crate::sidecar::Ports;

/// Host dos sockets. Loopback: o sidecar nunca escuta na rede.
pub const HOST: &str = "127.0.0.1";

/// Esquema dos eventos repassados à UI: `listen("zmq://<topic>")`.
pub const EVENT_SCHEME: &str = "zmq";

pub const DEFAULT_TIMEOUT: Duration = Duration::from_secs(10);

/// Timeout curto do SUB: ele só precisa acordar de tempos em tempos para ver o
/// flag de parada e notar que a porta mudou. Não é latência de entrega.
const SUB_POLL: Duration = Duration::from_millis(200);

pub fn endpoint(port: u16) -> String {
    format!("tcp://{HOST}:{port}")
}

#[derive(Debug, thiserror::Error)]
pub enum BridgeError {
    #[error("sidecar ainda não conectado")]
    NotConnected,
    #[error("timeout de {0:?} esperando a resposta de {1}")]
    Timeout(Duration, String),
    #[error("erro de ZMQ: {0}")]
    Zmq(#[from] zmq::Error),
    #[error("resposta ilegível: {0}")]
    Json(#[from] serde_json::Error),
    #[error("o sidecar respondeu erro {code}: {message}")]
    Remote { code: String, message: String },
    #[error("a thread de bloqueio falhou: {0}")]
    Join(String),
}

impl BridgeError {
    /// Código estável para a UI. Para erros do sidecar é o código dele mesmo
    /// (`unknown_method`, `bad_params`, ...), que é o que o front realmente quer.
    pub fn code(&self) -> String {
        match self {
            Self::Remote { code, .. } => code.clone(),
            Self::NotConnected => "not_connected".into(),
            Self::Timeout(..) => "timeout".into(),
            Self::Zmq(_) => "zmq".into(),
            Self::Json(_) => "bad_response".into(),
            Self::Join(_) => "internal".into(),
        }
    }
}

pub struct ZmqBridge {
    ctx: Context,
    /// `Mutex<Option<Socket>>` e não `Socket` direto: o socket só existe depois
    /// que o sidecar anunciou a porta, e some quando ele cai.
    dealer: Mutex<Option<Socket>>,
    next_id: AtomicU64,
}

impl ZmqBridge {
    pub fn new() -> Arc<Self> {
        Arc::new(Self {
            ctx: Context::new(),
            dealer: Mutex::new(None),
            next_id: AtomicU64::new(1),
        })
    }

    /// Cópia do contexto para a thread do SUB (o `Context` do ZMQ já é um `Arc`).
    pub fn context(&self) -> Context {
        self.ctx.clone()
    }

    /// (Re)conecta o DEALER na porta do ROUTER.
    pub fn connect(&self, port: u16) -> Result<(), BridgeError> {
        let socket = self.ctx.socket(DEALER)?;
        socket.set_linger(0)?;
        socket.connect(&endpoint(port))?;
        // Trocar o socket fecha o antigo, o que derruba a conexão velha.
        *self.lock_dealer() = Some(socket);
        Ok(())
    }

    /// Correlaciona um pedido com a sua resposta. Roda em thread de bloqueio.
    pub fn request_blocking(
        &self,
        method: &str,
        params: Value,
        timeout: Duration,
    ) -> Result<Value, BridgeError> {
        let guard = self.lock_dealer();
        let socket = guard.as_ref().ok_or(BridgeError::NotConnected)?;

        let id = self.next_id.fetch_add(1, Ordering::Relaxed).to_string();
        // `ts` é opcional no envelope: o Pydantic preenche se faltar.
        let envelope = json!({ "v": 1, "id": id, "method": method, "params": params });
        socket.set_rcvtimeo(timeout.as_millis().min(i32::MAX as u128) as i32)?;
        socket.send(envelope.to_string(), 0)?;

        loop {
            let bytes = match socket.recv_bytes(0) {
                Ok(bytes) => bytes,
                Err(zmq::Error::EAGAIN) => {
                    return Err(BridgeError::Timeout(timeout, method.to_string()))
                }
                Err(err) => return Err(BridgeError::from(err)),
            };

            let reply: Value = serde_json::from_slice(&bytes)?;
            if reply.get("id").and_then(Value::as_str) != Some(id.as_str()) {
                // Não deveria acontecer (DEALER é FIFO), mas pular é mais seguro
                // do que devolver a resposta de outra pergunta.
                continue;
            }

            if reply.get("ok").and_then(Value::as_bool).unwrap_or(false) {
                return Ok(reply.get("result").cloned().unwrap_or(Value::Null));
            }

            let error = &reply["error"];
            return Err(BridgeError::Remote {
                code: error
                    .get("code")
                    .and_then(Value::as_str)
                    .unwrap_or("unknown")
                    .to_string(),
                message: error
                    .get("message")
                    .and_then(Value::as_str)
                    .unwrap_or("erro sem mensagem")
                    .to_string(),
            });
        }
    }

    /// Versão usada pelos comandos do Tauri: empurra o bloqueio para o pool.
    pub async fn request(
        self: &Arc<Self>,
        method: &str,
        params: Value,
        timeout: Duration,
    ) -> Result<Value, BridgeError> {
        let this = Arc::clone(self);
        let method = method.to_string();
        tokio::task::spawn_blocking(move || this.request_blocking(&method, params, timeout))
            .await
            .map_err(|err| BridgeError::Join(err.to_string()))?
    }

    /// Reconecta o DEALER sempre que o sidecar publicar uma porta nova.
    pub async fn watch(self: Arc<Self>, mut ports: watch::Receiver<Option<Ports>>) {
        let mut connected: Option<u16> = None;

        loop {
            // O `Ref` do watch é descartado no fim da linha: ele não é `Send` e
            // por isso não pode atravessar o `await` abaixo.
            let target = ports.borrow_and_update().as_ref().map(|p| p.zmq_port);

            if target != connected {
                match target {
                    Some(port) => {
                        let this = Arc::clone(&self);
                        match tokio::task::spawn_blocking(move || this.connect(port)).await {
                            Ok(Ok(())) => connected = Some(port),
                            Ok(Err(err)) => {
                                eprintln!("dealer: falha ao conectar na porta {port}: {err}")
                            }
                            Err(err) => eprintln!("dealer: thread de bloqueio falhou: {err}"),
                        }
                    }
                    None => connected = None,
                }
            }

            // `changed()` só erra se o `Sender` for descartado — aí não há mais
            // nada para vigiar.
            if ports.changed().await.is_err() {
                return;
            }
        }
    }

    /// Um `panic` em outra thread não deve derrubar a ponte inteira.
    fn lock_dealer(&self) -> MutexGuard<'_, Option<Socket>> {
        self.dealer
            .lock()
            .unwrap_or_else(|poisoned| poisoned.into_inner())
    }
}

/// Thread dedicada ao SUB.
///
/// Ela nunca fica presa num `recv` sem timeout: o `SUB_POLL` curto é o que permite
/// ver o flag de parada e trocar de porta quando o sidecar reinicia. É também por
/// isso que é uma thread crua e não uma task.
pub fn spawn_subscriber(
    app: AppHandle,
    ctx: Context,
    mut ports: watch::Receiver<Option<Ports>>,
    stop: Arc<std::sync::atomic::AtomicBool>,
) {
    let spawned = std::thread::Builder::new()
        .name("zmq-sub".into())
        .spawn(move || {
            let socket = match ctx.socket(SUB) {
                Ok(socket) => socket,
                Err(err) => {
                    eprintln!("zmq-sub: não consegui abrir o SUB: {err}");
                    return;
                }
            };
            let _ = socket.set_linger(0);
            let _ = socket.set_subscribe(b""); // todos os tópicos
            let _ = socket.set_rcvtimeo(SUB_POLL.as_millis() as i32);

            let mut connected: Option<u16> = None;

            while !stop.load(Ordering::Relaxed) {
                // Comparar a cada volta é mais simples (e mais robusto) do que
                // depender da semântica de `has_changed` de um receptor novo.
                let target = ports.borrow_and_update().as_ref().map(|p| p.pub_port);
                if target != connected {
                    if let Some(old) = connected.take() {
                        let _ = socket.disconnect(&endpoint(old));
                    }
                    if let Some(port) = target {
                        if socket.connect(&endpoint(port)).is_ok() {
                            connected = Some(port);
                        }
                    }
                }

                match socket.recv_multipart(0) {
                    Ok(frames) => forward(&app, &frames),
                    Err(zmq::Error::EAGAIN) | Err(zmq::Error::EINTR) => {}
                    Err(err) => eprintln!("zmq-sub: {err}"),
                }
            }
        });

    if let Err(err) = spawned {
        eprintln!("zmq-sub: não consegui criar a thread: {err}");
    }
}

/// Repassa um evento do PUB para o frontend.
///
/// O frame 0 é o tópico e o 1 é o envelope JSON. Emitimos só o `payload`, porque é
/// isso que o `SidecarEventMap` do `@protocol` declara.
fn forward(app: &AppHandle, frames: &[zmq::Message]) {
    let [topic, body, ..] = frames else { return };

    let Ok(topic) = std::str::from_utf8(topic.as_ref()) else {
        eprintln!("zmq-sub: tópico que não é UTF-8");
        return;
    };

    let Ok(envelope) = serde_json::from_slice::<Value>(body.as_ref()) else {
        eprintln!("zmq-sub: evento com JSON inválido no tópico {topic}");
        return;
    };

    let payload = envelope.get("payload").cloned().unwrap_or(Value::Null);
    if let Err(err) = app.emit(&format!("{EVENT_SCHEME}://{topic}"), payload) {
        eprintln!("zmq-sub: falha ao emitir {topic}: {err}");
    }
}
