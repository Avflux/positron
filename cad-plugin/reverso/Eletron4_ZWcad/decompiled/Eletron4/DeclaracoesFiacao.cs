using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

[StandardModule]
public sealed class DeclaracoesFiacao
{
	public struct structurePontosPotencial
	{
		public double X;

		public double Y;

		public int potencial;

		public short painel;

		public string layer;

		public string secao;

		public string cor;

		public string tag;

		public string nRegua;

		public string terminal;

		public double terminalNum;

		public string alternativo;

		public double dOrdem;

		public int PosicaoNum;

		public string tipo;

		public short tipoBorne;

		public short indexModelo;

		public bool bJumper;

		public bool bLink;

		public string handle;

		public int Aplicacao;

		public int Ordem;

		public string revisao;

		public int dwg;

		public string criador;

		public DateTime data;
	}

	public struct structurePosicaoDisp
	{
		public int painel;

		public string tag;

		public int posicaoNum;

		public int ordem;
	}

	public struct structurePontosBlocos
	{
		public string nome;

		public double X;

		public double Y;
	}

	public struct structurePnRev
	{
		public string revisao;

		public int painel;
	}

	public struct structureRevisoes
	{
		public string revisao;

		public int Dwg;

		public string criador;

		public DateTime data;
	}

	public struct structureVF
	{
		public string Tag;

		public string Alternativo;

		public string Tipo;

		public int IndexModelo;

		public int PosOrdem;

		public string Handle;

		public string BlocoTopográfico;

		public string BlocoLayout;

		public int Indice;
	}

	public struct structureFiacao
	{
		public string NRegua;

		public string Terminal;

		public string Pagina;

		public int TipoBorne;

		public int LM;

		public structureLigacao[] Lig;

		public string Circuito;

		public string BlocoLayout;

		public long Indice;
	}

	public struct structureLigacao
	{
		public string Tag;

		public string Alternativo;

		public string Term;

		public string Secao;

		public string Cor;
	}

	public struct structureLink
	{
		public string borne;

		public bool bUp;

		public bool bDown;
	}

	public struct structureLinkSiemens
	{
		public string Regua;

		public int iRegua;

		public int iOrdem;

		public string sOrdem;

		public string borne;

		public bool bUp;

		public bool bDown;
	}

	public struct StructureLinks
	{
		public string sModelo;

		public string sRegua;

		public string sBorne1;

		public string sBorne2;

		public int iQuant;

		public string sTipo;
	}

	public struct structureRB
	{
		public int indexRegua;

		public string regua;
	}

	public struct structureBN
	{
		public int indice;

		public string borne;

		public string handle;

		public bool bLink;

		public bool bReserva;

		public int[] Potenciais;

		public int Potencial;

		public int[] Ordens;
	}

	public struct structureRelFiacao
	{
		public string Tag;

		public string NomeDispositivo;

		public string Circuito;

		public int numLigacoes;

		public string Terminal;

		public int TipoBorne;

		public string sLM;

		public string Disp1;

		public string Term1;

		public string Disp2;

		public string Term2;

		public string Disp3;

		public string Term3;

		public string Disp4;

		public string Term4;

		public string Secao12;

		public string Cor12;

		public string Secao34;

		public string Cor34;

		public string Pagina12;

		public string Pagina34;

		public string Jumper;

		public string sMat;
	}

	public struct structurePotencial
	{
		public int Potencial;

		public string Tag;

		public string Alternativo;

		public string NRegua;

		public string Terminal;

		public bool bLink;

		public string Secao;

		public string Cor;

		public string Pagina;

		public int indexModelo;

		public int PosicaoNum;

		public int TipoBorne;

		public double TerminalNum;

		public string Orientacao;

		public int Aplicacao;
	}

	public struct structureAnilhas
	{
		public string Tag1;

		public string Terminal1;

		public string Anilha1;

		public string Orientacao1;

		public string Tag2;

		public string Terminal2;

		public string Anilha2;

		public string Orientacao2;

		public string Secao;

		public string Cor;

		public bool bTemLink;
	}

	public struct structureRelPotencialSiemens
	{
		public int potencial;

		public string tag1;

		public string term1;

		public string ori1;

		public string tag2;

		public string term2;

		public string ori2;

		public string secao;

		public string cor;

		public string pagina1;

		public string pagina2;

		public string Aplicacao;
	}

	public struct structureDiferencial
	{
		public string Tag1;

		public string Terminal1;

		public int PosicaoNum1;

		public int TipoBorne1;

		public string Alt1;

		public string Tag2;

		public string Terminal2;

		public int PosicaoNum2;

		public int TipoBorne2;

		public string Alt2;

		public string Secao;

		public string Cor;

		public string Pagina;
	}

	public struct structureRelPotencial
	{
		public int potencial;

		public string tag1;

		public string alt1;

		public string term1;

		public string tag2;

		public string alt2;

		public string term2;

		public string secao;

		public string cor;

		public string pagina;
	}

	public struct structureRelPlaquetas
	{
		public string Indice;

		public string Nome;

		public string Modelo;

		public string Quant;

		public string Desc1;

		public string Desc2;

		public string Desc3;

		public string Painel;

		public double ordem;
	}

	public struct structureEstatFiacao
	{
		public double comprimento;

		public string secao;

		public string cor;
	}

	public struct structureAplicacao
	{
		public int Indice;

		public string Nome;

		public string Secao;

		public string Cor;

		public string TipoCabo;

		public string Isolacao;
	}

	public struct structureFiacaoTAF
	{
		public string NRegua;

		public string Terminal;

		public string Pagina;

		public int TipoBorne;

		public string Handle;

		public structureLigacaoTAF[] Lig;
	}

	public struct structureLigacaoTAF
	{
		public string Tag;

		public string Alternativo;

		public string Term;

		public string Handle;
	}

	public struct structurePortasTAF
	{
		public string Tag;

		public string Handle;

		public string ChavePrimaria;

		public string EFC;

		public string Descricao;

		public string TipoSinal;

		public string Funcao;
	}

	public static int ilinhaCEMIGD;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DeclaracoesFiacao()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
