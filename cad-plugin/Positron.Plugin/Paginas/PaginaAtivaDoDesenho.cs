using System.Collections.Generic;
using Positron.Data.Paginas;
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
    /// A **pagina ativa** no desenho: o <c>LocalizaPaginaAtiva</c> (qual pagina a camada corrente
    /// mostra), o <c>checaCapa</c> (a capa e o seu formato) e o <c>AtivaPagina</c> do
    /// <c>Pagina.cs</c> do original — o que liga a pagina pedida e **desliga todo o resto**, com a
    /// camada corrente passando para ela.
    ///
    /// A regra e pura (<see cref="PaginaAtiva"/>); este adapter so fala com a tabela de layers.
    /// </summary>
    internal static class PaginaAtivaDoDesenho
    {
        /// <summary>O que a ativacao fez, para o resumo do comando e da grade.</summary>
        internal sealed class Resultado
        {
            /// <summary>A pagina foi achada entre os layers (e virou a camada corrente).</summary>
            internal bool PaginaEncontrada { get; set; }

            /// <summary>Quantos layers estavam com o <c>IsOff</c> diferente do que a regra pede.</summary>
            internal int LayersAlterados { get; set; }

            /// <summary>Quantos ficaram desligados (os que nao sao a pagina, o 0 nem o formato do corpo).</summary>
            internal int LayersDesligados { get; set; }

            /// <summary>Quantos ficaram ligados (a pagina, o 0 e o formato do corpo).</summary>
            internal int LayersLigados { get; set; }

            /// <summary>A capa achada na tabela (o <c>retornaNumeroCapa</c>), quando o layer existe.</summary>
            internal string Capa { get; set; }
        }

        /// <summary>A pagina ativa do desenho (o <c>LocalizaPaginaAtiva</c>); vazio quando a camada corrente nao e pagina.</summary>
        internal static string Ler()
        {
            return PaginaAtiva.Localiza(LerCamadaCorrente());
        }

        /// <summary>
        /// O nome da **camada corrente**, cru — e o que o <c>LocalizaPaginaAtiva</c> do original devolve
        /// (<c>Pagina.cs:1347</c>: ele nao checa se a camada e uma pagina). O <c>AtivaPagina</c> do
        /// original recebe esse nome como veio (o <c>IniciarDWG</c> e o <c>travaDWG</c>); a guarda do
        /// <see cref="Ler"/> e de quem pergunta pela pagina ativa do desenho.
        /// </summary>
        internal static string LerCamadaCorrente()
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return string.Empty;
            }

            string corrente = string.Empty;
            using (Transaction transacao = documento.Database.TransactionManager.StartTransaction())
            {
                LayerTableRecord layer = transacao.GetObject(documento.Database.Clayer, OpenMode.ForRead) as LayerTableRecord;
                if (layer != null)
                {
                    corrente = layer.Name;
                }

                transacao.Commit();
            }

            return corrente;
        }

        /// <summary>A capa da tabela de layers (o <c>retornaNumeroCapa</c>); vazia quando nao ha.</summary>
        internal static string LerCapa()
        {
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return string.Empty;
            }

            string capa = string.Empty;
            using (Transaction transacao = documento.Database.TransactionManager.StartTransaction())
            {
                LayerTable camadas = (LayerTable)transacao.GetObject(documento.Database.LayerTableId, OpenMode.ForRead);
                foreach (ObjectId id in camadas)
                {
                    LayerTableRecord layer = transacao.GetObject(id, OpenMode.ForRead) as LayerTableRecord;
                    if (layer != null && PaginaAtiva.ChecaCapa(layer.Name))
                    {
                        capa = layer.Name;
                        break;
                    }
                }

                transacao.Commit();
            }

            return capa;
        }

        /// <summary>
        /// Ativa a pagina: liga a pagina pedida (que passa a ser a camada corrente), mantem o
        /// layer <c>0</c> e o formato do corpo (<c>-1</c>, fora da capa) ligados e **desliga os
        /// demais** — a capa inclusive.
        /// </summary>
        internal static Resultado Ativar(string pagina)
        {
            Resultado resultado = new Resultado();
            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return resultado;
            }

            string alvo = (pagina ?? string.Empty).Trim();
            using (Transaction transacao = documento.Database.TransactionManager.StartTransaction())
            {
                LayerTable camadas = (LayerTable)transacao.GetObject(documento.Database.LayerTableId, OpenMode.ForRead);
                foreach (ObjectId id in camadas)
                {
                    LayerTableRecord layer = transacao.GetObject(id, OpenMode.ForRead) as LayerTableRecord;
                    if (layer == null)
                    {
                        continue;
                    }

                    PapelDoLayerNaAtivacao papel = PaginaAtiva.Papel(layer.Name, alvo);
                    if (papel == PapelDoLayerNaAtivacao.Pagina)
                    {
                        resultado.PaginaEncontrada = true;
                    }

                    if (resultado.Capa == null && PaginaAtiva.ChecaCapa(layer.Name))
                    {
                        resultado.Capa = layer.Name;
                    }

                    bool desligar = papel == PapelDoLayerNaAtivacao.Fora;
                    if (layer.IsOff != desligar)
                    {
                        layer.UpgradeOpen();
                        layer.IsOff = desligar;
                        resultado.LayersAlterados++;
                    }

                    if (desligar)
                    {
                        resultado.LayersDesligados++;
                    }
                    else
                    {
                        resultado.LayersLigados++;
                    }
                }

                if (resultado.PaginaEncontrada && camadas.Has(alvo))
                {
                    // A camada corrente acompanha a pagina (o `Database.Clayer` do original): e o
                    // que este comando, e so ele, muda no desenho.
                    documento.Database.Clayer = camadas[alvo];
                }

                transacao.Commit();
            }

            return resultado;
        }
    }
}
