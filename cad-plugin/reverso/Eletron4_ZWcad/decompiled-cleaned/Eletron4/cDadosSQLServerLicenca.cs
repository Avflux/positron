using System;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class cDadosSQLServerLicenca
{
	public AcessoSQLServerLicenca db;

	public cDadosSQLServerLicenca()
	{
		db = new AcessoSQLServerLicenca();
	}

	public void fechaConexao()
	{
		db.fechaConexao();
	}

	public bool testaConexao()
	{
		FrmBuscaNuvem frmBuscaNuvem = new FrmBuscaNuvem();
		bool flag = false;
		flag = db.TestaConexao();
		frmBuscaNuvem.Close();
		frmBuscaNuvem.Dispose();
		return flag;
	}

	public bool carregaLicenca(ref DeclaracoesGeral.structureLic lic)
	{
		bool result = false;
		try
		{
			string query = "SELECT Chave, NomeCliente, CodigoCliente, Software, Quantidade, Habilitada, DataExpira, DiasTrial, Versao, DataCriacao, Observacao FROM Licencas WHERE Licenca=@licenca";
			db.AddParameter("@licenca", lic.Licenca, SqlDbType.Char);
			DataTable dataTable = db.ExecuteReader(query);
			if (dataTable.Rows.Count == 1)
			{
				lic.ChaveLic = Conversions.ToInteger(dataTable.Rows[0][0]);
				lic.NomeCliente = Conversions.ToString(dataTable.Rows[0][1]);
				lic.CodigoCliente = Conversions.ToInteger(dataTable.Rows[0][2]);
				lic.Software = Conversions.ToInteger(dataTable.Rows[0][3]);
				lic.Quantidade = Conversions.ToInteger(dataTable.Rows[0][4]);
				lic.Habilitada = Conversions.ToBoolean(dataTable.Rows[0][5]);
				lic.DataExpira = Conversions.ToInteger(dataTable.Rows[0][6]);
				lic.DiasTrial = Conversions.ToInteger(dataTable.Rows[0][7]);
				lic.Versao = Conversions.ToDouble(dataTable.Rows[0][8]);
				lic.DataCriacao = Conversions.ToInteger(dataTable.Rows[0][9]);
				lic.Observacao = Conversions.ToString(dataTable.Rows[0][10]);
				result = true;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		return result;
	}

	public int buscaQuantidadeUsers(int chaveLic)
	{
		int num = 0;
		try
		{
			string query = "SELECT COUNT(*) FROM Usuarios WHERE ChaveLic=@chaveLic";
			db.AddParameter("@chaveLic", chaveLic, SqlDbType.Int);
			DataTable dataTable = db.ExecuteReader(query);
			return Conversions.ToInteger(dataTable.Rows[0][0]);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public bool carregaUser(ref DeclaracoesGeral.structureUser user)
	{
		bool result = false;
		try
		{
			string query = "SELECT Chave, UltLogin FROM Usuarios WHERE ChaveLic=@chaveLic AND Email=@email AND IDUnico=@idUnico";
			db.AddParameter("@chaveLic", user.ChaveLic, SqlDbType.Int);
			db.AddParameter("@email", user.Email, SqlDbType.Char);
			db.AddParameter("@idUnico", user.IDUnico, SqlDbType.Int);
			DataTable dataTable = db.ExecuteReader(query);
			if (dataTable.Rows.Count == 1)
			{
				user.ChaveUser = Conversions.ToInteger(dataTable.Rows[0][0]);
				user.UltLogin = Conversions.ToInteger(dataTable.Rows[0][1]);
				result = true;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		return result;
	}

	public void AdicionaUser(DeclaracoesGeral.structureUser User)
	{
		try
		{
			string query = "Insert into Usuarios(ChaveLic, Email, VersaoCAD, VersaoSW, UltLogin, IDUnico) VALUES(@chaveLic,@email,@versaoCAD,@versaoSW,@ultLogin,@idUnico)";
			db.AddParameter("@chaveLic", User.ChaveLic, SqlDbType.Int);
			db.AddParameter("@email", User.Email, SqlDbType.Char);
			db.AddParameter("@versaoCAD", User.versaoCAD, SqlDbType.Char);
			db.AddParameter("@versaoSW", User.versaoSW, SqlDbType.Decimal);
			db.AddParameter("@ultLogin", User.UltLogin, SqlDbType.Int);
			db.AddParameter("@idUnico", User.IDUnico, SqlDbType.Int);
			db.ExecuteNonQuery(query);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}

	public bool ApagaUser(int Chave)
	{
		bool flag = true;
		try
		{
			string query = "DELETE FROM Usuarios WHERE Chave=@chaveUSer";
			db.AddParameter("@chaveUser", Chave, SqlDbType.Int);
			db.ExecuteNonQuery(query);
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}

	public void AtualizaUltimoLogin(int ultLogin, int chaveUSer, string versaoCAD, double versaoSW)
	{
		try
		{
			string query = "UPDATE Usuarios SET UltLogin=@ultLogin, VersaoCAD=@versaoCAD, VersaoSW=@versaoSW WHERE Chave=@chave";
			db.AddParameter("@ultLogin", ultLogin, SqlDbType.Int);
			db.AddParameter("@versaoCAD", versaoCAD, SqlDbType.Char);
			db.AddParameter("@versaoSW", versaoSW, SqlDbType.Decimal);
			db.AddParameter("@chave", chaveUSer, SqlDbType.Int);
			db.ExecuteNonQuery(query);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			throw new Exception(ex2.Message);
		}
	}
}
