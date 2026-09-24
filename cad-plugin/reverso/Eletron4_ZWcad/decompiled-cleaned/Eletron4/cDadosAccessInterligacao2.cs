using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class cDadosAccessInterligacao2
{
	public object db;

	public void fechaConexao()
	{
		NewLateBinding.LateCall(db, null, "fechaConexao", new object[0], null, null, null, IgnoreReturn: true);
	}

	public cDadosAccessInterligacao2()
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

	public void CarregaRevisoesDwgIligCorrente(int dwgCorrente, ref DeclaracoesFiacao.structureRevisoes[] mRevisoes)
	{
		checked
		{
			try
			{
				string text = "SELECT DISTINCT Revisao, Criador, Data FROM Interligacao4 WHERE DWG=@dwgCorrente ORDER BY Data";
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
				List<string> list = new List<string>();
				list.Add("Portas4I");
				list.Add("Bornes4I");
				foreach (string item in list)
				{
					text = "SELECT DISTINCT Revisao FROM " + item + " WHERE DWG=@dwgCorrente ORDER BY Revisao";
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@dwgCorrente",
						dwgCorrente,
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					dwgCorrente = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					dataTable = (DataTable)obj;
					if (dataTable.Rows.Count <= 0)
					{
						continue;
					}
					int num2 = dataTable.Rows.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						bool flag = false;
						int num3 = Information.UBound(mRevisoes);
						for (int k = 1; k <= num3; k++)
						{
							if (Operators.ConditionalCompareObjectEqual(mRevisoes[k].revisao, dataTable.Rows[j][0], TextCompare: true))
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							mRevisoes = (DeclaracoesFiacao.structureRevisoes[])Utils.CopyArray(mRevisoes, new DeclaracoesFiacao.structureRevisoes[Information.UBound(mRevisoes) + 1 + 1]);
							mRevisoes[Information.UBound(mRevisoes)].revisao = Conversions.ToString(dataTable.Rows[j][0]);
							mRevisoes[Information.UBound(mRevisoes)].criador = " ";
							mRevisoes[Information.UBound(mRevisoes)].data = DateTime.MinValue;
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

	public void CarregaRevisoesCabos4(ref DeclaracoesFiacao.structureRevisoes[] mRevisoes)
	{
		checked
		{
			try
			{
				string text = "SELECT DISTINCT Revisao, Criador, Data FROM Cabos4 ORDER BY Data";
				object instance = db;
				object[] array = new object[1] { text };
				object[] array2 = array;
				object obj = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
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

	public void CarregaPnRev(string revisao, ref DeclaracoesFiacao.structurePnRev[] mPnRev)
	{
		List<int> list = new List<int>();
		checked
		{
			try
			{
				string text = "SELECT DISTINCT Pn1 FROM Cabos4 WHERE Revisao=@revisao ORDER BY Pn1";
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
						mPnRev = (DeclaracoesFiacao.structurePnRev[])Utils.CopyArray(mPnRev, new DeclaracoesFiacao.structurePnRev[Information.UBound(mPnRev) + 1 + 1]);
						mPnRev[Information.UBound(mPnRev)].revisao = revisao;
						mPnRev[Information.UBound(mPnRev)].painel = Conversions.ToInteger(dataTable.Rows[i][0]);
						list.Add(Conversions.ToInteger(dataTable.Rows[i][0]));
					}
				}
				text = "SELECT DISTINCT Pn2 FROM Cabos4 WHERE Revisao=@revisao ORDER BY Pn2";
				NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
				{
					"@revisao",
					revisao,
					OleDbType.Char
				}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				dataTable = (DataTable)obj;
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num2 = dataTable.Rows.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					if (!list.Contains(Conversions.ToInteger(dataTable.Rows[j][0])))
					{
						mPnRev = (DeclaracoesFiacao.structurePnRev[])Utils.CopyArray(mPnRev, new DeclaracoesFiacao.structurePnRev[Information.UBound(mPnRev) + 1 + 1]);
						mPnRev[Information.UBound(mPnRev)].revisao = revisao;
						mPnRev[Information.UBound(mPnRev)].painel = Conversions.ToInteger(dataTable.Rows[j][0]);
						list.Add(Conversions.ToInteger(dataTable.Rows[j][0]));
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

	public void AdicionaItemInterligacao(DeclaracoesInterligacao.structureInterlig ilig)
	{
		try
		{
			string text = "";
			text = "Insert into Interligacao4(Revisao, DWG, Tag_Cabo, Num_Veia, Nome_Veia, DWG1, Documento1, Painel1, Tag1, Alternativo1, NRegua1, Terminal1, TerminalNum1, TipoBorne1, Handle1, Pagina1, Posicao1, IndexModelo1, DWG2, Documento2, Painel2, Tag2, Alternativo2, NRegua2, Terminal2, TerminalNum2, TipoBorne2, Handle2, Pagina2, Posicao2, IndexModelo2 , Criador, Data) VALUES(@revisao, @dwg, @tagCabo, @numVeia, @nomeVeia, @dwg1, @documento1, @painel1, @tag1, @alternativo1, @nregua1, @terminal1, @terminalNum1, @tipoBorne1, @handle1, @pagina1, @posicao1, @indexModelo1, @dwg2, @documento2, @painel2, @tag2, @alternativo2, @nregua2, @terminal2, @terminalNum2, @tipoBorne2, @handle2, @pagina2, @posicao2, @indexModelo2, @criador, @data)";
			object instance = db;
			object[] array = new object[3] { "@revisao", null, null };
			ref string revisao = ref ilig.revisao;
			ref string reference = ref revisao;
			array[1] = revisao;
			array[2] = OleDbType.Char;
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[3] { "@dwg", null, null };
			ref int dWG = ref ilig.DWG;
			ref int reference2 = ref dWG;
			array3[1] = dWG;
			array3[2] = OleDbType.Integer;
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance3 = db;
			object[] array4 = new object[3] { "@tagCabo", null, null };
			ref string tag_Cabo = ref ilig.Tag_Cabo;
			reference = ref tag_Cabo;
			array4[1] = tag_Cabo;
			array4[2] = OleDbType.Char;
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance4 = db;
			object[] array5 = new object[3] { "@numVeia", null, null };
			ref int num_Veia = ref ilig.Num_Veia;
			reference2 = ref num_Veia;
			array5[1] = num_Veia;
			array5[2] = OleDbType.Integer;
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance5 = db;
			object[] array6 = new object[3] { "@nomeVeia", null, null };
			ref string nome_Veia = ref ilig.Nome_Veia;
			reference = ref nome_Veia;
			array6[1] = nome_Veia;
			array6[2] = OleDbType.Char;
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance6 = db;
			object[] array7 = new object[3] { "@dwg1", null, null };
			ref int dwg = ref ilig.dwg1;
			reference2 = ref dwg;
			array7[1] = dwg;
			array7[2] = OleDbType.Integer;
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance7 = db;
			object[] array8 = new object[3] { "@documento1", null, null };
			ref string documento = ref ilig.Documento1;
			reference = ref documento;
			array8[1] = documento;
			array8[2] = OleDbType.Char;
			array2 = array8;
			NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance8 = db;
			object[] array9 = new object[3] { "@painel1", null, null };
			ref short painel = ref ilig.painel1;
			ref short reference3 = ref painel;
			array9[1] = painel;
			array9[2] = OleDbType.Integer;
			array2 = array9;
			NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference3 = (short)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(short));
			object instance9 = db;
			object[] array10 = new object[3] { "@tag1", null, null };
			ref string tag = ref ilig.tag1;
			reference = ref tag;
			array10[1] = tag;
			array10[2] = OleDbType.Char;
			array2 = array10;
			NewLateBinding.LateCall(instance9, null, "AddParameter", array10, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance10 = db;
			object[] array11 = new object[3] { "@alternativo1", null, null };
			ref string alternativo = ref ilig.alternativo1;
			reference = ref alternativo;
			array11[1] = alternativo;
			array11[2] = OleDbType.Char;
			array2 = array11;
			NewLateBinding.LateCall(instance10, null, "AddParameter", array11, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			if (Operators.CompareString(ilig.tipo1, "IB", TextCompare: true) != 0)
			{
				object instance11 = db;
				object[] array12 = new object[3] { "@nregua1", null, null };
				ref string nRegua = ref ilig.nRegua1;
				reference = ref nRegua;
				array12[1] = nRegua;
				array12[2] = OleDbType.Char;
				array2 = array12;
				NewLateBinding.LateCall(instance11, null, "AddParameter", array12, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			}
			else
			{
				NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
				{
					"@nregua1",
					"",
					OleDbType.Char
				}, null, null, null, IgnoreReturn: true);
			}
			object instance12 = db;
			object[] array13 = new object[3] { "@terminal1", null, null };
			ref string terminal = ref ilig.terminal1;
			reference = ref terminal;
			array13[1] = terminal;
			array13[2] = OleDbType.Char;
			array2 = array13;
			NewLateBinding.LateCall(instance12, null, "AddParameter", array13, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance13 = db;
			object[] array14 = new object[3] { "@terminalNum1", null, null };
			ref double terminalNum = ref ilig.terminalNum1;
			ref double reference4 = ref terminalNum;
			array14[1] = terminalNum;
			array14[2] = OleDbType.Double;
			array2 = array14;
			NewLateBinding.LateCall(instance13, null, "AddParameter", array14, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference4 = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
			object instance14 = db;
			object[] array15 = new object[3] { "@tipoBorne1", null, null };
			ref short tipoBorne = ref ilig.tipoBorne1;
			reference3 = ref tipoBorne;
			array15[1] = tipoBorne;
			array15[2] = OleDbType.Integer;
			array2 = array15;
			NewLateBinding.LateCall(instance14, null, "AddParameter", array15, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference3 = (short)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(short));
			object instance15 = db;
			object[] array16 = new object[3] { "@handle1", null, null };
			ref string handle = ref ilig.handle1;
			reference = ref handle;
			array16[1] = handle;
			array16[2] = OleDbType.Char;
			array2 = array16;
			NewLateBinding.LateCall(instance15, null, "AddParameter", array16, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance16 = db;
			object[] array17 = new object[3] { "@pagina1", null, null };
			ref string layer = ref ilig.layer1;
			reference = ref layer;
			array17[1] = layer;
			array17[2] = OleDbType.Char;
			array2 = array17;
			NewLateBinding.LateCall(instance16, null, "AddParameter", array17, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance17 = db;
			object[] array18 = new object[3] { "@posicao1", null, null };
			ref string posicao = ref ilig.posicao1;
			reference = ref posicao;
			array18[1] = posicao;
			array18[2] = OleDbType.Char;
			array2 = array18;
			NewLateBinding.LateCall(instance17, null, "AddParameter", array18, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance18 = db;
			object[] array19 = new object[3] { "@indexModelo1", null, null };
			ref short indexModelo = ref ilig.indexModelo1;
			reference3 = ref indexModelo;
			array19[1] = indexModelo;
			array19[2] = OleDbType.Integer;
			array2 = array19;
			NewLateBinding.LateCall(instance18, null, "AddParameter", array19, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference3 = (short)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(short));
			object instance19 = db;
			object[] array20 = new object[3] { "@dwg2", null, null };
			ref int dwg2 = ref ilig.dwg2;
			reference2 = ref dwg2;
			array20[1] = dwg2;
			array20[2] = OleDbType.Integer;
			array2 = array20;
			NewLateBinding.LateCall(instance19, null, "AddParameter", array20, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance20 = db;
			object[] array21 = new object[3] { "@documento2", null, null };
			ref string documento2 = ref ilig.Documento2;
			reference = ref documento2;
			array21[1] = documento2;
			array21[2] = OleDbType.Char;
			array2 = array21;
			NewLateBinding.LateCall(instance20, null, "AddParameter", array21, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance21 = db;
			object[] array22 = new object[3] { "@painel2", null, null };
			ref short painel2 = ref ilig.painel2;
			reference3 = ref painel2;
			array22[1] = painel2;
			array22[2] = OleDbType.Integer;
			array2 = array22;
			NewLateBinding.LateCall(instance21, null, "AddParameter", array22, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference3 = (short)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(short));
			object instance22 = db;
			object[] array23 = new object[3] { "@tag2", null, null };
			ref string tag2 = ref ilig.tag2;
			reference = ref tag2;
			array23[1] = tag2;
			array23[2] = OleDbType.Char;
			array2 = array23;
			NewLateBinding.LateCall(instance22, null, "AddParameter", array23, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance23 = db;
			object[] array24 = new object[3] { "@alternativo2", null, null };
			ref string alternativo2 = ref ilig.alternativo2;
			reference = ref alternativo2;
			array24[1] = alternativo2;
			array24[2] = OleDbType.Char;
			array2 = array24;
			NewLateBinding.LateCall(instance23, null, "AddParameter", array24, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			if (Operators.CompareString(ilig.tipo2, "IB", TextCompare: true) != 0)
			{
				object instance24 = db;
				object[] array25 = new object[3] { "@nregua2", null, null };
				ref string nRegua2 = ref ilig.nRegua2;
				reference = ref nRegua2;
				array25[1] = nRegua2;
				array25[2] = OleDbType.Char;
				array2 = array25;
				NewLateBinding.LateCall(instance24, null, "AddParameter", array25, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			}
			else
			{
				NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
				{
					"@nregua2",
					"",
					OleDbType.Char
				}, null, null, null, IgnoreReturn: true);
			}
			object instance25 = db;
			object[] array26 = new object[3] { "@terminal2", null, null };
			ref string terminal2 = ref ilig.terminal2;
			reference = ref terminal2;
			array26[1] = terminal2;
			array26[2] = OleDbType.Char;
			array2 = array26;
			NewLateBinding.LateCall(instance25, null, "AddParameter", array26, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance26 = db;
			object[] array27 = new object[3] { "@terminalNum2", null, null };
			ref double terminalNum2 = ref ilig.terminalNum2;
			reference4 = ref terminalNum2;
			array27[1] = terminalNum2;
			array27[2] = OleDbType.Double;
			array2 = array27;
			NewLateBinding.LateCall(instance26, null, "AddParameter", array27, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference4 = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
			object instance27 = db;
			object[] array28 = new object[3] { "@tipoBorne2", null, null };
			ref short tipoBorne2 = ref ilig.tipoBorne2;
			reference3 = ref tipoBorne2;
			array28[1] = tipoBorne2;
			array28[2] = OleDbType.Integer;
			array2 = array28;
			NewLateBinding.LateCall(instance27, null, "AddParameter", array28, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference3 = (short)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(short));
			object instance28 = db;
			object[] array29 = new object[3] { "@handle2", null, null };
			ref string handle2 = ref ilig.handle2;
			reference = ref handle2;
			array29[1] = handle2;
			array29[2] = OleDbType.Char;
			array2 = array29;
			NewLateBinding.LateCall(instance28, null, "AddParameter", array29, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance29 = db;
			object[] array30 = new object[3] { "@pagina2", null, null };
			ref string layer2 = ref ilig.layer2;
			reference = ref layer2;
			array30[1] = layer2;
			array30[2] = OleDbType.Char;
			array2 = array30;
			NewLateBinding.LateCall(instance29, null, "AddParameter", array30, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance30 = db;
			object[] array31 = new object[3] { "@posicao2", null, null };
			ref string posicao2 = ref ilig.posicao2;
			reference = ref posicao2;
			array31[1] = posicao2;
			array31[2] = OleDbType.Char;
			array2 = array31;
			NewLateBinding.LateCall(instance30, null, "AddParameter", array31, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance31 = db;
			object[] array32 = new object[3] { "@indexModelo2", null, null };
			ref short indexModelo2 = ref ilig.indexModelo2;
			reference3 = ref indexModelo2;
			array32[1] = indexModelo2;
			array32[2] = OleDbType.Integer;
			array2 = array32;
			NewLateBinding.LateCall(instance31, null, "AddParameter", array32, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference3 = (short)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(short));
			object instance32 = db;
			object[] array33 = new object[3] { "@criador", null, null };
			ref string criador = ref ilig.criador;
			reference = ref criador;
			array33[1] = criador;
			array33[2] = OleDbType.Char;
			array2 = array33;
			NewLateBinding.LateCall(instance32, null, "AddParameter", array33, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance33 = db;
			object[] array34 = new object[3] { "@data", null, null };
			ref DateTime data = ref ilig.data;
			array34[1] = data;
			array34[2] = OleDbType.Date;
			array2 = array34;
			NewLateBinding.LateCall(instance33, null, "AddParameter", array34, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			data = (DateTime)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(DateTime));
			NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}

	public void RemoveRevisaoTabelaParaDWG(string nomeTabela, int dwgCorrente, string revisao)
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

	public void RemoveRevisaoTabelaParaTodosDWG(string nomeTabela, string revisao)
	{
		try
		{
			string text = "";
			text = "DELETE FROM " + nomeTabela + " WHERE Revisao=@revisao";
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

	public void AdicionaItemPortas(string revisao, long dwg, long indexModelo, string nomeModelo, string regua, string borne, string terminal, double terminalNum, string tipo)
	{
		try
		{
			string text = "";
			text = "Insert into Portas4I(Revisao, DWG, IndexModelo, NomeModelo, Regua, Borne, Terminal, TerminalNum, Tipo) VALUES(@revisao, @dwg, @indexModelo, @nomeModelo, @regua, @borne, @terminal, @terminalNum, @tipo)";
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
			object[] array11 = new object[1] { text };
			array2 = array11;
			NewLateBinding.LateCall(instance10, null, "ExecuteNonQuery", array11, null, null, new bool[1] { true }, IgnoreReturn: true);
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
			text = "Insert into Bornes4I(Revisao, DWG, Painel, IndexRegua, Regua, Alternativo, Handle, Borne, Ordem, Tipo, Pagina, bReserva) VALUES(@revisao, @dwg, @painel, @indexRegua, @regua, @alternativo, @handle, @borne, @ordem, @tipo, @pagina, @reserva)";
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

	public void CarregaCabos(ref DeclaracoesInterligacao.structureCabo[] mCabos)
	{
		checked
		{
			try
			{
				string text = "SELECT Tag, Formacao, Blindagem, Pn1, Pn2, Codigo, Funcao, Aterrar, Comprimento, Trajeto, Instrucao, Diametro, Grupo, Cabos FROM Cabos ORDER BY Tag";
				object instance = db;
				object[] array = new object[1] { text };
				object[] array2 = array;
				object obj = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					int num2 = Information.UBound(mCabos) + 1;
					mCabos = (DeclaracoesInterligacao.structureCabo[])Utils.CopyArray(mCabos, new DeclaracoesInterligacao.structureCabo[num2 + 1]);
					if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][0])))
					{
						dataTable.Rows[i][0] = "";
					}
					if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][1])))
					{
						dataTable.Rows[i][1] = "";
					}
					if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][5])))
					{
						dataTable.Rows[i][5] = "";
					}
					if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][6])))
					{
						dataTable.Rows[i][6] = "";
					}
					if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][8])))
					{
						dataTable.Rows[i][8] = 0;
					}
					if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][9])))
					{
						dataTable.Rows[i][9] = "";
					}
					if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][10])))
					{
						dataTable.Rows[i][10] = "";
					}
					if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][11])))
					{
						dataTable.Rows[i][11] = 0;
					}
					if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][12])))
					{
						dataTable.Rows[i][12] = "";
					}
					mCabos[num2].Tag = Conversions.ToString(dataTable.Rows[i][0]);
					mCabos[num2].Formacao = Conversions.ToString(dataTable.Rows[i][1]);
					mCabos[num2].Blindagem = Conversions.ToBoolean(dataTable.Rows[i][2]);
					mCabos[num2].Pn1 = Conversions.ToInteger(dataTable.Rows[i][3]);
					mCabos[num2].Pn2 = Conversions.ToInteger(dataTable.Rows[i][4]);
					mCabos[num2].Codigo = Conversions.ToString(dataTable.Rows[i][5]);
					mCabos[num2].Funcao = Conversions.ToString(dataTable.Rows[i][6]);
					mCabos[num2].Aterrar = Conversions.ToInteger(dataTable.Rows[i][7]);
					mCabos[num2].Comprimento = Conversions.ToDouble(dataTable.Rows[i][8]);
					mCabos[num2].Trajeto = Conversions.ToString(dataTable.Rows[i][9]);
					mCabos[num2].Instrucao = Conversions.ToString(dataTable.Rows[i][10]);
					mCabos[num2].Diametro = Conversions.ToDouble(dataTable.Rows[i][11]);
					mCabos[num2].Grupo = Conversions.ToString(dataTable.Rows[i][12]);
					mCabos[num2].Cabos = Conversions.ToInteger(dataTable.Rows[i][13]);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void CarregaVeias(ref DeclaracoesInterligacao.structureVeia[] mVeias)
	{
		checked
		{
			try
			{
				string text = "SELECT Tag, Indice, Nome_Veia, Uso, Funcao FROM Veias ORDER BY Tag";
				object instance = db;
				object[] array = new object[1] { text };
				object[] array2 = array;
				object obj = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					int num2 = Information.UBound(mVeias) + 1;
					mVeias = (DeclaracoesInterligacao.structureVeia[])Utils.CopyArray(mVeias, new DeclaracoesInterligacao.structureVeia[num2 + 1]);
					mVeias[num2].Tag = Conversions.ToString(dataTable.Rows[i][0]);
					mVeias[num2].Num_Veia = Conversions.ToInteger(dataTable.Rows[i][1]);
					if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][2])))
					{
						dataTable.Rows[i][2] = "";
					}
					mVeias[num2].Nome_Veia = Conversions.ToString(dataTable.Rows[i][2]);
					mVeias[num2].Uso = Conversions.ToBoolean(dataTable.Rows[i][3]);
					mVeias[num2].Funcao = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][4]));
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void AdicionaItemCabos4(string revisao, DeclaracoesInterligacao.structureCabo cabo)
	{
		try
		{
			string text = "";
			text = "Insert into Cabos4(Revisao, Tag, Formacao, Blindagem, Pn1, Pn2, Codigo, Funcao, Aterrar, Comprimento, Trajeto, Instrucao, Diametro, Grupo, Cabos, Criador, Data) VALUES(@revisao, @tag, @formacao, @blindagem, @pn1, @pn2, @codigo, @funcao, @aterrar, @comprimento, @trajeto, @instrucao, @diametro, @grupo, @cabos, @criador, @data)";
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
			object[] array3 = new object[3] { "@tag", null, null };
			ref string tag = ref cabo.Tag;
			ref string reference = ref tag;
			array3[1] = tag;
			array3[2] = OleDbType.Char;
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance3 = db;
			object[] array4 = new object[3] { "@formacao", null, null };
			ref string formacao = ref cabo.Formacao;
			reference = ref formacao;
			array4[1] = formacao;
			array4[2] = OleDbType.Char;
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance4 = db;
			object[] array5 = new object[3] { "@blindagem", null, null };
			ref bool blindagem = ref cabo.Blindagem;
			array5[1] = blindagem;
			array5[2] = OleDbType.Boolean;
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			blindagem = (bool)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(bool));
			object instance5 = db;
			object[] array6 = new object[3] { "@pn1", null, null };
			ref int pn = ref cabo.Pn1;
			ref int reference2 = ref pn;
			array6[1] = pn;
			array6[2] = OleDbType.Integer;
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance6 = db;
			object[] array7 = new object[3] { "@pn2", null, null };
			ref int pn2 = ref cabo.Pn2;
			reference2 = ref pn2;
			array7[1] = pn2;
			array7[2] = OleDbType.Integer;
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance7 = db;
			object[] array8 = new object[3] { "@codigo", null, null };
			ref string codigo = ref cabo.Codigo;
			reference = ref codigo;
			array8[1] = codigo;
			array8[2] = OleDbType.Char;
			array2 = array8;
			NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance8 = db;
			object[] array9 = new object[3] { "@funcao", null, null };
			ref string funcao = ref cabo.Funcao;
			reference = ref funcao;
			array9[1] = funcao;
			array9[2] = OleDbType.Char;
			array2 = array9;
			NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance9 = db;
			object[] array10 = new object[3] { "@aterrar", null, null };
			ref int aterrar = ref cabo.Aterrar;
			reference2 = ref aterrar;
			array10[1] = aterrar;
			array10[2] = OleDbType.Integer;
			array2 = array10;
			NewLateBinding.LateCall(instance9, null, "AddParameter", array10, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance10 = db;
			object[] array11 = new object[3] { "@comprimento", null, null };
			ref double comprimento = ref cabo.Comprimento;
			ref double reference3 = ref comprimento;
			array11[1] = comprimento;
			array11[2] = OleDbType.Double;
			array2 = array11;
			NewLateBinding.LateCall(instance10, null, "AddParameter", array11, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference3 = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
			object instance11 = db;
			object[] array12 = new object[3] { "@trajeto", null, null };
			ref string trajeto = ref cabo.Trajeto;
			reference = ref trajeto;
			array12[1] = trajeto;
			array12[2] = OleDbType.Char;
			array2 = array12;
			NewLateBinding.LateCall(instance11, null, "AddParameter", array12, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance12 = db;
			object[] array13 = new object[3] { "@instrucao", null, null };
			ref string instrucao = ref cabo.Instrucao;
			reference = ref instrucao;
			array13[1] = instrucao;
			array13[2] = OleDbType.Char;
			array2 = array13;
			NewLateBinding.LateCall(instance12, null, "AddParameter", array13, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance13 = db;
			object[] array14 = new object[3] { "@diametro", null, null };
			ref double diametro = ref cabo.Diametro;
			reference3 = ref diametro;
			array14[1] = diametro;
			array14[2] = OleDbType.Double;
			array2 = array14;
			NewLateBinding.LateCall(instance13, null, "AddParameter", array14, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference3 = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
			object instance14 = db;
			object[] array15 = new object[3] { "@grupo", null, null };
			ref string grupo = ref cabo.Grupo;
			reference = ref grupo;
			array15[1] = grupo;
			array15[2] = OleDbType.Char;
			array2 = array15;
			NewLateBinding.LateCall(instance14, null, "AddParameter", array15, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance15 = db;
			object[] array16 = new object[3] { "@cabos", null, null };
			ref int cabos = ref cabo.Cabos;
			reference2 = ref cabos;
			array16[1] = cabos;
			array16[2] = OleDbType.Integer;
			array2 = array16;
			NewLateBinding.LateCall(instance15, null, "AddParameter", array16, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance16 = db;
			object[] array17 = new object[3] { "@criador", null, null };
			ref string criador = ref cabo.criador;
			reference = ref criador;
			array17[1] = criador;
			array17[2] = OleDbType.Char;
			array2 = array17;
			NewLateBinding.LateCall(instance16, null, "AddParameter", array17, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance17 = db;
			object[] array18 = new object[3] { "@data", null, null };
			ref DateTime data = ref cabo.data;
			array18[1] = data;
			array18[2] = OleDbType.Date;
			array2 = array18;
			NewLateBinding.LateCall(instance17, null, "AddParameter", array18, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			data = (DateTime)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(DateTime));
			object instance18 = db;
			object[] array19 = new object[1] { text };
			array2 = array19;
			NewLateBinding.LateCall(instance18, null, "ExecuteNonQuery", array19, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}

	public void AdicionaItemVeias4(string revisao, DeclaracoesInterligacao.structureVeia veia)
	{
		try
		{
			string text = "";
			text = "Insert into Veias4(Revisao, Tag, Num_Veia, Nome_Veia, Uso, Funcao) VALUES(@revisao, @tag, @numVeia, @nomeVeia, @uso, @funcao)";
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
			object[] array3 = new object[3] { "@tag", null, null };
			ref string tag = ref veia.Tag;
			ref string reference = ref tag;
			array3[1] = tag;
			array3[2] = OleDbType.Char;
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance3 = db;
			object[] array4 = new object[3] { "@numVeia", null, null };
			ref int num_Veia = ref veia.Num_Veia;
			array4[1] = num_Veia;
			array4[2] = OleDbType.Integer;
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			num_Veia = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance4 = db;
			object[] array5 = new object[3] { "@nomeVeia", null, null };
			ref string nome_Veia = ref veia.Nome_Veia;
			reference = ref nome_Veia;
			array5[1] = nome_Veia;
			array5[2] = OleDbType.Char;
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance5 = db;
			object[] array6 = new object[3] { "@uso", null, null };
			ref bool uso = ref veia.Uso;
			array6[1] = uso;
			array6[2] = OleDbType.Boolean;
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			uso = (bool)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(bool));
			object instance6 = db;
			object[] array7 = new object[3] { "@funcao", null, null };
			ref string funcao = ref veia.Funcao;
			reference = ref funcao;
			array7[1] = funcao;
			array7[2] = OleDbType.Char;
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance7 = db;
			object[] array8 = new object[1] { text };
			array2 = array8;
			NewLateBinding.LateCall(instance7, null, "ExecuteNonQuery", array8, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}

	public void CarregaCabos4(string revisao, List<int> lPainelSel, ref DeclaracoesInterligacao.structureCabo[] mCabos, List<string> lCabos)
	{
		checked
		{
			try
			{
				string text = "SELECT Tag, Formacao, Funcao, Aterrar, Pn1, Pn2, Blindagem, Comprimento, Trajeto, Cabos, Instrucao FROM Cabos4 WHERE Revisao=@revisao ORDER BY Tag";
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
				object[] array3 = new object[1] { text };
				array2 = array3;
				object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (!(lCabos.Contains(Conversions.ToString(dataTable.Rows[i][0])) & (lPainelSel.Contains(Conversions.ToInteger(dataTable.Rows[i][4])) | lPainelSel.Contains(Conversions.ToInteger(dataTable.Rows[i][5])))))
					{
						continue;
					}
					int num2 = Information.UBound(mCabos) + 1;
					mCabos = (DeclaracoesInterligacao.structureCabo[])Utils.CopyArray(mCabos, new DeclaracoesInterligacao.structureCabo[num2 + 1]);
					if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][0])))
					{
						dataTable.Rows[i][0] = "";
					}
					if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][2])))
					{
						dataTable.Rows[i][2] = "";
					}
					if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][8])))
					{
						dataTable.Rows[i][8] = "";
					}
					mCabos[num2].Tag = Conversions.ToString(dataTable.Rows[i][0]);
					mCabos[num2].Formacao = Conversions.ToString(dataTable.Rows[i][1]);
					mCabos[num2].Blindagem = Conversions.ToBoolean(dataTable.Rows[i][6]);
					if (!Operators.ConditionalCompareObjectEqual(dataTable.Rows[i][6], true, TextCompare: true))
					{
						mCabos[num2].Formacao2 = Conversions.ToString(dataTable.Rows[i][1]);
						mCabos[num2].blindagem2 = "";
					}
					else
					{
						mCabos[num2].Formacao2 = Conversions.ToString(Operators.AddObject(Operators.AddObject("(", dataTable.Rows[i][1]), ")"));
						mCabos[num2].blindagem2 = "X";
					}
					mCabos[num2].Cabos = Conversions.ToInteger(dataTable.Rows[i][9]);
					if (Operators.ConditionalCompareObjectGreater(dataTable.Rows[i][9], 1, TextCompare: true))
					{
						mCabos[num2].Formacao2 = dataTable.Rows[i][9].ToString() + "x" + mCabos[num2].Formacao2;
					}
					mCabos[num2].Funcao = Conversions.ToString(dataTable.Rows[i][2]);
					mCabos[num2].Aterrar = Conversions.ToInteger(dataTable.Rows[i][3]);
					object left = dataTable.Rows[i][3];
					if (!Operators.ConditionalCompareObjectEqual(left, 0, TextCompare: true))
					{
						if (!Operators.ConditionalCompareObjectEqual(left, 1, TextCompare: true))
						{
							if (!Operators.ConditionalCompareObjectEqual(left, 2, TextCompare: true))
							{
								if (Operators.ConditionalCompareObjectEqual(left, 3, TextCompare: true))
								{
									mCabos[num2].AterrarOrigem = "X";
									mCabos[num2].AterrarDestino = "X";
								}
							}
							else
							{
								mCabos[num2].AterrarOrigem = "";
								mCabos[num2].AterrarDestino = "X";
							}
						}
						else
						{
							mCabos[num2].AterrarOrigem = "X";
							mCabos[num2].AterrarDestino = "";
						}
					}
					else
					{
						mCabos[num2].AterrarOrigem = "";
						mCabos[num2].AterrarDestino = "";
					}
					mCabos[num2].Pn1 = Conversions.ToInteger(dataTable.Rows[i][4]);
					mCabos[num2].Origem = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][4]));
					mCabos[num2].Pn2 = Conversions.ToInteger(dataTable.Rows[i][5]);
					mCabos[num2].Destino = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][5]));
					mCabos[num2].Comprimento = Conversions.ToDouble(dataTable.Rows[i][7]);
					mCabos[num2].Trajeto = Conversions.ToString(dataTable.Rows[i][8]);
					mCabos[num2].Instrucao = Conversions.ToString(dataTable.Rows[i][10]);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void CarregaCabosEnergisa(string revisao, List<int> lPainelSel, ref Relatorios_CabosEnergisaDWG.structureRelatCabosEnergisa[] mCabos, List<string> lCabos)
	{
		checked
		{
			try
			{
				string text = "SELECT Tag, Formacao, Funcao, Comprimento, Pn1, Pn2, Blindagem, Cabos, Instrucao FROM Cabos4 WHERE Revisao=@revisao ORDER BY Tag";
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
						if (lCabos.Contains(Conversions.ToString(dataTable.Rows[i][0])) & (lPainelSel.Contains(Conversions.ToInteger(dataTable.Rows[i][4])) | lPainelSel.Contains(Conversions.ToInteger(dataTable.Rows[i][5]))))
						{
							int num2 = Information.UBound(mCabos) + 1;
							mCabos = (Relatorios_CabosEnergisaDWG.structureRelatCabosEnergisa[])Utils.CopyArray(mCabos, new Relatorios_CabosEnergisaDWG.structureRelatCabosEnergisa[num2 + 1]);
							mCabos[num2].sVeiasUsadas = "0";
							mCabos[num2].sVeiasLivres = "0";
							if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][0])))
							{
								dataTable.Rows[i][0] = "";
							}
							if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][2])))
							{
								dataTable.Rows[i][2] = "";
							}
							mCabos[num2].Tag = Conversions.ToString(dataTable.Rows[i][0]);
							mCabos[num2].Formacao = Conversions.ToString(dataTable.Rows[i][1]);
							mCabos[num2].Formacao = Conversions.ToString(dataTable.Rows[i][1]);
							mCabos[num2].sBlindagem = DeclaracoesGeral.mMensagem[1, 20].ToString().ToUpper();
							if (!Operators.ConditionalCompareObjectEqual(dataTable.Rows[i][6], true, TextCompare: true))
							{
								mCabos[num2].Formacao = Conversions.ToString(dataTable.Rows[i][1]);
							}
							else
							{
								mCabos[num2].sBlindagem = DeclaracoesGeral.mMensagem[1, 19].ToString().ToUpper();
								mCabos[num2].Formacao = Conversions.ToString(Operators.AddObject(Operators.AddObject("(", dataTable.Rows[i][1]), ")"));
							}
							if (Operators.ConditionalCompareObjectGreater(dataTable.Rows[i][7], 1, TextCompare: true))
							{
								mCabos[num2].Formacao = dataTable.Rows[i][7].ToString() + "x" + mCabos[num2].Formacao;
							}
							mCabos[num2].Funcao = Conversions.ToString(dataTable.Rows[i][2]);
							mCabos[num2].iPn1 = Conversions.ToInteger(dataTable.Rows[i][4]);
							mCabos[num2].sPn1 = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][4]));
							mCabos[num2].iPn2 = Conversions.ToInteger(dataTable.Rows[i][5]);
							mCabos[num2].sPn2 = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][5]));
							mCabos[num2].Comprimento = Conversions.ToString(dataTable.Rows[i][3]);
							mCabos[num2].Instrucao = Conversions.ToString(dataTable.Rows[i][8]);
						}
					}
				}
				text = "SELECT Tag, Uso FROM Veias4 WHERE Revisao=@revisao and Num_Veia > 0 ";
				NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
				{
					"@revisao",
					revisao,
					OleDbType.Char
				}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
					int num4 = Information.UBound(mCabos);
					for (int k = 1; k <= num4; k++)
					{
						if (Operators.ConditionalCompareObjectEqual(dataTable2.Rows[j][0], mCabos[k].Tag, TextCompare: true))
						{
							if (!Operators.ConditionalCompareObjectEqual(dataTable2.Rows[j][1], true, TextCompare: true))
							{
								mCabos[k].sVeiasLivres = Conversions.ToString(Conversions.ToInteger(mCabos[k].sVeiasLivres) + 1);
							}
							else
							{
								mCabos[k].sVeiasUsadas = Conversions.ToString(Conversions.ToInteger(mCabos[k].sVeiasUsadas) + 1);
							}
							break;
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

	public void CarregaCabosEletroSul(string revisao, List<int> lPainelSel, ref DeclaracoesInterligacao.structureCabo[] mCabos, bool bRepeteCapo, List<string> lCabos)
	{
		List<string> list = new List<string>();
		bool flag = true;
		int num = 0;
		mCabos = new DeclaracoesInterligacao.structureCabo[1];
		checked
		{
			try
			{
				string text = "SELECT Tag, Formacao, Funcao, Aterrar, Pn1, Pn2, Blindagem, Comprimento, Trajeto, Cabos FROM Cabos4 WHERE Revisao=@revisao ORDER BY Tag";
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
				object[] array3 = new object[1] { text };
				array2 = array3;
				object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				foreach (int item in lPainelSel)
				{
					flag = true;
					int num2 = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num2; i++)
					{
						if (!Conversions.ToBoolean(Operators.AndObject(lCabos.Contains(Conversions.ToString(dataTable.Rows[i][0])), Operators.OrObject(Operators.CompareObjectEqual(item, dataTable.Rows[i][4], TextCompare: true), Operators.CompareObjectEqual(item, dataTable.Rows[i][5], TextCompare: true)))) || (!bRepeteCapo && list.Contains(Conversions.ToString(dataTable.Rows[i][0]))))
						{
							continue;
						}
						if (flag)
						{
							num = Information.UBound(mCabos) + 1;
							mCabos = (DeclaracoesInterligacao.structureCabo[])Utils.CopyArray(mCabos, new DeclaracoesInterligacao.structureCabo[num + 1]);
							mCabos[num].Tag = "";
							mCabos[num].Pn1 = item;
							mCabos[num].Origem = Dicionario.BuscaNomeDoPainel(item);
							mCabos[num].Pn2 = item;
							mCabos[num].Destino = Dicionario.BuscaNomeDoPainel(item);
							mCabos[num].Formacao = "";
							mCabos[num].Formacao2 = "";
							mCabos[num].blindagem2 = "";
							mCabos[num].Funcao = "";
							mCabos[num].Comprimento = 0.0;
							mCabos[num].Trajeto = "";
							flag = false;
						}
						num = Information.UBound(mCabos) + 1;
						mCabos = (DeclaracoesInterligacao.structureCabo[])Utils.CopyArray(mCabos, new DeclaracoesInterligacao.structureCabo[num + 1]);
						if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][0])))
						{
							dataTable.Rows[i][0] = "";
						}
						if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][2])))
						{
							dataTable.Rows[i][2] = "";
						}
						if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][8])))
						{
							dataTable.Rows[i][8] = "";
						}
						mCabos[num].Tag = Conversions.ToString(dataTable.Rows[i][0]);
						list.Add(Conversions.ToString(dataTable.Rows[i][0]));
						mCabos[num].Formacao = Conversions.ToString(dataTable.Rows[i][1]);
						mCabos[num].Blindagem = Conversions.ToBoolean(dataTable.Rows[i][6]);
						if (!Operators.ConditionalCompareObjectEqual(dataTable.Rows[i][6], true, TextCompare: true))
						{
							mCabos[num].Formacao2 = Conversions.ToString(dataTable.Rows[i][1]);
							mCabos[num].blindagem2 = "";
						}
						else
						{
							mCabos[num].Formacao2 = Conversions.ToString(Operators.AddObject(Operators.AddObject("(", dataTable.Rows[i][1]), ")"));
							mCabos[num].blindagem2 = "X";
						}
						mCabos[num].Cabos = Conversions.ToInteger(dataTable.Rows[i][9]);
						if (Operators.ConditionalCompareObjectGreater(dataTable.Rows[i][9], 1, TextCompare: true))
						{
							mCabos[num].Formacao2 = dataTable.Rows[i][9].ToString() + "x" + mCabos[num].Formacao2;
						}
						mCabos[num].Funcao = Conversions.ToString(dataTable.Rows[i][2]);
						mCabos[num].Aterrar = Conversions.ToInteger(dataTable.Rows[i][3]);
						object left = dataTable.Rows[i][3];
						if (!Operators.ConditionalCompareObjectEqual(left, 0, TextCompare: true))
						{
							if (!Operators.ConditionalCompareObjectEqual(left, 1, TextCompare: true))
							{
								if (!Operators.ConditionalCompareObjectEqual(left, 2, TextCompare: true))
								{
									if (Operators.ConditionalCompareObjectEqual(left, 3, TextCompare: true))
									{
										mCabos[num].AterrarOrigem = "X";
										mCabos[num].AterrarDestino = "X";
									}
								}
								else
								{
									mCabos[num].AterrarOrigem = "";
									mCabos[num].AterrarDestino = "X";
								}
							}
							else
							{
								mCabos[num].AterrarOrigem = "X";
								mCabos[num].AterrarDestino = "";
							}
						}
						else
						{
							mCabos[num].AterrarOrigem = "";
							mCabos[num].AterrarDestino = "";
						}
						if (!Operators.ConditionalCompareObjectEqual(item, dataTable.Rows[i][4], TextCompare: true))
						{
							mCabos[num].Pn2 = Conversions.ToInteger(dataTable.Rows[i][4]);
							mCabos[num].Destino = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][4]));
							mCabos[num].Pn1 = Conversions.ToInteger(dataTable.Rows[i][5]);
							mCabos[num].Origem = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][5]));
						}
						else
						{
							mCabos[num].Pn1 = Conversions.ToInteger(dataTable.Rows[i][4]);
							mCabos[num].Origem = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][4]));
							mCabos[num].Pn2 = Conversions.ToInteger(dataTable.Rows[i][5]);
							mCabos[num].Destino = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][5]));
						}
						mCabos[num].Comprimento = Conversions.ToDouble(dataTable.Rows[i][7]);
						mCabos[num].Trajeto = Conversions.ToString(dataTable.Rows[i][8]);
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

	public void CarregaCabosENEL(string revisao, List<int> lPainelSel, ref DeclaracoesInterligacao.structureCabo[] mCabos, bool bRepeteCapo, List<string> lCabos)
	{
		List<string> list = new List<string>();
		int num = 0;
		mCabos = new DeclaracoesInterligacao.structureCabo[1];
		checked
		{
			try
			{
				string text = "SELECT Tag, Formacao, Pn1, Pn2, Funcao, Blindagem, Comprimento FROM Cabos4 WHERE Revisao=@revisao ORDER BY Tag";
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
				object[] array3 = new object[1] { text };
				array2 = array3;
				object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				foreach (int item in lPainelSel)
				{
					int num2 = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num2; i++)
					{
						if (Conversions.ToBoolean(Operators.AndObject(lCabos.Contains(Conversions.ToString(dataTable.Rows[i][0])), Operators.OrObject(Operators.CompareObjectEqual(item, dataTable.Rows[i][2], TextCompare: true), Operators.CompareObjectEqual(item, dataTable.Rows[i][3], TextCompare: true)))) && (bRepeteCapo || !list.Contains(Conversions.ToString(dataTable.Rows[i][0]))))
						{
							num = Information.UBound(mCabos) + 1;
							mCabos = (DeclaracoesInterligacao.structureCabo[])Utils.CopyArray(mCabos, new DeclaracoesInterligacao.structureCabo[num + 1]);
							if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][0])))
							{
								dataTable.Rows[i][0] = "";
							}
							if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][4])))
							{
								dataTable.Rows[i][4] = "";
							}
							if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][6])))
							{
								dataTable.Rows[i][6] = 0;
							}
							mCabos[num].Tag = Conversions.ToString(dataTable.Rows[i][0]);
							list.Add(Conversions.ToString(dataTable.Rows[i][0]));
							if (!Operators.ConditionalCompareObjectEqual(dataTable.Rows[i][5], true, TextCompare: true))
							{
								mCabos[num].Formacao = Conversions.ToString(dataTable.Rows[i][1]);
								mCabos[num].Blindagem = false;
							}
							else
							{
								mCabos[num].Formacao = Conversions.ToString(Operators.AddObject(dataTable.Rows[i][1], "-BL"));
								mCabos[num].Blindagem = true;
							}
							mCabos[num].Cabos = 1;
							mCabos[num].Funcao = Conversions.ToString(dataTable.Rows[i][4]);
							if (!Operators.ConditionalCompareObjectEqual(item, dataTable.Rows[i][2], TextCompare: true))
							{
								mCabos[num].Pn2 = Conversions.ToInteger(dataTable.Rows[i][2]);
								mCabos[num].Destino = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][2]));
								mCabos[num].Pn1 = Conversions.ToInteger(dataTable.Rows[i][3]);
								mCabos[num].Origem = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][3]));
							}
							else
							{
								mCabos[num].Pn1 = Conversions.ToInteger(dataTable.Rows[i][2]);
								mCabos[num].Origem = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][2]));
								mCabos[num].Pn2 = Conversions.ToInteger(dataTable.Rows[i][3]);
								mCabos[num].Destino = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][3]));
							}
							mCabos[num].Comprimento = Conversions.ToDouble(dataTable.Rows[i][6]);
							mCabos[num].Trajeto = "";
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

	public void CarregaCabosTaesa(string revisao, List<int> lPainelSel, ref DeclaracoesInterligacao.structureCabo[] mCabos, bool bRepeteCapo, List<string> lCabos)
	{
		List<string> list = new List<string>();
		bool flag = true;
		int num = 0;
		mCabos = new DeclaracoesInterligacao.structureCabo[1];
		checked
		{
			try
			{
				string text = "SELECT Tag, Formacao, Funcao, Aterrar, Pn1, Pn2, Blindagem, Comprimento, Trajeto, Cabos FROM Cabos4 WHERE Revisao=@revisao ORDER BY Tag";
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
				object[] array3 = new object[1] { text };
				array2 = array3;
				object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				foreach (int item in lPainelSel)
				{
					flag = true;
					int num2 = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num2; i++)
					{
						if (!Conversions.ToBoolean(Operators.AndObject(lCabos.Contains(Conversions.ToString(dataTable.Rows[i][0])), Operators.OrObject(Operators.CompareObjectEqual(item, dataTable.Rows[i][4], TextCompare: true), Operators.CompareObjectEqual(item, dataTable.Rows[i][5], TextCompare: true)))) || (!bRepeteCapo && list.Contains(Conversions.ToString(dataTable.Rows[i][0]))))
						{
							continue;
						}
						if (flag)
						{
							num = Information.UBound(mCabos) + 1;
							mCabos = (DeclaracoesInterligacao.structureCabo[])Utils.CopyArray(mCabos, new DeclaracoesInterligacao.structureCabo[num + 1]);
							mCabos[num].Tag = "";
							mCabos[num].Pn1 = item;
							mCabos[num].Origem = Dicionario.BuscaNomeDoPainel(item);
							mCabos[num].Pn2 = item;
							mCabos[num].Destino = Dicionario.BuscaNomeDoPainel(item);
							mCabos[num].Formacao = "";
							mCabos[num].Formacao2 = "";
							mCabos[num].blindagem2 = "";
							mCabos[num].Funcao = "";
							mCabos[num].Comprimento = 0.0;
							mCabos[num].Trajeto = "";
							flag = false;
						}
						num = Information.UBound(mCabos) + 1;
						mCabos = (DeclaracoesInterligacao.structureCabo[])Utils.CopyArray(mCabos, new DeclaracoesInterligacao.structureCabo[num + 1]);
						if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][0])))
						{
							dataTable.Rows[i][0] = "";
						}
						if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][2])))
						{
							dataTable.Rows[i][2] = "";
						}
						if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][8])))
						{
							dataTable.Rows[i][8] = "";
						}
						mCabos[num].Tag = Conversions.ToString(dataTable.Rows[i][0]);
						list.Add(Conversions.ToString(dataTable.Rows[i][0]));
						mCabos[num].Formacao = Conversions.ToString(dataTable.Rows[i][1]);
						mCabos[num].Blindagem = Conversions.ToBoolean(dataTable.Rows[i][6]);
						if (!Operators.ConditionalCompareObjectEqual(dataTable.Rows[i][6], true, TextCompare: true))
						{
							mCabos[num].Formacao2 = Conversions.ToString(dataTable.Rows[i][1]);
							mCabos[num].blindagem2 = "";
						}
						else
						{
							mCabos[num].Formacao2 = Conversions.ToString(Operators.AddObject(Operators.AddObject("(", dataTable.Rows[i][1]), ")"));
							mCabos[num].blindagem2 = "X";
						}
						mCabos[num].Cabos = Conversions.ToInteger(dataTable.Rows[i][9]);
						if (Operators.ConditionalCompareObjectGreater(dataTable.Rows[i][9], 1, TextCompare: true))
						{
							mCabos[num].Formacao2 = dataTable.Rows[i][9].ToString() + "x" + mCabos[num].Formacao2;
						}
						mCabos[num].Funcao = Conversions.ToString(dataTable.Rows[i][2]);
						mCabos[num].Aterrar = Conversions.ToInteger(dataTable.Rows[i][3]);
						object left = dataTable.Rows[i][3];
						if (!Operators.ConditionalCompareObjectEqual(left, 0, TextCompare: true))
						{
							if (!Operators.ConditionalCompareObjectEqual(left, 1, TextCompare: true))
							{
								if (!Operators.ConditionalCompareObjectEqual(left, 2, TextCompare: true))
								{
									if (Operators.ConditionalCompareObjectEqual(left, 3, TextCompare: true))
									{
										mCabos[num].AterrarOrigem = "X";
										mCabos[num].AterrarDestino = "X";
									}
								}
								else
								{
									mCabos[num].AterrarOrigem = "";
									mCabos[num].AterrarDestino = "X";
								}
							}
							else
							{
								mCabos[num].AterrarOrigem = "X";
								mCabos[num].AterrarDestino = "";
							}
						}
						else
						{
							mCabos[num].AterrarOrigem = "";
							mCabos[num].AterrarDestino = "";
						}
						if (!Operators.ConditionalCompareObjectEqual(item, dataTable.Rows[i][4], TextCompare: true))
						{
							mCabos[num].Pn2 = Conversions.ToInteger(dataTable.Rows[i][4]);
							mCabos[num].Destino = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][4]));
							mCabos[num].Pn1 = Conversions.ToInteger(dataTable.Rows[i][5]);
							mCabos[num].Origem = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][5]));
						}
						else
						{
							mCabos[num].Pn1 = Conversions.ToInteger(dataTable.Rows[i][4]);
							mCabos[num].Origem = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][4]));
							mCabos[num].Pn2 = Conversions.ToInteger(dataTable.Rows[i][5]);
							mCabos[num].Destino = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][5]));
						}
						mCabos[num].Comprimento = Conversions.ToDouble(dataTable.Rows[i][7]);
						mCabos[num].Trajeto = Conversions.ToString(dataTable.Rows[i][8]);
						List<string> list2 = new List<string>();
						List<string> list3 = new List<string>();
						string text2 = "SELECT Documento1, Documento2, Pagina1, Pagina2 FROM Interligacao4 WHERE Revisao=@revisao  AND Tag_Cabo=@tag_cabo ORDER BY Tag_Cabo";
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@revisao",
							revisao,
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						object instance3 = db;
						object[] array4 = new object[3] { "@tag_cabo", null, null };
						ref string tag = ref mCabos[num].Tag;
						array4[1] = tag;
						array4[2] = OleDbType.Char;
						array2 = array4;
						NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						tag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text2 }, null, null, new bool[1] { true });
						text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
						DataTable dataTable2 = (DataTable)obj;
						if (dataTable2.Rows.Count > 0)
						{
							int num3 = dataTable2.Rows.Count - 1;
							for (int j = 0; j <= num3; j++)
							{
								if (!list2.Contains(Conversions.ToString(dataTable2.Rows[j][0])))
								{
									list2.Add(Conversions.ToString(dataTable2.Rows[j][0]));
								}
								if (!list2.Contains(Conversions.ToString(dataTable2.Rows[j][1])))
								{
									list2.Add(Conversions.ToString(dataTable2.Rows[j][1]));
								}
								if (!list3.Contains(Conversions.ToString(dataTable2.Rows[j][2])))
								{
									list3.Add(Conversions.ToString(dataTable2.Rows[j][2]));
								}
								if (!list3.Contains(Conversions.ToString(dataTable2.Rows[j][3])))
								{
									list3.Add(Conversions.ToString(dataTable2.Rows[j][3]));
								}
							}
							list2.Sort();
							list3.Sort();
						}
						string text3 = "";
						foreach (string item2 in list2)
						{
							text3 = ((Operators.CompareString(text3, "", TextCompare: true) == 0) ? item2 : (text3 + ", " + item2));
						}
						string text4 = "";
						foreach (string item3 in list3)
						{
							text4 = ((Operators.CompareString(text4, "", TextCompare: true) == 0) ? item3 : (text4 + ", " + item3));
						}
						mCabos[num].sDocumentos = text3;
						mCabos[num].sPaginas = text4;
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

	public void CarregaReguas(string revisao, int painel, ref DeclaracoesInterligacao.structureRI[] mReguas)
	{
		checked
		{
			try
			{
				string text = "SELECT DISTINCT Regua, DWG FROM Bornes4I WHERE Revisao=@revisao AND Painel=@painel AND Tipo<2";
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
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						mReguas = (DeclaracoesInterligacao.structureRI[])Utils.CopyArray(mReguas, new DeclaracoesInterligacao.structureRI[mReguas.Length + 1]);
						mReguas[mReguas.Length - 1].Tag = Conversions.ToString(dataTable.Rows[i][0]);
						mReguas[mReguas.Length - 1].NRegua = "";
						mReguas[mReguas.Length - 1].Tipo = "B";
						mReguas[mReguas.Length - 1].IndexModelo = -1;
						mReguas[mReguas.Length - 1].DWG = Conversions.ToInteger(dataTable.Rows[i][1]);
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

	public void CarregaReguasPortas(string revisao, int painel, ref DeclaracoesInterligacao.structureRI[] mReguas)
	{
		checked
		{
			try
			{
				string text = "SELECT DISTINCT Tag1, NRegua1, IndexModelo1, DWG1 FROM Interligacao4 WHERE Revisao=@revisao AND Painel1=@painel AND Nregua1<>'' AND (TipoBorne1=-1 OR TipoBorne1=-2)";
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
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						object objectValue = RuntimeHelpers.GetObjectValue(dataTable.Rows[i][0]);
						string text2 = Conversions.ToString(dataTable.Rows[i][1]);
						string value = Conversions.ToString(dataTable.Rows[i][2]);
						int dWG = Conversions.ToInteger(dataTable.Rows[i][3]);
						bool flag = false;
						int num2 = Information.UBound(mReguas);
						for (int j = 1; j <= num2; j++)
						{
							if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.CompareString(mReguas[j].Tipo, "E", TextCompare: true) == 0, Operators.CompareObjectEqual(mReguas[j].Tag, objectValue, TextCompare: true)), Operators.CompareString(mReguas[j].NRegua, text2, TextCompare: true) == 0)))
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							mReguas = (DeclaracoesInterligacao.structureRI[])Utils.CopyArray(mReguas, new DeclaracoesInterligacao.structureRI[mReguas.Length + 1]);
							mReguas[mReguas.Length - 1].Tag = Conversions.ToString(objectValue);
							mReguas[mReguas.Length - 1].NRegua = text2;
							mReguas[mReguas.Length - 1].Tipo = "E";
							mReguas[mReguas.Length - 1].IndexModelo = Conversions.ToInteger(value);
							mReguas[mReguas.Length - 1].DWG = dWG;
						}
					}
				}
				text = "SELECT DISTINCT Tag2, NRegua2, IndexModelo2, DWG2 FROM Interligacao4 WHERE Revisao=@revisao AND Painel2=@painel AND Nregua2<>'' AND (TipoBorne2=-1 OR TipoBorne2=-2)";
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
				obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				dataTable = (DataTable)obj;
				if (dataTable.Rows.Count > 0)
				{
					int num3 = dataTable.Rows.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						object objectValue2 = RuntimeHelpers.GetObjectValue(dataTable.Rows[k][0]);
						string text3 = Conversions.ToString(dataTable.Rows[k][1]);
						string value2 = Conversions.ToString(dataTable.Rows[k][2]);
						int dWG2 = Conversions.ToInteger(dataTable.Rows[k][3]);
						bool flag2 = false;
						int num4 = Information.UBound(mReguas);
						for (int l = 1; l <= num4; l++)
						{
							if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.CompareString(mReguas[l].Tipo, "E", TextCompare: true) == 0, Operators.CompareObjectEqual(mReguas[l].Tag, objectValue2, TextCompare: true)), Operators.CompareString(mReguas[l].NRegua, text3, TextCompare: true) == 0)))
							{
								flag2 = true;
								break;
							}
						}
						if (!flag2)
						{
							mReguas = (DeclaracoesInterligacao.structureRI[])Utils.CopyArray(mReguas, new DeclaracoesInterligacao.structureRI[mReguas.Length + 1]);
							mReguas[mReguas.Length - 1].Tag = Conversions.ToString(objectValue2);
							mReguas[mReguas.Length - 1].NRegua = text3;
							mReguas[mReguas.Length - 1].Tipo = "E";
							mReguas[mReguas.Length - 1].IndexModelo = Conversions.ToInteger(value2);
							mReguas[mReguas.Length - 1].DWG = dWG2;
						}
					}
				}
				text = "SELECT DISTINCT Tag, NRegua, IndexModelo, DWG FROM Jumper4 WHERE Tipo='E' AND Revisao=@revisao AND Painel=@painel AND NRegua<>''";
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
				obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				dataTable = (DataTable)obj;
				if (dataTable.Rows.Count > 0)
				{
					int num5 = dataTable.Rows.Count - 1;
					for (int m = 0; m <= num5; m++)
					{
						string text4 = Conversions.ToString(dataTable.Rows[m][0]);
						string text5 = Conversions.ToString(dataTable.Rows[m][1]);
						string value3 = Conversions.ToString(dataTable.Rows[m][2]);
						int dWG3 = Conversions.ToInteger(dataTable.Rows[m][3]);
						bool flag3 = false;
						int num6 = Information.UBound(mReguas);
						for (int n = 1; n <= num6; n++)
						{
							if ((Operators.CompareString(mReguas[n].Tipo, "E", TextCompare: true) == 0) & (Operators.CompareString(mReguas[n].Tag, text4, TextCompare: true) == 0) & (Operators.CompareString(mReguas[n].NRegua, text5, TextCompare: true) == 0))
							{
								flag3 = true;
								break;
							}
						}
						if (!flag3)
						{
							mReguas = (DeclaracoesInterligacao.structureRI[])Utils.CopyArray(mReguas, new DeclaracoesInterligacao.structureRI[mReguas.Length + 1]);
							mReguas[mReguas.Length - 1].Tag = text4;
							mReguas[mReguas.Length - 1].NRegua = text5;
							mReguas[mReguas.Length - 1].Tipo = "E";
							mReguas[mReguas.Length - 1].IndexModelo = Conversions.ToInteger(value3);
							mReguas[mReguas.Length - 1].DWG = dWG3;
						}
					}
				}
				int num7 = Information.UBound(mReguas);
				for (int num8 = 1; num8 <= num7; num8++)
				{
					text = "SELECT DISTINCT Regua FROM Portas4I WHERE Revisao=@revisao AND DWG=@dwg AND IndexModelo=@indexModelo and Regua<>@regua and Tipo='B'";
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@revisao",
						revisao,
						OleDbType.Char
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance4 = db;
					object[] array5 = new object[3] { "@dwg", null, null };
					ref int dWG4 = ref mReguas[num8].DWG;
					ref int reference = ref dWG4;
					array5[1] = dWG4;
					array5[2] = OleDbType.Integer;
					array2 = array5;
					NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					object instance5 = db;
					object[] array6 = new object[3] { "@indexModelo", null, null };
					ref int indexModelo = ref mReguas[num8].IndexModelo;
					reference = ref indexModelo;
					array6[1] = indexModelo;
					array6[2] = OleDbType.Integer;
					array2 = array6;
					NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					object instance6 = db;
					object[] array7 = new object[3] { "@regua", null, null };
					ref string nRegua = ref mReguas[num8].NRegua;
					array7[1] = nRegua;
					array7[2] = OleDbType.Char;
					array2 = array7;
					NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					nRegua = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					dataTable = (DataTable)obj;
					if (dataTable.Rows.Count <= 0)
					{
						continue;
					}
					int num9 = dataTable.Rows.Count - 1;
					for (int num10 = 0; num10 <= num9; num10++)
					{
						bool flag4 = false;
						int num11 = Information.UBound(mReguas);
						for (int num12 = 1; num12 <= num11; num12++)
						{
							if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareString(mReguas[num12].Tipo, "E", TextCompare: true) == 0, Operators.CompareObjectEqual(mReguas[num12].NRegua, dataTable.Rows[num10][0], TextCompare: true))))
							{
								flag4 = true;
								break;
							}
						}
						if (!flag4)
						{
							mReguas = (DeclaracoesInterligacao.structureRI[])Utils.CopyArray(mReguas, new DeclaracoesInterligacao.structureRI[mReguas.Length + 1]);
							mReguas[mReguas.Length - 1].Tag = mReguas[num8].Tag;
							mReguas[mReguas.Length - 1].NRegua = Conversions.ToString(dataTable.Rows[num10][0]);
							mReguas[mReguas.Length - 1].Tipo = "E";
							mReguas[mReguas.Length - 1].IndexModelo = mReguas[num8].IndexModelo;
							mReguas[mReguas.Length - 1].DWG = mReguas[num8].DWG;
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

	public void CarregaBornesReguas(string revisao, int painel, ref DeclaracoesInterligacao.structureRI[] mReguas, bool bCadastro)
	{
		checked
		{
			try
			{
				int num = Information.UBound(mReguas);
				for (int i = 1; i <= num; i++)
				{
					object[] array;
					object obj;
					if (Operators.CompareString(mReguas[i].Tipo, "B", TextCompare: true) != 0)
					{
						if (Operators.CompareString(mReguas[i].Tipo, "E", TextCompare: true) != 0)
						{
							continue;
						}
						string text = "";
						text = (bCadastro ? "SELECT Borne FROM Portas4I WHERE Revisao=@revisao AND DWG=@dwg AND IndexModelo=@indexModelo AND Regua=@regua AND Tipo='B' ORDER BY Indice" : "SELECT Borne FROM Portas4I WHERE Revisao=@revisao AND DWG=@dwg AND IndexModelo=@indexModelo AND Regua=@regua AND Tipo='B' ORDER BY TerminalNum ASC, Borne");
						NewLateBinding.LateCall(db, null, "AddParameter", array = new object[3]
						{
							"@revisao",
							revisao,
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(string));
						object instance = db;
						object[] array2 = new object[3] { "@dwg", null, null };
						ref int dWG = ref mReguas[i].DWG;
						ref int reference = ref dWG;
						array2[1] = dWG;
						array2[2] = OleDbType.Integer;
						array = array2;
						NewLateBinding.LateCall(instance, null, "AddParameter", array2, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
						object instance2 = db;
						object[] array3 = new object[3] { "@indexModelo", null, null };
						ref int indexModelo = ref mReguas[i].IndexModelo;
						reference = ref indexModelo;
						array3[1] = indexModelo;
						array3[2] = OleDbType.Integer;
						array = array3;
						NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
						object instance3 = db;
						object[] array4 = new object[3] { "@regua", null, null };
						ref string nRegua = ref mReguas[i].NRegua;
						array4[1] = nRegua;
						array4[2] = OleDbType.Char;
						array = array4;
						NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						nRegua = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(string));
						obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array = new object[1] { text }, null, null, new bool[1] { true });
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
						DataTable dataTable = (DataTable)obj;
						string text2 = "";
						List<string> list = new List<string>();
						DeclaracoesInterligacao.borneRI[] array5 = new DeclaracoesInterligacao.borneRI[1];
						if (dataTable.Rows.Count <= 0)
						{
							continue;
						}
						int num2 = 0;
						int num3 = dataTable.Rows.Count - 1;
						for (int j = 0; j <= num3; j++)
						{
							text2 = Conversions.ToString(dataTable.Rows[j][0]);
							if (!list.Contains(text2))
							{
								list.Add(text2);
								num2++;
								int num4 = Information.UBound(array5) + 1;
								array5 = (DeclaracoesInterligacao.borneRI[])Utils.CopyArray(array5, new DeclaracoesInterligacao.borneRI[num4 + 1]);
								array5[num4].Borne = text2;
								array5[num4].Ordem = num2;
								array5[num4].TipoBorne = 0;
								array5[num4].Pagina = "";
							}
						}
						mReguas[i].Bornes = array5;
						continue;
					}
					string tag = mReguas[i].Tag;
					string text3 = "SELECT Borne, Ordem, Tipo, Pagina FROM Bornes4I WHERE Revisao=@revisao AND Painel=@painel AND Regua=@regua AND Tipo<2 ORDER BY Ordem DESC";
					object instance4 = db;
					object[] array6 = new object[3]
					{
						"@revisao",
						revisao,
						OleDbType.Char
					};
					array = array6;
					NewLateBinding.LateCall(instance4, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(string));
					object instance5 = db;
					object[] array7 = new object[3]
					{
						"@painel",
						painel,
						OleDbType.Integer
					};
					array = array7;
					NewLateBinding.LateCall(instance5, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
					object instance6 = db;
					object[] array8 = new object[3]
					{
						"@regua",
						tag,
						OleDbType.Char
					};
					array = array8;
					NewLateBinding.LateCall(instance6, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					tag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(string));
					object instance7 = db;
					object[] array9 = new object[1] { text3 };
					array = array9;
					obj = NewLateBinding.LateGet(instance7, null, "ExecuteReader", array9, null, null, new bool[1] { true });
					text3 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
					DataTable dataTable2 = (DataTable)obj;
					string text4 = "";
					List<string> list2 = new List<string>();
					DeclaracoesInterligacao.borneRI[] array10 = new DeclaracoesInterligacao.borneRI[1];
					if (dataTable2.Rows.Count <= 0)
					{
						continue;
					}
					int num5 = dataTable2.Rows.Count - 1;
					for (int k = 0; k <= num5; k++)
					{
						text4 = Conversions.ToString(dataTable2.Rows[k][0]);
						if (!list2.Contains(text4))
						{
							list2.Add(text4);
							int num6 = Information.UBound(array10) + 1;
							array10 = (DeclaracoesInterligacao.borneRI[])Utils.CopyArray(array10, new DeclaracoesInterligacao.borneRI[num6 + 1]);
							array10[num6].Borne = text4;
							array10[num6].Ordem = Conversions.ToInteger(dataTable2.Rows[k][1]);
							array10[num6].TipoBorne = Conversions.ToInteger(dataTable2.Rows[k][2]);
							array10[num6].Pagina = Conversions.ToString(dataTable2.Rows[k][3]);
						}
					}
					Array.Reverse(array10, 1, Information.UBound(array10));
					mReguas[i].Bornes = array10;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void CarregaCabosNosBornesRI(string revisao, int painel, ref DeclaracoesInterligacao.structureRI[] mReguas, ref ProgressBar ProgressBar1, int padraoDI)
	{
		checked
		{
			try
			{
				List<string> list = new List<string>();
				int num = Information.UBound(mReguas);
				for (int i = 1; i <= num; i++)
				{
					if (Information.IsNothing(mReguas[i].Bornes))
					{
						continue;
					}
					int num2 = Information.UBound(mReguas[i].Bornes);
					for (int j = 1; j <= num2; j++)
					{
						ProgressBar1.PerformStep();
						string text = "";
						DeclaracoesInterligacao.caboRI[] array = new DeclaracoesInterligacao.caboRI[1];
						text = "SELECT Tag_Cabo, Num_Veia, Nome_Veia, Painel2, Documento2, Tag2, NRegua2, Terminal2, Pagina2, Posicao2, Documento1, Pagina1, DWG FROM Interligacao4 WHERE Revisao=@revisao AND Painel1=@painel AND Tag1=@tag AND NRegua1=@nRegua AND Terminal1=@terminal ORDER BY Tag_Cabo";
						object[] array2;
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
						object instance = db;
						object[] array3 = new object[3] { "@tag", null, null };
						ref string tag = ref mReguas[i].Tag;
						ref string reference = ref tag;
						array3[1] = tag;
						array3[2] = OleDbType.Char;
						array2 = array3;
						NewLateBinding.LateCall(instance, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						object instance2 = db;
						object[] array4 = new object[3] { "@nRegua", null, null };
						ref string nRegua = ref mReguas[i].NRegua;
						reference = ref nRegua;
						array4[1] = nRegua;
						array4[2] = OleDbType.Char;
						array2 = array4;
						NewLateBinding.LateCall(instance2, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						object instance3 = db;
						object[] array5 = new object[3] { "@terminal", null, null };
						ref string borne = ref mReguas[i].Bornes[j].Borne;
						reference = ref borne;
						array5[1] = borne;
						array5[2] = OleDbType.Char;
						array2 = array5;
						NewLateBinding.LateCall(instance3, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						object obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
						DataTable dataTable = (DataTable)obj;
						int num3 = 0;
						if (dataTable.Rows.Count > 0)
						{
							int num4 = dataTable.Rows.Count - 1;
							for (int k = 0; k <= num4; k++)
							{
								int num5 = Information.UBound(array) + 1;
								array = (DeclaracoesInterligacao.caboRI[])Utils.CopyArray(array, new DeclaracoesInterligacao.caboRI[num5 + 1]);
								array[num5].Tag_Cabo = Conversions.ToString(dataTable.Rows[k][0]);
								array[num5].Veia = Conversions.ToInteger(dataTable.Rows[k][1]);
								array[num5].NomeVeia = Conversions.ToString(dataTable.Rows[k][2]);
								array[num5].iPainelDest = Conversions.ToInteger(dataTable.Rows[k][3]);
								array[num5].DocDest = Conversions.ToString(dataTable.Rows[k][4]);
								array[num5].TagDest = Conversions.ToString(dataTable.Rows[k][5]);
								array[num5].NReguaDest = Conversions.ToString(dataTable.Rows[k][6]);
								array[num5].BorneDest = Conversions.ToString(dataTable.Rows[k][7]);
								array[num5].PaginaDest = Conversions.ToString(dataTable.Rows[k][8]);
								array[num5].PosicaoDest = Conversions.ToString(dataTable.Rows[k][9]);
								array[num5].DocOrigem = Conversions.ToString(dataTable.Rows[k][10]);
								array[num5].PaginaOrigem = Conversions.ToString(dataTable.Rows[k][11]);
								num3 = Conversions.ToInteger(dataTable.Rows[k][12]);
								if (array[num5].Veia <= 0)
								{
									array[num5].sPainelDest = "";
								}
								else
								{
									array[num5].sPainelDest = Dicionario.BuscaNomeDoPainel(array[num5].iPainelDest);
								}
								string text2 = "SELECT Formacao, Funcao, Blindagem, Cabos, Pn1, Pn2, Aterrar, Trajeto FROM Cabos4 WHERE Revisao=@revisao AND Tag=@tag";
								NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
								{
									"@revisao",
									revisao,
									OleDbType.Char
								}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
								revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
								object instance4 = db;
								object[] array6 = new object[3] { "@tag", null, null };
								ref string tag_Cabo = ref array[num5].Tag_Cabo;
								reference = ref tag_Cabo;
								array6[1] = tag_Cabo;
								array6[2] = OleDbType.Char;
								array2 = array6;
								NewLateBinding.LateCall(instance4, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
								reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
								obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text2 }, null, null, new bool[1] { true });
								text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
								DataTable dataTable2 = (DataTable)obj;
								if (dataTable2.Rows.Count != 1)
								{
									string text3 = "SELECT Nome FROM DWG WHERE Indice=@indice";
									object instance5 = db;
									object[] array7 = new object[3]
									{
										"@indice",
										num3,
										OleDbType.Integer
									};
									array2 = array7;
									NewLateBinding.LateCall(instance5, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
									num3 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
									object instance6 = db;
									object[] array8 = new object[1] { text3 };
									array2 = array8;
									obj = NewLateBinding.LateGet(instance6, null, "ExecuteReader", array8, null, null, new bool[1] { true });
									text3 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
									DataTable dataTable3 = (DataTable)obj;
									if (dataTable3.Rows.Count == 1 && !list.Contains(Conversions.ToString(dataTable3.Rows[0][0])))
									{
										list.Add(Conversions.ToString(dataTable3.Rows[0][0]));
									}
								}
								else
								{
									array[num5].Formacao = Conversions.ToString(dataTable2.Rows[0][0]);
									array[num5].Funcao = Conversions.ToString(dataTable2.Rows[0][1]);
									array[num5].Blindagem = Conversions.ToBoolean(dataTable2.Rows[0][2]);
									array[num5].Cabos = Conversions.ToInteger(dataTable2.Rows[0][3]);
									int num6 = Conversions.ToInteger(dataTable2.Rows[0][4]);
									int num7 = Conversions.ToInteger(dataTable2.Rows[0][5]);
									int num8 = Conversions.ToInteger(dataTable2.Rows[0][6]);
									array[num5].Trajetos = Conversions.ToString(dataTable2.Rows[0][7]);
									switch (num8)
									{
									case 3:
										array[num5].bAterrar = true;
										break;
									case 0:
										array[num5].bAterrar = false;
										break;
									case 1:
										if (num6 != painel)
										{
											array[num5].bAterrar = false;
										}
										else
										{
											array[num5].bAterrar = true;
										}
										break;
									case 2:
										if (num7 != painel)
										{
											array[num5].bAterrar = false;
										}
										else
										{
											array[num5].bAterrar = true;
										}
										break;
									}
								}
								if (!((padraoDI == 2) | (padraoDI == 10)))
								{
									array[num5].FuncaoVeia = "";
									continue;
								}
								string text4 = "SELECT Funcao FROM Veias4 WHERE Revisao=@revisao AND Tag=@tag AND Num_Veia=@num_veia";
								object instance7 = db;
								object[] array9 = new object[3]
								{
									"@revisao",
									revisao,
									OleDbType.Char
								};
								array2 = array9;
								NewLateBinding.LateCall(instance7, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
								revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
								object instance8 = db;
								object[] array10 = new object[3] { "@tag", null, null };
								ref string tag_Cabo2 = ref array[num5].Tag_Cabo;
								reference = ref tag_Cabo2;
								array10[1] = tag_Cabo2;
								array10[2] = OleDbType.Char;
								array2 = array10;
								NewLateBinding.LateCall(instance8, null, "AddParameter", array10, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
								reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
								object instance9 = db;
								object[] array11 = new object[3] { "@num_veia", null, null };
								ref int veia = ref array[num5].Veia;
								ref int reference2 = ref veia;
								array11[1] = veia;
								array11[2] = OleDbType.Integer;
								array2 = array11;
								NewLateBinding.LateCall(instance9, null, "AddParameter", array11, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
								reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
								object instance10 = db;
								object[] array12 = new object[1] { text4 };
								array2 = array12;
								obj = NewLateBinding.LateGet(instance10, null, "ExecuteReader", array12, null, null, new bool[1] { true });
								text4 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
								DataTable dataTable4 = (DataTable)obj;
								if (dataTable4.Rows.Count == 1)
								{
									array[num5].FuncaoVeia = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable4.Rows[0][0]));
								}
							}
						}
						text = "SELECT Tag_Cabo, Num_Veia, Nome_Veia, Painel1, Documento1, Tag1, NRegua1, Terminal1, Pagina1, Posicao1, Documento2, Pagina2, DWG FROM Interligacao4 WHERE Revisao=@revisao AND Painel2=@painel AND Tag2=@tag AND NRegua2=@nRegua AND Terminal2=@terminal ORDER BY Tag_Cabo";
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
						object instance11 = db;
						object[] array13 = new object[3] { "@tag", null, null };
						ref string tag2 = ref mReguas[i].Tag;
						reference = ref tag2;
						array13[1] = tag2;
						array13[2] = OleDbType.Char;
						array2 = array13;
						NewLateBinding.LateCall(instance11, null, "AddParameter", array13, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						object instance12 = db;
						object[] array14 = new object[3] { "@nRegua", null, null };
						ref string nRegua2 = ref mReguas[i].NRegua;
						reference = ref nRegua2;
						array14[1] = nRegua2;
						array14[2] = OleDbType.Char;
						array2 = array14;
						NewLateBinding.LateCall(instance12, null, "AddParameter", array14, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						object instance13 = db;
						object[] array15 = new object[3] { "@terminal", null, null };
						ref string borne2 = ref mReguas[i].Bornes[j].Borne;
						reference = ref borne2;
						array15[1] = borne2;
						array15[2] = OleDbType.Char;
						array2 = array15;
						NewLateBinding.LateCall(instance13, null, "AddParameter", array15, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
						dataTable = (DataTable)obj;
						if (dataTable.Rows.Count > 0)
						{
							int num9 = dataTable.Rows.Count - 1;
							for (int l = 0; l <= num9; l++)
							{
								int num10 = Information.UBound(array) + 1;
								array = (DeclaracoesInterligacao.caboRI[])Utils.CopyArray(array, new DeclaracoesInterligacao.caboRI[num10 + 1]);
								array[num10].Tag_Cabo = Conversions.ToString(dataTable.Rows[l][0]);
								array[num10].Veia = Conversions.ToInteger(dataTable.Rows[l][1]);
								array[num10].NomeVeia = Conversions.ToString(dataTable.Rows[l][2]);
								array[num10].iPainelDest = Conversions.ToInteger(dataTable.Rows[l][3]);
								array[num10].DocDest = Conversions.ToString(dataTable.Rows[l][4]);
								array[num10].TagDest = Conversions.ToString(dataTable.Rows[l][5]);
								array[num10].NReguaDest = Conversions.ToString(dataTable.Rows[l][6]);
								array[num10].BorneDest = Conversions.ToString(dataTable.Rows[l][7]);
								array[num10].PaginaDest = Conversions.ToString(dataTable.Rows[l][8]);
								array[num10].PosicaoDest = Conversions.ToString(dataTable.Rows[l][9]);
								array[num10].DocOrigem = Conversions.ToString(dataTable.Rows[l][10]);
								array[num10].PaginaOrigem = Conversions.ToString(dataTable.Rows[l][11]);
								num3 = Conversions.ToInteger(dataTable.Rows[l][12]);
								if (array[num10].Veia <= 0)
								{
									array[num10].sPainelDest = "";
								}
								else
								{
									array[num10].sPainelDest = Dicionario.BuscaNomeDoPainel(array[num10].iPainelDest);
								}
								string text5 = "SELECT Formacao, Funcao, Blindagem, Cabos, Pn1, Pn2, Aterrar, Trajeto FROM Cabos4 WHERE Revisao=@revisao AND Tag=@tag";
								NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
								{
									"@revisao",
									revisao,
									OleDbType.Char
								}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
								revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
								object instance14 = db;
								object[] array16 = new object[3] { "@tag", null, null };
								ref string tag_Cabo3 = ref array[num10].Tag_Cabo;
								reference = ref tag_Cabo3;
								array16[1] = tag_Cabo3;
								array16[2] = OleDbType.Char;
								array2 = array16;
								NewLateBinding.LateCall(instance14, null, "AddParameter", array16, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
								reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
								obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text5 }, null, null, new bool[1] { true });
								text5 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
								DataTable dataTable5 = (DataTable)obj;
								if (dataTable5.Rows.Count != 1)
								{
									string text6 = "SELECT Nome FROM DWG WHERE Indice=@indice";
									object instance15 = db;
									object[] array17 = new object[3]
									{
										"@indice",
										num3,
										OleDbType.Integer
									};
									array2 = array17;
									NewLateBinding.LateCall(instance15, null, "AddParameter", array17, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
									num3 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
									object instance16 = db;
									object[] array18 = new object[1] { text6 };
									array2 = array18;
									obj = NewLateBinding.LateGet(instance16, null, "ExecuteReader", array18, null, null, new bool[1] { true });
									text6 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
									DataTable dataTable6 = (DataTable)obj;
									if (dataTable6.Rows.Count == 1 && !list.Contains(Conversions.ToString(dataTable6.Rows[0][0])))
									{
										list.Add(Conversions.ToString(dataTable6.Rows[0][0]));
									}
								}
								else
								{
									array[num10].Formacao = Conversions.ToString(dataTable5.Rows[0][0]);
									array[num10].Funcao = Conversions.ToString(dataTable5.Rows[0][1]);
									array[num10].Blindagem = Conversions.ToBoolean(dataTable5.Rows[0][2]);
									array[num10].Cabos = Conversions.ToInteger(dataTable5.Rows[0][3]);
									int num11 = Conversions.ToInteger(dataTable5.Rows[0][4]);
									int num12 = Conversions.ToInteger(dataTable5.Rows[0][5]);
									int num13 = Conversions.ToInteger(dataTable5.Rows[0][6]);
									array[num10].Trajetos = Conversions.ToString(dataTable5.Rows[0][7]);
									switch (num13)
									{
									case 3:
										array[num10].bAterrar = true;
										break;
									case 0:
										array[num10].bAterrar = false;
										break;
									case 1:
										if (num11 != painel)
										{
											array[num10].bAterrar = false;
										}
										else
										{
											array[num10].bAterrar = true;
										}
										break;
									case 2:
										if (num12 != painel)
										{
											array[num10].bAterrar = false;
										}
										else
										{
											array[num10].bAterrar = true;
										}
										break;
									}
								}
								if (!((padraoDI == 2) | (padraoDI == 10)))
								{
									array[num10].FuncaoVeia = "";
									continue;
								}
								string text7 = "SELECT Funcao FROM Veias4 WHERE Revisao=@revisao AND Tag=@tag AND Num_Veia=@num_veia";
								object instance17 = db;
								object[] array19 = new object[3]
								{
									"@revisao",
									revisao,
									OleDbType.Char
								};
								array2 = array19;
								NewLateBinding.LateCall(instance17, null, "AddParameter", array19, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
								revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
								object instance18 = db;
								object[] array20 = new object[3] { "@tag", null, null };
								ref string tag_Cabo4 = ref array[num10].Tag_Cabo;
								reference = ref tag_Cabo4;
								array20[1] = tag_Cabo4;
								array20[2] = OleDbType.Char;
								array2 = array20;
								NewLateBinding.LateCall(instance18, null, "AddParameter", array20, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
								reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
								object instance19 = db;
								object[] array21 = new object[3] { "@num_veia", null, null };
								ref int veia2 = ref array[num10].Veia;
								ref int reference2 = ref veia2;
								array21[1] = veia2;
								array21[2] = OleDbType.Integer;
								array2 = array21;
								NewLateBinding.LateCall(instance19, null, "AddParameter", array21, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
								reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
								object instance20 = db;
								object[] array22 = new object[1] { text7 };
								array2 = array22;
								obj = NewLateBinding.LateGet(instance20, null, "ExecuteReader", array22, null, null, new bool[1] { true });
								text7 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
								DataTable dataTable7 = (DataTable)obj;
								if (dataTable7.Rows.Count == 1)
								{
									array[num10].FuncaoVeia = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable7.Rows[0][0]));
								}
							}
						}
						mReguas[i].Bornes[j].cabos = array;
					}
				}
				list.Sort();
				string text8 = "";
				foreach (string item in list)
				{
					text8 = text8 + item + "\r\n";
				}
				if (Operators.CompareString(text8, "", TextCompare: true) != 0)
				{
					Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 36], "\r\n"), text8), MsgBoxStyle.Critical, "Eletron");
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void CarregaJumpersNosBornesRI(string revisao, int painel, ref DeclaracoesInterligacao.structureRI[] mReguas, ref ProgressBar ProgressBar1)
	{
		checked
		{
			try
			{
				int num = Information.UBound(mReguas);
				for (int i = 1; i <= num; i++)
				{
					if (Information.IsNothing(mReguas[i].Bornes))
					{
						continue;
					}
					int num2 = Information.UBound(mReguas[i].Bornes);
					for (int j = 1; j <= num2; j++)
					{
						ProgressBar1.PerformStep();
						DeclaracoesInterligacao.jumperRI[] array = new DeclaracoesInterligacao.jumperRI[1];
						string text = "SELECT Potencial, Ordem, Pagina FROM Jumper4 WHERE Revisao=@revisao AND Painel=@painel AND Tag=@tag AND NRegua=@nRegua AND Terminal=@terminal AND BJumper=@bJumper ORDER BY Potencial";
						object[] array2;
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
						object instance = db;
						object[] array3 = new object[3] { "@tag", null, null };
						ref string tag = ref mReguas[i].Tag;
						ref string reference = ref tag;
						array3[1] = tag;
						array3[2] = OleDbType.Char;
						array2 = array3;
						NewLateBinding.LateCall(instance, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						object instance2 = db;
						object[] array4 = new object[3] { "@nRegua", null, null };
						ref string nRegua = ref mReguas[i].NRegua;
						reference = ref nRegua;
						array4[1] = nRegua;
						array4[2] = OleDbType.Char;
						array2 = array4;
						NewLateBinding.LateCall(instance2, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						object instance3 = db;
						object[] array5 = new object[3] { "@terminal", null, null };
						ref string borne = ref mReguas[i].Bornes[j].Borne;
						reference = ref borne;
						array5[1] = borne;
						array5[2] = OleDbType.Char;
						array2 = array5;
						NewLateBinding.LateCall(instance3, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
						{
							"@bJumper",
							true,
							OleDbType.Boolean
						}, null, null, null, IgnoreReturn: true);
						object obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
						DataTable dataTable = (DataTable)obj;
						if (dataTable.Rows.Count > 0)
						{
							int num3 = dataTable.Rows.Count - 1;
							for (int k = 0; k <= num3; k++)
							{
								int num4 = Conversions.ToInteger(dataTable.Rows[k][0]);
								int num5 = Conversions.ToInteger(dataTable.Rows[k][1]);
								string pagina = Conversions.ToString(dataTable.Rows[k][2]);
								if (num5 > 1)
								{
									string text2 = "SELECT Tag, NRegua, Terminal FROM Jumper4 WHERE Revisao=@revisao AND Painel=@painel AND Potencial=@potencial AND Ordem=@ordem";
									object instance4 = db;
									object[] array6 = new object[3]
									{
										"@revisao",
										revisao,
										OleDbType.Char
									};
									array2 = array6;
									NewLateBinding.LateCall(instance4, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
									revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
									object instance5 = db;
									object[] array7 = new object[3]
									{
										"@painel",
										painel,
										OleDbType.Integer
									};
									array2 = array7;
									NewLateBinding.LateCall(instance5, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
									painel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
									object instance6 = db;
									object[] array8 = new object[3]
									{
										"@potencial",
										num4,
										OleDbType.Integer
									};
									array2 = array8;
									NewLateBinding.LateCall(instance6, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
									num4 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
									NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
									{
										"@ordem",
										num5 - 1,
										OleDbType.Integer
									}, null, null, null, IgnoreReturn: true);
									object instance7 = db;
									object[] array9 = new object[1] { text2 };
									array2 = array9;
									obj = NewLateBinding.LateGet(instance7, null, "ExecuteReader", array9, null, null, new bool[1] { true });
									text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
									DataTable dataTable2 = (DataTable)obj;
									if (dataTable2.Rows.Count == 1)
									{
										int num6 = Information.UBound(array) + 1;
										array = (DeclaracoesInterligacao.jumperRI[])Utils.CopyArray(array, new DeclaracoesInterligacao.jumperRI[num6 + 1]);
										array[num6].Tag = Conversions.ToString(dataTable2.Rows[0][0]);
										array[num6].NRegua = Conversions.ToString(dataTable2.Rows[0][1]);
										array[num6].Borne = Conversions.ToString(dataTable2.Rows[0][2]);
										array[num6].Pagina = pagina;
										array[num6].bEntra = true;
										array[num6].bSai = false;
									}
								}
								string text3 = "SELECT Tag, NRegua, Terminal FROM Jumper4 WHERE Revisao=@revisao AND Painel=@painel AND Potencial=@potencial AND Ordem=@ordem";
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
									num4,
									OleDbType.Integer
								}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
								num4 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
								NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
								{
									"@ordem",
									num5 + 1,
									OleDbType.Integer
								}, null, null, null, IgnoreReturn: true);
								obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text3 }, null, null, new bool[1] { true });
								text3 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
								DataTable dataTable3 = (DataTable)obj;
								if (dataTable3.Rows.Count == 1)
								{
									int num7 = Information.UBound(array) + 1;
									array = (DeclaracoesInterligacao.jumperRI[])Utils.CopyArray(array, new DeclaracoesInterligacao.jumperRI[num7 + 1]);
									array[num7].Tag = Conversions.ToString(dataTable3.Rows[0][0]);
									array[num7].NRegua = Conversions.ToString(dataTable3.Rows[0][1]);
									array[num7].Borne = Conversions.ToString(dataTable3.Rows[0][2]);
									array[num7].Pagina = pagina;
									array[num7].bEntra = false;
									array[num7].bSai = true;
								}
							}
						}
						mReguas[i].Bornes[j].jumpers = array;
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

	public void CarregaVeiasReserva(string revisao, int painel, ref DeclaracoesInterligacao.reservaRI[] mAterrados, ref DeclaracoesInterligacao.reservaRI[] mNaoAterrados, bool bELS)
	{
		string text = "";
		text = "SELECT Tag, Pn2, Aterrar FROM Cabos4 WHERE Revisao=@revisao AND Pn1=@painel ORDER BY Tag";
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
		checked
		{
			if (dataTable.Rows.Count > 0)
			{
				int num = dataTable.Rows.Count - 1;
				int num3 = default;
				for (int i = 0; i <= num; i++)
				{
					string text2 = Conversions.ToString(dataTable.Rows[i][0]);
					int iPainel = Conversions.ToInteger(dataTable.Rows[i][1]);
					int num2 = Conversions.ToInteger(dataTable.Rows[i][2]);
					string text3 = "SELECT COUNT(*) FROM Veias4 WHERE Revisao=@revisao AND Tag=@tag AND Uso=@bUso";
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@revisao",
						revisao,
						OleDbType.Char
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@tag",
						text2,
						OleDbType.Char
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
					{
						"@bUso",
						true,
						OleDbType.Boolean
					}, null, null, null, IgnoreReturn: true);
					obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text3 }, null, null, new bool[1] { true });
					text3 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DataTable dataTable2 = (DataTable)obj;
					if (!Operators.ConditionalCompareObjectGreater(dataTable2.Rows[0][0], 0, TextCompare: true))
					{
						continue;
					}
					string text4 = "SELECT Num_Veia, Nome_Veia FROM Veias4 WHERE Revisao=@revisao AND Tag=@tag AND Uso=@bUso AND Num_Veia>0 ORDER BY Num_Veia";
					object instance4 = db;
					object[] array5 = new object[3]
					{
						"@revisao",
						revisao,
						OleDbType.Char
					};
					array2 = array5;
					NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance5 = db;
					object[] array6 = new object[3]
					{
						"@tag",
						text2,
						OleDbType.Char
					};
					array2 = array6;
					NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
					{
						"@bUso",
						false,
						OleDbType.Boolean
					}, null, null, null, IgnoreReturn: true);
					object instance6 = db;
					object[] array7 = new object[1] { text4 };
					array2 = array7;
					obj = NewLateBinding.LateGet(instance6, null, "ExecuteReader", array7, null, null, new bool[1] { true });
					text4 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DataTable dataTable3 = (DataTable)obj;
					if (!bELS)
					{
						if (!((num2 == 1) | (num2 == 3)))
						{
							if ((num2 == 2) | (num2 == 0))
							{
								num3 = Information.UBound(mNaoAterrados) + 1;
								mNaoAterrados = (DeclaracoesInterligacao.reservaRI[])Utils.CopyArray(mNaoAterrados, new DeclaracoesInterligacao.reservaRI[num3 + 1]);
								mNaoAterrados[num3].Tag = text2;
								mNaoAterrados[num3].sPainelDest = Dicionario.BuscaNomeDoPainel(iPainel);
								mNaoAterrados[num3].lveias = new List<string>();
							}
						}
						else
						{
							num3 = Information.UBound(mAterrados) + 1;
							mAterrados = (DeclaracoesInterligacao.reservaRI[])Utils.CopyArray(mAterrados, new DeclaracoesInterligacao.reservaRI[num3 + 1]);
							mAterrados[num3].Tag = text2;
							mAterrados[num3].sPainelDest = Dicionario.BuscaNomeDoPainel(iPainel);
							mAterrados[num3].lveias = new List<string>();
						}
					}
					else if (!((num2 == 1) | (num2 == 3)))
					{
						if ((num2 == 2) | (num2 == 0))
						{
							num3 = Information.UBound(mAterrados) + 1;
							mAterrados = (DeclaracoesInterligacao.reservaRI[])Utils.CopyArray(mAterrados, new DeclaracoesInterligacao.reservaRI[num3 + 1]);
							mAterrados[num3].Tag = text2;
							mAterrados[num3].sPainelDest = Dicionario.BuscaNomeDoPainel(iPainel);
							mAterrados[num3].lveias = new List<string>();
						}
					}
					else
					{
						num3 = Information.UBound(mAterrados) + 1;
						mAterrados = (DeclaracoesInterligacao.reservaRI[])Utils.CopyArray(mAterrados, new DeclaracoesInterligacao.reservaRI[num3 + 1]);
						mAterrados[num3].Tag = text2;
						mAterrados[num3].sPainelDest = Dicionario.BuscaNomeDoPainel(iPainel);
						mAterrados[num3].lveias = new List<string>();
					}
					if (dataTable3.Rows.Count <= 0)
					{
						continue;
					}
					int num4 = dataTable3.Rows.Count - 1;
					for (int j = 0; j <= num4; j++)
					{
						string text5 = "";
						if (!bELS)
						{
							if (!((num2 == 1) | (num2 == 3)))
							{
								if ((num2 == 2) | (num2 == 0))
								{
									text5 = Conversions.ToString(dataTable3.Rows[j][0]);
									string text6 = Conversions.ToString(dataTable3.Rows[j][1]);
									if (Operators.CompareString(text6, "", TextCompare: true) != 0)
									{
										text5 = text6;
									}
									mNaoAterrados[num3].lveias.Add(text5);
								}
							}
							else
							{
								text5 = Conversions.ToString(dataTable3.Rows[j][0]);
								string text7 = Conversions.ToString(dataTable3.Rows[j][1]);
								if (Operators.CompareString(text7, "", TextCompare: true) != 0)
								{
									text5 = text7;
								}
								mAterrados[num3].lveias.Add(text5);
							}
						}
						else if (!((num2 == 1) | (num2 == 3)))
						{
							if ((num2 == 2) | (num2 == 0))
							{
								text5 = Conversions.ToString(dataTable3.Rows[j][0]);
								string text8 = Conversions.ToString(dataTable3.Rows[j][1]);
								if (Operators.CompareString(text8, "", TextCompare: true) != 0)
								{
									text5 = text8;
								}
								mAterrados[num3].lveias.Add(text5);
							}
						}
						else
						{
							text5 = Conversions.ToString(dataTable3.Rows[j][0]);
							string text9 = Conversions.ToString(dataTable3.Rows[j][1]);
							if (Operators.CompareString(text9, "", TextCompare: true) != 0)
							{
								text5 = text9;
							}
							mAterrados[num3].lveias.Add(text5);
						}
					}
				}
			}
			text = "SELECT Tag, Pn1, Aterrar FROM Cabos4 WHERE Revisao=@revisao AND Pn2=@painel ORDER BY Tag";
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
			obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			dataTable = (DataTable)obj;
			if (dataTable.Rows.Count <= 0)
			{
				return;
			}
			int num5 = dataTable.Rows.Count - 1;
			int num7 = default;
			for (int k = 0; k <= num5; k++)
			{
				string text10 = Conversions.ToString(dataTable.Rows[k][0]);
				int iPainel2 = Conversions.ToInteger(dataTable.Rows[k][1]);
				int num6 = Conversions.ToInteger(dataTable.Rows[k][2]);
				string text11 = "SELECT COUNT(*) FROM Veias4 WHERE Revisao=@revisao AND Tag=@tag AND Uso=@bUso";
				NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
				{
					"@revisao",
					revisao,
					OleDbType.Char
				}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
				{
					"@tag",
					text10,
					OleDbType.Char
				}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				text10 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
				{
					"@bUso",
					true,
					OleDbType.Boolean
				}, null, null, null, IgnoreReturn: true);
				obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text11 }, null, null, new bool[1] { true });
				text11 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable4 = (DataTable)obj;
				if (!Operators.ConditionalCompareObjectGreater(dataTable4.Rows[0][0], 0, TextCompare: true))
				{
					continue;
				}
				string text12 = "SELECT Num_Veia, Nome_Veia FROM Veias4 WHERE Revisao=@revisao AND Tag=@tag AND Uso=@bUso AND Num_Veia>0 ORDER BY Num_Veia";
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
					"@tag",
					text10,
					OleDbType.Char
				};
				array2 = array9;
				NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				text10 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
				{
					"@bUso",
					false,
					OleDbType.Boolean
				}, null, null, null, IgnoreReturn: true);
				object instance9 = db;
				object[] array10 = new object[1] { text12 };
				array2 = array10;
				obj = NewLateBinding.LateGet(instance9, null, "ExecuteReader", array10, null, null, new bool[1] { true });
				text12 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable5 = (DataTable)obj;
				if (!bELS)
				{
					if (!((num6 == 2) | (num6 == 3)))
					{
						if ((num6 == 1) | (num6 == 0))
						{
							num7 = Information.UBound(mNaoAterrados) + 1;
							mNaoAterrados = (DeclaracoesInterligacao.reservaRI[])Utils.CopyArray(mNaoAterrados, new DeclaracoesInterligacao.reservaRI[num7 + 1]);
							mNaoAterrados[num7].Tag = text10;
							mNaoAterrados[num7].sPainelDest = Dicionario.BuscaNomeDoPainel(iPainel2);
							mNaoAterrados[num7].lveias = new List<string>();
						}
					}
					else
					{
						num7 = Information.UBound(mAterrados) + 1;
						mAterrados = (DeclaracoesInterligacao.reservaRI[])Utils.CopyArray(mAterrados, new DeclaracoesInterligacao.reservaRI[num7 + 1]);
						mAterrados[num7].Tag = text10;
						mAterrados[num7].sPainelDest = Dicionario.BuscaNomeDoPainel(iPainel2);
						mAterrados[num7].lveias = new List<string>();
					}
				}
				else if (!((num6 == 2) | (num6 == 3)))
				{
					if ((num6 == 1) | (num6 == 0))
					{
						num7 = Information.UBound(mAterrados) + 1;
						mAterrados = (DeclaracoesInterligacao.reservaRI[])Utils.CopyArray(mAterrados, new DeclaracoesInterligacao.reservaRI[num7 + 1]);
						mAterrados[num7].Tag = text10;
						mAterrados[num7].sPainelDest = Dicionario.BuscaNomeDoPainel(iPainel2);
						mAterrados[num7].lveias = new List<string>();
					}
				}
				else
				{
					num7 = Information.UBound(mAterrados) + 1;
					mAterrados = (DeclaracoesInterligacao.reservaRI[])Utils.CopyArray(mAterrados, new DeclaracoesInterligacao.reservaRI[num7 + 1]);
					mAterrados[num7].Tag = text10;
					mAterrados[num7].sPainelDest = Dicionario.BuscaNomeDoPainel(iPainel2);
					mAterrados[num7].lveias = new List<string>();
				}
				if (dataTable5.Rows.Count <= 0)
				{
					continue;
				}
				int num8 = dataTable5.Rows.Count - 1;
				for (int l = 0; l <= num8; l++)
				{
					string text13 = "";
					if (!bELS)
					{
						if (!((num6 == 2) | (num6 == 3)))
						{
							if ((num6 == 1) | (num6 == 0))
							{
								text13 = Conversions.ToString(dataTable5.Rows[l][0]);
								string text14 = Conversions.ToString(dataTable5.Rows[l][1]);
								if (Operators.CompareString(text14, "", TextCompare: true) != 0)
								{
									text13 = text14;
								}
								mNaoAterrados[num7].lveias.Add(text13);
							}
						}
						else
						{
							text13 = Conversions.ToString(dataTable5.Rows[l][0]);
							string text15 = Conversions.ToString(dataTable5.Rows[l][1]);
							if (Operators.CompareString(text15, "", TextCompare: true) != 0)
							{
								text13 = text15;
							}
							mAterrados[num7].lveias.Add(text13);
						}
					}
					else if (!((num6 == 2) | (num6 == 3)))
					{
						if ((num6 == 1) | (num6 == 0))
						{
							text13 = Conversions.ToString(dataTable5.Rows[l][0]);
							string text16 = Conversions.ToString(dataTable5.Rows[l][1]);
							if (Operators.CompareString(text16, "", TextCompare: true) != 0)
							{
								text13 = text16;
							}
							mAterrados[num7].lveias.Add(text13);
						}
					}
					else
					{
						text13 = Conversions.ToString(dataTable5.Rows[l][0]);
						string text17 = Conversions.ToString(dataTable5.Rows[l][1]);
						if (Operators.CompareString(text17, "", TextCompare: true) != 0)
						{
							text13 = text17;
						}
						mAterrados[num7].lveias.Add(text13);
					}
				}
			}
		}
	}

	public void CarregaVeiasUsadasLivres(string revisao, string tag_cabo, ref List<string> lVeiasUsadas, ref List<string> lVeiasLivres)
	{
		string text = "SELECT Num_Veia, Nome_Veia, Uso FROM Veias4 WHERE Revisao=@revisao AND Tag=@tag AND Num_Veia>0 ORDER BY Num_Veia";
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
			"@tag",
			tag_cabo,
			OleDbType.Char
		};
		array2 = array3;
		NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		tag_cabo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
		checked
		{
			int num = dataTable.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				int num2 = Conversions.ToInteger(dataTable.Rows[i][0]);
				string text2 = Conversions.ToString(dataTable.Rows[i][1]);
				bool flag = Conversions.ToBoolean(dataTable.Rows[i][2]);
				string item = num2.ToString();
				if (Operators.CompareString(text2.Trim(), "", TextCompare: true) != 0)
				{
					item = text2.Trim();
				}
				if (!flag)
				{
					lVeiasLivres.Add(item);
				}
				else
				{
					lVeiasUsadas.Add(item);
				}
			}
		}
	}

	public void ApagaCabosRevPn(string revisao, ref List<int> lPn)
	{
		try
		{
			foreach (int item in lPn)
			{
				string text = "";
				text = "DELETE FROM ARANHA4 WHERE Revisao=@revisao AND Painel=@painel";
				object[] array;
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
					item,
					OleDbType.Integer
				}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				int current = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
				NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}

	public void exportaCabos(string revisao, ref DeclaracoesInterligacao.caboSync[] mCabosSync)
	{
		try
		{
			int num = Information.UBound(mCabosSync);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				string text = "";
				text = "Insert into Aranha4(Revisao, Tag_Cabo, Painel, Caderno, Folha, Coluna) VALUES(@revisao, @tagCabo, @painel, @caderno, @folha, @coluna)";
				object[] array;
				NewLateBinding.LateCall(db, null, "AddParameter", array = new object[3]
				{
					"@revisao",
					revisao,
					OleDbType.Char
				}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				revisao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(string));
				object instance = db;
				object[] array2 = new object[3] { "@tagCabo", null, null };
				ref string tag_Cabo = ref mCabosSync[i].Tag_Cabo;
				ref string reference = ref tag_Cabo;
				array2[1] = tag_Cabo;
				array2[2] = OleDbType.Char;
				array = array2;
				NewLateBinding.LateCall(instance, null, "AddParameter", array2, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(string));
				object instance2 = db;
				object[] array3 = new object[3] { "@painel", null, null };
				ref int painel = ref mCabosSync[i].Painel;
				ref int reference2 = ref painel;
				array3[1] = painel;
				array3[2] = OleDbType.Integer;
				array = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
				object instance3 = db;
				object[] array4 = new object[3] { "@caderno", null, null };
				ref string caderno = ref mCabosSync[i].Caderno;
				reference = ref caderno;
				array4[1] = caderno;
				array4[2] = OleDbType.Char;
				array = array4;
				NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(string));
				object instance4 = db;
				object[] array5 = new object[3] { "@folha", null, null };
				ref string folha = ref mCabosSync[i].Folha;
				reference = ref folha;
				array5[1] = folha;
				array5[2] = OleDbType.Char;
				array = array5;
				NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(string));
				object instance5 = db;
				object[] array6 = new object[3] { "@coluna", null, null };
				ref int coluna = ref mCabosSync[i].Coluna;
				reference2 = ref coluna;
				array6[1] = coluna;
				array6[2] = OleDbType.Integer;
				array = array6;
				NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
				NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}

	public void leCabos(string revisao, ref DeclaracoesInterligacao.caboSync[] mTodosCabosSync)
	{
		checked
		{
			try
			{
				string text = "SELECT Tag_Cabo, Painel, Caderno, Folha, Coluna FROM Aranha4 WHERE Revisao=@revisao";
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
						int num2 = Information.UBound(mTodosCabosSync) + 1;
						mTodosCabosSync = (DeclaracoesInterligacao.caboSync[])Utils.CopyArray(mTodosCabosSync, new DeclaracoesInterligacao.caboSync[num2 + 1]);
						mTodosCabosSync[num2].Tag_Cabo = Conversions.ToString(dataTable.Rows[i][0]);
						mTodosCabosSync[num2].Painel = Conversions.ToInteger(dataTable.Rows[i][1]);
						mTodosCabosSync[num2].Caderno = Conversions.ToString(dataTable.Rows[i][2]);
						mTodosCabosSync[num2].Folha = Conversions.ToString(dataTable.Rows[i][3]);
						mTodosCabosSync[num2].Coluna = Conversions.ToInteger(dataTable.Rows[i][4]);
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				throw new Exception(ex2.Message);
			}
		}
	}

	public void CorrigeNothing(string tabela)
	{
		try
		{
			string text = "";
			text = "UPDATE Cabos SET " + tabela + "=' ' WHERE " + tabela + "=''";
			object instance = db;
			object[] array = new object[1] { text };
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "ExecuteNonQuery", array, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			text = "UPDATE Cabos4 SET " + tabela + "=' ' WHERE " + tabela + "=''";
			object instance2 = db;
			object[] array3 = new object[1] { text };
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "ExecuteNonQuery", array3, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			text = "UPDATE Cabos SET Alarme = 0";
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

	public void LeTodosCabosUsados(ref List<string> lCabosUsados)
	{
		checked
		{
			try
			{
				string text = "SELECT DISTINCT(Tag) FROM Veias WHERE USO = TRUE";
				object instance = db;
				object[] array = new object[3] { "@arquivo", null, null };
				ref int indice = ref DeclaracoesGeral.arqAtivo.Indice;
				array[1] = indice;
				array[2] = OleDbType.Integer;
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				indice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance2 = db;
				object[] array3 = new object[1] { text };
				array2 = array3;
				object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				lCabosUsados.Clear();
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (!lCabosUsados.Contains(Conversions.ToString(dataTable.Rows[i][0])))
						{
							lCabosUsados.Add(Conversions.ToString(dataTable.Rows[i][0]));
						}
					}
				}
				lCabosUsados.Sort();
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

	public void LeTodosCabos(ref List<string> lTodosCabos)
	{
		checked
		{
			try
			{
				string text = "SELECT DISTINCT(Tag) FROM Veias";
				object instance = db;
				object[] array = new object[3] { "@arquivo", null, null };
				ref int indice = ref DeclaracoesGeral.arqAtivo.Indice;
				array[1] = indice;
				array[2] = OleDbType.Integer;
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				indice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance2 = db;
				object[] array3 = new object[1] { text };
				array2 = array3;
				object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				lTodosCabos.Clear();
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (!lTodosCabos.Contains(Conversions.ToString(dataTable.Rows[i][0])))
						{
							lTodosCabos.Add(Conversions.ToString(dataTable.Rows[i][0]));
						}
					}
				}
				lTodosCabos.Sort();
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
}
