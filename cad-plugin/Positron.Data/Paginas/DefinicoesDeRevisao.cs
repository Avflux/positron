using System;
using System.Collections.Generic;

namespace Positron.Data.Paginas
{
    /// <summary>
    /// As posições que o formato admite por página — o <c>maxCapa</c>/<c>maxCorpo</c> que o
    /// <c>carregaConfiguracaoRevisao</c> do reverso conta pelos atributos do bloco de formato.
    /// </summary>
    public sealed class PosicoesDoFormato
    {
        /// <summary>Posições da capa (os atributos <c>REV0..7</c> no layer da capa).</summary>
        public int Capa { get; set; }

        /// <summary>Posições do corpo (os atributos <c>REV0..7</c> no layer <c>-1</c>).</summary>
        public int Corpo { get; set; }

        /// <summary>Nenhuma posição — o desenho não tem o formato (ou ele não tem tags <c>REV</c>).</summary>
        public bool Vazio
        {
            get { return Capa == 0 && Corpo == 0; }
        }
    }

    /// <summary>
    /// O que o <c>ATTSYNC</c> faz numa referência em relação à definição do bloco: o que **falta**
    /// (tags da definição que a referência não tem — acrescentar) e o que **sobra** (tags da
    /// referência que a definição não tem — remover). A comparação é sem caixa.
    /// </summary>
    public sealed class PlanoDeSincronizacao
    {
        internal PlanoDeSincronizacao(List<string> acrescentar, List<string> remover)
        {
            Acrescentar = acrescentar;
            Remover = remover;
        }

        /// <summary>Tags da definição que a referência não tem (entram com o padrão da definição).</summary>
        public IReadOnlyList<string> Acrescentar { get; private set; }

        /// <summary>Tags da referência que a definição não tem (saem).</summary>
        public IReadOnlyList<string> Remover { get; private set; }

        /// <summary>A referência já casa com a definição.</summary>
        public bool Vazio
        {
            get { return Acrescentar.Count == 0 && Remover.Count == 0; }
        }
    }

    /// <summary>
    /// A sincronização dos atributos de uma referência com a definição do bloco — a parte
    /// **estrutural** do <c>ATTSYNC</c> que o <c>verificaCriaBlocoRevisao</c> dispara por referência
    /// depois de refazer a definição: acrescenta os atributos que faltam e tira os que sobraram.
    ///
    /// **Divergência deliberada:** o <c>ATTSYNC</c> do CAD é um comando e o recoder reproduz só a
    /// estrutura (as tags), **preservando os valores já gravados** — rebobinar os valores para o
    /// padrão da definição (que nas cópias é vazio) apagaria a revisão das páginas não editadas.
    /// </summary>
    public static class SincronizacaoDeAtributos
    {
        public static PlanoDeSincronizacao Calcular(
            IReadOnlyList<string> tagsDaDefinicao,
            IReadOnlyList<string> tagsDaReferencia)
        {
            List<string> definicao = Normalizar(tagsDaDefinicao);
            List<string> referencia = Normalizar(tagsDaReferencia);

            List<string> acrescentar = new List<string>();
            List<string> remover = new List<string>();

            // O que a definição tem e a referência não (conserva a ordem/grafia da definição).
            if (tagsDaDefinicao != null)
            {
                foreach (string tag in tagsDaDefinicao)
                {
                    string texto = (tag ?? string.Empty).Trim();
                    if (texto.Length > 0 && !referencia.Contains(texto.ToLowerInvariant()))
                    {
                        acrescentar.Add(texto);
                    }
                }
            }

            // O que a referência tem e a definição não (conserva a ordem/grafia da referência).
            if (tagsDaReferencia != null)
            {
                foreach (string tag in tagsDaReferencia)
                {
                    string texto = (tag ?? string.Empty).Trim();
                    if (texto.Length > 0 && !definicao.Contains(texto.ToLowerInvariant()) && !remover.Contains(texto))
                    {
                        remover.Add(texto);
                    }
                }
            }

            return new PlanoDeSincronizacao(acrescentar, remover);
        }

        private static List<string> Normalizar(IReadOnlyList<string> tags)
        {
            List<string> normalizadas = new List<string>();
            if (tags == null)
            {
                return normalizadas;
            }

            foreach (string tag in tags)
            {
                string texto = (tag ?? string.Empty).Trim();
                if (texto.Length > 0)
                {
                    normalizadas.Add(texto.ToLowerInvariant());
                }
            }

            return normalizadas;
        }
    }

    /// <summary>
    /// A criação das **definições** dos blocos de revisão completa — o <c>verificaCriaBlocoRevisao</c>
    /// do <c>Revisao.cs</c> do reverso: para cada posição que o formato admite, o original garante uma
    /// definição <c>Revisao_Capa{pos-1}</c> ou <c>Revisao_Corpo{pos-1}</c>, vazia e (re)preenchida com
    /// cópias dos <c>AttributeDefinition</c> do **bloco de formato** cujo layer e tag casam.
    ///
    /// A regra é **pura** (só dados): quem mexe no desenho é o <c>RevisoesDoDesenho</c>. As três
    /// decisões ficam aqui:
    /// - <see cref="Nome"/> — o nome da definição, do layer alvo (a capa ou o <c>-1</c>) e o dígito
    ///   <c>tipo</c> (o <c>Revisao_Capa{tipo}</c>/<c>Revisao_Corpo{tipo}</c>);
    /// - <see cref="Copiar"/> — se um atributo do formato entra na definição (layer igual, tag
    ///   protegida, e o tag **termina** com o dígito);
    /// - <see cref="Contar"/> — o <c>maxCapa</c>/<c>maxCorpo</c> do <c>carregaConfiguracaoRevisao</c>.
    ///
    /// O conjunto de tags protegidas é o <c>attRevProtCollection</c> do original: as seis famílias
    /// (<c>REV</c>, <c>DESC</c>, <c>DATA</c>, <c>ELAB</c>, <c>VERIF</c>, <c>APROV</c>) com um dígito de
    /// <c>0</c> a <c>7</c> — 48 tags. A comparação é sem caixa (o recoder é tolerante onde o original
    /// é exato; a diferença só aparece com um formato fora do padrão).
    /// </summary>
    public static class DefinicoesDeRevisao
    {
        /// <summary>As 48 tags do <c>attRevProtCollection</c> (seis famílias × dígitos 0..7).</summary>
        public static readonly IReadOnlyList<string> TagsProtegidas = MontarTagsProtegidas();

