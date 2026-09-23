"""Relatório **Relatório de Interligação** (`frmRelatorio_Interligacao` do original).

Título `591 = "Relatório de Interligação"`. As colunas são as da grade
(`dgInterlig.Columns.Add`), com o texto do resource `Mensagens`: `Régua`(1425),
`Tag`(1426), `Formação`(1427), `Anilha`(1591), `Destino`(1428), `Régua`(1425),
`Borne`(1429), `Função`(1430), `Documento`(1431) e `Trajeto`(1248), mais duas colunas de
rótulo configurável na tela que aqui **não** entram (elas ficam sempre vazias no original).

É uma **árvore**: para cada **régua** do painel, os seus **bornes** e, em cada borne, os
**cabos** que passam por ele. A montagem segue o `cDadosAccessInterligacao2`:

1. **réguas**: as de borne saem do cadastro (`SELECT DISTINCT Regua, DWG FROM Bornes4I
   WHERE Revisao = ? AND Painel = ? AND Tipo < 2`, com `Tag = Regua`, `NRegua = ""`,
   `Tipo = "B"` — o `CarregaReguas`) e as de **porta** das pontas de porta da
   `Interligacao4` (`NRegua <> ''` com `TipoBorne` `-1`/`-2`, `Tag = Tag1`,
   `NRegua = NRegua1`, `Tipo = "E"`) — o `CarregaReguasPortas`;
2. **bornes**: réguas de borne vêm do `Bornes4I` (`Tipo < 2`, `ORDER BY Ordem DESC`,
   sem repetição, e **invertidas** — o `Array.Reverse` do original deixa em ordem
   crescente de `Ordem`); réguas de porta vêm do `Portas4I` (`Tipo = 'B'`, `ORDER BY
   Indice` no modo cadastro) — é o `CarregaBornesReguas` com **`rbCadastro` ligado**, que
   é o modo portado;
3. **cabos do borne**: `SELECT Tag_Cabo, Num_Veia, Nome_Veia, Painel2, Documento2, Tag2,
   NRegua2, Terminal2, Pagina2, Documento1, Pagina1 FROM Interligacao4 WHERE Revisao = ?
   AND Painel1 = ? AND Tag1 = ? AND NRegua1 = ? AND Terminal1 = ? ORDER BY Tag_Cabo` — a
   ponta 1 é o próprio borne; a **destino** é a ponta 2 (o `CarregaCabosNosBornesRI`);
4. por cabo, o `Cabos4` (`Formacao, Funcao, Blindagem, Cabos, Pn1, Pn2, Aterrar,
   Trajeto`).

Os **cabeçalhos de grupo** são as linhas com o nome da régua na primeira coluna (a grade
do original pinta a linha de cinza e o texto em negrito); a linha em branco que o original
insere **entre** os grupos não é emitida (apresentação).

Regras de formatação do original reproduzidas (o laço `rbTexto`, linhas 1609-1689) — todas
mudam o que aparece:

* cabo `"$REP$"` é **pulado**;
* `Tag`: com `Nome_Veia` preenchido é `Tag_Cabo` quando o cabo tem mais de uma veia e
  `Tag_Cabo (Nome_Veia)` quando tem uma; sem `Nome_Veia` é `Tag_Cabo` quando a **formação
  começa com `1x`/`1X`** e `Tag_Cabo-Num_Veia` no resto;
* `Formação`: `(Formacao)` quando `Blindagem`, com prefixo `Nx` quando `Cabos > 1`;
* `Anilha`: `RÉGUA-BORNE` (o `text5`) — e **vazia** quando a `Tag` sai vazia;
* `Destino`: o nome do **painel** da outra ponta (`Paineis`), e **vazio** quando a veia é
  `<= 0` (o `sPainelDest` do original);
* `Régua` (destino): `TagDest/R NReguaDest` quando o `NReguaDest` existe e o painel é
  diferente da tag; só `NReguaDest` quando o painel é igual à tag; só `TagDest` no resto;
* `Borne` (destino): o `Terminal` da outra ponta, com **`?`** quando ele é exatamente
  `"0"`;
* `Documento`: `Documento1/Pagina1` mais `Documento2/Pagina2` quando a veia é `> 0`, com
  os **dois casos especiais** do original (um lado vazio ou iguais → só o primeiro;
  mesmo documento com páginas diferentes → `Documento1, Pagina2`);
* a coluna sem rótulo depois de `Documento` leva o **`Tipo` do borne** (`tipoBorne`), como
  no original.

**O que não está portado:** o modo **gráfico** (`rbGrafico`), que desenha a árvore de
jumpers com o `bEntra`/`bSai`, e a seção de **veias de reserva** (`cbReserva`). O modo
texto é o que lista os cabos por borne; os dois ficam registrados no `PLANO.md` §7.3.
"""

