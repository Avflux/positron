using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using Positron.Data.Paginas;

namespace Positron.Plugin.Interface.Excel
{
    /// <summary>
    /// A ponte com o **Excel ativo** do `frmEditaTitulos`: o `ExcFuncoesExcel.VerificaExcelAtivo`
    /// (`ExcFuncoesExcel.cs:122-162`), o `LimpaSheet` (`:530-536`), o `DesativaCalculoExcel`/`AtivaCalculOExcel`
    /// (`:395-448`, nas folhas compartilhadas do <see cref="ExcelDoReverso"/>) e a escrita/leitura da
    /// aba do `clsTextos.ExportaPaginas` (`clsTextos.cs:1059-1213`) e do `ImportaTitulos` (`:1214-1306`).
    ///
    /// Aqui a aba é sempre a **ativa** (`VerificaExcelAtivo`), diferente do `VerificaExcel` da
    /// estatística de cabos (`ExcelAtivoDaEstatisticaDeCabos`), que trabalha com a aba **nomeada**.
    ///
    /// O que o **plano** diz (colunas, células, faixas, cores) vem da regra pura
    /// <see cref="ExcelDosTitulos"/>; aqui é só o `Microsoft.Office.Interop.Excel`. É a **mesma PIA**
    /// que o original usa (a `Microsoft.Office.Interop.Excel.dll` do Office, no GAC): o requisito de
    /// ter o Excel instalado é do próprio recurso.
    /// </summary>
    internal static class ExcelAtivoDosTitulos
    {
        /// <summary>
        /// O **Exportar** do menu (`frmEditaTitulos.cs:875-888`): pega (ou cria) o Excel, desliga o
        /// cálculo, limpa a aba e escreve o plano. Devolve o plano — o `TotalDePassos` é o da barra
        /// de progresso da paleta (recorte pendente do "progresso compartilhado").
        /// </summary>
        internal static PlanoDaPlanilha Exportar(IReadOnlyList<LinhaDeTitulosDaGrade> linhas, bool[] titulos, bool alternativo)
        {
            Application aplicacao;
            Worksheet aba;
            Abrir(out aplicacao, out aba);
            try
            {
                ExcelDoReverso.DesativarCalculo(aplicacao);
                LimparAba(aba);
                PlanoDaPlanilha plano = ExcelDosTitulos.Exportar(linhas, titulos, alternativo);
                Escrever(aba, plano);
                return plano;
            }
            finally
            {
                ExcelDoReverso.AtivarCalculo(aplicacao);
                ExcelDoReverso.Liberar(aplicacao, aba);
            }
        }

        /// <summary>
        /// O **Importar** do menu (`frmEditaTitulos.cs:890-917`): lê a aba ativa (o
        /// `ImportaTitulos`), pinta as células com aviso e devolve o que foi lido. Quem aplica na
        /// grade é o <see cref="ExcelDosTitulos.AplicarNaGrade"/>.
        /// </summary>
        internal static LeituraDaPlanilha Ler(bool[] titulos, bool alternativo)
        {
            Application aplicacao;
            Worksheet aba;
            Abrir(out aplicacao, out aba);
            try
            {
                ExcelDoReverso.DesativarCalculo(aplicacao);
                LeituraDaPlanilha leitura = ExcelDosTitulos.Importar(LerLinhas(aba), titulos, alternativo);
                Pintar(aba, leitura.Avisos);
                return leitura;
            }
            finally
            {
                ExcelDoReverso.AtivarCalculo(aplicacao);
                ExcelDoReverso.Liberar(aplicacao, aba);
            }
        }

        /// <summary>O `VerificaExcelAtivo`: a instância aberta (livro e aba ativos) ou uma nova.</summary>
        private static void Abrir(out Application aplicacao, out Worksheet aba)
        {
            Workbook livro;
            if (!ExcelDoReverso.ExcelAberto())
            {
                aplicacao = ExcelDoReverso.NovaInstancia(out livro);
                aba = (Worksheet)aplicacao.ActiveSheet;
                aba.get_Range("A1", Type.Missing).Select();
                return;
            }

            aplicacao = ExcelDoReverso.InstanciaAtiva(out livro);
            aba = (Worksheet)aplicacao.ActiveSheet;
        }

        /// <summary>O `LimpaSheet` (`ExcFuncoesExcel.cs:530-536`).</summary>
        private static void LimparAba(Worksheet aba)
        {
            aba.get_Range("A1", "Z10000").EntireRow.Delete(Type.Missing);
            aba.get_Range("A1", "Z1").ColumnWidth = 8.43;
            aba.Cells.ClearComments();
        }

