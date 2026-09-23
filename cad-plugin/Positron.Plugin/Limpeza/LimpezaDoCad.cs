using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Limpeza;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Limpeza
{
    /// <summary>
    /// A parte das ações de **limpeza do CAD** que toca o desenho (frente 2 do
    /// §7.6, o <c>Correcao.cs</c> do reverso). O que é regra está em
    /// <see cref="LimpezaDoDesenho"/>; aqui só se varre o ModelSpace / o
    /// dicionário nomeado e se escreve.
    ///
    /// São as quatro primeiras da frente porque são as mais simples e as menos
    /// acopladas ao projeto: nenhuma lê banco nem cadastro, só o desenho.
    /// </summary>
    internal static class LimpezaDoCad
    {
        internal sealed class Resultado
        {
            /// <summary>Entidades (ou dicionários) examinadas.</summary>
            internal int Lidos { get; set; }

            /// <summary>Entidades (ou dicionários) que a ação alterou.</summary>
            internal int Alterados { get; set; }
        }

        /// <summary>
        /// <c>ApagarTextosEmBranco</c> — apaga do ModelSpace todo <c>DBText</c> cujo
        /// texto é só espaços **e** que não tem XData. Devolve quantos foram lidos e
        /// quantos saíram; o original mostra só o segundo ("NTextos apagados.").
        /// </summary>
        internal static Resultado ApagarTextosEmBranco()
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
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco, OpenMode.ForRead);

                foreach (ObjectId id in espaco)
                {
                    DBText texto = transacao.GetObject(id, OpenMode.ForRead) as DBText;
                    if (texto == null)
                    {
                        continue;
                    }

                    resultado.Lidos++;

                    if (!LimpezaDoDesenho.TextoEmBranco(texto.TextString, texto.XData != null))
                    {
                        continue;
                    }

                    texto.UpgradeOpen();
                    texto.Erase();
                    texto.DowngradeOpen();
                    resultado.Alterados++;
                }

                transacao.Commit();
            }

            return resultado;
        }

        /// <summary>
        /// <c>apagaXDataTerceiros</c> — substitui o XData das entidades do ModelSpace
        /// que trazem o app name de terceiro pelo registro único de
        /// <see cref="LimpezaDoDesenho.XDataDeTerceirosSubstituido"/> (o efeito é
        /// remover o conteúdo de terceiro; a marca fica, como no original).
        /// </summary>
        internal static Resultado ApagarXDataTerceiros()
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
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco, OpenMode.ForRead);

                foreach (ObjectId id in espaco)
                {
                    Entity entidade = transacao.GetObject(id, OpenMode.ForRead) as Entity;
                    if (entidade == null)
                    {
                        continue;
                    }

                    resultado.Lidos++;

                    if (entidade.GetXDataForApplication(LimpezaDoDesenho.XDataTerceiros) == null)
                    {
                        continue;
                    }

                    entidade.UpgradeOpen();
                    entidade.XData = ParaResultBuffer(LimpezaDoDesenho.XDataDeTerceirosSubstituido());
                    resultado.Alterados++;
                }

                transacao.Commit();
            }

            return resultado;
        }

        /// <summary>
        /// <c>ApagaLayouts</c> — apaga o dicionário <c>CENG_LAYOUT</c> do desenho (a
        /// posição dos equipamentos no layout de cada painel, que o <c>FIA</c> usa no
        /// <c>PosicaoNum</c> e o <c>COMPLM</c> na <c>OrdemLay</c>). É o "recomeçar do
        /// zero" do original; depois dele o <c>FIA</c> ainda projeta, sem posição.
        /// </summary>
        internal static Resultado ApagarDicionarioLayout()
        {
            return ApagarDicionario(LimpezaDoDesenho.DicionarioLayout);
        }

        /// <summary>
        /// <c>ApagaPlaquetas</c> — apaga o dicionário <c>CENG_PLAQUETA</c> (as
        /// plaquetas de identificação de cada painel, o insumo do <c>EPLQ</c>).
        /// </summary>
        internal static Resultado ApagarDicionarioPlaquetas()
        {
            return ApagarDicionario(LimpezaDoDesenho.DicionarioPlaquetas);
        }

        private static Resultado ApagarDicionario(string nome)
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
                DBDictionary nomeados =
                    (DBDictionary)transacao.GetObject(banco.NamedObjectsDictionaryId, OpenMode.ForRead);

                if (!nomeados.Contains(nome))
                {
                    transacao.Commit();
                    return resultado;
                }

                resultado.Lidos = 1;

                DBDictionary dicionario =
                    (DBDictionary)transacao.GetObject(nomeados.GetAt(nome), OpenMode.ForWrite);
                dicionario.Erase();
                resultado.Alterados = 1;

                transacao.Commit();
            }

            return resultado;
        }

        private static BlockTableRecord EspacoDeModelo(Transaction transacao, Database banco, OpenMode modo)
        {
            BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, modo);
            return (BlockTableRecord)transacao.GetObject(tabela[BlockTableRecord.ModelSpace], modo);
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
