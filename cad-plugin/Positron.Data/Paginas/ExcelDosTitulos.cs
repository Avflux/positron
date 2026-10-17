using System;
using System.Collections.Generic;

namespace Positron.Data.Paginas
{
    /// <summary>
    /// O **Excel ativo** da tela `frmEditaTitulos`: o `clsTextos.ExportaPaginas`
    /// (`clsTextos.cs:1059-1213`) e o `ImportaTitulos` (`:1214-1306`) mais o que a tela faz com o que
    /// voltou da planilha (`frmEditaTitulos.cs:875-936`).
    ///
    /// A regra aqui é **pura**: ela monta o que deve ser escrito (ou lê o que foi lido) na forma de
    /// dados — colunas, células, faixas de borda, cores e mudanças na grade. Quem fala com o
    /// `Microsoft.Office.Interop.Excel` é o adapter do plugin
    /// (`Positron.Plugin/Interface/Excel/ExcelAtivoDosTitulos.cs`).
    ///
    /// As colunas são as da grade e da planilha, na mesma ordem (`A`..`G`):
    /// `Página | Título 1 | Título 2 | Título 3 | Título 4 | Unidade | Alternativo`.
    /// </summary>
    public static class ExcelDosTitulos
    {
        /// <summary>O número da coluna do alternativo na grade e na planilha (0 = A).</summary>
        public const int ColunaDoAlternativo = 6;

        /// <summary>O número da coluna da unidade (0 = F).</summary>
        public const int ColunaDaUnidade = 5;

        /// <summary>A cor da faixa alternada das linhas (`Interior.ColorIndex = 36`).</summary>
        public const int CorDaLinhaAlternada = 36;

        /// <summary>A cor do aviso pintado na célula (`PintaCelula(..., cor 3)`).</summary>
        public const int CorDoAviso = 3;

        /// <summary>O limite de caracteres do alternativo (`Strings.Len(text) &gt; 20`).</summary>
        public const int LimiteDoAlternativo = 20;

        /// <summary>As larguras das colunas do cabeçalho, na ordem do original.</summary>
        private static readonly double[] Larguras = { 10, 50, 50, 50, 50, 15, 20 };

        /// <summary>
        /// Os títulos das colunas do cabeçalho — as `mMensagem` 9 (A), 40..43 (B..E), 11 (F) e 10 (G).
        /// </summary>
        private static readonly string[] TitulosDasColunas = { "Página", "Título 1", "Título 2", "Título 3", "Título 4", "Unidade", "Alternativo" };

        /// <summary>
        /// O **ano** do AutoCAD a partir do `major.minor` — a tabela do `Geral.CADVersion()`
        /// (`Geral.cs:1574-1690`): `23.1` = 2020, `24.0` = 2021, `24.1` = 2022, `24.2` = 2023,
        /// `24.3` = 2024, `25.0`/`25.1` = 2025 e `26.0` = 2026; fora da tabela o original devolve
        /// `"?"` (aqui, <c>0</c>).
        /// </summary>
        public static int AnoDoAutoCad(string majorMenor)
        {
            switch (majorMenor)
            {
                case "18.0": return 2010;
                case "18.1": return 2011;
                case "18.2": return 2012;
                case "19.0": return 2013;
                case "19.1": return 2014;
                case "20.0": return 2015;
                case "20.1": return 2016;
                case "21.0": return 2017;
                case "22.0": return 2018;
                case "23.0": return 2019;
                case "23.1": return 2020;
                case "24.0": return 2021;
                case "24.1": return 2022;
                case "24.2": return 2023;
                case "24.3": return 2024;
                case "25.0":
                case "25.1": return 2025;
                case "26.0": return 2026;
                default: return 0;
            }
        }

        /// <summary>
        /// A versão do CAD na forma do <c>Geral.CADVersion()</c>: `A_2020` no AutoCAD (o
        /// <c>Autodesk.AutoCAD.ApplicationServices.Application</c>) e `Z_2026` no ZWCAD; ano 0 vira
        /// `A_?`/`Z_?`, como o `"?"` do original.
        /// </summary>
        public static string VersaoDoCad(bool autodesk, int ano)
        {
            return (autodesk ? "A_" : "Z_") + (ano > 0 ? ano.ToString() : "?");
        }

