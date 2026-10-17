# Rodada 183 — Páginas e Editar os Títulos fiéis ao reverso

**Data:** 2026-10-15 · **Commit:** *(este)* · **Frente:** correção do básico, item 3 · **Situação:** 🟡 parcial (GUI validada; recortes funcionais abaixo pendentes)

## Alvo

Pedido do dono: ajustar Páginas e Editar os Títulos conforme `paginas.png`, `paginas1.png` e
`editar os títulos.png`. Critérios: nenhuma faixa/coluna/dica inventada; grade Página | Unidade |
Alternativo (este oculto por padrão); faixa superior, quatro atalhos, indicador do banco, progresso e
logo do original; editor não modal 684 × 492 com uma linha por página do corpo, seleção por célula,
títulos existentes no formato, unidade e alternativo; gravação explícita por Editar com lock.
Usar os adapters e o renderizador existentes, sem adicionar dependências.

## O que o reverso faz

Caminhos relativos a `cad-plugin/reverso/Eletron4_ZWcad/decompiled-cleaned/Eletron4/`.

- **Páginas:** `uscPaginas.cs:987-1225`: `dg` em (9,51), margem lateral 9, inferior 52,
  fundo Control, sem cabeçalho de linha, sem redimensionar linhas, seleção de linha inteira,
  multiseleção desligada, scroll vertical. `tbPagina` maiúsculas, máximo 7, `btPagina` Enter_16;
  `lb1..4` com borda, Tahoma 8.25, dois por linha; `btSalva` Record_16 não salva o DWG:
  arma a captura do próximo atalho (`:1510-1610`). Logo `eletron_grande21` e progresso embaixo.
- `uscPaginas.cs:1280-1324,1400-1455,1996-2026`: HKCU Software/Cadgraph/Eletron4, valor `Altern`,
  string `0` por padrão, `1` ligado. Alternativo controla coluna e Editar Alternativo.
  Ordem Página, Unidade, Alternativo, Pg e PgDecimal; as duas últimas invisíveis. Sem Alternativo,
  larguras 2/5 e 3/5; com ele, terços. D/A/V ocultam Alternativo e não têm menu/edição.
- `uscPaginas.cs:1510-1730`: gravar atalho guarda página corrente; clicar ativa, e limpa o atalho
  inexistente. `Dicionario.cs:99-259`: NOD `CENG_ELET` / Xrecord `Atalhos`, **seis** strings DXF 1,
  embora só quatro labels sejam mostrados. Preservar os dois últimos. Leitura sem registro = vazios.
- `uscPaginas.cs:1675-1730,1457-1506`: botão de navegação normaliza número, desliga multiseleção,
  ativa e rola para página existente; inválida retorna à página corrente. Carga seleciona a ativa.
- `uscPaginas.cs:1740-1855`: edição inline renomeia página (exceto primeira linha), grava unidade /
  alternativo; alternativo limitado a 20 e mensagem 1927. Clique de seleção única ativa página.
- `uscPaginas.cs:1238-1270,2600-2614`: progresso iniciar/passo/fim; status do banco usa contador
  de conexões > 0, não a mera existência de arquivo. Não inventar indicador conectado.
- **Editar os Títulos:** menu `uscPaginas.cs:2137` → `frmEditaTitulos`.
  Designer `frmEditaTitulos.cs:421-530`: cliente 684 × 492, grade (12,12), 660 × 468 ancorada
  aos quatro lados, cinza 224, seleção **por célula**, sem botões OK/Cancelar e sem quatro campos.
- Construtor `:533-620`: `Pagina.restauraCampos`, `buscaTitulosExistentes`; sem títulos,
  mensagem 53 `O Formato usado não possui títulos!` e não abre. Abre não modal e seleciona ativa.
- `:623-766`: sete colunas Página | Título 1..4 | Unidade | Alternativo. Página só leitura,
  sem ordenação; títulos ausentes ocultos; Alternativo obedece ao mesmo registro. `wFKiyTSi1h`
  carrega de **índice 2** em diante (a capa não aparece). `Pagina.capturaTitulos`, `Pagina.cs:722`:
  lê **TextString**, não valor armazenado no XData; último texto do mesmo índice vence.
- Menu `:774-914`: Copiar (buffer privado, uma célula), Colar, Limpar, Exportar, Importar,
  DE, PARA, Substituir, Editar. Colar/Limpar/Substituir não alteram Página. Substituir diferencia
  maiúsculas e dá Trim. Colar/Substituir limitam Alternativo a 20; digitação avisa mensagem 1927.
