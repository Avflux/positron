namespace Positron.Data.Fiacao
{
    /// <summary>
    /// Uma <c>CONEXAO</c> lida do desenho, com o que os geradores que **varrem o
    /// desenho** (não os pontos projetados) precisam: tipo, painel, potencial e nome.
    ///
    /// Existe porque nem todo gerador parte dos pontos de fiação. O `t6yXrlfi5w`
    /// (Circuitos4F) varre o ModelSpace atrás de polylines `CONEXAO` e aceita as
    /// `Tipo == 1` com nome preenchido — **independente** de a conexão gerar ponto de
    /// fiação (que depende de `Disp1`/`Disp2`/`Jumper`). Medido contra o banco do
    /// produto: o desenho tem 11 conexões Tipo-1 com nome e o original gravou 11
    /// circuitos; alimentando o gerador com os pontos saíam só 7.
    /// </summary>
    public sealed class ConexaoFiacao
    {
        public short Tipo { get; set; }

        public short Painel { get; set; }

        public int Potencial { get; set; }

        public string Nome { get; set; }

        public string Secao { get; set; }

        public string Cor { get; set; }
    }
}
