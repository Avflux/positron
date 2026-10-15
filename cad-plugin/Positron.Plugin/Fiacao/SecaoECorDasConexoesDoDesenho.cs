using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Positron.Data.Fiacao;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
#endif

namespace Positron.Plugin.Fiacao
{
    /// <summary>
    /// O <c>clsConexao.editarSecaoCor</c> (<c>EDCON</c>, por seleção) e o
    /// <c>clsConexao.editarSecaoCorPaginas</c> (<c>EDCONP</c>, pelas páginas da
    /// <c>frmEditaConexao</c>) no desenho: os prompts do original, a regravação do XData
    /// <c>CONEXAO</c> e dos textos <c>AUXCONEXAO</c>. A regra fica em
    /// <see cref="SecaoECorDasConexoes"/>.
    ///
    /// Como no original: documento travado, uma transação só, e um cancelamento em qualquer
    /// prompt não grava nada. O <c>MsgBox</c> do erro vira a linha de resumo.
    /// </summary>
    internal static class SecaoECorDasConexoesDoDesenho
    {
        internal sealed class Resultado
        {
            /// <summary>O usuário cancelou um prompt (nada foi gravado).</summary>
            internal bool Cancelado { get; set; }

            internal ModoSecaoECor Modo { get; set; }

            internal string Secao { get; set; }

            internal string Cor { get; set; }

            internal int Potenciais { get; set; }

            internal int Conexoes { get; set; }

            internal int Textos { get; set; }

            internal string Resumo(string comando)
            {
                if (Cancelado)
                {
                    return comando + ": cancelado — nada foi alterado.";
                }

                string valores = (SecaoECorDasConexoes.PedeSecao(Modo) ? " seção \"" + Secao + "\"" : string.Empty)
                    + (SecaoECorDasConexoes.PedeCor(Modo) ? " cor \"" + Cor + "\"" : string.Empty);
                return comando + ":" + valores + " — " + Potenciais + " potencial(is), " + Conexoes
                    + " conexão(ões) regravada(s), " + Textos + " texto(s) auxiliar(es) reescrito(s).";
            }
        }

        // O `hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF` do original: devolve o foco à janela do desenho
        // antes dos prompts (o EDCONP pergunta a partir de uma janela não modal).
        [DllImport("user32.dll", EntryPoint = "SetFocus")]
        private static extern IntPtr SetFocus(IntPtr janela);

        /// <summary>O prompt <c>Seção, Cor ou Ambas</c> (mMensagem 715), padrão <c>A</c>; <c>null</c> se cancelado.</summary>
        internal static ModoSecaoECor? PerguntarModo()
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return null;
            }

