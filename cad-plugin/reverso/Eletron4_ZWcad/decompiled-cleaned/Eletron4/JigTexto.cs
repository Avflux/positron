using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;

namespace Eletron4;

public class JigTexto : EntityJig
{
	private Point3d VqGpnyCyss7;

	public JigTexto(Entity ent)
		: base(ent)
	{
	}

	protected override SamplerStatus Sampler(JigPrompts prompts)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected Obj, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Invalid comparison between Unknown and I4
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		Point3d vqGpnyCyss = VqGpnyCyss7;
		JigPromptPointOptions val = new JigPromptPointOptions();
		((PromptOptions)val).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 744]));
		PromptPointResult val2 = prompts.AcquirePoint(val);
		if (Operators.CompareString(((PromptResult)val2).StringResult, " ", TextCompare: true) != 0)
		{
			if ((int)((PromptResult)val2).Status == 5100)
			{
				VqGpnyCyss7 = val2.Value;
				if (vqGpnyCyss.DistanceTo(VqGpnyCyss7) < 0.001)
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
		((DBText)((EntityJig)this).Entity).Position = VqGpnyCyss7;
		return true;
	}
}
