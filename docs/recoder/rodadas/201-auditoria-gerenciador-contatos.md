# Rodada 201 — auditoria da `frmGerenciadorContatos` (item 5 da correção do básico, 16ª tela)

**Data:** 2026-10-16 · **Commit:** `*(este)*` · **Frente:** correção do básico · **Situação:** 🟡 parcial (16 telas auditadas)

## Alvo

Item 5 do `ESTADO.md`; comando `GERCONT`, irmã da `frmGerenciadorMascaras` (rodada 200, mesma base `LigacaoDeModelos`). Captura: `gerenciador de contatos.png`.

## O que o reverso faz

`frmGerenciadorContatos.cs` (construtor `:1960`, `mostraModelo :2119`, `mostraContatos :2610`), `clsDispositivo.cs` (`carregaModelosNoDG :2062`, `AtualizaColunasDGModelos :2123`), `clsDispositivoAuxiliares.cs` (`carregaContatosNoDG :667`, `AtualizaColunasDGContatosAuxiliaresMODELO :1751`).

- Construtor: `BancoValido()`; DWG sem índice → `MsgBox` 331; textos pelas mMensagens (`LbTerminais` recebe 655 e depois 659 "Terminais"); dicas 661–673, 916/917 + nome do modelo, 1211, 1353, 1843; combos `CBTipo` (NA/NF/RV) e `CBComportamento` (ST/TE/TD/BI/AM).
- `DGModelo`: sem modelos, sem colunas; com modelos: `#`, Nome (987), LM1, LM2, Reserva1, Topográfico (990), Layout (991), Plaquetas (992), Reserva2, Terminais (983), Orientação (1846); linhas centralizadas; larguras 5/13/9/9/0/19/19/0/0/13/13%.
- `DGContato`: sem contatos, sem colunas; cabeçalhos `#`, T1..T3, Orientação, Tipo (995), Comportamento (996), "ReservaUso", Página (9), Handle; só as colunas 1–6 visíveis, em sextos; centralizada, sem ordenação.
- `mostraModelo`: blocos em cinza, branco se o diretório da simbologia existe.

Diferenças da ligação anterior: sem a guarda do 331; colunas sempre criadas, com nomes inventados ("Material 1", "Bloco Topográfico"…) e a coluna Reserva1 com título "0"; sem larguras nem centralização; `LbTerminais` com o texto errado ("Terminais da Bobina"); dicas eram "motivos" inventados; sem as dicas das caixas e combos; cor dos blocos fixa; linha `GERCONT:` e linha `MODELOS:` (na base) na linha de comando.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmGerenciadorContatos.cs` | guarda 331; colunas só com linhas e com os cabeçalhos do original; larguras e `Resize`; centralização; dicas pelas mMensagens; cor dos blocos; `LbTerminais` = 659; sai a linha `GERCONT:` |
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDeModelos.cs` | o erro do catálogo vira `MsgBox` crítico em vez da linha `MODELOS:` (vale para as duas telas) |

## Prova

- `plugin:test`: não rodado: só casca; runner xUnit ausente. Última contagem: 975.
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- CAD: não medido: sem ZWCAD; tela não aberta.

## Falta

- [ ] Botões de editar/gravar/Excel/pesquisa de material seguem **desabilitados** (regra não portada); a dica do Excel não leva ainda o nome do modelo (916/917 + `TBModelo`, atualizada no `mostraModelo`).
- [ ] `DGContatosInseridos` (`carregaDispPrincipalDoModeloInserido`), `marcaUdoDosModelos`, `Correcao.CorrigeModelosDeContatos` no construtor, `VerificaTamanhoContatosAuxiliares`.
- [ ] Auditar `frmGerenciadorMateriais`, `frmGerenciadorMatIndep`, `frmRelatorio_Materiais`, `frmRelatorio_Veias`, `frmSplash`.
- [ ] Medir `GERCONT` no `Funcional.dwg` (AutoCAD).

## Conhecimento registrado

Nenhum fato novo.
