using System.Collections.Generic;
using System.Runtime.CompilerServices;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class clsImportarProjetos
{
	public struct mEquip
	{
		public int iPainel;

		public string sPainel;
	}

	public struct mDWG
	{
		public int iDWG;

		public string sNome;

		public string sCaminho;
	}

	public struct mCabos
	{
		public int iDWG;

		public string sNomeCabo;
	}

	public struct mIndiceTrocaDWG
	{
		public int iDWG;

		public int iDWG_Troca;
	}

	public struct mIndiceTrocaPN
	{
		public int iPainel;

		public string sPainel;

		public int iPainelNovo;

		public string sPainelNovo;
	}

	public struct mTodosCabos
	{
		public string Tag;

		public string Formacao;

		public bool blindagem;

		public int Pn1;

		public int Pn2;

		public string Codigo;

		public string Funcao;

		public int Alarme;

		public int Aterrar;

		public double Comprimento;

		public string Trajeto;

		public string Instrucao;

		public double Diametro;

		public string Grupo;

		public int Cabos;
	}

	public struct mTodasVeias
	{
		public string Tag;

		public int indice;

		public string Nome_Veias;

		public bool Uso;

		public string Handle;

		public int Arquivo;

		public string Pagina;

		public int Chave;
	}

	public struct mExpo
	{
		public int Codigo;

		public string Tipo;

		public int DWG;

		public string Caderno;

		public string Handle;

		public string Pagina;

		public string Posicao;

		public int Painel;

		public string Texto;

		public int DWGDest;

		public string CadernoDest;

		public string PaginaDest;

		public string PosicaoDest;

		public string NomeRegua;

		public int indiceModelo;

		public bool atualizado;
	}

	public struct mAtt
	{
		public int DWG;

		public string Handle;

		public string Nome;

		public string Valor;
	}

	public struct mTrocaImportados
	{
		public int iIndice;

		public int iIndiceNovo;
	}

	public struct mTrocaCabos
	{
		public string sCabo;

		public string sCaboNovo;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public clsImportarProjetos()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AualizaCodigoDWG_ExportadosImportados(mIndiceTrocaDWG[] mIndiceTrocaDWG, mTrocaImportados[] _i_IndiceExportados)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int BuscaNovoPainel(mIndiceTrocaPN[] iIndicePN_TROCA, int iPn)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string BuscaNomeDoPainel(mEquip[] mPaineis, int iPn)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int BuscaNovoDWG(mIndiceTrocaDWG[] mIndiceTrocaDWG, int iDWG)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static int BuscaNovoCodidoExportado(mTrocaImportados[] _i_IndiceExportados, int iCodigo)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EncontraPaineisDoDesenho(string dwgFile, ref object mPaineis, mEquip[] mNOVO_PnImportada, ref List<int> lLM)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaNomeDasVeias(mTrocaCabos[] iNomeCabosTroca)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void MudaLMdosBlocos(mTrocaImportados[] iIndiceTrocaLM, bool bLM)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void IndefineTodosAsVeiasDWG()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string BuscaNomeDoCabo(ref mTrocaCabos[] iNomeCabos, string sNome)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static clsImportarProjetos()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
