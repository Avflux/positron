using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class clsRelatorio_Elektro
{
	public struct mRelatElektro
	{
		public string sNomeModelo;

		public string sNome1;

		public string sNome2;

		public string sAlternativo;

		public string iPN;

		public string sPN;

		public int iIndexModelo;

		public string sHandleDaMascara;

		public string sChave;

		public int iIndexPorta;

		public string sUnidade;

		public string sTipo;

		public string sEFC;

		public string sTerminais;

		public string sRegua;

		public string sBornes;

		public bool bUso;

		public string sPaginaPorta;

		public string sHandlePorta;

		public string DescricaoC;

		public string DescricaoR;
	}

	public struct ConfElektro
	{
		public int iColuna;

		public int iIndiceUnico;

		public int iPainel;

		public string sDisp;

		public string sTipo;

		public string sUnidade;
	}

	public static void PesquisaTodasAsPortasEDefinicoesUsadas(ref mRelatElektro[] mRelatElektro)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Expected Obj, but got Unknown
		//IL_03e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Expected Obj, but got Unknown
		//IL_054d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DeclaracoesGeral.Reguas RH = default;
				bool flag = false;
				DeclaracoesGeral.Reguas RH2 = default;
				bool flag2 = false;
				flag = XDataGeral.LeXDataReguaH(ref RH);
				flag2 = XDataGeral.LeXDataReguaV(ref RH2);
				BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
				long num = 0L;
				num = clsBlocos.AcadObjectCount();
				mRelatElektro = (mRelatElektro[])Utils.CopyArray(mRelatElektro, new mRelatElektro[1]);
				PortaRelElektro[] mPortas = new PortaRelElektro[1];
				cDadosExcel cDadosExcel2 = new cDadosExcel();
				cDadosExcel2.ImportarDadosRelatorioElektro(ref mPortas);
				cDadosExcel2.fechaConexao();
				Declaracoes2.MMascara[] mMasc = new Declaracoes2.MMascara[1];
				clsMascara.CarregaMascaras(ref mMasc);
				num += Information.UBound(mMasc);
				DeclaracoesGeral._uscPagina.Quantidade = (int)num;
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num2 = 0;
				Declaracoes2.MMascara[] array = mMasc;
				for (int i = 0; i < array.Length; i++)
				{
					Declaracoes2.MMascara mMascara = array[i];
					string sNomeModelo = mMascara.sNome1;
					if (Operators.CompareString(mMascara.sNome2, "", TextCompare: true) != 0)
					{
						sNomeModelo = mMascara.sNome1 + "/" + mMascara.sNome2;
					}
					if (mMascara.iIndiceModelo <= 0)
					{
						continue;
					}
					Declaracoes2.MModeloDePortas[] mPortas2 = new Declaracoes2.MModeloDePortas[1];
					DicionarioMascaras.LeAsPortasDoModeloDoDicionario(ref mMascara.iIndiceModelo, sNomeModelo, ref mPortas2);
					Declaracoes2.MModeloDePortas[] array2 = mPortas2;
					for (int j = 0; j < array2.Length; j++)
					{
						Declaracoes2.MModeloDePortas mModeloDePortas = array2[j];
						if (mModeloDePortas.IndiceDaPorta > 0)
						{
							int num3 = Information.UBound(mRelatElektro) + 1;
							mRelatElektro = (mRelatElektro[])Utils.CopyArray(mRelatElektro, new mRelatElektro[num3 + 1]);
							mRelatElektro[num3].sNomeModelo = sNomeModelo;
							mRelatElektro[num3].sNome1 = mMascara.sNome1;
							mRelatElektro[num3].sNome2 = mMascara.sNome2;
							mRelatElektro[num3].sAlternativo = mMascara.sNome3;
							mRelatElektro[num3].iPN = Conversions.ToString(mMascara.iPainel);
							mRelatElektro[num3].sPN = mMascara.sPainel;
							mRelatElektro[num3].iIndexModelo = mMascara.iIndiceModelo;
							mRelatElektro[num3].sHandleDaMascara = mMascara.sHandle;
							mRelatElektro[num3].iIndexPorta = mModeloDePortas.IndiceDaPorta;
							mRelatElektro[num3].sEFC = mModeloDePortas.sEFC;
							mRelatElektro[num3].sTerminais = mModeloDePortas.sTerminais;
							mRelatElektro[num3].sRegua = mModeloDePortas.sRegua;
							mRelatElektro[num3].sBornes = mModeloDePortas.sBornes;
							mRelatElektro[num3].bUso = false;
							mRelatElektro[num3].sPaginaPorta = "";
							mRelatElektro[num3].sHandlePorta = "";
							mRelatElektro[num3].sChave = "";
							mRelatElektro[num3].DescricaoC = "";
							mRelatElektro[num3].DescricaoR = "";
						}
					}
					num2++;
					if (num2 == 100)
					{
						DeclaracoesGeral._uscPagina.pbPasso(num2);
						num2 = 0;
					}
				}
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val3.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						num2++;
						if (num2 == 100)
						{
							DeclaracoesGeral._uscPagina.pbPasso(num2);
							num2 = 0;
						}
						Entity ent = (Entity)val.GetObject(current, (OpenMode)0);
						if (!(ent is BlockReference))
						{
							continue;
						}
						BlockReference val4 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
						if (val4 == null)
						{
							continue;
						}
						Entity ent2 = (Entity)(object)val4;
						string tipoImportado = "";
						string text = XDataDispositivo.verificaTipoDispositivo(ref ent2, ref tipoImportado);
						val4 = (BlockReference)ent2;
						string left = text;
						if (Operators.CompareString(left, "E", TextCompare: true) != 0)
						{
							continue;
						}
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val4);
						DeclaracoesEntidades.StructurePortas structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
						int num4 = Information.UBound(mRelatElektro);
						for (int k = 1; k <= num4; k++)
						{
							if (((structurePortas.indiceDoModelo == mRelatElektro[k].iIndexModelo) & (structurePortas.indiceDaPorta == mRelatElektro[k].iIndexPorta)) && ((Operators.CompareString(structurePortas.Nome1, mRelatElektro[k].sNome1, TextCompare: true) == 0) & (Operators.CompareString(structurePortas.Nome2, mRelatElektro[k].sNome2, TextCompare: true) == 0) & (Operators.CompareString(structurePortas.Alternativo, mRelatElektro[k].sAlternativo, TextCompare: true) == 0)))
							{
								mRelatElektro[k].bUso = true;
								mRelatElektro[k].sPaginaPorta += Pagina.montaCruzamentoPagina(ent.Layer.ToString(), Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2));
								mRelatElektro[k].sHandlePorta += ((object)((DBObject)val4).Handle/*cast due to constrained. prefix*/).ToString();
								mRelatElektro[k].sChave = clsTextos.TiraNothing(structurePortas.chavePrimaria);
								if (Operators.CompareString(mRelatElektro[k].sChave, "", TextCompare: true) != 0)
								{
									buscaDadosExcel(mPortas, mRelatElektro[k].sChave, ref mRelatElektro[k].sEFC, ref mRelatElektro[k].sTipo, ref mRelatElektro[k].sUnidade, ref mRelatElektro[k].DescricaoC, ref mRelatElektro[k].DescricaoR);
								}
								break;
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				DeclaracoesGeral._uscPagina.pbFim();
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

	public static void buscaDadosExcel(PortaRelElektro[] mPortasExcel, string sChavePrimaria, ref string sEFC, ref string sTipo, ref string sUnidade, ref string sDescricaoC, ref string sDescricaoR)
	{
		sEFC = "";
		sTipo = "";
		sUnidade = "";
		sDescricaoC = "";
		sDescricaoR = "";
		sChavePrimaria = clsTextos.TiraNothing(sChavePrimaria);
		if (Operators.CompareString(sChavePrimaria, "", TextCompare: true) == 0)
		{
			return;
		}
		int num = 0;
		PortaRelElektro portaRelElektro;
		while (true)
		{
			if (num < mPortasExcel.Length)
			{
				portaRelElektro = mPortasExcel[num];
				if (Operators.CompareString(portaRelElektro.sChavePrimaria, sChavePrimaria, TextCompare: true) == 0)
				{
					break;
				}
				num = checked(num + 1);
				continue;
			}
			return;
		}
		sEFC = portaRelElektro.sEfc;
		sTipo = portaRelElektro.sTipo;
		sUnidade = portaRelElektro.sUnidade;
		sDescricaoC = portaRelElektro.sDescricaoC;
		sDescricaoR = portaRelElektro.sDescricaoR;
	}

	public static void CriaMatrizDePotenciaisDWG_OK(mRelatElektro[] mRelatElektro, string sfonte, string sTitulo, ref ConfElektro rel, bool bRevCompleta)
	{
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.Reguas RH = default;
		XDataGeral.LeXDataReguaH(ref RH);
		int quantColunas = 2;
		int iAlturaInicial = 32;
		int num = 5;
		int iAlturaDoBloco = 7;
		double num2 = 0.0;
		num2 = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta;
		num2 -= 15.0;
		num2 /= 2.0;
		double num3 = 0.0;
		num3 = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta - 2.0 * num2;
		num3 /= 3.0;
		Point3d val = new Point3d(RH.Pti.X + 5.0, RH.Pti.Y - 32.0, 0.0);
		try
		{
			Dicionario.CriaTableStyleRelatorios(sfonte);
			DeclaracoesGeral._uscPagina.pbIniciar();
			DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mRelatElektro);
			bool flag = true;
			rel.iColuna = 1;
			rel.iIndiceUnico = 0;
			Point3d pt = new Point3d(RH.Pti.X + (double)num, RH.Pti.Y - (double)iAlturaInicial, 0.0);
			encontraProximaInsercaoRelatorioRevisao(ref pt, iAlturaDoBloco, num, num2, iAlturaInicial, RH, ref rel);
			val = pt;
			if (pt.Y == 0.0)
			{
				string pag = Pagina.montaNumeroPagina(Pagina.EncontraProximaPagina(DeclaracoesGeral.ativo.Pagina));
				if (Operators.CompareString(DeclaracoesGeral.ativo.Pagina, pag, TextCompare: true) != 0)
				{
					Pagina.AtivaPagina(pag);
					DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
				}
				else
				{
					if (!Pagina.criarUmaNovaPagina())
					{
						return;
					}
					DeclaracoesGeral._uscPagina.CarregaPG();
				}
				val = new Point3d(RH.Pti.X + (double)num, RH.Pti.Y - (double)iAlturaInicial, 0.0);
				rel.iColuna = -1;
			}
			int num4 = Information.UBound(mRelatElektro);
			for (int i = 1; i <= num4; i = checked(i + 1))
			{
				if (rel.iColuna != -1)
				{
					if (i == 1)
					{
						flag = true;
					}
				}
				else
				{
					rel.iColuna = 1;
					flag = true;
				}
				bool bTitulo;
				if (flag)
				{
					double dLarguraDoBloco = num2;
					int iIndice = i;
					bTitulo = true;
					CriaTabelaElektro(dLarguraDoBloco, ref val, mRelatElektro, iIndice, ref bTitulo, ref iAlturaDoBloco, sfonte, sTitulo, bContemDados: true, ref rel, bRevCompleta);
					flag = false;
				}
				double dLarguraDoBloco2 = num2;
				int iIndice2 = i;
				bTitulo = false;
				CriaTabelaElektro(dLarguraDoBloco2, ref val, mRelatElektro, iIndice2, ref bTitulo, ref iAlturaDoBloco, sfonte, sTitulo, bContemDados: false, ref rel, bRevCompleta);
				verificaRelatorioElektro(RH, quantColunas, num, num2, ref iAlturaInicial, ref val, mRelatElektro, i, iAlturaDoBloco, sfonte, sTitulo, flag, ref rel, bRevCompleta);
				DeclaracoesGeral._uscPagina.pbPasso();
				if (DeclaracoesGeral.bPararRelatorio)
				{
					break;
				}
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			DeclaracoesGeral._uscPagina.pbFim();
			ProjectData.ClearProjectError();
		}
	}

	public static string EncontraPotenciaisDWGElektro(ConfElektro relBusca)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected Obj, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected Obj, but got Unknown
		string text = "";
		List<string> list = new List<string>();
		ConfElektro rel = default;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity Ent = (Entity)val2.GetObject(current, (OpenMode)1);
						if (XDataRelatorio.leXDataRevisaoElektro(ref Ent, ref rel) && relBusca.iPainel == rel.iPainel && Operators.CompareString(relBusca.sDisp, rel.sDisp, TextCompare: true) == 0 && Operators.CompareString(relBusca.sTipo, rel.sTipo, TextCompare: true) == 0 && !list.Contains(Ent.Layer))
						{
							list.Add(Ent.Layer);
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
				Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
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
		if (list.Count > 0)
		{
			foreach (string item in list)
			{
				text = text + item + ";";
			}
		}
		return text;
	}

	public static string ApagaPotenciaisDWGElektro(ConfElektro relDEL)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected Obj, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected Obj, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected Obj, but got Unknown
		string text = "";
		ConfElektro rel = default;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity Ent = (Entity)val2.GetObject(current, (OpenMode)1);
						if (XDataRelatorio.leXDataRevisaoElektro(ref Ent, ref rel) && relDEL.iPainel == rel.iPainel && Operators.CompareString(relDEL.sDisp, rel.sDisp, TextCompare: true) == 0)
						{
							if (Operators.CompareString(text, "", TextCompare: true) == 0)
							{
								text = Ent.Layer;
							}
							((DBObject)Ent).UpgradeOpen();
							((DBObject)Ent).Erase();
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
				Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
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
		return text;
	}

	public static void verificaRelatorioElektro(DeclaracoesGeral.Reguas RH, int QuantColunas, double iDistEntreColunas, double dLarguraDoBloco, ref int iAlturaInicial, ref Point3d pt, mRelatElektro[] mRelatElektro, int I, int iAlturaDoBloco, string sfonte, string sTitulo, bool bTitulo, ref ConfElektro rel, bool bRevCompleta)
	{
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			try
			{
				double num = 0.0;
				if (bTitulo)
				{
					num = iAlturaDoBloco * 2;
				}
				if (!(Math.Round(pt.Y, 2) - num < Math.Round(RH.AltBase, 2)))
				{
					return;
				}
				if (!bTitulo)
				{
					ApagaUmIndice(rel);
				}
				if (rel.iColuna >= QuantColunas)
				{
					rel.iColuna = 1;
					string pag = Pagina.montaNumeroPagina(Pagina.EncontraProximaPagina(DeclaracoesGeral.ativo.Pagina));
					if (Operators.CompareString(DeclaracoesGeral.ativo.Pagina, pag, TextCompare: true) != 0)
					{
						Pagina.AtivaPagina(pag);
						DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
					}
					else
					{
						if (!Pagina.criarUmaNovaPagina())
						{
							return;
						}
						DeclaracoesGeral._uscPagina.CarregaPG();
					}
					pt = new Point3d(RH.Pti.X + iDistEntreColunas, RH.Pti.Y - (double)iAlturaInicial, 0.0);
					bool bTitulo2 = true;
					CriaTabelaElektro(dLarguraDoBloco, ref pt, mRelatElektro, I, ref bTitulo2, ref iAlturaDoBloco, sfonte, sTitulo, bContemDados: true, ref rel, bRevCompleta);
				}
				else
				{
					rel.iColuna++;
					pt = new Point3d(RH.Pti.X + iDistEntreColunas * (double)rel.iColuna + dLarguraDoBloco * (double)(rel.iColuna - 1), RH.Pti.Y - (double)iAlturaInicial, 0.0);
					bool bTitulo2 = true;
					CriaTabelaElektro(dLarguraDoBloco, ref pt, mRelatElektro, I, ref bTitulo2, ref iAlturaDoBloco, sfonte, sTitulo, bContemDados: true, ref rel, bRevCompleta);
				}
				if (!bTitulo)
				{
					bool bTitulo2 = false;
					CriaTabelaElektro(dLarguraDoBloco, ref pt, mRelatElektro, I, ref bTitulo2, ref iAlturaDoBloco, sfonte, sTitulo, bContemDados: false, ref rel, bRevCompleta);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void CriaTabelaElektro(double dLarguraDoBloco, ref Point3d pt, mRelatElektro[] mRelatElektro, int iIndice, ref bool bTitulo, ref int iAlturaDoBloco, string sFonte, string sTitulo, bool bContemDados, ref ConfElektro rel, bool bDescCompleta)
	{
		//IL_0769: Unknown result type (might be due to invalid IL or missing references)
		//IL_076e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected Obj, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected Obj, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected Obj, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0412: Expected Obj, but got Unknown
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0458: Unknown result type (might be due to invalid IL or missing references)
		//IL_045f: Expected Obj, but got Unknown
		//IL_06b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0508: Unknown result type (might be due to invalid IL or missing references)
		//IL_051a: Unknown result type (might be due to invalid IL or missing references)
		//IL_051f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0523: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f1: Expected Obj, but got Unknown
		//IL_0570: Unknown result type (might be due to invalid IL or missing references)
		//IL_0575: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Unknown result type (might be due to invalid IL or missing references)
		//IL_057e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0559: Unknown result type (might be due to invalid IL or missing references)
		//IL_0560: Expected Obj, but got Unknown
		double x = pt.X;
		double y = pt.Y;
		int colorIndex = 7;
		if (bTitulo)
		{
			if (!bContemDados && iIndice == 1)
			{
				pt = new Point3d(x, y - (double)iAlturaDoBloco, 0.0);
			}
			CriaTabelaELEKTRO1Linha(dLarguraDoBloco, ref pt, mRelatElektro, iAlturaDoBloco, sFonte, sTitulo, ref rel);
			x = pt.X;
			y = pt.Y;
			iIndice = 0;
		}
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Database database = mdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					TextStyleTable val3 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
					_ = ((SymbolTable)val3)[sFonte];
					new DBObjectCollection();
					BlockTable val4 = (BlockTable)val2.GetObject(mdiActiveDocument.Database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
					Table val6 = new Table();
					((Entity)val6).Layer = DeclaracoesGeral.ativo.Pagina;
					val6.SetSize(1, 5);
					val6.GenerateLayout();
					val6.RecomputeTableBlock(true);
					Point3d position = (((BlockReference)val6).Position = new Point3d(pt.X, pt.Y, 0.0));
					val6.Columns[0].Width = dLarguraDoBloco * 0.1;
					val6.Columns[1].Width = dLarguraDoBloco * 0.15;
					val6.Columns[2].Width = dLarguraDoBloco * 0.55;
					val6.Columns[3].Width = dLarguraDoBloco * 0.1;
					val6.Columns[4].Width = dLarguraDoBloco * 0.1;
					val6.SetRowHeight((double)iAlturaDoBloco);
					int num = 0;
					do
					{
						if (!((num == 2) & !bTitulo))
						{
							((CellRange)val6.Cells[0, num]).TextHeight = 2.0;
							((CellRange)val6.Cells[0, num]).Alignment = (CellAlignment)5;
						}
						else
						{
							((CellRange)val6.Cells[0, num]).TextHeight = 2.0;
							((CellRange)val6.Cells[0, num]).Alignment = (CellAlignment)4;
						}
						num++;
					}
					while (num <= 4);
					if (Operators.CompareString(clsTextos.TiraNothing(mRelatElektro[iIndice].sEFC), "", TextCompare: true) == 0)
					{
						mRelatElektro[iIndice].sEFC = "##B##";
					}
					if (Operators.CompareString(clsTextos.TiraNothing(mRelatElektro[iIndice].sBornes), "", TextCompare: true) == 0)
					{
						mRelatElektro[iIndice].sBornes = "##B##";
					}
					if (Operators.CompareString(clsTextos.TiraNothing(mRelatElektro[iIndice].DescricaoC), "", TextCompare: true) == 0)
					{
						mRelatElektro[iIndice].DescricaoC = "##B##";
					}
					if (Operators.CompareString(clsTextos.TiraNothing(mRelatElektro[iIndice].DescricaoR), "", TextCompare: true) == 0)
					{
						mRelatElektro[iIndice].DescricaoR = "##B##";
					}
					if (Operators.CompareString(clsTextos.TiraNothing(mRelatElektro[iIndice].sPaginaPorta), "", TextCompare: true) == 0)
					{
						mRelatElektro[iIndice].sPaginaPorta = "##B##";
					}
					val6.Cells[0, 0].TextString = mRelatElektro[iIndice].sEFC.ToString();
					val6.Cells[0, 1].TextString = mRelatElektro[iIndice].sBornes.ToString();
					if (!bDescCompleta)
					{
						val6.Cells[0, 2].TextString = mRelatElektro[iIndice].DescricaoR.ToString();
					}
					else
					{
						val6.Cells[0, 2].TextString = mRelatElektro[iIndice].DescricaoC.ToString();
					}
					val6.Cells[0, 3].TextString = mRelatElektro[iIndice].sPaginaPorta.ToString();
					val6.Cells[0, 4].TextString = "##B##";
					if (iIndice == 0)
					{
						val6.Cells[0, 4].TextString = mRelatElektro[iIndice].sHandlePorta.ToString();
					}
					val6.SetRowHeight((double)iAlturaDoBloco);
					((BlockReference)val6).Position = position;
					y = 100000.0;
					x = 0.0;
					Extents3d value = ((Drawable)val6).Bounds.Value;
					Point3d minPoint = value.MinPoint;
					x = minPoint.X;
					((Entity)val6).ColorIndex = colorIndex;
					DeclaracoesGeral.bAnularEventos = true;
					val6.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					val6.GenerateLayout();
					val5.AppendEntity((Entity)(object)val6);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
					val6.RecomputeTableBlock(true);
					((DBObject)val6).UpgradeOpen();
					val6.SetRowHeight((double)iAlturaDoBloco);
					DBObjectCollection val8 = new DBObjectCollection();
					DeclaracoesGeral.bAnularEventos = true;
					val6.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					((Entity)val6).Explode(val8);
					((DBObject)val6).Erase();
					foreach (Entity item in val8)
					{
						Entity val9 = item;
						MText val10 = (MText)(object)((val9 is MText) ? val9 : null);
						if (val10 != null)
						{
							((Entity)val10).ColorIndex = colorIndex;
							((Entity)val10).Layer = DeclaracoesGeral.ativo.Pagina;
							if (Operators.CompareString(val10.Text, "##B##", TextCompare: true) != 0)
							{
								val5.AppendEntity((Entity)(object)val10);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
								Entity Ent = (Entity)(object)val10;
								XDataRelatorio.GravarXDataElektro(ref Ent, rel);
								val10 = (MText)Ent;
							}
						}
						Line val11 = (Line)(object)((val9 is Line) ? val9 : null);
						if (val11 != null)
						{
							val9.Layer = DeclaracoesGeral.ativo.Pagina;
							val5.AppendEntity(val9);
							double num2 = y;
							value = ((Drawable)val11).Bounds.Value;
							minPoint = value.MinPoint;
							if (num2 > minPoint.Y)
							{
								value = ((Drawable)val11).Bounds.Value;
								minPoint = value.MinPoint;
								y = minPoint.Y;
							}
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
							Entity Ent = (Entity)(object)val11;
							XDataRelatorio.GravarXDataElektro(ref Ent, rel);
							val11 = (Line)Ent;
						}
						((DisposableWrapper)val9).Dispose();
					}
					pt = new Point3d(x, y, 0.0);
					rel.iIndiceUnico++;
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
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

	public static void CriaTabelaELEKTRO1Linha(double dLarguraDoBloco, ref Point3d pt, mRelatElektro[] mRelatElektro, int iAlturaDoBloco, string sFonte, string sTitulo, ref ConfElektro rel)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected Obj, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected Obj, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected Obj, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Expected Obj, but got Unknown
		//IL_03cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected Obj, but got Unknown
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Expected Obj, but got Unknown
		double x = pt.X;
		double y = pt.Y;
		int colorIndex = 7;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				TextStyleTable val3 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
				_ = ((SymbolTable)val3)[sFonte];
				new DBObjectCollection();
				BlockTable val4 = (BlockTable)val2.GetObject(mdiActiveDocument.Database.BlockTableId, (OpenMode)0);
				BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
				Table val6 = new Table();
				((Entity)val6).Layer = DeclaracoesGeral.ativo.Pagina;
				val6.SetSize(1, 1);
				val6.GenerateLayout();
				val6.RecomputeTableBlock(true);
				Point3d position = (((BlockReference)val6).Position = new Point3d(pt.X, pt.Y, 0.0));
				val6.Columns[0].Width = dLarguraDoBloco;
				val6.SetRowHeight((double)iAlturaDoBloco);
				((CellRange)val6.Cells[0, 0]).TextHeight = 2.0;
				((CellRange)val6.Cells[0, 0]).Alignment = (CellAlignment)5;
				if (Operators.CompareString(clsTextos.TiraNothing(sTitulo), "##B##", TextCompare: true) == 0)
				{
					sTitulo = "##B##";
				}
				val6.Cells[0, 0].TextString = sTitulo;
				val6.SetRowHeight((double)iAlturaDoBloco);
				((BlockReference)val6).Position = position;
				y = 100000.0;
				x = 0.0;
				Extents3d value = ((Drawable)val6).Bounds.Value;
				Point3d minPoint = value.MinPoint;
				x = minPoint.X;
				((Entity)val6).ColorIndex = colorIndex;
				DeclaracoesGeral.bAnularEventos = true;
				val6.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				val6.GenerateLayout();
				val5.AppendEntity((Entity)(object)val6);
				DeclaracoesGeral.bAnularEventos = true;
				val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
				val6.RecomputeTableBlock(true);
				((DBObject)val6).UpgradeOpen();
				val6.SetRowHeight((double)iAlturaDoBloco);
				DBObjectCollection val8 = new DBObjectCollection();
				DeclaracoesGeral.bAnularEventos = true;
				val6.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				((Entity)val6).Explode(val8);
				((DBObject)val6).Erase();
				foreach (Entity item in val8)
				{
					Entity val9 = item;
					MText val10 = (MText)(object)((val9 is MText) ? val9 : null);
					if (val10 != null)
					{
						((Entity)val10).ColorIndex = colorIndex;
						((Entity)val10).Layer = DeclaracoesGeral.ativo.Pagina;
						if (Operators.CompareString(val10.Text, "##B##", TextCompare: true) != 0)
						{
							val5.AppendEntity((Entity)(object)val10);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
							Entity Ent = (Entity)(object)val10;
							XDataRelatorio.GravarXDataElektro(ref Ent, rel);
							val10 = (MText)Ent;
						}
					}
					Line val11 = (Line)(object)((val9 is Line) ? val9 : null);
					if (val11 != null)
					{
						val9.Layer = DeclaracoesGeral.ativo.Pagina;
						val5.AppendEntity(val9);
						double num = y;
						value = ((Drawable)val11).Bounds.Value;
						minPoint = value.MinPoint;
						if (num > minPoint.Y)
						{
							value = ((Drawable)val11).Bounds.Value;
							minPoint = value.MinPoint;
							y = minPoint.Y;
						}
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
						Entity Ent = (Entity)(object)val11;
						XDataRelatorio.GravarXDataElektro(ref Ent, rel);
						val11 = (Line)Ent;
					}
					((DisposableWrapper)val9).Dispose();
				}
				pt = new Point3d(x, y, 0.0);
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
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

	public static void ApagaUmIndice(ConfElektro rel)
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
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity Ent = (Entity)val2.GetObject(current, (OpenMode)1);
						ConfElektro rel2 = default;
						if (XDataRelatorio.leXDataRevisaoElektro(ref Ent, ref rel2) && ((rel2.iColuna == rel.iColuna) & (rel2.iIndiceUnico == checked(rel.iIndiceUnico - 1)) & (rel2.iPainel == rel.iPainel) & (Operators.CompareString(rel2.sDisp, rel.sDisp, TextCompare: true) == 0) & (Operators.CompareString(rel2.sTipo, rel.sTipo, TextCompare: true) == 0) & (Operators.CompareString(rel2.sUnidade, rel.sUnidade, TextCompare: true) == 0)))
						{
							((DBObject)Ent).UpgradeOpen();
							((DBObject)Ent).Erase();
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
				Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
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

	public static void encontraProximaInsercaoRelatorioRevisao(ref Point3d pt, double iAlturaDoBloco, double iDistEntreColunas, double dLarguraDoBloco, double iAlturaInicial, DeclaracoesGeral.Reguas RH, ref ConfElektro rel)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected Obj, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		rel.iColuna = -1;
		int iColuna = 0;
		int num = 0;
		bool flag = false;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity Ent = (Entity)val2.GetObject(current, (OpenMode)1);
						if (Operators.CompareString(Ent.Layer, DeclaracoesGeral.ativo.Pagina, TextCompare: true) != 0)
						{
							continue;
						}
						Line val5 = (Line)(object)((Ent is Line) ? Ent : null);
						if (val5 != null)
						{
							ConfElektro rel2 = default;
							if (XDataRelatorio.leXDataRevisaoElektro(ref Ent, ref rel2))
							{
								iColuna = rel2.iColuna;
								num = rel2.iIndiceUnico;
								Extents3d value = ((Drawable)val5).Bounds.Value;
								Point3d minPoint = value.MinPoint;
								double x = minPoint.X;
								value = ((Drawable)val5).Bounds.Value;
								minPoint = value.MinPoint;
								pt = new Point3d(x, minPoint.Y, 0.0);
								flag = true;
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
				if (flag)
				{
					rel.iColuna = iColuna;
					rel.iIndiceUnico = checked(num + 1);
				}
				if (!(Math.Round(pt.Y, 2) - iAlturaDoBloco * 5.0 < Math.Round(RH.AltBase, 2)))
				{
					if (flag)
					{
						pt = new Point3d(pt.X, pt.Y - iAlturaDoBloco * 2.0, 0.0);
					}
				}
				else
				{
					if (flag)
					{
						pt = new Point3d(pt.X, 0.0, 0.0);
					}
					if (rel.iColuna != 2)
					{
						rel.iColuna = 2;
						pt = new Point3d(RH.Pti.X + iDistEntreColunas + dLarguraDoBloco + iDistEntreColunas, RH.Pti.Y - iAlturaInicial, 0.0);
					}
					else
					{
						rel.iColuna = -1;
					}
				}
				Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
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
}
