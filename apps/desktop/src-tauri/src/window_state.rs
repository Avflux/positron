//! Sistema de mapeamento e persistência de estado da janela e último caminho acessado.
//!
//! Grava em `%LOCALAPPDATA%\positron\state.json` (ou caminho equivalente no SO):
//! - Posição (x, y), tamanho (width, height) e estado maximizado da janela.
//! - Suporte a múltiplos monitores: se as coordenadas salvas não forem encontradas em nenhum
//!   monitor ativo (ex.: segundo monitor desconectado), move para o monitor ativo disponível e centraliza.
//! - Último caminho de arquivo/projeto acessado pelo usuário (`last_path`).

use serde::{Deserialize, Serialize};
use std::fs;
use std::path::PathBuf;
use std::sync::atomic::{AtomicBool, Ordering};
use std::sync::{Arc, Mutex};
use tauri::{
    PhysicalPosition, PhysicalSize, Position, Size, WebviewWindow, WindowEvent,
};

/// Geometria salva da janela física.
#[derive(Debug, Clone, Serialize, Deserialize, PartialEq, Eq)]
pub struct WindowGeometry {
    pub x: i32,
    pub y: i32,
    pub width: u32,
    pub height: u32,
    pub maximized: bool,
}

/// Estado geral salvo no arquivo `state.json`.
#[derive(Debug, Clone, Serialize, Deserialize, Default, PartialEq, Eq)]
pub struct AppStateData {
    pub window: Option<WindowGeometry>,
    pub last_path: Option<String>,
    #[serde(default)]
    pub recent_paths: Vec<String>,
}

/// Retângulo em coordenadas físicas para cálculos de tela e monitores.
#[derive(Debug, Clone, Copy, PartialEq, Eq)]
pub struct Rect {
    pub x: i32,
    pub y: i32,
    pub width: u32,
    pub height: u32,
}

impl Rect {
    /// Verifica se um ponto (px, py) está contido nos limites deste retângulo.
    pub fn contains_point(&self, px: i32, py: i32) -> bool {
        px >= self.x
            && px < self.x + self.width as i32
            && py >= self.y
            && py < self.y + self.height as i32
    }

    /// Calcula a largura e altura de sobreposição entre dois retângulos.
    pub fn overlap(&self, other: &Rect) -> (i32, i32) {
        let left = self.x.max(other.x);
        let right = (self.x + self.width as i32).min(other.x + other.width as i32);
        let top = self.y.max(other.y);
        let bottom = (self.y + self.height as i32).min(other.y + other.height as i32);

        let overlap_w = (right - left).max(0);
        let overlap_h = (bottom - top).max(0);
        (overlap_w, overlap_h)
    }
}

/// Encontra o índice do monitor correspondente à janela ou ao ponto.
/// Retorna `None` se a janela estiver completamente fora de todos os monitores disponíveis.
pub fn find_matching_monitor_index(
    monitors: &[Rect],
    win_x: i32,
    win_y: i32,
    win_w: u32,
    win_h: u32,
) -> Option<usize> {
    // 1. Verifica se o ponto superior-esquerdo da janela está contido em algum monitor
    for (idx, mon) in monitors.iter().enumerate() {
        if mon.contains_point(win_x, win_y) {
            return Some(idx);
        }
    }

    // 2. Se o ponto superior-esquerdo estiver ligeiramente fora da borda, verifica
    // se há sobreposição visível suficiente da janela (ao menos 100px x 40px, p. ex. barra de título)
    let win_rect = Rect {
        x: win_x,
        y: win_y,
        width: win_w,
        height: win_h,
    };
    for (idx, mon) in monitors.iter().enumerate() {
        let (ow, oh) = mon.overlap(&win_rect);
        if ow >= 100 && oh >= 40 {
            return Some(idx);
        }
    }

    None
}

