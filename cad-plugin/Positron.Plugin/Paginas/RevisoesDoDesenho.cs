using System;
using System.Collections.Generic;
using Positron.Data;
using Positron.Data.Paginas;
using Positron.Plugin.Bornes;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
#endif

namespace Positron.Plugin.Paginas
{
    /// <summary>
    /// Leitor e gravador das revisões das páginas no desenho CAD:
    /// - <see cref="LerSimplificadas"/> e <see cref="GravarSimplificadas"/>:
    ///   opera sobre os <see cref="DBText"/> de cada página com o XData <c>DiagLog</c>/<c>TituloPagina</c>
    ///   de índice 8 (a tag "REV" do formato, o mesmo do original <c>Revisao.capturaRevisoesSimplificadas</c>).
    /// - <see cref="LerCompletas"/> e <see cref="GravarCompletas"/>:
    ///   opera sobre os blocos de revisão no desenho com XData <c>DiagLog</c>/<c>Revisao</c>
    ///   (o mesmo do original <c>Revisao.capturaRevisoesCompletas</c>).
    /// </summary>
    internal static class RevisoesDoDesenho
    {
        /// <summary>
        /// Lê as revisões simplificadas de todas as páginas do caderno.
        /// </summary>
        internal static List<RevisaoSimplificadaDaPagina> LerSimplificadas()
        {
            List<string> paginas = PaginasDoDesenho.Ler();
            List<RevisaoSimplificadaDaPagina> resultado = new List<RevisaoSimplificadaDaPagina>(paginas.Count);

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                foreach (string pagina in paginas)
                {
                    resultado.Add(new RevisaoSimplificadaDaPagina(pagina, string.Empty));
                }
                return resultado;
            }

            Database banco = documento.Database;
            Dictionary<string, string> revisaoPorPagina = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco, OpenMode.ForRead);
                foreach (ObjectId id in espaco)
                {
                    DBText texto = transacao.GetObject(id, OpenMode.ForRead) as DBText;
                    if (texto == null || string.IsNullOrEmpty(texto.Layer))
                    {
                        continue;
                    }

                    // Como o original, o último campo REV lido na página é o que fica.
                    int indice;
                    string valor;
                    if (IndiceDoTitulo(texto, out indice, out valor) && indice == 8)
                    {
                        revisaoPorPagina[texto.Layer] = texto.TextString ?? valor ?? string.Empty;
                    }
                }

