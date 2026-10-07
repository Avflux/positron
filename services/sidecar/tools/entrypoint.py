"""Ponto de entrada para o PyInstaller.

Existe por um motivo bem específico: apontar o PyInstaller direto para
`src/sidecar/__main__.py` faz ele adivinhar que aquele arquivo é um módulo de
pacote (por causa do `__init__.py` ao lado), e a adivinhação nem sempre acerta —
quando erra, os `from . import ...` explodem em runtime, dentro do executável já
compilado. Este arquivo importa o pacote pelo nome, sem ambiguidade.
"""

from __future__ import annotations

import sys

from sidecar.__main__ import main

if __name__ == "__main__":
    sys.exit(main())
