using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

[StandardModule]
public sealed class Geral
{
	public static void extraiNomeCaminhoDwg(string nome, ref string nomeDWG, ref string caminho)
	{
		nomeDWG = "";
		caminho = "";
		string[] array = nome.Split('\\');
		checked
		{
			int num = Information.UBound(array) - 1;
			for (int i = 0; i <= num; i++)
			{
				caminho = caminho + array[i] + "\\";
			}
			nomeDWG = array[Information.UBound(array)];
			nomeDWG = Strings.Mid(nomeDWG, 1, Strings.Len(nomeDWG) - 4);
		}
	}

	public static string leCompany(int indice)
	{
		string result = "?";
		switch (indice)
		{
		case 111:
			result = "PRONEXT5";
			break;
		case 0:
			result = "CADGRAPH";
			break;
		case 2:
			result = "ARTECHE";
			break;
		case 4:
			result = "INVALIDA";
			break;
		case 5:
			result = "PHI";
			break;
		case 6:
			result = "VOITH HYDRO";
			break;
		case 7:
			result = "VOITH HYDRO";
			break;
		case 8:
			result = "SELINC";
			break;
		case 9:
			result = "TSE";
			break;
		case 10:
			result = "ALTUS";
			break;
		case 11:
			result = "";
			break;
		case 12:
			result = "ENSISTE";
			break;
		case 13:
			result = "MARTE";
			break;
		case 14:
			result = "COPEM";
			break;
		case 15:
			result = "COPEM";
			break;
		case 16:
			result = "IRINEU";
			break;
		case 17:
			result = "MKSE";
			break;
		case 18:
			result = "TSEA";
			break;
		case 19:
			result = "SCHNEIDER";
			break;
		case 20:
			result = "TOWER";
			break;
		case 21:
			result = "GUSTAVO";
			break;
		case 22:
			result = "ROUBADO";
			break;
		case 23:
			result = "COELBA";
			break;
		case 24:
			result = "PETRA";
			break;
		case 25:
			result = "ELTMAN";
			break;
		case 26:
			result = "TRACTEBEL BH";
			break;
		case 27:
			result = "TRACTEBEL RJ";
			break;
		case 28:
			result = "TRACTEBEL DF";
			break;
		case 29:
			result = "INTEREST";
			break;
		case 30:
			result = "INOVA";
			break;
		case 31:
			result = "THEMAG SP";
			break;
		case 32:
			result = "THEMAG DF";
			break;
		case 33:
			result = "CENNATECH";
			break;
		case 34:
			result = "NOVA ENGEVIX";
			break;
		case 35:
			result = "ALTUS2";
			break;
		case 36:
			result = "SIEMENS";
			break;
		case 37:
			result = "TECMON";
			break;
		case 38:
			result = "MULTIEMP.";
			break;
		case 39:
			result = "KRS APICE";
			break;
		case 40:
			result = "PROELT";
			break;
		case 41:
			result = "ENGESERVE";
			break;
		case 42:
			result = "STK";
			break;
		case 43:
			result = "JF VIEIRA";
			break;
		case 44:
			result = "GNETO";
			break;
		case 45:
			result = "EBR BRASIL";
			break;
		case 46:
			result = "VLB ENG";
			break;
		case 47:
			result = "TSEA";
			break;
		case 48:
			result = "GAMA ENGENHARIA";
			break;
		case 49:
			result = "EXAUT";
			break;
		case 50:
			result = "TALENT";
			break;
		case 51:
			result = "QGIT-UPGN";
			break;
		case 52:
			result = "DOUGLAS";
			break;
		case 53:
			result = "JCS ELET";
			break;
		case 54:
			result = "CPE-CE";
			break;
		case 55:
			result = "NARI";
			break;
		case 56:
			result = "ELETRONORTE";
			break;
		case 57:
			result = "SCHNEIDER";
			break;
		case 58:
			result = "PROCESS";
			break;
		case 59:
			result = "PROCESS";
			break;
		case 60:
			result = "ZIV DO BRASIL";
			break;
		case 61:
			result = "JONNY";
			break;
		case 62:
			result = "SELECT";
			break;
		case 63:
			result = "OMEGA";
			break;
		case 64:
			result = "IOSI PROJ";
			break;
		case 65:
			result = "ENERTOP";
			break;
		case 66:
			result = "COPENGE";
			break;
		case 67:
			result = "SETEPLA";
			break;
		case 68:
			result = "SHUNT";
			break;
		case 69:
			result = "PRONEXT";
			break;
		case 70:
			result = "ARTECHE MX";
			break;
		case 71:
			result = "CPFL";
			break;
		case 72:
			result = "GE";
			break;
		case 73:
			result = "SIEMENS DG";
			break;
		case 74:
			result = "HITACHI ENERGY";
			break;
		case 75:
			result = "EPROSUL";
			break;
		case 76:
			result = "ELETROSUL";
			break;
		case 77:
			result = "RAVAGLIO";
			break;
		case 78:
			result = "FLUXO";
			break;
		case 79:
			result = "CARAMURU";
			break;
		case 80:
			result = "CHESF";
			break;
		case 81:
			result = "ENGELIMA";
			break;
		case 82:
			result = "ISABELLE";
			break;
		case 83:
			result = "SHUNT2";
			break;
		case 84:
			result = "BLUEZZ";
			break;
		case 85:
			result = "FERNANDO";
			break;
		case 86:
			result = "FABIO ROSAN";
			break;
		case 87:
			result = "BLUEZZ-2";
			break;
		case 88:
			result = "RICARDO";
			break;
		case 89:
			result = "JPW";
			break;
		case 90:
			result = "ACE ENGENHARIA";
			break;
		case 91:
			result = "ENEL GO";
			break;
		case 92:
			result = "W.BRANDAO";
			break;
		case 93:
			result = "PRONEXT2";
			break;
		case 94:
			result = "IAMACIEL";
			break;
		case 95:
			result = "GIOVANI";
			break;
		case 96:
			result = "ALLPRIME";
			break;
		case 97:
			result = "VISION";
			break;
		case 98:
			result = "COPEL";
			break;
		case 99:
			result = "PRONEXT3";
			break;
		case 100:
			result = "ALISSON";
			break;
		case 101:
			result = "CJM ENG";
			break;
		case 102:
			result = "LEFT ENG";
			break;
		case 103:
			result = "ENGERA";
			break;
		case 104:
			result = "PERRONI";
			break;
		case 105:
			result = "DAROIT";
			break;
		case 106:
			result = "HFT ENERGIA";
			break;
		case 107:
			result = "BTM ELETROMEC";
			break;
		case 108:
			result = "ELEKTRO";
			break;
		case 109:
			result = "ZOPONE";
			break;
		case 110:
			result = "PRONEXT4";
			break;
		}
		return result;
	}

