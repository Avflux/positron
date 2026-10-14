using System;
using System.Collections.Generic;
using Positron.Data;
using Positron.Data.Fiacao;
using Positron.Data.Materiais;
using Positron.Data.Modelos;
using Positron.Plugin.Bornes;
#if AUTOCAD
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
#else
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.DatabaseServices;
#endif

namespace Positron.Plugin.Materiais
{
    /// <summary>
    /// O I/O do **ramo do desenho** do <b>Edita Material Selecionado</b> do <c>ATINDEP</c> — o
    /// <c>clsDispositivo.EditaLMDoDispositivo</c> do reverso: para cada linha da lista escolhida que
    /// veio do desenho (tem <c>Handle</c>), grava o <c>iLM1</c> no XData <c>Dispositivo</c> do bloco e
    /// os atributos <c>MODELO</c> (vazio) / <c>PAINEL</c> / <c>FABRICANTE</c>. A regra do que gravar é
    /// pura (<see cref="DispositivoDaListaEdicao"/>); aqui só se fala com o desenho.
    ///
    /// **O que o original faz e se reproduz:**
    ///
    /// - o bloco vem do **handle** e só entra quando o tipo do XData é <c>"P"</c>
    ///   (<c>verificaTipoDispositivo</c>) — o handle que não é bloco de dispositivo é **pulado**;
    /// - o XData é regravado **só quando o <c>iLM1</c> difere** (o guarda do original), sempre com o
    ///   código <c>1071</c> — o tipo do <c>iLM1</c> no array do <c>GravarXDataDispPrincipal</c>;
    /// - o **fabricante** sai do LM **relido do desenho** depois da gravação (o original chama
    ///   <c>LeXDataQualquerDispositivo</c> de novo antes do <c>BuscaFabricanteDoMaterial</c>) e o
    ///   <c>PAINEL</c> do painel **do bloco** (o <c>array[8]</c>), não do cadastro da linha;
    /// - os **três atributos são gravados sempre**, mesmo quando o LM já era o escolhido.
    ///
    /// **Diferenças de forma, as dos outros adaptadores de escrita:** o buffer é gravado trocando
    /// **só o valor** dentro do registro do app (<see cref="TrocarUmValor"/>), preservando os outros
    /// app names — o original joga o array de 29 valores no <c>Entity.XData</c> e, com isso, **apaga
    /// os outros registros** do bloco —; o texto do atributo só é escrito quando **difere** (o
    /// original chama <c>UpgradeOpen</c>/<c>AdjustAlignment</c>/<c>Draw</c> e grava sempre; o
    /// redesenho e o reajuste de alinhamento ficam com o CAD, como na rodada 135); o lote inteiro roda
    /// numa **transação só** (o original abre uma por atributo, com <c>LockDocument</c> em cada) e o
    /// handle que não abre deixa de ser um <c>InvalidCastException</c> que **abortava a transação
    /// inteira** no original — aqui ele é contado em <see cref="Resultado.BlocosNaoAchados"/>.
    /// </summary>
    internal static class DispositivoDaListaDoDesenho
    {
        /// <summary>O app name legado que o <c>verificaTipoDispositivo</c> também procura.</summary>
        private const string AppNameLegado = "DISPOSITIVO";

        /// <summary>O tipo da tabela de dispositivos do XData <c>Dispositivo</c> (o `disp` do original).</summary>
        private const string TipoDispositivo = "P";

        internal sealed class Resultado
        {
            /// <summary>Linhas do desenho recebidas (as que têm handle).</summary>
            internal int Itens { get; set; }

            /// <summary>Blocos do desenho efetivamente lidos como dispositivo.</summary>
            internal int Dispositivos { get; set; }

            /// <summary>XData regravado com o material escolhido (o guarda do <c>iLM1</c>).</summary>
            internal int LmGravados { get; set; }

            /// <summary>Dispositivos que **já** estavam com o material escolhido (o XData não foi tocado).</summary>
            internal int LmIguais { get; set; }

            /// <summary>Handles que não estão no desenho (ou não são bloco).</summary>
            internal int BlocosNaoAchados { get; set; }

            /// <summary>Blocos que não são dispositivo tipo <c>"P"</c> (o XData diz outra coisa).</summary>
            internal int NaoEhDispositivo { get; set; }

            /// <summary>Registros de dispositivo com o array curto demais para o painel/o <c>iLM1</c>.</summary>
            internal int XDataCurto { get; set; }

            /// <summary>Atributos gravados (com texto diferente do que estava).</summary>
            internal int AtributosGravados { get; set; }

            /// <summary>Atributos que já estavam com o texto certo (o caso do <c>MODELO</c> já vazio).</summary>
            internal int AtributosIguais { get; set; }

            /// <summary>Atributos pedidos que o bloco não tem (o <c>MODELO</c>/<c>PAINEL</c>/<c>FABRICANTE</c> fora do bloco).</summary>
            internal int AtributosNaoAchados { get; set; }

