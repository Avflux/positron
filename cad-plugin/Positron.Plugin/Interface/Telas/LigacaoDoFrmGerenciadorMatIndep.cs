using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Positron.Data;
using Positron.Data.Configuracao;
using Positron.Data.Materiais;
using Positron.Plugin.Materiais;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A ligação do <c>frmGerenciadorMatIndep</c> (o comando <c>ATINDEP</c>, "Dispositivos
    /// Independentes e Avulsos"): a coluna <c>dgPaineis</c> com os **painéis da lista de materiais**
    /// do desenho ativo, a grade <c>dgDisp</c> com os itens do painel escolhido — nas doze colunas do
    /// <c>formataDGDisp</c> do original — e a **escrita da lista** (desde a rodada 151): o item avulso
    /// que o <c>AdicionaUmItemMaterialAvulso</c> grava e o plano do <c>eK4ppmS0dUi</c> — mais o **ramo
    /// do desenho** dele (desde a rodada 152): o <c>clsDispositivo.EditaLMDoDispositivo</c>, que
    /// regrava o <c>iLM1</c> do bloco e os atributos <c>MODELO</c>/<c>PAINEL</c>/<c>FABRICANTE</c>.
    ///
    /// **A diferença deliberada da rodada 148:** o original monta a lista de painéis varrendo o
    /// ModelSpace (<c>clsLM.PaineisDocumentoLM</c>, o painel de cada entidade por XData); aqui ela sai
    /// da <c>ListaMateriais</c> do desenho — a projeção que o <c>COMPLM</c> já gravou (a regra do
    /// recoder). O painel continua vindo do desenho; o caminho é que não é uma segunda varredura.
    ///
    /// **A escrita (rodada 151), na ordem do original:**
    ///
    /// - <b>Adiciona Material</b> (<c>jnTppR04rG4</c>): a caixa do código no <c>0</c> não acrescenta
    ///   nada; senão a linha entra **avulsa**, com a <c>Ordem</c> do contador que começa em 100000 (o
    ///   `rfCpTfmCm7Q`), e a lista é relida — a linha já aparece com o <c>Indice</c> que o banco
    ///   atribuiu;
    /// - <b>Edita Material Selecionado</b> (<c>eK4ppmS0dUi</c>): para cada linha selecionada, o item
    ///   avulso é **substituído** (apagar pelo <c>Indice</c> e inserir de novo com o digitado) e a
    ///   linha **do desenho** vai para o <c>clsDispositivo.EditaLMDoDispositivo</c> (o XData do bloco
    ///   e os atributos <c>MODELO</c>/<c>PAINEL</c>/<c>FABRICANTE</c>), pelo
    ///   <see cref="DispositivoDaListaDoDesenho"/> — a lista e o bloco saem do mesmo clique, senão a
    ///   próxima projeção desfaria a gravação;
    /// - <b>Apaga Material Selecionado</b> (<c>eUVppXAWerf</c>): só as linhas **avulsas** saem — as do
    ///   desenho são da projeção —, e o motivo aparece quando alguma é deixada de fora.
    ///
    /// **A pintura (rodada 154):** cada carga da grade termina no <c>MesclaDGDisp</c>, como lá — a
    /// cor das células 3–5 pela origem da linha, a dica e o <c>ErrorText</c> do material
    /// (<see cref="PinturaDaListaDoPainel"/>).
    ///
    /// O <b>Pesquisar</b> (o <c>frmPesquisaMateriais</c>) continua desabilitado com o motivo na dica.
    ///
    /// **Como a tela é medida num script** (não há clique): <c>POSITRON_LIM_ITEM</c>
    /// (<c>Indice;Tag;Quantidade;Codigo</c>) seleciona a linha pelo <c>Indice</c> e preenche as caixas,
    /// e <c>POSITRON_LIM_ACAO</c> (<c>adicionar</c>, <c>editar</c> ou <c>apagar</c>) roda a **mesma**
    /// ação do clique. Sem nenhuma das duas variáveis, nada acontece.
    /// </summary>
    internal sealed class LigacaoDoFrmGerenciadorMatIndep : LigacaoDeMateriais
    {
        /// <summary>
        /// O estado da janela: o painel escolhido na coluna da esquerda e o contador do item avulso
        /// (o `mTqpTGZErsQ` e o `rfCpTfmCm7Q` do original).
        /// </summary>
        private sealed class EstadoDaLista
        {
            internal int Painel;

            /// <summary>Quantos itens **esta janela** já acrescentou — a <c>Ordem</c> sai daqui.</summary>
            internal int Acrescentados;
        }

        public override string NomeDaTela
        {
            get { return "frmGerenciadorMatIndep"; }
        }

        public override void Preencher(Form janela)
        {
            DataGridView paineis = ControlesDaTela.Achar<DataGridView>(janela, "dgPaineis");
            DataGridView grade = ControlesDaTela.Achar<DataGridView>(janela, "dgDisp");

            // Construtor do original (`frmGerenciadorMatIndep.cs:747`): `clsAuxiliar.BancoValido()`.
            if (!InicioDoDesenho.BancoValido(true))
            {
                janela.Dispose();
                return;
            }

            TextosDoOriginal(janela);
            MontarColunas(paineis, grade);

            ConfiguracaoPositron config = ConfiguracaoEfetiva.Carregar();
            IReadOnlyDictionary<int, MaterialDoCatalogo> catalogo =
                CatalogoDeMateriais.Indexar(Catalogo(config));

            List<LinhaListaMaterial> linhas = LerLista(config, out int dwg);
            IReadOnlyDictionary<int, string> nomes = LerNomesDePaineis(config);

            List<int> doDesenho = PaineisDaListaDeMateriais.Distintos(linhas);
            EstadoDaLista estado = new EstadoDaLista();

            if (paineis != null)
            {
                paineis.Rows.Clear();
                foreach (int painel in doDesenho)
                {
                    paineis.Rows.Add(painel, NomeDoPainel(nomes, painel));
                }

                paineis.SelectionChanged += (origem, evento) =>
                {
                    estado.Painel = PainelSelecionado(paineis);
                    Recarregar(janela, grade, catalogo, config, estado, 0);
                };

                // O original seleciona a primeira linha ao terminar a carga (o `CarregaDGPainelLM`).
                if (paineis.Rows.Count > 0)
                {
                    paineis.Rows[0].Selected = true;
                }
            }

            if (grade != null)
            {
                grade.SelectionChanged += (origem, evento) => PreencherMaterial(janela, grade, catalogo);
            }

            // Os três botões que gravam a lista (o `jnTppR04rG4`, o `eK4ppmS0dUi` e o `eUVppXAWerf`).
            Ligar(ControlesDaTela.Achar<Button>(janela, "BTAdicionaLM"),
                (origem, evento) => Adicionar(janela, grade, estado, catalogo, config));
            Ligar(ControlesDaTela.Achar<Button>(janela, "BTEditaLM"),
                (origem, evento) => Editar(janela, grade, estado, catalogo, nomes, config));
            Ligar(ControlesDaTela.Achar<Button>(janela, "BTApagaLM"),
                (origem, evento) => Apagar(janela, grade, estado, catalogo, config));

            Motivos(janela);

            // A carga da primeira linha é explícita aqui: num script a tela não é *mostrada*, e a
            // seleção programática não dispara o `SelectionChanged` de um controle sem janela — o
            // original conta com o clique. Assim a tela abre com o painel 1 carregado, como no uso.
            if (doDesenho.Count > 0)
            {
                estado.Painel = doDesenho[0];
                CarregarDispositivos(grade, linhas, doDesenho[0], 0, catalogo);
                PreencherMaterial(janela, grade, catalogo);
            }

            GanchoDoHarness(janela, grade, estado, catalogo, nomes, config);
        }

        /// <summary>Os textos e as dicas que o construtor do original aplica por cima do designer.</summary>
        private static void TextosDoOriginal(Form janela)
        {
            Texto(janela, "GroupBox4", "Materiais");
            Texto(janela, "LbTag", "Dispositivo");
            Texto(janela, "lbQuantidade", "Quantidade");
            Texto(janela, "lbCodigo", "Código");
            Texto(janela, "lbDesc", "Descrição Resumida");
            Texto(janela, "lbModelo", "Modelo");
            Texto(janela, "lbFabricante", "Fabricante");
            Texto(janela, "tbCodigo1", "0");

            Dica(janela, "BTAdicionaLM", "Adiciona Material");
            Dica(janela, "BTEditaLM", "Edita Material Selecionado");
            Dica(janela, "BTApagaLM", "Apaga Material Selecionado");
        }

        /// <summary>
        /// As colunas do <c>formataDGPainelLM</c> e do <c>formataDGDisp</c> do original. A coluna 0 da
        /// grade dos painéis fica **oculta** (o original mostra só o nome e guarda o índice na linha).
        /// A grade dos itens é de **seleção múltipla** (o `dgDisp.MultiSelect = true` do construtor):
        /// o Edita e o Apaga varrem as linhas selecionadas.
        /// </summary>
        private static void MontarColunas(DataGridView paineis, DataGridView grade)
        {
            if (paineis != null)
            {
                paineis.Columns.Clear();
                paineis.Columns.Add("Indice", string.Empty);
                paineis.Columns.Add("Equipamento", "Equipamentos  Painéis");
                paineis.Columns[0].Visible = false;
            }

            if (grade != null)
            {
                grade.Columns.Clear();
                grade.Columns.Add("#", string.Empty);
                grade.Columns.Add("DWG", string.Empty);
                grade.Columns.Add("PN", string.Empty);
                grade.Columns.Add("TAG", "Dispositivo");
                grade.Columns.Add("Material", "Materiais");
                grade.Columns.Add("Quantidade", "Quantidade");
                grade.Columns.Add("Ordem", string.Empty);
                grade.Columns.Add("Avulso", string.Empty);
                grade.Columns.Add("DESC", string.Empty);
                grade.Columns.Add("DESCDEST", string.Empty);
                grade.Columns.Add("Alternativo", string.Empty);
                grade.Columns.Add("indexModelo", string.Empty);
                grade.MultiSelect = true;
            }
        }

        /// <summary>As linhas da <c>ListaMateriais</c> do desenho ativo (o `CarregaDadosDispositivos` por DWG).</summary>
        private static List<LinhaListaMaterial> LerLista(ConfiguracaoPositron config, out int dwg)
        {
            dwg = config == null ? 0 : config.Dwg;
            if (config == null || string.IsNullOrEmpty(config.Banco))
            {
                return new List<LinhaListaMaterial>();
            }

            try
            {
                return new ProjectStore(config.Banco).LerListaMateriais(config.Dwg);
            }
            catch (Exception erro)
            {
                Aviso.MsgBoxCritico(erro.Message, "Elétron");
                return new List<LinhaListaMaterial>();
            }
        }

        private static IReadOnlyDictionary<int, string> LerNomesDePaineis(ConfiguracaoPositron config)
        {
            if (config == null || string.IsNullOrEmpty(config.Banco))
            {
                return new Dictionary<int, string>();
            }

            try
            {
                return new ProjectStore(config.Banco).LerNomesDePaineis();
            }
            catch (Exception erro)
            {
                Aviso.MsgBoxCritico(erro.Message, "Elétron");
                return new Dictionary<int, string>();
            }
        }

        /// <summary>
        /// O nome do painel como o <c>Dicionario.BuscaNomeDoPainel</c> do original o responde — o
        /// valor da tabela <c>Paineis</c> quando o índice está no cadastro e o literal <c>"???"</c>
        /// quando não está (é o mesmo valor que vai para o atributo <c>PAINEL</c> do dispositivo, na
        /// <see cref="DispositivoDaListaEdicao.NomeDoPainel"/>).
        /// </summary>
        private static string NomeDoPainel(IReadOnlyDictionary<int, string> nomes, int painel)
        {
            return DispositivoDaListaEdicao.NomeDoPainel(nomes, painel);
        }

        private static int PainelSelecionado(DataGridView paineis)
        {
            if (paineis == null || paineis.SelectedRows.Count == 0)
            {
                return 0;
            }

            object valor = paineis.SelectedRows[0].Cells[0].Value;
            if (valor == null)
            {
                return 0;
            }

            int painel;
            return int.TryParse(Convert.ToString(valor), out painel) ? painel : 0;
        }

        /// <summary>
        /// O <c>CarregaDGDisp</c> do original para o painel escolhido: as linhas da lista na ordem
        /// posicional do `Rows.Add` — é o que as regras de cor e de erro do <c>MesclaDGDisp</c> leem
        /// nas células 4, 7 e 11. Com <paramref name="selecionar"/> a linha daquele <c>Indice</c> fica
        /// selecionada (é como a linha recém-gravada continua escolhida depois da releitura). A carga
        /// termina com a pintura, como o `CarregaDGDisp` termina no `MesclaDGDisp`.
        /// </summary>
        private static int CarregarDispositivos(
            DataGridView grade,
            List<LinhaListaMaterial> linhas,
            int painel,
            int selecionar,
            IReadOnlyDictionary<int, MaterialDoCatalogo> catalogo)
        {
            if (grade == null)
            {
                return 0;
            }

            grade.Rows.Clear();
            if (painel == 0)
            {
                return 0;
            }

            int posicao = -1;
            foreach (LinhaListaMaterial linha in PaineisDaListaDeMateriais.DoPainel(linhas, painel))
            {
                int indice = grade.Rows.Add(
                    linha.Indice,
                    linha.DWG,
                    linha.Painel,
                    linha.Tag,
                    linha.IndiceMaterial,
                    linha.Quantidade,
                    linha.Ordem,
                    linha.Avulso,
                    linha.Destino,
                    linha.DescDestino,
                    linha.Alternativo,
                    linha.Handle);

                if (selecionar != 0 && linha.Indice == selecionar)
                {
                    posicao = indice;
                }
            }

            Pintar(grade, catalogo);
            if (grade.Rows.Count > 0)
            {
                grade.Rows[posicao >= 0 ? posicao : 0].Selected = true;
            }

            return grade.Rows.Count;
        }

        /// <summary>
        /// O <c>MesclaDGDisp</c>: as células 3 a 5 de cada linha na cor da
        /// <see cref="PinturaDaListaDoPainel"/>, com a dica e o <c>ErrorText</c> da célula 4.
        /// </summary>
        private static void Pintar(DataGridView grade, IReadOnlyDictionary<int, MaterialDoCatalogo> catalogo)
        {
            foreach (DataGridViewRow linha in grade.Rows)
            {
                if (linha.IsNewRow)
                {
                    continue;
                }

                PinturaDaLinha pintura = PinturaDaListaDoPainel.Pintar(DaLinha(linha), catalogo);
                for (int coluna = 3; coluna <= 5 && coluna < linha.Cells.Count; coluna++)
                {
                    DataGridViewCell celula = linha.Cells[coluna];
                    CorDaCelula fundo = coluna == 4 && pintura.FundoDoMaterial.HasValue
                        ? pintura.FundoDoMaterial.Value
                        : pintura.Fundo;
                    celula.Style.BackColor = Cor(fundo);
                    celula.Style.ForeColor = fundo == CorDaCelula.Coral ? System.Drawing.Color.White : System.Drawing.Color.Black;
                    celula.ToolTipText = pintura.Dica;
                }

                if (linha.Cells.Count > 4)
                {
                    linha.Cells[4].ErrorText = pintura.Erro;
                }
            }
        }

        /// <summary>
        /// O que a pintura deixou **na grade** (lido das células, não da regra): quantas linhas em
        /// cada cor, quantas com o material em coral e quantas com <c>ErrorText</c> — a medida num
        /// script, onde não há olho na tela.
        /// </summary>
        private static string ResumoDaPintura(DataGridView grade)
        {
            if (grade == null)
            {
                return "pintura: sem grade";
            }

            int limao = 0, ciano = 0, cinza = 0, coral = 0, erros = 0;
            foreach (DataGridViewRow linha in grade.Rows)
            {
                if (linha.IsNewRow || linha.Cells.Count <= 4)
                {
                    continue;
                }

                System.Drawing.Color fundo = linha.Cells[3].Style.BackColor;
                if (fundo == System.Drawing.Color.LemonChiffon) { limao++; }
                else if (fundo == System.Drawing.Color.LightCyan) { ciano++; }
                else if (fundo == System.Drawing.Color.LightGray) { cinza++; }

                if (linha.Cells[4].Style.BackColor == System.Drawing.Color.LightCoral) { coral++; }
                if (!string.IsNullOrEmpty(linha.Cells[4].ErrorText)) { erros++; }
            }

            return "pintura: " + limao + " do desenho, " + ciano + " avulso(s), " + cinza + " sem marca, "
                + coral + " material(is) fora do catálogo, " + erros + " com erro";
        }

        private static System.Drawing.Color Cor(CorDaCelula cor)
        {
            switch (cor)
            {
                case CorDaCelula.Limao: return System.Drawing.Color.LemonChiffon;
                case CorDaCelula.Ciano: return System.Drawing.Color.LightCyan;
                case CorDaCelula.Coral: return System.Drawing.Color.LightCoral;
                default: return System.Drawing.Color.LightGray;
            }
        }

        /// <summary>
        /// Relê a lista do banco e reconstrói a grade do painel escolhido — a releitura que o original
        /// faz depois do <b>Adiciona</b> (o <c>oZXpp56N3Ah</c>) e que aqui fecha também o Edita e o
        /// Apaga: é assim que a grade passa a ter as chaves do **banco** e não as da tela.
        /// </summary>
        private static void Recarregar(
            Form janela,
            DataGridView grade,
            IReadOnlyDictionary<int, MaterialDoCatalogo> catalogo,
            ConfiguracaoPositron config,
            EstadoDaLista estado,
            int selecionar)
        {
            List<LinhaListaMaterial> linhas = LerLista(config, out _);
            CarregarDispositivos(grade, linhas, estado.Painel, selecionar, catalogo);
            PreencherMaterial(janela, grade, catalogo);
        }

        /// <summary>
        /// A seleção de um item de <c>dgDisp</c> — o `U7Epp0og4bx` + `ODLpp1Gpc7y`: as caixas de tag e
        /// quantidade vêm das células 3 e 5, e as do catálogo da célula 4 (o código interno), que o
        /// original procura no vetor do `CarregaDadosLMMatriz`. Devolve a descrição resumida do
        /// material (vazia quando a célula 4 não casa com o catálogo), para a linha de comando.
        /// </summary>
        private static string PreencherMaterial(
            Form janela,
            DataGridView grade,
            IReadOnlyDictionary<int, MaterialDoCatalogo> catalogo)
        {
            TextoDaCaixa(janela, "TBTag", string.Empty);
            TextoDaCaixa(janela, "TBQuantidade", string.Empty);
            TextoDaCaixa(janela, "tbCodigo1", "0");
            TextoDaCaixa(janela, "tbDescricaoResum1", string.Empty);
            TextoDaCaixa(janela, "tbModelo1", string.Empty);
            TextoDaCaixa(janela, "tbFabricante1", string.Empty);

            if (grade == null || grade.Rows.Count == 0)
            {
                return string.Empty;
            }

            DataGridViewRow linha = grade.SelectedRows.Count > 0 ? grade.SelectedRows[0] : grade.Rows[0];
            TextoDaCaixa(janela, "TBTag", Celula(linha, 3));
            TextoDaCaixa(janela, "TBQuantidade", Celula(linha, 5));

            int codigo;
            if (!int.TryParse(Celula(linha, 4), out codigo))
            {
                return string.Empty;
            }

            MaterialDoCatalogo material = CatalogoDeMateriais.Buscar(catalogo, codigo);
            if (material == null)
            {
                // Acontece de verdade: o `lm == 0` do borne (o `BorneSemLm`) não está no catálogo — é
                // o dado, e a caixa do código fica no `0` que o original deixa.
                return "\"" + Celula(linha, 3) + "\" → material "
                    + codigo.ToString(System.Globalization.CultureInfo.InvariantCulture) + " (fora do catálogo)";
            }

            TextoDaCaixa(janela, "tbCodigo1", material.CodigoInterno.ToString(System.Globalization.CultureInfo.InvariantCulture));
            TextoDaCaixa(janela, "tbDescricaoResum1", material.DescricaoResumida);
            TextoDaCaixa(janela, "tbModelo1", material.Modelo);
            TextoDaCaixa(janela, "tbFabricante1", material.Fabricante);

            return "\"" + Celula(linha, 3) + "\" → " + material.CodigoInterno
                + " \"" + material.DescricaoResumida + "\"";
        }

        // ------------------------------------------------------------------ as três ações da tela

        /// <summary>O clique do <c>BTAdicionaLM</c> — o <c>jnTppR04rG4</c> e o `AdicionaUmItemMaterialAvulso`.</summary>
        private static string Adicionar(
            Form janela,
            DataGridView grade,
            EstadoDaLista estado,
            IReadOnlyDictionary<int, MaterialDoCatalogo> catalogo,
            ConfiguracaoPositron config)
        {
            if (grade == null)
            {
                return "ATINDEP: a grade dos itens não está na tela.";
            }

            string codigo = LerCaixa(janela, "tbCodigo1");
            if (!ListaMateriaisEdicao.PodeAcrescentarItem(codigo))
            {
                return "ATINDEP: a caixa do código está no 0 — escolha o material; a linha do dispositivo "
                    + "sem material não entra na lista (o guarda do original).";
            }

            if (config == null || string.IsNullOrEmpty(config.Banco))
            {
                return "ATINDEP: " + Positron.Data.Interface.MensagensDoReverso.BancoNaoConfigurado;
            }

            if (estado.Painel == 0)
            {
                return "ATINDEP: escolha o painel na coluna da esquerda.";
            }

            LinhaListaMaterial item = ListaMateriaisEdicao.ItemNovo(
                config.Dwg,
                estado.Painel,
                LerCaixa(janela, "TBTag"),
                codigo,
                LerCaixa(janela, "TBQuantidade"),
                ListaMateriaisEdicao.OrdemDoItemAvulso(estado.Acrescentados));

            int indice;
            try
            {
                indice = new ProjectStore(config.Banco).AdicionarItemDaLM(item);
            }
            catch (Exception erro)
            {
                return "ATINDEP: falhou ao gravar o item avulso — " + erro.Message;
            }

            estado.Acrescentados++;
            Recarregar(janela, grade, catalogo, config, estado, indice);

            return "ATINDEP: item avulso " + item.IndiceMaterial + " \"" + item.Tag + "\" no painel "
                + estado.Painel + " (quantidade " + item.Quantidade + ", Ordem " + item.Ordem
                + ") gravado — a linha entrou com o Indice " + indice + " do banco.";
        }

        /// <summary>
        /// O clique do <c>BTEditaLM</c> — o <c>eK4ppmS0dUi</c>, nas duas metades do original: a
        /// **lista** (o item avulso substituído) e o **desenho** (o
        /// <c>clsDispositivo.EditaLMDoDispositivo</c> nos blocos das linhas com handle).
        /// </summary>
        private static string Editar(
            Form janela,
            DataGridView grade,
            EstadoDaLista estado,
            IReadOnlyDictionary<int, MaterialDoCatalogo> catalogo,
            IReadOnlyDictionary<int, string> nomes,
            ConfiguracaoPositron config)
        {
            List<LinhaDoItemNaGrade> selecionadas = Selecionadas(grade);
            if (selecionadas.Count == 0)
            {
                return "ATINDEP: escolha o item a editar na grade.";
            }

            if (config == null || string.IsNullOrEmpty(config.Banco))
            {
                return "ATINDEP: " + Positron.Data.Interface.MensagensDoReverso.BancoNaoConfigurado;
            }

            int codigoEscolhido = ListaMateriaisEdicao.CodigoDoTexto(LerCaixa(janela, "tbCodigo1"));
            List<AcaoNoItemDaLM> plano = ListaMateriaisEdicao.PlanoDoMaterialEscolhido(
                selecionadas,
                LerCaixa(janela, "TBTag"),
                LerCaixa(janela, "TBQuantidade"),
                LerCaixa(janela, "tbCodigo1"));

            if (plano.Count == 0)
            {
                return "ATINDEP: nenhuma linha selecionada é item da tela (avulsa) nem dispositivo com "
                    + "handle — não há o que editar.";
            }

            int substituidos = 0;
            int editados = 0;
            int ultimo = 0;
            try
            {
                ProjectStore store = new ProjectStore(config.Banco);
                foreach (AcaoNoItemDaLM acao in plano)
                {
                    if (acao.Tipo == TipoDeAcaoNoItemDaLM.Substituir)
                    {
                        // O `eK4ppmS0dUi`: o `RemoveMaterialAvulso` pelo Indice e o insert de novo.
                        store.RemoverItemDaLM(acao.Indice);
                        ultimo = store.AdicionarItemDaLM(acao.Item);
                        substituidos++;
                        continue;
                    }

                    // A linha **do desenho** também passa pelo banco no original — o
                    // `EditaUmItemMaterialAvulso(indiceLM, indice)` grava o material na propria linha
                    // da `ListaMateriais` (o `UPDATE ... SET IndiceMaterial` pelo `Indice`) **antes**
                    // do `EditaLMDoDispositivo`: a lista e o bloco saem do mesmo clique.
                    editados += store.EditarMaterialDoItemDaLM(acao.Indice, acao.IndiceMaterial);
                }
            }
            catch (Exception erro)
            {
                return "ATINDEP: falhou ao gravar a lista — " + erro.Message;
            }

            // A outra metade do clique no original: o `clsDispositivo.EditaLMDoDispositivo` regrava o
            // XData do bloco (o `iLM1`) e os atributos MODELO/PAINEL/FABRICANTE das linhas do desenho.
            // A lista e o desenho sao a mesma verdade (a linha da grade e o desenho) e os dois tem de
            // sair do clique: gravar so o `IndiceMaterial` deixaria a lista e o bloco discordando, e a
            // proxima projecao (`COMPLM`) desfaria a gravacao.
            List<ItemDoDispositivo> doDesenho = DispositivoDaListaEdicao.ItensParaODesenho(plano);
            string desenho;
            try
            {
                desenho = ResumoDoDesenho(doDesenho.Count == 0
                    ? null
                    : DispositivoDaListaDoDesenho.Executar(doDesenho, nomes, catalogo));
            }
            catch (Exception erro)
            {
                desenho = " o desenho nao foi gravado — " + erro.Message;
            }

            Recarregar(janela, grade, catalogo, config, estado, ultimo);

            return "ATINDEP: " + substituidos + " item(ns) da tela regravado(s) com o material "
                + codigoEscolhido.ToString(System.Globalization.CultureInfo.InvariantCulture)
                + " (" + editados + " linha(s) do desenho com o material gravado na lista)."
                + desenho;
        }

        /// <summary>
        /// O resumo do ramo do desenho para a linha de comando — as contagens do
        /// <see cref="DispositivoDaListaDoDesenho.Resultado"/> que importam ficam em português de
        /// gente; o que não aconteceu não aparece (o `null` é o plano sem linha de desenho).
        /// </summary>
        private static string ResumoDoDesenho(DispositivoDaListaDoDesenho.Resultado resultado)
        {
            if (resultado == null)
            {
                return string.Empty;
            }

            string texto = " o desenho: " + resultado.Dispositivos + " dispositivo(s) — "
                + resultado.LmGravados + " lm(s) regravado(s) no XData (" + resultado.LmIguais
                + " já com o material), " + resultado.AtributosGravados + " atributo(s) — "
                + resultado.AtributosIguais + " já iguais, " + resultado.AtributosNaoAchados
                + " tag(s) fora do bloco.";

            if (resultado.BlocosNaoAchados > 0)
            {
                texto += " " + resultado.BlocosNaoAchados + " handle(s) não estão no desenho.";
            }

            if (resultado.NaoEhDispositivo > 0)
            {
                texto += " " + resultado.NaoEhDispositivo + " bloco(s) não são dispositivo tipo P.";
            }

            if (resultado.XDataCurto > 0)
            {
                texto += " " + resultado.XDataCurto + " dispositivo(s) com o XData curto demais.";
            }

            if (resultado.RegistroNaoAchado > 0)
            {
                texto += " " + resultado.RegistroNaoAchado + " app name(s) fora do buffer do bloco.";
            }

            return texto;
        }

        /// <summary>O clique do <c>BTApagaLM</c> — o <c>eUVppXAWerf</c> (só as linhas avulsas saem).</summary>
        private static string Apagar(
            Form janela,
            DataGridView grade,
            EstadoDaLista estado,
            IReadOnlyDictionary<int, MaterialDoCatalogo> catalogo,
            ConfiguracaoPositron config)
        {
            List<LinhaDoItemNaGrade> selecionadas = Selecionadas(grade);
            if (selecionadas.Count == 0)
            {
                return "ATINDEP: escolha o item a apagar na grade.";
            }

            if (config == null || string.IsNullOrEmpty(config.Banco))
            {
                return "ATINDEP: " + Positron.Data.Interface.MensagensDoReverso.BancoNaoConfigurado;
            }

            int apagadas = 0;
            int doDesenho = 0;
            try
            {
                ProjectStore store = new ProjectStore(config.Banco);

                // O original varre de baixo para cima; a linha do desenho não é tocada (o teste do
                // `Cells[7]`), e aqui ela também aparece na contagem para não sumir em silêncio.
                for (int i = selecionadas.Count - 1; i >= 0; i--)
                {
                    if (!selecionadas[i].Avulso)
                    {
                        doDesenho++;
                        continue;
                    }

                    apagadas += store.RemoverItemDaLM(selecionadas[i].Indice);
                }
            }
            catch (Exception erro)
            {
                return "ATINDEP: falhou ao apagar o item — " + erro.Message;
            }

            Recarregar(janela, grade, catalogo, config, estado, 0);

            return "ATINDEP: " + apagadas + " item(ns) da tela apagado(s)."
                + (doDesenho > 0
                    ? " " + doDesenho + " linha(s) do desenho não entram: quem as escreve é a projeção (o COMPLM)."
                    : string.Empty);
        }

        // ------------------------------------------------------------------ o gancho do harness

        /// <summary>
        /// O gancho do harness (um script não clica nos botões): <c>POSITRON_LIM_PAINEL</c> escolhe o
        /// painel da coluna da esquerda (a tela abre no primeiro da lista, e é o clique nele que
        /// carrega outra grade — sem esta variável as linhas de um painel que não o primeiro ficam
        /// fora do alcance do script), <c>POSITRON_LIM_ITEM</c> (<c>Indice;Tag;Quantidade;Codigo</c>)
        /// seleciona a linha pelo <c>Indice</c> e **depois** preenche as caixas — a seleção chama o
        /// <c>PreencherMaterial</c>, que escreveria por cima do digitado —, e <c>POSITRON_LIM_ACAO</c>
        /// roda a mesma ação do clique.
        /// </summary>
        private static void GanchoDoHarness(
            Form janela,
            DataGridView grade,
            EstadoDaLista estado,
            IReadOnlyDictionary<int, MaterialDoCatalogo> catalogo,
            IReadOnlyDictionary<int, string> nomes,
            ConfiguracaoPositron config)
        {
            string item = Environment.GetEnvironmentVariable("POSITRON_LIM_ITEM");
            string acao = Environment.GetEnvironmentVariable("POSITRON_LIM_ACAO");
            string painelPedido = Environment.GetEnvironmentVariable("POSITRON_LIM_PAINEL");

            if (string.IsNullOrEmpty(item) && string.IsNullOrEmpty(acao) && string.IsNullOrEmpty(painelPedido))
            {
                return;
            }

            int painel;
            if (grade != null
                && !string.IsNullOrEmpty(painelPedido)
                && int.TryParse(painelPedido, out painel)
                && painel != 0
                && painel != estado.Painel)
            {
                // O `SelectionChanged` da coluna dos paineis, sem o clique.
                estado.Painel = painel;
                Recarregar(janela, grade, catalogo, config, estado, 0);
                Plugin.Escrever("ATINDEP: painel " + painel + " escolhido pelo POSITRON_LIM_PAINEL ("
                    + grade.Rows.Count + " item(ns); " + ResumoDaPintura(grade) + ").");
            }

            if (!string.IsNullOrEmpty(item))
            {
                string[] campos = item.Split(';');

                int indice;
                if (grade != null && int.TryParse(Campo(campos, 0), out indice) && indice != 0)
                {
                    // A grade é de seleção múltipla: a linha do script tem de ficar **sozinha**
                    // selecionada (num clique o usuário escolhe uma ou algumas, e o Ctrl é dele).
                    grade.ClearSelection();
                    foreach (DataGridViewRow linha in grade.Rows)
                    {
                        if (CodigoDaLinha(linha, 0) == indice)
                        {
                            linha.Selected = true;
                            PreencherMaterial(janela, grade, catalogo);
                            break;
                        }
                    }
                }

                TextoDaCaixa(janela, "TBTag", Campo(campos, 1));
                TextoDaCaixa(janela, "TBQuantidade", Campo(campos, 2));
                TextoDaCaixa(janela, "tbCodigo1", Campo(campos, 3));
            }

            if (string.Equals(acao, "editar", StringComparison.OrdinalIgnoreCase))
            {
                Plugin.Escrever(Editar(janela, grade, estado, catalogo, nomes, config));
            }
            else if (string.Equals(acao, "apagar", StringComparison.OrdinalIgnoreCase))
            {
                Plugin.Escrever(Apagar(janela, grade, estado, catalogo, config));
            }
            else if (string.Equals(acao, "adicionar", StringComparison.OrdinalIgnoreCase))
            {
                Plugin.Escrever(Adicionar(janela, grade, estado, catalogo, config));
            }
        }

        // ------------------------------------------------------------------ os ajudantes

        private static void Ligar(Button botao, EventHandler acao)
        {
            if (botao != null)
            {
                botao.Click += acao;
            }
        }

        /// <summary>As linhas **selecionadas** da grade, na ordem da tela — as do `eK4ppmS0dUi`/`eUVppXAWerf`.</summary>
        private static List<LinhaDoItemNaGrade> Selecionadas(DataGridView grade)
        {
            List<LinhaDoItemNaGrade> selecionadas = new List<LinhaDoItemNaGrade>();
            if (grade == null)
            {
                return selecionadas;
            }

            foreach (DataGridViewRow linha in grade.SelectedRows)
            {
                selecionadas.Add(DaLinha(linha));
            }

            return selecionadas;
        }

        /// <summary>A linha da grade nas doze células posicionais do <c>formataDGDisp</c>.</summary>
        private static LinhaDoItemNaGrade DaLinha(DataGridViewRow linha)
        {
            return new LinhaDoItemNaGrade
            {
                Indice = CodigoDaLinha(linha, 0),
                DWG = CodigoDaLinha(linha, 1),
                Painel = CodigoDaLinha(linha, 2),
                Tag = Celula(linha, 3),
                IndiceMaterial = CodigoDaLinha(linha, 4),
                Quantidade = CodigoDaLinha(linha, 5),
                Ordem = CodigoDaLinha(linha, 6),
                Avulso = Logico(linha, 7),
                Destino = Celula(linha, 8),
                DescDestino = Celula(linha, 9),
                Alternativo = Celula(linha, 10),
                Handle = Celula(linha, 11),
            };
        }

        private static int CodigoDaLinha(DataGridViewRow linha, int coluna)
        {
            int codigo;
            return int.TryParse(Celula(linha, coluna), out codigo) ? codigo : 0;
        }

        /// <summary>A célula 7 (`Avulso`) como booleano — a grade a recebe do banco como `bool`.</summary>
        private static bool Logico(DataGridViewRow linha, int coluna)
        {
            if (linha == null || coluna >= linha.Cells.Count)
            {
                return false;
            }

            object valor = linha.Cells[coluna].Value;
            if (valor is bool)
            {
                return (bool)valor;
            }

            bool logico;
            return bool.TryParse(Celula(linha, coluna), out logico) && logico;
        }

        private static string Campo(string[] campos, int indice)
        {
            return indice < campos.Length ? (campos[indice] ?? string.Empty) : string.Empty;
        }

        /// <summary>
        /// O que continua sem regra na tela: a pesquisa do material (o `frmPesquisaMateriais`) — o botão
        /// fica desabilitado, sem dica (o original não tem).
        /// </summary>
        private static void Motivos(Form janela)
        {
            Control pesquisa = ControlesDaTela.Procurar(janela, "btPesquisaLM1");
            if (pesquisa != null)
            {
                pesquisa.Enabled = false;
            }
        }
    }
}
