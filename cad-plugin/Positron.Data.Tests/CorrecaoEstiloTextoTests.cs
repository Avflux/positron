using System.Collections.Generic;
using Positron.Data.Correcoes;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// A regra do <c>CorrigeStyle</c> (os estilos de texto do desenho): quem tem
    /// problema, quem é a referência e o que muda em cada um. As decisões vêm do
    /// <c>corrigeStyles</c> do <c>Correcao.cs</c> do reverso.
    /// </summary>
    public class CorrecaoEstiloTextoTests
    {
        private static EstiloTexto Estilo(string nome, string arquivo, double escala, double altura)
        {
            return new EstiloTexto
            {
                Nome = nome,
                ArquivoFonte = arquivo,
                EscalaX = escala,
                Altura = altura,
            };
        }

        [Fact]
        public void Estilo_sem_fonte_e_problema()
        {
            Assert.True(CorrecaoEstiloTexto.PrecisaCorrigir(Estilo("SEM", "", 1.0, 2.5)));
        }

        [Fact]
        public void Estilo_com_escala_zero_e_problema()
        {
            Assert.True(CorrecaoEstiloTexto.PrecisaCorrigir(Estilo("ZERO", "arial.ttf", 0.0, 2.5)));
        }

        [Fact]
        public void Estilo_com_fonte_e_escala_nao_e_problema()
        {
            Assert.False(CorrecaoEstiloTexto.PrecisaCorrigir(Estilo("OK", "arial.ttf", 1.0, 2.5)));
            Assert.False(CorrecaoEstiloTexto.PrecisaCorrigir(Estilo("OK2", "times.ttf", 0.8, 0.0)));
        }

        [Fact]
        public void Arquivo_nulo_conta_como_vazio()
        {
            Assert.True(CorrecaoEstiloTexto.ArquivoVazio(null));
            Assert.True(CorrecaoEstiloTexto.ArquivoVazio(""));
            Assert.False(CorrecaoEstiloTexto.ArquivoVazio("arial.ttf"));
        }

        [Fact]
        public void Referencia_e_o_primeiro_arial_ttf()
        {
            List<EstiloTexto> estilos = new List<EstiloTexto>
            {
                Estilo("A", "times.ttf", 1.0, 2.5),
                Estilo("ARIAL", "arial.ttf", 1.2, 3.0),
                Estilo("B", "arial.ttf", 1.0, 2.5),
            };

            Assert.Equal(1, CorrecaoEstiloTexto.IndiceDaReferencia(estilos));
        }

        [Fact]
        public void Sem_arial_a_referencia_e_o_ultimo_estilo()
        {
            // Quirk do original: sem `arial.ttf`, `val5` fica no último estilo
            // enumerado e é dele que a fonte sai.
            List<EstiloTexto> estilos = new List<EstiloTexto>
            {
                Estilo("A", "times.ttf", 1.0, 2.5),
                Estilo("B", "txt.shx", 1.0, 2.0),
            };

            Assert.Equal(1, CorrecaoEstiloTexto.IndiceDaReferencia(estilos));
        }

        [Fact]
        public void Sem_estilos_nao_ha_referencia()
        {
            Assert.Equal(-1, CorrecaoEstiloTexto.IndiceDaReferencia(new List<EstiloTexto>()));
        }

        [Fact]
        public void Sem_problema_o_plano_nao_corrige_nada()
        {
            List<EstiloTexto> estilos = new List<EstiloTexto>
            {
                Estilo("A", "arial.ttf", 1.0, 2.5),
                Estilo("B", "times.ttf", 1.0, 1.0),
            };

            PlanoDeEstilos plano = CorrecaoEstiloTexto.Planejar(estilos);

            Assert.Empty(plano.Problemas);
            Assert.Empty(plano.Correcoes);
        }

        [Fact]
        public void Estilo_sem_fonte_copia_fonte_escala_e_altura_da_referencia()
        {
            List<EstiloTexto> estilos = new List<EstiloTexto>
            {
                Estilo("PROBLEMA", "", 0.0, 0.0),
                Estilo("ARIAL", "arial.ttf", 1.5, 2.5),
            };

            PlanoDeEstilos plano = CorrecaoEstiloTexto.Planejar(estilos);

            Assert.Equal(new[] { "PROBLEMA" }, plano.Problemas);
            Assert.True(plano.TemReferenciaArial);
            Assert.Equal(1, plano.IndiceReferencia);

            CorrecaoDeEstilo correcao = Assert.Single(plano.Correcoes);
            Assert.Equal(0, correcao.Indice);
            Assert.True(correcao.CopiarFonte);
            Assert.Equal("arial.ttf", correcao.ArquivoFonte);
            Assert.True(correcao.AjustarEscala);
            Assert.Equal(1.5, correcao.EscalaX);
            Assert.True(correcao.AjustarAltura);
            Assert.Equal(2.5, correcao.Altura);
        }

        [Fact]
        public void Referencia_em_zero_corrigida_primeiro_deixa_os_seguintes_intactos()
        {
            // A referência é um objeto vivo: quando o laço a corrige (escala 0 → 1),
            // os estilos **seguintes** deixam de casar a segunda comparação. Com a
            // referência no índice 0, o estilo com fonte fica como estava.
            List<EstiloTexto> estilos = new List<EstiloTexto>
            {
                Estilo("REF", "arial.ttf", 0.0, 2.5),
                Estilo("FONTE_OK", "times.ttf", 5.0, 1.0),
            };

            PlanoDeEstilos plano = CorrecaoEstiloTexto.Planejar(estilos);

            Assert.Equal(new[] { "REF" }, plano.Problemas);
            CorrecaoDeEstilo correcao = Assert.Single(plano.Correcoes);
            Assert.Equal(0, correcao.Indice);
            Assert.True(correcao.AjustarEscala);
            Assert.Equal(1.0, correcao.EscalaX);
        }

        [Fact]
        public void Referencia_em_zero_no_fim_ainda_corrige_os_anteriores()
        {
            // O oposto do teste acima pela posição da referência: enquanto o laço
            // não chega nela, `val5.XScale` continua 0 e a segunda comparação pega o
            // estilo com fonte que vem antes.
            List<EstiloTexto> estilos = new List<EstiloTexto>
            {
                Estilo("FONTE_OK", "times.ttf", 5.0, 1.0),
                Estilo("REF", "arial.ttf", 0.0, 2.5),
            };

            PlanoDeEstilos plano = CorrecaoEstiloTexto.Planejar(estilos);

            Assert.Equal(2, plano.Correcoes.Count);
            Assert.True(plano.Correcoes[0].AjustarEscala);
            Assert.Equal(1.0, plano.Correcoes[0].EscalaX);
            Assert.False(plano.Correcoes[0].CopiarFonte);
            Assert.Equal(1, plano.Correcoes[1].Indice);
        }

        [Fact]
        public void Estilo_sem_fonte_herda_escala_um_quando_a_referencia_e_zero()
        {
            List<EstiloTexto> estilos = new List<EstiloTexto>
            {
                Estilo("SEM_FONTE", "", 0.0, 3.0),
                Estilo("REF", "arial.ttf", 0.0, 2.5),
            };

            PlanoDeEstilos plano = CorrecaoEstiloTexto.Planejar(estilos);

            // As duas entram na correção: o estilo sem fonte (copia tudo) **e** a
            // própria referência, porque ela está com escala 0.
            Assert.Equal(2, plano.Correcoes.Count);

            CorrecaoDeEstilo correcao = plano.Correcoes[0];
            Assert.True(correcao.CopiarFonte);
            Assert.True(correcao.AjustarEscala);
            Assert.Equal(1.0, correcao.EscalaX);
            Assert.True(correcao.AjustarAltura);
            Assert.Equal(2.5, correcao.Altura);
        }

        [Fact]
        public void Sem_arial_no_desenho_a_referencia_nao_e_arial()
        {
            List<EstiloTexto> estilos = new List<EstiloTexto>
            {
                Estilo("SEM_FONTE", "", 1.0, 1.0),
                Estilo("ULTIMO", "times.ttf", 2.0, 4.0),
            };

            PlanoDeEstilos plano = CorrecaoEstiloTexto.Planejar(estilos);

            Assert.False(plano.TemReferenciaArial);
            Assert.Equal(1, plano.IndiceReferencia);

            CorrecaoDeEstilo correcao = Assert.Single(plano.Correcoes);
            Assert.True(correcao.CopiarFonte);
            Assert.Equal("times.ttf", correcao.ArquivoFonte);
            Assert.True(correcao.AjustarEscala);
            Assert.Equal(2.0, correcao.EscalaX);
            Assert.Equal(4.0, correcao.Altura);
        }

        [Fact]
        public void Problemas_listam_os_nomes_sem_fonte_e_de_escala_zero()
        {
            List<EstiloTexto> estilos = new List<EstiloTexto>
            {
                Estilo("SEM_FONTE", "", 1.0, 1.0),
                Estilo("OK", "arial.ttf", 1.0, 1.0),
                Estilo("ESCALA_ZERO", "times.ttf", 0.0, 1.0),
            };

            PlanoDeEstilos plano = CorrecaoEstiloTexto.Planejar(estilos);

            Assert.Equal(new[] { "SEM_FONTE", "ESCALA_ZERO" }, plano.Problemas);
        }
    }
}
