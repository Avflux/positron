using System;
using System.Data;
using System.Data.OleDb;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class AcessoExcel
{
	private OleDbConnection zaWnP6uD2;

	private OleDbCommand Giy1rD8sw;

	public void fechaConexao()
	{
		if (zaWnP6uD2.State == ConnectionState.Open)
		{
			Giy1rD8sw.Dispose();
			Giy1rD8sw = null;
			zaWnP6uD2.Close();
			zaWnP6uD2.Dispose();
			zaWnP6uD2 = null;
		}
	}

	public AcessoExcel()
	{
		zaWnP6uD2 = new OleDbConnection();
		Giy1rD8sw = new OleDbCommand();
		try
		{
			zaWnP6uD2.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + DeclaracoesGeral.ConfLP.listaDePontos + "; Extended Properties='Excel 12.0 Xml;HDR=YES'";
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		finally
		{
			Giy1rD8sw.Connection = zaWnP6uD2;
		}
	}

	public bool ExecuteQuery(string query)
	{
		Giy1rD8sw.CommandType = CommandType.Text;
		Giy1rD8sw.CommandText = query;
		try
		{
			if (zaWnP6uD2.State == ConnectionState.Closed)
			{
				zaWnP6uD2.Open();
			}
			OleDbDataReader oleDbDataReader = Giy1rD8sw.ExecuteReader();
			bool result = (oleDbDataReader.HasRows ? true : false);
			oleDbDataReader.Close();
			return result;
		}
		catch (OleDbException ex)
		{
			ProjectData.SetProjectError(ex);
			OleDbException ex2 = ex;
			string prompt = "Excel Error: " + ex2.Message + " / " + query;
			Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
			throw;
		}
		catch (InvalidOperationException ex3)
		{
			ProjectData.SetProjectError(ex3);
			InvalidOperationException ex4 = ex3;
			string prompt2 = "Excel Error: " + ex4.Message + " / " + query;
			Interaction.MsgBox(prompt2, MsgBoxStyle.Critical);
			throw;
		}
		finally
		{
			Giy1rD8sw.Parameters.Clear();
		}
	}

	public int ExecuteScalar(string query)
	{
		Giy1rD8sw.CommandType = CommandType.Text;
		Giy1rD8sw.CommandText = query;
		int result = 0;
		try
		{
			if (zaWnP6uD2.State == ConnectionState.Closed)
			{
				zaWnP6uD2.Open();
			}
			result = Conversions.ToInteger(Giy1rD8sw.ExecuteScalar());
		}
		catch (OleDbException ex)
		{
			ProjectData.SetProjectError(ex);
			OleDbException ex2 = ex;
			string prompt = "Excel Error: " + ex2.Message + " / " + query;
			Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
			throw;
		}
		catch (InvalidOperationException ex3)
		{
			ProjectData.SetProjectError(ex3);
			InvalidOperationException ex4 = ex3;
			string prompt2 = "Excel Error: " + ex4.Message + " / " + query;
			Interaction.MsgBox(prompt2, MsgBoxStyle.Critical);
			throw;
		}
		finally
		{
			Giy1rD8sw.Parameters.Clear();
		}
		return result;
	}

	public int ExecuteNonQuery(string query)
	{
		Giy1rD8sw.CommandType = CommandType.Text;
		Giy1rD8sw.CommandText = query;
		int result = -1;
		try
		{
			if (zaWnP6uD2.State == ConnectionState.Closed)
			{
				zaWnP6uD2.Open();
			}
			result = Giy1rD8sw.ExecuteNonQuery();
		}
		catch (OleDbException ex)
		{
			ProjectData.SetProjectError(ex);
			OleDbException ex2 = ex;
			string prompt = "Excel Error: " + ex2.Message + " / " + query;
			Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
			throw;
		}
		catch (InvalidOperationException ex3)
		{
			ProjectData.SetProjectError(ex3);
			InvalidOperationException ex4 = ex3;
			string prompt2 = "Excel Error: " + ex4.Message + " / " + query;
			Interaction.MsgBox(prompt2, MsgBoxStyle.Critical);
			throw;
		}
		finally
		{
			Giy1rD8sw.Parameters.Clear();
		}
		return result;
	}

	public DataTable ExecuteReader(string query)
	{
		Giy1rD8sw.CommandText = query;
		Giy1rD8sw.CommandType = CommandType.Text;
		DataTable dataTable = new DataTable();
		checked
		{
			try
			{
				if (zaWnP6uD2.State == ConnectionState.Closed)
				{
					zaWnP6uD2.Open();
				}
				OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(Giy1rD8sw);
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
							else
							{
								dataTable.Rows[j][i] = Strings.Trim(Conversions.ToString(dataTable.Rows[j][i]));
							}
						}
					}
				}
			}
			catch (OleDbException ex)
			{
				ProjectData.SetProjectError(ex);
				OleDbException ex2 = ex;
				string prompt = "Excel Error: " + ex2.Message + " / " + query;
				Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
				throw;
			}
			catch (InvalidOperationException ex3)
			{
				ProjectData.SetProjectError(ex3);
				InvalidOperationException ex4 = ex3;
				string prompt2 = "Excel Error: " + ex4.Message + " / " + query;
				Interaction.MsgBox(prompt2, MsgBoxStyle.Critical);
				throw;
			}
			finally
			{
				Giy1rD8sw.Parameters.Clear();
			}
			return dataTable;
		}
	}

	public void UpdateConectadoPosFuncional(ref PortaExportada[] Porta)
	{
		checked
		{
			try
			{
				if (zaWnP6uD2.State == ConnectionState.Closed)
				{
					zaWnP6uD2.Open();
				}
				OleDbCommand oleDbCommand = new OleDbCommand();
				oleDbCommand.CommandText = "UPDATE [" + DeclaracoesGeral.ConfLP.worksheet + "$] SET " + DeclaracoesGeral.ConfLP.posicaoFuncional + "='' WHERE " + DeclaracoesGeral.ConfLP.chavePrimaria + " IS NOT NULL";
				oleDbCommand.Connection = zaWnP6uD2;
				oleDbCommand.ExecuteNonQuery();
				if (Operators.CompareString(DeclaracoesGeral.ConfLP.documentoFuncional, "", TextCompare: true) != 0)
				{
					oleDbCommand.CommandText = "UPDATE [" + DeclaracoesGeral.ConfLP.worksheet + "$] SET " + DeclaracoesGeral.ConfLP.documentoFuncional + "='' WHERE " + DeclaracoesGeral.ConfLP.chavePrimaria + " IS NOT NULL";
					oleDbCommand.Connection = zaWnP6uD2;
					oleDbCommand.ExecuteNonQuery();
				}
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(Porta);
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num = 0;
				int num2 = Information.UBound(Porta);
				for (int i = 1; i <= num2; i++)
				{
					oleDbCommand.CommandText = "UPDATE [" + DeclaracoesGeral.ConfLP.worksheet + "$] SET " + DeclaracoesGeral.ConfLP.posicaoFuncional + "='" + Porta[i].sPosicaoFuncional + "' WHERE " + DeclaracoesGeral.ConfLP.chavePrimaria + "='" + Porta[i].sChavePrimaria + "'";
					oleDbCommand.Connection = zaWnP6uD2;
					oleDbCommand.ExecuteNonQuery();
					if (Operators.CompareString(DeclaracoesGeral.ConfLP.documentoFuncional, "", TextCompare: true) != 0)
					{
						oleDbCommand.CommandText = "UPDATE [" + DeclaracoesGeral.ConfLP.worksheet + "$] SET " + DeclaracoesGeral.ConfLP.documentoFuncional + "='" + Porta[i].sDocFuncional + "' WHERE " + DeclaracoesGeral.ConfLP.chavePrimaria + "='" + Porta[i].sChavePrimaria + "'";
						oleDbCommand.Connection = zaWnP6uD2;
						oleDbCommand.ExecuteNonQuery();
					}
					num++;
					if (num == 100)
					{
						DeclaracoesGeral._uscPagina.pbPasso(num);
						num = 0;
					}
				}
				DeclaracoesGeral._uscPagina.pbFim();
			}
			catch (OleDbException ex)
			{
				ProjectData.SetProjectError(ex);
				OleDbException ex2 = ex;
				string prompt = "Excel Error: " + ex2.Message;
				Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
				throw;
			}
			catch (InvalidOperationException ex3)
			{
				ProjectData.SetProjectError(ex3);
				InvalidOperationException ex4 = ex3;
				string prompt2 = "Excel Error: " + ex4.Message;
				Interaction.MsgBox(prompt2, MsgBoxStyle.Critical);
				throw;
			}
			finally
			{
			}
		}
	}

	public DataTable ExecuteReaderCOLS(string ws)
	{
		DataTable result = null;
		try
		{
			if (zaWnP6uD2.State == ConnectionState.Closed)
			{
				zaWnP6uD2.Open();
			}
			result = zaWnP6uD2.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[4] { null, null, ws, null });
		}
		catch (OleDbException ex)
		{
			ProjectData.SetProjectError(ex);
			OleDbException ex2 = ex;
			string prompt = "Excel Error: " + ex2.Message;
			Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
			throw;
		}
		catch (InvalidOperationException ex3)
		{
			ProjectData.SetProjectError(ex3);
			InvalidOperationException ex4 = ex3;
			string prompt2 = "Excel Error: " + ex4.Message;
			Interaction.MsgBox(prompt2, MsgBoxStyle.Critical);
			throw;
		}
		finally
		{
			Giy1rD8sw.Parameters.Clear();
		}
		return result;
	}

	public DataTable ExecuteReaderWS()
	{
		DataTable result = null;
		try
		{
			if (zaWnP6uD2.State == ConnectionState.Closed)
			{
				zaWnP6uD2.Open();
			}
			result = zaWnP6uD2.GetSchema("Tables");
		}
		catch (OleDbException ex)
		{
			ProjectData.SetProjectError(ex);
			OleDbException ex2 = ex;
			string prompt = "Excel Error: " + ex2.Message;
			Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
			throw;
		}
		catch (InvalidOperationException ex3)
		{
			ProjectData.SetProjectError(ex3);
			InvalidOperationException ex4 = ex3;
			string prompt2 = "Excel Error: " + ex4.Message;
			Interaction.MsgBox(prompt2, MsgBoxStyle.Critical);
			throw;
		}
		finally
		{
			Giy1rD8sw.Parameters.Clear();
		}
		return result;
	}

	public void AddParameter(string name, object value, OleDbType tipo)
	{
		Giy1rD8sw.Parameters.Add(name, tipo);
		if ((tipo == OleDbType.Char) & Information.IsNothing(RuntimeHelpers.GetObjectValue(value)))
		{
			value = "";
		}
		Giy1rD8sw.Parameters[name].Value = RuntimeHelpers.GetObjectValue(value);
	}
}
