using System;
using System.Collections.Generic;
using Positron.Data;
using Positron.Data.Cabos;
using Positron.Data.Configuracao;
using Positron.Data.Fiacao;
using Positron.Data.Interligacao;
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

namespace Positron.Plugin.Interligacao
{
    /// <summary>
    /// <c>RecriaTextosCabo</c> — o comando do <c>clsEletron.cs</c>: apaga os rótulos
    /// auxiliares das veias (a regra do <c>clsEletron.ApagarTodosOsTextosDasVeias</c>)
    /// e **reinsere um por trecho de interligação** que ficou sem rótulo, com o texto
    /// calculado do XData do trecho e a posição vinda do segmento da polilinha —
    /// o <c>clsEditarInterligacao.InsereTextosDeCabos(bPadraoEL: true)</c>, o caminho
    /// do **modelo padrão** (`iModeloVeiaFuncao = 0`).
    ///
    /// Fora do recorte desta rodada, e documentado: o modelo Eletrosul
    /// (<c>RecriaTextosCaboEletrosul</c>), o <c>InterligacaoLayout == 3</c> (ENEL), o
    /// <c>bApaga</c> e o <c>AtualizaTodosOpcionaisDoCabo</c>.
    ///
    /// A regra é pura e está em <see cref="CorrecaoTextosCabo"/>,
    /// <see cref="TextoDoRotuloDeCabo"/> e <see cref="PosicaoDoRotuloDeCabo"/>; aqui se
    /// varre o ModelSpace e se escreve.
    /// </summary>
    internal static class RotulosDeCaboDoDesenho
    {
        internal sealed class Resultado
        {
            internal int EntidadesLidas { get; set; }

            internal int RotulosApagados { get; set; }

            internal int TrechosLidos { get; set; }

            internal int TrechosComRotulo { get; set; }

            internal int RotulosInseridos { get; set; }

            internal int CabosSingelos { get; set; }

            /// <summary>Sem banco (ou sem catálogo) o "singelo" não é resolvido — o texto sai com o separador.</summary>
            internal bool SemCatalogo { get; set; }
        }

        internal static Resultado Executar()
        {
            return Executar(false);
        }

        /// <summary>
        /// <c>RecriaTextosCaboEletrosul</c> — o irmão da Eletrosul: **a mesma limpeza** e um
        /// rótulo por trecho, mas com a geometria própria
        /// (<c>criarTextoNomeCaboEletrosul</c>: alinhamento no **meio do segmento**, rotação
        /// 0 e horizontal à esquerda), **sem** o teste de "já tem rótulo" (o original
        /// reinsere para todo trecho) e com <c>iModeloVeiaFuncao = 1</c>.
        ///
        /// Fora do recorte: o <c>AdicionaCaboEletrosul</c> (duas entidades extras com o
        /// XData <c>ELETROSUL</c>) e a marca <c>H</c>/<c>V</c> que ele grava.
        /// </summary>
        internal static Resultado ExecutarEletrosul()
        {
            return Executar(true);
        }

        private static Resultado Executar(bool eletrosul)
        {
            Resultado resultado = new Resultado();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return resultado;
            }

            ConfiguracaoPositron config = ConfiguracaoPositron.Carregar();
            bool semCatalogo;
            int quantosSingelos;
            HashSet<string> singelos = LerSingelos(config, out semCatalogo, out quantosSingelos);
            resultado.SemCatalogo = semCatalogo;
            resultado.CabosSingelos = quantosSingelos;
            Database banco = documento.Database;
            string usuario = Environment.UserName;
            string data = DateTime.Now.ToString();

            // Fase 1 — a limpeza do `clsEletron.ApagarTodosOsTextosDasVeias`, a mesma
            // das duas recriações (helper compartilhado).
            ApagarRotulosDeCabo.Resultado limpeza = ApagarRotulosDeCabo.Executar(config);
            resultado.EntidadesLidas = limpeza.EntidadesLidas;
            resultado.RotulosApagados = limpeza.Apagados;

