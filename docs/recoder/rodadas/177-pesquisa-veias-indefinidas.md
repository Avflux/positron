# Rodada 177 — `PESQC`: pesquisa de veias indefinidas, tela ligada

**Data:** 2026-10-15 · **Commit:** `e4f19340` · **Frente:** 7 — interligação, cabos e veias · **Situação:** ✅ completa

## Alvo

Item 1 da fila do `ESTADO.md` ("telas só-casca mais baratas"), o primeiro da lista:
`frmPesquisaVeiasIndefinidas` (`PESQC`, 340 linhas). A triagem da rodada 110 a marcou como "só UI".
A tela não grava nada, mas carrega a grade com uma regra própria (`carregaTodasAsVeiasIndefinidasDoCaderno`)
e navega até a veia clicada.

## O que o reverso faz

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

- **Entrada / cadeia:** `PESQC` → `Comandos.cs:856` → `new frmPesquisaVeiasIndefinidas()` (`:163`, não modal) →
  `clsEditarInterligacao.carregaTodasAsVeiasIndefinidasDoCaderno` (`clsEditarInterligacao.cs:950`) →
  `CarregaTodasAsVeiasDoCadernoNoDG` (`:201`) → `Dicionario.BuscaNomeDoPainel` (`Dicionario.cs:47`).
  Clique/tecla na grade → `wkpp6H6CivH` (`:279`) → `clsBlocos.Unhighlight` (`clsBlocos.cs:1952`) →
  `clsInterligacao.AtivaUmaHighlightZoom` (`clsInterligacao.cs:3682`).
- **Lê:** `INTERLIGACAO` das `Polyline` do ModelSpace (todas as válidas), o layer e o `Bounds.MinPoint`;
  a polyline do `ilig.handle` no tipo 2; o cadastro `Paineis` para os nomes.
- **Filtro e preenchimento:** `NumVeia == -1000`, menos `Painel1 == 0 && Painel2 > 0 && Tipo != 3`.
  Tipo 3 só com painel 2: o 2 vai para o 1. Tipo 2 sem painel 1: painel 1 = `Painel2` da apontada
  **e o handle da veia passa a ser o da apontada**; sem painel 2: painel 2 = `Painel2` da apontada.
- **Ordem:** bubble sort com três trocas em sequência por par (página em decimal; mesma página →
  Y maior antes; mesmo Y → X menor antes). Detalhes em `conhecimento/interligacao.md`.
- **Grade:** `#` (1..n), Página (mMensagem 9), Origem (429), Destino (432), Handle (oculto); painéis
  em ordem (menor, maior), `"???"` → `" "`; larguras 10/30/30/30%.
- **Grava / efeitos:** nada no desenho. O clique ativa a página da veia, dá zoom (margem 20) e a realça;
  antes, tira o realce das entidades da página ativa.
- **Ramos e quirks:** o `ExisteForm` procura o nome com espaço no fim (a tela nunca é reaproveitada);
  o primeiro laço da carga monta um array que nunca é usado.
- **Mensagens:** 568 `Pesquisar Veias Indefinidas` (título), 331 `Este arquivo ainda não foi cadastrado no banco do projeto!`.
- **Apelidos de ofuscados:** `wkpp6H6CivH` = ir até a veia; `Otfp6h0f11R` = `Resize`;
  `haG8HN1M755FJ2bc2NW.ARP1IVj2So` = há barra vertical na grade.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Data/Interligacao/VeiasIndefinidasDoCaderno.cs` | regra pura: `Carregar` (filtro, tipo 2/3, bubble sort literal) e `LinhasDaGrade` |
| `cad-plugin/Positron.Plugin/Interligacao/InterligacaoDoDesenho.cs` | `LerComPosicao`: handle, layer e canto mínimo de cada trecho |
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmPesquisaVeiasIndefinidas.cs` (+1 linha em `LigacoesDasTelas`) | a tela ligada: grade, larguras, `KeyUp`/`MouseUp` → tirar realce, ativar página, zoom, realce |
| `cad-plugin/Positron.Data.Tests/VeiasIndefinidasDoCadernoTests.cs` | +8 testes |
| `scripts/cad-fixture-pesqc.lsp` | fixture com 7 interligações em 3 páginas (os ramos do filtro, tipo 2/3 e a ordem) |
| `cad-plugin/README.md` | linha `PESQC` |

Reaproveitado: `PaginaAtivaDoDesenho.Ativar`, `LocalizacaoPorHandleDoDesenho.Achar`/`DarZoom` (o `EncontraHandle`),
`PaginaNumerada.Decimal`, `DispositivoDaListaEdicao.NomeDoPainel`.

**Desvios do original:**
- ~~Sem o teste de "arquivo cadastrado" (mMensagem 331)~~: corrigido na rodada 178. O `arqAtivo.Indice` é o `ConfiguracaoPositron.Dwg`, e com DWG 0 a tela não abre.
- A tela é aberta pelo gerador de telas, que já evita duplicata — o quirk do `ExisteForm` com espaço não é reproduzido.
- A linha de resumo `PESQC:` na linha de comando, para o harness medir.

## Prova

- `plugin:test`: **884** (+8), total conferido > 0.
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- Cobertura: telas com ligação 16 → **17**; o resto sem mudança (o `PESQC` já tinha comando gerado e botão coberto).
- **ZWCAD 2026, `Funcional.dwg` (cópia):** o desenho não tem veia indefinida.

```
PESQC: 0 veia(s) indefinida(s) na grade.
```

Com o fixture e o banco do e2e (`-Fixture scripts/cad-fixture-pesqc.lsp -Banco %TEMP%\positron-projeto.db -Comandos PESQC`):

```
PESQC: 5 veia(s) indefinida(s) na grade: 3 TSA-3->TSA-3 [4DE79]; 12 PT1-220V->TSA-3 [4DE7B]; 12 TSA-3->CABANA SIT [4DE7A]; 12 PT1-220V->TSA-3 [4DE7C]; 12A ->QLEX-4 05L8/05L9 [4DE7D].
PESQC: "Pesquisar Veias Indefinidas" (frmPesquisaVeiasIndefinidas) aberta no CAD — 6 controle(s).
PESQC: veia 4DE7B na página "12" (zoom e realce).
```

Confere com o esperado do fixture: 5 de 7 (fora a definida e a ponta só com painel 2); a do tipo 2
aparece com o handle da apontada (`4DE79`, a primeira criada) e o painel 2 dela nos dois lados; na
página 12, o X menor antes no mesmo Y e o Y menor por último; a do tipo 3 vai com o 4 no painel 1
(origem em branco). A última linha é o `KeyUp` da grade (o Enter do harness move a seleção para a
2ª linha): ativação, zoom e realce rodaram no CAD.

- AutoCAD: **não medido** nesta rodada — e a justificativa dela **estava errada**: o **AutoCAD 2020 está instalado** (**verificado em 2026-10-16** por registro + pastas + `where`; `C:\Program Files\Autodesk\AutoCAD 2020`). Ausência de CAD é uma **medição, com data** (`RUNBOOK.md` → *Existe CAD nesta máquina?*). O recorte segue **não medido** no AutoCAD; a build compila.

## Falta

- [ ] Conferência visual do realce/zoom com clique de mouse: dono.
- [ ] Medir no AutoCAD (**instalado** — verificado em 2026-10-16, ao contrário do que esta rodada afirmou).

## Conhecimento registrado

`docs/recoder/conhecimento/interligacao.md` (novo): as duas cargas de veias indefinidas lado a lado,
a ordem do bubble sort, os quirks da tela `PESQC` e os apelidos.
