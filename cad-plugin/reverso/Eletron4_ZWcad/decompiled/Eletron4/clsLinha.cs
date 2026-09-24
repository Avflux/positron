using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class clsLinha
{
	public struct StructureLinhaBornes
	{
		public string term;

		public string Handle;

		public Point3d InsertionPoint;

		public Point3d ptIni;

		public Point3d ptFim;

		public long Potencial;

		public int IndexRegua;

		public bool btitulo;

		public Point3d ptMeio;

		public double x;

		public double y;
	}

	public struct LigacaoDosBornes
	{
		public int indece;

		public double iX;

		public double iY;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public clsLinha()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AdricionaLinhaH(double dI, double dM, double dF)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AdricionaLinhaV(double dI, double dM, double dF)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool BuscaBornesDaPagina(BlockReference Bloco, ref Point3d xIni, ref Point3d xFim, string sLinha)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static long SELCarregaosBornesDaPaginaH(ref StructureLinhaBornes[] LinhaBorne, string sPagina, ref clsBornes.BornesTipo[] BornesTipo)
	{
		return 0L;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static long SELCarregaosBornesDaPaginaV(ref StructureLinhaBornes[] LinhaBorne, string sPagina, ref clsBornes.BornesTipo[] BornesTipo)
	{
		return 0L;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool H9gThl5vQ0(string P_0, clsBornes.BornesTipo[] P_1, ref Point3d P_2, ref Point3d P_3)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void carregaLinhaNovaH(int IndexRegua, double y, ref StructureLinhaBornes[] LinhaEntreBornes, ref StructureLinhaBornes[] CriarLinhaBorne)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void carregaLinhaNovaV(int IndexRegua, double y, StructureLinhaBornes[] LinhaEntreBornes, ref StructureLinhaBornes[] CriarLinhaBorne)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InsereAsLinhasH(ref StructureLinhaBornes[] LinhaBorne, string sPagina, double dI, double dM, double dF)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InsereAsLinhasV(ref StructureLinhaBornes[] LinhaBorne, string sPagina, clsBornes.BornesTipo[] BornesTipo, double dI, double dM, double dF)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaLinhaAuxBornes(ref string sPagina)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CriaEstiloDeLinha()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaLinhaErro(List<string> lErros)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static clsLinha()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
