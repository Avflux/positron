# Rodada 176 — `EDCON`/`EDCONP`: seção e cor das conexões, por seleção e por página

**Data:** 2026-10-15 · **Commit:** `054b001a` · **Frente:** 5 — caderno, circuitos, conexão e páginas · **Situação:** ✅ completa

## Alvo

Item 1 da fila do `ESTADO.md` ("telas só-casca mais baratas"): `frmEditaConexao` (`EDCONP`, 269
linhas). A triagem da rodada 110 a classificou como "só UI", mas o botão dela roda
`clsConexao.editarSecaoCorPaginas`, que **grava o desenho**. O irmão por seleção, `EDCON`
(`editarSecaoCor`), estava entre os 49 comandos sem nada no plugin. Como os dois usam a mesma regra,
entraram juntos.

## O que o reverso faz

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

- **Entrada / cadeia:**
  - `EDCON` → `Comandos.cs:579` (`edCon`) → keyword `S`/`C`/`A` → `clsConexao.editarSecaoCor(1|2|3)` (`clsConexao.cs:2313`).
  - `EDCONP` → `Comandos.cs:635` → `new frmEditaConexao()` (`frmEditaConexao.cs:158`, não modal) →
    grade com `DeclaracoesGeral.mPaginas[0, 1..]` (`:231`) → `btEditar` (`:183`) → páginas selecionadas
    → `SetFocus` na janela do desenho → o mesmo keyword → `clsConexao.editarSecaoCorPaginas(modo, páginas)` (`clsConexao.cs:2557`).
- **Lê:**
  - `CONEXAO` das `Polyline` do ModelSpace (`XDataConexao.lerXDataConexao`, `XDataConexao.cs:215`).
  - `AUXCONEXAO` dos `DBText` (`lerXDataAuxCircuito`, `XDataConexao.cs:447`: tipo, potencial, handle, endereçamento).
  - Padrão dos prompts: `DeclaracoesGeral.ativoRibbon.Secao`/`.Cor`, vindos de `My.Settings` (`Secao = "1,5"`, `Cor = "PT"`, `Eletron4.My/MySettings.cs:96,111`; atualizados pela lista/campo da barra, `Ribbon.cs:971,2264`).
- **Potenciais escolhidos:**
  - `EDCON`: seleção filtrada por `LWPOLYLINE` + `1001 CONEXAO` (prompt mMensagem 716); entram os **tipos 1..4**.
  - `EDCONP`: as conexões cujo **layer** está na lista de páginas (`List.Contains`, que diferencia maiúsculas); entram só os **tipos 1, 2 e 4**.
- **Grava / efeitos:**
  - Em **todo** o ModelSpace, cada `CONEXAO` tipo 1..4 de um potencial escolhido tem o XData reescrito (`GravarXDataConexao`, `XDataConexao.cs:97`, 25 valores, reservados fixos). Secao/Cor mudam conforme o modo, `Usuario = Environment.UserName`, `Data = DateTime.Now.ToString()`.
  - Os `DBText` `AUXCONEXAO` tipos 4/5/6 desses potenciais cujo handle (sem diferenciar maiúsculas) é de uma conexão regravada recebem: 4 = cor, 5 = seção, 6 = `"cor (seção)"`.
  - Uma transação, documento travado, `bAnularEventos` no commit.
- **Ramos e quirks (mantidos):**
  - **A aplicação volta a 0:** `aplicacao` é parâmetro opcional que nem o `EDCON` nem o `EDCONP` passam. Editar seção/cor desliga a aplicação do condutor.
  - O tipo 3 (superposição) não traz potencial no `EDCONP`, mas é editado se o potencial vier de outra conexão.
  - O alcance é o **potencial inteiro**, inclusive fora das páginas ou da seleção.
  - Cancelar um prompt de seção/cor ainda faz commit da transação, mas sem nada alterado.
  - O modo 4 (seção e cor dados pelo chamador) existe na assinatura; nenhum dos dois comandos o usa.
