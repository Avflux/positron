using System.Collections.Generic;
using Positron.Data.Paginas;

namespace Positron.Data.Interligacao
{
    /// <summary>
    /// O **Excel ativo** do <c>frmEstatisticaDeCabos</c>: o
    /// <c>Relatorios_EstatisticaCaboEXCEL.ExportaEstatisticaExcel(dg, itipo)</c> do reverso, mais o
    /// <c>ExcFuncoesExcel.VerificaExcel</c>/<c>TrocaBarra</c> que ele usa (a aba é **nomeada**, não a
    /// ativa — diferente da ponte dos títulos, que usa o <c>VerificaExcelAtivo</c>).
    ///
    /// A regra aqui é **pura**: monta o nome da aba, as três colunas e o que deve ser escrito na
    /// planilha (o texto já com o apóstrofo do original, que força o Excel a tratar o valor como
    /// texto). Quem fala com o <c>Microsoft.Office.Interop.Excel</c> é o adapter do plugin
    /// (<c>Positron.Plugin/Interface/Excel/ExcelAtivoDaEstatisticaDeCabos.cs</c>).
    /// </summary>
    public static class ExcelDaEstatisticaDeCabos
    {
        /// <summary>O prefixo do nome da aba (<c>"DIF_" +</c> o agrupamento, `Relatorios_EstatisticaCaboEXCEL.cs:32`).</summary>
        public const string PrefixoDaAba = "DIF_";

        /// <summary>O corte do nome da aba (o <c>if (num2 &gt; 31) num2 = 31</c> do `TrocaBarra`).</summary>
        public const int LimiteDoNomeDaAba = 31;

        /// <summary>O nome usado quando o nome da aba vem vazio (o <c>Plan1</c> do `VerificaExcel`).</summary>
        public const string NomePadraoDaAba = "Plan1";

        /// <summary>A faixa do cabeçalho (o <c>"A1:C1"</c> do original, com negrito e as bordas).</summary>
        public const string FaixaDoCabecalho = "A1:C1";

        /// <summary>A célula selecionada no fim da exportação (o <c>Range("A1").Select()</c>).</summary>
        public const string CelulaSelecionada = "A1";

        /// <summary>As larguras das três colunas, na ordem do original (`:38, :48, :58`).</summary>
        private static readonly double[] Larguras = { 12, 40, 15 };

        /// <summary>
        /// O texto do grupo — as `mMensagem` 1285 (Formação), 1430 (Função) e 1248 (Trajeto). É o
        /// mesmo rótulo que a grade e o título da janela usam.
        /// </summary>
        public static string Rotulo(AgrupamentoDeCabos agrupamento)
        {
            switch (agrupamento)
            {
                case AgrupamentoDeCabos.Funcao: return "Função";
                case AgrupamentoDeCabos.Trajeto: return "Trajeto";
                default: return "Formação";
            }
        }

        /// <summary>
        /// O nome da aba: `"DIF_"` + o grupo sem `ç`/`ã` (`:31-32`) e, como o `VerificaExcel` faz,
        /// passado pelo <see cref="TrocaBarra"/> — `DIF_FORMACAO`, `DIF_FUNCAO`, `DIF_TRAJETO`.
        /// </summary>
        public static string NomeDaAba(AgrupamentoDeCabos agrupamento)
        {
            return NomeDaAbaDe(Rotulo(agrupamento));
        }

        /// <summary>O nome da aba a partir do texto do grupo (o caminho do <c>ExportaEstatisticaExcel</c>).</summary>
        public static string NomeDaAbaDe(string rotulo)
        {
            string nome = PrefixoDaAba + SemAcento(rotulo ?? string.Empty);
            return TrocaBarra(nome);
        }

        /// <summary>As duas trocas de acento do original (`:31-32`) — só `ç` e `ã`.</summary>
        public static string SemAcento(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return string.Empty;
            }

            return texto.Replace("ç", "c").Replace("ã", "a");
        }

        /// <summary>
        /// O `TrocaBarra` (`ExcFuncoesExcel.cs:886-944`): todo caractere fora de `0-9A-Za-z` vira `_`,
        /// menos os que o original preserva (`/` vira `|`; `? ! * @ # $ % & - ( )`, espaço, `Ã`, `É` e
        /// `Ç` ficam como estão); o nome é **cortado em 31** caracteres e **sobe para maiúsculas**.
        ///
        /// O `Strings.Asc` do original devolve o código na **página de código do sistema**, e não o
        /// `char` Unicode; para o que esta ponte produz (`DIF_FORMACAO`…) os dois coincidem.
        /// </summary>
        public static string TrocaBarra(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return string.Empty;
            }

            string trocado = string.Empty;
            foreach (char caractere in nome)
            {
                trocado += TrocaUmCaractere(caractere);
            }

            if (trocado.Length > LimiteDoNomeDaAba)
            {
                trocado = trocado.Substring(0, LimiteDoNomeDaAba);
            }

