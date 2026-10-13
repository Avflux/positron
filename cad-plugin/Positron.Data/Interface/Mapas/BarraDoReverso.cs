using System;
using System.Collections.Generic;

namespace Positron.Data.Interface.Mapas
{
    /// <summary>
    /// A **barra de ferramentas do reverso** — o <c>Ribbon.cs</c> do <c>Eletron4Z</c>: a aba, os
    /// nove painéis na ordem em que o <c>CreateRibbon()</c> (dois) e o <c>CreateRibbon2()</c> (sete)
    /// os criam e, dentro de cada painel, a **árvore** que o original monta: as linhas
    /// (<c>RibbonRowPanel</c>) com as quebras, a área recolhível (depois do <c>RibbonPanelBreak</c>),
    /// os separadores, os menus suspensos com os itens, a lista de seção, o campo da cor, o botão
    /// liga/desliga e o botão do canto (<c>DialogLauncher</c>) — cada item com o rótulo, o comando,
    /// os **ícones do produto** (claro e escuro) e a dica do original.
    ///
    /// O que a barra chama é o **comando** — a mesma moeda do mapa <see cref="ComandosDoReverso"/>:
    /// <see cref="ItemDaBarra.Coberto"/> é "o recoder responde a esse comando" e
    /// <see cref="ItemDaBarra.AbreJanela"/> é "e ele abre uma tela do mapa" (rodada 128).
    ///
    /// A tabela compilada fica no <c>BarraDoReverso.Dados.cs</c> (gerado); aqui só a consulta.
    /// A receita é o <c>scripts/extrair-barra-do-reverso.ps1</c> e o resultado legível é o
    /// <c>docs/reverso-barra-do-original.txt</c>.
    /// </summary>
    public static partial class BarraDoReverso
    {
        private static readonly PainelDaBarra[] TodosOsPaineis = MontarOsPaineis();

        private static readonly ItemDaBarra[] TodosOsAcionaveis = Achatar();

        private static readonly Dictionary<string, ItemDaBarra> Indice = Indexar();

        /// <summary>O `Id` da aba no original (`CENG.ID_Elet`).</summary>
        public static string IdDaAbaDoOriginal
        {
            get { return IdDaAba; }
        }

        /// <summary>O título da aba no original ("Elétron").</summary>
        public static string TituloDaAbaDoOriginal
        {
            get { return TituloDaAba; }
        }

        /// <summary>Os painéis na ordem da barra do original.</summary>
        public static IReadOnlyList<PainelDaBarra> Paineis
        {
            get { return TodosOsPaineis; }
        }

        /// <summary>
        /// Tudo o que se clica (botão, item de menu, liga/desliga e o botão do canto), na ordem da
        /// barra.
        /// </summary>
        public static IReadOnlyList<ItemDaBarra> Acionaveis
        {
            get { return TodosOsAcionaveis; }
        }

        /// <summary>Quantos itens daquele tipo a barra tem (o botão do canto conta como botão).</summary>
        public static int Contar(TipoDoItemDaBarra tipo)
        {
            int total = 0;
            foreach (PainelDaBarra painel in TodosOsPaineis)
            {
                total += painel.Contar(tipo);
            }

            return total;
        }

        /// <summary>Quantos acionáveis o recoder responde hoje.</summary>
        public static int QuantosCobertos()
        {
            int total = 0;
            foreach (ItemDaBarra item in TodosOsAcionaveis)
            {
                if (item.Coberto)
                {
                    total++;
                }
            }

            return total;
        }

        /// <summary>Quantos acionáveis o recoder responde **e** abrem uma janela do mapa.</summary>
        public static int QuantosAbremJanela()
        {
            int total = 0;
            foreach (ItemDaBarra item in TodosOsAcionaveis)
            {
                if (item.Coberto && item.AbreJanela)
                {
                    total++;
                }
            }

            return total;
        }

        /// <summary>O primeiro acionável da barra com esse comando (ou <c>null</c>).</summary>
        public static ItemDaBarra Buscar(string comando)
        {
            if (string.IsNullOrEmpty(comando))
            {
                return null;
            }

            ItemDaBarra item;
            return Indice.TryGetValue(comando, out item) ? item : null;
        }

        private static ItemDaBarra[] Achatar()
        {
            List<ItemDaBarra> itens = new List<ItemDaBarra>();
            foreach (PainelDaBarra painel in TodosOsPaineis)
            {
                itens.AddRange(painel.Acionaveis());
            }

            return itens.ToArray();
        }

