using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class AcessoAccess
{
	private OleDbConnection SWu2oxCG7;

	private OleDbCommand VQe380QVs;

	public void fechaConexao()
	{
		checked
		{
			if (SWu2oxCG7.State == ConnectionState.Open)
			{
				VQe380QVs.Dispose();
				VQe380QVs = null;
				SWu2oxCG7.Close();
				SWu2oxCG7.Dispose();
				SWu2oxCG7 = null;
				DeclaracoesGeral.monitorConexao--;
				DeclaracoesGeral._uscPagina.statusBanco(Conversions.ToString(DeclaracoesGeral.monitorConexao));
			}
		}
	}

	public AcessoAccess()
	{
		SWu2oxCG7 = new OleDbConnection();
		VQe380QVs = new OleDbCommand();
		try
		{
			if (Operators.CompareString(DeclaracoesGeral.mdac, "0", TextCompare: true) == 0)
			{
				DeclaracoesGeral.mdac = i3CeWxHkQ();
			}
			if (Operators.CompareString(DeclaracoesGeral.Conf.DirProjeto, "", TextCompare: true) == 0)
			{
				new frmConfiguracaoBDProjeto();
				return;
			}
			if (!File.Exists(DeclaracoesGeral.Conf.DirProjeto))
			{
				new frmConfiguracaoBDProjeto();
				return;
			}
			OleDbConnectionStringBuilder oleDbConnectionStringBuilder = new OleDbConnectionStringBuilder();
			if (Operators.CompareString(DeclaracoesGeral.mdac, "2016", TextCompare: true) != 0)
			{
				if (Operators.CompareString(DeclaracoesGeral.mdac, "2010", TextCompare: true) != 0)
				{
					throw new Exception("MDAC 2016 não está instalado. Feche o AutoCAD e instale o MDAC 2016.");
				}
				oleDbConnectionStringBuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
			}
			else
			{
				oleDbConnectionStringBuilder.Provider = "Microsoft.ACE.OLEDB.16.0";
			}
			oleDbConnectionStringBuilder.DataSource = DeclaracoesGeral.Conf.DirProjeto.Trim();
			SWu2oxCG7.ConnectionString = oleDbConnectionStringBuilder.ConnectionString;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
			VQe380QVs.Connection = SWu2oxCG7;
		}
	}

	private string i3CeWxHkQ()
	{
		string result = "0";
		string[] array = new string[2]
		{
			"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=" + DeclaracoesGeral.Conf.DirProjeto.Trim(),
			"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + DeclaracoesGeral.Conf.DirProjeto.Trim()
		};
		bool flag = false;
		int num = 0;
		do
		{
			try
			{
				OleDbConnection oleDbConnection = new OleDbConnection(array[num]);
				oleDbConnection.Open();
				oleDbConnection.Close();
				switch (num)
				{
				case 0:
					result = "2016";
					break;
				case 1:
					result = "2010";
					break;
				}
				flag = true;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			if (flag)
			{
				break;
			}
			num = checked(num + 1);
		}
		while (num <= 1);
		return result;
	}

	public int ExecuteScalar(string query)
	{
		VQe380QVs.CommandType = CommandType.Text;
		VQe380QVs.CommandText = query;
		int result = 0;
		checked
		{
			try
			{
				if (SWu2oxCG7.State == ConnectionState.Closed)
				{
					SWu2oxCG7.Open();
					DeclaracoesGeral.monitorConexao++;
					DeclaracoesGeral._uscPagina.statusBanco(Conversions.ToString(DeclaracoesGeral.monitorConexao));
				}
				result = Conversions.ToInteger(VQe380QVs.ExecuteScalar());
			}
			catch (OleDbException ex)
			{
				ProjectData.SetProjectError(ex);
				OleDbException ex2 = ex;
				string prompt = "Access Error: " + ex2.Message + " / " + query;
				Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
				throw;
			}
			catch (InvalidOperationException ex3)
			{
				ProjectData.SetProjectError(ex3);
				InvalidOperationException ex4 = ex3;
				string prompt2 = "Access Error: " + ex4.Message + " / " + query;
				Interaction.MsgBox(prompt2, MsgBoxStyle.Critical);
				throw;
			}
			finally
			{
				VQe380QVs.Parameters.Clear();
			}
			return result;
		}
	}

	public void ExecuteNonQuery(string query, bool bMsg = true)
	{
		VQe380QVs.CommandType = CommandType.Text;
		VQe380QVs.CommandText = query;
		checked
		{
			try
			{
				if (SWu2oxCG7.State == ConnectionState.Closed)
				{
					SWu2oxCG7.Open();
					DeclaracoesGeral.monitorConexao++;
					DeclaracoesGeral._uscPagina.statusBanco(Conversions.ToString(DeclaracoesGeral.monitorConexao));
				}
				VQe380QVs.ExecuteNonQuery();
			}
			catch (OleDbException ex)
			{
				ProjectData.SetProjectError(ex);
				OleDbException ex2 = ex;
				if (bMsg)
				{
					string prompt = "Access Error: " + ex2.Message + " / " + query;
					Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
				}
				throw;
			}
			catch (InvalidOperationException ex3)
			{
				ProjectData.SetProjectError(ex3);
				InvalidOperationException ex4 = ex3;
				if (bMsg)
				{
					string prompt2 = "Access Error: " + ex4.Message + " / " + query;
					Interaction.MsgBox(prompt2, MsgBoxStyle.Critical);
				}
				throw;
			}
			finally
			{
				VQe380QVs.Parameters.Clear();
			}
		}
	}

	public DataTable ExecuteReader(string query)
	{
		VQe380QVs.CommandText = query;
		VQe380QVs.CommandType = CommandType.Text;
		DataTable dataTable = new DataTable();
		checked
		{
			try
			{
				if (SWu2oxCG7.State == ConnectionState.Closed)
				{
					SWu2oxCG7.Open();
					DeclaracoesGeral.monitorConexao++;
					DeclaracoesGeral._uscPagina.statusBanco(Conversions.ToString(DeclaracoesGeral.monitorConexao));
				}
				OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(VQe380QVs);
				oleDbDataAdapter.Fill(dataTable);
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Columns.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (Operators.CompareString(dataTable.Columns[i].DataType.Name, "String", TextCompare: true) != 0)
						{
							continue;
						}
						int num2 = dataTable.Rows.Count - 1;
						for (int j = 0; j <= num2; j++)
						{
							if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[j][i])))
							{
								dataTable.Rows[j][i] = "";
							}
							dataTable.Rows[j][i] = Strings.Trim(Conversions.ToString(dataTable.Rows[j][i]));
						}
					}
				}
				oleDbDataAdapter.Dispose();
			}
			catch (OleDbException ex)
			{
				ProjectData.SetProjectError(ex);
				OleDbException ex2 = ex;
				string prompt = "Access Error: " + ex2.Message + " / " + query;
				Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
				throw;
			}
			catch (InvalidOperationException ex3)
			{
				ProjectData.SetProjectError(ex3);
				InvalidOperationException ex4 = ex3;
				string prompt2 = "Access Error: " + ex4.Message + " / " + query;
				Interaction.MsgBox(prompt2, MsgBoxStyle.Critical);
				throw;
			}
			finally
			{
				VQe380QVs.Parameters.Clear();
			}
			return dataTable;
		}
	}

	public bool ExecuteQuery(string query)
	{
		VQe380QVs.CommandType = CommandType.Text;
		VQe380QVs.CommandText = query;
		checked
		{
			try
			{
				if (SWu2oxCG7.State == ConnectionState.Closed)
				{
					SWu2oxCG7.Open();
					DeclaracoesGeral.monitorConexao++;
					DeclaracoesGeral._uscPagina.statusBanco(Conversions.ToString(DeclaracoesGeral.monitorConexao));
				}
				OleDbDataReader oleDbDataReader = VQe380QVs.ExecuteReader();
				bool result = (oleDbDataReader.HasRows ? true : false);
				oleDbDataReader.Close();
				return result;
			}
			catch (OleDbException ex)
			{
				ProjectData.SetProjectError(ex);
				OleDbException ex2 = ex;
				string prompt = "Access Error: " + ex2.Message + " / " + query;
				Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
				throw;
			}
			catch (InvalidOperationException ex3)
			{
				ProjectData.SetProjectError(ex3);
				InvalidOperationException ex4 = ex3;
				string prompt2 = "Access Error: " + ex4.Message + " / " + query;
				Interaction.MsgBox(prompt2, MsgBoxStyle.Critical);
				throw;
			}
			finally
			{
				VQe380QVs.Parameters.Clear();
			}
		}
	}

	public string Schema()
	{
		string result = "";
		checked
		{
			try
			{
				if (SWu2oxCG7.State == ConnectionState.Closed)
				{
					SWu2oxCG7.Open();
					DeclaracoesGeral.monitorConexao++;
					DeclaracoesGeral._uscPagina.statusBanco(Conversions.ToString(DeclaracoesGeral.monitorConexao));
				}
				DataTable oleDbSchemaTable = SWu2oxCG7.GetOleDbSchemaTable(OleDbSchemaGuid.Primary_Keys, new object[3] { null, null, "Materiais" });
				if (oleDbSchemaTable.Rows.Count > 0)
				{
					result = Conversions.ToString(oleDbSchemaTable.Rows[0][7]);
				}
			}
			catch (OleDbException ex)
			{
				ProjectData.SetProjectError(ex);
				OleDbException ex2 = ex;
				string prompt = "Access Error: " + ex2.Message;
				Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
				throw;
			}
			catch (InvalidOperationException ex3)
			{
				ProjectData.SetProjectError(ex3);
				InvalidOperationException ex4 = ex3;
				string prompt2 = "Access Error: " + ex4.Message;
				Interaction.MsgBox(prompt2, MsgBoxStyle.Critical);
				throw;
			}
			finally
			{
			}
			return result;
		}
	}

	public bool ExisteTabela(string tabela)
	{
		bool result = false;
		checked
		{
			try
			{
				if (SWu2oxCG7.State == ConnectionState.Closed)
				{
					SWu2oxCG7.Open();
					DeclaracoesGeral.monitorConexao++;
					DeclaracoesGeral._uscPagina.statusBanco(Conversions.ToString(DeclaracoesGeral.monitorConexao));
				}
				DataTable oleDbSchemaTable = SWu2oxCG7.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[4] { null, null, tabela, "TABLE" });
				if (oleDbSchemaTable.Rows.Count > 0)
				{
					result = true;
				}
			}
			catch (OleDbException ex)
			{
				ProjectData.SetProjectError(ex);
				OleDbException ex2 = ex;
				string prompt = "Access Error: " + ex2.Message;
				Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
				throw;
			}
			catch (InvalidOperationException ex3)
			{
				ProjectData.SetProjectError(ex3);
				InvalidOperationException ex4 = ex3;
				string prompt2 = "Access Error: " + ex4.Message;
				Interaction.MsgBox(prompt2, MsgBoxStyle.Critical);
				throw;
			}
			finally
			{
			}
			return result;
		}
	}

	public bool ExisteColuna(string tblName, string fldName)
	{
		bool flag = false;
		try
		{
			if (SWu2oxCG7.State == ConnectionState.Closed)
			{
				SWu2oxCG7.Open();
			}
			DataTable dataTable = new DataTable();
			string selectCommandText = "Select TOP 1 * from " + tblName;
			OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(selectCommandText, SWu2oxCG7);
			oleDbDataAdapter.Fill(dataTable);
			int num = dataTable.Columns.IndexOf(fldName);
			if (num != -1)
			{
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw ex2;
		}
	}

	public void AddParameter(string name, object value, OleDbType tipo)
	{
		VQe380QVs.Parameters.Add(name, tipo);
		VQe380QVs.Parameters[name].Value = RuntimeHelpers.GetObjectValue(value);
	}
}
