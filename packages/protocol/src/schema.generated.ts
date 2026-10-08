// GERADO POR scripts/gen-schema.mjs a partir de db/schema.sql — NÃO EDITE.
// Rode `npm run schema:sync` para regravar; `npm run protocol:gen` falha se estiver velho.
//
// Tipos do contrato de dados compartilhado entre os dois frontends
// (ver docs/POSITRON.md). Colunas anuláveis aparecem como `T | null`.

export interface Fiacao {
  Indice: number;
  Revisao: string | null;
  DWG: number | null;
  Painel: number | null;
  Potencial: number | null;
  Ordem: number | null;
  Pagina: string | null;
  Tag: string | null;
  Alternativo: string | null;
  NRegua: string | null;
  Terminal: string | null;
  TerminalNum: number | null;
  Tipo: string | null;
  Secao: string | null;
  Cor: string | null;
  PosicaoNum: number | null;
  TipoBorne: number | null;
  BJumper: boolean;
  BLink: boolean;
  Handle: string | null;
  IndexModelo: number | null;
  Criador: string | null;
  Data: string | null;
  Aplicacao: number | null;
  Orientacao: string | null;
}

export interface Jumper4 {
  Indice: number;
  Revisao: string | null;
  DWG: number | null;
  Painel: number | null;
  Potencial: number | null;
  Ordem: number | null;
  Pagina: string | null;
  Tag: string | null;
  Alternativo: string | null;
  NRegua: string | null;
  Terminal: string | null;
  TerminalNum: number | null;
  Tipo: string | null;
  Secao: string | null;
  Cor: string | null;
  PosicaoNum: number | null;
  TipoBorne: number | null;
  BJumper: boolean;
  BLink: boolean;
  Handle: string | null;
  IndexModelo: number | null;
  Criador: string | null;
  Data: string | null;
}

export interface Interligacao4 {
  Indice: number;
  Revisao: string | null;
  DWG: number | null;
  Tag_Cabo: string | null;
  Num_Veia: number | null;
  Nome_Veia: string | null;
  DWG1: number | null;
  Documento1: string | null;
  Painel1: number | null;
  Tag1: string | null;
  Alternativo1: string | null;
  NRegua1: string | null;
  Terminal1: string | null;
  TerminalNum1: number | null;
  TipoBorne1: number | null;
  Handle1: string | null;
  Pagina1: string | null;
  Posicao1: string | null;
  IndexModelo1: number | null;
  DWG2: number | null;
  Documento2: string | null;
  Painel2: number | null;
  Tag2: string | null;
  Alternativo2: string | null;
  NRegua2: string | null;
  Terminal2: string | null;
  TerminalNum2: number | null;
  TipoBorne2: number | null;
  Handle2: string | null;
  Pagina2: string | null;
  Posicao2: string | null;
  IndexModelo2: number | null;
  Criador: string | null;
  Data: string | null;
}

export interface Bornes4F {
  Indice: number;
  Revisao: string | null;
  DWG: number | null;
  Painel: number | null;
  IndexRegua: number | null;
  Regua: string | null;
  Alternativo: string | null;
  Handle: string | null;
  Borne: string | null;
  Ordem: number | null;
  Tipo: number | null;
  Pagina: string | null;
  bReserva: boolean;
  LM: number | null;
  Orientacao: string | null;
  BlocoLayout: string | null;
}

export interface Bornes4I {
  Indice: number;
  Revisao: string | null;
  DWG: number | null;
  Painel: number | null;
  IndexRegua: number | null;
  Regua: string | null;
  Alternativo: string | null;
  Handle: string | null;
  Borne: string | null;
  Ordem: number | null;
  Tipo: number | null;
  Pagina: string | null;
  bReserva: boolean;
}

export interface Portas4F {
  Indice: number;
  Revisao: string | null;
  DWG: number | null;
  IndexModelo: number | null;
  NomeModelo: string | null;
  Regua: string | null;
  Borne: string | null;
  Terminal: string | null;
  TerminalNum: number | null;
  Tipo: string | null;
  Orientacao: string | null;
}