        /// <summary>
        /// O nome da definição do bloco de revisão: <c>Revisao_Capa{tipo}</c> quando o layer é a
        /// capa, <c>Revisao_Corpo{tipo}</c> quando é o <c>-1</c> (o formato do corpo) e **vazio** em
        /// qualquer outro layer — o original só chama com esses dois (o ramo vazio deles cria um
        /// registro sem nome, que o recoder não reproduz de propósito).
        /// </summary>
        public static string Nome(string layer, string tipo)
        {
            string alvo = (layer ?? string.Empty).Trim();
            string sufixo = (tipo ?? string.Empty).Trim();

            if (PaginaAtiva.ChecaCapa(alvo))
            {
                return "Revisao_Capa" + sufixo;
            }

            if (string.Equals(alvo, PaginaAtiva.LayerDoFormatoDoCorpo, StringComparison.OrdinalIgnoreCase))
            {
                return "Revisao_Corpo" + sufixo;
            }

            return string.Empty;
        }

        /// <summary>A tag está no <c>attRevProtCollection</c>? (sem caixa)</summary>
        public static bool EhTagProtegida(string tag)
        {
            string texto = (tag ?? string.Empty).Trim();
            foreach (string protegida in TagsProtegidas)
            {
                if (string.Equals(texto, protegida, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// O atributo do formato entra na definição da posição <paramref name="tipo"/>? As três
        /// condições do original: o <b>layer</b> do atributo é o alvo (a capa ou o <c>-1</c>), a
        /// <b>tag</b> está no conjunto protegido e ela **termina** com o dígito da posição
        /// (<c>val9.Tag.EndsWith(tipo)</c>).
        /// </summary>
        public static bool Copiar(string layerDoAtributo, string tag, string layerAlvo, string tipo)
        {
            if (!string.Equals(
                    (layerDoAtributo ?? string.Empty).Trim(),
                    (layerAlvo ?? string.Empty).Trim(),
                    StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            if (!EhTagProtegida(tag))
            {
                return false;
            }

            string sufixo = (tipo ?? string.Empty).Trim();
            if (sufixo.Length == 0)
            {
                return false;
            }

            return (tag ?? string.Empty).Trim().EndsWith(sufixo, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// O <c>maxCapa</c>/<c>maxCorpo</c> do <c>carregaConfiguracaoRevisao</c>: conta as tags
        /// **numeradas** (<c>REV0..7</c>) do layer da capa e do layer <c>-1</c>. A tag <c>REV</c>
        /// sozinha **não** conta (no original ela só liga um flag `SCapa`/`SCorpo`), e por isso a
        /// contagem é feita aqui, e não pelo <see cref="PosicionamentoDeRevisoes.ContarPosicoes"/>
        /// (que inclui o <c>REV</c> solto).
        /// </summary>
        public static PosicoesDoFormato Contar(IReadOnlyList<TagDeAtributo> formato, string capaLayer)
        {
            PosicoesDoFormato posicoes = new PosicoesDoFormato();
            if (formato == null)
            {
                return posicoes;
            }

            string capa = (capaLayer ?? string.Empty).Trim();
            foreach (TagDeAtributo atributo in formato)
            {
                if (atributo == null || !EhTagNumeradaDeRevisao(atributo.Tag))
                {
                    continue;
                }

                string layer = (atributo.Layer ?? string.Empty).Trim();
                if (capa.Length > 0 && string.Equals(layer, capa, StringComparison.OrdinalIgnoreCase))
                {
                    posicoes.Capa++;
                }
                else if (string.Equals(layer, PaginaAtiva.LayerDoFormatoDoCorpo, StringComparison.OrdinalIgnoreCase))
                {
                    posicoes.Corpo++;
                }
            }

            return posicoes;
        }

        /// <summary><c>REV</c> + um dígito de <c>0</c> a <c>7</c> — o que o <c>carregaConfiguracaoRevisao</c> conta.</summary>
        public static bool EhTagNumeradaDeRevisao(string tag)
        {
            string texto = (tag ?? string.Empty).Trim().ToUpperInvariant();
            return texto.Length == 4 && texto.StartsWith("REV", StringComparison.Ordinal)
                && texto[3] >= '0' && texto[3] <= '7';
        }

        private static IReadOnlyList<string> MontarTagsProtegidas()
        {
            string[] familias = { "REV", "DESC", "DATA", "ELAB", "VERIF", "APROV" };
            List<string> tags = new List<string>(familias.Length * 8);
            foreach (string familia in familias)
            {
                for (int digito = 0; digito <= 7; digito++)
                {
                    tags.Add(familia + digito);
                }
            }

            return tags;
        }
    }
}
