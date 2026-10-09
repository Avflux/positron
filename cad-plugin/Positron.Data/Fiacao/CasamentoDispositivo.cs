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
    ///    e exige ≤ 0,5.
    ///
    /// Se tudo passa, o ponto recebe a tag <c>Nome1[/Nome2]</c> e o tipo do
    /// dispositivo.
    ///
    /// Diferenças assumidas e documentadas:
    ///
    /// - O original para no primeiro bloco que casa (ordem do desenho); aqui se
    ///   escolhe o **mais próximo** dentro da tolerância — determinístico.
    /// - O original só aceita o casamento se o bloco também tirar um **terminal**
    ///   não-vazio (<c>ltZUHdAX7R</c>); isso depende de atributos do bloco e fica
    ///   no adapter. Este núcleo valida só a geometria.
    /// - Este núcleo aceita também <c>I</c> (importado), a pedido do projeto,
    ///   embora o <c>frmCompilarFiacao</c> do original o pule — ver
    ///   <see cref="TiposQueDaoTag"/>.
    /// </summary>
    public static class CasamentoDispositivo
    {
        /// <summary>Tolerância do original para o ponto de ligação: 0,5 unidade de desenho.</summary>
        public const double Tolerancia = 0.5;

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

                double distancia = GeometriaBloco.DistanciaMinima(
                    x, y, dispositivo.X, dispositivo.Y, dispositivo.NomeBloco, deslocamentos);
                if (distancia <= menor)
                {
                    menor = distancia;
                    melhor = dispositivo;
                }
            }

            return melhor;
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
