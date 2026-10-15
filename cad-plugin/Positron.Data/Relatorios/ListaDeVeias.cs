using System;
using System.Collections.Generic;
using System.Globalization;
using Positron.Contract;

namespace Positron.Data.Relatorios
{
    /// <summary>Uma linha da **Lista de Veias** — as quinze colunas do <c>frmRelatorio_Veias</c>.</summary>
    /// <remarks>
    /// O <c>Tag</c>/<c>Formacao</c>/<c>Painel*</c>/<c>Documento</c>/<c>Comprimento</c> são do **cabo**
    /// (a coluna do <c>sPainel1</c> é o **nome** do painel, como o <c>Dicionario.BuscaNomeDoPainel</c>
    /// responde); o <c>Veia</c> e as duas pontas são da **veia**.
    /// </remarks>
    public sealed class LinhaDaListaDeVeias
    {
        public string Tag { get; set; }

        /// <summary>O <c>NxFormacao</c> com o <c>(...)</c> da blindagem — o <c>_formacao</c> do relatório.</summary>
        public string Formacao { get; set; }

        /// <summary>A <c>Funcao</c> do **cabo** (a coluna <c>FUNÇÃO</c> da tela no modo padrão).</summary>
        public string Funcao { get; set; }

        /// <summary>O <c>Nome_Veia</c> e, quando ele é vazio, o número da veia.</summary>
        public string Veia { get; set; }

        /// <summary>O nome do painel da ponta 1 (a ponta do painel escolhido no relatório).</summary>
        public string Painel1 { get; set; }

        /// <summary>O <c>NRegua</c> do trecho quando ele existe; senão a tag (a regra do original).</summary>
        public string Dispositivo1 { get; set; }

        public string Borne1 { get; set; }

        /// <summary>O <c>X</c> da coluna <c>ATERRAAR</c> da ponta 1.</summary>
        public bool Aterrar1 { get; set; }

        public string Painel2 { get; set; }

        public string Dispositivo2 { get; set; }

        public string Borne2 { get; set; }

        public bool Aterrar2 { get; set; }

        /// <summary>Os documentos funcionais das duas pontas, sem repetição e ordenados, unidos por <c>", "</c>.</summary>
        public string Documento { get; set; }

        /// <summary>As páginas das duas pontas (<c>Pagina1, Pagina2</c> quando diferem).</summary>
        public string Pagina { get; set; }

        /// <summary>O comprimento do cabo no texto do <c>Conversions.ToString</c> do original.</summary>
        public string Comprimento { get; set; }
    }