            // Fase 2 — reinserir o que ficou sem rótulo (o `InsereTextosDeCabos`).
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTableRecord espaco = EspacoDeModelo(transacao, banco, OpenMode.ForWrite);
                List<string> rotulados = new List<string>();
                List<Trecho> trechos = new List<Trecho>();

                foreach (ObjectId id in espaco)
                {
                    Entity entidade = transacao.GetObject(id, OpenMode.ForRead) as Entity;
                    if (entidade == null)
                    {
                        continue;
                    }

                    DBText texto = entidade as DBText;
                    if (texto != null)
                    {
                        short tipo;
                        string handle;
                        if (!eletrosul
                            && AuxInterligacaoXData.Ler(
                                LerXData(entidade, AuxInterligacaoXData.AppName), out tipo, out handle)
                            && (tipo == CorrecaoTextosCabo.TipoRotuloCabo || tipo == 3))
                        {
                            rotulados.Add(handle);
                        }

                        continue;
                    }

                    Polyline linha = entidade as Polyline;
                    if (linha == null)
                    {
                        continue;
                    }

                    InterligacaoXData ilig;
                    if (!InterligacaoXData.Ler(LerXData(entidade, InterligacaoXData.AppName), out ilig))
                    {
                        continue;
                    }

                    trechos.Add(new Trecho
                    {
                        Id = id,
                        Handle = linha.Handle.ToString(),
                        Layer = linha.Layer,
                        Ligacao = ilig,
                        Vertices = LerVertices(linha),
                    });
                }

                resultado.TrechosLidos = trechos.Count;

                List<string> handles = new List<string>();
                foreach (Trecho trecho in trechos)
                {
                    handles.Add(trecho.Handle);
                }

                // A Eletrosul **não** olha se o trecho já tem rótulo: reinsere para todos.
                IReadOnlyList<string> semRotulo = eletrosul
                    ? handles
                    : CorrecaoTextosCabo.SemRotulo(handles, rotulados);
                resultado.TrechosComRotulo = trechos.Count - semRotulo.Count;

                TextStyleTable estilos =
                    (TextStyleTable)transacao.GetObject(banco.TextStyleTableId, OpenMode.ForRead);
                ObjectId estiloId = estilos.Has("Romans") ? estilos["Romans"] : estilos["Standard"];

                HashSet<string> aRotular = new HashSet<string>();
                foreach (string handle in semRotulo)
                {
                    aRotular.Add(handle);
                }

                foreach (Trecho trecho in trechos)
                {
                    if (!aRotular.Contains(trecho.Handle))
                    {
                        continue;
                    }

                    string texto = TextoDoRotuloDeCabo.Calcular(
                        trecho.Ligacao,
                        config.SeparadorCaboVeia,
                        VerificadorTerminalIndefinido,
                        singelos.Contains(trecho.Ligacao.Tag_Cabo));
                    PosicaoDoRotulo posicao = eletrosul
                        ? PosicaoDoRotuloDeCabo.CalcularEletrosul(trecho.Vertices)
                        : PosicaoDoRotuloDeCabo.Calcular(trecho.Vertices);

                    DBText novo = new DBText();
                    novo.TextStyleId = estiloId;
                    novo.VerticalMode = TextVerticalMode.TextBottom;
                    novo.HorizontalMode = eletrosul
                        ? TextHorizontalMode.TextLeft
                        : TextHorizontalMode.TextCenter;
                    novo.ColorIndex = (short)config.CorTextoInterligacao;
                    novo.Layer = trecho.Layer;
                    novo.TextString = texto;
                    novo.Height = config.FonteCabos;
                    novo.LineWeight = LineWeight.LineWeight009;
                    novo.AlignmentPoint = new Point3d(posicao.AlignX, posicao.AlignY, 0.0);
                    novo.Rotation = posicao.Rotation;

                    espaco.AppendEntity(novo);
                    transacao.AddNewlyCreatedDBObject(novo, true);

                    BornesDaCorrecao.GarantirAppName(transacao, banco, AuxInterligacaoXData.AppName);
                    novo.XData = ParaResultBuffer(AuxInterligacaoXData.ParaValores(
                        trecho.Handle, CorrecaoTextosCabo.TipoRotuloCabo, string.Empty, usuario, data, string.Empty));

                    // `ilig.iModeloVeiaFuncao = num` (0 no modelo padrão).
                    trecho.Ligacao.IndexModeloVeiaFuncao = eletrosul ? 1 : 0;
                    Polyline linha = transacao.GetObject(trecho.Id, OpenMode.ForWrite) as Polyline;
                    if (linha != null)
                    {
                        linha.XData = ParaResultBuffer(trecho.Ligacao.ParaValores(usuario, data));
                    }

                    resultado.RotulosInseridos++;
                }

