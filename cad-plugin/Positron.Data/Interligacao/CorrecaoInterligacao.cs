using System;
using System.Collections.Generic;

namespace Positron.Data.Interligacao
{
    /// <summary>
    /// A correção <c>CorrigeInterligacao</c> do original (<c>clsUtilitarios.cs:611</c>, 216 linhas) —
    /// o comando que fecha o laço do <c>VERIF</c> na interligação **por página inteira**, onde o
    /// <see cref="AcaoIndefinirCabos"/> (o <c>INDCABO</c>) só mexe nos trechos escolhidos.
    ///
    /// Para cada trecho **indefinido** (<c>NumVeia == -1000</c>, o estado que a ação deixa) o original
    /// redescobre o painel de cada ponta pelo **dispositivo que está sobre a ponta**
    /// (<c>verificaDispInterlig</c>, no adapter) e regrava <c>Painel1</c>/<c>Painel2</c> — os mesmos
    /// campos que a projeção do <c>INT</c> lê.
    ///
    /// Três detalhes do original reproduzidos (cada um fixado em teste):
    ///
    /// 1. a comparação do <c>Tipo 1</c> é a do **par em qualquer ordem** — trocar <c>Painel1</c> com
    ///    <c>Painel2</c> não é erro, então não se regrava só por causa da ordem (o <c>if</c> aninhado
    ///    que o decompilador devolveu é redundante: as duas condições internas são a negação da
    ///    mesma comparação);
    /// 2. no <c>Tipo 2</c>/<c>3</c> quem decide o campo é <c>Painel1 == 0</c>: com ele zerado o
    ///    painel achado vai para <c>Painel2</c>, senão para <c>Painel1</c> — e só **um** dos dois é
    ///    tocado;
    /// 3. o painel vem da ponta 1 e, **só quando ela não tem dispositivo**, da ponta 2 (o
    ///    <c>if (!flag)</c> do original).
    ///
    /// **Uma divergência deliberada** (mesma decisão do <c>RENPAGA</c>, rodada 134): o original
    /// **grava zero** quando não acha dispositivo na ponta — inclusive por cima de um
    /// <c>Painel2</c> válido, no ramo do <c>Tipo 2</c>/<c>3</c>. Aqui o trecho sem dispositivo nas
    /// pontas (ou sem a ponta exigida, no <c>Tipo 1</c>) é **pulado** e contado em
    /// <see cref="Plano.SemDispositivo"/>: a correção existe para **consertar** o painel pelo
    /// desenho, e zerar um painel válido é o oposto disso.
    /// </summary>
    public static class CorrecaoInterligacao
    {
        /// <summary>Trecho com as duas pontas (vértice 0 e último).</summary>
        public const short TipoDuasPontas = 1;

        /// <summary>Trecho com uma ponta — o painel achado vai para o campo que o <c>Painel1</c> indica.</summary>
        public const short TipoUmaPonta = 2;

        /// <summary>Trecho de destino — mesma decisão do <see cref="TipoUmaPonta"/> no original.</summary>
        public const short TipoDestino = 3;

        /// <summary>O painel achado sobre uma ponta do trecho (a leitura é do adapter).</summary>
        public sealed class Ponta
        {
            /// <summary>Nenhum dispositivo com painel foi achado nesta ponta.</summary>
            public static readonly Ponta NaoEncontrada = new Ponta(0, false);

            public Ponta(short painel, bool encontrada)
            {
                Painel = painel;
                Encontrada = encontrada;
            }

            public short Painel { get; private set; }

            public bool Encontrada { get; private set; }
        }

        /// <summary>Um trecho do desenho como a regra o vê (XData + os painéis achados nas pontas).</summary>
        public sealed class Trecho
        {
            public short Tipo { get; set; }

            /// <summary><c>NumVeia == -1000</c>: só os indefinidos entram na correção.</summary>
            public bool Indefinido { get; set; }

            public short Painel1 { get; set; }

            public short Painel2 { get; set; }

            /// <summary>O dispositivo na ponta 1 (vértice 0).</summary>
            public Ponta NaPonta1 { get; set; }

