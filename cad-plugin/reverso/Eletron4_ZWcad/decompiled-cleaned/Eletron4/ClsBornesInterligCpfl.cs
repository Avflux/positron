using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

public class ClsBornesInterligCpfl
{
	public struct StructureBornesCPFL
	{
		public int iPainel;

		public string sPainel;

		public int iRegua;

		public string sRegua;

		public string sBorne;

		public string sHandle;

		public string Layer;

		public Point3d Point1;

		public bool bCDE1;

		public bool bCDE2;

		public bool bCDE3;

		public bool bCDE4;

		public bool bCPARA1;

		public bool bCPARA2;

		public bool bCPARA3;

		public bool bCPARA4;

		public bool bJDE1;

		public bool bJDE2;

		public bool bJDE3;

		public bool bJDE4;

		public bool bJPARA1;

		public bool bJPARA2;

		public bool bJPARA3;

		public bool bJPARA4;

		public bool Adicionado;

		public double iOrdem;
	}

	public struct StructureInterligCFEL
	{
		public string sPainelDE;

		public string sReguaDE;

		public string sBorneDE;

		public int iPainelDE;

		public int iReguaDE;

		public string sPainelPARA;

		public string sReguaPARA;

		public string sBornePARA;

		public int iPainelPARA;

		public int iReguaPara;

		public string s_Cabo;

		public int indice;

		public string sNome;

		public bool Adicionado;

		public string sTipo;
	}

	public struct StructureJUMPERCFEL
	{
		public string sPainelDE;

		public string sReguaDE;

		public string sBorneDE;

		public int iPainelDE;

		public int iReguaDE;

		public string sPainelPARA;

		public string sReguaPARA;

		public string sBornePARA;

		public int iPainelPARA;

		public int iReguaPara;

		public string sSecao;

		public string sCor;

		public string sFuncao;

		public bool Adicionado;
	}

	public struct StructureCadastroCabos
	{
		public string sCabo;

		public string sFormacao;

		public bool bBlindado;

		public string sFuncao;

		public string sVeias;

		public string sSecao;

		public int indice;

		public string sNome;

		public string sEquipDE;

		public string sEquipPARA;

		public int iEquipDE;

		public int iEquipPARA;

		public int iAterrar;

		public double dComprimento;

		public string sTajeto;
	}

	public struct StructureBorneInseidos2
	{
		public string sPainelDE;

		public string sReguaDE;

		public string sBorneDE;

		public int iPainelDE;

		public int iReguaDE;

		public string sPainelPARA;

		public string sReguaPARA;

		public string sBornePARA;

		public int iPainelPARA;

		public int iReguaPARA;
	}

	public struct StructureTamanhoCaboCPFE
	{
		public string sCabo;

		public int iTotVeias;

		public int iVeias;

		public int iQuant;
	}

	public struct StructureBornesReservas
	{
		public int iPainel;

		public int iRegua;

		public int iMaiorBorne;

		public bool bAddReserva;
	}

	public static void CapturaBornesDoDesenhoCpfl(ref StructureBornesCPFL[] mTodosBornes)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected Obj, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				DeclaracoesEntidades.StructureBorne structureBorne = default;
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
						if (Operators.CompareString(left, "B", TextCompare: true) != 0)
						{
							continue;
						}
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
						DeclaracoesEntidades.StructureBorne structureBorne2 = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
						int num = Information.UBound(mTodosBornes);
						for (int i = 1; i <= num; i = checked(i + 1))
						{
							if ((mTodosBornes[i].iPainel == structureBorne2.indexPainel) & (mTodosBornes[i].iRegua == structureBorne2.IndiceRegua) & (Operators.CompareString(mTodosBornes[i].sBorne, structureBorne2.Numero, TextCompare: true) == 0))
							{
								mTodosBornes[i].sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
								mTodosBornes[i].Layer = ((Entity)val6).Layer;
								ref StructureBornesCPFL reference = ref mTodosBornes[i];
								Point3d position = val6.Position;
								double x = position.X;
								position = val6.Position;
								reference.Point1 = new Point3d(x, position.Y, 0.0);
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

	public static bool VerificaBornesCpfl(ref StructureBorneInseidos2[] mBornesAdd, ref StructureInterligCFEL[] mInterligacoes, ref StructureJUMPERCFEL[] mJUMPERS)
	{
		bool result = false;
		int num = 0;
		mBornesAdd = new StructureBorneInseidos2[1];
		string text = "";
		string text2 = "";
		int num2 = Information.UBound(mInterligacoes);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				string sPainelDE = mInterligacoes[i].sPainelDE;
				string sReguaDE = mInterligacoes[i].sReguaDE;
				string sBorneDE = mInterligacoes[i].sBorneDE;
				string sPainelPARA = mInterligacoes[i].sPainelPARA;
				string sReguaPARA = mInterligacoes[i].sReguaPARA;
				string sBornePARA = mInterligacoes[i].sBornePARA;
				text = sPainelDE + "-" + sReguaDE + "-" + sBorneDE;
				text2 = sPainelPARA + "-" + sReguaPARA + "-" + sBornePARA;
				if (!(((Operators.CompareString(text, "--", TextCompare: true) == 0) & (Operators.CompareString(text2, "--", TextCompare: true) == 0)) | ((Operators.CompareString(sReguaDE, "-", TextCompare: true) == 0) | (Operators.CompareString(sReguaPARA, "-", TextCompare: true) == 0)) | ((Operators.CompareString(sReguaDE, "?", TextCompare: true) == 0) & (Operators.CompareString(sReguaPARA, "?", TextCompare: true) == 0))) && !((Operators.CompareString(text, "--", TextCompare: true) == 0) & (Operators.CompareString(text2, "--", TextCompare: true) == 0)))
				{
					num++;
					mBornesAdd = (StructureBorneInseidos2[])Utils.CopyArray(mBornesAdd, new StructureBorneInseidos2[num + 1]);
					mBornesAdd[num].sPainelDE = sPainelDE.Trim();
					mBornesAdd[num].sReguaDE = sReguaDE.Trim();
					mBornesAdd[num].sBorneDE = sBorneDE.Trim();
					mBornesAdd[num].sPainelPARA = sPainelPARA.Trim();
					mBornesAdd[num].sReguaPARA = sReguaPARA.Trim();
					mBornesAdd[num].sBornePARA = sBornePARA.Trim();
				}
			}
			int num3 = Information.UBound(mJUMPERS);
			for (int j = 1; j <= num3; j++)
			{
				string sPainelDE2 = mJUMPERS[j].sPainelDE;
				string sReguaDE2 = mJUMPERS[j].sReguaDE;
				string sBorneDE2 = mJUMPERS[j].sBorneDE;
				string sPainelPARA2 = mJUMPERS[j].sPainelPARA;
				string sReguaPARA2 = mJUMPERS[j].sReguaPARA;
				string sBornePARA2 = mJUMPERS[j].sBornePARA;
				text = sPainelDE2 + "-" + sReguaDE2 + "-" + sBorneDE2;
				text2 = sPainelPARA2 + "-" + sReguaPARA2 + "-" + sBornePARA2;
				if (!(((Operators.CompareString(text, "--", TextCompare: true) == 0) & (Operators.CompareString(text2, "--", TextCompare: true) == 0)) | ((Operators.CompareString(sReguaDE2, "-", TextCompare: true) == 0) | (Operators.CompareString(sReguaPARA2, "-", TextCompare: true) == 0))) && !((Operators.CompareString(text, "--", TextCompare: true) == 0) & (Operators.CompareString(text2, "--", TextCompare: true) == 0)))
				{
					num++;
					mBornesAdd = (StructureBorneInseidos2[])Utils.CopyArray(mBornesAdd, new StructureBorneInseidos2[num + 1]);
					mBornesAdd[num].sPainelDE = sPainelDE2.Trim();
					mBornesAdd[num].sReguaDE = sReguaDE2.Trim();
					mBornesAdd[num].sBorneDE = sBorneDE2.Trim();
					mBornesAdd[num].sPainelPARA = sPainelPARA2.Trim();
					mBornesAdd[num].sReguaPARA = sReguaPARA2.Trim();
					mBornesAdd[num].sBornePARA = sBornePARA2.Trim();
				}
			}
			return result;
		}
	}

