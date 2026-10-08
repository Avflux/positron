namespace Positron.Data.Bornes
{
    /// <summary>
    /// Um borne do desenho já em tipos neutros (sem ZWCAD): o XData
    /// (<see cref="BorneXData"/>) mais o que só a entidade sabe — posição de
    /// inserção, layer e handle.
    ///
    /// É o que o casamento (<see cref="CasamentoBorne"/>) usa para ligar um ponto
    /// de fiação ao borne mais próximo. O nome da régua
    /// (<see cref="NomeRegua"/>) e o painel vêm do dicionário de réguas
    /// (<see cref="ReguasModelo"/>), resolvidos por <see cref="IndiceRegua"/>.
    /// </summary>
    public sealed class PontoBorne
    {
        /// <summary>Handle do bloco do borne no desenho.</summary>
        public string Handle { get; set; }

        public string Layer { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        /// <summary>Número do terminal (com complemento), como vai para <c>Terminal</c>.</summary>
        public string Terminal { get; set; }

        /// <summary>Ordem do terminal na régua — vira <c>TerminalNum</c>.</summary>
        public double Ordem { get; set; }

        /// <summary>Número do borne (sem complemento).</summary>
        public string Numero { get; set; }

        public int Lm { get; set; }

        public string Orientacao { get; set; }

        public string BlocoLayout { get; set; }

        public int IndiceRegua { get; set; }

        public int Tipo { get; set; }

        /// <summary>Painel do borne — resolvido pelo dicionário de réguas.</summary>
        public short Painel { get; set; }

        /// <summary>Nome da régua — resolvido pelo dicionário de réguas.</summary>
        public string NomeRegua { get; set; }

        /// <summary>Nome alternativo da régua — vira <c>Alternativo</c>.</summary>
        public string Alternativo { get; set; }

        /// <summary>
        /// A partir do XData de um borne e dos dados de entidade, resolve régua e
        /// painel pelo dicionário (se disponível).
        /// </summary>
        public static PontoBorne DeBorne(BorneXData borne, string handle, string layer, double x, double y, ReguasModelo reguas)
        {
            ReguaInfo regua = reguas == null ? null : reguas.Buscar(borne.IndiceRegua);

            return new PontoBorne
            {
                Handle = handle,
                Layer = layer,
                X = x,
                Y = y,
                Terminal = borne.Terminal,
                Ordem = borne.Ordem,
                Numero = borne.Numero,
                Lm = borne.Lm,
                Orientacao = borne.Orientacao,
                BlocoLayout = borne.BlocoLayout,
                IndiceRegua = borne.IndiceRegua,
                Tipo = borne.Tipo,
                Painel = regua == null ? (short)0 : regua.Painel,
                NomeRegua = regua == null ? null : regua.Nome,
                Alternativo = regua == null ? null : regua.Alternativo,
            };
        }
    }
}
