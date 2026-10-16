using System.Collections.Generic;
using Positron.Data.Fiacao;

namespace Positron.Data.Correcoes
{
    /// <summary>
    /// O XData do app name <c>CORRECAO</c> do **ModelSpace**: as marcas das **cinco correções
    /// automáticas** que o original roda **uma vez por desenho**, na primeira ativação
    /// (<c>Iniciar.cs:151-186</c> → <c>XDataCorrecao.LerCorrecao</c>/<c>setaCorrecao</c>,
    /// <c>XDataCorrecao.cs</c>).
    ///
    /// O buffer é um registro <c>1001 "CORRECAO"</c> seguido de **30 inteiros** (<c>1070</c>), um por
    /// correção: <c>1</c> = já rodou neste desenho. O original lê o índice e, quando não está marcado,
    /// roda a correção e grava a marca — é por isso que essas correções são **destrutivas e únicas**
    /// (elas consertam um defeito de versão antiga; rodar de novo não é o mesmo que não rodar).
    ///
    /// Os cinco números e as cinco correções, na ordem do <c>IniciarDWG</c>:
    ///
    /// | nº | marca | correção do <c>Correcao.cs</c> | o que faz |
    /// |----|-------|---------------------------------|-----------|
    /// | 1 | <see cref="AppNameDoDispositivo"/> | <c>CorrecaoDisp</c> (<c>:259</c>) | app name legado <c>DISPOSITIVO</c> → <c>Dispositivo</c> |
    /// | 2 | <see cref="BornesVisiveis"/> | <c>CorrecaoBornesVisiveis</c> (<c>:318</c>) | <c>Visivel -1</c> → <c>0</c> no borne |
    /// | 3 | <see cref="TextosDeCircuito"/> | <c>correcaoTextosCircuitos</c> (<c>:397</c>) | texto auxiliar de circuito sai do <c>VerticalMode 1</c> |
    /// | 4 | <see cref="Linhas"/> | <c>correcaoLines</c> (<c>:480</c>) | tira o XData <c>CONEXAO</c>/<c>INTERLIGACAO</c> das <c>Line</c> |
    /// | 5 | <see cref="OrdemDosBornes"/> | <c>corrigeOrdemBornes</c> (<c>:1565</c>) | renumera a <c>Ordem</c> dos bornes por régua |
    ///
    /// Quem lê e grava o XData é o adapter (<c>Positron.Plugin.Correcoes.MarcasDeCorrecaoDoDesenho</c>);
    /// aqui fica só o layout do buffer e as duas decisões — lida? / marcar.
    /// </summary>
    public static class MarcasDeCorrecao
    {
        /// <summary>O app name do XData das marcas (o <c>"CORRECAO"</c> do original).</summary>
        public const string AppName = "CORRECAO";

        /// <summary>O desenho já rodou o <c>CorrecaoDisp</c> (o índice 1 do buffer).</summary>
        public const int AppNameDoDispositivo = 1;

        /// <summary>O desenho já rodou o <c>CorrecaoBornesVisiveis</c> (o índice 2).</summary>
        public const int BornesVisiveis = 2;

        /// <summary>O desenho já rodou o <c>correcaoTextosCircuitos</c> (o índice 3).</summary>
        public const int TextosDeCircuito = 3;

        /// <summary>O desenho já rodou o <c>correcaoLines</c> (o índice 4).</summary>
        public const int Linhas = 4;

        /// <summary>O desenho já rodou o <c>corrigeOrdemBornes</c> (o índice 5).</summary>
        public const int OrdemDosBornes = 5;

        /// <summary>
        /// Quantos valores o buffer do original tem **depois** do <c>1001</c>
        /// (<c>new TypedValue[31]</c> menos o app name, <c>XDataCorrecao.cs:96-105</c>).
        /// </summary>
        public const int NumeroDeMarcas = 30;

        /// <summary>
        /// O buffer do original quando o desenho ainda não tem nenhum: o <c>1001 "CORRECAO"</c> e
        /// **30 zeros** (<c>XDataCorrecao.cs:96-105</c>).
        /// </summary>
        public static IReadOnlyList<TypedXData> Base()
        {
            List<TypedXData> valores = new List<TypedXData>(NumeroDeMarcas + 1);
            valores.Add(new TypedXData(1001, AppName));
            for (int i = 0; i < NumeroDeMarcas; i++)
            {
                valores.Add(new TypedXData(1070, (short)0));
            }

            return valores;
        }

        /// <summary>
        /// O <c>XDataCorrecao.LerCorrecao(numero)</c> (<c>XDataCorrecao.cs:112-155</c>): o buffer é do
        /// app name e o valor do índice é <c>1</c>.
        ///
        /// Diferença deliberada: o original indexa sem conferir o tamanho (um buffer curto derruba o
        /// <c>IniciarDWG</c> inteiro no <c>catch</c> com <c>IndexOutOfRangeException</c>); aqui o buffer
        /// sem o índice responde <c>false</c> e a correção roda, como se a marca não existisse.
        /// </summary>
        public static bool Lida(IReadOnlyList<TypedXData> valores, int numero)
        {
            if (valores == null || numero < 1 || numero >= valores.Count)
            {
                return false;
            }

            if (valores[0].Codigo != 1001 || (valores[0].Valor as string) != AppName)
            {
                return false;
            }

            return XDataNumero.Inteiro(valores[numero].Valor) == 1;
        }

        /// <summary>
        /// O <c>XDataCorrecao.setaCorrecao(numero)</c> (<c>XDataCorrecao.cs:9-110</c>): com o buffer do
        /// app name já no desenho, só o índice pedido vira <c>1</c> e os outros ficam como estão; sem
        /// ele, o buffer nasce do zero (a <see cref="Base"/>) com o índice marcado.
        ///
        /// O original grava o buffer inteiro no ModelSpace a cada marca
        /// (<c>((DBObject)val4).XData = new ResultBuffer(array)</c>): pela regra do <c>setXData</c> do
        /// CAD, isso **troca** o bloco do app name <c>CORRECAO</c> e não toca nos outros app names — é o
        /// mesmo efeito que o adapter faz juntando os blocos.
        /// </summary>
        public static IReadOnlyList<TypedXData> Marcar(IReadOnlyList<TypedXData> valores, int numero)
        {
            List<TypedXData> marcados = new List<TypedXData>();
            bool temBuffer = valores != null && numero >= 1 && numero < valores.Count
                && valores[0].Codigo == 1001 && (valores[0].Valor as string) == AppName;

            if (!temBuffer)
            {
                marcados.AddRange(Base());
            }
            else
            {
                marcados.AddRange(valores);
            }

            marcados[numero] = new TypedXData(1070, (short)1);
            return marcados;
        }
    }
}
