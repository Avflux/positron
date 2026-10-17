using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Positron.Plugin.Interface.Telas;
using Positron.Data;
using Positron.Data.Interface.Mapas;
using Positron.Plugin.Paginas;
using Positron.Data.Paginas;

namespace Positron.Plugin.Interface.Folhas
{
    /// <summary>
    /// A **prova do caminho da paleta** — o que o comando <c>pzFolhas</c> roda. Monta o
    /// <see cref="FolhasControle"/> e chama o **mesmo** handler que o clique do menu e a tecla
    /// chamam, sem passar pela interface: é o caminho do usuário sem o clique (que um script não dá).
    ///
    /// A entrada é toda do harness, e **só** daqui: <c>POSITRON_FOLHA_ACAO</c> (<c>nova</c>,
    /// <c>inserir:N</c>, <c>apagar</c>, <c>multiselecao</c>, <c>renumerar</c>, <c>formato:LITERAL</c>,
    /// <c>inline</c>, <c>inline-evento</c>, <c>banco</c>, <c>progresso</c>; sem ela o comando só
    /// despeja o estado), <c>POSITRON_FOLHA_SELECAO</c> (a linha
    /// selecionada; o padrão é <c>POSITRON_PAGINA</c>), <c>POSITRON_FOLHA_SELECIONADAS</c> (as linhas
    /// selecionadas, separadas por vírgula) e <c>POSITRON_FOLHA_INLINE</c> (o texto que a edição
    /// inline da célula Página digita; ausente é a célula vazia).
    /// </summary>
    internal static class ProvaDaPaleta
    {
        internal static string Executar()
        {
            try
            {
                if (Environment.GetEnvironmentVariable("POSITRON_FOLHA_ACAO") == "campos-interface")
                {
                    Timer timer = new Timer { Interval = 1500 };
                    timer.Tick += (origem, evento) =>
                    {
                        timer.Stop();
                        timer.Dispose();
                        try
                        {
                            PaletaDeFolhas.Mostrar();
                            ProvarCampos(PaletaDeFolhas.Controle, true);
                        }
                        catch (Exception erro) { Plugin.Escrever("CAMPOS185: FALHOU — " + erro); }
                    };
                    timer.Start();
                    return "pzFolhas: prova de campos agendada fora de comando.";
                }
                if (Environment.GetEnvironmentVariable("POSITRON_FOLHA_ACAO") == "interface")
                {
                    AgendarProvaDaInterface();
                    return "pzFolhas: prova agendada fora de comando (Timer da interface).";
                }
                if (Environment.GetEnvironmentVariable("POSITRON_FOLHA_ACAO") == "renumerar-interface")
                {
                    AgendarRenumeracaoPelaInterface();
                    return "pzFolhas: prova da renumeração agendada fora de comando (Timer da interface).";
                }
                if (Environment.GetEnvironmentVariable("POSITRON_FOLHA_ACAO") == "clique-inline")
                {
                    AgendarCliqueNaCelula();
                    return "pzFolhas: clique físico na célula Página agendado fora de comando.";
                }
                if (Environment.GetEnvironmentVariable("POSITRON_FOLHA_ACAO") == "clique-atalhos")
                {
                    AgendarCliqueNosAtalhos();
                    return "pzFolhas: cliques físicos nos atalhos agendados fora de comando.";
                }
                if (Environment.GetEnvironmentVariable("POSITRON_FOLHA_ACAO") == "aviso")
                {
                    AgendarProvaDosAvisos();
                    return "pzFolhas: prova dos diálogos de aviso agendada fora de comando.";
                }
                FolhasControle controle = new FolhasControle();
                int paginas = controle.Carregar();

                string selecao = Environment.GetEnvironmentVariable("POSITRON_FOLHA_SELECAO");
                if (string.IsNullOrEmpty(selecao))
                {
                    selecao = Environment.GetEnvironmentVariable("POSITRON_PAGINA");
                }

                string selecionadas = Environment.GetEnvironmentVariable("POSITRON_FOLHA_SELECIONADAS");
                List<string> linhas = new List<string>();
                if (!string.IsNullOrEmpty(selecionadas))
                {
                    foreach (string parte in selecionadas.Split(','))
                    {
                        if (!string.IsNullOrEmpty(parte.Trim()))
                        {
                            linhas.Add(parte.Trim());
                        }
                    }

                    // Mais de uma página pedida é o usuário que ligou a `Multiseleção` no menu para
                    // poder marcar as linhas (no `Inserir` de colunas ou no `Apagar Páginas`).
                    if (linhas.Count > 1)
                    {
                        controle.Multiselecao = true;
                    }
                }
                else if (!string.IsNullOrEmpty(selecao))
                {
                    linhas.Add(selecao);
                }

                int achadas = controle.Selecionar(linhas);

                string acao = (Environment.GetEnvironmentVariable("POSITRON_FOLHA_ACAO") ?? string.Empty).Trim().ToLowerInvariant();
                string resultado = "(sem ação: só o estado da grade)";

                if (acao == "campos")
                {
                    ProvarCampos(controle, false);
                    resultado = "PASSOU — campos pelo menu";
                }
                else if (acao == "restaurar")
                {
                    Dictionary<string, TitulosDaPagina> antes = TitulosDaPaginaDoDesenho.LerGrade();
                    List<RevisaoSimplificadaDaPagina> revisoes = RevisoesDoDesenho.LerSimplificadas();
                    string ativa = PaginaAtivaDoDesenho.Ler();
                    for (int passagem = 0; passagem < 2; passagem++)
                    {
                        using (Form janela = RenderizadorDeTelas.Montar(FormulariosDoReverso.Buscar("frmEditaTitulos")))
                        {
                            Dictionary<string, TitulosDaPagina> depois = TitulosDaPaginaDoDesenho.LerGrade();
                            foreach (KeyValuePair<string, TitulosDaPagina> par in antes)
                                for (int i = 1; i <= 4; i++)
                                    if ((par.Value.De(i) ?? "") != (depois[par.Key].De(i) ?? ""))
                                        throw new InvalidOperationException("Restauração alterou título " + i + " da página " + par.Key);
                            List<RevisaoSimplificadaDaPagina> novas = RevisoesDoDesenho.LerSimplificadas();
                            if (revisoes.Count != novas.Count) throw new InvalidOperationException("Quantidade de revisões alterada");
                            for (int i = 0; i < revisoes.Count; i++)
                                if (revisoes[i].Pagina != novas[i].Pagina || revisoes[i].Revisao != novas[i].Revisao)
                                    throw new InvalidOperationException("Revisão simplificada alterada");
                            if (ativa != PaginaAtivaDoDesenho.Ler()) throw new InvalidOperationException("Página ativa alterada");
                        }
                    }
                    resultado = "PASSOU — duas aberturas/descarte; títulos de " + antes.Count
                        + " página(s), " + revisoes.Count + " revisões e página ativa preservados";
                }
                else if (acao == "titulos")
                {
                    // A prova do título 4: o atributo TITULO4PAG no formato (o `Funcional.dwg`
                    // só tem 1..3), pela API do CAD — o ActiveX do AutoLISP não tem
                    // `AddAttribute` nesta versão (medido).
                    if (Environment.GetEnvironmentVariable("POSITRON_FOLHA_TITULO4") == "1")
                    {
                        Plugin.Escrever("CLIQUE222: formato — " + Titulo4DaProva.Acrescentar());
                    }

                    using (Form janela = RenderizadorDeTelas.Montar(FormulariosDoReverso.Buscar("frmEditaTitulos")))
                    {
                        if (janela.IsDisposed) resultado = "sem títulos no formato; janela não aberta";
                        else
                        {
                            DataGridView grade = ControlesDaTela.Achar<DataGridView>(janela, "dg");
                            List<string> visiveis = new List<string>();
                            foreach (DataGridViewColumn coluna in grade.Columns)
                                if (coluna.Visible) visiveis.Add(coluna.HeaderText);
                            resultado = grade.Rows.Count + " linha(s); colunas [" + string.Join(" | ", visiveis.ToArray()) + "]";
                            string alvo = Environment.GetEnvironmentVariable("POSITRON_PAGINA");
                            foreach (DataGridViewRow linha in grade.Rows)
                            {
                                if (!string.Equals(Convert.ToString(linha.Cells[0].Value), alvo, StringComparison.OrdinalIgnoreCase)) continue;
                                resultado += "; linha " + alvo + " = [T1 \"" + Convert.ToString(linha.Cells[1].Value)
                                    + "\" | T2 \"" + Convert.ToString(linha.Cells[2].Value)
                                    + "\" | T3 \"" + Convert.ToString(linha.Cells[3].Value)
                                    + "\" | T4 \"" + Convert.ToString(linha.Cells[4].Value) + "\"]";
                            }
                            foreach (DataGridViewRow linha in grade.Rows)
                            {
                                if (Convert.ToString(linha.Cells[0].Value) != alvo) continue;
                                for (int i = 1; i <= 4; i++)
                                {
                                    string valor = Environment.GetEnvironmentVariable("POSITRON_TITULO" + i);
                                    if (valor != null) linha.Cells[i].Value = valor;
                                }
                                string unidade = Environment.GetEnvironmentVariable("POSITRON_UNIDADE");
                                if (unidade != null) linha.Cells[5].Value = unidade;
                                string alternativo = Environment.GetEnvironmentVariable("POSITRON_ALTERNATIVO");
                                if (alternativo != null) linha.Cells[6].Value = EdicaoDaGradeDeTitulos.Limitar(6, alternativo);
                            }
                            Capturar(janela, "editar-os-titulos");
                            foreach (ToolStripItem item in grade.ContextMenuStrip.Items)
                                if (item.Text == "Editar DWG") item.PerformClick();
                            resultado += "; Editar DWG pelo menu; fechou=" + janela.IsDisposed;
                            Plugin.Escrever("CLIQUE222: títulos — " + resultado);
                            string esperado = Environment.GetEnvironmentVariable("POSITRON_TITULO1");
                            if (esperado != null && TitulosDaPaginaDoDesenho.LerGrade()[alvo].Titulo1 != esperado)
                                throw new InvalidOperationException("Título gravado difere do pedido");
                        }
                    }
                }
                else if (acao == "banco")
                {
                    // O status do banco pelo **contador de conexões** — o `monitorConexao` que o
                    // `AcessoSQLite` incrementa ao abrir e decrementa no `fechaConexao`
                    // (`AcessoSQLite.cs:99-104,33-43`) e o `statusBanco` que troca o ícone
                    // (`uscPaginas.cs:2606-2617`).
                    //
                    // A primeira medida é o **caminho real**: sem `POSITRON_DWG` (variável que só
                    // existe no harness) a carga da paleta resolve o índice do DWG pelo banco do
                    // projeto — o `ConfiguracaoEfetiva.IndiceDoDwg` lê a tabela `DWG` e a conexão
                    // abre e fecha **dentro** da própria carga.
                    string dwgDoHarness = Environment.GetEnvironmentVariable("POSITRON_DWG");
                    bool inicial = controle.BancoConectado();
                    List<string> duranteACarga = new List<string>();
                    EventHandler observadorCarga = (origem, evento) =>
                        duranteACarga.Add(controle.BancoConectado() ? "conectado" : "desconectado");
                    MonitorDeConexao.Atual.Mudou += observadorCarga;
                    try
                    {
                        Environment.SetEnvironmentVariable("POSITRON_DWG", null);
                        controle.Carregar();
                    }
                    finally
                    {
                        MonitorDeConexao.Atual.Mudou -= observadorCarga;
                        Environment.SetEnvironmentVariable("POSITRON_DWG", dwgDoHarness);
                    }

                    bool depoisDaCarga = controle.BancoConectado();

                    // A segunda, com resultado visível: a leitura direta do banco do projeto com o
                    // ícone acompanhando o contador.
                    string banco = ConfiguracaoEfetiva.Carregar().Banco;
                    List<string> duranteALeitura = new List<string>();
                    EventHandler observadorLeitura = (origem, evento) =>
                        duranteALeitura.Add(controle.BancoConectado() ? "conectado" : "desconectado");
                    int dwgs;
                    int paineis;
                    MonitorDeConexao.Atual.Mudou += observadorLeitura;
                    try
                    {
                        ProjectStore loja = new ProjectStore(banco);
                        dwgs = loja.LerNomesDeDwgs().Count;
                        paineis = loja.LerIndicesDePaineis().Count;
                    }
                    finally
                    {
                        MonitorDeConexao.Atual.Mudou -= observadorLeitura;
                    }

                    // A terceira: o `monitorConexao = 0` + `statusBanco("0")` do `IniciarDWG`
                    // (`Iniciar.cs:178-179`), que roda em toda ativação de documento. O
                    // `accoreconsole` não abre um segundo documento, então o caminho é exercitado
                    // chamando o **mesmo** `Iniciar()` que o `DocumentActivated` chama
                    // (`InicioDoDesenho.AoAtivar`).
                    MonitorDeConexao.Atual.Incrementar();
                    bool solta = controle.BancoConectado();
                    Positron.Plugin.InicioDoDesenho.Iniciar();
                    int depoisDoIniciar = MonitorDeConexao.Atual.Abertas;
                    bool iconeDepoisDoIniciar = controle.BancoConectado();

                    resultado = "banco \"" + banco + "\": ícone inicial=" + Estado(inicial)
                        + "; carga da paleta sem POSITRON_DWG → " + duranteACarga.Count + " aviso(s) ["
                        + string.Join(" | ", duranteACarga.ToArray()) + "], depois=" + Estado(depoisDaCarga)
                        + "; leitura direta = " + dwgs + " DWG(s) e " + paineis + " painel(is), avisos ["
                        + string.Join(" | ", duranteALeitura.ToArray()) + "], agora="
                        + Estado(controle.BancoConectado())
                        + "; conexão aberta fora do par → ícone=" + Estado(solta)
                        + "; depois do IniciarDWG: contador=" + depoisDoIniciar
                        + ", ícone=" + Estado(iconeDepoisDoIniciar);
                }
                else if (acao == "progresso")
                {
                    // A **barra compartilhada** no caminho real: os comandos que o usuário digita
                    // (`SYNCD`, `SYNCV`, `RESTPROJ`) movem o `ProgressBar1` **da paleta do
                    // arranque** — o mesmo objeto que as rotinas alcançam (`PaletaDeFolhas`, o
                    // `DeclaracoesGeral._uscPagina` do original). Um controle montado aqui seria
                    // outra instância e não veria nada: a leitura é no singleton.
                    PaletaDeFolhas.Mostrar();
                    FolhasControle paleta = PaletaDeFolhas.Controle;
                    if (paleta == null)
                    {
                        throw new InvalidOperationException("A paleta não existe nesta sessão.");
                    }

                    ProgressBar barra = (ProgressBar)paleta.Controls["ProgressBar1"];
                    // A **exportação dos títulos** pelo menu (o `clsTextos.ExportaPaginas`): é a
                    // rotina longa cujo `Quantidade` é o do original (`dg.RowCount - 1`). Vem
                    // **primeiro** porque é onde se vê o `pbPasso` antes do `pbIniciar` numa barra
                    // que ainda não foi usada (0..100, os padrões do `ProgressBar`).
                    string exportacao = "(sem exportação: `POSITRON_TITULOS_EXCEL` ausente)";
                    if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("POSITRON_TITULOS_EXCEL")))
                    {
                        exportacao = MedirABarra(paleta, barra, () =>
                        {
                            using (Form editor = RenderizadorDeTelas.Montar(
                                FormulariosDoReverso.Buscar("frmEditaTitulos")))
                            {
                                // O `GanchoDoHarness` do `LigacaoDoFrmEditaTitulos` roda a
                                // exportação na abertura da janela.
                            }
                        });
                    }

                    string sincd = MedirABarra(paleta, barra, () => new Comandos().SincD());
                    string sincv = MedirABarra(paleta, barra, () => new Comandos().SincV());
                    string restproj = MedirABarra(paleta, barra, () => new Comandos().RestaurarProjeto());

                    // O esperado do `SYNCD` (o `Quantidade = 6` do original, aqui os quatro passos
                    // do pipeline): faixa 0..4 e estado 2 (`PBST_ERROR`, a barra vermelha do
                    // `pbIniciar`), um passo por passo, e o `pbFim` devolvendo a faixa a 0..0.
                    const string esperadoDoSincD =
                        "0..4=0, estado 2 | 0..4=1, estado 2 | 0..4=2, estado 2 | 0..4=3, estado 2 | 0..4=4, estado 2 | 0..0=0, estado 2";
                    if (sincd != esperadoDoSincD)
                    {
                        throw new InvalidOperationException("A barra do SYNCD saiu diferente do esperado: " + sincd);
                    }

                    resultado = "barra da paleta (ProgressBar1) — exportação dos títulos → " + exportacao
                        + "; SYNCD → " + sincd + "; SYNCV → " + sincv + "; RESTPROJ → " + restproj
                        + "; compartilhada com o controle: " + ReferenceEquals(PaletaDeFolhas.Progresso, paleta.Progresso);
                }
                else if (acao == "ler-titulos")
                {
                    Dictionary<string, TitulosDaPagina> capturados = TitulosDaPaginaDoDesenho.LerGrade();
                    string alvo = Environment.GetEnvironmentVariable("POSITRON_PAGINA") ?? "2";
                    resultado = "TextString capturado=" + (capturados.ContainsKey(alvo) ? capturados[alvo].Titulo1 : "ausente");
                }
                else if (acao == "ir")
                {
                    controle.IrParaPagina(selecao);
                    resultado = "página ativa=" + PaginaAtivaDoDesenho.Ler();
                }
                else if (acao == "multiselecao")
                {
                    controle.Multiselecao = true;
                    resultado = controle.NovaPagina();
                }
                else if (acao == "nova")
                {
                    resultado = controle.NovaPagina();
                }
                else if (acao == "apagar")
                {
                    resultado = controle.ApagarSelecionadas();
                }
                else if (acao == "renumerar")
                {
                    // O caminho do usuário: o **clique no item do menu** (não a chamada direta do
                    // handler) — é o que prova que o item está habilitado e ligado à regra.
                    DataGridView grade = (DataGridView)controle.Controls["dg"];
                    ToolStripMenuItem item = null;
                    if (grade.ContextMenuStrip != null)
                    {
                        foreach (ToolStripItem candidato in grade.ContextMenuStrip.Items)
                        {
                            if (candidato.Text == Positron.Data.Interface.MensagensDoReverso.RenumerarPaginas)
                            {
                                item = candidato as ToolStripMenuItem;
                            }
                        }
                    }

                    if (item == null)
                    {
                        // Documentos D/A/V não ganham menu no reverso (`dg.ContextMenuStrip = null`
                        // no `VSWp1ebyWra`): não inventar o clique de um item que o usuário não vê.
                        resultado = grade.ContextMenuStrip == null
                            ? "sem menu (documento D/A/V ou sem páginas) — nada a clicar"
                            : "o menu não tem o item \"" + Positron.Data.Interface.MensagensDoReverso.RenumerarPaginas + "\"";
                        Plugin.Escrever("RENUM186: " + resultado);
                        Capturar(controle, "paginas");
                        return "pzFolhas: " + controle.Paginas().Count + " página(s) na grade "
                            + Lista(controle.Paginas()) + "; combo=\"" + controle.FormatoDaNumeracao()
                            + "\"; ação \"renumerar\" → " + resultado + "; " + controle.DescreverInterface();
                    }

                    if (!item.Enabled)
                    {
                        throw new InvalidOperationException("O item \""
                            + Positron.Data.Interface.MensagensDoReverso.RenumerarPaginas + "\" está desabilitado.");
                    }

                    item.PerformClick();
                    resultado = "clique no menu → " + controle.UltimaMensagem;
                }
                else if (acao == "sonda-renomear")
                {
                    // Isola o `Pagina.alteraNomeLayer` (o `LayerTableRecord.Name = novo` da
                    // `PaginasDoDesenho.Renomear`) da camada corrente: o que a edição inline da
                    // célula Página faz no meio. Serve para saber de quem é o efeito no `CLAYER`.
                    string camadaAntes = PaginaAtivaDoDesenho.LerCamadaCorrente();
                    string camadaNova = camadaAntes + "Z";
                    int ida = PaginasDoDesenho.Renomear(new[] { camadaAntes }, new[] { camadaNova });
                    string camadaDepois = PaginaAtivaDoDesenho.LerCamadaCorrente();
                    int volta = PaginasDoDesenho.Renomear(new[] { camadaNova }, new[] { camadaAntes });
                    resultado = "rename \"" + camadaAntes + "\" → \"" + camadaNova + "\" = " + ida
                        + "; camada corrente \"" + camadaAntes + "\" → \"" + camadaDepois + "\""
                        + "; volta = " + volta + ", camada corrente \"" + PaginaAtivaDoDesenho.LerCamadaCorrente() + "\"";
                }
                else if (acao == "tipo-d")
                {
                    // O documento tipo D (o `verificaTipoXData` pelo ModelSpace): o paleta esconde o
                    // Alternativo e a grade fica sem menu e somente leitura (`uscPaginas.cs:1434,1483`).
                    // O tipo vem do **desenho aberto** — a fixture põe o DiagLog no ModelSpace de um
                    // desenho novo (`vla-SetXData`), porque trocar o Eletron de um existente não pega.
                    string antes = TipoDoDesenhoDaProva.Agora();
                    string depois = antes;
                    // A paleta de verdade (o `PaletteSet`), carregada com o tipo já no lugar.
                    PaletaDeFolhas.Mostrar();
                    controle = PaletaDeFolhas.Controle;
                    int paginasDoTipoD = controle.Carregar();
                    DataGridView grade = (DataGridView)controle.Controls["dg"];
                    List<string> visiveis = new List<string>();
                    foreach (DataGridViewColumn coluna in grade.Columns)
                        if (coluna.Visible) visiveis.Add(coluna.HeaderText);
                    if (!TipoDoDesenhoDaProva.ForaDoEletron(depois))
                        throw new InvalidOperationException("O desenho não é D/A/V: tipo \"" + depois + "\".");
                    if (grade.ContextMenuStrip != null)
                        throw new InvalidOperationException("Documento D ainda com menu na grade.");
                    if (!grade.ReadOnly)
                        throw new InvalidOperationException("Documento D com a grade editável.");
                    if (grade.Columns[2].Visible)
                        throw new InvalidOperationException("Documento D mostrando a coluna Alternativo.");
                    resultado = "tipo " + antes + " → " + depois + "; " + paginasDoTipoD + " página(s); menu=ausente"
                        + "; grade=somente leitura; colunas [" + string.Join(" | ", visiveis.ToArray()) + "]";
                    Capturar(controle, "tipo-d");
                    Plugin.Escrever("CLIQUE222: " + resultado);
                }
                else if (acao == "inline")
                {
                    // A edição inline da célula Página (o ramo `ColumnIndex == 0` do `j9Sp1mKZkcD`,
                    // `uscPaginas.cs:1733-1846`): o harness escreve o texto que o usuário digitaria
                    // e chama o **mesmo** método que o `CellEndEdit` da grade dispara.
                    DataGridView grade = (DataGridView)controle.Controls["dg"];
                    string valor = Environment.GetEnvironmentVariable("POSITRON_FOLHA_INLINE");
                    if (valor == null)
                    {
                        valor = string.Empty;
                    }

                    string alvoInline = linhas.Count > 0 ? linhas[0] : string.Empty;
                    int indice = -1;
                    for (int i = 0; i < grade.Rows.Count; i++)
                    {
                        if (string.Equals(Convert.ToString(grade.Rows[i].Cells[0].Value), alvoInline, StringComparison.OrdinalIgnoreCase))
                        {
                            indice = i;
                        }
                    }

                    if (indice < 0)
                    {
                        throw new InvalidOperationException("Linha \"" + alvoInline + "\" ausente para a edição inline.");
                    }

                    grade.Rows[indice].Cells[0].Value = valor;
                    string camadaAntesInline = PaginaAtivaDoDesenho.LerCamadaCorrente();
                    string resumo = controle.RenomearPaginaInline(indice);
                    string camadaDepoisInline = PaginaAtivaDoDesenho.LerCamadaCorrente();
                    string celula = indice < grade.Rows.Count
                        ? Convert.ToString(grade.Rows[indice].Cells[0].Value)
                        : string.Empty;
                    resultado = "edição inline \"" + valor + "\" na linha " + indice + " (página " + alvoInline
                        + ") → " + resumo + "; célula=\"" + celula + "\""
                        + "; camada corrente \"" + camadaAntesInline + "\" → \"" + camadaDepoisInline + "\"";
                }
                else if (acao == "inline-evento")
                {
                    // O **evento real** da grade (o `CellEndEdit` do WinForms) e não o método por trás
                    // dele: é o recorte que a rodada 212 não conseguiu medir (o `accoreconsole` não
                    // tinha janela onde a grade entrasse em edição). A grade vai para um formulário
                    // fora da tela, entra em edição e **confirma** — o evento dispara como no clique.
                    DataGridView grade = (DataGridView)controle.Controls["dg"];
                    string valor = Environment.GetEnvironmentVariable("POSITRON_FOLHA_INLINE");
                    if (valor == null)
                    {
                        valor = string.Empty;
                    }

                    string alvoEvento = linhas.Count > 0 ? linhas[0] : string.Empty;
                    int indice = -1;
                    for (int i = 0; i < grade.Rows.Count; i++)
                    {
                        if (string.Equals(Convert.ToString(grade.Rows[i].Cells[0].Value), alvoEvento, StringComparison.OrdinalIgnoreCase))
                        {
                            indice = i;
                        }
                    }

                    if (indice < 0)
                    {
                        throw new InvalidOperationException("Linha \"" + alvoEvento + "\" ausente para o evento.");
                    }

                    bool entrou;
                    bool fim;
                    using (Form hospedeiro = new Form())
                    {
                        hospedeiro.ShowInTaskbar = false;
                        hospedeiro.FormBorderStyle = FormBorderStyle.None;
                        hospedeiro.StartPosition = FormStartPosition.Manual;
                        hospedeiro.Location = new System.Drawing.Point(-3000, -3000);
                        hospedeiro.Size = new System.Drawing.Size(260, 520);
                        hospedeiro.Controls.Add(controle);
                        hospedeiro.Show();
                        System.Windows.Forms.Application.DoEvents();

                        grade.CurrentCell = grade.Rows[indice].Cells[0];
                        entrou = grade.BeginEdit(true);
                        if (entrou && grade.EditingControl != null)
                        {
                            grade.EditingControl.Text = valor;
                        }

                        fim = grade.EndEdit();
                        System.Windows.Forms.Application.DoEvents();
                        hospedeiro.Controls.Remove(controle);
                        hospedeiro.Close();
                    }

                    string celula = indice < grade.Rows.Count
                        ? Convert.ToString(grade.Rows[indice].Cells[0].Value)
                        : string.Empty;
                    resultado = "evento real (CellEndEdit): BeginEdit=" + entrou + "; EndEdit=" + fim
                        + "; edição inline \"" + valor + "\" na página " + alvoEvento + " → "
                        + controle.UltimaMensagem + "; célula=\"" + celula + "\"";
                }
                else if (acao.StartsWith("formato", StringComparison.Ordinal))
                {
                    string literal = "012";
                    int doisPontos = acao.IndexOf(':');
                    if (doisPontos > 0)
                    {
                        literal = acao.Substring(doisPontos + 1).Trim();
                    }

                    controle.EscolherFormatoDaNumeracao(literal);
                    resultado = "formato \"" + literal + "\" → " + controle.UltimaMensagem;
                }
                else if (acao.StartsWith("inserir", StringComparison.Ordinal))
                {
                    int indice = 1;
                    int doisPontos = acao.IndexOf(':');
                    if (doisPontos > 0)
                    {
                        int.TryParse(acao.Substring(doisPontos + 1), out indice);
                    }

                    resultado = controle.InserirColuna(indice);
                }

