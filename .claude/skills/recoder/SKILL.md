---
name: recoder
description: Roda uma rodada do recoder do plugin CAD (Eletron4Z → cad-plugin/positron) — extrai do reverso tudo o que o comportamento original faz, replica no recoder com prova medida e registra o feito e o que falta em docs/recoder/. Use quando pedirem "próxima rodada", "porta o comando X", "replica a tela Y do reverso", "continua o recoder", ou qualquer trabalho de portar algo do reverso para o plugin.
---

# Rodada do recoder

Uma **rodada** = um alvo do reverso portado de ponta a ponta = **um commit**. Vá direto ao ponto:
não pergunte o que dá para descobrir no repo; pare para perguntar **só** no que é decisão do dono
(lista em `docs/recoder/ESTADO.md` → *Depende do dono*).

## 0. Onde fica cada coisa

| o quê | onde |
|---|---|
| **estado + fila** (lê primeiro, sempre) | `docs/recoder/ESTADO.md` |
| uma rodada = um arquivo (a partir da 176) | `docs/recoder/rodadas/NNN-slug.md` (modelo em `modelo-rodada.md` desta skill) |
| fatos do reverso já descobertos, por tema | `docs/recoder/conhecimento/` (índice no `README.md` de lá) |
| o reverso decompilado (VB.NET → C#) | `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/` |
| visão geral do reverso | `cad-plugin/reverso/Eletron4_ZWcad/ARQUITETURA.md` |
| comando → classe/método/tela | `docs/reverso-comandos.txt` · telas: `docs/reverso-formularios.txt` · barra: `docs/reverso-barra-do-original.txt` · capturas: `docs/reverso-capturas.txt` + `cad-plugin/reverso/captura_das_janelas/*.png` |
| projeto real para medir | `cad-plugin/reverso/Teste_projeto_real/` (`Funcional.dwg`, `RCD.mdb`; bibliotecas reais em `libs\` — Formato, Layout, Máscaras, Simbologia) |
| textos exatos (`mMensagem[1, n]`) | `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Mensagens-PT.txt` (`n=texto`) e `Mensagens.txt` (PT+EN) |
| o que o original guarda fora do desenho | `decompiled-cleaned/Eletron4.My/MySettings.cs` (`Cor`, `Secao`, `LicMode`…) e o registro `HKCU\Software\Cadgraph\Eletron4` (`Idioma`, `Altern`…) — grep `Registry` no decompilado |
| modelos que o original usa | `Eletron4_ZWcad/BD Projeto/` (banco novo), `Formatos/` (17 DWG de folha), `MODELOS/` (Excel dos relatórios), `LP/`, `Blocos/*.rar` |
| layout das telas | `decompiled-cleaned/Eletron4.frm*.resx` (28) + o designer no `.cs` + a captura |
| receitas de build/CAD/armadilhas | `docs/RUNBOOK.md` (seções de operação e *Troubleshooting*) |
| histórico até a rodada 175 (só leitura) | `docs/PLANO.md` §5 e §7 (triagem), seções "Rodada N" do `RUNBOOK.md` — **não acrescente mais nada lá** |

Use `grep` nesses arquivos grandes; não leia o `PLANO.md`/`RUNBOOK.md` inteiros.

## Regra de ouro: nada sem prova no reverso

Todo controle, coluna, rótulo, texto, item de menu, dica, valor padrão, chave gravada (arquivo, registro,
XData, banco) e comportamento do plugin precisa de **prova no reverso**: `arquivo:linha` do decompilado,
`.resx`, `Mensagens-PT.txt` ou captura `.png`. **O que não tiver prova não entra** — nem "extra útil", nem
rodapé, nem tooltip, nem chave nova de `.ini`, nem texto de desenvolvimento na tela. Se a medição precisa
de algo que o original não tem, fica **só no harness** (variáveis `POSITRON_*`, nunca gravadas em arquivo
nem mostradas em tela). Em 2026-10-15 o dono achou configuração, paleta de folhas e projeto ativo
inventados — ver *Correção do básico* no `ESTADO.md`.

## 1. Escolher o alvo

1. Leia `docs/recoder/ESTADO.md`. O alvo é o que o usuário nomeou ou, sem nome, o **item 1 da fila**.
2. Se o alvo é um comando/tela, rode `powershell -ExecutionPolicy Bypass -File scripts/cobertura-do-reverso.ps1`
   (e `-Listas`/`-Acoplamento` se ajudar) para confirmar que ainda falta.
3. `grep -n "<alvo>" docs/PLANO.md docs/recoder/` — se já houve triagem ("fora do recorte", "ambiente",
   "decisão do dono"), respeite-a ou registre por que mudou.
4. **Se o alvo envolve tela/janela:** **sempre verificar se a janela já foi ajustada** antes de qualquer alteração (`grep -rn "<frmJanela>" docs/recoder/rodadas/ docs/recoder/ESTADO.md docs/PLANO.md`, `git log --grep="<frmJanela>"`). Identifique o que já foi entregue para não refazer trabalho nem desfazer correções anteriores.

## 2. Extrair o máximo do reverso (antes de escrever código)

Objetivo: entender o comportamento original **inteiro**, até as folhas, para replicar inclusive o
que parece estranho.

1. **Ponto de entrada:** `docs/reverso-comandos.txt` dá a classe/método do `[CommandMethod]`.
2. **Cadeia completa:** siga cada chamada até as folhas (API do CAD, SQL, XData, arquivo). Nomes
   ofuscados (`ltZUHdAX7R`, `iaGppGHMjAT`…) — resolva lendo o corpo e registre o apelido.
   Para cadeias largas, dispare subagentes `Explore` em paralelo, um por ramo.
3. **Inventarie, com `arquivo:linha` do reverso**, tudo que o alvo toca:
   - entradas: seleção, prompts, `Conf.*`/`DeclaracoesGeral.*`, variáveis de ambiente, ini;
   - XData (app name + layout de cada valor), dicionários/`Xrecord` (`CENG_*`, `MASCARAS`…), layers, blocos/atributos;
   - SQL: tabelas, colunas, ordem, transação;
   - mensagens ao usuário (texto exato — `MensagensDoReverso.cs`), `MsgBox`, ramos de cancelamento;
   - ramos condicionais (`switch` de layout/cliente: Eletrosul, CEMIG, Furnas…) e valores mágicos;
   - efeitos colaterais (o que mais ele apaga, recria, ativa).
4. **Se há tela/janela (conferir se estão conforme no recode e reverso):**
   - **Verificar se já foi ajustada:** confirme no histórico (`docs/recoder/rodadas/`, `docs/recoder/ESTADO.md`, `docs/reverso-capturas.txt` e commits) se a janela já foi ajustada antes e qual foi o escopo.
   - **Referência original:** confira a captura real em `cad-plugin/reverso/captura_das_janelas` (`C:\Users\rno\Desktop\APPs\positron\cad-plugin\reverso\captura_das_janelas\*.png`) cruzando com o mapeamento em `docs/reverso-capturas.txt`, o designer no `.cs` e o `.resx`.
   - **Conferência no recode:** inspecione a janela correspondente reconstruída no recode/plugin (via comando `JANELA` / `POSITRON_JANELA=<janela>` ou renderizador) e compare **controle a controle** com a captura do reverso (títulos, textos de carga `mMensagem`, abas, ordem/visibilidade/largura das colunas em grades, botões, ícones, estados habilitado/desabilitado).
   - Liste as diferenças na ficha da rodada antes de escrever o código.
5. Confira `docs/recoder/conhecimento/` antes de redescobrir; **todo fato novo e reutilizável vai
   para lá** (ver §5).
6. Escreva a **ficha** (seção *O que o reverso faz* do modelo) já no arquivo da rodada, antes do código.

## 3. Replicar

- **Regra pura em `cad-plugin/Positron.Data/<Área>/`** (testável sem CAD); **casca CAD em
  `cad-plugin/Positron.Plugin/`** (comando, leitura/gravação do desenho, tela).
- **Ajuste de janelas/telas:** sempre verificar se a janela já foi ajustada antes de mexer. Qualquer ajuste deve garantir que as janelas fiquem estritamente conforme no recode e reverso (`cad-plugin/reverso/captura_das_janelas`), preservando correções consolidadas.
- Procure antes o que já existe (`grep` por app name, dicionário, tabela): estenda o tipo dono,
  não duplique leitor de XData/dicionário.
- Nomes e comentários seguem o código ao redor (português, cita `Classe.Metodo` do reverso).
- Replique o comportamento observado; desvio do original só com motivo escrito na rodada.
- **Escrita no desenho vinda de paleta ou janela não modal: sempre `LockDocument`** (o original trava em cada
  rotina). Erro e aviso chegam ao usuário como no original (`MsgBox`, prompt), **nunca** engolidos numa
  propriedade ou só no log.
- O projeto ativo é **do desenho** (XData `EletronProj`/`Config`, índice do DWG pela tabela `DWG`), refeito a
  cada troca de documento — nunca de um arquivo global da máquina.
- O que ficar fora: **anote com o motivo** e mande para a fila — nunca deixe silencioso.
- Comando novo: atualizar a tabela de comandos do `cad-plugin/README.md`.

## 4. Provar (nada é "feito" sem número)

Rode e copie os números para a rodada:

1. `npm run plugin:test` — confira que o **total > 0** (falso verde conhecido: ver *RUNBOOK →
   `npm run plugin:test` sai 0 sem rodar teste nenhum* e use o console do xunit). Testes novos para a regra pura.
2. `npm run plugin:build:zwcad` **e** `npm run plugin:build:autocad` — 0 avisos, 0 erros.
3. Se toca o desenho: medir no CAD (`npm run cad:projeto` / `cad:projeto:acad`, ou o harness com
   fixture `scripts/cad-fixture-*.lsp`) no `Funcional.dwg` e colar a linha de resumo do comando.
   **E provar pelo caminho do usuário real**, não só pelo comando digitado: o botão/paleta/menu que o
   usuário clica (fora de comando = sem lock automático), um **desenho novo** sem XData e a **troca de
   documento**. O que não der para automatizar vai para *Falta* como conferência do dono, com o passo a passo.
   ZWCAD é instância única: feche antes. AutoCAD: `scripts/instala-bundle.ps1 -Cad AutoCAD` após o build.
4. **Se toca tela/janela:** conferir visualmente se a janela no recode está conforme a captura correspondente em `cad-plugin/reverso/captura_das_janelas/*.png` e validar que ajustes anteriores permanecem íntegros.
5. Se mexeu em cobertura: rodar de novo `scripts/cobertura-do-reverso.ps1` e anotar os números.

Se algo não pôde ser medido (CAD indisponível etc.), escreva **"não medido: motivo"** — não maquie.

## 5. Registrar (sempre, mesmo em rodada parcial ou abortada)

1. **`docs/recoder/rodadas/NNN-slug.md`** — copie `modelo-rodada.md` desta skill; NNN = última
   rodada + 1 (ver `ESTADO.md`). Todas as seções preenchidas; *Falta* vazio só se nada faltar.
2. **`docs/recoder/ESTADO.md`** — atualize **só**: os números do *Estado*, a linha da rodada em
   *Últimas rodadas* (mantenha as 10 mais novas), e a *Fila* (risque/remova o item feito; inclua o
   que a rodada deixou em *Falta*, na posição de prioridade). Nada de narrativa ali.
3. **`docs/recoder/conhecimento/<tema>.md`** — fatos do reverso descobertos (formato de XData,
   dicionário, quirk), com `arquivo:linha`; acrescente o tema no índice se for novo.
4. Armadilha de **operação** (build, CAD, harness) → seção em *Troubleshooting* do `RUNBOOK.md`.
5. **Commit** único da rodada: `tipo(area): resumo curto (rodada NNN)` — ex.:
   `feat(paginas): cadeia do CAD completa com TrocaColunas (rodada 175)`. Inclui código, testes e docs.
   Commit só se o usuário pediu commits nesta sessão ou no fluxo do projeto; senão, deixe pronto e avise.
   O hash ainda não existe ao escrever: use `*(este)*` na rodada e no `ESTADO.md`, e a **rodada
   seguinte** troca pelo hash real (sem commit extra só para isso).

## 6. Resposta ao usuário

Curta: alvo, o que foi replicado, a prova (números), o que ficou em *Falta* e o próximo item da fila.
