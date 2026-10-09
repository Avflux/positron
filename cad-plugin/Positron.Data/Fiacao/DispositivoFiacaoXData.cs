using System;
using System.Collections.Generic;

namespace Positron.Data.Fiacao
{
    /// <summary>
    /// Lê o XData de um **bloco de dispositivo** numa forma neutra e testável —
    /// o <c>LeXDataQualquerDispositivo</c> / <c>verificaTipoDispositivo</c> /
    /// <c>xDataLeNomesDisp</c> do original.
    ///
    /// São dois app names:
    ///
    /// - <c>DISPOSITIVO</c> (ou o legado <c>Dispositivo</c>): o tipo está em
    ///   <c>array[1]</c> e os nomes em <c>array[2]</c>/<c>array[3]</c>;
    /// - <c>IMPORTADO</c>: dispositivo importado de outro DWG — tipo <c>"I"</c>,
    ///   nomes em <c>array[2]</c>/<c>array[3]</c> e painel em <c>array[9]</c>
    ///   (<c>BuscaPainelDispositivo</c>).
    ///
    /// Layouts por tipo (índices do XData, do reverso):
    ///
    /// | tipo | Nome1 | Nome2 | Alternativo | Painel                | indexModelo |
    /// |------|-------|-------|-------------|-----------------------|-------------|
    /// | P    | 2     | 3     | 4           | 8                     | 12          |
    /// | M    | 2     | 3     | 4           | 8                     | 12          |
    /// | E    | 2     | 3     | 11          | resolvido do handle 4 | 5           |
    /// | A    | 2     | 3     | 11          | resolvido do handle 4 | 5           |
    /// | I    | 2     | 3     | —           | 9                     | —           |
    /// </summary>
    public static class DispositivoFiacaoXData
    {
        /// <summary>App name corrente do XData de dispositivo.</summary>
        public const string AppName = "DISPOSITIVO";

        /// <summary>App name legado (grafia mista) do XData de dispositivo.</summary>
        public const string AppNameLegado = "Dispositivo";

        /// <summary>App name dos dispositivos importados de outro DWG.</summary>
        public const string AppNameImportado = "IMPORTADO";

        public const string TipoDispositivo = "P";

        public const string TipoPorta = "E";

        public const string TipoAuxiliar = "A";

        public const string TipoMascara = "M";

        public const string TipoImportado = "I";

        /// <summary>
        /// Lê o XData do app <c>DISPOSITIVO</c>. Aceita <c>P</c>/<c>M</c>/<c>E</c>/<c>A</c>;
        /// o <c>B</c> (borne) tem leitor próprio (<c>BorneXData</c>) e é rejeitado aqui.
        /// </summary>
        public static bool Ler(IReadOnlyList<TypedXData> valores, out DispositivoFiacao dispositivo)
        {
            dispositivo = null;

            if (valores == null || valores.Count < 2)
            {
                return false;
            }

            string tipo = Normalizar(valores[1].Valor);
            if (string.IsNullOrEmpty(tipo))
            {
                return false;
            }

            switch (tipo)
            {
                case TipoDispositivo:
                case TipoMascara:
                    // Nome1=2, Nome2=3, Alternativo=4, Painel=8, indexModelo=12, Complementar=13.
                    if (valores.Count < 14)
                    {
                        return false;
                    }

                    dispositivo = new DispositivoFiacao
                    {
                        Tipo = tipo,
                        Nome1 = Texto(valores[2].Valor),
                        Nome2 = Texto(valores[3].Valor),
                        Alternativo = Texto(valores[4].Valor),
                        Painel = Curto(valores[8].Valor),
                        IndexModelo = Inteiro(valores[12].Valor),
                        Complementar = Booleano(valores[13].Valor),
                    };
                    return true;

                case TipoPorta:
                case TipoAuxiliar:
                    // Nome1=2, Nome2=3, Alternativo=11, handle da máscara=4, indexModelo=5.
                    if (valores.Count < 12)
                    {
                        return false;
                    }

                    dispositivo = new DispositivoFiacao
                    {
                        Tipo = tipo,
                        Nome1 = Texto(valores[2].Valor),
                        Nome2 = Texto(valores[3].Valor),
                        HandleMascara = Texto(valores[4].Valor),
                        IndexModelo = Inteiro(valores[5].Valor),
                        Alternativo = Texto(valores[11].Valor),
                        PainelPendente = true,
                    };
                    return true;

                default:
                    // "B" é borne; os demais não interessam a este leitor.
                    return false;
            }
        }

        /// <summary>
        /// Lê o XData do app <c>IMPORTADO</c>. O painel está em <c>array[9]</c>; o
        /// tipo é sempre <see cref="TipoImportado"/>.
        /// </summary>
        public static bool LerImportado(IReadOnlyList<TypedXData> valores, out DispositivoFiacao dispositivo)
        {
            dispositivo = null;

            if (valores == null || valores.Count < 10)
            {
                return false;
            }

            dispositivo = new DispositivoFiacao
            {
                Tipo = TipoImportado,
                Nome1 = Texto(valores[2].Valor),
                Nome2 = Texto(valores[3].Valor),
                Painel = Curto(valores[9].Valor),
            };
            return true;
        }

        /// <summary>Painel de um bloco de máscara/dispositivo (o <c>array[8]</c>), para resolver o <c>E</c>/<c>A</c>.</summary>
        public static bool LerPainel(IReadOnlyList<TypedXData> valores, out short painel)
        {
            painel = 0;
            if (valores == null || valores.Count < 9)
            {
                return false;
            }

            painel = Curto(valores[8].Valor);
            return true;
        }

        private static string Normalizar(object valor)
        {
            string texto = Texto(valor);
            return texto == null ? null : texto.Trim().ToUpperInvariant();
        }

        private static short Curto(object valor)
        {
            return valor == null || valor is DBNull ? (short)0 : Convert.ToInt16(valor);
        }

        private static int Inteiro(object valor)
        {
            return valor == null || valor is DBNull ? 0 : Convert.ToInt32(valor);
        }

        private static bool Booleano(object valor)
        {
            return valor != null && !(valor is DBNull) && Convert.ToBoolean(valor);
        }

        private static string Texto(object valor)
        {
            if (valor == null || valor is DBNull)
            {
                return null;
            }

            string texto = valor as string;
            return texto == null ? Convert.ToString(valor) : texto.Trim();
        }
    }
}
