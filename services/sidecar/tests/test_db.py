"""Testes do acesso ao banco do projeto (frontend APP).

O banco de teste é montado a partir do próprio `schema.sql` canônico: se o
schema e as consultas divergirem, estes testes quebram. Nada de mock — é
SQLite de verdade, como em `test_roundtrip.py` com o ZMQ.
"""

from __future__ import annotations

import sqlite3
from pathlib import Path

import pytest

import sidecar
from sidecar.db import ProjectDatabase
from sidecar.handlers import Handlers
from sidecar.protocol import BadParams, DatabaseError, DatabaseNotOpen

SCHEMA_PATH = Path(sidecar.__file__).parent / "db" / "schema.sql"


def make_project_db(target: Path) -> Path:
    """Cria um `.db` com o schema real e um punhado de linhas conhecidas."""
    connection = sqlite3.connect(target)
    connection.executescript(SCHEMA_PATH.read_text(encoding="utf-8"))
    connection.executescript(
        """
        INSERT INTO Paineis(Indice, Nome, Criador, Editor) VALUES
            (2, 'PT2', 'ana', 'bia'),
            (1, 'PT1', 'ana', 'bia');

        INSERT INTO Materiais(
            Indice, CodigoInterno, CodigoCliente, DescricaoResumida, DescricaoCompleta,
            Modelo, Fabricante
        )
            VALUES (1, 1001, 'CLI-1', 'Disjuntor 20A', 'DISJUNTOR 20A COMPLETA', 'DJ-20A',
                    'Siemens'),
                   (2, 1002, 'CLI-2', 'Borne 4mm', 'BORNE 4MM COMPLETA', 'BR-4', 'Wago');

        INSERT INTO ModelosCabos(Indice, CodigoCliente, Descricao) VALUES
            (1, 'M-1', 'Cabo blindado');

        INSERT INTO Fiacao(Indice, Revisao, DWG, Painel, Ordem, Tag, Terminal, BJumper, BLink)
            VALUES (10, 'R0', 1, 1, 4, 'A1', '1', 0, 0),
                   (11, 'R0', 1, 1, 2, 'A2', '2', 0, 0),
                   (12, 'R0', 1, 2, 1, 'B1', '1', 0, 0);

        INSERT INTO Interligacao4(
            Indice, Revisao, DWG, Tag_Cabo, Num_Veia, Painel1, Pagina1, Tag1, NRegua1, Terminal1,
            Documento1, Painel2, Pagina2, Tag2, NRegua2, Terminal2, Documento2
        )
            VALUES (20, 'R0', 1, 'C-100', 1, 1, '8', 'A1', '', '1', 'DOC-A',
                    2, '9', 'B1', 'R1', NULL, 'DOC-B'),
                   (21, 'R0', 1, 'C-100', 2, 1, '8', 'A2', '', '2', 'DOC-A',
                    2, '9', 'B2', '', '2', 'DOC-B'),
                   (22, 'R0', 1, 'C-200', 1, 1, '8', 'A1', '', '1', 'DOC-A',
                    3, '9', 'C1', '', '1', 'DOC-C'),
                   -- ponta 1 = a REGUA (Tag1 = nome da regua, NRegua1 NULL): e o que o
                   -- relatorio de interligacao procura. Terminal2 = '0' cai no `?`.
                   (23, 'R0', 1, 'C-100', 3, 1, '9', 'R1', NULL, '11', 'DOC-A',
                    2, '9', 'B1', '', '0', 'DOC-B');

        INSERT INTO Circuitos4F(Indice, Revisao, DWG, Painel, Circuito, Potencial)
            VALUES (30, 'R0', 1, 1, 'C1', 5),
                   (31, 'R0', 1, 1, 'C2', 3),
                   (32, 'R0', 1, 2, 'C3', 7);

        INSERT INTO Dispositivos4F(Indice, Revisao, DWG, Painel, Tag, Tipo)
            VALUES (40, 'R0', 1, 1, 'D2', 'P'),
                   (41, 'R0', 1, 1, 'D1', 'M'),
                   (42, 'R0', 1, 2, 'D3', 'P');

        INSERT INTO Aplicacao4F(Indice, Revisao, DWG, Numero, Nome, Secao)
            VALUES (50, 'R0', 1, 2, 'AP2', '4'),
                   (51, 'R0', 1, 1, 'AP1', '2,5');

        INSERT INTO Jumper4(Indice, Revisao, DWG, Painel, Potencial, Ordem, Tag, BJumper, BLink)
            VALUES (60, 'R0', 1, 1, 7, 2, 'J2', 1, 0),
                   (61, 'R0', 1, 1, 7, 1, 'J1', 1, 0),
                   (62, 'R0', 1, 2, 3, 1, 'J3', 1, 0);

        INSERT INTO Portas4I(Indice, Revisao, DWG, IndexModelo, NomeModelo, Regua, Borne, Tipo)
            VALUES (70, 'R0', 1, 8, 'M8', 'R1', '11', 'B');

        INSERT INTO Bornes4I(
            Indice, Revisao, Painel, IndexRegua, Regua, Borne, Ordem, bReserva, Tipo
        )
            VALUES (80, 'R0', 1, 5, 'R1', '12', 2.0, 0, 0),
                   (81, 'R0', 1, 5, 'R1', '11', 1.0, 0, 0);

        INSERT INTO Cabos4(
            Indice, Revisao, Tag, Blindagem, Formacao, Funcao, Aterrar, Pn1, Pn2, Cabos, Comprimento
        )
            VALUES (90, 'R0', 'C-100', 1, '3x2,5', 'F1', 3, 1, 2, 2, 12.5);

        INSERT INTO Contatos4F(Indice, Revisao, DWG, IndexModelo, NomeModelo, Terminal)
            VALUES (120, 'R0', 1, 7, 'FUSIVEL', '1');

        INSERT INTO Portas4F(Indice, Revisao, DWG, IndexModelo, NomeModelo, Tipo, Terminal)
            VALUES (100, 'R0', 1, 7, 'FUSIVEL', 'T', '1'),
                   (101, 'R0', 1, 7, 'FUSIVEL', 'T', '2');

        INSERT INTO Bornes4F(Indice, Revisao, Painel, IndexRegua, Regua, Borne, Ordem, bReserva)
            VALUES (110, 'R0', 503, 5, 'R1', '11', 1.0, 0);

        INSERT INTO Veias4(Indice, Revisao, Tag, Num_Veia, Uso, Nome_Veia, Funcao)
            VALUES (95, 'R0', 'C-100', 1, 0, 'V1', 'FV'),
                   (96, 'R0', 'C-100', 2, 0, '', 'FV2'),
                   (97, 'R0', 'C-100', -60, 0, 'RESERVA', '');

        INSERT INTO Plaquetas4(Indice, DWG, Painel, Tag, Modelo, Desc1, Desc2)
            VALUES (130, 1, 1, 'PLACA-B', 'MB', 'Placa B', NULL),
                   (131, 1, 1, 'PLACA-A', 'MA', 'Placa A', 'linha 2'),
                   (132, 1, 2, 'PLACA-C', 'MC', 'Placa C', NULL);

        INSERT INTO ListaMateriais(
            Indice, DWG, Painel, Tag, IndiceMaterial, Quantidade, Ordem, Avulso, Handle,
            IndiceLM, OrdemLay
        )
            VALUES (140, 1, 1, 'D2', 459, 1, 2, 0, '4B', 0, 12),
                   (141, 1, 1, 'R6', 476, 63, 1, 0, 'BORNE', 0, 10000),
                   (143, 1, 1, 'D1', 1001, 2, 1, 0, NULL, 7, 0),
                   (142, 1, 2, 'MF', 518, 1, 1, 1, NULL, 44, 0);
        """
    )
    connection.commit()
    connection.close()
    return target


