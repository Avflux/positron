using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;

namespace Eletron4;

public class JigConexao : EntityJig
{
	private Point3d oQEpnRyveSF;

	private int bN4pnmnAfYj;

	public JigConexao(ref Entity ent, int tipo)
		: base(ent)
	{
		bN4pnmnAfYj = 1;
		bN4pnmnAfYj = tipo;
	}

	protected override SamplerStatus Sampler(JigPrompts prompts)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected Obj, but got Unknown
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Invalid comparison between Unknown and I4
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Invalid comparison between Unknown and I4
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Invalid comparison between Unknown and I4
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		Point3d val = oQEpnRyveSF;
		JigPromptPointOptions val2 = new JigPromptPointOptions();
		if (!((((Polyline)((EntityJig)this).Entity).NumberOfVertices == 4) & ((bN4pnmnAfYj == 2) | (bN4pnmnAfYj == 3))))
		{
			if (!((((Polyline)((EntityJig)this).Entity).NumberOfVertices == 2) & (bN4pnmnAfYj == 4)))
			{
				((PromptOptions)val2).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 417]));
			}
			else
			{
				((PromptOptions)val2).Keywords.Add("J");
				((PromptOptions)val2).Message = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 418]), " "));
			}
		}
		else
		{
			((PromptOptions)val2).Keywords.Add("I");
			((PromptOptions)val2).Message = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 418]), " "));
		}
		((JigPromptOptions)val2).UserInputControls = (UserInputControls)4097;
		int numberOfVertices = ((Polyline)((EntityJig)this).Entity).NumberOfVertices;
		PromptPointResult val3;
		checked
		{
			Point2d point2dAt = ((Polyline)((EntityJig)this).Entity).GetPoint2dAt(numberOfVertices - 2);
			double x = point2dAt.X;
			point2dAt = ((Polyline)((EntityJig)this).Entity).GetPoint2dAt(numberOfVertices - 2);
			Point3d basePoint = new Point3d(x, point2dAt.Y, 0.0);
			((JigPromptGeometryOptions)val2).UseBasePoint = true;
			((JigPromptGeometryOptions)val2).BasePoint = basePoint;
			val3 = prompts.AcquirePoint(val2);
		}
		if ((int)((PromptResult)val3).Status != 5100)
		{
			if ((int)((PromptResult)val3).Status != -5002)
			{
				if ((int)((PromptResult)val3).Status == -5005)
				{
				}
			}
			else if (bN4pnmnAfYj == 1)
			{
				int numberOfVertices2 = ((Polyline)((EntityJig)this).Entity).NumberOfVertices;
				numberOfVertices2 = checked(numberOfVertices2 - 1);
				((Polyline)((EntityJig)this).Entity).RemoveVertexAt(numberOfVertices2);
			}
		}
		else
		{
			oQEpnRyveSF = val3.Value;
			if (val.DistanceTo(oQEpnRyveSF) < 0.001)
			{
				return (SamplerStatus)1;
			}
		}
		return (SamplerStatus)0;
	}

	protected override bool Update()
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0477: Unknown result type (might be due to invalid IL or missing references)
		//IL_047d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_0484: Unknown result type (might be due to invalid IL or missing references)
		//IL_0485: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_0442: Unknown result type (might be due to invalid IL or missing references)
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		//IL_050f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0515: Unknown result type (might be due to invalid IL or missing references)
		//IL_0522: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Unknown result type (might be due to invalid IL or missing references)
		if (bN4pnmnAfYj != 1)
		{
			Point2d val;
			if (!((bN4pnmnAfYj == 2) | (bN4pnmnAfYj == 3)))
			{
				if (bN4pnmnAfYj != 5)
				{
					if ((bN4pnmnAfYj == 6) | (bN4pnmnAfYj == 7) | (bN4pnmnAfYj == 8) | (bN4pnmnAfYj == 9))
					{
						val = new Point2d(oQEpnRyveSF.X, oQEpnRyveSF.Y);
						Point2d point2dAt = ((Polyline)((EntityJig)this).Entity).GetPoint2dAt(0);
						Point2d val2 = val;
						double num = default;
						double num2 = default;
						double num3 = default;
						double num4 = default;
						if (bN4pnmnAfYj != 6)
						{
							if (bN4pnmnAfYj != 7)
							{
								if (bN4pnmnAfYj != 8)
								{
									if (bN4pnmnAfYj == 9)
									{
										if (!(point2dAt.Y < val2.Y))
										{
											num = -2.0;
											num2 = -2.0;
											num3 = -2.0;
											num4 = 2.0;
										}
										else
										{
											num = -2.0;
											num2 = 2.0;
											num3 = -2.0;
											num4 = -2.0;
										}
									}
								}
								else if (!(point2dAt.Y < val2.Y))
								{
									num = 2.0;
									num2 = -2.0;
									num3 = 2.0;
									num4 = 2.0;
								}
								else
								{
									num = 2.0;
									num2 = 2.0;
									num3 = 2.0;
									num4 = -2.0;
								}
							}
							else if (!(point2dAt.X < val2.X))
							{
								num = -2.0;
								num2 = -2.0;
								num3 = 2.0;
								num4 = -2.0;
							}
							else
							{
								num = 2.0;
								num2 = -2.0;
								num3 = -2.0;
								num4 = -2.0;
							}
						}
						else if (!(point2dAt.X < val2.X))
						{
							num = -2.0;
							num2 = 2.0;
							num3 = 2.0;
							num4 = 2.0;
						}
						else
						{
							num = 2.0;
							num2 = 2.0;
							num3 = -2.0;
							num4 = 2.0;
						}
						Point2d val3 = new Point2d(point2dAt.X + num, point2dAt.Y + num2);
						((Polyline)((EntityJig)this).Entity).SetPointAt(1, val3);
						Point2d val4 = new Point2d(val2.X + num3, val2.Y + num4);
						((Polyline)((EntityJig)this).Entity).SetPointAt(2, val4);
						((Polyline)((EntityJig)this).Entity).SetPointAt(3, val);
					}
				}
				else
				{
					val = new Point2d(oQEpnRyveSF.X, oQEpnRyveSF.Y);
					Point2d point2dAt2 = ((Polyline)((EntityJig)this).Entity).GetPoint2dAt(0);
					Point2d point2dAt3 = ((Polyline)((EntityJig)this).Entity).GetPoint2dAt(3);
					bool flag = false;
					flag = !(val.Y <= point2dAt2.Y);
					double num5;
					double num6;
					if (!(point2dAt2.X < point2dAt3.X))
					{
						num5 = -2.0;
						num6 = 2.0;
					}
					else
					{
						num5 = 2.0;
						num6 = -2.0;
					}
					if (!flag)
					{
						Point2d val5 = new Point2d(point2dAt2.X + num5, point2dAt2.Y - 2.0);
						((Polyline)((EntityJig)this).Entity).SetPointAt(1, val5);
						Point2d val6 = new Point2d(point2dAt3.X + num6, point2dAt3.Y - 2.0);
						((Polyline)((EntityJig)this).Entity).SetPointAt(2, val6);
					}
					else
					{
						Point2d val7 = new Point2d(point2dAt2.X + num5, point2dAt2.Y + 2.0);
						((Polyline)((EntityJig)this).Entity).SetPointAt(1, val7);
						Point2d val8 = new Point2d(point2dAt3.X + num6, point2dAt3.Y + 2.0);
						((Polyline)((EntityJig)this).Entity).SetPointAt(2, val8);
					}
				}
			}
			else
			{
				val = new Point2d(oQEpnRyveSF.X, oQEpnRyveSF.Y);
				Point2d point2dAt4 = ((Polyline)((EntityJig)this).Entity).GetPoint2dAt(0);
				Point2d point2dAt5 = ((Polyline)((EntityJig)this).Entity).GetPoint2dAt(3);
				if (bN4pnmnAfYj != 2)
				{
					if (bN4pnmnAfYj == 3)
					{
						bool flag2 = false;
						if (!(point2dAt4.X > point2dAt5.X))
						{
							if ((val.X <= point2dAt5.X) & (val.X >= point2dAt4.X))
							{
								flag2 = true;
							}
						}
						else if ((val.X <= point2dAt4.X) & (val.X >= point2dAt5.X))
						{
							flag2 = true;
						}
						if (flag2)
						{
							Point2d val9 = new Point2d(val.X, point2dAt4.Y);
							((Polyline)((EntityJig)this).Entity).SetPointAt(1, val9);
							Point2d val10 = new Point2d(val.X, point2dAt5.Y);
							((Polyline)((EntityJig)this).Entity).SetPointAt(2, val10);
						}
					}
				}
				else
				{
					bool flag3 = false;
					if (!(point2dAt4.Y > point2dAt5.Y))
					{
						if ((val.Y <= point2dAt5.Y) & (val.Y >= point2dAt4.Y))
						{
							flag3 = true;
						}
					}
					else if ((val.Y <= point2dAt4.Y) & (val.Y >= point2dAt5.Y))
					{
						flag3 = true;
					}
					if (flag3)
					{
						Point2d val11 = new Point2d(point2dAt4.X, val.Y);
						((Polyline)((EntityJig)this).Entity).SetPointAt(1, val11);
						Point2d val12 = new Point2d(point2dAt5.X, val.Y);
						((Polyline)((EntityJig)this).Entity).SetPointAt(2, val12);
					}
				}
			}
		}
		else
		{
			int num7 = checked(((Polyline)((EntityJig)this).Entity).NumberOfVertices - 1);
			Point2d val13 = new Point2d(oQEpnRyveSF.X, oQEpnRyveSF.Y);
			((Polyline)((EntityJig)this).Entity).SetPointAt(num7, val13);
		}
		return true;
	}
}
