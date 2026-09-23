using System.Collections.Generic;
using System.Globalization;
using Positron.Data.Bornes;
using Positron.Data.Fiacao;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Bornes
{
    /// <summary>
    /// O que as correções de borne (<c>corrigeOrdemBornes</c>, <c>CorrigeBornes</c>
    /// e <c>SobeLm</c>) fazem igual em volta do desenho: varrer o ModelSpace,
    /// ler/gravar o XData <c>Dispositivo</c> do borne e reabrir o bloco pelo
    /// handle. Era o mesmo bloco copiado em cada adapter; agora é um só —
    /// <see cref="BornesDoDesenho"/> é o **leitor** dos bornes do desenho (o
    /// <c>PontoBorne</c> da projeção), este é o avesso: escrever o borne.
    /// </summary>
    internal static class BornesDaCorrecao
    {
        internal static BlockTableRecord EspacoDeModelo(Transaction transacao, Database banco, OpenMode modo)
        {
            BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, modo);
            return (BlockTableRecord)transacao.GetObject(tabela[BlockTableRecord.ModelSpace], modo);
        }

        /// <summary>O XData do borne — o app name atual ou o legado.</summary>
        internal static IReadOnlyList<TypedXData> LerXData(BlockReference bloco)
        {
            ResultBuffer xdata = bloco.GetXDataForApplication(BorneXData.AppName)
                ?? bloco.GetXDataForApplication(BorneXData.AppNameLegado);

            return xdata == null ? null : XDataNeutro.Para(xdata);
        }

        internal static ResultBuffer ParaResultBuffer(IReadOnlyList<TypedXData> valores)
        {
            TypedValue[] array = new TypedValue[valores.Count];
            for (int i = 0; i < valores.Count; i++)
            {
                array[i] = new TypedValue(valores[i].Codigo, valores[i].Valor);
            }

            return new ResultBuffer(array);
        }

        /// <summary>O bloco do borne pelo handle, na transação em curso; <c>null</c> se não for um bloco.</summary>
        internal static BlockReference AbrirPorHandle(Transaction transacao, Database banco, string handle)
        {
            long numero;
            if (!long.TryParse(handle, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out numero))
            {
                return null;
            }

            ObjectId id;
            if (!banco.TryGetObjectId(new Handle(numero), out id))
            {
                return null;
            }

            return transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
        }

        /// <summary>Registra o app name antes de gravar (sem registro o CAD lança).</summary>
        internal static void GarantirAppName(Transaction transacao, Database banco, string appName)
        {
            SymbolTable tabela = (SymbolTable)transacao.GetObject(banco.RegAppTableId, OpenMode.ForWrite);
            if (tabela.Has(appName))
            {
                return;
            }

            RegAppTableRecord registro = new RegAppTableRecord();
            registro.Name = appName;
            tabela.Add(registro);
            transacao.AddNewlyCreatedDBObject(registro, true);
        }
    }
}