    /// <summary>
    /// A **Lista de Veias** do <c>frmRelatorio_Veias</c> (o comando <c>LVEI</c>) — a mesma montagem
    /// que o relatório <c>veias</c> do app já faz e mede (<c>services/sidecar/.../relatorios/veias.py</c>,
    /// rodada 65): aqui ela ganha a forma de **regra pura** para a tela do CAD, com as tabelas que o
    /// plugin já lê (<c>Cabos4</c>, <c>Veias4</c>, <c>Interligacao4</c> e o cadastro <c>Paineis</c>).
    ///
    /// **A montagem, na ordem do original** (o <c>CDadosAccessInterligacao.CarregaVeias4</c>):
    ///
    /// 1. os cabos da revisão que têm o painel escolhido em <c>Pn1</c> ou <c>Pn2</c>, ordenados por
    ///    <c>Tag</c> — cada cabo entra **uma vez** (o <c>lCabosUnico</c>);
    /// 2. a ponta do painel escolhido vira a **ponta 1** do relatório; as marcas de <c>Aterrar</c>
    ///    continuam presas aos <c>Pn1</c>/<c>Pn2</c> **originais** (<c>1</c> = fim do <c>Pn1</c>,
    ///    <c>2</c> = fim do <c>Pn2</c>, <c>3</c> = os dois);
    /// 3. as veias do cabo vêm do <c>Veias4</c> (mesma revisão), pulando <c>Num_Veia &lt;= -51</c>; o
    ///    rótulo é o <c>Nome_Veia</c> e, quando vazio, o número da veia;
    /// 4. as pontas de cada veia vêm do <c>Interligacao4</c> por <c>(Revisao, Tag_Cabo, Num_Veia)</c>,
    ///    casadas **por painel** com as pontas do cabo: a ponta que não casa fica **vazia** — só a que
    ///    casa recebe tag, borne e página. O <c>Terminal</c> vazio ou <c>"0"</c> sai como o caracter
    ///    indefinido (<c>?</c>) e, quando o <c>NRegua</c> do lado não é vazio, é **ele** que aparece na
    ///    coluna de dispositivo (não a tag) — duas regras do original reproduzidas de propósito;
    /// 5. o <c>Documento Funcional</c> é a lista ordenada e sem repetição dos documentos das duas
    ///    pontas do trecho, unida por <c>", "</c>;
    /// 6. a <c>Página</c> sai <c>Pagina1, Pagina2</c> quando diferem (e só a que existe, quando a outra
    ///    é vazia);
    /// 7. nas veias de índice **negativo** (as de reserva) o original ainda tenta o trecho da veia
    ///    **seguinte** quando a própria não resolve — reproduzido.
    ///
    /// **O que fica de fora, registrado:** o <c>OrdenaAVeia</c> do original reordena as veias de índice
    /// negativo com heurísticas sobre o nome (<c>"P"</c>/<c>"T"</c>) — aqui as veias saem por
    /// <c>Num_Veia</c>, como no relatório do app (muda a ordem relativa das veias de reserva, não o
    /// conteúdo das linhas); o <c>CarregaFuncoesDaVeias4</c>, que troca a coluna <c>Função</c> pela
    /// função da **veia** no modo <b>Função da Veia</b> da tela, não entra (a coluna sai com a função do
    /// cabo, o modo padrão); e a apresentação da tela
    /// — a faixa <c>AntiqueWhite</c> por cabo, as linhas de painel <c>LightBlue</c> e os brancos das
    /// linhas de continuação — é da **ligação da tela**, não da regra.
    /// </summary>
    public static class ListaDeVeias
    {
        /// <summary>O caracter do terminal indefinido (o <c>Conf.CaracterTerminalIndefinido</c>).</summary>
        public const string TerminalIndefinido = "?";

        /// <summary>As veias com <c>Num_Veia</c> abaixo disto saem do relatório (o <c>mVeia &gt; -51</c>).</summary>
        public const int VeiaReservaMinima = -51;

        /// <summary>
        /// Os painéis que aparecem nas duas pontas dos cabos da revisão — a lista da coluna
        /// <c>dgEquip</c> (o <c>CarregaPnRev</c> do original), sem repetição e na ordem em que os
        /// cabos os trazem (a lista do original vem do banco; a ordem de aparição é a escolha daqui, e
        /// não muda o conteúdo).
        /// </summary>
        public static List<int> Paineis(IEnumerable<Cabos4Row> cabos, string revisao)
        {
            List<int> paineis = new List<int>();
            if (cabos == null)
            {
                return paineis;
            }

            foreach (Cabos4Row cabo in cabos)
            {
                if (!MesmaRevisao(cabo, revisao))
                {
                    continue;
                }

                Acrescentar(paineis, cabo.Pn1);
                Acrescentar(paineis, cabo.Pn2);
            }

            return paineis;
        }

