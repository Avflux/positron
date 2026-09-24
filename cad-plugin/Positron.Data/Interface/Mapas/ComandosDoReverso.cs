using System;
using System.Collections.Generic;

namespace Positron.Data.Interface.Mapas
{
    /// <summary>
    /// O **mapa dos comandos do reverso** — os 216 <c>[CommandMethod]</c> do <c>Eletron4Z</c> e as
    /// janelas que cada um abre.
    ///
    /// No original o comando é fino de propósito: o corpo monta a janela
    /// (<c>new frmGerenciadorDWG();</c>) e ela mesma abre dentro do CAD
    /// (<c>Application.ShowModelessDialog(this)</c> — o construtor do `frm*`). Por isso o comando
    /// e a tela andam juntos: quem sabe **qual** janela é a decodificada pelo
    /// <see cref="FormulariosDoReverso"/>, e onde o comando está no reverso, é este mapa.
    ///
    /// Duas marcas decidem o que dá para ligar no CAD com o nome do original:
    /// <list type="bullet">
    /// <item><see cref="Comando.SomenteJanela"/> — o corpo não faz outra regra além de montar a
    /// janela. Um comando que também trabalha (o <c>SYNCD</c>, que roda a sincronização inteira)
    /// não entra.</item>
    /// <item><see cref="Comando.ComVariante"/> — a construção passa argumento
    /// (<c>new frmRelatorio_DICemig(3)</c>): aquele comando é uma **variante** da tela, não a tela
    /// padrão, e registrar como se fosse a padrão seria mentir.</item>
    /// </list>
    ///
    /// A tabela compilada fica no <c>ComandosDoReverso.Dados.cs</c> (gerado); aqui só a consulta.
    /// A receita é o <c>scripts/extrair-comandos-do-reverso.ps1</c> e o resultado legível é o
    /// <c>docs/reverso-comandos.txt</c>.
    /// </summary>
    public static partial class ComandosDoReverso
    {
        private static readonly Comando[] TodosOsComandos = MontarOsComandos();

        private static readonly Dictionary<string, Comando> Indice = Indexar();

        private static readonly Dictionary<string, Comando[]> PorTela = Agrupar();

        /// <summary>Os comandos na ordem do nome, como no mapa.</summary>
        public static IReadOnlyList<Comando> Todos
        {
            get { return TodosOsComandos; }
        }

        /// <summary>Quantos comandos o original declara.</summary>
        public static int Quantidade
        {
            get { return TodosOsComandos.Length; }
        }

        /// <summary>O comando pelo nome no original (ou <c>null</c> quando não existe).</summary>
        public static Comando Buscar(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return null;
            }

            Comando comando;
            return Indice.TryGetValue(nome, out comando) ? comando : null;
        }

        /// <summary>Os comandos do original que abrem uma tela (o nome do `frm*`).</summary>
        public static IReadOnlyList<Comando> DaTela(string tela)
        {
            if (string.IsNullOrEmpty(tela))
            {
                return new Comando[0];
            }

            Comando[] comandos;
            return PorTela.TryGetValue(tela, out comandos) ? comandos : new Comando[0];
        }

        /// <summary>Quantos comandos do original abrem alguma janela.</summary>
        public static int QuantosAbremJanela()
        {
            int total = 0;
            foreach (Comando comando in TodosOsComandos)
            {
                if (comando.AbreJanela)
                {
                    total++;
                }
            }

            return total;
        }

        /// <summary>
        /// Quantos comandos dá para registrar com o nome do original (<see cref="Comando.Ligavel"/>) —
        /// os mesmos que o <c>ComandosDoOriginal.Gerado.cs</c> gera. Abrem a janela, nada mais,
        /// e não são variante de uma tela que o recoder ainda não portou.
        /// </summary>
        public static int QuantosLigaveis()
        {
            int total = 0;
            foreach (Comando comando in TodosOsComandos)
            {
                if (comando.Ligavel)
                {
                    total++;
                }
            }

            return total;
        }

