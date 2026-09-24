using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

public class clsVerificadorProjetoInterligacao
{
	public struct StructureJumper
	{
		public int iPotencial_Veia;

		public int indexCor;

		public int iPesoLinha;

		public string Secao;

		public string Cor_Nome;

		public string Handle;

		public int iTipo;

		public bool bPnApagado;
	}

	public struct StructurefiacaoErro
	{
		public string sValor;

		public int iPotencial;

		public string sCabo;
	}

	public static void buscaDadosDoDWG(ref StructureJumper[] mJumpers, ref StructureJumper[] mlig, ref List<string> lPnApagados)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected Obj, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected Obj, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected I4, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected I4, but got Unknown
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		mJumpers = new StructureJumper[1];
		int num2 = 0;
		mlig = new StructureJumper[1];
		new List<string>();
		DeclaracoesGeral.Reguas RH = default;
		DeclaracoesGeral.Reguas RH2 = default;
		XDataGeral.LeXDataReguaH(ref RH);
		XDataGeral.LeXDataReguaV(ref RH2);
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
							Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
							DeclaracoesEntidades.StructureConexao conex = default;
							if (pl == null)
							{
								continue;
							}
							if (XDataConexao.lerXDataConexao(ref pl, ref conex) && Operators.CompareString(conex.Jumper.ToUpper(), "JUMPER", TextCompare: true) == 0)
							{
								num++;
								mJumpers = (StructureJumper[])Utils.CopyArray(mJumpers, new StructureJumper[num + 1]);
								mJumpers[num].indexCor = ((Entity)pl).ColorIndex;
								unchecked
								{
									mJumpers[num].iPesoLinha = (int)((Entity)pl).LineWeight;
									mJumpers[num].Handle = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
									mJumpers[num].Cor_Nome = conex.Cor;
									mJumpers[num].Secao = conex.Secao;
									mJumpers[num].iPotencial_Veia = conex.Potencial;
									mJumpers[num].iTipo = conex.Tipo;
									if (lPnApagados.Contains(Conversions.ToString((int)conex.Painel)))
									{
										mJumpers[num].bPnApagado = true;
									}
								}
							}
							DeclaracoesEntidades.StructureInterligacao ilig = default;
							if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
							{
								num2++;
								mlig = (StructureJumper[])Utils.CopyArray(mlig, new StructureJumper[num2 + 1]);
								mlig[num2].indexCor = ((Entity)pl).ColorIndex;
								unchecked
								{
									mlig[num2].iPesoLinha = (int)((Entity)pl).LineWeight;
									mlig[num2].Handle = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
									mlig[num2].Cor_Nome = ilig.Tag_Cabo;
									mlig[num2].Secao = "";
									mlig[num2].iPotencial_Veia = ilig.NumVeia;
									if (lPnApagados.Contains(Conversions.ToString((int)ilig.Painel1)) | lPnApagados.Contains(Conversions.ToString((int)ilig.Painel2)))
									{
										mlig[num2].bPnApagado = true;
									}
								}
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					cDadosAccess.carregaDadosDWG();
					CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
					ClsCabos.StructureCabo[] mCabosCaderno = new ClsCabos.StructureCabo[1];
					cDadosAccessInterligacao3.LeTodosOsCabosUsadosNesteCaderno(ref mCabosCaderno, DeclaracoesGeral.arqAtivo.Indice, bProgress: false);
					cDadosAccessInterligacao3.FechaConexao();
					int num3 = Information.UBound(mlig);
					for (int i = 1; i <= num3; i++)
					{
						int num4 = Information.UBound(mCabosCaderno);
						for (int j = 1; j <= num4; j++)
						{
							if (Operators.CompareString(mlig[i].Cor_Nome, mCabosCaderno[j].sTag, TextCompare: true) == 0)
							{
								mlig[i].Secao = mCabosCaderno[j].sFormacao;
							}
						}
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					val2.Abort();
					ProjectData.ClearProjectError();
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void PintaJumper(ref StructureJumper[] mJumper, int icor = 0)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
						DeclaracoesEntidades.StructureConexao conex = default;
						if (pl == null || !XDataConexao.lerXDataConexao(ref pl, ref conex) || Operators.CompareString(conex.Jumper, "JUMPER", TextCompare: true) != 0)
						{
							continue;
						}
						if (icor != 0)
						{
							((DBObject)pl).UpgradeOpen();
							((Entity)pl).ColorIndex = icor;
							((Entity)pl).LineWeight = (LineWeight)30;
							continue;
						}
						int num = Information.UBound(mJumper);
						for (int i = 1; i <= num; i = checked(i + 1))
						{
							if (Operators.CompareString(mJumper[i].Handle, ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString(), TextCompare: true) == 0)
							{
								((DBObject)pl).UpgradeOpen();
								((Entity)pl).ColorIndex = mJumper[i].indexCor;
								((Entity)pl).LineWeight = (LineWeight)mJumper[i].iPesoLinha;
								break;
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				val2.Abort();
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void PintaInterlig(ref StructureJumper[] mIlig, int icor = 0)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
						if (pl == null)
						{
							continue;
						}
						DeclaracoesEntidades.StructureInterligacao ilig = default;
						if (!XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
						{
							continue;
						}
						if (icor != 0)
						{
							((DBObject)pl).UpgradeOpen();
							((Entity)pl).ColorIndex = icor;
							((Entity)pl).LineWeight = (LineWeight)30;
							continue;
						}
						int num = Information.UBound(mIlig);
						for (int i = 1; i <= num; i = checked(i + 1))
						{
							if (Operators.CompareString(mIlig[i].Handle, ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString(), TextCompare: true) == 0)
							{
								((DBObject)pl).UpgradeOpen();
								((Entity)pl).ColorIndex = mIlig[i].indexCor;
								((Entity)pl).LineWeight = (LineWeight)mIlig[i].iPesoLinha;
								break;
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				val2.Abort();
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void carregaTree(ref TreeView tree, StructureJumper[] mJumpers, StructureJumper[] mlig, List<string> lPnApagado, List<string> LFiacaoTTDuplicada)
	{
		tree.Nodes.Clear();
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		int num = 0;
		StructurefiacaoErro[] array = new StructurefiacaoErro[1];
		List<int> list3 = new List<int>();
		checked
		{
			if (Information.UBound(mJumpers) > 0)
			{
				list.Clear();
				int num2 = Information.UBound(mJumpers);
				for (int i = 1; i <= num2; i++)
				{
					string text = mJumpers[i].Cor_Nome + " - " + mJumpers[i].Secao;
					if (((Operators.CompareString(mJumpers[i].Cor_Nome.Trim(), "", TextCompare: true) == 0) | (Operators.CompareString(mJumpers[i].Secao.Trim(), "", TextCompare: true) == 0) | mJumpers[i].bPnApagado) && !list3.Contains(mJumpers[i].iPotencial_Veia) && !list2.Contains(mJumpers[i].iPotencial_Veia.ToString()))
					{
						num++;
						array = (StructurefiacaoErro[])Utils.CopyArray(array, new StructurefiacaoErro[num + 1]);
						array[num].sValor = text;
						array[num].iPotencial = mJumpers[i].iPotencial_Veia;
						list3.Add(mJumpers[i].iPotencial_Veia);
						list2.Add(mJumpers[i].iPotencial_Veia.ToString());
					}
					if (!list.Contains(text) && Operators.CompareString(text.Trim(), "", TextCompare: true) != 0)
					{
						list.Add(text);
					}
				}
				list.Sort();
				TreeNode treeNode = (TreeNode)NewLateBinding.LateGet(tree.Nodes, null, "Add", new object[1] { Operators.ConcatenateObject("  ", DeclaracoesGeral.mMensagem[1, 703]) }, null, null, null);
				treeNode.Name = Conversions.ToString(Operators.ConcatenateObject("  ", DeclaracoesGeral.mMensagem[1, 703]));
				foreach (string item in list)
				{
					TreeNode treeNode2 = treeNode.Nodes.Add(item);
					treeNode2.Name = item;
				}
				int num3 = Information.UBound(array);
				for (int j = 1; j <= num3; j++)
				{
					string text2 = Conversions.ToString(array[j].iPotencial);
					object instance = NewLateBinding.LateGet(tree.Nodes, null, "Item", new object[1] { Operators.ConcatenateObject("  ", DeclaracoesGeral.mMensagem[1, 703]) }, null, null, null);
					object[] array2 = new object[1];
					ref string sValor = ref array[j].sValor;
					ref string reference = ref sValor;
					array2[0] = sValor;
					object[] array3 = array2;
					object instance2 = NewLateBinding.LateGet(instance, null, "Nodes", array2, null, null, new bool[1] { true });
					reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
					object[] array4;
					object obj = NewLateBinding.LateGet(NewLateBinding.LateGet(instance2, null, "Nodes", new object[0], null, null, null), null, "Add", array4 = new object[1] { text2 }, null, null, new bool[1] { true });
					text2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
					TreeNode treeNode3 = (TreeNode)obj;
					treeNode3.ForeColor = Color.Red;
				}
				if (LFiacaoTTDuplicada.Count > 0)
				{
					TreeNode treeNode4 = (TreeNode)NewLateBinding.LateGet(treeNode.Nodes, null, "Add", new object[1] { Operators.ConcatenateObject(" ", DeclaracoesGeral.mMensagem[1, 1567]) }, null, null, null);
					treeNode4.Name = Conversions.ToString(Operators.ConcatenateObject(" ", DeclaracoesGeral.mMensagem[1, 1567]));
				}
				foreach (string LFiacaoTTDuplicadum in LFiacaoTTDuplicada)
				{
					object[] array4;
					object obj = NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(tree.Nodes, null, "Item", new object[1] { Operators.ConcatenateObject("  ", DeclaracoesGeral.mMensagem[1, 703]) }, null, null, null), null, "Nodes", new object[1] { Operators.ConcatenateObject(" ", DeclaracoesGeral.mMensagem[1, 1567]) }, null, null, null), null, "Nodes", new object[0], null, null, null), null, "Add", array4 = new object[1] { LFiacaoTTDuplicadum }, null, null, new bool[1] { true });
					string current2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
					TreeNode treeNode5 = (TreeNode)obj;
					treeNode5.ForeColor = Color.Red;
				}
				tree.Sort();
			}
			int num4 = 0;
			StructurefiacaoErro[] array5 = new StructurefiacaoErro[1];
			List<string> list4 = new List<string>();
			if (Information.UBound(mlig) > 0)
			{
				list.Clear();
				int num5 = Information.UBound(mlig);
				for (int k = 1; k <= num5; k++)
				{
					string text3 = mlig[k].Secao;
					if ((Operators.CompareString(mlig[k].Cor_Nome, "", TextCompare: true) == 0) | mlig[k].bPnApagado)
					{
						text3 = Conversions.ToString(NewLateBinding.LateGet(DeclaracoesGeral.mMensagem[1, 740], null, "ToUpper", new object[0], null, null, null));
					}
					if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(text3, NewLateBinding.LateGet(DeclaracoesGeral.mMensagem[1, 740], null, "ToUpper", new object[0], null, null, null), TextCompare: true), mlig[k].bPnApagado)) && !list2.Contains(mlig[k].Handle.ToString()))
					{
						num4++;
						array5 = (StructurefiacaoErro[])Utils.CopyArray(array5, new StructurefiacaoErro[num4 + 1]);
						array5[num4].sValor = text3;
						array5[num4].sCabo = mlig[k].Handle;
						list4.Add(mlig[k].Handle);
						list2.Add(mlig[k].Handle.ToString());
					}
					if (!list.Contains(text3) && Operators.CompareString(text3.Trim(), "", TextCompare: true) != 0)
					{
						list.Add(text3);
					}
				}
				list.Sort();
				TreeNode treeNode = (TreeNode)NewLateBinding.LateGet(tree.Nodes, null, "Add", new object[1] { Operators.ConcatenateObject(" ", DeclaracoesGeral.mMensagem[1, 508]) }, null, null, null);
				treeNode.Name = Conversions.ToString(Operators.ConcatenateObject(" ", DeclaracoesGeral.mMensagem[1, 508]));
				foreach (string item2 in list)
				{
					TreeNode treeNode6 = treeNode.Nodes.Add(item2);
					treeNode6.Name = item2;
				}
				int num6 = Information.UBound(array5);
				for (int l = 1; l <= num6; l++)
				{
					string sCabo = array5[l].sCabo;
					object instance3 = NewLateBinding.LateGet(tree.Nodes, null, "Item", new object[1] { Operators.ConcatenateObject(" ", DeclaracoesGeral.mMensagem[1, 508]) }, null, null, null);
					object[] array6 = new object[1];
					ref string sValor2 = ref array5[l].sValor;
					ref string reference = ref sValor2;
					array6[0] = sValor2;
					object[] array3 = array6;
					object instance2 = NewLateBinding.LateGet(instance3, null, "Nodes", array6, null, null, new bool[1] { true });
					reference = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
					object[] array4;
					object obj = NewLateBinding.LateGet(NewLateBinding.LateGet(instance2, null, "Nodes", new object[0], null, null, null), null, "Add", array4 = new object[1] { sCabo }, null, null, new bool[1] { true });
					sCabo = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array4[0]), typeof(string));
					TreeNode treeNode7 = (TreeNode)obj;
					treeNode7.ForeColor = Color.Red;
				}
				tree.Sort();
			}
			tree.ExpandAll();
		}
	}

	public static void mostraIndefinidos(string sPotencial)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected Obj, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected Obj, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected Obj, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Expected Obj, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected Obj, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected Obj, but got Unknown
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		clsBlocos.Unhighlight();
		string text = "";
		bool flag = false;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						if (Operators.CompareString(((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString(), sPotencial, TextCompare: true) != 0)
						{
							continue;
						}
						Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
						if (pl == null)
						{
							continue;
						}
						DeclaracoesEntidades.StructureInterligacao ilig = default;
						string pag;
						if (!XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
						{
							DeclaracoesEntidades.StructureConexao conex = default;
							if (XDataConexao.lerXDataConexao(ref pl, ref conex))
							{
								if (Operators.CompareString(text, "", TextCompare: true) == 0)
								{
									text = ((Entity)pl).Layer;
								}
								if (Operators.CompareString(DeclaracoesGeral.ativo.Pagina, text, TextCompare: true) != 0)
								{
									Pagina.AtivaPagina(((Entity)pl).Layer);
									uscPaginas uscPagina = DeclaracoesGeral._uscPagina;
									pag = ((Entity)pl).Layer.ToString();
									uscPagina.ativaPaginaAtalho(ref pag);
								}
								if (Operators.CompareString(text, ((Entity)pl).Layer, TextCompare: true) == 0)
								{
									Caderno.AtivaHighlightFolhaConexJumper(text, conex.Potencial);
									((Entity)pl).Highlight();
									flag = true;
									break;
								}
							}
							continue;
						}
						Pagina.AtivaPagina(((Entity)pl).Layer);
						uscPaginas uscPagina2 = DeclaracoesGeral._uscPagina;
						pag = ((Entity)pl).Layer.ToString();
						uscPagina2.ativaPaginaAtalho(ref pag);
						Caderno.ZEntity(((DBObject)pl).ObjectId, 10);
						((Entity)pl).Highlight();
						flag = true;
						break;
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		if (flag)
		{
			return;
		}
		DocumentLock val6 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database2 = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val7 = database2.TransactionManager.StartTransaction();
			try
			{
				BlockTable val8 = (BlockTable)val7.GetObject(database2.BlockTableId, (OpenMode)0);
				BlockTableRecord val9 = (BlockTableRecord)val7.GetObject(((SymbolTable)val8)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator2 = default;
				try
				{
					enumerator2 = val9.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						ObjectId current2 = enumerator2.Current;
						Entity val10 = (Entity)val7.GetObject(current2, (OpenMode)0);
						Polyline pl2 = (Polyline)(object)((val10 is Polyline) ? val10 : null);
						DeclaracoesEntidades.StructureConexao conex2 = default;
						if (pl2 == null || !XDataConexao.lerXDataConexao(ref pl2, ref conex2) || Operators.CompareString(conex2.Potencial.ToString(), sPotencial, TextCompare: true) != 0)
						{
							continue;
						}
						if (Operators.CompareString(text, "", TextCompare: true) == 0)
						{
							text = ((Entity)pl2).Layer;
						}
						if (Operators.CompareString(text, ((Entity)pl2).Layer, TextCompare: true) == 0)
						{
							Pagina.AtivaPagina(((Entity)pl2).Layer);
							uscPaginas uscPagina3 = DeclaracoesGeral._uscPagina;
							string pag = ((Entity)pl2).Layer.ToString();
							uscPagina3.ativaPaginaAtalho(ref pag);
							if (conex2.Tipo != 3)
							{
								Caderno.ZEntity(((DBObject)pl2).ObjectId, 10);
							}
							((Entity)pl2).Highlight();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator2)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val7.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				val7.Abort();
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val7)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val6)?.Dispose();
		}
	}

	public static void IndefineCabosNaoExistentes(List<string> lCabos)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected Obj, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected Obj, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected Obj, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected Obj, but got Unknown
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected Obj, but got Unknown
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected Obj, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected Obj, but got Unknown
		List<string> list = new List<string>();
		if (lCabos.Count <= 0)
		{
			return;
		}
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
						if (pl != null)
						{
							DeclaracoesEntidades.StructureInterligacao ilig = default;
							if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) && !lCabos.Contains(ilig.Tag_Cabo))
							{
								ilig.Tag_Cabo = "";
								ilig.NumVeia = -1000;
								ilig.NomeVeia = "";
								ilig.ocultaTag = 0;
								((DBObject)pl).UpgradeOpen();
								XDataInterligacao.AtualizaXDataInterligacao(ref pl, ref ilig);
								list.Add(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				val2.Abort();
				throw;
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		try
		{
			DocumentLock val6 = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database2 = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val7 = database2.TransactionManager.StartTransaction();
				try
				{
					BlockTable val8 = (BlockTable)val7.GetObject(database2.BlockTableId, (OpenMode)0);
					BlockTableRecord val9 = (BlockTableRecord)val7.GetObject(((SymbolTable)val8)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator2 = default;
					try
					{
						enumerator2 = val9.GetEnumerator();
						short tipo = default;
						while (enumerator2.MoveNext())
						{
							ObjectId current2 = enumerator2.Current;
							Entity val10 = (Entity)val7.GetObject(current2, (OpenMode)0);
							DBText val11 = (DBText)(object)((val10 is DBText) ? val10 : null);
							if (val11 != null)
							{
								string handle = "";
								string THandle = "";
								Entity ent = (Entity)(object)val11;
								string sOpcionais = "";
								bool flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle, ref tipo, ref THandle, ref sOpcionais);
								val11 = (DBText)ent;
								if (flag && tipo == 1)
								{
									((DBObject)val11).UpgradeOpen();
									val11.TextString = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
								}
							}
						}
					}
					finally
					{
						((IDisposable)enumerator2)?.Dispose();
					}
					DeclaracoesGeral.bAnularEventos = true;
					val7.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception projectError2)
				{
					ProjectData.SetProjectError(projectError2);
					val7.Abort();
					throw;
				}
				finally
				{
					((IDisposable)val7)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val6)?.Dispose();
			}
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			ProjectData.ClearProjectError();
		}
	}
}
