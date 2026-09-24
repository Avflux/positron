using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class AcessoSQLServer
{
	private SqlConnection EcsmpC3BC;

	private SqlCommand xHKXZTwmu;

	private SqlTransaction fPLUxqIrr;

	private bool Kaiy5RFjS;

	public void fechaConexao()
	{
		checked
		{
			if (EcsmpC3BC.State == ConnectionState.Open)
			{
				xHKXZTwmu.Dispose();
				xHKXZTwmu = null;
				if (Kaiy5RFjS)
				{
					fPLUxqIrr.Commit();
					fPLUxqIrr.Dispose();
				}
				EcsmpC3BC.Close();
				EcsmpC3BC.Dispose();
				EcsmpC3BC = null;
				DeclaracoesGeral.monitorConexao--;
				DeclaracoesGeral._uscPagina.statusBanco(Conversions.ToString(DeclaracoesGeral.monitorConexao));
			}
		}
	}

	public AcessoSQLServer(bool bTrans = true)
	{
		EcsmpC3BC = new SqlConnection();
		xHKXZTwmu = new SqlCommand();
		Kaiy5RFjS = true;
		Kaiy5RFjS = bTrans;
		try
		{
			SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
			{
				DataSource = DeclaracoesGeral.Conf.DataSource,
				IntegratedSecurity = false,
				UserID = DeclaracoesGeral.Conf.User,
				Password = DeclaracoesGeral.Conf.Senha,
				InitialCatalog = DeclaracoesGeral.Conf.BancoDeDados,
				Encrypt = true,
				PersistSecurityInfo = false,
				ConnectTimeout = 30,
				MultipleActiveResultSets = false,
				TrustServerCertificate = true
			};
			EcsmpC3BC.ConnectionString = sqlConnectionStringBuilder.ConnectionString;
			xHKXZTwmu.Connection = EcsmpC3BC;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public bool TestaConexao()
	{
		bool result = false;
		try
		{
			if (EcsmpC3BC.State == ConnectionState.Closed)
			{
				EcsmpC3BC.Open();
				result = true;
				EcsmpC3BC.Close();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		finally
		{
		}
		return result;
	}

	public int ExecuteScalar(string query)
	{
		xHKXZTwmu.CommandType = CommandType.Text;
		xHKXZTwmu.CommandText = query;
		int result = 0;
		checked
		{
			try
			{
				if (EcsmpC3BC.State == ConnectionState.Closed)
				{
					EcsmpC3BC.Open();
					DeclaracoesGeral.monitorConexao++;
					DeclaracoesGeral._uscPagina.statusBanco(Conversions.ToString(DeclaracoesGeral.monitorConexao));
					if (Kaiy5RFjS)
					{
						fPLUxqIrr = EcsmpC3BC.BeginTransaction();
					}
				}
				if (Kaiy5RFjS)
				{
					xHKXZTwmu.Transaction = fPLUxqIrr;
				}
				result = Conversions.ToInteger(xHKXZTwmu.ExecuteScalar());
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				string prompt = "Error: " + ex2.Message;
				Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
				if (Kaiy5RFjS)
				{
					fPLUxqIrr.Rollback();
				}
				throw;
			}
			finally
			{
				xHKXZTwmu.Parameters.Clear();
			}
			return result;
		}
	}

	public void ExecuteNonQuery(string query, bool bMsg = true)
	{
		xHKXZTwmu.CommandType = CommandType.Text;
		xHKXZTwmu.CommandText = query;
		checked
		{
			try
			{
				if (EcsmpC3BC.State == ConnectionState.Closed)
				{
					EcsmpC3BC.Open();
					DeclaracoesGeral.monitorConexao++;
					DeclaracoesGeral._uscPagina.statusBanco(Conversions.ToString(DeclaracoesGeral.monitorConexao));
					if (Kaiy5RFjS)
					{
						fPLUxqIrr = EcsmpC3BC.BeginTransaction();
					}
				}
				if (Kaiy5RFjS)
				{
					xHKXZTwmu.Transaction = fPLUxqIrr;
				}
				xHKXZTwmu.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				if (bMsg)
				{
					string prompt = "Error: " + ex2.Message;
					Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
				}
				if (Kaiy5RFjS)
				{
					fPLUxqIrr.Rollback();
				}
				throw;
			}
			finally
			{
				xHKXZTwmu.Parameters.Clear();
			}
		}
	}

	public DataTable ExecuteReader(string query)
	{
		xHKXZTwmu.CommandText = query;
		xHKXZTwmu.CommandType = CommandType.Text;
		DataTable dataTable = new DataTable();
		checked
		{
			try
			{
				if (EcsmpC3BC.State == ConnectionState.Closed)
				{
					EcsmpC3BC.Open();
					DeclaracoesGeral.monitorConexao++;
					DeclaracoesGeral._uscPagina.statusBanco(Conversions.ToString(DeclaracoesGeral.monitorConexao));
					if (Kaiy5RFjS)
					{
						fPLUxqIrr = EcsmpC3BC.BeginTransaction();
					}
				}
				if (Kaiy5RFjS)
				{
					xHKXZTwmu.Transaction = fPLUxqIrr;
				}
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(xHKXZTwmu);
				sqlDataAdapter.Fill(dataTable);
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
				sqlDataAdapter.Dispose();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				string prompt = "Error: " + ex2.Message;
				Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
				if (Kaiy5RFjS)
				{
					fPLUxqIrr.Rollback();
				}
				throw;
			}
			finally
			{
				xHKXZTwmu.Parameters.Clear();
			}
			return dataTable;
		}
	}

	public bool ExecuteQuery(string query)
	{
		xHKXZTwmu.CommandType = CommandType.Text;
		xHKXZTwmu.CommandText = query;
		checked
		{
			try
			{
				if (EcsmpC3BC.State == ConnectionState.Closed)
				{
					EcsmpC3BC.Open();
					DeclaracoesGeral.monitorConexao++;
					DeclaracoesGeral._uscPagina.statusBanco(Conversions.ToString(DeclaracoesGeral.monitorConexao));
					if (Kaiy5RFjS)
					{
						fPLUxqIrr = EcsmpC3BC.BeginTransaction();
					}
				}
				if (Kaiy5RFjS)
				{
					xHKXZTwmu.Transaction = fPLUxqIrr;
				}
				SqlDataReader sqlDataReader = xHKXZTwmu.ExecuteReader();
				bool result = (sqlDataReader.HasRows ? true : false);
				sqlDataReader.Close();
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				string prompt = "Error: " + ex2.Message;
				Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
				if (Kaiy5RFjS)
				{
					fPLUxqIrr.Rollback();
				}
				throw;
			}
			finally
			{
				xHKXZTwmu.Parameters.Clear();
			}
		}
	}

	public bool ExisteTabela(string tabela)
	{
		bool result = false;
		xHKXZTwmu.CommandType = CommandType.Text;
		xHKXZTwmu.CommandText = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @TableName AND TABLE_SCHEMA = @SchemaName";
		xHKXZTwmu.Parameters.AddWithValue("@TableName", tabela);
		xHKXZTwmu.Parameters.AddWithValue("@SchemaName", "dbo");
		checked
		{
			try
			{
				if (EcsmpC3BC.State == ConnectionState.Closed)
				{
					EcsmpC3BC.Open();
					DeclaracoesGeral.monitorConexao++;
					DeclaracoesGeral._uscPagina.statusBanco(Conversions.ToString(DeclaracoesGeral.monitorConexao));
					if (Kaiy5RFjS)
					{
						fPLUxqIrr = EcsmpC3BC.BeginTransaction();
					}
				}
				if (Kaiy5RFjS)
				{
					xHKXZTwmu.Transaction = fPLUxqIrr;
				}
				int num = Convert.ToInt32(RuntimeHelpers.GetObjectValue(xHKXZTwmu.ExecuteScalar()));
				result = num > 0;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				string prompt = "Error: " + ex2.Message;
				Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
				if (Kaiy5RFjS)
				{
					fPLUxqIrr.Rollback();
				}
				throw;
			}
			finally
			{
			}
			return result;
		}
	}

	public void AddParameter(string name, object value, OleDbType tipoOleDb)
	{
		try
		{
			SqlDbType sqlDbType = default;
			switch (tipoOleDb)
			{
			case OleDbType.LongVarChar:
				sqlDbType = SqlDbType.VarChar;
				break;
			case OleDbType.Decimal:
				sqlDbType = SqlDbType.Decimal;
				break;
			case OleDbType.Char:
				sqlDbType = SqlDbType.Char;
				break;
			case OleDbType.LongVarWChar:
				sqlDbType = SqlDbType.VarChar;
				break;
			case OleDbType.Integer:
				sqlDbType = SqlDbType.Int;
				break;
			case OleDbType.Double:
				sqlDbType = SqlDbType.Real;
				break;
			case OleDbType.Single:
				sqlDbType = SqlDbType.Real;
				break;
			case OleDbType.SmallInt:
				sqlDbType = SqlDbType.SmallInt;
				break;
			case OleDbType.Boolean:
				sqlDbType = SqlDbType.Bit;
				break;
			case OleDbType.Date:
				sqlDbType = SqlDbType.DateTime;
				break;
			default:
				Interaction.MsgBox("Erro AddParameter SQL Server!");
				break;
			}
			xHKXZTwmu.Parameters.Add(name, sqlDbType);
			xHKXZTwmu.Parameters[name].Value = RuntimeHelpers.GetObjectValue(value);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			string prompt = "Error Parameter: " + ex2.Message;
			Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
			if (Kaiy5RFjS)
			{
				fPLUxqIrr.Rollback();
			}
			throw;
		}
	}
}
