using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.PlottingServices;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class ImprimirPG
{
	public static void ImprimirPaginaCorrente()
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected Obj, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected Obj, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected Obj, but got Unknown
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Invalid comparison between Unknown and I4
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected Obj, but got Unknown
		object objectValue = RuntimeHelpers.GetObjectValue(Application.GetSystemVariable("BackGroundPlot"));
		Application.SetSystemVariable("BackGroundPlot", (object)0);
		DeclaracoesGeral.bAnularEventos = true;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				try
				{
					string nomeDWG = "";
					string caminho = "";
					Geral.extraiNomeCaminhoDwg(mdiActiveDocument.Name, ref nomeDWG, ref caminho);
					LayoutManager current = LayoutManager.Current;
					Layout val3 = (Layout)val2.GetObject(current.GetLayoutId(current.CurrentLayout), (OpenMode)0);
					PlotInfo val4 = new PlotInfo();
					try
					{
						val4.Layout = ((DBObject)val3).ObjectId;
						PlotSettings val5 = new PlotSettings(((PlotSettings)val3).ModelType);
						try
						{
							((RXObject)val5).CopyFrom((RXObject)(object)val3);
							PlotSettingsValidator current2 = PlotSettingsValidator.Current;
							current2.RefreshLists(val5);
							current2.SetPlotType(val5, val5.PlotType);
							current2.SetUseStandardScale(val5, true);
							current2.SetStdScaleType(val5, (StdScaleType)0);
							current2.SetCurrentStyleSheet(val5, val5.CurrentStyleSheet);
							current2.SetPlotCentered(val5, true);
							current2.SetPlotConfigurationName(val5, val5.PlotConfigurationName, ((PlotSettings)val3).CanonicalMediaName);
							val4.OverrideSettings = val5;
							PlotInfoValidator val6 = new PlotInfoValidator();
							val6.MediaMatchingPolicy = (MatchingPolicy)2;
							val6.Validate(val4);
							if ((int)PlotFactory.ProcessPlotState == 0)
							{
								PlotEngine val7 = PlotFactory.CreatePublishEngine();
								try
								{
									val7.BeginPlot((PlotProgress)null, (object)null);
									val7.BeginDocument(val4, mdiActiveDocument.Name, (object)null, 1, false, mdiActiveDocument.Name);
									PlotPageInfo val8 = new PlotPageInfo();
									try
									{
										val7.BeginPage(val8, val4, true, (object)null);
									}
									finally
									{
										((IDisposable)val8)?.Dispose();
									}
									val7.BeginGenerateGraphics((object)null);
									val7.EndGenerateGraphics((object)null);
									val7.EndPage((object)null);
									val7.EndDocument((object)null);
									val7.EndPlot((object)null);
								}
								finally
								{
									((IDisposable)val7)?.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)val5)?.Dispose();
						}
					}
					finally
					{
						((IDisposable)val4)?.Dispose();
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					val2.Abort();
					ProjectData.ClearProjectError();
				}
				finally
				{
					DeclaracoesGeral.bAnularEventos = false;
					Application.SetSystemVariable("BackGroundPlot", RuntimeHelpers.GetObjectValue(objectValue));
				}
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
