using System;
using System.Collections.Generic;
using Positron.Contract;

namespace Positron.Data.Cabos
{
    /// <summary>
    /// Projeta o **catálogo de cabos e veias** (<c>Cabos</c>/<c>Veias</c>) para as
    /// tabelas por revisão (<c>Cabos4</c>/<c>Veias4</c>) — o
    /// <c>RUIU5Sbjhj</c>/<c>v1TU0cEjWd</c> do <c>frmCompilarInterligacao</c>.
    ///
    /// O original não deriva esses dados do desenho: ele **copia** o catálogo
    /// (<c>CarregaCabos</c>/<c>CarregaVeias</c>) e carimba cada linha com a revisão
    /// corrente e o autor. É um snapshot do catálogo por revisão — manter os dois
    /// lados em sincronia é o que o app lê depois.
    ///
    /// Mapeamento (do reverso, <c>cDadosAccessInterligacao2</c>):
    ///
    /// - <c>Cabos4</c> ← <c>Cabos</c> menos <c>Alarme</c> (a tabela 4 não tem essa
    ///   coluna), mais <c>Revisao</c>/<c>Criador</c>/<c>Data</c>.
    /// - <c>Veias4</c> ← <c>Veias</c>, com <c>Indice</c> virando <c>Num_Veia</c>.
    ///
    /// Funções puras: nada de CAD nem de SQL — só a transformação, testável sozinha.
    /// </summary>
    public static class CabosVeias4Gerador
    {
        /// <summary>
        /// Snapshot do catálogo de cabos para a revisão. Preserva a ordem de entrada
        /// (o leitor já ordena por <c>Tag</c>, como o <c>ORDER BY Tag</c> do original).
        /// </summary>
        public static List<Cabos4Row> GerarCabos(IEnumerable<CabosRow> cabos, string revisao, string criador, DateTime data)
        {
            List<Cabos4Row> linhas = new List<Cabos4Row>();
            if (cabos == null)
            {
                return linhas;
            }

            foreach (CabosRow cabo in cabos)
            {
                if (cabo == null)
                {
                    continue;
                }

                linhas.Add(new Cabos4Row
                {
                    Revisao = revisao,
                    Tag = cabo.Tag,
                    Formacao = cabo.Formacao,
                    Blindagem = cabo.Blindagem,
                    Pn1 = cabo.Pn1,
                    Pn2 = cabo.Pn2,
                    Codigo = cabo.Codigo,
                    Funcao = cabo.Funcao,
                    Aterrar = cabo.Aterrar,
                    Comprimento = cabo.Comprimento,
                    Trajeto = cabo.Trajeto,
                    Instrucao = cabo.Instrucao,
                    Diametro = cabo.Diametro,
                    Grupo = cabo.Grupo,
                    Cabos = cabo.Cabos,
                    Criador = criador,
                    Data = data,
                });
            }

            return linhas;
        }

        /// <summary>Snapshot do catálogo de veias para a revisão.</summary>
        public static List<Veias4Row> GerarVeias(IEnumerable<VeiasRow> veias, string revisao)
        {
            List<Veias4Row> linhas = new List<Veias4Row>();
            if (veias == null)
            {
                return linhas;
            }

            foreach (VeiasRow veia in veias)
            {
                if (veia == null)
                {
                    continue;
                }

                linhas.Add(new Veias4Row
                {
                    Revisao = revisao,
                    Tag = veia.Tag,
                    Num_Veia = veia.Indice,
                    Nome_Veia = veia.Nome_Veia,
                    Uso = veia.Uso,
                    Funcao = veia.Funcao,
                });
            }

            return linhas;
        }
    }
}
