#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Correcoes
{
    /// <summary>
    /// <c>Geral.CriaTextStyle</c> (<c>Geral.cs:1118</c>): cria o **estilo de texto** do desenho se ele
    /// ainda não existe, com a fonte pedida — o <c>IniciarDWG</c> chama com
    /// <c>("Romans", "romans.shx")</c> na primeira ativação de cada desenho
    /// (<c>Iniciar.cs:145-146</c>), porque os textos do produto usam o estilo <c>Romans</c>
    /// (o <c>RotulosDeCaboDoDesenho</c> do recoder já o procura, caindo no <c>Standard</c> quando
    /// falta).
    ///
    /// O original **engole** a falha (<c>catch</c> com <c>SetProjectError</c>/<c>ClearProjectError</c>,
    /// sem reerguer): um erro ao criar o estilo não pode derrubar o carregamento do desenho. Aqui a
    /// falha é devolvida no retorno — o <c>IniciarDWG</c> registra a linha no log e segue, sem
    /// mensagem ao usuário (o original não mostra nenhuma).
    /// </summary>
    internal static class EstiloDeTextoDoDesenho
    {
        /// <summary>O estilo que o <c>IniciarDWG</c> garante (o par nome/fonte do original).</summary>
        internal const string EstiloRomans = "Romans";

        /// <summary>A fonte daquele estilo.</summary>
        internal const string FonteRomans = "romans.shx";

        /// <summary>
        /// Garante o <c>Romans</c> no desenho ativo. Devolve o estado:
        /// <c>"criado"</c>, <c>"ja existia"</c> ou <c>"falhou — …"</c>.
        /// </summary>
        internal static string GarantirRomans()
        {
            return Garantir(EstiloRomans, FonteRomans);
        }

        /// <summary>O <c>Geral.CriaTextStyle(nome, fonte)</c>.</summary>
        internal static string Garantir(string nome, string fonte)
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return "falhou — sem desenho ativo";
            }

            Database banco = documento.Database;
            try
            {
                using (Transaction transacao = banco.TransactionManager.StartTransaction())
                {
                    TextStyleTable tabela =
                        transacao.GetObject(banco.TextStyleTableId, OpenMode.ForWrite, false) as TextStyleTable;
                    if (tabela == null)
                    {
                        return "falhou — o desenho não tem tabela de estilos de texto";
                    }

                    if (tabela.Has(nome))
                    {
                        transacao.Commit();
                        return "já existia";
                    }

                    // A ordem do original: entra na tabela, a fonte é atribuída depois (o registro ainda
                    // está aberto na transação) e o CAD é avisado do objeto novo.
                    TextStyleTableRecord registro = new TextStyleTableRecord();
                    registro.Name = nome;
                    tabela.Add(registro);
                    registro.FileName = fonte;
                    transacao.AddNewlyCreatedDBObject(registro, true);
                    transacao.Commit();
                    return "criado";
                }
            }
            catch (System.Exception erro)
            {
                return "falhou — " + erro.Message;
            }
        }
    }
}
