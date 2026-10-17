# Rodada 212 — Paleta `uscPaginas`: edição inline da célula Página

**Data:** 2026-10-16 · **Commit:** *(este)* · **Frente:** correção do básico, item 3 (paleta fiel) · **Situação:** 🟡 parcial

## Alvo

Item 1 da fila do `ESTADO.md` (fechar os recortes da rodada 183). O recorte desta rodada é o que a
rodada 183 deixou explicitamente de fora e a 186 confirmou: a **edição inline da célula Página** da
grade das folhas (`uscPaginas.cs:1733-1846`, o ramo `ColumnIndex == 0` do `dg.CellEndEdit`). Hoje o
recoder deixa a coluna Página `ReadOnly` com o comentário "A renumeração inline permanece fora desta
rodada" (`FolhasControle.cs:89`), enquanto o reverso **deixa a coluna editável** e trata o fim da
edição.

Critérios: nenhum controle, dica, texto ou configuração inventados; o nome digitado passa pelo
`Trim`/`ToUpper`, pela validação de dígitos e pelo `montaNumeroPagina` (largura fixa do caderno); o
`LayerValido` recusa o que não é página; o nome que já é página avisa (mMensagem 28) e não renomeia;
a **primeira linha (a capa)** volta ao nome original; a célula esvaziada escreve a **página ativa**
(quirk do original). Escrita no desenho pelo caminho da paleta com `LockDocument`; erro e aviso
chegam ao usuário como no original (`MsgBox`).

## O que o reverso faz

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

- **Entrada:** `dg.CellEndEdit` → `j9Sp1mKZkcD` (`uscPaginas.cs:1733`, ligado no designer em `:220`).
  Duas colunas são tratadas: a Página (`case 0`) e o Alternativo (`case 2`); a Unidade (`case 1`) só
  regrava o XData. A coluna Página **não** é `ReadOnly` no designer.
- **Normalização (`:1736-1752`):** o texto da célula é `Trim()`. Na coluna 0, se não for vazio recebe
  `ToUpper()`. **Vazio** → escreve `DeclaracoesGeral.ativo.Pagina` (a **página ativa**) na célula e
  **retorna** sem renomear — quirk mantido (a célula deixa de exibir o nome da própria linha).
- **Ramo da Página (`case 0`, `:1790-1844`):**
  - **Linha 0 (a capa)** → escreve de volta `Cells[3].Value` (o nome carregado) e sai. É a **única**
    proteção da primeira linha: não há `ReadOnly`, há reversão.
  - **Linhas ≥ 1:** `text2 = Cells[0].Value.ToString().Trim()`. Se não é numérico: com **um** caractere
    só, volta ao original; com mais, **todo caractere menos o último** tem de ser dígito, senão volta ao
    original. Depois `text2 = Pagina.montaNumeroPagina(text2)` (`Pagina.cs:1819`, aplica a largura fixa).
  - `Pagina.LayerValido(text2)` (`Pagina.cs:240`): número > 0, ou número seguido de dígito/letra
    maiúscula. Inválido → volta ao original (mas **segue** para as sincronizações).
  - Válido: escreve `text2` na célula; compara com `Cells[3]` (o nome antigo); **igual** → só a célula
    normalizada, sem renomear. Diferente → `Pagina.renumerarPagina(text3, text2)` (`Pagina.cs:1841`).
- **`renumerarPagina` (`Pagina.cs:1841-1902`):** percorre `mPaginas`; se `Pagina` já é uma página do
  caderno, mostra a mMensagem **28** (`Esta página já existe!`, informação) e devolve **false** (não
  renomeia). Senão `alteraNomeLayer(PagOld, PagNova)` (`:1903`): `LockDocument` + transação, só troca o
  `Name` do layer; atualiza a matriz, `OrdenaMatrizPaginas` e `AtualizaContTotFl`.
