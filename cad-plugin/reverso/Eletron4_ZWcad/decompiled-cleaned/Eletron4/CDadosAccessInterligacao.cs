using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class CDadosAccessInterligacao
{
	private struct JBgaA5p5W7h1TRpQ5uHE
	{
		public int NsTp5p3fWbb;

		public string aqhp5TFBaCf;
	}

	public object db;

	public void FechaConexao()
	{
		NewLateBinding.LateCall(db, null, "fechaConexao", new object[0], null, null, null, IgnoreReturn: true);
	}

	public CDadosAccessInterligacao()
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
				if (dataTable.Rows.Count <= 0)
				{
					mRevisoes[Information.UBound(mRevisoes)].revisao = "";
					return;
				}
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					mRevisoes = (DeclaracoesFiacao.structureRevisoes[])Utils.CopyArray(mRevisoes, new DeclaracoesFiacao.structureRevisoes[Information.UBound(mRevisoes) + 1 + 1]);
					mRevisoes[Information.UBound(mRevisoes)].revisao = Conversions.ToString(dataTable.Rows[i][0]);
					mRevisoes[Information.UBound(mRevisoes)].criador = Conversions.ToString(dataTable.Rows[i][1]);
					mRevisoes[Information.UBound(mRevisoes)].data = Conversions.ToDate(dataTable.Rows[i][2]);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void LeCabosDosPaineis(ref DataGridView dg, int Pn1, int Pn2)
	{
		checked
		{
			try
			{
				if ((Pn1 == 0) | (Pn2 == 0))
				{
					return;
				}
				string text = "SELECT Tag, Formacao, Funcao FROM Cabos WHERE (Pn1=@pn1 and Pn2=@pn2) or (Pn1=@pn2 and Pn2=@pn1)";
				object instance = db;
				object[] array = new object[3]
				{
					"@pn1",
					Pn1,
					OleDbType.Integer
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				Pn1 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance2 = db;
				object[] array3 = new object[3]
				{
					"@pn2",
					Pn2,
					OleDbType.Integer
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				Pn2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
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
						string text2 = dataTable.Rows[i][1].ToString();
						dg.Rows.Add(dataTable.Rows[i][0].ToString(), text2.ToUpper(), dataTable.Rows[i][2].ToString(), Pn1, Pn2);
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
			}
		}
	}

	public void LeBlindagensDoPainel(ref DataGridView dg, int PN)
	{
		checked
		{
			try
			{
				if (PN == 0)
				{
					return;
				}
				List<string> list = new List<string>();
				list.Clear();
				string text = "SELECT DISTINCT(Tag) FROM Veias WHERE Indice < 1";
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
					list.Add(dataTable.Rows[i][0].ToString());
				}
				text = "SELECT Tag, Formacao, Funcao FROM Cabos WHERE Pn1=@pn or Pn2=@pn";
				object instance2 = db;
				object[] array3 = new object[3]
				{
					"@pn",
					PN,
					OleDbType.Integer
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				PN = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance3 = db;
				object[] array4 = new object[1] { text };
				array2 = array4;
				obj = NewLateBinding.LateGet(instance3, null, "ExecuteReader", array4, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable2 = (DataTable)obj;
				if (dataTable2.Rows.Count <= 0)
				{
					return;
				}
				int num2 = dataTable2.Rows.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					if (list.Contains(dataTable2.Rows[j][0].ToString()))
					{
						string text2 = dataTable2.Rows[j][1].ToString();
						dg.Rows.Add(dataTable2.Rows[j][0].ToString(), text2.ToUpper(), dataTable2.Rows[j][2].ToString(), PN, 0);
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
			}
		}
	}

	public void LeTodosOsPaineisDosCabos(ref List<int> lPaineis)
	{
		checked
		{
			try
			{
				lPaineis.Clear();
				string text = "SELECT Pn1, Pn2 FROM Cabos";
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
						if (!lPaineis.Contains(Conversions.ToInteger(dataTable.Rows[i][0])))
						{
							lPaineis.Add(Conversions.ToInteger(dataTable.Rows[i][0]));
						}
						if (!lPaineis.Contains(Conversions.ToInteger(dataTable.Rows[i][1])))
						{
							lPaineis.Add(Conversions.ToInteger(dataTable.Rows[i][1]));
						}
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
			}
			lPaineis.Sort();
		}
	}

	public void LeTodosOsCabosEmUso(ref List<string> lFuncao, ref List<string> lFormacao, ref List<string> ltrajeto, ref Declaracoes2.EstatisticasDeCabos[] mEstat)
	{
		checked
		{
			try
			{
				List<string> list = new List<string>();
				lFuncao.Clear();
				lFormacao.Clear();
				ltrajeto.Clear();
				int num = 0;
				mEstat = new Declaracoes2.EstatisticasDeCabos[1];
				string text = "";
				text = "SELECT C.Tag, C.Formacao, C.Funcao, C.Comprimento, c.Trajeto, V.Tag, V.Uso FROM Cabos C, Veias V WHERE V.Uso=@bUso AND C.Tag=V.Tag";
				NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
				{
					"@bUso",
					true,
					OleDbType.Boolean
				}, null, null, null, IgnoreReturn: true);
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
				int num2 = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					if (!list.Contains(dataTable.Rows[i][0].ToString()))
					{
						list.Add(dataTable.Rows[i][0].ToString());
						if (!lFormacao.Contains(dataTable.Rows[i][1].ToString()) && Operators.CompareString(clsTextos.TiraDBNull(dataTable.Rows[i][1].ToString()), "", TextCompare: true) != 0)
						{
							lFormacao.Add(dataTable.Rows[i][1].ToString());
						}
						if (!lFuncao.Contains(dataTable.Rows[i][2].ToString()) && Operators.CompareString(clsTextos.TiraDBNull(dataTable.Rows[i][2].ToString()), "", TextCompare: true) != 0)
						{
							lFuncao.Add(dataTable.Rows[i][2].ToString());
						}
						if (!ltrajeto.Contains(dataTable.Rows[i][4].ToString()) && Operators.CompareString(clsTextos.TiraDBNull(dataTable.Rows[i][4].ToString()), "", TextCompare: true) != 0)
						{
							ltrajeto.Add(dataTable.Rows[i][4].ToString());
						}
						num++;
						mEstat = (Declaracoes2.EstatisticasDeCabos[])Utils.CopyArray(mEstat, new Declaracoes2.EstatisticasDeCabos[num + 1]);
						mEstat[num].Tag = dataTable.Rows[i][0].ToString();
						mEstat[num].Formacao = dataTable.Rows[i][1].ToString();
						mEstat[num].Funcao = dataTable.Rows[i][2].ToString();
						mEstat[num].Comprimento = Conversions.ToDouble(dataTable.Rows[i][3]);
						mEstat[num].Trajeto = dataTable.Rows[i][4].ToString();
					}
				}
				lFormacao.Sort();
				lFuncao.Sort();
				ltrajeto.Sort();
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

	public void LeAsVeiasDoCaboSel(ref DataGridView dg, string sCabo)
	{
		checked
		{
			try
			{
				string text = "SELECT Chave, Tag, Indice, Nome_Veia, Uso, Handle, Arquivo, Pagina, Funcao FROM Veias WHERE Tag=@tag AND indice > 0";
				object instance = db;
				object[] array = new object[3]
				{
					"@tag",
					sCabo,
					OleDbType.Char
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				sCabo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
					string text2 = "BL";
					if (Conversions.ToDouble(dataTable.Rows[i][2].ToString().Trim()) > 0.0)
					{
						text2 = dataTable.Rows[i][2].ToString();
					}
					if (Operators.CompareString(dataTable.Rows[i][3].ToString().Trim(), "", TextCompare: true) != 0)
					{
						text2 = dataTable.Rows[i][3].ToString();
					}
					string text3 = DeclaracoesGeral.mMensagem[1, 1105].ToString().ToLowerInvariant();
					if (Conversions.ToBoolean(dataTable.Rows[i][4].ToString()))
					{
						text3 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1113]);
					}
					string text4 = clsTextos.TiraNothing(dataTable.Rows[i][8].ToString());
					dg.Rows.Add(dataTable.Rows[i][0].ToString(), dataTable.Rows[i][1].ToString(), dataTable.Rows[i][2].ToString(), dataTable.Rows[i][3].ToString(), text2, text3, text4);
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

	public void LeAsBlindagensDoCaboSel(ref DataGridView dg, string sCabo)
	{
		checked
		{
			try
			{
				string text = "SELECT Chave, Tag, Indice, Nome_Veia, Uso, Handle, Arquivo, Pagina FROM Veias WHERE Tag=@tag AND indice < 1";
				object instance = db;
				object[] array = new object[3]
				{
					"@tag",
					sCabo,
					OleDbType.Char
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				sCabo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
					string text2 = "BL";
					if (Conversions.ToDouble(dataTable.Rows[i][2].ToString().Trim()) < 1.0)
					{
						text2 = dataTable.Rows[i][2].ToString();
					}
					if (Operators.CompareString(dataTable.Rows[i][3].ToString().Trim(), "", TextCompare: true) != 0)
					{
						text2 = dataTable.Rows[i][3].ToString();
					}
					string text3 = DeclaracoesGeral.mMensagem[1, 1105].ToString().ToLowerInvariant();
					if (Conversions.ToBoolean(dataTable.Rows[i][4].ToString()))
					{
						text3 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1113]);
					}
					dg.Rows.Add(dataTable.Rows[i][0].ToString(), dataTable.Rows[i][1].ToString(), dataTable.Rows[i][2].ToString(), dataTable.Rows[i][3].ToString(), text2, text3);
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

	public string TemBlindagemLivresNoCaboSel(string sCabo)
	{
		string result = "D";
		try
		{
			string text = "SELECT Tag FROM Veias WHERE Tag=@tag AND indice < 1";
			object instance = db;
			object[] array = new object[3]
			{
				"@tag",
				sCabo,
				OleDbType.Char
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			sCabo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[1] { text };
			array2 = array3;
			object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			DataTable dataTable = (DataTable)obj;
			int count = dataTable.Rows.Count;
			string text2 = "SELECT Tag FROM Veias WHERE Tag=@tag AND indice < 1 AND USO = TRUE";
			object instance3 = db;
			object[] array4 = new object[3]
			{
				"@tag",
				sCabo,
				OleDbType.Char
			};
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			sCabo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance4 = db;
			object[] array5 = new object[1] { text2 };
			array2 = array5;
			obj = NewLateBinding.LateGet(instance4, null, "ExecuteReader", array5, null, null, new bool[1] { true });
			text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			dataTable = (DataTable)obj;
			int count2 = dataTable.Rows.Count;
			if (count != count2)
			{
				if (count2 == 0)
				{
					result = "L";
				}
			}
			else
			{
				result = "U";
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public string TemVeiasLivresNoCaboSel(string sCabo)
	{
		string result = "D";
		try
		{
			string text = "SELECT Tag FROM Veias WHERE Tag=@tag AND indice > 0";
			object instance = db;
			object[] array = new object[3]
			{
				"@tag",
				sCabo,
				OleDbType.Char
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			sCabo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[1] { text };
			array2 = array3;
			object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			DataTable dataTable = (DataTable)obj;
			int count = dataTable.Rows.Count;
			string text2 = "SELECT Tag FROM Veias WHERE Tag=@tag AND indice > 0 AND USO = TRUE";
			object instance3 = db;
			object[] array4 = new object[3]
			{
				"@tag",
				sCabo,
				OleDbType.Char
			};
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			sCabo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance4 = db;
			object[] array5 = new object[1] { text2 };
			array2 = array5;
			obj = NewLateBinding.LateGet(instance4, null, "ExecuteReader", array5, null, null, new bool[1] { true });
			text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			dataTable = (DataTable)obj;
			int count2 = dataTable.Rows.Count;
			if (count != count2)
			{
				if (count2 == 0)
				{
					result = "L";
				}
			}
			else
			{
				result = "U";
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void LeNomeDeCabos(ref List<string> lmListaCabos)
	{
		checked
		{
			try
			{
				string text = "SELECT TAG FROM Cabos";
				object instance = db;
				object[] array = new object[1] { text };
				object[] array2 = array;
				object obj = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				lmListaCabos.Clear();
				DeclaracoesGeral._uscPagina.Quantidade = dataTable.Rows.Count;
				DeclaracoesGeral._uscPagina.pbIniciar();
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (!lmListaCabos.Contains(Conversions.ToString(dataTable.Rows[i][0])))
						{
							lmListaCabos.Add(Conversions.ToString(dataTable.Rows[i][0]));
						}
						DeclaracoesGeral._uscPagina.pbPasso();
					}
				}
				DeclaracoesGeral._uscPagina.pbFim();
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

	public object LeNomeDeUmaVeiaDeUmCabo(ref string sTag, int iIndice)
	{
		string result = "";
		checked
		{
			try
			{
				string text = "SELECT Nome_Veia FROM veias WHERE Tag=@tag AND Indice=@indice";
				object instance = db;
				object[] array = new object[3]
				{
					"@tag",
					sTag,
					OleDbType.Char
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				sTag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance2 = db;
				object[] array3 = new object[3]
				{
					"@indice",
					iIndice,
					OleDbType.Integer
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				iIndice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
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
						result = Conversions.ToString(dataTable.Rows[i][0]);
					}
				}
				DeclaracoesGeral._uscPagina.pbFim();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
			return result;
		}
	}

	public void LeCabosVeiasUsadasCaderno(ref structureVeiasCaderno[] VeiasCaderno, ref List<string> lCabos, bool bFormacao = false)
	{
		checked
		{
			try
			{
				VeiasCaderno = new structureVeiasCaderno[1];
				string text = "SELECT DISTINCT(Tag) FROM Veias WHERE Arquivo=@arquivo ORDER BY Tag";
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
				lCabos.Clear();
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						lCabos.Add(Conversions.ToString(dataTable.Rows[i][0]));
					}
				}
				lCabos.Sort();
				int num2 = lCabos.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					string sFormacao = "";
					List<string> list;
					int index;
					if (bFormacao)
					{
						text = "SELECT Formacao FROM cabos WHERE Tag=@tag";
						object instance3 = db;
						object[] array4 = new object[3]
						{
							"@tag",
							(list = lCabos)[index = j],
							OleDbType.Char
						};
						array2 = array4;
						NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						list[index] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						object instance4 = db;
						object[] array5 = new object[1] { text };
						array2 = array5;
						obj = NewLateBinding.LateGet(instance4, null, "ExecuteReader", array5, null, null, new bool[1] { true });
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
						DataTable dataTable2 = (DataTable)obj;
						if (dataTable2.Rows.Count > 0)
						{
							int num3 = dataTable2.Rows.Count - 1;
							for (int k = 0; k <= num3; k++)
							{
								sFormacao = Conversions.ToString(dataTable2.Rows[k][0]);
							}
						}
					}
					text = "SELECT Tag, Indice, Nome_Veia, Handle, Pagina, Arquivo, Funcao FROM veias WHERE Tag=@tag ORDER BY Indice";
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@tag",
						(list = lCabos)[index = j],
						OleDbType.Char
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					list[index] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DataTable dataTable3 = (DataTable)obj;
					if (dataTable3.Rows.Count > 0)
					{
						int num4 = dataTable3.Rows.Count - 1;
						for (int l = 0; l <= num4; l++)
						{
							int num5 = Information.UBound(VeiasCaderno) + 1;
							VeiasCaderno = (structureVeiasCaderno[])Utils.CopyArray(VeiasCaderno, new structureVeiasCaderno[num5 + 1]);
							VeiasCaderno[num5].sTag = Conversions.ToString(dataTable3.Rows[l][0]);
							VeiasCaderno[num5].sFormacao = sFormacao;
							VeiasCaderno[num5].iIndice = Conversions.ToInteger(dataTable3.Rows[l][1]);
							VeiasCaderno[num5].sNomeVeia = dataTable3.Rows[l][2].ToString();
							VeiasCaderno[num5].sFuncaoVeia = dataTable3.Rows[l][6].ToString();
							VeiasCaderno[num5].sHandleCabo1 = dataTable3.Rows[l][3].ToString();
							VeiasCaderno[num5].iArquivo = DeclaracoesGeral.arqAtivo.Indice;
							VeiasCaderno[num5].sPagina = dataTable3.Rows[l][4].ToString();
							VeiasCaderno[num5].iPn1 = 0;
							VeiasCaderno[num5].sHandleTag1 = "";
							VeiasCaderno[num5].iPn2 = 0;
							VeiasCaderno[num5].sHandleCabo2 = "";
							VeiasCaderno[num5].sHandleTag2 = "";
							VeiasCaderno[num5].sPagina2 = "";
							VeiasCaderno[num5].iTipo = 1;
							VeiasCaderno[num5].X = 0.0;
							VeiasCaderno[num5].Y = 0.0;
							VeiasCaderno[num5].iDWG = Conversions.ToInteger(dataTable3.Rows[l][5].ToString());
						}
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
			}
		}
	}

	public void LeCabosTodosCabos(ref List<string> lCabos, ref List<string> lCabosCaderno)
	{
		checked
		{
			try
			{
				string text = "SELECT DISTINCT(Tag) FROM Veias WHERE Arquivo>0";
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
				lCabos.Clear();
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (!lCabosCaderno.Contains(Conversions.ToString(dataTable.Rows[i][0])))
						{
							lCabos.Add(Conversions.ToString(dataTable.Rows[i][0]));
						}
					}
				}
				lCabos.Sort();
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

	public void LeCabosVeiasUsadasOutrosCaderno(ref structureVeiasCaderno[] VeiasCaderno, ref List<string> lCabos, bool bFormacao = false)
	{
		checked
		{
			try
			{
				VeiasCaderno = new structureVeiasCaderno[1];
				string text = "";
				int num = lCabos.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					string sFormacao = "";
					List<string> list;
					int index;
					object obj;
					object[] array2;
					if (bFormacao)
					{
						text = "SELECT Formacao FROM cabos WHERE Tag=@tag";
						object instance = db;
						object[] array = new object[3]
						{
							"@tag",
							(list = lCabos)[index = i],
							OleDbType.Char
						};
						array2 = array;
						NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						list[index] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						object instance2 = db;
						object[] array3 = new object[1] { text };
						array2 = array3;
						obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
						DataTable dataTable = (DataTable)obj;
						if (dataTable.Rows.Count > 0)
						{
							int num2 = dataTable.Rows.Count - 1;
							for (int j = 0; j <= num2; j++)
							{
								sFormacao = Conversions.ToString(dataTable.Rows[j][0]);
							}
						}
					}
					text = "SELECT Tag, Indice, Nome_Veia, Handle, Pagina FROM veias WHERE Tag=@tag ORDER BY Indice";
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@tag",
						(list = lCabos)[index = i],
						OleDbType.Char
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					list[index] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DataTable dataTable2 = (DataTable)obj;
					if (dataTable2.Rows.Count > 0)
					{
						int num3 = dataTable2.Rows.Count - 1;
						for (int k = 0; k <= num3; k++)
						{
							int num4 = Information.UBound(VeiasCaderno) + 1;
							VeiasCaderno = (structureVeiasCaderno[])Utils.CopyArray(VeiasCaderno, new structureVeiasCaderno[num4 + 1]);
							VeiasCaderno[num4].sTag = Conversions.ToString(dataTable2.Rows[k][0]);
							VeiasCaderno[num4].sFormacao = sFormacao;
							VeiasCaderno[num4].iIndice = Conversions.ToInteger(dataTable2.Rows[k][1]);
							VeiasCaderno[num4].sNomeVeia = dataTable2.Rows[k][2].ToString();
							VeiasCaderno[num4].sHandleCabo1 = dataTable2.Rows[k][3].ToString();
							VeiasCaderno[num4].iArquivo = DeclaracoesGeral.arqAtivo.Indice;
							VeiasCaderno[num4].sPagina = dataTable2.Rows[k][4].ToString();
							VeiasCaderno[num4].iPn1 = 0;
							VeiasCaderno[num4].sHandleTag1 = "";
							VeiasCaderno[num4].iPn2 = 0;
							VeiasCaderno[num4].sHandleCabo2 = "";
							VeiasCaderno[num4].sHandleTag2 = "";
							VeiasCaderno[num4].sPagina2 = "";
							VeiasCaderno[num4].iTipo = 1;
							VeiasCaderno[num4].X = 0.0;
							VeiasCaderno[num4].Y = 0.0;
						}
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
			}
		}
	}

	public void LeCabosVeiasNaoUsadasCaderno(ref structureVeiasCaderno[] VeiasNaoUsadasCaderno, bool bFormacao = false)
	{
		checked
		{
			try
			{
				string text = "";
				List<string> list = new List<string>();
				text = "SELECT DISTINCT(Tag) FROM Veias";
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
						if (Operators.ConditionalCompareObjectNotEqual(dataTable.Rows[i][0], "", TextCompare: true))
						{
							list.Add(Conversions.ToString(dataTable.Rows[i][0]));
						}
					}
				}
				List<string> list2 = new List<string>();
				DeclaracoesGeral._uscPagina.Quantidade = list.Count;
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num2 = list.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					text = "SELECT Tag, Uso, Handle FROM Veias WHERE Tag=@tag AND Uso=@bUso";
					List<string> list3;
					int index;
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@tag",
						(list3 = list)[index = j],
						OleDbType.Char
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					list3[index] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
					{
						"@bUso",
						true,
						OleDbType.Boolean
					}, null, null, null, IgnoreReturn: true);
					obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DataTable dataTable2 = (DataTable)obj;
					if (dataTable2.Rows.Count == 0)
					{
						list2.Add(list[j]);
					}
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				DeclaracoesGeral._uscPagina.pbFim();
				DeclaracoesGeral._uscPagina.Quantidade = list2.Count;
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num3 = 1;
				int num4 = list2.Count - 1;
				for (int k = 0; k <= num4; k++)
				{
					string sFormacao = "";
					List<string> list3;
					int index;
					if (bFormacao)
					{
						text = "SELECT Formacao FROM Cabos WHERE Tag=@tag";
						object instance2 = db;
						object[] array3 = new object[3]
						{
							"@tag",
							(list3 = list2)[index = k],
							OleDbType.Char
						};
						array2 = array3;
						NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						list3[index] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						object instance3 = db;
						object[] array4 = new object[1] { text };
						array2 = array4;
						obj = NewLateBinding.LateGet(instance3, null, "ExecuteReader", array4, null, null, new bool[1] { true });
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
						DataTable dataTable3 = (DataTable)obj;
						if (dataTable3.Rows.Count > 0)
						{
							int num5 = dataTable3.Rows.Count - 1;
							for (int l = 0; l <= num5; l++)
							{
								sFormacao = Conversions.ToString(dataTable3.Rows[l][0]);
							}
						}
					}
					text = "SELECT Tag, Indice, Nome_Veia, Handle, Pagina, Arquivo, Funcao FROM veias WHERE Tag=@tag ORDER BY Indice";
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@tag",
						(list3 = list2)[index = k],
						OleDbType.Char
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					list3[index] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DataTable dataTable4 = (DataTable)obj;
					if (dataTable4.Rows.Count > 0)
					{
						int num6 = dataTable4.Rows.Count - 1;
						for (int m = 0; m <= num6; m++)
						{
							num3 = Information.UBound(VeiasNaoUsadasCaderno) + 1;
							VeiasNaoUsadasCaderno = (structureVeiasCaderno[])Utils.CopyArray(VeiasNaoUsadasCaderno, new structureVeiasCaderno[num3 + 1]);
							VeiasNaoUsadasCaderno[num3].sTag = Conversions.ToString(dataTable4.Rows[m][0]);
							VeiasNaoUsadasCaderno[num3].sFormacao = sFormacao;
							VeiasNaoUsadasCaderno[num3].iIndice = Conversions.ToInteger(dataTable4.Rows[m][1]);
							VeiasNaoUsadasCaderno[num3].sNomeVeia = dataTable4.Rows[m][2].ToString();
							VeiasNaoUsadasCaderno[num3].sFuncaoVeia = dataTable4.Rows[m][6].ToString();
							VeiasNaoUsadasCaderno[num3].sHandleCabo1 = dataTable4.Rows[m][3].ToString();
							VeiasNaoUsadasCaderno[num3].iArquivo = DeclaracoesGeral.arqAtivo.Indice;
							VeiasNaoUsadasCaderno[num3].sPagina = dataTable4.Rows[m][4].ToString();
							VeiasNaoUsadasCaderno[num3].iPn1 = 0;
							VeiasNaoUsadasCaderno[num3].sHandleTag1 = "";
							VeiasNaoUsadasCaderno[num3].iPn2 = 0;
							VeiasNaoUsadasCaderno[num3].sHandleCabo2 = "";
							VeiasNaoUsadasCaderno[num3].sHandleTag2 = "";
							VeiasNaoUsadasCaderno[num3].sPagina2 = "";
							VeiasNaoUsadasCaderno[num3].iTipo = 1;
							VeiasNaoUsadasCaderno[num3].X = 0.0;
							VeiasNaoUsadasCaderno[num3].Y = 0.0;
							VeiasNaoUsadasCaderno[num3].iDWG = Conversions.ToInteger(dataTable4.Rows[m][5].ToString());
						}
					}
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				DeclaracoesGeral._uscPagina.pbFim();
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

	public bool LancaUmCaboNoBanco(ClsCabos.StructureCabo Cabo)
	{
		bool result = true;
		try
		{
			string text = "";
			text = "Insert into Cabos(Tag, Formacao, Blindagem, Pn1, Pn2, Codigo,  Funcao, Alarme, Aterrar, Comprimento, Trajeto, Instrucao, Diametro, Grupo, Cabos) VALUES(@tag, @formacao, @blindagem, @pn1, @pn2, @codigo, @funcao, @alarme, @aterrar, @comprimento, @trajeto, @instucao, @diametro, @grupo, @cabos)";
			object instance = db;
			object[] array = new object[3] { "@tag", null, null };
			ref string sTag = ref Cabo.sTag;
			ref string reference = ref sTag;
			array[1] = sTag;
			array[2] = OleDbType.Char;
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[3] { "@formacao", null, null };
			ref string sFormacao = ref Cabo.sFormacao;
			reference = ref sFormacao;
			array3[1] = sFormacao;
			array3[2] = OleDbType.Char;
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance3 = db;
			object[] array4 = new object[3] { "@blindagem", null, null };
			ref bool bBlindagem = ref Cabo.bBlindagem;
			array4[1] = bBlindagem;
			array4[2] = OleDbType.Boolean;
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			bBlindagem = (bool)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(bool));
			object instance4 = db;
			object[] array5 = new object[3] { "@pn1", null, null };
			ref int iPn = ref Cabo.iPn1;
			ref int reference2 = ref iPn;
			array5[1] = iPn;
			array5[2] = OleDbType.Integer;
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance5 = db;
			object[] array6 = new object[3] { "@pn2", null, null };
			ref int iPn2 = ref Cabo.iPn2;
			reference2 = ref iPn2;
			array6[1] = iPn2;
			array6[2] = OleDbType.Integer;
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@codigo",
				"",
				OleDbType.Char
			}, null, null, null, IgnoreReturn: true);
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@funcao",
				clsTextos.TiraNothing(Cabo.sFuncao),
				OleDbType.Char
			}, null, null, null, IgnoreReturn: true);
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@alarme",
				0,
				OleDbType.Integer
			}, null, null, null, IgnoreReturn: true);
			object instance6 = db;
			object[] array7 = new object[3] { "@aterrar", null, null };
			ref int iAterrar = ref Cabo.iAterrar;
			reference2 = ref iAterrar;
			array7[1] = iAterrar;
			array7[2] = OleDbType.Integer;
			array2 = array7;
			NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance7 = db;
			object[] array8 = new object[3] { "@comprimento", null, null };
			ref double dComprimento = ref Cabo.dComprimento;
			ref double reference3 = ref dComprimento;
			array8[1] = dComprimento;
			array8[2] = OleDbType.Double;
			array2 = array8;
			NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference3 = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@trajeto",
				clsTextos.TiraNothing(Cabo.sTrajeto),
				OleDbType.Char
			}, null, null, null, IgnoreReturn: true);
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@instucao",
				clsTextos.TiraNothing(Cabo.sInstrucao),
				OleDbType.Char
			}, null, null, null, IgnoreReturn: true);
			object instance8 = db;
			object[] array9 = new object[3] { "@diametro", null, null };
			ref double dComprimento2 = ref Cabo.dComprimento;
			reference3 = ref dComprimento2;
			array9[1] = dComprimento2;
			array9[2] = OleDbType.Double;
			array2 = array9;
			NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference3 = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@grupo",
				clsTextos.TiraNothing(Cabo.sGrupo),
				OleDbType.Char
			}, null, null, null, IgnoreReturn: true);
			object instance9 = db;
			object[] array10 = new object[3] { "@cabos", null, null };
			ref int iCabos = ref Cabo.iCabos;
			reference2 = ref iCabos;
			array10[1] = iCabos;
			array10[2] = OleDbType.Integer;
			array2 = array10;
			NewLateBinding.LateCall(instance9, null, "AddParameter", array10, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance10 = db;
			object[] array11 = new object[1] { text };
			array2 = array11;
			NewLateBinding.LateCall(instance10, null, "ExecuteNonQuery", array11, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool AddParteDeUmaVeia(string sCabo, int iIndice, string sNome, string sFuncao)
	{
		bool result = true;
		try
		{
			string text = "";
			text = "Insert into Veias(Tag, Indice, Nome_Veia, Uso, Handle, Arquivo, Pagina, Funcao) VALUES(@tag, @indice, @nome_veias, @uso, @handle, @arquivo, @pagina, @funcao)";
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@tag",
				sCabo.ToString(),
				OleDbType.Char
			}, null, null, null, IgnoreReturn: true);
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
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@nome_veias",
				clsTextos.TiraNothing(sNome),
				OleDbType.Char
			}, null, null, null, IgnoreReturn: true);
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@uso",
				false,
				OleDbType.Boolean
			}, null, null, null, IgnoreReturn: true);
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@handle",
				"",
				OleDbType.Char
			}, null, null, null, IgnoreReturn: true);
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@arquivo",
				0,
				OleDbType.Integer
			}, null, null, null, IgnoreReturn: true);
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@pagina",
				"",
				OleDbType.Char
			}, null, null, null, IgnoreReturn: true);
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@funcao",
				sFuncao,
				OleDbType.Char
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			sFuncao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance3 = db;
			object[] array4 = new object[1] { text };
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "ExecuteNonQuery", array4, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void RemoveCaboErro(string sCabo)
	{
		try
		{
			if (!Information.IsNothing(sCabo))
			{
				string text = "";
				text = "DELETE FROM Cabos WHERE Tag=@scabo";
				object instance = db;
				object[] array = new object[3]
				{
					"@scabo",
					sCabo,
					OleDbType.Char
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				sCabo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance2 = db;
				object[] array3 = new object[1] { text };
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "ExecuteNonQuery", array3, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "DELETE FROM Veias WHERE Tag=@scabo";
				object instance3 = db;
				object[] array4 = new object[3]
				{
					"@scabo",
					sCabo,
					OleDbType.Char
				};
				array2 = array4;
				NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				sCabo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance4 = db;
				object[] array5 = new object[1] { text };
				array2 = array5;
				NewLateBinding.LateCall(instance4, null, "ExecuteNonQuery", array5, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}

	public void LeTodosOsCabosUsadosNesteCaderno(ref ClsCabos.StructureCabo[] mCabosCaderno, int iDWG, bool bProgress = true)
	{
		checked
		{
			try
			{
				string text = "";
				List<string> list = new List<string>();
				text = "SELECT DISTINCT(Tag) FROM Veias WHERE Handle <> '' AND Arquivo =" + Conversions.ToString(iDWG);
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
						list.Add(Conversions.ToString(dataTable.Rows[i][0]));
					}
				}
				if (bProgress)
				{
					DeclaracoesGeral._uscPagina.Quantidade = list.Count;
					DeclaracoesGeral._uscPagina.pbIniciar();
				}
				int num2 = 1;
				foreach (string item in list)
				{
					text = "SELECT Tag, Formacao, Blindagem, Pn1, Pn2, Funcao, Alarme, Aterrar, Comprimento, Trajeto, Cabos FROM Cabos WHERE Tag=@tag";
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@tag",
						item,
						OleDbType.Char
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					string current = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DataTable dataTable2 = (DataTable)obj;
					if (dataTable2.Rows.Count > 0)
					{
						int num3 = dataTable2.Rows.Count - 1;
						for (int j = 0; j <= num3; j++)
						{
							num2 = Information.UBound(mCabosCaderno) + 1;
							mCabosCaderno = (ClsCabos.StructureCabo[])Utils.CopyArray(mCabosCaderno, new ClsCabos.StructureCabo[num2 + 1]);
							mCabosCaderno[num2].iLinha = num2;
							mCabosCaderno[num2].sTag = Conversions.ToString(dataTable2.Rows[j][0]);
							mCabosCaderno[num2].sFormacao = Conversions.ToString(dataTable2.Rows[j][1]);
							mCabosCaderno[num2].bBlindagem = Conversions.ToBoolean(dataTable2.Rows[j][2]);
							mCabosCaderno[num2].iPn1 = Conversions.ToInteger(dataTable2.Rows[j][3]);
							mCabosCaderno[num2].iPn2 = Conversions.ToInteger(dataTable2.Rows[j][4]);
							mCabosCaderno[num2].sFuncao = "";
							if (Operators.CompareString(dataTable2.Rows[j][5].ToString(), "", TextCompare: true) != 0)
							{
								mCabosCaderno[num2].sFuncao = Conversions.ToString(dataTable2.Rows[j][5]);
							}
							mCabosCaderno[num2].iAlarme = 0;
							mCabosCaderno[num2].iAterrar = Conversions.ToInteger(dataTable2.Rows[j][7]);
							mCabosCaderno[num2].dComprimento = 0.0;
							if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dataTable2.Rows[j][8])))
							{
								mCabosCaderno[num2].dComprimento = Conversions.ToDouble(dataTable2.Rows[j][8]);
							}
							mCabosCaderno[num2].sTrajeto = "";
							if (Operators.CompareString(dataTable2.Rows[j][9].ToString(), "", TextCompare: true) != 0)
							{
								mCabosCaderno[num2].sTrajeto = Conversions.ToString(dataTable2.Rows[j][9]);
							}
							mCabosCaderno[num2].iCabos = Conversions.ToInteger(dataTable2.Rows[j][10]);
						}
					}
					if (bProgress)
					{
						DeclaracoesGeral._uscPagina.pbPasso();
					}
				}
				if (bProgress)
				{
					DeclaracoesGeral._uscPagina.pbFim();
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

	public void LeTodosOsCabosLivres(ref ClsCabos.StructureCabo[] mCabosLivres, bool bProgress = true)
	{
		checked
		{
			try
			{
				string text = "";
				List<string> list = new List<string>();
				text = "SELECT DISTINCT(Tag) FROM Veias";
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
						if (Operators.ConditionalCompareObjectNotEqual(dataTable.Rows[i][0], "", TextCompare: true))
						{
							list.Add(Conversions.ToString(dataTable.Rows[i][0]));
						}
					}
				}
				List<string> list2 = new List<string>();
				if (bProgress)
				{
					DeclaracoesGeral._uscPagina.Quantidade = list.Count;
					DeclaracoesGeral._uscPagina.pbIniciar();
				}
				int num2 = list.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					text = "SELECT Tag, Uso, Handle FROM Veias WHERE Tag=@tag AND Uso=@bUso";
					List<string> list3;
					int index;
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@tag",
						(list3 = list)[index = j],
						OleDbType.Char
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					list3[index] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
					{
						"@bUso",
						true,
						OleDbType.Boolean
					}, null, null, null, IgnoreReturn: true);
					obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DataTable dataTable2 = (DataTable)obj;
					if (dataTable2.Rows.Count == 0)
					{
						list2.Add(list[j]);
					}
					if (bProgress)
					{
						DeclaracoesGeral._uscPagina.pbPasso();
					}
				}
				if (bProgress)
				{
					DeclaracoesGeral._uscPagina.pbFim();
					DeclaracoesGeral._uscPagina.Quantidade = list2.Count;
					DeclaracoesGeral._uscPagina.pbIniciar();
				}
				int num3 = 1;
				int num4 = list2.Count - 1;
				for (int k = 0; k <= num4; k++)
				{
					text = "SELECT Tag, Formacao, Blindagem, Pn1, Pn2, Funcao, Alarme, Aterrar, Comprimento, Trajeto, Cabos FROM Cabos WHERE Tag=@tag";
					List<string> list3;
					int index;
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@tag",
						(list3 = list2)[index = k],
						OleDbType.Char
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					list3[index] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DataTable dataTable3 = (DataTable)obj;
					if (dataTable3.Rows.Count > 0)
					{
						int num5 = dataTable3.Rows.Count - 1;
						for (int l = 0; l <= num5; l++)
						{
							num3 = Information.UBound(mCabosLivres) + 1;
							mCabosLivres = (ClsCabos.StructureCabo[])Utils.CopyArray(mCabosLivres, new ClsCabos.StructureCabo[num3 + 1]);
							mCabosLivres[num3].iLinha = num3;
							mCabosLivres[num3].sTag = Conversions.ToString(dataTable3.Rows[l][0]);
							mCabosLivres[num3].sFormacao = Conversions.ToString(dataTable3.Rows[l][1]);
							mCabosLivres[num3].bBlindagem = Conversions.ToBoolean(dataTable3.Rows[l][2]);
							mCabosLivres[num3].iPn1 = Conversions.ToInteger(dataTable3.Rows[l][3]);
							mCabosLivres[num3].iPn2 = Conversions.ToInteger(dataTable3.Rows[l][4]);
							mCabosLivres[num3].sFuncao = "";
							if (Operators.CompareString(dataTable3.Rows[l][5].ToString(), "", TextCompare: true) != 0)
							{
								mCabosLivres[num3].sFuncao = Conversions.ToString(dataTable3.Rows[l][5]);
							}
							mCabosLivres[num3].iAlarme = 0;
							mCabosLivres[num3].iAterrar = Conversions.ToInteger(dataTable3.Rows[l][7]);
							mCabosLivres[num3].dComprimento = 0.0;
							if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dataTable3.Rows[l][8])))
							{
								mCabosLivres[num3].dComprimento = Conversions.ToDouble(dataTable3.Rows[l][8]);
							}
							mCabosLivres[num3].sTrajeto = "";
							if (Operators.CompareString(dataTable3.Rows[l][9].ToString(), "", TextCompare: true) != 0)
							{
								mCabosLivres[num3].sTrajeto = Conversions.ToString(dataTable3.Rows[l][9]);
							}
							mCabosLivres[num3].iCabos = Conversions.ToInteger(dataTable3.Rows[l][10]);
						}
					}
					if (bProgress)
					{
						DeclaracoesGeral._uscPagina.pbPasso();
					}
				}
				if (bProgress)
				{
					DeclaracoesGeral._uscPagina.pbFim();
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

	public void LeTodosOsCabos(ref ClsCabos.StructureCabo[] mCabosTodos, ref List<string> lTodosCabos, bool bProgress = true)
	{
		checked
		{
			try
			{
				string text = "";
				List<string> list = new List<string>();
				text = "SELECT DISTINCT(Tag) FROM Veias ";
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
						list.Add(Conversions.ToString(dataTable.Rows[i][0]));
					}
				}
				if (bProgress)
				{
					DeclaracoesGeral._uscPagina.Quantidade = list.Count;
					DeclaracoesGeral._uscPagina.pbIniciar();
				}
				int num2 = 1;
				int num3 = list.Count - 1;
				for (int j = 0; j <= num3; j++)
				{
					text = "SELECT Tag, Formacao, Blindagem, Pn1, Pn2, Funcao, Alarme, Aterrar, Comprimento, Trajeto, Cabos, Instrucao FROM Cabos WHERE Tag=@tag";
					List<string> list2;
					int index;
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@tag",
						(list2 = list)[index = j],
						OleDbType.Char
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					list2[index] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DataTable dataTable2 = (DataTable)obj;
					if (dataTable2.Rows.Count > 0)
					{
						int num4 = dataTable2.Rows.Count - 1;
						for (int k = 0; k <= num4; k++)
						{
							num2 = Information.UBound(mCabosTodos) + 1;
							mCabosTodos = (ClsCabos.StructureCabo[])Utils.CopyArray(mCabosTodos, new ClsCabos.StructureCabo[num2 + 1]);
							mCabosTodos[num2].iLinha = num2;
							mCabosTodos[num2].sTag = Conversions.ToString(dataTable2.Rows[k][0]);
							mCabosTodos[num2].sFormacao = Conversions.ToString(dataTable2.Rows[k][1]);
							mCabosTodos[num2].bBlindagem = Conversions.ToBoolean(dataTable2.Rows[k][2]);
							mCabosTodos[num2].iPn1 = Conversions.ToInteger(dataTable2.Rows[k][3]);
							mCabosTodos[num2].iPn2 = Conversions.ToInteger(dataTable2.Rows[k][4]);
							mCabosTodos[num2].sFuncao = "";
							if (Operators.CompareString(dataTable2.Rows[k][5].ToString(), "", TextCompare: true) != 0)
							{
								mCabosTodos[num2].sFuncao = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable2.Rows[k][5]));
							}
							mCabosTodos[num2].iAlarme = 0;
							mCabosTodos[num2].iAterrar = Conversions.ToInteger(dataTable2.Rows[k][7]);
							mCabosTodos[num2].dComprimento = 0.0;
							if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dataTable2.Rows[k][8])))
							{
								mCabosTodos[num2].dComprimento = Conversions.ToDouble(dataTable2.Rows[k][8]);
							}
							mCabosTodos[num2].sTrajeto = "";
							if (Operators.CompareString(dataTable2.Rows[k][9].ToString(), "", TextCompare: true) != 0)
							{
								mCabosTodos[num2].sTrajeto = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable2.Rows[k][9]));
							}
							mCabosTodos[num2].iCabos = Conversions.ToInteger(dataTable2.Rows[k][10]);
							mCabosTodos[num2].sInstrucao = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable2.Rows[k][11]));
						}
					}
					if (bProgress)
					{
						DeclaracoesGeral._uscPagina.pbPasso();
					}
				}
				if (bProgress)
				{
					DeclaracoesGeral._uscPagina.pbFim();
				}
				lTodosCabos = list;
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

	public void LimpaVeiasDoArquivo()
	{
		checked
		{
			try
			{
				List<string> lCabos = new List<string>();
				lCabos.Clear();
				List<string> lVeias = new List<string>();
				lVeias.Clear();
				List<string> list = new List<string>();
				list.Clear();
				LeCabosTodosOsCabos(ref lCabos);
				lCabos.Sort();
				LeTodasasVeias(ref lVeias);
				lVeias.Sort();
				string text = "SELECT TAG FROM Veias";
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
						if (!lCabos.Contains(Conversions.ToString(dataTable.Rows[i][0])) && !list.Contains(Conversions.ToString(dataTable.Rows[i][0])))
						{
							list.Add(Conversions.ToString(dataTable.Rows[i][0]));
						}
					}
				}
				text = "SELECT TAG FROM Cabos";
				obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable2 = (DataTable)obj;
				if (dataTable2.Rows.Count > 0)
				{
					int num2 = dataTable2.Rows.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						if (!lVeias.Contains(Conversions.ToString(dataTable2.Rows[j][0])) && !list.Contains(Conversions.ToString(dataTable2.Rows[j][0])))
						{
							list.Add(Conversions.ToString(dataTable2.Rows[j][0]));
						}
					}
				}
				int num3 = list.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					RemoveCaboErro(list[k]);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void IndefineVeiasDeUmcadeno()
	{
		try
		{
			string text = "UPDATE Veias SET Uso=@bUso, Handle='', Arquivo=0, Pagina='' WHERE Arquivo=@arquivo";
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@bUso",
				false,
				OleDbType.Boolean
			}, null, null, null, IgnoreReturn: true);
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
			NewLateBinding.LateCall(instance2, null, "ExecuteNonQuery", array3, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public void IndefineUmaVeiaDeUmCabo(ref string sHandle)
	{
		try
		{
			string text = "UPDATE Veias SET  Uso=@bUso, Handle='', Arquivo=0, Pagina='' WHERE Handle=@handle AND Arquivo=@arquivo";
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@bUso",
				false,
				OleDbType.Boolean
			}, null, null, null, IgnoreReturn: true);
			object instance = db;
			object[] array = new object[3]
			{
				"@handle",
				sHandle,
				OleDbType.Char
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			sHandle = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[3] { "@arquivo", null, null };
			ref int indice = ref DeclaracoesGeral.arqAtivo.Indice;
			array3[1] = indice;
			array3[2] = OleDbType.Integer;
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

	public void SincronizarTodasAsVeias(ref SincVeias[] SincVeias)
	{
		string text = "";
		checked
		{
			try
			{
				int num = Information.UBound(SincVeias);
				ref int reference2;
				object[] array2;
				object obj;
				for (int i = 1; i <= num; i++)
				{
					string text2 = "";
					text = "SELECT Funcao FROM Veias WHERE Tag=@tag AND Indice=@indice";
					object instance = db;
					object[] array = new object[3] { "@tag", null, null };
					ref string sTag = ref SincVeias[i].sTag;
					ref string reference = ref sTag;
					array[1] = sTag;
					array[2] = OleDbType.Char;
					array2 = array;
					NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance2 = db;
					object[] array3 = new object[3] { "@indice", null, null };
					ref int iIndice = ref SincVeias[i].iIndice;
					reference2 = ref iIndice;
					array3[1] = iIndice;
					array3[2] = OleDbType.Integer;
					array2 = array3;
					NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DataTable dataTable = (DataTable)obj;
					if (dataTable.Rows.Count == 1)
					{
						text2 = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][0]));
					}
					text = "UPDATE Veias SET Uso=@uso, Handle=@handle, Arquivo=@arquivo, Pagina=@pagina, Funcao=@funcao WHERE Tag=@tag AND Indice=@indice";
					NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
					{
						"@uso",
						true,
						OleDbType.Boolean
					}, null, null, null, IgnoreReturn: true);
					object instance3 = db;
					object[] array4 = new object[3] { "@handle", null, null };
					ref string sHandle = ref SincVeias[i].sHandle1;
					reference = ref sHandle;
					array4[1] = sHandle;
					array4[2] = OleDbType.Char;
					array2 = array4;
					NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance4 = db;
					object[] array5 = new object[3] { "@arquivo", null, null };
					ref int iArquivo = ref SincVeias[i].iArquivo1;
					reference2 = ref iArquivo;
					array5[1] = iArquivo;
					array5[2] = OleDbType.Integer;
					array2 = array5;
					NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					object instance5 = db;
					object[] array6 = new object[3] { "@pagina", null, null };
					ref string sPagina = ref SincVeias[i].sPagina1;
					reference = ref sPagina;
					array6[1] = sPagina;
					array6[2] = OleDbType.Char;
					array2 = array6;
					NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@funcao",
						text2,
						OleDbType.Char
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance6 = db;
					object[] array7 = new object[3] { "@tag", null, null };
					ref string sTag2 = ref SincVeias[i].sTag;
					reference = ref sTag2;
					array7[1] = sTag2;
					array7[2] = OleDbType.Char;
					array2 = array7;
					NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance7 = db;
					object[] array8 = new object[3] { "@indice", null, null };
					ref int iIndice2 = ref SincVeias[i].iIndice;
					reference2 = ref iIndice2;
					array8[1] = iIndice2;
					array8[2] = OleDbType.Integer;
					array2 = array8;
					NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				}
				text = "SELECT Tag, Indice, Handle FROM Veias WHERE Handle<>'' AND Arquivo=@arquivo";
				object instance8 = db;
				object[] array9 = new object[3] { "@arquivo", null, null };
				ref int indice = ref DeclaracoesGeral.arqAtivo.Indice;
				reference2 = ref indice;
				array9[1] = indice;
				array9[2] = OleDbType.Integer;
				array2 = array9;
				NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance9 = db;
				object[] array10 = new object[1] { text };
				array2 = array10;
				obj = NewLateBinding.LateGet(instance9, null, "ExecuteReader", array10, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable2 = (DataTable)obj;
				if (dataTable2.Rows.Count <= 0)
				{
					return;
				}
				int num2 = Information.UBound(SincVeias);
				for (int j = 1; j <= num2; j++)
				{
					SincVeias[j].Del = "#OK#";
				}
				int num3 = dataTable2.Rows.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					int num4 = Information.UBound(SincVeias);
					for (int l = 1; l <= num4; l++)
					{
						if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(SincVeias[l].sTag, dataTable2.Rows[k][0], TextCompare: true), Operators.CompareObjectEqual(SincVeias[l].iIndice, dataTable2.Rows[k][1], TextCompare: true))) && Operators.ConditionalCompareObjectEqual(SincVeias[l].sHandle1, dataTable2.Rows[k][2], TextCompare: true))
						{
							SincVeias[l].Del = "";
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

	public bool AtribuiVeiaNoBanco(int iIndice, string sHandle, int Arquivo, string sPagina)
	{
		bool result = true;
		try
		{
			string text = "UPDATE Veias SET Uso=@bUso, Handle=@handle, Arquivo=@arquivo, Pagina=@pagina WHERE Chave=@chave";
			NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
			{
				"@bUso",
				true,
				OleDbType.Boolean
			}, null, null, null, IgnoreReturn: true);
			object instance = db;
			object[] array = new object[3]
			{
				"@handle",
				sHandle,
				OleDbType.Char
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			sHandle = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@arquivo",
				Arquivo,
				OleDbType.Integer
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			Arquivo = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance3 = db;
			object[] array4 = new object[3]
			{
				"@pagina",
				sPagina,
				OleDbType.Char
			};
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			sPagina = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance4 = db;
			object[] array5 = new object[3]
			{
				"@chave",
				iIndice,
				OleDbType.Integer
			};
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iIndice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance5 = db;
			object[] array6 = new object[1] { text };
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "ExecuteNonQuery", array6, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void EditaOnomeDaVeiaDeUmCabo(string sNovoNome, string sTag, int iIndice)
	{
		try
		{
			string text = "UPDATE Veias SET Nome_Veia=@nome_veia WHERE Tag=@tag and Indice=@indice";
			object instance = db;
			object[] array = new object[3]
			{
				"@nome_veia",
				sNovoNome,
				OleDbType.Char
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			sNovoNome = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@tag",
				sTag,
				OleDbType.Char
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			sTag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance3 = db;
			object[] array4 = new object[3]
			{
				"@indice",
				iIndice,
				OleDbType.Integer
			};
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iIndice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
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

	public void EditaNomeFuncaoVeiaDeUmCabo(string sNovoNome, string sFuncao, string sTag, int iIndice)
	{
		try
		{
			string text = "UPDATE Veias SET Nome_Veia=@nome_veia, Funcao=@funcao WHERE Tag=@tag and Indice=@indice";
			object instance = db;
			object[] array = new object[3]
			{
				"@nome_veia",
				sNovoNome,
				OleDbType.Char
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			sNovoNome = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@funcao",
				sFuncao,
				OleDbType.Char
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			sFuncao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance3 = db;
			object[] array4 = new object[3]
			{
				"@tag",
				sTag,
				OleDbType.Char
			};
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			sTag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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

	public void PesquisaCabosFaltantesNoBanco(ref structureCadernoMigra[] VeiasCaderno)
	{
		try
		{
			string text = "";
			int num = Information.UBound(VeiasCaderno);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				text = "Select Tag, Pn1, Pn2 FROM Cabos WHERE Tag =@tag";
				object instance = db;
				object[] array = new object[3] { "@tag", null, null };
				ref string sTag = ref VeiasCaderno[i].sTag0;
				array[1] = sTag;
				array[2] = OleDbType.Char;
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				sTag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				VeiasCaderno[i].bOK = false;
				if (dataTable.Rows.Count == 1)
				{
					string right = Conversions.ToString(dataTable.Rows[0][0]);
					int num2 = Conversions.ToInteger(dataTable.Rows[0][1]);
					int num3 = Conversions.ToInteger(dataTable.Rows[0][2]);
					VeiasCaderno[i].bOK = true;
					if (Operators.CompareString(VeiasCaderno[i].sTag0, right, TextCompare: true) == 0 && (((VeiasCaderno[i].iPn1 == num2) & (VeiasCaderno[i].iPn2 == num3)) | ((VeiasCaderno[i].iPn1 == num3) & (VeiasCaderno[i].iPn2 == num2))))
					{
						VeiasCaderno[i].bOK = false;
					}
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
		}
	}

	public void LeCabosTodosOsCabos(ref List<string> lCabos)
	{
		checked
		{
			try
			{
				string text = "Select Tag FROM Cabos";
				object instance = db;
				object[] array = new object[1] { text };
				object[] array2 = array;
				object obj = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				lCabos.Clear();
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (!lCabos.Contains(Conversions.ToString(dataTable.Rows[i][0])))
						{
							lCabos.Add(Conversions.ToString(dataTable.Rows[i][0]));
						}
					}
				}
				lCabos.Sort();
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

	public void LeTodasasVeias(ref List<string> lVeias)
	{
		checked
		{
			try
			{
				string text = "Select Tag FROM Veias";
				object instance = db;
				object[] array = new object[1] { text };
				object[] array2 = array;
				object obj = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				lVeias.Clear();
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (!lVeias.Contains(Conversions.ToString(dataTable.Rows[i][0])))
					{
						lVeias.Add(Conversions.ToString(dataTable.Rows[i][0]));
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
			}
		}
	}

	public void LeDadosDeUmCabo(string sCaboOrigem, ref ClsCabos.StructureCabo Cabo)
	{
		checked
		{
			try
			{
				string text = "Select Tag, Formacao, Blindagem, Pn1, Pn2, Funcao, Alarme, Aterrar, Comprimento, Trajeto, Instrucao, Diametro, Grupo, Cabos FROM Cabos where Tag =@tag";
				object instance = db;
				object[] array = new object[3]
				{
					"@tag",
					sCaboOrigem,
					OleDbType.Char
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				sCaboOrigem = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
						Cabo.sTag = Conversions.ToString(dataTable.Rows[i][0]);
						Cabo.sFormacao = Conversions.ToString(dataTable.Rows[i][1]);
						Cabo.bBlindagem = Conversions.ToBoolean(dataTable.Rows[i][2]);
						Cabo.iPn1 = Conversions.ToInteger(dataTable.Rows[i][3]);
						Cabo.iPn2 = Conversions.ToInteger(dataTable.Rows[i][4]);
						Cabo.sFuncao = dataTable.Rows[i][5].ToString();
						Cabo.iAlarme = 0;
						Cabo.iAterrar = Conversions.ToInteger(dataTable.Rows[i][7]);
						Cabo.dComprimento = Conversions.ToDouble(dataTable.Rows[i][8]);
						Cabo.sTrajeto = dataTable.Rows[i][9].ToString();
						Cabo.sInstrucao = dataTable.Rows[i][10].ToString();
						Cabo.dDiametro = Conversions.ToDouble(dataTable.Rows[i][11]);
						Cabo.sGrupo = dataTable.Rows[i][12].ToString();
						Cabo.iCabos = Conversions.ToInteger(dataTable.Rows[i][13]);
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
			}
		}
	}

	public void leDadosDaVeia(string sCaboOrigem, ref ClsCabos.StructureVeia[] Veias)
	{
		checked
		{
			try
			{
				string text = "Select Tag, Indice, Nome_Veia, Uso, Handle, Arquivo, Pagina, Funcao FROM Veias where Tag=@tag";
				object instance = db;
				object[] array = new object[3]
				{
					"@tag",
					sCaboOrigem,
					OleDbType.Char
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				sCaboOrigem = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance2 = db;
				object[] array3 = new object[1] { text };
				array2 = array3;
				object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				Veias = new ClsCabos.StructureVeia[1];
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						int num2 = Information.UBound(Veias) + 1;
						Veias = (ClsCabos.StructureVeia[])Utils.CopyArray(Veias, new ClsCabos.StructureVeia[num2 + 1]);
						Veias[num2].sTag = Conversions.ToString(dataTable.Rows[i][0]);
						Veias[num2].iIndice = Conversions.ToInteger(dataTable.Rows[i][1]);
						Veias[num2].sNome = dataTable.Rows[i][2].ToString();
						Veias[num2].bUso = false;
						Veias[num2].sHandle = "";
						Veias[num2].sArquivo = "";
						Veias[num2].sPagina = "";
						Veias[num2].sFuncao = dataTable.Rows[i][7].ToString();
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
			}
		}
	}

	public void OrdenaINTERLIG_Tudo(ref DataGridView dg, string revCorrente, int iPainel)
	{
		checked
		{
			try
			{
				string text = "";
				int num = dg.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (Operators.ConditionalCompareObjectNotEqual(dg.Rows[i].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
					{
						string text2 = Conversions.ToString(dg.Rows[i].Cells[7].Value);
						text = "Select Tag_Cabo, Num_Veia FROM Interligacao4 WHERE DWG=@dwg And Revisao=@revisao And ((Handle1=@handle1 And Painel1=@pn1) Or (Handle2=@handle2 And Painel2=@pn2))";
						object instance = db;
						object[] array = new object[3] { "@dwg", null, null };
						ref int indice = ref DeclaracoesGeral.arqAtivo.Indice;
						array[1] = indice;
						array[2] = OleDbType.Integer;
						object[] array2 = array;
						NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						indice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
						object instance2 = db;
						object[] array3 = new object[3]
						{
							"@revisao",
							revCorrente,
							OleDbType.Char
						};
						array2 = array3;
						NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						revCorrente = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						object instance3 = db;
						object[] array4 = new object[3]
						{
							"@handle1",
							text2,
							OleDbType.Char
						};
						array2 = array4;
						NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						object instance4 = db;
						object[] array5 = new object[3]
						{
							"@pn1",
							iPainel,
							OleDbType.Integer
						};
						array2 = array5;
						NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						iPainel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
						object instance5 = db;
						object[] array6 = new object[3]
						{
							"@handle2",
							text2,
							OleDbType.Char
						};
						array2 = array6;
						NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						object instance6 = db;
						object[] array7 = new object[3]
						{
							"@pn2",
							iPainel,
							OleDbType.Integer
						};
						array2 = array7;
						NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						iPainel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
						object instance7 = db;
						object[] array8 = new object[1] { text };
						array2 = array8;
						object obj = NewLateBinding.LateGet(instance7, null, "ExecuteReader", array8, null, null, new bool[1] { true });
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
						DataTable dataTable = (DataTable)obj;
						if (dataTable.Rows.Count <= 0)
						{
							dg.Rows[i].Cells[13].Value = "ZZZ";
							dg.Rows[i].Cells[14].Value = "0";
						}
						else
						{
							dg.Rows[i].Cells[13].Value = dataTable.Rows[0][0].ToString();
							dg.Rows[i].Cells[14].Value = dataTable.Rows[0][1].ToString();
						}
					}
				}
				int index = 9;
				int index2 = 13;
				int index3 = 14;
				double num2 = 0.0;
				double num3 = 0.0;
				int num4 = 0;
				int num5 = dg.Rows.Count - 1;
				for (int j = 0; j <= num5; j++)
				{
					if (Operators.ConditionalCompareObjectEqual(dg.Rows[j].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
					{
						num4++;
					}
				}
				if (dg.Rows.Count - 1 < 1)
				{
					return;
				}
				int num6 = dg.Rows.Count - 2 - num4;
				for (int k = 0; k <= num6; k++)
				{
					int num7 = dg.Rows.Count - 2 - num4;
					for (int l = num7; l >= 0; l += -1)
					{
						if (!Operators.ConditionalCompareObjectNotEqual(dg.Rows[l].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
						{
							continue;
						}
						num2 = Pagina.calculaPaginaDecimal(Conversions.ToString(dg.Rows[l].Cells[index].Value));
						num3 = Pagina.calculaPaginaDecimal(Conversions.ToString(dg.Rows[l + 1].Cells[index].Value));
						if (num2 > num3)
						{
							int num8 = dg.ColumnCount - 1;
							for (int m = 0; m <= num8; m++)
							{
								object objectValue = RuntimeHelpers.GetObjectValue(dg.Rows[l].Cells[m].Value);
								dg.Rows[l].Cells[m].Value = RuntimeHelpers.GetObjectValue(dg.Rows[l + 1].Cells[m].Value);
								dg.Rows[l + 1].Cells[m].Value = RuntimeHelpers.GetObjectValue(objectValue);
							}
						}
						if (num2 == num3 && Operators.ConditionalCompareObjectGreater(dg.Rows[l].Cells[index2].Value, dg.Rows[l + 1].Cells[index2].Value, TextCompare: true))
						{
							int num9 = dg.ColumnCount - 1;
							for (int n = 0; n <= num9; n++)
							{
								object objectValue2 = RuntimeHelpers.GetObjectValue(dg.Rows[l].Cells[n].Value);
								dg.Rows[l].Cells[n].Value = RuntimeHelpers.GetObjectValue(dg.Rows[l + 1].Cells[n].Value);
								dg.Rows[l + 1].Cells[n].Value = RuntimeHelpers.GetObjectValue(objectValue2);
							}
						}
						if (num2 == num3 && Operators.ConditionalCompareObjectEqual(dg.Rows[l].Cells[index2].Value, dg.Rows[l + 1].Cells[index2].Value, TextCompare: true) && Operators.ConditionalCompareObjectGreater(dg.Rows[l].Cells[index3].Value, dg.Rows[l + 1].Cells[index3].Value, TextCompare: true))
						{
							int num10 = dg.ColumnCount - 1;
							for (int num11 = 0; num11 <= num10; num11++)
							{
								object objectValue3 = RuntimeHelpers.GetObjectValue(dg.Rows[l].Cells[num11].Value);
								dg.Rows[l].Cells[num11].Value = RuntimeHelpers.GetObjectValue(dg.Rows[l + 1].Cells[num11].Value);
								dg.Rows[l + 1].Cells[num11].Value = RuntimeHelpers.GetObjectValue(objectValue3);
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
			finally
			{
			}
		}
	}

	public void OrdenaINTERLIG_Indefinidos(ref DataGridView dg, double ordem, double proximoBorne, string revCorrente, int iPainel)
	{
		checked
		{
			try
			{
				int num = 0;
				int num2 = dg.Rows.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					if (Operators.CompareString(dg.Rows[i].Cells[2].Value.ToString(), "?", TextCompare: true) == 0)
					{
						num++;
					}
				}
				if (num > 0)
				{
					int num3 = num;
					for (int j = 0; j <= num3; j++)
					{
						if (Operators.ConditionalCompareObjectNotEqual(dg.Rows[j].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
						{
							string text = Conversions.ToString(dg.Rows[j].Cells[7].Value);
							string text2 = "Select Tag_Cabo, Num_Veia FROM Interligacao4 WHERE DWG=@dwg And Revisao=@revisao And ((Handle1=@handle1 And Painel1=@pn1) Or (Handle2=@handle2 And Painel2=@pn2))";
							object instance = db;
							object[] array = new object[3] { "@dwg", null, null };
							ref int indice = ref DeclaracoesGeral.arqAtivo.Indice;
							array[1] = indice;
							array[2] = OleDbType.Integer;
							object[] array2 = array;
							NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							indice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
							object instance2 = db;
							object[] array3 = new object[3]
							{
								"@revisao",
								revCorrente,
								OleDbType.Char
							};
							array2 = array3;
							NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							revCorrente = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
							object instance3 = db;
							object[] array4 = new object[3]
							{
								"@handle1",
								text,
								OleDbType.Char
							};
							array2 = array4;
							NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
							object instance4 = db;
							object[] array5 = new object[3]
							{
								"@pn1",
								iPainel,
								OleDbType.Integer
							};
							array2 = array5;
							NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							iPainel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
							object instance5 = db;
							object[] array6 = new object[3]
							{
								"@handle2",
								text,
								OleDbType.Char
							};
							array2 = array6;
							NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
							object instance6 = db;
							object[] array7 = new object[3]
							{
								"@pn2",
								iPainel,
								OleDbType.Integer
							};
							array2 = array7;
							NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
							iPainel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
							object instance7 = db;
							object[] array8 = new object[1] { text2 };
							array2 = array8;
							object obj = NewLateBinding.LateGet(instance7, null, "ExecuteReader", array8, null, null, new bool[1] { true });
							text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
							DataTable dataTable = (DataTable)obj;
							if (dataTable.Rows.Count <= 0)
							{
								dg.Rows[j].Cells[13].Value = "ZZZ";
								dg.Rows[j].Cells[14].Value = "0";
							}
							else
							{
								dg.Rows[j].Cells[13].Value = dataTable.Rows[0][0].ToString();
								dg.Rows[j].Cells[14].Value = dataTable.Rows[0][1].ToString();
							}
						}
					}
				}
				int index = 9;
				int index2 = 13;
				int index3 = 14;
				double num4 = 0.0;
				double num5 = 0.0;
				if (dg.Rows.Count - 1 >= 1)
				{
					int num6 = num;
					for (int k = 0; k <= num6; k++)
					{
						int num7 = num - 1;
						for (int l = num7; l >= 0; l += -1)
						{
							if (!Operators.ConditionalCompareObjectNotEqual(dg.Rows[l].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
							{
								continue;
							}
							num4 = Pagina.calculaPaginaDecimal(Conversions.ToString(dg.Rows[l].Cells[index].Value));
							num5 = Pagina.calculaPaginaDecimal(Conversions.ToString(dg.Rows[l + 1].Cells[index].Value));
							if (num4 > num5)
							{
								int num8 = dg.ColumnCount - 1;
								for (int m = 0; m <= num8; m++)
								{
									object objectValue = RuntimeHelpers.GetObjectValue(dg.Rows[l].Cells[m].Value);
									dg.Rows[l].Cells[m].Value = RuntimeHelpers.GetObjectValue(dg.Rows[l + 1].Cells[m].Value);
									dg.Rows[l + 1].Cells[m].Value = RuntimeHelpers.GetObjectValue(objectValue);
								}
							}
							if (num4 == num5 && Operators.ConditionalCompareObjectLess(dg.Rows[l].Cells[index2].Value, dg.Rows[l + 1].Cells[index2].Value, TextCompare: true))
							{
								int num9 = dg.ColumnCount - 1;
								for (int n = 0; n <= num9; n++)
								{
									object objectValue2 = RuntimeHelpers.GetObjectValue(dg.Rows[l].Cells[n].Value);
									dg.Rows[l].Cells[n].Value = RuntimeHelpers.GetObjectValue(dg.Rows[l + 1].Cells[n].Value);
									dg.Rows[l + 1].Cells[n].Value = RuntimeHelpers.GetObjectValue(objectValue2);
								}
							}
							if (num4 == num5 && Operators.ConditionalCompareObjectEqual(dg.Rows[l].Cells[index2].Value, dg.Rows[l + 1].Cells[index2].Value, TextCompare: true) && Operators.ConditionalCompareObjectGreater(dg.Rows[l].Cells[index3].Value, dg.Rows[l + 1].Cells[index3].Value, TextCompare: true))
							{
								int num10 = dg.ColumnCount - 1;
								for (int num11 = 0; num11 <= num10; num11++)
								{
									object objectValue3 = RuntimeHelpers.GetObjectValue(dg.Rows[l].Cells[num11].Value);
									dg.Rows[l].Cells[num11].Value = RuntimeHelpers.GetObjectValue(dg.Rows[l + 1].Cells[num11].Value);
									dg.Rows[l + 1].Cells[num11].Value = RuntimeHelpers.GetObjectValue(objectValue3);
								}
							}
						}
					}
				}
				int num12 = dg.Rows.Count - 1;
				for (int num13 = 0; num13 <= num12; num13++)
				{
					if (Operators.CompareString(dg.Rows[num13].Cells[2].Value.ToString(), "?", TextCompare: true) == 0)
					{
						dg.Rows[num13].Cells[2].Value = Conversions.ToString((int)Math.Round(proximoBorne));
						dg.Rows[num13].Cells[1].Value = (int)Math.Round(ordem);
						proximoBorne++;
						ordem++;
					}
				}
				int num14 = 0;
				int num15 = dg.Rows.Count - 1;
				for (int num16 = 0; num16 <= num15; num16++)
				{
					if (Operators.ConditionalCompareObjectEqual(dg.Rows[num16].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
					{
						num14++;
					}
				}
				if (dg.Rows.Count - 1 >= 1)
				{
					int num17 = dg.Rows.Count - 2 - num14;
					for (int num18 = 0; num18 <= num17; num18++)
					{
						int num19 = dg.Rows.Count - 2 - num14;
						for (int num20 = num19; num20 >= 0; num20 += -1)
						{
							if (Operators.ConditionalCompareObjectNotEqual(dg.Rows[num20].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true) && Operators.ConditionalCompareObjectGreater(dg.Rows[num20].Cells[1].Value, dg.Rows[num20 + 1].Cells[1].Value, TextCompare: true))
							{
								int num21 = dg.ColumnCount - 1;
								for (int num22 = 0; num22 <= num21; num22++)
								{
									object objectValue4 = RuntimeHelpers.GetObjectValue(dg.Rows[num20].Cells[num22].Value);
									dg.Rows[num20].Cells[num22].Value = RuntimeHelpers.GetObjectValue(dg.Rows[num20 + 1].Cells[num22].Value);
									dg.Rows[num20 + 1].Cells[num22].Value = RuntimeHelpers.GetObjectValue(objectValue4);
								}
							}
						}
					}
				}
				int num23 = dg.Rows.Count - 1;
				for (int num24 = 0; num24 <= num23; num24++)
				{
					dg.Rows[num24].Cells[1].Value = num24 + 1;
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

	public void CarregaVeias4Copel(string sRev, ref List<string> lCabos, List<int> lPainelSel, bool bBlindagemVeia)
	{
		checked
		{
			try
			{
				string text = "Select Tag, Formacao, Funcao, Aterrar, Pn1, Pn2, Blindagem, Cabos FROM Cabos4 WHERE Revisao=@revisao ORDER BY Tag";
				object instance = db;
				object[] array = new object[3]
				{
					"@revisao",
					sRev,
					OleDbType.Char
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				sRev = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance2 = db;
				object[] array3 = new object[1] { text };
				array2 = array3;
				object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count > 0)
				{
					DeclaracoesGeral._uscPagina.Quantidade = dataTable.Rows.Count - 1;
					DeclaracoesGeral._uscPagina.pbIniciar();
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if ((lPainelSel.Contains(Conversions.ToInteger(dataTable.Rows[i][4])) | lPainelSel.Contains(Conversions.ToInteger(dataTable.Rows[i][5]))) && !lCabos.Contains(Conversions.ToString(dataTable.Rows[i][0])))
						{
							lCabos.Add(Conversions.ToString(dataTable.Rows[i][0]));
						}
						DeclaracoesGeral._uscPagina.pbPasso();
					}
				}
				lCabos.Sort();
				DeclaracoesGeral._uscPagina.pbFim();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void CarregaVeias4(string sRev, ref List<string> lCabosUnico, List<int> lPainelSel, ref clsVeias.StructureVeias[] mVeias, bool bSepara, bool bBlindagemVeia = false)
	{
		checked
		{
			try
			{
				string text = "Select Tag, Formacao, Funcao, Aterrar, Pn1, Pn2, Blindagem, Cabos, Comprimento FROM Cabos4 WHERE Revisao=@revisao ORDER BY Tag";
				object instance = db;
				object[] array = new object[3]
				{
					"@revisao",
					sRev,
					OleDbType.Char
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				sRev = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance2 = db;
				object[] array3 = new object[1] { text };
				array2 = array3;
				object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (bSepara)
				{
					int num = Information.UBound(mVeias) + 1;
					mVeias = (clsVeias.StructureVeias[])Utils.CopyArray(mVeias, new clsVeias.StructureVeias[num + 1]);
					mVeias[num].iPainelSel = lPainelSel[0];
					mVeias[num].sTag = "";
					mVeias[num].iIndice = -1000;
				}
				if (dataTable.Rows.Count > 0)
				{
					DeclaracoesGeral._uscPagina.Quantidade = dataTable.Rows.Count - 1;
					DeclaracoesGeral._uscPagina.pbIniciar();
					int num2 = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num2; i++)
					{
						if (lPainelSel.Contains(Conversions.ToInteger(dataTable.Rows[i][4])) | lPainelSel.Contains(Conversions.ToInteger(dataTable.Rows[i][5])))
						{
							clsVeias.StructureVeias structureVeias = new clsVeias.StructureVeias
							{
								iAterrar = Conversions.ToInteger(dataTable.Rows[i][3]),
								dComprimento = Conversions.ToDouble(dataTable.Rows[i][8]),
								sAterrar1 = "",
								sAterrar2 = ""
							};
							if (structureVeias.iAterrar == 3)
							{
								structureVeias.sAterrar1 = "X";
								structureVeias.sAterrar2 = "X";
							}
							int num3 = lPainelSel.Count - 1;
							for (int j = 0; j <= num3; j++)
							{
								if (!Operators.ConditionalCompareObjectEqual(lPainelSel[j], dataTable.Rows[i][4], TextCompare: true))
								{
									if (Operators.ConditionalCompareObjectEqual(lPainelSel[j], dataTable.Rows[i][5], TextCompare: true))
									{
										structureVeias.iPn1 = Conversions.ToInteger(dataTable.Rows[i][5]);
										structureVeias.sPainel1 = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][5]));
										structureVeias.iPn2 = Conversions.ToInteger(dataTable.Rows[i][4]);
										structureVeias.sPainel2 = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][4]));
										if (structureVeias.iAterrar == 1)
										{
											structureVeias.sAterrar2 = "X";
										}
										if (structureVeias.iAterrar == 2)
										{
											structureVeias.sAterrar1 = "X";
										}
										break;
									}
									continue;
								}
								structureVeias.iPn1 = Conversions.ToInteger(dataTable.Rows[i][4]);
								structureVeias.sPainel1 = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][4]));
								structureVeias.iPn2 = Conversions.ToInteger(dataTable.Rows[i][5]);
								structureVeias.sPainel2 = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][5]));
								if (structureVeias.iAterrar == 1)
								{
									structureVeias.sAterrar1 = "X";
								}
								if (structureVeias.iAterrar == 2)
								{
									structureVeias.sAterrar2 = "X";
								}
								break;
							}
							structureVeias.sTag = Conversions.ToString(dataTable.Rows[i][0]);
							structureVeias.sFormacao = Conversions.ToString(dataTable.Rows[i][1]);
							structureVeias.bBlindagem = Conversions.ToBoolean(dataTable.Rows[i][6]);
							if (!Operators.ConditionalCompareObjectEqual(dataTable.Rows[i][6], true, TextCompare: true))
							{
								structureVeias.sFormacao = Conversions.ToString(dataTable.Rows[i][1]);
							}
							else
							{
								structureVeias.sFormacao = Conversions.ToString(Operators.AddObject(Operators.AddObject("(", dataTable.Rows[i][1]), ")"));
							}
							structureVeias.iCabos = Conversions.ToInteger(dataTable.Rows[i][7]);
							if (Operators.ConditionalCompareObjectGreater(dataTable.Rows[i][7], 1, TextCompare: true))
							{
								structureVeias.sFormacao = dataTable.Rows[i][7].ToString() + "x" + structureVeias.sFormacao;
							}
							structureVeias.sFuncao = Conversions.ToString(dataTable.Rows[i][2]);
							structureVeias.sBorne1 = "";
							structureVeias.sBorne2 = "";
							structureVeias.sDiagrama = "";
							structureVeias.sDisp1 = "";
							structureVeias.sDisp2 = "";
							structureVeias.sPagina1 = "";
							structureVeias.sVeia = "";
							clsVeias.StructureUmaVeia[] mVeia = new clsVeias.StructureUmaVeia[1];
							CarregaUmaVeias4Copel(structureVeias.sTag, sRev, ref mVeia, bBlindagemVeia);
							clsVeias.StructureVeias[] array4 = new clsVeias.StructureVeias[1];
							List<string> list = new List<string>();
							int num4 = Information.UBound(mVeia);
							for (int k = 1; k <= num4; k++)
							{
								if (mVeia[k].iIndice <= -51)
								{
									continue;
								}
								int num5 = Information.UBound(array4) + 1;
								array4 = (clsVeias.StructureVeias[])Utils.CopyArray(array4, new clsVeias.StructureVeias[num5 + 1]);
								array4[num5] = structureVeias;
								array4[num5].sVeia = Conversions.ToString(mVeia[k].iIndice);
								array4[num5].iIndice = mVeia[k].iIndice;
								if (Operators.CompareString(mVeia[k].sNome_Veia, "", TextCompare: true) != 0)
								{
									array4[num5].sVeia = mVeia[k].sNome_Veia;
								}
								clsVeias.StructureInterComplementa mVeia2 = new clsVeias.StructureInterComplementa
								{
									DWG1 = 0,
									DWG2 = 0,
									Painel1 = 0,
									Painel2 = 0,
									sAlternativo1 = "",
									sAlternativo2 = "",
									sDocumento1 = "",
									sDocumento2 = "",
									sNRegua1 = "",
									sNRegua2 = "",
									sPagina1 = "",
									sPagina2 = "",
									sTag1 = "",
									sTag2 = "",
									sTerminal1 = "",
									sTerminal2 = ""
								};
								CarregaDadosInterlig4(sRev, structureVeias.sTag, mVeia[k].iIndice, ref mVeia2);
								if (mVeia[k].iIndice <= 0)
								{
									if ((mVeia2.Painel1 != 0) | (mVeia2.Painel2 != 0))
									{
										if (array4[num5].iPn1 == mVeia2.Painel1)
										{
											array4[num5].sDisp1 = mVeia2.sTag1;
											array4[num5].sBorne1 = Indefinido(mVeia2.sTerminal1);
											array4[num5].sAterrar1 = "";
											if (Operators.CompareString(mVeia2.sNRegua1, "", TextCompare: true) != 0)
											{
												array4[num5].sDisp1 = mVeia2.sNRegua1;
											}
											array4[num5].sPagina1 = mVeia2.sPagina1;
										}
										if (array4[num5].iPn2 == mVeia2.Painel2)
										{
											array4[num5].sDisp2 = mVeia2.sTag2;
											array4[num5].sBorne2 = Indefinido(mVeia2.sTerminal2);
											array4[num5].sAterrar2 = "";
											if (Operators.CompareString(mVeia2.sNRegua2, "", TextCompare: true) != 0)
											{
												array4[num5].sDisp2 = mVeia2.sNRegua2;
											}
											array4[num5].sPagina2 = mVeia2.sPagina2;
										}
										if (array4[num5].iPn1 == mVeia2.Painel2)
										{
											array4[num5].sDisp1 = mVeia2.sTag2;
											array4[num5].sBorne1 = Indefinido(mVeia2.sTerminal2);
											array4[num5].sAterrar1 = "";
											if (Operators.CompareString(mVeia2.sNRegua2, "", TextCompare: true) != 0)
											{
												array4[num5].sDisp1 = mVeia2.sNRegua2;
											}
											array4[num5].sPagina1 = mVeia2.sPagina2;
										}
										if (array4[num5].iPn2 == mVeia2.Painel1)
										{
											array4[num5].sDisp2 = mVeia2.sTag1;
											array4[num5].sBorne2 = Indefinido(mVeia2.sTerminal1);
											array4[num5].sAterrar2 = "";
											if (Operators.CompareString(mVeia2.sNRegua1, "", TextCompare: true) != 0)
											{
												array4[num5].sDisp2 = mVeia2.sNRegua1;
											}
											array4[num5].sPagina2 = mVeia2.sPagina1;
										}
										if (Operators.CompareString(mVeia2.sDocumento1, "", TextCompare: true) != 0 && !list.Contains(mVeia2.sDocumento1))
										{
											list.Add(mVeia2.sDocumento1);
										}
										if (Operators.CompareString(mVeia2.sDocumento2, "", TextCompare: true) != 0 && !list.Contains(mVeia2.sDocumento2))
										{
											list.Add(mVeia2.sDocumento2);
										}
									}
									CarregaDadosInterlig4(sRev, structureVeias.sTag, mVeia[k + 1].iIndice, ref mVeia2);
									if ((mVeia2.Painel1 != 0) | (mVeia2.Painel2 != 0))
									{
										if (array4[num5].iPn1 == mVeia2.Painel1)
										{
											array4[num5].sDisp1 = mVeia2.sTag1;
											array4[num5].sBorne1 = Indefinido(mVeia2.sTerminal1);
											array4[num5].sPagina1 = mVeia2.sPagina1;
										}
										if (array4[num5].iPn2 == mVeia2.Painel2)
										{
											array4[num5].sDisp2 = mVeia2.sTag2;
											array4[num5].sBorne2 = Indefinido(mVeia2.sTerminal2);
											array4[num5].sPagina2 = mVeia2.sPagina2;
										}
										if (array4[num5].iPn1 == mVeia2.Painel2)
										{
											array4[num5].sDisp1 = mVeia2.sTag2;
											array4[num5].sBorne1 = Indefinido(mVeia2.sTerminal2);
											array4[num5].sPagina1 = mVeia2.sPagina2;
										}
										if (array4[num5].iPn2 == mVeia2.Painel1)
										{
											array4[num5].sDisp2 = mVeia2.sTag1;
											array4[num5].sBorne2 = Indefinido(mVeia2.sTerminal1);
											array4[num5].sPagina2 = mVeia2.sPagina1;
										}
										if (Operators.CompareString(mVeia2.sDocumento1, "", TextCompare: true) != 0 && !list.Contains(mVeia2.sDocumento1))
										{
											list.Add(mVeia2.sDocumento1);
										}
										if (Operators.CompareString(mVeia2.sDocumento2, "", TextCompare: true) != 0 && !list.Contains(mVeia2.sDocumento2))
										{
											list.Add(mVeia2.sDocumento2);
										}
									}
								}
								else
								{
									if (!((mVeia2.Painel1 != 0) | (mVeia2.Painel2 != 0)))
									{
										continue;
									}
									if (array4[num5].iPn1 == mVeia2.Painel1)
									{
										array4[num5].sDisp1 = mVeia2.sTag1;
										array4[num5].sBorne1 = Indefinido(mVeia2.sTerminal1);
										array4[num5].sAterrar1 = "";
										if (Operators.CompareString(mVeia2.sNRegua1, "", TextCompare: true) != 0)
										{
											array4[num5].sDisp1 = mVeia2.sNRegua1;
										}
										array4[num5].sPagina1 = mVeia2.sPagina1;
									}
									if (array4[num5].iPn2 == mVeia2.Painel2)
									{
										array4[num5].sDisp2 = mVeia2.sTag2;
										array4[num5].sBorne2 = Indefinido(mVeia2.sTerminal2);
										array4[num5].sAterrar2 = "";
										if (Operators.CompareString(mVeia2.sNRegua2, "", TextCompare: true) != 0)
										{
											array4[num5].sDisp2 = mVeia2.sNRegua2;
										}
										array4[num5].sPagina2 = mVeia2.sPagina2;
									}
									if (array4[num5].iPn1 == mVeia2.Painel2)
									{
										array4[num5].sDisp1 = mVeia2.sTag2;
										array4[num5].sBorne1 = Indefinido(mVeia2.sTerminal2);
										array4[num5].sAterrar1 = "";
										if (Operators.CompareString(mVeia2.sNRegua2, "", TextCompare: true) != 0)
										{
											array4[num5].sDisp1 = mVeia2.sNRegua2;
										}
										array4[num5].sPagina1 = mVeia2.sPagina2;
									}
									if (array4[num5].iPn2 == mVeia2.Painel1)
									{
										array4[num5].sDisp2 = mVeia2.sTag1;
										array4[num5].sBorne2 = Indefinido(mVeia2.sTerminal1);
										array4[num5].sAterrar2 = "";
										if (Operators.CompareString(mVeia2.sNRegua1, "", TextCompare: true) != 0)
										{
											array4[num5].sDisp2 = mVeia2.sNRegua1;
										}
										array4[num5].sPagina2 = mVeia2.sPagina1;
									}
									if (Operators.CompareString(mVeia2.sDocumento1, "", TextCompare: true) != 0 && !list.Contains(mVeia2.sDocumento1))
									{
										list.Add(mVeia2.sDocumento1);
									}
									if (Operators.CompareString(mVeia2.sDocumento2, "", TextCompare: true) != 0 && !list.Contains(mVeia2.sDocumento2))
									{
										list.Add(mVeia2.sDocumento2);
									}
								}
							}
							string text2 = "";
							if (list.Count > 0)
							{
								list.Sort();
								int num6 = list.Count - 1;
								for (int l = 0; l <= num6; l++)
								{
									text2 = ((Operators.CompareString(text2, "", TextCompare: true) == 0) ? list[l] : (text2 + ", " + list[l]));
								}
							}
							bool flag = false;
							if (Information.UBound(array4) > 0)
							{
								if (!lCabosUnico.Contains(array4[1].sTag))
								{
									lCabosUnico.Add(array4[1].sTag);
									flag = true;
								}
								else
								{
									flag = false;
								}
							}
							if (flag)
							{
								int num7 = Information.UBound(array4);
								for (int m = 1; m <= num7; m++)
								{
									int num8 = Information.UBound(mVeias) + 1;
									mVeias = (clsVeias.StructureVeias[])Utils.CopyArray(mVeias, new clsVeias.StructureVeias[num8 + 1]);
									mVeias[num8].iPainelSel = 0;
									mVeias[num8] = array4[m];
									mVeias[num8].sDiagrama = text2;
								}
							}
							list.Clear();
						}
						DeclaracoesGeral._uscPagina.pbPasso();
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

	public void CarregaVeias4Copel(string sRev, ref List<string> lCabosUnico, ref List<string> lCabos, List<int> lPainelSel, ref clsVeias.StructureVeias[] mVeias, bool bSepara, bool bBlindagemVeia = false)
	{
		checked
		{
			try
			{
				string text = "Select Tag, Formacao, Funcao, Aterrar, Pn1, Pn2, Blindagem, Cabos, Comprimento FROM Cabos4 WHERE Revisao=@revisao ORDER BY Tag";
				object instance = db;
				object[] array = new object[3]
				{
					"@revisao",
					sRev,
					OleDbType.Char
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				sRev = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance2 = db;
				object[] array3 = new object[1] { text };
				array2 = array3;
				object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (bSepara)
				{
					int num = Information.UBound(mVeias) + 1;
					mVeias = (clsVeias.StructureVeias[])Utils.CopyArray(mVeias, new clsVeias.StructureVeias[num + 1]);
					mVeias[num].iPainelSel = lPainelSel[0];
					mVeias[num].sTag = "";
					mVeias[num].iIndice = -1000;
				}
				if (dataTable.Rows.Count > 0)
				{
					DeclaracoesGeral._uscPagina.Quantidade = dataTable.Rows.Count - 1;
					DeclaracoesGeral._uscPagina.pbIniciar();
					int num2 = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num2; i++)
					{
						if (lCabos.Count > 0 && lCabos.Contains(Conversions.ToString(dataTable.Rows[i][0])) && (lPainelSel.Contains(Conversions.ToInteger(dataTable.Rows[i][4])) | lPainelSel.Contains(Conversions.ToInteger(dataTable.Rows[i][5]))))
						{
							clsVeias.StructureVeias structureVeias = new clsVeias.StructureVeias
							{
								iAterrar = Conversions.ToInteger(dataTable.Rows[i][3]),
								dComprimento = Conversions.ToDouble(dataTable.Rows[i][8]),
								sAterrar1 = "",
								sAterrar2 = ""
							};
							if (structureVeias.iAterrar == 3)
							{
								structureVeias.sAterrar1 = "X";
								structureVeias.sAterrar2 = "X";
							}
							int num3 = lPainelSel.Count - 1;
							for (int j = 0; j <= num3; j++)
							{
								if (!Operators.ConditionalCompareObjectEqual(lPainelSel[j], dataTable.Rows[i][4], TextCompare: true))
								{
									if (Operators.ConditionalCompareObjectEqual(lPainelSel[j], dataTable.Rows[i][5], TextCompare: true))
									{
										structureVeias.iPn1 = Conversions.ToInteger(dataTable.Rows[i][5]);
										structureVeias.sPainel1 = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][5]));
										structureVeias.iPn2 = Conversions.ToInteger(dataTable.Rows[i][4]);
										structureVeias.sPainel2 = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][4]));
										if (structureVeias.iAterrar == 1)
										{
											structureVeias.sAterrar2 = "X";
										}
										if (structureVeias.iAterrar == 2)
										{
											structureVeias.sAterrar1 = "X";
										}
										break;
									}
									continue;
								}
								structureVeias.iPn1 = Conversions.ToInteger(dataTable.Rows[i][4]);
								structureVeias.sPainel1 = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][4]));
								structureVeias.iPn2 = Conversions.ToInteger(dataTable.Rows[i][5]);
								structureVeias.sPainel2 = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][5]));
								if (structureVeias.iAterrar == 1)
								{
									structureVeias.sAterrar1 = "X";
								}
								if (structureVeias.iAterrar == 2)
								{
									structureVeias.sAterrar2 = "X";
								}
								break;
							}
							structureVeias.sTag = Conversions.ToString(dataTable.Rows[i][0]);
							structureVeias.sFormacao = Conversions.ToString(dataTable.Rows[i][1]);
							structureVeias.bBlindagem = Conversions.ToBoolean(dataTable.Rows[i][6]);
							if (!Operators.ConditionalCompareObjectEqual(dataTable.Rows[i][6], true, TextCompare: true))
							{
								structureVeias.sFormacao = Conversions.ToString(dataTable.Rows[i][1]);
							}
							else
							{
								structureVeias.sFormacao = Conversions.ToString(Operators.AddObject(Operators.AddObject("(", dataTable.Rows[i][1]), ")"));
							}
							structureVeias.iCabos = Conversions.ToInteger(dataTable.Rows[i][7]);
							if (Operators.ConditionalCompareObjectGreater(dataTable.Rows[i][7], 1, TextCompare: true))
							{
								structureVeias.sFormacao = dataTable.Rows[i][7].ToString() + "x" + structureVeias.sFormacao;
							}
							structureVeias.sFuncao = Conversions.ToString(dataTable.Rows[i][2]);
							structureVeias.sBorne1 = "";
							structureVeias.sBorne2 = "";
							structureVeias.sDiagrama = "";
							structureVeias.sDisp1 = "";
							structureVeias.sDisp2 = "";
							structureVeias.sPagina1 = "";
							structureVeias.sVeia = "";
							clsVeias.StructureUmaVeia[] mVeia = new clsVeias.StructureUmaVeia[1];
							CarregaUmaVeias4Copel(structureVeias.sTag, sRev, ref mVeia, bBlindagemVeia);
							clsVeias.StructureVeias[] array4 = new clsVeias.StructureVeias[1];
							List<string> list = new List<string>();
							int num4 = Information.UBound(mVeia);
							for (int k = 1; k <= num4; k++)
							{
								if (mVeia[k].iIndice <= -51)
								{
									continue;
								}
								int num5 = Information.UBound(array4) + 1;
								array4 = (clsVeias.StructureVeias[])Utils.CopyArray(array4, new clsVeias.StructureVeias[num5 + 1]);
								array4[num5] = structureVeias;
								array4[num5].sVeia = Conversions.ToString(mVeia[k].iIndice);
								array4[num5].iIndice = mVeia[k].iIndice;
								if (Operators.CompareString(mVeia[k].sNome_Veia, "", TextCompare: true) != 0)
								{
									array4[num5].sVeia = mVeia[k].sNome_Veia;
								}
								clsVeias.StructureInterComplementa mVeia2 = new clsVeias.StructureInterComplementa
								{
									DWG1 = 0,
									DWG2 = 0,
									Painel1 = 0,
									Painel2 = 0,
									sAlternativo1 = "",
									sAlternativo2 = "",
									sDocumento1 = "",
									sDocumento2 = "",
									sNRegua1 = "",
									sNRegua2 = "",
									sPagina1 = "",
									sPagina2 = "",
									sTag1 = "",
									sTag2 = "",
									sTerminal1 = "",
									sTerminal2 = ""
								};
								CarregaDadosInterlig4(sRev, structureVeias.sTag, mVeia[k].iIndice, ref mVeia2);
								if (mVeia[k].iIndice <= 0)
								{
									if ((mVeia2.Painel1 != 0) | (mVeia2.Painel2 != 0))
									{
										if (array4[num5].iPn1 == mVeia2.Painel1)
										{
											array4[num5].sDisp1 = mVeia2.sTag1;
											array4[num5].sBorne1 = Indefinido(mVeia2.sTerminal1);
											array4[num5].sAterrar1 = "";
											if (Operators.CompareString(mVeia2.sNRegua1, "", TextCompare: true) != 0)
											{
												array4[num5].sDisp1 = mVeia2.sNRegua1;
											}
											array4[num5].sPagina1 = mVeia2.sPagina1;
										}
										if (array4[num5].iPn2 == mVeia2.Painel2)
										{
											array4[num5].sDisp2 = mVeia2.sTag2;
											array4[num5].sBorne2 = Indefinido(mVeia2.sTerminal2);
											array4[num5].sAterrar2 = "";
											if (Operators.CompareString(mVeia2.sNRegua2, "", TextCompare: true) != 0)
											{
												array4[num5].sDisp2 = mVeia2.sNRegua2;
											}
											array4[num5].sPagina2 = mVeia2.sPagina2;
										}
										if (array4[num5].iPn1 == mVeia2.Painel2)
										{
											array4[num5].sDisp1 = mVeia2.sTag2;
											array4[num5].sBorne1 = Indefinido(mVeia2.sTerminal2);
											array4[num5].sAterrar1 = "";
											if (Operators.CompareString(mVeia2.sNRegua2, "", TextCompare: true) != 0)
											{
												array4[num5].sDisp1 = mVeia2.sNRegua2;
											}
											array4[num5].sPagina1 = mVeia2.sPagina2;
										}
										if (array4[num5].iPn2 == mVeia2.Painel1)
										{
											array4[num5].sDisp2 = mVeia2.sTag1;
											array4[num5].sBorne2 = Indefinido(mVeia2.sTerminal1);
											array4[num5].sAterrar2 = "";
											if (Operators.CompareString(mVeia2.sNRegua1, "", TextCompare: true) != 0)
											{
												array4[num5].sDisp2 = mVeia2.sNRegua1;
											}
											array4[num5].sPagina2 = mVeia2.sPagina1;
										}
										if (Operators.CompareString(mVeia2.sDocumento1, "", TextCompare: true) != 0 && !list.Contains(mVeia2.sDocumento1))
										{
											list.Add(mVeia2.sDocumento1);
										}
										if (Operators.CompareString(mVeia2.sDocumento2, "", TextCompare: true) != 0 && !list.Contains(mVeia2.sDocumento2))
										{
											list.Add(mVeia2.sDocumento2);
										}
									}
									CarregaDadosInterlig4(sRev, structureVeias.sTag, mVeia[k + 1].iIndice, ref mVeia2);
									if ((mVeia2.Painel1 != 0) | (mVeia2.Painel2 != 0))
									{
										if (array4[num5].iPn1 == mVeia2.Painel1)
										{
											array4[num5].sDisp1 = mVeia2.sTag1;
											array4[num5].sBorne1 = Indefinido(mVeia2.sTerminal1);
											array4[num5].sPagina1 = mVeia2.sPagina1;
										}
										if (array4[num5].iPn2 == mVeia2.Painel2)
										{
											array4[num5].sDisp2 = mVeia2.sTag2;
											array4[num5].sBorne2 = Indefinido(mVeia2.sTerminal2);
											array4[num5].sPagina2 = mVeia2.sPagina2;
										}
										if (array4[num5].iPn1 == mVeia2.Painel2)
										{
											array4[num5].sDisp1 = mVeia2.sTag2;
											array4[num5].sBorne1 = Indefinido(mVeia2.sTerminal2);
											array4[num5].sPagina1 = mVeia2.sPagina2;
										}
										if (array4[num5].iPn2 == mVeia2.Painel1)
										{
											array4[num5].sDisp2 = mVeia2.sTag1;
											array4[num5].sBorne2 = Indefinido(mVeia2.sTerminal1);
											array4[num5].sPagina2 = mVeia2.sPagina1;
										}
										if (Operators.CompareString(mVeia2.sDocumento1, "", TextCompare: true) != 0 && !list.Contains(mVeia2.sDocumento1))
										{
											list.Add(mVeia2.sDocumento1);
										}
										if (Operators.CompareString(mVeia2.sDocumento2, "", TextCompare: true) != 0 && !list.Contains(mVeia2.sDocumento2))
										{
											list.Add(mVeia2.sDocumento2);
										}
									}
								}
								else
								{
									if (!((mVeia2.Painel1 != 0) | (mVeia2.Painel2 != 0)))
									{
										continue;
									}
									if (array4[num5].iPn1 == mVeia2.Painel1)
									{
										array4[num5].sDisp1 = mVeia2.sTag1;
										array4[num5].sBorne1 = Indefinido(mVeia2.sTerminal1);
										array4[num5].sAterrar1 = "";
										if (Operators.CompareString(mVeia2.sNRegua1, "", TextCompare: true) != 0)
										{
											array4[num5].sDisp1 = mVeia2.sNRegua1;
										}
										array4[num5].sPagina1 = mVeia2.sPagina1;
									}
									if (array4[num5].iPn2 == mVeia2.Painel2)
									{
										array4[num5].sDisp2 = mVeia2.sTag2;
										array4[num5].sBorne2 = Indefinido(mVeia2.sTerminal2);
										array4[num5].sAterrar2 = "";
										if (Operators.CompareString(mVeia2.sNRegua2, "", TextCompare: true) != 0)
										{
											array4[num5].sDisp2 = mVeia2.sNRegua2;
										}
										array4[num5].sPagina2 = mVeia2.sPagina2;
									}
									if (array4[num5].iPn1 == mVeia2.Painel2)
									{
										array4[num5].sDisp1 = mVeia2.sTag2;
										array4[num5].sBorne1 = Indefinido(mVeia2.sTerminal2);
										array4[num5].sAterrar1 = "";
										if (Operators.CompareString(mVeia2.sNRegua2, "", TextCompare: true) != 0)
										{
											array4[num5].sDisp1 = mVeia2.sNRegua2;
										}
										array4[num5].sPagina1 = mVeia2.sPagina2;
									}
									if (array4[num5].iPn2 == mVeia2.Painel1)
									{
										array4[num5].sDisp2 = mVeia2.sTag1;
										array4[num5].sBorne2 = Indefinido(mVeia2.sTerminal1);
										array4[num5].sAterrar2 = "";
										if (Operators.CompareString(mVeia2.sNRegua1, "", TextCompare: true) != 0)
										{
											array4[num5].sDisp2 = mVeia2.sNRegua1;
										}
										array4[num5].sPagina2 = mVeia2.sPagina1;
									}
									if (Operators.CompareString(mVeia2.sDocumento1, "", TextCompare: true) != 0 && !list.Contains(mVeia2.sDocumento1))
									{
										list.Add(mVeia2.sDocumento1);
									}
									if (Operators.CompareString(mVeia2.sDocumento2, "", TextCompare: true) != 0 && !list.Contains(mVeia2.sDocumento2))
									{
										list.Add(mVeia2.sDocumento2);
									}
								}
							}
							string text2 = "";
							if (list.Count > 0)
							{
								list.Sort();
								int num6 = list.Count - 1;
								for (int l = 0; l <= num6; l++)
								{
									text2 = ((Operators.CompareString(text2, "", TextCompare: true) == 0) ? list[l] : (text2 + ", " + list[l]));
								}
							}
							bool flag = false;
							if (Information.UBound(array4) > 0)
							{
								if (!lCabosUnico.Contains(array4[1].sTag))
								{
									lCabosUnico.Add(array4[1].sTag);
									flag = true;
								}
								else
								{
									flag = false;
								}
							}
							if (flag)
							{
								int num7 = Information.UBound(array4);
								for (int m = 1; m <= num7; m++)
								{
									int num8 = Information.UBound(mVeias) + 1;
									mVeias = (clsVeias.StructureVeias[])Utils.CopyArray(mVeias, new clsVeias.StructureVeias[num8 + 1]);
									mVeias[num8].iPainelSel = 0;
									mVeias[num8] = array4[m];
									mVeias[num8].sDiagrama = text2;
								}
							}
							list.Clear();
						}
						DeclaracoesGeral._uscPagina.pbPasso();
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

	public void CarregaUmaVeias4Copel(string sTag, string sRev, ref clsVeias.StructureUmaVeia[] mVeia, bool bBlindagemVeia)
	{
		checked
		{
			try
			{
				string text = "";
				text = (bBlindagemVeia ? "Select  Num_Veia, Nome_Veia, Funcao FROM Veias4 WHERE Tag=@tag And Revisao=@rev" : "Select  Num_Veia, Nome_Veia, Funcao FROM Veias4 WHERE Tag=@tag And Revisao=@rev And Num_Veia > 0");
				object[] array;
				NewLateBinding.LateCall(db, null, "AddParameter", array = new object[3]
				{
					"@tag",
					sTag,
					OleDbType.Char
				}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				sTag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(string));
				NewLateBinding.LateCall(db, null, "AddParameter", array = new object[3]
				{
					"@rev",
					sRev,
					OleDbType.Char
				}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				sRev = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(string));
				object obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array = new object[1] { text }, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						int num2 = Information.UBound(mVeia) + 1;
						mVeia = (clsVeias.StructureUmaVeia[])Utils.CopyArray(mVeia, new clsVeias.StructureUmaVeia[num2 + 1]);
						mVeia[num2].sTag = sTag;
						mVeia[num2].iIndice = Conversions.ToInteger(dataTable.Rows[i][0]);
						mVeia[num2].iIndiceOrdem = Conversions.ToDouble(dataTable.Rows[i][0]);
						mVeia[num2].sNome_Veia = Conversions.ToString(dataTable.Rows[i][1]);
						mVeia[num2].sFuncao = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][2]));
						mVeia[num2].sArquivo = "";
						mVeia[num2].sPagina = "";
					}
				}
				OrdenaAVeia(ref mVeia);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void CarregaVeiasGIGA(string sRev, ref List<string> lCabosUnico, int iPN1, int iPN2, ref clsVeias.StructureVeiasgIGA[] mVeias)
	{
		checked
		{
			try
			{
				string text = "Select Tag, Pn1, Pn2 FROM Cabos4 WHERE Revisao=@revisao ORDER BY Tag";
				object instance = db;
				object[] array = new object[3]
				{
					"@revisao",
					sRev,
					OleDbType.Char
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				sRev = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance2 = db;
				object[] array3 = new object[1] { text };
				array2 = array3;
				object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				int num = 1;
				mVeias = (clsVeias.StructureVeiasgIGA[])Utils.CopyArray(mVeias, new clsVeias.StructureVeiasgIGA[2]);
				mVeias[1].iPainelSel = iPN1;
				mVeias[1].sTag = "";
				num = 2;
				mVeias = (clsVeias.StructureVeiasgIGA[])Utils.CopyArray(mVeias, new clsVeias.StructureVeiasgIGA[3]);
				mVeias[2].iPainelSel = iPN2;
				mVeias[2].sTag = "";
				if (dataTable.Rows.Count > 0)
				{
					DeclaracoesGeral._uscPagina.Quantidade = dataTable.Rows.Count - 1;
					DeclaracoesGeral._uscPagina.pbIniciar();
					int num2 = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num2; i++)
					{
						if (Conversions.ToBoolean(Operators.OrObject(Operators.AndObject(Operators.CompareObjectEqual(dataTable.Rows[i][1], iPN1, TextCompare: true), Operators.CompareObjectEqual(dataTable.Rows[i][2], iPN2, TextCompare: true)), Operators.AndObject(Operators.CompareObjectEqual(dataTable.Rows[i][1], iPN2, TextCompare: true), Operators.CompareObjectEqual(dataTable.Rows[i][2], iPN1, TextCompare: true)))))
						{
							clsVeias.StructureVeiasgIGA structureVeiasgIGA = default;
							if (Operators.ConditionalCompareObjectEqual(dataTable.Rows[i][1], iPN1, TextCompare: true))
							{
								structureVeiasgIGA.iPn1 = Conversions.ToInteger(dataTable.Rows[i][1]);
								structureVeiasgIGA.sPainel1 = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][1]));
								structureVeiasgIGA.iPn2 = Conversions.ToInteger(dataTable.Rows[i][2]);
								structureVeiasgIGA.sPainel2 = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][2]));
							}
							if (Operators.ConditionalCompareObjectEqual(dataTable.Rows[i][1], iPN2, TextCompare: true))
							{
								structureVeiasgIGA.iPn1 = Conversions.ToInteger(dataTable.Rows[i][2]);
								structureVeiasgIGA.sPainel1 = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][2]));
								structureVeiasgIGA.iPn2 = Conversions.ToInteger(dataTable.Rows[i][1]);
								structureVeiasgIGA.sPainel2 = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][1]));
							}
							structureVeiasgIGA.sTag = Conversions.ToString(dataTable.Rows[i][0]);
							clsVeias.StructureUmaVeia[] mVeia = new clsVeias.StructureUmaVeia[1];
							CarregaUmaVeias4(structureVeiasgIGA.sTag, sRev, ref mVeia);
							clsVeias.StructureVeiasgIGA[] array4 = new clsVeias.StructureVeiasgIGA[1];
							List<string> list = new List<string>();
							int num3 = Information.UBound(mVeia);
							for (int j = 1; j <= num3; j++)
							{
								if (mVeia[j].iIndice <= -51)
								{
									continue;
								}
								num = Information.UBound(array4) + 1;
								array4 = (clsVeias.StructureVeiasgIGA[])Utils.CopyArray(array4, new clsVeias.StructureVeiasgIGA[num + 1]);
								array4[num] = structureVeiasgIGA;
								clsVeias.StructureInterComplementa mVeia2 = new clsVeias.StructureInterComplementa
								{
									DWG1 = 0,
									DWG2 = 0,
									Painel1 = 0,
									Painel2 = 0,
									sAlternativo1 = "",
									sAlternativo2 = "",
									sDocumento1 = "",
									sDocumento2 = "",
									sNRegua1 = "",
									sNRegua2 = "",
									sPagina1 = "",
									sPagina2 = "",
									sTag1 = "",
									sTag2 = "",
									sTerminal1 = "",
									sTerminal2 = ""
								};
								CarregaDadosInterlig4(sRev, structureVeiasgIGA.sTag, mVeia[j].iIndice, ref mVeia2);
								if (mVeia[j].iIndice <= 0)
								{
									if ((mVeia2.Painel1 != 0) | (mVeia2.Painel2 != 0))
									{
										if (array4[num].iPn1 == mVeia2.Painel1)
										{
											array4[num].sDisp1 = mVeia2.sTag1;
											array4[num].sBorne1 = Indefinido(mVeia2.sTerminal1);
											if (Operators.CompareString(mVeia2.sNRegua1, "", TextCompare: true) != 0)
											{
												array4[num].sDisp1 = mVeia2.sNRegua1;
											}
											array4[num].sPagina1 = mVeia2.sPagina1;
										}
										if (array4[num].iPn2 == mVeia2.Painel2)
										{
											array4[num].sDisp2 = mVeia2.sTag2;
											array4[num].sBorne2 = Indefinido(mVeia2.sTerminal2);
											if (Operators.CompareString(mVeia2.sNRegua2, "", TextCompare: true) != 0)
											{
												array4[num].sDisp2 = mVeia2.sNRegua2;
											}
											array4[num].sPagina2 = mVeia2.sPagina2;
										}
										if (array4[num].iPn1 == mVeia2.Painel2)
										{
											array4[num].sDisp1 = mVeia2.sTag2;
											array4[num].sBorne1 = Indefinido(mVeia2.sTerminal2);
											if (Operators.CompareString(mVeia2.sNRegua2, "", TextCompare: true) != 0)
											{
												array4[num].sDisp1 = mVeia2.sNRegua2;
											}
											array4[num].sPagina1 = mVeia2.sPagina2;
										}
										if (array4[num].iPn2 == mVeia2.Painel1)
										{
											array4[num].sDisp2 = mVeia2.sTag1;
											array4[num].sBorne2 = Indefinido(mVeia2.sTerminal1);
											if (Operators.CompareString(mVeia2.sNRegua1, "", TextCompare: true) != 0)
											{
												array4[num].sDisp2 = mVeia2.sNRegua1;
											}
											array4[num].sPagina2 = mVeia2.sPagina1;
										}
									}
									CarregaDadosInterlig4(sRev, structureVeiasgIGA.sTag, mVeia[j + 1].iIndice, ref mVeia2);
									if ((mVeia2.Painel1 != 0) | (mVeia2.Painel2 != 0))
									{
										if (array4[num].iPn1 == mVeia2.Painel1)
										{
											array4[num].sDisp1 = mVeia2.sTag1;
											array4[num].sBorne1 = Indefinido(mVeia2.sTerminal1);
											array4[num].sPagina1 = mVeia2.sPagina1;
										}
										if (array4[num].iPn2 == mVeia2.Painel2)
										{
											array4[num].sDisp2 = mVeia2.sTag2;
											array4[num].sBorne2 = Indefinido(mVeia2.sTerminal2);
											array4[num].sPagina2 = mVeia2.sPagina2;
										}
										if (array4[num].iPn1 == mVeia2.Painel2)
										{
											array4[num].sDisp1 = mVeia2.sTag2;
											array4[num].sBorne1 = Indefinido(mVeia2.sTerminal2);
											array4[num].sPagina1 = mVeia2.sPagina2;
										}
										if (array4[num].iPn2 == mVeia2.Painel1)
										{
											array4[num].sDisp2 = mVeia2.sTag1;
											array4[num].sBorne2 = Indefinido(mVeia2.sTerminal1);
											array4[num].sPagina2 = mVeia2.sPagina1;
										}
									}
								}
								else
								{
									if (!((mVeia2.Painel1 != 0) | (mVeia2.Painel2 != 0)))
									{
										continue;
									}
									if (array4[num].iPn1 == mVeia2.Painel1)
									{
										array4[num].sDisp1 = mVeia2.sTag1;
										array4[num].sBorne1 = Indefinido(mVeia2.sTerminal1);
										if (Operators.CompareString(mVeia2.sNRegua1, "", TextCompare: true) != 0)
										{
											array4[num].sDisp1 = mVeia2.sNRegua1;
										}
										array4[num].sPagina1 = mVeia2.sPagina1;
									}
									if (array4[num].iPn2 == mVeia2.Painel2)
									{
										array4[num].sDisp2 = mVeia2.sTag2;
										array4[num].sBorne2 = Indefinido(mVeia2.sTerminal2);
										if (Operators.CompareString(mVeia2.sNRegua2, "", TextCompare: true) != 0)
										{
											array4[num].sDisp2 = mVeia2.sNRegua2;
										}
										array4[num].sPagina2 = mVeia2.sPagina2;
									}
									if (array4[num].iPn1 == mVeia2.Painel2)
									{
										array4[num].sDisp1 = mVeia2.sTag2;
										array4[num].sBorne1 = Indefinido(mVeia2.sTerminal2);
										if (Operators.CompareString(mVeia2.sNRegua2, "", TextCompare: true) != 0)
										{
											array4[num].sDisp1 = mVeia2.sNRegua2;
										}
										array4[num].sPagina1 = mVeia2.sPagina2;
									}
									if (array4[num].iPn2 == mVeia2.Painel1)
									{
										array4[num].sDisp2 = mVeia2.sTag1;
										array4[num].sBorne2 = Indefinido(mVeia2.sTerminal1);
										if (Operators.CompareString(mVeia2.sNRegua1, "", TextCompare: true) != 0)
										{
											array4[num].sDisp2 = mVeia2.sNRegua1;
										}
										array4[num].sPagina2 = mVeia2.sPagina1;
									}
								}
							}
							bool flag = false;
							if (Information.UBound(array4) > 0)
							{
								if (!lCabosUnico.Contains(array4[1].sTag))
								{
									lCabosUnico.Add(array4[1].sTag);
									flag = true;
								}
								else
								{
									flag = false;
								}
							}
							if (flag)
							{
								int num4 = Information.UBound(array4);
								for (int k = 1; k <= num4; k++)
								{
									num = Information.UBound(mVeias) + 1;
									mVeias = (clsVeias.StructureVeiasgIGA[])Utils.CopyArray(mVeias, new clsVeias.StructureVeiasgIGA[num + 1]);
									mVeias[num].iPainelSel = 0;
									mVeias[num] = array4[k];
								}
							}
							list.Clear();
						}
						DeclaracoesGeral._uscPagina.pbPasso();
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

	public string Indefinido(string sTerminal)
	{
		string result = sTerminal;
		if (Operators.CompareString(sTerminal, "", TextCompare: true) == 0)
		{
			result = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
		}
		if (Operators.CompareString(sTerminal, "0", TextCompare: true) == 0)
		{
			result = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
		}
		return result;
	}

	public void CarregaUmaVeias4(string sTag, string sRev, ref clsVeias.StructureUmaVeia[] mVeia)
	{
		checked
		{
			try
			{
				string text = "Select  Num_Veia, Nome_Veia, Funcao FROM Veias4 WHERE Tag=@tag And Revisao=@rev";
				object instance = db;
				object[] array = new object[3]
				{
					"@tag",
					sTag,
					OleDbType.Char
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				sTag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance2 = db;
				object[] array3 = new object[3]
				{
					"@rev",
					sRev,
					OleDbType.Char
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				sRev = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
						int num2 = Information.UBound(mVeia) + 1;
						mVeia = (clsVeias.StructureUmaVeia[])Utils.CopyArray(mVeia, new clsVeias.StructureUmaVeia[num2 + 1]);
						mVeia[num2].sTag = sTag;
						mVeia[num2].iIndice = Conversions.ToInteger(dataTable.Rows[i][0]);
						mVeia[num2].iIndiceOrdem = Conversions.ToDouble(dataTable.Rows[i][0]);
						mVeia[num2].sNome_Veia = Conversions.ToString(dataTable.Rows[i][1]);
						mVeia[num2].sFuncao = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][2]));
						mVeia[num2].sArquivo = "";
						mVeia[num2].sPagina = "";
					}
				}
				OrdenaAVeia(ref mVeia);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void CarregaFuncoesDaVeias4(string sRev, ref clsVeias.StructureUmaVeia[] mVeia)
	{
		checked
		{
			try
			{
				string text = "Select Tag, Num_Veia, Nome_Veia, Funcao FROM Veias4 WHERE Revisao=@rev ORDER BY Tag, Num_Veia";
				object instance = db;
				object[] array = new object[3]
				{
					"@rev",
					sRev,
					OleDbType.Char
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				sRev = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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
						int num2 = Information.UBound(mVeia) + 1;
						mVeia = (clsVeias.StructureUmaVeia[])Utils.CopyArray(mVeia, new clsVeias.StructureUmaVeia[num2 + 1]);
						mVeia[num2].sTag = Conversions.ToString(dataTable.Rows[i][0]);
						mVeia[num2].iIndice = Conversions.ToInteger(dataTable.Rows[i][1]);
						mVeia[num2].sNome_Veia = Conversions.ToString(dataTable.Rows[i][2]);
						mVeia[num2].sFuncao = Conversions.ToString(dataTable.Rows[i][3]);
						mVeia[num2].sArquivo = "";
						mVeia[num2].sPagina = "";
					}
				}
				OrdenaAVeia(ref mVeia);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void CarregaDadosInterlig4(string sRev, string sTag, int iVeia, ref clsVeias.StructureInterComplementa mVeia)
	{
		try
		{
			string text = "Select DWG1, Documento1, Painel1, Pagina1, Tag1, Alternativo1, NRegua1, Terminal1, DWG2, Documento2, Painel2, Pagina2, Tag2, Alternativo2, NRegua2, Terminal2 FROM INTERLIGACAO4 WHERE Revisao=@rev And Tag_Cabo=@tag And Num_Veia=@veia";
			object instance = db;
			object[] array = new object[3]
			{
				"@rev",
				sRev,
				OleDbType.Char
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			sRev = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@tag",
				sTag,
				OleDbType.Char
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			sTag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance3 = db;
			object[] array4 = new object[3]
			{
				"@veia",
				iVeia,
				OleDbType.Integer
			};
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iVeia = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance4 = db;
			object[] array5 = new object[1] { text };
			array2 = array5;
			object obj = NewLateBinding.LateGet(instance4, null, "ExecuteReader", array5, null, null, new bool[1] { true });
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			DataTable dataTable = (DataTable)obj;
			if (dataTable.Rows.Count == 1)
			{
				mVeia.DWG1 = Conversions.ToInteger(dataTable.Rows[0][0]);
				mVeia.sDocumento1 = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][1]));
				mVeia.Painel1 = Conversions.ToInteger(dataTable.Rows[0][2]);
				mVeia.sPagina1 = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][3]));
				mVeia.sTag1 = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][4]));
				mVeia.sAlternativo1 = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][5]));
				mVeia.sNRegua1 = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][6]));
				mVeia.sTerminal1 = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][7]));
				mVeia.DWG2 = Conversions.ToInteger(dataTable.Rows[0][8]);
				mVeia.sDocumento2 = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][9]));
				mVeia.Painel2 = Conversions.ToInteger(clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][10])));
				mVeia.sPagina2 = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][11]));
				mVeia.sTag2 = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][12]));
				mVeia.sAlternativo2 = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][13]));
				mVeia.sNRegua2 = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][14]));
				mVeia.sTerminal2 = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0][15]));
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public void OrdenaAVeia(ref clsVeias.StructureUmaVeia[] mVeia)
	{
		checked
		{
			try
			{
				string left = "";
				int num = Information.UBound(mVeia);
				for (int i = 1; i <= num; i++)
				{
					if ((int)Math.Round(mVeia[i].iIndiceOrdem) == 1)
					{
						if (mVeia[i].sNome_Veia.ToString().Contains("P"))
						{
							left = "P";
						}
						if (mVeia[i].sNome_Veia.ToString().Contains("T"))
						{
							left = "T";
						}
					}
					if ((int)Math.Round(mVeia[i].iIndiceOrdem) == -99)
					{
						mVeia[i].iIndiceOrdem = 0.0;
					}
					if ((int)Math.Round(mVeia[i].iIndiceOrdem) < -50)
					{
						mVeia[i].iIndiceOrdem = mVeia[i].iIndiceOrdem + 50.0;
					}
				}
				if (Operators.CompareString(left, "", TextCompare: true) != 0)
				{
					int num2 = Information.UBound(mVeia);
					for (int j = 1; j <= num2; j++)
					{
						if (mVeia[j].iIndiceOrdem < 0.0)
						{
							if (Operators.CompareString(left, "P", TextCompare: true) == 0)
							{
								mVeia[j].iIndiceOrdem = mVeia[j].iIndiceOrdem * 2.0;
								mVeia[j].iIndiceOrdem = mVeia[j].iIndiceOrdem - 0.1;
							}
							if (Operators.CompareString(left, "T", TextCompare: true) == 0)
							{
								mVeia[j].iIndiceOrdem = mVeia[j].iIndiceOrdem * 3.0;
								mVeia[j].iIndiceOrdem = mVeia[j].iIndiceOrdem - 0.1;
							}
						}
					}
					int num3 = Information.UBound(mVeia);
					for (int k = 1; k <= num3; k++)
					{
						if ((int)Math.Round(mVeia[k].iIndiceOrdem) < 0)
						{
							mVeia[k].iIndiceOrdem = mVeia[k].iIndiceOrdem * -1.0;
						}
					}
				}
				clsVeias.StructureUmaVeia structureUmaVeia = default;
				if (Information.UBound(mVeia) < 2 || Information.UBound(mVeia) <= 0)
				{
					return;
				}
				int num4 = Information.UBound(mVeia);
				for (int l = 1; l <= num4; l++)
				{
					int num5 = Information.UBound(mVeia) - 1;
					int num6 = l;
					for (int m = num5; m >= num6; m += -1)
					{
						if (mVeia[m].iIndiceOrdem > mVeia[m + 1].iIndiceOrdem)
						{
							structureUmaVeia = mVeia[m + 1];
							mVeia[m + 1] = mVeia[m];
							mVeia[m] = structureUmaVeia;
						}
						if (mVeia[m].iIndiceOrdem == mVeia[m + 1].iIndiceOrdem && mVeia[m].iIndice < mVeia[m + 1].iIndice)
						{
							structureUmaVeia = mVeia[m + 1];
							mVeia[m + 1] = mVeia[m];
							mVeia[m] = structureUmaVeia;
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

	public void CorrigeOsCabosSingelos(ref List<string> lVeias)
	{
		List<string> list = new List<string>();
		checked
		{
			try
			{
				string text = "Select Tag FROM Cabos WHERE Cabos = 1";
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
						list.Add(dataTable.Rows[i][0].ToString());
					}
				}
				int num2 = list.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					_ = list[j];
					text = "Select  Nome_Veia FROM Veias WHERE DWG=@dwg And Tag=@tag And indice > 0";
					object instance2 = db;
					object[] array3 = new object[3] { "@dwg", null, null };
					ref int indice = ref DeclaracoesGeral.arqAtivo.Indice;
					array3[1] = indice;
					array3[2] = OleDbType.Integer;
					array2 = array3;
					NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					indice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					List<string> list2;
					int index;
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@tag",
						(list2 = list)[index = j],
						OleDbType.Char
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					list2[index] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DataTable dataTable2 = (DataTable)obj;
					if (dataTable2.Rows.Count == 1 && dataTable2.Rows[0][0].ToString().Contains("#"))
					{
						lVeias.Add(list[j]);
					}
				}
				int num3 = lVeias.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					text = "UPDATE Veias Set Nome_Veia='' WHERE Tag=@tag";
					List<string> list2;
					int index;
					NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
					{
						"@tag",
						(list2 = lVeias)[index = k],
						OleDbType.Char
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					list2[index] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
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

	public void CaboSingelo(ref List<string> sCaboSingelos)
	{
		checked
		{
			try
			{
				new List<string>();
				string text = "SELECT Tag FROM Cabos WHERE Formacao like '%1x%'";
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
						sCaboSingelos.Add(dataTable.Rows[i][0].ToString());
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
			}
		}
	}

	public void EditaFuncaoComprimentoTrajeto(string sTag, string sFuncao, double dComprimento, string sTrajeto, string sIsolacao)
	{
		try
		{
			string text = "UPDATE Cabos SET Funcao=@funcao, Comprimento=@comprimento, Trajeto=@trajeto, Instrucao=@instrucao WHERE Tag=@tag ";
			object instance = db;
			object[] array = new object[3]
			{
				"@funcao",
				sFuncao,
				OleDbType.Char
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			sFuncao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@comprimento",
				dComprimento,
				OleDbType.Double
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			dComprimento = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
			object instance3 = db;
			object[] array4 = new object[3]
			{
				"@trajeto",
				sTrajeto,
				OleDbType.Char
			};
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			sTrajeto = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance4 = db;
			object[] array5 = new object[3]
			{
				"@instrucao",
				sIsolacao,
				OleDbType.Char
			};
			array2 = array5;
			NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			sIsolacao = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance5 = db;
			object[] array6 = new object[3]
			{
				"@tag",
				sTag,
				OleDbType.Char
			};
			array2 = array6;
			NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			sTag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
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

	public void EditaComprimento(double dComprimento, int iPn1, int iPn2)
	{
		try
		{
			string text = "UPDATE Cabos SET Comprimento=@comprimento, Diametro=@comprimento WHERE Pn1=@pn1 and Pn2=@pn2";
			object instance = db;
			object[] array = new object[3]
			{
				"@comprimento",
				dComprimento,
				OleDbType.Double
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			dComprimento = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@pn1",
				iPn1,
				OleDbType.Integer
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iPn1 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance3 = db;
			object[] array4 = new object[3]
			{
				"@pn2",
				iPn2,
				OleDbType.Integer
			};
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iPn2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
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

	public void LeCabosVeiasTodos(ref structureVeiasCaderno[] VeiasCaderno, bool bFormacao = false)
	{
		checked
		{
			try
			{
				List<string> list = new List<string>();
				VeiasCaderno = new structureVeiasCaderno[1];
				JBgaA5p5W7h1TRpQ5uHE[] array = new JBgaA5p5W7h1TRpQ5uHE[1];
				string text = "SELECT Indice, Nome FROM DWG";
				object instance = db;
				object[] array2 = new object[1] { text };
				object[] array3 = array2;
				object obj = NewLateBinding.LateGet(instance, null, "ExecuteReader", array2, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						array = (JBgaA5p5W7h1TRpQ5uHE[])Utils.CopyArray(array, new JBgaA5p5W7h1TRpQ5uHE[i + 1]);
						array[i].NsTp5p3fWbb = Conversions.ToInteger(dataTable.Rows[i][0]);
						array[i].aqhp5TFBaCf = Conversions.ToString(dataTable.Rows[i][1]);
					}
				}
				text = "SELECT DISTINCT(Tag) FROM Veias ORDER BY Tag";
				obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array3 = new object[1] { text }, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
				DataTable dataTable2 = (DataTable)obj;
				list.Clear();
				if (dataTable2.Rows.Count > 0)
				{
					int num2 = dataTable2.Rows.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						list.Add(Conversions.ToString(dataTable2.Rows[j][0]));
					}
				}
				int num3 = list.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					string sFormacao = "";
					List<string> list2;
					int index;
					if (bFormacao)
					{
						text = "SELECT Formacao FROM cabos WHERE Tag=@tag";
						object instance2 = db;
						object[] array4 = new object[3]
						{
							"@tag",
							(list2 = list)[index = k],
							OleDbType.Char
						};
						array3 = array4;
						NewLateBinding.LateCall(instance2, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						list2[index] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[1]), typeof(string));
						object instance3 = db;
						object[] array5 = new object[1] { text };
						array3 = array5;
						obj = NewLateBinding.LateGet(instance3, null, "ExecuteReader", array5, null, null, new bool[1] { true });
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
						DataTable dataTable3 = (DataTable)obj;
						if (dataTable3.Rows.Count > 0)
						{
							int num4 = dataTable3.Rows.Count - 1;
							for (int l = 0; l <= num4; l++)
							{
								sFormacao = Conversions.ToString(dataTable3.Rows[l][0]);
							}
						}
					}
					text = "SELECT Tag, Indice, Nome_Veia, Handle, Pagina, Arquivo FROM veias WHERE Tag=@tag ORDER BY Indice";
					NewLateBinding.LateCall(db, null, "AddParameter", array3 = new object[3]
					{
						"@tag",
						(list2 = list)[index = k],
						OleDbType.Char
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					list2[index] = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[1]), typeof(string));
					obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array3 = new object[1] { text }, null, null, new bool[1] { true });
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
					DataTable dataTable4 = (DataTable)obj;
					if (dataTable4.Rows.Count <= 0)
					{
						continue;
					}
					int num5 = dataTable4.Rows.Count - 1;
					for (int m = 0; m <= num5; m++)
					{
						int num6 = Information.UBound(VeiasCaderno) + 1;
						VeiasCaderno = (structureVeiasCaderno[])Utils.CopyArray(VeiasCaderno, new structureVeiasCaderno[num6 + 1]);
						VeiasCaderno[num6].sTag = Conversions.ToString(dataTable4.Rows[m][0]);
						VeiasCaderno[num6].sFormacao = sFormacao;
						VeiasCaderno[num6].iIndice = Conversions.ToInteger(dataTable4.Rows[m][1]);
						VeiasCaderno[num6].sNomeVeia = dataTable4.Rows[m][2].ToString();
						VeiasCaderno[num6].sHandleCabo1 = dataTable4.Rows[m][3].ToString();
						VeiasCaderno[num6].iArquivo = DeclaracoesGeral.arqAtivo.Indice;
						VeiasCaderno[num6].sPagina = dataTable4.Rows[m][4].ToString();
						VeiasCaderno[num6].iPn1 = 0;
						VeiasCaderno[num6].sHandleTag1 = "";
						VeiasCaderno[num6].iPn2 = 0;
						VeiasCaderno[num6].sHandleCabo2 = "";
						VeiasCaderno[num6].sHandleTag2 = "";
						VeiasCaderno[num6].sPagina2 = "";
						VeiasCaderno[num6].iTipo = 1;
						VeiasCaderno[num6].X = 0.0;
						VeiasCaderno[num6].Y = 0.0;
						VeiasCaderno[num6].iDWG = Conversions.ToInteger(dataTable4.Rows[m][5].ToString());
						string value = "";
						int num7 = Information.UBound(array);
						for (int n = 0; n <= num7; n++)
						{
							if (array[n].NsTp5p3fWbb == VeiasCaderno[num6].iDWG)
							{
								value = array[n].aqhp5TFBaCf;
								break;
							}
						}
						value = clsTextos.TiraNothing(value);
						VeiasCaderno[num6].sCaderno = value;
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
			}
		}
	}

	public bool LeFormacaodoCaboFuncaoVeia(ref string sCabo, int iVeia, ref string sFormacao, ref string sFuncaoVeia)
	{
		bool result = false;
		checked
		{
			try
			{
				string text = "SELECT Formacao FROM cabos WHERE Tag=@tag";
				object instance = db;
				object[] array = new object[3]
				{
					"@tag",
					sCabo,
					OleDbType.Char
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				sCabo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance2 = db;
				object[] array3 = new object[1] { text };
				array2 = array3;
				object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					int index = 0;
					if (0 <= num)
					{
						sFormacao = Conversions.ToString(dataTable.Rows[index][0]);
					}
				}
				text = "SELECT Funcao FROM Veias WHERE Tag=@tag AND Indice=@indice";
				NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
				{
					"@tag",
					sCabo,
					OleDbType.Char
				}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				sCabo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
				{
					"@indice",
					iVeia,
					OleDbType.Integer
				}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				iVeia = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable2 = (DataTable)obj;
				if (dataTable2.Rows.Count > 0)
				{
					int num2 = dataTable2.Rows.Count - 1;
					int index2 = 0;
					if (0 <= num2)
					{
						sFuncaoVeia = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable2.Rows[index2][0]));
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
			}
			return result;
		}
	}

	public bool LeTodasasFormacoesdosCabosFuncoesDasVeias(ref clsUtilitarios.structureFormacao[] mFormacao, ref clsUtilitarios.structureFuncaoVeia[] mFuncao)
	{
		int num = 0;
		int num2 = 0;
		mFormacao = new clsUtilitarios.structureFormacao[1];
		mFuncao = new clsUtilitarios.structureFuncaoVeia[1];
		bool result = false;
		checked
		{
			try
			{
				string text = "SELECT Tag, Formacao FROM cabos";
				object instance = db;
				object[] array = new object[1] { text };
				object[] array2 = array;
				object obj = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count > 0)
				{
					int num3 = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num3; i++)
					{
						num++;
						mFormacao = (clsUtilitarios.structureFormacao[])Utils.CopyArray(mFormacao, new clsUtilitarios.structureFormacao[num + 1]);
						mFormacao[num].sCabo = Conversions.ToString(dataTable.Rows[i][0]);
						mFormacao[num].sFormacao = Conversions.ToString(dataTable.Rows[i][1]);
					}
				}
				text = "SELECT Tag, Indice, Nome_Veia, Funcao FROM Veias";
				obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable2 = (DataTable)obj;
				if (dataTable2.Rows.Count > 0)
				{
					int num4 = dataTable2.Rows.Count - 1;
					for (int j = 0; j <= num4; j++)
					{
						num2++;
						mFuncao = (clsUtilitarios.structureFuncaoVeia[])Utils.CopyArray(mFuncao, new clsUtilitarios.structureFuncaoVeia[num2 + 1]);
						mFuncao[num2].sCabo = Conversions.ToString(dataTable2.Rows[j][0]);
						mFuncao[num2].iVeia = Conversions.ToInteger(dataTable2.Rows[j][1]);
						mFuncao[num2].sNome = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable2.Rows[j][2]));
						mFuncao[num2].sFuncao = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable2.Rows[j][3]));
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
			}
			return result;
		}
	}

	public bool leNomeFuncaoDasVeias(ref clsVeias.StructureUmaVeia[] VeiasNomeFuncao)
	{
		bool result = false;
		checked
		{
			try
			{
				int num = 0;
				VeiasNomeFuncao = new clsVeias.StructureUmaVeia[1];
				string text = " SELECT Tag, indice, Nome_veia, Funcao FROM Veias";
				object instance = db;
				object[] array = new object[1] { text };
				object[] array2 = array;
				object obj = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count > 0)
				{
					result = true;
					int num2 = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num2; i++)
					{
						num++;
						VeiasNomeFuncao = (clsVeias.StructureUmaVeia[])Utils.CopyArray(VeiasNomeFuncao, new clsVeias.StructureUmaVeia[num + 1]);
						VeiasNomeFuncao[num].sTag = Conversions.ToString(dataTable.Rows[i][0]);
						VeiasNomeFuncao[num].iIndice = Conversions.ToInteger(dataTable.Rows[i][1]);
						VeiasNomeFuncao[num].sNome_Veia = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][2]));
						VeiasNomeFuncao[num].sFuncao = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][3]));
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
	}

	public void atualizaNomeFuncaoDasVeias(clsVeias.StructureUmaVeia[] VeiasNomeFuncao)
	{
		try
		{
			for (int i = 0; i < VeiasNomeFuncao.Length; i = checked(i + 1))
			{
				clsVeias.StructureUmaVeia structureUmaVeia = VeiasNomeFuncao[i];
				if (structureUmaVeia.iIndice != 0)
				{
					string text = "UPDATE Veias SET  Nome_veia=@veia, Funcao=@funcao WHERE Tag=@tag and Indice=@indice";
					NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
					{
						"@veia",
						clsTextos.TiraNothing(structureUmaVeia.sNome_Veia),
						OleDbType.Char
					}, null, null, null, IgnoreReturn: true);
					NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
					{
						"@funcao",
						clsTextos.TiraNothing(structureUmaVeia.sFuncao),
						OleDbType.Char
					}, null, null, null, IgnoreReturn: true);
					object instance = db;
					object[] array = new object[3] { "@tag", null, null };
					ref string sTag = ref structureUmaVeia.sTag;
					array[1] = sTag;
					array[2] = OleDbType.Char;
					object[] array2 = array;
					NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					sTag = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance2 = db;
					object[] array3 = new object[3] { "@indice", null, null };
					ref int iIndice = ref structureUmaVeia.iIndice;
					array3[1] = iIndice;
					array3[2] = OleDbType.Integer;
					array2 = array3;
					NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					iIndice = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					object instance3 = db;
					object[] array4 = new object[1] { text };
					array2 = array4;
					NewLateBinding.LateCall(instance3, null, "ExecuteNonQuery", array4, null, null, new bool[1] { true }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void BuscaCabo(ref DeclaracoesInterligacao.structureCabo[] MCabos)
	{
		checked
		{
			try
			{
				int num = 0;
				MCabos = new DeclaracoesInterligacao.structureCabo[1];
				string text = "SELECT Tag, Pn1, Pn2 FROM Cabos";
				object instance = db;
				object[] array = new object[1] { text };
				object[] array2 = array;
				object obj = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count > 0)
				{
					int num2 = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num2; i++)
					{
						num++;
						MCabos = (DeclaracoesInterligacao.structureCabo[])Utils.CopyArray(MCabos, new DeclaracoesInterligacao.structureCabo[num + 1]);
						MCabos[num].Tag = Conversions.ToString(dataTable.Rows[i][0]);
						MCabos[num].Pn1 = Conversions.ToInteger(dataTable.Rows[i][1]);
						MCabos[num].Pn2 = Conversions.ToInteger(dataTable.Rows[i][2]);
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
			}
		}
	}

	public void LimpaVeiasSemCaderno()
	{
		checked
		{
			try
			{
				List<int> list = new List<int>();
				string text = "SELECT Indice FROM DWG WHERE Tipo='F'";
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
						list.Add(Conversions.ToInteger(dataTable.Rows[i][0]));
					}
				}
				text = "SELECT Handle, Arquivo FROM Veias WHERE Arquivo > 0";
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
					if (!list.Contains(Conversions.ToInteger(dataTable.Rows[j][1].ToString())))
					{
						string text2 = "UPDATE Veias SET  Uso=@bUso, Handle='', Arquivo=0, Pagina='' WHERE Handle=@handle AND Arquivo=@arquivo";
						NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
						{
							"@bUso",
							false,
							OleDbType.Boolean
						}, null, null, null, IgnoreReturn: true);
						object instance2 = db;
						DataRow dataRow;
						object[] array3 = new object[3]
						{
							"@handle",
							(dataRow = dataTable.Rows[j])[0],
							OleDbType.Char
						};
						array2 = array3;
						NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[0] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance3 = db;
						object[] array4 = new object[3]
						{
							"@arquivo",
							(dataRow = dataTable.Rows[j])[1],
							OleDbType.Integer
						};
						array2 = array4;
						NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[1] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance4 = db;
						object[] array5 = new object[1] { text2 };
						array2 = array5;
						NewLateBinding.LateCall(instance4, null, "ExecuteNonQuery", array5, null, null, new bool[1] { true }, IgnoreReturn: true);
						text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
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
			}
		}
	}
}
