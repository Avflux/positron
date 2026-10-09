using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Layout;

namespace Positron.Data.Modelos
{
    /// <summary>Blocos topográfico/layout de um modelo (de contato ou de máscara).</summary>
    public sealed class BlocoDoModelo
    {
        public string BlocoTopografico { get; set; }

        public string BlocoLayout { get; set; }
    }

    /// <summary>Uma linha de <c>Dispositivos4F</c>.</summary>
    public sealed class Dispositivo4F
    {
        public string Tipo { get; set; }

        public short Painel { get; set; }

        public string Tag { get; set; }

        public string Alternativo { get; set; }

        public string Handle { get; set; }

        public string Pagina { get; set; }

        public string BlocoTopografico { get; set; }

        public string BlocoLayout { get; set; }

        public int PosicaoNum { get; set; }

        public int Ordem { get; set; }
    }

    /// <summary>
    /// Gera <c>Dispositivos4F</c> — o trecho do <c>frmCompilarFiacao</c> do
    /// original (linhas 2640–2793) que grava **um dispositivo por bloco**:
    ///
    /// - um por bloco de **dispositivo** (<c>P</c>);
    /// - um por bloco de **máscara** (<c>M</c>).
    ///
    /// Os demais tipos (<c>E</c>/<c>A</c>/<c>I</c>/<c>B</c>) são pulados aqui,
    /// como no original — só <c>P</c> e <c>M</c> chegam à
    /// <c>AdicionaItemDispositivos</c>. Bloco <c>Complementar</c> ou de painel
    /// fora de uso também é pulado.
    ///
    /// Colunas:
    /// - <c>Tag</c> = <c>Nome1[/Nome2]</c>, <c>Alternativo</c> e <c>Handle</c> do bloco;
    /// - <c>Pagina</c> = layer do bloco (o caso <c>0..2</c> do
    ///   <c>Conf.incluirColuna</c>, o mesmo projetado no `Fiacao`/`Bornes4F`);
    /// - <c>BlocoTopografico</c>/<c>BlocoLayout</c> = do **modelo** casado por
    ///   <c>IndexModelo</c>: no <c>P</c> o dicionário de modelos de contato
    ///   (`DicionarioContatos` do original), no <c>M</c> o de máscaras
    ///   (`DicionarioMascaras`);
    /// - <c>PosicaoNum</c>/<c>Ordem</c> = da tabela de posições do layout,
    ///   casada por <c>(painel, tag)</c> — `mPosicao`/`CENG_LAYOUT` no original.
    ///
    /// **Limite assumido:** quando o <c>P</c> tem <c>IndexModelo == 0</c>, o
    /// original lê <c>Topografico</c>/<c>Layout</c> do próprio XData do bloco;
    /// o leitor atual (`DispositivoFiacaoXData`) não expõe esses índices, então
    /// as duas colunas saem vazias (ausente, não inventado).
    /// </summary>
    public static class Dispositivos4FGerador
    {
        public static List<Dispositivo4F> Gerar(
            IEnumerable<DispositivoFiacao> blocos,
            ICollection<int> paineisEmUso,
            IReadOnlyDictionary<int, BlocoDoModelo> modelosDeDispositivo,
            IReadOnlyDictionary<int, BlocoDoModelo> modelosDeMascara,
            LayoutPosicoes posicoes)
        {
            List<Dispositivo4F> linhas = new List<Dispositivo4F>();
            if (blocos == null)
            {
                return linhas;
            }

            foreach (DispositivoFiacao bloco in blocos)
            {
                if (bloco == null)
                {
                    continue;
                }

                string tipo = Normalizar(bloco.Tipo);
                bool dispositivo = string.Equals(tipo, DispositivoFiacaoXData.TipoDispositivo, StringComparison.Ordinal);
                bool mascara = string.Equals(tipo, DispositivoFiacaoXData.TipoMascara, StringComparison.Ordinal);
                if (!dispositivo && !mascara)
                {
                    continue;
                }

                if (bloco.Complementar)
                {
                    continue;
                }

                if (paineisEmUso != null && !paineisEmUso.Contains(bloco.Painel))
                {
                    continue;
                }

                string tag = bloco.Tag;
                string topografico = null;
                string layout = null;

                if (dispositivo)
                {
                    if (bloco.IndexModelo != 0)
                    {
                        PreencherDoModelo(modelosDeDispositivo, bloco.IndexModelo, out topografico, out layout);
                    }
                }
                else if (bloco.IndexModelo > 0)
                {
                    PreencherDoModelo(modelosDeMascara, bloco.IndexModelo, out topografico, out layout);
                }

                int posicaoNum = 0;
                int ordem = 0;
                PosicaoLayout posicao = posicoes == null ? null : posicoes.Buscar(bloco.Painel, tag);
                if (posicao != null)
                {
                    posicaoNum = posicao.PosicaoNum;
                    ordem = posicao.Ordem;
                }

                linhas.Add(new Dispositivo4F
                {
                    Tipo = tipo,
                    Painel = bloco.Painel,
                    Tag = tag,
                    Alternativo = bloco.Alternativo,
                    Handle = bloco.Handle,
                    Pagina = bloco.Layer,
                    BlocoTopografico = topografico,
                    BlocoLayout = layout,
                    PosicaoNum = posicaoNum,
                    Ordem = ordem,
                });
            }

            return linhas;
        }

        private static void PreencherDoModelo(
            IReadOnlyDictionary<int, BlocoDoModelo> modelos,
            int indexModelo,
            out string topografico,
            out string layout)
        {
            topografico = null;
            layout = null;

            BlocoDoModelo modelo;
            if (modelos != null && modelos.TryGetValue(indexModelo, out modelo) && modelo != null)
            {
                topografico = modelo.BlocoTopografico;
                layout = modelo.BlocoLayout;
            }
        }

        private static string Normalizar(string tipo)
        {
            return string.IsNullOrEmpty(tipo) ? null : tipo.Trim().ToUpperInvariant();
        }
    }
}
