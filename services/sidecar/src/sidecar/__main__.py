"""Ponto de entrada do processo sidecar.

    python -m sidecar                  # portas efêmeras, HTTP em 8765
    python -m sidecar --port 5555      # ROUTER fixo em 5555 (PUB em 5556)
    python -m sidecar --no-http        # só ZMQ
    python -m sidecar --log-level DEBUG

Handshake com o processo pai (o Rust): depois de ligar os sockets, este módulo
escreve UMA linha em stdout e dá flush:

    SIDECAR_READY {"pid":123,"version":"0.1.0","zmq_port":54321,"pub_port":54322}

O Rust lê essa linha para descobrir a porta efêmera e só então conecta o DEALER
e o SUB. Todo o log vai para stderr justamente para não poluir esse canal.

Sobre o HTTP: o FastAPI roda numa thread própria, com o seu próprio event loop.
O ZMQ fica com o loop principal. Os dois publicam no mesmo `EventBus`, que é
seguro entre threads por construção (ver `events.py`).
"""

from __future__ import annotations

import argparse
import asyncio
import json
import logging
import os
import signal
import sys
import threading
from collections.abc import Coroutine
from typing import Any

import uvicorn
import zmq
import zmq.asyncio

from . import __version__
from .config import Settings
from .events import EventBus
from .handlers import Handlers
from .protocol import PingResult, ts
from .zmq import Publisher, Responder

log = logging.getLogger("sidecar")

#: Prefixo da linha de handshake lida pelo Rust (ver `apps/desktop/src-tauri/src/sidecar.rs`).
READY_PREFIX = "SIDECAR_READY "

#: Origens do Vite em dev. O modo `dev:web` fala HTTP direto do navegador, então
#: o FastAPI precisa responder a estas origens.
DEV_ORIGINS = ["http://localhost:5173", "http://127.0.0.1:5173"]


def _parse_args(argv: list[str] | None) -> argparse.Namespace:
    parser = argparse.ArgumentParser(
        prog="sidecar",
        description="Serviço de comandos (ROUTER) e eventos (PUB) sobre ZeroMQ.",
    )
    parser.add_argument("--port", type=int, default=None, help="porta do ROUTER (0 = efêmera)")
    parser.add_argument("--host", default=None, help="interface de bind (padrão 127.0.0.1)")
    parser.add_argument("--no-http", action="store_true", help="desliga o FastAPI")
    parser.add_argument("--log-level", default=None, help="DEBUG, INFO, WARNING ou ERROR")
    return parser.parse_args(argv)


def main(argv: list[str] | None = None) -> int:
    args = _parse_args(argv)

    settings = Settings()
    if args.port is not None:
        settings.zmq_port = args.port
    if args.host:
        settings.zmq_host = args.host
    if args.no_http:
        settings.http_enabled = False
    if args.log_level:
        settings.log_level = args.log_level

    # stdout é o canal do handshake; o log vai para stderr de propósito.
    logging.basicConfig(
        level=settings.log_level.upper(),
        format="%(asctime)s %(levelname)-7s %(name)s: %(message)s",
        stream=sys.stderr,
    )

    try:
        _run(_serve(settings))
    except KeyboardInterrupt:  # Ctrl+C antes de instalarmos o handler
        log.info("interrompido")
    return 0


def _run(coro: Coroutine[Any, Any, None]) -> None:
    """Roda o loop principal de forma explícita.

    No Windows o loop padrão é o **Proactor**, que não implementa a família
    `add_reader` — e é exatamente dela que o `zmq.asyncio` depende. Sem isto o
    serviço morre no primeiro socket:

        RuntimeError: Proactor event loop does not implement add_reader family of
        methods required for zmq.

    Escolhemos o `SelectorEventLoop` pelo `loop_factory` do `asyncio.Runner` em
    vez de mexer na política global (`set_event_loop_policy` está deprecado).
    O loop do FastAPI roda em outra thread e não usa ZMQ, então lá o Proactor
    serve perfeitamente.
    """
    if sys.platform == "win32":
        with asyncio.Runner(loop_factory=asyncio.SelectorEventLoop) as runner:
            runner.run(coro)
    else:
        asyncio.run(coro)


