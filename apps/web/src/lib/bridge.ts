/**
 * Ponte única entre a UI e o "backend".
 *
 * Em produção (dentro do Tauri) falamos com o Rust via `invoke`.
 * No navegador (dev:web) caímos para o FastAPI do sidecar — mesma assinatura,
 * para a UI não precisar saber onde está rodando.
 */
import type { Method, MethodParams, MethodResult } from "@protocol";

// Reexportado porque a UI sempre importa da ponte, nunca do pacote direto.
export type { SidecarStatus } from "@protocol";

type InvokeFn = <T>(cmd: string, args?: Record<string, unknown>) => Promise<T>;

let invokeImpl: InvokeFn | null = null;

/** Tauri injeta `window.__TAURI_INTERNALS__`; usamos isso como detecção. */
export const isTauri = (): boolean =>
  typeof window !== "undefined" && "__TAURI_INTERNALS__" in window;

async function loadInvoke(): Promise<InvokeFn | null> {
  if (!isTauri()) return null;
  if (invokeImpl) return invokeImpl;
  // import dinâmico: o bundle do navegador não quebra quando o pacote não existe/falha.
  const mod = await import("@tauri-apps/api/core");
  invokeImpl = mod.invoke as InvokeFn;
  return invokeImpl;
}

export class BackendError extends Error {
  constructor(message: string, readonly code?: string) {
    super(message);
    this.name = "BackendError";
  }
}

/** Comando síncrono: request/response com timeout aplicado no lado do Rust. */
export async function request<M extends Method>(
  method: M,
  params?: MethodParams<M>,
): Promise<MethodResult<M>> {
  const invoke = await loadInvoke();
  if (invoke) {
    return invoke<MethodResult<M>>("zmq_request", { method, params: params ?? {} });
  }
  return httpRequest<M>(method, params);
}

async function httpRequest<M extends Method>(
  method: M,
  params?: MethodParams<M>,
): Promise<MethodResult<M>> {
  const base = import.meta.env.VITE_HTTP_BASE ?? "http://127.0.0.1:8765";
  const res = await fetch(`${base}/rpc/${method}`, {
    method: "POST",
    headers: { "content-type": "application/json" },
    body: JSON.stringify(params ?? {}),
  });
  const body = await res.json().catch(() => ({}));
  if (!res.ok || body?.error) {
    throw new BackendError(body?.error?.message ?? res.statusText, body?.error?.code);
  }
  return body.result as MethodResult<M>;
}

/** Escuta um evento publicado pelo sidecar (via Rust). */
export async function onEvent<T = unknown>(
  topic: string,
  handler: (payload: T) => void,
): Promise<() => void> {
  if (!isTauri()) {
    // Fallback: SSE pelo FastAPI (ver services/sidecar/src/sidecar/http/app.py).
    const base = import.meta.env.VITE_HTTP_BASE ?? "http://127.0.0.1:8765";
    const es = new EventSource(`${base}/events`);
    es.addEventListener(topic, (ev) => handler(JSON.parse((ev as MessageEvent).data)));
    return () => es.close();
  }
  const { listen } = await import("@tauri-apps/api/event");
  const unlisten = await listen<T>(`zmq://${topic}`, (ev) => handler(ev.payload));
  return unlisten;
}

/** Retorna o último caminho acessado pelo usuário (gravado em AppData\Local\positron\state.json). */
export async function getLastPath(): Promise<string | null> {
  const invoke = await loadInvoke();
  if (invoke) {
    try {
      return await invoke<string | null>("get_last_path");
    } catch {
      return null;
    }
  }
  return typeof localStorage !== "undefined"
    ? localStorage.getItem("positron:last_path")
    : null;
}

/** Salva o último caminho acessado pelo usuário em AppData\Local\positron\state.json. */
export async function setLastPath(path: string): Promise<void> {
  const invoke = await loadInvoke();
  if (invoke) {
    try {
      await invoke("set_last_path", { path });
      return;
    } catch {
      // Ignora erro de invoke e grava fallback no localStorage
    }
  }
  if (typeof localStorage !== "undefined") {
    localStorage.setItem("positron:last_path", path);
  }
}


