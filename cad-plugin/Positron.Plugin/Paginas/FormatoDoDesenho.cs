using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;
#if AUTOCAD
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Paginas
{
    /// <summary>
    /// O **bloco de formato** do desenho: o <c>BlockReference</c> do ModelSpace marcado pelo XData
    /// <c>DiagLog</c>/<c>Formato</c> (o <c>PossuiXDataFormato</c> do original) e as
    /// <c>AttributeDefinition</c> da sua definição (o <c>blockFormatoName</c>). É a fonte tanto dos
    /// campos de título copiados pela criação de página quanto das definições
    /// <c>Revisao_Capa{n}</c>/<c>Revisao_Corpo{n}</c>.
    /// </summary>
    internal static class FormatoDoDesenho
    {
        /// <summary>App name do XData que marca o bloco de formato (o mesmo dos títulos).</summary>
        internal const string AppName = "DiagLog";

        /// <summary>A marca do bloco de formato dentro do XData <c>DiagLog</c>.</summary>
        internal const string Marca = "Formato";

        /// <summary>O bloco de formato do espaço dado (o <c>PossuiXDataFormato</c>).</summary>
        internal static BlockReference Encontrar(Transaction transacao, BlockTableRecord espaco)
        {
            if (transacao == null || espaco == null)
            {
                return null;
            }

            foreach (ObjectId id in espaco)
            {
                BlockReference bloco = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
                if (bloco == null)
                {
                    continue;
                }

                ResultBuffer xdata = bloco.GetXDataForApplication(AppName);
                if (xdata == null)
                {
                    continue;
                }

                IReadOnlyList<TypedXData> valores = XDataNeutro.Para(xdata);
                if (valores.Count > 1
                    && string.Equals(Convert.ToString(valores[1].Valor), Marca, StringComparison.OrdinalIgnoreCase))
                {
                    return bloco;
                }
            }

            return null;
        }

        /// <summary>
        /// As definições de atributo do **bloco de formato** — o original lê o
        /// <c>BlockTableRecord</c> de <c>blockFormatoName</c> (o nome da definição da referência), e
        /// não os valores da referência.
        /// </summary>
        internal static List<AtributoDeFormato> Atributos(Transaction transacao, BlockTable tabela, BlockReference formato)
        {
            List<AtributoDeFormato> atributos = new List<AtributoDeFormato>();
            if (transacao == null || tabela == null || formato == null
                || string.IsNullOrEmpty(formato.Name) || !tabela.Has(formato.Name))
            {
                return atributos;
            }

            BlockTableRecord definicao = transacao.GetObject(tabela[formato.Name], OpenMode.ForRead) as BlockTableRecord;
            if (definicao == null)
            {
                return atributos;
            }

            foreach (ObjectId id in definicao)
            {
                AttributeDefinition atributo = transacao.GetObject(id, OpenMode.ForRead) as AttributeDefinition;
                if (atributo == null)
                {
                    continue;
                }

                atributos.Add(new AtributoDeFormato(id, atributo.Tag, atributo.Layer));
            }

            return atributos;
        }
    }

    /// <summary>Uma definição de atributo do bloco de formato — o id, o tag e o layer.</summary>
    internal sealed class AtributoDeFormato
    {
        internal AtributoDeFormato(ObjectId id, string tag, string layer)
        {
            Id = id;
            Tag = tag ?? string.Empty;
            Layer = layer ?? string.Empty;
        }

        internal ObjectId Id { get; private set; }

        internal string Tag { get; private set; }

        internal string Layer { get; private set; }
    }
}