        /// <summary>
        /// As linhas da lista de veias do painel escolhido — uma por veia dos cabos desse painel, com
        /// as duas pontas. <paramref name="trechos"/> e <paramref name="veias"/> são as linhas da
        /// **mesma revisão** (o adapter lê uma vez por revisão).
        /// </summary>
        public static List<LinhaDaListaDeVeias> Montar(
            IEnumerable<Cabos4Row> cabos,
            IEnumerable<Veias4Row> veias,
            IEnumerable<Interligacao4Row> trechos,
            IReadOnlyDictionary<int, string> nomesDePaineis,
            string revisao,
            int painel)
        {
            List<LinhaDaListaDeVeias> linhas = new List<LinhaDaListaDeVeias>();
            if (cabos == null)
            {
                return linhas;
            }

            List<Cabos4Row> daRevisao = new List<Cabos4Row>();
            foreach (Cabos4Row cabo in cabos)
            {
                if (MesmaRevisao(cabo, revisao))
                {
                    daRevisao.Add(cabo);
                }
            }

            // `ORDER BY Tag` do original.
            daRevisao.Sort(delegate (Cabos4Row a, Cabos4Row b)
            {
                return string.Compare(a.Tag ?? string.Empty, b.Tag ?? string.Empty, StringComparison.Ordinal);
            });

            List<string> vistos = new List<string>();
            foreach (Cabos4Row cabo in daRevisao)
            {
                int pn1 = (int)(cabo.Pn1 ?? 0);
                int pn2 = (int)(cabo.Pn2 ?? 0);
                if (painel != pn1 && painel != pn2)
                {
                    continue;
                }

                string tag = Texto(cabo.Tag);
                if (vistos.Contains(tag))
                {
                    continue;
                }

                vistos.Add(tag);

                // A ponta do painel escolhido é a ponta 1; o `Aterrar` fica preso aos Pn1/Pn2 originais.
                int ponta1, ponta2;
                bool aterrar1, aterrar2;
                long? aterrar = cabo.Aterrar;
                if (pn1 == painel)
                {
                    ponta1 = pn1;
                    ponta2 = pn2;
                    aterrar1 = aterrar == 1 || aterrar == 3;
                    aterrar2 = aterrar == 2 || aterrar == 3;
                }
                else
                {
                    ponta1 = pn2;
                    ponta2 = pn1;
                    aterrar1 = aterrar == 2 || aterrar == 3;
                    aterrar2 = aterrar == 1 || aterrar == 3;
                }

                List<Veias4Row> doCabo = VeiasDoCabo(veias, tag);
                for (int i = 0; i < doCabo.Count; i++)
                {
                    int numero = (int)(doCabo[i].Num_Veia ?? 0);
                    Trecho trecho = AcharTrecho(trechos, tag, numero, ponta1, ponta2);

                    if (trecho == null && numero <= 0 && i + 1 < doCabo.Count)
                    {
                        // As veias de reserva caem no trecho da veia seguinte (o original).
                        trecho = AcharTrecho(trechos, tag, (int)(doCabo[i + 1].Num_Veia ?? 0), ponta1, ponta2);
                    }

                    if (trecho == null)
                    {
                        continue;
                    }

                    linhas.Add(new LinhaDaListaDeVeias
                    {
                        Tag = tag,
                        Formacao = Formacao(cabo),
                        Funcao = Texto(cabo.Funcao),
                        Veia = NomeDaVeia(doCabo[i], numero),
                        Painel1 = NomeDoPainel(nomesDePaineis, ponta1),
                        Dispositivo1 = trecho.Fim1 == null ? string.Empty : trecho.Fim1.Dispositivo,
                        Borne1 = trecho.Fim1 == null ? string.Empty : Terminal(trecho.Fim1.Terminal),
                        Aterrar1 = aterrar1,
                        Painel2 = NomeDoPainel(nomesDePaineis, ponta2),
                        Dispositivo2 = trecho.Fim2 == null ? string.Empty : trecho.Fim2.Dispositivo,
                        Borne2 = trecho.Fim2 == null ? string.Empty : Terminal(trecho.Fim2.Terminal),
                        Aterrar2 = aterrar2,
                        Documento = string.Join(", ", trecho.Documentos.ToArray()),
                        Pagina = Paginas(
                            trecho.Fim1 == null ? string.Empty : trecho.Fim1.Pagina,
                            trecho.Fim2 == null ? string.Empty : trecho.Fim2.Pagina),
                        Comprimento = Comprimento(cabo.Comprimento),
                    });
                }
            }

            return linhas;
        }

