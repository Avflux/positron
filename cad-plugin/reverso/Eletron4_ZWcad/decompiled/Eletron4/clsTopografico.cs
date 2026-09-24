using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class clsTopografico
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public clsTopografico()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string InserirBlocoDispTopografico(DeclaracoesTopografico.structureDispTopografico dTpg, string nomebloco)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string InserirPrimeiroBorneTopografico(DeclaracoesTopografico.structureBorneTopografico bTpg, string nomebloco)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string InserirOutroBorneTopografico(DeclaracoesTopografico.structureBorneTopografico bTpg, string nomebloco, Point3d ptIns)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InserirTerminaisDispositivo(DeclaracoesTopografico.structureDispTopografico dTpg, ref DeclaracoesTopografico.structureConfigTopografico ctpg, ref string sblockRef, ref DeclaracoesTopografico.structureLigTermTopografico[] mLigacoes, bool bIgnorarExcedentes, bool bAlternativo, bool bIgnorarFaltantes)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InserirTerminaisBorne(DeclaracoesTopografico.structureBorneTopografico bTpg, ref DeclaracoesTopografico.structureConfigTopografico ctpg, ref string sblockRef, ref DeclaracoesTopografico.structureLigTermTopografico mLigacao, bool bAlternativo, bool bSeparaTerminaisDuplos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InserirErroBorne(string posEntrada, ref BlockReference blockRef)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string InserirLinkTopografico(DeclaracoesTopografico.structureBorneTopografico bTpg, string nomebloco, string sHandle)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizarTerminais(ref DeclaracoesTopografico.structureConfigTopografico ctpg, bool bAlternativo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void mostraSecao(string secao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ocultaSecao()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ReinserirTodasLigacoesDispositivos(ref DeclaracoesTopografico.structureConfigTopografico ctpg, int dwg, string revisao, int painel, bool bIgnorarExcedentes, bool bAlternativo, DeclaracoesTopografico.structureDispsTpg[] mTags, bool bIgnorarFaltantes)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ReinserirTodasLigacoesRegua(ref DeclaracoesTopografico.structureConfigTopografico ctpg, int dwg, string revisao, int painel, string regua, int indexModelo, bool bAlternativo, bool bSeparaTerminaisDuplos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagarTodasLigacoes(int painel, string tipo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void carregarPaineisBlocos(ref List<int> lPn)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void carregarHandlesBlocos(ref List<string> lhandles, int pn)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void carregaAnilhas(ref DeclaracoesTopografico.structureAnilhaTopografico[] mAnilhas, int pn)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void processaAnilhas(ref DeclaracoesTopografico.structureAnilhaTopografico[] mAnilhasTemp, ref DeclaracoesTopografico.structureAnilhaTopografico[] mAnilhas)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void inserirItemLMDisp(int painel, cDadosLM.structureDispLM[] mItens)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void montarTerminais(string tag, string alternativo, ref DeclaracoesTopografico.structureConfigTopografico ctpg, string terminal, bool bAlternativo, string orientacao, ref DeclaracoesTopografico.structureTerminalTopog[] mLigTerm, ref string valor1, ref string valor2, ref string valor3, ref string valor4)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void carregarLigacoes(string tag, ref DeclaracoesTopografico.structureLigTermTopografico[] mLigacoes, int indiceSel, string revisaoSel, int painelSel, string tipo, int indexModelo, ref DeclaracoesFiacao.structureLink[] mLink)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void carregaDispositivosInseridos(int painel, List<string> lTags)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void carregaBornesInseridos(int painel, string regua, List<string> lBornes)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaTerminaisDoBlocoApagado(string sLayer, string sTag, string sAlternativo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static clsTopografico()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
