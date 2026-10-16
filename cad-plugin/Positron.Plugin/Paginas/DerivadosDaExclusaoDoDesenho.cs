using System;
using System.Collections.Generic;
using Positron.Data;
using Positron.Data.Fiacao;
using Positron.Data.Interligacao;
using Positron.Data.Modelos;
using Positron.Data.Paginas;
using Positron.Plugin.Bornes;
using Positron.Plugin.Correcoes;
#if AUTOCAD
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
#else
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
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
    /// O ramo do **contato auxiliar** (tipo <c>A</c> do <c>verificaTipoDispositivo</c>) chama a
    /// <c>clsDispositivoAuxiliares.limpaInsercaoTabela(handle)</c> (<c>:2656</c>): o primeiro bloco de
    /// modelo cujo <c>HandleContatoAux</c> é o handle do contato apagado tem os atributos
    /// <c>INSERCAO</c>/<c>INSERCAONA</c>/<c>INSERCAONF</c> zerados e o <c>HandleContatoAux</c> esvaziado.
    ///
    /// O ramo da **máscara** (tipo <c>M</c>) chama o <c>clsMascara.ApagaAMascara</c> (<c>clsMascara.cs:1264</c>):
    /// a primeira outra máscara com o mesmo painel/nomes/alternativo é promovida e as demais apontam
    /// para ela (<see cref="ApagarMascara"/>); sem sucessora, as portas e as definições da máscara saem
    /// junto; com ela, passam a apontar para ela.
    ///
    /// Os ramos do dispositivo (<c>promoveComplementar</c>/<c>ApagaContatosModeloDispositivo</c>) não
    /// estão portados (fila do <c>ESTADO.md</c>).
    /// </summary>
    internal static class DerivadosDaExclusaoDoDesenho
    {
        /// <summary>Apaga os derivados da entidade; devolve quantas entidades **extras** saíram.</summary>
        internal static int Apagar(Entity entidade, Transaction transacao, Database banco, BlockTableRecord espaco)
        {
            if (entidade == null)
            {
                return 0;
            }

            try
            {
                Polyline polyline = entidade as Polyline;
                if (polyline != null)
                {
                    return ApagarDaInterligacao(polyline, transacao, banco, espaco);
                }

                ResultBuffer dispositivo = entidade.GetXDataForApplication(DispositivoFiacaoXData.AppName);
                ResultBuffer importado = dispositivo == null
                    ? entidade.GetXDataForApplication(DispositivoFiacaoXData.AppNameImportado)
                    : null;
                string tipo = DerivadosDaExclusao.TipoDoDispositivo(
                    dispositivo == null ? null : XDataNeutro.Para(dispositivo),
                    importado == null ? null : XDataNeutro.Para(importado));
                if (string.Equals(tipo, DispositivoFiacaoXData.TipoAuxiliar, StringComparison.OrdinalIgnoreCase))
                {
                    LimparInsercaoDoModelo(entidade.Handle.ToString(), transacao, banco, espaco);
                }

                if (string.Equals(tipo, DispositivoFiacaoXData.TipoMascara, StringComparison.OrdinalIgnoreCase))
                {
                    return ApagarAMascara(entidade as BlockReference, transacao, banco, espaco);
                }

                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private static int ApagarDaInterligacao(Polyline polyline, Transaction transacao, Database banco, BlockTableRecord espaco)
        {
            ResultBuffer xdata = polyline.GetXDataForApplication(InterligacaoXData.AppName);
            InterligacaoXData interligacao;
            if (xdata == null || !InterligacaoXData.Ler(XDataNeutro.Para(xdata), out interligacao))
            {
                return 0;
            }

            string handleDaIrma = DerivadosDaExclusao.HandleDaIrma(interligacao);
            return handleDaIrma == null ? 0 : ApagarIrma(handleDaIrma, transacao, banco, espaco);
        }

        /// <summary>
        /// O <c>ApagaAMascara</c>: planeja pela regra pura, regrava as outras máscaras e depois apaga ou
        /// reaponta as portas e as definições da apagada. Devolve quantas entidades **extras** saíram.
        /// </summary>
        private static int ApagarAMascara(BlockReference mascara, Transaction transacao, Database banco, BlockTableRecord espaco)
        {
            if (mascara == null)
            {
                return 0;
            }

            EstadoDaMascara estado = LerMascara(mascara);
            if (estado == null)
            {
                return 0;
            }

            string handle = mascara.Handle.ToString();
            List<ApagarMascara.Candidata> candidatas = new List<ApagarMascara.Candidata>();
            foreach (ObjectId id in espaco)
            {
                if (id.IsErased)
                {
                    continue;
                }

                BlockReference outra = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
                EstadoDaMascara outroEstado = outra == null ? null : LerMascara(outra);
                if (outroEstado == null)
                {
                    continue;
                }

                candidatas.Add(new ApagarMascara.Candidata
                {
                    Handle = outra.Handle.ToString(),
                    Estado = outroEstado,
                    Modelo = LerAtributo(transacao, outra, ApagarMascara.AtributoModelo),
                    Fabricante = LerAtributo(transacao, outra, ApagarMascara.AtributoFabricante),
                    Descricao = LerAtributo(transacao, outra, ApagarMascara.AtributoDescricao),
                });
            }

            ApagarMascara.Plano plano = ApagarMascara.Planejar(
                handle,
                estado,
                LerAtributo(transacao, mascara, ApagarMascara.AtributoModelo),
                LerAtributo(transacao, mascara, ApagarMascara.AtributoFabricante),
                LerAtributo(transacao, mascara, ApagarMascara.AtributoDescricao),
                candidatas);
            if (plano == null)
            {
                return 0;
            }

            foreach (ApagarMascara.Gravacao gravacao in plano.Gravacoes)
            {
                GravarMascara(gravacao, transacao, banco);
            }

            return ApagarOuReapontarPortas(handle, plano.Sucessora, transacao, banco, espaco);
        }

        /// <summary>O ramo `M` do <c>LeXDataQualquerDispositivo</c>: o estado da máscara, ou <c>null</c>.</summary>
        private static EstadoDaMascara LerMascara(BlockReference bloco)
        {
            ResultBuffer xdata = bloco.GetXDataForApplication(EstadoDaMascara.AppName);
            EstadoDaMascara estado;
            return xdata != null && EstadoDaMascara.Ler(XDataNeutro.Para(xdata), out estado) ? estado : null;
        }

        private static string LerAtributo(Transaction transacao, BlockReference bloco, string tag)
        {
            foreach (ObjectId idAtributo in bloco.AttributeCollection)
            {
                AttributeReference atributo = transacao.GetObject(idAtributo, OpenMode.ForRead) as AttributeReference;
                if (atributo != null && string.Equals(atributo.Tag, tag, StringComparison.OrdinalIgnoreCase))
                {
                    return atributo.TextString ?? string.Empty;
                }
            }

            return string.Empty;
        }

        /// <summary>O `EditaUmAtributoDeUmBloco` de cada atributo do plano e o `GravarXDataMascara` do estado novo.</summary>
        private static void GravarMascara(ApagarMascara.Gravacao gravacao, Transaction transacao, Database banco)
        {
            BlockReference bloco = BornesDaCorrecao.AbrirPorHandle(transacao, banco, gravacao.Handle);
            if (bloco == null)
            {
                return;
            }

            foreach (ApagarMascara.EdicaoDeAtributo edicao in gravacao.Atributos)
            {
                foreach (ObjectId idAtributo in bloco.AttributeCollection)
                {
                    AttributeReference atributo = transacao.GetObject(idAtributo, OpenMode.ForRead) as AttributeReference;
                    if (atributo == null || !string.Equals(atributo.Tag, edicao.Tag, StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    atributo.UpgradeOpen();
                    if (!string.Equals(atributo.TextString, edicao.Valor, StringComparison.OrdinalIgnoreCase))
                    {
                        atributo.TextString = edicao.Valor;
                    }

                    atributo.Visible = edicao.Visivel;
                    atributo.AdjustAlignment(banco);
                    break;
                }
            }

            BornesDaCorrecao.GarantirAppName(transacao, banco, EstadoDaMascara.AppName);
            bloco.UpgradeOpen();
            bloco.XData = XDataNeutro.ParaResultBuffer(gravacao.Estado.ParaValores(
                Environment.UserName, DateTime.Now.ToString(), new Point3d(0, 0, 0)));
        }

        /// <summary>
        /// O fim do <c>ApagaAMascara</c>: as definições (`Definicao`) e as portas (`E`) cujo
        /// <c>HandleDaMascara</c> é o da apagada saem (sem sucessora) ou passam a apontar para a sucessora.
        /// </summary>
        private static int ApagarOuReapontarPortas(string handle, string sucessora, Transaction transacao, Database banco, BlockTableRecord espaco)
        {
            int apagados = 0;
            foreach (ObjectId id in espaco)
            {
                if (id.IsErased)
                {
                    continue;
                }

                Entity entidade = transacao.GetObject(id, OpenMode.ForRead) as Entity;
                if (entidade == null)
                {
                    continue;
                }

                ResultBuffer dispositivo = entidade.GetXDataForApplication(DispositivoFiacaoXData.AppName);
                ResultBuffer importado = dispositivo == null
                    ? entidade.GetXDataForApplication(DispositivoFiacaoXData.AppNameImportado)
                    : null;
                string tipo = DerivadosDaExclusao.TipoDoDispositivo(
                    dispositivo == null ? null : XDataNeutro.Para(dispositivo),
                    importado == null ? null : XDataNeutro.Para(importado));

                bool apagar;
                if (!string.Equals(tipo, DispositivoFiacaoXData.TipoPorta, StringComparison.OrdinalIgnoreCase))
                {
                    ResultBuffer definicao = entidade.GetXDataForApplication(EstadoDaDefinicao.AppName);
                    EstadoDaDefinicao def;
                    if (definicao == null || !EstadoDaDefinicao.Ler(XDataNeutro.Para(definicao), out def))
                    {
                        continue;
                    }

                    string novo = ApagarMascara.NovoHandleDaMascara(def.HandleDaMascara, handle, sucessora, out apagar);
                    if (apagar)
                    {
                        entidade.UpgradeOpen();
                        entidade.Erase();
                        apagados++;
                    }
                    else if (novo != null)
                    {
                        def.HandleDaMascara = novo;
                        BornesDaCorrecao.GarantirAppName(transacao, banco, EstadoDaDefinicao.AppName);
                        entidade.UpgradeOpen();
                        entidade.XData = XDataNeutro.ParaResultBuffer(def.ParaValores());
                    }

                    continue;
                }

                EstadoDaPorta porta;
                if (dispositivo == null || !EstadoDaPorta.Ler(XDataNeutro.Para(dispositivo), out porta))
                {
                    continue;
                }

                string novoHandle = ApagarMascara.NovoHandleDaMascara(porta.HandleDaMascara, handle, sucessora, out apagar);
                if (apagar)
                {
                    entidade.UpgradeOpen();
                    entidade.Erase();
                    apagados++;
                }
                else if (novoHandle != null)
                {
                    porta.HandleDaMascara = novoHandle;
                    BornesDaCorrecao.GarantirAppName(transacao, banco, EstadoDaMascara.AppName);
                    entidade.UpgradeOpen();
                    entidade.XData = XDataNeutro.ParaResultBuffer(porta.ParaValores(Environment.UserName, DateTime.Now.ToString()));
                }
            }

            return apagados;
        }

        /// <summary>
        /// A <c>limpaInsercaoTabela</c>: o primeiro bloco de modelo cujo <c>HandleContatoAux</c> é
        /// <paramref name="handleDoContato"/> perde o texto dos atributos de inserção e o handle.
        /// </summary>
        private static void LimparInsercaoDoModelo(string handleDoContato, Transaction transacao, Database banco, BlockTableRecord espaco)
        {
            foreach (ObjectId id in espaco)
            {
                if (id.IsErased)
                {
                    continue;
                }

                BlockReference bloco = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
                if (bloco == null)
                {
                    continue;
                }

                ResultBuffer xdata = bloco.GetXDataForApplication(ModeloXData.AppName)
                    ?? bloco.GetXDataForApplication(ModeloXData.AppNameLegado);
                BlocoModelo modelo;
                if (xdata == null
                    || !ModeloXData.Ler(XDataNeutro.Para(xdata), out modelo)
                    || !DerivadosDaExclusao.RotuloDoTrecho(modelo.HandleContatoAux, handleDoContato))
                {
                    continue;
                }

                foreach (ObjectId idAtributo in bloco.AttributeCollection)
                {
                    AttributeReference atributo = transacao.GetObject(idAtributo, OpenMode.ForWrite) as AttributeReference;
                    if (atributo != null && DerivadosDaExclusao.AtributoDeInsercao(atributo.Tag))
                    {
                        atributo.TextString = string.Empty;
                    }
                }

                modelo.HandleContatoAux = string.Empty;
                BornesDaCorrecao.GarantirAppName(transacao, banco, ModeloXData.AppName);
                ResultBuffer todos = bloco.XData;
                bloco.UpgradeOpen();
                bloco.XData = XDataNeutro.ParaResultBuffer(ContatosAuxiliaresDoDesenho.TrocandoOModelo(
                    todos == null ? null : XDataNeutro.Para(todos), modelo));
                return;
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