        private static Dictionary<string, ItemDaBarra> Indexar()
        {
            Dictionary<string, ItemDaBarra> indice = new Dictionary<string, ItemDaBarra>(StringComparer.OrdinalIgnoreCase);
            foreach (ItemDaBarra item in TodosOsAcionaveis)
            {
                if (item.TemComando && !indice.ContainsKey(item.Comando))
                {
                    indice[item.Comando] = item;
                }
            }

            return indice;
        }
    }

    /// <summary>O que um item da barra do original é (a classe do <c>Ribbon*</c> que o cria).</summary>
    public enum TipoDoItemDaBarra
    {
        /// <summary><c>RibbonButton</c>.</summary>
        Botao,

        /// <summary><c>RibbonMenuButton</c>: o botão do menu suspenso, com os itens como filhos.</summary>
        Menu,

        /// <summary><c>RibbonMenuItem</c>.</summary>
        ItemDeMenu,

        /// <summary><c>RibbonRowPanel</c>: uma coluna de linhas, com os itens como filhos.</summary>
        Linha,

        /// <summary><c>RibbonRowBreak</c>: a próxima linha dentro da <see cref="Linha"/>.</summary>
        QuebraDeLinha,

        /// <summary><c>RibbonPanelBreak</c>: o que vem depois fica na área recolhível do painel.</summary>
        Recolhe,

        /// <summary><c>RibbonSeparator</c>.</summary>
        Separador,

        /// <summary><c>RibbonCombo</c>: a seção ativa (a <c>BitolaCollection</c> do original).</summary>
        ListaDeSecao,

        /// <summary><c>RibbonTextBox</c>: a cor ativa.</summary>
        CampoDeCor,

        /// <summary><c>RibbonToggleButton</c>: o liga/desliga (o <c>InfoOn</c> do Help).</summary>
        Alternar,
    }

    /// <summary>Um painel da barra: o título do original, o botão do canto e a árvore dos itens.</summary>
    public sealed class PainelDaBarra
    {
        private readonly ItemDaBarra[] _itens;

        public PainelDaBarra(int ordem, string titulo, int indiceMensagem, string metodo, int origem, ItemDaBarra lancador, ItemDaBarra[] itens)
        {
            Ordem = ordem;
            Titulo = titulo;
            IndiceMensagem = indiceMensagem;
            Metodo = metodo;
            Origem = origem;
            Lancador = lancador;
            _itens = itens ?? new ItemDaBarra[0];
        }

        /// <summary>A posição do painel na barra (1 é o primeiro).</summary>
        public int Ordem { get; private set; }

        /// <summary>O título do painel, já com a `mMensagem` resolvida.</summary>
        public string Titulo { get; private set; }

        /// <summary>O índice na `mMensagem` (ou -1 quando o título é literal, como o "Help").</summary>
        public int IndiceMensagem { get; private set; }

        /// <summary>O método do `Ribbon.cs` que monta o painel (a evidência).</summary>
        public string Metodo { get; private set; }

        /// <summary>A linha do método no `Ribbon.cs`.</summary>
        public int Origem { get; private set; }

        /// <summary>O botão do canto do painel (o <c>DialogLauncher</c>), ou <c>null</c>.</summary>
        public ItemDaBarra Lancador { get; private set; }

        /// <summary>Os itens do painel no primeiro nível, na ordem do original.</summary>
        public IReadOnlyList<ItemDaBarra> Itens
        {
            get { return _itens; }
        }

        /// <summary>Os acionáveis do painel, na ordem da barra (o botão do canto por último).</summary>
        public List<ItemDaBarra> Acionaveis()
        {
            List<ItemDaBarra> saida = new List<ItemDaBarra>();
            foreach (ItemDaBarra item in Todos())
            {
                if (item.Acionavel)
                {
                    saida.Add(item);
                }
            }

            return saida;
        }

        /// <summary>Quantos itens daquele tipo há no painel (a árvore inteira e o botão do canto).</summary>
        public int Contar(TipoDoItemDaBarra tipo)
        {
            int total = 0;
            foreach (ItemDaBarra item in Todos())
            {
                if (item.Tipo == tipo)
                {
                    total++;
                }
            }

            return total;
        }

        private IEnumerable<ItemDaBarra> Todos()
        {
            foreach (ItemDaBarra item in _itens)
            {
                foreach (ItemDaBarra descendente in item.EleEOsDescendentes())
                {
                    yield return descendente;
                }
            }

            if (Lancador != null)
            {
                yield return Lancador;
            }
        }
    }

