using System;
using System.Collections.Generic;
using System.IO;
using Positron.Data;
using Positron.Data.Relatorios;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// Relatório da verificação — a grid de erros das telas do original, em forma
    /// pura (texto + arquivo). O comando `ELETREL` grava isto; o caminho todo é
    /// verificável sem tela.
    /// </summary>
    public class RelatorioCompilacaoTests
    {
        private static List<Problema> Problemas()
        {
            return new List<Problema>
            {
                new Problema
                {
                    Area = AreaVerificacao.Desenho,
                    Tipo = TipoProblema.BorneSemFiacao,
                    Tabela = "Fiacao",
                    Identificador = "4A725",
                    Detalhe = "borne do desenho sem ponto de fiação",
                },
                new Problema
                {
                    Area = AreaVerificacao.Interligacao,
                    Tipo = TipoProblema.PontoSemTag,
                    Tabela = "Interligacao4",
                    Identificador = "8-CCE-001",
                    Detalhe = "ponta sem tag",
                },
            };
        }

        [Fact]
        public void Texto_traz_titulo_resumo_linhas_e_total()
        {
            RelatorioCompilacao relatorio = RelatorioCompilacao.DeProblemas(
                "Verificação do projeto (R0, DWG 1)",
                "VERIF: 494 fio(s) ...",
                Problemas());

            string texto = relatorio.Texto();

            Assert.Contains("# Verificação do projeto (R0, DWG 1)", texto);
            Assert.Contains("VERIF: 494 fio(s)", texto);
            Assert.Contains("# area;tipo;tabela;identificador;detalhe", texto);
            Assert.Contains("Desenho;BorneSemFiacao;Fiacao;4A725;borne do desenho sem ponto de fiação", texto);
            Assert.Contains("Interligacao;PontoSemTag;Interligacao4;8-CCE-001;ponta sem tag", texto);
            Assert.Contains("# 2 linha(s)", texto);
        }

        [Fact]
        public void Contagens_do_chamador_entram_no_texto()
        {
            RelatorioCompilacao relatorio = RelatorioCompilacao.DeProblemas("t", "r", null);
            relatorio.Contagens.Add("# banco=C:\\proj\\obra.db");

            Assert.Contains("# banco=C:\\proj\\obra.db", relatorio.Texto());
            Assert.Contains("# 0 linha(s)", relatorio.Texto());
        }

        [Fact]
        public void Salvar_grava_o_mesmo_texto_em_arquivo()
        {
            string pasta = Path.Combine(Path.GetTempPath(), "positron-relatorio-teste-" + Guid.NewGuid().ToString("N"));
            string arquivo = Path.Combine(pasta, "relatorio.txt");

            try
            {
                RelatorioCompilacao relatorio = RelatorioCompilacao.DeProblemas("t", "resumo", Problemas());
                relatorio.Salvar(arquivo);

                Assert.True(File.Exists(arquivo));
                Assert.Equal(relatorio.Texto(), File.ReadAllText(arquivo));
            }
            finally
            {
                if (Directory.Exists(pasta))
                {
                    Directory.Delete(pasta, true);
                }
            }
        }

        [Fact]
        public void Salvar_sem_caminho_e_erro_de_uso()
        {
            RelatorioCompilacao relatorio = RelatorioCompilacao.DeProblemas("t", "r", null);
            Assert.Throws<ArgumentException>(() => relatorio.Salvar("  "));
        }
    }
}
