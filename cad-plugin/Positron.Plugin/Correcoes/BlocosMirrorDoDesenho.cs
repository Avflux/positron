using System;
using System.Collections.Generic;
using Positron.Data.Correcoes;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
#endif

namespace Positron.Plugin.Correcoes
{
    /// <summary>
    /// <c>ApagaBlocosMirror</c> — apaga os blocos **espelhados** (escala X negativa) que
    /// têm **algum** XData e **não** são cabos de aranha (<c>DINTERLIG</c>), como o
    /// <c>clsUtilitarios.cs</c> (frente 2 do §7.6).
    ///
    /// A regra é pura (<see cref="CorrecaoDosBlocosMirror.PrecisaApagar"/>). O original
    /// não conta nem avisa nada — aqui a linha de resumo traz os números.
    /// </summary>
    internal static class BlocosMirrorDoDesenho
    {
        internal sealed class Resultado
        {
            /// <summary>Blocos de referência lidos.</summary>
            internal int BlocosLidos { get; set; }

            /// <summary>Blocos com algum XData.</summary>
            internal int ComXData { get; set; }

            /// <summary>Blocos espelhados (escala X negativa) entre os que têm XData.</summary>
            internal int Espelhados { get; set; }

            /// <summary>Espelhados que são cabo de aranha e ficam.</summary>
            internal int CabosDeAranha { get; set; }

            /// <summary>Blocos apagados.</summary>
            internal int Apagados { get; set; }
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

                foreach (ObjectId id in espaco)
                {
                    BlockReference bloco = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
                    if (bloco == null)
                    {
                        continue;
                    }

                    resultado.BlocosLidos++;

                    bool temXData = bloco.XData != null;
                    if (!temXData)
                    {
                        continue;
                    }

                    resultado.ComXData++;

                    bool temCaboAranha = bloco.GetXDataForApplication(
                        CorrecaoDosBlocosMirror.AppNameCaboAranha) != null;
                    double escalaX = bloco.ScaleFactors.X;

                    if (escalaX < 0.0 && temCaboAranha)
                    {
                        resultado.CabosDeAranha++;
                    }

                    if (escalaX < 0.0)
                    {
                        resultado.Espelhados++;
                    }

                    if (!CorrecaoDosBlocosMirror.PrecisaApagar(temXData, temCaboAranha, escalaX))
                    {
                        continue;
                    }

                    bloco.UpgradeOpen();
                    bloco.Erase();
                    resultado.Apagados++;
                }

                transacao.Commit();
            }

            return resultado;
        }
    }
}
