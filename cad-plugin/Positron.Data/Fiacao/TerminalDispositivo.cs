namespace Positron.Data.Fiacao
{
    /// <summary>
    /// Um atributo de **terminal** (<c>T*</c>/<c>B*</c>) de um bloco de
    /// dispositivo, já em tipos neutros: a tag do atributo, o texto e a posição
    /// no desenho.
    ///
    /// É o insumo da segunda checagem do <c>ltZUHdAX7R</c> do original: o bloco
    /// só casa com o ponto **não-borne** se dele sair um terminal não-vazio — o
    /// atributo <c>T&lt;n&gt;</c> (ou <c>B&lt;n&gt;</c>, no <c>E</c>) mais próximo
    /// do ponto. A leitura do atributo é do adapter; a escolha e a validação
    /// ficam no núcleo (<see cref="CasamentoDispositivo"/>).
    /// </summary>
    public sealed class TerminalDispositivo
    {
        /// <summary>Tag do atributo, como está no bloco — <c>T1</c>, <c>B2</c>, etc.</summary>
        public string Atributo { get; set; }

        /// <summary>Texto do atributo (o terminal) — o que vira <c>Terminal</c> na fiação.</summary>
        public string Texto { get; set; }

        public double X { get; set; }

        public double Y { get; set; }
    }
}