	public static string leCompanyNuvemElecKey(int indice)
	{
		string result = "?";
		switch (indice)
		{
		case 1510:
		case 1511:
		case 1512:
			result = "Energisa Sul Sudeste";
			break;
		case 830:
		case 831:
		case 832:
			result = "Engetécnica";
			break;
		case 490:
		case 491:
		case 492:
			result = "Engevix";
			break;
		case 320:
		case 321:
		case 322:
			result = "Ensiste";
			break;
		case 240:
		case 241:
		case 242:
			result = "Tractebel RJ";
			break;
		case 200:
		case 201:
			result = "Interest";
			break;
		case 50:
		case 51:
		case 52:
			result = "Treinamento Cadgraph";
			break;
		case 100:
		case 101:
		case 102:
			result = "Cadgraph";
			break;
		case 210:
		case 211:
		case 212:
			result = "Marte";
			break;
		case 220:
		case 221:
		case 222:
			result = "Tractebel BH";
			break;
		case 230:
		case 231:
		case 232:
			result = "Tractebel DF";
			break;
		case 250:
		case 251:
		case 252:
			result = "Copenge";
			break;
		case 280:
		case 281:
		case 282:
			result = "Arteche MX";
			break;
		case 260:
		case 261:
		case 262:
			result = "Voith";
			break;
		case 270:
		case 271:
		case 272:
			result = "Arteche";
			break;
		case 290:
		case 291:
		case 292:
			result = "Arteche ES";
			break;
		case 300:
		case 301:
		case 302:
			result = "PHI Engenharia";
			break;
		case 310:
		case 311:
		case 312:
			result = "Selinc";
			break;
		case 330:
		case 331:
		case 332:
			result = "Copem";
			break;
		case 340:
		case 341:
		case 342:
			result = "MKSE";
			break;
		case 410:
		case 411:
		case 412:
			result = "Schneider";
			break;
		case 370:
		case 371:
		case 372:
			result = "Gustavo";
			break;
		case 350:
		case 351:
		case 352:
			result = "TSEA";
			break;
		case 360:
		case 361:
		case 362:
			result = "Tower";
			break;
		case 380:
		case 381:
		case 382:
			result = "Coelba";
			break;
		case 390:
		case 391:
		case 392:
			result = "Petra";
			break;
		case 400:
		case 401:
		case 402:
			result = "Eltman";
			break;
		case 420:
		case 421:
		case 422:
			result = "Themag SP";
			break;
		case 450:
		case 451:
		case 452:
			result = "Inova";
			break;
		case 430:
		case 431:
		case 432:
			result = "Themag DF";
			break;
		case 440:
		case 441:
		case 442:
			result = "Cennatech";
			break;
		case 460:
		case 461:
		case 462:
			result = "Siemens";
			break;
		case 470:
		case 471:
		case 472:
			result = "Siemens DG";
			break;
		case 480:
		case 481:
		case 482:
			result = "Multiempreendimentos";
			break;
		case 500:
		case 501:
		case 502:
			result = "Proelt";
			break;
		case 510:
		case 511:
		case 512:
			result = "Engeserve";
			break;
		case 660:
		case 661:
		case 662:
			result = "Jonny";
			break;
		case 580:
		case 581:
		case 582:
			result = "JCS Elet";
			break;
		case 540:
		case 541:
		case 542:
			result = "EBR";
			break;
		case 520:
		case 521:
		case 522:
			result = "STK";
			break;
		case 530:
		case 531:
		case 532:
			result = "GNeto";
			break;
		case 550:
		case 551:
		case 552:
			result = "Gama Engenharia";
			break;
		case 560:
		case 561:
		case 562:
			result = "Talent";
			break;
		case 570:
		case 571:
		case 572:
			result = "Douglas";
			break;
		case 590:
		case 591:
		case 592:
			result = "CPE-CE";
			break;
		case 620:
		case 621:
		case 622:
			result = "Eletrosul";
			break;
		case 600:
		case 601:
		case 602:
			result = "Nari";
			break;
		case 610:
		case 611:
		case 612:
			result = "Eletronorte";
			break;
		case 630:
		case 631:
		case 632:
			result = "Chesf";
			break;
		case 640:
		case 641:
		case 642:
			result = "Process";
			break;
		case 650:
		case 651:
		case 652:
			result = "ZIV";
			break;
		case 670:
		case 671:
		case 672:
			result = "Omega Abengoa";
			break;
		case 680:
		case 681:
		case 682:
			result = "Iosi";
			break;
		case 750:
		case 751:
		case 752:
			result = "GE";
			break;
		case 710:
		case 711:
		case 712:
			result = "Setepla";
			break;
		case 690:
		case 691:
		case 692:
			result = "Enertop";
			break;
		case 700:
		case 701:
		case 702:
			result = "Copenge";
			break;
		case 720:
		case 721:
		case 722:
			result = "Shunt";
			break;
		case 730:
		case 731:
		case 732:
			result = "Pronext";
			break;
		case 740:
		case 741:
		case 742:
			result = "CPFL";
			break;
		case 760:
		case 761:
		case 762:
			result = "Hitachi Energy";
			break;
		case 790:
		case 791:
		case 792:
			result = "Fluxo";
			break;
		case 770:
		case 771:
		case 772:
			result = "Eprosul";
			break;
		case 780:
		case 781:
		case 782:
			result = "Ravaglio";
			break;
		case 800:
		case 801:
		case 802:
			result = "Caramuru";
			break;
		case 810:
		case 811:
		case 812:
			result = "Tecmon";
			break;
		case 820:
		case 821:
		case 822:
			result = "JPW";
			break;
		case 840:
		case 841:
		case 842:
			result = "Bluezz";
			break;
		case 850:
		case 851:
		case 852:
			result = "Engepro";
			break;
		case 1170:
		case 1171:
		case 1172:
			result = "AllPrime";
			break;
		case 1000:
		case 1001:
		case 1002:
			result = "EDP ES";
			break;
		case 920:
		case 921:
		case 922:
			result = "Engelima";
			break;
		case 880:
		case 881:
		case 882:
			result = "Lucy Electric";
			break;
		case 860:
		case 861:
		case 862:
			result = "Energisa";
			break;
		case 870:
		case 871:
		case 872:
			result = "Automa Power";
			break;
		case 890:
		case 891:
		case 892:
			result = "Enel GO";
			break;
		case 900:
		case 901:
		case 902:
			result = "DMA Sistemas";
			break;
		case 910:
		case 911:
		case 912:
			result = "Siproenge";
			break;
		case 930:
		case 931:
		case 932:
			result = "Ghenova";
			break;
		case 960:
		case 961:
		case 962:
			result = "Enel Coelce";
			break;
		case 940:
		case 941:
		case 942:
			result = "ISA CTEEP";
			break;
		case 950:
		case 951:
		case 952:
			result = "Sec Painéis";
			break;
		case 970:
		case 971:
		case 972:
			result = "EG Engenharia";
			break;
		case 980:
		case 981:
		case 982:
			result = "Cápua Engenharia";
			break;
		case 990:
		case 991:
		case 992:
			result = "Nova Engevix";
			break;
		case 1010:
		case 1011:
		case 1012:
			result = "Vision";
			break;
		case 1020:
		case 1021:
		case 1022:
			result = "ESC Engenharia";
			break;
		case 1090:
		case 1091:
		case 1092:
			result = "CJM ENG";
			break;
		case 1050:
		case 1051:
		case 1052:
			result = "Sistem Engenharia";
			break;
		case 1030:
		case 1031:
		case 1032:
			result = "AProt";
			break;
		case 1040:
		case 1041:
		case 1042:
			result = "Smart Electric";
			break;
		case 1060:
		case 1061:
		case 1062:
			result = "Select Engenharia";
			break;
		case 1070:
		case 1071:
		case 1072:
			result = "Alta Engenharia";
			break;
		case 1080:
		case 1081:
		case 1082:
			result = "Taves";
			break;
		case 1100:
		case 1101:
		case 1102:
			result = "IAMaciel";
			break;
		case 1130:
		case 1131:
		case 1132:
			result = "Nery";
			break;
		case 1110:
		case 1111:
		case 1112:
			result = "PlusVolt";
			break;
		case 1120:
		case 1121:
		case 1122:
			result = "Copel";
			break;
		case 1140:
		case 1141:
		case 1142:
			result = "Copenge2";
			break;
		case 1150:
		case 1151:
		case 1152:
			result = "Metrum";
			break;
		case 1160:
		case 1161:
		case 1162:
			result = "Alisson";
			break;
		case 1180:
		case 1181:
		case 1182:
			result = "Acrux";
			break;
		case 1190:
		case 1191:
		case 1192:
			result = "AMTK";
			break;
		case 1340:
		case 1341:
		case 1342:
			result = "PWM";
			break;
		case 1260:
		case 1261:
		case 1262:
			result = "HFT Energia";
			break;
		case 1220:
		case 1221:
		case 1222:
			result = "Perroni Engenharia";
			break;
		case 1200:
		case 1201:
		case 1202:
			result = "Left Engenharia";
			break;
		case 1210:
		case 1211:
		case 1212:
			result = "Engera";
			break;
		case 1230:
		case 1231:
		case 1232:
			result = "SRA Equip. Sist.";
			break;
		case 1240:
		case 1241:
		case 1242:
			result = "LT Energia";
			break;
		case 1250:
		case 1251:
		case 1252:
			result = "SNEF Brasil";
			break;
		case 1270:
		case 1271:
		case 1272:
			result = "OHM Engenharia";
			break;
		case 1300:
		case 1301:
		case 1302:
			result = "Cymi";
			break;
		case 1280:
		case 1281:
		case 1282:
			result = "Furnas";
			break;
		case 1290:
		case 1291:
		case 1292:
			result = "Zopone";
			break;
		case 1310:
		case 1311:
		case 1312:
			result = "BTM Eletromec";
			break;
		case 1320:
		case 1321:
		case 1322:
			result = "Roraima Energia";
			break;
		case 1330:
		case 1331:
		case 1332:
			result = "AMC";
			break;
		case 1350:
		case 1351:
		case 1352:
			result = "ACE Engenharia";
			break;
		case 1360:
		case 1361:
		case 1362:
			result = "PROJEM";
			break;
		case 1430:
		case 1431:
		case 1432:
			result = "CPFL-T";
			break;
		case 1390:
		case 1391:
		case 1392:
			result = "Progressul";
			break;
		case 1370:
		case 1371:
		case 1372:
			result = "Elecnor";
			break;
		case 1380:
		case 1381:
		case 1382:
			result = "Neoenergia";
			break;
		case 1400:
		case 1401:
		case 1402:
			result = "Siemens Energy Power";
			break;
		case 1410:
		case 1411:
		case 1412:
			result = "MPE Engenharia";
			break;
		case 1420:
		case 1421:
		case 1422:
			result = "Efeitto";
			break;
		case 1440:
		case 1441:
		case 1442:
			result = "Cymi Tech";
			break;
		case 1470:
		case 1471:
		case 1472:
			result = "About Brasil";
			break;
		case 1450:
		case 1451:
		case 1452:
			result = "Projexa";
			break;
		case 1460:
		case 1461:
		case 1462:
			result = "Ilo";
			break;
		case 1480:
		case 1481:
		case 1482:
			result = "Mesh Engenharia";
			break;
		case 1490:
		case 1491:
		case 1492:
			result = "Jefferson Mirasol";
			break;
		case 1500:
		case 1501:
		case 1502:
			result = "Tecnova";
			break;
		case 1520:
		case 1521:
		case 1522:
			result = "Enel SP";
			break;
		case 1530:
		case 1531:
		case 1532:
			result = "Ecotechne";
			break;
		}
		return result;
	}

