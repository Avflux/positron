"""Relatório **Fiação** (`frmRelatorio_Fiacao` do original) — modo *Dispositivos*.

Título `590 = "Relatórios de Fiação"`. A tela do original tem cinco grades (DWG,
revisão, equipamento/painel, dispositivos e a de fiação) e um par de radios que
escolhem **o que** listar (`rbDispositivos` 518 / `rbReguas` 788) e outro que escolhe
**quanto** (`rbTodos` 792 / `rbUsados` 793). Os padrões da tela são
`rbDispositivos` + `rbTodos` (`cbAlternativo` e `cbLayout` desligados) — é esse modo
que este módulo porta, o que o formulário mostra ao abrir.

As colunas saem de `formataDGFiacao` (o texto de cada uma é o id do resource
`Mensagens`): `Terminal`(776), uma coluna **sem rótulo** para o caractere de ligação,
`Dispositivo 1`(777), `Terminal 1`(778), `Dispositivo 2`(779), `Terminal 2`(780),
`Seção`(781), `Cor`(782) e `Página`(783). A coluna `TIPO`(262) só aparece quando nem
`rbDispositivos` nem `rbReguas` estão ligados; no modo portado (Dispositivos) a sétima
coluna é a `Cor`.

A montagem segue o laço `R9dpbbD9Jbg` (o botão de pesquisar) alimentado por:

1. **a lista de dispositivos** — o `CarregaDispTipoIndexModelo`: uma consulta à
   `Fiacao` por painel em que a **chave de deduplicação** é o `Tag` mais um sufixo
   (`-A` para `P`/`A`, `-E` para `E`, `-B` para `B`) e o **tipo do relatório** colapsa
   `P` e `A` em `"A"` (é o original; é isso que decide o leitor de terminais);
2. **os terminais de cada dispositivo** — `CarregaTerminaisDispositivo` (sem modelo,
   `IndexModelo == 0`: os terminais saem da própria `Fiacao`, deduplicados na ordem
   `TerminalNum, Terminal`), `CarregaTerminaisContato` (`IndexModelo > 0`: os terminais
   do **modelo de contato**, `Contatos4F`, sem deduplicar) ou `CarregaTerminaisMascara`
   (`tipo == "E"`: `Portas4F`, com o `Terminal` sendo o `Borne` quando a `Regua` existe);
3. **as ligações de cada terminal** — o `CarregaLigacoesTerminal`, que para cada
   terminal busca as linhas da `Fiacao` (mesmo `Tag`/`NRegua`/`Terminal`, `Tipo <> 'B'`,
   `BJumper = 0`, ordenadas por `Secao, Cor`) e, para cada uma, os **vizinhos** do mesmo
   potencial (`Ordem - 1` e `Ordem + 1`) — são esses vizinhos que viram "Dispositivo 1/2"
   e "Terminal 1/2". O `Term` do vizinho é `NRegua:Terminal` quando ele tem `NRegua`
   (é a regra de formatação do original) e o `Terminal` sozinho no resto.

**O que muda do original, e por quê:** a tela gera a grade só para as linhas
**selecionadas** em `dgDisp`; aqui não há seleção, então o relatório emite a seção de
**todos** os dispositivos do painel. A consulta também não filtra o `DWG` (o app
seleciona painel + revisão, como os outros relatórios — ver `PLANO.md` §7.3).

**O que não está portado** (registrado no `PLANO.md` §7.3): os modos *Réguas de Bornes*
(`rbReguas`) e *Terminais usados* (`rbUsados`), o alternativo (`cbAlternativo`), a
ordem do layout (`cbLayout`), os caracteres de ligação `║╗╝` (que saem do `mLink`, só
calculado no modo de régua) e as exportações DWG/Excel — no modo portado a coluna sem
rótulo sai sempre vazia, como no original.
"""

from __future__ import annotations

from typing import TYPE_CHECKING, Any

from .base import Relatorio, texto

if TYPE_CHECKING:
    from ..db import ProjectDatabase

#: A lista de dispositivos do painel (o `CarregaDispTipoIndexModelo`, sem os itens sem
#: fiação — `bAdicionaDispSemFiacao = false`).
DISPOSITIVOS = (
    "SELECT Tag, Alternativo, Tipo, IndexModelo, Handle FROM Fiacao "
    "WHERE Painel = ? AND Revisao = ? AND BJumper = 0 ORDER BY Tag"
)

