# Relatório consolidado — o recoder do Eletron4Z sobre o positron

**Data:** 2026-09-23 · **Sequência:** rodadas 74–115 (42 rodadas de entrega, uma por commit duplo)
**Estado:** **recorte em lote fechado** — frente 2 entregue (27 de 38, sem pendência de
implementação ou de prova), **frentes 1–9 todas portadas ou triadas sem candidato em aberto** e os
**três pipelines** do original entregues (`SYNCD`, `SYNCV` e `RESTPROJ`) · **48 comandos**, **514
testes**, duas builds com 0 avisos.

Este relatório é a leitura única do que existe, do que foi **medido no desenho real** e do que
ficou **fora do recorte com motivo**. O detalhe rodada a rodada está no `docs/RUNBOOK.md` (mais
novo primeiro) e o registro completo no `docs/PLANO.md` (§2.2 e a tabela de rodadas).

---

## 1. O que é

- **Original:** Eletron4Z, plugin CAD (ZWCAD 2026) para projetos elétricos industriais, lido a
  partir do reverso em ..\Elet\Eletron4_ZWcad\decompiled-cleaned\Eletron4\ — **216 nomes de
  comando** inventariados (177 no Comandos.cs, 24 no Correcao.cs, 15 nos utilitários).
- **Recoder:** positron, com o plugin em cad-plugin/ — Positron.Data (regras puras + testes
  xunit), Positron.Plugin (I/O do CAD) e Positron.CadStub (o AutoCAD sem o CAD real).
- **Desenho de referência:** ..\Elet\Teste_projeto_real\Funcional.dwg (DWG 63) — sempre usado a
  partir de **cópia limpa** (o harness nunca muta o original).
- **Recorte do plano:** frente 1 (base/contexto e comandos portados) e frente 2 (correções e
  limpeza), mais o SobeLm próprio; as frentes 3–9 são o checklist exaustivo do §7.6, **todas
triadas** (105, 106, 110 e 112).

## 2. Entregas por frente

| # | Frente | Situação |
|---|---|---|
| 1 | Base/contexto (ELET, FIA, INT, VERIF, CFG, …) | ✅ portada; o SYNCD virou o **pipeline** do original (rodada 107) |
| 2 | Correções e limpeza do CAD | ✅ **27 de 38** entregues, **sem pendência**; os 11 restantes são UI/página/interação |
| 3 | Réguas e bornes | 8 UI + 5 interativos + **STATBORN em lote** (rodada 108) |
| 4 | Dispositivos, máscaras, portas e contatos | triada: **20 UI + 8 interativos/por arquivo**, nenhum em lote |
| 5 | Caderno/circuitos/páginas | triada: 16 UI/interativos + `SYNCC` (já coberto pela projeção `FIA`) |
| 6 | Fiação | triada: 3 UI + `DELFIPROJ` (destrutivo com confirmação) |
| 7 | Interligação, cabos e veias | triada: 33 UI/interativos/portados + **`SYNCV`** (111) e **`RECRIACABOS`** (115) |
| 8 | Materiais | triada: 2 UI + `DELLM` (destrutivo) |
| 9 | Exportar/importar e manipulação de projeto | triada: 15 UI/ambiente/destrutivo + **`CBD`** (112) e **`RESTPROJ`** + `ApagaERROS` (113) |

## 3. Evidências medidas no desenho real (amostra das registradas)

