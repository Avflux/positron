using System.Collections.Generic;

namespace Positron.Data.Paginas
{
    /// <summary>
    /// A **criação da página** do <c>Pagina.criarUmaNovaPagina</c> do reverso (a fatia 6 da frente 10):
    /// o que é **puro** é o nome que a página nova recebe e os campos do formato que ela copia.
    ///
    /// 1. <see cref="Normalizar"/> é o <c>montaNumeroPagina</c> do original: tira os zeros à esquerda
    ///    e, com a **largura fixa** ligada (<c>Conf.LarguraFixaPaginas</c>), completa com zeros até
    ///    essa largura — com o detalhe do original que soma **um** zero a mais quando o nome não é
    ///    numérico (o `num++` do ramo `Not IsNumeric`);
    /// 2. <see cref="CampoDoFormato.De"/> é o mapa do <c>criaCamposFormato</c>: dos atributos
    ///    protegidos do bloco de formato, **oito** viram campo da página nova (os outros — SÉCAO,
    ///    REV0..7, DESC, DATA, ELAB, VERIF, APROV — entram no laço do original e **não** geram
    ///    campo nenhum; o mapa abaixo é a leitura do <c>if/else</c> dele). Cada campo leva o
    ///    **índice do título** que o <c>gravarXDataTitulo</c> grava no XData.
    /// 
    /// Quem escreve no desenho (o layer e os textos) é o adapter do plugin.
    /// </summary>
    public static class CriacaoDePagina
    {
        /// <summary>Um campo do formato que a página nova recebe (o <c>criaCamposFormato</c>).</summary>
        public sealed class CampoDoFormato
        {
            private CampoDoFormato(string tag, int indice, string texto)
            {
                Tag = tag;
                Indice = indice;
                Texto = texto;
            }

            /// <summary>A tag do atributo no bloco de formato (como o designer a escreveu).</summary>
            public string Tag { get; private set; }

            /// <summary>O índice do título no XData do texto (<c>gravarXDataTitulo</c>).</summary>
            public int Indice { get; private set; }

            /// <summary>O texto que o campo nasce com (um espaço, ou <c>?</c> nos dois indefinidos).</summary>
            public string Texto { get; private set; }

            /// <summary>O campo do formato para a tag, ou <c>null</c> quando ela não gera campo.</summary>
            public static CampoDoFormato De(string tag)
            {
                if (string.IsNullOrEmpty(tag))
                {
                    return null;
                }

                switch (tag.Trim().ToUpperInvariant())
                {
                    case "FL":
                        return new CampoDoFormato("FL", 6, "?");
                    case "CONT":
                        return new CampoDoFormato("CONT", 5, "?");
                    case "ALTERNATIVO":
                        return new CampoDoFormato("ALTERNATIVO", 9, " ");
                    case "REV":
                        return new CampoDoFormato("REV", 8, " ");
                    case "TITULO1PAG":
                        return new CampoDoFormato("TITULO1PAG", 1, " ");
                    case "TITULO2PAG":
                        return new CampoDoFormato("TITULO2PAG", 2, " ");
                    case "TITULO3PAG":
                        return new CampoDoFormato("TITULO3PAG", 3, " ");
                    case "TITULO4PAG":
                    case "PAINEL":
                        return new CampoDoFormato(tag.Trim().ToUpperInvariant(), 4, " ");
                    default:
                        return null;
                }
            }
        }

        /// <summary>
        /// O nome normalizado da página (o <c>montaNumeroPagina</c>). <paramref name="larguraFixa"/>
        /// zero é o padrão do original (sem zeros à esquerda).
        /// </summary>
        public static string Normalizar(string pagina, int larguraFixa)
        {
            string texto = (pagina ?? string.Empty).Trim();
            while (texto.Length > 0 && texto[0] == '0')
            {
                texto = texto.Substring(1);
            }

            if (larguraFixa != 0
                && !(PaginaNumerada.EhNumerico(pagina) && texto.Length >= larguraFixa)
                && texto.Length <= larguraFixa)
            {
                int quantos = larguraFixa - texto.Length;
                if (!PaginaNumerada.EhNumerico(texto))
                {
                    quantos++;
                }

                texto = new string('0', quantos) + texto;
            }

            return texto;
        }
    }
}
