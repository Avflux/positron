// O binário só chama a lib, para que a montagem do app seja testável e
// reutilizável (mesmo arranjo dos templates oficiais do Tauri).
#![cfg_attr(not(debug_assertions), windows_subsystem = "windows")]

fn main() {
    app_desktop_lib::run()
}