        /// <summary>
        /// O <c>qTotal</c> da tela — o <c>lCabosUnico.Count</c> do original: os cabos distintos do
        /// painel que o <c>CarregaVeias4</c> **passou a montar**, isto é, os que têm pelo menos uma
        /// veia acima do piso da reserva. Não é o número de linhas da grade: o cabo cujas veias não
        /// acham trecho no <c>Interligacao4</c> entra na conta e **não** aparece na lista (quirk do
        /// original, medido na rodada 159 — 42 cabos e 22 linhas no painel 503).
        /// </summary>
        public static List<string> CabosDoRelatorio(
            IEnumerable<Cabos4Row> cabos,
            IEnumerable<Veias4Row> veias,
            string revisao,
            int painel)
        {
            List<string> vistos = new List<string>();
            if (cabos == null)
            {
                return vistos;
            }

            foreach (Cabos4Row cabo in cabos)
            {
                if (!MesmaRevisao(cabo, revisao))
                {
                    continue;
                }

                int pn1 = (int)(cabo.Pn1 ?? 0);
                int pn2 = (int)(cabo.Pn2 ?? 0);
                if (painel != pn1 && painel != pn2)
                {
                    continue;
                }

                string tag = Texto(cabo.Tag);
                if (vistos.Contains(tag) || VeiasDoCabo(veias, tag).Count == 0)
                {
                    continue;
                }

                vistos.Add(tag);
            }

            return vistos;
        }

        // ------------------------------------------------------------------ as pontas do trecho

        /// <summary>Uma ponta do trecho, já na ordem do relatório (o <c>_Ponta</c> do módulo do app).</summary>
        private sealed class Ponta
        {
            internal string Tag;
            internal string Terminal;
            internal string NRegua;
            internal string Pagina;
            internal string Documento;

            /// <summary>O `NRegua` manda quando existe; senão a tag (regra do original).</summary>
            internal string Dispositivo
            {
                get { return string.IsNullOrEmpty(NRegua) ? (Tag ?? string.Empty) : NRegua; }
            }
        }

        /// <summary>As duas pontas de um trecho, casadas com as pontas do cabo **por painel**.</summary>
        private sealed class Trecho
        {
            internal Ponta Fim1;
            internal Ponta Fim2;
            internal List<string> Documentos = new List<string>();
        }

