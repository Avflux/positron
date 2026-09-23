using System;
using System.Collections.Generic;
using Positron.Data.Bornes;
using Positron.Data.Correcoes;
using Positron.Data.Fiacao;
using Positron.Plugin.Bornes;
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
    /// <c>CorrigeBornes</c> — o <c>CorrecaoBornesVisiveis</c> do <c>Correcao.cs</c>:
    /// o borne com o campo <c>Visivel</c> em <c>-1</c> volta para <c>0</c>, com o
    /// XData regravado pelo mesmo <c>GravarXDataDispBorne</c> (que resolve o
    /// <c>lm</c> quando está zerado, como a correção de ordem).
    ///
    /// A decisão é pura (<see cref="CorrecaoVisibilidadeBorne"/>); aqui varre-se o
    /// ModelSpace e escreve-se.
    /// </summary>
    internal static class BornesVisiveisDoDesenho
    {
        internal sealed class Resultado
        {
            /// <summary>Bornes do desenho (blocos <c>B</c> com XData válido).</summary>
            internal int BornesLidos { get; set; }

            /// <summary>Bornes com <c>Visivel == -1</c> regravados.</summary>
            internal int BornesCorrigidos { get; set; }

            /// <summary>Bornes que ganharam o <c>lm</c> do dicionário de réguas na regravação.</summary>
            internal int LmResolvidos { get; set; }
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
            ReguasModelo reguas = ReguasDoDesenho.Ler();

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco, OpenMode.ForRead);
                foreach (ObjectId id in espaco)
                {
                    BlockReference bloco = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
                    if (bloco == null)
                    {
                        continue;
                    }

                    IReadOnlyList<TypedXData> valores = LerXData(bloco);
                    BorneXData borne;
                    if (valores == null || !BorneXData.Ler(valores, out borne))
                    {
                        continue;
                    }

                    resultado.BornesLidos++;

                    if (!CorrecaoVisibilidadeBorne.PrecisaCorrigir(borne.Visivel))
                    {
                        continue;
                    }

                    borne.Visivel = CorrecaoVisibilidadeBorne.VisivelCorrigido;

                    if (borne.Lm == 0)
                    {
                        int lm = reguas.BuscarLm(borne.IndiceRegua, borne.Tipo);
                        if (lm != 0)
                        {
                            borne.Lm = lm;
                            resultado.LmResolvidos++;
                        }
                    }

                    GarantirAppName(transacao, banco, BorneXData.AppName);
                    DBObject objeto = bloco;
                    objeto.UpgradeOpen();
                    objeto.XData = ParaResultBuffer(borne.ParaValores(
                        Environment.UserName,
                        DateTime.Now.ToString()));

                    resultado.BornesCorrigidos++;
                }

                transacao.Commit();
            }

            return resultado;
        }

        private static BlockTableRecord EspacoDeModelo(Transaction transacao, Database banco, OpenMode modo)
        {
            BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, modo);
            return (BlockTableRecord)transacao.GetObject(tabela[BlockTableRecord.ModelSpace], modo);
        }

        private static IReadOnlyList<TypedXData> LerXData(BlockReference bloco)
        {
            ResultBuffer xdata = bloco.GetXDataForApplication(BorneXData.AppName)
                ?? bloco.GetXDataForApplication(BorneXData.AppNameLegado);

            return xdata == null ? null : XDataNeutro.Para(xdata);
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

        private static void GarantirAppName(Transaction transacao, Database banco, string appName)
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

    /// <summary>
    /// <c>CorrigeDisp</c> — renomeia o app name legado <c>"DISPOSITIVO"</c> para
    /// <c>"Dispositivo"</c> na tabela <c>APPID</c> do desenho (o
    /// <c>CorrecaoDisp</c> do <c>Correcao.cs</c>).
    /// </summary>
    internal static class AppNameDoDesenho
    {
        internal sealed class Resultado
        {
            /// <summary>O desenho tinha o nome legado registrado.</summary>
            internal bool TinhaLegado { get; set; }

            /// <summary>
            /// O nome foi renomeado **e o CAD aceitou**: conferido depois do commit,
            /// relendo a tabela (o original só tenta e não confere).
            /// </summary>
            internal bool Renomeado { get; set; }
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

            // O `Has(nome)` do CAD **não diferencia caixa**: perguntar por
            // "DISPOSITIVO" acha a entrada "Dispositivo". Então o legado é
            // procurado pelo nome **como está gravado**, enumerando a tabela —
            // senão o comando diria "legado existe" em todo desenho e tentaria um
            // rename que não muda nada.
            ObjectId legado;
            bool tinha = EnumerarLegado(banco, out legado);
            resultado.TinhaLegado = tinha;
            if (tinha)
            {
                using (Transaction transacao = banco.TransactionManager.StartTransaction())
                {
                    RegAppTableRecord registro =
                        transacao.GetObject(legado, OpenMode.ForWrite) as RegAppTableRecord;
                    if (registro != null)
                    {
                        registro.Name = CorrecaoAppNameDispositivo.Atual;
                    }

                    transacao.Commit();
                }
            }

            // Confere o efeito numa transação nova: o `Name` é uma tentativa, e
            // quem diz se valeu é a tabela depois do commit.
            if (tinha)
            {
                resultado.Renomeado = !EnumerarLegado(banco, out _);
            }

            return resultado;
        }

        /// <summary>
        /// Procura o app name legado **pela caixa gravada** (o `Has` não serve:
        /// ele acha qualquer caixa). Devolve o <c>ObjectId</c>, que é o que sobrevive
        /// ao fim da transação (a instância do objeto não).
        /// </summary>
        private static bool EnumerarLegado(Database banco, out ObjectId legado)
        {
            legado = default(ObjectId);
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                RegAppTable tabela = (RegAppTable)transacao.GetObject(banco.RegAppTableId, OpenMode.ForRead);
                foreach (ObjectId id in tabela)
                {
                    RegAppTableRecord candidato = transacao.GetObject(id, OpenMode.ForRead) as RegAppTableRecord;
                    if (candidato != null
                        && string.Equals(candidato.Name, CorrecaoAppNameDispositivo.Legado, StringComparison.Ordinal))
                    {
                        legado = id;
                        transacao.Commit();
                        return true;
                    }
                }

                transacao.Commit();
            }

            return false;
        }
    }
}
