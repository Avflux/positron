"""Leitura do banco do projeto (SQLite) pelo frontend APP.

Decisões que valem a pena registrar (ver `docs/POSITRON.md`, seção 2):

- **WAL + busy_timeout.** O plugin ZWCAD escreve no mesmo arquivo durante o
  desenho. Sem WAL, a conexão longa do app bloquearia o plugin no meio de um
  comando; sem `busy_timeout`, o app falharia na primeira escrita concorrente.
- **Uma conexão por consulta, aberta em `asyncio.to_thread`.** `sqlite3` é
  bloqueante e não pode ser chamado no loop do ZMQ. Abrir por consulta evita a
  briga de `check_same_thread` e de lock entre threads — o custo de um open de
  SQLite é desprezível para consultas de catálogo.
- **Só `SELECT` parametrizado.** Nada de montar SQL com entrada do usuário; os
  filtros entram como bind e nunca por concatenação.
- **BOOL do SQLite vira `bool` de verdade.** O SQLite guarda booleano como 0/1 e
  o `sqlite3` devolveria inteiro — o que contradiria o `boolean` do contrato TS
  (`schema.generated.ts`). O conversor abaixo roda na leitura via
  `PARSE_DECLTYPES`, então o que atravessa o fio casa com o tipo declarado.
"""

from __future__ import annotations

import asyncio
import sqlite3
from pathlib import Path
from typing import Any

from ..protocol import DatabaseError

#: Consultas de catálogo são pequenas; 5 s é folga larga para esperar um writer.
BUSY_TIMEOUT_MS = 5000


#: Colunas declaradas `BOOL` chegam como inteiro 0/1 do SQLite; o contrato diz
#: `boolean`. Registrar o conversor uma vez basta — vale para todo `connect`.
sqlite3.register_converter("BOOL", lambda raw: bool(int(raw)))


