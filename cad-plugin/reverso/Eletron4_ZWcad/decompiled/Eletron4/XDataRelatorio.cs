using System.Runtime.CompilerServices;
using ZwSoft.ZwCAD.DatabaseServices;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class XDataRelatorio
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public XDataRelatorio()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GravarXDataFiacao(ref Entity Ent, string sRelatorio, int iPN)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LerXDataFiacao(ref Entity Ent, ref string sRel, ref int iPN)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GravarXDataJumpers(ref Entity Ent, string sRelatorio, int iPN)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LerXDataJumpers(ref Entity Ent, ref string sRel, ref int iPN)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GravarXDataPlaquetas(ref Entity Ent, string sIndice, string sDisp, int iPN)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LerXDataPlaquetas(ref Entity Ent, ref string sEti, ref string sDisp, ref int iPN)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GravarXDataIndice(ref object ent, int iIndice, string sPG = "")
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LerXDataIndicePG(ref Entity Ent)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool TemOxDataNoRelatorio(ref Entity ent, string sNomeRelatorio)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GravarXDataMateriais(ref Entity Ent, int iIndice, int iPN, string sDisp = "")
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LerXDataMateriais(ref Entity Ent, ref int iIndice, ref int iPN)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LerDispsXDataMateriais(ref Entity Ent, ref int iIndice, ref int iPN, ref string[] sDisps)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LerDispsXDataMateriaisM(ref Entity Ent, ref int iIndice, ref int iPN, ref string[] sDisps)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void gravaXDataDistPot(ref Entity Ent, Relatorios_DistribuicaoPot.StructureBloco Bloco)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LerXDataDistPot(ref Entity Ent, ref Relatorios_DistribuicaoPot.StructureBloco Bloco)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LerXDataDistPotLinhas(ref Entity Ent, ref Relatorios_DistribuicaoPot.StructureBloco Bloco)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LeTodosOsXdatasDeRelatorio(ref Entity ent, ref string s1, ref string s2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GravarXDataCabosEnergisa(ref Entity Ent, string sRev, ref string sRelatorio, ref string sCabo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LEXDataCabosEnergisa(ref Entity Ent, ref string SREV, ref string sRelatorio, ref string sCabo)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GravarXDataCabosEDPES(ref Entity Ent, string revisaoSel, int iPainel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LEXDataCabosEDPES(ref Entity Ent, ref string SREV)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LeXDataRevisao(ref BlockReference blockRef, ref DeclaracoesGeral.Revisoes revC)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool leXDataRevisaoCompleta(ref Entity Ent, ref string sRevisao, ref int iColuna, ref int iIndice)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool leXDataBuscaTamanhoColunasRevisaoCompleta(ref Entity Ent, ref Relatorios_Rev.ConfigReV confRelRev)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GravarXDataRevisaoCompleta(ref Entity Ent, string sRevisao, int iColuna, int iIndice, int i1, int i2, int i3)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool leXDataRevisaoElektro(ref Entity Ent, ref clsRelatorio_Elektro.ConfElektro rel)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GravarXDataElektro(ref Entity Ent, clsRelatorio_Elektro.ConfElektro rel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GravarXDataFurnas(ref Entity Ent, int Pag)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LerXDataFurnas(ref Entity Ent)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LerXDataFurnasIndice(ref Entity Ent)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GravarXDataRevisaoMatricial(ref Entity Ent, string sPagina, int iIndice, string sRevisoes, string sTipo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool leXDataRevisaoMatricial(ref Entity Ent, ref string sRevisao, ref string sPagina, ref int iIndice, ref string sTipo)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool leXDataBuscaTamanhoColunasRevisaoMatricial(ref Entity Ent, ref Relatorios_Rev_Matricial.ConfigReV confRelRev)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GravarXDataVeiasCopel(ref Entity Ent, string sRelatorio, int iINDICE)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LerXDataVeiasCopel(ref Entity Ent, ref string sRel, ref int iIndice)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static XDataRelatorio()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
