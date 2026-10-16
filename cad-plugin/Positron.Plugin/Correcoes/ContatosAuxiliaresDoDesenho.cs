using System;
using System.Collections.Generic;
using Positron.Data.Correcoes;
using Positron.Data.Fiacao;
using Positron.Data.Modelos;
using Positron.Plugin.Bornes;
using Positron.Plugin.Fiacao;
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
    /// <c>CorrigeContatosAux</c> — preenche o <c>HandleContatoAux</c> do XData
    /// <c>Modelo</c> de cada bloco de modelo com o handle do **bloco auxiliar**
    /// (tipo <c>A</c>) que casa com a chave <c>(HandleBob, indexModelo, indexContato)</c>
    /// — frente 2 do §7.6, o <c>Correcao.cs</c>. É o par de escrita do
    /// <c>bt4Auxiliar</c> (rodada 54).
    ///
    /// O que é regra está em <see cref="CorrecaoContatoAuxiliar"/>; aqui se varre o
    /// ModelSpace (os <c>A</c> vêm do mesmo leitor do <c>FIA</c>) e se grava só o que
    /// muda.
    ///
    /// **Diferença de propósito:** o original faz
    /// <c>blockRef.XData = new ResultBuffer(array)</c>, que troca o **buffer
    /// inteiro** do bloco — se o bloco também tiver XData de outro app name, ele
    /// some. Aqui só o registro do <c>Modelo</c> é trocado, preservando os demais.
    /// </summary>
    internal static class ContatosAuxiliaresDoDesenho
    {
        internal sealed class Resultado
        {
            /// <summary>Blocos auxiliares (<c>A</c>) lidos do desenho.</summary>
            internal int AuxiliaresLidos { get; set; }

            /// <summary>Blocos com XData <c>Modelo</c> lidos.</summary>
            internal int ModelosLidos { get; set; }

            /// <summary>Modelos cujo <c>HandleContatoAux</c> foi regravado.</summary>
            internal int ModelosAlterados { get; set; }

            /// <summary>Modelos que ficaram sem contato casado (o campo vai vazio, como no original).</summary>
            internal int SemContato { get; set; }
        }

        internal static Resultado Executar()
        {
            Resultado resultado = new Resultado();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return resultado;
            }

            List<ContatoAuxiliarNoDesenho> auxiliares = new List<ContatoAuxiliarNoDesenho>();
            foreach (DispositivoFiacao dispositivo in DispositivosDeFiacaoDoDesenho.Ler())
            {
                if (dispositivo == null ||
                    !string.Equals(dispositivo.Tipo, DispositivoFiacaoXData.TipoAuxiliar, StringComparison.Ordinal))
                {
                    continue;
                }

                auxiliares.Add(new ContatoAuxiliarNoDesenho
                {
                    Handle = dispositivo.Handle,
                    HandleBob = dispositivo.HandleBob,
                    IndexModelo = dispositivo.IndexModelo,
                    IndexContato = dispositivo.IndiceDaPorta,
                });
            }

            resultado.AuxiliaresLidos = auxiliares.Count;

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco);
                List<BlocoModelo> modelos = new List<BlocoModelo>();
                foreach (ObjectId id in espaco)
                {
                    BlocoModelo modelo = LerModelo(transacao, id);
                    if (modelo != null)
                    {
                        modelos.Add(modelo);
                    }
                }

                resultado.ModelosLidos = modelos.Count;

                IReadOnlyList<CorrecaoContatoAuxiliar.Ajuste> ajustes =
                    CorrecaoContatoAuxiliar.Planejar(auxiliares, modelos);

                foreach (CorrecaoContatoAuxiliar.Ajuste ajuste in ajustes)
                {
                    if (string.IsNullOrEmpty(ajuste.HandleContatoAux))
                    {
                        resultado.SemContato++;
                    }

                    if (!ajuste.Mudou)
                    {
                        continue;
                    }

                    BlockReference bloco = BornesDaCorrecao.AbrirPorHandle(transacao, banco, ajuste.Handle);
                    if (bloco == null)
                    {
                        continue;
                    }

                    BornesDaCorrecao.GarantirAppName(transacao, banco, ModeloXData.AppName);
                    BlocoModelo dados = ajuste.Modelo;
                    dados.HandleContatoAux = ajuste.HandleContatoAux;

                    ResultBuffer todos = bloco.XData;
                    bloco.UpgradeOpen();
                    bloco.XData = ParaResultBuffer(TrocandoOModelo(
                        todos == null ? null : XDataNeutro.Para(todos), dados));
                    resultado.ModelosAlterados++;
                }

                transacao.Commit();
            }

            return resultado;
        }

        private static BlocoModelo LerModelo(Transaction transacao, ObjectId id)
        {
            BlockReference bloco = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
            if (bloco == null)
            {
                return null;
            }

            ResultBuffer xdata = bloco.GetXDataForApplication(ModeloXData.AppName)
                ?? bloco.GetXDataForApplication(ModeloXData.AppNameLegado);
            if (xdata == null)
            {
                return null;
            }

            BlocoModelo modelo;
            if (!ModeloXData.Ler(XDataNeutro.Para(xdata), out modelo))
            {
                return null;
            }

            modelo.Handle = bloco.Handle.ToString();
            return modelo;
        }

        /// <summary>
        /// O XData do bloco com o registro do <c>Modelo</c> **trocado**: tira o
        /// registro antigo (do <c>Modelo</c> ou do legado <c>MODELO</c>) e põe o novo
        /// no fim, preservando os outros app names do bloco.
        /// </summary>
        internal static IReadOnlyList<TypedXData> TrocandoOModelo(
            IReadOnlyList<TypedXData> todos,
            BlocoModelo modelo)
        {
            List<TypedXData> restantes = new List<TypedXData>();
            bool dentro = false;
            if (todos != null)
            {
                foreach (TypedXData valor in todos)
                {
                    if (valor.Codigo == 1001)
                    {
                        string nome = valor.Valor as string;
                        dentro = nome != null &&
                            (string.Equals(nome, ModeloXData.AppName, StringComparison.OrdinalIgnoreCase));
                    }

                    if (!dentro)
                    {
                        restantes.Add(valor);
                    }
                }
            }

            foreach (TypedXData valor in ModeloXData.ParaValores(modelo))
            {
                restantes.Add(valor);
            }

            return restantes;
        }

        private static BlockTableRecord EspacoDeModelo(Transaction transacao, Database banco)
        {
            BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
            return (BlockTableRecord)transacao.GetObject(tabela[BlockTableRecord.ModelSpace], OpenMode.ForRead);
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
