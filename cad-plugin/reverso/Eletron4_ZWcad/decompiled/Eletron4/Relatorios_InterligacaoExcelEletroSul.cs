using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Excel;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class Relatorios_InterligacaoExcelEletroSul
{
	public struct structureRelInterligacao
	{
		public string TagRegua;

		public string Jumper;

		public string TagCabo_Veia;

		public string Formacao;

		public string Destino;

		public string Régua;

		public string Borne;

		public string Funcao;

		public string Documento;

		public int TipoBorne;

		public string Trajeto;
	}

	public struct structureReguasInterligacao
	{
		public string sRegua;

		public string sNomeSheet;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Relatorios_InterligacaoExcelEletroSul()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CriaMatrizInterligacaoExcel(ref List<string> lSheetArea, structureRelInterligacao[] mInterligacao, string sPainel, int QuantLinhasMax, bool bFormacao, bool bFuncao, bool bDocumento, bool bReserva, string sOpcional, bool bOpcional, bool bTrajeto, DeclaracoesInterligacao.reservaRI[] mAterrados, DeclaracoesInterligacao.reservaRI[] mNaoAterrados, string sMaxColuna, string sMaxQuebra, ref Declaracoes2.StructureIndiceRelatEletroSul[] mIndiceRel, bool bRodape, frmRelatorio_InterligacaoEletroSul_Excel.ConfRelelatorioExcel ConfRelinterligacao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string BuscaNomeDaSheet(string sRegua, structureReguasInterligacao[] sNomeReguas)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void desenhaMreguaELS(string sSheet, ref List<string> lSheetArea, string sRegua, structureRelInterligacao[] mRegua, int QuantLinhasMax, bool bFormacao, bool bFuncao, bool bDocumento, bool bTrajeto, string sOpcional, bool bOpcional, string sMaxColuna, string sMaxQuebra, ref Declaracoes2.StructureIndiceRelatEletroSul[] mIndiceRel, bool bRodape, frmRelatorio_InterligacaoEletroSul_Excel.ConfRelelatorioExcel ConfRelinterligacao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void qgu31jj7K1(ref Application P_0, ref Worksheet P_1, ref List<string> P_2, ref int P_3, DeclaracoesInterligacao.reservaRI[] P_4, string P_5, ref int P_6, int P_7, ref Declaracoes2.StructureIndiceRelatEletroSul[] P_8, frmRelatorio_InterligacaoEletroSul_Excel.ConfRelelatorioExcel P_9)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void yFQ3lS2JES(ref Worksheet P_0, ref int P_1, string P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AdicionaLinhaRelInterligacao(ref Worksheet oSheet, ref int iLinhaRelatorio, ref structureRelInterligacao[] mInterligacao, int iIndice1, int iIndice2, bool bFormacao, bool bfuncao, bool bDoc, bool bTrajeto, string sOpcional, bool bCampoVazio = false)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void NM7355LkAH(ref Worksheet P_0, bool P_1, bool P_2, bool P_3, string P_4, bool P_5)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void OIX30sQvc4(ref Worksheet P_0, ref int P_1, bool P_2, bool P_3, bool P_4, string P_5, bool P_6)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void EDM3R9Q20T(ref Application P_0, ref Worksheet P_1, ref List<string> P_2, string P_3, string P_4, ref int P_5, int P_6, bool P_7, bool P_8, bool P_9, bool P_10, bool P_11, string P_12, frmRelatorio_InterligacaoEletroSul_Excel.ConfRelelatorioExcel P_13)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void wao3mITsLF(ref Application P_0, ref Worksheet P_1, ref List<string> P_2, ref int P_3, string P_4, string P_5, ref int P_6, int P_7, bool P_8, bool P_9, bool P_10, bool P_11, string P_12, frmRelatorio_InterligacaoEletroSul_Excel.ConfRelelatorioExcel P_13)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void a653XZOLxi(ref Worksheet P_0, ref int P_1, string P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Relatorios_InterligacaoExcelEletroSul()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
