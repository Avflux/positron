using System;
using System.Collections.Generic;
using System.IO;
using Positron.Data;
using Positron.Data.Diagnostico;
using Positron.Data.Fiacao;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Diagnostico
{
    /// <summary>
    /// O <c>pzDiag</c> — a **ferramenta de diagnóstico em C#** que substitui os contadores
    /// LISP (o gargalo das rodadas 90/91/102 era o LISP, não a lógica).
    ///
    /// Escreve um arquivo com duas seções:
    ///
    /// - <c>PORTA</c>: cada bloco de porta (Dispositivo tipo <c>E</c>) com o par
    ///   modelo/porta, os dois handles e os atributos <c>NOME1</c>/<c>T1</c>/<c>PAINEL</c>/<c>EFC</c>;
    /// - <c>COR</c>: cada referência cujo nome de bloco tem XData, com a cor da referência e a
    ///   da definição (o <c>CorrigeCoresDosBlocos</c>), e o total de diferenças.
    ///
    /// O caminho sai de <c>POSITRON_DIAG</c> ou, sem ele, de <c>%TEMP%\positron-diag.txt</c>.
    /// </summary>
    internal static class DiagnosticoDoDesenho
    {
        internal sealed class Resultado
        {
            internal string Caminho { get; set; }

            internal int Portas { get; set; }

            internal int Referencias { get; set; }

            internal int Diferencas { get; set; }
        }

        internal static Resultado Escrever()
        {
            Resultado resultado = new Resultado();
            resultado.Caminho = Caminho();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return resultado;
            }

            List<string> linhas = new List<string>();
            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
                BlockTableRecord espaco = (BlockTableRecord)transacao.GetObject(
                    tabela[BlockTableRecord.ModelSpace], OpenMode.ForRead);

                Dictionary<string, Dictionary<string, int>> definicoes =
                    new Dictionary<string, Dictionary<string, int>>(StringComparer.OrdinalIgnoreCase);
                int portas = 0;
                int referencias = 0;
                int diferencas = 0;

                foreach (ObjectId id in espaco)
                {
                    BlockReference bloco = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
                    if (bloco == null)
                    {
                        continue;
                    }

                    // Seção das PORTAS: os blocos de Dispositivo tipo E.
                    IReadOnlyList<TypedXData> dispositivo = XDataNeutro.Para(
                        bloco.GetXDataForApplication("Dispositivo"));
                    if (dispositivo != null && dispositivo.Count > 10 &&
                        string.Equals(dispositivo[1].Valor as string, "E", StringComparison.OrdinalIgnoreCase))
                    {
                        portas++;
                        linhas.Add(RelatorioDeDiagnostico.LinhaDePorta(
                            "E",
                            XDataNumero.Inteiro(dispositivo[5].Valor),
                            XDataNumero.Inteiro(dispositivo[6].Valor),
                            dispositivo[4].Valor as string,
                            dispositivo[9].Valor as string,
                            Atributo(bloco, transacao, "NOME1"),
                            Atributo(bloco, transacao, "T1"),
                            Atributo(bloco, transacao, "PAINEL"),
                            Atributo(bloco, transacao, "EFC")));
                    }

                    // Seção das CORES: os blocos com XData e a definição do seu nome.
                    if (bloco.XData == null)
                    {
                        continue;
                    }

                    if (!definicoes.ContainsKey(bloco.Name) && tabela.Has(bloco.Name))
                    {
                        BlockTableRecord definicao = transacao.GetObject(
                            tabela[bloco.Name], OpenMode.ForRead) as BlockTableRecord;
                        Dictionary<string, int> cores = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
                        if (definicao != null)
                        {
                            foreach (ObjectId idDefinicao in definicao)
                            {
                                AttributeDefinition attdef =
                                    transacao.GetObject(idDefinicao, OpenMode.ForRead) as AttributeDefinition;
                                if (attdef != null && !string.IsNullOrEmpty(attdef.Tag))
                                {
                                    cores[attdef.Tag] = attdef.ColorIndex;
                                }
                            }
                        }

                        definicoes[bloco.Name] = cores;
                    }

                    Dictionary<string, int> doNome;
                    if (!definicoes.TryGetValue(bloco.Name, out doNome))
                    {
                        continue;
                    }

                    string handle = bloco.Handle.ToString();
                    foreach (ObjectId idAtributo in bloco.AttributeCollection)
                    {
                        AttributeReference atributo =
                            transacao.GetObject(idAtributo, OpenMode.ForRead) as AttributeReference;
                        if (atributo == null)
                        {
                            continue;
                        }

                        int daDefinicao;
                        if (!doNome.TryGetValue(atributo.Tag ?? string.Empty, out daDefinicao))
                        {
                            continue;
                        }

                        referencias++;
                        if (!RelatorioDeDiagnostico.CorDiferente(atributo.ColorIndex, daDefinicao))
                        {
                            continue;
                        }

                        diferencas++;
                        linhas.Add(RelatorioDeDiagnostico.LinhaDeCor(
                            handle, bloco.Name, atributo.Tag, atributo.ColorIndex, daDefinicao));
                    }
                }

                linhas.Insert(0, RelatorioDeDiagnostico.CabecalhoDePortas);
                linhas.Add(RelatorioDeDiagnostico.Total("portas", portas, referencias, diferencas));
                linhas.Add(RelatorioDeDiagnostico.CabecalhoDeCores);
                linhas.Add(RelatorioDeDiagnostico.Total("diferencas", diferencas));

                resultado.Portas = portas;
                resultado.Referencias = referencias;
                resultado.Diferencas = diferencas;

                transacao.Commit();
            }

            File.WriteAllLines(resultado.Caminho, linhas);
            return resultado;
        }

        private static string Atributo(BlockReference bloco, Transaction transacao, string tag)
        {
            foreach (ObjectId id in bloco.AttributeCollection)
            {
                AttributeReference atributo = transacao.GetObject(id, OpenMode.ForRead) as AttributeReference;
                if (atributo != null && string.Equals(atributo.Tag, tag, StringComparison.OrdinalIgnoreCase))
                {
                    return atributo.TextString ?? string.Empty;
                }
            }

            return string.Empty;
        }

        private static string Caminho()
        {
            string caminho = Environment.GetEnvironmentVariable("POSITRON_DIAG");
            if (!string.IsNullOrEmpty(caminho))
            {
                return caminho;
            }

            return Path.Combine(Path.GetTempPath(), "positron-diag.txt");
        }
    }
}
