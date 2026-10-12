using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Positron.Data.Interface.Mapas;
#if AUTOCAD
using Autodesk.Windows;
using Autodesk.AutoCAD.ApplicationServices;
using Document = Autodesk.AutoCAD.ApplicationServices.Document;
#else
using ZwSoft.Windows;
using ZwSoft.ZwCAD.ApplicationServices;
using Document = ZwSoft.ZwCAD.ApplicationServices.Document;
#endif

namespace Positron.Plugin.Interface.Barra
{
    /// <summary>
    /// A **barra de ferramentas** do Positron, montada a partir do **mapa do reverso**
    /// (<see cref="BarraDoReverso"/>) — e não desenhada à mão: os nove painéis saem na ordem do
    /// <c>CreateRibbon()</c>/<c>CreateRibbon2()</c> do original, com o **título** dele (resolvido
    /// pela <c>mMensagem</c>), e cada um dos **121 botões** na ordem do corpo do <c>Ribbon.cs</c>,
    /// com o rótulo, a dica e o **ícone do produto** (a <c>lib/Icons</c>, extraída do DLL).
    ///
    /// O que decide se o botão funciona é o comando: <see cref="BotaoDaBarra.Coberto"/> é "o recoder
    /// responde a esse comando hoje" — e é por isso que a barra agora **chama as janelas** do mapa
    /// das telas (76 dos botões do original abrem uma tela, sem nenhum código novo: o comando já
    /// existe no CAD desde a rodada 128). O botão cujo comando ainda não existe entra **desativado**
    /// e com a dica dizendo isso: a barra do original fica inteira à vista, e o que funciona é o que
    /// está ligado.
    ///
    /// Duas diferenças deliberadas do original, registradas: a aba é <c>POSITRON.ID_Positron</c> e
    /// chama-se **Positron** (o original é <c>CENG.ID_Elet</c>/"Elétron" — o id e o título de lá
    /// ficam no mapa), e os botões pequenos, que no original só mostram o ícone e ficam com o nome
    /// na dica, aqui mostram o texto curto (a nossa barra tem menos botões por painel e o rótulo
    /// ajuda a chamar a janela certa).
    ///
    /// **A mesma construção serve aos dois CADs** (rodada 138): o <c>ZwSoft.Windows</c> do ZWCAD e o
    /// <c>Autodesk.Windows</c> da <c>AdWindows.dll</c> são a mesma API de ribbon, então só o
    /// <c>using</c> muda (os dois <c>RibbonControl</c>/<c>RibbonTab</c>/<c>RibbonButton</c> saem do
    /// <c>using</c> condicional). Duas divergências ficam em <c>#if</c>, medidas no compilador: o
    /// <c>Name</c> do item, que no ZWCAD se chama <c>Id</c> no AutoCAD, e o "desativado", que é
    /// <c>IsActive</c> no ZWCAD e <c>IsEnabled</c> no AutoCAD.
    ///
    /// **Onde ela não existe:** no <c>accoreconsole</c> (o harness headless) não há ribbon nenhum —
    /// o <c>ComponentManager.Ribbon</c> é nulo e o método devolve a linha dizendo isso, sem lançar.
    /// Medido na rodada 138: no AutoCAD de interface cheia a aba é criada no load (a mensagem sai
    /// com os painéis e os botões).
    /// </summary>
    internal static class BarraDeFerramentas
    {
        internal const string IdDaAba = "POSITRON.ID_Positron";

        /// <summary>Os comandos do próprio recoder, que não têm lugar na barra do original.</summary>
        private static readonly string[][] ComandosDoRecoder = new[]
        {
            new[] { "ELET", "Páginas", "Caderno_32" },
            new[] { "FOLHAS", "Folhas", "Caderno_32" },
            new[] { "JANELAS", "Janelas do reverso", "Item" },
            new[] { "JANELA", "Uma janela", "Item" },
            new[] { "VERIF", "Verificador", "Item" },
            new[] { "ELETCFG", "Configuração", "Setup_32" },
            new[] { "pzDiag", "Diagnóstico", "Item" },
            new[] { "pzTelas", "Montar as telas", "Item" },
        };

        /// <summary>Cria (ou recria) a aba e devolve a linha de resumo. Nunca lança.</summary>
        /// <remarks>
        /// No ZWCAD o ribbon já existe quando o plugin carrega; **no AutoCAD, não** — medido na
        /// rodada 138: no load por autoload o `ComponentManager.Ribbon` é **nulo** (o AutoCAD monta o
        /// ribbon depois do carregamento do plugin). Por isso, quando ele ainda não existe, a aba é
        /// agendada para a primeira ociosidade do CAD (<see cref="NaOciosidade"/>), e não se perde.
        /// </remarks>
        internal static string Criar()
        {
            if (ComponentManager.Ribbon == null)
            {
#if AUTOCAD
                AgendarRetentativa();
                return "Barra: o ribbon ainda não existe nesta fase do arranque — a aba entra na "
                    + "primeira ociosidade do CAD (no accoreconsole, que não tem interface, não há ribbon).";
#else
                return "Barra: o CAD não tem ribbon nesta sessão.";
#endif
            }

            return ConstruirAba();
        }

