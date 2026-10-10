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

        /// <summary>Handle da própria polilinha — o <c>m_Fiacao[i].Handle</c> do original.</summary>
        public string Handle { get; set; }

        /// <summary>
        /// O <c>HandleSup</c> do verificador: <c>"OK"</c> por padrão e, nas conexões
        /// <c>Tipo 3</c>, o campo <c>Handle</c> do XData — que aponta para a conexão
        /// com que esta se superpõe. Vazio é órfão (o laço do <c>carregaOrfao</c>).
        /// </summary>
        public string HandleSuperposto { get; set; }

        /// <summary>Layer da polilinha — a página (<c>sPaginaa</c>) do verificador.</summary>
        public string Pagina { get; set; }

        /// <summary>
        /// Campo <c>Jumper</c> do XData. O verificador do original <b>descarta</b> as
        /// conexões com <c>Jumper == "JUMPER"</c> antes de montar o conjunto
        /// (<c>ClsVerificadorProjetoFiacao:791</c>): elas são do <c>JMP</c>, não da fiação.
        /// </summary>
        public string Jumper { get; set; }

        /// <summary>
        /// Campo <c>Disp1</c> do XData (ponta 1 ligada). Só o verificador da
        /// interligação usa: o jumper só entra na checagem de duplicados quando
        /// <c>Tipo == 4</c> e <b>as duas</b> pontas estão ligadas
        /// (<c>ClsVerificadorProjetoFiacao:791</c>, modo <c>"J"</c>).
        /// </summary>
        public bool Disp1 { get; set; }

        /// <summary>Campo <c>Disp2</c> do XData (ponta 2 ligada) — espelho de <see cref="Disp1"/>.</summary>
        public bool Disp2 { get; set; }
    }
}
