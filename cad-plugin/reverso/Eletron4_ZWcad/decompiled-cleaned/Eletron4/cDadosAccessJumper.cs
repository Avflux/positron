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

public class cDadosAccessJumper
{
	public object db;

	public void fechaConexao()
	{
		NewLateBinding.LateCall(db, null, "fechaConexao", new object[0], null, null, null, IgnoreReturn: true);
	}

	public cDadosAccessJumper()
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

	public void CarregaRevisoesDwgJumperCorrente(int dwgCorrente, ref DeclaracoesFiacao.structureRevisoes[] mRevisoes)
	{
		checked
		{
			try
			{
				string text = "SELECT DISTINCT Revisao, Criador, Data FROM Jumper4 WHERE DWG=@dwgCorrente ORDER BY Data";
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

	public void AdicionaItemPotencial(DeclaracoesFiacao.structurePontosPotencial pot)
	{
		try
		{
			string text = "";
			text = "Insert into Jumper4(Revisao, DWG, Painel, Potencial, Ordem, Pagina, Tag, Alternativo, NRegua, Terminal, TerminalNum, Tipo, Secao, Cor, PosicaoNum, TipoBorne, BJumper, BLink, Handle, IndexModelo, Criador, Data) VALUES(@revisao, @dwg, @painel, @potencial, @ordem, @pagina, @tag, @alternativo, @nregua, @terminal, @terminalNum, @tipo, @secao, @cor, @posicaoNum, @tipoBorne, @bJumper, @bLink, @handle, @indexModelo, @criador, @data)";
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
			object[] array22 = new object[3] { "@criador", null, null };
			ref string criador = ref pot.criador;
			reference = ref criador;
			array22[1] = criador;
			array22[2] = OleDbType.Char;
			array2 = array22;
			NewLateBinding.LateCall(instance21, null, "AddParameter", array22, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance22 = db;
			object[] array23 = new object[3] { "@data", null, null };
			ref DateTime data = ref pot.data;
			array23[1] = data;
			array23[2] = OleDbType.Date;
			array2 = array23;
			NewLateBinding.LateCall(instance22, null, "AddParameter", array23, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			data = (DateTime)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(DateTime));
			object instance23 = db;
			object[] array24 = new object[1] { text };
			array2 = array24;
			NewLateBinding.LateCall(instance23, null, "ExecuteNonQuery", array24, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}

	public void CarregaPotenciais(int dwgCorrente, string revisao, int painel, ref DeclaracoesFiacao.structurePontosPotencial[] mPot)
	{
		checked
		{
			try
			{
				string text = "SELECT Potencial, Handle, Terminal, Ordem, BLink FROM Jumper4 WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel";
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

	public void AtualizaPotenciais(int dwgCorrente, string revisao, ref DataTable varTableFiacaoH)
	{
		checked
		{
			try
			{
				string text = "SELECT Indice, Potencial, Handle, Terminal, Ordem, BLink, Tipo FROM Jumper4 WHERE DWG=@dwgCorrente AND Revisao=@revisao";
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
						text4 = "UPDATE Jumper4 SET Ordem=@ordem, Blink=@bLink WHERE Indice=@indice";
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
				string text = "SELECT DISTINCT Potencial FROM Jumper4 WHERE DWG=@dwgCorrente AND Revisao=@revisao";
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
					string text2 = "SELECT Indice, Ordem FROM Jumper4 WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Potencial=@potencial ORDER BY Ordem";
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
							text3 = "UPDATE Jumper4 SET Ordem=@ordem WHERE Indice=@indice";
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

	public void CarregaPnRev(int dwgCorrente, string revisao, ref DeclaracoesFiacao.structurePnRev[] mPnRev)
	{
		checked
		{
			try
			{
				string text = "SELECT DISTINCT Painel FROM Jumper4 WHERE DWG=@dwgCorrente AND Revisao=@revisao ORDER BY Painel";
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

	public void CarregaRevisoesDwgCorrente(int dwgCorrente, ref DeclaracoesFiacao.structureRevisoes[] mRevisoes)
	{
		checked
		{
			try
			{
				string text = "SELECT DISTINCT Revisao, Criador, Data FROM Jumper4 WHERE DWG=@dwgCorrente ORDER BY Data";
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

	public void CarregaUltimaRevisaoDwgCorrente(int dwgCorrente, ref DeclaracoesFiacao.structureRevisoes[] mRevisoes)
	{
		checked
		{
			try
			{
				string text = "SELECT DISTINCT Revisao, Criador, Data FROM Jumper4 WHERE DWG=@dwgCorrente AND Revisao <> @valor ORDER BY Data";
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
				NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
				{
					"@valor",
					"CORR",
					OleDbType.Char
				}, null, null, null, IgnoreReturn: true);
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

	public void CarregaSequenciamento(int dwgCorrente, string revisao, int painel, int potencial, ref DataGridView dgSeq, ref Label lblSecao, ref Label lblCor)
	{
		checked
		{
			try
			{
				string text = "SELECT Indice, Tag, NRegua, Terminal, Pagina, Secao, Cor FROM Jumper4 WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Potencial=@potencial ORDER BY Ordem";
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
				text = "SELECT Indice, Tag, NRegua, Terminal, Pagina, Secao, Cor FROM Jumper4 WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Potencial=@potencial ORDER BY Ordem";
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
				NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
				{
					"@revisao",
					"CORR",
					OleDbType.Char
				}, null, null, null, IgnoreReturn: true);
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
				object[] array9 = new object[3]
				{
					"@potencial",
					potencial,
					OleDbType.Integer
				};
				array2 = array9;
				NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				potencial = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance9 = db;
				object[] array10 = new object[1] { text };
				array2 = array10;
				obj = NewLateBinding.LateGet(instance9, null, "ExecuteReader", array10, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable2 = (DataTable)obj;
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (i == 0)
					{
						lblSecao.Text = Conversions.ToString(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 612], dataTable.Rows[i][5]));
						lblCor.Text = Conversions.ToString(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 613], dataTable.Rows[i][6]));
					}
					int num2 = 0;
					int num3 = dataTable2.Rows.Count - 1;
					for (int j = 0; j <= num3; j++)
					{
						if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(dataTable2.Rows[j][1], dataTable.Rows[i][1], TextCompare: true), Operators.CompareObjectEqual(dataTable2.Rows[j][2], dataTable.Rows[i][2], TextCompare: true)), Operators.CompareObjectEqual(dataTable2.Rows[j][3], dataTable.Rows[i][3], TextCompare: true))))
						{
							num2 = Conversions.ToInteger(dataTable2.Rows[j][0]);
							break;
						}
					}
					dgSeq.Rows.Add(dataTable.Rows[i][0], dataTable.Rows[i][1], dataTable.Rows[i][2], dataTable.Rows[i][3], dataTable.Rows[i][4], num2);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public List<int> carregaTodosPotenciais(int dwgCorrente, string revisao, int painel, string tag, bool b3T, ref Dictionary<int, int> dicPot)
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
					text = "SELECT DISTINCT Potencial FROM Jumper4 WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND Tag=@tag ORDER BY Potencial";
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
					text = "SELECT DISTINCT Potencial FROM Jumper4 WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel ORDER BY Potencial";
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

	public List<string> carregaDispositivos(int dwgCorrente, string revisao, int painel)
	{
		List<string> list = new List<string>();
		checked
		{
			try
			{
				string text = "SELECT DISTINCT Tag FROM Jumper4 WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel ORDER BY Tag";
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

	public void CarregaDicPotenciais(int dwgCorrente, string revisao, ref Dictionary<int, int> dicPot)
	{
		checked
		{
			try
			{
				string text = "";
				text = "SELECT DISTINCT Potencial FROM Jumper4 WHERE DWG=@dwgCorrente AND Revisao=@revisao";
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
						string text2 = "";
						text2 = "SELECT COUNT(*) FROM Jumper4 WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Potencial=@potencial";
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
						dicPot.Add(Conversions.ToInteger(dataTable.Rows[i][0]), Conversions.ToInteger(dataTable2.Rows[0][0]));
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

	public void AtualizaOrdemTerminal(int indice, int ordem)
	{
		try
		{
			string text = "";
			text = "UPDATE Jumper4 SET Ordem=@ordem WHERE Indice=@indice";
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

	public void CarregaPotenciaisPainel(int dwgCorrente, string revisao, int painel, ref DeclaracoesFiacao.structurePotencial[] mPotencial)
	{
		checked
		{
			try
			{
				string text = "SELECT Potencial, Tag, Alternativo, NRegua, Terminal, bLink, Secao, Cor, Pagina, IndexModelo FROM Jumper4 WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND BJumper=@bJumper ORDER BY Potencial, Ordem";
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
					true,
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
						mPotencial[num2].bLink = Conversions.ToBoolean(dataTable.Rows[i][5]);
						mPotencial[num2].Secao = Conversions.ToString(dataTable.Rows[i][6]);
						mPotencial[num2].Cor = Conversions.ToString(dataTable.Rows[i][7]);
						mPotencial[num2].Pagina = Conversions.ToString(dataTable.Rows[i][8]);
						mPotencial[num2].indexModelo = Conversions.ToInteger(dataTable.Rows[i][9]);
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

	public void CarregaPotenciaisPainel2(int dwgCorrente, string revisao, int painel, ref DeclaracoesFiacao.structurePotencial[] mPotencial)
	{
		checked
		{
			try
			{
				Dictionary<int, double> dictionary = new Dictionary<int, double>();
				string text = "SELECT DISTINCT Potencial FROM Jumper4 WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND BJumper=@bJumper ORDER BY Potencial";
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
					true,
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
						string text2 = "SELECT Pagina FROM Jumper4 WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND BJumper=@bJumper AND Potencial=@potencial ORDER BY Ordem";
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
							true,
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
					string text3 = "SELECT Tag, Alternativo, NRegua, Terminal, bLink, Secao, Cor, Pagina, IndexModelo FROM Jumper4 WHERE DWG=@dwgCorrente AND Revisao=@revisao AND Painel=@painel AND BJumper=@bJumper AND Potencial=@potencial ORDER BY Ordem";
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
						true,
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
}
