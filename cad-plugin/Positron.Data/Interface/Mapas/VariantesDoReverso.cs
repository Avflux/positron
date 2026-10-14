using System;
using System.Collections.Generic;

namespace Positron.Data.Interface.Mapas
{
    /// <summary>
    /// O **mapa das variantes das telas** do reverso — os 15 comandos do <c>Eletron4Z</c> que abrem
    /// formulários com argumentos no construtor (<c>new frmRelatorio_DInterlig(1..11)</c>,
    /// <c>new frmRelatorio_DICemig(1..3)</c> e <c>new frmTrocaPaineis(bAbre: false)</c>).
    ///
    /// No original, o construtor desses formulários executa um <c>switch</c> sobre o argumento que:
    /// <list type="bullet">
    /// <item>Troca o título da janela para a concessionária/tipo específico;</item>
    /// <item>Mostra ou oculta painéis e grupos de controles (<c>GroupBoxTipoCruz</c>, <c>GroupBoxPaineisCima</c>, <c>GroupBox1</c>, <c>rb2</c>, <c>tbReserva</c>);</item>
    /// <item>Habilita ou desabilita botões de ação e opções (<c>btMirrorJumper</c>, <c>btCima</c>, <c>btRebateCabos</c>, <c>rbC</c>, <c>rb4</c>);</item>
    /// <item>Ajusta a posição de sobreposição de recipientes (<c>GroupBoxPaineisCima.Location = GroupBoxTipoCruz.Location</c>).</item>
    /// </list>
    ///
    /// Este mapa formaliza todas as 15 variantes como dados puros em <see cref="VarianteDeTela"/>,
    /// permitindo que tanto a casca do CAD (<see cref="JanelasDoOriginal"/>) quanto o renderizador
    /// e testes abram a janela adaptada com fidelidade.
    /// </summary>
    public static class VariantesDoReverso
    {
        private static readonly VarianteDeTela[] TodasAsVariantes = MontarVariantes();

        private static readonly Dictionary<string, VarianteDeTela> IndicePorComando = IndexarPorComando();

        private static readonly Dictionary<string, List<VarianteDeTela>> IndicePorTela = IndexarPorTela();

        /// <summary>As 15 variantes mapeadas.</summary>
        public static IReadOnlyList<VarianteDeTela> Todas
        {
            get { return TodasAsVariantes; }
        }

        /// <summary>Quantidade de variantes de tela mapeadas (15).</summary>
        public static int Quantidade
        {
            get { return TodasAsVariantes.Length; }
        }

        /// <summary>
        /// Busca a variante pelo nome do comando (ex.: <c>DICHESF</c>, <c>DIFURNAS</c>, <c>DICEMIGDE</c>, <c>TROCAPN</c>),
        /// insensível a maiúsculas/minúsculas.
        /// </summary>
        public static VarianteDeTela Buscar(string comando)
        {
            if (string.IsNullOrEmpty(comando))
            {
                return null;
            }

            VarianteDeTela variante;
            return IndicePorComando.TryGetValue(comando.Trim(), out variante) ? variante : null;
        }

        /// <summary>Todas as variantes pertencentes a um formulário base (ex.: <c>frmRelatorio_DInterlig</c>).</summary>
        public static IReadOnlyList<VarianteDeTela> DaTela(string tela)
        {
            if (string.IsNullOrEmpty(tela))
            {
                return new VarianteDeTela[0];
            }

            List<VarianteDeTela> lista;
            if (IndicePorTela.TryGetValue(tela.Trim(), out lista))
            {
                return lista;
            }

            return new VarianteDeTela[0];
        }

        private static Dictionary<string, VarianteDeTela> IndexarPorComando()
        {
            Dictionary<string, VarianteDeTela> mapa = new Dictionary<string, VarianteDeTela>(StringComparer.OrdinalIgnoreCase);
            foreach (VarianteDeTela v in TodasAsVariantes)
            {
                mapa[v.Comando] = v;
            }

            return mapa;
        }

