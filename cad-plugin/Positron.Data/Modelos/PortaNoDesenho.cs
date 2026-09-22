using System.Collections.Generic;

namespace Positron.Data.Modelos
{
    /// <summary>
    /// Um atributo de um **bloco de porta** (<c>E</c>) do desenho: a tag
    /// (<c>T1</c>, <c>B2</c>, <c>R3</c>…), o texto e se está visível. É o insumo
    /// cru do <c>bt14PortasDiscrepantes</c>, que compara o bloco com o modelo.
    /// </summary>
    public sealed class AtributoPorta
    {
        public string Tag { get; set; }

        public string Texto { get; set; }

        public bool Visivel { get; set; }
    }

    /// <summary>
    /// Um **bloco de porta** (<c>E</c>) do desenho já em tipos neutros: o handle, o
    /// modelo e a porta que ele referencia (o XData <c>Dispositivo</c>) mais os
    /// atributos <c>T*</c>/<c>B*</c>/<c>R*</c>. É o segundo lado do
    /// <c>bt14PortasDiscrepantes</c> — o primeiro é o modelo (<see cref="ModeloPorta"/>).
    /// </summary>
    public sealed class PortaNoDesenho
    {
        /// <summary>Handle do bloco no desenho.</summary>
        public string Handle { get; set; }

        /// <summary>Índice do modelo de máscara referenciado (<c>array[5]</c> do XData).</summary>
        public int IndiceModelo { get; set; }

        /// <summary>Índice da porta no modelo (<c>array[6]</c> do XData); 0 quando não é porta.</summary>
        public int IndiceDaPorta { get; set; }

        /// <summary>Nome principal do XData da porta (<c>Nome1</c>) — entra no rótulo da máscara.</summary>
        public string Nome1 { get; set; }

        /// <summary>Nome complementar do XData da porta (<c>Nome2</c>).</summary>
        public string Nome2 { get; set; }

        /// <summary>
        /// Painel da **máscara** referenciada (<c>BuscaPainelDispositivo</c> do original,
        /// resolvido pelo bloco apontado em <c>array[4]</c>) — o prefixo do rótulo da
        /// máscara (<c>BuscaNomeDoPainel(painel) + "/" + Nome1[-Nome2]</c>).
        /// </summary>
        public short Painel { get; set; }

        public IList<AtributoPorta> Atributos { get; } = new List<AtributoPorta>();
    }
}
