"""Barramento de eventos em processo.

O PUB do ZeroMQ só alcança quem fala ZMQ. O modo `dev:web` (navegador) usa SSE pelo
FastAPI, então todo evento publicado também entra aqui.

Por que guardamos `queue -> loop` e não só a fila: `publish()` é chamado de threads
DIFERENTES. O loop principal bombeia o ZMQ e o heartbeat; cada thread do uvicorn tem

seu próprio loop e cria a fila do SSE dentro dele. Só `call_soon_threadsafe` no loop
DONO da fila é seguro. (O `asyncio.Queue` não expõe o loop antes do primeiro `await`,
então capturá-lo em `subscribe()` não é preciosismo: os dois loops costumam ser
objetos distintos.)
"""

from __future__ import annotations

import asyncio
import logging
from typing import Any

from .protocol import EventEnvelope

log = logging.getLogger(__name__)


class EventBus:
    def __init__(self, maxsize: int = 256) -> None:
        self._maxsize = maxsize
        self._subscribers: dict[asyncio.Queue[EventEnvelope], asyncio.AbstractEventLoop] = {}

    def subscribe(self) -> asyncio.Queue[EventEnvelope]:
        """Cria uma fila amarrada ao loop de quem chamou (o do SSE)."""
        queue: asyncio.Queue[EventEnvelope] = asyncio.Queue(maxsize=self._maxsize)
        self._subscribers[queue] = asyncio.get_running_loop()
        return queue

    def unsubscribe(self, queue: asyncio.Queue[EventEnvelope]) -> None:
        self._subscribers.pop(queue, None)

    def publish(self, topic: str, payload: Any) -> EventEnvelope:
        """Entrega para todos os assinantes. Nunca levanta: evento perdido != serviço caído."""
        envelope = EventEnvelope(topic=topic, payload=payload)
        for queue, loop in list(self._subscribers.items()):
            if loop.is_closed():
                self._subscribers.pop(queue, None)
                continue
            try:
                loop.call_soon_threadsafe(_offer, queue, envelope)
            except RuntimeError:  # loop morto entre o is_closed e a chamada
                self._subscribers.pop(queue, None)
        return envelope


def _offer(queue: asyncio.Queue[EventEnvelope], envelope: EventEnvelope) -> None:
    """Roda DENTRO do loop dono da fila. Assinante lento perde o evento, não trava o PUB."""
    try:
        queue.put_nowait(envelope)
    except asyncio.QueueFull:
        log.warning("assinante lento: evento %s descartado", envelope.topic)
