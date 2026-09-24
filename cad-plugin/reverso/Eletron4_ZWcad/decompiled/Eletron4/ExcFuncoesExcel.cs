using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Excel;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class ExcFuncoesExcel
{
	public struct PosicoesExcel
	{
		public string SSheet;

		public string SNomeCampo;

		public string SPosicao;
	}

	public struct ValoresExcel
	{
		public string SNomeCampo;

		public string SValor;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ExcFuncoesExcel()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void VerificaExcel(ref Application oExcelNew, ref Worksheet oSheet, string oNomeSheet)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool VerificaExcelAtivo(ref Application oExcelNew, ref Workbook oBook, ref Worksheet oSheet, bool bMaximiza = true)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool VerificaExcelAtivoImportar(ref Application oExcelNew, ref Workbook oBook, ref Worksheet oSheet, bool bMaximiza = true)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool VerificaExisteSheet(ref Application oExcelNew, ref Worksheet oSheet, string oNomeSheet, bool bMaximiza = true)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ExisteSheet(string oNomeSheet, bool bMaximiza = true)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool VerificaExisteSheetSiemens(ref Application OExcelNew, ref Worksheet OSheet, string oNomeSheet)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AbreExcelExterno(string sCaminho)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void FechaExcelOculto()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ExcelAberto()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DesativaCalculoExcel(ref Application oExcel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtivaCalculOExcel(ref Application OExcelNew)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtuaizaCalculOExcel(ref Application OExcelNew)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void FormataPagina(ref Application OExcelNew, ref Worksheet OSheet, int Zoom)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int BuscaIndiceMaximoUsado(ref Worksheet OSheet, string sColuna, int Linha = 1)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LimpaSheet(ref Worksheet OSheet)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool InsereFigura1(ref Worksheet OSheet, string SCel1, string SCaminho, int iDeslocX, int iDeslocY)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int QuantidadeFigura(ref Application OExcelNew)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string BuscaValorNaPlanilhaExcel(string SPlanilha, string SWorksheet, string SValor, int IInicio = 1, int IFim = 100)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void BuscaTodosValorDoModelo(string sPlanilha, List<string> lCampos, ref PosicoesExcel[] mPosicoes)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void PreencheTodosValorDoModelo(PosicoesExcel[] MPosicoes, ValoresExcel[] ValoresExcel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void PreencheUmValorNOExcel(string SSheet, string SCel1, string sValor)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaFigura(string ONomeSheet)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int EncontraZoomPagina(ref Application OExcelNew, ref Worksheet OSheetNew)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtivaView(ref Application OExcelNew, bool bPreview)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void TrocaBarra(ref string SSheet)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CriaLinhasExterna(ref Worksheet OSheet, string sRange, bool bCompleto)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CriaLinhasExternaSimles(ref Worksheet OSheet, string sRange, bool bCompleto)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LimpaLinhasInterna(ref Worksheet OSheet, string sRange)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CriaLinhasInterna(ref Worksheet OSheet, string sRange)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CriaLinhasPontilhadaInterna(ref Worksheet OSheet, string sRange)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetarCorCelula(ref Worksheet OSheet, string sRange)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LimpaErro(ref Worksheet OSheet, string sLinha)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void PintaCelula(ref Worksheet OSheet, string SColuna, string SLinha, string SMsg, int ICor, int IQuantLinhas = 0, int ILargura = 0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool VerificaSheetVazia(ref Worksheet OSheet)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SetaAreaDeImpressao(ref Worksheet OSheet, ref List<string> LSheetArea, string SCol, string SLin)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RemoveHPageBreaks(ref Worksheet OSheet)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string mudaNumeroAsc(long iCol)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CopyValorCelula(ref Worksheet oSheet, string sDestino, string sOrigem)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ExcFuncoesExcel()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
