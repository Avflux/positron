# Rodada 185 — Unidade e Alternativo pelo menu da paleta

**Data:** 2026-10-15 · **Commit:** *(este)* · **Frente:** correção do básico, item 3 · **Situação:** 🟡 parcial

## Alvo

Recorte do item 1 da fila: substituir o diálogo inventado de Editar Unidade/Alternativo pelos
prompts do CAD e aplicar em todas as linhas selecionadas. Critérios: nenhuma seleção = nenhuma
pergunta/gravação (sem fallback para página ativa); prompt com espaços e valor padrão da primeira
linha de SelectedRows; Escape não altera nada; resposta ToUpper().Trim(); preserva o outro campo
de cada linha e a multiseleção; Alternativo recalcula CONT/FL/TOT e atualiza a tela. Sem dependência,
comando ou configuração novos. As demais pendências da 183/184 continuam explicitamente fora.

## O que o reverso faz

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

- **Entrada / cadeia:** `uscPaginas.cs:2054-2094` (`bt6p1Bww9xD`, Editar Unidade) e
  `:2096-2135` (`T5Qp1VoBCME`, Editar Alternativo): sem SelectedRows retorna; foco no desenho,
  PromptStringOptions, AllowSpaces=true, DefaultValue da célula 1/2 de SelectedRows[0],
  UseDefaultValue=true; Editor.GetString. Só PromptStatus.OK (5100) prossegue.
- **Lê:** páginas e ambos os campos das linhas selecionadas; não usa página ativa como fallback.
  Mensagens 15/16 (`../Mensagens-PT.txt:16-17`): `Informe o novo valor de Unidade: ` e
  `Informe o novo valor do Nome Alternativo:`. Acrescenta newline e espaço no prompt.
- **Grava / efeitos:** resposta ToUpper().Trim(), uma chamada de
  `XDataGeral.AlteraXDataUnidadeAlternativo` por linha, preservando a outra célula; atualiza só
  a célula editada. Recarrega/ordena matriz, não chama CarregaPG nem desliga multiseleção.
  Alternativo também chama `Pagina.AtualizaContTotFl` e `Application.UpdateScreen`.
- **Folha CAD:** `XDataGeral.cs:1243-1325`: LockDocument e transação por layer; Eletron/Unidade,
  índices 2 e 3 são unidade/alternativo. Sem XData cria a marca. Com marca Unidade altera os dois
  valores e conserva o resto do buffer. Exceções voltam para MsgBox crítico nos handlers.
- **Ramos e quirks:** o menu **não limita Alternativo a 20**; a validação de 20 pertence à edição
  inline (`uscPaginas.cs:1831-1851`). Enter aceita o padrão; cancelamento não grava.
- **Apelidos:** `bt6p1Bww9xD` = Editar Unidade; `T5Qp1VoBCME` = Editar Alternativo;
  `hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF` = foco na janela (P/Invoke user32, ver conhecimento).

### Diferenças antes de editar

O recoder abre FormularioDeCampoDaPagina modal com OK/Cancelar e título de página, só edita uma
página, tem fallback à ativa e recarrega a paleta (perdendo multiseleção). Não normaliza a resposta
nem recalcula campos ao editar Alternativo pelo menu. O adapter de XData existente já usa lock.

## O que foi feito

| arquivo | o quê |
|---|---|
| `Positron.Data/Paginas/UnidadeDaPaginaXData.cs` | normalização pura da resposta do menu, sem impor limite inline |
| `Positron.Data/Interface/MensagensDoReverso.cs` | mensagens exatas 15 e 16 |
| `Positron.Data.Tests/UnidadeDaPaginaTests.cs` | +6 casos (espaços, caixa, vazio/null, >20) |
| `Positron.Plugin/Interface/Folhas/FormularioDaPagina.cs` | remove o Form inventado; PerguntaDeCampoDaPagina usa SetFocus/GetString e harness existente |
| `Positron.Plugin/Interface/Folhas/FolhasControle.cs` | handlers compartilham seleção capturada, aplicam a cada linha e preservam outro campo/multiseleção; sem fallback ativa; Alternativo recalcula e UpdateScreen |
| `Positron.Plugin/Interface/Folhas/ProvaDaPaleta.cs` | ações campos/core e campos-interface/Timer: menus reais, cancelamento/padrão nativos, campos e páginas não selecionadas relidos |

Guarda deliberada: se o documento ativo mudar durante o prompt, não aplica a seleção antiga ao
novo documento. Não se recria cache mPaginas: os leitores existentes consultam o desenho.
O adapter existente é reutilizado com LockDocument; não foi reimplementado nesta rodada.

## Prova

- `npm run plugin:test`: **0 testes**, falha conhecida do adaptador VSTest; não é passe.
  Console xUnit 2.9.2 em `%TEMP%/pm185`, bin completo: **953 (+6)**, Errors **0**, Failed **0**,
  Skipped **0**; repetição final **3,511 s**.
- Builds finais ZWCAD / AutoCAD: **0 avisos, 0 erros**, **1,53 s / 1,71 s**. Verificação de tipos C#
  incluída nas duas compilações contra as APIs reais. `git diff --check` sem erros.
- Cobertura inicial/final: **78** manuais, **115** gerados, **48** ausentes, **21** telas ligadas;
  **126/161** acionáveis da barra. Nenhum comando/tela novo.