def make_fiacao_db(target: Path) -> Path:
    """Um banco só com o grafo da `Fiacao` que o relatório de Fiação percorre.

    O painel 1 tem três dispositivos (`D1`/`D2`/`D3`) no **mesmo potencial** (5), nas
    ordens 1..3, cada um com a `Seção`/`Cor` da sua própria linha, e um `D9` com
    **modelo de contato** (`IndexModelo = 7`) cujo terminal do modelo não tem linha na
    `Fiacao` — é o caso das ligações vazias.
    """
    connection = sqlite3.connect(target)
    connection.executescript(SCHEMA_PATH.read_text(encoding="utf-8"))
    connection.executescript(
        """
        INSERT INTO Paineis(Indice, Nome) VALUES (1, 'PT1');

        INSERT INTO Fiacao(
            Indice, Revisao, DWG, Painel, Potencial, Ordem, Pagina, Tag, Terminal, Tipo,
            Secao, Cor, BJumper, BLink, NRegua, IndexModelo, TerminalNum
        )
            VALUES (1, 'R0', 1, 1, 5, 1, '10', 'D1', '1', 'P', '2,5', 'P', 0, 0, '', 0, 1),
                   (2, 'R0', 1, 1, 5, 2, '10', 'D2', '1', 'P', '4',   'B', 0, 0, '', 0, 1),
                   (3, 'R0', 1, 1, 5, 3, '10', 'D3', '1', 'P', '6',   'R', 0, 0, '', 0, 1),
                   (4, 'R0', 1, 1, 9, 1, '11', 'D9', 'Z', 'P', '1,5', 'B', 0, 0, '', 7, 1);

        INSERT INTO Contatos4F(Indice, Revisao, DWG, IndexModelo, NomeModelo, Terminal)
            VALUES (200, 'R0', 1, 7, 'FUSIVEL', '1');
        """
    )
    connection.commit()
    connection.close()
    return target


