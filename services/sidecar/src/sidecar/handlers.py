"""Tabela de métodos do sidecar.

Cada handler recebe o dict de `params` e devolve algo serializável (ou um modelo
Pydantic). É o único lugar que precisa mudar quando um método novo entra — tanto o
ZMQ (`zmq/responder.py`) quanto o HTTP (`http/app.py`) chamam este mesmo `dispatch`.
"""

from __future__ import annotations

import asyncio
import os
from collections.abc import Awaitable, Callable
from typing import Any

from pydantic import ValidationError

from . import __version__
from .db import ProjectDatabase
from .protocol import (
    AplicacoesPorRevisaoParams,
    BadParams,
    Bornes4IPorReguaParams,
    Cabos4PorRevisaoParams,
    CatalogoListarMateriaisParams,
    CircuitosPorPainelParams,
    DatabaseNotOpen,
    DispositivosPorPainelParams,
    EchoParams,
    EchoResult,
    FiacaoPorPainelParams,
    InterligacaoPorCaboParams,
    InterligacaoPorPainelParams,
    JumperPorPainelParams,
    PingResult,
    Portas4IPorModeloParams,
    ProjetoAbrirParams,
    SidecarError,
    UnknownMethod,
    Veias4PorRevisaoParams,
)

Handler = Callable[[dict[str, Any]], Awaitable[Any]]