        private static Dictionary<string, List<VarianteDeTela>> IndexarPorTela()
        {
            Dictionary<string, List<VarianteDeTela>> mapa = new Dictionary<string, List<VarianteDeTela>>(StringComparer.OrdinalIgnoreCase);
            foreach (VarianteDeTela v in TodasAsVariantes)
            {
                List<VarianteDeTela> lista;
                if (!mapa.TryGetValue(v.Tela, out lista))
                {
                    lista = new List<VarianteDeTela>();
                    mapa[v.Tela] = lista;
                }

                lista.Add(v);
            }

            return mapa;
        }

        private static VarianteDeTela[] MontarVariantes()
        {
            return new VarianteDeTela[]
            {
                // =========================================================================
                // frmRelatorio_DInterlig (11 variantes do switch em orN1wKRAnJ)
                // =========================================================================
                new VarianteDeTela(
                    "DICHESF",
                    "frmRelatorio_DInterlig",
                    "new frmRelatorio_DInterlig(1)",
                    1,
                    "Diagrama de Interligação CHESF",
                    new[] { "GroupBoxPaineisCima", "GroupBox1", "rb2", "Label3", "tbReserva" },
                    new[] { "GroupBoxTipoCruz" },
                    new[] { "btRebateCabos" },
                    new[] { "btMirrorJumper", "btCima", "rbC" },
                    new[] { new Par("GroupBoxPaineisCima", "12,459") }),

                new VarianteDeTela(
                    "DICPFL",
                    "frmRelatorio_DInterlig",
                    "new frmRelatorio_DInterlig(2)",
                    2,
                    "Diagrama de Interligação CPFL SERVIÇOS",
                    new[] { "GroupBoxTipoCruz", "GroupBox1", "rb2", "Label3", "tbReserva" },
                    new[] { "GroupBoxPaineisCima" },
                    new[] { "btMirrorJumper", "btCima", "btRebateCabos", "rbC" },
                    new string[0]),

                new VarianteDeTela(
                    "DICTEEP",
                    "frmRelatorio_DInterlig",
                    "new frmRelatorio_DInterlig(3)",
                    3,
                    "Diagrama de Interligação ISA CTEEP",
                    new[] { "GroupBoxPaineisCima", "GroupBox1", "rb2", "Label3", "tbReserva" },
                    new[] { "GroupBoxTipoCruz" },
                    new[] { "btRebateCabos" },
                    new[] { "btMirrorJumper", "btCima", "rbC" },
                    new[] { new Par("GroupBoxPaineisCima", "12,459") }),

                new VarianteDeTela(
                    "DIEQUAT",
                    "frmRelatorio_DInterlig",
                    "new frmRelatorio_DInterlig(4)",
                    4,
                    "Diagrama de Interligação EQUATORIAL",
                    new[] { "Label3", "tbReserva" },
                    new[] { "GroupBoxTipoCruz", "GroupBoxPaineisCima", "GroupBox1" },
                    new[] { "btMirrorJumper", "btCima", "btRebateCabos", "rbC" },
                    new string[0]),

                new VarianteDeTela(
                    "DICPFLTR",
                    "frmRelatorio_DInterlig",
                    "new frmRelatorio_DInterlig(5)",
                    5,
                    "Diagrama de Interligação CPFL TRANSMISSÃO",
                    new[] { "GroupBoxPaineisCima", "GroupBox1", "rb2", "Label3", "tbReserva" },
                    new[] { "GroupBoxTipoCruz" },
                    new[] { "btRebateCabos" },
                    new[] { "btMirrorJumper", "btCima", "rbC" },
                    new[] { new Par("GroupBoxPaineisCima", "12,459") }),

                new VarianteDeTela(
                    "DIEDP",
                    "frmRelatorio_DInterlig",
                    "new frmRelatorio_DInterlig(6)",
                    6,
                    "Diagrama de Interligação EDP ES",
                    new[] { "GroupBoxPaineisCima", "GroupBox1", "Label3", "tbReserva" },
                    new[] { "GroupBoxTipoCruz", "rb2" },
                    new[] { "btRebateCabos" },
                    new[] { "btMirrorJumper", "btCima", "rbC" },
                    new[] { new Par("GroupBoxPaineisCima", "12,459") }),

                new VarianteDeTela(
                    "DITAESA",
                    "frmRelatorio_DInterlig",
                    "new frmRelatorio_DInterlig(7)",
                    7,
                    "Diagrama de Interligação TAESA",
                    new[] { "GroupBoxPaineisCima", "GroupBox1", "Label3", "tbReserva" },
                    new[] { "GroupBoxTipoCruz", "rb2" },
                    new[] { "btRebateCabos" },
                    new[] { "btMirrorJumper", "btCima", "rbC" },
                    new[] { new Par("GroupBoxPaineisCima", "12,459") }),

                new VarianteDeTela(
                    "DIFURNAS",
                    "frmRelatorio_DInterlig",
                    "new frmRelatorio_DInterlig(8)",
                    8,
                    "Diagrama de Interligação FURNAS",
                    new[] { "GroupBoxPaineisCima", "GroupBox1", "rb2", "Label3", "tbReserva" },
                    new[] { "GroupBoxTipoCruz" },
                    new[] { "btRebateCabos" },
                    new[] { "btMirrorJumper", "btCima", "rbC" },
                    new[] { new Par("GroupBoxPaineisCima", "12,459") }),

                new VarianteDeTela(
                    "DICEMIGGTP",
                    "frmRelatorio_DInterlig",
                    "new frmRelatorio_DInterlig(9)",
                    9,
                    "Diagrama de Interligação CEMIG-GT PAINEL",
                    new[] { "GroupBoxPaineisCima", "GroupBox1", "rb2" },
                    new[] { "GroupBoxTipoCruz", "Label3", "tbReserva" },
                    new[] { "btRebateCabos" },
                    new[] { "btMirrorJumper", "btCima", "rbC" },
                    new[] { new Par("GroupBoxPaineisCima", "12,459") }),

                new VarianteDeTela(
                    "DIENELSP",
                    "frmRelatorio_DInterlig",
                    "new frmRelatorio_DInterlig(10)",
                    10,
                    "Diagrama de Interligação ENEL-SP",
                    new[] { "GroupBoxPaineisCima", "GroupBox1", "Label3", "tbReserva" },
                    new[] { "GroupBoxTipoCruz", "rb2" },
                    new[] { "btRebateCabos" },
                    new[] { "btMirrorJumper", "btCima", "rbC" },
                    new[] { new Par("GroupBoxPaineisCima", "12,459") }),

                new VarianteDeTela(
                    "DIITAIPU",
                    "frmRelatorio_DInterlig",
                    "new frmRelatorio_DInterlig(11)",
                    11,
                    "Diagrama de Interligação ITAIPU",
                    new[] { "GroupBoxPaineisCima", "GroupBox1", "rb2", "Label3", "tbReserva" },
                    new[] { "GroupBoxTipoCruz" },
                    new[] { "btRebateCabos" },
                    new[] { "btMirrorJumper", "btCima", "rbC" },
                    new[] { new Par("GroupBoxPaineisCima", "12,459") }),

                // =========================================================================
                // frmRelatorio_DICemig (3 variantes do switch em Hu2LowX0Zg)
                // =========================================================================
                new VarianteDeTela(
                    "DICEMIGGTE",
                    "frmRelatorio_DICemig",
                    "new frmRelatorio_DICemig(1)",
                    1,
                    "Diagrama de Interligação CEMIG-GT EQUIP",
                    new string[0],
                    new string[0],
                    new[] { "btEsquerda", "btMirrorJumperDown" },
                    new[] { "rb4" }),

                new VarianteDeTela(
                    "DICEMIGDP",
                    "frmRelatorio_DICemig",
                    "new frmRelatorio_DICemig(2)",
                    2,
                    "Diagrama de Interligação CEMIG-D PAINEL",
                    new string[0],
                    new string[0],
                    new[] { "btEsquerda", "btMirrorJumperDown" },
                    new[] { "rb4" }),

                new VarianteDeTela(
                    "DICEMIGDE",
                    "frmRelatorio_DICemig",
                    "new frmRelatorio_DICemig(3)",
                    3,
                    "Diagrama de Interligação CEMIG-D EQUIP",
                    new string[0],
                    new string[0],
                    new[] { "rb4", "btEsquerda", "btMirrorJumperDown" },
                    new string[0]),

                // =========================================================================
                // frmTrocaPaineis (1 variante com argumento nomeado bAbre: false)
                // =========================================================================
                new VarianteDeTela(
                    "TROCAPN",
                    "frmTrocaPaineis",
                    "new frmTrocaPaineis(bAbre: false)",
                    0,
                    "Trocar Painel",
                    new string[0],
                    new string[0],
                    new[] { "btTrocaosPaineis" },
                    new string[0])
            };
        }
    }