- `RmDiunMFty` = aplicar (`:819-870`): encerra edição, normaliza títulos nulos, copia grade para
  matriz; `Pagina.AtualizaTitulos` (`Pagina.cs:1653-1761`) regrava **todos** os DBText índices 1..4
  e **9** (alternativo), texto + XData `DiagLog/TituloPagina`, sem limite de quatro entidades;
  `clsTextos.AtualizaUnidadeAlternativo` (`clsTextos.cs:1460`) grava XData `Eletron` do layer;
  recarrega paleta e fecha. Fechar pelo X descarta as edições ainda não aplicadas.
- Excel `:883-942`: usa Excel ativo, exporta grade e importa por número da página/índice,
  não por posição de linha. Deve ser medido separadamente se não couber nesta rodada.

### Diferenças encontradas antes de editar

| controle | recoder atual | reverso / alvo |
|---|---|---|
| rodapé | sufixo A, renumerar, recarregar, página ativa | não existe; remover |
| grade | Página, Alternativo, Unidade; PgAtiva; negrito | ordem correta, cinco colunas, fonte regular |
| cabeçalho | ausente | navegação, atalhos, armar captura, status |
| alternativo | ligado, não persistido | registro, padrão desligado |
| dicas | textos de implementação / POSITRON_* | não existem; remover |
| editor | diálogo modal de uma página com T1..4 e OK/Cancelar | grade não modal do caderno, menu e Editar |
| leitura / escrita | valor XData e limite de 4 textos | TextString e todos os títulos + índice 9 |

## O que foi feito

| arquivo | o quê |
|---|---|
| `Positron.Plugin/Interface/Folhas/FolhasControle.cs` | remove rodapé, PgAtiva e negrito; corrige ordem e proporções; faixa superior, navegação, quatro atalhos, progresso e logo; seleção única ativa; unidade/alternativo inline; remove dicas; menu abre a grade de títulos; recarga seleciona ativa e zera multiseleção |
| `Positron.Plugin/Interface/Folhas/PreferenciasDeFolhas.cs` | preferência Altern do registro, padrão desligado, compartilhada pelas duas telas |
| `Positron.Plugin/Paginas/AtalhosDePaginasDoDesenho.cs` | seis strings do Xrecord CENG_ELET/Atalhos, preserva 5/6 e grava com lock |
| `Positron.Plugin/Paginas/PaginaAtivaDoDesenho.cs` | lock na ativação agora chamada fora de comando pela paleta |
| `Positron.Plugin/Interface/Telas/LigacaoDoFrmEditaTitulos.cs` | liga frmEditaTitulos ao renderizador existente: grade do corpo, visibilidade por formato, sete colunas, buffer privado, colar/limpar/substituir e aplicar pelo menu; fecha sem aplicar ao trocar de documento |
| `Positron.Plugin/Paginas/TitulosDaPaginaDoDesenho.cs` | LerGrade pelo TextString e GravarGrade de todos os textos 1..4/9, sem mudar o contrato da edição individual usada por outros comandos |
| `Positron.Plugin/Interface/Telas/LigacoesDasTelas.cs` | registra a 21ª tela ligada |
| `Positron.Plugin/Interface/Folhas/FormularioDaPagina.cs` | remove o diálogo modal de quatro títulos inventado; mantém a pergunta de unidade/alternativo existente |
| `Positron.Data/Paginas/EdicaoDaGradeDeTitulos.cs` | operações puras de células; protege Página, Trim e limite 20 apenas em Alternativo |
| `Positron.Data.Tests/EdicaoDaGradeDeTitulosTests.cs` | +12 casos |
| `Positron.Plugin/Interface/Folhas/ProvaDaPaleta.cs` | prova da grade/menu, captura e prova agendada por Timer fora de comando (esta última ainda não executada com sucesso) |
| `scripts/cad-fixture-titulos.lsp` | cinco títulos duplicados + alternativo índice 9; dump independente de TextString/XData/layer |

**Desvios/recortes explícitos:**

- O menu Renumerar Páginas foi **desabilitado**, não trocado por RENPAGA: o código antigo aplicava
  sufixo a todo o caderno e não era o C8Op1CM1YgS do original. O combo de largura continua sem handler.
- Excel Exportar/Importar presentes mas desabilitados; não há ponte Excel implementada nesta rodada.
- O editor fecha ao trocar de DWG em vez de permitir que uma grade capturada de um documento seja
  aplicada em outro. É uma guarda de segurança para a janela modeless, não uma alegação do original.
- O quirk do designer que esconde coluna 3 quando falta título 2 não foi replicado: cada coluna fica
  visível pelo seu próprio título. A captura real (títulos 1/2/3) não cai nesse ramo.
