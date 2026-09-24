using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class XDataDispositivo
{
	public static string verificaTipoDispositivo(ref Entity ent, [Optional][DefaultParameterValue("")] ref string tipoImportado)
	{
		string result = "";
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("DISPOSITIVO");
		if (xDataForApplication == null)
		{
			ResultBuffer xDataForApplication2 = ((DBObject)ent).GetXDataForApplication("IMPORTADO");
			if (xDataForApplication2 != null)
			{
				TypedValue[] array = xDataForApplication2.AsArray();
				result = "I";
				tipoImportado = Conversions.ToString(array[3].Value);
				((DisposableWrapper)xDataForApplication2).Dispose();
			}
		}
		else
		{
			TypedValue[] array2 = xDataForApplication.AsArray();
			result = Conversions.ToString(array2[1].Value);
			((DisposableWrapper)xDataForApplication).Dispose();
		}
		return result;
	}

	public static short BuscaPainelDispositivo(ref Entity ent)
	{
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Expected Obj, but got Unknown
		short result = 0;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("DISPOSITIVO");
		if (xDataForApplication == null)
		{
			xDataForApplication = ((DBObject)ent).GetXDataForApplication("IMPORTADO");
			if (xDataForApplication != null)
			{
				TypedValue[] array = xDataForApplication.AsArray();
				result = Conversions.ToShort(array[9].Value);
			}
		}
		else
		{
			TypedValue[] array2 = xDataForApplication.AsArray();
			string text = array2[1].Value.ToString().ToUpper();
			string left = text;
			if (Operators.CompareString(left, "P", TextCompare: true) != 0 && Operators.CompareString(left, "M", TextCompare: true) != 0)
			{
				if (Operators.CompareString(left, "A", TextCompare: true) != 0 && Operators.CompareString(left, "E", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left, "B", TextCompare: true) == 0)
					{
						int iRegua = Conversions.ToInteger(array2[8].Value);
						string sRegua = "";
						string sAlternativo = "";
						result = checked((short)DicionarioBorne.BuscaPainelDoBorneNoDicionario(ref iRegua, ref sRegua, ref sAlternativo));
					}
				}
				else
				{
					string sHandle = array2[4].Value.ToString();
					Database database = Application.DocumentManager.MdiActiveDocument.Database;
					_ = Application.DocumentManager.MdiActiveDocument.Editor;
					Transaction val = database.TransactionManager.StartTransaction();
					try
					{
						ObjectId val2 = Geral.HandleToID(sHandle);
						if (val2.IsValid)
						{
							Entity val3 = (Entity)val.GetObject(val2, (OpenMode)0);
							try
							{
								ResultBuffer xDataForApplication2 = ((DBObject)val3).GetXDataForApplication("DISPOSITIVO");
								if (xDataForApplication2 != null)
								{
									TypedValue[] array3 = xDataForApplication2.AsArray();
									result = Conversions.ToShort(array3[8].Value);
								}
							}
							finally
							{
								((IDisposable)val3)?.Dispose();
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
			}
			else
			{
				result = Conversions.ToShort(array2[8].Value);
			}
		}
		return result;
	}

	public static bool xDataLeNomesDisp(Entity ent, ref string sTipo, ref string sNome1, ref string sNome2, ref int iPainel)
	{
		bool flag = false;
		ResultBuffer val = null;
		sTipo = "";
		sNome1 = "";
		sNome2 = "";
		bool result;
		try
		{
			val = ((DBObject)ent).GetXDataForApplication("Dispositivo");
			if (val != null)
			{
				TypedValue[] array = val.AsArray();
				sTipo = array[1].Value.ToString().ToUpper();
				string left = sTipo;
				if (Operators.CompareString(left, "P", TextCompare: true) != 0 && Operators.CompareString(left, "M", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left, "A", TextCompare: true) == 0 || Operators.CompareString(left, "E", TextCompare: true) == 0)
					{
						sNome1 = Conversions.ToString(NewLateBinding.LateGet(array[2].Value, null, "trim", new object[0], null, null, null));
						sNome2 = Conversions.ToString(NewLateBinding.LateGet(array[3].Value, null, "trim", new object[0], null, null, null));
						flag = true;
					}
				}
				else
				{
					sNome1 = Conversions.ToString(NewLateBinding.LateGet(array[2].Value, null, "trim", new object[0], null, null, null));
					sNome2 = Conversions.ToString(NewLateBinding.LateGet(array[3].Value, null, "trim", new object[0], null, null, null));
					iPainel = Conversions.ToInteger(array[8].Value);
					flag = true;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			sTipo = "";
			sNome1 = "";
			sNome2 = "";
			result = false;
			ProjectData.ClearProjectError();
			goto IL_0189;
		}
		result = flag;
		goto IL_0189;
		IL_0189:
		return result;
	}

	public static bool xDataPaineisOutroDWG(Database db, Entity ent, ref string sTipo, ref int Pn1, ref int Pn2, Declaracoes2.StructureModeloDeReguas[] mModeloDeReguas, ref List<int> lLM, [Optional][DefaultParameterValue(0)] ref int Potencial, bool bTopografico = false)
	{
		bool flag = false;
		Transaction topTransaction = db.TransactionManager.TopTransaction;
		bool result;
		try
		{
			ResultBuffer val = null;
			sTipo = "";
			Pn1 = 0;
			Pn2 = 0;
			try
			{
				val = ((DBObject)ent).GetXDataForApplication("Dispositivo");
				if (val != null)
				{
					TypedValue[] array = val.AsArray();
					sTipo = array[1].Value.ToString().ToUpper();
					string left = sTipo;
					if (Operators.CompareString(left, "P", TextCompare: true) != 0 && Operators.CompareString(left, "M", TextCompare: true) != 0)
					{
						if (Operators.CompareString(left, "B", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left, "A", TextCompare: true) != 0 && Operators.CompareString(left, "E", TextCompare: true) == 0)
							{
							}
						}
						else
						{
							if (!Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(array[10].Value)))
							{
								if (!lLM.Contains(0))
								{
									lLM.Add(0);
								}
							}
							else if (!lLM.Contains(Conversions.ToInteger(array[10].Value)))
							{
								lLM.Add(Conversions.ToInteger(array[10].Value));
							}
							int num = Information.UBound(mModeloDeReguas);
							for (int i = 1; i <= num; i = checked(i + 1))
							{
								if ((double)mModeloDeReguas[i].indexRegua == Conversions.ToDouble(array[8].Value.ToString().ToUpper()))
								{
									Pn1 = mModeloDeReguas[i].indexPainel;
									flag = true;
									break;
								}
							}
						}
					}
					else
					{
						Pn1 = Conversions.ToInteger(array[8].Value);
						if (!Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(array[21].Value)))
						{
							if (!lLM.Contains(0))
							{
								lLM.Add(0);
							}
						}
						else if (!lLM.Contains(Conversions.ToInteger(array[21].Value)))
						{
							lLM.Add(Conversions.ToInteger(array[21].Value));
						}
						if (!Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(array[23].Value)))
						{
							if (!lLM.Contains(0))
							{
								lLM.Add(0);
							}
						}
						else if (!lLM.Contains(Conversions.ToInteger(array[23].Value)))
						{
							lLM.Add(Conversions.ToInteger(array[23].Value));
						}
						flag = true;
					}
				}
				val = ((DBObject)ent).GetXDataForApplication("CONEXAO");
				if (val == null)
				{
					goto IL_0045;
				}
				TypedValue[] array2 = val.AsArray();
				sTipo = "C";
				string left2 = array2[1].Value.ToString();
				if (!((Operators.CompareString(left2, "1", TextCompare: true) == 0) | (Operators.CompareString(left2, "2", TextCompare: true) == 0) | (Operators.CompareString(left2, "3", TextCompare: true) == 0) | (Operators.CompareString(left2, "4", TextCompare: true) == 0)))
				{
					goto IL_0045;
				}
				Pn1 = Conversions.ToInteger(array2[4].Value);
				Potencial = Conversions.ToInteger(array2[2].Value);
				flag = true;
				goto end_IL_001e;
				IL_0045:
				if (bTopografico)
				{
					BlockReference blockRef = (BlockReference)(object)((ent is BlockReference) ? ent : null);
					if (blockRef != null)
					{
						DeclaracoesTopografico.structureDispTopografico dTpg = default;
						if (!XDataTopografico.lerXDataDispTopografico(ref blockRef, ref dTpg))
						{
							string tag = "";
							string alternativo = "";
							string Handle = "";
							if (XDataLayout.lerXDataDispLayout(ref blockRef, ref Pn1, ref tag, ref alternativo, ref Handle))
							{
								sTipo = "LAYD";
								flag = true;
							}
						}
						else
						{
							sTipo = "TPGD";
							Pn1 = dTpg.painel;
							flag = true;
						}
					}
				}
				end_IL_001e:;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				Pn1 = -1;
				Pn2 = -1;
				result = false;
				ProjectData.ClearProjectError();
				goto IL_03e9;
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)topTransaction)?.Dispose();
		}
		result = flag;
		goto IL_03e9;
		IL_03e9:
		return result;
	}

	public static bool xDataPaineis(Entity ent, ref string sTipo, ref int Pn1, ref int Pn2, [Optional][DefaultParameterValue(0)] ref int Potencial, bool bTopografico = false)
	{
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected Obj, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected Obj, but got Unknown
		bool flag = false;
		ResultBuffer val = null;
		sTipo = "";
		Pn1 = 0;
		Pn2 = 0;
		Entity ent2 = null;
		int num = 0;
		string text = "";
		bool result;
		try
		{
			val = ((DBObject)ent).GetXDataForApplication("Dispositivo");
			if (val != null)
			{
				TypedValue[] array = val.AsArray();
				sTipo = array[1].Value.ToString().ToUpper();
				string left = sTipo;
				if (Operators.CompareString(left, "P", TextCompare: true) != 0 && Operators.CompareString(left, "M", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left, "B", TextCompare: true) != 0)
					{
						if (Operators.CompareString(left, "A", TextCompare: true) == 0 || Operators.CompareString(left, "E", TextCompare: true) == 0)
						{
							text = array[4].Value.ToString();
							Database database = Application.DocumentManager.MdiActiveDocument.Database;
							_ = Application.DocumentManager.MdiActiveDocument.Editor;
							Transaction val2 = database.TransactionManager.StartTransaction();
							try
							{
								ObjectId val3 = Geral.HandleToID(text);
								if (val3.IsValid)
								{
									ent2 = (Entity)val2.GetObject(val3, (OpenMode)0);
									object oValor = Pn1;
									bool flag2 = lexDataRetornaValorDoIndiceInformado(ref ent2, "Dispositivo", 8, ref oValor);
									Pn1 = Conversions.ToInteger(oValor);
									if (flag2)
									{
										flag = true;
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
								ProjectData.ClearProjectError();
							}
							finally
							{
								((IDisposable)val2)?.Dispose();
							}
						}
					}
					else
					{
						num = Conversions.ToInteger(array[8].Value.ToString().ToUpper());
						string sRegua = "";
						string sAlternativo = "";
						Pn1 = DicionarioBorne.BuscaPainelDoBorneNoDicionario(ref num, ref sRegua, ref sAlternativo);
						flag = true;
					}
				}
				else
				{
					Pn1 = Conversions.ToInteger(array[8].Value);
					flag = true;
				}
			}
			val = ((DBObject)ent).GetXDataForApplication("MODELO");
			if (val != null)
			{
				TypedValue[] array2 = val.AsArray();
				sTipo = "D";
				text = array2[1].Value.ToString();
				Database database2 = Application.DocumentManager.MdiActiveDocument.Database;
				_ = Application.DocumentManager.MdiActiveDocument.Editor;
				Transaction val4 = database2.TransactionManager.StartTransaction();
				try
				{
					ObjectId val5 = Geral.HandleToID(text);
					if (val5.IsValid)
					{
						ent2 = (Entity)val4.GetObject(val5, (OpenMode)0);
						object oValor = Pn1;
						bool flag3 = lexDataRetornaValorDoIndiceInformado(ref ent2, "Dispositivo", 8, ref oValor);
						Pn1 = Conversions.ToInteger(oValor);
						if (flag3)
						{
							flag = true;
						}
					}
					DeclaracoesGeral.bAnularEventos = true;
					val4.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					val4.Abort();
					ProjectData.ClearProjectError();
				}
				finally
				{
					((IDisposable)val4)?.Dispose();
				}
			}
			val = ((DBObject)ent).GetXDataForApplication("CONEXAO");
			if (val != null)
			{
				TypedValue[] array3 = val.AsArray();
				sTipo = "C";
				string left2 = array3[1].Value.ToString();
				if ((Operators.CompareString(left2, "1", TextCompare: true) == 0) | (Operators.CompareString(left2, "2", TextCompare: true) == 0) | (Operators.CompareString(left2, "3", TextCompare: true) == 0) | (Operators.CompareString(left2, "4", TextCompare: true) == 0))
				{
					Pn1 = Conversions.ToInteger(array3[4].Value);
					Potencial = Conversions.ToInteger(array3[2].Value);
					flag = true;
				}
			}
			if (bTopografico)
			{
				BlockReference blockRef = (BlockReference)(object)((ent is BlockReference) ? ent : null);
				if (blockRef != null)
				{
					DeclaracoesTopografico.structureDispTopografico dTpg = default;
					if (XDataTopografico.lerXDataDispTopografico(ref blockRef, ref dTpg))
					{
						sTipo = "TPGD";
						Pn1 = dTpg.painel;
						flag = true;
					}
					string tag = "";
					string alternativo = "";
					string sAlternativo = "";
					if (XDataLayout.lerXDataDispLayout(ref blockRef, ref Pn1, ref tag, ref alternativo, ref sAlternativo))
					{
						sTipo = "LAYD";
						flag = true;
					}
				}
			}
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			Pn1 = -1;
			Pn2 = -1;
			result = false;
			ProjectData.ClearProjectError();
			goto IL_041d;
		}
		if (!Information.IsNothing(ent2))
		{
			((DisposableWrapper)ent2).Dispose();
		}
		result = flag;
		goto IL_041d;
		IL_041d:
		return result;
	}

	public static bool lexDataRetornaValorDoIndiceInformado(ref Entity ent, string sNomexData, int iIndicexData, ref object oValor)
	{
		bool result = false;
		ResultBuffer val = null;
		val = ((DBObject)ent).GetXDataForApplication(sNomexData);
		if (val != null)
		{
			TypedValue[] array = val.AsArray();
			oValor = RuntimeHelpers.GetObjectValue(array[iIndicexData].Value);
			result = true;
		}
		return result;
	}

	public static void GravarXDataDePara(ref DBText text, string handle, short tipo)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			RegAppTable val = (RegAppTable)topTransaction.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val).Has("DEPARA"))
			{
				RegAppTableRecord val2 = new RegAppTableRecord();
				((SymbolTableRecord)val2).Name = "DEPARA";
				((SymbolTable)val).Add((SymbolTableRecord)(object)val2);
				DeclaracoesGeral.bAnularEventos = true;
				topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val2, true);
			}
			TypedValue[] array = new TypedValue[4]
			{
				new TypedValue(1001, (object)"DEPARA"),
				new TypedValue(1070, (object)tipo),
				new TypedValue(1000, (object)handle),
				new TypedValue(1070, (object)1)
			};
			((DBObject)text).XData = new ResultBuffer(array);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
			((IDisposable)topTransaction)?.Dispose();
		}
	}

	public static bool lerXDataDePara(ref DBText text, ref string handle, ref short tipo)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)text).GetXDataForApplication("DEPARA");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			tipo = Conversions.ToShort(array[1].Value);
			handle = Conversions.ToString(array[2].Value);
			result = true;
		}
		return result;
	}
}
