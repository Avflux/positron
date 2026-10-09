using System;
using System.Collections.Generic;
using Positron.Contract;
using Positron.Data.Bornes;
using Positron.Data.Layout;

namespace Positron.Data
{
    /// <summary>Onde o problema foi encontrado.</summary>
    public enum AreaVerificacao
    {
        Fiacao,
        Interligacao,
        Modelos,

        /// <summary>Lido do próprio desenho, não das tabelas gravadas.</summary>
        Desenho,
    }

    /// <summary>Categoria do problema (ver <see cref="VerificadorProjeto"/> para as regras).</summary>
    public enum TipoProblema
    {
        /// <summary>Ponto de fiação sem <c>Tag</c> (não casou com dispositivo/borne).</summary>
        SemTag,

        /// <summary>Terminal vazio, <c>"?"</c> ou <c>"0"</c> (o <c>CaracterTerminalIndefinido</c>).</summary>
        TerminalIndefinido,

        /// <summary>Potencial de fiação ausente ou ≤ 0.</summary>
        PotencialInvalido,

        /// <summary>Mesmo terminal repetido no mesmo <c>(painel, potencial)</c> / modelo.</summary>
        TerminalDuplicado,

        /// <summary>Trecho de interligação sem <c>Tag_Cabo</c>.</summary>
        CaboIndefinido,

        /// <summary>Ponta de interligação sem <c>Tag</c> (não casou com borne).</summary>
        PontoSemTag,

        /// <summary>Trecho sem <c>Num_Veia</c> válido.</summary>
        VeiaIndefinida,

        /// <summary>Modelo com régua ausente (<c>Portas4F</c>/<c>Bornes4F</c>).</summary>
        ReguaAusente,

        /// <summary>Modelo com borne ausente (<c>Portas4F</c>/<c>Bornes4F</c>).</summary>
        SemBorne,

        /// <summary>Cabo referenciado no desenho que não existe no catálogo (<c>Cabos</c>).</summary>
        CaboSemCatalogo,

        /// <summary>Borne do desenho cuja régua não resolve no dicionário.</summary>
        BorneSemRegua,

        /// <summary>Página gravada que não existe na <c>LayerTable</c> do desenho.</summary>
        PaginaAusente,
    }

    /// <summary>Um problema apontado numa linha das tabelas derivadas.</summary>
    public sealed class Problema
    {
        public AreaVerificacao Area { get; set; }

        public TipoProblema Tipo { get; set; }

        /// <summary>Tabela de origem — <c>Fiacao</c>, <c>Interligacao4</c>, <c>Portas4F</c>, …</summary>
        public string Tabela { get; set; }

        /// <summary>Como achar a linha — handle, tag ou <c>modelo #índice</c>.</summary>
        public string Identificador { get; set; }

        public string Detalhe { get; set; }
    }

    /// <summary>
    /// Valida as **tabelas derivadas do diagrama** — um recorte read-only do
    /// <c>frmVerificadorProjetoFiacao</c> / <c>frmVerificadorProjetoInterligacao</c>
    /// do original, que são telas grandes montadas sobre o desenho. Aqui a
    /// validação olha o que foi **gravado** e aponta as classes de problema que os
    /// próprios passos de projeção deixam visíveis.
    ///
    /// **Fiação** (<c>Fiacao</c>): ponto sem tag; terminal indefinido; potencial
    /// ≤ 0; terminal repetido no mesmo <c>(painel, potencial)</c>
    /// (o <c>LFiacaoTTDuplicada</c>).
    ///
    /// **Interligação** (<c>Interligacao4</c>): cabo indefinido (sem
    /// <c>Tag_Cabo</c>); ponta sem tag (<c>Tag1</c>/<c>Tag2</c>); terminal
    /// indefinido numa ponta; veia ausente. O original marca o mesmo no
    /// <c>carregaTree</c> (cor/seção indefinida) e no
    /// <c>IndefineCabosNaoExistentes</c>.
    ///
    /// **Modelos** (<c>Portas4F</c>/<c>Bornes4F</c>/<c>Contatos4F</c>): porta sem
    /// régua/borne; borne sem régua/número; terminal indefinido; terminal
    /// repetido no mesmo modelo. Corresponde ao <c>buscaReguasVazias</c> e às
    /// conferências de porta/contato do original.
    ///
    /// O que **não** está aqui: os erros que o verifier original lê **do desenho**
    /// (geometria, páginas apagadas, cabos referenciados que não existem no
    /// catálogo). Isso depende do ZWCAD e do adapter.
    /// </summary>
    public static class VerificadorProjeto
    {
        /// <summary>Texto de terminal indefinido do original (<c>CaracterTerminalIndefinido</c>).</summary>
        public const string TerminalIndefinido = "?";

