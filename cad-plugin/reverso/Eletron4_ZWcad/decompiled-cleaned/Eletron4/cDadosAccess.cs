using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;

namespace Eletron4;

public class cDadosAccess
{
	public static void carregaDadosDWG()
	{
		try
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Geral.extraiNomeCaminhoDwg(mdiActiveDocument.Name, ref DeclaracoesGeral.arqAtivo.Nome, ref DeclaracoesGeral.arqAtivo.Path);
			if (clsAuxiliar.BancoValido())
			{
				DeclaracoesGeral.arqAtivo.Indice = 0;
				if (DeclaracoesGeral.dicDWG.Count == 0)
				{
					carregaDWGDicionario();
				}
				foreach (KeyValuePair<int, string> item in DeclaracoesGeral.dicDWG)
				{
					if (Operators.CompareString(item.Value, DeclaracoesGeral.arqAtivo.Nome, TextCompare: true) == 0)
					{
						DeclaracoesGeral.arqAtivo.Indice = item.Key;
						break;
					}
				}
				if (DeclaracoesGeral.arqAtivo.Indice != 0)
				{
					return;
				}
				carregaDWGDicionario();
				using Dictionary<int, string>.Enumerator enumerator2 = DeclaracoesGeral.dicDWG.GetEnumerator();
				KeyValuePair<int, string> current;
				do
				{
					if (enumerator2.MoveNext())
					{
						current = enumerator2.Current;
						continue;
					}
					return;
				}
				while (Operators.CompareString(current.Value, DeclaracoesGeral.arqAtivo.Nome, TextCompare: true) != 0);
				DeclaracoesGeral.arqAtivo.Indice = current.Key;
				return;
			}
			DeclaracoesGeral.arqAtivo.Indice = 0;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public static void carregaDWGDicionario()
	{
		DeclaracoesGeral.dicDWG = new Dictionary<int, string>();
		object obj = null;
		string banco = DeclaracoesGeral.Conf.Banco;
		if (Operators.CompareString(banco, "A", TextCompare: true) != 0)
		{
			if (Operators.CompareString(banco, "S", TextCompare: true) != 0)
			{
				if (Operators.CompareString(banco, "SV", TextCompare: true) == 0)
				{
					obj = new AcessoSQLServer();
				}
			}
			else
			{
				obj = new AcessoSQLite();
			}
		}
		else
		{
			obj = new AcessoAccess();
		}
		checked
		{
			try
			{
				string text = "SELECT Indice, Nome FROM DWG";
				object instance = obj;
				object[] array = new object[1] { text };
				object[] array2 = array;
				object obj2 = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj2;
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						DeclaracoesGeral.dicDWG.Add(Conversions.ToInteger(dataTable.Rows[i][0]), Conversions.ToString(dataTable.Rows[i][1]));
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
				NewLateBinding.LateCall(obj, null, "fechaConexao", new object[0], null, null, null, IgnoreReturn: true);
			}
		}
	}

	public static void carregaDadosTodosDWG(ref DeclaracoesGeral.arqLogico[] mDWG)
	{
		object obj = null;
		string banco = DeclaracoesGeral.Conf.Banco;
		if (Operators.CompareString(banco, "A", TextCompare: true) != 0)
		{
			if (Operators.CompareString(banco, "S", TextCompare: true) != 0)
			{
				if (Operators.CompareString(banco, "SV", TextCompare: true) == 0)
				{
					obj = new AcessoSQLServer();
				}
			}
			else
			{
				obj = new AcessoSQLite();
			}
		}
		else
		{
			obj = new AcessoAccess();
		}
		checked
		{
			try
			{
				string text = "SELECT Indice, Caminho, Nome FROM DWG WHERE Tipo='F'";
				object instance = obj;
				object[] array = new object[1] { text };
				object[] array2 = array;
				object obj2 = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj2;
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						mDWG = (DeclaracoesGeral.arqLogico[])Utils.CopyArray(mDWG, new DeclaracoesGeral.arqLogico[Information.UBound(mDWG) + 1 + 1]);
						mDWG[Information.UBound(mDWG)].Indice = Conversions.ToInteger(dataTable.Rows[i][0]);
						mDWG[Information.UBound(mDWG)].Path = Conversions.ToString(dataTable.Rows[i][1]);
						mDWG[Information.UBound(mDWG)].Nome = Conversions.ToString(dataTable.Rows[i][2]);
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
				NewLateBinding.LateCall(obj, null, "fechaConexao", new object[0], null, null, null, IgnoreReturn: true);
			}
		}
	}

	public static void carregaPNDG(ref DataGridView dg, string sPainel)
	{
		object obj = null;
		string banco = DeclaracoesGeral.Conf.Banco;
		if (Operators.CompareString(banco, "A", TextCompare: true) != 0)
		{
			if (Operators.CompareString(banco, "S", TextCompare: true) != 0)
			{
				if (Operators.CompareString(banco, "SV", TextCompare: true) == 0)
				{
					obj = new AcessoSQLServer();
				}
			}
			else
			{
				obj = new AcessoSQLite();
			}
		}
		else
		{
			obj = new AcessoAccess();
		}
		checked
		{
			try
			{
				string text = "SELECT Indice, Nome, Criador, Editor, Data FROM " + sPainel + " WHERE Nome IS NOT NULL ORDER BY Indice";
				object instance = obj;
				object[] array = new object[1] { text };
				object[] array2 = array;
				object obj2 = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj2;
				dg.Rows.Clear();
				dg.Columns.Clear();
				dg.Columns.Add("", "Índice");
				dg.Columns.Add("", "Painel");
				dg.Columns.Add("", "Criador");
				dg.Columns.Add("", "Editor");
				dg.Columns.Add("", "Data");
				dg.Columns.Add("", "Uso");
				dg.Columns.Add("", "ADD");
				dg.Columns.Add("", "EXC");
				dg.Columns.Add("", "EDI");
				dg.Columns.Add("", "Indice Deletar");
				string text2 = "";
				string text3 = " ";
				string text4 = " ";
				object obj3 = " ";
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						text2 = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][1]));
						text4 = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][3]));
						obj3 = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][4]));
						text3 = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][2]));
						dg.Rows.Add(dataTable.Rows[i][0], text2, text3, text4, obj3, "False", "False", "False", "False", 0);
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
				NewLateBinding.LateCall(obj, null, "fechaConexao", new object[0], null, null, null, IgnoreReturn: true);
			}
		}
	}

	public static void carregaDadosPNs(ref object mPaineis, string sPainel)
	{
		object obj = null;
		string banco = DeclaracoesGeral.Conf.Banco;
		if (Operators.CompareString(banco, "A", TextCompare: true) != 0)
		{
			if (Operators.CompareString(banco, "S", TextCompare: true) != 0)
			{
				if (Operators.CompareString(banco, "SV", TextCompare: true) == 0)
				{
					obj = new AcessoSQLServer();
				}
			}
			else
			{
				obj = new AcessoSQLite();
			}
		}
		else
		{
			obj = new AcessoAccess();
		}
		checked
		{
			try
			{
				string text = "SELECT * FROM " + sPainel + " order by indice";
				object instance = obj;
				object[] array = new object[1] { text };
				object[] array2 = array;
				object obj2 = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj2;
				NewLateBinding.LateIndexSet(mPaineis, new object[3] { 0, 0, "Indice do Painel" }, null);
				NewLateBinding.LateIndexSet(mPaineis, new object[3] { 1, 0, "Nome do Painel" }, null);
				NewLateBinding.LateIndexSet(mPaineis, new object[3] { 2, 0, "Criador" }, null);
				NewLateBinding.LateIndexSet(mPaineis, new object[3] { 3, 0, "Editor" }, null);
				NewLateBinding.LateIndexSet(mPaineis, new object[3] { 4, 0, "Data" }, null);
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					mPaineis = Utils.CopyArray((Array)mPaineis, new object[5, i + 1 + 1]);
					NewLateBinding.LateIndexSet(mPaineis, new object[3]
					{
						0,
						i + 1,
						""
					}, null);
					NewLateBinding.LateIndexSet(mPaineis, new object[3]
					{
						1,
						i + 1,
						""
					}, null);
					NewLateBinding.LateIndexSet(mPaineis, new object[3]
					{
						2,
						i + 1,
						""
					}, null);
					NewLateBinding.LateIndexSet(mPaineis, new object[3]
					{
						3,
						i + 1,
						""
					}, null);
					NewLateBinding.LateIndexSet(mPaineis, new object[3]
					{
						4,
						i + 1,
						""
					}, null);
					if (Operators.CompareString(dataTable.Rows[i][0].ToString(), "", TextCompare: true) != 0)
					{
						NewLateBinding.LateIndexSet(mPaineis, new object[3]
						{
							0,
							i + 1,
							dataTable.Rows[i][0]
						}, null);
					}
					if (Operators.CompareString(dataTable.Rows[i][1].ToString(), "", TextCompare: true) != 0)
					{
						NewLateBinding.LateIndexSet(mPaineis, new object[3]
						{
							1,
							i + 1,
							dataTable.Rows[i][1]
						}, null);
					}
					if (Operators.CompareString(dataTable.Rows[i][2].ToString(), "", TextCompare: true) != 0)
					{
						NewLateBinding.LateIndexSet(mPaineis, new object[3]
						{
							2,
							i + 1,
							dataTable.Rows[i][2]
						}, null);
					}
					if (Operators.CompareString(dataTable.Rows[i][3].ToString(), "", TextCompare: true) != 0)
					{
						NewLateBinding.LateIndexSet(mPaineis, new object[3]
						{
							3,
							i + 1,
							dataTable.Rows[i][3]
						}, null);
					}
					if (Operators.CompareString(dataTable.Rows[i][4].ToString(), "", TextCompare: true) != 0)
					{
						NewLateBinding.LateIndexSet(mPaineis, new object[3]
						{
							4,
							i + 1,
							dataTable.Rows[i][4]
						}, null);
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
				NewLateBinding.LateCall(obj, null, "fechaConexao", new object[0], null, null, null, IgnoreReturn: true);
			}
		}
	}

	public static void carregaPainelDicionario()
	{
		DeclaracoesGeral.dicPainel = new Dictionary<int, string>();
		object obj = null;
		string banco = DeclaracoesGeral.Conf.Banco;
		if (Operators.CompareString(banco, "A", TextCompare: true) != 0)
		{
			if (Operators.CompareString(banco, "S", TextCompare: true) != 0)
			{
				if (Operators.CompareString(banco, "SV", TextCompare: true) == 0)
				{
					obj = new AcessoSQLServer();
				}
			}
			else
			{
				obj = new AcessoSQLite();
			}
		}
		else
		{
			obj = new AcessoAccess();
		}
		checked
		{
			try
			{
				string text = "SELECT Indice, Nome FROM Paineis WHERE Nome IS NOT NULL ORDER BY Nome";
				object instance = obj;
				object[] array = new object[1] { text };
				object[] array2 = array;
				object obj2 = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj2;
				bool flag = false;
				List<string> list = new List<string>();
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						DeclaracoesGeral.dicPainel.Add(Conversions.ToInteger(dataTable.Rows[i][0]), dataTable.Rows[i][1].ToString());
						if (list.Contains(dataTable.Rows[i][1].ToString()))
						{
							flag = true;
						}
						else
						{
							list.Add(dataTable.Rows[i][1].ToString());
						}
					}
				}
				string text2 = "";
				if (flag)
				{
					text2 = Conversions.ToString(Operators.AddObject(text2, Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1718], ".")));
				}
				if (Operators.CompareString(text2, "", TextCompare: true) != 0)
				{
					Interaction.MsgBox(text2, MsgBoxStyle.Information, "Elétron");
					new frmCadastroDePaineis();
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
				NewLateBinding.LateCall(obj, null, "fechaConexao", new object[0], null, null, null, IgnoreReturn: true);
			}
		}
	}
}
