using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using Positron.Data.Paginas;
using Positron.Plugin.Interface.Folhas;

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
        /// cálculo, limpa a aba e escreve o plano. Devolve o plano — e a barra **compartilhada** da
        /// paleta anda com ele: `Quantidade = TotalDePassos` (o `dg.RowCount - 1` do original) e um
        /// passo por linha, como o `clsTextos.ExportaPaginas`.
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
                // O `pbPasso()` do original logo depois do `LimpaSheet` (`clsTextos.cs:1064`) — e
                // **antes** do `pbIniciar` daqui de baixo: ele anda o que sobrou na barra (numa barra
                // recém-nascida, 0..100, anda de verdade; depois de um `pbFim`, a faixa é 0 e não
                // mexe em nada).
                PaletaDeFolhas.ProgressoPasso();
                PlanoDaPlanilha plano = ExcelDosTitulos.Exportar(linhas, titulos, alternativo);
                // O `Quantidade = dg.RowCount - 1` seguido do `pbIniciar` (`clsTextos.cs:1149-1150`).
                PaletaDeFolhas.ProgressoQuantidade(plano.TotalDePassos);
                PaletaDeFolhas.ProgressoIniciar();
                Escrever(aba, plano);
                // O `pbFim` no fim da exportação (`clsTextos.cs:1210`).
                PaletaDeFolhas.ProgressoFim();
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
        ///
        /// A barra da paleta **não** anda aqui: o `ImportaTitulos` do original
        /// (`clsTextos.cs:1214-1306`) não chama `pbIniciar`/`pbPasso`/`pbFim` — quem o faz na
        /// importação é o `ImportaTextos` (`:1393-1441`, do `frmExportarImportarTextos`, que o
        /// recoder ainda não porta). Não "consertar" isso sem prova no reverso.
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
                // O `pbPasso()` no fim de cada linha escrita (`clsTextos.cs:1201-1202`). O original
                // conta uma linha a mais que o `Maximum` (`RowCount` linhas para `RowCount - 1`): o
                // último passo satura na barra.
                PaletaDeFolhas.ProgressoPasso();
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
