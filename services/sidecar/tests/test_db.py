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

        INSERT INTO Materiais(Indice, CodigoInterno, CodigoCliente, DescricaoResumida, Fabricante)
            VALUES (1, 1001, 'CLI-1', 'Disjuntor 20A', 'Siemens'),
                   (2, 1002, 'CLI-2', 'Borne 4mm', 'Wago');

        INSERT INTO ModelosCabos(Indice, CodigoCliente, Descricao) VALUES
            (1, 'M-1', 'Cabo blindado');

        INSERT INTO Fiacao(Indice, Revisao, DWG, Painel, Ordem, Tag, Terminal, BJumper, BLink)
            VALUES (10, 'R0', 1, 1, 4, 'A1', '1', 0, 0),
                   (11, 'R0', 1, 1, 2, 'A2', '2', 0, 0),
                   (12, 'R0', 1, 2, 1, 'B1', '1', 0, 0);

        INSERT INTO Interligacao4(
            Indice, Revisao, DWG, Tag_Cabo, Num_Veia, Painel1, Tag1, Painel2, Tag2
        )
            VALUES (20, 'R0', 1, 'C-100', 1, 1, 'A1', 2, 'B1'),
                   (21, 'R0', 1, 'C-100', 2, 1, 'A2', 2, 'B2'),
                   (22, 'R0', 1, 'C-200', 1, 1, 'A1', 3, 'C1');
        """
    )
    connection.commit()
    connection.close()
    return target


@pytest.fixture
def project_db(tmp_path: Path) -> Path:
    return make_project_db(tmp_path / "projeto.db")


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
    assert [t["Num_Veia"] for t in trechos["trechos"]] == [1, 2]
    assert trechos["trechos"][0]["Tag1"] == "A1"
    assert trechos["trechos"][0]["Tag2"] == "B1"


async def test_interligacao_por_painel_pega_as_duas_pontas(project_db: Path):
    handlers = Handlers(str(project_db))
    trechos = await handlers.dispatch("interligacao_por_painel", {"painel": 2})
    # Painel 2 só aparece como destino nas duas veias de C-100.
    assert {t["Tag_Cabo"] for t in trechos["trechos"]} == {"C-100"}


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
