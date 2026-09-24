using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.Runtime;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class Correcao
{
	public struct mBlocosCores
	{
		public string sNomeBloco;

		public string sATT;

		public string sCor;

		public int iCor;
	}

	public struct CorracaoModelo
	{
		public int iModelo;

		public int iContato;

		public int iContatoNovo;
	}

	public struct CorracaoModeloBL
	{
		public int iModelo;

		public int iContato;

		public int iContatoNovo;

		public string sTipo;

		public string sT1;

		public string sT2;

		public string sT3;
	}

	public struct mBlocos
	{
		public string sNome1;

		public string sBorne;

		public string sNome2;

		public string sAlternativo;

		public int iPainel;

		public string sPainel;

		public int iOrdem;

		public int iTipo;

		public int iPot;

		public string sTipo;

		public string sHandle;

		public bool bPinta;

		public string sBloco;

		public string sPagina;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Correcao()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("CorrigeStyle")]
	public static void corrigeStyles()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool corrigeTextStyles()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("CorrigeDisp")]
	public static void CorrecaoDisp()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("CorrigeBornes")]
	public static void CorrecaoBornesVisiveis()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void correcaoTextosCircuitos()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void correcaoLines()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("ApagaLayouts")]
	public static void ApagaLayouts()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("ApagaPlaquetas")]
	public static void ApagaPlaquetas()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("CorrigeContatosAux")]
	public static void CorrigeContatos()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CorrigeContatosAux(int indexModelo = 0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("LimpaTextosLPCopiados")]
	public static void LimpaTextosLPCopiados()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LimpaXData(Entity Ent, string sNomexData)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("apagaXDataTerceiros")]
	public static void ApagaXDataTerceiros()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("CorrigeJanelas")]
	public static void corrigeJanelas()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void mostraBloco(string sHandle)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("corrigeDicMascaras")]
	public static void corrigeDicMascaras()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("corrigePortas")]
	public static void corrigePortas()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("CorrigeCabosSingelos")]
	public static void CorrecaoCabosSingelos()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("CorrigeModelosDeContatos")]
	public static void CorrigeModelosDeTodosContatos()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CorrigeModelosDeContatos(int indexModelo = 0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("CorrigeCabos")]
	public static void CorrecaoCabosNothing()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("corrigeOrdemBornes")]
	public static void corrigeOrdemBornes()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("apagarTodosOsTextosDasVeias")]
	public static void ApagarTodosOsTextosDasVeias()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("CorrigeBlocosContatosAux")]
	public static void CorrigeBlocosContatosAux()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("ApagarTextosEmBranco")]
	public static void ApagarTextosEmBranco()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("PesquisaBlocos")]
	public static void PesquisaBlocos()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void pesquisaElementosEletronNoDWG(string sNome1, string sNome2, string sAlternativo, bool P, bool A, bool B, bool M, bool E, bool bConexao, bool bCabo, bool bJumper, ref DataGridView dg, ref bool bNome2, ref bool bAlternativo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("CorrigeHandleSuperior")]
	public static void CorrigeHandleSuperior()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("Limpahandle")]
	public static void limpaHandleSuperior()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool verificaConexao(Point3d pt, ref string sTipo, ref short iPainel, ref int iPotencial, ref string sHandle, string sPagina, ref string sNome)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtivaTodasAsPagina()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("CorrigeCoresDosBlocos")]
	public static void CorrigeCoresDosBlocos()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void carregaBlocosInseridos(ref List<string> lBl)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void MMg1xjoRaA(ref mBlocosCores[] P_0, ref List<string> P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static void lu61bhmRNc(ref mBlocosCores[] P_0, List<string> P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LimpaVeiasDeDWGsApagados()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("RENPAGA")]
	public static void RenumerarPagina()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CommandMethod("REMLAYDUP")]
	public static void RemoveDuplicadoLayoutRapido()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Correcao()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
