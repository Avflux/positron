using System;
using System.Collections.Generic;
using Positron.Data.Bornes;

namespace Positron.Data.Fiacao
{
    /// <summary>
    /// Liga um ponto de fiação **não-borne** ao bloco de dispositivo mais próximo
    /// — a parte pura do trecho de <c>frmCompilarFiacao</c> que faz
    /// <c>pont.tag = sRegua</c> quando o ponto não casa com um borne.
    ///
    /// **Regra recuperada do reverso.** Para cada ponto, o original consulta os
    /// blocos vizinhos (mesmo layer, dentro da bounding-box) e, por bloco:
    ///
    /// 1. descobre o tipo (<c>verificaTipoDispositivo</c>); só <c>B</c>/<c>P</c>/
    ///    <c>A</c>/<c>E</c> prosseguem (o <c>I</c> e o <c>M</c> são pulados);
    /// 2. lê os nomes e o painel do dispositivo;
    /// 3. exige <c>painel do ponto == painel do dispositivo</c> **e**
    ///    <c>painel &gt; 0</c>;
    /// 4. exige o ponto dentro da bounding-box ±0,25
    ///    (<see cref="GeometriaBloco.DentroDosBounds"/>);
    /// 5. mede a distância aos pontos de ligação do bloco
    ///    (<c>inserção + deslocamento</c>, <see cref="TabelaDeslocamentoBlocos"/>)
    ///    e exige ≤ 0,5;
    /// 6. exige que o bloco tire um **terminal não-vazio**: o atributo
    ///    <c>T&lt;n&gt;</c> (ou <c>B&lt;n&gt;</c>, no <c>E</c>) mais próximo do
    ///    ponto, com texto não-vazio e diferente de
    ///    <see cref="TerminalIndefinido"/> (<c>"?"</c>) — o <c>ltZUHdAX7R</c> do
    ///    original.
    ///
    /// Se tudo passa, o ponto recebe a tag <c>Nome1[/Nome2]</c> e o tipo do
    /// dispositivo, e o terminal escolhido sai no <c>out string terminal</c>.
    ///
    /// Diferenças assumidas e documentadas:
    ///
    /// - O original para no primeiro bloco que casa (ordem do desenho); aqui se
    ///   escolhe o **mais próximo** dentro da tolerância — determinístico.
    /// - Este núcleo aceita também <c>I</c> (importado), a pedido do projeto,
    ///   embora o <c>frmCompilarFiacao</c> do original o pule — ver
    ///   <see cref="TiposQueDaoTag"/>. Para o <c>I</c> só o prefixo <c>T</c>
    ///   conta (é o que o original lê para os tipos de dispositivo).
    /// </summary>
    public static class CasamentoDispositivo
    {
        /// <summary>Tolerância do original para o ponto de ligação: 0,5 unidade de desenho.</summary>
        public const double Tolerancia = 0.5;

        /// <summary>
        /// Texto do terminal que o original trata como indefinido
        /// (<c>DeclaracoesGeral.Conf.CaracterTerminalIndefinido</c>, default
        /// <c>"?"</c>): o bloco que só tira esse texto **não** casa.
        /// </summary>
        public const string TerminalIndefinido = "?";

        /// <summary>
        /// Tipos de dispositivo que dão tag ao ponto não-borne. <c>I</c> é
        /// extensão deste projeto (o original pula <c>I</c>/<c>M</c> no
        /// <c>frmCompilarFiacao</c>); <c>M</c> nunca entra — é máscara.
        /// </summary>
        public static readonly IReadOnlyList<string> TiposQueDaoTag = new[] { "P", "E", "A", "I" };

        /// <summary>Dispositivo mais próximo do ponto dentro da tolerância, ou <c>null</c>.</summary>
        public static DispositivoFiacao Proximo(
            double x,
            double y,
            string layer,
            short painel,
            IEnumerable<DispositivoFiacao> dispositivos,
            double tolerancia,
            TabelaDeslocamentoBlocos deslocamentos)
        {
            string ignorado;
            return Proximo(x, y, layer, painel, dispositivos, tolerancia, deslocamentos, out ignorado);
        }

