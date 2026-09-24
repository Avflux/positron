using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class ACorrecaoBD
{
	public static void CorrigeBD()
	{
		int num = 0;
		string text = "";
		object obj = null;
		string banco = DeclaracoesGeral.Conf.Banco;
		if (Operators.CompareString(banco, "A", TextCompare: true) != 0)
		{
			if (Operators.CompareString(banco, "S", TextCompare: true) != 0)
			{
				if (Operators.CompareString(banco, "SV", TextCompare: true) == 0)
				{
					obj = new AcessoSQLServer();
				}
			}
			else
			{
				obj = new AcessoSQLite();
			}
		}
		else
		{
			obj = new AcessoAccess();
		}
		int lErl = default;
		try
		{
			text = "DELETE FROM Correcao WHERE Numero < 0";
			object instance = obj;
			object[] array = new object[1] { text };
			object[] array2 = array;
			NewLateBinding.LateCall(instance, null, "ExecuteNonQuery", array, null, null, new bool[1] { true }, IgnoreReturn: true);
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			text = "SELECT MAX(Numero) FROM Correcao";
			object instance2 = obj;
			object[] array3 = new object[1] { text };
			array2 = array3;
			object value = NewLateBinding.LateGet(instance2, null, "ExecuteScalar", array3, null, null, new bool[1] { true });
			text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			num = Conversions.ToInteger(value);
			if (num >= 50)
			{
				if (num >= 51)
				{
					if (num < 52)
					{
						goto IL_040f;
					}
					if (num < 53)
					{
						goto IL_04c5;
					}
					if (num < 54)
					{
						goto IL_057b;
					}
					if (num < 55)
					{
						goto IL_0631;
					}
					if (num < 56)
					{
						goto IL_073b;
					}
					if (num < 57)
					{
						goto IL_0845;
					}
					if (num < 58)
					{
						goto IL_094f;
					}
					if (num < 59)
					{
						goto IL_0a59;
					}
					if (num < 60)
					{
						goto IL_0b63;
					}
					if (num < 61)
					{
						goto IL_0c6d;
					}
					if (num < 62)
					{
						goto IL_0d23;
					}
					if (num < 63)
					{
						goto IL_0dd9;
					}
					if (num < 64)
					{
						goto IL_0ee3;
					}
					if (num < 65)
					{
						goto IL_0fed;
					}
					if (num < 66)
					{
						goto IL_10f7;
					}
					if (num < 67)
					{
						goto IL_1201;
					}
					if (num < 68)
					{
						goto IL_130b;
					}
					if (num < 69)
					{
						goto IL_1415;
					}
					if (num < 70)
					{
						goto IL_14cb;
					}
					if (num < 71)
					{
						goto IL_1581;
					}
					if (num < 72)
					{
						goto IL_168b;
					}
					if (num < 73)
					{
						goto IL_1795;
					}
					if (num < 74)
					{
						goto IL_1947;
					}
					if (num < 75)
					{
						goto IL_1b17;
					}
					if (num < 76)
					{
						goto IL_1c21;
					}
					if (num < 77)
					{
						goto IL_1cd7;
					}
					if (num < 78)
					{
						goto IL_1de1;
					}
					if (num < 79)
					{
						goto IL_1eeb;
					}
					if (num < 80)
					{
						goto IL_1ff5;
					}
					if (num < 81)
					{
						goto IL_20ff;
					}
					if (num < 82)
					{
						goto IL_21b5;
					}
					if (num < 83)
					{
						goto IL_226b;
					}
					if (num < 84)
					{
						goto IL_2321;
					}
					if (num < 85)
					{
						goto IL_23d7;
					}
					if (num < 86)
					{
						goto IL_248d;
					}
					if (num < 87)
					{
						goto IL_2543;
					}
					if (num < 88)
					{
						goto IL_264d;
					}
					if (num < 89)
					{
						goto IL_2703;
					}
					if (num < 90)
					{
						goto IL_2846;
					}
					if (num < 91)
					{
						goto IL_28f3;
					}
					if (num < 92)
					{
						goto IL_2a36;
					}
					return;
				}
			}
			else
			{
				lErl = 50;
				try
				{
					text = "ALTER TABLE DWG ADD Criador TEXT(50) , Editor TEXT(50), Data Date";
					object instance3 = obj;
					object[] array4 = new object[2] { text, false };
					array2 = array4;
					NewLateBinding.LateCall(instance3, null, "ExecuteNonQuery", array4, null, null, new bool[2] { true, false }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex, lErl);
					ProjectData.ClearProjectError();
				}
				finally
				{
					text = "Insert into Correcao(Numero) VALUES(50)";
					object instance4 = obj;
					object[] array5 = new object[1] { text };
					array2 = array5;
					NewLateBinding.LateCall(instance4, null, "ExecuteNonQuery", array5, null, null, new bool[1] { true }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				}
			}
			lErl = 51;
			try
			{
				text = "CREATE TABLE DWGH(Indice Long, Tipo TEXT(1), Caminho MEMO, Nome TEXT(50), Criador TEXT(50), Editor TEXT(50), Data Date)";
				object instance5 = obj;
				object[] array6 = new object[2] { text, false };
				array2 = array6;
				NewLateBinding.LateCall(instance5, null, "ExecuteNonQuery", array6, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex2)
			{
				ProjectData.SetProjectError(ex2, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(51)";
				object instance6 = obj;
				object[] array7 = new object[1] { text };
				array2 = array7;
				NewLateBinding.LateCall(instance6, null, "ExecuteNonQuery", array7, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_040f;
			IL_21b5:
			lErl = 82;
			try
			{
				text = "ALTER TABLE Contatos4F ADD Orientacao TEXT(1)";
				object instance7 = obj;
				object[] array8 = new object[2] { text, false };
				array2 = array8;
				NewLateBinding.LateCall(instance7, null, "ExecuteNonQuery", array8, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(82)";
				object instance8 = obj;
				object[] array9 = new object[1] { text };
				array2 = array9;
				NewLateBinding.LateCall(instance8, null, "ExecuteNonQuery", array9, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_226b;
			IL_1581:
			lErl = 71;
			try
			{
				text = "CREATE TABLE Aranha4(Indice AUTOINCREMENT, Revisao TEXT(5), Tag_Cabo TEXT(50), Painel Long, Caderno TEXT(50), Folha TEXT(20), Coluna integer)";
				object instance9 = obj;
				object[] array10 = new object[2] { text, false };
				array2 = array10;
				NewLateBinding.LateCall(instance9, null, "ExecuteNonQuery", array10, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE Aranha4 ADD PRIMARY KEY (Indice)";
				object instance10 = obj;
				object[] array11 = new object[2] { text, false };
				array2 = array11;
				NewLateBinding.LateCall(instance10, null, "ExecuteNonQuery", array11, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex4)
			{
				ProjectData.SetProjectError(ex4, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(71)";
				object instance11 = obj;
				object[] array12 = new object[1] { text };
				array2 = array12;
				NewLateBinding.LateCall(instance11, null, "ExecuteNonQuery", array12, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_168b;
			IL_2543:
			lErl = 87;
			try
			{
				text = "CREATE TABLE SaidasGoose(Indice AUTOINCREMENT, Tag TEXT(100), Tag61850 TEXT(100),TagAlternativoEntrada TEXT(100), Descricao TEXT(255), CadernoOrigem TEXT(100), VaoOrigem TEXT(100),PainelOrigem TEXT(150),UnidadeOrigem TEXT(100),PaginaOrigem TEXT(30),CadernoDestino TEXT(100), VaoDestino TEXT(100),PainelDestino TEXT(150),UnidadeDestino TEXT(100),PaginaDestino TEXT(30))";
				object instance12 = obj;
				object[] array13 = new object[2] { text, false };
				array2 = array13;
				NewLateBinding.LateCall(instance12, null, "ExecuteNonQuery", array13, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE SaidasGoose ADD PRIMARY KEY (Indice)";
				object instance13 = obj;
				object[] array14 = new object[2] { text, false };
				array2 = array14;
				NewLateBinding.LateCall(instance13, null, "ExecuteNonQuery", array14, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex5)
			{
				ProjectData.SetProjectError(ex5, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(87)";
				object instance14 = obj;
				object[] array15 = new object[1] { text };
				array2 = array15;
				NewLateBinding.LateCall(instance14, null, "ExecuteNonQuery", array15, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_264d;
			IL_168b:
			lErl = 72;
			try
			{
				text = "CREATE TABLE Circuitos4F(Indice AUTOINCREMENT, Revisao TEXT(5), DWG Long, Painel Long, Circuito TEXT(50), Potencial Long)";
				object instance15 = obj;
				object[] array16 = new object[2] { text, false };
				array2 = array16;
				NewLateBinding.LateCall(instance15, null, "ExecuteNonQuery", array16, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE Circuitos4F ADD PRIMARY KEY (Indice)";
				object instance16 = obj;
				object[] array17 = new object[2] { text, false };
				array2 = array17;
				NewLateBinding.LateCall(instance16, null, "ExecuteNonQuery", array17, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex6)
			{
				ProjectData.SetProjectError(ex6, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(72)";
				object instance17 = obj;
				object[] array18 = new object[1] { text };
				array2 = array18;
				NewLateBinding.LateCall(instance17, null, "ExecuteNonQuery", array18, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_1795;
			IL_040f:
			lErl = 52;
			try
			{
				text = "CREATE TABLE Configuracoes(Indice Long, Tipo TEXT(1), Comando TEXT(10), Valor MEMO)";
				object instance18 = obj;
				object[] array19 = new object[2] { text, false };
				array2 = array19;
				NewLateBinding.LateCall(instance18, null, "ExecuteNonQuery", array19, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex7)
			{
				ProjectData.SetProjectError(ex7, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(52)";
				object instance19 = obj;
				object[] array20 = new object[1] { text };
				array2 = array20;
				NewLateBinding.LateCall(instance19, null, "ExecuteNonQuery", array20, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_04c5;
			IL_2846:
			lErl = 90;
			try
			{
				text = "ALTER TABLE SinaisLogico ADD Enderecos61850 TEXT(100)";
				object instance20 = obj;
				object[] array21 = new object[1] { text };
				array2 = array21;
				NewLateBinding.LateCall(instance20, null, "ExecuteNonQuery", array21, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex8)
			{
				ProjectData.SetProjectError(ex8, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(90)";
				object instance21 = obj;
				object[] array22 = new object[1] { text };
				array2 = array22;
				NewLateBinding.LateCall(instance21, null, "ExecuteNonQuery", array22, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_28f3;
			IL_04c5:
			lErl = 53;
			try
			{
				text = "ALTER TABLE Paineis ADD Criador TEXT(50) , Editor TEXT(50), Data Date";
				object instance22 = obj;
				object[] array23 = new object[2] { text, false };
				array2 = array23;
				NewLateBinding.LateCall(instance22, null, "ExecuteNonQuery", array23, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex9)
			{
				ProjectData.SetProjectError(ex9, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(53)";
				object instance23 = obj;
				object[] array24 = new object[1] { text };
				array2 = array24;
				NewLateBinding.LateCall(instance23, null, "ExecuteNonQuery", array24, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_057b;
			IL_1795:
			lErl = 73;
			try
			{
				text = "ALTER TABLE Materiais ALTER COLUMN CodigoCliente TEXT(250)";
				object instance24 = obj;
				object[] array25 = new object[2] { text, false };
				array2 = array25;
				NewLateBinding.LateCall(instance24, null, "ExecuteNonQuery", array25, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE Materiais ALTER COLUMN DescricaoResumida TEXT(250)";
				object instance25 = obj;
				object[] array26 = new object[2] { text, false };
				array2 = array26;
				NewLateBinding.LateCall(instance25, null, "ExecuteNonQuery", array26, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE Materiais ALTER COLUMN Modelo TEXT(250)";
				object instance26 = obj;
				object[] array27 = new object[2] { text, false };
				array2 = array27;
				NewLateBinding.LateCall(instance26, null, "ExecuteNonQuery", array27, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE Materiais ALTER COLUMN Fabricante TEXT(250)";
				object instance27 = obj;
				object[] array28 = new object[2] { text, false };
				array2 = array28;
				NewLateBinding.LateCall(instance27, null, "ExecuteNonQuery", array28, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex10)
			{
				ProjectData.SetProjectError(ex10, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(73)";
				object instance28 = obj;
				object[] array29 = new object[1] { text };
				array2 = array29;
				NewLateBinding.LateCall(instance28, null, "ExecuteNonQuery", array29, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_1947;
			IL_057b:
			lErl = 54;
			try
			{
				text = "CREATE TABLE PaineisH(Indice Long, Nome TEXT(50), Criador TEXT(50), Editor TEXT(50), Data Date)";
				object instance29 = obj;
				object[] array30 = new object[2] { text, false };
				array2 = array30;
				NewLateBinding.LateCall(instance29, null, "ExecuteNonQuery", array30, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex11)
			{
				ProjectData.SetProjectError(ex11, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(54)";
				object instance30 = obj;
				object[] array31 = new object[1] { text };
				array2 = array31;
				NewLateBinding.LateCall(instance30, null, "ExecuteNonQuery", array31, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_0631;
			IL_226b:
			lErl = 83;
			try
			{
				text = "ALTER TABLE Portas4F ADD Orientacao TEXT(1)";
				object instance31 = obj;
				object[] array32 = new object[2] { text, false };
				array2 = array32;
				NewLateBinding.LateCall(instance31, null, "ExecuteNonQuery", array32, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex12)
			{
				ProjectData.SetProjectError(ex12, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(83)";
				object instance32 = obj;
				object[] array33 = new object[1] { text };
				array2 = array33;
				NewLateBinding.LateCall(instance32, null, "ExecuteNonQuery", array33, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_2321;
			IL_0631:
			lErl = 55;
			try
			{
				text = "CREATE TABLE Fiacao(Indice AUTOINCREMENT, Revisao TEXT(5), DWG Long, Painel Long, Potencial Long, Ordem Integer, Pagina TEXT(20), Tag TEXT(50), Alternativo TEXT(50), NRegua TEXT(50), Terminal TEXT(50), TerminalNum Double, Tipo TEXT(1), Secao TEXT(10), Cor TEXT(50), PosicaoNum Integer, TipoBorne Integer, BJumper YesNo, BLink YesNo, Handle TEXT(20), IndexModelo Long, Criador TEXT(20), Data DATE)";
				object instance33 = obj;
				object[] array34 = new object[2] { text, false };
				array2 = array34;
				NewLateBinding.LateCall(instance33, null, "ExecuteNonQuery", array34, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE Fiacao ADD PRIMARY KEY (Indice)";
				object instance34 = obj;
				object[] array35 = new object[2] { text, false };
				array2 = array35;
				NewLateBinding.LateCall(instance34, null, "ExecuteNonQuery", array35, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex13)
			{
				ProjectData.SetProjectError(ex13, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(55)";
				object instance35 = obj;
				object[] array36 = new object[1] { text };
				array2 = array36;
				NewLateBinding.LateCall(instance35, null, "ExecuteNonQuery", array36, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_073b;
			IL_1947:
			lErl = 74;
			try
			{
				string text2 = Conversions.ToString(NewLateBinding.LateGet(obj, null, "Schema", new object[0], null, null, null));
				if (Operators.CompareString(text2, "", TextCompare: true) != 0)
				{
					text = "ALTER TABLE Materiais DROP CONSTRAINT " + text2;
					object instance36 = obj;
					object[] array37 = new object[2] { text, false };
					array2 = array37;
					NewLateBinding.LateCall(instance36, null, "ExecuteNonQuery", array37, null, null, new bool[2] { true, false }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				}
				if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(obj, null, "existeColuna", new object[2] { "Materiais", "Indice" }, null, null, null), false, TextCompare: true))
				{
					text = "ALTER TABLE Materiais ADD Indice AUTOINCREMENT";
					object instance37 = obj;
					object[] array38 = new object[2] { text, false };
					array2 = array38;
					NewLateBinding.LateCall(instance37, null, "ExecuteNonQuery", array38, null, null, new bool[2] { true, false }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				}
				text = "ALTER TABLE Materiais ADD PRIMARY KEY (Indice)";
				NewLateBinding.LateCall(obj, null, "ExecuteNonQuery", array2 = new object[2] { text, false }, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex14)
			{
				ProjectData.SetProjectError(ex14, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(74)";
				object instance38 = obj;
				object[] array39 = new object[1] { text };
				array2 = array39;
				NewLateBinding.LateCall(instance38, null, "ExecuteNonQuery", array39, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_1b17;
			IL_073b:
			lErl = 56;
			try
			{
				text = "CREATE TABLE Contatos4F(Indice AUTOINCREMENT, Revisao TEXT(5), DWG Long, IndexModelo Long, NomeModelo TEXT(255), Terminal TEXT(50), TerminalNum Double)";
				object instance39 = obj;
				object[] array40 = new object[2] { text, false };
				array2 = array40;
				NewLateBinding.LateCall(instance39, null, "ExecuteNonQuery", array40, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE Contatos4F ADD PRIMARY KEY (Indice)";
				object instance40 = obj;
				object[] array41 = new object[2] { text, false };
				array2 = array41;
				NewLateBinding.LateCall(instance40, null, "ExecuteNonQuery", array41, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex15)
			{
				ProjectData.SetProjectError(ex15, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(56)";
				object instance41 = obj;
				object[] array42 = new object[1] { text };
				array2 = array42;
				NewLateBinding.LateCall(instance41, null, "ExecuteNonQuery", array42, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_0845;
			IL_264d:
			lErl = 88;
			try
			{
				text = "ALTER TABLE ListaMateriais ADD OrdemLay Integer";
				object instance42 = obj;
				object[] array43 = new object[2] { text, false };
				array2 = array43;
				NewLateBinding.LateCall(instance42, null, "ExecuteNonQuery", array43, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex16)
			{
				ProjectData.SetProjectError(ex16, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(88)";
				object instance43 = obj;
				object[] array44 = new object[1] { text };
				array2 = array44;
				NewLateBinding.LateCall(instance43, null, "ExecuteNonQuery", array44, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_2703;
			IL_0845:
			lErl = 57;
			try
			{
				text = "CREATE TABLE Portas4F(Indice AUTOINCREMENT, Revisao TEXT(5), DWG Long, IndexModelo Long, NomeModelo TEXT(255), Regua TEXT(50), Borne TEXT(50), Terminal TEXT(50), TerminalNum Double, Tipo TEXT(1))";
				object instance44 = obj;
				object[] array45 = new object[2] { text, false };
				array2 = array45;
				NewLateBinding.LateCall(instance44, null, "ExecuteNonQuery", array45, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE Portas4F ADD PRIMARY KEY (Indice)";
				object instance45 = obj;
				object[] array46 = new object[2] { text, false };
				array2 = array46;
				NewLateBinding.LateCall(instance45, null, "ExecuteNonQuery", array46, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex17)
			{
				ProjectData.SetProjectError(ex17, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(57)";
				object instance46 = obj;
				object[] array47 = new object[1] { text };
				array2 = array47;
				NewLateBinding.LateCall(instance46, null, "ExecuteNonQuery", array47, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_094f;
			IL_1b17:
			lErl = 75;
			try
			{
				text = "CREATE TABLE Preferencias(Indice AUTOINCREMENT, DWG Long, Painel Long, Campo TEXT(100), Valor TEXT(100))";
				object instance47 = obj;
				object[] array48 = new object[2] { text, false };
				array2 = array48;
				NewLateBinding.LateCall(instance47, null, "ExecuteNonQuery", array48, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE Preferencias ADD PRIMARY KEY (Indice)";
				object instance48 = obj;
				object[] array49 = new object[2] { text, false };
				array2 = array49;
				NewLateBinding.LateCall(instance48, null, "ExecuteNonQuery", array49, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex18)
			{
				ProjectData.SetProjectError(ex18, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(75)";
				object instance49 = obj;
				object[] array50 = new object[1] { text };
				array2 = array50;
				NewLateBinding.LateCall(instance49, null, "ExecuteNonQuery", array50, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_1c21;
			IL_094f:
			lErl = 58;
			try
			{
				text = "CREATE TABLE Dispositivos4F(Indice AUTOINCREMENT, Revisao TEXT(5), DWG Long, Painel Long, Tag TEXT(50), Alternativo TEXT(50), Tipo TEXT(1), Handle TEXT(20), Pagina TEXT(20), BlocoTopografico TEXT(255), BlocoLayout TEXT(255), PosicaoNum Integer, Ordem Integer)";
				object instance50 = obj;
				object[] array51 = new object[2] { text, false };
				array2 = array51;
				NewLateBinding.LateCall(instance50, null, "ExecuteNonQuery", array51, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE Dispositivos4F ADD PRIMARY KEY (Indice)";
				object instance51 = obj;
				object[] array52 = new object[2] { text, false };
				array2 = array52;
				NewLateBinding.LateCall(instance51, null, "ExecuteNonQuery", array52, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex19)
			{
				ProjectData.SetProjectError(ex19, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(58)";
				object instance52 = obj;
				object[] array53 = new object[1] { text };
				array2 = array53;
				NewLateBinding.LateCall(instance52, null, "ExecuteNonQuery", array53, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_0a59;
			IL_2321:
			lErl = 84;
			try
			{
				text = "ALTER TABLE Fiacao ADD Aplicacao Integer";
				object instance53 = obj;
				object[] array54 = new object[2] { text, false };
				array2 = array54;
				NewLateBinding.LateCall(instance53, null, "ExecuteNonQuery", array54, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex20)
			{
				ProjectData.SetProjectError(ex20, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(84)";
				object instance54 = obj;
				object[] array55 = new object[1] { text };
				array2 = array55;
				NewLateBinding.LateCall(instance54, null, "ExecuteNonQuery", array55, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_23d7;
			IL_0a59:
			lErl = 59;
			try
			{
				text = "CREATE TABLE Bornes4F(Indice AUTOINCREMENT, Revisao TEXT(5), DWG Long, Painel Long, IndexRegua Integer, Regua TEXT(50), Alternativo TEXT(50), Handle TEXT(20), Borne TEXT(10), Ordem Double, Tipo Integer, Pagina TEXT(20), bReserva YesNo)";
				object instance55 = obj;
				object[] array56 = new object[2] { text, false };
				array2 = array56;
				NewLateBinding.LateCall(instance55, null, "ExecuteNonQuery", array56, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE Bornes4F ADD PRIMARY KEY (Indice)";
				object instance56 = obj;
				object[] array57 = new object[2] { text, false };
				array2 = array57;
				NewLateBinding.LateCall(instance56, null, "ExecuteNonQuery", array57, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex21)
			{
				ProjectData.SetProjectError(ex21, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(59)";
				object instance57 = obj;
				object[] array58 = new object[1] { text };
				array2 = array58;
				NewLateBinding.LateCall(instance57, null, "ExecuteNonQuery", array58, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_0b63;
			IL_1c21:
			lErl = 76;
			try
			{
				text = "ALTER TABLE Bornes4F ADD LM Long";
				object instance58 = obj;
				object[] array59 = new object[2] { text, false };
				array2 = array59;
				NewLateBinding.LateCall(instance58, null, "ExecuteNonQuery", array59, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex22)
			{
				ProjectData.SetProjectError(ex22, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(76)";
				object instance59 = obj;
				object[] array60 = new object[1] { text };
				array2 = array60;
				NewLateBinding.LateCall(instance59, null, "ExecuteNonQuery", array60, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_1cd7;
			IL_0b63:
			lErl = 60;
			try
			{
				text = "CREATE TABLE Plaquetas4(Indice AUTOINCREMENT, DWG Long, Painel Long, Tag TEXT(50), Modelo TEXT(10), Desc1 TEXT(40), Desc2 TEXT(40), Desc3 TEXT(40), Quantidade Integer)";
				object instance60 = obj;
				object[] array61 = new object[2] { text, false };
				array2 = array61;
				NewLateBinding.LateCall(instance60, null, "ExecuteNonQuery", array61, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE Plaquetas4 ADD PRIMARY KEY (Indice)";
				object instance61 = obj;
				object[] array62 = new object[2] { text, false };
				array2 = array62;
				NewLateBinding.LateCall(instance61, null, "ExecuteNonQuery", array62, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex23)
			{
				ProjectData.SetProjectError(ex23, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(60)";
				object instance62 = obj;
				object[] array63 = new object[1] { text };
				array2 = array63;
				NewLateBinding.LateCall(instance62, null, "ExecuteNonQuery", array63, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_0c6d;
			IL_2a36:
			lErl = 92;
			try
			{
				if (Operators.CompareString(DeclaracoesGeral.Conf.Banco, "A", TextCompare: true) != 0)
				{
					if (Operators.CompareString(DeclaracoesGeral.Conf.Banco, "S", TextCompare: true) == 0)
					{
						text = "CREATE TEMPORARY TABLE ModelosCabosTemp(Indice INTEGER,CodigoCliente TEXT(10), Descricao TEXT(255), Prefixo TEXT(15), Conector1 TEXT(20), BlocoConector1 TEXT(20), Conector2 TEXT(20), BlocoConector2 TEXT(20), EstiloLinha TEXT(50), CorLinha Integer, PesoLinha Double, EscalaLinha Double)";
						object instance63 = obj;
						object[] array64 = new object[1] { text };
						array2 = array64;
						NewLateBinding.LateCall(instance63, null, "ExecuteNonQuery", array64, null, null, new bool[1] { true }, IgnoreReturn: true);
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
						text = "INSERT INTO ModelosCabosTemp SELECT * FROM ModelosCabos";
						object instance64 = obj;
						object[] array65 = new object[1] { text };
						array2 = array65;
						NewLateBinding.LateCall(instance64, null, "ExecuteNonQuery", array65, null, null, new bool[1] { true }, IgnoreReturn: true);
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
						text = "DROP TABLE ModelosCabos";
						object instance65 = obj;
						object[] array66 = new object[1] { text };
						array2 = array66;
						NewLateBinding.LateCall(instance65, null, "ExecuteNonQuery", array66, null, null, new bool[1] { true }, IgnoreReturn: true);
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
						text = "CREATE TABLE ModelosCabos(Indice INTEGER PRIMARY KEY,CodigoCliente TEXT(10), Descricao TEXT(255), Prefixo TEXT(15), Conector1 TEXT(20), BlocoConector1 TEXT(20), Conector2 TEXT(20), BlocoConector2 TEXT(20), EstiloLinha TEXT(50), CorLinha Integer, PesoLinha Double, EscalaLinha Double)";
						object instance66 = obj;
						object[] array67 = new object[1] { text };
						array2 = array67;
						NewLateBinding.LateCall(instance66, null, "ExecuteNonQuery", array67, null, null, new bool[1] { true }, IgnoreReturn: true);
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
						text = "INSERT INTO ModelosCabos SELECT * FROM ModelosCabosTemp";
						object instance67 = obj;
						object[] array68 = new object[1] { text };
						array2 = array68;
						NewLateBinding.LateCall(instance67, null, "ExecuteNonQuery", array68, null, null, new bool[1] { true }, IgnoreReturn: true);
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
						text = "DROP TABLE ModelosCabosTemp";
						object instance68 = obj;
						object[] array69 = new object[1] { text };
						array2 = array69;
						NewLateBinding.LateCall(instance68, null, "ExecuteNonQuery", array69, null, null, new bool[1] { true }, IgnoreReturn: true);
						text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
					}
				}
				else
				{
					text = "ALTER TABLE ModelosCabos ALTER COLUMN Prefixo TEXT(15)";
					object instance69 = obj;
					object[] array70 = new object[2] { text, false };
					array2 = array70;
					NewLateBinding.LateCall(instance69, null, "ExecuteNonQuery", array70, null, null, new bool[2] { true, false }, IgnoreReturn: true);
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				}
				return;
			}
			catch (Exception ex24)
			{
				ProjectData.SetProjectError(ex24, lErl);
				ProjectData.ClearProjectError();
				return;
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(92)";
				object instance70 = obj;
				object[] array71 = new object[1] { text };
				array2 = array71;
				NewLateBinding.LateCall(instance70, null, "ExecuteNonQuery", array71, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			IL_0c6d:
			lErl = 61;
			try
			{
				text = "ALTER TABLE ListaMateriais ADD Alternativo TEXT(20), Handle TEXT(20)";
				object instance71 = obj;
				object[] array72 = new object[2] { text, false };
				array2 = array72;
				NewLateBinding.LateCall(instance71, null, "ExecuteNonQuery", array72, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex25)
			{
				ProjectData.SetProjectError(ex25, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(61)";
				object instance72 = obj;
				object[] array73 = new object[1] { text };
				array2 = array73;
				NewLateBinding.LateCall(instance72, null, "ExecuteNonQuery", array73, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_0d23;
			IL_1cd7:
			lErl = 77;
			try
			{
				text = "ALTER TABLE Veias ADD Funcao TEXT(50)";
				object instance73 = obj;
				object[] array74 = new object[2] { text, false };
				array2 = array74;
				NewLateBinding.LateCall(instance73, null, "ExecuteNonQuery", array74, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE Veias4 ADD Funcao TEXT(50)";
				object instance74 = obj;
				object[] array75 = new object[2] { text, false };
				array2 = array75;
				NewLateBinding.LateCall(instance74, null, "ExecuteNonQuery", array75, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex26)
			{
				ProjectData.SetProjectError(ex26, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(77)";
				object instance75 = obj;
				object[] array76 = new object[1] { text };
				array2 = array76;
				NewLateBinding.LateCall(instance75, null, "ExecuteNonQuery", array76, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_1de1;
			IL_0d23:
			lErl = 62;
			try
			{
				text = "ALTER TABLE ListaMateriais ADD IndiceLM Integer";
				object instance76 = obj;
				object[] array77 = new object[2] { text, false };
				array2 = array77;
				NewLateBinding.LateCall(instance76, null, "ExecuteNonQuery", array77, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex27)
			{
				ProjectData.SetProjectError(ex27, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(62)";
				object instance77 = obj;
				object[] array78 = new object[1] { text };
				array2 = array78;
				NewLateBinding.LateCall(instance77, null, "ExecuteNonQuery", array78, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_0dd9;
			IL_23d7:
			lErl = 85;
			try
			{
				text = "ALTER TABLE Fiacao ADD Orientacao TEXT(1)";
				object instance78 = obj;
				object[] array79 = new object[2] { text, false };
				array2 = array79;
				NewLateBinding.LateCall(instance78, null, "ExecuteNonQuery", array79, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex28)
			{
				ProjectData.SetProjectError(ex28, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(85)";
				object instance79 = obj;
				object[] array80 = new object[1] { text };
				array2 = array80;
				NewLateBinding.LateCall(instance79, null, "ExecuteNonQuery", array80, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_248d;
			IL_0dd9:
			lErl = 63;
			try
			{
				text = "CREATE TABLE Interligacao4(Indice AUTOINCREMENT, Revisao TEXT(5),  DWG Long, Tag_Cabo TEXT(50), Num_Veia Integer, Nome_Veia TEXT(100), DWG1 Long, Documento1 TEXT(50), Painel1 Long, Tag1 TEXT(50), Alternativo1 TEXT(50), NRegua1 TEXT(50), Terminal1 TEXT(50), TerminalNum1 Double, TipoBorne1 Integer, Handle1 TEXT(20), Pagina1 TEXT(255), Posicao1 TEXT(10), IndexModelo1 Long, DWG2 Long, Documento2 TEXT(50), Painel2 Long, Tag2 TEXT(50), Alternativo2 TEXT(50), NRegua2 TEXT(50), Terminal2 TEXT(50), TerminalNum2 Double, TipoBorne2 Integer, Handle2 TEXT(20), Pagina2 TEXT(255), Posicao2 TEXT(10), IndexModelo2 Long, Criador TEXT(20), Data DATE)";
				object instance80 = obj;
				object[] array81 = new object[2] { text, false };
				array2 = array81;
				NewLateBinding.LateCall(instance80, null, "ExecuteNonQuery", array81, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE Interligacao4 ADD PRIMARY KEY (Indice)";
				object instance81 = obj;
				object[] array82 = new object[2] { text, false };
				array2 = array82;
				NewLateBinding.LateCall(instance81, null, "ExecuteNonQuery", array82, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex29)
			{
				ProjectData.SetProjectError(ex29, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(63)";
				object instance82 = obj;
				object[] array83 = new object[1] { text };
				array2 = array83;
				NewLateBinding.LateCall(instance82, null, "ExecuteNonQuery", array83, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_0ee3;
			IL_1de1:
			lErl = 78;
			try
			{
				text = "CREATE TABLE ModelosCabos(Indice AUTOINCREMENT,CodigoCliente TEXT(10), Descricao TEXT(255), Prefixo TEXT(5), Conector1 TEXT(10), BlocoConector1 TEXT(20), Conector2 TEXT(10), BlocoConector2 TEXT(20), EstiloLinha TEXT(50), CorLinha Integer, PesoLinha Double, EscalaLinha Double)";
				object instance83 = obj;
				object[] array84 = new object[2] { text, false };
				array2 = array84;
				NewLateBinding.LateCall(instance83, null, "ExecuteNonQuery", array84, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE ModelosCabos ADD PRIMARY KEY (Indice)";
				object instance84 = obj;
				object[] array85 = new object[2] { text, false };
				array2 = array85;
				NewLateBinding.LateCall(instance84, null, "ExecuteNonQuery", array85, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex30)
			{
				ProjectData.SetProjectError(ex30, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(78)";
				object instance85 = obj;
				object[] array86 = new object[1] { text };
				array2 = array86;
				NewLateBinding.LateCall(instance85, null, "ExecuteNonQuery", array86, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_1eeb;
			IL_0ee3:
			lErl = 64;
			try
			{
				text = "CREATE TABLE Portas4I(Indice AUTOINCREMENT, Revisao TEXT(5), DWG Long, IndexModelo Long, NomeModelo TEXT(255), Regua TEXT(50), Borne TEXT(50), Terminal TEXT(50), TerminalNum Double, Tipo TEXT(1))";
				object instance86 = obj;
				object[] array87 = new object[2] { text, false };
				array2 = array87;
				NewLateBinding.LateCall(instance86, null, "ExecuteNonQuery", array87, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE Portas4I ADD PRIMARY KEY (Indice)";
				object instance87 = obj;
				object[] array88 = new object[2] { text, false };
				array2 = array88;
				NewLateBinding.LateCall(instance87, null, "ExecuteNonQuery", array88, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex31)
			{
				ProjectData.SetProjectError(ex31, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(64)";
				object instance88 = obj;
				object[] array89 = new object[1] { text };
				array2 = array89;
				NewLateBinding.LateCall(instance88, null, "ExecuteNonQuery", array89, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_0fed;
			IL_2703:
			lErl = 89;
			try
			{
				text = "DROP TABLE SaidasGoose";
				object instance89 = obj;
				object[] array90 = new object[1] { text };
				array2 = array90;
				NewLateBinding.LateCall(instance89, null, "ExecuteNonQuery", array90, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "CREATE TABLE SinaisLogico(Indice AUTOINCREMENT, Tipo TEXT(30), Tag TEXT(100), Tag61850 TEXT(100),TagAlternativoEntrada TEXT(100), Descricao TEXT(255), CadernoOrigem TEXT(100), VaoOrigem TEXT(100),PainelOrigem TEXT(150),UnidadeOrigem TEXT(100),PaginaOrigem TEXT(30),CadernoDestino TEXT(100), VaoDestino TEXT(100),PainelDestino TEXT(150),UnidadeDestino TEXT(100),PaginaDestino TEXT(30))";
				object instance90 = obj;
				object[] array91 = new object[1] { text };
				array2 = array91;
				NewLateBinding.LateCall(instance90, null, "ExecuteNonQuery", array91, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE SinaisLogico ADD PRIMARY KEY (Indice)";
				object instance91 = obj;
				object[] array92 = new object[1] { text };
				array2 = array92;
				NewLateBinding.LateCall(instance91, null, "ExecuteNonQuery", array92, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex32)
			{
				ProjectData.SetProjectError(ex32, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(89)";
				object instance92 = obj;
				object[] array93 = new object[1] { text };
				array2 = array93;
				NewLateBinding.LateCall(instance92, null, "ExecuteNonQuery", array93, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_2846;
			IL_0fed:
			lErl = 65;
			try
			{
				text = "CREATE TABLE Bornes4I(Indice AUTOINCREMENT, Revisao TEXT(5), DWG Long, Painel Long, IndexRegua Integer, Regua TEXT(50), Alternativo TEXT(50), Handle TEXT(20), Borne TEXT(10), Ordem Double, Tipo Integer, Pagina TEXT(20), bReserva YesNo)";
				object instance93 = obj;
				object[] array94 = new object[2] { text, false };
				array2 = array94;
				NewLateBinding.LateCall(instance93, null, "ExecuteNonQuery", array94, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE Bornes4I ADD PRIMARY KEY (Indice)";
				object instance94 = obj;
				object[] array95 = new object[2] { text, false };
				array2 = array95;
				NewLateBinding.LateCall(instance94, null, "ExecuteNonQuery", array95, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex33)
			{
				ProjectData.SetProjectError(ex33, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(65)";
				object instance95 = obj;
				object[] array96 = new object[1] { text };
				array2 = array96;
				NewLateBinding.LateCall(instance95, null, "ExecuteNonQuery", array96, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_10f7;
			IL_1eeb:
			lErl = 79;
			try
			{
				text = "ALTER TABLE ModelosCabos ALTER COLUMN Conector1 TEXT(20)";
				object instance96 = obj;
				object[] array97 = new object[2] { text, false };
				array2 = array97;
				NewLateBinding.LateCall(instance96, null, "ExecuteNonQuery", array97, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE ModelosCabos ALTER COLUMN Conector2 TEXT(20)";
				object instance97 = obj;
				object[] array98 = new object[2] { text, false };
				array2 = array98;
				NewLateBinding.LateCall(instance97, null, "ExecuteNonQuery", array98, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex34)
			{
				ProjectData.SetProjectError(ex34, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(79)";
				object instance98 = obj;
				object[] array99 = new object[1] { text };
				array2 = array99;
				NewLateBinding.LateCall(instance98, null, "ExecuteNonQuery", array99, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_1ff5;
			IL_10f7:
			lErl = 66;
			try
			{
				text = "CREATE TABLE Jumper4(Indice AUTOINCREMENT, Revisao TEXT(5), DWG Long, Painel Long, Potencial Long, Ordem Integer, Pagina TEXT(20), Tag TEXT(50), Alternativo TEXT(50), NRegua TEXT(50), Terminal TEXT(50), TerminalNum Double, Tipo TEXT(1), Secao TEXT(10), Cor TEXT(50), PosicaoNum Integer, TipoBorne Integer, BJumper YesNo, BLink YesNo, Handle TEXT(20), IndexModelo Long, Criador TEXT(20), Data DATE)";
				object instance99 = obj;
				object[] array100 = new object[2] { text, false };
				array2 = array100;
				NewLateBinding.LateCall(instance99, null, "ExecuteNonQuery", array100, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE Jumper4 ADD PRIMARY KEY (Indice)";
				object instance100 = obj;
				object[] array101 = new object[2] { text, false };
				array2 = array101;
				NewLateBinding.LateCall(instance100, null, "ExecuteNonQuery", array101, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex35)
			{
				ProjectData.SetProjectError(ex35, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(66)";
				object instance101 = obj;
				object[] array102 = new object[1] { text };
				array2 = array102;
				NewLateBinding.LateCall(instance101, null, "ExecuteNonQuery", array102, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_1201;
			IL_248d:
			lErl = 86;
			try
			{
				text = "ALTER TABLE Bornes4F ADD BlocoLayout TEXT(200)";
				object instance102 = obj;
				object[] array103 = new object[2] { text, false };
				array2 = array103;
				NewLateBinding.LateCall(instance102, null, "ExecuteNonQuery", array103, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex36)
			{
				ProjectData.SetProjectError(ex36, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(86)";
				object instance103 = obj;
				object[] array104 = new object[1] { text };
				array2 = array104;
				NewLateBinding.LateCall(instance103, null, "ExecuteNonQuery", array104, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_2543;
			IL_1201:
			lErl = 67;
			try
			{
				text = "CREATE TABLE Cabos4(Indice AUTOINCREMENT, Revisao TEXT(5), Tag TEXT(50), Formacao TEXT(15), Blindagem YesNo, Pn1 Long, Pn2 Long, Codigo TEXT(20), Funcao TEXT(255), Aterrar Long, Comprimento Double, Trajeto TEXT(255), Instrucao TEXT(255), Diametro Double,  Grupo TEXT(50), Cabos Long, Criador TEXT(20), Data DATE)";
				object instance104 = obj;
				object[] array105 = new object[2] { text, false };
				array2 = array105;
				NewLateBinding.LateCall(instance104, null, "ExecuteNonQuery", array105, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE Cabos4 ADD PRIMARY KEY (Indice)";
				object instance105 = obj;
				object[] array106 = new object[2] { text, false };
				array2 = array106;
				NewLateBinding.LateCall(instance105, null, "ExecuteNonQuery", array106, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex37)
			{
				ProjectData.SetProjectError(ex37, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(67)";
				object instance106 = obj;
				object[] array107 = new object[1] { text };
				array2 = array107;
				NewLateBinding.LateCall(instance106, null, "ExecuteNonQuery", array107, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_130b;
			IL_1ff5:
			lErl = 80;
			try
			{
				text = "CREATE TABLE Aplicacao4F(Indice AUTOINCREMENT, Revisao TEXT(5), DWG Long, Numero Integer, Nome TEXT(150), Secao TEXT(20), Cor TEXT(20), TipoCabo TEXT(150), Isolacao TEXT(150))";
				object instance107 = obj;
				object[] array108 = new object[2] { text, false };
				array2 = array108;
				NewLateBinding.LateCall(instance107, null, "ExecuteNonQuery", array108, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE Aplicacao4F ADD PRIMARY KEY (Indice)";
				object instance108 = obj;
				object[] array109 = new object[2] { text, false };
				array2 = array109;
				NewLateBinding.LateCall(instance108, null, "ExecuteNonQuery", array109, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex38)
			{
				ProjectData.SetProjectError(ex38, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(80)";
				object instance109 = obj;
				object[] array110 = new object[1] { text };
				array2 = array110;
				NewLateBinding.LateCall(instance109, null, "ExecuteNonQuery", array110, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_20ff;
			IL_130b:
			lErl = 68;
			try
			{
				text = "CREATE TABLE Veias4(Indice AUTOINCREMENT, Revisao TEXT(5), Tag TEXT(50), Num_Veia Long, Nome_Veia TEXT(100), Uso YesNo)";
				object instance110 = obj;
				object[] array111 = new object[2] { text, false };
				array2 = array111;
				NewLateBinding.LateCall(instance110, null, "ExecuteNonQuery", array111, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE Veias4 ADD PRIMARY KEY (Indice)";
				object instance111 = obj;
				object[] array112 = new object[2] { text, false };
				array2 = array112;
				NewLateBinding.LateCall(instance111, null, "ExecuteNonQuery", array112, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex39)
			{
				ProjectData.SetProjectError(ex39, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(68)";
				object instance112 = obj;
				object[] array113 = new object[1] { text };
				array2 = array113;
				NewLateBinding.LateCall(instance112, null, "ExecuteNonQuery", array113, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_1415;
			IL_28f3:
			lErl = 91;
			try
			{
				text = "DROP TABLE SinaisLogico";
				object instance113 = obj;
				object[] array114 = new object[1] { text };
				array2 = array114;
				NewLateBinding.LateCall(instance113, null, "ExecuteNonQuery", array114, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "CREATE TABLE Sinais(Indice AUTOINCREMENT, ChavePrimaria TEXT(100), IndiceOrigem Integer, IndiceDestino Integer, TipoTag Integer, Tipo TEXT(30), Tag TEXT(100), Tag61850 TEXT(100), Enderecos61850 TEXT(100), TagAlternativoEntrada TEXT(100), Descricao TEXT(255), Caderno TEXT(100), Vao TEXT(100), Painel TEXT(150), Unidade TEXT(100),Pagina TEXT(30))";
				object instance114 = obj;
				object[] array115 = new object[1] { text };
				array2 = array115;
				NewLateBinding.LateCall(instance114, null, "ExecuteNonQuery", array115, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
				text = "ALTER TABLE Sinais ADD PRIMARY KEY (Indice)";
				object instance115 = obj;
				object[] array116 = new object[1] { text };
				array2 = array116;
				NewLateBinding.LateCall(instance115, null, "ExecuteNonQuery", array116, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex40)
			{
				ProjectData.SetProjectError(ex40, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(91)";
				object instance116 = obj;
				object[] array117 = new object[1] { text };
				array2 = array117;
				NewLateBinding.LateCall(instance116, null, "ExecuteNonQuery", array117, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_2a36;
			IL_1415:
			lErl = 69;
			try
			{
				text = "ALTER TABLE Cabos ALTER COLUMN Trajeto MEMO";
				object instance117 = obj;
				object[] array118 = new object[2] { text, false };
				array2 = array118;
				NewLateBinding.LateCall(instance117, null, "ExecuteNonQuery", array118, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex41)
			{
				ProjectData.SetProjectError(ex41, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(69)";
				object instance118 = obj;
				object[] array119 = new object[1] { text };
				array2 = array119;
				NewLateBinding.LateCall(instance118, null, "ExecuteNonQuery", array119, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_14cb;
			IL_20ff:
			lErl = 81;
			try
			{
				text = "ALTER TABLE Bornes4F ADD Orientacao TEXT(1)";
				object instance119 = obj;
				object[] array120 = new object[2] { text, false };
				array2 = array120;
				NewLateBinding.LateCall(instance119, null, "ExecuteNonQuery", array120, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex42)
			{
				ProjectData.SetProjectError(ex42, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(81)";
				object instance120 = obj;
				object[] array121 = new object[1] { text };
				array2 = array121;
				NewLateBinding.LateCall(instance120, null, "ExecuteNonQuery", array121, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_21b5;
			IL_14cb:
			lErl = 70;
			try
			{
				text = "ALTER TABLE Cabos4 ALTER COLUMN Trajeto MEMO";
				object instance121 = obj;
				object[] array122 = new object[2] { text, false };
				array2 = array122;
				NewLateBinding.LateCall(instance121, null, "ExecuteNonQuery", array122, null, null, new bool[2] { true, false }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			catch (Exception ex43)
			{
				ProjectData.SetProjectError(ex43, lErl);
				ProjectData.ClearProjectError();
			}
			finally
			{
				text = "Insert into Correcao(Numero) VALUES(70)";
				object instance122 = obj;
				object[] array123 = new object[1] { text };
				array2 = array123;
				NewLateBinding.LateCall(instance122, null, "ExecuteNonQuery", array123, null, null, new bool[1] { true }, IgnoreReturn: true);
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array2[0]), typeof(string));
			}
			goto IL_1581;
		}
		catch (Exception ex44)
		{
			ProjectData.SetProjectError(ex44, lErl);
			throw;
		}
		finally
		{
			NewLateBinding.LateCall(obj, null, "fechaConexao", new object[0], null, null, null, IgnoreReturn: true);
		}
	}
}