@pytest.fixture
def project_db(tmp_path: Path) -> Path:
    return make_project_db(tmp_path / "projeto.db")


def make_fiacao_ramos_db(target: Path) -> Path:
    """Um banco que exercita os ramos de **3, 4 e mais de 4** ligações.

    Cada dispositivo (`D4`/`D5`/`D6`) aparece em vários potenciais — é a soma dos vizinhos
    de cada linha que decide o formato. Os vizinhos entram como linhas de **tipo `B`**,
    que o modo `rbDispositivos` **não** lista como dispositivo: são ligação, não seção.
    """
    connection = sqlite3.connect(target)
    connection.executescript(SCHEMA_PATH.read_text(encoding="utf-8"))
    connection.executescript(
        """
        INSERT INTO Paineis(Indice, Nome) VALUES (1, 'PT1');

        INSERT INTO Fiacao(
            Indice, Revisao, DWG, Painel, Potencial, Ordem, Pagina, Tag, Terminal, Tipo,
            Secao, Cor, BJumper, BLink, NRegua, IndexModelo, TerminalNum
        )
            VALUES
            -- D4: pot. 6 (Ordem 2) + pot. 7 (Ordem 1) = 3 ligacoes.
            (1,  'R0', 1, 1, 6,  2, '20', 'D4',  '1', 'P', '2,5', 'P', 0, 0, '', 0, 1),
            (2,  'R0', 1, 1, 7,  1, '20', 'D4',  '1', 'P', '4',   'B', 0, 0, '', 0, 1),
            (3,  'R0', 1, 1, 6,  1, '20', 'RA1', '1', 'B', '2,5', 'P', 0, 0, '', 0, 1),
            (4,  'R0', 1, 1, 6,  3, '20', 'RA2', '1', 'B', '2,5', 'P', 0, 0, '', 0, 1),
            (5,  'R0', 1, 1, 7,  2, '20', 'RA3', '1', 'B', '4',   'B', 0, 0, '', 0, 1),
            -- D5: pot. 8 + pot. 10 (os dois na Ordem 2) = 4 ligacoes.
            (6,  'R0', 1, 1, 8,  2, '30', 'D5',  '1', 'P', '1,5', 'P', 0, 0, '', 0, 1),
            (7,  'R0', 1, 1, 10, 2, '30', 'D5',  '1', 'P', '2,5', 'P', 0, 0, '', 0, 1),
            (8,  'R0', 1, 1, 8,  1, '30', 'RB1', '1', 'B', '1,5', 'P', 0, 0, '', 0, 1),
            (9,  'R0', 1, 1, 8,  3, '30', 'RB2', '1', 'B', '1,5', 'P', 0, 0, '', 0, 1),
            (10, 'R0', 1, 1, 10, 1, '30', 'RB3', '1', 'B', '2,5', 'P', 0, 0, '', 0, 1),
            (11, 'R0', 1, 1, 10, 3, '30', 'RB4', '1', 'B', '2,5', 'P', 0, 0, '', 0, 1),
            -- D6: pot. 11 + pot. 12 (Ordem 2) + pot. 13 (Ordem 1) = 5 ligacoes.
            (12, 'R0', 1, 1, 11, 2, '40', 'D6',  '1', 'P', '1,5', 'P', 0, 0, '', 0, 1),
            (13, 'R0', 1, 1, 12, 2, '40', 'D6',  '1', 'P', '2,5', 'P', 0, 0, '', 0, 1),
            (14, 'R0', 1, 1, 13, 1, '40', 'D6',  '1', 'P', '3,5', 'P', 0, 0, '', 0, 1),
            (15, 'R0', 1, 1, 11, 1, '40', 'RC1', '1', 'B', '1,5', 'P', 0, 0, '', 0, 1),
            (16, 'R0', 1, 1, 11, 3, '40', 'RC2', '1', 'B', '1,5', 'P', 0, 0, '', 0, 1),
            (17, 'R0', 1, 1, 12, 1, '40', 'RC3', '1', 'B', '2,5', 'P', 0, 0, '', 0, 1),
            (18, 'R0', 1, 1, 12, 3, '40', 'RC4', '1', 'B', '2,5', 'P', 0, 0, '', 0, 1),
            (19, 'R0', 1, 1, 13, 2, '40', 'RC5', '1', 'B', '3,5', 'P', 0, 0, '', 0, 1);
        """
    )
    connection.commit()
    connection.close()
    return target


