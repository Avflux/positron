using System;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

public class clsImportarModelos
{
	public static bool CadernoEletron(string dwgFile)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected Obj, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected Obj, but got Unknown
		bool result = default;
		if (Operators.CompareString(dwgFile.Trim(), "", TextCompare: true) != 0)
		{
			result = false;
			Database val = new Database(false, true);
			try
			{
				val.ReadDwgFile(dwgFile, (FileOpenMode)3, false, "");
				Transaction val2 = (Transaction)(object)val.TransactionManager.StartOpenCloseTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(val.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					ResultBuffer xDataForApplication = ((DBObject)val4).GetXDataForApplication("Eletron");
					if (xDataForApplication != null)
					{
						result = true;
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					result = false;
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
		return result;
	}

	public static void CarregaModelosMascarasOutroCadreno(string dwgFile, ref Declaracoes2.MModeloDeMascara[] mMODELO)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected Obj, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		Database val = new Database(false, true);
		try
		{
			val.ReadDwgFile(dwgFile, (FileOpenMode)3, false, "");
			Transaction val2 = (Transaction)(object)val.TransactionManager.StartOpenCloseTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(val.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				mMODELO = new Declaracoes2.MModeloDeMascara[1];
				Database db = val;
				DicionarioMascaras.LeOsModelosDeMascarasSemAbrirDWG(ref mMODELO, bComplementarModelo: true, ref db);
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
	}

	public static void CarregaModelosContatosOutroCaderno(string dwgFile, ref Declaracoes2.MModelosDeContatos[] mMODELO)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected Obj, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		Database val = new Database(false, true);
		try
		{
			val.ReadDwgFile(dwgFile, (FileOpenMode)3, false, "");
			Transaction val2 = (Transaction)(object)val.TransactionManager.StartOpenCloseTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(val.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				mMODELO = new Declaracoes2.MModelosDeContatos[1];
				Database db = val;
				DicionarioContatos.LeOsModelosDeDeDicionarioContatosSemAbrirDWG(ref mMODELO, ref db);
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
	}

	public static void CarregaPortasOutroCadreno(string dwgFile, int iIndiceModelo, string NomeModelo, ref Declaracoes2.MModeloDePortas[] mPORTAS)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected Obj, but got Unknown
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected Obj, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		mPORTAS = new Declaracoes2.MModeloDePortas[1];
		Database val = new Database(false, true);
		try
		{
			val.ReadDwgFile(dwgFile, (FileOpenMode)3, false, "");
			Transaction val2 = (Transaction)(object)val.TransactionManager.StartOpenCloseTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(val.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Database db = val;
				DicionarioMascaras.LeAsPortasDoModeloDoDicionarioSemAbriDWG(ref iIndiceModelo, NomeModelo, ref mPORTAS, ref db);
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
	}

	public static void CarregaContatosAuxOutroCadreno(string dwgFile, int iIndiceModelo, string NomeModelo, ref Declaracoes2.StructureContatosAuxiliares[] mCONTATOS)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected Obj, but got Unknown
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected Obj, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		mCONTATOS = new Declaracoes2.StructureContatosAuxiliares[1];
		Database val = new Database(false, true);
		try
		{
			val.ReadDwgFile(dwgFile, (FileOpenMode)3, false, "");
			Transaction val2 = (Transaction)(object)val.TransactionManager.StartOpenCloseTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(val.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Database db = val;
				DicionarioContatos.LeOsContatosAuxiliarDoModeloDoDicionarioSemAbrirDWG(ref iIndiceModelo, ref mCONTATOS, ref db);
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
	}
}
