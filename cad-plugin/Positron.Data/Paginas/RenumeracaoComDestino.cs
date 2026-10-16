using System;
using System.Collections.Generic;
using System.Globalization;
using Positron.Data.Interface;

namespace Positron.Data.Paginas
{
    /// <summary>
    /// A **renumeração com destino** do menu das folhas — o <c>C8Op1CM1YgS</c> do
    /// <c>uscPaginas.cs</c> (`:2247-2390`), o item **Renumerar Páginas** (mMensagem 22): pergunta
    /// "Mover para página?" (mMensagem 24), e move as linhas **selecionadas** da grade a partir do
    /// número informado — recusando a capa (57), o destino que já é uma selecionada (26), o que já
    /// é outra página (25) e o que não cabe antes da próxima página (27).
    ///
    /// Não confundir com o <see cref="PaginasDoCaderno.Renomear"/>: aquele é o `RENPAGA`, que
    /// acrescenta um **sufixo** ao caderno inteiro. Aqui o nome novo é **calculado** a partir do
    /// destino, em duas famílias, na ordem em que o original as tenta:
    ///
    /// 1. **numérica** (<c>definePaginasNumericas</c>): `destino`, `destino + passo`, ...;
    /// 2. **alfanumérica** (<c>definePaginasAlfaNumericas</c>): quando os números não cabem antes da
    ///    próxima página, o destino ganha letra — `12`, `12A`, `12B`, ... (a aritmética de 27 páginas
    ///    por número: 26 letras + a página "seca", que vale 64 = 'A' - 1).
    ///
    /// O nome novo sempre passa pelo <see cref="PaginasDoCaderno.MontaNumeroPagina"/> com a largura
    /// fixa da configuração (<c>Conf.LarguraFixaPaginas</c>), como o original faz dentro das duas
    /// rotinas de definição.
    /// </summary>
    public static class RenumeracaoComDestino
    {
        /// <summary>O sentinela do fim do caderno (o <c>p = "1000000"</c> do original).</summary>
        public const string FimDoCaderno = "1000000";

        /// <summary>O que a movimentação decidiu: aplicar os nomes novos, ou só avisar.</summary>
        public sealed class Plano
        {
            /// <summary>Os nomes novos estão calculados e a movimentação pode ser gravada.</summary>
            public bool Aplicar { get; set; }

            /// <summary>O destino como o prompt o normalizou (`ToUpper` + `montaNumeroPagina`).</summary>
            public string Destino { get; set; } = string.Empty;

            /// <summary>
            /// A mensagem do `MsgBox` de informação do original quando **não** se aplica
            /// (as mMensagem 57, 26, 25 e 27); <c>null</c> quando aplica.
            /// </summary>
            public string Aviso { get; set; }

            /// <summary>Um nome novo por linha selecionada, na mesma ordem.</summary>
            public IReadOnlyList<string> Novas { get; set; } = new List<string>();
        }

        /// <summary>
        /// A largura fixa que o **literal do combo `Folha`** representa — o `switch` do
        /// <c>Es6p1Y15jTb</c> (`uscPaginas.cs:2399-2439`): `12` é a largura zero (sem zeros à
        /// esquerda) e cada zero a mais sobe a largura. Devolve <c>false</c> para um texto que não é
        /// um dos seis literais — o original, nesse caso, **não** mexe na configuração (o combo é
        /// editável e aceita texto digitado), mas segue renumera tudo com a largura que já estava.
        /// </summary>
        public static bool LarguraDoFormatoLiteral(string formato, out int largura)
        {
            largura = 0;
            switch ((formato ?? string.Empty).Trim())
            {
                case "12": largura = 0; return true;
                case "012": largura = 3; return true;
                case "0012": largura = 4; return true;
                case "00012": largura = 5; return true;
                case "000012": largura = 6; return true;
                case "0000012": largura = 7; return true;
                default: return false;
            }
        }

        /// <summary>
        /// Todas as páginas com o nome normalizado pela largura (o fim do `Es6p1Y15jTb`: cada linha
        /// da grade passa pelo <c>montaNumeroPagina</c> e o resultado vai para o
        /// <c>renumerarPaginasLote</c>). É a largura do combo aplicada ao caderno inteiro.
        /// </summary>
        public static IReadOnlyList<string> Normalizar(IReadOnlyList<string> paginas, int larguraFixaPaginas)
        {
            List<string> normalizadas = new List<string>();
            if (paginas == null)
            {
                return normalizadas;
            }

            foreach (string pagina in paginas)
            {
                normalizadas.Add(PaginasDoCaderno.MontaNumeroPagina(pagina, larguraFixaPaginas));
            }

            return normalizadas;
        }