        /// <summary>
        /// Terminal vazio, <c>"?"</c> ou <c>"0"</c> é indefinido — o verifier do
        /// original troca <c>"0"</c> e vazio por <c>CaracterTerminalIndefinido</c>.
        /// </summary>
        public static bool TerminalEhIndefinido(string terminal)
        {
            if (string.IsNullOrWhiteSpace(terminal))
            {
                return true;
            }

            string texto = terminal.Trim();
            return string.Equals(texto, TerminalIndefinido, StringComparison.Ordinal)
                || string.Equals(texto, "0", StringComparison.Ordinal);
        }

        /// <summary>Roda os três blocos e devolve tudo junto.</summary>
        public static List<Problema> Verificar(
            IEnumerable<FiacaoRow> fiacao,
            IEnumerable<Interligacao4Row> interligacao,
            IEnumerable<Portas4FRow> portas,
            IEnumerable<Bornes4FRow> bornes,
            IEnumerable<Contatos4FRow> contatos)
        {
            List<Problema> problemas = new List<Problema>();
            problemas.AddRange(VerificarFiacao(fiacao));
            problemas.AddRange(VerificarInterligacao(interligacao));
            problemas.AddRange(VerificarModelos(portas, bornes, contatos));
            return problemas;
        }

        // ---------------------------------------------------------------- Fiação

        public static List<Problema> VerificarFiacao(IEnumerable<FiacaoRow> linhas)
        {
            List<Problema> problemas = new List<Problema>();
            if (linhas == null)
            {
                return problemas;
            }

            Dictionary<string, bool> vistos = new Dictionary<string, bool>(StringComparer.Ordinal);
            foreach (FiacaoRow linha in linhas)
            {
                if (linha == null)
                {
                    continue;
                }

                string id = Identificador(linha.Handle, linha.Painel, linha.Potencial);

                if (!linha.Potencial.HasValue || linha.Potencial.Value <= 0)
                {
                    problemas.Add(Novo(AreaVerificacao.Fiacao, TipoProblema.PotencialInvalido, "Fiacao", id, "potencial ausente ou <= 0"));
                }

                if (string.IsNullOrWhiteSpace(linha.Tag))
                {
                    problemas.Add(Novo(AreaVerificacao.Fiacao, TipoProblema.SemTag, "Fiacao", id, "ponto sem tag"));
                }
                else if (TerminalEhIndefinido(linha.Terminal))
                {
                    problemas.Add(Novo(AreaVerificacao.Fiacao, TipoProblema.TerminalIndefinido, "Fiacao", id, "terminal indefinido"));
                }

                string terminal = TerminalLimpo(linha.Terminal);
                if (terminal != null)
                {
                    string chave = (linha.Painel ?? 0) + "|" + (linha.Potencial ?? 0) + "|" + terminal;
                    if (vistos.ContainsKey(chave))
                    {
                        problemas.Add(Novo(AreaVerificacao.Fiacao, TipoProblema.TerminalDuplicado, "Fiacao", id, "terminal repetido no mesmo potencial"));
                    }
                    else
                    {
                        vistos[chave] = true;
                    }
                }
            }

            return problemas;
        }

        // ----------------------------------------------------------- Interligação

        public static List<Problema> VerificarInterligacao(IEnumerable<Interligacao4Row> linhas)
        {
            List<Problema> problemas = new List<Problema>();
            if (linhas == null)
            {
                return problemas;
            }

            foreach (Interligacao4Row linha in linhas)
            {
                if (linha == null)
                {
                    continue;
                }

                string id = string.IsNullOrWhiteSpace(linha.Tag_Cabo)
                    ? "#" + linha.Indice
                    : linha.Tag_Cabo;

                if (string.IsNullOrWhiteSpace(linha.Tag_Cabo))
                {
                    problemas.Add(Novo(AreaVerificacao.Interligacao, TipoProblema.CaboIndefinido, "Interligacao4", id, "cabo indefinido"));
                }

                if (string.IsNullOrWhiteSpace(linha.Tag1))
                {
                    problemas.Add(Novo(AreaVerificacao.Interligacao, TipoProblema.PontoSemTag, "Interligacao4", id, "ponta 1 sem tag"));
                }
                else if (TerminalEhIndefinido(linha.Terminal1))
                {
                    problemas.Add(Novo(AreaVerificacao.Interligacao, TipoProblema.TerminalIndefinido, "Interligacao4", id, "terminal indefinido na ponta 1"));
                }

                if (string.IsNullOrWhiteSpace(linha.Tag2))
                {
                    problemas.Add(Novo(AreaVerificacao.Interligacao, TipoProblema.PontoSemTag, "Interligacao4", id, "ponta 2 sem tag"));
                }
                else if (TerminalEhIndefinido(linha.Terminal2))
                {
                    problemas.Add(Novo(AreaVerificacao.Interligacao, TipoProblema.TerminalIndefinido, "Interligacao4", id, "terminal indefinido na ponta 2"));
                }

                if (!linha.Num_Veia.HasValue || linha.Num_Veia.Value <= 0)
                {
                    problemas.Add(Novo(AreaVerificacao.Interligacao, TipoProblema.VeiaIndefinida, "Interligacao4", id, "veia ausente ou <= 0"));
                }
            }

            return problemas;
        }