- **Fim do handler (`:1816-1844`):** no sucesso, `Y9op1KgeRgW()` (reconstrói a grade) e
  `VSWp1ebyWra()` (multiseleção desligada, linha da ativa), e `tbPagina.Text = text2`. Em qualquer ramo
  que chegue ao fim (inclusive o `LayerValido` falso), roda a família de sincronizações
  (`clsConexao.sincronizaCircuitos`, `clsInterligacao.SincronizaCruzamentoInterlig`,
  `clsDePara.SincronizaDePara(false)`, `clsDispositivoAuxiliares.SincronizaContatos`,
  `clsPortas.SincronizaPortas`). Exceção → `MsgBox` crítico.
- **`Cells[3]`:** a coluna técnica `Pg` guarda o nome **carregado** — é de onde o original tira o
  original para reverter (a coluna `PgDecimal` é a 4).
- **Mensagens:** mMensagem 28 `Esta página já existe!` (mesmo texto da 32, usada pelo `CriarLayer`).

### Diferenças antes de editar

| controle | recoder atual | reverso / alvo |
|---|---|---|
| coluna Página | `ReadOnly` | editável |
| fim da edição da Página | ignora (`ColumnIndex < 1`) | normaliza, valida, renomeia ou reverte |
| linha 0 | — | reverte ao nome carregado |
| célula vazia | — | escreve a página ativa (quirk) |
| nome já existente | — | avisa mMensagem 28, não renomeia |

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Data/Paginas/RenomeacaoInlineDaPagina.cs` | regra pura: normalização (`Trim`/`ToUpper`), validação de dígitos, `montaNumeroPagina`, `LayerValido`, existência (mMensagem 28), capa e o quirk do vazio; devolve o nome que a célula passa a exibir, o aviso e se as sincronizações rodam |
| `cad-plugin/Positron.Data.Tests/RenomeacaoInlineTests.cs` | +12 casos |
| `cad-plugin/Positron.Plugin/Interface/Folhas/FolhasControle.cs` | tira o `ReadOnly` da coluna Página; `CellEndEdit` passa a despachar por coluna (`EditarCelula`); `RenomearPaginaInline` renomeia o layer, recalcula CONT/FL/TOT, reconstrói a grade e devolve a mensagem |
| `cad-plugin/Positron.Plugin/Interface/Folhas/ProvaDaPaleta.cs` | ação `inline` (o texto vem de `POSITRON_FOLHA_INLINE`; ausente = célula vazia) |
| `cad-plugin/Positron.Data/Interface/MensagensDoReverso.cs` | documenta que a mMensagem **28** tem o mesmo texto da 32 (`Esta página já existe!`) — é a do `renumerarPagina` |

**Desvios do original (com o motivo):**

- **A existência é lida do desenho, não da grade.** O `renumerarPagina` percorre o `mPaginas`; a
  primeira tentativa lia a grade e a **própria célula em edição** (que já carrega o nome digitado)
  contava como página existente. Medido no CAD: a página `7 → "7A"` saiu como `Esta página já existe!`
  até a correção; agora `PaginasDoDesenho.Ler()` é quem responde.
- **As sincronizações** são o **stand-in** já registrado (`Comandos.SincronizacoesDoCaderno()`), o
  mesmo do `Apagar Páginas`/`Renumerar Páginas` (a família `clsConexao`/`clsInterligacao`/… não está
  portada). O original as roda em **todo** ramo que chega ao fim do `case 0` — inclusive quando o
  `LayerValido` recusa — e não quando sai antes (`RodarSincronizacoes` guarda exatamente esses ramos).
- **CONT/FL/TOT** depois do rename: a chamada é a mesma `AtualizarContagem` (`AtualizaContTotFl`)
  provada na rodada 185; o valor recalculado após a renomeação **não** foi re-medido com sentinelas
  nesta rodada (ver *Falta*).

## Prova

- `npm run plugin:test`: **0 testes**, falha conhecida do adaptador VSTest (não é passe). Console
  xUnit 2.9.2 em `%TEMP%/pm212`, bin completo: **1020 (+12)**, Errors **0**, Failed **0**,
  Skipped **0**; **3,607 s**.
- Builds finais ZWCAD / AutoCAD: **0 avisos, 0 erros** (1,41 s / 2,20 s, contra as duas APIs reais).
- AutoCAD 2020 `accoreconsole`, cópia do `Funcional.dwg` (16 páginas: 1, 2, 6, 7, 8, 15..24, 1000),
  ação pelo **mesmo método que o `CellEndEdit` da grade chama**, respostas só do harness:

```text
# 1. renomear a página 7 para "7A" (válido, livre)
edição inline "7A" na linha 3 (página 7) → Página: "7" → "7A"; 1 layer(s) renomeado(s).; célula="7A"
  grade depois: [1 | 2 | 6 | 7A | 8 | 15 | 16 | 17 | 18 | 19 | 20 | 21 | 22 | 23 | 24 | 1000]; tbPagina=7A

