"""Configuração de teste.

O pyzmq **não funciona** no `ProactorEventLoop`, que é o loop padrão do Windows
desde o Python 3.8. O `zmq.asyncio` precisa da família `add_reader`, que o
Proactor não implementa:

    RuntimeError: Proactor event loop does not implement add_reader family of
    methods required for zmq.

Sem isto, os testes de round-trip travam em vez de falhar (a mensagem do pyzmq
só aparece quando algo tenta ler). O `conftest.py` é importado antes de qualquer
teste, então a política já vale quando o pytest-asyncio cria o loop.

Opcionalmente dá para resolver com `tornado>=6.1` instalado, que o pyzmq usa como
fallback — mas uma dependência a mais só por isso não se paga.
"""

from __future__ import annotations

import asyncio
import sys
import warnings

if sys.platform == "win32":  # pragma: no cover - dependente de plataforma
    with warnings.catch_warnings():
        # `set_event_loop_policy` está deprecado no Python 3.14 e não tem
        # substituto antes do pytest-asyncio criar o loop de cada teste.
        warnings.simplefilter("ignore", DeprecationWarning)
        asyncio.set_event_loop_policy(asyncio.WindowsSelectorEventLoopPolicy())
