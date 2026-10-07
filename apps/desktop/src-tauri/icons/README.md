# Ícones

`icon.svg` é um ícone provisório para permitir o desenvolvimento no Windows.
Substitua-o por um ícone de marca antes de distribuir o app.

## O que fazer antes do primeiro `tauri build`

1. Ponha um PNG quadrado de 1024×1024 em qualquer lugar (ex.: `logo.png`).
2. Rode, da raiz do repositório:

   ```bash
   npm run tauri --workspace @app/desktop -- icon ../../logo.png
   ```

   (O script se chama `tauri`; tudo depois do `--` vira argumento dele. O caminho
   é relativo a `apps/desktop`, que é onde o npm roda o script.)

   Isso gera `32x32.png`, `128x128.png`, `128x128@2x.png`, `icon.icns`,
   `icon.ico` e os ícones do Windows Store. É o mesmo comando do template oficial.

3. Configure os ícones gerados em `bundle.icon` no
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

`tauri dev` funciona sem nada disso — só o empacotamento exige ícone.
