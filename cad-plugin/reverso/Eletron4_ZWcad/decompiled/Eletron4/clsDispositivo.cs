using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class clsDispositivo
{
	public struct mBlocosPrincipal
	{
		public string sNome1;

		public string sNome2;

		public string sAlternativo;

		public int iPainel;

		public string sPainel;

		public int iOrdem;

		public int iLM;

		public bool bComplementar;

		public string sTipo;

		public string sHandle;

		public string sTerminais;

		public int iQuantTerminais;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public clsDispositivo()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CarregaBlocosNaMatriz(ref object mBlocos, string sSimbologia)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ExtraiNomeCaminhoDwgPorTipo(string sCaminhoCompleto, ref string sDiretorio, ref string sNomeCompleto, ref string sNomeDWGVisivel, ref string sTipo)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaContatosModeloDispositivo(Entity entPri)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void promoveComplementar(Entity entPri)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int carregaOsContatosDoModeloselecionado(string sNomeModelo, ref Declaracoes2.MModelosDeContatos[] mModelo, ref Declaracoes2.StructureContatosAuxiliares[] mContatos)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InsereOsContatosAuxiliaresModelo(Point3d pt, string sNorma, ref BlockReference blockRefAnterior, Declaracoes2.StructureModelo Modelo, Declaracoes2.StructureContatosAuxiliares[] mCONTATOS, string sLayer, double dDistanciaEntreModelo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string BuscaTerminaisNoModelo(string sModelos, ref Declaracoes2.MModelosDeContatos[] mMODELO)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string BuscaNomeDoModelo(int iIndexModelo, ref Declaracoes2.MModelosDeContatos[] mMODELO)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int BuscaIndiceDoModelo(string sModelo, ref Declaracoes2.MModelosDeContatos[] mMODELO)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CarregaBlocos(ref object mBlocos, string sTipoBloco)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ExtraiNomeCaminhoDwgPorTipoAux(string sCaminhoCompleto, ref string sDiretorio, ref string sNomeDWGVisivel, ref string sTipo, ref string sComportamento, ref string iQuantNomes)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void carregaModelosNoCombo(ref ComboBox combo, ref Declaracoes2.MModelosDeContatos[] mMODELO)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InserirBlocoSimbologia(string sCaminhoBloco, string sNomeBlocoDWG, string sTerm, ref DeclaracoesEntidades.StructureDispositivo Disp, Declaracoes2.MModelosDeContatos[] mMODELO, Declaracoes2.StructureContatosAuxiliares[] mCONTATOS, string sFabricante, bool bOcultaModelo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void insereTabelaModelo(ref BlockReference blockRef, DeclaracoesEntidades.StructureDispositivo Disp, Declaracoes2.MModelosDeContatos[] mMODELO, Declaracoes2.StructureContatosAuxiliares[] mCONTATOS, string sFabricante, bool bOcultaModelo, double dDistanciaEntreModelo = 0.0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string selecionaDispositivoPrincipalInserido(ref Declaracoes2.MDispPrincipal myBL, ref DeclaracoesEntidades.StructureDispositivo Disp)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void BuscaTerminaisDoBloco(BlockReference blockRef, ref string sTerminais)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string BuscaTerminaisTipoTdoBloco(BlockReference blockRef)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ObjectId selDispositivoPrincipal(ref Point3d ptInsert, string msg)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return (ObjectId)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void carregaMatrizContatos(DataGridView DGContatos, ref Declaracoes2.StructureContatosAuxiliares[] mContatos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static object ApagaOsContatoAuxiliarDoModelo(int indexModelo)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static object ApagaOsContatoAuxiliarDoDispositivo(int indexModelo, int indexContato)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static object ApagaUmModelo(int indexModelo)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void carregaModelosNoDG(ref DataGridView dg, Declaracoes2.MModelosDeContatos[] mMODELO)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaColunasDGModelos(ref DataGridView dg)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaOsDispositivosPrincipais(int iIndexModelo, string sNome, string sTerm, string sTopo, string sLayout, int iLm1, int iLm2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaOsTerminaisDaBobina(ObjectId BlockID, string sNomeBloco, int iIndex, string sTerm)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaOsModelosDosPrincipais(int iIndexModelo, string sNomeModelo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string ModeloBobina(ref List<string> lHandlesOcultos)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string OcultaModeloBobinaEditada(ref List<string> lHandlesOcultos)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaColunasDGContatosInseridos(ref DataGridView ContatosInseridos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ReInsereContatosModelo(Declaracoes2.StructureContatosAuxiliares[] mContatos, int indexModelo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int BuscaPainelDoDispPrincipal(string sHandleDaEntity)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int verificaExisteNomeDispositivo(int iPn, string Nome1, string Nome2, string Alternativo, ref string handle, ref string tipo)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static object TrocaPainel(string TipoSelec, DeclaracoesEntidades.StructureDispositivo Disp, DeclaracoesEntidades.StructureMascara Masc, int iPainelAntigo, int iNovoPainelSel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaNomeDoDispositivoPrincipal(ref Declaracoes2.MDispPrincipal myBL, string sNome1, string sNome2, string sAlternativo, bool bNomeVisivel, bool bAlternativoVisivel, string sHandleSel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaLMDoDispositivo(object[,] mLM)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaContatos(Declaracoes2.StructureContatosAuxiliares[] mContatos, int indexModelo, int index)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void pesquisaDispositivosPeMnoDWG(ref mBlocosPrincipal[] mDispositivos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void pesquisaDispositivosTerminais(ref mBlocosPrincipal[] mDispositivos, ref List<int> lLM)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void editaUmBlocoDispositivoPrincipal(string sHandle, int iPN, string sNome1, string sNome2, string sAlternativo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaApenasOsNomeDoDispositivoPrincipal(string shandle, string sNome1, string sNome2, string sAlternativo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaTerminaisDispositivoSemModelo(mBlocosPrincipal[] mDispEditados)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EncontraModelosUsados(ref List<int> lModelosUsados)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EncontraModelosComContatos(ref List<string> lModelosContatos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ModeloDoDispositivoPrincipalTipo0()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ModeloDoDispositivoPrincipalTipo1()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ModeloDoDispositivoPrincipalTipo2()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ModeloDoDispositivoPrincipalTipo3()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaUmModeloDeDispositivoPrincipalTipo0(string sHandle)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaUmModeloDeDispositivoPrincipalTipo1(string sHandle)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaUmModeloDeDispositivoPrincipalTipo2(string sHandle)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaUmModeloDeDispositivoPrincipalTipo3(string sHandle)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static object BuscaModeloExistente(string shandleBobina)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LPDisponivel(ref string lp)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static clsDispositivo()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
