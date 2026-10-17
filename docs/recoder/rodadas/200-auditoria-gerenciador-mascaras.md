# Rodada 200 — auditoria da `frmGerenciadorMascaras` (item 5 da correção do básico, 15ª tela)

**Data:** 2026-10-16 · **Commit:** `*(este)*` · **Frente:** correção do básico · **Situação:** 🟡 parcial (15 telas auditadas)

## Alvo

Item 5 do `ESTADO.md`; comando `GERMASC`. Sem outra passagem (grep em `docs/recoder/`). Captura: `gerenciador de máscaras.png`.

## O que o reverso faz

`frmGerenciadorMascaras.cs` (construtor `:1881`, `mostraModeloMascara :1981`, `yuSzcqjrTY`, `WXCz919CZj :3464`, `AtualizaColunasDGPortasMascara :2962`), `clsMascara.cs` (`carregaModelosDeMascaraNoDG :397`, `AtualizaColunasDGModelos :474`), `clsDispositivoMascaras.cs:543`.

- Construtor: `BancoValido()`; DWG sem índice → `MsgBox` 331; textos pelas mMensagens; dicas 661–663, 1126–1128, 668–670, 673, 1124, 1125, 1353, 1481, 1843; `tbBlocoTopografico`/`tbBlocoLayout` desabilitados; primeira linha selecionada.
- `DGMascaras`: **sem modelos, sem colunas** (a captura mostra a grade vazia sem cabeçalho); com modelos: `#`, Nome (987), LM1, LM2 (1084+"1"/"2"), Topográfico (990), Layout (991), 7ª escondida; linhas centralizadas; larguras 10/18/10/10/26/26%; `MultiSelect` falso.
- `DGPortas`: sem portas, sem colunas; cabeçalhos 922/983/1846/984/985; larguras 50/0/20%/30%/65/30%/20% de (largura − 115); refeitas no `Resize`.
- `mostraModeloMascara`: blocos topográfico/layout em cinza, branco se o diretório da simbologia existe; materiais 0/vazio se o código não está no catálogo; caixas da porta zeradas; linha 0 das portas sem seleção.

Diferenças da ligação anterior: sem a guarda do 331; colunas sempre criadas (cabeçalho com grade vazia) e com nomes inventados ("Modelo", "Material 1", "Bloco Topográfico"…); sem larguras nem centralização; dicas dos botões eram "motivos" inventados ("não portada…") no lugar das mMensagens; sem as dicas das caixas; cor dos blocos fixa; linha `GERMASC:` na linha de comando.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmGerenciadorMascaras.cs` | guarda 331; colunas só com linhas e com os cabeçalhos do original; larguras e `Resize`; centralização; dicas pelas mMensagens (botões e caixas); cor dos blocos pela existência do diretório; sai a linha `GERMASC:` |

## Prova

- `plugin:test`: não rodado: só casca; runner xUnit ausente. Última contagem: 975.
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- CAD: não medido: sem ZWCAD (medido; ausência = medição com data — ver RUNBOOK.md → *Existe CAD nesta máquina?*); tela não aberta.

## Falta

- [ ] Botões de editar/gravar/Excel/pesquisa de material seguem **desabilitados** (regra não portada: `DicionarioMascaras.Grava*`, `EditaAsMascaras`, importar/exportar, `marcaUdoDosModelos`, `btVerifica`, `btApagaModelosSemUso`, `DGPortasInseridas`).
- [ ] `LigacaoDeModelos.Catalogo` (base também de `frmGerenciadorContatos`) ainda escreve a linha `MODELOS:` na linha de comando em vez do tratamento do original.
- [ ] Auditar `frmGerenciadorContatos` (mesma base, ainda com dicas de "motivo"), `frmGerenciadorMateriais`, `frmGerenciadorMatIndep`, `frmRelatorio_*`, `frmSplash`.
- [ ] Medir `GERMASC` no `Funcional.dwg` (AutoCAD).

## Conhecimento registrado

Nenhum fato novo.
