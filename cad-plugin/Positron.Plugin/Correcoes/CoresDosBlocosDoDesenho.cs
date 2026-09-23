using System;
using System.Collections.Generic;
using Positron.Data.Correcoes;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Correcoes
{
    /// <summary>
    /// <c>CorrigeCoresDosBlocos</c> — a cor dos atributos das **referências** passa a ser
    /// a da **definição** do bloco, para os blocos inseridos que têm XData (frente 2 do
    /// §7.6, o <c>Correcao.cs</c>: <c>carregaBlocosInseridos</c> + <c>MMg1xjoRaA</c> +
    /// <c>lu61bhmRNc</c>).
    ///
    /// A regra é pura (<see cref="CorrecaoDasCoresDosBlocos"/>), incluindo o quirk do
    /// nome em caixa alta da terceira passada.
    /// </summary>
    internal static class CoresDosBlocosDoDesenho
    {
        internal sealed class Resultado
        {
            /// <summary>Nomes de blocos inseridos com XData (a lista do original).</summary>
            internal int BlocosInseridos { get; set; }

            /// <summary>Atributos de definição lidos (o <c>MMg1xjoRaA</c>).</summary>
            internal int Definicoes { get; set; }

            /// <summary>Atributos cuja cor foi corrigida.</summary>
            internal int AtributosAlterados { get; set; }

            /// <summary>Blocos em que pelo menos um atributo mudou.</summary>
            internal int BlocosAlterados { get; set; }
        }

        internal static Resultado Executar()
        {
            Resultado resultado = new Resultado();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return resultado;
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
                BlockTableRecord espaco = (BlockTableRecord)transacao.GetObject(
                    tabela[BlockTableRecord.ModelSpace], OpenMode.ForRead);

                // 1) os nomes dos blocos inseridos que têm XData.
                List<string> nomes = new List<string>();
                foreach (ObjectId id in espaco)
                {
                    BlockReference bloco = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
                    if (bloco == null || bloco.XData == null)
                    {
                        continue;
                    }

                    if (!nomes.Contains(bloco.Name))
                    {
                        nomes.Add(bloco.Name);
                    }
                }

                resultado.BlocosInseridos = nomes.Count;

                // 2) a cor de cada atributo das DEFINIÇÕES.
                List<CorDeAtributo> cores = new List<CorDeAtributo>();
                foreach (string nome in nomes)
                {
                    if (!tabela.Has(nome))
                    {
                        continue;
                    }

                    BlockTableRecord definicao = transacao.GetObject(
                        tabela[nome], OpenMode.ForRead) as BlockTableRecord;
                    if (definicao == null)
                    {
                        continue;
                    }

                    foreach (ObjectId id in definicao)
                    {
                        AttributeDefinition atributo =
                            transacao.GetObject(id, OpenMode.ForRead) as AttributeDefinition;
                        if (atributo == null)
                        {
                            continue;
                        }

                        resultado.Definicoes++;
                        cores.Add(new CorDeAtributo
                        {
                            NomeBloco = nome,
                            Tag = atributo.Tag,
                            Cor = (short)atributo.ColorIndex,
                        });
                    }
                }

                if (cores.Count == 0)
                {
                    transacao.Commit();
                    return resultado;
                }

                // 3) a cor dos atributos das REFERÊNCIAS.
                foreach (ObjectId id in espaco)
                {
                    BlockReference bloco = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
                    if (bloco == null || !CorrecaoDasCoresDosBlocos.BlocoEntra(nomes, bloco.Name))
                    {
                        continue;
                    }

                    bool abriu = false;
                    foreach (ObjectId idAtributo in bloco.AttributeCollection)
                    {
                        AttributeReference atributo =
                            transacao.GetObject(idAtributo, OpenMode.ForRead) as AttributeReference;
                        if (atributo == null)
                        {
                            continue;
                        }

                        short? cor = CorrecaoDasCoresDosBlocos.CorDoAtributo(cores, bloco.Name, atributo.Tag);
                        if (!cor.HasValue || atributo.ColorIndex == cor.Value)
                        {
                            continue;
                        }

                        if (!abriu)
                        {
                            bloco.UpgradeOpen();
                            abriu = true;
                        }

                        atributo.UpgradeOpen();
                        atributo.ColorIndex = cor.Value;
                        resultado.AtributosAlterados++;
                    }

                    if (abriu)
                    {
                        resultado.BlocosAlterados++;
                    }
                }

                transacao.Commit();
            }

            return resultado;
        }
    }
}
