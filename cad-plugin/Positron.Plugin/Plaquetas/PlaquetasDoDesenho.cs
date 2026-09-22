using System;
using System.Collections;
using System.Collections.Generic;
using Positron.Data.Bornes;
using Positron.Data.Fiacao;
using Positron.Data.Plaquetas;
using Positron.Plugin.Fiacao;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Plaquetas
{
    /// <summary>
    /// A parte do <c>EPLQ</c> que toca a API do CAD: o dicionário de plaquetas do
    /// desenho (<c>CENG_PLAQUETA</c>), o mapa <c>handle → nome</c> dos dispositivos
    /// <c>M</c>/<c>P</c> por painel e os painéis com fiação. O resto é puro
    /// (<see cref="Plaquetas4Gerador"/>).
    ///
    /// O dicionário é o mesmo caminho do <c>DicionarioPlaqueta</c> do original:
    /// <c>NamedObjectsDictionary → "CENG_PLAQUETA" → Xrecord por painel</c>.
    /// </summary>
    internal static class PlaquetasDoDesenho
    {
        /// <summary>
        /// Lê o dicionário de plaquetas: <c>painel → registros</c>. Painel que não
        /// seja número é ignorado (o original usa a chave como texto do painel).
        /// </summary>
        internal static Dictionary<int, IReadOnlyList<PlaquetaDefinicao>> LerDicionario()
        {
            Dictionary<int, IReadOnlyList<PlaquetaDefinicao>> plaquetas =
                new Dictionary<int, IReadOnlyList<PlaquetaDefinicao>>();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return plaquetas;
            }

            Database banco = documento.Database;

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                DBDictionary nomeados =
                    (DBDictionary)transacao.GetObject(banco.NamedObjectsDictionaryId, OpenMode.ForRead);
                if (nomeados == null || !nomeados.Contains(PlaquetasXData.NomeDicionario))
                {
                    transacao.Commit();
                    return plaquetas;
                }

                DBDictionary porPainel =
                    (DBDictionary)transacao.GetObject(nomeados.GetAt(PlaquetasXData.NomeDicionario), OpenMode.ForRead);

                foreach (DictionaryEntry entrada in porPainel)
                {
                    int painel;
                    if (!int.TryParse(Convert.ToString(entrada.Key), out painel))
                    {
                        continue;
                    }

                    Xrecord registro = transacao.GetObject((ObjectId)entrada.Value, OpenMode.ForRead) as Xrecord;
                    if (registro == null)
                    {
                        continue;
                    }

                    plaquetas[painel] = PlaquetasXData.Ler(XDataNeutro.Para(registro));
                }

                transacao.Commit();
            }

            return plaquetas;
        }

        /// <summary>
        /// O <c>carregaNomeDispositivosPM</c> do original: por painel, o mapa
        /// <c>handle → Nome1[/Nome2]</c> dos blocos <c>M</c>/<c>P</c> (pulando os
        /// complementares). Reusa o mesmo leitor da fiação.
        /// </summary>
        internal static Dictionary<int, IReadOnlyDictionary<string, string>> NomesDeDispositivosPorPainel()
        {
            Dictionary<int, Dictionary<string, string>> porPainel =
                new Dictionary<int, Dictionary<string, string>>();

            foreach (DispositivoFiacao dispositivo in DispositivosDeFiacaoDoDesenho.Ler())
            {
                if (dispositivo.Complementar)
                {
                    continue;
                }

                if (!string.Equals(dispositivo.Tipo, DispositivoFiacaoXData.TipoMascara, StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(dispositivo.Tipo, DispositivoFiacaoXData.TipoDispositivo, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                Dictionary<string, string> doPainel;
                if (!porPainel.TryGetValue(dispositivo.Painel, out doPainel))
                {
                    doPainel = new Dictionary<string, string>();
                    porPainel[dispositivo.Painel] = doPainel;
                }

                // O original usa `.Add`; um handle repetido estouraria. Aqui o
                // último vence — dado de terceiro não derruba o comando.
                doPainel[dispositivo.Handle ?? string.Empty] = dispositivo.Tag ?? string.Empty;
            }

            Dictionary<int, IReadOnlyDictionary<string, string>> mapa =
                new Dictionary<int, IReadOnlyDictionary<string, string>>();
            foreach (KeyValuePair<int, Dictionary<string, string>> item in porPainel)
            {
                mapa[item.Key] = item.Value;
            }

            return mapa;
        }

        /// <summary>
        /// Os painéis **com fiação** do desenho — o <c>carregaEquipComFiacao</c> do
        /// original: os painéis citados pelas <c>CONEXAO</c>.
        /// </summary>
        internal static HashSet<int> PaineisComFiacao()
        {
            HashSet<int> paineis = new HashSet<int>();
            foreach (ConexaoFiacao conexao in ConexoesDoDesenho.Ler())
            {
                paineis.Add(conexao.Painel);
            }

            return paineis;
        }
    }
}
