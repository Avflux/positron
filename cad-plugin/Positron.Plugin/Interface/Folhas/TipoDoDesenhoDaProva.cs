using System;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
#endif

namespace Positron.Plugin.Interface.Folhas
{
    /// <summary>
    /// A leitura do tipo do documento para a prova da rodada 222 — o
    /// <c>XDataGeral.verificaTipoXData</c> pelas apps do ModelSpace (<c>Eletron</c>=E,
    /// <c>DiagLog</c>=D, <c>ArqNet</c>=A, nenhuma=V). O documento <c>D</c> da medição é um
    /// **desenho novo** com o <c>DiagLog</c> posto no ModelSpace pela fixture (o
    /// <c>vla-SetXData</c> do AutoLISP, que só existe com interface — rodada 181); trocar o
    /// <c>Eletron</c> de um desenho existente pelo <c>BlockTableRecord.XData</c> **não** pegou
    /// (medido nesta rodada: a app continuou lá e o tipo continuou "E").
    /// </summary>
    internal static class TipoDoDesenhoDaProva
    {
        /// <summary>O tipo do desenho ativo (o <see cref="InicioDoDesenho.TipoDoDesenho"/>).</summary>
        internal static string Agora()
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            return documento == null ? string.Empty : InicioDoDesenho.TipoDoDesenho(documento);
        }

        /// <summary>O tipo é um dos que o paleta trata sem menu/edição (D/A/V)?</summary>
        internal static bool ForaDoEletron(string tipo)
        {
            return string.Equals(tipo, "D", StringComparison.OrdinalIgnoreCase)
                || string.Equals(tipo, "A", StringComparison.OrdinalIgnoreCase)
                || string.Equals(tipo, "V", StringComparison.OrdinalIgnoreCase);
        }
    }
}
