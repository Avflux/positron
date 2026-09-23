using System;
using System.Collections.Generic;
using Positron.Data;
using Positron.Data.Correcoes;
using Positron.Data.Fiacao;
using Positron.Data.Modelos;
using Positron.Plugin.Modelos;
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
    /// <c>CorrigeBlocosContatosAux</c> — o <c>Correcao.cs</c> que reescreve os
    /// terminais (<c>T1</c>, <c>T2</c>, <c>T3</c>) dos blocos **auxiliares** (os de
    /// Dispositivo tipo <c>"A"</c>) com o que diz o contato do dicionário
    /// <c>CONTATOS</c> (frente 2 do §7.6).
    ///
    /// O bloco casa pelo par <c>IndexModelo</c>/<c>IndexContato</c> do XData do modelo;
    /// a regra de cada atributo é pura (<see cref="TerminaisDoContato.ValorDoAtributo"/>).
    /// Como no original, o par <c>iContatoNovo</c> que ele calcula **não é usado** e o
    /// comando não mexe no XData (o <c>atualizaXdata</c> fica no padrão 0).
    /// </summary>
    internal static class BlocosContatosAuxDoDesenho
    {
        internal sealed class Resultado
        {
            internal int Modelos { get; set; }

            internal int Contatos { get; set; }

            /// <summary>Blocos de Dispositivo tipo <c>"A"</c> varridos.</summary>
            internal int BlocosLidos { get; set; }

            /// <summary>Blocos casados com um contato do dicionário.</summary>
            internal int BlocosCasados { get; set; }

            /// <summary>Atributos <c>T1</c>/<c>T2</c>/<c>T3</c> regravados.</summary>
            internal int AtributosAlterados { get; set; }
        }

        internal static Resultado Executar()
        {
            Resultado resultado = new Resultado();

            List<ModeloContato> modelos = ContatosDoDesenho.LerModelos();
            resultado.Modelos = modelos.Count;

            Dictionary<int, List<ContatoAuxiliar>> contatosPorModelo =
                new Dictionary<int, List<ContatoAuxiliar>>();
            foreach (ModeloContato modelo in modelos)
            {
                List<ContatoAuxiliar> contatos = ContatosDoDesenho.LerAuxiliares(modelo.Indice);
                contatosPorModelo[modelo.Indice] = contatos;
                resultado.Contatos += contatos.Count;
            }

            if (resultado.Contatos == 0)
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

                    int indexModelo;
                    int indexContato;
                    if (!LerAuxiliar(bloco, out indexModelo, out indexContato))
                    {
                        continue;
                    }

                    resultado.BlocosLidos++;

                    List<ContatoAuxiliar> contatos;
                    if (!contatosPorModelo.TryGetValue(indexModelo, out contatos))
                    {
                        continue;
                    }

                    ContatoAuxiliar contato = TerminaisDoContato.BuscarContato(contatos, indexContato);
                    if (contato == null)
                    {
                        continue;
                    }

                    resultado.BlocosCasados++;
                    Aplicar(bloco, transacao, contato, resultado);
                }

                transacao.Commit();
            }

            return resultado;
        }

        /// <summary>
        /// O <c>LeXDataQualquerDispositivo</c> para um bloco **auxiliar**: o XData
        /// <c>Dispositivo</c> com o tipo <c>"A"</c> no valor 1, o <c>IndexModelo</c> no
        /// **5** e o <c>IndexContato</c> no **6** (medido no desenho real: os blocos
        /// auxiliares não têm o XData <c>Modelo</c> — o par vem daqui).
        /// </summary>
        private static bool LerAuxiliar(BlockReference bloco, out int indexModelo, out int indexContato)
        {
            indexModelo = 0;
            indexContato = 0;

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
            if (!string.Equals(tipo ?? string.Empty, "A", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            indexModelo = XDataNumero.Inteiro(valores[5].Valor);
            indexContato = XDataNumero.Inteiro(valores[6].Valor);
            return true;
        }

        private static void Aplicar(
            BlockReference bloco,
            Transaction transacao,
            ContatoAuxiliar contato,
            Resultado resultado)
        {
            string tipoDoBloco = TerminaisDoContato.TipoDoBloco(bloco.Name);

            foreach (ObjectId id in bloco.AttributeCollection)
            {
                AttributeReference atributo = transacao.GetObject(id, OpenMode.ForRead) as AttributeReference;
                if (atributo == null)
                {
                    continue;
                }

                string valor = TerminaisDoContato.ValorDoAtributo(
                    atributo.Tag, contato.Tipo, tipoDoBloco, contato.T1, contato.T2, contato.T3);
                if (string.Equals(valor, TerminaisDoContato.NaoMexer, StringComparison.Ordinal))
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
