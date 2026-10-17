using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using Positron.Data.Interligacao;

namespace Positron.Plugin.Interface.Excel
{
    /// <summary>
    /// A ponte com o **Excel ativo** do `frmEstatisticaDeCabos`: o
    /// `Relatorios_EstatisticaCaboEXCEL.ExportaEstatisticaExcel(dg, itipo)` do reverso, que abre por
    /// `ExcFuncoesExcel.VerificaExcel` (`:36-...`) — a **aba nomeada** `DIF_&lt;grupo&gt;`, e não a aba
    /// ativa como a ponte dos títulos.
    ///
    /// O que escrever (o nome da aba, as três colunas do cabeçalho e uma linha por linha da grade, já
    /// com o apóstrofo do original) vem da regra pura <see cref="ExcelDaEstatisticaDeCabos"/>; aqui é
    /// só o `Microsoft.Office.Interop.Excel`. As folhas COM compartilhadas com a ponte dos títulos
    /// (o `ExcelAberto`, a instância pelo CLSID, o `AtivaCalculOExcel` e o `Geral.CADVersion`) estão no
    /// <see cref="ExcelDoReverso"/>.
    /// </summary>
    internal static class ExcelAtivoDaEstatisticaDeCabos
    {
        /// <summary>
        /// O `ExportaEstatisticaExcel` (`Relatorios_EstatisticaCaboEXCEL.cs:12-98`): procura (ou cria)
        /// a aba do grupo, limpa e escreve o plano. Devolve o plano — a casca usa o rótulo para a
        /// linha de resumo.
        /// </summary>
        internal static PlanoDaEstatisticaDeCabos Exportar(
            IReadOnlyList<IReadOnlyList<string>> linhasDaGrade,
            AgrupamentoDeCabos agrupamento)
        {
            PlanoDaEstatisticaDeCabos plano = ExcelDaEstatisticaDeCabos.Exportar(linhasDaGrade, agrupamento);

            Application aplicacao;
            Workbook livro;
            Worksheet aba;
            VerificaExcel(plano.NomeDaAba, out aplicacao, out livro, out aba);
            try
            {
                // O `AtivaCalculOExcel` do original (`:119`): visível e calculando (o inverso do
                // `DesativaCalculoExcel` que a ponte dos títulos usa).
                ExcelDoReverso.AtivarCalculo(aplicacao);

                // `:33-34` — a aba já limpa pelo `VerificaExcel` é limpa de novo aqui.
                aba.get_Range("A1", "Z10000").EntireRow.Delete(Type.Missing);
                aba.Cells.ClearComments();

                Escrever(aba, plano);
                aba.get_Range(ExcelDaEstatisticaDeCabos.CelulaSelecionada).Select();
                return plano;
            }
            finally
            {
                ExcelDoReverso.Liberar(aplicacao, livro, aba);
            }
        }

