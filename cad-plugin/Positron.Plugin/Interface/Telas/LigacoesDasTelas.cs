using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Positron.Data.Interface.Mapas;

namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// O **registro das ligações** das telas: para as janelas cuja **regra já está portada**, liga os
    /// controles do designer (que o <see cref="RenderizadorDeTelas"/> reconstrói fielmente) à regra
    /// pura do <c>Positron.Data</c>. É a "casca fina" da regra de ouro do §7.7 do plano.
    ///
    /// A lista é **explícita e curta de propósito**: integrar o método de uma tela é (1) criar o
    /// arquivo dela ao lado dos outros (<see cref="ILigacaoDeTela"/>, olhando o
    /// <see cref="LigacaoDoFrmPesquisaXdatas"/> como molde na primeira vez) e (2) acrescentar
    /// **uma linha** na lista abaixo. Nada mais — as telas ligadas não são tocadas.
    ///
    /// As telas que **não** estão aqui abrem com a casca fiel e sem comportamento: o que a rodada
    /// entrega é a formatação, e cada ligação entra quando a regra dela existe.
    ///
    /// Duas diferenças deliberadas em relação ao original, as duas para não travar:
    ///
    /// - onde o original mostra um `MsgBox` de confirmação/resultado (o "N xData apagados"), o
    ///   recoder **escreve na linha de comando** — um `MsgBox` num script não tem quem o feche;
    /// - onde o original lê o banco para montar a tela, aqui entra a **regra do recoder** (a mesma
    ///   que o comando equivalente já usa e que já foi medida no desenho real).
    /// </summary>
    internal static class LigacoesDasTelas
    {
        private static readonly ILigacaoDeTela[] Todas = new ILigacaoDeTela[]
        {
            new LigacaoDoFrmPesquisaXdatas(),
            new LigacaoDoFrmEstatisticaDeBornes(),
            new LigacaoDoFrmCompilarFiacao(),
            new LigacaoDoFrmCompilarInterligacao(),
            new LigacaoDoFrmCompilarJumperExt(),
            new LigacaoDoFrmGerenciadorMateriais(),
            new LigacaoDoFrmGerenciadorMatIndep(),
        };

        /// <summary>As telas ligadas hoje (para o diagnóstico e os testes não lerem a lista).</summary>
        internal static IReadOnlyList<ILigacaoDeTela> Ligadas
        {
            get { return Todas; }
        }

        /// <summary>Liga uma tela pelo nome, quando há ligação. Nunca lança.</summary>
        internal static void Preencher(Form janela, Tela tela)
        {
            if (janela == null || tela == null)
            {
                return;
            }

            foreach (ILigacaoDeTela ligacao in Todas)
            {
                if (!string.Equals(ligacao.NomeDaTela, tela.Nome, StringComparison.Ordinal))
                {
                    continue;
                }

                try
                {
                    ligacao.Preencher(janela);
                }
                catch (Exception erro)
                {
                    Plugin.Escrever("LIGACAO: \"" + tela.Nome + "\" falhou — " + erro.Message + ".");
                }

                return;
            }
        }

        /// <summary>Os nomes das telas ligadas, para o resumo do diagnóstico.</summary>
        internal static string Nomes()
        {
            List<string> nomes = new List<string>();
            foreach (ILigacaoDeTela ligacao in Todas)
            {
                nomes.Add(ligacao.NomeDaTela);
            }

            return string.Join(", ", nomes.ToArray());
        }
    }
}
