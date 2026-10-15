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
    /// A parte que **grava** da criação de página (o <c>Pagina.criarUmaNovaPagina</c> do reverso, a
    /// fatia 6 da frente 10): cria o **layer** da página com o XData de unidade/alternativo
    /// (<c>GravarXDataUnidadeAlternativo</c>) e copia os **campos do formato**
    /// (<c>criaCamposFormato</c>) do bloco de formato para o layer novo. A decisão é pura
    /// (<see cref="CriacaoDePagina"/>).
    ///
    /// **Onde o formato mora:** o bloco de formato é um <c>BlockReference</c> do ModelSpace com o
    /// XData <c>DiagLog</c> / <c>Formato</c> (o <c>PossuiXDataFormato</c> do original); os atributos
    /// dele na camada <c>-1</c> são o **modelo**: os oito do mapa do <c>criaCamposFormato</c> viram
    /// um <c>DBText</c> no layer da página (com a mesma posição/altura/estilo, o <c>dtepniSZGL6</c> do
    /// original) e recebem o XData do título (<see cref="TituloDaPaginaXData"/>). Sem o bloco de
    /// formato a página nasce **só com o layer** — e o resumo diz isso, em vez de fingir que copiou.
    /// 
    /// **O que fica fora (registrado):** o original ainda lê/escreve os **títulos** da página
    /// (<c>capturaTitulos*</c>/<c>AtualizaTitulosDeUmaPagina</c>) e o XData do layer é o dele; aqui
    /// entra o layer e os campos — os títulos são a fatia seguinte.
    /// </summary>
    internal static class CriacaoDePaginaDoDesenho
    {
        /// <summary>App name do XData do layer (unidade/alternativo).</summary>
        internal const string AppNameEletron = "Eletron";

        /// <summary>A camada do bloco de formato de onde os campos são copiados (o <c>-1</c> do original).</summary>
        internal const string LayerDeReferencia = "-1";

        internal sealed class Resultado
        {
            /// <summary>O nome normalizado da página (vazio quando o pedido não gera nome).</summary>
            internal string Nome { get; set; }

            /// <summary>O layer foi criado nesta passada.</summary>
            internal bool Criado { get; set; }

            /// <summary>O layer já existia (o <c>-1</c> do <c>CriarLayer</c>).</summary>
            internal bool JaExistia { get; set; }

            /// <summary>O desenho tem o bloco de formato.</summary>
            internal bool TemFormato { get; set; }

            /// <summary>Campos do formato copiados para a página nova.</summary>
            internal int CamposCopiados { get; set; }

            /// <summary>Títulos herdados da página de referência (o `AtualizaTitulosDeUmaPagina`).</summary>
            internal int TitulosCopiados { get; set; }
        }

        internal static Resultado Executar(
            string pagina, int larguraFixa, string unidade, string alternativo, string referencia)
        {
            Resultado resultado = new Resultado();

            // A página é recusada **antes** de normalizar: com a largura fixa ligada, um nome
            // vazio sairia como uma fileira de zeros (o comportamento do `montaNumeroPagina`).
            if (string.IsNullOrEmpty((pagina ?? string.Empty).Trim()))
            {
                return resultado;
            }

            resultado.Nome = CriacaoDePagina.Normalizar(pagina, larguraFixa);
            if (resultado.Nome.Length == 0)
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
                LayerTable camadas = (LayerTable)transacao.GetObject(banco.LayerTableId, OpenMode.ForRead);
                if (camadas.Has(resultado.Nome))
                {
                    resultado.JaExistia = true;
                    transacao.Commit();
                    return resultado;
                }

                camadas.UpgradeOpen();
                LayerTableRecord layer = new LayerTableRecord { Name = resultado.Nome };
                camadas.Add(layer);
                transacao.AddNewlyCreatedDBObject(layer, true);
                BornesDaCorrecao.GarantirAppName(transacao, banco, AppNameEletron);
                layer.XData = BornesDaCorrecao.ParaResultBuffer(new List<TypedXData>
                {
                    new TypedXData(1001, AppNameEletron),
                    new TypedXData(1000, "Unidade"),
                    new TypedXData(1000, unidade ?? string.Empty),
                    new TypedXData(1000, alternativo ?? string.Empty),
                });
                resultado.Criado = true;

                BlockTableRecord espaco = EspacoDeModelo(transacao, banco, OpenMode.ForWrite);
                BlockReference formato = FormatoDoDesenho.Encontrar(transacao, espaco);
                if (formato != null)
                {
                    resultado.TemFormato = true;
                    resultado.CamposCopiados = CopiarCampos(
                        transacao, banco, espaco, formato, LayerDeReferencia, resultado.Nome);
                }

                transacao.Commit();

                // Os títulos da página de referência passam para a nova — o
                // `pagCorrente.Titulo1..4 = pag.Titulo1..4` + `AtualizaTitulosDeUmaPagina` do
                // `criarUmaNovaPagina` (transação própria, como o original).
            }

            if (!string.IsNullOrEmpty(referencia))
            {
                resultado.TitulosCopiados = TitulosDaPaginaDoDesenho.Gravar(
                    resultado.Nome, TitulosDaPaginaDoDesenho.Ler(referencia));
            }

            return resultado;
        }

        /// <summary>
        /// Os oito campos do formato viram <c>DBText</c> no layer da página (o <c>criaCamposFormato</c>).
        /// O <paramref name="layerRef"/> é o layer do atributo que serve de modelo: o <c>-1</c> nas
        /// páginas normais e o **nome da capa** na capa (o <c>retornaNumeroCapa()</c> do original),
        /// que é o que a cadeia pós-troca do formato passa.
        /// </summary>
        internal static int CopiarCampos(
            Transaction transacao,
            Database banco,
            BlockTableRecord espaco,
            BlockReference formato,
            string layerRef,
            string layer)
        {
            int copiados = 0;
            BornesDaCorrecao.GarantirAppName(transacao, banco, TituloDaPaginaXData.AppName);

            foreach (ObjectId id in formato.AttributeCollection)
            {
                AttributeReference atributo = transacao.GetObject(id, OpenMode.ForRead) as AttributeReference;
                if (atributo == null)
                {
                    continue;
                }

                if (!string.Equals(atributo.Layer, layerRef, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                CriacaoDePagina.CampoDoFormato campo = CriacaoDePagina.CampoDoFormato.De(atributo.Tag);
                if (campo == null)
                {
                    continue;
                }

                DBText texto = Clonar(atributo, campo.Texto, layer);
                espaco.AppendEntity(texto);
                transacao.AddNewlyCreatedDBObject(texto, true);
                texto.XData = BornesDaCorrecao.ParaResultBuffer(TituloDaPaginaXData.ParaValores(
                    campo.Indice, campo.Texto, Environment.UserName, DateTime.Now.ToString()));
                copiados++;
            }

            return copiados;
        }

        /// <summary>O <c>dtepniSZGL6</c> do original: o atributo vira um <c>DBText</c> com a mesma forma.</summary>
        internal static DBText Clonar(AttributeReference atributo, string conteudo, string layer)
        {
            DBText texto = new DBText
            {
                Layer = layer,
                TextString = conteudo,
                TextStyleId = atributo.TextStyleId,
                ColorIndex = atributo.ColorIndex,
                LineWeight = atributo.LineWeight,
                Height = atributo.Height,
                WidthFactor = atributo.WidthFactor,
                Position = atributo.Position,
                Oblique = atributo.Oblique,
                Rotation = atributo.Rotation,
                Visible = true,
                HorizontalMode = atributo.HorizontalMode,
                VerticalMode = atributo.VerticalMode,
            };

            if (atributo.HorizontalMode != 0 || atributo.VerticalMode != 0)
            {
                texto.AlignmentPoint = atributo.AlignmentPoint;
            }

            return texto;
        }

        private static BlockTableRecord EspacoDeModelo(Transaction transacao, Database banco, OpenMode modo)
        {
            BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
            return (BlockTableRecord)transacao.GetObject(tabela[BlockTableRecord.ModelSpace], modo);
        }
    }
}