                transacao.Commit();
            }

            // Sem campo REV a revisão fica vazia, como no original (não há fallback para o projeto).
            foreach (string pagina in paginas)
            {
                string rev;
                if (!revisaoPorPagina.TryGetValue(pagina, out rev))
                {
                    rev = string.Empty;
                }
                resultado.Add(new RevisaoSimplificadaDaPagina(pagina, rev));
            }

            return resultado;
        }

        /// <summary>
        /// Regrava as revisões simplificadas nos textos das páginas do desenho.
        /// Devolve quantos textos foram atualizados.
        /// </summary>
        internal static int GravarSimplificadas(IReadOnlyList<RevisaoSimplificadaDaPagina> revisoes)
        {
            if (revisoes == null || revisoes.Count == 0)
            {
                return 0;
            }

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return 0;
            }

            Dictionary<string, string> mapa = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (RevisaoSimplificadaDaPagina item in revisoes)
            {
                if (item != null && !string.IsNullOrEmpty(item.Pagina))
                {
                    mapa[item.Pagina] = item.Revisao ?? string.Empty;
                }
            }

            int gravados = 0;
            Database banco = documento.Database;

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco, OpenMode.ForWrite);
                BornesDaCorrecao.GarantirAppName(transacao, banco, TituloDaPaginaXData.AppName);

                foreach (ObjectId id in espaco)
                {
                    DBText texto = transacao.GetObject(id, OpenMode.ForRead) as DBText;
                    if (texto == null || string.IsNullOrEmpty(texto.Layer))
                    {
                        continue;
                    }

                    string novaRevisao;
                    if (!mapa.TryGetValue(texto.Layer, out novaRevisao))
                    {
                        continue;
                    }

                    int indice;
                    string valor;
                    if (!IndiceDoTitulo(texto, out indice, out valor) || indice != 8)
                    {
                        continue;
                    }

                    texto.UpgradeOpen();
                    texto.TextString = novaRevisao;
                    texto.XData = BornesDaCorrecao.ParaResultBuffer(TituloDaPaginaXData.ParaValores(
                        8, novaRevisao, Environment.UserName, DateTime.Now.ToString()));
                    gravados++;
                }

                transacao.Commit();
            }

            return gravados;
        }

        /// <summary>
        /// Lê as revisões completas de todas as páginas do caderno.
        /// </summary>
        internal static List<RevisaoCompletaDaPagina> LerCompletas()
        {
            List<string> paginas = PaginasDoDesenho.Ler();
            List<RevisaoCompletaDaPagina> resultado = new List<RevisaoCompletaDaPagina>(paginas.Count);

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                foreach (string pagina in paginas)
                {
                    resultado.Add(new RevisaoCompletaDaPagina(pagina, string.Empty, string.Empty, string.Empty,
                        string.Empty, string.Empty, string.Empty));
                }
                return resultado;
            }

            Database banco = documento.Database;
            Dictionary<string, RevisaoCompletaDaPagina> revPorPagina = new Dictionary<string, RevisaoCompletaDaPagina>(StringComparer.OrdinalIgnoreCase);

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco, OpenMode.ForRead);
                foreach (ObjectId id in espaco)
                {
                    BlockReference bloco = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
                    if (bloco == null || string.IsNullOrEmpty(bloco.Layer))
                    {
                        continue;
                    }

                    ResultBuffer xdata = bloco.GetXDataForApplication(RevisaoCompletaXData.AppName);
                    if (xdata == null)
                    {
                        continue;
                    }

                    RevisaoCompletaDaPagina rev;
                    if (!RevisaoCompletaXData.Ler(XDataNeutro.Para(xdata), out rev))
                    {
                        continue;
                    }

                    rev.Pagina = bloco.Layer;

                    // Como o capturaRevisoesCompletas: a posição nova tem de ser maior que a guardada (0 no início).
                    RevisaoCompletaDaPagina existente;
                    int posicaoGuardada = revPorPagina.TryGetValue(bloco.Layer, out existente) ? existente.Posicao : 0;
                    if (OperacoesDeRevisao.AceitaRevisaoCompleta(posicaoGuardada, rev.Posicao))
                    {
                        revPorPagina[bloco.Layer] = rev;
                    }
                }

                transacao.Commit();
            }

            foreach (string pagina in paginas)
            {
                RevisaoCompletaDaPagina rev;
                if (!revPorPagina.TryGetValue(pagina, out rev))
                {
                    rev = new RevisaoCompletaDaPagina(pagina, string.Empty, string.Empty, string.Empty,
                        string.Empty, string.Empty, string.Empty);
                }
                resultado.Add(rev);
            }

            return resultado;
        }

        /// <summary>
        /// Regrava as revisões completas nos blocos de revisão do desenho, como o
        /// <c>AtualizaRevCompleta</c> do original: monta o **posicionamento** de cada página
        /// (<see cref="PosicionamentoDeRevisoes.Calcular"/>) sobre os blocos que já existem, apaga,
        /// desloca e cria os blocos, e devolve o que foi feito.
        /// </summary>
        internal static ResultadoDaGravacaoDeRevisoes GravarCompletas(IReadOnlyList<RevisaoCompletaDaPagina> revisoes)
        {
            ResultadoDaGravacaoDeRevisoes resultado = new ResultadoDaGravacaoDeRevisoes();
            if (revisoes == null || revisoes.Count == 0)
            {
                return resultado;
            }

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return resultado;
            }

            Database banco = documento.Database;

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
                BlockTableRecord espaco = (BlockTableRecord)transacao.GetObject(
                    tabela[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                BornesDaCorrecao.GarantirAppName(transacao, banco, RevisaoCompletaXData.AppName);

                // 1) lê todos os blocos de revisão do desenho, agrupados por página.
                Dictionary<string, List<BlocoDeRevisao>> porPagina =
                    new Dictionary<string, List<BlocoDeRevisao>>(StringComparer.OrdinalIgnoreCase);
                foreach (ObjectId id in espaco)
                {
                    BlockReference bloco = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
                    if (bloco == null || string.IsNullOrEmpty(bloco.Layer))
                    {
                        continue;
                    }

                    ResultBuffer xdata = bloco.GetXDataForApplication(RevisaoCompletaXData.AppName);
                    if (xdata == null)
                    {
                        continue;
                    }

                    RevisaoCompletaDaPagina rev;
                    if (!RevisaoCompletaXData.Ler(XDataNeutro.Para(xdata), out rev))
                    {
                        continue;
                    }

                    rev.Pagina = bloco.Layer;
                    List<BlocoDeRevisao> lista;
                    if (!porPagina.TryGetValue(bloco.Layer, out lista))
                    {
                        lista = new List<BlocoDeRevisao>();
                        porPagina[bloco.Layer] = lista;
                    }

                    lista.Add(new BlocoDeRevisao(id, rev));
                }

                // 2) as posições do formato (o maxCapa/maxCorpo do carregaConfiguracaoRevisao), medidas
                // pelos blocos Revisao_Capa{n}/Revisao_Corpo{n} que o verificaCriaBlocoRevisao deixou.
                int maxCapa = ContarDefinicoes(transacao, tabela, "Revisao_Capa");
                int maxCorpo = ContarDefinicoes(transacao, tabela, "Revisao_Corpo");

                // 3) aplica o plano de cada página editada.
                foreach (RevisaoCompletaDaPagina recebida in revisoes)
                {
                    if (recebida == null || string.IsNullOrEmpty(recebida.Pagina))
                    {
                        continue;
                    }

                    List<BlocoDeRevisao> existentes;
                    if (!porPagina.TryGetValue(recebida.Pagina, out existentes))
                    {
                        existentes = new List<BlocoDeRevisao>();
                    }

                    BlocoDeRevisao atual = BlocoDeMaiorPosicao(existentes);
                    RevisaoCompletaDaPagina nova = Copiar(recebida);
                    nova.Posicao = atual != null ? atual.Revisao.Posicao : 0;
                    nova.RevisaoOriginal = atual != null ? atual.Revisao.Revisao : string.Empty;

                    bool capa = PaginaAtiva.ChecaCapa(recebida.Pagina);
                    int posicoes = capa ? maxCapa : maxCorpo;
                    if (posicoes == 0)
                    {
                        // Sem os blocos de formato: não há como saber quantas posições cabem. O recoder
                        // não apaga nada por isso — a página aceita pelo menos uma posição a mais.
                        posicoes = MaiorPosicao(existentes) + 1;
                        resultado.SemFormato++;
                    }

                    PlanoDaRevisaoCompleta plano = PosicionamentoDeRevisoes.Calcular(
                        nova,
                        Revisoes(existentes),
                        posicoes);

                    if (plano.Vazio)
                    {
                        continue;
                    }

                    resultado.Paginas++;
                    if (plano.Estourou)
                    {
                        resultado.Estourou = true;
                    }

                    foreach (OperacaoDaRevisao operacao in plano.Operacoes)
                    {
                        switch (operacao.Tipo)
                        {
                            case TipoDaOperacaoDaRevisao.Atualizar:
                                if (AtualizarBloco(transacao, existentes, operacao.Dados))
                                {
                                    resultado.Atualizados++;
                                }
                                break;

                            case TipoDaOperacaoDaRevisao.Apagar:
                                if (ApagarBloco(transacao, existentes, operacao.Posicao))
                                {
                                    resultado.Apagados++;
                                }
                                break;

                            case TipoDaOperacaoDaRevisao.Criar:
                                if (CriarBloco(transacao, tabela, espaco, recebida.Pagina, operacao.Dados))
                                {
                                    resultado.Criados++;
                                    if (plano.Estourou)
                                    {
                                        resultado.Deslocados++;
                                    }
                                }
                                else
                                {
                                    resultado.SemDefinicao++;
                                }
                                break;
                        }
                    }
                }

                transacao.Commit();
            }

            return resultado;
        }

        /// <summary>Atualiza o XData e os atributos do bloco que já está na posição (o ramo "sem alteração").</summary>
        private static bool AtualizarBloco(
            Transaction transacao,
            List<BlocoDeRevisao> existentes,
            RevisaoCompletaDaPagina nova)
        {
            BlocoDeRevisao alvo = BlocoNaPosicao(existentes, nova.Posicao);
            if (alvo == null)
            {
                return false;
            }

            BlockReference bloco = transacao.GetObject(alvo.Id, OpenMode.ForRead) as BlockReference;
            if (bloco == null)
            {
                return false;
            }

            bloco.UpgradeOpen();
            bloco.XData = BornesDaCorrecao.ParaResultBuffer(RevisaoCompletaXData.ParaValores(
                nova, Environment.UserName, DateTime.Now.ToString()));
            AtualizarAtributos(transacao, bloco, nova);
            return true;
        }

        /// <summary>Apaga o bloco da posição (o <c>LK3p1o8pTVH</c>).</summary>
        private static bool ApagarBloco(Transaction transacao, List<BlocoDeRevisao> existentes, int posicao)
        {
            BlocoDeRevisao alvo = BlocoNaPosicao(existentes, posicao);
            if (alvo == null)
            {
                return false;
            }

            BlockReference bloco = transacao.GetObject(alvo.Id, OpenMode.ForRead) as BlockReference;
            if (bloco == null)
            {
                return false;
            }

            bloco.UpgradeOpen();
            bloco.Erase();
            return true;
        }

        /// <summary>
        /// Cria o bloco da revisão na posição: o <c>JdCp1GqFmnk</c> — a definição é
        /// <c>Revisao_Capa{Posicao-1}</c> (capa) ou <c>Revisao_Corpo{Posicao-1}</c>, no layer da página,
        /// com um atributo por definição do bloco e o XData <c>DiagLog/Revisao</c>.
        /// Devolve <c>false</c> quando a definição do bloco não existe no desenho.
        /// </summary>
        private static bool CriarBloco(
            Transaction transacao,
            BlockTable tabela,
            BlockTableRecord espaco,
            string pagina,
            RevisaoCompletaDaPagina dados)
        {
            string nome = (PaginaAtiva.ChecaCapa(pagina) ? "Revisao_Capa" : "Revisao_Corpo") + (dados.Posicao - 1);
            if (!tabela.Has(nome))
            {
                return false;
            }

            BlockTableRecord definicao = transacao.GetObject(tabela[nome], OpenMode.ForRead) as BlockTableRecord;
            if (definicao == null)
            {
                return false;
            }

            BlockReference bloco = new BlockReference(Point3d.Origin, definicao.ObjectId);
            bloco.Layer = pagina;
            espaco.AppendEntity(bloco);
            transacao.AddNewlyCreatedDBObject(bloco, true);

            foreach (ObjectId idDef in definicao)
            {
                AttributeDefinition atributoDef = transacao.GetObject(idDef, OpenMode.ForRead) as AttributeDefinition;
                if (atributoDef == null)
                {
                    continue;
                }

                AttributeReference atributo = new AttributeReference();
                atributo.SetAttributeFromBlock(atributoDef, bloco.BlockTransform);
                AplicarValor(atributo, dados);
                bloco.AttributeCollection.AppendAttribute(atributo);
                transacao.AddNewlyCreatedDBObject(atributo, true);
            }

            bloco.XData = BornesDaCorrecao.ParaResultBuffer(RevisaoCompletaXData.ParaValores(
                dados, Environment.UserName, DateTime.Now.ToString()));
            return true;
        }

        /// <summary>O laço do <c>JdCp1GqFmnk</c>: cada atributo do bloco pela sua tag (<c>REV0..7</c> etc.).</summary>
        private static void AtualizarAtributos(Transaction transacao, BlockReference bloco, RevisaoCompletaDaPagina nova)
        {
            foreach (ObjectId idAtributo in bloco.AttributeCollection)
            {
                AttributeReference atributo = transacao.GetObject(idAtributo, OpenMode.ForWrite) as AttributeReference;
                if (atributo == null || string.IsNullOrEmpty(atributo.Tag))
                {
                    continue;
                }

                AplicarValor(atributo, nova);
            }
        }

        /// <summary>
        /// Escreve no atributo o campo da sua tag; tag que não é um campo de revisão (o título do
        /// formato, por exemplo) fica com o valor que veio da definição — como no original, que só
        /// troca o <c>TextString</c> das tags conhecidas.
        /// </summary>
        private static void AplicarValor(AttributeReference atributo, RevisaoCompletaDaPagina dados)
        {
            string campo = RevisaoCompletaXData.CampoDoAtributo(atributo.Tag);
            if (campo == null)
            {
                return;
            }

            switch (campo)
            {
                case "Revisao":
                    atributo.TextString = dados.Revisao ?? string.Empty;
                    break;
                case "Descricao":
                    atributo.TextString = dados.Descricao ?? string.Empty;
                    break;
                case "Data":
                    atributo.TextString = dados.Data ?? string.Empty;
                    break;
                case "Elaborador":
                    atributo.TextString = dados.Elaborador ?? string.Empty;
                    break;
                case "Verificador":
                    atributo.TextString = dados.Verificador ?? string.Empty;
                    break;
                case "Aprovador":
                    atributo.TextString = dados.Aprovador ?? string.Empty;
                    break;
            }
        }

        private static List<RevisaoCompletaDaPagina> Revisoes(List<BlocoDeRevisao> existentes)
        {
            List<RevisaoCompletaDaPagina> revisoes = new List<RevisaoCompletaDaPagina>(existentes.Count);
            foreach (BlocoDeRevisao bloco in existentes)
            {
                revisoes.Add(bloco.Revisao);
            }

            return revisoes;
        }

        private static BlocoDeRevisao BlocoNaPosicao(List<BlocoDeRevisao> existentes, int posicao)
        {
            foreach (BlocoDeRevisao bloco in existentes)
            {
                if (bloco.Revisao.Posicao == posicao)
                {
                    return bloco;
                }
            }

            return null;
        }

        private static BlocoDeRevisao BlocoDeMaiorPosicao(List<BlocoDeRevisao> existentes)
        {
            BlocoDeRevisao maior = null;
            foreach (BlocoDeRevisao bloco in existentes)
            {
                if (maior == null || bloco.Revisao.Posicao > maior.Revisao.Posicao)
                {
                    maior = bloco;
                }
            }

            return maior;
        }

        private static int MaiorPosicao(List<BlocoDeRevisao> existentes)
        {
            BlocoDeRevisao maior = BlocoDeMaiorPosicao(existentes);
            return maior == null ? 0 : maior.Revisao.Posicao;
        }

        private static int ContarDefinicoes(Transaction transacao, BlockTable tabela, string prefixo)
        {
            int total = 0;
            foreach (ObjectId id in tabela)
            {
                BlockTableRecord definicao = transacao.GetObject(id, OpenMode.ForRead) as BlockTableRecord;
                if (definicao == null || string.IsNullOrEmpty(definicao.Name))
                {
                    continue;
                }

                if (definicao.Name.StartsWith(prefixo, StringComparison.OrdinalIgnoreCase))
                {
                    total++;
                }
            }

            return total;
        }

        private static RevisaoCompletaDaPagina Copiar(RevisaoCompletaDaPagina origem)
        {
            return new RevisaoCompletaDaPagina(
                origem.Pagina,
                origem.Revisao,
                origem.Descricao,
                origem.Data,
                origem.Elaborador,
                origem.Verificador,
                origem.Aprovador,
                origem.Posicao)
            {
                RevisaoOriginal = origem.RevisaoOriginal,
            };
        }

        /// <summary>Um bloco de revisão já no desenho: a entidade e o XData lido.</summary>
        private sealed class BlocoDeRevisao
        {
            internal BlocoDeRevisao(ObjectId id, RevisaoCompletaDaPagina revisao)
            {
                Id = id;
                Revisao = revisao;
            }

            internal ObjectId Id { get; private set; }

            internal RevisaoCompletaDaPagina Revisao { get; private set; }
        }

        /// <summary>O que a gravação fez — para o comando relatar (não há clique para ver a tela).</summary>
        internal sealed class ResultadoDaGravacaoDeRevisoes
        {
            internal int Paginas { get; set; }

            internal int Atualizados { get; set; }

            internal int Criados { get; set; }

            internal int Apagados { get; set; }

            internal int Deslocados { get; set; }

            internal int SemDefinicao { get; set; }

            internal int SemFormato { get; set; }

            internal bool Estourou { get; set; }
        }

        private static bool IndiceDoTitulo(DBText texto, out int indice, out string valor)
        {
            indice = 0;
            valor = null;
            ResultBuffer xdata = texto.GetXDataForApplication(TituloDaPaginaXData.AppName);
            return xdata != null && TituloDaPaginaXData.Ler(XDataNeutro.Para(xdata), out indice, out valor);
        }

        private static BlockTableRecord EspacoDeModelo(Transaction transacao, Database banco, OpenMode modo)
        {
            BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
            return (BlockTableRecord)transacao.GetObject(tabela[BlockTableRecord.ModelSpace], modo);
        }
    }
}
