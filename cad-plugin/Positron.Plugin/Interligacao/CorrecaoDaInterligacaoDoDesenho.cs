using System;
using System.Collections.Generic;
using System.Globalization;
using Positron.Data;
using Positron.Data.Bornes;
using Positron.Data.Fiacao;
using Positron.Data.Interligacao;
using Positron.Plugin.Bornes;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
#endif

namespace Positron.Plugin.Interligacao
{
    /// <summary>
    /// A parte que **grava** do comando <c>CorrigeInterligacao</c> (o <c>clsUtilitarios.cs:611</c> do
    /// original): varre o ModelSpace, redescobre o painel de cada ponta pelo **dispositivo que está
    /// sobre ela** (o <c>verificaDispInterlig</c>) e regrava <c>Painel1</c>/<c>Painel2</c> dos trechos
    /// **indefinidos** — a decisão é pura (<see cref="CorrecaoInterligacao"/>).
    ///
    /// **Os ramos do <c>verificaDispInterlig</c>**, reproduzidos (o original pagina a entidade ativa —
    /// <c>Pagina.AtivaPagina(layer)</c> — antes de procurar, então o filtro é o **layer do próprio
    /// trecho**):
    ///
    /// 1. o primeiro <c>BlockReference</c> **na caixa de 0,2** em volta da ponta, no mesmo layer, decide —
    ///    inclusive quando ele **não** é um dispositivo (aí a procura daquela ponta termina sem
    ///    painel, como o <c>break</c> do original);
    /// 2. tipo <c>E</c> exige um atributo <c>B&lt;numero&gt;</c> (senão a ponta não tem painel);
    /// 3. tipo <c>B</c> tem o painel resolvido no dicionário <c>REGUAS</c> (o <c>array[8]</c> é o índice
    ///    da régua, o <c>BuscaPainelDoBorneNoDicionario</c> do original);
    /// 4. tipo <c>I</c> (importado) só vale com o **tipo importado** <c>E</c> (exigindo o atributo
    ///    <c>B&lt;numero&gt;</c>) ou <c>B</c>; o painel sai do <c>array[9]</c> do XData <c>IMPORTADO</c>;
    /// 5. <c>E</c>/<c>A</c> resolvem o painel pelo bloco apontado no <c>array[4]</c> (o handle) — o
    ///    mesmo <c>BuscaPainelDispositivo</c> que a projeção já usa.
    ///
    /// **Duas divergências do original, as duas registradas:** (1) a **caixa** é o teste da posição do
    /// bloco dentro de ±0,2 da ponta (o original usa <c>Editor.SelectCrossingWindow</c>, que também pega
    /// geometria cruzando a janela); (2) um dispositivo cujo painel resolve em **0** conta como **não
    /// achado** — o original devolveria <c>true</c> com painel 0 e gravaria o zero (ver a decisão da
    /// regra pura). Com dois blocos dentro da caixa a ordem é a do ModelSpace, não a do selection set
    /// do original.
    /// </summary>
    internal static class CorrecaoDaInterligacaoDoDesenho
    {
        /// <summary>Meia-aresta da janela do <c>verificaDispInterlig</c> (0,2 no original).</summary>
        private const double ToleranciaDaPonta = 0.2;

        /// <summary>O tipo do borne (<c>B</c>), que tem leitor e painel próprios (o dicionário de réguas).</summary>
        private const string TipoBorne = "B";

        internal sealed class Resultado
        {
            /// <summary>Trechos de interligação lidos do desenho (XData válido).</summary>
            internal int TrechosLidos { get; set; }

            /// <summary>Trechos <c>NumVeia == -1000</c> (os que a correção olha).</summary>
            internal int TrechosIndefinidos { get; set; }

            /// <summary>Trechos regravados.</summary>
            internal int Corrigidos { get; set; }

            /// <summary>Trechos indefinidos sem dispositivo (ou sem a ponta exigida) — pulados.</summary>
            internal int SemDispositivo { get; set; }

            /// <summary>Blocos que caíram na caixa de alguma ponta (a conta do instrumento).</summary>
            internal int BlocosNaCaixa { get; set; }
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
            ReguasModelo reguas = ReguasDoDesenho.Ler();

