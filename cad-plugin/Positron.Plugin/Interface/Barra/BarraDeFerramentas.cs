using System;
using System.Collections.Generic;
using System.Windows.Controls;
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
    /// (<see cref="BarraDoReverso"/>) — e não desenhada à mão: os nove painéis na ordem do
    /// <c>CreateRibbon()</c>/<c>CreateRibbon2()</c> do original e, em cada um, a **árvore** que o
    /// <c>Ribbon.cs</c> monta (rodada 147): as linhas com as quebras, a área recolhível, os
    /// separadores, os menus suspensos, a lista de seção, o campo da cor, o liga/desliga e o botão do
    /// canto — cada item com o **estilo do ajudante** que o configura no original (grande com texto,
    /// ícone grande, ícone 16 com texto, só o ícone 16) e o ícone do **tema** do CAD.
    ///
    /// O que decide se o item funciona é o comando: <see cref="ItemDaBarra.Utilizavel"/> é "o recoder
    /// responde a esse comando hoje". O item cujo comando ainda não existe entra **desativado** e com
    /// a dica dizendo isso: a barra do original fica inteira à vista, e o que funciona é o que está
    /// ligado. Três botões do original têm, no recoder, um comando **próprio** que faz o trabalho —
    /// e o comando com o nome de lá só abre a casca da tela: eles chamam o nosso
    /// (<see cref="ComandoNoRecoder"/>). Foi isso que tirou da barra o painel extra "Positron" que
    /// repetia esses comandos (rodada 147).
    ///
    /// Diferença deliberada do original, registrada: a aba é <c>POSITRON.ID_Positron</c> e chama-se
    /// **Positron** (o original é <c>CENG.ID_Elet</c>/"Elétron" — o id e o título de lá ficam no
    /// mapa), e o banner do painel Configuração diz "Positron" (no original, a versão e o hardlock).
    ///
    /// **A mesma construção serve aos dois CADs** (rodada 138): o <c>ZwSoft.Windows</c> do ZWCAD e o
    /// <c>Autodesk.Windows</c> da <c>AdWindows.dll</c> são a mesma API de ribbon, então só o
    /// <c>using</c> muda. Duas divergências ficam em <c>#if</c>: o <c>Name</c> do item, que no ZWCAD
    /// se chama <c>Id</c> no AutoCAD, e o "desativado": o <c>IsEnabled</c> serve aos dois (está no
    /// <c>RibbonItem</c>, inclusive na lista e no campo), e no ZWCAD o item de comando também leva o
    /// <c>IsActive = false</c> que o original usa lá.
    ///
    /// **Onde ela não existe:** no <c>accoreconsole</c> (o harness headless) não há ribbon nenhum —
    /// o <c>ComponentManager.Ribbon</c> é nulo e o método devolve a linha dizendo isso, sem lançar.
    /// </summary>
    internal static class BarraDeFerramentas
    {
        internal const string IdDaAba = "POSITRON.ID_Positron";

        internal const string TituloDaAba = "Positron";

        /// <summary>
        /// Os botões do original cujo trabalho, no recoder, é de um comando **nosso**: o comando com
        /// o nome de lá existe, mas só abre a casca da tela (gerado na rodada 128).
        /// </summary>
        private static readonly Dictionary<string, string> Substitutos =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "CFG", "ELETCFG" },
                { "VFIA", "VERIF" },
                { "VINT", "VERIF" },
            };

        /// <summary>O comando que o item chama no recoder: o substituto, quando há, ou o do original.</summary>
        internal static string ComandoNoRecoder(string comandoDoOriginal)
        {
            string nosso;
            return Substitutos.TryGetValue(comandoDoOriginal ?? string.Empty, out nosso) ? nosso : comandoDoOriginal;
        }

        /// <summary>O que foi montado, por tipo — a linha do log e a medição contra o mapa.</summary>
        private sealed class Contagem
        {
            internal readonly Dictionary<TipoDoItemDaBarra, int> PorTipo = new Dictionary<TipoDoItemDaBarra, int>();
            internal int Ligados;
            internal int Desativados;
            internal int Substituidos;

            internal void Somar(TipoDoItemDaBarra tipo)
            {
                int atual;
                PorTipo.TryGetValue(tipo, out atual);
                PorTipo[tipo] = atual + 1;
            }

            internal int De(TipoDoItemDaBarra tipo)
            {
                int atual;
                return PorTipo.TryGetValue(tipo, out atual) ? atual : 0;
            }
        }

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

        /// <summary>
        /// **Desmonta a aba** — o par do <see cref="Criar"/>, chamado pelo <c>Plugin.Terminate()</c>
        /// quando o CAD descarrega o plugin. Nunca lança.
        /// </summary>
        /// <remarks>
        /// Existe por um defeito medido (rodada 160): o <c>Terminate()</c> estava **vazio**, então a
        /// aba ficava no ribbon depois do descarregamento — e, no AutoCAD, a **retentativa agendada**
        /// na ociosidade (ver <see cref="NaOciosidade"/>) ainda podia recriá-la *depois* do unload,
        /// porque ela nunca era cancelada. Aqui a aba sai **e** a retentativa é cancelada, senão a
        /// remoção não dura.
        /// </remarks>
        internal static string Remover()
        {
#if AUTOCAD
            CancelarRetentativa();
#endif
            try
            {
                RibbonControl ribbon = ComponentManager.Ribbon;
                if (ribbon == null)
                {
                    return "Barra: o CAD não tem ribbon nesta sessão — nada a desmontar.";
                }

                int paineis;
                int removidas = LimparAbas(ribbon, out paineis);
                return removidas == 0
                    ? "Barra: a aba \"" + TituloDaAba + "\" não estava no ribbon."
                    : "Barra: aba \"" + TituloDaAba + "\" desmontada — " + removidas
                        + " aba(s), " + paineis + " painel(is).";
            }
            catch (Exception erro)
            {
                return "Barra: falhou ao desmontar — " + erro.Message + ".";
            }
        }

        /// <summary>
        /// Tira do ribbon as abas do Positron e conta o que saiu — o <paramref name="paineis"/> é a
        /// evidência de que a aba removida era a montada de verdade (a do mapa tem **9** painéis), e
        /// não uma casca deixada para trás por uma versão antiga.
        /// </summary>
        private static int LimparAbas(RibbonControl ribbon, out int paineis)
        {
            paineis = 0;
            int removidas = 0;
            for (int i = ribbon.Tabs.Count - 1; i >= 0; i--)
            {
                RibbonTab aba = ribbon.Tabs[i];
                if (!string.Equals(aba.Id, IdDaAba, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                paineis += aba.Panels.Count;
                ribbon.Tabs.RemoveAt(i);
                removidas++;
            }

            return removidas;
        }

        /// <summary>
        /// O bloco do <c>IniciarDWG</c> que liga/desliga os **painéis** pelo **tipo do desenho**
        /// (<c>Iniciar.cs:72-127</c>) — a regra é pura (<see cref="LigacaoDosPaineis"/>). Devolve a
        /// linha do log, ou <c>null</c> quando o CAD não tem ribbon nesta sessão (o
        /// <c>accoreconsole</c>): não há painel nenhum para ligar, e o original nem chega aqui (ele só
        /// roda no CAD de janela). Nunca lança.
        /// </summary>
        internal static string AplicarTipoDoDesenho(string tipo)
        {
            try
            {
                RibbonControl ribbon = ComponentManager.Ribbon;
                if (ribbon == null)
                {
                    return null;
                }

                RibbonTab aba = AcharAba(ribbon);
                if (aba == null)
                {
                    return "Barra: a aba \"" + TituloDaAba + "\" não está no ribbon — o tipo \"" + tipo
                        + "\" não foi aplicado aos painéis.";
                }

                IReadOnlyList<bool?> plano = LigacaoDosPaineis.Plano(tipo, aba.Panels.Count);
                List<string> ligados = new List<string>();
                List<string> desligados = new List<string>();
                List<string> intocados = new List<string>();
                for (int i = 0; i < aba.Panels.Count && i < plano.Count; i++)
                {
                    RibbonPanel painel = aba.Panels[i];
                    string nome = painel.Source == null ? "#" + i : painel.Source.Title;
                    if (plano[i] == null)
                    {
                        // O último painel no tipo V: o original não toca (`IsEnabled` fica como está).
                        intocados.Add(nome + " (" + (painel.IsEnabled ? "ligado" : "desligado") + ")");
                        continue;
                    }

                    painel.IsEnabled = plano[i].Value;
                    if (plano[i].Value)
                    {
                        ligados.Add(nome);
                    }
                    else
                    {
                        desligados.Add(nome);
                    }
                }

                return "Barra: desenho tipo \"" + tipo + "\" — " + ligados.Count + " painel(is) ligado(s)"
                    + Lista(ligados) + ", " + desligados.Count + " desligado(s)" + Lista(desligados)
                    + ", " + intocados.Count + " intocado(s)" + Lista(intocados) + ".";
            }
            catch (Exception erro)
            {
                return "Barra: falhou ao aplicar o tipo \"" + tipo + "\" — " + erro.Message + ".";
            }
        }

        /// <summary>
        /// O tipo do **desenho ativo** aplicado aos painéis, para a linha de resumo — <c>null</c> quando
        /// não há desenho ativo (o par do <see cref="AplicarTipoDoDesenho"/> chamado pela montagem da
        /// aba, no caminho da ociosidade do AutoCAD).
        /// </summary>
        internal static string AplicarTipoDoDesenhoDoDesenhoAtivo()
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            return documento == null ? null : AplicarTipoDoDesenho(InicioDoDesenho.TipoDoDesenho(documento));
        }

        /// <summary>Os nomes entre parênteses, para a linha de resumo (vazio quando não há nenhum).</summary>
        private static string Lista(List<string> nomes)
        {
            return nomes.Count == 0 ? string.Empty : " [" + string.Join(" | ", nomes.ToArray()) + "]";
        }

        /// <summary>A aba do Positron no ribbon, ou <c>null</c> quando não está lá.</summary>
        private static RibbonTab AcharAba(RibbonControl ribbon)
        {
            foreach (RibbonTab candidata in ribbon.Tabs)
            {
                if (string.Equals(candidata.Id, IdDaAba, StringComparison.OrdinalIgnoreCase))
                {
                    return candidata;
                }
            }

            return null;
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

                // Uma aba do Positron que ainda esteja no ribbon é de **outra** carga (build antigo do
                // pacote, tipicamente): sai antes, e o log denuncia a sobra em vez de deixar duas.
                int paineisDaSobra;
                int sobra = LimparAbas(ribbon, out paineisDaSobra);
                string nota = sobra == 0
                    ? string.Empty
                    : " [substituiu " + sobra + " aba(s) do Positron que já estavam no ribbon, com "
                        + paineisDaSobra + " painel(is) — build anterior no ar?]";

                RibbonTab aba = new RibbonTab
                {
                    Id = IdDaAba,
                    Title = TituloDaAba,
                };
                ribbon.Tabs.Add(aba);

                bool escuro = TemaEscuro();
                Contagem conta = new Contagem();
                int paineis = 0;
                foreach (PainelDaBarra painel in BarraDoReverso.Paineis)
                {
                    RibbonPanelSource fonte = new RibbonPanelSource { Title = painel.Titulo };
                    aba.Panels.Add(new RibbonPanel { Source = fonte });
                    paineis++;

                    foreach (ItemDaBarra item in painel.Itens)
                    {
                        fonte.Items.Add(Construir(item, escuro, conta));
                    }

                    if (painel.Lancador != null)
                    {
                        fonte.DialogLauncher = (RibbonCommandItem)Construir(painel.Lancador, escuro, conta);
                    }
                }

                // Como o original (`val.IsActive = true` no CreateRibbon): a aba abre à frente.
                aba.IsActive = true;

                // O tipo do desenho **de agora**: no ZWCAD a aba já existe quando o `IniciarDWG` roda,
                // mas no AutoCAD ela nasce na primeira ociosidade — depois dele (rodada 138). Sem
                // reaplicar aqui, a aba nasceria com os nove painéis ligados num desenho que não é do
                // Elétron (medido na rodada 181).
                string aplicacao = AplicarTipoDoDesenhoDoDesenhoAtivo();

                return "Barra: aba \"" + aba.Title + "\" com " + paineis + " painel(is) — " + nota
                    + conta.De(TipoDoItemDaBarra.Botao) + " botão(ões), "
                    + conta.De(TipoDoItemDaBarra.Menu) + " menu(s) com " + conta.De(TipoDoItemDaBarra.ItemDeMenu) + " item(ns), "
                    + conta.De(TipoDoItemDaBarra.Alternar) + " liga/desliga, "
                    + conta.De(TipoDoItemDaBarra.ListaDeSecao) + " lista e " + conta.De(TipoDoItemDaBarra.CampoDeCor) + " campo; "
                    + conta.De(TipoDoItemDaBarra.Linha) + " linha(s), " + conta.De(TipoDoItemDaBarra.QuebraDeLinha) + " quebra(s), "
                    + conta.De(TipoDoItemDaBarra.Recolhe) + " área(s) recolhível(is), " + conta.De(TipoDoItemDaBarra.Separador) + " separador(es). "
                    + "Acionáveis: " + conta.Ligados + " ligado(s) (" + conta.Substituidos + " no comando do recoder), "
                    + conta.Desativados + " desativado(s); tema " + (escuro ? "escuro" : "claro") + "."
                    + (string.IsNullOrEmpty(aplicacao) ? string.Empty : " " + aplicacao);
            }
            catch (Exception erro)
            {
                return "Barra: falhou — " + erro.Message + ".";
            }
        }

        /// <summary>
        /// O instrumento do <c>pzBarra</c>: percorre a aba no <c>ComponentManager.Ribbon</c> (o que o
        /// CAD tem de fato) e conta por classe — painéis, cada classe de item, os desativados e o
        /// botão do canto. Nunca lança.
        /// </summary>
        internal static string Inspecionar()
        {
            try
            {
                RibbonControl ribbon = ComponentManager.Ribbon;
                if (ribbon == null)
                {
                    return "pzBarra: o CAD não tem ribbon nesta sessão.";
                }

                RibbonTab aba = null;
                int abasPositron = 0;
                foreach (RibbonTab candidata in ribbon.Tabs)
                {
                    if (string.Equals(candidata.Id, IdDaAba, StringComparison.OrdinalIgnoreCase))
                    {
                        aba = candidata;
                        abasPositron++;
                    }
                }

                if (aba == null)
                {
                    return "pzBarra: a aba " + IdDaAba + " não está no ribbon.";
                }

                SortedDictionary<string, int> porClasse = new SortedDictionary<string, int>(StringComparer.Ordinal);
                int desativados = 0;
                int lancadores = 0;
                List<string> titulos = new List<string>();
                foreach (RibbonPanel painel in aba.Panels)
                {
                    // O estado do painel saiu do `IniciarDWG` (o tipo do desenho, rodada 181): ele entra
                    // na medição porque é o que o tipo muda na barra viva.
                    titulos.Add(painel.Source.Title + (painel.IsEnabled ? " ligado" : " DESLIGADO"));
                    if (painel.Source.DialogLauncher != null)
                    {
                        lancadores++;
                    }

                    foreach (RibbonItem item in painel.Source.Items)
                    {
                        ContarVivo(item, porClasse, ref desativados);
                    }
                }

                List<string> partes = new List<string>();
                foreach (KeyValuePair<string, int> par in porClasse)
                {
                    partes.Add(par.Key + "=" + par.Value);
                }

                return "pzBarra: " + abasPositron + " aba(s) " + IdDaAba + " (\"" + aba.Title + "\"), "
                    + aba.Panels.Count + " painel(is) [" + string.Join(" | ", titulos.ToArray()) + "]; "
                    + string.Join(", ", partes.ToArray()) + "; " + lancadores + " botão(ões) de canto; "
                    + desativados + " item(ns) desativado(s); " + TipoDoDesenho() + ".";
            }
            catch (Exception erro)
            {
                return "pzBarra: falhou — " + erro.Message + ".";
            }
        }

        /// <summary>O tipo do desenho ativo (o `verificaTipoXData`) — a causa do estado dos painéis.</summary>
        private static string TipoDoDesenho()
        {
            try
            {
                Document documento = Application.DocumentManager.MdiActiveDocument;
                return documento == null
                    ? "sem desenho ativo"
                    : "desenho tipo \"" + InicioDoDesenho.TipoDoDesenho(documento) + "\"";
            }
            catch (Exception)
            {
                return "tipo do desenho ilegível";
            }
        }

        private static void ContarVivo(RibbonItem item, SortedDictionary<string, int> porClasse, ref int desativados)
        {
            string classe = item.GetType().Name;
            int atual;
            porClasse.TryGetValue(classe, out atual);
            porClasse[classe] = atual + 1;
            if (!item.IsEnabled)
            {
                desativados++;
            }

            RibbonRowPanel linha = item as RibbonRowPanel;
            if (linha != null)
            {
                foreach (RibbonItem filho in linha.Items)
                {
                    ContarVivo(filho, porClasse, ref desativados);
                }
            }

            RibbonMenuButton menu = item as RibbonMenuButton;
            if (menu != null)
            {
                foreach (RibbonItem filho in menu.Items)
                {
                    ContarVivo(filho, porClasse, ref desativados);
                }
            }
        }

        /// <summary>Um item do mapa, com a subárvore, já no tipo do ribbon do CAD.</summary>
        private static RibbonItem Construir(ItemDaBarra item, bool escuro, Contagem conta)
        {
            conta.Somar(item.Tipo);
            switch (item.Tipo)
            {
                case TipoDoItemDaBarra.Linha:
                    RibbonRowPanel linha = new RibbonRowPanel();
                    foreach (ItemDaBarra filho in item.Filhos)
                    {
                        linha.Items.Add(Construir(filho, escuro, conta));
                    }

                    return linha;

                case TipoDoItemDaBarra.QuebraDeLinha:
                    return new RibbonRowBreak();

                case TipoDoItemDaBarra.Recolhe:
                    return new RibbonPanelBreak();

                case TipoDoItemDaBarra.Separador:
                    RibbonSeparator separador = new RibbonSeparator();
                    if (item.Largura > 0)
                    {
                        // Os separadores com largura são os declarados no original, todos com o
                        // `SeparatorStyle = 1` (o espaço, sem a linha).
                        separador.Width = item.Largura;
                        separador.SeparatorStyle = (RibbonSeparatorStyle)1;
                    }

                    return separador;

                case TipoDoItemDaBarra.ListaDeSecao:
                    RibbonCombo lista = new RibbonCombo
                    {
                        MinWidth = 15,
                        Width = item.Largura,
                        ShowText = false,
                    };
                    return Desativar(lista, "Seção ativa da fiação — ainda não portado no Positron (o original lia a "
                        + "BitolaCollection e gravava a seção que o INSM/CON usam).", conta, false);

                case TipoDoItemDaBarra.CampoDeCor:
                    RibbonTextBox campo = new RibbonTextBox
                    {
                        MinWidth = 15,
                        Width = item.Largura,
                    };
                    return Desativar(campo, "Cor ativa da fiação — ainda não portado no Positron (o original gravava "
                        + "a cor que o INSM/CON usam).", conta, false);

                case TipoDoItemDaBarra.Menu:
                    RibbonMenuButton menu = new RibbonMenuButton
                    {
                        Text = string.Empty,
                        ShowText = false,
                        ShowImage = true,
                        Image = Imagem(item, escuro),
                        MinWidth = 15,
                        Width = item.Largura > 0 ? item.Largura : 40,
                        ToolTip = item.Dica,
                    };
                    bool algumLigado = false;
                    foreach (ItemDaBarra filho in item.Filhos)
                    {
                        RibbonItem construido = Construir(filho, escuro, conta);
                        menu.Items.Add(construido);
                        algumLigado |= filho.Utilizavel;
                    }

                    return algumLigado ? (RibbonItem)menu : Desativar(menu, item.Dica + " — nenhum item portado no Positron.", conta, false);

                case TipoDoItemDaBarra.ItemDeMenu:
                    RibbonMenuItem itemDeMenu = new RibbonMenuItem
                    {
                        Text = item.Rotulo,
                        ShowText = true,
                        ShowImage = true,
                        Image = Imagem(item, escuro),
                    };
                    return Ligar(itemDeMenu, item, conta, true);

                case TipoDoItemDaBarra.Alternar:
                    RibbonToggleButton alternar = new RibbonToggleButton
                    {
                        Size = RibbonItemSize.Large,
                        LargeImage = Imagem(item, escuro),
                        ShowText = false,
                        ShowImage = true,
                        Orientation = Orientation.Horizontal,
                        Text = string.Empty,
                    };
                    return Ligar(alternar, item, conta, false);

                default:
                    return Ligar(Botao(item, escuro), item, conta, false);
            }
        }

        /// <summary>O botão com o estilo do ajudante que o configura no original.</summary>
        private static RibbonButton Botao(ItemDaBarra item, bool escuro)
        {
            BitmapImage imagem = Imagem(item, escuro);
            RibbonButton botao = new RibbonButton { ShowImage = imagem != null };
            switch (item.Grau)
            {
                case "Grande":
                    // O `Nowp1LGUQxQ`: ícone grande, texto embaixo. O único é o banner da versão.
                    botao.Text = item.TemComando ? item.Rotulo : "Positron";
                    botao.ShowText = true;
                    botao.LargeImage = imagem;
                    botao.Size = RibbonItemSize.Large;
                    botao.Orientation = Orientation.Vertical;
                    break;

                case "IconeGrande":
                    // O `IsVp1wK9F5x`: ícone grande sem texto (o nome vai na dica).
                    botao.Text = item.Rotulo;
                    botao.ShowText = false;
                    botao.LargeImage = imagem;
                    botao.Size = RibbonItemSize.Large;
                    botao.Orientation = Orientation.Horizontal;
                    break;

                case "IconeTexto":
                    // O `PVGp1btLkXV`: ícone 16 com o texto ao lado.
                    botao.Text = item.Rotulo;
                    botao.ShowText = true;
                    botao.Image = imagem;
                    botao.Height = 16;
                    botao.Size = RibbonItemSize.Standard;
                    botao.Orientation = Orientation.Horizontal;
                    break;

                case "Icone":
                    // O `UCHp1xnMtMs`: só o ícone 16x16.
                    botao.ShowText = false;
                    botao.Image = imagem;
                    botao.Width = 16;
                    botao.Height = 16;
                    break;

                default:
                    // O botão do canto (`Dialogo`): o CAD desenha a setinha.
                    botao.Text = item.Rotulo;
                    botao.ShowText = true;
                    botao.ShowImage = true;
                    break;
            }

#if AUTOCAD
            botao.Id = "POSITRON_" + item.Comando;
#else
            botao.Name = "POSITRON_" + item.Comando;
#endif
            return botao;
        }

        /// <summary>Liga o item ao comando do recoder, ou o desativa com o motivo na dica.</summary>
        private static RibbonItem Ligar(RibbonCommandItem alvo, ItemDaBarra item, Contagem conta, bool cancelarAntes)
        {
            string dica = string.IsNullOrEmpty(item.Dica) ? item.Rotulo : item.Dica;
            if (item.Desativado)
            {
                // O banner da versão: o original o cria inativo.
                return Desativar(alvo, dica, conta, true);
            }

            if (!item.Utilizavel)
            {
                string motivo = item.TemComando
                    ? " — ainda não portado no Positron (o comando " + item.Comando + " não existe aqui)."
                    : " — sem comando.";
                return Desativar(alvo, dica + motivo, conta, true);
            }

            string comando = ComandoNoRecoder(item.Comando);
            bool substituido = !string.Equals(comando, item.Comando, StringComparison.OrdinalIgnoreCase);
            if (substituido)
            {
                conta.Substituidos++;
            }

            // O item de menu manda um ESC antes (o `RibbomMenuItemCommandHandler` do original).
            alvo.CommandParameter = (cancelarAntes ? "\u001b" : string.Empty) + comando + " ";
            alvo.CommandHandler = new ComandoDoBotao();
            alvo.ToolTip = dica
                + (substituido ? " (" + comando + " do Positron)" : string.Empty)
                + (item.AbreJanela && !substituido ? " (abre a janela do original)" : string.Empty);
            conta.Ligados++;
            return alvo;
        }

        /// <summary>O item fica na barra, inativo, com o motivo na dica.</summary>
        private static RibbonItem Desativar(RibbonItem alvo, string dica, Contagem conta, bool acionavel)
        {
            alvo.IsEnabled = false;
#if !AUTOCAD
            // O que o original usa no ZWCAD (o banner); só o item de comando tem.
            RibbonCommandItem deComando = alvo as RibbonCommandItem;
            if (deComando != null)
            {
                deComando.IsActive = false;
            }
#endif
            alvo.ToolTip = dica;
            if (acionavel)
            {
                conta.Desativados++;
            }

            return alvo;
        }

        /// <summary>O ícone do tema do CAD: o escuro quando o original tem um e o tema é o escuro.</summary>
        private static BitmapImage Imagem(ItemDaBarra item, bool escuro)
        {
            string nome = escuro && item.IconeEscuro.Length > 0 ? item.IconeEscuro : item.Icone;
            return string.IsNullOrEmpty(nome) ? null : IconesEmbutidos.Imagem(nome);
        }

        /// <summary>
        /// O tema do CAD: o <c>COLORTHEME</c> (0 = escuro), como o original lê. Sem a variável (CAD
        /// antigo ou sem interface) fica o claro, que é o padrão de lá.
        /// </summary>
        private static bool TemaEscuro()
        {
            try
            {
                return Convert.ToInt32(Application.GetSystemVariable("COLORTHEME")) == 0;
            }
            catch (Exception)
            {
                return false;
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
            _tentativas = 0;
            Plugin.Escrever(ConstruirAba());
        }

        /// <summary>
        /// Cancela a retentativa agendada — a aba desmontada não pode voltar sozinha na ociosidade
        /// seguinte (é o caminho pelo qual o AutoCAD "ressuscitava" a barra depois do unload).
        /// </summary>
        private static void CancelarRetentativa()
        {
            if (_tentativas == 0)
            {
                return;
            }

            _tentativas = 0;
            Application.Idle -= NaOciosidade;
        }
#endif

        /// <summary>
        /// O <c>AdskCommandHandler</c> do reverso: o <c>ICommand</c> do item manda o
        /// <c>CommandParameter</c> para a linha de comando do CAD (o botão, o item de menu e o
        /// liga/desliga são todos <c>RibbonCommandItem</c>).
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
                RibbonCommandItem item = parameter as RibbonCommandItem;
                string comando = item == null ? null : item.CommandParameter as string;
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