    /// <summary>Um item da barra do original e o que o recoder consegue fazer com ele.</summary>
    public sealed class ItemDaBarra
    {
        private readonly ItemDaBarra[] _filhos;

        public ItemDaBarra(
            TipoDoItemDaBarra tipo,
            string grau,
            string rotulo,
            string comando,
            string icone,
            string iconeEscuro,
            string dica,
            double largura,
            bool desativado,
            int origem,
            bool coberto,
            bool abreJanela,
            params ItemDaBarra[] filhos)
        {
            Tipo = tipo;
            Grau = grau ?? string.Empty;
            Rotulo = rotulo ?? string.Empty;
            Comando = comando ?? string.Empty;
            Icone = icone ?? string.Empty;
            IconeEscuro = iconeEscuro ?? string.Empty;
            Dica = dica ?? string.Empty;
            Largura = largura;
            Desativado = desativado;
            Origem = origem;
            Coberto = coberto;
            AbreJanela = abreJanela;
            _filhos = filhos ?? new ItemDaBarra[0];
        }

        /// <summary>A classe do original que cria o item.</summary>
        public TipoDoItemDaBarra Tipo { get; private set; }

        /// <summary>
        /// O ajudante do original que configura o item: <c>Grande</c> (ícone grande, texto embaixo),
        /// <c>IconeGrande</c> (ícone grande sem texto), <c>IconeTexto</c> (ícone 16 com texto),
        /// <c>Icone</c> (só o ícone 16), <c>Menu</c>, <c>ItemDeMenu</c> ou <c>Dialogo</c> (o botão
        /// do canto). Vazio nos itens que não passam por ajudante (linha, quebra, separador...).
        /// </summary>
        public string Grau { get; private set; }

        /// <summary>O texto do item no original (vazio nos que só mostram o ícone).</summary>
        public string Rotulo { get; private set; }

        /// <summary>O `CommandParameter` do original, sem o espaço final (o que a barra manda ao CAD).</summary>
        public string Comando { get; private set; }

        /// <summary>O ícone do tema claro (`Resources.X`), ou vazio.</summary>
        public string Icone { get; private set; }

        /// <summary>O ícone do tema escuro (o ramo `COLORTHEME == 0`), vazio quando é o mesmo.</summary>
        public string IconeEscuro { get; private set; }

        /// <summary>A `ToolTip` do original (nos itens só de ícone é ela que traz o nome por extenso).</summary>
        public string Dica { get; private set; }

        /// <summary>A `Width` do original (0 quando ele não define).</summary>
        public double Largura { get; private set; }

        /// <summary>O original cria o item inativo (o banner da versão).</summary>
        public bool Desativado { get; private set; }

        /// <summary>A linha do `Ribbon.cs` (a evidência).</summary>
        public int Origem { get; private set; }

        /// <summary>O recoder responde a esse comando hoje.</summary>
        public bool Coberto { get; private set; }

        /// <summary>O comando abre uma janela do mapa das telas (o `AbreJanela` da rodada 128).</summary>
        public bool AbreJanela { get; private set; }

        /// <summary>Os filhos: os itens da <c>Linha</c> ou do <c>Menu</c>, na ordem do original.</summary>
        public IReadOnlyList<ItemDaBarra> Filhos
        {
            get { return _filhos; }
        }

        /// <summary>O item tem comando.</summary>
        public bool TemComando
        {
            get { return Comando.Length > 0; }
        }

        /// <summary>Se clica: botão, item de menu ou liga/desliga.</summary>
        public bool Acionavel
        {
            get
            {
                return Tipo == TipoDoItemDaBarra.Botao
                    || Tipo == TipoDoItemDaBarra.ItemDeMenu
                    || Tipo == TipoDoItemDaBarra.Alternar;
            }
        }

        /// <summary>Dá para ligar hoje: tem comando, o recoder responde e o original não o desativa.</summary>
        public bool Utilizavel
        {
            get { return TemComando && Coberto && !Desativado; }
        }

        /// <summary>O item e a sua subárvore, em pré-ordem.</summary>
        public IEnumerable<ItemDaBarra> EleEOsDescendentes()
        {
            yield return this;
            foreach (ItemDaBarra filho in _filhos)
            {
                foreach (ItemDaBarra descendente in filho.EleEOsDescendentes())
                {
                    yield return descendente;
                }
            }
        }
    }
}
