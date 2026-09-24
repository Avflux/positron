using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class clsBlocos
{
	public struct StructureErros
	{
		public string iPainel;

		public string sTipo;

		public string sPagina;

		public string sHandle;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public clsBlocos()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int AcadObjectCount()
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ObjectId RetornaID_Bloco(string shandle)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return (ObjectId)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void MarcaComoErro(string sHandle, string sDisp, string sTipo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaERROS(ref string sTipo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void calculaOPontoCentralDoBloco(BlockReference blockRef, ref Point3d pt, ref double dPontoDoModelo, string sNomeBlocoAnterior)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaUmAtributoDeUmBloco(ref string sHandle, string sAttributo, string sValor, bool bliga = true)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaNomesDeUmBloco(ref string sHandle, string sNome1, string sNome2, string sAlternativo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaValorDeUmAtributo(ref string sHandle, string sAttributo, string sValor)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaValorDeUmAtributoPMF(ref string sHandle, string iPN, int iLM, clsLM.LModFab[] ModFab, string sModelo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool AtributoVisivelDeUmBloco(ref string sHandle, string sAttributo)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaUmaMascara(ref string sHandle, DeclaracoesEntidades.StructureMascara DispMasc, bool bAlternativoVisivel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void PreencheOsNomesDeUmBloco(ref string sHandle, string sNome1, string sNome2, string sAlternativo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaNomesDeUmBloco(ref string sHandle, string sNome1, string sNome2, string sAlternativo, string sTerm, bool bNomeVisivel, bool bAlternativoVisivel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaTerminaisDeUmBloco(ref string sHandle, string sTerm)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string LeUmAtributoDeUmBloco(ref string sHandle, string sAttributo)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void IndefineCruzamentoDoBloco(ref string sHandle)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaUmTexto(ref string sHandle, string sValor)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ExisteAtributo(string sHandle, string sAtributo)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool AtributoVisivel(string sHandle, string sAtributo)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool LimpaAtributoInvisivel(string sHandle)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtributoVisivelInvidivel(ref string sHandle, string sAttributo, bool bliga)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InsereOsBlocos(ref DataGridView dg)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void removeOsBlocos(ref DataGridView dg)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtivaHighlightDispP(ref DeclaracoesEntidades.StructureDispositivo Disp, string sHandle)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void Unhighlight()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string TipoBlocoDoEletron(ref BlockReference blockRef, ref string sNomeBloco)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string BuscaNomeDoBloco(string sCaminho)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string selecionaUmBlocoDaSimbologia(string sFiltro)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void selecionaVariosBlocos(string sFiltro, List<string> lNomeBlocosSel, ref DataGridView dg)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string insereUmBloco(string sCaminhoBloco, string sNomeDoBloco)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ExecutaATTSYNC(ref DataGridView dg)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ExecutaATTSYNC_UmBloco(ref string s1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void MostraBloco(string sHandle, bool bZoom = true, int dAproximacao = 20)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void OcultaAtributos(ref string sHandle, ref clsBornesInterligAuto.mAtt[] mAtt)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DesOcultaAtributos(ref string sHandle, ref clsBornesInterligAuto.mAtt[] mAtt)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaNomesDeUmBlocoDodispositivoPM(ref string sHandle, string sNome1, string sNome2, string sAlternativo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void VerificaDuplicados(ref StructureErros[] MErros, bool bProgress = true)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Point3d retornaUmPonto()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return (Point3d)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void movePosicaoDoBloco(ref string sHandle, double dx, double dy)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool VerificaDocumetoValidoParaColar()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static clsBlocos()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
