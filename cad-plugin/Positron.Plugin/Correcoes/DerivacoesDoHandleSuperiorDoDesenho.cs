using System;
using System.Collections.Generic;
using Positron.Data;
using Positron.Data.Correcoes;
using Positron.Data.Fiacao;
using Positron.Data.Limpeza;
using Positron.Plugin.Limpeza;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;
using Polyline = Autodesk.AutoCAD.DatabaseServices.Polyline;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
using Polyline = ZwSoft.ZwCAD.DatabaseServices.Polyline;
#endif

namespace Positron.Plugin.Correcoes
{
    /// <summary>
    /// <c>CorrigeHandleSuperior</c> — o comando do <c>Correcao.cs</c> completo: primeiro
    /// **limpa** os handles das derivações (o <c>limpaHandleSuperior</c>, que o recoder já
    /// tem como <c>Limpahandle</c> na rodada 92) e depois **re-resolve** cada derivação com o
    /// <c>verificaConexao</c> — a conexão vizinha do ponto inicial (frente 2 do §7.6).
    ///
    /// A regra do resolvedor é pura (<see cref="ResolvedorDeConexao"/>); aqui se lê o
    /// desenho, se escolhe o vizinho e se gravam **três** valores do XData <c>CONEXAO</c>
    /// (o handle, o nome e o potencial) trocando só o registro do app.
    ///
    /// **Fora do recorte, documentado:** a parte de **páginas** do original
    /// (<c>AtivaTodasAsPagina</c>, <c>Pagina.AtivaPagina</c>) e o gate de hardlock.
    /// </summary>
    internal static class DerivacoesDoHandleSuperiorDoDesenho
    {
        /// <summary>Os índices (relativos ao app) dos três campos que o resolver grava.</summary>
        private const int IndiceDoPotencial = 1;

        private const int IndiceDoHandle = 2;

        private const int IndiceDoNome = 6;

        internal sealed class Resultado
        {
            internal int HandlesLimpos { get; set; }

            internal int Conexoes { get; set; }

            internal int Derivacoes { get; set; }

            internal int Resolvidas { get; set; }

            internal int Alteradas { get; set; }
        }

        private sealed class ConexaoDoDesenho
        {
            internal ObjectId Id { get; set; }

            internal string Layer { get; set; }

            internal string Handle { get; set; }

            internal ConexaoXData Conexao { get; set; }

            internal double MinX { get; set; }

            internal double MinY { get; set; }

            internal double MaxX { get; set; }

            internal double MaxY { get; set; }
        }

        internal static Resultado Executar()
        {
            Resultado resultado = new Resultado();

            // A primeira metade do comando: o `limpaHandleSuperior()`.
            resultado.HandlesLimpos = HandlesDasDerivacoesDoDesenho.Executar().HandlesLimpos;

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
                    tabela[BlockTableRecord.ModelSpace], OpenMode.ForRead);

                List<ConexaoDoDesenho> vizinhos = new List<ConexaoDoDesenho>();
                foreach (ObjectId id in espaco)
                {
                    Polyline linha = transacao.GetObject(id, OpenMode.ForRead) as Polyline;
                    if (linha == null)
                    {
                        continue;
                    }

                    ResultBuffer xdata = linha.GetXDataForApplication(ConexaoXData.AppName);
                    ConexaoXData conexao;
                    if (xdata == null || !ConexaoXData.Ler(XDataNeutro.Para(xdata), out conexao))
                    {
                        continue;
                    }

                    Extents3d? limites = ((Drawable)linha).Bounds;
                    vizinhos.Add(new ConexaoDoDesenho
                    {
                        Id = id,
                        Layer = linha.Layer,
                        Handle = linha.Handle.ToString(),
                        Conexao = conexao,
                        MinX = limites.HasValue ? limites.Value.MinPoint.X : 0.0,
                        MinY = limites.HasValue ? limites.Value.MinPoint.Y : 0.0,
                        MaxX = limites.HasValue ? limites.Value.MaxPoint.X : 0.0,
                        MaxY = limites.HasValue ? limites.Value.MaxPoint.Y : 0.0,
                    });
                }

                resultado.Conexoes = vizinhos.Count;

                foreach (ConexaoDoDesenho derivacao in vizinhos)
                {
                    if (!LimpezaDoHandleDasDerivacoes.EhDerivacao(derivacao.Conexao.Tipo))
                    {
                        continue;
                    }

                    resultado.Derivacoes++;

                    Polyline linha = transacao.GetObject(derivacao.Id, OpenMode.ForRead) as Polyline;
                    if (linha == null)
                    {
                        continue;
                    }

                    Point3d inicio = linha.StartPoint;
                    ConexaoDoDesenho alvo = null;
                    foreach (ConexaoDoDesenho candidato in vizinhos)
                    {
                        if (!ResolvedorDeConexao.JanelaToca(inicio.X, inicio.Y,
                                candidato.MinX, candidato.MinY, candidato.MaxX, candidato.MaxY))
                        {
                            continue;
                        }

                        if (!ResolvedorDeConexao.EhVizinho(candidato.Layer, derivacao.Layer,
                                candidato.Handle, derivacao.Handle))
                        {
                            continue;
                        }

                        alvo = candidato;
                        break;
                    }

                    if (alvo == null)
                    {
                        continue;
                    }

                    resultado.Resolvidas++;

                    if (!ResolvedorDeConexao.PrecisaAtualizar(
                            derivacao.Conexao.Handle, derivacao.Conexao.Nome, derivacao.Conexao.Potencial,
                            alvo.Handle, alvo.Conexao.Nome, alvo.Conexao.Potencial))
                    {
                        continue;
                    }

                    linha.UpgradeOpen();
                    linha.XData = ParaResultBuffer(TrocandoOsTres(
                        linha.XData, alvo.Handle, alvo.Conexao.Nome, alvo.Conexao.Potencial));
                    resultado.Alteradas++;
                }

                transacao.Commit();
            }

            return resultado;
        }

        /// <summary>Troca o potencial, o handle e o nome no registro <c>CONEXAO</c> do buffer.</summary>
        private static IReadOnlyList<TypedXData> TrocandoOsTres(
            ResultBuffer todos,
            string handle,
            string nome,
            int potencial)
        {
            List<TypedXData> saida = new List<TypedXData>();
            IReadOnlyList<TypedXData> valores = todos == null ? null : XDataNeutro.Para(todos);
            if (valores == null)
            {
                return saida;
            }

            int i = 0;
            while (i < valores.Count)
            {
                bool ehConexao = valores[i].Codigo == 1001 &&
                    string.Equals(valores[i].Valor as string, ConexaoXData.AppName, StringComparison.Ordinal);
                if (!ehConexao)
                {
                    saida.Add(valores[i]);
                    i++;
                    continue;
                }

                saida.Add(valores[i]);
                i++;
                int k = 0;
                while (i < valores.Count && valores[i].Codigo != 1001)
                {
                    if (k == IndiceDoHandle)
                    {
                        saida.Add(new TypedXData(valores[i].Codigo, handle));
                    }
                    else if (k == IndiceDoNome)
                    {
                        saida.Add(new TypedXData(valores[i].Codigo, nome ?? string.Empty));
                    }
                    else if (k == IndiceDoPotencial)
                    {
                        saida.Add(new TypedXData(valores[i].Codigo, potencial));
                    }
                    else
                    {
                        saida.Add(valores[i]);
                    }

                    k++;
                    i++;
                }
            }

            return saida;
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
