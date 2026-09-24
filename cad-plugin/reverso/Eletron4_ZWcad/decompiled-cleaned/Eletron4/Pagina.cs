using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class Pagina
{
	public static void CarregaPaginasOrdenadasNova()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected Obj, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Obj, but got Unknown
		checked
		{
			try
			{
				DeclaracoesGeral.StructurePaginas[] array = new DeclaracoesGeral.StructurePaginas[1];
				DeclaracoesGeral.mPaginasNova = new DeclaracoesGeral.StructurePaginas[1];
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Database database = mdiActiveDocument.Database;
				try
				{
					int num = 1;
					Transaction val = database.TransactionManager.StartTransaction();
					try
					{
						LayerTable val2 = (LayerTable)val.GetObject(database.LayerTableId, (OpenMode)0);
						SymbolTableEnumerator enumerator = default;
						try
						{
							enumerator = val2.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								LayerTableRecord val3 = (LayerTableRecord)val.GetObject(current, (OpenMode)0);
								try
								{
									if (LayerValido(((SymbolTableRecord)val3).Name))
									{
										string unidade = "";
										string alternativo = "";
										LayerTableRecord Layer = val3;
										XDataGeral.LeXDataUnidadeAlternativo(ref Layer, ref unidade, ref alternativo);
										array = (DeclaracoesGeral.StructurePaginas[])Utils.CopyArray(array, new DeclaracoesGeral.StructurePaginas[Information.UBound(array) + 1 + 1]);
										array[Information.UBound(array)].Pagina = ((SymbolTableRecord)val3).Name;
										array[Information.UBound(array)].PaginaDec = calculaPaginaDecimal(((SymbolTableRecord)val3).Name);
										array[Information.UBound(array)].Unidade = unidade;
										array[Information.UBound(array)].Alternativo = alternativo;
										array[Information.UBound(array)].Revisao = "";
										array[Information.UBound(array)].Vao = "";
										num++;
									}
								}
								finally
								{
									((IDisposable)val3)?.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						DeclaracoesGeral.StructurePaginas[] mPaginasNova = array.OrderBy([SpecialName] (DeclaracoesGeral.StructurePaginas x) => x.PaginaDec).ToArray();
						DeclaracoesGeral.mPaginasNova = mPaginasNova;
						Revisao.capturaRevisoesSimplificadasNova();
						int num2 = Information.UBound(DeclaracoesGeral.mPaginasNova);
						for (num = 1; num <= num2; num++)
						{
							if (DeclaracoesGeral.dicRevSimplificadaNova.ContainsKey(DeclaracoesGeral.mPaginasNova[num].Pagina))
							{
								DeclaracoesGeral.mPaginasNova[num].Revisao = DeclaracoesGeral.dicRevSimplificadaNova[DeclaracoesGeral.mPaginasNova[num].Pagina];
							}
						}
						Revisao.capturaRevisoesCompletas();
						int num3 = Information.UBound(DeclaracoesGeral.mPaginasNova);
						for (num = 1; num <= num3; num++)
						{
							int num4 = Information.UBound(DeclaracoesGeral.mRevCompleta);
							for (int num5 = 1; num5 <= num4; num5++)
							{
								if (Operators.CompareString(DeclaracoesGeral.mPaginasNova[num].Pagina, DeclaracoesGeral.mRevCompleta[num5].Pagina, TextCompare: true) == 0)
								{
									if (Operators.CompareString(DeclaracoesGeral.mRevCompleta[num5].Revisao, "", TextCompare: true) != 0)
									{
										DeclaracoesGeral.mPaginasNova[num].Revisao = DeclaracoesGeral.mRevCompleta[num5].Revisao;
									}
									break;
								}
							}
						}
						DeclaracoesGeral.bAnularEventos = true;
						val.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					finally
					{
						((IDisposable)val)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)database)?.Dispose();
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public static void CarregaPaginas()
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected Obj, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		checked
		{
			try
			{
				DeclaracoesGeral.mPaginas = new object[5, 1];
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Database database = mdiActiveDocument.Database;
				try
				{
					int num = 1;
					Transaction val = database.TransactionManager.StartTransaction();
					try
					{
						LayerTable val2 = (LayerTable)val.GetObject(database.LayerTableId, (OpenMode)0);
						SymbolTableEnumerator enumerator = default;
						try
						{
							enumerator = val2.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								LayerTableRecord val3 = (LayerTableRecord)val.GetObject(current, (OpenMode)0);
								try
								{
									string unidade = "";
									string alternativo = "";
									LayerTableRecord Layer = val3;
									XDataGeral.LeXDataUnidadeAlternativo(ref Layer, ref unidade, ref alternativo);
									if (LayerValido(((SymbolTableRecord)val3).Name))
									{
										DeclaracoesGeral.mPaginas = (object[,])Utils.CopyArray(DeclaracoesGeral.mPaginas, new object[5, num + 1]);
										DeclaracoesGeral.mPaginas[0, num] = ((SymbolTableRecord)val3).Name;
										DeclaracoesGeral.mPaginas[1, num] = calculaPaginaDecimal(((SymbolTableRecord)val3).Name);
										DeclaracoesGeral.mPaginas[2, num] = "";
										DeclaracoesGeral.mPaginas[3, num] = unidade;
										DeclaracoesGeral.mPaginas[4, num] = alternativo;
										num++;
									}
								}
								finally
								{
									((IDisposable)val3)?.Dispose();
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
				}
				finally
				{
					((IDisposable)database)?.Dispose();
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public static void OrdenaMatrizPaginas()
	{
		if (Information.UBound(DeclaracoesGeral.mPaginas, 2) < 2 || Information.UBound(DeclaracoesGeral.mPaginas, 2) <= 0)
		{
			return;
		}
		checked
		{
			int num = Information.UBound(DeclaracoesGeral.mPaginas, 2) - 1;
			for (int i = num; i >= 1; i += -1)
			{
				int num2 = i;
				for (int j = 1; j <= num2; j++)
				{
					if (Operators.ConditionalCompareObjectGreater(DeclaracoesGeral.mPaginas[1, j], DeclaracoesGeral.mPaginas[1, j + 1], TextCompare: true))
					{
						int num3 = 0;
						do
						{
							object objectValue = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mPaginas[num3, j + 1]);
							DeclaracoesGeral.mPaginas[num3, j + 1] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mPaginas[num3, j]);
							DeclaracoesGeral.mPaginas[num3, j] = RuntimeHelpers.GetObjectValue(objectValue);
							num3++;
						}
						while (num3 <= 4);
					}
				}
			}
		}
	}

	public static bool LayerValido(string pagina)
	{
		bool result;
		try
		{
			if (!Versioned.IsNumeric(pagina))
			{
				string expression = Strings.Mid(pagina, 1, checked(Strings.Len(pagina) - 1));
				if (!Versioned.IsNumeric(expression))
				{
					result = false;
				}
				else
				{
					string text = Strings.Mid(pagina, Strings.Len(pagina), 1);
					result = ((((Strings.Asc(text) >= 48) & (Strings.Asc(text) <= 57)) | ((Strings.Asc(text) >= 65) & (Strings.Asc(text) <= 90))) ? true : false);
				}
			}
			else
			{
				int num = Conversions.ToInteger(pagina);
				result = num > 0;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static double calculaPaginaDecimal(string pagina)
	{
		double result = 0.0;
		try
		{
			string text = "";
			string text2 = "";
			if (!Versioned.IsNumeric(pagina))
			{
				text2 = Strings.Mid(pagina, 1, checked(Strings.Len(pagina) - 1));
				if (Versioned.IsNumeric(text2))
				{
					text = Strings.Mid(pagina, Strings.Len(pagina), 1);
					if ((Strings.Asc(text) >= 65) & (Strings.Asc(text) <= 90))
					{
						result = Conversions.ToDouble(text2) + (double)Strings.Asc(text) / 100.0;
					}
				}
			}
			else
			{
				result = Conversions.ToDouble(pagina);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		return result;
	}

	public static int calculaEspacoNumerico(string p0, string p1)
	{
		int num = 0;
		double num2 = (Versioned.IsNumeric(p0) ? Conversions.ToDouble(p0) : (Math.Floor(calculaPaginaDecimal(p0)) + 1.0));
		double num3 = (Versioned.IsNumeric(p1) ? (Conversions.ToDouble(p1) - 1.0) : Math.Floor(calculaPaginaDecimal(p1)));
		return checked((int)Math.Round(num3 - num2 + 1.0));
	}

	public static int calculaEspacoAlfaNumerico(string p0, string p1)
	{
		double num = calculaPaginaDecimal(p0);
		double num2 = calculaPaginaDecimal(p1);
		checked
		{
			int num3 = (int)Math.Floor(num);
			int num4 = (int)Math.Round((num - Math.Floor(num)) * 100.0);
			int num5 = (int)Math.Floor(num2);
			int num6 = (int)Math.Round((num2 - Math.Floor(num2)) * 100.0);
			int num7;
			if (num3 != num5)
			{
				if (num4 == 0)
				{
					num4 = 64;
				}
				num7 = 91 - num4;
				if (num6 > 0)
				{
					num7 += num6 - 64;
				}
				if (num5 - num3 > 1)
				{
					num7 += (num5 - num3 - 1) * 27;
				}
			}
			else
			{
				if (num4 == 0)
				{
					num4 = 64;
				}
				num7 = num6 - num4;
			}
			return num7;
		}
	}

	public static void definePaginasNumericas(ref object mPagSel, string p0)
	{
		checked
		{
			try
			{
				double num = (Versioned.IsNumeric(p0) ? Conversions.ToDouble(p0) : (Math.Floor(calculaPaginaDecimal(p0)) + 1.0));
				int num2 = Information.UBound((Array)mPagSel, 2);
				for (int i = 1; i <= num2; i++)
				{
					NewLateBinding.LateIndexSet(mPagSel, new object[3]
					{
						2,
						i,
						(num + (double)((i - 1) * DeclaracoesGeral.Conf.PassoPagina)).ToString()
					}, null);
					NewLateBinding.LateIndexSet(mPagSel, new object[3]
					{
						2,
						i,
						montaNumeroPagina(Conversions.ToString(NewLateBinding.LateIndexGet(mPagSel, new object[2] { 2, i }, null)))
					}, null);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public static void definePaginasAlfaNumericas(ref object mPagSel, string p0)
	{
		checked
		{
			try
			{
				int num;
				int num2;
				if (!Versioned.IsNumeric(p0))
				{
					num = Strings.Asc(Strings.Mid(p0, p0.Length, 1));
					num2 = Conversions.ToInteger(Strings.Mid(p0, 1, p0.Length - 1));
				}
				else
				{
					num = 64;
					num2 = Conversions.ToInteger(p0);
				}
				int num3 = Information.UBound((Array)mPagSel, 2);
				for (int i = 1; i <= num3; i++)
				{
					if (num == 91)
					{
						num = 64;
						num2++;
					}
					string text = ((num == 64) ? "" : Conversions.ToString(Strings.Chr(num)));
					NewLateBinding.LateIndexSet(mPagSel, new object[3]
					{
						2,
						i,
						num2 + text
					}, null);
					NewLateBinding.LateIndexSet(mPagSel, new object[3]
					{
						2,
						i,
						montaNumeroPagina(Conversions.ToString(NewLateBinding.LateIndexGet(mPagSel, new object[2] { 2, i }, null)))
					}, null);
					num++;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public static void calculaNovaPagina(ref DeclaracoesGeral.tPagina pagAnt, ref DeclaracoesGeral.tPagina pagCorrente, ref DeclaracoesGeral.tPagina pagPost)
	{
		checked
		{
			try
			{
				if (Operators.CompareString(pagPost.Pagina.ToString().Trim(), "", TextCompare: true) == 0)
				{
					pagPost.Pagina = "1000000";
				}
				int num;
				int num2;
				if (!Versioned.IsNumeric(pagPost.Pagina))
				{
					num = Strings.Asc(Strings.Mid(pagPost.Pagina, pagPost.Pagina.Length, 1));
					num2 = Conversions.ToInteger(Strings.Mid(pagPost.Pagina, 1, pagPost.Pagina.Length - 1));
				}
				else
				{
					num = 64;
					num2 = Conversions.ToInteger(pagPost.Pagina);
				}
				int num3;
				int num4;
				if (!Versioned.IsNumeric(pagAnt.Pagina))
				{
					num3 = Strings.Asc(Strings.Mid(pagAnt.Pagina, pagAnt.Pagina.Length, 1));
					num4 = Conversions.ToInteger(Strings.Mid(pagAnt.Pagina, 1, pagAnt.Pagina.Length - 1));
				}
				else
				{
					num3 = 64;
					num4 = Conversions.ToInteger(pagAnt.Pagina);
				}
				int num5 = default;
				int num6 = default;
				if (Versioned.IsNumeric(pagAnt.Pagina) & Versioned.IsNumeric(pagPost.Pagina))
				{
					if (num2 - num4 <= DeclaracoesGeral.Conf.PassoPagina)
					{
						if (num2 <= num4 + 1)
						{
							num5 = num4;
							num6 = 65;
						}
						else
						{
							num5 = num4 + 1;
							num6 = 64;
						}
					}
					else
					{
						num5 = num4 + DeclaracoesGeral.Conf.PassoPagina;
						num6 = 64;
					}
				}
				if (Versioned.IsNumeric(pagAnt.Pagina) & !Versioned.IsNumeric(pagPost.Pagina))
				{
					if (num2 - num4 <= DeclaracoesGeral.Conf.PassoPagina)
					{
						if (num2 <= num4 + 1)
						{
							if (num2 != num4 + 1)
							{
								if (num2 == num4)
								{
									num6 = 65;
									num5 = ((65 != num) ? num4 : 0);
								}
							}
							else
							{
								num5 = num4;
								num6 = 65;
							}
						}
						else
						{
							num5 = num4 + 1;
							num6 = 64;
						}
					}
					else
					{
						num5 = num4 + DeclaracoesGeral.Conf.PassoPagina;
						num6 = 64;
					}
				}
				if (!Versioned.IsNumeric(pagAnt.Pagina) & Versioned.IsNumeric(pagPost.Pagina))
				{
					if (num2 - num4 <= DeclaracoesGeral.Conf.PassoPagina)
					{
						if (num2 <= num4 + 1)
						{
							if (num2 == num4 + 1)
							{
								num6 = num3 + 1;
								num5 = ((num6 <= 90) ? num4 : 0);
							}
						}
						else
						{
							num5 = num4 + 1;
							num6 = 64;
						}
					}
					else
					{
						num5 = num4 + DeclaracoesGeral.Conf.PassoPagina;
						num6 = 64;
					}
				}
				if (!Versioned.IsNumeric(pagAnt.Pagina) & !Versioned.IsNumeric(pagPost.Pagina))
				{
					if (num2 - num4 <= DeclaracoesGeral.Conf.PassoPagina)
					{
						if (num2 <= num4 + 1)
						{
							if (num2 != num4 + 1)
							{
								if (num2 == num4)
								{
									num6 = num3 + 1;
									num5 = ((num6 < num) ? num4 : 0);
								}
							}
							else
							{
								num6 = num3 + 1;
								if (num6 > 90)
								{
									num6 = num - 1;
									num5 = ((num6 > 64) ? num2 : 0);
								}
								else
								{
									num5 = num4;
								}
							}
						}
						else
						{
							num5 = num4 + 1;
							num6 = 64;
						}
					}
					else
					{
						num5 = num4 + DeclaracoesGeral.Conf.PassoPagina;
						num6 = 64;
					}
				}
				pagCorrente.PgNum = Conversions.ToString(num5);
				if (num6 != 64)
				{
					pagCorrente.PgAlfa = Conversions.ToString(Strings.Chr(num6));
				}
				else
				{
					pagCorrente.PgAlfa = "";
				}
				pagCorrente.Pagina = pagCorrente.PgNum + pagCorrente.PgAlfa;
				pagCorrente.PgDec = calculaPaginaDecimal(pagCorrente.Pagina);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public static void capturaTitulosDeUmaPagina(ref DeclaracoesGeral.tPagina pag)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected Obj, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected Obj, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		checked
		{
			try
			{
				Transaction val = database.TransactionManager.StartTransaction();
				try
				{
					pag.Titulo1 = "";
					pag.Titulo2 = "";
					pag.Titulo3 = "";
					pag.Titulo4 = "";
					BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val3.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val4 = (Entity)val.GetObject(current, (OpenMode)0);
							try
							{
								if (Operators.CompareString(val4.Layer.ToString(), pag.Pagina, TextCompare: true) != 0)
								{
									continue;
								}
								DBText val5 = (DBText)(object)((val4 is DBText) ? val4 : null);
								try
								{
									int num = 0;
									if (!((DisposableWrapper)(object)val5 != (DisposableWrapper)null))
									{
										continue;
									}
									DBText text = val5;
									int num2 = XDataGeral.LeXDataTitulo(ref text);
									if ((num2 > 0) & (num2 < 5))
									{
										string textString = val5.TextString;
										switch (num2)
										{
										case 4:
											pag.Titulo4 = textString;
											num++;
											break;
										case 1:
											pag.Titulo1 = textString;
											num++;
											break;
										case 2:
											pag.Titulo2 = textString;
											num++;
											break;
										case 3:
											pag.Titulo3 = textString;
											num++;
											break;
										}
										if (num == 4)
										{
											break;
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
			finally
			{
				((IDisposable)database)?.Dispose();
			}
		}
	}

	public static void capturaTitulos()
	{
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected Obj, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected Obj, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected Obj, but got Unknown
		checked
		{
			DeclaracoesGeral.mTitulos = new object[7, Information.UBound(DeclaracoesGeral.mPaginas, 2) + 1];
			int num = Information.UBound(DeclaracoesGeral.mPaginas, 2);
			for (int i = 1; i <= num; i++)
			{
				DeclaracoesGeral.mTitulos[0, i] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mPaginas[0, i]);
				DeclaracoesGeral.mTitulos[1, i] = "";
				DeclaracoesGeral.mTitulos[2, i] = "";
				DeclaracoesGeral.mTitulos[3, i] = "";
				DeclaracoesGeral.mTitulos[4, i] = "";
				DeclaracoesGeral.mTitulos[5, i] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mPaginas[3, i]);
				DeclaracoesGeral.mTitulos[6, i] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mPaginas[4, i]);
			}
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			try
			{
				Transaction val = database.TransactionManager.StartTransaction();
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
							Entity val4 = (Entity)val.GetObject(current, (OpenMode)0);
							try
							{
								DBText val5 = (DBText)(object)((val4 is DBText) ? val4 : null);
								try
								{
									if (!((DisposableWrapper)(object)val5 != (DisposableWrapper)null))
									{
										continue;
									}
									DBText text = val5;
									int num2 = XDataGeral.LeXDataTitulo(ref text);
									if (!((num2 > 0) & (num2 < 5)))
									{
										continue;
									}
									string textString = val5.TextString;
									int num3 = Information.UBound(DeclaracoesGeral.mTitulos, 2);
									for (int j = 1; j <= num3; j++)
									{
										if (Operators.ConditionalCompareObjectEqual(val4.Layer.ToString(), DeclaracoesGeral.mTitulos[0, j], TextCompare: true))
										{
											switch (num2)
											{
											case 4:
												DeclaracoesGeral.mTitulos[4, j] = textString;
												break;
											case 1:
												DeclaracoesGeral.mTitulos[1, j] = textString;
												break;
											case 2:
												DeclaracoesGeral.mTitulos[2, j] = textString;
												break;
											case 3:
												DeclaracoesGeral.mTitulos[3, j] = textString;
												break;
											}
											break;
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
			finally
			{
				((IDisposable)database)?.Dispose();
			}
		}
	}

	public static void criaCamposFormato(string layerRef, string layer)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected Obj, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					try
					{
						DBObject val5 = val2.GetObject(DeclaracoesGeral.blockFormatoID, (OpenMode)0);
						BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						AttributeCollection attributeCollection = val6.AttributeCollection;
						foreach (object item in attributeCollection)
						{
							ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference val8 = (AttributeReference)val2.GetObject(val7, (OpenMode)0);
							try
							{
								if (!((Operators.CompareString(((Entity)val8).Layer, layerRef, TextCompare: true) == 0) & DeclaracoesGeral.attProtCollection.Contains(val8.Tag) & (Operators.CompareString(val8.Tag, "TOT", TextCompare: true) != 0)))
								{
									continue;
								}
								string left = Strings.UCase(val8.Tag);
								if (Operators.CompareString(left, "FL", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left, "CONT", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left, "ALTERNATIVO", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left, "REV", TextCompare: true) != 0)
											{
												if (Operators.CompareString(left, "TITULO1PAG", TextCompare: true) != 0)
												{
													if (Operators.CompareString(left, "TITULO2PAG", TextCompare: true) != 0)
													{
														if (Operators.CompareString(left, "TITULO3PAG", TextCompare: true) != 0)
														{
															if (Operators.CompareString(left, "TITULO4PAG", TextCompare: true) == 0 || Operators.CompareString(left, "PAINEL", TextCompare: true) == 0)
															{
																DBText texto = dtepniSZGL6(val8, " ", layer);
																val4.AppendEntity((Entity)(object)texto);
																DeclaracoesGeral.bAnularEventos = true;
																val2.AddNewlyCreatedDBObject((DBObject)(object)texto, true);
																XDataGeral.gravarXDataTitulo(ref texto, 4, " ");
															}
														}
														else
														{
															DBText texto = dtepniSZGL6(val8, " ", layer);
															val4.AppendEntity((Entity)(object)texto);
															DeclaracoesGeral.bAnularEventos = true;
															val2.AddNewlyCreatedDBObject((DBObject)(object)texto, true);
															XDataGeral.gravarXDataTitulo(ref texto, 3, " ");
														}
													}
													else
													{
														DBText texto = dtepniSZGL6(val8, " ", layer);
														val4.AppendEntity((Entity)(object)texto);
														DeclaracoesGeral.bAnularEventos = true;
														val2.AddNewlyCreatedDBObject((DBObject)(object)texto, true);
														XDataGeral.gravarXDataTitulo(ref texto, 2, " ");
													}
												}
												else
												{
													DBText texto = dtepniSZGL6(val8, " ", layer);
													val4.AppendEntity((Entity)(object)texto);
													DeclaracoesGeral.bAnularEventos = true;
													val2.AddNewlyCreatedDBObject((DBObject)(object)texto, true);
													XDataGeral.gravarXDataTitulo(ref texto, 1, " ");
												}
											}
											else
											{
												DBText texto = dtepniSZGL6(val8, " ", layer);
												val4.AppendEntity((Entity)(object)texto);
												DeclaracoesGeral.bAnularEventos = true;
												val2.AddNewlyCreatedDBObject((DBObject)(object)texto, true);
												XDataGeral.gravarXDataTitulo(ref texto, 8, " ");
											}
										}
										else
										{
											DBText texto = dtepniSZGL6(val8, " ", layer);
											val4.AppendEntity((Entity)(object)texto);
											DeclaracoesGeral.bAnularEventos = true;
											val2.AddNewlyCreatedDBObject((DBObject)(object)texto, true);
											XDataGeral.gravarXDataTitulo(ref texto, 9, " ");
										}
									}
									else
									{
										DBText texto = dtepniSZGL6(val8, "?", layer);
										val4.AppendEntity((Entity)(object)texto);
										DeclaracoesGeral.bAnularEventos = true;
										val2.AddNewlyCreatedDBObject((DBObject)(object)texto, true);
										XDataGeral.gravarXDataTitulo(ref texto, 5, " ");
									}
								}
								else
								{
									DBText texto = dtepniSZGL6(val8, "?", layer);
									val4.AppendEntity((Entity)(object)texto);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)texto, true);
									XDataGeral.gravarXDataTitulo(ref texto, 6, " ");
								}
							}
							finally
							{
								((IDisposable)val8)?.Dispose();
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
						throw new Exception(Conversions.ToString(3), (Exception)DeclaracoesGeral.mMensagem[1, 34]);
					}
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)database)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void criaCamposTOT()
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected Obj, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		if (!DeclaracoesGeral.blockFormatoID.IsValid)
		{
			return;
		}
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		try
		{
			Transaction topTransaction = database.TransactionManager.TopTransaction;
			try
			{
				BlockTable val = (BlockTable)topTransaction.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val2 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val)[BlockTableRecord.ModelSpace], (OpenMode)1);
				try
				{
					DBObject val3 = topTransaction.GetObject(DeclaracoesGeral.blockFormatoID, (OpenMode)0);
					BlockReference val4 = (BlockReference)(object)((val3 is BlockReference) ? val3 : null);
					AttributeCollection attributeCollection = val4.AttributeCollection;
					foreach (object item in attributeCollection)
					{
						ObjectId val5 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						AttributeReference val6 = (AttributeReference)topTransaction.GetObject(val5, (OpenMode)0);
						try
						{
							if ((checaCapa(((Entity)val6).Layer) | (Operators.CompareString(((Entity)val6).Layer, "-1", TextCompare: true) == 0)) & DeclaracoesGeral.attProtCollection.Contains(val6.Tag) & (Operators.CompareString(val6.Tag, "TOT", TextCompare: true) == 0))
							{
								DBText texto = dtepniSZGL6(val6, "1", ((Entity)val6).Layer);
								val2.AppendEntity((Entity)(object)texto);
								DeclaracoesGeral.bAnularEventos = true;
								topTransaction.AddNewlyCreatedDBObject((DBObject)(object)texto, true);
								XDataGeral.gravarXDataTitulo(ref texto, 7, " ");
							}
						}
						finally
						{
							((IDisposable)val6)?.Dispose();
						}
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					throw;
				}
			}
			finally
			{
				((IDisposable)topTransaction)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)database)?.Dispose();
		}
	}

	private static DBText dtepniSZGL6(AttributeReference P_0, string P_1, string P_2)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Invalid comparison between Unknown and I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Invalid comparison between Unknown and I4
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		DBText val = new DBText();
		((Entity)val).Layer = P_2;
		val.TextString = P_1;
		val.TextStyleId = ((DBText)P_0).TextStyleId;
		((Entity)val).ColorIndex = ((Entity)P_0).ColorIndex;
		((Entity)val).LineWeight = ((Entity)P_0).LineWeight;
		val.Height = ((DBText)P_0).Height;
		val.WidthFactor = ((DBText)P_0).WidthFactor;
		val.Position = ((DBText)P_0).Position;
		val.Oblique = ((DBText)P_0).Oblique;
		val.Rotation = ((DBText)P_0).Rotation;
		((Entity)val).Visible = true;
		val.HorizontalMode = ((DBText)P_0).HorizontalMode;
		val.VerticalMode = ((DBText)P_0).VerticalMode;
		if (!(((int)((DBText)P_0).HorizontalMode == 0) & ((int)((DBText)P_0).VerticalMode == 0)))
		{
			val.AlignmentPoint = ((DBText)P_0).AlignmentPoint;
		}
		return val;
	}

	public static void ApagarCamposPaginas()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		try
		{
			Transaction topTransaction = database.TransactionManager.TopTransaction;
			try
			{
				BlockTable val = (BlockTable)topTransaction.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val2 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val)[BlockTableRecord.ModelSpace], (OpenMode)1);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val2.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val3 = (Entity)topTransaction.GetObject(current, (OpenMode)0);
						try
						{
							DBText val4 = (DBText)(object)((val3 is DBText) ? val3 : null);
							try
							{
								if ((DisposableWrapper)(object)val4 != (DisposableWrapper)null)
								{
									DBText text = val4;
									int num = XDataGeral.LeXDataTitulo(ref text);
									if (num > 0)
									{
										((DBObject)val3).UpgradeOpen();
										((DBObject)val3).Erase();
									}
								}
							}
							finally
							{
								((IDisposable)val4)?.Dispose();
							}
						}
						finally
						{
							((IDisposable)val3)?.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
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
		finally
		{
			((IDisposable)database)?.Dispose();
		}
	}

	public static string BuscaProximaPaginaValida(string pagina)
	{
		checked
		{
			int num = Information.UBound(DeclaracoesGeral.mPaginas, 2) - 1;
			for (int i = 1; i <= num; i++)
			{
				if (Operators.ConditionalCompareObjectEqual(DeclaracoesGeral.mPaginas[0, i], pagina, TextCompare: true))
				{
					return Conversions.ToString(DeclaracoesGeral.mPaginas[0, i + 1]);
				}
			}
			return "";
		}
	}

	public static string BuscaAlternativo(string pagina, bool bretornaVazio)
	{
		string text = "";
		int num = Information.UBound(DeclaracoesGeral.mPaginas, 2);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Operators.ConditionalCompareObjectEqual(DeclaracoesGeral.mPaginas[0, i], pagina, TextCompare: true))
			{
				text = Conversions.ToString(DeclaracoesGeral.mPaginas[4, i]);
				break;
			}
		}
		if (!bretornaVazio & (Operators.CompareString(text, "", TextCompare: true) == 0))
		{
			text = pagina;
		}
		return text;
	}

	public static int localizaPaginaMatriz(string sLayer)
	{
		int num = Information.UBound(DeclaracoesGeral.mPaginas, 2);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Operators.ConditionalCompareObjectEqual(DeclaracoesGeral.mPaginas[0, i], sLayer, TextCompare: true))
			{
				return i;
			}
		}
		return 0;
	}

	public static bool AtivaPagina(string pagina)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected Obj, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		try
		{
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				try
				{
					Transaction val2 = database.TransactionManager.StartTransaction();
					try
					{
						LayerTable val3 = (LayerTable)val2.GetObject(database.LayerTableId, (OpenMode)0);
						try
						{
							SymbolTableEnumerator enumerator = default;
							try
							{
								enumerator = val3.GetEnumerator();
								while (enumerator.MoveNext())
								{
									ObjectId current = enumerator.Current;
									LayerTableRecord val4 = (LayerTableRecord)val2.GetObject(current, (OpenMode)1);
									try
									{
										string right = (checaCapa(pagina) ? pagina : "-1");
										if (Operators.CompareString(((SymbolTableRecord)val4).Name, pagina, TextCompare: true) != 0)
										{
											if (!((Operators.CompareString(((SymbolTableRecord)val4).Name, "0", TextCompare: true) == 0) | (Operators.CompareString(((SymbolTableRecord)val4).Name, right, TextCompare: true) == 0)))
											{
												val4.IsOff = true;
											}
											else
											{
												val4.IsOff = false;
											}
										}
										else
										{
											val4.IsOff = false;
											database.Clayer = ((SymbolTable)val3)[pagina];
											DeclaracoesGeral.ativo.Pagina = pagina;
										}
									}
									finally
									{
										((IDisposable)val4)?.Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)enumerator)?.Dispose();
							}
						}
						finally
						{
							((IDisposable)val3)?.Dispose();
						}
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
						Application.UpdateScreen();
						result = true;
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
					((IDisposable)database)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static string LocalizaPaginaAtiva()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		string result = "";
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		try
		{
			Transaction val = database.TransactionManager.StartTransaction();
			try
			{
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				ObjectId layerTableId = mdiActiveDocument.Database.LayerTableId;
				_ = (LayerTable)layerTableId.GetObject((OpenMode)0);
				LayerTableRecord val2 = (LayerTableRecord)val.GetObject(database.Clayer, (OpenMode)0);
				result = ((SymbolTableRecord)val2).Name;
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				result = retornaNumeroCapa();
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)database)?.Dispose();
		}
		return result;
	}

	public static void AtualizaContTotFl()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			try
			{
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
							try
							{
								DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
								try
								{
									if (!((DisposableWrapper)(object)val6 != (DisposableWrapper)null))
									{
										continue;
									}
									string text = "";
									string text2 = "";
									DBText text3 = val6;
									switch (XDataGeral.LeXDataTitulo(ref text3))
									{
									case 9:
										((DBObject)val6).UpgradeOpen();
										val6.TextString = BuscaAlternativo(((Entity)val6).Layer, bretornaVazio: true);
										break;
									case 5:
										((DBObject)val6).UpgradeOpen();
										text = BuscaProximaPaginaValida(((Entity)val6).Layer);
										if (!((DeclaracoesGeral.Conf.incluirColuna == 3) | (DeclaracoesGeral.Conf.incluirColuna == 4) | (DeclaracoesGeral.Conf.incluirColuna == 5)))
										{
											val6.TextString = text;
											break;
										}
										text2 = BuscaAlternativo(text, bretornaVazio: true);
										if (Operators.CompareString(text2, "", TextCompare: true) == 0)
										{
											val6.TextString = text;
										}
										else
										{
											val6.TextString = text2;
										}
										break;
									case 6:
										if (Operators.CompareString(((Entity)val6).Layer.ToString(), val6.TextString, TextCompare: true) != 0)
										{
											((DBObject)val6).UpgradeOpen();
											val6.TextString = ((Entity)val6).Layer.ToString();
										}
										break;
									case 7:
										((DBObject)val6).UpgradeOpen();
										text = Conversions.ToString(DeclaracoesGeral.mPaginas[0, Information.UBound(DeclaracoesGeral.mPaginas, 2)]);
										if (!((DeclaracoesGeral.Conf.incluirColuna == 3) | (DeclaracoesGeral.Conf.incluirColuna == 4) | (DeclaracoesGeral.Conf.incluirColuna == 5)))
										{
											val6.TextString = text;
											break;
										}
										text2 = BuscaAlternativo(text, bretornaVazio: true);
										if (Operators.CompareString(text2, "", TextCompare: true) == 0)
										{
											val6.TextString = text;
										}
										else
										{
											val6.TextString = text2;
										}
										break;
									case 8:
										break;
									}
								}
								finally
								{
									((IDisposable)val6)?.Dispose();
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
				((IDisposable)database)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void AtualizaTitulosDeUmaPagina(DeclaracoesGeral.tPagina pag)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				try
				{
					Transaction val2 = database.TransactionManager.StartTransaction();
					try
					{
						BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
						BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
						int num = 0;
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
									if (Operators.CompareString(val5.Layer.ToString(), pag.Pagina, TextCompare: true) == 0)
									{
										DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
										try
										{
											if ((DisposableWrapper)(object)val6 != (DisposableWrapper)null)
											{
												DBText text = val6;
												switch (XDataGeral.LeXDataTitulo(ref text))
												{
												case 4:
													((DBObject)val6).UpgradeOpen();
													val6.TextString = pag.Titulo4;
													text = val6;
													XDataGeral.gravarXDataTitulo(ref text, 4, pag.Titulo4);
													num++;
													break;
												case 1:
													((DBObject)val6).UpgradeOpen();
													val6.TextString = pag.Titulo1;
													text = val6;
													XDataGeral.gravarXDataTitulo(ref text, 1, pag.Titulo1);
													num++;
													break;
												case 2:
													((DBObject)val6).UpgradeOpen();
													val6.TextString = pag.Titulo2;
													text = val6;
													XDataGeral.gravarXDataTitulo(ref text, 2, pag.Titulo2);
													num++;
													break;
												case 3:
													((DBObject)val6).UpgradeOpen();
													val6.TextString = pag.Titulo3;
													text = val6;
													XDataGeral.gravarXDataTitulo(ref text, 3, pag.Titulo3);
													num++;
													break;
												}
											}
										}
										finally
										{
											((IDisposable)val6)?.Dispose();
										}
									}
									if (num != 4)
									{
										continue;
									}
								}
								finally
								{
									((IDisposable)val5)?.Dispose();
								}
								break;
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
					((IDisposable)database)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void AtualizaTitulos()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			try
			{
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
							try
							{
								DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
								try
								{
									if (!((DisposableWrapper)(object)val6 != (DisposableWrapper)null))
									{
										continue;
									}
									DBText text = val6;
									int num = XDataGeral.LeXDataTitulo(ref text);
									if (!(((num > 0) & (num < 5)) | (num == 9)))
									{
										continue;
									}
									string text2 = "";
									int num2 = Information.UBound(DeclaracoesGeral.mTitulos, 2);
									for (int i = 1; i <= num2; i = checked(i + 1))
									{
										if (Operators.ConditionalCompareObjectEqual(DeclaracoesGeral.mTitulos[0, i], ((Entity)val6).Layer, TextCompare: true))
										{
											text2 = ((num == 9) ? Conversions.ToString(DeclaracoesGeral.mTitulos[6, i]) : Conversions.ToString(DeclaracoesGeral.mTitulos[num, i]));
											((DBObject)val6).UpgradeOpen();
											val6.TextString = text2;
											text = val6;
											XDataGeral.gravarXDataTitulo(ref text, num, text2);
											break;
										}
									}
								}
								finally
								{
									((IDisposable)val6)?.Dispose();
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
				((IDisposable)database)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static string CriarLayer(string layer, string unidade, string vao)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		string result = "0";
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					string text = montaNumeroPagina(layer);
					LayerTable val3 = (LayerTable)val2.GetObject(database.LayerTableId, (OpenMode)0);
					if (!((SymbolTable)val3).Has(text))
					{
						LayerTableRecord layer2 = new LayerTableRecord();
						((SymbolTableRecord)layer2).Name = text;
						((DBObject)val3).UpgradeOpen();
						((SymbolTable)val3).Add((SymbolTableRecord)(object)layer2);
						XDataGeral.GravarXDataUnidadeAlternativo(ref layer2, unidade, vao);
						result = text;
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)layer2, true);
					}
					else
					{
						result = "-1";
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					result = "0";
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
				((IDisposable)database)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return result;
	}

	public static string montaNumeroPagina(string layer)
	{
		string text = layer.Trim();
		while (Operators.CompareString(Strings.Mid(text, 1, 1), "0", TextCompare: true) == 0)
		{
			text = Strings.Mid(text, 2);
		}
		checked
		{
			if (DeclaracoesGeral.Conf.LarguraFixaPaginas != 0 && !(Versioned.IsNumeric(layer) & (Strings.Len(text) >= DeclaracoesGeral.Conf.LarguraFixaPaginas)) && Strings.Len(text) <= DeclaracoesGeral.Conf.LarguraFixaPaginas)
			{
				int num = DeclaracoesGeral.Conf.LarguraFixaPaginas - Strings.Len(text);
				if (!Versioned.IsNumeric(text))
				{
					num++;
				}
				text = Strings.StrDup(num, "0") + text;
			}
			return text;
		}
	}

	public static bool renumerarPagina(string PagOld, string PagNova)
	{
		bool result = false;
		int num = Information.UBound(DeclaracoesGeral.mPaginas, 2);
		int num2 = 1;
		while (true)
		{
			if (num2 <= num)
			{
				if (!Operators.ConditionalCompareObjectEqual(DeclaracoesGeral.mPaginas[0, num2], PagNova, TextCompare: true))
				{
					num2 = checked(num2 + 1);
					continue;
				}
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 28]), MsgBoxStyle.Information);
				break;
			}
			try
			{
				if (!alteraNomeLayer(PagOld, PagNova))
				{
					break;
				}
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				try
				{
					_ = Application.DocumentManager.MdiActiveDocument.Editor;
					Transaction val = database.TransactionManager.StartTransaction();
					try
					{
						int num3 = localizaPaginaMatriz(PagOld);
						DeclaracoesGeral.mPaginas[0, num3] = PagNova;
						DeclaracoesGeral.mPaginas[1, num3] = calculaPaginaDecimal(PagNova);
						OrdenaMatrizPaginas();
						AtualizaContTotFl();
						result = true;
						DeclaracoesGeral.bAnularEventos = true;
						val.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					finally
					{
						((IDisposable)val)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)database)?.Dispose();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
				ProjectData.ClearProjectError();
			}
			break;
		}
		return result;
	}

	public static bool alteraNomeLayer(string antigo, string novo)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected Obj, but got Unknown
		bool result = false;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					LayerTable val3 = (LayerTable)val2.GetObject(database.LayerTableId, (OpenMode)0);
					try
					{
						if (((SymbolTable)val3).Has(antigo))
						{
							ObjectId val4 = ((SymbolTable)val3)[antigo];
							LayerTableRecord val5 = (LayerTableRecord)val2.GetObject(val4, (OpenMode)1);
							((SymbolTableRecord)val5).Name = novo;
							result = true;
							DeclaracoesGeral.bAnularEventos = true;
							val2.Commit();
							DeclaracoesGeral.bAnularEventos = false;
						}
					}
					finally
					{
						((IDisposable)val3)?.Dispose();
					}
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
			}
			finally
			{
				((IDisposable)database)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return result;
	}

	public static bool renumerarPaginasLote(Array mPagSel)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					LayerTable val3 = (LayerTable)val2.GetObject(database.LayerTableId, (OpenMode)0);
					try
					{
						int num = Information.UBound(mPagSel, 2);
						for (int i = 1; i <= num; i = checked(i + 1))
						{
							object[] array = new object[1];
							object[] array2 = new object[2];
							object obj = (array2[0] = 0);
							object obj2 = (array2[1] = i);
							array[0] = NewLateBinding.LateIndexGet(mPagSel, array2, null);
							object[] array3 = array;
							object value = NewLateBinding.LateGet(val3, null, "Has", array, null, null, new bool[1] { true });
							NewLateBinding.LateIndexSetComplex(mPagSel, new object[3]
							{
								obj,
								obj2,
								array3[0]
							}, null, OptimisticSet: true, RValueBase: false);
							if (Conversions.ToBoolean(value))
							{
								ObjectId val4 = ((SymbolTable)val3)[Conversions.ToString(NewLateBinding.LateIndexGet(mPagSel, new object[2] { 0, i }, null))];
								LayerTableRecord val5 = (LayerTableRecord)val2.GetObject(val4, (OpenMode)1);
								try
								{
									((SymbolTableRecord)val5).Name = Conversions.ToString(NewLateBinding.LateIndexGet(mPagSel, new object[2] { 2, i }, null));
								}
								finally
								{
									((IDisposable)val5)?.Dispose();
								}
							}
						}
						CarregaPaginas();
						OrdenaMatrizPaginas();
						AtualizaContTotFl();
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					finally
					{
						((IDisposable)val3)?.Dispose();
					}
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
			}
			finally
			{
				((IDisposable)database)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return true;
	}

	public static void restauraCampos()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			try
			{
				_ = Application.DocumentManager.MdiActiveDocument.Editor;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					_ = ObjectId.Null;
					CarregaPaginas();
					OrdenaMatrizPaginas();
					capturaTitulos();
					Revisao.capturaRevisoesSimplificadas();
					ApagarCamposPaginas();
					criaCamposTOT();
					int num = Information.UBound(DeclaracoesGeral.mPaginas, 2);
					for (int i = 1; i <= num; i = checked(i + 1))
					{
						if (!Operators.ConditionalCompareObjectEqual(DeclaracoesGeral.mPaginas[1, i], 1, TextCompare: true))
						{
							criaCamposFormato("-1", Conversions.ToString(DeclaracoesGeral.mPaginas[0, i]));
						}
						else
						{
							criaCamposFormato(retornaNumeroCapa(), Conversions.ToString(DeclaracoesGeral.mPaginas[0, i]));
						}
					}
					AtualizaTitulos();
					Revisao.AtualizaRevSimplificada();
					CarregaPaginas();
					OrdenaMatrizPaginas();
					AtualizaContTotFl();
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
					ProjectData.ClearProjectError();
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)database)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void ApagarElementosPagina(string Layer)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			try
			{
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
							try
							{
								if (Operators.CompareString(val5.Layer, Layer, TextCompare: true) == 0)
								{
									((DBObject)val5).UpgradeOpen();
									Entity ent = val5;
									clsApagar.ApagarDerivados(ref ent);
									((DBObject)val5).Erase();
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
				((IDisposable)database)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static bool RemoveLayer(string sLayer, bool bAtivaPag = false)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected Obj, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected Obj, but got Unknown
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					database.Clayer = ((SymbolTable)(LayerTable)val2.GetObject(database.LayerTableId, (OpenMode)1, false))["0"];
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
				Transaction val3 = database.TransactionManager.StartTransaction();
				try
				{
					LayerTable val4 = (LayerTable)val3.GetObject(database.LayerTableId, (OpenMode)1);
					try
					{
						SymbolTableEnumerator enumerator = default;
						try
						{
							enumerator = val4.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								LayerTableRecord val5 = (LayerTableRecord)val3.GetObject(current, (OpenMode)1);
								try
								{
									if (Operators.CompareString(((SymbolTableRecord)val5).Name, sLayer, TextCompare: true) != 0)
									{
										continue;
									}
									((DBObject)val5).Erase();
									result = true;
									break;
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
						val3.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					finally
					{
						((IDisposable)val4)?.Dispose();
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					val3.Abort();
					throw;
				}
				finally
				{
					((IDisposable)val3)?.Dispose();
				}
				if (bAtivaPag)
				{
					Transaction val6 = database.TransactionManager.StartTransaction();
					try
					{
						database.Clayer = ((SymbolTable)(LayerTable)val6.GetObject(database.LayerTableId, (OpenMode)1, false))[DeclaracoesGeral.ativo.Pagina];
						DeclaracoesGeral.bAnularEventos = true;
						val6.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					finally
					{
						((IDisposable)val6)?.Dispose();
					}
				}
			}
			finally
			{
				((IDisposable)database)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return result;
	}

	public static void verificaLayerExtraNoFormato(ref DeclaracoesGeral.LayersExtra bLayers)
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected Obj, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected Obj, but got Unknown
		bLayers.bELET1 = false;
		bLayers.sELET1 = "";
		bLayers.bELET2 = false;
		bLayers.sELET2 = "";
		bLayers.bELET3 = false;
		bLayers.sELET3 = "";
		bLayers.bELET4 = false;
		bLayers.sELET4 = "";
		bLayers.bELET5 = false;
		bLayers.sELET5 = "";
		if (!DeclaracoesGeral.blockFormatoID.IsValid)
		{
			return;
		}
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		try
		{
			Transaction val = database.TransactionManager.StartTransaction();
			try
			{
				ObjectId layerTableId = Application.DocumentManager.MdiActiveDocument.Database.LayerTableId;
				LayerTable val2 = (LayerTable)layerTableId.GetObject((OpenMode)0);
				SymbolTableEnumerator enumerator = default;
				try
				{
					enumerator = val2.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						LayerTableRecord val3 = (LayerTableRecord)val.GetObject(current, (OpenMode)0);
						try
						{
							string name = ((SymbolTableRecord)val3).Name;
							if (name.StartsWith("ELET1_"))
							{
								bLayers.bELET1 = true;
								bLayers.sELET1 = name.Remove(0, 6);
							}
							if (name.StartsWith("ELET2_"))
							{
								bLayers.bELET2 = true;
								bLayers.sELET2 = name.Remove(0, 6);
							}
							if (name.StartsWith("ELET3_"))
							{
								bLayers.bELET3 = true;
								bLayers.sELET3 = name.Remove(0, 6);
							}
							if (name.StartsWith("ELET4_"))
							{
								bLayers.bELET4 = true;
								bLayers.sELET4 = name.Remove(0, 6);
							}
							if (name.StartsWith("ELET5_"))
							{
								bLayers.bELET5 = true;
								bLayers.sELET5 = name.Remove(0, 6);
							}
						}
						finally
						{
							((IDisposable)val3)?.Dispose();
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
		finally
		{
			((IDisposable)database)?.Dispose();
		}
	}

	public static void InserirColuna(string sPag, string sTipo)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Obj, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected Obj, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected Obj, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[DeclaracoesGeral.blockFormatoName], (OpenMode)1);
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val6 = (Entity)val2.GetObject(current, (OpenMode)0);
							try
							{
								if (Operators.CompareString(val6.Layer, sTipo, TextCompare: true) == 0)
								{
									Entity val7 = (Entity)((RXObject)val6).Clone();
									val7.Layer = sPag;
									val5.AppendEntity(val7);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val7, true);
									XDataGeral.gravarXDataColuna(val7, sTipo);
								}
							}
							finally
							{
								((IDisposable)val6)?.Dispose();
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
				((IDisposable)database)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void buscaTitulosExistentes(ref DeclaracoesGeral.Titulos tit)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected Obj, but got Unknown
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		try
		{
			Transaction val = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
				try
				{
					DBObject val3 = val.GetObject(DeclaracoesGeral.blockFormatoID, (OpenMode)0);
					BlockReference val4 = (BlockReference)(object)((val3 is BlockReference) ? val3 : null);
					AttributeCollection attributeCollection = val4.AttributeCollection;
					foreach (object item in attributeCollection)
					{
						ObjectId val5 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						AttributeReference val6 = (AttributeReference)val.GetObject(val5, (OpenMode)0);
						try
						{
							if (Operators.CompareString(((Entity)val6).Layer, "-1", TextCompare: true) != 0)
							{
								continue;
							}
							string left = val6.Tag.ToUpper();
							if (Operators.CompareString(left, "TITULO1PAG", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "TITULO2PAG", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left, "TITULO3PAG", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left, "TITULO4PAG", TextCompare: true) == 0 || Operators.CompareString(left, "PAINEL", TextCompare: true) == 0)
										{
											tit.bTitulo4 = true;
										}
									}
									else
									{
										tit.bTitulo3 = true;
									}
								}
								else
								{
									tit.bTitulo2 = true;
								}
							}
							else
							{
								tit.bTitulo1 = true;
							}
						}
						finally
						{
							((IDisposable)val6)?.Dispose();
						}
					}
					DeclaracoesGeral.bAnularEventos = true;
					val.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					val.Abort();
					throw;
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)database)?.Dispose();
		}
	}

	public static bool checaCapa(string pagina)
	{
		bool result = false;
		if ((Operators.CompareString(pagina, "1", TextCompare: true) == 0) | (Operators.CompareString(pagina, "001", TextCompare: true) == 0) | (Operators.CompareString(pagina, "0001", TextCompare: true) == 0) | (Operators.CompareString(pagina, "00001", TextCompare: true) == 0) | (Operators.CompareString(pagina, "000001", TextCompare: true) == 0) | (Operators.CompareString(pagina, "0000001", TextCompare: true) == 0))
		{
			result = true;
		}
		return result;
	}

	public static string retornaNumeroCapa()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected Obj, but got Unknown
		string result = "";
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		try
		{
			Transaction val = database.TransactionManager.StartTransaction();
			try
			{
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				ObjectId val2 = mdiActiveDocument.Database.LayerTableId;
				LayerTable val3 = (LayerTable)val2.GetObject((OpenMode)0);
				SymbolTableEnumerator enumerator = val3.GetEnumerator();
				while (enumerator.MoveNext())
				{
					val2 = enumerator.Current;
					LayerTableRecord val4 = (LayerTableRecord)val2.GetObject((OpenMode)0);
					if (checaCapa(((SymbolTableRecord)val4).Name))
					{
						result = ((SymbolTableRecord)val4).Name;
						break;
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
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
		finally
		{
			((IDisposable)database)?.Dispose();
		}
		return result;
	}

	public static void redefinePasso()
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Invalid comparison between Unknown and I4
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		PromptIntegerOptions val = new PromptIntegerOptions(Conversions.ToString(Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 143])));
		((PromptNumericalOptions)val).AllowNegative = false;
		((PromptNumericalOptions)val).AllowZero = false;
		val.DefaultValue = DeclaracoesGeral.Conf.PassoPagina;
		((PromptNumericalOptions)val).UseDefaultValue = true;
		PromptIntegerResult integer = editor.GetInteger(val);
		if ((int)((PromptResult)integer).Status == 5100)
		{
			DeclaracoesGeral.Conf.PassoPagina = integer.Value;
			XDataGeral.GravarXDataConfiguracao();
		}
	}

	public static bool criarUmaNovaPagina()
	{
		bool result = false;
		try
		{
			DeclaracoesGeral.tPagina pag = default;
			DeclaracoesGeral.tPagina pagPost = default;
			DeclaracoesGeral.tPagina pagCorrente = default;
			pag.Pagina = DeclaracoesGeral.ativo.Pagina;
			pagCorrente.Unidade = "";
			pagCorrente.Alternativo = "";
			capturaTitulosDeUmaPagina(ref pag);
			pagCorrente.Pagina = "";
			capturaTitulos();
			if (!Operators.ConditionalCompareObjectEqual(DeclaracoesGeral.mTitulos[0, Information.UBound(DeclaracoesGeral.mTitulos, 2)], DeclaracoesGeral.ativo.Pagina, TextCompare: true))
			{
				pagPost.Pagina = BuscaProximaPaginaValida(DeclaracoesGeral.ativo.Pagina);
			}
			else
			{
				pagPost.Pagina = "1000000";
			}
			calculaNovaPagina(ref pag, ref pagCorrente, ref pagPost);
			if (Conversions.ToDouble(pagCorrente.PgNum) != 0.0)
			{
				string text = (pagCorrente.Pagina = CriarLayer(pagCorrente.Pagina, pagCorrente.Unidade, pagCorrente.Alternativo));
				if (Operators.CompareString(text, "-1", TextCompare: true) != 0)
				{
					if (Operators.CompareString(text, "0", TextCompare: true) != 0)
					{
						CarregaPaginas();
						OrdenaMatrizPaginas();
						criaCamposFormato("-1", text);
						AtualizaContTotFl();
						AtivaPagina(text);
						pagCorrente.Titulo1 = pag.Titulo1;
						pagCorrente.Titulo2 = pag.Titulo2;
						pagCorrente.Titulo3 = pag.Titulo3;
						pagCorrente.Titulo4 = pag.Titulo4;
						AtualizaTitulosDeUmaPagina(pagCorrente);
						result = true;
					}
					else
					{
						Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 33]), MsgBoxStyle.Information, "Elétron");
					}
				}
				else
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 32]), MsgBoxStyle.Information, "Elétron");
				}
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 31]), MsgBoxStyle.Information, "Elétron");
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		return result;
	}

	public static string EncontraProximaPagina(string pagina)
	{
		string result = Conversions.ToString(1);
		bool flag = false;
		checked
		{
			int num = Information.UBound(DeclaracoesGeral.mPaginas, 2) - 1;
			for (int i = 1; i <= num; i++)
			{
				if (Operators.ConditionalCompareObjectEqual(DeclaracoesGeral.mPaginas[0, i], pagina, TextCompare: true))
				{
					result = Conversions.ToString(DeclaracoesGeral.mPaginas[0, i + 1]);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				result = Conversions.ToString(DeclaracoesGeral.mPaginas[0, Information.UBound(DeclaracoesGeral.mPaginas, 2)]);
			}
			return result;
		}
	}

	public static string calculaLinhaColuna(ref Entity ent, ref DeclaracoesGeral.Reguas rH, ref DeclaracoesGeral.Reguas rv, bool bH, bool bV)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		Entity obj = ent;
		BlockReference val = (BlockReference)(object)((obj is BlockReference) ? obj : null);
		Point3d val2;
		double x = default;
		double y = default;
		if ((DisposableWrapper)(object)val != (DisposableWrapper)null)
		{
			val2 = val.Position;
			x = val2.X;
			val2 = val.Position;
			y = val2.Y;
		}
		Entity obj2 = ent;
		DBText val3 = (DBText)(object)((obj2 is DBText) ? obj2 : null);
		if ((DisposableWrapper)(object)val3 != (DisposableWrapper)null)
		{
			val2 = val3.Position;
			x = val2.X;
			val2 = val3.Position;
			y = val2.Y;
			if ((x == 0.0) & (y == 0.0))
			{
				val2 = val3.AlignmentPoint;
				x = val2.X;
				val2 = val3.AlignmentPoint;
				y = val2.Y;
			}
		}
		checked
		{
			if ((DeclaracoesGeral.Conf.incluirColuna == 1) | (DeclaracoesGeral.Conf.incluirColuna == 2) | (DeclaracoesGeral.Conf.incluirColuna == 4) | (DeclaracoesGeral.Conf.incluirColuna == 5))
			{
				int num = default;
				if (bH)
				{
					num = (int)Conversion.Int((x - rH.Pti.X) / rH.Delta);
					num += Conversions.ToInteger(rH.Inicio);
				}
				int num2 = default;
				if (bV)
				{
					if (Operators.CompareString(rv.Inicio, rv.Fim, TextCompare: true) >= 0)
					{
						double value = (rv.Pti.Y - y) / rv.Delta;
						num2 = (int)Math.Round(Math.Round(value, 0));
					}
					else
					{
						num2 = (int)Conversion.Int((rv.Pti.Y - y) / rv.Delta);
					}
					if (Conversions.ToInteger(rv.Inicio) >= Conversions.ToInteger(rv.Fim))
					{
						num2 = Conversions.ToInteger(rv.Fim) - num2;
						if (num2 <= 65)
						{
							num2 = (int)Conversion.Int((rv.Pti.Y - y) / rv.Delta);
							num2 = (int)Math.Round(Conversions.ToDouble(rv.Inicio) - (double)num2);
						}
					}
					else
					{
						num2 += Conversions.ToInteger(rv.Inicio);
					}
				}
				switch (DeclaracoesGeral.Conf.incluirColuna)
				{
				case 1:
				case 2:
				case 5:
					if (bH)
					{
						text += Conversions.ToString(num);
					}
					if (bV)
					{
						text += Strings.Trim(Conversions.ToString(Strings.Chr(num2)));
					}
					break;
				case 4:
					if (bV)
					{
						text += Strings.Trim(Conversions.ToString(Strings.Chr(num2)));
					}
					if (bH)
					{
						text += Conversions.ToString(num);
					}
					break;
				}
			}
			return text;
		}
	}

	public static string montaCruzamentoPagina(string pagina, string posicao)
	{
		string text = "";
		switch (DeclaracoesGeral.Conf.incluirColuna)
		{
		case 6:
		{
			string unidade2 = "";
			string alternativo2 = "";
			XDataGeral.LeXDataUnidadeAlternativo2(ref pagina, ref unidade2, ref alternativo2);
			text = DeclaracoesGeral.Conf.PrefixoCruzInterno + pagina + DeclaracoesGeral.Conf.SufixoCruzInterno;
			if (Operators.CompareString(alternativo2.Trim(), "", TextCompare: true) != 0)
			{
				text = text + DeclaracoesGeral.Conf.SeparadorCruzamento + alternativo2;
			}
			break;
		}
		case 0:
			text = DeclaracoesGeral.Conf.PrefixoCruzInterno + pagina + DeclaracoesGeral.Conf.SufixoCruzInterno;
			break;
		case 1:
			text = DeclaracoesGeral.Conf.PrefixoCruzInterno + pagina + DeclaracoesGeral.Conf.SeparadorCruzamento + posicao + DeclaracoesGeral.Conf.SufixoCruzInterno;
			break;
		case 2:
			text = DeclaracoesGeral.Conf.PrefixoCruzInterno + posicao + DeclaracoesGeral.Conf.SeparadorCruzamento + pagina + DeclaracoesGeral.Conf.SufixoCruzInterno;
			break;
		case 3:
		{
			string unidade4 = "";
			string alternativo4 = "";
			XDataGeral.LeXDataUnidadeAlternativo2(ref pagina, ref unidade4, ref alternativo4);
			text = ((Operators.CompareString(alternativo4.Trim(), "", TextCompare: true) != 0) ? (DeclaracoesGeral.Conf.PrefixoCruzInterno + alternativo4 + DeclaracoesGeral.Conf.SufixoCruzInterno) : (DeclaracoesGeral.Conf.PrefixoCruzInterno + pagina + DeclaracoesGeral.Conf.SufixoCruzInterno));
			break;
		}
		case 4:
		{
			string unidade3 = "";
			string alternativo3 = "";
			XDataGeral.LeXDataUnidadeAlternativo2(ref pagina, ref unidade3, ref alternativo3);
			text = ((Operators.CompareString(alternativo3.Trim(), "", TextCompare: true) != 0) ? (DeclaracoesGeral.Conf.PrefixoCruzInterno + alternativo3 + DeclaracoesGeral.Conf.SeparadorCruzamento + posicao + DeclaracoesGeral.Conf.SufixoCruzInterno) : (DeclaracoesGeral.Conf.PrefixoCruzInterno + pagina + DeclaracoesGeral.Conf.SeparadorCruzamento + posicao + DeclaracoesGeral.Conf.SufixoCruzInterno));
			break;
		}
		case 5:
		{
			string unidade = "";
			string alternativo = "";
			XDataGeral.LeXDataUnidadeAlternativo2(ref pagina, ref unidade, ref alternativo);
			text = ((Operators.CompareString(alternativo.Trim(), "", TextCompare: true) != 0) ? (DeclaracoesGeral.Conf.PrefixoCruzInterno + alternativo + DeclaracoesGeral.Conf.SeparadorCruzamento + posicao + DeclaracoesGeral.Conf.SufixoCruzInterno) : (DeclaracoesGeral.Conf.PrefixoCruzInterno + pagina + DeclaracoesGeral.Conf.SeparadorCruzamento + posicao + DeclaracoesGeral.Conf.SufixoCruzInterno));
			break;
		}
		}
		return text;
	}

	public static void TrocaColunas()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected Obj, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected Obj, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected Obj, but got Unknown
		string[,] array = new string[2, 1];
		bool flag = true;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		checked
		{
			try
			{
				Transaction val = database.TransactionManager.StartTransaction();
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
							Entity val4 = (Entity)val.GetObject(current, (OpenMode)0);
							try
							{
								string text = XDataGeral.verificaXDataColunas(val4);
								if (Operators.CompareString(text, "0", TextCompare: true) == 0)
								{
									continue;
								}
								flag = true;
								long num = Information.UBound(array, 2);
								for (long num2 = 1L; num2 <= num; num2++)
								{
									if (Operators.CompareString(array[0, (int)num2], val4.Layer, TextCompare: true) == 0 && Operators.CompareString(array[1, (int)num2].ToString(), text, TextCompare: true) == 0)
									{
										flag = false;
										break;
									}
								}
								if (flag)
								{
									array = (string[,])Utils.CopyArray(array, new string[2, Information.UBound(array, 2) + 1 + 1]);
									array[0, Information.UBound(array, 2)] = val4.Layer;
									array[1, Information.UBound(array, 2)] = text;
								}
								((DBObject)val4).UpgradeOpen();
								((DBObject)val4).Erase();
							}
							finally
							{
								((IDisposable)val4)?.Dispose();
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
			finally
			{
				((IDisposable)database)?.Dispose();
			}
			if (Information.UBound(array, 2) > 0)
			{
				long num3 = Information.UBound(array, 2);
				for (long num4 = 1L; num4 <= num3; num4++)
				{
					InserirColuna(array[0, (int)num4], array[1, (int)num4]);
				}
			}
		}
	}

	public static void AtualizaRevSimplificada(string sPagina, string sValor)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			try
			{
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
							try
							{
								if (Operators.CompareString(sPagina, val5.Layer, TextCompare: true) != 0)
								{
									continue;
								}
								DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
								try
								{
									if ((DisposableWrapper)(object)val6 != (DisposableWrapper)null)
									{
										DBText text = val6;
										int num = XDataGeral.LeXDataTitulo(ref text);
										if (num == 8)
										{
											((DBObject)val6).UpgradeOpen();
											val6.TextString = sValor;
										}
									}
								}
								finally
								{
									((IDisposable)val6)?.Dispose();
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
				((IDisposable)database)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}
}
