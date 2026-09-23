using System;
using System.Collections.Generic;
using Positron.Data;
using Positron.Data.Correcoes;
using Positron.Data.Fiacao;
using Positron.Data.Modelos;
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
    /// <c>corrigePortas</c> — o <c>EditaTodasPortas</c> do <c>clsPortas.cs</c>: reescreve
    /// os atributos dos blocos de **porta** (Dispositivo tipo <c>E</c>) com o que diz o
    /// dicionário <c>MASCARAS</c> (frente 2 do §7.6).
    ///
    /// A regra é pura (<see cref="CorrecaoDasPortas"/>): o bloco casa pelo par
    /// <c>indiceDoModelo</c>/<c>indiceDaPorta</c> e cada atributo recebe o terminal, o
    /// borne (sem o <c>*</c>), a régua (com a visibilidade decidida pela marca) ou o
    /// <c>EFC</c>.
    ///
    /// **Fora deste recorte, documentado:** as tags <c>NOME1</c> e <c>ORIGEM</c> (faltam
    /// os dois <c>Busca*</c> do original — o nome da máscara pelo handle e a página do
    /// texto da definição) e o <c>IndefineUmaPorta</c> que o original roda na porta que
    /// **não** está no dicionário (a porta fica como está e é contada).
    /// </summary>
    internal static class PortasDoModeloDoDesenho
    {
        /// <summary>O caracter de terminal indefinido (`Conf.CaracterTerminalIndefinido`, padrão `?`).</summary>
        private const string VerificadorTerminalIndefinido = "?";

        private const string DicionarioMascaras = "MASCARAS";

        internal sealed class Resultado
        {
            internal int Portas { get; set; }

            /// <summary>Blocos de porta (Dispositivo tipo <c>E</c>) lidos.</summary>
            internal int BlocosLidos { get; set; }

            /// <summary>Blocos casados com uma porta do dicionário.</summary>
            internal int Casados { get; set; }

            /// <summary>Portas que não estão no dicionário (o <c>IndefineUmaPorta</c> fica fora).</summary>
            internal int SemPorta { get; set; }

            internal int AtributosAlterados { get; set; }

            internal int VisibilidadesAlteradas { get; set; }
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
            List<ModeloPorta> portas = LerPortasDoDicionario(banco);
            resultado.Portas = portas.Count;
            if (portas.Count == 0)
            {
                return resultado;
            }

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

                    int indiceModelo;
                    int indiceDaPorta;
                    if (!LerPorta(bloco, out indiceModelo, out indiceDaPorta))
                    {
                        continue;
                    }

                    resultado.BlocosLidos++;
                    if (indiceDaPorta == 0)
                    {
                        continue;
                    }

                    ModeloPorta porta = Buscar(portas, indiceModelo, indiceDaPorta);
                    if (porta == null)
                    {
                        resultado.SemPorta++;
                        continue;
                    }

                    resultado.Casados++;
                    Aplicar(bloco, transacao, porta, resultado);
                }

                transacao.Commit();
            }

            return resultado;
        }

        /// <summary>As portas de todos os modelos do dicionário <c>MASCARAS</c>.</summary>
        private static List<ModeloPorta> LerPortasDoDicionario(Database banco)
        {
            List<ModeloPorta> portas = new List<ModeloPorta>();

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                DBDictionary raiz = transacao.GetObject(
                    banco.NamedObjectsDictionaryId, OpenMode.ForRead) as DBDictionary;
                if (raiz == null || !raiz.Contains(DicionarioMascaras))
                {
                    transacao.Commit();
                    return portas;
                }

                DBDictionary mascaras = transacao.GetObject(
                    raiz.GetAt(DicionarioMascaras), OpenMode.ForRead) as DBDictionary;
                if (mascaras == null || !mascaras.Contains("MODELOS2"))
                {
                    transacao.Commit();
                    return portas;
                }

                Xrecord registro = transacao.GetObject(
                    mascaras.GetAt("MODELOS2"), OpenMode.ForRead) as Xrecord;
                List<ModeloMascara> modelos = registro == null
                    ? new List<ModeloMascara>()
                    : ModelosMascara.LerModelos(XDataNeutro.Para(registro));

                foreach (ModeloMascara modelo in modelos)
                {
                    string chave = modelo.Indice.ToString();
                    if (!mascaras.Contains(chave))
                    {
                        continue;
                    }

                    Xrecord doModelo = transacao.GetObject(
                        mascaras.GetAt(chave), OpenMode.ForRead) as Xrecord;
                    if (doModelo == null)
                    {
                        continue;
                    }

                    portas.AddRange(ModelosMascara.LerPortas(
                        XDataNeutro.Para(doModelo), modelo.Indice, modelo.Nome));
                }

                transacao.Commit();
            }

            return portas;
        }

        private static ModeloPorta Buscar(List<ModeloPorta> portas, int indiceModelo, int indiceDaPorta)
        {
            foreach (ModeloPorta porta in portas)
            {
                if (porta.IndiceModelo == indiceModelo && porta.IndiceDaPorta == indiceDaPorta)
                {
                    return porta;
                }
            }

            return null;
        }

        /// <summary>O <c>verificaTipoDispositivo == "E"</c> e o par do XData Dispositivo (5 e 6).</summary>
        private static bool LerPorta(BlockReference bloco, out int indiceModelo, out int indiceDaPorta)
        {
            indiceModelo = 0;
            indiceDaPorta = 0;

            ResultBuffer xdata = bloco.GetXDataForApplication(DispositivoXData.AppName);
            if (xdata == null)
            {
                return false;
            }

            IReadOnlyList<TypedXData> valores = XDataNeutro.Para(xdata);
            if (valores.Count < 7)
            {
                return false;
            }

            string tipo = valores[1].Valor as string;
            if (!string.Equals(tipo ?? string.Empty, "E", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            indiceModelo = XDataNumero.Inteiro(valores[5].Valor);
            indiceDaPorta = XDataNumero.Inteiro(valores[6].Valor);
            return true;
        }

        private static void Aplicar(
            BlockReference bloco,
            Transaction transacao,
            ModeloPorta porta,
            Resultado resultado)
        {
            BornesDaPorta bornes = CorrecaoDasPortas.SepararBornes(porta.Bornes);
            string[] terminais = (porta.Terminais ?? string.Empty).Split(';');

            foreach (ObjectId id in bloco.AttributeCollection)
            {
                AttributeReference atributo = transacao.GetObject(id, OpenMode.ForRead) as AttributeReference;
                if (atributo == null)
                {
                    continue;
                }

                bool? visivel;
                string valor = CorrecaoDasPortas.ValorDoAtributo(
                    atributo.Tag, terminais, bornes, porta.Regua, porta.EFC,
                    VerificadorTerminalIndefinido, out visivel);

                bool mudaTexto = !string.Equals(valor, CorrecaoDasPortas.NaoMexer, StringComparison.Ordinal)
                    && !string.Equals(atributo.TextString ?? string.Empty, valor, StringComparison.Ordinal);
                bool mudaVisivel = visivel.HasValue && atributo.Visible != visivel.Value;
                if (!mudaTexto && !mudaVisivel)
                {
                    continue;
                }

                atributo.UpgradeOpen();
                if (mudaTexto)
                {
                    atributo.TextString = valor;
                    resultado.AtributosAlterados++;
                }

                if (mudaVisivel)
                {
                    atributo.Visible = visivel.Value;
                    resultado.VisibilidadesAlteradas++;
                }
            }
        }
    }
}
