using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Limpeza
{
    /// <summary>
    /// As regras **puras** das ações de **limpeza do CAD** — o primeiro bloco da
    /// frente 2 do §7.6 do plano (`Correcao.cs`).
    ///
    /// Elas não leem tabela do projeto nem o banco: são regras sobre entidades do
    /// desenho, e por isso quem varre o ModelSpace e escreve é o adapter do plugin
    /// (<c>Positron.Plugin.Limpeza.LimpezaDoCad</c>) — aqui fica só o que dá para
    /// testar sem CAD.
    /// </summary>
    public static class LimpezaDoDesenho
    {
        /// <summary>
        /// App name de XData **de terceiros** que o <c>apagaXDataTerceiros</c> limpa
        /// (o <c>AEC_XDATA_BOUND_SPACE</c> do original, de outro produto).
        /// </summary>
        public const string XDataTerceiros = "AEC_XDATA_BOUND_SPACE";

        /// <summary>Dicionário da posição dos equipamentos no layout de cada painel (o <c>CENG_LAYOUT</c>).</summary>
        public const string DicionarioLayout = "CENG_LAYOUT";

        /// <summary>Dicionário das plaquetas de identificação de cada painel (o <c>CENG_PLAQUETA</c>).</summary>
        public const string DicionarioPlaquetas = "CENG_PLAQUETA";

        /// <summary>
        /// Tipo do rótulo <c>AUXINTERLIG</c> que a <c>apagarTodosOsTextosDasVeias</c>
        /// apaga — o mesmo que o <c>INDCABO</c> trata como o rótulo do trecho
        /// (a função do reverso é <c>tipo == 1</c>).
        /// </summary>
        public const short TipoRotuloAuxiliar = 1;

        /// <summary>
        /// O <c>DBText</c> conta como **em branco** quando é só espaços (o
        /// <c>TextString.Trim()</c> do original) **e** não tem XData. A segunda
        /// condição é do original e importa: um rótulo sem texto mas com XData
        /// (ex.: o <c>AUXINTERLIG</c> de um cabo) é dado, não lixo.
        /// </summary>
        public static bool TextoEmBranco(string texto, bool temXData)
        {
            return !temXData && (texto ?? string.Empty).Trim().Length == 0;
        }

        /// <summary>
        /// O XData que o <c>apagaXDataTerceiros</c> **grava** por cima do que a
        /// entidade tinha: o original troca o buffer inteiro por um único registro
        /// 1001 com o próprio app name — some o conteúdo, fica a marca. É um
        /// quirk reproduzido (o efeito prático é remover o XData de terceiro).
        /// </summary>
        public static IReadOnlyList<TypedXData> XDataDeTerceirosSubstituido()
        {
            return new List<TypedXData>
            {
                new TypedXData(1001, XDataTerceiros),
            };
        }

        /// <summary>
        /// A regra do <c>apagarTodosOsTextosDasVeias</c> do <c>Correcao.cs</c>:
        /// apaga o **rótulo auxiliar**. Duas condições, na ordem do original:
        ///
        /// 1. qualquer entidade (texto ou não) com o XData <c>ELETROSUL</c> — o
        ///    original apaga sem olhar o tipo nem o conteúdo;
        /// 2. o <c>DBText</c> com XData <c>AUXINTERLIG</c> do tipo
        ///    <see cref="TipoRotuloAuxiliar"/> (1).
        ///
        /// O <c>ehTexto</c> só vale para a segunda: um <c>AUXINTERLIG</c> tipo 1
        /// num não-texto **fica** (é o ramo do <c>DBText val6 = ... as DBText</c>
        /// do original).
        /// </summary>
        public static bool ApagarRotuloAuxiliar(bool ehTexto, bool temXDataEletrosul, short tipoAuxInterligacao)
        {
            if (temXDataEletrosul)
            {
                return true;
            }

            return ehTexto && tipoAuxInterligacao == TipoRotuloAuxiliar;
        }
    }
}
