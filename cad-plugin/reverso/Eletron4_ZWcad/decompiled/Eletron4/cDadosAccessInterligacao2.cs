using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class cDadosAccessInterligacao2
{
	public object db;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void fechaConexao()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public cDadosAccessInterligacao2()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaRevisoesDwgIligCorrente(int dwgCorrente, ref DeclaracoesFiacao.structureRevisoes[] mRevisoes)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaRevisoesCabos4(ref DeclaracoesFiacao.structureRevisoes[] mRevisoes)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaPnRev(string revisao, ref DeclaracoesFiacao.structurePnRev[] mPnRev)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdicionaItemInterligacao(DeclaracoesInterligacao.structureInterlig ilig)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveRevisaoTabelaParaDWG(string nomeTabela, int dwgCorrente, string revisao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveRevisaoTabelaParaTodosDWG(string nomeTabela, string revisao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdicionaItemPortas(string revisao, long dwg, long indexModelo, string nomeModelo, string regua, string borne, string terminal, double terminalNum, string tipo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdicionaItemBornes(string revisao, long dwg, DeclaracoesEntidades.StructureBorne born)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaCabos(ref DeclaracoesInterligacao.structureCabo[] mCabos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaVeias(ref DeclaracoesInterligacao.structureVeia[] mVeias)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdicionaItemCabos4(string revisao, DeclaracoesInterligacao.structureCabo cabo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdicionaItemVeias4(string revisao, DeclaracoesInterligacao.structureVeia veia)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaCabos4(string revisao, List<int> lPainelSel, ref DeclaracoesInterligacao.structureCabo[] mCabos, List<string> lCabos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaCabosEnergisa(string revisao, List<int> lPainelSel, ref Relatorios_CabosEnergisaDWG.structureRelatCabosEnergisa[] mCabos, List<string> lCabos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaCabosEletroSul(string revisao, List<int> lPainelSel, ref DeclaracoesInterligacao.structureCabo[] mCabos, bool bRepeteCapo, List<string> lCabos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaCabosENEL(string revisao, List<int> lPainelSel, ref DeclaracoesInterligacao.structureCabo[] mCabos, bool bRepeteCapo, List<string> lCabos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaCabosTaesa(string revisao, List<int> lPainelSel, ref DeclaracoesInterligacao.structureCabo[] mCabos, bool bRepeteCapo, List<string> lCabos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaReguas(string revisao, int painel, ref DeclaracoesInterligacao.structureRI[] mReguas)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaReguasPortas(string revisao, int painel, ref DeclaracoesInterligacao.structureRI[] mReguas)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaBornesReguas(string revisao, int painel, ref DeclaracoesInterligacao.structureRI[] mReguas, bool bCadastro)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaCabosNosBornesRI(string revisao, int painel, ref DeclaracoesInterligacao.structureRI[] mReguas, ref ProgressBar ProgressBar1, int padraoDI)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaJumpersNosBornesRI(string revisao, int painel, ref DeclaracoesInterligacao.structureRI[] mReguas, ref ProgressBar ProgressBar1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaVeiasReserva(string revisao, int painel, ref DeclaracoesInterligacao.reservaRI[] mAterrados, ref DeclaracoesInterligacao.reservaRI[] mNaoAterrados, bool bELS)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaVeiasUsadasLivres(string revisao, string tag_cabo, ref List<string> lVeiasUsadas, ref List<string> lVeiasLivres)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ApagaCabosRevPn(string revisao, ref List<int> lPn)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void exportaCabos(string revisao, ref DeclaracoesInterligacao.caboSync[] mCabosSync)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void leCabos(string revisao, ref DeclaracoesInterligacao.caboSync[] mTodosCabosSync)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CorrigeNothing(string tabela)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LeTodosCabosUsados(ref List<string> lCabosUsados)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LeTodosCabos(ref List<string> lTodosCabos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static cDadosAccessInterligacao2()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
