# Rodada 184 — Restaurar campos ao abrir Editar os Títulos

**Data:** 2026-10-15 · **Commit:** *(este)* · **Frente:** correção do básico, item 3 · **Situação:** 🟡 parcial

## Alvo

Primeiro item da fila: completar `Pagina.restauraCampos` específico do editor, pendente da rodada
183. Critérios: executar antes de identificar os títulos do formato; capturar TextString (último
índice vence); apagar/recriar campos a partir dos atributos; preservar títulos e revisão
simplificada; recalcular CONT/FL/TOT/Alternativo; usar LockDocument e transação abrangente; não
trocar colunas, reconstruir definições de revisão, gravar configuração nem ativar a capa.
Sem dependências novas, comandos novos ou controles extras.

## O que o reverso faz

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

- **Entrada / cadeia:** `frmEditaTitulos.cs:557` chama `Pagina.restauraCampos` antes de
  `buscaTitulosExistentes`. `Pagina.cs:2050-2123`: lock, transação abrangente, CarregaPaginas,
  OrdenaMatrizPaginas, capturaTitulos, capturaRevisoesSimplificadas, ApagarCamposPaginas,
  criaCamposTOT, criaCamposFormato por página, AtualizaTitulos, AtualizaRevSimplificada,
  recarga/ordenação, AtualizaContTotFl e commit.
- **Lê:** layers numéricos e unidade/alternativo `Eletron/Unidade`; DBText `DiagLog/TituloPagina`
  índices 1..4 e 8 pelo **TextString**, último duplicado vence (`Pagina.cs:722-838`,
  `Revisao.cs:80-157`). Atributos da referência `DiagLog/Formato`, protegidos por tag.
- **Grava / efeitos:** `ApagarCamposPaginas` (`Pagina.cs:1118-1195`) apaga todo DBText com índice
  positivo, inclusive fora de páginas. `criaCamposTOT` (`:1010-1084`) cria TOT nos layers capa/-1;
  `criaCamposFormato` (`:841-1008`) cria os demais campos no layer de cada página, com referência
  capa na capa e -1 no corpo. `dtepniSZGL6` (`:1086-1115`) clona aparência/geometria do atributo.
  `AtualizaTitulos` (`:1653-1761`) restaura 1..4 e 9; `Revisao.AtualizaRevSimplificada`
  (`Revisao.cs:159-243`) regrava todos os índices 8, texto e XData.
- **Ramos e quirks:** abrir e fechar pelo X já restaura a estrutura, mas não aplica a edição local
  da grade. Este caminho **não** faz TrocaColunas, attsync, definições de revisão, configuração ou
  ativação da capa (esses passos pertencem a Caderno.CriaCaderno).
- **Mensagens:** exceção da restauração é exibida por MsgBox de informação (`Pagina.cs:2103-2108`).
  Sem títulos: `O Formato usado não possui títulos!` (mensagem 53; frmEditaTitulos).
- **Apelidos de ofuscados:** `dtepniSZGL6` = clonar AttributeReference em DBText visível.

## O que foi feito

| arquivo | o quê |
|---|---|
| `cad-plugin/Positron.Plugin/Paginas/RestauracaoDoFormatoDoDesenho.cs` | extrai RecriarCampos para compartilhar somente apagar/TOT/campos; adiciona RestaurarCampos com captura de TextString, revisões, alternativos, lock e transação abrangente; restaura dados e CONT/FL/TOT sem os efeitos da troca de formato |
| `cad-plugin/Positron.Plugin/Interface/Telas/LigacaoDoFrmEditaTitulos.cs` | chama a restauração antes de ler os títulos existentes; erro visível por MsgBox, como no reverso |
| `cad-plugin/Positron.Data.Tests/TitulosDaPaginaTests.cs` | +6 casos das regras puras reutilizadas: último índice vence após completar quatro títulos e vazio substitui valor anterior |
| `cad-plugin/Positron.Plugin/Interface/Folhas/ProvaDaPaleta.cs` | ação restaurar do harness abre/descarta duas vezes e compara todos os títulos, revisões e página ativa |
| `scripts/cad-fixture-titulos.lsp` | fixture opt-in com revisão TextString diferente do XData, campo obsoleto e texto comum; prova independente após restauração, título esperado configurável só no harness |

Sem dependência, comando ou controle novo. A restauração não chama Executar da troca de formato.
A transação abrangente também permite rollback das transações internas dos adapters reutilizados.
Nenhuma supressão de teste/erro adicionada. Não se alterou a edição individual de títulos.

## Prova

- `npm run plugin:test`: adaptador VSTest não carregou, **0 testes** (não é passe).
  Console xUnit 2.9.2, bin inteiro copiado para `%TEMP%/pm184`: **947**, +6; Errors **0**,
  Failed **0**, Skipped **0**, **3,678 s**.
