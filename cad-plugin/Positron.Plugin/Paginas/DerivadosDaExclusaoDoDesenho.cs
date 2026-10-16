using System;
using Positron.Data.Interligacao;
using Positron.Data.Paginas;
#if AUTOCAD
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Paginas
{
    /// <summary>
    /// O <c>clsApagar.ApagarDerivados</c> do reverso (<c>clsApagar.cs:9</c>) para o ramo da **polyline
    /// de interligação**: antes de a exclusão apagar uma polyline com <c>INTERLIGACAO</c> de
    /// <c>Tipo == 2</c>, apaga a polyline irmã que ela aponta pelo handle (<c>clsInterligacao.ApagarPL
    /// :2087</c>) e os rótulos auxiliares dela (<c>ApagarTextosAuxiliaresVeias :2005</c>: no layer da
    /// irmã, o <c>DBText</c> com <c>AUXINTERLIG</c> do handle e a entidade que não é texto nem bloco
    /// com <c>ELETROSUL</c> do handle).
    ///
    /// Roda **dentro** da transação e do lock da exclusão (o original abre uma transação aninhada em
    /// cada rotina; o resultado é o mesmo). Como no original, qualquer falha aqui é engolida
    /// (<c>catch</c> vazio do <c>ApagarDerivados</c>): o derivado que não deu para apagar não impede
    /// a exclusão da página.
    ///
    /// Os ramos do dispositivo (<c>promoveComplementar</c>/<c>ApagaContatosModeloDispositivo</c>), do
    /// contato auxiliar (<c>limpaInsercaoTabela</c>) e da máscara (<c>ApagaAMascara</c>) não estão
    /// portados (fila do <c>ESTADO.md</c>).
    /// </summary>
    internal static class DerivadosDaExclusaoDoDesenho
    {
        /// <summary>Apaga os derivados da entidade; devolve quantas entidades **extras** saíram.</summary>
        internal static int Apagar(Entity entidade, Transaction transacao, Database banco, BlockTableRecord espaco)
        {
            Polyline polyline = entidade as Polyline;
            if (polyline == null)
            {
                return 0;
            }

            try
            {
                ResultBuffer xdata = polyline.GetXDataForApplication(InterligacaoXData.AppName);
                InterligacaoXData interligacao;
                if (xdata == null || !InterligacaoXData.Ler(XDataNeutro.Para(xdata), out interligacao))
                {
                    return 0;
                }

                string handleDaIrma = DerivadosDaExclusao.HandleDaIrma(interligacao);
                if (handleDaIrma == null)
                {
                    return 0;
                }

                return ApagarIrma(handleDaIrma, transacao, banco, espaco);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>O <c>ApagarPL</c>: a polyline do handle, com os rótulos dela; só se ela tem <c>INTERLIGACAO</c>.</summary>
        private static int ApagarIrma(string handle, Transaction transacao, Database banco, BlockTableRecord espaco)
        {
            long numero;
            if (!long.TryParse(handle, System.Globalization.NumberStyles.HexNumber,
                System.Globalization.CultureInfo.InvariantCulture, out numero))
            {
                return 0;
            }

            ObjectId id;
            if (!banco.TryGetObjectId(new Handle(numero), out id) || id.IsNull || id.IsErased)
            {
                return 0;
            }

            Polyline irma = transacao.GetObject(id, OpenMode.ForRead) as Polyline;
            if (irma == null)
            {
                return 0;
            }

            ResultBuffer xdata = irma.GetXDataForApplication(InterligacaoXData.AppName);
            InterligacaoXData ignorada;
            if (xdata == null || !InterligacaoXData.Ler(XDataNeutro.Para(xdata), out ignorada))
            {
                return 0;
            }

            int apagados = ApagarRotulos(irma.Layer, irma.Handle.ToString(), transacao, espaco);
            irma.UpgradeOpen();
            irma.Erase();
            return apagados + 1;
        }

        /// <summary>O <c>ApagarTextosAuxiliaresVeias</c>: os rótulos auxiliares do trecho, no layer dele.</summary>
        private static int ApagarRotulos(string layer, string handleDoTrecho, Transaction transacao, BlockTableRecord espaco)
        {
            int apagados = 0;
            foreach (ObjectId id in espaco)
            {
                if (id.IsErased)
                {
                    continue;
                }

                Entity entidade = transacao.GetObject(id, OpenMode.ForRead) as Entity;
                if (entidade == null || !string.Equals(entidade.Layer, layer, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                bool apagar;
                if (entidade is DBText)
                {
                    short tipo;
                    string handleDoRotulo;
                    ResultBuffer aux = entidade.GetXDataForApplication(AuxInterligacaoXData.AppName);
                    apagar = aux != null
                        && AuxInterligacaoXData.Ler(XDataNeutro.Para(aux), out tipo, out handleDoRotulo)
                        && DerivadosDaExclusao.RotuloDoTrecho(handleDoRotulo, handleDoTrecho);
                }
                else if (entidade is BlockReference)
                {
                    apagar = false;
                }
                else
                {
                    string handleDoRotulo;
                    ResultBuffer eletrosul = entidade.GetXDataForApplication(AuxInterligacaoEletrosulXData.AppName);
                    apagar = eletrosul != null
                        && AuxInterligacaoEletrosulXData.Ler(XDataNeutro.Para(eletrosul), out handleDoRotulo)
                        && DerivadosDaExclusao.RotuloDoTrecho(handleDoRotulo, handleDoTrecho);
                }

                if (!apagar)
                {
                    continue;
                }

                entidade.UpgradeOpen();
                entidade.Erase();
                apagados++;
            }

            return apagados;
        }
    }
}
