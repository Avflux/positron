namespace Eletron4;

public class cDadosSQLServer
{
	public AcessoSQLServer db;

	public cDadosSQLServer()
	{
		db = new AcessoSQLServer(bTrans: false);
	}

	public void fechaConexao()
	{
		db.fechaConexao();
	}

	public bool testaConexao()
	{
		return db.TestaConexao();
	}
}