            using (Transaction transacao = banco.TransactionManager.StartTransaction())
            {
                BlockTable tabela = (BlockTable)transacao.GetObject(banco.BlockTableId, OpenMode.ForRead);
                BlockTableRecord espaco = (BlockTableRecord)transacao.GetObject(
                    tabela[BlockTableRecord.ModelSpace], OpenMode.ForRead);

                List<BlockReference> blocos = new List<BlockReference>();
                foreach (ObjectId id in espaco)
                {
                    BlockReference bloco = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
                    if (bloco != null)
                    {
                        blocos.Add(bloco);
                    }
                }

                List<Polyline> entidades = new List<Polyline>();
                List<InterligacaoXData> dados = new List<InterligacaoXData>();
                List<CorrecaoInterligacao.Trecho> trechos = new List<CorrecaoInterligacao.Trecho>();

                foreach (ObjectId id in espaco)
                {
                    Polyline linha = transacao.GetObject(id, OpenMode.ForRead) as Polyline;
                    if (linha == null)
                    {
                        continue;
                    }

                    ResultBuffer xdata = ((DBObject)linha).GetXDataForApplication(InterligacaoXData.AppName);
                    if (xdata == null)
                    {
                        continue;
                    }

                    InterligacaoXData ilig;
                    if (!InterligacaoXData.Ler(XDataNeutro.Para(xdata), out ilig))
                    {
                        // XData inválido/truncado não derruba o comando.
                        continue;
                    }

                    resultado.TrechosLidos++;

                    bool indefinido = ilig.NumVeia == InterligacaoXData.NumVeiaIndefinido;
                    if (indefinido)
                    {
                        resultado.TrechosIndefinidos++;
                    }

                    CorrecaoInterligacao.Ponta ponta1 = CorrecaoInterligacao.Ponta.NaoEncontrada;
                    CorrecaoInterligacao.Ponta ponta2 = CorrecaoInterligacao.Ponta.NaoEncontrada;
                    if (indefinido && (ilig.Tipo == CorrecaoInterligacao.TipoDuasPontas
                        || ilig.Tipo == CorrecaoInterligacao.TipoUmaPonta
                        || ilig.Tipo == CorrecaoInterligacao.TipoDestino))
                    {
                        ponta1 = EncontrarPonta(transacao, blocos, linha, 0, reguas, resultado);
                        ponta2 = EncontrarPonta(transacao, blocos, linha, linha.NumberOfVertices - 1, reguas, resultado);
                    }

                    trechos.Add(CorrecaoInterligacao.Trecho.De(
                        ilig.Tipo, indefinido, ilig.Painel1, ilig.Painel2, ponta1, ponta2));

                    entidades.Add(linha);
                    dados.Add(ilig);
                }

                CorrecaoInterligacao.Plano plano = CorrecaoInterligacao.Planejar(trechos);
                resultado.SemDispositivo = plano.SemDispositivo;

                if (plano.Correcoes.Count > 0)
                {
                    BornesDaCorrecao.GarantirAppName(transacao, banco, InterligacaoXData.AppName);

                    foreach (CorrecaoInterligacao.Correcao correcao in plano.Correcoes)
                    {
                        InterligacaoXData trecho = dados[correcao.Indice];
                        trecho.Painel1 = correcao.Painel1;
                        trecho.Painel2 = correcao.Painel2;

                        DBObject objeto = entidades[correcao.Indice];
                        objeto.UpgradeOpen();
                        objeto.XData = BornesDaCorrecao.ParaResultBuffer(trecho.ParaValores(
                            Environment.UserName, DateTime.Now.ToString()));

                        resultado.Corrigidos++;
                    }
                }

                transacao.Commit();
            }

            return resultado;
        }