        /// <summary>
        /// O `DesativaCalculoExcel` (`ExcFuncoesExcel.cs:395-416`): desliga o cálculo **exceto** quando
        /// a versão do CAD é `A_2025`/`A_2026`/`A_2027` — e aí ele chama o `AtivaCalculOExcel`
        /// (quirk do original: no AutoCAD 2025+ o cálculo fica **ligado**).
        /// </summary>
        public static bool DesligaOCalculo(string versaoDoCad)
        {
            return versaoDoCad != "A_2025" && versaoDoCad != "A_2026" && versaoDoCad != "A_2027";
        }

        /// <summary>A letra da coluna **1-based** (o <c>mudaNumeroAsc</c> do original: 1 = A).</summary>
        public static string LetraDaColuna(int coluna)
        {
            string letra = string.Empty;
            long numero = coluna;
            while (numero > 0)
            {
                letra = (char)((numero - 1) % 26 + 'A') + letra;
                numero = (numero - 1) / 26;
            }

            return letra;
        }

        /// <summary>
        /// O endereço de uma célula (o <c>"A" + linha</c> do original). <paramref name="coluna"/> é o
        /// índice da **grade** (0 = A), então a letra sai de <c>coluna + 1</c>.
        /// </summary>
        public static string Endereco(int coluna, int linha)
        {
            return LetraDaColuna(coluna + 1) + linha;
        }

        /// <summary>O título da coluna (o texto do cabeçalho da planilha).</summary>
        public static string TituloDaColuna(int coluna)
        {
            return coluna >= 0 && coluna < TitulosDasColunas.Length ? TitulosDasColunas[coluna] : string.Empty;
        }

        /// <summary>A largura da coluna: 0 quando a coluna está escondida (o original usa 0).</summary>
        public static double LarguraDaColuna(int coluna)
        {
            return coluna >= 0 && coluna < Larguras.Length ? Larguras[coluna] : 0;
        }

        /// <summary>A coluna está visível? (o título existe no formato / o alternativo está ligado).</summary>
        public static bool ColunaVisivel(int coluna, bool[] titulos, bool alternativo)
        {
            if (coluna == ColunaDoAlternativo)
            {
                return alternativo;
            }

            if (coluna >= 1 && coluna <= 4)
            {
                return TituloLigado(titulos, coluna);
            }

            return true;
        }

        /// <summary>O título do índice 1..4 existe neste formato (os `bTitulo1..4`)?</summary>
        public static bool TituloLigado(bool[] titulos, int indice)
        {
            return titulos != null && indice >= 1 && indice < titulos.Length && titulos[indice];
        }

        /// <summary>
        /// O **plano de exportação** do `ExportaPaginas` (`clsTextos.cs:1059-1213`): o cabeçalho, as
        /// larguras (0 = escondida), as linhas com o valor de cada célula e a faixa que recebe borda
        /// interna e a cor alternada.
        /// </summary>
        public static PlanoDaPlanilha Exportar(IReadOnlyList<LinhaDeTitulosDaGrade> linhas, bool[] titulos, bool alternativo)
        {
            linhas = linhas ?? new List<LinhaDeTitulosDaGrade>();

            int ultima = alternativo ? ColunaDoAlternativo : ColunaDaUnidade;
            int ultimaLinha = linhas.Count + 1;
            var colunas = new List<ColunaDaPlanilha>();
            for (int coluna = 0; coluna <= ColunaDoAlternativo; coluna++)
            {
                bool visivel = ColunaVisivel(coluna, titulos, alternativo);
                colunas.Add(new ColunaDaPlanilha(coluna, TituloDaColuna(coluna), visivel ? LarguraDaColuna(coluna) : 0));
            }

            var plano = new PlanoDaPlanilha
            {
                Colunas = colunas,
                // `Range("A1:G{RowCount+1}")`: fonte 10 e centralizado; `Range("E2:G{RowCount+1}")`: quebra.
                FaixaDoTitulo = "A1:G" + ultimaLinha,
                FaixaDaQuebra = "E2:G" + ultimaLinha,
                FaixaDoCabecalho = "A1:G1",
                TotalDePassos = linhas.Count - 1,
            };

            for (int i = 0; i < linhas.Count; i++)
            {
                int numero = i + 2;
                var linha = new LinhaDaPlanilha { Numero = numero };
                // O apóstrofo do original força o Excel a tratar o valor como texto. Só a coluna da
                // página não recebe `WrapText` (o original liga a quebra em B..E e em F/G).
                linha.Celulas.Add(new CelulaDaPlanilha(Endereco(0, numero), "'" + (linhas[i].Pagina ?? string.Empty), false));
                for (int titulo = 1; titulo <= 4; titulo++)
                {
                    if (TituloLigado(titulos, titulo))
                    {
                        linha.Celulas.Add(new CelulaDaPlanilha(Endereco(titulo, numero),
                            "'" + (linhas[i].Titulo(titulo) ?? string.Empty), true));
                    }
                }

                linha.Celulas.Add(new CelulaDaPlanilha(Endereco(ColunaDaUnidade, numero),
                    "'" + (linhas[i].Unidade ?? string.Empty), true));
                if (alternativo)
                {
                    linha.Celulas.Add(new CelulaDaPlanilha(Endereco(ColunaDoAlternativo, numero),
                        "'" + (linhas[i].Alternativo ?? string.Empty), true));
                }

                linha.Faixa = "A" + numero + ":" + LetraDaColuna(ultima + 1) + numero;
                // A flag do original começa `false`: a PRIMEIRA linha de dados é pintada, e daí alterna.
                linha.Colorida = i % 2 == 0;
                plano.Linhas.Add(linha);
            }

            return plano;
        }