@pytest.fixture
def fiacao_db(tmp_path: Path) -> Path:
    return make_fiacao_db(tmp_path / "fiacao.db")


@pytest.fixture
def fiacao_ramos_db(tmp_path: Path) -> Path:
    return make_fiacao_ramos_db(tmp_path / "fiacao-ramos.db")


async def test_projeto_abrir_e_listar_paineis(project_db: Path):
    handlers = Handlers()
    opened = await handlers.dispatch("projeto_abrir", {"caminho": str(project_db)})
    assert opened["caminho"] == str(project_db)
    assert "Paineis" in opened["tabelas"]

    paineis = await handlers.dispatch("projeto_listar_paineis")
    assert [p["Nome"] for p in paineis["paineis"]] == ["PT1", "PT2"]
    # A linha chega com as colunas do schema, não como tupla posicional.
    assert paineis["paineis"][0]["Criador"] == "ana"


async def test_paineis_sem_projeto_aberto_falha(project_db: Path):
    handlers = Handlers()
    with pytest.raises(DatabaseNotOpen):
        await handlers.dispatch("projeto_listar_paineis")


async def test_db_path_da_config_abre_na_subida(project_db: Path):
    handlers = Handlers(str(project_db))
    paineis = await handlers.dispatch("projeto_listar_paineis")
    assert len(paineis["paineis"]) == 2


async def test_fiacao_por_painel_respeita_painel_e_ordem(project_db: Path):
    handlers = Handlers(str(project_db))
    painel1 = await handlers.dispatch("fiacao_por_painel", {"painel": 1})
    # Ordem crescente: A2 (2) antes de A1 (4).
    assert [f["Tag"] for f in painel1["fios"]] == ["A2", "A1"]

    painel2 = await handlers.dispatch("fiacao_por_painel", {"painel": 2})
    assert [f["Tag"] for f in painel2["fios"]] == ["B1"]


async def test_booleans_chegam_como_bool_e_inteiros_como_int(project_db: Path):
    """SQLite guarda BOOL como 0/1; o contrato TS diz `boolean`. Não pode divergir."""
    handlers = Handlers(str(project_db))
    fios = (await handlers.dispatch("fiacao_por_painel", {"painel": 1}))["fios"]
    assert all(isinstance(fio["BJumper"], bool) for fio in fios)
    assert fios[0]["BJumper"] is False
    # Coluna INTEGER continua inteira — o conversor não é global.
    assert isinstance(fios[0]["Indice"], int)
    # E coluna não preenchida continua None, não vira False.
    assert fios[0]["Potencial"] is None


async def test_fiacao_por_painel_filtra_revisao(project_db: Path):
    handlers = Handlers(str(project_db))
    vazio = await handlers.dispatch("fiacao_por_painel", {"painel": 1, "revisao": "R9"})
    assert vazio["fios"] == []


async def test_interligacao_por_cabo_traz_trechos_ordenados(project_db: Path):
    handlers = Handlers(str(project_db))
    trechos = await handlers.dispatch("interligacao_por_cabo", {"tag_cabo": "C-100"})
    # As duas veias de ponta 1 de dispositivo e a veia de ponta 1 de **régua** (a do
    # relatório de interligação).
    assert [t["Num_Veia"] for t in trechos["trechos"]] == [1, 2, 3]
    assert trechos["trechos"][0]["Tag1"] == "A1"
    assert trechos["trechos"][0]["Tag2"] == "B1"
    assert trechos["trechos"][2]["Tag1"] == "R1"


async def test_interligacao_por_painel_pega_as_duas_pontas(project_db: Path):
    handlers = Handlers(str(project_db))
    trechos = await handlers.dispatch("interligacao_por_painel", {"painel": 2})
    # Painel 2 só aparece como destino nas duas veias de C-100.
    assert {t["Tag_Cabo"] for t in trechos["trechos"]} == {"C-100"}


