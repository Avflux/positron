using System.Windows.Forms;

namespace Positron.Plugin.Interface
{
    /// <summary>
    /// A **ligação de uma tela**: o que fazer quando a janela do designer abre. É o contrato que
    /// faz a integração dos métodos do original ser um passo de cada vez — **uma tela por arquivo**
    /// (o molde é o <see cref="LigacaoDoFrmPesquisaXdatas"/>).
    /// </summary>
    /// <remarks>
    /// O que entra aqui é a **regra do recoder** (a mesma que o comando equivalente já usa e que já
    /// foi medida no desenho), ligada ao controle pelo `Name` do designer — nunca uma cópia da
    /// lógica do original. A receita completa (e as duas diferenças deliberadas) está no RUNBOOK,
    /// rodada 130.
    /// </remarks>
    internal interface ILigacaoDeTela
    {
        /// <summary>O `Name` da tela no original (o `frm*`, a mesma chave do mapa).</summary>
        string NomeDaTela { get; }

        /// <summary>
        /// Liga os controles à regra. A janela já está **montada** (fiel ao designer) e ainda não
        /// foi mostrada. Não precisa tratar erro: o registro já faz isso.
        /// </summary>
        void Preencher(Form janela);
    }
}
