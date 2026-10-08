"""Contrato do sidecar — FONTE DA VERDADE.

Espelho TS: packages/protocol/src/index.ts
Se mudar algo aqui, mude lá e rode `npm run protocol:gen`.

Formato do envelope (frame único, JSON UTF-8):

    requisição  {"v":1,"id":"...","method":"ping","params":{},"ts":"..."}
    resposta    {"v":1,"id":"...","ok":true,"result":{...}}
    erro        {"v":1,"id":"...","ok":false,"error":{"code":"...","message":"..."}}
    evento      {"v":1,"topic":"ready","payload":{...},"ts":"..."}
"""

from __future__ import annotations

from datetime import UTC, datetime
from typing import Any, Literal

from pydantic import BaseModel, Field

PROTOCOL_VERSION = 1


def utcnow() -> datetime:
    return datetime.now(UTC)


def ts() -> str:
    """Timestamp ISO-8601 em UTC, sempre com 'Z' (o JS parseia sem ambiguidade)."""
    return utcnow().isoformat().replace("+00:00", "Z")


class RequestEnvelope(BaseModel):
    v: Literal[1] = PROTOCOL_VERSION
    id: str
    method: str
    params: dict[str, Any] = Field(default_factory=dict)
    ts: str = Field(default_factory=ts)


class ErrorBody(BaseModel):
    code: str
    message: str
    detail: Any | None = None


class ResponseEnvelope(BaseModel):
    v: Literal[1] = PROTOCOL_VERSION
    id: str
    ok: bool
    result: Any | None = None
    error: ErrorBody | None = None

    @classmethod
    def success(cls, req_id: str, result: Any) -> ResponseEnvelope:
        return cls(id=req_id, ok=True, result=result)

    @classmethod
    def failure(
        cls,
        req_id: str,
        code: str,
        message: str,
        detail: Any | None = None,
    ) -> ResponseEnvelope:
        return cls(
            id=req_id,
            ok=False,
            error=ErrorBody(code=code, message=message, detail=detail),
        )


class EventEnvelope(BaseModel):
    v: Literal[1] = PROTOCOL_VERSION
    topic: str
    payload: Any
    ts: str = Field(default_factory=ts)


class PingResult(BaseModel):
    service: str = "sidecar"
    version: str
    pid: int
    ts: str = Field(default_factory=ts)
    served: int = 0


class EchoParams(BaseModel):
    message: str
    repeat: int = Field(default=1, ge=1, le=100)


class EchoResult(BaseModel):
    message: str
    count: int


# --- Banco do projeto (frontend APP) ---------------------------------------
# Os `result` destes métodos carregam linhas do banco; o formato de cada linha
# é o do `schema.sql`, espelhado em packages/protocol/src/schema.generated.ts.
# Por isso só os `params` têm modelo aqui — validar a linha inteira seria
# duplicar as 341 colunas que o gerador já conhece.


class ProjetoAbrirParams(BaseModel):
    caminho: str = Field(min_length=1)


class CatalogoListarMateriaisParams(BaseModel):
    filtro: str | None = None


class FiacaoPorPainelParams(BaseModel):
    painel: int
    revisao: str | None = None


class InterligacaoPorCaboParams(BaseModel):
    tag_cabo: str = Field(min_length=1)


class InterligacaoPorPainelParams(BaseModel):
    painel: int


#: Erros do domínio do sidecar. `code` é o que a UI usa para decidir o que mostrar.
class SidecarError(Exception):
    def __init__(self, code: str, message: str, detail: Any | None = None) -> None:
        super().__init__(message)
        self.code = code
        self.message = message
        self.detail = detail


class UnknownMethod(SidecarError):
    def __init__(self, method: str) -> None:
        super().__init__("unknown_method", f"método desconhecido: {method!r}")


class BadParams(SidecarError):
    def __init__(self, method: str, detail: Any) -> None:
        super().__init__("bad_params", f"parâmetros inválidos para {method!r}", detail)


class DatabaseNotOpen(SidecarError):
    """Nenhum projeto aberto: a UI precisa chamar `projeto_abrir` primeiro."""

    def __init__(self) -> None:
        super().__init__("db_not_open", "nenhum projeto aberto; chame projeto_abrir primeiro")


class DatabaseError(SidecarError):
    """Falha ao abrir ou consultar o banco do projeto."""

    def __init__(self, message: str) -> None:
        super().__init__("db_error", message)
