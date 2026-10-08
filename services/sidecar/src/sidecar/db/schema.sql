-- ============================================================================
-- Schema do banco do projeto (SQLite) — FONTE DA VERDADE do contrato de dados.
-- ============================================================================
--
-- Este arquivo é o contrato entre os dois frontends (ver docs/POSITRON.md):
--   - o frontend APP lê/escreve pelo sidecar (Python);
--   - o frontend ZWCAD (plugin .NET) escreve direto, durante o desenho.
--
-- Ele foi extraído fielmente de `BD Projeto/Modelo de BD Projeto.db`
-- (engenharia reversa em ..\..\..\Elet\Eletron4_ZWcad). Mantenha o DDL
-- identificável: `scripts/gen-schema.mjs` o parseia para gerar os tipos
-- TypeScript (packages/protocol/src/schema.generated.ts) e C#
-- (packages/protocol/csharp/Tables.g.cs).
--
--     npm run schema:sync    # regrava os tipos gerados
--     npm run protocol:gen   # FALHA se os tipos gerados estiverem desatualizados
--
-- Dono da escrita (`quem desenha, grava`): tabelas marcadas [plugin] só são
-- escritas pelo plugin ZWCAD, que projeta o diagrama para elas. [app] são
-- catálogo/projeto/configuração. Todos os lados podem LER qualquer tabela.

-- ---------------------------------------------------------------------------
-- [plugin] Fiação e interligação — derivadas do diagrama funcional
-- ---------------------------------------------------------------------------

CREATE TABLE Fiacao(Indice INTEGER NOT NULL PRIMARY KEY, Revisao VARCHAR(5), DWG INTEGER, Painel INTEGER, Potencial INTEGER, Ordem INTEGER, Pagina VARCHAR(20), Tag VARCHAR(50), Alternativo VARCHAR(50), NRegua VARCHAR(50), Terminal VARCHAR(50), TerminalNum REAL, Tipo CHAR(1), Secao VARCHAR(10), Cor VARCHAR(50), PosicaoNum INTEGER, TipoBorne INTEGER, BJumper BOOL NOT NULL, BLink BOOL NOT NULL, Handle VARCHAR(20), IndexModelo INTEGER, Criador VARCHAR(20), Data DATETIME, Aplicacao INTEGER, Orientacao CHAR(1));

CREATE TABLE Jumper4(Indice INTEGER NOT NULL PRIMARY KEY, Revisao VARCHAR(5), DWG INTEGER, Painel INTEGER, Potencial INTEGER, Ordem INTEGER, Pagina VARCHAR(20), Tag VARCHAR(50), Alternativo VARCHAR(50), NRegua VARCHAR(50), Terminal VARCHAR(50), TerminalNum REAL, Tipo CHAR(1), Secao VARCHAR(10), Cor VARCHAR(50), PosicaoNum INTEGER, TipoBorne INTEGER, BJumper BOOL NOT NULL, BLink BOOL NOT NULL, Handle VARCHAR(20), IndexModelo INTEGER, Criador VARCHAR(20), Data DATETIME);

CREATE TABLE Interligacao4(Indice INTEGER NOT NULL PRIMARY KEY, Revisao VARCHAR(5), DWG INTEGER, Tag_Cabo VARCHAR(50), Num_Veia INTEGER, Nome_Veia VARCHAR(100), DWG1 INTEGER, Documento1 VARCHAR(50), Painel1 INTEGER, Tag1 VARCHAR(50), Alternativo1 VARCHAR(50), NRegua1 VARCHAR(50), Terminal1 VARCHAR(50), TerminalNum1 REAL, TipoBorne1 INTEGER, Handle1 VARCHAR(20), Pagina1 VARCHAR(255), Posicao1 VARCHAR(10), IndexModelo1 INTEGER, DWG2 INTEGER, Documento2 VARCHAR(50), Painel2 INTEGER, Tag2 VARCHAR(50), Alternativo2 VARCHAR(50), NRegua2 VARCHAR(50), Terminal2 VARCHAR(50), TerminalNum2 REAL, TipoBorne2 INTEGER, Handle2 VARCHAR(20), Pagina2 VARCHAR(255), Posicao2 VARCHAR(10), IndexModelo2 INTEGER, Criador VARCHAR(20), Data DATETIME);

CREATE TABLE Bornes4F(Indice INTEGER NOT NULL PRIMARY KEY, Revisao VARCHAR(5), DWG INTEGER, Painel INTEGER, IndexRegua INTEGER, Regua VARCHAR(50), Alternativo VARCHAR(50), Handle VARCHAR(20), Borne VARCHAR(10), Ordem REAL, Tipo INTEGER, Pagina VARCHAR(20), bReserva BOOL NOT NULL, LM INTEGER, Orientacao CHAR(1), BlocoLayout VARCHAR(200));

