using System;
using System.Collections.Generic;

namespace Positron.Data.Interface.Mapas
{
    /// <summary>
    /// O **mapa das janelas do reverso** — os 127 `frm*` do `Eletron4Z`: o título, o tamanho e
    /// cada controle na posição, no tamanho, no texto e no ícone do original.
    ///
    /// De onde vem: o `.cs` descompilado guarda o método do designer inteiro (o
    /// `[DebuggerStepThrough]` com o `SuspendLayout()`) e o de4dot **não** ofuscou os nomes de
    /// controle nem os valores das propriedades — só os campos privados e os nomes de método.
    /// A formatação das janelas, portanto, está no arquivo; a receita de extração é o
    /// `scripts/extrair-formularios-do-reverso.ps1`, e o resultado legível é o
    /// `docs/reverso-formularios.txt`.
    ///
    /// Os **textos** vêm da tabela `mMensagem` do original (resolvida pelo índice) ou de literal;
    /// onde o texto só existe em tempo de execução (por exemplo um nome de painel buscado no
    /// banco) o campo guarda o marcador `{expressão}` — nunca um valor inventado. Os **ícones**
    /// vêm do nome do recurso (`Resources.X`), extraídos para `cad-plugin/lib/Icons`.
    ///
    /// A tabela compilada fica no `FormulariosDoReverso.Dados.cs` (gerado); aqui só a consulta.
    /// </summary>
    public static partial class FormulariosDoReverso
    {
        private static readonly Tela[] TodasAsTelas = MontarAsTelas();

        private static readonly Dictionary<string, Tela> Indice = Indexar();

        /// <summary>As telas na ordem do nome, como no mapa.</summary>
        public static IReadOnlyList<Tela> Todas
        {
            get { return TodasAsTelas; }
        }

        /// <summary>Quantas telas do original foram decodificadas.</summary>
        public static int Quantidade
        {
            get { return TodasAsTelas.Length; }
        }

        /// <summary>A tela pelo nome do `frm` (ou <c>null</c> quando não existe).</summary>
        public static Tela Buscar(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return null;
            }

            Tela tela;
            return Indice.TryGetValue(nome, out tela) ? tela : null;
        }

