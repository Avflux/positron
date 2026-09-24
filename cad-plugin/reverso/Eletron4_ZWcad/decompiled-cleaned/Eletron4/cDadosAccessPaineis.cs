using System;
using System.Data;
using System.Data.OleDb;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class cDadosAccessPaineis
{
	public object db;

	public void fechaConexao()
	{
		NewLateBinding.LateCall(db, null, "fechaConexao", new object[0], null, null, null, IgnoreReturn: true);
	}

	public cDadosAccessPaineis()
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

	public void AdicionaPainel(string sNomePainel, int iPainel, string sNome, string sCriador, string sEditor, DateTime sData)
	{
		string text = "Insert into " + sNomePainel + "(Indice, Nome, Criador, Editor, Data) VALUES(@indice, @nome, @criador, @editor, @data)";
		object instance = db;
		object[] array = new object[3]
		{
			"@indice",
			iPainel,
			OleDbType.Integer
		};
		object[] array2 = array;
		NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		iPainel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
		object instance2 = db;
		object[] array3 = new object[3]
		{
			"@nome",
			sNome,
			OleDbType.Char
		};
		array2 = array3;
		NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sNome = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance3 = db;
		object[] array4 = new object[3]
		{
			"@criador",
			sCriador,
			OleDbType.Char
		};
		array2 = array4;
		NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sCriador = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance4 = db;
		object[] array5 = new object[3]
		{
			"@editor",
			sEditor,
			OleDbType.Char
		};
		array2 = array5;
		NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sEditor = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance5 = db;
		object[] array6 = new object[3]
		{
			"@data",
			sData,
			OleDbType.Date
		};
		array2 = array6;
		NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sData = (DateTime)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(DateTime));
		object instance6 = db;
		object[] array7 = new object[1] { text };
		array2 = array7;
		NewLateBinding.LateCall(instance6, null, "ExecuteNonQuery", array7, null, null, new bool[1] { true }, IgnoreReturn: true);
		text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
	}

	public void ApagaOsPaineisDaTabela(int iPainel, string sTabela, string sPainel)
	{
		string text = "DELETE FROM " + sTabela + " WHERE " + sPainel + "=@indice";
		object instance = db;
		object[] array = new object[3]
		{
			"@indice",
			iPainel,
			OleDbType.Integer
		};
		object[] array2 = array;
		NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		iPainel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
		object instance2 = db;
		object[] array3 = new object[1] { text };
		array2 = array3;
		NewLateBinding.LateCall(instance2, null, "ExecuteNonQuery", array3, null, null, new bool[1] { true }, IgnoreReturn: true);
		text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
	}

	public bool ApagaPainel(string sTabela, int iPainel)
	{
		string text = "DELETE FROM " + sTabela + " WHERE indice=@indice";
		object instance = db;
		object[] array = new object[3]
		{
			"@indice",
			iPainel,
			OleDbType.Char
		};
		object[] array2 = array;
		NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		iPainel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
		object instance2 = db;
		object[] array3 = new object[1] { text };
		array2 = array3;
		object value = NewLateBinding.LateGet(instance2, null, "ExecuteQuery", array3, null, null, new bool[1] { true });
		text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		return Conversions.ToBoolean(value);
	}

	public void TrocaPaineis(int iDWG, int iPNO, int iPNN)
	{
		string text = "";
		text = "SELECT * FROM Fiacao WHERE DWG=@dwg";
		object instance = db;
		object[] array = new object[3]
		{
			"@dwg",
			iDWG,
			OleDbType.Integer
		};
		object[] array2 = array;
		NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
		object instance2 = db;
		object[] array3 = new object[1] { text };
		array2 = array3;
		object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
		text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		DataTable dataTable = (DataTable)obj;
		if (dataTable.Rows.Count > 0)
		{
			text = "UPDATE Fiacao SET Painel=@ipnn WHERE DWG=@dwg AND Painel=@ipno";
			object instance3 = db;
			object[] array4 = new object[3]
			{
				"@ipnn",
				iPNN,
				OleDbType.Integer
			};
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iPNN = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance4 = db;
			object[] array5 = new object[3]
			{
				"@dwg",
				iDWG,
				OleDbType.Integer
			};
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance5 = db;
			object[] array6 = new object[3]
			{
				"@ipno",
				iPNO,
				OleDbType.Integer
			};
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iPNO = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance6 = db;
			object[] array7 = new object[1] { text };
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "ExecuteNonQuery", array7, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		text = "SELECT * FROM Circuitos4F WHERE DWG=@dwg";
		NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
		{
			"@dwg",
			iDWG,
			OleDbType.Integer
		}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
		obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
		text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		dataTable = (DataTable)obj;
		if (dataTable.Rows.Count > 0)
		{
			text = "UPDATE Circuitos4F SET Painel=@ipnn WHERE DWG=@dwg AND Painel=@ipno";
			object instance7 = db;
			object[] array8 = new object[3]
			{
				"@ipnn",
				iPNN,
				OleDbType.Integer
			};
			array2 = array8;
			NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iPNN = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance8 = db;
			object[] array9 = new object[3]
			{
				"@dwg",
				iDWG,
				OleDbType.Integer
			};
			array2 = array9;
			NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance9 = db;
			object[] array10 = new object[3]
			{
				"@ipno",
				iPNO,
				OleDbType.Integer
			};
			array2 = array10;
			NewLateBinding.LateCall(instance9, null, "AddParameter", array10, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iPNO = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance10 = db;
			object[] array11 = new object[1] { text };
			array2 = array11;
			NewLateBinding.LateCall(instance10, null, "ExecuteNonQuery", array11, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		text = "SELECT * FROM Dispositivos4F WHERE DWG=@dwg";
		NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
		{
			"@dwg",
			iDWG,
			OleDbType.Integer
		}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
		obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
		text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		dataTable = (DataTable)obj;
		if (dataTable.Rows.Count > 0)
		{
			text = "UPDATE Dispositivos4F SET Painel=@ipnn WHERE DWG=@dwg AND Painel=@ipno";
			object instance11 = db;
			object[] array12 = new object[3]
			{
				"@ipnn",
				iPNN,
				OleDbType.Integer
			};
			array2 = array12;
			NewLateBinding.LateCall(instance11, null, "AddParameter", array12, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iPNN = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance12 = db;
			object[] array13 = new object[3]
			{
				"@dwg",
				iDWG,
				OleDbType.Integer
			};
			array2 = array13;
			NewLateBinding.LateCall(instance12, null, "AddParameter", array13, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance13 = db;
			object[] array14 = new object[3]
			{
				"@ipno",
				iPNO,
				OleDbType.Integer
			};
			array2 = array14;
			NewLateBinding.LateCall(instance13, null, "AddParameter", array14, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iPNO = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance14 = db;
			object[] array15 = new object[1] { text };
			array2 = array15;
			NewLateBinding.LateCall(instance14, null, "ExecuteNonQuery", array15, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		text = "SELECT * FROM Bornes4F WHERE DWG=@dwg";
		NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
		{
			"@dwg",
			iDWG,
			OleDbType.Integer
		}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
		obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
		text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		dataTable = (DataTable)obj;
		if (dataTable.Rows.Count > 0)
		{
			text = "UPDATE Bornes4F SET Painel=@ipnn WHERE DWG=@dwg AND Painel=@ipno";
			object instance15 = db;
			object[] array16 = new object[3]
			{
				"@ipnn",
				iPNN,
				OleDbType.Integer
			};
			array2 = array16;
			NewLateBinding.LateCall(instance15, null, "AddParameter", array16, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iPNN = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance16 = db;
			object[] array17 = new object[3]
			{
				"@dwg",
				iDWG,
				OleDbType.Integer
			};
			array2 = array17;
			NewLateBinding.LateCall(instance16, null, "AddParameter", array17, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance17 = db;
			object[] array18 = new object[3]
			{
				"@ipno",
				iPNO,
				OleDbType.Integer
			};
			array2 = array18;
			NewLateBinding.LateCall(instance17, null, "AddParameter", array18, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iPNO = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance18 = db;
			object[] array19 = new object[1] { text };
			array2 = array19;
			NewLateBinding.LateCall(instance18, null, "ExecuteNonQuery", array19, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		text = "SELECT  * FROM ListaMateriais WHERE DWG=@dwg";
		NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
		{
			"@dwg",
			iDWG,
			OleDbType.Integer
		}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
		obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
		text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		dataTable = (DataTable)obj;
		if (dataTable.Rows.Count > 0)
		{
			text = "UPDATE ListaMateriais SET Painel=@ipnn WHERE DWG=@dwg AND Painel=@ipno";
			object instance19 = db;
			object[] array20 = new object[3]
			{
				"@ipnn",
				iPNN,
				OleDbType.Integer
			};
			array2 = array20;
			NewLateBinding.LateCall(instance19, null, "AddParameter", array20, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iPNN = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance20 = db;
			object[] array21 = new object[3]
			{
				"@dwg",
				iDWG,
				OleDbType.Integer
			};
			array2 = array21;
			NewLateBinding.LateCall(instance20, null, "AddParameter", array21, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance21 = db;
			object[] array22 = new object[3]
			{
				"@ipno",
				iPNO,
				OleDbType.Integer
			};
			array2 = array22;
			NewLateBinding.LateCall(instance21, null, "AddParameter", array22, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iPNO = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance22 = db;
			object[] array23 = new object[1] { text };
			array2 = array23;
			NewLateBinding.LateCall(instance22, null, "ExecuteNonQuery", array23, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		text = "SELECT  * FROM Plaquetas4 WHERE DWG=@dwg";
		NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
		{
			"@dwg",
			iDWG,
			OleDbType.Integer
		}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
		obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
		text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		dataTable = (DataTable)obj;
		if (dataTable.Rows.Count > 0)
		{
			text = "UPDATE Plaquetas4 SET Painel=@ipnn WHERE DWG=@dwg AND Painel=@ipno";
			object instance23 = db;
			object[] array24 = new object[3]
			{
				"@ipnn",
				iPNN,
				OleDbType.Integer
			};
			array2 = array24;
			NewLateBinding.LateCall(instance23, null, "AddParameter", array24, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iPNN = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance24 = db;
			object[] array25 = new object[3]
			{
				"@dwg",
				iDWG,
				OleDbType.Integer
			};
			array2 = array25;
			NewLateBinding.LateCall(instance24, null, "AddParameter", array25, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance25 = db;
			object[] array26 = new object[3]
			{
				"@ipno",
				iPNO,
				OleDbType.Integer
			};
			array2 = array26;
			NewLateBinding.LateCall(instance25, null, "AddParameter", array26, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iPNO = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance26 = db;
			object[] array27 = new object[1] { text };
			array2 = array27;
			NewLateBinding.LateCall(instance26, null, "ExecuteNonQuery", array27, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		text = "SELECT * FROM Jumper4 WHERE DWG=@dwg";
		NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
		{
			"@dwg",
			iDWG,
			OleDbType.Integer
		}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
		obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
		text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		dataTable = (DataTable)obj;
		if (dataTable.Rows.Count > 0)
		{
			text = "UPDATE Jumper4 SET Painel=@ipnn WHERE DWG=@dwg AND Painel=@ipno";
			object instance27 = db;
			object[] array28 = new object[3]
			{
				"@ipnn",
				iPNN,
				OleDbType.Integer
			};
			array2 = array28;
			NewLateBinding.LateCall(instance27, null, "AddParameter", array28, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iPNN = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance28 = db;
			object[] array29 = new object[3]
			{
				"@dwg",
				iDWG,
				OleDbType.Integer
			};
			array2 = array29;
			NewLateBinding.LateCall(instance28, null, "AddParameter", array29, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance29 = db;
			object[] array30 = new object[3]
			{
				"@ipno",
				iPNO,
				OleDbType.Integer
			};
			array2 = array30;
			NewLateBinding.LateCall(instance29, null, "AddParameter", array30, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iPNO = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance30 = db;
			object[] array31 = new object[1] { text };
			array2 = array31;
			NewLateBinding.LateCall(instance30, null, "ExecuteNonQuery", array31, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
	}

	public int ProximoIndicePainel()
	{
		int num = 1;
		int num2 = 1;
		string text = "";
		text = "SELECT * FROM Paineis WHERE Indice IS NOT NULL";
		object instance = db;
		object[] array = new object[1] { text };
		object[] array2 = array;
		object left = NewLateBinding.LateGet(instance, null, "ExecuteQuery", array, null, null, new bool[1] { true });
		text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		if (!Operators.ConditionalCompareObjectEqual(left, false, TextCompare: true))
		{
			text = "SELECT MAX(Indice) FROM Paineis WHERE Indice IS NOT NULL";
			object instance2 = db;
			object[] array3 = new object[1] { text };
			array2 = array3;
			left = NewLateBinding.LateGet(instance2, null, "ExecuteScalar", array3, null, null, new bool[1] { true });
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			num2 = Conversions.ToInteger(left);
			if (num2 > num)
			{
				num = num2;
			}
		}
		else
		{
			num2 = 1;
		}
		text = "SELECT * FROM PaineisH WHERE Indice IS NOT NULL";
		left = NewLateBinding.LateGet(db, null, "ExecuteQuery", array2 = new object[1] { text }, null, null, new bool[1] { true });
		text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		if (!Operators.ConditionalCompareObjectEqual(left, false, TextCompare: true))
		{
			text = "SELECT MAX(Indice) FROM PaineisH WHERE Indice IS NOT NULL";
			object instance3 = db;
			object[] array4 = new object[1] { text };
			array2 = array4;
			left = NewLateBinding.LateGet(instance3, null, "ExecuteScalar", array4, null, null, new bool[1] { true });
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			num2 = Conversions.ToInteger(left);
			if (num2 > num)
			{
				num = num2;
			}
		}
		else
		{
			num2 = 1;
		}
		return checked(num + 1);
	}
}
