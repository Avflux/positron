using System;
using System.Collections.Generic;
using Positron.Data;
using Xunit;

namespace Positron.Data.Tests
{
    /// <summary>
    /// <see cref="ProgressoCompartilhado"/> — o <c>pbIniciar</c>/<c>pbPasso</c>/<c>pbFim</c> do
    /// <c>uscPaginas</c> (<c>uscPaginas.cs:1242-1269</c>), a barra que as rotinas longas do original
    /// dirigem por <c>DeclaracoesGeral._uscPagina</c> (rodada 220).
    /// </summary>
    public class ProgressoCompartilhadoTests
    {
        [Fact]
        public void Nasce_com_os_padroes_do_ProgressBar()
        {
            // O designer do original não mexe no ProgressBar1 (`uscPaginas.cs:1203-1208`): valem os
            // padrões do WinForms — 0..100, passo 10, valor 0 — e o estado de fábrica (normal).
            ProgressoCompartilhado barra = new ProgressoCompartilhado();
            Assert.Equal(0, barra.Minimo);
            Assert.Equal(100, barra.Maximo);
            Assert.Equal(10, barra.Incremento);
            Assert.Equal(0, barra.Valor);
            Assert.Equal(CorDaBarra.Verde, barra.Cor);
            Assert.Equal(0, barra.Quantidade);
        }

        [Fact]
        public void Iniciar_fixa_a_faixa_pela_quantidade_e_pinta_de_vermelho()
        {
            ProgressoCompartilhado barra = new ProgressoCompartilhado();
            barra.Quantidade = 6;
            barra.Iniciar();

            Assert.Equal(0, barra.Minimo);
            Assert.Equal(6, barra.Maximo);
            Assert.Equal(1, barra.Incremento);
            Assert.Equal(CorDaBarra.Vermelho, barra.Cor);
            Assert.Equal(0, barra.Valor);
        }

        [Fact]
        public void Quantidade_negativa_vira_zero()
        {
            // O `if (Quantidade < 0) Quantidade = 0;` do `pbIniciar` (`uscPaginas.cs:1250-1253`).
            ProgressoCompartilhado barra = new ProgressoCompartilhado();
            barra.Quantidade = -3;
            barra.Iniciar();

            Assert.Equal(0, barra.Quantidade);
            Assert.Equal(0, barra.Maximo);
        }

        [Fact]
        public void Iniciar_nao_zera_o_valor_e_o_corta_no_maximo()
        {
            // O `pbIniciar` não toca no `Value`: o valor da rodada anterior fica — e o controle o
            // corta quando o novo `Maximum` é menor que ele.
            ProgressoCompartilhado barra = new ProgressoCompartilhado();
            barra.Quantidade = 10;
            barra.Iniciar();
            barra.Passo(4);
            Assert.Equal(4, barra.Valor);

            barra.Quantidade = 10;
            barra.Iniciar();
            Assert.Equal(4, barra.Valor);

            barra.Quantidade = 2;
            barra.Iniciar();
            Assert.Equal(2, barra.Valor);
        }

        [Fact]
        public void Passo_anda_e_satura_no_maximo()
        {
            ProgressoCompartilhado barra = new ProgressoCompartilhado();
            barra.Quantidade = 3;
            barra.Iniciar();

            barra.Passo();
            Assert.Equal(1, barra.Valor);
            barra.Passo();
            barra.Passo();
            Assert.Equal(3, barra.Valor);

            // O `Increment` do controle para no máximo: o passo que sobra não muda nada.
            barra.Passo();
            Assert.Equal(3, barra.Valor);

            // O `iPasso` do `pbPasso(int iPasso = 1)`.
            barra.Passo(1000);
            Assert.Equal(3, barra.Valor);
        }

        [Fact]
        public void Passo_antes_do_iniciar_anda_na_barra_recem_nascida()
        {
            // O `pbPasso()` que o `ExportaPaginas` faz logo depois do `LimpaSheet`
            // (`clsTextos.cs:1064`) vem **antes** do `pbIniciar` da exportação. Numa barra que ainda
            // não foi usada (0..100) ele anda de verdade; depois de um `pbFim` (faixa 0) não faz nada.
            ProgressoCompartilhado barra = new ProgressoCompartilhado();
            barra.Passo();
            Assert.Equal(1, barra.Valor);

            barra.Fim();
            barra.Passo();
            Assert.Equal(0, barra.Valor);
        }

        [Fact]
        public void Fim_zera_valor_e_faixa_mas_deixa_passo_e_cor()
        {
            ProgressoCompartilhado barra = new ProgressoCompartilhado();
            barra.Quantidade = 5;
            barra.Iniciar();
            barra.Passo(3);
            barra.Fim();

            Assert.Equal(0, barra.Valor);
            Assert.Equal(0, barra.Minimo);
            Assert.Equal(0, barra.Maximo);
            Assert.Equal(1, barra.Incremento);
            Assert.Equal(CorDaBarra.Vermelho, barra.Cor);
        }

        [Fact]
        public void Cada_chamada_avisa_quem_espelha_a_barra()
        {
            ProgressoCompartilhado barra = new ProgressoCompartilhado();
            List<string> vistos = new List<string>();
            barra.Mudou += (origem, evento) =>
                vistos.Add(barra.Valor + "/" + barra.Maximo + " " + barra.Cor);
            barra.Quantidade = 2;
            barra.Iniciar();
            barra.Passo();
            barra.Passo();
            barra.Passo();
            barra.Fim();

            Assert.Equal(new[]
            {
                "0/2 Vermelho",
                "1/2 Vermelho",
                "2/2 Vermelho",
                "2/2 Vermelho",
                "0/0 Vermelho",
            }, vistos);
        }

        [Fact]
        public void O_tamanho_da_barra_e_a_sequencia_do_SYNCD()
        {
            // O `SYNCD` do original (`Comandos.cs:288-303`): `Quantidade = 6`, o `pbIniciar`, seis
            // passos e o `pbFim`. A barra termina cheia antes do fim e volta a zero no `pbFim`.
            ProgressoCompartilhado barra = new ProgressoCompartilhado();
            List<int> valores = new List<int>();
            barra.Mudou += (origem, evento) => valores.Add(barra.Valor);
            barra.Quantidade = 6;
            barra.Iniciar();
            for (int i = 0; i < 6; i++)
            {
                barra.Passo();
            }

            barra.Fim();
            Assert.Equal(new[] { 0, 1, 2, 3, 4, 5, 6, 0 }, valores);
        }

        [Fact]
        public void A_exportacao_dos_titulos_usa_o_rowcount_menos_um_e_um_passo_por_linha()
        {
            // O `ExportaPaginas` (`clsTextos.cs:1149-1210`): `Quantidade = dg.RowCount - 1`,
            // `pbIniciar`, um `pbPasso` por linha escrita (são `RowCount` linhas, então o último
            // passo satura) e o `pbFim`.
            ProgressoCompartilhado barra = new ProgressoCompartilhado();
            barra.Quantidade = 14;
            barra.Iniciar();
            for (int i = 0; i < 15; i++)
            {
                barra.Passo();
            }

            Assert.Equal(14, barra.Maximo);
            Assert.Equal(14, barra.Valor);
            barra.Fim();
            Assert.Equal(0, barra.Valor);
            Assert.Equal(0, barra.Maximo);
        }
    }
}