from __future__ import annotations

from typing import TYPE_CHECKING, Any

from .base import Relatorio, texto

if TYPE_CHECKING:
    from ..db import ProjectDatabase

#: As réguas de borne (o `CarregaReguas`): `Tag = Regua` e `NRegua = ""`.
REGUAS_BORNE = (
    "SELECT DISTINCT Regua, DWG FROM Bornes4I "
    "WHERE Revisao = ? AND Painel = ? AND Tipo < 2"
)

#: As réguas de **porta** (o `CarregaReguasPortas`): as duas pontas da `Interligacao4`
#: cujo `NRegua` existe e cujo `TipoBorne` é `-1`/`-2` (porta).
#:
#: **`IFNULL` nas comparações com `''`:** o original roda em Jet/Access, que **não
#: distingue string vazia de `NULL`** — `NRegua1 = ''` casa as duas coisas. No SQLite a
#: coluna vazia é `NULL` (o `ProjectStore` grava `DBNull`), e `NULL = ''` é falso: sem o
#: `IFNULL` a consulta do original não acharia cabo nenhum.
REGUAS_PORTA_PONTA1 = (
    "SELECT DISTINCT Tag1, NRegua1, IndexModelo1, DWG1 FROM Interligacao4 "
    "WHERE Revisao = ? AND Painel1 = ? AND IFNULL(NRegua1, '') <> '' "
    "AND (TipoBorne1 = -1 OR TipoBorne1 = -2)"
)
REGUAS_PORTA_PONTA2 = (
    "SELECT DISTINCT Tag2, NRegua2, IndexModelo2, DWG2 FROM Interligacao4 "
    "WHERE Revisao = ? AND Painel2 = ? AND IFNULL(NRegua2, '') <> '' "
    "AND (TipoBorne2 = -1 OR TipoBorne2 = -2)"
)

BORNES_DA_REGUA = (
    "SELECT Borne, Ordem, Tipo, Pagina FROM Bornes4I "
    "WHERE Revisao = ? AND Painel = ? AND Regua = ? AND Tipo < 2 ORDER BY Ordem DESC"
)

BORNES_DA_PORTA = (
    "SELECT Borne FROM Portas4I "
    "WHERE Revisao = ? AND DWG = ? AND IndexModelo = ? AND Regua = ? AND Tipo = 'B' ORDER BY Indice"
)

#: Os cabos que passam pelo borne (a ponta 1 é o borne; a 2 é o destino). O
#: `IFNULL(NRegua1, '')` é o mesmo ajuste de Jet→SQLite das réguas de porta acima.
CABOS_NO_BORNE = (
    "SELECT Tag_Cabo, Num_Veia, Nome_Veia, Painel2, Documento2, Tag2, NRegua2, Terminal2, "
    "Pagina2, Documento1, Pagina1 FROM Interligacao4 "
    "WHERE Revisao = ? AND Painel1 = ? AND Tag1 = ? AND IFNULL(NRegua1, '') = ? "
    "AND Terminal1 = ? ORDER BY Tag_Cabo"
)

CABO = (
    "SELECT Formacao, Funcao, Blindagem, Cabos, Pn1, Pn2, Aterrar, Trajeto "
    "FROM Cabos4 WHERE Revisao = ? AND Tag = ?"
)

#: A veia de representação do cabo (a mesma convenção da `Veias4`/`Interligacao4`).
VEIA_REPETIDA = "$REP$"


class _Regua:
    """Uma régua da árvore (de borne, `B`, ou de porta, `E`)."""

    __slots__ = ("dwg", "index_modelo", "nregua", "tipo", "tag")

    def __init__(self, tag: str, nregua: str, tipo: str, index_modelo: int, dwg: int) -> None:
        self.tag = tag
        self.nregua = nregua
        self.tipo = tipo
        self.index_modelo = index_modelo
        self.dwg = dwg

    @property
    def cabecalho(self) -> str:
        """O `text2` do original: `NRegua` na porta, `Tag` no borne."""
        return self.nregua if self.tipo == "E" else self.tag