| rodada | o que entrou | medida no Funcional.dwg |
|---|---|---|
| 84 | REMLAYDUP | 340 → **326** registros (14 chaves); o último registro de cada chave é sempre descartado |
| 85 | CorrigeBlocosContatosAux | **63 de 63** pares casados, 0 alterados |
| 87 / 100 | corrigePortas | **45 de 45** blocos de porta, **240** portas no dicionário; depois do NOME1/ORIGEM: **9 atributos** regravados na 1ª chamada e **0** na 2ª (idempotência) |
| 88 / 103 | CorrigeCoresDosBlocos | 44 nomes e **197** atributos de definição; **50 diferenças** — todas no bloco MascaraM.DWG (o quirk do nome) |
| 92 | Limpahandle | 365 conexões, **167 derivações**, 167 handles zerados |
| 93–94 | ApagaBlocosMirror | 557 blocos, 521 com XData, **0** espelhados; a fixture prova o caminho de apagar |
| 96 | CorrigePainelET1DosBornes | **199 de 199** bornes casaram uma régua (31 no dicionário), 0 alterados |
| 97 | CorrigeCabos | 0 Funcao vazias nas duas tabelas e **697** linhas tocadas pelo Alarme (sonda independente em Python confirma) |
| 98 | CorrigeHandleSuperior | **167 de 167** derivações acharam vizinho e foram regravadas |
| 101 / 104 | IndefineUmaPorta | provado ponta a ponta: PORTA;E;9;5;;;NOME-ANTIGO;7;PT1;EFC-ANTIGO → PORTA;E;9;0;;;;?;; |
| 103 | pzDiag (ferramenta C#) | 45 portas, **1834** referências de cor e **50** diferenças — as mesmas 50 da rodada 88 |
| 107 | SYNCD (pipeline) | FIA: 494 linhas (199 bornes, 191 dispositivos, 83 posições); INT: 20 linhas, **697 cabos**, **2388 veias** |
| 108 | STATBORN | **31 réguas**, 199 usados, 17 de reserva, **216 no total** |
| 111 | SYNCV (pipeline das veias) | 24 rótulos apagados e 20 reinseridos; a projeção repete os números do `SYNCD`; 0 de 0 opcionais |
| 112 | CBD (compactar o banco) | **584 KB → 572 KB** (12 KB liberados) — o `VACUUM` sobre uma cópia do banco |
| 113 | RESTPROJ (pipeline-mãe) | seis passos no desenho real; `ApagaERROS` varreu **3286 entidades** e apagou 0 (a cópia é limpa); os números repetem as rodadas 107/111 — **terceira testemunha** |
| 115 | RECRIACABOS (pelo layout) | `layout 0 (Eletron)`: 24 rótulos apagados e 20 reinseridos de 20 trechos (305 cabos singelos no catálogo) — o branch do Eletrosul fica coberto pelo teste da regra e pela medição da rodada 79 |

**Corroborações cruzadas** (o mesmo número por caminhos independentes): os **199 bornes** aparecem no
FIA/SYNCD e no STATBORN; os **216** aparecem no Bornes4I e no total do STATBORN; as **50 diferenças
de cor** aparecem no comando (rodada 88) e na ferramenta pzDiag (rodada 103); as **31 réguas**
aparecem no dicionário medido na rodada 96 e na estatística da 108.

## 4. Quirks e convenções medidas

- **ZWCAD é instância única:** as medições encadeiam numa mesma passada; passadas separadas nunca
  provam convergência — as idempotencias foram medidas com **duas chamadas do mesmo comando**.
- **entget com app não registrado aborta o load:** a lista de nomes de XData precisa vir filtrada
  por tblsearch.
- **A linha de comando depois do NETLOAD não executa no desenho real** (rodadas 90/91): os
  contadores passaram a rodar **no load**.
- **O harness sempre parte de cópia limpa** do DWG: antes/depois só cabem na mesma passada — foi o
  que motivou o modo **acrescentar** do pzDiag.
- **A via LISP é o gargalo das evidências** (rodadas 90/91/102/104): contador sem saída, rastro
  parando em 0 load, parênteses. A saída foi a **ferramenta em C#** (pzDiag/STATBORN).
- **Edições silenciosas:** duas edições de código reportaram sucesso e não persistiram (o modo
  acrescentar do pzDiag e o registro do pzDiagCriar). A regra que ficou: **conferir o efeito**, não
  o retorno da ferramenta.
- **Quirks de dados:** o REMLAYDUP descarta o último registro de cada chave; o
  CorrigeCoresDosBlocos compara o nome cru contra a lista em maiúsculas (o bloco MascaraM.DWG fica
  fora da cobertura); a coluna DWG não existe em Veias (usa Arquivo); o leitor tipado de contatos
  **recalcula a orientação**, o que obrigou o caminho de escrita a usar o **registro cru**.
- **SYNCD do original é um pipeline** (seis passos), não uma projeção — descoberto na triagem da
  frente 4 e implementado na 107.
- **pzDiagCriar não era executado** porque o registro **não persistiu** (rodada 104); corrigido na 108.

## 5. Fora do recorte, com motivo

| família | exemplos | por quê |
|---|---|---|
| UI/WinForms | DEF, GERRB, BORN, EDBORN, SELBORN, MBOR, CLOBORN, PN, GERCONT, GERMASC, DISP, PORT, CONT, MASC, EDTDISPS*, EDTFUNC, MIGPOR, MCONT, MMASC, LAYMEC, PLAQ, TPG, ATPG, PesquisaBlocos, APAGARXDATA, CorrigeJanelas | o comando é a tela; a regra já está portada quando há regra |
| Páginas / interativo | RENPAGA, CorrigeInterligacao, REGH, REGV, HBASE, LDNR, OCPN, EncontraHandle | dependem da matriz de páginas, de formulário de captura, de GetPoint ou da seleção de **um** bloco |
| Arquivo/ambiente | CHVAUT, SYNCLP, LXLS, PortasChesf | exigem a "lista de pontos" num arquivo externo ou abrem processo de terceiro |
| Atributos por grade | LeAtributos, CorrigeAtributos*, PreencheNovosAtributos | o buffer estático é preenchido por uma grade WinForms |
| Materiais e projeto (frentes 8 e 9) | GERLM, ATINDEP, DELLM, EXPCOMP, CLONAR, EXPPDF, COPIAINT, EXPDWG, EXPIT, IMPR, TROCTT, COPYCAD, TROCBL, TROCAPN, MUDAUSER, IMPCAD, IMPBD, DELPLA | 15 são formulários; os demais são destrutivos com `MsgBox` de confirmação (`DELLM`, `DELPLA`) ou de ambiente/arquivo (`IMPBD`) |

## 6. Como verificar

```powershell
npm run plugin:test          # 511 testes xunit (net472) do Positron.Data
npm run plugin:build         # ZWCAD 2026 (API real)
npm run plugin:build:autocad # AutoCAD (Positron.CadStub)
```

Medição no desenho real (sempre a partir de cópia limpa; o harness recebe o DWG e o banco):

```powershell
$env:POSITRON_DIAG = "$env:TEMPpositron-diag.txt"
powershell -ExecutionPolicy Bypass -File scripts/cad-zwcad-smoke.ps1 -Dwg 63 -Revisao R0 -Comandos "pzDiag,SYNCD,STATBORN" -Desenho "..\Elet\Teste_projeto_real\Funcional.dwg" -Banco "$env:TEMP\positron-limpeza.db"
```

## 7. Pendências

- **De implementação: nenhuma.** Todas as pendências registradas das rodadas 86, 87 e 101 foram
  fechadas (99, 100, 101/104) e o contador da cor caiu na rodada 103.
- **De ferramenta: nenhuma aberta.** O contador LISP foi substituído pelo pzDiag; a prova do
  IndefineUmaPorta saiu em C# (104) e o pzDiagCriar foi registrado de novo (108).
- **Do plano (o que resta):** as frentes 3–9 são editoras de UI/interação/arquivo/materiais; os
  candidatos de lote que as triagens revelaram — `STATBORN` (108), `SYNCV` (111), `CBD` (112) e
  `RESTPROJ`/`ApagaERROS` (113) — foram **todos entregues**. Fica em aberto só o `RECRIACABOS`
  (o `MsgBox` + o `switch` do `InterligacaoLayout`, com a substância já portada em 78/79).
- **O que resta no mapa:** nada em lote — o recorte está **fechado** (a última ponta, o
  `RECRIACABOS`, caiu na 115). O que sobra são editores de tela, integração de ambiente/licença e
  as rotinas destrutivas com confirmação (`DELFIPROJ`, `DELLM`, `DELPLA`), que dependem de resposta
  humana no `MsgBox` — o harness roda os comandos sem ninguém para responder.
- **Limites de evidência registrados:** o branch do **Eletrosul** do `RECRIACABOS` (o harness não
  repassa `POSITRON_INTERLIGACAO_LAYOUT` ao plugin, que o recebe pelo `.scr`) e o caminho do
  **`IndefineUmaPorta`** em desenho real, provado em C# na 104.

## 8. A sequência, em blocos

| rodadas | o que foi |
|---|---|
| 74–79 | base e contexto: SobeLm, as duas telas do VERIF, os primeiros Corrige*/limpezas |
| 80–88 | interligação, cabos, opcionais, textos LP, layout, contatos, modelos, portas e cores — cada um com regra pura, adapter, comando, fixture/contador e medição |
| 89–91 | evidência: as 50 diferenças de cor isoladas e a lição do tblsearch |
| 92–98 | limpeza/derivações, mirror, textos das ligações, bornes/painel, cabos e o resolvedor por ponto |
| 99–104 | fecho das pendências: dicionário de contatos, NOME1/ORIGEM, prefixo/sufixo, a ferramenta C# e a prova do IndefineUmaPorta |
| 105–106 | triagem das frentes 3 e 4 |
| 107–108 | o SYNCD como pipeline e o STATBORN em lote |
| 109 | o relatório consolidado (este arquivo) |
| 110–112 | triagem das frentes 5–9, o `SYNCV` como pipeline e o `CBD` (compactar o banco) |
| 113 | o `RESTPROJ` (pipeline-mãe) e o `ApagaERROS` |
| 114 | este relatório, atualizado até a rodada 113 |
| 115 | o `RECRIACABOS` pelo layout — a última ponta do mapa |
