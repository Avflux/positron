using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.Internal;
using ZwSoft.ZwCAD.Runtime;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[StandardModule]
public sealed class clsCloud
{
	private static string PUZpqLZfal;

	private static bool gsQpaOYguD;

	private static double Mxap8PfxDc;

	private static int sC3pN9quQL;

	public static void add(string sRev, bool bRevSimp, double radius, int iCorSel)
	{
		PUZpqLZfal = sRev;
		gsQpaOYguD = bRevSimp;
		Mxap8PfxDc = radius;
		sC3pN9quQL = iCorSel;
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		mdiActiveDocument.SendStringToExecute("CriaJigCloud\n", true, false, true);
	}

	[CommandMethod("CriaJigCloud")]
	public static void CriaRevisionJigCloud()
	{
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Expected Obj, but got Unknown
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Expected Obj, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected Obj, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Invalid comparison between Unknown and I4
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected Obj, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected Obj, but got Unknown
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Expected I4, but got Unknown
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected Obj, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Invalid comparison between Unknown and I4
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Expected Obj, but got Unknown
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Invalid comparison between Unknown and I4
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
					int num = 0;
					num = clsBlocos.AcadObjectCount();
					object[,] mMensagem;
					object[] array = new object[1] { (mMensagem = DeclaracoesGeral.mMensagem)[1, 1683] };
					object[] array2 = array;
					object obj = NewLateBinding.LateGet(editor, null, "GetPoint", array, null, null, new bool[1] { true });
					mMensagem[1, 1683] = RuntimeHelpers.GetObjectValue(array2[0]);
					PromptPointResult val5 = (PromptPointResult)obj;
					if ((int)((PromptResult)val5).Status == 5100)
					{
						Point3d value = val5.Value;
						Polyline val6 = new Polyline();
						((Entity)val6).SetDatabaseDefaults();
						((Entity)val6).ColorIndex = sC3pN9quQL;
						val6.AddVertexAt(0, new Point2d(value.X, value.Y), 0.0, 0.0, 0.0);
						val6.AddVertexAt(1, new Point2d(value.X, value.Y), 0.0, 0.0, 0.0);
						while (true)
						{
							Entity ent = (Entity)(object)val6;
							JigCloud jigCloud = new JigCloud(ref ent);
							val6 = (Polyline)ent;
							JigCloud jigCloud2 = jigCloud;
							hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
							PromptResult val7 = editor.Drag((Jig)(object)jigCloud2);
							Point2d val8 = default;
							PromptStatus status = val7.Status;
							switch (status - -5005)
							{
							case 4:
								((DisposableWrapper)val6).Dispose();
								break;
							default:
								if ((int)status != 5000 && (int)status == 5100)
								{
									goto IL_0317;
								}
								goto case 0;
							case 0:
							case 1:
							case 2:
							{
								val4.AppendEntity((Entity)(object)val6);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
								editor.Command(new object[7]
								{
									"_REVCLOUD",
									"_ARC",
									Mxap8PfxDc,
									Mxap8PfxDc,
									"_OBJECT",
									((DBObject)val6).ObjectId,
									"_NO"
								});
								int num2 = 0;
								num2 = clsBlocos.AcadObjectCount();
								if (num2 != checked(num + 1))
								{
									break;
								}
								ObjectId val9 = Utils.EntLast();
								Entity val10 = (Entity)val9.GetObject((OpenMode)0);
								val6 = (Polyline)(object)((val10 is Polyline) ? val10 : null);
								if (val6 != null)
								{
									((DBObject)val6).UpgradeOpen();
									((Entity)val6).Linetype = "Continuous";
									((Entity)val6).ColorIndex = sC3pN9quQL;
									ent = (Entity)(object)val6;
									XDataGeral.gravarXDataRevisaoAutomatica(ref ent, PUZpqLZfal, sC3pN9quQL);
									val6 = (Polyline)ent;
									val6.Closed = true;
									if (gsQpaOYguD)
									{
										Pagina.AtualizaRevSimplificada(DeclaracoesGeral.ativo.Pagina, PUZpqLZfal);
									}
								}
								break;
							}
							case 3:
								if (val6.NumberOfVertices == 1)
								{
									((DisposableWrapper)val6).Dispose();
									break;
								}
								goto case 0;
							}
							break;
							IL_0317:
							checked
							{
								val8 = val6.GetPoint2dAt(val6.NumberOfVertices - 1);
								val6.AddVertexAt(val6.NumberOfVertices - 1, val8, 0.0, 0.0, 0.0);
							}
						}
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError((Exception)ex);
					val2.Abort();
					ProjectData.ClearProjectError();
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
		catch (Exception ex2)
		{
			ProjectData.SetProjectError((Exception)ex2);
			ProjectData.ClearProjectError();
		}
		Form form = Application.OpenForms["frmRevisaoAutomatica"];
		if (!Information.IsNothing(form))
		{
			frmRevisaoAutomatica frmRevisaoAutomatica2 = (frmRevisaoAutomatica)form;
			frmRevisaoAutomatica2.AtualizaRevisao();
		}
	}

	private static string jSrpInMWyM(ObjectId P_0)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string text = $"(setq ss (handent \"{((object)P_0.Handle/*cast due to constrained. prefix*/).ToString()}\"))";
		return text + "\r\n";
	}