- Builds ZWCAD / AutoCAD: **0 avisos, 0 erros**, **1,91 s / 1,83 s**. As duas builds compilam
  também os tipos da regra pura (verificação de tipos C#).
- Cobertura antes/depois: **78** manuais, **115** gerados, **48** ausentes, **21** telas ligadas.
- AutoCAD 2020 `accoreconsole`, cópia do **Funcional.dwg**, fixture com cinco duplicados de título,
  índice 9, revisão 8 e índice obsoleto 42: duas aberturas/descarte mantêm títulos de **16 páginas**,
  **16 revisões** e página ativa; cada grade tem **15 linhas**. Prova independente: duplicados
  viram **1** campo título 1 do formato, revisão vira **1** campo com texto e XData restaurados,
  entidades antigas REV/42 apagadas e texto comum sem XData preservado.

```text
Editar os Títulos: 15 página(s) na grade; capa excluída.
Editar os Títulos: 15 página(s) na grade; capa excluída.
ação "restaurar" → PASSOU — duas aberturas/descarte; títulos de 16 página(s), 16 revisões e página ativa preservados
RESTAURA184;falhas=0;titulo1=1;rev=1;antigos-rev-obsoleto-apagados=sim;texto-comum-preservado=sim
```

- AutoCAD **visível**, processo de lançamento persistente BACKGROUND, DLL isolada em
  `C:/positron-smoke/r184`, cópia `pz184-gui.dwg`: Timer WinForms aciona o **menu real da paleta**
  fora de comando (PerformClick, não mouse físico). Navega para 2, grava atalho, abre editor,
  verifica que a edição local não foi aplicada antes do clique Editar DWG e aplica/reconfere.
  Grade **15 linhas**, aplicação **45 textos** (agora os duplicados já foram recriados).

```text
pzFolhas UI: PASSOU — navegação pelo botão, atalho Xrecord, menu Editar Títulos, 15 linha(s), edição local sem gravação antecipada; Editar DWG fora de comando; texto e XData confirmados.
NOVO=Drawing1.dwg; entidades=0
pzFolhas UI: PASSOU — navegação pelo botão, atalho Xrecord, menu Editar Títulos, 15 linha(s), edição local sem gravação antecipada; Editar DWG fora de comando; texto e XData confirmados.
RESTAURA184;falhas=0;titulo1=1;rev=1;antigos-rev-obsoleto-apagados=sim;texto-comum-preservado=sim
```

  Segunda passagem do Timer depois de voltar do desenho novo. Prova LISP repetida com o valor
  efetivamente aplicado pelo Timer (`PROVA UI 183`, literal do harness anterior). Original intocado;
  cópia e novo desenho fechados **sem salvar**; nenhum acad/accoreconsole permaneceu aberto.
  Não houve nova captura visual nem novo clique físico nesta rodada.
- Limitações/ocorrências do instrumento: primeira chamada do core tentou criar banco com TEMP do
  Git Bash e falhou; repetida com banco existente/TEMP Windows. Primeira comparação LISP na GUI
  esperava o título da fixture após o Timer aplicar outro: **1 falha do instrumento**, corrigida
  passando título esperado ao harness; reexecução **0 falhas**, sem alterar código do plugin.
  Verificador GUI excedeu o timeout após concluir o retorno; fechamento feito em chamada separada.
  O `acad.exe` saiu com **66960062**, não zero, apesar do Close(false)/Quit concluído e provas
  anteriores aprovadas; não contar encerramento do host como aprovado. Última repetição core
  também excedeu o timeout da ferramenta, mas produziu log completo, marcador **falhas=0** e
  não deixou processo aberto; o exit status dessa repetição não foi recuperado.

## Falta

- [ ] ZWCAD não medido: host não instalado nesta máquina (estado vigente).
- [ ] Desenho novo foi criado/vazio e houve retorno MDI medido, mas abertura do editor sem formato
  e conferência visual da paleta vazia **não foram repetidas** nesta rodada. Conferência: abrir DWG
  novo, mostrar Páginas, verificar grade/atalhos vazios e tentar Editar os Títulos (mensagem 53),
  depois retornar ao projeto e abrir editor novamente. Não alegar auditoria visual nova.
- [ ] Injeção de erro para medir rollback, conservação de colunas e configuração em fixture específica;
  o caminho implementado não chama os métodos que os modificam, mas isso não foi medido separadamente.
- [ ] Investigar saída anômala do AutoCAD GUI (também ocorreu na rodada 183); não bloqueia as
  assertivas concluídas antes do Quit, mas o encerramento continua não aprovado.
- [ ] Demais recortes da rodada 183: Excel ativo, renumeração lote/inline e combo, prompts em
  multiseleção, status de conexão/progresso compartilhado, título 4, D/A/V e todos os atalhos.
  Esta rodada fecha somente a restauração específica, não toda a correção do básico.

## Conhecimento registrado

`conhecimento/paginas.md`: cadeia específica de restauraCampos, efeitos já na abertura, revisão
TextString/último vence e distinção dos efeitos da troca de formato.
