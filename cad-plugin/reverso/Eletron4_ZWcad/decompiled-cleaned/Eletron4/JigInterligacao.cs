using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;

namespace Eletron4;

public class JigInterligacao : EntityJig
{
	private Point3d R3ApnX6TRGH;

	private int a1HpnUtFide;

	public JigInterligacao(ref Entity ent, int tipo)
		: base(ent)
	{
		a1HpnUtFide = 1;
		a1HpnUtFide = tipo;
	}

	protected override SamplerStatus Sampler(JigPrompts prompts)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected Obj, but got Unknown
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Invalid comparison between Unknown and I4
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Invalid comparison between Unknown and I4
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Invalid comparison between Unknown and I4
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		Point3d r3ApnX6TRGH = R3ApnX6TRGH;
		JigPromptPointOptions val = new JigPromptPointOptions();
		if (!((((Polyline)((EntityJig)this).Entity).NumberOfVertices == 4) & ((a1HpnUtFide == 2) | (a1HpnUtFide == 3))))
		{
			((PromptOptions)val).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 417]));
		}
		else
		{
			((PromptOptions)val).Keywords.Add("I");
			((PromptOptions)val).Message = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 418]), " "));
		}
		((JigPromptOptions)val).UserInputControls = (UserInputControls)4097;
		int numberOfVertices = ((Polyline)((EntityJig)this).Entity).NumberOfVertices;
		PromptPointResult val2;
		checked
		{
			Point2d point2dAt = ((Polyline)((EntityJig)this).Entity).GetPoint2dAt(numberOfVertices - 2);
			double x = point2dAt.X;
			point2dAt = ((Polyline)((EntityJig)this).Entity).GetPoint2dAt(numberOfVertices - 2);
			Point3d basePoint = new Point3d(x, point2dAt.Y, 0.0);
			((JigPromptGeometryOptions)val).UseBasePoint = true;
			((JigPromptGeometryOptions)val).BasePoint = basePoint;
			val2 = prompts.AcquirePoint(val);
		}
		if ((int)((PromptResult)val2).Status != 5100)
		{
			if ((int)((PromptResult)val2).Status != -5002)
			{
				if ((int)((PromptResult)val2).Status == -5005)
				{
				}
			}
			else if (a1HpnUtFide == 1)
			{
				int numberOfVertices2 = ((Polyline)((EntityJig)this).Entity).NumberOfVertices;
				numberOfVertices2 = checked(numberOfVertices2 - 1);
				((Polyline)((EntityJig)this).Entity).RemoveVertexAt(numberOfVertices2);
			}
		}
		else
		{
			R3ApnX6TRGH = val2.Value;
			if (r3ApnX6TRGH.DistanceTo(R3ApnX6TRGH) < 0.001)
			{
				return (SamplerStatus)1;
			}
		}
		return (SamplerStatus)0;
	}

	protected override bool Update()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		if (a1HpnUtFide != 1)
		{
			if ((a1HpnUtFide == 2) | (a1HpnUtFide == 3))
			{
				Point2d val = new Point2d(R3ApnX6TRGH.X, R3ApnX6TRGH.Y);
				Point2d point2dAt = ((Polyline)((EntityJig)this).Entity).GetPoint2dAt(0);
				Point2d point2dAt2 = ((Polyline)((EntityJig)this).Entity).GetPoint2dAt(3);
				if (a1HpnUtFide != 2)
				{
					if (a1HpnUtFide == 3)
					{
						bool flag = false;
						if (!(point2dAt.X > point2dAt2.X))
						{
							if ((val.X <= point2dAt2.X) & (val.X >= point2dAt.X))
							{
								flag = true;
							}
						}
						else if ((val.X <= point2dAt.X) & (val.X >= point2dAt2.X))
						{
							flag = true;
						}
						if (flag)
						{
							Point2d val2 = new Point2d(val.X, point2dAt.Y);
							((Polyline)((EntityJig)this).Entity).SetPointAt(1, val2);
							Point2d val3 = new Point2d(val.X, point2dAt2.Y);
							((Polyline)((EntityJig)this).Entity).SetPointAt(2, val3);
						}
					}
				}
				else
				{
					bool flag2 = false;
					if (!(point2dAt.Y > point2dAt2.Y))
					{
						if ((val.Y <= point2dAt2.Y) & (val.Y >= point2dAt.Y))
						{
							flag2 = true;
						}
					}
					else if ((val.Y <= point2dAt.Y) & (val.Y >= point2dAt2.Y))
					{
						flag2 = true;
					}
					if (flag2)
					{
						Point2d val4 = new Point2d(point2dAt.X, val.Y);
						((Polyline)((EntityJig)this).Entity).SetPointAt(1, val4);
						Point2d val5 = new Point2d(point2dAt2.X, val.Y);
						((Polyline)((EntityJig)this).Entity).SetPointAt(2, val5);
					}
				}
			}
		}
		else
		{
			int num = checked(((Polyline)((EntityJig)this).Entity).NumberOfVertices - 1);
			Point2d val6 = new Point2d(R3ApnX6TRGH.X, R3ApnX6TRGH.Y);
			((Polyline)((EntityJig)this).Entity).SetPointAt(num, val6);
		}
		return true;
	}
}
