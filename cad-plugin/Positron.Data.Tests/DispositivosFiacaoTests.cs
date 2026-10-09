using System;
using System.Collections.Generic;
using Positron.Data.Bornes;
using Positron.Data.Fiacao;
using Positron.Data.Layout;
using Xunit;

namespace Positron.Data.Tests
{
    public class DispositivosFiacaoTests
    {
        /// <summary>Monta um XData com o app name na posição 0 e os valores nas demais.</summary>
        private static IReadOnlyList<TypedXData> XData(params object[] valores)
        {
            TypedXData[] xdata = new TypedXData[valores.Length];
            for (int i = 0; i < valores.Length; i++)
            {
                xdata[i] = new TypedXData((short)(i == 0 ? 1001 : 1000), valores[i]);
            }

            return xdata;
        }

        /// <summary>Array de <paramref name="tamanho"/> posições com os valores dados nos índices indicados.</summary>
        private static IReadOnlyList<TypedXData> Espalhado(int tamanho, params object[] posicionados)
        {
            object[] valores = new object[tamanho];
            for (int i = 0; i + 1 < posicionados.Length; i += 2)
            {
                valores[(int)posicionados[i]] = posicionados[i + 1];
            }

            return XData(valores);
        }

        [Fact]
        public void Le_dispositivo_tipo_P_com_tag_e_painel()
        {
            // Nome1=2, Nome2=3, Alternativo=4, Painel=8, indexModelo=12, Complementar=13.
            IReadOnlyList<TypedXData> xdata = Espalhado(
                14, 1, "P", 2, "DEV1", 3, "B", 4, "ALT", 8, (short)3, 12, 7, 13, false);

            DispositivoFiacao dispositivo;
            Assert.True(DispositivoFiacaoXData.Ler(xdata, out dispositivo));
            Assert.Equal("P", dispositivo.Tipo);
            Assert.Equal("DEV1", dispositivo.Nome1);
            Assert.Equal("DEV1/B", dispositivo.Tag);
            Assert.Equal("ALT", dispositivo.Alternativo);
            Assert.Equal((short)3, dispositivo.Painel);
            Assert.Equal(7, dispositivo.IndexModelo);
            Assert.False(dispositivo.PainelPendente);
        }

        [Fact]
        public void Sem_nome2_a_tag_nao_leva_barra()
        {
            IReadOnlyList<TypedXData> xdata = Espalhado(
                14, 1, "P", 2, "DEV1", 3, "", 4, "", 8, (short)1, 12, 0, 13, false);

            DispositivoFiacao dispositivo;
            Assert.True(DispositivoFiacaoXData.Ler(xdata, out dispositivo));
            Assert.Equal("DEV1", dispositivo.Tag);
        }

        [Fact]
        public void Porta_E_tem_painel_pendente_e_handle_da_mascara()
        {
            // Nome1=2, Nome2=3, handle da máscara=4, indexModelo=5, Alternativo=11.
            IReadOnlyList<TypedXData> xdata = Espalhado(
                12, 1, "E", 2, "PRT", 3, "2", 4, "ABC", 5, 9, 11, "ALT");

            DispositivoFiacao dispositivo;
            Assert.True(DispositivoFiacaoXData.Ler(xdata, out dispositivo));
            Assert.Equal("E", dispositivo.Tipo);
            Assert.Equal("PRT/2", dispositivo.Tag);
            Assert.Equal("ABC", dispositivo.HandleMascara);
            Assert.Equal(9, dispositivo.IndexModelo);
            Assert.True(dispositivo.PainelPendente);

            // O adapter resolve o painel pela máscara; aqui simulamos isso.
            dispositivo.DefinirPainel(5);
            Assert.Equal((short)5, dispositivo.Painel);
            Assert.False(dispositivo.PainelPendente);
        }

        [Fact]
        public void Importado_le_tipo_I_e_painel_do_indice_9()
        {
            IReadOnlyList<TypedXData> xdata = Espalhado(
                10, 1, "I", 2, "IMP1", 3, "X", 9, (short)4);

            DispositivoFiacao dispositivo;
            Assert.True(DispositivoFiacaoXData.LerImportado(xdata, out dispositivo));
            Assert.Equal("I", dispositivo.Tipo);
            Assert.Equal("IMP1/X", dispositivo.Tag);
            Assert.Equal((short)4, dispositivo.Painel);
        }

        [Fact]
        public void Tipo_B_nao_e_dispositivo()
        {
            IReadOnlyList<TypedXData> xdata = Espalhado(14, 1, "B", 2, "BORNE");
            DispositivoFiacao dispositivo;
            Assert.False(DispositivoFiacaoXData.Ler(xdata, out dispositivo));
        }

