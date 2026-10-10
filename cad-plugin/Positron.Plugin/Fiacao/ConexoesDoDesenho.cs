using System.Collections.Generic;
using Positron.Data.Fiacao;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Fiacao
{
    /// <summary>
    /// Lê **todas** as conexões <c>CONEXAO</c> do ModelSpace, sem o filtro de ponta do
    /// <see cref="FiacaoDoDesenho"/>: aqui interessa a conexão em si (tipo, painel,
    /// potencial, nome), porque os geradores que varrem o desenho — `Circuitos4F`
    /// (`t6yXrlfi5w`) — enxergam a conexão mesmo quando ela não gera ponto de fiação.
    /// </summary>
    public static class ConexoesDoDesenho
    {
        public static IReadOnlyList<ConexaoFiacao> Ler()
        {
            List<ConexaoFiacao> conexoes = new List<ConexaoFiacao>();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return conexoes;
            }

            Database banco = documento.Database;

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
                BlockTableRecord espaco = (BlockTableRecord)transacao.GetObject(
                    tabela[BlockTableRecord.ModelSpace],
                    OpenMode.ForRead);

                foreach (ObjectId id in espaco)
                {
                    Entity entidade = transacao.GetObject(id, OpenMode.ForRead) as Entity;
                    if (entidade == null)
                    {
                        continue;
                    }

                    ResultBuffer xdata = entidade.GetXDataForApplication(ConexaoXData.AppName);
                    if (xdata == null)
                    {
                        continue;
                    }

                    ConexaoXData conexao;
                    if (!ConexaoXData.Ler(XDataNeutro.Para(xdata), out conexao))
                    {
                        continue;
                    }

                    conexoes.Add(new ConexaoFiacao
                    {
                        Tipo = conexao.Tipo,
                        Painel = conexao.Painel,
                        Potencial = conexao.Potencial,
                        Nome = conexao.Nome,
                        Secao = conexao.Secao,
                        Cor = conexao.Cor,
                        Handle = entidade.Handle.ToString(),
                        // `HandleSup` do verificador: "OK" fora do Tipo 3; no Tipo 3, o
                        // Handle do XData (a conexão com que esta se superpõe).
                        HandleSuperposto = conexao.Tipo == 3 ? conexao.Handle : "OK",
                        Pagina = entidade.Layer,
                        Jumper = conexao.Jumper,
                        Disp1 = conexao.Disp1,
                        Disp2 = conexao.Disp2,
                    });
                }

                transacao.Commit();
            }

            return conexoes;
        }
    }
}
