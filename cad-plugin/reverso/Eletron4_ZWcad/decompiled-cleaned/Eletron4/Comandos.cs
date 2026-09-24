using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.Windows;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Runtime;
using ZwSoft.ZwCAD.Windows;

namespace Eletron4;

public class Comandos
{
	private static bool bdXTjkEID2;

	private static bool YLcTLKTrE9;

	private frmSplash LjQTwnGi0W;

	[SpecialName]
	private int _0024STATIC_0024InsereDePara_00242001_0024tipo;

	[CommandMethod("ONSPL")]
	public void spl()
	{
		if (Operators.CompareString(DeclaracoesGeral.companyHardlock.ToUpper(), "CADGRAPH", TextCompare: true) == 0)
		{
			LjQTwnGi0W = new frmSplash();
		}
	}

	[CommandMethod("OFFSPL")]
	public void fspl()
	{
		if (Operators.CompareString(DeclaracoesGeral.companyHardlock.ToUpper(), "CADGRAPH", TextCompare: true) == 0)
		{
			LjQTwnGi0W.Close();
		}
	}

	[CommandMethod("ELET")]
	public void elet()
	{
	}

	[CommandMethod("DLOG")]
	public void dlog()
	{
	}

	[CommandMethod("ETPG")]
	public void etpg()
	{
	}

	[CommandMethod("ANET")]
	public void Anet()
	{
	}

	[CommandMethod("EARQ")]
	public void earq()
	{
	}

	[CommandMethod("LOADAUT")]
	public void loadaut()
	{
		Trigger trigger = new Trigger();
		trigger.Register();
	}

	[CommandMethod("UNLOADAUT")]
	public void unloadaut()
	{
		Trigger trigger = new Trigger();
		trigger.Unregister();
	}

	[CommandMethod("RESETLIC")]
	public void ResetLic()
	{
		MySettingsProperty.Settings.LicMode = 0;
		MySettingsProperty.Settings.Save();
	}

	[CommandMethod("CFG")]
	public void ConfGeral()
	{
		new frmConfiguracaoGeral();
	}

	[CommandMethod("RESTAURA")]
	public void Restaura()
	{
		Pagina.restauraCampos();
	}

	[CommandMethod("CAD")]
	public void Cad()
	{
		Caderno caderno = new Caderno();
		caderno.CriaCaderno();
	}

	[CommandMethod("GERDWG")]
	public void gerdwg()
	{
		new frmGerenciadorDWG();
	}

	[CommandMethod("REGH")]
	public void RegH()
	{
		checked
		{
			if (clsRegua.insereReguaH())
			{
				RibbonControl ribbon = ComponentManager.Ribbon;
				int count = ((Collection<RibbonPanel>)(object)((Collection<RibbonTab>)(object)ribbon.Tabs)[DeclaracoesGeral.indexRibbon].Panels).Count;
				int num = count - 1;
				for (int i = 0; i <= num; i++)
				{
					((Collection<RibbonPanel>)(object)((Collection<RibbonTab>)(object)ribbon.Tabs)[DeclaracoesGeral.indexRibbon].Panels)[i].IsEnabled = true;
				}
			}
		}
	}

	[CommandMethod("REGV")]
	public void Regv()
	{
		clsRegua.insereReguaV();
	}

	[CommandMethod("PN")]
	public void PN()
	{
		new frmCadastroDePaineis();
	}