        // ---------------------------------------------------------------- Modelos

        public static List<Problema> VerificarModelos(
            IEnumerable<Portas4FRow> portas,
            IEnumerable<Bornes4FRow> bornes,
            IEnumerable<Contatos4FRow> contatos)
        {
            List<Problema> problemas = new List<Problema>();

            if (portas != null)
            {
                foreach (Portas4FRow porta in portas)
                {
                    if (porta == null)
                    {
                        continue;
                    }

                    string id = Modelo(porta.NomeModelo, porta.IndexModelo);
                    if (string.IsNullOrWhiteSpace(porta.Regua))
                    {
                        problemas.Add(Novo(AreaVerificacao.Modelos, TipoProblema.ReguaAusente, "Portas4F", id, "porta sem régua"));
                    }

                    if (string.IsNullOrWhiteSpace(porta.Borne))
                    {
                        problemas.Add(Novo(AreaVerificacao.Modelos, TipoProblema.SemBorne, "Portas4F", id, "porta sem borne"));
                    }

                    if (TerminalEhIndefinido(porta.Terminal))
                    {
                        problemas.Add(Novo(AreaVerificacao.Modelos, TipoProblema.TerminalIndefinido, "Portas4F", id, "terminal indefinido"));
                    }
                }
            }

            if (bornes != null)
            {
                foreach (Bornes4FRow borne in bornes)
                {
                    if (borne == null)
                    {
                        continue;
                    }

                    string id = string.IsNullOrWhiteSpace(borne.Regua)
                        ? "#" + borne.Indice
                        : borne.Regua + " " + (borne.Borne ?? "?");

                    if (!borne.IndexRegua.HasValue || borne.IndexRegua.Value <= 0)
                    {
                        problemas.Add(Novo(AreaVerificacao.Modelos, TipoProblema.ReguaAusente, "Bornes4F", id, "borne sem régua"));
                    }

                    if (string.IsNullOrWhiteSpace(borne.Borne))
                    {
                        problemas.Add(Novo(AreaVerificacao.Modelos, TipoProblema.SemBorne, "Bornes4F", id, "borne sem número"));
                    }
                }
            }

            if (contatos != null)
            {
                Dictionary<string, bool> vistos = new Dictionary<string, bool>(StringComparer.Ordinal);
                foreach (Contatos4FRow contato in contatos)
                {
                    if (contato == null)
                    {
                        continue;
                    }

                    string id = Modelo(contato.NomeModelo, contato.IndexModelo);
                    if (TerminalEhIndefinido(contato.Terminal))
                    {
                        problemas.Add(Novo(AreaVerificacao.Modelos, TipoProblema.TerminalIndefinido, "Contatos4F", id, "terminal indefinido"));
                        continue;
                    }

                    string chave = (contato.IndexModelo ?? 0) + "|" + TerminalLimpo(contato.Terminal);
                    if (vistos.ContainsKey(chave))
                    {
                        problemas.Add(Novo(AreaVerificacao.Modelos, TipoProblema.TerminalDuplicado, "Contatos4F", id, "terminal repetido no mesmo modelo"));
                    }
                    else
                    {
                        vistos[chave] = true;
                    }
                }
            }

            return problemas;
        }

        // --------------------------------------------------------------- Desenho
        //
        // O verifier original também pinta erros lidos do DESENHO (o que não está
        // nas tabelas gravadas). Estas duas regras são as que dão para checar sem
        // geometria: a régua do borne e o cabo referenciado fora do catálogo.