            SetFocus(documento.Window.Handle);
            PromptKeywordOptions opcoes = new PromptKeywordOptions("\r\nSeção, Cor ou Ambas");
            opcoes.Keywords.Add("S");
            opcoes.Keywords.Add("C");
            opcoes.Keywords.Add("A");
            opcoes.AllowNone = false;
            opcoes.AllowArbitraryInput = false;
            opcoes.Keywords.Default = "A";
            PromptResult resposta = documento.Editor.GetKeywords(opcoes);
            return resposta.Status == PromptStatus.OK ? SecaoECorDasConexoes.ModoDaPalavra(resposta.StringResult) : null;
        }

        /// <summary>
        /// Executa a edição. <paramref name="paginas"/> <c>null</c> = a variante por seleção
        /// (<c>EDCON</c>); senão, as páginas escolhidas na tela (<c>EDCONP</c>).
        /// </summary>
        internal static Resultado Executar(ModoSecaoECor modo, ICollection<string> paginas)
        {
            Resultado resultado = new Resultado { Modo = modo };

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                resultado.Cancelado = true;
                return resultado;
            }

            SetFocus(documento.Window.Handle);
            Editor editor = documento.Editor;
            Database banco = documento.Database;

            using (documento.LockDocument())
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
                BlockTableRecord espaco = (BlockTableRecord)transacao.GetObject(
                    tabela[BlockTableRecord.ModelSpace], OpenMode.ForRead);

                List<int> potenciais = paginas == null
                    ? PotenciaisDaSelecao(editor, transacao)
                    : SecaoECorDasConexoes.PotenciaisDasPaginas(ConexoesPorLayer(espaco, transacao), paginas);
                if (potenciais == null)
                {
                    resultado.Cancelado = true;
                    return resultado;
                }

                string secao = string.Empty;
                string cor = string.Empty;
                if (SecaoECorDasConexoes.PedeSecao(modo)
                    && !Perguntar(editor, "\r\nSeção=", SecaoECorDasConexoes.SecaoPadrao, out secao))
                {
                    resultado.Cancelado = true;
                    return resultado;
                }

                if (SecaoECorDasConexoes.PedeCor(modo)
                    && !Perguntar(editor, "\r\nCor=", SecaoECorDasConexoes.CorPadrao, out cor))
                {
                    resultado.Cancelado = true;
                    return resultado;
                }

                resultado.Secao = secao;
                resultado.Cor = cor;
                resultado.Potenciais = potenciais.Count;

                // handle da conexão regravada -> (cor, seção), para os textos auxiliares.
                Dictionary<string, KeyValuePair<string, string>> regravadas =
                    new Dictionary<string, KeyValuePair<string, string>>(StringComparer.OrdinalIgnoreCase);
                string usuario = Environment.UserName;
                string data = DateTime.Now.ToString();

                foreach (ObjectId id in espaco)
                {
                    Polyline polyline = transacao.GetObject(id, OpenMode.ForRead) as Polyline;
                    ConexaoXData conexao = LerConexao(polyline);
                    if (conexao == null
                        || !SecaoECorDasConexoes.EhCondutor(conexao.Tipo)
                        || !potenciais.Contains(conexao.Potencial))
                    {
                        continue;
                    }

                    SecaoECorDasConexoes.Aplicar(conexao, modo, secao, cor);
                    polyline.UpgradeOpen();
                    polyline.XData = XDataNeutro.ParaResultBuffer(conexao.ParaValores(usuario, data));
                    regravadas[polyline.Handle.ToString()] = new KeyValuePair<string, string>(conexao.Cor, conexao.Secao);
                    resultado.Conexoes++;
                }

                foreach (ObjectId id in espaco)
                {
                    DBText texto = transacao.GetObject(id, OpenMode.ForRead) as DBText;
                    ResultBuffer xdata = texto == null ? null : texto.GetXDataForApplication(AuxConexaoXData.AppName);
                    short tipo;
                    int potencial;
                    string handle;
                    if (xdata == null
                        || !AuxConexaoXData.Ler(XDataNeutro.Para(xdata), out tipo, out potencial, out handle)
                        || (tipo != 4 && tipo != 5 && tipo != 6)
                        || !potenciais.Contains(potencial))
                    {
                        continue;
                    }

                    KeyValuePair<string, string> valores;
                    if (!regravadas.TryGetValue(handle, out valores))
                    {
                        continue;
                    }

                    texto.UpgradeOpen();
                    texto.TextString = SecaoECorDasConexoes.TextoDoAuxiliar(tipo, valores.Key, valores.Value);
                    resultado.Textos++;
                }

                transacao.Commit();
            }

            return resultado;
        }

        /// <summary>
        /// A seleção do <c>EDCON</c>: só <c>LWPOLYLINE</c> com XData <c>CONEXAO</c> (o filtro do
        /// original), prompt "Selecione as conexões a serem editadas" (mMensagem 716);
        /// <c>null</c> quando cancelada.
        /// </summary>
        private static List<int> PotenciaisDaSelecao(Editor editor, Transaction transacao)
        {
            SelectionFilter filtro = new SelectionFilter(new[]
            {
                new TypedValue(0, "LWPOLYLINE"),
                new TypedValue(1001, ConexaoXData.AppName),
            });
            PromptSelectionOptions opcoes = new PromptSelectionOptions();
            opcoes.MessageForAdding = "Selecione as conexões a serem editadas";
            PromptSelectionResult selecao = editor.GetSelection(opcoes, filtro);
            if (selecao.Status != PromptStatus.OK)
            {
                return null;
            }

            List<ConexaoXData> selecionadas = new List<ConexaoXData>();
            foreach (ObjectId id in selecao.Value.GetObjectIds())
            {
                ConexaoXData conexao = LerConexao(transacao.GetObject(id, OpenMode.ForRead) as Polyline);
                if (conexao != null)
                {
                    selecionadas.Add(conexao);
                }
            }

            return SecaoECorDasConexoes.PotenciaisDaSelecao(selecionadas);
        }

        private static IEnumerable<KeyValuePair<string, ConexaoXData>> ConexoesPorLayer(
            BlockTableRecord espaco, Transaction transacao)
        {
            List<KeyValuePair<string, ConexaoXData>> conexoes = new List<KeyValuePair<string, ConexaoXData>>();
            foreach (ObjectId id in espaco)
            {
                Polyline polyline = transacao.GetObject(id, OpenMode.ForRead) as Polyline;
                ConexaoXData conexao = LerConexao(polyline);
                if (conexao != null)
                {
                    conexoes.Add(new KeyValuePair<string, ConexaoXData>(polyline.Layer, conexao));
                }
            }

            return conexoes;
        }

        private static ConexaoXData LerConexao(Polyline polyline)
        {
            ResultBuffer xdata = polyline == null ? null : polyline.GetXDataForApplication(ConexaoXData.AppName);
            ConexaoXData conexao;
            return xdata != null && ConexaoXData.Ler(XDataNeutro.Para(xdata), out conexao) ? conexao : null;
        }

        /// <summary>O <c>GetString</c> do original: sem espaços, com o valor ativo como padrão.</summary>
        private static bool Perguntar(Editor editor, string mensagem, string padrao, out string valor)
        {
            PromptStringOptions opcoes = new PromptStringOptions(mensagem);
            opcoes.AllowSpaces = false;
            opcoes.DefaultValue = padrao;
            opcoes.UseDefaultValue = true;
            PromptResult resposta = editor.GetString(opcoes);
            valor = resposta.Status == PromptStatus.OK ? resposta.StringResult : string.Empty;
            return resposta.Status == PromptStatus.OK;
        }
    }
}
