# Interligação (`INTERLIGACAO`) — veias indefinidas

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.
Layout do XData: `InterligacaoXData` (`cad-plugin/Positron.Data/Interligacao/`).

## Veia indefinida

`NumVeia == -1000`. Duas rotinas carregam as veias indefinidas do desenho, com regras parecidas
mas **não iguais** (rodada 177):

| | `carregaApenasAsVeiasIndefinidasDoCaderno` | `carregaTodasAsVeiasIndefinidasDoCaderno` (`clsEditarInterligacao.cs:950`) |
|---|---|---|
| quem usa | `ESTVL` (`EstimativaDeVeiasLivres`) | `PESQC` (`VeiasIndefinidasDoCaderno`) |
| filtro | fora: `Painel1 == 0 && Painel2 > 0 && Tipo != 3` | o mesmo |
| tipo 3 só com painel 2 | — | painel 2 vai para o painel 1 (`:1093`) |
| tipo 2 sem painel 1 | painel 1 = `Painel2` da apontada | o mesmo **e** o handle da veia passa a ser o da apontada (`:1113`) |
| tipo 2 sem painel 2 | painel 2 = `Painel2` da apontada | o mesmo |
| ordem | painel 1 desc., painel 2 asc. | bubble sort de três trocas em sequência: página em decimal; mesma página (texto, sem caixa) → Y maior antes; mesmo Y → X menor antes (`:1144`) |

- A "apontada" é a polyline do `ilig.handle` (`Geral.HandleToObject`), lida com qualquer `NumVeia`.
- X/Y = `Bounds.MinPoint` arredondado (`Math.Round`, par mais próximo).
- O primeiro laço da rotina (`:1007`) monta um array (`GjFnBTpYJ2jOTH3qRap`) que **nunca é usado**.
- `1` e `001` têm o mesmo decimal mas não são "a mesma página" para o desempate por Y/X.

## A tela `frmPesquisaVeiasIndefinidas` (`PESQC`)

- Construtor (`frmPesquisaVeiasIndefinidas.cs:163`): o `Geral.ExisteForm` procura
  `"frmPesquisaVeiasIndefinidas "` **com espaço no fim** — nunca acha, a tela abre de novo a cada
  `PESQC`. Sem arquivo cadastrado (`arqAtivo.Indice == 0`): mMensagem 331
  `Este arquivo ainda não foi cadastrado no banco do projeto!`. Título = mMensagem 568.
- Grade (`:201`): `#` (1..n), página, `BuscaNomeDoPainel(menor)`, `BuscaNomeDoPainel(maior)`, handle
  oculto; `"???"` vira `" "`. Larguras 10/30/30/30% de `Width - 4` (ou `- 21` com barra vertical).
- `KeyUp`/`MouseUp` da grade → `wkpp6H6CivH` (`:279`): `clsBlocos.Unhighlight` (tira o realce das
  entidades do layer da página ativa, `clsBlocos.cs:1952`), `SetFocus` no desenho e, para a linha
  selecionada, `clsInterligacao.AtivaUmaHighlightZoom` (`clsInterligacao.cs:3682`): `AtivaPagina(layer)`,
  atalho da paleta, `Caderno.ZEntity(id, 20)` e `Highlight()`.
- Apelidos: `wkpp6H6CivH` = ir até a veia selecionada; `Otfp6h0f11R` = `Resize` → `AtualizaDGVeiasDWG`;
  `haG8HN1M755FJ2bc2NW.ARP1IVj2So` = a grade tem barra vertical visível.
