using System;
using System.Data;
using System.Data.OleDb;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class cDadosAccessComum
{
	public object db;

	public void fechaConexao()
	{
		NewLateBinding.LateCall(db, null, "fechaConexao", new object[0], null, null, null, IgnoreReturn: true);
	}

	public cDadosAccessComum()
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

	public void AtualizaUserData(string sTabela, string sCampo, string sValor)
	{
		try
		{
			string text = "@" + sCampo;
			string text2 = "UPDATE " + sTabela + " SET " + sCampo + "=" + text;
			object instance = db;
			object[] array = new object[3]
			{
				text,
				sValor,
				OleDbType.Char
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { true, true, false }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			sValor = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[1] { text2 };
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "ExecuteNonQuery", array3, null, null, new bool[1] { true }, IgnoreReturn: true);
			text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public void AtualizaUserDataBD(string sTabela, string sCampo, DateTime sValor)
	{
		try
		{
			string text = "@" + sCampo;
			string text2 = "UPDATE " + sTabela + " SET " + sCampo + "=" + text;
			object instance = db;
			object[] array = new object[3]
			{
				text,
				sValor,
				OleDbType.Date
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { true, true, false }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			sValor = (DateTime)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(DateTime));
			object instance2 = db;
			object[] array3 = new object[1] { text2 };
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "ExecuteNonQuery", array3, null, null, new bool[1] { true }, IgnoreReturn: true);
			text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public void LeConfiguracao(ref string sComando, int iIndice, string sTipo, string sRelatorio)
	{
		if (!clsAuxiliar.BancoValido())
		{
			return;
		}
		string text = "SELECT * FROM CONFIGURACOES WHERE Indice=@indice AND Tipo=@tipo AND Comando=@comando";
		object instance = db;
		object[] array = new object[3]
		{
			"@indice",
			iIndice,
			OleDbType.Integer
		};
		object[] array2 = array;
		NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		iIndice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
		object instance2 = db;
		object[] array3 = new object[3]
		{
			"@tipo",
			sTipo,
			OleDbType.Char
		};
		array2 = array3;
		NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sTipo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance3 = db;
		object[] array4 = new object[3]
		{
			"@comando",
			sRelatorio,
			OleDbType.Char
		};
		array2 = array4;
		NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sRelatorio = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance4 = db;
		object[] array5 = new object[1] { text };
		array2 = array5;
		object obj = NewLateBinding.LateGet(instance4, null, "ExecuteReader", array5, null, null, new bool[1] { true });
		text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		DataTable dataTable = (DataTable)obj;
		if (dataTable.Rows.Count != 1)
		{
			sComando = "";
			return;
		}
		checked
		{
			int num = dataTable.Columns.Count - 1;
			int num2 = num;
			while (true)
			{
				if (num2 >= 0)
				{
					if (Operators.CompareString(dataTable.Columns[num2].ColumnName, "Valor", TextCompare: true) == 0)
					{
						break;
					}
					num2 += -1;
					continue;
				}
				return;
			}
			sComando = Strings.Trim(Conversions.ToString(dataTable.Rows[0][num2]));
		}
	}

	public DataTable LeConfiguracaoRelatorio(string sTipo, string sRelatorio)
	{
		DataTable result = null;
		if (clsAuxiliar.BancoValido())
		{
			string text = "SELECT * FROM CONFIGURACOES WHERE Tipo=@tipo AND Comando=@comando";
			object instance = db;
			object[] array = new object[3]
			{
				"@tipo",
				sTipo,
				OleDbType.Char
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			sTipo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@comando",
				sRelatorio,
				OleDbType.Char
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			sRelatorio = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			DataTable dataTable = null;
			object instance3 = db;
			object[] array4 = new object[1] { text };
			array2 = array4;
			object obj = NewLateBinding.LateGet(instance3, null, "ExecuteReader", array4, null, null, new bool[1] { true });
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			dataTable = (DataTable)obj;
			if (dataTable.Rows.Count > 0)
			{
				result = dataTable;
			}
			return result;
		}
		return result;
	}

	public void GravaConfiguracao(string sComando, int iIndice, string sTipo, string sRelatorio)
	{
		string text = "DELETE FROM CONFIGURACOES WHERE Indice=@indice AND Tipo=@tipo AND Comando=@comando";
		object instance = db;
		object[] array = new object[3]
		{
			"@indice",
			iIndice,
			OleDbType.Integer
		};
		object[] array2 = array;
		NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		iIndice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
		object instance2 = db;
		object[] array3 = new object[3]
		{
			"@tipo",
			sTipo,
			OleDbType.Char
		};
		array2 = array3;
		NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sTipo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance3 = db;
		object[] array4 = new object[3]
		{
			"@comando",
			sRelatorio,
			OleDbType.Char
		};
		array2 = array4;
		NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sRelatorio = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance4 = db;
		object[] array5 = new object[1] { text };
		array2 = array5;
		NewLateBinding.LateCall(instance4, null, "ExecuteNonQuery", array5, null, null, new bool[1] { true }, IgnoreReturn: true);
		text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		text = "Insert into CONFIGURACOES(Indice, Tipo, Comando, Valor) VALUES(@indice, @tipo, @comando , @valor)";
		object instance5 = db;
		object[] array6 = new object[3]
		{
			"@indice",
			iIndice,
			OleDbType.Integer
		};
		array2 = array6;
		NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		iIndice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
		object instance6 = db;
		object[] array7 = new object[3]
		{
			"@tipo",
			sTipo,
			OleDbType.Char
		};
		array2 = array7;
		NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sTipo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance7 = db;
		object[] array8 = new object[3]
		{
			"@comando",
			sRelatorio,
			OleDbType.Char
		};
		array2 = array8;
		NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sRelatorio = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance8 = db;
		object[] array9 = new object[3]
		{
			"@valor",
			sComando,
			OleDbType.Char
		};
		array2 = array9;
		NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sComando = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance9 = db;
		object[] array10 = new object[1] { text };
		array2 = array10;
		NewLateBinding.LateCall(instance9, null, "ExecuteNonQuery", array10, null, null, new bool[1] { true }, IgnoreReturn: true);
		text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
	}
}