    /// <summary>
    /// A especificação de uma variante de tela: o comando que a dispara, o título adaptado,
    /// os grupos e controles a mostrar/ocultar ou habilitar/desabilitar, e as coordenadas corrigidas.
    /// </summary>
    public sealed class VarianteDeTela
    {
        private readonly string[] _gruposVisiveis;
        private readonly string[] _gruposOcultos;
        private readonly string[] _controlesDesabilitados;
        private readonly string[] _controlesHabilitados;
        private readonly Par[] _posicoesModificadas;

        public VarianteDeTela(
            string comando,
            string tela,
            string construcao,
            int caso,
            string titulo,
            string[] gruposVisiveis,
            string[] gruposOcultos,
            string[] controlesDesabilitados,
            string[] controlesHabilitados,
            Par[] posicoesModificadas = null)
        {
            Comando = comando ?? string.Empty;
            Tela = tela ?? string.Empty;
            Construcao = construcao ?? string.Empty;
            Caso = caso;
            Titulo = titulo ?? string.Empty;
            _gruposVisiveis = gruposVisiveis ?? new string[0];
            _gruposOcultos = gruposOcultos ?? new string[0];
            _controlesDesabilitados = controlesDesabilitados ?? new string[0];
            _controlesHabilitados = controlesHabilitados ?? new string[0];
            _posicoesModificadas = posicoesModificadas ?? new Par[0];
        }

