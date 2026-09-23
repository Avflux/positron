using System.Collections.Generic;

namespace Positron.Data.Interligacao
{
    /// <summary>
    /// O que o <c>RecriaTextosCabo</c> do <c>clsEletron.cs</c> decide antes de
    /// reinserir: **quais rótulos saem** e **quais trechos ficam sem rótulo**.
    ///
    /// A regra de apagar é a do <c>clsEletron.ApagarTodosOsTextosDasVeias</c> —
    /// **diferente** da do <c>Correcao.cs</c> (a limpeza da rodada 75, que só apaga
    /// o tipo 1):
    ///
    /// | entidade | condição |
    /// |---|---|
    /// | não-texto | XData <c>ELETROSUL</c> **ou** XData <c>AUXINTERLIG</c> (a variante ENEL, que usa o mesmo app name) |
    /// | <c>DBText</c> | <c>AUXINTERLIG</c> com tipo **1, 4, 5 ou 6** |
    /// | <c>DBText</c> | <c>AUXINTERLIG</c> tipo 3 **e** <c>InterligacaoLayout == 3</c> (ENEL), ou o <c>bApaga</c> ligado |
    ///
    /// O texto **sem** <c>AUXINTERLIG</c> nunca sai (o original só olha o rótulo
    /// auxiliar), e o tipo 2 (rótulo de ponta) também fica.
    /// </summary>
    public static class CorrecaoTextosCabo
    {
        /// <summary>Tipo do rótulo de cabo (o texto que a recriação reescreve).</summary>
        public const short TipoRotuloCabo = 1;

        /// <summary>Tipos de rótulo que a limpeza do RecriaTextosCabo sempre apaga.</summary>
        public static bool TipoApagado(short tipo)
        {
            return tipo == 1 || tipo == 4 || tipo == 5 || tipo == 6;
        }

        /// <summary>
        /// A decisão de apagar, na ordem do original.
        /// </summary>
        public static bool ApagarRotulo(
            bool ehTexto,
            bool temEletrosul,
            bool temAuxInterlig,
            short tipoAuxInterligacao,
            int interligacaoLayout,
            bool apagarTudo)
        {
            if (!ehTexto)
            {
                return temEletrosul || temAuxInterlig;
            }

            if (!temAuxInterlig)
            {
                return false;
            }

            if (TipoApagado(tipoAuxInterligacao))
            {
                return true;
            }

            return (tipoAuxInterligacao == 3 && interligacaoLayout == 3) || apagarTudo;
        }

        /// <summary>
        /// Os handles dos trechos que **não** têm rótulo — o original monta a lista
        /// dos <c>DBText</c> com <c>AUXINTERLIG</c> tipo 1 ou 3 (o campo
        /// <c>handle</c> do XData é o handle da polilinha) e reinsere só o que falta.
        /// </summary>
        public static IReadOnlyList<string> SemRotulo(
            IReadOnlyList<string> handlesDosTrechos,
            IReadOnlyCollection<string> handlesDosRotulos)
        {
            List<string> sem = new List<string>();
            if (handlesDosTrechos == null)
            {
                return sem;
            }

            HashSet<string> rotulados = new HashSet<string>();
            if (handlesDosRotulos != null)
            {
                foreach (string handle in handlesDosRotulos)
                {
                    if (!string.IsNullOrEmpty(handle))
                    {
                        rotulados.Add(handle);
                    }
                }
            }

            foreach (string handle in handlesDosTrechos)
            {
                if (!string.IsNullOrEmpty(handle) && !rotulados.Contains(handle))
                {
                    sem.Add(handle);
                }
            }

            return sem;
        }
    }
}
