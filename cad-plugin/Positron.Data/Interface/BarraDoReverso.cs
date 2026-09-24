using System;
using System.Collections.Generic;

namespace Positron.Data.Interface
{
    /// <summary>
    /// A **barra de ferramentas do reverso** — o <c>Ribbon.cs</c> do <c>Eletron4Z</c>: a aba, os
    /// nove painéis na ordem em que o <c>CreateRibbon()</c> (dois) e o <c>CreateRibbon2()</c> (sete)
    /// os criam e, dentro de cada painel, cada um dos 121 botões na ordem do corpo dele — com o
    /// rótulo, o comando, o **ícone do produto** e a dica do original.
    ///
    /// Por que vale ler isto em vez de desenhar a barra à mão: no original o botão é
    /// <c>Text</c> + <c>CommandParameter</c> + <c>Image</c> montados por quatro ajudantes
    /// (o nome deles ficou ofuscado; o corpo, não), e o que a barra chama é o **comando** — a mesma
    /// moeda do mapa <see cref="ComandosDoReverso"/>. Com os dois mapas, a barra diz o que já
    /// funciona: <see cref="BotaoDaBarra.Coberto"/> é "o recoder responde a esse comando" e
    /// <see cref="BotaoDaBarra.AbreJanela"/> é "e ele abre uma tela do mapa" (rodada 128).
    ///
    /// A tabela compilada fica no <c>BarraDoReverso.Dados.cs</c> (gerado); aqui só a consulta.
    /// A receita é o <c>scripts/extrair-barra-do-reverso.ps1</c> e o resultado legível é o
    /// <c>docs/reverso-barra-do-original.txt</c>.
    /// </summary>
    public static partial class BarraDoReverso
    {
        private static readonly PainelDaBarra[] TodosOsPaineis = MontarOsPaineis();

        private static readonly BotaoDaBarra[] TodosOsBotoes = Achatar();

        private static readonly Dictionary<string, BotaoDaBarra> Indice = Indexar();

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

        /// <summary>Todos os botões na ordem da barra (por painel, na ordem do corpo do original).</summary>
        public static IReadOnlyList<BotaoDaBarra> Botoes
        {
            get { return TodosOsBotoes; }
        }

        /// <summary>Quantos botões o original tem.</summary>
        public static int Quantidade
        {
            get { return TodosOsBotoes.Length; }
        }

        /// <summary>Quantos botões o recoder responde hoje.</summary>
        public static int QuantosCobertos()
        {
            int total = 0;
            foreach (BotaoDaBarra botao in TodosOsBotoes)
            {
                if (botao.Coberto)
                {
                    total++;
                }
            }

            return total;
        }

        /// <summary>Quantos botões o recoder responde **e** abrem uma janela do mapa.</summary>
        public static int QuantosAbremJanela()
        {
            int total = 0;
            foreach (BotaoDaBarra botao in TodosOsBotoes)
            {
                if (botao.Coberto && botao.AbreJanela)
                {
                    total++;
                }
            }

            return total;
        }

        /// <summary>O primeiro botão da barra com esse comando (ou <c>null</c>).</summary>
        public static BotaoDaBarra Buscar(string comando)
        {
            if (string.IsNullOrEmpty(comando))
            {
                return null;
            }

            BotaoDaBarra botao;
            return Indice.TryGetValue(comando, out botao) ? botao : null;
        }

        private static BotaoDaBarra[] Achatar()
        {
            List<BotaoDaBarra> botoes = new List<BotaoDaBarra>();
            foreach (PainelDaBarra painel in TodosOsPaineis)
            {
                botoes.AddRange(painel.Botoes);
            }

            return botoes.ToArray();
        }

        private static Dictionary<string, BotaoDaBarra> Indexar()
        {
            Dictionary<string, BotaoDaBarra> indice = new Dictionary<string, BotaoDaBarra>(StringComparer.OrdinalIgnoreCase);
            foreach (BotaoDaBarra botao in TodosOsBotoes)
            {
                if (botao.TemComando && !indice.ContainsKey(botao.Comando))
                {
                    indice[botao.Comando] = botao;
                }
            }

            return indice;
        }
    }

    /// <summary>Um painel da barra: o título do original (resolvido pela `mMensagem`) e os botões.</summary>
    public sealed class PainelDaBarra
    {
        private readonly BotaoDaBarra[] _botoes;

        public PainelDaBarra(int ordem, string titulo, int indiceMensagem, string metodo, int origem, BotaoDaBarra[] botoes)
        {
            Ordem = ordem;
            Titulo = titulo;
            IndiceMensagem = indiceMensagem;
            Metodo = metodo;
            Origem = origem;
            _botoes = botoes ?? new BotaoDaBarra[0];
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

        /// <summary>Os botões do painel, na ordem do corpo do original.</summary>
        public IReadOnlyList<BotaoDaBarra> Botoes
        {
            get { return _botoes; }
        }

        /// <summary>Quantos botões deste painel o recoder responde.</summary>
        public int QuantosCobertos()
        {
            int total = 0;
            foreach (BotaoDaBarra botao in _botoes)
            {
                if (botao.Coberto)
                {
                    total++;
                }
            }

            return total;
        }
    }

    /// <summary>Um botão da barra do original e o que o recoder consegue fazer com ele.</summary>
    public sealed class BotaoDaBarra
    {
        public BotaoDaBarra(
            string rotulo,
            string comando,
            string icone,
            string dica,
            string grau,
            int origem,
            bool coberto,
            bool abreJanela)
        {
            Rotulo = rotulo ?? string.Empty;
            Comando = comando ?? string.Empty;
            Icone = icone ?? string.Empty;
            Dica = dica ?? string.Empty;
            Grau = grau ?? string.Empty;
            Origem = origem;
            Coberto = coberto;
            AbreJanela = abreJanela;
        }

        /// <summary>O texto do botão no original (vazio no banner da versão).</summary>
        public string Rotulo { get; private set; }

        /// <summary>O `CommandParameter` do original, sem o espaço final (o que a barra manda ao CAD).</summary>
        public string Comando { get; private set; }

        /// <summary>O nome do recurso de imagem do original (`Resources.X`), ou vazio.</summary>
        public string Icone { get; private set; }

        /// <summary>A `ToolTip` do original (nos botões pequenos é ela que traz o nome por extenso).</summary>
        public string Dica { get; private set; }

        /// <summary>
        /// O tamanho no original: `Grande` (botão com texto), `Pequeno` (ícone com a dica),
        /// `IconeTexto`, `Icone` (16x16) ou `Dialogo` (o launcher do canto do painel).
        /// </summary>
        public string Grau { get; private set; }

        /// <summary>A linha do `Ribbon.cs` (a evidência).</summary>
        public int Origem { get; private set; }

        /// <summary>O recoder responde a esse comando hoje.</summary>
        public bool Coberto { get; private set; }

        /// <summary>O comando abre uma janela do mapa das telas (o `AbreJanela` da rodada 128).</summary>
        public bool AbreJanela { get; private set; }

        /// <summary>O botão tem comando (o banner da versão não tem).</summary>
        public bool TemComando
        {
            get { return Comando.Length > 0; }
        }

        /// <summary>Dá para ligar hoje: tem comando e o recoder responde a ele.</summary>
        public bool Utilizavel
        {
            get { return TemComando && Coberto; }
        }
    }
}
