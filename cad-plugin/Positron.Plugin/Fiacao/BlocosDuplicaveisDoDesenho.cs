using System;
using System.Collections.Generic;
using System.Globalization;
using Positron.Data;
using Positron.Data.Bornes;
using Positron.Data.Fiacao;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Fiacao
{
    /// <summary>
    /// Varre o ModelSpace numa **passada só** e devolve os blocos com os campos de
    /// identidade que a checagem de duplicados usa (<see cref="BlocoDuplicavel"/>) —
    /// o <c>clsBlocos.VerificaDuplicados</c> do original.
    ///
    /// A ordem da varredura é a do ModelSpace, como no original: é dela que depende
    /// qual dos blocos repetidos vira o apontamento e, no auxiliar, o painel do
    /// filtro (o original reaproveita o <c>indexPainel</c> do último borne).
    ///
    /// Por tipo:
    /// - <c>M</c>/<c>P</c>: a própria identidade do XData;
    /// - <c>E</c>: identidade da **máscara** apontada por <c>array[4]</c> + o
    ///   <c>indiceDaPorta</c> do próprio bloco;
    /// - <c>A</c>: identidade do **bob** apontado por <c>array[4]</c> + o
    ///   <c>IndexContato</c> (<c>array[6]</c>);
    /// - <c>B</c>: régua/número do XData do borne e o painel resolvido pelo
    ///   dicionário de réguas (<see cref="ReguasModelo"/>) — o mesmo caminho do
    ///   <c>BuscaPainelDoBorneNoDicionario</c>;
    /// - texto de **definição** (<c>DBText</c> com XData <c>Definicao</c>): a
    ///   máscara, o modelo e a porta gravados no próprio texto.
    /// </summary>
    public static class BlocosDuplicaveisDoDesenho
    {
        public static IReadOnlyList<BlocoDuplicavel> Ler(ReguasModelo reguas)
        {
            List<BlocoDuplicavel> blocos = new List<BlocoDuplicavel>();

            Document documento = Application.DocumentManager.MdiActiveDocument;
            if (documento == null)
            {
                return blocos;
            }

            Database banco = documento.Database;
            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
                BlockTableRecord espaco = (BlockTableRecord)transacao.GetObject(
                    tabela[BlockTableRecord.ModelSpace],
                    OpenMode.ForRead);

                foreach (ObjectId id in espaco)
                {
                    DBObject objeto = transacao.GetObject(id, OpenMode.ForRead);

                    BlockReference bloco = objeto as BlockReference;
                    if (bloco != null)
                    {
                        LerBloco(banco, transacao, bloco, reguas, blocos);
                        continue;
                    }

                    DBText texto = objeto as DBText;
                    if (texto != null)
                    {
                        LerDefinicao(banco, transacao, texto, blocos);
                    }
                }

                transacao.Commit();
            }

            return blocos;
        }

        private static void LerBloco(
            Database banco, Transaction transacao, BlockReference bloco, ReguasModelo reguas, List<BlocoDuplicavel> saida)
        {
            IReadOnlyList<TypedXData> valores = LerXData(bloco);
            if (valores == null || valores.Count < 2)
            {
                return;
            }

            string tipo = Texto(valores[1].Valor);
            if (string.IsNullOrEmpty(tipo))
            {
                return;
            }

            tipo = tipo.Trim().ToUpperInvariant();
            string pagina = bloco.Layer;
            string handle = bloco.Handle.ToString();

            switch (tipo)
            {
                case "M":
                case "P":
                {
                    DispositivoFiacao dispositivo;
                    if (!DispositivoFiacaoXData.Ler(valores, out dispositivo))
                    {
                        return;
                    }

                    saida.Add(new BlocoDuplicavel
                    {
                        Tipo = tipo,
                        Nome1 = dispositivo.Nome1,
                        Nome2 = dispositivo.Nome2,
                        Alternativo = dispositivo.Alternativo,
                        Painel = dispositivo.Painel,
                        Complementar = dispositivo.Complementar,
                        Pagina = pagina,
                        Handle = handle,
                    });
                    return;
                }

                case "E":
                {
                    DispositivoFiacao porta;
                    if (!DispositivoFiacaoXData.Ler(valores, out porta))
                    {
                        return;
                    }

                    string nome1;
                    string nome2;
                    string alternativo;
                    short painel;
                    IdentidadeDeReferencia(banco, transacao, porta.HandleMascara, out nome1, out nome2, out alternativo, out painel);

                    saida.Add(new BlocoDuplicavel
                    {
                        Tipo = "E",
                        Nome1 = nome1,
                        Nome2 = nome2,
                        Alternativo = alternativo,
                        Painel = painel,
                        IndiceDaPorta = porta.IndiceDaPorta,
                        Pagina = pagina,
                        Handle = handle,
                    });
                    return;
                }

                case "A":
                {
                    DispositivoFiacao auxiliar;
                    if (!DispositivoFiacaoXData.Ler(valores, out auxiliar))
                    {
                        return;
                    }

                    string nome1;
                    string nome2;
                    string alternativo;
                    short painel;
                    IdentidadeDeReferencia(banco, transacao, auxiliar.HandleBob, out nome1, out nome2, out alternativo, out painel);

                    saida.Add(new BlocoDuplicavel
                    {
                        Tipo = "A",
                        Nome1 = nome1,
                        Nome2 = nome2,
                        Alternativo = alternativo,
                        Painel = painel,
                        IndexContato = auxiliar.IndiceDaPorta,
                        Pagina = pagina,
                        Handle = handle,
                    });
                    return;
                }

                case "B":
                {
                    BorneXData borne;
                    if (!BorneXData.Ler(valores, out borne))
                    {
                        return;
                    }

                    ReguaInfo regua = reguas == null ? null : reguas.Buscar(borne.IndiceRegua);
                    saida.Add(new BlocoDuplicavel
                    {
                        Tipo = "B",
                        Painel = regua == null ? (short)0 : regua.Painel,
                        IndiceRegua = borne.IndiceRegua,
                        Numero = borne.Numero,
                        Pagina = pagina,
                        Handle = handle,
                    });
                    return;
                }

                default:
                    // Importado ("I") e demais não entram na checagem, como no original.
                    return;
            }
        }

        /// <summary>
        /// O texto de **definição** (o <c>DBText</c> com XData <c>Definicao</c>): a
        /// chave do original é <c>HandleDaMascara_indiceDoModelo_indiceDaPorta</c>, e o
        /// painel do filtro sai da máscara apontada.
        /// </summary>
        private static void LerDefinicao(Database banco, Transaction transacao, DBText texto, List<BlocoDuplicavel> saida)
        {
            ResultBuffer xdata = texto.GetXDataForApplication("Definicao");
            if (xdata == null)
            {
                xdata = texto.GetXDataForApplication("DEFINICAO");
            }

            if (xdata == null)
            {
                return;
            }

            IReadOnlyList<TypedXData> valores = XDataNeutro.Para(xdata);
            if (valores.Count < 5)
            {
                return;
            }

            string nome = Texto(valores[0].Valor);
            if (!string.Equals(nome, "DEFINICAO", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            string handleMascara = Texto(valores[1].Valor);
            string nome1;
            string nome2;
            string alternativo;
            short painel;
            IdentidadeDeReferencia(banco, transacao, handleMascara, out nome1, out nome2, out alternativo, out painel);

            saida.Add(new BlocoDuplicavel
            {
                Tipo = "D",
                HandleMascara = handleMascara,
                IndiceModelo = Inteiro(valores[2].Valor),
                IndiceDaPorta = Inteiro(valores[3].Valor),
                Painel = painel,
                Pagina = texto.Layer,
                Handle = texto.Handle.ToString(),
            });
        }

        /// <summary>
        /// A identidade da máscara/bob apontado por um handle: abre o bloco e lê os
        /// nomes/alternativo/painel do XData de dispositivo. Sem o bloco (handle
        /// vazio/inválido), devolve vazio e painel 0 — como o <c>default</c> do original.
        /// </summary>
        private static void IdentidadeDeReferencia(
            Database banco, Transaction transacao, string handle,
            out string nome1, out string nome2, out string alternativo, out short painel)
        {
            nome1 = string.Empty;
            nome2 = string.Empty;
            alternativo = string.Empty;
            painel = 0;

            if (string.IsNullOrEmpty(handle))
            {
                return;
            }

            long numero;
            if (!long.TryParse(handle, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out numero))
            {
                return;
            }

            ObjectId id;
            if (!banco.TryGetObjectId(new Handle(numero), out id))
            {
                return;
            }

            BlockReference bloco = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
            if (bloco == null)
            {
                return;
            }

            IReadOnlyList<TypedXData> valores = LerXData(bloco);
            if (valores == null)
            {
                return;
            }

            DispositivoFiacao referencia;
            if (!DispositivoFiacaoXData.Ler(valores, out referencia))
            {
                return;
            }

            nome1 = referencia.Nome1;
            nome2 = referencia.Nome2;
            alternativo = referencia.Alternativo;
            painel = referencia.Painel;
        }

        private static IReadOnlyList<TypedXData> LerXData(DBObject objeto)
        {
            ResultBuffer xdata = objeto.GetXDataForApplication(DispositivoFiacaoXData.AppName);
            if (xdata == null)
            {
                xdata = objeto.GetXDataForApplication(DispositivoFiacaoXData.AppNameLegado);
            }

            return xdata == null ? null : XDataNeutro.Para(xdata);
        }

        private static string Texto(object valor)
        {
            if (valor == null || valor is DBNull)
            {
                return null;
            }

            string texto = valor as string;
            return texto ?? Convert.ToString(valor, CultureInfo.InvariantCulture);
        }

        private static int Inteiro(object valor)
        {
            return valor == null || valor is DBNull ? 0 : XDataNumero.Inteiro(valor);
        }
    }
}
