using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class cDadosAccessFiacao
{
	public object db;

	public void fechaConexao()
	{
		NewLateBinding.LateCall(db, null, "fechaConexao", new object[0], null, null, null, IgnoreReturn: true);
	}

	public cDadosAccessFiacao()
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

	public void CarregaLayouRapidoPainel(int dwgCorrente, int painel, int posicao, ref List<string> lista)
	{
		checked
		{
			try
			{
				string text = "SELECT DISTINCT TAG, Y, X FROM Potencial WHERE Painel=@painel AND DWG=@dwgCorrente AND PosicaoNum=@posicao AND X<>0 AND Y<>0 ORDER BY Y DESC, X";
				object instance = db;
				object[] array = new object[3]
				{
					"@painel",
					painel,
					OleDbType.Integer
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance2 = db;
				object[] array3 = new object[3]
				{
					"@dwgCorrente",
					dwgCorrente,
					OleDbType.Integer
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance3 = db;
				object[] array4 = new object[3]
				{
					"@posicao",
					posicao,
					OleDbType.Integer
				};
				array2 = array4;
				NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				posicao = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance4 = db;
				object[] array5 = new object[1] { text };
				array2 = array5;
				object obj = NewLateBinding.LateGet(instance4, null, "ExecuteReader", array5, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				float num = 1000f;
				int num2 = 0;
				int num3 = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num3; i++)
				{
					if (Operators.ConditionalCompareObjectNotEqual(num, dataTable.Rows[i][1], TextCompare: true))
					{
						num2 = Conversions.ToInteger(Operators.DivideObject(Operators.SubtractObject(num, dataTable.Rows[i][1]), 10));
						int num4 = num2;
						for (int j = 1; j <= num4; j++)
						{
							lista.Add("---");
						}
						num = Conversions.ToSingle(dataTable.Rows[i][1]);
					}
					lista.Add(Conversions.ToString(dataTable.Rows[i][0]));
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void CarregaRevisoesDwgCorrente(int dwgCorrente, ref DeclaracoesFiacao.structureRevisoes[] mRevisoes)
	{
		checked
		{
			try
			{
				string text = "SELECT DISTINCT Revisao, Criador, Data FROM Fiacao WHERE DWG=@dwgCorrente ORDER BY Data";
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
				object[] array3 = new object[1] { text };
				array2 = array3;
				object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						mRevisoes = (DeclaracoesFiacao.structureRevisoes[])Utils.CopyArray(mRevisoes, new DeclaracoesFiacao.structureRevisoes[Information.UBound(mRevisoes) + 1 + 1]);
						mRevisoes[Information.UBound(mRevisoes)].revisao = Conversions.ToString(dataTable.Rows[i][0]);
						mRevisoes[Information.UBound(mRevisoes)].criador = Conversions.ToString(dataTable.Rows[i][1]);
						mRevisoes[Information.UBound(mRevisoes)].data = Conversions.ToDate(dataTable.Rows[i][2]);
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

	public void CarregaMaioresRevisoesDwg(ref DeclaracoesFiacao.structureRevisoes[] mRevisoes)
	{
		checked
		{
			try
			{
				string text = "SELECT DISTINCT Revisao, DWG, Data FROM Fiacao ORDER BY Data";
				object instance = db;
				object[] array = new object[1] { text };
				object[] array2 = array;
				object obj = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				List<int> list = new List<int>();
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (list.Contains(Conversions.ToInteger(dataTable.Rows[i][1])))
					{
						int num2 = Information.UBound(mRevisoes);
						for (int j = 1; j <= num2; j++)
						{
							if (Operators.ConditionalCompareObjectEqual(mRevisoes[j].Dwg, dataTable.Rows[i][1], TextCompare: true) && Operators.ConditionalCompareObjectGreater(dataTable.Rows[i][2], mRevisoes[j].data, TextCompare: true))
							{
								mRevisoes[j].revisao = Conversions.ToString(dataTable.Rows[i][0]);
								mRevisoes[j].data = Conversions.ToDate(dataTable.Rows[i][2]);
							}
						}
					}
					else
					{
						list.Add(Conversions.ToInteger(dataTable.Rows[i][1]));
						mRevisoes = (DeclaracoesFiacao.structureRevisoes[])Utils.CopyArray(mRevisoes, new DeclaracoesFiacao.structureRevisoes[Information.UBound(mRevisoes) + 1 + 1]);
						mRevisoes[Information.UBound(mRevisoes)].revisao = Conversions.ToString(dataTable.Rows[i][0]);
						mRevisoes[Information.UBound(mRevisoes)].Dwg = Conversions.ToInteger(dataTable.Rows[i][1]);
						mRevisoes[Information.UBound(mRevisoes)].data = Conversions.ToDate(dataTable.Rows[i][2]);
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

	public void CarregaRevisoesAnterioresDwgCorrente(int dwgCorrente, ref DeclaracoesFiacao.structureRevisoes[] mRevisoes, DateTime data)
	{
		checked
		{
			try
			{
				string text = "SELECT DISTINCT Revisao, Criador, Data FROM Fiacao WHERE DWG=@dwgCorrente AND Data<@data ORDER BY Data";
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
					"@data",
					data,
					OleDbType.Date
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				data = (DateTime)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(DateTime));
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
						mRevisoes = (DeclaracoesFiacao.structureRevisoes[])Utils.CopyArray(mRevisoes, new DeclaracoesFiacao.structureRevisoes[Information.UBound(mRevisoes) + 1 + 1]);
						mRevisoes[Information.UBound(mRevisoes)].revisao = Conversions.ToString(dataTable.Rows[i][0]);
						mRevisoes[Information.UBound(mRevisoes)].criador = Conversions.ToString(dataTable.Rows[i][1]);
						mRevisoes[Information.UBound(mRevisoes)].data = Conversions.ToDate(dataTable.Rows[i][2]);
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

	public void CarregaPnRev(int dwgCorrente, string revisao, ref DeclaracoesFiacao.structurePnRev[] mPnRev)
	{
		checked
		{
			try
			{
				string text = "SELECT DISTINCT Painel FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao ORDER BY Painel";
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
					revisao,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
						mPnRev[Information.UBound(mPnRev)].revisao = revisao;
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

	public void CarregaPotenciais(int dwgCorrente, string revisao, int painel, ref DeclaracoesFiacao.structurePontosPotencial[] mPot)
	{
		checked
		{
			try
			{
				string text = "SELECT Potencial, Handle, Terminal, Ordem, BLink FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel";
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
					revisao,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						mPot = (DeclaracoesFiacao.structurePontosPotencial[])Utils.CopyArray(mPot, new DeclaracoesFiacao.structurePontosPotencial[Information.UBound(mPot) + 1 + 1]);
						mPot[Information.UBound(mPot)].potencial = Conversions.ToInteger(dataTable.Rows[i][0]);
						mPot[Information.UBound(mPot)].handle = Conversions.ToString(dataTable.Rows[i][1]);
						mPot[Information.UBound(mPot)].terminal = Conversions.ToString(dataTable.Rows[i][2]);
						mPot[Information.UBound(mPot)].Ordem = Conversions.ToInteger(dataTable.Rows[i][3]);
						mPot[Information.UBound(mPot)].bLink = Conversions.ToBoolean(dataTable.Rows[i][4]);
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

	public void CarregaSequenciamento(int dwgCorrente, string revisao, int painel, int potencial, ref DataGridView dgSeq, ref Label lblSecao, ref Label lblCor)
	{
		checked
		{
			try
			{
				string text = "SELECT Indice, Tag, Terminal, Pagina, Secao, Cor, Alternativo FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Potencial=@potencial ORDER BY Ordem";
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
					revisao,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (i == 0)
					{
						lblSecao.Text = Conversions.ToString(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 612], dataTable.Rows[i][4]));
						lblCor.Text = Conversions.ToString(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 613], dataTable.Rows[i][5]));
					}
					dgSeq.Rows.Add(dataTable.Rows[i][0], dataTable.Rows[i][1], dataTable.Rows[i][6], dataTable.Rows[i][2], dataTable.Rows[i][3]);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public List<int> CarregaTodosPotenciais(int dwgCorrente, string revisao, int painel, string tag, bool b3T, ref Dictionary<int, int> dicPot)
	{
		List<int> list = new List<int>();
		checked
		{
			try
			{
				string text = "";
				object[] array2;
				if (Operators.CompareString(tag.Trim(), "", TextCompare: true) != 0)
				{
					text = "SELECT DISTINCT Potencial FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Tag=@tag ORDER BY Potencial";
					object instance = db;
					object[] array = new object[3]
					{
						"@dwgCorrente",
						dwgCorrente,
						OleDbType.Integer
					};
					array2 = array;
					NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					object instance2 = db;
					object[] array3 = new object[3]
					{
						"@revisao",
						revisao,
						OleDbType.Char
					};
					array2 = array3;
					NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
					object[] array5 = new object[3]
					{
						"@tag",
						tag,
						OleDbType.Char
					};
					array2 = array5;
					NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					tag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				}
				else
				{
					text = "SELECT DISTINCT Potencial FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel ORDER BY Potencial";
					object instance5 = db;
					object[] array6 = new object[3]
					{
						"@dwgCorrente",
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
						revisao,
						OleDbType.Char
					};
					array2 = array7;
					NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance7 = db;
					object[] array8 = new object[3]
					{
						"@painel",
						painel,
						OleDbType.Integer
					};
					array2 = array8;
					NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				}
				object obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (!b3T)
						{
							list.Add(Conversions.ToInteger(dataTable.Rows[i][0]));
						}
						else if (dicPot[Conversions.ToInteger(dataTable.Rows[i][0])] > 2)
						{
							list.Add(Conversions.ToInteger(dataTable.Rows[i][0]));
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

	public void CarregaDicPotenciais(int dwgCorrente, string revisao, ref Dictionary<int, int> dicPot)
	{
		checked
		{
			try
			{
				string text = "";
				text = "SELECT Potencial FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao ORDER BY Potencial";
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
					revisao,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance3 = db;
				object[] array4 = new object[1] { text };
				array2 = array4;
				object obj = NewLateBinding.LateGet(instance3, null, "ExecuteReader", array4, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				int num = 0;
				int num2 = -1;
				int num3 = -2;
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num4 = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num4; i++)
				{
					num2 = Conversions.ToInteger(dataTable.Rows[i][0]);
					if (num2 != num3)
					{
						if (num3 != -2)
						{
							dicPot.Add(num3, num);
						}
						num3 = num2;
						num = 0;
					}
					num++;
				}
				if (num3 != -2)
				{
					dicPot.Add(num3, num);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void CarregaSecaoCabos(int dwgCorrente, string revisao, int painel, ref List<string> lSecao)
	{
		checked
		{
			try
			{
				string text = "SELECT DISTINCT Secao FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel ORDER BY Secao";
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
					revisao,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						lSecao.Add(Conversions.ToString(dataTable.Rows[i][0]));
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

	public List<string> CarregaDispositivos(int dwgCorrente, string revisao, int painel)
	{
		List<string> list = new List<string>();
		checked
		{
			try
			{
				string text = "SELECT DISTINCT Tag FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel ORDER BY Tag";
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
					revisao,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						list.Add(Conversions.ToString(dataTable.Rows[i][0]));
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

	public void CarregaDispTipoIndexModelo(int dwgCorrente, string revisao, int painel, ref DeclaracoesFiacao.structureVF[] mDisp, bool bAdicionaDispSemFiacao = false)
	{
		List<string> list = new List<string>();
		checked
		{
			try
			{
				string text = "SELECT Tag, Alternativo, Tipo, IndexModelo, Handle FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND BJumper=@bJumper ORDER BY Tag";
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
					revisao,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
				NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
				{
					"@bJumper",
					false,
					OleDbType.Boolean
				}, null, null, null, IgnoreReturn: true);
				object instance4 = db;
				object[] array5 = new object[1] { text };
				array2 = array5;
				object obj = NewLateBinding.LateGet(instance4, null, "ExecuteReader", array5, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				List<string> list2 = new List<string>();
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					int num2 = default;
					for (int i = 0; i <= num; i++)
					{
						string item = "";
						object left = dataTable.Rows[i][2];
						if (!Conversions.ToBoolean(Conversions.ToBoolean(Operators.CompareObjectEqual(left, "P", TextCompare: true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, "A", TextCompare: true))))
						{
							if (!Operators.ConditionalCompareObjectEqual(left, "E", TextCompare: true))
							{
								if (Operators.ConditionalCompareObjectEqual(left, "B", TextCompare: true))
								{
									item = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[i][0], "-B"));
								}
							}
							else
							{
								item = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[i][0], "-E"));
							}
						}
						else
						{
							item = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[i][0], "-A"));
						}
						if (list2.Contains(item))
						{
							continue;
						}
						mDisp = (DeclaracoesFiacao.structureVF[])Utils.CopyArray(mDisp, new DeclaracoesFiacao.structureVF[mDisp.Length + 1]);
						mDisp[mDisp.Length - 1].Tag = Conversions.ToString(dataTable.Rows[i][0]);
						list.Add(Conversions.ToString(dataTable.Rows[i][0]));
						mDisp[mDisp.Length - 1].Alternativo = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][1]));
						string text2 = "";
						object left2 = dataTable.Rows[i][2];
						if (!Conversions.ToBoolean(Conversions.ToBoolean(Operators.CompareObjectEqual(left2, "P", TextCompare: true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left2, "A", TextCompare: true))))
						{
							if (!Operators.ConditionalCompareObjectEqual(left2, "E", TextCompare: true))
							{
								if (Operators.ConditionalCompareObjectEqual(left2, "B", TextCompare: true))
								{
									text2 = "B";
								}
							}
							else
							{
								text2 = "E";
							}
						}
						else
						{
							text2 = "A";
						}
						mDisp[mDisp.Length - 1].Tipo = text2;
						mDisp[mDisp.Length - 1].IndexModelo = Conversions.ToInteger(dataTable.Rows[i][3]);
						mDisp[mDisp.Length - 1].Handle = Conversions.ToString(dataTable.Rows[i][4]);
						if (Operators.CompareString(text2, "B", TextCompare: true) != 0)
						{
							string text3 = "SELECT PosicaoNum, Ordem, BlocoTopografico, BlocoLayout, Indice, Handle FROM Dispositivos4F WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Tag=@tag";
							object instance5 = db;
							object[] array6 = new object[3]
							{
								"@dwgCorrente",
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
								revisao,
								OleDbType.Char
							};
							array2 = array7;
							NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
							object instance7 = db;
							object[] array8 = new object[3]
							{
								"@painel",
								painel,
								OleDbType.Integer
							};
							array2 = array8;
							NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
							object instance8 = db;
							object[] array9 = new object[3] { "@tag", null, null };
							ref string tag = ref mDisp[mDisp.Length - 1].Tag;
							array9[1] = tag;
							array9[2] = OleDbType.Char;
							array2 = array9;
							NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							tag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
							object instance9 = db;
							object[] array10 = new object[1] { text3 };
							array2 = array10;
							obj = NewLateBinding.LateGet(instance9, null, "ExecuteReader", array10, null, null, new bool[1] { true });
							text3 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
							DataTable dataTable2 = (DataTable)obj;
							if (dataTable2.Rows.Count == 1)
							{
								object left3 = dataTable2.Rows[0][0];
								if (!Operators.ConditionalCompareObjectEqual(left3, 0, TextCompare: true))
								{
									if (!Operators.ConditionalCompareObjectEqual(left3, 2, TextCompare: true))
									{
										if (Operators.ConditionalCompareObjectEqual(left3, 3, TextCompare: true))
										{
											num2 = 1;
										}
									}
									else
									{
										num2 = 2;
									}
								}
								else
								{
									num2 = 0;
								}
								mDisp[mDisp.Length - 1].PosOrdem = Conversions.ToInteger(Operators.AddObject(num2 * 1000, dataTable2.Rows[0][1]));
								mDisp[mDisp.Length - 1].BlocoTopográfico = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0][2]));
								mDisp[mDisp.Length - 1].BlocoLayout = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0][3]));
								mDisp[mDisp.Length - 1].Indice = Conversions.ToInteger(dataTable2.Rows[0][4]);
								mDisp[mDisp.Length - 1].Handle = Conversions.ToString(dataTable2.Rows[0][5]);
							}
							dataTable2.Dispose();
						}
						else
						{
							mDisp[mDisp.Length - 1].PosOrdem = 3;
						}
						object left4 = dataTable.Rows[i][2];
						if (!Conversions.ToBoolean(Conversions.ToBoolean(Operators.CompareObjectEqual(left4, "P", TextCompare: true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left4, "A", TextCompare: true))))
						{
							if (!Operators.ConditionalCompareObjectEqual(left4, "E", TextCompare: true))
							{
								if (Operators.ConditionalCompareObjectEqual(left4, "B", TextCompare: true))
								{
									item = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[i][0], "-B"));
								}
							}
							else
							{
								item = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[i][0], "-E"));
							}
						}
						else
						{
							item = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[i][0], "-A"));
						}
						list2.Add(item);
					}
					dataTable.Dispose();
				}
				if (!bAdicionaDispSemFiacao)
				{
					return;
				}
				string text4 = "SELECT Tag, Tipo, PosicaoNum, Ordem, BlocoTopografico, BlocoLayout, Indice FROM Dispositivos4F WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel";
				object instance10 = db;
				object[] array11 = new object[3]
				{
					"@dwgCorrente",
					dwgCorrente,
					OleDbType.Integer
				};
				array2 = array11;
				NewLateBinding.LateCall(instance10, null, "AddParameter", array11, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance11 = db;
				object[] array12 = new object[3]
				{
					"@revisao",
					revisao,
					OleDbType.Char
				};
				array2 = array12;
				NewLateBinding.LateCall(instance11, null, "AddParameter", array12, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance12 = db;
				object[] array13 = new object[3]
				{
					"@painel",
					painel,
					OleDbType.Integer
				};
				array2 = array13;
				NewLateBinding.LateCall(instance12, null, "AddParameter", array13, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance13 = db;
				object[] array14 = new object[1] { text4 };
				array2 = array14;
				obj = NewLateBinding.LateGet(instance13, null, "ExecuteReader", array14, null, null, new bool[1] { true });
				text4 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable3 = (DataTable)obj;
				if (dataTable3.Rows.Count > 0)
				{
					int num3 = dataTable3.Rows.Count - 1;
					int num4 = default;
					for (int j = 0; j <= num3; j++)
					{
						if (list.Contains(Conversions.ToString(dataTable3.Rows[j][0])))
						{
							continue;
						}
						mDisp = (DeclaracoesFiacao.structureVF[])Utils.CopyArray(mDisp, new DeclaracoesFiacao.structureVF[mDisp.Length + 1]);
						mDisp[mDisp.Length - 1].Tag = Conversions.ToString(dataTable3.Rows[j][0]);
						list.Add(Conversions.ToString(dataTable3.Rows[j][0]));
						string tipo = "";
						object left5 = dataTable3.Rows[j][1];
						if (!Conversions.ToBoolean(Conversions.ToBoolean(Operators.CompareObjectEqual(left5, "P", TextCompare: true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left5, "A", TextCompare: true))))
						{
							if (!Operators.ConditionalCompareObjectEqual(left5, "E", TextCompare: true))
							{
								if (Operators.ConditionalCompareObjectEqual(left5, "B", TextCompare: true))
								{
									tipo = "B";
								}
							}
							else
							{
								tipo = "E";
							}
						}
						else
						{
							tipo = "A";
						}
						mDisp[mDisp.Length - 1].Tipo = tipo;
						mDisp[mDisp.Length - 1].IndexModelo = 0;
						object left6 = dataTable3.Rows[j][2];
						if (!Operators.ConditionalCompareObjectEqual(left6, 0, TextCompare: true))
						{
							if (!Operators.ConditionalCompareObjectEqual(left6, 2, TextCompare: true))
							{
								if (Operators.ConditionalCompareObjectEqual(left6, 3, TextCompare: true))
								{
									num4 = 1;
								}
							}
							else
							{
								num4 = 2;
							}
						}
						else
						{
							num4 = 0;
						}
						mDisp[mDisp.Length - 1].PosOrdem = Conversions.ToInteger(Operators.AddObject(num4 * 1000, dataTable3.Rows[j][3]));
						mDisp[mDisp.Length - 1].BlocoTopográfico = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable3.Rows[j][4]));
						mDisp[mDisp.Length - 1].BlocoLayout = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable3.Rows[j][5]));
						mDisp[mDisp.Length - 1].Indice = Conversions.ToInteger(dataTable3.Rows[j][6]);
					}
				}
				dataTable3.Dispose();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void AtualizaBlocoTopografico(int indice, string blocoTopografico)
	{
		try
		{
			string text = "";
			text = "UPDATE Dispositivos4F SET BlocoTopografico=@bloco WHERE Indice=@indice";
			object instance = db;
			object[] array = new object[3]
			{
				"@bloco",
				blocoTopografico,
				OleDbType.Char
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			blocoTopografico = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@indice",
				indice,
				OleDbType.Integer
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			indice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance3 = db;
			object[] array4 = new object[1] { text };
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "ExecuteNonQuery", array4, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public void AtualizaBlocoLayout(int indice, string blocoLayout)
	{
		try
		{
			string text = "";
			text = "UPDATE Dispositivos4F SET BlocoLayout=@bloco WHERE Indice=@indice";
			object instance = db;
			object[] array = new object[3]
			{
				"@bloco",
				blocoLayout,
				OleDbType.Char
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			blocoLayout = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@indice",
				indice,
				OleDbType.Integer
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			indice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance3 = db;
			object[] array4 = new object[1] { text };
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "ExecuteNonQuery", array4, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public void CarregaTerminaisDispositivo(int dwgCorrente, string revisao, int painel, string tag, ref DeclaracoesFiacao.structureFiacao[] mfiacao)
	{
		checked
		{
			try
			{
				string text = "SELECT Terminal FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Tag=@tag AND Tipo<>'B' ORDER BY TerminalNum, Terminal";
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
					revisao,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
				object[] array5 = new object[3]
				{
					"@tag",
					tag,
					OleDbType.Char
				};
				array2 = array5;
				NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				tag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance5 = db;
				object[] array6 = new object[1] { text };
				array2 = array6;
				object obj = NewLateBinding.LateGet(instance5, null, "ExecuteReader", array6, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				List<string> list = new List<string>();
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					string item = Conversions.ToString(dataTable.Rows[i][0]);
					if (!list.Contains(item))
					{
						list.Add(item);
					}
				}
				foreach (string item2 in list)
				{
					mfiacao = (DeclaracoesFiacao.structureFiacao[])Utils.CopyArray(mfiacao, new DeclaracoesFiacao.structureFiacao[mfiacao.Length + 1]);
					mfiacao[mfiacao.Length - 1].Terminal = item2;
					mfiacao[mfiacao.Length - 1].TipoBorne = 0;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void CarregaTerminaisContato(int dwgCorrente, string revisao, int indexModelo, ref DeclaracoesFiacao.structureFiacao[] mfiacao)
	{
		checked
		{
			try
			{
				string text = "SELECT Terminal FROM Contatos4F WHERE DWG=@dwgCorrente AND Revisao=@revisao AND IndexModelo=@indexModelo ORDER BY TerminalNum, Terminal";
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
					revisao,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance3 = db;
				object[] array4 = new object[3]
				{
					"@indexModelo",
					indexModelo,
					OleDbType.Integer
				};
				array2 = array4;
				NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				indexModelo = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
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
						mfiacao = (DeclaracoesFiacao.structureFiacao[])Utils.CopyArray(mfiacao, new DeclaracoesFiacao.structureFiacao[mfiacao.Length + 1]);
						mfiacao[mfiacao.Length - 1].Terminal = Conversions.ToString(dataTable.Rows[i][0]);
						mfiacao[mfiacao.Length - 1].TipoBorne = 0;
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

	public void CarregaTerminaisMascara(int dwgCorrente, string revisao, int indexModelo, ref DeclaracoesFiacao.structureFiacao[] mfiacao)
	{
		checked
		{
			try
			{
				string text = "SELECT Regua, Borne, Terminal FROM Portas4F WHERE DWG=@dwgCorrente AND Revisao=@revisao AND IndexModelo=@indexModelo ORDER BY Regua, TerminalNum, Terminal, Borne";
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
					revisao,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance3 = db;
				object[] array4 = new object[3]
				{
					"@indexModelo",
					indexModelo,
					OleDbType.Integer
				};
				array2 = array4;
				NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				indexModelo = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance4 = db;
				object[] array5 = new object[1] { text };
				array2 = array5;
				object obj = NewLateBinding.LateGet(instance4, null, "ExecuteReader", array5, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					string text2 = Conversions.ToString(dataTable.Rows[i][0]);
					string terminal = Conversions.ToString(dataTable.Rows[i][1]);
					string terminal2 = Conversions.ToString(dataTable.Rows[i][2]);
					mfiacao = (DeclaracoesFiacao.structureFiacao[])Utils.CopyArray(mfiacao, new DeclaracoesFiacao.structureFiacao[mfiacao.Length + 1]);
					mfiacao[mfiacao.Length - 1].NRegua = text2;
					mfiacao[mfiacao.Length - 1].TipoBorne = 0;
					if (Operators.CompareString(text2.Trim(), "", TextCompare: true) != 0)
					{
						mfiacao[mfiacao.Length - 1].Terminal = terminal;
					}
					else
					{
						mfiacao[mfiacao.Length - 1].Terminal = terminal2;
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

	public void CarregaTerminaisRegua(int dwgCorrente, string revisao, int painel, int indexRegua, ref DeclaracoesFiacao.structureFiacao[] mfiacao, bool bIncuiPG = false, bool bTodosOsBornes = false)
	{
		checked
		{
			try
			{
				string text = "SELECT Borne, Tipo, LM, Pagina, BlocoLayout, Indice FROM Bornes4F WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND IndexRegua=@indexRegua and Tipo<2 ORDER BY Ordem";
				if (bTodosOsBornes)
				{
					text = "SELECT Borne, Tipo, LM, Pagina, BlocoLayout, Indice FROM Bornes4F WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND IndexRegua=@indexRegua ORDER BY Ordem";
				}
				object[] array;
				NewLateBinding.LateCall(db, null, "AddParameter", array = new object[3]
				{
					"@dwgCorrente",
					dwgCorrente,
					OleDbType.Integer
				}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
				NewLateBinding.LateCall(db, null, "AddParameter", array = new object[3]
				{
					"@revisao",
					revisao,
					OleDbType.Char
				}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(string));
				NewLateBinding.LateCall(db, null, "AddParameter", array = new object[3]
				{
					"@painel",
					painel,
					OleDbType.Integer
				}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
				NewLateBinding.LateCall(db, null, "AddParameter", array = new object[3]
				{
					"@indexRegua",
					indexRegua,
					OleDbType.Integer
				}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				indexRegua = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
				object obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array = new object[1] { text }, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					mfiacao = (DeclaracoesFiacao.structureFiacao[])Utils.CopyArray(mfiacao, new DeclaracoesFiacao.structureFiacao[mfiacao.Length + 1]);
					mfiacao[mfiacao.Length - 1].Terminal = Conversions.ToString(dataTable.Rows[i][0]);
					mfiacao[mfiacao.Length - 1].TipoBorne = Conversions.ToInteger(dataTable.Rows[i][1]);
					if (Operators.CompareString(clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][2])), "", TextCompare: true) == 0)
					{
						mfiacao[mfiacao.Length - 1].LM = 0;
					}
					else
					{
						mfiacao[mfiacao.Length - 1].LM = Conversions.ToInteger(dataTable.Rows[i][2]);
					}
					if (bIncuiPG)
					{
						mfiacao[mfiacao.Length - 1].Pagina = Conversions.ToString(dataTable.Rows[i][3]);
					}
					mfiacao[mfiacao.Length - 1].BlocoLayout = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][4]));
					mfiacao[mfiacao.Length - 1].Indice = Conversions.ToLong(clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][5])));
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public bool TemReguas(int dwgCorrente, string revisao, int painel)
	{
		bool result = false;
		try
		{
			string text = "SELECT DISTINCT Regua FROM Bornes4F WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Tipo<2 ORDER BY Regua";
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
				revisao,
				OleDbType.Char
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
				result = true;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		return result;
	}

	public void CarregaReguas(int dwgCorrente, string revisao, int painel, ref DeclaracoesFiacao.structureRB[] mReguas)
	{
		checked
		{
			try
			{
				string text = "SELECT DISTINCT IndexRegua, Regua FROM Bornes4F WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel ORDER BY Regua";
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
					revisao,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						mReguas = (DeclaracoesFiacao.structureRB[])Utils.CopyArray(mReguas, new DeclaracoesFiacao.structureRB[mReguas.Length + 1]);
						mReguas[mReguas.Length - 1].indexRegua = Conversions.ToInteger(dataTable.Rows[i][0]);
						mReguas[mReguas.Length - 1].regua = Conversions.ToString(dataTable.Rows[i][1]);
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

	public void CarregaBornes(int dwgCorrente, string revisao, int painel, int indexRegua, ref DeclaracoesFiacao.structureBN[] mBornes)
	{
		checked
		{
			try
			{
				string text = "SELECT Indice, Borne, Handle, bReserva FROM Bornes4F WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND IndexRegua=@indexRegua ORDER BY Ordem";
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
					revisao,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
				object[] array5 = new object[3]
				{
					"@indexRegua",
					indexRegua,
					OleDbType.Integer
				};
				array2 = array5;
				NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				indexRegua = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
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
						mBornes = (DeclaracoesFiacao.structureBN[])Utils.CopyArray(mBornes, new DeclaracoesFiacao.structureBN[mBornes.Length + 1]);
						mBornes[mBornes.Length - 1].Potenciais = new int[1];
						mBornes[mBornes.Length - 1].Ordens = new int[1];
						mBornes[mBornes.Length - 1].indice = Conversions.ToInteger(dataTable.Rows[i][0]);
						mBornes[mBornes.Length - 1].borne = Conversions.ToString(dataTable.Rows[i][1]);
						mBornes[mBornes.Length - 1].handle = Conversions.ToString(dataTable.Rows[i][2]);
						mBornes[mBornes.Length - 1].bLink = false;
						mBornes[mBornes.Length - 1].bReserva = Conversions.ToBoolean(dataTable.Rows[i][3]);
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

	public void CarregaPotenciaisNaMatriz(int dwgCorrente, string revisao, int painel, int indexRegua, ref DeclaracoesFiacao.structureBN[] mBornes)
	{
		checked
		{
			try
			{
				string text = "SELECT Handle, Potencial, bLink, Ordem FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND IndexModelo=@indexModelo AND Tipo='B' AND BJumper=@bJumper";
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
					revisao,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
				object[] array5 = new object[3]
				{
					"@indexModelo",
					indexRegua,
					OleDbType.Integer
				};
				array2 = array5;
				NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				indexRegua = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
				{
					"@bJumper",
					false,
					OleDbType.Boolean
				}, null, null, null, IgnoreReturn: true);
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
						string right = Conversions.ToString(dataTable.Rows[i][0]);
						int num2 = Conversions.ToInteger(dataTable.Rows[i][1]);
						bool flag = Conversions.ToBoolean(dataTable.Rows[i][2]);
						int num3 = Conversions.ToInteger(dataTable.Rows[i][3]);
						int num4 = Information.UBound(mBornes);
						for (int j = 1; j <= num4; j++)
						{
							if (Operators.CompareString(mBornes[j].handle, right, TextCompare: true) == 0)
							{
								ref int[] potenciais = ref mBornes[j].Potenciais;
								potenciais = (int[])Utils.CopyArray(potenciais, new int[Information.UBound(mBornes[j].Potenciais) + 1 + 1]);
								mBornes[j].Potenciais[Information.UBound(mBornes[j].Potenciais)] = num2;
								ref int[] ordens = ref mBornes[j].Ordens;
								ordens = (int[])Utils.CopyArray(ordens, new int[Information.UBound(mBornes[j].Ordens) + 1 + 1]);
								mBornes[j].Ordens[Information.UBound(mBornes[j].Ordens)] = num3;
								if (flag)
								{
									mBornes[j].bLink = true;
								}
							}
						}
					}
				}
				int num5 = Information.UBound(mBornes);
				for (int k = 1; k <= num5; k++)
				{
					if (k != 1)
					{
						mBornes[k].Potencial = mBornes[k].Potenciais[0];
						int num6 = Information.UBound(mBornes[k].Potenciais);
						for (int l = 0; l <= num6; l++)
						{
							int num7 = Information.UBound(mBornes[k - 1].Potenciais);
							for (int m = 0; m <= num7; m++)
							{
								int num8 = mBornes[k].Potenciais[l];
								int num9 = mBornes[k - 1].Potenciais[m];
								int num10 = mBornes[k].Ordens[l];
								int num11 = mBornes[k - 1].Ordens[m];
								int num12 = num10 - num11;
								if (num12 < 0)
								{
									num12 *= -1;
								}
								if ((num8 > 0) & (num9 > 0) & (num8 == num9) & (num12 == 1))
								{
									mBornes[k].Potencial = num8;
									mBornes[k - 1].Potencial = num8;
								}
							}
						}
					}
					else
					{
						mBornes[k].Potencial = mBornes[k].Potenciais[Information.UBound(mBornes[k].Potenciais)];
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

	public void InsereLink(int dwgCorrente, string revisao, int painel, int indexRegua, string terminal, int potencial)
	{
		try
		{
			string text = "";
			text = "UPDATE Fiacao SET BLink=@bLink WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND IndexModelo=@indexModelo AND Terminal=@terminal AND Potencial=@potencial";
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@bLink",
				true,
				OleDbType.Boolean
			}, null, null, null, IgnoreReturn: true);
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
				revisao,
				OleDbType.Char
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
			object[] array5 = new object[3]
			{
				"@indexModelo",
				indexRegua,
				OleDbType.Integer
			};
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			indexRegua = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance5 = db;
			object[] array6 = new object[3]
			{
				"@terminal",
				terminal,
				OleDbType.Char
			};
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			terminal = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance6 = db;
			object[] array7 = new object[3]
			{
				"@potencial",
				potencial,
				OleDbType.Integer
			};
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			potencial = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance7 = db;
			object[] array8 = new object[1] { text };
			array2 = array8;
			NewLateBinding.LateCall(instance7, null, "ExecuteNonQuery", array8, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public void RemoveLink(int dwgCorrente, string revisao, int painel, int indexRegua, int potencial)
	{
		try
		{
			string text = "";
			text = "UPDATE Fiacao SET BLink=@bLink WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND IndexModelo=@indexModelo AND Potencial=@potencial AND Tipo='B'";
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@bLink",
				false,
				OleDbType.Boolean
			}, null, null, null, IgnoreReturn: true);
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
				revisao,
				OleDbType.Char
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
			object[] array5 = new object[3]
			{
				"@indexModelo",
				indexRegua,
				OleDbType.Integer
			};
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			indexRegua = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance5 = db;
			object[] array6 = new object[3]
			{
				"@potencial",
				potencial,
				OleDbType.Integer
			};
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			potencial = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance6 = db;
			object[] array7 = new object[1] { text };
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "ExecuteNonQuery", array7, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public void CarregaLigacoesTerminal(int dwgCorrente, string revisao, int painel, string tag, string tipo, ref DeclaracoesFiacao.structureFiacao[] mFiacao, ref DeclaracoesFiacao.structureLink[] mLink)
	{
		checked
		{
			try
			{
				int num = Information.UBound(mFiacao);
				for (int i = 1; i <= num; i++)
				{
					string terminal = mFiacao[i].Terminal;
					bool flag = false;
					string nRegua = mFiacao[i].NRegua;
					mFiacao[i].Lig = new DeclaracoesFiacao.structureLigacao[1];
					bool flag2 = false;
					string text = "";
					object[] array2;
					if (Operators.CompareString(tipo, "B", TextCompare: true) != 0)
					{
						if (Operators.CompareString(nRegua, "", TextCompare: true) != 0)
						{
							text = "SELECT Potencial, Ordem, Pagina, Secao, Cor FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Tag=@tag and NRegua=@nregua and Terminal=@terminal AND Tipo<>'B' AND BJumper=@bJumper ORDER BY Secao, Cor";
							object instance = db;
							object[] array = new object[3]
							{
								"@dwgCorrente",
								dwgCorrente,
								OleDbType.Integer
							};
							array2 = array;
							NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
							object instance2 = db;
							object[] array3 = new object[3]
							{
								"@revisao",
								revisao,
								OleDbType.Char
							};
							array2 = array3;
							NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
							object[] array5 = new object[3]
							{
								"@tag",
								tag,
								OleDbType.Char
							};
							array2 = array5;
							NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							tag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
							object instance5 = db;
							object[] array6 = new object[3]
							{
								"@nregua",
								nRegua,
								OleDbType.Char
							};
							array2 = array6;
							NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							nRegua = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
							object instance6 = db;
							object[] array7 = new object[3]
							{
								"@terminal",
								terminal,
								OleDbType.Char
							};
							array2 = array7;
							NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							terminal = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
							NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
							{
								"@bJumper",
								false,
								OleDbType.Boolean
							}, null, null, null, IgnoreReturn: true);
						}
						else
						{
							text = "SELECT Potencial, Ordem, Pagina, Secao, Cor FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Tag=@tag and Terminal=@terminal AND Tipo<>'B' AND BJumper=@bJumper ORDER BY Secao, Cor";
							object instance7 = db;
							object[] array8 = new object[3]
							{
								"@dwgCorrente",
								dwgCorrente,
								OleDbType.Integer
							};
							array2 = array8;
							NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
							object instance8 = db;
							object[] array9 = new object[3]
							{
								"@revisao",
								revisao,
								OleDbType.Char
							};
							array2 = array9;
							NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
							object instance9 = db;
							object[] array10 = new object[3]
							{
								"@painel",
								painel,
								OleDbType.Integer
							};
							array2 = array10;
							NewLateBinding.LateCall(instance9, null, "AddParameter", array10, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
							object instance10 = db;
							object[] array11 = new object[3]
							{
								"@tag",
								tag,
								OleDbType.Char
							};
							array2 = array11;
							NewLateBinding.LateCall(instance10, null, "AddParameter", array11, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							tag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
							object instance11 = db;
							object[] array12 = new object[3]
							{
								"@terminal",
								terminal,
								OleDbType.Char
							};
							array2 = array12;
							NewLateBinding.LateCall(instance11, null, "AddParameter", array12, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							terminal = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
							NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
							{
								"@bJumper",
								false,
								OleDbType.Boolean
							}, null, null, null, IgnoreReturn: true);
						}
						flag2 = false;
					}
					else
					{
						text = "SELECT Potencial, Ordem, Pagina, Secao, Cor, bLink FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Tag=@tag and Terminal=@terminal AND Tipo='B' AND BJumper=@bJumper ORDER BY Secao, Cor";
						object instance12 = db;
						object[] array13 = new object[3]
						{
							"@dwgCorrente",
							dwgCorrente,
							OleDbType.Integer
						};
						array2 = array13;
						NewLateBinding.LateCall(instance12, null, "AddParameter", array13, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
						object instance13 = db;
						object[] array14 = new object[3]
						{
							"@revisao",
							revisao,
							OleDbType.Char
						};
						array2 = array14;
						NewLateBinding.LateCall(instance13, null, "AddParameter", array14, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						object instance14 = db;
						object[] array15 = new object[3]
						{
							"@painel",
							painel,
							OleDbType.Integer
						};
						array2 = array15;
						NewLateBinding.LateCall(instance14, null, "AddParameter", array15, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
						object instance15 = db;
						object[] array16 = new object[3]
						{
							"@tag",
							tag,
							OleDbType.Char
						};
						array2 = array16;
						NewLateBinding.LateCall(instance15, null, "AddParameter", array16, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						tag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						object instance16 = db;
						object[] array17 = new object[3]
						{
							"@terminal",
							terminal,
							OleDbType.Char
						};
						array2 = array17;
						NewLateBinding.LateCall(instance16, null, "AddParameter", array17, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						terminal = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
						{
							"@bJumper",
							false,
							OleDbType.Boolean
						}, null, null, null, IgnoreReturn: true);
					}
					object obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DataTable dataTable = (DataTable)obj;
					if (dataTable.Rows.Count <= 0)
					{
						continue;
					}
					int num2 = dataTable.Rows.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						int num3 = Conversions.ToInteger(dataTable.Rows[j][0]);
						int num4 = Conversions.ToInteger(dataTable.Rows[j][1]);
						string pagina = Conversions.ToString(dataTable.Rows[j][2]);
						string secao = Conversions.ToString(dataTable.Rows[j][3]);
						string cor = Conversions.ToString(dataTable.Rows[j][4]);
						if (Operators.CompareString(tipo, "B", TextCompare: true) == 0)
						{
							flag2 = Conversions.ToBoolean(dataTable.Rows[j][5]);
						}
						mFiacao[i].Pagina = pagina;
						mFiacao[i].Circuito = "";
						if (num4 > 1)
						{
							string text2 = "SELECT Tag, Alternativo, NRegua, Terminal, bLink FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Potencial=@potencial AND Ordem=@ordem";
							object instance17 = db;
							object[] array18 = new object[3]
							{
								"@dwgCorrente",
								dwgCorrente,
								OleDbType.Integer
							};
							array2 = array18;
							NewLateBinding.LateCall(instance17, null, "AddParameter", array18, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
							object instance18 = db;
							object[] array19 = new object[3]
							{
								"@revisao",
								revisao,
								OleDbType.Char
							};
							array2 = array19;
							NewLateBinding.LateCall(instance18, null, "AddParameter", array19, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
							object instance19 = db;
							object[] array20 = new object[3]
							{
								"@painel",
								painel,
								OleDbType.Integer
							};
							array2 = array20;
							NewLateBinding.LateCall(instance19, null, "AddParameter", array20, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
							object instance20 = db;
							object[] array21 = new object[3]
							{
								"@potencial",
								num3,
								OleDbType.Integer
							};
							array2 = array21;
							NewLateBinding.LateCall(instance20, null, "AddParameter", array21, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							num3 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
							NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
							{
								"@ordem",
								num4 - 1,
								OleDbType.Integer
							}, null, null, null, IgnoreReturn: true);
							object instance21 = db;
							object[] array22 = new object[1] { text2 };
							array2 = array22;
							obj = NewLateBinding.LateGet(instance21, null, "ExecuteReader", array22, null, null, new bool[1] { true });
							text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
							DataTable dataTable2 = (DataTable)obj;
							if (dataTable2.Rows.Count == 1)
							{
								bool flag3 = Conversions.ToBoolean(dataTable2.Rows[0][4]);
								bool flag4 = false;
								if (flag2 & flag3)
								{
									string right = Conversions.ToString(dataTable2.Rows[0][0]);
									string text3 = Conversions.ToString(dataTable2.Rows[0][3]);
									double num5 = -1.0;
									double num6 = -3.0;
									if (Operators.CompareString(tag, right, TextCompare: true) == 0)
									{
										string text4 = "SELECT Ordem FROM Bornes4F WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Regua=@regua AND (Borne=@borneP OR Borne=@borneD) ORDER BY Ordem";
										object instance22 = db;
										object[] array23 = new object[3]
										{
											"@dwgCorrente",
											dwgCorrente,
											OleDbType.Integer
										};
										array2 = array23;
										NewLateBinding.LateCall(instance22, null, "AddParameter", array23, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
										dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
										object instance23 = db;
										object[] array24 = new object[3]
										{
											"@revisao",
											revisao,
											OleDbType.Char
										};
										array2 = array24;
										NewLateBinding.LateCall(instance23, null, "AddParameter", array24, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
										revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
										object instance24 = db;
										object[] array25 = new object[3]
										{
											"@painel",
											painel,
											OleDbType.Integer
										};
										array2 = array25;
										NewLateBinding.LateCall(instance24, null, "AddParameter", array25, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
										painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
										object instance25 = db;
										object[] array26 = new object[3]
										{
											"@regua",
											tag,
											OleDbType.Char
										};
										array2 = array26;
										NewLateBinding.LateCall(instance25, null, "AddParameter", array26, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
										tag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
										object instance26 = db;
										object[] array27 = new object[3]
										{
											"@borneP",
											terminal,
											OleDbType.Char
										};
										array2 = array27;
										NewLateBinding.LateCall(instance26, null, "AddParameter", array27, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
										terminal = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
										object instance27 = db;
										object[] array28 = new object[3]
										{
											"@borneD",
											text3,
											OleDbType.Char
										};
										array2 = array28;
										NewLateBinding.LateCall(instance27, null, "AddParameter", array28, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
										text3 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
										object instance28 = db;
										object[] array29 = new object[1] { text4 };
										array2 = array29;
										obj = NewLateBinding.LateGet(instance28, null, "ExecuteReader", array29, null, null, new bool[1] { true });
										text4 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
										DataTable dataTable3 = (DataTable)obj;
										if (dataTable3.Rows.Count == 2)
										{
											num6 = Conversions.ToDouble(dataTable3.Rows[0][0]);
											num5 = Conversions.ToDouble(dataTable3.Rows[1][0]);
											string text5 = "SELECT COUNT(*) FROM Bornes4F WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Regua=@regua AND Ordem>@ordemD AND Ordem<@ordemP";
											object instance29 = db;
											object[] array30 = new object[3]
											{
												"@dwgCorrente",
												dwgCorrente,
												OleDbType.Integer
											};
											array2 = array30;
											NewLateBinding.LateCall(instance29, null, "AddParameter", array30, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
											dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
											object instance30 = db;
											object[] array31 = new object[3]
											{
												"@revisao",
												revisao,
												OleDbType.Char
											};
											array2 = array31;
											NewLateBinding.LateCall(instance30, null, "AddParameter", array31, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
											revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
											object instance31 = db;
											object[] array32 = new object[3]
											{
												"@painel",
												painel,
												OleDbType.Integer
											};
											array2 = array32;
											NewLateBinding.LateCall(instance31, null, "AddParameter", array32, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
											painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
											object instance32 = db;
											object[] array33 = new object[3]
											{
												"@regua",
												tag,
												OleDbType.Char
											};
											array2 = array33;
											NewLateBinding.LateCall(instance32, null, "AddParameter", array33, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
											tag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
											object instance33 = db;
											object[] array34 = new object[3]
											{
												"@ordemD",
												num6,
												OleDbType.Double
											};
											array2 = array34;
											NewLateBinding.LateCall(instance33, null, "AddParameter", array34, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
											num6 = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
											object instance34 = db;
											object[] array35 = new object[3]
											{
												"@ordemP",
												num5,
												OleDbType.Double
											};
											array2 = array35;
											NewLateBinding.LateCall(instance34, null, "AddParameter", array35, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
											num5 = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
											object instance35 = db;
											object[] array36 = new object[1] { text5 };
											array2 = array36;
											obj = NewLateBinding.LateGet(instance35, null, "ExecuteReader", array36, null, null, new bool[1] { true });
											text5 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
											DataTable dataTable4 = (DataTable)obj;
											if (Operators.ConditionalCompareObjectEqual(dataTable4.Rows[0][0], 0, TextCompare: true))
											{
												flag4 = true;
											}
										}
									}
								}
								if (flag4)
								{
									mLink = (DeclaracoesFiacao.structureLink[])Utils.CopyArray(mLink, new DeclaracoesFiacao.structureLink[mLink.Length + 1]);
									flag = true;
									mLink[mLink.Length - 1].borne = terminal;
									mLink[mLink.Length - 1].bUp = true;
								}
								else
								{
									ref DeclaracoesFiacao.structureLigacao[] lig = ref mFiacao[i].Lig;
									lig = (DeclaracoesFiacao.structureLigacao[])Utils.CopyArray(lig, new DeclaracoesFiacao.structureLigacao[mFiacao[i].Lig.Length + 1]);
									mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Tag = Conversions.ToString(dataTable2.Rows[0][0]);
									mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Alternativo = Conversions.ToString(dataTable2.Rows[0][1]);
									string text6 = Conversions.ToString(dataTable2.Rows[0][2]);
									if (Operators.CompareString(text6, "", TextCompare: true) != 0)
									{
										mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Term = Conversions.ToString(Operators.AddObject(text6 + ":", dataTable2.Rows[0][3]));
									}
									else
									{
										mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Term = Conversions.ToString(dataTable2.Rows[0][3]);
									}
									mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Secao = secao;
									mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Cor = cor;
								}
							}
						}
						string text7 = "SELECT Tag, Alternativo, NRegua, Terminal, bLink FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Potencial=@potencial AND Ordem=@ordem";
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
							revisao,
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@painel",
							painel,
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@potencial",
							num3,
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						num3 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
						NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
						{
							"@ordem",
							num4 + 1,
							OleDbType.Integer
						}, null, null, null, IgnoreReturn: true);
						obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text7 }, null, null, new bool[1] { true });
						text7 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
						DataTable dataTable5 = (DataTable)obj;
						if (dataTable5.Rows.Count != 1)
						{
							continue;
						}
						bool flag5 = Conversions.ToBoolean(dataTable5.Rows[0][4]);
						bool flag6 = false;
						if (flag2 & flag5)
						{
							string right2 = Conversions.ToString(dataTable5.Rows[0][0]);
							string text8 = Conversions.ToString(dataTable5.Rows[0][3]);
							double num7 = -1.0;
							double num8 = -3.0;
							if (Operators.CompareString(tag, right2, TextCompare: true) == 0)
							{
								string text9 = "SELECT Ordem FROM Bornes4F WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Regua=@regua AND (Borne=@borneP OR Borne=@borneD) ORDER BY Ordem";
								object instance36 = db;
								object[] array37 = new object[3]
								{
									"@dwgCorrente",
									dwgCorrente,
									OleDbType.Integer
								};
								array2 = array37;
								NewLateBinding.LateCall(instance36, null, "AddParameter", array37, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
								dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
								object instance37 = db;
								object[] array38 = new object[3]
								{
									"@revisao",
									revisao,
									OleDbType.Char
								};
								array2 = array38;
								NewLateBinding.LateCall(instance37, null, "AddParameter", array38, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
								revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
								object instance38 = db;
								object[] array39 = new object[3]
								{
									"@painel",
									painel,
									OleDbType.Integer
								};
								array2 = array39;
								NewLateBinding.LateCall(instance38, null, "AddParameter", array39, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
								painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
								object instance39 = db;
								object[] array40 = new object[3]
								{
									"@regua",
									tag,
									OleDbType.Char
								};
								array2 = array40;
								NewLateBinding.LateCall(instance39, null, "AddParameter", array40, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
								tag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
								object instance40 = db;
								object[] array41 = new object[3]
								{
									"@borneP",
									terminal,
									OleDbType.Char
								};
								array2 = array41;
								NewLateBinding.LateCall(instance40, null, "AddParameter", array41, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
								terminal = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
								object instance41 = db;
								object[] array42 = new object[3]
								{
									"@borneD",
									text8,
									OleDbType.Char
								};
								array2 = array42;
								NewLateBinding.LateCall(instance41, null, "AddParameter", array42, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
								text8 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
								object instance42 = db;
								object[] array43 = new object[1] { text9 };
								array2 = array43;
								obj = NewLateBinding.LateGet(instance42, null, "ExecuteReader", array43, null, null, new bool[1] { true });
								text9 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
								DataTable dataTable6 = (DataTable)obj;
								if (dataTable6.Rows.Count == 2)
								{
									num7 = Conversions.ToDouble(dataTable6.Rows[0][0]);
									num8 = Conversions.ToDouble(dataTable6.Rows[1][0]);
									string text10 = "SELECT COUNT(*) FROM Bornes4F WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Regua=@regua AND Ordem>@ordemP AND Ordem<@ordemD";
									object instance43 = db;
									object[] array44 = new object[3]
									{
										"@dwgCorrente",
										dwgCorrente,
										OleDbType.Integer
									};
									array2 = array44;
									NewLateBinding.LateCall(instance43, null, "AddParameter", array44, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
									dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
									object instance44 = db;
									object[] array45 = new object[3]
									{
										"@revisao",
										revisao,
										OleDbType.Char
									};
									array2 = array45;
									NewLateBinding.LateCall(instance44, null, "AddParameter", array45, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
									revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
									object instance45 = db;
									object[] array46 = new object[3]
									{
										"@painel",
										painel,
										OleDbType.Integer
									};
									array2 = array46;
									NewLateBinding.LateCall(instance45, null, "AddParameter", array46, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
									painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
									object instance46 = db;
									object[] array47 = new object[3]
									{
										"@regua",
										tag,
										OleDbType.Char
									};
									array2 = array47;
									NewLateBinding.LateCall(instance46, null, "AddParameter", array47, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
									tag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
									object instance47 = db;
									object[] array48 = new object[3]
									{
										"@ordemP",
										num7,
										OleDbType.Double
									};
									array2 = array48;
									NewLateBinding.LateCall(instance47, null, "AddParameter", array48, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
									num7 = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
									object instance48 = db;
									object[] array49 = new object[3]
									{
										"@ordemD",
										num8,
										OleDbType.Double
									};
									array2 = array49;
									NewLateBinding.LateCall(instance48, null, "AddParameter", array49, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
									num8 = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
									object instance49 = db;
									object[] array50 = new object[1] { text10 };
									array2 = array50;
									obj = NewLateBinding.LateGet(instance49, null, "ExecuteReader", array50, null, null, new bool[1] { true });
									text10 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
									DataTable dataTable7 = (DataTable)obj;
									if (Operators.ConditionalCompareObjectEqual(dataTable7.Rows[0][0], 0, TextCompare: true))
									{
										flag6 = true;
									}
								}
							}
						}
						if (flag6)
						{
							if (!flag)
							{
								mLink = (DeclaracoesFiacao.structureLink[])Utils.CopyArray(mLink, new DeclaracoesFiacao.structureLink[mLink.Length + 1]);
								mLink[mLink.Length - 1].borne = terminal;
							}
							mLink[mLink.Length - 1].bDown = true;
						}
						else
						{
							ref DeclaracoesFiacao.structureLigacao[] lig2 = ref mFiacao[i].Lig;
							lig2 = (DeclaracoesFiacao.structureLigacao[])Utils.CopyArray(lig2, new DeclaracoesFiacao.structureLigacao[mFiacao[i].Lig.Length + 1]);
							mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Tag = Conversions.ToString(dataTable5.Rows[0][0]);
							mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Alternativo = Conversions.ToString(dataTable5.Rows[0][1]);
							string text11 = Conversions.ToString(dataTable5.Rows[0][2]);
							if (Operators.CompareString(text11, "", TextCompare: true) != 0)
							{
								mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Term = Conversions.ToString(Operators.AddObject(text11 + ":", dataTable5.Rows[0][3]));
							}
							else
							{
								mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Term = Conversions.ToString(dataTable5.Rows[0][3]);
							}
							mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Secao = secao;
							mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Cor = cor;
						}
						if (num3 > 0)
						{
							string text12 = "SELECT Circuito FROM Circuitos4F WHERE Revisao=@revisao AND DWG=@dwgCorrente AND Painel=@painel AND Potencial=@potencial";
							object instance50 = db;
							object[] array51 = new object[3]
							{
								"@revisao",
								revisao,
								OleDbType.Char
							};
							array2 = array51;
							NewLateBinding.LateCall(instance50, null, "AddParameter", array51, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
							object instance51 = db;
							object[] array52 = new object[3]
							{
								"@dwgCorrente",
								dwgCorrente,
								OleDbType.Integer
							};
							array2 = array52;
							NewLateBinding.LateCall(instance51, null, "AddParameter", array52, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
							object instance52 = db;
							object[] array53 = new object[3]
							{
								"@painel",
								painel,
								OleDbType.Integer
							};
							array2 = array53;
							NewLateBinding.LateCall(instance52, null, "AddParameter", array53, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
							object instance53 = db;
							object[] array54 = new object[3]
							{
								"@potencial",
								num3,
								OleDbType.Integer
							};
							array2 = array54;
							NewLateBinding.LateCall(instance53, null, "AddParameter", array54, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							num3 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
							mFiacao[i].Circuito = "";
							object instance54 = db;
							object[] array55 = new object[1] { text12 };
							array2 = array55;
							obj = NewLateBinding.LateGet(instance54, null, "ExecuteReader", array55, null, null, new bool[1] { true });
							text12 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
							DataTable dataTable8 = (DataTable)obj;
							if (dataTable8.Rows.Count == 1)
							{
								mFiacao[i].Circuito = Conversions.ToString(dataTable8.Rows[0][0]);
							}
						}
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

	public void CarregaPotenciaisPainel2(int dwgCorrente, string revisao, int painel, ref DeclaracoesFiacao.structurePotencial[] mPotencial)
	{
		checked
		{
			try
			{
				Dictionary<int, double> dictionary = new Dictionary<int, double>();
				string text = "SELECT DISTINCT Potencial FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND BJumper=@bJumper ORDER BY Potencial";
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
					revisao,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
				NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
				{
					"@bJumper",
					false,
					OleDbType.Boolean
				}, null, null, null, IgnoreReturn: true);
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
						string text2 = "SELECT Pagina FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND BJumper=@bJumper AND Potencial=@potencial ORDER BY Ordem";
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
							revisao,
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@painel",
							painel,
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
						NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
						{
							"@bJumper",
							false,
							OleDbType.Boolean
						}, null, null, null, IgnoreReturn: true);
						DataRow dataRow;
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@potencial",
							(dataRow = dataTable.Rows[i])[0],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[0] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text2 }, null, null, new bool[1] { true });
						text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
						DataTable dataTable2 = (DataTable)obj;
						double num2 = 100000.0;
						if (dataTable2.Rows.Count > 0)
						{
							int num3 = dataTable2.Rows.Count - 1;
							for (int j = 0; j <= num3; j++)
							{
								double num4 = Pagina.calculaPaginaDecimal(Conversions.ToString(dataTable2.Rows[j][0]));
								if (num4 < num2)
								{
									num2 = num4;
								}
							}
						}
						dictionary.Add(Conversions.ToInteger(dataTable.Rows[i][0]), num2);
					}
				}
				dictionary = dictionary.OrderBy([SpecialName] (KeyValuePair<int, double> x) => x.Value).ToDictionary([SpecialName] (KeyValuePair<int, double> x) => x.Key, [SpecialName] (KeyValuePair<int, double> x) => x.Value);
				foreach (int key in dictionary.Keys)
				{
					string text3 = "SELECT Tag, Alternativo, NRegua, Terminal, bLink, Secao, Cor, Pagina, IndexModelo, Aplicacao, Orientacao FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND BJumper=@bJumper AND Potencial=@potencial ORDER BY Ordem";
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
						revisao,
						OleDbType.Char
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@painel",
						painel,
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
					{
						"@bJumper",
						false,
						OleDbType.Boolean
					}, null, null, null, IgnoreReturn: true);
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@potencial",
						key,
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					int current = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text3 }, null, null, new bool[1] { true });
					text3 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DataTable dataTable3 = (DataTable)obj;
					if (dataTable3.Rows.Count > 0)
					{
						int num5 = dataTable3.Rows.Count - 1;
						for (int num6 = 0; num6 <= num5; num6++)
						{
							int num7 = Information.UBound(mPotencial) + 1;
							mPotencial = (DeclaracoesFiacao.structurePotencial[])Utils.CopyArray(mPotencial, new DeclaracoesFiacao.structurePotencial[num7 + 1]);
							mPotencial[num7].Potencial = current;
							mPotencial[num7].Tag = Conversions.ToString(dataTable3.Rows[num6][0]);
							mPotencial[num7].Alternativo = Conversions.ToString(dataTable3.Rows[num6][1]);
							mPotencial[num7].NRegua = Conversions.ToString(dataTable3.Rows[num6][2]);
							mPotencial[num7].Terminal = Conversions.ToString(dataTable3.Rows[num6][3]);
							mPotencial[num7].bLink = Conversions.ToBoolean(dataTable3.Rows[num6][4]);
							mPotencial[num7].Secao = Conversions.ToString(dataTable3.Rows[num6][5]);
							mPotencial[num7].Cor = Conversions.ToString(dataTable3.Rows[num6][6]);
							mPotencial[num7].Pagina = Conversions.ToString(dataTable3.Rows[num6][7]);
							mPotencial[num7].indexModelo = Conversions.ToInteger(dataTable3.Rows[num6][8]);
							mPotencial[num7].Aplicacao = Conversions.ToInteger(clsTextos.TiraDBNullNumero(RuntimeHelpers.GetObjectValue(dataTable3.Rows[num6][9])));
							mPotencial[num7].Orientacao = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable3.Rows[num6][10]));
						}
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void CarregaPotenciaisPainelEstat(int dwgCorrente, string revisao, int painel, ref DeclaracoesFiacao.structurePotencial[] mPotencial)
	{
		checked
		{
			try
			{
				string text = "SELECT Potencial, Tag, Terminal, bLink, Secao, Cor, IndexModelo, PosicaoNum  FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND BJumper=@bJumper ORDER BY Potencial, Ordem";
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
					revisao,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
				NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
				{
					"@bJumper",
					false,
					OleDbType.Boolean
				}, null, null, null, IgnoreReturn: true);
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
						int num2 = Information.UBound(mPotencial) + 1;
						mPotencial = (DeclaracoesFiacao.structurePotencial[])Utils.CopyArray(mPotencial, new DeclaracoesFiacao.structurePotencial[num2 + 1]);
						mPotencial[num2].Potencial = Conversions.ToInteger(dataTable.Rows[i][0]);
						mPotencial[num2].Tag = Conversions.ToString(dataTable.Rows[i][1]);
						mPotencial[num2].Terminal = Conversions.ToString(dataTable.Rows[i][2]);
						mPotencial[num2].bLink = Conversions.ToBoolean(dataTable.Rows[i][3]);
						mPotencial[num2].Secao = Conversions.ToString(dataTable.Rows[i][4]);
						mPotencial[num2].Cor = Conversions.ToString(dataTable.Rows[i][5]);
						mPotencial[num2].indexModelo = Conversions.ToInteger(dataTable.Rows[i][6]);
						mPotencial[num2].PosicaoNum = Conversions.ToInteger(dataTable.Rows[i][7]);
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void CarregaPotenciaisReguas(int dwgCorrente, string revisao, int painel, List<string> lReguas, ref StructureBorneAplicacao[] mReguas)
	{
		checked
		{
			try
			{
				cDadosLM.structureLMRelelatorio[] mLP = new cDadosLM.structureLMRelelatorio[1];
				cDadosAccessImportarProj cDadosAccessImportarProj2 = new cDadosAccessImportarProj();
				try
				{
					cDadosAccessImportarProj2.CarregaTodaLMDoImpProj(ref mLP);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				finally
				{
					cDadosAccessImportarProj2.fechaConexao();
				}
				string text = "SELECT Regua, Borne, Ordem, LM FROM Bornes4F WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Tipo<2 ORDER BY Indice";
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
					revisao,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				foreach (string lRegua in lReguas)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (!Operators.ConditionalCompareObjectEqual(dataTable.Rows[i][0], lRegua, TextCompare: true))
						{
							continue;
						}
						int num2 = Information.UBound(mReguas) + 1;
						mReguas = (StructureBorneAplicacao[])Utils.CopyArray(mReguas, new StructureBorneAplicacao[num2 + 1]);
						mReguas[num2].Regua = Conversions.ToString(dataTable.Rows[i][0]);
						mReguas[num2].Terminal = Conversions.ToString(dataTable.Rows[i][1]);
						mReguas[num2].ordem = Conversions.ToInteger(dataTable.Rows[i][2]);
						mReguas[num2].LM = Conversions.ToInteger(dataTable.Rows[i][3]);
						mReguas[num2].modelo = "";
						mReguas[num2].Fabricante = "";
						if (mReguas[num2].LM <= 0)
						{
							continue;
						}
						int num3 = Information.UBound(mLP);
						for (int j = 1; j <= num3; j++)
						{
							if ((double)mReguas[num2].LM == Conversions.ToDouble(mLP[j].Index))
							{
								mReguas[num2].modelo = mLP[j].sModelo;
								mReguas[num2].Fabricante = mLP[j].sFabricante;
								break;
							}
						}
					}
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void CarregaPotenciaisPainel3(int dwgCorrente, string revisao, int painel, ref DeclaracoesFiacao.structurePotencial[] mPotencial)
	{
		checked
		{
			try
			{
				string text = "SELECT Potencial, Tag, Alternativo, NRegua, Terminal, TerminalNum, bLink, PosicaoNum, IndexModelo, Secao, Cor, Aplicacao, Orientacao FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND BJumper=@bJumper ORDER BY Potencial, Ordem";
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
					revisao,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
				NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
				{
					"@bJumper",
					false,
					OleDbType.Boolean
				}, null, null, null, IgnoreReturn: true);
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
						int num2 = Information.UBound(mPotencial) + 1;
						mPotencial = (DeclaracoesFiacao.structurePotencial[])Utils.CopyArray(mPotencial, new DeclaracoesFiacao.structurePotencial[num2 + 1]);
						mPotencial[num2].Potencial = Conversions.ToInteger(dataTable.Rows[i][0]);
						mPotencial[num2].Tag = Conversions.ToString(dataTable.Rows[i][1]);
						mPotencial[num2].Alternativo = Conversions.ToString(dataTable.Rows[i][2]);
						mPotencial[num2].NRegua = Conversions.ToString(dataTable.Rows[i][3]);
						mPotencial[num2].Terminal = Conversions.ToString(dataTable.Rows[i][4]);
						mPotencial[num2].TerminalNum = Conversions.ToDouble(dataTable.Rows[i][5]);
						mPotencial[num2].bLink = Conversions.ToBoolean(dataTable.Rows[i][6]);
						mPotencial[num2].PosicaoNum = Conversions.ToInteger(dataTable.Rows[i][7]);
						mPotencial[num2].indexModelo = Conversions.ToInteger(dataTable.Rows[i][8]);
						mPotencial[num2].Secao = Conversions.ToString(dataTable.Rows[i][9]);
						mPotencial[num2].Cor = Conversions.ToString(dataTable.Rows[i][10]);
						mPotencial[num2].Aplicacao = Conversions.ToInteger(dataTable.Rows[i][11]);
						mPotencial[num2].Orientacao = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][12]));
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void CarregaPotDiferencialPainel(int dwgCorrente, string revisao, int painel, ref DeclaracoesFiacao.structurePotencial[] mPotencial)
	{
		checked
		{
			try
			{
				string text = "SELECT Potencial, Tag, Alternativo, NRegua, Terminal, bLink, Secao, Cor, Pagina, IndexModelo, PosicaoNum, TipoBorne FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel ORDER BY Potencial, Ordem";
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
					revisao,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						int num2 = Information.UBound(mPotencial) + 1;
						mPotencial = (DeclaracoesFiacao.structurePotencial[])Utils.CopyArray(mPotencial, new DeclaracoesFiacao.structurePotencial[num2 + 1]);
						mPotencial[num2].Potencial = Conversions.ToInteger(dataTable.Rows[i][0]);
						mPotencial[num2].Tag = Conversions.ToString(dataTable.Rows[i][1]);
						mPotencial[num2].Alternativo = Conversions.ToString(dataTable.Rows[i][2]);
						mPotencial[num2].NRegua = Conversions.ToString(dataTable.Rows[i][3]);
						mPotencial[num2].Terminal = Conversions.ToString(dataTable.Rows[i][4]);
						mPotencial[num2].bLink = Conversions.ToBoolean(dataTable.Rows[i][5]);
						mPotencial[num2].Secao = Conversions.ToString(dataTable.Rows[i][6]);
						mPotencial[num2].Cor = Conversions.ToString(dataTable.Rows[i][7]);
						mPotencial[num2].Pagina = Conversions.ToString(dataTable.Rows[i][8]);
						mPotencial[num2].indexModelo = Conversions.ToInteger(dataTable.Rows[i][9]);
						mPotencial[num2].PosicaoNum = Conversions.ToInteger(dataTable.Rows[i][10]);
						mPotencial[num2].TipoBorne = Conversions.ToInteger(dataTable.Rows[i][11]);
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public bool BornesVizinhos(int dwgCorrente, string revisao, int painel, int indexRegua, string borne1, string borne2)
	{
		bool result = false;
		try
		{
			string text = "SELECT Ordem FROM Bornes4F WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND IndexRegua=@indexRegua AND (Borne=@borne1 OR Borne=@borne2) ORDER BY Ordem";
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
				revisao,
				OleDbType.Char
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
			object[] array5 = new object[3]
			{
				"@indexRegua",
				indexRegua,
				OleDbType.Integer
			};
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			indexRegua = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance5 = db;
			object[] array6 = new object[3]
			{
				"@borne1",
				borne1,
				OleDbType.Char
			};
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			borne1 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance6 = db;
			object[] array7 = new object[3]
			{
				"@borne2",
				borne2,
				OleDbType.Char
			};
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			borne2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance7 = db;
			object[] array8 = new object[1] { text };
			array2 = array8;
			object obj = NewLateBinding.LateGet(instance7, null, "ExecuteReader", array8, null, null, new bool[1] { true });
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			DataTable dataTable = (DataTable)obj;
			if (dataTable.Rows.Count == 2)
			{
				double num = Conversions.ToDouble(dataTable.Rows[0][0]);
				double num2 = Conversions.ToDouble(dataTable.Rows[1][0]);
				string text2 = "SELECT COUNT(*) FROM Bornes4F WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND IndexRegua=@indexRegua AND Ordem>@ordem1 AND Ordem<@ordem2";
				object instance8 = db;
				object[] array9 = new object[3]
				{
					"@dwgCorrente",
					dwgCorrente,
					OleDbType.Integer
				};
				array2 = array9;
				NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance9 = db;
				object[] array10 = new object[3]
				{
					"@revisao",
					revisao,
					OleDbType.Char
				};
				array2 = array10;
				NewLateBinding.LateCall(instance9, null, "AddParameter", array10, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance10 = db;
				object[] array11 = new object[3]
				{
					"@painel",
					painel,
					OleDbType.Integer
				};
				array2 = array11;
				NewLateBinding.LateCall(instance10, null, "AddParameter", array11, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance11 = db;
				object[] array12 = new object[3]
				{
					"@indexRegua",
					indexRegua,
					OleDbType.Integer
				};
				array2 = array12;
				NewLateBinding.LateCall(instance11, null, "AddParameter", array12, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				indexRegua = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance12 = db;
				object[] array13 = new object[3]
				{
					"@ordem1",
					num,
					OleDbType.Double
				};
				array2 = array13;
				NewLateBinding.LateCall(instance12, null, "AddParameter", array13, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				num = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
				object instance13 = db;
				object[] array14 = new object[3]
				{
					"@ordem2",
					num2,
					OleDbType.Double
				};
				array2 = array14;
				NewLateBinding.LateCall(instance13, null, "AddParameter", array14, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				num2 = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
				object instance14 = db;
				object[] array15 = new object[1] { text2 };
				array2 = array15;
				obj = NewLateBinding.LateGet(instance14, null, "ExecuteReader", array15, null, null, new bool[1] { true });
				text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable2 = (DataTable)obj;
				if (Operators.ConditionalCompareObjectEqual(dataTable2.Rows[0][0], 0, TextCompare: true))
				{
					result = true;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void AtualizaOrdemTerminal(int indice, int ordem)
	{
		try
		{
			string text = "";
			text = "UPDATE Fiacao SET Ordem=@ordem WHERE Indice=@indice";
			object instance = db;
			object[] array = new object[3]
			{
				"@ordem",
				ordem,
				OleDbType.Integer
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			ordem = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@indice",
				indice,
				OleDbType.Integer
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			indice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance3 = db;
			object[] array4 = new object[1] { text };
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "ExecuteNonQuery", array4, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public void AtualizaPotenciais(int dwgCorrente, string revisao, ref DataTable varTableFiacaoH)
	{
		checked
		{
			try
			{
				string text = "SELECT Indice, Potencial, Handle, Terminal, Ordem, BLink, Tipo FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao";
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
					revisao,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance3 = db;
				object[] array4 = new object[1] { text };
				array2 = array4;
				object obj = NewLateBinding.LateGet(instance3, null, "ExecuteReader", array4, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					int num2 = Conversions.ToInteger(dataTable.Rows[i][0]);
					int num3 = Conversions.ToInteger(dataTable.Rows[i][1]);
					string text2 = Conversions.ToString(dataTable.Rows[i][2]);
					string text3 = Conversions.ToString(dataTable.Rows[i][3]);
					Conversions.ToString(dataTable.Rows[i][4]);
					string left = Conversions.ToString(dataTable.Rows[i][6]);
					string filterExpression = ((Operators.CompareString(left, "B", TextCompare: true) == 0) ? ("Potencial=" + num3 + " AND Handle='" + text2 + "'") : ("Potencial=" + num3 + " AND Handle='" + text2 + "' AND Terminal='" + text3 + "'"));
					DataRow[] array5 = varTableFiacaoH.Select(filterExpression);
					if (array5.Length == 1)
					{
						int num4 = Conversions.ToInteger(array5[0][3]);
						bool flag = Conversions.ToBoolean(array5[0][4]);
						string text4 = "";
						text4 = "UPDATE Fiacao SET Ordem=@ordem, Blink=@bLink WHERE Indice=@indice";
						object instance4 = db;
						object[] array6 = new object[3]
						{
							"@ordem",
							num4,
							OleDbType.Integer
						};
						array2 = array6;
						NewLateBinding.LateCall(instance4, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						num4 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
						object instance5 = db;
						object[] array7 = new object[3]
						{
							"@bLink",
							flag,
							OleDbType.Boolean
						};
						array2 = array7;
						NewLateBinding.LateCall(instance5, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						flag = (bool)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(bool));
						object instance6 = db;
						object[] array8 = new object[3]
						{
							"@indice",
							num2,
							OleDbType.Integer
						};
						array2 = array8;
						NewLateBinding.LateCall(instance6, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						num2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
						object instance7 = db;
						object[] array9 = new object[1] { text4 };
						array2 = array9;
						NewLateBinding.LateCall(instance7, null, "ExecuteNonQuery", array9, null, null, new bool[1] { true }, IgnoreReturn: true);
						text4 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
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

	public void ReordenaOrdemPotenciais(int dwgCorrente, string revisao)
	{
		checked
		{
			try
			{
				string text = "SELECT DISTINCT Potencial FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao";
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
					revisao,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance3 = db;
				object[] array4 = new object[1] { text };
				array2 = array4;
				object obj = NewLateBinding.LateGet(instance3, null, "ExecuteReader", array4, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					int num2 = Conversions.ToInteger(dataTable.Rows[i][0]);
					string text2 = "SELECT Indice, Ordem FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Potencial=@potencial ORDER BY Ordem";
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
						revisao,
						OleDbType.Char
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@potencial",
						num2,
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					num2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text2 }, null, null, new bool[1] { true });
					text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DataTable dataTable2 = (DataTable)obj;
					int num3 = 0;
					if (dataTable2.Rows.Count <= 0)
					{
						continue;
					}
					int num4 = dataTable2.Rows.Count - 1;
					for (int j = 0; j <= num4; j++)
					{
						int num5 = Conversions.ToInteger(dataTable2.Rows[j][0]);
						int num6 = Conversions.ToInteger(dataTable2.Rows[j][1]);
						num3++;
						if (num6 != num3)
						{
							string text3 = "";
							text3 = "UPDATE Fiacao SET Ordem=@ordem WHERE Indice=@indice";
							object instance4 = db;
							object[] array5 = new object[3]
							{
								"@ordem",
								num3,
								OleDbType.Integer
							};
							array2 = array5;
							NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							num3 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
							object instance5 = db;
							object[] array6 = new object[3]
							{
								"@indice",
								num5,
								OleDbType.Integer
							};
							array2 = array6;
							NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							num5 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
							object instance6 = db;
							object[] array7 = new object[1] { text3 };
							array2 = array7;
							NewLateBinding.LateCall(instance6, null, "ExecuteNonQuery", array7, null, null, new bool[1] { true }, IgnoreReturn: true);
							text3 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
						}
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

	public void AdicionaItemPotencial(DeclaracoesFiacao.structurePontosPotencial pot)
	{
		try
		{
			string text = "";
			text = "Insert into Fiacao(Revisao, DWG, Painel, Potencial, Ordem, Pagina, Tag, Alternativo, NRegua, Terminal, TerminalNum, Tipo, Secao, Cor, PosicaoNum, TipoBorne, BJumper, BLink, Handle, IndexModelo, Aplicacao, Criador, Data) VALUES(@revisao, @dwg, @painel, @potencial, @ordem, @pagina, @tag, @alternativo, @nregua, @terminal, @terminalNum, @tipo, @secao, @cor, @posicaoNum, @tipoBorne, @bJumper, @bLink, @handle, @indexModelo, @aplicacao, @criador, @data)";
			object instance = db;
			object[] array = new object[3] { "@revisao", null, null };
			ref string revisao = ref pot.revisao;
			ref string reference = ref revisao;
			array[1] = revisao;
			array[2] = OleDbType.Char;
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[3] { "@dwg", null, null };
			ref int dwg = ref pot.dwg;
			ref int reference2 = ref dwg;
			array3[1] = dwg;
			array3[2] = OleDbType.Integer;
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance3 = db;
			object[] array4 = new object[3] { "@painel", null, null };
			ref short painel = ref pot.painel;
			ref short reference3 = ref painel;
			array4[1] = painel;
			array4[2] = OleDbType.Integer;
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference3 = (short)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(short));
			object instance4 = db;
			object[] array5 = new object[3] { "@potencial", null, null };
			ref int potencial = ref pot.potencial;
			reference2 = ref potencial;
			array5[1] = potencial;
			array5[2] = OleDbType.Integer;
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance5 = db;
			object[] array6 = new object[3] { "@ordem", null, null };
			ref int ordem = ref pot.Ordem;
			reference2 = ref ordem;
			array6[1] = ordem;
			array6[2] = OleDbType.Integer;
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance6 = db;
			object[] array7 = new object[3] { "@pagina", null, null };
			ref string layer = ref pot.layer;
			reference = ref layer;
			array7[1] = layer;
			array7[2] = OleDbType.Char;
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance7 = db;
			object[] array8 = new object[3] { "@tag", null, null };
			ref string tag = ref pot.tag;
			reference = ref tag;
			array8[1] = tag;
			array8[2] = OleDbType.Char;
			array2 = array8;
			NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance8 = db;
			object[] array9 = new object[3] { "@alternativo", null, null };
			ref string alternativo = ref pot.alternativo;
			reference = ref alternativo;
			array9[1] = alternativo;
			array9[2] = OleDbType.Char;
			array2 = array9;
			NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance9 = db;
			object[] array10 = new object[3] { "@nregua", null, null };
			ref string nRegua = ref pot.nRegua;
			reference = ref nRegua;
			array10[1] = nRegua;
			array10[2] = OleDbType.Char;
			array2 = array10;
			NewLateBinding.LateCall(instance9, null, "AddParameter", array10, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance10 = db;
			object[] array11 = new object[3] { "@terminal", null, null };
			ref string terminal = ref pot.terminal;
			reference = ref terminal;
			array11[1] = terminal;
			array11[2] = OleDbType.Char;
			array2 = array11;
			NewLateBinding.LateCall(instance10, null, "AddParameter", array11, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance11 = db;
			object[] array12 = new object[3] { "@terminalNum", null, null };
			ref double terminalNum = ref pot.terminalNum;
			array12[1] = terminalNum;
			array12[2] = OleDbType.Double;
			array2 = array12;
			NewLateBinding.LateCall(instance11, null, "AddParameter", array12, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			terminalNum = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
			object instance12 = db;
			object[] array13 = new object[3] { "@tipo", null, null };
			ref string tipo = ref pot.tipo;
			reference = ref tipo;
			array13[1] = tipo;
			array13[2] = OleDbType.Char;
			array2 = array13;
			NewLateBinding.LateCall(instance12, null, "AddParameter", array13, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance13 = db;
			object[] array14 = new object[3] { "@secao", null, null };
			ref string secao = ref pot.secao;
			reference = ref secao;
			array14[1] = secao;
			array14[2] = OleDbType.Char;
			array2 = array14;
			NewLateBinding.LateCall(instance13, null, "AddParameter", array14, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance14 = db;
			object[] array15 = new object[3] { "@cor", null, null };
			ref string cor = ref pot.cor;
			reference = ref cor;
			array15[1] = cor;
			array15[2] = OleDbType.Char;
			array2 = array15;
			NewLateBinding.LateCall(instance14, null, "AddParameter", array15, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance15 = db;
			object[] array16 = new object[3] { "@posicaoNum", null, null };
			ref int posicaoNum = ref pot.PosicaoNum;
			reference2 = ref posicaoNum;
			array16[1] = posicaoNum;
			array16[2] = OleDbType.Integer;
			array2 = array16;
			NewLateBinding.LateCall(instance15, null, "AddParameter", array16, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance16 = db;
			object[] array17 = new object[3] { "@tipoBorne", null, null };
			ref short tipoBorne = ref pot.tipoBorne;
			reference3 = ref tipoBorne;
			array17[1] = tipoBorne;
			array17[2] = OleDbType.Integer;
			array2 = array17;
			NewLateBinding.LateCall(instance16, null, "AddParameter", array17, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference3 = (short)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(short));
			object instance17 = db;
			object[] array18 = new object[3] { "@bJumper", null, null };
			ref bool bJumper = ref pot.bJumper;
			ref bool reference4 = ref bJumper;
			array18[1] = bJumper;
			array18[2] = OleDbType.Boolean;
			array2 = array18;
			NewLateBinding.LateCall(instance17, null, "AddParameter", array18, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference4 = (bool)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(bool));
			object instance18 = db;
			object[] array19 = new object[3] { "@bLink", null, null };
			ref bool bLink = ref pot.bLink;
			reference4 = ref bLink;
			array19[1] = bLink;
			array19[2] = OleDbType.Boolean;
			array2 = array19;
			NewLateBinding.LateCall(instance18, null, "AddParameter", array19, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference4 = (bool)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(bool));
			object instance19 = db;
			object[] array20 = new object[3] { "@handle", null, null };
			ref string handle = ref pot.handle;
			reference = ref handle;
			array20[1] = handle;
			array20[2] = OleDbType.Char;
			array2 = array20;
			NewLateBinding.LateCall(instance19, null, "AddParameter", array20, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance20 = db;
			object[] array21 = new object[3] { "@indexModelo", null, null };
			ref short indexModelo = ref pot.indexModelo;
			reference3 = ref indexModelo;
			array21[1] = indexModelo;
			array21[2] = OleDbType.Integer;
			array2 = array21;
			NewLateBinding.LateCall(instance20, null, "AddParameter", array21, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference3 = (short)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(short));
			object instance21 = db;
			object[] array22 = new object[3] { "@aplicacao", null, null };
			ref int aplicacao = ref pot.Aplicacao;
			reference2 = ref aplicacao;
			array22[1] = aplicacao;
			array22[2] = OleDbType.Char;
			array2 = array22;
			NewLateBinding.LateCall(instance21, null, "AddParameter", array22, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance22 = db;
			object[] array23 = new object[3] { "@criador", null, null };
			ref string criador = ref pot.criador;
			reference = ref criador;
			array23[1] = criador;
			array23[2] = OleDbType.Char;
			array2 = array23;
			NewLateBinding.LateCall(instance22, null, "AddParameter", array23, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance23 = db;
			object[] array24 = new object[3] { "@data", null, null };
			ref DateTime data = ref pot.data;
			array24[1] = data;
			array24[2] = OleDbType.Date;
			array2 = array24;
			NewLateBinding.LateCall(instance23, null, "AddParameter", array24, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			data = (DateTime)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(DateTime));
			object instance24 = db;
			object[] array25 = new object[1] { text };
			array2 = array25;
			NewLateBinding.LateCall(instance24, null, "ExecuteNonQuery", array25, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}

	public void RemoveRevisaoTabela(string nomeTabela, int dwgCorrente, string revisao)
	{
		try
		{
			string text = "";
			text = "DELETE FROM " + nomeTabela + " WHERE DWG=@dwgCorrente AND Revisao=@revisao";
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
				revisao,
				OleDbType.Char
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance3 = db;
			object[] array4 = new object[1] { text };
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "ExecuteNonQuery", array4, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}

	public void AdicionaItemCircuitos(string revisao, long dwg, int painel, string nomeCircuito, int potencial)
	{
		try
		{
			string text = "";
			text = "Insert into Circuitos4F(Revisao, DWG, Painel, Circuito, Potencial) VALUES(@revisao, @dwg, @painel, @circuito, @potencial)";
			object instance = db;
			object[] array = new object[3]
			{
				"@revisao",
				revisao,
				OleDbType.Char
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@dwg",
				dwg,
				OleDbType.Integer
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			dwg = (long)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(long));
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
			object[] array5 = new object[3]
			{
				"@circuito",
				nomeCircuito,
				OleDbType.Char
			};
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			nomeCircuito = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance5 = db;
			object[] array6 = new object[3]
			{
				"@potencial",
				potencial,
				OleDbType.Integer
			};
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			potencial = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance6 = db;
			object[] array7 = new object[1] { text };
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "ExecuteNonQuery", array7, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}

	public void AdicionaItemContatos(string revisao, long dwg, long indexModelo, string nomeModelo, string terminal, double terminalNum, string orientacao)
	{
		try
		{
			string text = "";
			text = "Insert into Contatos4F(Revisao, DWG, IndexModelo, NomeModelo, Terminal, TerminalNum, Orientacao) VALUES(@revisao, @dwg, @indexModelo, @nomeModelo, @terminal, @terminalNum, @orientacao)";
			object instance = db;
			object[] array = new object[3]
			{
				"@revisao",
				revisao,
				OleDbType.Char
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@dwg",
				dwg,
				OleDbType.Integer
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			dwg = (long)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(long));
			object instance3 = db;
			object[] array4 = new object[3]
			{
				"@indexModelo",
				indexModelo,
				OleDbType.Integer
			};
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			indexModelo = (long)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(long));
			object instance4 = db;
			object[] array5 = new object[3]
			{
				"@nomeModelo",
				nomeModelo,
				OleDbType.Char
			};
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			nomeModelo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance5 = db;
			object[] array6 = new object[3]
			{
				"@terminal",
				terminal,
				OleDbType.Char
			};
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			terminal = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance6 = db;
			object[] array7 = new object[3]
			{
				"@terminalNum",
				terminalNum,
				OleDbType.Double
			};
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			terminalNum = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
			object instance7 = db;
			object[] array8 = new object[3]
			{
				"@orientacao",
				orientacao,
				OleDbType.Char
			};
			array2 = array8;
			NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			orientacao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance8 = db;
			object[] array9 = new object[1] { text };
			array2 = array9;
			NewLateBinding.LateCall(instance8, null, "ExecuteNonQuery", array9, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}

	public void atualizaItemOrientacaoFiacao(string orientacao, string revisao, long dwg, long indexModelo, string terminal, string tipo)
	{
		try
		{
			string text = "";
			text = "UPDATE Fiacao SET Orientacao=@orientacao WHERE Revisao=@revisao AND DWG=@dwg AND IndexModelo=@indexModelo AND Terminal=@terminal AND Tipo=@tipo";
			object instance = db;
			object[] array = new object[3]
			{
				"@orientacao",
				orientacao,
				OleDbType.Char
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			orientacao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@revisao",
				revisao,
				OleDbType.Char
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance3 = db;
			object[] array4 = new object[3]
			{
				"@dwg",
				dwg,
				OleDbType.Integer
			};
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			dwg = (long)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(long));
			object instance4 = db;
			object[] array5 = new object[3]
			{
				"@indexModelo",
				indexModelo,
				OleDbType.Integer
			};
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			indexModelo = (long)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(long));
			object instance5 = db;
			object[] array6 = new object[3]
			{
				"@terminal",
				terminal,
				OleDbType.Char
			};
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			terminal = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance6 = db;
			object[] array7 = new object[3]
			{
				"@tipo",
				tipo,
				OleDbType.Char
			};
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			tipo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance7 = db;
			object[] array8 = new object[1] { text };
			array2 = array8;
			NewLateBinding.LateCall(instance7, null, "ExecuteNonQuery", array8, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public void AdicionaItemPortas(string revisao, long dwg, long indexModelo, string nomeModelo, string regua, string borne, string terminal, double terminalNum, string tipo, string orientacao = "")
	{
		try
		{
			string text = "";
			text = "Insert into Portas4F(Revisao, DWG, IndexModelo, NomeModelo, Regua, Borne, Terminal, TerminalNum, Tipo, Orientacao) VALUES(@revisao, @dwg, @indexModelo, @nomeModelo, @regua, @borne, @terminal, @terminalNum, @tipo, @orientacao)";
			object instance = db;
			object[] array = new object[3]
			{
				"@revisao",
				revisao,
				OleDbType.Char
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@dwg",
				dwg,
				OleDbType.Integer
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			dwg = (long)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(long));
			object instance3 = db;
			object[] array4 = new object[3]
			{
				"@indexModelo",
				indexModelo,
				OleDbType.Integer
			};
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			indexModelo = (long)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(long));
			object instance4 = db;
			object[] array5 = new object[3]
			{
				"@nomeModelo",
				nomeModelo,
				OleDbType.Char
			};
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			nomeModelo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance5 = db;
			object[] array6 = new object[3]
			{
				"@regua",
				regua,
				OleDbType.Char
			};
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			regua = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance6 = db;
			object[] array7 = new object[3]
			{
				"@borne",
				borne,
				OleDbType.Char
			};
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			borne = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance7 = db;
			object[] array8 = new object[3]
			{
				"@terminal",
				terminal,
				OleDbType.Char
			};
			array2 = array8;
			NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			terminal = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance8 = db;
			object[] array9 = new object[3]
			{
				"@terminalNum",
				terminalNum,
				OleDbType.Double
			};
			array2 = array9;
			NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			terminalNum = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
			object instance9 = db;
			object[] array10 = new object[3]
			{
				"@tipo",
				tipo,
				OleDbType.Char
			};
			array2 = array10;
			NewLateBinding.LateCall(instance9, null, "AddParameter", array10, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			tipo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance10 = db;
			object[] array11 = new object[3]
			{
				"@orientacao",
				orientacao,
				OleDbType.Char
			};
			array2 = array11;
			NewLateBinding.LateCall(instance10, null, "AddParameter", array11, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			orientacao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance11 = db;
			object[] array12 = new object[1] { text };
			array2 = array12;
			NewLateBinding.LateCall(instance11, null, "ExecuteNonQuery", array12, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}

	public void AdicionaItemBornes(string revisao, long dwg, DeclaracoesEntidades.StructureBorne born)
	{
		try
		{
			string text = "";
			text = "Insert into Bornes4F(Revisao, DWG, Painel, IndexRegua, Regua, Alternativo, Handle, Borne, Ordem, Tipo, Pagina, bReserva, LM, Orientacao, BlocoLayout) VALUES(@revisao, @dwg, @painel, @indexRegua, @regua, @alternativo, @handle, @borne, @ordem, @tipo, @pagina, @reserva, @LM, @orientacao, @blocoLayout)";
			object instance = db;
			object[] array = new object[3]
			{
				"@revisao",
				revisao,
				OleDbType.Char
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@dwg",
				dwg,
				OleDbType.Integer
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			dwg = (long)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(long));
			object instance3 = db;
			object[] array4 = new object[3] { "@painel", null, null };
			ref int indexPainel = ref born.indexPainel;
			ref int reference = ref indexPainel;
			array4[1] = indexPainel;
			array4[2] = OleDbType.Integer;
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance4 = db;
			object[] array5 = new object[3] { "@indexRegua", null, null };
			ref int indiceRegua = ref born.IndiceRegua;
			reference = ref indiceRegua;
			array5[1] = indiceRegua;
			array5[2] = OleDbType.Integer;
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance5 = db;
			object[] array6 = new object[3] { "@regua", null, null };
			ref string nomeRegua = ref born.NomeRegua;
			ref string reference2 = ref nomeRegua;
			array6[1] = nomeRegua;
			array6[2] = OleDbType.Char;
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance6 = db;
			object[] array7 = new object[3] { "@alternativo", null, null };
			ref string alternativo = ref born.Alternativo;
			reference2 = ref alternativo;
			array7[1] = alternativo;
			array7[2] = OleDbType.Char;
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance7 = db;
			object[] array8 = new object[3] { "@handle", null, null };
			ref string handle = ref born.Handle;
			reference2 = ref handle;
			array8[1] = handle;
			array8[2] = OleDbType.Char;
			array2 = array8;
			NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance8 = db;
			object[] array9 = new object[3] { "@borne", null, null };
			ref string numero = ref born.Numero;
			reference2 = ref numero;
			array9[1] = numero;
			array9[2] = OleDbType.Char;
			array2 = array9;
			NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance9 = db;
			object[] array10 = new object[3] { "@ordem", null, null };
			ref double ordem = ref born.Ordem;
			array10[1] = ordem;
			array10[2] = OleDbType.Double;
			array2 = array10;
			NewLateBinding.LateCall(instance9, null, "AddParameter", array10, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			ordem = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
			object instance10 = db;
			object[] array11 = new object[3] { "@tipo", null, null };
			ref int tipo = ref born.tipo;
			reference = ref tipo;
			array11[1] = tipo;
			array11[2] = OleDbType.Integer;
			array2 = array11;
			NewLateBinding.LateCall(instance10, null, "AddParameter", array11, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance11 = db;
			object[] array12 = new object[3] { "@pagina", null, null };
			ref string pagina = ref born.pagina;
			reference2 = ref pagina;
			array12[1] = pagina;
			array12[2] = OleDbType.Char;
			array2 = array12;
			NewLateBinding.LateCall(instance11, null, "AddParameter", array12, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance12 = db;
			object[] array13 = new object[3] { "@reserva", null, null };
			ref bool reserva = ref born.reserva;
			array13[1] = reserva;
			array13[2] = OleDbType.Boolean;
			array2 = array13;
			NewLateBinding.LateCall(instance12, null, "AddParameter", array13, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reserva = (bool)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(bool));
			object instance13 = db;
			object[] array14 = new object[3] { "@LM", null, null };
			ref int lm = ref born.lm;
			reference = ref lm;
			array14[1] = lm;
			array14[2] = OleDbType.Integer;
			array2 = array14;
			NewLateBinding.LateCall(instance13, null, "AddParameter", array14, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance14 = db;
			object[] array15 = new object[3] { "@orientacao", null, null };
			ref string orientacao = ref born.Orientacao;
			reference2 = ref orientacao;
			array15[1] = orientacao;
			array15[2] = OleDbType.Char;
			array2 = array15;
			NewLateBinding.LateCall(instance14, null, "AddParameter", array15, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance15 = db;
			object[] array16 = new object[3] { "@blocoLayout", null, null };
			ref string blocoLayout = ref born.BlocoLayout;
			reference2 = ref blocoLayout;
			array16[1] = blocoLayout;
			array16[2] = OleDbType.Char;
			array2 = array16;
			NewLateBinding.LateCall(instance15, null, "AddParameter", array16, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance16 = db;
			object[] array17 = new object[1] { text };
			array2 = array17;
			NewLateBinding.LateCall(instance16, null, "ExecuteNonQuery", array17, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}

	public void AtualizaBlocoLayoutReguas(int indice, string blocoLayout)
	{
		try
		{
			string text = "";
			text = "UPDATE Bornes4F SET BlocoLayout=@bloco WHERE Indice=@indice";
			object instance = db;
			object[] array = new object[3]
			{
				"@bloco",
				blocoLayout,
				OleDbType.Char
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			blocoLayout = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@indice",
				indice,
				OleDbType.Integer
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			indice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance3 = db;
			object[] array4 = new object[1] { text };
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "ExecuteNonQuery", array4, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public void AdicionaItemDispositivos(string revisao, long dwg, int painel, string Tag, string alternativo, string Tipo, string Handle, string Pagina, string BlocoTopografico, string BlocoLayout, int posicaoNum, int ordem)
	{
		try
		{
			string text = "";
			text = "Insert into Dispositivos4F(Revisao, DWG, Painel, Tag, Alternativo, Tipo, Handle, Pagina, BlocoTopografico, BlocoLayout, PosicaoNum, Ordem) VALUES(@revisao, @dwg, @painel, @tag, @alternativo, @tipo, @handle, @pagina, @blocoTopografico, @blocoLayout, @posicaoNum, @ordem)";
			object instance = db;
			object[] array = new object[3]
			{
				"@revisao",
				revisao,
				OleDbType.Char
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@dwg",
				dwg,
				OleDbType.Integer
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			dwg = (long)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(long));
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
			object[] array5 = new object[3]
			{
				"@tag",
				Tag,
				OleDbType.Char
			};
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			Tag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance5 = db;
			object[] array6 = new object[3]
			{
				"@alternativo",
				alternativo,
				OleDbType.Char
			};
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			alternativo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance6 = db;
			object[] array7 = new object[3]
			{
				"@tipo",
				Tipo,
				OleDbType.Char
			};
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			Tipo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance7 = db;
			object[] array8 = new object[3]
			{
				"@handle",
				Handle,
				OleDbType.Char
			};
			array2 = array8;
			NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			Handle = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance8 = db;
			object[] array9 = new object[3]
			{
				"@pagina",
				Pagina,
				OleDbType.Char
			};
			array2 = array9;
			NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			Pagina = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance9 = db;
			object[] array10 = new object[3]
			{
				"@blocoTopografico",
				BlocoTopografico,
				OleDbType.Char
			};
			array2 = array10;
			NewLateBinding.LateCall(instance9, null, "AddParameter", array10, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			BlocoTopografico = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance10 = db;
			object[] array11 = new object[3]
			{
				"@blocoLayout",
				BlocoLayout,
				OleDbType.Char
			};
			array2 = array11;
			NewLateBinding.LateCall(instance10, null, "AddParameter", array11, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			BlocoLayout = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance11 = db;
			object[] array12 = new object[3]
			{
				"@posicaoNum",
				posicaoNum,
				OleDbType.Integer
			};
			array2 = array12;
			NewLateBinding.LateCall(instance11, null, "AddParameter", array12, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			posicaoNum = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance12 = db;
			object[] array13 = new object[3]
			{
				"@ordem",
				ordem,
				OleDbType.Integer
			};
			array2 = array13;
			NewLateBinding.LateCall(instance12, null, "AddParameter", array13, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			ordem = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance13 = db;
			object[] array14 = new object[1] { text };
			array2 = array14;
			NewLateBinding.LateCall(instance13, null, "ExecuteNonQuery", array14, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}

	public void AdicionaItemAplicacao(string revisao, long dwg, int Numero, string Nome, string Secao, string Cor, string TipoCabo, string Isolacao)
	{
		try
		{
			string text = "";
			text = "Insert into Aplicacao4F(Revisao, DWG, Numero, Nome, Secao, Cor, TipoCabo, Isolacao) VALUES(@revisao, @dwg, @numero, @nome, @secao, @cor, @tipoCabo, @isolacao)";
			object instance = db;
			object[] array = new object[3]
			{
				"@revisao",
				revisao,
				OleDbType.Char
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@dwg",
				dwg,
				OleDbType.Integer
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			dwg = (long)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(long));
			object instance3 = db;
			object[] array4 = new object[3]
			{
				"@numero",
				Numero,
				OleDbType.Integer
			};
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			Numero = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance4 = db;
			object[] array5 = new object[3]
			{
				"@nome",
				Nome,
				OleDbType.Char
			};
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			Nome = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance5 = db;
			object[] array6 = new object[3]
			{
				"@secao",
				Secao,
				OleDbType.Char
			};
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			Secao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance6 = db;
			object[] array7 = new object[3]
			{
				"@cor",
				Cor,
				OleDbType.Char
			};
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			Cor = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance7 = db;
			object[] array8 = new object[3]
			{
				"@tipoCabo",
				TipoCabo,
				OleDbType.Char
			};
			array2 = array8;
			NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			TipoCabo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance8 = db;
			object[] array9 = new object[3]
			{
				"@isolacao",
				Isolacao,
				OleDbType.Char
			};
			array2 = array9;
			NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			Isolacao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance9 = db;
			object[] array10 = new object[1] { text };
			array2 = array10;
			NewLateBinding.LateCall(instance9, null, "ExecuteNonQuery", array10, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}

	public void CarregaPlaquetasEletron3(int dwg, int painel, ref Declaracoes2.StructurePlaquetas[] mPlaquetas)
	{
		checked
		{
			try
			{
				string text = "SELECT Tag, Desc1, Desc2, Desc3, Modelo FROM Plaquetas WHERE DWG=@dwg AND Painel=@painel";
				object instance = db;
				object[] array = new object[3]
				{
					"@dwg",
					dwg,
					OleDbType.Integer
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				dwg = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance2 = db;
				object[] array3 = new object[3]
				{
					"@painel",
					painel,
					OleDbType.Integer
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance3 = db;
				object[] array4 = new object[1] { text };
				array2 = array4;
				object obj = NewLateBinding.LateGet(instance3, null, "ExecuteReader", array4, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][0])))
					{
						dataTable.Rows[i][0] = "";
					}
					if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][1])))
					{
						dataTable.Rows[i][1] = "";
					}
					if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][2])))
					{
						dataTable.Rows[i][2] = "";
					}
					if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][3])))
					{
						dataTable.Rows[i][3] = "";
					}
					if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][4])))
					{
						dataTable.Rows[i][4] = "";
					}
					int num2 = Information.UBound(mPlaquetas) + 1;
					mPlaquetas = (Declaracoes2.StructurePlaquetas[])Utils.CopyArray(mPlaquetas, new Declaracoes2.StructurePlaquetas[num2 + 1]);
					mPlaquetas[num2].Nome = Conversions.ToString(dataTable.Rows[i][0]);
					mPlaquetas[num2].Desc1 = Conversions.ToString(dataTable.Rows[i][1]);
					mPlaquetas[num2].Desc2 = Conversions.ToString(dataTable.Rows[i][2]);
					mPlaquetas[num2].Desc3 = Conversions.ToString(dataTable.Rows[i][3]);
					mPlaquetas[num2].Modelo = Conversions.ToString(dataTable.Rows[i][4]);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
		}
	}

	public void RemovePlaquetas(int dwgCorrente)
	{
		try
		{
			string text = "";
			text = "DELETE FROM Plaquetas4 WHERE DWG=@dwgCorrente";
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
			object[] array3 = new object[1] { text };
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "ExecuteNonQuery", array3, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}

	public void AdicionaItemPlaqueta(long dwg, int painel, Declaracoes2.StructurePlaquetas plaqueta)
	{
		try
		{
			string text = "";
			text = "Insert into Plaquetas4(DWG, Painel, Tag, Desc1, Desc2, Desc3, Modelo) VALUES(@dwg, @painel, @tag, @desc1, @desc2, @desc3, @modelo)";
			object instance = db;
			object[] array = new object[3]
			{
				"@dwg",
				dwg,
				OleDbType.Integer
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			dwg = (long)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(long));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@painel",
				painel,
				OleDbType.Integer
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance3 = db;
			object[] array4 = new object[3] { "@tag", null, null };
			ref string nome = ref plaqueta.Nome;
			ref string reference = ref nome;
			array4[1] = nome;
			array4[2] = OleDbType.Char;
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance4 = db;
			object[] array5 = new object[3] { "@desc1", null, null };
			ref string desc = ref plaqueta.Desc1;
			reference = ref desc;
			array5[1] = desc;
			array5[2] = OleDbType.Char;
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance5 = db;
			object[] array6 = new object[3] { "@desc2", null, null };
			ref string desc2 = ref plaqueta.Desc2;
			reference = ref desc2;
			array6[1] = desc2;
			array6[2] = OleDbType.Char;
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance6 = db;
			object[] array7 = new object[3] { "@desc3", null, null };
			ref string desc3 = ref plaqueta.Desc3;
			reference = ref desc3;
			array7[1] = desc3;
			array7[2] = OleDbType.Char;
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance7 = db;
			object[] array8 = new object[3] { "@modelo", null, null };
			ref string modelo = ref plaqueta.Modelo;
			reference = ref modelo;
			array8[1] = modelo;
			array8[2] = OleDbType.Char;
			array2 = array8;
			NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance8 = db;
			object[] array9 = new object[1] { text };
			array2 = array9;
			NewLateBinding.LateCall(instance8, null, "ExecuteNonQuery", array9, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}

	public long ExisteItemPreferencias(long dwg, int painel, string campo, ref string valor)
	{
		long result = 0L;
		valor = "";
		try
		{
			string text = "SELECT Indice, Valor FROM Preferencias WHERE DWG=@dwgCorrente AND Painel=@painel and Campo=@campo";
			object instance = db;
			object[] array = new object[3]
			{
				"@dwgCorrente",
				dwg,
				OleDbType.Integer
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			dwg = (long)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(long));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@painel",
				painel,
				OleDbType.Integer
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance3 = db;
			object[] array4 = new object[3]
			{
				"@campo",
				campo,
				OleDbType.Char
			};
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			campo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance4 = db;
			object[] array5 = new object[1] { text };
			array2 = array5;
			object obj = NewLateBinding.LateGet(instance4, null, "ExecuteReader", array5, null, null, new bool[1] { true });
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			DataTable dataTable = (DataTable)obj;
			if (dataTable.Rows.Count > 0)
			{
				result = Conversions.ToLong(dataTable.Rows[0][0]);
				valor = Conversions.ToString(dataTable.Rows[0][1]);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		return result;
	}

	public void AtualizaItemPreferencias(long Indice, long dwg, int painel, string campo, string valor)
	{
		try
		{
			string text = "";
			text = "UPDATE Preferencias SET dwg=@dwg, painel=@painel, campo=@campo, valor=@valor WHERE Indice=@indice";
			object instance = db;
			object[] array = new object[3]
			{
				"@dwg",
				dwg,
				OleDbType.Integer
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			dwg = (long)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(long));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@painel",
				painel,
				OleDbType.Integer
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance3 = db;
			object[] array4 = new object[3]
			{
				"@campo",
				campo,
				OleDbType.Char
			};
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			campo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance4 = db;
			object[] array5 = new object[3]
			{
				"@valor",
				valor,
				OleDbType.Char
			};
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			valor = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance5 = db;
			object[] array6 = new object[3]
			{
				"@indice",
				Indice,
				OleDbType.Integer
			};
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			Indice = (long)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(long));
			object instance6 = db;
			object[] array7 = new object[1] { text };
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "ExecuteNonQuery", array7, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}

	public void AdicionaItemPreferencias(long dwg, int painel, string campo, string valor)
	{
		try
		{
			string text = "";
			text = "Insert into Preferencias(DWG, Painel, Campo, Valor) VALUES(@dwg, @painel, @campo, @valor)";
			object instance = db;
			object[] array = new object[3]
			{
				"@dwg",
				dwg,
				OleDbType.Integer
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			dwg = (long)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(long));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@painel",
				painel,
				OleDbType.Integer
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance3 = db;
			object[] array4 = new object[3]
			{
				"@campo",
				campo,
				OleDbType.Char
			};
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			campo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance4 = db;
			object[] array5 = new object[3]
			{
				"@valor",
				valor,
				OleDbType.Char
			};
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			valor = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance5 = db;
			object[] array6 = new object[1] { text };
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "ExecuteNonQuery", array6, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}

	public void BuscatodosOsBornesPotenciais(ref frmGerenciadorReguasBornes.structureDadosFiacao[] mDadosFiacao)
	{
		int indice = DeclaracoesGeral.arqAtivo.Indice;
		string text = "";
		int num = 1;
		mDadosFiacao = new frmGerenciadorReguasBornes.structureDadosFiacao[1];
		string text2 = "SELECT Revisao FROM Fiacao WHERE DWG=@dwgCorrente ORDER BY DATA DESC";
		object instance = db;
		object[] array = new object[3]
		{
			"@dwgCorrente",
			indice,
			OleDbType.Integer
		};
		object[] array2 = array;
		NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		indice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
		object instance2 = db;
		object[] array3 = new object[1] { text2 };
		array2 = array3;
		object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
		text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		DataTable dataTable = (DataTable)obj;
		if (dataTable.Rows.Count <= 0)
		{
			return;
		}
		text = Conversions.ToString(dataTable.Rows[0][0]);
		checked
		{
			try
			{
				text2 = "SELECT Potencial, Handle FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao ORDER BY Potencial";
				object instance3 = db;
				object[] array4 = new object[3]
				{
					"@dwgCorrente",
					indice,
					OleDbType.Integer
				};
				array2 = array4;
				NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				indice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance4 = db;
				object[] array5 = new object[3]
				{
					"@revisao",
					text,
					OleDbType.Char
				};
				array2 = array5;
				NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance5 = db;
				object[] array6 = new object[1] { text2 };
				array2 = array6;
				obj = NewLateBinding.LateGet(instance5, null, "ExecuteReader", array6, null, null, new bool[1] { true });
				text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				dataTable = (DataTable)obj;
				if (dataTable.Rows.Count > 0)
				{
					int num2 = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num2; i++)
					{
						mDadosFiacao = (frmGerenciadorReguasBornes.structureDadosFiacao[])Utils.CopyArray(mDadosFiacao, new frmGerenciadorReguasBornes.structureDadosFiacao[num + 1]);
						mDadosFiacao[num].Potencial = Conversions.ToLong(dataTable.Rows[i][0]);
						mDadosFiacao[num].Handle = Conversions.ToString(dataTable.Rows[i][1]);
						num++;
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

	public bool ExistePlaquetasDoEletron3(int dwg)
	{
		bool result = false;
		try
		{
			string text = "SELECT * FROM Plaquetas WHERE DWG=@dwg";
			object instance = db;
			object[] array = new object[3]
			{
				"@dwg",
				dwg,
				OleDbType.Integer
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			dwg = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance2 = db;
			object[] array3 = new object[1] { text };
			array2 = array3;
			object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			DataTable dataTable = (DataTable)obj;
			result = dataTable.Rows.Count > 0;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		finally
		{
		}
		return result;
	}

	public void CarregaTodasReguasDG(int dwgCorrente, string revisao, int painel, ref DataGridView dg)
	{
		checked
		{
			try
			{
				cDadosLM.structureLMRelelatorio[] mLP = new cDadosLM.structureLMRelelatorio[1];
				cDadosAccessImportarProj cDadosAccessImportarProj2 = new cDadosAccessImportarProj();
				try
				{
					cDadosAccessImportarProj2.CarregaTodaLMDoImpProj(ref mLP);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				finally
				{
					cDadosAccessImportarProj2.fechaConexao();
				}
				string text = "SELECT Regua, IndexRegua FROM Bornes4F WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel ORDER BY REGUA";
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
					revisao,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
				List<string> list = new List<string>();
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (!list.Contains(Conversions.ToString(dataTable.Rows[i][0])))
					{
						dg.Rows.Add(dataTable.Rows[i][0], dataTable.Rows[i][1]);
						list.Add(Conversions.ToString(dataTable.Rows[i][0]));
					}
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void CarregaLigacoesTerminalSIEMENS(int dwgCorrente, string revisao, int painel, string tag, string tipo, ref DeclaracoesFiacao.structureFiacao[] mFiacao, ref DeclaracoesFiacao.structureLinkSiemens[] mLinks)
	{
		checked
		{
			try
			{
				int num = Information.UBound(mFiacao);
				for (int i = 1; i <= num; i++)
				{
					string text = mFiacao[i].Terminal;
					bool flag = false;
					mFiacao[i].Lig = new DeclaracoesFiacao.structureLigacao[1];
					bool flag2 = false;
					string text2 = "";
					object[] array2;
					if (Operators.CompareString(tipo, "B", TextCompare: true) == 0)
					{
						text2 = "SELECT Potencial, Ordem, Pagina, Secao, Cor, bLink, Tag, IndexModelo FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Tag=@tag and Terminal=@terminal AND Tipo='B' AND BJumper=@bJumper ORDER BY Secao, Cor";
						object instance = db;
						object[] array = new object[3]
						{
							"@dwgCorrente",
							dwgCorrente,
							OleDbType.Integer
						};
						array2 = array;
						NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
						object instance2 = db;
						object[] array3 = new object[3]
						{
							"@revisao",
							revisao,
							OleDbType.Char
						};
						array2 = array3;
						NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
						object[] array5 = new object[3]
						{
							"@tag",
							tag,
							OleDbType.Char
						};
						array2 = array5;
						NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						tag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						object instance5 = db;
						object[] array6 = new object[3]
						{
							"@terminal",
							text,
							OleDbType.Char
						};
						array2 = array6;
						NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
						{
							"@bJumper",
							false,
							OleDbType.Boolean
						}, null, null, null, IgnoreReturn: true);
					}
					object obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text2 }, null, null, new bool[1] { true });
					text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DataTable dataTable = (DataTable)obj;
					if (dataTable.Rows.Count <= 0)
					{
						continue;
					}
					int num2 = dataTable.Rows.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						int num3 = Conversions.ToInteger(dataTable.Rows[j][0]);
						int num4 = Conversions.ToInteger(dataTable.Rows[j][1]);
						string pagina = Conversions.ToString(dataTable.Rows[j][2]);
						string secao = Conversions.ToString(dataTable.Rows[j][3]);
						string cor = Conversions.ToString(dataTable.Rows[j][4]);
						string regua = Conversions.ToString(dataTable.Rows[j][6]);
						int iRegua = Conversions.ToInteger(dataTable.Rows[j][7]);
						if (Operators.CompareString(tipo, "B", TextCompare: true) == 0)
						{
							flag2 = Conversions.ToBoolean(dataTable.Rows[j][5]);
						}
						mFiacao[i].Pagina = pagina;
						mFiacao[i].Circuito = "";
						if (num4 > 1)
						{
							string text3 = "SELECT Tag, Alternativo, NRegua, Terminal, bLink FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Potencial=@potencial AND Ordem=@ordem";
							object instance6 = db;
							object[] array7 = new object[3]
							{
								"@dwgCorrente",
								dwgCorrente,
								OleDbType.Integer
							};
							array2 = array7;
							NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
							object instance7 = db;
							object[] array8 = new object[3]
							{
								"@revisao",
								revisao,
								OleDbType.Char
							};
							array2 = array8;
							NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
							object instance8 = db;
							object[] array9 = new object[3]
							{
								"@painel",
								painel,
								OleDbType.Integer
							};
							array2 = array9;
							NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
							object instance9 = db;
							object[] array10 = new object[3]
							{
								"@potencial",
								num3,
								OleDbType.Integer
							};
							array2 = array10;
							NewLateBinding.LateCall(instance9, null, "AddParameter", array10, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							num3 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
							NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
							{
								"@ordem",
								num4 - 1,
								OleDbType.Integer
							}, null, null, null, IgnoreReturn: true);
							object instance10 = db;
							object[] array11 = new object[1] { text3 };
							array2 = array11;
							obj = NewLateBinding.LateGet(instance10, null, "ExecuteReader", array11, null, null, new bool[1] { true });
							text3 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
							DataTable dataTable2 = (DataTable)obj;
							if (dataTable2.Rows.Count == 1)
							{
								bool flag3 = Conversions.ToBoolean(dataTable2.Rows[0][4]);
								bool flag4 = false;
								if (flag2 & flag3)
								{
									string right = Conversions.ToString(dataTable2.Rows[0][0]);
									string text4 = Conversions.ToString(dataTable2.Rows[0][3]);
									double num5 = -1.0;
									double num6 = -3.0;
									if (Operators.CompareString(tag, right, TextCompare: true) == 0)
									{
										string text5 = "SELECT Ordem FROM Bornes4F WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Regua=@regua AND (Borne=@borneP OR Borne=@borneD) ORDER BY Ordem";
										object instance11 = db;
										object[] array12 = new object[3]
										{
											"@dwgCorrente",
											dwgCorrente,
											OleDbType.Integer
										};
										array2 = array12;
										NewLateBinding.LateCall(instance11, null, "AddParameter", array12, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
										dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
										object instance12 = db;
										object[] array13 = new object[3]
										{
											"@revisao",
											revisao,
											OleDbType.Char
										};
										array2 = array13;
										NewLateBinding.LateCall(instance12, null, "AddParameter", array13, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
										revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
										object instance13 = db;
										object[] array14 = new object[3]
										{
											"@painel",
											painel,
											OleDbType.Integer
										};
										array2 = array14;
										NewLateBinding.LateCall(instance13, null, "AddParameter", array14, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
										painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
										object instance14 = db;
										object[] array15 = new object[3]
										{
											"@regua",
											tag,
											OleDbType.Char
										};
										array2 = array15;
										NewLateBinding.LateCall(instance14, null, "AddParameter", array15, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
										tag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
										object instance15 = db;
										object[] array16 = new object[3]
										{
											"@borneP",
											text,
											OleDbType.Char
										};
										array2 = array16;
										NewLateBinding.LateCall(instance15, null, "AddParameter", array16, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
										text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
										object instance16 = db;
										object[] array17 = new object[3]
										{
											"@borneD",
											text4,
											OleDbType.Char
										};
										array2 = array17;
										NewLateBinding.LateCall(instance16, null, "AddParameter", array17, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
										text4 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
										object instance17 = db;
										object[] array18 = new object[1] { text5 };
										array2 = array18;
										obj = NewLateBinding.LateGet(instance17, null, "ExecuteReader", array18, null, null, new bool[1] { true });
										text5 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
										DataTable dataTable3 = (DataTable)obj;
										if (dataTable3.Rows.Count == 2)
										{
											num6 = Conversions.ToDouble(dataTable3.Rows[0][0]);
											num5 = Conversions.ToDouble(dataTable3.Rows[1][0]);
											string text6 = "SELECT COUNT(*) FROM Bornes4F WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Regua=@regua AND Ordem>@ordemD AND Ordem<@ordemP";
											object instance18 = db;
											object[] array19 = new object[3]
											{
												"@dwgCorrente",
												dwgCorrente,
												OleDbType.Integer
											};
											array2 = array19;
											NewLateBinding.LateCall(instance18, null, "AddParameter", array19, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
											dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
											object instance19 = db;
											object[] array20 = new object[3]
											{
												"@revisao",
												revisao,
												OleDbType.Char
											};
											array2 = array20;
											NewLateBinding.LateCall(instance19, null, "AddParameter", array20, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
											revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
											object instance20 = db;
											object[] array21 = new object[3]
											{
												"@painel",
												painel,
												OleDbType.Integer
											};
											array2 = array21;
											NewLateBinding.LateCall(instance20, null, "AddParameter", array21, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
											painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
											object instance21 = db;
											object[] array22 = new object[3]
											{
												"@regua",
												tag,
												OleDbType.Char
											};
											array2 = array22;
											NewLateBinding.LateCall(instance21, null, "AddParameter", array22, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
											tag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
											object instance22 = db;
											object[] array23 = new object[3]
											{
												"@ordemD",
												num6,
												OleDbType.Double
											};
											array2 = array23;
											NewLateBinding.LateCall(instance22, null, "AddParameter", array23, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
											num6 = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
											object instance23 = db;
											object[] array24 = new object[3]
											{
												"@ordemP",
												num5,
												OleDbType.Double
											};
											array2 = array24;
											NewLateBinding.LateCall(instance23, null, "AddParameter", array24, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
											num5 = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
											object instance24 = db;
											object[] array25 = new object[1] { text6 };
											array2 = array25;
											obj = NewLateBinding.LateGet(instance24, null, "ExecuteReader", array25, null, null, new bool[1] { true });
											text6 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
											DataTable dataTable4 = (DataTable)obj;
											if (Operators.ConditionalCompareObjectEqual(dataTable4.Rows[0][0], 0, TextCompare: true))
											{
												flag4 = true;
											}
										}
									}
								}
								if (flag4)
								{
									mLinks = (DeclaracoesFiacao.structureLinkSiemens[])Utils.CopyArray(mLinks, new DeclaracoesFiacao.structureLinkSiemens[mLinks.Length + 1]);
									flag = true;
									mLinks[mLinks.Length - 1].Regua = regua;
									mLinks[mLinks.Length - 1].iRegua = iRegua;
									mLinks[mLinks.Length - 1].iOrdem = num4;
									mLinks[mLinks.Length - 1].borne = text;
									mLinks[mLinks.Length - 1].bUp = true;
								}
								else
								{
									ref DeclaracoesFiacao.structureLigacao[] lig = ref mFiacao[i].Lig;
									lig = (DeclaracoesFiacao.structureLigacao[])Utils.CopyArray(lig, new DeclaracoesFiacao.structureLigacao[mFiacao[i].Lig.Length + 1]);
									mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Tag = Conversions.ToString(dataTable2.Rows[0][0]);
									mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Alternativo = Conversions.ToString(dataTable2.Rows[0][1]);
									string text7 = Conversions.ToString(dataTable2.Rows[0][2]);
									if (Operators.CompareString(text7, "", TextCompare: true) != 0)
									{
										mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Term = Conversions.ToString(Operators.AddObject(text7 + ":", dataTable2.Rows[0][3]));
									}
									else
									{
										mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Term = Conversions.ToString(dataTable2.Rows[0][3]);
									}
									mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Secao = secao;
									mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Cor = cor;
								}
							}
						}
						string text8 = "SELECT Tag, Alternativo, NRegua, Terminal, bLink FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Potencial=@potencial AND Ordem=@ordem";
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
							revisao,
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@painel",
							painel,
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@potencial",
							num3,
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						num3 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
						NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
						{
							"@ordem",
							num4 + 1,
							OleDbType.Integer
						}, null, null, null, IgnoreReturn: true);
						obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text8 }, null, null, new bool[1] { true });
						text8 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
						DataTable dataTable5 = (DataTable)obj;
						if (dataTable5.Rows.Count != 1)
						{
							continue;
						}
						bool flag5 = Conversions.ToBoolean(dataTable5.Rows[0][4]);
						bool flag6 = false;
						if (flag2 & flag5)
						{
							string right2 = Conversions.ToString(dataTable5.Rows[0][0]);
							string text9 = Conversions.ToString(dataTable5.Rows[0][3]);
							double num7 = -1.0;
							double num8 = -3.0;
							if (Operators.CompareString(tag, right2, TextCompare: true) == 0)
							{
								string text10 = "SELECT Ordem FROM Bornes4F WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Regua=@regua AND (Borne=@borneP OR Borne=@borneD) ORDER BY Ordem";
								object instance25 = db;
								object[] array26 = new object[3]
								{
									"@dwgCorrente",
									dwgCorrente,
									OleDbType.Integer
								};
								array2 = array26;
								NewLateBinding.LateCall(instance25, null, "AddParameter", array26, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
								dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
								object instance26 = db;
								object[] array27 = new object[3]
								{
									"@revisao",
									revisao,
									OleDbType.Char
								};
								array2 = array27;
								NewLateBinding.LateCall(instance26, null, "AddParameter", array27, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
								revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
								object instance27 = db;
								object[] array28 = new object[3]
								{
									"@painel",
									painel,
									OleDbType.Integer
								};
								array2 = array28;
								NewLateBinding.LateCall(instance27, null, "AddParameter", array28, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
								painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
								object instance28 = db;
								object[] array29 = new object[3]
								{
									"@regua",
									tag,
									OleDbType.Char
								};
								array2 = array29;
								NewLateBinding.LateCall(instance28, null, "AddParameter", array29, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
								tag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
								object instance29 = db;
								object[] array30 = new object[3]
								{
									"@borneP",
									text,
									OleDbType.Char
								};
								array2 = array30;
								NewLateBinding.LateCall(instance29, null, "AddParameter", array30, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
								text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
								object instance30 = db;
								object[] array31 = new object[3]
								{
									"@borneD",
									text9,
									OleDbType.Char
								};
								array2 = array31;
								NewLateBinding.LateCall(instance30, null, "AddParameter", array31, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
								text9 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
								object instance31 = db;
								object[] array32 = new object[1] { text10 };
								array2 = array32;
								obj = NewLateBinding.LateGet(instance31, null, "ExecuteReader", array32, null, null, new bool[1] { true });
								text10 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
								DataTable dataTable6 = (DataTable)obj;
								if (dataTable6.Rows.Count == 2)
								{
									num7 = Conversions.ToDouble(dataTable6.Rows[0][0]);
									num8 = Conversions.ToDouble(dataTable6.Rows[1][0]);
									string text11 = "SELECT COUNT(*) FROM Bornes4F WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Regua=@regua AND Ordem>@ordemP AND Ordem<@ordemD";
									object instance32 = db;
									object[] array33 = new object[3]
									{
										"@dwgCorrente",
										dwgCorrente,
										OleDbType.Integer
									};
									array2 = array33;
									NewLateBinding.LateCall(instance32, null, "AddParameter", array33, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
									dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
									object instance33 = db;
									object[] array34 = new object[3]
									{
										"@revisao",
										revisao,
										OleDbType.Char
									};
									array2 = array34;
									NewLateBinding.LateCall(instance33, null, "AddParameter", array34, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
									revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
									object instance34 = db;
									object[] array35 = new object[3]
									{
										"@painel",
										painel,
										OleDbType.Integer
									};
									array2 = array35;
									NewLateBinding.LateCall(instance34, null, "AddParameter", array35, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
									painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
									object instance35 = db;
									object[] array36 = new object[3]
									{
										"@regua",
										tag,
										OleDbType.Char
									};
									array2 = array36;
									NewLateBinding.LateCall(instance35, null, "AddParameter", array36, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
									tag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
									object instance36 = db;
									object[] array37 = new object[3]
									{
										"@ordemP",
										num7,
										OleDbType.Double
									};
									array2 = array37;
									NewLateBinding.LateCall(instance36, null, "AddParameter", array37, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
									num7 = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
									object instance37 = db;
									object[] array38 = new object[3]
									{
										"@ordemD",
										num8,
										OleDbType.Double
									};
									array2 = array38;
									NewLateBinding.LateCall(instance37, null, "AddParameter", array38, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
									num8 = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
									object instance38 = db;
									object[] array39 = new object[1] { text11 };
									array2 = array39;
									obj = NewLateBinding.LateGet(instance38, null, "ExecuteReader", array39, null, null, new bool[1] { true });
									text11 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
									DataTable dataTable7 = (DataTable)obj;
									if (Operators.ConditionalCompareObjectEqual(dataTable7.Rows[0][0], 0, TextCompare: true))
									{
										flag6 = true;
									}
								}
							}
						}
						if (flag6)
						{
							if (!flag)
							{
								mLinks = (DeclaracoesFiacao.structureLinkSiemens[])Utils.CopyArray(mLinks, new DeclaracoesFiacao.structureLinkSiemens[mLinks.Length + 1]);
								mLinks[mLinks.Length - 1].Regua = regua;
								mLinks[mLinks.Length - 1].iRegua = iRegua;
								mLinks[mLinks.Length - 1].iOrdem = num4;
								mLinks[mLinks.Length - 1].borne = text;
							}
							mLinks[mLinks.Length - 1].bDown = true;
							continue;
						}
						ref DeclaracoesFiacao.structureLigacao[] lig2 = ref mFiacao[i].Lig;
						lig2 = (DeclaracoesFiacao.structureLigacao[])Utils.CopyArray(lig2, new DeclaracoesFiacao.structureLigacao[mFiacao[i].Lig.Length + 1]);
						mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Tag = Conversions.ToString(dataTable5.Rows[0][0]);
						mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Alternativo = Conversions.ToString(dataTable5.Rows[0][1]);
						string text12 = Conversions.ToString(dataTable5.Rows[0][2]);
						if (Operators.CompareString(text12, "", TextCompare: true) != 0)
						{
							mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Term = Conversions.ToString(Operators.AddObject(text12 + ":", dataTable5.Rows[0][3]));
						}
						else
						{
							mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Term = Conversions.ToString(dataTable5.Rows[0][3]);
						}
						mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Secao = secao;
						mFiacao[i].Lig[mFiacao[i].Lig.Length - 1].Cor = cor;
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

	public void CarregaTerminaisReguaTAF(int dwgCorrente, string revisao, int painel, int indexRegua, ref DeclaracoesFiacao.structureFiacaoTAF[] mfiacao)
	{
		checked
		{
			try
			{
				string text = "SELECT Borne, Tipo, Pagina, Handle FROM Bornes4F WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND IndexRegua=@indexRegua and Tipo<2 ORDER BY Ordem";
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
					revisao,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
				object[] array5 = new object[3]
				{
					"@indexRegua",
					indexRegua,
					OleDbType.Integer
				};
				array2 = array5;
				NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				indexRegua = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
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
						mfiacao = (DeclaracoesFiacao.structureFiacaoTAF[])Utils.CopyArray(mfiacao, new DeclaracoesFiacao.structureFiacaoTAF[mfiacao.Length + 1]);
						mfiacao[mfiacao.Length - 1].Terminal = dataTable.Rows[i][0].ToString();
						mfiacao[mfiacao.Length - 1].TipoBorne = Conversions.ToInteger(dataTable.Rows[i][1]);
						mfiacao[mfiacao.Length - 1].Pagina = dataTable.Rows[i][2].ToString();
						mfiacao[mfiacao.Length - 1].Handle = dataTable.Rows[i][3].ToString();
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

	public void CarregaLigacoesTerminalTAF(int dwgCorrente, string revisao, int painel, string tag, string tipo, ref DeclaracoesFiacao.structureFiacaoTAF[] mFiacaoTAF)
	{
		DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mFiacaoTAF);
		DeclaracoesGeral._uscPagina.pbIniciar();
		checked
		{
			try
			{
				int num = Information.UBound(mFiacaoTAF);
				for (int i = 1; i <= num; i++)
				{
					DeclaracoesGeral._uscPagina.pbPasso();
					string terminal = mFiacaoTAF[i].Terminal;
					mFiacaoTAF[i].Lig = new DeclaracoesFiacao.structureLigacaoTAF[1];
					string text = "";
					text = "SELECT Potencial, Ordem, Pagina FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Tag=@tag and Terminal=@terminal AND Tipo='B' AND BJumper=@bJumper ORDER BY Secao, Cor";
					object[] array;
					NewLateBinding.LateCall(db, null, "AddParameter", array = new object[3]
					{
						"@dwgCorrente",
						dwgCorrente,
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "AddParameter", array = new object[3]
					{
						"@revisao",
						revisao,
						OleDbType.Char
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(string));
					NewLateBinding.LateCall(db, null, "AddParameter", array = new object[3]
					{
						"@painel",
						painel,
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "AddParameter", array = new object[3]
					{
						"@tag",
						tag,
						OleDbType.Char
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					tag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(string));
					NewLateBinding.LateCall(db, null, "AddParameter", array = new object[3]
					{
						"@terminal",
						terminal,
						OleDbType.Char
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					terminal = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(string));
					NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
					{
						"@bJumper",
						false,
						OleDbType.Boolean
					}, null, null, null, IgnoreReturn: true);
					object obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array = new object[1] { text }, null, null, new bool[1] { true });
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
					DataTable dataTable = (DataTable)obj;
					if (dataTable.Rows.Count <= 0)
					{
						continue;
					}
					int num2 = dataTable.Rows.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						int num3 = Conversions.ToInteger(dataTable.Rows[j][0]);
						int num4 = Conversions.ToInteger(dataTable.Rows[j][1]);
						string pagina = Conversions.ToString(dataTable.Rows[j][2]);
						mFiacaoTAF[i].Pagina = pagina;
						string text2 = "SELECT Tag, Alternativo, NRegua, Terminal, Handle FROM Fiacao WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Potencial=@potencial AND Tipo='E' AND Ordem<>@ordem";
						NewLateBinding.LateCall(db, null, "AddParameter", array = new object[3]
						{
							"@dwgCorrente",
							dwgCorrente,
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
						NewLateBinding.LateCall(db, null, "AddParameter", array = new object[3]
						{
							"@revisao",
							revisao,
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(string));
						NewLateBinding.LateCall(db, null, "AddParameter", array = new object[3]
						{
							"@painel",
							painel,
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
						NewLateBinding.LateCall(db, null, "AddParameter", array = new object[3]
						{
							"@potencial",
							num3,
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						num3 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
						NewLateBinding.LateCall(db, null, "AddParameter", array = new object[3]
						{
							"@ordem",
							num4,
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						num4 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
						obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array = new object[1] { text2 }, null, null, new bool[1] { true });
						text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
						DataTable dataTable2 = (DataTable)obj;
						if (dataTable2.Rows.Count <= 0)
						{
							continue;
						}
						int num5 = dataTable2.Rows.Count - 1;
						for (int k = 0; k <= num5; k++)
						{
							ref DeclaracoesFiacao.structureLigacaoTAF[] lig = ref mFiacaoTAF[i].Lig;
							lig = (DeclaracoesFiacao.structureLigacaoTAF[])Utils.CopyArray(lig, new DeclaracoesFiacao.structureLigacaoTAF[mFiacaoTAF[i].Lig.Length + 1]);
							mFiacaoTAF[i].Lig[mFiacaoTAF[i].Lig.Length - 1].Tag = Conversions.ToString(dataTable2.Rows[k][0]);
							mFiacaoTAF[i].Lig[mFiacaoTAF[i].Lig.Length - 1].Alternativo = Conversions.ToString(dataTable2.Rows[k][1]);
							string text3 = Conversions.ToString(dataTable2.Rows[k][2]);
							if (Operators.CompareString(text3, "", TextCompare: true) != 0)
							{
								mFiacaoTAF[i].Lig[mFiacaoTAF[i].Lig.Length - 1].Term = Conversions.ToString(Operators.AddObject(text3 + ":", dataTable2.Rows[k][3]));
							}
							else
							{
								mFiacaoTAF[i].Lig[mFiacaoTAF[i].Lig.Length - 1].Term = Conversions.ToString(dataTable2.Rows[k][3]);
							}
							mFiacaoTAF[i].Lig[mFiacaoTAF[i].Lig.Length - 1].Handle = Conversions.ToString(dataTable2.Rows[k][4]);
						}
					}
				}
				DeclaracoesGeral._uscPagina.pbFim();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}
}
