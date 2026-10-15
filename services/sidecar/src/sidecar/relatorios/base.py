"""A base dos relatórios tabulares do app.

Um relatório é **título + colunas + linhas**: o app desenha a grade, não há layout de
impressão aqui. As colunas levam o texto do resource `Mensagens` do original (o mesmo
que as telas usavam: `dgX.Columns.Add("", DeclaracoesGeral.mMensagem[1, id])`), extraído
do `Eletron4.Resources.resx` descompilado — o id de cada texto fica citado no módulo do
relatório, para a conferência ser possível sem adivinhação.
"""

from __future__ import annotations

from typing import TYPE_CHECKING, Any

if TYPE_CHECKING:
    from ..db import ProjectDatabase

#: O caracter do terminal indefinido do original (`Conf.CaracterTerminalIndefinido`, o
#: `Indefinido()` do `CDadosAccessInterligacao`): terminal vazio ou `"0"` vira isto.
#: O recoder usa `"?"` — o mesmo valor das regras do `VERIF` (`bt8intervalos`, `bt9`).
TERMINAL_INDEFINIDO = "?"


class Relatorio:
    """Um relatório tabular: metadados + a montagem das linhas."""

    def __init__(
        self,
        *,
        id: str,
        titulo: str,
        descricao: str,
        colunas: tuple[str, ...],
        parametros: tuple[str, ...],
    ) -> None:
        self.id = id
        self.titulo = titulo
        self.descricao = descricao
        self.colunas = colunas
        #: Os parâmetros que o relatório aceita (`painel`, `revisao`, ...), para a UI
        #: montar o formulário em vez de adivinhar.
        self.parametros = parametros

    def resumo(self) -> dict[str, Any]:
        return {
            "id": self.id,
            "titulo": self.titulo,
            "descricao": self.descricao,
            "colunas": list(self.colunas),
            "parametros": list(self.parametros),
        }

    async def linhas(self, db: ProjectDatabase, params: dict[str, Any]) -> list[list[str]]:
        raise NotImplementedError


def texto(valor: Any) -> str:
    """O `Conversions.ToString` + `TiraNothing` do original: `None`/vazio viram `""`."""
    if valor is None:
        return ""
    if isinstance(valor, bool):
        return "True" if valor else "False"
    return str(valor)


def terminal(valor: Any) -> str:
    """O `Indefinido()` do original: vazio ou `"0"` viram o caracter indefinido."""
    texto_ = texto(valor)
    if texto_ == "" or texto_ == "0":
        return TERMINAL_INDEFINIDO
    return texto_


def numero(valor: Any) -> str:
    """O `Conversions.ToString` do original **num `Double`** — o `texto()` não serve aqui.

    O `str(0.0)` do Python dá `"0.0"` e o do VB dá `"0"`: o `Conversions.ToString(Double)`
    usa o formato geral (o `ToStr` padrão do .NET Framework, **15 dígitos**), que não escreve
    as casas decimais quando o número é inteiro — é o `".15g"` daqui. A diferença aparece na
    coluna `Comprimento` da Lista de Veias (medida na rodada 159, com os 22 cabos do painel
    503: o original grava `0` e o app escrevia `0.0`).
    """
    if valor is None:
        return ""
    if isinstance(valor, bool):
        return texto(valor)
    if isinstance(valor, int):
        return str(valor)
    if isinstance(valor, float):
        if valor.is_integer() and abs(valor) < 1e15:
            return str(int(valor))
        return format(valor, ".15g").replace("e+", "E+").replace("e-", "E-")
    return texto(valor)


__all__ = ["TERMINAL_INDEFINIDO", "Relatorio", "numero", "terminal", "texto"]
