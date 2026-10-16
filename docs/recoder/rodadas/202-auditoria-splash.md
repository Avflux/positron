# Rodada 202 — auditoria da `frmSplash` (item 5 da correção do básico, 17ª tela)

**Data:** 2026-10-16 · **Commit:** `*(este)*` · **Frente:** correção do básico · **Situação:** 🟡 parcial (17 telas auditadas)

## Alvo

Item 5 do `ESTADO.md`; comandos `ONSPL`/`OFFSPL`. Sem captura própria.

## O que o reverso faz

`frmSplash.cs` (designer `:33-52`, construtor `:51`) e `Comandos.cs:31-47`.

- Designer: 625×506, sem borda, fundo azul com `TransparencyKey` azul, `BackgroundImage = SplashEL26` centralizada, `TopMost`, sem ícone nem barra de tarefas, centrada na tela.
- Construtor: `ShowModelessDialog`; **nenhum** manipulador de clique ou tecla (`Load` vazio).
- `ONSPL` cria a tela; `OFFSPL` só chama `Close()`, sem mensagem. Os dois só agem quando `companyHardlock == "CADGRAPH"` (licença).

Diferenças da ligação anterior: fechava a tela por clique, ESC, Enter e Espaço ("fechamento conveniente", sem prova no reverso); `OFFSPL` escrevia "splash fechada" / "nenhuma tela de splash aberta" na linha de comando.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmSplash.cs` | saem o clique e as teclas; a tela só fecha pelo `OFFSPL` |
| `cad-plugin/Positron.Plugin/Comandos.cs` | `OFFSPL` fecha sem mensagem |

## Prova

- `plugin:test`: não rodado: só casca; runner xUnit ausente. Última contagem: 975.
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- CAD: não medido: sem ZWCAD; tela não aberta. O RUNBOOK cita as mensagens removidas do `OFFSPL` (receita antiga); nenhum script as lia.

## Falta

- [ ] A condição `companyHardlock == "CADGRAPH"` dos dois comandos é licença: fica fora (mesma triagem do `TCHAVE`); decisão do dono se o splash deve existir no plugin.
- [ ] Atualizar a receita do RUNBOOK que cita as mensagens do `OFFSPL`.
- [ ] Auditar `frmGerenciadorMateriais`, `frmGerenciadorMatIndep`, `frmRelatorio_Materiais`, `frmRelatorio_Veias`.

## Conhecimento registrado

Nenhum fato novo.
