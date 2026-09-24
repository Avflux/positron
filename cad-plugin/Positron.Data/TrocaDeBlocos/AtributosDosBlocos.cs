using System;
using System.Collections.Generic;
using Positron.Data.Interface;

namespace Positron.Data.TrocaDeBlocos
{
    /// <summary>
    /// Um atributo de bloco lido do desenho — o <c>structureAtributos</c> do
    /// <c>clsTrocaEditaBlocosMat</c> reduzido ao que a regra usa (o handle do bloco, o nome dele,
    /// a tag, o valor e a visibilidade).
    /// </summary>
    public sealed class AtributoDoBloco
    {
        /// <summary>O handle do <b>bloco</b> (o <c>sHandleBlocoo</c>/<c>sHandleBlocooNovo</c> do original).</summary>
        public string HandleDoBloco { get; set; }

        /// <summary>O nome do bloco (o <c>Name</c> do <c>BlockReference</c>).</summary>
        public string NomeDoBloco { get; set; }

        /// <summary>A tag do atributo (o <c>sTag</c>).</summary>
        public string Tag { get; set; }

        /// <summary>O texto do atributo (o <c>sValor</c>).</summary>
        public string Valor { get; set; }

        /// <summary>A visibilidade lida (o <c>sVisible</c> — só os invisíveis entram no buffer).</summary>
        public bool Visivel { get; set; }
    }

    /// <summary>
    /// O que o <c>frmTrocaEditaBlocos</c> dispara **depois** da troca
    /// (<c>frmTrocaEditaBlocos.cs:695-740</c>): as três marcas que o nome do bloco carrega
    /// (<c>_A_</c>, <c>_B_</c>, <c>_E_</c>) decidem quais correções rodam.
    /// </summary>
    public sealed class CorrecoesPosTroca
    {
        /// <summary>Algum bloco com <c>_A_</c>: os contatos auxiliares (o <c>CorrigeBlocosContatosAux</c>).</summary>
        public bool ContatosAuxiliares { get; set; }

        /// <summary>Algum bloco com <c>_B_</c>: o painel/ET1 dos bornes (o <c>CorrigePainelET1DosBornes</c>).</summary>
        public bool PainelEt1 { get; set; }

        /// <summary>
        /// Algum bloco com <c>_E_</c> **ou** <c>_A_</c>: o <c>PreencheNovosAtributos</c> — o
        /// original usa <c>flag | flag3</c>, então o caso <c>_A_</c> dispara os dois
        /// (<c>CorrigeBlocosContatosAux</c> e o preenchimento).
        /// </summary>
        public bool PreencheAtributos { get; set; }
    }

    /// <summary>
    /// As decisões da **troca de blocos** do original (<c>clsTrocaEditaBlocos.cs</c>: os cinco
    /// comandos <c>LeAtributos</c>, <c>LeTodosAtributos</c>, <c>CorrigeAtributos</c>,
    /// <c>CorrigeAtributosSemMsg</c> e <c>PreencheNovosAtributos</c>, mais o que a tela
    /// <c>frmTrocaEditaBlocos</c> faz com eles).
    ///
    /// O **buffer** é o do original e a regra dele é uma só: entram os atributos
    /// **invisíveis** — é neles que a troca de bloco guarda o que o projetista não vê na tela, e é
    /// por eles que o valor atravessa a substituição do bloco.
    /// </summary>
    /// <remarks>
    /// **O que fica fora, decidido:** (1) o filtro de &quot;bloco do Elétron&quot; do
    /// <c>LeAtributos</c> (<c>clsBlocos.TipoBlocoDoEletron</c>, <c>clsBlocos.cs:2025</c>) — ele lê o
    /// <c>XData.ToString()</c> cru do bloco e ainda para o <c>PointMonitorToolTips</c> do CAD:
    /// é ambiente/UI, e aqui o recorte por **nome** (<c>POSITRON_BLOCOS</c>) já limita a varredura
    /// (o <c>LeTodosAtributos</c> do original **não** tem filtro nenhum, e é ele que a medição usa);
    /// (2) a troca em si (<c>insereUmBlocoParaSubstituir</c>/<c>ApagaOsBlocosAntigos</c>/
    /// <c>corrigeOsHandlesDosBlocos</c>, que importam um DWG e apagam blocos — pilha de importação)
    /// e (3) o <c>AtualizaAsPortasTrocadas</c> do ramo <c>_E_</c> do
    /// <c>PreencheNovosAtributos</c>, que precisa da matriz de handles que a troca produz.
    /// </remarks>
    public static class AtributosDosBlocos
    {
        /// <summary>O <c>_E_</c> do nome do bloco: a família das portas (o ramo do <c>PreencheNovosAtributos</c>).</summary>
        public const string MarcadorPortas = "_E_";

