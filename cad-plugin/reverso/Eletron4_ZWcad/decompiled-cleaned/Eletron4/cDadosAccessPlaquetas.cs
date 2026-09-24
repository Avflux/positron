using System;
using System.Data;
using System.Data.OleDb;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class cDadosAccessPlaquetas
{
	public object db;

	public void fechaConexao()
	{
		NewLateBinding.LateCall(db, null, "fechaConexao", new object[0], null, null, null, IgnoreReturn: true);
	}

	public cDadosAccessPlaquetas()
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

	public void CarregaPaineis(DataGridView dg)
	{
		checked
		{
			try
			{
				string text = "SELECT Distinct(Painel) FROM Plaquetas4 ORDER BY Painel";
				object instance = db;
				object[] array = new object[1] { text };
				object[] array2 = array;
				object obj = NewLateBinding.LateGet(instance, null, "ExecuteReader", array, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				if (dataTable.Rows.Count > 0)
				{
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						dg.Rows.Add(dataTable.Rows[i][0], Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(dataTable.Rows[i][0])));
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

	public void CarregaPlaquetas(DataGridView dg, int iPainel)
	{
		checked
		{
			try
			{
				string text = "select Tag, Desc1, Desc2, Desc3, Modelo, Quantidade from Plaquetas4  where Painel=@painel  order by Indice";
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
				object[] array3 = new object[1] { text };
				array2 = array3;
				object obj = NewLateBinding.LateGet(instance2, null, "ExecuteReader", array3, null, null, new bool[1] { true });
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				DataTable dataTable = (DataTable)obj;
				int num = 0;
				if (dataTable.Rows.Count > 0)
				{
					int num2 = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num2; i++)
					{
						num++;
						dg.Rows.Add("", "", num, dataTable.Rows[i][0], dataTable.Rows[i][1], dataTable.Rows[i][2], dataTable.Rows[i][3], dataTable.Rows[i][4]);
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