            /// <summary>O dispositivo na ponta 2 (último vértice).</summary>
            public Ponta NaPonta2 { get; set; }

            public static Trecho De(short tipo, bool indefinido, short painel1, short painel2,
                Ponta naPonta1, Ponta naPonta2)
            {
                return new Trecho
                {
                    Tipo = tipo,
                    Indefinido = indefinido,
                    Painel1 = painel1,
                    Painel2 = painel2,
                    NaPonta1 = naPonta1 ?? Ponta.NaoEncontrada,
                    NaPonta2 = naPonta2 ?? Ponta.NaoEncontrada,
                };
            }
        }

        /// <summary>O que regravar num trecho — os **dois** campos, porque o XData é regravado inteiro.</summary>
        public sealed class Correcao
        {
            public int Indice { get; set; }

            public short Painel1 { get; set; }

            public short Painel2 { get; set; }
        }

        /// <summary>A decisão: o que gravar e quantos trechos ficaram sem dispositivo nas pontas.</summary>
        public sealed class Plano
        {
            public Plano(IReadOnlyList<Correcao> correcoes, int semDispositivo)
            {
                Correcoes = correcoes;
                SemDispositivo = semDispositivo;
            }

            public IReadOnlyList<Correcao> Correcoes { get; private set; }

            public int SemDispositivo { get; private set; }
        }

        /// <summary>Planeja a correção. Devolve vazio (sem exceção) com lista nula.</summary>
        public static Plano Planejar(IReadOnlyList<Trecho> trechos)
        {
            List<Correcao> correcoes = new List<Correcao>();
            if (trechos == null)
            {
                return new Plano(correcoes, 0);
            }

            int semDispositivo = 0;
            for (int i = 0; i < trechos.Count; i++)
            {
                Trecho trecho = trechos[i];
                if (trecho == null || !trecho.Indefinido)
                {
                    continue;
                }

                if (trecho.Tipo == TipoDuasPontas)
                {
                    // A ponta é a origem do painel: sem as duas não há par para comparar (o original
                    // gravaria 0 na que faltou — ver a divergência deliberada no XML doc).
                    if (!trecho.NaPonta1.Encontrada || !trecho.NaPonta2.Encontrada)
                    {
                        semDispositivo++;
                        continue;
                    }

                    short achado1 = trecho.NaPonta1.Painel;
                    short achado2 = trecho.NaPonta2.Painel;
                    if (MesmoPar(trecho.Painel1, trecho.Painel2, achado1, achado2))
                    {
                        continue;
                    }

                    correcoes.Add(new Correcao { Indice = i, Painel1 = achado1, Painel2 = achado2 });
                    continue;
                }

                if (trecho.Tipo != TipoUmaPonta && trecho.Tipo != TipoDestino)
                {
                    continue;
                }

                Ponta ponta = trecho.NaPonta1.Encontrada
                    ? trecho.NaPonta1
                    : (trecho.NaPonta2.Encontrada ? trecho.NaPonta2 : null);

                if (ponta == null)
                {
                    semDispositivo++;
                    continue;
                }

                short painel1 = trecho.Painel1;
                short painel2 = trecho.Painel2;
                if (painel1 == 0)
                {
                    if (painel2 == ponta.Painel)
                    {
                        continue;
                    }

                    painel2 = ponta.Painel;
                }
                else
                {
                    if (painel1 == ponta.Painel)
                    {
                        continue;
                    }

                    painel1 = ponta.Painel;
                }

                correcoes.Add(new Correcao { Indice = i, Painel1 = painel1, Painel2 = painel2 });
            }

            return new Plano(correcoes, semDispositivo);
        }

        /// <summary>O par casa em qualquer ordem — a comparação do <c>Tipo 1</c> no original.</summary>
        private static bool MesmoPar(short painel1, short painel2, short achado1, short achado2)
        {
            return (painel1 == achado1 && painel2 == achado2)
                || (painel1 == achado2 && painel2 == achado1);
        }
    }
}