- Indicador do banco nasce desconectado; não inventa conexão a partir do caminho de um arquivo.
  Falta ligar ao contador real de conexões, que o recoder ainda não expõe.
- Não foi executada a cadeia destrutiva `Pagina.restauraCampos` ao abrir o editor: o adapter existente
  de troca de formato também mexe em colunas, revisões e ativa capa; reutilizá-lo inteiro aqui seria
  incorreto. A grade atual lê os campos existentes. Portar o caminho específico fica pendente.

## Prova

- `npm run plugin:test`: o adaptador VSTest falhou ao carregar e rodou **zero** testes (não é passe).
  Console xUnit 2.9.2, cópia do bin inteiro fora do Desktop: **941**, +12, Errors 0, Failed 0,
  Skipped 0; segunda execução 4,017 s.
- Builds finais ZWCAD / AutoCAD contra APIs reais: **0 avisos, 0 erros**, 1,38 s / 1,51 s.
- Cobertura: 78 manuais, 115 gerados, 48 ausentes, **21** telas ligadas (antes 20).
- AutoCAD 2020 **accoreconsole**, cópia do Funcional.dwg e fixture (a interface não foi mostrada):

```
Editar os Títulos: 15 página(s) na grade; capa excluída.
Editar os Títulos: 15 página(s), 51 texto(s) regravado(s).
pzFolhas: 16 página(s) ... ação "titulos" → 15 linha(s);
colunas [Página | Título 1 | Título 2 | Título 3 | Unidade]; Editar DWG pelo menu; fechou=True;
interface: 5 colunas [Página | Unidade]; tbPagina=2; multiseleção=False; controles=11
```

Dump LISP independente, página 2: **seis** textos índice 1 (o original + cinco duplicados) com
`texto=RODADA 183;xdata=RODADA 183`; índice 9 `texto=ALT183;xdata=ALT183`; layer Eletron/Unidade
`UNIDADE 183`, `ALT183`. Índices 6/8 não foram substituídos pelo editor. Antes eram
`TEXTO VISIVEL 183` / `XDATA ANTIGO` na fixture; todos os duplicados foram regravados, não só quatro.

- Desenho vazio no core: **0** páginas, tbPagina vazio; mensagem 53 e editor descartado.
  As execuções paralelas do harness usaram o mesmo carimbo de segundo e misturaram o arquivo de log;
  o ensaio final do projeto foi repetido isoladamente. Não usar esse log misturado como prova de MDI.
- **Não medido: interface cheia, clique real, gravação fora de comando e troca MDI.** A tentativa
  `.tmp-smoke/r183-gui.ps1` não encontrou instância AutoCAD pelo COM (`MK_E_UNAVAILABLE`, 0x800401E3);
  o acad.exe não ficou rodando. O Timer `POSITRON_FOLHA_ACAO=interface` não chegou a executar.
- `DrawToBitmap` no core gerou imagens **incompletas**: paleta sem alguns controles superiores,
  editor vazio apesar de a grade ter 15 linhas no log. Não são capturas válidas da tela entregue e
  **não** provam fidelidade visual; foram mantidas apenas em `.tmp-smoke/r183-imagens` (ignorado).

### Complemento — validação visual concluída em 2026-10-15

A limitação de GUI relatada acima foi resolvida nesta continuação: executar `acad.exe /nologo
<cópia.dwg>` e **manter o processo de lançamento vivo** com `WaitForExit` no job BACKGROUND.
O script anterior terminava e a limpeza do job podia encerrar a árvore do AutoCAD. Nesta execução
houve janela visível, COM disponível, interação por mouse/teclado e capturas por `CopyFromScreen`.
O `setenv` do AutoLISP não alterou as variáveis lidas por `Environment.GetEnvironmentVariable` nesta
sessão; o harness funcionou quando `POSITRON_*` foi definido antes de iniciar o CAD.

**Reparos encontrados pela conferência:** o combo da numeração estava visualmente vazio; agora
`Carregar` mostra `12` / `012` / ... conforme `LarguraFixaPaginas` (uscPaginas.cs:1336-1360), sem
alegar implementar sua ação de renumerar. O resumo do Timer contava linhas após fechar o form
(0); agora captura o total antes do fechamento (**15**).

**Resultado na DLL final (build 23:00):**

```
pzFolhas UI: interface: 5 colunas [Página | Unidade]; tbPagina=23; multiseleção=False; controles=11
pzFolhas UI: PASSOU — navegação pelo botão, atalho Xrecord, menu Editar Títulos, 15 linha(s),
edição local sem gravação antecipada; Editar DWG fora de comando; texto e XData confirmados.
```

