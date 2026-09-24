using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.Windows;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;

namespace Eletron4;

public class Iniciar
{
	private static EventosDB eMBpn50TGKV;

	public static void IniciarApp()
	{
		frmSplash frmSplash2 = new frmSplash();
		Application.DoEvents();
		Thread.Sleep(2000);
		try
		{
			Geral.IniciaStringCollectionAtt();
			Geral.IniciaStringCollectionBitolas();
			Ribbon ribbon = new Ribbon();
			ribbon.CreateRibbon();
			ribbon.CreateRibbon2();
			DeclaracoesGeral.lDwgRegen.Clear();
			string text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Cadgraph\\Eletron4\\";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			BinaryWriter binaryWriter = new BinaryWriter(File.Create(text + "MascaraM.dwg"));
			binaryWriter.Write(Resources.MascaraM);
			binaryWriter.Close();
			BinaryWriter binaryWriter2 = new BinaryWriter(File.Create(text + "ErroFiacao.dwg"));
			binaryWriter2.Write(Resources.ErroFiacao);
			binaryWriter2.Close();
			BinaryWriter binaryWriter3 = new BinaryWriter(File.Create(text + "V_B_BORNECPFL.dwg"));
			binaryWriter3.Write(Resources.V_B_BORNECPFL);
			binaryWriter3.Close();
			PointMonitorToolTips.StopMonitor();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 55], " "), "Elétron"), MsgBoxStyle.Information, "Elétron");
			ProjectData.ClearProjectError();
		}
		finally
		{
			frmSplash2.Close();
		}
	}

	public static void IniciarDWG()
	{
		checked
		{
			try
			{
				if (!Information.IsNothing(Application.DocumentManager.MdiActiveDocument))
				{
					DeclaracoesGeral.ativo.Tipo = XDataGeral.verificaTipoXData();
					RibbonControl ribbon = ComponentManager.Ribbon;
					int count = ((Collection<RibbonPanel>)(object)((Collection<RibbonTab>)(object)ribbon.Tabs)[DeclaracoesGeral.indexRibbon].Panels).Count;
					string tipo = DeclaracoesGeral.ativo.Tipo;
					if (Operators.CompareString(tipo, "E", TextCompare: true) != 0)
					{
						if (Operators.CompareString(tipo, "V", TextCompare: true) != 0)
						{
							if (Operators.CompareString(tipo, "D", TextCompare: true) == 0 || Operators.CompareString(tipo, "A", TextCompare: true) == 0)
							{
								int num = count - 1;
								for (int i = 0; i <= num; i++)
								{
									((Collection<RibbonPanel>)(object)((Collection<RibbonTab>)(object)ribbon.Tabs)[DeclaracoesGeral.indexRibbon].Panels)[i].IsEnabled = false;
								}
							}
						}
						else
						{
							XDataGeral.LerXDataConfiguracao();
							XDataGeral.LerXDataConfiguracao2();
							((Collection<RibbonPanel>)(object)((Collection<RibbonTab>)(object)ribbon.Tabs)[DeclaracoesGeral.indexRibbon].Panels)[0].IsEnabled = true;
							((Collection<RibbonPanel>)(object)((Collection<RibbonTab>)(object)ribbon.Tabs)[DeclaracoesGeral.indexRibbon].Panels)[1].IsEnabled = true;
							int num2 = count - 2;
							for (int j = 2; j <= num2; j++)
							{
								((Collection<RibbonPanel>)(object)((Collection<RibbonTab>)(object)ribbon.Tabs)[DeclaracoesGeral.indexRibbon].Panels)[j].IsEnabled = false;
							}
						}
					}
					else
					{
						XDataGeral.LerXDataConfiguracao();
						XDataGeral.LerXDataConfiguracao2();
						XDataGeral.LerXDataConfiguracaoListaDePontos();
						int num3 = count - 1;
						for (int k = 0; k <= num3; k++)
						{
							((Collection<RibbonPanel>)(object)((Collection<RibbonTab>)(object)ribbon.Tabs)[DeclaracoesGeral.indexRibbon].Panels)[k].IsEnabled = true;
						}
					}
					Pagina.CarregaPaginas();
					Pagina.OrdenaMatrizPaginas();
					if (Information.UBound(DeclaracoesGeral.mPaginas, 2) <= 0)
					{
						Comandos.GerenciadorPagina();
					}
					else
					{
						DeclaracoesGeral.ativo.Pagina = Pagina.LocalizaPaginaAtiva();
						Pagina.AtivaPagina(DeclaracoesGeral.ativo.Pagina);
						DeclaracoesGeral.ativo.Painel = 0;
						Dicionario.LeAtalhos();
						Caderno.ExisteFormato();
						Comandos.GerenciadorPagina();
					}
					Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
					if (!DeclaracoesGeral.lDwgRegen.Contains(mdiActiveDocument.Name))
					{
						DeclaracoesGeral.lDwgRegen.Add(mdiActiveDocument.Name);
						Geral.travaDWG(bTravar: false);
						Geral.CriaTextStyle("Romans", "romans.shx");
						if (!XDataCorrecao.LerCorrecao(1))
						{
							Correcao.CorrecaoDisp();
							XDataCorrecao.setaCorrecao(1);
						}
						if (!XDataCorrecao.LerCorrecao(2))
						{
							Correcao.CorrecaoBornesVisiveis();
							XDataCorrecao.setaCorrecao(2);
						}
						if (!XDataCorrecao.LerCorrecao(3))
						{
							Correcao.correcaoTextosCircuitos();
							XDataCorrecao.setaCorrecao(3);
						}
						if (!XDataCorrecao.LerCorrecao(4))
						{
							Correcao.correcaoLines();
							XDataCorrecao.setaCorrecao(4);
						}
						if (!XDataCorrecao.LerCorrecao(5))
						{
							Correcao.corrigeOrdemBornes();
							XDataCorrecao.setaCorrecao(5);
						}
						Application.DocumentManager.MdiActiveDocument.Editor.Regen();
						if (!clsAuxiliar.BancoValido(bMsg: false))
						{
							if (Operators.CompareString(DeclaracoesGeral.ativo.Tipo, "E", TextCompare: true) == 0)
							{
								new frmConfiguracaoBDProjeto();
							}
						}
						else
						{
							ACorrecaoBD.CorrigeBD();
						}
					}
					DeclaracoesGeral.dicDWG = new Dictionary<int, string>();
					if (clsAuxiliar.BancoValido(bMsg: false))
					{
						cDadosAccess.carregaDWGDicionario();
						cDadosAccess.carregaPainelDicionario();
						PointMonitorToolTips.StopMonitor();
						PointMonitorToolTips.StartMonitor();
					}
					eMBpn50TGKV = new EventosDB();
					DeclaracoesGeral.monitorConexao = 0;
					DeclaracoesGeral._uscPagina.statusBanco(DeclaracoesGeral.monitorConexao.ToString());
				}
				else
				{
					DeclaracoesGeral._pspag.Visible = false;
					DeclaracoesGeral._pspag.KeepFocus = false;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information, "Elétron");
				ProjectData.ClearProjectError();
			}
		}
	}
}
