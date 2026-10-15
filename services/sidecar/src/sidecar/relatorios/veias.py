"""Relatório **Lista de Veias** (`frmRelatorio_Veias` do original).

Título `895 = "Lista de Veias"` (o form usa o literal `"Lista de Veias"` e a mensagem 895
tem o mesmo texto). As colunas são as da grade (`dgVeias.Columns.Add`), com o texto do
resource `Mensagens`: `Tag`(176), `Formação`(1285), `Função`(1430), `Veias`(1239),
`Painel`(1081), `Dispositivos`(518), `Borne`(1429), `Aterrar`(1243) — esse quarteto
**duas vezes**, um por ponta —, `Documento Funcional`(253), `Página`(9) e, quando o
comprimento está ligado na tela, `Comprimento`(1246). Aqui o comprimento entra **sempre**:
o app não tem o checkbox do original.

A montagem segue o `CDadosAccessInterligacao.CarregaVeias4` (mais o
`CarregaUmaVeias4Copel` e o `CarregaDadosInterlig4`):

1. `SELECT Tag, Formacao, Funcao, Aterrar, Pn1, Pn2, Blindagem, Cabos, Comprimento FROM
   Cabos4 WHERE Revisao = ? ORDER BY Tag` — só os cabos cujo `Pn1` ou `Pn2` é o painel;
2. orientação: a ponta do painel selecionado vira a **ponta 1** do relatório; as marcas
   de `Aterrar` continuam presas ao `Pn1`/`Pn2` **originais** (`Aterrar` 1 = fim do Pn1,
   2 = fim do Pn2, 3 = os dois) — é o que o laço de orientação do original faz;
3. as veias do cabo vêm de `Veias4` (mesma revisão), pulando `Num_Veia <= -51`; o rótulo
   é o `Nome_Veia` e, quando vazio, o número da veia;
4. as pontas de cada veia vêm do `Interligacao4` por `(Revisao, Tag_Cabo, Num_Veia)`,
   casadas **por painel** com as pontas do cabo (é o `iPn1 == Painel1` / `iPn2 ==
   Painel2` do original, com as duas trocas): a ponta que não casa fica **vazia** — só a
   que casa recebe tag, borne e página. O `Terminal` vazio ou `"0"` sai como o caracter
   indefinido (`?`) e, quando o `NRegua` do lado não é vazio, é **ele** que aparece na
   coluna de dispositivo (não a tag) — duas regras do original reproduzidas de propósito;
5. o `Documento Funcional` é a lista **ordenada e sem repetição** dos documentos das duas
   pontas do trecho, unida por `", "`;
6. a `Página` sai `Pagina1, Pagina2` quando diferem (e só a que existe, quando uma é
   vazia);
7. cada cabo entra **uma vez** (o `lCabosUnico` do original);
8. nas veias de índice **negativo** (as de reserva) o original ainda tenta o trecho da
   veia **seguinte** quando a própria não resolve (`mVeia[k + 1].iIndice`) — reproduzido.

**O que não está portado:** o `OrdenaAVeia` do original reordena as veias de índice
negativo com heurísticas sobre o nome (`"P"`/`"T"`) — aqui as veias saem por `Num_Veia`.
Isso muda a **ordem relativa** das veias de reserva (índice negativo), não o conteúdo das
linhas; está registrado no `PLANO.md` §7.3.
"""

from __future__ import annotations

from typing import TYPE_CHECKING, Any

from .base import Relatorio, numero, terminal, texto

if TYPE_CHECKING:
    from ..db import ProjectDatabase

CABOS = (
    "SELECT Tag, Formacao, Funcao, Aterrar, Pn1, Pn2, Blindagem, Cabos, Comprimento "
    "FROM Cabos4 WHERE Revisao = ? ORDER BY Tag"
)

VEIAS = (
    "SELECT Num_Veia, Nome_Veia FROM Veias4 "
    "WHERE Tag = ? AND Revisao = ? AND Num_Veia > -51 ORDER BY Num_Veia"
)

