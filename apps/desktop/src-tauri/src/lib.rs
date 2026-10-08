//! Montagem do app Tauri: estado compartilhado, comandos do IPC e ciclo de vida.
//!
//! A UI só fala com o Rust por três comandos; o resto é evento:
//!
//! | Direção        | Canal                          | Quem usa                  |
//! |----------------|--------------------------------|---------------------------|
//! | UI → Rust      | `invoke("zmq_request")`        | `lib/bridge.ts`           |
//! | UI → Rust      | `invoke("sidecar_status")`     | diagnóstico               |
//! | UI → Rust      | `invoke("sidecar_restart")`    | botão de reiniciar        |
//! | Rust → UI      | `emit("zmq://<topic>")`        | `onEvent()` / `useZmqEvent`|
//! | Rust → UI      | `emit("zmq://sidecar")`        | estado do processo        |

mod sidecar;
mod window_state;
mod zmq_bridge;

use std::sync::atomic::{AtomicBool, Ordering};
use std::sync::Arc;

use serde::Serialize;
use serde_json::Value;
use tauri::{AppHandle, Manager, RunEvent, State};

use sidecar::{Sidecar, SidecarError, Status};
use window_state::WindowStateManager;
use zmq_bridge::{BridgeError, ZmqBridge};

/// Estado gerenciado pelo Tauri, acessível pelos comandos via `State`.
pub struct AppState {
    sidecar: Arc<Sidecar>,
    bridge: Arc<ZmqBridge>,
    /// Avisa a thread do SUB para sair. Sem isto ela só morreria junto com o
    /// processo, atrasando o desligamento.
    stop: Arc<AtomicBool>,
    window_state: Arc<WindowStateManager>,
}

/// Erro que atravessa o IPC. `code` é para a máquina decidir, `message` para humanos.
#[derive(Debug, Clone, Serialize)]
pub struct IpcError {
    code: String,
    message: String,
}

impl IpcError {
    fn new(code: impl Into<String>, message: impl Into<String>) -> Self {
        Self {
            code: code.into(),
            message: message.into(),
        }
    }
}

impl From<BridgeError> for IpcError {
    fn from(err: BridgeError) -> Self {
        Self::new(err.code(), err.to_string())
    }
}

impl From<SidecarError> for IpcError {
    fn from(err: SidecarError) -> Self {
        Self::new("sidecar", err.to_string())
    }
}

/// Comando principal: `invoke("zmq_request", { method, params })`.
#[tauri::command]
async fn zmq_request(
    state: State<'_, AppState>,
    method: String,
    params: Option<Value>,
) -> Result<Value, IpcError> {
    let params = params.unwrap_or_else(|| Value::Object(serde_json::Map::new()));
    state
        .bridge
        .request(&method, params, zmq_bridge::DEFAULT_TIMEOUT)
        .await
        .map_err(IpcError::from)
}

/// Estado atual do processo. Redundante com o evento `zmq://sidecar` de propósito:
/// a UI que monta depois do `ready` não perde o estado inicial.
#[tauri::command]
fn sidecar_status(state: State<'_, AppState>) -> Status {
    state.sidecar.status()
}

/// Botão "reiniciar" da UI.
///
/// Só **derruba** o processo: quem sobe de novo é o laço de supervisão, que é o
/// único dono do ciclo de vida. Se subíssemos aqui também, os dois competiriam e
/// acabaria com dois sidecars, cada um numa porta efêmera diferente.
#[tauri::command]
async fn sidecar_restart(state: State<'_, AppState>) -> Result<Status, IpcError> {
    state.sidecar.stop().await;
    Ok(state.sidecar.status())
}

/// Retorna o último caminho acessado pelo usuário (salvo em AppData\Local\positron\state.json).
#[tauri::command]
fn get_last_path(state: State<'_, AppState>) -> Option<String> {
    state.window_state.get_last_path()
}

/// Grava o último caminho acessado pelo usuário em AppData\Local\positron\state.json.
#[tauri::command]
fn set_last_path(state: State<'_, AppState>, path: String) -> Result<(), String> {
    state.window_state.set_last_path(path)
}

pub fn run() {
    let sidecar = Sidecar::new();
    let bridge = ZmqBridge::new();
    let stop = Arc::new(AtomicBool::new(false));
    let window_state = Arc::new(WindowStateManager::new());

    tauri::Builder::default()
        .manage(AppState {
            sidecar: Arc::clone(&sidecar),
            bridge: Arc::clone(&bridge),
            stop: Arc::clone(&stop),
            window_state: Arc::clone(&window_state),
        })
        .invoke_handler(tauri::generate_handler![
            zmq_request,
            sidecar_status,
            sidecar_restart,
            get_last_path,
            set_last_path
        ])
        .setup(move |app| {
            let handle = app.handle().clone();

            // Mapeamento e restauração da geometria da janela (com suporte a multi-monitor)
            if let Some(window) = app.get_webview_window("main") {
                window_state.restore_window(&window);
                window_state.attach_listeners(&window);
                let _ = window.show();
            }

            // SUB: uma thread dedicada para toda a vida do app.
            zmq_bridge::spawn_subscriber(
                handle.clone(),
                bridge.context(),
                sidecar.ports(),
                Arc::clone(&stop),
            );

            // DEALER: reconecta sozinho quando a porta do ROUTER mudar.
            let bridge_for_watch = Arc::clone(&bridge);
            let ports = sidecar.ports();
            tauri::async_runtime::spawn(async move {
                bridge_for_watch.watch(ports).await;
            });

            // Supervisão do processo (sobe, espera, reinicia com backoff).
            let supervised = Arc::clone(&sidecar);
            tauri::async_runtime::spawn(async move {
                supervised.supervise(handle).await;
            });

            Ok(())
        })
        .build(tauri::generate_context!())
        .expect("falha ao montar o app Tauri")
        .run(handle_run_event);
}

/// Limpeza no fim da vida do app.
///
/// Um sidecar que sobrevive ao Rust fica órfão segurando as portas. O
/// `kill_on_drop` já cobre o caminho normal, mas isto é explícito — e o
/// `RunEvent::Exit` é o único ponto garantido para fazer isso.
fn handle_run_event(app: &AppHandle, event: RunEvent) {
    if matches!(event, RunEvent::Exit) {
        if let Some(state) = app.try_state::<AppState>() {
            state.stop.store(true, Ordering::Relaxed);
            state.sidecar.kill_now();
            let _ = state.window_state.save();
        }
    }
}
