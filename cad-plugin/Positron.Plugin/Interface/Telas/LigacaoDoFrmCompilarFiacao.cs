namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A ligação do <c>frmCompilarFiacao</c> — a tela do <c>FIA</c> do original (507 x 407, a maior das
    /// três). O <c>btAnalisar</c> roda o pipeline <c>FIA</c> (a projeção da fiação e das tabelas
    /// <c>Portas4F</c>/<c>Bornes4F</c>/<c>Contatos4F</c>/<c>Dispositivos4F</c>/<c>Circuitos4F</c>/
    /// <c>Aplicacao4F</c>), a <c>dgERROS</c> abre com os problemas da revisão e a <c>dgRevisao</c> com as
    /// revisões do DWG no banco.
    /// 
    /// Os três controles que só esta tela tem — a <c>dgEquip</c> (os equipamentos da revisão), o
    /// <c>tbPaineis</c> (os painéis) e o <c>cbPreservar</c> — ficam como o designer os desenhou: no
    /// original eles são preenchidos pelo Analisar junto com a lista que este recoder já grava no banco
    /// (<c>Fiacao</c>/<c>Dispositivos4F</c>), e ligá-los é trabalho da rodada que portar a leitura do
    /// banco para a tela (a regra de hoje já está no comando <c>FIA</c>, medido).
    /// </summary>
    internal sealed class LigacaoDoFrmCompilarFiacao : LigacaoDeCompilacao
    {
        public override string NomeDaTela
        {
            get { return "frmCompilarFiacao"; }
        }

        protected override string Comando
        {
            get { return "FIA"; }
        }

        protected override string Executar(string revisao)
        {
            return Comandos.ExecutarFiacao(revisao);
        }
    }
}
