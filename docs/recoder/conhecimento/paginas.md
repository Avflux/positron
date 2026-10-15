# Páginas — títulos e textos

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

## Títulos de página (`DiagLog`/`TituloPagina`)

- Layout do XData: `TituloDaPaginaXData` (`cad-plugin/Positron.Data/Paginas/`).
- `clsEditaTitulosTextos.LeXDataTitulo` (`clsEditaTitulosTextos.cs:230`) só reconhece os índices **1..4**
  (`array[2] > 0 And < 5`); os outros índices do `TituloPagina` (6 = página, 8 = revisão…) não são "título".
- `Pagina.buscaTitulosExistentes` (`Pagina.cs:2502`) lê as `AttributeReference` do bloco de formato
  (`blockFormatoID`, o `BlockReference` com `DiagLog`/`Formato`) no layer `-1`: `TITULOnPAG` → título n, e
  **`PAINEL` → título 4**. No `Funcional.dwg` existem os títulos 1, 2 e 3 (rodada 179).

## `EditaTitulosTextosDoDWG` (`TROCTT`, rodada 179)

- Filtro de página: `List.Contains(Ent.Layer)`, que diferencia maiúsculas. `BlockReference` é pulado (atributos não entram).
- `LerXDataVazio` (`:174`) = tem XData de `Eletron`, `DiagLog`, `TextoLP`, `AUXCONEXAO`, `AUXINTERLIG`,
  `AUXIMPORTADO`, `DEPARA` ou `Definicao`. Texto/multitexto com um deles não é "texto do AutoCAD".
- A troca é `String.Replace` (diferencia maiúsculas), mas só grava se `novo.ToUpper.Trim <> velho.ToUpper.Trim`
  (`TextCompare`). Uma troca que só muda a caixa não grava nem conta.
- O título trocado **não** tem o valor do XData atualizado (só o `TextString`). O `AtualizaUmTituloEditado`
  (`:258`), que regrava o XData, é de outro caminho.
- Cada texto é gravado com lock + transação próprios (`clsTextos.AtualizarTexto`/`AtualizarMTexto`), dentro da
  transação de leitura, que não tem lock.
