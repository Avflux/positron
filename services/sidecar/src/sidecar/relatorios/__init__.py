"""Relatórios tabulares do projeto (frontend APP).

O original tinha **37 telas** `frmRelatorio_*`, todas WinForms com grade, botões de
exportação para Excel/DWG e boa parte dependente do CAD. O recoder entrega os relatórios
**tabulares** aqui no app: o conteúdo vem do banco do projeto, que o plugin já projeta e
que está conferido contra o produto (ver `docs/RUNBOOK.md`).

Cada relatório é um módulo que declara as **colunas** (com o texto do resource
`Mensagens` do original, extraído do `.resx` descompilado) e monta as linhas com SQL
leitor. Não há render de PDF/Excel aqui: o app desenha a grade.

Relatórios portados: `Lista de Materiais` (`materiais.py`), `Lista de Veias`
(`veias.py`), `Relatório de Interligação` (`interligacao.py`, o modo texto) e
`Fiação` (`fiacao.py`, o modo *Dispositivos*, o padrão da tela do original — o grafo
`terminal → potencial → outras pontas` do `CarregaLigacoesTerminal`) e `Lista de Plaquetas`
(`plaquetas.py`, a parte do banco do `frmRelatorio_Plaquetas`; `TIPO`/`HANDLE` vêm do desenho e
ficam de fora).
"""

from __future__ import annotations

from typing import Any

from .base import Relatorio
from .fiacao import RELATORIO as _FIACAO
from .interligacao import RELATORIO as _INTERLIGACAO
from .materiais import RELATORIO as _MATERIAIS
from .plaquetas import RELATORIO as _PLAQUETAS
from .veias import RELATORIO as _VEIAS

#: Os relatórios disponíveis, por id. A ordem é a da tela.
RELATORIOS: tuple[Relatorio, ...] = (_VEIAS, _MATERIAIS, _INTERLIGACAO, _FIACAO, _PLAQUETAS)

_POR_ID = {relatorio.id: relatorio for relatorio in RELATORIOS}


def listar() -> list[dict[str, Any]]:
    """O catálogo dos relatórios, para a UI montar o seletor."""
    return [relatorio.resumo() for relatorio in RELATORIOS]


def buscar(relatorio_id: str) -> Relatorio | None:
    return _POR_ID.get(relatorio_id)


__all__ = ["RELATORIOS", "Relatorio", "buscar", "listar"]
