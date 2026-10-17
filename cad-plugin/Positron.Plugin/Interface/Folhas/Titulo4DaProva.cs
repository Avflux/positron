using System;
using Positron.Plugin.Paginas;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
#endif

namespace Positron.Plugin.Interface.Folhas
{
    /// <summary>
    /// A preparação do **título 4** para a prova da rodada 222: as colunas do
    /// <c>frmEditaTitulos</c> existem quando o atributo do formato está no layer <c>-1</c> com a tag
    /// <c>TITULOnPAG</c> (<c>Pagina.buscaTitulosExistentes</c>, <c>Pagina.cs:2502-2562</c>) — e o
    /// `Funcional.dwg` só tem TITULO1PAG..TITULO3PAG. Aqui entra um <c>TITULO4PAG</c> na referência
    /// do formato pela API do CAD (o ActiveX do AutoLISP não tem <c>AddAttribute</c> nesta versão —
    /// medido: "unknown name: AddAttribute"). Só o harness chama; não é comportamento de produto.
    /// </summary>
    internal static class Titulo4DaProva
    {
        internal static string Acrescentar()
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return "sem documento ativo";
            }

            Database banco = documento.Database;
            using (documento.LockDocument())
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
                BlockTableRecord espaco = (BlockTableRecord)transacao.GetObject(
                    tabela[BlockTableRecord.ModelSpace], OpenMode.ForRead);
                BlockReference formato = FormatoDoDesenho.Encontrar(transacao, espaco);
                if (formato == null)
                {
                    return "sem bloco de formato";
                }

                foreach (ObjectId id in formato.AttributeCollection)
                {
                    AttributeReference existente = transacao.GetObject(id, OpenMode.ForRead) as AttributeReference;
                    if (existente != null && string.Equals(existente.Tag, "TITULO4PAG", StringComparison.OrdinalIgnoreCase))
                    {
                        return "o formato já tem TITULO4PAG";
                    }
                }

                formato.UpgradeOpen();
                AttributeReference atributo = new AttributeReference
                {
                    Tag = "TITULO4PAG",
                    TextString = "TITULO 4",
                    Layer = "-1",
                    Position = new Point3d(0.0, 0.0, 0.0),
                    Height = 2.5,
                };
                formato.AttributeCollection.AppendAttribute(atributo);
                transacao.AddNewlyCreatedDBObject(atributo, true);
                transacao.Commit();
            }

            return "atributo TITULO4PAG (layer -1) acrescentado ao formato";
        }
    }
}
