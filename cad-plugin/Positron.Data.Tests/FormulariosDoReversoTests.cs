using System.Collections.Generic;
using Positron.Data.Interface.Mapas;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// O mapa das janelas do reverso (`FormulariosDoReverso`) — o que o
    /// `scripts/extrair-formularios-do-reverso.ps1` tirou do designer dos 127 `frm*`.
    ///
    /// Estes testes são o contrato da decodificação: as contagens são as **medidas** no
    /// decompilado (2026-09-24) e a integridade estrutural (todo pai existe, o título não é
    /// vazio) é o que garante que o <c>RenderizadorDeTelas</c> consegue montar as telas.
    /// </summary>
    public class FormulariosDoReversoTests
    {
        [Fact]
        public void SaoAsCentoEVinteESeteTelasDoReverso()
        {
            Assert.Equal(127, FormulariosDoReverso.Quantidade);
            Assert.Equal(127, FormulariosDoReverso.Todas.Count);
        }

        [Fact]
        public void NaoHaNomeDeTelaRepetido()
        {
            HashSet<string> nomes = new HashSet<string>();
            foreach (Tela tela in FormulariosDoReverso.Todas)
            {
                Assert.True(nomes.Add(tela.Nome), "tela repetida: " + tela.Nome);
            }
        }

        [Fact]
        public void OsCamposSomamOTotalMedidoNoReverso()
        {
            // 2589 controles do designer + 835 colunas de grade das rotinas de carga (eram 842 ate
            // o `mMensagem[...].ToString().ToUpper()` resolver: 7 cabecalhos eram o mesmo de outra
            // rotina da mesma grade).
            int total = 0;
            foreach (Tela tela in FormulariosDoReverso.Todas)
            {
                total += tela.Campos.Count;
            }

            Assert.Equal(3424, total);
        }

        [Fact]
        public void SoAsDuasTelasDeFundoNaoTemControle()
        {
            List<string> vazias = new List<string>();
            foreach (Tela tela in FormulariosDoReverso.Todas)
            {
                if (tela.Campos.Count == 0)
                {
                    vazias.Add(tela.Nome);
                }
            }

            vazias.Sort();
            Assert.Equal(new[] { "FrmBuscaNuvem", "frmSplash" }, vazias.ToArray());
        }

        [Fact]
        public void TodaTelaTemNomeTituloETamanho()
        {
            Assert.All(FormulariosDoReverso.Todas, tela =>
            {
                Assert.False(string.IsNullOrEmpty(tela.Nome));
                Assert.False(string.IsNullOrEmpty(tela.Titulo));
                Assert.True(tela.Largura > 0, tela.Nome + " sem largura");
                Assert.True(tela.Altura > 0, tela.Nome + " sem altura");
                Assert.True(tela.Origem > 0, tela.Nome + " sem a linha do designer");
            });
        }

        /// <summary>
        /// A integridade de que o renderizador depende: todo `Pai` citado existe como controle
        /// na própria tela. Um pai órfão deixaria controles fora da janela em silêncio.
        /// </summary>
        [Fact]
        public void TodoPaiCitadoExisteNaPropriaTela()
        {
            Assert.All(FormulariosDoReverso.Todas, tela =>
            {
                HashSet<string> nomes = new HashSet<string>();
                foreach (Campo campo in tela.Campos)
                {
                    if (!string.IsNullOrEmpty(campo.Nome))
                    {
                        nomes.Add(campo.Nome);
                    }
                }

                foreach (Campo campo in tela.Campos)
                {
                    if (!string.IsNullOrEmpty(campo.Pai))
                    {
                        Assert.True(nomes.Contains(campo.Pai), tela.Nome + ": pai orfao " + campo.Pai + " (filho " + campo.Nome + ")");
                    }
                }
            });
        }

        [Fact]
        public void TodoCampoTemTipoECaixaValida()
        {
            Assert.All(FormulariosDoReverso.Todas, tela => Assert.All(tela.Campos, campo =>
            {
                Assert.False(string.IsNullOrEmpty(campo.Tipo));

                // posicao e tamanho vem em par: ou o designer pos os dois, ou nenhum
                Assert.Equal(campo.X == Campo.NaoDefinido, campo.Y == Campo.NaoDefinido);
                Assert.Equal(campo.Largura == Campo.NaoDefinido, campo.Altura == Campo.NaoDefinido);

                // a posicao pode ser negativa (o original tem controle em -18); o tamanho, nao
                if (campo.TemTamanho)
                {
                    Assert.True(campo.Largura >= 0, tela.Nome + "/" + campo.Nome + ": largura " + campo.Largura);
                    Assert.True(campo.Altura >= 0, tela.Nome + "/" + campo.Nome + ": altura " + campo.Altura);
                }
            }));
        }

        /// <summary>Ha controle do original fora da janela (`X` negativo) — e ele nao pode virar 0.</summary>
        [Fact]
        public void ACoordenadaNegativaDoDesignerEPreservada()
        {
            Tela tela = FormulariosDoReverso.Buscar("frmVerificadorProjetoFiacao");
            Assert.NotNull(tela);
            Assert.Contains(tela.Campos, campo => campo.X < 0);
        }

        /// <summary>O nome da imagem e o **nome do recurso** do original, nao um caminho.</summary>
        [Fact]
        public void OIconeDoCampoENomeDeRecurso()
        {
            Assert.All(FormulariosDoReverso.Todas, tela => Assert.All(tela.Campos, campo =>
            {
                if (campo.Imagem != null)
                {
                    Assert.DoesNotContain(".", campo.Imagem);
                    Assert.DoesNotContain("/", campo.Imagem);
                }
            }));
        }

        [Fact]
        public void OPesquisaXdatasSaiComODesignerDoOriginal()
        {
            Tela tela = FormulariosDoReverso.Buscar("frmPesquisaXdatas");

            Assert.NotNull(tela);
            // O titulo do designer e "Apaga xData Selecionado", mas o construtor o troca pela
            // mMensagem[1, 1930] — o mapa fica com o que o usuario ve.
            Assert.Equal("Apagar XDatas de Terceiros", tela.Titulo);
            Assert.Equal(304, tela.Largura);
            Assert.Equal(461, tela.Altura);

            Campo apagar = Achar(tela, "BtApaga");
            Assert.Equal("Button", apagar.Tipo);
            Assert.Equal(254, apagar.X);
            Assert.Equal(407, apagar.Y);
            Assert.Equal(40, apagar.Largura);
            Assert.Equal(42, apagar.Altura);
            Assert.Equal("Delete_32", apagar.Imagem);
            Assert.Equal("Flat", apagar.Propriedade("FlatStyle"));

            Campo grade = Achar(tela, "DG");
            Assert.Equal("DataGridView", grade.Tipo);
            Assert.Equal(286, grade.Largura);
            Assert.Equal("FullRowSelect", grade.Propriedade("SelectionMode"));

            Campo marcar = Achar(tela, "CkXdataEletron");
            Assert.Equal("CheckBox", marcar.Tipo);
            Assert.Equal("Incluir xData Eletron", marcar.Texto);

            // as colunas da grade vem das rotinas de carga do original
            Assert.Contains(Filhos(tela, "DG"), campo => campo.EhColuna && campo.Texto == "xData");
            Assert.Contains(Filhos(tela, "DG"), campo => campo.EhColuna && campo.Texto == "Quantidade");
        }

        [Fact]
        public void OSplashEOMesmoDoOriginal()
        {
            Tela tela = FormulariosDoReverso.Buscar("frmSplash");

            Assert.NotNull(tela);
            Assert.Equal(625, tela.Largura);
            Assert.Equal(506, tela.Altura);
            Assert.Empty(tela.Campos);
            Assert.Equal("SplashEL26", tela.Propriedade("BackgroundImage"));
            Assert.Equal("None", tela.Propriedade("FormBorderStyle"));
            Assert.Equal("Blue", tela.Propriedade("TransparencyKey"));
        }

        [Fact]
        public void OTituloComConcatenacaoDaMensagemEResolvido()
        {
            // Text = Conversions.ToString(Operators.ConcatenateObject(
            //     Operators.ConcatenateObject(mMensagem[1, 595], " - "), mMensagem[1, 596]))
            Tela tela = FormulariosDoReverso.Buscar("frmTrocaEditaBlocos");

            Assert.NotNull(tela);
            Assert.Equal("Trocar Blocos - Substituir Blocos", tela.Titulo);
        }

        /// <summary>
        /// O que o original so monta em tempo de execucao sai como marcador `{...}` — nunca um
        /// valor inventado (a regra do `POSITRON.md` §6).
        /// </summary>
        [Fact]
        public void OTituloDeExecucaoViraMarcador()
        {
            Tela tela = FormulariosDoReverso.Buscar("frmRelatorio_TAF");

            Assert.NotNull(tela);
            Assert.StartsWith("Relatório TAF >> ", tela.Titulo);
            Assert.Contains("{DeclaracoesGeral.arqAtivo.Nome}", tela.Titulo);
        }

        [Fact]
        public void ABuscaIgnoraAMaiusculaEZeraONaoEncontrado()
        {
            Assert.NotNull(FormulariosDoReverso.Buscar("FRMPESQUISAXDATAS"));
            Assert.Same(FormulariosDoReverso.Buscar("frmSplash"), FormulariosDoReverso.Buscar("frmSplash"));
            Assert.Null(FormulariosDoReverso.Buscar("frmNaoExiste"));
            Assert.Null(FormulariosDoReverso.Buscar(null));
            Assert.Null(FormulariosDoReverso.Buscar(string.Empty));
        }

        [Fact]
        public void OsFilhosSaemNaOrdemDoControlsAdd()
        {
            Tela tela = FormulariosDoReverso.Buscar("frmPesquisaXdatas");

            IReadOnlyList<Campo> raizes = tela.Raizes;
            Assert.Equal(4, raizes.Count);
            for (int i = 1; i < raizes.Count; i++)
            {
                Assert.True(raizes[i - 1].Ordem < raizes[i].Ordem, "fora de ordem: " + raizes[i].Nome);
            }
        }

        [Fact]
        public void AJanelaMaisCheiaDoReversoContinuaInteira()
        {
            Tela tela = FormulariosDoReverso.Buscar("frmConfiguracaoGeral");

            Assert.NotNull(tela);
            Assert.Equal(110, tela.Campos.Count);
            Assert.Equal("Configuração Geral", tela.Titulo);
            // as abas puxam os paineis: o TabPage e filho do TabControl
            Assert.Contains(tela.Campos, campo => campo.Tipo == "TabControl");
            Assert.Contains(tela.Campos, campo => campo.Tipo == "TabPage" && !string.IsNullOrEmpty(campo.Pai));
        }

        /// <summary>
        /// A rotina de idioma do original troca o texto do designer pelo da `mMensagem` em toda
        /// carga: o "CKNomeVisível" do designer aparece como "Nome Visível" (a captura do PORT).
        /// </summary>
        [Fact]
        public void OTextoTraduzidoNaCargaValeMaisQueODoDesigner()
        {
            Tela portas = FormulariosDoReverso.Buscar("frmPortas");
            Assert.Equal("Nome Visível", Achar(portas, "CKNomeVisivel").Texto);
            Assert.Equal("Múltipla Inserção", Achar(portas, "GroupBox1").Texto);

            // a aba traduzida pelo indice (`TabControl1.TabPages[0].Text = mMensagem[...]`)
            Assert.Equal("Seleção", Achar(FormulariosDoReverso.Buscar("frmClonar"), "TabPage1").Texto);
        }

        /// <summary>
        /// O ajuste das colunas que a rotina de carga faz logo depois do `Columns.Add`: o indice
        /// escondido (`Visible = false`) e a largura calculada sobre a do designer
        /// (`float num = dgEquip.Width - 22`, 184 - 22 = 162).
        /// </summary>
        [Fact]
        public void AColunaDaCargaTrazALarguraEOVisibleDaRotina()
        {
            Tela tela = FormulariosDoReverso.Buscar("frmTopograficoAnilha");
            IReadOnlyList<Campo> colunas = Filhos(tela, "dgEquip");

            Assert.Equal(2, colunas.Count);
            Assert.Equal("Indice", colunas[0].Texto);
            Assert.Equal("False", colunas[0].Propriedade("Visible"));
            Assert.Equal("162", colunas[1].Propriedade("Width"));
        }

        /// <summary>O estilo de celula do designer sai como `Estilo.Sub` (o cabecalho em negrito).</summary>
        [Fact]
        public void OEstiloDoCabecalhoDaGradeEPreservado()
        {
            Campo grade = Achar(FormulariosDoReverso.Buscar("frmTopograficoAnilha"), "dgEquip");

            Assert.Contains("FontStyle.Bold", grade.Propriedade("ColumnHeadersDefaultCellStyle.Font"));
            Assert.Equal("MiddleCenter", grade.Propriedade("ColumnHeadersDefaultCellStyle.Alignment"));
        }

        private static Campo Achar(Tela tela, string nome)
        {
            foreach (Campo campo in tela.Campos)
            {
                if (campo.Nome == nome)
                {
                    return campo;
                }
            }

            throw new Xunit.Sdk.XunitException("controle nao encontrado na tela " + tela.Nome + ": " + nome);
        }

        private static IReadOnlyList<Campo> Filhos(Tela tela, string pai)
        {
            return tela.Filhos(pai);
        }
    }
}
