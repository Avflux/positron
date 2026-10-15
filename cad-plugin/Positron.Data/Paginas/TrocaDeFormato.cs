using System;
using System.Collections.Generic;

namespace Positron.Data.Paginas
{
    /// <summary>
    /// Um atributo lido do bloco de formato: o **layer** (a página), a **tag** e o **valor**.
    /// É a linha do <c>mAtributos</c> do <c>CapturaAtributosDoFormato</c> do reverso — o buffer
    /// que atravessa a troca do formato.
    /// </summary>
    public sealed class AtributoDoFormato
    {
        public AtributoDoFormato(string layer, string tag, string valor)
        {
            Layer = layer ?? string.Empty;
            Tag = tag ?? string.Empty;
            Valor = valor ?? string.Empty;
        }

        /// <summary>O layer do atributo (no original, a página a que ele pertence).</summary>
        public string Layer { get; private set; }

        /// <summary>A tag do atributo.</summary>
        public string Tag { get; private set; }

        /// <summary>O texto do atributo no formato antigo.</summary>
        public string Valor { get; private set; }
    }

    /// <summary>
    /// O que fazer com um atributo da definição do **formato novo**: o texto com que a referência
    /// nasce e se ela fica invisível. É o ramo do <c>if (!attProtCollection.Contains(tag))</c> do
    /// <c>CriaCaderno</c> do reverso.
    /// </summary>
    public sealed class InstrucaoDeAtributo
    {
        internal InstrucaoDeAtributo(string texto, bool invisivel)
        {
            Texto = texto ?? string.Empty;
            Invisivel = invisivel;
        }

        /// <summary>
        /// O texto da referência: o valor **preservado** do formato antigo quando o atributo não
        /// é protegido (o original ainda deixa o usuário digitar por cima, usando este como
        /// <c>DefaultValue</c>), ou vazio.
        /// </summary>
        public string Texto { get; private set; }

        /// <summary>
        /// O atributo é do conjunto protegido (<c>attProtCollection</c>): nasce **invisível e
        /// vazio** — quem o preenche é o motor do caderno (os títulos, o painel, as revisões).
        /// </summary>
        public bool Invisivel { get; private set; }
    }

    /// <summary>
    /// A **troca do formato** do caderno — o <c>Caderno.CriaCaderno</c> do reverso (o botão
    /// CADERNO da barra, comando <c>CAD</c>, dica "Cria ou troca o formato"). O original:
    /// <list type="number">
    /// <item>se já existe formato, pergunta e, confirmado, **captura** os atributos da referência
    /// (o <c>CapturaAtributosDoFormato</c>), apaga a definição e as referências do formato antigo
    /// (o <c>ApagaDefinicaoReferencias</c>) e renomeia a capa para <c>"1"</c> (o
    /// <c>retornaNumeroCapa</c>/<c>alteraNomeLayer</c>);</item>
    /// <item>pede o DWG do formato novo, o insere como bloco na origem (layer <c>0</c>), carimba o
    /// XData <c>DiagLog</c>/<c>Formato</c> e **recria os atributos** a partir da definição: os
    /// protegidos nascem invisíveis e vazios e os demais recebem o valor capturado — casado por
    /// **página** (o decimal do layer) e **tag** (o <c>euxs3rkWO</c>);</item>
    /// <item>restaura a capa e recarrega as páginas (a cadeia seguinte, que o recoder ainda não
    /// porta — ver o XML doc de <see cref="TrocaDeFormatoDoDesenho"/> no plugin).</item>
    /// </list>
    ///
    /// Aqui ficam só as decisões **puras**; quem fala com o CAD é o
    /// <c>Positron.Plugin.Paginas.TrocaDeFormatoDoDesenho</c>.
    /// </summary>
    public static class TrocaDeFormato
    {
        /// <summary>O layer de destino da capa quando ela tem outro nome (o <c>"1"</c> do original).</summary>
        public const string LayerPadraoDaCapa = "1";

        /// <summary>
        /// As **59** tags do <c>attProtCollection</c> do original (o
        /// <c>Geral.IniciaStringCollectionAtt</c>): os quatro títulos, o painel, a seção, o <c>FL</c>,
        /// o <c>CONT</c>, o <c>REV</c> e o <c>TOT</c>, o alternativo e as seis famílias de revisão
        /// (<c>REV</c>/<c>DESC</c>/<c>DATA</c>/<c>ELAB</c>/<c>VERIF</c>/<c>APROV</c>) com o dígito
        /// <c>0..7</c>. São os atributos que a troca **não** preserva: eles nascem invisíveis e
        /// vazios, porque quem os preenche é o motor do caderno.
        /// </summary>
        public static readonly IReadOnlyList<string> TagsProtegidas = MontarTagsProtegidas();

