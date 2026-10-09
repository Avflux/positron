using System.Collections.Generic;
using Positron.Data.Bornes;
using Positron.Data.Fiacao;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// As regras do verificador que olham o **desenho** (régua do borne e cabo
    /// fora do catálogo) — o que o <c>frmVerificadorProjeto*</c> acrescenta às
    /// tabelas gravadas.
    /// </summary>
    public class VerificadorDesenhoTests
    {
        [Fact]
        public void Aponta_cabo_referenciado_fora_do_catalogo()
        {
            List<string> usados = new List<string> { "CABO1", "CABO2", "cabo2", null, " " };
            List<string> catalogo = new List<string> { "CABO1", "CABO3" };

            List<Problema> problemas = VerificadorProjeto.VerificarCabosSemCatalogo(usados, catalogo);

            Problema problema = Assert.Single(problemas);
            Assert.Equal(AreaVerificacao.Desenho, problema.Area);
            Assert.Equal(TipoProblema.CaboSemCatalogo, problema.Tipo);
            Assert.Equal("CABO2", problema.Identificador);
        }

        [Fact]
        public void Catalogo_completo_nao_aponta_nada()
        {
            List<Problema> problemas = VerificadorProjeto.VerificarCabosSemCatalogo(
                new List<string> { "CABO1" },
                new List<string> { "cabo1" });

            Assert.Empty(problemas);
        }

        [Fact]
        public void Aponta_borne_sem_regua_no_dicionario()
        {
            ReguasModelo reguas = ReguasModelo.Ler(RegistrosRegua());
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                new PontoBorne { Handle = "H1", IndiceRegua = 5 },
                new PontoBorne { Handle = "H9", IndiceRegua = 9 },
                new PontoBorne { Handle = "", IndiceRegua = 9 },
            };

            List<Problema> problemas = VerificadorProjeto.VerificarBornesSemRegua(bornes, reguas);

            Assert.Equal(2, problemas.Count);
            Assert.Equal(TipoProblema.BorneSemRegua, problemas[0].Tipo);
            Assert.Equal("H9", problemas[0].Identificador);
            Assert.Equal("régua #9", problemas[1].Identificador);
        }

        [Fact]
        public void Aponta_regua_do_dicionario_sem_borne()
        {
            // O `buscaReguasVazias` do reverso: para cada régua do dicionário, se o
            // par (painel, régua) não está entre as usadas pelos bornes, ela está vazia.
            ReguasModelo reguas = ReguasModelo.Ler(RegistrosRegua());

            // Sem nenhum borne no desenho, a única régua do dicionário (painel 3,
            // régua 5) está vazia.
            List<Problema> problemas = VerificadorProjeto.VerificarReguasVazias(reguas, new List<PontoBorne>());

            Problema problema = Assert.Single(problemas);
            Assert.Equal(TipoProblema.ReguaVazia, problema.Tipo);
            Assert.Equal("painel 3, régua #5", problema.Identificador);
            Assert.Contains("R1", problema.Detalhe);
        }

        [Fact]
        public void Regua_usada_nao_e_apontada()
        {
            ReguasModelo reguas = ReguasModelo.Ler(RegistrosRegua());
            List<PontoBorne> bornes = new List<PontoBorne>();
            foreach (ReguaInfo regua in reguas.Ordenadas)
            {
                bornes.Add(new PontoBorne { Handle = "H" + regua.Indice, IndiceRegua = regua.Indice, Painel = regua.Painel });
            }

            Assert.Empty(VerificadorProjeto.VerificarReguasVazias(reguas, bornes));
        }

        [Fact]
        public void Borne_de_outro_painel_nao_usa_a_regua()
        {
            // A chave é o par (painel, régua), como o `"painel,régua"` do original:
            // um borne de outro painel com o mesmo índice não usa esta régua.
            ReguasModelo reguas = ReguasModelo.Ler(RegistrosRegua());
            int indice = reguas.Ordenadas[0].Indice;
            int painel = reguas.Ordenadas[0].Painel;
            List<PontoBorne> bornes = new List<PontoBorne>
            {
                new PontoBorne { Handle = "H1", IndiceRegua = indice, Painel = (short)(painel + 1) },
            };

            List<Problema> problemas = VerificadorProjeto.VerificarReguasVazias(reguas, bornes);

            Assert.Contains(problemas, p => p.Identificador == "painel " + painel + ", régua #" + indice);
        }

        [Fact]
        public void Borne_com_regua_resolvida_nao_aponta()
        {
            ReguasModelo reguas = ReguasModelo.Ler(RegistrosRegua());
            List<PontoBorne> bornes = new List<PontoBorne> { new PontoBorne { Handle = "H1", IndiceRegua = 5 } };

            Assert.Empty(VerificadorProjeto.VerificarBornesSemRegua(bornes, reguas));
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
