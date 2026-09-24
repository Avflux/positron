using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

[StandardModule]
public sealed class DeclaracoesInterligacao
{
	public struct structureInterlig
	{
		public string Tag_Cabo;

		public int Num_Veia;

		public string Nome_Veia;

		public int dwg1;

		public string Documento1;

		public double X1;

		public double Y1;

		public short painel1;

		public string tag1;

		public string alternativo1;

		public string nRegua1;

		public string terminal1;

		public double terminalNum1;

		public short tipoBorne1;

		public string handle1;

		public string layer1;

		public string layer1Erro;

		public string posicao1;

		public short indexModelo1;

		public string tipo1;

		public int dwg2;

		public string Documento2;

		public double X2;

		public double Y2;

		public short painel2;

		public string tag2;

		public string alternativo2;

		public string nRegua2;

		public string terminal2;

		public double terminalNum2;

		public short tipoBorne2;

		public string handle2;

		public string layer2;

		public string layer2Erro;

		public string posicao2;

		public short indexModelo2;

		public string tipo2;

		public string revisao;

		public int DWG;

		public string criador;

		public DateTime data;
	}

	public struct structureCabo
	{
		public int Indice;

		public string revisao;

		public string Tag;

		public string Formacao;

		public bool Blindagem;

		public int Pn1;

		public int Pn2;

		public string Codigo;

		public string Funcao;

		public int Aterrar;

		public double Comprimento;

		public string Trajeto;

		public string Instrucao;

		public double Diametro;

		public string Grupo;

		public int Cabos;

		public string criador;

		public DateTime data;

		public string AterrarOrigem;

		public string AterrarDestino;

		public string Formacao2;

		public string blindagem2;

		public string Origem;

		public string Destino;

		public string sPaginas;

		public string sDocumentos;
	}

	public struct structureVeia
	{
		public string revisao;

		public string Tag;

		public int Num_Veia;

		public string Nome_Veia;

		public bool Uso;

		public string Funcao;
	}

	public struct structureEstimativa
	{
		public string sPn1;

		public string sPn2;

		public int iPn1;

		public int iPn2;

		public int iQuant;
	}

	public struct structureBornesInseridos
	{
		public string Tag;

		public string NRegua;

		public int Qtde;
	}

	public struct structureRI
	{
		public string Tag;

		public string NRegua;

		public string Tipo;

		public int IndexModelo;

		public int DWG;

		public borneRI[] Bornes;
	}

	public struct borneRI
	{
		public string Borne;

		public int Ordem;

		public int TipoBorne;

		public string Pagina;

		public caboRI[] cabos;

		public jumperRI[] jumpers;
	}

	public struct caboRI
	{
		public string Tag_Cabo;

		public string Formacao;

		public string Funcao;

		public bool Blindagem;

		public bool bAterrar;

		public int Veia;

		public string NomeVeia;

		public string FuncaoVeia;

		public int Cabos;

		public int iPainelDest;

		public string sPainelDest;

		public string DocDest;

		public string DocOrigem;

		public string TagDest;

		public string NReguaDest;

		public string BorneDest;

		public string PaginaDest;

		public string PaginaOrigem;

		public string PosicaoDest;

		public string Trajetos;
	}

	public struct jumperRI
	{
		public string Tag;

		public string NRegua;

		public string Borne;

		public string Pagina;

		public bool bEntra;

		public bool bSai;
	}

	public struct reservaRI
	{
		public string Tag;

		public List<string> lveias;

		public string sPainelDest;

		public string Veias;
	}

	public struct borneAranha
	{
		public string Revisao;

		public int Painel;

		public string Tag;

		public string NRegua;

		public int TipoBorne;

		public string Borne;

		public double Ordem;

		public int Posicao;
	}

	public struct PosborneAranha
	{
		public string Pagina;

		public int Posicao;

		public Point3d PtIns;

		public double Ordem;
	}

	public struct PosborneDInterlig
	{
		public string Pagina;

		public int Posicao;

		public Point3d PtIns;

		public double Ordem;
	}

	public struct ConfigDInterlig
	{
		public int tipo;

		public int tipoCruzamento;

		public bool bJumperCima;

		public double margemEsquerda;

		public double margemDireita;

		public double margemCima;

		public string diretorio;

		public double distEntreReguas;

		public double distEntreVeias;

		public double distEntreJumpers;

		public double distInicialBorneCabo;

		public int corHatch;

		public int corJumper;

		public int corTracoVeiasReservas;

		public int corTextoVeiasReservas;

		public double anguloTextoVeiasReservas;

		public int corVeias;

		public int corTextoVeia;

		public double anguloTextoVeia;

		public int corTextoDestino;

		public double anguloTextoDestino;

		public double alturaInsercaoCabo;

		public int corLinhaVCabo;

		public bool bUsa2LinhasBornes;

		public double raioHatch;

		public double larguraBorne;

		public double alturaFonteVeia;

		public double alturaFonteCruzamento;

		public double alturaFonteReservas;

		public string textStyle;

		public bool bA1;
	}

	public struct borneJ
	{
		public string Tag;

		public string NRegua;

		public string Borne;

		public int TipoBorne;

		public double Y;

		public double X;

		public string Pagina;

		public double PaginaNum;

		public int Posicao;

		public string Handle;

		public Point2d ptInsTerm;

		public int contVeiasLigadas;

		public int contVeiasLigadas2;
	}

	public struct jumper
	{
		public long indexOrig;

		public long indexDest;

		public double dist;

		public bool bMesmaPaginaColuna;
	}

	public struct caboAranha
	{
		public string Tag_Cabo;

		public string Formacao;

		public string Funcao;

		public bool Blindagem;

		public bool bAterrar;

		public string sPainelDest;

		public string Pagina;

		public double PaginaNum;

		public int Coluna;

		public double Y;

		public double X;

		public int Linha;

		public string Lado;

		public bool bParTrioTrancado;

		public int[] mIndices;

		public string[] mVeias;

		public borneDestino[] mDestinos;

		public Point3d ptIns;

		public List<string> lVeiasUsadas;

		public List<string> lVeiasLivres;

		public string Handle;
	}

	public struct borneDestino
	{
		public string tagDest;

		public string nReguaDest;

		public string borneDest;

		public string FuncaoVeia;
	}

	public struct veiasCompl
	{
		public string Pagina;

		public double PaginaNum;

		public int Posicao;

		public int indiceBorne;

		public string Veia;

		public borneDestino Dest;

		public string LadoEntradaBorne;
	}

	public struct limitesMatriz
	{
		public int inicio;

		public int final;
	}

	public struct cruzamentoCaboAranha
	{
		public string tag_Cabo;

		public int coluna;

		public borneCruzamentoCaboAranha[] mBornes;
	}

	public struct borneCruzamentoCaboAranha
	{
		public ObjectId ID;

		public string rb;

		public string pagina;
	}

	public struct caboSync
	{
		public string Revisao;

		public string Tag_Cabo;

		public int Painel;

		public string Caderno;

		public string Folha;

		public int Coluna;
	}

	public struct AltPagUsada
	{
		public double Y;

		public string Pagina;
	}

	public struct structureEstiloInterligacao
	{
		public double LinetypeScale;

		public string Linetype;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DeclaracoesInterligacao()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