        /// <summary>
        /// O plano da movimentação: o que fazer com as **selecionadas** quando o destino é
        /// <paramref name="destino"/>. <paramref name="naoSelecionadas"/> são as outras linhas da
        /// grade — na **ordem da grade**, porque é a primeira delas depois do destino que limita o
        /// espaço (o `p` do original).
        /// </summary>
        public static Plano Planejar(string destino, int larguraFixaPaginas, int passo,
            IReadOnlyList<string> selecionadas, IReadOnlyList<string> naoSelecionadas)
        {
            Plano plano = new Plano();
            List<string> escolhidas = Lista(selecionadas);
            List<string> outras = Lista(naoSelecionadas);

            // O prompt: `val2.StringResult.ToUpper()` e, em seguida, o `montaNumeroPagina`.
            string alvo = PaginasDoCaderno.MontaNumeroPagina(
                (destino ?? string.Empty).Trim().ToUpperInvariant(), larguraFixaPaginas);
            plano.Destino = alvo;

            // 1. A capa não se move (o `checaCapa` antes de tudo, mMensagem 57).
            if (PaginaAtiva.ChecaCapa(alvo))
            {
                plano.Aviso = MensagensDoReverso.NaoEPossivelMoverSobreACapa;
                return plano;
            }

            // 2. O destino já é página — primeiro a mensagem das selecionadas (26), depois a das outras (25).
            foreach (string pagina in escolhidas)
            {
                if (Mesma(pagina, alvo))
                {
                    plano.Aviso = MensagensDoReverso.EstaPaginaFoiSelecionada;
                    return plano;
                }
            }

            foreach (string pagina in outras)
            {
                if (Mesma(pagina, alvo))
                {
                    plano.Aviso = MensagensDoReverso.EstaPaginaJaExisteInformeLivre;
                    return plano;
                }
            }

            // 3. O limite: a primeira página NÃO selecionada depois do destino (o `p` do original);
            // sem nenhuma, o sentinela do fim do caderno.
            string limite = FimDoCaderno;
            foreach (string pagina in outras)
            {
                if (PaginaNumerada.Decimal(pagina) > PaginaNumerada.Decimal(alvo))
                {
                    limite = pagina;
                    break;
                }
            }

            if (PaginaNumerada.EspacoNumerico(alvo, limite) >= escolhidas.Count)
            {
                plano.Novas = Numericas(alvo, passo, escolhidas.Count, larguraFixaPaginas);
            }
            else if (PaginaNumerada.EspacoAlfaNumerico(alvo, limite) >= escolhidas.Count)
            {
                plano.Novas = AlfaNumericas(alvo, escolhidas.Count, larguraFixaPaginas);
            }
            else
            {
                plano.Aviso = MensagensDoReverso.NaoHaEspacoSuficiente;
                return plano;
            }

            plano.Aplicar = true;
            return plano;
        }

        /// <summary>
        /// Os nomes do ramo **numérico** (o <c>definePaginasNumericas</c>): do destino (ou do
        /// número seguinte, quando o destino tem letra) em diante, de <paramref name="passo"/> em
        /// <paramref name="passo"/> (<c>Conf.PassoPagina</c>).
        /// </summary>
        public static IReadOnlyList<string> Numericas(string destino, int passo, int quantidade, int larguraFixaPaginas)
        {
            List<string> novas = new List<string>();
            string alvo = destino ?? string.Empty;
            double primeira = PaginaNumerada.EhNumerico(alvo)
                ? double.Parse(alvo, CultureInfo.InvariantCulture)
                : Math.Floor(PaginaNumerada.Decimal(alvo)) + 1.0;

            for (int i = 0; i < quantidade; i++)
            {
                string nome = (primeira + i * (double)passo).ToString("0", CultureInfo.InvariantCulture);
                novas.Add(PaginasDoCaderno.MontaNumeroPagina(nome, larguraFixaPaginas));
            }

            return novas;
        }

        /// <summary>
        /// Os nomes do ramo **alfanumérico** (o <c>definePaginasAlfaNumericas</c>): do destino em
        /// diante acrescentando letra, pulando de número ao passar de `Z` (o `Asc == 91` que volta
        /// para 64 sem sufixo).
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Com o destino vazio ou com prefixo não numérico: o original estoura lá dentro nesses
        /// casos (`Strings.Mid("", 0, 1)` e o <c>Conversions.ToInteger</c> do prefixo) e mostra a
        /// mensagem do erro num `MsgBox` crítico, sem renomear nada — é o mesmo caminho aqui.
        /// </exception>
        public static IReadOnlyList<string> AlfaNumericas(string destino, int quantidade, int larguraFixaPaginas)
        {
            List<string> novas = new List<string>();
            string alvo = destino ?? string.Empty;
            int letra;
            int numero;
            if (PaginaNumerada.EhNumerico(alvo))
            {
                letra = 64;
                numero = Inteiro(alvo);
            }
            else
            {
                if (alvo.Length == 0)
                {
                    throw new InvalidOperationException(
                        "Sem página de destino: não há caractere para a letra do nome novo.");
                }

                letra = alvo[alvo.Length - 1];
                numero = Inteiro(alvo.Substring(0, alvo.Length - 1));
            }

            for (int i = 0; i < quantidade; i++)
            {
                if (letra == 91)
                {
                    letra = 64;
                    numero++;
                }

                string sufixo = letra == 64 ? string.Empty : ((char)letra).ToString();
                novas.Add(PaginasDoCaderno.MontaNumeroPagina(
                    numero.ToString(CultureInfo.InvariantCulture) + sufixo, larguraFixaPaginas));
                letra++;
            }

            return novas;
        }

        /// <summary>O <c>Conversions.ToInteger</c> do original: vazio é zero, o resto tem de ser número.</summary>
        private static int Inteiro(string texto)
        {
            double valor;
            if (!double.TryParse(texto ?? string.Empty, NumberStyles.Float, CultureInfo.InvariantCulture, out valor))
            {
                throw new InvalidOperationException(
                    "\"" + (texto ?? string.Empty) + "\" não é um número de página.");
            }

            return (int)Math.Round(valor);
        }

        private static bool Mesma(string pagina, string alvo)
        {
            return string.Equals(pagina ?? string.Empty, alvo ?? string.Empty, StringComparison.OrdinalIgnoreCase);
        }

        private static List<string> Lista(IReadOnlyList<string> paginas)
        {
            List<string> lista = new List<string>();
            if (paginas != null)
            {
                foreach (string pagina in paginas)
                {
                    lista.Add(pagina ?? string.Empty);
                }
            }

            return lista;
        }
    }
}