#: Os terminais de um dispositivo **sem modelo** (o `CarregaTerminaisDispositivo`): saem
#: da `Fiacao`, `Tipo <> 'B'`, e o original deduplica preservando a primeira ocorrência
#: da ordem `TerminalNum, Terminal`.
TERMINAIS_DISPOSITIVO = (
    "SELECT Terminal FROM Fiacao "
    "WHERE Painel = ? AND Revisao = ? AND Tag = ? AND Tipo <> 'B' "
    "ORDER BY TerminalNum, Terminal"
)

#: Os terminais do **modelo de contato** (o `CarregaTerminaisContato`, `IndexModelo > 0`)
#: — o original **não** deduplica esta lista.
TERMINAIS_CONTATO = (
    "SELECT Terminal FROM Contatos4F "
    "WHERE Revisao = ? AND IndexModelo = ? ORDER BY TerminalNum, Terminal"
)

#: Os terminais do **modelo de máscara** (o `CarregaTerminaisMascara`, `tipo == "E"`).
TERMINAIS_MASCARA = (
    "SELECT Regua, Borne, Terminal FROM Portas4F "
    "WHERE Revisao = ? AND IndexModelo = ? ORDER BY Regua, TerminalNum, Terminal, Borne"
)

#: As linhas da `Fiacao` de um terminal **sem régua** (`NRegua == ""`), o `tipo <> "B"` do
#: `CarregaLigacoesTerminal`.
LIGACOES_SEM_REGUA = (
    "SELECT Potencial, Ordem, Pagina, Secao, Cor FROM Fiacao "
    "WHERE Painel = ? AND Revisao = ? AND Tag = ? AND Terminal = ? "
    "AND Tipo <> 'B' AND BJumper = 0 ORDER BY Secao, Cor"
)

#: As mesmas linhas quando o terminal vem de uma máscara (o original filtra o `NRegua`).
LIGACOES_COM_REGUA = (
    "SELECT Potencial, Ordem, Pagina, Secao, Cor FROM Fiacao "
    "WHERE Painel = ? AND Revisao = ? AND Tag = ? AND NRegua = ? AND Terminal = ? "
    "AND Tipo <> 'B' AND BJumper = 0 ORDER BY Secao, Cor"
)

#: O vizinho do mesmo potencial (o `Potencial`/`Ordem ± 1`): é ele que vira a ponta da
#: ligação. O modo portado é o de dispositivo/máscara, cujo `tipo <> "B"` faz o `bLink`
#: do original ficar sempre falso — só as ligações simples são montadas, nunca o `mLink`.
VIZINHO = (
    "SELECT Tag, Alternativo, NRegua, Terminal, BLink FROM Fiacao "
    "WHERE Painel = ? AND Revisao = ? AND Potencial = ? AND Ordem = ?"
)


class _Ligacao:
    """Uma ponta da ligação (o `structureLigacao` do original)."""

    __slots__ = ("cor", "secao", "tag", "term")

    def __init__(self, tag: str, term: str, secao: str, cor: str) -> None:
        self.tag = tag
        self.term = term
        self.secao = secao
        self.cor = cor


class _Dispositivo:
    """Uma linha de `dgDisp` (o `structureVF` do original)."""

    __slots__ = ("index_modelo", "tag", "tipo")

    def __init__(self, tag: str, tipo: str, index_modelo: int) -> None:
        self.tag = tag
        self.tipo = tipo
        self.index_modelo = index_modelo


def _sufixo(tag: str, tipo: str) -> str:
    """A chave de deduplicação do `dgDisp` — o `item` montado pelo original."""
    if tipo in ("P", "A"):
        return f"{tag}-A"
    if tipo == "E":
        return f"{tag}-E"
    if tipo == "B":
        return f"{tag}-B"
    return ""


def _tipo_do_relatorio(tipo: str) -> str:
    """O `text2` do original: `P` e `A` viram `"A"`, o resto é preservado."""
    if tipo in ("P", "A"):
        return "A"
    if tipo in ("E", "B"):
        return tipo
    return ""


def _ksep(nregua: str, terminal_: str) -> str:
    """O `kSepbOpfnuc`: `NRegua:Terminal` com `NRegua`, e `Terminal` sozinho sem ele."""
    if nregua.strip() == "":
        return terminal_.strip()
    return f"{nregua}:{terminal_}".strip()


def _term(nregua: str, terminal_: str) -> str:
    """O `Term` da ligação: o mesmo `NRegua:Terminal` do `kSepbOpfnuc`."""
    return f"{nregua}:{terminal_}" if nregua != "" else terminal_


def _junta(primeiro: str, segundo: str) -> str:
    """O `lig[1] + " ; " + lig[2]` quando os dois valores diferem."""
    if primeiro != segundo:
        return f"{primeiro} ; {segundo}"
    return primeiro


