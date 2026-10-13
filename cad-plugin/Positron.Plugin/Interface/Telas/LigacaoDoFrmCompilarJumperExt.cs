namespace Positron.Plugin.Interface.Telas
{
    /// <summary>
    /// A ligação do <c>frmCompilarJumperExt</c> — a tela do <c>JMP</c> do original (o "Jumper Externo"). O
    /// <c>btAnalisar</c> roda o pipeline <c>JMP</c> (as conexões <c>Tipo 4</c> e as <c>Tipo 3</c> com
    /// <c>Jumper == "JUMPER"</c>, casadas por ponta e gravadas em <c>Jumper4</c> — a mesma máquina do
    /// <c>FIA</c> com a tabela de destino trocada), a <c>dgERROS</c> abre com os problemas da revisão e a
    /// <c>dgRevisao</c> com as revisões do DWG no banco.
    /// 
    /// O <c>cbPreservar</c> desta tela fica como o designer o desenhou (o original o lê no meio da
    /// compilação para não apagar o que já existe; o pipeline do recoder substitui a revisão inteira,
    /// como os outros dois).
    /// </summary>
    internal sealed class LigacaoDoFrmCompilarJumperExt : LigacaoDeCompilacao
    {
        public override string NomeDaTela
        {
            get { return "frmCompilarJumperExt"; }
        }

        protected override string Comando
        {
            get { return "JMP"; }
        }

        protected override string Executar(string revisao)
        {
            return Comandos.ExecutarJumper(revisao);
        }
    }
}
