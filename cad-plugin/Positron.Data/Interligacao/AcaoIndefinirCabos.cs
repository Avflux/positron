using System;
using System.Collections.Generic;

namespace Positron.Data.Interligacao
{
    /// <summary>
    /// A **ação** <c>IndefineCabosNaoExistentes</c> do
    /// <c>clsVerificadorProjetoInterligacao</c> — o botão <c>BTCorrigeCabos</c>
    /// ("Corrigir") da tela de verificação da interligação, não uma checagem.
    ///
    /// Ela não lê tabela nenhuma: varre as <c>LWPOLYLINE</c> de interligação do
    /// desenho e, quando o <c>Tag_Cabo</c> **não** está no catálogo
    /// (<c>SELECT Tag FROM Cabos</c>), limpa e regrava o XData daquele trecho
    /// (<see cref="InterligacaoXData.IndefinirCabo"/> +
    /// <see cref="InterligacaoXData.ParaValores"/>) e põe o caracter de terminal
    /// indefinido no rótulo auxiliar (<c>AUXINTERLIG</c>) da ponta.
    ///
    /// Esta classe guarda o que é **puro** e por isso testável sem CAD: a decisão
    /// de quais trechos indefinir e a regra do rótulo. Quem escreve no desenho é o
    /// adapter do plugin.
    /// </summary>
    public static class AcaoIndefinirCabos
    {
        /// <summary>
        /// Tipo do rótulo <c>AUXINTERLIG</c> que representa o cabo — só ele recebe o
        /// caracter indefinido (<c>tipo == 1</c> no original).
        /// </summary>
        public const short TipoRotuloCabo = 1;

        /// <summary>Caracter de terminal indefinido — o <c>Conf.CaracterTerminalIndefinido</c> do original.</summary>
        public const string TerminalIndefinido = VerificadorProjeto.TerminalIndefinido;

        /// <summary>
        /// Planeja a ação: os **índices** dos trechos cujo <c>Tag_Cabo</c> não existe
        /// no catálogo, na ordem em que apareceram.
        ///
        /// **Catálogo vazio devolve vazio.** O original abre a ação com
        /// <c>if (lCabos.Count &lt;= 0) return;</c> — sem catálogo não há "cabo
        /// inexistente", há ausência de dado (o projeto real carrega o catálogo do
        /// banco Access). Sem essa guarda a ação apagaria a tag de **todo** trecho do
        /// desenho.
        ///
        /// A comparação é **ordinal** (sensível a caixa), como o
        /// <c>List(Of String).Contains</c> do original — não confundir com a regra de
        /// verificação <see cref="VerificadorProjeto.VerificarCabosSemCatalogo"/>, que
        /// aponta (é read-only) e por isso tolera caixa/espaço.
        /// </summary>
        public static IReadOnlyList<int> Planejar(
            IReadOnlyList<string> tags,
            IReadOnlyCollection<string> catalogo)
        {
            List<int> indices = new List<int>();
            if (tags == null || catalogo == null || catalogo.Count == 0)
            {
                return indices;
            }

            HashSet<string> conhecidos = new HashSet<string>(catalogo, StringComparer.Ordinal);
            for (int i = 0; i < tags.Count; i++)
            {
                if (!conhecidos.Contains(tags[i] ?? string.Empty))
                {
                    indices.Add(i);
                }
            }

            return indices;
        }

        /// <summary>O rótulo auxiliar deste tipo é o do cabo (recebe o caracter indefinido).</summary>
        public static bool RotuloEhDoCabo(short tipo)
        {
            return tipo == TipoRotuloCabo;
        }
    }
}
