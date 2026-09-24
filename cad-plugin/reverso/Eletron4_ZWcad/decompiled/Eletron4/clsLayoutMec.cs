using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class clsLayoutMec
{
	public struct StructureDisps
	{
		public string nome;

		public double X;

		public double Y;

		public string Handle;
	}

	public struct StructurePlaquetas
	{
		public int iOrdem;

		public int indice_OrdemPL;

		public int indice_OrdemLM;

		public int indice_OrdemLAY;

		public string Disp;

		public string Etiq;

		public string Painel;

		public int iTipo;

		public double dPG;

		public double dX;

		public double dY;

		public string Handle;
	}

	public struct StructurePlaquetasPainel
	{
		public int indice_OrdemPL;

		public string Disp;

		public string Etiq;

		public string Painel;
	}

	public struct StructureLmPainel
	{
		public int indice_OrdemLM;

		public string Disp;

		public string Painel;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public clsLayoutMec()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string InserirBlocoDispLayout(int painel, string tag, string alternativo, string nomeBloco, bool bAlternativo, string sEtiqueta, bool bETQ, bool bNomeVisivel, string sHandle)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ObjectId InserirPrimeiroBorneLayout(string nomebloco, int painel, string regua, string borne, int tipoBorne, bool bVertical, double dFonte)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return (ObjectId)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ObjectId InserirOutroBorneLayout(string nomebloco, Point3d ptIns, int painel, string regua, string borne, int tipoBorne)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return (ObjectId)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CarregaDispositivosInseridos(int painel, List<string> lTags)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string BuscaHandleDoDispLayout(int painel, string sTags)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CarregaBornesInseridos(int painel, string regua, List<string> lBornes)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaReguaSelecionada(int painel, string regua)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaNomeAlternativoLayoutMec(int painel, string TagOriginal, string TagNovo, string Alternativo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AdicionaQuantidadeDosBornes(Point3d PtIni, Point3d PtFim, string SQuantidade, bool BVertical, bool BDireitaOuCima, int Painel, string Regua, string Borne, int TipoBorne, double DFonte)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CriarNumeroDoPrimeiroBorne(BlockReference blockRef, string sNumero, bool bVertical, bool bDireita, int painel, string regua, string borne, int tipoBorne, double dFonte)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static double CriaTabelaLayout(bool bTitulo, ref Point3d pt, int ix, int iPainel, string sFuncional, string sPlaqueta, bool bAlternativo, int iTipo)
	{
		return 0.0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaTabelaLayout(int iPainel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaTextoDisp(string sHandleDisp)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaRetanguloDisp(int ipainel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LimpaLMPlaquetasDisp(int ipainel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool SelecionaBornesParaEdicao(ref StructureDisps[] mNomes)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool AdicionaOTexto(ref Point3d pt, ref StructureDisps[] mNomes, int iPainel)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaOsTextosAntigos(ref StructureDisps[] mNomes, int iPainel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaETQDasReguas(int iPainelSel, string sETQ, string sDisp, bool bLiga, bool bPlaquetas, bool bNumeros, bool bIncluirRetangulo, double bTamanho)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CriaRetanguloNoTexto(ref string sHandle, int iPainelSel, string sDisp, double dTamanho)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CriaRetanguloNoAtributo(ref string sHandle, double dTamanho)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CarregaPlaquetasDoPainel(ref StructurePlaquetasPainel[] _mPlaquetasPainel, int iPainel)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CarregaLmDoPainel(ref StructureLmPainel[] _mLmPainel, int iPainel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void pesquisaPlaquetasDesenho(ref StructurePlaquetas[] mPlaquetasRel, int painelSel, bool bAlternativo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ExistePlaquetaLM(int iPainel)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool TemPlaquetas(int iPainel)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void atualizaNomesAuternativoDispositivos(int painel, ref DeclaracoesFiacao.structureVF[] mDisp, bool bAlternativo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void MarcaDispositivosUsados(DataGridView dgDisp, ref DeclaracoesFiacao.structureVF[] mDisp, int iPainel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaPlaquetasLayoutMec(ref List<string> listHandle, StructurePlaquetasPainel[] _mPlaquetasPainel, int iPainel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaLmLayoutMec(ref List<string> listHandle, StructureLmPainel[] _mLmPainel, int iPainel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaNOMEDoBloco(int iPainelSel, bool bNomeVisivel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaOsTextosAntigos()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static object BuscaNoomedoBloco(ref string sHandle)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static clsLayoutMec()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
