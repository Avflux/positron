# Rodada 178 — `PESQCAB`: pesquisa de cabos e veias, tela ligada

**Data:** 2026-10-15 · **Commit:** `e3c69237` · **Frente:** 7 — interligação, cabos e veias · **Situação:** ✅ completa

## Alvo

Item 1 da fila do `ESTADO.md`. O primeiro da lista, `frmTrocarChave` (`TCHAVE`), é **licença**:
fora de escopo por decisão do dono (`PLANO.md` §7.5, triagem da frente 11). Saiu da fila sem código.
O seguinte é `frmPesquisaCabos` (`PESQCAB`, 512 linhas), triado como "só UI" na rodada 110. A tela
não grava nada, mas lê o catálogo `Veias` do banco com regras próprias e navega até a veia.

## O que o reverso faz

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

- **Entrada / cadeia:** `PESQCAB` → `Comandos.cs:944` → `new frmPesquisaCabos()` (`frmPesquisaCabos.cs:227`, não modal) →
  `CDadosAccessInterligacao.LeCabosVeiasUsadasCaderno` (`:674`) → `LeCabosTodosCabos` (`:791`) →
  `CarregaTodasCabosDoCadernoNoDG` (`frmPesquisaCabos.cs:287`) → `LeCabosVeiasUsadasOutrosCaderno` (`:837`) →
  `LeCabosVeiasTodos` (`:4319`). Clique num cabo → `MI1pvipBDIv` → `CarregaTodasAsVeiasDoCadernoNoDG` (`:345`)
  → `ClsCabos.OrdenaVeias` (`ClsCabos.cs:1208`). Clique numa veia → `vp1pvC6nLi1`, o mesmo código do `PESQC`
  (`Unhighlight` + `AtivaUmaHighlightZoom`).
- **Lê (SQL):**
  - `SELECT DISTINCT(Tag) FROM Veias WHERE Arquivo=@arquivo ORDER BY Tag`, e depois `List.Sort()` (cultura corrente);
  - `SELECT DISTINCT(Tag) FROM Veias WHERE Arquivo>0`, menos as do caderno (`List.Contains`), `Sort()`;
  - para cada tag: `SELECT Tag, Indice, Nome_Veia, Handle, Pagina[, Arquivo, Funcao] FROM veias WHERE Tag=@tag ORDER BY Indice`, **de todos os arquivos**;
  - `SELECT Indice, Nome FROM DWG`: o nome do caderno de cada veia.
- **Grade de cabos:** `Nome do Cabo` (mMensagem 1238) e `Tipo` oculto (o `bCor`). Primeiro os cabos deste DWG;
  se houver cabos de outros, a linha `CABOS DE OUTROS CADERNOS` (1638 em maiúsculas, `LightCoral`) e os de
  outros cadernos (`LightGray`).
- **Grade de veias** (Índice 915 oculto, Veias 1239, Página 772, Handle e Ordena ocultos): as veias do cabo em
  todos os DWGs. O texto é o nome, ou o índice quando não há nome. Cabo deste caderno: a página e o
  handle. Cabo de outro: `caderno-página` (só a página se o DWG não tem nome) e o handle vazio.
- **`OrdenaVeias`:** a veia 1 com `P`/`T` no nome define pares/ternas. `-99` vira 0; abaixo de -50 soma 50.
  Com pares/ternas, cada negativo `-n` vira `n·2+0,1` / `n·3+0,1`, ou seja, a blindagem vai logo depois do
  seu par ou terna. Em seguida vem um bubble sort crescente e as cores: índice 0/-99 = `LightBlue`; os outros
  alternam `LightGoldenrodYellow`/`LightGray` quando a primeira letra muda ou quando o nome é número.
- **Grava / efeitos:** nada no banco nem no desenho. O clique na veia ativa a página, dá zoom e realça; a
  linha sem handle perde a seleção.
- **Ramos e quirks (mantidos):**
  - Um cabo deste caderno mostra também as veias que estão em outros DWGs, **com o handle delas**. O
    clique tenta ir até um handle que pode não ser deste desenho; o `HandleToID` falha e não acontece nada.
  - O `PJ5p6TFIbHs` usado pela grade de veias é o do **último** `LeCabosVeiasTodos`, não o da primeira carga.
- **Mensagens:** 580 `Pesquisar Cabos e Veias` (título), 331 `Este arquivo ainda não foi cadastrado no banco do projeto!`
  (sem DWG: a tela não abre), 1284 `O Projeto não possui Cabos` (sem veias: a tela fecha).