        /// <summary>
        /// Como o anterior, devolvendo em <paramref name="terminal"/> o terminal
        /// escolhido do dispositivo (o atributo <c>T*</c>/<c>B*</c> mais próximo
        /// do ponto). Só casa quando esse terminal é não-vazio e diferente de
        /// <see cref="TerminalIndefinido"/>.
        /// </summary>
        public static DispositivoFiacao Proximo(
            double x,
            double y,
            string layer,
            short painel,
            IEnumerable<DispositivoFiacao> dispositivos,
            double tolerancia,
            TabelaDeslocamentoBlocos deslocamentos,
            out string terminal)
        {
            terminal = null;

            if (dispositivos == null)
            {
                return null;
            }

            DispositivoFiacao melhor = null;
            double menor = tolerancia;

            foreach (DispositivoFiacao dispositivo in dispositivos)
            {
                if (dispositivo == null || !DaTag(dispositivo.Tipo))
                {
                    continue;
                }

                if (!GeometriaBloco.MesmoLayer(layer, dispositivo.Layer))
                {
                    continue;
                }

                // Painel pendente (E/A sem o bloco da máscara) ou fora do
                // desenho não casa: o original exige painel > 0.
                if (dispositivo.Painel <= 0)
                {
                    continue;
                }

                // O original exige igualdade dos painéis; painel 0 no ponto é
                // "desconhecido" e não restringe (mesma convenção dos bornes).
                if (painel > 0 && dispositivo.Painel != painel)
                {
                    continue;
                }

                if (!GeometriaBloco.DentroDosBounds(
                        x,
                        y,
                        dispositivo.TemBounds,
                        dispositivo.MinX,
                        dispositivo.MinY,
                        dispositivo.MaxX,
                        dispositivo.MaxY))
                {
                    continue;
                }

                // Só casa o bloco que tira um terminal não-vazio (ltZUHdAX7R).
                string encontrado;
                if (!EscolherTerminal(dispositivo, x, y, out encontrado))
                {
                    continue;
                }

                double distancia = GeometriaBloco.DistanciaMinima(
                    x, y, dispositivo.X, dispositivo.Y, dispositivo.NomeBloco, deslocamentos);
                if (distancia <= menor)
                {
                    menor = distancia;
                    melhor = dispositivo;
                    terminal = encontrado;
                }
            }

            return melhor;
        }

        /// <summary>
        /// Escolhe o terminal do bloco: o atributo <c>T&lt;n&gt;</c> (ou
        /// <c>B&lt;n&gt;</c>, no <c>E</c>) mais próximo do ponto, exigindo texto
        /// não-vazio e diferente de <see cref="TerminalIndefinido"/> — a segunda
        /// checagem do <c>ltZUHdAX7R</c>.
        /// </summary>
        public static bool EscolherTerminal(
            DispositivoFiacao dispositivo,
            double x,
            double y,
            out string terminal)
        {
            terminal = null;
            if (dispositivo == null || dispositivo.Terminais == null)
            {
                return false;
            }

            double menor = double.MaxValue;
            foreach (TerminalDispositivo candidato in dispositivo.Terminais)
            {
                if (candidato == null)
                {
                    continue;
                }

                string atributo = (candidato.Atributo ?? string.Empty).Trim().ToUpperInvariant();
                if (atributo.Length < 2)
                {
                    continue;
                }

                if (!LetraAceita(dispositivo.Tipo, atributo[0]))
                {
                    continue;
                }

                // O original exige sufixo numérico (T1, B12): T/B sem número não conta.
                if (!SomenteDigitos(atributo.Substring(1)))
                {
                    continue;
                }

                double distancia = GeometriaBloco.Distancia(candidato.X, candidato.Y, x, y);
                if (distancia < menor)
                {
                    menor = distancia;
                    terminal = candidato.Texto;
                }
            }

            if (terminal == null)
            {
                return false;
            }

            string limpo = terminal.Trim();
            return limpo.Length > 0
                && !string.Equals(limpo, TerminalIndefinido, StringComparison.Ordinal);
        }

        /// <summary>
        /// Prefixo do atributo de terminal aceito por tipo: o <c>E</c> (porta) lê
        /// <c>T*</c> e <c>B*</c>; os demais (<c>P</c>/<c>A</c>/<c>I</c>) só
        /// <c>T*</c>, como o original.
        /// </summary>
        private static bool LetraAceita(string tipo, char letra)
        {
            if (string.Equals(tipo, DispositivoFiacaoXData.TipoPorta, StringComparison.OrdinalIgnoreCase))
            {
                return letra == 'T' || letra == 'B';
            }

            return letra == 'T';
        }

        private static bool SomenteDigitos(string texto)
        {
            if (texto.Length == 0)
            {
                return false;
            }

            foreach (char c in texto)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
        }

        private static bool DaTag(string tipo)
        {
            if (string.IsNullOrEmpty(tipo))
            {
                return false;
            }

            foreach (string aceito in TiposQueDaoTag)
            {
                if (string.Equals(aceito, tipo, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