export interface Portas4I {
  Indice: number;
  Revisao: string | null;
  DWG: number | null;
  IndexModelo: number | null;
  NomeModelo: string | null;
  Regua: string | null;
  Borne: string | null;
  Terminal: string | null;
  TerminalNum: number | null;
  Tipo: string | null;
}

export interface Contatos4F {
  Indice: number;
  Revisao: string | null;
  DWG: number | null;
  IndexModelo: number | null;
  NomeModelo: string | null;
  Terminal: string | null;
  TerminalNum: number | null;
  Orientacao: string | null;
}

export interface Dispositivos4F {
  Indice: number;
  Revisao: string | null;
  DWG: number | null;
  Painel: number | null;
  Tag: string | null;
  Alternativo: string | null;
  Tipo: string | null;
  Handle: string | null;
  Pagina: string | null;
  BlocoTopografico: string | null;
  BlocoLayout: string | null;
  PosicaoNum: number | null;
  Ordem: number | null;
}

export interface Aranha4 {
  Indice: number;
  Revisao: string | null;
  Tag_Cabo: string | null;
  Painel: number | null;
  Caderno: string | null;
  Folha: string | null;
  Coluna: number | null;
}

export interface Circuitos4F {
  Indice: number;
  Revisao: string | null;
  DWG: number | null;
  Painel: number | null;
  Circuito: string | null;
  Potencial: number | null;
}

export interface Aplicacao4F {
  Indice: number;
  Revisao: string | null;
  DWG: number | null;
  Numero: number | null;
  Nome: string | null;
  Secao: string | null;
  Cor: string | null;
  TipoCabo: string | null;
  Isolacao: string | null;
}

export interface Atributos {
  Indice: number;
  DWG: number | null;
  Handle: string | null;
  Nome: string | null;
  Valor: string | null;
}

export interface Exportados {
  Indice: number;
  Codigo: number | null;
  Tipo: string | null;
  DWG: number | null;
  Caderno: string | null;
  Handle: string | null;
  Pagina: string | null;
  Posicao: string | null;
  Painel: number | null;
  Texto: string | null;
  DWGDest: number | null;
  CadernoDest: string | null;
  PaginaDest: string | null;
  PosicaoDest: string | null;
  NomeRegua: string | null;
  IndexModelo: number | null;
  Atualizado: boolean;
}

export interface Cabos4 {
  Indice: number;
  Revisao: string | null;
  Tag: string | null;
  Formacao: string | null;
  Blindagem: boolean;
  Pn1: number | null;
  Pn2: number | null;
  Codigo: string | null;
  Funcao: string | null;
  Aterrar: number | null;
  Comprimento: number | null;
  Trajeto: string | null;
  Instrucao: string | null;
  Diametro: number | null;
  Grupo: string | null;
  Cabos: number | null;
  Criador: string | null;
  Data: string | null;
}

export interface Veias4 {
  Indice: number;
  Revisao: string | null;
  Tag: string | null;
  Num_Veia: number | null;
  Nome_Veia: string | null;
  Uso: boolean;
  Funcao: string | null;
}

export interface Materiais {
  CodigoInterno: number | null;
  CodigoCliente: string | null;
  DescricaoResumida: string | null;
  DescricaoCompleta: string | null;
  Modelo: string | null;
  Fabricante: string | null;
  Indice: number;
}

export interface ListaMateriais {
  Indice: number;
  DWG: number | null;
  Painel: number | null;
  Tag: string | null;
  IndiceMaterial: number | null;
  Quantidade: number | null;
  Ordem: number | null;
  Avulso: boolean;
  Destino: string | null;
  DescDestino: string | null;
  Alternativo: string | null;
  Handle: string | null;
  IndiceLM: number | null;
  OrdemLay: number | null;
}

export interface ModelosCabos {
  Indice: number;
  CodigoCliente: string | null;
  Descricao: string | null;
  Prefixo: string | null;
  Conector1: string | null;
  BlocoConector1: string | null;
  Conector2: string | null;
  BlocoConector2: string | null;
  EstiloLinha: string | null;
  CorLinha: number | null;
  PesoLinha: number | null;
  EscalaLinha: number | null;
}

