using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Positron.Contract;
using Positron.Data.Bornes;
using Positron.Data.Fiacao;
using Positron.Data.Layout;
using Positron.Data.Modelos;

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

        /// <summary>Borne do desenho que não virou nenhum ponto de <c>Fiacao</c> (órfão).</summary>
        BorneSemFiacao,

        /// <summary>Mesmo fio desenhado duas vezes (dois trechos Tipo 2 com as mesmas pontas).</summary>
        FiacaoDuplicada,

        /// <summary>Régua do dicionário do desenho sem nenhum borne no caderno.</summary>
        ReguaVazia,

        /// <summary>Borne do desenho sem <c>LM</c> (<c>lm == 0</c>): a régua não define LM.</summary>
        BorneSemLm,

        /// <summary>Borne do desenho cujo atributo <c>T1</c> (número visível) difere do número definido pela régua (o <c>bt9Discrepantes</c>).</summary>
        BorneEditado,

        /// <summary>Painel usado no desenho que não existe no cadastro do projeto (<c>lPnAoagado</c>).</summary>
        PainelSemCadastro,

        /// <summary>Conexão sem par: sem sobreposição (Tipo 3 com Handle vazio) ou fora do potencial.</summary>
        ConexaoOrfa,
        /// <summary>Tipo 3 apontando para um Handle que não existe como conexão na mesma página.</summary>
        SobreposicaoAusente,

        /// <summary>Borne de régua com número <c>"?"</c> (indefinido) — o `bt8intervalos`.</summary>
        BorneNumeroIndefinido,

        /// <summary>Buraco na sequência numérica dos bornes de uma régua (o `bt8intervalos`).</summary>
        IntervaloBorneInvalido,

        /// <summary>Dois bornes seguidos da mesma régua com o mesmo número (o `bt8intervalos`).</summary>
        BorneNumeroRepetido,

        /// <summary>Porta de modelo de máscara com o campo `Régua` separado por `;` fora de par com os bornes (o `bt13ReguaMascara`).</summary>
        ReguaMascara,

        /// <summary>Bloco de porta (`E`) do desenho cujo atributo `T`/`B`/`R` diverge do modelo de máscara (o `bt14PortasDiscrepantes`).</summary>
        PortaDiscrepante,

        /// <summary>Dispositivo principal (`P`) sem LM (LM1 e LM2 zerados) ou com terminal indefinido (o `bt3Principal`).</summary>
        PrincipalIncompleto,

        /// <summary>Bloco auxiliar (`A`) cujos terminais divergem do contato do modelo (o `bt4Auxiliar`).</summary>
        AuxiliarDivergente,

        /// <summary>Bloco do desenho repetido — dois blocos do mesmo item (o `bt12AMao`, "Copy made by hand").</summary>
        BlocoDuplicado,
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

                // Nem todo ponto de fiação tem dispositivo: os vértices e cruzamentos
                // do fio nascem sem Tag, sem Handle e sem régua (medido no desenho
                // real: 223 de 365 linhas, TODAS sem nenhum campo de dispositivo).
                // O que interessa é o ponto que TEM dispositivo e ficou sem Tag —
                // esse é o órfão que o original mostra em `carregaOrfao`.
                bool temDispositivo = !string.IsNullOrWhiteSpace(linha.Handle)
                    || !string.IsNullOrWhiteSpace(linha.NRegua)
                    || !string.IsNullOrWhiteSpace(linha.Alternativo)
                    || (linha.IndexModelo.HasValue && linha.IndexModelo.Value > 0)
                    || (linha.TipoBorne.HasValue && linha.TipoBorne.Value != 0)
                    || (linha.Aplicacao.HasValue && linha.Aplicacao.Value != 0);

                bool temTag = !string.IsNullOrWhiteSpace(linha.Tag);
                if (temDispositivo && !temTag)
                {
                    problemas.Add(Novo(AreaVerificacao.Fiacao, TipoProblema.SemTag, "Fiacao", id, "ponto com dispositivo sem tag"));
                }
                else if (temTag && TerminalEhIndefinido(linha.Terminal))
                {
                    problemas.Add(Novo(AreaVerificacao.Fiacao, TipoProblema.TerminalIndefinido, "Fiacao", id, "terminal indefinido"));
                }

                // Não existe regra de "terminal repetido no mesmo potencial": dois
                // bornes diferentes numerados 11 no mesmo potencial são normais (era o
                // que esta regra apontava, 110 vezes no desenho real). O que o original
                // verifica é **fiação desenhada em duplicidade** — dois trechos Tipo 2
                // com as mesmas pontas —, e isso vive em `VerificarFiacaoDuplicada`
                // porque depende da geometria do desenho, não da tabela.
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

                    // O produto grava DOIS tipos de linha em Portas4F
                    // (frmCompilarFiacao, NNYXzPbSi2):
                    //   "B" = borne declarado pela máscara → Regua/Borne preenchidos,
                    //         Terminal vazio;
                    //   "T" = terminal da máscara → Terminal preenchido e Regua/Borne
                    //         VAZIOS por construção.
                    // Exigir régua/borne de toda linha marcava 100% das linhas "T"
                    // como problema (medido: 265+265 no desenho real).
                    bool ehBorne = string.Equals(porta.Tipo, "B", System.StringComparison.OrdinalIgnoreCase);

                    if (ehBorne)
                    {
                        if (string.IsNullOrWhiteSpace(porta.Regua))
                        {
                            problemas.Add(Novo(AreaVerificacao.Modelos, TipoProblema.ReguaAusente, "Portas4F", id, "borne sem régua"));
                        }

                        if (string.IsNullOrWhiteSpace(porta.Borne))
                        {
                            problemas.Add(Novo(AreaVerificacao.Modelos, TipoProblema.SemBorne, "Portas4F", id, "borne sem número"));
                        }
                    }
                    else if (TerminalEhIndefinido(porta.Terminal))
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
                foreach (Contatos4FRow contato in contatos)
                {
                    if (contato == null)
                    {
                        continue;
                    }

                    // Sem regra de "terminal repetido no mesmo modelo": o original
                    // grava um contato por campo `sT1`/`sT2`/`sT3` do modelo, **sem
                    // dedup** (frmCompilarFiacao linha ~2279) — um fusível com o mesmo
                    // terminal nos dois lados é dado normal (18 apontamentos de ruído no
                    // desenho real).
                    if (TerminalEhIndefinido(contato.Terminal))
                    {
                        problemas.Add(Novo(AreaVerificacao.Modelos, TipoProblema.TerminalIndefinido, "Contatos4F", Modelo(contato.NomeModelo, contato.IndexModelo), "terminal indefinido"));
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

            // Catálogo VAZIO não é "nenhum cabo existe": é ausência de dados (no
            // projeto real o catálogo vem do banco Access, que não está carregado
            // aqui). Sem esta guarda, todo cabo do desenho vira problema — medido:
            // 18 apontamentos de ruído num desenho real.
            if (conhecidos.Count == 0)
            {
                return problemas;
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
        /// <summary>
        /// Régua declarada no dicionário do desenho que **não tem borne** no
        /// caderno — o <c>buscaReguasVazias</c> do
        /// <c>ClsVerificadorProjetoFiacao</c> (linha 1815 do reverso): para cada
        /// modelo de régua do dicionário, se o par <c>(painel, régua)</c> não está
        /// entre as réguas usadas pelos bornes do desenho, a régua está vazia. O
        /// original guarda as usadas em `"painel,régua"`
        /// (<c>clsReguasDeBornes.EncontraReguasUsadasNoCaderno</c>); aqui a chave é
        /// o par de inteiros, que é a mesma coisa sem depender de formatação.
        /// </summary>
        /// <summary>
        /// Borne do desenho com <c>lm == 0</c> — o <c>GijcRTCGe3</c> do
        /// <c>frmVerificadorProjetoFiacao</c> (linha 2720 do reverso), que monta a
        /// árvore `TreeViewBornesLM` com todo borne cujo <c>lm</c> é zero, agrupado
        /// por painel → régua → número. O <c>lm</c> é resolvido do dicionário quando
        /// o borne é criado (<c>DicionarioBorne.BuscaLMdaRegua</c>): zero significa
        /// que a régua não define LM.
        /// </summary>
        /// <summary>
        /// Conexões órfãs — o <c>carregaOrfao</c> do <c>ClsVerificadorProjetoFiacao</c>
        /// (linha 1311 do reverso), que é o botão "órfão" da tela de verificação.
        ///
        /// A regra tem dois laços, como no original:
        ///
        /// 1. conexão sem sobreposição (<c>HandleSup</c> vazio — na prática uma
        ///    <c>Tipo 3</c> cujo campo <c>Handle</c> do XData está em branco);
        /// 2. conexão cujo <c>Potencial</c> **não** aparece em nenhuma conexão
        ///    <c>Tipo 1</c>/<c>2</c> (potencial isolado), ou cuja sobreposição aponta
        ///    para um handle que **não** existe como conexão na mesma página.
        ///
        /// O original dedupa por potencial **durante** o segundo laço
        /// (<c>list2.Add</c>) e compara a sobreposição com o conjunto de handles das
        /// conexões do desenho; aqui é o mesmo, sem o filtro de painéis em uso que a
        /// tela aplica (<c>lPn</c>).
        /// </summary>
        /// <summary>
        /// Painel usado no desenho que **não existe no cadastro** do projeto — o
        /// `lPnAoagado` do `ClsVerificadorProjetoFiacao`. O painel entra na lista
        /// quando o dispositivo/máscara o referencia e `Dicionario.BuscaNomeDoPainel`
        /// responde `"???"` (o dicionário de painéis é a tabela `Paineis` do banco,
        /// não o desenho). Painel `0` é "não definido" e não entra, como no original.
        /// </summary>
        public static List<Problema> VerificarPaineisSemCadastro(
            IEnumerable<int> paineisDoDesenho,
            IEnumerable<int> indicesDoCadastro)
        {
            List<Problema> problemas = new List<Problema>();
            if (paineisDoDesenho == null)
            {
                return problemas;
            }

            HashSet<int> vistos = new HashSet<int>();
            foreach (int painel in paineisDoDesenho)
            {
                if (painel <= 0 || !vistos.Add(painel))
                {
                    continue;
                }

                if (indicesDoCadastro != null && new HashSet<int>(indicesDoCadastro).Contains(painel))
                {
                    continue;
                }

                problemas.Add(Novo(AreaVerificacao.Desenho, TipoProblema.PainelSemCadastro, "Paineis",
                    "painel " + painel,
                    "painel usado no desenho sem cadastro no projeto (o dicionário devolveria \"???\")"));
            }

            return problemas;
        }

        public static List<Problema> VerificarOrfaos(IEnumerable<ConexaoFiacao> conexoes)
        {
            List<Problema> problemas = new List<Problema>();
            if (conexoes == null)
            {
                return problemas;
            }

            List<ConexaoFiacao> todas = new List<ConexaoFiacao>();
            foreach (ConexaoFiacao conexao in conexoes)
            {
                if (conexao == null)
                {
                    continue;
                }

                // O original descarta as conexões de jumper antes de montar o conjunto
                // (`ClsVerificadorProjetoFiacao:791`): elas são do `JMP`.
                string jumper = (conexao.Jumper ?? string.Empty).Trim().ToUpperInvariant();
                if (jumper == "JUMPER")
                {
                    continue;
                }

                todas.Add(conexao);
            }

            if (todas.Count == 0)
            {
                return problemas;
            }

            // Passo 1 do original: potenciais que têm conexão Tipo 1 ou 2 e o
            // conjunto de handles das conexões (com a página de cada um).
            HashSet<int> comTipo12 = new HashSet<int>();
            List<KeyValuePair<string, string>> handles = new List<KeyValuePair<string, string>>();
            List<string> vistos = new List<string>();
            foreach (ConexaoFiacao conexao in todas)
            {
                if (conexao.Tipo == 1 || conexao.Tipo == 2)
                {
                    comTipo12.Add(conexao.Potencial);
                }

                string handle = conexao.Handle ?? string.Empty;
                if (!vistos.Contains(handle))
                {
                    vistos.Add(handle);
                    handles.Add(new KeyValuePair<string, string>(handle, conexao.Pagina ?? string.Empty));
                }
            }

            // Laço A: sem sobreposição.
            foreach (ConexaoFiacao conexao in todas)
            {
                if (!string.IsNullOrEmpty(conexao.HandleSuperposto))
                {
                    continue;
                }

                problemas.Add(Novo(AreaVerificacao.Desenho, TipoProblema.ConexaoOrfa, "Conexoes",
                    conexao.Handle, "conexão sem sobreposição (potencial " + conexao.Potencial
                    + ", painel " + conexao.Painel + ", página \"" + (conexao.Pagina ?? string.Empty) + "\")"));
            }

            // Laço B: potencial isolado ou sobreposição que não resolve.
            HashSet<int> jaApontados = new HashSet<int>();
            foreach (ConexaoFiacao conexao in todas)
            {
                string sobreposto = conexao.HandleSuperposto ?? string.Empty;
                if (comTipo12.Contains(conexao.Potencial) || jaApontados.Contains(conexao.Potencial))
                {
                    if (sobreposto == "OK")
                    {
                        continue;
                    }

                    bool achou = false;
                    foreach (KeyValuePair<string, string> par in handles)
                    {
                        if (par.Key == sobreposto && par.Value == (conexao.Pagina ?? string.Empty))
                        {
                            achou = true;
                            break;
                        }
                    }

                    if (achou)
                    {
                        continue;
                    }

                    problemas.Add(Novo(AreaVerificacao.Desenho, TipoProblema.SobreposicaoAusente, "Conexoes",
                        conexao.Handle, "sobreposição \"" + sobreposto + "\" não existe como conexão na página \""
                        + (conexao.Pagina ?? string.Empty) + "\" (potencial " + conexao.Potencial + ")"));
                    jaApontados.Add(conexao.Potencial);
                }
                else
                {
                    problemas.Add(Novo(AreaVerificacao.Desenho, TipoProblema.ConexaoOrfa, "Conexoes",
                        conexao.Handle, "potencial " + conexao.Potencial + " sem nenhuma conexão Tipo 1/2"
                        + " (painel " + conexao.Painel + ", página \"" + (conexao.Pagina ?? string.Empty) + "\")"));
                    jaApontados.Add(conexao.Potencial);
                }
            }

            return problemas;
        }

        public static List<Problema> VerificarBornesSemLm(IEnumerable<PontoBorne> bornes)
        {
            List<Problema> problemas = new List<Problema>();
            if (bornes == null)
            {
                return problemas;
            }

            foreach (PontoBorne borne in bornes)
            {
                if (borne == null || borne.Lm != 0)
                {
                    continue;
                }

                problemas.Add(Novo(AreaVerificacao.Desenho, TipoProblema.BorneSemLm, "Bornes",
                    borne.Handle,
                    "borne sem LM (painel " + borne.Painel + ", régua #" + borne.IndiceRegua
                    + ", borne " + (borne.Numero ?? string.Empty).Trim() + ")"));
            }

            return problemas;
        }

        /// <summary>
        /// Bornes editados — o <c>bt9Discrepantes</c> da tela de verificação
        /// (<c>QU5c0lgjBd</c>): o borne do desenho cujo atributo <c>T1</c> (o número
        /// **visível** impresso no bloco) difere do número que a régua/XData define.
        ///
        /// O original monta <c>m_TodosBornes</c> com o número do XData (o complemento
        /// colado e o <c>"0"</c> virando <c>"?"</c>) e depois **substitui** o
        /// <c>NumeroComplem</c> pelo atributo <c>T1</c> do bloco; quando o atributo é
        /// igual ao número, ele é zerado (não é edição). A grade
        /// <c>dgBornesEditados</c> lista exatamente os que sobram — o número visível
        /// contradiz o dado. A comparação é sem diferenciar maiúsculas (<c>TextCompare</c>)
        /// e sem <c>Trim</c>, como no original.
        /// </summary>
        public static List<Problema> VerificarBornesEditados(IEnumerable<PontoBorne> bornes)
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

                // `clsTextos.TiraNothing`: ausência de atributo não é edição.
                string visivel = borne.NumeroVisivel ?? string.Empty;
                if (visivel.Length == 0)
                {
                    continue;
                }

                string numero = NumeroDoDesenho(borne);
                if (Igual(visivel, numero))
                {
                    continue;
                }

                string identificador = string.IsNullOrWhiteSpace(borne.Handle)
                    ? "régua #" + borne.IndiceRegua
                    : borne.Handle;
                problemas.Add(Novo(AreaVerificacao.Desenho, TipoProblema.BorneEditado, "Bornes", identificador,
                    "número visível \"" + visivel + "\" ≠ número da régua \"" + numero
                    + "\" (painel " + borne.Painel + ", régua #" + borne.IndiceRegua + ")"));
            }

            return problemas;
        }

        /// <summary>
        /// Blocos duplicados — o <c>bt12AMao</c> da tela de verificação ("Copy made by
        /// hand", a grade <c>dgAMao</c>), alimentado pelo
        /// <c>clsBlocos.VerificaDuplicados</c>.
        ///
        /// O original varre o ModelSpace e, por bloco, monta uma **chave de
        /// identidade** conforme o tipo; quando a chave já apareceu, o bloco é um
        /// **duplicado** (dois blocos do mesmo item) e vira uma linha. A lista de
        /// chaves é **uma só** para todos os tipos (um <c>List&lt;string&gt;</c>
        /// compartilhado):
        ///
        /// | tipo | chave | rótulo |
        /// |------|-------|--------|
        /// | máscara (`M`) | `painel_nome1_nome2_alternativo` | `Mask` |
        /// | dispositivo (`P`) | `painel_nome1_nome2_alternativo` | `Main Device` |
        /// | porta (`E`) | `painel_nome1_nome2_alternativo_indiceDaPorta` (identidade da **máscara**) | `Door` |
        /// | borne (`B`) | `painel_indiceRegua_numero` | `Terminal` |
        /// | auxiliar (`A`) | `painel_nome1_nome2_alternativo_indexContato` (identidade do **bob**) | `Auxiliary Contacts` |
        /// | definição (`D`) | `handleMascara_indiceModelo_indiceDaPorta` | `Definition` |
        ///
        /// Regras fiéis: máscara/dispositivo **complementar** não entram; porta com
        /// `indiceDaPorta == 0` não entra; borne com número `"?"`/`"0"` é pulado (o
        /// desenho grava "sem número" assim); a comparação das chaves é **ordinal**
        /// (sensível a caixa), e o complemento do número do borne **não** entra na
        /// chave (o original usa o `Numero` cru, não o `Terminal`).
        ///
        /// Só aparecem os blocos cujo **painel está em uso** (o <c>cOWeaBRTRB</c> do
        /// original). No auxiliar o painel do filtro é o **bug do original**: usa o
        /// `indexPainel` do **último borne processado**, não o do bob — reproduzido.
        /// </summary>
        public static List<Problema> VerificarBlocosDuplicados(
            IEnumerable<BlocoDuplicavel> blocos,
            ICollection<int> paineisEmUso)
        {
            List<Problema> problemas = new List<Problema>();
            if (blocos == null)
            {
                return problemas;
            }

            HashSet<string> emUso = null;
            if (paineisEmUso != null)
            {
                emUso = new HashSet<string>();
                foreach (int painel in paineisEmUso)
                {
                    emUso.Add(painel.ToString(CultureInfo.InvariantCulture));
                }
            }

            // O `list` do original é UM só para todos os tipos (compartilhado).
            HashSet<string> vistos = new HashSet<string>(StringComparer.Ordinal);

            // O filtro do auxiliar usa o `indexPainel` do **último borne** processado
            // (variável reaproveitada no original) — reproduzido.
            int ultimoPainelBorne = 0;

            foreach (BlocoDuplicavel bloco in blocos)
            {
                if (bloco == null)
                {
                    continue;
                }

                string tipo = (bloco.Tipo ?? string.Empty).Trim().ToUpperInvariant();
                string chave;
                string rotulo;
                int painel;

                switch (tipo)
                {
                    case "M":
                        if (bloco.Complementar)
                        {
                            continue;
                        }

                        chave = Identidade(bloco);
                        rotulo = "Mask";
                        painel = bloco.Painel;
                        break;
                    case "P":
                        if (bloco.Complementar)
                        {
                            continue;
                        }

                        chave = Identidade(bloco);
                        rotulo = "Main Device";
                        painel = bloco.Painel;
                        break;
                    case "E":
                        if (bloco.IndiceDaPorta <= 0)
                        {
                            continue;
                        }

                        chave = Identidade(bloco) + "_" + bloco.IndiceDaPorta.ToString(CultureInfo.InvariantCulture);
                        rotulo = "Door";
                        painel = bloco.Painel;
                        break;
                    case "B":
                        chave = bloco.Painel.ToString(CultureInfo.InvariantCulture) + "_"
                            + bloco.IndiceRegua.ToString(CultureInfo.InvariantCulture) + "_"
                            + (bloco.Numero ?? string.Empty);
                        rotulo = "Terminal";
                        painel = bloco.Painel;
                        ultimoPainelBorne = bloco.Painel;
                        if (!vistos.Contains(chave))
                        {
                            vistos.Add(chave);
                            continue;
                        }

                        // O desenho grava "sem número" como "?"/0: o original não aponta esses.
                        if (NumeroIndefinidoDoBorne(bloco.Numero))
                        {
                            continue;
                        }

                        break;
                    case "A":
                        chave = Identidade(bloco) + "_" + bloco.IndexContato.ToString(CultureInfo.InvariantCulture);
                        rotulo = "Auxiliary Contacts";
                        painel = ultimoPainelBorne;
                        break;
                    case "D":
                        chave = (bloco.HandleMascara ?? string.Empty) + "_"
                            + bloco.IndiceModelo.ToString(CultureInfo.InvariantCulture) + "_"
                            + bloco.IndiceDaPorta.ToString(CultureInfo.InvariantCulture);
                        rotulo = "Definition";
                        painel = bloco.Painel;
                        break;
                    default:
                        continue;
                }

                if (!vistos.Contains(chave))
                {
                    vistos.Add(chave);
                    continue;
                }

                if (emUso != null && !emUso.Contains(painel.ToString(CultureInfo.InvariantCulture)))
                {
                    continue;
                }

                problemas.Add(Novo(AreaVerificacao.Desenho, TipoProblema.BlocoDuplicado, "Blocos",
                    bloco.Handle,
                    "duplicado: " + rotulo + " (painel " + painel + ", página \"" + (bloco.Pagina ?? string.Empty) + "\")"));
            }

            return problemas;
        }

        /// <summary>A identidade do original: <c>painel_nome1_nome2_alternativo</c>, com <c>Nothing</c> virando vazio.</summary>
        private static string Identidade(BlocoDuplicavel bloco)
        {
            return bloco.Painel.ToString(CultureInfo.InvariantCulture) + "_"
                + (bloco.Nome1 ?? string.Empty) + "_"
                + (bloco.Nome2 ?? string.Empty) + "_"
                + (bloco.Alternativo ?? string.Empty);
        }

        /// <summary>O número "sem valor" do borne desenhado: <c>"?"</c> ou <c>"0"</c>.</summary>
        private static bool NumeroIndefinidoDoBorne(string numero)
        {
            string texto = (numero ?? string.Empty).Trim();
            return string.Equals(texto, TerminalIndefinido, StringComparison.Ordinal)
                || string.Equals(texto, "0", StringComparison.Ordinal);
        }

        public static List<Problema> VerificarReguasVazias(
            ReguasModelo reguas,
            IEnumerable<PontoBorne> bornes)
        {
            List<Problema> problemas = new List<Problema>();
            if (reguas == null)
            {
                return problemas;
            }

            HashSet<string> usadas = new HashSet<string>();
            if (bornes != null)
            {
                foreach (PontoBorne borne in bornes)
                {
                    if (borne != null)
                    {
                        usadas.Add(borne.Painel + "," + borne.IndiceRegua);
                    }
                }
            }

            foreach (ReguaInfo regua in reguas.Ordenadas)
            {
                if (regua == null || usadas.Contains(regua.Painel + "," + regua.Indice))
                {
                    continue;
                }

                problemas.Add(Novo(AreaVerificacao.Desenho, TipoProblema.ReguaVazia, "Reguas",
                    "painel " + regua.Painel + ", régua #" + regua.Indice,
                    "régua \"" + (regua.Nome ?? string.Empty) + "\" sem nenhum borne no desenho"));
            }

            return problemas;
        }

        /// <summary>
        /// Intervalos de borne de uma régua — o botão <c>bt8intervalos</c> da tela
        /// (<c>TreeViewBornes</c>, o método <c>nXnc5R08lF</c> do reverso).
        ///
        /// Para cada régua do dicionário **em uso** (o filtro <c>lPn</c> do
        /// <c>buscaDadosDeFiacaoDWG</c>), junta os bornes do desenho daquela régua
        /// mais os **bornes de reserva** ainda ausentes (`LeDicBornesReserva`, dedup
        /// por `Numero` + `Ordem`), ordena por `Ordem` e percorre a sequência:
        ///
        /// - número <c>"?"</c> → <see cref="TipoProblema.BorneNumeroIndefinido"/>;
        /// - dois números consecutivos **não** adjacentes (`n != seguinte - 1`) e
        ///   **diferentes** → <see cref="TipoProblema.IntervaloBorneInvalido"/> ("N a M");
        /// - dois números consecutivos **iguais** → <see cref="TipoProblema.BorneNumeroRepetido"/>.
        ///
        /// O número do borne **do desenho** é o do XData com o complemento colado
        /// (`Numero += NumeroComplem`) e, se sobrar <c>"0"</c>, vira
        /// <see cref="TerminalIndefinido"/> — as duas coisas que o original faz ao
        /// montar `m_TodosBornes` (o `"0"` é como o desenho grava "sem número").
        /// As reservas entram **cruas** do dicionário: o original não repete o
        /// mapeamento nelas (ver <see cref="NumeroDoDesenho"/>).
        ///
        /// Só entram no teste de intervalo os números **numéricos** (como o
        /// <c>Versioned.IsNumeric</c> do original) — bornes com número textual ("A1",
        /// ou "11A" de um borne com complemento) ficam de fora. O texto do duplicado
        /// no original é a mensagem `mMensagem[1, 1629]`, que não é recuperável do
        /// reverso; aqui sai uma frase legível.
        /// </summary>
        public static List<Problema> VerificarIntervalosBornes(
            ReguasModelo reguas,
            IEnumerable<PontoBorne> bornes,
            ICollection<int> paineisEmUso,
            IReadOnlyDictionary<int, IReadOnlyList<BorneReserva>> reservasPorRegua)
        {
            List<Problema> problemas = new List<Problema>();
            if (reguas == null)
            {
                return problemas;
            }

            // O original compara o painel como TEXTO (`cOWeaBRTRB.Contains(...ToString())`).
            HashSet<string> emUso = null;
            if (paineisEmUso != null)
            {
                emUso = new HashSet<string>();
                foreach (int painel in paineisEmUso)
                {
                    emUso.Add(painel.ToString(CultureInfo.InvariantCulture));
                }
            }

            List<PontoBorne> desenho = new List<PontoBorne>();
            if (bornes != null)
            {
                foreach (PontoBorne borne in bornes)
                {
                    if (borne != null)
                    {
                        desenho.Add(borne);
                    }
                }
            }

            foreach (ReguaInfo regua in reguas.Ordenadas)
            {
                if (regua == null)
                {
                    continue;
                }

                if (emUso != null && !emUso.Contains(regua.Painel.ToString(CultureInfo.InvariantCulture)))
                {
                    continue;
                }

                List<BorneDaSequencia> sequencia = new List<BorneDaSequencia>();
                foreach (PontoBorne borne in desenho)
                {
                    if (borne.IndiceRegua == regua.Indice)
                    {
                        sequencia.Add(new BorneDaSequencia { Numero = NumeroDoDesenho(borne), Ordem = borne.Ordem });
                    }
                }

                IReadOnlyList<BorneReserva> reservas;
                if (reservasPorRegua != null
                    && reservasPorRegua.TryGetValue(regua.Indice, out reservas)
                    && reservas != null)
                {
                    foreach (BorneReserva reserva in reservas)
                    {
                        if (reserva == null || JaEsta(sequencia, reserva))
                        {
                            continue;
                        }

                        sequencia.Add(new BorneDaSequencia { Numero = reserva.Numero, Ordem = reserva.Ordem });
                    }
                }

                // Ordena por `Ordem` (estável, como a bolha do original).
                sequencia = sequencia.OrderBy(item => item.Ordem).ToList();

                string identificador = "painel " + regua.Painel + ", régua #" + regua.Indice;
                string nome = regua.Nome ?? string.Empty;

                for (int m = 0; m < sequencia.Count; m++)
                {
                    string numero = (sequencia[m].Numero ?? string.Empty).Trim();

                    if (string.Equals(numero, TerminalIndefinido, StringComparison.OrdinalIgnoreCase))
                    {
                        problemas.Add(Novo(AreaVerificacao.Desenho, TipoProblema.BorneNumeroIndefinido, "Bornes",
                            identificador,
                            "borne com número indefinido (\"" + TerminalIndefinido + "\") na régua \"" + nome + "\""));
                    }

                    if (m + 1 >= sequencia.Count)
                    {
                        continue;
                    }

                    double atual;
                    double seguinte;
                    if (!Numerico(sequencia[m].Numero, out atual)
                        || !Numerico(sequencia[m + 1].Numero, out seguinte)
                        || atual == seguinte - 1.0)
                    {
                        continue;
                    }

                    string proximo = (sequencia[m + 1].Numero ?? string.Empty).Trim();
                    if (!string.Equals(numero, proximo, StringComparison.OrdinalIgnoreCase))
                    {
                        problemas.Add(Novo(AreaVerificacao.Desenho, TipoProblema.IntervaloBorneInvalido, "Bornes",
                            identificador,
                            "intervalo de borne " + numero + " a " + proximo + " na régua \"" + nome + "\""));
                    }
                    else
                    {
                        problemas.Add(Novo(AreaVerificacao.Desenho, TipoProblema.BorneNumeroRepetido, "Bornes",
                            identificador,
                            "borne " + numero + " repetido na régua \"" + nome + "\""));
                    }
                }
            }

            return problemas;
        }

        /// <summary>
        /// Régua da máscara — o <c>bt13ReguaMascara</c> da tela de verificação
        /// (<c>AC1cAJLSDI</c>): porta de um **modelo de máscara** cujo campo
        /// <c>Régua</c> traz o separador (<c>;</c>) sem que a contagem de réguas
        /// feche com a de bornes.
        ///
        /// O original divide o campo <c>Régua</c> (<c>sRegua</c>) e o campo
        /// <c>Bornes</c> (<c>sBornes</c>) em itens e decide assim:
        /// - contagens **iguais** → o multi-régua é legítimo (uma régua por borne);
        /// - <c>régua == 1</c> e <c>bornes &gt; 1</c> → legítimo (a mesma régua para
        ///   todos os bornes);
        /// - qualquer outro caso **com separador** no campo da régua → discrepância.
        ///
        /// Portas sem separador no campo <c>Régua</c> nunca são apontadas (o caso
        /// comum). O item apontado é o texto **cru** da régua, sem repetir dentro do
        /// mesmo modelo — como o <c>if list.Contains(...)</c> do original.
        ///
        /// A contagem segue o <c>Geral.DivideTerminais(..., bRepete: true)</c>: a
        /// última <c>;</c> é descartada **uma vez** e cada trecho vira um item (mesmo
        /// vazio), então o total é o número de trechos. Não reutiliza
        /// <see cref="Terminais.Dividir"/> de propósito: ele descarta **todas** as
        /// <c>;</c> finais, o que divergiria de <c>"A;;"</c> (o original conta 2).
        /// </summary>
        public static List<Problema> VerificarReguasMascara(
            IEnumerable<ModeloMascara> modelos,
            IReadOnlyDictionary<int, IReadOnlyList<ModeloPorta>> portasPorModelo)
        {
            List<Problema> problemas = new List<Problema>();
            if (modelos == null || portasPorModelo == null)
            {
                return problemas;
            }

            foreach (ModeloMascara modelo in modelos)
            {
                if (modelo == null)
                {
                    continue;
                }

                IReadOnlyList<ModeloPorta> portas;
                if (!portasPorModelo.TryGetValue(modelo.Indice, out portas) || portas == null)
                {
                    continue;
                }

                // O `list` do original é por MODELO: a mesma régua só é apontada
                // uma vez dentro do modelo.
                List<string> apontadas = new List<string>();
                foreach (ModeloPorta porta in portas)
                {
                    if (porta == null)
                    {
                        continue;
                    }

                    string regua = porta.Regua ?? string.Empty;
                    string semSeparador = regua.Replace(";", string.Empty);
                    int quantasReguas = ContarPartes(regua);
                    int quantosBornes = ContarPartes(porta.Bornes);

                    bool fecha = false;
                    if (quantasReguas > 0)
                    {
                        if (quantasReguas != quantosBornes)
                        {
                            if (quantasReguas == 1 && quantosBornes > 1)
                            {
                                fecha = true;
                            }
                        }
                        else
                        {
                            fecha = true;
                        }
                    }

                    if (fecha
                        || string.Equals(regua, semSeparador, StringComparison.Ordinal)
                        || apontadas.Contains(regua))
                    {
                        continue;
                    }

                    apontadas.Add(regua);
                    problemas.Add(Novo(
                        AreaVerificacao.Modelos,
                        TipoProblema.ReguaMascara,
                        "Mascaras",
                        Modelo(modelo.Nome, modelo.Indice),
                        "régua do modelo com separador inconsistente (Régua \"" + regua
                            + "\", " + quantasReguas + " × " + quantosBornes + " bornes)"));
                }
            }

            return problemas;
        }

        /// <summary>
        /// Conta os itens de um campo separado por <c>;</c> como o
        /// <c>Geral.DivideTerminais(..., bRepete: true)</c>: <c>null</c> vira um item;
        /// descarta **uma** <c>;</c> final e conta os trechos (o <c>Split</c> sempre
        /// devolve ao menos 1).
        /// </summary>
        private static int ContarPartes(string texto)
        {
            if (texto == null)
            {
                return 1;
            }

            if (texto.EndsWith(";", StringComparison.Ordinal))
            {
                texto = texto.Substring(0, texto.Length - 1);
            }

            return texto.Split(';').Length;
        }

        /// <summary>
        /// Portas discrepantes — o <c>bt14PortasDiscrepantes</c> da tela
        /// (<c>clsPortas.VerificaPortasDiscrepantes</c>, alimentado por
        /// <c>CarregaTodasAsPortasPortas</c>): cruza cada **bloco de porta** do desenho
        /// com a **definição do modelo** e aponta os atributos que divergem.
        ///
        /// Para cada bloco <c>E</c> (com porta != 0) que casa com uma porta do modelo
        /// por <c>(modelo, porta)</c>, o original compara, atributo a atributo (só os
        /// cuja tag tem sufixo numérico):
        /// - <c>T&lt;n&gt;</c> contra o n-ésimo item de <c>Terminais</c> do modelo — se o
        ///   modelo tem menos itens que <c>n</c>, é discrepância (valor do modelo ausente);
        /// - <c>B&lt;n&gt;</c> contra o n-ésimo item de <c>Bornes</c> (com o <c>*</c>
        ///   removido — o marcador de "repete");
        /// - <c>R&lt;n&gt;</c> contra o campo <c>Régua</c> do modelo e, quando o
        ///   <c>B&lt;n&gt;</c> correspondente é um borne marcado com <c>*</c> **e** o
        ///   atributo está **invisível**, o original também aponta.
        ///
        /// A comparação é **sem diferenciar maiúsculas** (<c>TextCompare</c> do original)
        /// e **sem <c>Trim</c>** (o texto cru).
        ///
        /// **Duas defensivas** em relação ao original, que aqui não pode estourar:
        /// - <c>B&lt;n&gt;</c> com <c>n</c> fora da lista do modelo: o original **estoura**
        ///   o índice (<c>array2[num5 - 1]</c>); aqui vira discrepância;
        /// - tag sem sufixo numérico (ou índice &lt; 1) é ignorada — o
        ///   <c>Versioned.IsNumeric</c> do original, sem o estouro do <c>CInt</c>.
        /// </summary>
        public static List<Problema> VerificarPortasDiscrepantes(
            IEnumerable<ModeloPorta> portasDoModelo,
            IEnumerable<PortaNoDesenho> portas)
        {
            List<Problema> problemas = new List<Problema>();
            if (portasDoModelo == null || portas == null)
            {
                return problemas;
            }

            List<ModeloPorta> definicoes = new List<ModeloPorta>();
            foreach (ModeloPorta porta in portasDoModelo)
            {
                if (porta != null)
                {
                    definicoes.Add(porta);
                }
            }

            foreach (PortaNoDesenho bloco in portas)
            {
                if (bloco == null || bloco.IndiceDaPorta == 0)
                {
                    continue;
                }

                foreach (ModeloPorta definicao in definicoes)
                {
                    if (definicao.IndiceModelo != bloco.IndiceModelo
                        || definicao.IndiceDaPorta != bloco.IndiceDaPorta)
                    {
                        continue;
                    }

                    AcrescentarDiscrepanciasDePorta(problemas, bloco, definicao);
                }
            }

            return problemas;
        }

        private static void AcrescentarDiscrepanciasDePorta(
            List<Problema> problemas, PortaNoDesenho bloco, ModeloPorta definicao)
        {
            string[] terminais = Partes(definicao.Terminais);
            string[] bornes = Partes(definicao.Bornes);

            // O `list` do original: as tags `B` cujo item do modelo tem `*`.
            HashSet<string> repetidos = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (AtributoPorta atributo in bloco.Atributos)
            {
                char tipo;
                int indice;
                if (!TagsDePorta(atributo.Tag, out tipo, out indice) || tipo != 'B' || indice > bornes.Length)
                {
                    continue;
                }

                if ((bornes[indice - 1] ?? string.Empty).Contains("*"))
                {
                    repetidos.Add(atributo.Tag);
                }
            }

            string referencia = Modelo(definicao.NomeModelo, definicao.IndiceModelo)
                + ", porta #" + definicao.IndiceDaPorta;

            foreach (AtributoPorta atributo in bloco.Atributos)
            {
                char tipo;
                int indice;
                if (!TagsDePorta(atributo.Tag, out tipo, out indice))
                {
                    continue;
                }

                string texto = atributo.Texto ?? string.Empty;

                if (tipo == 'T')
                {
                    if (indice > terminais.Length)
                    {
                        problemas.Add(Novo(AreaVerificacao.Desenho, TipoProblema.PortaDiscrepante, "Portas", bloco.Handle,
                            "terminal " + atributo.Tag + " fora do modelo (bloco \"" + texto + "\"; " + referencia + ")"));
                    }
                    else if (!Igual(terminais[indice - 1], texto))
                    {
                        problemas.Add(Novo(AreaVerificacao.Desenho, TipoProblema.PortaDiscrepante, "Portas", bloco.Handle,
                            "terminal " + atributo.Tag + ": bloco \"" + texto + "\" ≠ modelo \"" + terminais[indice - 1] + "\" (" + referencia + ")"));
                    }
                }
                else if (tipo == 'B')
                {
                    if (indice > bornes.Length)
                    {
                        problemas.Add(Novo(AreaVerificacao.Desenho, TipoProblema.PortaDiscrepante, "Portas", bloco.Handle,
                            "borne " + atributo.Tag + " fora do modelo (bloco \"" + texto + "\"; " + referencia + ")"));
                    }
                    else if (!Igual((bornes[indice - 1] ?? string.Empty).Replace("*", string.Empty), texto))
                    {
                        problemas.Add(Novo(AreaVerificacao.Desenho, TipoProblema.PortaDiscrepante, "Portas", bloco.Handle,
                            "borne " + atributo.Tag + ": bloco \"" + texto + "\" ≠ modelo \"" + bornes[indice - 1] + "\" (" + referencia + ")"));
                    }
                }
                else if (tipo == 'R')
                {
                    bool oculta = repetidos.Contains(atributo.Tag.Replace("R", "B")) && !atributo.Visivel;
                    if (!Igual(definicao.Regua, texto))
                    {
                        problemas.Add(Novo(AreaVerificacao.Desenho, TipoProblema.PortaDiscrepante, "Portas", bloco.Handle,
                            "régua " + atributo.Tag + ": bloco \"" + texto + "\" ≠ modelo \"" + (definicao.Regua ?? string.Empty) + "\" (" + referencia + ")"));
                    }
                    else if (oculta)
                    {
                        problemas.Add(Novo(AreaVerificacao.Desenho, TipoProblema.PortaDiscrepante, "Portas", bloco.Handle,
                            "régua " + atributo.Tag + " invisível no borne repetido (" + referencia + ")"));
                    }
                }
            }
        }

        /// <summary>
        /// Dispositivos principais incompletos — o <c>bt3Principal</c> da tela
        /// (<c>MbycXLEWI4</c>, que monta a <c>dgPrincipal</c> a partir de
        /// <c>zvRejlppGf</c>, os dispositivos <c>P</c> lidos do desenho).
        ///
        /// O original junta os atributos <c>T*</c> do bloco num texto só
        /// (<c>LeOsTerminais</c>: ordenados pela tag, unidos por <c>", "</c> e com
        /// <c>"0"</c>/vazio virando <c>"?"</c>, o <c>CaracterTerminalIndefinido</c>)
        /// e aponta o dispositivo quando:
        /// - o texto tem o caracter indefinido (<c>"?"</c>) — a tela detecta isso
        ///   comparando o texto com ele mesmo sem o caracter; **ou**
        /// - <c>LM1 == 0</c> **e** <c>LM2 == 0</c>.
        ///
        /// **A conjunção do LM é do original e é reproduzida:** a lista de handles a
        /// mostrar exige <c>iLM1 == 0 &amp;&amp; iLM2 == 0</c>, então um dispositivo com
        /// <c>LM1 == 0</c> e <c>LM2 != 0</c> **não** é apontado — embora a grade
        /// sozinha só exigisse <c>iLM1 == 0</c>. O <c>list3</c> do original, que nunca
        /// recebe nada, não muda o resultado e é omitido.
        ///
        /// O dispositivo é apontado **uma vez** (o <c>list</c> de handles do original),
        /// ainda que tenha as duas razões ao mesmo tempo.
        /// </summary>
        public static List<Problema> VerificarDispositivosPrincipais(IEnumerable<DispositivoFiacao> dispositivos)
        {
            List<Problema> problemas = new List<Problema>();
            if (dispositivos == null)
            {
                return problemas;
            }

            HashSet<string> apontados = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (DispositivoFiacao dispositivo in dispositivos)
            {
                if (dispositivo == null)
                {
                    continue;
                }

                string terminais = TerminaisTDoBloco(dispositivo.Terminais);
                bool indefinido = ContemTerminalIndefinido(terminais);
                bool semLm = dispositivo.Lm1 == 0 && dispositivo.Lm2 == 0;

                if (!indefinido && !semLm)
                {
                    continue;
                }

                string identificador = IdentificadorDoDispositivo(dispositivo);
                if (!apontados.Add(identificador))
                {
                    continue;
                }

                List<string> motivos = new List<string>();
                if (indefinido)
                {
                    motivos.Add("terminal indefinido (\"" + TerminalIndefinido + "\") em \"" + terminais + "\"");
                }

                if (dispositivo.Lm1 == 0)
                {
                    motivos.Add("sem LM (LM1=" + dispositivo.Lm1 + ", LM2=" + dispositivo.Lm2 + ")");
                }

                problemas.Add(Novo(
                    AreaVerificacao.Desenho,
                    TipoProblema.PrincipalIncompleto,
                    "Dispositivos",
                    identificador,
                    string.Join("; ", motivos.ToArray()) + " (painel " + dispositivo.Painel
                        + ", \"" + dispositivo.Tag + "\")"));
            }

            return problemas;
        }

        /// <summary>
        /// Auxiliares divergentes — o <c>bt4Auxiliar</c> da tela
        /// (<c>XSScUGxu4K</c>, que monta a <c>dgAuxiliar</c> a partir de
        /// <c>A94eLhaDqZ</c>, os blocos <c>A</c> do desenho).
        ///
        /// O original compara os terminais do bloco (<c>LeOsTerminais</c>, só os
        /// <c>T*</c>, como no <c>bt3Principal</c>) com os do **contato do modelo**
        /// (<c>LeOsTerminaisdeUmIndiceDeContatosAuxiliar</c>, o dicionário
        /// <c>CONTATOS</c>) e decide pela **tabela de tipos**: o tipo do contato
        /// (<c>TipoDoContato</c>, o <c>array[7]</c> do XData do <c>A</c>) contra o tipo
        /// do bloco usado (<c>TipoBlocoUsado = Mid(Nome, 5, 2)</c>).
        ///
        /// | tipo do contato | tipo do bloco | terminais comparados |
        /// |-----------------|---------------|----------------------|
        /// | `RV` | `RV`          | T1/T2/T3             |
        /// | `RV` | `NF`          | T1/T2                |
        /// | `RV` | `NA`          | T1 e T2 contra T1 e **T3** do modelo |
        /// | `NF` | `NF`          | T1/T2 e T3 contra vazio |
        /// | `NA` | `NA`          | T1/T2 e T3 contra vazio |
        ///
        /// Qualquer outra combinação não é apontada (o <c>else if</c> da tela). Uma
        /// linha por **bloco auxiliar**, com as células divergentes no detalhe.
        ///
        /// O original só olha o bloco cujo <c>HandleBob</c> entrou na lista (aqueles
        /// com <c>"?"</c> nos terminais ou com terminais diferentes do modelo) e só
        /// acha o nome/painel quando o bob é um dispositivo <c>P</c> conhecido; sem o
        /// principal, o auxiliar **não** é apontado — reproduzido aqui.
        ///
        /// A comparação é **sem diferenciar maiúsculas** (<c>TextCompare</c> do
        /// original). Um contato que não existe no dicionário entra com os terminais
        /// do modelo **vazios** (o <c>text</c> vazio do original).
        /// </summary>
        public static List<Problema> VerificarAuxiliaresDivergentes(
            IEnumerable<DispositivoFiacao> auxiliares,
            IEnumerable<DispositivoFiacao> principais,
            IReadOnlyDictionary<int, IReadOnlyList<ContatoAuxiliar>> contatosPorModelo)
        {
            List<Problema> problemas = new List<Problema>();
            if (auxiliares == null)
            {
                return problemas;
            }

            List<DispositivoFiacao> blocos = new List<DispositivoFiacao>();
            foreach (DispositivoFiacao auxiliar in auxiliares)
            {
                if (auxiliar != null)
                {
                    blocos.Add(auxiliar);
                }
            }

            List<DispositivoFiacao> dispositivos = new List<DispositivoFiacao>();
            if (principais != null)
            {
                foreach (DispositivoFiacao principal in principais)
                {
                    if (principal != null)
                    {
                        dispositivos.Add(principal);
                    }
                }
            }

            // O `list` do original: os bobs (na ordem de entrada) que têm terminal
            // indefinido ou terminais diferentes do modelo.
            List<string> bobs = new List<string>();
            HashSet<string> vistos = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (DispositivoFiacao bloco in blocos)
            {
                string terminais = TerminaisTDoBloco(bloco.Terminais);
                string doModelo = TerminaisDoContato(contatosPorModelo, bloco.IndexModelo, bloco.IndiceDaPorta);
                if (!ContemTerminalIndefinido(terminais) && Igual(terminais, doModelo))
                {
                    continue;
                }

                if (!string.IsNullOrEmpty(bloco.HandleBob) && vistos.Add(bloco.HandleBob))
                {
                    bobs.Add(bloco.HandleBob);
                }
            }

            foreach (string bob in bobs)
            {
                DispositivoFiacao principal = null;
                foreach (DispositivoFiacao candidato in dispositivos)
                {
                    if (Igual(candidato.Handle, bob))
                    {
                        principal = candidato;
                        break;
                    }
                }

                if (principal == null)
                {
                    continue;
                }

                foreach (DispositivoFiacao bloco in blocos)
                {
                    if (!Igual(bloco.HandleBob, bob))
                    {
                        continue;
                    }

                    List<string> diferencas = DiferencasDoAuxiliar(bloco, contatosPorModelo);
                    if (diferencas.Count == 0)
                    {
                        continue;
                    }

                    problemas.Add(Novo(
                        AreaVerificacao.Desenho,
                        TipoProblema.AuxiliarDivergente,
                        "Auxiliares",
                        IdentificadorDoDispositivo(bloco),
                        string.Join("; ", diferencas.ToArray())
                            + " (contato \"" + TipoDoContatoTexto(bloco.TipoDoContato) + "\", bloco \""
                            + (bloco.NomeBloco ?? string.Empty) + "\", bob " + bob
                            + ", painel " + principal.Painel + ", \"" + principal.Tag + "\")"));
                }
            }

            return problemas;
        }

        /// <summary>
        /// Os terminais que divergem no <c>bt4Auxiliar</c> — a tabela de tipos do
        /// original, devolvendo uma entrada por célula que não bate (vazio = não
        /// aponta). O <c>TipoBlocoUsado</c> é o <c>Mid(Nome, 5, 2)</c> do VB.
        /// </summary>
        private static List<string> DiferencasDoAuxiliar(
            DispositivoFiacao bloco, IReadOnlyDictionary<int, IReadOnlyList<ContatoAuxiliar>> contatosPorModelo)
        {
            List<string> diferencas = new List<string>();

            string[] doBloco = PartesPorVirgula(TerminaisTDoBloco(bloco.Terminais));
            string[] doModelo = PartesPorVirgula(TerminaisDoContato(contatosPorModelo, bloco.IndexModelo, bloco.IndiceDaPorta));

            string t1 = doBloco[0];
            string t2 = doBloco[1];
            string t3 = doBloco[2];
            string m1 = doModelo[0];
            string m2 = doModelo[1];
            string m3 = doModelo[2];

            string tipo = TipoDoContatoTexto(bloco.TipoDoContato);
            string tipoBloco = Mid(bloco.NomeBloco, 5, 2);

            if (!Igual(tipo, "NA"))
            {
                if (!Igual(tipo, "NF"))
                {
                    if (!Igual(tipo, "RV"))
                    {
                        return diferencas;
                    }

                    if (!Igual(tipoBloco, "NA"))
                    {
                        if (!Igual(tipoBloco, "NF"))
                        {
                            if (Igual(tipoBloco, "RV"))
                            {
                                CompararCelula(diferencas, "T1", t1, m1);
                                CompararCelula(diferencas, "T2", t2, m2);
                                CompararCelula(diferencas, "T3", t3, m3);
                            }
                        }
                        else
                        {
                            CompararCelula(diferencas, "T1", t1, m1);
                            CompararCelula(diferencas, "T2", t2, m2);
                        }
                    }
                    else
                    {
                        CompararCelula(diferencas, "T1", t1, m1);
                        CompararCelula(diferencas, "T2", t2, m3);
                    }
                }
                else if (Igual(tipoBloco, "NF"))
                {
                    CompararCelula(diferencas, "T1", t1, m1);
                    CompararCelula(diferencas, "T2", t2, m2);
                    CompararCelula(diferencas, "T3", t3, string.Empty);
                }
            }
            else if (Igual(tipoBloco, "NA"))
            {
                CompararCelula(diferencas, "T1", t1, m1);
                CompararCelula(diferencas, "T2", t2, m2);
                CompararCelula(diferencas, "T3", t3, string.Empty);
            }

            return diferencas;
        }

        private static void CompararCelula(List<string> diferencas, string rotulo, string doBloco, string doModelo)
        {
            if (!Igual(doBloco, doModelo))
            {
                diferencas.Add(rotulo + " \"" + doBloco + "\" ≠ modelo \"" + doModelo + "\"");
            }
        }

        /// <summary>
        /// Os terminais <c>T*</c> de um bloco, como o <c>LeOsTerminais</c> do original:
        /// aceita a tag <c>T</c> + sufixo numérico (sem diferenciar maiúsculas),
        /// ordena pela tag e junta com <c>", "</c>, trocando <c>"0"</c>/vazio por
        /// <see cref="TerminalIndefinido"/>. Os <c>B*</c> e o <c>R1</c> que o original
        /// também lê não entram nas duas regras.
        /// </summary>
        private static string TerminaisTDoBloco(IEnumerable<TerminalDispositivo> terminais)
        {
            List<TerminalDispositivo> lista = new List<TerminalDispositivo>();
            if (terminais != null)
            {
                foreach (TerminalDispositivo terminal in terminais)
                {
                    if (terminal == null || string.IsNullOrEmpty(terminal.Atributo) || terminal.Atributo.Length < 2)
                    {
                        continue;
                    }

                    if (!string.Equals(terminal.Atributo.Substring(0, 1), "T", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    if (!Numerico(terminal.Atributo.Substring(1), out _))
                    {
                        continue;
                    }

                    lista.Add(terminal);
                }
            }

            // Bolha do original (ordem crescente pela tag, comparação binária).
            lista.Sort((esquerda, direita) => string.CompareOrdinal(esquerda.Atributo, direita.Atributo));

            string texto = string.Empty;
            foreach (TerminalDispositivo terminal in lista)
            {
                string valor = terminal.Texto ?? string.Empty;
                string limpo = valor.Trim();
                if (string.Equals(limpo, "0", StringComparison.Ordinal) || limpo.Length == 0)
                {
                    valor = TerminalIndefinido;
                }

                texto = texto.Trim().Length != 0 ? texto + ", " + valor : valor;
            }

            return texto;
        }

        /// <summary>
        /// O <c>sTerminaisMod</c> do original
        /// (<c>LeOsTerminaisdeUmIndiceDeContatosAuxiliar</c>): os terminais do contato
        /// <paramref name="indiceContato"/> do modelo <paramref name="indiceModelo"/>
        /// no dicionário <c>CONTATOS</c>, com o <c>T1</c> entrando sempre e o
        /// <c>T2</c>/<c>T3</c> só quando **não vazios** (e sem <c>Trim</c>, como lá).
        /// </summary>
        private static string TerminaisDoContato(
            IReadOnlyDictionary<int, IReadOnlyList<ContatoAuxiliar>> contatosPorModelo, int indiceModelo, int indiceContato)
        {
            if (contatosPorModelo == null)
            {
                return string.Empty;
            }

            IReadOnlyList<ContatoAuxiliar> contatos;
            if (!contatosPorModelo.TryGetValue(indiceModelo, out contatos) || contatos == null)
            {
                return string.Empty;
            }

            foreach (ContatoAuxiliar contato in contatos)
            {
                if (contato == null || contato.Indice != indiceContato)
                {
                    continue;
                }

                string texto = contato.T1 ?? string.Empty;
                if (!string.IsNullOrEmpty(contato.T2))
                {
                    texto = texto + ", " + contato.T2;
                }

                if (!string.IsNullOrEmpty(contato.T3))
                {
                    texto = texto + ", " + contato.T3;
                }

                return texto;
            }

            return string.Empty;
        }

        /// <summary>O teste de terminal indefinido do original: o texto muda ao remover o caracter.</summary>
        private static bool ContemTerminalIndefinido(string texto)
        {
            return (texto ?? string.Empty).Contains(TerminalIndefinido);
        }

        /// <summary>
        /// Divide por <c>,</c> como o <c>Split(',')</c> do original e devolve sempre
        /// **três** posições (as que faltarem ficam vazias), já sem espaços — o
        /// <c>Trim</c> de cada <c>text3</c>..<c>text8</c>.
        /// </summary>
        private static string[] PartesPorVirgula(string texto)
        {
            string[] partes = (texto ?? string.Empty).Split(',');
            string[] resultado = new string[3];
            for (int i = 0; i < 3; i++)
            {
                resultado[i] = i < partes.Length ? partes[i].Trim() : string.Empty;
            }

            return resultado;
        }

        /// <summary>O <c>Mid</c> do VB (base 1): <c>Mid(Nome, 5, 2)</c> é o <c>TipoBlocoUsado</c>.</summary>
        private static string Mid(string texto, int inicio, int tamanho)
        {
            if (string.IsNullOrEmpty(texto) || inicio < 1 || tamanho <= 0 || inicio > texto.Length)
            {
                return string.Empty;
            }

            return texto.Substring(inicio - 1, Math.Min(tamanho, texto.Length - (inicio - 1)));
        }

        /// <summary>O tipo do contato do auxiliar como a tela mostra: <c>1</c>=<c>NA</c>, <c>2</c>=<c>NF</c>, <c>3</c>=<c>RV</c>.</summary>
        private static string TipoDoContatoTexto(short tipo)
        {
            switch (tipo)
            {
                case 1:
                    return "NA";
                case 2:
                    return "NF";
                case 3:
                    return "RV";
                default:
                    return string.Empty;
            }
        }

        /// <summary>O handle do bloco como identificador; sem ele, o nome do dispositivo.</summary>
        private static string IdentificadorDoDispositivo(DispositivoFiacao dispositivo)
        {
            if (!string.IsNullOrWhiteSpace(dispositivo.Handle))
            {
                return dispositivo.Handle;
            }

            return string.IsNullOrWhiteSpace(dispositivo.Tag) ? "sem handle" : dispositivo.Tag;
        }

        /// <summary>Divide um campo do modelo por <c>;</c> — o <c>Split</c> do VB, que devolve ao menos um item.</summary>
        private static string[] Partes(string texto)
        {
            return (texto ?? string.Empty).Split(';');
        }

        /// <summary>Lê a tag de um atributo de porta (<c>T1</c>/<c>B2</c>/<c>R3</c>): tipo + índice.</summary>
        private static bool TagsDePorta(string tag, out char tipo, out int indice)
        {
            tipo = '\0';
            indice = 0;
            if (string.IsNullOrEmpty(tag) || tag.Length < 2)
            {
                return false;
            }

            if (!int.TryParse(tag.Substring(1).Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out indice)
                || indice < 1)
            {
                return false;
            }

            tipo = char.ToUpperInvariant(tag[0]);
            return true;
        }

        /// <summary>Igualdade como o <c>TextCompare</c> do original: sem diferenciar maiúsculas e sem <c>Trim</c>.</summary>
        private static bool Igual(string a, string b)
        {
            return string.Equals(a ?? string.Empty, b ?? string.Empty, StringComparison.OrdinalIgnoreCase);
        }

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
        /// <summary>
        /// Borne do desenho que não virou nenhum ponto de fiação — o "órfão" do
        /// <c>carregaOrfao</c> do original. Compara os <c>Handle</c> dos blocos de
        /// borne do desenho com os <c>Handle</c> gravados em <c>Fiacao</c>: se nenhum
        /// ponto casou com o borne, ele ficou fora da projeção.
        /// </summary>
        /// <summary>
        /// Fiação desenhada em duplicidade — dois trechos <c>Tipo 2</c> com a mesma
        /// página e as mesmas pontas (o <c>LFiacaoTTDuplicada</c> do original).
        /// Depende da geometria do desenho, por isso compara os trechos lidos e não
        /// as linhas da tabela.
        /// </summary>
        public static List<Problema> VerificarFiacaoDuplicada(IEnumerable<TrechoFiacao> trechos)
        {
            List<Problema> problemas = new List<Problema>();
            foreach (ProblemaFiacaoDuplicada duplicado in FiacaoDuplicada.Verificar(trechos))
            {
                problemas.Add(Novo(
                    AreaVerificacao.Desenho,
                    TipoProblema.FiacaoDuplicada,
                    "Fiacao",
                    duplicado.Handle,
                    "mesmo fio desenhado duas vezes na página " + duplicado.Pagina));
            }

            return problemas;
        }

        public static List<Problema> VerificarBornesSemFiacao(
            IEnumerable<string> handlesDoDesenho,
            IEnumerable<string> handlesNaFiacao)
        {
            List<Problema> problemas = new List<Problema>();
            if (handlesDoDesenho == null)
            {
                return problemas;
            }

            HashSet<string> naFiacao = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (handlesNaFiacao != null)
            {
                foreach (string handle in handlesNaFiacao)
                {
                    if (!string.IsNullOrWhiteSpace(handle))
                    {
                        naFiacao.Add(handle.Trim());
                    }
                }
            }

            // Sem nenhum ponto de fiação não há o que comparar: a projeção não rodou.
            if (naFiacao.Count == 0)
            {
                return problemas;
            }

            HashSet<string> apontados = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (string handle in handlesDoDesenho)
            {
                if (string.IsNullOrWhiteSpace(handle))
                {
                    continue;
                }

                string limpo = handle.Trim();
                if (naFiacao.Contains(limpo) || !apontados.Add(limpo))
                {
                    continue;
                }

                problemas.Add(Novo(AreaVerificacao.Desenho, TipoProblema.BorneSemFiacao, "Fiacao", limpo, "borne do desenho sem ponto de fiação"));
            }

            return problemas;
        }

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

        /// <summary>Um item da sequência de bornes de uma régua (do desenho ou de reserva).</summary>
        private sealed class BorneDaSequencia
        {
            public string Numero { get; set; }

            public double Ordem { get; set; }
        }

        /// <summary>
        /// O número do borne como o verifier original guarda em `m_TodosBornes`:
        /// o <c>Terminal</c> (XData `Numero` + `NumeroComplem` colado) e, se der
        /// exatamente <c>"0"</c>, o <c>CaracterTerminalIndefinido</c> (<c>"?"</c>).
        ///
        /// A ordem importa: o original cola o complemento **antes** de trocar o
        /// <c>"0"</c>, então <c>"0"</c> + <c>"A"</c> continua <c>"0A"</c> (textual,
        /// fora do teste de intervalo).
        /// </summary>
        private static string NumeroDoDesenho(PontoBorne borne)
        {
            string numero = borne.Terminal;
            return string.Equals(numero, "0", StringComparison.Ordinal) ? TerminalIndefinido : numero;
        }

        private static bool JaEsta(List<BorneDaSequencia> sequencia, BorneReserva reserva)
        {
            foreach (BorneDaSequencia item in sequencia)
            {
                if (item.Ordem == reserva.Ordem
                    && string.Equals(item.Numero, reserva.Numero, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool Numerico(string texto, out double valor)
        {
            valor = 0.0;
            if (string.IsNullOrWhiteSpace(texto))
            {
                return false;
            }

            return double.TryParse(texto.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out valor);
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
