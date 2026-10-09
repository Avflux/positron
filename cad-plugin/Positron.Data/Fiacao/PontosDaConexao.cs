namespace Positron.Data.Fiacao
{
    /// <summary>
    /// De **qual** ponta de uma <c>CONEXAO</c> nasce um ponto de fiação — as
    /// condições do <c>frmCompilarFiacao</c> do original (linhas ~1547 e ~1565):
    ///
    /// | ponta | condição |
    /// |-------|----------|
    /// | primeiro vértice | <c>(Tipo == 1 &amp;&amp; Disp1) || Tipo == 2</c> |
    /// | último vértice | <c>(Tipo == 1 &amp;&amp; Disp2) || Tipo == 2 || (Tipo == 3 &amp;&amp; Jumper == "")</c> |
    ///
    /// Uma <c>CONEXAO</c> pode gerar **dois** pontos (Tipo 2, ou Tipo 1 com os dois
    /// flags) ou **nenhum** (Tipo 1 sem flag, Tipo 4).
    ///
    /// **Regressão medida no desenho real:** a leitura criava **um** ponto por
    /// polilinha, sempre no primeiro vértice. Nas 365 conexões do desenho isso dava
    /// 365 pontos onde o original cria **494** (170 primeiros + 324 últimos), e —
    /// pior — 167 conexões Tipo 3 tinham o ponto no vértice errado, o que deixava o
    /// borne da outra ponta sem casar (193 órfãos no `VERIF`).
    /// </summary>
    public static class PontosDaConexao
    {
        /// <summary>O ponto nasce do **primeiro** vértice da polilinha?</summary>
        public static bool UsaPrimeiroVertice(ConexaoXData conexao)
        {
            if (conexao == null)
            {
                return false;
            }

            return (conexao.Tipo == 1 && conexao.Disp1) || conexao.Tipo == 2;
        }

        /// <summary>O ponto nasce do **último** vértice da polilinha?</summary>
        public static bool UsaUltimoVertice(ConexaoXData conexao)
        {
            if (conexao == null)
            {
                return false;
            }

            if ((conexao.Tipo == 1 && conexao.Disp2) || conexao.Tipo == 2)
            {
                return true;
            }

            // O original compara o jumper **sem** trim (`Jumper.ToUpper() == ""`);
            // espaço em branco conta como jumper preenchido.
            return conexao.Tipo == 3 && string.IsNullOrEmpty(conexao.Jumper);
        }
    }
}