            return trocado.ToUpperInvariant();
        }

        private static string TrocaUmCaractere(char caractere)
        {
            if ((caractere >= '0' && caractere <= '9') || (caractere >= 'A' && caractere <= 'Z')
                || (caractere >= 'a' && caractere <= 'z'))
            {
                return caractere.ToString();
            }

            switch (caractere)
            {
                case '/': return "|";
                case '?':
                case '!':
                case '*':
                case '@':
                case '#':
                case '$':
                case '%':
                case '&':
                case '-':
                case '(':
                case ')':
                case ' ':
                case 'Ã':
                case 'É':
                case 'Ç': return caractere.ToString();
                default: return "_";
            }
        }

        /// <summary>
        /// O plano da exportação (`Relatorios_EstatisticaCaboEXCEL.cs:35-92`): as três colunas do
        /// cabeçalho (largura e título, já com o apóstrofo) e uma linha de planilha por **linha da
        /// grade** — a exportação não recalcula nada, escreve o que a grade mostra.
        ///
        /// Quirk mantido: a faixa dos dados é `A2:C{última linha escrita}`; com a grade vazia a última
        /// linha é `1` e a faixa sai **invertida** (`A2:C1`), que o Excel normaliza.
        /// </summary>
        public static PlanoDaEstatisticaDeCabos Exportar(
            IReadOnlyList<IReadOnlyList<string>> linhasDaGrade,
            AgrupamentoDeCabos agrupamento)
        {
            string rotulo = Rotulo(agrupamento);
            var plano = new PlanoDaEstatisticaDeCabos
            {
                NomeDaAba = NomeDaAbaDe(rotulo),
                Rotulo = rotulo,
                FaixaDoCabecalho = FaixaDoCabecalho,
            };

            // A coluna do grupo é a `mMensagem` do agrupamento; a da contagem é `"#" + 514` sem o
            // espaço que a grade usa ("# Cabos"), como o original escreve no Excel.
            plano.Colunas.Add(new ColunaDaEstatistica(0, "'#Cabos", Larguras[0]));
            plano.Colunas.Add(new ColunaDaEstatistica(1, "'" + rotulo, Larguras[1]));
            plano.Colunas.Add(new ColunaDaEstatistica(2, "'Comprimento", Larguras[2]));

            int numero = 1;
            if (linhasDaGrade != null)
            {
                foreach (IReadOnlyList<string> linha in linhasDaGrade)
                {
                    numero++;
                    plano.Linhas.Add(new LinhaDaEstatisticaDaPlanilha(
                        numero,
                        "'" + Texto(Celula(linha, 0)),
                        "'" + Texto(Celula(linha, 1)),
                        "'" + Texto(Celula(linha, 2))));
                }
            }

            plano.FaixaDosDados = "A2:C" + numero;
            return plano;
        }

        private static string Celula(IReadOnlyList<string> linha, int coluna)
        {
            return linha != null && coluna >= 0 && coluna < linha.Count ? linha[coluna] : null;
        }

        /// <summary>O `TiraNothing` do `clsTextos` (`:54`): a célula vazia vira texto vazio.</summary>
        private static string Texto(string valor)
        {
            return valor ?? string.Empty;
        }
    }

    /// <summary>Uma coluna do cabeçalho da aba: o endereço (`A1`/`B1`/`C1`), o título e a largura.</summary>
    public sealed class ColunaDaEstatistica
    {
        public ColunaDaEstatistica(int indice, string titulo, double largura)
        {
            Indice = indice;
            Titulo = titulo;
            Largura = largura;
        }

        /// <summary>O índice da coluna (0 = A).</summary>
        public int Indice { get; }

        /// <summary>O texto do cabeçalho, já com o apóstrofo do original.</summary>
        public string Titulo { get; }

        public double Largura { get; }

        /// <summary>A célula da linha 1 (o endereço que o original usa).</summary>
        public string Endereco
        {
            get { return ExcelDosTitulos.Endereco(Indice, 1); }
        }
    }

    /// <summary>Uma linha de dados da aba: o número e os três valores (já com o apóstrofo).</summary>
    public sealed class LinhaDaEstatisticaDaPlanilha
    {
        public LinhaDaEstatisticaDaPlanilha(int numero, string contagem, string grupo, string comprimento)
        {
            Numero = numero;
            Contagem = contagem;
            Grupo = grupo;
            Comprimento = comprimento;
        }

        /// <summary>A linha da planilha (2 em diante).</summary>
        public int Numero { get; }

        /// <summary>A coluna A (quantos cabos no grupo).</summary>
        public string Contagem { get; }

        /// <summary>A coluna B (o valor do agrupamento).</summary>
        public string Grupo { get; }

        /// <summary>A coluna C (a soma dos comprimentos).</summary>
        public string Comprimento { get; }

        /// <summary>O endereço de uma das três células (0 = A).</summary>
        public string Endereco(int coluna)
        {
            return ExcelDosTitulos.Endereco(coluna, Numero);
        }

        /// <summary>O valor de uma das três células (0 = A).</summary>
        public string Valor(int coluna)
        {
            switch (coluna)
            {
                case 0: return Contagem;
                case 1: return Grupo;
                default: return Comprimento;
            }
        }
    }

    /// <summary>O plano do <c>ExportaEstatisticaExcel</c>: o que escrever e formatar na aba.</summary>
    public sealed class PlanoDaEstatisticaDeCabos
    {
        public PlanoDaEstatisticaDeCabos()
        {
            Colunas = new List<ColunaDaEstatistica>();
            Linhas = new List<LinhaDaEstatisticaDaPlanilha>();
        }

        /// <summary>O nome da aba (`DIF_FORMACAO`, `DIF_FUNCAO`, `DIF_TRAJETO`).</summary>
        public string NomeDaAba { get; set; }

        /// <summary>O texto do agrupamento (Formação/Função/Trajeto).</summary>
        public string Rotulo { get; set; }

        public List<ColunaDaEstatistica> Colunas { get; }

        /// <summary>`A1:C1` — negrito, borda interna e externa.</summary>
        public string FaixaDoCabecalho { get; set; }

        public List<LinhaDaEstatisticaDaPlanilha> Linhas { get; }

        /// <summary>`A2:C{última linha escrita}` — borda interna e externa.</summary>
        public string FaixaDosDados { get; set; }
    }
}
