using System.Collections.Generic;
using Positron.Data;
using Positron.Data.Bornes;
using Positron.Data.Modelos;
using Xunit;

namespace Positron.Data.Tests
{
    public class GeradoresTests
    {
        [Fact]
        public void Gerar_portas_de_borne_e_de_terminal()
        {
            List<ModeloMascara> modelos = new List<ModeloMascara>
            {
                new ModeloMascara { Indice = 4, Nome = "MOD4" },
                new ModeloMascara { Indice = 5, Nome = "MOD5" },
            };

            Dictionary<int, IReadOnlyList<ModeloPorta>> portas = new Dictionary<int, IReadOnlyList<ModeloPorta>>
            {
                [4] = new List<ModeloPorta>
                {
                    new ModeloPorta { IndiceModelo = 4, NomeModelo = "MOD4", Bornes = "11;*12", Regua = "R1;R2", Orientacao = "H" },
                },
                [5] = new List<ModeloPorta>
                {
                    new ModeloPorta { IndiceModelo = 5, NomeModelo = "MOD5", Terminais = "1;2", Orientacao = "V" },
                },
            };

            List<Porta4F> linhas = Portas4FGerador.Gerar(modelos, portas, new List<int> { 4, 5 });

            // Modelo 4: 2 bornes ("B"); modelo 5: 2 terminais ("T").
            Assert.Equal(4, linhas.Count);

            Assert.Equal("B", linhas[0].Tipo);
            Assert.Equal("R1", linhas[0].Regua);
            Assert.Equal("11", linhas[0].Borne);
            Assert.Equal("R2", linhas[1].Regua);
            Assert.Equal("12", linhas[1].Borne); // o "*" é removido

            Assert.Equal("T", linhas[2].Tipo);
            Assert.Equal("1", linhas[2].Terminal);
            Assert.Equal("MOD5", linhas[2].NomeModelo);
        }

        [Fact]
        public void Modelo_fora_de_uso_nao_gera_portas()
        {
            List<ModeloMascara> modelos = new List<ModeloMascara> { new ModeloMascara { Indice = 4, Nome = "MOD4" } };
            Dictionary<int, IReadOnlyList<ModeloPorta>> portas = new Dictionary<int, IReadOnlyList<ModeloPorta>>
            {
                [4] = new List<ModeloPorta> { new ModeloPorta { Bornes = "11", Regua = "R1" } },
            };

            List<Porta4F> linhas = Portas4FGerador.Gerar(modelos, portas, new List<int> { 99 });
            Assert.Empty(linhas);
        }

        [Fact]
        public void Gerar_bornes_do_desenho_e_reservas()
        {
            ReguasModelo reguas = ReguasModelo.Ler(RegistrosRegua());

            List<PontoBorne> bornes = new List<PontoBorne>
            {
                new PontoBorne { Handle = "H1", IndiceRegua = 5, Numero = "11", Ordem = 1.0, Tipo = 0, Layer = "PAG1", Lm = 2 },
                new PontoBorne { Handle = "H9", IndiceRegua = 6, Numero = "99", Layer = "PAG1" }, // régua 6 não existe → fora
            };

            Dictionary<int, IReadOnlyList<BorneReserva>> reservas = new Dictionary<int, IReadOnlyList<BorneReserva>>
            {
                [5] = new List<BorneReserva>
                {
                    new BorneReserva { Numero = "14", Ordem = 4.0, Tipo = 1, Reserva = true },
                },
            };

            List<Borne4F> linhas = Bornes4FGerador.Gerar(bornes, reguas, new List<int> { 3 }, reservas);

            Assert.Equal(2, linhas.Count);

            Assert.Equal("H1", linhas[0].Handle);
            Assert.Equal("11", linhas[0].Borne);
            Assert.Equal("R1", linhas[0].Regua);
            Assert.False(linhas[0].BReserva);
            Assert.Equal("PAG1", linhas[0].Pagina);

            Assert.Equal(string.Empty, linhas[1].Handle);
            Assert.Equal("14", linhas[1].Borne);
            Assert.True(linhas[1].BReserva);
        }

        [Fact]
        public void Grava_portas_e_bornes_no_banco()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);

                store.InserirPortas(
                    new List<Porta4F> { new Porta4F { IndexModelo = 4, NomeModelo = "MOD4", Borne = "11", Regua = "R1", Tipo = "B" } },
                    "R0", 1);

                store.InserirBornes(
                    new List<Borne4F> { new Borne4F { Painel = 3, IndexRegua = 5, Regua = "R1", Borne = "11", Handle = "H1", Tipo = 0 } },
                    "R0", 1);

                Assert.Equal(1, store.ContarPortasDoModelo(4));
                Assert.Equal(1, store.ContarBornesDaRegua(5));
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        private static List<Positron.Data.Fiacao.TypedXData> RegistrosRegua()
        {
            List<Positron.Data.Fiacao.TypedXData> valores = new List<Positron.Data.Fiacao.TypedXData>();
            // Índice 0 é o cabeçalho (maior indexRegua) — como o produto grava.
            valores.Add(new Positron.Data.Fiacao.TypedXData(90, 5));
            AcrescentaRegua(valores, 5, "R1", "ALT1", 3);
            return valores;
        }

        private static void AcrescentaRegua(List<Positron.Data.Fiacao.TypedXData> valores, int indice, string nome, string alternativo, int painel)
        {
            valores.Add(new Positron.Data.Fiacao.TypedXData(1071, indice));
            valores.Add(new Positron.Data.Fiacao.TypedXData(1000, nome));
            valores.Add(new Positron.Data.Fiacao.TypedXData(1000, alternativo));
            valores.Add(new Positron.Data.Fiacao.TypedXData(1071, painel));
            for (int i = 0; i < 6; i++)
            {
                valores.Add(new Positron.Data.Fiacao.TypedXData(1071, 0));
            }
        }
    }
}