async def _serve(settings: Settings) -> None:
    handlers = Handlers()
    bus = EventBus()
    ctx = zmq.asyncio.Context()

    responder = Responder(ctx, settings.zmq_host, settings.zmq_port)
    port = responder.bind()

    # O PUB mora em PORT+1: o Rust descobre a porta pelo handshake, então tudo
    # que ele precisa fazer é somar 1 para assinar os eventos.
    pub_port = port + settings.pub_port_offset
    publisher = Publisher(ctx, settings.zmq_host, pub_port, bus)
    pub_port = publisher.bind()

    http = _HttpSidecar(settings, handlers, bus)
    http.start()

    stop = asyncio.Event()
    _install_signal_handlers(stop)

    tasks = [asyncio.create_task(responder.run(handlers, stop), name="zmq-router")]
    if settings.heartbeat_seconds > 0:
        tasks.append(
            asyncio.create_task(
                _heartbeat(publisher, handlers, settings.heartbeat_seconds, stop),
                name="heartbeat",
            )
        )

    _announce(port, pub_port)
    publisher.publish(
        "ready",
        PingResult(version=__version__, pid=os.getpid(), served=handlers.served).model_dump(),
    )
    log.info(
        "sidecar pronto — ROUTER tcp://%s:%d, PUB tcp://%s:%d, HTTP %s",
        settings.zmq_host,
        port,
        settings.zmq_host,
        pub_port,
        http.endpoint or "desligado",
    )

    try:
        await stop.wait()
    finally:
        for task in tasks:
            task.cancel()
        await asyncio.gather(*tasks, return_exceptions=True)
        http.stop()
        publisher.close()
        ctx.term()
        log.info("sidecar encerrado")


def _announce(port: int, pub_port: int) -> None:
    """Handshake: uma linha, um JSON, flush imediato."""
    payload = {
        "pid": os.getpid(),
        "version": __version__,
        "zmq_port": port,
        "pub_port": pub_port,
    }
    print(READY_PREFIX + json.dumps(payload), flush=True)


def _install_signal_handlers(stop: asyncio.Event) -> None:
    """SIGINT/SIGTERM → desligamento limpo.

    Usamos `signal.signal` e não `loop.add_signal_handler` porque o segundo não
    existe no ProactorEventLoop do Windows. Só funciona na thread principal, que
    é exatamente onde este módulo roda.
    """
    loop = asyncio.get_running_loop()

    def _handler(signum: int, _frame: Any) -> None:
        log.info("sinal %s recebido, desligando", signal.Signals(signum).name)
        loop.call_soon_threadsafe(stop.set)

    for sig in (signal.SIGINT, signal.SIGTERM):
        try:
            signal.signal(sig, _handler)
        except (ValueError, OSError):  # plataforma/thread sem suporte
            log.debug("sem handler de sinal para %s", sig)


async def _heartbeat(
    publisher: Publisher,
    handlers: Handlers,
    seconds: float,
    stop: asyncio.Event,
) -> None:
    """Batida periódica.

    Existe por causa do *slow joiner* do PUB/SUB: quem conecta depois do `ready`
    perde aquele evento. A batida garante que um assinante novo se sincronize
    sozinho em no máximo `heartbeat_seconds`.
    """
    while not stop.is_set():
        try:
            await asyncio.wait_for(stop.wait(), timeout=seconds)
            return
        except TimeoutError:
            publisher.publish("heartbeat", {"ts": ts(), "served": handlers.served})


class _HttpSidecar:
    """uvicorn numa thread separada, com o seu próprio event loop."""

    def __init__(self, settings: Settings, handlers: Handlers, bus: EventBus) -> None:
        self._settings = settings
        self._handlers = handlers
        self._bus = bus
        self._server: uvicorn.Server | None = None
        self._thread: threading.Thread | None = None

    @property
    def endpoint(self) -> str | None:
        if not self._settings.http_enabled:
            return None
        return f"http://{self._settings.http_host}:{self._settings.http_port}"

    def start(self) -> None:
        if not self._settings.http_enabled:
            log.info("HTTP desligado (SIDECAR_HTTP_ENABLED=false)")
            return

        from .http import create_app

        app = create_app(self._handlers, self._bus, cors_origins=DEV_ORIGINS)
        self._server = uvicorn.Server(
            uvicorn.Config(
                app,
                host=self._settings.http_host,
                port=self._settings.http_port,
                log_level="warning",
                access_log=False,
            )
        )
        self._thread = threading.Thread(target=self._server.run, name="http", daemon=True)
        self._thread.start()

    def stop(self) -> None:
        if self._server is not None:
            self._server.should_exit = True
        if self._thread is not None:
            self._thread.join(timeout=5)


if __name__ == "__main__":
    raise SystemExit(main())
