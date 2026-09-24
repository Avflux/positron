using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ZwSoft.ZwCAD.Geometry;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class Relatorios_CabosChesfDWG
{
	public struct structureRelatCabosChesf
	{
		public string Tag;

		public string Bitola;

		public string Comprimento;

		public int iPn1;

		public int iPn2;

		public string sPn1;

		public string sPn2;

		public string sObs;
	}

	public struct structureRelatCabosEDPES
	{
		public string Tag;

		public int iPn1;

		public int iPn2;

		public string sPn1;

		public string sPn2;

		public string Funcao;

		public string Formacao;

		public string VeiasUsadas;

		public string VeiasLivres;

		public string isolacao;

		public string Blindado;

		public string Comprimento;

		public string sObs;
	}

	public struct ConfigRelatCabosChesf
	{
		public int DistEntreColunas;

		public int QuantColunas;

		public int AlturaInicial;

		public double AlturaDoBloco;

		public double TamanhoFonte;

		public int CorLinha;

		public int CorTexto;

		public string sFonte;
	}

	public struct structureRelatCabosCEMIG_D
	{
		public string _1_REV;

		public string _2_etapa;

		public string _3_Tag;

		public string _4_Funcao;

		public string _5_sPn1;

		public string _6_sPn2;

		public string _7_Comprimento;

		public string _8_Formacao;

		public string _9_VeiasTOT;

		public string _10_VeiasUsadas;

		public string _11_tipo;

		public string _12_Blindado;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Relatorios_CabosChesfDWG()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CriaMatrizDeCabosDWGChesf(structureRelatCabosChesf[] mCabos, string revisaoSel, ConfigRelatCabosChesf confRelatCabos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CriaTabelaCaboChesf(double dLarguraDoBloco, Point3d pt, structureRelatCabosChesf[] mCabos, int iIndice, ref double dY, ref double dX, ConfigRelatCabosChesf confRelatCabos, string revisaoSel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaRelatorioCabosChesf(string revisaoSel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void BuscaCabosDoRelatorioCabosChesf(ref List<string> lCabos, string revisaoSel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Relatorios_CabosChesfDWG()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
