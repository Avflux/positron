using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class clsPortas
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	public clsPortas()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void RemoveUmaHandle(ref object[,] PortasSelecionadas, ref Declaracoes2.MModeloDePortas[] mPortasUsadas)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void DivideHandles(ref string sTodosHandle, string sRemoverHandle, ref string sTodasPaginas)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void MarcaOsContatosUsadosNoDG(int Indice, string sNome, ref DataGridView dg, ref Declaracoes2.MModeloDePortas[] mPortasUsadas, int indicePaineSel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int ContaContatos(string sTexto)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void selecionaUmaPortaInserida(ref DeclaracoesEntidades.StructurePortas myBL, ref int iPainel, ref BlockReference ent)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void IndefinePortasApagadas(int indexModelo, int indexPorta)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaUmaPorta(int indexModelo, int indexPorta, string sEFC, string sTerminais, string sRegua, string sBornes)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaTodasPortas(Declaracoes2.MModeloDePortas[] mPORTAS)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void IndefinePortasModelo(string[] mPortas)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaAsPortasDeUmaMascara(string sHandle, bool bAlternativoVisivel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaOsIndicesDoModeloDeMascara(string sHandleDaMascara, int iIndice)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaUmaDefinicao(DBText texto)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SincronizaPortas(bool bMarcaErros = true, bool bProgress = true)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GravaHandleNaPorta(ref string sHandlePorta, ref string sHandleTexto)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void GravaHandleNaDefinicao(ref string sHandleDefinicao, ref string sHandlePorta)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static Point3d InserirPorta(Declaracoes2.MPorta myBL, bool bNomeVisivel, bool bNomeAlternativo, string indice, Point3d point)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return (Point3d)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string selecionaUmaPorta(ref DeclaracoesEntidades.StructurePortas portaE, ref int iPainel)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static ObjectId DBYTfvCWmP(ref Point3d P_0)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return (ObjectId)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool SelecionaPortas(ref object[,] PortasSelecionadas, int indiceDoModelo, string sNome1, string sNome2, string sAlternativo, ref bool bContinua, ref bool bDiferente)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void SelecionaPortasOuDefinicao(ref object[,] PortasSelecionadas, string sTipoDef)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void IndefineUmaPorta(string sHandle, bool bLimpaTudo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void IndefineUmaDefinicao(string sHandle)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LimpaPorta(string sHandle, bool bLimpaTudo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtribuiPortas(string sModelo, ref object[,] PortasSelecionadas, ref frmDefinicao.mItensSelecionadosDG[] mItensSelecionadosDG, ref Declaracoes2.MModeloDePortas[] mPortas_DefUsadas, int indicePainelSel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtribuiDefinicao(string smodelo, ref object[,] DefSelecionadas, ref frmDefinicao.mItensSelecionadosDG[] mItensSelecionadosDG, ref Declaracoes2.MModeloDePortas[] mPortas_DefUsadas)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void InserePaginaAsDefinicoes(ref object[,] DefSelecionadas, ref frmDefinicao.mItensSelecionadosDG[] mItensSelecionadosDG)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void preencheAtributosPorta(ref ObjectId BlockID, frmDefinicao.mItensSelecionadosDG[] mItensSelecionadosDG, int iIndice, DeclaracoesEntidades.StructurePortas porta, bool PreencheLogico)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtribuiChavePrimaria()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool ExportaImportarPortas()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void BuscaDescricaoDaLP(ref Declaracoes2.StructureDescricaoLP[] PortasSelecionadas)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int leaChavePrimariaAntigaDasPortas(ref mTrocaChavePri[] mChaves, ref PortaExportada[] mPortas)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaChavePrimaria(ref mTrocaChavePri[] mChaves)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaAsPortasTrocadas(structureAtributosSub[] mAtributosHandle)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaAtributosPorta(ref ObjectId BlockID, DeclaracoesEntidades.StructurePortas porta, bool PreencheLogico)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaPortasPortas(string sPainel, int indexModelo, Declaracoes2.MModeloDePortas[] mPortas)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaPortasImportadasDoExcel(int indexModelo, List<int> lIndiceAntigo, List<int> lIndiceNovo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaNomeDePortasDeUmaMascara(string shandle, string sNome1, string sNome2, string sAlternativo, bool bAlternativo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaChavePrimariaPortasDefinicao(ref structureAtributosSub[] mHandle)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CarregaTodasAsPortasPortas(ref Declaracoes2.MModeloDePortas[] mPORTASAlt)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void VerificaPortasDiscrepantes(Declaracoes2.MModeloDePortas[] mPORTAS, ref Declaracoes2.MModeloDePortas[] mPORTASAlt)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void corrigeAsPortas()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static clsPortas()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
