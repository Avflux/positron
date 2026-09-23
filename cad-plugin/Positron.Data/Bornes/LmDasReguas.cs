using System.Collections.Generic;
using Positron.Data.Modelos;

namespace Positron.Data.Bornes
{
    /// <summary>
    /// O <c>lm</c> que a **régua** define para um tipo de borne — a resolução que
    /// fecha o <c>BorneSemLm</c> que o <c>VERIF</c> aponta (o comando
    /// <c>SobeLm</c>).
    ///
    /// São **duas fontes**, nesta ordem:
    ///
    /// 1. o campo do <c>REGUAS/MODELOS2</c> (+6 = tipo 0, +7 = tipo 1), que é o
    ///    **único** que o <c>DicionarioBorne.BuscaLMdaRegua</c> do original lê
    ///    (<see cref="ReguasModelo.BuscarLm"/>);
    /// 2. o **dicionário de bornes da régua** (<c>CENG_BORNES</c>): o <c>lm</c> do
    ///    primeiro borne de reserva **do tipo** do borne
    ///    (<see cref="BornesReserva.Ler"/>).
    ///
    /// A segunda fonte é **desvio do recoder**, e tem medição: o
    /// <c>GravaOsModelosDeRegua</c> do original grava <c>0</c> em +4..+8, então no
    /// desenho real os **31** registros do <c>MODELOS2</c> têm o campo zerado e a
    /// fonte 1 nunca resolve — o <c>lm</c> de verdade está no dicionário de bornes
    /// da régua (o mesmo que o <c>FIA</c> lê para as reservas). Sem a segunda
    /// fonte, o <c>SobeLm</c> seria um no-op por construção, em todo desenho que
    /// passou pelo gravador do original.
    ///
    /// A precedência é do <c>MODELOS2</c> porque é o que o original leria: só
    /// quando ele **não define** o tipo o dicionário entra. E o dicionário só é
    /// consultado para os tipos <c>0</c> e <c>1</c> — os dois que o
    /// <c>BuscaLMdaRegua</c> endereça (+6/+7); para os outros o valor continua
    /// <c>0</c>, como no original.
    /// </summary>
    public static class LmDasReguas
    {
        /// <summary>
        /// O <c>lm</c> da régua para o tipo — <c>0</c> quando nenhuma das duas
        /// fontes define (nesse caso é **dado faltando no desenho**, não regra).
        /// <paramref name="doDicionario"/> pode ser <c>null</c> (régua sem
        /// entrada no <c>CENG_BORNES</c>).
        /// </summary>
        public static int Resolver(
            ReguasModelo reguas,
            int indiceRegua,
            IReadOnlyList<BorneReserva> doDicionario,
            int tipo)
        {
            if (reguas != null)
            {
                int doModelos2 = reguas.BuscarLm(indiceRegua, tipo);
                if (doModelos2 != 0)
                {
                    return doModelos2;
                }
            }

            if (tipo != 0 && tipo != 1)
            {
                return 0;
            }

            if (doDicionario == null)
            {
                return 0;
            }

            foreach (BorneReserva borne in doDicionario)
            {
                if (borne != null && borne.Tipo == tipo && borne.Lm != 0)
                {
                    return borne.Lm;
                }
            }

            return 0;
        }
    }
}