	[CommandMethod("IMPBD")]
	public void IMPBD()
	{
		if (Operators.CompareString(DeclaracoesGeral.Conf.Banco, "SV", TextCompare: true) != 0)
		{
			new frmImportarProjetos();
		}
		else
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1969]), MsgBoxStyle.Information, "Elétron");
		}
	}

	[CommandMethod("DUPCAD")]
	public void DUPCAD()
	{
		new frmDuplicarCaderno();
	}

	[CommandMethod("INDPG")]
	public static void AdicionaIndiceDePagina()
	{
		new frmRelatorio_IndicedePaginas();
	}

	[CommandMethod("RELREV")]
	public static void RELREV()
	{
		new frmRelatorio_Rev();
	}

	[CommandMethod("RELREVF")]
	public void RELREVF()
	{
		new frmRelatorio_Furnas();
	}

	[CommandMethod("RELMATRI")]
	public static void RELMATRI()
	{
		new frmRelatorio_Rev_Matricial();
	}

	[CommandMethod("GERCONT")]
	public void GERCONT()
	{
		new frmGerenciadorContatos();
	}

	[CommandMethod("GERMASC")]
	public void GERMASC()
	{
		new frmGerenciadorMascaras();
	}

	[CommandMethod("DISP")]
	public void DISP()
	{
		new frmDispPrincipal();
	}

	[CommandMethod("PORT")]
	public void PORT()
	{
		new frmPortas();
	}

	[CommandMethod("CONT")]
	public void CONT()
	{
		new frmContatosAux();
	}

	[CommandMethod("DEF")]
	public void DEF()
	{
		if (clsRegua.VerificaRegua())
		{
			new frmDefinicao();
		}
	}

	[CommandMethod("LXLS")]
	public void fcarregaLP()
	{
		string lp = "";
		if (clsDispositivo.LPDisponivel(ref lp))
		{
			using (Process process = new Process())
			{
				process.StartInfo.FileName = lp;
				process.StartInfo.UseShellExecute = true;
				process.Start();
			}
		}
	}

	[CommandMethod("MASC")]
	public void MASC()
	{
		new frmMascara();
	}

	[CommandMethod("LDAT")]
	public void LDAT()
	{
		clsAtributos.ligaNomedeDispositivos();
	}

	[CommandMethod("PINC")]
	public void PINC()
	{
		clsAtributos.Pincel();
	}

	[CommandMethod("MOVPN")]
	public void MUDAPN()
	{
		new frmMudaPN();
	}

	[CommandMethod("DEPARA")]
	public void InsereDePara()
	{
		checked
		{
			_0024STATIC_0024InsereDePara_00242001_0024tipo++;
			clsDePara.CriarDePara(ref _0024STATIC_0024InsereDePara_00242001_0024tipo);
			if (_0024STATIC_0024InsereDePara_00242001_0024tipo == 2)
			{
				_0024STATIC_0024InsereDePara_00242001_0024tipo = 0;
			}
		}
	}

	[CommandMethod("SYNCD")]
	public void SYNCD()
	{
		DeclaracoesGeral._uscPagina.Quantidade = 6;
		DeclaracoesGeral._uscPagina.pbIniciar();
		clsDispositivoAuxiliares.ApagaContatosOrfaos();
		DeclaracoesGeral._uscPagina.pbPasso();
		Correcao.CorrigeModelosDeContatos();
		DeclaracoesGeral._uscPagina.pbPasso();
		clsDispositivoAuxiliares.SincronizaContatos();
		DeclaracoesGeral._uscPagina.pbPasso();
		clsPortas.SincronizaPortas(bMarcaErros: false, bProgress: false);
		DeclaracoesGeral._uscPagina.pbPasso();
		clsDePara.SincronizaDePara(bUpdateProp: false);
		DeclaracoesGeral._uscPagina.pbPasso();
		clsUtilitarios.EditaPortaDipAuxPainelModeloFabricante(bProgress: false);
		DeclaracoesGeral._uscPagina.pbPasso();
		Correcao.CorrigeCoresDosBlocos();
		DeclaracoesGeral._uscPagina.pbFim();
	}

	[CommandMethod("CONFLP")]
	public void ConfLP()
	{
		new frmConfiguracaoLP();
	}

	[CommandMethod("CHVAUT")]
	public void fChvAut()
	{
		clsPortas.AtribuiChavePrimaria();
	}

	[CommandMethod("ADDDESC")]
	public void ADDDESC()
	{
		new frmTextoLP();
	}

	[CommandMethod("SYNCLP")]
	public void SYNCLP()
	{
		clsPortas.ExportaImportarPortas();
	}

	[CommandMethod("MIGPOR")]
	public void MIGPOR()
	{
		new frmMigraPortas();
	}

	[CommandMethod("MCONT")]
	public void mCont()
	{
		new frmImportarModelosDeContatos();
	}

	[CommandMethod("MMASC")]
	public void mMasc()
	{
		new frmImportarModelosDeMascaras();
	}

	[CommandMethod("EDTFUNC")]
	public void EDTFUNC()
	{
		new frmEditaFuncaoBobina();
	}

	[CommandMethod("EDTDISPSA")]
	public void EDTDISPSA()
	{
		new frmEditaDispositivosAvulsos();
	}

	[CommandMethod("EDTDISPS")]
	public void EDTDISPS()
	{
		new frmEditaVariosDispositivos();
	}

	[CommandMethod("LAYMEC")]
	public void LAYMEC()
	{
		new frmLayoutMec();
	}

	[CommandMethod("PLAQ")]
	public void PLAQ()
	{
		new frmPlaquetas();
	}

	[CommandMethod("EPLQ")]
	public void fExpPlaq()
	{
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 819]), MsgBoxStyle.YesNo, "Elétron");
		if (msgBoxResult == MsgBoxResult.Yes)
		{
			cDadosAtualizaBanco cDadosAtualizaBanco2 = new cDadosAtualizaBanco();
			cDadosAtualizaBanco2.LimpaDWGApagadosDoProjeto();
			cDadosAtualizaBanco2.fechaConexao();
			clsDispositivoTacito.exportaPlaquetas();
		}
	}

	[CommandMethod("DELLM")]
	public void ApagaLMExportada()
	{
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1576]), MsgBoxStyle.YesNo | MsgBoxStyle.Critical, "Elétron");
		if (msgBoxResult == MsgBoxResult.Yes)
		{
			msgBoxResult = Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1283], "\r\n"), DeclaracoesGeral.mMensagem[1, 1715]), MsgBoxStyle.YesNo | MsgBoxStyle.Critical, "Elétron");
			if (msgBoxResult == MsgBoxResult.Yes)
			{
				cDadosAtualizaBanco cDadosAtualizaBanco2 = new cDadosAtualizaBanco();
				cDadosAtualizaBanco2.ApagaLMExportada();
				cDadosAtualizaBanco2.fechaConexao();
			}
		}
	}

	[CommandMethod("DELPLA")]
	public void ApagaPLAQUETASExportada()
	{
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1910]), MsgBoxStyle.YesNo | MsgBoxStyle.Critical, "Elétron");
		if (msgBoxResult == MsgBoxResult.Yes)
		{
			msgBoxResult = Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1283], "\r\n"), DeclaracoesGeral.mMensagem[1, 1715]), MsgBoxStyle.YesNo | MsgBoxStyle.Critical, "Elétron");
			if (msgBoxResult == MsgBoxResult.Yes)
			{
				cDadosAtualizaBanco cDadosAtualizaBanco2 = new cDadosAtualizaBanco();
				cDadosAtualizaBanco2.ApagaPlaquetasExportada();
				cDadosAtualizaBanco2.fechaConexao();
			}
		}
	}

	[CommandMethod("RELPL")]
	public void fRELPL()
	{
		new frmRelatorio_Plaquetas();
	}

	[CommandMethod("RELEKTRO")]
	public void frRELEKTRO()
	{
		new frmRelatorio_Elektro();
	}

	[CommandMethod("GERRB")]
	public void GERRB()
	{
		new frmCriarReguas();
	}

	[CommandMethod("BORN")]
	public void BORN()
	{
		new frmBornes();
	}

	[CommandMethod("EDBORN")]
	public void EDBORN()
	{
		if (clsRegua.VerificaRegua())
		{
			new frmGerenciadorReguasBornes();
		}
	}

	[CommandMethod("LDNR")]
	public void LDNR()
	{
		clsBornes.OcultaAtributoNome();
	}

	[CommandMethod("OCPN")]
	public void OCPN()
	{
		clsBornes.OcultaAtributoPainel();
	}

	[CommandMethod("STATBORN")]
	public void STATBORN()
	{
		new frmEstatisticaDeBornes();
	}

	[CommandMethod("SELBORN")]
	public void SELBORN()
	{
		new frmEditaBornesSelecao();
	}

	[CommandMethod("MBOR")]
	public void MBOR()
	{
		new frmMigraBornes();
	}

	[CommandMethod("CLOBORN")]
	public void CLOBORN()
	{
		new frmClonarEstruturaRegua();
	}

	[CommandMethod("CIRC")]
	public void gerCirc()
	{
		new frmCircuito();
	}

	[CommandMethod("CON")]
	public void Con()
	{
		clsConexao clsConexao2 = new clsConexao();
		clsConexao2.CriarConexao();
	}

	[CommandMethod("JPEXT")]
	public void jpExt()
	{
		new frmJumper();
	}

	[CommandMethod("CONAUT")]
	public void ConAut()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected Obj, but got Unknown
		clsConexao clsConexao2 = new clsConexao();
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		PromptKeywordOptions val = new PromptKeywordOptions("");
		((PromptOptions)val).Message = Conversions.ToString(Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 619]));
		((PromptOptions)val).Keywords.Add("H");
		((PromptOptions)val).Keywords.Add("V");
		val.AllowNone = false;
		val.AllowArbitraryInput = false;
		((PromptOptions)val).Keywords.Default = "V";
		PromptResult keywords = editor.GetKeywords(val);
		if (Operators.CompareString(keywords.StringResult, "V", TextCompare: true) != 0)
		{
			if (Operators.CompareString(keywords.StringResult, "H", TextCompare: true) == 0)
			{
				clsConexao2.CriarConexaoAutomatica("H");
			}
		}
		else
		{
			clsConexao2.CriarConexaoAutomatica("V");
		}
	}

	[CommandMethod("DERAUT")]
	public void derAut()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected Obj, but got Unknown
		clsConexao clsConexao2 = new clsConexao();
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		PromptKeywordOptions val = new PromptKeywordOptions("");
		((PromptOptions)val).Message = Conversions.ToString(Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 619]));
		((PromptOptions)val).Keywords.Add("H");
		((PromptOptions)val).Keywords.Add("V");
		val.AllowNone = false;
		val.AllowArbitraryInput = false;
		((PromptOptions)val).Keywords.Default = "V";
		PromptResult keywords = editor.GetKeywords(val);
		if (Operators.CompareString(keywords.StringResult, "V", TextCompare: true) != 0)
		{
			if (Operators.CompareString(keywords.StringResult, "H", TextCompare: true) == 0)
			{
				clsConexao2.CriarDerivacaoAutomatica("H");
			}
		}
		else
		{
			clsConexao2.CriarDerivacaoAutomatica("V");
		}
	}

	[CommandMethod("EDTNCIRC")]
	public void EDTNCIRC()
	{
		new frmEditaNomeCircuitos();
	}

	[CommandMethod("INSM")]
	public void InsM()
	{
		new frmMarcador();
	}

	[CommandMethod("EDCON")]
	public void edCon()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected Obj, but got Unknown
		try
		{
			clsConexao clsConexao2 = new clsConexao();
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			PromptKeywordOptions val = new PromptKeywordOptions("");
			((PromptOptions)val).Message = Conversions.ToString(Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 715]));
			((PromptOptions)val).Keywords.Add("S");
			((PromptOptions)val).Keywords.Add("C");
			((PromptOptions)val).Keywords.Add("A");
			val.AllowNone = false;
			val.AllowArbitraryInput = false;
			((PromptOptions)val).Keywords.Default = "A";
			PromptResult keywords = editor.GetKeywords(val);
			if (Operators.CompareString(keywords.StringResult, "S", TextCompare: true) != 0)
			{
				if (Operators.CompareString(keywords.StringResult, "C", TextCompare: true) != 0)
				{
					if (Operators.CompareString(keywords.StringResult, "A", TextCompare: true) == 0)
					{
						clsConexao2.editarSecaoCor(3);
					}
				}
				else
				{
					clsConexao2.editarSecaoCor(2);
				}
			}
			else
			{
				clsConexao2.editarSecaoCor(1);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	[CommandMethod("APL")]
	public void Apl()
	{
		new frmAplicacao();
	}

	[CommandMethod("SYNCC")]
	public void syncCirc()
	{
		clsConexao.sincronizaCircuitos();
	}

	[CommandMethod("EDCONP")]
	public void edConP()
	{
		new frmEditaConexao();
	}

	[CommandMethod("VFIA")]
	public void VFIA()
	{
		new frmVerificadorProjetoFiacao();
	}

	[CommandMethod("LR")]
	public void LR()
	{
		new frmLayoutRapido();
	}

	[CommandMethod("FIA")]
	public void fFia()
	{
		new frmCompilarFiacao();
	}

	[CommandMethod("SEQ")]
	public void fSeq()
	{
		new frmSequenciador();
	}

	[CommandMethod("LNK")]
	public void fLNK()
	{
		new frmLink();
	}

	[CommandMethod("DELFIPROJ")]
	public void ApagaCompilacaoFiacao()
	{
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1713]), MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Elétron");
		if (msgBoxResult == MsgBoxResult.Yes)
		{
			msgBoxResult = Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1283], "\r\n"), DeclaracoesGeral.mMensagem[1, 1715]), MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Elétron");
			if (msgBoxResult == MsgBoxResult.Yes)
			{
				cDadosAtualizaBanco cDadosAtualizaBanco2 = new cDadosAtualizaBanco();
				cDadosAtualizaBanco2.ApagaTodaFiacao();
				cDadosAtualizaBanco2.fechaConexao();
			}
		}
	}

	[CommandMethod("RFIA")]
	public void frFia()
	{
		new frmRelatorio_Fiacao();
	}

	[CommandMethod("RTAF")]
	public void frTaf()
	{
		new frmRelatorio_TAF();
	}

	[CommandMethod("RBORELS")]
	public void frFBorELS()
	{
		new frmRelatorio_Fiacao_Compacta();
	}

	[CommandMethod("RPOT")]
	public void frPot()
	{
		new frmRelatorio_Potenciais();
	}

	[CommandMethod("RPOTS")]
	public void frPots()
	{
		new frmRelatorio_PotenciaisSiemens();
	}

	[CommandMethod("RDIF")]
	public void frDif()
	{
		new frmRelatorio_Diferencial();
	}

	[CommandMethod("DPOT")]
	public void DispPot()
	{
		new frmRelatorio_DistribuicaoPotencial();
	}

	[CommandMethod("RANI")]
	public void frRAni()
	{
		new frmRelatorio_Anilhas();
	}

	[CommandMethod("TPG")]
	public void frTopog()
	{
		new frmTopografico();
	}

	[CommandMethod("ATPG")]
	public void frTopogAnilha()
	{
		new frmTopograficoAnilha();
	}

	[CommandMethod("ESTF")]
	public void frEstF()
	{
		new frmRelatorio_EstatisticaFiacao();
	}

	[CommandMethod("VEIA1")]
	public void InsereVeia1()
	{
		clsInterligacao clsInterligacao2 = new clsInterligacao();
		clsInterligacao2.CriarInterligacao1();
	}

	[CommandMethod("VEIA")]
	public void InsereVeia()
	{
		clsInterligacao clsInterligacao2 = new clsInterligacao();
		clsInterligacao2.CriarInterligacao();
	}

	[CommandMethod("VEIA2")]
	public void InsereVeia2()
	{
		clsInterligacao clsInterligacao2 = new clsInterligacao();
		clsInterligacao2.CriarInterligacao2();
	}

	[CommandMethod("VEAUT")]
	public void InsereVeiaAutom()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected Obj, but got Unknown
		clsInterligacao clsInterligacao2 = new clsInterligacao();
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		PromptKeywordOptions val = new PromptKeywordOptions("");
		((PromptOptions)val).Message = Conversions.ToString(Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 619]));
		((PromptOptions)val).Keywords.Add("H");
		((PromptOptions)val).Keywords.Add("V");
		val.AllowNone = false;
		val.AllowArbitraryInput = false;
		((PromptOptions)val).Keywords.Default = "V";
		PromptResult keywords = editor.GetKeywords(val);
		if (Operators.CompareString(keywords.StringResult, "V", TextCompare: true) != 0)
		{
			if (Operators.CompareString(keywords.StringResult, "H", TextCompare: true) == 0)
			{
				clsInterligacao2.CriarVeiaAutomatica("H");
			}
		}
		else
		{
			clsInterligacao2.CriarVeiaAutomatica("V");
		}
	}

	[CommandMethod("BLI")]
	public void InsereBlindagem()
	{
		clsInterligacao clsInterligacao2 = new clsInterligacao();
		clsInterligacao2.CriarVeiaAterrada();
	}

	[CommandMethod("ATCABO")]
	public void ATCABO()
	{
		new frmatribuirVeias();
	}

	[CommandMethod("IVEIEX")]
	public void IVEIEX()
	{
		new FrmImportarCabosExcel();
	}

	[CommandMethod("EDCABO")]
	public void EDCABO()
	{
		new frmEditorCabos();
	}

	[CommandMethod("OCCAB")]
	public void OCCAB()
	{
		bdXTjkEID2 = !bdXTjkEID2;
		clsInterligacao.OcultaTodasAsVeiasDoDesnho(ref bdXTjkEID2);
	}

	[CommandMethod("LNOME")]
	public void LNOME()
	{
		bool bLiga = true;
		clsInterligacao.selecionaTextoDeVeias(ref bLiga);
	}

	[CommandMethod("DNOME")]
	public void DNOME()
	{
		bdXTjkEID2 = false;
		bool bLiga = false;
		clsInterligacao.selecionaTextoDeVeias(ref bLiga);
	}

	[CommandMethod("INDV")]
	public void INDV()
	{
		clsInterligacao.SelecionaEIndefineUmaVeia();
		clsUtilitarios.AtualizaTodosOpcionaisDoCabo();
	}

	[CommandMethod("PESQC")]
	public void PESQC()
	{
		new frmPesquisaVeiasIndefinidas();
	}

	[CommandMethod("SYNCV")]
	public void syncCabos()
	{
		DeclaracoesGeral._uscPagina.Quantidade = 9;
		DeclaracoesGeral._uscPagina.pbIniciar();
		DeclaracoesGeral._uscPagina.pbPasso();
		clsUtilitarios.CorrigeOsTextosDosCabos();
		DeclaracoesGeral._uscPagina.pbPasso();
		clsEditarInterligacao.InsereTextosDeCabos();
		DeclaracoesGeral._uscPagina.pbPasso();
		CDadosAccessInterligacao CDadosAccessInterligacao = new CDadosAccessInterligacao();
		clsEditarInterligacao.SincronizaVeiasDoCaderno(ref CDadosAccessInterligacao, bProgress: false);
		CDadosAccessInterligacao.FechaConexao();
		DeclaracoesGeral._uscPagina.pbPasso();
		clsEditarInterligacao.AtualizaNomesDosCabos();
		DeclaracoesGeral._uscPagina.pbPasso();
		clsInterligacao.SincronizaCruzamentoInterlig();
		DeclaracoesGeral._uscPagina.pbPasso();
		clsInterligacao.RecriaOCruzamentoInterligTipo2Apagados();
		DeclaracoesGeral._uscPagina.pbPasso();
		clsUtilitarios.AtualizaTodosOpcionaisDoCabo();
		DeclaracoesGeral._uscPagina.pbPasso();
		if (DeclaracoesGeral.Conf.ModeloBobina != 0)
		{
			if (DeclaracoesGeral.Conf.ModeloBobina != 1)
			{
				if (DeclaracoesGeral.Conf.ModeloBobina != 2)
				{
					if (DeclaracoesGeral.Conf.ModeloBobina == 3)
					{
						clsDispositivo.ModeloDoDispositivoPrincipalTipo3();
					}
				}
				else
				{
					clsDispositivo.ModeloDoDispositivoPrincipalTipo2();
				}
			}
			else
			{
				clsDispositivo.ModeloDoDispositivoPrincipalTipo1();
			}
		}
		else
		{
			clsDispositivo.ModeloDoDispositivoPrincipalTipo0();
		}
		Correcao.CorrigeCoresDosBlocos();
		DeclaracoesGeral._uscPagina.pbPasso();
		DeclaracoesGeral._uscPagina.pbFim();
	}

	[CommandMethod("VINT")]
	public void VINT()
	{
		new frmVerificadorProjetoInterligacao();
	}

	[CommandMethod("JMP")]
	public void jmp()
	{
		new frmCompilarJumperExt();
	}

	[CommandMethod("INT")]
	public void INT()
	{
		new frmCompilarInterligacao();
	}

	[CommandMethod("SEQJ")]
	public void seqj()
	{
		new frmSequenciadorJumper();
	}

	[CommandMethod("CLOCAB")]
	public void CLOCAB()
	{
		new frmClonarCabos();
	}

	[CommandMethod("PESQCAB")]
	public void PESQCAB()
	{
		new frmPesquisaCabos();
	}

	[CommandMethod("ESTVL")]
	public void ESTVL()
	{
		new frmEstimativaVeiasLivres();
	}

	[CommandMethod("ESTVCABOS")]
	public void ESTVCABOS()
	{
		new frmEstatisticaDeCabos();
	}

	[CommandMethod("EDNOMEFUNVEIAS")]
	public void EDFUNVEIAS()
	{
		new frmEditarNomesFuncoesVeias();
	}

	[CommandMethod("OPVEIAS")]
	public void OPVEIAS()
	{
		new frmDadosOpcionaisVeias();
	}

	[CommandMethod("RECRIACABOS")]
	public void layelsRecria()
	{
		int interligacaoLayout = DeclaracoesGeral.Conf.InterligacaoLayout;
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1738]), MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Elétron");
		if (msgBoxResult == MsgBoxResult.Yes)
		{
			switch (interligacaoLayout)
			{
			case 0:
			case 2:
			case 3:
				clsEletron.RecriaTextosCabo();
				break;
			case 1:
				clsEletrosul.RecriaTextosCaboEletrosul();
				break;
			}
		}
	}

	[CommandMethod("LAYELN")]
	public void LAYELN()
	{
		clsEletron.RecriaTextosCabo();
	}

	[CommandMethod("LAYELS")]
	public void LAYELSUL()
	{
		clsEletrosul.RecriaTextosCaboEletrosul();
	}

	[CommandMethod("INDEFCAB")]
	public void INDFCAB()
	{
		clsInterligacao.IndefineTodasAsVeiasDoDesnho();
	}

	[CommandMethod("IIEX")]
	public void IIEX()
	{
		new frmImportarInterligExcel();
	}

	[CommandMethod("DELINTPROJ")]
	public void ApagaCompilacaoInterligacao()
	{
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1714]), MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Elétron");
		if (msgBoxResult == MsgBoxResult.Yes)
		{
			msgBoxResult = Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1283], "\r\n"), DeclaracoesGeral.mMensagem[1, 1715]), MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Elétron");
			if (msgBoxResult == MsgBoxResult.Yes)
			{
				cDadosAtualizaBanco cDadosAtualizaBanco2 = new cDadosAtualizaBanco();
				cDadosAtualizaBanco2.ApagaTodaInterligacao();
				cDadosAtualizaBanco2.fechaConexao();
			}
		}
	}

	[CommandMethod("LCAB")]
	public void LCAB()
	{
		new frmRelatorio_Cabos();
	}

	[CommandMethod("LVEI")]
	public void LVEI()
	{
		new frmRelatorio_Veias();
	}

	[CommandMethod("LCABCOP")]
	public void LCABCOP()
	{
		new frmRelatorio_VeiasCopel();
	}

	[CommandMethod("RINT")]
	public void RINT()
	{
		new frmRelatorio_Interligacao();
	}

	[CommandMethod("RINTE")]
	public void RINTE()
	{
		new frmRelatorio_InterligacaoEletrosul();
	}

	[CommandMethod("DIELN")]
	public void DIELN()
	{
		new frmRelatorio_Aranha();
	}

	[CommandMethod("DICEMIGGTP")]
	public void DICEMIGTP()
	{
		new frmRelatorio_DInterlig(9);
	}

	[CommandMethod("DICEMIGGTE")]
	public void DICEMIGGTE()
	{
		new frmRelatorio_DICemig(1);
	}

	[CommandMethod("DICEMIGDP")]
	public void DICEMIGDP()
	{
		new frmRelatorio_DICemig(2);
	}

	[CommandMethod("DICEMIGDE")]
	public void DICEMIGDE()
	{
		new frmRelatorio_DICemig(3);
	}

	[CommandMethod("DICHESF")]
	public void DICHESF()
	{
		new frmRelatorio_DInterlig(1);
	}

	[CommandMethod("DICPFL")]
	public void DICPFL()
	{
		new frmRelatorio_DInterlig(2);
	}

	[CommandMethod("DICPFLTR")]
	public void DICPFLTR()
	{
		new frmRelatorio_DInterlig(5);
	}

	[CommandMethod("DIEDP")]
	public void DIEDP()
	{
		new frmRelatorio_DInterlig(6);
	}

	[CommandMethod("DIEQUAT")]
	public void DIEQUAT()
	{
		new frmRelatorio_DInterlig(4);
	}

	[CommandMethod("DIENER")]
	public void DIENER()
	{
		new frmRelatorio_DIEnergisaMS();
	}

	[CommandMethod("DIENERMT")]
	public void DIENERMT()
	{
		new frmRelatorio_DIEnergisaMT();
	}

	[CommandMethod("DIENERSSE")]
	public void DIENERSSE()
	{
		new frmRelatorio_DIEnergisaSSE();
	}

	[CommandMethod("DIENELSP")]
	public void DIENELSP()
	{
		new frmRelatorio_DInterlig(10);
	}

	[CommandMethod("DIFURNAS")]
	public void DIFURNAS()
	{
		new frmRelatorio_DInterlig(8);
	}

	[CommandMethod("DICTEEP")]
	public void DICTEEP()
	{
		new frmRelatorio_DInterlig(3);
	}

	[CommandMethod("DIITAIPU")]
	public void DIITAIPU()
	{
		new frmRelatorio_DInterlig(11);
	}

	[CommandMethod("DITAESA")]
	public void DITAESA()
	{
		new frmRelatorio_DInterlig(7);
	}

	[CommandMethod("LJUMP")]
	public void LJUMP()
	{
		new frmRelatorio_Jumpers();
	}

	[CommandMethod("LGIGA")]
	public void LGIGA()
	{
		new frmRelatorio_InterligacaoGIGA();
	}

	[CommandMethod("LANI")]
	public void LANI()
	{
		new frmRelatorio_AnilhasCabos();
	}

	[CommandMethod("GERLM")]
	public void GERLM()
	{
		new frmGerenciadorMateriais();
	}

	[CommandMethod("ATINDEP")]
	public void ATINDEP()
	{
		new frmGerenciadorMatIndep();
	}

	[CommandMethod("COMPLM")]
	public static void COMPLM()
	{
		cDadosAtualizaBanco cDadosAtualizaBanco2 = new cDadosAtualizaBanco();
		cDadosAtualizaBanco2.LimpaDWGApagadosDoProjeto();
		cDadosAtualizaBanco2.fechaConexao();
		clsLM.CompilaListaDeMateriais();
	}

	[CommandMethod("EXPLM")]
	public static void EXPLM()
	{
		new frmRelatorio_Materiais();
	}

	[CommandMethod("REVAUT")]
	public void REVAUT()
	{
		new frmRevisaoAutomatica();
	}

	[CommandMethod("EXPCOMP")]
	public void EXPCOMP()
	{
		new frmExportarImportar();
	}

	[CommandMethod("CLONAR")]
	public void fCLONAR()
	{
		new frmClonar();
	}

	[CommandMethod("EXPPDF")]
	public void fEXPPDF()
	{
		new frmPDF();
	}

	[CommandMethod("COPIAINT")]
	public void fCopiar()
	{
		new frmCopia();
	}

	[CommandMethod("CBD")]
	public static void CBD()
	{
		clsCompactador clsCompactador2 = new clsCompactador();
		clsCompactador2.CompactarBD();
	}

	[CommandMethod("RESTPROJ")]
	public void RESTPROJ()
	{
		DeclaracoesGeral._uscPagina.pbIniciar();
		DeclaracoesGeral._uscPagina.Quantidade = 16;
		clsUtilitarios.CorrigeOsTextosDosCabos();
		DeclaracoesGeral._uscPagina.pbPasso();
		string sTipo = "";
		clsBlocos.ApagaERROS(ref sTipo);
		DeclaracoesGeral._uscPagina.pbPasso();
		clsDispositivoAuxiliares.ApagaContatosOrfaos();
		DeclaracoesGeral._uscPagina.pbPasso();
		Correcao.CorrigeModelosDeContatos();
		DeclaracoesGeral._uscPagina.pbPasso();
		clsDispositivoAuxiliares.SincronizaContatos(0, bMarcaErros: false);
		DeclaracoesGeral._uscPagina.pbPasso();
		clsPortas.SincronizaPortas(bMarcaErros: false, bProgress: false);
		DeclaracoesGeral._uscPagina.pbPasso();
		clsDePara.SincronizaDePara(bUpdateProp: false);
		DeclaracoesGeral._uscPagina.pbPasso();
		clsUtilitarios.EditaPortaDipAuxPainelModeloFabricante(bProgress: false);
		DeclaracoesGeral._uscPagina.pbPasso();
		clsConexao.sincronizaCircuitos();
		DeclaracoesGeral._uscPagina.pbPasso();
		clsEditarInterligacao.InsereTextosDeCabos();
		DeclaracoesGeral._uscPagina.pbPasso();
		CDadosAccessInterligacao CDadosAccessInterligacao = new CDadosAccessInterligacao();
		clsEditarInterligacao.SincronizaVeiasDoCaderno(ref CDadosAccessInterligacao, bProgress: false);
		CDadosAccessInterligacao.FechaConexao();
		DeclaracoesGeral._uscPagina.pbPasso();
		clsInterligacao.SincronizaCruzamentoInterlig();
		DeclaracoesGeral._uscPagina.pbPasso();
		clsInterligacao.RecriaOCruzamentoInterligTipo2Apagados();
		DeclaracoesGeral._uscPagina.pbPasso();
		clsEditarInterligacao.AtualizaNomesDosCabos();
		DeclaracoesGeral._uscPagina.pbPasso();
		int interligacaoLayout = DeclaracoesGeral.Conf.InterligacaoLayout;
		if (interligacaoLayout == 3)
		{
			clsUtilitarios.AtualizaTodosOpcionaisDoCabo();
			DeclaracoesGeral._uscPagina.pbPasso();
		}
		if (DeclaracoesGeral.Conf.ModeloBobina != 0)
		{
			if (DeclaracoesGeral.Conf.ModeloBobina != 1)
			{
				if (DeclaracoesGeral.Conf.ModeloBobina != 2)
				{
					if (DeclaracoesGeral.Conf.ModeloBobina == 3)
					{
						clsDispositivo.ModeloDoDispositivoPrincipalTipo3();
					}
				}
				else
				{
					clsDispositivo.ModeloDoDispositivoPrincipalTipo2();
				}
			}
			else
			{
				clsDispositivo.ModeloDoDispositivoPrincipalTipo1();
			}
		}
		else
		{
			clsDispositivo.ModeloDoDispositivoPrincipalTipo0();
		}
		clsUtilitarios.CorrigePainelET1DosBornes();
		DeclaracoesGeral._uscPagina.pbPasso();
		clsCopia.AtualizaBlocosCopia();
		Correcao.CorrigeCoresDosBlocos();
		DeclaracoesGeral._uscPagina.pbPasso();
		DeclaracoesGeral._uscPagina.pbFim();
	}

	[CommandMethod("MOV")]
	public void MOV()
	{
		clsUtilitarios.moverElementos();
	}

	[CommandMethod("EXPDWG")]
	public static void cmdExport()
	{
		new frmExportarDWGs();
	}

	[CommandMethod("IMPR")]
	public static void cmdImprimir()
	{
		new frmImprimir();
	}

	[CommandMethod("TROCTT")]
	public void TROCTT()
	{
		new frmEditaTitulosTextos();
	}

	[CommandMethod("EXPIT")]
	public void EXPIT()
	{
		new frmExportarImportarTextos();
	}

	[CommandMethod("COPYCAD")]
	public void COPYCAD()
	{
		new frmCopiarObjetos();
	}

	[CommandMethod("TROCBL")]
	public void TROCBL()
	{
		new frmTrocaEditaBlocos();
	}

	[CommandMethod("APAGARXDATA")]
	public static void TiraXdata()
	{
		new frmPesquisaXdatas();
	}

	[CommandMethod("TROCAPN")]
	public void TROCAPN()
	{
		new frmTrocaPaineis(bAbre: false);
	}

	[CommandMethod("PESQUISA")]
	public static void PesquisaBlocos()
	{
		new frmNavegador();
	}

	[CommandMethod("MUDAUSER")]
	public void MudaUser()
	{
		new FrmTrocaUsuario();
	}

	[CommandMethod("IMPCAD")]
	public void IMPCAD()
	{
		new frmMisturador();
	}

	[CommandMethod("INFOON")]
	public void INFOON()
	{
		PointMonitorToolTips.StartMonitor();
	}

	[CommandMethod("INFOOFF")]
	public void INFOOFF()
	{
		PointMonitorToolTips.StopMonitor();
	}

	[CommandMethod("AJUDA")]
	public void Ajuda()
	{
		string fileName = "";
		if (Operators.CompareString(DeclaracoesGeral.ConfElet.Idioma, "[PT]", TextCompare: true) != 0)
		{
			if (Operators.CompareString(DeclaracoesGeral.ConfElet.Idioma, "[EN]", TextCompare: true) == 0)
			{
				fileName = "https://www.cadgraph.com.br/help/elet/25/pt/index.html";
			}
		}
		else
		{
			fileName = "https://www.cadgraph.com.br/help/elet/25/pt/index.html";
		}
		using Process process = new Process();
		process.StartInfo.FileName = fileName;
		process.StartInfo.UseShellExecute = true;
		process.Start();
	}

	[CommandMethod("PAS")]
	public void passo()
	{
		Pagina.redefinePasso();
	}

	[CommandMethod("HBASE")]
	public void hbase()
	{
		clsRegua.redefineAlturaBase();
	}

	[CommandMethod("PAG")]
	public static void GerenciadorPagina()
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected Obj, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected Obj, but got Unknown
		if (DeclaracoesGeral._pspag == null)
		{
			if (Operators.CompareString(DeclaracoesGeral.ConfElet.Idioma, "[PT]", TextCompare: true) != 0)
			{
				if (Operators.CompareString(DeclaracoesGeral.ConfElet.Idioma, "[EN]", TextCompare: true) == 0)
				{
					DeclaracoesGeral._pspag = new PaletteSet(Conversions.ToString(DeclaracoesGeral.mMensagem[1, 8]), "", new Guid("D17CCE76-F129-49A2-BFE6-6B9FCD7EC953"));
				}
			}
			else
			{
				DeclaracoesGeral._pspag = new PaletteSet(Conversions.ToString(DeclaracoesGeral.mMensagem[1, 8]), "", new Guid("D17CCE76-F129-49A2-BFE6-6B9FCD7EC954"));
			}
			DeclaracoesGeral._uscPagina = new uscPaginas();
			DeclaracoesGeral._pspag.Add("usc", (Control)DeclaracoesGeral._uscPagina);
			DeclaracoesGeral._pspag.DockEnabled = (DockSides)20480;
			DeclaracoesGeral._pspag.Dock = (DockSides)4096;
			DeclaracoesGeral._pspag.MinimumSize = new Size(100, 400);
		}
		DeclaracoesGeral._pspag.Visible = true;
		DeclaracoesGeral._pspag.KeepFocus = true;
		DeclaracoesGeral.ativo.Pagina = Pagina.LocalizaPaginaAtiva();
		DeclaracoesGeral._uscPagina.CarregaPG();
	}

	[CommandMethod("TCHAVE")]
	public void TCHAVE()
	{
		new frmTrocarChave();
	}

	[CommandMethod("TUSING")]
	public void TUSING()
	{
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)1);
				try
				{
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					try
					{
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val4.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val5 = (Entity)val2.GetObject(current, (OpenMode)1);
								try
								{
									Line val6 = (Line)(object)((val5 is Line) ? val5 : null);
									try
									{
										if (val6 != null)
										{
											Interaction.Beep();
										}
									}
									finally
									{
										((IDisposable)val6)?.Dispose();
									}
									DBText val7 = (DBText)(object)((val5 is DBText) ? val5 : null);
									if (val7 != null)
									{
										Interaction.Beep();
									}
									DBText val8 = (DBText)(object)((val5 is DBText) ? val5 : null);
									if (val8 != null)
									{
										_ = val8.TextString;
									}
									((DisposableWrapper)val5).Dispose();
								}
								finally
								{
									((IDisposable)val5)?.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					finally
					{
						((IDisposable)val4)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)val3)?.Dispose();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				val2.Abort();
				throw;
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}
}
