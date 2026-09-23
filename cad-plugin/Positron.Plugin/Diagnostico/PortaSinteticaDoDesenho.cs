using System;
using System.Collections.Generic;
using Positron.Data.Diagnostico;
using Positron.Data.Fiacao;
using Positron.Plugin.Bornes;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
#endif

namespace Positron.Plugin.Diagnostico
{
    /// <summary>
    /// O <c>pzDiagCriar</c> — monta no desenho a **porta sintética** que prova o
    /// <c>IndefineUmaPorta</c> ponta a ponta (a última pendência da frente 2): um bloco com os
    /// quatro ATTDEFs (<c>NOME1</c>, <c>T1</c>, <c>PAINEL</c>, <c>EFC</c>), a inserção com os
    /// valores antigos, o XData <c>Dispositivo</c> tipo <c>E</c> apontando o modelo 9 e a porta
    /// **5** e um dicionário <c>MASCARAS</c> cujo modelo 9 só tem a porta **3** — ou seja, a
    /// porta do desenho **não** está no dicionário.
    ///
    /// A criação é em **C#** de propósito: a fixture LISP equivalente não produzia saída (o
    /// gargalo das rodadas 90/91/102).
    /// </summary>
    internal static class PortaSinteticaDoDesenho
    {
        internal const string AppNameDispositivo = "Dispositivo";

        internal static string Criar()
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return "pzDiagCriar: sem documento ativo.";
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
                BlockTableRecord espaco = (BlockTableRecord)transacao.GetObject(
                    tabela[BlockTableRecord.ModelSpace], OpenMode.ForRead);

                // Idempotente: numa mesma passada o comando pode rodar antes e depois da
                // correção (a segunda chamada não pode estourar o `eDuplicateRecordName`).
                if (tabela.Has(PortaSintetica.NomeDoBloco))
                {
                    return "pzDiagCriar: a porta sintética já existe (nada a fazer).";
                }

                tabela.UpgradeOpen();
                BlockTableRecord definicao = new BlockTableRecord();
                definicao.Name = PortaSintetica.NomeDoBloco;
                ObjectId idDefinicao = tabela.Add(definicao);
                transacao.AddNewlyCreatedDBObject(definicao, true);

                for (int i = 0; i < PortaSintetica.Tags.Count; i++)
                {
                    AttributeDefinition attdef = new AttributeDefinition();
                    attdef.Tag = PortaSintetica.Tags[i];
                    attdef.TextString = PortaSintetica.Valores[i];
                    attdef.Height = 2.5;
                    attdef.Position = new Point3d(0.0, -1.0 * i, 0.0);
                    attdef.SetDatabaseDefaults();
                    definicao.AppendEntity(attdef);
                    transacao.AddNewlyCreatedDBObject(attdef, true);
                }

                espaco.UpgradeOpen();
                // O `Name` do BlockReference é somente leitura (vem da definição).
                BlockReference inserida = new BlockReference(new Point3d(10.0, 0.0, 0.0), idDefinicao);
                espaco.AppendEntity(inserida);
                transacao.AddNewlyCreatedDBObject(inserida, true);

                for (int i = 0; i < PortaSintetica.Tags.Count; i++)
                {
                    AttributeReference atributo = new AttributeReference();
                    atributo.Tag = PortaSintetica.Tags[i];
                    atributo.TextString = PortaSintetica.Valores[i];
                    atributo.SetDatabaseDefaults();
                    inserida.AttributeCollection.AppendAttribute(atributo);
                    transacao.AddNewlyCreatedDBObject(atributo, true);
                }

                BornesDaCorrecao.GarantirAppName(transacao, banco, AppNameDispositivo);
                inserida.XData = ParaResultBuffer(PortaSintetica.ParaValores(
                    PortaSintetica.IndiceDoModelo, PortaSintetica.IndiceDaPorta));

                CriarMascaras(transacao, banco, tabela);
                transacao.Commit();
            }

            return "pzDiagCriar: porta sintética criada (bloco " + PortaSintetica.NomeDoBloco
                + ", modelo " + PortaSintetica.IndiceDoModelo + ", porta " + PortaSintetica.IndiceDaPorta
                + "; o MASCARAS só tem a porta " + PortaSintetica.IndiceDaPortaDoDicionario + ").";
        }

        /// <summary>O dicionário <c>MASCARAS</c> com o modelo 9 e a porta 3 (a que não casa).</summary>
        private static void CriarMascaras(Transaction transacao, Database banco, BlockTable tabela)
        {
            DBDictionary raiz = (DBDictionary)transacao.GetObject(
                banco.NamedObjectsDictionaryId, OpenMode.ForRead);
            raiz.UpgradeOpen();

            DBDictionary mascaras;
            if (raiz.Contains("MASCARAS"))
            {
                mascaras = (DBDictionary)transacao.GetObject(raiz.GetAt("MASCARAS"), OpenMode.ForWrite);
            }
            else
            {
                mascaras = new DBDictionary();
                raiz.SetAt("MASCARAS", mascaras);
                transacao.AddNewlyCreatedDBObject(mascaras, true);
            }

            Xrecord modelos = new Xrecord();
            modelos.Data = ParaResultBuffer(new List<TypedXData>
            {
                new TypedXData(90, 1),
                new TypedXData(90, PortaSintetica.IndiceDoModelo),
                new TypedXData(1, "M9"),
                new TypedXData(90, 1),
                new TypedXData(90, 2),
                new TypedXData(90, 0),
                new TypedXData(1, "BLOCO"),
                new TypedXData(1, "LAYOUT"),
                new TypedXData(1, "H"),
                new TypedXData(1, string.Empty),
                new TypedXData(1, string.Empty),
            });
            mascaras.SetAt("MODELOS2", modelos);
            transacao.AddNewlyCreatedDBObject(modelos, true);

            Xrecord portas = new Xrecord();
            portas.Data = ParaResultBuffer(new List<TypedXData>
            {
                new TypedXData(90, 1),
                new TypedXData(90, PortaSintetica.IndiceDaPortaDoDicionario),
                new TypedXData(1, "H"),
                new TypedXData(1, "EFC3"),
                new TypedXData(1, "T1X"),
                new TypedXData(1, "B1X"),
                new TypedXData(1, string.Empty),
                new TypedXData(1, "R1"),
                new TypedXData(1, string.Empty),
            });
            mascaras.SetAt(PortaSintetica.IndiceDoModelo.ToString(), portas);
            transacao.AddNewlyCreatedDBObject(portas, true);
        }

        private static ResultBuffer ParaResultBuffer(IReadOnlyList<TypedXData> valores)
        {
            TypedValue[] array = new TypedValue[valores.Count];
            for (int i = 0; i < valores.Count; i++)
            {
                array[i] = new TypedValue(valores[i].Codigo, valores[i].Valor);
            }

            return new ResultBuffer(array);
        }
    }
}
