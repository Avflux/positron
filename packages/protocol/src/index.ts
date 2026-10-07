/**
 * Contrato compartilhado UI <-> Rust <-> Python.
 *
 * ATENÇÃO: este arquivo é o espelho manual de
 * `services/sidecar/src/sidecar/protocol.py`. Ao mudar um método, mude os dois
 * e rode `npm run protocol:gen` (scripts/gen-protocol.ps1) que valida o diff.
 *
 * Convenção de nomes: métodos em snake_case (`list_fixtures`), para casar com o
 * `dispatch` do Python sem camada de tradução.
 */

/** Envelope trocado no socket DEALER/ROUTER (frame único, JSON UTF-8). */
export interface RequestEnvelope<T = unknown> {
  v: 1;
  id: string;
  method: string;
  params: T;
  ts: string;
}

export interface ResponseEnvelope<T = unknown> {
  v: 1;
  id: string;
  ok: boolean;
  result?: T;
  error?: { code: string; message: string; detail?: unknown };
}

export interface EventEnvelope<T = unknown> {
  v: 1;
  topic: string;
  payload: T;
  ts: string;
}

/* ------------------------------------------------------------------ */
/* Métodos                                                             */
/* ------------------------------------------------------------------ */

export interface PingResult {
  service: string;
  version: string;
  pid: number;
  ts: string;
  /** Quantos comandos já foram atendidos nesta sessão. */
  served: number;
}

export interface EchoParams {
  message: string;
  repeat?: number;
}

export interface EchoResult {
  message: string;
  count: number;
}

/** Mapa método -> assinatura. É a única fonte de tipos para `request()`. */
export interface MethodMap {
  ping: { params: Record<string, never>; result: PingResult };
  echo: { params: EchoParams; result: EchoResult };
}

export type Method = keyof MethodMap;
export type MethodParams<M extends Method> = MethodMap[M]["params"];
export type MethodResult<M extends Method> = MethodMap[M]["result"];

/* ------------------------------------------------------------------ */
/* Estado do processo sidecar                                          */
/* ------------------------------------------------------------------ */

/**
 * Espelho de `Status` em `apps/desktop/src-tauri/src/sidecar.rs`.
 *
 * É o Rust que produz isto (o Python não conhece o próprio ciclo de vida), então
 * este é o único tipo do arquivo cuja fonte da verdade está do lado do Rust.
 * A tag `state` vem do `#[serde(tag = "state", rename_all = "lowercase")]`.
 */
export type SidecarStatus =
  | { state: "starting" }
  | { state: "ready"; pid: number; version: string; zmq_port: number; pub_port: number }
  | { state: "exited"; code: number | null }
  | { state: "error"; message: string }
  /** Desistimos depois de várias tentativas seguidas: não virá outra. */
  | { state: "stopped"; attempts: number };

/* ------------------------------------------------------------------ */
/* Tópicos de evento                                                   */
/* ------------------------------------------------------------------ */

export interface SidecarEventMap {
  ready: PingResult;
  sidecar: SidecarStatus;
  heartbeat: { ts: string; served: number };
}

export type EventTopic = keyof SidecarEventMap;
export type EventPayload<T extends EventTopic> = SidecarEventMap[T];
