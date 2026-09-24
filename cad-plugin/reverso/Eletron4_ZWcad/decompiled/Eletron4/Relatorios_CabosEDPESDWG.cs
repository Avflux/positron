using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ZwSoft.ZwCAD.Geometry;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class Relatorios_CabosEDPESDWG
{
	public struct structureRelatCabosEDPESDWG
	{
		public string Tag;

		public string Formacao;

		public string Funcao;

		public string sBlindagem;

		public string Comprimento;

		public int iPn1;

		public int iPn2;

		public string sPn1;

		public string sPn2;

		public string sObs;

		public string sVeiasUsadas;

		public string sVeiasLivres;

		public string Instrucao;
	}

	public struct ConfigRelatCabosEDPESDWG
	{
		public int AlturaInicial;

		public double AlturaDoBloco;

		public double TamanhoFonte;

		public int CorLinha;

		public int CorTexto;

		public string sFonte;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Relatorios_CabosEDPESDWG()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CriaMatrizDeCabosEDPES_DWG(Relatorios_CabosChesfDWG.structureRelatCabosEDPES[] mCabos, string revisaoSel, ConfigRelatCabosEDPESDWG confRelatCabos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CriaTituloTabelaCaboEDPES_Titulo(ref Point3d pt, double dLarguraDoBloco, Relatorios_CabosChesfDWG.structureRelatCabosEDPES[] mCabos, int iIndice, ConfigRelatCabosEDPESDWG confRelat, string sRevisao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CriaTituloDaTabelaEDPParte(ref Point3d pt, int iIndice, double dLargura, double dAltura, ConfigRelatCabosEDPESDWG ConfRelt, string sRevisao, List<string> lValor)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CriaTituloTabelaCaboEDPES_Corpo(double dLarguraDoBloco, ref Point3d pt, int iIndice, Relatorios_CabosChesfDWG.structureRelatCabosEDPES[] mCabos, ConfigRelatCabosEDPESDWG ConfRelt, string sRevisao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaRelatorioCabosEDPES(string revisaoSel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static double BuscaAlturadaRegua()
	{
		return 0.0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Relatorios_CabosEDPESDWG()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
