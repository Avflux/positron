using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

[StandardModule]
public sealed class Declaracoes2
{
	public struct StructureTamanhosDosContatos
	{
		public double TIT;

		public double NA;

		public double NF;

		public double RV;
	}

	public struct StructureFuncoesDispositivo
	{
		public string Handle;

		public int index;

		public string Funcao;
	}

	public struct MMascara
	{
		public string sNome1;

		public string sNome2;

		public string sNome3;

		public int iIndiceModelo;

		public int iPainel;

		public string sPainel;

		public string sPagina;

		public string sHandle;

		public string sTipo;
	}

	public struct StructurePlaquetas
	{
		public string Tipo;

		public string Handle;

		public int IndiceRegua;

		public string Nome;

		public string Desc1;

		public string Desc2;

		public string Desc3;

		public string Modelo;

		public int Ordem;
	}

	public struct EstatisticasDeCabos
	{
		public string Tag;

		public string Formacao;

		public string Funcao;

		public double Comprimento;

		public string Trajeto;
	}

	public struct MModeloDePortas
	{
		public int MaxIndice;

		public int IndiceDaPorta;

		public int IndiceModelo;

		public int IndicePN;

		public string NomeModelo;

		public string sEFC;

		public string sTerminais;

		public string sOrientacao;

		public string sBornes;

		public string sRegua;

		public bool Uso;

		public string PaginaPorta;

		public string PaginaDef;

		public string HandlePorta;

		public string HandleDef;
	}

	public struct MModeloDeMascara
	{
		public int iIndiceModelo;

		public string sNomeModelo;

		public long iLM1;

		public long iLM2;

		public string sBlocoTopografico;

		public string sBlocoLayout;

		public string sPlaquetas;

		public string sFabricante;

		public string sDescricao;

		public string Orientacao;
	}

	public struct MModelosDeContatos
	{
		public int iIndiceModelo;

		public string sNomeModelo;

		public int iLM1;

		public int iLM2;

		public string sBlocoTopografico;

		public string sBlocoLayout;

		public string sTerminaisDoDispositivo;

		public string sOrientacao;
	}

	public struct StructureContatosAuxiliares
	{
		public int iIndice;

		public string sT1;

		public string sT2;

		public string sT3;

		public string sOrientacao;

		public string sTipo;

		public string sComportamento;

		public string sUso;

		public int iT;

		public int iTipo;

		public int iComportamento;

		public string sHandle;

		public string sTipoUsados;

		public string sPagina;

		public bool bNA;

		public bool bNF;

		public bool bRV;
	}

	public struct MDispPrincipal
	{
		public bool bOK2;

		public int iPainel;

		public string sPainel;

		public string sNome1;

		public string sNome2;

		public string sAlternativo;

		public int iIndexModelo;

		public int sModelo;

		public bool bComplementar;

		public ObjectId iD;

		public string sHandle;

		public string sTerminais;

		public string sOrientacao;

		public string sNomeBloco;

		public double dAltura;

		public int LM1;

		public int LM2;

		public string sTopografico;

		public string sLayout;
	}

	public struct StructureContatoAuxBobina
	{
		public bool bOK;

		public string sNomeDoBloco;

		public string sCaminhoBloco;

		public string sNomeDisp;

		public string sHandleBobina;

		public string sHandleContato;

		public string sPainel;

		public int iPainel;

		public int iIndiceModelo;

		public int iIndiceContato;

		public string sT1;

		public string sT2;

		public string sT3;

		public string sNome1;

		public string sNome2;

		public string sAlternativo;

		public int iTipo;

		public string sTipo;

		public string sTipoBlocoContato;

		public int iComportamento;

		public string sComportamento;
	}

	public struct MPorta
	{
		public string sNomeDoBloco;

		public string sCaminhoBloco;

		public string sHandle;

		public string sPainel;

		public int iPainel;

		public int iIndiceModelo;

		public string sNomeModelo;

		public string sFabricante;

		public string sNome1;

		public string sNome2;

		public string sAlternativo;
	}

	public struct StructurePortasUsadas
	{
		public int IndiceMascara;

		public int IndiceEFC;

		public string EFC;

		public string Def_Handle;

		public bool Def_Uso;

		public bool Def_Erro;

		public string Porta_Handle;

		public bool Porta_Uso;

		public bool Porta_Erro;
	}

	public struct StructureDescricaoLP
	{
		public Point3d point;

		public string sHandle;

		public double X;

		public double Y;

		public string chavePri;

		public string sDesc;
	}

	public struct StructureModelo
	{
		public string HandleBob;

		public int indexModelo;

		public int indexContato;

		public string HandleContatoAux;
	}

	public struct StructureModeloDeReguas
	{
		public int iMaxIndice;

		public int indexPainel;

		public int indexRegua;

		public string nomeRegua;

		public string nomeAlternativo;

		public int quantBornesS;

		public int quantBornesD;

		public int quantBornesSRes;

		public int quantBornesDRes;

		public int quantBornesRegua;
	}

	public struct StructureBornesEmUso
	{
		public string Handle;

		public string Pagina;

		public double X;

		public double Y;

		public string Seq;

		public string SubSeq;

		public double SeqNum;

		public string Tipo;

		public string PaginaString;

		public long Potencial;

		public long PainelOrigem;

		public string CaboOrigem;

		public int VeiaOrigem;
	}

	public struct StructureIndiceRelatEletroSul
	{
		public string sFolha;

		public string sDescricao;
	}

	public struct ConfRelatorio
	{
		public short CorLinha;

		public short CorTexto;

		public short CorDoJumper;

		public double TamanhoFonte;

		public short QuantColunas;

		public double AlturaInicial;

		public double DistEntreColunas;

		public double AlturaDoBloco;

		public string sFonte;

		public string TAG;

		public string Disp1;

		public string Term1;

		public string Disp2;

		public string Term2;

		public string Cor;

		public string Secao;

		public string Pagina;
	}

	public static StructureTamanhosDosContatos mTamanhosDosContatos;

	public static ConfRelatorio confRelFiacao;

	public static bool bMirrorAtivo;

	public static bool bCancelaMirror;

	public static bool bRotateAtivo;

	public static bool bCanselaRotate;

	public static bool bScaleAtivo;

	public static bool bCancelaScale;

	public static double dDistanciaModelo0;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Declaracoes2()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
		WJkyKaTe27P0AIjC8LiE.anJTee6tgpK(WJkyKaTe27P0AIjC8LiE.oyaTe3YS354);
		bMirrorAtivo = false;
		bCancelaMirror = false;
		bRotateAtivo = false;
		bCanselaRotate = false;
		bScaleAtivo = false;
		bCancelaScale = false;
		dDistanciaModelo0 = 0.0;
	}
}