def _vizinho(registro: dict[str, Any], secao: str, cor: str) -> _Ligacao:
    return _Ligacao(
        tag=texto(registro["Tag"]),
        term=_term(texto(registro["NRegua"]), texto(registro["Terminal"])),
        secao=secao,
        cor=cor,
    )


class RelatorioFiacao(Relatorio):
    def __init__(self) -> None:
        super().__init__(
            id="fiacao",
            titulo="Relatórios de Fiação",
            descricao=(
                "Fiação do painel por dispositivo: para cada dispositivo e cada terminal, "
                "as pontas ligadas no mesmo potencial (dispositivo e terminal)."
            ),
            colunas=(
                "Terminal",
                "",
                "Dispositivo 1",
                "Terminal 1",
                "Dispositivo 2",
                "Terminal 2",
                "Seção",
                "Cor",
                "Página",
            ),
            parametros=("painel", "revisao"),
        )

    async def linhas(self, db: ProjectDatabase, params: dict[str, Any]) -> list[list[str]]:
        painel = int(params["painel"])
        revisao = texto(params.get("revisao"))

        linhas: list[list[str]] = []
        for dispositivo in await _dispositivos(db, painel, revisao):
            linhas.append([dispositivo.tag] + [""] * (len(self.colunas) - 1))
            for terminal_, nregua in await _terminais(db, painel, revisao, dispositivo):
                ligacoes, pagina = await _ligacoes(
                    db, painel, revisao, dispositivo.tag, terminal_, nregua
                )
                linhas.extend(_linhas_do_terminal(terminal_, nregua, ligacoes, pagina))
            linhas.append([""] * len(self.colunas))
        return linhas


async def _dispositivos(
    db: ProjectDatabase, painel: int, revisao: str
) -> list[_Dispositivo]:
    """O `CarregaDispTipoIndexModelo` no modo `rbDispositivos` (sem os `B`)."""
    dispositivos: list[_Dispositivo] = []
    vistos: set[str] = set()
    for registro in await db.query(DISPOSITIVOS, (painel, revisao)):
        tag = texto(registro["Tag"])
        tipo = _tipo_do_relatorio(texto(registro["Tipo"]))
        chave = _sufixo(tag, texto(registro["Tipo"]))
        if chave in vistos:
            continue
        vistos.add(chave)
        # O `rbDispositivos` do original mostra tudo menos as réguas de borne (`B`).
        if tipo == "B":
            continue
        dispositivos.append(
            _Dispositivo(tag, tipo, int(registro["IndexModelo"] or 0))
        )
    return dispositivos


async def _terminais(
    db: ProjectDatabase, painel: int, revisao: str, dispositivo: _Dispositivo
) -> list[tuple[str, int, str]]:
    """Os terminais de um dispositivo: `(Terminal, NRegua)`.

    Reproduz o `switch` do `R9dpbbD9Jbg` para o **tipo do relatório** `"A"`/`"E"` (o
    único par que o modo `rbDispositivos` produz, fora os de tipo vazio, que não têm
    leitor e caem numa seção sem terminais). O `TipoBorne` do original só importa no
    modo de régua (`B`) e aqui é sempre `0`.
    """
    if dispositivo.tipo == "A" and dispositivo.index_modelo == 0:
        # `CarregaTerminaisDispositivo`: deduplica na ordem da consulta.
        terminais: list[tuple[str, str]] = []
        vistos: set[str] = set()
        for registro in await db.query(
            TERMINAIS_DISPOSITIVO, (painel, revisao, dispositivo.tag)
        ):
            terminal_ = texto(registro["Terminal"])
            if terminal_ in vistos:
                continue
            vistos.add(terminal_)
            terminais.append((terminal_, ""))
        return terminais
    if dispositivo.tipo == "A":
        # `CarregaTerminaisContato`: o modelo de contato, sem deduplicar.
        return [
            (texto(registro["Terminal"]), "")
            for registro in await db.query(
                TERMINAIS_CONTATO, (revisao, dispositivo.index_modelo)
            )
        ]
    if dispositivo.tipo == "E":
        # `CarregaTerminaisMascara`: o `Terminal` é o `Borne` quando a régua existe.
        terminais_mascara: list[tuple[str, str]] = []
        for registro in await db.query(
            TERMINAIS_MASCARA, (revisao, dispositivo.index_modelo)
        ):
            nregua = texto(registro["Regua"])
            borne = texto(registro["Borne"])
            terminal_ = borne if nregua.strip() != "" else texto(registro["Terminal"])
            terminais_mascara.append((terminal_, nregua))
        return terminais_mascara
    return []


