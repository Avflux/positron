using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

public class clsConexao
{
	public struct Apagados
	{
		public string handle;

		public string handleSup;

		public bool bApagar;
	}

	public struct structureAUXDERIVACAO
	{
		public string sHandle;

		public string sTipo;

		public string Potencial;

		public string sNome;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public clsConexao()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CriarConexao()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool verificaDispConex(Point3d pt, ref string sTipo, ref short Painel, ref int Potencial, ref string Handle, ref string Secao, ref string Cor, ref int Aplicacao, [Optional][DefaultParameterValue(false)] ref bool bpossuiRB)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CriarConexaoAutomatica(string tipoConexao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CriarDerivacaoAutomatica(string tipoDerivacao)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CriarHatch(Point3d pt, string layer, string handle)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagarDerivacoesLinhas(DeclaracoesEntidades.StructureConexao conex, string handle, string layer)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void ApagarTextosAuxiliaresCircuito(string layer, string handle)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DBText criarTextoCircuito(DeclaracoesEntidades.StructureConexao conex, Polyline pl, string layer)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public DBText criarTextoDePara(DeclaracoesEntidades.StructureConexao conex, Polyline pl, string layer, short tipoTexto)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void editarDadosCircuitoDerivacaoJumper(DeclaracoesEntidades.StructureConexao conex)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void editarTextoAuxiliarTipo123(DeclaracoesEntidades.StructureConexao conex)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void AlterarCorTamanhoTextoAuxiliarTipo123()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void trocarPotencial(int potencialAlvo, DeclaracoesEntidades.StructureConexao conex)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void carregaEquipComFiacao(ref List<int> lEquip)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void trocarPotencialTextoAuxiliar(int potencialAlvo, DeclaracoesEntidades.StructureConexao conex)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ligarTextoAuxiliar(string layer)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void editarSecaoCor(short modo, int aplicacao = 0, string secaoA = "", string CorA = "")
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void editarSecaoCorPaginas(short modo, List<string> lPaginas, int aplicacao = 0, string secaoA = "", string CorA = "")
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CriarMarcador(short cor, Point3d ptIns, bool cbCor, bool cbSecao, bool cbPot, string sPot, string layer, double fonte, DeclaracoesEntidades.StructureConexao conex, string handleSel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static bool possuiTerminalRB(ref BlockReference blockref)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void atualizaSecaoCor(int indiceApl, string secao, string cor)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void removeAplicacao(int indiceApl)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void ativaAplicacao(int indiceApl, ref Dictionary<string, int> dicCores, int corApl)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void desativaAplicacao(ref Dictionary<string, int> dicCores)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void buscaAplicacoesUsadas(ref List<int> lAplUsadas, ref List<string> lPagUsadas)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void sincronizaCircuitos()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void editarConexoesDerivacoes()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static double CalculaTerminalNumerico(string T)
	{
		return 0.0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LeTodosCircuitos(ref DeclaracoesEntidades.StructureConexao[] conex)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void LeTodosTextosAuxiliaresCircuito(ref structureAUXDERIVACAO[] sTextoAux)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public static void EditaValorNomeCircuito(string sHandle, string sNovoNome, string sTipo)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static clsConexao()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
