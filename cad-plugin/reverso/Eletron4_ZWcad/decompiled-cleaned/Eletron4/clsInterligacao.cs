using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
using ZwSoft.ZwCAD.Runtime;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

public class clsInterligacao
{
	private static DeclaracoesEntidades.StructureInterligacao QcPTJsKyMi;

	public void CriarInterligacao()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected Obj, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Invalid comparison between Unknown and I4
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected Obj, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected Obj, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected Obj, but got Unknown
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected I4, but got Unknown
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Invalid comparison between Unknown and I4
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Expected Obj, but got Unknown
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Expected Obj, but got Unknown
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_05be: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0602: Unknown result type (might be due to invalid IL or missing references)
		//IL_0609: Expected Obj, but got Unknown
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0433: Unknown result type (might be due to invalid IL or missing references)
		//IL_0460: Unknown result type (might be due to invalid IL or missing references)
		//IL_0465: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Unknown result type (might be due to invalid IL or missing references)
		//IL_046a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ef: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		int num = Conversions.ToInteger(LeOModeloVeias());
		List<string> lHandleCabos = new List<string>();
		if (num == 3)
		{
			clsTextos.capturaTodosTextosDeCabos(ref lHandleCabos);
		}
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		PromptPointOptions val = new PromptPointOptions("");
		((PromptOptions)val).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 732]));
		PromptPointResult point = editor.GetPoint(val);
		if ((int)((PromptResult)point).Status != -5002)
		{
			Point3d value = point.Value;
			string sTipo = "";
			Point3d pt = value;
			string Handle = "";
			short Painel = default;
			if (verificaDispInterlig(pt, ref sTipo, ref Painel, ref Handle))
			{
				ClsCabos.CriaEstiloDeLinha(ref DeclaracoesGeral.Conf.EstiloLinha, DeclaracoesGeral.Conf.EstiloLinhaEscala);
				DeclaracoesEntidades.StructureInterligacao ilig = new DeclaracoesEntidades.StructureInterligacao
				{
					Tipo = 1,
					Handle1 = "",
					Handle2 = "",
					Tag_Cabo = "",
					NumVeia = -1000,
					NomeVeia = "",
					iModeloVeiaFuncao = num,
					ocultaTag = 0,
					Usuario = Environment.UserName,
					Data = DateTime.Now.ToString(),
					Painel1 = Painel
				};
				Point2d val2 = value.Convert2d((PlanarEntity)new Plane());
				Polyline pl = new Polyline();
				((Entity)pl).SetDatabaseDefaults();
				((Entity)pl).ColorIndex = DeclaracoesGeral.Conf.CorInterligacao;
				((Entity)pl).Linetype = DeclaracoesGeral.Conf.EstiloLinha;
				((Entity)pl).LinetypeScale = DeclaracoesGeral.Conf.EstiloLinhaEscala;
				pl.AddVertexAt(0, val2, 0.0, 0.0, 0.0);
				pl.AddVertexAt(1, val2, 0.0, 0.0, 0.0);
				((Entity)pl).Layer = DeclaracoesGeral.ativo.Pagina;
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val3 = database.TransactionManager.StartTransaction();
				try
				{
					int num2 = 1;
					try
					{
						while (true)
						{
							Entity ent = (Entity)(object)pl;
							JigInterligacao jigInterligacao = new JigInterligacao(ref ent, num2);
							pl = (Polyline)ent;
							JigInterligacao jigInterligacao2 = jigInterligacao;
							hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
							PromptResult val4 = editor.Drag((Jig)(object)jigInterligacao2);
							PromptStatus status = val4.Status;
							switch (status - -5005)
							{
							default:
								if ((int)status == 5100)
								{
									Point2d point2dAt = pl.GetPoint2dAt(checked(pl.NumberOfVertices - 1));
									Point2d point2dAt2 = pl.GetPoint2dAt(0);
									if (num2 == 1)
									{
										if ((pl.NumberOfVertices == 2) & (Math.Round(point2dAt2.X, 1) != Math.Round(point2dAt.X, 1)) & (Math.Round(point2dAt2.Y, 1) != Math.Round(point2dAt.Y, 1)))
										{
											Point3d val5 = new Point3d(point2dAt.X - 0.2, point2dAt.Y - 0.2, 0.0);
											Point3d val6 = new Point3d(point2dAt.X + 0.2, point2dAt.Y + 0.2, 0.0);
											PromptSelectionResult val7 = editor.SelectCrossingWindow(val5, val6);
											if (!Information.IsNothing(val7.Value))
											{
												SelectionSet value2 = val7.Value;
												if (value2.Count == 1)
												{
													Point2d point2dAt3 = pl.GetPoint2dAt(0);
													Point2d point2dAt4 = pl.GetPoint2dAt(1);
													Point2d point2dAt5 = pl.GetPoint2dAt(1);
													pl.SetPointAt(1, point2dAt3);
													pl.AddVertexAt(2, point2dAt4, 0.0, 0.0, 0.0);
													pl.AddVertexAt(3, point2dAt5, 0.0, 0.0, 0.0);
													num2 = 2;
													continue;
												}
											}
										}
										pl.AddVertexAt(pl.NumberOfVertices, point2dAt, 0.0, 0.0, 0.0);
										num2 = 1;
										continue;
									}
								}
								goto case 1;
							case 1:
							case 2:
							{
								Point3d point3dAt = pl.GetPoint3dAt(checked(pl.NumberOfVertices - 1));
								Handle = "";
								if (!verificaDispInterlig(point3dAt, ref sTipo, ref Painel, ref Handle))
								{
									break;
								}
								ilig.Painel2 = Painel;
								if (ilig.Painel1 != ilig.Painel2)
								{
									BlockTable val8 = (BlockTable)val3.GetObject(database.BlockTableId, (OpenMode)0);
									BlockTableRecord val9 = (BlockTableRecord)val3.GetObject(((SymbolTable)val8)[BlockTableRecord.ModelSpace], (OpenMode)1);
									val9.AppendEntity((Entity)(object)pl);
									DeclaracoesGeral.bAnularEventos = true;
									val3.AddNewlyCreatedDBObject((DBObject)(object)pl, true);
									XDataInterligacao.GravarXDataInterligacao(ref pl, ref ilig, 0);
									switch (num)
									{
									case 1:
										clsEletrosul.reinsereAuxInterligEletrosul(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
										break;
									case 0:
									{
										DBText val10 = criarTextoNomeCabo(pl, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, DeclaracoesGeral.ativo.Pagina);
										val9.AppendEntity((Entity)(object)val10);
										DeclaracoesGeral.bAnularEventos = true;
										val3.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
										ent = (Entity)(object)val10;
										XDataInterligacao.GravarXDataAuxInterligacao(ref ent, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString(), 1, "");
										val10 = (DBText)ent;
										break;
									}
									}
								}
								else
								{
									Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 733]), MsgBoxStyle.Exclamation);
								}
								break;
							}
							case 0:
								if (((num2 == 2) | (num2 == 3)) && Operators.CompareString(val4.StringResult.ToUpper(), "I", TextCompare: true) == 0)
								{
									switch (num2)
									{
									case 3:
										num2 = 2;
										break;
									case 2:
										num2 = 3;
										break;
									}
								}
								continue;
							case 3:
								if (pl.NumberOfVertices == 1)
								{
									break;
								}
								goto case 1;
							case 4:
								break;
							}
							break;
						}
						DeclaracoesGeral.bAnularEventos = true;
						val3.Commit();
						DeclaracoesGeral.bAnularEventos = false;
						((DisposableWrapper)pl).Dispose();
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						val3.Abort();
						Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
						ProjectData.ClearProjectError();
					}
				}
				finally
				{
					((IDisposable)val3)?.Dispose();
				}
			}
		}
		PointMonitorToolTips.StartMonitor();
	}

	public void CriarVeiaAutomatica(string tipoConexao)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected Obj, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected Obj, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected Obj, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Invalid comparison between Unknown and I4
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected Obj, but got Unknown
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected Obj, but got Unknown
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected Obj, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Invalid comparison between Unknown and I4
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Expected Obj, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Expected Obj, but got Unknown
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected Obj, but got Unknown
		//IL_035e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0402: Expected Obj, but got Unknown
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		//IL_043f: Invalid comparison between Unknown and I4
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_044d: Unknown result type (might be due to invalid IL or missing references)
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0481: Expected Obj, but got Unknown
		//IL_09a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04de: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e5: Expected Obj, but got Unknown
		//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ec: Expected Obj, but got Unknown
		//IL_0517: Unknown result type (might be due to invalid IL or missing references)
		//IL_0521: Invalid comparison between Unknown and I4
		//IL_0538: Unknown result type (might be due to invalid IL or missing references)
		//IL_053f: Expected Obj, but got Unknown
		//IL_0967: Unknown result type (might be due to invalid IL or missing references)
		//IL_096d: Unknown result type (might be due to invalid IL or missing references)
		//IL_055a: Unknown result type (might be due to invalid IL or missing references)
		//IL_055f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0569: Unknown result type (might be due to invalid IL or missing references)
		//IL_0570: Expected Obj, but got Unknown
		//IL_05a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b0: Expected Obj, but got Unknown
		//IL_05b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0603: Unknown result type (might be due to invalid IL or missing references)
		//IL_089f: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0620: Unknown result type (might be due to invalid IL or missing references)
		//IL_0625: Unknown result type (might be due to invalid IL or missing references)
		//IL_062f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0636: Expected Obj, but got Unknown
		//IL_066f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0676: Expected Obj, but got Unknown
		//IL_067c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0681: Unknown result type (might be due to invalid IL or missing references)
		//IL_068c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0691: Unknown result type (might be due to invalid IL or missing references)
		//IL_069a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0741: Unknown result type (might be due to invalid IL or missing references)
		//IL_0748: Expected Obj, but got Unknown
		//IL_0785: Unknown result type (might be due to invalid IL or missing references)
		//IL_07aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0911: Unknown result type (might be due to invalid IL or missing references)
		//IL_0918: Expected Obj, but got Unknown
		//IL_091f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0924: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		int num = Conversions.ToInteger(LeOModeloVeias());
		List<string> lHandleCabos = new List<string>();
		if (num == 3)
		{
			clsTextos.capturaTodosTextosDeCabos(ref lHandleCabos);
		}
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		string text = "";
		string right = "";
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)1);
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			try
			{
				PromptPointOptions val4 = new PromptPointOptions("");
				((PromptOptions)val4).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 623]));
				PromptPointResult point = editor.GetPoint(val4);
				if ((int)((PromptResult)point).Status != -5002)
				{
					Point3d value = point.Value;
					string sTipo = "";
					string Handle = "";
					short Painel = default;
					if (verificaDispInterlig(value, ref sTipo, ref Painel, ref Handle))
					{
						BlockReference val5 = (BlockReference)Geral.HandleToObject(Handle);
						Point3d position;
						if (val5 != null)
						{
							text = val5.Name;
							double x = value.X;
							position = val5.Position;
							num2 = x - position.X;
							double y = value.Y;
							position = val5.Position;
							num3 = y - position.Y;
						}
						TypedValue[] array = new TypedValue[2];
						if (Operators.CompareString(sTipo, "I", TextCompare: true) != 0)
						{
							array.SetValue((object)new TypedValue(0, (object)"INSERT"), 0);
							array.SetValue((object)new TypedValue(1001, (object)"DISPOSITIVO"), 1);
						}
						else
						{
							array.SetValue((object)new TypedValue(0, (object)"INSERT"), 0);
							array.SetValue((object)new TypedValue(1001, (object)"IMPORTADO"), 1);
						}
						SelectionFilter val6 = new SelectionFilter(array);
						PromptSelectionOptions val7 = new PromptSelectionOptions();
						val7.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 622]);
						PromptSelectionResult selection = editor.GetSelection(val7, val6);
						if ((int)selection.Status == 5100)
						{
							SelectionSet value2 = selection.Value;
							ObjectIdCollection val8 = new ObjectIdCollection(value2.GetObjectIds());
							ClsCabos.CriaEstiloDeLinha(ref DeclaracoesGeral.Conf.EstiloLinha, DeclaracoesGeral.Conf.EstiloLinhaEscala);
							ObjectIdCollection val9 = new ObjectIdCollection();
							Dictionary<double, ObjectId> dictionary = new Dictionary<double, ObjectId>();
							List<double> list = new List<double>();
							foreach (object item in val8)
							{
								ObjectId value3 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
								BlockReference val10 = (BlockReference)value3.GetObject((OpenMode)0);
								if (Operators.CompareString(text, val10.Name, TextCompare: true) == 0)
								{
									if (Operators.CompareString(tipoConexao, "V", TextCompare: true) != 0)
									{
										position = val10.Position;
										dictionary.Add(Math.Round(position.Y, 1), value3);
										position = val10.Position;
										list.Add(Math.Round(position.Y, 1));
									}
									else
									{
										position = val10.Position;
										dictionary.Add(Math.Round(position.X, 1), value3);
										position = val10.Position;
										list.Add(Math.Round(position.X, 1));
									}
								}
							}
							list.Sort();
							foreach (double item2 in list)
							{
								double key = item2;
								val9.Add(dictionary[key]);
							}
							val4 = new PromptPointOptions("");
							((PromptOptions)val4).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 624]));
							point = editor.GetPoint(val4);
							if ((int)((PromptResult)point).Status != -5002)
							{
								Point3d value4 = point.Value;
								string sTipo2 = "";
								string Handle2 = "";
								short Painel2 = default;
								if (verificaDispInterlig(value4, ref sTipo2, ref Painel2, ref Handle2))
								{
									val5 = (BlockReference)Geral.HandleToObject(Handle2);
									if (val5 != null)
									{
										right = val5.Name;
										double x2 = value4.X;
										position = val5.Position;
										num4 = x2 - position.X;
										double y2 = value4.Y;
										position = val5.Position;
										num5 = y2 - position.Y;
									}
									TypedValue[] array2 = new TypedValue[2];
									if (Operators.CompareString(sTipo2, "I", TextCompare: true) != 0)
									{
										array2.SetValue((object)new TypedValue(0, (object)"INSERT"), 0);
										array2.SetValue((object)new TypedValue(1001, (object)"DISPOSITIVO"), 1);
									}
									else
									{
										array2.SetValue((object)new TypedValue(0, (object)"INSERT"), 0);
										array2.SetValue((object)new TypedValue(1001, (object)"IMPORTADO"), 1);
									}
									val6 = new SelectionFilter(array2);
									val7 = new PromptSelectionOptions();
									val7.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 622]);
									selection = editor.GetSelection(val7, val6);
									if ((int)selection.Status == 5100)
									{
										SelectionSet value5 = selection.Value;
										ObjectIdCollection val11 = new ObjectIdCollection(value5.GetObjectIds());
										foreach (object item3 in val9)
										{
											ObjectId val12 = ((item3 == null) ? default(ObjectId) : ((ObjectId)item3));
											Entity val13 = (Entity)val12.GetObject((OpenMode)0);
											BlockReference val14 = (BlockReference)(object)((val13 is BlockReference) ? val13 : null);
											if (val14 == null || Operators.CompareString(val14.Name, text, TextCompare: true) != 0)
											{
												continue;
											}
											Entity ent = (Entity)(object)val14;
											short num6 = XDataDispositivo.BuscaPainelDispositivo(ref ent);
											val14 = (BlockReference)ent;
											Painel = num6;
											position = val14.Position;
											double x3 = position.X;
											position = val14.Position;
											new Point2d(x3, position.Y);
											position = val14.Position;
											double num7 = position.X + num2;
											position = val14.Position;
											Point2d val15 = new Point2d(num7, position.Y + num3);
											foreach (object item4 in val11)
											{
												ObjectId val16 = ((item4 == null) ? default(ObjectId) : ((ObjectId)item4));
												Entity val17 = (Entity)val16.GetObject((OpenMode)0);
												BlockReference val18 = (BlockReference)(object)((val17 is BlockReference) ? val17 : null);
												if (val18 == null || Operators.CompareString(val18.Name, right, TextCompare: true) != 0)
												{
													continue;
												}
												ent = (Entity)(object)val18;
												num6 = XDataDispositivo.BuscaPainelDispositivo(ref ent);
												val18 = (BlockReference)ent;
												Painel2 = num6;
												position = val18.Position;
												double x4 = position.X;
												position = val18.Position;
												new Point2d(x4, position.Y);
												position = val18.Position;
												double num8 = position.X + num4;
												position = val18.Position;
												Point2d val19 = new Point2d(num8, position.Y + num5);
												if (Painel != Painel2 && (((Operators.CompareString(tipoConexao, "V", TextCompare: true) == 0) & (Math.Round(val15.X, 0) == Math.Round(val19.X, 0))) | ((Operators.CompareString(tipoConexao, "H", TextCompare: true) == 0) & (Math.Round(val15.Y, 0) == Math.Round(val19.Y, 0)))))
												{
													Polyline pl = new Polyline();
													((Entity)pl).SetDatabaseDefaults();
													((Entity)pl).ColorIndex = DeclaracoesGeral.Conf.CorInterligacao;
													((Entity)pl).Linetype = DeclaracoesGeral.Conf.EstiloLinha;
													((Entity)pl).LinetypeScale = DeclaracoesGeral.Conf.EstiloLinhaEscala;
													pl.AddVertexAt(0, val15, 0.0, 0.0, 0.0);
													pl.AddVertexAt(1, val19, 0.0, 0.0, 0.0);
													((Entity)pl).Layer = DeclaracoesGeral.ativo.Pagina;
													val3.AppendEntity((Entity)(object)pl);
													DeclaracoesGeral.bAnularEventos = true;
													val.AddNewlyCreatedDBObject((DBObject)(object)pl, true);
													DeclaracoesEntidades.StructureInterligacao ilig = new DeclaracoesEntidades.StructureInterligacao
													{
														Tipo = 1,
														Handle1 = "",
														Handle2 = "",
														Tag_Cabo = "",
														NumVeia = -1000,
														NomeVeia = "",
														ocultaTag = 0,
														Painel1 = Painel,
														Painel2 = Painel2,
														Usuario = Environment.UserName,
														Data = DateTime.Now.ToString()
													};
													XDataInterligacao.GravarXDataInterligacao(ref pl, ref ilig, 0);
													switch (num)
													{
													case 0:
													{
														DBText val20 = criarTextoNomeCabo(pl, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, DeclaracoesGeral.ativo.Pagina);
														val3.AppendEntity((Entity)(object)val20);
														DeclaracoesGeral.bAnularEventos = true;
														val.AddNewlyCreatedDBObject((DBObject)(object)val20, true);
														ent = (Entity)(object)val20;
														XDataInterligacao.GravarXDataAuxInterligacao(ref ent, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString(), 1, "");
														val20 = (DBText)ent;
														break;
													}
													case 1:
														clsEletrosul.reinsereAuxInterligEletrosul(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
														break;
													}
													break;
												}
											}
										}
									}
								}
							}
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				val.Abort();
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
				ProjectData.ClearProjectError();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		PointMonitorToolTips.StartMonitor();
	}

	public void CriarInterligacao1()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Invalid comparison between Unknown and I4
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected Obj, but got Unknown
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected Obj, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected Obj, but got Unknown
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Expected I4, but got Unknown
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Expected Obj, but got Unknown
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected Obj, but got Unknown
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Invalid comparison between Unknown and I4
		//IL_0638: Unknown result type (might be due to invalid IL or missing references)
		//IL_0656: Unknown result type (might be due to invalid IL or missing references)
		//IL_065b: Unknown result type (might be due to invalid IL or missing references)
		//IL_067c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0683: Expected Obj, but got Unknown
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Expected Obj, but got Unknown
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Unknown result type (might be due to invalid IL or missing references)
		//IL_068a: Unknown result type (might be due to invalid IL or missing references)
		//IL_068f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0502: Unknown result type (might be due to invalid IL or missing references)
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		//IL_0473: Unknown result type (might be due to invalid IL or missing references)
		//IL_053c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0541: Unknown result type (might be due to invalid IL or missing references)
		//IL_0546: Unknown result type (might be due to invalid IL or missing references)
		//IL_054b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0550: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_055a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0564: Unknown result type (might be due to invalid IL or missing references)
		//IL_0589: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		int num = Conversions.ToInteger(LeOModeloVeias());
		List<string> lHandleCabos = new List<string>();
		if (num == 3)
		{
			clsTextos.capturaTodosTextosDeCabos(ref lHandleCabos);
		}
		QcPTJsKyMi = default;
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		PromptPointOptions val = new PromptPointOptions("");
		((PromptOptions)val).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 732]));
		PromptPointResult point = editor.GetPoint(val);
		if ((int)((PromptResult)point).Status != -5002)
		{
			Point3d value = point.Value;
			string sTipo = "";
			Point3d pt = value;
			string Handle = "";
			short Painel = default;
			if (verificaDispInterlig(pt, ref sTipo, ref Painel, ref Handle))
			{
				ClsCabos.CriaEstiloDeLinha(ref DeclaracoesGeral.Conf.EstiloLinha, DeclaracoesGeral.Conf.EstiloLinhaEscala);
				QcPTJsKyMi.Tipo = 2;
				QcPTJsKyMi.Handle1 = "";
				QcPTJsKyMi.Handle2 = "";
				QcPTJsKyMi.THandle1 = "";
				QcPTJsKyMi.THandle2 = "";
				QcPTJsKyMi.Tag_Cabo = "";
				QcPTJsKyMi.NumVeia = -1000;
				QcPTJsKyMi.NomeVeia = "";
				QcPTJsKyMi.iModeloVeiaFuncao = num;
				QcPTJsKyMi.ocultaTag = 0;
				QcPTJsKyMi.Usuario = Environment.UserName;
				QcPTJsKyMi.Data = DateTime.Now.ToString();
				QcPTJsKyMi.Painel1 = Painel;
				Point2d val2 = value.Convert2d((PlanarEntity)new Plane());
				Polyline pl = new Polyline();
				((Entity)pl).SetDatabaseDefaults();
				((Entity)pl).ColorIndex = DeclaracoesGeral.Conf.CorInterligacao;
				((Entity)pl).Linetype = DeclaracoesGeral.Conf.EstiloLinha;
				((Entity)pl).LinetypeScale = DeclaracoesGeral.Conf.EstiloLinhaEscala;
				pl.AddVertexAt(0, val2, 0.0, 0.0, 0.0);
				pl.AddVertexAt(1, val2, 0.0, 0.0, 0.0);
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val3 = database.TransactionManager.StartTransaction();
				try
				{
					int num2 = 1;
					try
					{
						while (true)
						{
							Entity ent = (Entity)(object)pl;
							JigInterligacao jigInterligacao = new JigInterligacao(ref ent, num2);
							pl = (Polyline)ent;
							JigInterligacao jigInterligacao2 = jigInterligacao;
							hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
							PromptResult val4 = editor.Drag((Jig)(object)jigInterligacao2);
							PromptStatus status = val4.Status;
							switch (status - -5005)
							{
							default:
								if ((int)status == 5100)
								{
									Point2d point2dAt = pl.GetPoint2dAt(checked(pl.NumberOfVertices - 1));
									Point2d point2dAt2 = pl.GetPoint2dAt(0);
									if (num2 == 1)
									{
										if ((pl.NumberOfVertices == 2) & (Math.Round(point2dAt2.X, 1) != Math.Round(point2dAt.X, 1)) & (Math.Round(point2dAt2.Y, 1) != Math.Round(point2dAt.Y, 1)))
										{
											Point3d val5 = new Point3d(point2dAt.X - 0.2, point2dAt.Y - 0.2, 0.0);
											Point3d val6 = new Point3d(point2dAt.X + 0.2, point2dAt.Y + 0.2, 0.0);
											PromptSelectionResult val7 = editor.SelectCrossingWindow(val5, val6);
											if (!Information.IsNothing(val7.Value))
											{
												SelectionSet value2 = val7.Value;
												if (value2.Count == 1)
												{
													Point2d point2dAt3 = pl.GetPoint2dAt(0);
													Point2d point2dAt4 = pl.GetPoint2dAt(1);
													Point2d point2dAt5 = pl.GetPoint2dAt(1);
													pl.SetPointAt(1, point2dAt3);
													pl.AddVertexAt(2, point2dAt4, 0.0, 0.0, 0.0);
													pl.AddVertexAt(3, point2dAt5, 0.0, 0.0, 0.0);
													num2 = 2;
													continue;
												}
											}
										}
										pl.AddVertexAt(pl.NumberOfVertices, point2dAt, 0.0, 0.0, 0.0);
										num2 = 1;
										continue;
									}
								}
								goto case 1;
							case 1:
							case 2:
							{
								QcPTJsKyMi.Painel2 = 0;
								BlockTable val8 = (BlockTable)val3.GetObject(database.BlockTableId, (OpenMode)0);
								BlockTableRecord val9 = (BlockTableRecord)val3.GetObject(((SymbolTable)val8)[BlockTableRecord.ModelSpace], (OpenMode)1);
								val9.AppendEntity((Entity)(object)pl);
								DeclaracoesGeral.bAnularEventos = true;
								val3.AddNewlyCreatedDBObject((DBObject)(object)pl, true);
								XDataInterligacao.GravarXDataInterligacao(ref pl, ref QcPTJsKyMi, 1);
								DBText val10 = null;
								if (num != 0)
								{
									if (num == 1)
									{
										clsEletrosul.reinsereAuxInterligEletrosul(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
									}
								}
								else
								{
									val10 = criarTextoNomeCabo(pl, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, DeclaracoesGeral.ativo.Pagina);
									val9.AppendEntity((Entity)(object)val10);
									DeclaracoesGeral.bAnularEventos = true;
									val3.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
									ent = (Entity)(object)val10;
									XDataInterligacao.GravarXDataAuxInterligacao(ref ent, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString(), 1, "");
									val10 = (DBText)ent;
								}
								val10 = criarTextoCruzamentoCabo(pl, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, DeclaracoesGeral.ativo.Pagina, 1);
								val9.AppendEntity((Entity)(object)val10);
								DeclaracoesGeral.bAnularEventos = true;
								val3.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
								QcPTJsKyMi.THandle1 = ((object)((DBObject)val10).Handle/*cast due to constrained. prefix*/).ToString();
								QcPTJsKyMi.THandle2 = "";
								ent = (Entity)(object)val10;
								XDataInterligacao.GravarXDataAuxInterligacao(ref ent, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString(), 2, QcPTJsKyMi.THandle2);
								val10 = (DBText)ent;
								QcPTJsKyMi.Handle1 = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
								break;
							}
							case 0:
								if (((num2 == 2) | (num2 == 3)) && Operators.CompareString(val4.StringResult.ToUpper(), "I", TextCompare: true) == 0)
								{
									switch (num2)
									{
									case 3:
										num2 = 2;
										break;
									case 2:
										num2 = 3;
										break;
									}
								}
								continue;
							case 3:
								if (pl.NumberOfVertices == 1)
								{
									break;
								}
								goto case 1;
							case 4:
								break;
							}
							break;
						}
						DeclaracoesGeral.bAnularEventos = true;
						val3.Commit();
						DeclaracoesGeral.bAnularEventos = false;
						((DisposableWrapper)pl).Dispose();
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						val3.Abort();
						Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
						ProjectData.ClearProjectError();
					}
				}
				finally
				{
					((IDisposable)val3)?.Dispose();
				}
			}
		}
		PointMonitorToolTips.StartMonitor();
	}

	public void CriarInterligacao2()
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected Obj, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Invalid comparison between Unknown and I4
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected Obj, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected Obj, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected Obj, but got Unknown
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected I4, but got Unknown
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Invalid comparison between Unknown and I4
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected Obj, but got Unknown
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Expected Obj, but got Unknown
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_0688: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d3: Expected Obj, but got Unknown
		//IL_04f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0527: Unknown result type (might be due to invalid IL or missing references)
		//IL_052c: Unknown result type (might be due to invalid IL or missing references)
		//IL_052f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0531: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0401: Expected Obj, but got Unknown
		//IL_0410: Unknown result type (might be due to invalid IL or missing references)
		//IL_0417: Expected Obj, but got Unknown
		//IL_06da: Unknown result type (might be due to invalid IL or missing references)
		//IL_06df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Expected Obj, but got Unknown
		//IL_0569: Unknown result type (might be due to invalid IL or missing references)
		//IL_056e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0573: Unknown result type (might be due to invalid IL or missing references)
		//IL_0578: Unknown result type (might be due to invalid IL or missing references)
		//IL_057d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0582: Unknown result type (might be due to invalid IL or missing references)
		//IL_0587: Unknown result type (might be due to invalid IL or missing references)
		//IL_0591: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0769: Unknown result type (might be due to invalid IL or missing references)
		//IL_0770: Expected Obj, but got Unknown
		//IL_0796: Unknown result type (might be due to invalid IL or missing references)
		//IL_079d: Expected Obj, but got Unknown
		if (Operators.CompareString(QcPTJsKyMi.Handle1, "", TextCompare: true) == 0)
		{
			return;
		}
		int num = Conversions.ToInteger(LeOModeloVeias());
		List<string> lHandleCabos = new List<string>();
		if (num == 3)
		{
			clsTextos.capturaTodosTextosDeCabos(ref lHandleCabos);
		}
		PointMonitorToolTips.StopMonitor();
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		PromptPointOptions val = new PromptPointOptions("");
		((PromptOptions)val).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 732]));
		PromptPointResult point = editor.GetPoint(val);
		if ((int)((PromptResult)point).Status != -5002)
		{
			Point3d value = point.Value;
			ClsCabos.CriaEstiloDeLinha(ref DeclaracoesGeral.Conf.EstiloLinha, DeclaracoesGeral.Conf.EstiloLinhaEscala);
			QcPTJsKyMi.Tipo = 2;
			QcPTJsKyMi.Tag_Cabo = "";
			QcPTJsKyMi.NumVeia = -1000;
			QcPTJsKyMi.NomeVeia = "";
			QcPTJsKyMi.iModeloVeiaFuncao = num;
			QcPTJsKyMi.ocultaTag = 0;
			QcPTJsKyMi.Usuario = Environment.UserName;
			QcPTJsKyMi.Data = DateTime.Now.ToString();
			Point2d val2 = value.Convert2d((PlanarEntity)new Plane());
			Polyline pl = new Polyline();
			((Entity)pl).SetDatabaseDefaults();
			((Entity)pl).ColorIndex = DeclaracoesGeral.Conf.CorInterligacao;
			((Entity)pl).Linetype = DeclaracoesGeral.Conf.EstiloLinha;
			((Entity)pl).LinetypeScale = DeclaracoesGeral.Conf.EstiloLinhaEscala;
			pl.AddVertexAt(0, val2, 0.0, 0.0, 0.0);
			pl.AddVertexAt(1, val2, 0.0, 0.0, 0.0);
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val3 = database.TransactionManager.StartTransaction();
			try
			{
				int num2 = 1;
				try
				{
					short Painel = default;
					short tipo = default;
					while (true)
					{
						Entity ent = (Entity)(object)pl;
						JigInterligacao jigInterligacao = new JigInterligacao(ref ent, num2);
						pl = (Polyline)ent;
						JigInterligacao jigInterligacao2 = jigInterligacao;
						hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
						PromptResult val4 = editor.Drag((Jig)(object)jigInterligacao2);
						PromptStatus status = val4.Status;
						switch (status - -5005)
						{
						default:
							if ((int)status == 5100)
							{
								Point2d point2dAt = pl.GetPoint2dAt(checked(pl.NumberOfVertices - 1));
								Point2d point2dAt2 = pl.GetPoint2dAt(0);
								if (num2 == 1)
								{
									if ((pl.NumberOfVertices == 2) & (Math.Round(point2dAt2.X, 1) != Math.Round(point2dAt.X, 1)) & (Math.Round(point2dAt2.Y, 1) != Math.Round(point2dAt.Y, 1)))
									{
										Point3d val5 = new Point3d(point2dAt.X - 0.2, point2dAt.Y - 0.2, 0.0);
										Point3d val6 = new Point3d(point2dAt.X + 0.2, point2dAt.Y + 0.2, 0.0);
										PromptSelectionResult val7 = editor.SelectCrossingWindow(val5, val6);
										if (!Information.IsNothing(val7.Value))
										{
											SelectionSet value2 = val7.Value;
											if (value2.Count == 1)
											{
												Point2d point2dAt3 = pl.GetPoint2dAt(0);
												Point2d point2dAt4 = pl.GetPoint2dAt(1);
												Point2d point2dAt5 = pl.GetPoint2dAt(1);
												pl.SetPointAt(1, point2dAt3);
												pl.AddVertexAt(2, point2dAt4, 0.0, 0.0, 0.0);
												pl.AddVertexAt(3, point2dAt5, 0.0, 0.0, 0.0);
												num2 = 2;
												continue;
											}
										}
									}
									pl.AddVertexAt(pl.NumberOfVertices, point2dAt, 0.0, 0.0, 0.0);
									num2 = 1;
									continue;
								}
							}
							goto case 1;
						case 1:
						case 2:
						{
							string sTipo = "";
							Point3d point3dAt = pl.GetPoint3dAt(checked(pl.NumberOfVertices - 1));
							string Handle = "";
							if (!verificaDispInterlig(point3dAt, ref sTipo, ref Painel, ref Handle))
							{
								break;
							}
							QcPTJsKyMi.Painel2 = Painel;
							if (QcPTJsKyMi.Painel1 != QcPTJsKyMi.Painel2)
							{
								QcPTJsKyMi.Painel1 = 0;
								BlockTable val8 = (BlockTable)val3.GetObject(database.BlockTableId, (OpenMode)0);
								BlockTableRecord val9 = (BlockTableRecord)val3.GetObject(((SymbolTable)val8)[BlockTableRecord.ModelSpace], (OpenMode)1);
								val9.AppendEntity((Entity)(object)pl);
								DeclaracoesGeral.bAnularEventos = true;
								val3.AddNewlyCreatedDBObject((DBObject)(object)pl, true);
								XDataInterligacao.GravarXDataInterligacao(ref pl, ref QcPTJsKyMi, 2);
								DBText val10 = null;
								if (num != 0)
								{
									if (num == 1)
									{
										clsEletrosul.reinsereAuxInterligEletrosul(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
									}
								}
								else
								{
									val10 = criarTextoNomeCabo(pl, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, DeclaracoesGeral.ativo.Pagina);
									val9.AppendEntity((Entity)(object)val10);
									DeclaracoesGeral.bAnularEventos = true;
									val3.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
									ent = (Entity)(object)val10;
									XDataInterligacao.GravarXDataAuxInterligacao(ref ent, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString(), 1, "");
									val10 = (DBText)ent;
								}
								val10 = criarTextoCruzamentoCabo(pl, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, DeclaracoesGeral.ativo.Pagina, 2);
								val9.AppendEntity((Entity)(object)val10);
								DeclaracoesGeral.bAnularEventos = true;
								val3.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
								QcPTJsKyMi.THandle2 = ((object)((DBObject)val10).Handle/*cast due to constrained. prefix*/).ToString();
								QcPTJsKyMi.Handle2 = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
								ent = (Entity)(object)val10;
								XDataInterligacao.GravarXDataAuxInterligacao(ref ent, QcPTJsKyMi.Handle2, 2, QcPTJsKyMi.THandle1);
								val10 = (DBText)ent;
								Polyline pl2 = (Polyline)Geral.HandleToObject(QcPTJsKyMi.Handle1);
								if (pl2 != null)
								{
									((DBObject)pl2).UpgradeOpen();
									DeclaracoesEntidades.StructureInterligacao ilig = default;
									if (XDataInterligacao.lerXDataInterligacao(ref pl2, ref ilig))
									{
										ilig.Handle2 = QcPTJsKyMi.Handle2;
										XDataInterligacao.GravarXDataInterligacao(ref pl2, ref ilig, 1);
									}
								}
								DBText val11 = (DBText)Geral.HandleToObject(QcPTJsKyMi.THandle1);
								if (val11 != null)
								{
									((DBObject)val11).UpgradeOpen();
									string handle = "";
									string THandle = "";
									ent = (Entity)(object)val11;
									Handle = "";
									bool flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle, ref tipo, ref THandle, ref Handle);
									val11 = (DBText)ent;
									if (flag)
									{
										ent = (Entity)(object)val11;
										XDataInterligacao.GravarXDataAuxInterligacao(ref ent, handle, 2, QcPTJsKyMi.THandle2);
										val11 = (DBText)ent;
									}
								}
								SincronizaCruzamentoInterlig();
							}
							else
							{
								Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 733]), MsgBoxStyle.Exclamation);
							}
							break;
						}
						case 0:
							if (((num2 == 2) | (num2 == 3)) && Operators.CompareString(val4.StringResult.ToUpper(), "I", TextCompare: true) == 0)
							{
								switch (num2)
								{
								case 3:
									num2 = 2;
									break;
								case 2:
									num2 = 3;
									break;
								}
							}
							continue;
						case 3:
							if (pl.NumberOfVertices == 1)
							{
								break;
							}
							goto case 1;
						case 4:
							break;
						}
						break;
					}
					DeclaracoesGeral.bAnularEventos = true;
					val3.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					((DisposableWrapper)pl).Dispose();
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					val3.Abort();
					Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
					ProjectData.ClearProjectError();
				}
				finally
				{
					QcPTJsKyMi = default;
				}
			}
			finally
			{
				((IDisposable)val3)?.Dispose();
			}
		}
		PointMonitorToolTips.StartMonitor();
	}

	public void CriarVeiaAterrada()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected Obj, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Invalid comparison between Unknown and I4
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected Obj, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected Obj, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected Obj, but got Unknown
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected I4, but got Unknown
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Invalid comparison between Unknown and I4
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected Obj, but got Unknown
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Expected Obj, but got Unknown
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_0559: Unknown result type (might be due to invalid IL or missing references)
		//IL_0577: Unknown result type (might be due to invalid IL or missing references)
		//IL_057c: Unknown result type (might be due to invalid IL or missing references)
		//IL_059d: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a4: Expected Obj, but got Unknown
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0423: Unknown result type (might be due to invalid IL or missing references)
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		//IL_0460: Unknown result type (might be due to invalid IL or missing references)
		//IL_0465: Unknown result type (might be due to invalid IL or missing references)
		//IL_046a: Unknown result type (might be due to invalid IL or missing references)
		//IL_046f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0474: Unknown result type (might be due to invalid IL or missing references)
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		//IL_047e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ad: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		int num = Conversions.ToInteger(LeOModeloVeias());
		List<string> lHandleCabos = new List<string>();
		if (num == 3)
		{
			clsTextos.capturaTodosTextosDeCabos(ref lHandleCabos);
		}
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		PromptPointOptions val = new PromptPointOptions("");
		((PromptOptions)val).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 732]));
		PromptPointResult point = editor.GetPoint(val);
		if ((int)((PromptResult)point).Status != -5002)
		{
			Point3d value = point.Value;
			string sTipo = "";
			Point3d pt = value;
			string Handle = "";
			short Painel = default;
			if (!verificaDispInterlig(pt, ref sTipo, ref Painel, ref Handle))
			{
				ClsCabos.CriaEstiloDeLinha(ref DeclaracoesGeral.Conf.EstiloLinha, DeclaracoesGeral.Conf.EstiloLinhaEscala);
				DeclaracoesEntidades.StructureInterligacao ilig = new DeclaracoesEntidades.StructureInterligacao
				{
					Tipo = 3,
					Tag_Cabo = "",
					NumVeia = -1000,
					NomeVeia = "",
					iModeloVeiaFuncao = num,
					ocultaTag = 0,
					Painel1 = 0,
					Usuario = Environment.UserName,
					Data = DateTime.Now.ToString()
				};
				Point2d val2 = value.Convert2d((PlanarEntity)new Plane());
				Polyline pl = new Polyline();
				((Entity)pl).SetDatabaseDefaults();
				((Entity)pl).ColorIndex = DeclaracoesGeral.Conf.CorInterligacao;
				((Entity)pl).Linetype = DeclaracoesGeral.Conf.EstiloLinha;
				((Entity)pl).LinetypeScale = DeclaracoesGeral.Conf.EstiloLinhaEscala;
				pl.AddVertexAt(0, val2, 0.0, 0.0, 0.0);
				pl.AddVertexAt(1, val2, 0.0, 0.0, 0.0);
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val3 = database.TransactionManager.StartTransaction();
				try
				{
					int num2 = 1;
					try
					{
						while (true)
						{
							Entity ent = (Entity)(object)pl;
							JigInterligacao jigInterligacao = new JigInterligacao(ref ent, num2);
							pl = (Polyline)ent;
							JigInterligacao jigInterligacao2 = jigInterligacao;
							hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
							PromptResult val4 = editor.Drag((Jig)(object)jigInterligacao2);
							PromptStatus status = val4.Status;
							switch (status - -5005)
							{
							default:
								if ((int)status == 5100)
								{
									Point2d point2dAt = pl.GetPoint2dAt(checked(pl.NumberOfVertices - 1));
									Point2d point2dAt2 = pl.GetPoint2dAt(0);
									if (num2 == 1)
									{
										if ((pl.NumberOfVertices == 2) & (Math.Round(point2dAt2.X, 1) != Math.Round(point2dAt.X, 1)) & (Math.Round(point2dAt2.Y, 1) != Math.Round(point2dAt.Y, 1)))
										{
											Point3d val5 = new Point3d(point2dAt.X - 0.2, point2dAt.Y - 0.2, 0.0);
											Point3d val6 = new Point3d(point2dAt.X + 0.2, point2dAt.Y + 0.2, 0.0);
											PromptSelectionResult val7 = editor.SelectCrossingWindow(val5, val6);
											if (!Information.IsNothing(val7.Value))
											{
												SelectionSet value2 = val7.Value;
												if (value2.Count == 1)
												{
													Point2d point2dAt3 = pl.GetPoint2dAt(0);
													Point2d point2dAt4 = pl.GetPoint2dAt(1);
													Point2d point2dAt5 = pl.GetPoint2dAt(1);
													pl.SetPointAt(1, point2dAt3);
													pl.AddVertexAt(2, point2dAt4, 0.0, 0.0, 0.0);
													pl.AddVertexAt(3, point2dAt5, 0.0, 0.0, 0.0);
													num2 = 2;
													continue;
												}
											}
										}
										pl.AddVertexAt(pl.NumberOfVertices, point2dAt, 0.0, 0.0, 0.0);
										num2 = 1;
										continue;
									}
								}
								goto case 1;
							case 1:
							case 2:
							{
								Point3d point3dAt = pl.GetPoint3dAt(checked(pl.NumberOfVertices - 1));
								Handle = "";
								if (verificaDispInterlig(point3dAt, ref sTipo, ref Painel, ref Handle))
								{
									ilig.Painel2 = Painel;
									BlockTable val8 = (BlockTable)val3.GetObject(database.BlockTableId, (OpenMode)0);
									BlockTableRecord val9 = (BlockTableRecord)val3.GetObject(((SymbolTable)val8)[BlockTableRecord.ModelSpace], (OpenMode)1);
									val9.AppendEntity((Entity)(object)pl);
									DeclaracoesGeral.bAnularEventos = true;
									val3.AddNewlyCreatedDBObject((DBObject)(object)pl, true);
									XDataInterligacao.GravarXDataInterligacao(ref pl, ref ilig, 0);
									switch (num)
									{
									case 1:
										clsEletrosul.reinsereAuxInterligEletrosul(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
										break;
									case 0:
									{
										DBText val10 = criarTextoNomeCabo(pl, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, DeclaracoesGeral.ativo.Pagina);
										val9.AppendEntity((Entity)(object)val10);
										DeclaracoesGeral.bAnularEventos = true;
										val3.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
										ent = (Entity)(object)val10;
										XDataInterligacao.GravarXDataAuxInterligacao(ref ent, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString(), 1, "");
										val10 = (DBText)ent;
										break;
									}
									}
								}
								break;
							}
							case 0:
								if (((num2 == 2) | (num2 == 3)) && Operators.CompareString(val4.StringResult.ToUpper(), "I", TextCompare: true) == 0)
								{
									switch (num2)
									{
									case 3:
										num2 = 2;
										break;
									case 2:
										num2 = 3;
										break;
									}
								}
								continue;
							case 3:
								if (pl.NumberOfVertices == 1)
								{
									break;
								}
								goto case 1;
							case 4:
								break;
							}
							break;
						}
						DeclaracoesGeral.bAnularEventos = true;
						val3.Commit();
						DeclaracoesGeral.bAnularEventos = false;
						((DisposableWrapper)pl).Dispose();
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						val3.Abort();
						Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
						ProjectData.ClearProjectError();
					}
				}
				finally
				{
					((IDisposable)val3)?.Dispose();
				}
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 734]), MsgBoxStyle.Exclamation);
			}
		}
		PointMonitorToolTips.StartMonitor();
	}

	public bool verificaDispInterlig(Point3d pt, ref string sTipo, ref short Painel, [Optional][DefaultParameterValue("")] ref string Handle)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected Obj, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected Obj, but got Unknown
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected Obj, but got Unknown
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Expected Obj, but got Unknown
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a1: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		bool flag = false;
		string text = "";
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		Point3d val = new Point3d(pt.X - 0.2, pt.Y - 0.2, 0.0);
		Point3d val2 = new Point3d(pt.X + 0.2, pt.Y + 0.2, 0.0);
		PromptSelectionResult val3 = editor.SelectCrossingWindow(val, val2);
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val4 = database.TransactionManager.StartTransaction();
		try
		{
			if (!Information.IsNothing(val3.Value))
			{
				SelectionSet value = val3.Value;
				ObjectIdCollection val5 = new ObjectIdCollection(value.GetObjectIds());
				foreach (object item in val5)
				{
					ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
					Entity ent = (Entity)val6.GetObject((OpenMode)0);
					if (Operators.CompareString(ent.Layer, DeclaracoesGeral.ativo.Pagina, TextCompare: true) != 0)
					{
						continue;
					}
					BlockReference val7 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
					if (val7 == null)
					{
						continue;
					}
					string tipoImportado = "";
					text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
					if (Operators.CompareString(text, "E", TextCompare: true) == 0)
					{
						flag = false;
						foreach (object item2 in val7.AttributeCollection)
						{
							ObjectId val8 = ((item2 == null) ? default(ObjectId) : ((ObjectId)item2));
							AttributeReference val9 = (AttributeReference)val8.GetObject((OpenMode)0);
							if ((Operators.CompareString(Strings.Mid(val9.Tag, 1, 1), "B", TextCompare: true) == 0) & Versioned.IsNumeric(Strings.Mid(val9.Tag, 2)))
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							result = false;
							break;
						}
						sTipo = "E";
						Painel = XDataDispositivo.BuscaPainelDispositivo(ref ent);
						Handle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
						result = true;
					}
					if (Operators.CompareString(text, "B", TextCompare: true) == 0)
					{
						sTipo = "B";
						Painel = XDataDispositivo.BuscaPainelDispositivo(ref ent);
						Handle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
						result = true;
					}
					if (Operators.CompareString(text, "I", TextCompare: true) != 0)
					{
						break;
					}
					flag = false;
					sTipo = "I";
					if (Operators.CompareString(tipoImportado, "E", TextCompare: true) != 0)
					{
						if (Operators.CompareString(tipoImportado, "B", TextCompare: true) == 0)
						{
							Painel = XDataDispositivo.BuscaPainelDispositivo(ref ent);
							Handle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							result = true;
						}
						break;
					}
					foreach (object item3 in val7.AttributeCollection)
					{
						ObjectId val10 = ((item3 == null) ? default(ObjectId) : ((ObjectId)item3));
						AttributeReference val11 = (AttributeReference)val10.GetObject((OpenMode)0);
						if ((Operators.CompareString(Strings.Mid(val11.Tag, 1, 1), "B", TextCompare: true) == 0) & Versioned.IsNumeric(Strings.Mid(val11.Tag, 2)))
						{
							flag = true;
						}
					}
					if (!flag)
					{
						result = false;
						break;
					}
					Painel = XDataDispositivo.BuscaPainelDispositivo(ref ent);
					Handle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
					result = true;
					break;
				}
			}
			DeclaracoesGeral.bAnularEventos = true;
			val4.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			val4.Abort();
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val4)?.Dispose();
		}
		return result;
	}

	public static DBText criarTextoNomeCabo(Polyline pl, string texto, string layer)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		double num = Math.Round(Math.PI, 2);
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		DBText val2;
		try
		{
			TextStyleTable val = (TextStyleTable)topTransaction.GetObject(database.TextStyleTableId, (OpenMode)0);
			ObjectId textStyleId = (((SymbolTable)val).Has("Romans") ? ((SymbolTable)val)["Romans"] : ((SymbolTable)val)["Standard"]);
			val2 = new DBText();
			Point3d point3dAt;
			Point3d point3dAt2;
			if (pl.NumberOfVertices != 2)
			{
				if (pl.NumberOfVertices != 3)
				{
					if (pl.NumberOfVertices != 4)
					{
						point3dAt = pl.GetPoint3dAt(0);
						point3dAt2 = pl.GetPoint3dAt(1);
					}
					else
					{
						point3dAt = pl.GetPoint3dAt(1);
						point3dAt2 = pl.GetPoint3dAt(2);
					}
				}
				else
				{
					point3dAt = pl.GetPoint3dAt(0);
					point3dAt2 = pl.GetPoint3dAt(1);
					double num2 = point3dAt.DistanceTo(point3dAt2);
					point3dAt = pl.GetPoint3dAt(1);
					point3dAt2 = pl.GetPoint3dAt(2);
					double num3 = point3dAt.DistanceTo(point3dAt2);
					if (!(num2 > num3))
					{
						point3dAt = pl.GetPoint3dAt(1);
						point3dAt2 = pl.GetPoint3dAt(2);
					}
					else
					{
						point3dAt = pl.GetPoint3dAt(0);
						point3dAt2 = pl.GetPoint3dAt(1);
					}
				}
			}
			else
			{
				point3dAt = pl.GetPoint3dAt(0);
				point3dAt2 = pl.GetPoint3dAt(1);
			}
			double num4 = point3dAt.DistanceTo(point3dAt2) / 2.0;
			double num5 = 1.0;
			double x = point3dAt2.X - point3dAt.X;
			double y = point3dAt2.Y - point3dAt.Y;
			double num6 = Math.Round(Math.Atan2(y, x), 2);
			double rotation;
			if (!((num6 <= num / 2.0) & (num6 > num / 2.0 * -1.0)))
			{
				val2.VerticalMode = (TextVerticalMode)1;
				val2.HorizontalMode = (TextHorizontalMode)1;
				rotation = num6 - Math.PI;
			}
			else
			{
				val2.VerticalMode = (TextVerticalMode)1;
				val2.HorizontalMode = (TextHorizontalMode)1;
				rotation = num6;
			}
			double num7 = num4 * Math.Cos(num6);
			double num8 = num4 * Math.Sin(num6);
			double num9 = num5 * Math.Cos(Math.PI / 2.0 - num6);
			double num10 = num5 * Math.Sin(Math.PI / 2.0 - num6);
			if (num10 < 0.0)
			{
				num10 *= -1.0;
			}
			if (num6 == num / 2.0)
			{
				num9 *= -1.0;
			}
			if (((num6 > 0.0) & (num6 < num / 2.0)) | ((num6 < 0.0) & (num6 > num / 2.0 * -1.0)))
			{
				num9 *= -1.0;
			}
			Point3d alignmentPoint = new Point3d(point3dAt.X + num7 + num9, point3dAt.Y + num8 + num10, 0.0);
			((Entity)val2).ColorIndex = DeclaracoesGeral.Conf.CorTextoInterligacao;
			((Entity)val2).Layer = layer;
			val2.TextString = texto;
			val2.Height = DeclaracoesGeral.Conf.FonteCabos;
			val2.TextStyleId = textStyleId;
			((Entity)val2).LineWeight = (LineWeight)9;
			val2.AlignmentPoint = alignmentPoint;
			val2.Rotation = rotation;
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
		return val2;
	}

	public static DBText criarTextoCruzamentoCabo(Polyline pl, string texto, string layer, short tipoTexto)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected Obj, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		double num = Math.Round(Math.PI, 2);
		short num2 = tipoTexto;
		double num3 = default;
		double num4 = default;
		if (num2 == 1)
		{
			num3 = 1.0;
			num4 = -1.0;
		}
		else if (num2 == 2)
		{
			num3 = 1.0;
			num4 = -1.0;
		}
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		checked
		{
			DBText val2;
			try
			{
				TextStyleTable val = (TextStyleTable)topTransaction.GetObject(database.TextStyleTableId, (OpenMode)0);
				ObjectId textStyleId = (((SymbolTable)val).Has("Romans") ? ((SymbolTable)val)["Romans"] : ((SymbolTable)val)["Standard"]);
				val2 = new DBText();
				Point3d point3dAt = default;
				Point3d point3dAt2 = default;
				if (tipoTexto != 2)
				{
					if (tipoTexto == 1)
					{
						point3dAt = pl.GetPoint3dAt(pl.NumberOfVertices - 1);
						point3dAt2 = pl.GetPoint3dAt(pl.NumberOfVertices - 2);
					}
				}
				else
				{
					point3dAt = pl.GetPoint3dAt(0);
					point3dAt2 = pl.GetPoint3dAt(1);
				}
				double x = point3dAt2.X - point3dAt.X;
				double y = point3dAt2.Y - point3dAt.Y;
				double num5 = Math.Round(Math.Atan2(y, x), 2);
				double rotation;
				if (!((num5 <= num / 2.0) & (num5 > num / 2.0 * -1.0)))
				{
					val2.VerticalMode = (TextVerticalMode)3;
					val2.HorizontalMode = (TextHorizontalMode)2;
					rotation = num5 - Math.PI;
				}
				else
				{
					val2.VerticalMode = (TextVerticalMode)3;
					val2.HorizontalMode = (TextHorizontalMode)0;
					rotation = num5;
				}
				double num6 = num3 * Math.Cos(num5);
				double num7 = num3 * Math.Sin(num5);
				double num8 = num4 * Math.Cos(Math.PI / 2.0 - num5);
				double num9 = num4 * Math.Sin(Math.PI / 2.0 - num5);
				if (num9 > 0.0)
				{
					num9 *= -1.0;
				}
				if (((num5 > 0.0) & (num5 < num / 2.0)) | ((num5 < 0.0) & (num5 > num / 2.0 * -1.0)))
				{
					num8 *= -1.0;
				}
				if (num5 == num / 2.0)
				{
					num8 *= -1.0;
				}
				Point3d alignmentPoint = new Point3d(point3dAt.X + num6 + num8, point3dAt.Y + num7 + num9, 0.0);
				((Entity)val2).ColorIndex = DeclaracoesGeral.Conf.CorTextoInterligacao;
				((Entity)val2).Layer = layer;
				val2.TextString = texto;
				val2.Height = DeclaracoesGeral.Conf.FonteCabos;
				val2.TextStyleId = textStyleId;
				((Entity)val2).LineWeight = (LineWeight)9;
				val2.AlignmentPoint = alignmentPoint;
				val2.Rotation = rotation;
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
			return val2;
		}
	}

	public static void AlterarCorTamanhoSeparadorTextoAuxiliarVeias()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected Obj, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected Obj, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected Obj, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected Obj, but got Unknown
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 743]), MsgBoxStyle.YesNo);
		if (msgBoxResult == MsgBoxResult.No)
		{
			return;
		}
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
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
					short tipo = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
						if (val6 == null)
						{
							continue;
						}
						string handle = "";
						string THandle = "";
						Entity ent = (Entity)(object)val6;
						string sOpcionais = "";
						bool flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle, ref tipo, ref THandle, ref sOpcionais);
						val6 = (DBText)ent;
						if (!flag)
						{
							continue;
						}
						switch (tipo)
						{
						case 2:
							((DBObject)val6).UpgradeOpen();
							((Entity)val6).ColorIndex = DeclaracoesGeral.Conf.CorTextoInterligacao;
							val6.Height = DeclaracoesGeral.Conf.FonteCabos;
							break;
						case 1:
						{
							string textString = "??";
							Polyline pl = (Polyline)Geral.HandleToObject(handle);
							if (pl != null)
							{
								DeclaracoesEntidades.StructureInterligacao ilig = default;
								if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
								{
									if (!((Operators.CompareString(ilig.Tag_Cabo.Trim(), "", TextCompare: true) == 0) & (ilig.NumVeia == -1000)))
									{
										if (Operators.CompareString(ilig.NomeVeia.Trim(), "", TextCompare: true) != 0)
										{
											if (ilig.ocultaTag != 0)
											{
												if (ilig.ocultaTag == 1)
												{
													textString = " (" + ilig.NomeVeia + ")";
												}
											}
											else
											{
												textString = ilig.Tag_Cabo + " (" + ilig.NomeVeia + ")";
											}
										}
										else if (ilig.ocultaTag != 0)
										{
											if (ilig.ocultaTag == 1)
											{
												textString = ilig.NumVeia.ToString();
											}
										}
										else
										{
											textString = ilig.Tag_Cabo + DeclaracoesGeral.Conf.SeparadorCaboVeia + ilig.NumVeia;
										}
									}
									else
									{
										textString = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
									}
								}
							}
							((DBObject)val6).UpgradeOpen();
							val6.TextString = textString;
							((Entity)val6).ColorIndex = DeclaracoesGeral.Conf.CorTextoInterligacao;
							val6.Height = DeclaracoesGeral.Conf.FonteCabos;
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

	public static void ApagarTextosAuxiliaresVeias(string layer, string handle)
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
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
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
						Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
						if (Operators.CompareString(ent.Layer.ToString(), layer, TextCompare: true) != 0)
						{
							continue;
						}
						DBText val5 = (DBText)(object)((ent is DBText) ? ent : null);
						if (val5 == null)
						{
							BlockReference val6 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
							if (val6 == null && XDataInterligacao.checaXDataAuxInterligacaoEletrosulHandle(ref ent, ref handle))
							{
								((DBObject)ent).UpgradeOpen();
								((DBObject)ent).Erase();
							}
							continue;
						}
						Entity ent2 = (Entity)(object)val5;
						bool flag = XDataInterligacao.checaHandleEntidadeAuxInterligacao(ref ent2, handle);
						val5 = (DBText)ent2;
						if (flag)
						{
							((DBObject)val5).UpgradeOpen();
							((DBObject)val5).Erase();
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
			((IDisposable)val)?.Dispose();
		}
	}

	public static void ApagarPL(string handle)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Polyline pl = (Polyline)Geral.HandleToObject(handle);
				if (pl != null)
				{
					DeclaracoesEntidades.StructureInterligacao ilig = default;
					if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
					{
						ApagarTextosAuxiliaresVeias(((Entity)pl).Layer.ToString(), ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
						((DBObject)pl).UpgradeOpen();
						((DBObject)pl).Erase();
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

	public static void editarCorVeias()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected Obj, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected Obj, but got Unknown
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 742]), MsgBoxStyle.YesNo);
		if (msgBoxResult == MsgBoxResult.No)
		{
			return;
		}
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
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
							Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
							if (pl != null)
							{
								DeclaracoesEntidades.StructureInterligacao ilig = default;
								if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
								{
									((DBObject)pl).UpgradeOpen();
									((Entity)pl).ColorIndex = DeclaracoesGeral.Conf.CorInterligacao;
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
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					val2.Abort();
					throw;
				}
				finally
				{
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

	public static void editarEstiloVeias()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected Obj, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected Obj, but got Unknown
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1880]), MsgBoxStyle.YesNo);
		if (msgBoxResult == MsgBoxResult.No)
		{
			return;
		}
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					ClsCabos.CriaEstiloDeLinha(ref DeclaracoesGeral.Conf.EstiloLinha, DeclaracoesGeral.Conf.EstiloLinhaEscala);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)1);
							Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
							if (pl != null)
							{
								DeclaracoesEntidades.StructureInterligacao ilig = default;
								if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
								{
									((DBObject)pl).UpgradeOpen();
									((Entity)pl).Linetype = DeclaracoesGeral.Conf.EstiloLinha;
									((Entity)pl).LinetypeScale = DeclaracoesGeral.Conf.EstiloLinhaEscala;
									((Entity)pl).Draw();
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
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					val2.Abort();
					throw;
				}
				finally
				{
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

	public static void SincronizaCruzamentoInterlig()
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected Obj, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected Obj, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected Obj, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected Obj, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				DeclaracoesGeral.Reguas RH = default;
				bool flag = false;
				DeclaracoesGeral.Reguas RH2 = default;
				bool flag2 = false;
				flag = XDataGeral.LeXDataReguaH(ref RH);
				flag2 = XDataGeral.LeXDataReguaV(ref RH2);
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					short tipo = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
						if (val6 == null)
						{
							continue;
						}
						string handle = "";
						string THandle = "";
						Entity ent = (Entity)(object)val6;
						string sOpcionais = "";
						bool flag3 = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle, ref tipo, ref THandle, ref sOpcionais);
						val6 = (DBText)ent;
						if (!flag3 || tipo != 2)
						{
							continue;
						}
						DBText val7 = (DBText)Geral.HandleToObject(THandle);
						if (val7 != null)
						{
							((DBObject)val6).UpgradeOpen();
							if (!Information.IsNothing(val7))
							{
								DBText val8 = val6;
								string pagina = ((Entity)val7).Layer.ToString();
								ent = (Entity)(object)val7;
								sOpcionais = Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2);
								val7 = (DBText)ent;
								val8.TextString = Pagina.montaCruzamentoPagina(pagina, sOpcionais);
							}
							else
							{
								val6.TextString = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
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

	public static void RecriaOCruzamentoInterligTipo2Apagados()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected Obj, but got Unknown
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Expected Obj, but got Unknown
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Expected Obj, but got Unknown
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected Obj, but got Unknown
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected Obj, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected Obj, but got Unknown
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a4: Expected Obj, but got Unknown
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Expected Obj, but got Unknown
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_043e: Expected Obj, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Expected Obj, but got Unknown
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected Obj, but got Unknown
		//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_053c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0547: Unknown result type (might be due to invalid IL or missing references)
		//IL_054e: Expected Obj, but got Unknown
		//IL_0557: Unknown result type (might be due to invalid IL or missing references)
		//IL_0562: Unknown result type (might be due to invalid IL or missing references)
		//IL_0569: Expected Obj, but got Unknown
		//IL_0579: Unknown result type (might be due to invalid IL or missing references)
		//IL_057e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0582: Unknown result type (might be due to invalid IL or missing references)
		//IL_058a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0591: Expected Obj, but got Unknown
		//IL_05a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_061c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0623: Expected Obj, but got Unknown
		//IL_0671: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06db: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0702: Expected Obj, but got Unknown
		//IL_070a: Unknown result type (might be due to invalid IL or missing references)
		//IL_070f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0721: Unknown result type (might be due to invalid IL or missing references)
		//IL_0726: Unknown result type (might be due to invalid IL or missing references)
		//IL_0741: Unknown result type (might be due to invalid IL or missing references)
		//IL_0748: Expected Obj, but got Unknown
		//IL_079a: Unknown result type (might be due to invalid IL or missing references)
		//IL_079f: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bc: Unknown result type (might be due to invalid IL or missing references)
		List<string> list = new List<string>();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
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
					short tipo = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
						if (val6 == null)
						{
							continue;
						}
						string handle = "";
						string THandle = "";
						Entity ent = (Entity)(object)val6;
						string sOpcionais = "";
						bool flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle, ref tipo, ref THandle, ref sOpcionais);
						val6 = (DBText)ent;
						if (flag && tipo == 2)
						{
							string item = handle + "|" + THandle;
							if (!list.Contains(item))
							{
								list.Add(item);
								continue;
							}
							((DBObject)val6).UpgradeOpen();
							((DBObject)val6).Erase();
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
		DocumentLock val7 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database2 = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val8 = database2.TransactionManager.StartTransaction();
			try
			{
				BlockTable val9 = (BlockTable)val8.GetObject(database2.BlockTableId, (OpenMode)0);
				BlockTableRecord val10 = (BlockTableRecord)val8.GetObject(((SymbolTable)val9)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator2 = default;
				try
				{
					enumerator2 = val10.GetEnumerator();
					short tipo2 = default;
					while (enumerator2.MoveNext())
					{
						ObjectId current2 = enumerator2.Current;
						Entity val11 = (Entity)val8.GetObject(current2, (OpenMode)0);
						DBText val12 = (DBText)(object)((val11 is DBText) ? val11 : null);
						if (val12 == null)
						{
							continue;
						}
						string handle2 = "";
						string THandle2 = "";
						Entity ent = (Entity)(object)val12;
						string sOpcionais = "";
						bool flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle2, ref tipo2, ref THandle2, ref sOpcionais);
						val12 = (DBText)ent;
						if (!flag || tipo2 != 2)
						{
							continue;
						}
						DBText val13 = (DBText)Geral.HandleToObject(THandle2);
						if (val13 != null)
						{
							if (Operators.CompareString(val12.TextString, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) == 0)
							{
								((DBObject)val12).UpgradeOpen();
								((DBObject)val12).Erase();
							}
						}
						else
						{
							((DBObject)val12).UpgradeOpen();
							((DBObject)val12).Erase();
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
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
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
		DeclaracoesGeral.Reguas RH = default;
		bool flag2 = false;
		DeclaracoesGeral.Reguas RH2 = default;
		bool flag3 = false;
		flag2 = XDataGeral.LeXDataReguaH(ref RH);
		flag3 = XDataGeral.LeXDataReguaV(ref RH2);
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		List<string> list4 = new List<string>();
		int num = 0;
		DocumentLock val14 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database3 = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val15 = database3.TransactionManager.StartTransaction();
			try
			{
				BlockTable val16 = (BlockTable)val15.GetObject(database3.BlockTableId, (OpenMode)0);
				BlockTableRecord val17 = (BlockTableRecord)val15.GetObject(((SymbolTable)val16)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator3 = default;
				try
				{
					enumerator3 = val17.GetEnumerator();
					short tipo3 = default;
					while (enumerator3.MoveNext())
					{
						ObjectId current3 = enumerator3.Current;
						Entity val18 = (Entity)val15.GetObject(current3, (OpenMode)0);
						DBText val19 = (DBText)(object)((val18 is DBText) ? val18 : null);
						if (val19 == null)
						{
							Polyline pl = (Polyline)(object)((val18 is Polyline) ? val18 : null);
							if (pl != null)
							{
								DeclaracoesEntidades.StructureInterligacao ilig = default;
								if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) && ilig.Tipo == 2)
								{
									list3.Add(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
								}
							}
							continue;
						}
						string handle3 = "";
						string THandle3 = "";
						Entity ent = (Entity)(object)val19;
						string sOpcionais = "";
						bool flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle3, ref tipo3, ref THandle3, ref sOpcionais);
						val19 = (DBText)ent;
						if (flag && tipo3 == 2)
						{
							list2.Add(handle3);
						}
					}
				}
				finally
				{
					((IDisposable)enumerator3)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val15.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				foreach (string item2 in list3)
				{
					if (!list2.Contains(item2))
					{
						list4.Add(item2);
						num = checked(num + 1);
					}
				}
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				val15.Abort();
				throw;
			}
			finally
			{
				((IDisposable)val15)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val14)?.Dispose();
		}
		if (num <= 0)
		{
			return;
		}
		list3.Clear();
		DocumentLock val20 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database4 = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val21 = database4.TransactionManager.StartTransaction();
			try
			{
				if (num <= 0)
				{
					return;
				}
				BlockTable val22 = (BlockTable)val21.GetObject(database4.BlockTableId, (OpenMode)1);
				BlockTableRecord val23 = (BlockTableRecord)val21.GetObject(((SymbolTable)val22)[BlockTableRecord.ModelSpace], (OpenMode)1);
				BlockTableRecordEnumerator enumerator5 = default;
				try
				{
					enumerator5 = val23.GetEnumerator();
					while (enumerator5.MoveNext())
					{
						ObjectId current5 = enumerator5.Current;
						Entity ent2 = (Entity)val21.GetObject(current5, (OpenMode)1);
						Polyline pl2 = (Polyline)(object)((ent2 is Polyline) ? ent2 : null);
						if (pl2 == null || !list4.Contains(((object)((DBObject)pl2).Handle/*cast due to constrained. prefix*/).ToString()) || list3.Contains(((object)((DBObject)pl2).Handle/*cast due to constrained. prefix*/).ToString()))
						{
							continue;
						}
						DeclaracoesEntidades.StructureInterligacao ilig2 = default;
						if (!XDataInterligacao.lerXDataInterligacao(ref pl2, ref ilig2) || ilig2.Tipo != 2)
						{
							continue;
						}
						Polyline pl3 = (Polyline)Geral.HandleToObject(ilig2.handle);
						if (pl3 != null)
						{
							DeclaracoesEntidades.StructureInterligacao ilig3 = default;
							if (XDataInterligacao.lerXDataInterligacao(ref pl3, ref ilig3) && ilig3.Tipo == 2)
							{
								DBText val24 = criarTextoCruzamentoCabo(pl2, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, ((Entity)pl2).Layer, 1);
								val23.AppendEntity((Entity)(object)val24);
								DeclaracoesGeral.bAnularEventos = true;
								val21.AddNewlyCreatedDBObject((DBObject)(object)val24, true);
								DBText val25 = criarTextoCruzamentoCabo(pl3, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, ((Entity)pl3).Layer, 2);
								val23.AppendEntity((Entity)(object)val25);
								DeclaracoesGeral.bAnularEventos = true;
								val21.AddNewlyCreatedDBObject((DBObject)(object)val25, true);
								Entity ent = (Entity)(object)val24;
								XDataInterligacao.GravarXDataAuxInterligacao(ref ent, ((object)((DBObject)pl2).Handle/*cast due to constrained. prefix*/).ToString(), 2, ((object)((DBObject)val25).Handle/*cast due to constrained. prefix*/).ToString());
								val24 = (DBText)ent;
								ent = (Entity)(object)val25;
								XDataInterligacao.GravarXDataAuxInterligacao(ref ent, ((object)((DBObject)pl3).Handle/*cast due to constrained. prefix*/).ToString(), 2, ((object)((DBObject)val24).Handle/*cast due to constrained. prefix*/).ToString());
								val25 = (DBText)ent;
								val25.TextString = Pagina.montaCruzamentoPagina(((Entity)pl2).Layer.ToString(), Pagina.calculaLinhaColuna(ref ent2, ref RH, ref RH2, flag2, flag3));
								val24.TextString = Pagina.montaCruzamentoPagina(((Entity)pl3).Layer.ToString(), Pagina.calculaLinhaColuna(ref ent2, ref RH, ref RH2, flag2, flag3));
								list3.Add(((object)((DBObject)pl2).Handle/*cast due to constrained. prefix*/).ToString());
								list3.Add(((object)((DBObject)pl3).Handle/*cast due to constrained. prefix*/).ToString());
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator5)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val21.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception projectError4)
			{
				ProjectData.SetProjectError(projectError4);
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val21)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val20)?.Dispose();
		}
	}

	public static void IndefineTodasAsVeiasDoDesnho()
	{
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected Obj, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Expected Obj, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected Obj, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected Obj, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Expected Obj, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected Obj, but got Unknown
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected Obj, but got Unknown
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1282]), MsgBoxStyle.YesNo);
		if (msgBoxResult != MsgBoxResult.Yes)
		{
			return;
		}
		msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1283]), MsgBoxStyle.YesNo);
		if (msgBoxResult == MsgBoxResult.No)
		{
			return;
		}
		PointMonitorToolTips.StopMonitor();
		List<string> list = new List<string>();
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
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
							Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
							if (pl == null)
							{
								continue;
							}
							DeclaracoesEntidades.StructureInterligacao ilig = default;
							if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
							{
								if (!list.Contains(ilig.Tag_Cabo))
								{
									list.Add(ilig.Tag_Cabo);
								}
								ilig.Tag_Cabo = "";
								ilig.NumVeia = -1000;
								ilig.NomeVeia = "";
								ilig.ocultaTag = 0;
								((DBObject)pl).UpgradeOpen();
								XDataInterligacao.AtualizaXDataInterligacao(ref pl, ref ilig);
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
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		try
		{
			DocumentLock val6 = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database2 = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val7 = database2.TransactionManager.StartTransaction();
				try
				{
					BlockTable val8 = (BlockTable)val7.GetObject(database2.BlockTableId, (OpenMode)0);
					BlockTableRecord val9 = (BlockTableRecord)val7.GetObject(((SymbolTable)val8)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator2 = default;
					try
					{
						enumerator2 = val9.GetEnumerator();
						short tipo = default;
						while (enumerator2.MoveNext())
						{
							ObjectId current2 = enumerator2.Current;
							Entity val10 = (Entity)val7.GetObject(current2, (OpenMode)0);
							DBText val11 = (DBText)(object)((val10 is DBText) ? val10 : null);
							if (val11 != null)
							{
								string handle = "";
								string THandle = "";
								Entity ent = (Entity)(object)val11;
								string sOpcionais = "";
								bool flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle, ref tipo, ref THandle, ref sOpcionais);
								val11 = (DBText)ent;
								if (flag && tipo == 1)
								{
									((DBObject)val11).UpgradeOpen();
									val11.TextString = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
								}
							}
						}
					}
					finally
					{
						((IDisposable)enumerator2)?.Dispose();
					}
					DeclaracoesGeral.bAnularEventos = true;
					val7.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					val7.Abort();
					throw;
				}
				finally
				{
					((IDisposable)val7)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val6)?.Dispose();
			}
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			ProjectData.ClearProjectError();
		}
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		checked
		{
			int num = list.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				cDadosAccessInterligacao3.RemoveCaboErro(list[i]);
			}
			cDadosAccessInterligacao3.FechaConexao();
			PointMonitorToolTips.StartMonitor();
		}
	}

	public static void OcultaTodasAsVeiasDoDesnho(ref bool bVisivelVeia)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected Obj, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected Obj, but got Unknown
		PointMonitorToolTips.StopMonitor();
		List<string> list = new List<string>();
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
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						short tipo = default;
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
							DBText val5 = (DBText)(object)((ent is DBText) ? ent : null);
							string sHandle;
							if (val5 == null)
							{
								sHandle = "";
								if (XDataInterligacao.lerXDataAuxInterligacaoEletrosul(ref ent, ref sHandle) | XDataInterligacao.lerXDataAuxInterligacaoENEL(ref ent))
								{
									((DBObject)ent).UpgradeOpen();
									ent.Visible = bVisivelVeia;
								}
								continue;
							}
							string handle = "";
							string THandle = "";
							Entity ent2 = (Entity)(object)val5;
							sHandle = "";
							bool flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent2, ref handle, ref tipo, ref THandle, ref sHandle);
							val5 = (DBText)ent2;
							if (!flag)
							{
								continue;
							}
							if (!((tipo == 1) | (tipo == 3) | (tipo == 4) | (tipo == 5) | (tipo == 6)))
							{
								if (tipo == 2 && bVisivelVeia)
								{
									((DBObject)val5).UpgradeOpen();
									((Entity)val5).Visible = bVisivelVeia;
								}
							}
							else
							{
								((DBObject)val5).UpgradeOpen();
								((Entity)val5).Visible = bVisivelVeia;
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
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		checked
		{
			int num = list.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				cDadosAccessInterligacao3.RemoveCaboErro(list[i]);
			}
			cDadosAccessInterligacao3.FechaConexao();
			PointMonitorToolTips.StartMonitor();
		}
	}

	public static void SelecionaEIndefineUmaVeia()
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected Obj, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected Obj, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected Obj, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Invalid comparison between Unknown and I4
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected Obj, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected Obj, but got Unknown
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				TypedValue[] array = new TypedValue[1];
				array.SetValue((object)new TypedValue(1001, (object)"INTERLIGACAO"), 0);
				SelectionFilter val4 = new SelectionFilter(array);
				PromptSelectionOptions val5 = new PromptSelectionOptions();
				val5.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 877]);
				PromptSelectionResult selection = editor.GetSelection(val5, val4);
				if ((int)selection.Status == 5100)
				{
					SelectionSet value = selection.Value;
					ObjectIdCollection val6 = new ObjectIdCollection(value.GetObjectIds());
					if (val6.Count == 0)
					{
						goto IL_01fd;
					}
					foreach (object item in val6)
					{
						ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						Entity val8 = (Entity)val7.GetObject((OpenMode)0);
						Polyline pl = (Polyline)(object)((val8 is Polyline) ? val8 : null);
						DeclaracoesEntidades.StructureInterligacao ilig = default;
						if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
						{
							IndefineumVeia(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
							if (ilig.Tipo == 2)
							{
								IndefineumVeia(ilig.handle);
							}
						}
					}
				}
				Form form = Application.OpenForms["frmPesquisaVeiasIndefinidas"];
				if (!Information.IsNothing(form))
				{
					frmPesquisaVeiasIndefinidas frmPesquisaVeiasIndefinidas2 = (frmPesquisaVeiasIndefinidas)form;
					frmPesquisaVeiasIndefinidas2.CarregaNovamenteAsVeias();
				}
				goto IL_01fd;
				IL_01fd:
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				val2.Abort();
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
			((IDisposable)val)?.Dispose();
		}
		PointMonitorToolTips.StartMonitor();
	}

	public static void IndefineUmCabo(List<string> lCabos)
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
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
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
						Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
						if (pl != null)
						{
							DeclaracoesEntidades.StructureInterligacao ilig = default;
							if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) && lCabos.Contains(ilig.Tag_Cabo))
							{
								ilig.Tag_Cabo = "";
								ilig.NumVeia = -1000;
								ilig.NomeVeia = "";
								((DBObject)pl).UpgradeOpen();
								XDataInterligacao.AtualizaXDataInterligacao(ref pl, ref ilig);
								IndefineTextosAuxiliaresVeias(((Entity)pl).Layer.ToString(), ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
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

	public static void IndefineumVeia(string sHandleLinha)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected Obj, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					Polyline pl = (Polyline)Geral.HandleToObject(sHandleLinha);
					if (pl != null)
					{
						DeclaracoesEntidades.StructureInterligacao ilig = default;
						if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
						{
							ilig.Tag_Cabo = "";
							ilig.NumVeia = -1000;
							ilig.NomeVeia = "";
							ilig.ocultaTag = 0;
							((DBObject)pl).UpgradeOpen();
							XDataInterligacao.AtualizaXDataInterligacao(ref pl, ref ilig);
							IndefineTextosAuxiliaresVeias(((Entity)pl).Layer.ToString(), ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
							string sHandle = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
							cDadosAccessInterligacao3.IndefineUmaVeiaDeUmCabo(ref sHandle);
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
					cDadosAccessInterligacao3.FechaConexao();
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

	public static void DeixaVisivelOsTextosInterligacao(string sHandleLinha)
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
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
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
					short tipo = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						if (Operators.CompareString(val5.Layer.ToString(), DeclaracoesGeral.ativo.Pagina, TextCompare: true) != 0)
						{
							continue;
						}
						DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
						if (val6 != null)
						{
							string handle = "";
							string THandle = "";
							Entity ent = (Entity)(object)val6;
							string sOpcionais = "";
							bool flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle, ref tipo, ref THandle, ref sOpcionais);
							val6 = (DBText)ent;
							if (flag && ((Operators.CompareString(handle, sHandleLinha, TextCompare: true) == 0) | (Operators.CompareString(THandle, sHandleLinha, TextCompare: true) == 0)))
							{
								((DBObject)val6).UpgradeOpen();
								((Entity)val6).Visible = true;
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

	public static void DeixaVisivelOsTextosCircuito(string sHandleLinha)
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
						if (Operators.CompareString(val5.Layer.ToString(), DeclaracoesGeral.ativo.Pagina, TextCompare: true) != 0)
						{
							continue;
						}
						DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
						if (val6 == null)
						{
							continue;
						}
						ResultBuffer val7 = null;
						val7 = ((DBObject)val6).GetXDataForApplication("AUXCONEXAO");
						if (val7 != null)
						{
							TypedValue[] array = val7.AsArray();
							string left = array[3].Value.ToString();
							if (Operators.CompareString(left, sHandleLinha, TextCompare: true) == 0)
							{
								((DBObject)val6).UpgradeOpen();
								((Entity)val6).Visible = true;
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

	public static void AtribuiUmaVeia(string sHandleLinha, string Tag_Cabo, int NumVeia, string NomeVeia, bool bNomeVisivel)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Entity val4 = (Entity)Geral.HandleToObject(sHandleLinha);
				if (val4 != null)
				{
					Polyline pl = (Polyline)(object)((val4 is Polyline) ? val4 : null);
					if (pl != null)
					{
						DeclaracoesEntidades.StructureInterligacao ilig = default;
						if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) && ilig.NumVeia == -1000)
						{
							ilig.Tag_Cabo = Tag_Cabo;
							ilig.NumVeia = NumVeia;
							ilig.NomeVeia = NomeVeia;
							ilig.ocultaTag = 1;
							if (bNomeVisivel)
							{
								ilig.ocultaTag = 0;
							}
							((DBObject)pl).UpgradeOpen();
							XDataInterligacao.AtualizaXDataInterligacao(ref pl, ref ilig);
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
	}

	public static void IndefineTextosAuxiliaresVeias(string layer, string handle)
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
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
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
					short tipo = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						if (Operators.CompareString(val5.Layer.ToString(), layer, TextCompare: true) != 0)
						{
							continue;
						}
						DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
						if (val6 != null)
						{
							string handle2 = "";
							string THandle = "";
							Entity ent = (Entity)(object)val6;
							string sOpcionais = "";
							bool flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle2, ref tipo, ref THandle, ref sOpcionais);
							val6 = (DBText)ent;
							if (flag && ((tipo == 1) & (Operators.CompareString(handle2, handle, TextCompare: true) == 0)))
							{
								((DBObject)val6).UpgradeOpen();
								val6.TextString = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
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

	public static void AtivaHighlight(List<string> list)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected Obj, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
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
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
							if (list.Contains(((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString()))
							{
								val5.Highlight();
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
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static void AtivaUmaHighlightZoom(string sHandle)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
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
					_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					Entity val4 = (Entity)Geral.HandleToObject(sHandle);
					if (val4 != null)
					{
						Pagina.AtivaPagina(val4.Layer);
						uscPaginas uscPagina = DeclaracoesGeral._uscPagina;
						string pag = val4.Layer.ToString();
						uscPagina.ativaPaginaAtalho(ref pag);
						Caderno.ZEntity(((DBObject)val4).ObjectId, 20);
						val4.Highlight();
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
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
	}

	public static void selecionaTextoDeVeias(ref bool bLiga)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected Obj, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected Obj, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected Obj, but got Unknown
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Invalid comparison between Unknown and I4
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected Obj, but got Unknown
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected Obj, but got Unknown
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Expected Obj, but got Unknown
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Expected Obj, but got Unknown
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Expected Obj, but got Unknown
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Expected Obj, but got Unknown
		//IL_0420: Unknown result type (might be due to invalid IL or missing references)
		//IL_0425: Unknown result type (might be due to invalid IL or missing references)
		//IL_0456: Unknown result type (might be due to invalid IL or missing references)
		//IL_045d: Expected Obj, but got Unknown
		//IL_0472: Unknown result type (might be due to invalid IL or missing references)
		//IL_0477: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		List<string> list = new List<string>();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				TypedValue[] array = new TypedValue[4];
				array.SetValue((object)new TypedValue(-4, (object)"<OR"), 0);
				array.SetValue((object)new TypedValue(1001, (object)"AUXINTERLIG"), 1);
				array.SetValue((object)new TypedValue(1001, (object)"INTERLIGACAO"), 2);
				array.SetValue((object)new TypedValue(-4, (object)"OR>"), 3);
				SelectionFilter val4 = new SelectionFilter(array);
				PromptSelectionOptions val5 = new PromptSelectionOptions();
				val5.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 877]);
				PromptSelectionResult selection = editor.GetSelection(val5, val4);
				if ((int)selection.Status == 5100)
				{
					SelectionSet value = selection.Value;
					ObjectIdCollection val6 = new ObjectIdCollection(value.GetObjectIds());
					if (val6.Count != 0)
					{
						short tipo = default;
						short tipo2 = default;
						foreach (object item in val6)
						{
							ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							Entity val8 = (Entity)val7.GetObject((OpenMode)0);
							DBText val9 = (DBText)(object)((val8 is DBText) ? val8 : null);
							if (val9 == null)
							{
								Polyline pl = (Polyline)(object)((val8 is Polyline) ? val8 : null);
								if (pl == null)
								{
									continue;
								}
								DeclaracoesEntidades.StructureInterligacao ilig = default;
								if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
								{
									LigaDesligaTextosAuxiliaresVeias(pl, bLiga);
									ilig.ocultaTag = 1;
									if (bLiga)
									{
										ilig.ocultaTag = 0;
									}
									((DBObject)pl).UpgradeOpen();
									XDataInterligacao.AtualizaXDataInterligacao(ref pl, ref ilig);
								}
								continue;
							}
							string handle = "";
							string THandle = "";
							Entity ent = (Entity)(object)val9;
							string sOpcionais = "";
							bool flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle, ref tipo, ref THandle, ref sOpcionais);
							val9 = (DBText)ent;
							if (!flag)
							{
								continue;
							}
							if (tipo == 1)
							{
								Entity val10 = (Entity)Geral.HandleToObject(handle);
								if (val10 != null)
								{
									Polyline pl2 = (Polyline)(object)((val10 is Polyline) ? val10 : null);
									if (pl2 != null)
									{
										DeclaracoesEntidades.StructureInterligacao ilig2 = default;
										if (XDataInterligacao.lerXDataInterligacao(ref pl2, ref ilig2))
										{
											string text = "";
											if (DeclaracoesGeral.Conf.InterligacaoLayout != 3)
											{
												if (Operators.CompareString(ilig2.NomeVeia, "", TextCompare: true) == 0)
												{
													text = ilig2.NumVeia.ToString();
													if (bLiga)
													{
														text = ilig2.Tag_Cabo + DeclaracoesGeral.Conf.SeparadorCaboVeia + text;
													}
												}
												else
												{
													text = "(" + ilig2.NomeVeia + ")";
													if (bLiga)
													{
														text = ilig2.Tag_Cabo + " " + text;
													}
												}
												if (ilig2.NumVeia == -1000)
												{
													text = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
												}
												if (ilig2.ocultaTag == 1 && Operators.CompareString(val9.TextString, text, TextCompare: true) == 0)
												{
													text = ilig2.Tag_Cabo;
												}
											}
											else
											{
												text = ilig2.NomeVeia;
												if (Operators.CompareString(text, "", TextCompare: true) == 0)
												{
													text = ilig2.NumVeia.ToString();
												}
												if (ilig2.ocultaTag == 0)
												{
													text = ilig2.Tag_Cabo + " " + text;
												}
												if (ilig2.NumVeia == -1000)
												{
													text = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
												}
											}
											ilig2.ocultaTag = 1;
											if (bLiga)
											{
												ilig2.ocultaTag = 0;
											}
											clsTextos.AtualizaUmTexto(((object)((DBObject)val9).Handle/*cast due to constrained. prefix*/).ToString(), text);
											if (ilig2.Tipo == 2)
											{
												Entity val11 = (Entity)Geral.HandleToObject(ilig2.handle);
												if (val11 != null)
												{
													Polyline val12 = (Polyline)(object)((val11 is Polyline) ? val11 : null);
													string sHandle = retornaOHandleTextosAuxiliaresVeias(((object)((DBObject)val12).Handle/*cast due to constrained. prefix*/).ToString(), 1);
													clsTextos.AtualizaUmTexto(sHandle, text);
												}
											}
										}
										((DBObject)pl2).UpgradeOpen();
										XDataInterligacao.AtualizaXDataInterligacao(ref pl2, ref ilig2);
									}
								}
							}
							if (list.Contains(((object)((DBObject)val9).Handle/*cast due to constrained. prefix*/).ToString()))
							{
								continue;
							}
							string handle2 = "";
							ent = (Entity)(object)val9;
							sOpcionais = "";
							string sOpcionais2 = "";
							flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle2, ref tipo2, ref sOpcionais, ref sOpcionais2);
							val9 = (DBText)ent;
							if (!flag || !((tipo == 4) | (tipo == 5) | (tipo == 2)))
							{
								continue;
							}
							((DBObject)val9).UpgradeOpen();
							((Entity)val9).Visible = bLiga;
							list.Add(((object)((DBObject)val9).Handle/*cast due to constrained. prefix*/).ToString());
							Polyline pl3 = (Polyline)Geral.HandleToObject(handle2);
							if (pl3 == null)
							{
								continue;
							}
							DeclaracoesEntidades.StructureInterligacao ilig3 = default;
							if (XDataInterligacao.lerXDataInterligacao(ref pl3, ref ilig3))
							{
								if (!bLiga)
								{
									ilig3.ocultaTag = 1;
								}
								else
								{
									ilig3.ocultaTag = 0;
								}
								((DBObject)pl3).UpgradeOpen();
								XDataInterligacao.AtualizaXDataInterligacao(ref pl3, ref ilig3);
							}
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				val2.Abort();
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
			((IDisposable)val)?.Dispose();
		}
		PointMonitorToolTips.StartMonitor();
	}

	public static string retornaOHandleTextosAuxiliaresVeias(string handleLine, int tipo)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected Obj, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
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
					short tipo2 = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
						if (val6 != null)
						{
							string handle = "";
							string THandle = "";
							Entity ent = (Entity)(object)val6;
							string sOpcionais = "";
							bool flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle, ref tipo2, ref THandle, ref sOpcionais);
							val6 = (DBText)ent;
							if (flag && Operators.CompareString(handle, handleLine, TextCompare: true) == 0 && tipo2 == tipo)
							{
								result = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
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

	public static void LigaDesligaTextosAuxiliaresVeias(Polyline pl, bool bliga)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				string right = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					short tipo = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
						if (val6 == null)
						{
							continue;
						}
						string handle = "";
						string THandle = "";
						Entity ent = (Entity)(object)val6;
						string sOpcionais = "";
						bool flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle, ref tipo, ref THandle, ref sOpcionais);
						val6 = (DBText)ent;
						if (!flag || Operators.CompareString(handle, right, TextCompare: true) != 0)
						{
							continue;
						}
						if (!bliga)
						{
							if ((tipo == 4) | (tipo == 5))
							{
								((DBObject)val6).UpgradeOpen();
								((Entity)val6).Visible = bliga;
							}
						}
						else
						{
							((DBObject)val6).UpgradeOpen();
							((Entity)val6).Visible = bliga;
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
			((IDisposable)val)?.Dispose();
		}
	}

	public static string SelecionaAsVeiasDaPagina(ref structureVeiasCaderno[] VeiasCaderno, clsTextos.structureTextoCaderno[] TextoCabo, bool bOrdenaDeSelecao)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected Obj, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected Obj, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected Obj, but got Unknown
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Invalid comparison between Unknown and I4
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected Obj, but got Unknown
		//IL_06df: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected Obj, but got Unknown
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Unknown result type (might be due to invalid IL or missing references)
		//IL_0495: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04db: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0540: Unknown result type (might be due to invalid IL or missing references)
		//IL_0545: Unknown result type (might be due to invalid IL or missing references)
		//IL_0564: Unknown result type (might be due to invalid IL or missing references)
		//IL_0569: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0606: Expected Obj, but got Unknown
		//IL_03a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Expected Obj, but got Unknown
		//IL_0654: Unknown result type (might be due to invalid IL or missing references)
		//IL_0659: Unknown result type (might be due to invalid IL or missing references)
		//IL_0678: Unknown result type (might be due to invalid IL or missing references)
		//IL_067d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		VeiasCaderno = new structureVeiasCaderno[1];
		structureVeiasCaderno[] array = new structureVeiasCaderno[1];
		PointMonitorToolTips.StopMonitor();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
					TypedValue[] array2 = new TypedValue[1];
					array2.SetValue((object)new TypedValue(1001, (object)"INTERLIGACAO"), 0);
					SelectionFilter val4 = new SelectionFilter(array2);
					PromptSelectionOptions val5 = new PromptSelectionOptions();
					val5.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 877]);
					PromptSelectionResult selection = editor.GetSelection(val5, val4);
					if (unchecked((int)selection.Status) == 5100)
					{
						SelectionSet value = selection.Value;
						ObjectIdCollection val6 = new ObjectIdCollection(value.GetObjectIds());
						if (val6.Count != 0)
						{
							foreach (object item in val6)
							{
								ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
								Entity val8 = (Entity)val7.GetObject((OpenMode)0);
								try
								{
									Polyline pl = (Polyline)(object)((val8 is Polyline) ? val8 : null);
									if (pl == null)
									{
										continue;
									}
									DeclaracoesEntidades.StructureInterligacao ilig = default;
									if (!XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) || ilig.NumVeia != -1000)
									{
										continue;
									}
									int num = Information.UBound(array) + 1;
									array = (structureVeiasCaderno[])Utils.CopyArray(array, new structureVeiasCaderno[num + 1]);
									array[num].sTag = ilig.Tag_Cabo;
									array[num].iIndice = ilig.NumVeia;
									array[num].sNomeVeia = ilig.NomeVeia;
									array[num].iArquivo = DeclaracoesGeral.arqAtivo.Indice;
									array[num].sPagina = ((Entity)pl).Layer.ToString();
									array[num].iPn1 = ilig.Painel1;
									array[num].sHandleCabo1 = "";
									array[num].sHandleTag1 = "";
									array[num].iPn2 = ilig.Painel2;
									array[num].sHandleCabo2 = "";
									array[num].sHandleTag2 = "";
									if (ilig.Painel1 != 0)
									{
										array[num].sHandleCabo1 = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
										array[num].sHandleTag1 = clsTextos.EncontraTextoDoCabo(TextoCabo, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
										array[num].sPagina = ((Entity)pl).Layer.ToString();
									}
									if ((ilig.Painel2 != 0) & (ilig.Tipo == 2))
									{
										array[num].sHandleCabo2 = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
										array[num].sHandleTag2 = clsTextos.EncontraTextoDoCabo(TextoCabo, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
										array[num].sPagina2 = ((Entity)pl).Layer.ToString();
									}
									if (ilig.Tipo == 3)
									{
										array[num].sHandleCabo1 = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
										array[num].sHandleTag1 = clsTextos.EncontraTextoDoCabo(TextoCabo, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
										array[num].sPagina = ((Entity)pl).Layer.ToString();
									}
									array[num].iTipo = ilig.Tipo;
									ref structureVeiasCaderno reference = ref array[num];
									Extents3d value2 = ((Drawable)pl).Bounds.Value;
									Point3d minPoint = value2.MinPoint;
									reference.X = (int)Math.Round(minPoint.X);
									ref structureVeiasCaderno reference2 = ref array[num];
									value2 = ((Drawable)pl).Bounds.Value;
									minPoint = value2.MinPoint;
									reference2.Y = (int)Math.Round(minPoint.Y);
									if (ilig.Tipo == 3 && ((array[num].iPn1 == 0) & (array[num].iPn2 != 0)))
									{
										array[num].iPn1 = array[num].iPn2;
										array[num].iPn2 = 0;
									}
									if (ilig.Tipo != 2)
									{
										continue;
									}
									if (ilig.Painel1 == 0)
									{
										Entity val9 = (Entity)Geral.HandleToObject(ilig.handle);
										try
										{
											if (val9 != null)
											{
												Polyline pl2 = (Polyline)(object)((val9 is Polyline) ? val9 : null);
												if (pl2 != null)
												{
													DeclaracoesEntidades.StructureInterligacao ilig2 = default;
													if (XDataInterligacao.lerXDataInterligacao(ref pl2, ref ilig2))
													{
														array[num].iPn1 = ilig2.Painel1;
														array[num].sHandleCabo1 = ((object)((DBObject)pl2).Handle/*cast due to constrained. prefix*/).ToString();
														array[num].sHandleTag1 = clsTextos.EncontraTextoDoCabo(TextoCabo, ((object)((DBObject)pl2).Handle/*cast due to constrained. prefix*/).ToString());
														array[num].sPagina = ((Entity)pl2).Layer.ToString();
													}
												}
											}
										}
										finally
										{
											((IDisposable)val9)?.Dispose();
										}
									}
									if (ilig.Painel2 != 0)
									{
										continue;
									}
									Entity val10 = (Entity)Geral.HandleToObject(ilig.handle);
									try
									{
										if (val10 == null)
										{
											continue;
										}
										Polyline pl3 = (Polyline)(object)((val10 is Polyline) ? val10 : null);
										if (pl3 != null)
										{
											DeclaracoesEntidades.StructureInterligacao ilig3 = default;
											if (XDataInterligacao.lerXDataInterligacao(ref pl3, ref ilig3))
											{
												array[num].iPn2 = ilig3.Painel2;
												array[num].sHandleCabo2 = ((object)((DBObject)pl3).Handle/*cast due to constrained. prefix*/).ToString();
												array[num].sHandleTag2 = clsTextos.EncontraTextoDoCabo(TextoCabo, ((object)((DBObject)pl3).Handle/*cast due to constrained. prefix*/).ToString());
												array[num].sPagina2 = ((Entity)pl3).Layer.ToString();
											}
										}
									}
									finally
									{
										((IDisposable)val10)?.Dispose();
									}
								}
								finally
								{
									((IDisposable)val8)?.Dispose();
								}
							}
						}
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					val2.Abort();
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
				((IDisposable)val)?.Dispose();
			}
			PointMonitorToolTips.StartMonitor();
			List<string> list = new List<string>();
			if (Information.UBound(array) >= 1)
			{
				int iPn = array[1].iPn1;
				int iPn2 = array[1].iPn2;
				int num2 = 1;
				int num3 = 2;
				if (array[1].iTipo != 3)
				{
					result = "C";
				}
				else
				{
					result = "B";
					num2 = 3;
					num2 = 3;
				}
				int num4 = Information.UBound(array);
				for (int i = 0; i <= num4; i++)
				{
					if (((array[i].iTipo == num2) | (array[i].iTipo == num3)) && (((array[i].iPn1 == iPn) & (array[i].iPn2 == iPn2)) | ((array[i].iPn1 == iPn2) & (array[i].iPn2 == iPn))))
					{
						int num5 = Information.UBound(VeiasCaderno) + 1;
						VeiasCaderno = (structureVeiasCaderno[])Utils.CopyArray(VeiasCaderno, new structureVeiasCaderno[num5 + 1]);
						VeiasCaderno[num5] = array[i];
						if (Operators.CompareString(array[i].sHandleCabo1, "", TextCompare: true) != 0)
						{
							list.Add(array[i].sHandleCabo1);
						}
						if (Operators.CompareString(array[i].sHandleCabo2, "", TextCompare: true) != 0)
						{
							list.Add(array[i].sHandleCabo2);
						}
					}
				}
			}
			if (Information.UBound(VeiasCaderno) >= 1 && !bOrdenaDeSelecao)
			{
				int num6 = Information.UBound(VeiasCaderno) - 1;
				for (int j = num6; j >= 1; j += -1)
				{
					int num7 = j;
					for (int k = 1; k <= num7; k++)
					{
						if (Pagina.calculaPaginaDecimal(VeiasCaderno[k].sPagina) > Pagina.calculaPaginaDecimal(VeiasCaderno[k + 1].sPagina))
						{
							structureVeiasCaderno structureVeiasCaderno2 = VeiasCaderno[k];
							VeiasCaderno[k] = VeiasCaderno[k + 1];
							VeiasCaderno[k + 1] = structureVeiasCaderno2;
						}
						if (Operators.CompareString(VeiasCaderno[k].sPagina, VeiasCaderno[k + 1].sPagina, TextCompare: true) == 0 && VeiasCaderno[k].Y < VeiasCaderno[k + 1].Y)
						{
							structureVeiasCaderno structureVeiasCaderno2 = VeiasCaderno[k];
							VeiasCaderno[k] = VeiasCaderno[k + 1];
							VeiasCaderno[k + 1] = structureVeiasCaderno2;
						}
						if (Operators.CompareString(VeiasCaderno[k].sPagina, VeiasCaderno[k + 1].sPagina, TextCompare: true) == 0 && VeiasCaderno[k].Y == VeiasCaderno[k + 1].Y && VeiasCaderno[k].X > VeiasCaderno[k + 1].X)
						{
							structureVeiasCaderno structureVeiasCaderno2 = VeiasCaderno[k];
							VeiasCaderno[k] = VeiasCaderno[k + 1];
							VeiasCaderno[k + 1] = structureVeiasCaderno2;
						}
					}
				}
			}
			clsBlocos.Unhighlight();
			AtivaHighlight(list);
			return result;
		}
	}

	public static void buscaTextosdosCabos(ref clsTextos.structureTextoCaderno[] TextoCabo)
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
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected Obj, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
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
						short tipo = default;
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
							DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
							if (val6 != null)
							{
								string handle = "";
								string THandle = "";
								Entity ent = (Entity)(object)val6;
								string sOpcionais = "";
								bool flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle, ref tipo, ref THandle, ref sOpcionais);
								val6 = (DBText)ent;
								if (flag && tipo == 1)
								{
									int num = Information.UBound(TextoCabo) + 1;
									TextoCabo = (clsTextos.structureTextoCaderno[])Utils.CopyArray(TextoCabo, new clsTextos.structureTextoCaderno[num + 1]);
									TextoCabo[num].sHandleTexto = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
									TextoCabo[num].sHandleVeia = handle;
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

	public static void Estimativa(ref DeclaracoesInterligacao.structureEstimativa[] mEstimativa)
	{
		int num = 0;
		mEstimativa = new DeclaracoesInterligacao.structureEstimativa[1];
		int num2 = 0;
		int num3 = 0;
		structureVeiasCaderno[] VeiasCaderno = new structureVeiasCaderno[1];
		clsEditarInterligacao.carregaApenasAsVeiasIndefinidasDoCaderno(ref VeiasCaderno);
		int num4 = Information.UBound(VeiasCaderno);
		checked
		{
			for (int i = 1; i <= num4; i++)
			{
				if ((VeiasCaderno[i].iPn1 == 0) | (VeiasCaderno[i].iPn2 == 0))
				{
					continue;
				}
				bool flag = true;
				num2 = VeiasCaderno[i].iPn1;
				num3 = VeiasCaderno[i].iPn2;
				if (num2 > num3)
				{
					num2 = VeiasCaderno[i].iPn2;
					num3 = VeiasCaderno[i].iPn1;
				}
				int num5 = Information.UBound(mEstimativa);
				for (int j = 1; j <= num5; j++)
				{
					if ((mEstimativa[j].iPn1 == num2) & (mEstimativa[j].iPn2 == num3))
					{
						mEstimativa[j].iQuant++;
						flag = false;
						break;
					}
				}
				if (flag)
				{
					num++;
					mEstimativa = (DeclaracoesInterligacao.structureEstimativa[])Utils.CopyArray(mEstimativa, new DeclaracoesInterligacao.structureEstimativa[num + 1]);
					mEstimativa[num].sPn1 = Dicionario.BuscaNomeDoPainel(num2);
					mEstimativa[num].sPn2 = Dicionario.BuscaNomeDoPainel(num3);
					mEstimativa[num].iPn1 = num2;
					mEstimativa[num].iPn2 = num3;
					mEstimativa[num].iQuant = 1;
				}
			}
		}
	}

	public static string LeOModeloVeias()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		int num = 0;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
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
							Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
							if (pl != null)
							{
								DeclaracoesEntidades.StructureInterligacao ilig = default;
								if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
								{
									num = ilig.iModeloVeiaFuncao;
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
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					val2.Abort();
					throw;
				}
				finally
				{
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
		return Conversions.ToString(num);
	}

	public static bool SelecionaDadosDeumaVeias(ref string sHandle, ref string sCabo, ref string sVeia, ref string sNome, ref string sFuncao, ref string sFormacao)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected Obj, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Invalid comparison between Unknown and I4
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected Obj, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		PointMonitorToolTips.StopMonitor();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				PromptEntityOptions val4 = new PromptEntityOptions("");
				val4.SetRejectMessage(Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 1536])));
				((PromptOptions)val4).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 1536]));
				val4.AddAllowedClass(typeof(Polyline), true);
				PromptEntityResult entity = editor.GetEntity(val4);
				if ((int)((PromptResult)entity).Status != -5002)
				{
					ObjectId objectId = entity.ObjectId;
					Entity val5 = (Entity)objectId.GetObject((OpenMode)0);
					Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
					if (pl != null)
					{
						DeclaracoesEntidades.StructureInterligacao ilig = default;
						if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) && ilig.NumVeia != -1000)
						{
							sCabo = ilig.Tag_Cabo;
							sVeia = Conversions.ToString(ilig.NumVeia);
							sNome = ilig.NomeVeia;
							sHandle = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
							CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
							cDadosAccessInterligacao3.LeFormacaodoCaboFuncaoVeia(ref sCabo, Conversions.ToInteger(sVeia), ref sFormacao, ref sFuncao);
							cDadosAccessInterligacao3.FechaConexao();
							result = true;
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				val2.Abort();
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
			((IDisposable)val)?.Dispose();
		}
		return result;
	}

	public static void LeTodasAsVeiasUsadasNoDesenho(ref structureNomeVeiasEditadar[] mNomesVeias)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
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
						BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val4.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
								Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
								if (pl != null)
								{
									DeclaracoesEntidades.StructureInterligacao ilig = default;
									if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) && ilig.NumVeia != -1000)
									{
										int num = Information.UBound(mNomesVeias) + 1;
										mNomesVeias = (structureNomeVeiasEditadar[])Utils.CopyArray(mNomesVeias, new structureNomeVeiasEditadar[num + 1]);
										mNomesVeias[num].sTag = ilig.Tag_Cabo;
										mNomesVeias[num].iIndice = ilig.NumVeia;
										mNomesVeias[num].sNomeVeia = ilig.NomeVeia;
										mNomesVeias[num].sFuncaoVeias = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
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
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			if (Information.UBound(mNomesVeias) < 2)
			{
				return;
			}
			int num2 = Information.UBound(mNomesVeias);
			for (int i = 1; i <= num2; i++)
			{
				int num3 = Information.UBound(mNomesVeias) - 1;
				int num4 = i;
				for (int j = num3; j >= num4; j += -1)
				{
					if (Operators.CompareString(mNomesVeias[j].sTag, mNomesVeias[j + 1].sTag, TextCompare: true) > 0)
					{
						structureNomeVeiasEditadar structureNomeVeiasEditadar2 = mNomesVeias[j + 1];
						mNomesVeias[j + 1] = mNomesVeias[j];
						mNomesVeias[j] = structureNomeVeiasEditadar2;
					}
					if (Operators.CompareString(mNomesVeias[j].sTag, mNomesVeias[j + 1].sTag, TextCompare: true) == 0 && mNomesVeias[j].iIndice > mNomesVeias[j + 1].iIndice)
					{
						structureNomeVeiasEditadar structureNomeVeiasEditadar2 = mNomesVeias[j + 1];
						mNomesVeias[j + 1] = mNomesVeias[j];
						mNomesVeias[j] = structureNomeVeiasEditadar2;
					}
				}
			}
		}
	}

	public static bool ExisteVeiasUsadasNoDesenho()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		bool result = false;
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
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
							Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
							if (pl != null)
							{
								DeclaracoesEntidades.StructureInterligacao ilig = default;
								if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) && ilig.NumVeia != -1000)
								{
									result = true;
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
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool ExisteJumperExternosNoDesenho()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		bool result = false;
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
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
							Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
							if (pl == null)
							{
								continue;
							}
							DeclaracoesEntidades.StructureConexao conex = default;
							if (XDataConexao.lerXDataConexao(ref pl, ref conex))
							{
								if (conex.Tipo == 4)
								{
									result = true;
									break;
								}
								if ((conex.Tipo == 3) & (Operators.CompareString(conex.Jumper.ToUpper(), "JUMPER", TextCompare: true) == 0))
								{
									result = true;
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
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return result;
	}
}
