using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

public class clsDispositivoTacito
{
	public static void carregaTodosDispositivosLayout(ref DataTable varTable, ref bool bAlternativo)
	{
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected Obj, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected Obj, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected Obj, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected Obj, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		varTable.Columns.Add("Painel", typeof(int));
		varTable.Columns.Add("Tag", typeof(string));
		varTable.Columns.Add("Alternativo", typeof(string));
		varTable.Columns.Add("Handle", typeof(string));
		bAlternativo = false;
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
						BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						if (val6 == null)
						{
							continue;
						}
						Entity ent = (Entity)(object)val6;
						string tipoImportado = "";
						string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
						val6 = (BlockReference)ent;
						string text2 = text;
						string left = text2;
						if (Operators.CompareString(left, "M", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left, "P", TextCompare: true) != 0)
							{
								continue;
							}
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
							DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
							if (!structureDispositivo.Complementar)
							{
								string text3 = structureDispositivo.Nome1;
								if (Operators.CompareString(structureDispositivo.Nome2, "", TextCompare: true) != 0)
								{
									text3 = text3 + "/" + structureDispositivo.Nome2;
								}
								DataRow dataRow = varTable.NewRow();
								dataRow["Painel"] = structureDispositivo.Painel;
								dataRow["Tag"] = text3;
								dataRow["Alternativo"] = structureDispositivo.Alternativo;
								if (Operators.CompareString(structureDispositivo.Alternativo.Trim(), "", TextCompare: true) != 0)
								{
									bAlternativo = true;
								}
								dataRow["Handle"] = ((DBObject)val6).Handle;
								varTable.Rows.Add(dataRow);
							}
							continue;
						}
						object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
						DeclaracoesEntidades.StructureMascara structureMascara = ((obj2 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj2));
						if (!structureMascara.Complementar)
						{
							string text4 = structureMascara.Nome1;
							if (Operators.CompareString(structureMascara.Nome2, "", TextCompare: true) != 0)
							{
								text4 = text4 + "/" + structureMascara.Nome2;
							}
							DataRow dataRow2 = varTable.NewRow();
							dataRow2["Painel"] = structureMascara.Painel;
							dataRow2["Tag"] = text4;
							dataRow2["Alternativo"] = structureMascara.Alternativo;
							if (Operators.CompareString(structureMascara.Alternativo.Trim(), "", TextCompare: true) != 0)
							{
								bAlternativo = true;
							}
							dataRow2["Handle"] = ((DBObject)val6).Handle;
							varTable.Rows.Add(dataRow2);
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
	}