#: O trecho de uma veia — o `CarregaDadosInterlig4` do original.
INTERLIGACAO = (
    "SELECT Documento1, Painel1, Pagina1, Tag1, NRegua1, Terminal1, "
    "Documento2, Painel2, Pagina2, Tag2, NRegua2, Terminal2 "
    "FROM Interligacao4 WHERE Revisao = ? AND Tag_Cabo = ? AND Num_Veia = ?"
)


class _Ponta:
    """Uma ponta de trecho, já na ordem do relatório."""

    __slots__ = ("documento", "nregua", "pagina", "tag", "terminal")

    def __init__(self, tag: str, terminal_: str, nregua: str, pagina: str, documento: str) -> None:
        self.tag = tag
        self.terminal = terminal_
        self.nregua = nregua
        self.pagina = pagina
        self.documento = documento

    @property
    def dispositivo(self) -> str:
        """O `NRegua` manda quando existe; senão a tag (regra do original)."""
        return self.nregua if self.nregua else self.tag


class _Trecho:
    """As duas pontas de um trecho, casadas com as pontas do cabo **por painel**."""

    __slots__ = ("fim1", "fim2", "documentos")

    def __init__(self) -> None:
        self.fim1: _Ponta | None = None
        self.fim2: _Ponta | None = None
        self.documentos: list[str] = []

    @property
    def tem_painel(self) -> bool:
        return bool(self.documentos) or self.fim1 is not None or self.fim2 is not None


def _montar_trecho(registro: dict[str, Any], ponta1: int, ponta2: int) -> _Trecho | None:
    """Casa as pontas do `Interligacao4` com as do cabo (`ponta1`/`ponta2`).

    O original só entra no bloco quando `Painel1 != 0` ou `Painel2 != 0`; cada ponta é
    casada por painel e a que não casa fica vazia.
    """
    painel1 = int(registro["Painel1"] or 0)
    painel2 = int(registro["Painel2"] or 0)
    if painel1 == 0 and painel2 == 0:
        return None

    trecho = _Trecho()
    ponta_a = _Ponta(
        tag=texto(registro["Tag1"]),
        terminal_=texto(registro["Terminal1"]),
        nregua=texto(registro["NRegua1"]),
        pagina=texto(registro["Pagina1"]),
        documento=texto(registro["Documento1"]),
    )
    ponta_b = _Ponta(
        tag=texto(registro["Tag2"]),
        terminal_=texto(registro["Terminal2"]),
        nregua=texto(registro["NRegua2"]),
        pagina=texto(registro["Pagina2"]),
        documento=texto(registro["Documento2"]),
    )

    if painel1 == ponta1:
        trecho.fim1 = ponta_a
    elif painel2 == ponta1:
        trecho.fim1 = ponta_b

    if painel2 == ponta2:
        trecho.fim2 = ponta_b
    elif painel1 == ponta2:
        trecho.fim2 = ponta_a

    documentos = [p.documento for p in (ponta_a, ponta_b) if p.documento]
    trecho.documentos = sorted(set(documentos))
    return trecho


def _formacao(cabo: dict[str, Any]) -> str:
    """O `Nx` da quantidade de cabos e o `(...)` da blindagem (o original faz os dois)."""
    formacao = texto(cabo["Formacao"])
    if bool(cabo["Blindagem"]):
        formacao = f"({formacao})"
    cabos = int(cabo["Cabos"] or 0)
    if cabos > 1:
        formacao = f"{cabos}x{formacao}"
    return formacao


def _paginas(primeira: str, segunda: str) -> str:
    if primeira == segunda:
        return primeira
    if not primeira:
        return segunda
    return f"{primeira}, {segunda}"


