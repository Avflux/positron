using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZwSoft.ZwCAD.DatabaseServices;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class XDataDInterlig
{
	public string Tag_Cabo;

	public string Formacao;

	public bool Blindagem;

	public bool bAterrar;

	public string sPainelDest;

	public string Pagina;

	public int Coluna;

	public double Y;

	public string Lado;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public XDataDInterlig()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GravarXDataBorne(ref BlockReference blockRef, DeclaracoesInterligacao.borneAranha bn)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LerXDataBorne(ref BlockReference blockRef, ref DeclaracoesInterligacao.borneAranha bn)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GravarXDataNomeRegua(ref BlockReference blockRef, DeclaracoesInterligacao.borneAranha bn)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LerXDataNomeRegua(ref BlockReference blockRef, ref DeclaracoesInterligacao.borneAranha bn)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GravarXDataJumper(ref Entity ent, string revisao, int painel, DeclaracoesInterligacao.borneAranha bnO, DeclaracoesInterligacao.borneAranha bnD)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LerXDataJumper(ref Entity ent, ref string revisao, ref int painel, ref DeclaracoesInterligacao.borneAranha bnO, ref DeclaracoesInterligacao.borneAranha bnD)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GravarXDataCabo(ref Entity ent, string revisao, int painel, DeclaracoesInterligacao.caboAranha cabo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LerXDataCabo(ref Entity ent, ref string revisao, ref int painel, ref DeclaracoesInterligacao.caboAranha cabo)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GravarXDataVeia(ref Entity ent, string revisao, int painel, string tag_cabo, string veia, string handle, bool bRebatido = false)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LerXDataVeia(ref Entity ent, ref string revisao, ref int painel, ref string tag_cabo, ref string veia, ref string handle, [Optional][DefaultParameterValue(false)] ref bool bRebatido)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static XDataDInterlig()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