        [Fact]
        public void Nao_borne_casa_com_dispositivo_pela_tabela_de_deslocamento()
        {
            // Inserção em (0,0), ponto de ligação do bloco em (10,5).
            DispositivoFiacao dispositivo = new DispositivoFiacao
            {
                Tipo = "P",
                Nome1 = "DEV1",
                Painel = 2,
                Layer = "PAG1",
                X = 0.0,
                Y = 0.0,
                NomeBloco = "BLK",
                TemBounds = true,
                MinX = 9.0,
                MinY = 4.0,
                MaxX = 11.0,
                MaxY = 6.0,
            };
            dispositivo.Terminais.Add(new TerminalDispositivo { Atributo = "T1", Texto = "5", X = 10.0, Y = 5.0 });
            TabelaDeslocamentoBlocos tabela = TabelaDeslocamentoBlocos.Ler(new[]
            {
                new DeslocamentoBloco { Nome = "BLK", X = 10.0, Y = 5.0 },
            });

            string terminal;
            DispositivoFiacao casado = CasamentoDispositivo.Proximo(
                10.1, 5.0, "PAG1", 2, new List<DispositivoFiacao> { dispositivo },
                CasamentoDispositivo.Tolerancia, tabela, out terminal);

            Assert.Same(dispositivo, casado);
            Assert.Equal("DEV1", casado.Tag);
            Assert.Equal("5", terminal);
        }

        [Fact]
        public void Sem_terminal_nao_casa()
        {
            // Bloco de dispositivo sem atributo T*/B*: o ltZUHdAX7R o rejeita.
            DispositivoFiacao dispositivo = new DispositivoFiacao
            {
                Tipo = "P", Nome1 = "DEV1", Painel = 2, Layer = "PAG1", X = 0.0, Y = 0.0,
            };

            DispositivoFiacao casado = CasamentoDispositivo.Proximo(
                0.0, 0.0, "PAG1", 2, new List<DispositivoFiacao> { dispositivo },
                CasamentoDispositivo.Tolerancia, null);

            Assert.Null(casado);
        }

        [Fact]
        public void Terminal_indefinido_nao_casa()
        {
            DispositivoFiacao dispositivo = new DispositivoFiacao
            {
                Tipo = "P", Nome1 = "DEV1", Painel = 2, Layer = "PAG1", X = 0.0, Y = 0.0,
            };
            dispositivo.Terminais.Add(new TerminalDispositivo { Atributo = "T1", Texto = "?", X = 0.0, Y = 0.0 });

            DispositivoFiacao casado = CasamentoDispositivo.Proximo(
                0.0, 0.0, "PAG1", 2, new List<DispositivoFiacao> { dispositivo },
                CasamentoDispositivo.Tolerancia, null);

            Assert.Null(casado);
        }

        [Fact]
        public void Escolhe_o_terminal_mais_proximo_do_ponto()
        {
            DispositivoFiacao dispositivo = new DispositivoFiacao
            {
                Tipo = "P", Nome1 = "DEV1", Painel = 2, Layer = "PAG1", X = 0.0, Y = 0.0,
            };
            dispositivo.Terminais.Add(new TerminalDispositivo { Atributo = "T1", Texto = "1", X = 5.0, Y = 0.0 });
            dispositivo.Terminais.Add(new TerminalDispositivo { Atributo = "T2", Texto = "2", X = 0.1, Y = 0.0 });

            string terminal;
            DispositivoFiacao casado = CasamentoDispositivo.Proximo(
                0.0, 0.0, "PAG1", 2, new List<DispositivoFiacao> { dispositivo },
                CasamentoDispositivo.Tolerancia, null, out terminal);

            Assert.Same(dispositivo, casado);
            Assert.Equal("2", terminal);
        }

        [Fact]
        public void Tipo_P_ignora_atributo_B_para_o_terminal()
        {
            // No original, só o E lê B*; um P que só tenha B1 não casa.
            DispositivoFiacao dispositivo = new DispositivoFiacao
            {
                Tipo = "P", Nome1 = "DEV1", Painel = 2, Layer = "PAG1", X = 0.0, Y = 0.0,
            };
            dispositivo.Terminais.Add(new TerminalDispositivo { Atributo = "B1", Texto = "5", X = 0.0, Y = 0.0 });

            DispositivoFiacao casado = CasamentoDispositivo.Proximo(
                0.0, 0.0, "PAG1", 2, new List<DispositivoFiacao> { dispositivo },
                CasamentoDispositivo.Tolerancia, null);

            Assert.Null(casado);
        }

        [Fact]
        public void Tipo_E_aceita_atributo_B_para_o_terminal()
        {
            DispositivoFiacao dispositivo = new DispositivoFiacao
            {
                Tipo = "E", Nome1 = "PRT", Painel = 2, Layer = "PAG1", X = 0.0, Y = 0.0,
            };
            dispositivo.Terminais.Add(new TerminalDispositivo { Atributo = "B2", Texto = "7", X = 0.0, Y = 0.0 });

            string terminal;
            DispositivoFiacao casado = CasamentoDispositivo.Proximo(
                0.0, 0.0, "PAG1", 2, new List<DispositivoFiacao> { dispositivo },
                CasamentoDispositivo.Tolerancia, null, out terminal);

            Assert.Same(dispositivo, casado);
            Assert.Equal("7", terminal);
        }