class ProjectDatabase:
    """Wrapper de um arquivo `.db` do projeto.

    Não guarda conexão aberta: guarda o caminho e abre por consulta. Barato em
    SQLite e imune aos problemas de compartilhar conexão entre threads.
    """

    def __init__(self, path: str | Path) -> None:
        self.path = Path(path)

    @property
    def exists(self) -> bool:
        return self.path.is_file()

    def create_from_schema(self) -> None:
        """Cria o arquivo do banco de dados e aplica o schema.sql oficial."""
        schema_path = Path(__file__).parent / "schema.sql"
        try:
            schema_sql = schema_path.read_text(encoding="utf-8")
            self.path.parent.mkdir(parents=True, exist_ok=True)
            connection = sqlite3.connect(
                self.path,
                timeout=BUSY_TIMEOUT_MS / 1000,
            )
            # WAL para manter o padrão de performance
            connection.execute("PRAGMA journal_mode=WAL")
            connection.executescript(schema_sql)
            connection.commit()
            connection.close()
        except Exception as exc:
            raise DatabaseError(f"falha ao criar banco de dados novo: {exc}") from exc

    async def tables(self) -> list[str]:
        rows = await self.query(
            "SELECT name FROM sqlite_master "
            "WHERE type = 'table' AND name NOT LIKE 'sqlite_%' ORDER BY name"
        )
        return [row["name"] for row in rows]

    async def query(self, sql: str, params: tuple[Any, ...] = ()) -> list[dict[str, Any]]:
        """Roda um `SELECT` e devolve as linhas como dicts.

        O trabalho bloqueante vai para uma thread para não travar o loop do ZMQ.
        """
        return await asyncio.to_thread(self._query_blocking, sql, params)

    def _query_blocking(self, sql: str, params: tuple[Any, ...]) -> list[dict[str, Any]]:
        if not self.exists:
            raise DatabaseError(f"banco do projeto não encontrado: {self.path}")

        try:
            connection = sqlite3.connect(
                self.path,
                timeout=BUSY_TIMEOUT_MS / 1000,
                detect_types=sqlite3.PARSE_DECLTYPES,
            )
        except sqlite3.Error as exc:  # arquivo ilegível, diretório errado, etc.
            raise DatabaseError(f"não foi possível abrir {self.path}: {exc}") from exc

        connection.row_factory = sqlite3.Row
        try:
            # WAL para conviver com o plugin gravando ao mesmo tempo.
            connection.execute("PRAGMA journal_mode=WAL")
            connection.execute(f"PRAGMA busy_timeout={BUSY_TIMEOUT_MS}")
            cursor = connection.execute(sql, params)
            return [dict(row) for row in cursor.fetchall()]
        except sqlite3.Error as exc:
            raise DatabaseError(f"erro de SQL: {exc}") from exc
        finally:
            connection.close()

    # ------------------------------------------------------------- consultas

    async def list_paineis(self) -> list[dict[str, Any]]:
        return await self.query("SELECT * FROM Paineis ORDER BY Nome")

    async def list_materiais(self, filtro: str | None = None) -> list[dict[str, Any]]:
        if not filtro:
            return await self.query("SELECT * FROM Materiais ORDER BY DescricaoResumida")
        like = f"%{filtro}%"
        return await self.query(
            "SELECT * FROM Materiais "
            "WHERE DescricaoResumida LIKE ? OR DescricaoCompleta LIKE ? "
            "   OR Modelo LIKE ? OR Fabricante LIKE ? OR CodigoCliente LIKE ? "
            "ORDER BY DescricaoResumida",
            (like, like, like, like, like),
        )

    async def list_modelos_cabo(self) -> list[dict[str, Any]]:
        return await self.query("SELECT * FROM ModelosCabos ORDER BY Indice")

    async def fiacao_por_painel(
        self, painel: int, revisao: str | None = None
    ) -> list[dict[str, Any]]:
        # `Ordem` reinicia a cada potencial (ver FiacaoProjetor no plugin), então
        # ordenar só por ela intercalaria potenciais. Potencial vem primeiro.
        if revisao:
            return await self.query(
                "SELECT * FROM Fiacao WHERE Painel = ? AND Revisao = ? "
                "ORDER BY Potencial, Ordem",
                (painel, revisao),
            )
        return await self.query(
            "SELECT * FROM Fiacao WHERE Painel = ? ORDER BY Potencial, Ordem", (painel,)
        )

    async def interligacao_por_cabo(self, tag_cabo: str) -> list[dict[str, Any]]:
        return await self.query(
            "SELECT * FROM Interligacao4 WHERE Tag_Cabo = ? ORDER BY Num_Veia, Indice",
            (tag_cabo,),
        )

    async def interligacao_por_painel(self, painel: int) -> list[dict[str, Any]]:
        # Um trecho pertence ao painel quando qualquer uma das pontas está nele.
        return await self.query(
            "SELECT * FROM Interligacao4 WHERE Painel1 = ? OR Painel2 = ? "
            "ORDER BY Tag_Cabo, Num_Veia, Indice",
            (painel, painel),
        )

    async def circuitos_por_painel(
        self, painel: int, revisao: str | None = None
    ) -> list[dict[str, Any]]:
        if revisao:
            return await self.query(
                "SELECT * FROM Circuitos4F WHERE Painel = ? AND Revisao = ? "
                "ORDER BY Potencial, Indice",
                (painel, revisao),
            )
        return await self.query(
            "SELECT * FROM Circuitos4F WHERE Painel = ? ORDER BY Potencial, Indice",
            (painel,),
        )

    async def dispositivos_por_painel(
        self, painel: int, revisao: str | None = None
    ) -> list[dict[str, Any]]:
        if revisao:
            return await self.query(
                "SELECT * FROM Dispositivos4F WHERE Painel = ? AND Revisao = ? "
                "ORDER BY Tag, Indice",
                (painel, revisao),
            )
        return await self.query(
            "SELECT * FROM Dispositivos4F WHERE Painel = ? ORDER BY Tag, Indice", (painel,)
        )

    async def aplicacoes_por_revisao(self, revisao: str | None = None) -> list[dict[str, Any]]:
        # Os tipos de aplicação são copiados do dicionário do desenho por revisão.
        if revisao:
            return await self.query(
                "SELECT * FROM Aplicacao4F WHERE Revisao = ? ORDER BY Numero, Indice",
                (revisao,),
            )
        return await self.query("SELECT * FROM Aplicacao4F ORDER BY Numero, Indice")
