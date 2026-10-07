"""Tabela de métodos do sidecar.

Cada handler recebe o dict de `params` e devolve algo serializável (ou um modelo
Pydantic). É o único lugar que precisa mudar quando um método novo entra — tanto o
ZMQ (`zmq/responder.py`) quanto o HTTP (`http/app.py`) chamam este mesmo `dispatch`.
"""

from __future__ import annotations

import os
from collections.abc import Awaitable, Callable
from typing import Any

from pydantic import ValidationError

from . import __version__
from .protocol import (
    BadParams,
    EchoParams,
    EchoResult,
    PingResult,
    SidecarError,
    UnknownMethod,
)

Handler = Callable[[dict[str, Any]], Awaitable[Any]]


class Handlers:
    """Estado + dispatch. Uma instância por processo."""

    def __init__(self) -> None:
        self.served = 0
        self._table: dict[str, Handler] = {
            "ping": self._ping,
            "echo": self._echo,
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

    # ---------------------------------------------------------------- dispatch

    async def dispatch(self, method: str, params: dict[str, Any] | None = None) -> Any:
        handler = self._table.get(method)
        if handler is None:
            raise UnknownMethod(method)

        self.served += 1
        result = await handler(params or {})
        # Modelos Pydantic viram dict para o JSONEncoder não precisar conhecê-los.
        return result.model_dump() if hasattr(result, "model_dump") else result


def _validate(model_name: str, model: type, data: dict[str, Any]):
    try:
        return model.model_validate(data)
    except ValidationError as exc:
        raise BadParams(model_name, exc.errors(include_url=False)) from exc


__all__ = ["Handlers", "SidecarError"]