/// Calcula a posição centralizada de uma janela dentro do retângulo de um monitor,
/// respeitando limites mínimos e o tamanho da tela.
pub fn calculate_centered_position(
    monitor_rect: &Rect,
    req_w: u32,
    req_h: u32,
) -> (PhysicalPosition<i32>, PhysicalSize<u32>) {
    let mw = monitor_rect.width as i32;
    let mh = monitor_rect.height as i32;

    // Garante que o tamanho caiba no monitor com alguma margem e respeite mínimo de 640x480
    let win_w = (req_w as i32).clamp(640, (mw - 40).max(640));
    let win_h = (req_h as i32).clamp(480, (mh - 40).max(480));

    let center_x = monitor_rect.x + (mw - win_w) / 2;
    let center_y = monitor_rect.y + (mh - win_h) / 2;

    (
        PhysicalPosition {
            x: center_x,
            y: center_y,
        },
        PhysicalSize {
            width: win_w as u32,
            height: win_h as u32,
        },
    )
}

/// Resolve o caminho absoluto do arquivo `state.json` dentro da pasta `AppData\Local\positron`.
pub fn resolve_state_file_path() -> PathBuf {
    let base_dir = if let Ok(local_app_data) = std::env::var("LOCALAPPDATA") {
        PathBuf::from(local_app_data)
    } else if let Ok(user_profile) = std::env::var("USERPROFILE") {
        PathBuf::from(user_profile).join("AppData").join("Local")
    } else if let Ok(home) = std::env::var("HOME") {
        PathBuf::from(home).join(".local").join("share")
    } else {
        PathBuf::from(".")
    };

    base_dir.join("positron").join("state.json")
}

/// Gerenciador de estado em memória com persistência e sincronização de janela.
pub struct WindowStateManager {
    file_path: PathBuf,
    data: Mutex<AppStateData>,
    dirty: AtomicBool,
}

impl WindowStateManager {
    pub fn new() -> Self {
        Self::with_path(resolve_state_file_path())
    }

    pub fn with_path(file_path: PathBuf) -> Self {
        let data = if file_path.exists() {
            match fs::read_to_string(&file_path) {
                Ok(content) => serde_json::from_str::<AppStateData>(&content).unwrap_or_default(),
                Err(_) => AppStateData::default(),
            }
        } else {
            AppStateData::default()
        };

        Self {
            file_path,
            data: Mutex::new(data),
            dirty: AtomicBool::new(false),
        }
    }

    #[allow(dead_code)]
    pub fn file_path(&self) -> &PathBuf {
        &self.file_path
    }

    /// Salva o estado atual no disco de forma síncrona.
    pub fn save(&self) -> Result<(), std::io::Error> {
        let snapshot = {
            let guard = self.data.lock().unwrap();
            guard.clone()
        };

        if let Some(parent) = self.file_path.parent() {
            fs::create_dir_all(parent)?;
        }

        let json = serde_json::to_string_pretty(&snapshot)
            .map_err(|e| std::io::Error::new(std::io::ErrorKind::Other, e))?;

        fs::write(&self.file_path, json)?;
        self.dirty.store(false, Ordering::Release);
        Ok(())
    }

    /// Retorna o último caminho gravado.
    pub fn get_last_path(&self) -> Option<String> {
        self.data.lock().unwrap().last_path.clone()
    }

    /// Grava o último caminho acessado e persiste no disco.
    pub fn set_last_path(&self, path: String) -> Result<(), String> {
        {
            let mut guard = self.data.lock().unwrap();
            guard.last_path = Some(path.clone());
            if !guard.recent_paths.contains(&path) {
                guard.recent_paths.insert(0, path);
                if guard.recent_paths.len() > 10 {
                    guard.recent_paths.truncate(10);
                }
            }
        }
        self.save().map_err(|e| e.to_string())
    }

