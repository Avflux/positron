using System;

namespace Positron.Data.Correcoes
{
    /// <summary>
    /// O <c>ApagaBlocosMirror</c> do <c>clsUtilitarios.cs</c> (frente 2 do §7.6): apaga
    /// os blocos **espelhados** que **não** são cabos de aranha.
    ///
    /// A regra do original, do jeito que está escrita:
    ///
    /// 1. o bloco tem **algum** XData (<c>val6.XData != null</c>);
    /// 2. **não** tem o app <c>DINTERLIG</c> (<c>lexDataDaEntity1(ref ent, "DINTERLIG", 0,</c>
    ///    <c>ref oValor)</c> devolve <c>false</c>);
    /// 3. o fator de escala em **X é negativo** (<c>ScaleFactors.X &lt; 0</c>) — o espelho.
    ///
    /// **Nota de recorte:** a família <c>LeAtributos</c>/<c>LeTodosAtributos</c> +
    /// <c>CorrigeAtributos</c>/<c>CorrigeAtributosSemMsg</c>/<c>PreencheNovosAtributos</c>
    /// fica **fora**: elas operam sobre o buffer estático
    /// <c>clsTrocaEditaBlocosMat.mAtributos</c>, que é preenchido por uma tela (a grade de
    /// atributos) e aplicado depois — sem a tela não há o que aplicar.
    /// </summary>
    public static class CorrecaoDosBlocosMirror
    {
        /// <summary>O app name do cabo de aranha, que **impede** o apagamento.</summary>
        public const string AppNameCaboAranha = "DINTERLIG";

        /// <summary>As três condições do original, na ordem.</summary>
        public static bool PrecisaApagar(bool temXData, bool temCaboAranha, double escalaX)
        {
            if (!temXData)
            {
                return false;
            }

            if (temCaboAranha)
            {
                return false;
            }

            return escalaX < 0.0;
        }
    }
}
