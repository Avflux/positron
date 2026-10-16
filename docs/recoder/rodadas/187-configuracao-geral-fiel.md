# Rodada 187 — Configuração geral fiel (frmConfiguracaoGeral)

**Data:** 2026-10-16 · **Commit:** `*(este)*` · **Frente:** 12 — as 127 telas / Correção do básico (item 4) · **Situação:** ✅ completa

## Alvo

Substituir o formulário feito à mão inventado (`FormularioConfiguracao.cs`) pela ligação fiel dos 110 controles da `frmConfiguracaoGeral` (`frmConfiguracaoGeral.cs:2529-4600`; capturas `configuração geral 1-3.png`), gravando a configuração no ModelSpace nos XDatas `Eletron`/`Config` (41 valores) e `EletronProj`/`Projeto` (10 valores), além do idioma no registro (`HKCU\Software\Cadgraph\Eletron4\Idioma`). Fazer o botão `CFG` da barra de ferramentas chamar `CFG` diretamente (removendo o substituto para `ELETCFG`), e redirecionar `ELETCFG` para a mesma tela fiel.

## O que o reverso faz

Ficha do comportamento original em `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`:

- **Entrada / cadeia:**
  - Comando `CFG` (`Comandos.cs:95`): `new frmConfiguracaoGeral().ShowDialog()`.
  - Carga da tela (`h8M2j7J0e`, `frmConfiguracaoGeral.cs:3210-3330`): lê XData `Eletron`/`Config` e `EletronProj`/`Projeto` via `XDataGeral.LerXDataConfiguracao`/`2` (`XDataGeral.cs:153, 532`), além da chave de registro `HKCU\Software\Cadgraph\Eletron4`, `Idioma` (`:3212-3218`).
  - Preenche os 110 controles nas 3 abas (`tbBancoDados`, `tbBibliotecas`, `tbGeral`).
- **Lê:**
  - ModelSpace: XData `Eletron`/`Config` (41 posições: `Conf.Local`, `Conf.Banco`, `Conf.Norma`, `Conf.Separador*`, `Conf.Fonte*`, `Conf.Cor*`, `Conf.PrefixoCruz*`, `Conf.InterligacaoLayout`, etc.) e `EletronProj`/`Projeto` (caminhos de projeto e bibliotecas).
  - Registro: `HKCU\Software\Cadgraph\Eletron4`, chave `Idioma` (`[PT]` ou `[EN]`).
- **Grava / efeitos (`GuKynurbxa`, :3823-3930):**
  - Botão `btSalvar` (`:3823`):
    - Lê controles da tela e atualiza os campos de `Conf.*`.
    - Chama `XDataGeral.GravarXDataConfiguracao()` (`XDataGeral.cs:302`) com 41 valores no app `Eletron`, sub-buffer `Config`.
    - Chama `XDataGeral.GravarXDataConfiguracao2()` (`:592`) com 10 valores no app `EletronProj`, sub-buffer `Projeto`.
    - Grava o idioma (`[PT]` ou `[EN]`) na chave do registro `HKCU\Software\Cadgraph\Eletron4\Idioma` (`:3904-3910`).
    - Fecha o formulário.
- **Ramos e quirks:**
  - Presets (`btEletronorte`, `btEletrosul`, `btChesf`, `:3657-3740`): redefinem cores ACI (todos para 7 no recoder/reverso), caracteres delimitadores, fontes (1.5 ou 1.8), norma IEC vs ANSI, layout de representação e modelo de bobina.
  - Alternância SQL Server vs Access/SQLite (`:3485-3520`): quando SQL Server está ativo, o grupo SQL Server sobe (`Top = 277` vs `381`) e os campos de arquivo Access/SQLite ficam ocultos ou descem; no Access/SQLite, o grupo SQL Server fica invisível (`Visible = false`).
  - Validação de caminhos (`:3340-3380`): se o caminho preenchido não existe em disco, o fundo do `TextBox` fica vermelho claro (`Color.LightCoral`).
  - Cores CAD: os 4 botões de cor (`btCorConexao`, `btCorTextoCircuito`, `btCorInterligacao`, `btCorTextoInterligacao`) abrem o diálogo nativo de cores ACI do CAD (`ZwSoft.ZwCAD.Windows.ColorDialog` / `Autodesk.AutoCAD.Windows.ColorDialog`) e atualizam a cor de fundo do botão para a cor RGB correspondente ao índice ACI.
- **Mensagens:**
  - No original: fecha a tela silenciosamente após salvar.
- **Apelidos de ofuscados:**
  - `GuKynurbxa` (`:3823`) = método de salvar configurações (atualiza `Conf.*`, grava XDatas e registro).
  - `h8M2j7J0e` (`:3210`) = método de inicialização/carga da tela (lê registro e XData).