        /// <summary>A tag está no <c>attProtCollection</c>? (sem caixa, a tolerância do recoder)</summary>
        public static bool Protegida(string tag)
        {
            string texto = (tag ?? string.Empty).Trim();
            if (texto.Length == 0)
            {
                return false;
            }

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
        /// O atributo entra no buffer da troca? A guarda do <c>CapturaAtributosDoFormato</c>: **não**
        /// ser protegido e ter texto (sem contar espaços).
        /// </summary>
        public static bool ValePreservar(string tag, string valor)
        {
            if (Protegida(tag))
            {
                return false;
            }

            return (valor ?? string.Empty).Trim().Length > 0;
        }

        /// <summary>O buffer: só os atributos que o <see cref="ValePreservar"/> aceita, na ordem recebida.</summary>
        public static IReadOnlyList<AtributoDoFormato> Captura(IReadOnlyList<AtributoDoFormato> doFormato)
        {
            List<AtributoDoFormato> capturados = new List<AtributoDoFormato>();
            if (doFormato == null)
            {
                return capturados;
            }

            foreach (AtributoDoFormato atributo in doFormato)
            {
                if (atributo != null && ValePreservar(atributo.Tag, atributo.Valor))
                {
                    capturados.Add(atributo);
                }
            }

            return capturados;
        }

        /// <summary>
        /// O valor preservado para um atributo do formato novo — o <c>euxs3rkWO</c> do original: casa
        /// pela **página em decimal** (o <c>calculaPaginaDecimal</c>, que trata <c>1</c> e <c>001</c>
        /// como a mesma página) e pela **tag** (sem caixa), nesta ordem. Sem par, vazio.
        /// </summary>
        public static string ValorPreservado(string layer, string tag, IReadOnlyList<AtributoDoFormato> capturados)
        {
            if (capturados == null)
            {
                return string.Empty;
            }

            string alvo = (tag ?? string.Empty).Trim();
            double pagina = PaginaNumerada.Decimal(layer);
            foreach (AtributoDoFormato atributo in capturados)
            {
                if (atributo == null)
                {
                    continue;
                }

                if (PaginaNumerada.Decimal(atributo.Layer) != pagina)
                {
                    continue;
                }

                if (string.Equals(alvo, atributo.Tag.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return atributo.Valor;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// A instrução de um atributo da definição do formato novo: protegido → invisível e vazio;
        /// caso contrário, o valor preservado do formato antigo (o <c>DefaultValue</c> do prompt do
        /// original, que o usuário pode sobrescrever).
        /// </summary>
        public static InstrucaoDeAtributo Definir(string tag, string layer, IReadOnlyList<AtributoDoFormato> capturados)
        {
            if (Protegida(tag))
            {
                return new InstrucaoDeAtributo(string.Empty, true);
            }

            return new InstrucaoDeAtributo(ValorPreservado(layer, tag, capturados), false);
        }

        /// <summary>
        /// A capa tem de ser renomeada para <c>"1"</c> antes da troca? O original só o faz quando o
        /// <c>retornaNumeroCapa</c> acha uma capa com outro nome (o <c>001</c>, por exemplo) — é o
        /// que faz o <c>retornaNumeroCapa</c> responder <c>"1"</c> durante a reconstrução do
        /// formato. O nome é restaurado no fim.
        /// </summary>
        public static bool PrecisaRenomearCapa(string capa)
        {
            string nome = (capa ?? string.Empty).Trim();
            return nome.Length > 0
                && !string.Equals(nome, LayerPadraoDaCapa, StringComparison.OrdinalIgnoreCase);
        }

        private static IReadOnlyList<string> MontarTagsProtegidas()
        {
            List<string> tags = new List<string>
            {
                "TITULO1PAG", "TITULO2PAG", "TITULO3PAG", "TITULO4PAG",
                "PAINEL", "SECAO", "FL", "CONT", "REV", "TOT", "ALTERNATIVO",
            };

            string[] familias = { "REV", "DESC", "DATA", "ELAB", "VERIF", "APROV" };
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
