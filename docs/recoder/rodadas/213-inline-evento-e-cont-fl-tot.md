# Rodada 213 — edição inline da célula Página pelo evento real e o CONT/FL/TOT do rename

**Data:** 2026-10-16 · **Commit:** *(este)* · **Frente:** correção do básico, item 3 (paleta fiel) · **Situação:** 🟡 parcial

## Alvo

Item 1 da fila do `ESTADO.md` (fechar os recortes da rodada 183) — os **dois** recortes que a rodada
212 deixou declarados em *Falta* para a edição inline da célula Página:

1. a medição pelo **evento real** da grade (o `CellEndEdit` do WinForms) — a 212 provou que o método
   por trás dele faz o serviço, não que o evento em si funciona (o risco: o `Carregar()` reconstrói a
   grade **dentro** do evento);
2. o **CONT/FL/TOT** depois do rename — a chamada era a mesma já provada na 185, mas o valor
   recalculado nunca foi medido com sentinelas.

Sem regra nova no plugin: entram o caminho de prova no harness e a fixture, e a medição no CAD.

## O que o reverso faz

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

- **O evento é a entrada:** o `j9Sp1mKZkcD` está ligado em `dataGridView.CellEndEdit`
  (`uscPaginas.cs:220`, o `set` da propriedade `dg`) — o caminho é o **fim da edição** da célula, não
  uma chamada interna. No ramo da Página (`case 0`, `:1790-1844`) o handler reconstrói a grade
  (`Y9op1KgeRgW`) e reseleciona a ativa (`VSWp1ebyWra`) **dentro** do evento.
- **`renumerarPagina` (`Pagina.cs:1841`)** fecha com `OrdenaMatrizPaginas` e **`AtualizaContTotFl`** —
  é o passo que reescreve os campos `CONT`/`FL`/`TOT`/`ALTERNATIVO` das páginas depois do rename.
- **`AtualizaContTotFl`** (regra pura em `CamposDoFormato.TextoDoContTotFl`): o `switch` do índice do
  campo é **5 = CONT** (a próxima página válida), **6 = FL** (o nome do próprio layer), **7 = TOT** (a
  última página do caderno) e **9 = ALTERNATIVO** (o alternativo da página); o `REV` (8) **não** é
  tocado. Com o `ConfincluirColuna` em 3..5 o `CONT`/`TOT` trocam a página pelo alternativo dela.
- **O que o passo muda é só o texto:** o adapter escreve `DBText.TextString`; o XData do campo
  (`DiagLog`/`TituloPagina`, com o índice) fica como estava.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Plugin/Interface/Folhas/ProvaDaPaleta.cs` | ação `inline-evento`: põe a grade num formulário fora da tela, entra em edição (`BeginEdit`) e **confirma** (`EndEdit`) — o `CellEndEdit` real dispara e roda o mesmo `EditarCelula` do clique |
| `scripts/cad-fixture-inline-campos.lsp` | fixture opt-in que monta sentinelas `DBText` com o XData `DiagLog`/`TituloPagina` nos índices 5/6/7 e despeja os campos 5/6/7 de todos os layers de página (leitura independente, `entget`) |

Nenhum comportamento do plugin mudou; a ação nova só existe sob `POSITRON_FOLHA_ACAO=inline-evento`.

## Prova

- `npm run plugin:test`: **0 testes**, falha conhecida do adaptador VSTest (não é passe). Console
  xUnit 2.9.2 em `%TEMP%/pm213`, bin completo: **1020**, Errors **0**, Failed **0**, Skipped **0**;
  **3,970 s** (nenhum teste novo nesta rodada — não há regra nova).
- Builds finais ZWCAD / AutoCAD: **0 avisos, 0 erros**.
- **O evento real**, no AutoCAD 2020 `accoreconsole`, cópia do `Funcional.dwg`
  (`POSITRON_FOLHA_ACAO=inline-evento`, `POSITRON_FOLHA_INLINE=7A`, `POSITRON_PAGINA=7`):

```text
evento real (CellEndEdit): BeginEdit=True; EndEdit=True;
  edição inline "7A" na página 7 → Página: "7" → "7A"; 1 layer(s) renomeado(s).; célula="7A"
  grade depois: [1 | 2 | 6 | 7A | 8 | 15 | 16 | 17 | 18 | 19 | 20 | 21 | 22 | 23 | 24 | 1000]; tbPagina=7A
