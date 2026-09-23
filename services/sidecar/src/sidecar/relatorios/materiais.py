"""Relatório **Lista de Materiais** (`frmRelatorio_Materiais` do original).

O título e as colunas são os do original (resource `Mensagens`, bloco `[PT]`):
`656 = "Lista de Materiais"` e, na ordem da grade
(`dgListaMateriais.Columns.Add(...)`): `915 = Índice`, `1218 = Quant`, `176 = Tag`,
`64 = Descrição`, `654 = Modelo`, `1169 = Fabricante`, `1163 = Código do Cliente` e a
coluna `INDEXLM`.

A consulta é a do `cDadosLM.CarregaDadosDispositivosMultiplosPN` do original, no caso de
**um painel**:

```sql
SELECT ListaMateriais.Indice, ListaMateriais.Tag, ListaMateriais.IndiceMaterial,
       ListaMateriais.Quantidade, Materiais.DescricaoCompleta, Materiais.Modelo,
       Materiais.Fabricante, Materiais.CodigoCliente
FROM ListaMateriais
INNER JOIN Materiais ON ListaMateriais.IndiceMaterial = Materiais.CodigoInterno
WHERE ListaMateriais.IndiceMaterial <> 0 AND ListaMateriais.Painel = ?
ORDER BY ListaMateriais.IndiceMaterial, ListaMateriais.Ordem, ListaMateriais.Tag
```

Dois detalhes que valem registro, porque são do original e não escolha nossa:

* a descrição é a **`DescricaoCompleta`** (não a resumida);
* o `INNER JOIN` com o `IndiceMaterial <> 0` **descarta** as linhas sem material no
  catálogo (os bornes com `lm = 0`, por exemplo) — o relatório lista o que tem material,
  como o original. A `ListaMateriais` continua com essas linhas; quem as mostra é a tela
  do painel.

O `Ordem` do `ORDER BY` é a ordem do **diagrama** (o `COMPLM` renumera 1..N por painel),
usada só como desempate dentro do mesmo `IndiceMaterial` — a ordenação principal é a do
material.
"""

from __future__ import annotations

from typing import TYPE_CHECKING, Any

from .base import Relatorio, texto

if TYPE_CHECKING:
    from ..db import ProjectDatabase

CONSULTA = (
    "SELECT lm.Indice, lm.Tag, lm.IndiceMaterial, lm.Quantidade, lm.Ordem, lm.IndiceLM, "
    "m.DescricaoCompleta, m.Modelo, m.Fabricante, m.CodigoCliente "
    "FROM ListaMateriais lm "
    "INNER JOIN Materiais m ON lm.IndiceMaterial = m.CodigoInterno "
    "WHERE lm.IndiceMaterial <> 0 AND lm.Painel = ? "
    "ORDER BY lm.IndiceMaterial, lm.Ordem, lm.Tag"
)


class RelatorioMateriais(Relatorio):
    def __init__(self) -> None:
        super().__init__(
            id="materiais",
            titulo="Lista de Materiais",
            descricao=(
                "Lista de material do painel: uma linha por material, com a descrição, "
                "o modelo, o fabricante e o código do cliente do catálogo."
            ),
            colunas=(
                "Índice",
                "Quant",
                "Tag",
                "Descrição",
                "Modelo",
                "Fabricante",
                "Código do Cliente",
                "INDEXLM",
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
                    texto(registro["Quantidade"]),
                    texto(registro["Tag"]),
                    texto(registro["DescricaoCompleta"]),
                    texto(registro["Modelo"]),
                    texto(registro["Fabricante"]),
                    texto(registro["CodigoCliente"]),
                    texto(registro["IndiceLM"]),
                ]
            )
        return linhas


RELATORIO = RelatorioMateriais()
