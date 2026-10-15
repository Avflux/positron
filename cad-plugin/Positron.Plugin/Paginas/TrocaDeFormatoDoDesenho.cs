using System;
using System.Collections.Generic;
using System.IO;
using Positron.Data.Fiacao;
using Positron.Data.Interface;
using Positron.Data.Paginas;
using Positron.Plugin.Bornes;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
#endif

namespace Positron.Plugin.Paginas
{
    /// <summary>
    /// A **troca do formato** no desenho — o <c>Caderno.CriaCaderno</c> do reverso (o botão
    /// CADERNO da barra, comando <c>CAD</c>): apaga o formato antigo (a definição e as referências
    /// do bloco, o <c>ApagaDefinicaoReferencias</c>), insere o DWG do formato novo como bloco na
    /// origem (layer <c>0</c>), carimba o XData <c>DiagLog</c>/<c>Formato</c> e **recria os
    /// atributos** a partir da definição — os protegidos (<c>attProtCollection</c>) nascem
    /// invisíveis e vazios e os demais herdam o valor capturado do formato antigo, casado por
    /// página (o decimal do layer) e tag. A capa é renomeada para <c>"1"</c> durante a troca e
    /// restaurada no fim (o <c>retornaNumeroCapa</c>/<c>alteraNomeLayer</c>).
    ///
    /// A decisão de cada passo é **pura** (<see cref="TrocaDeFormato"/>); este adapter só fala com
    /// o CAD.
    ///
    /// **Diálogos, como o original:** sem um caminho já definido, o DWG do formato novo vem do
    /// <c>GetFileNameForOpen</c> (o "Selecione o formato:") e cada atributo não protegido é
    /// perguntado no <c>GetString</c>, com o valor preservado como padrão. Com o caminho em
    /// <c>POSITRON_FORMATO</c> (a convenção <c>POSITRON_*</c> do resto do plugin), o comando
    /// **não** abre diálogo nenhum: usa o caminho, pula o prompt de cada atributo (o padrão é o
    /// valor preservado, o "Enter" do original) e aceita a troca pela variável
    /// <c>POSITRON_FORMATO_TROCAR</c>.
    ///
    /// **A cadeia pós-troca** — o <c>ApagarCamposPaginas</c>, o <c>criaCamposTOT</c>, o
    /// <c>criaCamposFormato</c> de cada página, as definições de revisão, o <c>AtualizaTitulos</c> e
    /// o <c>AtualizaContTotFl</c> — está em <see cref="RestauracaoDoFormatoDoDesenho"/>. Ficam
    /// **fora, com o motivo:** o <c>TrocaColunas</c>, o <c>AtualizaRevSimplificada</c>, o
    /// <c>attsync</c> por referência e a página ativa/paleta do fim do <c>CriaCaderno</c>.
    /// </summary>
    internal static class TrocaDeFormatoDoDesenho
    {
        /// <summary>App name do XData que marca o bloco de formato (o mesmo dos títulos).</summary>
        internal const string AppName = FormatoDoDesenho.AppName;

        /// <summary>A camada do bloco de formato novo (o <c>"0"</c> do original).</summary>
        internal const string LayerDoBloco = "0";

        /// <summary>O filtro do diálogo de abrir o formato (o literal do original).</summary>
        private const string FiltroDoFormato = "AutoCAD DWG (*.dwg)|*.dwg";

        /// <summary>O que a troca fez — para o resumo do comando (não há clique para ver a tela).</summary>
        internal sealed class Resultado
        {
            /// <summary>O desenho já tinha um formato (a troca, não a criação).</summary>
            internal bool TinhaFormato { get; set; }

            /// <summary>O diálogo do arquivo foi cancelado (nada foi tocado).</summary>
            internal bool Cancelado { get; set; }

            /// <summary>A capa foi renomeada para "1" e restaurada (o nome restaurado; vazio quando não houve).</summary>
            internal string CapaRestaurada { get; set; }

            /// <summary>O nome da definição do formato antigo apagada.</summary>
            internal string DefinicaoApagada { get; set; }

            /// <summary>Quantas referências do formato antigo foram apagadas com a definição.</summary>
            internal int ReferenciasApagadas { get; set; }

            /// <summary>O nome da definição do bloco de formato novo.</summary>
            internal string NomeDoBloco { get; set; }

            /// <summary>Atributos criados na referência do formato novo.</summary>
            internal int AtributosCriados { get; set; }

            /// <summary>Atributos que herdaram o valor do formato antigo.</summary>
            internal int AtributosPreservados { get; set; }

            /// <summary>Atributos do conjunto protegido (nasceram invisíveis e vazios).</summary>
            internal int AtributosProtegidos { get; set; }

            /// <summary>Quantos atributos foram perguntados ao usuário (no modo interativo).</summary>
            internal int AtributosPerguntados { get; set; }
        }