        /// <summary>
        /// Cabo referenciado no desenho/projeção que não existe no catálogo
        /// (<c>Cabos</c>) — o <c>IndefineCabosNaoExistentes</c> do original. A
        /// comparação de tags ignora caixa e aponta cada tag uma vez.
        /// </summary>
        public static List<Problema> VerificarCabosSemCatalogo(
            IEnumerable<string> cabosUsados,
            IEnumerable<string> catalogo)
        {
            List<Problema> problemas = new List<Problema>();
            if (cabosUsados == null)
            {
                return problemas;
            }

            HashSet<string> conhecidos = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (catalogo != null)
            {
                foreach (string tag in catalogo)
                {
                    if (!string.IsNullOrWhiteSpace(tag))
                    {
                        conhecidos.Add(tag.Trim());
                    }
                }
            }

            HashSet<string> apontados = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (string tag in cabosUsados)
            {
                if (string.IsNullOrWhiteSpace(tag))
                {
                    continue;
                }

                string limpo = tag.Trim();
                if (conhecidos.Contains(limpo) || !apontados.Add(limpo))
                {
                    continue;
                }

                problemas.Add(Novo(AreaVerificacao.Desenho, TipoProblema.CaboSemCatalogo, "Cabos", limpo,
                    "cabo referenciado não existe no catálogo (Cabos)"));
            }

            return problemas;
        }

        /// <summary>
        /// Borne do desenho cuja régua não resolve no dicionário
        /// (<c>IndiceRegua</c> fora de <c>REGUAS/MODELOS2</c>) — o original não
        /// projeta esse borne e a tela de verificação o aponta.
        /// </summary>
        public static List<Problema> VerificarBornesSemRegua(
            IEnumerable<PontoBorne> bornes,
            ReguasModelo reguas)
        {
            List<Problema> problemas = new List<Problema>();
            if (bornes == null)
            {
                return problemas;
            }

            foreach (PontoBorne borne in bornes)
            {
                if (borne == null)
                {
                    continue;
                }

                if (reguas != null && reguas.Buscar(borne.IndiceRegua) != null)
                {
                    continue;
                }

                string identificador = string.IsNullOrWhiteSpace(borne.Handle)
                    ? "régua #" + borne.IndiceRegua
                    : borne.Handle;
                problemas.Add(Novo(AreaVerificacao.Desenho, TipoProblema.BorneSemRegua, "Bornes", identificador,
                    "borne sem régua no dicionário (índice " + borne.IndiceRegua + ")"));
            }

            return problemas;
        }

        /// <summary>
        /// Página gravada que não existe na <c>LayerTable</c> do desenho — a
        /// matriz de páginas é montada dos layers (o <c>Pagina.CarregaPaginas</c>),
        /// então uma página fora dela é página apagada/renomeada.
        /// </summary>
        public static List<Problema> VerificarPaginasAusentes(
            IEnumerable<string> paginas,
            PaginaMatrix matriz)
        {
            List<Problema> problemas = new List<Problema>();
            if (paginas == null)
            {
                return problemas;
            }

            HashSet<string> apontadas = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (string pagina in paginas)
            {
                if (string.IsNullOrWhiteSpace(pagina))
                {
                    continue;
                }

                string limpa = pagina.Trim();
                if (matriz != null && matriz.Contem(limpa))
                {
                    continue;
                }

                if (!apontadas.Add(limpa))
                {
                    continue;
                }

                problemas.Add(Novo(AreaVerificacao.Desenho, TipoProblema.PaginaAusente, "Pagina", limpa,
                    "página gravada não existe na LayerTable do desenho"));
            }

            return problemas;
        }

        private static string TerminalLimpo(string terminal)
        {
            if (TerminalEhIndefinido(terminal))
            {
                return null;
            }

            return terminal.Trim();
        }

        private static string Identificador(string handle, long? painel, long? potencial)
        {
            if (!string.IsNullOrWhiteSpace(handle))
            {
                return handle;
            }

            return (painel ?? 0) + "/" + (potencial ?? 0);
        }

        private static string Modelo(string nome, long? indice)
        {
            return (string.IsNullOrWhiteSpace(nome) ? "?" : nome) + " #" + (indice ?? 0);
        }

        private static Problema Novo(AreaVerificacao area, TipoProblema tipo, string tabela, string identificador, string detalhe)
        {
            return new Problema
            {
                Area = area,
                Tipo = tipo,
                Tabela = tabela,
                Identificador = identificador,
                Detalhe = detalhe,
            };
        }
    }
}
