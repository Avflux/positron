using System;
using System.Collections.Generic;
using Positron.Data.Fiacao;
using Positron.Data.Paginas;
using Positron.Plugin.Bornes;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Paginas
{
    /// <summary>
    /// As **colunas do formato** no desenho: o <c>Inserir</c> da paleta das folhas (o
    /// <c>Pagina.InserirColuna</c>, `Pagina.cs:2415`) e a leitura que monta os cinco sub-itens (o
    /// <c>Pagina.verificaLayerExtraNoFormato</c>, `Pagina.cs:2315`).
    ///
    /// A regra é pura (<see cref="ColunasDoFormato"/>); aqui ficam só a tabela de layers (de onde
    /// saem o rótulo e a visibilidade) e a clonagem da **definição do bloco de formato** para o
    /// ModelSpace, que é o que o original faz com o <c>LockDocument</c> dele.
    /// </summary>
    internal static class ColunasDoDesenho
    {
        /// <summary>
        /// As cinco colunas, com o rótulo e a visibilidade da **tabela de layers** do desenho. Sem o
        /// bloco de formato a leitura devolve as cinco invisíveis — o original nem varre a tabela
        /// nesse caso (`Pagina.cs:2338`).
        /// </summary>
        internal static IReadOnlyList<ColunaDoFormato> Ler()
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return ColunasDoFormato.DosLayers(null);
            }

            List<string> nomes = new List<string>();
            using (Transaction transacao = documento.Database.TransactionManager.StartTransaction())
            {
                BlockTable tabela = transacao.GetObject(documento.Database.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord espaco = tabela == null
                    ? null
                    : transacao.GetObject(tabela[BlockTableRecord.ModelSpace], OpenMode.ForRead) as BlockTableRecord;
                if (FormatoDoDesenho.Encontrar(transacao, espaco) == null)
                {
                    transacao.Commit();
                    return ColunasDoFormato.DosLayers(null);
                }

                LayerTable camadas = (LayerTable)transacao.GetObject(documento.Database.LayerTableId, OpenMode.ForRead);
                foreach (ObjectId id in camadas)
                {
                    LayerTableRecord layer = transacao.GetObject(id, OpenMode.ForRead) as LayerTableRecord;
                    if (layer != null)
                    {
                        nomes.Add(layer.Name);
                    }
                }

                transacao.Commit();
            }

            return ColunasDoFormato.DosLayers(nomes);
        }

        /// <summary>
        /// O <c>Pagina.InserirColuna(sPag, sTipo)</c>: clona para o layer da página toda entidade da
        /// **definição do bloco de formato** cujo layer é o da coluna, com o XData
        /// <c>DiagLog</c>/<c>COLUNAS</c>. Devolve quantas entidades nasceram (o original não devolve
        /// nada nem avisa quando não acha a coluna).
        /// </summary>
        internal static int Inserir(string pagina, string tipo)
        {
            string alvo = (pagina ?? string.Empty).Trim();
            if (alvo.Length == 0 || string.IsNullOrEmpty(tipo))
            {
                return 0;
            }

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return 0;
            }

            Database banco = documento.Database;
            int criadas = 0;
            using (documento.LockDocument())
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTable tabela = transacao.GetObject(banco.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord espaco = tabela == null
                    ? null
                    : transacao.GetObject(tabela[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                BlockReference formato = FormatoDoDesenho.Encontrar(transacao, espaco);
                if (formato != null && espaco != null && !string.IsNullOrEmpty(formato.Name) && tabela.Has(formato.Name))
                {
                    BlockTableRecord definicao = transacao.GetObject(tabela[formato.Name], OpenMode.ForRead) as BlockTableRecord;
                    if (definicao != null)
                    {
                        BornesDaCorrecao.GarantirAppName(transacao, banco, ColunaDaPaginaXData.AppName);
                        criadas = InserirColuna(transacao, espaco, definicao, banco, alvo, tipo);
                    }
                }

                transacao.Commit();
            }

            return criadas;
        }

        /// <summary>
        /// O corpo do <c>InserirColuna</c> dentro de uma transação que já existe: é o mesmo passo que o
        /// <c>TrocaColunasDoDesenho</c> usa para reinstanciar cada par (página, tipo).
        /// </summary>
        internal static int InserirColuna(
            Transaction transacao,
            BlockTableRecord espaco,
            BlockTableRecord definicao,
            Database banco,
            string pagina,
            string tipo)
        {
            if (transacao == null || espaco == null || definicao == null)
            {
                return 0;
            }

            int criadas = 0;
            foreach (ObjectId id in definicao)
            {
                Entity modelo = transacao.GetObject(id, OpenMode.ForRead) as Entity;
                if (modelo == null || !string.Equals(modelo.Layer, tipo, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                Entity clone = modelo.Clone() as Entity;
                if (clone == null)
                {
                    continue;
                }

                clone.Layer = pagina;
                espaco.AppendEntity(clone);
                transacao.AddNewlyCreatedDBObject(clone, true);

                IReadOnlyList<TypedXData> valores = ColunaDaPaginaXData.ParaValores(
                    tipo,
                    Environment.UserName,
                    DateTime.Now.ToString());
                clone.XData = BornesDaCorrecao.ParaResultBuffer(valores);
                criadas++;
            }

            return criadas;
        }
    }
}
