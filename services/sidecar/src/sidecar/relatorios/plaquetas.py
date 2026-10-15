"""Relatório **Lista de Plaquetas** (`frmRelatorio_Plaquetas` do original, a parte do banco).

O título e as colunas são os do original (resource `Mensagens`, bloco `[PT]`):
`589 = "Relatório Lista de Plaquetas"` e, na ordem da grade (`dgPlaquetas.Columns.Add`):
`804 = Dispositivo`, `805 = Descrição 1`, `806 = Descrição 2`, `807 = Descrição 3`,
`808 = Modelo`. A coluna de sequência leva o literal `INDICE`, como no original.

A consulta é a do `cDadosAccessPlaquetas.CarregaPlaquetas`, com o painel:

```sql
SELECT Tag, Desc1, Desc2, Desc3, Modelo FROM Plaquetas4 WHERE Painel = ? ORDER BY Indice
```

Duas diferenças em relação à tela, deliberadas:

* as colunas `TIPO` e `HANDLE` do original vêm do **desenho** (a entidade da plaqueta) e
  não existem no banco; o app não tem o desenho, então não as monta;
* a `Quantidade` da consulta do original não aparece na grade dele, e por isso também não
  entra aqui.

Como no original, a consulta não filtra por revisão nem por DWG: o `Plaquetas4` guarda o
DWG, mas `CarregaPlaquetas` só casa o painel.
"""

from __future__ import annotations

from typing import TYPE_CHECKING, Any

from .base import Relatorio, texto

if TYPE_CHECKING:
    from ..db import ProjectDatabase

CONSULTA = (
    "SELECT Tag, Desc1, Desc2, Desc3, Modelo "
    "FROM Plaquetas4 WHERE Painel = ? ORDER BY Indice"
)


class RelatorioPlaquetas(Relatorio):
    def __init__(self) -> None:
        super().__init__(
            id="plaquetas",
            titulo="Relatório Lista de Plaquetas",
            descricao=(
                "Plaquetas do painel: uma linha por plaqueta, com o dispositivo e as três "
                "descrições e o modelo, na ordem em que foram gravadas."
            ),
            colunas=(
                "INDICE",
                "Dispositivo",
                "Descrição 1",
                "Descrição 2",
                "Descrição 3",
                "Modelo",
            ),
            parametros=("painel",),
        )

    async def linhas(self, db: ProjectDatabase, params: dict[str, Any]) -> list[list[str]]:
        painel = int(params["painel"])
        registros = await db.query(CONSULTA, (painel,))
        linhas: list[list[str]] = []
        for sequencia, registro in enumerate(registros, start=1):
            linhas.append(
                [
                    str(sequencia),
                    texto(registro["Tag"]),
                    texto(registro["Desc1"]),
                    texto(registro["Desc2"]),
                    texto(registro["Desc3"]),
                    texto(registro["Modelo"]),
                ]
            )
        return linhas


RELATORIO = RelatorioPlaquetas()
