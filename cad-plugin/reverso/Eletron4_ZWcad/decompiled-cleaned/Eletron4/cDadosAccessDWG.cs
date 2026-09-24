using System;
using System.Data;
using System.Data.OleDb;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class cDadosAccessDWG
{
	public object db;

	private string MGdphAnH26;

	public void fechaConexao()
	{
		NewLateBinding.LateCall(db, null, "fechaConexao", new object[0], null, null, null, IgnoreReturn: true);
	}

	public cDadosAccessDWG()
	{
		MGdphAnH26 = "";
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

	public bool ExisteArquivo(string sTabela, string sNome)
	{
		bool result = false;
		MGdphAnH26 = "SELECT * FROM " + sTabela + " WHERE Nome=@nome";
		object instance = db;
		object[] array = new object[3]
		{
			"@nome",
			sNome,
			OleDbType.Char
		};
		object[] array2 = array;
		NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sNome = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance2 = db;
		object[] array3 = new object[1];
		ref string mGdphAnH = ref MGdphAnH26;
		array3[0] = mGdphAnH;
		array2 = array3;
		object left = NewLateBinding.LateGet(instance2, null, "ExecuteQuery", array3, null, null, new bool[1] { true });
		mGdphAnH = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		if (Operators.ConditionalCompareObjectEqual(left, true, TextCompare: true))
		{
			result = true;
		}
		return result;
	}

	public bool BuscaIndice(string sTabela, string iIndice)
	{
		MGdphAnH26 = "SELECT indice FROM " + sTabela + " WHERE indice=@iIndice";
		object instance = db;
		object[] array = new object[3]
		{
			"@iIndice",
			iIndice,
			OleDbType.Integer
		};
		object[] array2 = array;
		NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		iIndice = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance2 = db;
		object[] array3 = new object[1];
		ref string mGdphAnH = ref MGdphAnH26;
		array3[0] = mGdphAnH;
		array2 = array3;
		object value = NewLateBinding.LateGet(instance2, null, "ExecuteQuery", array3, null, null, new bool[1] { true });
		mGdphAnH = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		return Conversions.ToBoolean(value);
	}

	public int BuscaIndiceArquivo(string sTabela, string sNome)
	{
		int num = 0;
		MGdphAnH26 = "SELECT indice FROM " + sTabela + " WHERE Nome=@nome";
		object instance = db;
		object[] array = new object[3]
		{
			"@nome",
			sNome,
			OleDbType.Char
		};
		object[] array2 = array;
		NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sNome = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance2 = db;
		object[] array3 = new object[1];
		ref string mGdphAnH = ref MGdphAnH26;
		array3[0] = mGdphAnH;
		array2 = array3;
		object value = NewLateBinding.LateGet(instance2, null, "ExecuteScalar", array3, null, null, new bool[1] { true });
		mGdphAnH = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		return Conversions.ToInteger(value);
	}

	public int ProximoIndice(string DWG)
	{
		int num = 1;
		MGdphAnH26 = "SELECT * FROM " + DWG + " WHERE Indice IS NOT NULL";
		object instance = db;
		object[] array = new object[1];
		ref string mGdphAnH = ref MGdphAnH26;
		ref string reference = ref mGdphAnH;
		array[0] = mGdphAnH;
		object[] array2 = array;
		object left = NewLateBinding.LateGet(instance, null, "ExecuteQuery", array, null, null, new bool[1] { true });
		reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		if (!Operators.ConditionalCompareObjectEqual(left, false, TextCompare: true))
		{
			MGdphAnH26 = "SELECT MAX(Indice) FROM " + DWG + " WHERE Indice IS NOT NULL";
			object instance2 = db;
			object[] array3 = new object[1];
			ref string mGdphAnH2 = ref MGdphAnH26;
			reference = ref mGdphAnH2;
			array3[0] = mGdphAnH2;
			array2 = array3;
			left = NewLateBinding.LateGet(instance2, null, "ExecuteScalar", array3, null, null, new bool[1] { true });
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			num = Conversions.ToInteger(left);
			return checked(num + 1);
		}
		return 1;
	}

	public void AdicionaCaderno(string dwg, int indice, string scriador, string seditor, DateTime sData)
	{
		MGdphAnH26 = "Insert into " + dwg + "(Indice, Tipo, Caminho, Nome, Criador, Editor, Data) VALUES(@indice, 'F', @caminho, @nome, @criador, @editor, @data)";
		object instance = db;
		object[] array = new object[3]
		{
			"@indice",
			indice,
			OleDbType.Integer
		};
		object[] array2 = array;
		NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		indice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
		object instance2 = db;
		object[] array3 = new object[3] { "@caminho", null, null };
		ref string path = ref DeclaracoesGeral.arqAtivo.Path;
		ref string reference = ref path;
		array3[1] = path;
		array3[2] = OleDbType.Char;
		array2 = array3;
		NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance3 = db;
		object[] array4 = new object[3] { "@nome", null, null };
		ref string nome = ref DeclaracoesGeral.arqAtivo.Nome;
		reference = ref nome;
		array4[1] = nome;
		array4[2] = OleDbType.Char;
		array2 = array4;
		NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance4 = db;
		object[] array5 = new object[3]
		{
			"@criador",
			scriador,
			OleDbType.Char
		};
		array2 = array5;
		NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		scriador = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance5 = db;
		object[] array6 = new object[3]
		{
			"@editor",
			seditor,
			OleDbType.Char
		};
		array2 = array6;
		NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		seditor = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance6 = db;
		object[] array7 = new object[3]
		{
			"@data",
			sData,
			OleDbType.Date
		};
		array2 = array7;
		NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sData = (DateTime)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(DateTime));
		object instance7 = db;
		object[] array8 = new object[1];
		ref string mGdphAnH = ref MGdphAnH26;
		reference = ref mGdphAnH;
		array8[0] = mGdphAnH;
		array2 = array8;
		NewLateBinding.LateCall(instance7, null, "ExecuteNonQuery", array8, null, null, new bool[1] { true }, IgnoreReturn: true);
		reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
	}

	public void RecuperaDWG(string DWG, string DWGH, string sNome)
	{
		MGdphAnH26 = "INSERT INTO " + DWG + "(Indice, Tipo, Caminho, Nome, Criador, Editor, Data) ";
		ref string mGdphAnH = ref MGdphAnH26;
		mGdphAnH = mGdphAnH + "SELECT Indice, Tipo, Caminho, Nome, Criador, Editor, Data FROM " + DWGH + " WHERE Nome=@Nome";
		object instance = db;
		object[] array = new object[3]
		{
			"@Nome",
			sNome,
			OleDbType.Char
		};
		object[] array2 = array;
		NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sNome = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance2 = db;
		object[] array3 = new object[1];
		ref string mGdphAnH2 = ref MGdphAnH26;
		array3[0] = mGdphAnH2;
		array2 = array3;
		NewLateBinding.LateCall(instance2, null, "ExecuteNonQuery", array3, null, null, new bool[1] { true }, IgnoreReturn: true);
		mGdphAnH2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
	}

	public void AtualizaDWG(string DWG, string sEditor, DateTime sData, string sNome)
	{
		MGdphAnH26 = "UPDATE " + DWG + " SET Caminho=@caminho, Editor=@editor, Data=@data WHERE Nome=@Nome";
		object instance = db;
		object[] array = new object[3] { "@caminho", null, null };
		ref string path = ref DeclaracoesGeral.arqAtivo.Path;
		ref string reference = ref path;
		array[1] = path;
		array[2] = OleDbType.Char;
		object[] array2 = array;
		NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance2 = db;
		object[] array3 = new object[3]
		{
			"@editor",
			sEditor,
			OleDbType.Char
		};
		array2 = array3;
		NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sEditor = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance3 = db;
		object[] array4 = new object[3]
		{
			"@data",
			sData,
			OleDbType.Date
		};
		array2 = array4;
		NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sData = (DateTime)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(DateTime));
		object instance4 = db;
		object[] array5 = new object[3]
		{
			"@Nome",
			sNome,
			OleDbType.Char
		};
		array2 = array5;
		NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sNome = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance5 = db;
		object[] array6 = new object[1];
		ref string mGdphAnH = ref MGdphAnH26;
		reference = ref mGdphAnH;
		array6[0] = mGdphAnH;
		array2 = array6;
		NewLateBinding.LateCall(instance5, null, "ExecuteNonQuery", array6, null, null, new bool[1] { true }, IgnoreReturn: true);
		reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
	}

	public void AtualizaValores(string DWG, string sEditor, DateTime sData)
	{
		MGdphAnH26 = "UPDATE " + DWG + " SET Caminho=@caminho, Editor=@editor, Data=@data WHERE Indice=@indice";
		object instance = db;
		object[] array = new object[3] { "@caminho", null, null };
		ref string path = ref DeclaracoesGeral.arqAtivo.Path;
		ref string reference = ref path;
		array[1] = path;
		array[2] = OleDbType.Char;
		object[] array2 = array;
		NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance2 = db;
		object[] array3 = new object[3]
		{
			"@editor",
			sEditor,
			OleDbType.Char
		};
		array2 = array3;
		NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sEditor = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance3 = db;
		object[] array4 = new object[3]
		{
			"@data",
			sData,
			OleDbType.Date
		};
		array2 = array4;
		NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sData = (DateTime)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(DateTime));
		object instance4 = db;
		object[] array5 = new object[3] { "@indice", null, null };
		ref int indice = ref DeclaracoesGeral.arqAtivo.Indice;
		array5[1] = indice;
		array5[2] = OleDbType.Integer;
		array2 = array5;
		NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		indice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
		object instance5 = db;
		object[] array6 = new object[1];
		ref string mGdphAnH = ref MGdphAnH26;
		reference = ref mGdphAnH;
		array6[0] = mGdphAnH;
		array2 = array6;
		NewLateBinding.LateCall(instance5, null, "ExecuteNonQuery", array6, null, null, new bool[1] { true }, IgnoreReturn: true);
		reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
	}

	public void AtualizaCaminho(string DWG, int iIndice, string sCaminho, string sEditor, DateTime sData)
	{
		MGdphAnH26 = "UPDATE " + DWG + " SET Caminho=@caminho, Editor=@editor, Data=@data WHERE Indice=@indice";
		object instance = db;
		object[] array = new object[3]
		{
			"@caminho",
			sCaminho,
			OleDbType.Char
		};
		object[] array2 = array;
		NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sCaminho = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance2 = db;
		object[] array3 = new object[3]
		{
			"@editor",
			sEditor,
			OleDbType.Char
		};
		array2 = array3;
		NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sEditor = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance3 = db;
		object[] array4 = new object[3]
		{
			"@data",
			sData,
			OleDbType.Date
		};
		array2 = array4;
		NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sData = (DateTime)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(DateTime));
		object instance4 = db;
		object[] array5 = new object[3]
		{
			"@indice",
			iIndice,
			OleDbType.Integer
		};
		array2 = array5;
		NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		iIndice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
		object instance5 = db;
		object[] array6 = new object[1];
		ref string mGdphAnH = ref MGdphAnH26;
		array6[0] = mGdphAnH;
		array2 = array6;
		NewLateBinding.LateCall(instance5, null, "ExecuteNonQuery", array6, null, null, new bool[1] { true }, IgnoreReturn: true);
		mGdphAnH = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
	}

	public void RemoveDWG(string DWG, string sNome)
	{
		MGdphAnH26 = "DELETE FROM " + DWG + " WHERE Nome=@Nome";
		object instance = db;
		object[] array = new object[3]
		{
			"@Nome",
			sNome,
			OleDbType.Char
		};
		object[] array2 = array;
		NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sNome = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance2 = db;
		object[] array3 = new object[1];
		ref string mGdphAnH = ref MGdphAnH26;
		array3[0] = mGdphAnH;
		array2 = array3;
		NewLateBinding.LateCall(instance2, null, "ExecuteNonQuery", array3, null, null, new bool[1] { true }, IgnoreReturn: true);
		mGdphAnH = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
	}

	public void AtualizaCaderno(string DWG, string sEditor, DateTime sData, int indice)
	{
		MGdphAnH26 = "UPDATE " + DWG + " SET Tipo='F', Caminho=@caminho, Nome=@nome, Editor=@editor, Data=@data WHERE Indice=@indice";
		object instance = db;
		object[] array = new object[3] { "@caminho", null, null };
		ref string path = ref DeclaracoesGeral.arqAtivo.Path;
		ref string reference = ref path;
		array[1] = path;
		array[2] = OleDbType.Char;
		object[] array2 = array;
		NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance2 = db;
		object[] array3 = new object[3] { "@nome", null, null };
		ref string nome = ref DeclaracoesGeral.arqAtivo.Nome;
		reference = ref nome;
		array3[1] = nome;
		array3[2] = OleDbType.Char;
		array2 = array3;
		NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance3 = db;
		object[] array4 = new object[3]
		{
			"@editor",
			sEditor,
			OleDbType.Char
		};
		array2 = array4;
		NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sEditor = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance4 = db;
		object[] array5 = new object[3]
		{
			"@data",
			sData,
			OleDbType.Date
		};
		array2 = array5;
		NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sData = (DateTime)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(DateTime));
		object instance5 = db;
		object[] array6 = new object[3]
		{
			"@indice",
			indice,
			OleDbType.Integer
		};
		array2 = array6;
		NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		indice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
		object instance6 = db;
		object[] array7 = new object[1];
		ref string mGdphAnH = ref MGdphAnH26;
		reference = ref mGdphAnH;
		array7[0] = mGdphAnH;
		array2 = array7;
		NewLateBinding.LateCall(instance6, null, "ExecuteNonQuery", array7, null, null, new bool[1] { true }, IgnoreReturn: true);
		reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
	}

	public DataTable atualizaDG(string ordenacao)
	{
		DataTable dataTable = null;
		if (Operators.CompareString(ordenacao, "ASC", TextCompare: true) != 0)
		{
			if (Operators.CompareString(ordenacao, "DESC", TextCompare: true) == 0)
			{
				MGdphAnH26 = "SELECT * FROM DWG WHERE Indice IS NOT NULL ORDER BY Indice DESC";
			}
		}
		else
		{
			MGdphAnH26 = "SELECT * FROM DWG WHERE Indice IS NOT NULL ORDER BY Indice ASC";
		}
		object instance = db;
		object[] array = new object[1];
		ref string mGdphAnH = ref MGdphAnH26;
		array[0] = mGdphAnH;
		object[] array2 = array;
		object obj = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
		mGdphAnH = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		return (DataTable)obj;
	}

	public bool verificaArquivoExcluido(string DWGH, string sNome)
	{
		MGdphAnH26 = "SELECT * FROM " + DWGH + " WHERE Nome=@nome";
		object instance = db;
		object[] array = new object[3]
		{
			"@nome",
			sNome,
			OleDbType.Char
		};
		object[] array2 = array;
		NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
		sNome = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
		object instance2 = db;
		object[] array3 = new object[1];
		ref string mGdphAnH = ref MGdphAnH26;
		array3[0] = mGdphAnH;
		array2 = array3;
		object value = NewLateBinding.LateGet(instance2, null, "ExecuteQuery", array3, null, null, new bool[1] { true });
		mGdphAnH = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		return Conversions.ToBoolean(value);
	}
}
