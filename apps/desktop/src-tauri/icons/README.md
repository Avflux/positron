# Ícones

`icon.svg` é exibido na interface web e como favicon. O `icon.ico` é usado pelo
Tauri como ícone do app no Windows. Ambos são carregados diretamente deste
diretório; substitua os arquivos aqui para atualizar esses usos.

## Ícones para distribuição em outras plataformas

Para distribuir em macOS ou Linux, gere também os ícones específicos dessas
plataformas a partir de um PNG quadrado de 1024×1024 (ex.: `logo.png`).
1. Rode, da raiz do repositório:

   ```bash
   npm run tauri --workspace @app/desktop -- icon ../../logo.png
   ```

   (O script se chama `tauri`; tudo depois do `--` vira argumento dele. O caminho
   é relativo a `apps/desktop`, que é onde o npm roda o script.)

   Isso gera `32x32.png`, `128x128.png`, `128x128@2x.png`, `icon.icns`,
   `icon.ico` e os ícones do Windows Store. É o mesmo comando do template oficial.

2. Configure os ícones gerados em `bundle.icon` no arquivo base
   `apps/desktop/src-tauri/tauri.conf.json`:

   ```json
   "icon": [
     "icons/32x32.png",
     "icons/128x128.png",
     "icons/128x128@2x.png",
     "icons/icon.icns",
     "icons/icon.ico"
   ]
   ```

O ícone do Windows já está configurado em
`apps/desktop/src-tauri/tauri.windows.conf.json`. O comando de build do Tauri
recompila a interface antes de empacotá-la, incluindo o SVG. Ao substituir o
`.ico`, recompile o app desktop para atualizar o ícone do executável.
