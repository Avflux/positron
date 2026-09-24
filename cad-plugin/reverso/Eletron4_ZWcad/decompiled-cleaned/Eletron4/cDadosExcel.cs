using System;
using System.Data;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class cDadosExcel
{
	public AcessoExcel db;

	public void fechaConexao()
	{
		db.fechaConexao();
	}

	public cDadosExcel()
	{
		db = new AcessoExcel();
	}

	public void ImportarPaginasPosLogico(ref PortaExportada[] mPortas)
	{
		mPortas = new PortaExportada[1];
		string text = "[" + DeclaracoesGeral.ConfLP.worksheet + "$]";
		checked
		{
			try
			{
				string text2 = "";
				text2 = ((Operators.CompareString(DeclaracoesGeral.ConfLP.funcaoPorta, "", TextCompare: true) != 0) ? ("SELECT " + DeclaracoesGeral.ConfLP.chavePrimaria + ", " + DeclaracoesGeral.ConfLP.enderecoFisico + ", " + DeclaracoesGeral.ConfLP.unidade + ", " + DeclaracoesGeral.ConfLP.posicaoLogico + ", " + DeclaracoesGeral.ConfLP.posicaoFuncional + ", " + DeclaracoesGeral.ConfLP.descricaoResumida + ", " + DeclaracoesGeral.ConfLP.funcaoPorta + " FROM " + text + " WHERE " + DeclaracoesGeral.ConfLP.chavePrimaria + " IS NOT NULL") : ("SELECT " + DeclaracoesGeral.ConfLP.chavePrimaria + ", " + DeclaracoesGeral.ConfLP.enderecoFisico + ", " + DeclaracoesGeral.ConfLP.unidade + ", " + DeclaracoesGeral.ConfLP.posicaoLogico + ", " + DeclaracoesGeral.ConfLP.posicaoFuncional + ", " + DeclaracoesGeral.ConfLP.descricaoResumida + " FROM " + text + " WHERE " + DeclaracoesGeral.ConfLP.chavePrimaria + " IS NOT NULL"));
				DataTable dataTable = db.ExecuteReader(text2);
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					int num2 = Information.UBound(mPortas) + 1;
					mPortas = (PortaExportada[])Utils.CopyArray(mPortas, new PortaExportada[num2 + 1]);
					mPortas[num2].sChavePrimaria = "";
					mPortas[num2].sEfc = "";
					mPortas[num2].shandle = "";
					mPortas[num2].sPosicaoFuncional = "";
					mPortas[num2].sPosicaoLogico = "";
					mPortas[num2].sUnidade = "";
					mPortas[num2].sFuncao = "";
					int num3 = dataTable.Columns.Count - 1;
					for (int j = 0; j <= num3; j++)
					{
						string text3 = "";
						if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][j])))
						{
							text3 = dataTable.Rows[i][j].ToString().Trim();
						}
						string columnName = dataTable.Columns[j].ColumnName;
						if (Operators.CompareString(columnName, DeclaracoesGeral.ConfLP.chavePrimaria, TextCompare: true) != 0)
						{
							if (Operators.CompareString(columnName, DeclaracoesGeral.ConfLP.enderecoFisico, TextCompare: true) != 0)
							{
								if (Operators.CompareString(columnName, DeclaracoesGeral.ConfLP.posicaoFuncional, TextCompare: true) != 0)
								{
									if (Operators.CompareString(columnName, DeclaracoesGeral.ConfLP.posicaoLogico, TextCompare: true) != 0)
									{
										if (Operators.CompareString(columnName, DeclaracoesGeral.ConfLP.unidade, TextCompare: true) != 0)
										{
											if (Operators.CompareString(columnName, DeclaracoesGeral.ConfLP.descricaoResumida, TextCompare: true) != 0)
											{
												if (Operators.CompareString(columnName, DeclaracoesGeral.ConfLP.funcaoPorta, TextCompare: true) == 0)
												{
													mPortas[num2].sFuncao = text3;
												}
											}
											else
											{
												mPortas[num2].sDescricao = text3;
											}
										}
										else
										{
											mPortas[num2].sUnidade = text3;
										}
									}
									else
									{
										mPortas[num2].sPosicaoLogico = text3;
									}
								}
								else
								{
									mPortas[num2].sPosicaoFuncional = text3;
								}
							}
							else
							{
								mPortas[num2].sEfc = text3;
							}
						}
						else
						{
							mPortas[num2].sChavePrimaria = text3;
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

	public void ImportarDadosRelatorioElektro(ref PortaRelElektro[] mPortas)
	{
		mPortas = new PortaRelElektro[1];
		string text = "[" + DeclaracoesGeral.ConfLP.worksheet + "$]";
		checked
		{
			try
			{
				string query = "";
				if (!((Operators.CompareString(DeclaracoesGeral.ConfLP.descricaoCompleta.Trim(), "", TextCompare: true) != 0) & (Operators.CompareString(DeclaracoesGeral.ConfLP.descricaoResumida.Trim(), "", TextCompare: true) != 0)))
				{
					if (!((Operators.CompareString(DeclaracoesGeral.ConfLP.descricaoCompleta.Trim(), "", TextCompare: true) != 0) & (Operators.CompareString(DeclaracoesGeral.ConfLP.descricaoResumida.Trim(), "", TextCompare: true) == 0)))
					{
						if (!((Operators.CompareString(DeclaracoesGeral.ConfLP.descricaoCompleta.Trim(), "", TextCompare: true) == 0) & (Operators.CompareString(DeclaracoesGeral.ConfLP.descricaoResumida.Trim(), "", TextCompare: true) != 0)))
						{
							if ((Operators.CompareString(DeclaracoesGeral.ConfLP.descricaoCompleta.Trim(), "", TextCompare: true) == 0) & (Operators.CompareString(DeclaracoesGeral.ConfLP.descricaoResumida.Trim(), "", TextCompare: true) == 0))
							{
								return;
							}
						}
						else
						{
							query = "SELECT " + DeclaracoesGeral.ConfLP.chavePrimaria + ", " + DeclaracoesGeral.ConfLP.enderecoFisico + ", " + DeclaracoesGeral.ConfLP.tipoDeSinal + ", " + DeclaracoesGeral.ConfLP.unidade + ", " + DeclaracoesGeral.ConfLP.descricaoResumida + ", " + DeclaracoesGeral.ConfLP.descricaoResumida + " FROM " + text + " WHERE " + DeclaracoesGeral.ConfLP.chavePrimaria + " IS NOT NULL";
						}
					}
					else
					{
						query = "SELECT " + DeclaracoesGeral.ConfLP.chavePrimaria + ", " + DeclaracoesGeral.ConfLP.enderecoFisico + ", " + DeclaracoesGeral.ConfLP.tipoDeSinal + ", " + DeclaracoesGeral.ConfLP.unidade + ", " + DeclaracoesGeral.ConfLP.descricaoCompleta + ", " + DeclaracoesGeral.ConfLP.descricaoCompleta + " FROM " + text + " WHERE " + DeclaracoesGeral.ConfLP.chavePrimaria + " IS NOT NULL";
					}
				}
				else
				{
					query = "SELECT " + DeclaracoesGeral.ConfLP.chavePrimaria + ", " + DeclaracoesGeral.ConfLP.enderecoFisico + ", " + DeclaracoesGeral.ConfLP.tipoDeSinal + ", " + DeclaracoesGeral.ConfLP.unidade + ", " + DeclaracoesGeral.ConfLP.descricaoResumida + ", " + DeclaracoesGeral.ConfLP.descricaoCompleta + " FROM " + text + " WHERE " + DeclaracoesGeral.ConfLP.chavePrimaria + " IS NOT NULL";
				}
				DataTable dataTable = db.ExecuteReader(query);
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					int num2 = Information.UBound(mPortas) + 1;
					mPortas = (PortaRelElektro[])Utils.CopyArray(mPortas, new PortaRelElektro[num2 + 1]);
					mPortas[num2].sChavePrimaria = "";
					mPortas[num2].sEfc = "";
					mPortas[num2].sTipo = "";
					mPortas[num2].sUnidade = "";
					mPortas[num2].sDescricaoC = "";
					mPortas[num2].sDescricaoR = "";
					int num3 = dataTable.Columns.Count - 1;
					for (int j = 0; j <= num3; j++)
					{
						string text2 = "";
						if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][j])))
						{
							text2 = dataTable.Rows[i][j].ToString().Trim();
						}
						string columnName = dataTable.Columns[j].ColumnName;
						if (Operators.CompareString(columnName, DeclaracoesGeral.ConfLP.chavePrimaria, TextCompare: true) != 0)
						{
							if (Operators.CompareString(columnName, DeclaracoesGeral.ConfLP.enderecoFisico, TextCompare: true) != 0)
							{
								if (Operators.CompareString(columnName, DeclaracoesGeral.ConfLP.tipoDeSinal, TextCompare: true) != 0)
								{
									if (Operators.CompareString(columnName, DeclaracoesGeral.ConfLP.unidade, TextCompare: true) != 0)
									{
										if (Operators.CompareString(columnName, DeclaracoesGeral.ConfLP.descricaoResumida, TextCompare: true) != 0)
										{
											if (Operators.CompareString(columnName, DeclaracoesGeral.ConfLP.descricaoCompleta, TextCompare: true) == 0)
											{
												mPortas[num2].sDescricaoC = text2.Replace("\n", " ");
											}
										}
										else
										{
											mPortas[num2].sDescricaoR = text2.Replace("\n", " ");
										}
									}
									else
									{
										mPortas[num2].sUnidade = text2;
									}
								}
								else
								{
									mPortas[num2].sTipo = text2;
								}
							}
							else
							{
								mPortas[num2].sEfc = text2;
							}
						}
						else
						{
							mPortas[num2].sChavePrimaria = text2;
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

	public void exportaPaginasPosFuncional(ref PortaExportada[] mPortas)
	{
		try
		{
			db.UpdateConectadoPosFuncional(ref mPortas);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public void CarregaColunasDaWS(ref string[] mColunas, string ws)
	{
		checked
		{
			try
			{
				DataTable dataTable = db.ExecuteReaderCOLS(ws + "$");
				string text = "";
				if (dataTable.Rows.Count <= 0)
				{
					dataTable = db.ExecuteReaderCOLS("'" + ws + "$'");
					{
						foreach (DataRow row in dataTable.Rows)
						{
							text = row["COLUMN_NAME"].ToString();
							if (Operators.CompareString(text.Trim(), text.Replace(" ", "").Trim(), TextCompare: true) != 0)
							{
								Interaction.MsgBox(Operators.ConcatenateObject(text + " ", DeclaracoesGeral.mMensagem[1, 1675]), MsgBoxStyle.Information, "Elétron");
								continue;
							}
							mColunas = (string[])Utils.CopyArray(mColunas, new string[Information.UBound(mColunas) + 1 + 1]);
							mColunas[Information.UBound(mColunas)] = text;
						}
						return;
					}
				}
				foreach (DataRow row2 in dataTable.Rows)
				{
					text = row2["COLUMN_NAME"].ToString();
					if (Operators.CompareString(text.Trim(), text.Replace(" ", "").Trim(), TextCompare: true) != 0)
					{
						Interaction.MsgBox(Operators.ConcatenateObject(text + " ", DeclaracoesGeral.mMensagem[1, 1675]), MsgBoxStyle.Information, "Elétron");
						continue;
					}
					mColunas = (string[])Utils.CopyArray(mColunas, new string[Information.UBound(mColunas) + 1 + 1]);
					mColunas[Information.UBound(mColunas)] = text;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void leWorkSheets(ref string[] mWS)
	{
		checked
		{
			try
			{
				DataTable dataTable = db.ExecuteReaderWS();
				string text = "";
				foreach (DataRow row in dataTable.Rows)
				{
					text = row["TABLE_NAME"].ToString();
					if (!text.EndsWith("$"))
					{
						if (text.EndsWith("$'"))
						{
							mWS = (string[])Utils.CopyArray(mWS, new string[Information.UBound(mWS) + 1 + 1]);
							string str = text.Substring(0, text.Length - 2);
							mWS[Information.UBound(mWS)] = Strings.Mid(str, 2);
						}
					}
					else
					{
						mWS = (string[])Utils.CopyArray(mWS, new string[Information.UBound(mWS) + 1 + 1]);
						mWS[Information.UBound(mWS)] = text.Substring(0, text.Length - 1);
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

	public void BuscaEFCDescricao(ref DeclaracoesFiacao.structurePortasTAF[] mPortas)
	{
		string text = "[" + DeclaracoesGeral.ConfLP.worksheet + "$]";
		checked
		{
			try
			{
				string query = "SELECT " + DeclaracoesGeral.ConfLP.chavePrimaria + ", " + DeclaracoesGeral.ConfLP.enderecoFisico + ", " + DeclaracoesGeral.ConfLP.descricaoResumida + ", " + DeclaracoesGeral.ConfLP.tipoDeSinal + ", " + DeclaracoesGeral.ConfLP.funcaoPorta + " FROM " + text + " WHERE " + DeclaracoesGeral.ConfLP.chavePrimaria + " IS NOT NULL";
				DataTable dataTable = db.ExecuteReader(query);
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					string right = "";
					string eFC = "";
					string descricao = "";
					string tipoSinal = "";
					string funcao = "";
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][0])))
					{
						right = dataTable.Rows[i][0].ToString().Trim();
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][1])))
					{
						eFC = dataTable.Rows[i][1].ToString().Trim();
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][2])))
					{
						descricao = dataTable.Rows[i][2].ToString().Trim();
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][3])))
					{
						tipoSinal = dataTable.Rows[i][3].ToString().Trim();
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[i][4])))
					{
						funcao = dataTable.Rows[i][4].ToString().Trim();
					}
					int num2 = Information.UBound(mPortas);
					for (int j = 1; j <= num2; j++)
					{
						if (Operators.CompareString(mPortas[j].ChavePrimaria, right, TextCompare: true) == 0)
						{
							mPortas[j].EFC = eFC;
							mPortas[j].Descricao = descricao;
							mPortas[j].TipoSinal = tipoSinal;
							mPortas[j].Funcao = funcao;
							break;
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
}