async def test_circuitos_por_painel_ordenados_por_potencial(project_db: Path):
    handlers = Handlers(str(project_db))
    painel1 = await handlers.dispatch("circuitos_por_painel", {"painel": 1})
    # Potencial crescente: C2 (3) antes de C1 (5).
    assert [c["Circuito"] for c in painel1["circuitos"]] == ["C2", "C1"]

    painel2 = await handlers.dispatch("circuitos_por_painel", {"painel": 2})
    assert [c["Circuito"] for c in painel2["circuitos"]] == ["C3"]

    vazio = await handlers.dispatch("circuitos_por_painel", {"painel": 1, "revisao": "R9"})
    assert vazio["circuitos"] == []


async def test_dispositivos_por_painel_ordenados_por_tag(project_db: Path):
    handlers = Handlers(str(project_db))
    dispositivos = await handlers.dispatch("dispositivos_por_painel", {"painel": 1})
    assert [d["Tag"] for d in dispositivos["dispositivos"]] == ["D1", "D2"]
    assert dispositivos["dispositivos"][0]["Tipo"] == "M"


async def test_aplicacoes_por_revisao_ordenadas_por_numero(project_db: Path):
    handlers = Handlers(str(project_db))
    aplicacoes = await handlers.dispatch("aplicacoes_por_revisao", {})
    assert [a["Nome"] for a in aplicacoes["aplicacoes"]] == ["AP1", "AP2"]

    filtrado = await handlers.dispatch("aplicacoes_por_revisao", {"revisao": "R9"})
    assert filtrado["aplicacoes"] == []


async def test_jumper_por_painel_ordenado_por_potencial_e_ordem(project_db: Path):
    handlers = Handlers(str(project_db))
    painel1 = await handlers.dispatch("jumper_por_painel", {"painel": 1})
    assert [j["Tag"] for j in painel1["jumpers"]] == ["J1", "J2"]
    assert painel1["jumpers"][0]["BJumper"] is True

    painel2 = await handlers.dispatch("jumper_por_painel", {"painel": 2})
    assert [j["Tag"] for j in painel2["jumpers"]] == ["J3"]

    vazio = await handlers.dispatch("jumper_por_painel", {"painel": 1, "revisao": "R9"})
    assert vazio["jumpers"] == []


async def test_portas4i_e_bornes4i_por_chave(project_db: Path):
    handlers = Handlers(str(project_db))

    portas = await handlers.dispatch("portas4i_por_modelo", {"index_modelo": 8})
    assert [p["Borne"] for p in portas["portas"]] == ["11"]

    bornes = await handlers.dispatch("bornes4i_por_regua", {"index_regua": 5})
    # Ordem crescente: 11 (1.0) antes de 12 (2.0).
    assert [b["Borne"] for b in bornes["bornes"]] == ["11", "12"]


async def test_cabos4_e_veias4_por_revisao(project_db: Path):
    handlers = Handlers(str(project_db))

    cabos = await handlers.dispatch("cabos4_por_revisao", {})
    assert [c["Tag"] for c in cabos["cabos"]] == ["C-100"]
    assert cabos["cabos"][0]["Blindagem"] is True

    veias = await handlers.dispatch("veias4_por_revisao", {"revisao": "R0"})
    # A ordem é `Tag, Num_Veia`: a veia de reserva (-60) vem primeiro.
    assert [v["Num_Veia"] for v in veias["veias"]] == [-60, 1, 2]

    vazio = await handlers.dispatch("veias4_por_revisao", {"revisao": "R9"})
    assert vazio["veias"] == []


async def test_portas4f_e_bornes4f_por_revisao(project_db: Path):
    handlers = Handlers(str(project_db))

    portas = await handlers.dispatch("portas4f_por_revisao", {"revisao": "R0"})
    assert [p["Terminal"] for p in portas["portas"]] == ["1", "2"]
    assert portas["portas"][0]["IndexModelo"] == 7

    bornes = await handlers.dispatch("bornes4f_por_revisao", {})
    assert [b["IndexRegua"] for b in bornes["bornes"]] == [5]

    vazio = await handlers.dispatch("portas4f_por_revisao", {"revisao": "R9"})
    assert vazio["portas"] == []

    contatos = await handlers.dispatch("contatos4f_por_revisao", {})
    assert [c["Terminal"] for c in contatos["contatos"]] == ["1"]


