using System;
using System.Data;
using System.Data.OleDb;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class cDadosAccessExpImp
{
	public object db;

	public void fechaConexao()
	{
		NewLateBinding.LateCall(db, null, "fechaConexao", new object[0], null, null, null, IgnoreReturn: true);
	}

	public cDadosAccessExpImp()
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

	public int gravaDispExportado(ref DeclaracoesEntidades.StructureExportar exp)
	{
		int result = 0;
		try
		{
			string text = "Insert into Exportados(Codigo, Tipo, DWG, Caderno, Handle, Pagina, Posicao, Painel, Texto, DWGDest, CadernoDest, PaginaDest, PosicaoDest, NomeRegua, IndexModelo, Atualizado) VALUES(@codigo, @tipo, @dwg, @caderno, @handle, @pagina, @posicao, @painel, @texto, @dwgDest, @cadernoDest, @paginadest, @posicaoDest, @nomeRegua, @indexModelo, @atualizado)";
			object instance = db;
			object[] array = new object[3] { "@codigo", null, null };
			ref int codigo = ref exp.Codigo;
			ref int reference = ref codigo;
			array[1] = codigo;
			array[2] = OleDbType.Integer;
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance2 = db;
			object[] array3 = new object[3] { "@tipo", null, null };
			ref string tipo = ref exp.Tipo;
			ref string reference2 = ref tipo;
			array3[1] = tipo;
			array3[2] = OleDbType.Char;
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance3 = db;
			object[] array4 = new object[3] { "@dwg", null, null };
			ref int dWG = ref exp.DWG;
			reference = ref dWG;
			array4[1] = dWG;
			array4[2] = OleDbType.Integer;
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance4 = db;
			object[] array5 = new object[3] { "@caderno", null, null };
			ref string caderno = ref exp.Caderno;
			reference2 = ref caderno;
			array5[1] = caderno;
			array5[2] = OleDbType.Char;
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance5 = db;
			object[] array6 = new object[3] { "@handle", null, null };
			ref string handle = ref exp.Handle;
			reference2 = ref handle;
			array6[1] = handle;
			array6[2] = OleDbType.Char;
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance6 = db;
			object[] array7 = new object[3] { "@pagina", null, null };
			ref string pagina = ref exp.Pagina;
			reference2 = ref pagina;
			array7[1] = pagina;
			array7[2] = OleDbType.Char;
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance7 = db;
			object[] array8 = new object[3] { "@posicao", null, null };
			ref string posicao = ref exp.posicao;
			reference2 = ref posicao;
			array8[1] = posicao;
			array8[2] = OleDbType.Char;
			array2 = array8;
			NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance8 = db;
			object[] array9 = new object[3] { "@painel", null, null };
			ref int painel = ref exp.Painel;
			reference = ref painel;
			array9[1] = painel;
			array9[2] = OleDbType.Integer;
			array2 = array9;
			NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance9 = db;
			object[] array10 = new object[3] { "@texto", null, null };
			ref string texto = ref exp.Texto;
			reference2 = ref texto;
			array10[1] = texto;
			array10[2] = OleDbType.Char;
			array2 = array10;
			NewLateBinding.LateCall(instance9, null, "AddParameter", array10, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance10 = db;
			object[] array11 = new object[3] { "@dwgDest", null, null };
			ref int dWGDest = ref exp.DWGDest;
			reference = ref dWGDest;
			array11[1] = dWGDest;
			array11[2] = OleDbType.Integer;
			array2 = array11;
			NewLateBinding.LateCall(instance10, null, "AddParameter", array11, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance11 = db;
			object[] array12 = new object[3] { "@cadernoDest", null, null };
			ref string cadernoDest = ref exp.CadernoDest;
			reference2 = ref cadernoDest;
			array12[1] = cadernoDest;
			array12[2] = OleDbType.Char;
			array2 = array12;
			NewLateBinding.LateCall(instance11, null, "AddParameter", array12, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance12 = db;
			object[] array13 = new object[3] { "@paginadest", null, null };
			ref string paginaDest = ref exp.PaginaDest;
			reference2 = ref paginaDest;
			array13[1] = paginaDest;
			array13[2] = OleDbType.Char;
			array2 = array13;
			NewLateBinding.LateCall(instance12, null, "AddParameter", array13, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance13 = db;
			object[] array14 = new object[3] { "@posicaoDest", null, null };
			ref string posicaoDest = ref exp.PosicaoDest;
			reference2 = ref posicaoDest;
			array14[1] = posicaoDest;
			array14[2] = OleDbType.Char;
			array2 = array14;
			NewLateBinding.LateCall(instance13, null, "AddParameter", array14, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance14 = db;
			object[] array15 = new object[3] { "@nomeRegua", null, null };
			ref string nomeRegua = ref exp.NomeRegua;
			reference2 = ref nomeRegua;
			array15[1] = nomeRegua;
			array15[2] = OleDbType.Char;
			array2 = array15;
			NewLateBinding.LateCall(instance14, null, "AddParameter", array15, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance15 = db;
			object[] array16 = new object[3] { "@indexModelo", null, null };
			ref int indexModelo = ref exp.indexModelo;
			reference = ref indexModelo;
			array16[1] = indexModelo;
			array16[2] = OleDbType.Integer;
			array2 = array16;
			NewLateBinding.LateCall(instance15, null, "AddParameter", array16, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance16 = db;
			object[] array17 = new object[3] { "@atualizado", null, null };
			ref bool atualizado = ref exp.Atualizado;
			array17[1] = atualizado;
			array17[2] = OleDbType.Boolean;
			array2 = array17;
			NewLateBinding.LateCall(instance16, null, "AddParameter", array17, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			atualizado = (bool)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(bool));
			object instance17 = db;
			object[] array18 = new object[1] { text };
			array2 = array18;
			NewLateBinding.LateCall(instance17, null, "ExecuteNonQuery", array18, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			text = "SELECT MAX(Indice) FROM Exportados";
			object instance18 = db;
			object[] array19 = new object[1] { text };
			array2 = array19;
			object obj = NewLateBinding.LateGet(instance18, null, "ExecuteReader", array19, null, null, new bool[1] { true });
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			DataTable dataTable = (DataTable)obj;
			if (dataTable.Rows.Count > 0)
			{
				result = Conversions.ToInteger(dataTable.Rows[0][0]);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		return result;
	}

	public void gravaAtributoExportado(int dwg, string handle, string nome, string valor)
	{
		try
		{
			string text = "Insert into Atributos(DWG, Handle, Nome, Valor) VALUES(@dwg, @handle, @nome, @valor)";
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
				"@handle",
				handle,
				OleDbType.Char
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			handle = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance3 = db;
			object[] array4 = new object[3]
			{
				"@nome",
				nome,
				OleDbType.Char
			};
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			nome = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public bool carregaDestinos(int indice, ref string CadernoDest, ref string paginaDest, ref string posicaoDest)
	{
		bool result = false;
		try
		{
			string text = "SELECT CadernoDest, PaginaDest, PosicaoDest FROM Exportados WHERE DWGDest<>0 AND Indice=@indice";
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
			object[] array3 = new object[1] { text };
			array2 = array3;
			object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			DataTable dataTable = (DataTable)obj;
			if (dataTable.Rows.Count == 1)
			{
				CadernoDest = Conversions.ToString(dataTable.Rows[0][0]);
				paginaDest = Conversions.ToString(dataTable.Rows[0][1]);
				posicaoDest = Conversions.ToString(dataTable.Rows[0][2]);
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

	public bool lerValorAtributo(int dwg, string handle, string nome, ref string valor)
	{
		bool result = false;
		try
		{
			string text = "SELECT Valor FROM Atributos WHERE DWG=@dwg AND Handle=@handle AND Nome=@nome";
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
				"@handle",
				handle,
				OleDbType.Char
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			handle = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance3 = db;
			object[] array4 = new object[3]
			{
				"@nome",
				nome,
				OleDbType.Char
			};
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			nome = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance4 = db;
			object[] array5 = new object[1] { text };
			array2 = array5;
			object obj = NewLateBinding.LateGet(instance4, null, "ExecuteReader", array5, null, null, new bool[1] { true });
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			DataTable dataTable = (DataTable)obj;
			if (dataTable.Rows.Count == 1)
			{
				valor = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][0]));
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

	public void setaAtualizadoFalseDWG(int dwg)
	{
		try
		{
			string text = "";
			text = "UPDATE Exportados SET Atualizado=@atualizado WHERE DWG=@dwg";
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@atualizado",
				false,
				OleDbType.Boolean
			}, null, null, null, IgnoreReturn: true);
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
			NewLateBinding.LateCall(instance2, null, "ExecuteNonQuery", array3, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public void setaAtualizadoFalseDWGDestino(int dwg)
	{
		try
		{
			string text = "";
			text = "UPDATE Exportados SET Atualizado=@atualizado WHERE DWGDest=@dwgDest";
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@atualizado",
				false,
				OleDbType.Boolean
			}, null, null, null, IgnoreReturn: true);
			object instance = db;
			object[] array = new object[3]
			{
				"@dwgDest",
				dwg,
				OleDbType.Integer
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			dwg = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance2 = db;
			object[] array3 = new object[1] { text };
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "ExecuteNonQuery", array3, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public void ApagaAtributos(int dwg)
	{
		try
		{
			string text = "";
			text = "DELETE FROM Atributos WHERE DWG=@dwg";
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

	public void ApagaAtributosHandle(int dwg, string Handle)
	{
		try
		{
			string text = "";
			text = "DELETE FROM Atributos WHERE DWG=@dwg AND Handle=@handle";
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
				"@handle",
				Handle,
				OleDbType.Char
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			Handle = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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

	public void ApagaRegistros(int dwg)
	{
		try
		{
			string text = "";
			text = "DELETE FROM Exportados WHERE DWG=@dwg AND Atualizado=@atualizado";
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
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@atualizado",
				false,
				OleDbType.Boolean
			}, null, null, null, IgnoreReturn: true);
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

	public void ApagaRegistroInvalido(int indice, int codigo, string handle)
	{
		try
		{
			string text = "";
			text = "DELETE FROM Exportados WHERE Indice=@indice AND Codigo=@codigo AND Handle=@handle";
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
			object[] array3 = new object[3]
			{
				"@codigo",
				codigo,
				OleDbType.Integer
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			codigo = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
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
			object[] array5 = new object[1] { text };
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "ExecuteNonQuery", array5, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}

	public void AtualizaRegistro(int indice, ref DeclaracoesEntidades.StructureExportar exp)
	{
		try
		{
			string text = "";
			text = "UPDATE Exportados SET Codigo=@codigo, Tipo=@tipo, DWG=@dwg, Caderno=@caderno, Handle=@handle, Pagina=@pagina, Posicao=@posicao, Painel=@painel, Texto=@texto, NomeRegua=@nomeRegua, IndexModelo=@indexModelo, Atualizado=@atualizado WHERE Indice=@indice";
			object instance = db;
			object[] array = new object[3] { "@codigo", null, null };
			ref int codigo = ref exp.Codigo;
			ref int reference = ref codigo;
			array[1] = codigo;
			array[2] = OleDbType.Integer;
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance2 = db;
			object[] array3 = new object[3] { "@tipo", null, null };
			ref string tipo = ref exp.Tipo;
			ref string reference2 = ref tipo;
			array3[1] = tipo;
			array3[2] = OleDbType.Char;
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance3 = db;
			object[] array4 = new object[3] { "@dwg", null, null };
			ref int dWG = ref exp.DWG;
			reference = ref dWG;
			array4[1] = dWG;
			array4[2] = OleDbType.Integer;
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance4 = db;
			object[] array5 = new object[3] { "@caderno", null, null };
			ref string caderno = ref exp.Caderno;
			reference2 = ref caderno;
			array5[1] = caderno;
			array5[2] = OleDbType.Char;
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance5 = db;
			object[] array6 = new object[3] { "@handle", null, null };
			ref string handle = ref exp.Handle;
			reference2 = ref handle;
			array6[1] = handle;
			array6[2] = OleDbType.Char;
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance6 = db;
			object[] array7 = new object[3] { "@pagina", null, null };
			ref string pagina = ref exp.Pagina;
			reference2 = ref pagina;
			array7[1] = pagina;
			array7[2] = OleDbType.Char;
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance7 = db;
			object[] array8 = new object[3] { "@posicao", null, null };
			ref string posicao = ref exp.posicao;
			reference2 = ref posicao;
			array8[1] = posicao;
			array8[2] = OleDbType.Char;
			array2 = array8;
			NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance8 = db;
			object[] array9 = new object[3] { "@painel", null, null };
			ref int painel = ref exp.Painel;
			reference = ref painel;
			array9[1] = painel;
			array9[2] = OleDbType.Integer;
			array2 = array9;
			NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance9 = db;
			object[] array10 = new object[3] { "@texto", null, null };
			ref string texto = ref exp.Texto;
			reference2 = ref texto;
			array10[1] = texto;
			array10[2] = OleDbType.Char;
			array2 = array10;
			NewLateBinding.LateCall(instance9, null, "AddParameter", array10, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance10 = db;
			object[] array11 = new object[3] { "@nomeRegua", null, null };
			ref string nomeRegua = ref exp.NomeRegua;
			reference2 = ref nomeRegua;
			array11[1] = nomeRegua;
			array11[2] = OleDbType.Char;
			array2 = array11;
			NewLateBinding.LateCall(instance10, null, "AddParameter", array11, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance11 = db;
			object[] array12 = new object[3] { "@indexModelo", null, null };
			ref int indexModelo = ref exp.indexModelo;
			reference = ref indexModelo;
			array12[1] = indexModelo;
			array12[2] = OleDbType.Integer;
			array2 = array12;
			NewLateBinding.LateCall(instance11, null, "AddParameter", array12, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance12 = db;
			object[] array13 = new object[3] { "@atualizado", null, null };
			ref bool atualizado = ref exp.Atualizado;
			array13[1] = atualizado;
			array13[2] = OleDbType.Boolean;
			array2 = array13;
			NewLateBinding.LateCall(instance12, null, "AddParameter", array13, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			atualizado = (bool)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(bool));
			object instance13 = db;
			object[] array14 = new object[3]
			{
				"@indice",
				indice,
				OleDbType.Integer
			};
			array2 = array14;
			NewLateBinding.LateCall(instance13, null, "AddParameter", array14, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			indice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance14 = db;
			object[] array15 = new object[1] { text };
			array2 = array15;
			NewLateBinding.LateCall(instance14, null, "ExecuteNonQuery", array15, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}

	public void AtualizaRegistroDestino(int indice, ref DeclaracoesEntidades.StructureExportar exp)
	{
		try
		{
			string text = "";
			text = "UPDATE Exportados SET DWGDest=@dwgDest, CadernoDest=@cadernoDest, PaginaDest=@paginaDest, PosicaoDest=@posicaoDest, Atualizado=@atualizado WHERE Indice=@indice";
			object instance = db;
			object[] array = new object[3] { "@dwgDest", null, null };
			ref int dWGDest = ref exp.DWGDest;
			array[1] = dWGDest;
			array[2] = OleDbType.Integer;
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			dWGDest = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance2 = db;
			object[] array3 = new object[3] { "@cadernoDest", null, null };
			ref string cadernoDest = ref exp.CadernoDest;
			ref string reference = ref cadernoDest;
			array3[1] = cadernoDest;
			array3[2] = OleDbType.Char;
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance3 = db;
			object[] array4 = new object[3] { "@paginaDest", null, null };
			ref string paginaDest = ref exp.PaginaDest;
			reference = ref paginaDest;
			array4[1] = paginaDest;
			array4[2] = OleDbType.Char;
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance4 = db;
			object[] array5 = new object[3] { "@posicaoDest", null, null };
			ref string posicaoDest = ref exp.PosicaoDest;
			reference = ref posicaoDest;
			array5[1] = posicaoDest;
			array5[2] = OleDbType.Char;
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance5 = db;
			object[] array6 = new object[3] { "@atualizado", null, null };
			ref bool atualizado = ref exp.Atualizado;
			array6[1] = atualizado;
			array6[2] = OleDbType.Boolean;
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			atualizado = (bool)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(bool));
			object instance6 = db;
			object[] array7 = new object[3]
			{
				"@indice",
				indice,
				OleDbType.Integer
			};
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			indice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
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

	public void AlteraStatusImportadosApagados(int dwg)
	{
		try
		{
			string text = "";
			text = "UPDATE Exportados SET DWGDest=0 WHERE Atualizado=@atualizado AND DWGDest=@dwgDest";
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@atualizado",
				false,
				OleDbType.Boolean
			}, null, null, null, IgnoreReturn: true);
			object instance = db;
			object[] array = new object[3]
			{
				"@dwgDest",
				dwg,
				OleDbType.Integer
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			dwg = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
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

	public bool carregaExportadoParcial(int indice, ref DeclaracoesEntidades.StructureExportar exp)
	{
		bool result = false;
		try
		{
			string text = "SELECT Caderno, Pagina, Posicao, Painel, NomeRegua, IndexModelo, Texto FROM Exportados WHERE Indice=@indice";
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
			object[] array3 = new object[1] { text };
			array2 = array3;
			object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			DataTable dataTable = (DataTable)obj;
			if (dataTable.Rows.Count == 1)
			{
				exp.Caderno = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][0]));
				exp.Pagina = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][1]));
				exp.posicao = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][2]));
				exp.Painel = Conversions.ToInteger(clsTextos.TiraDBNullNumero(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][3])));
				exp.NomeRegua = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][4]));
				exp.indexModelo = Conversions.ToInteger(clsTextos.TiraDBNullNumero(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][5])));
				exp.Texto = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][6]));
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
}
