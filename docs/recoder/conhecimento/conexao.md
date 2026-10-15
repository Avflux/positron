# Conexões (`CONEXAO`) e textos auxiliares (`AUXCONEXAO`)

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

## `CONEXAO` — a polyline do condutor (25 valores)

`XDataConexao.GravarXDataConexao` (`XDataConexao.cs:97`). Leitura em `lerXDataConexao` (`:215`).
No recoder: `ConexaoXData` (`Ler` e `ParaValores`).

| idx | código | campo |
|---|---|---|
| 1 | 1070 | Tipo (1..4 = condutor; 3 = superposição, cujo Handle aponta a conexão superposta) |
| 2 | 1071 | Potencial |
| 3 | 1000 | Handle |
| 4 | 1070 | Painel |
| 5 | 1070 | Aplicacao |
| 7–11 | 1000 | Nome, Funcao, Tensao, Secao, Cor |
| 14–15 | 1070 | Disp1, Disp2 (`-1`/`0`) |
| 16 | 1000 | Jumper |
| 18 | 1071 | Enderecamento |
| 20–21 | 1000 | Usuario, Data (`DateTime.Now.ToString()`) |
| 6, 12, 13, 17, 19, 22–24 | | reservados, sempre regravados fixos: `0`, `""`, `0.0`, `""`, `1`, `1`, `0.0`, `""` |

Qualquer escrita **regrava os 25** (os reservados não são preservados). — rodada 176

## `AUXCONEXAO` — texto auxiliar de circuito (12 valores)

`XDataConexao.cs:411` (escrita) e `lerXDataAuxCircuito` (`:447`, que lê os índices 1, 2, 3 e 6).
No recoder: `AuxConexaoXData.Ler`.

| idx | código | campo |
|---|---|---|
| 1 | 1070 | Tipo |
| 2 | 1071 | Potencial |
| 3 | 1000 | Handle da conexão |
| 6 | 1071 | Enderecamento |
| 7–8 | 1000 | Usuario, Data |

Tipos que o `editarSecaoCor*` reescreve: **4** = cor, **5** = seção, **6** = `"cor (seção)"`.
O `Funcional.dwg` real tem 106 `AUXCONEXAO`, todos dos tipos 1/2/3. — rodada 176

## `editarSecaoCor` / `editarSecaoCorPaginas` (`EDCON` / `EDCONP`)

`clsConexao.cs:2313` e `:2557`. Ver a rodada `../rodadas/176-edicao-secao-cor-conexoes.md`.

- O alcance é o **potencial inteiro** no ModelSpace, não só a seleção ou as páginas.
- Por página, só os tipos 1, 2 e 4 trazem potencial; a página casa com o layer **diferenciando maiúsculas**.
- A **aplicação volta a 0** (o parâmetro opcional não é passado).
- O padrão dos prompts é o `ativoRibbon.Secao`/`.Cor` (`My.Settings`: `1,5` / `PT`).

## Apelidos de ofuscados

| ofuscado | é |
|---|---|
| `hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF` (`oADsu33FpCEasW73ADP/`) | `user32!SetFocus`: devolve o foco ao desenho antes de um prompt vindo de janela não modal |
| `frmEditaConexao.FpkZYb3mMU` / `QNjZraIE9k` / `j2HZCSevKW` | carrega as páginas / monta a coluna / clique do `btEditar` |