- **Apelidos de ofuscados:** `MI1pvipBDIv` = carrega as veias do cabo selecionado; `vp1pvC6nLi1` = ir até a veia;
  `FdhpvYAGGd3` = `Resize`; `JBgaA5p5W7h1TRpQ5uHE` = par (índice, nome) do DWG.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Data/Interligacao/PesquisaDeCabos.cs` | regra pura: `Cabos` (as duas listas e o cabeçalho), `VeiasDoCabo` e o `OrdenaVeias` com as cores |
| `cad-plugin/Positron.Data/ProjectStore.cs` | `LerNomesDeDwgs` (`SELECT Indice, Nome FROM DWG`) |
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmPesquisaCabos.cs` (+1 linha em `LigacoesDasTelas`) | a tela ligada: as duas grades, as cores, os cliques |
| `cad-plugin/Positron.Plugin/Interface/Telas/IrAteAVeiaDaGrade.cs` | o "ir até a veia" (o código comum ao `PESQC` e ao `PESQCAB`), extraído da ligação do `PESQC` |
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmPesquisaVeiasIndefinidas.cs` | usa o `IrAteAVeiaDaGrade`; ganha o teste do DWG cadastrado (mMensagem 331) |
| `cad-plugin/Positron.Plugin/Interface/Telas/RenderizadorDeTelas.cs` | a ligação pode descartar a janela (o `MsgBox` + "não abre" do construtor do original) |
| `cad-plugin/Positron.Data.Tests/PesquisaDeCabosTests.cs` | +9 testes |
| `cad-plugin/README.md` | linha `PESQCAB` |

**Correção da rodada 177:** lá escrevi que o recoder não tem o `arqAtivo.Indice`, mas tem: é o
`ConfiguracaoPositron.Dwg` (`POSITRON_DWG`). O `PESQC` agora também não abre com DWG 0, como no original.

**Desvios do original:**
- Os `MsgBox` 331/1284 viram linhas de comando. A janela é descartada antes de aparecer (a 1284 aparece e
  fecha no original), então o efeito é o mesmo.
- Sem banco configurado, a tela não abre (no original, o `clsAuxiliar.BancoValido()` também barra).

## Prova

- `plugin:test`: **893** (+9), total conferido > 0.
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- Cobertura: telas com ligação 17 → **18**; o resto sem mudança (o `PESQCAB` já tinha comando gerado e botão coberto).
- **ZWCAD 2026, `Funcional.dwg` (cópia), banco do e2e, DWG 63** (`-Comandos "PESQCAB,PESQC"`):

```
PESQCAB: 18 cabo(s) deste DWG (63) e 679 de outros cadernos na grade; 2388 veia(s) no catálogo.
PESQCAB: cabo "8-CCE-001" — 1 veia(s): 1@8 [4DD25].
PESQCAB: "Pesquisar Cabos e Veias" (frmPesquisaCabos) aberta no CAD — 9 controle(s).
PESQC: 0 veia(s) indefinida(s) na grade.
```

Conferido por SQL no mesmo banco: 18 tags distintas com `Arquivo=63` e 679 com `Arquivo>0` fora delas;
`8-CCE-001` tem uma veia, índice 1, página 8, handle `4DD25`. O clique num cabo não é scriptável (janela
não modal); a regra que ele chama foi rodada direto da `Positron.Data.dll` sobre o mesmo banco:

```
8-GGE-017 (outro=False): -99/BL@[]=0:Blindagem; 0/BL@[]=0:Blindagem; 1/1@19[4DDC7]=1:Escura; 2/2@19[4DDC5]=2:Clara
7SA6000 (outro=True): -99/BL@[]=0:Blindagem; 0/BL@[]=0:Blindagem; 1/1@18[]=1:Escura; 2/2@18[]=2:Clara; ...
```

A tabela `DWG` desse banco está vazia (o cadastro de DWGs é decisão do dono), então as páginas de outros
cadernos saem sem o nome do caderno.

- AutoCAD: **não medido** nesta rodada — e a justificativa dela **estava errada**: o **AutoCAD 2020 está instalado** (**verificado em 2026-10-16** por registro + pastas + `where`; `C:\Program Files\Autodesk\AutoCAD 2020`). Ausência de CAD é uma **medição, com data** (`RUNBOOK.md` → *Existe CAD nesta máquina?*). O recorte segue **não medido** no AutoCAD; a build compila.

## Falta

- [ ] Conferência visual das duas grades e dos cliques com mouse: dono.
- [ ] Nome do caderno nas veias de outros DWGs: depende do cadastro de DWGs (decisão do dono).
- [ ] Medir no AutoCAD (**instalado** — verificado em 2026-10-16, ao contrário do que esta rodada afirmou).

## Conhecimento registrado

`docs/recoder/conhecimento/interligacao.md`: seção da tela `PESQCAB` (as consultas, o `OrdenaVeias`, os
quirks e os apelidos); a seção do `PESQC` foi corrigida (o DWG cadastrado existe no recoder).
