using System.Runtime.CompilerServices;
using ZwSoft.ZwCAD.Geometry;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class Relatorios_DistribuicaoPot
{
	public struct StructurePotenciais
	{
		public string sNome;

		public int iPotencial;
	}

	public struct StructurePontos
	{
		public string sNome;

		public string sT1;

		public string sSentido;

		public Point3d pt;
	}

	public struct StructurePosicaoBlocos
	{
		public string sNome;

		public string sT1;

		public double sX;

		public double sY;
	}

	public struct StructureTag
	{
		public string sTag;

		public string sRegua;

		public string Terminal;

		public string Pagina;

		public string Indice;

		public string Tipo;

		public string Handle;

		public string POTENCIAL;

		public string sHandle;

		public string sPainel;

		public int iPainel;
	}

	public struct StructureBloco
	{
		public int iPot;

		public int iDwg;

		public string sTipo;

		public int iPn;

		public string sCorr;

		public string sCorrComp;

		public string sDispComp;

		public string sPn;

		public string sRegua;

		public string sNome;

		public string sT1;

		public string sT2;

		public string sHandle;

		public string sRevisao;

		public int Eletron;

		public bool bPrimeiro;

		public bool bMostraPainel;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Relatorios_DistribuicaoPot()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CarregaBlocos(ref object mBlocos, string sTipoBloco)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaDistribuicaoPotenciais(string sRevF, ref int iDwg, ref int iPot)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CarregaNomeDosBlocos(int i, ref string sTipo, ref string sCaminho, ref string sBloco)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string insereUmBlocoDoRelatorioDePotenciais(string sCaminhoBloco, double lIncremento, string sNomeDoBloco, string sSentido, StructureBloco Bloco, ref Point3d Point, ref Point3d PointBloco, ref StructurePosicaoBlocos[] posBlocosADD)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string insereLinhadORelatorioDePotenciais(double dComprimentoDaLinha, double dAlturaDoBloco, ref string sSentido, StructureBloco Bloco, ref Point3d Point)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string insereUmLinhaRelPot2(double dComprimentoDaLinha, double dAlturaDoBloco, ref string sSentido, StructureBloco Bloco, ref Point3d Point)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void insereUmLinhaRelPotDeslocamento(double dAlturaDaLinha, double dAlturaDoBloco, string sU_D, string sD_E, double dDeslocamento, StructureBloco Bloco, ref Point3d Point)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void criarHatchTriangulo(Point3d pt, string layer, string sSentido, StructureBloco Bloco)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string insereUmLinhaRelPotRetorno(double dAlturaDaLinha, double dAlturaDoBloco, ref string sU_D, ref string sD_E, double dDeslocamento, StructureBloco Bloco, ref Point3d Point)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ExistePontoNaLista(ref StructurePosicaoBlocos[] posBlocosADD, Point3d pt)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool adicionaPontoNaLista(ref StructurePosicaoBlocos[] posBlocosADD, Point3d pt, string sNome, string sT)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Relatorios_DistribuicaoPot()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