class RelatorioVeias(Relatorio):
    def __init__(self) -> None:
        super().__init__(
            id="veias",
            titulo="Lista de Veias",
            descricao=(
                "Lista de veias do painel: uma linha por veia de cada cabo, com as duas "
                "pontas (painel, dispositivo, borne e aterramento) e a página."
            ),
            colunas=(
                "Tag",
                "Formação",
                "Função",
                "Veias",
                "Painel",
                "Dispositivos",
                "Borne",
                "Aterrar",
                "Painel",
                "Dispositivos",
                "Borne",
                "Aterrar",
                "Documento Funcional",
                "Página",
                "Comprimento",
            ),
            parametros=("painel", "revisao"),
        )

    async def linhas(self, db: ProjectDatabase, params: dict[str, Any]) -> list[list[str]]:
        painel = int(params["painel"])
        revisao = texto(params.get("revisao"))
        nomes = await _nomes_de_paineis(db)

        linhas: list[list[str]] = []
        vistos: set[str] = set()
        for cabo in await db.query(CABOS, (revisao,)):
            pn1, pn2 = int(cabo["Pn1"] or 0), int(cabo["Pn2"] or 0)
            if painel not in (pn1, pn2):
                continue

            tag = texto(cabo["Tag"])
            # Cada cabo entra uma vez, como no `lCabosUnico` do original.
            if tag in vistos:
                continue
            vistos.add(tag)

            # A ponta do painel selecionado é a ponta 1 do relatório; o `Aterrar` fica
            # preso ao Pn1/Pn2 originais.
            aterrar = texto(cabo["Aterrar"])
            if pn1 == painel:
                ponta1, ponta2 = pn1, pn2
                aterrar1, aterrar2 = aterrar in ("1", "3"), aterrar in ("2", "3")
            else:
                ponta1, ponta2 = pn2, pn1
                aterrar1, aterrar2 = aterrar in ("2", "3"), aterrar in ("1", "3")

            veias = await db.query(VEIAS, (tag, revisao))
            for posicao, veia in enumerate(veias):
                numero_da_veia = int(veia["Num_Veia"] or 0)
                trecho = await _trecho(db, revisao, tag, numero_da_veia, ponta1, ponta2)
                if trecho is None and numero_da_veia <= 0 and posicao + 1 < len(veias):
                    # As veias de reserva caem no trecho da veia seguinte (o original).
                    seguinte = int(veias[posicao + 1]["Num_Veia"] or 0)
                    trecho = await _trecho(db, revisao, tag, seguinte, ponta1, ponta2)
                if trecho is None:
                    continue

                fim1, fim2 = trecho.fim1, trecho.fim2
                linhas.append(
                    [
                        tag,
                        _formacao(cabo),
                        texto(cabo["Funcao"]),
                        texto(veia["Nome_Veia"]) or str(numero_da_veia),
                        nomes.get(ponta1, ""),
                        fim1.dispositivo if fim1 else "",
                        terminal(fim1.terminal) if fim1 else "",
                        "X" if aterrar1 else "",
                        nomes.get(ponta2, ""),
                        fim2.dispositivo if fim2 else "",
                        terminal(fim2.terminal) if fim2 else "",
                        "X" if aterrar2 else "",
                        ", ".join(trecho.documentos),
                        _paginas(fim1.pagina if fim1 else "", fim2.pagina if fim2 else ""),
                        numero(cabo["Comprimento"]),
                    ]
                )
        return linhas


async def _nomes_de_paineis(db: ProjectDatabase) -> dict[int, str]:
    """O `Dicionario.BuscaNomeDoPainel`: o nome sai do cadastro `Paineis`."""
    nomes: dict[int, str] = {}
    for registro in await db.query("SELECT Indice, Nome FROM Paineis"):
        nomes[int(registro["Indice"])] = texto(registro["Nome"])
    return nomes


async def _trecho(
    db: ProjectDatabase, revisao: str, tag: str, numero: int, ponta1: int, ponta2: int
) -> _Trecho | None:
    registros = await db.query(INTERLIGACAO, (revisao, tag, numero))
    if not registros:
        return None
    return _montar_trecho(registros[0], ponta1, ponta2)


RELATORIO = RelatorioVeias()