        /// <summary>
        /// O `ExcFuncoesExcel.VerificaExcel` (`:36-...`): acha a aba **pelo nome** (sem caixa) no livro
        /// ativo e, se ela existe, ativa, apaga as imagens (`ApagaFigura`, `:796-846`) e limpa
        /// (`LimpaSheet`, `:530-536`) — o nome já vem do <see cref="ExcelDaEstatisticaDeCabos"/> (que
        /// aplica o `TrocaBarra`; reaplicá-lo não muda nada). Sem aba com esse nome, acrescenta uma
        /// **no fim** do livro e ativa.
        /// </summary>
        private static void VerificaExcel(string nomeDaAba, out Application aplicacao, out Workbook livro, out Worksheet aba)
        {
            if (string.IsNullOrEmpty(nomeDaAba))
            {
                nomeDaAba = ExcelDaEstatisticaDeCabos.NomePadraoDaAba;
            }

            if (!ExcelDoReverso.ExcelAberto())
            {
                aplicacao = ExcelDoReverso.NovaInstancia(out livro);
            }
            else
            {
                aplicacao = ExcelDoReverso.InstanciaAtiva(out livro);
            }

            aba = (Worksheet)aplicacao.ActiveSheet;
            for (int i = 1; i <= livro.Sheets.Count; i++)
            {
                Worksheet candidata = (Worksheet)livro.Worksheets[i];
                if (!string.Equals(candidata.Name, nomeDaAba, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                candidata.Activate();
                aba = (Worksheet)aplicacao.ActiveSheet;
                ApagaFigura(aba);
                LimpaSheet(aba);
                aplicacao.ScreenUpdating = true;
                System.Windows.Forms.Application.DoEvents();
                aplicacao.Visible = true;
                return;
            }

            // Não existe: ativa a primeira aba e acrescenta a nova depois da última (o `Worksheets.Add`
            // do original), e a ativa.
            if (livro.Sheets.Count >= 1)
            {
                ((Worksheet)livro.Worksheets[1]).Activate();
                aba = (Worksheet)aplicacao.ActiveSheet;
            }

            Worksheet nova = (Worksheet)livro.Worksheets.Add(
                Type.Missing, livro.Worksheets[livro.Worksheets.Count], Type.Missing, Type.Missing);
            nova.Name = nomeDaAba;
            for (int i = 1; i <= livro.Sheets.Count; i++)
            {
                Worksheet candidata = (Worksheet)livro.Worksheets[i];
                if (!string.Equals(candidata.Name, nomeDaAba, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                candidata.Activate();
                aba = (Worksheet)aplicacao.ActiveSheet;
                System.Windows.Forms.Application.DoEvents();
                break;
            }

            // Quirk do caminho novo (`:...`): com o cálculo em Manual o original passa por Automatic e
            // volta — mantido.
            if (aplicacao.Calculation == XlCalculation.xlCalculationManual)
            {
                aplicacao.Calculation = XlCalculation.xlCalculationAutomatic;
                aplicacao.Calculation = XlCalculation.xlCalculationManual;
                System.Windows.Forms.Application.DoEvents();
            }
        }

        /// <summary>O `ApagaFigura` (`ExcFuncoesExcel.cs:796-846`): apaga as imagens da aba ativa.</summary>
        private static void ApagaFigura(Worksheet aba)
        {
            try
            {
                // Na PIA esta folha é um método com o índice opcional (`Pictures(Index)`), como o
                // `get_Range`; sem índice ele devolve a coleção inteira.
                Pictures imagens = (Pictures)aba.Pictures(Type.Missing);
                if (imagens.Count <= 0)
                {
                    return;
                }

                foreach (Picture imagem in imagens)
                {
                    imagem.Delete();
                }
            }
            catch (Exception)
            {
                // O original engole a falha aqui.
            }
        }

        /// <summary>O `LimpaSheet` (`ExcFuncoesExcel.cs:530-536`).</summary>
        private static void LimpaSheet(Worksheet aba)
        {
            aba.get_Range("A1", "Z10000").EntireRow.Delete(Type.Missing);
            aba.get_Range("A1", "Z1").ColumnWidth = 8.43;
            aba.Cells.ClearComments();
        }

        /// <summary>
        /// A escrita do `ExportaEstatisticaExcel` (`:35-92`): o cabeçalho célula a célula (largura e
        /// alinhamentos), o negrito e as bordas da faixa `A1:C1`, as linhas da grade e as bordas da
        /// faixa dos dados.
        /// </summary>
        private static void Escrever(Worksheet aba, PlanoDaEstatisticaDeCabos plano)
        {
            foreach (ColunaDaEstatistica coluna in plano.Colunas)
            {
                Range celula = aba.get_Range(coluna.Endereco);
                celula.ColumnWidth = coluna.Largura;
                // Os literais do original: `VerticalAlignment = 2` e `HorizontalAlignment = 3`.
                celula.VerticalAlignment = 2;
                celula.HorizontalAlignment = 3;
                celula.Value = coluna.Titulo;
            }

            Range cabecalho = aba.get_Range(plano.FaixaDoCabecalho);
            cabecalho.Font.Bold = true;
            Internas(aba, plano.FaixaDoCabecalho);
            Externas(aba, plano.FaixaDoCabecalho);

            foreach (LinhaDaEstatisticaDaPlanilha linha in plano.Linhas)
            {
                EscreverCelula(aba, linha.Endereco(0), linha.Contagem, 3);
                EscreverCelula(aba, linha.Endereco(1), linha.Grupo, null);
                EscreverCelula(aba, linha.Endereco(2), linha.Comprimento, 4);
            }

            // Quirk mantido: com a grade vazia a faixa sai invertida (`A2:C1`) e quem normaliza é o
            // próprio Excel, como no original.
            Internas(aba, plano.FaixaDosDados);
            Externas(aba, plano.FaixaDosDados);
        }

        /// <summary>
        /// Uma célula de dados: o valor com o apóstrofo, o `VerticalAlignment = 2` e, quando o original
        /// pede, o `HorizontalAlignment` (3 na contagem, 4 no comprimento — a coluna do grupo não
        /// recebe alinhamento nenhum).
        /// </summary>
        private static void EscreverCelula(Worksheet aba, string endereco, string valor, int? horizontal)
        {
            Range alvo = aba.get_Range(endereco);
            alvo.Value = valor;
            alvo.VerticalAlignment = 2;
            if (horizontal.HasValue)
            {
                alvo.HorizontalAlignment = horizontal.Value;
            }
        }

        /// <summary>O `CriaLinhasInterna` (`ExcFuncoesExcel.cs:1001-1014`): quebra de linha e borda interna.</summary>
        private static void Internas(Worksheet aba, string faixa)
        {
            Range alvo = aba.get_Range(faixa);
            alvo.WrapText = true;
            alvo.Borders.LineStyle = 1;
        }

        /// <summary>O `CriaLinhasExterna(..., completo: true)` (`ExcFuncoesExcel.cs:946-963`): as quatro bordas.</summary>
        private static void Externas(Worksheet aba, string faixa)
        {
            try
            {
                Range alvo = aba.get_Range(faixa);
                alvo.Borders[XlBordersIndex.xlEdgeTop].Weight = 3;
                alvo.Borders[XlBordersIndex.xlEdgeBottom].Weight = 3;
                alvo.Borders[XlBordersIndex.xlEdgeRight].Weight = 3;
                alvo.Borders[XlBordersIndex.xlEdgeLeft].Weight = 3;
            }
            catch (Exception)
            {
                // O original engole a falha do Excel aqui.
            }
        }
    }
}
