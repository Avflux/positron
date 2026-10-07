"""FastAPI opcional.

Existe por três motivos, e nenhum deles é o caminho quente da UI:
  1. `/health` para o orquestrador saber se o processo está vivo;
  2. `/docs` (Swagger) para testar métodos sem escrever um cliente ZMQ;
  3. `/events` (SSE) para o modo `dev:web`, onde não há Rust para falar ZMQ.

O dispatch é o MESMO do ZMQ (`Handlers.dispatch`), então um método novo não
precisa ser registrado duas vezes.
"""

from __future__ import annotations

import asyncio
import json
from typing import TYPE_CHECKING, Any

from fastapi import FastAPI, Request
from fastapi.responses import JSONResponse, StreamingResponse

from .. import __version__
from ..protocol import SidecarError

if TYPE_CHECKING:
    from ..events import EventBus
    from ..handlers import Handlers


def create_app(handlers: Handlers, bus: EventBus, cors_origins: list[str]) -> FastAPI:
    app = FastAPI(title="sidecar", version=__version__)

    if cors_origins:
        from fastapi.middleware.cors import CORSMiddleware

        app.add_middleware(
            CORSMiddleware,
            allow_origins=cors_origins,
            allow_methods=["*"],
            allow_headers=["*"],
        )

    @app.get("/health")
    async def health() -> dict[str, Any]:
        return {"status": "ok", "version": __version__, "served": handlers.served}

    @app.post("/rpc/{method}")
    async def rpc_post(method: str, request: Request) -> JSONResponse:
        try:
            params = await request.json()
        except json.JSONDecodeError:
            params = {}
        return await _dispatch(handlers, method, params or {})

    @app.get("/rpc/{method}")
    async def rpc_get(method: str) -> JSONResponse:
        return await _dispatch(handlers, method, {})

    async def _dispatch(h: Handlers, method: str, params: dict[str, Any]) -> JSONResponse:
        try:
            result = await h.dispatch(method, params)
            return JSONResponse({"ok": True, "result": result})
        except SidecarError as exc:
            return JSONResponse(
                {"ok": False, "error": {"code": exc.code, "message": exc.message}},
                status_code=400,
            )

    @app.get("/events")
    async def events() -> StreamingResponse:
        queue = bus.subscribe()

        async def stream():
            try:
                while True:
                    envelope = await queue.get()
                    yield f"event: {envelope.topic}\ndata: {envelope.model_dump_json()}\n\n"
            except asyncio.CancelledError:  # cliente desconectou
                raise
            finally:
                bus.unsubscribe(queue)

        return StreamingResponse(stream(), media_type="text/event-stream")

    return app
