using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.Windows;
using zgryP3p0xulXcIZvObyh;

namespace Eletron4;

[StandardModule]
public sealed class DeclaracoesGeral
{
	public struct ConfigEletron
	{
		public string Idioma;
	}

	public struct ConfigCaderno
	{
		public string DirProjeto;

		public string DirSimbologiaEletrica;

		public string dirSimbologiaTopografico;

		public string dirSimbologiaLayout;

		public string dirSimbologiaRelatorios;

		public string DataSource;

		public string BancoDeDados;

		public string User;

		public string Senha;

		public int Norma;

		public bool SCapa;

		public bool SCorpo;

		public bool CCapa;

		public bool CCorpo;

		public int maxCapa;

		public int maxCorpo;

		public int PassoPagina;

		public string Local;

		public int CorConexao;

		public int CorTextoCircuito;

		public int CorInterligacao;

		public int CorTextoInterligacao;

		public string EstiloLinha;

		public double EstiloLinhaEscala;

		public double FonteCircuito;

		public double FonteCabos;

		public double FonteCruzamento;

		public int incluirColuna;

		public int LarguraFixaPaginas;

		public string SeparadorCaboVeia;

		public string CaracterTerminalIndefinido;

		public string SeparadorCruzamento;

		public string PrefixoCruzInterno;

		public string SufixoCruzInterno;

		public string PrefixoCruzExterno;

		public string SufixoCruzExterno;

		public string PrefixoCruzFF;

		public string SufixoCruzFF;

		public string SeparadorCarimbo;

		public string SeparadorPainelRegua;

		public int ModeloBobina;

		public int InterligacaoLayout;

		public string Banco;
	}

	public struct TagConfig
	{
		public string chave;

		public string tag;

		public string descricao;

		public string posFuncional;

		public string docFuncional;

		public string unidade;

		public string unidadeDestino;

		public int tipoTag;

		public int DIN;

		public int indice;

		public string vao;

		public string tag61850;

		public string subestacao;

		public string colunaAdicional;

		public string TagAlternativoEntrada;

		public string Comando1;

		public string Comando2;

		public string Bloco;

		public string pagina;

		public string coluna;

		public string Handle;

		public string user;

		public string data;

		public string tipoDeSinal;
	}

	public struct ConfigLP
	{
		public string listaDePontos;

		public string worksheet;

		public string chavePrimaria;

		public string tag;

		public string enderecoFisico;

		public string unidade;

		public string descricaoResumida;

		public string descricaoCompleta;

		public string tipoDeSinal;

		public string funcaoPorta;

		public string documentoFuncional;

		public string posicaoFuncional;

		public string documentoLogico;

		public string posicaoLogico;
	}

	public struct tPagina
	{
		public string Pagina;

		public string PgNum;

		public string PgAlfa;

		public double PgDec;

		public string Titulo1;

		public string Titulo2;

		public string Titulo3;

		public string Titulo4;

		public string Unidade;

		public string Alternativo;
	}

	public struct Reguas
	{
		public bool Visivel;

		public string Inicio;

		public string Fim;

		public double Delta;

		public string Espessura;

		public short Cor;

		public double Div;

		public double AltBase;

		public Point3d Pti;

		public Point3d Ptf;

		public double LarguraBase;
	}

	public struct tLayout
	{
		public double largDescricao;

		public double largVariavel;

		public double largFolha;

		public double largAdicional;

		public bool bMText;
	}

	public struct Titulos
	{
		public bool bTitulo1;

		public bool bTitulo2;

		public bool bTitulo3;

		public bool bTitulo4;
	}

	public struct Revisoes
	{
		public string Pagina;

		public int Posicao;

		public string RevisaoOriginal;

		public string Revisao;

		public string Descricao;

		public string Data;

		public string Elaborador;

		public string Verificador;

		public string Aprovador;
	}

	public struct StructureAtivo
	{
		public string Pagina;

		public string Unidade;

		public string Alternativo;

		public int Painel;

		public string Tipo;
	}

	public struct arqLogico
	{
		public int Indice;

		public string Nome;

		public string Path;
	}

	public struct ConfRelatorioIndice
	{
		public short CorLinha;

		public short CorTexto;

		public double TamanhoFonte;

		public short QuantColunas;

		public double AlturaInicial;

		public double DistEntreColunas;

		public double AlturaDoBloco;

		public string sFonte;

		public bool Tit1;

		public bool Tit2;

		public bool Tit3;

		public bool Tit4;

		public bool bRev;
	}

	public struct Atalhos
	{
		public string atalho1;

		public string atalho2;

		public string atalho3;

		public string atalho4;

		public string atalho5;

		public string atalho6;
	}

	public struct Hardlock
	{
		public string company;

		public bool Chk;

		public bool existe;

		public ushort handle;

		public short tipo;

		public int erro;

		public uint ID;
	}

	public struct DadosRibbon
	{
		public string Secao;

		public string Cor;
	}

	public struct LayersExtra
	{
		public bool bELET1;

		public string sELET1;

		public bool bELET2;

		public string sELET2;

		public bool bELET3;

		public string sELET3;

		public bool bELET4;

		public string sELET4;

		public bool bELET5;