# 2. destino que já é página (a 6 para "8") — mMensagem 28 e a célula volta
Esta página já existe!
edição inline "8" na linha 2 (página 6) → Página: Esta página já existe!; célula="6"
  grade depois: [1 | 2 | 6 | 7 | 8 | ...]  (inalterada)

# 3. a primeira linha (a capa) — reverte, sem renomear
ação "inline" → edição inline "5" na linha 0 (página 1) → Página: a primeira linha (a capa) não se renomeia; "1" mantido.; célula="1"

# 4. célula esvaziada — o quirk: escreve a página ativa, sem renomear
ação "inline" → edição inline "" na linha 3 (página 7) → Página: célula vazia — escrita a página ativa "7" (sem renomear).; célula="7"
```

- Prova **independente** (fixture `scripts/cad-fixture-renumerar.lsp` + dump em AutoLISP na **mesma**
  sessão, depois do `pzFolhas`): o layer `7` virou `7A` **preservando** o XData `Eletron`
  (unidade/alternativo) que o layer já carregava — como o `alteraNomeLayer`, que só troca o `Name`:

```text
PAGINA;7A;xdata=((1000 . Unidade) (1000 . UNIFILAR) (1000 . ))
```

- Não medido: a **interface cheia** (janela/paleta) e o `CellEndEdit` do WinForms de verdade — o
  `accoreconsole` é headless e não carrega a paleta; o que se provou é que o método por trás do
  evento faz o serviço. ZWCAD **não** medido: `C:\Program Files\ZWSOFT` não existe nesta máquina
  nesta data (o host medido é o AutoCAD 2020).

## Falta

- [ ] Medir pelo **clique real na célula** com a **interface cheia** (o `CellEndEdit` do WinForms, a
  grade reconstruída e o `tbPagina` na janela): o `accoreconsole` não carrega a paleta. Vale para as
  quatro passagens acima.
- [ ] Repetir no **ZWCAD** quando ele voltar a esta máquina.
- [ ] CONT/FL/TOT após o rename: a chamada é a mesma provada na 185, mas o valor recalculado não foi
  re-medido com sentinelas.
- [ ] Restantes do item 1 da fila (a rodada 183): Excel ativo (`clsTextos.ExportaPaginas/ImportaTitulos`),
  o status do banco ligado ao contador de conexões, o progresso compartilhado pelas rotinas longas,
  o título 4/D/A/V e os seis atalhos em GUI, a saída anômala do `acad.exe` e o
  `frmConfiguracaoBDProjeto` que rouba o foco ao abrir.

## Conhecimento registrado

`conhecimento/paginas.md`: a edição inline da célula Página (`j9Sp1mKZkcD`, `case 0`), a coluna `Pg`
como fonte do nome original, o quirk da célula vazia e o aviso da mMensagem 28 do `renumerarPagina`.
