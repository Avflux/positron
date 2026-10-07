/**
 * Utilitários só para o modo navegador (dev:web), onde não há Rust/Tauri.
 * Mantidos fora do `bridge.ts` para deixar claro o que é caminho de produção
 * e o que é conveniência de desenvolvimento.
 */
export const HTTP_BASE = (): string =>
  import.meta.env.VITE_HTTP_BASE ?? "http://127.0.0.1:8765";

export async function health(): Promise<{ status: string; version: string }> {
  const res = await fetch(`${HTTP_BASE()}/health`);
  if (!res.ok) throw new Error(`health falhou: ${res.status}`);
  return res.json();
}