            /// <summary>O app name não estava no buffer na hora de gravar (o CAD lançaria).</summary>
            internal int RegistroNaoAchado { get; set; }
        }

        /// <summary>
        /// Aplica o plano no desenho. Nunca lança: um erro de dados (handle que não abre, XData fora
        /// do formato) é contado e o resto do lote segue — o comando trata a exceção de ambiente.
        /// </summary>
        internal static Resultado Executar(
            IReadOnlyList<ItemDoDispositivo> itens,
            IReadOnlyDictionary<int, string> nomesDePaineis,
            IReadOnlyDictionary<int, MaterialDoCatalogo> catalogo)
        {
            Resultado resultado = new Resultado();
            if (itens == null || itens.Count == 0)
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
                foreach (ItemDoDispositivo item in itens)
                {
                    resultado.Itens++;

                    IReadOnlyList<TypedXData> valores;
                    BlockReference bloco = AbrirDispositivo(transacao, banco, item, resultado, out valores);
                    if (bloco == null)
                    {
                        continue;
                    }

                    resultado.Dispositivos++;

                    int painel = XDataNumero.Curto(valores[DispositivoDaListaEdicao.IndiceDoPainelNoXData].Valor);
                    bool gravou = GravarLm(transacao, banco, bloco, valores, item, resultado);

                    // O original relê o XData depois de gravar e é o LM **de lá** que busca o
                    // fabricante. Quando a gravação sai, o LM do desenho é o escolhido (é o valor que
                    // acabou de ser escrito — não se depende de reler o que se gravou); quando não sai
                    // (o já igual e o registro que sumiu do buffer), o LM é o **do desenho**, como no
                    // `LeXDataQualquerDispositivo` que o original repete.
                    int lmDoDesenho = gravou ? item.Lm : LerLm(bloco, valores);

                    string nomeDoPainel = DispositivoDaListaEdicao.NomeDoPainel(nomesDePaineis, painel);
                    string fabricante = DispositivoDaListaEdicao.FabricanteDoMaterial(
                        CatalogoDeMateriais.Buscar(catalogo, lmDoDesenho));

                    GravarAtributos(
                        transacao,
                        bloco,
                        DispositivoDaListaEdicao.AtributosDoDispositivo(nomeDoPainel, fabricante),
                        resultado);
                }

                transacao.Commit();
            }

            return resultado;
        }

        /// <summary>
        /// Abre o bloco do item e devolve o registro do XData <c>Dispositivo</c> **já validado**
        /// (o <c>verificaTipoDispositivo</c> + o <c>LeXDataQualquerDispositivo</c> do original):
        /// <c>null</c> quando o handle não abre, quando o bloco não tem o XData ou quando o tipo não é
        /// <c>"P"</c> — nos três casos o original pula a linha (ou, no handle inválido, derrubaria a
        /// transação inteira: aqui é contado).
        /// </summary>
        private static BlockReference AbrirDispositivo(
            Transaction transacao,
            Database banco,
            ItemDoDispositivo item,
            Resultado resultado,
            out IReadOnlyList<TypedXData> valores)
        {
            valores = null;

            BlockReference bloco = BornesDaCorrecao.AbrirPorHandle(transacao, banco, item.Handle);
            if (bloco == null)
            {
                resultado.BlocosNaoAchados++;
                return null;
            }

            // O `verificaTipoDispositivo` lê o app name **em maiúscula** (a tabela do CAD não
            // diferencia caixa, então é o mesmo registro) e o `LeXDataQualquerDispositivo` procura o
            // atual e depois o legado — as duas leituras do original, como estão.
            ResultBuffer xdata = bloco.GetXDataForApplication(DispositivoXData.AppName)
                ?? bloco.GetXDataForApplication(AppNameLegado);
            valores = XDataNeutro.Para(xdata);

            if (valores.Count <= DispositivoDaListaEdicao.IndiceDoLmNoXData)
            {
                // Sem o array inteiro não há nem painel nem iLM1 para ler — e o original estouraria no
                // índice (o `Conversions.ToInteger(array[...])`), abortando o lote.
                resultado.XDataCurto++;
                valores = null;
                return null;
            }

            string tipo = valores[1].Valor as string;
            if (!string.Equals(tipo ?? string.Empty, TipoDispositivo, StringComparison.OrdinalIgnoreCase))
            {
                resultado.NaoEhDispositivo++;
                valores = null;
                return null;
            }

            return bloco;
        }

