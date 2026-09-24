using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Excel;
using ZwSoft.ZwCAD.Geometry;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class ClsBornesInterligCpfl
{
	public struct StructureBornesCPFL
	{
		public int iPainel;

		public string sPainel;

		public int iRegua;

		public string sRegua;

		public string sBorne;

		public string sHandle;

		public string Layer;

		public Point3d Point1;

		public bool bCDE1;

		public bool bCDE2;

		public bool bCDE3;

		public bool bCDE4;

		public bool bCPARA1;

		public bool bCPARA2;

		public bool bCPARA3;

		public bool bCPARA4;

		public bool bJDE1;

		public bool bJDE2;

		public bool bJDE3;

		public bool bJDE4;

		public bool bJPARA1;

		public bool bJPARA2;

		public bool bJPARA3;

		public bool bJPARA4;

		public bool Adicionado;

		public double iOrdem;
	}

	public struct StructureInterligCFEL
	{
		public string sPainelDE;

		public string sReguaDE;

		public string sBorneDE;

		public int iPainelDE;

		public int iReguaDE;

		public string sPainelPARA;

		public string sReguaPARA;

		public string sBornePARA;

		public int iPainelPARA;

		public int iReguaPara;

		public string s_Cabo;

		public int indice;

		public string sNome;

		public bool Adicionado;

		public string sTipo;
	}

	public struct StructureJUMPERCFEL
	{
		public string sPainelDE;

		public string sReguaDE;

		public string sBorneDE;

		public int iPainelDE;

		public int iReguaDE;

		public string sPainelPARA;

		public string sReguaPARA;

		public string sBornePARA;

		public int iPainelPARA;

		public int iReguaPara;

		public string sSecao;

		public string sCor;

		public string sFuncao;

		public bool Adicionado;
	}

	public struct StructureCadastroCabos
	{
		public string sCabo;

		public string sFormacao;

		public bool bBlindado;

		public string sFuncao;

		public string sVeias;

		public string sSecao;

		public int indice;

		public string sNome;

		public string sEquipDE;

		public string sEquipPARA;

		public int iEquipDE;

		public int iEquipPARA;

		public int iAterrar;

		public double dComprimento;

		public string sTajeto;
	}

	public struct StructureBorneInseidos2
	{
		public string sPainelDE;

		public string sReguaDE;

		public string sBorneDE;

		public int iPainelDE;

		public int iReguaDE;

		public string sPainelPARA;

		public string sReguaPARA;

		public string sBornePARA;

		public int iPainelPARA;

		public int iReguaPARA;
	}

	public struct StructureTamanhoCaboCPFE
	{
		public string sCabo;

		public int iTotVeias;

		public int iVeias;

		public int iQuant;
	}

	public struct StructureBornesReservas
	{
		public int iPainel;

		public int iRegua;

		public int iMaiorBorne;

		public bool bAddReserva;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ClsBornesInterligCpfl()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CapturaBornesDoDesenhoCpfl(ref StructureBornesCPFL[] mTodosBornes)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool VerificaBornesCpfl(ref StructureBorneInseidos2[] mBornesAdd, ref StructureInterligCFEL[] mInterligacoes, ref StructureJUMPERCFEL[] mJUMPERS)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CadastraPaineisCpfl(ref StructureBorneInseidos2[] mBornes, ref StructureBornesCPFL[] mTodosBornes, ref StructureInterligCFEL[] mInterligacoes, ref StructureInterligCFEL[] mBlindagens, ref StructureJUMPERCFEL[] mJUMPERS, ref StructureCadastroCabos[] mCabosAdd)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CadastraReguasCpfl(ref StructureBorneInseidos2[] mBornes, ref StructureBornesCPFL[] mTodosBornes, ref StructureInterligCFEL[] mInterligacoes, ref StructureInterligCFEL[] mBlindagem, ref StructureJUMPERCFEL[] mJUMPERS)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int BuscaIndideRegua(Declaracoes2.StructureModeloDeReguas[] mModeloDeReguas, int iPainel, string sRegua)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InsereVeiaCpfl(Point3d PrimeiroPoint, Point3d SegundoPoint, DeclaracoesEntidades.StructureInterligacao ilig)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AdicionaBornesReserva(ref StructureBornesCPFL[] mTodosBornes, List<string> lPNReguaReserva)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool AdicionaBornesNoDWG(double TamanhoDosEspacos, ref StructureBornesCPFL[] mTodosBornes, bool bPainel, bool bOrdem)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool AdicionaUmBorne(ref Point3d Point, ref StructureBornesCPFL mBornes, int iOrdem, string sCaminhoBloco, string sNomeBloco, bool bPainel, bool bOrdem)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AdicionaCabosNoDWG(ref StructureBornesCPFL[] mTodosBornes, ref StructureInterligCFEL[] mInterligacoes, double distancia)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AdicionaBlindagensNoDWG(ref StructureBornesCPFL[] mTodosBornes, ref StructureInterligCFEL[] mBlindagens, double distancia)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void Ey3pnQL4Ry(ref StructureBornesCPFL[] P_0, ref StructureInterligCFEL P_1, double P_2, DeclaracoesGeral.Reguas P_3, DeclaracoesGeral.Reguas P_4, bool P_5, bool P_6)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void GZtp1Yu60B(ref StructureBornesCPFL[] P_0, ref StructureInterligCFEL P_1, double P_2, DeclaracoesGeral.Reguas P_3, DeclaracoesGeral.Reguas P_4, bool P_5, bool P_6)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AdicionaJUMPERSNoDWG(ref StructureBornesCPFL[] mTodosBornes, ref StructureJUMPERCFEL[] mJUMPERS, double distancia)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void c9HplyQjUH(ref StructureBornesCPFL[] P_0, ref StructureJUMPERCFEL P_1, double P_2, int P_3, DeclaracoesGeral.Reguas P_4, DeclaracoesGeral.Reguas P_5, bool P_6, bool P_7)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ExportaModeloBornesInterligacaoCPFL(ref Worksheet oSheet)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LimpaTodoDesenho()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaTodosOsBornesReserva()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ClsBornesInterligCpfl()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
