# Auditoria de cobertura — o reverso do Eletron4Z × o recoder positron

**Data:** 2026-09-23 · **Pergunta auditada:** *o reverso inteiro está coberto e só restou UI e lógica de UI?*

## Resposta curta

**Não.** O que está coberto é o **recorte** — as correções e a limpeza do CAD (frente 2), a base/contexto (frente 1) e os três pipelines —, e o que está **mapeado** são os **216 comandos** do reverso (todos classificados). O que **não** está coberto é a **lógica por trás dos formulários** (49% do código do reverso) nem a pilha de exportação/importação, as rotinas destrutivas e a integração de ambiente/licença.

## 0. Estado medido agora — o que falta, em ordem (rodadas 132–133)

Esta seção responde à pergunta recorrente *"o que já cobrimos e o que falta"* **com número medido no
próprio repo**, e não com memória: o `scripts/cobertura-do-reverso.ps1` cruza o mapa dos 216 comandos
(`docs/reverso-comandos.txt`) com os `[CommandMethod]` do plugin (separando os **escritos à mão** dos
**99 gerados** da rodada 128) e com as **127** telas do decompilado. Os números do §1 são de
2026-09-23; estes são de hoje.

```
powershell -ExecutionPolicy Bypass -File scripts/cobertura-do-reverso.ps1              # o painel
powershell -ExecutionPolicy Bypass -File scripts/cobertura-do-reverso.ps1 -Listas    # + as listas nominais
powershell -ExecutionPolicy Bypass -File scripts/cobertura-do-reverso.ps1 -Acoplamento  # + quanto do
    # ambiente do original cada corpo carrega (o termometro de "traduzir 1:1 ou virar regra")
```

| | valor medido |
|---|---|
| comandos do reverso | **216** |
| deles, abrem alguma janela / são regra de desenho pura | **121** / **95** |
| telas `frm*` | **127** |
| comandos que o plugin responde | **152** = **53 escritos à mão** (40 do reverso + 13 nossos) + **99 gerados** (só abrem a tela) |
| comandos do reverso **sem nada no plugin** | **77** = **17** que abrem janela (15 variantes + `IMPBD` + `ONSPL`/`TROCAPN`) + **60** de regra pura |
| telas alcançadas por algum comando | **103** (5 com regra escrita à mão, 98 só casca) |
| telas que **nenhum** comando abre (sub-janela: relatórios DWG/Excel, editores) | **19** |
| telas sem comando e sem casca pelo nome (variante/splash) | **5** |

**Os "60 sem tela e sem nada no plugin" não são 60 regras faltando:** a triagem do §7.6 já dividiu
cada um (só UI, interativo, destrutivo, ambiente ou substância coberta sob outro nome). O que sobra de
**regra em lote de verdade** está na **frente 2**, e é pouca coisa: dos **38** comandos dela, **30**
estão entregues (contra os 27 do estado anterior, entraram `RENPAGA`, `APAGARXDATA` e `PesquisaBlocos`)
e dos **8** que sobram **7 são regra de desenho** — o outro, `CorrigeJanelas`, é **ambiente** (mexe nas
janelas do CAD, não no desenho):

| comando | no reverso | corpo | veredito (medido na rodada 132) |
|---|---|---|---|
| `RENPAGA` | `Correcao.cs:3273` | 52 linhas | **regra já portada** (`PaginasDoCaderno`, rodadas 125/129) — falta só **registrar o nome do comando** |
| `APAGARXDATA` | `Comandos.cs:1372` | 5 linhas | **entregue** (rodada 127, medido no `Funcional.dwg`) |
| `PesquisaBlocos` | `Correcao.cs:2050` | 8 linhas | **entregue**: é só UI, e o gerado da rodada 128 abre o `frmNavegador` pelo nome |
| `CorrigeJanelas` | `Correcao.cs:1083` | 5 linhas | **ambiente**: `Geral.moveFormOrigem()` mexe nas janelas do CAD, não no desenho |
| `EncontraHandle` | `clsUtilitarios.cs:950` | 74 linhas | **candidato**: pede um handle no `Editor` e navega até o objeto |
| `CorrigeInterligacao` | `clsUtilitarios.cs:611` | 216 linhas | **candidato grande**: varre as polylines de interligação, descobre o painel de **cada ponta** (`verificaDispInterlig`) e regrava `Painel1`/`Painel2` no XData — a leitura/gravação desse XData e a barra de progresso da paleta **já existem** (rodadas 60 e 121) |
| `LeAtributos` · `LeTodosAtributos` · `CorrigeAtributos` · `CorrigeAtributosSemMsg` · `PreencheNovosAtributos` | `clsTrocaEditaBlocos.cs:18/171/141/267/278` | 122+95+29+10+21 = **277 linhas** | **candidato recomendado**: é um fluxo **grade → buffer → desenho**; o recorte o deixou de fora (nota no `CorrecaoDosBlocosMirror`) **porque não havia tela** — e a tela existe desde a rodada 127; ler/gravar atributo de bloco já é padrão no plugin (10 adaptadores usam `AttributeReference` e 5 já gravam) |