export interface Cabos {
  Tag: string;
  Formacao: string | null;
  Blindagem: boolean;
  Pn1: number | null;
  Pn2: number | null;
  Codigo: string | null;
  Funcao: string | null;
  Alarme: number | null;
  Aterrar: number | null;
  Comprimento: number | null;
  Trajeto: string | null;
  Instrucao: string | null;
  Diametro: number | null;
  Grupo: string | null;
  Cabos: number | null;
}

export interface Veias {
  Tag: string | null;
  Indice: number | null;
  Nome_Veia: string | null;
  Uso: boolean;
  Handle: string | null;
  Arquivo: number | null;
  Pagina: string | null;
  Chave: number;
  Funcao: string | null;
}

export interface Paineis {
  Indice: number;
  Nome: string | null;
  Criador: string | null;
  Editor: string | null;
  Data: string | null;
}

export interface PaineisH {
  Indice: number | null;
  Nome: string | null;
  Criador: string | null;
  Editor: string | null;
  Data: string | null;
}

export interface Plaquetas4 {
  Indice: number;
  DWG: number | null;
  Painel: number | null;
  Tag: string | null;
  Modelo: string | null;
  Desc1: string | null;
  Desc2: string | null;
  Desc3: string | null;
  Quantidade: number | null;
}

export interface DWG {
  Indice: number;
  Tipo: string | null;
  Caminho: string | null;
  Nome: string | null;
  Criador: string | null;
  Editor: string | null;
  Data: string | null;
}

export interface DWGH {
  Indice: number | null;
  Tipo: string | null;
  Caminho: string | null;
  Nome: string | null;
  Criador: string | null;
  Editor: string | null;
  Data: string | null;
}

export interface Sinais {
  Indice: number;
  ChavePrimaria: string | null;
  IndiceOrigem: number | null;
  IndiceDestino: number | null;
  TipoTag: number | null;
  Tipo: string | null;
  Tag: string | null;
  Tag61850: string | null;
  Enderecos61850: string | null;
  TagAlternativoEntrada: string | null;
  Descricao: string | null;
  Caderno: string | null;
  Vao: string | null;
  Painel: string | null;
  Unidade: string | null;
  Pagina: string | null;
}

export interface Configuracoes {
  Indice: number | null;
  Tipo: string | null;
  Comando: string | null;
  Valor: string | null;
}

export interface Preferencias {
  Indice: number;
  DWG: number | null;
  Painel: number | null;
  Campo: string | null;
  Valor: string | null;
}

export interface Comandos {
  Comando: string | null;
  Usuario: string | null;
  DWG: number | null;
}

export interface Correcao {
  Numero: number | null;
}

/** Mapa tabela -> tipo da linha. */
export interface TableMap {
  Fiacao: Fiacao;
  Jumper4: Jumper4;
  Interligacao4: Interligacao4;
  Bornes4F: Bornes4F;
  Bornes4I: Bornes4I;
  Portas4F: Portas4F;
  Portas4I: Portas4I;
  Contatos4F: Contatos4F;
  Dispositivos4F: Dispositivos4F;
  Aranha4: Aranha4;
  Circuitos4F: Circuitos4F;
  Aplicacao4F: Aplicacao4F;
  Atributos: Atributos;
  Exportados: Exportados;
  Cabos4: Cabos4;
  Veias4: Veias4;
  Materiais: Materiais;
  ListaMateriais: ListaMateriais;
  ModelosCabos: ModelosCabos;
  Cabos: Cabos;
  Veias: Veias;
  Paineis: Paineis;
  PaineisH: PaineisH;
  Plaquetas4: Plaquetas4;
  DWG: DWG;
  DWGH: DWGH;
  Sinais: Sinais;
  Configuracoes: Configuracoes;
  Preferencias: Preferencias;
  Comandos: Comandos;
  Correcao: Correcao;
}

export type TableName = keyof TableMap;
export type Row<T extends TableName> = TableMap[T];
