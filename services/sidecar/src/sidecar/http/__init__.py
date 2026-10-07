"""Camada HTTP opcional: health, RPC de debug e SSE para o modo navegador."""

from .app import create_app

__all__ = ["create_app"]