        /// <summary>O nome do comando que aciona esta variante (ex.: <c>DICHESF</c>).</summary>
        public string Comando { get; private set; }

        /// <summary>O nome do formulário base no reverso (ex.: <c>frmRelatorio_DInterlig</c>).</summary>
        public string Tela { get; private set; }

        /// <summary>A expressão de instanciação do original (ex.: <c>new frmRelatorio_DInterlig(1)</c>).</summary>
        public string Construcao { get; private set; }

        /// <summary>O valor numérico do argumento do construtor (ou 0 quando nomeado).</summary>
        public int Caso { get; private set; }

        /// <summary>O título exibido na barra de título da janela.</summary>
        public string Titulo { get; private set; }

        /// <summary>Nomes dos grupos/controles que devem ficar visíveis (<c>Visible = true</c>).</summary>
        public IReadOnlyList<string> GruposVisiveis
        {
            get { return _gruposVisiveis; }
        }

        /// <summary>Nomes dos grupos/controles que devem ficar ocultos (<c>Visible = false</c>).</summary>
        public IReadOnlyList<string> GruposOcultos
        {
            get { return _gruposOcultos; }
        }

        /// <summary>Nomes dos controles que devem ficar desabilitados (<c>Enabled = false</c>).</summary>
        public IReadOnlyList<string> ControlesDesabilitados
        {
            get { return _controlesDesabilitados; }
        }

        /// <summary>Nomes dos controles que devem ficar habilitados (<c>Enabled = true</c>).</summary>
        public IReadOnlyList<string> ControlesHabilitados
        {
            get { return _controlesHabilitados; }
        }

