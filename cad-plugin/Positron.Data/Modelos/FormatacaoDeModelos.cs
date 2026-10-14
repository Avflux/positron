using System;
using System.Collections.Generic;
using Positron.Data.Materiais;

namespace Positron.Data.Modelos
{
    /// <summary>
    /// Formatação e resolução dos dados de exibição dos gerenciadores de modelos
    /// (<c>GERMASC</c> e <c>GERCONT</c>).
    /// </summary>
    public static class FormatacaoDeModelos
    {
        public sealed class DetalheDoMaterial
        {
            public string Codigo { get; set; }

            public string Descricao { get; set; }

            public string Modelo { get; set; }

            public string Fabricante { get; set; }
        }

        /// <summary>
        /// Resolve os dados de exibição do material (slot 1 ou 2) a partir do código LM
        /// e do catálogo indexado por código interno (o <c>yuSzcqjrTY</c> / <c>i3dr5Qwhxi</c> do reverso).
        /// </summary>
        public static DetalheDoMaterial ResolverMaterial(int codigo, IReadOnlyDictionary<int, MaterialDoCatalogo> catalogo)
        {
            MaterialDoCatalogo mat;
            if (codigo > 0 && catalogo != null && catalogo.TryGetValue(codigo, out mat) && mat != null)
            {
                return new DetalheDoMaterial
                {
                    Codigo = codigo.ToString(),
                    Descricao = mat.DescricaoResumida ?? string.Empty,
                    Modelo = mat.Modelo ?? string.Empty,
                    Fabricante = mat.Fabricante ?? string.Empty,
                };
            }

            return new DetalheDoMaterial
            {
                Codigo = codigo == 0 ? "0" : codigo.ToString(),
                Descricao = string.Empty,
                Modelo = string.Empty,
                Fabricante = string.Empty,
            };
        }

        /// <summary>
        /// Normaliza o nome do bloco topográfico ou de layout para exibição em caixa alta (como no original).
        /// </summary>
        public static string FormatarNomeDoBloco(string bloco)
        {
            return string.IsNullOrEmpty(bloco) ? string.Empty : bloco.Trim().ToUpperInvariant();
        }
    }
}
