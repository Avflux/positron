using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class clsVeias
{
	public struct StructureVeias
	{
		public int iPainelSel;

		public string sTag;

		public string sFormacao;

		public string sFuncao;

		public string sVeia;

		public int iIndice;

		public string sAterrar1;

		public int iPn1;

		public string sPainel1;

		public string sDisp1;

		public string sBorne1;

		public int iPn2;

		public string sPainel2;

		public string sDisp2;

		public string sBorne2;

		public string sAterrar2;

		public string sDiagrama;

		public string sPagina1;

		public string sPagina2;

		public bool bBlindagem;

		public int iAterrar;

		public int iCabos;

		public double dComprimento;
	}

	public struct StructureUmaVeia
	{
		public string sTag;

		public int iIndice;

		public double iIndiceOrdem;

		public string sNome_Veia;

		public string sFuncao;

		public string sArquivo;

		public string sPagina;

		public string sIsolamento;
	}

	public struct StructureInterComplementa
	{
		public int DWG1;

		public string sDocumento1;

		public int Painel1;

		public string sPagina1;

		public string sTag1;

		public string sAlternativo1;

		public string sNRegua1;

		public string sTerminal1;

		public int DWG2;

		public string sDocumento2;

		public int Painel2;

		public string sPagina2;

		public string sTag2;

		public string sAlternativo2;

		public string sNRegua2;

		public string sTerminal2;
	}

	public struct StructureVeiasgIGA
	{
		public int iPainelSel;

		public string sTag;

		public int iPn1;

		public string sPainel1;

		public string sDisp1;

		public string sBorne1;

		public int iPn2;

		public string sPainel2;

		public string sDisp2;

		public string sBorne2;

		public string sPagina1;

		public string sPagina2;
	}

	public struct InterGIGA
	{
		public int iIndice;

		public string sTag1;

		public string sCor;

		public string sTag2;

		public string sPG;

		public string sD1;

		public string sD2;

		public string sB1;

		public string sB2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public clsVeias()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ExportaNomeFuncaoVeiaParaOExcel(ref Worksheet oSheet, ref DataGridView dg, structureVeiasCaderno[] SincVeias)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ImportaNomeFuncaoVeiaDoExcel(ref Worksheet oSheet, ref structureVeiasCaderno[] SincVeias)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static clsVeias()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