        /// <summary>O painel achado no vértice indicado (a leitura do <c>verificaDispInterlig</c>).</summary>
        private static CorrecaoInterligacao.Ponta EncontrarPonta(
            Transaction transacao,
            IReadOnlyList<BlockReference> blocos,
            Polyline linha,
            int vertice,
            ReguasModelo reguas,
            Resultado resultado)
        {
            if (vertice < 0 || vertice >= linha.NumberOfVertices)
            {
                return CorrecaoInterligacao.Ponta.NaoEncontrada;
            }

            Point2d ponto = linha.GetPoint2dAt(vertice);
            string pagina = linha.Layer;

            foreach (BlockReference bloco in blocos)
            {
                if (!string.Equals(bloco.Layer, pagina, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                if (!NaCaixa(bloco.Position, ponto))
                {
                    continue;
                }

                resultado.BlocosNaCaixa++;

                // O primeiro bloco da caixa decide: é o `break` do original quando ele não é um
                // dispositivo (ou quando é um E/I sem o atributo de borne).
                return DispositivoDaPonta(transacao, bloco, reguas);
            }

            return CorrecaoInterligacao.Ponta.NaoEncontrada;
        }

        /// <summary>Os cinco ramos do <c>verificaDispInterlig</c> para um bloco candidato.</summary>
        private static CorrecaoInterligacao.Ponta DispositivoDaPonta(
            Transaction transacao,
            BlockReference bloco,
            ReguasModelo reguas)
        {
            DispositivoDoBloco dispositivo = LerDispositivo(bloco);
            if (dispositivo == null)
            {
                return CorrecaoInterligacao.Ponta.NaoEncontrada;
            }

            if (string.Equals(dispositivo.Tipo, DispositivoFiacaoXData.TipoPorta, StringComparison.Ordinal))
            {
                if (!TemAtributoBorne(transacao, bloco))
                {
                    return CorrecaoInterligacao.Ponta.NaoEncontrada;
                }

                return ComPainel(dispositivo, reguas);
            }

            if (string.Equals(dispositivo.Tipo, TipoBorne, StringComparison.Ordinal))
            {
                return ComPainel(dispositivo, reguas);
            }

            if (!string.Equals(dispositivo.Tipo, DispositivoFiacaoXData.TipoImportado, StringComparison.Ordinal))
            {
                return CorrecaoInterligacao.Ponta.NaoEncontrada;
            }

            if (!string.Equals(dispositivo.TipoImportado, DispositivoFiacaoXData.TipoPorta, StringComparison.Ordinal))
            {
                return string.Equals(dispositivo.TipoImportado, TipoBorne, StringComparison.Ordinal)
                    ? ComPainel(dispositivo, reguas)
                    : CorrecaoInterligacao.Ponta.NaoEncontrada;
            }

            if (!TemAtributoBorne(transacao, bloco))
            {
                return CorrecaoInterligacao.Ponta.NaoEncontrada;
            }

            return ComPainel(dispositivo, reguas);
        }

        /// <summary>Painel 0 é "sem painel" no produto (o <c>Painel1 &lt;= 0</c> da projeção): não é achado.</summary>
        private static CorrecaoInterligacao.Ponta ComPainel(DispositivoDoBloco dispositivo, ReguasModelo reguas)
        {
            short painel = dispositivo.Painel(reguas);
            return painel == 0
                ? CorrecaoInterligacao.Ponta.NaoEncontrada
                : new CorrecaoInterligacao.Ponta(painel, true);
        }

        private static bool NaCaixa(Point3d posicao, Point2d ponto)
        {
            return Math.Abs(posicao.X - ponto.X) <= ToleranciaDaPonta
                && Math.Abs(posicao.Y - ponto.Y) <= ToleranciaDaPonta;
        }

        /// <summary>O <c>verificaTipoDispositivo</c> do original: o XData do bloco em tipos neutros.</summary>
        private static DispositivoDoBloco LerDispositivo(BlockReference bloco)
        {
            ResultBuffer xdata = bloco.GetXDataForApplication(DispositivoFiacaoXData.AppName);
            if (xdata == null)
            {
                xdata = bloco.GetXDataForApplication(DispositivoFiacaoXData.AppNameLegado);
            }

            if (xdata != null)
            {
                IReadOnlyList<TypedXData> valores = XDataNeutro.Para(xdata);
                return new DispositivoDoBloco(Texto(valores, 1), string.Empty, valores);
            }

            ResultBuffer importado = bloco.GetXDataForApplication(DispositivoFiacaoXData.AppNameImportado);
            if (importado != null)
            {
                IReadOnlyList<TypedXData> valores = XDataNeutro.Para(importado);
                return new DispositivoDoBloco(DispositivoFiacaoXData.TipoImportado, Texto(valores, 3), valores);
            }

            return null;
        }

        /// <summary>Tem atributo <c>B&lt;numero&gt;</c> (a exigência dos ramos <c>E</c> e <c>I/E</c>).</summary>
        private static bool TemAtributoBorne(Transaction transacao, BlockReference bloco)
        {
            foreach (ObjectId id in bloco.AttributeCollection)
            {
                AttributeReference atributo = transacao.GetObject(id, OpenMode.ForRead) as AttributeReference;
                if (atributo == null)
                {
                    continue;
                }

                string tag = atributo.Tag ?? string.Empty;
                if (tag.Length > 1
                    && (tag[0] == (char)66 || tag[0] == (char)98)
                    && EhNumero(tag.Substring(1)))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool EhNumero(string texto)
        {
            double valor;
            return !string.IsNullOrEmpty(texto)
                && double.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out valor);
        }

        private static string Texto(IReadOnlyList<TypedXData> valores, int indice)
        {
            if (valores == null || valores.Count <= indice || valores[indice].Valor == null)
            {
                return string.Empty;
            }

            string texto = Convert.ToString(valores[indice].Valor);
            return texto == null ? string.Empty : texto.Trim().ToUpperInvariant();
        }

        /// <summary>O XData do bloco candidato: o tipo, o tipo importado e os valores crus.</summary>
        private sealed class DispositivoDoBloco
        {
            internal DispositivoDoBloco(string tipo, string tipoImportado, IReadOnlyList<TypedXData> valores)
            {
                Tipo = tipo;
                TipoImportado = tipoImportado;
                Valores = valores;
            }

            internal string Tipo { get; private set; }

            internal string TipoImportado { get; private set; }

            internal IReadOnlyList<TypedXData> Valores { get; private set; }

            /// <summary>O painel do bloco pelas regras do <c>BuscaPainelDispositivo</c>.</summary>
            internal short Painel(ReguasModelo reguas)
            {
                if (string.Equals(Tipo, TipoBorne, StringComparison.Ordinal))
                {
                    ReguaInfo regua = reguas.Buscar(Inteiro(Valores, 8));
                    return regua == null ? (short)0 : regua.Painel;
                }

                if (string.Equals(Tipo, DispositivoFiacaoXData.TipoImportado, StringComparison.Ordinal))
                {
                    DispositivoFiacao importado;
                    return DispositivoFiacaoXData.LerImportado(Valores, out importado) ? importado.Painel : (short)0;
                }

                DispositivoFiacao lido;
                if (!DispositivoFiacaoXData.Ler(Valores, out lido))
                {
                    return 0;
                }

                return lido.PainelPendente ? ResolverPainelPendente(lido) : lido.Painel;
            }

            /// <summary>
            /// O <c>E</c>/<c>A</c> não traz o painel: ele vem do bloco apontado no <c>array[4]</c> (a
            /// máscara/o bob), como o <c>BuscaPainelDispositivo</c> do original.
            /// </summary>
            private static short ResolverPainelPendente(DispositivoFiacao dispositivo)
            {
                if (string.IsNullOrEmpty(dispositivo.HandleMascara))
                {
                    return 0;
                }

                long valor;
                if (!long.TryParse(dispositivo.HandleMascara, NumberStyles.HexNumber,
                        CultureInfo.InvariantCulture, out valor))
                {
                    return 0;
                }

                Document documento = Application.DocumentManager.MdiActiveDocument;
                if (documento == null)
                {
                    return 0;
                }

                Database banco = documento.Database;
                ObjectId id;
                if (!banco.TryGetObjectId(new Handle(valor), out id))
                {
                    return 0;
                }

                Transaction transacao = banco.TransactionManager.TopTransaction;
                if (transacao == null)
                {
                    return 0;
                }

                BlockReference mascara = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
                if (mascara == null)
                {
                    return 0;
                }

                ResultBuffer xdata = mascara.GetXDataForApplication(DispositivoFiacaoXData.AppName);
                if (xdata == null)
                {
                    xdata = mascara.GetXDataForApplication(DispositivoFiacaoXData.AppNameLegado);
                }

                if (xdata == null)
                {
                    return 0;
                }

                short painel;
                return DispositivoFiacaoXData.LerPainel(XDataNeutro.Para(xdata), out painel) ? painel : (short)0;
            }

            private static int Inteiro(IReadOnlyList<TypedXData> valores, int indice)
            {
                if (valores == null || valores.Count <= indice || valores[indice].Valor == null)
                {
                    return 0;
                }

                return XDataNumero.Inteiro(valores[indice].Valor);
            }
        }
    }
}
