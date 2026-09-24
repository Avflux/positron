using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ZwSoft.ZwCAD.Geometry;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class Relatorios_Rev_Matricial
{
	public struct ConfigReV
	{
		public short CorLinha;

		public short CorJumper;

		public short CorTexto;

		public double TamanhoFonte;

		public short QuantColunas;

		public double AlturaInicial;

		public double DistEntreColunas;

		public double AlturaDoBloco;

		public string sFonte;

		public double dOrdenadaY;

		public string sTitulo1;

		public string sTitulo2;

		public string sRevisoesProjeto;
	}

	public struct RevisaoMatricial
	{
		public string sAlternativa;

		public string sPagina;

		public string sRevisao;

		public string R00;

		public string R01;

		public string R02;

		public string R03;

		public string R04;

		public string R05;

		public string R06;

		public string R07;

		public string R08;

		public string R09;

		public string R10;

		public string R11;

		public string R12;

		public string R13;

		public string R14;

		public string R15;

		public string R16;
	}

	public struct RevisaoPosicaoMatricial
	{
		public string R0;

		public string R1;

		public string R2;

		public string R3;

		public string R4;

		public string R5;

		public string R6;

		public string R7;

		public string R8;

		public string R9;

		public string R10;

		public string R11;

		public string R12;

		public string R13;

		public string R14;

		public string R15;

		public string R16;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Relatorios_Rev_Matricial()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CriaRelatorioREvisaoDWG(ConfigReV confRelRev, RevisaoMatricial[] mRelatorioMatricial)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void BuscaRevisoesAntigasDWG(ref RevisaoMatricial[] mRevisoesAntigas)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CriaTituloRevMatricial(double dLarguraDoBloco, Point3d pt, ref double dY, ref double dX, ConfigReV confRelRev, RevisaoMatricial[] mRelatorioMatricial, int iIndiceRel, ref string sRevisoesProjeto)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CriaTabelaRevMatricial(double dLarguraDoBloco, Point3d pt, ref double dY, ref double dX, ConfigReV confRelRev, RevisaoMatricial[] mRelatorioMatricial, int iIndiceRel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CriaTabelaRevMatricialVazia(double dLarguraDoBloco, Point3d pt, ref double dY, ref double dX, ConfigReV confRelRev, int iIndiceRel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaUmIndice(int iIndice)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaRelatorioRevisaoMatricial()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool BuscaRevisaoMatricial(ref List<string> lRevisoes)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool BuscaRevisoes(string sPagina, string sRevisao, RevisaoMatricial[] mRevisoesAntigas)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string OrdenaRevisao(string sRevisao)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static double BuscaPosicaoInicialRelatorio()
	{
		return 0.0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Relatorios_Rev_Matricial()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
