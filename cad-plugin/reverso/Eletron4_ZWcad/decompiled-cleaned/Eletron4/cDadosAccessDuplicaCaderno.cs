using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class cDadosAccessDuplicaCaderno
{
	public object db;

	public void fechaConexao()
	{
		NewLateBinding.LateCall(db, null, "fechaConexao", new object[0], null, null, null, IgnoreReturn: true);
	}

	public cDadosAccessDuplicaCaderno()
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

	public void CopiaFiacao(int IndiceOriginal, int IndiceNovo)
	{
		checked
		{
			try
			{
				string text = Environment.UserName;
				DateTime dateTime = Conversions.ToDate(DateTime.Now.ToString());
				string text2 = "SELECT Revisao, DWG, Painel, Potencial, Ordem, Pagina, Tag, Alternativo, NRegua, Terminal, TerminalNum, Tipo, Secao, Cor, PosicaoNum, TipoBorne, BJumper, BLink, Handle, IndexModelo, Aplicacao, Orientacao, Criador, Data FROM Fiacao WHERE DWG=@dwg";
				object instance = db;
				object[] array = new object[3]
				{
					"@dwg",
					IndiceOriginal,
					OleDbType.Integer
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				IndiceOriginal = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance2 = db;
				object[] array3 = new object[1] { text2 };
				array2 = array3;
				object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
				text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						text2 = "Insert into Fiacao(Revisao, DWG, Painel, Potencial, Ordem, Pagina, Tag, Alternativo, NRegua, Terminal, TerminalNum, Tipo, Secao, Cor, PosicaoNum, TipoBorne, BJumper, BLink, Handle, IndexModelo, Aplicacao, Orientacao, Criador, Data) VALUES(@revisao, @dwg, @painel, @potencial, @ordem, @pagina, @tag, @alternativo, @nregua, @terminal, @terminalNum, @tipo, @secao, @cor, @posicaoNum, @tipoBorne, @bJumper, @bLink, @handle, @indexModelo, @aplicacao, @Orientacao, @criador, @data)";
						DataRow dataRow;
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@revisao",
							(dataRow = dataTable.Rows[i])[0],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[0] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@dwg",
							IndiceNovo,
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						IndiceNovo = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@painel",
							(dataRow = dataTable.Rows[i])[2],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[2] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@potencial",
							(dataRow = dataTable.Rows[i])[3],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[3] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@ordem",
							(dataRow = dataTable.Rows[i])[4],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[4] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@pagina",
							(dataRow = dataTable.Rows[i])[5],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[5] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@tag",
							(dataRow = dataTable.Rows[i])[6],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[6] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@alternativo",
							(dataRow = dataTable.Rows[i])[7],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[7] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@nregua",
							(dataRow = dataTable.Rows[i])[8],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[8] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@terminal",
							(dataRow = dataTable.Rows[i])[9],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[9] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@terminalNum",
							(dataRow = dataTable.Rows[i])[10],
							OleDbType.Double
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[10] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@tipo",
							(dataRow = dataTable.Rows[i])[11],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[11] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@secao",
							(dataRow = dataTable.Rows[i])[12],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[12] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@cor",
							(dataRow = dataTable.Rows[i])[13],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[13] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@posicaoNum",
							(dataRow = dataTable.Rows[i])[14],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[14] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@tipoBorne",
							(dataRow = dataTable.Rows[i])[15],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[15] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@bJumper",
							(dataRow = dataTable.Rows[i])[16],
							OleDbType.Boolean
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[16] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@bLink",
							(dataRow = dataTable.Rows[i])[17],
							OleDbType.Boolean
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[17] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@handle",
							(dataRow = dataTable.Rows[i])[18],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[18] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@indexModelo",
							(dataRow = dataTable.Rows[i])[19],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[19] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@aplicacao",
							(dataRow = dataTable.Rows[i])[20],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[20] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@Orientacao",
							(dataRow = dataTable.Rows[i])[21],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[21] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@criador",
							text,
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(string));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@data",
							dateTime,
							OleDbType.Date
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dateTime = (DateTime)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(DateTime));
						NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text2 }, null, null, new bool[1] { true }, IgnoreReturn: true);
						text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void CopiaContatos4F(int IndiceOriginal, int IndiceNovo)
	{
		checked
		{
			try
			{
				string text = "SELECT Revisao, DWG, IndexModelo, NomeModelo, Terminal, TerminalNum, Orientacao FROM Contatos4F WHERE DWG=@dwg";
				object instance = db;
				object[] array = new object[3]
				{
					"@dwg",
					IndiceOriginal,
					OleDbType.Integer
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				IndiceOriginal = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				_ = Environment.UserName;
				Conversions.ToDate(DateTime.Now.ToString());
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
						text = "Insert into Contatos4F(Revisao, DWG, indexModelo, NomeModelo, Terminal, TerminalNum, Orientacao) VALUES(@revisao, @dwg, @indexmodelo, @nomemodelo, @terminal, @terminalNum, @orientacao)";
						DataRow dataRow;
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@revisao",
							(dataRow = dataTable.Rows[i])[0],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[0] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@dwg",
							IndiceNovo,
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						IndiceNovo = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@indexmodelo",
							(dataRow = dataTable.Rows[i])[2],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[2] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@nomemodelo",
							(dataRow = dataTable.Rows[i])[3],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[3] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@terminal",
							(dataRow = dataTable.Rows[i])[4],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[4] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@terminalNum",
							(dataRow = dataTable.Rows[i])[5],
							OleDbType.Double
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[5] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@orientacao",
							(dataRow = dataTable.Rows[i])[6],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[6] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
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
	}

	public void CopiaCircuitos4F(int IndiceOriginal, int IndiceNovo)
	{
		checked
		{
			try
			{
				string text = "SELECT Revisao, DWG, Painel, Circuito, Potencial FROM Circuitos4F WHERE DWG=@dwg";
				object instance = db;
				object[] array = new object[3]
				{
					"@dwg",
					IndiceOriginal,
					OleDbType.Integer
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				IndiceOriginal = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				_ = Environment.UserName;
				Conversions.ToDate(DateTime.Now.ToString());
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
						text = "Insert into Circuitos4F( Revisao, DWG, Painel, Circuito, Potencial) VALUES(@revisao, @dwg, @painel, @circuito, @potencial)";
						DataRow dataRow;
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@revisao",
							(dataRow = dataTable.Rows[i])[0],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[0] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@dwg",
							IndiceNovo,
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						IndiceNovo = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@painel",
							(dataRow = dataTable.Rows[i])[2],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[2] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@circuito",
							(dataRow = dataTable.Rows[i])[3],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[3] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@potencial",
							(dataRow = dataTable.Rows[i])[4],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[4] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
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
	}

	public void CopiaPortas4F(int IndiceOriginal, int IndiceNovo)
	{
		checked
		{
			try
			{
				string text = "SELECT Revisao, DWG, IndexModelo, NomeModelo, Regua, Borne, Terminal, TerminalNum, Tipo, Orientacao FROM Portas4F WHERE DWG=@dwg";
				object instance = db;
				object[] array = new object[3]
				{
					"@dwg",
					IndiceOriginal,
					OleDbType.Integer
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				IndiceOriginal = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				_ = Environment.UserName;
				Conversions.ToDate(DateTime.Now.ToString());
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
						text = "Insert into Portas4F(Revisao, DWG, indexModelo, NomeModelo, Regua, Borne, Terminal, TerminalNum, Tipo, Orientacao) VALUES(@revisao, @dwg, @indexmodelo, @nomemodelo, @regua, @borne, @terminal, @terminalNum, @tipo, @orientacao)";
						DataRow dataRow;
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@revisao",
							(dataRow = dataTable.Rows[i])[0],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[0] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@dwg",
							IndiceNovo,
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						IndiceNovo = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@indexmodelo",
							(dataRow = dataTable.Rows[i])[2],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[2] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@nomemodelo",
							(dataRow = dataTable.Rows[i])[3],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[3] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@regua",
							(dataRow = dataTable.Rows[i])[4],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[4] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@borne",
							(dataRow = dataTable.Rows[i])[5],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[5] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@terminal",
							(dataRow = dataTable.Rows[i])[6],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[6] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@terminalNum",
							(dataRow = dataTable.Rows[i])[7],
							OleDbType.Double
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[7] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@tipo",
							(dataRow = dataTable.Rows[i])[8],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[8] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@orientacao",
							(dataRow = dataTable.Rows[i])[9],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[9] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
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
	}

	public void CopiaDispositivos4F(int IndiceOriginal, int IndiceNovo)
	{
		checked
		{
			try
			{
				string text = "";
				text = "SELECT Revisao, DWG, Painel, Tag, Alternativo, Tipo, Handle, Pagina, BlocoTopografico, BlocoLayout, PosicaoNum, Ordem FROM Dispositivos4F WHERE DWG=@dwg";
				object instance = db;
				object[] array = new object[3]
				{
					"@dwg",
					IndiceOriginal,
					OleDbType.Integer
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				IndiceOriginal = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
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
						text = "Insert into Dispositivos4F(Revisao, DWG, Painel, Tag, Alternativo, Tipo, Handle, Pagina, BlocoTopografico, BlocoLayout, PosicaoNum, Ordem) VALUES(@revisao, @dwg, @painel, @tag, @alternativo, @tipo, @handle, @pagina, @blocotopografico, @blocolayout, @posicaonum, @ordem)";
						DataRow dataRow;
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@revisao",
							(dataRow = dataTable.Rows[i])[0],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[0] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@dwg",
							IndiceNovo,
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						IndiceNovo = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@painel",
							(dataRow = dataTable.Rows[i])[2],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[2] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@tag",
							(dataRow = dataTable.Rows[i])[3],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[3] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@alternativo",
							(dataRow = dataTable.Rows[i])[4],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[4] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@tipo",
							(dataRow = dataTable.Rows[i])[5],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[5] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@handle",
							(dataRow = dataTable.Rows[i])[6],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[6] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@pagina",
							(dataRow = dataTable.Rows[i])[7],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[7] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@blocotopografico",
							(dataRow = dataTable.Rows[i])[8],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[8] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@blocolayout",
							(dataRow = dataTable.Rows[i])[9],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[9] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@posicaonum",
							(dataRow = dataTable.Rows[i])[10],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[10] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@ordem",
							(dataRow = dataTable.Rows[i])[11],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[11] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
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
	}

	public void CopiaBornes4F(int IndiceOriginal, int IndiceNovo)
	{
		checked
		{
			try
			{
				string text = "SELECT Revisao, DWG, Painel, IndexRegua, Regua, Alternativo, Handle, Borne, Ordem, Tipo, Pagina, bReserva, LM, Orientacao, BlocoLayout FROM Bornes4F WHERE DWG=@dwg";
				object instance = db;
				object[] array = new object[3]
				{
					"@dwg",
					IndiceOriginal,
					OleDbType.Integer
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				IndiceOriginal = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
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
						text = "Insert into Bornes4F(Revisao, DWG, Painel, IndexRegua, Regua, Alternativo, Handle, Borne, Ordem, Tipo, Pagina, bReserva, LM, Orientacao, BlocoLayout) VALUES(@revisao, @dwg, @painel, @indexRegua, @regua, @alternativo, @handle, @borne, @ordem, @tipo, @pagina, @reserva, @LM, @orientacao, @blocoLayout)";
						DataRow dataRow;
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@revisao",
							(dataRow = dataTable.Rows[i])[0],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[0] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@dwg",
							IndiceNovo,
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						IndiceNovo = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@painel",
							(dataRow = dataTable.Rows[i])[2],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[2] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@indexRegua",
							(dataRow = dataTable.Rows[i])[3],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[3] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@regua",
							(dataRow = dataTable.Rows[i])[4],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[4] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@alternativo",
							(dataRow = dataTable.Rows[i])[5],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[5] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@handle",
							(dataRow = dataTable.Rows[i])[6],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[6] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@borne",
							(dataRow = dataTable.Rows[i])[7],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[7] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@ordem",
							(dataRow = dataTable.Rows[i])[8],
							OleDbType.Double
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[8] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@tipo",
							(dataRow = dataTable.Rows[i])[9],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[9] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@pagina",
							(dataRow = dataTable.Rows[i])[10],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[10] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@reserva",
							(dataRow = dataTable.Rows[i])[11],
							OleDbType.Boolean
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[11] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@LM",
							(dataRow = dataTable.Rows[i])[12],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[12] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@orientacao",
							(dataRow = dataTable.Rows[i])[13],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[13] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@blocoLayout",
							(dataRow = dataTable.Rows[i])[14],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[14] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
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
	}

	public void CopiaJumpers(int IndiceOriginal, int IndiceNovo)
	{
		checked
		{
			try
			{
				string text = "SELECT Revisao, DWG, Painel, Potencial, Ordem, Pagina, Tag, Alternativo, NRegua, Terminal, TerminalNum, Tipo, Secao, Cor, PosicaoNum, TipoBorne, BJumper, BLink, Handle, IndexModelo FROM Jumper4 WHERE DWG=@dwg";
				object instance = db;
				object[] array = new object[3]
				{
					"@dwg",
					IndiceOriginal,
					OleDbType.Integer
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				IndiceOriginal = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				string text2 = Environment.UserName;
				DateTime dateTime = Conversions.ToDate(DateTime.Now.ToString());
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
						text = "Insert into Jumper4(Revisao, DWG, Painel, Potencial, Ordem, Pagina, Tag, Alternativo, NRegua, Terminal, TerminalNum, Tipo, Secao, Cor, PosicaoNum, TipoBorne, BJumper, BLink, Handle, IndexModelo, Criador, Data) VALUES(@revisao, @dwg, @painel, @potencial, @ordem, @pagina, @tag, @alternativo, @nregua, @terminal, @terminalNum, @tipo, @secao, @cor, @posicaoNum, @tipoBorne, @bJumper, @bLink, @handle, @indexModelo, @criador, @data)";
						DataRow dataRow;
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@revisao",
							(dataRow = dataTable.Rows[i])[0],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[0] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@dwg",
							IndiceNovo,
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						IndiceNovo = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@painel",
							(dataRow = dataTable.Rows[i])[2],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[2] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@potencial",
							(dataRow = dataTable.Rows[i])[3],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[3] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@ordem",
							(dataRow = dataTable.Rows[i])[4],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[4] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@pagina",
							(dataRow = dataTable.Rows[i])[5],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[5] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@tag",
							(dataRow = dataTable.Rows[i])[6],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[6] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@alternativo",
							(dataRow = dataTable.Rows[i])[7],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[7] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@nregua",
							(dataRow = dataTable.Rows[i])[8],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[8] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@terminal",
							(dataRow = dataTable.Rows[i])[9],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[9] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@terminalNum",
							(dataRow = dataTable.Rows[i])[10],
							OleDbType.Double
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[10] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@tipo",
							(dataRow = dataTable.Rows[i])[11],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[11] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@secao",
							(dataRow = dataTable.Rows[i])[12],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[12] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@cor",
							(dataRow = dataTable.Rows[i])[13],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[13] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@posicaoNum",
							(dataRow = dataTable.Rows[i])[14],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[14] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@tipoBorne",
							(dataRow = dataTable.Rows[i])[15],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[15] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@bJumper",
							(dataRow = dataTable.Rows[i])[16],
							OleDbType.Boolean
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[16] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@bLink",
							(dataRow = dataTable.Rows[i])[17],
							OleDbType.Boolean
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[17] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@handle",
							(dataRow = dataTable.Rows[i])[18],
							OleDbType.Char
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[18] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@indexModelo",
							(dataRow = dataTable.Rows[i])[19],
							OleDbType.Integer
						}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
						dataRow[19] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array2[1]));
						NewLateBinding.LateCall(db, null, "AddParameter", array2 = new object[3]
						{
							"@criador",
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
						NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array2 = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
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
	}

	public void BuscaIndicesFiacao(int iDWG, int iPainel, ref List<int> lDisp, ref List<int> lMasc)
	{
		checked
		{
			try
			{
				string text = "SELECT Tipo, IndexModelo FROM Fiacao WHERE DWG=@dwg and Painel=@painel";
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
					iPainel,
					OleDbType.Integer
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				iPainel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance3 = db;
				object[] array4 = new object[1] { text };
				array2 = array4;
				object obj = NewLateBinding.LateGet(instance3, null, "ExecuteReader", array4, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count <= 0)
				{
					return;
				}
				int num = dataTable.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (!Operators.ConditionalCompareObjectGreater(dataTable.Rows[i][1], 0, TextCompare: true))
					{
						continue;
					}
					object left = dataTable.Rows[i][0];
					if (!Conversions.ToBoolean(Conversions.ToBoolean(Operators.CompareObjectEqual(left, "A", TextCompare: true)) || Conversions.ToBoolean(Operators.CompareObjectEqual(left, "P", TextCompare: true))))
					{
						if (Operators.ConditionalCompareObjectEqual(left, "E", TextCompare: true) && !lMasc.Contains(Conversions.ToInteger(dataTable.Rows[i][1])))
						{
							lMasc.Add(Conversions.ToInteger(dataTable.Rows[i][1]));
						}
					}
					else if (!lDisp.Contains(Conversions.ToInteger(dataTable.Rows[i][1])))
					{
						lDisp.Add(Conversions.ToInteger(dataTable.Rows[i][1]));
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void ApagaFiacao(int iPainel, int iDWG)
	{
		try
		{
			string text = "DELETE FROM Fiacao WHERE Painel=@painel and DWG=@dwg ";
			object instance = db;
			object[] array = new object[3]
			{
				"@painel",
				iPainel,
				OleDbType.Integer
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iPainel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@dwg",
				iDWG,
				OleDbType.Integer
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance3 = db;
			object[] array4 = new object[1] { text };
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "ExecuteNonQuery", array4, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void ApagaContatos4F(int Indice, int iDWG, List<int> lDisp)
	{
		checked
		{
			try
			{
				int num = lDisp.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					string text = "DELETE FROM Contatos4F WHERE indexModelo=@indexmodelo and DWG=@dwg";
					List<int> list;
					int index;
					object[] array;
					NewLateBinding.LateCall(db, null, "AddParameter", array = new object[3]
					{
						"@indexmodelo",
						(list = lDisp)[index = i],
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					list[index] = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "AddParameter", array = new object[3]
					{
						"@dwg",
						iDWG,
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void ApagaCircuitos4F(int iPainel, int iDWG)
	{
		try
		{
			string text = "DELETE FROM Circuitos4F WHERE Painel=@painel and DWG=@dwg ";
			object instance = db;
			object[] array = new object[3]
			{
				"@painel",
				iPainel,
				OleDbType.Integer
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iPainel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@dwg",
				iDWG,
				OleDbType.Integer
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance3 = db;
			object[] array4 = new object[1] { text };
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "ExecuteNonQuery", array4, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void ApagaPortas4F(int iPainel, int iDWG, List<int> lMasc)
	{
		checked
		{
			try
			{
				int num = lMasc.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					string text = "DELETE FROM Portas4F WHERE indexModelo=@indexmodelo and  DWG=@dwg";
					List<int> list;
					int index;
					object[] array;
					NewLateBinding.LateCall(db, null, "AddParameter", array = new object[3]
					{
						"@indexmodelo",
						(list = lMasc)[index = i],
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					list[index] = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "AddParameter", array = new object[3]
					{
						"@dwg",
						iDWG,
						OleDbType.Integer
					}, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
					iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
					NewLateBinding.LateCall(db, null, "ExecuteNonQuery", array = new object[1] { text }, null, null, new bool[1] { true }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void ApagaDispositivos4F(int iPainel, int iDWG)
	{
		try
		{
			string text = "DELETE FROM Dispositivos4F WHERE Painel=@painel and DWG=@dwg ";
			object instance = db;
			object[] array = new object[3]
			{
				"@painel",
				iPainel,
				OleDbType.Integer
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iPainel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@dwg",
				iDWG,
				OleDbType.Integer
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance3 = db;
			object[] array4 = new object[1] { text };
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "ExecuteNonQuery", array4, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void ApagaBornes4F(int iPainel, int iDWG)
	{
		try
		{
			string text = "DELETE FROM Bornes4F WHERE Painel=@painel and DWG=@dwg ";
			object instance = db;
			object[] array = new object[3]
			{
				"@painel",
				iPainel,
				OleDbType.Integer
			};
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iPainel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance2 = db;
			object[] array3 = new object[3]
			{
				"@dwg",
				iDWG,
				OleDbType.Integer
			};
			array2 = array3;
			NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
			iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
			object instance3 = db;
			object[] array4 = new object[1] { text };
			array2 = array4;
			NewLateBinding.LateCall(instance3, null, "ExecuteNonQuery", array4, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void ApagaVarios3(int iPainel, int iDWG)
	{
		try
		{
			string text = "";
			if (Conversions.ToBoolean(NewLateBinding.LateGet(db, null, "ExisteTabela", new object[1] { "Bornes4I" }, null, null, null)))
			{
				text = "DELETE FROM Bornes4I WHERE Painel=@painel and DWG=@dwg ";
				object instance = db;
				object[] array = new object[3]
				{
					"@painel",
					iPainel,
					OleDbType.Integer
				};
				object[] array2 = array;
				NewLateBinding.LateCall(instance, null, "AddParameter", array, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				iPainel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance2 = db;
				object[] array3 = new object[3]
				{
					"@dwg",
					iDWG,
					OleDbType.Integer
				};
				array2 = array3;
				NewLateBinding.LateCall(instance2, null, "AddParameter", array3, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance3 = db;
				object[] array4 = new object[1] { text };
				array2 = array4;
				NewLateBinding.LateCall(instance3, null, "ExecuteNonQuery", array4, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			if (Conversions.ToBoolean(NewLateBinding.LateGet(db, null, "ExisteTabela", new object[1] { "Interligacao4" }, null, null, null)))
			{
				text = "DELETE FROM Interligacao4 WHERE Painel1=@painel and DWG1=@dwg ";
				object instance4 = db;
				object[] array5 = new object[3]
				{
					"@painel",
					iPainel,
					OleDbType.Integer
				};
				object[] array2 = array5;
				NewLateBinding.LateCall(instance4, null, "AddParameter", array5, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				iPainel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance5 = db;
				object[] array6 = new object[3]
				{
					"@dwg",
					iDWG,
					OleDbType.Integer
				};
				array2 = array6;
				NewLateBinding.LateCall(instance5, null, "AddParameter", array6, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance6 = db;
				object[] array7 = new object[1] { text };
				array2 = array7;
				NewLateBinding.LateCall(instance6, null, "ExecuteNonQuery", array7, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			if (Conversions.ToBoolean(NewLateBinding.LateGet(db, null, "existeTabela", new object[1] { "Interligacao4" }, null, null, null)))
			{
				text = "DELETE FROM Interligacao4 WHERE Painel2=@painel and DWG2=@dwg ";
				object instance7 = db;
				object[] array8 = new object[3]
				{
					"@painel",
					iPainel,
					OleDbType.Integer
				};
				object[] array2 = array8;
				NewLateBinding.LateCall(instance7, null, "AddParameter", array8, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				iPainel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
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
				object[] array10 = new object[1] { text };
				array2 = array10;
				NewLateBinding.LateCall(instance9, null, "ExecuteNonQuery", array10, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			if (Conversions.ToBoolean(NewLateBinding.LateGet(db, null, "existeTabela", new object[1] { "Jumper4" }, null, null, null)))
			{
				text = "DELETE FROM Jumper4 WHERE Painel=@painel and DWG=@dwg ";
				object instance10 = db;
				object[] array11 = new object[3]
				{
					"@painel",
					iPainel,
					OleDbType.Integer
				};
				object[] array2 = array11;
				NewLateBinding.LateCall(instance10, null, "AddParameter", array11, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				iPainel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance11 = db;
				object[] array12 = new object[3]
				{
					"@dwg",
					iDWG,
					OleDbType.Integer
				};
				array2 = array12;
				NewLateBinding.LateCall(instance11, null, "AddParameter", array12, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance12 = db;
				object[] array13 = new object[1] { text };
				array2 = array13;
				NewLateBinding.LateCall(instance12, null, "ExecuteNonQuery", array13, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			if (Conversions.ToBoolean(NewLateBinding.LateGet(db, null, "existeTabela", new object[1] { "ListaMateriais" }, null, null, null)))
			{
				text = "DELETE FROM ListaMateriais WHERE Painel=@painel and DWG=@dwg ";
				object instance13 = db;
				object[] array14 = new object[3]
				{
					"@painel",
					iPainel,
					OleDbType.Integer
				};
				object[] array2 = array14;
				NewLateBinding.LateCall(instance13, null, "AddParameter", array14, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				iPainel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance14 = db;
				object[] array15 = new object[3]
				{
					"@dwg",
					iDWG,
					OleDbType.Integer
				};
				array2 = array15;
				NewLateBinding.LateCall(instance14, null, "AddParameter", array15, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance15 = db;
				object[] array16 = new object[1] { text };
				array2 = array16;
				NewLateBinding.LateCall(instance15, null, "ExecuteNonQuery", array16, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			if (Conversions.ToBoolean(NewLateBinding.LateGet(db, null, "existeTabela", new object[1] { "Plaquetas4" }, null, null, null)))
			{
				text = "DELETE FROM Plaquetas4 WHERE Painel=@painel and DWG=@dwg ";
				object instance16 = db;
				object[] array17 = new object[3]
				{
					"@painel",
					iPainel,
					OleDbType.Integer
				};
				object[] array2 = array17;
				NewLateBinding.LateCall(instance16, null, "AddParameter", array17, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				iPainel = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance17 = db;
				object[] array18 = new object[3]
				{
					"@dwg",
					iDWG,
					OleDbType.Integer
				};
				array2 = array18;
				NewLateBinding.LateCall(instance17, null, "AddParameter", array18, null, null, new bool[3] { false, true, false }, IgnoreReturn: true);
				iDWG = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[1]), typeof(int));
				object instance18 = db;
				object[] array19 = new object[1] { text };
				array2 = array19;
				NewLateBinding.LateCall(instance18, null, "ExecuteNonQuery", array19, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}
}