- Paleta visível com os 11 controles, quatro labels, campo de página, ícones, grade, logo e barra.
  Sem PgAtiva/negrito/rodapé extra; seleção única e proporções 2/5–3/5. Combo **12** confirmado no menu.
- Editor visível com **15** páginas (capa fora), títulos 1/2/3, Unidade; título 4 ausente oculto;
  Alternativo aparece nas **duas telas** ao ligar a preferência pelo menu. Preferência devolvida
  ao estado desligado pelo próprio menu após a prova.
- Mouse + teclado reais: primeira célula foi alterada para `DESCARTAR UI`, fechada pelo **X** e
  reaberta com `PROVA UI 183` (valor aplicado anteriormente pelo Timer). Em seguida foi digitado
  `CLIQUE UI 183`, acionado **Editar DWG** por clique e reaberto com esse valor persistido no DWG.
- Novo `Drawing1.dwg`: paleta **vazia**, tbPagina e quatro atalhos vazios; editor anterior fechado.
  Retorno ao projeto: **16** páginas e atalho 1=`2` recuperados. A página corrente do retorno foi
  `7` no último ensaio; a paleta a acompanhou corretamente, sem forçar a página do harness.
- Cópia e desenho novo fechados **sem salvar**, instância de teste encerrada. Original intocado.
  O script COM completou `Close(false)`/`Quit`, mas o processo acad.exe terminou com código
  **51100350**, não zero: encerramento anômalo do host, não contado como gate de saída aprovado.
  As capturas/assertivas ocorreram antes do Quit e comprovam os fluxos descritos; investigar a
  saída anômala permanece uma limitação operacional.
- Builds após os dois reparos: ZWCAD **0 avisos/0 erros**, 2,92 s; AutoCAD **0 avisos/0 erros**,
  1,51 s. Regra pura/testes não alterados nesta continuação: os **941** aprovados continuam a
  referência; não foi repetida a suíte só por mudança do texto do combo e do contador do harness.
- Capturas recortadas do desktop real em `docs/recoder/provas/183-paginas/`: `paginas-menu.png`,
  `editar-titulos-descarte.png`, `editar-titulos-aplicado.png`, `editar-titulos-alternativo.png`,
  `paginas-dwg-novo.png`, `paginas-retorno.png`. Não são os PNGs incompletos do core.
  `resumo-gui.txt` preserva as duas passagens do Timer, inclusive o contador 0 anterior ao reparo.
- Diferenças de host visíveis: ícone AutoCAD/título em caixa alta do PaletteSet e borda nativa do
  Windows; não alterados para imitar a janela do ZWCAD. O menu Renumerar e Excel seguem desabilitados
  conforme o recorte já declarado. Isso **não** fecha a rodada funcional inteira.

## Falta

- [x] Validação visual em **AutoCAD 2020 visível**, cópia do Funcional.dwg: paleta, navegação,
  captura do lb1, editor via menu, digitação, descarte pelo X, aplicação por clique, Alternativo
  ligado/desligado e novo documento/retorno. Evidências e limites na subseção abaixo.
- [x] Prova Timer fora de comando: **PASSOU**, 15 linhas; título/unidade/alternativo relidos.
  Os quatro slots e os atalhos 5/6 ainda não foram exercitados individualmente.
- [ ] Repetir no ZWCAD — ausente nesta máquina (medido; a ausência é uma medição com data: `RUNBOOK.md` → *Existe CAD nesta máquina?*).
- [ ] `Pagina.restauraCampos` específico do editor (sem efeitos da troca de formato).
- [ ] Excel ativo: Exportar/Importar por página/índice (`clsTextos.ExportaPaginas/ImportaTitulos`).
- [ ] Paleta: C8Op1CM1YgS (Renumerar lote), renomear página inline (primeira protegida), combo de
  largura e persistência XData; status ligado ao contador de conexões; progresso compartilhado
  pelas rotinas longas (a barra atual acompanha a carga local).
- [ ] Editar Unidade/Alternativo do menu ainda usa diálogo existente, não o PromptStringOptions do
  reverso; a edição inline já grava, mas faltam a equivalência do prompt e aplicação em todas as
  linhas selecionadas (a rodada não deve ser considerada auditoria completa desses comandos).
- [ ] Validar título 4 presente, documentos D/A/V e os seis atalhos em GUI (Alternativo ligado e
  título 4 ausente já conferidos no projeto real).

## Conhecimento registrado

`docs/recoder/conhecimento/paginas.md`: grade de títulos distinta da edição individual, leitura pelo
TextString, índice 9, sem limite de quatro; sem capa; sem gravação antecipada; registro Altern,
Xrecord de seis atalhos e significado real do btSalva.
