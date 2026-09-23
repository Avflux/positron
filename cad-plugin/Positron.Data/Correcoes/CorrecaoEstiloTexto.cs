using System;
using System.Collections.Generic;

namespace Positron.Data.Correcoes
{
    /// <summary>
    /// Um estilo de texto da <c>TextStyleTable</c> do desenho, como a correção
    /// precisa dele: nome, arquivo da fonte (<c>FileName</c>), escala horizontal
    /// (<c>XScale</c>, o width factor do DXF 41) e altura fixa (<c>TextSize</c>,
    /// o DXF 40).
    /// </summary>
    public sealed class EstiloTexto
    {
        public string Nome { get; set; }

        /// <summary>O <c>TextStyleTableRecord.FileName</c> — vazio quando o estilo está sem fonte.</summary>
        public string ArquivoFonte { get; set; }

        public double EscalaX { get; set; }

        public double Altura { get; set; }
    }

    /// <summary>O que a correção faz com **um** estilo (o adapter abre e grava).</summary>
    public sealed class CorrecaoDeEstilo
    {
        public int Indice { get; set; }

        /// <summary>Copia a fonte do estilo de referência (o original: <c>val4.Font = val5.Font</c>).</summary>
        public bool CopiarFonte { get; set; }

        /// <summary>
        /// O arquivo de fonte da referência, para o adapter **também** regravar o
        /// <c>FileName</c>. O original só copia o descritor <c>Font</c>, e no ZWCAD
        /// isso **não** regrava o arquivo — o estilo continua lido como "sem fonte"
        /// e o comando nunca converge (medido: ver <c>RUNBOOK.md</c>, rodada 73).
        /// </summary>
        public string ArquivoFonte { get; set; }

        public bool AjustarEscala { get; set; }

        public double EscalaX { get; set; }

        public bool AjustarAltura { get; set; }

        public double Altura { get; set; }
    }

    /// <summary>O plano inteiro: quem é a referência, quem tem problema e o que muda em cada um.</summary>
    public sealed class PlanoDeEstilos
    {
        public PlanoDeEstilos()
        {
            Problemas = new List<string>();
            Correcoes = new List<CorrecaoDeEstilo>();
        }

        /// <summary>Índice, na ordem da tabela, do estilo que serve de referência (<c>-1</c> quando não há estilo).</summary>
        public int IndiceReferencia { get; set; }

        /// <summary>
        /// A referência é mesmo um <c>arial.ttf</c>? Quando o desenho não tem esse
        /// estilo, o original usa o **último** estilo da tabela — o quirk fica
        /// registrado e o resumo diz que a referência não é a esperada.
        /// </summary>
        public bool TemReferenciaArial { get; set; }

        /// <summary>Nomes dos estilos com problema (sem fonte **ou** com escala 0) — a lista do aviso do original.</summary>
        public List<string> Problemas { get; private set; }

        /// <summary>Só os estilos que o adapter precisa abrir e regravar, na ordem da tabela.</summary>
        public List<CorrecaoDeEstilo> Correcoes { get; private set; }
    }

    /// <summary>
    /// A regra do comando <c>CorrigeStyle</c> do original (<c>Correcao.cs</c>, o
    /// <c>corrigeStyles</c>): corrige os **estilos de texto** do desenho.
    ///
    /// Um estilo tem problema quando <c>FileName == ""</c> (sem fonte) **ou**
    /// <c>XScale == 0</c> (escala horizontal inválida). O original então:
    /// 1. escolhe a **referência** — o primeiro estilo cujo <c>FileName</c> é
    ///    <c>arial.ttf</c> (comparação sem caixa); se não existir, cai no
    ///    **último** estilo da ordem da tabela (quirk reproduzido, porque muda o
    ///    resultado num desenho sem Arial);
    /// 2. para cada estilo **sem fonte**, copia da referência a fonte, a escala
    ///    (<c>ref.EscalaX</c> ou <c>1</c> quando a referência tem escala 0) e a
    ///    altura;
    /// 3. e, **independentemente** do campo anterior, quando a **referência** tem
    ///    escala 0, põe <c>1</c> na escala de todo estilo que ainda não esteja em
    ///    <c>1</c> — é a segunda comparação do original, que não olha o
    ///    <c>FileName</c>.
    ///
    /// **A referência é um objeto vivo** (quirk que muda o resultado): o laço do
    /// original percorre os estilos na ordem da tabela e, quando chega no próprio
    /// estilo de referência, corrige-o — a partir dali <c>val5.XScale</c> já não é
    /// mais <c>0</c>, então os estilos **seguintes** deixam de casar a segunda
    /// comparação. Esta regra percorre na mesma ordem e atualiza a escala da
    /// referência ao processá-la, para o plano bater com o original em qualquer
    /// posição da referência.
    ///
    /// Sem nenhum estilo com problema o original nem entra no laço de gravação: o
    /// plano sai vazio. O que é puro é esta decisão; quem varre a
    /// <c>TextStyleTable</c> e grava é o adapter do plugin.
    /// </summary>
    public static class CorrecaoEstiloTexto
    {
        /// <summary>O arquivo de fonte que o original procura para ser a referência.</summary>
        public const string FonteReferencia = "arial.ttf";

