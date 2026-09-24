using System;

#if !AUTOCAD
using System.Windows.Input;
using ZwSoft.Windows;
using ZwSoft.ZwCAD.ApplicationServices;
#endif

namespace Positron.Plugin.Interface
{
    /// <summary>
    /// A **barra de ferramentas** do Positron — a fatia 4 da frente 11, no mesmo desenho do
    /// <c>Ribbon.cs</c> do reverso: uma aba (<c>POSITRON.ID_Positron</c>) com painéis de botões,
    /// cada botão com o <c>CommandParameter</c> = o comando a executar e um <c>ICommand</c> que o
    /// manda para a linha de comando do CAD.
    ///
    /// Só existe no ZWCAD (o <c>ZdWindows</c> é a API de interface); no build AutoCAD o método
    /// devolve a linha informando isso — o build de AutoCAD é o gate de compilação do stub.
    /// </summary>
    internal static class BarraDeFerramentas
    {
        internal const string IdDaAba = "POSITRON.ID_Positron";

        /// <summary>Cria (ou recria) a aba e devolve a linha de resumo. Nunca lança.</summary>
        internal static string Criar()
        {
#if AUTOCAD
            return "Barra: disponível apenas no build ZWCAD (o ZdWindows é a API de interface).";
#else
            try
            {
                RibbonControl ribbon = ComponentManager.Ribbon;
                if (ribbon == null)
                {
                    return "Barra: o CAD não tem ribbon nesta sessão.";
                }

                for (int i = ribbon.Tabs.Count - 1; i >= 0; i--)
                {
                    if (string.Equals(ribbon.Tabs[i].Id, IdDaAba, StringComparison.OrdinalIgnoreCase))
                    {
                        ribbon.Tabs.RemoveAt(i);
                    }
                }

                RibbonTab aba = new RibbonTab
                {
                    Id = IdDaAba,
                    Title = "Positron",
                };
                ribbon.Tabs.Add(aba);

                // Os painéis usam os **títulos do original** (mMensagem 109..112, 540, 559, 560,
                // 1549) e cada botão traz o comando que temos; os rótulos são os do reverso onde
                // o comando existe na barra dele (`CBD`, `RESTPROJ`).
                int botoes = 0;
                botoes += Painel(aba, Positron.Data.Interface.MensagensDoReverso.PainelCaderno, new[]
                {
                    new[] { "ELET", "ELET" },
                    new[] { "FOLHAS", "FOLHAS" },
                });
                botoes += Painel(aba, Positron.Data.Interface.MensagensDoReverso.PainelFiacao, new[]
                {
                    new[] { "FIA", "FIA" },
                    new[] { "SYNCD", "SYNCD" },
                });
                botoes += Painel(aba, Positron.Data.Interface.MensagensDoReverso.PainelCabosEVeias, new[]
                {
                    new[] { "INT", "INT" },
                    new[] { "SYNCV", "SYNCV" },
                    new[] { "RECRIACABOS", "RECRIACABOS" },
                    new[] { "RESTPROJ", Positron.Data.Interface.MensagensDoReverso.BotaoRestProj },
                    new[] { "CBD", Positron.Data.Interface.MensagensDoReverso.BotaoCbd },
                });
                botoes += Painel(aba, Positron.Data.Interface.MensagensDoReverso.PainelBornes, new[]
                {
                    new[] { "STATBORN", "STATBORN" },
                });
                botoes += Painel(aba, Positron.Data.Interface.MensagensDoReverso.PainelUtilitarios, new[]
                {
                    new[] { "VERIF", "VERIF" },
                    new[] { "pzDiag", "pzDiag" },
                });

                return "Barra: aba \"" + aba.Title + "\" com " + botoes + " botão(ões).";
            }
            catch (Exception erro)
            {
                return "Barra: falhou — " + erro.Message + ".";
            }
#endif
        }

#if !AUTOCAD
        /// <summary>Um painel com os botões (rótulo, comando) e o seu handler.</summary>
        private static int Painel(RibbonTab aba, string titulo, string[][] botoes)
        {
            RibbonPanelSource fonte = new RibbonPanelSource { Title = titulo };
            RibbonPanel painel = new RibbonPanel { Source = fonte };
            aba.Panels.Add(painel);

            foreach (string[] botao in botoes)
            {
                RibbonButton item = new RibbonButton
                {
                    Text = botao[1],
                    Name = "POSITRON_" + botao[0],
                    ShowText = true,
                    ShowImage = false,
                    CommandParameter = botao[0] + " ",
                    CommandHandler = new ComandoDoBotao(),
                };
                fonte.Items.Add(item);
            }

            return botoes.Length;
        }

        /// <summary>
        /// O <c>AdskCommandHandler</c> do reverso: o <c>ICommand</c> do botão manda o
        /// <c>CommandParameter</c> para a linha de comando do CAD.
        /// </summary>
        private sealed class ComandoDoBotao : ICommand
        {
            public event EventHandler CanExecuteChanged
            {
                add { }
                remove { }
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                RibbonButton botao = parameter as RibbonButton;
                string comando = botao == null ? null : botao.CommandParameter as string;
                if (string.IsNullOrEmpty(comando))
                {
                    return;
                }

                Document documento = Application.DocumentManager.MdiActiveDocument;
                if (documento == null)
                {
                    return;
                }

                documento.SendStringToExecute(comando, true, false, false);
            }
        }
#endif
    }
}
