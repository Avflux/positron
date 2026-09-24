using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class clsTextos
{
	public struct mTitulos
	{
		public string shandle;

		public int indice;

		public string sTitulo;

		public string sPagina;
	}

	public struct mTextos
	{
		public string sIndice;

		public string shandle;

		public string sTipo;

		public string sTexto;

		public string sPagina;
	}

	public struct structureTextoCaderno
	{
		public string sHandleTexto;

		public string sHandleVeia;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public clsTextos()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string TiraNothing(string Value)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string TiraDBNull(object Value)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static object TiraDBNullNumero(object Value)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool criaMTextoLP(ref Declaracoes2.StructureDescricaoLP[] PortasSelecionadas, int iIndex, double DistLinha, double Fonte, double Largura, double OrdenadaY, double OrdenadaX, bool bAdicionaLinha, string sTipo, bool bMline2, bool bMline3, bool bPorta, ref string sHandleultimaline, int linhas = 2)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void criaLinhaFinalDoTextoLP(ref string sUltimaline, string chavePri, double Largura)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaTextoDasPortas(ref Declaracoes2.StructureDescricaoLP[] PortasSelecionadas)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizarTexto(DBText Texto, string NovoValor)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaUmTexto(string sHandle, string NovoValor)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string LeUmTexto(string sHandle)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string EncontraPaginaDoTexto(string sHandle)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizarMTexto(MText Texto, string NovoValor)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void capturaTodosTextosETitulos(ref mTextos[] mTextos, bool bIncluirNumero, string tbQuant)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void capturaTodosTextosDeCabos(ref List<string> lHandleCabos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaTodosTextosETitulos(ref DataGridView dg, ref mTextos[] mTextos)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ExportaPaginas(ref Worksheet oSheet, ref DataGridView dg, DeclaracoesGeral.Titulos tit, bool bAlternativo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ImportaTitulos(ref Worksheet oSheet, ref mTitulos[] mTitulos, DeclaracoesGeral.Titulos tit, bool balternativo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ExportaTextos(ref Worksheet oSheet, ref DataGridView dg)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ImportaTextos(ref Worksheet oSheet, ref DataGridView dg, ref mTextos[] mTextosAtualizados)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string EncontraTextoDoCabo(structureTextoCaderno[] Texto, string sHandleLinha)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaUnidadeAlternativo(string pagina, string unidade, string alternativo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaTextoEmBrabcoSemXdata()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagaUmTexto(string sHandle)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void CriarUmTexto(ref string sTipo, string sTexto, string sHandlePL, string sXdata)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static ObjectId CriarUmTextoSimples(Point3d pt, ref string sTipoHV, string sTexto)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		return (ObjectId)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void NomeValido(ref TextBox tbNome)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static double RetornaPrimeiroTerminal(string T)
	{
		return 0.0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string RetornaValorMais0000MaisNum(string sValor)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EncontraAlturadoTexto_Linha(ref double dLinha, ref double dTexto)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static clsTextos()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
