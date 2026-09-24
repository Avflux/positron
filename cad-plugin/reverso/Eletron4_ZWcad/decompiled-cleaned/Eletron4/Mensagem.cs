using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class Mensagem
{
	public void CarregaMensagens()
	{
		string right = "";
		DeclaracoesGeral.mMensagem = new object[2, 1];
		string mensagens = Resources.Mensagens;
		int num = 0;
		string text = "";
		string text2 = "0";
		string text3 = "";
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		int num2 = Strings.Len(mensagens);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				while (true)
				{
					if (!flag)
					{
						if (Operators.CompareString(Strings.Mid(mensagens, i, 1), "[", TextCompare: true) == 0)
						{
							text = "";
							flag3 = true;
						}
						if (flag3)
						{
							text += Strings.Mid(mensagens, i, 1);
							if (Operators.CompareString(Strings.Mid(mensagens, i, 1), "]", TextCompare: true) == 0)
							{
								flag = true;
							}
						}
						if (flag)
						{
							flag = true;
							right = text;
							text = "";
							break;
						}
					}
					if (!flag)
					{
						break;
					}
					Strings.Mid(mensagens, i, 1);
					if (Operators.CompareString(Strings.Mid(mensagens, i, 1), "[", TextCompare: true) != 0 || !K8VpngHwvdj(mensagens, i))
					{
						if (Operators.CompareString(Strings.Mid(mensagens, i, 1), "{", TextCompare: true) != 0)
						{
							if (Operators.CompareString(Strings.Mid(mensagens, i, 1), "}", TextCompare: true) != 0)
							{
								if (flag4)
								{
									text3 += Strings.Mid(mensagens, i, 1);
								}
							}
							else
							{
								flag2 = true;
								flag4 = false;
							}
							if (flag2)
							{
								text3 = text3;
								text2 = "0";
								long num3 = Conversions.ToLong(text2);
								vYfpnAvBPT0(ref num3, ref text3);
								text2 = Conversions.ToString(num3);
								if (Operators.CompareString(text3, "", TextCompare: true) != 0 && Operators.CompareString(DeclaracoesGeral.ConfElet.Idioma, right, TextCompare: true) == 0)
								{
									DeclaracoesGeral.mMensagem = (object[,])Utils.CopyArray(DeclaracoesGeral.mMensagem, new object[2, num + 1]);
									DeclaracoesGeral.mMensagem[0, num] = Conversions.ToLong(text2);
									DeclaracoesGeral.mMensagem[1, num] = text3;
									num = Information.UBound(DeclaracoesGeral.mMensagem, 2) + 1;
									text3 = "";
									text2 = "0";
								}
								flag2 = false;
							}
						}
						else
						{
							flag4 = true;
							text3 = "";
						}
						break;
					}
					flag = false;
				}
			}
		}
	}

	private bool K8VpngHwvdj(string P_0, long P_1)
	{
		bool result = false;
		if (checked(Operators.CompareString(Strings.Mid(P_0, (int)P_1, 1), "[", TextCompare: true) == 0 && Strings.InStr("AÃÁBCÇDEÉÊFGHIÍJKLMNOPQRSTUÚVWXYZ", Strings.Mid(P_0, (int)(P_1 + 1L), 1), CompareMethod.Text) != 0 && Strings.InStr("AÃÁBCÇDEÉÊFGHIÍJKLMNOPQRSTUÚVWXYZ", Strings.Mid(P_0, (int)(P_1 + 2L), 1), CompareMethod.Text) != 0 && Operators.CompareString(Strings.Mid(P_0, (int)(P_1 + 3L), 1), "]", TextCompare: true) == 0))
		{
			result = true;
		}
		return result;
	}

	private void vYfpnAvBPT0(ref long P_0, ref string P_1)
	{
		bool flag = false;
		string text = "";
		string text2 = "";
		int num = Strings.Len(P_1);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Versioned.IsNumeric(Strings.Mid(P_1, i, 1)) & !flag)
			{
				text += Strings.Mid(P_1, i, 1);
			}
			if (Operators.CompareString(Strings.Mid(P_1, i, 1), "=", TextCompare: true) != 0)
			{
				if (flag)
				{
					text2 += Strings.Mid(P_1, i, 1);
				}
			}
			else
			{
				flag = true;
			}
		}
		if (!flag)
		{
			P_0 = 0L;
			P_1 = "";
		}
		else
		{
			P_0 = Conversions.ToLong(text);
			P_1 = text2;
		}
	}
}
