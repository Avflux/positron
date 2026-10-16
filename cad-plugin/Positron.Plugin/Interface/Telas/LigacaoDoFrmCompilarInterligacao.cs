namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A ligação do <c>frmCompilarInterligacao</c> — a tela do <c>INT</c> do original. O <c>btAnalisar</c>
    /// roda o pipeline <c>INT</c> (a projeção de <c>Interligacao4</c> e das tabelas <c>Portas4I</c>/
    /// <c>Bornes4I</c>/<c>Cabos4</c>/<c>Veias4</c>), a <c>dgERROS</c> abre com os problemas da revisão e a
    /// <c>dgRevisao</c> com as revisões do DWG no banco.
    /// 
    /// O botão é o irmão do <c>frmCompilarFiacao</c>: a casca é a mesma (<see cref="LigacaoDeCompilacao"/>),
    /// o que muda é o pipeline e o que a tela não tem (a grade de equipamentos e o campo dos painéis).
    /// </summary>
    internal sealed class LigacaoDoFrmCompilarInterligacao : LigacaoDeCompilacao
    {
        public override string NomeDaTela
        {
            get { return "frmCompilarInterligacao"; }
        }

        protected override string Comando
        {
            get { return "INT"; }
        }

        protected override string DicaAnalisar
        {
            get { return "Analisar Interligação"; }
        }

        protected override string DicaSalvar
        {
            get { return "Salvar nova revisão da interligação"; }
        }

        protected override string Executar(string revisao)
        {
            return Comandos.ExecutarInterligacao(revisao);
        }
    }
}