def _formacao(cabo: dict[str, Any]) -> str:
    formacao = texto(cabo["Formacao"])
    if bool(cabo["Blindagem"]):
        formacao = f"({formacao})"
    cabos = int(cabo["Cabos"] or 0)
    if cabos > 1:
        formacao = f"{cabos}x{formacao}"
    return formacao


def _tag_do_cabo(cabo: dict[str, Any], formacao: str) -> str:
    """A regra de `text3` do original (depende do `Nome_Veia`, de `Cabos` e da formação)."""
    tag_cabo = texto(cabo["Tag_Cabo"])
    nome_veia = texto(cabo["Nome_Veia"])
    if nome_veia:
        if int(cabo["Cabos"] or 0) > 1:
            return tag_cabo
        return f"{tag_cabo} ({nome_veia})"
    if formacao.startswith("1x") or formacao.startswith("1X"):
        return tag_cabo
    return f"{tag_cabo}-{texto(cabo['Num_Veia'])}"


def _regua_destino(cabo: dict[str, Any], painel_destino: str) -> str:
    """A regra de `text6`: `TagDest/NReguaDest`, só `NReguaDest` ou só `TagDest`."""
    tag_dest = texto(cabo["Tag2"])
    nregua_dest = texto(cabo["NRegua2"])
    if not nregua_dest:
        return tag_dest
    if painel_destino != tag_dest:
        return f"{tag_dest}/{nregua_dest}"
    return nregua_dest


def _documento(cabo: dict[str, Any]) -> str:
    """A composição de `text12` — com os dois casos especiais do original."""
    doc_origem = texto(cabo["Documento1"])
    pag_origem = texto(cabo["Pagina1"])
    doc_dest = texto(cabo["Documento2"])
    pag_dest = texto(cabo["Pagina2"])

    primeira = f"{doc_origem}/{pag_origem}"
    segunda = f"{doc_dest}/{pag_dest}" if int(cabo["Num_Veia"] or 0) > 0 else ""

    if segunda == "" or primeira == segunda:
        documento = primeira
    else:
        documento = f"{primeira}, {segunda}"

    if doc_origem and doc_dest and doc_origem == doc_dest and pag_origem != pag_dest:
        documento = f"{primeira}, {pag_dest}"
    return documento


def _borne_destino(valor: Any) -> str:
    """O `text8`: `?` **só** quando o terminal de destino é exatamente `"0"`."""
    return "?" if texto(valor) == "0" else texto(valor)


class RelatorioInterligacao(Relatorio):
    def __init__(self) -> None:
        super().__init__(
            id="interligacao",
            titulo="Relatório de Interligação",
            descricao=(
                "Interligação do painel por régua: para cada régua, os bornes do cadastro "
                "e os cabos que passam em cada borne, com o destino e a página."
            ),
            colunas=(
                "Régua",
                "",
                "Tag",
                "Formação",
                "Anilha",
                "Destino",
                "Régua",
                "Borne",
                "Função",
                "Documento",
                "",
                "Trajeto",
            ),
            parametros=("painel", "revisao"),
        )

    async def linhas(self, db: ProjectDatabase, params: dict[str, Any]) -> list[list[str]]:
        painel = int(params["painel"])
        revisao = texto(params.get("revisao"))
        nomes = await _nomes_de_paineis(db)

        linhas: list[list[str]] = []
        cabecalho_atual: str | None = None
        for regua in await _reguas(db, revisao, painel):
            cabecalho = regua.cabecalho
            if cabecalho != cabecalho_atual:
                # A linha de grupo: o nome da régua na primeira coluna (na grade do
                # original ela sai em negrito e com fundo cinza).
                linhas.append([cabecalho] + [""] * (len(self.colunas) - 1))
                cabecalho_atual = cabecalho

            for borne in await _bornes(db, revisao, painel, regua):
                anilha = f"{cabecalho}-{borne['Borne']}"
                for cabo in await _cabos_do_borne(db, revisao, painel, regua, borne["Borne"]):
                    if texto(cabo["Tag_Cabo"]) == VEIA_REPETIDA:
                        continue

                    detalhe = await _cabo(db, revisao, texto(cabo["Tag_Cabo"]))
                    formacao = _formacao(detalhe)
                    tag = _tag_do_cabo(cabo, formacao)
                    # O `sPainelDest` do original: o nome do painel da outra ponta e
                    # **vazio** quando a veia e <= 0 (a ponta nao e uma veia de cabo).
                    destino = ""
                    if int(cabo["Num_Veia"] or 0) > 0:
                        destino = nomes.get(int(cabo["Painel2"] or 0), "")

                    linhas.append(
                        [
                            texto(borne["Borne"]),
                            "",
                            tag,
                            formacao,
                            anilha if tag else "",
                            destino,
                            _regua_destino(cabo, destino),
                            _borne_destino(cabo["Terminal2"]),
                            texto(detalhe["Funcao"]),
                            _documento(cabo),
                            texto(borne["Tipo"]),
                            texto(detalhe["Trajeto"]),
                        ]
                    )
        return linhas