        /// <summary>O estilo está **sem fonte** (o original compara <c>FileName</c> com <c>""</c>, sem caixa).</summary>
        public static bool ArquivoVazio(string arquivoFonte)
        {
            return string.IsNullOrEmpty(arquivoFonte);
        }

        /// <summary>O estilo tem problema e entra na lista do aviso: sem fonte **ou** com escala 0.</summary>
        public static bool PrecisaCorrigir(EstiloTexto estilo)
        {
            return estilo != null && (ArquivoVazio(estilo.ArquivoFonte) || estilo.EscalaX == 0.0);
        }

        /// <summary>
        /// O índice do estilo de referência: o primeiro com <c>arial.ttf</c>, ou o
        /// **último** da tabela quando não há nenhum (o quirk do original).
        /// Devolve <c>-1</c> sem estilos.
        /// </summary>
        public static int IndiceDaReferencia(IReadOnlyList<EstiloTexto> estilos)
        {
            if (estilos == null || estilos.Count == 0)
            {
                return -1;
            }

            for (int i = 0; i < estilos.Count; i++)
            {
                if (string.Equals(estilos[i].ArquivoFonte, FonteReferencia, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }

            return estilos.Count - 1;
        }

        /// <summary>Planeja a correção inteira (nada é gravado aqui).</summary>
        public static PlanoDeEstilos Planejar(IReadOnlyList<EstiloTexto> estilos)
        {
            PlanoDeEstilos plano = new PlanoDeEstilos();
            if (estilos == null || estilos.Count == 0)
            {
                return plano;
            }

            plano.IndiceReferencia = IndiceDaReferencia(estilos);
            EstiloTexto referencia = estilos[plano.IndiceReferencia];
            plano.TemReferenciaArial = string.Equals(
                referencia.ArquivoFonte, FonteReferencia, StringComparison.OrdinalIgnoreCase);

            for (int i = 0; i < estilos.Count; i++)
            {
                if (PrecisaCorrigir(estilos[i]))
                {
                    plano.Problemas.Add(estilos[i].Nome);
                }
            }

            // `if (num != 0)` do original: sem problema, nada é tocado.
            if (plano.Problemas.Count == 0)
            {
                return plano;
            }

            // A escala da referência é lida viva, como no original: quando o laço
            // chega no próprio estilo de referência, a correção o muda para 1 e os
            // estilos seguintes já veem 1 (a altura nunca muda, porque só é escrita
            // a partir da própria referência).
            double escalaReferencia = referencia.EscalaX;

            for (int i = 0; i < estilos.Count; i++)
            {
                EstiloTexto estilo = estilos[i];
                CorrecaoDeEstilo correcao = new CorrecaoDeEstilo { Indice = i };
                bool altera = false;

                if (ArquivoVazio(estilo.ArquivoFonte))
                {
                    correcao.CopiarFonte = true;
                    correcao.ArquivoFonte = referencia.ArquivoFonte;
                    altera = true;

                    double escala = escalaReferencia > 0.0 ? escalaReferencia : 1.0;
                    if (escala != estilo.EscalaX)
                    {
                        correcao.AjustarEscala = true;
                        correcao.EscalaX = escala;
                    }

                    if (referencia.Altura != estilo.Altura)
                    {
                        correcao.AjustarAltura = true;
                        correcao.Altura = referencia.Altura;
                    }
                }

                // A segunda comparação do original é **independente**: quando a
                // referência está com escala 0, ela põe 1 na escala de qualquer
                // estilo, mesmo os que têm fonte.
                if (escalaReferencia == 0.0 && estilo.EscalaX != 1.0)
                {
                    correcao.AjustarEscala = true;
                    correcao.EscalaX = 1.0;
                    altera = true;
                }

                if (altera)
                {
                    plano.Correcoes.Add(correcao);
                }

                // O original corrige a referência ao passar por ela: daqui em
                // diante o `val5.XScale` que o laço lê já é 1.
                if (i == plano.IndiceReferencia && correcao.AjustarEscala)
                {
                    escalaReferencia = correcao.EscalaX;
                }
            }

            return plano;
        }
    }
}