        private static Dictionary<string, Tela> Indexar()
        {
            Dictionary<string, Tela> indice = new Dictionary<string, Tela>(StringComparer.OrdinalIgnoreCase);
            foreach (Tela tela in TodasAsTelas)
            {
                indice[tela.Nome] = tela;
            }

            return indice;
        }
    }

    /// <summary>Uma janela do reverso: o formulário e o que ele tem dentro.</summary>
    public sealed class Tela
    {
        private readonly Par[] _propriedades;
        private readonly Campo[] _campos;
        private readonly Dictionary<string, List<Campo>> _porPai;

        public Tela(string nome, string titulo, int largura, int altura, int origem, string[] propriedades, Campo[] campos)
        {
            Nome = nome;
            Titulo = titulo;
            Largura = largura;
            Altura = altura;
            Origem = origem;
            _propriedades = Emparelhar(propriedades);
            _campos = campos ?? new Campo[0];
            _porPai = Agrupar(_campos);
        }

        /// <summary>O nome do `frm` no original (ex.: `frmPesquisaXdatas`).</summary>
        public string Nome { get; private set; }

        /// <summary>O título da janela, já com a `mMensagem` resolvida.</summary>
        public string Titulo { get; private set; }

        /// <summary>A largura do `ClientSize` do designer.</summary>
        public int Largura { get; private set; }

        /// <summary>A altura do `ClientSize` do designer.</summary>
        public int Altura { get; private set; }

        /// <summary>A linha do designer no `.cs` do reverso (a evidência).</summary>
        public int Origem { get; private set; }

        /// <summary>As propriedades da janela (a moldura: borda, cor de fundo, imagem, topo...).</summary>
        public IReadOnlyList<Par> Propriedades
        {
            get { return _propriedades; }
        }

        /// <summary>Os controles, na ordem em que o designer os declara.</summary>
        public IReadOnlyList<Campo> Campos
        {
            get { return _campos; }
        }

        /// <summary>Os controles de primeiro nível (os que o designer pendura na própria janela).</summary>
        public IReadOnlyList<Campo> Raizes
        {
            get { return Filhos(string.Empty); }
        }

        /// <summary>Os filhos de um controle, na ordem do `Controls.Add` do designer.</summary>
        public IReadOnlyList<Campo> Filhos(string pai)
        {
            List<Campo> lista;
            if (_porPai.TryGetValue(pai ?? string.Empty, out lista))
            {
                return lista;
            }

            return new Campo[0];
        }

        /// <summary>O valor de uma propriedade da janela (ou <c>null</c> quando o designer não a põe).</summary>
        public string Propriedade(string nome)
        {
            return Emparelhado.Valor(_propriedades, nome);
        }

        private static Par[] Emparelhar(string[] pares)
        {
            if (pares == null || pares.Length < 2)
            {
                return new Par[0];
            }

            Par[] resultado = new Par[pares.Length / 2];
            for (int i = 0; i + 1 < pares.Length; i += 2)
            {
                resultado[i / 2] = new Par(pares[i], pares[i + 1]);
            }

            return resultado;
        }

        private static Dictionary<string, List<Campo>> Agrupar(Campo[] campos)
        {
            Dictionary<string, List<Campo>> porPai = new Dictionary<string, List<Campo>>(StringComparer.Ordinal);
            foreach (Campo campo in campos)
            {
                string pai = campo.Pai ?? string.Empty;
                List<Campo> lista;
                if (!porPai.TryGetValue(pai, out lista))
                {
                    lista = new List<Campo>();
                    porPai[pai] = lista;
                }

                lista.Add(campo);
            }

            foreach (List<Campo> lista in porPai.Values)
            {
                lista.Sort((a, b) => a.Ordem.CompareTo(b.Ordem));
            }

            return porPai;
        }
    }

    /// <summary>Um controle (ou uma coluna de grade) da janela, na posição do designer.</summary>
    public sealed class Campo
    {
        /// <summary>
        /// O que o designer **não** põe. Não pode ser um valor "pequeno": o designer do original
        /// tem controle em coordenada negativa (o `BTCorrigaPortasDiscrepantes`, por exemplo, está
        /// em `Location = (-18, ...)`), então -1 seria ambíguo.
        /// </summary>
        public const int NaoDefinido = int.MinValue;

        private readonly Par[] _propriedades;

        public Campo(
            string tipo,
            string nome,
            string pai,
            int x,
            int y,
            int largura,
            int altura,
            string texto,
            string imagem,
            int ordem,
            string[] propriedades)
        {
            Tipo = tipo;
            Nome = nome;
            Pai = pai;
            X = x;
            Y = y;
            Largura = largura;
            Altura = altura;
            Texto = texto;
            Imagem = imagem;
            Ordem = ordem;
            _propriedades = new Par[0];
            if (propriedades != null && propriedades.Length >= 2)
            {
                _propriedades = new Par[propriedades.Length / 2];
                for (int i = 0; i + 1 < propriedades.Length; i += 2)
                {
                    _propriedades[i / 2] = new Par(propriedades[i], propriedades[i + 1]);
                }
            }
        }

        /// <summary>O tipo WinForms do designer (`Button`, `DataGridView`, `Coluna`...).</summary>
        public string Tipo { get; private set; }

        /// <summary>O nome do controle no designer (o `Name` do original).</summary>
        public string Nome { get; private set; }

        /// <summary>O nome do controle que contém este (vazio = a própria janela).</summary>
        public string Pai { get; private set; }

        /// <summary>O `X` do `Location` (ou <see cref="NaoDefinido"/>).</summary>
        public int X { get; private set; }

        /// <summary>O `Y` do `Location` (ou <see cref="NaoDefinido"/>).</summary>
        public int Y { get; private set; }

        /// <summary>A largura do `Size` (ou <see cref="NaoDefinido"/>).</summary>
        public int Largura { get; private set; }

        /// <summary>A altura do `Size` (ou <see cref="NaoDefinido"/>).</summary>
        public int Altura { get; private set; }

        /// <summary>O designer pôs a posição deste controle.</summary>
        public bool TemLocal
        {
            get { return X != NaoDefinido && Y != NaoDefinido; }
        }

        /// <summary>O designer pôs o tamanho deste controle.</summary>
        public bool TemTamanho
        {
            get { return Largura != NaoDefinido && Altura != NaoDefinido; }
        }

        /// <summary>O texto (a `mMensagem` já resolvida; `{expressão}` quando só existe em execução).</summary>
        public string Texto { get; private set; }

        /// <summary>O nome do recurso de imagem do original (`Resources.X`), ou vazio.</summary>
        public string Imagem { get; private set; }

        /// <summary>A ordem do `Controls.Add` no designer (a z-order e a ordem de criação).</summary>
        public int Ordem { get; private set; }

        /// <summary>As propriedades que mudam o visual, na ordem em que o designer as escreve.</summary>
        public IReadOnlyList<Par> Propriedades
        {
            get { return _propriedades; }
        }

        /// <summary>É uma coluna de grade (a definição vem das rotinas de carga do original).</summary>
        public bool EhColuna
        {
            get { return Tipo == "Coluna"; }
        }

        /// <summary>É um item literal de lista (`Items.Add("...")`).</summary>
        public bool EhItem
        {
            get { return Tipo == "Item"; }
        }

        /// <summary>O valor de uma propriedade do controle (ou <c>null</c>).</summary>
        public string Propriedade(string nome)
        {
            return Emparelhado.Valor(_propriedades, nome);
        }
    }

    /// <summary>Um par nome/valor de propriedade (a ordem do designer importa).</summary>
    public sealed class Par
    {
        public Par(string nome, string valor)
        {
            Nome = nome;
            Valor = valor;
        }

        public string Nome { get; private set; }

        public string Valor { get; private set; }
    }

    internal static class Emparelhado
    {
        internal static string Valor(IReadOnlyList<Par> pares, string nome)
        {
            for (int i = 0; i < pares.Count; i++)
            {
                if (string.Equals(pares[i].Nome, nome, StringComparison.Ordinal))
                {
                    return pares[i].Valor;
                }
            }

            return null;
        }
    }
}