        /// <summary>A montagem da aba (o corpo comum aos dois CADs). Nunca lança.</summary>
        private static string ConstruirAba()
        {
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

                int ativosDoOriginal = 0;
                int desativados = 0;
                int paineis = 0;
                foreach (PainelDaBarra painel in BarraDoReverso.Paineis)
                {
                    RibbonPanelSource fonte = new RibbonPanelSource { Title = painel.Titulo };
                    RibbonPanel quadro = new RibbonPanel { Source = fonte };
                    aba.Panels.Add(quadro);
                    paineis++;

                    foreach (BotaoDaBarra botao in painel.Botoes)
                    {
                        fonte.Items.Add(Botao(botao, ref ativosDoOriginal, ref desativados));
                    }
                }

                // Os comandos que são nossos e não existem na barra do original (a paleta das
                // folhas, o seletor das 127 telas, o verificador) num painel no fim, para não
                // ficarem sem porta de entrada.
                RibbonPanelSource nossa = new RibbonPanelSource { Title = "Positron" };
                RibbonPanel quadroNossa = new RibbonPanel { Source = nossa };
                aba.Panels.Add(quadroNossa);
                paineis++;
                foreach (string[] comando in ComandosDoRecoder)
                {
                    nossa.Items.Add(DoRecoder(comando));
                }

                return "Barra: aba \"" + aba.Title + "\" com " + paineis + " painel(is) — "
                    + BarraDoReverso.Quantidade + " botão(ões) do original ("
                    + ativosDoOriginal + " ligado(s), " + desativados + " desativado(s); "
                    + BarraDoReverso.QuantosAbremJanela() + " abrem uma janela) e "
                    + ComandosDoRecoder.Length + " do recoder.";
            }
            catch (Exception erro)
            {
                return "Barra: falhou — " + erro.Message + ".";
            }
        }

#if AUTOCAD
        /// <summary>A tentativa em curso (0 = nenhuma agendada).</summary>
        private static int _tentativas;

        /// <summary>
        /// O AutoCAD cria o ribbon **depois** de carregar o plugin, então a aba espera a primeira
        /// ociosidade (10 tentativas bastam: o `Idle` dispara muitas vezes no arranque). No
        /// accoreconsole o evento não chega a disparar e nada fica pendurado.
        /// </summary>
        private static void AgendarRetentativa()
        {
            if (_tentativas > 0)
            {
                return;
            }

            _tentativas = 1;
            Application.Idle += NaOciosidade;
        }

        private static void NaOciosidade(object remetente, EventArgs argumentos)
        {
            if (ComponentManager.Ribbon == null && _tentativas < 10)
            {
                _tentativas++;
                return;
            }

            Application.Idle -= NaOciosidade;
            Plugin.Escrever(ConstruirAba());
        }
#endif

        /// <summary>
        /// Um botão do original. Com o comando que o recoder responde ele manda o
        /// <c>CommandParameter</c> para a linha de comando (como o <c>AdskCommandHandler</c> do
        /// reverso); sem ele, o botão entra **desativado** e a dica diz o porquê.
        /// </summary>
        private static RibbonButton Botao(BotaoDaBarra botao, ref int ativos, ref int desativados)
        {
            BitmapImage imagem = string.IsNullOrEmpty(botao.Icone) ? null : IconesEmbutidos.Imagem(botao.Icone);
            string dica = string.IsNullOrEmpty(botao.Dica) ? botao.Rotulo : botao.Dica;

            RibbonButton item = new RibbonButton
            {
#if AUTOCAD
                Id = "POSITRON_" + botao.Comando,
#else
                Name = "POSITRON_" + botao.Comando,
#endif
                Text = botao.Rotulo,
                ShowText = true,
                ShowImage = imagem != null,
                Image = imagem,
                LargeImage = imagem,
            };

            if (botao.Utilizavel)
            {
                item.CommandParameter = botao.Comando + " ";
                item.CommandHandler = new ComandoDoBotao();
                item.ToolTip = dica + (botao.AbreJanela ? " (abre a janela do original)" : string.Empty);
                ativos++;
                return item;
            }

            // Como o original faz com o banner da versão: o item fica na barra, inativo.
#if AUTOCAD
            item.IsEnabled = false;
#else
            item.IsActive = false;
#endif
            item.ToolTip = dica + " — ainda não portado no Positron (o comando " + botao.Comando + " não existe aqui).";
            desativados++;
            return item;
        }

        /// <summary>Um botão dos comandos do recoder.</summary>
        private static RibbonButton DoRecoder(string[] comando)
        {
            BitmapImage imagem = IconesEmbutidos.Imagem(comando[2]);
            return new RibbonButton
            {
#if AUTOCAD
                Id = "POSITRON_" + comando[0],
#else
                Name = "POSITRON_" + comando[0],
#endif
                Text = comando[1],
                ShowText = true,
                ShowImage = imagem != null,
                Image = imagem,
                LargeImage = imagem,
                ToolTip = comando[1] + " (" + comando[0] + ")",
                CommandParameter = comando[0] + " ",
                CommandHandler = new ComandoDoBotao(),
            };
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
    }
}
