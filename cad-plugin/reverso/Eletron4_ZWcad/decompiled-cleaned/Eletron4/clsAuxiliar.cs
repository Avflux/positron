using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class clsAuxiliar
{
	public static bool BancoValido(bool bMsg = true)
	{
		bool result = true;
		string banco = DeclaracoesGeral.Conf.Banco;
		if (Operators.CompareString(banco, "A", TextCompare: true) != 0 && Operators.CompareString(banco, "S", TextCompare: true) != 0)
		{
			if (Operators.CompareString(banco, "SV", TextCompare: true) == 0)
			{
				if (!((Operators.CompareString(DeclaracoesGeral.Conf.DataSource.Trim(), "", TextCompare: true) == 0) | (Operators.CompareString(DeclaracoesGeral.Conf.BancoDeDados.Trim(), "", TextCompare: true) == 0) | (Operators.CompareString(DeclaracoesGeral.Conf.User.Trim(), "", TextCompare: true) == 0)))
				{
					cDadosSQLServer cDadosSQLServer2 = new cDadosSQLServer();
					if (!cDadosSQLServer2.testaConexao())
					{
						if (bMsg)
						{
							Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1968]), MsgBoxStyle.Critical, "Elétron");
						}
						result = false;
					}
					cDadosSQLServer2.fechaConexao();
				}
				else
				{
					if (bMsg)
					{
						Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 328]), MsgBoxStyle.Information);
					}
					result = false;
				}
			}
		}
		else if (Operators.CompareString(DeclaracoesGeral.Conf.DirProjeto.Trim(), "", TextCompare: true) != 0)
		{
			if (!File.Exists(DeclaracoesGeral.Conf.DirProjeto))
			{
				if (bMsg)
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 329]), MsgBoxStyle.Information);
				}
				result = false;
			}
		}
		else
		{
			if (bMsg)
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 328]), MsgBoxStyle.Information);
			}
			result = false;
		}
		return result;
	}
}