        /// <summary>
        /// Lê as linhas da planilha como o `ImportaTitulos` (`clsTextos.cs:1214-1306`): uma entrada por
        /// título existente (índices 1..4), a **unidade** (índice 5, sempre) e o **alternativo**
        /// (índice 6, só com o alternativo ligado). O `G` com mais de
        /// <see cref="LimiteDoAlternativo"/> caracteres é truncado e a célula entra em
        /// <see cref="LeituraDaPlanilha.Avisos"/>.
        ///
        /// <paramref name="linhas"/> são as linhas **de dados** da aba (a linha 2 em diante); a primeira
        /// da lista é a linha 2. A linha **sem a coluna A** não lê nada, mas **entra** na leitura — é o
        /// que o original faz (as entradas são acrescentadas fora do `if` da coluna A).
        /// </summary>
        public static LeituraDaPlanilha Importar(IReadOnlyList<IReadOnlyList<string>> linhas, bool[] titulos, bool alternativo)
        {
            var leitura = new LeituraDaPlanilha();
            if (linhas == null)
            {
                return leitura;
            }

            for (int i = 0; i < linhas.Count; i++)
            {
                int numero = i + 2;
                IReadOnlyList<string> celulas = linhas[i];
                string pagina = string.Empty;
                string[] valores = new string[ColunaDoAlternativo + 1];
                for (int coluna = 0; coluna <= ColunaDoAlternativo; coluna++)
                {
                    valores[coluna] = string.Empty;
                }

                if (Celula(celulas, 0) != null)
                {
                    pagina = Celula(celulas, 0);
                    for (int coluna = 1; coluna <= ColunaDoAlternativo; coluna++)
                    {
                        valores[coluna] = Celula(celulas, coluna) ?? string.Empty;
                    }

                    if (valores[ColunaDoAlternativo].Length > LimiteDoAlternativo)
                    {
                        valores[ColunaDoAlternativo] = valores[ColunaDoAlternativo].Substring(0, LimiteDoAlternativo);
                        leitura.Avisos.Add(new AvisoDaPlanilha
                        {
                            Linha = numero,
                            Endereco = Endereco(ColunaDoAlternativo, numero),
                            Mensagem = Interface.MensagensDoReverso.MaximoDe20Caracteres,
                            CorIndice = CorDoAviso,
                        });
                    }
                }

                for (int titulo = 1; titulo <= 4; titulo++)
                {
                    if (TituloLigado(titulos, titulo))
                    {
                        leitura.Titulos.Add(new TituloImportado { Pagina = pagina, Indice = titulo, Texto = valores[titulo] });
                    }
                }

                leitura.Titulos.Add(new TituloImportado { Pagina = pagina, Indice = ColunaDaUnidade, Texto = valores[ColunaDaUnidade] });
                if (alternativo)
                {
                    leitura.Titulos.Add(new TituloImportado
                    {
                        Pagina = pagina,
                        Indice = ColunaDoAlternativo,
                        Texto = valores[ColunaDoAlternativo],
                    });
                }
            }

            return leitura;
        }

