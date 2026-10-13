using System;

namespace Positron.Data.Paginas
{
    /// <summary>
    /// Os **quatro títulos** de uma página (o <c>tPagina.Titulo1..4</c> do original). Cada um é um
    /// texto no layer da página com o XData do título: o <c>capturaTitulosDeUmaPagina</c> lê os quatro
    /// e o <c>AtualizaTitulosDeUmaPagina</c> os regrava.
    ///
    /// O **índice** do XData é a chave (1..4). Como o mapa do <c>criaCamposFormato</c> dá o índice 4
    /// tanto ao <c>TITULO4PAG</c> quanto ao <c>PAINEL</c>, os dois textos da página recebem o
    /// <c>Titulo4</c> — é o que o <c>switch</c> do original faz (ele não olha a tag, só o índice).
    /// </summary>
    public sealed class TitulosDaPagina
    {
        /// <summary>O último índice de título (o original só trata 1..4).</summary>
        public const int UltimoIndice = 4;

        public string Titulo1 { get; set; }

        public string Titulo2 { get; set; }

        public string Titulo3 { get; set; }

        public string Titulo4 { get; set; }

        /// <summary>Quantos dos quatro já vieram do desenho (o contador do original).</summary>
        public int Quantos { get; private set; }

        /// <summary>Todos os quatro foram lidos (mesmo que vazios).</summary>
        public bool Completos
        {
            get { return Quantos >= UltimoIndice; }
        }

        /// <summary>O título do índice (1..4), ou <c>null</c> fora da faixa.</summary>
        public string De(int indice)
        {
            switch (indice)
            {
                case 1: return Titulo1;
                case 2: return Titulo2;
                case 3: return Titulo3;
                case 4: return Titulo4;
                default: return null;
            }
        }

        /// <summary>
        /// Guarda o valor do índice 1..4 e conta o achado. Índice fora da faixa é ignorado
        /// (o <c>if ((num2 &gt; 0) &amp; (num2 &lt; 5))</c> do original) e o mesmo índice não conta duas vezes.
        /// </summary>
        public void Definir(int indice, string valor)
        {
            if (indice < 1 || indice > UltimoIndice)
            {
                return;
            }

            bool jaTinha = De(indice) != null;
            switch (indice)
            {
                case 1: Titulo1 = valor; break;
                case 2: Titulo2 = valor; break;
                case 3: Titulo3 = valor; break;
                case 4: Titulo4 = valor; break;
            }

            if (!jaTinha)
            {
                Quantos++;
            }
        }
    }
}
