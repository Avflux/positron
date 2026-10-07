"""Imprime o contrato do sidecar em JSON.

Usado por `scripts/gen-protocol.ps1` para comparar a fonte da verdade (Python)
com o espelho em TypeScript. Deixar isto num arquivo, e não num `python -c`,
evita a briga de aspas entre PowerShell, bash e Python.

    python tools/dump_contract.py
    {"version": 1, "methods": ["echo", "ping"]}
"""

from __future__ import annotations

import json
import sys

from sidecar.handlers import Handlers
from sidecar.protocol import PROTOCOL_VERSION


def main() -> int:
    contract = {
        "version": PROTOCOL_VERSION,
        "methods": Handlers().methods,
    }
    print(json.dumps(contract))
    return 0


if __name__ == "__main__":
    sys.exit(main())
