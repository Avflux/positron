/**
 * Contrato compartilhado UI <-> Rust <-> Python.
 *
 * ATENÇÃO: este arquivo é o espelho manual de
 * `services/sidecar/src/sidecar/protocol.py`. Ao mudar um método, mude os dois
 * e rode `npm run protocol:gen` (scripts/gen-protocol.ps1) que valida o diff.
 *
 * Convenção de nomes: métodos em snake_case (`list_fixtures`), para casar com o
 * `dispatch` do Python sem camada de tradução. O `gen-protocol` cobra isto (a
 * regex só aceita `[a-z_][a-z0-9_]*`), então nada de `namespace.metodo`.
 */

import type {
  Aplicacao4F,
  Bornes4I,
  Cabos4,
  Circuitos4F,
  Dispositivos4F,
  Fiacao,
  Interligacao4,
  Jumper4,
  Materiais,
  ModelosCabos,
  Paineis,
  Bornes4F,
  Contatos4F,
  Portas4F,
  Portas4I,
  Veias4,
} from "./schema.generated";

// Os tipos das linhas do banco fazem parte do contrato público: a UI importa
// `Paineis`, `Fiacao`, ... daqui, nunca do arquivo gerado direto.
export * from "./schema.generated";

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

/* ------------------------------------------------------------------ */
/* Banco do projeto (frontend APP)                                     */
/*                                                                     */
/* As linhas têm o formato do schema.sql, espelhado em                 */
/* schema.generated.ts. O plugin ZWCAD é quem escreve as tabelas       */
/* derivadas do diagrama; aqui o app lê (ver docs/POSITRON.md).        */
/* ------------------------------------------------------------------ */

export interface ProjetoAbrirParams {
  caminho: string;
}

export interface ProjetoAbrirResult {
  caminho: string;
  tabelas: string[];
}

export interface CatalogoListarMateriaisParams {
  filtro?: string | null;
}

export interface FiacaoPorPainelParams {
  painel: number;
  revisao?: string | null;
}

export interface InterligacaoPorCaboParams {
  tag_cabo: string;
}

export interface InterligacaoPorPainelParams {
  painel: number;
}

export interface CircuitosPorPainelParams {
  painel: number;
  revisao?: string | null;
}

export interface DispositivosPorPainelParams {
  painel: number;
  revisao?: string | null;
}

export interface AplicacoesPorRevisaoParams {
  revisao?: string | null;
}

export interface JumperPorPainelParams {
  painel: number;
  revisao?: string | null;
}

export interface Portas4IPorModeloParams {
  index_modelo: number;
}

export interface Bornes4IPorReguaParams {
  index_regua: number;
}

export interface Cabos4PorRevisaoParams {
  revisao?: string | null;
}

export interface Veias4PorRevisaoParams {
  revisao?: string | null;
}

export interface Portas4FPorRevisaoParams {
  revisao?: string | null;
}

export interface Bornes4FPorRevisaoParams {
  revisao?: string | null;
}

export interface Contatos4FPorRevisaoParams {
  revisao?: string | null;
}

/** Mapa método -> assinatura. É a única fonte de tipos para `request()`. */
export interface MethodMap {
  ping: { params: Record<string, never>; result: PingResult };
  echo: { params: EchoParams; result: EchoResult };
  projeto_abrir: { params: ProjetoAbrirParams; result: ProjetoAbrirResult };
  projeto_listar_paineis: { params: Record<string, never>; result: { paineis: Paineis[] } };
  catalogo_listar_materiais: {
    params: CatalogoListarMateriaisParams;
    result: { materiais: Materiais[] };
  };
  catalogo_listar_modelos_cabo: {
    params: Record<string, never>;
    result: { modelos: ModelosCabos[] };
  };
  fiacao_por_painel: { params: FiacaoPorPainelParams; result: { fios: Fiacao[] } };
  interligacao_por_cabo: {
    params: InterligacaoPorCaboParams;
    result: { trechos: Interligacao4[] };
  };
  interligacao_por_painel: {
    params: InterligacaoPorPainelParams;
    result: { trechos: Interligacao4[] };
  };
  circuitos_por_painel: {
    params: CircuitosPorPainelParams;
    result: { circuitos: Circuitos4F[] };
  };
  dispositivos_por_painel: {
    params: DispositivosPorPainelParams;
    result: { dispositivos: Dispositivos4F[] };
  };
  aplicacoes_por_revisao: {
    params: AplicacoesPorRevisaoParams;
    result: { aplicacoes: Aplicacao4F[] };
  };
  jumper_por_painel: {
    params: JumperPorPainelParams;
    result: { jumpers: Jumper4[] };
  };
  portas4i_por_modelo: {
    params: Portas4IPorModeloParams;
    result: { portas: Portas4I[] };
  };
  bornes4i_por_regua: {
    params: Bornes4IPorReguaParams;
    result: { bornes: Bornes4I[] };
  };
  cabos4_por_revisao: {
    params: Cabos4PorRevisaoParams;
    result: { cabos: Cabos4[] };
  };
  veias4_por_revisao: {
    params: Veias4PorRevisaoParams;
    result: { veias: Veias4[] };
  };
  portas4f_por_revisao: {
    params: Portas4FPorRevisaoParams;
    result: { portas: Portas4F[] };
  };
  bornes4f_por_revisao: {
    params: Bornes4FPorRevisaoParams;
    result: { bornes: Bornes4F[] };
  };
  contatos4f_por_revisao: {
    params: Contatos4FPorRevisaoParams;
    result: { contatos: Contatos4F[] };
  };
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
