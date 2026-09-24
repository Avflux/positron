using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

public class clsClonar
{
	public static void carregaTagsUsados(ref DeclaracoesClonar.structureTagsUsados[] mTagsUsados)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected Obj, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected Obj, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val3.GetEnumerator();
					int painel = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val4 = (Entity)val.GetObject(current, (OpenMode)0);
						BlockReference val5 = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
						if (val5 == null)
						{
							continue;
						}
						Entity ent = (Entity)(object)val5;
						string tipoImportado = "";
						string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
						val5 = (BlockReference)ent;
						string left = text;
						if (Operators.CompareString(left, "P", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left, "M", TextCompare: true) == 0)
							{
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val5);
								DeclaracoesEntidades.StructureMascara structureMascara = ((obj == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj));
								if (!structureMascara.Complementar)
								{
									int num = Information.UBound(mTagsUsados) + 1;
									mTagsUsados = (DeclaracoesClonar.structureTagsUsados[])Utils.CopyArray(mTagsUsados, new DeclaracoesClonar.structureTagsUsados[num + 1]);
									mTagsUsados[num].Painel = structureMascara.Painel;
									mTagsUsados[num].Nome1 = structureMascara.Nome1;
									mTagsUsados[num].Nome2 = structureMascara.Nome2;
									mTagsUsados[num].Alternativo = structureMascara.Alternativo;
								}
							}
						}
						else
						{
							BlockReference blockRef = (BlockReference)val4;
							object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							val4 = (Entity)(object)blockRef;
							DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj2 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj2));
							if (!structureDispositivo.Complementar)
							{
								int num2 = Information.UBound(mTagsUsados) + 1;
								mTagsUsados = (DeclaracoesClonar.structureTagsUsados[])Utils.CopyArray(mTagsUsados, new DeclaracoesClonar.structureTagsUsados[num2 + 1]);
								mTagsUsados[num2].Painel = structureDispositivo.Painel;
								mTagsUsados[num2].Nome1 = structureDispositivo.Nome1;
								mTagsUsados[num2].Nome2 = structureDispositivo.Nome2;
								mTagsUsados[num2].Alternativo = structureDispositivo.Alternativo;
							}
						}
						DeclaracoesTopografico.structureDispTopografico dTpg = default;
						if (XDataTopografico.lerXDataDispTopografico(ref val5, ref dTpg))
						{
							left = "TPGD";
							int num3 = Information.UBound(mTagsUsados) + 1;
							mTagsUsados = (DeclaracoesClonar.structureTagsUsados[])Utils.CopyArray(mTagsUsados, new DeclaracoesClonar.structureTagsUsados[num3 + 1]);
							mTagsUsados[num3].Painel = dTpg.painel;
							mTagsUsados[num3].Nome1 = dTpg.tag;
							mTagsUsados[num3].Nome2 = "";
							mTagsUsados[num3].Alternativo = dTpg.alternativo;
						}
						string tag = "";
						string alternativo = "";
						text = "";
						if (XDataLayout.lerXDataDispLayout(ref val5, ref painel, ref tag, ref alternativo, ref text))
						{
							left = "LAYD";
							int num4 = Information.UBound(mTagsUsados) + 1;
							mTagsUsados = (DeclaracoesClonar.structureTagsUsados[])Utils.CopyArray(mTagsUsados, new DeclaracoesClonar.structureTagsUsados[num4 + 1]);
							mTagsUsados[num4].Painel = painel;
							mTagsUsados[num4].Nome1 = tag;
							mTagsUsados[num4].Nome2 = "";
							mTagsUsados[num4].Alternativo = alternativo;
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				val.Abort();
				throw;
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static int BuscaIndexNaMatriz(ref DeclaracoesClonar.structureDispOrigem[] mDisp, string ID)
	{
		int result = 0;
		int num = Information.UBound(mDisp);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(mDisp[i].ID, ID, TextCompare: true) == 0)
			{
				result = i;
				break;
			}
		}
		return result;
	}

	public static bool leTagNaMatriz(ref DeclaracoesClonar.structureDispOrigem[] mDisp, ref string Nome1, ref string Nome2, ref string alternativo, int index)
	{
		bool result = false;
		if (!((Operators.CompareString(Nome1, mDisp[index].Nome1, TextCompare: true) == 0) & (Operators.CompareString(Nome2, mDisp[index].Nome2, TextCompare: true) == 0) & (Operators.CompareString(alternativo, mDisp[index].Alternativo, TextCompare: true) == 0)))
		{
			Nome1 = mDisp[index].Nome1;
			Nome2 = mDisp[index].Nome2;
			alternativo = mDisp[index].Alternativo;
		}
		else
		{
			result = true;
		}
		return result;
	}

	public static void AlteraNome(ref BlockReference blockRef, string Nome1, string Nome2, string Alternativo)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected Obj, but got Unknown
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				AttributeCollection attributeCollection = blockRef.AttributeCollection;
				bool flag = false;
				ObjectId val4;
				foreach (object item in attributeCollection)
				{
					val4 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
					AttributeReference val5 = (AttributeReference)val4.GetObject((OpenMode)1);
					if (Operators.CompareString(val5.Tag, "NOME2", TextCompare: true) == 0)
					{
						flag = true;
					}
				}
				if (!flag && Operators.CompareString(Nome2, "", TextCompare: true) != 0)
				{
					Nome1 = Nome1 + "/" + Nome2;
				}
				foreach (object item2 in attributeCollection)
				{
					val4 = ((item2 == null) ? default(ObjectId) : ((ObjectId)item2));
					AttributeReference val5 = (AttributeReference)val4.GetObject((OpenMode)1);
					string left = val5.Tag.ToUpper();
					if (Operators.CompareString(left, "NOME1", TextCompare: true) != 0 && Operators.CompareString(left, "NOME", TextCompare: true) != 0)
					{
						if (Operators.CompareString(left, "NOME2", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left, "ALTERNATIVO", TextCompare: true) != 0 && Operators.CompareString(left, "ALT", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "@LM", TextCompare: true) == 0)
								{
									((DBObject)val5).UpgradeOpen();
									((DBText)val5).TextString = "?";
								}
							}
							else
							{
								((DBObject)val5).UpgradeOpen();
								((DBText)val5).TextString = Alternativo;
							}
						}
						else
						{
							((DBObject)val5).UpgradeOpen();
							((DBText)val5).TextString = Nome2;
						}
					}
					else
					{
						((DBObject)val5).UpgradeOpen();
						((DBText)val5).TextString = Nome1;
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
