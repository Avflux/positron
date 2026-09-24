using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class cDadosAtualizaBanco
{
	public object db;

	public void fechaConexao()
	{
		NewLateBinding.LateCall(db, null, "fechaConexao", new object[0], null, null, null, IgnoreReturn: true);
	}

	public cDadosAtualizaBanco()
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

	public void LimpaDWGApagadosDoProjeto()
	{
		checked
		{
			try
			{
				List<int> list = new List<int>();
				string text = "SELECT DISTINCT(Indice) FROM DWG ORDER BY INDICE";
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
						if (!list.Contains(Conversions.ToInteger(dataTable.Rows[i][0])))
						{
							list.Add(Conversions.ToInteger(dataTable.Rows[i][0]));
						}
					}
				}
				List<int> list2 = new List<int>();
				text = "SELECT DISTINCT(DWG) FROM FIACAO WHERE DWG IS NOT NULL";
				obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable2 = (DataTable)obj;
				if (dataTable2.Rows.Count > 0)
				{
					int num2 = dataTable2.Rows.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						if (!list2.Contains(Conversions.ToInteger(dataTable2.Rows[j][0])))
						{
							list2.Add(Conversions.ToInteger(dataTable2.Rows[j][0]));
						}
					}
				}
				text = "SELECT DISTINCT(DWG) FROM INTERLIGACAO4 WHERE DWG IS NOT NULL";
				obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable3 = (DataTable)obj;
				if (dataTable3.Rows.Count > 0)
				{
					int num3 = dataTable3.Rows.Count - 1;
					for (int k = 0; k <= num3; k++)
					{
						if (!list2.Contains(Conversions.ToInteger(dataTable3.Rows[k][0])))
						{
							list2.Add(Conversions.ToInteger(dataTable3.Rows[k][0]));
						}
					}
				}
				text = "SELECT DISTINCT(DWG) FROM LISTAMATERIAIS WHERE DWG IS NOT NULL";
				obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable4 = (DataTable)obj;
				if (dataTable4.Rows.Count > 0)
				{
					int num4 = dataTable4.Rows.Count - 1;
					for (int l = 0; l <= num4; l++)
					{
						if (!list2.Contains(Conversions.ToInteger(dataTable4.Rows[l][0])))
						{
							list2.Add(Conversions.ToInteger(dataTable4.Rows[l][0]));
						}
					}
				}
				text = "SELECT DISTINCT(DWG) FROM PLAQUETAS4 WHERE DWG IS NOT NULL";
				obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable5 = (DataTable)obj;
				if (dataTable5.Rows.Count > 0)
				{
					int num5 = dataTable5.Rows.Count - 1;
					for (int m = 0; m <= num5; m++)
					{
						if (!list2.Contains(Conversions.ToInteger(dataTable5.Rows[m][0])))
						{
							list2.Add(Conversions.ToInteger(dataTable5.Rows[m][0]));
						}
					}
				}
				List<int> list3 = new List<int>();
				foreach (int item in list2)
				{
					if (!list.Contains(item))
					{
						list3.Add(item);
					}
				}
				foreach (int item2 in list3)
				{
					text = "DELETE FROM Atributos WHERE DWG=@dwg";
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@dwg",
						item2,
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					int current2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					text = "DELETE FROM Bornes4F WHERE DWG=@dwg";
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@dwg",
						current2,
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					current2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					text = "DELETE FROM Bornes4I WHERE DWG=@dwg";
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@dwg",
						current2,
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					current2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					text = "DELETE FROM Circuitos4F WHERE DWG=@dwg";
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@dwg",
						current2,
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					current2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					text = "DELETE FROM Contatos4F WHERE DWG=@dwg";
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@dwg",
						current2,
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					current2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					text = "DELETE FROM Dispositivos4F WHERE DWG=@dwg";
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@dwg",
						current2,
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					current2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					text = "DELETE FROM Exportados WHERE DWG=@dwg";
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@dwg",
						current2,
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					current2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					text = "DELETE FROM Fiacao WHERE DWG=@dwg";
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@dwg",
						current2,
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					current2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					text = "DELETE FROM Interligacao4 WHERE DWG=@dwg";
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@dwg",
						current2,
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					current2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					text = "DELETE FROM Jumper4 WHERE DWG=@dwg";
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@dwg",
						current2,
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					current2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					text = "DELETE FROM ListaMateriais WHERE DWG=@dwg";
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@dwg",
						current2,
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					current2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					text = "DELETE FROM Plaquetas4 WHERE DWG=@dwg";
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@dwg",
						current2,
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					current2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					text = "DELETE FROM Portas4F WHERE DWG=@dwg";
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@dwg",
						current2,
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					current2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					text = "DELETE FROM Portas4I WHERE DWG=@dwg";
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@dwg",
						current2,
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					current2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					text = "UPDATE Veias SET  Uso=@bUso, Handle='', Arquivo=0, Pagina='' WHERE Arquivo=@arquivo";
					NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
					{
						"@bUso",
						false,
						OleDbType.Boolean
					}, null, null, null, IgnoreReturn: true);
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@arquivo",
						current2,
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					current2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void ApagaTodaFiacao()
	{
		try
		{
			string text = "";
			text = "DELETE FROM Bornes4F";
			object instance = db;
			object[] array = new object[1] { text };
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "ExecuteNonQuery", array, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			text = "DELETE FROM Circuitos4F";
			object instance2 = db;
			object[] array3 = new object[1] { text };
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "ExecuteNonQuery", array3, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			text = "DELETE FROM Contatos4F";
			object instance3 = db;
			object[] array4 = new object[1] { text };
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "ExecuteNonQuery", array4, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			text = "DELETE FROM Dispositivos4F";
			object instance4 = db;
			object[] array5 = new object[1] { text };
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "ExecuteNonQuery", array5, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			text = "DELETE FROM Fiacao";
			object instance5 = db;
			object[] array6 = new object[1] { text };
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "ExecuteNonQuery", array6, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			text = "DELETE FROM Portas4F";
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

	public void ApagaTodaInterligacao()
	{
		try
		{
			string text = "";
			text = "DELETE FROM Bornes4I ";
			object instance = db;
			object[] array = new object[1] { text };
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "ExecuteNonQuery", array, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			text = "DELETE FROM Cabos4";
			object instance2 = db;
			object[] array3 = new object[1] { text };
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "ExecuteNonQuery", array3, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			text = "DELETE FROM Veias4";
			object instance3 = db;
			object[] array4 = new object[1] { text };
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "ExecuteNonQuery", array4, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			text = "DELETE FROM Interligacao4";
			object instance4 = db;
			object[] array5 = new object[1] { text };
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "ExecuteNonQuery", array5, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			text = "DELETE FROM Jumper4";
			object instance5 = db;
			object[] array6 = new object[1] { text };
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "ExecuteNonQuery", array6, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			text = "DELETE FROM Portas4I";
			object instance6 = db;
			object[] array7 = new object[1] { text };
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "ExecuteNonQuery", array7, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			text = "DELETE FROM Aranha4";
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

	public void ApagaLMExportada()
	{
		try
		{
			string text = "";
			text = "DELETE FROM ListaMateriais";
			object instance = db;
			object[] array = new object[1] { text };
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "ExecuteNonQuery", array, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public void ApagaPlaquetasExportada()
	{
		try
		{
			string text = "";
			text = "DELETE FROM Plaquetas4";
			object instance = db;
			object[] array = new object[1] { text };
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "ExecuteNonQuery", array, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public void ApagaAranha4()
	{
		try
		{
			string text = "";
			text = "DELETE FROM Aranha4 ";
			object instance = db;
			object[] array = new object[1] { text };
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "ExecuteNonQuery", array, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}
}