        /// <summary>O <c>_A_</c> do nome do bloco: os contatos auxiliares.</summary>
        public const string MarcadorContatosAuxiliares = "_A_";

        /// <summary>O <c>_B_</c> do nome do bloco: os bornes (o painel/ET1).</summary>
        public const string MarcadorBornes = "_B_";

        /// <summary>
        /// O buffer do <c>LeAtributos</c>/<c>LeTodosAtributos</c>: os atributos **invisíveis**, na
        /// ordem de leitura. Com <paramref name="nomesDeBloco"/> preenchido, só os dos blocos
        /// com aquele nome — a comparação é sem caixa, como o <c>mNomeBlocos.Contains(Upper)</c>
        /// do original (a lista chega em maiúscula).
        /// </summary>
        public static IReadOnlyList<AtributoDoBloco> Invisiveis(
            IEnumerable<AtributoDoBloco> atributos,
            IReadOnlyCollection<string> nomesDeBloco)
        {
            List<AtributoDoBloco> buffer = new List<AtributoDoBloco>();
            if (atributos == null)
            {
                return buffer;
            }

            foreach (AtributoDoBloco atributo in atributos)
            {
                if (atributo == null || atributo.Visivel)
                {
                    continue;
                }

                if (!NomePermitido(atributo.NomeDoBloco, nomesDeBloco))
                {
                    continue;
                }

                buffer.Add(atributo);
            }

            return buffer;
        }

        /// <summary>
        /// Os nomes dos blocos da lista de atributos — únicos, em **maiúscula** e na ordem de
        /// leitura (o <c>lBlocosExistentesTrocados</c> do original, que o <c>LeAtributos</c>
        /// preenche pelo parâmetro chamado <c>lBlocosNaoExistentes</c> — o nome do parâmetro é
        /// enganoso lá e o dado é este). A lista que entra é a **leitura inteira**, não só o
        /// buffer: o original registra o bloco assim que ele tem algum atributo.
        /// </summary>
        public static IReadOnlyList<string> NomesDosBlocos(IReadOnlyList<AtributoDoBloco> buffer)
        {
            List<string> nomes = new List<string>();
            if (buffer == null)
            {
                return nomes;
            }

            foreach (AtributoDoBloco atributo in buffer)
            {
                string nome = (atributo.NomeDoBloco ?? string.Empty).ToUpperInvariant();
                if (nome.Length == 0 || nomes.Contains(nome))
                {
                    continue;
                }

                nomes.Add(nome);
            }

            return nomes;
        }

        /// <summary>
        /// Os handles dos blocos do buffer — únicos e na ordem de leitura (o
        /// <c>lBlocosAlterados</c> do original).
        /// </summary>
        public static IReadOnlyList<string> HandlesDosBlocos(IReadOnlyList<AtributoDoBloco> buffer)
        {
            List<string> handles = new List<string>();
            if (buffer == null)
            {
                return handles;
            }

            foreach (AtributoDoBloco atributo in buffer)
            {
                string handle = atributo.HandleDoBloco ?? string.Empty;
                if (handle.Length == 0 || handles.Contains(handle))
                {
                    continue;
                }

                handles.Add(handle);
            }

            return handles;
        }