	public static void travaDWG(bool bTravar)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				LayerTable val3 = (LayerTable)val2.GetObject(database.LayerTableId, (OpenMode)1);
				SymbolTableEnumerator enumerator = default;
				try
				{
					enumerator = val3.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						LayerTableRecord val4 = (LayerTableRecord)val2.GetObject(current, (OpenMode)1);
						val4.IsLocked = bTravar;
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				string pagina = Pagina.LocalizaPaginaAtiva();
				Pagina.AtivaPagina(pagina);
				Application.DocumentManager.MdiActiveDocument.Editor.Regen();
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

	public static void CriaTextStyle(string nome, string fonte)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected Obj, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected Obj, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		try
		{
			Transaction val = database.TransactionManager.StartTransaction();
			try
			{
				_ = mdiActiveDocument.Editor;
				try
				{
					TextStyleTable val2 = (TextStyleTable)val.GetObject(database.TextStyleTableId, (OpenMode)1, false);
					try
					{
						if (!((SymbolTable)val2).Has(nome))
						{
							TextStyleTableRecord val3 = new TextStyleTableRecord();
							((SymbolTableRecord)val3).Name = nome;
							((SymbolTable)val2).Add((SymbolTableRecord)(object)val3);
							val3.FileName = fonte;
							DeclaracoesGeral.bAnularEventos = true;
							val.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
						}
					}
					finally
					{
						((IDisposable)val2)?.Dispose();
					}
					DeclaracoesGeral.bAnularEventos = true;
					val.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)database)?.Dispose();
		}
	}