```

  O `Carregar()` que reconstrói a grade **dentro** do `CellEndEdit` não estourou: a linha caiu no
  ramo de sucesso, o layer foi renomeado e a grade voltou com o nome novo. É o risco que a 212 havia
  deixado em aberto.
- **CONT/FL/TOT**, com a fixture `scripts/cad-fixture-inline-campos.lsp` na **mesma** sessão do
  rename (três sentinelas no desenho; o dump é leitura independente do plugin):

| sentinela (antes) | layer | índice | depois |
|---|---|---|---|
| `SENTINELA-CONT-213` | `6` | 5 (CONT = próxima página) | **`7A`** |
| `SENTINELA-FL-213` | `7` | 6 (FL = o próprio layer) | **`7A`** |
| `SENTINELA-TOT-213` | `7` | 7 (TOT = última página) | **`1000`** |

```text
LAYER;6;existe   LAYER;7;ausente   LAYER;7A;existe
CAMPO;layer=7A;indice=7;texto=1000
CAMPO;layer=7A;indice=6;texto=7A
CAMPO;layer=6;indice=5;texto=7A
CAMPO;layer=1000;indice=6;texto=1000
```

  O dump foi rodado **sem** o rename (ensaio de controle) e as mesmas três sentinelas saíram com os
  textos montados (`SENTINELA-*`) nos layers `6`/`7`/`7` — a diferença acima é do `AtualizaContTotFl`.
  Os campos reais do `Funcional.dwg` (índice 6 nos layers `1`..`24` e `1000`) também aparecem, com o
  `FL` igual ao próprio layer: confere com a regra.
- **Não medido:** o **clique físico** (mouse e teclado) com a **paleta visível** — a sessão foi o
  `accoreconsole` (headless; a grade entrou em edição num formulário fora da tela, não na janela da
  paleta). **Não medido:** ZWCAD — **verificado** em 2026-10-16 (registro + pastas + `where`) que ele
  não está nesta máquina nesta data; o AutoCAD 2020, que o `RUNBOOK` dizia ausente, **está** instalado.

## Falta

- [ ] Clique físico com a **janela da paleta visível** (o `acad.exe` com interface cheia): o evento em
  si já está provado aqui; falta a conferência visual da célula e da grade na tela.
- [ ] Repetir no **ZWCAD** quando ele voltar a esta máquina (verificar antes de afirmar ausência —
  `RUNBOOK.md` → *Existe CAD nesta máquina?*).
- [ ] Restantes do item 1 da fila (a rodada 183): Excel ativo (`clsTextos.ExportaPaginas/ImportaTitulos`),
  o status do banco ligado ao contador de conexões (`statusBanco`/`DeclaracoesGeral.monitorConexao`), o
  progresso compartilhado pelas rotinas longas (`pbIniciar`/`pbPasso`/`pbFim` chamados por ~30 classes),
  o título 4/D/A/V e os seis atalhos em GUI, a **preservação das extensões no buffer `Eletron`**
  (`AlteraXDataUnidadeAlternativo` conserva o buffer; o adapter do recoder recria quatro valores) e a
  saída anômala do `acad.exe`.

## Conhecimento registrado

`conhecimento/paginas.md`: o que o `AtualizaContTotFl` escreve em cada índice (5/6/7/9) e que ele muda
só o `TextString`, deixando o XData do campo. `docs/RUNBOOK.md` (*Troubleshooting*): a receita de
levantar o **`CellEndEdit` real** no `accoreconsole` (formulário fora da tela) e o `\r` nos dumps
LISP que engana o `grep` por linha.
