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
| projeto real para medir | `cad-plugin/reverso/Teste_projeto_real/` (`Funcional.dwg`, `RCD.mdb`) |
| receitas de build/CAD/armadilhas | `docs/RUNBOOK.md` (seções de operação e *Troubleshooting*) |
| histórico até a rodada 175 (só leitura) | `docs/PLANO.md` §5 e §7 (triagem), seções "Rodada N" do `RUNBOOK.md` — **não acrescente mais nada lá** |

Use `grep` nesses arquivos grandes; não leia o `PLANO.md`/`RUNBOOK.md` inteiros.

## 1. Escolher o alvo

1. Leia `docs/recoder/ESTADO.md`. O alvo é o que o usuário nomeou ou, sem nome, o **item 1 da fila**.
2. Se o alvo é um comando/tela, rode `powershell -ExecutionPolicy Bypass -File scripts/cobertura-do-reverso.ps1`
   (e `-Listas`/`-Acoplamento` se ajudar) para confirmar que ainda falta.
3. `grep -n "<alvo>" docs/PLANO.md docs/recoder/` — se já houve triagem ("fora do recorte", "ambiente",
   "decisão do dono"), respeite-a ou registre por que mudou.

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
4. Se há tela: `.resx` + captura `.png` (controles, rótulos, ordem das colunas, o que fica desabilitado).
5. Confira `docs/recoder/conhecimento/` antes de redescobrir; **todo fato novo e reutilizável vai
   para lá** (ver §5).
6. Escreva a **ficha** (seção *O que o reverso faz* do modelo) já no arquivo da rodada, antes do código.

## 3. Replicar

- **Regra pura em `cad-plugin/Positron.Data/<Área>/`** (testável sem CAD); **casca CAD em
  `cad-plugin/Positron.Plugin/`** (comando, leitura/gravação do desenho, tela).
- Procure antes o que já existe (`grep` por app name, dicionário, tabela): estenda o tipo dono,
  não duplique leitor de XData/dicionário.
- Nomes e comentários seguem o código ao redor (português, cita `Classe.Metodo` do reverso).
- Replique o comportamento observado; desvio do original só com motivo escrito na rodada.
- O que ficar fora: **anote com o motivo** e mande para a fila — nunca deixe silencioso.
- Comando novo: atualizar a tabela de comandos do `cad-plugin/README.md`.

## 4. Provar (nada é "feito" sem número)

Rode e copie os números para a rodada:

1. `npm run plugin:test` — confira que o **total > 0** (falso verde conhecido: ver *RUNBOOK →
   `npm run plugin:test` sai 0 sem rodar teste nenhum* e use o console do xunit). Testes novos para a regra pura.
2. `npm run plugin:build:zwcad` **e** `npm run plugin:build:autocad` — 0 avisos, 0 erros.
3. Se toca o desenho: medir no CAD (`npm run cad:projeto` / `cad:projeto:acad`, ou o harness com
   fixture `scripts/cad-fixture-*.lsp`) no `Funcional.dwg` e colar a linha de resumo do comando.
   ZWCAD é instância única: feche antes. AutoCAD: `scripts/instala-bundle.ps1 -Cad AutoCAD` após o build.
4. Se mexeu em cobertura: rodar de novo `scripts/cobertura-do-reverso.ps1` e anotar os números.

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
