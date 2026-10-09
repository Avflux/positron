using System.Collections.Generic;
using Positron.Data.Bornes;
using Positron.Data.Fiacao;
using Positron.Data.Modelos;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// <c>Portas4I</c> e <c>Bornes4I</c> — a projeção intermediária do
    /// <c>frmCompilarInterligacao</c> (<c>wrlU180vl0</c> e <c>T6NUlT3ghH</c>): ao
    /// contrário do <c>FIA</c>, a interligação **não** filtra por painel/modelo em
    /// uso.
    /// </summary>
    public class Interligacao4ITests
    {
        [Fact]
        public void Portas4I_gera_todos_os_modelos_sem_filtro_de_uso()
        {
            List<ModeloMascara> modelos = new List<ModeloMascara> { new ModeloMascara { Indice = 4, Nome = "MOD4" } };
            Dictionary<int, IReadOnlyList<ModeloPorta>> portas = new Dictionary<int, IReadOnlyList<ModeloPorta>>
            {
                [4] = new List<ModeloPorta> { new ModeloPorta { IndiceModelo = 4, NomeModelo = "MOD4", Bornes = "11", Regua = "R1", Orientacao = "H" } },
            };

            // O FIA só projeta modelo em uso; com o painel 99 fora de uso, nada sai.
            Assert.Empty(Portas4FGerador.Gerar(modelos, portas, new List<int> { 99 }));

            List<Porta4I> linhas = Portas4IGerador.Gerar(modelos, portas);

            Porta4I linha = Assert.Single(linhas);
            Assert.Equal(4, linha.IndexModelo);
            Assert.Equal("MOD4", linha.NomeModelo);
            Assert.Equal("B", linha.Tipo);
            Assert.Equal("R1", linha.Regua);
            Assert.Equal("11", linha.Borne);
        }

        [Fact]
        public void Portas4I_mapeia_os_campos_da_porta()
        {
            List<Porta4I> linhas = Portas4IGerador.Mapear(new List<Porta4F>
            {
                new Porta4F
                {
                    IndexModelo = 5, NomeModelo = "MOD5", Terminal = "1",
                    TerminalNum = 1.5, Tipo = "T", Orientacao = "V",
                },
            });

            Porta4I linha = Assert.Single(linhas);
            Assert.Equal(5, linha.IndexModelo);
            Assert.Equal("MOD5", linha.NomeModelo);
            Assert.Equal("1", linha.Terminal);
            Assert.Equal(1.5, linha.TerminalNum);
            Assert.Equal("T", linha.Tipo);
        }

        [Fact]
        public void Bornes4I_gera_sem_filtro_de_painel()
        {
            ReguasModelo reguas = ReguasModelo.Ler(RegistrosRegua());
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                new PontoBorne { Handle = "H1", IndiceRegua = 5, Numero = "11", Ordem = 1.0, Tipo = 0, Layer = "PAG1" },
            };
            Dictionary<int, IReadOnlyList<BorneReserva>> reservas = new Dictionary<int, IReadOnlyList<BorneReserva>>
            {
                [5] = new List<BorneReserva> { new BorneReserva { Numero = "14", Ordem = 4.0, Tipo = 1, Reserva = true } },
            };

            // O FIA filtra pelo painel em uso; com 99 nada sai.
            Assert.Empty(Bornes4FGerador.Gerar(bornes, reguas, new List<int> { 99 }, reservas));

            List<Borne4I> linhas = Bornes4IGerador.Gerar(bornes, reguas, reservas);

            Assert.Equal(2, linhas.Count);
            Assert.Equal("H1", linhas[0].Handle);
            Assert.Equal("11", linhas[0].Borne);
            Assert.Equal("R1", linhas[0].Regua);
            Assert.False(linhas[0].BReserva);
            Assert.Equal("PAG1", linhas[0].Pagina);
            Assert.Equal("14", linhas[1].Borne);
            Assert.True(linhas[1].BReserva);
        }

        [Fact]
        public void Gravar_duas_vezes_nao_duplica_e_lote_vazio_limpa_a_revisao()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                List<Porta4I> portas = new List<Porta4I>
                {
                    new Porta4I { IndexModelo = 4, NomeModelo = "MOD4", Borne = "11", Regua = "R1", Tipo = "B" },
                };
                List<Borne4I> bornes = new List<Borne4I>
                {
                    new Borne4I { Painel = 3, IndexRegua = 5, Regua = "R1", Borne = "11", Handle = "H1", Tipo = 0 },
                };

                store.InserirPortas4I(portas, "R0", 1);
                store.InserirBornes4I(bornes, "R0", 1);
                Assert.Single(store.Portas4IDaRevisao(1, "R0"));
                Assert.Single(store.Bornes4IDaRevisao(1, "R0"));

                store.InserirPortas4I(portas, "R0", 1);
                store.InserirBornes4I(bornes, "R0", 1);
                Assert.Single(store.Portas4IDaRevisao(1, "R0"));
                Assert.Single(store.Bornes4IDaRevisao(1, "R0"));

                store.InserirPortas4I(portas, "R1", 1);
                store.InserirPortas4I(new List<Porta4I>(), "R0", 1);
                Assert.Empty(store.Portas4IDaRevisao(1, "R0"));
                Assert.Single(store.Portas4IDaRevisao(1, "R1"));
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }

        private static List<TypedXData> RegistrosRegua()
        {
            List<TypedXData> valores = new List<TypedXData>();
            // Índice 0 é o cabeçalho (maior indexRegua) — como o produto grava.
            valores.Add(new TypedXData(90, 5));
            valores.Add(new TypedXData(1071, 5));
            valores.Add(new TypedXData(1000, "R1"));
            valores.Add(new TypedXData(1000, "ALT1"));
            valores.Add(new TypedXData(1071, 3));
            for (int i = 0; i < 6; i++)
            {
                valores.Add(new TypedXData(1071, 0));
            }

            return valores;
        }
    }
}
