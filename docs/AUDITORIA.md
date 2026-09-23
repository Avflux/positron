# Auditoria de cobertura — o reverso do Eletron4Z × o recoder positron

**Data:** 2026-09-23 · **Pergunta auditada:** *o reverso inteiro está coberto e só restou UI e lógica de UI?*

## Resposta curta

**Não.** O que está coberto é o **recorte** — as correções e a limpeza do CAD (frente 2), a base/contexto (frente 1) e os três pipelines —, e o que está **mapeado** são os **216 comandos** do reverso (todos classificados). O que **não** está coberto é a **lógica por trás dos formulários** (49% do código do reverso) nem a pilha de exportação/importação, as rotinas destrutivas e a integração de ambiente/licença.

## 1. O inventário de comandos: completo

Varredura do decompilado (2026-09-23):

| arquivo | comandos |
|---|---|
| `Comandos.cs` | 177 |
| `Correcao.cs` | 24 |
| `clsUtilitarios.cs` | 7 |
| `clsTrocaEditaBlocos.cs` | 5 |
| `clsCloud.cs`, `clsEletron.cs`, `clsEletrosul.cs` | 1 cada |
| **total** | **216** (sem repetição) |

Cruzamento com o §7.6 do `docs/PLANO.md`: **209 dos 216** nomes apareciam citados; os **7 que faltavam** (`APAGARXDATA`, `PesquisaBlocos`, `LeAtributos`, `LeTodosAtributos`, `CorrigeAtributos`, `CorrigeAtributosSemMsg`, `PreencheNovosAtributos`) foram **acrescentados na linha da frente 2** nesta auditoria — estavam classificados no RUNBOOK, mas não nomeados na tabela.

**Cobertura dos 216 por situação:**

| situação | quantidade |
|---|---|
| **implementados** no recoder (nomes do reverso) | **39** |
| classificados como **só UI** (o comando abre um formulário) | **68** |
| **interativos/navegação** (ponto, seleção, jig, URL, páginas) | **28** |
| **destrutivos com confirmação** (`MsgBox`): `DELFIPROJ`, `DELLM`, `DELPLA` | **3** |
| **arquivo/ambiente**: `CHVAUT`, `SYNCLP`, `LXLS`, `PortasChesf`, `IMPBD` | **5** |
| **cobertos pela substância** de outro comando ou pela projeção: `LAYELN`, `LAYELS`, `RECRIACABOS`, `SYNCC` | **4** |
| comandos **próprios** do recoder (sem par): `ELETCFG`, `INDCABO`, `VERIF`, `ELETREL`, `ELETCMP`, `SobeLm`, `pzDiag`, `pzDiagCriar`, `ApagaERROS` | 9 (fora dos 216) |

> As somas por frente estão nas linhas do §7.6 (triagens das rodadas 105, 106, 110 e 112).

## 2. O tamanho do que não está coberto

Medição de linhas (decompilado limpo × recoder):

| | arquivos | linhas |
|---|---|---|
| **reverso — total** | 358 | **408.392** |
| · `frm*` (formulários) | 127 | **199.355** (49%) |
| · `cls*` (lógica) | 57 | **107.003** (26%) |
| · outros (entidades, acesso a dados, modelos) | 174 | **102.034** (25%) |
| **recoder — produto** (`Positron.Data` + `Positron.Plugin`) | 138 | **23.533** (≈6% do reverso) |
| **recoder — testes** (`Positron.Data.Tests`) | 64 | 8.537 |

Ou seja: o recoder é **≈23,5 mil linhas** contra **408 mil** do reverso. Mesmo descontando os formulários (que são apresentação), a **lógica** do reverso (`cls*`, 107 mil linhas) está coberta em **≈22%** — o resto é a lógica das funcionalidades que o recorte não pediu (edição de bornes, definição de réguas, máscaras/portas/contatos, materiais, exportação/importação).

## 3. O que exatamente ficou de fora (por tipo)

1. **Lógica de UI** (o maior bloco): os **199 mil linhas** dos 127 formulários e as classes que eles orquestram. Um formulário não é "só tela": `frmPortas`, `frmMascara`, `frmBornes`, `frmDefinicao`, `frmContatosAux` etc. carregam regras de edição que **não** foram portadas — só portamos as correções que o `VERIF` cobra.
2. **Pilha de exportação/importação e manipulação de projeto** (frente 9): o §7.6 estima **≈5.800 linhas** em `clsExportImport` + `cDadosAccessExpImp` + `clsImportarProjetos` + `cDadosAccessImportarProj` — nenhuma linha portada.
3. **Rotinas destrutivas com confirmação** (`DELFIPROJ`, `DELLM`, `DELPLA`): não portadas de propósito (dependem de resposta humana no `MsgBox`; o harness roda comandos sem ninguém para responder).
4. **Interação pura** (`EncontraHandle`, `REGH`/`REGV`, `HBASE`, `LDNR`/`OCPN`, `INDV`, `VEIA1/2`, `VEAUT`, `BLI`, `DEPARA`, `LDAT`/`PINC`, `CON`/`CONAUT`/`DERAUT`, `CriaJigCloud`, `AJUDA`, …): o valor é o clique; as regras que dão para isolar já entraram quando fizeram parte do recorte.
5. **Ambiente/licença e arquivo externo** (`IMPBD`, `LXLS`, `PortasChesf`, `CHVAUT`, `SYNCLP`).
6. **Integrações que só existem com a UI**: a barra de progresso (`_uscPagina`), o `PointMonitorToolTips`, o *ribbon*, a troca de usuário.

## 4. O que está coberto, e com que evidência

- **Frente 1** (base/contexto) portada; **`SYNCD`** virou o pipeline do original (rodada 107).
- **Frente 2** (correções e limpeza): **27 de 38** entregues, com medição no desenho real; os 11 restantes são UI/página/interação/destrutivo, classificados um a um.
- **Frente 3**: o candidato em lote (estatística de bornes) entregue como `STATBORN` (108).
- **Frente 7**: o pipeline das veias `SYNCV` (111) e o `RECRIACABOS` (115).
- **Frente 9**: `CBD` (112), `RESTPROJ` e `ApagaERROS` (113).
- **Ferramentas**: `pzDiag` (103) e a prova do `IndefineUmaPorta` em C# (104).
- **Verificação**: `npm run plugin:test` (**514**), `npm run plugin:build`, `npm run plugin:build:autocad` e a medição no ZWCAD 2026 (sempre a partir de cópia limpa).

## 5. Conclusão

- **Inventário:** ✅ os **216** comandos estão varridos e classificados (com a correção dos 7 nomes nesta auditoria).
- **Recorte em lote:** ✅ fechado — correções, limpeza, pipelines e ferramentas, com medição.
- **Reverso inteiro:** ❌ **não** está coberto. O que falta não é "só UI": é a **lógica das funcionalidades de edição** que vive atrás dos formulários (a maior parte das 107 mil linhas de `cls*`), a pilha de exportação/importação (≈5,8 mil linhas), as rotinas destrutivas e as integrações de ambiente.

**Próximo passo honesto, se o objetivo for cobrir o reverso inteiro:** escolher uma funcionalidade de UI por vez (ex.: edição de bornes do `frmBornes`, definição de réguas do `frmDefinicao`) e portar a **regra** dela para o `Positron.Data` com testes, deixando a tela de fora — é o mesmo método das 42 rodadas, aplicado a um alvo que ainda não foi tocado.
