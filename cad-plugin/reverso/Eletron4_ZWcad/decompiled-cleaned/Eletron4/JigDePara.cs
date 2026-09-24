using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;

namespace Eletron4;

public class JigDePara : EntityJig
{
	private Point3d kwB3Icc8on;

	public JigDePara(Entity ent)
		: base(ent)
	{
	}

	protected override SamplerStatus Sampler(JigPrompts prompts)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected Obj, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Invalid comparison between Unknown and I4
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Invalid comparison between Unknown and I4
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		Point3d val = kwB3Icc8on;
		JigPromptPointOptions val2 = new JigPromptPointOptions();
		((PromptOptions)val2).Keywords.Add(" ");
		((PromptOptions)val2).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 744]));
		PromptPointResult val3 = prompts.AcquirePoint(val2);
		if (Operators.CompareString(((PromptResult)val3).StringResult, " ", TextCompare: true) != 0)
		{
			if ((int)((PromptResult)val3).Status != 5100)
			{
				if ((int)((PromptResult)val3).Status == -5005)
				{
				}
			}
			else
			{
				kwB3Icc8on = val3.Value;
				if (val.DistanceTo(kwB3Icc8on) < 0.001)
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
		((BlockReference)((EntityJig)this).Entity).Position = kwB3Icc8on;
		return true;
	}
}
