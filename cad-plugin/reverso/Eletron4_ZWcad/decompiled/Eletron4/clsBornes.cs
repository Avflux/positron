using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class clsBornes
{
	public struct StructureBlocoBorne
	{
		public string numero;

		public string numeroComplem;

		public double ordem;

		public int IndiceRegua;

		public string Handle;

		public string Pagina;

		public string NomeRegua;

		public string Painel;

		public string conector;

		public int LM;

		public int tipo;

		public int Visivel;

		public string sNomeDoBloco;

		public string sCaminhoBloco;

		public string Orientacao;

		public string Layout;
	}

	public struct BornesTipo
	{
		public string Nome;

		public Point3d iIni;

		public Point3d iFim;
	}

	public struct mBornes
	{
		public int _0IndiceRegua;

		public int _1Ordem;

		public string _2Numero;

		public string _3Alternativo;

		public string _4Tipo;

		public int _5ListaDeMateriais;

		public string _6Pagina;

		public string _7Handle;

		public string _8NumeroOriginal;

		public double _9sPG;

		public double _10sLin;

		public double _11sCol;

		public int _12iPot;

		public string _13Cabo;

		public string _14Veia;

		public string _15Orientacao;

		public string _16Layout;

		public string _17NomeUnico;
	}

	public struct ordemBornes
	{
		public int indexRegua;

		public string Nome;

		public string Alternativo;

		public string sHandle;

		public double dX;

		public double dY;

		public double Ordem;

		public int iOrdemSelecao;

		public int Tipo;

		public int Lm;

		public string Orientacao;

		public string Layout;
	}

	public struct mOrdem
	{
		public double pagina;

		public int potencial;

		public int ordem;

		public string shandle;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public clsBornes()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static double BuscaTamanhodoBorneH(string shandle, int parte)
	{
		return 0.0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static double BuscaTamanhodoBorneV(string shandle, int parte)
	{
		return 0.0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static double BuscaTamanhodoBorneMeioH(string shandle, int parte)
	{
		return 0.0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OcultaAtributoNome()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool OcultaAtributos(ref ObjectId ObjectId, string sAtributo)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OcultaAtributoPainel()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool OcultaAtributosPainel(ref ObjectId ObjectId, string sAtributo)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InserirBorne(ref StructureBlocoBorne myBornes, int indice, bool bPrimeiro, bool bPainel, bool bRegua, ref Point3d point)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void insereBorneAutomaticamente(ref DeclaracoesEntidades.StructureBorne Borne, string sCaminhoBloco, string sNomeDoBloco, bool InsereBorne, bool Up)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void indefineUmBorne(string sHandle)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditarOsBornesDasReguasSelecionada(Declaracoes2.StructureModeloDeReguas[] mModeloDeReguasNovos, int index)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaUmBorne(ref string sHandle, string sAttributo, string sValor)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditarOsTodosOsBornesDasReguasSelecionada(DeclaracoesEntidades.StructureBorne[] mBornes)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditarOsTodosOsBornesMigradosDasReguaSelecionada(DeclaracoesEntidades.StructureBorne[] mBornes, string sReguaAntiga)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaOsBornesDasReguasExcluidas(Declaracoes2.StructureModeloDeReguas[] mModeloDeReguasNovos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void capturaTodosOsBornesDoDesenho(int indexRegua, ref DeclaracoesEntidades.StructureBorne[] mBornes)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void capturaOutrosBornesDoDesenhoNaoSel(int indexRegua, ref DeclaracoesEntidades.StructureBorne[] mBornes, List<string> sHandleBornes, ref int iMaiorOrdem)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AdicionaPotencialAosBornes(ref DeclaracoesEntidades.StructureBorne[] mBornes, frmGerenciadorReguasBornes.structureDadosFiacao[] mDadosFiacao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static double BorneNumericoValido(string sBornes)
	{
		return 0.0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OrdenaReguaDeBornesPorPotencial(ref DataGridView dg, ref mBornes[] mBornes, string sOrdem)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OrdenaReguaDeBornesPorPGPotencial(ref DataGridView dg, ref mBornes[] mBornes, string sOrdem)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OrdenaReguaDeBornesPorPotencial(ref DataGridView dg, string sCriterio)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool SelecionaBornesParaEdicao(ref ordemBornes[] BornesSelecionadas, ref int indexModelo, ref double iMaiorOrdem)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ocultarBornesSelecionados()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ligarBornesPagina(string layer)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string calculaBorneNumericoDecimal(string pagina)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void MudaOrdemDeUmBorne(string sHandle, int iOrdem)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void buscaTipoLm(ref int iRegua, ref int iLm, ref int itipo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool SelecioanBorne(ref int iPainel, ref int iRegua, ref string sNomeBloco)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void PositivoInterno(List<string> lHandles, string valor)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool SelecionaBornesECircuitosParaEdicao(ref ordemBornes[] BornesSelecionadas, ref List<string> lHandPot, ref int indexModelo, ref double iMaiorOrdem)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static clsBornes()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
