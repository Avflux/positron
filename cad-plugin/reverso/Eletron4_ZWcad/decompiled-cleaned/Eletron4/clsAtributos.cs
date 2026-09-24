using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

public class clsAtributos
{
	public object[,] sHandle;

	public static void ligaNomedeDispositivos()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.bAnularEventos = true;
		PointMonitorToolTips.StopMonitor();
		object[,] array = null;
		string Tipo = "";
		ObjectId val = selecionaUmBloco(ref Tipo);
		if (!val.IsNull)
		{
			di4pRqcoSw(ref val, ref array, Tipo);
		}
		PointMonitorToolTips.StartMonitor();
		DeclaracoesGeral.bAnularEventos = false;
	}

	public static void LeTodosOsAtributosDeUmBloco(ref ObjectId ObjectId, ref string[,] sAtt)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockReference val3 = (BlockReference)val2.GetObject(ObjectId, (OpenMode)0);
					_ = (BlockTableRecord)val2.GetObject(val3.BlockTableRecord, (OpenMode)0);
					AttributeCollection attributeCollection = val3.AttributeCollection;
					foreach (object item in attributeCollection)
					{
						ObjectId val4 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						AttributeReference val5 = (AttributeReference)val4.GetObject((OpenMode)1);
						int num = Information.UBound(sAtt, 2) + 1;
						sAtt = (string[,])Utils.CopyArray(sAtt, new string[2, num + 1]);
						sAtt[0, num] = val5.Tag;
						sAtt[1, num] = ((DBText)val5).TextString;
						((Entity)val5).Draw();
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
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static string LeTodosOsBornesOuTerminaisDeUmBloco(ref ObjectId ObjectId, ref string sRegua)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected Obj, but got Unknown
		string text = "";
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockReference val3 = (BlockReference)val2.GetObject(ObjectId, (OpenMode)0);
					_ = (BlockTableRecord)val2.GetObject(val3.BlockTableRecord, (OpenMode)0);
					AttributeCollection attributeCollection = val3.AttributeCollection;
					string[] array = new string[1];
					string[] array2 = new string[1];
					foreach (object item in attributeCollection)
					{
						ObjectId val4 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						AttributeReference val5 = (AttributeReference)val4.GetObject((OpenMode)1);
						int num = 0;
						if (Operators.CompareString(val5.Tag, "R1", TextCompare: true) != 0)
						{
							if (Versioned.IsNumeric(Strings.Mid(val5.Tag, 2, Strings.Len(val5.Tag) - 1)))
							{
								num = Conversions.ToInteger(Strings.Mid(val5.Tag, 2, Strings.Len(val5.Tag) - 1));
							}
							if (!((Operators.CompareString(Strings.Mid(val5.Tag, 1, 1), "B", TextCompare: true) == 0) & (num > 0)))
							{
								if ((Operators.CompareString(Strings.Mid(val5.Tag, 1, 1), "T", TextCompare: true) == 0) & (num > 0))
								{
									if (Information.UBound(array) >= num)
									{
										array[num] = ((DBText)val5).TextString;
										continue;
									}
									array = (string[])Utils.CopyArray(array, new string[num + 1]);
									array[num] = ((DBText)val5).TextString;
								}
							}
							else if (Information.UBound(array2) >= num)
							{
								array2[num] = ((DBText)val5).TextString;
							}
							else
							{
								array2 = (string[])Utils.CopyArray(array2, new string[num + 1]);
								array2[num] = ((DBText)val5).TextString;
							}
						}
						else
						{
							sRegua = ((DBText)val5).TextString;
						}
					}
					if (Information.UBound(array2) > 0)
					{
						string[] array3 = array2;
						foreach (string text2 in array3)
						{
							if (Operators.CompareString(text2, "", TextCompare: true) != 0)
							{
								text = ((Operators.CompareString(text, "", TextCompare: true) == 0) ? (text + text2) : (text + "; " + text2));
							}
						}
					}
					if (Operators.CompareString(text, "", TextCompare: true) == 0 && Information.UBound(array) > 0)
					{
						string[] array4 = array;
						foreach (string text3 in array4)
						{
							if (Operators.CompareString(text3, "", TextCompare: true) != 0)
							{
								text = ((Operators.CompareString(text, "", TextCompare: true) == 0) ? (text + text3) : (text + "; " + text3));
							}
						}
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
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			return text;
		}
	}

	public static string LeEFCdaPortaDeUmBloco(ref ObjectId ObjectId)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected Obj, but got Unknown
		string result = "";
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockReference val3 = (BlockReference)val2.GetObject(ObjectId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(val3.BlockTableRecord, (OpenMode)0);
				AttributeCollection attributeCollection = val3.AttributeCollection;
				foreach (object item in attributeCollection)
				{
					ObjectId val4 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
					AttributeReference val5 = (AttributeReference)val4.GetObject((OpenMode)1);
					if (Operators.CompareString(val5.Tag.ToUpper(), "EFC", TextCompare: true) == 0)
					{
						result = ((DBText)val5).TextString;
						break;
					}
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
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return result;
	}

	private static void di4pRqcoSw(ref ObjectId P_0, ref object[,] P_1, string P_2)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		object obj = null;
		nIlpmAkKnK(ref P_0, ref P_1, P_2);
		if (!SelecionaTextoDoBlocos(ref P_0, P_2))
		{
			return;
		}
		bool flag = false;
		do
		{
			object obj2 = obj;
			Point3d ptInsert = ((obj2 == null) ? default(Point3d) : ((Point3d)obj2));
			selPonto(ref ptInsert, "ATT");
			obj = ptInsert;
			if (flag = znTpU2LcJu(ref obj, ref P_1, ref P_0, P_2))
			{
				MudaCorTextodoBlocos(ref P_0, ref P_1, P_2);
			}
		}
		while (flag);
		OcultaTextosHandle(P_0, ref P_1);
	}

	private static void nIlpmAkKnK(ref ObjectId P_0, ref object[,] P_1, string P_2)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected Obj, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0606: Unknown result type (might be due to invalid IL or missing references)
		//IL_060b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected Obj, but got Unknown
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		P_1 = new object[7, 1];
		P_1[0, 0] = "Nome";
		P_1[1, 0] = "Visivel | Invisivel";
		P_1[2, 0] = "BoundingBox Min";
		P_1[3, 0] = "BoundingBox Max";
		P_1[4, 0] = "Cor";
		P_1[5, 0] = "Handle do atributo";
		P_1[6, 0] = "EDITÁVEL=TRUE / NÃO EDITÁVEL=FALSE";
		Point3d val = default;
		Point3d val2 = default;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		DocumentLock val3 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Transaction val4 = database.TransactionManager.StartTransaction();
				try
				{
					BlockReference val5 = (BlockReference)val4.GetObject(P_0, (OpenMode)0);
					_ = (BlockTableRecord)val4.GetObject(val5.BlockTableRecord, (OpenMode)0);
					AttributeCollection attributeCollection = val5.AttributeCollection;
					int num = 0;
					foreach (object item in attributeCollection)
					{
						ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
						bool flag = true;
						if (Information.IsNothing(((Drawable)val7).Bounds))
						{
							flag = false;
						}
						else
						{
							Extents3d value = ((Drawable)val7).Bounds.Value;
							val = value.MinPoint;
							value = ((Drawable)val7).Bounds.Value;
							val2 = value.MaxPoint;
						}
						num++;
						if (!flag)
						{
							continue;
						}
						P_1 = (object[,])Utils.CopyArray(P_1, new object[7, Information.UBound(P_1, 2) + 1 + 1]);
						P_1[0, Information.UBound(P_1, 2)] = val7.Tag;
						P_1[1, Information.UBound(P_1, 2)] = ((Entity)val7).Visible;
						P_1[2, Information.UBound(P_1, 2)] = val;
						P_1[3, Information.UBound(P_1, 2)] = val2;
						P_1[4, Information.UBound(P_1, 2)] = ((Entity)val7).ColorIndex;
						P_1[5, Information.UBound(P_1, 2)] = ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString();
						bool flag2 = true;
						if (Operators.CompareString(P_2, "A", TextCompare: true) != 0)
						{
							if (Operators.CompareString(P_2, "P", TextCompare: true) != 0)
							{
								if (Operators.CompareString(P_2, "E", TextCompare: true) != 0)
								{
									if (Operators.CompareString(P_2, "M", TextCompare: true) != 0)
									{
										if (Operators.CompareString(P_2, "B", TextCompare: true) == 0)
										{
											flag2 = !((Operators.CompareString(Strings.Mid(val7.Tag, 1, 1), "T", TextCompare: true) == 0) & Versioned.IsNumeric(Strings.Mid(val7.Tag, 2, Strings.Len(val7.Tag) - 1)));
										}
										else if (Operators.CompareString(P_2, "I", TextCompare: true) != 0)
										{
											if (Operators.CompareString(P_2, "L", TextCompare: true) == 0)
											{
												flag2 = true;
											}
										}
										else
										{
											flag2 = true;
										}
									}
									else
									{
										string tag = val7.Tag;
										flag2 = Operators.CompareString(tag, "NOME1", TextCompare: true) != 0 && Operators.CompareString(tag, "NOME2", TextCompare: true) != 0 && (Operators.CompareString(tag, "ALTERNATIVO", TextCompare: true) == 0 || true);
									}
								}
								else
								{
									if ((Operators.CompareString(Strings.Mid(val7.Tag, 1, 1), "B", TextCompare: true) == 0) & Versioned.IsNumeric(Strings.Mid(val7.Tag, 2, Strings.Len(val7.Tag) - 1)))
									{
										flag2 = false;
									}
									if ((Operators.CompareString(Strings.Mid(val7.Tag, 1, 1), "R", TextCompare: true) == 0) & Versioned.IsNumeric(Strings.Mid(val7.Tag, 2, Strings.Len(val7.Tag) - 1)))
									{
										flag2 = true;
									}
									string tag2 = val7.Tag;
									flag2 = Operators.CompareString(tag2, "NOME1", TextCompare: true) == 0 || Operators.CompareString(tag2, "NOME2", TextCompare: true) == 0 || Operators.CompareString(tag2, "ALTERNATIVO", TextCompare: true) == 0 || Operators.CompareString(tag2, "EFC", TextCompare: true) != 0;
								}
							}
							else
							{
								if ((Operators.CompareString(Strings.Mid(val7.Tag, 1, 1), "T", TextCompare: true) == 0) & Versioned.IsNumeric(Strings.Mid(val7.Tag, 2, Strings.Len(val7.Tag) - 1)))
								{
									flag2 = false;
								}
								string tag3 = val7.Tag;
								flag2 = Operators.CompareString(tag3, "NOME1", TextCompare: true) != 0 && Operators.CompareString(tag3, "NOME2", TextCompare: true) != 0 && (Operators.CompareString(tag3, "ALTERNATIVO", TextCompare: true) == 0 || true);
							}
						}
						else
						{
							if ((Operators.CompareString(Strings.Mid(val7.Tag, 1, 1), "T", TextCompare: true) == 0) & Versioned.IsNumeric(Strings.Mid(val7.Tag, 2, Strings.Len(val7.Tag) - 1)))
							{
								flag2 = false;
							}
							string tag4 = val7.Tag;
							flag2 = Operators.CompareString(tag4, "NOME1", TextCompare: true) != 0 && Operators.CompareString(tag4, "NOME2", TextCompare: true) != 0 && (Operators.CompareString(tag4, "ALTERNATIVO", TextCompare: true) == 0 || true);
						}
						P_1[6, Information.UBound(P_1, 2)] = flag2;
					}
					DeclaracoesGeral.bAnularEventos = true;
					val4.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					P_0 = ((DBObject)val5).ObjectId;
				}
				finally
				{
					((IDisposable)val4)?.Dispose();
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val3)?.Dispose();
			}
		}
	}

	public static void Pincel()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.bAnularEventos = true;
		PointMonitorToolTips.StopMonitor();
		string Tipo = "";
		object[,] array = null;
		ObjectId val = selecionaUmBloco(ref Tipo);
		w6IpXkSa5E(ref val, ref array);
		PointMonitorToolTips.StartMonitor();
		DeclaracoesGeral.bAnularEventos = false;
	}

	private static void w6IpXkSa5E(ref ObjectId P_0, ref object[,] P_1)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		mAtt[] array = null;
		string sTipo = "";
		object[] ObjIDSSelect = null;
		if (SelecionaModeloPincel(ref P_0, ref sTipo, ref array))
		{
			SelecionaOsObjetosPincel(ref ObjIDSSelect, sTipo);
			int num = Information.UBound(ObjIDSSelect);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				object[] array2;
				int num2;
				object obj = (array2 = ObjIDSSelect)[num2 = i];
				ObjectId ObjectId = ((obj == null) ? default(ObjectId) : ((ObjectId)obj));
				EditaBlocosPincel(ref ObjectId, ref array);
				array2[num2] = ObjectId;
			}
		}
	}

	public static bool SelecionaTextoDoBlocos(ref ObjectId ObjectId, string sTipo)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected Obj, but got Unknown
		bool result = false;
		if (!ObjectId.IsNull)
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockReference val3 = (BlockReference)val2.GetObject(ObjectId, (OpenMode)0);
					_ = (Entity)val2.GetObject(ObjectId, (OpenMode)0);
					_ = (BlockTableRecord)val2.GetObject(val3.BlockTableRecord, (OpenMode)0);
					AttributeCollection attributeCollection = val3.AttributeCollection;
					foreach (object item in attributeCollection)
					{
						ObjectId val4 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						AttributeReference val5 = (AttributeReference)val4.GetObject((OpenMode)1);
						if (Operators.CompareString(((DBText)val5).TextString, "", TextCompare: true) == 0)
						{
							((DBText)val5).TextString = " ";
						}
						if (((Entity)val5).Visible)
						{
							if (!((((Operators.CompareString(Strings.Mid(val5.Tag, 1, 1), "T", TextCompare: true) == 0) | (Operators.CompareString(Strings.Mid(val5.Tag, 1, 1), "B", TextCompare: true) == 0)) & Versioned.IsNumeric(Strings.Mid(val5.Tag, 2, checked(Strings.Len(val5.Tag) - 1)))) | (Operators.CompareString(val5.Tag, "EFC", TextCompare: true) == 0)))
							{
								if (!(((Operators.CompareString(val5.Tag, "NOME1", TextCompare: true) == 0) & (Operators.CompareString(sTipo, "M", TextCompare: true) == 0)) | ((Operators.CompareString(sTipo, "E", TextCompare: true) == 0) & (Operators.CompareString(Strings.Mid(val5.Tag, 1, 1), "R", TextCompare: true) == 0))))
								{
									((Entity)val5).ColorIndex = 3;
								}
								else
								{
									((Entity)val5).ColorIndex = 251;
								}
							}
							else
							{
								((Entity)val5).ColorIndex = 251;
							}
						}
						else
						{
							((Entity)val5).Visible = true;
							((Entity)val5).ColorIndex = 1;
						}
						((DBText)val5).AdjustAlignment(database);
						((Entity)val5).Draw();
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					ObjectId = ((DBObject)val3).ObjectId;
					result = true;
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
		return result;
	}

	public static bool SelecionaModeloPincel(ref ObjectId ObjectId, ref string sTipo, ref mAtt[] mAtt)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Obj, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected Obj, but got Unknown
		bool result = false;
		int num = 0;
		mAtt = new mAtt[1];
		checked
		{
			if (!ObjectId.IsNull)
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
				try
				{
					Transaction val2 = database.TransactionManager.StartTransaction();
					try
					{
						BlockReference val3 = (BlockReference)val2.GetObject(ObjectId, (OpenMode)0);
						Entity ent = (Entity)val2.GetObject(ObjectId, (OpenMode)0);
						string tipoImportado = "";
						sTipo = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
						if (Operators.CompareString(sTipo, "", TextCompare: true) == 0)
						{
							result = false;
						}
						else
						{
							_ = (BlockTableRecord)val2.GetObject(val3.BlockTableRecord, (OpenMode)0);
							AttributeCollection attributeCollection = val3.AttributeCollection;
							foreach (object item in attributeCollection)
							{
								object objectValue = RuntimeHelpers.GetObjectValue(item);
								AttributeReference val4 = (AttributeReference)NewLateBinding.LateGet(objectValue, null, "GetObject", new object[1] { (object)(OpenMode)1 }, null, null, null);
								num++;
								mAtt = (mAtt[])Utils.CopyArray(mAtt, new mAtt[num + 1]);
								mAtt[num].sTag = val4.Tag;
								mAtt[num].bVisivel = ((Entity)val4).Visible;
							}
							result = true;
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
			return result;
		}
	}

	public static bool SelecionaOsObjetosPincel(ref object[] ObjIDSSelect, string sTipo)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected Obj, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected Obj, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		ObjIDSSelect = new object[1];
		bool result = false;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					_ = Application.DocumentManager.MdiActiveDocument;
					Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
					PromptSelectionOptions val3 = new PromptSelectionOptions();
					editor.WriteMessage(Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 1137])));
					val3.Keywords.GetDisplayString(true);
					PromptSelectionResult selection = editor.GetSelection(val3);
					if (!Information.IsNothing(selection.Value))
					{
						SelectionSet value = selection.Value;
						ObjectIdCollection val4 = new ObjectIdCollection(value.GetObjectIds());
						foreach (object item in val4)
						{
							ObjectId val5 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							Entity ent = (Entity)val5.GetObject((OpenMode)0);
							string tipoImportado = "";
							if (Operators.CompareString(sTipo, XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), TextCompare: true) == 0)
							{
								int num = Information.UBound(ObjIDSSelect) + 1;
								ObjIDSSelect = (object[])Utils.CopyArray(ObjIDSSelect, new object[num + 1]);
								ObjIDSSelect[num] = val5;
								result = true;
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
			return result;
		}
	}

	public static bool EditaBlocosPincel(ref ObjectId ObjectId, ref mAtt[] mAtt)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected Obj, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		if (!ObjectId.IsNull)
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockReference val3 = (BlockReference)val2.GetObject(ObjectId, (OpenMode)0);
					_ = (Entity)val2.GetObject(ObjectId, (OpenMode)0);
					_ = (BlockTableRecord)val2.GetObject(val3.BlockTableRecord, (OpenMode)0);
					AttributeCollection attributeCollection = val3.AttributeCollection;
					foreach (object item in attributeCollection)
					{
						object objectValue = RuntimeHelpers.GetObjectValue(item);
						AttributeReference val4 = (AttributeReference)NewLateBinding.LateGet(objectValue, null, "GetObject", new object[1] { (object)(OpenMode)1 }, null, null, null);
						int num = Information.UBound(mAtt);
						for (int i = 1; i <= num; i = checked(i + 1))
						{
							if (Operators.CompareString(val4.Tag, mAtt[i].sTag, TextCompare: true) == 0)
							{
								((Entity)val4).Visible = mAtt[i].bVisivel;
							}
						}
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					ObjectId = ((DBObject)val3).ObjectId;
					result = true;
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
		return result;
	}

	public static void MudaCorTextodoBlocos(ref ObjectId ObjectId, ref object[,] sHandle, string sTipo)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockReference val3 = (BlockReference)val2.GetObject(ObjectId, (OpenMode)0);
					_ = (Entity)val2.GetObject(ObjectId, (OpenMode)0);
					_ = (BlockTableRecord)val2.GetObject(val3.BlockTableRecord, (OpenMode)0);
					AttributeCollection attributeCollection = val3.AttributeCollection;
					foreach (object item in attributeCollection)
					{
						ObjectId val4 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						AttributeReference val5 = (AttributeReference)val4.GetObject((OpenMode)1);
						int num = Information.UBound(sHandle, 2);
						for (int i = 1; i <= num; i++)
						{
							if (!Operators.ConditionalCompareObjectEqual(sHandle[0, i], val5.Tag, TextCompare: true))
							{
								continue;
							}
							if (!((((Operators.CompareString(Strings.Mid(val5.Tag, 1, 1), "T", TextCompare: true) == 0) | (Operators.CompareString(Strings.Mid(val5.Tag, 1, 1), "B", TextCompare: true) == 0)) & Versioned.IsNumeric(Strings.Mid(val5.Tag, 2, Strings.Len(val5.Tag) - 1))) | (Operators.CompareString(val5.Tag, "EFC", TextCompare: true) == 0)))
							{
								if (!((Operators.CompareString(val5.Tag, "NOME1", TextCompare: true) == 0) & (Operators.CompareString(sTipo, "M", TextCompare: true) == 0)))
								{
									if (!Operators.ConditionalCompareObjectEqual(sHandle[1, i], true, TextCompare: true))
									{
										((Entity)val5).ColorIndex = 1;
									}
									else
									{
										((Entity)val5).ColorIndex = 3;
									}
								}
								else
								{
									((Entity)val5).ColorIndex = 251;
								}
							}
							else
							{
								((Entity)val5).ColorIndex = 251;
							}
						}
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					ObjectId = ((DBObject)val3).ObjectId;
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

	private static bool znTpU2LcJu(ref object P_0, ref object[,] P_1, ref ObjectId P_2, string P_3)
	{
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected Obj, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected Obj, but got Unknown
		bool flag = false;
		string left = "";
		bool flag2 = false;
		int num = Information.UBound(P_1, 2);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				if (Operators.ConditionalCompareObjectEqual(P_1[6, i], true, TextCompare: true))
				{
					object objectValue = RuntimeHelpers.GetObjectValue(P_1[2, i]);
					object objectValue2 = RuntimeHelpers.GetObjectValue(P_1[3, i]);
					if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.CompareObjectLessEqual(NewLateBinding.LateIndexGet(objectValue, new object[1] { 0 }, null), NewLateBinding.LateIndexGet(P_0, new object[1] { 0 }, null), TextCompare: true), Operators.CompareObjectLessEqual(NewLateBinding.LateIndexGet(objectValue, new object[1] { 1 }, null), NewLateBinding.LateIndexGet(P_0, new object[1] { 1 }, null), TextCompare: true)), Operators.AndObject(Operators.CompareObjectLessEqual(NewLateBinding.LateIndexGet(P_0, new object[1] { 0 }, null), NewLateBinding.LateIndexGet(objectValue2, new object[1] { 0 }, null), TextCompare: true), Operators.CompareObjectLessEqual(NewLateBinding.LateIndexGet(P_0, new object[1] { 1 }, null), NewLateBinding.LateIndexGet(objectValue2, new object[1] { 1 }, null), TextCompare: true)))))
					{
						left = Conversions.ToString(P_1[0, i]);
						Conversions.ToString(P_1[5, i]);
						flag2 = true;
						P_0 = null;
						break;
					}
				}
			}
			if (flag2)
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
				try
				{
					Transaction val2 = database.TransactionManager.StartTransaction();
					try
					{
						BlockReference val3 = (BlockReference)val2.GetObject(P_2, (OpenMode)0);
						_ = (Entity)val2.GetObject(P_2, (OpenMode)0);
						_ = (BlockTableRecord)val2.GetObject(val3.BlockTableRecord, (OpenMode)0);
						AttributeCollection attributeCollection = val3.AttributeCollection;
						foreach (object item in attributeCollection)
						{
							ObjectId val4 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference val5 = (AttributeReference)val4.GetObject((OpenMode)1);
							int num2 = Information.UBound(P_1, 2);
							for (int j = 1; j <= num2; j++)
							{
								if ((((Operators.CompareString(Strings.Mid(val5.Tag, 1, 1), "T", TextCompare: true) == 0) | (Operators.CompareString(Strings.Mid(val5.Tag, 1, 1), "B", TextCompare: true) == 0)) & Versioned.IsNumeric(Strings.Mid(val5.Tag, 2, Strings.Len(val5.Tag) - 1))) | (Operators.CompareString(val5.Tag, "EFC", TextCompare: true) == 0))
								{
									break;
								}
								if (Operators.ConditionalCompareObjectEqual(left, P_1[0, j], TextCompare: true))
								{
									flag = true;
									if (!Operators.ConditionalCompareObjectEqual(P_1[1, j], true, TextCompare: true))
									{
										P_1[1, j] = true;
										((Entity)val5).ColorIndex = 3;
									}
									else
									{
										P_1[1, j] = false;
										((Entity)val5).ColorIndex = 1;
									}
									if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareString(P_3, "M", TextCompare: true) == 0, Operators.CompareObjectEqual(P_1[0, j], "NOME1", TextCompare: true))))
									{
										P_1[1, j] = true;
										((Entity)val5).ColorIndex = 251;
									}
								}
								if (flag)
								{
									break;
								}
							}
							if (flag)
							{
								break;
							}
						}
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
						((Entity)val3).Draw();
						P_2 = ((DBObject)val3).ObjectId;
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
			return flag;
		}
	}

	public static void OcultaTextosHandle(ObjectId ObjectId, ref object[,] sHandle)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected Obj, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockReference val3 = (BlockReference)val2.GetObject(ObjectId, (OpenMode)0);
				_ = (Entity)val2.GetObject(ObjectId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(val3.BlockTableRecord, (OpenMode)0);
				AttributeCollection attributeCollection = val3.AttributeCollection;
				foreach (object item in attributeCollection)
				{
					ObjectId val4 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
					AttributeReference val5 = (AttributeReference)val4.GetObject((OpenMode)1);
					int num = Information.UBound(sHandle, 2);
					for (int i = 1; i <= num; i = checked(i + 1))
					{
						if (Operators.ConditionalCompareObjectEqual(val5.Tag, sHandle[0, i], TextCompare: true))
						{
							((Entity)val5).Visible = Conversions.ToBoolean(sHandle[1, i]);
							((Entity)val5).ColorIndex = Conversions.ToInteger(sHandle[4, i]);
						}
					}
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

	public static ObjectId selecionaUmBloco(ref string Tipo)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected Obj, but got Unknown
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected Obj, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		ObjectId result = ObjectId.Null;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		_ = Application.DocumentManager.MdiActiveDocument.Editor;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			try
			{
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				Point3d ptInsert = default;
				ObjectId val2 = selPonto(ref ptInsert, Tipo);
				if (!val2.IsNull)
				{
					Entity ent = (Entity)val.GetObject(val2, (OpenMode)0);
					if (!Information.IsDBNull(ent))
					{
						string tipoImportado = "";
						string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
						if (!((Operators.CompareString(text, "A", TextCompare: true) == 0) | (Operators.CompareString(text, "B", TextCompare: true) == 0) | (Operators.CompareString(text, "E", TextCompare: true) == 0) | (Operators.CompareString(text, "P", TextCompare: true) == 0) | (Operators.CompareString(text, "I", TextCompare: true) == 0) | (Operators.CompareString(text, "M", TextCompare: true) == 0)))
						{
							BlockReference blockRef = (BlockReference)ent;
							int painel = 0;
							tipoImportado = "";
							string alternativo = "";
							string Handle = "";
							bool flag = XDataLayout.lerXDataDispLayout(ref blockRef, ref painel, ref tipoImportado, ref alternativo, ref Handle);
							ent = (Entity)(object)blockRef;
							if (!flag)
							{
								result = default;
							}
							else
							{
								result = val2;
								Tipo = "L";
							}
						}
						else
						{
							result = val2;
							Tipo = text;
						}
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				result = default;
				ProjectData.ClearProjectError();
			}
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return result;
	}

	public static ObjectId selPonto(ref Point3d ptInsert, string sTipo)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Invalid comparison between Unknown and I4
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		if (Operators.CompareString(sTipo, "B", TextCompare: true) != 0)
		{
			if (Operators.CompareString(sTipo, "ATT", TextCompare: true) != 0)
			{
				if (Operators.CompareString(sTipo, "", TextCompare: true) == 0)
				{
					text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 802]);
				}
			}
			else
			{
				text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1352]);
			}
		}
		else
		{
			text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1351]);
		}
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		PromptEntityOptions val = new PromptEntityOptions("\r\n" + text);
		val.SetRejectMessage("\r\n");
		val.AddAllowedClass(typeof(BlockReference), false);
		PromptEntityResult entity = editor.GetEntity(val);
		if ((int)((PromptResult)entity).Status == 5100)
		{
			ptInsert = entity.PickedPoint;
			return entity.ObjectId;
		}
		return ObjectId.Null;
	}
}
