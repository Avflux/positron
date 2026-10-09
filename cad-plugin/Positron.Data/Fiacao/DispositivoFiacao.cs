using System.Collections.Generic;

namespace Positron.Data.Fiacao
{
    /// <summary>
    /// Um **bloco de dispositivo** do desenho já em tipos neutros (sem ZWCAD):
    /// o XData (<see cref="DispositivoFiacaoXData"/>) mais o que só a entidade
    /// sabe — inserção, layer, handle, nome do bloco e bounding-box.
    ///
    /// É o que dá a **tag** ao ponto de fiação **não-borne** no
    /// <c>frmCompilarFiacao</c>: quando o ponto não casa com um borne
    /// (<see cref="CasamentoBorne"/>), ele é casado com o dispositivo mais
    /// próximo (<see cref="CasamentoDispositivo"/>) e recebe
    /// <c>Nome1[/Nome2]</c> como tag (o trecho do original que faz
    /// <c>pont.tag = sRegua</c>).
    /// </summary>
    public sealed class DispositivoFiacao
    {
        /// <summary>Tipo do dispositivo: <c>"P"</c> (dispositivo), <c>"E"</c> (porta), <c>"A"</c> (auxiliar), <c>"M"</c> (máscara) ou <c>"I"</c> (importado).</summary>
        public string Tipo { get; set; }

        /// <summary>Nome principal do dispositivo — vira a <c>tag</c> (<c>sRegua</c> no original).</summary>
        public string Nome1 { get; set; }

        /// <summary>Nome complementar — concatenado à tag com <c>"/"</c> quando presente.</summary>
        public string Nome2 { get; set; }

        public string Alternativo { get; set; }

        /// <summary>Painel do dispositivo. Em <c>"E"</c>/<c>"A"</c> vem do bloco da máscara (ver <see cref="PainelPendente"/>).</summary>
        public short Painel { get; set; }

        /// <summary>
        /// <c>true</c> quando o painel ainda não foi resolvido: em <c>"E"</c>/<c>"A"</c>
        /// o original lê o painel do bloco apontado por <see cref="HandleMascara"/>
        /// (<c>BuscaPainelDispositivo</c>), o que exige o desenho — o adapter faz isso.
        /// </summary>
        public bool PainelPendente { get; set; }

        /// <summary>Handle do bloco da máscara (só em <c>"E"</c>/<c>"A"</c>).</summary>
        public string HandleMascara { get; set; }

        public int IndexModelo { get; set; }

        public bool Complementar { get; set; }

        /// <summary>
        /// Bloco topográfico gravado no **próprio XData** do dispositivo —
        /// usado quando <see cref="IndexModelo"/> é 0 (o original lê o modelo do
        /// dicionário só quando há índice; sem ele, cai no XData:
        /// <c>StructureDispositivo.Topografico</c>).
        /// </summary>
        public string Topografico { get; set; }

        /// <summary>Bloco de layout do próprio XData (o par de <see cref="Topografico"/>).</summary>
        public string Layout { get; set; }

        /// <summary>Handle do próprio bloco no desenho.</summary>
        public string Handle { get; set; }

        public string Layer { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        /// <summary>Nome da definição do bloco (o <c>BlockReference.Name</c>) — chave da tabela de deslocamento.</summary>
        public string NomeBloco { get; set; }

        /// <summary>
        /// Atributos de terminal do bloco (<c>T*</c>/<c>B*</c>), com a posição de
        /// cada um. O adapter lê do desenho; o núcleo
        /// (<see cref="CasamentoDispositivo"/>) escolhe o mais próximo do ponto e
        /// só aceita o casamento se o terminal for não-vazio — o <c>ltZUHdAX7R</c>
        /// do original.
        /// </summary>
        public IList<TerminalDispositivo> Terminais { get; } = new List<TerminalDispositivo>();

        public bool TemBounds { get; set; }

        public double MinX { get; set; }

        public double MinY { get; set; }

        public double MaxX { get; set; }

        public double MaxY { get; set; }

        /// <summary>A tag do ponto não-borne: <c>Nome1</c>, com <c>"/Nome2"</c> quando há complemento.</summary>
        public string Tag
        {
            get
            {
                if (string.IsNullOrEmpty(Nome2))
                {
                    return Nome1;
                }

                return Nome1 + "/" + Nome2;
            }
        }

        /// <summary>Fixa o painel resolvido pelo desenho (adapter) e limpa a pendência.</summary>
        public void DefinirPainel(short painel)
        {
            Painel = painel;
            PainelPendente = false;
        }
    }
}