	public static void IniciaStringCollectionAtt()
	{
		DeclaracoesGeral.attProtCollection.Add("TITULO1PAG");
		DeclaracoesGeral.attProtCollection.Add("TITULO2PAG");
		DeclaracoesGeral.attProtCollection.Add("TITULO3PAG");
		DeclaracoesGeral.attProtCollection.Add("TITULO4PAG");
		DeclaracoesGeral.attProtCollection.Add("PAINEL");
		DeclaracoesGeral.attProtCollection.Add("SECAO");
		DeclaracoesGeral.attProtCollection.Add("FL");
		DeclaracoesGeral.attProtCollection.Add("CONT");
		DeclaracoesGeral.attProtCollection.Add("REV");
		DeclaracoesGeral.attProtCollection.Add("TOT");
		DeclaracoesGeral.attProtCollection.Add("ALTERNATIVO");
		DeclaracoesGeral.attProtCollection.Add("REV0");
		DeclaracoesGeral.attProtCollection.Add("REV1");
		DeclaracoesGeral.attProtCollection.Add("REV2");
		DeclaracoesGeral.attProtCollection.Add("REV3");
		DeclaracoesGeral.attProtCollection.Add("REV4");
		DeclaracoesGeral.attProtCollection.Add("REV5");
		DeclaracoesGeral.attProtCollection.Add("REV6");
		DeclaracoesGeral.attProtCollection.Add("REV7");
		DeclaracoesGeral.attProtCollection.Add("DESC0");
		DeclaracoesGeral.attProtCollection.Add("DESC1");
		DeclaracoesGeral.attProtCollection.Add("DESC2");
		DeclaracoesGeral.attProtCollection.Add("DESC3");
		DeclaracoesGeral.attProtCollection.Add("DESC4");
		DeclaracoesGeral.attProtCollection.Add("DESC5");
		DeclaracoesGeral.attProtCollection.Add("DESC6");
		DeclaracoesGeral.attProtCollection.Add("DESC7");
		DeclaracoesGeral.attProtCollection.Add("DATA0");
		DeclaracoesGeral.attProtCollection.Add("DATA1");
		DeclaracoesGeral.attProtCollection.Add("DATA2");
		DeclaracoesGeral.attProtCollection.Add("DATA3");
		DeclaracoesGeral.attProtCollection.Add("DATA4");
		DeclaracoesGeral.attProtCollection.Add("DATA5");
		DeclaracoesGeral.attProtCollection.Add("DATA6");
		DeclaracoesGeral.attProtCollection.Add("DATA7");
		DeclaracoesGeral.attProtCollection.Add("ELAB0");
		DeclaracoesGeral.attProtCollection.Add("ELAB1");
		DeclaracoesGeral.attProtCollection.Add("ELAB2");
		DeclaracoesGeral.attProtCollection.Add("ELAB3");
		DeclaracoesGeral.attProtCollection.Add("ELAB4");
		DeclaracoesGeral.attProtCollection.Add("ELAB5");
		DeclaracoesGeral.attProtCollection.Add("ELAB6");
		DeclaracoesGeral.attProtCollection.Add("ELAB7");
		DeclaracoesGeral.attProtCollection.Add("VERIF0");
		DeclaracoesGeral.attProtCollection.Add("VERIF1");
		DeclaracoesGeral.attProtCollection.Add("VERIF2");
		DeclaracoesGeral.attProtCollection.Add("VERIF3");
		DeclaracoesGeral.attProtCollection.Add("VERIF4");
		DeclaracoesGeral.attProtCollection.Add("VERIF5");
		DeclaracoesGeral.attProtCollection.Add("VERIF6");
		DeclaracoesGeral.attProtCollection.Add("VERIF7");
		DeclaracoesGeral.attProtCollection.Add("APROV0");
		DeclaracoesGeral.attProtCollection.Add("APROV1");
		DeclaracoesGeral.attProtCollection.Add("APROV2");
		DeclaracoesGeral.attProtCollection.Add("APROV3");
		DeclaracoesGeral.attProtCollection.Add("APROV4");
		DeclaracoesGeral.attProtCollection.Add("APROV5");
		DeclaracoesGeral.attProtCollection.Add("APROV6");
		DeclaracoesGeral.attProtCollection.Add("APROV7");
		DeclaracoesGeral.attRevProtCollection.Add("REV0");
		DeclaracoesGeral.attRevProtCollection.Add("REV1");
		DeclaracoesGeral.attRevProtCollection.Add("REV2");
		DeclaracoesGeral.attRevProtCollection.Add("REV3");
		DeclaracoesGeral.attRevProtCollection.Add("REV4");
		DeclaracoesGeral.attRevProtCollection.Add("REV5");
		DeclaracoesGeral.attRevProtCollection.Add("REV6");
		DeclaracoesGeral.attRevProtCollection.Add("REV7");
		DeclaracoesGeral.attRevProtCollection.Add("DESC0");
		DeclaracoesGeral.attRevProtCollection.Add("DESC1");
		DeclaracoesGeral.attRevProtCollection.Add("DESC2");
		DeclaracoesGeral.attRevProtCollection.Add("DESC3");
		DeclaracoesGeral.attRevProtCollection.Add("DESC4");
		DeclaracoesGeral.attRevProtCollection.Add("DESC5");
		DeclaracoesGeral.attRevProtCollection.Add("DESC6");
		DeclaracoesGeral.attRevProtCollection.Add("DESC7");
		DeclaracoesGeral.attRevProtCollection.Add("DATA0");
		DeclaracoesGeral.attRevProtCollection.Add("DATA1");
		DeclaracoesGeral.attRevProtCollection.Add("DATA2");
		DeclaracoesGeral.attRevProtCollection.Add("DATA3");
		DeclaracoesGeral.attRevProtCollection.Add("DATA4");
		DeclaracoesGeral.attRevProtCollection.Add("DATA5");
		DeclaracoesGeral.attRevProtCollection.Add("DATA6");
		DeclaracoesGeral.attRevProtCollection.Add("DATA7");
		DeclaracoesGeral.attRevProtCollection.Add("ELAB0");
		DeclaracoesGeral.attRevProtCollection.Add("ELAB1");
		DeclaracoesGeral.attRevProtCollection.Add("ELAB2");
		DeclaracoesGeral.attRevProtCollection.Add("ELAB3");
		DeclaracoesGeral.attRevProtCollection.Add("ELAB4");
		DeclaracoesGeral.attRevProtCollection.Add("ELAB5");
		DeclaracoesGeral.attRevProtCollection.Add("ELAB6");
		DeclaracoesGeral.attRevProtCollection.Add("ELAB7");
		DeclaracoesGeral.attRevProtCollection.Add("VERIF0");
		DeclaracoesGeral.attRevProtCollection.Add("VERIF1");
		DeclaracoesGeral.attRevProtCollection.Add("VERIF2");
		DeclaracoesGeral.attRevProtCollection.Add("VERIF3");
		DeclaracoesGeral.attRevProtCollection.Add("VERIF4");
		DeclaracoesGeral.attRevProtCollection.Add("VERIF5");
		DeclaracoesGeral.attRevProtCollection.Add("VERIF6");
		DeclaracoesGeral.attRevProtCollection.Add("VERIF7");
		DeclaracoesGeral.attRevProtCollection.Add("APROV0");
		DeclaracoesGeral.attRevProtCollection.Add("APROV1");
		DeclaracoesGeral.attRevProtCollection.Add("APROV2");
		DeclaracoesGeral.attRevProtCollection.Add("APROV3");
		DeclaracoesGeral.attRevProtCollection.Add("APROV4");
		DeclaracoesGeral.attRevProtCollection.Add("APROV5");
		DeclaracoesGeral.attRevProtCollection.Add("APROV6");
		DeclaracoesGeral.attRevProtCollection.Add("APROV7");
	}

