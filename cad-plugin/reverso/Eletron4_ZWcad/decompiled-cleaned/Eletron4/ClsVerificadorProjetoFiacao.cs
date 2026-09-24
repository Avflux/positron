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
using ZwSoft.ZwCAD.Geometry;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

public class ClsVerificadorProjetoFiacao
{
	public struct _structurePn
	{
		public int iPN;

		public string sPN;
	}

	public struct StrucTerminais
	{
		public string T;

		public string V;
	}

	public struct _structureModRegua
	{
		public int iPainel;

		public string sPainel;

		public int iRegua;

		public string sNomeRegua;

		public DeclaracoesEntidades.StructureBorne[] mBorne;
	}

	public struct _structuremRegua
	{
		public int iPainel;

		public string sPainel;

		public int iRegua;

		public string sNomeRegua;
	}

	public struct _StructureAnalisePorta
	{
		public int indexMascara;

		public int indexPorta;

		public string sNomeMascara;

		public string sEFC;

		public string sRegua;

		public string sattT;

		public string sattB;

		public string sTerm;

		public string sTermM;

		public string sBorn;

		public string sBornM;

		public List<string> lT;

		public List<string> lB;

		public string sHandle;

		public string sPagina;

		public bool bPnApagados;

		public int iPn;
	}

	public struct _StructureConexao
	{
		public int iPotencial_Veia;

		public int indexCor;

		public int iPesoLinha;

		public string sSecao;

		public string Cor_Nome;

		public string Handle;

		public string HandleSup;

		public int iTipo;

		public string sPaginaa;

		public string sPainel;

		public int iPainel;

		public double x;

		public double y;

		public bool bPnApagado;

		public Point3d ptIni;

		public Point3d ptFim;
	}

	public struct _StructuremDispositivo
	{
		public string Handle;

		public string Nome1;

		public string Nome2;

		public string Alternativo;

		public string sTerminais;

		public short Painel;

		public string ChavePrimaria;

		public int indexModelo;

		public string Modelo;

		public bool Complementar;

		public double posX;

		public double posY;

		public int iLM1;

		public int iLM2;

		public short tipoContatoAux;

		public double distContAux;

		public bool NomeVisivel;

		public bool AlternativoVisivel;

		public string Topografico;

		public string Layout;

		public string Usuario;

		public string Data;

		public bool bPnApagados;

		public int iPn;
	}

	public struct _StructuremAuxiliar
	{
		public string Nome1;

		public string Nome2;

		public string Alternativo;

		public string sTerminais;

		public string sTerminaisMod;

		public string HandleBob;

		public string Handle;

		public int IndexModelo;

		public int IndexContato;

		public short TipoDoContato;

		public short TipoDoComportamento;

		public string TipoBlocoUsado;

		public string TerminaisBlocoUsado;

		public string Usuario;

		public string Data;

		public bool bPnApagados;

		public int iPn;
	}

	public struct _errosPorta
	{
		public string sMasc;

		public int iIndiceMascara;

		public int iIndicePorta;

		public string sNome;

		public string sEfc;

		public string sRegua;

		public string sTerBorne;

		public string sDuplicado;

		public string sIndefinido;

		public string sHandle;
	}

	public struct _StructurERROBorne
	{
		public int iPn;

		public string sPn;

		public string sRegua;

		public string sErro;

		public string sHandle;
	}

	public struct _StructurefiacaoErro
	{
		public string sCorFiacao;

		public string sPainel;

		public string sValor;

		public string iPotencial;

		public string sCabo;

		public string sPagina;

		public double x;

		public double y;
	}

	public struct HandlePorta
	{
		public string sHandle;

		public string sPagina;
	}