async def _reguas(
    db: ProjectDatabase, revisao: str, painel: int
) -> list[_Regua]:
    """As réguas da árvore: primeiro as de borne, depois as de porta (a ordem do form)."""
    reguas: list[_Regua] = []
    vistas: set[tuple[str, str]] = set()

    for registro in await db.query(REGUAS_BORNE, (revisao, painel)):
        regua = _Regua(
            tag=texto(registro["Regua"]),
            nregua="",
            tipo="B",
            index_modelo=-1,
            dwg=int(registro["DWG"] or 0),
        )
        reguas.append(regua)
        vistas.add((regua.tag, regua.nregua))

    for consulta, colunas in (
        (REGUAS_PORTA_PONTA1, ("Tag1", "NRegua1", "IndexModelo1", "DWG1")),
        (REGUAS_PORTA_PONTA2, ("Tag2", "NRegua2", "IndexModelo2", "DWG2")),
    ):
        for registro in await db.query(consulta, (revisao, painel)):
            regua = _Regua(
                tag=texto(registro[colunas[0]]),
                nregua=texto(registro[colunas[1]]),
                tipo="E",
                index_modelo=int(registro[colunas[2]] or 0),
                dwg=int(registro[colunas[3]] or 0),
            )
            if (regua.tag, regua.nregua) in vistas:
                continue
            vistas.add((regua.tag, regua.nregua))
            reguas.append(regua)

    return reguas


async def _bornes(
    db: ProjectDatabase, revisao: str, painel: int, regua: _Regua
) -> list[dict[str, Any]]:
    """Os bornes de uma régua, na ordem do original (cadastro ligado)."""
    if regua.tipo == "E":
        # O `Portas4I` só traz o `Borne`; o original completa com `Tipo = 0` e
        # `Pagina = ""` (o `array5[num4].TipoBorne = 0` / `.Pagina = ""`).
        return [
            {"Borne": registro["Borne"], "Tipo": 0, "Pagina": "", "Ordem": None}
            for registro in await db.query(
                BORNES_DA_PORTA, (revisao, regua.dwg, regua.index_modelo, regua.nregua)
            )
        ]

    registros = await db.query(BORNES_DA_REGUA, (revisao, painel, regua.tag))
    bornes: list[dict[str, Any]] = []
    vistos: set[str] = set()
    for registro in registros:  # já vem `Ordem DESC`; o original dedupa e **inverte**
        borne = texto(registro["Borne"])
        if borne in vistos:
            continue
        vistos.add(borne)
        bornes.append(registro)
    bornes.reverse()
    return bornes


async def _cabos_do_borne(
    db: ProjectDatabase, revisao: str, painel: int, regua: _Regua, borne: str
) -> list[dict[str, Any]]:
    """Os cabos que passam no borne: a ponta 1 é `(Tag1, NRegua1, Terminal1)`."""
    return list(
        await db.query(CABOS_NO_BORNE, (revisao, painel, regua.tag, regua.nregua, borne))
    )


async def _cabo(db: ProjectDatabase, revisao: str, tag: str) -> dict[str, Any]:
    registros = await db.query(CABO, (revisao, tag))
    return registros[0] if registros else {}


async def _nomes_de_paineis(db: ProjectDatabase) -> dict[int, str]:
    """O `Dicionario.BuscaNomeDoPainel` (o `sPainelDest`): o nome sai do cadastro."""
    nomes: dict[int, str] = {}
    for registro in await db.query("SELECT Indice, Nome FROM Paineis"):
        nomes[int(registro["Indice"])] = texto(registro["Nome"])
    return nomes


RELATORIO = RelatorioInterligacao()