	public static void CadastraPaineisCpfl(ref StructureBorneInseidos2[] mBornes, ref StructureBornesCPFL[] mTodosBornes, ref StructureInterligCFEL[] mInterligacoes, ref StructureInterligCFEL[] mBlindagens, ref StructureJUMPERCFEL[] mJUMPERS, ref StructureCadastroCabos[] mCabosAdd)
	{
		string userName = Environment.UserName;
		string sEditor = "";
		DateTime sData = Conversions.ToDate(DateTime.Now.ToString());
		int num = 1;
		int num2 = 1;
		checked
		{
			DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mBornes) + Information.UBound(mTodosBornes) + Information.UBound(mInterligacoes) + Information.UBound(mJUMPERS) + Information.UBound(mCabosAdd);
			DeclaracoesGeral._uscPagina.pbIniciar();
			int num3 = 0;
			cDadosAccessPaineis cDadosAccessPaineis2 = new cDadosAccessPaineis();
			num = cDadosAccessPaineis2.ProximoIndicePainel();
			List<string> list = new List<string>();
			int num4 = Information.UBound(mBornes);
			for (int i = 1; i <= num4; i++)
			{
				num3++;
				if (num3 == 10)
				{
					DeclaracoesGeral._uscPagina.pbPasso(num3);
					num3 = 0;
				}
				if (!list.Contains(mBornes[i].sPainelDE) && Dicionario.BuscaIndiceDoPainel(mBornes[i].sPainelDE) == 0 && Operators.CompareString(mBornes[i].sPainelDE.Trim(), "", TextCompare: true) != 0)
				{
					list.Add(mBornes[i].sPainelDE);
				}
				if (!list.Contains(mBornes[i].sPainelPARA) && Dicionario.BuscaIndiceDoPainel(mBornes[i].sPainelPARA) == 0 && Operators.CompareString(mBornes[i].sPainelPARA.Trim(), "", TextCompare: true) != 0)
				{
					list.Add(mBornes[i].sPainelPARA);
				}
			}
			list.Sort();
			foreach (string item in list)
			{
				cDadosAccessPaineis2.AdicionaPainel("Paineis", num, item, userName, sEditor, sData);
				num++;
			}
			cDadosAccessPaineis2.fechaConexao();
			cDadosAccess.carregaPainelDicionario();
			int num5 = Information.UBound(mBornes);
			for (int j = 1; j <= num5; j++)
			{
				mBornes[j].iPainelDE = Dicionario.BuscaIndiceDoPainel(mBornes[j].sPainelDE);
				mBornes[j].iPainelPARA = Dicionario.BuscaIndiceDoPainel(mBornes[j].sPainelPARA);
				num3++;
				if (num3 == 10)
				{
					DeclaracoesGeral._uscPagina.pbPasso(num3);
					num3 = 0;
				}
			}
			int num6 = Information.UBound(mTodosBornes);
			for (int k = 1; k <= num6; k++)
			{
				mTodosBornes[k].iPainel = Dicionario.BuscaIndiceDoPainel(mTodosBornes[k].sPainel);
				mTodosBornes[k].iPainel = Dicionario.BuscaIndiceDoPainel(mTodosBornes[k].sPainel);
				num3++;
				if (num3 == 10)
				{
					DeclaracoesGeral._uscPagina.pbPasso(num3);
					num3 = 0;
				}
			}
			int num7 = Information.UBound(mInterligacoes);
			for (int l = 1; l <= num7; l++)
			{
				mInterligacoes[l].iPainelDE = Dicionario.BuscaIndiceDoPainel(mInterligacoes[l].sPainelDE);
				mInterligacoes[l].iPainelPARA = Dicionario.BuscaIndiceDoPainel(mInterligacoes[l].sPainelPARA);
				num3++;
				if (num3 == 10)
				{
					DeclaracoesGeral._uscPagina.pbPasso(num3);
					num3 = 0;
				}
			}
			int num8 = Information.UBound(mBlindagens);
			for (int m = 1; m <= num8; m++)
			{
				mBlindagens[m].iPainelDE = Dicionario.BuscaIndiceDoPainel(mBlindagens[m].sPainelDE);
			}
			int num9 = Information.UBound(mJUMPERS);
			for (int n = 1; n <= num9; n++)
			{
				mJUMPERS[n].iPainelDE = Dicionario.BuscaIndiceDoPainel(mJUMPERS[n].sPainelDE);
				mJUMPERS[n].iPainelPARA = Dicionario.BuscaIndiceDoPainel(mJUMPERS[n].sPainelPARA);
				num3++;
				if (num3 == 10)
				{
					DeclaracoesGeral._uscPagina.pbPasso(num3);
					num3 = 0;
				}
			}
			int num10 = Information.UBound(mCabosAdd);
			for (int num11 = 1; num11 <= num10; num11++)
			{
				mCabosAdd[num11].iEquipDE = Dicionario.BuscaIndiceDoPainel(mCabosAdd[num11].sEquipDE);
				mCabosAdd[num11].iEquipPARA = Dicionario.BuscaIndiceDoPainel(mCabosAdd[num11].sEquipPARA);
				num3++;
				if (num3 == 10)
				{
					DeclaracoesGeral._uscPagina.pbPasso(num3);
					num3 = 0;
				}
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	public static void CadastraReguasCpfl(ref StructureBorneInseidos2[] mBornes, ref StructureBornesCPFL[] mTodosBornes, ref StructureInterligCFEL[] mInterligacoes, ref StructureInterligCFEL[] mBlindagem, ref StructureJUMPERCFEL[] mJUMPERS)
	{
		checked
		{
			try
			{
				Declaracoes2.StructureModeloDeReguas[] mModelo = new Declaracoes2.StructureModeloDeReguas[1];
				DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
				bool flag = true;
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mBornes);
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num = 0;
				int num2 = Information.UBound(mBornes);
				for (int i = 1; i <= num2; i++)
				{
					flag = true;
					int num3 = Information.UBound(mModelo);
					for (int j = 1; j <= num3; j++)
					{
						if (!((Operators.CompareString(mBornes[i].sReguaDE.Trim(), "", TextCompare: true) != 0) | (Operators.CompareString(mBornes[i].sReguaDE.Trim(), DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) != 0)))
						{
							flag = false;
							break;
						}
						if (mBornes[i].iPainelDE == mModelo[j].indexPainel && Operators.CompareString(mBornes[i].sReguaDE, mModelo[j].nomeRegua, TextCompare: true) == 0)
						{
							mBornes[i].iReguaDE = mModelo[j].indexRegua;
							flag = false;
							break;
						}
					}
					if (flag)
					{
						mBornes[i].iReguaDE = mModelo[0].iMaxIndice + 1;
						int num4 = Information.UBound(mModelo) + 1;
						mModelo = (Declaracoes2.StructureModeloDeReguas[])Utils.CopyArray(mModelo, new Declaracoes2.StructureModeloDeReguas[num4 + 1]);
						mModelo[num4].indexRegua = mBornes[i].iReguaDE;
						mModelo[num4].nomeRegua = mBornes[i].sReguaDE;
						mModelo[num4].nomeAlternativo = "";
						mModelo[num4].indexPainel = mBornes[i].iPainelDE;
						mModelo[0].iMaxIndice = mBornes[i].iReguaDE;
						DicionarioReguas.GravaOsModelosDeRegua(mModelo);
						mModelo = new Declaracoes2.StructureModeloDeReguas[1];
						DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
					}
					if (Information.UBound(mTodosBornes) <= 1000)
					{
						DeclaracoesGeral._uscPagina.pbPasso();
						continue;
					}
					num++;
					if (num > 1000)
					{
						DeclaracoesGeral._uscPagina.pbPasso(num);
						num = 0;
					}
				}
				DeclaracoesGeral._uscPagina.pbFim();
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mTodosBornes);
				DeclaracoesGeral._uscPagina.pbIniciar();
				num = 0;
				int num5 = Information.UBound(mTodosBornes);
				for (int k = 1; k <= num5; k++)
				{
					flag = true;
					int num6 = Information.UBound(mModelo);
					for (int l = 1; l <= num6; l++)
					{
						if (!((Operators.CompareString(mTodosBornes[k].sRegua, "", TextCompare: true) != 0) | (Operators.CompareString(mTodosBornes[k].sRegua, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) != 0)))
						{
							flag = false;
							break;
						}
						if (mTodosBornes[k].iPainel == mModelo[l].indexPainel && Operators.CompareString(mTodosBornes[k].sRegua, mModelo[l].nomeRegua, TextCompare: true) == 0)
						{
							mTodosBornes[k].iRegua = mModelo[l].indexRegua;
							flag = false;
							break;
						}
					}
					if (flag)
					{
						mTodosBornes[k].iRegua = mModelo[0].iMaxIndice + 1;
						int num7 = Information.UBound(mModelo) + 1;
						mModelo = (Declaracoes2.StructureModeloDeReguas[])Utils.CopyArray(mModelo, new Declaracoes2.StructureModeloDeReguas[num7 + 1]);
						mModelo[num7].indexRegua = mTodosBornes[k].iRegua;
						mModelo[num7].nomeRegua = mTodosBornes[k].sRegua;
						mModelo[num7].nomeAlternativo = "";
						mModelo[num7].indexPainel = mTodosBornes[k].iPainel;
						mModelo[0].iMaxIndice = mTodosBornes[k].iRegua;
						DicionarioReguas.GravaOsModelosDeRegua(mModelo);
						mModelo = new Declaracoes2.StructureModeloDeReguas[1];
						DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
					}
					if (Information.UBound(mTodosBornes) <= 1000)
					{
						DeclaracoesGeral._uscPagina.pbPasso();
						continue;
					}
					num++;
					if (num > 1000)
					{
						DeclaracoesGeral._uscPagina.pbPasso(num);
						num = 0;
					}
				}
				DeclaracoesGeral._uscPagina.pbFim();
				mModelo = new Declaracoes2.StructureModeloDeReguas[1];
				DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mTodosBornes);
				DeclaracoesGeral._uscPagina.pbIniciar();
				num = 0;
				int num8 = Information.UBound(mBornes);
				for (int m = 1; m <= num8; m++)
				{
					flag = true;
					int num9 = Information.UBound(mModelo);
					for (int n = 1; n <= num9; n++)
					{
						if (Operators.CompareString(mBornes[m].sReguaPARA.Trim(), "", TextCompare: true) == 0)
						{
							flag = false;
							break;
						}
						if (mBornes[m].iPainelPARA == mModelo[n].indexPainel && Operators.CompareString(mBornes[m].sReguaPARA, mModelo[n].nomeRegua, TextCompare: true) == 0)
						{
							mBornes[m].iReguaPARA = mModelo[n].indexRegua;
							flag = false;
							break;
						}
					}
					if (flag)
					{
						mBornes[m].iReguaPARA = mModelo[0].iMaxIndice + 1;
						int num10 = Information.UBound(mModelo) + 1;
						mModelo = (Declaracoes2.StructureModeloDeReguas[])Utils.CopyArray(mModelo, new Declaracoes2.StructureModeloDeReguas[num10 + 1]);
						mModelo[num10].indexRegua = mBornes[m].iReguaPARA;
						mModelo[num10].nomeRegua = mBornes[m].sReguaPARA;
						mModelo[num10].nomeAlternativo = "";
						mModelo[num10].indexPainel = mBornes[m].iPainelPARA;
						mModelo[0].iMaxIndice = mBornes[m].iReguaPARA;
						DicionarioReguas.GravaOsModelosDeRegua(mModelo);
						mModelo = new Declaracoes2.StructureModeloDeReguas[1];
						DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
					}
					if (Information.UBound(mBornes) <= 100)
					{
						DeclaracoesGeral._uscPagina.pbPasso();
						continue;
					}
					num++;
					if (num > 100)
					{
						DeclaracoesGeral._uscPagina.pbPasso(num);
						num = 0;
					}
				}
				DeclaracoesGeral._uscPagina.pbFim();
				mModelo = new Declaracoes2.StructureModeloDeReguas[1];
				DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
				int num11 = Information.UBound(mTodosBornes);
				for (int num12 = 1; num12 <= num11; num12++)
				{
					mTodosBornes[num12].iRegua = BuscaIndideRegua(mModelo, mTodosBornes[num12].iPainel, mTodosBornes[num12].sRegua);
				}
				int num13 = Information.UBound(mInterligacoes);
				for (int num14 = 1; num14 <= num13; num14++)
				{
					mInterligacoes[num14].iReguaDE = BuscaIndideRegua(mModelo, mInterligacoes[num14].iPainelDE, mInterligacoes[num14].sReguaDE);
					mInterligacoes[num14].iReguaPara = BuscaIndideRegua(mModelo, mInterligacoes[num14].iPainelPARA, mInterligacoes[num14].sReguaPARA);
				}
				int num15 = Information.UBound(mBlindagem);
				for (int num16 = 1; num16 <= num15; num16++)
				{
					mBlindagem[num16].iReguaDE = BuscaIndideRegua(mModelo, mBlindagem[num16].iPainelDE, mBlindagem[num16].sReguaDE);
				}
				int num17 = Information.UBound(mJUMPERS);
				for (int num18 = 1; num18 <= num17; num18++)
				{
					mJUMPERS[num18].iReguaDE = BuscaIndideRegua(mModelo, mJUMPERS[num18].iPainelDE, mJUMPERS[num18].sReguaDE);
					mJUMPERS[num18].iReguaPara = BuscaIndideRegua(mModelo, mJUMPERS[num18].iPainelDE, mJUMPERS[num18].sReguaPARA);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static int BuscaIndideRegua(Declaracoes2.StructureModeloDeReguas[] mModeloDeReguas, int iPainel, string sRegua)
	{
		int result = 0;
		int num = Information.UBound(mModeloDeReguas);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (iPainel == mModeloDeReguas[i].indexPainel && Operators.CompareString(sRegua, mModeloDeReguas[i].nomeRegua, TextCompare: true) == 0)
			{
				result = mModeloDeReguas[i].indexRegua;
				break;
			}
		}
		return result;
	}

	public static void InsereVeiaCpfl(Point3d PrimeiroPoint, Point3d SegundoPoint, DeclaracoesEntidades.StructureInterligacao ilig)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected Obj, but got Unknown
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected Obj, but got Unknown
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected Obj, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected Obj, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		Point2d val = PrimeiroPoint.Convert2d((PlanarEntity)new Plane());
		Point2d val2 = SegundoPoint.Convert2d((PlanarEntity)new Plane());
		Polyline pl = new Polyline();
		((Entity)pl).SetDatabaseDefaults();
		((Entity)pl).ColorIndex = DeclaracoesGeral.Conf.CorInterligacao;
		pl.AddVertexAt(0, val, 0.0, 0.0, 0.0);
		pl.AddVertexAt(1, val2, 0.0, 0.0, 0.0);
		DocumentLock val3 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val4 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val5 = (BlockTable)val4.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val6 = (BlockTableRecord)val4.GetObject(((SymbolTable)val5)[BlockTableRecord.ModelSpace], (OpenMode)1);
				val6.AppendEntity((Entity)(object)pl);
				DeclaracoesGeral.bAnularEventos = true;
				val4.AddNewlyCreatedDBObject((DBObject)(object)pl, true);
				XDataInterligacao.GravarXDataInterligacao(ref pl, ref ilig, 0);
				DeclaracoesGeral.bAnularEventos = true;
				val4.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				val4.Abort();
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val4)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val3)?.Dispose();
		}
		PointMonitorToolTips.StartMonitor();
	}

	public static void AdicionaBornesReserva(ref StructureBornesCPFL[] mTodosBornes, List<string> lPNReguaReserva)
	{
		int num = 0;
		StructureBornesReservas[] array = new StructureBornesReservas[1];
		int num2 = Information.UBound(mTodosBornes);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				bool flag = true;
				int num3 = Information.UBound(array);
				for (int j = 1; j <= num3; j++)
				{
					if (!((mTodosBornes[i].iPainel == array[j].iPainel) & (mTodosBornes[i].iRegua == array[j].iRegua)))
					{
						continue;
					}
					if (array[j].bAddReserva)
					{
						if (!Versioned.IsNumeric(mTodosBornes[i].sBorne))
						{
							array[j].bAddReserva = false;
						}
						else if (Conversions.ToInteger(mTodosBornes[i].sBorne) > array[j].iMaiorBorne)
						{
							array[j].iMaiorBorne = Conversions.ToInteger(mTodosBornes[i].sBorne);
						}
					}
					flag = false;
				}
				if (lPNReguaReserva.Contains(Conversions.ToString(mTodosBornes[i].iPainel) + "-" + Conversions.ToString(mTodosBornes[i].iRegua)) && flag && Versioned.IsNumeric(mTodosBornes[i].sBorne))
				{
					num++;
					array = (StructureBornesReservas[])Utils.CopyArray(array, new StructureBornesReservas[num + 1]);
					array[num].iPainel = mTodosBornes[i].iPainel;
					array[num].iRegua = mTodosBornes[i].iRegua;
					array[num].iMaiorBorne = Conversions.ToInteger(mTodosBornes[i].sBorne);
					array[num].bAddReserva = true;
				}
			}
			int num4 = Information.UBound(array);
			for (int k = 1; k <= num4; k++)
			{
				if (!array[k].bAddReserva)
				{
					continue;
				}
				DeclaracoesEntidades.StructureBorne[] array2 = null;
				int num5 = 0;
				array2 = new DeclaracoesEntidades.StructureBorne[1];
				List<double> list = new List<double>();
				int num6 = Information.UBound(mTodosBornes);
				for (int l = 1; l <= num6; l++)
				{
					if (((array[k].iPainel == mTodosBornes[l].iPainel) & (array[k].iRegua == mTodosBornes[l].iRegua)) && Versioned.IsNumeric(mTodosBornes[l].sBorne))
					{
						list.Add(Conversions.ToDouble(mTodosBornes[l].sBorne));
					}
				}
				int iMaiorBorne = array[k].iMaiorBorne;
				for (int m = 1; m <= iMaiorBorne; m++)
				{
					if (!list.Contains(Conversions.ToDouble(m.ToString())))
					{
						num5 = Information.UBound(array2) + 1;
						array2 = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(array2, new DeclaracoesEntidades.StructureBorne[num5 + 1]);
						array2[num5].Ordem = m;
						array2[num5].Numero = Conversions.ToString(m);
						array2[num5].Alternativo = "";
						array2[num5].tipo = 0;
						array2[num5].lm = 0;
						array2[num5].Handle = "";
						array2[num5].reserva = true;
					}
				}
				if (Information.UBound(array2) > 0)
				{
					DicionarioBorne.gravaDicBornesReserva(array[k].iRegua, ref array2);
				}
			}
		}
	}

	public static bool AdicionaBornesNoDWG(double TamanhoDosEspacos, ref StructureBornesCPFL[] mTodosBornes, bool bPainel, bool bOrdem)
	{
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		string text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Cadgraph\\Eletron4\\";
		string text2 = "V_B_BORNECPFL";
		text = text + text2 + ".dwg";
		DeclaracoesGeral.Reguas RH = default;
		XDataGeral.LeXDataReguaH(ref RH);
		double num = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta;
		double num2 = 20.0;
		double num3 = 30.0;
		Point3d val = new Point3d(RH.Pti.X + TamanhoDosEspacos, RH.Pti.Y - 20.0, 0.0);
		Point3d Point = val;
		checked
		{
			try
			{
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mTodosBornes);
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num4 = 1;
				List<string> list = new List<string>();
				int num5 = Information.UBound(mTodosBornes);
				for (int i = 1; i <= num5; i++)
				{
					string item = Conversions.ToString(mTodosBornes[i].iPainel) + "|" + Conversions.ToString(mTodosBornes[i].iRegua) + "|" + mTodosBornes[i].sBorne;
					if (list.Contains(item))
					{
						mTodosBornes[i].Adicionado = true;
					}
					else
					{
						list.Add(item);
					}
				}
				int num6 = Information.UBound(mTodosBornes);
				for (int j = 1; j <= num6; j++)
				{
					if (DeclaracoesGeral.bPararRelatorio)
					{
						break;
					}
					if (!mTodosBornes[j].Adicionado)
					{
						if (DeclaracoesGeral.bPararRelatorio)
						{
							break;
						}
						if (bOrdem && Versioned.IsNumeric(mTodosBornes[j].sBorne))
						{
							num4++;
						}
						mTodosBornes[j].Adicionado = AdicionaUmBorne(ref Point, ref mTodosBornes[j], (int)Math.Round(mTodosBornes[j].iOrdem), text, text2, bPainel, bOrdem: true);
						result = true;
						Point = new Point3d(Point.X + TamanhoDosEspacos, Point.Y, 0.0);
						if (Point.X > num)
						{
							if (!(Point.Y - num2 * 2.0 < RH.AltBase))
							{
								Point = new Point3d(val.X, Point.Y - num3, 0.0);
							}
							else
							{
								string pag = Pagina.montaNumeroPagina(Pagina.EncontraProximaPagina(DeclaracoesGeral.ativo.Pagina));
								if (Operators.CompareString(DeclaracoesGeral.ativo.Pagina, pag, TextCompare: true) == 0)
								{
									if (!Pagina.criarUmaNovaPagina())
									{
										break;
									}
									DeclaracoesGeral._uscPagina.CarregaPG();
									pag = Pagina.montaNumeroPagina(Pagina.EncontraProximaPagina(DeclaracoesGeral.ativo.Pagina));
								}
								Pagina.AtivaPagina(pag);
								DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
								Point = val;
							}
						}
						Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
					}
					if (!DeclaracoesGeral.bPararRelatorio)
					{
						DeclaracoesGeral._uscPagina.pbPasso();
						continue;
					}
					break;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			DeclaracoesGeral._uscPagina.pbFim();
			return result;
		}
	}

	public static bool AdicionaUmBorne(ref Point3d Point, ref StructureBornesCPFL mBornes, int iOrdem, string sCaminhoBloco, string sNomeBloco, bool bPainel, bool bOrdem)
	{
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		clsBornes.StructureBlocoBorne myBornes = new clsBornes.StructureBlocoBorne
		{
			IndiceRegua = mBornes.iRegua,
			LM = 0,
			NomeRegua = mBornes.sRegua,
			numero = mBornes.sBorne,
			ordem = iOrdem,
			Painel = mBornes.sPainel,
			sCaminhoBloco = sCaminhoBloco,
			sNomeDoBloco = sNomeBloco,
			tipo = 0,
			Visivel = -1,
			conector = "",
			numeroComplem = ""
		};
		clsBornes.InserirBorne(ref myBornes, 2, bPrimeiro: true, bPainel, bRegua: true, ref Point);
		mBornes.Point1 = new Point3d(Point.X, Point.Y, 0.0);
		mBornes.sHandle = myBornes.Handle;
		mBornes.Layer = myBornes.Pagina;
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		return true;
	}

	public static void AdicionaCabosNoDWG(ref StructureBornesCPFL[] mTodosBornes, ref StructureInterligCFEL[] mInterligacoes, double distancia)
	{
		DeclaracoesGeral.Reguas RH = default;
		bool flag = false;
		DeclaracoesGeral.Reguas RH2 = default;
		bool flag2 = false;
		flag = XDataGeral.LeXDataReguaH(ref RH);
		flag2 = XDataGeral.LeXDataReguaV(ref RH2);
		int num = Information.UBound(mInterligacoes);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			StructureInterligCFEL structureInterligCFEL = mInterligacoes[i];
			if (!((Operators.CompareString(structureInterligCFEL.sReguaDE, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) == 0) | (Operators.CompareString(structureInterligCFEL.sReguaPARA, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) == 0)) && !structureInterligCFEL.Adicionado)
			{
				Ey3pnQL4Ry(ref mTodosBornes, ref structureInterligCFEL, distancia, RH, RH2, flag, flag2);
			}
			mInterligacoes[i].Adicionado = true;
		}
		clsEditarInterligacao.InsereTextosDeCabos();
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
	}

	public static void AdicionaBlindagensNoDWG(ref StructureBornesCPFL[] mTodosBornes, ref StructureInterligCFEL[] mBlindagens, double distancia)
	{
		DeclaracoesGeral.Reguas RH = default;
		bool flag = false;
		DeclaracoesGeral.Reguas RH2 = default;
		bool flag2 = false;
		flag = XDataGeral.LeXDataReguaH(ref RH);
		flag2 = XDataGeral.LeXDataReguaV(ref RH2);
		int num = Information.UBound(mBlindagens);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			StructureInterligCFEL structureInterligCFEL = mBlindagens[i];
			if (!structureInterligCFEL.Adicionado)
			{
				GZtp1Yu60B(ref mTodosBornes, ref structureInterligCFEL, distancia, RH, RH2, flag, flag2);
			}
			mBlindagens[i].Adicionado = true;
		}
		clsEditarInterligacao.InsereTextosDeCabos();
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
	}

	private static void Ey3pnQL4Ry(ref StructureBornesCPFL[] P_0, ref StructureInterligCFEL P_1, double P_2, DeclaracoesGeral.Reguas P_3, DeclaracoesGeral.Reguas P_4, bool P_5, bool P_6)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected Obj, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Obj, but got Unknown
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Expected Obj, but got Unknown
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_081b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0434: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Unknown result type (might be due to invalid IL or missing references)
		//IL_049e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a5: Expected Obj, but got Unknown
		//IL_04e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_050f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0514: Unknown result type (might be due to invalid IL or missing references)
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_052f: Unknown result type (might be due to invalid IL or missing references)
		//IL_053b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0560: Unknown result type (might be due to invalid IL or missing references)
		//IL_0585: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0606: Unknown result type (might be due to invalid IL or missing references)
		//IL_060b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0623: Unknown result type (might be due to invalid IL or missing references)
		//IL_0628: Unknown result type (might be due to invalid IL or missing references)
		//IL_06da: Unknown result type (might be due to invalid IL or missing references)
		//IL_06df: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_090a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0924: Unknown result type (might be due to invalid IL or missing references)
		//IL_0929: Unknown result type (might be due to invalid IL or missing references)
		//IL_0941: Unknown result type (might be due to invalid IL or missing references)
		//IL_0946: Unknown result type (might be due to invalid IL or missing references)
		//IL_0994: Unknown result type (might be due to invalid IL or missing references)
		//IL_099b: Expected Obj, but got Unknown
		//IL_09e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e8: Expected Obj, but got Unknown
		//IL_09fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a01: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a33: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3a: Expected Obj, but got Unknown
		//IL_0a42: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a59: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a79: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a80: Expected Obj, but got Unknown
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		string pagina = DeclaracoesGeral.ativo.Pagina;
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
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					try
					{
						int num5 = 0;
						int num6 = Information.UBound(P_0);
						for (int i = 1; i <= num6; i++)
						{
							if ((P_0[i].iPainel == P_1.iPainelDE) & (P_0[i].iRegua == P_1.iReguaDE) & (Operators.CompareString(P_0[i].sBorne, P_1.sBorneDE, TextCompare: true) == 0) & (P_0[i].Point1.X != 0.0))
							{
								num = i;
								num5++;
								if (P_0[i].bCDE1)
								{
									if (P_0[i].bCDE2)
									{
										if (P_0[i].bCDE3)
										{
											if (P_0[i].bCDE4)
											{
												P_0[i].bCDE4 = true;
												num3 = 18;
											}
											else
											{
												P_0[i].bCDE4 = true;
												num3 = 14;
											}
										}
										else
										{
											P_0[i].bCDE3 = true;
											num3 = 10;
										}
									}
									else
									{
										P_0[i].bCDE2 = true;
										num3 = 6;
									}
								}
								else
								{
									P_0[i].bCDE1 = true;
									num3 = 2;
								}
							}
							if ((P_0[i].iPainel == P_1.iPainelPARA) & (P_0[i].iRegua == P_1.iReguaPara) & (Operators.CompareString(P_0[i].sBorne, P_1.sBornePARA, TextCompare: true) == 0) & (P_0[i].Point1.X != 0.0))
							{
								num2 = i;
								num5++;
								if (P_0[i].bCPARA1)
								{
									if (P_0[i].bCPARA2)
									{
										if (P_0[i].bCPARA3)
										{
											if (P_0[i].bCPARA4)
											{
												P_0[i].bCPARA4 = true;
												num4 = 18;
											}
											else
											{
												P_0[i].bCPARA4 = true;
												num4 = 14;
											}
										}
										else
										{
											P_0[i].bCPARA3 = true;
											num4 = 10;
										}
									}
									else
									{
										P_0[i].bCPARA2 = true;
										num4 = 6;
									}
								}
								else
								{
									P_0[i].bCPARA1 = true;
									num4 = 2;
								}
							}
							if ((num != 0) & (num2 != 0))
							{
								break;
							}
						}
						double num7 = P_2 / 11.0 * 5.0;
						Polyline pl = new Polyline();
						Point3d val5 = new Point3d(P_0[num].Point1.X, P_0[num].Point1.Y - 5.0, 0.0);
						Point2d val6 = new Point2d(val5.X, val5.Y);
						Point2d val7 = new Point2d(val5.X, val5.Y - (double)num3);
						Point2d val8 = new Point2d(val5.X + num7, val5.Y - (double)num3);
						((Entity)pl).SetDatabaseDefaults();
						string text = P_1.sNome.ToUpper();
						if (!text.EndsWith("BL"))
						{
							pl.AddVertexAt(0, val6, 0.0, 0.0, 0.0);
							pl.AddVertexAt(1, val7, 0.0, 0.0, 0.0);
							pl.AddVertexAt(2, val8, 0.0, 0.0, 0.0);
						}
						else
						{
							pl.AddVertexAt(0, val8, 0.0, 0.0, 0.0);
							pl.AddVertexAt(1, val7, 0.0, 0.0, 0.0);
							pl.AddVertexAt(2, val6, 0.0, 0.0, 0.0);
						}
						((Entity)pl).Layer = P_0[num].Layer;
						((Entity)pl).LineWeight = (LineWeight)9;
						((Entity)pl).ColorIndex = DeclaracoesGeral.Conf.CorInterligacao;
						val4.AppendEntity((Entity)(object)pl);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)pl, true);
						Polyline pl2 = new Polyline();
						Point3d val9 = new Point3d(P_0[num2].Point1.X - num7, P_0[num2].Point1.Y - (double)num4 - 5.0, 0.0);
						Point2d val10 = new Point2d(val9.X, val9.Y);
						Point2d val11 = new Point2d(val9.X + num7, val9.Y);
						Point2d val12 = new Point2d(val9.X + num7, val9.Y + (double)num4);
						((Entity)pl2).SetDatabaseDefaults();
						pl2.AddVertexAt(0, val10, 0.0, 0.0, 0.0);
						pl2.AddVertexAt(1, val11, 0.0, 0.0, 0.0);
						pl2.AddVertexAt(2, val12, 0.0, 0.0, 0.0);
						((Entity)pl2).Layer = P_0[num2].Layer;
						((Entity)pl2).LineWeight = (LineWeight)9;
						((Entity)pl2).ColorIndex = DeclaracoesGeral.Conf.CorInterligacao;
						val4.AppendEntity((Entity)(object)pl2);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)pl2, true);
						int num8 = 2;
						DeclaracoesEntidades.StructureInterligacao ilig = new DeclaracoesEntidades.StructureInterligacao
						{
							Tipo = 2,
							Handle1 = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString(),
							Handle2 = ((object)((DBObject)pl2).Handle/*cast due to constrained. prefix*/).ToString(),
							Tag_Cabo = P_1.s_Cabo.ToString(),
							NumVeia = P_1.indice,
							NomeVeia = P_1.sNome,
							ocultaTag = 0,
							Usuario = Environment.UserName,
							Data = DateTime.Now.ToString(),
							Painel1 = (short)P_0[num].iPainel,
							Painel2 = 0,
							THandle1 = "",
							THandle2 = ""
						};
						DeclaracoesEntidades.StructureInterligacao ilig2 = new DeclaracoesEntidades.StructureInterligacao
						{
							Tipo = 2,
							Handle1 = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString(),
							Handle2 = ((object)((DBObject)pl2).Handle/*cast due to constrained. prefix*/).ToString(),
							Tag_Cabo = P_1.s_Cabo.ToString(),
							NumVeia = P_1.indice,
							NomeVeia = P_1.sNome,
							ocultaTag = 0,
							Usuario = Environment.UserName,
							Data = DateTime.Now.ToString(),
							Painel1 = 0,
							Painel2 = (short)P_0[num2].iPainel,
							THandle1 = "",
							THandle2 = ""
						};
						if (text.EndsWith("BL"))
						{
							num8 = 3;
							ilig.Tipo = 3;
							ilig.Painel1 = 0;
							ilig.Painel2 = (short)P_0[num].iPainel;
							ilig2.Tipo = 3;
							ilig2.Painel1 = 0;
							ilig2.Painel2 = (short)P_0[num2].iPainel;
						}
						if (num8 != 2)
						{
							XDataInterligacao.GravarXDataInterligacao(ref pl, ref ilig, 0);
							XDataInterligacao.GravarXDataInterligacao(ref pl2, ref ilig2, 0);
						}
						else
						{
							DeclaracoesGeral.ativo.Pagina = ((Entity)pl).Layer;
							DBText val13 = clsInterligacao.criarTextoCruzamentoCabo(pl, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, ((Entity)pl).Layer, 1);
							val4.AppendEntity((Entity)(object)val13);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val13, true);
							DeclaracoesGeral.ativo.Pagina = ((Entity)pl2).Layer;
							DBText val14 = clsInterligacao.criarTextoCruzamentoCabo(pl2, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, ((Entity)pl2).Layer, 2);
							val4.AppendEntity((Entity)(object)val14);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val14, true);
							ilig.THandle1 = ((object)((DBObject)val13).Handle/*cast due to constrained. prefix*/).ToString();
							ilig2.THandle2 = ((object)((DBObject)val14).Handle/*cast due to constrained. prefix*/).ToString();
							((DBObject)val13).UpgradeOpen();
							((Entity)val13).Layer = ((Entity)pl).Layer;
							DBText val15 = val13;
							string pagina2 = ((Entity)val14).Layer.ToString();
							Entity ent = (Entity)(object)val14;
							string posicao = Pagina.calculaLinhaColuna(ref ent, ref P_3, ref P_4, P_5, P_6);
							val14 = (DBText)ent;
							val15.TextString = Pagina.montaCruzamentoPagina(pagina2, posicao);
							((DBObject)val14).UpgradeOpen();
							((Entity)val14).Layer = ((Entity)pl2).Layer;
							DBText val16 = val14;
							string pagina3 = ((Entity)val13).Layer.ToString();
							ent = (Entity)(object)val13;
							posicao = Pagina.calculaLinhaColuna(ref ent, ref P_3, ref P_4, P_5, P_6);
							val13 = (DBText)ent;
							val16.TextString = Pagina.montaCruzamentoPagina(pagina3, posicao);
							ent = (Entity)(object)val13;
							XDataInterligacao.GravarXDataAuxInterligacao(ref ent, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString(), 2, ((object)((DBObject)val14).Handle/*cast due to constrained. prefix*/).ToString());
							val13 = (DBText)ent;
							ent = (Entity)(object)val14;
							XDataInterligacao.GravarXDataAuxInterligacao(ref ent, ((object)((DBObject)pl2).Handle/*cast due to constrained. prefix*/).ToString(), 2, ((object)((DBObject)val13).Handle/*cast due to constrained. prefix*/).ToString());
							val14 = (DBText)ent;
							XDataInterligacao.GravarXDataInterligacao(ref pl, ref ilig, 1);
							XDataInterligacao.GravarXDataInterligacao(ref pl2, ref ilig2, 2);
						}
						hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						val2.Abort();
						Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
						ProjectData.ClearProjectError();
					}
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
			DeclaracoesGeral.ativo.Pagina = pagina;
		}
	}

	private static void GZtp1Yu60B(ref StructureBornesCPFL[] P_0, ref StructureInterligCFEL P_1, double P_2, DeclaracoesGeral.Reguas P_3, DeclaracoesGeral.Reguas P_4, bool P_5, bool P_6)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected Obj, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected Obj, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected Obj, but got Unknown
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		string pagina = DeclaracoesGeral.ativo.Pagina;
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
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					try
					{
						int num2 = 0;
						int num3 = Information.UBound(P_0);
						for (int i = 1; i <= num3; i++)
						{
							if ((P_0[i].iPainel == P_1.iPainelDE) & (P_0[i].iRegua == P_1.iReguaDE) & (Operators.CompareString(P_0[i].sBorne, P_1.sBorneDE, TextCompare: true) == 0))
							{
								num = i;
								num2++;
								if (P_0[i].bCDE1)
								{
									if (P_0[i].bCDE2)
									{
										if (P_0[i].bCDE3)
										{
											if (P_0[i].bCDE4)
											{
												P_0[i].bCDE4 = true;
											}
											else
											{
												P_0[i].bCDE4 = true;
											}
										}
										else
										{
											P_0[i].bCDE3 = true;
										}
									}
									else
									{
										P_0[i].bCDE2 = true;
									}
								}
								else
								{
									P_0[i].bCDE1 = true;
								}
							}
							if (num2 == 1)
							{
								break;
							}
						}
						Polyline pl = new Polyline();
						Point3d val5 = new Point3d(P_0[num].Point1.X, P_0[num].Point1.Y - 5.0, 0.0);
						((Entity)pl).SetDatabaseDefaults();
						P_1.sNome.ToUpper();
						val5 = new Point3d(P_0[num].Point1.X, P_0[num].Point1.Y - 5.0, 0.0);
						Point2d val6 = new Point2d(val5.X, val5.Y);
						Point2d val7 = new Point2d(val5.X, val5.Y - 3.0);
						Point2d val8 = new Point2d(val5.X, val5.Y - 17.0);
						pl.AddVertexAt(0, val8, 0.0, 0.0, 0.0);
						pl.AddVertexAt(1, val7, 0.0, 0.0, 0.0);
						pl.AddVertexAt(2, val6, 0.0, 0.0, 0.0);
						pl.AddVertexAt(pl.NumberOfVertices, val6, 0.0, 0.0, 0.0);
						DeclaracoesEntidades.StructureInterligacao ilig = new DeclaracoesEntidades.StructureInterligacao
						{
							Tipo = 3,
							Tag_Cabo = P_1.s_Cabo.ToString(),
							NumVeia = P_1.indice,
							NomeVeia = P_1.sNome,
							iModeloVeiaFuncao = 0,
							ocultaTag = 0,
							Painel1 = 0,
							Painel2 = (short)P_0[num].iPainel,
							Usuario = Environment.UserName,
							Data = DateTime.Now.ToString()
						};
						((Entity)pl).SetDatabaseDefaults();
						pl.AddVertexAt(0, val8, 0.0, 0.0, 0.0);
						pl.AddVertexAt(1, val7, 0.0, 0.0, 0.0);
						pl.AddVertexAt(2, val6, 0.0, 0.0, 0.0);
						((Entity)pl).Layer = P_0[num].Layer;
						((Entity)pl).LineWeight = (LineWeight)9;
						((Entity)pl).ColorIndex = DeclaracoesGeral.Conf.CorInterligacao;
						val4.AppendEntity((Entity)(object)pl);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)pl, true);
						XDataInterligacao.GravarXDataInterligacao(ref pl, ref ilig, 0);
						hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						val2.Abort();
						Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
						ProjectData.ClearProjectError();
					}
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
			DeclaracoesGeral.ativo.Pagina = pagina;
		}
	}

	public static void AdicionaJUMPERSNoDWG(ref StructureBornesCPFL[] mTodosBornes, ref StructureJUMPERCFEL[] mJUMPERS, double distancia)
	{
		DeclaracoesGeral.Reguas RH = default;
		bool flag = false;
		DeclaracoesGeral.Reguas RH2 = default;
		bool flag2 = false;
		flag = XDataGeral.LeXDataReguaH(ref RH);
		flag2 = XDataGeral.LeXDataReguaV(ref RH2);
		int num = Information.UBound(mJUMPERS);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			StructureJUMPERCFEL structureJUMPERCFEL = mJUMPERS[i];
			if (!((Operators.CompareString(structureJUMPERCFEL.sReguaDE, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) == 0) | (Operators.CompareString(structureJUMPERCFEL.sReguaPARA, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) == 0)) && !structureJUMPERCFEL.Adicionado)
			{
				c9HplyQjUH(ref mTodosBornes, ref structureJUMPERCFEL, distancia, i, RH, RH2, flag, flag2);
			}
			mJUMPERS[i].Adicionado = true;
		}
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
	}

	private static void c9HplyQjUH(ref StructureBornesCPFL[] P_0, ref StructureJUMPERCFEL P_1, double P_2, int P_3, DeclaracoesGeral.Reguas P_4, DeclaracoesGeral.Reguas P_5, bool P_6, bool P_7)
	{
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected Obj, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected Obj, but got Unknown
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Expected Obj, but got Unknown
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0423: Unknown result type (might be due to invalid IL or missing references)
		//IL_0433: Unknown result type (might be due to invalid IL or missing references)
		//IL_0438: Unknown result type (might be due to invalid IL or missing references)
		//IL_0456: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0472: Unknown result type (might be due to invalid IL or missing references)
		//IL_0477: Unknown result type (might be due to invalid IL or missing references)
		//IL_0483: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0521: Unknown result type (might be due to invalid IL or missing references)
		//IL_0537: Unknown result type (might be due to invalid IL or missing references)
		//IL_053e: Expected Obj, but got Unknown
		//IL_0572: Unknown result type (might be due to invalid IL or missing references)
		//IL_0577: Unknown result type (might be due to invalid IL or missing references)
		//IL_0587: Unknown result type (might be due to invalid IL or missing references)
		//IL_058c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0620: Unknown result type (might be due to invalid IL or missing references)
		//IL_0674: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0737: Unknown result type (might be due to invalid IL or missing references)
		//IL_0757: Unknown result type (might be due to invalid IL or missing references)
		//IL_075c: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b8: Expected Obj, but got Unknown
		//IL_07fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0805: Expected Obj, but got Unknown
		checked
		{
			DeclaracoesEntidades.StructureConexao conex = new DeclaracoesEntidades.StructureConexao
			{
				Tipo = 4,
				Nome = "",
				Handle = "",
				Tensao = "",
				Aplicacao = 0,
				Jumper = "JUMPER",
				Usuario = Environment.UserName,
				Data = DateTime.Now.ToString(),
				Potencial = XDataConexao.BuscaPotencial(),
				Secao = P_1.sSecao,
				Cor = P_1.sCor,
				Funcao = P_1.sFuncao,
				Enderecamento = 1,
				Painel = (short)P_1.iPainelDE
			};
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					try
					{
						int num5 = 0;
						int num6 = Information.UBound(P_0);
						for (int i = 1; i <= num6; i++)
						{
							if ((P_0[i].iPainel == P_1.iPainelDE) & (P_0[i].iRegua == P_1.iReguaDE) & (Operators.CompareString(P_0[i].sBorne, P_1.sBorneDE, TextCompare: true) == 0) & (P_0[i].Point1.X != 0.0))
							{
								num = i;
								num5++;
								if (P_0[i].bJDE1)
								{
									if (P_0[i].bJDE2)
									{
										if (P_0[i].bJDE3)
										{
											if (P_0[i].bJDE4)
											{
												P_0[i].bJDE4 = true;
												num3 = -20;
											}
											else
											{
												P_0[i].bJDE4 = true;
												num3 = -16;
											}
										}
										else
										{
											P_0[i].bJDE3 = true;
											num3 = -12;
										}
									}
									else
									{
										P_0[i].bJDE2 = true;
										num3 = -8;
									}
								}
								else
								{
									P_0[i].bJDE1 = true;
									num3 = -4;
								}
							}
							if ((P_0[i].iPainel == P_1.iPainelPARA) & (P_0[i].iRegua == P_1.iReguaPara) & (Operators.CompareString(P_0[i].sBorne, P_1.sBornePARA, TextCompare: true) == 0) & (P_0[i].Point1.X != 0.0))
							{
								num2 = i;
								num5++;
								if (P_0[i].bJPARA1)
								{
									if (P_0[i].bJPARA2)
									{
										if (P_0[i].bJPARA3)
										{
											if (P_0[i].bJPARA4)
											{
												P_0[i].bJPARA4 = true;
												num4 = -20;
											}
											else
											{
												P_0[i].bJPARA4 = true;
												num4 = -16;
											}
										}
										else
										{
											P_0[i].bJPARA3 = true;
											num4 = -12;
										}
									}
									else
									{
										P_0[i].bJPARA2 = true;
										num4 = -8;
									}
								}
								else
								{
									P_0[i].bJPARA1 = true;
									num4 = -4;
								}
							}
							if ((num != 0) & (num2 != 0))
							{
								break;
							}
						}
						double num7 = P_2 / 11.0 * 5.0;
						Polyline pl = new Polyline();
						Point3d val5 = new Point3d(P_0[num].Point1.X, P_0[num].Point1.Y, 0.0);
						Point2d val6 = new Point2d(val5.X, val5.Y);
						Point2d val7 = new Point2d(val5.X + 2.0, val5.Y - (double)num3);
						Point2d val8 = new Point2d(val5.X + num7, val5.Y - (double)num3);
						((Entity)pl).SetDatabaseDefaults();
						pl.AddVertexAt(0, val6, 0.0, 0.0, 0.0);
						pl.AddVertexAt(1, val7, 0.0, 0.0, 0.0);
						pl.AddVertexAt(2, val8, 0.0, 0.0, 0.0);
						((Entity)pl).Layer = P_0[num].Layer;
						((Entity)pl).LineWeight = (LineWeight)9;
						((Entity)pl).ColorIndex = DeclaracoesGeral.Conf.CorInterligacao;
						val4.AppendEntity((Entity)(object)pl);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)pl, true);
						Polyline pl2 = new Polyline();
						Point3d val9 = new Point3d(P_0[num2].Point1.X - num7, P_0[num2].Point1.Y - (double)num4, 0.0);
						Point2d val10 = new Point2d(val9.X, val9.Y);
						Point2d val11 = new Point2d(val9.X + num7 - 2.0, val9.Y);
						Point2d val12 = new Point2d(val9.X + num7, val9.Y + (double)num4);
						((Entity)pl2).SetDatabaseDefaults();
						pl2.AddVertexAt(0, val10, 0.0, 0.0, 0.0);
						pl2.AddVertexAt(1, val11, 0.0, 0.0, 0.0);
						pl2.AddVertexAt(2, val12, 0.0, 0.0, 0.0);
						((Entity)pl2).Layer = P_0[num2].Layer;
						((Entity)pl2).LineWeight = (LineWeight)9;
						((Entity)pl2).ColorIndex = DeclaracoesGeral.Conf.CorInterligacao;
						val4.AppendEntity((Entity)(object)pl2);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)pl2, true);
						conex.Disp1 = true;
						conex.Disp2 = false;
						XDataConexao.GravarXDataConexao(ref pl, conex);
						clsConexao clsConexao2 = new clsConexao();
						DBText text = clsConexao2.criarTextoDePara(conex, pl, DeclaracoesGeral.ativo.Pagina, 2);
						val4.AppendEntity((Entity)(object)text);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)text, true);
						XDataConexao.GravarXDataAuxCircuito(ref text, conex.Potencial, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString(), conex.Enderecamento, 3);
						conex.Disp1 = false;
						conex.Disp2 = true;
						XDataConexao.GravarXDataConexao(ref pl2, conex);
						DBText text2 = clsConexao2.criarTextoDePara(conex, pl2, DeclaracoesGeral.ativo.Pagina, 1);
						val4.AppendEntity((Entity)(object)text2);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)text2, true);
						XDataConexao.GravarXDataAuxCircuito(ref text2, conex.Potencial, ((object)((DBObject)pl2).Handle/*cast due to constrained. prefix*/).ToString(), conex.Enderecamento, 2);
						((DBObject)text).UpgradeOpen();
						((Entity)text).Layer = ((Entity)pl).Layer;
						DBText val13 = text;
						string pagina = ((Entity)text2).Layer.ToString();
						Entity ent = (Entity)(object)text2;
						string posicao = Pagina.calculaLinhaColuna(ref ent, ref P_4, ref P_5, P_6, P_7);
						text2 = (DBText)ent;
						val13.TextString = Pagina.montaCruzamentoPagina(pagina, posicao);
						((DBObject)text2).UpgradeOpen();
						((Entity)text2).Layer = ((Entity)pl2).Layer;
						DBText val14 = text2;
						string pagina2 = ((Entity)text).Layer.ToString();
						ent = (Entity)(object)text;
						posicao = Pagina.calculaLinhaColuna(ref ent, ref P_4, ref P_5, P_6, P_7);
						text = (DBText)ent;
						val14.TextString = Pagina.montaCruzamentoPagina(pagina2, posicao);
						hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						val2.Abort();
						Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
						ProjectData.ClearProjectError();
					}
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

	public static void ExportaModeloBornesInterligacaoCPFL(ref Worksheet oSheet)
	{
		string text = "";
		text = "A1:Z10000";
		((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
		((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).RowHeight = 15;
		int num = 1;
		checked
		{
			string cell;
			do
			{
				cell = ExcFuncoesExcel.mudaNumeroAsc(num) + "1";
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				num++;
			}
			while (num <= 15);
			text = "D1";
			cell = "A1:A2";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1083].ToString().ToUpper());
			cell = "B1:C1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1456].ToString().ToUpper());
			cell = "B2";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1244].ToString().ToUpper());
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
			cell = "C2";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1285].ToString().ToUpper());
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
			cell = "D2";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 5;
			cell = "E1:G1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1618].ToString().ToUpper());
			cell = "E2";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1005].ToString().ToUpper());
			cell = "F2";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1429].ToString().ToUpper());
			cell = "G2";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 984].ToString().ToUpper());
			cell = "H1:H2";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1569].ToString().ToUpper());
			cell = "I1:K1";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1619].ToString().ToUpper());
			cell = "I2";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 984].ToString().ToUpper());
			cell = "J2";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1429].ToString().ToUpper());
			cell = "K2";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1005].ToString().ToUpper());
			cell = "L1:L2";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1243].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(12L), "1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1271]), 37, 1, 60);
			cell = "M1:M2";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1246].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(13L), "1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1271]), 37, 1, 60);
			cell = "N1:N2";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Merge(RuntimeHelpers.GetObjectValue(Missing.Value));
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)DeclaracoesGeral.mMensagem[1, 1248].ToString().ToUpper());
			ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(14L), "1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1271]), 37, 1, 60);
			cell = "A1:N2";
			ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, cell);
			ExcFuncoesExcel.CriaLinhasExterna(ref oSheet, cell, bCompleto: true);
			List<string> list = new List<string>();
			list.Add("1P1");
			list.Add("1P2");
			list.Add("2P1");
			list.Add("2P2");
			list.Add("3P1");
			list.Add("3P2");
			list.Add("4P1");
			list.Add("4P2");
			list.Add("5P1");
			list.Add("5P2");
			list.Add("6P1");
			list.Add("6P2");
			cell = "A3:N100";
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
			int num2 = 2;
			int num3 = 1;
			do
			{
				num2++;
				cell = "A" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"CABO1");
				cell = "B" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"COMANDO");
				cell = "C" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"12x2,5");
				cell = "E" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"PN1");
				cell = "F" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + Conversions.ToString(num2 + 159)));
				cell = "G" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"X1");
				cell = "H" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)(num2 - 2));
				cell = "I" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"X1");
				cell = "J" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + Conversions.ToString(num2 + 195)));
				cell = "K" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"PN2");
				cell = "L" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"2");
				cell = "M" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"50");
				cell = "N" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"C34;C33;C31");
				num3++;
			}
			while (num3 <= 10);
			int num4 = 1;
			do
			{
				num2++;
				cell = "A" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"CABO2");
				cell = "B" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"COMANDO");
				cell = "C" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"6Px2,5(blindado)");
				cell = "E" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"PN1");
				cell = "F" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + Conversions.ToString(num2 + 52)));
				cell = "G" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"X1");
				cell = "H" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)list[num4 - 1]);
				cell = "I" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"X2");
				cell = "J" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + Conversions.ToString(num2 + 360)));
				cell = "K" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"PN3");
				if (num4 == 2)
				{
					num2++;
					cell = "A" + Conversions.ToString(num2);
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"CABO2");
					cell = "B" + Conversions.ToString(num2);
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"COMANDO");
					cell = "C" + Conversions.ToString(num2);
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"6Px2,5(blindado)");
					cell = "E" + Conversions.ToString(num2);
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"PN1");
					cell = "F" + Conversions.ToString(num2);
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'2");
					cell = "G" + Conversions.ToString(num2);
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"BT");
					cell = "H" + Conversions.ToString(num2);
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"1BL");
				}
				if (num4 == 4)
				{
					num2++;
					cell = "A" + Conversions.ToString(num2);
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"CABO2");
					cell = "B" + Conversions.ToString(num2);
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"COMANDO");
					cell = "C" + Conversions.ToString(num2);
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"6Px2,5(blindado)");
					cell = "E" + Conversions.ToString(num2);
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"PN1");
					cell = "F" + Conversions.ToString(num2);
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'4");
					cell = "G" + Conversions.ToString(num2);
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"BT");
					cell = "H" + Conversions.ToString(num2);
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"2BL");
					cell = "I" + Conversions.ToString(num2);
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"BT");
					cell = "J" + Conversions.ToString(num2);
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'7");
					cell = "K" + Conversions.ToString(num2);
					((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"PN3");
				}
				num4++;
			}
			while (num4 <= 10);
			num2++;
			cell = "A" + Conversions.ToString(num2);
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"CABO2");
			cell = "B" + Conversions.ToString(num2);
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"COMANDO");
			cell = "C" + Conversions.ToString(num2);
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"6Px2,5(blindado)");
			cell = "E" + Conversions.ToString(num2);
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"PN1");
			cell = "F" + Conversions.ToString(num2);
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'10");
			cell = "G" + Conversions.ToString(num2);
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"BT");
			cell = "H" + Conversions.ToString(num2);
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"BL");
			cell = "I" + Conversions.ToString(num2);
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"BT");
			cell = "J" + Conversions.ToString(num2);
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"'1");
			cell = "K" + Conversions.ToString(num2);
			((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"PN3");
			int num5 = 1;
			do
			{
				num2++;
				cell = "A" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"JUMPER");
				cell = "C" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"2,5");
				cell = "E" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"PN1");
				cell = "F" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + Conversions.ToString(num2 + 56)));
				cell = "G" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"X1");
				cell = "H" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"PT");
				cell = "I" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"X1");
				cell = "J" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + Conversions.ToString(num2 + 358)));
				cell = "K" + Conversions.ToString(num2);
				((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"PN1");
				num5++;
			}
			while (num5 <= 10);
			cell = "A3:N" + Conversions.ToString(num2);
			ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, cell);
		}
	}

	public static void LimpaTodoDesenho()
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected Obj, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected Obj, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected Obj, but got Unknown
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Expected Obj, but got Unknown
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Expected Obj, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected Obj, but got Unknown
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Expected Obj, but got Unknown
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Expected Obj, but got Unknown
		//IL_0407: Unknown result type (might be due to invalid IL or missing references)
		//IL_040e: Expected Obj, but got Unknown
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b8: Expected Obj, but got Unknown
		PointMonitorToolTips.StopMonitor();
		List<string> list = new List<string>();
		try
		{
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
							if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
							{
								if (!list.Contains(ilig.Tag_Cabo))
								{
									list.Add(ilig.Tag_Cabo);
								}
								ilig.Tag_Cabo = "";
								ilig.NumVeia = -1000;
								ilig.NomeVeia = "";
								ilig.ocultaTag = 0;
								((DBObject)pl).UpgradeOpen();
								XDataInterligacao.AtualizaXDataInterligacao(ref pl, ref ilig);
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
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
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
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		checked
		{
			int num = list.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				cDadosAccessInterligacao3.RemoveCaboErro(list[i]);
			}
			cDadosAccessInterligacao3.FechaConexao();
			try
			{
				DocumentLock val12 = Application.DocumentManager.MdiActiveDocument.LockDocument();
				try
				{
					Database database3 = Application.DocumentManager.MdiActiveDocument.Database;
					Transaction val13 = database3.TransactionManager.StartTransaction();
					try
					{
						BlockTable val14 = (BlockTable)val13.GetObject(database3.BlockTableId, (OpenMode)0);
						BlockTableRecord val15 = (BlockTableRecord)val13.GetObject(((SymbolTable)val14)[BlockTableRecord.ModelSpace], (OpenMode)0);
						BlockTableRecordEnumerator enumerator3 = default;
						try
						{
							enumerator3 = val15.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								ObjectId current3 = enumerator3.Current;
								Entity val16 = (Entity)val13.GetObject(current3, (OpenMode)0);
								BlockReference val17 = (BlockReference)(object)((val16 is BlockReference) ? val16 : null);
								if (val17 == null)
								{
									Polyline pl2 = (Polyline)(object)((val16 is Polyline) ? val16 : null);
									if (pl2 != null)
									{
										DeclaracoesEntidades.StructureInterligacao ilig2 = default;
										if (XDataInterligacao.lerXDataInterligacao(ref pl2, ref ilig2))
										{
											((DBObject)val16).UpgradeOpen();
											((DBObject)val16).Erase();
											continue;
										}
										DeclaracoesEntidades.StructureConexao conex = default;
										if (XDataConexao.lerXDataConexao(ref pl2, ref conex) && Operators.CompareString(conex.Jumper, "JUMPER", TextCompare: true) == 0)
										{
											((DBObject)val16).UpgradeOpen();
											((DBObject)val16).Erase();
											continue;
										}
									}
									DBText val18 = (DBText)(object)((val16 is DBText) ? val16 : null);
									if (val18 == null)
									{
										continue;
									}
									if (val18 != null)
									{
										Entity ent = (Entity)(object)val18;
										bool flag = XDataGeral.TemXData(ref ent, "AUXINTERLIG");
										val18 = (DBText)ent;
										if (flag && !((DBObject)val18).IsErased)
										{
											((DBObject)val16).UpgradeOpen();
											((DBObject)val16).Erase();
											continue;
										}
									}
									ResultBuffer val19 = null;
									val19 = ((DBObject)val18).GetXDataForApplication("AUXCONEXAO");
									if (val19 != null)
									{
										((DBObject)val16).UpgradeOpen();
										((DBObject)val16).Erase();
									}
								}
								else
								{
									Entity ent = (Entity)(object)val17;
									string sOpcionais = "";
									string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref sOpcionais);
									val17 = (BlockReference)ent;
									string left = text;
									if (Operators.CompareString(left, "B", TextCompare: true) == 0)
									{
										((DBObject)val16).UpgradeOpen();
										((DBObject)val16).Erase();
									}
								}
							}
						}
						finally
						{
							((IDisposable)enumerator3)?.Dispose();
						}
						DeclaracoesGeral.bAnularEventos = true;
						val13.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					catch (Exception projectError4)
					{
						ProjectData.SetProjectError(projectError4);
						val13.Abort();
						throw;
					}
					finally
					{
						((IDisposable)val13)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)val12)?.Dispose();
				}
			}
			catch (Exception projectError5)
			{
				ProjectData.SetProjectError(projectError5);
				ProjectData.ClearProjectError();
			}
			Declaracoes2.StructureModeloDeReguas[] mModelo = new Declaracoes2.StructureModeloDeReguas[1];
			DicionarioReguas.GravaOsModelosDeRegua(mModelo);
			Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
		}
	}

	public static void ApagaTodosOsBornesReserva()
	{
		Declaracoes2.StructureModeloDeReguas[] mModelo = new Declaracoes2.StructureModeloDeReguas[1];
		DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
		int num = Information.UBound(mModelo);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			DeclaracoesEntidades.StructureBorne[] array = null;
			array = new DeclaracoesEntidades.StructureBorne[1];
			int qSimples = 0;
			int qDuplo = 0;
			DicionarioBorne.LeDicBornesReserva(mModelo[i].indexRegua, ref array, ref qSimples, ref qDuplo);
			array = new DeclaracoesEntidades.StructureBorne[1];
			DicionarioBorne.gravaDicBornesReserva(mModelo[i].indexRegua, ref array);
		}
	}
}
