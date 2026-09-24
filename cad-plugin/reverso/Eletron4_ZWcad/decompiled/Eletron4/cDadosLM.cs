using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class cDadosLM
{
	public struct StructureLM
	{
		public string sDescResumida;

		public string sDescCompleta;
	}

	public struct structureDispLM
	{
		public int Indice;

		public int iDWG;

		public int iPainel;

		public string sTag;

		public int iIndiceMaterial;

		public int iQuantidade;

		public int lOrdem;

		public bool bAvulso;

		public string sDestino;

		public string sDescDestino;

		public string sAlternativo;

		public string sHandle;

		public int IndiceLM;
	}

	public struct structureOrdemDispLM
	{
		public int Indice;

		public string sTag;

		public int iIndiceMaterial;

		public int lOrdem;

		public int OrdemLay;

		public int quantidade;
	}

	public struct structureLMRelelatorio
	{
		public string Tag;

		public string Index;

		public string Quantidade;

		public string Desc;

		public string DescResumida;

		public string DescCompleta;

		public string sModelo;

		public string sFabricante;

		public string CodCli;

		public string IndexLM;

		public string sOrdem;

		public string sD1;

		public string sD2;

		public string sD3;

		public string sD4;

		public string sD5;

		public string sD6;

		public string sD7;

		public string sD8;

		public string sD9;

		public string sD10;
	}

	public struct indexCODMateriais
	{
		public int indice;

		public int indexLM;
	}

	public object db;

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void fechaConexao()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public cDadosLM()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DeclaracoesClonar.structureMaterial[] CarregaDadosLMMatriz()
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaDadosLMLista(ref ComboBox COMBO, List<int> lLM)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string BuscaFabricanteDoMaterial(ref string index)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void buscaListaDeFabricanteDoMaterial(ref clsLM.LModFab[] mModFab)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ComplementaModelo(Declaracoes2.MModeloDeMascara[] mModelo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaDadosPaineisLM(ref int[] Paineis)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaDadosDispositivos(ref structureDispLM[] sDisp, int iDWG, int iPN)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaDadosOrdemDispositivos(ref structureOrdemDispLM[] sDisp, int iDWG, int iPN)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AtualizaDadosOrdemDispositivos(int indice, int ordem)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CarregaDadosDispositivosMultiplosPN(ref DataGridView dg, ref string[,] mLM, ref indexCODMateriais[] mCod, int iMultiplicador)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AtualizaLMBaseadoNosDWGsCadastrados()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void RemoveDWG(int indiceDWG)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static cDadosLM()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