    /// Restaura a geometria e posição da janela na inicialização.
    ///
    /// Se a posição anterior não for encontrada em nenhum monitor atualmente conectado
    /// (exemplo clássico de desconexão de monitor secundário), seleciona o monitor disponível
    /// e centraliza a janela nele.
    pub fn restore_window(&self, window: &WebviewWindow) {
        let saved_geom = {
            let guard = self.data.lock().unwrap();
            guard.window.clone()
        };

        let monitors = window.available_monitors().unwrap_or_default();

        if monitors.is_empty() {
            // Sem monitores reportados pelo sistema: centraliza padrão
            let _ = window.center();
            return;
        }

        let monitor_rects: Vec<Rect> = monitors
            .iter()
            .map(|m| Rect {
                x: m.position().x,
                y: m.position().y,
                width: m.size().width,
                height: m.size().height,
            })
            .collect();

        if let Some(geom) = saved_geom {
            let match_index = find_matching_monitor_index(
                &monitor_rects,
                geom.x,
                geom.y,
                geom.width,
                geom.height,
            );

            match match_index {
                Some(_idx) => {
                    // Monitor correspondente encontrado: restaura posição e tamanho exatos
                    let _ = window.set_size(Size::Physical(PhysicalSize {
                        width: geom.width,
                        height: geom.height,
                    }));
                    let _ = window.set_position(Position::Physical(PhysicalPosition {
                        x: geom.x,
                        y: geom.y,
                    }));
                }
                None => {
                    // Monitor original desconectado ou ponto fora do alcance:
                    // "muda pro outro monitor e mantem na posição centralizado"
                    let primary_idx = window
                        .primary_monitor()
                        .ok()
                        .flatten()
                        .and_then(|pm| {
                            monitor_rects.iter().position(|r| {
                                r.x == pm.position().x && r.y == pm.position().y
                            })
                        })
                        .unwrap_or(0);

                    let target_rect = &monitor_rects[primary_idx];
                    let (pos, size) =
                        calculate_centered_position(target_rect, geom.width, geom.height);

                    let _ = window.set_size(Size::Physical(size));
                    let _ = window.set_position(Position::Physical(pos));
                }
            }

            if geom.maximized {
                let _ = window.maximize();
            }
        } else {
            // Primeiro acesso sem estado salvo: centraliza no monitor primário
            let primary_rect = window
                .primary_monitor()
                .ok()
                .flatten()
                .map(|pm| Rect {
                    x: pm.position().x,
                    y: pm.position().y,
                    width: pm.size().width,
                    height: pm.size().height,
                })
                .unwrap_or(monitor_rects[0]);

            let (pos, size) = calculate_centered_position(&primary_rect, 1000, 720);
            let _ = window.set_size(Size::Physical(size));
            let _ = window.set_position(Position::Physical(pos));
        }
    }

    /// Registra observadores nos eventos de movimentação e fechamento da janela.
    pub fn attach_listeners(self: &Arc<Self>, window: &WebviewWindow) {
        let manager = Arc::clone(self);
        let win = window.clone();

        window.on_window_event(move |event| match event {
            WindowEvent::Moved(pos) => {
                if let Ok(false) = win.is_maximized() {
                    let mut guard = manager.data.lock().unwrap();
                    if let Some(geom) = guard.window.as_mut() {
                        geom.x = pos.x;
                        geom.y = pos.y;
                        geom.maximized = false;
                    } else {
                        guard.window = Some(WindowGeometry {
                            x: pos.x,
                            y: pos.y,
                            width: 1000,
                            height: 720,
                            maximized: false,
                        });
                    }
                    manager.dirty.store(true, Ordering::Release);
                } else if let Ok(true) = win.is_maximized() {
                    let mut guard = manager.data.lock().unwrap();
                    if let Some(geom) = guard.window.as_mut() {
                        geom.maximized = true;
                    }
                    manager.dirty.store(true, Ordering::Release);
                }
            }
            WindowEvent::Resized(size) => {
                if let Ok(false) = win.is_maximized() {
                    let mut guard = manager.data.lock().unwrap();
                    if let Some(geom) = guard.window.as_mut() {
                        geom.width = size.width;
                        geom.height = size.height;
                        geom.maximized = false;
                    } else {
                        guard.window = Some(WindowGeometry {
                            x: 100,
                            y: 100,
                            width: size.width,
                            height: size.height,
                            maximized: false,
                        });
                    }
                    manager.dirty.store(true, Ordering::Release);
                } else if let Ok(true) = win.is_maximized() {
                    let mut guard = manager.data.lock().unwrap();
                    if let Some(geom) = guard.window.as_mut() {
                        geom.maximized = true;
                    }
                    manager.dirty.store(true, Ordering::Release);
                }
            }
            WindowEvent::CloseRequested { .. } | WindowEvent::Destroyed => {
                manager.sync_from_window(&win);
                let _ = manager.save();
            }
            _ => {}
        });

        // Tarefa em segundo plano para persistência debounced (a cada 600ms se dirty)
        let manager_debounced = Arc::clone(self);
        tauri::async_runtime::spawn(async move {
            loop {
                tokio::time::sleep(tokio::time::Duration::from_millis(600)).await;
                if manager_debounced.dirty.swap(false, Ordering::AcqRel) {
                    let _ = manager_debounced.save();
                }
            }
        });
    }