class Handlers:
    """Estado + dispatch. Uma instância por processo."""

    def __init__(self, db_path: str | None = None) -> None:
        self.served = 0
        #: Banco do projeto aberto. `None` até `projeto_abrir` (ou a config) definir um.
        self._db: ProjectDatabase | None = ProjectDatabase(db_path) if db_path else None
        self._table: dict[str, Handler] = {
            "ping": self._ping,
            "echo": self._echo,
            "projeto_abrir": self._projeto_abrir,
            "projeto_listar_paineis": self._projeto_listar_paineis,
            "catalogo_listar_materiais": self._catalogo_listar_materiais,
            "catalogo_listar_modelos_cabo": self._catalogo_listar_modelos_cabo,
            "fiacao_por_painel": self._fiacao_por_painel,
            "interligacao_por_cabo": self._interligacao_por_cabo,
            "interligacao_por_painel": self._interligacao_por_painel,
            "circuitos_por_painel": self._circuitos_por_painel,
            "dispositivos_por_painel": self._dispositivos_por_painel,
            "aplicacoes_por_revisao": self._aplicacoes_por_revisao,
            "jumper_por_painel": self._jumper_por_painel,
            "portas4i_por_modelo": self._portas4i_por_modelo,
            "bornes4i_por_regua": self._bornes4i_por_regua,
            "cabos4_por_revisao": self._cabos4_por_revisao,
            "veias4_por_revisao": self._veias4_por_revisao,
        }

    @property
    def methods(self) -> list[str]:
        return sorted(self._table)

    # ---------------------------------------------------------------- handlers

    async def _ping(self, _params: dict[str, Any]) -> PingResult:
        return PingResult(version=__version__, pid=os.getpid(), served=self.served)

    async def _echo(self, params: dict[str, Any]) -> EchoResult:
        parsed = _validate("echo", EchoParams, params)
        return EchoResult(message=" ".join([parsed.message] * parsed.repeat), count=parsed.repeat)

    # ------------------------------------------------------------ banco (APP)
    #
    # Todos leem o `.db` do projeto; o plugin ZWCAD escreve as tabelas derivadas
    # do diagrama (ver docs/POSITRON.md, seção 2, decisão 2).

    async def _projeto_abrir(self, params: dict[str, Any]) -> dict[str, Any]:
        parsed = _validate("projeto_abrir", ProjetoAbrirParams, params)
        db = ProjectDatabase(parsed.caminho)
        if not db.exists:
            # Em vez de falhar, inicializamos o arquivo em branco usando o schema oficial
            await asyncio.to_thread(db.create_from_schema)
        self._db = db
        return {"caminho": str(db.path), "tabelas": await db.tables()}

    async def _projeto_listar_paineis(self, _params: dict[str, Any]) -> dict[str, Any]:
        return {"paineis": await self._require_db().list_paineis()}

    async def _catalogo_listar_materiais(self, params: dict[str, Any]) -> dict[str, Any]:
        parsed = _validate("catalogo_listar_materiais", CatalogoListarMateriaisParams, params)
        return {"materiais": await self._require_db().list_materiais(parsed.filtro)}

    async def _catalogo_listar_modelos_cabo(self, _params: dict[str, Any]) -> dict[str, Any]:
        return {"modelos": await self._require_db().list_modelos_cabo()}

    async def _fiacao_por_painel(self, params: dict[str, Any]) -> dict[str, Any]:
        parsed = _validate("fiacao_por_painel", FiacaoPorPainelParams, params)
        return {"fios": await self._require_db().fiacao_por_painel(parsed.painel, parsed.revisao)}

    async def _interligacao_por_cabo(self, params: dict[str, Any]) -> dict[str, Any]:
        parsed = _validate("interligacao_por_cabo", InterligacaoPorCaboParams, params)
        return {"trechos": await self._require_db().interligacao_por_cabo(parsed.tag_cabo)}

    async def _interligacao_por_painel(self, params: dict[str, Any]) -> dict[str, Any]:
        parsed = _validate("interligacao_por_painel", InterligacaoPorPainelParams, params)
        return {"trechos": await self._require_db().interligacao_por_painel(parsed.painel)}

    async def _circuitos_por_painel(self, params: dict[str, Any]) -> dict[str, Any]:
        parsed = _validate("circuitos_por_painel", CircuitosPorPainelParams, params)
        circuitos = await self._require_db().circuitos_por_painel(parsed.painel, parsed.revisao)
        return {"circuitos": circuitos}

    async def _dispositivos_por_painel(self, params: dict[str, Any]) -> dict[str, Any]:
        parsed = _validate("dispositivos_por_painel", DispositivosPorPainelParams, params)
        return {
            "dispositivos": await self._require_db().dispositivos_por_painel(
                parsed.painel, parsed.revisao
            )
        }

    async def _aplicacoes_por_revisao(self, params: dict[str, Any]) -> dict[str, Any]:
        parsed = _validate("aplicacoes_por_revisao", AplicacoesPorRevisaoParams, params)
        return {"aplicacoes": await self._require_db().aplicacoes_por_revisao(parsed.revisao)}

    async def _jumper_por_painel(self, params: dict[str, Any]) -> dict[str, Any]:
        parsed = _validate("jumper_por_painel", JumperPorPainelParams, params)
        jumpers = await self._require_db().jumper_por_painel(parsed.painel, parsed.revisao)
        return {"jumpers": jumpers}

    async def _portas4i_por_modelo(self, params: dict[str, Any]) -> dict[str, Any]:
        parsed = _validate("portas4i_por_modelo", Portas4IPorModeloParams, params)
        portas = await self._require_db().portas4i_por_modelo(parsed.index_modelo)
        return {"portas": portas}

    async def _bornes4i_por_regua(self, params: dict[str, Any]) -> dict[str, Any]:
        parsed = _validate("bornes4i_por_regua", Bornes4IPorReguaParams, params)
        bornes = await self._require_db().bornes4i_por_regua(parsed.index_regua)
        return {"bornes": bornes}

    async def _cabos4_por_revisao(self, params: dict[str, Any]) -> dict[str, Any]:
        parsed = _validate("cabos4_por_revisao", Cabos4PorRevisaoParams, params)
        return {"cabos": await self._require_db().cabos4_por_revisao(parsed.revisao)}

    async def _veias4_por_revisao(self, params: dict[str, Any]) -> dict[str, Any]:
        parsed = _validate("veias4_por_revisao", Veias4PorRevisaoParams, params)
        return {"veias": await self._require_db().veias4_por_revisao(parsed.revisao)}

    def _require_db(self) -> ProjectDatabase:
        if self._db is None:
            raise DatabaseNotOpen()
        return self._db

    # ---------------------------------------------------------------- dispatch

    async def dispatch(self, method: str, params: dict[str, Any] | None = None) -> Any:
        handler = self._table.get(method)
        if handler is None:
            raise UnknownMethod(method)

        self.served += 1
        result = await handler(params or {})
        # dicts (linhas do banco) já são serializáveis; modelos Pydantic viram dict.
        return result.model_dump() if hasattr(result, "model_dump") else result


def _validate(model_name: str, model: type, data: dict[str, Any]):
    try:
        return model.model_validate(data)
    except ValidationError as exc:
        raise BadParams(model_name, exc.errors(include_url=False)) from exc


__all__ = ["Handlers", "SidecarError"]