        /// <summary>O desenho tem um bloco de formato? (o <c>ExisteFormato</c>, só de leitura)</summary>
        internal static bool Existe()
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return false;
            }

            using (Transaction transacao = documento.Database.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = EspacoDeModelo(transacao, documento.Database, OpenMode.ForRead);
                bool existe = FormatoDoDesenho.Encontrar(transacao, espaco) != null;
                transacao.Commit();
                return existe;
            }
        }

        /// <summary>
        /// O nome do DWG que o original pede (o <c>GetFileNameForOpen</c>); <c>null</c> quando o
        /// usuário cancela ou não há desenho aberto.
        /// </summary>
        internal static string EscolherFormato()
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return null;
            }

            PromptOpenFileOptions opcoes = new PromptOpenFileOptions(MensagensDoReverso.SelecioneOFormato);
            opcoes.DialogCaption = MensagensDoReverso.SelecioneUmFormato;
            opcoes.Filter = FiltroDoFormato;

            PromptFileNameResult resultado = documento.Editor.GetFileNameForOpen(opcoes);
            if (resultado.Status != PromptStatus.OK || string.IsNullOrEmpty(resultado.StringResult))
            {
                return null;
            }

            return resultado.StringResult;
        }

        /// <summary>
        /// Troca (ou cria) o formato. <paramref name="caminhoPedido"/> não nulo é o modo
        /// <c>POSITRON_FORMATO</c> (sem diálogo e sem prompts); nulo é o interativo.
        /// Nunca lança — a falha vira o resultado relatado pelo comando.
        /// </summary>
        internal static Resultado Trocar(string caminhoPedido)
        {
            Resultado resultado = new Resultado();
            bool interativo = string.IsNullOrEmpty(caminhoPedido);

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return resultado;
            }

            Database banco = documento.Database;

            // O caminho do formato novo: o do ambiente (modo script) ou o diálogo do original.
            string caminho = caminhoPedido;
            if (interativo)
            {
                caminho = EscolherFormato();
                if (string.IsNullOrEmpty(caminho))
                {
                    resultado.Cancelado = true;
                    return resultado;
                }
            }

            string nome = Path.GetFileNameWithoutExtension(caminho);
            if (string.IsNullOrEmpty(nome))
            {
                resultado.Cancelado = true;
                return resultado;
            }

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
                BlockTableRecord espaco = (BlockTableRecord)transacao.GetObject(
                    tabela[BlockTableRecord.ModelSpace], OpenMode.ForWrite);

                BlockReference formato = FormatoDoDesenho.Encontrar(transacao, espaco);
                IReadOnlyList<AtributoDoFormato> capturados = new List<AtributoDoFormato>();
                if (formato != null)
                {
                    resultado.TinhaFormato = true;
                    capturados = TrocaDeFormato.Captura(LerAtributosDaReferencia(transacao, formato));
                    resultado.DefinicaoApagada = formato.Name;

                    // A capa passa a "1" durante a troca (o `retornaNumeroCapa` tem de responder "1"
                    // enquanto o formato é reconstruído) e volta ao nome antigo no fim.
                    resultado.CapaRestaurada = RenomearCapaParaUm(transacao, banco);

                    resultado.ReferenciasApagadas = ApagarDefinicao(transacao, tabela, formato.Name);
                }

                BlockTableRecord definicao = InserirFormato(transacao, banco, espaco, nome, caminho);
                if (definicao == null)
                {
                    // Não deu para ler o DWG: nada foi tocado além do (já apagado) formato antigo —
                    // o original também só mostra a mensagem de erro e aborta.
                    transacao.Abort();
                    return resultado;
                }

                resultado.NomeDoBloco = definicao.Name;
                CriarAtributos(transacao, banco, definicao, espaco, capturados, documento, interativo, resultado);

                RestaurarCapa(transacao, banco, resultado.CapaRestaurada);
                transacao.Commit();
            }

            return resultado;
        }

        /// <summary>Os atributos da **referência** do formato (o <c>CapturaAtributosDoFormato</c>): layer, tag e texto.</summary>
        private static List<AtributoDoFormato> LerAtributosDaReferencia(Transaction transacao, BlockReference formato)
        {
            List<AtributoDoFormato> atributos = new List<AtributoDoFormato>();
            foreach (ObjectId id in formato.AttributeCollection)
            {
                AttributeReference atributo = transacao.GetObject(id, OpenMode.ForRead) as AttributeReference;
                if (atributo == null)
                {
                    continue;
                }

                atributos.Add(new AtributoDoFormato(atributo.Layer, atributo.Tag, atributo.TextString));
            }

            return atributos;
        }

        /// <summary>
        /// Apaga a definição do formato e **todas** as referências dela (o
        /// <c>ApagaDefinicaoReferencias</c>): primeiro as referências, depois o registro. Devolve
        /// quantas referências saíram.
        /// </summary>
        private static int ApagarDefinicao(Transaction transacao, BlockTable tabela, string nomeBloco)
        {
            if (string.IsNullOrEmpty(nomeBloco) || !tabela.Has(nomeBloco))
            {
                return 0;
            }

            BlockTableRecord definicao = transacao.GetObject(tabela[nomeBloco], OpenMode.ForWrite) as BlockTableRecord;
            if (definicao == null)
            {
                return 0;
            }

            int referencias = 0;
            ObjectIdCollection ids = definicao.GetBlockReferenceIds(true, true);
            if (ids != null)
            {
                foreach (ObjectId id in ids)
                {
                    DBObject objeto = transacao.GetObject(id, OpenMode.ForWrite, false, true);
                    if (objeto != null)
                    {
                        objeto.Erase();
                        referencias++;
                    }
                }
            }

            definicao.Erase(true);
            return referencias;
        }

        /// <summary>
        /// Insere o DWG do formato como bloco na origem (layer <c>0</c>) e carimba o XData
        /// <c>DiagLog</c>/<c>Formato</c>. Devolve a definição criada, ou <c>null</c> quando o DWG não
        /// pôde ser lido.
        /// </summary>
        private static BlockTableRecord InserirFormato(
            Transaction transacao,
            Database banco,
            BlockTableRecord espaco,
            string nome,
            string caminho)
        {
            if (!File.Exists(caminho))
            {
                return null;
            }

            ObjectId idDefinicao;
            try
            {
                Database novo = new Database(false, true);
                try
                {
                    novo.ReadDwgFile(caminho, FileShare.Read, true, "");
                    idDefinicao = banco.Insert(nome, novo, false);
                }
                finally
                {
                    novo.Dispose();
                }
            }
            catch (System.Exception)
            {
                return null;
            }

            BlockTableRecord definicao = transacao.GetObject(idDefinicao, OpenMode.ForRead) as BlockTableRecord;
            if (definicao == null)
            {
                return null;
            }

            BlockReference bloco = new BlockReference(Point3d.Origin, idDefinicao);
            bloco.Layer = LayerDoBloco;
            espaco.AppendEntity(bloco);
            transacao.AddNewlyCreatedDBObject(bloco, true);

            BornesDaCorrecao.GarantirAppName(transacao, banco, AppName);
            bloco.XData = BornesDaCorrecao.ParaResultBuffer(new List<TypedXData>
            {
                new TypedXData(1001, AppName),
                new TypedXData(1000, FormatoDoDesenho.Marca),
                new TypedXData(1070, 3),
                new TypedXData(1000, " "),
            });

            return definicao;
        }

        /// <summary>
        /// Cria um <c>AttributeReference</c> por definição de atributo do formato novo: os
        /// protegidos nascem invisíveis e vazios e os demais herdam o valor preservado (o
        /// <c>DefaultValue</c> do prompt do original). No modo interativo o valor é perguntado.
        /// </summary>
        private static void CriarAtributos(
            Transaction transacao,
            Database banco,
            BlockTableRecord definicao,
            BlockTableRecord espaco,
            IReadOnlyList<AtributoDoFormato> capturados,
            Document documento,
            bool interativo,
            Resultado resultado)
        {
            // A referência do formato recém-criada é a última do ModelSpace no layer 0.
            BlockReference bloco = UltimaReferenciaDoFormato(transacao, espaco);
            if (bloco == null)
            {
                return;
            }

            foreach (ObjectId idDef in definicao)
            {
                AttributeDefinition atributoDef = transacao.GetObject(idDef, OpenMode.ForRead) as AttributeDefinition;
                if (atributoDef == null)
                {
                    continue;
                }

                InstrucaoDeAtributo instrucao = TrocaDeFormato.Definir(atributoDef.Tag, atributoDef.Layer, capturados);

                AttributeReference atributo = new AttributeReference();
                atributo.SetAttributeFromBlock(atributoDef, bloco.BlockTransform);

                if (instrucao.Invisivel)
                {
                    atributo.Invisible = true;
                    atributo.TextString = string.Empty;
                    resultado.AtributosProtegidos++;
                }
                else if (interativo)
                {
                    atributo.TextString = Perguntar(atributoDef, instrucao.Texto, documento);
                    resultado.AtributosPerguntados++;
                    if (instrucao.Texto.Length > 0)
                    {
                        resultado.AtributosPreservados++;
                    }
                }
                else
                {
                    atributo.TextString = instrucao.Texto;
                    if (instrucao.Texto.Length > 0)
                    {
                        resultado.AtributosPreservados++;
                    }
                }

                atributo.AdjustAlignment(banco);
                bloco.AttributeCollection.AppendAttribute(atributo);
                transacao.AddNewlyCreatedDBObject(atributo, true);
                resultado.AtributosCriados++;
            }
        }

        /// <summary>
        /// O prompt de um atributo (o <c>GetString</c> do <c>CriaCaderno</c>): o texto do original é
        /// o prefixo <c>CAPA-&gt;</c>/<c>CORPO-&gt;</c> (pelo layer do atributo) mais o <c>Prompt</c>
        /// da definição; o valor preservado entra como padrão.
        /// </summary>
        private static string Perguntar(AttributeDefinition atributoDef, string padrao, Document documento)
        {
            if (documento == null)
            {
                return padrao ?? string.Empty;
            }

            string prefixo = string.Empty;
            if (PaginaAtiva.ChecaCapa(atributoDef.Layer))
            {
                prefixo = MensagensDoReverso.Capa;
            }
            else if (string.Equals(atributoDef.Layer, PaginaAtiva.LayerDoFormatoDoCorpo, StringComparison.OrdinalIgnoreCase))
            {
                prefixo = MensagensDoReverso.Corpo;
            }

            PromptStringOptions opcoes = new PromptStringOptions(
                "\r\n" + prefixo + (atributoDef.Prompt ?? string.Empty) + ":");
            opcoes.AllowSpaces = true;
            opcoes.AppendKeywordsToMessage = false;

            string valor = padrao ?? string.Empty;
            opcoes.DefaultValue = valor;
            opcoes.UseDefaultValue = valor.Length > 0;

            PromptResult resultado = documento.Editor.GetString(opcoes);
            return resultado.Status == PromptStatus.OK ? (resultado.StringResult ?? string.Empty) : valor;
        }

        /// <summary>Renomeia a capa para <c>"1"</c> quando ela tem outro nome; devolve o nome antigo (ou vazio).</summary>
        private static string RenomearCapaParaUm(Transaction transacao, Database banco)
        {
            LayerTable camadas = transacao.GetObject(banco.LayerTableId, OpenMode.ForRead) as LayerTable;
            if (camadas == null)
            {
                return string.Empty;
            }

            foreach (ObjectId id in camadas)
            {
                LayerTableRecord layer = transacao.GetObject(id, OpenMode.ForRead) as LayerTableRecord;
                if (layer == null || !PaginaAtiva.ChecaCapa(layer.Name))
                {
                    continue;
                }

                if (!TrocaDeFormato.PrecisaRenomearCapa(layer.Name))
                {
                    return string.Empty;
                }

                // O destino não pode existir: o original deixaria o próprio CAD estourar o rename.
                if (camadas.Has(TrocaDeFormato.LayerPadraoDaCapa))
                {
                    return string.Empty;
                }

                string antigo = layer.Name;
                layer.UpgradeOpen();
                layer.Name = TrocaDeFormato.LayerPadraoDaCapa;
                return antigo;
            }

            return string.Empty;
        }

        /// <summary>Devolve a capa ao nome antigo (o segundo <c>alteraNomeLayer</c> do original).</summary>
        private static void RestaurarCapa(Transaction transacao, Database banco, string antigo)
        {
            if (string.IsNullOrEmpty(antigo))
            {
                return;
            }

            LayerTable camadas = transacao.GetObject(banco.LayerTableId, OpenMode.ForRead) as LayerTable;
            if (camadas == null || !camadas.Has(TrocaDeFormato.LayerPadraoDaCapa))
            {
                return;
            }

            LayerTableRecord layer = transacao.GetObject(
                camadas[TrocaDeFormato.LayerPadraoDaCapa], OpenMode.ForWrite) as LayerTableRecord;
            if (layer == null)
            {
                return;
            }

            layer.Name = antigo;
        }

        /// <summary>A referência do formato no ModelSpace (a que o <c>InserirFormato</c> acabou de acrescentar).</summary>
        private static BlockReference UltimaReferenciaDoFormato(Transaction transacao, BlockTableRecord espaco)
        {
            BlockReference achada = null;
            foreach (ObjectId id in espaco)
            {
                BlockReference bloco = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
                if (bloco == null)
                {
                    continue;
                }

                ResultBuffer xdata = bloco.GetXDataForApplication(AppName);
                if (xdata == null)
                {
                    continue;
                }

                IReadOnlyList<TypedXData> valores = XDataNeutro.Para(xdata);
                if (valores.Count > 1
                    && string.Equals(Convert.ToString(valores[1].Valor), FormatoDoDesenho.Marca, StringComparison.OrdinalIgnoreCase))
                {
                    achada = bloco;
                }
            }

            return achada;
        }

        private static BlockTableRecord EspacoDeModelo(Transaction transacao, Database banco, OpenMode modo)
        {
            BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
            return (BlockTableRecord)transacao.GetObject(tabela[BlockTableRecord.ModelSpace], modo);
        }
    }
}