    /// Sincroniza o estado atual diretamente da janela antes de fechar.
    pub fn sync_from_window(&self, window: &WebviewWindow) {
        let is_max = window.is_maximized().unwrap_or(false);
        let mut guard = self.data.lock().unwrap();

        if is_max {
            if let Some(geom) = guard.window.as_mut() {
                geom.maximized = true;
            } else if let (Ok(pos), Ok(size)) = (window.outer_position(), window.outer_size()) {
                guard.window = Some(WindowGeometry {
                    x: pos.x,
                    y: pos.y,
                    width: size.width,
                    height: size.height,
                    maximized: true,
                });
            }
        } else if let (Ok(pos), Ok(size)) = (window.outer_position(), window.outer_size()) {
            guard.window = Some(WindowGeometry {
                x: pos.x,
                y: pos.y,
                width: size.width,
                height: size.height,
                maximized: false,
            });
        }
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_rect_contains_point() {
        let r = Rect {
            x: 0,
            y: 0,
            width: 1920,
            height: 1080,
        };
        assert!(r.contains_point(100, 100));
        assert!(r.contains_point(0, 0));
        assert!(!r.contains_point(1920, 1080));
        assert!(!r.contains_point(-10, 50));
    }

    #[test]
    fn test_multi_monitor_detection_and_fallback() {
        let mon1 = Rect {
            x: 0,
            y: 0,
            width: 1920,
            height: 1080,
        };
        let mon2 = Rect {
            x: 1920,
            y: 0,
            width: 1920,
            height: 1080,
        };
        let monitors = vec![mon1, mon2];

        // Janela posicionada no segundo monitor (x=2100)
        let idx = find_matching_monitor_index(&monitors, 2100, 100, 1000, 720);
        assert_eq!(idx, Some(1));

        // Cenário: Monitor 2 desconectado! Apenas mon1 existe agora.
        let single_monitor = vec![mon1];
        let not_found = find_matching_monitor_index(&single_monitor, 2100, 100, 1000, 720);
        assert_eq!(not_found, None);

        // Fallback: centraliza a janela no monitor restante (mon1)
        let (pos, size) = calculate_centered_position(&mon1, 1000, 720);
        assert_eq!(size.width, 1000);
        assert_eq!(size.height, 720);
        assert_eq!(pos.x, (1920 - 1000) / 2); // 460
        assert_eq!(pos.y, (1080 - 720) / 2); // 180
    }

    #[test]
    fn test_serialization_and_persistence() {
        let temp_dir = std::env::temp_dir().join("positron_test_state");
        let _ = fs::create_dir_all(&temp_dir);
        let test_file = temp_dir.join("test_state.json");

        let manager = WindowStateManager::with_path(test_file.clone());
        manager
            .set_last_path("C:\\Projetos\\teste.db".to_string())
            .expect("deve salvar last_path");

        assert_eq!(
            manager.get_last_path(),
            Some("C:\\Projetos\\teste.db".to_string())
        );

        // Recarrega de uma nova instância lendo o arquivo
        let reloaded = WindowStateManager::with_path(test_file.clone());
        assert_eq!(
            reloaded.get_last_path(),
            Some("C:\\Projetos\\teste.db".to_string())
        );

        let _ = fs::remove_dir_all(&temp_dir);
    }

    #[test]
    fn test_resolve_state_file_path() {
        let p = resolve_state_file_path();
        let s = p.to_string_lossy();
        assert!(s.ends_with("state.json"));
        assert!(s.contains("positron"));
    }
}
