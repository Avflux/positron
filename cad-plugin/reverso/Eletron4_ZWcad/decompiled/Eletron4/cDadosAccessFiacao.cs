using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class cDadosAccessFiacao
{
	public object db;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void fechaConexao()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public cDadosAccessFiacao()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaLayouRapidoPainel(int dwgCorrente, int painel, int posicao, ref List<string> lista)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaRevisoesDwgCorrente(int dwgCorrente, ref DeclaracoesFiacao.structureRevisoes[] mRevisoes)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaMaioresRevisoesDwg(ref DeclaracoesFiacao.structureRevisoes[] mRevisoes)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaRevisoesAnterioresDwgCorrente(int dwgCorrente, ref DeclaracoesFiacao.structureRevisoes[] mRevisoes, DateTime data)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaPnRev(int dwgCorrente, string revisao, ref DeclaracoesFiacao.structurePnRev[] mPnRev)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaPotenciais(int dwgCorrente, string revisao, int painel, ref DeclaracoesFiacao.structurePontosPotencial[] mPot)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaSequenciamento(int dwgCorrente, string revisao, int painel, int potencial, ref DataGridView dgSeq, ref Label lblSecao, ref Label lblCor)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<int> CarregaTodosPotenciais(int dwgCorrente, string revisao, int painel, string tag, bool b3T, ref Dictionary<int, int> dicPot)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaDicPotenciais(int dwgCorrente, string revisao, ref Dictionary<int, int> dicPot)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaSecaoCabos(int dwgCorrente, string revisao, int painel, ref List<string> lSecao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public List<string> CarregaDispositivos(int dwgCorrente, string revisao, int painel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaDispTipoIndexModelo(int dwgCorrente, string revisao, int painel, ref DeclaracoesFiacao.structureVF[] mDisp, bool bAdicionaDispSemFiacao = false)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AtualizaBlocoTopografico(int indice, string blocoTopografico)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AtualizaBlocoLayout(int indice, string blocoLayout)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaTerminaisDispositivo(int dwgCorrente, string revisao, int painel, string tag, ref DeclaracoesFiacao.structureFiacao[] mfiacao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaTerminaisContato(int dwgCorrente, string revisao, int indexModelo, ref DeclaracoesFiacao.structureFiacao[] mfiacao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaTerminaisMascara(int dwgCorrente, string revisao, int indexModelo, ref DeclaracoesFiacao.structureFiacao[] mfiacao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaTerminaisRegua(int dwgCorrente, string revisao, int painel, int indexRegua, ref DeclaracoesFiacao.structureFiacao[] mfiacao, bool bIncuiPG = false, bool bTodosOsBornes = false)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool TemReguas(int dwgCorrente, string revisao, int painel)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaReguas(int dwgCorrente, string revisao, int painel, ref DeclaracoesFiacao.structureRB[] mReguas)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaBornes(int dwgCorrente, string revisao, int painel, int indexRegua, ref DeclaracoesFiacao.structureBN[] mBornes)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaPotenciaisNaMatriz(int dwgCorrente, string revisao, int painel, int indexRegua, ref DeclaracoesFiacao.structureBN[] mBornes)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void InsereLink(int dwgCorrente, string revisao, int painel, int indexRegua, string terminal, int potencial)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveLink(int dwgCorrente, string revisao, int painel, int indexRegua, int potencial)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaLigacoesTerminal(int dwgCorrente, string revisao, int painel, string tag, string tipo, ref DeclaracoesFiacao.structureFiacao[] mFiacao, ref DeclaracoesFiacao.structureLink[] mLink)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaPotenciaisPainel2(int dwgCorrente, string revisao, int painel, ref DeclaracoesFiacao.structurePotencial[] mPotencial)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaPotenciaisPainelEstat(int dwgCorrente, string revisao, int painel, ref DeclaracoesFiacao.structurePotencial[] mPotencial)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaPotenciaisReguas(int dwgCorrente, string revisao, int painel, List<string> lReguas, ref StructureBorneAplicacao[] mReguas)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaPotenciaisPainel3(int dwgCorrente, string revisao, int painel, ref DeclaracoesFiacao.structurePotencial[] mPotencial)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaPotDiferencialPainel(int dwgCorrente, string revisao, int painel, ref DeclaracoesFiacao.structurePotencial[] mPotencial)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool BornesVizinhos(int dwgCorrente, string revisao, int painel, int indexRegua, string borne1, string borne2)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AtualizaOrdemTerminal(int indice, int ordem)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AtualizaPotenciais(int dwgCorrente, string revisao, ref DataTable varTableFiacaoH)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ReordenaOrdemPotenciais(int dwgCorrente, string revisao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdicionaItemPotencial(DeclaracoesFiacao.structurePontosPotencial pot)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveRevisaoTabela(string nomeTabela, int dwgCorrente, string revisao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdicionaItemCircuitos(string revisao, long dwg, int painel, string nomeCircuito, int potencial)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdicionaItemContatos(string revisao, long dwg, long indexModelo, string nomeModelo, string terminal, double terminalNum, string orientacao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void atualizaItemOrientacaoFiacao(string orientacao, string revisao, long dwg, long indexModelo, string terminal, string tipo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdicionaItemPortas(string revisao, long dwg, long indexModelo, string nomeModelo, string regua, string borne, string terminal, double terminalNum, string tipo, string orientacao = "")
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdicionaItemBornes(string revisao, long dwg, DeclaracoesEntidades.StructureBorne born)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AtualizaBlocoLayoutReguas(int indice, string blocoLayout)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdicionaItemDispositivos(string revisao, long dwg, int painel, string Tag, string alternativo, string Tipo, string Handle, string Pagina, string BlocoTopografico, string BlocoLayout, int posicaoNum, int ordem)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdicionaItemAplicacao(string revisao, long dwg, int Numero, string Nome, string Secao, string Cor, string TipoCabo, string Isolacao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaPlaquetasEletron3(int dwg, int painel, ref Declaracoes2.StructurePlaquetas[] mPlaquetas)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemovePlaquetas(int dwgCorrente)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdicionaItemPlaqueta(long dwg, int painel, Declaracoes2.StructurePlaquetas plaqueta)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public long ExisteItemPreferencias(long dwg, int painel, string campo, ref string valor)
	{
		return 0L;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AtualizaItemPreferencias(long Indice, long dwg, int painel, string campo, string valor)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AdicionaItemPreferencias(long dwg, int painel, string campo, string valor)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void BuscatodosOsBornesPotenciais(ref frmGerenciadorReguasBornes.structureDadosFiacao[] mDadosFiacao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool ExistePlaquetasDoEletron3(int dwg)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaTodasReguasDG(int dwgCorrente, string revisao, int painel, ref DataGridView dg)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaLigacoesTerminalSIEMENS(int dwgCorrente, string revisao, int painel, string tag, string tipo, ref DeclaracoesFiacao.structureFiacao[] mFiacao, ref DeclaracoesFiacao.structureLinkSiemens[] mLinks)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaTerminaisReguaTAF(int dwgCorrente, string revisao, int painel, int indexRegua, ref DeclaracoesFiacao.structureFiacaoTAF[] mfiacao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaLigacoesTerminalTAF(int dwgCorrente, string revisao, int painel, string tag, string tipo, ref DeclaracoesFiacao.structureFiacaoTAF[] mFiacaoTAF)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static cDadosAccessFiacao()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
