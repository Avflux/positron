using System;
using System.Collections.Generic;

namespace Positron.Data.Paginas
{
    /// <summary>O tipo de entidade que o <c>EditaTitulosTextosDoDWG</c> olha.</summary>
    public enum TipoDeTextoNaPagina
    {
        Outro,

        /// <summary><c>DBText</c>: título de página (XData <c>TituloPagina</c> 1..4) ou texto solto.</summary>
        Texto,

        /// <summary><c>MText</c>.</summary>
        MultiTexto,
    }

    /// <summary>Uma entidade do ModelSpace como a edição a vê.</summary>
    public sealed class TextoNaPagina
    {
        public TextoNaPagina(TipoDeTextoNaPagina tipo, string layer, string texto, int titulo, bool protegido)
        {
            Tipo = tipo;
            Layer = layer;
            Texto = texto;
            Titulo = titulo;
            Protegido = protegido;
        }

        public TipoDeTextoNaPagina Tipo { get; }

        public string Layer { get; }

        /// <summary>O <c>TextString</c> do texto ou o <c>Contents</c> do multitexto.</summary>
        public string Texto { get; }

        /// <summary>O índice do título (1..4, o <c>LeXDataTitulo</c>); 0 quando não é título.</summary>
        public int Titulo { get; }

        /// <summary>O <c>LerXDataVazio</c>: tem XData de um dos <see cref="EdicaoDeTitulosETextos.AppsProtegidos"/>.</summary>
        public bool Protegido { get; }
    }

    /// <summary>O que o usuário marcou na tela (os seis <c>CheckBox</c>, o DE e o PARA).</summary>
    public sealed class OpcoesDeTitulosETextos
    {
        public bool Titulo1 { get; set; }

        public bool Titulo2 { get; set; }

        public bool Titulo3 { get; set; }

        public bool Titulo4 { get; set; }

        public bool Textos { get; set; }

        public bool MultiTextos { get; set; }

        public string De { get; set; }

        public string Para { get; set; }

        /// <summary>
        /// O botão só faz algo com alguma caixa marcada e o DE preenchido (o <c>sgrSxhI2bv</c>
        /// volta calado nos outros casos).
        /// </summary>
        public bool Valida
        {
            get
            {
                return (Titulo1 || Titulo2 || Titulo3 || Titulo4 || Textos || MultiTextos) && !string.IsNullOrEmpty(De);
            }
        }

        internal bool Titulo(int indice)
        {
            switch (indice)
            {
                case 1: return Titulo1;
                case 2: return Titulo2;
                case 3: return Titulo3;
                case 4: return Titulo4;
                default: return false;
            }
        }
    }

    /// <summary>
    /// A **edição de títulos e textos** (o comando <c>TROCTT</c>, a tela <c>frmEditaTitulosTextos</c>):
    /// troca um trecho (DE → PARA) nos títulos de página escolhidos, nos textos e nos multitextos das
    /// páginas selecionadas. É o <c>clsEditaTitulosTextos.EditaTitulosTextosDoDWG</c>
    /// (<c>clsEditaTitulosTextos.cs:15</c>) e o <c>Pagina.buscaTitulosExistentes</c>
    /// (<c>Pagina.cs:2502</c>), que habilita cada "Título n".
    /// </summary>
    public static class EdicaoDeTitulosETextos
    {
        /// <summary>
        /// Os app names do <c>LerXDataVazio</c>: o texto (ou multitexto) com XData de um deles é do
        /// próprio produto e não é tocado como "texto do AutoCAD".
        /// </summary>
        public static readonly IReadOnlyList<string> AppsProtegidos = new[]
        {
            "Eletron", "DiagLog", "TextoLP", "AUXCONEXAO", "AUXINTERLIG", "AUXIMPORTADO", "DEPARA", "Definicao",
        };

        /// <summary>
        /// Os títulos que o formato tem (índices 1..4): os atributos do bloco de formato no layer
        /// <c>-1</c> com a tag <c>TITULOnPAG</c> — e <c>PAINEL</c> também liga o título 4.
        /// </summary>
        public static bool[] TitulosExistentes(IEnumerable<KeyValuePair<string, string>> tagsELayers)
        {
            bool[] existe = new bool[5];
            if (tagsELayers == null)
            {
                return existe;
            }

            foreach (KeyValuePair<string, string> atributo in tagsELayers)
            {
                if (!string.Equals(atributo.Value, "-1", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                switch ((atributo.Key ?? string.Empty).ToUpperInvariant())
                {
                    case "TITULO1PAG": existe[1] = true; break;
                    case "TITULO2PAG": existe[2] = true; break;
                    case "TITULO3PAG": existe[3] = true; break;
                    case "TITULO4PAG":
                    case "PAINEL": existe[4] = true; break;
                }
            }

            return existe;
        }

        /// <summary>
        /// O texto novo da entidade, ou <c>null</c> quando ela fica como está. Fora das páginas
        /// escolhidas (<c>List.Contains</c>, que diferencia maiúsculas), nada. A troca é o
        /// <c>String.Replace</c> (diferencia maiúsculas); e só conta quando o resultado difere do
        /// original **sem** diferenciar maiúsculas e espaços nas pontas — trocar só a caixa não grava.
        /// </summary>
        public static string NovoTexto(TextoNaPagina entidade, OpcoesDeTitulosETextos opcoes, ICollection<string> paginas)
        {
            if (entidade == null || opcoes == null || paginas == null || !paginas.Contains(entidade.Layer))
            {
                return null;
            }

            switch (entidade.Tipo)
            {
                case TipoDeTextoNaPagina.Texto:
                    if (entidade.Titulo >= 1 && entidade.Titulo <= 4)
                    {
                        return opcoes.Titulo(entidade.Titulo) ? Trocar(entidade.Texto, opcoes) : null;
                    }

                    return opcoes.Textos && !entidade.Protegido ? Trocar(entidade.Texto, opcoes) : null;

                case TipoDeTextoNaPagina.MultiTexto:
                    return opcoes.MultiTextos && !entidade.Protegido ? Trocar(entidade.Texto, opcoes) : null;

                default:
                    return null;
            }
        }

        private static string Trocar(string texto, OpcoesDeTitulosETextos opcoes)
        {
            string atual = texto ?? string.Empty;
            if (atual.Trim().Length == 0)
            {
                return null;
            }

            string novo = atual.Replace(opcoes.De, opcoes.Para ?? string.Empty);
            return string.Equals(novo.ToUpper().Trim(), atual.ToUpper().Trim(), StringComparison.CurrentCultureIgnoreCase) ? null : novo;
        }
    }
}
