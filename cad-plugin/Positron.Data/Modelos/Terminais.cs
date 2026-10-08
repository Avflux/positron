using System;
using System.Collections.Generic;

namespace Positron.Data.Modelos
{
    /// <summary>
    /// Divide as listas separadas por <c>;</c> que os modelos usam para terminais,
    /// bornes e réguas — o <c>Geral.DivideTerminais</c>/<c>DivideOrientacoes</c> do
    /// original. O separador é sempre <c>;</c>; a última <c>;</c> é descartada.
    /// </summary>
    public static class Terminais
    {
        /// <summary>
        /// Divide <paramref name="texto"/> em itens. Com <paramref name="repete"/>,
        /// itens repetidos são mantidos (é o que o original faz para os bornes de
        /// uma porta); sem ele, duplicados são removidos.
        /// </summary>
        public static List<string> Dividir(string texto, bool repete)
        {
            List<string> itens = new List<string>();
            if (texto == null)
            {
                return itens;
            }

            string limpo = texto.TrimEnd(';');
            foreach (string parte in limpo.Split(';'))
            {
                string item = parte.Trim();
                if (!repete && itens.Contains(item))
                {
                    continue;
                }

                itens.Add(item);
            }

            return itens;
        }

        public static List<string> Dividir(string texto)
        {
            return Dividir(texto, false);
        }

        /// <summary>
        /// Divide uma lista de orientações, **mantendo vazias** (ao contrário de
        /// <see cref="Dividir(string)"/>) — é o que o original espera, para casar
        /// orientação e terminal pela posição.
        /// </summary>
        public static List<string> DividirOrientacoes(string texto)
        {
            List<string> itens = new List<string>();
            if (texto == null)
            {
                return itens;
            }

            string limpo = texto.TrimEnd(';');
            if (limpo.Length == 0)
            {
                return itens;
            }

            foreach (string parte in limpo.Split(';'))
            {
                itens.Add(parte.Trim());
            }

            return itens;
        }
    }
}