async def _ligacoes(
    db: ProjectDatabase,
    painel: int,
    revisao: str,
    tag: str,
    terminal_: str,
    nregua: str,
) -> tuple[list[_Ligacao], str]:
    """O `CarregaLigacoesTerminal` para um terminal de tipo `A`/`E`.

    Para cada linha da `Fiacao` do terminal, os vizinhos `Ordem - 1` e `Ordem + 1` do
    mesmo potencial viram ligações; a `Seção`/`Cor` de cada ligação é a da linha do
    terminal e a `Página` do terminal é a da **última** linha (é o que o original faz:
    ele grava o par dentro do laço, então a última vence). No tipo `A`/`E` o `bLink` do
    original é sempre falso, então **toda** linha acrescenta ligações — o caminho do
    `mLink` (os caracteres `║╗╝`) não entra.
    """
    if nregua != "":
        registros = await db.query(LIGACOES_COM_REGUA, (painel, revisao, tag, nregua, terminal_))
    else:
        registros = await db.query(LIGACOES_SEM_REGUA, (painel, revisao, tag, terminal_))

    ligacoes: list[_Ligacao] = []
    pagina = ""
    for registro in registros:
        potencial = int(registro["Potencial"] or 0)
        ordem = int(registro["Ordem"] or 0)
        secao = texto(registro["Secao"])
        cor = texto(registro["Cor"])
        pagina = texto(registro["Pagina"])

        if ordem > 1:
            anterior = await db.query(VIZINHO, (painel, revisao, potencial, ordem - 1))
            if len(anterior) == 1:
                ligacoes.append(_vizinho(anterior[0], secao, cor))

        seguinte = await db.query(VIZINHO, (painel, revisao, potencial, ordem + 1))
        if len(seguinte) == 1:
            ligacoes.append(_vizinho(seguinte[0], secao, cor))
    return ligacoes, pagina


def _linhas_do_terminal(
    terminal_: str, nregua: str, ligacoes: list[_Ligacao], pagina: str
) -> list[list[str]]:
    """A emissão do `R9dpbbD9Jbg` para um terminal (os ramos por `Ubound(lig)`).

    O original decide a forma da linha pelo número de ligações: 0 só com `rbTodos`, 1
    uma linha, 2 uma linha com as duas pontas, 3 e 4 **duas** linhas (2 + 1 e 2 + 2) e
    mais de 4 a linha de erro. A coluna `TipoBorne` do original (`== 0` pinta a linha de
    vermelho) não atravessa o contrato — é apresentação.
    """
    primeiro = _ksep(nregua, terminal_)
    quantidade = len(ligacoes)

    if quantidade == 0:
        return [[primeiro, "", "", "", "", "", "", "", pagina]]

    if quantidade == 1:
        unica = ligacoes[0]
        return [[primeiro, "", unica.tag, unica.term, "", "", unica.secao, unica.cor, pagina]]

    if quantidade == 2:
        primeira, segunda = ligacoes
        return [
            [
                primeiro,
                "",
                primeira.tag,
                primeira.term,
                segunda.tag,
                segunda.term,
                _junta(primeira.secao, segunda.secao),
                _junta(primeira.cor, segunda.cor),
                pagina,
            ]
        ]

    if quantidade == 3:
        primeira, segunda, terceira = ligacoes
        return [
            [
                primeiro,
                "",
                primeira.tag,
                primeira.term,
                segunda.tag,
                segunda.term,
                _junta(primeira.secao, segunda.secao),
                _junta(primeira.cor, segunda.cor),
                pagina,
            ],
            [
                primeiro,
                "",
                terceira.tag,
                terceira.term,
                "",
                "",
                terceira.secao,
                terceira.cor,
                pagina,
            ],
        ]

    if quantidade == 4:
        primeira, segunda, terceira, quarta = ligacoes
        return [
            [
                primeiro,
                "",
                primeira.tag,
                primeira.term,
                segunda.tag,
                segunda.term,
                _junta(primeira.secao, segunda.secao),
                _junta(primeira.cor, segunda.cor),
                pagina,
            ],
            [
                primeiro,
                "",
                terceira.tag,
                terceira.term,
                quarta.tag,
                quarta.term,
                _junta(terceira.secao, quarta.secao),
                _junta(terceira.cor, quarta.cor),
                pagina,
            ],
        ]

    # O `UBound(lig) > 4` do original: a linha de erro com o texto 784.
    return [[terminal_, "", "Erro: Conexões>4", "", "", "", "", "", pagina]]


RELATORIO = RelatorioFiacao()
