using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class ClsCabos
{
	public struct NomeVeias
	{
		public string blVar;

		public string P1Var;

		public string P2Var;

		public string T1Var;

		public string T2Var;

		public string T3Var;
	}

	public struct StructureCabo
	{
		public int iLinha;

		public string sTag;

		public string sFormacao;

		public bool bBlindagem;

		public int iPn1;

		public int iPn2;

		public string sCodigo;

		public string sFuncao;

		public int iAlarme;

		public int iAterrar;

		public double dComprimento;

		public string sTrajeto;

		public string sInstrucao;

		public double dDiametro;

		public string sGrupo;

		public int iCabos;

		public string sVeias;

		public string sSecao;

		public string sTagAntigo;
	}

	public struct StructureVeia
	{
		public string sTag;

		public int iIndice;

		public string sNome;

		public bool bUso;

		public string sHandle;

		public string sArquivo;

		public string sPagina;

		public string sFuncao;
	}

	public struct VeiaCabo
	{
		public string sTag;

		public int iNumVeias;

		public int iNumBlColetivas;

		public int iNumBlIndividuais;

		public string sTipo;
	}

	public struct CaboDWG
	{
		public string sTagOriginal;

		public string sTagNovo;

		public int iPn1;

		public int iPn2;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ClsCabos()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CarregaOsCabosDoExcel(ref Worksheet oSheet, ref StructureCabo[] mCabos, List<string> lmListaCabos, NomeVeias nv, StructureCabo[] mCadernoCabos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AdicionaBDCabosDoExcel(ref Worksheet oSheet, ref StructureCabo[] mCabos, NomeVeias nv, ref CDadosAccessInterligacao cDadosAccessInterligacao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CarregaOsCabosDoExcelParaEdicao(ref Worksheet oSheet, ref StructureCabo[] mCabos, List<string> lmListaCabos, NomeVeias nv, ref CaboDWG[] mCabosDWG, ref CaboDWG[] mCabosEditar, StructureCabo[] mmCadernoCabos, ref CDadosAccessInterligacao cDadosAccessInterligacao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static object VNEpy4gRec(ref Worksheet P_0, int P_1, ref List<string> P_2, ref List<string> P_3, ref string P_4, bool P_5, StructureCabo[] P_6)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void encontraVeiaSecao(string sFormacao, int iCabos, ref string sveia, ref string sSecao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static object vkypgJ9yxl(ref Worksheet P_0, int P_1, ref List<string> P_2, ref List<string> P_3, ref string P_4, bool P_5, StructureCabo[] P_6)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RemoveOsCabosAntigos(ref CaboDWG[] mCabosDWG, ref CDadosAccessInterligacao CDadosAccessInterligacao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LancaUmCabo(StructureCabo cabo, NomeVeias nv, ref CDadosAccessInterligacao cDadosAccessInterligacao)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LancaUmaVeia(VeiaCabo Veia, StructureCabo cabo, NomeVeias nv, ref CDadosAccessInterligacao cDadosAccessInterligacao)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CalculaVeiasEBlindagens(ref VeiaCabo Veia, ref StructureCabo cabo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ExportaModeloDeCabosParaOExcel(ref Worksheet oSheet)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ExportaCabosParaOExcel(ref Worksheet oSheet, ref DataGridView dg, string sTipo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OrdenaVeias(ref DataGridView dg, int indice = 4)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CarregaOsCabosDoDG(ref frmImportarInterligExcel.structureImpCabos[] mCabosImp, ref CDadosAccessInterligacao cDadosAccessInterligacao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ExportaCabosParcialParaOExcel(ref Worksheet oSheet, ref DataGridView dg, string sTipo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ExportaCabosTrajetoParaOExcel(ref Worksheet oSheet, ref DataGridView dg, string sTipo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CarregaOsCabosDoExcelParaEdicaoParcial(ref Worksheet oSheet, ref StructureCabo[] mCabos, List<string> lmListaCabos, NomeVeias nv, ref CaboDWG[] mCabosDWG, ref CaboDWG[] mCabosEditar, StructureCabo[] mmCadernoCabos, ref CDadosAccessInterligacao cDadosAccessInterligacao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CarregaOsCabosDoExcelParaEdicaoParcial2(ref Worksheet oSheet, ref CDadosAccessInterligacao CDadosAccessInterligacao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CriaEstiloDeLinha(ref string estilo, double escala)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ClsCabos()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