- **Mensagens:** 715 `Seção, Cor ou Ambas`, 716 `Selecione as conexões a serem editadas`, 717 `Seção=`, 718 `Cor=`, 719 `Editar Conexão` (título e dica do botão), 9 `Página` (coluna).
- **Apelidos de ofuscados:**
  - `hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF` = `user32!SetFocus`.
  - `frmEditaConexao`: `FpkZYb3mMU` = carrega as páginas; `QNjZraIE9k` = monta a coluna; `j2HZCSevKW` = clique do `btEditar`.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Data/Fiacao/SecaoECorDasConexoes.cs` | regra pura: modo pela palavra-chave, potenciais (seleção/páginas), `Aplicar`, texto do auxiliar |
| `cad-plugin/Positron.Data/Fiacao/AuxConexaoXData.cs` | leitor do `AUXCONEXAO` (novo; antes só o nome aparecia na limpeza) |
| `cad-plugin/Positron.Data/Fiacao/ConexaoXData.cs` | `ParaValores`: a escrita do `CONEXAO` (antes só havia leitura) |
| `cad-plugin/Positron.Plugin/XDataNeutro.cs` | `ParaResultBuffer`, o inverso do `Para` |
| `cad-plugin/Positron.Plugin/Fiacao/SecaoECorDasConexoesDoDesenho.cs` | casca: `SetFocus`, prompts, lock, transação, regravação |
| `cad-plugin/Positron.Plugin/Comandos.cs` | `[CommandMethod("EDCON")]` |
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmEditaConexao.cs` (+1 linha em `LigacoesDasTelas`) | a tela `EDCONP` ligada |
| `cad-plugin/Positron.Data.Tests/SecaoECorDasConexoesTests.cs` | +15 testes |
| `cad-plugin/Positron.Data/Interface/Mapas/BarraDoReverso.Dados.cs`, `docs/reverso-barra-do-original.txt` | regenerados: o botão `EDCON` da barra passa a "coberto" (125 → 126); o teste da contagem foi ajustado |
| `scripts/cad-fixture-edcon.lsp` | fixture que pendura textos `AUXCONEXAO` 4/5/6 + 2 de controle numa conexão real e despeja o resultado |
| `cad-plugin/README.md` | linha `EDCON`/`EDCONP` |

**Desvios do original:**
- O padrão dos prompts é fixo em `1,5`/`PT`, porque a lista de seção e o campo de cor da barra ainda não estão portados (ver *Falta*).
- O `MsgBox` de erro vira a linha de resumo.
- O cancelamento devolve "nada foi alterado" sem commit. O efeito é o mesmo do original.

## Prova

- `plugin:test`: **876** (+15), total conferido > 0. O teste da barra foi ajustado para 126 cobertos.
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- Cobertura: escritos à mão 76 → **77**; comandos do reverso sem nada no plugin 49 → **48**; telas com ligação 15 → **16**; botões da barra cobertos 125 → **126**.
- **ZWCAD 2026, `Funcional.dwg` (cópia):**

```
EDCONP: 16 página(s) na grade.
EDCONP: "Editar Conexão" (frmEditaConexao) aberta no CAD — 3 controle(s).
EDCON: seção "4" — 174 potencial(is), 365 conexão(ões) regravada(s), 0 texto(s) auxiliar(es) reescrito(s).
EDCON: seção "4" cor "VM" — 174 potencial(is), 365 conexão(ões) regravada(s), 0 texto(s) auxiliar(es) reescrito(s).
EDCON: cor "VM" — 174 potencial(is), 365 conexão(ões) regravada(s), 0 texto(s) auxiliar(es) reescrito(s).
```

As 365 conexões são as mesmas 365 linhas que o `FIA` projeta desse desenho. Os 0 textos estão
corretos: o desenho tem **106** `AUXCONEXAO`, todos dos tipos 1/2/3. Com o fixture
(`-Fixture scripts/cad-fixture-edcon.lsp -Comandos "EDCON A _ALL  4 VM,(pz-edcon:dump)"`):

```
EDCON: seção "4" cor "VM" — 174 potencial(is), 365 conexão(ões) regravada(s), 3 texto(s) auxiliar(es) reescrito(s).
ALVO;4B68A;2513
TEXTO;COR;VM
TEXTO;SECAO;4
TEXTO;AMBAS;VM (4)
TEXTO;OUTRO-HANDLE;OUTRO-HANDLE
TEXTO;TIPO1;TIPO1
```

- AutoCAD: **não medido**, porque o AutoCAD 2020 não está instalado nesta máquina hoje (só o 2011/2013 e o TrueView 2027, que não carregam net472). A build compila.
- O clique do `btEditar` da `EDCONP` não é scriptável (janela não modal). A tela foi medida abrindo e carregando as 16 páginas; a regra que o botão chama é a mesma medida pelo `EDCON`, só que com as páginas no lugar da seleção.

## Falta

- [ ] **Seção e cor ativas da barra** (a `ListaDeSecao`/`CampoDeCor` do `Ribbon.cs:971,2264`, o `ativoRibbon`): hoje desabilitadas na barra. Quando entrarem, o padrão dos prompts do `EDCON`/`EDCONP` passa a vir delas (também usadas pelo `INSM`/`CON`).
- [ ] Clique real do `btEditar` da `EDCONP` no CAD com mouse: conferência visual do dono.
- [ ] Medir no AutoCAD quando ele estiver instalado.
- [ ] (limpeza) Há 14 cópias privadas de `ParaResultBuffer` no plugin. O `XDataNeutro.ParaResultBuffer` novo pode substituí-las numa rodada de consolidação.

## Conhecimento registrado

`docs/recoder/conhecimento/conexao.md` (novo): layout do `CONEXAO` e do `AUXCONEXAO`, tipos dos auxiliares, os quirks do `editarSecaoCor*` e os apelidos.