	public static void IniciaStringCollectionBitolas()
	{
		DeclaracoesGeral.BitolaCollection.Add("0,5");
		DeclaracoesGeral.BitolaCollection.Add("0,75");
		DeclaracoesGeral.BitolaCollection.Add("1,0");
		DeclaracoesGeral.BitolaCollection.Add("1,5");
		DeclaracoesGeral.BitolaCollection.Add("2,5");
		DeclaracoesGeral.BitolaCollection.Add("4,0");
		DeclaracoesGeral.BitolaCollection.Add("6,0");
		DeclaracoesGeral.BitolaCollection.Add("8,0");
		DeclaracoesGeral.BitolaCollection.Add("10,0");
		DeclaracoesGeral.BitolaCollection.Add("10 AWG");
		DeclaracoesGeral.BitolaCollection.Add("12 AWG");
		DeclaracoesGeral.BitolaCollection.Add("14 AWG");
		DeclaracoesGeral.BitolaCollection.Add("16 AWG");
		DeclaracoesGeral.BitolaCollection.Add("18 AWG");
		DeclaracoesGeral.BitolaCollection.Add("22 AWG");
	}

	public static object HandleToObject(string sHandle)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		object result = null;
		if (Operators.CompareString(clsTextos.TiraNothing(sHandle), "", TextCompare: true) != 0)
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction topTransaction = database.TransactionManager.TopTransaction;
			try
			{
				long num = Convert.ToInt64(sHandle, 16);
				Handle val = new Handle(num);
				ObjectId objectId = database.GetObjectId(false, val, 0);
				if (objectId.IsValid & !objectId.IsErased)
				{
					DBObject val2 = topTransaction.GetObject(objectId, (OpenMode)0);
					result = val2;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)topTransaction)?.Dispose();
			}
		}
		return result;
	}

	public static ObjectId HandleToID(string sHandle)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		ObjectId result = ObjectId.Null;
		if (Operators.CompareString(clsTextos.TiraNothing(sHandle), "", TextCompare: true) != 0)
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			try
			{
				long num = Convert.ToInt64(sHandle, 16);
				Handle val = new Handle(num);
				ObjectId objectId = database.GetObjectId(false, val, 0);
				if (objectId.IsValid & !objectId.IsErased)
				{
					result = objectId;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	public static bool ExisteForm(string nome)
	{
		bool result = false;
		int count = Application.OpenForms.Count;
		checked
		{
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				Form form = Application.OpenForms[i];
				if (Operators.CompareString(form.Name, nome, TextCompare: true) == 0)
				{
					result = true;
					form.WindowState = FormWindowState.Normal;
					Correcao.corrigeJanelas();
					break;
				}
			}
			return result;
		}
	}

	public static bool FechaForm(string nome)
	{
		bool result = false;
		int count = Application.OpenForms.Count;
		checked
		{
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				Form form = Application.OpenForms[i];
				if (Operators.CompareString(form.Name, nome, TextCompare: true) == 0)
				{
					form.Close();
					break;
				}
			}
			return result;
		}
	}

	public static void moveFormOrigem()
	{
		int count = Application.OpenForms.Count;
		checked
		{
			int num = count - 1;
			for (int i = 0; i <= num; i++)
			{
				Form form = Application.OpenForms[i];
				form.WindowState = FormWindowState.Normal;
				form.StartPosition = FormStartPosition.CenterParent;
				form.Left = 0;
				form.Top = 0;
				form.Opacity = 1.0;
				form.Visible = true;
				form.Refresh();
			}
		}
	}

	public static void DivideTerminais(ref List<string> lTerminais, string sTexto, bool bRepete = false)
	{
		if (Operators.CompareString(sTexto, null, TextCompare: true) == 0)
		{
			sTexto = " ";
		}
		checked
		{
			if (Operators.CompareString(Strings.Mid(sTexto, sTexto.Length, sTexto.Length), ";", TextCompare: true) == 0)
			{
				sTexto = Strings.Mid(sTexto, 1, sTexto.Length - 1);
			}
			string[] array = sTexto.Split(';');
			int num = Information.UBound(array);
			for (int i = 0; i <= num; i++)
			{
				if (Operators.CompareString(array[i].Trim(), "", TextCompare: true) == 0)
				{
					array[i] = " ";
				}
				if (!((Operators.CompareString(array[i], " ", TextCompare: true) == 0) | (Operators.CompareString(array[i].Trim(), DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) == 0)))
				{
					if (!bRepete)
					{
						if (!lTerminais.Contains(array[i].Trim()))
						{
							lTerminais.Add(array[i].Trim());
						}
					}
					else
					{
						lTerminais.Add(array[i].Trim());
					}
				}
				else
				{
					lTerminais.Add(array[i].Trim());
				}
			}
		}
	}

	public static void DivideOrientacoes(ref List<string> lOrientacoes, string sTexto)
	{
		if (Operators.CompareString(sTexto, null, TextCompare: true) == 0)
		{
			sTexto = " ";
		}
		checked
		{
			if (Operators.CompareString(Strings.Mid(sTexto, sTexto.Length, sTexto.Length), ";", TextCompare: true) == 0)
			{
				sTexto = Strings.Mid(sTexto, 1, sTexto.Length - 1);
			}
			string[] array = sTexto.Split(';');
			int num = Information.UBound(array);
			for (int i = 0; i <= num; i++)
			{
				lOrientacoes.Add(array[i].Trim());
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoOptimization)]
	public static bool IsFileInUse(string sFile)
	{
		bool result = false;
		if (File.Exists(sFile))
		{
			try
			{
				short num = checked((short)FileSystem.FreeFile());
				FileSystem.FileOpen(num, sFile, OpenMode.Binary, OpenAccess.ReadWrite, OpenShare.LockReadWrite);
				FileSystem.FileClose(num);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				result = true;
				ProjectData.ClearProjectError();
			}
		}
		return result;
	}

	public static string CADVersion()
	{
		string result = "";
		string text = "";
		Version version = Application.Version;
		if (!((object)Application.StatusBar).ToString().ToUpper().Contains("ZWCAD"))
		{
			if (!((object)Application.StatusBar).ToString().ToUpper().Contains("AUTOCAD"))
			{
				if (((object)Application.StatusBar).ToString().ToUpper().Contains("BRICSCAD"))
				{
					text = "B_";
				}
			}
			else
			{
				text = "A_";
			}
		}
		else
		{
			text = "Z_";
		}
		string left = text;
		if (Operators.CompareString(left, "A_", TextCompare: true) != 0)
		{
			if (Operators.CompareString(left, "Z_", TextCompare: true) != 0)
			{
				if (Operators.CompareString(left, "B_", TextCompare: true) == 0)
				{
					result = text + version.Major + "." + version.Minor + "." + version.Build;
				}
			}
			else
			{
				string text2 = Conversions.ToString(version.Major) + "." + Conversions.ToString(version.Minor);
				string left2 = text2;
				if (Operators.CompareString(left2, "26.0", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left2, "25.0", TextCompare: true) == 0)
					{
						result = text + "2025";
					}
				}
				else
				{
					result = text + "2026";
				}
			}
		}
		else
		{
			string text3 = Conversions.ToString(version.Major) + "." + Conversions.ToString(version.Minor);
			string left3 = text3;
			if (Operators.CompareString(left3, "25.1", TextCompare: true) != 0)
			{
				if (Operators.CompareString(left3, "25.0", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left3, "24.3", TextCompare: true) != 0)
					{
						if (Operators.CompareString(left3, "24.2", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left3, "24.1", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left3, "24.0", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left3, "23.1", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left3, "23.0", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left3, "22.0", TextCompare: true) != 0)
											{
												if (Operators.CompareString(left3, "21.0", TextCompare: true) != 0)
												{
													if (Operators.CompareString(left3, "20.1", TextCompare: true) != 0)
													{
														if (Operators.CompareString(left3, "20.0", TextCompare: true) != 0)
														{
															if (Operators.CompareString(left3, "19.1", TextCompare: true) != 0)
															{
																if (Operators.CompareString(left3, "19.0", TextCompare: true) != 0)
																{
																	if (Operators.CompareString(left3, "18.2", TextCompare: true) != 0)
																	{
																		if (Operators.CompareString(left3, "18.1", TextCompare: true) != 0)
																		{
																			result = ((Operators.CompareString(left3, "18.0", TextCompare: true) == 0) ? (text + "2010") : "?");
																		}
																		else
																		{
																			result = text + "2011";
																		}
																	}
																	else
																	{
																		result = text + "2012";
																	}
																}
																else
																{
																	result = text + "2013";
																}
															}
															else
															{
																result = text + "2014";
															}
														}
														else
														{
															result = text + "2015";
														}
													}
													else
													{
														result = text + "2016";
													}
												}
												else
												{
													result = text + "2017";
												}
											}
											else
											{
												result = text + "2018";
											}
										}
										else
										{
											result = text + "2019";
										}
									}
									else
									{
										result = text + "2020";
									}
								}
								else
								{
									result = text + "2021";
								}
							}
							else
							{
								result = text + "2022";
							}
						}
						else
						{
							result = text + "2023";
						}
					}
					else
					{
						result = text + "2024";
					}
				}
				else
				{
					result = text + "2025";
				}
			}
			else
			{
				result = text + "2026";
			}
		}
		return result;
	}

	public static string MostrarVersaoDWGMaisRecente()
	{
		string text = "";
		string text2 = CADVersion();
		text = ((Operators.CompareString(text2.Substring(0, 1).ToUpper(), "Z", TextCompare: true) == 0) ? Conversions.ToString(Application.GetSystemVariable("VERNUM")) : Conversions.ToString(Application.GetSystemVariable("ACADVER")));
		return eiopnl1rbV9(text);
	}

	private static string eiopnl1rbV9(string P_0)
	{
		switch (Conversions.ToInteger(P_0.Substring(0, 2)))
		{
		case 24:
		case 25:
		case 26:
			return "AC1032";
		default:
			return "AC1032";
		case 23:
			return "AC1027";
		case 22:
			return "AC1024";
		}
	}
}
