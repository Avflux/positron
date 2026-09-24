using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class AcessoSQLServerLicenca
{
	private SqlConnection PX5ghHlf3;

	private SqlCommand P3JA4j3VN;

	public void fechaConexao()
	{
		PX5ghHlf3.Close();
		PX5ghHlf3.Dispose();
		P3JA4j3VN.Dispose();
	}

	public AcessoSQLServerLicenca()
	{
		PX5ghHlf3 = new SqlConnection();
		P3JA4j3VN = new SqlCommand();
		try
		{
			SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
			{
				DataSource = "svsqlcse.database.windows.net, 1433",
				IntegratedSecurity = false,
				UserID = "azureadm",
				Password = "2020CSE@lic",
				InitialCatalog = "LICSQL_CSE",
				Encrypt = true,
				PersistSecurityInfo = false,
				ConnectTimeout = 30,
				MultipleActiveResultSets = false,
				TrustServerCertificate = true
			};
			PX5ghHlf3.ConnectionString = sqlConnectionStringBuilder.ConnectionString;
			P3JA4j3VN.Connection = PX5ghHlf3;
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
			if (PX5ghHlf3.State == ConnectionState.Closed)
			{
				PX5ghHlf3.Open();
				result = true;
				PX5ghHlf3.Close();
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

	public void ExecuteNonQuery(string query)
	{
		P3JA4j3VN.CommandType = CommandType.Text;
		P3JA4j3VN.CommandText = query;
		try
		{
			if (PX5ghHlf3.State == ConnectionState.Closed)
			{
				PX5ghHlf3.Open();
			}
			P3JA4j3VN.ExecuteNonQuery();
		}
		catch (SqlException ex)
		{
			ProjectData.SetProjectError(ex);
			SqlException ex2 = ex;
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
			P3JA4j3VN.Parameters.Clear();
		}
	}

	public DataTable ExecuteReader(string query)
	{
		P3JA4j3VN.CommandText = query;
		P3JA4j3VN.CommandType = CommandType.Text;
		DataTable dataTable = new DataTable();
		try
		{
			if (PX5ghHlf3.State == ConnectionState.Closed)
			{
				PX5ghHlf3.Open();
			}
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(P3JA4j3VN);
			sqlDataAdapter.Fill(dataTable);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw ex2;
		}
		finally
		{
			P3JA4j3VN.Parameters.Clear();
		}
		return dataTable;
	}

	public void AddParameter(string name, object value, SqlDbType tipo)
	{
		try
		{
			P3JA4j3VN.Parameters.Add(name, tipo);
			P3JA4j3VN.Parameters[name].Value = RuntimeHelpers.GetObjectValue(value);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}
}