        /// <summary>
        /// O texto que o <c>CorrigeAtributos</c> mostra
        /// (<c>clsTrocaEditaBlocos.cs:141-169</c>), montado com as mesmas
        /// <c>mMensagem</c> do original — e com as mesmas trocas de título:
        /// <c>1298</c> no singular e <c>1302</c> com mais de um; o &quot;Blocos Trocados&quot;
        /// (<c>1349</c>) **substitui** o título quando algum handle mudou na troca; e a cauda dos
        /// que não existem usa <c>1300</c> quando a lista tem <c>;</c> e <c>1299</c> quando é um só,
        /// sempre com o <c>1301</c> (&quot;no Desenho&quot;) colado no texto.
        /// </summary>
        public static string Resumo(int blocosExistentes, int blocosTrocados, string blocosNaoExistentes)
        {
            string texto = blocosExistentes + " " + MensagensDoReverso.TipoDeBlocoTrocado;
            if (blocosExistentes > 1)
            {
                texto = blocosExistentes + " " + MensagensDoReverso.TiposDeBlocosTrocados;
            }

            if (blocosTrocados >= 1)
            {
                texto = MensagensDoReverso.BlocosTrocados + "  " + blocosTrocados;
            }

            string cauda = string.Empty;
            string naoExistentes = blocosNaoExistentes ?? string.Empty;
            if (naoExistentes.Length != 0)
            {
                string abertura = naoExistentes.Contains(";")
                    ? MensagensDoReverso.NaoExistemEssesBlocos
                    : MensagensDoReverso.NaoExisteEsseBloco;

                cauda = "\r\n\r\n" + abertura + " " + MensagensDoReverso.NoDesenho + naoExistentes;
            }

            return texto + cauda;
        }

        /// <summary>O bloco é da família das portas? (o <c>Contains("_E_")</c> do <c>PreencheNovosAtributos</c>).</summary>
        public static bool EhDosPortas(string nomeDoBloco)
        {
            return ContemMarcador(nomeDoBloco, MarcadorPortas);
        }

        /// <summary>O bloco é dos contatos auxiliares? (o <c>Contains("_A_")</c>).</summary>
        public static bool EhDosContatosAuxiliares(string nomeDoBloco)
        {
            return ContemMarcador(nomeDoBloco, MarcadorContatosAuxiliares);
        }

        /// <summary>O bloco é dos bornes? (o <c>Contains("_B_")</c> da tela).</summary>
        public static bool EhDosBornes(string nomeDoBloco)
        {
            return ContemMarcador(nomeDoBloco, MarcadorBornes);
        }

        /// <summary>
        /// A lista dos blocos que **não** existem no desenho, do jeito que a tela a monta
        /// (<c>frmTrocaEditaBlocos.cs:718-724</c>): o primeiro entra com uma quebra de linha e
        /// **sem** maiúscula, os seguintes entram em maiúscula e separados por <c>;</c> — é essa
        /// diferença que o resumo usa para escolher entre o singular e o plural.
        /// </summary>
        public static string ListaDosNaoExistentes(string atual, string nomeDoBloco)
        {
            string nome = nomeDoBloco ?? string.Empty;
            if (string.IsNullOrEmpty(atual))
            {
                return "\r\n" + nome;
            }

            return atual + ";\r\n" + nome.ToUpperInvariant();
        }

        /// <summary>
        /// O que a tela dispara depois da troca: para cada bloco que existe no desenho, as três
        /// marcas do nome ligam as correções (<c>frmTrocaEditaBlocos.cs:695-740</c>) — e o
        /// <c>PreencheNovosAtributos</c> vem com <c>flag | flag3</c>, ou seja o <c>_A_</c> também
        /// o dispara.
        /// </summary>
        public static CorrecoesPosTroca AcoesPosTroca(IEnumerable<string> nomesExistentes)
        {
            CorrecoesPosTroca acoes = new CorrecoesPosTroca();
            if (nomesExistentes == null)
            {
                return acoes;
            }

            bool contatos = false;
            bool bornes = false;
            bool portas = false;
            foreach (string nome in nomesExistentes)
            {
                if (EhDosContatosAuxiliares(nome))
                {
                    contatos = true;
                }

                if (EhDosBornes(nome))
                {
                    bornes = true;
                }

                if (EhDosPortas(nome))
                {
                    portas = true;
                }
            }

            acoes.ContatosAuxiliares = contatos;
            acoes.PainelEt1 = bornes;
            acoes.PreencheAtributos = contatos || portas;
            return acoes;
        }

        private static bool NomePermitido(string nome, IReadOnlyCollection<string> nomesDeBloco)
        {
            if (nomesDeBloco == null || nomesDeBloco.Count == 0)
            {
                return true;
            }

            string procurado = (nome ?? string.Empty).ToUpperInvariant();
            foreach (string permitido in nomesDeBloco)
            {
                if (string.Equals(procurado, (permitido ?? string.Empty).ToUpperInvariant(), StringComparison.Ordinal))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ContemMarcador(string nomeDoBloco, string marcador)
        {
            return (nomeDoBloco ?? string.Empty).IndexOf(marcador, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
