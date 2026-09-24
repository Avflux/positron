using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class cDadosAccessImportarProj
{
	public object db;

	public void fechaConexao()
	{
		NewLateBinding.LateCall(db, null, "fechaConexao", new object[0], null, null, null, IgnoreReturn: true);
	}

	public cDadosAccessImportarProj()
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

	public void CarregaCabosImpProj(ref clsImportarProjetos.mCabos[] mCabos, bool bUso)
	{
		List<string> list = new List<string>();
		int num = 0;
		mCabos = new clsImportarProjetos.mCabos[1];
		checked
		{
			try
			{
				string text = "";
				text = (bUso ? "SELECT Tag, Arquivo FROM Veias WHERE Arquivo > 0 ORDER BY Tag, Arquivo" : "SELECT Tag, Arquivo FROM Veias ORDER BY Tag, Arquivo ASC");
				object[] array;
				object obj = NewLateBinding.LateGet(db, null, "ExecuteReader", array = new object[1] { text }, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num2 = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					if (!list.Contains(Conversions.ToString(dataTable.Rows[i][0])))
					{
						num++;
						mCabos = (clsImportarProjetos.mCabos[])Utils.CopyArray(mCabos, new clsImportarProjetos.mCabos[num + 1]);
						mCabos[num].sNomeCabo = Conversions.ToString(dataTable.Rows[i][0]);
						mCabos[num].iDWG = Conversions.ToInteger(dataTable.Rows[i][1]);
						list.Add(Conversions.ToString(dataTable.Rows[i][0]));
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

	public void CarregaEquipImpProj(ref clsImportarProjetos.mEquip[] mPN)
	{
		List<int> list = new List<int>();
		int num = 0;
		mPN = new clsImportarProjetos.mEquip[1];
		checked
		{
			try
			{
				string text = "SELECT Indice, Nome FROM Paineis ORDER BY Indice";
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
					if (!list.Contains(Conversions.ToInteger(dataTable.Rows[i][0])))
					{
						num++;
						mPN = (clsImportarProjetos.mEquip[])Utils.CopyArray(mPN, new clsImportarProjetos.mEquip[num + 1]);
						mPN[num].iPainel = Conversions.ToInteger(dataTable.Rows[i][0]);
						mPN[num].sPainel = Conversions.ToString(dataTable.Rows[i][1]);
						list.Add(Conversions.ToInteger(dataTable.Rows[i][0]));
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

	public void CarregaDWGImpProj(ref clsImportarProjetos.mDWG[] mDWG)
	{
		List<int> list = new List<int>();
		int num = 0;
		mDWG = new clsImportarProjetos.mDWG[1];
		checked
		{
			try
			{
				string text = "SELECT Indice, Nome, Caminho FROM DWG WHERE Tipo = 'F' ORDER BY Indice";
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
					if (!list.Contains(Conversions.ToInteger(dataTable.Rows[i][0])))
					{
						num++;
						mDWG = (clsImportarProjetos.mDWG[])Utils.CopyArray(mDWG, new clsImportarProjetos.mDWG[num + 1]);
						mDWG[num].iDWG = Conversions.ToInteger(dataTable.Rows[i][0]);
						mDWG[num].sNome = Conversions.ToString(dataTable.Rows[i][1]);
						mDWG[num].sCaminho = Conversions.ToString(dataTable.Rows[i][2]);
						list.Add(Conversions.ToInteger(dataTable.Rows[i][0]));
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

	public int BuscaProximoIndiceDWG()
	{
		int num = 1;
		checked
		{
			try
			{
				string text = "DELETE FROM DWGH";
				object instance = db;
				object[] array = new object[1] { text };
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "ExecuteNonQuery", array, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "SELECT Indice FROM DWG";
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
						if (Operators.ConditionalCompareObjectLessEqual(num, dataTable.Rows[i][0], TextCompare: true))
						{
							num = Conversions.ToInteger(Operators.AddObject(dataTable.Rows[i][0], 1));
						}
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			return num;
		}
	}

	public void CarregaCabosCompletosImpProj(List<int> lIndicePaineisCabos, List<int> lIndiceDWGCabos, ref clsImportarProjetos.mTrocaCabos[] iNomeCabosTroca, ref List<string> lListaCabosOriginal, List<string> lCabos, ref clsImportarProjetos.mTodosCabos[] mTodosCabos, ref clsImportarProjetos.mTodasVeias[] mTodasVeias)
	{
		checked
		{
			try
			{
				int num = 0;
				mTodosCabos = new clsImportarProjetos.mTodosCabos[1];
				int num2 = 0;
				mTodasVeias = new clsImportarProjetos.mTodasVeias[1];
				List<string> list = new List<string>();
				try
				{
					string text = "SELECT Tag FROM Veias WHERE Arquivo > 0 ORDER BY Tag";
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
							if (!list.Contains(Conversions.ToString(dataTable.Rows[i][0])))
							{
								list.Add(Conversions.ToString(dataTable.Rows[i][0]));
							}
						}
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				try
				{
					string text2 = "SELECT Tag, Pn1, Pn2 FROM Cabos ORDER BY Tag";
					object instance2 = db;
					object[] array3 = new object[1] { text2 };
					object[] array2 = array3;
					object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
					text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DataTable dataTable2 = (DataTable)obj;
					if (dataTable2.Rows.Count > 0)
					{
						int num4 = dataTable2.Rows.Count - 1;
						for (int j = 0; j <= num4; j++)
						{
							if (list.Contains(Conversions.ToString(dataTable2.Rows[j][0])) && (lIndicePaineisCabos.Contains(Conversions.ToInteger(dataTable2.Rows[j][1])) & lIndicePaineisCabos.Contains(Conversions.ToInteger(dataTable2.Rows[j][2]))))
							{
								lCabos.Add(Conversions.ToString(dataTable2.Rows[j][0]));
							}
						}
					}
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
				try
				{
					string text3 = "SELECT Tag, Formacao, Blindagem, Pn1, Pn2, Codigo, Funcao, Alarme, Aterrar, Comprimento, Trajeto, Instrucao, Diametro, Grupo, Cabos FROM Cabos ORDER BY Tag ";
					object instance3 = db;
					object[] array4 = new object[1] { text3 };
					object[] array2 = array4;
					object obj = NewLateBinding.LateGet(instance3, null, "ExecuteReader", array4, null, null, new bool[1] { true });
					text3 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DataTable dataTable3 = (DataTable)obj;
					if (dataTable3.Rows.Count > 0 && dataTable3.Rows.Count > 0)
					{
						int num5 = dataTable3.Rows.Count - 1;
						for (int k = 0; k <= num5; k++)
						{
							if (lCabos.Contains(Conversions.ToString(dataTable3.Rows[k][0])))
							{
								num++;
								mTodosCabos = (clsImportarProjetos.mTodosCabos[])Utils.CopyArray(mTodosCabos, new clsImportarProjetos.mTodosCabos[num + 1]);
								int num6 = Information.UBound(iNomeCabosTroca) + 1;
								iNomeCabosTroca = (clsImportarProjetos.mTrocaCabos[])Utils.CopyArray(iNomeCabosTroca, new clsImportarProjetos.mTrocaCabos[num6 + 1]);
								iNomeCabosTroca[num6].sCabo = Conversions.ToString(dataTable3.Rows[k][0]);
								iNomeCabosTroca[num6].sCaboNovo = Conversions.ToString(dataTable3.Rows[k][0]);
								while (lListaCabosOriginal.Contains(iNomeCabosTroca[num6].sCaboNovo))
								{
									iNomeCabosTroca[num6].sCaboNovo = iNomeCabosTroca[num6].sCaboNovo + "_1";
								}
								lListaCabosOriginal.Add(iNomeCabosTroca[num6].sCaboNovo);
								mTodosCabos[num].Tag = iNomeCabosTroca[num6].sCaboNovo;
								mTodosCabos[num].Formacao = Conversions.ToString(dataTable3.Rows[k][1]);
								mTodosCabos[num].blindagem = Conversions.ToBoolean(dataTable3.Rows[k][2]);
								mTodosCabos[num].Pn1 = Conversions.ToInteger(dataTable3.Rows[k][3]);
								mTodosCabos[num].Pn2 = Conversions.ToInteger(dataTable3.Rows[k][4]);
								mTodosCabos[num].Codigo = Conversions.ToString(dataTable3.Rows[k][5]);
								mTodosCabos[num].Funcao = "";
								if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable3.Rows[k][6])))
								{
									mTodosCabos[num].Funcao = Conversions.ToString(dataTable3.Rows[k][6]);
								}
								mTodosCabos[num].Alarme = Conversions.ToInteger(dataTable3.Rows[k][7]);
								mTodosCabos[num].Aterrar = Conversions.ToInteger(dataTable3.Rows[k][8]);
								mTodosCabos[num].Comprimento = Conversions.ToDouble(dataTable3.Rows[k][9]);
								mTodosCabos[num].Trajeto = Conversions.ToString(dataTable3.Rows[k][10]);
								mTodosCabos[num].Instrucao = Conversions.ToString(dataTable3.Rows[k][11]);
								mTodosCabos[num].Diametro = Conversions.ToDouble(dataTable3.Rows[k][12]);
								mTodosCabos[num].Grupo = Conversions.ToString(dataTable3.Rows[k][13]);
								mTodosCabos[num].Cabos = Conversions.ToInteger(dataTable3.Rows[k][14]);
							}
						}
					}
				}
				catch (Exception projectError3)
				{
					ProjectData.SetProjectError(projectError3);
					ProjectData.ClearProjectError();
				}
				try
				{
					string text4 = "SELECT Tag, Indice, Nome_Veia, Uso, Handle, Arquivo, Pagina, Chave FROM Veias  ORDER BY Tag, Indice";
					object instance4 = db;
					object[] array5 = new object[1] { text4 };
					object[] array2 = array5;
					object obj = NewLateBinding.LateGet(instance4, null, "ExecuteReader", array5, null, null, new bool[1] { true });
					text4 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DataTable dataTable4 = (DataTable)obj;
					if (dataTable4.Rows.Count <= 0)
					{
						return;
					}
					int num7 = dataTable4.Rows.Count - 1;
					for (int l = 0; l <= num7; l++)
					{
						if (lCabos.Contains(Conversions.ToString(dataTable4.Rows[l][0])))
						{
							num2++;
							mTodasVeias = (clsImportarProjetos.mTodasVeias[])Utils.CopyArray(mTodasVeias, new clsImportarProjetos.mTodasVeias[num2 + 1]);
							mTodasVeias[num2].Tag = clsImportarProjetos.BuscaNomeDoCabo(ref iNomeCabosTroca, Conversions.ToString(dataTable4.Rows[l][0]));
							mTodasVeias[num2].indice = Conversions.ToInteger(dataTable4.Rows[l][1]);
							mTodasVeias[num2].Nome_Veias = Conversions.ToString(dataTable4.Rows[l][2]);
							mTodasVeias[num2].Uso = Conversions.ToBoolean(dataTable4.Rows[l][3]);
							mTodasVeias[num2].Handle = Conversions.ToString(dataTable4.Rows[l][4]);
							mTodasVeias[num2].Arquivo = Conversions.ToInteger(dataTable4.Rows[l][5]);
							mTodasVeias[num2].Pagina = Conversions.ToString(dataTable4.Rows[l][6]);
							mTodasVeias[num2].Chave = Conversions.ToInteger(dataTable4.Rows[l][7]);
						}
					}
				}
				catch (Exception projectError4)
				{
					ProjectData.SetProjectError(projectError4);
					ProjectData.ClearProjectError();
				}
			}
			catch (Exception projectError5)
			{
				ProjectData.SetProjectError(projectError5);
				throw;
			}
		}
	}

	public void CadastraNovosDWGS(clsImportarProjetos.mDWG[] mIndiceNovosDWGs)
	{
		try
		{
			string text = Environment.UserName;
			string text2 = "";
			DateTime dateTime = Conversions.ToDate(DateTime.Now.ToString());
			int num = Information.UBound(mIndiceNovosDWGs);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				string text3 = "Insert into DWG(Indice, Tipo, Caminho, Nome, Criador, Editor, Data) VALUES(@indice, 'F', @caminho, @nome, @criador, @editor, @data)";
				object instance = db;
				object[] array = new object[3] { "@indice", null, null };
				ref int iDWG = ref mIndiceNovosDWGs[i].iDWG;
				array[1] = iDWG;
				array[2] = OleDbType.Integer;
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance2 = db;
				object[] array3 = new object[3] { "@caminho", null, null };
				ref string sCaminho = ref mIndiceNovosDWGs[i].sCaminho;
				ref string reference = ref sCaminho;
				array3[1] = sCaminho;
				array3[2] = OleDbType.Char;
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance3 = db;
				object[] array4 = new object[3] { "@nome", null, null };
				ref string sNome = ref mIndiceNovosDWGs[i].sNome;
				reference = ref sNome;
				array4[1] = sNome;
				array4[2] = OleDbType.Char;
				array2 = array4;
				NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
				{
					"@criador",
					text,
					OleDbType.Char
				}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
				{
					"@editor",
					text2,
					OleDbType.Char
				}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
				{
					"@data",
					dateTime,
					OleDbType.Date
				}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				dateTime = (DateTime)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(DateTime));
				NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text3 }, null, null, new bool[1] { true }, IgnoreReturn: true);
				text3 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void AdicionaNovosCabos(ref clsImportarProjetos.mTodosCabos[] mCabos)
	{
		DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mCabos);
		DeclaracoesGeral._uscPagina.pbIniciar();
		try
		{
			int num = Information.UBound(mCabos);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				string text = "";
				text = "Insert into Cabos(Tag, Formacao, Blindagem, Pn1, Pn2, Codigo, Funcao, Aterrar, Comprimento, Trajeto, Instrucao, Diametro, Grupo, Cabos) VALUES(@tag, @formacao, @blindagem, @pn1, @pn2, @codigo, @funcao, @aterrar, @comprimento, @trajeto, @instrucao, @diametro, @grupo, @cabos)";
				object instance = db;
				object[] array = new object[3] { "@tag", null, null };
				ref string tag = ref mCabos[i].Tag;
				ref string reference = ref tag;
				array[1] = tag;
				array[2] = OleDbType.Char;
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance2 = db;
				object[] array3 = new object[3] { "@formacao", null, null };
				ref string formacao = ref mCabos[i].Formacao;
				reference = ref formacao;
				array3[1] = formacao;
				array3[2] = OleDbType.Char;
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance3 = db;
				object[] array4 = new object[3] { "@blindagem", null, null };
				ref bool blindagem = ref mCabos[i].blindagem;
				array4[1] = blindagem;
				array4[2] = OleDbType.Boolean;
				array2 = array4;
				NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				blindagem = (bool)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(bool));
				object instance4 = db;
				object[] array5 = new object[3] { "@pn1", null, null };
				ref int pn = ref mCabos[i].Pn1;
				ref int reference2 = ref pn;
				array5[1] = pn;
				array5[2] = OleDbType.Integer;
				array2 = array5;
				NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance5 = db;
				object[] array6 = new object[3] { "@pn2", null, null };
				ref int pn2 = ref mCabos[i].Pn2;
				reference2 = ref pn2;
				array6[1] = pn2;
				array6[2] = OleDbType.Integer;
				array2 = array6;
				NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance6 = db;
				object[] array7 = new object[3] { "@codigo", null, null };
				ref string codigo = ref mCabos[i].Codigo;
				reference = ref codigo;
				array7[1] = codigo;
				array7[2] = OleDbType.Char;
				array2 = array7;
				NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance7 = db;
				object[] array8 = new object[3] { "@funcao", null, null };
				ref string funcao = ref mCabos[i].Funcao;
				reference = ref funcao;
				array8[1] = funcao;
				array8[2] = OleDbType.Char;
				array2 = array8;
				NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance8 = db;
				object[] array9 = new object[3] { "@aterrar", null, null };
				ref int aterrar = ref mCabos[i].Aterrar;
				reference2 = ref aterrar;
				array9[1] = aterrar;
				array9[2] = OleDbType.Integer;
				array2 = array9;
				NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance9 = db;
				object[] array10 = new object[3] { "@comprimento", null, null };
				ref double comprimento = ref mCabos[i].Comprimento;
				ref double reference3 = ref comprimento;
				array10[1] = comprimento;
				array10[2] = OleDbType.Double;
				array2 = array10;
				NewLateBinding.LateCall(instance9, null, "AddParameter", array10, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference3 = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
				object instance10 = db;
				object[] array11 = new object[3] { "@trajeto", null, null };
				ref string trajeto = ref mCabos[i].Trajeto;
				reference = ref trajeto;
				array11[1] = trajeto;
				array11[2] = OleDbType.Char;
				array2 = array11;
				NewLateBinding.LateCall(instance10, null, "AddParameter", array11, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance11 = db;
				object[] array12 = new object[3] { "@instrucao", null, null };
				ref string instrucao = ref mCabos[i].Instrucao;
				reference = ref instrucao;
				array12[1] = instrucao;
				array12[2] = OleDbType.Char;
				array2 = array12;
				NewLateBinding.LateCall(instance11, null, "AddParameter", array12, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance12 = db;
				object[] array13 = new object[3] { "@diametro", null, null };
				ref double diametro = ref mCabos[i].Diametro;
				reference3 = ref diametro;
				array13[1] = diametro;
				array13[2] = OleDbType.Double;
				array2 = array13;
				NewLateBinding.LateCall(instance12, null, "AddParameter", array13, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference3 = (double)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(double));
				object instance13 = db;
				object[] array14 = new object[3] { "@grupo", null, null };
				ref string grupo = ref mCabos[i].Grupo;
				reference = ref grupo;
				array14[1] = grupo;
				array14[2] = OleDbType.Char;
				array2 = array14;
				NewLateBinding.LateCall(instance13, null, "AddParameter", array14, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance14 = db;
				object[] array15 = new object[3] { "@cabos", null, null };
				ref int cabos = ref mCabos[i].Cabos;
				reference2 = ref cabos;
				array15[1] = cabos;
				array15[2] = OleDbType.Integer;
				array2 = array15;
				NewLateBinding.LateCall(instance14, null, "AddParameter", array15, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DeclaracoesGeral._uscPagina.pbPasso();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
		DeclaracoesGeral._uscPagina.pbFim();
	}

	public void AdicionaNovasVeias(ref clsImportarProjetos.mTodasVeias[] mVeias)
	{
		DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mVeias);
		DeclaracoesGeral._uscPagina.pbIniciar();
		try
		{
			int num = Information.UBound(mVeias);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				string text = "";
				text = "Insert into Veias(Tag, Indice, Nome_Veia, Uso, Handle, Arquivo, Pagina) VALUES(@tag, @Indice, @Nome_Veia, @uso, @handle, @arquivo, @pagina)";
				object instance = db;
				object[] array = new object[3] { "@tag", null, null };
				ref string tag = ref mVeias[i].Tag;
				ref string reference = ref tag;
				array[1] = tag;
				array[2] = OleDbType.Char;
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance2 = db;
				object[] array3 = new object[3] { "@Indice", null, null };
				ref int indice = ref mVeias[i].indice;
				ref int reference2 = ref indice;
				array3[1] = indice;
				array3[2] = OleDbType.Integer;
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance3 = db;
				object[] array4 = new object[3] { "@Nome_Veia", null, null };
				ref string nome_Veias = ref mVeias[i].Nome_Veias;
				reference = ref nome_Veias;
				array4[1] = nome_Veias;
				array4[2] = OleDbType.Char;
				array2 = array4;
				NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance4 = db;
				object[] array5 = new object[3] { "@uso", null, null };
				ref bool uso = ref mVeias[i].Uso;
				array5[1] = uso;
				array5[2] = OleDbType.Boolean;
				array2 = array5;
				NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				uso = (bool)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(bool));
				object instance5 = db;
				object[] array6 = new object[3] { "@handle", null, null };
				ref string handle = ref mVeias[i].Handle;
				reference = ref handle;
				array6[1] = handle;
				array6[2] = OleDbType.Char;
				array2 = array6;
				NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				object instance6 = db;
				object[] array7 = new object[3] { "@arquivo", null, null };
				ref int arquivo = ref mVeias[i].Arquivo;
				reference2 = ref arquivo;
				array7[1] = arquivo;
				array7[2] = OleDbType.Integer;
				array2 = array7;
				NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference2 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance7 = db;
				object[] array8 = new object[3] { "@pagina", null, null };
				ref string pagina = ref mVeias[i].Pagina;
				reference = ref pagina;
				array8[1] = pagina;
				array8[2] = OleDbType.Char;
				array2 = array8;
				NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
				NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DeclaracoesGeral._uscPagina.pbPasso();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
		DeclaracoesGeral._uscPagina.pbFim();
	}

	public void AdicionaNovosImportados(ref clsImportarProjetos.mExpo[] mNOVO_ExportadosImportada, ref clsImportarProjetos.mAtt[] mNOVO_AtributosImportada)
	{
		checked
		{
			DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mNOVO_ExportadosImportada) + Information.UBound(mNOVO_AtributosImportada);
			DeclaracoesGeral._uscPagina.pbIniciar();
			try
			{
				string text = "";
				int num = Information.UBound(mNOVO_ExportadosImportada);
				for (int i = 1; i <= num; i++)
				{
					text = "insert into Exportados (Codigo, Tipo, DWG, Caderno, Handle, Pagina, Posicao, Painel, Texto, DWGDest, CadernoDest, PaginaDest, PosicaoDest, NomeRegua, indexModelo, Atualizado) VALUES(@codigo, @tipo, @dwg, @caderno, @handle, @pagina, @posicao, @painel, @textos, @DWGDest, @CadernoDest, @PaginaDest, @PosicaoDest, @NomeRegua, @indexModelo, @Atualizado)";
					object instance = db;
					object[] array = new object[3] { "@codigo", null, null };
					ref int codigo = ref mNOVO_ExportadosImportada[i].Codigo;
					ref int reference = ref codigo;
					array[1] = codigo;
					array[2] = OleDbType.Integer;
					object[] array2 = array;
					NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					object instance2 = db;
					object[] array3 = new object[3] { "@tipo", null, null };
					ref string tipo = ref mNOVO_ExportadosImportada[i].Tipo;
					ref string reference2 = ref tipo;
					array3[1] = tipo;
					array3[2] = OleDbType.Char;
					array2 = array3;
					NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance3 = db;
					object[] array4 = new object[3] { "@dwg", null, null };
					ref int dWG = ref mNOVO_ExportadosImportada[i].DWG;
					reference = ref dWG;
					array4[1] = dWG;
					array4[2] = OleDbType.Integer;
					array2 = array4;
					NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					object instance4 = db;
					object[] array5 = new object[3] { "@caderno", null, null };
					ref string caderno = ref mNOVO_ExportadosImportada[i].Caderno;
					reference2 = ref caderno;
					array5[1] = caderno;
					array5[2] = OleDbType.Char;
					array2 = array5;
					NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance5 = db;
					object[] array6 = new object[3] { "@handle", null, null };
					ref string handle = ref mNOVO_ExportadosImportada[i].Handle;
					reference2 = ref handle;
					array6[1] = handle;
					array6[2] = OleDbType.Char;
					array2 = array6;
					NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance6 = db;
					object[] array7 = new object[3] { "@pagina", null, null };
					ref string pagina = ref mNOVO_ExportadosImportada[i].Pagina;
					reference2 = ref pagina;
					array7[1] = pagina;
					array7[2] = OleDbType.Char;
					array2 = array7;
					NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance7 = db;
					object[] array8 = new object[3] { "@posicao", null, null };
					ref string posicao = ref mNOVO_ExportadosImportada[i].Posicao;
					reference2 = ref posicao;
					array8[1] = posicao;
					array8[2] = OleDbType.Char;
					array2 = array8;
					NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance8 = db;
					object[] array9 = new object[3] { "@painel", null, null };
					ref int painel = ref mNOVO_ExportadosImportada[i].Painel;
					reference = ref painel;
					array9[1] = painel;
					array9[2] = OleDbType.Integer;
					array2 = array9;
					NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					object instance9 = db;
					object[] array10 = new object[3] { "@textos", null, null };
					ref string texto = ref mNOVO_ExportadosImportada[i].Texto;
					reference2 = ref texto;
					array10[1] = texto;
					array10[2] = OleDbType.Char;
					array2 = array10;
					NewLateBinding.LateCall(instance9, null, "AddParameter", array10, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance10 = db;
					object[] array11 = new object[3] { "@DWGDest", null, null };
					ref int dWGDest = ref mNOVO_ExportadosImportada[i].DWGDest;
					reference = ref dWGDest;
					array11[1] = dWGDest;
					array11[2] = OleDbType.Integer;
					array2 = array11;
					NewLateBinding.LateCall(instance10, null, "AddParameter", array11, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					object instance11 = db;
					object[] array12 = new object[3] { "@CadernoDest", null, null };
					ref string cadernoDest = ref mNOVO_ExportadosImportada[i].CadernoDest;
					reference2 = ref cadernoDest;
					array12[1] = cadernoDest;
					array12[2] = OleDbType.Char;
					array2 = array12;
					NewLateBinding.LateCall(instance11, null, "AddParameter", array12, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance12 = db;
					object[] array13 = new object[3] { "@PaginaDest", null, null };
					ref string paginaDest = ref mNOVO_ExportadosImportada[i].PaginaDest;
					reference2 = ref paginaDest;
					array13[1] = paginaDest;
					array13[2] = OleDbType.Char;
					array2 = array13;
					NewLateBinding.LateCall(instance12, null, "AddParameter", array13, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance13 = db;
					object[] array14 = new object[3] { "@PosicaoDest", null, null };
					ref string posicaoDest = ref mNOVO_ExportadosImportada[i].PosicaoDest;
					reference2 = ref posicaoDest;
					array14[1] = posicaoDest;
					array14[2] = OleDbType.Char;
					array2 = array14;
					NewLateBinding.LateCall(instance13, null, "AddParameter", array14, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance14 = db;
					object[] array15 = new object[3] { "@NomeRegua", null, null };
					ref string nomeRegua = ref mNOVO_ExportadosImportada[i].NomeRegua;
					reference2 = ref nomeRegua;
					array15[1] = nomeRegua;
					array15[2] = OleDbType.Char;
					array2 = array15;
					NewLateBinding.LateCall(instance14, null, "AddParameter", array15, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance15 = db;
					object[] array16 = new object[3] { "@indexModelo", null, null };
					ref int indiceModelo = ref mNOVO_ExportadosImportada[i].indiceModelo;
					reference = ref indiceModelo;
					array16[1] = indiceModelo;
					array16[2] = OleDbType.Integer;
					array2 = array16;
					NewLateBinding.LateCall(instance15, null, "AddParameter", array16, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					object instance16 = db;
					object[] array17 = new object[3] { "@Atualizado", null, null };
					ref bool atualizado = ref mNOVO_ExportadosImportada[i].atualizado;
					array17[1] = atualizado;
					array17[2] = OleDbType.Boolean;
					array2 = array17;
					NewLateBinding.LateCall(instance16, null, "AddParameter", array17, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					atualizado = (bool)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(bool));
					NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				int num2 = Information.UBound(mNOVO_AtributosImportada);
				for (int j = 1; j <= num2; j++)
				{
					text = "Insert into Atributos(DWG, Handle, Nome, Valor) VALUES(@dwg, @handle, @nome, @valor)";
					object instance17 = db;
					object[] array18 = new object[3] { "@dwg", null, null };
					ref int dWG2 = ref mNOVO_AtributosImportada[j].DWG;
					ref int reference = ref dWG2;
					array18[1] = dWG2;
					array18[2] = OleDbType.Integer;
					object[] array2 = array18;
					NewLateBinding.LateCall(instance17, null, "AddParameter", array18, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
					object instance18 = db;
					object[] array19 = new object[3] { "@handle", null, null };
					ref string handle2 = ref mNOVO_AtributosImportada[j].Handle;
					ref string reference2 = ref handle2;
					array19[1] = handle2;
					array19[2] = OleDbType.Char;
					array2 = array19;
					NewLateBinding.LateCall(instance18, null, "AddParameter", array19, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance19 = db;
					object[] array20 = new object[3] { "@nome", null, null };
					ref string nome = ref mNOVO_AtributosImportada[j].Nome;
					reference2 = ref nome;
					array20[1] = nome;
					array20[2] = OleDbType.Char;
					array2 = array20;
					NewLateBinding.LateCall(instance19, null, "AddParameter", array20, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					object instance20 = db;
					object[] array21 = new object[3] { "@valor", null, null };
					ref string valor = ref mNOVO_AtributosImportada[j].Valor;
					reference2 = ref valor;
					array21[1] = valor;
					array21[2] = OleDbType.Char;
					array2 = array21;
					NewLateBinding.LateCall(instance20, null, "AddParameter", array21, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					reference2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
					NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DeclaracoesGeral._uscPagina.pbPasso();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				throw new Exception(ex2.Message);
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	public void CarregaExportadosImpProj(ref clsImportarProjetos.mExpo[] mExportados, ref clsImportarProjetos.mAtt[] mAtributos)
	{
		checked
		{
			try
			{
				int num = 0;
				mExportados = new clsImportarProjetos.mExpo[1];
				int num2 = 0;
				mAtributos = new clsImportarProjetos.mAtt[1];
				try
				{
					string text = "SELECT Codigo, Tipo, DWG, Caderno, Handle, Pagina, Posicao, Painel, Texto, DWGDest, CadernoDest, PaginaDest, PosicaoDest, NomeRegua, indexModelo, Atualizado  FROM Exportados";
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
							mExportados = (clsImportarProjetos.mExpo[])Utils.CopyArray(mExportados, new clsImportarProjetos.mExpo[num + 1]);
							mExportados[num].Codigo = Conversions.ToInteger(dataTable.Rows[i][0]);
							mExportados[num].Tipo = Conversions.ToString(dataTable.Rows[i][1]);
							mExportados[num].DWG = Conversions.ToInteger(dataTable.Rows[i][2]);
							mExportados[num].Caderno = Conversions.ToString(dataTable.Rows[i][3]);
							mExportados[num].Handle = Conversions.ToString(dataTable.Rows[i][4]);
							mExportados[num].Pagina = Conversions.ToString(dataTable.Rows[i][5]);
							mExportados[num].Posicao = Conversions.ToString(dataTable.Rows[i][6]);
							mExportados[num].Painel = Conversions.ToInteger(dataTable.Rows[i][7]);
							mExportados[num].Texto = Conversions.ToString(dataTable.Rows[i][8]);
							mExportados[num].DWGDest = Conversions.ToInteger(dataTable.Rows[i][9]);
							mExportados[num].CadernoDest = Conversions.ToString(dataTable.Rows[i][10]);
							mExportados[num].PaginaDest = Conversions.ToString(dataTable.Rows[i][11]);
							mExportados[num].PosicaoDest = Conversions.ToString(dataTable.Rows[i][12]);
							mExportados[num].NomeRegua = Conversions.ToString(dataTable.Rows[i][13]);
							mExportados[num].indiceModelo = Conversions.ToInteger(dataTable.Rows[i][14]);
							mExportados[num].atualizado = Conversions.ToBoolean(dataTable.Rows[i][15]);
						}
					}
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				try
				{
					string text2 = "SELECT DWG, Handle, Nome, Valor FROM Atributos";
					object instance2 = db;
					object[] array3 = new object[1] { text2 };
					object[] array2 = array3;
					object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
					text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					DataTable dataTable2 = (DataTable)obj;
					if (dataTable2.Rows.Count > 0)
					{
						int num4 = dataTable2.Rows.Count - 1;
						for (int j = 0; j <= num4; j++)
						{
							num2++;
							mAtributos = (clsImportarProjetos.mAtt[])Utils.CopyArray(mAtributos, new clsImportarProjetos.mAtt[num2 + 1]);
							mAtributos[num2].DWG = Conversions.ToInteger(dataTable2.Rows[j][0]);
							mAtributos[num2].Handle = Conversions.ToString(dataTable2.Rows[j][1]);
							mAtributos[num2].Nome = Conversions.ToString(dataTable2.Rows[j][2]);
							mAtributos[num2].Valor = Conversions.ToString(dataTable2.Rows[j][3]);
						}
					}
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					ProjectData.ClearProjectError();
				}
			}
			catch (Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				throw;
			}
		}
	}

	public int BuscaIndiceExportado(int Codigo, int DWG, string Handle)
	{
		int result = 0;
		try
		{
			string text = "SELECT Indice FROM Exportados WHERE Codigo=@codigo and DWG=@dwg and Handle=@handle ";
			object instance = db;
			object[] array = new object[3]
			{
				"@codigo",
				Codigo,
				OleDbType.Integer
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			Codigo = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@dwg",
				DWG,
				OleDbType.Integer
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			DWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance3 = db;
			object[] array4 = new object[3]
			{
				"@handle",
				Handle,
				OleDbType.Char
			};
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			Handle = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance4 = db;
			object[] array5 = new object[1] { text };
			array2 = array5;
			object value = NewLateBinding.LateGet(instance4, null, "ExecuteScalar", array5, null, null, new bool[1] { true });
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			result = Conversions.ToInteger(value);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public int BuscaIndiceImportado(int Codigo, int DWG_DEST, string Handle)
	{
		int result = 0;
		try
		{
			string text = "SELECT Indice FROM Exportados WHERE Codigo=@codigo and DWGDest=@dwg and Handle=@handle ";
			object instance = db;
			object[] array = new object[3]
			{
				"@codigo",
				Codigo,
				OleDbType.Integer
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			Codigo = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@dwg",
				DWG_DEST,
				OleDbType.Integer
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			DWG_DEST = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance3 = db;
			object[] array4 = new object[3]
			{
				"@handle",
				Handle,
				OleDbType.Char
			};
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			Handle = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
			object instance4 = db;
			object[] array5 = new object[1] { text };
			array2 = array5;
			object value = NewLateBinding.LateGet(instance4, null, "ExecuteScalar", array5, null, null, new bool[1] { true });
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			result = Conversions.ToInteger(value);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public void CarregaTodaLMDoImpProj(ref cDadosLM.structureLMRelelatorio[] mLP)
	{
		int num = 0;
		mLP = new cDadosLM.structureLMRelelatorio[1];
		checked
		{
			try
			{
				string text = "SELECT * FROM Materiais";
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
						mLP = (cDadosLM.structureLMRelelatorio[])Utils.CopyArray(mLP, new cDadosLM.structureLMRelelatorio[num + 1]);
						mLP[num].Index = Conversions.ToString(dataTable.Rows[i][0]);
						mLP[num].CodCli = Conversions.ToString(dataTable.Rows[i][1]);
						mLP[num].Desc = Conversions.ToString(dataTable.Rows[i][2]);
						mLP[num].DescCompleta = Conversions.ToString(dataTable.Rows[i][3]);
						mLP[num].sModelo = Conversions.ToString(dataTable.Rows[i][4]);
						mLP[num].sFabricante = Conversions.ToString(dataTable.Rows[i][5]);
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

	public void LeBanco(string strSQL, ref DataTable dt)
	{
		try
		{
			object instance = db;
			object[] array = new object[1] { strSQL };
			object[] array2 = array;
			object obj = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
			strSQL = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			dt = (DataTable)obj;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public void AdicionaItemFiacaosDT(DataTable dt, clsImportarProjetos.mIndiceTrocaDWG[] mIndiceTrocaDWG, clsImportarProjetos.mIndiceTrocaPN[] iIndicePN_TROCA, ref long I, DeclaracoesFiacao.structureRevisoes[] mRevisoes)
	{
		checked
		{
			try
			{
				string text = Environment.UserName;
				DateTime dateTime = Conversions.ToDate(DateTime.Now.ToString());
				if (dt.Rows.Count <= 0)
				{
					return;
				}
				List<int> list = new List<int>();
				int num = Information.UBound(mIndiceTrocaDWG);
				for (int i = 1; i <= num; i++)
				{
					list.Add(mIndiceTrocaDWG[i].iDWG);
				}
				List<string> list2 = new List<string>();
				int num2 = Information.UBound(mRevisoes);
				for (int j = 1; j <= num2; j++)
				{
					if (list.Contains(mRevisoes[j].Dwg))
					{
						list2.Add(mRevisoes[j].revisao);
					}
				}
				int num3 = dt.Rows.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					if (list.Contains(Conversions.ToInteger(dt.Rows[k][1])) && list2.Contains(Conversions.ToString(dt.Rows[k][0])))
					{
						string text2 = "Insert into Fiacao(Revisao, DWG, Painel, Potencial, Ordem, Pagina, Tag, Alternativo, NRegua, Terminal, TerminalNum, Tipo, Secao, Cor, PosicaoNum, TipoBorne, BJumper, BLink, Handle, IndexModelo, Aplicacao, Orientacao, Criador, Data) VALUES(@revisao, @dwg, @painel, @potencial, @ordem, @pagina, @tag, @alternativo, @nregua, @terminal, @terminalNum, @tipo, @secao, @cor, @posicaoNum, @tipoBorne, @bJumper, @bLink, @handle, @indexModelo, @aplicacao, @orientacao, @criador, @data)";
						object instance = db;
						DataRow dataRow;
						object[] array = new object[3]
						{
							"@revisao",
							(dataRow = dt.Rows[k])[0],
							OleDbType.Char
						};
						object[] array2 = array;
						NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[0] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
						{
							"@dwg",
							clsImportarProjetos.BuscaNovoDWG(mIndiceTrocaDWG, Conversions.ToInteger(dt.Rows[k][1])),
							OleDbType.Integer
						}, null, null, null, IgnoreReturn: true);
						NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
						{
							"@painel",
							clsImportarProjetos.BuscaNovoPainel(iIndicePN_TROCA, Conversions.ToInteger(dt.Rows[k][2])),
							OleDbType.Integer
						}, null, null, null, IgnoreReturn: true);
						object instance2 = db;
						object[] array3 = new object[3]
						{
							"@potencial",
							(dataRow = dt.Rows[k])[3],
							OleDbType.Integer
						};
						array2 = array3;
						NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[3] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance3 = db;
						object[] array4 = new object[3]
						{
							"@ordem",
							(dataRow = dt.Rows[k])[4],
							OleDbType.Integer
						};
						array2 = array4;
						NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[4] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance4 = db;
						object[] array5 = new object[3]
						{
							"@pagina",
							(dataRow = dt.Rows[k])[5],
							OleDbType.Char
						};
						array2 = array5;
						NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[5] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance5 = db;
						object[] array6 = new object[3]
						{
							"@tag",
							(dataRow = dt.Rows[k])[6],
							OleDbType.Char
						};
						array2 = array6;
						NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[6] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance6 = db;
						object[] array7 = new object[3]
						{
							"@alternativo",
							(dataRow = dt.Rows[k])[7],
							OleDbType.Char
						};
						array2 = array7;
						NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[7] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance7 = db;
						object[] array8 = new object[3]
						{
							"@nregua",
							(dataRow = dt.Rows[k])[8],
							OleDbType.Char
						};
						array2 = array8;
						NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[8] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance8 = db;
						object[] array9 = new object[3]
						{
							"@terminal",
							(dataRow = dt.Rows[k])[9],
							OleDbType.Char
						};
						array2 = array9;
						NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[9] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance9 = db;
						object[] array10 = new object[3]
						{
							"@terminalNum",
							(dataRow = dt.Rows[k])[10],
							OleDbType.Double
						};
						array2 = array10;
						NewLateBinding.LateCall(instance9, null, "AddParameter", array10, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[10] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance10 = db;
						object[] array11 = new object[3]
						{
							"@tipo",
							(dataRow = dt.Rows[k])[11],
							OleDbType.Char
						};
						array2 = array11;
						NewLateBinding.LateCall(instance10, null, "AddParameter", array11, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[11] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance11 = db;
						object[] array12 = new object[3]
						{
							"@secao",
							(dataRow = dt.Rows[k])[12],
							OleDbType.Char
						};
						array2 = array12;
						NewLateBinding.LateCall(instance11, null, "AddParameter", array12, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[12] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance12 = db;
						object[] array13 = new object[3]
						{
							"@cor",
							(dataRow = dt.Rows[k])[13],
							OleDbType.Char
						};
						array2 = array13;
						NewLateBinding.LateCall(instance12, null, "AddParameter", array13, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[13] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance13 = db;
						object[] array14 = new object[3]
						{
							"@posicaoNum",
							(dataRow = dt.Rows[k])[14],
							OleDbType.Integer
						};
						array2 = array14;
						NewLateBinding.LateCall(instance13, null, "AddParameter", array14, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[14] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance14 = db;
						object[] array15 = new object[3]
						{
							"@tipoBorne",
							(dataRow = dt.Rows[k])[15],
							OleDbType.Integer
						};
						array2 = array15;
						NewLateBinding.LateCall(instance14, null, "AddParameter", array15, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[15] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance15 = db;
						object[] array16 = new object[3]
						{
							"@bJumper",
							(dataRow = dt.Rows[k])[16],
							OleDbType.Boolean
						};
						array2 = array16;
						NewLateBinding.LateCall(instance15, null, "AddParameter", array16, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[16] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance16 = db;
						object[] array17 = new object[3]
						{
							"@bLink",
							(dataRow = dt.Rows[k])[17],
							OleDbType.Boolean
						};
						array2 = array17;
						NewLateBinding.LateCall(instance16, null, "AddParameter", array17, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[17] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance17 = db;
						object[] array18 = new object[3]
						{
							"@handle",
							(dataRow = dt.Rows[k])[18],
							OleDbType.Char
						};
						array2 = array18;
						NewLateBinding.LateCall(instance17, null, "AddParameter", array18, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[18] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance18 = db;
						object[] array19 = new object[3]
						{
							"@indexModelo",
							(dataRow = dt.Rows[k])[19],
							OleDbType.Integer
						};
						array2 = array19;
						NewLateBinding.LateCall(instance18, null, "AddParameter", array19, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[19] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance19 = db;
						object[] array20 = new object[3]
						{
							"@aplicacao",
							(dataRow = dt.Rows[k])[20],
							OleDbType.Integer
						};
						array2 = array20;
						NewLateBinding.LateCall(instance19, null, "AddParameter", array20, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[20] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance20 = db;
						object[] array21 = new object[3]
						{
							"@orientacao",
							(dataRow = dt.Rows[k])[21],
							OleDbType.Char
						};
						array2 = array21;
						NewLateBinding.LateCall(instance20, null, "AddParameter", array21, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[21] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance21 = db;
						object[] array22 = new object[3]
						{
							"@criador",
							text,
							OleDbType.Char
						};
						array2 = array22;
						NewLateBinding.LateCall(instance21, null, "AddParameter", array22, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						object instance22 = db;
						object[] array23 = new object[3]
						{
							"@data",
							dateTime,
							OleDbType.Date
						};
						array2 = array23;
						NewLateBinding.LateCall(instance22, null, "AddParameter", array23, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dateTime = (DateTime)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(DateTime));
						object instance23 = db;
						object[] array24 = new object[1] { text2 };
						array2 = array24;
						NewLateBinding.LateCall(instance23, null, "ExecuteNonQuery", array24, null, null, new bool[1] { true }, IgnoreReturn: true);
						text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					}
					I++;
					if (I > 1000L)
					{
						DeclaracoesGeral._uscPagina.pbPasso(1000);
						I = 0L;
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

	public void AdicionaItemBornesDT(DataTable dt, clsImportarProjetos.mIndiceTrocaDWG[] mIndiceTrocaDWG, clsImportarProjetos.mIndiceTrocaPN[] iIndicePN_TROCA, ref long iProgress, DeclaracoesFiacao.structureRevisoes[] mRevisoes)
	{
		checked
		{
			try
			{
				List<int> list = new List<int>();
				int num = Information.UBound(mIndiceTrocaDWG);
				for (int i = 1; i <= num; i++)
				{
					list.Add(mIndiceTrocaDWG[i].iDWG);
				}
				List<string> list2 = new List<string>();
				int num2 = Information.UBound(mRevisoes);
				for (int j = 1; j <= num2; j++)
				{
					if (list.Contains(mRevisoes[j].Dwg))
					{
						list2.Add(mRevisoes[j].revisao);
					}
				}
				int num3 = dt.Rows.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					if (list.Contains(Conversions.ToInteger(dt.Rows[k][1])) && list2.Contains(Conversions.ToString(dt.Rows[k][0])))
					{
						string text = "Insert into Bornes4F(Revisao, DWG, Painel, IndexRegua, Regua, Alternativo, Handle, Borne, Ordem, Tipo, Pagina, bReserva, LM, Orientacao, BlocoLayout) VALUES(@revisao, @dwg, @painel, @indexRegua, @regua, @alternativo, @handle, @borne, @ordem, @tipo, @pagina, @reserva, @LM, @orientacao, @blocoLayout)";
						object instance = db;
						DataRow dataRow;
						object[] array = new object[3]
						{
							"@revisao",
							(dataRow = dt.Rows[k])[0],
							OleDbType.Char
						};
						object[] array2 = array;
						NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[0] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
						{
							"@dwg",
							clsImportarProjetos.BuscaNovoDWG(mIndiceTrocaDWG, Conversions.ToInteger(dt.Rows[k][1])),
							OleDbType.Integer
						}, null, null, null, IgnoreReturn: true);
						NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
						{
							"@painel",
							clsImportarProjetos.BuscaNovoPainel(iIndicePN_TROCA, Conversions.ToInteger(dt.Rows[k][2])),
							OleDbType.Integer
						}, null, null, null, IgnoreReturn: true);
						object instance2 = db;
						object[] array3 = new object[3]
						{
							"@indexRegua",
							(dataRow = dt.Rows[k])[3],
							OleDbType.Integer
						};
						array2 = array3;
						NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[3] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance3 = db;
						object[] array4 = new object[3]
						{
							"@regua",
							(dataRow = dt.Rows[k])[4],
							OleDbType.Char
						};
						array2 = array4;
						NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[4] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance4 = db;
						object[] array5 = new object[3]
						{
							"@alternativo",
							(dataRow = dt.Rows[k])[5],
							OleDbType.Char
						};
						array2 = array5;
						NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[5] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance5 = db;
						object[] array6 = new object[3]
						{
							"@handle",
							(dataRow = dt.Rows[k])[6],
							OleDbType.Char
						};
						array2 = array6;
						NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[6] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance6 = db;
						object[] array7 = new object[3]
						{
							"@borne",
							(dataRow = dt.Rows[k])[7],
							OleDbType.Char
						};
						array2 = array7;
						NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[7] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance7 = db;
						object[] array8 = new object[3]
						{
							"@ordem",
							(dataRow = dt.Rows[k])[8],
							OleDbType.Double
						};
						array2 = array8;
						NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[8] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance8 = db;
						object[] array9 = new object[3]
						{
							"@tipo",
							(dataRow = dt.Rows[k])[9],
							OleDbType.Integer
						};
						array2 = array9;
						NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[9] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance9 = db;
						object[] array10 = new object[3]
						{
							"@pagina",
							(dataRow = dt.Rows[k])[10],
							OleDbType.Char
						};
						array2 = array10;
						NewLateBinding.LateCall(instance9, null, "AddParameter", array10, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[10] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance10 = db;
						object[] array11 = new object[3]
						{
							"@reserva",
							(dataRow = dt.Rows[k])[11],
							OleDbType.Boolean
						};
						array2 = array11;
						NewLateBinding.LateCall(instance10, null, "AddParameter", array11, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[11] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance11 = db;
						object[] array12 = new object[3]
						{
							"@LM",
							(dataRow = dt.Rows[k])[12],
							OleDbType.Integer
						};
						array2 = array12;
						NewLateBinding.LateCall(instance11, null, "AddParameter", array12, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[12] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance12 = db;
						object[] array13 = new object[3]
						{
							"@orientacao",
							(dataRow = dt.Rows[k])[13],
							OleDbType.Char
						};
						array2 = array13;
						NewLateBinding.LateCall(instance12, null, "AddParameter", array13, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[13] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance13 = db;
						object[] array14 = new object[3]
						{
							"@blocoLayout",
							(dataRow = dt.Rows[k])[14],
							OleDbType.Char
						};
						array2 = array14;
						NewLateBinding.LateCall(instance13, null, "AddParameter", array14, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[14] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance14 = db;
						object[] array15 = new object[1] { text };
						array2 = array15;
						NewLateBinding.LateCall(instance14, null, "ExecuteNonQuery", array15, null, null, new bool[1] { true }, IgnoreReturn: true);
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					}
					iProgress++;
					if (iProgress > 1000L)
					{
						DeclaracoesGeral._uscPagina.pbPasso(1000);
						iProgress = 0L;
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

	public void AdicionaItemCircuitos4FDT(DataTable dt, clsImportarProjetos.mIndiceTrocaDWG[] mIndiceTrocaDWG, clsImportarProjetos.mIndiceTrocaPN[] iIndicePN_TROCA, ref long iProgress, DeclaracoesFiacao.structureRevisoes[] mRevisoes)
	{
		checked
		{
			try
			{
				DeclaracoesGeral._uscPagina.pbPasso(0);
				List<int> list = new List<int>();
				int num = Information.UBound(mIndiceTrocaDWG);
				for (int i = 1; i <= num; i++)
				{
					list.Add(mIndiceTrocaDWG[i].iDWG);
				}
				List<string> list2 = new List<string>();
				int num2 = Information.UBound(mRevisoes);
				for (int j = 1; j <= num2; j++)
				{
					if (list.Contains(mRevisoes[j].Dwg))
					{
						list2.Add(mRevisoes[j].revisao);
					}
				}
				int num3 = dt.Rows.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					if (list.Contains(Conversions.ToInteger(dt.Rows[k][1])) && list2.Contains(Conversions.ToString(dt.Rows[k][0])))
					{
						string text = "Insert into Circuitos4F(Revisao, DWG, Painel, Circuito, Potencial) VALUES(@revisao, @dwg, @painel, @circuito, @potencial)";
						object instance = db;
						DataRow dataRow;
						object[] array = new object[3]
						{
							"@revisao",
							(dataRow = dt.Rows[k])[0],
							OleDbType.Char
						};
						object[] array2 = array;
						NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[0] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
						{
							"@dwg",
							clsImportarProjetos.BuscaNovoDWG(mIndiceTrocaDWG, Conversions.ToInteger(dt.Rows[k][1])),
							OleDbType.Integer
						}, null, null, null, IgnoreReturn: true);
						NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
						{
							"@painel",
							clsImportarProjetos.BuscaNovoPainel(iIndicePN_TROCA, Conversions.ToInteger(dt.Rows[k][2])),
							OleDbType.Integer
						}, null, null, null, IgnoreReturn: true);
						object instance2 = db;
						object[] array3 = new object[3]
						{
							"@circuito",
							(dataRow = dt.Rows[k])[3],
							OleDbType.Char
						};
						array2 = array3;
						NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[3] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance3 = db;
						object[] array4 = new object[3]
						{
							"@potencial",
							(dataRow = dt.Rows[k])[4],
							OleDbType.Integer
						};
						array2 = array4;
						NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[4] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance4 = db;
						object[] array5 = new object[1] { text };
						array2 = array5;
						NewLateBinding.LateCall(instance4, null, "ExecuteNonQuery", array5, null, null, new bool[1] { true }, IgnoreReturn: true);
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					}
					iProgress++;
					if (iProgress > 1000L)
					{
						DeclaracoesGeral._uscPagina.pbPasso(1000);
						iProgress = 0L;
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

	public void AdicionaItemContatos4FDT(DataTable dt, clsImportarProjetos.mIndiceTrocaDWG[] mIndiceTrocaDWG, clsImportarProjetos.mIndiceTrocaPN[] iIndicePN_TROCA, ref long iProgress, DeclaracoesFiacao.structureRevisoes[] mRevisoes)
	{
		checked
		{
			try
			{
				if (dt.Rows.Count <= 0)
				{
					return;
				}
				List<int> list = new List<int>();
				int num = Information.UBound(mIndiceTrocaDWG);
				for (int i = 1; i <= num; i++)
				{
					list.Add(mIndiceTrocaDWG[i].iDWG);
				}
				List<string> list2 = new List<string>();
				int num2 = Information.UBound(mRevisoes);
				for (int j = 1; j <= num2; j++)
				{
					if (list.Contains(mRevisoes[j].Dwg))
					{
						list2.Add(mRevisoes[j].revisao);
					}
				}
				int num3 = dt.Rows.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					if (list.Contains(Conversions.ToInteger(dt.Rows[k][1])) && list2.Contains(Conversions.ToString(dt.Rows[k][0])))
					{
						string text = "Insert into Contatos4F(Revisao, DWG, IndexModelo, NomeModelo, Terminal, TerminalNum, Orientacao) VALUES(@revisao, @dwg, @indexModelo, @nomeModelo, @terminal, @terminalNum, @orientacao)";
						object instance = db;
						DataRow dataRow;
						object[] array = new object[3]
						{
							"@revisao",
							(dataRow = dt.Rows[k])[0],
							OleDbType.Char
						};
						object[] array2 = array;
						NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[0] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
						{
							"@dwg",
							clsImportarProjetos.BuscaNovoDWG(mIndiceTrocaDWG, Conversions.ToInteger(dt.Rows[k][1])),
							OleDbType.Integer
						}, null, null, null, IgnoreReturn: true);
						object instance2 = db;
						object[] array3 = new object[3]
						{
							"@indexModelo",
							(dataRow = dt.Rows[k])[2],
							OleDbType.Integer
						};
						array2 = array3;
						NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[2] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance3 = db;
						object[] array4 = new object[3]
						{
							"@nomeModelo",
							(dataRow = dt.Rows[k])[3],
							OleDbType.Char
						};
						array2 = array4;
						NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[3] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance4 = db;
						object[] array5 = new object[3]
						{
							"@terminal",
							(dataRow = dt.Rows[k])[4],
							OleDbType.Char
						};
						array2 = array5;
						NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[4] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance5 = db;
						object[] array6 = new object[3]
						{
							"@terminalNum",
							(dataRow = dt.Rows[k])[5],
							OleDbType.Double
						};
						array2 = array6;
						NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[5] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance6 = db;
						object[] array7 = new object[3]
						{
							"@orientacao",
							(dataRow = dt.Rows[k])[6],
							OleDbType.Char
						};
						array2 = array7;
						NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[6] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance7 = db;
						object[] array8 = new object[1] { text };
						array2 = array8;
						NewLateBinding.LateCall(instance7, null, "ExecuteNonQuery", array8, null, null, new bool[1] { true }, IgnoreReturn: true);
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					}
					iProgress++;
					if (iProgress > 1000L)
					{
						DeclaracoesGeral._uscPagina.pbPasso(1000);
						iProgress = 0L;
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

	public void AdicionaItemDispositivos4FDT(DataTable dt, clsImportarProjetos.mIndiceTrocaDWG[] mIndiceTrocaDWG, clsImportarProjetos.mIndiceTrocaPN[] iIndicePN_TROCA, ref long iProgress, DeclaracoesFiacao.structureRevisoes[] mRevisoes)
	{
		checked
		{
			try
			{
				if (dt.Rows.Count <= 0)
				{
					return;
				}
				List<int> list = new List<int>();
				int num = Information.UBound(mIndiceTrocaDWG);
				for (int i = 1; i <= num; i++)
				{
					list.Add(mIndiceTrocaDWG[i].iDWG);
				}
				List<string> list2 = new List<string>();
				int num2 = Information.UBound(mRevisoes);
				for (int j = 1; j <= num2; j++)
				{
					if (list.Contains(mRevisoes[j].Dwg))
					{
						list2.Add(mRevisoes[j].revisao);
					}
				}
				int num3 = dt.Rows.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					if (list.Contains(Conversions.ToInteger(dt.Rows[k][1])) && list2.Contains(Conversions.ToString(dt.Rows[k][0])))
					{
						string text = "Insert into Dispositivos4F(Revisao, DWG, Painel, Tag, Alternativo, Tipo, Handle, Pagina, BlocoTopografico, BlocoLayout, PosicaoNum, Ordem) VALUES(@revisao, @dwg, @painel, @tag, @alternativo, @tipo, @handle, @pagina, @blocoTopografico, @blocoLayout, @posicaoNum, @ordem)";
						object instance = db;
						DataRow dataRow;
						object[] array = new object[3]
						{
							"@revisao",
							(dataRow = dt.Rows[k])[0],
							OleDbType.Char
						};
						object[] array2 = array;
						NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[0] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
						{
							"@dwg",
							clsImportarProjetos.BuscaNovoDWG(mIndiceTrocaDWG, Conversions.ToInteger(dt.Rows[k][1])),
							OleDbType.Integer
						}, null, null, null, IgnoreReturn: true);
						NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
						{
							"@painel",
							clsImportarProjetos.BuscaNovoPainel(iIndicePN_TROCA, Conversions.ToInteger(dt.Rows[k][2])),
							OleDbType.Integer
						}, null, null, null, IgnoreReturn: true);
						object instance2 = db;
						object[] array3 = new object[3]
						{
							"@tag",
							(dataRow = dt.Rows[k])[3],
							OleDbType.Char
						};
						array2 = array3;
						NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[3] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance3 = db;
						object[] array4 = new object[3]
						{
							"@alternativo",
							(dataRow = dt.Rows[k])[4],
							OleDbType.Char
						};
						array2 = array4;
						NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[4] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance4 = db;
						object[] array5 = new object[3]
						{
							"@tipo",
							(dataRow = dt.Rows[k])[5],
							OleDbType.Char
						};
						array2 = array5;
						NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[5] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance5 = db;
						object[] array6 = new object[3]
						{
							"@handle",
							(dataRow = dt.Rows[k])[6],
							OleDbType.Char
						};
						array2 = array6;
						NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[6] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance6 = db;
						object[] array7 = new object[3]
						{
							"@pagina",
							(dataRow = dt.Rows[k])[7],
							OleDbType.Char
						};
						array2 = array7;
						NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[7] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance7 = db;
						object[] array8 = new object[3]
						{
							"@blocoTopografico",
							(dataRow = dt.Rows[k])[8],
							OleDbType.Char
						};
						array2 = array8;
						NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[8] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance8 = db;
						object[] array9 = new object[3]
						{
							"@blocoLayout",
							(dataRow = dt.Rows[k])[9],
							OleDbType.Char
						};
						array2 = array9;
						NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[9] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance9 = db;
						object[] array10 = new object[3]
						{
							"@posicaoNum",
							(dataRow = dt.Rows[k])[10],
							OleDbType.Integer
						};
						array2 = array10;
						NewLateBinding.LateCall(instance9, null, "AddParameter", array10, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[10] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance10 = db;
						object[] array11 = new object[3]
						{
							"@ordem",
							(dataRow = dt.Rows[k])[11],
							OleDbType.Integer
						};
						array2 = array11;
						NewLateBinding.LateCall(instance10, null, "AddParameter", array11, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[11] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance11 = db;
						object[] array12 = new object[1] { text };
						array2 = array12;
						NewLateBinding.LateCall(instance11, null, "ExecuteNonQuery", array12, null, null, new bool[1] { true }, IgnoreReturn: true);
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					}
					iProgress++;
					if (iProgress > 1000L)
					{
						DeclaracoesGeral._uscPagina.pbPasso(1000);
						iProgress = 0L;
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

	public void AdicionaItemPortas4FDT(DataTable dt, clsImportarProjetos.mIndiceTrocaDWG[] mIndiceTrocaDWG, clsImportarProjetos.mIndiceTrocaPN[] iIndicePN_TROCA, ref long iProgress, DeclaracoesFiacao.structureRevisoes[] mRevisoes)
	{
		checked
		{
			try
			{
				if (dt.Rows.Count <= 0)
				{
					return;
				}
				List<int> list = new List<int>();
				int num = Information.UBound(mIndiceTrocaDWG);
				for (int i = 1; i <= num; i++)
				{
					list.Add(mIndiceTrocaDWG[i].iDWG);
				}
				List<string> list2 = new List<string>();
				int num2 = Information.UBound(mRevisoes);
				for (int j = 1; j <= num2; j++)
				{
					if (list.Contains(mRevisoes[j].Dwg))
					{
						list2.Add(mRevisoes[j].revisao);
					}
				}
				int num3 = dt.Rows.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					if (list.Contains(Conversions.ToInteger(dt.Rows[k][1])) && list2.Contains(Conversions.ToString(dt.Rows[k][0])))
					{
						string text = "Insert into Portas4F(Revisao, DWG, IndexModelo, NomeModelo, Regua, Borne, Terminal, TerminalNum, Tipo, Orientacao) VALUES(@revisao, @dwg, @indexModelo, @nomeModelo, @regua, @borne, @terminal, @terminalNum, @tipo, @orientacao)";
						object instance = db;
						DataRow dataRow;
						object[] array = new object[3]
						{
							"@revisao",
							(dataRow = dt.Rows[k])[0],
							OleDbType.Char
						};
						object[] array2 = array;
						NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[0] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", new object[3]
						{
							"@dwg",
							clsImportarProjetos.BuscaNovoDWG(mIndiceTrocaDWG, Conversions.ToInteger(dt.Rows[k][1])),
							OleDbType.Integer
						}, null, null, null, IgnoreReturn: true);
						object instance2 = db;
						object[] array3 = new object[3]
						{
							"@indexModelo",
							(dataRow = dt.Rows[k])[2],
							OleDbType.Integer
						};
						array2 = array3;
						NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[2] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance3 = db;
						object[] array4 = new object[3]
						{
							"@nomeModelo",
							(dataRow = dt.Rows[k])[3],
							OleDbType.Char
						};
						array2 = array4;
						NewLateBinding.LateCall(instance3, null, "AddParameter", array4, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[3] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance4 = db;
						object[] array5 = new object[3]
						{
							"@regua",
							(dataRow = dt.Rows[k])[4],
							OleDbType.Char
						};
						array2 = array5;
						NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[4] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance5 = db;
						object[] array6 = new object[3]
						{
							"@borne",
							(dataRow = dt.Rows[k])[5],
							OleDbType.Char
						};
						array2 = array6;
						NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[5] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance6 = db;
						object[] array7 = new object[3]
						{
							"@terminal",
							(dataRow = dt.Rows[k])[6],
							OleDbType.Char
						};
						array2 = array7;
						NewLateBinding.LateCall(instance6, null, "AddParameter", array7, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[6] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance7 = db;
						object[] array8 = new object[3]
						{
							"@terminalNum",
							(dataRow = dt.Rows[k])[7],
							OleDbType.Double
						};
						array2 = array8;
						NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[7] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance8 = db;
						object[] array9 = new object[3]
						{
							"@tipo",
							(dataRow = dt.Rows[k])[8],
							OleDbType.Char
						};
						array2 = array9;
						NewLateBinding.LateCall(instance8, null, "AddParameter", array9, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[8] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance9 = db;
						object[] array10 = new object[3]
						{
							"@orientacao",
							(dataRow = dt.Rows[k])[9],
							OleDbType.Char
						};
						array2 = array10;
						NewLateBinding.LateCall(instance9, null, "AddParameter", array10, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[9] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						object instance10 = db;
						object[] array11 = new object[1] { text };
						array2 = array11;
						NewLateBinding.LateCall(instance10, null, "ExecuteNonQuery", array11, null, null, new bool[1] { true }, IgnoreReturn: true);
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					}
					iProgress++;
					if (iProgress > 1000L)
					{
						DeclaracoesGeral._uscPagina.pbPasso(1000);
						iProgress = 0L;
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
}
