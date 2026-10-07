"""PUB: emite eventos para os assinantes SUB.

PUB descarta mensagens sem assinante (é o comportamento correto de pub/sub), então
nada aqui pode virar controle de fluxo. Todo evento também vai para o `EventBus`,
que alimenta o SSE do modo navegador.
"""

from __future__ import annotations

import logging
from typing import Any

import zmq
import zmq.asyncio

from ..events import EventBus
from ..protocol import EventEnvelope

log = logging.getLogger(__name__)


class Publisher:
    def __init__(self, ctx: zmq.asyncio.Context, host: str, port: int, bus: EventBus) -> None:
        self._ctx = ctx
        self._host = host
        self._requested_port = port
        self._bus = bus
        self._sock: zmq.asyncio.Socket | None = None
        self.port: int = port

    @property
    def endpoint(self) -> str:
        return f"tcp://{self._host}:{self.port}"

    def bind(self) -> int:
        """Sobe o socket e devolve a porta efetiva (igual ao `Responder.bind`)."""
        if self._sock is not None:
            return self.port

        sock = self._ctx.socket(zmq.PUB)
        sock.linger = 0
        if self._requested_port:
            sock.bind(f"tcp://{self._host}:{self._requested_port}")
            self.port = self._requested_port
        else:
            self.port = sock.bind_to_random_port(f"tcp://{self._host}")
        self._sock = sock

        log.info("PUB ouvindo em %s", self.endpoint)
        return self.port

    def close(self) -> None:
        if self._sock is not None:
            self._sock.close(linger=0)
            self._sock = None

    def publish(self, topic: str, payload: Any) -> EventEnvelope:
        """Frame duplo: [tópico][json]. O SUB filtra por prefixo de tópico."""
        envelope: EventEnvelope = self._bus.publish(topic, payload)
        if self._sock is not None:
            try:
                self._sock.send_multipart(
                    [topic.encode(), envelope.model_dump_json().encode()],
                    flags=zmq.NOBLOCK,
                )
            except zmq.ZMQError as exc:  # fila cheia / sem assinantes
                log.debug("evento %s descartado no PUB: %s", topic, exc)
        return envelope