        /// <summary>
        /// O <c>_montar_trecho</c> do módulo do app: casa as pontas do <c>Interligacao4</c> com as do
        /// cabo (<paramref name="ponta1"/>/<paramref name="ponta2"/>). O original só entra no bloco
        /// quando <c>Painel1 != 0</c> ou <c>Painel2 != 0</c>; cada ponta é casada por painel e a que não
        /// casa fica vazia.
        /// </summary>
        private static Trecho AcharTrecho(
            IEnumerable<Interligacao4Row> trechos,
            string tag,
            int numero,
            int ponta1,
            int ponta2)
        {
            if (trechos == null)
            {
                return null;
            }

            foreach (Interligacao4Row linha in trechos)
            {
                if (!string.Equals(Texto(linha.Tag_Cabo), tag, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if ((int)(linha.Num_Veia ?? 0) != numero)
                {
                    continue;
                }

                int painel1 = (int)(linha.Painel1 ?? 0);
                int painel2 = (int)(linha.Painel2 ?? 0);
                if (painel1 == 0 && painel2 == 0)
                {
                    return null;
                }

                Ponta a = new Ponta
                {
                    Tag = Texto(linha.Tag1),
                    Terminal = Texto(linha.Terminal1),
                    NRegua = Texto(linha.NRegua1),
                    Pagina = Texto(linha.Pagina1),
                    Documento = Texto(linha.Documento1),
                };

                Ponta b = new Ponta
                {
                    Tag = Texto(linha.Tag2),
                    Terminal = Texto(linha.Terminal2),
                    NRegua = Texto(linha.NRegua2),
                    Pagina = Texto(linha.Pagina2),
                    Documento = Texto(linha.Documento2),
                };

                Trecho trecho = new Trecho();
                if (painel1 == ponta1)
                {
                    trecho.Fim1 = a;
                }
                else if (painel2 == ponta1)
                {
                    trecho.Fim1 = b;
                }

                if (painel2 == ponta2)
                {
                    trecho.Fim2 = b;
                }
                else if (painel1 == ponta2)
                {
                    trecho.Fim2 = a;
                }

                List<string> documentos = new List<string>();
                foreach (Ponta ponta in new[] { a, b })
                {
                    if (!string.IsNullOrEmpty(ponta.Documento))
                    {
                        documentos.Add(ponta.Documento);
                    }
                }

                documentos.Sort(StringComparer.Ordinal);
                for (int i = documentos.Count - 1; i > 0; i--)
                {
                    if (string.Equals(documentos[i], documentos[i - 1], StringComparison.Ordinal))
                    {
                        documentos.RemoveAt(i);
                    }
                }

                trecho.Documentos = documentos;
                return trecho;
            }

            return null;
        }

        // ------------------------------------------------------------------ os campos

        private static List<Veias4Row> VeiasDoCabo(IEnumerable<Veias4Row> veias, string tag)
        {
            List<Veias4Row> doCabo = new List<Veias4Row>();
            if (veias == null)
            {
                return doCabo;
            }

            foreach (Veias4Row veia in veias)
            {
                if (!string.Equals(Texto(veia.Tag), tag, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if ((veia.Num_Veia ?? 0) <= VeiaReservaMinima)
                {
                    continue;
                }

                doCabo.Add(veia);
            }

            doCabo.Sort(delegate (Veias4Row a, Veias4Row b)
            {
                return (a.Num_Veia ?? 0).CompareTo(b.Num_Veia ?? 0);
            });

            return doCabo;
        }

        /// <summary>O <c>Nx</c> da quantidade de cabos e o <c>(...)</c> da blindagem (o <c>_formacao</c>).</summary>
        private static string Formacao(Cabos4Row cabo)
        {
            string formacao = Texto(cabo.Formacao);
            if (cabo.Blindagem)
            {
                formacao = "(" + formacao + ")";
            }

            int cabos = (int)(cabo.Cabos ?? 0);
            if (cabos > 1)
            {
                formacao = cabos.ToString(CultureInfo.InvariantCulture) + "x" + formacao;
            }

            return formacao;
        }

        private static string NomeDaVeia(Veias4Row veia, int numero)
        {
            string nome = Texto(veia.Nome_Veia);
            return string.IsNullOrEmpty(nome) ? numero.ToString(CultureInfo.InvariantCulture) : nome;
        }

        /// <summary>O <c>_paginas</c> do app: iguais saem uma vez; a vazia sai sozinha; senão, <c>", "</c>.</summary>
        private static string Paginas(string primeira, string segunda)
        {
            if (string.Equals(primeira, segunda, StringComparison.Ordinal))
            {
                return primeira;
            }

            if (string.IsNullOrEmpty(primeira))
            {
                return segunda;
            }

            return primeira + ", " + segunda;
        }

        /// <summary>O <c>Indefinido()</c> do original: vazio ou <c>"0"</c> viram o caracter indefinido.</summary>
        private static string Terminal(string valor)
        {
            string texto = Texto(valor);
            return texto.Length == 0 || texto == "0" ? TerminalIndefinido : texto;
        }

        /// <summary>
        /// O comprimento no texto do <c>Conversions.ToString</c> do original: inteiro sai sem casas
        /// (<c>12</c>) e o resto sai na cultura invariante (<c>12.5</c>) — a coluna é <c>Float</c> no
        /// produto.
        /// </summary>
        private static string Comprimento(double? valor)
        {
            if (!valor.HasValue)
            {
                return string.Empty;
            }

            double comprimento = valor.Value;
            if (comprimento == Math.Floor(comprimento) && Math.Abs(comprimento) < 1e15)
            {
                return ((long)comprimento).ToString(CultureInfo.InvariantCulture);
            }

            return comprimento.ToString(CultureInfo.InvariantCulture);
        }

        private static string NomeDoPainel(IReadOnlyDictionary<int, string> nomes, int painel)
        {
            string nome;
            if (nomes != null && nomes.TryGetValue(painel, out nome))
            {
                return nome ?? string.Empty;
            }

            return string.Empty;
        }

        private static bool MesmaRevisao(Cabos4Row cabo, string revisao)
        {
            return cabo != null && string.Equals(Texto(cabo.Revisao), Texto(revisao), StringComparison.OrdinalIgnoreCase);
        }

        private static void Acrescentar(List<int> paineis, long? painel)
        {
            int valor = (int)(painel ?? 0);
            if (valor != 0 && !paineis.Contains(valor))
            {
                paineis.Add(valor);
            }
        }

        private static string Texto(string valor)
        {
            return valor ?? string.Empty;
        }
    }
}
