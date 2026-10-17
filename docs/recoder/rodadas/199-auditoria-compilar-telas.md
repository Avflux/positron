# Rodada 199 — auditoria das telas de compilação `frmCompilarJumperExt`/`Interligacao`/`Fiacao` (item 5 da correção do básico, 12ª–14ª telas)

**Data:** 2026-10-16 · **Commit:** `*(este)*` · **Frente:** correção do básico · **Situação:** 🟡 parcial (14 telas auditadas)

## Alvo

Item 5 do `ESTADO.md`. As três ligações herdam a mesma base (`LigacaoDeCompilacao.cs`), então uma auditoria cobre as três. Referência: `frmCompilarJumperExt.cs` (construtor `:461`, `formataDGRevisao :2422`, `CarregaDGRevisao :2453`, `formataDGErros :2479`, `btAnalisar :1595`); `frmCompilarFiacao.cs:599-631` e `frmCompilarInterligacao.cs:446-469` repetem o construtor com outras mensagens.

## O que o reverso faz

- Construtor: `BancoValido()`; DWG sem índice → `MsgBox` 331 (Information); `cbPreservar.Checked = true`; dicas: Analisar (Fiação 756 / Interligação 1400 / Jumper 1406), Apagar (757 "Apagar revisão"), Salvar (758 / 1401 / 1407); `btSalvar.Enabled = false`.
- `dgRevisao`: Revisão (752), Criador (753), Data (754), larguras 2/8, 2/8, 4/8 de (largura − 22), sem ordenação; linhas (revisão, criador, data); erro → `MessageBox` "Elétron" crítico.
- `dgERROS`: vazia e sem coluna ao abrir (`formataDGErros(false)`); depois do Analisar, a coluna "Erros" (755) com as páginas onde há bloco de erro.
- `btAnalisar`: revisão vazia → `MsgBox` 761 "Informe um número de revisão!" (Exclamation); revisão já existente → 762.
- `tbRevisao` abre vazio (`MaxLength 5` do designer).

Diferenças encontradas na base anterior: dicas inventadas (motivos de "desabilitado" no lugar das mMensagens); `tbRevisao` já aberto com a revisão da configuração e, vazio, o Analisar usava a da configuração em vez do 761; colunas da `dgRevisao` na ordem Revisão/Data/Criador e sem larguras; `dgERROS` abria já com os problemas; linha `COMPILAR:` na linha de comando e dos erros; sem a guarda do 331 e sem `cbPreservar` marcado; erros só na linha de comando.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDeCompilacao.cs` | guarda do 331, `cbPreservar` marcado, dicas pelas mMensagens (por tela: `DicaAnalisar`/`DicaSalvar`), `btSalvar` desabilitado, `dgRevisao` Revisão/Criador/Data com larguras 2/8·2/8·4/8, `dgERROS` vazia na abertura e com a coluna "Erros" só depois do Analisar, 761 para revisão vazia, erros em `MsgBox`; saem as linhas `COMPILAR:` e as dicas inventadas |
| `…/LigacaoDoFrmCompilarFiacao.cs`, `…Interligacao.cs`, `…JumperExt.cs` | as duas dicas de cada tela |

Desvios mantidos (já registrados no RUNBOOK): o Analisar do recoder roda o pipeline inteiro e grava (o original separa Analisar de Salvar, mensagem 762 para revisão existente) e a coluna "Erros" lista problemas em vez de páginas com bloco de erro. `btApagar` e `btApagarComp` ficam desabilitados (sem a regra portada). Harness: `POSITRON_ANALISAR=1` preenche o campo com a revisão da configuração.

## Prova

- `plugin:test`: não rodado: só casca; runner xUnit ausente. Última contagem: 975.
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- CAD: não medido: sem ZWCAD (medido; ausência = medição com data — ver RUNBOOK.md → *Existe CAD nesta máquina?*); telas não abertas. As linhas `COMPILAR:` só aparecem no RUNBOOK (receita antiga); nenhum script as lia.

## Falta

- [ ] Separar Analisar de Salvar como o original (762 revisão existente, `btSalvar` habilitado só depois, `cbPreservar` preservando a última revisão) — porte da regra das três compilações.
- [ ] `btApagar` (mMensagem 760, `RemoveRevisaoTabelaParaDWG`) e `btApagarComp` (blocos `ErroFiacao`).
- [ ] `dgEquip`/`tbPaineis` do `frmCompilarFiacao` (ficam como o designer).
- [ ] Atualizar a receita do RUNBOOK que cita as linhas `COMPILAR:`.
- [ ] Medir as três telas no AutoCAD (`POSITRON_JANELA` + `POSITRON_ANALISAR=1`).
- [ ] Auditar `frmGerenciador*`, `frmRelatorio_*`, `frmSplash`.

## Conhecimento registrado

Nenhum fato novo.
