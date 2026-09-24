using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

public class clsLyneTypes
{
	public static void BuscaLyneTypes(ref LyneTypes.structureEstiloInterligacao[] mEstilo)
	{
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0407: Unknown result type (might be due to invalid IL or missing references)
		//IL_040e: Expected Obj, but got Unknown
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_0422: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Expected Obj, but got Unknown
		//IL_0436: Unknown result type (might be due to invalid IL or missing references)
		//IL_043b: Unknown result type (might be due to invalid IL or missing references)
		//IL_043f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Unknown result type (might be due to invalid IL or missing references)
		//IL_044e: Expected Obj, but got Unknown
		//IL_0531: Unknown result type (might be due to invalid IL or missing references)
		//IL_053c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0543: Expected Obj, but got Unknown
		//IL_054c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0557: Unknown result type (might be due to invalid IL or missing references)
		//IL_0561: Unknown result type (might be due to invalid IL or missing references)
		//IL_056e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0575: Expected Obj, but got Unknown
		//IL_0585: Unknown result type (might be due to invalid IL or missing references)
		//IL_058a: Unknown result type (might be due to invalid IL or missing references)
		//IL_058e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0598: Unknown result type (might be due to invalid IL or missing references)
		//IL_059f: Expected Obj, but got Unknown
		int num = 0;
		mEstilo = (LyneTypes.structureEstiloInterligacao[])Utils.CopyArray(mEstilo, new LyneTypes.structureEstiloInterligacao[1]);
		mEstilo[0].Linetype = "Continuous";
		mEstilo[0].LinetypeScale = 1.0;
		num = 1;
		mEstilo = (LyneTypes.structureEstiloInterligacao[])Utils.CopyArray(mEstilo, new LyneTypes.structureEstiloInterligacao[2]);
		mEstilo[1].Linetype = "CENTER";
		mEstilo[1].LinetypeScale = 1.0;
		num = 2;
		mEstilo = (LyneTypes.structureEstiloInterligacao[])Utils.CopyArray(mEstilo, new LyneTypes.structureEstiloInterligacao[3]);
		mEstilo[2].Linetype = "CENTER2";
		mEstilo[2].LinetypeScale = 1.0;
		num = 3;
		mEstilo = (LyneTypes.structureEstiloInterligacao[])Utils.CopyArray(mEstilo, new LyneTypes.structureEstiloInterligacao[4]);
		mEstilo[3].Linetype = "CENTERX2";
		mEstilo[3].LinetypeScale = 1.0;
		num = 4;
		mEstilo = (LyneTypes.structureEstiloInterligacao[])Utils.CopyArray(mEstilo, new LyneTypes.structureEstiloInterligacao[5]);
		mEstilo[4].Linetype = "DASHED";
		mEstilo[4].LinetypeScale = 1.0;
		num = 5;
		mEstilo = (LyneTypes.structureEstiloInterligacao[])Utils.CopyArray(mEstilo, new LyneTypes.structureEstiloInterligacao[6]);
		mEstilo[5].Linetype = "DASHED2";
		mEstilo[5].LinetypeScale = 1.0;
		num = 6;
		mEstilo = (LyneTypes.structureEstiloInterligacao[])Utils.CopyArray(mEstilo, new LyneTypes.structureEstiloInterligacao[7]);
		mEstilo[6].Linetype = "DASHEDX2";
		mEstilo[6].LinetypeScale = 1.0;
		num = 7;
		mEstilo = (LyneTypes.structureEstiloInterligacao[])Utils.CopyArray(mEstilo, new LyneTypes.structureEstiloInterligacao[8]);
		mEstilo[7].Linetype = "DOT";
		mEstilo[7].LinetypeScale = 1.0;
		num = 8;
		mEstilo = (LyneTypes.structureEstiloInterligacao[])Utils.CopyArray(mEstilo, new LyneTypes.structureEstiloInterligacao[9]);
		mEstilo[8].Linetype = "DOT2";
		mEstilo[8].LinetypeScale = 1.0;
		num = 9;
		mEstilo = (LyneTypes.structureEstiloInterligacao[])Utils.CopyArray(mEstilo, new LyneTypes.structureEstiloInterligacao[10]);
		mEstilo[9].Linetype = "DOTX2";
		mEstilo[9].LinetypeScale = 1.0;
		num = 10;
		mEstilo = (LyneTypes.structureEstiloInterligacao[])Utils.CopyArray(mEstilo, new LyneTypes.structureEstiloInterligacao[11]);
		mEstilo[10].Linetype = "HIDDEN";
		mEstilo[10].LinetypeScale = 1.0;
		num = 11;
		mEstilo = (LyneTypes.structureEstiloInterligacao[])Utils.CopyArray(mEstilo, new LyneTypes.structureEstiloInterligacao[12]);
		mEstilo[11].Linetype = "HIDDEN2";
		mEstilo[11].LinetypeScale = 1.0;
		num = 12;
		mEstilo = (LyneTypes.structureEstiloInterligacao[])Utils.CopyArray(mEstilo, new LyneTypes.structureEstiloInterligacao[13]);
		mEstilo[12].Linetype = "HIDDENX2";
		mEstilo[12].LinetypeScale = 1.0;
		List<string> list = new List<string>();
		list.Add("Continuous");
		list.Add("CENTER");
		list.Add("CENTER2");
		list.Add("CENTERX2");
		list.Add("DASHED");
		list.Add("DASHED2");
		list.Add("DASHEDX2");
		list.Add("DOT");
		list.Add("DOT2");
		list.Add("DOTX2");
		list.Add("HIDDEN");
		list.Add("HIDDEN2");
		list.Add("HIDDENX2");
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
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
							Polyline val6 = (Polyline)(object)((val5 is Polyline) ? val5 : null);
							if (val6 == null)
							{
								continue;
							}
							string linetype = ((Entity)val6).Linetype;
							int num2 = Information.UBound(mEstilo);
							for (int i = 0; i <= num2; i++)
							{
								if (Operators.CompareString(mEstilo[i].Linetype, linetype, TextCompare: true) == 0)
								{
									mEstilo[i].LinetypeScale = ((Entity)val6).LinetypeScale;
									break;
								}
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
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			try
			{
				DocumentLock val7 = Application.DocumentManager.MdiActiveDocument.LockDocument();
				try
				{
					Database database2 = Application.DocumentManager.MdiActiveDocument.Database;
					Transaction val8 = database2.TransactionManager.StartTransaction();
					try
					{
						BlockTable val9 = (BlockTable)val8.GetObject(database2.BlockTableId, (OpenMode)0);
						_ = (BlockTableRecord)val8.GetObject(((SymbolTable)val9)[BlockTableRecord.ModelSpace], (OpenMode)0);
						LinetypeTable val10 = (LinetypeTable)val8.GetObject(database2.LinetypeTableId, (OpenMode)0, false, true);
						SymbolTableEnumerator enumerator2 = default;
						try
						{
							enumerator2 = ((SymbolTable)val10).GetEnumerator();
							while (enumerator2.MoveNext())
							{
								ObjectId current2 = enumerator2.Current;
								LinetypeTableRecord val11 = (LinetypeTableRecord)val8.GetObject(current2, (OpenMode)0, false, false);
								string name = ((SymbolTableRecord)val11).Name;
								if (!((Operators.CompareString(name.ToUpper(), "BYLAYER", TextCompare: true) == 0) | (Operators.CompareString(name.ToUpper(), "BYBLOCK", TextCompare: true) == 0) | name.Contains("$") | name.Contains("&") | (val11.NumDashes == 0) | name.Contains("XREF")) && !list.Contains(name))
								{
									num++;
									mEstilo = (LyneTypes.structureEstiloInterligacao[])Utils.CopyArray(mEstilo, new LyneTypes.structureEstiloInterligacao[num + 1]);
									mEstilo[num].LinetypeScale = val11.NumDashes;
									mEstilo[num].Linetype = name;
									list.Add(name);
								}
							}
						}
						finally
						{
							((IDisposable)enumerator2)?.Dispose();
						}
						DeclaracoesGeral.bAnularEventos = true;
						val8.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					finally
					{
						((IDisposable)val8)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)val7)?.Dispose();
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
			if (Information.UBound(mEstilo) < 2)
			{
				return;
			}
			int num3 = Information.UBound(mEstilo) - 1;
			for (int j = num3; j >= 1; j += -1)
			{
				int num4 = j;
				for (int k = 1; k <= num4; k++)
				{
					if (Operators.CompareString(mEstilo[k].Linetype, mEstilo[k + 1].Linetype, TextCompare: true) > 0)
					{
						LyneTypes.structureEstiloInterligacao structureEstiloInterligacao = default;
						structureEstiloInterligacao = mEstilo[k + 1];
						mEstilo[k + 1] = mEstilo[k];
						mEstilo[k] = structureEstiloInterligacao;
					}
				}
			}
		}
	}
}
