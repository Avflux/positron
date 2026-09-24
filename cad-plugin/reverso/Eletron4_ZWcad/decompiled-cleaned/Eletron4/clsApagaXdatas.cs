using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

public class clsApagaXdatas
{
	public struct StructureXDATA
	{
		public string sXdata;

		public int Quant;
	}

	public static void BuscaxDatasNaoEletron(ref StructureXDATA[] mXdata)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					int num = -1;
					mXdata = new StructureXDATA[0];
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
							try
							{
								if (!(((DBObject)val5).XData != (ResultBuffer)null))
								{
									continue;
								}
								Entity ent = val5;
								string text = LeTodosOsXdatasDoCaderno(ref ent).ToUpper();
								bool flag = false;
								int num2 = Information.UBound(mXdata);
								for (int i = 0; i <= num2; i++)
								{
									if (Operators.CompareString(mXdata[i].sXdata, text, TextCompare: true) == 0)
									{
										mXdata[i].Quant++;
										flag = true;
										break;
									}
								}
								if (!flag)
								{
									num++;
									mXdata = (StructureXDATA[])Utils.CopyArray(mXdata, new StructureXDATA[num + 1]);
									mXdata[num].sXdata = text;
									mXdata[num].Quant = 1;
								}
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
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
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
	}

	public static int ApagaxDatasSelecionados(List<string> lApagar)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected Obj, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected Obj, but got Unknown
		int num = 0;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
							try
							{
								int num2 = lApagar.Count - 1;
								for (int i = 0; i <= num2; i++)
								{
									Entity ent = val5;
									if (XDataGeral.TemXData(ref ent, lApagar[i]))
									{
										TypedValue[] array = new TypedValue[1]
										{
											new TypedValue(1001, (object)lApagar[i])
										};
										((DBObject)val5).UpgradeOpen();
										((DBObject)val5).XData = new ResultBuffer(array);
										num++;
									}
								}
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
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					throw;
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
				return num;
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static string LeTodosOsXdatasDoCaderno(ref Entity ent)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					_ = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
					if (((DBObject)ent).XData != (ResultBuffer)null)
					{
						string text = ((DBObject)ent).XData.ToString().ToUpper();
						string[] array = text.Split(')');
						int num = Information.UBound(array);
						for (int i = 0; i <= num; i++)
						{
							array[i] = array[i].Replace("(", "");
							array[i] = array[i].Replace(")", "");
						}
						string[] array2 = null;
						int num2 = Information.UBound(array);
						for (int j = 0; j <= num2; j++)
						{
							array2 = array[j].Split(',');
							if (Operators.CompareString(array2[0].ToString(), "1001", TextCompare: true) == 0)
							{
								string text2 = array2[1];
								result = text2;
							}
						}
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
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
			return result;
		}
	}
}