        /// <summary>
        /// O que a tela muda na grade com o que voltou da planilha (`frmEditaTitulos.cs:903-936`): casa
        /// **página** (comparação sem caixa) e **índice** e escreve na coluna do índice **só quando o
        /// valor é diferente** (também sem caixa). A unidade (índice 5) não depende de flag; o
        /// alternativo (índice 6) só entra com o alternativo ligado.
        ///
        /// A comparação é contra o valor **corrente** da grade: uma entrada posterior que caia na mesma
        /// célula compara com o que a anterior escreveu — como no original, que escreve célula a célula
        /// dentro do laço.
        /// </summary>
        public static IReadOnlyList<MudancaNaGrade> AplicarNaGrade(IReadOnlyList<LinhaDeTitulosDaGrade> grade,
            IReadOnlyList<TituloImportado> importados, bool[] titulos, bool alternativo)
        {
            var mudancas = new List<MudancaNaGrade>();
            if (grade == null || importados == null)
            {
                return mudancas;
            }

            var corrente = new List<string[]>();
            foreach (LinhaDeTitulosDaGrade linha in grade)
            {
                var valores = new string[ColunaDoAlternativo + 1];
                for (int coluna = 0; coluna <= ColunaDoAlternativo; coluna++)
                {
                    valores[coluna] = linha.Coluna(coluna) ?? string.Empty;
                }

                corrente.Add(valores);
            }

            for (int i = 0; i < corrente.Count; i++)
            {
                foreach (TituloImportado importado in importados)
                {
                    int coluna = importado.Indice;
                    if (coluna < 1 || coluna > ColunaDoAlternativo)
                    {
                        continue;
                    }

                    if (coluna >= 1 && coluna <= 4 && !TituloLigado(titulos, coluna))
                    {
                        continue;
                    }

                    if (coluna == ColunaDoAlternativo && !alternativo)
                    {
                        continue;
                    }

                    if (!string.Equals(corrente[i][0], importado.Pagina, StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    if (string.Equals(corrente[i][coluna], importado.Texto, StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    corrente[i][coluna] = importado.Texto ?? string.Empty;
                    mudancas.Add(new MudancaNaGrade { Linha = i, Coluna = coluna, Valor = corrente[i][coluna] });
                }
            }

            return mudancas;
        }

        private static string Celula(IReadOnlyList<string> celulas, int coluna)
        {
            return celulas != null && coluna >= 0 && coluna < celulas.Count ? celulas[coluna] : null;
        }
    }

    /// <summary>Uma linha da grade de títulos (o `dg.Rows[i]` do `frmEditaTitulos`).</summary>
    public sealed class LinhaDeTitulosDaGrade
    {
        public LinhaDeTitulosDaGrade(string pagina, TitulosDaPagina titulos, string unidade, string alternativo)
        {
            Pagina = pagina;
            Titulos = titulos ?? new TitulosDaPagina();
            Unidade = unidade;
            Alternativo = alternativo;
        }

        public string Pagina { get; }

        public TitulosDaPagina Titulos { get; }

        public string Unidade { get; }

        public string Alternativo { get; }

        /// <summary>O título do índice 1..4.</summary>
        public string Titulo(int indice)
        {
            return Titulos.De(indice) ?? string.Empty;
        }

        /// <summary>O valor da coluna como a grade o mostra (0 = Página … 6 = Alternativo).</summary>
        public string Coluna(int coluna)
        {
            switch (coluna)
            {
                case 0: return Pagina;
                case 1:
                case 2:
                case 3:
                case 4: return Titulo(coluna);
                case ExcelDosTitulos.ColunaDaUnidade: return Unidade;
                case ExcelDosTitulos.ColunaDoAlternativo: return Alternativo;
                default: return string.Empty;
            }
        }
    }

    /// <summary>Uma coluna da planilha: o texto do cabeçalho e a largura (0 = escondida).</summary>
    public sealed class ColunaDaPlanilha
    {
        public ColunaDaPlanilha(int indice, string titulo, double largura)
        {
            Indice = indice;
            Titulo = titulo;
            Largura = largura;
        }

        public int Indice { get; }

        public string Letra { get { return ExcelDosTitulos.LetraDaColuna(Indice); } }

        public string Titulo { get; }

        public double Largura { get; }

        public bool Visivel { get { return Largura > 0; } }
    }

    /// <summary>Uma célula a escrever (o endereço e o valor — já com o apóstrofo do original).</summary>
    public sealed class CelulaDaPlanilha
    {
        public CelulaDaPlanilha(string endereco, string valor, bool quebraTexto)
        {
            Endereco = endereco;
            Valor = valor;
            QuebraTexto = quebraTexto;
        }

        public string Endereco { get; }

        public string Valor { get; }

        /// <summary>Recebe `WrapText = true` (o original liga a quebra em cada célula menos a da página).</summary>
        public bool QuebraTexto { get; }
    }

    /// <summary>Uma linha de dados da planilha.</summary>
    public sealed class LinhaDaPlanilha
    {
        public LinhaDaPlanilha()
        {
            Celulas = new List<CelulaDaPlanilha>();
        }

        public int Numero { get; set; }

        public List<CelulaDaPlanilha> Celulas { get; }

        /// <summary>A faixa da linha (`A2:F2`): borda interna e quebra de linha.</summary>
        public string Faixa { get; set; }

        /// <summary>Recebe a cor da faixa alternada (`Interior.ColorIndex = 36`).</summary>
        public bool Colorida { get; set; }
    }

    /// <summary>O plano do `ExportaPaginas`: o que escrever e formatar na aba.</summary>
    public sealed class PlanoDaPlanilha
    {
        public PlanoDaPlanilha()
        {
            Colunas = new List<ColunaDaPlanilha>();
            Linhas = new List<LinhaDaPlanilha>();
        }

        public List<ColunaDaPlanilha> Colunas { get; set; }

        /// <summary>`A1:G{n}` — fonte 10 e alinhamento centralizado.</summary>
        public string FaixaDoTitulo { get; set; }

        /// <summary>`E2:G{n}` — quebra de linha automática.</summary>
        public string FaixaDaQuebra { get; set; }

        /// <summary>
        /// `A1:G1` — a faixa do cabeçalho que recebe borda interna. O original chama o
        /// `CriaLinhasInterna` uma vez por coluna, com a faixa **cumulativa** (`A1:A1`, `A1:B1`, …,
        /// `A1:G1`); o efeito final é o da última, que é o que está aqui.
        /// </summary>
        public string FaixaDoCabecalho { get; set; }

        public List<LinhaDaPlanilha> Linhas { get; set; }

        /// <summary>
        /// A `Quantidade` da barra de progresso do original: `dg.RowCount - 1` (o total anunciado é
        /// uma linha a menos do que os `pbPasso` que ele dispara — a barra é o recorte pendente do
        /// "progresso compartilhado").
        /// </summary>
        public int TotalDePassos { get; set; }
    }

    /// <summary>Uma entrada do que o `ImportaTitulos` monta (o `mTitulos[]` do original).</summary>
    public sealed class TituloImportado
    {
        public string Pagina { get; set; }

        /// <summary>1..4 = títulos, 5 = unidade, 6 = alternativo.</summary>
        public int Indice { get; set; }

        public string Texto { get; set; }
    }

    /// <summary>O que a leitura da planilha devolve.</summary>
    public sealed class LeituraDaPlanilha
    {
        public LeituraDaPlanilha()
        {
            Titulos = new List<TituloImportado>();
            Avisos = new List<AvisoDaPlanilha>();
        }

        public List<TituloImportado> Titulos { get; }

        /// <summary>As células que o original pinta (`PintaCelula` com a mMensagem 1927).</summary>
        public List<AvisoDaPlanilha> Avisos { get; }
    }

    /// <summary>Uma célula que a leitura da planilha manda pintar e comentar.</summary>
    public sealed class AvisoDaPlanilha
    {
        public int Linha { get; set; }

        public string Endereco { get; set; }

        public string Mensagem { get; set; }

        public int CorIndice { get; set; }
    }

    /// <summary>Uma célula da grade que a importação muda.</summary>
    public sealed class MudancaNaGrade
    {
        /// <summary>A linha da grade (0 = a primeira).</summary>
        public int Linha { get; set; }

        public int Coluna { get; set; }

        public string Valor { get; set; }
    }
}