        /// <summary>Coordenadas sobrescritas de controles (ex.: <c>GroupBoxPaineisCima</c> em <c>12,459</c>).</summary>
        public IReadOnlyList<Par> PosicoesModificadas
        {
            get { return _posicoesModificadas; }
        }

        /// <summary>
        /// Aplica as personalizações desta variante sobre a <see cref="Tela"/> base,
        /// retornando uma nova instância adaptada com o título correto e os estados de controle correspondentes.
        /// </summary>
        public Tela Aplicar(Tela baseTela)
        {
            if (baseTela == null)
            {
                return null;
            }

            HashSet<string> visiveis = new HashSet<string>(_gruposVisiveis, StringComparer.OrdinalIgnoreCase);
            HashSet<string> ocultos = new HashSet<string>(_gruposOcultos, StringComparer.OrdinalIgnoreCase);
            HashSet<string> desabilitados = new HashSet<string>(_controlesDesabilitados, StringComparer.OrdinalIgnoreCase);
            HashSet<string> habilitados = new HashSet<string>(_controlesHabilitados, StringComparer.OrdinalIgnoreCase);

            Dictionary<string, int[]> posicoes = new Dictionary<string, int[]>(StringComparer.OrdinalIgnoreCase);
            foreach (Par par in _posicoesModificadas)
            {
                string[] coords = (par.Valor ?? string.Empty).Split(',');
                if (coords.Length == 2)
                {
                    int x, y;
                    if (int.TryParse(coords[0], out x) && int.TryParse(coords[1], out y))
                    {
                        posicoes[par.Nome] = new[] { x, y };
                    }
                }
            }

            List<Campo> camposNovos = new List<Campo>();
            foreach (Campo c in baseTela.Campos)
            {
                int x = c.X;
                int y = c.Y;
                if (!string.IsNullOrEmpty(c.Nome) && posicoes.ContainsKey(c.Nome))
                {
                    int[] pt = posicoes[c.Nome];
                    x = pt[0];
                    y = pt[1];
                }

                List<string> props = new List<string>();
                for (int i = 0; i < c.Propriedades.Count; i++)
                {
                    string propNome = c.Propriedades[i].Nome;
                    string propValor = c.Propriedades[i].Valor;

                    if (!string.IsNullOrEmpty(c.Nome))
                    {
                        if (propNome.Equals("Visible", StringComparison.OrdinalIgnoreCase) && (visiveis.Contains(c.Nome) || ocultos.Contains(c.Nome)))
                        {
                            continue;
                        }

                        if (propNome.Equals("Enabled", StringComparison.OrdinalIgnoreCase) && (desabilitados.Contains(c.Nome) || habilitados.Contains(c.Nome)))
                        {
                            continue;
                        }
                    }

                    props.Add(propNome);
                    props.Add(propValor);
                }

                if (!string.IsNullOrEmpty(c.Nome))
                {
                    if (visiveis.Contains(c.Nome))
                    {
                        props.Add("Visible");
                        props.Add("True");
                    }
                    else if (ocultos.Contains(c.Nome))
                    {
                        props.Add("Visible");
                        props.Add("False");
                    }

                    if (desabilitados.Contains(c.Nome))
                    {
                        props.Add("Enabled");
                        props.Add("False");
                    }
                    else if (habilitados.Contains(c.Nome))
                    {
                        props.Add("Enabled");
                        props.Add("True");
                    }
                }

                Campo novo = new Campo(c.Tipo, c.Nome, c.Pai, x, y, c.Largura, c.Altura, c.Texto, c.Imagem, c.Ordem, props.ToArray());
                camposNovos.Add(novo);
            }

            List<string> propsJanela = new List<string>();
            foreach (Par p in baseTela.Propriedades)
            {
                propsJanela.Add(p.Nome);
                propsJanela.Add(p.Valor);
            }

            return new Tela(baseTela.Nome, Titulo, baseTela.Largura, baseTela.Altura, baseTela.Origem, propsJanela.ToArray(), camposNovos.ToArray());
        }
    }
}
