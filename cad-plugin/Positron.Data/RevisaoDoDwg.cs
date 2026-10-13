namespace Positron.Data
{
    /// <summary>
    /// Uma **revisão do DWG** que já tem compilação gravada no projeto — o que a grade
    /// <c>dgRevisao</c> das telas <c>frmCompilar*</c> mostra (<c>Revisão</c>, <c>Data</c> e
    /// <c>Criador</c>). Sai das tabelas dos três pipelines (<c>Fiacao</c>, <c>Interligacao4</c>,
    /// <c>Jumper4</c>), que guardam <c>Criador</c>/<c>Data</c> em cada linha: a revisão aparece
    /// **uma vez**, com o carimbo da linha mais recente.
    ///
    /// O <c>Data</c> fica como <c>string</c> de propósito: o schema o declara <c>DATETIME</c> e o
    /// <c>System.Data.SQLite</c> devolve o valor como o texto que gravou (o mesmo que o resto do
    /// <c>ProjectStore</c> lê).
    /// </summary>
    public sealed class RevisaoDoDwg
    {
        public string Revisao { get; set; }

        public string Criador { get; set; }

        public string Data { get; set; }
    }
}