                transacao.Commit();
            }

            return resultado;
        }

        /// <summary>O caracter de terminal indefinido (`Conf.CaracterTerminalIndefinido`, padrão `?`).</summary>
        private const string VerificadorTerminalIndefinido = "?";

        private sealed class Trecho
        {
            internal ObjectId Id { get; set; }

            internal string Handle { get; set; }

            internal string Layer { get; set; }

            internal InterligacaoXData Ligacao { get; set; }

            internal IReadOnlyList<PontoDoRotulo> Vertices { get; set; }
        }

        /// <summary>Os cabos <c>singelos</c> do catálogo: <c>SELECT Tag FROM Cabos WHERE Formacao like 1x</c>.</summary>
        /// <summary>
        /// Os cabos **singelos** do catálogo — o mesmo <c>CaboSingelo</c> das duas
        /// recriações de rótulo (compartilhado).
        /// </summary>
        internal static HashSet<string> LerSingelos(ConfiguracaoPositron config, out bool semCatalogo, out int quantos)
        {
            HashSet<string> singelos = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            semCatalogo = false;
            quantos = 0;
            if (string.IsNullOrEmpty(config.Banco))
            {
                semCatalogo = true;
                return singelos;
            }

            try
            {
                ProjectStore store = new ProjectStore(config.Banco);
                foreach (var cabo in store.LerCabos())
                {
                    if (cabo != null && !string.IsNullOrEmpty(cabo.Tag) &&
                        (cabo.Formacao ?? string.Empty).IndexOf("1x", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        singelos.Add(cabo.Tag);
                    }
                }
            }
            catch (Exception)
            {
                semCatalogo = true;
            }

            quantos = singelos.Count;
            return singelos;
        }

        private static IReadOnlyList<PontoDoRotulo> LerVertices(Polyline linha)
        {
            List<PontoDoRotulo> vertices = new List<PontoDoRotulo>();
            int quantos = linha.NumberOfVertices;
            for (int i = 0; i < quantos; i++)
            {
                Point2d ponto = linha.GetPoint2dAt(i);
                vertices.Add(new PontoDoRotulo { X = ponto.X, Y = ponto.Y });
            }

            return vertices;
        }

        private static bool TemXData(Entity entidade, string appName)
        {
            return entidade.GetXDataForApplication(appName) != null;
        }

        private static IReadOnlyList<TypedXData> LerXData(Entity entidade, string appName)
        {
            ResultBuffer xdata = entidade.GetXDataForApplication(appName);
            return xdata == null ? null : XDataNeutro.Para(xdata);
        }

        private static BlockTableRecord EspacoDeModelo(Transaction transacao, Database banco, OpenMode modo)
        {
            BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, modo);
            return (BlockTableRecord)transacao.GetObject(tabela[BlockTableRecord.ModelSpace], modo);
        }

        private static ResultBuffer ParaResultBuffer(IReadOnlyList<TypedXData> valores)
        {
            TypedValue[] array = new TypedValue[valores.Count];
            for (int i = 0; i < valores.Count; i++)
            {
                array[i] = new TypedValue(valores[i].Codigo, valores[i].Valor);
            }

            return new ResultBuffer(array);
        }
    }
}
