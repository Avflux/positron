using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class ClsVerificadorProjetoFiacao
{
	public struct _structurePn
	{
		public int iPN;

		public string sPN;
	}

	public struct StrucTerminais
	{
		public string T;

		public string V;
	}

	public struct _structureModRegua
	{
		public int iPainel;

		public string sPainel;

		public int iRegua;

		public string sNomeRegua;

		public DeclaracoesEntidades.StructureBorne[] mBorne;
	}

	public struct _structuremRegua
	{
		public int iPainel;

		public string sPainel;

		public int iRegua;

		public string sNomeRegua;
	}

	public struct _StructureAnalisePorta
	{
		public int indexMascara;

		public int indexPorta;

		public string sNomeMascara;

		public string sEFC;

		public string sRegua;

		public string sattT;

		public string sattB;

		public string sTerm;

		public string sTermM;

		public string sBorn;

		public string sBornM;

		public List<string> lT;

		public List<string> lB;

		public string sHandle;

		public string sPagina;

		public bool bPnApagados;

		public int iPn;
	}

	public struct _StructureConexao
	{
		public int iPotencial_Veia;

		public int indexCor;

		public int iPesoLinha;

		public string sSecao;

		public string Cor_Nome;

		public string Handle;

		public string HandleSup;

		public int iTipo;

		public string sPaginaa;

		public string sPainel;

		public int iPainel;

		public double x;

		public double y;

		public bool bPnApagado;

		public Point3d ptIni;

		public Point3d ptFim;
	}

	public struct _StructuremDispositivo
	{
		public string Handle;

		public string Nome1;

		public string Nome2;

		public string Alternativo;

		public string sTerminais;

		public short Painel;

		public string ChavePrimaria;

		public int indexModelo;

		public string Modelo;

		public bool Complementar;

		public double posX;

		public double posY;

		public int iLM1;

		public int iLM2;

		public short tipoContatoAux;

		public double distContAux;

		public bool NomeVisivel;

		public bool AlternativoVisivel;

		public string Topografico;

		public string Layout;

		public string Usuario;

		public string Data;

		public bool bPnApagados;

		public int iPn;
	}

	public struct _StructuremAuxiliar
	{
		public string Nome1;

		public string Nome2;

		public string Alternativo;

		public string sTerminais;

		public string sTerminaisMod;

		public string HandleBob;

		public string Handle;

		public int IndexModelo;

		public int IndexContato;

		public short TipoDoContato;

		public short TipoDoComportamento;

		public string TipoBlocoUsado;

		public string TerminaisBlocoUsado;

		public string Usuario;

		public string Data;

		public bool bPnApagados;

		public int iPn;
	}

	public struct _errosPorta
	{
		public string sMasc;

		public int iIndiceMascara;

		public int iIndicePorta;

		public string sNome;

		public string sEfc;

		public string sRegua;

		public string sTerBorne;

		public string sDuplicado;

		public string sIndefinido;

		public string sHandle;
	}

	public struct _StructurERROBorne
	{
		public int iPn;

		public string sPn;

		public string sRegua;

		public string sErro;

		public string sHandle;
	}

	public struct _StructurefiacaoErro
	{
		public string sCorFiacao;

		public string sPainel;

		public string sValor;

		public string iPotencial;

		public string sCabo;

		public string sPagina;

		public double x;

		public double y;
	}

	public struct HandlePorta
	{
		public string sHandle;

		public string sPagina;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public ClsVerificadorProjetoFiacao()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void buscaPaineisDoDG(ref List<string> lPn, ref List<string> lPnAoagado)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void buscaDadosDeFiacaoDWG(ref _StructureConexao[] m_Fiacao, ref DeclaracoesEntidades.StructureBorne[] m_TodosBornes, ref _StructureAnalisePorta[] m_TodasPortas, ref _StructuremDispositivo[] m_Disp, ref _StructuremAuxiliar[] m_Aux, ref List<string> lPn, ref List<string> lPnApagados, ref List<string> LFiacaoTTDuplicada, string sTipoRelat)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static string LeOsTerminaisdeUmIndiceDeContatosAuxiliar(ref int iIndiceModelo, ref int iIndiceContato)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void PintaFiacao(ref _StructureConexao[] mFiacao, int icor = 0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void carregaTree(ref TreeView tree, _StructureConexao[] mFiacao, List<string> LFiacaoTTDuplicada, ref _StructurefiacaoErro[] mCorFiacao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void carregaOrfao(ref DataGridView dgFiacaoOrfao, _StructureConexao[] mFiacao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LeOsTerminaisDeUmaPorta(ref Entity ent, ref _StructureAnalisePorta pot)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LeOsTerminais(ref Entity ent, ref string sT, ref string sB, ref string sR)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void buscaReguasVazias(ref _structuremRegua[] mReguas)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void mostraPotencialErrado(string sPotencial)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void mostraPotencialNaPagina(string sPotencial, string sPG)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void mostraPotencialSelecionado(ref DataGridView dg, _StructurefiacaoErro[] mCorFiacao, string sCorFia)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void formatadgPotencialSelecionado(ref DataGridView dg)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void AtualizaDGPotencialSelecionado(ref DataGridView dg)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static ClsVerificadorProjetoFiacao()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
