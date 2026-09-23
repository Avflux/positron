using System;
using System.Collections.Generic;
using Positron.Data;
using Positron.Data.Correcoes;
using Positron.Data.Fiacao;
using Positron.Data.Modelos;
using Positron.Plugin.Bornes;
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
    /// <c>CorrigeModelosDeContatos</c> — o par do <c>CorrigeBlocosContatosAux</c> da
    /// rodada 85: aquele reescreve os **terminais** dos blocos auxiliares; este acerta
    /// o **índice do contato** (frente 2 do §7.6, o <c>Correcao.cs</c>).
    ///
    /// A regra está em <see cref="CorrecaoModeloDeContato.Planejar"/>: quando o
    /// <c>Indice</c> de um contato do <c>CONTATOS</c> não é o da sua posição, o desenho
    /// recebe o índice novo — no XData <c>Dispositivo</c> (blocos auxiliares) e no XData
    /// <c>Modelo</c>. Como no precedente da rodada 77, grava-se trocando **só o registro
    /// do app**, preservando os outros (o original troca o buffer inteiro).
    ///
    /// **Fora do recorte, documentado:** a renumeração do **dicionário**
    /// (<c>GravaOsContatosAuxiliarDoModeloDoDicionario</c>) — o leitor do recoder
    /// recalcula a orientação ao ler, então gravar de volta persistiria o valor
    /// recalculado; e o <c>SincronizaContatos</c> do fim.
    /// </summary>
    internal static class ModelosDeContatosDoDesenho
    {
        internal sealed class Resultado
        {
            internal int Modelos { get; set; }

            internal int Contatos { get; set; }

            /// <summary>Ajustes de índice planejados (contatos fora da posição).</summary>
            internal int Ajustes { get; set; }

            /// <summary>Blocos auxiliares (<c>A</c>) lidos.</summary>
            internal int AuxiliaresLidos { get; set; }

            /// <summary>XData <c>Dispositivo</c> regravado com o índice novo.</summary>
            internal int DispositivosAlterados { get; set; }

            /// <summary>XData <c>Modelo</c> regravado com o índice novo.</summary>
            internal int ModelosAlterados { get; set; }

            /// <summary>Modelos cujos contatos foram renumerados no dicionário.</summary>
            internal int DicionariosAlterados { get; set; }
        }

        internal static Resultado Executar()
        {
            Resultado resultado = new Resultado();

            List<ModeloContato> modelos = ContatosDoDesenho.LerModelos();
            resultado.Modelos = modelos.Count;

            List<AjusteDeContato> ajustes = new List<AjusteDeContato>();
            foreach (ModeloContato modelo in modelos)
            {
                List<ContatoAuxiliar> contatos = ContatosDoDesenho.LerAuxiliares(modelo.Indice);
                resultado.Contatos += contatos.Count;
                ajustes.AddRange(CorrecaoModeloDeContato.Planejar(modelo.Indice, contatos));
            }

            // A outra metade do original: renumerar os contatos **no dicionario** (1, 2, 3...),
            // pelos registros crus (o leitor tipado recalcularia a orientacao).
            foreach (ModeloContato modelo in modelos)
            {
                bool mudou;
                IReadOnlyList<ModelosContato.ContatoBruto> brutos = CorrecaoModeloDeContato.Renumerar(
                    ContatosDoDesenho.LerAuxiliaresBrutos(modelo.Indice), out mudou);
                if (!mudou)
                {
                    continue;
                }

                if (ContatosDoDesenho.GravarAuxiliares(modelo.Indice, brutos.Count, brutos))
                {
                    resultado.DicionariosAlterados++;
                }
            }

            resultado.Ajustes = ajustes.Count;
            if (ajustes.Count == 0)
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

                // 1) os blocos auxiliares: o índice novo no XData `Dispositivo`.
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

                    resultado.AuxiliaresLidos++;

                    int novo = CorrecaoModeloDeContato.ContatoNovo(ajustes, indexModelo, indexContato);
                    if (novo < 0)
                    {
                        continue;
                    }

                    BornesDaCorrecao.GarantirAppName(transacao, banco, DispositivoXData.AppName);
                    bloco.UpgradeOpen();
                    bloco.XData = ParaResultBuffer(TrocandoOValor(
                        bloco.XData, DispositivoXData.AppName, IndiceDoDispositivo, novo));
                    resultado.DispositivosAlterados++;
                }

                // 2) o XData `Modelo` (de qualquer bloco que o tenha).
                foreach (ObjectId id in espaco)
                {
                    BlockReference bloco = transacao.GetObject(id, OpenMode.ForRead) as BlockReference;
                    if (bloco == null)
                    {
                        continue;
                    }

                    BlocoModelo dados;
                    if (!LerModelo(bloco, out dados))
                    {
                        continue;
                    }

                    int novo = CorrecaoModeloDeContato.ContatoNovo(
                        ajustes, dados.IndexModelo, dados.IndexContato);
                    if (novo < 0)
                    {
                        continue;
                    }

                    BornesDaCorrecao.GarantirAppName(transacao, banco, ModeloXData.AppName);
                    bloco.UpgradeOpen();
                    bloco.XData = ParaResultBuffer(TrocandoOValor(
                        bloco.XData, ModeloXData.AppName, IndiceDoModelo, novo));
                    resultado.ModelosAlterados++;
                }

                transacao.Commit();
            }

            return resultado;
        }

        /// <summary>O <c>IndexContato</c> no array do <c>Dispositivo</c> (o 6 do reverso).</summary>
        private const int IndiceDoDispositivo = 5;

        /// <summary>O <c>IndexContato</c> no array do <c>Modelo</c> (o 3 do `ModeloXData.Ler`).</summary>
        private const int IndiceDoModelo = 2;

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

        private static bool LerModelo(BlockReference bloco, out BlocoModelo modelo)
        {
            modelo = null;
            ResultBuffer xdata = bloco.GetXDataForApplication(ModeloXData.AppName)
                ?? bloco.GetXDataForApplication(ModeloXData.AppNameLegado);
            return xdata != null && ModeloXData.Ler(XDataNeutro.Para(xdata), out modelo);
        }

        /// <summary>
        /// Troca **um valor** do registro do app dentro do buffer inteiro do bloco,
        /// preservando os outros app names (o precedente da rodada 77).
        /// </summary>
        private static IReadOnlyList<TypedXData> TrocandoOValor(
            ResultBuffer todos,
            string appName,
            int indice,
            object valor)
        {
            List<TypedXData> saida = new List<TypedXData>();
            IReadOnlyList<TypedXData> valores = todos == null ? null : XDataNeutro.Para(todos);
            if (valores == null)
            {
                return saida;
            }

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
                int k = 0;
                while (i < valores.Count && valores[i].Codigo != 1001)
                {
                    saida.Add(k == indice ? new TypedXData(valores[i].Codigo, valor) : valores[i]);
                    k++;
                    i++;
                }
            }

            return saida;
        }

        private static ResultBuffer ParaResultBuffer(IReadOnlyList<TypedXData> valores)
        {
            TypedValue[] array = new TypedValue[valores.Count];
            for (int i = 0; i < valores.Count; i++)
            {
                array[i] = new TypedValue(valores[i].Codigo, valores[i].Valor);
            }

            return new ResultBuffer(array);
        }
    }
}
