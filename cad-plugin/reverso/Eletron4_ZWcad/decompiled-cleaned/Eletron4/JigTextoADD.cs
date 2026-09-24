using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;

namespace Eletron4;

public class JigTextoADD : EntityJig
{
	private Point3d plf37F7fbv;

	private double Yy93q08a8y;

	private double DLF3asVjfT;

	private double fXE38AjAke;

	public JigTextoADD(DBText texto, ref double dDiferencaH, ref double dDiferencaV, double dAlturaTexto)
		: base((Entity)(object)texto)
	{
		Yy93q08a8y = dDiferencaH;
		DLF3asVjfT = dDiferencaV;
		fXE38AjAke = dAlturaTexto;
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
		Point3d val = plf37F7fbv;
		JigPromptPointOptions val2 = new JigPromptPointOptions();
		((PromptOptions)val2).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 744]));
		PromptPointResult val3 = prompts.AcquirePoint(val2);
		if (Operators.CompareString(((PromptResult)val3).StringResult, " ", TextCompare: true) != 0)
		{
			if ((int)((PromptResult)val3).Status == 5100)
			{
				plf37F7fbv = val3.Value;
				if (val.DistanceTo(plf37F7fbv) < 0.001)
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
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		if (Yy93q08a8y != 0.0)
		{
			((DBText)((EntityJig)this).Entity).HorizontalMode = (TextHorizontalMode)4;
			((DBText)((EntityJig)this).Entity).Position = new Point3d(plf37F7fbv.X - Yy93q08a8y, plf37F7fbv.Y - DLF3asVjfT, 0.0);
		}
		else
		{
			((DBText)((EntityJig)this).Entity).HorizontalMode = (TextHorizontalMode)4;
			((DBText)((EntityJig)this).Entity).Position = new Point3d(plf37F7fbv.X - Yy93q08a8y - fXE38AjAke / 2.0, plf37F7fbv.Y - DLF3asVjfT, 0.0);
		}
		return true;
	}
}
