using System;
using System.Data;
using System.Data.OleDb;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class cDadosAccessMateriais
{
	public object db;

	public void fechaConexao()
	{
		NewLateBinding.LateCall(db, null, "fechaConexao", new object[0], null, null, null, IgnoreReturn: true);
	}

	public cDadosAccessMateriais()
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

	public void CarregaListaMateriaisDoDG(DataGridView dg, string sPesquisa = "")
	{
		checked
		{
			try
			{
				dg.Rows.Clear();
				dg.Columns.Clear();
				dg.Columns.Add("CodigoInterno", "#");
				dg.Columns.Add("CodigoCliente", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1385]));
				dg.Columns.Add("Modelo", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 654]));
				dg.Columns.Add("FabricanteS", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1169]));
				dg.Columns.Add("DescricaoResumida", "DescricaoResumida");
				dg.Columns.Add("DescricaoCompleta", "DescricaoCompleta");
				dg.Columns.Add("IndiceOriginal", "IndiceOriginal");
				dg.Columns.Add("Ação", "Ação");
				dg.Columns.Add("IndiceEL", "IndiceEL");
				dg.ColumnHeadersVisible = true;
				string text = "Select Indice, CodigoInterno, CodigoCliente, Modelo, Fabricante, DescricaoResumida, DescricaoCompleta FROM Materiais order by CodigoInterno";
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
					if (Operators.CompareString(sPesquisa, "", TextCompare: true) != 0)
					{
						string text2 = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][5]));
						if (text2.Contains(sPesquisa))
						{
							dg.Rows.Add(dataTable.Rows[i][1], clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][2])), clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][3])), clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][4])), clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][5])), clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][6])), clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][1])), "", dataTable.Rows[i][0]);
						}
					}
					else
					{
						dg.Rows.Add(dataTable.Rows[i][1], clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][2])), clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][3])), clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][4])), clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][5])), clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][6])), clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][1])), "", dataTable.Rows[i][0]);
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

	public void CarregaMateriaisStructure(ref DeclaracoesClonar.structureMaterial[] mat)
	{
		checked
		{
			try
			{
				string text = "Select CodigoInterno, CodigoCliente, Modelo, Fabricante, DescricaoResumida, DescricaoCompleta FROM Materiais order by CodigoInterno";
				object instance = db;
				object[] array = new object[1] { text };
				object[] array2 = array;
				object obj = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				mat = new DeclaracoesClonar.structureMaterial[1];
				int num = 1;
				if (dataTable.Rows.Count > 0)
				{
					int num2 = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num2; i++)
					{
						mat = (DeclaracoesClonar.structureMaterial[])Utils.CopyArray(mat, new DeclaracoesClonar.structureMaterial[num + 1]);
						mat[num].CodigoInterno = Conversions.ToInteger(dataTable.Rows[i][0]);
						mat[num].CodigoCliente = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][1]));
						mat[num].Modelo = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][2]));
						mat[num].Fabricante = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][3]));
						mat[num].DescricaoResumida = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][4]));
						mat[num].DescricaoCompleta = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][5]));
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

	public bool carregaMaterial(int indice, ref DeclaracoesClonar.structureMaterial mat)
	{
		bool result = false;
		try
		{
			string text = "Select CodigoInterno, CodigoCliente, DescricaoResumida, DescricaoCompleta, Modelo, Fabricante FROM Materiais WHERE CodigoInterno=@CodigoInterno";
			object instance = db;
			object[] array = new object[3]
			{
				"@CodigoInterno",
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
			if (dataTable.Rows.Count > 0)
			{
				mat.CodigoInterno = Conversions.ToInteger(dataTable.Rows[0][0]);
				mat.CodigoCliente = Conversions.ToString(dataTable.Rows[0][1]);
				mat.DescricaoResumida = Conversions.ToString(dataTable.Rows[0][2]);
				mat.DescricaoCompleta = Conversions.ToString(dataTable.Rows[0][3]);
				mat.Modelo = Conversions.ToString(dataTable.Rows[0][4]);
				mat.Fabricante = Conversions.ToString(dataTable.Rows[0][5]);
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

	public int BuscaMaiorCodigoInterno()
	{
		string text = "";
		int num = 0;
		text = "SELECT CodigoInterno FROM Materiais";
		object instance = db;
		object[] array = new object[1] { text };
		object[] array2 = array;
		object obj = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
		text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		DataTable dataTable = (DataTable)obj;
		checked
		{
			if (dataTable.Rows.Count > 0)
			{
				int num2 = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					if (Operators.ConditionalCompareObjectLess(num, dataTable.Rows[i][0], TextCompare: true))
					{
						num = Conversions.ToInteger(dataTable.Rows[i][0]);
					}
				}
			}
			return num;
		}
	}

	public void AdicionaItemMaterial(int CodigoInterno, string CodigoCliente, string Modelo, string Fabricante, string DescResumida, string DescCompleta)
	{
		try
		{
			string text = "";
			text = "Insert into Materiais(CodigoInterno, CodigoCliente, DescricaoResumida, DescricaoCompleta, Modelo, Fabricante) VALUES(@CodigoInterno, @CodigoCliente, @DescricaoResumida, @DescricaoCompleta, @Modelo, @Fabricante)";
			object instance = db;
			object[] array = new object[3]
			{
				"@CodigoInterno",
				CodigoInterno,
				OleDbType.Integer
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			CodigoInterno = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@CodigoCliente",
				CodigoCliente,
				OleDbType.Char
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			CodigoCliente = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance3 = db;
			object[] array4 = new object[3]
			{
				"@DescricaoResumida",
				DescResumida,
				OleDbType.Char
			};
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			DescResumida = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance4 = db;
			object[] array5 = new object[3]
			{
				"@DescricaoCompleta",
				DescCompleta,
				OleDbType.LongVarWChar
			};
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			DescCompleta = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance5 = db;
			object[] array6 = new object[3]
			{
				"@Modelo",
				Modelo,
				OleDbType.Char
			};
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			Modelo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance6 = db;
			object[] array7 = new object[3]
			{
				"@Fabricante",
				Fabricante,
				OleDbType.Char
			};
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			Fabricante = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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

	public void EditaItemMaterial(int CodigoInterno, string CodigoCliente, string Modelo, string Fabricante, string DescResumida, string DescCompleta)
	{
		try
		{
			string text = "";
			text = "UPDATE Materiais SET CodigoCliente=@CodigoCliente, DescricaoResumida=@DescricaoResumida, DescricaoCompleta=@DescricaoCompleta, Modelo=@Modelo, Fabricante=@Fabricante WHERE CodigoInterno=@CodigoInterno";
			object instance = db;
			object[] array = new object[3]
			{
				"@CodigoCliente",
				CodigoCliente,
				OleDbType.Char
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			CodigoCliente = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@DescricaoResumida",
				DescResumida,
				OleDbType.Char
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			DescResumida = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance3 = db;
			object[] array4 = new object[3]
			{
				"@DescricaoCompleta",
				DescCompleta,
				OleDbType.LongVarWChar
			};
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			DescCompleta = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance4 = db;
			object[] array5 = new object[3]
			{
				"@Modelo",
				Modelo,
				OleDbType.Char
			};
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			Modelo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance5 = db;
			object[] array6 = new object[3]
			{
				"@Fabricante",
				Fabricante,
				OleDbType.Char
			};
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			Fabricante = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance6 = db;
			object[] array7 = new object[3]
			{
				"@CodigoInterno",
				CodigoInterno,
				OleDbType.Integer
			};
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			CodigoInterno = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
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

	public void RemoveMateriaisLista(int dwg)
	{
		try
		{
			string text = "";
			text = "DELETE FROM ListaMateriais WHERE Dwg=@dwg and Avulso=@bAvulso";
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
				"@bAvulso",
				false,
				OleDbType.Boolean
			}, null, null, null, IgnoreReturn: true);
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

	public void RemoveMaterial(int CodigoInterno)
	{
		try
		{
			string text = "";
			text = "DELETE FROM Materiais WHERE CodigoInterno=@CodigoInterno ";
			object instance = db;
			object[] array = new object[3]
			{
				"@CodigoInterno",
				CodigoInterno,
				OleDbType.Integer
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			CodigoInterno = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
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

	public void CarregaOrdemEmMateriais(ref clsLM.Ordem[] OrdemLM)
	{
		checked
		{
			try
			{
				int num = 0;
				OrdemLM = new clsLM.Ordem[1];
				string text = "Select Indice, Tag, Painel, Ordem, IndiceMaterial FROM ListaMateriais WHERE DWG=@dwg Order By Painel, Ordem";
				object instance = db;
				object[] array = new object[3] { "@dwg", null, null };
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
				if (dataTable.Rows.Count > 0)
				{
					int num2 = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num2; i++)
					{
						num++;
						OrdemLM = (clsLM.Ordem[])Utils.CopyArray(OrdemLM, new clsLM.Ordem[num + 1]);
						OrdemLM[num].iIndice_LM = Conversions.ToInteger(dataTable.Rows[i][0]);
						OrdemLM[num].sTag = Conversions.ToString(dataTable.Rows[i][1]);
						OrdemLM[num].iPainel = Conversions.ToInteger(dataTable.Rows[i][2]);
						OrdemLM[num].iOrdem = Conversions.ToInteger(dataTable.Rows[i][3]);
						OrdemLM[num].Quantidade = 0;
						OrdemLM[num].IndiceMaterial = Conversions.ToInteger(dataTable.Rows[i][4]);
						OrdemLM[num].bEncontrado = false;
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

	public void CapturaMateriaisAvulso(ref clsLM.LMateriais[] mMateriais)
	{
		checked
		{
			try
			{
				string text = "Select DWG, Painel, Tag, IndiceMaterial, Quantidade, Ordem, Avulso, Destino, DescDestino, Alternativo, Handle, IndiceLM FROM ListaMateriais WHERE DWG=@dwg and Avulso = True ";
				object instance = db;
				object[] array = new object[3] { "@dwg", null, null };
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
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					int num2 = Information.UBound(mMateriais) + 1;
					mMateriais = (clsLM.LMateriais[])Utils.CopyArray(mMateriais, new clsLM.LMateriais[num2 + 1]);
					mMateriais[num2].sTipo = "Avulso";
					mMateriais[num2].Dwg = Conversions.ToInteger(dataTable.Rows[i][0]);
					mMateriais[num2].Painel = Conversions.ToInteger(dataTable.Rows[i][1]);
					mMateriais[num2].TagMat = Conversions.ToString(dataTable.Rows[i][2]);
					mMateriais[num2].IndiceMaterial = Conversions.ToInteger(dataTable.Rows[i][3]);
					mMateriais[num2].Quantidade = Conversions.ToInteger(dataTable.Rows[i][4]);
					mMateriais[num2].lOrdem = Conversions.ToLong(dataTable.Rows[i][5]);
					mMateriais[num2].Avulso = true;
					mMateriais[num2].TagAlternativo = "";
					mMateriais[num2].sHandle = "";
					if (Information.IsDBNull(dataTable.Rows[i][9].ToString()))
					{
						mMateriais[num2].TagAlternativo = Conversions.ToString(dataTable.Rows[i][9]);
					}
					if (Information.IsDBNull(dataTable.Rows[i][10].ToString()))
					{
						mMateriais[num2].sHandle = Conversions.ToString(dataTable.Rows[i][10]);
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

	public void RemoveItemMaterial(clsLM.LMateriais[] mMat)
	{
		checked
		{
			try
			{
				string text = "";
				text = "Select DWG, Painel, Tag, IndiceLM FROM ListaMateriais WHERE DWG=" + Conversions.ToString(DeclaracoesGeral.arqAtivo.Indice) + " and IndiceLM IS NOT NULL";
				object instance = db;
				object[] array = new object[1] { text };
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "ExecuteNonQuery", array, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				object instance2 = db;
				object[] array3 = new object[1] { text };
				array2 = array3;
				object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				int num = Information.UBound(mMat);
				for (int i = 1; i <= num; i++)
				{
					mMat[i].indexLM = 0;
				}
				if (dataTable.Rows.Count > 0)
				{
					int num2 = dataTable.Rows.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						int num3 = Information.UBound(mMat);
						for (int k = 1; k <= num3; k++)
						{
							if ((Conversions.ToInteger(dataTable.Rows[j][0]) == mMat[k].Dwg) & (Conversions.ToInteger(dataTable.Rows[j][1]) == mMat[k].Painel) & (Operators.CompareString(Conversions.ToString(dataTable.Rows[j][2]), mMat[k].TagMat, TextCompare: true) == 0))
							{
								mMat[k].indexLM = 0;
								if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dataTable.Rows[j][3])))
								{
									mMat[k].indexLM = Conversions.ToInteger(dataTable.Rows[j][3]);
								}
								break;
							}
						}
					}
				}
				text = "DELETE FROM ListaMateriais WHERE DWG=@dwg ";
				object instance3 = db;
				object[] array4 = new object[3] { "@dwg", null, null };
				ref int indice = ref DeclaracoesGeral.arqAtivo.Indice;
				ref int reference = ref indice;
				array4[1] = indice;
				array4[2] = OleDbType.Integer;
				array2 = array4;
				NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				int num4 = Information.UBound(mMat);
				for (int l = 1; l <= num4; l++)
				{
					text = "Insert into ListaMateriais(DWG, Painel, Tag, IndiceMaterial, Quantidade, Ordem, Avulso, Destino, DescDestino, Alternativo, Handle, IndiceLM, OrdemLay) VALUES(@dwg, @painel, @tag, @indiceMaterial, @quantidade, @ordem, @avulso, @destino, @descdestino, @tagAlt, @handle, @index, @OrdemLay)";
					object instance4 = db;
					object[] array5 = new object[3] { "@dwg", null, null };
					ref int dwg = ref mMat[l].Dwg;
					reference = ref dwg;
					array5[1] = dwg;
					array5[2] = OleDbType.Integer;
					array2 = array5;
					NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					object instance5 = db;
					object[] array6 = new object[3] { "@painel", null, null };
					ref int painel = ref mMat[l].Painel;
					reference = ref painel;
					array6[1] = painel;
					array6[2] = OleDbType.Integer;
					array2 = array6;
					NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					object instance6 = db;
					object[] array7 = new object[3] { "@tag", null, null };
					ref string tagMat = ref mMat[l].TagMat;
					ref string reference2 = ref tagMat;
					array7[1] = tagMat;
					array7[2] = OleDbType.Char;
					array2 = array7;
					NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance7 = db;
					object[] array8 = new object[3] { "@indiceMaterial", null, null };
					ref int indiceMaterial = ref mMat[l].IndiceMaterial;
					reference = ref indiceMaterial;
					array8[1] = indiceMaterial;
					array8[2] = OleDbType.Integer;
					array2 = array8;
					NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					object instance8 = db;
					object[] array9 = new object[3] { "@quantidade", null, null };
					ref int quantidade = ref mMat[l].Quantidade;
					reference = ref quantidade;
					array9[1] = quantidade;
					array9[2] = OleDbType.Integer;
					array2 = array9;
					NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
					{
						"@ordem",
						(int)mMat[l].lOrdem,
						OleDbType.Integer
					}, null, null, null, IgnoreReturn: true);
					object instance9 = db;
					object[] array10 = new object[3] { "@avulso", null, null };
					ref bool avulso = ref mMat[l].Avulso;
					array10[1] = avulso;
					array10[2] = OleDbType.Boolean;
					array2 = array10;
					NewLateBinding.LateCall(instance9, null, "AddParameter", array10, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					avulso = (bool)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(bool));
					NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
					{
						"@destino",
						"",
						OleDbType.Char
					}, null, null, null, IgnoreReturn: true);
					NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
					{
						"@descdestino",
						"",
						OleDbType.Char
					}, null, null, null, IgnoreReturn: true);
					object instance10 = db;
					object[] array11 = new object[3] { "@tagAlt", null, null };
					ref string tagAlternativo = ref mMat[l].TagAlternativo;
					reference2 = ref tagAlternativo;
					array11[1] = tagAlternativo;
					array11[2] = OleDbType.Char;
					array2 = array11;
					NewLateBinding.LateCall(instance10, null, "AddParameter", array11, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance11 = db;
					object[] array12 = new object[3] { "@handle", null, null };
					ref string sHandle = ref mMat[l].sHandle;
					reference2 = ref sHandle;
					array12[1] = sHandle;
					array12[2] = OleDbType.Char;
					array2 = array12;
					NewLateBinding.LateCall(instance11, null, "AddParameter", array12, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance12 = db;
					object[] array13 = new object[3] { "@index", null, null };
					ref int indexLM = ref mMat[l].indexLM;
					reference = ref indexLM;
					array13[1] = indexLM;
					array13[2] = OleDbType.Integer;
					array2 = array13;
					NewLateBinding.LateCall(instance12, null, "AddParameter", array13, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
					{
						"@OrdemLay",
						(int)mMat[l].OrdemLay,
						OleDbType.Integer
					}, null, null, null, IgnoreReturn: true);
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

	public void RemoveMaterialAvulso(int CodigoInterno)
	{
		try
		{
			string text = "";
			text = "DELETE FROM ListaMateriais WHERE Indice=@CodigoInterno ";
			object instance = db;
			object[] array = new object[3]
			{
				"@CodigoInterno",
				CodigoInterno,
				OleDbType.Integer
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			CodigoInterno = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
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

	public void AdicionaUmItemMaterialAvulso(ref DataGridView dg, int indice)
	{
		try
		{
			string text = "";
			text = "Insert into ListaMateriais(DWG, Painel, Tag, IndiceMaterial, Quantidade, Ordem, Avulso, Destino, DescDestino, Alternativo, Handle, IndiceLM) VALUES(@dwg, @painel, @tag, @indiceMaterial, @quantidade, @ordem, @avulso, @destino, @descdestino, @alternativo, @handle, @indicelm)";
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@dwg",
				Conversions.ToInteger(dg.Rows[indice].Cells[1].Value),
				OleDbType.Integer
			}, null, null, null, IgnoreReturn: true);
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@painel",
				Conversions.ToInteger(dg.Rows[indice].Cells[2].Value),
				OleDbType.Integer
			}, null, null, null, IgnoreReturn: true);
			object instance = db;
			DataGridViewCell dataGridViewCell;
			object[] array = new object[3]
			{
				"@tag",
				(dataGridViewCell = dg.Rows[indice].Cells[3]).Value,
				OleDbType.Char
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			dataGridViewCell.Value = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@indiceMaterial",
				Conversions.ToInteger(dg.Rows[indice].Cells[4].Value),
				OleDbType.Integer
			}, null, null, null, IgnoreReturn: true);
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@quantidade",
				Conversions.ToInteger(dg.Rows[indice].Cells[5].Value),
				OleDbType.Integer
			}, null, null, null, IgnoreReturn: true);
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@ordem",
				Conversions.ToInteger(dg.Rows[indice].Cells[6].Value),
				OleDbType.Integer
			}, null, null, null, IgnoreReturn: true);
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@avulso",
				true,
				OleDbType.Boolean
			}, null, null, null, IgnoreReturn: true);
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@destino",
				"",
				OleDbType.Char
			}, null, null, null, IgnoreReturn: true);
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@descdestino",
				"",
				OleDbType.Char
			}, null, null, null, IgnoreReturn: true);
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@alternativo",
				(dataGridViewCell = dg.Rows[indice].Cells[10]).Value,
				OleDbType.Char
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			dataGridViewCell.Value = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
			object instance3 = db;
			object[] array4 = new object[3]
			{
				"@handle",
				(dataGridViewCell = dg.Rows[indice].Cells[11]).Value,
				OleDbType.Char
			};
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			dataGridViewCell.Value = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@indicelm",
				indice,
				OleDbType.Integer
			}, null, null, null, IgnoreReturn: true);
			object instance4 = db;
			object[] array5 = new object[1] { text };
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "ExecuteNonQuery", array5, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public void EditaUmItemMaterialAvulso(int indiceLM, int indice)
	{
		try
		{
			string text = "";
			text = "UPDATE ListaMateriais SET IndiceMaterial=@indicelm WHERE Indice=@indice";
			object instance = db;
			object[] array = new object[3]
			{
				"@indicelm",
				indiceLM,
				OleDbType.Integer
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			indiceLM = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
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

	public void LeItensAvulsosDaLM(int DWG_ORI, int DWG_DEST, ref clsLM.LMateriais[] mMat)
	{
		int num = 0;
		mMat = new clsLM.LMateriais[1];
		checked
		{
			try
			{
				string text = "SELECT Painel, Tag, IndiceMaterial, Quantidade, Ordem, Avulso, Destino, DescDestino, Alternativo, Handle, IndiceLM, OrdemLay FROM ListaMateriais WHERE DWG=@dwg ";
				object instance = db;
				object[] array = new object[3]
				{
					"@dwg",
					DWG_ORI,
					OleDbType.Integer
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				DWG_ORI = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance2 = db;
				object[] array3 = new object[1] { text };
				array2 = array3;
				object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count > 0)
				{
					int num2 = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num2; i++)
					{
						num++;
						mMat = (clsLM.LMateriais[])Utils.CopyArray(mMat, new clsLM.LMateriais[num + 1]);
						mMat[num].Dwg = DWG_DEST;
						mMat[num].Painel = Conversions.ToInteger(dataTable.Rows[i][0]);
						mMat[num].TagMat = Conversions.ToString(dataTable.Rows[i][1]);
						mMat[num].IndiceMaterial = Conversions.ToInteger(dataTable.Rows[i][2]);
						mMat[num].Quantidade = Conversions.ToInteger(dataTable.Rows[i][3]);
						mMat[num].lOrdem = Conversions.ToLong(dataTable.Rows[i][4]);
						mMat[num].Avulso = Conversions.ToBoolean(dataTable.Rows[i][5]);
						mMat[num].TagAlternativo = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][8]));
						mMat[num].sHandle = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][9]));
						mMat[num].indexLM = Conversions.ToInteger(clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][10])));
						mMat[num].OrdemLay = Conversions.ToLong(clsTextos.TiraDBNullNumero(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][11])));
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

	public void AdicionaItensMateriaisIdependentes(int DWG_DEST, clsLM.LMateriais[] mMat)
	{
		checked
		{
			try
			{
				string text = "";
				text = "DELETE FROM ListaMateriais WHERE DWG=@dwg ";
				object instance = db;
				object[] array = new object[3]
				{
					"@dwg",
					DWG_DEST,
					OleDbType.Integer
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				DWG_DEST = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance2 = db;
				object[] array3 = new object[1] { text };
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "ExecuteNonQuery", array3, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				int num = Information.UBound(mMat);
				for (int i = 1; i <= num; i++)
				{
					text = "Insert into ListaMateriais(DWG, Painel, Tag, IndiceMaterial, Quantidade, Ordem, Avulso, Destino, DescDestino, Alternativo, Handle, IndiceLm, OrdemLay) VALUES(@dwg, @painel, @tag, @indiceMaterial, @quantidade, @ordem, @avulso, @destino, @descdestino, @tagAlt, @handle, @indicelm, @OrdemLay)";
					object instance3 = db;
					object[] array4 = new object[3] { "@dwg", null, null };
					ref int dwg = ref mMat[i].Dwg;
					ref int reference = ref dwg;
					array4[1] = dwg;
					array4[2] = OleDbType.Integer;
					array2 = array4;
					NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					object instance4 = db;
					object[] array5 = new object[3] { "@painel", null, null };
					ref int painel = ref mMat[i].Painel;
					reference = ref painel;
					array5[1] = painel;
					array5[2] = OleDbType.Integer;
					array2 = array5;
					NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					object instance5 = db;
					object[] array6 = new object[3] { "@tag", null, null };
					ref string tagMat = ref mMat[i].TagMat;
					ref string reference2 = ref tagMat;
					array6[1] = tagMat;
					array6[2] = OleDbType.Char;
					array2 = array6;
					NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance6 = db;
					object[] array7 = new object[3] { "@indiceMaterial", null, null };
					ref int indiceMaterial = ref mMat[i].IndiceMaterial;
					reference = ref indiceMaterial;
					array7[1] = indiceMaterial;
					array7[2] = OleDbType.Integer;
					array2 = array7;
					NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					object instance7 = db;
					object[] array8 = new object[3] { "@quantidade", null, null };
					ref int quantidade = ref mMat[i].Quantidade;
					reference = ref quantidade;
					array8[1] = quantidade;
					array8[2] = OleDbType.Integer;
					array2 = array8;
					NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
					{
						"@ordem",
						(int)mMat[i].lOrdem,
						OleDbType.Integer
					}, null, null, null, IgnoreReturn: true);
					object instance8 = db;
					object[] array9 = new object[3] { "@avulso", null, null };
					ref bool avulso = ref mMat[i].Avulso;
					array9[1] = avulso;
					array9[2] = OleDbType.Boolean;
					array2 = array9;
					NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					avulso = (bool)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(bool));
					NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
					{
						"@destino",
						"",
						OleDbType.Char
					}, null, null, null, IgnoreReturn: true);
					NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
					{
						"@descdestino",
						"",
						OleDbType.Char
					}, null, null, null, IgnoreReturn: true);
					object instance9 = db;
					object[] array10 = new object[3] { "@tagAlt", null, null };
					ref string tagAlternativo = ref mMat[i].TagAlternativo;
					reference2 = ref tagAlternativo;
					array10[1] = tagAlternativo;
					array10[2] = OleDbType.Char;
					array2 = array10;
					NewLateBinding.LateCall(instance9, null, "AddParameter", array10, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance10 = db;
					object[] array11 = new object[3] { "@handle", null, null };
					ref string sHandle = ref mMat[i].sHandle;
					reference2 = ref sHandle;
					array11[1] = sHandle;
					array11[2] = OleDbType.Char;
					array2 = array11;
					NewLateBinding.LateCall(instance10, null, "AddParameter", array11, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance11 = db;
					object[] array12 = new object[3] { "@indicelm", null, null };
					ref int indexLM = ref mMat[i].indexLM;
					reference = ref indexLM;
					array12[1] = indexLM;
					array12[2] = OleDbType.Char;
					array2 = array12;
					NewLateBinding.LateCall(instance11, null, "AddParameter", array12, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
					{
						"@OrdemLay",
						(int)mMat[i].OrdemLay,
						OleDbType.Integer
					}, null, null, null, IgnoreReturn: true);
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

	public void AtualizaIndiceLM(ref cDadosLM.indexCODMateriais[] mRelCod)
	{
		try
		{
			int num = Information.UBound(mRelCod);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				string text = "";
				text = "UPDATE ListaMateriais SET IndiceLM=@indicelm WHERE IndiceMaterial=@indice";
				object instance = db;
				object[] array = new object[3] { "@indicelm", null, null };
				ref int indice = ref mRelCod[i].indice;
				ref int reference = ref indice;
				array[1] = indice;
				array[2] = OleDbType.Integer;
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance2 = db;
				object[] array3 = new object[3] { "@indice", null, null };
				ref int indexLM = ref mRelCod[i].indexLM;
				reference = ref indexLM;
				array3[1] = indexLM;
				array3[2] = OleDbType.Integer;
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
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
