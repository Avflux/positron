using System;
using System.Collections.Generic;
using Positron.Data.Limpeza;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Limpeza
{
    /// <summary>
    /// O I/O da tela <c>frmPesquisaXdatas</c> (o comando <c>APAGARXDATA</c>): lê os app names de
    /// XData do **ModelSpace** e apaga os escolhidos.
    ///
    /// A leitura do nome é a do <c>LeTodosOsXdatasDoCaderno</c> do original — o **último
    /// registro `1001`** do buffer, em maiúsculas — e a gravação é a do
    /// <c>ApagaxDatasSelecionados</c>: o XData da entidade é trocado por um **registro único**
    /// com o próprio app name (`LimpezaDoDesenho.MarcaUnica`), o mesmo quirk que o
    /// <c>apagaXDataTerceiros</c> já reproduz — some o conteúdo, fica a marca.
    ///
    /// A regra (a lista do produto e a contagem) é pura: <see cref="XDatasDoDesenho"/>.
    /// </summary>
    internal static class XDatasDoCad
    {
        /// <summary>
        /// O app name de cada entidade do ModelSpace que tem XData, na ordem da varredura.
        /// A posição na lista é a da entidade; entidade sem nome legível entra como vazio.
        /// </summary>
        internal static IReadOnlyList<string> LerNomePorEntidade()
        {
            List<string> nomes = new List<string>();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return nomes;
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco);
                foreach (ObjectId id in espaco)
                {
                    Entity entidade = transacao.GetObject(id, OpenMode.ForRead) as Entity;
                    if (entidade == null)
                    {
                        continue;
                    }

                    string nome = LerAppName(entidade);
                    if (nome != null)
                    {
                        nomes.Add(nome);
                    }
                }

                transacao.Commit();
            }

            return nomes;
        }

        /// <summary>
        /// Apaga o XData dos app names pedidos e devolve quantas vezes a marca foi trocada (o
        /// `num` do `ApagaxDatasSelecionados`: conta por entidade **e** por app name).
        /// </summary>
        internal static int Apagar(IReadOnlyList<string> nomes)
        {
            if (nomes == null || nomes.Count == 0)
            {
                return 0;
            }

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return 0;
            }

            int apagados = 0;
            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco);
                foreach (ObjectId id in espaco)
                {
                    Entity entidade = transacao.GetObject(id, OpenMode.ForRead) as Entity;
                    if (entidade == null)
                    {
                        continue;
                    }

                    foreach (string nome in nomes)
                    {
                        if (string.IsNullOrEmpty(nome) || entidade.GetXDataForApplication(nome) == null)
                        {
                            continue;
                        }

                        entidade.UpgradeOpen();
                        entidade.XData = MarcaDe(nome);
                        apagados++;
                    }
                }

                transacao.Commit();
            }

            return apagados;
        }

        /// <summary>O último registro `1001` do XData da entidade (o nome do app), ou <c>null</c>.</summary>
        private static string LerAppName(Entity entidade)
        {
            ResultBuffer xdata;
            try
            {
                xdata = entidade.XData;
            }
            catch (Exception)
            {
                // entidade que nao expoe o XData: fora da conta, como no original
                return null;
            }

            if (xdata == null)
            {
                return null;
            }

            string nome = null;
            foreach (TypedValue valor in xdata.AsArray())
            {
                if (valor.TypeCode == 1001)
                {
                    nome = valor.Value as string;
                }
            }

            return nome;
        }

        private static ResultBuffer MarcaDe(string nome)
        {
            IReadOnlyList<Positron.Data.Fiacao.TypedXData> valores = LimpezaDoDesenho.MarcaUnica(nome);
            TypedValue[] array = new TypedValue[valores.Count];
            for (int i = 0; i < valores.Count; i++)
            {
                array[i] = new TypedValue(valores[i].Codigo, valores[i].Valor);
            }

            return new ResultBuffer(array);
        }

        private static BlockTableRecord EspacoDeModelo(Transaction transacao, Database banco)
        {
            BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
            return (BlockTableRecord)transacao.GetObject(tabela[BlockTableRecord.ModelSpace], OpenMode.ForRead);
        }
    }
}