        private static void Escrever(Worksheet aba, PlanoDaPlanilha plano)
        {
            Range faixa = aba.get_Range(plano.FaixaDoTitulo);
            faixa.Font.Size = 10;
            // Os literais do original: `VerticalAlignment = 2` (o Excel guarda -4108, centralizado) e
            // `HorizontalAlignment = 2` (-4131, esquerda) — medido nesta máquina com o Office 16.0.
            faixa.VerticalAlignment = 2;
            faixa.HorizontalAlignment = 2;
            aba.get_Range(plano.FaixaDaQuebra).WrapText = true;

            foreach (ColunaDaPlanilha coluna in plano.Colunas)
            {
                Range cabecalho = aba.get_Range(ExcelDosTitulos.Endereco(coluna.Indice, 1));
                if (coluna.Visivel)
                {
                    cabecalho.Value = coluna.Titulo;
                }

                cabecalho.ColumnWidth = coluna.Largura;
            }

            Faixa(aba, plano.FaixaDoCabecalho);

            foreach (LinhaDaPlanilha linha in plano.Linhas)
            {
                foreach (CelulaDaPlanilha celula in linha.Celulas)
                {
                    Range alvo = aba.get_Range(celula.Endereco);
                    if (celula.QuebraTexto)
                    {
                        alvo.WrapText = true;
                    }

                    alvo.Value = celula.Valor;
                }

                if (linha.Colorida)
                {
                    aba.get_Range(linha.Faixa).Interior.ColorIndex = ExcelDosTitulos.CorDaLinhaAlternada;
                }

                Faixa(aba, linha.Faixa);
            }
        }

        /// <summary>O `CriaLinhasInterna` (`ExcFuncoesExcel.cs:1001-1014`): quebra e borda interna.</summary>
        private static void Faixa(Worksheet aba, string endereco)
        {
            Range faixa = aba.get_Range(endereco);
            faixa.WrapText = true;
            faixa.Borders.LineStyle = 1;
        }

        /// <summary>As linhas da aba que o `ImportaTitulos` lê (a 2 até a última da coluna A).</summary>
        private static IReadOnlyList<IReadOnlyList<string>> LerLinhas(Worksheet aba)
        {
            var linhas = new List<IReadOnlyList<string>>();
            int ultima = BuscaIndiceMaximoUsado(aba, "A");
            for (int linha = 2; linha <= ultima; linha++)
            {
                var celulas = new List<string>();
                for (int coluna = 0; coluna <= ExcelDosTitulos.ColunaDoAlternativo; coluna++)
                {
                    celulas.Add(Texto(aba.get_Range(ExcelDosTitulos.Endereco(coluna, linha)).Value));
                }

                linhas.Add(celulas);
            }

            return linhas;
        }

        /// <summary>O `BuscaIndiceMaximoUsado` (`ExcFuncoesExcel.cs:515-529`).</summary>
        private static int BuscaIndiceMaximoUsado(Worksheet aba, string coluna)
        {
            int numero = 1;
            while (aba.get_Range(coluna + numero).Value != null)
            {
                numero++;
            }

            return numero - 1;
        }

        /// <summary>O `PintaCelula` (`ExcFuncoesExcel.cs:1057-1100`): comentário e cor na célula.</summary>
        private static void Pintar(Worksheet aba, IReadOnlyList<AvisoDaPlanilha> avisos)
        {
            foreach (AvisoDaPlanilha aviso in avisos)
            {
                try
                {
                    Range alvo = aba.get_Range(aviso.Endereco);
                    if (alvo.Comment == null)
                    {
                        alvo.AddComment(Type.Missing);
                    }

                    alvo.Comment.Visible = false;
                    alvo.Comment.Text(aviso.Mensagem, Type.Missing, Type.Missing);
                    alvo.Interior.ColorIndex = aviso.CorIndice;
                }
                catch (Exception)
                {
                    // O original engole o erro do comentário (e pinta a célula assim mesmo).
                    try
                    {
                        aba.get_Range(aviso.Endereco).Interior.ColorIndex = aviso.CorIndice;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        /// <summary>O `TiraNothing` do `clsTextos` (`:54`): a célula vazia vira texto vazio.</summary>
        private static string Texto(object valor)
        {
            return valor == null ? null : Convert.ToString(valor);
        }
    }
}
