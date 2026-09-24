using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.Runtime;
using ZwSoft.ZwCAD.Windows;

namespace Eletron4;

public class clsRegua
{
	public static bool insereReguaH()
	{
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		DeclaracoesGeral.Reguas Rg = new DeclaracoesGeral.Reguas
		{
			Cor = 7,
			Espessura = Conversions.ToString(3),
			Inicio = "1",
			Fim = "10",
			AltBase = 35.0
		};
		if (!Caderno.ExisteFormato())
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 76]), MsgBoxStyle.Critical);
			goto IL_0069;
		}
		if (CapturaDadosDaRegua(ref Rg, "H"))
		{
			Caderno.ApagaDefinicaoReferencias("ReguaH");
			ObjectId val = CriarDefinicaoReguaHorizontal(ref Rg);
			if (!(val == ObjectId.Null))
			{
				InsereRegua(Rg, val);
				redefineAlturaBase();
				Application.UpdateScreen();
				result = true;
				goto IL_0069;
			}
		}
		goto IL_00c4;
		IL_00c4:
		return result;
		IL_0069:
		Application.DocumentManager.MdiActiveDocument.Editor.Regen();
		goto IL_00c4;
	}

	public static void insereReguaV()
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.Reguas Rg = new DeclaracoesGeral.Reguas
		{
			Cor = 7,
			Espessura = Conversions.ToString(3),
			Inicio = "A",
			Fim = "F"
		};
		if (!Caderno.ExisteFormato())
		{
			Interaction.MsgBox("Formato não encontrado! ", MsgBoxStyle.Critical);
		}
		else
		{
			if (!CapturaDadosDaRegua(ref Rg, "V"))
			{
				return;
			}
			Caderno.ApagaDefinicaoReferencias("ReguaV");
			ObjectId val = CriarDefinicaoReguaVertical(ref Rg);
			if (val == ObjectId.Null)
			{
				return;
			}
			InsereRegua(Rg, val);
			Application.UpdateScreen();
		}
		Application.DocumentManager.MdiActiveDocument.Editor.Regen();
	}

	public static bool CapturaDadosDaRegua(ref DeclaracoesGeral.Reguas Rg, string tipo)
	{
		//IL_05ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0605: Expected Obj, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected Obj, but got Unknown
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Expected Obj, but got Unknown
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Invalid comparison between Unknown and I4
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_0410: Expected Obj, but got Unknown
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Invalid comparison between Unknown and I4
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected Obj, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Invalid comparison between Unknown and I4
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Invalid comparison between Unknown and I4
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected Obj, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Invalid comparison between Unknown and I4
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Expected Obj, but got Unknown
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Invalid comparison between Unknown and I4
		//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c9: Invalid comparison between Unknown and I4
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		try
		{
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			PromptKeywordOptions val = new PromptKeywordOptions("");
			((PromptOptions)val).Message = Conversions.ToString(Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 77]));
			((PromptOptions)val).Keywords.Add(Conversions.ToString(DeclaracoesGeral.mMensagem[1, 19]));
			((PromptOptions)val).Keywords.Add(Conversions.ToString(DeclaracoesGeral.mMensagem[1, 20]));
			val.AllowNone = false;
			val.AllowArbitraryInput = false;
			((PromptOptions)val).Keywords.Default = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 19]);
			Rg.Visivel = false;
			PromptResult keywords = editor.GetKeywords(val);
			if (Operators.ConditionalCompareObjectEqual(keywords.StringResult, DeclaracoesGeral.mMensagem[1, 19], TextCompare: true))
			{
				Rg.Visivel = true;
				goto IL_00fa;
			}
			if (Operators.ConditionalCompareObjectEqual(keywords.StringResult, DeclaracoesGeral.mMensagem[1, 20], TextCompare: true))
			{
				Rg.Visivel = false;
				goto IL_00fa;
			}
			result = false;
			goto end_IL_0002;
			IL_0197:
			while (true)
			{
				PromptPointResult val2 = (PromptPointResult)NewLateBinding.LateGet(editor, null, "GetPoint", new object[1] { Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 85]) }, null, null, null);
				if ((int)((PromptResult)val2).Status == -5002)
				{
					break;
				}
				Rg.Pti = val2.Value;
				PromptPointResult val3 = (PromptPointResult)NewLateBinding.LateGet(editor, null, "GetPoint", new object[1] { Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 86]) }, null, null, null);
				if ((int)((PromptResult)val3).Status == -5002)
				{
					break;
				}
				Rg.Ptf = val3.Value;
				if (Operators.CompareString(tipo, "H", TextCompare: true) != 0)
				{
					if (Operators.CompareString(tipo, "V", TextCompare: true) == 0 && Rg.Ptf.Y >= Rg.Pti.Y)
					{
						Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 88]), MsgBoxStyle.Information, "Elétron");
						continue;
					}
				}
				else if (Rg.Ptf.X <= Rg.Pti.X)
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 87]), MsgBoxStyle.Information, "Elétron");
					continue;
				}
				result = true;
				break;
			}
			goto end_IL_0002;
			IL_04fa:
			PromptResult val4;
			Rg.Fim = val4.StringResult.ToUpper();
			result = true;
			if (Rg.Visivel)
			{
				goto IL_012d;
			}
			goto IL_0197;
			IL_012d:
			PromptIntegerOptions val5 = new PromptIntegerOptions(Conversions.ToString(Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 84])));
			((PromptNumericalOptions)val5).AllowNegative = false;
			((PromptNumericalOptions)val5).AllowZero = false;
			val5.DefaultValue = Conversions.ToInteger(Rg.Espessura);
			((PromptNumericalOptions)val5).UseDefaultValue = true;
			PromptIntegerResult integer = editor.GetInteger(val5);
			if ((int)((PromptResult)integer).Status == 5100)
			{
				Rg.Espessura = Conversions.ToString(integer.Value);
			}
			goto IL_0197;
			IL_00fa:
			if (Rg.Visivel)
			{
				Rg.Cor = NHsTD1aldu();
			}
			if (Operators.CompareString(tipo, "H", TextCompare: true) != 0)
			{
				if (Operators.CompareString(tipo, "V", TextCompare: true) != 0)
				{
					goto IL_012d;
				}
				PromptStringOptions val6 = new PromptStringOptions(Conversions.ToString(Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 81])));
				val6.AllowSpaces = false;
				val6.DefaultValue = Rg.Inicio;
				val6.UseDefaultValue = true;
				PromptResult val7 = editor.GetString(val6);
				if ((int)val7.Status == 5100 && Strings.Len(val7.StringResult) <= 1)
				{
					Rg.Inicio = val7.StringResult.ToUpper();
					((PromptOptions)val6).Message = Conversions.ToString(Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 82]));
					val6.AllowSpaces = false;
					val6.DefaultValue = Rg.Fim;
					val6.UseDefaultValue = true;
					while (true)
					{
						val4 = editor.GetString(val6);
						if ((int)val4.Status == 5100 && Strings.Len(val4.StringResult) <= 1)
						{
							if (Operators.CompareString(val4.ToString(), val7.ToString(), TextCompare: true) == 0)
							{
								Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 83]), MsgBoxStyle.Information, "Elétron");
								continue;
							}
							goto IL_04fa;
						}
						break;
					}
				}
			}
			else
			{
				PromptIntegerOptions val8 = new PromptIntegerOptions(Conversions.ToString(Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 78])));
				((PromptNumericalOptions)val8).AllowNegative = false;
				((PromptNumericalOptions)val8).AllowZero = true;
				val8.DefaultValue = Conversions.ToInteger(Rg.Inicio);
				((PromptNumericalOptions)val8).UseDefaultValue = true;
				PromptIntegerResult integer2 = editor.GetInteger(val8);
				if ((int)((PromptResult)integer2).Status == 5100)
				{
					Rg.Inicio = integer2.Value.ToString();
					((PromptOptions)val8).Message = Conversions.ToString(Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 79]));
					((PromptNumericalOptions)val8).AllowNegative = false;
					((PromptNumericalOptions)val8).AllowZero = false;
					val8.DefaultValue = Conversions.ToInteger(Rg.Fim);
					((PromptNumericalOptions)val8).UseDefaultValue = true;
					PromptIntegerResult integer3;
					while (true)
					{
						integer3 = editor.GetInteger(val8);
						if ((int)((PromptResult)integer3).Status == 5100)
						{
							if (integer3.Value >= integer2.Value)
							{
								break;
							}
							Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 80]), MsgBoxStyle.Information, "Elétron");
							continue;
						}
						throw new Exception((ErrorStatus)1, "");
					}
					Rg.Fim = integer3.Value.ToString();
					result = true;
					if (Rg.Visivel)
					{
						goto IL_012d;
					}
					goto IL_0197;
				}
			}
			end_IL_0002:;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static short NHsTD1aldu()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected Obj, but got Unknown
		ColorDialog val = new ColorDialog();
		DialogResult dialogResult = val.ShowDialog();
		if (dialogResult != DialogResult.OK)
		{
			return 7;
		}
		return val.Color.ColorIndex;
	}

	public static void redefineAlturaBase()
	{
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected Obj, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected Obj, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Invalid comparison between Unknown and I4
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.Reguas RH = default;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			if (((SymbolTable)val2).Has("ReguaH"))
			{
				BlockTableRecord novaRegua = (BlockTableRecord)val.GetObject(((SymbolTable)val2)["ReguaH"], (OpenMode)1);
				if (XDataGeral.LeXDataReguaH(ref RH))
				{
					Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
					PromptPointResult val3 = (PromptPointResult)NewLateBinding.LateGet(editor, null, "GetPoint", new object[1] { Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 89]) }, null, null, null);
					if ((int)((PromptResult)val3).Status != -5002)
					{
						Point3d value = val3.Value;
						RH.AltBase = value.Y;
						XDataGeral.gravarXDataReguaH(ref novaRegua, RH);
					}
				}
			}
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			val.Abort();
			throw;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static ObjectId CriarDefinicaoReguaHorizontal(ref DeclaracoesGeral.Reguas Rg)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Expected Obj, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected Obj, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected Obj, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected Obj, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected Obj, but got Unknown
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected Obj, but got Unknown
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected Obj, but got Unknown
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected Obj, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		ObjectId result = ObjectId.Null;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord novaRegua = new BlockTableRecord();
				((SymbolTableRecord)novaRegua).Name = "ReguaH";
				((DBObject)val2).UpgradeOpen();
				((SymbolTable)val2).Add((SymbolTableRecord)(object)novaRegua);
				DeclaracoesGeral.bAnularEventos = true;
				val.AddNewlyCreatedDBObject((DBObject)(object)novaRegua, true);
				Line val3 = new Line();
				((Entity)val3).ColorIndex = Rg.Cor;
				((Entity)val3).Layer = "0";
				val3.StartPoint = new Point3d(0.0, 0.0 - Conversions.ToDouble(Rg.Espessura), 0.0);
				val3.EndPoint = new Point3d(Rg.Ptf.X - Rg.Pti.X, 0.0 - Conversions.ToDouble(Rg.Espessura), 0.0);
				novaRegua.AppendEntity((Entity)(object)val3);
				DeclaracoesGeral.bAnularEventos = true;
				val.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
				((Entity)val3).Visible = Rg.Visivel;
				int num = Conversions.ToInteger(Rg.Fim) - Conversions.ToInteger(Rg.Inicio) + 1;
				Line val4 = new Line();
				((Entity)val4).ColorIndex = 7;
				((Entity)val4).Layer = "0";
				val4.StartPoint = new Point3d(0.0, 0.0, 0.0);
				val4.EndPoint = new Point3d(0.0001, 0.0, 0.0);
				novaRegua.AppendEntity((Entity)(object)val4);
				DeclaracoesGeral.bAnularEventos = true;
				val.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				((Entity)val4).Visible = true;
				Rg.Div = num;
				double num2 = (Rg.Delta = (Rg.Ptf.X - Rg.Pti.X) / (double)num);
				TextStyleTable val5 = (TextStyleTable)val.GetObject(database.TextStyleTableId, (OpenMode)0);
				ObjectId val6 = (((SymbolTable)val5).Has("Romans") ? ((SymbolTable)val5)["Romans"] : ((SymbolTable)val5)["Standard"]);
				TextStyleTableRecord val7 = (TextStyleTableRecord)val.GetObject(val6, (OpenMode)0);
				double xScale = val7.XScale;
				short num3 = (short)(num - 1);
				for (short num4 = 0; num4 <= num3; num4 = (short)unchecked(num4 + 1))
				{
					Line val8 = new Line();
					((Entity)val8).ColorIndex = Rg.Cor;
					((Entity)val8).Layer = "0";
					val8.StartPoint = new Point3d((double)num4 * num2, 0.0, 0.0);
					val8.EndPoint = new Point3d((double)num4 * num2, 0.0 - Conversions.ToDouble(Rg.Espessura), 0.0);
					novaRegua.AppendEntity((Entity)(object)val8);
					DeclaracoesGeral.bAnularEventos = true;
					val.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
					((Entity)val8).Visible = Rg.Visivel;
					DBText val9 = new DBText();
					((Entity)val9).ColorIndex = Rg.Cor;
					((Entity)val9).Layer = "0";
					val9.TextString = Conversions.ToString(Conversions.ToDouble(Rg.Inicio) + (double)num4);
					val9.Height = Conversions.ToDouble(Rg.Espessura) * 0.7;
					val9.HorizontalMode = (TextHorizontalMode)4;
					val9.VerticalMode = (TextVerticalMode)2;
					val9.TextStyleId = val6;
					val9.WidthFactor = xScale;
					val9.AlignmentPoint = new Point3d((double)num4 * num2 + num2 / 2.0, (0.0 - Conversions.ToDouble(Rg.Espessura)) / 2.0, 0.0);
					novaRegua.AppendEntity((Entity)(object)val9);
					DeclaracoesGeral.bAnularEventos = true;
					val.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
					((Entity)val9).Visible = Rg.Visivel;
				}
				XDataGeral.gravarXDataReguaH(ref novaRegua, Rg);
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				result = ((DBObject)novaRegua).ObjectId;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				val.Abort();
				throw;
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			return result;
		}
	}

	public static ObjectId CriarDefinicaoReguaVertical(ref DeclaracoesGeral.Reguas Rg)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0465: Unknown result type (might be due to invalid IL or missing references)
		//IL_046b: Expected Obj, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected Obj, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected Obj, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected Obj, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Expected Obj, but got Unknown
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Expected Obj, but got Unknown
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected Obj, but got Unknown
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Expected Obj, but got Unknown
		//IL_037c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_0481: Unknown result type (might be due to invalid IL or missing references)
		//IL_0483: Unknown result type (might be due to invalid IL or missing references)
		ObjectId result = ObjectId.Null;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord novaRegua = new BlockTableRecord();
				((SymbolTableRecord)novaRegua).Name = "ReguaV";
				((DBObject)val2).UpgradeOpen();
				((SymbolTable)val2).Add((SymbolTableRecord)(object)novaRegua);
				DeclaracoesGeral.bAnularEventos = true;
				val.AddNewlyCreatedDBObject((DBObject)(object)novaRegua, true);
				Line val3 = new Line();
				((Entity)val3).ColorIndex = Rg.Cor;
				((Entity)val3).Layer = "0";
				val3.StartPoint = new Point3d(Conversions.ToDouble(Rg.Espessura), 0.0, 0.0);
				val3.EndPoint = new Point3d(Conversions.ToDouble(Rg.Espessura), Rg.Ptf.Y - Rg.Pti.Y, 0.0);
				novaRegua.AppendEntity((Entity)(object)val3);
				DeclaracoesGeral.bAnularEventos = true;
				val.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
				((Entity)val3).Visible = Rg.Visivel;
				Line val4 = new Line();
				((Entity)val4).ColorIndex = 7;
				((Entity)val4).Layer = "0";
				val4.StartPoint = new Point3d(0.0, 0.0, 0.0);
				val4.EndPoint = new Point3d(0.0, -0.0001, 0.0);
				novaRegua.AppendEntity((Entity)(object)val4);
				DeclaracoesGeral.bAnularEventos = true;
				val.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				((Entity)val4).Visible = true;
				short num = -1;
				if (Strings.Asc(Rg.Fim) > Strings.Asc(Rg.Inicio))
				{
					num = 1;
				}
				int num2 = Strings.Asc(Rg.Fim) - Strings.Asc(Rg.Inicio) + num;
				if (num2 < 0)
				{
					num2 *= -1;
				}
				Rg.Div = num2;
				double num3 = (Rg.Pti.Y - Rg.Ptf.Y) / (double)num2;
				if (num3 < 0.0)
				{
					num3 *= -1.0;
				}
				Rg.Delta = num3;
				TextStyleTable val5 = (TextStyleTable)val.GetObject(database.TextStyleTableId, (OpenMode)0);
				ObjectId val6 = (((SymbolTable)val5).Has("Romans") ? ((SymbolTable)val5)["Romans"] : ((SymbolTable)val5)["Standard"]);
				TextStyleTableRecord val7 = (TextStyleTableRecord)val.GetObject(val6, (OpenMode)0);
				double xScale = val7.XScale;
				short num4 = (short)(num2 - 1);
				for (short num5 = 0; num5 <= num4; num5 = (short)unchecked(num5 + 1))
				{
					Line val8 = new Line();
					((Entity)val8).ColorIndex = Rg.Cor;
					((Entity)val8).Layer = "0";
					val8.StartPoint = new Point3d(0.0, (double)(short)unchecked(-num5) * num3, 0.0);
					val8.EndPoint = new Point3d(Conversions.ToDouble(Rg.Espessura), (double)(short)unchecked(-num5) * num3, 0.0);
					novaRegua.AppendEntity((Entity)(object)val8);
					DeclaracoesGeral.bAnularEventos = true;
					val.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
					((Entity)val8).Visible = Rg.Visivel;
					DBText val9 = new DBText();
					((Entity)val9).ColorIndex = Rg.Cor;
					((Entity)val9).Layer = "0";
					val9.TextString = Conversions.ToString(Strings.Chr(Strings.Asc(Rg.Inicio) + (short)unchecked(num5 * num)));
					val9.Height = Conversions.ToDouble(Rg.Espessura) * 0.7;
					val9.HorizontalMode = (TextHorizontalMode)4;
					val9.VerticalMode = (TextVerticalMode)2;
					val9.TextStyleId = val6;
					val9.WidthFactor = xScale;
					val9.AlignmentPoint = new Point3d(Conversions.ToDouble(Rg.Espessura) / 2.0, (double)(short)unchecked(-num5) * num3 - num3 / 2.0, 0.0);
					novaRegua.AppendEntity((Entity)(object)val9);
					DeclaracoesGeral.bAnularEventos = true;
					val.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
					((Entity)val9).Visible = Rg.Visivel;
				}
				XDataGeral.gravarXDataReguaV(ref novaRegua, Rg);
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				result = ((DBObject)novaRegua).ObjectId;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				val.Abort();
				throw;
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			return result;
		}
	}

	public static void InsereRegua(DeclaracoesGeral.Reguas rg, ObjectId blocoID)
	{
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected Obj, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected Obj, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			if (!(blocoID == ObjectId.Null))
			{
				Point3d val2 = new Point3d(rg.Pti.X, rg.Pti.Y, 0.0);
				BlockReference val3 = new BlockReference(val2, blocoID);
				BlockTable val4 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val5 = (BlockTableRecord)val.GetObject(((SymbolTable)val4)[DeclaracoesGeral.blockFormatoName], (OpenMode)1);
				((Entity)val3).Layer = "-1";
				val5.AppendEntity((Entity)(object)val3);
				DeclaracoesGeral.bAnularEventos = true;
				val.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			val.Abort();
			throw;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static bool VerificaRegua()
	{
		bool result = true;
		DeclaracoesGeral.Reguas RH = default;
		bool flag = false;
		DeclaracoesGeral.Reguas RH2 = default;
		bool flag2 = false;
		flag = XDataGeral.LeXDataReguaH(ref RH);
		flag2 = XDataGeral.LeXDataReguaV(ref RH2);
		if (flag & (RH.Delta == 0.0))
		{
			Interaction.MsgBox(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1805], "H"));
			result = false;
		}
		if (flag2 & (RH2.Delta == 0.0))
		{
			Interaction.MsgBox(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1805], "V"));
			result = false;
		}
		return result;
	}
}
