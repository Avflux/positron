using System.Collections.Generic;
using Positron.Data;
using Positron.Data.Fiacao;
using Positron.Data.Modelos;
using Xunit;

namespace Positron.Data.Tests
{
    public class ContatosTests
    {
        [Fact]
        public void Le_os_modelos_de_contato()
        {
            List<TypedXData> valores = new List<TypedXData> { new TypedXData(1071, 1) };
            AcrescentaModelo(valores, 7, "CONT7", "1;2", "H");

            List<ModeloContato> modelos = ModelosContato.LerModelos(valores);

            ModeloContato modelo = Assert.Single(modelos);
            Assert.Equal(7, modelo.Indice);
            Assert.Equal("CONT7", modelo.Nome);
            Assert.Equal("1;2", modelo.TerminaisDoDispositivo);
            Assert.Equal("H", modelo.Orientacao);
        }

        [Fact]
        public void Le_os_contatos_auxiliares_com_tipo()
        {
            List<TypedXData> valores = new List<TypedXData> { new TypedXData(1071, 0) };
            AcrescentaAuxiliar(valores, 1, "A1", "A2", "", 1, "H"); // NA
            AcrescentaAuxiliar(valores, 2, "B1", "", "", 3, "V");  // RV

            List<ContatoAuxiliar> auxiliares = ModelosContato.LerAuxiliares(valores);

            Assert.Equal(2, auxiliares.Count);
            Assert.Equal("NA", auxiliares[0].Tipo);
            Assert.Equal("A1", auxiliares[0].T1);
            Assert.Equal("RV", auxiliares[1].Tipo);
            Assert.Equal(string.Empty, auxiliares[1].T2);
        }

        [Fact]
        public void Le_o_dispositivo_tipo_p()
        {
            List<TypedXData> valores = new List<TypedXData>();
            valores.Add(new TypedXData(1001, "Dispositivo"));
            valores.Add(new TypedXData(1000, "P"));
            valores.Add(new TypedXData(1000, "N1"));
            for (int i = 3; i < 26; i++)
            {
                valores.Add(new TypedXData(1071, 0));
            }

            valores[8] = new TypedXData(1070, (short)2);   // painel
            valores[12] = new TypedXData(1071, 7);         // índice do modelo
            valores[13] = new TypedXData(1071, 0);         // complementar

            DispositivoXData dado;
            Assert.True(DispositivoXData.Ler(valores, out dado));
            Assert.Equal((short)2, dado.Painel);
            Assert.Equal(7, dado.IndexModelo);
        }

        [Fact]
        public void Terminais_da_bobina_nao_repetem_os_do_dispositivo()
        {
            // O `DivideTerminais(ref List, ...)` do original acumula e **dedupa contra
            // a lista**: os terminais das bobinas só acrescentam o que ainda não está lá.
            // Regressão do banco do produto: o modelo 52 tem 15 terminais, e o recoder
            // gravava 18 (repetia 1, 2 e B1).
            List<ModeloContato> modelos = new List<ModeloContato>
            {
                new ModeloContato { Indice = 52, Nome = "BF-4", TerminaisDoDispositivo = "1;2;3" },
            };

            Dictionary<int, string> bobinas = new Dictionary<int, string> { [52] = "1;2;4" };

            List<Contato4F> linhas = Contatos4FGerador.Gerar(modelos, new List<int> { 52 }, null, bobinas);

            Assert.Equal(new[] { "1", "2", "3", "4" }, linhas.ConvertAll(l => l.Terminal).ToArray());
        }

        [Fact]
        public void Gera_contatos_do_dispositivo_e_dos_auxiliares()
        {
            List<ModeloContato> modelos = new List<ModeloContato>
            {
                new ModeloContato { Indice = 7, Nome = "CONT7", TerminaisDoDispositivo = "1;2", Orientacao = "H;V" },
                new ModeloContato { Indice = 8, Nome = "CONT8", TerminaisDoDispositivo = "9" },
            };

            Dictionary<int, IReadOnlyList<ContatoAuxiliar>> auxiliares =
                new Dictionary<int, IReadOnlyList<ContatoAuxiliar>>
                {
                    [7] = new List<ContatoAuxiliar>
                    {
                        new ContatoAuxiliar { T1 = "A1", T2 = "A2", Orientacao = "H;V" },
                    },
                };

            Dictionary<int, string> bobinas = new Dictionary<int, string> { [7] = "3;" };

            List<Contato4F> linhas = Contatos4FGerador.Gerar(modelos, new List<int> { 7 }, auxiliares, bobinas);

            // Modelo 7: 1,2 (dispositivo) + 3 (bobina) + A1,A2 (auxiliar); modelo 8 fora de uso.
            Assert.Equal(5, linhas.Count);

            Assert.Equal("1", linhas[0].Terminal);
            Assert.Equal("H", linhas[0].Orientacao);
            Assert.Equal("2", linhas[1].Terminal);
            Assert.Equal("V", linhas[1].Orientacao);
            Assert.Equal("3", linhas[2].Terminal);
            Assert.Equal("A1", linhas[3].Terminal);
            Assert.Equal("A2", linhas[4].Terminal);
        }

        [Fact]
        public void Grava_contatos_no_banco()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                store.InserirContatos(
                    new List<Contato4F>
                    {
                        new Contato4F { IndexModelo = 7, NomeModelo = "CONT7", Terminal = "1", TerminalNum = 1.0, Orientacao = "H" },
                        new Contato4F { IndexModelo = 7, NomeModelo = "CONT7", Terminal = "2", TerminalNum = 2.0 },
                    },
                    "R0", 1);

                Assert.Equal(2, store.ContarContatosDoModelo(7));
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        private static void AcrescentaModelo(List<TypedXData> valores, int indice, string nome, string terminais, string orientacao)
        {
            valores.Add(new TypedXData(1071, indice));
            valores.Add(new TypedXData(1000, nome));
            valores.Add(new TypedXData(1071, 1));          // lm1
            valores.Add(new TypedXData(1071, 2));          // lm2
            valores.Add(new TypedXData(1000, "ignorado"));
            valores.Add(new TypedXData(1000, "TOPO"));
            valores.Add(new TypedXData(1000, "LAY"));
            valores.Add(new TypedXData(1000, "ignorado"));
            valores.Add(new TypedXData(1000, orientacao));
            valores.Add(new TypedXData(1000, terminais));
        }

        private static void AcrescentaAuxiliar(List<TypedXData> valores, int indice, string t1, string t2, string t3, int tipo, string orientacao)
        {
            valores.Add(new TypedXData(1071, indice));
            valores.Add(new TypedXData(1000, t1));
            valores.Add(new TypedXData(1000, t2));
            valores.Add(new TypedXData(1000, t3));
            valores.Add(new TypedXData(1071, tipo));
            valores.Add(new TypedXData(1071, 0));          // comportamento
            valores.Add(new TypedXData(1000, orientacao));
            valores.Add(new TypedXData(1000, "ignorado"));
        }
    }
}
