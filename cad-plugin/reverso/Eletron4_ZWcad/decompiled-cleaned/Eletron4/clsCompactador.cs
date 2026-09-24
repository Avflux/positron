using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Access.Dao;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class clsCompactador
{
	[MethodImpl(MethodImplOptions.NoOptimization)]
	public void CompactarBD()
	{
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1808]), MsgBoxStyle.YesNo);
		if (msgBoxResult == MsgBoxResult.No)
		{
			return;
		}
		try
		{
			string text = DeclaracoesGeral.Conf.DirProjeto.Trim();
			string text2 = "";
			string text3 = ACcpPhlUHa(text);
			if (File.Exists(text))
			{
				FileInfo fileInfo = null;
				string left = text3;
				if (Operators.CompareString(left, ".mdb", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left, ".accdb", TextCompare: true) != 0)
					{
						if (Operators.CompareString(left, ".db", TextCompare: true) == 0)
						{
							fileInfo = new FileInfo(text.Replace(".db", ".db-journal"));
							string newValue = ".bak(" + DateAndTime.Now.Year + DateAndTime.Now.Month + DateAndTime.Now.Day + DateAndTime.Now.Hour + DateAndTime.Now.Minute + DateAndTime.Now.Second + ")";
							text2 = text.Replace(".db", newValue);
							FileSystem.FileCopy(text, text2);
						}
					}
					else
					{
						fileInfo = new FileInfo(text.Replace(".accdb", ".laccdb"));
						text2 = text.Replace(".accdb", "0.accdb");
					}
				}
				else
				{
					fileInfo = new FileInfo(text.Replace(".mdb", ".ldb"));
					text2 = text.Replace(".mdb", "0.mdb");
				}
				if (!fileInfo.Exists)
				{
					if (Operators.CompareString(DeclaracoesGeral.Conf.Banco, "A", TextCompare: true) != 0)
					{
						if (Operators.CompareString(DeclaracoesGeral.Conf.Banco, "S", TextCompare: true) == 0)
						{
							AcessoSQLite acessoSQLite = new AcessoSQLite(bTrans: false);
							try
							{
								string query = "vacuum";
								acessoSQLite.ExecuteNonQuery(query);
							}
							catch (Exception projectError)
							{
								ProjectData.SetProjectError(projectError);
								throw;
							}
							finally
							{
								acessoSQLite.fechaConexao();
							}
						}
					}
					else
					{
						DBEngine dBEngine = (DBEngine)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("CD7791B9-43FD-42C5-AE42-8DD2811F0419")));
						dBEngine.CompactDatabase(text, text2, RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(Missing.Value));
						dBEngine = null;
					}
					string newValue2 = ".bak(" + DateAndTime.Now.Year + DateAndTime.Now.Month + DateAndTime.Now.Day + DateAndTime.Now.Hour + DateAndTime.Now.Minute + DateAndTime.Now.Second + ")";
					string left2 = text3;
					if (Operators.CompareString(left2, ".mdb", TextCompare: true) != 0)
					{
						if (Operators.CompareString(left2, ".accdb", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left2, ".db", TextCompare: true) != 0)
							{
							}
						}
						else
						{
							File.Move(text, text.Replace(".accdb", newValue2));
							File.Move(text2, text2.Replace("0.accdb", ".accdb"));
						}
					}
					else
					{
						File.Move(text, text.Replace(".mdb", newValue2));
						File.Move(text2, text2.Replace("0.mdb", ".mdb"));
					}
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1811]));
				}
				else
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1810]));
				}
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1809]));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private string ACcpPhlUHa(string P_0)
	{
		string result = "";
		if (!P_0.EndsWith(".mdb"))
		{
			if (!P_0.EndsWith(".accdb"))
			{
				if (P_0.EndsWith(".db"))
				{
					result = ".db";
				}
			}
			else
			{
				result = ".accdb";
			}
		}
		else
		{
			result = ".mdb";
		}
		return result;
	}
}
