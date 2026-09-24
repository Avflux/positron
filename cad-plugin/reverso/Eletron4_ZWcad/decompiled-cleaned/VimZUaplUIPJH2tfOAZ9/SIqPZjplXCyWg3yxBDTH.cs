using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace VimZUaplUIPJH2tfOAZ9;

[StandardModule]
internal sealed class SIqPZjplXCyWg3yxBDTH
{
	public static short IRLplyYpYOJ(int P_0)
	{
		P_0 = Strings.Asc(Strings.UCase(Strings.Chr(P_0)));
		short result = (short)((Strings.InStr("AÃÁBCÇDEÉÊFGHIÍJKLMNOPQRSTUÚVWXYZ", Conversions.ToString(Strings.Chr(P_0)), CompareMethod.Text) != 0) ? checked((short)P_0) : 0);
		checked
		{
			if (P_0 == 8)
			{
				result = (short)P_0;
			}
			if (P_0 == 13)
			{
				result = (short)P_0;
			}
			if (P_0 == 32)
			{
				result = (short)P_0;
			}
			return result;
		}
	}

	public static short vXOplgmUZCR(short P_0)
	{
		string text = "1234567890";
		if (P_0 == Strings.Asc(Strings.Mid(Conversions.ToString(0.5), 2, 1)))
		{
			text += Conversions.ToString(Strings.Chr(P_0));
		}
		short result = (short)((Strings.InStr(text, Conversions.ToString(Strings.Chr(P_0)), CompareMethod.Text) != 0) ? P_0 : 0);
		switch (P_0)
		{
		case 32:
			result = P_0;
			break;
		case 8:
			result = P_0;
			break;
		case 13:
			result = P_0;
			break;
		case 45:
			result = P_0;
			break;
		}
		return result;
	}
}
