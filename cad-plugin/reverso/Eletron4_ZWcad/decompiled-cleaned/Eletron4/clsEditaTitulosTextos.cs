using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

public class clsEditaTitulosTextos
{
	public static void EditaTitulosTextosDoDWG(bool b1, bool b2, bool b3, bool b4, bool bText, bool bMText, string sDe, string sPara, List<string> lPaginas)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected Obj, but got Unknown
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected Obj, but got Unknown
		long num = 0L;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val3.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						string text = "";
						string text2 = "";
						Entity Ent = (Entity)val.GetObject(current, (OpenMode)0);
						if (!lPaginas.Contains(Ent.Layer.ToString()))
						{
							continue;
						}
						BlockReference val4 = (BlockReference)(object)((Ent is BlockReference) ? Ent : null);
						if (val4 != null)
						{
							continue;
						}
						DBText val5 = (DBText)(object)((Ent is DBText) ? Ent : null);
						if (val5 != null)
						{
							int Tipo = 0;
							if (!LeXDataTitulo(ref Ent, ref Tipo))
							{
								if (bText && !LerXDataVazio(ref Ent) && val5 != null)
								{
									text = val5.TextString;
									if (Operators.CompareString(text.ToString().Trim(), "", TextCompare: true) != 0)
									{
										text2 = text.Replace(sDe, sPara);
									}
									if (Operators.CompareString(text2.ToUpper().Trim(), text.ToUpper().Trim(), TextCompare: true) != 0)
									{
										clsTextos.AtualizarTexto(val5, text2);
										num++;
									}
								}
							}
							else
							{
								text = val5.TextString;
								if (Operators.CompareString(text.ToString().Trim(), "", TextCompare: true) != 0)
								{
									switch (Tipo)
									{
									case 4:
										if (b4)
										{
											text2 = text.Replace(sDe, sPara);
											if (Operators.CompareString(text2.ToUpper().Trim(), text.ToUpper().Trim(), TextCompare: true) != 0)
											{
												clsTextos.AtualizarTexto(val5, text2);
												num++;
											}
										}
										break;
									case 1:
										if (b1)
										{
											text2 = text.Replace(sDe, sPara);
											if (Operators.CompareString(text2.ToUpper().Trim(), text.ToUpper().Trim(), TextCompare: true) != 0)
											{
												clsTextos.AtualizarTexto(val5, text2);
												num++;
											}
										}
										break;
									case 2:
										if (b2)
										{
											text2 = text.Replace(sDe, sPara);
											if (Operators.CompareString(text2.ToUpper().Trim(), text.ToUpper().Trim(), TextCompare: true) != 0)
											{
												clsTextos.AtualizarTexto(val5, text2);
												num++;
											}
										}
										break;
									case 3:
										if (b3)
										{
											text2 = text.Replace(sDe, sPara);
											if (Operators.CompareString(text2.ToUpper().Trim(), text.ToUpper().Trim(), TextCompare: true) != 0)
											{
												clsTextos.AtualizarTexto(val5, text2);
												num++;
											}
										}
										break;
									}
								}
							}
						}
						if (!bMText)
						{
							continue;
						}
						MText val6 = (MText)(object)((Ent is MText) ? Ent : null);
						if (val6 != null && !LerXDataVazio(ref Ent))
						{
							text = val6.Contents;
							if (Operators.CompareString(text.ToString().Trim(), "", TextCompare: true) != 0)
							{
								text2 = text.Replace(sDe, sPara);
							}
							if (Operators.CompareString(text2.ToUpper().Trim(), text.ToUpper().Trim(), TextCompare: true) != 0)
							{
								clsTextos.AtualizarMTexto(val6, text2);
								num++;
							}
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
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				Interaction.MsgBox(Operators.ConcatenateObject(Conversions.ToString(num), DeclaracoesGeral.mMensagem[1, 1221]), MsgBoxStyle.Information);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static bool LerXDataVazio(ref Entity Ent)
	{
		bool result = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("Eletron");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("DiagLog");
			if (val == null)
			{
				val = ((DBObject)Ent).GetXDataForApplication("TextoLP");
				if (val == null)
				{
					val = ((DBObject)Ent).GetXDataForApplication("AUXCONEXAO");
					if (val == null)
					{
						val = ((DBObject)Ent).GetXDataForApplication("AUXINTERLIG");
						if (val == null)
						{
							val = ((DBObject)Ent).GetXDataForApplication("AUXIMPORTADO");
							if (val == null)
							{
								val = ((DBObject)Ent).GetXDataForApplication("DEPARA");
								if (val == null)
								{
									val = ((DBObject)Ent).GetXDataForApplication("Definicao");
									if (val != null)
									{
										result = true;
									}
								}
								else
								{
									result = true;
								}
							}
							else
							{
								result = true;
							}
						}
						else
						{
							result = true;
						}
					}
					else
					{
						result = true;
					}
				}
				else
				{
					result = true;
				}
			}
			else
			{
				result = true;
			}
		}
		else
		{
			result = true;
		}
		return result;
	}

	public static bool LeXDataTitulo(ref Entity Ent, ref int Tipo)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)Ent).GetXDataForApplication("DiagLog");
		if (Information.IsNothing(xDataForApplication))
		{
			xDataForApplication = ((DBObject)Ent).GetXDataForApplication("DiagLog".ToUpper());
		}
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "TITULOPAGINA", TextCompare: true) == 0 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreater(array[2].Value, 0, TextCompare: true), Operators.CompareObjectLess(array[2].Value, 5, TextCompare: true))))
			{
				result = true;
				Tipo = Conversions.ToInteger(array[2].Value);
			}
		}
		return result;
	}

	public static void AtualizaUmTituloEditado(string sHandle, int iTipo, string NovoValor)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				Entity val3 = (Entity)Geral.HandleToObject(sHandle);
				if (val3 != null)
				{
					DBText val4 = (DBText)(object)((val3 is DBText) ? val3 : null);
					if (val4 != null)
					{
						int Tipo = 0;
						Entity Ent = (Entity)(object)val4;
						LeXDataTitulo(ref Ent, ref Tipo);
						val4 = (DBText)Ent;
						((DBObject)val4).UpgradeOpen();
						XDataGeral.gravarXDataTitulo(ref val4, Tipo, NovoValor);
						val4.TextString = NovoValor;
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
	}
}
