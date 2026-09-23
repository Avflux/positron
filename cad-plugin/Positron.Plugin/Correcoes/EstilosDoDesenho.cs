using System.Collections.Generic;
using Positron.Data.Correcoes;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.GraphicsInterface;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.GraphicsInterface;
#endif

namespace Positron.Plugin.Correcoes
{
    /// <summary>
    /// <c>CorrigeStyle</c> — o <c>corrigeStyles</c> do <c>Correcao.cs</c>:
    /// corrige os **estilos de texto** do desenho que estão sem fonte
    /// (<c>FileName == ""</c>) ou com escala horizontal zero (<c>XScale == 0</c>),
    /// copiando da referência <c>arial.ttf</c> — ou, sem ela, do **último** estilo
    /// da tabela, como o original.
    ///
    /// A decisão é pura (<see cref="CorrecaoEstiloTexto"/>); aqui varre-se a
    /// <c>TextStyleTable</c> e grava-se. A confirmação do original (um
    /// <c>MsgBox</c> Sim/Não, que travaria o script) sai: o comando existe para
    /// corrigir, então ele corrige e o resumo lista os estilos com problema.
    /// </summary>
    internal static class EstilosDoDesenho
    {
        internal sealed class Resultado
        {
            /// <summary>Estilos de texto da tabela do desenho.</summary>
            internal int EstilosLidos { get; set; }

            /// <summary>Estilos com problema (sem fonte ou com escala 0).</summary>
            internal int EstilosComProblema { get; set; }

            /// <summary>Estilos abertos e regravados.</summary>
            internal int EstilosCorrigidos { get; set; }

            /// <summary>A referência é um <c>arial.ttf</c> de fato?</summary>
            internal bool TemReferenciaArial { get; set; }

            /// <summary>Nome do estilo usado como referência.</summary>
            internal string EstiloReferencia { get; set; }

            /// <summary>Nomes dos estilos com problema (a lista do aviso do original).</summary>
            internal List<string> Problemas { get; private set; }

            internal Resultado()
            {
                Problemas = new List<string>();
            }
        }

        internal static Resultado Executar()
        {
            Resultado resultado = new Resultado();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return resultado;
            }

            Database banco = documento.Database;

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                TextStyleTable tabela =
                    transacao.GetObject(banco.TextStyleTableId, OpenMode.ForRead) as TextStyleTable;
                if (tabela == null)
                {
                    transacao.Commit();
                    return resultado;
                }

                // A ordem da tabela importa: é ela que decide a referência quando
                // não há arial.ttf (o original usa o último estilo enumerado).
                List<TextStyleTableRecord> registros = new List<TextStyleTableRecord>();
                List<EstiloTexto> estilos = new List<EstiloTexto>();
                foreach (ObjectId id in tabela)
                {
                    TextStyleTableRecord registro =
                        transacao.GetObject(id, OpenMode.ForRead) as TextStyleTableRecord;
                    if (registro == null)
                    {
                        continue;
                    }

                    registros.Add(registro);
                    estilos.Add(new EstiloTexto
                    {
                        Nome = registro.Name,
                        ArquivoFonte = registro.FileName,
                        EscalaX = registro.XScale,
                        Altura = registro.TextSize,
                    });
                }

                resultado.EstilosLidos = estilos.Count;

                PlanoDeEstilos plano = CorrecaoEstiloTexto.Planejar(estilos);
                resultado.EstilosComProblema = plano.Problemas.Count;
                resultado.Problemas.AddRange(plano.Problemas);

                // Sem problema o original não abre transação de escrita nenhuma.
                if (plano.Problemas.Count > 0)
                {
                    EstiloTexto referencia = estilos[plano.IndiceReferencia];
                    resultado.TemReferenciaArial = plano.TemReferenciaArial;
                    resultado.EstiloReferencia = referencia.Nome;

                    // A fonte de referência é lida **antes** do laço: se a própria
                    // referência for corrigida depois, o valor copiado já foi colhido.
                    FontDescriptor fonteReferencia = registros[plano.IndiceReferencia].Font;

                    foreach (CorrecaoDeEstilo correcao in plano.Correcoes)
                    {
                        TextStyleTableRecord alvo = registros[correcao.Indice];
                        alvo.UpgradeOpen();

                        if (correcao.CopiarFonte)
                        {
                            alvo.Font = fonteReferencia;

                            // O original só copia o descritor `Font`, e no ZWCAD isso
                            // **não** regrava o arquivo da fonte: o `FileName` continua
                            // vazio e o comando reporta o mesmo problema em toda
                            // passada (medido na rodada 73). Regravar o arquivo junto é
                            // o que faz a correção de fato sair.
                            if (!string.IsNullOrEmpty(correcao.ArquivoFonte))
                            {
                                alvo.FileName = correcao.ArquivoFonte;
                            }
                        }

                        if (correcao.AjustarEscala)
                        {
                            alvo.XScale = correcao.EscalaX;
                        }

                        if (correcao.AjustarAltura)
                        {
                            alvo.TextSize = correcao.Altura;
                        }

                        resultado.EstilosCorrigidos++;
                    }
                }

                transacao.Commit();
            }

            return resultado;
        }
    }
}
