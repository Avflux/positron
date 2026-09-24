using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class cDadosAccessImportarProj
{
	public object db;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void fechaConexao()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public cDadosAccessImportarProj()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaCabosImpProj(ref clsImportarProjetos.mCabos[] mCabos, bool bUso)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaEquipImpProj(ref clsImportarProjetos.mEquip[] mPN)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaDWGImpProj(ref clsImportarProjetos.mDWG[] mDWG)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int BuscaProximoIndiceDWG()
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaCabosCompletosImpProj(List<int> lIndicePaineisCabos, List<int> lIndiceDWGCabos, ref clsImportarProjetos.mTrocaCabos[] iNomeCabosTroca, ref List<string> lListaCabosOriginal, List<string> lCabos, ref clsImportarProjetos.mTodosCabos[] mTodosCabos, ref clsImportarProjetos.mTodasVeias[] mTodasVeias)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CadastraNovosDWGS(clsImportarProjetos.mDWG[] mIndiceNovosDWGs)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdicionaNovosCabos(ref clsImportarProjetos.mTodosCabos[] mCabos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdicionaNovasVeias(ref clsImportarProjetos.mTodasVeias[] mVeias)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdicionaNovosImportados(ref clsImportarProjetos.mExpo[] mNOVO_ExportadosImportada, ref clsImportarProjetos.mAtt[] mNOVO_AtributosImportada)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaExportadosImpProj(ref clsImportarProjetos.mExpo[] mExportados, ref clsImportarProjetos.mAtt[] mAtributos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int BuscaIndiceExportado(int Codigo, int DWG, string Handle)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public int BuscaIndiceImportado(int Codigo, int DWG_DEST, string Handle)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaTodaLMDoImpProj(ref cDadosLM.structureLMRelelatorio[] mLP)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LeBanco(string strSQL, ref DataTable dt)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdicionaItemFiacaosDT(DataTable dt, clsImportarProjetos.mIndiceTrocaDWG[] mIndiceTrocaDWG, clsImportarProjetos.mIndiceTrocaPN[] iIndicePN_TROCA, ref long I, DeclaracoesFiacao.structureRevisoes[] mRevisoes)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdicionaItemBornesDT(DataTable dt, clsImportarProjetos.mIndiceTrocaDWG[] mIndiceTrocaDWG, clsImportarProjetos.mIndiceTrocaPN[] iIndicePN_TROCA, ref long iProgress, DeclaracoesFiacao.structureRevisoes[] mRevisoes)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdicionaItemCircuitos4FDT(DataTable dt, clsImportarProjetos.mIndiceTrocaDWG[] mIndiceTrocaDWG, clsImportarProjetos.mIndiceTrocaPN[] iIndicePN_TROCA, ref long iProgress, DeclaracoesFiacao.structureRevisoes[] mRevisoes)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdicionaItemContatos4FDT(DataTable dt, clsImportarProjetos.mIndiceTrocaDWG[] mIndiceTrocaDWG, clsImportarProjetos.mIndiceTrocaPN[] iIndicePN_TROCA, ref long iProgress, DeclaracoesFiacao.structureRevisoes[] mRevisoes)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdicionaItemDispositivos4FDT(DataTable dt, clsImportarProjetos.mIndiceTrocaDWG[] mIndiceTrocaDWG, clsImportarProjetos.mIndiceTrocaPN[] iIndicePN_TROCA, ref long iProgress, DeclaracoesFiacao.structureRevisoes[] mRevisoes)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdicionaItemPortas4FDT(DataTable dt, clsImportarProjetos.mIndiceTrocaDWG[] mIndiceTrocaDWG, clsImportarProjetos.mIndiceTrocaPN[] iIndicePN_TROCA, ref long iProgress, DeclaracoesFiacao.structureRevisoes[] mRevisoes)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static cDadosAccessImportarProj()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
