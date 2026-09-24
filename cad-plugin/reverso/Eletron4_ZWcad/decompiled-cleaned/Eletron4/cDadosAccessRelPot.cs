using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class cDadosAccessRelPot
{
	public object db;

	public void fechaConexao()
	{
		NewLateBinding.LateCall(db, null, "fechaConexao", new object[0], null, null, null, IgnoreReturn: true);
	}

	public cDadosAccessRelPot()
	{
		string banco = DeclaracoesGeral.Conf.Banco;
		if (Operators.CompareString(banco, "A", TextCompare: true) != 0)
		{
			if (Operators.CompareString(banco, "S", TextCompare: true) != 0)
			{
				if (Operators.CompareString(banco, "SV", TextCompare: true) == 0)
				{
					db = new AcessoSQLServer();
				}
			}
			else
			{
				db = new AcessoSQLite();
			}
		}
		else
		{
			db = new AcessoAccess();
		}
	}

	public void CarregaDadosTodosDWGFiacao(ref DeclaracoesGeral.arqLogico[] mDWG)
	{
		checked
		{
			try
			{
				string text = "SELECT DISTINCT DWG FROM Circuitos4F";
				object instance = db;
				object[] array = new object[1] { text };
				object[] array2 = array;
				object obj = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				List<int> list = new List<int>();
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						list.Add(Conversions.ToInteger(dataTable.Rows[i][0]));
					}
				}
				text = "SELECT Indice, Caminho, Nome FROM DWG WHERE Tipo='F'";
				obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable2 = (DataTable)obj;
				if (dataTable2.Rows.Count <= 0)
				{
					return;
				}
				int num2 = dataTable2.Rows.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					if (list.Contains(Conversions.ToInteger(dataTable2.Rows[j][0])))
					{
						mDWG = (DeclaracoesGeral.arqLogico[])Utils.CopyArray(mDWG, new DeclaracoesGeral.arqLogico[Information.UBound(mDWG) + 1 + 1]);
						mDWG[Information.UBound(mDWG)].Indice = Conversions.ToInteger(dataTable2.Rows[j][0]);
						mDWG[Information.UBound(mDWG)].Path = Conversions.ToString(dataTable2.Rows[j][1]);
						mDWG[Information.UBound(mDWG)].Nome = Conversions.ToString(dataTable2.Rows[j][2]);
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void CarregaPnRevRelatPot(int dwgCorrente, string revisaoF, ref DeclaracoesFiacao.structurePnRev[] mPnRev)
	{
		checked
		{
			try
			{
				string text = "SELECT DISTINCT Painel FROM Circuitos4F WHERE DWG=@dwg AND Revisao=@revisao ORDER BY Painel";
				object instance = db;
				object[] array = new object[3]
				{
					"@dwg",
					dwgCorrente,
					OleDbType.Integer
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance2 = db;
				object[] array3 = new object[3]
				{
					"@revisao",
					revisaoF,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisaoF = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance3 = db;
				object[] array4 = new object[1] { text };
				array2 = array4;
				object obj = NewLateBinding.LateGet(instance3, null, "ExecuteReader", array4, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						mPnRev = (DeclaracoesFiacao.structurePnRev[])Utils.CopyArray(mPnRev, new DeclaracoesFiacao.structurePnRev[Information.UBound(mPnRev) + 1 + 1]);
						mPnRev[Information.UBound(mPnRev)].revisao = revisaoF;
						mPnRev[Information.UBound(mPnRev)].painel = Conversions.ToInteger(dataTable.Rows[i][0]);
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public List<string> carregaDispositivosRelatorio(int dwgCorrente, string revisaoF, int painel)
	{
		List<string> list = new List<string>();
		checked
		{
			try
			{
				string text = "SELECT DISTINCT Potencial FROM Circuitos4F WHERE DWG=@dwg AND Revisao=@revisao AND Painel=@painel ORDER BY Potencial";
				object instance = db;
				object[] array = new object[3]
				{
					"@dwg",
					dwgCorrente,
					OleDbType.Integer
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance2 = db;
				object[] array3 = new object[3]
				{
					"@revisao",
					revisaoF,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisaoF = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance3 = db;
				object[] array4 = new object[3]
				{
					"@painel",
					painel,
					OleDbType.Integer
				};
				array2 = array4;
				NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance4 = db;
				object[] array5 = new object[1] { text };
				array2 = array5;
				object obj = NewLateBinding.LateGet(instance4, null, "ExecuteReader", array5, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				List<int> list2 = new List<int>();
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (!list2.Contains(Conversions.ToInteger(dataTable.Rows[i][0])))
						{
							list2.Add(Conversions.ToInteger(dataTable.Rows[i][0]));
						}
					}
				}
				text = "SELECT Tag, Potencial FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Tipo='P' ORDER BY Tag";
				NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
				{
					"@dwgCorrente",
					dwgCorrente,
					OleDbType.Integer
				}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
				{
					"@revisao",
					revisaoF,
					OleDbType.Char
				}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisaoF = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
				{
					"@painel",
					painel,
					OleDbType.Integer
				}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable2 = (DataTable)obj;
				if (dataTable2.Rows.Count > 0)
				{
					int num2 = dataTable2.Rows.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						if (list2.Contains(Conversions.ToInteger(dataTable2.Rows[j][1])) && !list.Contains(Conversions.ToString(dataTable2.Rows[j][0])))
						{
							list.Add(Conversions.ToString(dataTable2.Rows[j][0]));
						}
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			return list;
		}
	}

	public void CarregaPotenciaisRelatorio(int dwgCorrente, string revisaoF, int painel, ref Relatorios_DistribuicaoPot.StructurePotenciais[] mPotenciais)
	{
		int num = 0;
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		checked
		{
			try
			{
				string text = "SELECT DISTINCT POTENCIAL FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel ORDER BY Potencial";
				object instance = db;
				object[] array = new object[3]
				{
					"@dwgCorrente",
					dwgCorrente,
					OleDbType.Integer
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance2 = db;
				object[] array3 = new object[3]
				{
					"@revisao",
					revisaoF,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisaoF = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance3 = db;
				object[] array4 = new object[3]
				{
					"@painel",
					painel,
					OleDbType.Integer
				};
				array2 = array4;
				NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance4 = db;
				object[] array5 = new object[1] { text };
				array2 = array5;
				object obj = NewLateBinding.LateGet(instance4, null, "ExecuteReader", array5, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count > 0)
				{
					int num2 = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num2; i++)
					{
						list.Add(Conversions.ToInteger(dataTable.Rows[i][0]));
					}
				}
				text = "SELECT Potencial, Circuito FROM Circuitos4F WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel ORDER BY Potencial";
				NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
				{
					"@dwgCorrente",
					dwgCorrente,
					OleDbType.Integer
				}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
				{
					"@revisao",
					revisaoF,
					OleDbType.Char
				}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisaoF = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
				{
					"@painel",
					painel,
					OleDbType.Integer
				}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable2 = (DataTable)obj;
				if (dataTable2.Rows.Count <= 0)
				{
					return;
				}
				int num3 = dataTable2.Rows.Count - 1;
				for (int j = 0; j <= num3; j++)
				{
					if (list.Contains(Conversions.ToInteger(dataTable2.Rows[j][0])) & !list2.Contains(Conversions.ToInteger(dataTable2.Rows[j][0])))
					{
						num++;
						mPotenciais = (Relatorios_DistribuicaoPot.StructurePotenciais[])Utils.CopyArray(mPotenciais, new Relatorios_DistribuicaoPot.StructurePotenciais[num + 1]);
						mPotenciais[num].iPotencial = Conversions.ToInteger(dataTable2.Rows[j][0]);
						mPotenciais[num].sNome = Conversions.ToString(dataTable2.Rows[j][1]);
						list2.Add(Conversions.ToInteger(dataTable2.Rows[j][0]));
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public object carregaTag1Relatorio(int dwgCorrente, string revisaoF, int potencial, ref Relatorios_DistribuicaoPot.StructureTag[] mTag)
	{
		List<string> list = new List<string>();
		mTag = new Relatorios_DistribuicaoPot.StructureTag[1];
		checked
		{
			try
			{
				string text = "SELECT Tag, Terminal, Pagina, Indice, Tipo, Handle, Potencial, Painel, NRegua FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Potencial=@potencial ORDER BY ordem";
				object instance = db;
				object[] array = new object[3]
				{
					"@dwgCorrente",
					dwgCorrente,
					OleDbType.Integer
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance2 = db;
				object[] array3 = new object[3]
				{
					"@revisao",
					revisaoF,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisaoF = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance3 = db;
				object[] array4 = new object[3]
				{
					"@potencial",
					potencial,
					OleDbType.Integer
				};
				array2 = array4;
				NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				potencial = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance4 = db;
				object[] array5 = new object[1] { text };
				array2 = array5;
				object obj = NewLateBinding.LateGet(instance4, null, "ExecuteReader", array5, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						list.Add(Conversions.ToString(dataTable.Rows[i][0]));
						int num2 = Information.UBound(mTag) + 1;
						mTag = (Relatorios_DistribuicaoPot.StructureTag[])Utils.CopyArray(mTag, new Relatorios_DistribuicaoPot.StructureTag[num2 + 1]);
						mTag[num2].sTag = Conversions.ToString(dataTable.Rows[i][0]);
						mTag[num2].sRegua = Conversions.ToString(dataTable.Rows[i][8]);
						mTag[num2].Terminal = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
						if (Operators.ConditionalCompareObjectNotEqual(dataTable.Rows[i][1], "", TextCompare: true))
						{
							mTag[num2].Terminal = Conversions.ToString(dataTable.Rows[i][1]);
						}
						mTag[num2].Pagina = Conversions.ToString(dataTable.Rows[i][2]);
						mTag[num2].Indice = Conversions.ToString(dataTable.Rows[i][3]);
						mTag[num2].Tipo = Conversions.ToString(dataTable.Rows[i][4]);
						mTag[num2].Handle = Conversions.ToString(dataTable.Rows[i][5]);
						mTag[num2].POTENCIAL = Conversions.ToString(dataTable.Rows[i][6]);
						mTag[num2].sPainel = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][7]));
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			return list;
		}
	}

	public object carregaTag2Relatorio(int dwgCorrente, string revisaoF, string revisaoI, string handle, ref Relatorios_DistribuicaoPot.StructureTag[] mTag)
	{
		List<string> result = new List<string>();
		string text = "";
		string text2 = "";
		string text3 = "";
		int num = 0;
		mTag = new Relatorios_DistribuicaoPot.StructureTag[1];
		checked
		{
			try
			{
				string text4 = "SELECT Handle2, Tag2, Terminal2, Painel2, DWG2, Pagina2, Indice, NRegua2 FROM interligacao4 WHERE DWG1=@dwg AND Revisao=@revisao AND Handle1=@handle";
				object instance = db;
				object[] array = new object[3]
				{
					"@dwg",
					dwgCorrente,
					OleDbType.Integer
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance2 = db;
				object[] array3 = new object[3]
				{
					"@revisao",
					revisaoI,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisaoI = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance3 = db;
				object[] array4 = new object[3]
				{
					"@handle",
					handle,
					OleDbType.Char
				};
				array2 = array4;
				NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				handle = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance4 = db;
				object[] array5 = new object[1] { text4 };
				array2 = array5;
				object obj = NewLateBinding.LateGet(instance4, null, "ExecuteReader", array5, null, null, new bool[1] { true });
				text4 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				bool flag = default;
				int num3 = default;
				int num2 = default;
				if (dataTable.Rows.Count == 1 && Operators.ConditionalCompareObjectNotEqual(handle, dataTable.Rows[0][0], TextCompare: true))
				{
					text = Conversions.ToString(dataTable.Rows[0][1]);
					text2 = Conversions.ToString(dataTable.Rows[0][2]);
					num2 = Conversions.ToInteger(dataTable.Rows[0][3]);
					string handle2 = Conversions.ToString(dataTable.Rows[0][0]);
					num3 = Conversions.ToInteger(dataTable.Rows[0][4]);
					string pagina = Conversions.ToString(dataTable.Rows[0][5]);
					int num4 = Conversions.ToInteger(dataTable.Rows[0][6]);
					text3 = clsTextos.TiraNothing(Conversions.ToString(dataTable.Rows[0][7]));
					int num5 = Information.UBound(mTag) + 1;
					mTag = (Relatorios_DistribuicaoPot.StructureTag[])Utils.CopyArray(mTag, new Relatorios_DistribuicaoPot.StructureTag[num5 + 1]);
					mTag[num5].Terminal = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
					if (Operators.CompareString(text3, "", TextCompare: true) != 0)
					{
						mTag[num5].sTag = text3;
						mTag[num5].sRegua = text3;
					}
					else
					{
						mTag[num5].sTag = text;
						mTag[num5].sRegua = "";
					}
					mTag[num5].Terminal = text2;
					mTag[num5].Pagina = pagina;
					mTag[num5].Indice = Conversions.ToString(num4);
					mTag[num5].Tipo = "B";
					mTag[num5].Handle = handle2;
					mTag[num5].sPainel = Dicionario.BuscaNomeDoPainel(num2);
					flag = true;
				}
				if (!flag)
				{
					text4 = "SELECT Handle1, Tag1, Terminal1, Painel1, DWG1, Pagina1, Indice, NRegua1 FROM interligacao4 WHERE DWG2=@dwg AND Revisao=@revisao AND Handle2=@handle";
					object instance5 = db;
					object[] array6 = new object[3]
					{
						"@dwg",
						dwgCorrente,
						OleDbType.Integer
					};
					array2 = array6;
					NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					object instance6 = db;
					object[] array7 = new object[3]
					{
						"@revisao",
						revisaoI,
						OleDbType.Char
					};
					array2 = array7;
					NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					revisaoI = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance7 = db;
					object[] array8 = new object[3]
					{
						"@handle",
						handle,
						OleDbType.Char
					};
					array2 = array8;
					NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					handle = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance8 = db;
					object[] array9 = new object[1] { text4 };
					array2 = array9;
					obj = NewLateBinding.LateGet(instance8, null, "ExecuteReader", array9, null, null, new bool[1] { true });
					text4 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DataTable dataTable2 = (DataTable)obj;
					if (dataTable2.Rows.Count == 1 && Operators.ConditionalCompareObjectNotEqual(handle, dataTable2.Rows[0][0], TextCompare: true))
					{
						text = Conversions.ToString(dataTable2.Rows[0][1]);
						text2 = Conversions.ToString(dataTable2.Rows[0][2]);
						num2 = Conversions.ToInteger(dataTable2.Rows[0][3]);
						string handle2 = Conversions.ToString(dataTable2.Rows[0][0]);
						num3 = Conversions.ToInteger(dataTable2.Rows[0][4]);
						string pagina = Conversions.ToString(dataTable2.Rows[0][5]);
						int num4 = Conversions.ToInteger(dataTable2.Rows[0][6]);
						text3 = clsTextos.TiraNothing(Conversions.ToString(dataTable2.Rows[0][7]));
						int num6 = Information.UBound(mTag) + 1;
						mTag = (Relatorios_DistribuicaoPot.StructureTag[])Utils.CopyArray(mTag, new Relatorios_DistribuicaoPot.StructureTag[num6 + 1]);
						mTag[num6].Terminal = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
						if (Operators.CompareString(text3, "", TextCompare: true) != 0)
						{
							mTag[num6].sTag = text3;
							mTag[num6].sRegua = text3;
						}
						else
						{
							mTag[num6].sTag = text;
							mTag[num6].sRegua = "";
						}
						mTag[num6].Terminal = text2;
						mTag[num6].Pagina = pagina;
						mTag[num6].Indice = Conversions.ToString(num4);
						mTag[num6].Tipo = "B";
						mTag[num6].Handle = handle2;
						mTag[num6].sPainel = Dicionario.BuscaNomeDoPainel(num2);
						flag = true;
					}
				}
				if (flag)
				{
					text4 = "SELECT Potencial FROM Fiacao WHERE DWG=@dwg AND Revisao=@revisao AND Painel=@painel AND Tag=@tag AND NRegua=@nregua AND Terminal=@terminal";
					object instance9 = db;
					object[] array10 = new object[3]
					{
						"@dwg",
						num3,
						OleDbType.Integer
					};
					array2 = array10;
					NewLateBinding.LateCall(instance9, null, "AddParameter", array10, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					num3 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					object instance10 = db;
					object[] array11 = new object[3]
					{
						"@revisao",
						revisaoF,
						OleDbType.Char
					};
					array2 = array11;
					NewLateBinding.LateCall(instance10, null, "AddParameter", array11, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					revisaoF = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance11 = db;
					object[] array12 = new object[3]
					{
						"@painel",
						num2,
						OleDbType.Integer
					};
					array2 = array12;
					NewLateBinding.LateCall(instance11, null, "AddParameter", array12, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					num2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					object instance12 = db;
					object[] array13 = new object[3]
					{
						"@tag",
						text,
						OleDbType.Char
					};
					array2 = array13;
					NewLateBinding.LateCall(instance12, null, "AddParameter", array13, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance13 = db;
					object[] array14 = new object[3]
					{
						"@nregua",
						text3,
						OleDbType.Char
					};
					array2 = array14;
					NewLateBinding.LateCall(instance13, null, "AddParameter", array14, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					text3 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance14 = db;
					object[] array15 = new object[3]
					{
						"@terminal",
						text2,
						OleDbType.Char
					};
					array2 = array15;
					NewLateBinding.LateCall(instance14, null, "AddParameter", array15, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance15 = db;
					object[] array16 = new object[1] { text4 };
					array2 = array16;
					obj = NewLateBinding.LateGet(instance15, null, "ExecuteReader", array16, null, null, new bool[1] { true });
					text4 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DataTable dataTable3 = (DataTable)obj;
					if (dataTable3.Rows.Count == 1)
					{
						num = Conversions.ToInteger(dataTable3.Rows[0][0]);
					}
					if (num > 0)
					{
						carregaTag2RelatorioB(num3, revisaoF, num, num2, ref mTag);
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			return result;
		}
	}

	public object carregaTag2RelatorioB(int dwgCorrente, string revisaoF, int potencial, int iPainel, ref Relatorios_DistribuicaoPot.StructureTag[] mTag)
	{
		List<string> list = new List<string>();
		mTag = new Relatorios_DistribuicaoPot.StructureTag[1];
		checked
		{
			try
			{
				string text = "SELECT Tag, Terminal, Pagina, Indice, Tipo, Handle, Potencial, Painel, NRegua FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Potencial=@potencial ORDER BY ordem";
				object instance = db;
				object[] array = new object[3]
				{
					"@dwgCorrente",
					dwgCorrente,
					OleDbType.Integer
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance2 = db;
				object[] array3 = new object[3]
				{
					"@revisao",
					revisaoF,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisaoF = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance3 = db;
				object[] array4 = new object[3]
				{
					"@painel",
					iPainel,
					OleDbType.Integer
				};
				array2 = array4;
				NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				iPainel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance4 = db;
				object[] array5 = new object[3]
				{
					"@potencial",
					potencial,
					OleDbType.Integer
				};
				array2 = array5;
				NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				potencial = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance5 = db;
				object[] array6 = new object[1] { text };
				array2 = array6;
				object obj = NewLateBinding.LateGet(instance5, null, "ExecuteReader", array6, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						list.Add(Conversions.ToString(dataTable.Rows[i][0]));
						int num2 = Information.UBound(mTag) + 1;
						mTag = (Relatorios_DistribuicaoPot.StructureTag[])Utils.CopyArray(mTag, new Relatorios_DistribuicaoPot.StructureTag[num2 + 1]);
						mTag[num2].sTag = Conversions.ToString(dataTable.Rows[i][0]);
						mTag[num2].sRegua = Conversions.ToString(dataTable.Rows[i][8]);
						mTag[num2].Terminal = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
						if (Operators.ConditionalCompareObjectNotEqual(dataTable.Rows[i][1], "", TextCompare: true))
						{
							mTag[num2].Terminal = Conversions.ToString(dataTable.Rows[i][1]);
						}
						mTag[num2].Pagina = Conversions.ToString(dataTable.Rows[i][2]);
						mTag[num2].Indice = Conversions.ToString(dataTable.Rows[i][3]);
						mTag[num2].Tipo = Conversions.ToString(dataTable.Rows[i][4]);
						mTag[num2].Handle = Conversions.ToString(dataTable.Rows[i][5]);
						mTag[num2].POTENCIAL = Conversions.ToString(dataTable.Rows[i][6]);
						mTag[num2].sPainel = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][7]));
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			return list;
		}
	}
}