        private static Dictionary<string, Comando> Indexar()
        {
            Dictionary<string, Comando> indice = new Dictionary<string, Comando>(StringComparer.OrdinalIgnoreCase);
            foreach (Comando comando in TodosOsComandos)
            {
                indice[comando.Nome] = comando;
            }

            return indice;
        }

        private static Dictionary<string, Comando[]> Agrupar()
        {
            Dictionary<string, List<Comando>> porTela = new Dictionary<string, List<Comando>>(StringComparer.Ordinal);
            foreach (Comando comando in TodosOsComandos)
            {
                foreach (Janela janela in comando.Janelas)
                {
                    List<Comando> lista;
                    if (!porTela.TryGetValue(janela.Nome, out lista))
                    {
                        lista = new List<Comando>();
                        porTela[janela.Nome] = lista;
                    }

                    lista.Add(comando);
                }
            }

            Dictionary<string, Comando[]> pronto = new Dictionary<string, Comando[]>(StringComparer.Ordinal);
            foreach (KeyValuePair<string, List<Comando>> par in porTela)
            {
                pronto[par.Key] = par.Value.ToArray();
            }

            return pronto;
        }
    }

    /// <summary>Um comando do original: o atributo, o corpo e a janela que ele abre.</summary>
    public sealed class Comando
    {
        private readonly Janela[] _janelas;

        public Comando(string nome, string arquivo, int origem, bool somenteJanela, bool comVariante, bool jaNoPlugin, Janela[] janelas)
        {
            Nome = nome;
            Arquivo = arquivo;
            Origem = origem;
            SomenteJanela = somenteJanela;
            ComVariante = comVariante;
            JaNoPlugin = jaNoPlugin;
            _janelas = janelas ?? new Janela[0];
        }

        /// <summary>O nome do comando no original (o que se digita no CAD, ex.: `GERDWG`).</summary>
        public string Nome { get; private set; }

        /// <summary>O arquivo do reverso que declara o comando.</summary>
        public string Arquivo { get; private set; }

        /// <summary>A linha do <c>[CommandMethod]</c> no arquivo do reverso (a evidência).</summary>
        public int Origem { get; private set; }

        /// <summary>O corpo não faz outra regra além de montar a janela.</summary>
        public bool SomenteJanela { get; private set; }

        /// <summary>A construção passa argumento: o comando abre uma variante da tela.</summary>
        public bool ComVariante { get; private set; }

        /// <summary>O recoder já tem esse comando com regra própria.</summary>
        public bool JaNoPlugin { get; private set; }

        /// <summary>As janelas que o corpo abre, na ordem do corpo.</summary>
        public IReadOnlyList<Janela> Janelas
        {
            get { return _janelas; }
        }

        /// <summary>O comando abre alguma janela.</summary>
        public bool AbreJanela
        {
            get { return _janelas.Length > 0; }
        }

        /// <summary>Dá para registrar com o nome do original: só abre, e abre a tela padrão.</summary>
        public bool Ligavel
        {
            get { return SomenteJanela && !ComVariante && AbreJanela && !JaNoPlugin; }
        }
    }

    /// <summary>A janela que um comando do original abre e a construção que a evidencia.</summary>
    public sealed class Janela
    {
        public Janela(string nome, string construcao)
        {
            Nome = nome;
            Construcao = construcao ?? string.Empty;
        }

        /// <summary>O nome da tela do reverso (ex.: `frmGerenciadorDWG`).</summary>
        public string Nome { get; private set; }

        /// <summary>O `new frmX(...)` como está no corpo (a evidência da variante).</summary>
        public string Construcao { get; private set; }

        /// <summary>A construção passa argumento — é uma variante da tela.</summary>
        public bool ComArgumento
        {
            get { return !Construcao.TrimEnd().EndsWith("()", StringComparison.Ordinal); }
        }
    }
}
