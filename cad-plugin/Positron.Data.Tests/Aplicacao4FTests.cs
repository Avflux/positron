using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Modelos;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// <c>Aplicacao4F</c> — o <c>FiRUTW6Q6W</c> do <c>frmCompilarFiacao</c>: copia
    /// os tipos do dicionário <c>APLICACAO/TIPOS</c> (10 valores por tipo, a
    /// partir do índice 1 do Xrecord).
    /// </summary>
    public class Aplicacao4FTests
    {
        private static TypedXData Numero(short valor)
        {
            return new TypedXData(1070, valor);
        }

        private static TypedXData Texto(string valor)
        {
            return new TypedXData(1000, valor);
        }

        private static void AcrescentaAplicacao(
            List<TypedXData> valores,
            short indice,
            string nome,
            string secao,
            string cor,
            string tipoCabo,
            string isolacao)
        {
            valores.Add(Numero(indice));
            valores.Add(Texto(nome));
            valores.Add(Texto(secao));
            valores.Add(Texto(cor));
            valores.Add(Texto(tipoCabo));
            valores.Add(Texto(isolacao));
            valores.Add(Numero(0));
            valores.Add(Numero(0));
            valores.Add(Numero(0));
            valores.Add(Numero(0));
        }

        [Fact]
        public void Le_os_tipos_do_xrecord_e_ignora_o_primeiro_valor()
        {
            List<TypedXData> valores = new List<TypedXData>();
            valores.Add(Numero(0)); // índice 0 não é aplicação
            AcrescentaAplicacao(valores, 1, "AP1", "2,5", "AZ", "CABO-X", "PVC");
            AcrescentaAplicacao(valores, 2, "AP2", "4", "PT", "CABO-Y", "EPR");

            List<AplicacaoDefinicao> tipos = Aplicacao4FGerador.LerTipos(valores);

            Assert.Equal(2, tipos.Count);
            Assert.Equal(1, tipos[0].Indice);
            Assert.Equal("AP1", tipos[0].Nome);
            Assert.Equal("2,5", tipos[0].Secao);
            Assert.Equal("AZ", tipos[0].Cor);
            Assert.Equal("CABO-X", tipos[0].TipoCabo);
            Assert.Equal("PVC", tipos[0].Isolacao);
            Assert.Equal(2, tipos[1].Indice);
            Assert.Equal("AP2", tipos[1].Nome);
        }

        [Fact]
        public void Xrecord_truncado_no_fim_e_ignorado()
        {
            List<TypedXData> valores = new List<TypedXData>();
            valores.Add(Numero(0));
            AcrescentaAplicacao(valores, 1, "AP1", "2,5", "AZ", "CABO-X", "PVC");
            valores.Add(Numero(2)); // começa uma segunda, mas sem os 6 valores

            List<AplicacaoDefinicao> tipos = Aplicacao4FGerador.LerTipos(valores);

            Assert.Single(tipos);
            Assert.Equal("AP1", tipos[0].Nome);
        }

        [Fact]
        public void Gera_linha_com_o_indice_em_numero()
        {
            List<Aplicacao4F> linhas = Aplicacao4FGerador.Gerar(new List<AplicacaoDefinicao>
            {
                new AplicacaoDefinicao
                {
                    Indice = 7, Nome = "AP7", Secao = "6", Cor = "VD",
                    TipoCabo = "CABO-Z", Isolacao = "XLPE",
                },
            });

            Aplicacao4F linha = Assert.Single(linhas);
            Assert.Equal(7, linha.Numero);
            Assert.Equal("AP7", linha.Nome);
            Assert.Equal("XLPE", linha.Isolacao);
        }

        [Fact]
        public void Gravar_duas_vezes_nao_duplica_e_lote_vazio_limpa_a_revisao()
        {
            string caminho = BancoDeTeste.Criar();
            try
            {
                ProjectStore store = new ProjectStore(caminho);
                List<Aplicacao4F> linhas = new List<Aplicacao4F>
                {
                    new Aplicacao4F { Numero = 1, Nome = "AP1", Secao = "2,5", Cor = "AZ" },
                    new Aplicacao4F { Numero = 2, Nome = "AP2", Secao = "4", Cor = "PT" },
                };

                store.InserirAplicacoes(linhas, "R0", 1);
                Assert.Equal(2, store.AplicacoesDaRevisao(1, "R0").Count);

                store.InserirAplicacoes(linhas, "R0", 1);
                Assert.Equal(2, store.AplicacoesDaRevisao(1, "R0").Count);

                store.InserirAplicacoes(linhas, "R1", 1);
                store.InserirAplicacoes(new List<Aplicacao4F>(), "R0", 1);
                Assert.Empty(store.AplicacoesDaRevisao(1, "R0"));
                Assert.Equal(2, store.AplicacoesDaRevisao(1, "R1").Count);
            }
            finally
            {
                BancoDeTeste.Limpar(caminho);
            }
        }
    }
}
