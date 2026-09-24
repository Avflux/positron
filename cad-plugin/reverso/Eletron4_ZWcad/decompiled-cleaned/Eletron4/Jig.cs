using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;

namespace Eletron4;

public class Jig : EntityJig
{
	private Point3d BmUpn0BlaSF;

	public Jig(Entity ent)
		: base(ent)
	{
	}

	protected override SamplerStatus Sampler(JigPrompts prompts)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected Obj, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Invalid comparison between Unknown and I4
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		Point3d bmUpn0BlaSF = BmUpn0BlaSF;
		JigPromptPointOptions val = new JigPromptPointOptions();
		((PromptOptions)val).Keywords.Add(" ");
		((PromptOptions)val).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 188]));
		PromptPointResult val2 = prompts.AcquirePoint(val);
		if (Operators.CompareString(((PromptResult)val2).StringResult, " ", TextCompare: true) != 0)
		{
			if ((int)((PromptResult)val2).Status == 5100)
			{
				BmUpn0BlaSF = val2.Value;
				if (bmUpn0BlaSF.DistanceTo(BmUpn0BlaSF) < 0.001)
				{
					return (SamplerStatus)1;
				}
			}
			return (SamplerStatus)0;
		}
		return (SamplerStatus)1;
	}

	protected override bool Update()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		((BlockReference)((EntityJig)this).Entity).Position = BmUpn0BlaSF;
		return true;
	}
}