async def test_plaquetas_por_painel_ordenadas_por_tag(project_db: Path):
    handlers = Handlers(str(project_db))

    painel1 = await handlers.dispatch("plaquetas_por_painel", {"painel": 1})
    assert [p["Tag"] for p in painel1["plaquetas"]] == ["PLACA-A", "PLACA-B"]
    # A linha chega com as colunas do schema, não como tupla posicional.
    assert painel1["plaquetas"][0]["Desc2"] == "linha 2"
    assert painel1["plaquetas"][1]["Desc2"] is None

    painel2 = await handlers.dispatch("plaquetas_por_painel", {"painel": 2})
    assert [p["Tag"] for p in painel2["plaquetas"]] == ["PLACA-C"]

    vazio = await handlers.dispatch("plaquetas_por_painel", {"painel": 9})
    assert vazio["plaquetas"] == []


async def test_lista_materiais_por_painel_ordenada_pela_ordem_do_diagrama(project_db: Path):
    handlers = Handlers(str(project_db))

    painel1 = await handlers.dispatch("lista_materiais_por_painel", {"painel": 1})
    # A `Ordem` é a do diagrama (renumerada pelo `COMPLM`), não a alfabética: R6 e D1
    # têm `Ordem` 1 e desempatam pelo `Indice` do banco; o D2 (Ordem 2) vem por último.
    assert [m["Tag"] for m in painel1["materiais"]] == ["R6", "D1", "D2"]
    assert painel1["materiais"][0]["Quantidade"] == 63
    assert painel1["materiais"][0]["OrdemLay"] == 10000
    # `Avulso` é BOOL no schema: chega como `bool`, não como 0/1.
    assert painel1["materiais"][0]["Avulso"] is False
    assert painel1["materiais"][1]["IndiceLM"] == 7

    # O item avulso (lançado à mão no app) aparece com a marca dele e sem handle.
    painel2 = await handlers.dispatch("lista_materiais_por_painel", {"painel": 2})
    assert [m["Tag"] for m in painel2["materiais"]] == ["MF"]
    assert painel2["materiais"][0]["Avulso"] is True
    assert painel2["materiais"][0]["Handle"] is None


async def test_plaquetas_e_lista_de_material_exigem_painel(project_db: Path):
    handlers = Handlers(str(project_db))
    with pytest.raises(BadParams):
        await handlers.dispatch("plaquetas_por_painel", {})
    with pytest.raises(BadParams):
        await handlers.dispatch("lista_materiais_por_painel", {})


async def test_relatorio_listar_traz_os_relatorios(project_db: Path):
    handlers = Handlers(str(project_db))
    catalogo = await handlers.dispatch("relatorio_listar")

    assert [r["id"] for r in catalogo["relatorios"]] == [
        "veias",
        "materiais",
        "interligacao",
        "fiacao",
    ]
    veias, materiais, interligacao, fiacao = catalogo["relatorios"]
    assert veias["titulo"] == "Lista de Veias"
    assert veias["colunas"][:4] == ["Tag", "Formação", "Função", "Veias"]
    assert veias["parametros"] == ["painel", "revisao"]
    # A lista de material não tem revisão: a tabela dela é por desenho.
    assert materiais["titulo"] == "Lista de Materiais"
    assert materiais["parametros"] == ["painel"]
    assert interligacao["titulo"] == "Relatório de Interligação"
    assert interligacao["parametros"] == ["painel", "revisao"]
    assert interligacao["colunas"][0] == "Régua"
    # O de fiação é o modo *Dispositivos* do original: a coluna 7 é a `Cor` (não o `TIPO`).
    assert fiacao["titulo"] == "Relatórios de Fiação"
    assert fiacao["parametros"] == ["painel", "revisao"]
    assert fiacao["colunas"] == [
        "Terminal",
        "",
        "Dispositivo 1",
        "Terminal 1",
        "Dispositivo 2",
        "Terminal 2",
        "Seção",
        "Cor",
        "Página",
    ]


async def test_relatorio_materiais_junta_o_catalogo(project_db: Path):
    handlers = Handlers(str(project_db))
    gerado = await handlers.dispatch("relatorio_gerar", {"relatorio": "materiais", "painel": 1})

    assert gerado["titulo"] == "Lista de Materiais"
    assert gerado["colunas"] == [
        "Índice",
        "Quant",
        "Tag",
        "Descrição",
        "Modelo",
        "Fabricante",
        "Código do Cliente",
        "INDEXLM",
    ]
    # O `INNER JOIN` com `IndiceMaterial <> 0` descarta os 459 e 476 (sem catálogo):
    # sobra só o material 1001, com a descrição **completa**.
    assert gerado["total"] == 1
    assert gerado["linhas"][0] == [
        "1",
        "2",
        "D1",
        "DISJUNTOR 20A COMPLETA",
        "DJ-20A",
        "Siemens",
        "CLI-1",
        "7",
    ]

    # No painel 2 só há o item avulso (518), que não está no catálogo.
    painel2 = await handlers.dispatch("relatorio_gerar", {"relatorio": "materiais", "painel": 2})
    assert painel2["linhas"] == []