        /// <summary>
        /// O guarda e a gravação do <c>iLM1</c>: só troca o valor quando o do desenho difere do
        /// escolhido, dentro do **registro do app** que está no buffer (o nome como está gravado).
        /// Devolve se o valor foi gravado.
        /// </summary>
        private static bool GravarLm(
            Transaction transacao,
            Database banco,
            BlockReference bloco,
            IReadOnlyList<TypedXData> valores,
            ItemDoDispositivo item,
            Resultado resultado)
        {
            int lmDoDesenho = XDataNumero.Inteiro(
                valores[DispositivoDaListaEdicao.IndiceDoLmNoXData].Valor);
            if (!DispositivoDaListaEdicao.PrecisaGravarLm(lmDoDesenho, item.Lm))
            {
                resultado.LmIguais++;
                return false;
            }

            string appName = valores[0].Valor as string;
            bool trocou;
            // O `new TypedValue(1071, disp.iLM1)` do `GravarXDataDispPrincipal`: o tipo do `iLM1` no
            // array do original é 1071, e é com ele que o valor volta.
            IReadOnlyList<TypedXData> novos = TrocarUmValor(
                bloco.XData,
                appName,
                DispositivoDaListaEdicao.IndiceDoLmNoXData,
                item.Lm,
                out trocou);
            if (!trocou)
            {
                resultado.RegistroNaoAchado++;
                return false;
            }

            BornesDaCorrecao.GarantirAppName(transacao, banco, appName);
            bloco.UpgradeOpen();
            bloco.XData = BornesDaCorrecao.ParaResultBuffer(novos);
            resultado.LmGravados++;
            return true;
        }

        /// <summary>O <c>iLM1</c> do registro lido (o painel já foi validado em <see cref="AbrirDispositivo"/>).</summary>
        private static int LerLm(BlockReference bloco, IReadOnlyList<TypedXData> valores)
        {
            ResultBuffer xdata = bloco.GetXDataForApplication(valores[0].Valor as string) ?? bloco.XData;
            IReadOnlyList<TypedXData> lidos = XDataNeutro.Para(xdata);
            if (lidos.Count <= DispositivoDaListaEdicao.IndiceDoLmNoXData)
            {
                return 0;
            }

            return XDataNumero.Inteiro(lidos[DispositivoDaListaEdicao.IndiceDoLmNoXData].Valor);
        }

        /// <summary>
        /// Os três atributos do <c>AtualizaValorDeUmAtributo</c>: casa o tag **sem caixa** (o
        /// `val7.Tag.ToUpper() = sAttributo.ToUpper()` do original e o `TextCompare` dele) e grava só
        /// o texto que **difere**. O tag que o bloco não tem é contado, não é erro.
        /// </summary>
        private static void GravarAtributos(
            Transaction transacao,
            BlockReference bloco,
            IReadOnlyList<AtributoDoDispositivo> atributos,
            Resultado resultado)
        {
            foreach (AtributoDoDispositivo atributo in atributos)
            {
                bool achou = false;
                foreach (ObjectId id in bloco.AttributeCollection)
                {
                    AttributeReference referencia =
                        transacao.GetObject(id, OpenMode.ForRead) as AttributeReference;
                    if (referencia == null
                        || !string.Equals(
                            referencia.Tag ?? string.Empty,
                            atributo.Tag ?? string.Empty,
                            StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    achou = true;
                    string valor = atributo.Valor ?? string.Empty;
                    if (string.Equals(referencia.TextString ?? string.Empty, valor, StringComparison.Ordinal))
                    {
                        resultado.AtributosIguais++;
                        break;
                    }

                    referencia.UpgradeOpen();
                    referencia.TextString = valor;
                    resultado.AtributosGravados++;
                    break;
                }

                if (!achou)
                {
                    resultado.AtributosNaoAchados++;
                }
            }
        }

        /// <summary>
        /// Troca **um valor** do registro do app dentro do buffer inteiro do bloco, preservando os
        /// outros app names (o mesmo idioma da rodada 77). Devolve o buffer novo e, na saída,
        /// <paramref name="trocou"/> diz se o app name está lá e o índice existe.
        /// </summary>
        private static IReadOnlyList<TypedXData> TrocarUmValor(
            ResultBuffer todos,
            string appName,
            int indice,
            object valor,
            out bool trocou)
        {
            trocou = false;
            List<TypedXData> saida = new List<TypedXData>();
            IReadOnlyList<TypedXData> valores = XDataNeutro.Para(todos);

            int i = 0;
            while (i < valores.Count)
            {
                bool ehOApp = valores[i].Codigo == 1001 &&
                    string.Equals(valores[i].Valor as string, appName, StringComparison.OrdinalIgnoreCase);
                if (!ehOApp)
                {
                    saida.Add(valores[i]);
                    i++;
                    continue;
                }

                saida.Add(valores[i]);
                i++;
                // O `indice` conta o 1001 como 0 (o `valores[indice]` do leitor); o `k`, os valores
                // depois dele — por isso começa em 1.
                int k = 1;
                while (i < valores.Count && valores[i].Codigo != 1001)
                {
                    if (k == indice)
                    {
                        saida.Add(new TypedXData(1071, valor));
                        trocou = true;
                    }
                    else
                    {
                        saida.Add(valores[i]);
                    }

                    k++;
                    i++;
                }
            }

            return saida;
        }
    }
}
