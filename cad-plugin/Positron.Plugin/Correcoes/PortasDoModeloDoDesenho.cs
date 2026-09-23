using System;
using System.Collections.Generic;
using Positron.Data;
using Positron.Data.Correcoes;
using Positron.Data.Fiacao;
using Positron.Data.Modelos;
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

            /// <summary>Portas que não estão no dicionário (e que o comando indefine).</summary>
            internal int SemPorta { get; set; }

            /// <summary>Portas indefinidas (XData zerado e atributos limpos).</summary>
            internal int Indefinidas { get; set; }

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
                    string handleDaMascara;
                    string handleDaDefinicao;
                    if (!LerPorta(bloco, out indiceModelo, out indiceDaPorta, out handleDaMascara, out handleDaDefinicao))
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
                        // O `IndefineUmaPorta` do fim do laço do original: a porta que não está
                        // no dicionário tem o XData zerado e os atributos limpos.
                        resultado.SemPorta++;
                        if (IndefinirPorta(transacao, bloco))
                        {
                            resultado.Indefinidas++;
                        }

                        continue;
                    }

                    resultado.Casados++;

                    // Os dois `Busca*` do original: o nome da máscara e a página do texto da
                    // definição (a página sai do layer do texto, com prefixo/sufixo vazios —
                    // os campos `Conf.PrefixoCruzInterno`/`SufixoCruzInterno` ainda não existem
                    // no recoder e o padrão assumido é vazio, registrado no RUNBOOK).
                    string nomeDaMascara = NomeDaMascara(transacao, banco, handleDaMascara);
                    string pagina = PaginaDoTexto(transacao, banco, handleDaDefinicao);

                    Aplicar(bloco, transacao, porta, nomeDaMascara, pagina, resultado);
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

        /// <summary>
        /// O <c>verificaTipoDispositivo == "E"</c> e o par do XData Dispositivo (5 e 6),
        /// mais os dois handles que o <c>EditaTodasPortas</c> usa: o da **máscara**
        /// (o <c>array[4]</c>, para o <c>NOME1</c>) e o da **definição** (o <c>array[9]</c>,
        /// para a <c>ORIGEM</c>).
        /// </summary>
        private static bool LerPorta(
            BlockReference bloco,
            out int indiceModelo,
            out int indiceDaPorta,
            out string handleDaMascara,
            out string handleDaDefinicao)
        {
            indiceModelo = 0;
            indiceDaPorta = 0;
            handleDaMascara = null;
            handleDaDefinicao = null;

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
            handleDaMascara = valores[4].Valor as string;
            handleDaDefinicao = valores[9].Valor as string;
            return true;
        }

        /// <summary>
        /// O <c>clsMascara.BuscaNomeDaMascara</c>: o <c>Nome1</c> da máscara (e o <c>Nome2</c>
        /// depois de uma barra, quando preenchido), pelo handle do bloco da máscara.
        /// </summary>
        private static string NomeDaMascara(Transaction transacao, Database banco, string handle)
        {
            BlockReference bloco = BornesDaCorrecao.AbrirPorHandle(transacao, banco, handle);
            if (bloco == null)
            {
                return string.Empty;
            }

            ResultBuffer xdata = bloco.GetXDataForApplication(MascaraXData.AppName);
            MascaraXData mascara;
            if (xdata == null || !MascaraXData.Ler(XDataNeutro.Para(xdata), out mascara))
            {
                return string.Empty;
            }

            string nome = mascara.Nome1 ?? string.Empty;
            if (!string.IsNullOrEmpty(mascara.Nome2))
            {
                nome = nome + "/" + mascara.Nome2;
            }

            return nome;
        }

        /// <summary>
        /// O <c>clsTextos.EncontraPaginaDoTexto</c>: a página é o **layer** do texto da
        /// definição (o original envolve com <c>Conf.PrefixoCruzInterno</c>/
        /// <c>SufixoCruzInterno</c>, que aqui saem vazios).
        /// </summary>
        private static string PaginaDoTexto(Transaction transacao, Database banco, string handle)
        {
            Entity entidade = AbrirEntidade(transacao, banco, handle);
            DBText texto = entidade as DBText;
            return texto == null ? string.Empty : (texto.Layer ?? string.Empty);
        }

        private static Entity AbrirEntidade(Transaction transacao, Database banco, string handle)
        {
            if (string.IsNullOrEmpty(handle))
            {
                return null;
            }

            ObjectId id;
            try
            {
                if (!banco.TryGetObjectId(new Handle(Convert.ToInt64(handle, 16)), out id))
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }

            return transacao.GetObject(id, OpenMode.ForRead) as Entity;
        }

        /// <summary>
        /// O <c>IndefineUmaPorta(handle, bLimpaTudo: true)</c>: zera o <c>indiceDaPorta</c>, o
        /// <c>handleDaDefinicao</c> e a <c>chavePrimaria</c> no XData da porta e roda a
        /// <c>LimpaPorta</c> nos atributos.
        /// </summary>
        private static bool IndefinirPorta(Transaction transacao, BlockReference bloco)
        {
            bloco.UpgradeOpen();
            bloco.XData = ParaResultBuffer(TrocandoOsCamposDaPorta(bloco.XData));

            foreach (ObjectId id in bloco.AttributeCollection)
            {
                AttributeReference atributo = transacao.GetObject(id, OpenMode.ForRead) as AttributeReference;
                if (atributo == null)
                {
                    continue;
                }

                string valor = LimpezaDaPorta.ValorDoAtributoLimpo(
                    atributo.Tag, true, VerificadorTerminalIndefinido);
                if (valor == null)
                {
                    continue;
                }

                if (string.Equals(atributo.TextString ?? string.Empty, valor, StringComparison.Ordinal))
                {
                    continue;
                }

                atributo.UpgradeOpen();
                atributo.TextString = valor;
            }

            return true;
        }

        /// <summary>
        /// Zera os três campos do <c>IndefineUmaPorta</c> no registro <c>Dispositivo</c>: o
        /// <c>indiceDaPorta</c> (o <c>array[6]</c>), o <c>handleDaDefinicao</c> (o <c>array[9]</c>)
        /// e a <c>chavePrimaria</c> (o <c>array[10]</c>), trocando só o registro do app.
        /// </summary>
        private static IReadOnlyList<TypedXData> TrocandoOsCamposDaPorta(ResultBuffer todos)
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
                bool ehDispositivo = valores[i].Codigo == 1001 &&
                    string.Equals(valores[i].Valor as string, DispositivoXData.AppName, StringComparison.Ordinal);
                if (!ehDispositivo)
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
                    if (k == 5 || k == 8 || k == 9)
                    {
                        saida.Add(new TypedXData(valores[i].Codigo, k == 5 ? (object)0 : string.Empty));
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

        private static ResultBuffer ParaResultBuffer(IReadOnlyList<TypedXData> valores)
        {
            TypedValue[] array = new TypedValue[valores.Count];
            for (int i = 0; i < valores.Count; i++)
            {
                array[i] = new TypedValue(valores[i].Codigo, valores[i].Valor);
            }

            return new ResultBuffer(array);
        }

        private static void Aplicar(
            BlockReference bloco,
            Transaction transacao,
            ModeloPorta porta,
            string nomeDaMascara,
            string pagina,
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
                    VerificadorTerminalIndefinido, nomeDaMascara, pagina, out visivel);

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