async def test_relatorio_veias_monta_as_duas_pontas(project_db: Path):
    handlers = Handlers(str(project_db))
    gerado = await handlers.dispatch(
        "relatorio_gerar", {"relatorio": "veias", "painel": 1, "revisao": "R0"}
    )

    assert gerado["titulo"] == "Lista de Veias"
    assert gerado["total"] == 2  # a veia -60 fica fora (`Num_Veia > -51`)
    assert gerado["linhas"][0] == [
        "C-100",
        "2x(3x2,5)",  # `Cabos` > 1 e blindagem, como o original monta a formação
        "F1",
        "V1",
        "PT1",
        "A1",
        "1",
        "X",  # `Aterrar == 3` marca as duas pontas
        "PT2",
        "R1",  # o `NRegua` da ponta manda no lugar da tag
        "?",  # terminal vazio vira o caracter indefinido
        "X",
        "DOC-A, DOC-B",
        "8, 9",
        "12.5",
    ]
    # A segunda veia não tem `Nome_Veia`: o rótulo é o número dela.
    assert gerado["linhas"][1][3] == "2"
    assert gerado["linhas"][1][5] == "A2"

    # Sem o painel do cabo (3 não tem cabo nenhum), o relatório sai vazio.
    vazio = await handlers.dispatch(
        "relatorio_gerar", {"relatorio": "veias", "painel": 3, "revisao": "R0"}
    )
    assert vazio["linhas"] == []


async def test_relatorio_veias_exige_revisao_e_id_conhecido(project_db: Path):
    handlers = Handlers(str(project_db))
    with pytest.raises(BadParams):
        await handlers.dispatch("relatorio_gerar", {"relatorio": "veias", "painel": 1})
    with pytest.raises(BadParams):
        await handlers.dispatch("relatorio_gerar", {"relatorio": "inexistente", "painel": 1})


async def test_relatorio_interligacao_monta_a_arvore_regua_borne_cabo(project_db: Path):
    handlers = Handlers(str(project_db))
    gerado = await handlers.dispatch(
        "relatorio_gerar", {"relatorio": "interligacao", "painel": 1, "revisao": "R0"}
    )

    assert gerado["titulo"] == "Relatório de Interligação"
    # Uma régua (`R1`, a única do painel 1 no `Bornes4I`) vira **linha de grupo** e o
    # único cabo que passa no borne `11` vira a linha de cabo — o borne `12` não tem cabo.
    assert gerado["total"] == 2
    assert gerado["linhas"][0] == ["R1"] + [""] * 11
    assert gerado["linhas"][1] == [
        "11",                                    # Régua (o borne, como no original)
        "",                                      # (coluna sem rótulo)
        "C-100-3",                               # Tag: formação não começa com 1x → Tag-NumVeia
        "2x(3x2,5)",                             # Formação: blindagem + `Nx`
        "R1-11",                                 # Anilha: RÉGUA-BORNE
        "PT2",                                   # Destino: o nome do painel da outra ponta
        "B1",                                    # Régua destino (sem NRegua → só a tag)
        "?",                                     # Borne destino: terminal `"0"` vira `?`
        "F1",                                    # Função do cabo
        "DOC-A/9, DOC-B/9",                      # Documento das duas pontas
        "0",                                     # coluna sem rótulo: o Tipo do borne
        "",                                      # Trajeto (vazio no `Cabos4` do teste)
    ]


async def test_relatorio_interligacao_exige_revisao(project_db: Path):
    handlers = Handlers(str(project_db))
    with pytest.raises(BadParams):
        await handlers.dispatch("relatorio_gerar", {"relatorio": "interligacao", "painel": 1})


