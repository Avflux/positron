"""Testes de integração reais: sockets ZeroMQ de verdade, sem mock.

Se algum destes falhar, a premissa central do scaffold — Rust <-> Python
conversando por DEALER/ROUTER + PUB/SUB — está quebrada.
"""

from __future__ import annotations

import asyncio
import json
from contextlib import asynccontextmanager
from dataclasses import dataclass

import zmq
import zmq.asyncio

from sidecar.events import EventBus
from sidecar.handlers import Handlers
from sidecar.protocol import PROTOCOL_VERSION, RequestEnvelope, ResponseEnvelope
from sidecar.zmq import Publisher, Responder

TIMEOUT_MS = 3000


@dataclass
class Running:
    ctx: zmq.asyncio.Context
    handlers: Handlers
    bus: EventBus
    publisher: Publisher
    port: int
    pub_port: int


@asynccontextmanager
async def running_sidecar():
    """Sobe ROUTER + PUB em portas efêmeras, como `python -m sidecar` faria."""
    ctx = zmq.asyncio.Context()
    handlers = Handlers()
    bus = EventBus()

    responder = Responder(ctx, "127.0.0.1", 0)
    port = responder.bind()
    publisher = Publisher(ctx, "127.0.0.1", port + 1, bus)
    pub_port = publisher.bind()

    stop = asyncio.Event()
    task = asyncio.create_task(responder.run(handlers, stop))
    try:
        yield Running(ctx, handlers, bus, publisher, port, pub_port)
    finally:
        stop.set()
        await asyncio.wait_for(task, timeout=3)
        publisher.close()
        ctx.term()


def dealer_for(ctx: zmq.asyncio.Context, port: int) -> zmq.asyncio.Socket:
    sock = ctx.socket(zmq.DEALER)
    sock.linger = 0
    sock.rcvtimeo = TIMEOUT_MS
    sock.connect(f"tcp://127.0.0.1:{port}")
    return sock


async def rpc(
    sock: zmq.asyncio.Socket,
    method: str,
    params: dict | None = None,
    req_id: str = "t",
) -> ResponseEnvelope:
    envelope = RequestEnvelope(id=req_id, method=method, params=params or {})
    await sock.send(envelope.model_dump_json().encode())
    frames = await sock.recv_multipart()
    assert len(frames) == 1, f"ROUTER deve mandar um frame só, veio {len(frames)}"
    return ResponseEnvelope.model_validate_json(frames[0])


async def test_ping_roundtrip_over_dealer():
    async with running_sidecar() as sc:
        dealer = dealer_for(sc.ctx, sc.port)
        try:
            response = await rpc(dealer, "ping", req_id="ping-1")
            assert response.ok is True
            assert response.id == "ping-1"
            assert response.v == PROTOCOL_VERSION
            assert response.result is not None
            assert response.result["service"] == "sidecar"
            assert response.result["pid"] > 0
            assert response.result["ts"].endswith("Z"), "timestamp precisa ser UTC com Z"
        finally:
            dealer.close(linger=0)


async def test_echo_repeats_message():
    async with running_sidecar() as sc:
        dealer = dealer_for(sc.ctx, sc.port)
        try:
            response = await rpc(dealer, "echo", {"message": "eco", "repeat": 3})
            assert response.ok is True
            assert response.result["message"] == "eco eco eco"
            assert response.result["count"] == 3
        finally:
            dealer.close(linger=0)


async def test_unknown_method_and_bad_params_are_errors_not_crashes():
    async with running_sidecar() as sc:
        dealer = dealer_for(sc.ctx, sc.port)
        try:
            unknown = await rpc(dealer, "nao_existe")
            assert unknown.ok is False
            assert unknown.error is not None
            assert unknown.error.code == "unknown_method"

            bad = await rpc(dealer, "echo", {"repeat": 3})  # falta `message`
            assert bad.ok is False
            assert bad.error is not None
            assert bad.error.code == "bad_params"

            # O socket continua vivo depois dos dois erros.
            ok = await rpc(dealer, "ping")
            assert ok.ok is True
        finally:
            dealer.close(linger=0)


async def test_malformed_envelope_gets_an_error_response():
    async with running_sidecar() as sc:
        dealer = dealer_for(sc.ctx, sc.port)
        try:
            await dealer.send(b"{ isto nao e json")
            frames = await dealer.recv_multipart()
            response = ResponseEnvelope.model_validate_json(frames[0])
            assert response.ok is False
            assert response.error is not None
            assert response.error.code == "bad_request"
        finally:
            dealer.close(linger=0)


async def test_served_counter_increments():
    async with running_sidecar() as sc:
        dealer = dealer_for(sc.ctx, sc.port)
        try:
            await rpc(dealer, "ping")
            await rpc(dealer, "ping")
            third = await rpc(dealer, "ping")
            assert sc.handlers.served == 3
            # `dispatch` incrementa ANTES de chamar o handler, então o 3º ping já vê 3.
            assert third.result["served"] == 3
        finally:
            dealer.close(linger=0)


async def test_event_reaches_sub_and_event_bus():
    async with running_sidecar() as sc:
        sub = sc.ctx.socket(zmq.SUB)
        sub.linger = 0
        sub.rcvtimeo = TIMEOUT_MS
        sub.setsockopt(zmq.SUBSCRIBE, b"")
        sub.connect(sc.publisher.endpoint)

        # O caminho do SSE (modo navegador) é o EventBus. Assinamos antes de publicar.
        queue = sc.bus.subscribe()
        try:
            frames = await _recv_event(sub, sc.publisher, "heartbeat", {"ts": "x", "served": 7})
            assert frames[0] == b"heartbeat", "primeiro frame é o tópico"
            envelope = json.loads(frames[1])
            assert envelope["topic"] == "heartbeat"
            assert envelope["payload"]["served"] == 7
            assert envelope["v"] == PROTOCOL_VERSION

            # O mesmo evento tem que aparecer para quem está no SSE.
            from_bus = await asyncio.wait_for(queue.get(), timeout=1)
            assert from_bus.topic == "heartbeat"
            assert from_bus.payload["served"] == 7
        finally:
            sc.bus.unsubscribe(queue)
            sub.close(linger=0)


async def test_ready_event_payload_matches_ping_shape():
    """O Rust usa o evento `ready` para o handshake; o payload tem que ter `version`/`pid`."""
    async with running_sidecar() as sc:
        queue = sc.bus.subscribe()
        try:
            sc.publisher.publish(
                "ready",
                {"service": "sidecar", "version": "0.1.0", "pid": 1, "served": 0},
            )
            envelope = await asyncio.wait_for(queue.get(), timeout=1)
            assert envelope.topic == "ready"
            assert set(envelope.payload) >= {"service", "version", "pid"}
        finally:
            sc.bus.unsubscribe(queue)


async def _recv_event(sub, publisher: Publisher, topic: str, payload, deadline: float = 2.0):
    """PUB/SUB sofre do *slow joiner*: publicar antes do handshake perde a mensagem.

    Em produção quem cobre isso é o heartbeat. Aqui repetimos até chegar, o que
    mantém o teste determinístico sem sleep fixo.
    """
    loop = asyncio.get_running_loop()
    until = loop.time() + deadline
    while True:
        publisher.publish(topic, payload)
        try:
            return await asyncio.wait_for(sub.recv_multipart(), timeout=0.25)
        except TimeoutError:
            if loop.time() >= until:
                raise
