using System;
using System.Collections.Generic;

namespace Positron.Data.Fiacao
{
    /// <summary>
    /// XData do app name <c>AUXCONEXAO</c>: o texto auxiliar de circuito (<c>DBText</c>) que o
    /// original pendura numa conexão <c>CONEXAO</c>.
    ///
    /// Layout de <c>XDataConexao.GravarXDataAuxCircuito</c> (12 valores) e do leitor
    /// <c>lerXDataAuxCircuito</c>, que só olha os índices 1, 2, 3 e 6:
    ///
    /// | idx | código | campo          |
    /// |-----|--------|----------------|
    /// | 0   | 1001   | "AUXCONEXAO"   |
    /// | 1   | 1070   | Tipo (4 = cor, 5 = seção, 6 = "cor (seção)"…) |
    /// | 2   | 1071   | Potencial      |
    /// | 3   | 1000   | Handle da conexão |
    /// | 4–5 | 1000   | (reservado)    |
    /// | 6   | 1071   | Enderecamento  |
    /// | 7–8 | 1000   | Usuario, Data  |
    /// | 9–11|        | (reservado)    |
    /// </summary>
    public static class AuxConexaoXData
    {
        public const string AppName = "AUXCONEXAO";

        /// <summary>
        /// Lê tipo, potencial e handle. O original lê o índice 6 sem checar o tamanho; aqui o
        /// XData com menos de 7 valores (ou de outro app) devolve <c>false</c> em vez de lançar.
        /// </summary>
        public static bool Ler(IReadOnlyList<TypedXData> valores, out short tipo, out int potencial, out string handle)
        {
            tipo = 0;
            potencial = 0;
            handle = null;

            if (valores == null || valores.Count < 7)
            {
                return false;
            }

            if (valores[0].Codigo != 1001 || !string.Equals(valores[0].Valor as string, AppName, StringComparison.Ordinal))
            {
                return false;
            }

            tipo = valores[1].Valor == null ? (short)0 : XDataNumero.Curto(valores[1].Valor);
            potencial = valores[2].Valor == null ? 0 : XDataNumero.Inteiro(valores[2].Valor);
            handle = valores[3].Valor == null ? string.Empty : Convert.ToString(valores[3].Valor);
            return true;
        }
    }
}