CREATE TABLE Bornes4I(Indice INTEGER NOT NULL PRIMARY KEY, Revisao VARCHAR(5), DWG INTEGER, Painel INTEGER, IndexRegua INTEGER, Regua VARCHAR(50), Alternativo VARCHAR(50), Handle VARCHAR(20), Borne VARCHAR(10), Ordem REAL, Tipo INTEGER, Pagina VARCHAR(20), bReserva BOOL NOT NULL);

CREATE TABLE Portas4F(Indice INTEGER NOT NULL PRIMARY KEY, Revisao VARCHAR(5), DWG INTEGER, IndexModelo INTEGER, NomeModelo VARCHAR(255), Regua VARCHAR(50), Borne VARCHAR(50), Terminal VARCHAR(50), TerminalNum REAL, Tipo CHAR(1), Orientacao CHAR(1));

CREATE TABLE Portas4I(Indice INTEGER NOT NULL PRIMARY KEY, Revisao VARCHAR(5), DWG INTEGER, IndexModelo INTEGER, NomeModelo VARCHAR(255), Regua VARCHAR(50), Borne VARCHAR(50), Terminal VARCHAR(50), TerminalNum REAL, Tipo CHAR(1));

CREATE TABLE Contatos4F(Indice INTEGER NOT NULL PRIMARY KEY, Revisao VARCHAR(5), DWG INTEGER, IndexModelo INTEGER, NomeModelo VARCHAR(255), Terminal VARCHAR(50), TerminalNum REAL, Orientacao CHAR(1));

CREATE TABLE Dispositivos4F(Indice INTEGER NOT NULL PRIMARY KEY, Revisao VARCHAR(5), DWG INTEGER, Painel INTEGER, Tag VARCHAR(50), Alternativo VARCHAR(50), Tipo CHAR(1), Handle VARCHAR(20), Pagina VARCHAR(20), BlocoTopografico VARCHAR(255), BlocoLayout VARCHAR(255), PosicaoNum INTEGER, Ordem INTEGER);

CREATE TABLE Aranha4(Indice INTEGER NOT NULL PRIMARY KEY, Revisao VARCHAR(5), Tag_Cabo VARCHAR(50), Painel INTEGER, Caderno VARCHAR(50), Folha VARCHAR(20), Coluna INTEGER);

CREATE TABLE Circuitos4F(Indice INTEGER NOT NULL PRIMARY KEY, Revisao VARCHAR(5), DWG INTEGER, Painel INTEGER, Circuito VARCHAR(50), Potencial INTEGER);

CREATE TABLE Aplicacao4F(Indice INTEGER NOT NULL PRIMARY KEY, Revisao VARCHAR(5), DWG INTEGER, Numero INTEGER, Nome VARCHAR(150), Secao VARCHAR(20), Cor VARCHAR(20), TipoCabo VARCHAR(150), Isolacao VARCHAR(150));

CREATE TABLE Atributos(Indice INTEGER NOT NULL PRIMARY KEY, DWG INTEGER, Handle VARCHAR(20), Nome VARCHAR(100), Valor VARCHAR(255));

CREATE TABLE Exportados(Indice INTEGER NOT NULL PRIMARY KEY, Codigo INTEGER, Tipo CHAR(1), DWG INTEGER, Caderno VARCHAR(255), Handle VARCHAR(20), Pagina VARCHAR(20), Posicao VARCHAR(20), Painel INTEGER, Texto VARCHAR(255), DWGDest INTEGER, CadernoDest VARCHAR(255), PaginaDest VARCHAR(20), PosicaoDest VARCHAR(20), NomeRegua VARCHAR(100), IndexModelo INTEGER, Atualizado BOOL NOT NULL);

-- ---------------------------------------------------------------------------
-- [plugin] Instâncias de cabo/veia criadas ao lançar no diagrama
-- (a definição/catálogo correspondente é [app]: Cabos e Veias)
-- ---------------------------------------------------------------------------

CREATE TABLE Cabos4(Indice INTEGER NOT NULL PRIMARY KEY, Revisao VARCHAR(5), Tag VARCHAR(50), Formacao VARCHAR(15), Blindagem BOOL NOT NULL, Pn1 INTEGER, Pn2 INTEGER, Codigo VARCHAR(20), Funcao VARCHAR(255), Aterrar INTEGER, Comprimento REAL, Trajeto TEXT, Instrucao VARCHAR(255), Diametro REAL, Grupo VARCHAR(50), Cabos INTEGER, Criador VARCHAR(20), Data DATETIME);

