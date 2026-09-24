using System;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class clsEletron
{
	[CommandMethod("RecriaTextosCabo")]
	public static void RecriaTextosCabo(bool bApaga = false)
	{
		ApagarTodosOsTextosDasVeias(bApaga);
		clsEditarInterligacao.InsereTextosDeCabos(bPadraoEL: true);
		if (DeclaracoesGeral.Conf.InterligacaoLayout == 3)
		{
			clsUtilitarios.AtualizaTodosOpcionaisDoCabo();
		}
	}

	public static void ApagarTodosOsTextosDasVeias(bool bApaga)
	{
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected Obj, but got Unknown
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
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)1);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					short tipo = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity ent = (Entity)val2.GetObject(current, (OpenMode)1);
						DBText val5 = (DBText)(object)((ent is DBText) ? ent : null);
						string sHandle;
						if (val5 == null)
						{
							sHandle = "";
							if (XDataInterligacao.lerXDataAuxInterligacaoEletrosul(ref ent, ref sHandle) | XDataInterligacao.lerXDataAuxInterligacaoENEL(ref ent))
							{
								((DBObject)ent).Erase();
							}
							continue;
						}
						string handle = "";
						string THandle = "";
						Entity ent2 = (Entity)(object)val5;
						sHandle = "";
						bool flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent2, ref handle, ref tipo, ref THandle, ref sHandle);
						val5 = (DBText)ent2;
						if (!flag)
						{
							continue;
						}
						if (!((tipo == 1) | (tipo == 4) | (tipo == 5) | (tipo == 6)))
						{
							if (((tipo == 3) & (DeclaracoesGeral.Conf.InterligacaoLayout == 3)) | bApaga)
							{
								((DBObject)val5).Erase();
							}
						}
						else
						{
							((DBObject)val5).Erase();
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
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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
}
