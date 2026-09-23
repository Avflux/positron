using System;
using System.Collections.Generic;
using Positron.Contract;
using Positron.Data;
using Positron.Data.Configuracao;
using Positron.Data.Fiacao;
using Positron.Data.Interligacao;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Interligacao
{
    /// <summary>
    /// <c>AtualizaOpcionaisDoCabo</c> — reescreve o texto dos rótulos auxiliares dos
    /// tipos **3, 4, 5 e 6** a partir da **receita** de opcionais do XData
    /// <c>AUXINTERLIG</c> (frente 2 do §7.6, o <c>clsUtilitarios.cs</c>).
    ///
    /// O que é regra está em <see cref="OpcionaisDoCabo"/> (os tokens e a normalização);
    /// aqui se varre o ModelSpace, se resolve o trecho pelo handle do rótulo e se
    /// regrava o texto — só quando ele muda.
    ///
    /// **Fora do recorte, documentado:** o <c>clsEditarInterligacao.AtualizaNomesDosCabos</c>
    /// do fim do original e a barra de progresso (<c>_uscPagina</c>).
    /// </summary>
    internal static class OpcionaisDoCaboDoDesenho
    {
        internal sealed class Resultado
        {
            internal bool SemBanco { get; set; }

            /// <summary>Rótulos com XData <c>AUXINTERLIG</c> lidos.</summary>
            internal int Lidos { get; set; }

            /// <summary>Rótulos dos tipos 3..6 (os que a atualização olha).</summary>
            internal int Rotulos { get; set; }

            /// <summary>Rótulos cujo texto foi regravado.</summary>
            internal int Alterados { get; set; }

            /// <summary>Rótulos cujo trecho não foi resolvido pelo handle (ficam como estão).</summary>
            internal int SemTrecho { get; set; }
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
            IReadOnlyList<CabosRow> cabos = store.LerCabos();
            IReadOnlyList<VeiasRow> veias = store.LerVeias();

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
                    DBText texto = transacao.GetObject(id, OpenMode.ForRead) as DBText;
                    if (texto == null)
                    {
                        continue;
                    }

                    ResultBuffer xdata = texto.GetXDataForApplication(AuxInterligacaoXData.AppName);
                    short tipo;
                    string handle;
                    string opcionais;
                    if (xdata == null ||
                        !AuxInterligacaoXData.Ler(XDataNeutro.Para(xdata), out tipo, out handle, out opcionais))
                    {
                        continue;
                    }

                    resultado.Lidos++;

                    // O `AtualizaOpcionaisDoCabo` só olha os tipos 3..6 (o tipo 1 é do
                    // `RecriaTextosCabo`; o 2, o rótulo de ponta).
                    if (tipo != 3 && tipo != 4 && tipo != 5 && tipo != 6)
                    {
                        continue;
                    }

                    resultado.Rotulos++;

                    InterligacaoXData ilig;
                    if (!LerTrecho(transacao, banco, handle, out ilig))
                    {
                        resultado.SemTrecho++;
                        continue;
                    }

                    ContextoOpcionais contexto = new ContextoOpcionais
                    {
                        TagCabo = ilig.Tag_Cabo,
                        NumVeia = ilig.NumVeia,
                        NomeVeia = ilig.NomeVeia,
                        NomeDaVeia = OpcionaisDoCabo.BuscarNomeDaVeia(veias, ilig.Tag_Cabo, ilig.NumVeia),
                        FuncaoDaVeia = OpcionaisDoCabo.BuscarFuncaoDaVeia(veias, ilig.Tag_Cabo, ilig.NumVeia),
                        Formacao = OpcionaisDoCabo.BuscarFormacao(cabos, ilig.Tag_Cabo),
                    };

                    string novo = OpcionaisDoCabo.Expandir(opcionais, contexto, VerificadorTerminalIndefinido);
                    if (string.Equals(texto.TextString ?? string.Empty, novo, StringComparison.Ordinal))
                    {
                        continue;
                    }

                    texto.UpgradeOpen();
                    texto.TextString = novo;
                    resultado.Alterados++;
                }

                transacao.Commit();
            }

            return resultado;
        }

        /// <summary>O caracter de terminal indefinido (`Conf.CaracterTerminalIndefinido`, padrão `?`).</summary>
        private const string VerificadorTerminalIndefinido = "?";

        /// <summary>Resolve o trecho pelo handle que o rótulo guarda (hexadecimal, como no `ResolverPainel`).</summary>
        private static bool LerTrecho(
            Transaction transacao,
            Database banco,
            string handle,
            out InterligacaoXData ilig)
        {
            ilig = null;
            if (string.IsNullOrEmpty(handle))
            {
                return false;
            }

            ObjectId id;
            try
            {
                if (!banco.TryGetObjectId(new Handle(Convert.ToInt64(handle, 16)), out id))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            Entity trecho = transacao.GetObject(id, OpenMode.ForRead) as Entity;
            if (trecho == null)
            {
                return false;
            }

            ResultBuffer xdata = trecho.GetXDataForApplication(InterligacaoXData.AppName);
            return xdata != null && InterligacaoXData.Ler(XDataNeutro.Para(xdata), out ilig);
        }
    }
}
