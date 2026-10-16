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
    /// formato antigo com sincronização estrutural de atributos (<c>attsync</c>), restaurar os **títulos**
    /// capturados antes da troca (<c>AtualizaTitulos</c>), restaurar as **revisões simplificadas**
    /// (<c>AtualizaRevSimplificada</c>), restabelecer as **colunas de cruzamento** (<c>TrocaColunas</c>),
    /// recalcular o conteúdo de <c>CONT</c>/<c>FL</c>/<c>TOT</c>/<c>ALTERNATIVO</c>
    /// (<c>AtualizaContTotFl</c>), regravar a **configuração** do desenho com o <c>maxCapa</c>/
    /// <c>maxCorpo</c> do formato novo (<c>GravarXDataConfiguracao</c>) e ativar a capa
    /// (<c>DeclaracoesGeral.ativo.Pagina = retornaNumeroCapa()</c>).
    ///
    /// O que a cadeia faz com cada campo é puro (<see cref="CamposDoFormato"/>); este adapter só fala
    /// com o CAD.
    ///
    /// **Fora, com o motivo:** apenas a chamada de interface interativa do final do fluxo
    /// (<c>Comandos.GerenciadorPagina()</c>, que abre/focaliza a paleta de páginas para o operador).
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

            /// <summary>Revisões simplificadas restauradas (o <c>AtualizaRevSimplificada</c>).</summary>
            internal int RevSimplificadas { get; set; }

            /// <summary>Entidades de coluna antigas apagadas do ModelSpace (<c>TrocaColunas</c>).</summary>
            internal int ColunasApagadas { get; set; }

            /// <summary>Entidades de coluna clonadas e inseridas do novo formato (<c>TrocaColunas</c>).</summary>
            internal int ColunasCriadas { get; set; }

            /// <summary>Referências de revisão sincronizadas com as definições (o <c>Attsync</c> estrutural).</summary>
            internal int ReferenciasSincronizadas { get; set; }

            /// <summary>O <c>maxCapa</c>/<c>maxCorpo</c> do formato novo.</summary>
            internal int MaxCapa { get; set; }

            internal int MaxCorpo { get; set; }

            /// <summary>A configuração do desenho foi regravada.</summary>
            internal bool ConfigGravada { get; set; }

            /// <summary>A capa que foi ativada ao fim da restauração.</summary>
            internal string CapaAtivada { get; set; }
        }

        /// <summary>
        /// Sobrecarga compatível que roda a cadeia sem revisões simplificadas pré-capturadas.
        /// </summary>
        internal static Resultado Executar(IReadOnlyDictionary<string, TitulosDaPagina> titulos, bool tinhaFormato)
        {
            return Executar(titulos, null, tinhaFormato);
        }

        /// <summary>
        /// Roda a cadeia. <paramref name="titulos"/> e <paramref name="revisoes"/> são os dados
        /// capturados **antes** da troca; só entram quando <paramref name="tinhaFormato"/> é
        /// verdadeiro (o <c>flag2 = ExisteFormato()</c> do original gateia a revisão e os títulos). O
        /// <c>Conf.incluirColuna</c> que o <c>AtualizaContTotFl</c> consulta sai da configuração do
        /// desenho. Nunca lança.
        /// </summary>
        internal static Resultado Executar(
            IReadOnlyDictionary<string, TitulosDaPagina> titulos,
            IReadOnlyList<RevisaoSimplificadaDaPagina> revisoes,
            bool tinhaFormato)
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
            ObjectId formatoDefId = ObjectId.Null;
            string capa = string.Empty;

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
                BlockTableRecord espaco = (BlockTableRecord)transacao.GetObject(
                    tabela[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                BornesDaCorrecao.GarantirAppName(transacao, banco, TituloDaPaginaXData.AppName);

                BlockReference formato = RecriarCampos(transacao, banco, espaco, paginas, resultado, out capa);
                if (formato == null)
                {
                    transacao.Commit();
                    return resultado;
                }

                formatoDefId = formato.BlockTableRecord;

                transacao.Commit();
            }

            PosicoesDoFormato posicoes = new PosicoesDoFormato();

            // 4) Revisão, títulos e colunas: só quando o desenho **já tinha** formato (o `if (flag2)` do
            //    original). Na criação do formato não há revisão, títulos nem colunas antigas a restaurar.
            if (tinhaFormato)
            {
                int definicoes, apagadas, referencias;
                posicoes = RevisoesDoDesenho.CriarDefinicoesDoFormato(out definicoes, out apagadas, out referencias);
                resultado.Definicoes = definicoes;
                resultado.DefinicoesApagadas = apagadas;
                resultado.ReferenciasSincronizadas = referencias;
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

                // 6) AtualizaRevSimplificada: devolve as revisões simplificadas capturadas antes da troca.
                if (revisoes != null && revisoes.Count > 0)
                {
                    resultado.RevSimplificadas = RevisoesDoDesenho.GravarSimplificadas(revisoes);
                }

                // 7) TrocaColunas: apaga entidades de coluna antigas e reinstancia do formato novo.
                if (!formatoDefId.IsNull)
                {
                    TrocaColunasDoDesenho.Resultado colunas = TrocaColunasDoDesenho.Trocar(banco, formatoDefId);
                    resultado.ColunasApagadas = colunas.EntidadesApagadas;
                    resultado.ColunasCriadas = colunas.EntidadesCriadas;
                }
            }

            // 8) AtualizaContTotFl: o conteúdo de CONT/FL/TOT/ALTERNATIVO.
            resultado.ContTotFl = AtualizarContTotFl(banco, paginas, incluirColuna);

            // 9) GravarXDataConfiguracao com o maxCapa/maxCorpo do formato novo.
            if (conf != null && (conf.MaxCapa != posicoes.Capa || conf.MaxCorpo != posicoes.Corpo))
            {
                conf.MaxCapa = posicoes.Capa;
                conf.MaxCorpo = posicoes.Corpo;
                resultado.ConfigGravada = ConfiguracaoDoDesenho.Gravar(conf);
            }

            // 10) Ativação da capa (o `DeclaracoesGeral.ativo.Pagina = Pagina.retornaNumeroCapa()` do original).
            if (!string.IsNullOrEmpty(capa))
            {
                PaginaAtivaDoDesenho.Ativar(capa);
                resultado.CapaAtivada = capa;
            }

            return resultado;
        }

        /// <summary>
        /// Pagina.restauraCampos, chamado pelo editor antes de ler a grade. Não executa a cadeia
        /// de troca de formato: mantém colunas, definições, configuração e página ativa.
        /// A transação externa torna atômicas também as gravações dos adapters reutilizados.
        /// </summary>
        internal static Resultado RestaurarCampos()
        {
            Resultado resultado = new Resultado();
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null) return resultado;
            using (documento.LockDocument())
            using (Transaction transacao = documento.Database.TransactionManager.StartTransaction())
            {
                Database banco = documento.Database;
                List<PaginaDoCaderno> paginas = LerPaginas(banco);
                Dictionary<string, TitulosDaPagina> titulos = TitulosDaPaginaDoDesenho.LerGrade();
                List<RevisaoSimplificadaDaPagina> revisoes = RevisoesDoDesenho.LerSimplificadas();
                Dictionary<string, string> alternativos = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                foreach (PaginaDoCaderno pagina in paginas) alternativos[pagina.Nome] = pagina.Alternativo;

                BlockTableRecord espaco = EspacoDeModelo(transacao, banco, OpenMode.ForWrite);
                BornesDaCorrecao.GarantirAppName(transacao, banco, TituloDaPaginaXData.AppName);
                string capa;
                RecriarCampos(transacao, banco, espaco, paginas, resultado, out capa);
                resultado.Titulos = TitulosDaPaginaDoDesenho.GravarGrade(titulos, alternativos);
                resultado.RevSimplificadas = RevisoesDoDesenho.GravarSimplificadas(revisoes);
                ConfiguracaoDoCaderno conf = ConfiguracaoDoDesenho.Ler();
                resultado.ContTotFl = AtualizarContTotFl(banco, LerPaginas(banco), conf != null ? conf.IncluirColuna : 1);
                transacao.Commit();
            }
            return resultado;
        }

        /// <summary>Trecho comum a restauraCampos e CriaCaderno; não restaura dados nem ativa páginas.</summary>
        private static BlockReference RecriarCampos(
            Transaction transacao, Database banco, BlockTableRecord espaco,
            IReadOnlyList<PaginaDoCaderno> paginas, Resultado resultado, out string capa)
        {
            resultado.CamposApagados = ApagarCampos(transacao, espaco);
            BlockReference formato = FormatoDoDesenho.Encontrar(transacao, espaco);
            capa = LayerDaCapa(transacao, banco);
            if (formato == null) return null;
            resultado.CamposTot = CriarCamposTot(transacao, banco, espaco, formato, capa);
            foreach (PaginaDoCaderno pagina in paginas)
            {
                string layerRef = PaginaAtiva.ChecaCapa(pagina.Nome) ? capa : LayerDoCorpo;
                if (layerRef.Length == 0) continue;
                int criados = CriacaoDePaginaDoDesenho.CopiarCampos(
                    transacao, banco, espaco, formato, layerRef, pagina.Nome);
                if (criados > 0)
                {
                    resultado.Paginas++;
                    resultado.CamposCriados += criados;
                }
            }
            return formato;
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