- **Tela / janela:**
  - Capturas fiéis: `configuração geral 1.png` (aba Banco de Dados), `configuração geral 2.png` (aba Bibliotecas), `configuração geral 3.png` (aba Geral).
  - 110 controles do designer conferidos um a um sem invenções de rodapé ou botões fora do original.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Plugin/Configuracao/PreferenciasGerais.cs` | Leitura e gravação da chave `HKCU\Software\Cadgraph\Eletron4\Idioma` (`[PT]` / `[EN]`) |
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmConfiguracaoGeral.cs` | Ligação fiel dos 110 controles da `frmConfiguracaoGeral` (3 abas, cores CAD, presets Eletronorte/Eletrosul/Chesf, validação `LightCoral`, alternância de posição/visibilidade SQL Server e ganchos de harness) |
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacoesDasTelas.cs` | Registro da `LigacaoDoFrmConfiguracaoGeral` na lista de telas com regra ligada |
| `cad-plugin/Positron.Plugin/Interface/Barra/BarraDeFerramentas.cs` | Remoção do substituto `{ "CFG", "ELETCFG" }` para a barra chamar `CFG` diretamente |
| `cad-plugin/Positron.Plugin/Comandos.cs` | Comando `ELETCFG` redirecionado para abrir `CFG` (`frmConfiguracaoGeral`) |
| `cad-plugin/Positron.Plugin/Configuracao/FormularioConfiguracao.cs` | Removido formulário feito à mão inventado (`git rm`) |
| `cad-plugin/Positron.Data.Tests/ConfiguracaoDoCadernoTests.cs` | +4 testes unitários cobrindo round-trip de Norma, Log Func, Layouts de representação e SQL Server |
| `cad-plugin/README.md` | Atualização da documentação dos comandos `CFG` e `ELETCFG` |
| `docs/recoder/conhecimento/projeto.md` | Documentação da `frmConfiguracaoGeral` e do registro `Idioma` |

## Prova

- `plugin:test`: **975** (+4 novos: `ConfiguracaoDoCaderno_PreservaNormaIecEAnsi`, `ConfiguracaoDoCaderno_PreservaLogFuncionalExterno`, `ConfiguracaoDoCaderno_PreservaLayoutsDeRepresentacao`, `ConfiguracaoDoCaderno_PreservaBlocoSqlServer`), 0 falhas.
- builds ZWCAD / AutoCAD: **0 avisos, 0 erros** em ambas as plataformas.
- Cobertura do reverso: **22** telas com ligação à regra (subiu de 21 para 22).
- CAD (`AutoCAD 2013 accoreconsole`, desenho novo / temporário):
  - Smoke com comando `CFG`, preset `eletrosul`, idioma `en`, salvar `1`:
```text
Configuração Geral: configuração gravada no XData do desenho (Eletron/Config e EletronProj/Projeto).
CFG: "Configuração Geral" (frmConfiguracaoGeral) não aberta.
```
  - Registro `HKCU\Software\Cadgraph\Eletron4\Idioma`: valor verificado em `[EN]`.
  - Smoke com comando `CFG`, preset `eletronorte`, idioma `pt`, salvar `1`:
```text
Configuração Geral: configuração gravada no XData do desenho (Eletron/Config e EletronProj/Projeto).
CFG: "Configuração Geral" (frmConfiguracaoGeral) não aberta.
```
  - Registro `HKCU\Software\Cadgraph\Eletron4\Idioma`: valor verificado em `[PT]`.
  - Smoke com comando `ELETCFG`, preset `chesf`, salvar `1`:
```text
Configuração Geral: configuração gravada no XData do desenho (Eletron/Config e EletronProj/Projeto).
CFG: "Configuração Geral" (frmConfiguracaoGeral) não aberta.
```
  - Bundle reinstalado via `scripts/instala-bundle.ps1 -Cad AutoCAD`.

## Falta

- Item 5 da *Correção do básico*: auditoria detalhada das 20 telas ligadas e telas feitas à mão restantes, comparando controle a controle com o designer e a captura, atrás de invenções do mesmo tipo.
- Conexão efetiva de dados ao SQL Server (item 9c, depende de decisão do dono); a interface gráfica e o XData já suportam todos os parâmetros do SQL Server.

## Conhecimento registrado

- `docs/recoder/conhecimento/projeto.md`: adicionada seção sobre a tela `frmConfiguracaoGeral` fiel, persistência dos XDatas `Eletron`/`Config` (41 valores) e `EletronProj`/`Projeto` (10 valores), chave de registro `Idioma` (`[PT]` / `[EN]`), comportamento de alternância do bloco SQL Server e ganchos do harness.