	private static string NpLp7si3Qq()
	{
		string text = string.Format("(command \"{0}\" \"{1}\" ss \"{2}\")", "REVCLOUD", "E", "N");
		return text + "\r\n";
	}

	public static bool SelecionaUmaCloud(string sRevClound, bool bEditaRevSimpPag, int iCor)
	{
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected Obj, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected Obj, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected Obj, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected Obj, but got Unknown
		bool result = false;
		DeclaracoesGeral.bAnularEventos = true;
		try
		{
			cDadosAccess.carregaDadosDWG();
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					PromptSelectionOptions val3 = new PromptSelectionOptions();
					val3.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1710]);
					PromptSelectionResult selection = editor.GetSelection(val3);
					SelectionSet value = selection.Value;
					if (!Information.IsNothing(value))
					{
						ObjectIdCollection val4 = new ObjectIdCollection(value.GetObjectIds());
						foreach (object item in val4)
						{
							ObjectId val5 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							Entity val6 = (Entity)val5.GetObject((OpenMode)0);
							Polyline val7 = (Polyline)(object)((val6 is Polyline) ? val6 : null);
							if (val7 != null)
							{
								bool flag = false;
								if (Information.IsNothing(((DBObject)val7).XData))
								{
									flag = true;
								}
								else if (!LinhaDoEletron(((DBObject)val7).XData.ToString()))
								{
									flag = true;
								}
								if (flag)
								{
									((DBObject)val7).UpgradeOpen();
									((Entity)val7).ColorIndex = iCor;
									Entity ent = (Entity)(object)val7;
									XDataGeral.gravarXDataRevisaoAutomatica(ref ent, sRevClound, iCor);
									val7 = (Polyline)ent;
									result = true;
								}
							}
						}
					}
					val2.Commit();
					if (bEditaRevSimpPag)
					{
						Pagina.AtualizaRevSimplificada(DeclaracoesGeral.ativo.Pagina, sRevClound);
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
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			result = false;
			ProjectData.ClearProjectError();
		}
		DeclaracoesGeral.bAnularEventos = false;
		return result;
	}

	public static bool LinhaDoEletron(string sHandle)
	{
		bool result = false;
		List<string> list = new List<string> { "INTERLIGACAO", "CONEXAO", "LinhaTextoLP" };
		sHandle = sHandle.Replace("0", "");
		sHandle = sHandle.Replace("0", "");
		int num = 0;
		do
		{
			sHandle = sHandle.Replace(num.ToString(), "");
			num = checked(num + 1);
		}
		while (num <= 9);
		sHandle = sHandle.Replace("(,)", "");
		sHandle = sHandle.Replace("(,,)", "");
		sHandle = sHandle.Replace("(,-)", "");
		sHandle = sHandle.Replace("/", "");
		sHandle = sHandle.Replace(":", "");
		sHandle = sHandle.Replace(";", "");
		sHandle = sHandle.Replace(" ", "");
		sHandle = sHandle.Replace("(,", "(");
		sHandle = sHandle.Replace("(", "");
		sHandle = sHandle.Replace(")", "|");
		string[] array = sHandle.Split('|');
		if (list.Contains(array[0].ToString()))
		{
			result = true;
		}
		return result;
	}
}
