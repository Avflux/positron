using System;
using System.Collections.Generic;
using Positron.Data.Configuracao;
using Positron.Data.Fiacao;
using Positron.Data.Layout;
using Positron.Data.Paginas;
using Positron.Plugin.Bornes;
using Positron.Plugin.Configuracao;
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
    /// A **cadeia que o original roda depois de inserir o bloco do formato novo** — a segunda
    /// metade do <c>Caderno.CriaCaderno</c>, que a rodada 170 (a troca em si) deixou de fora:
    /// recarregar as páginas, apagar os campos antigos (<c>ApagarCamposPaginas</c>), recriar o campo
    /// <c>TOT</c> (<c>criaCamposTOT</c>) e os oito campos de cada página (<c>criaCamposFormato</c>),
    /// refazer as definições de revisão (<c>verificaCriaBlocoRevisao</c>) e apagar as que sobram do
    /// formato antigo, restaurar os **títulos** capturados antes da troca (<c>AtualizaTitulos</c>),
    /// recalcular o conteúdo de <c>CONT</c>/<c>FL</c>/<c>TOT</c>/<c>ALTERNATIVO</c>
    /// (<c>AtualizaContTotFl</c>) e regravar a **configuração** do desenho com o <c>maxCapa</c>/
    /// <c>maxCorpo</c> do formato novo (<c>GravarXDataConfiguracao</c>).
    ///
    /// O que a cadeia faz com cada campo é puro (<see cref="CamposDoFormato"/>); este adapter só fala
    /// com o CAD.
    ///
    /// **Fora, com o motivo:** o <c>TrocaColunas</c> (apaga e reinsere as entidades de coluna com o
    /// XData de cruzamento, que o adapter ainda não tem) e o <c>AtualizaRevSimplificada</c> (depende
    /// das revisões capturadas antes da troca, que o recoder reaplica pela via dos títulos — ver o
    /// <c>RevisoesDoDesenho</c>), além do <c>attsync</c> por referência e da página ativa/paleta do
    /// fim do <c>CriaCaderno</c>.
    /// </summary>
    internal static class RestauracaoDoFormatoDoDesenho
    {
        /// <summary>O layer do formato do corpo (o <c>-1</c>).</summary>
        private const string LayerDoCorpo = PaginaAtiva.LayerDoFormatoDoCorpo;

        internal sealed class Resultado
        {
            /// <summary>Campos de página apagados antes de recriar (o <c>ApagarCamposPaginas</c>).</summary>
            internal int CamposApagados { get; set; }

            /// <summary>Campos <c>TOT</c> criados (o <c>criaCamposTOT</c>).</summary>
            internal int CamposTot { get; set; }

            /// <summary>Páginas em que os campos foram recriados.</summary>
            internal int Paginas { get; set; }

            /// <summary>Campos de página criados no total (o <c>criaCamposFormato</c> de cada uma).</summary>
            internal int CamposCriados { get; set; }

            /// <summary>Definições <c>Revisao_Capa{n}</c>/<c>Revisao_Corpo{n}</c> refeitas.</summary>
            internal int Definicoes { get; set; }

            /// <summary>Definições de revisão além do formato apagadas.</summary>
            internal int DefinicoesApagadas { get; set; }

            /// <summary>Campos <c>CONT</c>/<c>FL</c>/<c>TOT</c>/<c>ALTERNATIVO</c> atualizados.</summary>
            internal int ContTotFl { get; set; }

            /// <summary>Títulos restaurados (o <c>AtualizaTitulos</c>).</summary>
            internal int Titulos { get; set; }

            /// <summary>O <c>maxCapa</c>/<c>maxCorpo</c> do formato novo.</summary>
            internal int MaxCapa { get; set; }

            internal int MaxCorpo { get; set; }

            /// <summary>A configuração do desenho foi regravada.</summary>
            internal bool ConfigGravada { get; set; }
        }

        /// <summary>
        /// Roda a cadeia. <paramref name="titulos"/> são os títulos capturados **antes** da troca,
        /// por página (a chave é o layer); só entram quando <paramref name="tinhaFormato"/> é
        /// verdadeiro (o <c>flag2 = ExisteFormato()</c> do original gateia a revisão e os títulos). O
        /// <c>Conf.incluirColuna</c> que o <c>AtualizaContTotFl</c> consulta sai da configuração do
        /// desenho. Nunca lança.
        /// </summary>
        internal static Resultado Executar(IReadOnlyDictionary<string, TitulosDaPagina> titulos, bool tinhaFormato)
        {
            Resultado resultado = new Resultado();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return resultado;
            }

            Database banco = documento.Database;
            List<PaginaDoCaderno> paginas = LerPaginas(banco);
            ConfiguracaoDoCaderno conf = ConfiguracaoDoDesenho.Ler();
            int incluirColuna = conf != null ? conf.IncluirColuna : 1;

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
                BlockTableRecord espaco = (BlockTableRecord)transacao.GetObject(
                    tabela[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                BornesDaCorrecao.GarantirAppName(transacao, banco, TituloDaPaginaXData.AppName);

                // 1) ApagarCamposPaginas: some com todo texto que tem o XData do título.
                resultado.CamposApagados = ApagarCampos(transacao, espaco);

                BlockReference formato = FormatoDoDesenho.Encontrar(transacao, espaco);
                if (formato == null)
                {
                    transacao.Commit();
                    return resultado;
                }

                string capa = LayerDaCapa(transacao, banco);

                // 2) criaCamposTOT: o campo TOT nasce no layer do atributo (capa ou -1).
                resultado.CamposTot = CriarCamposTot(transacao, banco, espaco, formato, capa);

                // 3) criaCamposFormato de cada página: o layer de referência é o da capa na capa e
                //    o -1 nas demais.
                foreach (PaginaDoCaderno pagina in paginas)
                {
                    string layerRef = PaginaAtiva.ChecaCapa(pagina.Nome) ? capa : LayerDoCorpo;
                    if (layerRef.Length == 0)
                    {
                        continue;
                    }

                    int criados = CriacaoDePaginaDoDesenho.CopiarCampos(
                        transacao, banco, espaco, formato, layerRef, pagina.Nome);
                    if (criados > 0)
                    {
                        resultado.Paginas++;
                        resultado.CamposCriados += criados;
                    }
                }

                transacao.Commit();
            }

            PosicoesDoFormato posicoes = new PosicoesDoFormato();

            // 4) Revisão e títulos: só quando o desenho **já tinha** formato (o `if (flag2)` do
            //    original). Na criação do formato não há revisão nem título a restaurar.
            if (tinhaFormato)
            {
                posicoes = RevisoesDoDesenho.CriarDefinicoesDoFormato(out int definicoes, out int apagadas);
                resultado.Definicoes = definicoes;
                resultado.DefinicoesApagadas = apagadas;
                resultado.MaxCapa = posicoes.Capa;
                resultado.MaxCorpo = posicoes.Corpo;

                // 5) AtualizaTitulos: devolve os títulos capturados antes da troca.
                if (titulos != null)
                {
                    foreach (KeyValuePair<string, TitulosDaPagina> par in titulos)
                    {
                        if (par.Value != null)
                        {
                            resultado.Titulos += TitulosDaPaginaDoDesenho.Gravar(par.Key, par.Value);
                        }
                    }
                }
            }

            // 6) AtualizaContTotFl: o conteúdo de CONT/FL/TOT/ALTERNATIVO.
            resultado.ContTotFl = AtualizarContTotFl(banco, paginas, incluirColuna);

            // 7) GravarXDataConfiguracao com o maxCapa/maxCorpo do formato novo.
            if (conf != null && (conf.MaxCapa != posicoes.Capa || conf.MaxCorpo != posicoes.Corpo))
            {
                conf.MaxCapa = posicoes.Capa;
                conf.MaxCorpo = posicoes.Corpo;
                resultado.ConfigGravada = ConfiguracaoDoDesenho.Gravar(conf);
            }

            return resultado;
        }

        /// <summary>O <c>ApagarCamposPaginas</c>: apaga todo <c>DBText</c> com o XData do título.</summary>
        private static int ApagarCampos(Transaction transacao, BlockTableRecord espaco)
        {
            List<ObjectId> alvos = new List<ObjectId>();
            foreach (ObjectId id in espaco)
            {
                DBText texto = transacao.GetObject(id, OpenMode.ForRead) as DBText;
                if (texto == null)
                {
                    continue;
                }

                int indice;
                string valor;
                if (IndiceDoTitulo(texto, out indice, out valor) && CamposDoFormato.EhCampoDePagina(indice))
                {
                    alvos.Add(id);
                }
            }

            int apagados = 0;
            foreach (ObjectId id in alvos)
            {
                Entity entidade = transacao.GetObject(id, OpenMode.ForWrite) as Entity;
                if (entidade != null)
                {
                    entidade.Erase();
                    apagados++;
                }
            }

            return apagados;
        }

        /// <summary>O <c>criaCamposTOT</c>: um campo TOT (índice 7, texto <c>"1"</c>) por atributo TOT protegido.</summary>
        private static int CriarCamposTot(
            Transaction transacao,
            Database banco,
            BlockTableRecord espaco,
            BlockReference formato,
            string capa)
        {
            int criados = 0;
            foreach (ObjectId id in formato.AttributeCollection)
            {
                AttributeReference atributo = transacao.GetObject(id, OpenMode.ForRead) as AttributeReference;
                if (atributo == null)
                {
                    continue;
                }

                if (!CamposDoFormato.GeraCampoTot(TrocaDeFormato.Protegida(atributo.Tag), atributo.Tag))
                {
                    continue;
                }

                bool noFormato = string.Equals(atributo.Layer, LayerDoCorpo, StringComparison.OrdinalIgnoreCase)
                    || (capa.Length > 0 && string.Equals(atributo.Layer, capa, StringComparison.OrdinalIgnoreCase));
                if (!noFormato)
                {
                    continue;
                }

                DBText texto = CriacaoDePaginaDoDesenho.Clonar(atributo, CamposDoFormato.TextoDoTot, atributo.Layer);
                espaco.AppendEntity(texto);
                transacao.AddNewlyCreatedDBObject(texto, true);
                texto.XData = BornesDaCorrecao.ParaResultBuffer(TituloDaPaginaXData.ParaValores(
                    CamposDoFormato.IndiceTot, CamposDoFormato.TextoDoTot, Environment.UserName, DateTime.Now.ToString()));
                criados++;
            }

            return criados;
        }

        /// <summary>
        /// O <c>AtualizaContTotFl</c> do reverso: relê as páginas do caderno e atualiza os campos
        /// CONT, FL, TOT e ALTERNATIVO em todas as páginas do desenho.
        /// </summary>
        internal static int AtualizarContTotFl(Database banco)
        {
            if (banco == null)
            {
                return 0;
            }

            int incluirColuna = 1;
            try
            {
                incluirColuna = ConfiguracaoEfetiva.Carregar().IncluirColuna;
            }
            catch (Exception)
            {
                incluirColuna = 1;
            }

            List<PaginaDoCaderno> paginas = LerPaginas(banco);
            return AtualizarContTotFl(banco, paginas, incluirColuna);
        }

        /// <summary>
        /// O <c>AtualizaContTotFl</c>: percorre os textos com o XData do título e ajusta os índices
        /// 5/6/7/9 (<see cref="CamposDoFormato.TextoDoContTotFl"/>). O <c>REV</c> e os títulos ficam.
        /// </summary>
        internal static int AtualizarContTotFl(
            Database banco,
            IReadOnlyList<PaginaDoCaderno> paginas,
            int incluirColuna)
        {
            string ultima = paginas.Count > 0 ? paginas[paginas.Count - 1].Nome : string.Empty;
            int atualizados = 0;

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco, OpenMode.ForWrite);
                foreach (ObjectId id in espaco)
                {
                    DBText texto = transacao.GetObject(id, OpenMode.ForRead) as DBText;
                    if (texto == null)
                    {
                        continue;
                    }

                    int indice;
                    string valor;
                    if (!IndiceDoTitulo(texto, out indice, out valor))
                    {
                        continue;
                    }

                    string novo = CamposDoFormato.TextoDoContTotFl(indice, texto.Layer, ultima, paginas, incluirColuna);
                    if (novo == null)
                    {
                        continue;
                    }

                    texto.UpgradeOpen();
                    texto.TextString = novo;
                    atualizados++;
                }

                transacao.Commit();
            }

            return atualizados;
        }

        /// <summary>As páginas do desenho (LayerTable + XData de unidade/alternativo), na ordem das páginas.</summary>
        internal static List<PaginaDoCaderno> LerPaginas(Database banco)
        {
            List<PaginaDoCaderno> paginas = new List<PaginaDoCaderno>();
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                LayerTable camadas = transacao.GetObject(banco.LayerTableId, OpenMode.ForRead) as LayerTable;
                if (camadas != null)
                {
                    foreach (ObjectId id in camadas)
                    {
                        LayerTableRecord layer = transacao.GetObject(id, OpenMode.ForRead) as LayerTableRecord;
                        if (layer == null || !PaginasDoCaderno.LayerValido(layer.Name))
                        {
                            continue;
                        }

                        string unidade;
                        string alternativo;
                        Alternativo(layer, out unidade, out alternativo);
                        paginas.Add(new PaginaDoCaderno { Nome = layer.Name, Alternativo = alternativo });
                    }
                }

                transacao.Commit();
            }

            paginas.Sort(delegate (PaginaDoCaderno a, PaginaDoCaderno b)
            {
                return PaginaNumerada.Decimal(a.Nome).CompareTo(PaginaNumerada.Decimal(b.Nome));
            });
            return paginas;
        }

        /// <summary>O alternativo do layer (o XData <c>Eletron</c>/<c>UNIDADE</c>).</summary>
        private static void Alternativo(LayerTableRecord layer, out string unidade, out string alternativo)
        {
            unidade = string.Empty;
            alternativo = string.Empty;
            ResultBuffer xdata = layer.GetXDataForApplication("Eletron");
            if (xdata == null)
            {
                return;
            }

            string lidoUnidade;
            string lidoAlternativo;
            if (UnidadeDaPaginaXData.Ler(XDataNeutro.Para(xdata), out lidoUnidade, out lidoAlternativo))
            {
                unidade = lidoUnidade;
                alternativo = lidoAlternativo;
            }
        }

        /// <summary>O layer da capa — o primeiro da tabela que o <c>checaCapa</c> aceita.</summary>
        private static string LayerDaCapa(Transaction transacao, Database banco)
        {
            LayerTable camadas = transacao.GetObject(banco.LayerTableId, OpenMode.ForRead) as LayerTable;
            if (camadas == null)
            {
                return string.Empty;
            }

            foreach (ObjectId id in camadas)
            {
                LayerTableRecord layer = transacao.GetObject(id, OpenMode.ForRead) as LayerTableRecord;
                if (layer != null && PaginaAtiva.ChecaCapa(layer.Name))
                {
                    return layer.Name;
                }
            }

            return string.Empty;
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