	public static Dictionary<string, string> carregaNomeDispositivosPM(int painel)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected Obj, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected Obj, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
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
						BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						if (val6 == null)
						{
							continue;
						}
						Entity ent = (Entity)(object)val6;
						string tipoImportado = "";
						string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
						val6 = (BlockReference)ent;
						string text2 = text;
						string left = text2;
						if (Operators.CompareString(left, "M", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left, "P", TextCompare: true) != 0)
							{
								continue;
							}
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
							DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
							if (!structureDispositivo.Complementar && structureDispositivo.Painel == painel)
							{
								string text3 = structureDispositivo.Nome1;
								if (Operators.CompareString(structureDispositivo.Nome2, "", TextCompare: true) != 0)
								{
									text3 = text3 + "/" + structureDispositivo.Nome2;
								}
								dictionary.Add(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString(), text3);
							}
							continue;
						}
						object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
						DeclaracoesEntidades.StructureMascara structureMascara = ((obj2 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj2));
						if (!structureMascara.Complementar && structureMascara.Painel == painel)
						{
							string text4 = structureMascara.Nome1;
							if (Operators.CompareString(structureMascara.Nome2, "", TextCompare: true) != 0)
							{
								text4 = text4 + "/" + structureMascara.Nome2;
							}
							dictionary.Add(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString(), text4);
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
		return dictionary;
	}

	public static Dictionary<string, string> carregaAlternativoDispositivosPM(int painel)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected Obj, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected Obj, but got Unknown
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
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
						BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						if (val6 == null)
						{
							continue;
						}
						Entity ent = (Entity)(object)val6;
						string tipoImportado = "";
						string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
						val6 = (BlockReference)ent;
						string text2 = text;
						string left = text2;
						if (Operators.CompareString(left, "M", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left, "P", TextCompare: true) == 0)
							{
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
								DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
								if (!structureDispositivo.Complementar && structureDispositivo.Painel == painel)
								{
									string alternativo = structureDispositivo.Alternativo;
									dictionary.Add(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString(), alternativo);
								}
							}
						}
						else
						{
							object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
							DeclaracoesEntidades.StructureMascara structureMascara = ((obj2 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj2));
							if (!structureMascara.Complementar && structureMascara.Painel == painel)
							{
								string alternativo2 = structureMascara.Alternativo;
								dictionary.Add(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString(), alternativo2);
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
		return dictionary;
	}

	public static void carregaModelosUsadosBobinas(ref List<int> lModelosEmUso, ref List<int> lPaineis)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected Obj, but got Unknown
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
						BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						if (val6 == null)
						{
							continue;
						}
						Entity ent = (Entity)(object)val6;
						string tipoImportado = "";
						string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
						val6 = (BlockReference)ent;
						string left = text;
						if (Operators.CompareString(left, "P", TextCompare: true) == 0)
						{
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
							DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
							if (!structureDispositivo.Complementar && structureDispositivo.indexModelo > 0 && lPaineis.Contains(structureDispositivo.Painel) && !lModelosEmUso.Contains(structureDispositivo.indexModelo))
							{
								lModelosEmUso.Add(structureDispositivo.indexModelo);
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
	}

	public static void carregaModelosUsadosMascaras(ref List<int> lModelosEmUso, ref List<int> lPaineis)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected Obj, but got Unknown
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
						BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						if (val6 == null)
						{
							continue;
						}
						Entity ent = (Entity)(object)val6;
						string tipoImportado = "";
						string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
						val6 = (BlockReference)ent;
						string left = text;
						if (Operators.CompareString(left, "M", TextCompare: true) == 0)
						{
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
							DeclaracoesEntidades.StructureMascara structureMascara = ((obj == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj));
							if (!structureMascara.Complementar && structureMascara.indexModelo > 0 && lPaineis.Contains(structureMascara.Painel) && !lModelosEmUso.Contains(structureMascara.indexModelo))
							{
								lModelosEmUso.Add(structureMascara.indexModelo);
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
	}

	public static string carregaTerminaisBobinas(int modelo, ref List<int> lPaineis)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected Obj, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected Obj, but got Unknown
		string result = "";
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
						BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						if (val6 == null)
						{
							continue;
						}
						Entity ent = (Entity)(object)val6;
						string tipoImportado = "";
						string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
						val6 = (BlockReference)ent;
						string left = text;
						if (Operators.CompareString(left, "P", TextCompare: true) == 0)
						{
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
							DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
							if (!structureDispositivo.Complementar && structureDispositivo.indexModelo == modelo && lPaineis.Contains(structureDispositivo.Painel))
							{
								result = clsDispositivo.BuscaTerminaisTipoTdoBloco(val6);
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
		return result;
	}

	public static void exportaPlaquetas()
	{
		cDadosAccess.carregaDadosDWG();
		Declaracoes2.StructurePlaquetas[] mPlaquetas = new Declaracoes2.StructurePlaquetas[1];
		List<int> lEquip = new List<int>();
		clsConexao.carregaEquipComFiacao(ref lEquip);
		Declaracoes2.StructureModeloDeReguas[] mModelo = new Declaracoes2.StructureModeloDeReguas[1];
		DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		cDadosAccessFiacao2.RemovePlaquetas(DeclaracoesGeral.arqAtivo.Indice);
		DeclaracoesGeral._uscPagina.Quantidade = DeclaracoesGeral.dicPainel.Count;
		DeclaracoesGeral._uscPagina.pbIniciar();
		checked
		{
			try
			{
				foreach (int key in DeclaracoesGeral.dicPainel.Keys)
				{
					DeclaracoesGeral._uscPagina.pbPasso();
					if (!lEquip.Contains(key))
					{
						continue;
					}
					int painel = key;
					string nome = DeclaracoesGeral.dicPainel[key];
					Dictionary<string, string> dictionary = carregaNomeDispositivosPM(painel);
					if (!DicionarioPlaqueta.ExisteDicPlaquetaPainel(painel.ToString()))
					{
						continue;
					}
					DicionarioPlaqueta.LeDicPlaquetas(painel.ToString(), ref mPlaquetas);
					int num = Information.UBound(mPlaquetas);
					for (int i = 0; i <= num; i++)
					{
						string tipo = mPlaquetas[i].Tipo;
						if (Operators.CompareString(tipo, "P", TextCompare: true) != 0)
						{
							if (Operators.CompareString(tipo, "D", TextCompare: true) != 0)
							{
								if (Operators.CompareString(tipo, "X", TextCompare: true) != 0)
								{
									if (Operators.CompareString(tipo, "R", TextCompare: true) == 0)
									{
										int num2 = Information.UBound(mModelo);
										for (int j = 1; j <= num2; j++)
										{
											if (mModelo[j].indexRegua == mPlaquetas[i].IndiceRegua)
											{
												mPlaquetas[i].Nome = mModelo[j].nomeRegua;
												break;
											}
										}
									}
								}
								else
								{
									string text = mPlaquetas[i].Desc1;
									if (Operators.CompareString(text.Trim(), "", TextCompare: true) == 0)
									{
										text = mPlaquetas[i].Desc2;
									}
									if (Operators.CompareString(text.Trim(), "", TextCompare: true) == 0)
									{
										text = mPlaquetas[i].Desc3;
									}
									mPlaquetas[i].Nome = text;
									mPlaquetas[i].Ordem = Conversions.ToInteger(mPlaquetas[i].Handle.Replace("#", ""));
								}
							}
							else if (dictionary.ContainsKey(mPlaquetas[i].Handle))
							{
								mPlaquetas[i].Nome = dictionary[mPlaquetas[i].Handle];
							}
						}
						else
						{
							mPlaquetas[i].Nome = nome;
						}
						if ((Operators.CompareString(mPlaquetas[i].Nome, "", TextCompare: true) != 0) & ((Operators.CompareString(mPlaquetas[i].Desc1, "", TextCompare: true) != 0) | (Operators.CompareString(mPlaquetas[i].Desc2, "", TextCompare: true) != 0) | (Operators.CompareString(mPlaquetas[i].Desc3, "", TextCompare: true) != 0)))
						{
							cDadosAccessFiacao2.AdicionaItemPlaqueta(DeclaracoesGeral.arqAtivo.Indice, painel, mPlaquetas[i]);
						}
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
				DeclaracoesGeral._uscPagina.pbFim();
				cDadosAccessFiacao2.fechaConexao();
			}
		}
	}

	public static void editaLayoutRapido(string pn, string tagOriginal, string tagNovo, string alternativo)
	{
		DeclaracoesEntidades.StructureLayout[] mTags = new DeclaracoesEntidades.StructureLayout[1];
		checked
		{
			if (DicionarioLayout.LeDicLayout("P" + pn, ref mTags))
			{
				int num = Information.UBound(mTags);
				for (int i = 0; i <= num; i++)
				{
					if (Operators.CompareString(mTags[i].Tag, tagOriginal, TextCompare: true) == 0)
					{
						mTags[i].Tag = tagNovo;
						mTags[i].Alternativo = alternativo;
						break;
					}
				}
				DicionarioLayout.ApagaDicLayoutPainel("P", pn);
				DicionarioLayout.gravaDicLayout("P" + pn, ref mTags);
			}
			DeclaracoesEntidades.StructureLayout[] mTags2 = new DeclaracoesEntidades.StructureLayout[1];
			if (!DicionarioLayout.LeDicLayout("C" + pn, ref mTags2))
			{
				return;
			}
			int num2 = Information.UBound(mTags2);
			for (int j = 0; j <= num2; j++)
			{
				if (Operators.CompareString(mTags2[j].Tag, tagOriginal, TextCompare: true) == 0)
				{
					mTags2[j].Tag = tagNovo;
					mTags2[j].Alternativo = alternativo;
					break;
				}
			}
			DicionarioLayout.ApagaDicLayoutPainel("C", pn);
			DicionarioLayout.gravaDicLayout("C" + pn, ref mTags2);
		}
	}
}
