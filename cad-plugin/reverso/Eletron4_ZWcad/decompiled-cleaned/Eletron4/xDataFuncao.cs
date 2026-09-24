using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

public class xDataFuncao
{
	public static void GravarXDataFuncao(ref BlockReference bl, ref string[] mFuncao)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected Obj, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				string userName = Environment.UserName;
				string text = DateTime.Now.ToString();
				try
				{
					RegAppTable val2 = (RegAppTable)val.GetObject(database.RegAppTableId, (OpenMode)1);
					if (!((SymbolTable)val2).Has("DISP_FUNCAO"))
					{
						RegAppTableRecord val3 = new RegAppTableRecord();
						((SymbolTableRecord)val3).Name = "DISP_FUNCAO";
						((SymbolTable)val2).Add((SymbolTableRecord)(object)val3);
						DeclaracoesGeral.bAnularEventos = true;
						val.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
					}
					int num = Information.UBound(mFuncao) + 2;
					TypedValue[] array = new TypedValue[num + 1];
					array[0] = new TypedValue(1001, (object)"DISP_FUNCAO");
					int num2 = 0;
					string[] array2 = mFuncao;
					foreach (string text2 in array2)
					{
						num2++;
						array[num2] = new TypedValue(1000, (object)clsTextos.TiraNothing(text2.Trim()));
					}
					array[num - 1] = new TypedValue(1000, (object)userName);
					array[num] = new TypedValue(1000, (object)text);
					((DBObject)bl).UpgradeOpen();
					((DBObject)bl).XData = new ResultBuffer(array);
					DeclaracoesGeral.bAnularEventos = true;
					val.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					throw;
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static bool lerXDataFuncao(ref BlockReference Bl, ref string[] mFuncao)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)Bl).GetXDataForApplication("DISP_FUNCAO");
		checked
		{
			if (xDataForApplication != null)
			{
				TypedValue[] array = xDataForApplication.AsArray();
				int num = Information.UBound(array);
				for (int i = 0; i <= num; i++)
				{
					mFuncao = (string[])Utils.CopyArray(mFuncao, new string[i + 1]);
					mFuncao[i] = Conversions.ToString(array[i].Value);
				}
				result = true;
			}
			return result;
		}
	}
}
