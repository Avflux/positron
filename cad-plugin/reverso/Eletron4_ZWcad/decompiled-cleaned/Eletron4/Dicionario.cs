using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

public class Dicionario
{
	public static void CarregaPaineis(ref ComboBox Combo)
	{
		try
		{
			Combo.Items.Clear();
			if (!Information.IsNothing(DeclaracoesGeral.dicPainel))
			{
				if (DeclaracoesGeral.dicPainel.Count == 0)
				{
					cDadosAccess.carregaPainelDicionario();
				}
			}
			else
			{
				cDadosAccess.carregaPainelDicionario();
			}
			foreach (KeyValuePair<int, string> item in DeclaracoesGeral.dicPainel)
			{
				if (item.Key == DeclaracoesGeral.ativo.Painel)
				{
					Combo.Text = item.Value;
				}
				Combo.Items.Add(item.Value);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			Combo.Items.Clear();
			ProjectData.ClearProjectError();
		}
	}

	public static string BuscaNomeDoPainel(int iPainel)
	{
		string text = "???";
		try
		{
			if (!Information.IsNothing(DeclaracoesGeral.dicPainel))
			{
				if (DeclaracoesGeral.dicPainel.Count == 0)
				{
					cDadosAccess.carregaPainelDicionario();
				}
			}
			else
			{
				cDadosAccess.carregaPainelDicionario();
			}
			text = (DeclaracoesGeral.dicPainel.ContainsKey(iPainel) ? DeclaracoesGeral.dicPainel[iPainel] : "???");
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			text = "???";
			ProjectData.ClearProjectError();
		}
		return text;
	}

	public static int BuscaIndiceDoPainel(string sPainel)
	{
		int result = 0;
		if (!Information.IsNothing(DeclaracoesGeral.dicPainel))
		{
			if (DeclaracoesGeral.dicPainel.Count == 0)
			{
				cDadosAccess.carregaPainelDicionario();
			}
		}
		else
		{
			cDadosAccess.carregaPainelDicionario();
		}
		foreach (KeyValuePair<int, string> item in DeclaracoesGeral.dicPainel)
		{
			if (Operators.CompareString(item.Value, sPainel, TextCompare: true) == 0)
			{
				result = item.Key;
				break;
			}
		}
		return result;
	}

	public static void gravaAtalhos()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected Obj, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected Obj, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected Obj, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected Obj, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				DBDictionary val3 = (DBDictionary)val2.GetObject(database.NamedObjectsDictionaryId, (OpenMode)1, false);
				DBDictionary val4;
				if (!val3.Contains("CENG_ELET"))
				{
					val4 = new DBDictionary();
					val3.SetAt("CENG_ELET", (DBObject)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				else
				{
					val4 = (DBDictionary)val2.GetObject(val3.GetAt("CENG_ELET"), (OpenMode)1);
				}
				Xrecord val5;
				if (!val4.Contains("Atalhos"))
				{
					TypedValue[] array = new TypedValue[1];
					ResultBuffer data = new ResultBuffer(array);
					val5 = new Xrecord();
					val5.Data = data;
					val4.SetAt("Atalhos", (DBObject)(object)val5);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val5, true);
				}
				else
				{
					ObjectId at = val4.GetAt("Atalhos");
					val5 = (Xrecord)val2.GetObject(at, (OpenMode)1);
				}
				ResultBuffer data2 = new ResultBuffer(new TypedValue[6]
				{
					new TypedValue(1, (object)DeclaracoesGeral.atalhosPag.atalho1),
					new TypedValue(1, (object)DeclaracoesGeral.atalhosPag.atalho2),
					new TypedValue(1, (object)DeclaracoesGeral.atalhosPag.atalho3),
					new TypedValue(1, (object)DeclaracoesGeral.atalhosPag.atalho4),
					new TypedValue(1, (object)DeclaracoesGeral.atalhosPag.atalho5),
					new TypedValue(1, (object)DeclaracoesGeral.atalhosPag.atalho6)
				});
				val5.Data = data2;
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
	}

	public static void LeAtalhos()
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected Obj, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected Obj, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected Obj, but got Unknown
		DeclaracoesGeral.atalhosPag.atalho1 = "";
		DeclaracoesGeral.atalhosPag.atalho2 = "";
		DeclaracoesGeral.atalhosPag.atalho3 = "";
		DeclaracoesGeral.atalhosPag.atalho4 = "";
		DeclaracoesGeral.atalhosPag.atalho5 = "";
		DeclaracoesGeral.atalhosPag.atalho6 = "";
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			DBDictionary val2 = (DBDictionary)val.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
			if (val2.Contains("CENG_ELET"))
			{
				DBDictionary val3 = (DBDictionary)val.GetObject(val2.GetAt("CENG_ELET"), (OpenMode)0);
				if (val3.Contains("Atalhos"))
				{
					ObjectId at = val3.GetAt("Atalhos");
					Xrecord val4 = (Xrecord)val.GetObject(at, (OpenMode)0);
					ResultBuffer data = val4.Data;
					TypedValue[] array = data.AsArray();
					DeclaracoesGeral.atalhosPag.atalho1 = Conversions.ToString(array[0].Value);
					DeclaracoesGeral.atalhosPag.atalho2 = Conversions.ToString(array[1].Value);
					DeclaracoesGeral.atalhosPag.atalho3 = Conversions.ToString(array[2].Value);
					DeclaracoesGeral.atalhosPag.atalho4 = Conversions.ToString(array[3].Value);
					DeclaracoesGeral.atalhosPag.atalho5 = Conversions.ToString(array[4].Value);
					DeclaracoesGeral.atalhosPag.atalho6 = Conversions.ToString(array[5].Value);
					DeclaracoesGeral.bAnularEventos = true;
					val.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			val.Abort();
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void CriaTableStyleRelatorios(string sFonte, double MargemVertical = 1.5, double MargemHorizontal = 2.0)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected Obj, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				DBObject val3 = val2.GetObject(database.TableStyleDictionaryId, (OpenMode)0);
				DBDictionary val4 = (DBDictionary)(object)((val3 is DBDictionary) ? val3 : null);
				string text = "RELATORIOS";
				ObjectId val5 = ObjectId.Null;
				TableStyle val7;
				if (val4.Contains(text))
				{
					val5 = val4.GetAt(text);
					DBObject val6 = val2.GetObject(val5, (OpenMode)1);
					val7 = (TableStyle)(object)((val6 is TableStyle) ? val6 : null);
					((DBObject)val7).Erase();
				}
				val7 = new TableStyle();
				((DBObject)val4).UpgradeOpen();
				val5 = val4.SetAt(text, (DBObject)(object)val7);
				DeclaracoesGeral.bAnularEventos = true;
				val2.AddNewlyCreatedDBObject((DBObject)(object)val7, true);
				((DBObject)val4).DowngradeOpen();
				val7.VerticalCellMargin = MargemVertical;
				val7.HorizontalCellMargin = MargemHorizontal;
				val7.IsTitleSuppressed = false;
				TextStyleTable val8 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
				try
				{
					ObjectId val9 = ((SymbolTable)val8)[sFonte];
					val7.SetTextStyle(val9, 4);
					val7.SetTextStyle(val9, 2);
					val7.SetTextStyle(val9, 1);
					database.Tablestyle = val4.GetAt(val7.Name);
				}
				finally
				{
					((IDisposable)val8)?.Dispose();
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
	}

	public static object CapturaOsTextStyle()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		_ = Application.DocumentManager.MdiActiveDocument;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		string[] array;
		try
		{
			array = new string[1] { "" };
			DBObject val2 = val.GetObject(database.TextStyleTableId, (OpenMode)0);
			TextStyleTable val3 = (TextStyleTable)(object)((val2 is TextStyleTable) ? val2 : null);
			SymbolTableEnumerator enumerator = default;
			try
			{
				enumerator = ((SymbolTable)val3).GetEnumerator();
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					DBObject val4 = val.GetObject(current, (OpenMode)1);
					TextStyleTableRecord val5 = (TextStyleTableRecord)(object)((val4 is TextStyleTableRecord) ? val4 : null);
					_ = ((SymbolTableRecord)val5).Name;
					if (Operators.CompareString(((SymbolTableRecord)val5).Name.Trim(), "", TextCompare: true) != 0)
					{
						array = (string[])Utils.CopyArray(array, new string[checked(Information.UBound(array) + 1 + 1)]);
						array[Information.UBound(array)] = ((SymbolTableRecord)val5).Name;
					}
				}
			}
			finally
			{
				((IDisposable)enumerator)?.Dispose();
			}
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return array;
	}
}
