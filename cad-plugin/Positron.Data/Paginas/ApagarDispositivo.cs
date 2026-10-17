using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Paginas
{
    /// <summary>
    /// Os ramos do **dispositivo principal** (tipo <c>P</c>) do <c>clsApagar.ApagarDerivados</c>
    /// (<c>clsApagar.cs:40-50</c>), decididos sobre o que o desenho tem:
    ///
    /// - <c>indexModelo &lt;= 0</c> → <c>clsDispositivo.promoveComplementar</c> (<c>clsDispositivo.cs:286</c>):
    ///   o **primeiro** outro <c>P</c> com mesmo Nome1/Nome2/Alternativo que é complementar vira principal
    ///   (<see cref="HandleAPromover"/>); a apagada só promove se ela **não** é complementar.
    /// - <c>indexModelo &gt; 0</c> → <c>clsDispositivo.ApagaContatosModeloDispositivo</c> (<c>clsDispositivo.cs:151</c>):
    ///   sai o que é do modelo dela (<see cref="HandlesDosContatosDoModelo"/>).
    ///
    /// A entrada é um <see cref="Bloco"/> por bloco do ModelSpace; o chamador (casca CAD) lê o XData.
    /// </summary>
    public static class ApagarDispositivo
    {
        /// <summary>
        /// Um bloco do desenho como os ramos o veem. <see cref="HandleBob"/>: no contato auxiliar (<c>A</c>) o
        /// bob do XData <c>Dispositivo</c>; nos demais tipos o bob do XData <c>Modelo</c> (<c>null</c> sem ele).
        /// </summary>
        public sealed class Bloco
        {
            public string Handle { get; set; }
            public string Tipo { get; set; }
            public string Nome1 { get; set; }
            public string Nome2 { get; set; }
            public string Alternativo { get; set; }
            public short Painel { get; set; }
            public bool Complementar { get; set; }
            public string HandleBob { get; set; }
        }

        /// <summary>
        /// O handle do complementar que vira principal, ou <c>null</c>. Só promove quando a apagada não é
        /// complementar (<c>disp.Complementar &amp; !structureDispositivo.Complementar</c>), e o primeiro casamento
        /// vence (o <c>break</c> do original).
        /// </summary>
        public static string HandleAPromover(Bloco apagado, IReadOnlyList<Bloco> blocos)
        {
            if (apagado == null || apagado.Complementar || blocos == null)
            {
                return null;
            }

            foreach (Bloco outro in blocos)
            {
                if (outro == null || !EhPrincipal(outro) || Igual(apagado.Handle, outro.Handle))
                {
                    continue;
                }

                if (Igual(apagado.Nome1, outro.Nome1)
                    && Igual(apagado.Nome2, outro.Nome2)
                    && Igual(apagado.Alternativo, outro.Alternativo)
                    && outro.Complementar)
                {
                    return outro.Handle;
                }
            }

            return null;
        }

        /// <summary>
        /// Os handles que <c>ApagaContatosModeloDispositivo</c> apaga, na ordem do desenho:
        /// - contato auxiliar (<c>A</c>) cujo bob é a apagada;
        /// - outro <c>P</c> (handle diferente) com mesmo painel/Nome1/Nome2/Alternativo que é complementar;
        /// - qualquer outro bloco cujo bob de modelo é a apagada.
        /// </summary>
        public static IReadOnlyList<string> HandlesDosContatosDoModelo(Bloco apagado, IReadOnlyList<Bloco> blocos)
        {
            List<string> handles = new List<string>();
            if (apagado == null || blocos == null)
            {
                return handles;
            }

            foreach (Bloco bloco in blocos)
            {
                if (bloco == null)
                {
                    continue;
                }

                bool apagar;
                if (string.Equals(bloco.Tipo, DispositivoFiacaoXData.TipoAuxiliar, StringComparison.OrdinalIgnoreCase))
                {
                    apagar = Igual(bloco.HandleBob, apagado.Handle);
                }
                else if (EhPrincipal(bloco))
                {
                    apagar = !Igual(apagado.Handle, bloco.Handle)
                        && apagado.Painel == bloco.Painel
                        && Igual(apagado.Nome1, bloco.Nome1)
                        && Igual(apagado.Nome2, bloco.Nome2)
                        && Igual(apagado.Alternativo, bloco.Alternativo)
                        && bloco.Complementar;
                }
                else
                {
                    apagar = Igual(bloco.HandleBob, apagado.Handle);
                }

                if (apagar)
                {
                    handles.Add(bloco.Handle);
                }
            }

            return handles;
        }

        private static bool EhPrincipal(Bloco bloco)
        {
            return string.Equals(bloco.Tipo, DispositivoFiacaoXData.TipoDispositivo, StringComparison.OrdinalIgnoreCase);
        }

        private static bool Igual(string a, string b)
        {
            return string.Equals(a ?? string.Empty, b ?? string.Empty, StringComparison.OrdinalIgnoreCase);
        }

    }
}
