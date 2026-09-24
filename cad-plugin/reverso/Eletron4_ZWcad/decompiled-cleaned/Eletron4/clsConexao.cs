using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.Runtime;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

public class clsConexao
{
	public struct Apagados
	{
		public string handle;

		public string handleSup;

		public bool bApagar;
	}

	public struct structureAUXDERIVACAO
	{
		public string sHandle;

		public string sTipo;

		public string Potencial;

		public string sNome;
	}

	public void CriarConexao()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected Obj, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Invalid comparison between Unknown and I4
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected Obj, but got Unknown
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected Obj, but got Unknown
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Expected Obj, but got Unknown
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Expected I4, but got Unknown
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Invalid comparison between Unknown and I4
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0baa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0baf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bcc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c42: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05da: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05df: Unknown result type (might be due to invalid IL or missing references)
		//IL_054e: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06be: Unknown result type (might be due to invalid IL or missing references)
		//IL_06eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c3: Expected Obj, but got Unknown
		//IL_03cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Expected Obj, but got Unknown
		//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0617: Unknown result type (might be due to invalid IL or missing references)
		//IL_061c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0621: Unknown result type (might be due to invalid IL or missing references)
		//IL_0626: Unknown result type (might be due to invalid IL or missing references)
		//IL_062b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0630: Unknown result type (might be due to invalid IL or missing references)
		//IL_0635: Unknown result type (might be due to invalid IL or missing references)
		//IL_063f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0664: Unknown result type (might be due to invalid IL or missing references)
		//IL_0718: Unknown result type (might be due to invalid IL or missing references)
		//IL_077d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0782: Unknown result type (might be due to invalid IL or missing references)
		//IL_07af: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Unknown result type (might be due to invalid IL or missing references)
		//IL_087d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0882: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0909: Unknown result type (might be due to invalid IL or missing references)
		//IL_090e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0911: Unknown result type (might be due to invalid IL or missing references)
		//IL_0913: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ada: Unknown result type (might be due to invalid IL or missing references)
		//IL_0adf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0969: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		PromptPointOptions val = new PromptPointOptions("");
		DeclaracoesEntidades.StructureConexao conex = new DeclaracoesEntidades.StructureConexao
		{
			Nome = "",
			Tensao = "",
			Funcao = "",
			Aplicacao = 0,
			Enderecamento = 1,
			Usuario = Environment.UserName,
			Data = DateTime.Now.ToString()
		};
		((PromptOptions)val).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 195]));
		PromptPointResult point = editor.GetPoint(val);
		if ((int)((PromptResult)point).Status != -5002)
		{
			Point3d value = point.Value;
			string sTipo = "";
			int Potencial = 0;
			string Handle = "";
			string Secao = "";
			string Cor = "";
			int Aplicacao = 0;
			Point3d pt = value;
			bool bpossuiRB = false;
			short Painel = default;
			if (verificaDispConex(pt, ref sTipo, ref Painel, ref Potencial, ref Handle, ref Secao, ref Cor, ref Aplicacao, ref bpossuiRB))
			{
				string left = sTipo;
				if (Operators.CompareString(left, "P", TextCompare: true) != 0 && Operators.CompareString(left, "A", TextCompare: true) != 0 && Operators.CompareString(left, "E", TextCompare: true) != 0 && Operators.CompareString(left, "B", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left, "C", TextCompare: true) != 0)
					{
						if (Operators.CompareString(left, "J", TextCompare: true) != 0)
						{
							goto IL_0eee;
						}
						conex.Tipo = 3;
						conex.Potencial = Potencial;
						conex.Disp1 = false;
						conex.Secao = Secao;
						conex.Cor = Cor;
						conex.Handle = Handle;
						conex.Painel = Painel;
						conex.Jumper = "JUMPER";
						conex.Aplicacao = Aplicacao;
					}
					else
					{
						conex.Tipo = 3;
						conex.Potencial = Potencial;
						conex.Disp1 = false;
						conex.Secao = Secao;
						conex.Cor = Cor;
						conex.Handle = Handle;
						conex.Painel = Painel;
						conex.Jumper = "";
						conex.Aplicacao = Aplicacao;
					}
				}
				else
				{
					conex.Tipo = 2;
					conex.Potencial = XDataConexao.BuscaPotencial();
					conex.Disp1 = true;
					conex.Secao = DeclaracoesGeral.ativoRibbon.Secao;
					conex.Cor = DeclaracoesGeral.ativoRibbon.Cor;
					conex.Handle = "";
					conex.Painel = Painel;
					conex.Jumper = "";
				}
				Point2d val2 = value.Convert2d((PlanarEntity)new Plane());
				Polyline pl = new Polyline();
				((Entity)pl).SetDatabaseDefaults();
				((Entity)pl).ColorIndex = DeclaracoesGeral.Conf.CorConexao;
				pl.AddVertexAt(0, val2, 0.0, 0.0, 0.0);
				pl.AddVertexAt(1, val2, 0.0, 0.0, 0.0);
				((Entity)pl).Layer = DeclaracoesGeral.ativo.Pagina;
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val3 = database.TransactionManager.StartTransaction();
				try
				{
					int num = 1;
					try
					{
						short Painel2 = default;
						while (true)
						{
							Entity ent = (Entity)(object)pl;
							JigConexao jigConexao = new JigConexao(ref ent, num);
							pl = (Polyline)ent;
							JigConexao jigConexao2 = jigConexao;
							hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
							PromptResult val4 = editor.Drag((Jig)(object)jigConexao2);
							PromptStatus status = val4.Status;
							switch (status - -5005)
							{
							default:
								if ((int)status == 5100)
								{
									Point2d point2dAt3 = pl.GetPoint2dAt(checked(pl.NumberOfVertices - 1));
									Point2d point2dAt4 = pl.GetPoint2dAt(0);
									if (num == 1)
									{
										if (!((conex.Tipo == 2) & (pl.NumberOfVertices == 2) & (Math.Round(point2dAt4.X, 1) != Math.Round(point2dAt3.X, 1)) & (Math.Round(point2dAt4.Y, 1) != Math.Round(point2dAt3.Y, 1))))
										{
											if ((conex.Tipo == 2) & (pl.NumberOfVertices == 2) & (Math.Round(point2dAt4.X, 1) != Math.Round(point2dAt3.X, 1)) & (Math.Round(point2dAt4.Y, 1) == Math.Round(point2dAt3.Y, 1)))
											{
												Point3d val9 = new Point3d(point2dAt3.X - 0.2, point2dAt3.Y - 0.2, 0.0);
												Point3d val10 = new Point3d(point2dAt3.X + 0.2, point2dAt3.Y + 0.2, 0.0);
												PromptSelectionResult val11 = editor.SelectCrossingWindow(val9, val10);
												if (Information.IsNothing(val11.Value))
												{
													pl.AddVertexAt(pl.NumberOfVertices, point2dAt3, 0.0, 0.0, 0.0);
													num = 1;
												}
												else
												{
													_ = val11.Value;
													num = 4;
												}
												continue;
											}
											if ((conex.Tipo == 3) & (pl.NumberOfVertices == 2) & (Math.Round(point2dAt4.X, 1) != Math.Round(point2dAt3.X, 1)) & (Math.Round(point2dAt4.Y, 1) != Math.Round(point2dAt3.Y, 1)))
											{
												Point3d val12 = new Point3d(point2dAt3.X - 0.2, point2dAt3.Y - 0.2, 0.0);
												Point3d val13 = new Point3d(point2dAt3.X + 0.2, point2dAt3.Y + 0.2, 0.0);
												PromptSelectionResult val14 = editor.SelectCrossingWindow(val12, val13);
												if (!Information.IsNothing(val14.Value))
												{
													_ = val14.Value;
													double num4;
													double num5;
													double num6;
													double num7;
													double num8;
													double num9;
													double num10;
													double num11;
													if (!(point2dAt3.X > point2dAt4.X))
													{
														if (!(point2dAt3.Y > point2dAt4.Y))
														{
															num4 = -0.1;
															num5 = -0.2;
															num6 = -0.1;
															num7 = 0.1;
															num8 = -0.1;
															num9 = 0.1;
															num10 = -0.1;
															num11 = -0.2;
														}
														else
														{
															num4 = -0.1;
															num5 = -0.2;
															num6 = -0.1;
															num7 = 0.1;
															num8 = -0.1;
															num9 = 0.1;
															num10 = 0.1;
															num11 = 0.2;
														}
													}
													else if (!(point2dAt3.Y > point2dAt4.Y))
													{
														num4 = 0.1;
														num5 = 0.2;
														num6 = -0.1;
														num7 = 0.1;
														num8 = -0.1;
														num9 = 0.1;
														num10 = -0.1;
														num11 = -0.2;
													}
													else
													{
														num4 = 0.1;
														num5 = 0.2;
														num6 = -0.1;
														num7 = 0.1;
														num8 = -0.1;
														num9 = 0.1;
														num10 = 0.1;
														num11 = 0.2;
													}
													val12 = new Point3d(point2dAt4.X + num4, point2dAt4.Y + num6, 0.0);
													val13 = new Point3d(point2dAt4.X + num5, point2dAt4.Y + num7, 0.0);
													val14 = editor.SelectCrossingWindow(val12, val13);
													bool flag = !Information.IsNothing(val14.Value);
													val12 = new Point3d(point2dAt4.X + num8, point2dAt4.Y + num10, 0.0);
													val13 = new Point3d(point2dAt4.X + num9, point2dAt4.Y + num11, 0.0);
													val14 = editor.SelectCrossingWindow(val12, val13);
													bool flag2 = !Information.IsNothing(val14.Value);
													if (!((!flag & flag2) | (!flag & !flag2)))
													{
														if (!(flag & !flag2))
														{
															if (flag & flag2)
															{
																pl.AddVertexAt(pl.NumberOfVertices, point2dAt3, 0.0, 0.0, 0.0);
																num = 1;
																continue;
															}
														}
														else
														{
															Point2d val15 = new Point2d(point2dAt4.X, point2dAt3.Y);
															Point2d point2dAt5 = pl.GetPoint2dAt(1);
															pl.SetPointAt(1, val15);
															pl.AddVertexAt(2, point2dAt5, 0.0, 0.0, 0.0);
														}
													}
													else
													{
														Point2d val16 = new Point2d(point2dAt3.X, point2dAt4.Y);
														Point2d point2dAt6 = pl.GetPoint2dAt(1);
														pl.SetPointAt(1, val16);
														pl.AddVertexAt(2, point2dAt6, 0.0, 0.0, 0.0);
													}
													goto case 1;
												}
											}
										}
										else
										{
											Point3d val17 = new Point3d(point2dAt3.X - 0.2, point2dAt3.Y - 0.2, 0.0);
											Point3d val18 = new Point3d(point2dAt3.X + 0.2, point2dAt3.Y + 0.2, 0.0);
											PromptSelectionResult val19 = editor.SelectCrossingWindow(val17, val18);
											if (!Information.IsNothing(val19.Value))
											{
												SelectionSet value2 = val19.Value;
												if (value2.Count == 1)
												{
													Point2d point2dAt7 = pl.GetPoint2dAt(0);
													Point2d point2dAt8 = pl.GetPoint2dAt(1);
													Point2d point2dAt9 = pl.GetPoint2dAt(1);
													pl.SetPointAt(1, point2dAt7);
													pl.AddVertexAt(2, point2dAt8, 0.0, 0.0, 0.0);
													pl.AddVertexAt(3, point2dAt9, 0.0, 0.0, 0.0);
													num = 2;
													continue;
												}
											}
										}
										pl.AddVertexAt(pl.NumberOfVertices, point2dAt3, 0.0, 0.0, 0.0);
										num = 1;
										continue;
									}
								}
								goto case 1;
							case 1:
							case 2:
							{
								Point3d point3dAt = pl.GetPoint3dAt(checked(pl.NumberOfVertices - 1));
								string sTipo2 = "";
								int Potencial2 = 0;
								string Handle2 = "";
								string Secao2 = "";
								string Cor2 = "";
								bool bpossuiRB2 = false;
								int Aplicacao2 = 0;
								if (!verificaDispConex(point3dAt, ref sTipo2, ref Painel2, ref Potencial2, ref Handle2, ref Secao2, ref Cor2, ref Aplicacao2, ref bpossuiRB2))
								{
									break;
								}
								string left2 = sTipo2;
								if (Operators.CompareString(left2, "P", TextCompare: true) != 0 && Operators.CompareString(left2, "A", TextCompare: true) != 0 && Operators.CompareString(left2, "E", TextCompare: true) != 0 && Operators.CompareString(left2, "B", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left2, "C", TextCompare: true) == 0)
									{
										Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 608]), MsgBoxStyle.Exclamation);
										break;
									}
								}
								else
								{
									if (Painel != Painel2)
									{
										Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 609]), MsgBoxStyle.Exclamation);
										break;
									}
									if ((conex.Tipo == 3) & (Operators.CompareString(conex.Jumper, "JUMPER", TextCompare: true) == 0))
									{
										if ((Operators.CompareString(sTipo2, "P", TextCompare: true) == 0) | (Operators.CompareString(sTipo2, "A", TextCompare: true) == 0))
										{
											Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1403]), MsgBoxStyle.Exclamation);
											break;
										}
										if ((Operators.CompareString(sTipo2, "E", TextCompare: true) == 0) & !bpossuiRB2)
										{
											Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1402]), MsgBoxStyle.Exclamation);
											break;
										}
									}
									conex.Disp2 = true;
								}
								BlockTable val7 = (BlockTable)val3.GetObject(database.BlockTableId, (OpenMode)0);
								BlockTableRecord val8 = (BlockTableRecord)val3.GetObject(((SymbolTable)val7)[BlockTableRecord.ModelSpace], (OpenMode)1);
								val8.AppendEntity((Entity)(object)pl);
								DeclaracoesGeral.bAnularEventos = true;
								val3.AddNewlyCreatedDBObject((DBObject)(object)pl, true);
								XDataConexao.GravarXDataConexao(ref pl, conex);
								if (conex.Tipo == 3)
								{
									CriarHatch(((Curve)pl).StartPoint, ((Entity)pl).Layer, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
								}
								break;
							}
							case 0:
								if (!((num == 2) | (num == 3)))
								{
									if (num == 4)
									{
										Point2d point2dAt = pl.GetPoint2dAt(0);
										double num2 = point2dAt.X + 2.0;
										point2dAt = pl.GetPoint2dAt(0);
										Point2d val5 = new Point2d(num2, point2dAt.Y - 2.0);
										point2dAt = pl.GetPoint2dAt(1);
										double num3 = point2dAt.X - 2.0;
										point2dAt = pl.GetPoint2dAt(1);
										Point2d val6 = new Point2d(num3, point2dAt.Y - 2.0);
										Point2d point2dAt2 = pl.GetPoint2dAt(1);
										pl.SetPointAt(1, val5);
										pl.AddVertexAt(2, val6, 0.0, 0.0, 0.0);
										pl.AddVertexAt(3, point2dAt2, 0.0, 0.0, 0.0);
										num = 5;
									}
								}
								else if (Operators.CompareString(val4.StringResult.ToUpper(), "I", TextCompare: true) == 0)
								{
									switch (num)
									{
									case 3:
										num = 2;
										break;
									case 2:
										num = 3;
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
		goto IL_0eee;
		IL_0eee:
		PointMonitorToolTips.StartMonitor();
	}

	public bool verificaDispConex(Point3d pt, ref string sTipo, ref short Painel, ref int Potencial, ref string Handle, ref string Secao, ref string Cor, ref int Aplicacao, [Optional][DefaultParameterValue(false)] ref bool bpossuiRB)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected Obj, but got Unknown
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected Obj, but got Unknown
		//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		short num = 0;
		short num2 = 0;
		int num3 = 0;
		bool flag = false;
		string text = "";
		bool flag2 = false;
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		Point3d val = new Point3d(pt.X - 0.2, pt.Y - 0.2, 0.0);
		Point3d val2 = new Point3d(pt.X + 0.2, pt.Y + 0.2, 0.0);
		PromptSelectionResult val3 = editor.SelectCrossingWindow(val, val2);
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val4 = database.TransactionManager.StartTransaction();
		checked
		{
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
						BlockReference blockref = (BlockReference)(object)((ent is BlockReference) ? ent : null);
						if (blockref != null)
						{
							string tipoImportado = "";
							text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							if (Operators.CompareString(text, "B", TextCompare: true) == 0)
							{
								flag = true;
							}
							if ((Operators.CompareString(text, "", TextCompare: true) != 0) & (Operators.CompareString(text, "I", TextCompare: true) != 0))
							{
								num++;
								Painel = XDataDispositivo.BuscaPainelDispositivo(ref ent);
								Handle = ((object)((DBObject)blockref).Handle/*cast due to constrained. prefix*/).ToString();
								if (Operators.CompareString(text, "E", TextCompare: true) == 0)
								{
									flag2 = possuiTerminalRB(ref blockref);
								}
							}
							if (Operators.CompareString(text, "I", TextCompare: true) == 0)
							{
								sTipo = "I";
							}
						}
						Polyline pl = (Polyline)(object)((ent is Polyline) ? ent : null);
						DeclaracoesEntidades.StructureConexao conex = default;
						if (pl == null || !XDataConexao.lerXDataConexao(ref pl, ref conex))
						{
							continue;
						}
						if (Operators.CompareString(conex.Jumper, "", TextCompare: true) != 0)
						{
							if (Operators.CompareString(conex.Jumper, "JUMPER", TextCompare: true) == 0)
							{
								sTipo = "J";
							}
						}
						else
						{
							sTipo = "C";
						}
						if (num3 != conex.Potencial)
						{
							num3 = conex.Potencial;
							num2++;
							Handle = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
							Painel = conex.Painel;
							Potencial = conex.Potencial;
							Secao = conex.Secao;
							Cor = conex.Cor;
							Aplicacao = conex.Aplicacao;
						}
					}
				}
				if (!((num == 0) & (num2 == 0)))
				{
					if (!(((num == 1) & ((num2 == 0) | (num2 == 1))) | flag))
					{
						if (!((num == 1) & (num2 >= 2)))
						{
							if ((num == 0) & (num2 >= 1))
							{
								result = true;
							}
						}
						else
						{
							Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 610]), MsgBoxStyle.Exclamation);
							result = false;
						}
					}
					else
					{
						sTipo = text;
						bpossuiRB = flag2;
						result = true;
					}
				}
				else
				{
					result = false;
				}
				DeclaracoesGeral.bAnularEventos = true;
				val4.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				return result;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				val4.Abort();
				throw;
			}
			finally
			{
				((IDisposable)val4)?.Dispose();
			}
		}
	}

	public void CriarConexaoAutomatica(string tipoConexao)
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected Obj, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Invalid comparison between Unknown and I4
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected Obj, but got Unknown
		//IL_0891: Unknown result type (might be due to invalid IL or missing references)
		//IL_0896: Unknown result type (might be due to invalid IL or missing references)
		//IL_08aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_08af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected Obj, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected Obj, but got Unknown
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Invalid comparison between Unknown and I4
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Expected Obj, but got Unknown
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected Obj, but got Unknown
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected Obj, but got Unknown
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Expected Obj, but got Unknown
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e6: Invalid comparison between Unknown and I4
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0408: Unknown result type (might be due to invalid IL or missing references)
		//IL_044d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Expected Obj, but got Unknown
		//IL_090a: Unknown result type (might be due to invalid IL or missing references)
		//IL_090f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0923: Unknown result type (might be due to invalid IL or missing references)
		//IL_0928: Unknown result type (might be due to invalid IL or missing references)
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0465: Expected Obj, but got Unknown
		//IL_0490: Unknown result type (might be due to invalid IL or missing references)
		//IL_049a: Invalid comparison between Unknown and I4
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b8: Expected Obj, but got Unknown
		//IL_0857: Unknown result type (might be due to invalid IL or missing references)
		//IL_085d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e9: Expected Obj, but got Unknown
		//IL_0522: Unknown result type (might be due to invalid IL or missing references)
		//IL_0529: Expected Obj, but got Unknown
		//IL_052f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0534: Unknown result type (might be due to invalid IL or missing references)
		//IL_053f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0544: Unknown result type (might be due to invalid IL or missing references)
		//IL_054d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_055a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0567: Unknown result type (might be due to invalid IL or missing references)
		//IL_056c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0577: Unknown result type (might be due to invalid IL or missing references)
		//IL_057c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0821: Unknown result type (might be due to invalid IL or missing references)
		//IL_0827: Unknown result type (might be due to invalid IL or missing references)
		//IL_0599: Unknown result type (might be due to invalid IL or missing references)
		//IL_059e: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05af: Expected Obj, but got Unknown
		//IL_05e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ef: Expected Obj, but got Unknown
		//IL_05f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0605: Unknown result type (might be due to invalid IL or missing references)
		//IL_060a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0613: Unknown result type (might be due to invalid IL or missing references)
		//IL_061b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0620: Unknown result type (might be due to invalid IL or missing references)
		//IL_062d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0632: Unknown result type (might be due to invalid IL or missing references)
		//IL_063d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0642: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c2: Expected Obj, but got Unknown
		//IL_06dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0702: Unknown result type (might be due to invalid IL or missing references)
		//IL_0739: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
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
				int Potencial = 0;
				string Secao = "";
				string Cor = "";
				PromptPointOptions val4 = new PromptPointOptions("");
				((PromptOptions)val4).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 623]));
				PromptPointResult point = editor.GetPoint(val4);
				if ((int)((PromptResult)point).Status != -5002)
				{
					Point3d value = point.Value;
					string sTipo = "";
					string Handle = "";
					int Aplicacao = 0;
					Point3d pt = value;
					bool bpossuiRB = false;
					short Painel = default;
					if (verificaDispConex(pt, ref sTipo, ref Painel, ref Potencial, ref Handle, ref Secao, ref Cor, ref Aplicacao, ref bpossuiRB))
					{
						string left = sTipo;
						if (Operators.CompareString(left, "P", TextCompare: true) == 0 || Operators.CompareString(left, "A", TextCompare: true) == 0 || Operators.CompareString(left, "E", TextCompare: true) == 0 || Operators.CompareString(left, "B", TextCompare: true) == 0)
						{
							BlockReference val5 = (BlockReference)Geral.HandleToObject(Handle);
							Point3d position;
							if (val5 != null)
							{
								text = val5.Name;
								double x = value.X;
								position = val5.Position;
								num = x - position.X;
								double y = value.Y;
								position = val5.Position;
								num2 = y - position.Y;
							}
							TypedValue[] array = new TypedValue[2];
							array.SetValue((object)new TypedValue(0, (object)"INSERT"), 0);
							array.SetValue((object)new TypedValue(1001, (object)"DISPOSITIVO"), 1);
							SelectionFilter val6 = new SelectionFilter(array);
							PromptSelectionOptions val7 = new PromptSelectionOptions();
							val7.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 622]);
							PromptSelectionResult selection = editor.GetSelection(val7, val6);
							if ((int)selection.Status == 5100)
							{
								SelectionSet value2 = selection.Value;
								ObjectIdCollection val8 = new ObjectIdCollection(value2.GetObjectIds());
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
									int Aplicacao2 = 0;
									Point3d pt2 = value4;
									bpossuiRB = false;
									short Painel2 = default;
									if (verificaDispConex(pt2, ref sTipo2, ref Painel2, ref Potencial, ref Handle2, ref Secao, ref Cor, ref Aplicacao2, ref bpossuiRB))
									{
										string left2 = sTipo2;
										if (Operators.CompareString(left2, "P", TextCompare: true) == 0 || Operators.CompareString(left2, "A", TextCompare: true) == 0 || Operators.CompareString(left2, "E", TextCompare: true) == 0 || Operators.CompareString(left2, "B", TextCompare: true) == 0)
										{
											val5 = (BlockReference)Geral.HandleToObject(Handle2);
											if (val5 != null)
											{
												right = val5.Name;
												double x2 = value4.X;
												position = val5.Position;
												num3 = x2 - position.X;
												double y2 = value4.Y;
												position = val5.Position;
												num4 = y2 - position.Y;
											}
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
													short num5 = XDataDispositivo.BuscaPainelDispositivo(ref ent);
													val14 = (BlockReference)ent;
													Painel = num5;
													position = val14.Position;
													double x3 = position.X;
													position = val14.Position;
													new Point2d(x3, position.Y);
													position = val14.Position;
													double num6 = position.X + num;
													position = val14.Position;
													Point2d val15 = new Point2d(num6, position.Y + num2);
													foreach (object item4 in val11)
													{
														ObjectId val16 = ((item4 == null) ? default(ObjectId) : ((ObjectId)item4));
														Entity val17 = (Entity)val16.GetObject((OpenMode)0);
														BlockReference val18 = (BlockReference)(object)((val17 is BlockReference) ? val17 : null);
														if (val18 != null && Operators.CompareString(val18.Name, right, TextCompare: true) == 0)
														{
															ent = (Entity)(object)val18;
															num5 = XDataDispositivo.BuscaPainelDispositivo(ref ent);
															val18 = (BlockReference)ent;
															Painel2 = num5;
															position = val18.Position;
															double x4 = position.X;
															position = val18.Position;
															new Point2d(x4, position.Y);
															position = val18.Position;
															double num7 = position.X + num3;
															position = val18.Position;
															Point2d val19 = new Point2d(num7, position.Y + num4);
															if (Painel == Painel2 && (((Operators.CompareString(tipoConexao, "V", TextCompare: true) == 0) & (Math.Round(val15.X, 0) == Math.Round(val19.X, 0))) | ((Operators.CompareString(tipoConexao, "H", TextCompare: true) == 0) & (Math.Round(val15.Y, 0) == Math.Round(val19.Y, 0)))))
															{
																Polyline pl = new Polyline();
																((Entity)pl).SetDatabaseDefaults();
																((Entity)pl).ColorIndex = DeclaracoesGeral.Conf.CorConexao;
																pl.AddVertexAt(0, val15, 0.0, 0.0, 0.0);
																pl.AddVertexAt(1, val19, 0.0, 0.0, 0.0);
																((Entity)pl).Layer = DeclaracoesGeral.ativo.Pagina;
																val3.AppendEntity((Entity)(object)pl);
																DeclaracoesGeral.bAnularEventos = true;
																val.AddNewlyCreatedDBObject((DBObject)(object)pl, true);
																XDataConexao.GravarXDataConexao(ref pl, new DeclaracoesEntidades.StructureConexao
																{
																	Tipo = 2,
																	Potencial = XDataConexao.BuscaPotencial(),
																	Aplicacao = 0,
																	Disp1 = true,
																	Disp2 = true,
																	Secao = DeclaracoesGeral.ativoRibbon.Secao,
																	Cor = DeclaracoesGeral.ativoRibbon.Cor,
																	Handle = "",
																	Painel = Painel,
																	Nome = "",
																	Tensao = "",
																	Funcao = "",
																	Jumper = "",
																	Enderecamento = 1,
																	Usuario = Environment.UserName,
																	Data = DateTime.Now.ToString()
																});
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

	public void CriarDerivacaoAutomatica(string tipoDerivacao)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected Obj, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected Obj, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Invalid comparison between Unknown and I4
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected Obj, but got Unknown
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected Obj, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Invalid comparison between Unknown and I4
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected Obj, but got Unknown
		//IL_0724: Unknown result type (might be due to invalid IL or missing references)
		//IL_0729: Unknown result type (might be due to invalid IL or missing references)
		//IL_073d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0742: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Expected Obj, but got Unknown
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Expected Obj, but got Unknown
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Invalid comparison between Unknown and I4
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Expected Obj, but got Unknown
		//IL_0459: Unknown result type (might be due to invalid IL or missing references)
		//IL_045f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Expected Obj, but got Unknown
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Expected Obj, but got Unknown
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Expected Obj, but got Unknown
		//IL_04ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0521: Unknown result type (might be due to invalid IL or missing references)
		//IL_0526: Unknown result type (might be due to invalid IL or missing references)
		//IL_0533: Unknown result type (might be due to invalid IL or missing references)
		//IL_0538: Unknown result type (might be due to invalid IL or missing references)
		//IL_0543: Unknown result type (might be due to invalid IL or missing references)
		//IL_0548: Unknown result type (might be due to invalid IL or missing references)
		//IL_0576: Unknown result type (might be due to invalid IL or missing references)
		//IL_057b: Unknown result type (might be due to invalid IL or missing references)
		//IL_058b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0590: Unknown result type (might be due to invalid IL or missing references)
		//IL_059e: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ac: Expected Obj, but got Unknown
		//IL_05c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_060e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0615: Expected Obj, but got Unknown
		//IL_063d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0642: Unknown result type (might be due to invalid IL or missing references)
		//IL_0646: Unknown result type (might be due to invalid IL or missing references)
		//IL_0650: Expected Obj, but got Unknown
		//IL_064b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0650: Unknown result type (might be due to invalid IL or missing references)
		//IL_065d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0683: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c7: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		double num = 0.0;
		double num2 = 0.0;
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
				PromptEntityOptions val4 = new PromptEntityOptions("");
				val4.SetRejectMessage(Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 615])));
				((PromptOptions)val4).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 614]));
				val4.AddAllowedClass(typeof(Polyline), true);
				PromptEntityResult entity = editor.GetEntity(val4);
				if ((int)((PromptResult)entity).Status != -5002)
				{
					ObjectId objectId = entity.ObjectId;
					Polyline pl = (Polyline)objectId.GetObject((OpenMode)0);
					DeclaracoesEntidades.StructureConexao conex = default;
					if (XDataConexao.lerXDataConexao(ref pl, ref conex))
					{
						_ = entity.PickedPoint;
						PromptPointOptions val5 = new PromptPointOptions("");
						((PromptOptions)val5).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 617]));
						PromptPointResult point = editor.GetPoint(val5);
						if ((int)((PromptResult)point).Status != -5002)
						{
							Point3d value = point.Value;
							string sTipo = "";
							int Potencial = 0;
							string Handle = "";
							string Secao = "";
							string Cor = "";
							int Aplicacao = 0;
							Point3d pt = value;
							bool bpossuiRB = false;
							short Painel = default;
							if (verificaDispConex(pt, ref sTipo, ref Painel, ref Potencial, ref Handle, ref Secao, ref Cor, ref Aplicacao, ref bpossuiRB))
							{
								if (Painel == conex.Painel)
								{
									string left = sTipo;
									if (Operators.CompareString(left, "P", TextCompare: true) == 0 || Operators.CompareString(left, "A", TextCompare: true) == 0 || Operators.CompareString(left, "E", TextCompare: true) == 0 || Operators.CompareString(left, "B", TextCompare: true) == 0)
									{
										BlockReference val6 = (BlockReference)Geral.HandleToObject(Handle);
										Point3d val7;
										if (val6 != null)
										{
											right = val6.Name;
											double x = value.X;
											val7 = val6.Position;
											num = x - val7.X;
											double y = value.Y;
											val7 = val6.Position;
											num2 = y - val7.Y;
										}
										TypedValue[] array = new TypedValue[2];
										array.SetValue((object)new TypedValue(0, (object)"INSERT"), 0);
										array.SetValue((object)new TypedValue(1001, (object)"DISPOSITIVO"), 1);
										SelectionFilter val8 = new SelectionFilter(array);
										PromptSelectionOptions val9 = new PromptSelectionOptions();
										val9.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 622]);
										PromptSelectionResult selection = editor.GetSelection(val9, val8);
										if ((int)selection.Status == 5100)
										{
											SelectionSet value2 = selection.Value;
											ObjectIdCollection val10 = new ObjectIdCollection(value2.GetObjectIds());
											foreach (object item in val10)
											{
												ObjectId val11 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
												Entity val12 = (Entity)val11.GetObject((OpenMode)0);
												BlockReference val13 = (BlockReference)(object)((val12 is BlockReference) ? val12 : null);
												if (val13 == null || Operators.CompareString(val13.Name, right, TextCompare: true) != 0)
												{
													continue;
												}
												Entity ent = (Entity)(object)val13;
												short num3 = XDataDispositivo.BuscaPainelDispositivo(ref ent);
												val13 = (BlockReference)ent;
												Painel = num3;
												val7 = val13.Position;
												double x2 = val7.X;
												val7 = val13.Position;
												new Point2d(x2, val7.Y);
												DeclaracoesEntidades.StructureConexao conex2 = new DeclaracoesEntidades.StructureConexao
												{
													Nome = "",
													Tensao = "",
													Funcao = "",
													Enderecamento = 1,
													Usuario = Environment.UserName,
													Data = DateTime.Now.ToString()
												};
												if (Painel != conex.Painel)
												{
													continue;
												}
												ent = (Entity)(object)val13;
												string tipoImportado = "";
												string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
												val13 = (BlockReference)ent;
												string text2 = text;
												string left2 = text2;
												if (Operators.CompareString(left2, "P", TextCompare: true) != 0 && Operators.CompareString(left2, "A", TextCompare: true) != 0 && Operators.CompareString(left2, "E", TextCompare: true) != 0 && Operators.CompareString(left2, "B", TextCompare: true) != 0)
												{
													break;
												}
												conex2.Tipo = 3;
												conex2.Potencial = conex.Potencial;
												conex2.Disp1 = false;
												conex2.Disp2 = true;
												conex2.Secao = conex.Secao;
												conex2.Cor = conex.Cor;
												conex2.Aplicacao = conex.Aplicacao;
												conex2.Handle = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
												conex2.Painel = conex.Painel;
												conex2.Jumper = conex.Jumper;
												val7 = val13.Position;
												double num4 = val7.X + num;
												val7 = val13.Position;
												Point2d val14 = new Point2d(num4, val7.Y + num2);
												double num5;
												double num6;
												if (Operators.CompareString(tipoDerivacao, "V", TextCompare: true) != 0)
												{
													num5 = 1.0;
													num6 = 0.0;
												}
												else
												{
													num5 = 0.0;
													num6 = 1.0;
												}
												val7 = val13.Position;
												double num7 = val7.X + num + num5;
												val7 = val13.Position;
												Point2d val15 = new Point2d(num7, val7.Y + num2 + num6);
												Polyline pl2 = new Polyline();
												((Entity)pl2).SetDatabaseDefaults();
												((Entity)pl2).ColorIndex = DeclaracoesGeral.Conf.CorConexao;
												pl2.AddVertexAt(0, val15, 0.0, 0.0, 0.0);
												pl2.AddVertexAt(1, val14, 0.0, 0.0, 0.0);
												Point3dCollection val16 = new Point3dCollection();
												((Entity)pl).IntersectWith((Entity)(object)pl2, (Intersect)2, val16, IntPtr.Zero, IntPtr.Zero);
												if (val16.Count == 1)
												{
													val7 = val16[0];
													Point2d val17 = val7.Convert2d((PlanarEntity)new Plane());
													pl2.RemoveVertexAt(0);
													pl2.AddVertexAt(0, val17, 0.0, 0.0, 0.0);
													val3.AppendEntity((Entity)(object)pl2);
													DeclaracoesGeral.bAnularEventos = true;
													val.AddNewlyCreatedDBObject((DBObject)(object)pl2, true);
													XDataConexao.GravarXDataConexao(ref pl2, conex2);
													if (conex2.Tipo == 3)
													{
														CriarHatch(((Curve)pl2).StartPoint, ((Entity)pl).Layer, ((object)((DBObject)pl2).Handle/*cast due to constrained. prefix*/).ToString());
													}
												}
											}
										}
									}
								}
								else
								{
									Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 618]), MsgBoxStyle.Exclamation);
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

	public void CriarHatch(Point3d pt, string layer, string handle)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected Obj, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			BlockTable val = (BlockTable)topTransaction.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val2 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val)[BlockTableRecord.ModelSpace], (OpenMode)1);
			Circle val3 = new Circle();
			((Entity)val3).SetDatabaseDefaults();
			val3.Center = pt;
			val3.Radius = 0.65;
			val2.AppendEntity((Entity)(object)val3);
			DeclaracoesGeral.bAnularEventos = true;
			topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
			ObjectIdCollection val4 = new ObjectIdCollection();
			val4.Add(((DBObject)val3).ObjectId);
			Hatch val5 = new Hatch();
			val2.AppendEntity((Entity)(object)val5);
			DeclaracoesGeral.bAnularEventos = true;
			topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val5, true);
			((Entity)val5).SetDatabaseDefaults();
			((Entity)val5).ColorIndex = DeclaracoesGeral.Conf.CorConexao;
			((Entity)val5).LineWeight = (LineWeight)9;
			((Entity)val5).Layer = layer;
			val5.SetHatchPattern((HatchPatternType)1, "SOLID");
			val5.Associative = true;
			val5.AppendLoop((HatchLoopTypes)16, val4);
			val5.EvaluateHatch(true);
			((DBObject)val3).Erase();
			Entity ent = (Entity)(object)val5;
			XDataConexao.GravarXDataHatchLinha(ref ent, handle, 1);
			val5 = (Hatch)ent;
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

	public static void ApagarDerivacoesLinhas(DeclaracoesEntidades.StructureConexao conex, string handle, string layer)
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected Obj, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected Obj, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected Obj, but got Unknown
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Expected Obj, but got Unknown
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_046f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0474: Unknown result type (might be due to invalid IL or missing references)
		//IL_0478: Unknown result type (might be due to invalid IL or missing references)
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_0483: Unknown result type (might be due to invalid IL or missing references)
		Apagados[] array = new Apagados[1];
		array[0].handle = handle;
		array[0].handleSup = "";
		array[0].bApagar = true;
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
					int potencial = default;
					int enderecamento = default;
					short tipo = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						if (Operators.CompareString(current.ObjectClass.DxfName.ToUpper(), "LWPOLYLINE", TextCompare: true) == 0)
						{
							Polyline pl = (Polyline)val.GetObject(current, (OpenMode)0);
							if (Operators.CompareString(((Entity)pl).Layer, layer, TextCompare: true) != 0)
							{
								continue;
							}
							DeclaracoesEntidades.StructureConexao conex2 = default;
							if (XDataConexao.lerXDataConexao(ref pl, ref conex2) && conex2.Tipo == 3 && conex.Potencial == conex2.Potencial)
							{
								array = (Apagados[])Utils.CopyArray(array, new Apagados[Information.UBound(array) + 1 + 1]);
								array[Information.UBound(array)].handle = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
								array[Information.UBound(array)].handleSup = conex2.Handle;
								array[Information.UBound(array)].bApagar = false;
							}
						}
						if ((Operators.CompareString(current.ObjectClass.DxfName.ToUpper(), "INSERT", TextCompare: true) == 0) | (Operators.CompareString(current.ObjectClass.DxfName.ToUpper(), "HATCH", TextCompare: true) == 0) | (Operators.CompareString(current.ObjectClass.DxfName.ToUpper(), "LWPOLYLINE", TextCompare: true) == 0))
						{
							Entity ent = (Entity)val.GetObject(current, (OpenMode)0);
							if (Operators.CompareString(ent.Layer, layer, TextCompare: true) != 0)
							{
								continue;
							}
							string text = XDataConexao.leHandleDerivacaoLinha(ref ent);
							if (Operators.CompareString(text, "", TextCompare: true) != 0)
							{
								array = (Apagados[])Utils.CopyArray(array, new Apagados[Information.UBound(array) + 1 + 1]);
								array[Information.UBound(array)].handle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
								array[Information.UBound(array)].handleSup = text;
								array[Information.UBound(array)].bApagar = false;
							}
						}
						if (Operators.CompareString(current.ObjectClass.DxfName.ToUpper(), "TEXT", TextCompare: true) != 0)
						{
							continue;
						}
						DBText text2 = (DBText)val.GetObject(current, (OpenMode)0);
						if (Operators.CompareString(((Entity)text2).Layer, layer, TextCompare: true) == 0)
						{
							string handle2 = "";
							if (XDataConexao.lerXDataAuxCircuito(ref text2, ref potencial, ref handle2, ref enderecamento, ref tipo) && conex.Potencial == potencial)
							{
								array = (Apagados[])Utils.CopyArray(array, new Apagados[Information.UBound(array) + 1 + 1]);
								array[Information.UBound(array)].handle = ((object)((DBObject)text2).Handle/*cast due to constrained. prefix*/).ToString();
								array[Information.UBound(array)].handleSup = handle2;
								array[Information.UBound(array)].bApagar = false;
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				List<string> list = new List<string>();
				list.Add(array[0].handle);
				bool flag;
				do
				{
					flag = false;
					int num = Information.UBound(array);
					for (int i = 1; i <= num; i++)
					{
						if (list.Contains(array[i].handleSup) & !array[i].bApagar)
						{
							list.Add(array[i].handle);
							array[i].bApagar = true;
							flag = true;
						}
					}
				}
				while (flag);
				int num2 = Information.UBound(array);
				for (int j = 1; j <= num2; j++)
				{
					if (array[j].bApagar)
					{
						long num3 = Convert.ToInt64(array[j].handle, 16);
						Handle val4 = new Handle(num3);
						ObjectId objectId = database.GetObjectId(false, val4, 0);
						DBObject val5 = val.GetObject(objectId, (OpenMode)1);
						val5.Erase();
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
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void ApagarTextosAuxiliaresCircuito(string layer, string handle)
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
					int potencial = default;
					int enderecamento = default;
					short tipo = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						if (Operators.CompareString(val5.Layer.ToString(), layer, TextCompare: true) != 0)
						{
							continue;
						}
						DBText text = (DBText)(object)((val5 is DBText) ? val5 : null);
						if (text != null)
						{
							string handle2 = "";
							if (XDataConexao.lerXDataAuxCircuito(ref text, ref potencial, ref handle2, ref enderecamento, ref tipo) && ((Operators.CompareString(handle, handle2, TextCompare: true) == 0) & ((tipo == 1) | (tipo == 2) | (tipo == 3))))
							{
								((DBObject)text).UpgradeOpen();
								((DBObject)text).Erase();
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

	public DBText criarTextoCircuito(DeclaracoesEntidades.StructureConexao conex, Polyline pl, string layer)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected Obj, but got Unknown
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected Obj, but got Unknown
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		double num = Math.Round(Math.PI, 2);
		double num2 = 5.0;
		double num3 = 0.5;
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
				Point3d point3dAt;
				Point3d point3dAt2;
				if (conex.Disp1)
				{
					point3dAt = pl.GetPoint3dAt(pl.NumberOfVertices - 1);
					point3dAt2 = pl.GetPoint3dAt(pl.NumberOfVertices - 2);
				}
				else
				{
					point3dAt = pl.GetPoint3dAt(0);
					point3dAt2 = pl.GetPoint3dAt(1);
				}
				double x = point3dAt2.X - point3dAt.X;
				double y = point3dAt2.Y - point3dAt.Y;
				double num4 = Math.Round(Math.Atan2(y, x), 2);
				double rotation;
				if (!((num4 <= num / 2.0) & (num4 > num / 2.0 * -1.0)))
				{
					val2.VerticalMode = (TextVerticalMode)1;
					val2.HorizontalMode = (TextHorizontalMode)2;
					rotation = num4 - Math.PI;
				}
				else
				{
					val2.VerticalMode = (TextVerticalMode)1;
					val2.HorizontalMode = (TextHorizontalMode)0;
					rotation = num4;
				}
				double num5 = num2 * Math.Cos(num4);
				double num6 = num2 * Math.Sin(num4);
				double num7 = num3 * Math.Cos(Math.PI / 2.0 - num4);
				double num8 = num3 * Math.Sin(Math.PI / 2.0 - num4);
				if (num8 < 0.0)
				{
					num8 *= -1.0;
				}
				if (num4 == num / 2.0)
				{
					num7 *= -1.0;
				}
				if (((num4 > 0.0) & (num4 < num / 2.0)) | ((num4 < 0.0) & (num4 > num / 2.0 * -1.0)))
				{
					num7 *= -1.0;
				}
				Point3d alignmentPoint = new Point3d(point3dAt.X + num5 + num7, point3dAt.Y + num6 + num8, 0.0);
				((Entity)val2).ColorIndex = DeclaracoesGeral.Conf.CorTextoCircuito;
				((Entity)val2).Layer = layer;
				val2.TextString = conex.Nome;
				val2.Height = DeclaracoesGeral.Conf.FonteCircuito;
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

	public DBText criarTextoDePara(DeclaracoesEntidades.StructureConexao conex, Polyline pl, string layer, short tipoTexto)
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Obj, but got Unknown
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected Obj, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		double num = Math.Round(Math.PI, 2);
		short num2 = tipoTexto;
		double num3 = default;
		double num4 = default;
		if (num2 == 1)
		{
			num3 = 5.0;
			num4 = -1.0;
			conex.Nome = "DE";
		}
		else if (num2 == 2)
		{
			num3 = 5.0;
			num4 = -1.0;
			conex.Disp1 = true;
			conex.Nome = "PARA";
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
				Point3d point3dAt;
				Point3d point3dAt2;
				if (conex.Disp1)
				{
					point3dAt = pl.GetPoint3dAt(pl.NumberOfVertices - 1);
					point3dAt2 = pl.GetPoint3dAt(pl.NumberOfVertices - 2);
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
				((Entity)val2).ColorIndex = DeclaracoesGeral.Conf.CorTextoCircuito;
				((Entity)val2).Layer = layer;
				val2.TextString = conex.Nome;
				val2.Height = DeclaracoesGeral.Conf.FonteCruzamento;
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

	public void editarDadosCircuitoDerivacaoJumper(DeclaracoesEntidades.StructureConexao conex)
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
						Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
						if (pl != null)
						{
							DeclaracoesEntidades.StructureConexao conex2 = default;
							if (XDataConexao.lerXDataConexao(ref pl, ref conex2) && (((conex2.Tipo == 1) | (conex2.Tipo == 3) | (conex2.Tipo == 4)) & (conex2.Potencial == conex.Potencial)))
							{
								conex2.Nome = conex.Nome;
								conex2.Enderecamento = conex.Enderecamento;
								conex2.Usuario = conex.Usuario;
								conex2.Data = conex.Data;
								((DBObject)pl).UpgradeOpen();
								XDataConexao.GravarXDataConexao(ref pl, conex2);
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

	public void editarTextoAuxiliarTipo123(DeclaracoesEntidades.StructureConexao conex)
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
					int potencial = default;
					int enderecamento = default;
					short tipo = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						DBText text = (DBText)(object)((val5 is DBText) ? val5 : null);
						if (text == null)
						{
							continue;
						}
						string handle = "";
						if (!XDataConexao.lerXDataAuxCircuito(ref text, ref potencial, ref handle, ref enderecamento, ref tipo))
						{
							continue;
						}
						if (!((tipo == 1) & (potencial == conex.Potencial)))
						{
							if (((tipo == 2) | (tipo == 3)) & (potencial == conex.Potencial))
							{
								((DBObject)text).UpgradeOpen();
								enderecamento = conex.Enderecamento;
								XDataConexao.GravarXDataAuxCircuito(ref text, potencial, handle, enderecamento, tipo);
							}
						}
						else
						{
							((DBObject)text).UpgradeOpen();
							enderecamento = conex.Enderecamento;
							XDataConexao.GravarXDataAuxCircuito(ref text, potencial, handle, enderecamento, tipo);
							text.TextString = conex.Nome;
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

	public void AlterarCorTamanhoTextoAuxiliarTipo123()
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
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					int potencial = default;
					int enderecamento = default;
					short tipo = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						DBText text = (DBText)(object)((val5 is DBText) ? val5 : null);
						if (text == null)
						{
							continue;
						}
						string handle = "";
						if (!XDataConexao.lerXDataAuxCircuito(ref text, ref potencial, ref handle, ref enderecamento, ref tipo))
						{
							continue;
						}
						if (tipo != 1)
						{
							if ((tipo == 2) | (tipo == 3))
							{
								((DBObject)text).UpgradeOpen();
								((Entity)text).ColorIndex = DeclaracoesGeral.Conf.CorTextoCircuito;
								text.Height = DeclaracoesGeral.Conf.FonteCruzamento;
							}
						}
						else
						{
							((DBObject)text).UpgradeOpen();
							((Entity)text).ColorIndex = DeclaracoesGeral.Conf.CorTextoCircuito;
							text.Height = DeclaracoesGeral.Conf.FonteCircuito;
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

	public void trocarPotencial(int potencialAlvo, DeclaracoesEntidades.StructureConexao conex)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			BlockTable val = (BlockTable)topTransaction.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val2 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val)[BlockTableRecord.ModelSpace], (OpenMode)0);
			BlockTableRecordEnumerator enumerator = default;
			try
			{
				enumerator = val2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					Entity val3 = (Entity)topTransaction.GetObject(current, (OpenMode)0);
					Polyline pl = (Polyline)(object)((val3 is Polyline) ? val3 : null);
					if (pl != null)
					{
						DeclaracoesEntidades.StructureConexao conex2 = default;
						if (XDataConexao.lerXDataConexao(ref pl, ref conex2) && (((conex2.Tipo == 1) | (conex2.Tipo == 3) | (conex2.Tipo == 4)) & (conex2.Potencial == potencialAlvo)))
						{
							((DBObject)pl).UpgradeOpen();
							conex2.Potencial = conex.Potencial;
							conex2.Nome = conex.Nome;
							conex2.Secao = conex.Secao;
							conex2.Cor = conex.Cor;
							conex2.Aplicacao = conex.Aplicacao;
							conex2.Enderecamento = conex.Enderecamento;
							conex2.Usuario = conex.Usuario;
							conex2.Data = conex.Data;
							XDataConexao.GravarXDataConexao(ref pl, conex2);
						}
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

	public static void carregaEquipComFiacao(ref List<int> lEquip)
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
					Polyline pl = (Polyline)(object)((val4 is Polyline) ? val4 : null);
					if (pl != null)
					{
						DeclaracoesEntidades.StructureConexao conex = default;
						if (XDataConexao.lerXDataConexao(ref pl, ref conex) && !lEquip.Contains(conex.Painel))
						{
							lEquip.Add(conex.Painel);
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
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			val.Abort();
			throw;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public void trocarPotencialTextoAuxiliar(int potencialAlvo, DeclaracoesEntidades.StructureConexao conex)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			BlockTable val = (BlockTable)topTransaction.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val2 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val)[BlockTableRecord.ModelSpace], (OpenMode)0);
			BlockTableRecordEnumerator enumerator = default;
			try
			{
				enumerator = val2.GetEnumerator();
				int potencial = default;
				int enderecamento = default;
				short tipo = default;
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					Entity val3 = (Entity)topTransaction.GetObject(current, (OpenMode)0);
					DBText text = (DBText)(object)((val3 is DBText) ? val3 : null);
					if (text == null)
					{
						continue;
					}
					string handle = "";
					if (XDataConexao.lerXDataAuxCircuito(ref text, ref potencial, ref handle, ref enderecamento, ref tipo) && (((tipo == 1) | (tipo == 2) | (tipo == 3)) & (potencial == potencialAlvo)))
					{
						((DBObject)text).UpgradeOpen();
						potencial = conex.Potencial;
						enderecamento = conex.Enderecamento;
						XDataConexao.GravarXDataAuxCircuito(ref text, potencial, handle, enderecamento, tipo);
						if (tipo == 1)
						{
							text.TextString = conex.Nome;
						}
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

	public void ligarTextoAuxiliar(string layer)
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
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					int potencial = default;
					int enderecamento = default;
					short tipo = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						DBText text = (DBText)(object)((val5 is DBText) ? val5 : null);
						if (text != null)
						{
							string handle = "";
							if (XDataConexao.lerXDataAuxCircuito(ref text, ref potencial, ref handle, ref enderecamento, ref tipo) && Operators.CompareString(((Entity)text).Layer.ToString(), layer, TextCompare: true) == 0 && !((Entity)text).Visible)
							{
								((DBObject)text).UpgradeOpen();
								((Entity)text).Visible = true;
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

	public void editarSecaoCor(short modo, int aplicacao = 0, string secaoA = "", string CorA = "")
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected Obj, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected Obj, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected Obj, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Invalid comparison between Unknown and I4
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected Obj, but got Unknown
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected Obj, but got Unknown
		//IL_0520: Unknown result type (might be due to invalid IL or missing references)
		//IL_0527: Expected Obj, but got Unknown
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_055f: Invalid comparison between Unknown and I4
		//IL_0595: Unknown result type (might be due to invalid IL or missing references)
		//IL_059c: Expected Obj, but got Unknown
		//IL_05ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d4: Invalid comparison between Unknown and I4
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected Obj, but got Unknown
		//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Expected Obj, but got Unknown
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		List<int> list = new List<int>();
		string secao = "";
		string cor = "";
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				try
				{
					TypedValue[] array = new TypedValue[2];
					array.SetValue((object)new TypedValue(0, (object)"LWPOLYLINE"), 0);
					array.SetValue((object)new TypedValue(1001, (object)"CONEXAO"), 1);
					SelectionFilter val5 = new SelectionFilter(array);
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
					PromptSelectionOptions val6 = new PromptSelectionOptions();
					val6.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 716]);
					PromptSelectionResult selection = editor.GetSelection(val6, val5);
					if ((int)selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						ObjectIdCollection val7 = new ObjectIdCollection(value.GetObjectIds());
						foreach (object item in val7)
						{
							ObjectId val8 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							Polyline pl = (Polyline)val8.GetObject((OpenMode)0);
							DeclaracoesEntidades.StructureConexao conex = default;
							if (XDataConexao.lerXDataConexao(ref pl, ref conex))
							{
								short tipo = conex.Tipo;
								if ((uint)(tipo - 1) <= 3u && !list.Contains(conex.Potencial))
								{
									list.Add(conex.Potencial);
								}
							}
						}
						if ((modo == 1) | (modo == 3))
						{
							PromptStringOptions val9 = new PromptStringOptions(Conversions.ToString(Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 717])));
							val9.AllowSpaces = false;
							val9.DefaultValue = DeclaracoesGeral.ativoRibbon.Secao;
							val9.UseDefaultValue = true;
							PromptResult val10 = editor.GetString(val9);
							if ((int)val10.Status != 5100)
							{
								goto IL_05f2;
							}
							secao = val10.StringResult;
						}
						if ((modo == 2) | (modo == 3))
						{
							PromptStringOptions val11 = new PromptStringOptions(Conversions.ToString(Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 718])));
							val11.AllowSpaces = false;
							val11.DefaultValue = DeclaracoesGeral.ativoRibbon.Cor;
							val11.UseDefaultValue = true;
							PromptResult val12 = editor.GetString(val11);
							if ((int)val12.Status != 5100)
							{
								goto IL_05f2;
							}
							cor = val12.StringResult;
						}
						if (modo == 4)
						{
							secao = secaoA;
							cor = CorA;
						}
						object[,] array2 = new object[3, 1];
						checked
						{
							BlockTableRecordEnumerator enumerator2 = default;
							try
							{
								enumerator2 = val4.GetEnumerator();
								while (enumerator2.MoveNext())
								{
									ObjectId current2 = enumerator2.Current;
									Entity val13 = (Entity)val2.GetObject(current2, (OpenMode)0);
									Polyline pl2 = (Polyline)(object)((val13 is Polyline) ? val13 : null);
									if (pl2 == null)
									{
										continue;
									}
									DeclaracoesEntidades.StructureConexao conex2 = default;
									if (XDataConexao.lerXDataConexao(ref pl2, ref conex2) && ((conex2.Tipo == 1) | (conex2.Tipo == 2) | (conex2.Tipo == 3) | (conex2.Tipo == 4)) && list.Contains(conex2.Potencial))
									{
										((DBObject)pl2).UpgradeOpen();
										conex2.Aplicacao = aplicacao;
										if ((modo == 1) | (modo == 3))
										{
											conex2.Secao = secao;
										}
										if ((modo == 2) | (modo == 3))
										{
											conex2.Cor = cor;
										}
										if (modo == 4)
										{
											conex2.Secao = secao;
											conex2.Cor = cor;
										}
										conex2.Usuario = Environment.UserName;
										conex2.Data = DateTime.Now.ToString();
										XDataConexao.GravarXDataConexao(ref pl2, conex2);
										array2 = (object[,])Utils.CopyArray(array2, new object[3, Information.UBound(array2, 2) + 1 + 1]);
										array2[0, Information.UBound(array2, 2)] = ((object)((DBObject)pl2).Handle/*cast due to constrained. prefix*/).ToString();
										array2[1, Information.UBound(array2, 2)] = conex2.Cor;
										array2[2, Information.UBound(array2, 2)] = conex2.Secao;
									}
								}
							}
							finally
							{
								((IDisposable)enumerator2)?.Dispose();
							}
							BlockTableRecordEnumerator enumerator3 = default;
							try
							{
								enumerator3 = val4.GetEnumerator();
								int potencial = default;
								int enderecamento = default;
								short tipo2 = default;
								while (enumerator3.MoveNext())
								{
									ObjectId current3 = enumerator3.Current;
									Entity val14 = (Entity)val2.GetObject(current3, (OpenMode)0);
									DBText text = (DBText)(object)((val14 is DBText) ? val14 : null);
									if (text == null)
									{
										continue;
									}
									string handle = "";
									if (!XDataConexao.lerXDataAuxCircuito(ref text, ref potencial, ref handle, ref enderecamento, ref tipo2) || !((tipo2 == 4) | (tipo2 == 5) | (tipo2 == 6)) || !list.Contains(potencial))
									{
										continue;
									}
									((DBObject)text).UpgradeOpen();
									int num = Information.UBound(array2, 2);
									for (int i = 0; i <= num; i++)
									{
										if (Operators.ConditionalCompareObjectEqual(array2[0, i], handle, TextCompare: true))
										{
											switch (tipo2)
											{
											case 6:
												text.TextString = Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject(array2[1, i], " ("), array2[2, i]), ")"));
												break;
											case 4:
												text.TextString = Conversions.ToString(array2[1, i]);
												break;
											case 5:
												text.TextString = Conversions.ToString(array2[2, i]);
												break;
											}
										}
									}
								}
							}
							finally
							{
								((IDisposable)enumerator3)?.Dispose();
							}
						}
					}
					goto IL_05f2;
					IL_05f2:
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
		PointMonitorToolTips.StartMonitor();
	}

	public void editarSecaoCorPaginas(short modo, List<string> lPaginas, int aplicacao = 0, string secaoA = "", string CorA = "")
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected Obj, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected Obj, but got Unknown
		//IL_0485: Unknown result type (might be due to invalid IL or missing references)
		//IL_048c: Expected Obj, but got Unknown
		//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c4: Invalid comparison between Unknown and I4
		//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Expected Obj, but got Unknown
		//IL_052f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0539: Invalid comparison between Unknown and I4
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected Obj, but got Unknown
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Expected Obj, but got Unknown
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		List<int> list = new List<int>();
		string secao = "";
		string cor = "";
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				try
				{
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
								DeclaracoesEntidades.StructureConexao conex = default;
								if (XDataConexao.lerXDataConexao(ref pl, ref conex) && ((conex.Tipo == 1) | (conex.Tipo == 2) | (conex.Tipo == 4)) && lPaginas.Contains(((Entity)pl).Layer.ToString()) && !list.Contains(conex.Potencial))
								{
									list.Add(conex.Potencial);
								}
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					if ((modo == 1) | (modo == 3))
					{
						PromptStringOptions val6 = new PromptStringOptions(Conversions.ToString(Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 717])));
						val6.AllowSpaces = false;
						val6.DefaultValue = DeclaracoesGeral.ativoRibbon.Secao;
						val6.UseDefaultValue = true;
						PromptResult val7 = editor.GetString(val6);
						if ((int)val7.Status != 5100)
						{
							goto IL_0558;
						}
						secao = val7.StringResult;
					}
					if ((modo == 2) | (modo == 3))
					{
						PromptStringOptions val8 = new PromptStringOptions(Conversions.ToString(Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 718])));
						val8.AllowSpaces = false;
						val8.DefaultValue = DeclaracoesGeral.ativoRibbon.Cor;
						val8.UseDefaultValue = true;
						PromptResult val9 = editor.GetString(val8);
						if ((int)val9.Status != 5100)
						{
							goto IL_0558;
						}
						cor = val9.StringResult;
					}
					if (modo == 4)
					{
						secao = secaoA;
						cor = CorA;
					}
					object[,] array = new object[3, 1];
					checked
					{
						BlockTableRecordEnumerator enumerator2 = default;
						try
						{
							enumerator2 = val4.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								ObjectId current2 = enumerator2.Current;
								Entity val10 = (Entity)val2.GetObject(current2, (OpenMode)0);
								Polyline pl2 = (Polyline)(object)((val10 is Polyline) ? val10 : null);
								if (pl2 == null)
								{
									continue;
								}
								DeclaracoesEntidades.StructureConexao conex2 = default;
								if (XDataConexao.lerXDataConexao(ref pl2, ref conex2) && ((conex2.Tipo == 1) | (conex2.Tipo == 2) | (conex2.Tipo == 3) | (conex2.Tipo == 4)) && list.Contains(conex2.Potencial))
								{
									((DBObject)pl2).UpgradeOpen();
									conex2.Aplicacao = aplicacao;
									if ((modo == 1) | (modo == 3))
									{
										conex2.Secao = secao;
									}
									if ((modo == 2) | (modo == 3))
									{
										conex2.Cor = cor;
									}
									if (modo == 4)
									{
										conex2.Secao = secao;
										conex2.Cor = cor;
									}
									conex2.Usuario = Environment.UserName;
									conex2.Data = DateTime.Now.ToString();
									XDataConexao.GravarXDataConexao(ref pl2, conex2);
									array = (object[,])Utils.CopyArray(array, new object[3, Information.UBound(array, 2) + 1 + 1]);
									array[0, Information.UBound(array, 2)] = ((object)((DBObject)pl2).Handle/*cast due to constrained. prefix*/).ToString();
									array[1, Information.UBound(array, 2)] = conex2.Cor;
									array[2, Information.UBound(array, 2)] = conex2.Secao;
								}
							}
						}
						finally
						{
							((IDisposable)enumerator2)?.Dispose();
						}
						BlockTableRecordEnumerator enumerator3 = default;
						try
						{
							enumerator3 = val4.GetEnumerator();
							int potencial = default;
							int enderecamento = default;
							short tipo = default;
							while (enumerator3.MoveNext())
							{
								ObjectId current3 = enumerator3.Current;
								Entity val11 = (Entity)val2.GetObject(current3, (OpenMode)0);
								DBText text = (DBText)(object)((val11 is DBText) ? val11 : null);
								if (text == null)
								{
									continue;
								}
								string handle = "";
								if (!XDataConexao.lerXDataAuxCircuito(ref text, ref potencial, ref handle, ref enderecamento, ref tipo) || !((tipo == 4) | (tipo == 5) | (tipo == 6)) || !list.Contains(potencial))
								{
									continue;
								}
								((DBObject)text).UpgradeOpen();
								int num = Information.UBound(array, 2);
								for (int i = 0; i <= num; i++)
								{
									if (Operators.ConditionalCompareObjectEqual(array[0, i], handle, TextCompare: true))
									{
										switch (tipo)
										{
										case 6:
											text.TextString = Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject(array[1, i], " ("), array[2, i]), ")"));
											break;
										case 4:
											text.TextString = Conversions.ToString(array[1, i]);
											break;
										case 5:
											text.TextString = Conversions.ToString(array[2, i]);
											break;
										}
									}
								}
							}
						}
						finally
						{
							((IDisposable)enumerator3)?.Dispose();
						}
						goto IL_0558;
					}
					IL_0558:
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
		PointMonitorToolTips.StartMonitor();
	}

	public void CriarMarcador(short cor, Point3d ptIns, bool cbCor, bool cbSecao, bool cbPot, string sPot, string layer, double fonte, DeclaracoesEntidades.StructureConexao conex, string handleSel)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected Obj, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected Obj, but got Unknown
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected Obj, but got Unknown
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			BlockTable val = (BlockTable)topTransaction.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val2 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val)[BlockTableRecord.ModelSpace], (OpenMode)1);
			Polyline val3 = new Polyline();
			((Entity)val3).SetDatabaseDefaults();
			((Entity)val3).ColorIndex = cor;
			((Entity)val3).Layer = layer;
			val3.AddVertexAt(0, new Point2d(ptIns.X - 1.0, ptIns.Y - 1.0), 0.0, 0.0, 0.0);
			val3.AddVertexAt(0, new Point2d(ptIns.X + 1.0, ptIns.Y + 1.0), 0.0, 0.0, 0.0);
			val2.AppendEntity((Entity)(object)val3);
			DeclaracoesGeral.bAnularEventos = true;
			topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
			Entity ent = (Entity)(object)val3;
			XDataConexao.GravarXDataHatchLinha(ref ent, handleSel, 2);
			val3 = (Polyline)ent;
			TextStyleTable val4 = (TextStyleTable)topTransaction.GetObject(database.TextStyleTableId, (OpenMode)0);
			ObjectId textStyleId = (((SymbolTable)val4).Has("Romans") ? ((SymbolTable)val4)["Romans"] : ((SymbolTable)val4)["Standard"]);
			string text = "";
			short tipo = 0;
			if (cbCor & (conex.Cor.Length > 0))
			{
				text = conex.Cor;
				tipo = 4;
			}
			if (cbSecao & (conex.Secao.Length > 0))
			{
				text = text + " (" + conex.Secao + ")";
				tipo = 5;
			}
			if (cbPot & (conex.Potencial > 0))
			{
				text = Conversions.ToString(conex.Potencial);
				if (Operators.CompareString(sPot, "", TextCompare: true) != 0)
				{
					text = sPot + " " + Conversions.ToString(conex.Potencial);
				}
				tipo = 5;
			}
			if (cbSecao & cbCor)
			{
				tipo = 6;
			}
			DBText text2 = new DBText();
			text2.TextString = text;
			((Entity)text2).ColorIndex = cor;
			((Entity)text2).Layer = layer;
			text2.Height = fonte;
			text2.HorizontalMode = (TextHorizontalMode)0;
			text2.VerticalMode = (TextVerticalMode)1;
			text2.TextStyleId = textStyleId;
			text2.WidthFactor = 1.0;
			text2.AlignmentPoint = new Point3d(ptIns.X + 1.0, ptIns.Y + 1.0, 0.0);
			val2.AppendEntity((Entity)(object)text2);
			DeclaracoesGeral.bAnularEventos = true;
			topTransaction.AddNewlyCreatedDBObject((DBObject)(object)text2, true);
			XDataConexao.GravarXDataAuxCircuito(ref text2, conex.Potencial, handleSel, 0, tipo);
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

	public static bool possuiTerminalRB(ref BlockReference blockref)
	{
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected Obj, but got Unknown
		bool result = false;
		bool flag = false;
		bool flag2 = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			AttributeCollection attributeCollection = blockref.AttributeCollection;
			foreach (object item in attributeCollection)
			{
				ObjectId val = ((item == null) ? default(ObjectId) : ((ObjectId)item));
				AttributeReference val2 = (AttributeReference)topTransaction.GetObject(val, (OpenMode)0);
				string left = Strings.Mid(val2.Tag.ToString().ToUpper(), 1, 1);
				if (!((Operators.CompareString(left, "R", TextCompare: true) == 0) & Versioned.IsNumeric(Strings.Mid(val2.Tag.ToString().ToUpper(), 2))))
				{
					if ((Operators.CompareString(left, "B", TextCompare: true) == 0) & Versioned.IsNumeric(Strings.Mid(val2.Tag.ToString().ToUpper(), 2)))
					{
						flag2 = true;
					}
				}
				else
				{
					flag = true;
				}
			}
			if (flag & flag2)
			{
				result = true;
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
		return result;
	}

	public void atualizaSecaoCor(int indiceApl, string secao, string cor)
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
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected Obj, but got Unknown
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
						if (XDataConexao.lerXDataConexao(ref pl, ref conex) && conex.Aplicacao == indiceApl)
						{
							if (!list.Contains(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString()))
							{
								list.Add(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
							}
							conex.Secao = secao;
							conex.Cor = cor;
							((DBObject)pl).UpgradeOpen();
							XDataConexao.GravarXDataConexao(ref pl, conex);
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				BlockTableRecordEnumerator enumerator2 = default;
				try
				{
					enumerator2 = val4.GetEnumerator();
					int potencial = default;
					int enderecamento = default;
					short tipo = default;
					while (enumerator2.MoveNext())
					{
						ObjectId current2 = enumerator2.Current;
						Entity val6 = (Entity)val2.GetObject(current2, (OpenMode)0);
						DBText text = (DBText)(object)((val6 is DBText) ? val6 : null);
						if (text == null)
						{
							continue;
						}
						string handle = "";
						if (XDataConexao.lerXDataAuxCircuito(ref text, ref potencial, ref handle, ref enderecamento, ref tipo) && ((tipo == 4) | (tipo == 5) | (tipo == 6)) && list.Contains(handle))
						{
							((DBObject)text).UpgradeOpen();
							switch (tipo)
							{
							case 6:
								text.TextString = cor + " (" + secao + ")";
								break;
							case 4:
								text.TextString = cor;
								break;
							case 5:
								text.TextString = secao;
								break;
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator2)?.Dispose();
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

	public void removeAplicacao(int indiceApl)
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
							DeclaracoesEntidades.StructureConexao conex = default;
							if (XDataConexao.lerXDataConexao(ref pl, ref conex) && conex.Aplicacao == indiceApl)
							{
								conex.Aplicacao = 0;
								((DBObject)pl).UpgradeOpen();
								XDataConexao.GravarXDataConexao(ref pl, conex);
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

	public void ativaAplicacao(int indiceApl, ref Dictionary<string, int> dicCores, int corApl)
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
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
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
						if (XDataConexao.lerXDataConexao(ref pl, ref conex) && conex.Aplicacao == indiceApl)
						{
							if (!dicCores.ContainsKey(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString()))
							{
								dicCores.Add(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString(), ((Entity)pl).ColorIndex);
							}
							((DBObject)pl).UpgradeOpen();
							((Entity)pl).ColorIndex = corApl;
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

	public void desativaAplicacao(ref Dictionary<string, int> dicCores)
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
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
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
							DeclaracoesEntidades.StructureConexao conex = default;
							if (XDataConexao.lerXDataConexao(ref pl, ref conex) && dicCores.ContainsKey(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString()))
							{
								((DBObject)pl).UpgradeOpen();
								((Entity)pl).ColorIndex = dicCores[((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString()];
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

	public void buscaAplicacoesUsadas(ref List<int> lAplUsadas, ref List<string> lPagUsadas)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected Obj, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected Obj, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected Obj, but got Unknown
		lAplUsadas.Clear();
		lPagUsadas.Clear();
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
						if (XDataConexao.lerXDataConexao(ref pl, ref conex) && conex.Aplicacao > 0)
						{
							if (!lAplUsadas.Contains(conex.Aplicacao))
							{
								lAplUsadas.Add(conex.Aplicacao);
							}
							if (!lPagUsadas.Contains(((Entity)pl).Layer))
							{
								lPagUsadas.Add(((Entity)pl).Layer);
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				lAplUsadas.Sort();
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

	public static void sincronizaCircuitos()
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected Obj, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected Obj, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Expected Obj, but got Unknown
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c0: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
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
					DataTable dataTable = new DataTable();
					dataTable.Columns.Add("Potencial", typeof(int));
					dataTable.Columns.Add("Tipo", typeof(int));
					dataTable.Columns.Add("PagNum", typeof(double));
					dataTable.Columns.Add("Posicao", typeof(string));
					dataTable.Columns.Add("Handle", typeof(string));
					dataTable.Columns.Add("CoordenadaX", typeof(double));
					dataTable.Columns.Add("Padrao", typeof(int));
					dataTable.Columns.Add("Indice", typeof(int));
					int num = 0;
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						int potencial = default;
						int enderecamento = default;
						short tipo = default;
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
							DBText text = (DBText)(object)((val5 is DBText) ? val5 : null);
							if (text != null)
							{
								string handle = "";
								if (XDataConexao.lerXDataAuxCircuito(ref text, ref potencial, ref handle, ref enderecamento, ref tipo) && ((tipo == 2) | (tipo == 3)))
								{
									((DBObject)text).UpgradeOpen();
									text.TextString = "";
									DataRow dataRow = dataTable.NewRow();
									dataRow["Potencial"] = potencial;
									dataRow["Tipo"] = tipo;
									dataRow["PagNum"] = Pagina.calculaPaginaDecimal(((Entity)text).Layer.ToString());
									string pagina = ((Entity)text).Layer.ToString();
									Entity ent = (Entity)(object)text;
									string posicao = Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2);
									text = (DBText)ent;
									dataRow["Posicao"] = Pagina.montaCruzamentoPagina(pagina, posicao);
									dataRow["Handle"] = ((object)((DBObject)text).Handle/*cast due to constrained. prefix*/).ToString();
									Point3d position = text.Position;
									dataRow["CoordenadaX"] = Math.Round(position.X, 1);
									dataRow["Padrao"] = enderecamento;
									dataRow["Indice"] = num;
									dataTable.Rows.Add(dataRow);
									num++;
								}
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					if (num != 0)
					{
						long num2 = -1L;
						object[,] array = new object[5, 1];
						string text2 = "";
						string text3 = "";
						text2 = "Padrao=1";
						text3 = "Potencial ASC, PagNum ASC, CoordenadaX ASC, Tipo";
						DataRow[] array2 = dataTable.Select(text2, text3);
						int upperBound = array2.GetUpperBound(0);
						for (int i = 0; i <= upperBound; i++)
						{
							num2++;
							array = (object[,])Utils.CopyArray(array, new object[5, (int)num2 + 1]);
							array[0, (int)num2] = RuntimeHelpers.GetObjectValue(array2[i][0]);
							array[1, (int)num2] = RuntimeHelpers.GetObjectValue(array2[i][1]);
							array[2, (int)num2] = RuntimeHelpers.GetObjectValue(array2[i][3]);
							array[3, (int)num2] = RuntimeHelpers.GetObjectValue(array2[i][4]);
							array[4, (int)num2] = "";
						}
						text2 = "Padrao=2";
						text3 = "Potencial ASC, Indice ASC";
						array2 = dataTable.Select(text2, text3);
						int upperBound2 = array2.GetUpperBound(0);
						for (int j = 0; j <= upperBound2; j++)
						{
							num2++;
							array = (object[,])Utils.CopyArray(array, new object[5, (int)num2 + 1]);
							array[0, (int)num2] = RuntimeHelpers.GetObjectValue(array2[j][0]);
							array[1, (int)num2] = RuntimeHelpers.GetObjectValue(array2[j][1]);
							array[2, (int)num2] = RuntimeHelpers.GetObjectValue(array2[j][3]);
							array[3, (int)num2] = RuntimeHelpers.GetObjectValue(array2[j][4]);
							array[4, (int)num2] = "";
						}
						long num3 = Information.UBound(array, 2);
						for (long num4 = 0L; num4 <= num3; num4++)
						{
							long num5 = Conversions.ToLong(array[0, (int)num4]);
							if (!Operators.ConditionalCompareObjectEqual(array[1, (int)num4], 2, TextCompare: true))
							{
								if (Operators.ConditionalCompareObjectEqual(array[1, (int)num4], 3, TextCompare: true) && num4 < Information.UBound(array, 2) && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(array[0, (int)(num4 + 1L)], num5, TextCompare: true), Operators.CompareObjectEqual(array[1, (int)(num4 + 1L)], 2, TextCompare: true))))
								{
									array[4, (int)num4] = RuntimeHelpers.GetObjectValue(array[2, (int)(num4 + 1L)]);
								}
							}
							else if (num4 > 0L && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(array[0, (int)(num4 - 1L)], num5, TextCompare: true), Operators.CompareObjectEqual(array[1, (int)(num4 - 1L)], 3, TextCompare: true))))
							{
								array[4, (int)num4] = RuntimeHelpers.GetObjectValue(array[2, (int)(num4 - 1L)]);
							}
						}
						long num6 = Information.UBound(array, 2);
						for (long num4 = 0L; num4 <= num6; num4++)
						{
							DBText val6 = (DBText)Geral.HandleToObject(Conversions.ToString(array[3, (int)num4]));
							if (val6 != null)
							{
								((DBObject)val6).UpgradeOpen();
								if (Operators.CompareString(Strings.Trim(Conversions.ToString(array[4, (int)num4])), "", TextCompare: true) != 0)
								{
									val6.TextString = Conversions.ToString(array[4, (int)num4]);
								}
								else
								{
									val6.TextString = "";
								}
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
	}

	public void editarConexoesDerivacoes()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected Obj, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected Obj, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected Obj, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Expected Obj, but got Unknown
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 616]), MsgBoxStyle.YesNo);
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
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
						if (pl != null)
						{
							DeclaracoesEntidades.StructureConexao conex = default;
							if (XDataConexao.lerXDataConexao(ref pl, ref conex))
							{
								((DBObject)pl).UpgradeOpen();
								((Entity)pl).ColorIndex = DeclaracoesGeral.Conf.CorConexao;
							}
						}
						BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						if (val6 != null)
						{
							string handle = "";
							Entity ent = (Entity)(object)val6;
							bool flag = XDataConexao.checaDerivacao(ref ent, ref handle);
							val6 = (BlockReference)ent;
							if (flag)
							{
								CriarHatch(val6.Position, ((Entity)val6).Layer, handle);
								((DBObject)val6).UpgradeOpen();
								((DBObject)val6).Erase();
							}
						}
						Hatch val7 = (Hatch)(object)((val5 is Hatch) ? val5 : null);
						if (val7 != null)
						{
							string handle2 = "";
							Entity ent = (Entity)(object)val7;
							bool flag = XDataConexao.checaDerivacao(ref ent, ref handle2);
							val7 = (Hatch)ent;
							if (flag)
							{
								((DBObject)val7).UpgradeOpen();
								((Entity)val7).ColorIndex = DeclaracoesGeral.Conf.CorConexao;
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

	public static double CalculaTerminalNumerico(string T)
	{
		double result = 1000000.0;
		string text = "";
		text = T.Trim().ToUpper();
		if (Operators.CompareString(text, "", TextCompare: true) != 0)
		{
			if (!Versioned.IsNumeric(text))
			{
				goto IL_003b;
			}
			int length = text.Length;
			int num = 1;
			while (num <= length)
			{
				if (Operators.CompareString(Strings.Mid(text, num, 1), ".", TextCompare: true) == 0 || Versioned.IsNumeric(Strings.Mid(text, num, 1)))
				{
					num = checked(num + 1);
					continue;
				}
				goto IL_003b;
			}
			string text2 = text;
			if (!int.TryParse(text2, out var _))
			{
				string[] array = text2.Split('.');
				string text3 = array[0];
				string text4 = array[1];
				if (Operators.CompareString(text3, "", TextCompare: true) == 0)
				{
					text3 = Conversions.ToString(0);
				}
				if (Operators.CompareString(text4, "", TextCompare: true) == 0)
				{
					text4 = Conversions.ToString(0);
				}
				double num2 = Conversions.ToDouble(text3);
				double num3 = Conversions.ToDouble(text4);
				num3 /= 10000.0;
				num2 += num3;
				result = num2;
			}
			else
			{
				result = Conversions.ToDouble(text);
			}
		}
		else
		{
			result = 0.0;
		}
		goto IL_05f0;
		IL_05f0:
		return result;
		IL_003b:
		checked
		{
			if (!((text.Length == 1) & (Strings.Asc(Strings.Mid(text, 1, 1)) >= 65) & (Strings.Asc(Strings.Mid(text, 1, 1)) <= 90)))
			{
				if (!(Versioned.IsNumeric(Strings.Mid(text, 1, text.Length - 1)) & (Strings.Asc(Strings.Mid(text, text.Length, 1)) >= 65) & (Strings.Asc(Strings.Mid(text, text.Length, 1)) <= 90)))
				{
					if ((Strings.Asc(Strings.Mid(text, 1, 1)) >= 65) & (Strings.Asc(Strings.Mid(text, 1, 1)) <= 90) & Versioned.IsNumeric(Strings.Mid(text, 2, text.Length - 1)))
					{
						string text5 = Strings.Mid(text, 2, text.Length - 1);
						if (int.TryParse(text5, out var _))
						{
							result = (double)Strings.Asc(Strings.Mid(text, 1, 1)) * 1000.0;
							result += Conversions.ToDouble(text5);
							goto IL_05f0;
						}
					}
					object left = Strings.InStr(1, text, ":", CompareMethod.Text);
					if (Operators.ConditionalCompareObjectEqual(left, 0, TextCompare: true))
					{
						left = Strings.InStr(1, text, "-", CompareMethod.Text);
					}
					if (Operators.ConditionalCompareObjectEqual(left, 0, TextCompare: true))
					{
						left = Strings.InStr(1, text, ".", CompareMethod.Text);
					}
					if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreater(left, 0, TextCompare: true), Operators.CompareObjectLess(left, text.Length, TextCompare: true))) && ((Strings.Asc(Strings.Mid(text, 1, 1)) >= 65) & (Strings.Asc(Strings.Mid(text, 1, 1)) <= 90)))
					{
						string text6 = Strings.Mid(text, 1, 1);
						string text7 = Strings.Mid(text, 2, Conversions.ToInteger(Operators.SubtractObject(left, 2)));
						if (Versioned.IsNumeric(text7))
						{
							string text8 = Strings.Mid(text, Conversions.ToInteger(Operators.AddObject(left, 1)));
							if (Versioned.IsNumeric(text8))
							{
								result = (double)Strings.Asc(text6) * 1000.0;
								result += Conversions.ToDouble(text7);
								result += Conversions.ToDouble(text8) / 1000.0;
								goto IL_05f0;
							}
						}
					}
					string text9 = "";
					string text10 = "";
					string text11 = "";
					int num4 = 1;
					int length2 = text.Length;
					for (int i = 1; i <= length2; i++)
					{
						if (!Versioned.IsNumeric(Strings.Mid(text, i, 1)))
						{
							if (Operators.CompareString(Strings.Mid(text, i, 1), ".", TextCompare: true) != 0)
							{
								text10 = Strings.Mid(text, i, 1);
								num4++;
							}
							continue;
						}
						switch (num4)
						{
						case 2:
							text11 += Strings.Mid(text, i, 1);
							break;
						case 1:
							text9 += Strings.Mid(text, i, 1);
							break;
						}
					}
					if (!((num4 == 2) & (Operators.CompareString(text9, "", TextCompare: true) != 0) & (Operators.CompareString(text11, "", TextCompare: true) != 0)))
					{
						if ((Strings.InStr(1, text, "+", CompareMethod.Text) > 0) | (Strings.InStr(1, text, "-", CompareMethod.Text) > 0))
						{
							string text8 = Conversions.ToString(text.Length);
							string text12 = "";
							int num5 = Conversions.ToInteger(text8);
							for (int j = 1; j <= num5 && Versioned.IsNumeric(Strings.Mid(text, j, 1)); j++)
							{
								text12 += Strings.Mid(text, j, 1);
							}
							if (Operators.CompareString(text12, "", TextCompare: true) != 0)
							{
								string numberDecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
								if (Strings.InStr(1, text, "+", CompareMethod.Text) <= 0)
								{
									if (Strings.InStr(1, text, "-", CompareMethod.Text) > 0)
									{
										text12 = text12 + numberDecimalSeparator + "0";
										result = Conversions.ToDouble(text12);
									}
								}
								else
								{
									text12 = text12 + numberDecimalSeparator + "1";
									result = Conversions.ToDouble(text12);
								}
							}
						}
					}
					else
					{
						result = Conversions.ToDouble(text9) * 1000.0;
						result += (double)Strings.Asc(text10);
						result += Conversions.ToDouble(text11) / 100.0;
					}
				}
				else
				{
					result = Conversions.ToDouble(Strings.Mid(text, 1, text.Length - 1));
					result += (double)Strings.Asc(Strings.Mid(text, text.Length, 1)) / 100.0;
				}
			}
			else
			{
				result = (double)Strings.Asc(text) / 100.0;
			}
			goto IL_05f0;
		}
	}

	public static void LeTodosCircuitos(ref DeclaracoesEntidades.StructureConexao[] conex)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				int num = 0;
				conex = new DeclaracoesEntidades.StructureConexao[1];
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
								DeclaracoesEntidades.StructureConexao conex2 = default;
								if (XDataConexao.lerXDataConexao(ref pl, ref conex2) && conex2.Tipo == 1)
								{
									num++;
									conex = (DeclaracoesEntidades.StructureConexao[])Utils.CopyArray(conex, new DeclaracoesEntidades.StructureConexao[num + 1]);
									conex[num] = conex2;
									conex[num].Pagina = ((Entity)pl).Layer.ToString();
									conex[num].Handle = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
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

	public static void LeTodosTextosAuxiliaresCircuito(ref structureAUXDERIVACAO[] sTextoAux)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		sTextoAux = new structureAUXDERIVACAO[1];
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
						int potencial = default;
						int enderecamento = default;
						short tipo = default;
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
							DBText text = (DBText)(object)((val5 is DBText) ? val5 : null);
							if (text != null)
							{
								string handle = "";
								if (XDataConexao.lerXDataAuxCircuito(ref text, ref potencial, ref handle, ref enderecamento, ref tipo) && tipo == 1)
								{
									num++;
									sTextoAux = (structureAUXDERIVACAO[])Utils.CopyArray(sTextoAux, new structureAUXDERIVACAO[num + 1]);
									sTextoAux[num].sHandle = ((object)((DBObject)text).Handle/*cast due to constrained. prefix*/).ToString();
									sTextoAux[num].Potencial = Conversions.ToString(potencial);
									sTextoAux[num].sTipo = "T";
									sTextoAux[num].sNome = text.TextString;
									num++;
									sTextoAux = (structureAUXDERIVACAO[])Utils.CopyArray(sTextoAux, new structureAUXDERIVACAO[num + 1]);
									sTextoAux[num].sHandle = handle;
									sTextoAux[num].Potencial = Conversions.ToString(potencial);
									sTextoAux[num].sTipo = "L";
									sTextoAux[num].sNome = "";
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

	public static void EditaValorNomeCircuito(string sHandle, string sNovoNome, string sTipo)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				if (Operators.CompareString(sTipo, "T", TextCompare: true) != 0)
				{
					if (Operators.CompareString(sTipo, "L", TextCompare: true) == 0)
					{
						Polyline pl = (Polyline)Geral.HandleToObject(sHandle);
						if (pl != null)
						{
							DeclaracoesEntidades.StructureConexao conex = default;
							if (XDataConexao.lerXDataConexao(ref pl, ref conex) && conex.Tipo == 1)
							{
								conex.Nome = sNovoNome;
								((DBObject)pl).UpgradeOpen();
								XDataConexao.GravarXDataConexao(ref pl, conex);
							}
						}
					}
				}
				else
				{
					DBText text = (DBText)Geral.HandleToObject(sHandle);
					if (text != null)
					{
						string handle = "";
						int potencial = default;
						int enderecamento = default;
						short tipo = default;
						if (XDataConexao.lerXDataAuxCircuito(ref text, ref potencial, ref handle, ref enderecamento, ref tipo))
						{
							((DBObject)text).UpgradeOpen();
							text.TextString = sNovoNome;
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
		Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
	}
}
