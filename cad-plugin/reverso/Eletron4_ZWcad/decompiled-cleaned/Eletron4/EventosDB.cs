using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;

namespace Eletron4;

public class EventosDB
{
	[AccessedThroughProperty("activeDB")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Database UuX1FeRxGb;

	public EventosDB()
	{
		W9ZTGL6D3Zx(Application.DocumentManager.MdiActiveDocument.Database);
	}

	[SpecialName]
	[CompilerGenerated]
	private virtual Database mhbTGjlq1WV()
	{
		return UuX1FeRxGb;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	private virtual void W9ZTGL6D3Zx(Database WithEventsValue)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected Obj, but got Unknown
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected Obj, but got Unknown
		ObjectEventHandler val = yvi1NN8qx1;
		ObjectEventHandler val2 = onDBModifiedEvent;
		ObjectErasedEventHandler val3 = onObjectEraseded;
		Database val4 = UuX1FeRxGb;
		if (val4 != null)
		{
			val4.ObjectAppended -= val;
			val4.ObjectModified -= val2;
			val4.ObjectErased -= val3;
		}
		UuX1FeRxGb = WithEventsValue;
		val4 = UuX1FeRxGb;
		if (val4 != null)
		{
			val4.ObjectAppended += val;
			val4.ObjectModified += val2;
			val4.ObjectErased += val3;
		}
	}

	private void yvi1NN8qx1(object P_0, ObjectEventArgs P_1)
	{
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected Obj, but got Unknown
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Expected Obj, but got Unknown
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Expected Obj, but got Unknown
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		//IL_0458: Expected Obj, but got Unknown
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected Obj, but got Unknown
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_046e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0475: Expected Obj, but got Unknown
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Expected Obj, but got Unknown
		//IL_053f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0546: Expected Obj, but got Unknown
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected Obj, but got Unknown
		//IL_055c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0563: Expected Obj, but got Unknown
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Expected Obj, but got Unknown
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Expected Obj, but got Unknown
		if (DeclaracoesGeral.bSuspenderEvento || DeclaracoesGeral.bAnularEventos || DeclaracoesGeral.bSuspenderEventoExpImpClonar)
		{
			return;
		}
		try
		{
			DBObject dBObject = P_1.DBObject;
			Entity ent = (Entity)(object)((dBObject is Entity) ? dBObject : null);
			if (ent != null && !((DBObject)ent).IsErased)
			{
				short tipo = 0;
				if (XDataConexao.lerXDataHatchLinha(ref ent, ref tipo))
				{
					((DBObject)ent).UpgradeOpen();
					((DBObject)ent).Erase();
				}
			}
			DBObject dBObject2 = P_1.DBObject;
			BlockReference val = (BlockReference)(object)((dBObject2 is BlockReference) ? dBObject2 : null);
			if (val != null)
			{
				Entity ent2 = (Entity)(object)val;
				string tipoImportado = "";
				string text = XDataDispositivo.verificaTipoDispositivo(ref ent2, ref tipoImportado);
				val = (BlockReference)ent2;
				string text2 = text;
				string left = text2;
				if (Operators.CompareString(left, "B", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left, "E", TextCompare: true) != 0)
					{
						if ((Operators.CompareString(left, "A", TextCompare: true) == 0 || Operators.CompareString(left, "P", TextCompare: true) == 0 || Operators.CompareString(left, "M", TextCompare: true) == 0 || Operators.CompareString(left, "I", TextCompare: true) == 0) && !((DBObject)val).IsErased)
						{
							((DBObject)val).UpgradeOpen();
							((DBObject)val).Erase();
						}
					}
					else if (!clsBlocos.VerificaDocumetoValidoParaColar())
					{
						if (!((DBObject)val).IsErased)
						{
							((DBObject)val).UpgradeOpen();
							((DBObject)val).Erase();
						}
					}
					else
					{
						clsPortas.IndefineUmaPorta(((object)((DBObject)val).Handle/*cast due to constrained. prefix*/).ToString(), bLimpaTudo: false);
						Correcao.LimpaXData((Entity)(object)val, "EXPORTADO");
					}
				}
				else if (!clsBlocos.VerificaDocumetoValidoParaColar())
				{
					if (!((DBObject)val).IsErased)
					{
						((DBObject)val).UpgradeOpen();
						((DBObject)val).Erase();
					}
				}
				else
				{
					clsBornes.indefineUmBorne(((object)((DBObject)val).Handle/*cast due to constrained. prefix*/).ToString());
					text = ((object)((DBObject)val).Handle/*cast due to constrained. prefix*/).ToString();
					clsBlocos.EditaUmAtributoDeUmBloco(ref text, "T1", DeclaracoesGeral.Conf.CaracterTerminalIndefinido);
					Correcao.LimpaXData((Entity)(object)val, "EXPORTADO");
				}
				Declaracoes2.StructureModelo Modelo = default;
				ent2 = (Entity)(object)val;
				bool flag = XDataDispositivosMaster.LerXDataModelo(ref ent2, ref Modelo);
				val = (BlockReference)ent2;
				if (flag && !((DBObject)val).IsErased)
				{
					((DBObject)val).UpgradeOpen();
					((DBObject)val).Erase();
				}
			}
			DBObject dBObject3 = P_1.DBObject;
			DBText val2 = (DBText)(object)((dBObject3 is DBText) ? dBObject3 : null);
			if (val2 != null)
			{
				DeclaracoesEntidades.StructureDefinicaoPortas Def = default;
				Entity ent2 = (Entity)(object)val2;
				bool flag = XDataDispositivosMaster.LerXDataDefinicao(ref ent2, ref Def);
				val2 = (DBText)ent2;
				if (flag)
				{
					DeclaracoesGeral.bAnularEventos = true;
					clsPortas.IndefineUmaDefinicao(((object)((DBObject)val2).Handle/*cast due to constrained. prefix*/).ToString());
				}
				int Tipo = 0;
				ent2 = (Entity)(object)val2;
				flag = clsEditaTitulosTextos.LeXDataTitulo(ref ent2, ref Tipo);
				val2 = (DBText)ent2;
				if (flag)
				{
					Correcao.LimpaXData((Entity)(object)val2, "DiagLog");
				}
				if (val2 != null)
				{
					ent2 = (Entity)(object)val2;
					flag = XDataGeral.TemXData(ref ent2, "AUXINTERLIG");
					val2 = (DBText)ent2;
					if (!flag)
					{
						ent2 = (Entity)(object)val2;
						flag = XDataGeral.TemXData(ref ent2, "IMPORTADO");
						val2 = (DBText)ent2;
						if (!flag)
						{
							ent2 = (Entity)(object)val2;
							flag = XDataGeral.TemXData(ref ent2, "AUXIMPORTADO");
							val2 = (DBText)ent2;
							if (!flag)
							{
								ent2 = (Entity)(object)val2;
								flag = XDataGeral.TemXData(ref ent2, "AUXCONEXAO");
								val2 = (DBText)ent2;
								if (flag && !((DBObject)val2).IsErased)
								{
									((DBObject)val2).UpgradeOpen();
									((DBObject)val2).Erase();
								}
							}
							else if (!((DBObject)val2).IsErased)
							{
								((DBObject)val2).UpgradeOpen();
								((DBObject)val2).Erase();
							}
						}
						else if (!((DBObject)val2).IsErased)
						{
							((DBObject)val2).UpgradeOpen();
							((DBObject)val2).Erase();
						}
					}
					else if (!((DBObject)val2).IsErased)
					{
						((DBObject)val2).UpgradeOpen();
						((DBObject)val2).Erase();
					}
				}
			}
			DBObject dBObject4 = P_1.DBObject;
			MText val3 = (MText)(object)((dBObject4 is MText) ? dBObject4 : null);
			if (val3 != null)
			{
				Entity ent2 = (Entity)(object)val3;
				bool flag = XDataGeral.TemXData(ref ent2, "TextoLP");
				val3 = (MText)ent2;
				if (!flag)
				{
					ent2 = (Entity)(object)val3;
					flag = XDataGeral.TemXData(ref ent2, "IMPORTADO");
					val3 = (MText)ent2;
					if (flag && !((DBObject)val3).IsErased)
					{
						((DBObject)val3).UpgradeOpen();
						((DBObject)val3).Erase();
					}
				}
				else
				{
					Correcao.LimpaXData((Entity)(object)val3, "TextoLP");
				}
			}
			DBObject dBObject5 = P_1.DBObject;
			Polyline pl = (Polyline)(object)((dBObject5 is Polyline) ? dBObject5 : null);
			if (pl != null)
			{
				DeclaracoesEntidades.StructureInterligacao ilig = default;
				if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) && !((DBObject)pl).IsErased)
				{
					((DBObject)pl).UpgradeOpen();
					((DBObject)pl).Erase();
				}
				DeclaracoesEntidades.StructureConexao conex = default;
				if (XDataConexao.lerXDataConexao(ref pl, ref conex) && conex.Tipo != 0 && !((DBObject)pl).IsErased)
				{
					((DBObject)pl).UpgradeOpen();
					((DBObject)pl).Erase();
				}
			}
			DBObject dBObject6 = P_1.DBObject;
			Line val4 = (Line)(object)((dBObject6 is Line) ? dBObject6 : null);
			if (val4 != null)
			{
				DeclaracoesEntidades.StructureConexao structureConexao = default;
				Entity ent2 = (Entity)(object)val4;
				bool flag = XDataGeral.TemXData(ref ent2, "CONEXAO");
				val4 = (Line)ent2;
				if (!flag)
				{
					ent2 = (Entity)(object)val4;
					flag = XDataGeral.TemXData(ref ent2, "INTERLIGACAO");
					val4 = (Line)ent2;
					if (flag)
					{
						Correcao.LimpaXData((Entity)(object)val4, "INTERLIGACAO");
					}
				}
				else
				{
					Correcao.LimpaXData((Entity)(object)val4, "CONEXAO");
				}
			}
			if (P_1.DBObject.IsErased)
			{
				return;
			}
			DBObject dBObject7 = P_1.DBObject;
			Entity val5 = (Entity)(object)((dBObject7 is Entity) ? dBObject7 : null);
			if (val5 != null && !((DBObject)val5).IsErased && !Information.IsNothing(((DBObject)val5).XData))
			{
				string sValor = clsTextos.TiraNothing(((DBObject)val5).XData.ToString());
				if (XDataGeral.TemXdataEletron(sValor) && !clsBlocos.VerificaDocumetoValidoParaColar())
				{
					((DBObject)val5).UpgradeOpen();
					((DBObject)val5).Erase();
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void onDBModifiedEvent(object sender, ObjectEventArgs e)
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected Obj, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected Obj, but got Unknown
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected Obj, but got Unknown
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected Obj, but got Unknown
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected Obj, but got Unknown
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected Obj, but got Unknown
		if (Operators.CompareString(((object)e.DBObject).ToString(), "ZwSoft.ZwCAD.DatabaseServices.ImpDBObject", TextCompare: true) == 0 || Operators.CompareString(((object)e.DBObject).ToString(), "ZwSoft.ZwCAD.DatabaseServices.LayertableRecord", TextCompare: true) == 0 || DeclaracoesGeral.bSuspenderEvento || DeclaracoesGeral.bAnularEventos || DeclaracoesGeral.bSuspenderEventoExpImpClonar)
		{
			return;
		}
		try
		{
			string text = "";
			DBObject dBObject = e.DBObject;
			BlockReference val = (BlockReference)(object)((dBObject is BlockReference) ? dBObject : null);
			if (val == null || ((DBObject)val).XData == (ResultBuffer)null)
			{
				return;
			}
			bool flag = false;
			Entity ent = (Entity)(object)val;
			string tipoImportado = "";
			string text2 = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
			val = (BlockReference)ent;
			text = text2;
			string left = text;
			if (Operators.CompareString(left, "A", TextCompare: true) != 0 && Operators.CompareString(left, "B", TextCompare: true) != 0 && Operators.CompareString(left, "E", TextCompare: true) != 0 && Operators.CompareString(left, "P", TextCompare: true) != 0 && Operators.CompareString(left, "I", TextCompare: true) != 0)
			{
				DeclaracoesTopografico.structureDispTopografico dTpg = default;
				if (!XDataTopografico.lerXDataDispTopografico(ref val, ref dTpg))
				{
					DeclaracoesInterligacao.borneAranha bn = default;
					if (!XDataAranha.LerXDataBorne(ref val, ref bn))
					{
						string revisao = "";
						int painel = 0;
						DeclaracoesInterligacao.caboAranha cabo = default;
						ent = (Entity)(object)val;
						bool flag2 = XDataAranha.LerXDataCabo(ref ent, ref revisao, ref painel, ref cabo);
						val = (BlockReference)ent;
						if (!flag2)
						{
							ent = (Entity)(object)val;
							object oValor = "";
							flag2 = XDataLeitura.lexDataDaEntity1(ref ent, "ARANHA", 0, ref oValor);
							val = (BlockReference)ent;
							if (!flag2)
							{
								if (!XDataDInterlig.LerXDataBorne(ref val, ref bn))
								{
									ent = (Entity)(object)val;
									flag2 = XDataDInterlig.LerXDataCabo(ref ent, ref revisao, ref painel, ref cabo);
									val = (BlockReference)ent;
									if (!flag2)
									{
										if (!XDataDIEnergisa.LerXDataBorne(ref val, ref bn))
										{
											ent = (Entity)(object)val;
											flag2 = XDataDIEnergisa.LerXDataCabo(ref ent, ref revisao, ref painel, ref cabo);
											val = (BlockReference)ent;
											if (flag2)
											{
												flag = true;
											}
										}
										else
										{
											flag = true;
										}
									}
									else
									{
										flag = false;
										Declaracoes2.bMirrorAtivo = false;
										Declaracoes2.bCancelaMirror = false;
									}
								}
								else
								{
									flag = true;
								}
							}
							else
							{
								flag = false;
								Declaracoes2.bMirrorAtivo = false;
								Declaracoes2.bCancelaMirror = false;
							}
						}
						else
						{
							flag = true;
						}
					}
					else
					{
						flag = true;
					}
				}
				else
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				if (Declaracoes2.bMirrorAtivo)
				{
					Declaracoes2.bCancelaMirror = true;
					return;
				}
				if (Declaracoes2.bRotateAtivo && val.Rotation != 0.0)
				{
					Declaracoes2.bCanselaRotate = true;
					return;
				}
				if (Declaracoes2.bScaleAtivo)
				{
					Scale3d scaleFactors = val.ScaleFactors;
					bool flag3 = scaleFactors.X != 1.0;
					scaleFactors = val.ScaleFactors;
					bool num = flag3 | (scaleFactors.Y != 1.0);
					scaleFactors = val.ScaleFactors;
					if (num | (scaleFactors.Z != 1.0))
					{
						Declaracoes2.bCancelaScale = true;
						return;
					}
				}
			}
			ent = (Entity)(object)val;
			text2 = "";
			tipoImportado = XDataDispositivo.verificaTipoDispositivo(ref ent, ref text2);
			val = (BlockReference)ent;
			text = tipoImportado;
			string left2 = text;
			if (Operators.CompareString(left2, "P", TextCompare: true) != 0 && Operators.CompareString(left2, "A", TextCompare: true) == 0)
			{
				object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val);
				DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = ((obj == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj));
				Declaracoes2.StructureContatoAuxBobina cont = new Declaracoes2.StructureContatoAuxBobina
				{
					sHandleBobina = structureAuxiliar.HandleBob,
					iIndiceModelo = structureAuxiliar.IndexModelo,
					iIndiceContato = structureAuxiliar.IndexContato,
					iTipo = structureAuxiliar.TipoDoContato,
					sHandleContato = ((object)((DBObject)val).Handle/*cast due to constrained. prefix*/).ToString(),
					sTipoBlocoContato = Strings.Mid(val.Name, 5, 2)
				};
				clsDispositivoAuxiliares.AtualizaInsercaoTabela(ref cont, ref val);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void onObjectEraseded(object sender, ObjectErasedEventArgs e)
	{
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected Obj, but got Unknown
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0427: Unknown result type (might be due to invalid IL or missing references)
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Expected Obj, but got Unknown
		//IL_0523: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Unknown result type (might be due to invalid IL or missing references)
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0574: Unknown result type (might be due to invalid IL or missing references)
		//IL_057b: Expected Obj, but got Unknown
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Expected Obj, but got Unknown
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected Obj, but got Unknown
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(((object)e.DBObject).ToString(), "ZwSoft.ZwCAD.DatabaseServices.ImpDBObject", TextCompare: true) == 0 || Operators.CompareString(((object)e.DBObject).ToString(), "ZwSoft.ZwCAD.DatabaseServices.LayertableRecord", TextCompare: true) == 0 || DeclaracoesGeral.bSuspenderEvento || DeclaracoesGeral.bAnularEventos || DeclaracoesGeral.bSuspenderEventoExpImpClonar)
		{
			return;
		}
		try
		{
			DBObject dBObject = e.DBObject;
			BlockReference val = (BlockReference)(object)((dBObject is BlockReference) ? dBObject : null);
			if (val != null && e.Erased)
			{
				Entity ent = (Entity)(object)val;
				string tipoImportado = "";
				string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
				val = (BlockReference)ent;
				string text2 = text;
				bool flag = false;
				string left = text2;
				if (Operators.CompareString(left, "P", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left, "A", TextCompare: true) != 0)
					{
						if (Operators.CompareString(left, "B", TextCompare: true) != 0 && Operators.CompareString(left, "E", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left, "M", TextCompare: true) != 0)
							{
								flag = true;
							}
							else
							{
								clsMascara.ApagaAMascara((Entity)(object)val);
							}
						}
					}
					else
					{
						clsDispositivoAuxiliares.limpaInsercaoTabela(((object)((DBObject)val).Handle/*cast due to constrained. prefix*/).ToString());
					}
				}
				else
				{
					object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val);
					if (((obj == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj)).indexModelo <= 0)
					{
						clsDispositivo.promoveComplementar((Entity)(object)val);
					}
					else
					{
						clsDispositivo.ApagaContatosModeloDispositivo((Entity)(object)val);
					}
				}
				string Handle;
				int painel2;
				bool flag2;
				if (flag)
				{
					string revisao = "";
					int painel = 0;
					DeclaracoesInterligacao.caboAranha cabo = default;
					ent = (Entity)(object)val;
					flag2 = XDataAranha.LerXDataCabo(ref ent, ref revisao, ref painel, ref cabo);
					val = (BlockReference)ent;
					if (flag2)
					{
						ClsAranha.ApagaVeiasUmCabo(revisao, painel, cabo.Tag_Cabo);
					}
					ent = (Entity)(object)val;
					flag2 = XDataDInterlig.LerXDataCabo(ref ent, ref revisao, ref painel, ref cabo);
					val = (BlockReference)ent;
					if (flag2)
					{
						clsDInterlig.ApagaVeiasUmCabo(revisao, painel, cabo.Tag_Cabo);
					}
					painel2 = 0;
					text = "";
					tipoImportado = "";
					Handle = "";
					if (XDataLayout.lerXDataDispLayout(ref val, ref painel2, ref text, ref tipoImportado, ref Handle))
					{
						clsLayoutMec.ApagaTextoDisp(((object)((DBObject)val).Handle/*cast due to constrained. prefix*/).ToString());
					}
				}
				int painel3 = 0;
				string tag = "";
				string alternativo = "";
				Handle = "";
				if (XDataLayout.lerXDataDispLayout(ref val, ref painel3, ref tag, ref alternativo, ref Handle))
				{
					Form form = Application.OpenForms["frmLayoutMec"];
					if (!Information.IsNothing(form))
					{
						frmLayoutMec frmLayoutMec2 = (frmLayoutMec)form;
						frmLayoutMec2.AtualizaDGDispInseridos(painel3, tag, alternativo);
					}
				}
				string regua = "";
				string borne = "";
				ent = (Entity)(object)val;
				painel2 = 0;
				flag2 = XDataLayout.lerXDataBorneLayout(ref ent, ref painel3, ref regua, ref borne, ref painel2);
				val = (BlockReference)ent;
				if (flag2)
				{
					Form form2 = Application.OpenForms["frmLayoutMec"];
					if (!Information.IsNothing(form2))
					{
						frmLayoutMec frmLayoutMec3 = (frmLayoutMec)form2;
						frmLayoutMec3.AtualizadgBornesInseridos(painel3, regua, borne);
					}
				}
				DeclaracoesTopografico.structureDispTopografico dTpg = default;
				if (XDataTopografico.lerXDataDispTopografico(ref val, ref dTpg))
				{
					clsTopografico.ApagaTerminaisDoBlocoApagado(((Entity)val).Layer, dTpg.tag, dTpg.alternativo);
					Form form3 = Application.OpenForms["frmTopografico"];
					if (!Information.IsNothing(form3))
					{
						frmTopografico frmTopografico2 = (frmTopografico)form3;
						frmTopografico2.AtualizaDGDispInseridos(dTpg);
					}
				}
				DeclaracoesTopografico.structureBorneTopografico bTpg = default;
				if (XDataTopografico.lerXDataBorneTopografico(ref val, ref bTpg))
				{
					Form form4 = Application.OpenForms["frmTopografico"];
					if (!Information.IsNothing(form4))
					{
						frmTopografico frmTopografico3 = (frmTopografico)form4;
						frmTopografico3.AtualizadgBornesInseridos(bTpg);
					}
				}
			}
			DBObject dBObject2 = e.DBObject;
			Polyline pl = (Polyline)(object)((dBObject2 is Polyline) ? dBObject2 : null);
			if (pl != null && e.Erased)
			{
				DeclaracoesEntidades.StructureConexao conex = default;
				if (XDataConexao.lerXDataConexao(ref pl, ref conex))
				{
					if ((conex.Tipo == 1) | (conex.Tipo == 4))
					{
						clsConexao.ApagarTextosAuxiliaresCircuito(((Entity)pl).Layer.ToString(), ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
					}
					clsConexao.ApagarDerivacoesLinhas(conex, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString(), ((Entity)pl).Layer);
					if ((conex.Tipo == 1) | (conex.Tipo == 4))
					{
						clsConexao.sincronizaCircuitos();
					}
				}
				DeclaracoesEntidades.StructureInterligacao ilig = default;
				if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
				{
					cDadosAccess.carregaDadosDWG();
					CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
					string Handle = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
					cDadosAccessInterligacao3.IndefineUmaVeiaDeUmCabo(ref Handle);
					cDadosAccessInterligacao3.FechaConexao();
					if (ilig.Tipo != 2)
					{
						clsInterligacao.ApagarTextosAuxiliaresVeias(((Entity)pl).Layer.ToString(), ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
					}
					else
					{
						clsInterligacao.ApagarPL(ilig.handle);
						clsInterligacao.ApagarTextosAuxiliaresVeias(((Entity)pl).Layer, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
					}
				}
			}
			DBObject dBObject3 = e.DBObject;
			DBText text3 = (DBText)(object)((dBObject3 is DBText) ? dBObject3 : null);
			if (text3 != null && e.Erased)
			{
				string handle = "";
				short tipo = default;
				if (XDataDispositivo.lerXDataDePara(ref text3, ref handle, ref tipo))
				{
					clsDePara.ApagarTextoDeParaCruzado(handle);
				}
				DeclaracoesEntidades.StructureDefinicaoPortas Def = default;
				Entity ent = (Entity)(object)text3;
				bool flag2 = XDataDispositivosMaster.LerXDataDefinicao(ref ent, ref Def);
				text3 = (DBText)ent;
				if (flag2)
				{
					clsPortas.ApagaUmaDefinicao(text3);
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}
}
