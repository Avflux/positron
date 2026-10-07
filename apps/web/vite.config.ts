import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";
import { fileURLToPath, URL } from "node:url";

// A UI é servida pelo Tauri em dev (porta fixa) e empacotada como estáticos em produção.
export default defineConfig({
  plugins: [react()],
  clearScreen: false,
  publicDir: fileURLToPath(new URL("../desktop/src-tauri/icons", import.meta.url)),
  server: {
    port: 5173,
    strictPort: true,
    // O Tauri usa 1420 por padrão; mantemos 5173 e configuramos em tauri.conf.json.
    watch: { ignored: ["**/src-tauri/**", "**/target/**"] },
  },
  resolve: {
    alias: {
      "@": fileURLToPath(new URL("./src", import.meta.url)),
      "@protocol": fileURLToPath(new URL("../../packages/protocol/src/index.ts", import.meta.url)),
    },
  },
  envPrefix: ["VITE_", "TAURI_"],
  build: {
    target: "chrome105",
    outDir: "dist",
    emptyOutDir: true,
    sourcemap: true,
  },
});