        [Fact]
        public void Painel_diferente_nao_casa()
        {
            DispositivoFiacao dispositivo = new DispositivoFiacao
            {
                Tipo = "P", Nome1 = "DEV1", Painel = 2, Layer = "PAG1", X = 0.0, Y = 0.0,
            };

            DispositivoFiacao casado = CasamentoDispositivo.Proximo(
                0.0, 0.0, "PAG1", 5, new List<DispositivoFiacao> { dispositivo },
                CasamentoDispositivo.Tolerancia, null);

            Assert.Null(casado);
        }

        [Fact]
        public void Painel_pendente_nao_casa()
        {
            DispositivoFiacao dispositivo = new DispositivoFiacao
            {
                Tipo = "E", Nome1 = "PRT", Layer = "PAG1", X = 0.0, Y = 0.0, PainelPendente = true,
            };

            DispositivoFiacao casado = CasamentoDispositivo.Proximo(
                0.0, 0.0, "PAG1", 1, new List<DispositivoFiacao> { dispositivo },
                CasamentoDispositivo.Tolerancia, null);

            Assert.Null(casado);
        }

        [Fact]
        public void Mascara_M_nunca_da_tag()
        {
            DispositivoFiacao mascara = new DispositivoFiacao
            {
                Tipo = "M", Nome1 = "MASC", Painel = 1, Layer = "PAG1", X = 0.0, Y = 0.0,
            };

            DispositivoFiacao casado = CasamentoDispositivo.Proximo(
                0.0, 0.0, "PAG1", 1, new List<DispositivoFiacao> { mascara },
                CasamentoDispositivo.Tolerancia, null);

            Assert.Null(casado);
        }

        [Fact]
        public void Escolhe_o_dispositivo_mais_proximo()
        {
            DispositivoFiacao longo = new DispositivoFiacao
            {
                Tipo = "P", Nome1 = "LONGE", Painel = 1, Layer = "PAG1", X = 0.4, Y = 0.0,
            };
            longo.Terminais.Add(new TerminalDispositivo { Atributo = "T1", Texto = "1", X = 0.4, Y = 0.0 });
            DispositivoFiacao perto = new DispositivoFiacao
            {
                Tipo = "P", Nome1 = "PERTO", Painel = 1, Layer = "PAG1", X = 0.05, Y = 0.0,
            };
            perto.Terminais.Add(new TerminalDispositivo { Atributo = "T1", Texto = "2", X = 0.05, Y = 0.0 });

            DispositivoFiacao casado = CasamentoDispositivo.Proximo(
                0.0, 0.0, "PAG1", 1, new List<DispositivoFiacao> { longo, perto },
                CasamentoDispositivo.Tolerancia, null);

            Assert.Same(perto, casado);
        }

        [Fact]
        public void Nao_borne_recebe_tag_do_dispositivo_e_posicao_do_layout()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                FiacaoProjetor projetor = new FiacaoProjetor(store);

                // Ponto não-borne na inserção do dispositivo, sem tag ainda.
                List<PontoFiacao> pontos = new List<PontoFiacao>
                {
                    new PontoFiacao { Painel = 1, Potencial = 4, X = 0.0, Y = 0.0, Layer = "PAG1" },
                };

                DispositivoFiacao dispositivo = new DispositivoFiacao
                {
                    Tipo = "P", Nome1 = "D1", Painel = 1, Layer = "PAG1", X = 0.1, Y = 0.0,
                };
                // O bloco dá o terminal (o ltZUHdAX7R exige terminal não-vazio).
                dispositivo.Terminais.Add(new TerminalDispositivo { Atributo = "T1", Texto = "5", X = 0.1, Y = 0.0 });
                List<DispositivoFiacao> dispositivos = new List<DispositivoFiacao> { dispositivo };

                // O layout casa por (painel, tag) — só funciona depois que o
                // dispositivo deu a tag ao ponto.
                LayoutPosicoes posicoes = LayoutPosicoes.Ler(new List<PosicaoLayout>
                {
                    new PosicaoLayout { Painel = 1, Tag = "D1", PosicaoNum = 3, Ordem = 1 },
                });

                projetor.Projetar(
                    pontos,
                    new ContextoProjecao { Dwg = 1, Criador = "ana", Data = DateTime.Now },
                    null,
                    posicoes,
                    null,
                    dispositivos);

                IReadOnlyList<Positron.Contract.FiacaoRow> linhas = store.FiacaoDoPainel(1);
                Positron.Contract.FiacaoRow linha = Assert.Single(linhas);
                Assert.Equal("D1", linha.Tag);
                Assert.Equal("P", linha.Tipo);
                Assert.Equal(3L, linha.PosicaoNum ?? 0);
                Assert.Equal(-1L, linha.TipoBorne ?? 0);
                // O terminal vem do atributo escolhido no dispositivo.
                Assert.Equal("5", linha.Terminal);
                Assert.Equal(5.0, linha.TerminalNum ?? -1.0);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }
    }
}