async def test_relatorio_fiacao_percorre_o_potencial(fiacao_db: Path):
    handlers = Handlers(str(fiacao_db))
    gerado = await handlers.dispatch(
        "relatorio_gerar", {"relatorio": "fiacao", "painel": 1, "revisao": "R0"}
    )

    assert gerado["titulo"] == "Relatórios de Fiação"
    assert gerado["total"] == 12
    # D1: o vizinho de Ordem 2 (`D2`) é a única ligação. A `Seção`/`Cor` são as da linha
    # do próprio D1 (é o que o original grava) e a `Página` é a da linha.
    assert gerado["linhas"][0] == ["D1"] + [""] * 8
    assert gerado["linhas"][1] == ["1", "", "D2", "1", "", "", "2,5", "P", "10"]
    assert gerado["linhas"][2] == [""] * 9
    # D2: as duas pontas do potencial caem numa **única** linha (o ramo `UBound(lig)==2`).
    assert gerado["linhas"][3] == ["D2"] + [""] * 8
    assert gerado["linhas"][4] == ["1", "", "D1", "1", "D3", "1", "4", "B", "10"]
    # D3: só o vizinho anterior.
    assert gerado["linhas"][6] == ["D3"] + [""] * 8
    assert gerado["linhas"][7] == ["1", "", "D2", "1", "", "", "6", "R", "10"]
    # D9: o terminal vem do **modelo de contato** (`Contatos4F`) e não tem linha nenhuma
    # na `Fiacao` — sai sem ligação e sem página.
    assert gerado["linhas"][9] == ["D9"] + [""] * 8
    assert gerado["linhas"][10] == ["1", "", "", "", "", "", "", "", ""]


async def test_relatorio_fiacao_exige_revisao(fiacao_db: Path):
    handlers = Handlers(str(fiacao_db))
    with pytest.raises(BadParams):
        await handlers.dispatch("relatorio_gerar", {"relatorio": "fiacao", "painel": 1})


async def test_relatorio_fiacao_ramos_de_3_4_e_5_ligacoes(fiacao_ramos_db: Path):
    """O formato da linha muda com o numero de ligacoes, como no `Ubound(lig)` do original."""
    handlers = Handlers(str(fiacao_ramos_db))
    gerado = await handlers.dispatch(
        "relatorio_gerar", {"relatorio": "fiacao", "painel": 1, "revisao": "R0"}
    )
    linhas = gerado["linhas"]

    # Os vizinhos de tipo `B` nao aparecem como dispositivo: so `D4`/`D5`/`D6` tem secao.
    assert [linha[0] for linha in linhas if linha[1:] == [""] * 8 and linha[0]] == [
        "D4",
        "D5",
        "D6",
    ]
    # 3 ligacoes: duas linhas (2 + 1).
    assert linhas[1] == ["1", "", "RA1", "1", "RA2", "1", "2,5", "P", "20"]
    assert linhas[2] == ["1", "", "RA3", "1", "", "", "4", "B", "20"]
    # 4 ligacoes: duas linhas (2 + 2).
    assert linhas[5] == ["1", "", "RB1", "1", "RB2", "1", "1,5", "P", "30"]
    assert linhas[6] == ["1", "", "RB3", "1", "RB4", "1", "2,5", "P", "30"]
    # Mais de 4: a linha de erro (o texto 784 do original).
    assert linhas[9] == ["1", "", "Erro: Conexões>4", "", "", "", "", "", "40"]


async def test_catalogo_materiais_com_e_sem_filtro(project_db: Path):
    handlers = Handlers(str(project_db))
    tudo = await handlers.dispatch("catalogo_listar_materiais")
    assert len(tudo["materiais"]) == 2

    filtrado = await handlers.dispatch("catalogo_listar_materiais", {"filtro": "Siemens"})
    assert [m["DescricaoResumida"] for m in filtrado["materiais"]] == ["Disjuntor 20A"]


async def test_catalogo_modelos_cabo(project_db: Path):
    handlers = Handlers(str(project_db))
    modelos = await handlers.dispatch("catalogo_listar_modelos_cabo")
    assert modelos["modelos"][0]["CodigoCliente"] == "M-1"


async def test_projeto_abrir_cria_banco_se_nao_existir(tmp_path: Path):
    handlers = Handlers()
    novo_caminho = tmp_path / "novo_projeto.db"
    res = await handlers.dispatch("projeto_abrir", {"caminho": str(novo_caminho)})
    assert res["caminho"] == str(novo_caminho)
    # Tem que ter tabelas (schema aplicado)
    assert len(res["tabelas"]) > 10
    assert novo_caminho.exists()


async def test_params_invalidos_viram_bad_params(project_db: Path):
    handlers = Handlers(str(project_db))
    with pytest.raises(BadParams):
        await handlers.dispatch("fiacao_por_painel", {})  # falta `painel`


async def test_banco_sem_schema_nao_mente(project_db: Path, tmp_path: Path):
    """Um arquivo SQLite válido mas sem as tabelas deve virar erro de domínio."""
    vazio = tmp_path / "vazio.db"
    sqlite3.connect(vazio).close()

    database = ProjectDatabase(vazio)
    with pytest.raises(DatabaseError):
        await database.list_paineis()
