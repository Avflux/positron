using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class cDadosLM
{
	public struct StructureLM
	{
		public string sDescResumida;

		public string sDescCompleta;
	}

	public struct structureDispLM
	{
		public int Indice;

		public int iDWG;

		public int iPainel;

		public string sTag;

		public int iIndiceMaterial;

		public int iQuantidade;

		public int lOrdem;

		public bool bAvulso;

		public string sDestino;

		public string sDescDestino;

		public string sAlternativo;

		public string sHandle;

		public int IndiceLM;
	}

	public struct structureOrdemDispLM
	{
		public int Indice;

		public string sTag;

		public int iIndiceMaterial;

		public int lOrdem;

		public int OrdemLay;

		public int quantidade;
	}

	public struct structureLMRelelatorio
	{
		public string Tag;

		public string Index;

		public string Quantidade;

		public string Desc;

		public string DescResumida;

		public string DescCompleta;

		public string sModelo;

		public string sFabricante;

		public string CodCli;

		public string IndexLM;

		public string sOrdem;

		public string sD1;

		public string sD2;

		public string sD3;

		public string sD4;

		public string sD5;

		public string sD6;

		public string sD7;

		public string sD8;

		public string sD9;

		public string sD10;
	}

	public struct indexCODMateriais
	{
		public int indice;

		public int indexLM;
	}

	public object db;

	public void fechaConexao()
	{
		NewLateBinding.LateCall(db, null, "fechaConexao", new object[0], null, null, null, IgnoreReturn: true);
	}

	public cDadosLM()
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

	public DeclaracoesClonar.structureMaterial[] CarregaDadosLMMatriz()
	{
		DeclaracoesClonar.structureMaterial[] array = new DeclaracoesClonar.structureMaterial[1];
		array[0].CodigoInterno = 0;
		array[0].CodigoCliente = "";
		array[0].DescricaoResumida = "";
		array[0].DescricaoCompleta = "";
		array[0].Modelo = "";
		array[0].Fabricante = "";
		checked
		{
			try
			{
				string text = "SELECT CodigoInterno, CodigoCliente, DescricaoResumida, DescricaoCompleta, Modelo, Fabricante FROM Materiais ORDER BY CodigoInterno";
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
						array = (DeclaracoesClonar.structureMaterial[])Utils.CopyArray(array, new DeclaracoesClonar.structureMaterial[Information.UBound(array) + 1 + 1]);
						array[Information.UBound(array)].CodigoInterno = Conversions.ToInteger(dataTable.Rows[i][0]);
						array[Information.UBound(array)].CodigoCliente = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][1]));
						array[Information.UBound(array)].DescricaoResumida = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][2]));
						array[Information.UBound(array)].DescricaoCompleta = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][3]));
						array[Information.UBound(array)].Modelo = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][4]));
						array[Information.UBound(array)].Fabricante = clsTextos.TiraDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][5]));
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
			return array;
		}
	}

	public void CarregaDadosLMLista(ref ComboBox COMBO, List<int> lLM)
	{
		checked
		{
			try
			{
				string text = "";
				string text2 = "SELECT CodigoInterno, CodigoCliente, DescricaoResumida, DescricaoCompleta, Modelo, Fabricante  FROM Materiais ORDER BY CodigoInterno";
				object instance = db;
				object[] array = new object[1] { text2 };
				object[] array2 = array;
				object obj = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
				text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				COMBO.Items.Clear();
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				if (lLM.Contains(0))
				{
					text = Conversions.ToString(Operators.ConcatenateObject("0 - ", DeclaracoesGeral.mMensagem[1, 1701]));
					COMBO.Items.Add(text);
				}
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (lLM.Contains(Conversions.ToInteger(dataTable.Rows[i][0])))
					{
						text = (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(dataTable.Rows[i][2], null, "trim", new object[0], null, null, null), "", TextCompare: true) ? Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(dataTable.Rows[i][0], " - "), dataTable.Rows[i][2]), " - "), dataTable.Rows[i][4])) : Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(dataTable.Rows[i][0], " - "), dataTable.Rows[i][3]), " - "), dataTable.Rows[i][2])));
						COMBO.Items.Add(text);
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

	public string BuscaFabricanteDoMaterial(ref string index)
	{
		string result = "";
		if (Versioned.IsNumeric(index))
		{
			int num = Conversions.ToInteger(index);
			try
			{
				string text = "SELECT Fabricante  FROM Materiais where CodigoInterno=@codigointerno";
				object instance = db;
				object[] array = new object[3]
				{
					"@codigointerno",
					num,
					OleDbType.Integer
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				num = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance2 = db;
				object[] array3 = new object[1] { text };
				array2 = array3;
				object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count > 0)
				{
					result = Conversions.ToString(dataTable.Rows[0][0]);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
		return result;
	}

	public void buscaListaDeFabricanteDoMaterial(ref clsLM.LModFab[] mModFab)
	{
		checked
		{
			try
			{
				string text = "SELECT CodigoInterno, Modelo, Fabricante FROM Materiais";
				object instance = db;
				object[] array = new object[1] { text };
				object[] array2 = array;
				object obj = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				int num = 0;
				mModFab = new clsLM.LModFab[1];
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num2 = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					if (Information.IsNothing(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][1])))
					{
						dataTable.Rows[i][1] = "";
					}
					if (Information.IsNothing(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][2])))
					{
						dataTable.Rows[i][2] = "";
					}
					num++;
					mModFab = (clsLM.LModFab[])Utils.CopyArray(mModFab, new clsLM.LModFab[num + 1]);
					mModFab[num].indice = Conversions.ToInteger(dataTable.Rows[i][0]);
					mModFab[num].Modelo = Conversions.ToString(dataTable.Rows[i][1]);
					mModFab[num].Fabricante = Conversions.ToString(dataTable.Rows[i][2]);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void ComplementaModelo(Declaracoes2.MModeloDeMascara[] mModelo)
	{
		checked
		{
			try
			{
				string text = "SELECT CodigoInterno, CodigoCliente, DescricaoResumida, DescricaoCompleta, Modelo, Fabricante FROM Materiais ORDER BY CodigoInterno";
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
					int num2 = Information.UBound(mModelo);
					for (int j = 1; j <= num2; j++)
					{
						if ((int)mModelo[j].iLM1 == Conversions.ToInteger(dataTable.Rows[i][0]))
						{
							mModelo[j].sFabricante = Conversions.ToString(dataTable.Rows[i][5]);
							mModelo[j].sDescricao = Conversions.ToString(dataTable.Rows[i][2]);
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

	public void CarregaDadosPaineisLM(ref int[] Paineis)
	{
		checked
		{
			try
			{
				string text = "SELECT distinct Painel FROM ListaMateriais WHERE IndiceMaterial<>0  ORDER BY Painel";
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
						Paineis = (int[])Utils.CopyArray(Paineis, new int[Information.UBound(Paineis) + 1 + 1]);
						Paineis[Information.UBound(Paineis)] = Conversions.ToInteger(dataTable.Rows[i][0]);
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

	public void CarregaDadosDispositivos(ref structureDispLM[] sDisp, int iDWG, int iPN)
	{
		checked
		{
			try
			{
				string text = "SELECT Indice, DWG, Painel, Tag, IndiceMaterial, Quantidade, Ordem, Avulso, Destino, DescDestino, Alternativo, Handle, IndiceLM FROM ListaMateriais WHERE DWG=@dwg and Painel=@painel ORDER BY Ordem";
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
				object[] array3 = new object[3]
				{
					"@painel",
					iPN,
					OleDbType.Integer
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				iPN = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance3 = db;
				object[] array4 = new object[1] { text };
				array2 = array4;
				object obj = NewLateBinding.LateGet(instance3, null, "ExecuteReader", array4, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				sDisp = new structureDispLM[1];
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					string sHandle = "";
					if (!Information.IsDBNull(dataTable.Rows[i][11].ToString()))
					{
						sHandle = dataTable.Rows[i][11].ToString();
					}
					int num2 = Information.UBound(sDisp) + 1;
					sDisp = (structureDispLM[])Utils.CopyArray(sDisp, new structureDispLM[num2 + 1]);
					sDisp[num2].Indice = Conversions.ToInteger(dataTable.Rows[i][0]);
					sDisp[num2].iDWG = Conversions.ToInteger(dataTable.Rows[i][1]);
					sDisp[num2].iPainel = Conversions.ToInteger(dataTable.Rows[i][2]);
					sDisp[num2].sTag = Conversions.ToString(dataTable.Rows[i][3]);
					sDisp[num2].iIndiceMaterial = Conversions.ToInteger(dataTable.Rows[i][4]);
					sDisp[num2].iQuantidade = Conversions.ToInteger(dataTable.Rows[i][5]);
					sDisp[num2].lOrdem = Conversions.ToInteger(dataTable.Rows[i][6]);
					sDisp[num2].bAvulso = Conversions.ToBoolean(dataTable.Rows[i][7]);
					sDisp[num2].sDestino = "";
					sDisp[num2].sDescDestino = "";
					sDisp[num2].sAlternativo = "";
					if (!Information.IsDBNull(dataTable.Rows[i][10].ToString()))
					{
						sDisp[num2].sAlternativo = dataTable.Rows[i][10].ToString();
					}
					sDisp[num2].sHandle = sHandle;
					if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][12])))
					{
						sDisp[num2].IndiceLM = 0;
					}
					else
					{
						sDisp[num2].IndiceLM = Conversions.ToInteger(dataTable.Rows[i][12]);
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

	public void CarregaDadosOrdemDispositivos(ref structureOrdemDispLM[] sDisp, int iDWG, int iPN)
	{
		checked
		{
			try
			{
				string text = "SELECT indice, Tag, IndiceMaterial, Ordem, Quantidade, OrdemLay FROM ListaMateriais WHERE Painel=@painel and IndiceMaterial <> 0 ORDER BY Ordem";
				object instance = db;
				object[] array = new object[3]
				{
					"@painel",
					iPN,
					OleDbType.Integer
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				iPN = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance2 = db;
				object[] array3 = new object[1] { text };
				array2 = array3;
				object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				sDisp = new structureOrdemDispLM[1];
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					int num2 = Information.UBound(sDisp) + 1;
					sDisp = (structureOrdemDispLM[])Utils.CopyArray(sDisp, new structureOrdemDispLM[num2 + 1]);
					sDisp[num2].Indice = Conversions.ToInteger(dataTable.Rows[i][0]);
					sDisp[num2].sTag = Conversions.ToString(dataTable.Rows[i][1]);
					sDisp[num2].iIndiceMaterial = Conversions.ToInteger(dataTable.Rows[i][2]);
					sDisp[num2].lOrdem = Conversions.ToInteger(dataTable.Rows[i][3]);
					sDisp[num2].quantidade = Conversions.ToInteger(dataTable.Rows[i][4]);
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][5])))
					{
						sDisp[num2].OrdemLay = Conversions.ToInteger(dataTable.Rows[i][5]);
					}
					else
					{
						sDisp[num2].OrdemLay = 0;
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

	public void AtualizaDadosOrdemDispositivos(int indice, int ordem)
	{
		try
		{
			string text = "";
			text = "UPDATE ListaMateriais SET Ordem=@ordem where Indice=@indice";
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

	public void CarregaDadosDispositivosMultiplosPN(ref DataGridView dg, ref string[,] mLM, ref indexCODMateriais[] mCod, int iMultiplicador)
	{
		checked
		{
			try
			{
				int num = 7;
				int num2 = dg.Rows.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					if (dg.Rows[i].Selected)
					{
						num++;
					}
				}
				string text = "";
				int num3 = 7;
				int num4 = 0;
				mLM = new string[num + 1, 1];
				mCod = new indexCODMateriais[1];
				mLM = new string[num + 1, 1];
				int num5 = num;
				for (int j = 0; j <= num5; j++)
				{
					mLM[j, 0] = "";
				}
				int num6 = 0;
				int num7 = 0;
				num7 = 1;
				int num8 = dg.Rows.Count - 1;
				for (int k = 0; k <= num8; k++)
				{
					if (!dg.Rows[k].Selected)
					{
						continue;
					}
					string text2 = "";
					string text3 = "";
					text = Conversions.ToString(dg.Rows[k].Cells[1].Value);
					text2 = "SELECT ListaMateriais.Indice, ListaMateriais.Tag, ListaMateriais.IndiceMaterial, ListaMateriais.Quantidade, Materiais.DescricaoCompleta, Materiais.Modelo, Materiais.Fabricante, Materiais.CodigoCliente FROM ListaMateriais INNER JOIN Materiais ON ListaMateriais.IndiceMaterial=Materiais.CodigoInterno WHERE ListaMateriais.IndiceMaterial<>0 and (";
					text3 = Conversions.ToString(Operators.ConcatenateObject("ListaMateriais.Painel=", dg.Rows[k].Cells[0].Value));
					text3 += ") ORDER BY ListaMateriais.IndiceMaterial, ListaMateriais.Ordem, ListaMateriais.tag";
					text2 += text3;
					object instance = db;
					object[] array = new object[1] { text2 };
					object[] array2 = array;
					object obj = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
					text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DataTable dataTable = (DataTable)obj;
					if (dataTable.Rows.Count > 0)
					{
						int num9 = dataTable.Rows.Count - 1;
						for (int l = 0; l <= num9; l++)
						{
							bool flag = true;
							int num10 = Information.UBound(mLM, 2);
							for (int m = 1; m <= num10; m++)
							{
								if (Operators.CompareString(mLM[6, m], Conversions.ToString(dataTable.Rows[l][2]), TextCompare: true) == 0)
								{
									ref string reference = ref mLM[1, m];
									reference = Conversions.ToString(Operators.AddObject(reference, Operators.ConcatenateObject(", ", dataTable.Rows[l][1])));
									int num11 = 0;
									if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dataTable.Rows[l][3])))
									{
										num11 = Conversions.ToInteger(dataTable.Rows[l][3]);
									}
									int num12 = num11 * iMultiplicador;
									if (!Versioned.IsNumeric(mLM[num3, m]))
									{
										mLM[num3, m] = "0";
									}
									mLM[num3, m] = Conversions.ToString(Conversions.ToInteger(mLM[num3, m]) + num12);
									mLM[num, m] = Conversions.ToString(Conversions.ToInteger(mLM[num, m]) + num12);
									mLM[num3, 0] = text;
									num6 = Information.UBound(mCod) + 1;
									mCod = (indexCODMateriais[])Utils.CopyArray(mCod, new indexCODMateriais[num6 + 1]);
									mCod[num6].indice = Conversions.ToInteger(dataTable.Rows[l][0]);
									mCod[num6].indexLM = Conversions.ToInteger(mLM[0, m]);
									flag = false;
									break;
								}
							}
							if (flag)
							{
								num4 = Information.UBound(mLM, 2) + 1;
								mLM = (string[,])Utils.CopyArray(mLM, new string[num + 1, num4 + 1]);
								int num13 = num;
								for (int n = 0; n <= num13; n++)
								{
									mLM[n, num4] = "";
								}
								mLM[num, num4] = "0";
								mLM[num3, num4] = "0";
								mLM[0, num4] = Conversions.ToString(num7);
								mLM[1, num4] = dataTable.Rows[l][1].ToString();
								mLM[2, num4] = dataTable.Rows[l][4].ToString();
								mLM[3, num4] = dataTable.Rows[l][5].ToString();
								mLM[4, num4] = dataTable.Rows[l][6].ToString();
								mLM[5, num4] = dataTable.Rows[l][7].ToString();
								mLM[6, num4] = Conversions.ToString(dataTable.Rows[l][2]);
								mLM[num3, 0] = text;
								int num14 = 0;
								if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dataTable.Rows[l][3])))
								{
									num14 = Conversions.ToInteger(dataTable.Rows[l][3]);
								}
								int num15 = num14 * iMultiplicador;
								mLM[num3, num4] = Conversions.ToString(num15);
								mLM[num, num4] = Conversions.ToString(num15);
								num6 = Information.UBound(mCod) + 1;
								mCod = (indexCODMateriais[])Utils.CopyArray(mCod, new indexCODMateriais[num6 + 1]);
								mCod[num6].indice = Conversions.ToInteger(dataTable.Rows[l][0]);
								mCod[num6].indexLM = num7;
								num7++;
							}
						}
					}
					num3++;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void AtualizaLMBaseadoNosDWGsCadastrados()
	{
		checked
		{
			try
			{
				DataTable dataTable = null;
				List<int> list = new List<int>();
				List<int> list2 = new List<int>();
				list.Clear();
				list2.Clear();
				string text = "SELECT indice from dwg";
				object instance = db;
				object[] array = new object[1] { text };
				object[] array2 = array;
				object obj = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				dataTable = (DataTable)obj;
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						list.Add(Conversions.ToInteger(dataTable.Rows[i][0]));
					}
				}
				text = "SELECT DISTINCT(DWG) from ListaMateriais";
				obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array2 = new object[1] { text }, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				dataTable = (DataTable)obj;
				if (dataTable.Rows.Count > 0)
				{
					int num2 = dataTable.Rows.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						if (!list.Contains(Conversions.ToInteger(dataTable.Rows[j][0])))
						{
							list2.Add(Conversions.ToInteger(dataTable.Rows[j][0]));
						}
					}
				}
				int num3 = list2.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					RemoveDWG(list2[k]);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void RemoveDWG(int indiceDWG)
	{
		try
		{
			string text = "";
			text = "DELETE FROM ListaMateriais WHERE DWG=@dwg ";
			object instance = db;
			object[] array = new object[3]
			{
				"@dwg",
				indiceDWG,
				OleDbType.Integer
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			indiceDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
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
}
