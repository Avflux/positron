using System;

namespace Positron.Data.Modelos
{
    /// <summary>
    /// Ajusta a orientação (N/S) de um contato auxiliar ao número de terminais
    /// que ele realmente tem — o <c>DicionarioContatos.VerificaOrientacaoContato</c>
    /// do original.
    ///
    /// O dicionário grava a orientação como uma sequência de <c>N</c>/<c>S</c>
    /// separados por <c>;</c> (ex.: <c>"NS;NS;NS"</c>). Como um contato pode ter
    /// menos terminais preenchidos, o original:
    ///
    /// 1. conta os terminais não-vazios de <c>T1;T2;T3;</c>;
    /// 2. deduplica a orientação (<c>NN</c>→<c>N</c>, <c>SS</c>→<c>S</c>,
    ///    <c>NS</c>→<c>N</c>, <c>SN</c>→<c>S</c>);
    /// 3. mantém só as letras <c>N</c>/<c>S</c> e os <c>;</c> até o limite de
    ///    terminais — o resto é descartado.
    /// </summary>
    public static class OrientacaoContato
    {
        public static string Verificar(string terminais, string orientacao)
        {
            string resultado = string.Empty;
            try
            {
                string limpo = terminais == null ? string.Empty : terminais.Replace(";;", ";");
                int quantidade = 0;
                foreach (string parte in limpo.Split(';'))
                {
                    if (parte.Trim().Length != 0)
                    {
                        quantidade++;
                    }
                }

                string normalizado = (orientacao ?? string.Empty).ToUpperInvariant().Trim();
                normalizado = normalizado.Replace("NN", "N");
                normalizado = normalizado.Replace("SS", "S");
                normalizado = normalizado.Replace("NS", "N");
                normalizado = normalizado.Replace("SN", "S");

                int contados = 0;
                foreach (char c in normalizado)
                {
                    if (c == 'N' || c == 'S')
                    {
                        contados++;
                        if (contados <= quantidade)
                        {
                            resultado += c;
                        }
                    }
                    else if (c == ';' && contados <= quantidade)
                    {
                        resultado += c;
                    }
                }

                resultado = resultado.Replace(";;", ";");
                if (resultado == ";")
                {
                    resultado = string.Empty;
                }
            }
            catch (Exception)
            {
                resultado = string.Empty;
            }

            return resultado;
        }
    }
}