		public string sELET5;
	}

	public struct StructurePaginas
	{
		public string Pagina;

		public double PaginaDec;

		public string Alternativo;

		public string Revisao;

		public string Unidade;

		public string Vao;
	}

	public struct AppInfo
	{
		public string Cliente;

		public string DiasRestantes;

		public bool bValido;

		public string mensagem;

		public int appNum;
	}

	public struct structureLic
	{
		public int ChaveLic;

		public string NomeCliente;

		public int CodigoCliente;

		public int Software;

		public string Licenca;

		public int Quantidade;

		public bool Habilitada;

		public int DataExpira;

		public int DiasTrial;

		public double Versao;

		public int DataCriacao;

		public string Observacao;
	}

	public struct structureUser
	{
		public int ChaveUser;

		public int ChaveLic;

		public string Email;

		public string versaoCAD;

		public double versaoSW;

		public int UltLogin;

		public int IDUnico;
	}

	public struct structureUserPC
	{
		public int Software;

		public string Email;

		public string Licenca;

		public int UltLogin;

		public int DataCriacao;

		public int DiasTrial;

		public int UsoTrial;

		public int IDUnico;

		public string NomeCliente;

		public int CodigoCliente;

		public double Versao;

		public int DiaInicialTrial;

		public string CPUID;
	}

	public const string nomeAplicacao = "Elétron";

	public const string appnameD = "DiagLog";

	public const string appnameE = "Eletron";

	public const string appnameA = "ArqNet";

	public static string sTipoInfo;

	public const string versao = "v26.03";

	public const double versaoNuvem = 26.03;

	public static bool app;

	public static int LicModeSel;

	public static int indexRibbon;

	public static object[,] mMensagem;

	public static StringCollection attProtCollection;

	public static StringCollection attRevProtCollection;

	public static StringCollection BitolaCollection;

	public static object[,] mPaginas;

	public static StructurePaginas[] mPaginasNova;

	public static object[,] mTitulos;

	public static object[,] mRevSimplificada;

	public static Dictionary<string, string> dicRevSimplificadaNova;

	public static Revisoes[] mRevCompleta;

	public static ObjectId blockFormatoID;

	public static string blockFormatoName;

	public static bool bAnularEventos;

	public static bool bSuspenderEvento;

	public static bool bSuspenderEventoExpImpClonar;

	public static bool bCancelarEventoTrocaDocumento;

	public static List<string> lDwgRegen;

	public static string sDocumentoclip;

	public static bool bPararRelatorio;

	public static PaletteSet _pspag;

	public static uscPaginas _uscPagina;

	public static Dictionary<int, string> dicPainel;

	public static Dictionary<int, string> dicDWG;

	public static Dictionary<int, string> dicAplicacao;

	public static string gsCaminhoBloco;

	public static int monitorConexao;

	public static string mdac;

	public static ConfigEletron ConfElet;

	public static ConfigCaderno Conf;

	public static ConfigLP ConfLP;

	public static StructureAtivo ativo;

	public static arqLogico arqAtivo;

	public static ConfRelatorioIndice IPg;

	public static Atalhos atalhosPag;

	public static string companyHardlock;

	public static short tipoHardlock;

	public static DadosRibbon ativoRibbon;

	public static AppInfo vAppInfo;

	[MethodImpl(MethodImplOptions.NoInlining)]
	static DeclaracoesGeral()
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
		WJkyKaTe27P0AIjC8LiE.anJTee6tgpK(WJkyKaTe27P0AIjC8LiE.oyaTe3YS354);
		sTipoInfo = PeVdSSTemosVL6age6QC.anJTee6tgpK(0x7F99A93D ^ _003CModule_003E_007B8db8dd6f_002D8df6_002D4ec7_002D8062_002D3391de66f7e6_007D.m_8f25251078fa4548856915ee4080e5ed.m_713fadba7f144eda84111d755b7f72d9, PeVdSSTemosVL6age6QC.a8hTeXWGnmn);
		attProtCollection = new StringCollection();
		attRevProtCollection = new StringCollection();
		BitolaCollection = new StringCollection();
		blockFormatoID = p3Of6DTlET4a5unJArlL.anJTee6tgpK(p3Of6DTlET4a5unJArlL.OVoTlZQ0OUH);
		blockFormatoName = "";
		bAnularEventos = false;
		bSuspenderEvento = false;
		bSuspenderEventoExpImpClonar = false;
		bCancelarEventoTrocaDocumento = false;
		lDwgRegen = new List<string>();
		sDocumentoclip = "";
		bPararRelatorio = false;
		gsCaminhoBloco = "";
		monitorConexao = 0;
		mdac = PeVdSSTemosVL6age6QC.anJTee6tgpK(0x4E3BE017 ^ _003CModule_003E_007B8db8dd6f_002D8df6_002D4ec7_002D8062_002D3391de66f7e6_007D.m_8f25251078fa4548856915ee4080e5ed.m_fc73fca973374745a25c800581bd3ce8, PeVdSSTemosVL6age6QC.a8hTeXWGnmn);
		ConfElet = default;
		Conf = default;
		ConfLP = default;
		IPg = default;
		atalhosPag = default;
		vAppInfo = default;
	}
}