                Capturar(controle, "paginas");
                return "pzFolhas: " + controle.Paginas().Count + " página(s) na grade " + Lista(controle.Paginas())
                    + "; combo=\"" + controle.FormatoDaNumeracao() + "\""
                    + " (antes: " + paginas + ")"
                    + "; seleção pedida " + Lista(linhas) + " (" + achadas + " achada(s))"
                    + "; selecionada depois " + Lista(controle.Selecionadas())
                    + "; ação \"" + (acao.Length == 0 ? "(nenhuma)" : acao) + "\" → " + resultado
                    + "; " + DescreverColunas(controle.Colunas())
                    + "; " + controle.DescreverInterface();
            }
            catch (Exception erro)
            {
                return "pzFolhas: falhou — " + erro.GetType().Name + ": " + erro.Message;
            }
        }

        private static void ProvarCampos(FolhasControle controle, bool nativo)
        {
            DataGridView grade = (DataGridView)controle.Controls["dg"];
            if (grade.Rows.Count == 0)
            {
                // D/A/V não têm menu no reverso; não inventar cliques num menu inexistente.
                if (grade.ContextMenuStrip != null)
                    throw new InvalidOperationException("Desenho vazio V deveria estar sem menu");
                controle.EditarUnidade();
                controle.EditarAlternativo();
                Plugin.Escrever("CAMPOS185: PASSOU — desenho sem páginas; menu ausente; nenhuma pergunta/gravação.");
                return;
            }
            string[] paginas = { "2", "6" };
            Dictionary<string, string[]> antes = new Dictionary<string, string[]>();
            foreach (string pagina in controle.Paginas())
            {
                string unidade, alternativo;
                UnidadeDaPaginaDoDesenho.Ler(pagina, out unidade, out alternativo);
                antes[pagina] = new[] { unidade, alternativo };
            }
            controle.Multiselecao = true;
            if (controle.Selecionar(paginas) != 2) throw new InvalidOperationException("Páginas 2/6 ausentes");
            string ativa = PaginaAtivaDoDesenho.Ler();
            if (nativo)
            {
                Plugin.Escrever("CAMPOS185: aguardando Escape no prompt Unidade.");
                ClicarCampo(grade, false);
                foreach (string pagina in paginas)
                {
                    string unidade, alternativo;
                    UnidadeDaPaginaDoDesenho.Ler(pagina, out unidade, out alternativo);
                    if (unidade != antes[pagina][0] || alternativo != antes[pagina][1])
                        throw new InvalidOperationException("Cancelamento gravou");
                }
            }
            string esperadoUnidade = "UNIDADE COM ESPACOS 185";
            string esperadoAlternativo = "NOME ALTERNATIVO COM MAIS DE VINTE CARACTERES 185";
            string envUnidade = Environment.GetEnvironmentVariable(RespostaDoHarness.VariavelUnidade);
            string envAlternativo = Environment.GetEnvironmentVariable(RespostaDoHarness.VariavelAlternativo);
            try
            {
                if (!nativo)
                {
                    Environment.SetEnvironmentVariable(RespostaDoHarness.VariavelUnidade, "  unidade com espacos 185  ");
                    Environment.SetEnvironmentVariable(RespostaDoHarness.VariavelAlternativo, "  nome alternativo com mais de vinte caracteres 185  ");
                }
                Plugin.Escrever("CAMPOS185: aguardando Unidade.");
                ClicarCampo(grade, false);
                foreach (string pagina in paginas)
                {
                    string unidade, alternativo;
                    UnidadeDaPaginaDoDesenho.Ler(pagina, out unidade, out alternativo);
                    if (unidade != esperadoUnidade || alternativo != antes[pagina][1])
                        throw new InvalidOperationException("Unidade ou conservação do alternativo incorreta");
                }
                if (nativo)
                {
                    Plugin.Escrever("CAMPOS185: aguardando Enter para aceitar Unidade padrão.");
                    ClicarCampo(grade, false);
                }
                Plugin.Escrever("CAMPOS185: aguardando Alternativo.");
                ClicarCampo(grade, true);
                foreach (KeyValuePair<string, string[]> par in antes)
                {
                    string unidade, alternativo;
                    UnidadeDaPaginaDoDesenho.Ler(par.Key, out unidade, out alternativo);
                    bool selecionada = Array.IndexOf(paginas, par.Key) >= 0;
                    if (unidade != (selecionada ? esperadoUnidade : par.Value[0])
                        || alternativo != (selecionada ? esperadoAlternativo : par.Value[1]))
                        throw new InvalidOperationException("Campo final incorreto na página " + par.Key);
                }
                if (!controle.Multiselecao || grade.SelectedRows.Count != 2 || PaginaAtivaDoDesenho.Ler() != ativa)
                    throw new InvalidOperationException("Multiseleção ou página ativa perdida");
                grade.ClearSelection();
                ClicarCampo(grade, false);
                ClicarCampo(grade, true);
                string finalUnidade, finalAlternativo;
                UnidadeDaPaginaDoDesenho.Ler(ativa, out finalUnidade, out finalAlternativo);
                if (finalUnidade != (Array.IndexOf(paginas, ativa) >= 0 ? esperadoUnidade : antes[ativa][0])
                    || finalAlternativo != (Array.IndexOf(paginas, ativa) >= 0 ? esperadoAlternativo : antes[ativa][1]))
                    throw new InvalidOperationException("Sem seleção alterou página ativa");
                Plugin.Escrever("CAMPOS185: PASSOU — menu; 2 páginas; demais " + (antes.Count - 2)
                    + " preservadas; caixa/espaços; Alternativo >20; seleção/ativa preservadas; sem seleção não grava; nativo=" + nativo);
            }
            finally
            {
                Environment.SetEnvironmentVariable(RespostaDoHarness.VariavelUnidade, envUnidade);
                Environment.SetEnvironmentVariable(RespostaDoHarness.VariavelAlternativo, envAlternativo);
            }
        }

        private static void ClicarCampo(DataGridView grade, bool alternativo)
        {
            string texto = alternativo ? Positron.Data.Interface.MensagensDoReverso.EditarAlternativo
                : Positron.Data.Interface.MensagensDoReverso.EditarUnidade;
            ToolStripMenuItem preferencia = null;
            foreach (ToolStripItem item in grade.ContextMenuStrip.Items)
                if (item.Text == Positron.Data.Interface.MensagensDoReverso.Alternativo)
                    preferencia = item as ToolStripMenuItem;
            bool habilitar = alternativo && preferencia != null && !preferencia.Checked;
            try
            {
                // Alternativo nasce oculto: o usuário primeiro liga a preferência pelo menu.
                if (habilitar) preferencia.PerformClick();
                foreach (ToolStripItem item in grade.ContextMenuStrip.Items)
                    if (item.Text == texto) { item.PerformClick(); return; }
                throw new InvalidOperationException("Menu ausente: " + texto);
            }
            finally { if (habilitar) preferencia.PerformClick(); }
        }

        /// <summary>
        /// A prova da **renumeração pelo caminho do usuário**: a paleta aparece, a grade recebe a
        /// seleção que o usuário faria, e o clique vai no **item do menu** — fora de comando (o
        /// Timer do WinForms), com o prompt nativo do CAD respondido por quem opera a janela. Os
        /// marcos do log ("clicando o menu") são o sinal para o script externo mandar a resposta.
        /// </summary>
        private static void AgendarRenumeracaoPelaInterface()
        {
            Timer timer = new Timer { Interval = 2000 };
            timer.Tick += (origem, evento) =>
            {
                timer.Stop();
                timer.Dispose();
                try
                {
                    PaletaDeFolhas.Mostrar();
                    FolhasControle controle = PaletaDeFolhas.Controle;
                    Plugin.Escrever("RENUM186 UI: " + controle.DescreverInterface());
                    List<string> alvos = new List<string>();
                    string pedido = Environment.GetEnvironmentVariable("POSITRON_FOLHA_SELECIONADAS");
                    if (!string.IsNullOrEmpty(pedido))
                    {
                        foreach (string parte in pedido.Split(','))
                        {
                            if (parte.Trim().Length > 0) alvos.Add(parte.Trim());
                        }
                    }

                    if (alvos.Count > 1) controle.Multiselecao = true;
                    int achadas = controle.Selecionar(alvos);
                    Plugin.Escrever("RENUM186 UI: seleção pedida \"" + pedido + "\" (" + achadas + " achada(s))");

                    // O outro caminho da paleta: escolher o formato no próprio combo (o
                    // `Es6p1Y15jTb`), também fora de comando.
                    string formato = Environment.GetEnvironmentVariable("POSITRON_FOLHA_FORMATO");
                    if (!string.IsNullOrEmpty(formato))
                    {
                        Capturar(controle, "paginas-antes-do-formato");
                        controle.EscolherFormatoDaNumeracao(formato);
                        Plugin.Escrever("RENUM186 UI: PASSOU — combo \"" + formato + "\" → " + controle.UltimaMensagem
                            + "; páginas depois: " + Lista(controle.Paginas()));
                        Capturar(controle, "paginas-depois-do-formato");
                        return;
                    }

                    DataGridView grade = (DataGridView)controle.Controls["dg"];
                    ToolStripMenuItem item = null;
                    foreach (ToolStripItem candidato in grade.ContextMenuStrip.Items)
                    {
                        if (candidato.Text == Positron.Data.Interface.MensagensDoReverso.RenumerarPaginas)
                        {
                            item = candidato as ToolStripMenuItem;
                        }
                    }

                    if (item == null || !item.Enabled)
                    {
                        throw new InvalidOperationException("O item \"Renumerar Páginas\" está ausente ou desabilitado.");
                    }

                    Capturar(controle, "paginas-antes-do-clique");
                    Plugin.Escrever("RENUM186 UI: clicando o menu — aguardando as respostas no prompt nativo.");
                    item.PerformClick();
                    Plugin.Escrever("RENUM186 UI: PASSOU — " + controle.UltimaMensagem
                        + "; página ativa=" + controle.PaginaAtiva);
                }
                catch (Exception erro)
                {
                    Plugin.Escrever("RENUM186 UI: FALHOU — " + erro);
                }
            };
            timer.Start();
        }

        private static void AgendarProvaDaInterface()
        {
            Timer timer = new Timer { Interval = 1500 };
            int passo = 0;
            Form editor = null;
            string alvo = Environment.GetEnvironmentVariable("POSITRON_PAGINA") ?? "2";
            string antes = TitulosDaPaginaDoDesenho.LerGrade().ContainsKey(alvo)
                ? TitulosDaPaginaDoDesenho.LerGrade()[alvo].Titulo1 : null;
            timer.Tick += (origem, evento) =>
            {
                try
                {
                    if (passo == 0)
                    {
                        PaletaDeFolhas.Mostrar();
                        Plugin.Escrever("pzFolhas UI: " + PaletaDeFolhas.Controle.DescreverInterface());
                    }
                    else if (passo == 1)
                    {
                        FolhasControle controle = PaletaDeFolhas.Controle;
                        TextBox pagina = (TextBox)controle.Controls["tbPagina"];
                        pagina.Text = alvo;
                        ((Button)controle.Controls["btPagina"]).PerformClick();
                        if (PaginaAtivaDoDesenho.Ler() != alvo) throw new InvalidOperationException("Navegação não ativou a página");
                        ((Button)controle.Controls["btSalva"]).PerformClick();
                        // Label não expõe PerformClick: dispara o mesmo evento WinForms do clique.
                        typeof(Control).GetMethod("OnClick", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                            .Invoke(controle.Controls["lb1"], new object[] { EventArgs.Empty });
                        if (AtalhosDePaginasDoDesenho.Ler()[0] != alvo) throw new InvalidOperationException("Atalho não gravado");
                        Capturar(controle, "paginas");
                        DataGridView grade = (DataGridView)controle.Controls["dg"];
                        foreach (ToolStripItem item in grade.ContextMenuStrip.Items)
                            if (item.Text == Positron.Data.Interface.MensagensDoReverso.EditarTitulos) item.PerformClick();
                    }
                    else if (passo == 2)
                    {
                        foreach (Form form in System.Windows.Forms.Application.OpenForms)
                            if (form.Name == "frmEditaTitulos") editor = form;
                        if (editor == null) throw new InvalidOperationException("Menu não abriu editor");
                        DataGridView grade = ControlesDaTela.Achar<DataGridView>(editor, "dg");
                        foreach (DataGridViewRow linha in grade.Rows)
                            if (Convert.ToString(linha.Cells[0].Value) == alvo)
                            {
                                linha.Cells[1].Value = "PROVA UI 183";
                                linha.Cells[5].Value = "UNIDADE UI 183";
                                linha.Cells[6].Value = "ALTERNATIVO UI 183";
                            }
                        if (TitulosDaPaginaDoDesenho.LerGrade()[alvo].Titulo1 != antes)
                            throw new InvalidOperationException("Grade gravou antes de Editar DWG");
                        Capturar(editor, "editar-os-titulos");
                        int quantidadeDeLinhas = grade.Rows.Count;
                        foreach (ToolStripItem item in grade.ContextMenuStrip.Items)
                            if (item.Text == "Editar DWG") item.PerformClick();
                        string unidade, alternativo;
                        UnidadeDaPaginaDoDesenho.Ler(alvo, out unidade, out alternativo);
                        if (!editor.IsDisposed || TitulosDaPaginaDoDesenho.LerGrade()[alvo].Titulo1 != "PROVA UI 183"
                            || unidade != "UNIDADE UI 183" || alternativo != "ALTERNATIVO UI 183")
                            throw new InvalidOperationException("Gravação/fechamento não confirmados");
                        Plugin.Escrever("pzFolhas UI: PASSOU — navegação pelo botão, atalho Xrecord, menu Editar Títulos, "
                            + quantidadeDeLinhas + " linha(s), edição local sem gravação antecipada; Editar DWG fora de comando; texto e XData confirmados.");
                        timer.Stop();
                        timer.Dispose();
                    }
                    passo++;
                }
                catch (Exception erro)
                {
                    timer.Stop();
                    timer.Dispose();
                    Plugin.Escrever("pzFolhas UI: FALHOU — " + erro);
                }
            };
            timer.Start();
        }

        /// <summary>
        /// O **clique físico** na célula Página, com a paleta visível e fora de comando: um clique
        /// do mouse de verdade seleciona a linha (e o original ativa a página aí), a digitação de
        /// verdade abre a edição (o `EditMode` padrão, `EditOnKeystrokeOrF2`, é o do designer do
        /// reverso — não há `EditMode` gravado lá) e o Enter fecha, disparando o `CellEndEdit` que
        /// renomeia (`uscPaginas.cs:1733-1846`). O desenho é lido depois pelo adapter, não pela
        /// célula — a célula pode ter sido reconstruída pelo `Carregar`.
        /// </summary>
        private static void AgendarCliqueNaCelula()
        {
            Timer timer = new Timer { Interval = 1500 };
            int passo = 0;
            int linha = -1;
            string alvo = Environment.GetEnvironmentVariable("POSITRON_FOLHA_INLINE_ALVO") ?? "7";
            string valor = Environment.GetEnvironmentVariable("POSITRON_FOLHA_INLINE");
            if (string.IsNullOrEmpty(valor))
            {
                valor = "7A";
            }

            timer.Tick += (origem, evento) =>
            {
                try
                {
                    if (passo == 0)
                    {
                        PaletaDeFolhas.Mostrar();
                        FolhasControle paleta = PaletaDeFolhas.Controle;
                        DataGridView grade = (DataGridView)paleta.Controls["dg"];
                        Plugin.Escrever("CLIQUE222: paleta — " + paleta.DescreverInterface()
                            + "; páginas " + Lista(paleta.Paginas()) + "; rótulos " + Rotulos(paleta));
                        for (int i = 0; i < grade.Rows.Count; i++)
                        {
                            if (string.Equals(Convert.ToString(grade.Rows[i].Cells[0].Value), alvo, StringComparison.OrdinalIgnoreCase))
                            {
                                linha = i;
                            }
                        }

                        if (linha < 0)
                        {
                            throw new InvalidOperationException("Linha \"" + alvo + "\" ausente para o clique.");
                        }

                        grade.FirstDisplayedScrollingRowIndex = linha;
                        Capturar(paleta, "inline-antes-do-clique");
                    }
                    else if (passo == 1)
                    {
                        FolhasControle paleta = PaletaDeFolhas.Controle;
                        DataGridView grade = (DataGridView)paleta.Controls["dg"];
                        System.Drawing.Rectangle celula = grade.GetCellDisplayRectangle(0, linha, false);
                        System.Drawing.Point ponto = grade.PointToScreen(new System.Drawing.Point(
                            celula.Left + celula.Width / 2, celula.Top + celula.Height / 2));
                        Plugin.Escrever("CLIQUE222: clique físico em (" + ponto.X + "," + ponto.Y + "), célula "
                            + celula + ", foco antes=\"" + EntradaFisicaDaProva.Foco() + "\"");
                        EntradaFisicaDaProva.ClicarEm(ponto, 1, grade);
                    }
                    else if (passo == 2)
                    {
                        FolhasControle paleta = PaletaDeFolhas.Controle;
                        DataGridView grade = (DataGridView)paleta.Controls["dg"];
                        bool atual = grade.CurrentCell != null && grade.CurrentCell.RowIndex == linha
                            && grade.CurrentCell.ColumnIndex == 0;
                        Plugin.Escrever("CLIQUE222: depois do clique — célula atual="
                            + (grade.CurrentCell == null ? "(nenhuma)" : grade.CurrentCell.RowIndex + "," + grade.CurrentCell.ColumnIndex)
                            + "; foco na grade=" + grade.Focused + "; em edição=" + grade.IsCurrentCellInEditMode
                            + "; camada corrente=\"" + PaginaAtivaDoDesenho.LerCamadaCorrente()
                            + "\"; ativa=\"" + PaginaAtivaDoDesenho.Ler()
                            + "\"; foco=\"" + EntradaFisicaDaProva.Foco() + "\"");
                        if (!atual)
                        {
                            throw new InvalidOperationException("O clique não pôs a célula Página da linha "
                                + linha + " como atual — nada foi digitado (teclas não vão para o CAD).");
                        }

                        string erro = EntradaFisicaDaProva.Digitar(valor, false);
                        if (erro != null)
                        {
                            throw new InvalidOperationException(erro);
                        }

                        Plugin.Escrever("CLIQUE222: digitando \"" + valor + "\" no teclado físico.");
                    }
                    else if (passo == 3)
                    {
                        FolhasControle paleta = PaletaDeFolhas.Controle;
                        DataGridView grade = (DataGridView)paleta.Controls["dg"];
                        string noEditor = grade.EditingControl == null ? "(sem editor)" : grade.EditingControl.Text;
                        Plugin.Escrever("CLIQUE222: em edição=" + grade.IsCurrentCellInEditMode
                            + "; editor=\"" + noEditor + "\"");
                        if (!grade.IsCurrentCellInEditMode)
                        {
                            throw new InvalidOperationException("A digitação física não abriu a edição da célula.");
                        }

                        EntradaFisicaDaProva.Digitar(string.Empty, true);
                        Plugin.Escrever("CLIQUE222: Enter físico — aguardando o CellEndEdit.");
                    }
                    else if (passo == 4)
                    {
                        FolhasControle paleta = PaletaDeFolhas.Controle;
                        List<string> paginas = new List<string>(PaginasDoDesenho.Ler());
                        DataGridView gradeFinal = (DataGridView)paleta.Controls["dg"];
                        Plugin.Escrever("CLIQUE222: PASSOU — página ativa=" + PaginaAtivaDoDesenho.Ler()
                            + "; camada corrente=\"" + PaginaAtivaDoDesenho.LerCamadaCorrente() + "\""
                            + "; grade: linha atual=" + (gradeFinal.CurrentCell == null ? "(nenhuma)" : gradeFinal.CurrentCell.RowIndex.ToString())
                            + ", selecionadas=" + gradeFinal.SelectedRows.Count
                            + (gradeFinal.SelectedRows.Count > 0 ? " (" + Convert.ToString(gradeFinal.SelectedRows[0].Cells[0].Value) + ")" : string.Empty)
                            + "; páginas do desenho " + Lista(paginas) + "; " + paleta.UltimaMensagem
                            + "; rótulos " + Rotulos(paleta));
                        Capturar(paleta, "inline-depois-do-enter");
                        timer.Stop();
                        timer.Dispose();
                    }

                    passo++;
                }
                catch (Exception erro)
                {
                    timer.Stop();
                    timer.Dispose();
                    Plugin.Escrever("CLIQUE222: FALHOU — " + erro);
                }
            };
            timer.Start();
        }

        /// <summary>
        /// Os quatro rótulos de atalho pelo **clique físico** — o ramo do `RXnp13sEwHd`
        /// (`uscPaginas.cs:1514-1601`): sem captura, o clique usa o atalho (normaliza, ativa, copia
        /// Unidade/Alternativo e rola) e o atalho inexistente se limpa; com a captura armada pelo
        /// `btSalva` (`EDJp12YldpK`, `:1509`), o clique grava a página ativa no slot. O Xrecord
        /// `CENG_ELET`/`Atalhos` tem **seis** strings (`Dicionario.cs:99-207`) e os dois últimos não
        /// têm rótulo: o clique não pode perdê-los.
        /// </summary>
        private static void AgendarCliqueNosAtalhos()
        {
            Timer timer = new Timer { Interval = 1500 };
            int passo = 0;
            FolhasControle paleta = null;
            timer.Tick += (origem, evento) =>
            {
                try
                {
                    if (passo == 0)
                    {
                        PaletaDeFolhas.Mostrar();
                        paleta = PaletaDeFolhas.Controle;
                        Plugin.Escrever("CLIQUE222: paleta — " + paleta.DescreverInterface()
                            + "; rótulos " + Rotulos(paleta)
                            + "; Xrecord " + Lista(AtalhosDePaginasDoDesenho.Ler()));
                        Capturar(paleta, "atalhos-antes");
                    }
                    else if (passo == 1)
                    {
                        Plugin.Escrever("CLIQUE222: clicando o lb1 (rótulo \"" + TextoDoRotulo(paleta, 1) + "\")");
                        EntradaFisicaDaProva.Clicar(paleta.Controls["lb1"], 1);
                    }
                    else if (passo == 2)
                    {
                        ConferirAtivo(paleta, "2", 1);
                        Plugin.Escrever("CLIQUE222: lb1 usou o atalho — ativa=" + PaginaAtivaDoDesenho.Ler());
                    }
                    else if (passo == 3)
                    {
                        Plugin.Escrever("CLIQUE222: clicando o lb2 (rótulo \"" + TextoDoRotulo(paleta, 2) + "\")");
                        EntradaFisicaDaProva.Clicar(paleta.Controls["lb2"], 1);
                    }
                    else if (passo == 4)
                    {
                        ConferirAtivo(paleta, "6", 2);
                        Plugin.Escrever("CLIQUE222: lb2 usou o atalho — ativa=" + PaginaAtivaDoDesenho.Ler());
                    }
                    else if (passo == 5)
                    {
                        Plugin.Escrever("CLIQUE222: clicando o lb3 (rotulo inexistente \"" + TextoDoRotulo(paleta, 3) + "\")");
                        EntradaFisicaDaProva.Clicar(paleta.Controls["lb3"], 1);
                    }
                    else if (passo == 6)
                    {
                        string[] atalhos = AtalhosDePaginasDoDesenho.Ler();
                        if (TextoDoRotulo(paleta, 3).Length != 0)
                            throw new InvalidOperationException("O rótulo lb3 não foi limpo pelo clique: \"" + TextoDoRotulo(paleta, 3) + "\"");
                        if (atalhos[2].Length != 0)
                            throw new InvalidOperationException("O slot 3 do Xrecord continuou \"" + atalhos[2] + "\".");
                        if (atalhos[4] != "QUINTO" || atalhos[5] != "SEXTO")
                            throw new InvalidOperationException("Os slots 5/6 do Xrecord se perderam: \"" + atalhos[4] + "\"/\"" + atalhos[5] + "\".");
                        Plugin.Escrever("CLIQUE222: lb3 inexistente limpou o slot 3; slots 5/6 preservados (\""
                            + atalhos[4] + "\"/\"" + atalhos[5] + "\")");
                    }
                    else if (passo == 7)
                    {
                        Plugin.Escrever("CLIQUE222: clicando o btSalva (arma a captura).");
                        EntradaFisicaDaProva.Clicar(paleta.Controls["btSalva"], 1);
                    }
                    else if (passo == 8)
                    {
                        Plugin.Escrever("CLIQUE222: clicando o lb4 (captura da página ativa \""
                            + PaginaAtivaDoDesenho.Ler() + "\")");
                        EntradaFisicaDaProva.Clicar(paleta.Controls["lb4"], 1);
                    }
                    else if (passo == 9)
                    {
                        string[] atalhos = AtalhosDePaginasDoDesenho.Ler();
                        if (atalhos[3] != "6")
                            throw new InvalidOperationException("O lb4 não capturou a página ativa: slot 4 = \"" + atalhos[3] + "\".");
                        if (TextoDoRotulo(paleta, 4) != "6")
                            throw new InvalidOperationException("O rótulo lb4 não recebeu a página: \"" + TextoDoRotulo(paleta, 4) + "\".");
                        if (atalhos[4] != "QUINTO" || atalhos[5] != "SEXTO")
                            throw new InvalidOperationException("Os slots 5/6 se perderam na captura: \"" + atalhos[4] + "\"/\"" + atalhos[5] + "\".");
                        Plugin.Escrever("CLIQUE222: PASSOU — ativa=" + PaginaAtivaDoDesenho.Ler()
                            + "; rótulos " + Rotulos(paleta)
                            + "; Xrecord " + Lista(atalhos));
                        Capturar(paleta, "atalhos-depois");
                        timer.Stop();
                        timer.Dispose();
                    }

                    passo++;
                }
                catch (Exception erro)
                {
                    timer.Stop();
                    timer.Dispose();
                    Plugin.Escrever("CLIQUE222: FALHOU — " + erro);
                }
            };
            timer.Start();
        }

        /// <summary>
        /// A prova dos **diálogos de aviso na tela**: o ensaio roda **sem** `POSITRON_LOG` — nesse
        /// modo o <see cref="Aviso"/> abre o `MsgBox` de verdade — e o roteiro externo acha a janela
        /// `#32770` do CAD, lê o texto e clica o OK. O harness registra o estado antes e depois no
        /// arquivo de `POSITRON_PROVA_SAIDA`, porque sem o log não há outra evidência.
        ///
        /// Modos (`POSITRON_AVISO_MODO`): <c>capa</c> — "Apagar Páginas" com a capa selecionada
        /// (mMensagem 17, crítico, título "Elétron"); <c>mover</c> — "Renumerar Páginas" com o
        /// destino na capa (mMensagem 57, informação, **sem título**); <c>mais20</c> — o Alternativo
        /// acima de 20 caracteres na célula (mMensagem 1927, **sem ícone**), com o clique e a
        /// digitação físicos.
        /// </summary>
        private static void AgendarProvaDosAvisos()
        {
            Timer timer = new Timer { Interval = 1500 };
            int passo = 0;
            int linha = -1;
            bool enterEnviado = false;
            FolhasControle paleta = null;
            string modo = (Environment.GetEnvironmentVariable("POSITRON_AVISO_MODO") ?? "capa").Trim().ToLowerInvariant();
            string alvo = Environment.GetEnvironmentVariable("POSITRON_FOLHA_SELECAO");
            if (string.IsNullOrEmpty(alvo))
            {
                alvo = modo == "capa" ? "1" : modo == "mover" ? "7" : "2";
            }

            string texto = Environment.GetEnvironmentVariable("POSITRON_FOLHA_INLINE");
            if (string.IsNullOrEmpty(texto))
            {
                texto = "NOME ALTERNATIVO 223 COM VINTE E CINCO";
            }

            bool ocupado = false;
            timer.Tick += (origem, evento) =>
            {
                // O `MessageBox` abre um **laço aninhado** que despacha o `WM_TIMER`: sem a guarda, o
                // mesmo passo roda de novo enquanto o diálogo está na tela (medido nesta rodada — o
                // clique no menu se repetia a cada 1,5 s).
                if (ocupado)
                {
                    return;
                }

                ocupado = true;
                try
                {
                    if (passo == 0)
                    {
                        PaletaDeFolhas.Mostrar();
                        paleta = PaletaDeFolhas.Controle;
                        if (paleta == null)
                        {
                            throw new InvalidOperationException("A paleta não existe nesta sessão.");
                        }

                        Registrar("AVISO223: paleta — " + paleta.DescreverInterface()
                            + "; páginas " + Lista(paleta.Paginas()) + "; modo=" + modo);
                        if (paleta.Selecionar(new[] { alvo }) != 1)
                        {
                            throw new InvalidOperationException("Página \"" + alvo + "\" ausente na grade.");
                        }

                        Registrar("AVISO223: página \"" + alvo + "\" selecionada; ativa=\""
                            + PaginaAtivaDoDesenho.Ler() + "\"");

                        if (modo == "capa" || modo == "mover")
                        {
                            string rotulo = modo == "capa"
                                ? Positron.Data.Interface.MensagensDoReverso.ApagarPaginas
                                : Positron.Data.Interface.MensagensDoReverso.RenumerarPaginas;
                            ToolStripMenuItem item = ItemDoMenu(paleta, rotulo);
                            if (item == null || !item.Enabled)
                            {
                                throw new InvalidOperationException("O item \"" + rotulo + "\" está ausente ou desabilitado.");
                            }

                            Registrar("AVISO223: clicando \"" + item.Text + "\" — o diálogo abre no clique.");
                            item.PerformClick();
                            Registrar("AVISO223: PASSOU — depois do aviso: " + paleta.UltimaMensagem
                                + "; páginas " + Lista(paleta.Paginas()));
                            Capturar(paleta, "aviso-" + modo + "-depois");
                            timer.Stop();
                            timer.Dispose();
                            return;
                        }

                        DataGridView grade = (DataGridView)paleta.Controls["dg"];
                        for (int i = 0; i < grade.Rows.Count; i++)
                        {
                            if (string.Equals(Convert.ToString(grade.Rows[i].Cells[0].Value), alvo, StringComparison.OrdinalIgnoreCase))
                            {
                                linha = i;
                            }
                        }

                        if (linha < 0)
                        {
                            throw new InvalidOperationException("Linha \"" + alvo + "\" ausente para a edição.");
                        }

                        // O Alternativo nasce oculto: o usuário primeiro liga a preferência no menu.
                        if (!grade.Columns[2].Visible)
                        {
                            ToolStripMenuItem preferencia = ItemDoMenu(paleta, Positron.Data.Interface.MensagensDoReverso.Alternativo);
                            if (preferencia == null)
                            {
                                throw new InvalidOperationException("O item \"" + Positron.Data.Interface.MensagensDoReverso.Alternativo + "\" não existe no menu.");
                            }

                            preferencia.PerformClick();
                            Registrar("AVISO223: coluna Alternativo ligada pelo menu; visível=" + grade.Columns[2].Visible);
                        }

                        grade.FirstDisplayedScrollingRowIndex = linha;
                        Capturar(paleta, "aviso-mais20-antes");
                    }
                    else if (passo == 1)
                    {
                        DataGridView grade = (DataGridView)paleta.Controls["dg"];
                        System.Drawing.Rectangle celula = grade.GetCellDisplayRectangle(2, linha, false);
                        System.Drawing.Point ponto = grade.PointToScreen(new System.Drawing.Point(
                            celula.Left + celula.Width / 2, celula.Top + celula.Height / 2));
                        Registrar("AVISO223: clique físico em (" + ponto.X + "," + ponto.Y + "), célula Alternativo "
                            + celula + ", foco antes=\"" + EntradaFisicaDaProva.Foco() + "\"");
                        EntradaFisicaDaProva.ClicarEm(ponto, 1, grade);
                    }
                    else if (passo == 2)
                    {
                        DataGridView grade = (DataGridView)paleta.Controls["dg"];
                        bool atual = grade.CurrentCell != null && grade.CurrentCell.RowIndex == linha
                            && grade.CurrentCell.ColumnIndex == 2;
                        if (!atual)
                        {
                            throw new InvalidOperationException("O clique não pôs a célula Alternativo da linha "
                                + linha + " como atual — nada foi digitado.");
                        }

                        string erro = EntradaFisicaDaProva.Digitar(texto, false);
                        if (erro != null)
                        {
                            throw new InvalidOperationException(erro);
                        }

                        Registrar("AVISO223: digitando " + texto.Length + " caracteres no teclado físico (o aviso sai ao confirmar).");
                    }
                    else if (passo == 3)
                    {
                        DataGridView grade = (DataGridView)paleta.Controls["dg"];
                        if (!grade.IsCurrentCellInEditMode)
                        {
                            throw new InvalidOperationException("A digitação física não abriu a edição da célula Alternativo.");
                        }

                        if (!enterEnviado)
                        {
                            EntradaFisicaDaProva.Digitar(string.Empty, true);
                            enterEnviado = true;
                            Registrar("AVISO223: Enter físico — aguardando o aviso.");
                        }
                    }
                    else
                    {
                        // O `CellEndEdit` está **dentro** do diálogo: enquanto ele não é fechado, a
                        // célula continua com os 25 caracteres e em edição.
                        DataGridView grade = (DataGridView)paleta.Controls["dg"];
                        string valor = Convert.ToString(grade.Rows[linha].Cells[2].Value);
                        if (!grade.IsCurrentCellInEditMode && valor.Length <= 20)
                        {
                            string unidade;
                            string alternativo;
                            UnidadeDaPaginaDoDesenho.Ler(alvo, out unidade, out alternativo);
                            if (alternativo != texto.Substring(0, 20))
                            {
                                throw new InvalidOperationException("O Alternativo gravado ficou \"" + alternativo + "\".");
                            }

                            Registrar("AVISO223: PASSOU — célula=\"" + valor + "\" (" + valor.Length
                                + " caracteres) e XData \"" + alternativo + "\" na página \"" + alvo + "\"; "
                                + paleta.UltimaMensagem);
                            Capturar(paleta, "aviso-mais20-depois");
                            timer.Stop();
                            timer.Dispose();
                        }
                    }

                    passo++;
                }
                catch (Exception erro)
                {
                    Registrar("AVISO223: FALHOU — " + erro);
                    timer.Stop();
                    timer.Dispose();
                }
                finally
                {
                    ocupado = false;
                }
            };
            timer.Start();
        }

        /// <summary>O item do menu de contexto da grade pelo texto que o usuário lê.</summary>
        private static ToolStripMenuItem ItemDoMenu(FolhasControle paleta, string texto)
        {
            DataGridView grade = (DataGridView)paleta.Controls["dg"];
            if (grade.ContextMenuStrip == null)
            {
                return null;
            }

            foreach (ToolStripItem item in grade.ContextMenuStrip.Items)
            {
                if (item.Text == texto)
                {
                    return item as ToolStripMenuItem;
                }
            }

            return null;
        }

        /// <summary>
        /// A evidência dos ensaios **sem** `POSITRON_LOG`: uma linha por passo no arquivo de
        /// `POSITRON_PROVA_SAIDA` (variável só do harness; sem ela, a linha vai para a linha de
        /// comando). É o que permite medir o `MsgBox` — que só abre quando não há log.
        /// </summary>
        private static void Registrar(string linha)
        {
            string caminho = Environment.GetEnvironmentVariable("POSITRON_PROVA_SAIDA");
            if (string.IsNullOrEmpty(caminho))
            {
                Plugin.Escrever(linha);
                return;
            }

            try
            {
                System.IO.File.AppendAllText(caminho, linha + Environment.NewLine);
            }
            catch (System.IO.IOException)
            {
            }
        }

        private static void ConferirAtivo(FolhasControle paleta, string esperada, int indiceDoRotulo)
        {
            string ativa = PaginaAtivaDoDesenho.Ler();
            if (!string.Equals(ativa, esperada, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("O clique no lb" + indiceDoRotulo + " (rótulo \""
                    + TextoDoRotulo(paleta, indiceDoRotulo) + "\") não ativou a página \""
                    + esperada + "\": ativa=\"" + ativa + "\".");
            }
        }

        private static string TextoDoRotulo(FolhasControle paleta, int indice)
        {
            Control rotulo = paleta.Controls["lb" + indice];
            return rotulo == null ? "(ausente)" : rotulo.Text;
        }

        private static string Rotulos(FolhasControle paleta)
        {
            List<string> partes = new List<string>();
            for (int i = 1; i <= 4; i++)
            {
                partes.Add("lb" + i + "=\"" + TextoDoRotulo(paleta, i) + "\"");
            }

            return "[" + string.Join(" | ", partes.ToArray()) + "]";
        }

        private static void Capturar(Control controle, string nome)
        {
            string pasta = Environment.GetEnvironmentVariable("POSITRON_FOLHA_PROVA_DIR");
            if (string.IsNullOrEmpty(pasta)) return;
            System.IO.Directory.CreateDirectory(pasta);
            using (System.Drawing.Bitmap imagem = new System.Drawing.Bitmap(controle.Width, controle.Height))
            {
                controle.DrawToBitmap(imagem, new System.Drawing.Rectangle(0, 0, controle.Width, controle.Height));
                imagem.Save(System.IO.Path.Combine(pasta, nome + ".png"), System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        /// <summary>
        /// Roda um comando com o observador na barra e devolve o que o **controle** registrou a cada
        /// aviso (`uscPaginas.cs:1242-1269`: o `pbIniciar`, os `pbPasso` e o `pbFim`).
        /// </summary>
        private static string MedirABarra(FolhasControle paleta, ProgressBar barra, Action comando)
        {
            List<string> registro = new List<string>();
            EventHandler observador = (origem, evento) => registro.Add(
                barra.Minimum + ".." + barra.Maximum + "=" + barra.Value
                + ", estado " + (int)paleta.Progresso.Cor);
            paleta.Progresso.Mudou += observador;
            try
            {
                comando();
            }
            finally
            {
                paleta.Progresso.Mudou -= observador;
            }

            return string.Join(" | ", registro.ToArray());
        }

        private static string Estado(bool conectado)
        {
            return conectado ? "conectado" : "desconectado";
        }

        private static string Lista(IReadOnlyList<string> nomes)
        {
            List<string> limpos = new List<string>();
            for (int i = 0; i < nomes.Count; i++)
            {
                limpos.Add(nomes[i].Length == 0 ? "(vazio)" : nomes[i]);
            }

            return "[" + string.Join(" | ", limpos.ToArray()) + "]";
        }

        private static string DescreverColunas(IReadOnlyList<ColunaDoFormato> colunas)
        {
            List<string> itens = new List<string>();
            foreach (ColunaDoFormato coluna in colunas)
            {
                itens.Add(coluna.Visivel ? coluna.Tipo : ("ELET" + coluna.Indice + "_ausente"));
            }

            return "colunas do formato " + (ColunasDoFormato.TemAlguma(colunas) ? "visíveis" : "nenhuma")
                + " [" + string.Join(" | ", itens.ToArray()) + "]";
        }
    }
}
