# Rodada 179 — `TROCTT`: troca DE → PARA em títulos, textos e multitextos, tela ligada

**Data:** 2026-10-15 · **Commit:** `86907aaf` · **Frente:** 9 — exportar/importar e manipulação de projeto · **Situação:** ✅ completa

## Alvo

Item 1 da fila do `ESTADO.md`: `frmEditaTitulosTextos` (`TROCTT`, 600 linhas + `clsEditaTitulosTextos`,
308). A triagem da rodada 112 o marcou como "só UI", mas o botão roda
`clsEditaTitulosTextos.EditaTitulosTextosDoDWG`, que **grava o desenho**.

## O que o reverso faz

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

- **Entrada / cadeia:** `TROCTT` → `Comandos.cs:1348` → `new frmEditaTitulosTextos()` (`frmEditaTitulosTextos.cs:492`, não modal)
  → `Pagina.buscaTitulosExistentes` (`Pagina.cs:2502`) → grade com `mPaginas` (`sOZSLnbfGo`) → `BtEditar`
  (`sgrSxhI2bv`) → `clsEditaTitulosTextos.EditaTitulosTextosDoDWG` (`clsEditaTitulosTextos.cs:15`) →
  `clsTextos.AtualizarTexto`/`AtualizarMTexto` (`clsTextos.cs:528,691`).
- **Habilitação:** os atributos (`AttributeReference`) do bloco de formato (`blockFormatoID`) no layer `-1`;
  `TITULO1PAG`..`TITULO4PAG` habilitam o "Título n", e `PAINEL` também habilita o 4. Sem nenhum título:
  mMensagem 53 `O Formato usado não possui títulos!` e a tela não abre.
- **O botão:** não faz nada sem alguma caixa marcada ou com o DE vazio. Páginas = as linhas selecionadas.
- **A troca**, no ModelSpace, só para entidades cujo layer está nas páginas (`List.Contains`, diferencia maiúsculas); bloco não entra:
  - `DBText` com `DiagLog`/`TituloPagina` de índice 1..4 (`LeXDataTitulo`, `:230`): troca se o "Título n" está marcado;
  - outro `DBText`: troca com "Textos AutoCAD" marcado e **sem** XData de `Eletron`, `DiagLog`, `TextoLP`,
    `AUXCONEXAO`, `AUXINTERLIG`, `AUXIMPORTADO`, `DEPARA`, `Definicao` (`LerXDataVazio`, `:174`);
  - `MText` (`Contents`): troca com "Multitextos Autocad" marcado e a mesma regra do XData.
  - A troca é `String.Replace` (diferencia maiúsculas). Só grava quando o resultado difere do original
    **sem diferenciar maiúsculas** e espaços nas pontas; texto em branco não entra.
- **Grava / efeitos:** `TextString`/`Contents` de cada texto trocado. O XData do título (o valor no índice 3)
  **não** é atualizado (quirk mantido; o `AtualizaUmTituloEditado`, que atualiza, não é chamado aqui).
- **Mensagens:** 592 `Editar Títulos e Textos` (título e dica), 48/49 `DE`/`PARA`, 40..43 `Título n`, 1161 `Textos AutoCAD`,
  1222 `Multitextos Autocad`, 9 `Página`, e no fim `MsgBox(n & " textos sofreram alteração.")` (1221).
- **Apelidos de ofuscados:** `fA6S3XxqxP` = os títulos existentes; `QyUSj1syjb` = monta a coluna; `sOZSLnbfGo` = carrega as
  páginas; `uHnSwNE1cF` = largura da coluna; `sgrSxhI2bv` = clique do `BtEditar`; `K9qSt9nUaH` = `InitializeComponent`.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Data/Paginas/EdicaoDeTitulosETextos.cs` | regra pura: títulos existentes, opções válidas, `NovoTexto` (os três ramos e a comparação sem caixa) |
| `cad-plugin/Positron.Plugin/Paginas/TitulosETextosDoDesenho.cs` | casca: atributos do formato, varredura do ModelSpace, `LeXDataTitulo`/`LerXDataVazio`, gravação |
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmEditaTitulosTextos.cs` (+1 linha em `LigacoesDasTelas`) | a tela ligada e o gancho de harness `POSITRON_TROCTT` |
| `cad-plugin/Positron.Data.Tests/EdicaoDeTitulosETextosTests.cs` | +7 testes |
| `scripts/cad-fixture-troctt.lsp` | fixture: textos de controle na página de um título preenchido, e o dump |
| `cad-plugin/README.md` | linha `TROCTT` |

**Desvios do original:**
- O original grava sem `LockDocument` a partir de uma janela não modal. Aqui a troca toda é feita numa
  transação com o documento travado. O efeito é o mesmo (o original abre uma transação e um lock por texto).
- Os `MsgBox` 53/1221 viram linhas de comando.
- `POSITRON_TROCTT` = `DE|PARA|caixas|páginas` (caixas `1`..`4`, `T`, `M`; páginas por vírgula, vazio = todas):
  gancho para o script, igual ao `POSITRON_ANALISAR`. Ele preenche os controles e roda o mesmo tratador do clique.

## Prova

- `plugin:test`: **900** (+7), total conferido > 0.
- builds ZWCAD / AutoCAD: 0 avisos, 0 erros.
- Cobertura: telas com ligação 18 → **19**; o resto sem mudança (o botão `TROCTT` da barra já estava coberto).
- **ZWCAD 2026, `Funcional.dwg` (cópia), com o fixture** (`-Fixture scripts/cad-fixture-troctt.lsp -Comandos "TROCTT,(pz-troctt:dump)"`).
  A página escolhida pelo fixture é a 24 (títulos 1 = `PNL-GGE`, 2 = `DIAGRAMA FUNCIONAL`, 3 = `PROG. DAS CHAVES SELETORAS`); a outra é a 23.

`POSITRON_TROCTT=PZ-ABC|PZ-XYZ|TM|24`:

```
TROCTT: 16 página(s) na grade; títulos do formato: 1, 2, 3.
TROCTT: 2 textos sofreram alteração. ("PZ-ABC" -> "PZ-XYZ" em 1 página(s))
TEXTO;A;PZ-XYZ      (texto solto: trocou)
TEXTO;B;PZ-ABC      (XData Eletron: ficou)
TEXTO;C;PZ-XYZ      (multitexto: trocou)
TEXTO;D;pz-abc      (minúsculas: ficou)
TEXTO;E;PZ-ABC      (página 23, não selecionada: ficou)
```

`POSITRON_TROCTT=DIAGRAMA|DIAG|2|24`:

```
TROCTT: 1 textos sofreram alteração. ("DIAGRAMA" -> "DIAG" em 1 página(s))
TITULO;2;DIAG FUNCIONAL
```

O formato do desenho tem os títulos 1, 2 e 3, então o "Título 4" abre desabilitado.

- AutoCAD: **não medido**, o AutoCAD 2020 não está instalado nesta máquina. A build compila.

## Falta

- [ ] Conferência visual da tela com mouse (seleção de páginas, caixas desabilitadas): dono.
- [ ] Medir no AutoCAD quando ele estiver instalado.

## Conhecimento registrado

`docs/recoder/conhecimento/paginas.md` (novo): títulos de página (`TituloPagina`, o `buscaTitulosExistentes`),
a lista do `LerXDataVazio` e os quirks do `EditaTitulosTextosDoDWG`.