**Os próximos passos, em ordem de valor por custo:**

1. **A família dos atributos (5 comandos, 277 linhas)** — é exatamente o formato que a interface
   acabou de ficar pronta para receber: a regra pura (o buffer e **quais** atributos trocar) no
   `Positron.Data`, a tela e **uma ligação** no `LigacoesDasTelas`. O bloqueio registrado no recorte
   ("sem a tela não há o que aplicar") **caiu**.
2. **`CorrigeInterligacao` (216 linhas)** — fecha o laço do `VERIF` na interligação por **página
   inteira** (o `INDCABO` conserta os trechos escolhidos): o `Painel1`/`Painel2` que o comando conserta
   é o mesmo campo que a projeção do `INT` já lê e grava.
3. **Ligar as três telas de compilação** — `frmCompilarFiacao`, `frmCompilarInterligacao` e
   `frmCompilarJumperExt` **já têm a regra** (os pipelines `FIA`/`INT`/`JMP`, medidos): a tela traz
   `btAnalisar` (rodar), `dgERROS` (os erros que o `VERIF` já calcula) e `dgRevisao`; o `btApagar`
   (apagar a compilação da revisão) é **destrutivo** e entra desabilitado com o motivo, como o menu das
   folhas.
4. **Trivial, e some da lista:** registrar o **nome `RENPAGA`** para a regra que já existe.

### Por que a regra não vem pronta do decompilado (e o que vem)

O que é **declaração** já é pegado do reverso por script: as 127 telas com os 3431 campos, a barra (9
painéis / 121 botões), os textos (`mMensagem`), os ícones e os **99 comandos** já gerados daí (rodada 128: só abrem a
tela) — no original, **164 dos 216** comandos têm corpo de **8 linhas ou menos**, ou seja, o comando é, na
prática, só montar a tela. O que **não** vem é a **regra**: no decompilado ela chega acoplada ao ambiente do original.

| marca (`-Acoplamento`) | ocorrências no decompilado | comandos que carregam |
|---|---|---|
| runtime VB (`Conversions.` / `Operators.`) | **22.195** | 31 |
| estado global (`DeclaracoesGeral.`) | **12.089** | 48 |
| banco Access/MDB (`cDados*`) | **2.215** | 11 |
| `Interaction.MsgBox` (trava um script — não há quem clique) | **655** | 13 |
| hardlock/licença | **274** | 5 |
| `Editor` do CAD (`.GetPoint` = 16 + a assinatura `Editor editor` = 115): exige o editor e, no `GetPoint`, alguém para responder | **131** | 6 |

O recoder roda em `net472` dentro do CAD, com **SQLite** e sem `MsgBox`: traduzir 1:1 traria o runtime
VB, o Access, o clique e a licença junto. E o decompilador **não devolve a intenção** — às vezes mente:
foi assim com o campo `RenomearPáginasToolStripMenuItem` cujo texto é **"Renumerar Páginas"**, com o
corpo que abre com guarda e "não abria janela", e com os "2 launchers" que são **1**. Os três foram
pegos por medição, não por leitura automática.

Por isso a divisão é deliberada: **do reverso vem a declaração; a regra é reescrita** (regra pura no
`Positron.Data` + teste + adapter que fala com o desenho). O `-Acoplamento` do script mostra, **por
comando**, quanto de ambiente o corpo carrega, com os totais acima — é o termômetro para achar onde a tradução é
quase 1:1 (entre os pendentes que ele lista, o `LeAtributos`, de 122 linhas, é o único que só toca
`Conversions`/`DeclaracoesGeral`) e onde tem de virar regra.

**O que continua fora, decidido (não é pendência):** as **15 variantes** de tela (o argumento da
construção), a **frente 11** (ambiente/licença — `RESETLIC`/`TCHAVE`/`TUSING`), os **3 destrutivos com
`MsgBox`** (`DELFIPROJ`, `DELLM`, `DELPLA`) e as **19 sub-janelas** de relatórios DWG/Excel — a pilha de
exportação (≈5.800 linhas), que sai pelo app (§7.3).

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
- **Frente 2** (correções e limpeza): **30 de 38** entregues, com medição no desenho real; dos **8** que sobram, **7 são regra de desenho** (a fila está no §0, com `arquivo:linha` e custo) e o `CorrigeJanelas` é **ambiente** (mexe nas janelas do CAD, não no desenho).
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
