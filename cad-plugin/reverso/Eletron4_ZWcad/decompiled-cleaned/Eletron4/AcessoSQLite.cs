using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SQLite;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class AcessoSQLite
{
	private SQLiteConnection OUulZGXpK;

	private SQLiteCommand KW35YNdVf;

	private SQLiteTransaction H5F0MaXHD;

	private bool zeuRjENRF;

	public void fechaConexao()
	{
		checked
		{
			if (OUulZGXpK.State == ConnectionState.Open)
			{
				((Component)(object)KW35YNdVf).Dispose();
				KW35YNdVf = null;
				if (zeuRjENRF)
				{
					H5F0MaXHD.Commit();
					((DbTransaction)(object)H5F0MaXHD).Dispose();
				}
				OUulZGXpK.Close();
				OUulZGXpK.Dispose();
				OUulZGXpK = null;
				DeclaracoesGeral.monitorConexao--;
				DeclaracoesGeral._uscPagina.statusBanco(Conversions.ToString(DeclaracoesGeral.monitorConexao));
			}
		}
	}

	public AcessoSQLite(bool bTrans = true)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected Obj, but got Unknown
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected Obj, but got Unknown
		OUulZGXpK = new SQLiteConnection();
		KW35YNdVf = new SQLiteCommand();
		zeuRjENRF = true;
		zeuRjENRF = bTrans;
		try
		{
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
			SQLiteConnectionStringBuilder val = new SQLiteConnectionStringBuilder();
			val.ReadOnly = false;
			val.DataSource = DeclaracoesGeral.Conf.DirProjeto;
			OUulZGXpK.ConnectionString = ((DbConnectionStringBuilder)(object)val).ConnectionString;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			string prompt = "Error: " + ex2.Message;
			Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
			throw;
		}
		finally
		{
			KW35YNdVf.Connection = OUulZGXpK;
		}
	}

	public int ExecuteScalar(string query)
	{
		KW35YNdVf.CommandType = CommandType.Text;
		KW35YNdVf.CommandText = query;
		int result = 0;
		checked
		{
			try
			{
				if (OUulZGXpK.State == ConnectionState.Closed)
				{
					OUulZGXpK.Open();
					DeclaracoesGeral.monitorConexao++;
					DeclaracoesGeral._uscPagina.statusBanco(Conversions.ToString(DeclaracoesGeral.monitorConexao));
					if (zeuRjENRF)
					{
						H5F0MaXHD = OUulZGXpK.BeginTransaction(IsolationLevel.ReadCommitted);
					}
				}
				if (zeuRjENRF)
				{
					KW35YNdVf.Transaction = H5F0MaXHD;
				}
				result = Conversions.ToInteger(KW35YNdVf.ExecuteScalar());
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				string prompt = "Error: " + ex2.Message;
				Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
				if (zeuRjENRF)
				{
					((SQLiteTransactionBase)H5F0MaXHD).Rollback();
				}
				throw;
			}
			finally
			{
				KW35YNdVf.Parameters.Clear();
			}
			return result;
		}
	}

	public void ExecuteNonQuery(string query, bool bMsg = true)
	{
		KW35YNdVf.CommandType = CommandType.Text;
		KW35YNdVf.CommandText = query;
		checked
		{
			try
			{
				if (OUulZGXpK.State == ConnectionState.Closed)
				{
					OUulZGXpK.Open();
					DeclaracoesGeral.monitorConexao++;
					DeclaracoesGeral._uscPagina.statusBanco(Conversions.ToString(DeclaracoesGeral.monitorConexao));
					if (zeuRjENRF)
					{
						H5F0MaXHD = OUulZGXpK.BeginTransaction(IsolationLevel.ReadCommitted);
					}
				}
				if (zeuRjENRF)
				{
					KW35YNdVf.Transaction = H5F0MaXHD;
				}
				KW35YNdVf.ExecuteNonQuery();
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
				if (zeuRjENRF)
				{
					((SQLiteTransactionBase)H5F0MaXHD).Rollback();
				}
				throw;
			}
			finally
			{
				KW35YNdVf.Parameters.Clear();
			}
		}
	}

	public DataTable ExecuteReader(string query)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		KW35YNdVf.CommandText = query;
		KW35YNdVf.CommandType = CommandType.Text;
		DataTable dataTable = new DataTable();
		checked
		{
			try
			{
				if (OUulZGXpK.State == ConnectionState.Closed)
				{
					OUulZGXpK.Open();
					DeclaracoesGeral.monitorConexao++;
					DeclaracoesGeral._uscPagina.statusBanco(Conversions.ToString(DeclaracoesGeral.monitorConexao));
					if (zeuRjENRF)
					{
						H5F0MaXHD = OUulZGXpK.BeginTransaction(IsolationLevel.ReadCommitted);
					}
				}
				if (zeuRjENRF)
				{
					KW35YNdVf.Transaction = H5F0MaXHD;
				}
				SQLiteDataAdapter val = new SQLiteDataAdapter(KW35YNdVf);
				((DbDataAdapter)(object)val).Fill(dataTable);
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
				((Component)(object)val).Dispose();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				string prompt = "Error: " + ex2.Message;
				Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
				if (zeuRjENRF)
				{
					((SQLiteTransactionBase)H5F0MaXHD).Rollback();
				}
				throw;
			}
			finally
			{
				KW35YNdVf.Parameters.Clear();
			}
			return dataTable;
		}
	}

	public bool ExecuteQuery(string query)
	{
		KW35YNdVf.CommandType = CommandType.Text;
		KW35YNdVf.CommandText = query;
		checked
		{
			try
			{
				if (OUulZGXpK.State == ConnectionState.Closed)
				{
					OUulZGXpK.Open();
					DeclaracoesGeral.monitorConexao++;
					DeclaracoesGeral._uscPagina.statusBanco(Conversions.ToString(DeclaracoesGeral.monitorConexao));
					if (zeuRjENRF)
					{
						H5F0MaXHD = OUulZGXpK.BeginTransaction(IsolationLevel.ReadCommitted);
					}
				}
				if (zeuRjENRF)
				{
					KW35YNdVf.Transaction = H5F0MaXHD;
				}
				SQLiteDataReader val = KW35YNdVf.ExecuteReader();
				bool result = (val.HasRows ? true : false);
				val.Close();
				return result;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				string prompt = "Error: " + ex2.Message;
				Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
				if (zeuRjENRF)
				{
					((SQLiteTransactionBase)H5F0MaXHD).Rollback();
				}
				throw;
			}
			finally
			{
				KW35YNdVf.Parameters.Clear();
			}
		}
	}

	public bool ExisteTabela(string tabela)
	{
		bool result = false;
		KW35YNdVf.CommandType = CommandType.Text;
		KW35YNdVf.CommandText = "Select Count(*) FROM sqlite_master WHERE type='table' AND name='" + tabela + "'";
		checked
		{
			try
			{
				if (OUulZGXpK.State == ConnectionState.Closed)
				{
					OUulZGXpK.Open();
					DeclaracoesGeral.monitorConexao++;
					DeclaracoesGeral._uscPagina.statusBanco(Conversions.ToString(DeclaracoesGeral.monitorConexao));
					if (zeuRjENRF)
					{
						H5F0MaXHD = OUulZGXpK.BeginTransaction(IsolationLevel.ReadCommitted);
					}
				}
				if (zeuRjENRF)
				{
					KW35YNdVf.Transaction = H5F0MaXHD;
				}
				switch (Conversions.ToInteger(KW35YNdVf.ExecuteScalar()))
				{
				case 0:
					result = false;
					break;
				case 1:
					result = true;
					break;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				string prompt = "Error: " + ex2.Message;
				Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
				if (zeuRjENRF)
				{
					((SQLiteTransactionBase)H5F0MaXHD).Rollback();
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
			DbType dbType = default;
			switch (tipoOleDb)
			{
			case OleDbType.LongVarChar:
				dbType = DbType.String;
				break;
			case OleDbType.Decimal:
				dbType = DbType.Decimal;
				break;
			case OleDbType.Char:
				dbType = DbType.String;
				break;
			case OleDbType.LongVarWChar:
				dbType = DbType.String;
				break;
			case OleDbType.Integer:
				dbType = DbType.Int32;
				break;
			case OleDbType.Double:
				dbType = DbType.Double;
				break;
			case OleDbType.Single:
				dbType = DbType.Single;
				break;
			case OleDbType.SmallInt:
				dbType = DbType.Int16;
				break;
			case OleDbType.Boolean:
				dbType = DbType.Boolean;
				break;
			case OleDbType.Date:
				dbType = DbType.Date;
				break;
			default:
				Interaction.MsgBox("Erro AddParameter SQLite!");
				break;
			}
			KW35YNdVf.Parameters.Add(name, dbType);
			KW35YNdVf.Parameters[name].Value = RuntimeHelpers.GetObjectValue(value);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			string prompt = "Error Parameter: " + ex2.Message;
			Interaction.MsgBox(prompt, MsgBoxStyle.Critical);
			if (zeuRjENRF)
			{
				((SQLiteTransactionBase)H5F0MaXHD).Rollback();
			}
			throw;
		}
	}
}
