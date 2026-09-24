using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class clsDispositivoAuxiliares
{
	public struct StructureFuncaoAuxiliares
	{
		public int iModelo;

		public string sNome1;

		public string sNome2;

		public int iIndice;

		public string sFuncao;
	}

	public struct StructureCorrigeMODELO
	{
		public Point3d ptMod0;

		public Point3d ptMod1;

		public double dAltura0;

		public double dAltura1;

		public string sHandle;

		public string sNomeBloco;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public clsDispositivoAuxiliares()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool InserirContatoAux(ref Declaracoes2.StructureContatoAuxBobina cont, bool bNomeVisivel, bool bNomeAlternativo)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void BuscaContatosUsados(ref Declaracoes2.StructureContatosAuxiliares[] mCONTATOS, string sPainel, int iIndiceModelo, string sNome)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void BuscaUsoDosContatosAuxiliares(ref Declaracoes2.StructureContatosAuxiliares[] mCONTATOS, int iIndiceModelo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void carregaContatosNoDG(ref DataGridView DGContatos, Declaracoes2.StructureContatosAuxiliares[] mContatos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void carregaContatosAuxiliaresNoDG(ref DataGridView DGContatos, Declaracoes2.StructureContatosAuxiliares[] mContatos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaTipoDoContatoDepoisDeImportarDoExcel(ref DataGridView dg, int iIndiceModelo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void selecionaContatoAuxiliarInserido(ref Declaracoes2.StructureContatoAuxBobina myBL)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static ObjectId zy3pEH1NOE(ref Point3d P_0)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return (ObjectId)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaOsTerminaisAuxiliares(string sHandle, string sTipoModelo, string sT1, string sT2, string sT3, int atualizaXdata = 0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<string> carregaNomeContatosAux(ref frmContatosAux.BlocosAuxiliares[] mBlocosAuxiliares, ref bool bCaminhoSimb)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static List<string> CarregaMatrizBlocosAux(ref frmContatosAux.BlocosAuxiliares[] mBlocosAuxiliares, string sNorma)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CarregaOsPaineisEmUsoPelosContatos(ref ComboBox combo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CarregaOsContatosAuxiliares(DataGridView dgDisp, ref DataGridView dgContatos, string sPainel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string carregaDGContatosAuxiliares(ref DataGridView Dg, ref DataGridView DgContatos, ref frmContatosAux Paleta, ref frmContatosAux.BlocosAuxiliares[] mBlocosAuxiliares, int iQuantidadeDeNomes)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void buscaTipoDoContatoSelecionado(DataGridView dgContatos, ref string sTipoContato, ref string sComportamentoContato)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CarregaContatosAuxiliaresInseridos(ref DataGridView dg, string sPainel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaColunasDGContatosAuxiliares(ref DataGridView DGContatos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaColunasDGContatosAuxiliaresMODELO(ref DataGridView DGContatos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void carregaContatosAuxiliaresDoModeloInserido(ref DataGridView DGContatosInseridos, int indexModelo, int indexContato)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void carregaDispPrincipalDoModeloInserido(ref DataGridView DGContatosInseridos, int indexModelo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaNomeDoModelo(string sHandle, string sNome1, string sNome2, string sAlternativo, bool bNome, bool bAlternativo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaNomeDoContatoAuxiliar(string sHandle, string sNome1, string sNome2, string sAlternativo, bool bNome, bool bAlternativo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void criaInsercaoTabela(ref Declaracoes2.StructureContatoAuxBobina cont)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaInsercaoTabela(ref Declaracoes2.StructureContatoAuxBobina cont, ref BlockReference blockContato)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void limpaInsercaoTabela(string handle)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaModelo(string handleBobina)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaContatos(string handleBobina, int indexModelo, Declaracoes2.StructureContatosAuxiliares[] mContatos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool podeTrocarModelo(string handleBobina, int indexModeloAntigo, int indexModeloNovo, Declaracoes2.MModelosDeContatos[] mMODELO)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SincronizaContatos(int indexModelo = 0, bool bMarcaErros = true)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaContatosOrfaos()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool BuscaModeloVisivel(string sHandle)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaNomeDoModeloDosDispositivos(string sHandle, string sNome1, string sNome2, string sAlternativo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaNomeDoContatoAuxiliarDispositivos(string sHandle, string sNome1, string sNome2, string sAlternativo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ExisteDispositivoAuxiliar(int iIndiceModelo, int iIndiceContato)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ExisteDispositivoDiferente(string sTipoContato, int iIndiceModelo, int iIndiceContato)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void BuscaContatosUsadosDoModelo(ref StructureFuncaoAuxiliares[] mFuncoes, int iIndiceModelo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaFuncaoDoContatoAux(ref StructureFuncaoAuxiliares[] mFuncoes, int iIndiceModelo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaContatoOrfao(ref List<int> lIndex, int iIndiceModelo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool CorrigirModelo(int iIndiceModelo)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CorrigeAlturaDosModelos(int iIndiceModelo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static double BuscaAlturaDoModelo(string sHandle)
	{
		return 0.0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static double BuscaAlturaDoModeloEspecifico(int indexModelo)
	{
		return 0.0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CorrigeAlturaDoModelosSelecionado(int iIndiceModelo, double dAltura)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void VerificaTamanhoContatosAuxiliares()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GuardaAsFuncoesDosModelos(ref Declaracoes2.StructureFuncoesDispositivo[] mFuncoes)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EscreveAsFuncoesDosModelos(ref Declaracoes2.StructureFuncoesDispositivo[] mFuncoes)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static clsDispositivoAuxiliares()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
