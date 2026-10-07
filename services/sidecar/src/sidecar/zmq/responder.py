"""ROUTER: atende comandos dos clientes DEALER (o Rust, e os testes).

Por que ROUTER e não REP: REP/REQ casa um-para-um e quebra com reconexão e timeout.
ROUTER aceita vários clientes, não bloqueia e deixa a correlação por `id` explícita.

`bind()` é separado de `run()` de propósito: o serviço precisa saber a porta efêmera
antes de subir o PUB (que mora em PORT+1).
"""

from __future__ import annotations

import asyncio
import json
import logging
from collections.abc import Callable
from typing import TYPE_CHECKING

import zmq
import zmq.asyncio
from pydantic import ValidationError

from ..protocol import RequestEnvelope, ResponseEnvelope, SidecarError

if TYPE_CHECKING:
    from ..handlers import Handlers

log = logging.getLogger(__name__)


class Responder:
    def __init__(
        self,
        ctx: zmq.asyncio.Context,
        host: str,
        port: int = 0,
        on_ready: Callable[[int], None] | None = None,
    ) -> None:
        self._ctx = ctx
        self._host = host
        self._requested_port = port
        self._on_ready = on_ready
        self._sock: zmq.asyncio.Socket | None = None
        self.port: int = port

    def bind(self) -> int:
        """Sobe o socket e devolve a porta efetiva (útil com `port=0`)."""
        if self._sock is not None:
            return self.port

        sock = self._ctx.socket(zmq.ROUTER)
        sock.linger = 0
        if self._requested_port:
            sock.bind(f"tcp://{self._host}:{self._requested_port}")
            self.port = self._requested_port
        else:
            self.port = sock.bind_to_random_port(f"tcp://{self._host}")
        self._sock = sock

        log.info("ROUTER ouvindo em tcp://%s:%d", self._host, self.port)
        if self._on_ready is not None:
            self._on_ready(self.port)
        return self.port

    async def run(self, handlers: Handlers, stop: asyncio.Event) -> None:
        sock = self._sock or self.bind()
        assert sock is not None

        poller = zmq.asyncio.Poller()
        poller.register(sock, zmq.POLLIN)
        try:
            while not stop.is_set():
                events = dict(await poller.poll(timeout=250))
                if sock not in events:
                    continue
                frames = await sock.recv_multipart()
                if not frames:
                    continue
                identity, *rest = frames
                payload = rest[-1] if rest else b"{}"
                response = await self._handle(handlers, payload)
                await sock.send_multipart([identity, response])
        finally:
            sock.close(linger=0)
            self._sock = None

    async def _handle(self, handlers: Handlers, payload: bytes) -> bytes:
        # Decodificar é separado do dispatch: sem envelope válido não existe `id`,
        # então essa resposta não é correlacionável e vira um erro de protocolo.
        try:
            request = RequestEnvelope.model_validate_json(payload)
        except ValidationError as exc:
            # JSON inválido E schema errado caem os dois aqui: o pydantic embrulha
            # `json.JSONDecodeError` numa `ValidationError`.
            log.warning("envelope inválido: %d erro(s)", exc.error_count())
            return _encode(
                ResponseEnvelope.failure(
                    "?",
                    "bad_request",
                    "envelope inválido",
                    exc.errors(include_url=False),
                )
            )

        try:
            result = await handlers.dispatch(request.method, request.params)
            return _encode(ResponseEnvelope.success(request.id, result))
        except SidecarError as exc:
            log.warning("erro de domínio: %s (%s)", exc.message, exc.code)
            return _encode(ResponseEnvelope.failure(request.id, exc.code, exc.message, exc.detail))
        except json.JSONDecodeError as exc:
            return _encode(ResponseEnvelope.failure(request.id, "bad_json", str(exc)))
        except Exception as exc:  # noqa: BLE001 — a fronteira não pode derrubar o loop
            log.exception("falha inesperada ao processar requisição")
            return _encode(ResponseEnvelope.failure(request.id, "internal", str(exc)))


def _encode(response: ResponseEnvelope) -> bytes:
    return response.model_dump_json().encode()