CREATE TABLE Veias4(Indice INTEGER NOT NULL PRIMARY KEY, Revisao VARCHAR(5), Tag VARCHAR(50), Num_Veia INTEGER, Nome_Veia VARCHAR(100), Uso BOOL NOT NULL, Funcao VARCHAR(50));

-- ---------------------------------------------------------------------------
-- [app] Catálogo e projeto
-- ---------------------------------------------------------------------------

CREATE TABLE Materiais(CodigoInterno INTEGER, CodigoCliente VARCHAR(250), DescricaoResumida VARCHAR(250), DescricaoCompleta TEXT, Modelo VARCHAR(250), Fabricante VARCHAR(250), Indice INTEGER NOT NULL PRIMARY KEY);

CREATE TABLE ListaMateriais(Indice INTEGER NOT NULL PRIMARY KEY, DWG INTEGER, Painel INTEGER, Tag VARCHAR(50), IndiceMaterial INTEGER, Quantidade SMALLINT, Ordem INTEGER, Avulso BOOL NOT NULL, Destino VARCHAR(10), DescDestino VARCHAR(20), Alternativo VARCHAR(20), Handle VARCHAR(20), IndiceLM INTEGER, OrdemLay INTEGER);

CREATE TABLE ModelosCabos(Indice INTEGER NOT NULL PRIMARY KEY, CodigoCliente VARCHAR(10), Descricao VARCHAR(255), Prefixo VARCHAR(5), Conector1 VARCHAR(20), BlocoConector1 VARCHAR(20), Conector2 VARCHAR(20), BlocoConector2 VARCHAR(20), EstiloLinha VARCHAR(50), CorLinha INTEGER, PesoLinha REAL, EscalaLinha REAL);

CREATE TABLE Cabos(Tag VARCHAR(50) PRIMARY KEY, Formacao VARCHAR(15), Blindagem BOOL NOT NULL, Pn1 SMALLINT, Pn2 SMALLINT, Codigo VARCHAR(20), Funcao VARCHAR(255), Alarme SMALLINT, Aterrar SMALLINT, Comprimento REAL, Trajeto TEXT, Instrucao VARCHAR(255), Diametro REAL, Grupo VARCHAR(50), Cabos SMALLINT);

CREATE TABLE Veias(Tag VARCHAR(50), Indice SMALLINT, Nome_Veia VARCHAR(100), Uso BOOL NOT NULL, Handle VARCHAR(20), Arquivo SMALLINT, Pagina VARCHAR(10), Chave INTEGER NOT NULL PRIMARY KEY, Funcao VARCHAR(50));

CREATE TABLE Paineis(Indice SMALLINT PRIMARY KEY, Nome VARCHAR(50), Criador VARCHAR(50), Editor VARCHAR(50), Data DATETIME);

CREATE TABLE PaineisH(Indice INTEGER, Nome VARCHAR(50), Criador VARCHAR(50), Editor VARCHAR(50), Data DATETIME);

CREATE TABLE Plaquetas4(Indice INTEGER NOT NULL PRIMARY KEY, DWG INTEGER, Painel INTEGER, Tag VARCHAR(50), Modelo VARCHAR(10), Desc1 VARCHAR(40), Desc2 VARCHAR(40), Desc3 VARCHAR(40), Quantidade INTEGER);

CREATE TABLE DWG(Indice SMALLINT PRIMARY KEY, Tipo CHAR(1), Caminho TEXT, Nome VARCHAR(50), Criador VARCHAR(50), Editor VARCHAR(50), Data DATETIME);

CREATE TABLE DWGH(Indice INTEGER, Tipo CHAR(1), Caminho TEXT, Nome VARCHAR(50), Criador VARCHAR(50), Editor VARCHAR(50), Data DATETIME);

CREATE TABLE Sinais(Indice INTEGER NOT NULL PRIMARY KEY, ChavePrimaria VARCHAR(100), IndiceOrigem INTEGER, IndiceDestino INTEGER, TipoTag INTEGER, Tipo VARCHAR(30), Tag VARCHAR(100), Tag61850 VARCHAR(100), Enderecos61850 VARCHAR(100), TagAlternativoEntrada VARCHAR(100), Descricao VARCHAR(255), Caderno VARCHAR(100), Vao VARCHAR(100), Painel VARCHAR(150), Unidade VARCHAR(100), Pagina VARCHAR(30));

CREATE TABLE Configuracoes(Indice INTEGER, Tipo CHAR(1), Comando VARCHAR(10), Valor TEXT);

CREATE TABLE Preferencias(Indice INTEGER NOT NULL PRIMARY KEY, DWG INTEGER, Painel INTEGER, Campo VARCHAR(100), Valor VARCHAR(100));

CREATE TABLE Comandos(Comando VARCHAR(10), Usuario VARCHAR(50), DWG SMALLINT);

CREATE TABLE Correcao(Numero SMALLINT);