- AutoCAD 2020 core, cópia do Funcional.dwg: ação `campos` pelo **PerformClick dos menus**, respostas
  só do harness; páginas 2 e 6 gravadas, demais 14 conservadas; preferência Alternativo ligada pelo
  próprio menu e devolvida ao estado original. Execução final core anterior ao último ajuste do
  ramo vazio do harness; este ramo foi medido depois na GUI final.

```text
CAMPOS185: PASSOU — menu; 2 páginas; demais 14 preservadas; caixa/espaços; Alternativo >20; seleção/ativa preservadas; sem seleção não grava; nativo=False
```

- AutoCAD 2020 **GUI visível**, DLL final isolada `C:/positron-smoke/r185`, cópia `pz185-gui.dwg`:
  Timer WinForms executa os menus reais **fora de comando**; WScript.SendKeys responde ao
  **Editor.GetString real** (sem POSITRON_UNIDADE/ALTERNATIVO). Escape não grava; nova resposta com
  espaços é normalizada; Enter mantém padrão; Alternativo de **49 caracteres** não é truncado.
  Não houve mouse físico nem auditoria visual nova nesta rodada.
- Leitura **independente AutoLISP entget** confirmou em ambos os layers Eletron/Unidade =
  `UNIDADE COM ESPACOS 185`, `NOME ALTERNATIVO COM MAIS DE VINTE CARACTERES 185`.
  Quatro sentinelas DBText criados por entmake antes do ensaio (índices 5/6/7/9 com OBSOLETO185)
  recalculados: **5=6**, **6=2**, **7=1000**, **9=nome alternativo completo**; portanto o menu
  efetivamente alcançou CONT/FL/TOT/Alternativo, não só o XData do layer.

```text
CAMPOS185: PASSOU — menu; 2 páginas; demais 14 preservadas; caixa/espaços; Alternativo >20; seleção/ativa preservadas; sem seleção não grava; nativo=True
CONT/FL/TOT/ALTERNATIVO: 4 sentinelas conferidos via entget
CAMPOS185: PASSOU — desenho sem páginas; menu ausente; nenhuma pergunta/gravação.
RETORNO=pz185-gui.dwg
CAD_PROCESSOS=0
EXIT=0
```

- Novo Drawing1.dwg: ModelSpace vazio antes do ensaio; tipo V, paleta sem menu, chamadas diretas
  dos dois handlers sem seleção retornam sem perguntar/gravar. Retorno MDI ao projeto confirmado
  por COM em chamada separada. Não se repetiu a edição completa após retornar.
- Provas preservadas em `docs/recoder/provas/185-campos/`: `gui-plugin.log`, `xdata.txt`,
  `campos.txt`, `host.txt`, `core.log`. Cópia e desenho novo fechados sem salvar; original intocado;
  processo final acad.exe **exit 0**, nenhum acad/accoreconsole restante. Bundle AutoCAD instalado
  após build final; autoload não retestado (a prova usou NETLOAD isolado).
- Falhas do instrumento mantidas explícitas: primeira prova core/GUI tentou PerformClick de
  Editar Alternativo oculto e falhou; harness corrigido para ligar a preferência pelo menu.
  Segunda GUI aprovou os prompts mas o ramo de desenho novo tentou usar ContextMenuStrip nulo
  (tipo V); corrigido para verificar menu ausente e chamar handlers sem seleção. Ambos os builds
  e suíte repetidos após esse ajuste; terceira GUI confirmou os dois ramos finais.
  Script externo da terceira GUI expirou procurando `desenho sem páginas` por acento corrompido
  do .ps1 UTF-8 lido pelo Windows PowerShell; o log UTF-8 do plugin contém **PASSOU** nesse ramo.
  Retorno/fechamento foram completados separadamente, sem transformar o timeout em passe.
  Primeiro Quit separado recebeu RPC_E_CALL_REJECTED; segunda chamada completou e o host saiu 0.
  Isso não resolve a causa dos exits anômalos de 183/184 (primeira tentativa desta rodada também
  terminou com 48151230); apenas registra uma saída normal medida na DLL final.

## Falta

- [ ] Demais recortes da 183/184: Excel ativo; renumerar lote/inline/combo; conexões/progresso;
  título 4/D/A/V/atalhos; rollback/sem formato/colunas/configuração e saída anômala do host.
- [ ] ZWCAD ausente nesta máquina (medido; a ausência é uma medição com data: `RUNBOOK.md` → *Existe CAD nesta máquina?*); repetir prompts/menu fora de comando nesse host.
- [ ] Repetir edição completa depois do retorno MDI (o retorno nesta rodada foi confirmado por COM).
- [ ] Auditar extensões/marcas diferentes no XData Eletron: o adapter preexistente recria quatro
  valores, enquanto AlteraXDataUnidadeAlternativo conserva o buffer e só altera marca Unidade.
  Fixture real/ensaio desta rodada não adicionaram extensões; não alegar esse ramo coberto.

## Conhecimento registrado

`conhecimento/paginas.md`: prompts do menu, seleção real/sem fallback, caixa/Trim, preservação,
sem limite de 20 e recálculo do Alternativo; foco SetFocus resolvido no ofuscado.
