using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;

namespace Eletron4;

public class JigCloud : EntityJig
{
	private Point3d HQx3O6o4ER;

	public JigCloud(ref Entity ent)
		: base(ent)
	{
	}

	protected override SamplerStatus Sampler(JigPrompts prompts)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected Obj, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Invalid comparison between Unknown and I4
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Invalid comparison between Unknown and I4
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Invalid comparison between Unknown and I4
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		Point3d hQx3O6o4ER = HQx3O6o4ER;
		JigPromptPointOptions val = new JigPromptPointOptions();
		((PromptOptions)val).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 417]));
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
			else
			{
				int numberOfVertices2 = ((Polyline)((EntityJig)this).Entity).NumberOfVertices;
				numberOfVertices2 = checked(numberOfVertices2 - 1);
				((Polyline)((EntityJig)this).Entity).RemoveVertexAt(numberOfVertices2);
			}
		}
		else
		{
			HQx3O6o4ER = val2.Value;
			if (hQx3O6o4ER.DistanceTo(HQx3O6o4ER) < 0.001)
			{
				return (SamplerStatus)1;
			}
		}
		return (SamplerStatus)0;
	}

	protected override bool Update()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		int num = checked(((Polyline)((EntityJig)this).Entity).NumberOfVertices - 1);
		Point2d val = new Point2d(HQx3O6o4ER.X, HQx3O6o4ER.Y);
		((Polyline)((EntityJig)this).Entity).SetPointAt(num, val);
		return true;
	}
}
