using System;
using System.Collections.Generic;

namespace Positron.Data.Fiacao
{
    /// <summary>O que o <c>EDCON</c>/<c>EDCONP</c> troca: as palavras-chave <c>S</c>, <c>C</c> e <c>A</c> do original.</summary>
    public enum ModoSecaoECor : short
    {
        Secao = 1,
        Cor = 2,
        Ambas = 3,
    }

    /// <summary>
    /// A regra do <c>clsConexao.editarSecaoCor</c> (comando <c>EDCON</c>, por seleção) e do
    /// <c>clsConexao.editarSecaoCorPaginas</c> (tela <c>frmEditaConexao</c>, comando
    /// <c>EDCONP</c>, por página): troca a seção e/ou a cor de **todos os condutores de um
    /// potencial** e reescreve os textos auxiliares que mostram esses valores.
    ///
    /// O fluxo do original, nas duas variantes:
    ///
    /// 1. junta os **potenciais** das conexões escolhidas (<see cref="PotenciaisDaSelecao"/> /
    ///    <see cref="PotenciaisDasPaginas"/>);
    /// 2. em **todo** o ModelSpace (não só na seleção/nas páginas), cada <c>CONEXAO</c> dos tipos
    ///    1..4 com um desses potenciais é regravada (<see cref="Aplicar"/>);
    /// 3. cada <c>DBText</c> com <c>AUXCONEXAO</c> dos tipos 4/5/6 desse potencial e cujo handle
    ///    aponta para uma conexão regravada recebe o texto novo (<see cref="TextoDoAuxiliar"/>).
    /// </summary>
    public static class SecaoECorDasConexoes
    {
        /// <summary>O padrão do prompt <c>Seção=</c> (<c>My.Settings.Secao</c>, o valor ativo da barra).</summary>
        public const string SecaoPadrao = "1,5";

        /// <summary>O padrão do prompt <c>Cor=</c> (<c>My.Settings.Cor</c>, o valor ativo da barra).</summary>
        public const string CorPadrao = "PT";

        /// <summary>As palavras-chave do prompt (mMensagem 715, "Seção, Cor ou Ambas"); <c>null</c> se não for uma delas.</summary>
        public static ModoSecaoECor? ModoDaPalavra(string palavra)
        {
            if (string.Equals(palavra, "S", StringComparison.OrdinalIgnoreCase))
            {
                return ModoSecaoECor.Secao;
            }

            if (string.Equals(palavra, "C", StringComparison.OrdinalIgnoreCase))
            {
                return ModoSecaoECor.Cor;
            }

            if (string.Equals(palavra, "A", StringComparison.OrdinalIgnoreCase))
            {
                return ModoSecaoECor.Ambas;
            }

            return null;
        }

        /// <summary>Se o modo pede a seção (<c>modo = 1 | 3</c>).</summary>
        public static bool PedeSecao(ModoSecaoECor modo)
        {
            return modo == ModoSecaoECor.Secao || modo == ModoSecaoECor.Ambas;
        }

        /// <summary>Se o modo pede a cor (<c>modo = 2 | 3</c>).</summary>
        public static bool PedeCor(ModoSecaoECor modo)
        {
            return modo == ModoSecaoECor.Cor || modo == ModoSecaoECor.Ambas;
        }

        /// <summary>Os condutores que a edição alcança: <c>CONEXAO</c> dos tipos 1, 2, 3 e 4.</summary>
        public static bool EhCondutor(short tipo)
        {
            return tipo >= 1 && tipo <= 4;
        }

        /// <summary>
        /// Os potenciais das conexões selecionadas (<c>editarSecaoCor</c>): tipos 1..4, sem
        /// repetir, na ordem em que aparecem.
        /// </summary>
        public static List<int> PotenciaisDaSelecao(IEnumerable<ConexaoXData> selecionadas)
        {
            List<int> potenciais = new List<int>();
            foreach (ConexaoXData conexao in selecionadas)
            {
                if (EhCondutor(conexao.Tipo) && !potenciais.Contains(conexao.Potencial))
                {
                    potenciais.Add(conexao.Potencial);
                }
            }

            return potenciais;
        }

        /// <summary>
        /// Os potenciais das conexões que estão nas páginas escolhidas
        /// (<c>editarSecaoCorPaginas</c>). Duas particularidades do original, mantidas: aqui só
        /// entram os tipos **1, 2 e 4** (o 3, a superposição, não traz potencial — mas é editado
        /// depois, se o potencial vier de outra conexão), e a página é comparada ao layer da
        /// polyline com <c>List.Contains</c>, que diferencia maiúsculas.
        /// </summary>
        public static List<int> PotenciaisDasPaginas(
            IEnumerable<KeyValuePair<string, ConexaoXData>> conexoesPorLayer,
            ICollection<string> paginas)
        {
            List<int> potenciais = new List<int>();
            foreach (KeyValuePair<string, ConexaoXData> par in conexoesPorLayer)
            {
                short tipo = par.Value.Tipo;
                if ((tipo == 1 || tipo == 2 || tipo == 4)
                    && paginas.Contains(par.Key)
                    && !potenciais.Contains(par.Value.Potencial))
                {
                    potenciais.Add(par.Value.Potencial);
                }
            }

            return potenciais;
        }

        /// <summary>
        /// A regravação de uma conexão. Particularidade do original, mantida: a aplicação volta
        /// a <c>0</c> (o parâmetro opcional <c>aplicacao</c>, que o <c>EDCON</c>/<c>EDCONP</c>
        /// não passam) — editar seção/cor **desliga a aplicação** do condutor.
        /// </summary>
        public static void Aplicar(ConexaoXData conexao, ModoSecaoECor modo, string secao, string cor)
        {
            conexao.Aplicacao = 0;
            if (PedeSecao(modo))
            {
                conexao.Secao = secao;
            }

            if (PedeCor(modo))
            {
                conexao.Cor = cor;
            }
        }

        /// <summary>
        /// O texto do auxiliar a partir da conexão regravada: tipo 4 = cor, 5 = seção,
        /// 6 = <c>"cor (seção)"</c>; os outros tipos não são tocados (<c>null</c>).
        /// </summary>
        public static string TextoDoAuxiliar(short tipo, string cor, string secao)
        {
            switch (tipo)
            {
                case 4:
                    return cor ?? string.Empty;
                case 5:
                    return secao ?? string.Empty;
                case 6:
                    return (cor ?? string.Empty) + " (" + (secao ?? string.Empty) + ")";
                default:
                    return null;
            }
        }
    }
}