	public static void buscaPaineisDoDG(ref List<string> lPn, ref List<string> lPnAoagado)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected Obj, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected Obj, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected Obj, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected Obj, but got Unknown
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Expected Obj, but got Unknown
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Expected Obj, but got Unknown
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected Obj, but got Unknown
		lPn.Clear();
		List<int> list = new List<int>();
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
						Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
						Polyline pl = (Polyline)(object)((ent is Polyline) ? ent : null);
						DeclaracoesEntidades.StructureConexao conex = default;
						if (pl == null)
						{
							BlockReference blockRef = (BlockReference)(object)((ent is BlockReference) ? ent : null);
							if (blockRef == null)
							{
								continue;
							}
							string tipoImportado = "";
							string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							string left = text;
							BlockReference blockRef2;
							object obj2;
							if (Operators.CompareString(left, "B", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "E", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left, "P", TextCompare: true) != 0)
									{
										continue;
									}
									object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj));
									if (!lPn.Contains(Conversions.ToString((int)structureDispositivo.Painel)))
									{
										lPn.Add(Conversions.ToString((int)structureDispositivo.Painel));
										if (Operators.CompareString(Dicionario.BuscaNomeDoPainel(structureDispositivo.Painel), "???", TextCompare: true) == 0)
										{
											lPnAoagado.Add(Conversions.ToString((int)structureDispositivo.Painel));
										}
									}
									continue;
								}
								blockRef2 = (BlockReference)ent;
								obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
								ent = (Entity)(object)blockRef2;
								object obj3 = obj2;
								DeclaracoesEntidades.StructurePortas structurePortas = ((obj3 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj3));
								DeclaracoesEntidades.StructureMascara structureMascara = default;
								Entity val5 = (Entity)Geral.HandleToObject(structurePortas.HandleDaMascara);
								if (val5 == null)
								{
									continue;
								}
								blockRef2 = (BlockReference)val5;
								obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
								val5 = (Entity)(object)blockRef2;
								object obj4 = obj2;
								structureMascara = ((obj4 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj4));
								if (!lPn.Contains(Conversions.ToString((int)structureMascara.Painel)))
								{
									lPn.Add(Conversions.ToString((int)structureMascara.Painel));
									if (Operators.CompareString(Dicionario.BuscaNomeDoPainel(structureMascara.Painel), "???", TextCompare: true) == 0)
									{
										lPnAoagado.Add(Conversions.ToString((int)structureMascara.Painel));
									}
								}
								continue;
							}
							DeclaracoesEntidades.StructureBorne structureBorne = default;
							blockRef2 = (BlockReference)ent;
							obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
							ent = (Entity)(object)blockRef2;
							object obj5 = obj2;
							structureBorne = ((obj5 == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj5));
							if (list.Contains(structureBorne.IndiceRegua))
							{
								continue;
							}
							short num = 0;
							num = checked((short)DicionarioBorne.BuscaPainelDoBorneNoDicionario(ref structureBorne.IndiceRegua, ref structureBorne.NomeRegua, ref structureBorne.Alternativo));
							if (!lPn.Contains(Conversions.ToString((int)num)))
							{
								lPn.Add(Conversions.ToString((int)num));
								if (Operators.CompareString(Dicionario.BuscaNomeDoPainel(num), "???", TextCompare: true) == 0)
								{
									lPnAoagado.Add(Conversions.ToString((int)num));
								}
							}
						}
						else if (XDataConexao.lerXDataConexao(ref pl, ref conex) && !lPn.Contains(Conversions.ToString((int)conex.Painel)))
						{
							lPn.Add(Conversions.ToString((int)conex.Painel));
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

	public static void buscaDadosDeFiacaoDWG(ref _StructureConexao[] m_Fiacao, ref DeclaracoesEntidades.StructureBorne[] m_TodosBornes, ref _StructureAnalisePorta[] m_TodasPortas, ref _StructuremDispositivo[] m_Disp, ref _StructuremAuxiliar[] m_Aux, ref List<string> lPn, ref List<string> lPnApagados, ref List<string> LFiacaoTTDuplicada, string sTipoRelat)
	{
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected Obj, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected Obj, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected Obj, but got Unknown
		//IL_06e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e7: Expected Obj, but got Unknown
		//IL_04d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dc: Expected I4, but got Unknown
		//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_057f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0584: Unknown result type (might be due to invalid IL or missing references)
		//IL_059c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a07: Expected Obj, but got Unknown
		//IL_0a37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3e: Expected Obj, but got Unknown
		//IL_047c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0481: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a51: Expected Obj, but got Unknown
		//IL_0669: Unknown result type (might be due to invalid IL or missing references)
		//IL_066e: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f19: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected Obj, but got Unknown
		//IL_0853: Unknown result type (might be due to invalid IL or missing references)
		//IL_0858: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected Obj, but got Unknown
		//IL_09b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09da: Unknown result type (might be due to invalid IL or missing references)
		//IL_09df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d49: Unknown result type (might be due to invalid IL or missing references)
		//IL_1590: Unknown result type (might be due to invalid IL or missing references)
		//IL_159e: Unknown result type (might be due to invalid IL or missing references)
		//IL_15b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_15bf: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		m_Fiacao = new _StructureConexao[1];
		int num2 = 0;
		m_TodasPortas = new _StructureAnalisePorta[1];
		int num3 = 0;
		m_Disp = new _StructuremDispositivo[1];
		int num4 = 0;
		m_Aux = new _StructuremAuxiliar[1];
		List<string> list = new List<string>();
		int num5 = -1;
		Declaracoes2.MModeloDePortas[] mPortas = null;
		string sNomeModelo = " ";
		List<int> list2 = new List<int>();
		DeclaracoesGeral.Reguas RH = default;
		bool flag = false;
		flag = XDataGeral.LeXDataReguaH(ref RH);
		DeclaracoesGeral.Reguas RH2 = default;
		bool flag2 = false;
		flag2 = XDataGeral.LeXDataReguaV(ref RH2);
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
						Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
						Polyline pl = (Polyline)(object)((ent is Polyline) ? ent : null);
						DeclaracoesEntidades.StructureConexao conex = default;
						Point3d val9;
						if (pl == null)
						{
							BlockReference blockRef = (BlockReference)(object)((ent is BlockReference) ? ent : null);
							if (blockRef == null)
							{
								continue;
							}
							string tipoImportado = "";
							string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							string left = text;
							BlockReference blockRef2;
							object obj2;
							if (Operators.CompareString(left, "B", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "E", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left, "P", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left, "A", TextCompare: true) != 0)
										{
											continue;
										}
										object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
										DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = ((obj == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj));
										Entity val5 = (Entity)Geral.HandleToObject(structureAuxiliar.HandleBob);
										if (val5 == null)
										{
											continue;
										}
										blockRef2 = (BlockReference)val5;
										obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
										val5 = (Entity)(object)blockRef2;
										object obj3 = obj2;
										DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj3 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj3));
										if (lPn.Contains(Conversions.ToString((int)structureDispositivo.Painel)))
										{
											checked
											{
												num4++;
												m_Aux = (_StructuremAuxiliar[])Utils.CopyArray(m_Aux, new _StructuremAuxiliar[num4 + 1]);
												m_Aux[num4].Nome1 = structureAuxiliar.Nome1;
												m_Aux[num4].Nome2 = structureAuxiliar.Nome2;
												m_Aux[num4].Alternativo = structureAuxiliar.Alternativo;
												m_Aux[num4].IndexModelo = structureAuxiliar.IndexModelo;
												m_Aux[num4].IndexContato = structureAuxiliar.IndexContato;
												m_Aux[num4].TipoDoContato = structureAuxiliar.TipoDoContato;
												m_Aux[num4].HandleBob = structureAuxiliar.HandleBob;
												ref string sTerminais = ref m_Aux[num4].sTerminais;
												string sB = "";
												tipoImportado = "";
												LeOsTerminais(ref ent, ref sTerminais, ref sB, ref tipoImportado);
												BlockReference val6 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
												m_Aux[num4].TipoBlocoUsado = Strings.Mid(val6.Name, 5, 2);
												if (clsBlocos.ExisteAtributo(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString(), "T1"))
												{
													m_Aux[num4].TerminaisBlocoUsado = "T1;";
												}
												if (clsBlocos.ExisteAtributo(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString(), "T2"))
												{
													m_Aux[num4].TerminaisBlocoUsado += "T2;";
												}
												if (clsBlocos.ExisteAtributo(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString(), "T3"))
												{
													m_Aux[num4].TerminaisBlocoUsado += "T3;";
												}
												m_Aux[num4].Handle = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
												m_Aux[num4].iPn = structureDispositivo.Painel;
												m_Aux[num4].sTerminaisMod = LeOsTerminaisdeUmIndiceDeContatosAuxiliar(ref structureAuxiliar.IndexModelo, ref structureAuxiliar.IndexContato);
											}
											if (lPnApagados.Contains(Conversions.ToString((int)structureDispositivo.Painel)))
											{
												m_Aux[num4].bPnApagados = true;
											}
										}
										continue;
									}
									object obj4 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									DeclaracoesEntidades.StructureDispositivo structureDispositivo2 = ((obj4 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj4));
									if (lPn.Contains(Conversions.ToString((int)structureDispositivo2.Painel)))
									{
										checked
										{
											num3++;
											m_Disp = (_StructuremDispositivo[])Utils.CopyArray(m_Disp, new _StructuremDispositivo[num3 + 1]);
											m_Disp[num3].Nome1 = structureDispositivo2.Nome1;
											m_Disp[num3].Nome2 = structureDispositivo2.Nome2;
											m_Disp[num3].Alternativo = structureDispositivo2.Alternativo;
											m_Disp[num3].iLM1 = structureDispositivo2.iLM1;
											m_Disp[num3].iLM2 = structureDispositivo2.iLM2;
											m_Disp[num3].indexModelo = structureDispositivo2.indexModelo;
											m_Disp[num3].Modelo = structureDispositivo2.Modelo;
											m_Disp[num3].Painel = structureDispositivo2.Painel;
											ref string sTerminais2 = ref m_Disp[num3].sTerminais;
											tipoImportado = "";
											string sB = "";
											LeOsTerminais(ref ent, ref sTerminais2, ref tipoImportado, ref sB);
											m_Disp[num3].Handle = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
											m_Disp[num3].iPn = structureDispositivo2.Painel;
										}
										if (lPnApagados.Contains(Conversions.ToString((int)structureDispositivo2.Painel)))
										{
											m_Disp[num3].bPnApagados = true;
										}
									}
									continue;
								}
								blockRef2 = (BlockReference)ent;
								obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
								ent = (Entity)(object)blockRef2;
								object obj5 = obj2;
								DeclaracoesEntidades.StructurePortas structurePortas = ((obj5 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj5));
								DeclaracoesEntidades.StructureMascara structureMascara = default;
								Entity val7 = (Entity)Geral.HandleToObject(structurePortas.HandleDaMascara);
								if (val7 == null)
								{
									continue;
								}
								blockRef2 = (BlockReference)val7;
								obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
								val7 = (Entity)(object)blockRef2;
								object obj6 = obj2;
								structureMascara = ((obj6 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj6));
								if (num5 != structurePortas.indiceDoModelo)
								{
									DicionarioMascaras.LeAsPortasDoModeloDoDicionario(ref structurePortas.indiceDoModelo, sNomeModelo, ref mPortas);
									num5 = structurePortas.indiceDoModelo;
								}
								if (!lPn.Contains(Conversions.ToString((int)structureMascara.Painel)))
								{
									continue;
								}
								_StructureAnalisePorta pot = new _StructureAnalisePorta
								{
									indexMascara = structurePortas.indiceDoModelo,
									indexPorta = structurePortas.indiceDaPorta,
									sHandle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString(),
									sNomeMascara = structurePortas.Nome1
								};
								if (Operators.CompareString(structurePortas.Nome2, "", TextCompare: true) != 0)
								{
									pot.sNomeMascara = structurePortas.Nome1 + "-" + structurePortas.Nome2;
								}
								pot.sNomeMascara = Dicionario.BuscaNomeDoPainel(structureMascara.Painel) + "/" + pot.sNomeMascara;
								pot.sattB = "";
								pot.sBorn = "";
								pot.sEFC = "";
								pot.sPagina = "";
								pot.sRegua = "";
								pot.sTermM = "";
								pot.sTerm = "";
								pot.sTermM = "";
								pot.sBornM = "";
								LeOsTerminaisDeUmaPorta(ref ent, ref pot);
								if ((Operators.CompareString(pot.sRegua, "", TextCompare: true) != 0) & (Operators.CompareString(pot.sBorn, "", TextCompare: true) != 0))
								{
									pot.sTermM = "";
									pot.sTerm = "";
								}
								int num6 = Information.UBound(mPortas);
								checked
								{
									for (int i = 1; i <= num6; i++)
									{
										if (pot.indexPorta == mPortas[i].IndiceDaPorta)
										{
											pot.sTermM = mPortas[i].sTerminais;
											pot.sBornM = mPortas[i].sBornes;
											break;
										}
									}
									pot.sBornM = pot.sBornM.Replace(" ", "");
									pot.sBornM = pot.sBornM.Replace("*", "");
									pot.sBorn = pot.sBorn.Replace(" ", "");
									pot.sTerm = pot.sTerm.Replace(" ", "");
									pot.sTermM = pot.sTermM.Replace(" ", "");
									string item = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
									if (!list.Contains(item))
									{
										list.Add(item);
										num2++;
										m_TodasPortas = (_StructureAnalisePorta[])Utils.CopyArray(m_TodasPortas, new _StructureAnalisePorta[num2 + 1]);
										m_TodasPortas[num2] = pot;
										m_TodasPortas[num2].sPagina = Conversions.ToString(Pagina.calculaPaginaDecimal(ent.Layer.ToString()));
									}
									m_TodasPortas[num2].iPn = structureMascara.Painel;
								}
								if (lPnApagados.Contains(Conversions.ToString((int)structureMascara.Painel)))
								{
									m_TodasPortas[num2].bPnApagados = true;
								}
								continue;
							}
							DeclaracoesEntidades.StructureBorne structureBorne = default;
							blockRef2 = (BlockReference)ent;
							obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
							ent = (Entity)(object)blockRef2;
							object obj7 = obj2;
							structureBorne = ((obj7 == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj7));
							short num7 = 0;
							num7 = checked((short)DicionarioBorne.BuscaPainelDoBorneNoDicionario(ref structureBorne.IndiceRegua, ref structureBorne.NomeRegua, ref structureBorne.Alternativo));
							if (lPn.Contains(Conversions.ToString((int)num7)))
							{
								int num8;
								checked
								{
									num8 = Information.UBound(m_TodosBornes) + 1;
									m_TodosBornes = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(m_TodosBornes, new DeclaracoesEntidades.StructureBorne[num8 + 1]);
									m_TodosBornes[num8] = structureBorne;
									if (Operators.CompareString(m_TodosBornes[num8].NumeroComplem, "", TextCompare: true) != 0)
									{
										m_TodosBornes[num8].Numero += m_TodosBornes[num8].NumeroComplem;
									}
									if (Operators.CompareString(m_TodosBornes[num8].Numero, "0", TextCompare: true) == 0)
									{
										m_TodosBornes[num8].Numero = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
									}
									ref DeclaracoesEntidades.StructureBorne reference = ref m_TodosBornes[num8];
									tipoImportado = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
									reference.NumeroComplem = clsBlocos.LeUmAtributoDeUmBloco(ref tipoImportado, "T1");
									if (Operators.CompareString(m_TodosBornes[num8].NumeroComplem, m_TodosBornes[num8].Numero, TextCompare: true) == 0)
									{
										m_TodosBornes[num8].NumeroComplem = "";
									}
									m_TodosBornes[num8].IndiceRegua = structureBorne.IndiceRegua;
									m_TodosBornes[num8].Alternativo = clsTextos.TiraNothing(m_TodosBornes[num8].Alternativo);
									m_TodosBornes[num8].reserva = false;
									m_TodosBornes[num8].Handle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
									m_TodosBornes[num8].pagina = Pagina.montaCruzamentoPagina(ent.Layer.ToString(), Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2));
									m_TodosBornes[num8].lm = structureBorne.lm;
									m_TodosBornes[num8].sPagina = Conversions.ToString(Pagina.calculaPaginaDecimal(ent.Layer.ToString()));
									m_TodosBornes[num8].indexPainel = num7;
									m_TodosBornes[num8].NomePainel = Dicionario.BuscaNomeDoPainel(num7);
									BlockReference val8 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
									if (val8 != null)
									{
										ref DeclaracoesEntidades.StructureBorne reference2 = ref m_TodosBornes[num8];
										val9 = val8.Position;
										reference2.iLinha = (int)Math.Round(Math.Round(val9.X, 1));
										ref DeclaracoesEntidades.StructureBorne reference3 = ref m_TodosBornes[num8];
										val9 = val8.Position;
										reference3.iColuna = (int)Math.Round(Math.Round(val9.Y, 1));
									}
								}
								if (lPnApagados.Contains(Conversions.ToString((int)num7)))
								{
									m_TodosBornes[num8].bPnApagado = true;
								}
							}
						}
						else
						{
							if (!XDataConexao.lerXDataConexao(ref pl, ref conex) || !lPn.Contains(Conversions.ToString((int)conex.Painel)))
							{
								continue;
							}
							if (Operators.CompareString(conex.Jumper.ToUpper(), "JUMPER", TextCompare: true) == 0)
							{
								if (((conex.Tipo == 4) & (Operators.CompareString(sTipoRelat, "J", TextCompare: true) == 0)) && (conex.Disp1 & conex.Disp2))
								{
									if (list2.Contains(conex.Potencial))
									{
										LFiacaoTTDuplicada.Add(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
									}
									else
									{
										list2.Add(conex.Potencial);
									}
								}
								continue;
							}
							checked
							{
								num++;
								m_Fiacao = (_StructureConexao[])Utils.CopyArray(m_Fiacao, new _StructureConexao[num + 1]);
								m_Fiacao[num].indexCor = ((Entity)pl).ColorIndex;
							}
							m_Fiacao[num].iPesoLinha = (int)((Entity)pl).LineWeight;
							m_Fiacao[num].Handle = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
							m_Fiacao[num].Cor_Nome = conex.Cor;
							m_Fiacao[num].sSecao = conex.Secao;
							m_Fiacao[num].iPotencial_Veia = conex.Potencial;
							m_Fiacao[num].iTipo = conex.Tipo;
							m_Fiacao[num].HandleSup = "OK";
							m_Fiacao[num].sPaginaa = ((Entity)pl).Layer;
							ref _StructureConexao reference4 = ref m_Fiacao[num];
							val9 = ((Curve)pl).StartPoint;
							reference4.x = val9.X;
							ref _StructureConexao reference5 = ref m_Fiacao[num];
							val9 = ((Curve)pl).StartPoint;
							reference5.y = val9.Y;
							m_Fiacao[num].sPainel = Dicionario.BuscaNomeDoPainel(conex.Painel);
							m_Fiacao[num].iPainel = conex.Painel;
							m_Fiacao[num].ptIni = ((Curve)pl).StartPoint;
							m_Fiacao[num].ptFim = ((Curve)pl).EndPoint;
							if (conex.Tipo == 3)
							{
								m_Fiacao[num].HandleSup = conex.Handle;
							}
							if (lPnApagados.Contains(Conversions.ToString((int)conex.Painel)) | (conex.Painel == 0))
							{
								m_Fiacao[num].bPnApagado = true;
							}
							if ((conex.Tipo == 2) & (Operators.CompareString(sTipoRelat, "F", TextCompare: true) == 0))
							{
								if (list2.Contains(conex.Potencial))
								{
									LFiacaoTTDuplicada.Add(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
								}
								else
								{
									list2.Add(conex.Potencial);
								}
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				int num9 = Information.UBound(m_TodosBornes);
				checked
				{
					for (int j = 1; j <= num9; j++)
					{
						int num10 = Information.UBound(m_TodosBornes) - 1;
						int num11 = j;
						for (int k = num10; k >= num11; k += -1)
						{
							if (m_TodosBornes[k].IndiceRegua > m_TodosBornes[k + 1].IndiceRegua)
							{
								DeclaracoesEntidades.StructureBorne structureBorne2 = default;
								structureBorne2 = m_TodosBornes[k + 1];
								m_TodosBornes[k + 1] = m_TodosBornes[k];
								m_TodosBornes[k] = structureBorne2;
							}
							if (m_TodosBornes[k].IndiceRegua == m_TodosBornes[k + 1].IndiceRegua && m_TodosBornes[k].Ordem > m_TodosBornes[k + 1].Ordem)
							{
								DeclaracoesEntidades.StructureBorne structureBorne3 = default;
								structureBorne3 = m_TodosBornes[k + 1];
								m_TodosBornes[k + 1] = m_TodosBornes[k];
								m_TodosBornes[k] = structureBorne3;
							}
						}
					}
					int num12 = Information.UBound(m_TodasPortas);
					for (int l = 1; l <= num12; l++)
					{
						int num13 = Information.UBound(m_TodasPortas) - 1;
						int num14 = l;
						for (int m = num13; m >= num14; m += -1)
						{
							if (m_TodasPortas[m].indexMascara > m_TodasPortas[m + 1].indexMascara)
							{
								_StructureAnalisePorta structureAnalisePorta = default;
								structureAnalisePorta = m_TodasPortas[m + 1];
								m_TodasPortas[m + 1] = m_TodasPortas[m];
								m_TodasPortas[m] = structureAnalisePorta;
							}
							if (m_TodasPortas[m].indexMascara == m_TodasPortas[m + 1].indexMascara && m_TodasPortas[m].indexPorta > m_TodasPortas[m + 1].indexPorta)
							{
								_StructureAnalisePorta structureAnalisePorta2 = default;
								structureAnalisePorta2 = m_TodasPortas[m + 1];
								m_TodasPortas[m + 1] = m_TodasPortas[m];
								m_TodasPortas[m] = structureAnalisePorta2;
							}
						}
					}
					int num15 = Information.UBound(m_Disp);
					for (int n = 1; n <= num15; n++)
					{
						int num16 = Information.UBound(m_Disp) - 1;
						int num17 = n;
						for (int num18 = num16; num18 >= num17; num18 += -1)
						{
							if (m_Disp[num18].indexModelo > m_Disp[num18 + 1].indexModelo)
							{
								_StructuremDispositivo structuremDispositivo = default;
								structuremDispositivo = m_Disp[num18 + 1];
								m_Disp[num18 + 1] = m_Disp[num18];
								m_Disp[num18] = structuremDispositivo;
							}
						}
					}
					int num19 = Information.UBound(m_Aux);
					for (int num20 = 1; num20 <= num19; num20++)
					{
						int num21 = Information.UBound(m_Aux) - 1;
						int num22 = num20;
						for (int num23 = num21; num23 >= num22; num23 += -1)
						{
							if (m_Aux[num23].IndexModelo > m_Aux[num23 + 1].IndexModelo)
							{
								_StructuremAuxiliar structuremAuxiliar = default;
								structuremAuxiliar = m_Aux[num23 + 1];
								m_Aux[num23 + 1] = m_Aux[num23];
								m_Aux[num23] = structuremAuxiliar;
							}
							if (m_Aux[num23].IndexModelo == m_Aux[num23 + 1].IndexModelo && Operators.CompareString(m_Aux[num23].Nome1, m_Aux[num23 + 1].Nome1, TextCompare: true) > 0)
							{
								_StructuremAuxiliar structuremAuxiliar2 = default;
								structuremAuxiliar2 = m_Aux[num23 + 1];
								m_Aux[num23 + 1] = m_Aux[num23];
								m_Aux[num23] = structuremAuxiliar2;
							}
							if (m_Aux[num23].IndexModelo == m_Aux[num23 + 1].IndexModelo && Operators.CompareString(m_Aux[num23].Nome1, m_Aux[num23 + 1].Nome1, TextCompare: true) == 0 && m_Aux[num23].IndexContato > m_Aux[num23 + 1].IndexContato)
							{
								_StructuremAuxiliar structuremAuxiliar3 = default;
								structuremAuxiliar3 = m_Aux[num23 + 1];
								m_Aux[num23 + 1] = m_Aux[num23];
								m_Aux[num23] = structuremAuxiliar3;
							}
						}
					}
					int num24 = Information.UBound(m_Fiacao);
					for (int num25 = 1; num25 <= num24; num25++)
					{
						if (m_Fiacao[num25].iTipo != 2)
						{
							continue;
						}
						int num26 = num25 + 1;
						int num27 = Information.UBound(m_Fiacao);
						for (int num28 = num26; num28 <= num27; num28++)
						{
							if (m_Fiacao[num28].iTipo == 2 && Operators.CompareString(m_Fiacao[num25].sPaginaa, m_Fiacao[num28].sPaginaa, TextCompare: true) == 0 && Operators.CompareString(m_Fiacao[num25].Handle, m_Fiacao[num28].Handle, TextCompare: true) != 0 && ((m_Fiacao[num25].ptIni == m_Fiacao[num28].ptIni) & (m_Fiacao[num25].ptFim == m_Fiacao[num28].ptFim)))
							{
								if (m_Fiacao[num25].iPotencial_Veia <= m_Fiacao[num28].iPotencial_Veia)
								{
									LFiacaoTTDuplicada.Add(m_Fiacao[num25].Handle);
								}
								else
								{
									LFiacaoTTDuplicada.Add(m_Fiacao[num28].Handle);
								}
							}
						}
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
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

	public static string LeOsTerminaisdeUmIndiceDeContatosAuxiliar(ref int iIndiceModelo, ref int iIndiceContato)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected Obj, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected Obj, but got Unknown
		string text = "";
		DBDictionary val = null;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val2 = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				DBDictionary val3 = (DBDictionary)val2.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
				if (val3.Contains("CONTATOS"))
				{
					val = (DBDictionary)val2.GetObject(val3.GetAt("CONTATOS"), (OpenMode)0);
					if (val.Contains(Conversions.ToString(iIndiceModelo)))
					{
						ObjectId at = val.GetAt(Conversions.ToString(iIndiceModelo));
						Xrecord val4 = (Xrecord)val2.GetObject(at, (OpenMode)0);
						ResultBuffer data = val4.Data;
						TypedValue[] array = data.AsArray();
						int num = Information.UBound(array);
						for (int i = 1; i <= num; i += 8)
						{
							if (iIndiceContato == Conversions.ToInteger(array[i + 0].Value))
							{
								text = Conversions.ToString(array[i + 1].Value);
								if (Operators.CompareString(Conversions.ToString(array[i + 2].Value), "", TextCompare: true) != 0)
								{
									text = text + ", " + Conversions.ToString(array[i + 2].Value);
								}
								if (Operators.CompareString(Conversions.ToString(array[i + 3].Value), "", TextCompare: true) != 0)
								{
									text = text + ", " + Conversions.ToString(array[i + 3].Value);
								}
								break;
							}
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
			return text;
		}
	}

	public static void PintaFiacao(ref _StructureConexao[] mFiacao, int icor = 0)
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
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
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
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)1);
							Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
							DeclaracoesEntidades.StructureConexao conex = default;
							if (pl == null || !XDataConexao.lerXDataConexao(ref pl, ref conex) || Operators.CompareString(conex.Jumper, "JUMPER", TextCompare: true) == 0)
							{
								continue;
							}
							if (icor != 0)
							{
								int num = Information.UBound(mFiacao);
								for (int i = 1; i <= num; i++)
								{
									if (Operators.CompareString(mFiacao[i].Handle, ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString(), TextCompare: true) == 0)
									{
										((DBObject)pl).UpgradeOpen();
										((Entity)pl).ColorIndex = icor;
										((Entity)pl).LineWeight = (LineWeight)30;
									}
								}
								continue;
							}
							int num2 = Information.UBound(mFiacao);
							for (int j = 1; j <= num2; j++)
							{
								if (Operators.CompareString(mFiacao[j].Handle, ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString(), TextCompare: true) == 0)
								{
									((DBObject)pl).UpgradeOpen();
									((Entity)pl).ColorIndex = mFiacao[j].indexCor;
									((Entity)pl).LineWeight = (LineWeight)mFiacao[j].iPesoLinha;
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
	}

	public static void carregaTree(ref TreeView tree, _StructureConexao[] mFiacao, List<string> LFiacaoTTDuplicada, ref _StructurefiacaoErro[] mCorFiacao)
	{
		tree.Nodes.Clear();
		List<string> list = new List<string>();
		int num = 0;
		int num2 = 0;
		_StructurefiacaoErro[] array = new _StructurefiacaoErro[1];
		List<int> list2 = new List<int>();
		List<string> list3 = new List<string>();
		checked
		{
			if (Information.UBound(mFiacao) > 0)
			{
				list.Clear();
				int num3 = Information.UBound(mFiacao);
				for (int i = 1; i <= num3; i++)
				{
					string text = mFiacao[i].Cor_Nome + " - " + mFiacao[i].sSecao;
					if (mFiacao[i].bPnApagado)
					{
						text = "ERROS";
					}
					if (!((Operators.CompareString(mFiacao[i].Cor_Nome.Trim(), "", TextCompare: true) == 0) | (Operators.CompareString(mFiacao[i].sSecao.Trim(), "", TextCompare: true) == 0) | mFiacao[i].bPnApagado))
					{
						if (!list3.Contains(mFiacao[i].sPaginaa + "-" + Conversions.ToString(mFiacao[i].iPotencial_Veia)))
						{
							num2++;
							mCorFiacao = (_StructurefiacaoErro[])Utils.CopyArray(mCorFiacao, new _StructurefiacaoErro[num2 + 1]);
							mCorFiacao[num2].sCorFiacao = text;
							mCorFiacao[num2].iPotencial = Conversions.ToString(mFiacao[i].iPotencial_Veia);
							mCorFiacao[num2].sCabo = Conversions.ToString(mFiacao[i].iPotencial_Veia);
							mCorFiacao[num2].sPagina = mFiacao[i].sPaginaa;
							mCorFiacao[num2].sPainel = mFiacao[i].sPainel;
							list3.Add(mFiacao[i].sPaginaa + "-" + Conversions.ToString(mFiacao[i].iPotencial_Veia));
						}
					}
					else if (!list2.Contains(mFiacao[i].iPotencial_Veia))
					{
						num++;
						array = (_StructurefiacaoErro[])Utils.CopyArray(array, new _StructurefiacaoErro[num + 1]);
						array[num].sValor = text;
						array[num].iPotencial = Conversions.ToString(mFiacao[i].iPotencial_Veia);
						list2.Add(mFiacao[i].iPotencial_Veia);
					}
					if (!list.Contains(text) && Operators.CompareString(text.Trim(), "", TextCompare: true) != 0)
					{
						list.Add(text);
					}
				}
				if (Information.UBound(array) >= 2)
				{
					int num4 = Information.UBound(array);
					for (int j = 1; j <= num4; j++)
					{
						int num5 = Information.UBound(array) - 1;
						int num6 = j;
						for (int k = num5; k >= num6; k += -1)
						{
							if (Operators.CompareString(array[k].sPagina, array[k + 1].sPagina, TextCompare: true) > 0)
							{
								_StructurefiacaoErro structurefiacaoErro = array[k + 1];
								array[k + 1] = array[k];
								array[k] = structurefiacaoErro;
							}
							if (Operators.CompareString(array[k].sPagina, array[k + 1].sPagina, TextCompare: true) == 0 && array[k].x > array[k + 1].x)
							{
								_StructurefiacaoErro structurefiacaoErro = array[k + 1];
								array[k + 1] = array[k];
								array[k] = structurefiacaoErro;
							}
						}
					}
				}
				if (!Information.IsNothing(mCorFiacao))
				{
					int num7 = Information.UBound(mCorFiacao);
					for (int l = 1; l <= num7; l++)
					{
						int num8 = Information.UBound(mCorFiacao) - 1;
						int num9 = l;
						for (int m = num8; m >= num9; m += -1)
						{
							if (Operators.CompareString(mCorFiacao[m].sPainel, mCorFiacao[m + 1].sPainel, TextCompare: true) > 0)
							{
								_StructurefiacaoErro structurefiacaoErro = mCorFiacao[m + 1];
								mCorFiacao[m + 1] = mCorFiacao[m];
								mCorFiacao[m] = structurefiacaoErro;
							}
							if (Operators.CompareString(mCorFiacao[m].sPainel, mCorFiacao[m + 1].sPainel, TextCompare: true) == 0 && Operators.CompareString(mCorFiacao[m].iPotencial, mCorFiacao[m + 1].iPotencial, TextCompare: true) > 0)
							{
								_StructurefiacaoErro structurefiacaoErro = mCorFiacao[m + 1];
								mCorFiacao[m + 1] = mCorFiacao[m];
								mCorFiacao[m] = structurefiacaoErro;
							}
							if (Operators.CompareString(mCorFiacao[m].sPainel, mCorFiacao[m + 1].sPainel, TextCompare: true) == 0 && Operators.CompareString(mCorFiacao[m].iPotencial, mCorFiacao[m + 1].iPotencial, TextCompare: true) == 0 && Operators.CompareString(mCorFiacao[m].sPagina, mCorFiacao[m + 1].sPagina, TextCompare: true) > 0)
							{
								_StructurefiacaoErro structurefiacaoErro = mCorFiacao[m + 1];
								mCorFiacao[m + 1] = mCorFiacao[m];
								mCorFiacao[m] = structurefiacaoErro;
							}
						}
					}
				}
				list.Sort();
				TreeNode treeNode = (TreeNode)NewLateBinding.LateGet(tree.Nodes, null, "Add", new object[1] { Operators.ConcatenateObject("   ", DeclaracoesGeral.mMensagem[1, 559]) }, null, null, null);
				treeNode.Name = Conversions.ToString(Operators.ConcatenateObject("   ", DeclaracoesGeral.mMensagem[1, 559]));
				foreach (string item in list)
				{
					TreeNode treeNode2 = treeNode.Nodes.Add(item);
					treeNode2.Name = item;
				}
				int num10 = Information.UBound(array);
				for (int n = 1; n <= num10; n++)
				{
					string iPotencial = array[n].iPotencial;
					if (Operators.CompareString(iPotencial, "ERRO", TextCompare: true) != 0)
					{
						object instance = NewLateBinding.LateGet(tree.Nodes, null, "Item", new object[1] { Operators.ConcatenateObject("   ", DeclaracoesGeral.mMensagem[1, 559]) }, null, null, null);
						object[] array2 = new object[1];
						ref string sValor = ref array[n].sValor;
						array2[0] = sValor;
						object[] array3 = array2;
						object instance2 = NewLateBinding.LateGet(instance, null, "Nodes", array2, null, null, new bool[1] { true });
						sValor = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(string));
						object instance3 = NewLateBinding.LateGet(instance2, null, "Nodes", new object[0], null, null, null);
						object[] array4 = new object[1] { iPotencial };
						object[] array5 = array4;
						object obj = NewLateBinding.LateGet(instance3, null, "Add", array4, null, null, new bool[1] { true });
						iPotencial = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array5[0]), typeof(string));
						TreeNode treeNode3 = (TreeNode)obj;
						treeNode3.ForeColor = Color.Red;
					}
				}
				tree.Sort();
				if (LFiacaoTTDuplicada.Count > 0)
				{
					TreeNode treeNode2 = (TreeNode)NewLateBinding.LateGet(treeNode.Nodes, null, "Add", new object[1] { Operators.ConcatenateObject(" ", DeclaracoesGeral.mMensagem[1, 1567]) }, null, null, null);
					treeNode2.Name = Conversions.ToString(Operators.ConcatenateObject(" ", DeclaracoesGeral.mMensagem[1, 1567]));
				}
				foreach (string LFiacaoTTDuplicadum in LFiacaoTTDuplicada)
				{
					object[] array5;
					object obj = NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(tree.Nodes, null, "Item", new object[1] { Operators.ConcatenateObject("   ", DeclaracoesGeral.mMensagem[1, 559]) }, null, null, null), null, "Nodes", new object[1] { Operators.ConcatenateObject(" ", DeclaracoesGeral.mMensagem[1, 1567]) }, null, null, null), null, "Nodes", new object[0], null, null, null), null, "Add", array5 = new object[1] { LFiacaoTTDuplicadum }, null, null, new bool[1] { true });
					string current2 = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array5[0]), typeof(string));
					TreeNode treeNode4 = (TreeNode)obj;
					treeNode4.ForeColor = Color.Red;
				}
			}
			tree.ExpandAll();
		}
	}

	public static void carregaOrfao(ref DataGridView dgFiacaoOrfao, _StructureConexao[] mFiacao)
	{
		int num = 0;
		_StructurefiacaoErro[] array = new _StructurefiacaoErro[1];
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		List<string> list3 = new List<string>();
		int num2 = 0;
		HandlePorta[] array2 = new HandlePorta[1];
		int num3 = Information.UBound(mFiacao);
		checked
		{
			for (int i = 1; i <= num3; i++)
			{
				if (!list.Contains(mFiacao[i].iPotencial_Veia) && ((mFiacao[i].iTipo == 1) | (mFiacao[i].iTipo == 2)))
				{
					list.Add(mFiacao[i].iPotencial_Veia);
				}
				if (!list3.Contains(mFiacao[i].Handle))
				{
					list3.Add(mFiacao[i].Handle);
					num2++;
					array2 = (HandlePorta[])Utils.CopyArray(array2, new HandlePorta[num2 + 1]);
					array2[num2].sHandle = mFiacao[i].Handle;
					array2[num2].sPagina = mFiacao[i].sPaginaa;
				}
			}
			new List<int>();
			if (Information.UBound(mFiacao) <= 0)
			{
				return;
			}
			int num4 = Information.UBound(mFiacao);
			for (int j = 1; j <= num4; j++)
			{
				if (Operators.CompareString(mFiacao[j].HandleSup, "", TextCompare: true) == 0)
				{
					num++;
					array = (_StructurefiacaoErro[])Utils.CopyArray(array, new _StructurefiacaoErro[num + 1]);
					array[num].sValor = mFiacao[j].Handle;
					array[num].iPotencial = Conversions.ToString(mFiacao[j].iPotencial_Veia);
					array[num].sPagina = mFiacao[j].sPaginaa;
					array[num].x = mFiacao[j].x;
					array[num].y = mFiacao[j].y;
					array[num].sPainel = mFiacao[j].sPainel;
				}
			}
			int num5 = Information.UBound(mFiacao);
			for (int k = 1; k <= num5; k++)
			{
				if (list.Contains(mFiacao[k].iPotencial_Veia) || list2.Contains(mFiacao[k].iPotencial_Veia))
				{
					if (Operators.CompareString(mFiacao[k].HandleSup, "OK", TextCompare: true) == 0)
					{
						continue;
					}
					bool flag = true;
					int num6 = Information.UBound(array2);
					for (int l = 1; l <= num6; l++)
					{
						if (Operators.CompareString(array2[l].sHandle, mFiacao[k].HandleSup, TextCompare: true) == 0 && Operators.CompareString(array2[l].sPagina, mFiacao[k].sPaginaa, TextCompare: true) == 0)
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						num++;
						array = (_StructurefiacaoErro[])Utils.CopyArray(array, new _StructurefiacaoErro[num + 1]);
						array[num].sValor = mFiacao[k].Handle;
						array[num].iPotencial = Conversions.ToString(mFiacao[k].iPotencial_Veia);
						array[num].sPagina = mFiacao[k].sPaginaa;
						array[num].x = mFiacao[k].x;
						array[num].y = mFiacao[k].y;
						array[num].sPainel = mFiacao[k].sPainel;
						list2.Add(mFiacao[k].iPotencial_Veia);
					}
				}
				else
				{
					num++;
					array = (_StructurefiacaoErro[])Utils.CopyArray(array, new _StructurefiacaoErro[num + 1]);
					array[num].sValor = mFiacao[k].Handle;
					array[num].iPotencial = Conversions.ToString(mFiacao[k].iPotencial_Veia);
					array[num].sPagina = mFiacao[k].sPaginaa;
					array[num].x = mFiacao[k].x;
					array[num].y = mFiacao[k].y;
					array[num].sPainel = mFiacao[k].sPainel;
					list2.Add(mFiacao[k].iPotencial_Veia);
				}
			}
			if (Information.UBound(array) >= 2)
			{
				int num7 = Information.UBound(array);
				for (int m = 1; m <= num7; m++)
				{
					int num8 = Information.UBound(array) - 1;
					int num9 = m;
					for (int n = num8; n >= num9; n += -1)
					{
						if (Operators.CompareString(array[n].sPainel, array[n + 1].sPainel, TextCompare: true) > 0)
						{
							_StructurefiacaoErro structurefiacaoErro = array[n + 1];
							array[n + 1] = array[n];
							array[n] = structurefiacaoErro;
						}
						if (Operators.CompareString(array[n].sPainel, array[n + 1].sPainel, TextCompare: true) == 0 && Operators.CompareString(array[n].sPagina, array[n + 1].sPagina, TextCompare: true) > 0)
						{
							_StructurefiacaoErro structurefiacaoErro = array[n + 1];
							array[n + 1] = array[n];
							array[n] = structurefiacaoErro;
						}
						if (Operators.CompareString(array[n].sPainel, array[n + 1].sPainel, TextCompare: true) == 0 && Operators.CompareString(array[n].sPagina, array[n + 1].sPagina, TextCompare: true) == 0 && array[n].x > array[n + 1].x)
						{
							_StructurefiacaoErro structurefiacaoErro = array[n + 1];
							array[n + 1] = array[n];
							array[n] = structurefiacaoErro;
						}
						if (Operators.CompareString(array[n].sPainel, array[n + 1].sPainel, TextCompare: true) == 0 && Operators.CompareString(array[n].sPagina, array[n + 1].sPagina, TextCompare: true) == 0 && array[n].x == array[n + 1].x && array[n].x > array[n + 1].x)
						{
							_StructurefiacaoErro structurefiacaoErro = array[n + 1];
							array[n + 1] = array[n];
							array[n] = structurefiacaoErro;
						}
					}
				}
			}
			_ = DeclaracoesGeral.Conf.CaracterTerminalIndefinido + DeclaracoesGeral.Conf.CaracterTerminalIndefinido + DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
			int num10 = Information.UBound(array);
			for (int num11 = 1; num11 <= num10; num11++)
			{
				dgFiacaoOrfao.Rows.Add(array[num11].sPainel, array[num11].iPotencial, array[num11].sPagina, array[num11].sValor);
			}
		}
	}

	public static void LeOsTerminaisDeUmaPorta(ref Entity ent, ref _StructureAnalisePorta pot)
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected Obj, but got Unknown
		pot.sTermM = " ";
		pot.sattB = " ";
		pot.sRegua = "";
		int num = 0;
		StrucTerminais[] array = new StrucTerminais[1];
		int num2 = 0;
		StrucTerminais[] array2 = new StrucTerminais[1];
		int num3 = 0;
		StrucTerminais[] array3 = new StrucTerminais[1];
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
					_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					if (ent != null)
					{
						Entity obj = ent;
						BlockReference val4 = (BlockReference)(object)((obj is BlockReference) ? obj : null);
						AttributeCollection attributeCollection = val4.AttributeCollection;
						foreach (object item in attributeCollection)
						{
							ObjectId val5 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference val6 = (AttributeReference)val5.GetObject((OpenMode)0);
							string left = val6.Tag.ToUpper();
							if (Operators.CompareString(left, "EFC", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, Strings.Mid(val6.Tag, 1, 1) + Strings.Mid(val6.Tag, 2, Strings.Len(val6.Tag)), TextCompare: true) != 0)
								{
									continue;
								}
								if ((Operators.CompareString(Strings.Mid(val6.Tag, 1, 1), "T", TextCompare: true) == 0) & Versioned.IsNumeric(Strings.Mid(val6.Tag, 2, Strings.Len(val6.Tag))))
								{
									((DBText)val6).TextString.Replace("*", "");
									num++;
									array = (StrucTerminais[])Utils.CopyArray(array, new StrucTerminais[num + 1]);
									array[num].T = val6.Tag;
									array[num].V = ((DBText)val6).TextString;
									if ((Operators.CompareString(((DBText)val6).TextString.Trim(), "0", TextCompare: true) == 0) | (Operators.CompareString(clsTextos.TiraNothing(((DBText)val6).TextString.Trim()), "", TextCompare: true) == 0))
									{
										array[num].V = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
									}
								}
								if ((Operators.CompareString(Strings.Mid(val6.Tag, 1, 1), "B", TextCompare: true) == 0) & Versioned.IsNumeric(Strings.Mid(val6.Tag, 2, Strings.Len(val6.Tag))))
								{
									((DBText)val6).TextString.Replace("*", "");
									num2++;
									array2 = (StrucTerminais[])Utils.CopyArray(array2, new StrucTerminais[num2 + 1]);
									array2[num2].T = val6.Tag;
									array2[num2].V = ((DBText)val6).TextString;
									if ((Operators.CompareString(((DBText)val6).TextString.Trim(), "0", TextCompare: true) == 0) | (Operators.CompareString(clsTextos.TiraNothing(((DBText)val6).TextString.Trim()), "", TextCompare: true) == 0))
									{
										array2[num2].V = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
									}
								}
								if ((Operators.CompareString(Strings.Mid(val6.Tag, 1, 1), "R", TextCompare: true) == 0) & Versioned.IsNumeric(Strings.Mid(val6.Tag, 2, Strings.Len(val6.Tag))))
								{
									((DBText)val6).TextString.Replace("*", "");
									num3++;
									array3 = (StrucTerminais[])Utils.CopyArray(array3, new StrucTerminais[num3 + 1]);
									array3[num3].T = val6.Tag;
									array3[num3].V = ((DBText)val6).TextString;
									if ((Operators.CompareString(((DBText)val6).TextString.Trim(), "0", TextCompare: true) == 0) | (Operators.CompareString(clsTextos.TiraNothing(((DBText)val6).TextString.Trim()), "", TextCompare: true) == 0))
									{
										array3[num3].V = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
									}
								}
							}
							else
							{
								pot.sEFC = ((DBText)val6).TextString;
							}
						}
						int num4 = Information.UBound(array);
						for (int i = 1; i <= num4; i++)
						{
							int num5 = Information.UBound(array) - 1;
							int num6 = i;
							for (int j = num5; j >= num6; j += -1)
							{
								if (Operators.CompareString(array[j].T, array[j + 1].T, TextCompare: true) > 0)
								{
									StrucTerminais strucTerminais = array[j + 1];
									array[j + 1] = array[j];
									array[j] = strucTerminais;
								}
							}
						}
						pot.sTermM = "";
						pot.sTerm = "";
						int num7 = Information.UBound(array);
						for (int k = 1; k <= num7; k++)
						{
							if (Operators.CompareString(pot.sTermM.Trim(), "", TextCompare: true) != 0)
							{
								ref string sTermM = ref pot.sTermM;
								sTermM = sTermM + ", " + array[k].T;
								ref string sTerm = ref pot.sTerm;
								sTerm = sTerm + ", " + array[k].V;
							}
							else
							{
								pot.sTermM = array[k].T;
								pot.sTerm = array[k].V;
							}
						}
						int num8 = Information.UBound(array2);
						for (int l = 1; l <= num8; l++)
						{
							int num9 = Information.UBound(array2) - 1;
							int num10 = l;
							for (int m = num9; m >= num10; m += -1)
							{
								if (Operators.CompareString(array2[m].T, array2[m + 1].T, TextCompare: true) > 0)
								{
									StrucTerminais strucTerminais2 = array2[m + 1];
									array2[m + 1] = array2[m];
									array2[m] = strucTerminais2;
								}
							}
						}
						pot.sattB = "";
						pot.sBorn = "";
						int num11 = Information.UBound(array2);
						for (int n = 1; n <= num11; n++)
						{
							if (Operators.CompareString(pot.sattB.Trim(), "", TextCompare: true) != 0)
							{
								ref string sattB = ref pot.sattB;
								sattB = sattB + ", " + array2[n].T;
								ref string sBorn = ref pot.sBorn;
								sBorn = sBorn + ", " + array2[n].V;
							}
							else
							{
								pot.sattB = array2[n].T;
								pot.sBorn = array2[n].V;
							}
						}
						int num12 = Information.UBound(array3);
						for (int num13 = 1; num13 <= num12; num13++)
						{
							int num14 = Information.UBound(array3) - 1;
							int num15 = num13;
							for (int num16 = num14; num16 >= num15; num16 += -1)
							{
								if (Operators.CompareString(array3[num16].T, array3[num16 + 1].T, TextCompare: true) > 0)
								{
									StrucTerminais strucTerminais3 = array3[num16 + 1];
									array3[num16 + 1] = array3[num16];
									array3[num16] = strucTerminais3;
								}
							}
						}
						int num17 = Information.UBound(array3);
						for (int num18 = 1; num18 <= num17; num18++)
						{
							if (Operators.CompareString(pot.sRegua.Trim(), "", TextCompare: true) != 0)
							{
								if (Operators.CompareString(pot.sRegua, array3[num18].V, TextCompare: true) != 0)
								{
									ref string sRegua = ref pot.sRegua;
									sRegua = sRegua + "; " + array3[num18].V;
								}
							}
							else
							{
								pot.sRegua = array3[num18].V;
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

	public static void LeOsTerminais(ref Entity ent, ref string sT, ref string sB, ref string sR)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected Obj, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected Obj, but got Unknown
		sT = "";
		sB = "";
		sR = "";
		int num = 0;
		StrucTerminais[] array = new StrucTerminais[1];
		int num2 = 0;
		StrucTerminais[] array2 = new StrucTerminais[1];
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
					_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					if (ent != null)
					{
						Entity obj = ent;
						BlockReference val4 = (BlockReference)(object)((obj is BlockReference) ? obj : null);
						AttributeCollection attributeCollection = val4.AttributeCollection;
						foreach (object item in attributeCollection)
						{
							ObjectId val5 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference val6 = (AttributeReference)val5.GetObject((OpenMode)0);
							string left = val6.Tag.ToUpper();
							if (Operators.CompareString(left, "R1", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, Strings.Mid(val6.Tag, 1, 1) + Strings.Mid(val6.Tag, 2, Strings.Len(val6.Tag)), TextCompare: true) != 0)
								{
									continue;
								}
								if ((Operators.CompareString(Strings.Mid(val6.Tag, 1, 1), "T", TextCompare: true) == 0) & Versioned.IsNumeric(Strings.Mid(val6.Tag, 2, Strings.Len(val6.Tag))))
								{
									((DBText)val6).TextString.Replace("*", "");
									num++;
									array = (StrucTerminais[])Utils.CopyArray(array, new StrucTerminais[num + 1]);
									array[num].T = val6.Tag;
									array[num].V = ((DBText)val6).TextString;
									if ((Operators.CompareString(((DBText)val6).TextString.Trim(), "0", TextCompare: true) == 0) | (Operators.CompareString(clsTextos.TiraNothing(((DBText)val6).TextString.Trim()), "", TextCompare: true) == 0))
									{
										array[num].V = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
									}
								}
								if ((Operators.CompareString(Strings.Mid(val6.Tag, 1, 1), "B", TextCompare: true) == 0) & Versioned.IsNumeric(Strings.Mid(val6.Tag, 2, Strings.Len(val6.Tag))))
								{
									((DBText)val6).TextString.Replace("*", "");
									num2++;
									array2 = (StrucTerminais[])Utils.CopyArray(array2, new StrucTerminais[num2 + 1]);
									array2[num2].T = val6.Tag;
									array2[num2].V = ((DBText)val6).TextString;
									if ((Operators.CompareString(((DBText)val6).TextString.Trim(), "0", TextCompare: true) == 0) | (Operators.CompareString(clsTextos.TiraNothing(((DBText)val6).TextString.Trim()), "", TextCompare: true) == 0))
									{
										array2[num2].V = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
									}
								}
							}
							else
							{
								sR = ((DBText)val6).TextString;
							}
						}
						int num3 = Information.UBound(array);
						for (int i = 1; i <= num3; i++)
						{
							int num4 = Information.UBound(array) - 1;
							int num5 = i;
							for (int j = num4; j >= num5; j += -1)
							{
								if (Operators.CompareString(array[j].T, array[j + 1].T, TextCompare: true) > 0)
								{
									StrucTerminais strucTerminais = array[j + 1];
									array[j + 1] = array[j];
									array[j] = strucTerminais;
								}
							}
						}
						sT = "";
						int num6 = Information.UBound(array);
						for (int k = 1; k <= num6; k++)
						{
							if (Operators.CompareString(sT.Trim(), "", TextCompare: true) != 0)
							{
								sT = sT + ", " + array[k].V;
							}
							else
							{
								sT = array[k].V;
							}
						}
						int num7 = Information.UBound(array2);
						for (int l = 1; l <= num7; l++)
						{
							int num8 = Information.UBound(array2) - 1;
							int num9 = l;
							for (int m = num8; m >= num9; m += -1)
							{
								if (Operators.CompareString(array2[m].T, array2[m + 1].T, TextCompare: true) > 0)
								{
									StrucTerminais strucTerminais2 = array2[m + 1];
									array2[m + 1] = array2[m];
									array2[m] = strucTerminais2;
								}
							}
						}
						sB = "";
						int num10 = Information.UBound(array2);
						for (int n = 1; n <= num10; n++)
						{
							if (Operators.CompareString(sB.Trim(), "", TextCompare: true) != 0)
							{
								sB = sB + ", " + array2[n].V;
							}
							else
							{
								sB = array2[n].V;
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

	public static void buscaReguasVazias(ref _structuremRegua[] mReguas)
	{
		int num = 0;
		mReguas = new _structuremRegua[1];
		Declaracoes2.StructureModeloDeReguas[] mModelo = new Declaracoes2.StructureModeloDeReguas[1];
		DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
		DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mModelo);
		List<string> lReguasUsadas = new List<string>();
		clsReguasDeBornes.EncontraReguasUsadasNoCaderno(ref lReguasUsadas);
		int num2 = Information.UBound(mModelo);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				if (!lReguasUsadas.Contains(Conversions.ToString(mModelo[i].indexPainel) + "," + Conversions.ToString(mModelo[i].indexRegua)))
				{
					num++;
					mReguas = (_structuremRegua[])Utils.CopyArray(mReguas, new _structuremRegua[num + 1]);
					mReguas[num].iPainel = mModelo[i].indexPainel;
					mReguas[num].sPainel = Dicionario.BuscaNomeDoPainel(mModelo[i].indexPainel);
					mReguas[num].iRegua = mModelo[i].indexRegua;
					mReguas[num].sNomeRegua = mModelo[i].nomeRegua;
				}
			}
		}
	}

	public static void mostraPotencialErrado(string sPotencial)
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

	public static void mostraPotencialNaPagina(string sPotencial, string sPG)
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
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
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
						if (pl != null && XDataConexao.lerXDataConexao(ref pl, ref conex) && Operators.CompareString(conex.Potencial.ToString(), sPotencial, TextCompare: true) == 0 && Operators.CompareString(sPG, ((Entity)pl).Layer, TextCompare: true) == 0)
						{
							if (Operators.CompareString(DeclaracoesGeral.ativo.Pagina, ((Entity)pl).Layer, TextCompare: true) != 0)
							{
								Pagina.AtivaPagina(((Entity)pl).Layer);
								uscPaginas uscPagina = DeclaracoesGeral._uscPagina;
								string pag = ((Entity)pl).Layer.ToString();
								uscPagina.ativaPaginaAtalho(ref pag);
							}
							if (conex.Tipo != 3)
							{
								Caderno.ZEntity(((DBObject)pl).ObjectId, 10);
							}
							((Entity)pl).Highlight();
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

	public static void mostraPotencialSelecionado(ref DataGridView dg, _StructurefiacaoErro[] mCorFiacao, string sCorFia)
	{
		clsBlocos.Unhighlight();
		checked
		{
			try
			{
				formatadgPotencialSelecionado(ref dg);
				for (int i = 0; i < mCorFiacao.Length; i++)
				{
					_StructurefiacaoErro structurefiacaoErro = mCorFiacao[i];
					if (Operators.CompareString(structurefiacaoErro.sCorFiacao, sCorFia, TextCompare: true) == 0)
					{
						dg.Rows.Add(structurefiacaoErro.sPainel, structurefiacaoErro.iPotencial, structurefiacaoErro.sPagina);
					}
				}
				AtualizaDGPotencialSelecionado(ref dg);
				int num = dg.RowCount - 1;
				for (int j = 0; j <= num; j++)
				{
					dg.Rows[j].Selected = false;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void formatadgPotencialSelecionado(ref DataGridView dg)
	{
		dg.Rows.Clear();
		dg.Columns.Clear();
		dg.Columns.Add("Painel", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 748]));
		dg.Columns.Add("Pot", "POT");
		dg.Columns.Add("Régua", DeclaracoesGeral.mMensagem[1, 1330].ToString().ToUpper());
	}

	public static void AtualizaDGPotencialSelecionado(ref DataGridView dg)
	{
		if (dg.RowCount <= 0)
		{
			dg.Rows.Clear();
			dg.Columns.Clear();
			return;
		}
		checked
		{
			double num = dg.Width - 4;
			if (haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg))
			{
				num = dg.Width - 21;
			}
			dg.Columns[0].Width = (int)Math.Round(num * 0.45);
			dg.Columns[0].Visible = true;
			dg.Columns[1].Width = (int)Math.Round(num * 0.25);
			dg.Columns[1].Visible = true;
			dg.Columns[2].Width = (int)Math.Round(num * 0.3);
			dg.Columns[2].Visible = true;
			int num2 = dg.Columns.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				dg.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
			}
			dg.MultiSelect = false;
		}
	}
}
