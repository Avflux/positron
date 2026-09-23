using System;
using System.Collections.Generic;
using Positron.Data;
using Positron.Data.Bornes;
using Positron.Data.Configuracao;
using Positron.Data.Correcoes;
using Positron.Plugin.Bornes;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Correcoes
{
    /// <summary>
    /// <c>CorrigePainelET1DosBornes</c> — escreve os atributos do bloco do **borne**
    /// (Dispositivo tipo <c>B</c>) com o painel e a régua resolvidos no dicionário
    /// <c>REGUAS</c> (o <c>BuscaPainelDoBorneNoDicionario</c> do original) e o nome do
    /// painel pelo cadastro (<c>Dicionario.BuscaNomeDoPainel</c>), frente 2 do §7.6.
    ///
    /// A regra de cada atributo é pura (<see cref="CorrecaoPainelDoBorne"/>), com a
    /// sentinela <c>"OK"</c> do original.
    /// </summary>
    internal static class PainelDoBorneDoDesenho
    {
        /// <summary>O caracter de terminal indefinido (`Conf.CaracterTerminalIndefinido`, padrão `?`).</summary>
        private const string VerificadorTerminalIndefinido = "?";

        internal sealed class Resultado
        {
            internal bool SemBanco { get; set; }

            /// <summary>Réguas lidas do dicionário do desenho.</summary>
            internal int Reguas { get; set; }

            /// <summary>Bornes (Dispositivo tipo <c>B</c>) lidos.</summary>
            internal int BornesLidos { get; set; }

            /// <summary>Bornes com a régua resolvida no dicionário.</summary>
            internal int ReguasResolvidas { get; set; }

            /// <summary>Atributos regravados.</summary>
            internal int AtributosAlterados { get; set; }
        }

        internal static Resultado Executar()
        {
            Resultado resultado = new Resultado();

            ConfiguracaoPositron config = ConfiguracaoPositron.Carregar();
            if (string.IsNullOrEmpty(config.Banco))
            {
                resultado.SemBanco = true;
                return resultado;
            }

            ProjectStore store = new ProjectStore(config.Banco);
            IReadOnlyDictionary<int, string> nomesDePaineis = store.LerNomesDePaineis();

            ReguasModelo reguas = ReguasDoDesenho.Ler();
            resultado.Reguas = reguas.Reguas.Count;

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

                foreach (ObjectId id in espaco)
                {
                    BlockReference bloco = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
                    if (bloco == null)
                    {
                        continue;
                    }

                    BorneXData borne;
                    if (!LerBorne(bloco, out borne))
                    {
                        continue;
                    }

                    resultado.BornesLidos++;

                    ReguaInfo regua = reguas.Buscar(borne.IndiceRegua);
                    if (regua == null)
                    {
                        continue;
                    }

                    resultado.ReguasResolvidas++;

                    string nomePainel;
                    if (!nomesDePaineis.TryGetValue(regua.Painel, out nomePainel))
                    {
                        continue;
                    }

                    Aplicar(transacao, bloco, borne, regua, nomePainel, config, resultado);
                }

                transacao.Commit();
            }

            return resultado;
        }

        private static bool LerBorne(BlockReference bloco, out BorneXData borne)
        {
            borne = null;
            ResultBuffer xdata = bloco.GetXDataForApplication(BorneXData.AppName)
                ?? bloco.GetXDataForApplication(BorneXData.AppNameLegado);
            return xdata != null && BorneXData.Ler(XDataNeutro.Para(xdata), out borne);
        }

        private static void Aplicar(
            Transaction transacao,
            BlockReference bloco,
            BorneXData borne,
            ReguaInfo regua,
            string nomePainel,
            ConfiguracaoPositron config,
            Resultado resultado)
        {
            foreach (ObjectId id in bloco.AttributeCollection)
            {
                AttributeReference atributo = transacao.GetObject(id, OpenMode.ForRead) as AttributeReference;
                if (atributo == null)
                {
                    continue;
                }

                string valor = CorrecaoPainelDoBorne.ValorDoAtributo(
                    atributo.Tag, nomePainel, regua.Nome, borne.Numero, borne.Visivel,
                    config.SeparadorPainelRegua, VerificadorTerminalIndefinido);

                // A sentinela `"OK"` do original: não escreve.
                if (string.Equals(valor, CorrecaoPainelDoBorne.NaoMexer, StringComparison.Ordinal))
                {
                    continue;
                }

                if (string.Equals(atributo.TextString ?? string.Empty, valor, StringComparison.Ordinal))
                {
                    continue;
                }

                atributo.UpgradeOpen();
                atributo.TextString = valor;
                resultado.AtributosAlterados++;
            }
        }
    }
}
