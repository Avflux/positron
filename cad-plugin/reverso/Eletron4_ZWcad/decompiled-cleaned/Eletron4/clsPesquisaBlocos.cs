using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.Runtime;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

public class clsPesquisaBlocos
{
	public struct mBlocos
	{
		public string sNome1;

		public string sNomeOriginal;

		public string sNome2;

		public string sTerminais;

		public string sAlternativo;

		public int iPainel;

		public string sPainel;

		public double dOrdem;

		public int ix;

		public int iy;

		public int iTipo;

		public double iPot;

		public string sTipo;

		public string sHandle;

		public bool bPinta;

		public string sBloco;

		public string sPagina;
	}

	public static void pesquisaElementosEletronNoDWG(string sNome1, string sNome2, string sAlternativo, bool P, bool A, bool B, bool M, bool E, bool bConexao, bool bCabo, bool bJumper, ref DataGridView dg, ref bool bNome2, ref bool bAlternativo)
	{
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected Obj, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected Obj, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected Obj, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected Obj, but got Unknown
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected Obj, but got Unknown
		//IL_0808: Unknown result type (might be due to invalid IL or missing references)
		//IL_080d: Unknown result type (might be due to invalid IL or missing references)
		//IL_096f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0976: Expected Obj, but got Unknown
		//IL_0e83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e8a: Expected Obj, but got Unknown
		//IL_1778: Unknown result type (might be due to invalid IL or missing references)
		//IL_177d: Unknown result type (might be due to invalid IL or missing references)
		//IL_179a: Unknown result type (might be due to invalid IL or missing references)
		//IL_179f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1555: Unknown result type (might be due to invalid IL or missing references)
		//IL_155a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1579: Unknown result type (might be due to invalid IL or missing references)
		//IL_157e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected Obj, but got Unknown
		//IL_048a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0491: Expected Obj, but got Unknown
		//IL_1252: Unknown result type (might be due to invalid IL or missing references)
		//IL_1257: Unknown result type (might be due to invalid IL or missing references)
		//IL_1276: Unknown result type (might be due to invalid IL or missing references)
		//IL_127b: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb8: Expected Obj, but got Unknown
		//IL_186a: Unknown result type (might be due to invalid IL or missing references)
		//IL_186f: Unknown result type (might be due to invalid IL or missing references)
		//IL_164b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1650: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Expected Obj, but got Unknown
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1065: Unknown result type (might be due to invalid IL or missing references)
		//IL_106a: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d8: Expected Obj, but got Unknown
		//IL_0b7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b82: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ce: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral._uscPagina.Quantidade = 14;
		DeclaracoesGeral._uscPagina.pbIniciar();
		DeclaracoesGeral._uscPagina.pbPasso();
		int num = 0;
		mBlocos[] array = new mBlocos[1];
		num = 1;
		int num2 = 0;
		mBlocos[] array2 = new mBlocos[1];
		num2 = 1;
		int num3 = 0;
		mBlocos[] array3 = new mBlocos[1];
		num3 = 1;
		int num4 = 0;
		mBlocos[] array4 = new mBlocos[1];
		num4 = 1;
		bNome2 = false;
		bAlternativo = false;
		DeclaracoesGeral.Reguas RH = default;
		bool flag = false;
		DeclaracoesGeral.Reguas RH2 = default;
		bool flag2 = false;
		flag = XDataGeral.LeXDataReguaH(ref RH);
		flag2 = XDataGeral.LeXDataReguaV(ref RH2);
		DeclaracoesGeral._uscPagina.pbPasso();
		checked
		{
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
							DeclaracoesEntidades.StructureDispositivo structureDispositivo = default;
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
								BlockReference blockRef = (BlockReference)(object)((ent is BlockReference) ? ent : null);
								if (blockRef == null)
								{
									Polyline pl = (Polyline)(object)((ent is Polyline) ? ent : null);
									if (pl == null)
									{
										DBText val5 = (DBText)(object)((ent is DBText) ? ent : null);
										if (val5 == null || !M)
										{
											continue;
										}
										DeclaracoesEntidades.StructureDefinicaoPortas Def = new DeclaracoesEntidades.StructureDefinicaoPortas
										{
											Nome = ""
										};
										Entity Ent = (Entity)(object)val5;
										XDataDispositivosMaster.LerXDataDefinicao(ref Ent, ref Def);
										val5 = (DBText)Ent;
										if (Operators.CompareString(Def.Nome.ToUpper(), "DEFINICAO", TextCompare: true) != 0)
										{
											continue;
										}
										_ = Def.HandleDaMascara + "_" + Conversions.ToString(Def.indiceDoModelo) + "_" + Conversions.ToString(Def.indiceDaPorta);
										Entity val6 = (Entity)Geral.HandleToObject(Def.HandleDaMascara);
										if (val6 != null)
										{
											BlockReference blockRef2 = (BlockReference)val6;
											object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
											val6 = (Entity)(object)blockRef2;
											object obj2 = obj;
											DeclaracoesEntidades.StructureMascara structureMascara = ((obj2 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj2));
											if (LikeOperator.LikeString(structureMascara.Nome1.ToUpper(), "*" + sNome1.ToUpper() + "*", CompareMethod.Text) & LikeOperator.LikeString(structureMascara.Nome2.ToUpper(), "*" + sNome2.ToUpper() + "*", CompareMethod.Text) & LikeOperator.LikeString(structureMascara.Alternativo.ToUpper(), "*" + sAlternativo.ToUpper() + "*", CompareMethod.Text))
											{
												array = (mBlocos[])Utils.CopyArray(array, new mBlocos[num + 1]);
												string text = clsTextos.TiraNothing(structureMascara.Nome1);
												array[num].sNome1 = text + "_2_" + Conversions.ToString(Def.indiceDaPorta);
												array[num].sNomeOriginal = text;
												array[num].sNome2 = clsTextos.TiraNothing(structureMascara.Nome2);
												array[num].sTipo = DeclaracoesGeral.mMensagem[1, 521].ToString().ToUpper();
												array[num].sBloco = "TEXTO";
												array[num].sPagina = Pagina.montaCruzamentoPagina(ent.Layer.ToString(), Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2));
												array[num].sAlternativo = structureMascara.Alternativo;
												array[num].iPainel = structureMascara.Painel;
												array[num].sPainel = Dicionario.BuscaNomeDoPainel(structureMascara.Painel);
												array[num].dOrdem = 5.0;
												array[num].sHandle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
												num++;
											}
										}
										continue;
									}
									DeclaracoesEntidades.StructureConexao conex = default;
									Point3d startPoint;
									if (!XDataConexao.lerXDataConexao(ref pl, ref conex))
									{
										DeclaracoesEntidades.StructureInterligacao ilig = default;
										if (!XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) || !bCabo)
										{
											continue;
										}
										array4 = (mBlocos[])Utils.CopyArray(array4, new mBlocos[num4 + 1]);
										array4[num4].sNome1 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 740]);
										if (Operators.CompareString(ilig.Tag_Cabo, "", TextCompare: true) != 0)
										{
											array4[num4].sNome1 = ilig.Tag_Cabo;
										}
										array4[num4].sNome2 = ilig.NomeVeia;
										array4[num4].sTerminais = Conversions.ToString(ilig.NumVeia);
										if (Operators.CompareString(ilig.NomeVeia, "", TextCompare: true) != 0)
										{
											array4[num4].sTerminais = ilig.NomeVeia;
										}
										array4[num4].sBloco = "POLYLINE";
										array4[num4].sPagina = Pagina.montaCruzamentoPagina(ent.Layer.ToString(), Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2));
										ref mBlocos reference = ref array4[num4];
										startPoint = ((Curve)pl).StartPoint;
										reference.ix = (int)Math.Round(startPoint.X);
										ref mBlocos reference2 = ref array4[num4];
										startPoint = ((Curve)pl).StartPoint;
										reference2.iy = (int)Math.Round(startPoint.Y);
										array4[num4].sAlternativo = "";
										array4[num4].iPot = ilig.NumVeia;
										if (ilig.NumVeia == 0)
										{
											array4[num4].iPot = 0.0;
										}
										if (ilig.NumVeia != -99)
										{
											if (ilig.NumVeia < -50)
											{
												array4[num4].iPot = (double)ilig.NumVeia + 50.0;
											}
										}
										else
										{
											array4[num4].iPot = 0.1;
										}
										if (array4[num4].iPot < 0.0)
										{
											array4[num4].iPot = array4[num4].iPot * -1.0;
											array4[num4].iPot = array4[num4].iPot + 0.1;
										}
										array4[num4].iPainel = ilig.Painel1;
										string text2 = "";
										string text3 = "";
										if (ilig.Painel1 > 0)
										{
											text2 = Dicionario.BuscaNomeDoPainel(ilig.Painel1);
										}
										if (ilig.Painel2 > 0)
										{
											text3 = Dicionario.BuscaNomeDoPainel(ilig.Painel2);
										}
										if (Operators.CompareString(text2, "", TextCompare: true) == 0)
										{
											if (Operators.CompareString(text3, "", TextCompare: true) != 0)
											{
												array4[num4].sPainel = text3;
											}
										}
										else
										{
											array4[num4].sPainel = text2;
											if (Operators.CompareString(text3, "", TextCompare: true) != 0)
											{
												ref string sPainel = ref array4[num4].sPainel;
												sPainel = sPainel + " / " + text3;
											}
										}
										array4[num4].bPinta = false;
										array4[num4].dOrdem = 20000.0;
										array4[num4].sTipo = DeclaracoesGeral.mMensagem[1, 1239].ToString().ToUpper();
										array4[num4].sHandle = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
										num4++;
										continue;
									}
									double num5 = 0.0;
									string sNome3 = "";
									string text4 = "";
									switch (conex.Tipo)
									{
									case 4:
										num5 = 0.3;
										text4 = DeclaracoesGeral.mMensagem[1, 703].ToString().ToUpper();
										sNome3 = DeclaracoesGeral.mMensagem[1, 703].ToString().ToUpper();
										goto IL_1470;
									case 1:
										text4 = DeclaracoesGeral.mMensagem[1, 175].ToString().ToUpper();
										num5 = 0.1;
										sNome3 = DeclaracoesGeral.mMensagem[1, 175].ToString().ToUpper();
										break;
									case 2:
										text4 = DeclaracoesGeral.mMensagem[1, 175].ToString().ToUpper() + " TT";
										num5 = 0.2;
										sNome3 = DeclaracoesGeral.mMensagem[1, 175].ToString().ToUpper() + " TT";
										break;
									case 3:
										{
											if (Operators.CompareString(conex.Jumper.ToUpper(), "JUMPER", TextCompare: true) != 0)
											{
												num5 = 3.11;
												text4 = DeclaracoesGeral.mMensagem[1, 1700].ToString().ToUpper();
												sNome3 = DeclaracoesGeral.mMensagem[1, 1700].ToString().ToUpper();
												break;
											}
											num5 = 0.31;
											text4 = DeclaracoesGeral.mMensagem[1, 1561].ToString().ToUpper();
											sNome3 = DeclaracoesGeral.mMensagem[1, 703].ToString().ToUpper();
											goto IL_1470;
										}
										IL_1470:
										if (bJumper)
										{
											array3 = (mBlocos[])Utils.CopyArray(array3, new mBlocos[num3 + 1]);
											array3[num3].sNomeOriginal = text4.ToString().ToUpper();
											array3[num3].sNome1 = sNome3;
											array3[num3].sNome2 = "";
											array3[num3].sTerminais = "POT: " + Conversions.ToString(conex.Potencial);
											array3[num3].iTipo = conex.Tipo;
											array3[num3].iPot = conex.Potencial;
											array3[num3].sBloco = "POLYLINE";
											array3[num3].sPagina = ent.Layer.ToString();
											ref mBlocos reference3 = ref array3[num3];
											startPoint = ((Curve)pl).StartPoint;
											reference3.ix = (int)Math.Round(startPoint.X);
											ref mBlocos reference4 = ref array3[num3];
											startPoint = ((Curve)pl).StartPoint;
											reference4.iy = (int)Math.Round(startPoint.Y);
											array3[num3].sAlternativo = "";
											array3[num3].iPainel = conex.Painel;
											array3[num3].sPainel = Dicionario.BuscaNomeDoPainel(conex.Painel);
											array3[num3].bPinta = false;
											array3[num3].dOrdem = (double)conex.Potencial + num5;
											if (Operators.CompareString(conex.Nome, "", TextCompare: true) == 0)
											{
												array3[num3].sNomeOriginal = text4.ToString().ToUpper();
											}
											else
											{
												array3[num3].sNomeOriginal = conex.Nome.ToString().ToUpper();
												array3[num3].iTipo = 1;
											}
											array3[num3].sTipo = text4;
											array3[num3].sHandle = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
											num3++;
										}
										continue;
									}
									if (bConexao)
									{
										array2 = (mBlocos[])Utils.CopyArray(array2, new mBlocos[num2 + 1]);
										array2[num2].sNomeOriginal = text4;
										array2[num2].sNome1 = sNome3;
										array2[num2].iTipo = conex.Tipo;
										array2[num2].iPot = conex.Potencial;
										array2[num2].sNome2 = "";
										array2[num2].sTerminais = "POT. " + Conversions.ToString(conex.Potencial);
										array2[num2].sBloco = "POLYLINE";
										array2[num2].sPagina = ent.Layer.ToString();
										ref mBlocos reference5 = ref array2[num2];
										startPoint = ((Curve)pl).StartPoint;
										reference5.ix = (int)Math.Round(startPoint.X);
										ref mBlocos reference6 = ref array2[num2];
										startPoint = ((Curve)pl).StartPoint;
										reference6.iy = (int)Math.Round(startPoint.Y);
										array2[num2].sAlternativo = "";
										array2[num2].iPainel = conex.Painel;
										array2[num2].sPainel = Dicionario.BuscaNomeDoPainel(conex.Painel);
										array2[num2].bPinta = false;
										array2[num2].dOrdem = (double)conex.Potencial + num5;
										if (Operators.CompareString(conex.Nome, "", TextCompare: true) == 0)
										{
											array2[num2].sNomeOriginal = DeclaracoesGeral.mMensagem[1, 175].ToString().ToUpper();
										}
										else
										{
											array2[num2].sNomeOriginal = conex.Nome;
											array2[num2].iTipo = 1;
										}
										array2[num2].sTipo = text4;
										array2[num2].sHandle = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
										num2++;
									}
									continue;
								}
								string tipoImportado = "";
								string text5 = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
								string left = text5;
								if (Operators.CompareString(left, "P", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left, "A", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left, "B", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left, "M", TextCompare: true) != 0)
											{
												if (Operators.CompareString(left, "E", TextCompare: true) != 0 || !E)
												{
													continue;
												}
												BlockReference blockRef2 = (BlockReference)ent;
												object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
												ent = (Entity)(object)blockRef2;
												object obj3 = obj;
												DeclaracoesEntidades.StructurePortas structurePortas = ((obj3 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj3));
												Entity val7 = (Entity)Geral.HandleToObject(structurePortas.HandleDaMascara);
												DeclaracoesEntidades.StructureMascara structureMascara2 = default;
												if (val7 == null)
												{
													continue;
												}
												bool flag3 = false;
												if (val7 == null)
												{
													flag3 = true;
												}
												else
												{
													blockRef2 = (BlockReference)val7;
													obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
													val7 = (Entity)(object)blockRef2;
													object obj4 = obj;
													structureMascara2 = ((obj4 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj4));
												}
												if (LikeOperator.LikeString(structureMascara2.Nome1.ToUpper(), "*" + sNome1.ToUpper() + "*", CompareMethod.Text) & LikeOperator.LikeString(structureMascara2.Nome2.ToUpper(), "*" + sNome2.ToUpper() + "*", CompareMethod.Text) & LikeOperator.LikeString(structureMascara2.Alternativo.ToUpper(), "*" + sAlternativo.ToUpper() + "*", CompareMethod.Text))
												{
													array = (mBlocos[])Utils.CopyArray(array, new mBlocos[num + 1]);
													string text6 = clsTextos.TiraNothing(structureMascara2.Nome1);
													array[num].sNome1 = text6 + "_1_" + Conversions.ToString(structurePortas.indiceDaPorta);
													array[num].sNomeOriginal = text6;
													array[num].sNome2 = clsTextos.TiraNothing(structureMascara2.Nome2);
													ref mBlocos reference7 = ref array[num];
													ObjectId ObjectId = ((DBObject)blockRef).ObjectId;
													tipoImportado = "";
													reference7.sTerminais = clsAtributos.LeTodosOsBornesOuTerminaisDeUmBloco(ref ObjectId, ref tipoImportado);
													array[num].sBloco = blockRef.Name.ToUpper();
													array[num].sPagina = Pagina.montaCruzamentoPagina(ent.Layer.ToString(), Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2));
													array[num].sAlternativo = structureMascara2.Alternativo;
													if (!flag3)
													{
														array[num].iPainel = structureMascara2.Painel;
														array[num].sPainel = Dicionario.BuscaNomeDoPainel(structureMascara2.Painel);
														array[num].bPinta = false;
													}
													else
													{
														array[num].iPainel = 0;
														array[num].sPainel = "";
														array[num].bPinta = true;
													}
													array[num].dOrdem = 0.0;
													array[num].sTipo = DeclaracoesGeral.mMensagem[1, 750].ToString().ToUpper();
													array[num].sHandle = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
													num++;
												}
											}
											else
											{
												if (!M)
												{
													continue;
												}
												BlockReference blockRef2 = (BlockReference)ent;
												object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
												ent = (Entity)(object)blockRef2;
												object obj5 = obj;
												DeclaracoesEntidades.StructureMascara structureMascara3 = ((obj5 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj5));
												if (LikeOperator.LikeString(structureMascara3.Nome1.ToUpper(), "*" + sNome1.ToUpper() + "*", CompareMethod.Text) & LikeOperator.LikeString(structureMascara3.Nome2.ToUpper(), "*" + sNome2.ToUpper() + "*", CompareMethod.Text) & LikeOperator.LikeString(structureMascara3.Alternativo.ToUpper(), "*" + sAlternativo.ToUpper() + "*", CompareMethod.Text))
												{
													array = (mBlocos[])Utils.CopyArray(array, new mBlocos[num + 1]);
													string text7 = clsTextos.TiraNothing(structureMascara3.Nome1);
													array[num].sNome1 = text7 + "_0";
													array[num].sNomeOriginal = text7;
													array[num].sNome2 = clsTextos.TiraNothing(structureMascara3.Nome2);
													array[num].sTerminais = "";
													array[num].sBloco = blockRef.Name.ToUpper();
													array[num].sPagina = Pagina.montaCruzamentoPagina(ent.Layer.ToString(), Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2));
													array[num].sAlternativo = structureMascara3.Alternativo;
													array[num].iPainel = structureMascara3.Painel;
													array[num].sPainel = Dicionario.BuscaNomeDoPainel(structureMascara3.Painel);
													array[num].dOrdem = 4.0;
													if (structureMascara3.Complementar)
													{
														array[num].sTipo = DeclaracoesGeral.mMensagem[1, 1698].ToString().ToUpper();
													}
													else
													{
														array[num].sTipo = DeclaracoesGeral.mMensagem[1, 524].ToString().ToUpper();
													}
													array[num].sHandle = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
													num++;
												}
											}
										}
										else
										{
											if (!B)
											{
												continue;
											}
											DeclaracoesEntidades.StructureBorne structureBorne = default;
											object obj6 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
											structureBorne = ((obj6 == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj6));
											short num6 = 0;
											num6 = (short)DicionarioBorne.BuscaPainelDoBorneNoDicionario(ref structureBorne.IndiceRegua, ref structureBorne.NomeRegua, ref structureBorne.Alternativo);
											string sPainel2 = Dicionario.BuscaNomeDoPainel(num6);
											if (LikeOperator.LikeString(structureBorne.NomeRegua.ToUpper(), "*" + sNome1.ToUpper() + "*", CompareMethod.Text) & LikeOperator.LikeString(structureBorne.Alternativo.ToUpper(), "*" + sAlternativo.ToUpper() + "*", CompareMethod.Text))
											{
												array = (mBlocos[])Utils.CopyArray(array, new mBlocos[num + 1]);
												string text8 = "";
												string text9 = "";
												int num7 = 6 - Strings.Len(structureBorne.Numero);
												for (int i = 1; i <= num7; i++)
												{
													text9 += "0";
												}
												text8 = text9 + structureBorne.Numero;
												array[num].sNome1 = structureBorne.NomeRegua + "-" + text8;
												array[num].sNomeOriginal = structureBorne.NomeRegua;
												array[num].sNome2 = "";
												ref mBlocos reference8 = ref array[num];
												ObjectId ObjectId = ((DBObject)blockRef).ObjectId;
												tipoImportado = "";
												reference8.sTerminais = clsAtributos.LeTodosOsBornesOuTerminaisDeUmBloco(ref ObjectId, ref tipoImportado);
												array[num].sBloco = blockRef.Name.ToUpper();
												array[num].sPagina = Pagina.montaCruzamentoPagina(ent.Layer.ToString(), Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2));
												array[num].sAlternativo = structureBorne.Alternativo;
												array[num].iPainel = num6;
												array[num].sPainel = sPainel2;
												array[num].bPinta = false;
												array[num].dOrdem = 3.0;
												array[num].sTipo = DeclaracoesGeral.mMensagem[1, 1429].ToString().ToUpper();
												array[num].sHandle = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
												num++;
											}
										}
									}
									else
									{
										if (!A)
										{
											continue;
										}
										DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = default;
										object obj7 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
										structureAuxiliar = ((obj7 == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj7));
										Entity val8 = (Entity)Geral.HandleToObject(structureAuxiliar.HandleBob);
										if (val8 == null)
										{
											continue;
										}
										bool flag4 = false;
										if (val8 == null)
										{
											flag4 = true;
										}
										else
										{
											BlockReference blockRef2 = (BlockReference)val8;
											object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
											val8 = (Entity)(object)blockRef2;
											object obj8 = obj;
											structureDispositivo = ((obj8 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj8));
										}
										if (LikeOperator.LikeString(structureAuxiliar.Nome1.ToUpper(), "*" + sNome1.ToUpper() + "*", CompareMethod.Text) & LikeOperator.LikeString(structureAuxiliar.Nome2.ToUpper(), "*" + sNome2.ToUpper() + "*", CompareMethod.Text) & LikeOperator.LikeString(structureAuxiliar.Alternativo.ToUpper(), "*" + sAlternativo.ToUpper() + "*", CompareMethod.Text))
										{
											array = (mBlocos[])Utils.CopyArray(array, new mBlocos[num + 1]);
											array[num].sNome1 = clsTextos.TiraNothing(structureAuxiliar.Nome1) + "_" + structureAuxiliar.IndexContato;
											array[num].sNomeOriginal = clsTextos.TiraNothing(structureAuxiliar.Nome1);
											array[num].sNome2 = clsTextos.TiraNothing(structureAuxiliar.Nome2);
											ref mBlocos reference9 = ref array[num];
											ObjectId ObjectId = ((DBObject)blockRef).ObjectId;
											tipoImportado = "";
											reference9.sTerminais = clsAtributos.LeTodosOsBornesOuTerminaisDeUmBloco(ref ObjectId, ref tipoImportado);
											array[num].sBloco = blockRef.Name.ToUpper();
											array[num].sPagina = Pagina.montaCruzamentoPagina(ent.Layer.ToString(), Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2));
											array[num].sAlternativo = structureAuxiliar.Alternativo;
											if (!flag4)
											{
												array[num].iPainel = structureDispositivo.Painel;
												array[num].sPainel = Dicionario.BuscaNomeDoPainel(structureDispositivo.Painel);
												array[num].bPinta = false;
											}
											else
											{
												array[num].iPainel = 0;
												array[num].sPainel = "";
												array[num].bPinta = true;
											}
											array[num].dOrdem = 2.0;
											array[num].sTipo = DeclaracoesGeral.mMensagem[1, 1699].ToString().ToUpper();
											array[num].sHandle = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
											num++;
										}
									}
								}
								else
								{
									if (!P)
									{
										continue;
									}
									DeclaracoesEntidades.StructureDispositivo structureDispositivo2 = default;
									object obj9 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									structureDispositivo2 = ((obj9 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj9));
									if (LikeOperator.LikeString(structureDispositivo2.Nome1.ToUpper(), "*" + sNome1.ToUpper() + "*", CompareMethod.Text) & LikeOperator.LikeString(structureDispositivo2.Nome2.ToUpper(), "*" + sNome2.ToUpper() + "*", CompareMethod.Text) & LikeOperator.LikeString(structureDispositivo2.Alternativo.ToUpper(), "*" + sAlternativo.ToUpper() + "*", CompareMethod.Text))
									{
										array = (mBlocos[])Utils.CopyArray(array, new mBlocos[num + 1]);
										string text10 = clsTextos.TiraNothing(structureDispositivo2.Nome1);
										array[num].sNome1 = text10 + "_0";
										array[num].sNomeOriginal = text10;
										array[num].sNome2 = clsTextos.TiraNothing(structureDispositivo2.Nome2);
										array[num].sAlternativo = structureDispositivo2.Alternativo;
										ref mBlocos reference10 = ref array[num];
										ObjectId ObjectId = ((DBObject)blockRef).ObjectId;
										tipoImportado = "";
										reference10.sTerminais = clsAtributos.LeTodosOsBornesOuTerminaisDeUmBloco(ref ObjectId, ref tipoImportado);
										array[num].sBloco = blockRef.Name.ToUpper();
										array[num].sPagina = Pagina.montaCruzamentoPagina(ent.Layer.ToString(), Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2));
										array[num].iPainel = structureDispositivo2.Painel;
										array[num].sPainel = Dicionario.BuscaNomeDoPainel(structureDispositivo2.Painel);
										array[num].dOrdem = 1.0;
										if (structureDispositivo2.Complementar)
										{
											array[num].sTipo = DeclaracoesGeral.mMensagem[1, 1698].ToString().ToUpper();
										}
										else
										{
											array[num].sTipo = DeclaracoesGeral.mMensagem[1, 1697].ToString().ToUpper();
										}
										array[num].sHandle = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
										num++;
									}
								}
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						DeclaracoesGeral._uscPagina.pbPasso();
						int num8 = Information.UBound(array2);
						for (int j = 1; j <= num8; j++)
						{
							if (array2[j].iTipo != 3)
							{
								continue;
							}
							int num9 = Information.UBound(array2);
							for (int k = 1; k <= num9; k++)
							{
								if (array2[k].iTipo == 1 && array2[j].iPot == array2[k].iPot)
								{
									array2[j].sNome1 = array2[k].sNomeOriginal.ToString().ToUpper();
									break;
								}
							}
						}
						DeclaracoesGeral._uscPagina.pbPasso();
						int num10 = Information.UBound(array4);
						for (int l = 1; l <= num10; l++)
						{
							if (array4[l].iTipo != 3)
							{
								continue;
							}
							int num11 = Information.UBound(array4);
							for (int m = 1; m <= num11; m++)
							{
								if (array4[m].iTipo == 1 && array4[l].iPot == array4[m].iPot)
								{
									array4[l].sNome1 = array4[m].sNomeOriginal.ToString().ToUpper();
									break;
								}
							}
						}
						DeclaracoesGeral._uscPagina.pbPasso();
						if (Information.UBound(array) >= 2)
						{
							int num12 = Information.UBound(array);
							for (int n = 1; n <= num12; n++)
							{
								array[n].ix = 0;
								array[n].iy = 0;
								int num13 = Information.UBound(array) - 1;
								int num14 = n;
								for (int num15 = num13; num15 >= num14; num15 += -1)
								{
									if (array[num15].iPainel > array[num15 + 1].iPainel)
									{
										mBlocos mBlocos2 = array[num15 + 1];
										array[num15 + 1] = array[num15];
										array[num15] = mBlocos2;
									}
									if (array[num15].iPainel == array[num15 + 1].iPainel && Operators.CompareString(array[num15].sNome1, array[num15 + 1].sNome1, TextCompare: true) > 0 && ((Operators.CompareString(array[num15].sNomeOriginal, "#COEX#", TextCompare: true) != 0) & (Operators.CompareString(array[num15 + 1].sNomeOriginal, "#COEX#", TextCompare: true) != 0)))
									{
										mBlocos mBlocos2 = array[num15 + 1];
										array[num15 + 1] = array[num15];
										array[num15] = mBlocos2;
									}
									if (array[num15].iPainel == array[num15 + 1].iPainel && Operators.CompareString(array[num15].sNomeOriginal, array[num15 + 1].sNomeOriginal, TextCompare: true) == 0 && Operators.CompareString(array[num15].sNome2, array[num15 + 1].sNome2, TextCompare: true) > 0)
									{
										mBlocos mBlocos2 = array[num15 + 1];
										array[num15 + 1] = array[num15];
										array[num15] = mBlocos2;
									}
									if (array[num15].iPainel == array[num15 + 1].iPainel && Operators.CompareString(array[num15].sNomeOriginal, array[num15 + 1].sNomeOriginal, TextCompare: true) == 0 && Operators.CompareString(array[num15].sNome2, array[num15 + 1].sNome2, TextCompare: true) == 0 && ((Operators.CompareString(array[num15].sTipo, "PORTA", TextCompare: true) == 0) & (Operators.CompareString(array[num15 + 1].sTipo, "PORTA", TextCompare: true) == 0)) && clsTextos.RetornaPrimeiroTerminal(array[num15].sTerminais) > clsTextos.RetornaPrimeiroTerminal(array[num15 + 1].sTerminais))
									{
										mBlocos mBlocos2 = array[num15 + 1];
										array[num15 + 1] = array[num15];
										array[num15] = mBlocos2;
									}
									if (array[num15].iPainel == array[num15 + 1].iPainel && Operators.CompareString(array[num15].sNome1, array[num15 + 1].sNome1, TextCompare: true) == 0 && Operators.CompareString(array[num15].sNome2, array[num15 + 1].sNome2, TextCompare: true) > 0)
									{
										mBlocos mBlocos2 = array[num15 + 1];
										array[num15 + 1] = array[num15];
										array[num15] = mBlocos2;
									}
									if (array[num15].iPainel == array[num15 + 1].iPainel && Operators.CompareString(array[num15].sNome1, array[num15 + 1].sNome1, TextCompare: true) == 0 && Operators.CompareString(array[num15].sNome2, array[num15 + 1].sNome2, TextCompare: true) == 0 && Operators.CompareString(array[num15].sAlternativo, array[num15 + 1].sAlternativo, TextCompare: true) > 0)
									{
										mBlocos mBlocos2 = array[num15 + 1];
										array[num15 + 1] = array[num15];
										array[num15] = mBlocos2;
									}
									if (array[num15].iPainel == array[num15 + 1].iPainel && Operators.CompareString(array[num15].sNome1, array[num15 + 1].sNome1, TextCompare: true) == 0 && Operators.CompareString(array[num15].sNome2, array[num15 + 1].sNome2, TextCompare: true) == 0 && Operators.CompareString(array[num15].sAlternativo, array[num15 + 1].sAlternativo, TextCompare: true) == 0 && array[num15].dOrdem > array[num15 + 1].dOrdem)
									{
										mBlocos mBlocos2 = array[num15 + 1];
										array[num15 + 1] = array[num15];
										array[num15] = mBlocos2;
									}
									if (array[num15].iPainel == array[num15 + 1].iPainel && Operators.CompareString(array[num15].sNome1, array[num15 + 1].sNome1, TextCompare: true) == 0 && Operators.CompareString(array[num15].sNome2, array[num15 + 1].sNome2, TextCompare: true) == 0 && Operators.CompareString(array[num15].sAlternativo, array[num15 + 1].sAlternativo, TextCompare: true) == 0 && array[num15].dOrdem == array[num15 + 1].dOrdem && Operators.CompareString(array[num15].sTipo, array[num15 + 1].sTipo, TextCompare: true) > 0)
									{
										mBlocos mBlocos2 = array[num15 + 1];
										array[num15 + 1] = array[num15];
										array[num15] = mBlocos2;
									}
								}
							}
						}
						DeclaracoesGeral._uscPagina.pbPasso();
						if (bConexao && Information.UBound(array2) >= 2 && Information.UBound(array2) > 0)
						{
							int num16 = Information.UBound(array2);
							for (int num17 = 1; num17 <= num16; num17++)
							{
								int num18 = Information.UBound(array2) - 1;
								int num19 = num17;
								for (int num20 = num18; num20 >= num19; num20 += -1)
								{
									if (array2[num20].iPainel > array2[num20 + 1].iPainel)
									{
										mBlocos mBlocos2 = array2[num20 + 1];
										array2[num20 + 1] = array2[num20];
										array2[num20] = mBlocos2;
									}
									if (array2[num20].iPainel == array2[num20 + 1].iPainel && array2[num20].iPot > array2[num20 + 1].iPot)
									{
										mBlocos mBlocos2 = array2[num20 + 1];
										array2[num20 + 1] = array2[num20];
										array2[num20] = mBlocos2;
									}
									if (array2[num20].iPainel == array2[num20 + 1].iPainel && array2[num20].iPot == array2[num20 + 1].iPot && Operators.CompareString(array2[num20].sPagina, array2[num20 + 1].sPagina, TextCompare: true) > 0)
									{
										mBlocos mBlocos2 = array2[num20 + 1];
										array2[num20 + 1] = array2[num20];
										array2[num20] = mBlocos2;
									}
									if (array2[num20].iPainel == array2[num20 + 1].iPainel && array2[num20].iPot == array2[num20 + 1].iPot && Operators.CompareString(array2[num20].sPagina, array2[num20 + 1].sPagina, TextCompare: true) == 0 && Operators.CompareString(array2[num20].sTipo, array2[num20 + 1].sTipo, TextCompare: true) > 0)
									{
										mBlocos mBlocos2 = array2[num20 + 1];
										array2[num20 + 1] = array2[num20];
										array2[num20] = mBlocos2;
									}
									if (array2[num20].iPainel == array2[num20 + 1].iPainel && array2[num20].iPot == array2[num20 + 1].iPot && Operators.CompareString(array2[num20].sPagina, array2[num20 + 1].sPagina, TextCompare: true) == 0 && Operators.CompareString(array2[num20].sTipo, array2[num20 + 1].sTipo, TextCompare: true) == 0 && array2[num20].dOrdem > array2[num20 + 1].dOrdem)
									{
										mBlocos mBlocos2 = array2[num20 + 1];
										array2[num20 + 1] = array2[num20];
										array2[num20] = mBlocos2;
									}
									if (array2[num20].iPainel == array2[num20 + 1].iPainel && array2[num20].iPot == array2[num20 + 1].iPot && Operators.CompareString(array2[num20].sPagina, array2[num20 + 1].sPagina, TextCompare: true) == 0 && Operators.CompareString(array2[num20].sTipo, array2[num20 + 1].sTipo, TextCompare: true) == 0 && array2[num20].dOrdem == array2[num20 + 1].dOrdem && array2[num20].iy > array2[num20 + 1].iy)
									{
										mBlocos mBlocos2 = array2[num20 + 1];
										array2[num20 + 1] = array2[num20];
										array2[num20] = mBlocos2;
									}
									if (array2[num20].iPainel == array2[num20 + 1].iPainel && array2[num20].iPot == array2[num20 + 1].iPot && Operators.CompareString(array2[num20].sPagina, array2[num20 + 1].sPagina, TextCompare: true) == 0 && Operators.CompareString(array2[num20].sTipo, array2[num20 + 1].sTipo, TextCompare: true) == 0 && array2[num20].dOrdem == array2[num20 + 1].dOrdem && array2[num20].iy == array2[num20 + 1].iy && array2[num20].ix > array2[num20 + 1].ix)
									{
										mBlocos mBlocos2 = array2[num20 + 1];
										array2[num20 + 1] = array2[num20];
										array2[num20] = mBlocos2;
									}
								}
							}
						}
						DeclaracoesGeral._uscPagina.pbPasso();
						if (bJumper && Information.UBound(array3) >= 2 && Information.UBound(array3) > 0)
						{
							int num21 = Information.UBound(array3);
							for (int num22 = 1; num22 <= num21; num22++)
							{
								int num23 = Information.UBound(array3) - 1;
								int num24 = num22;
								for (int num25 = num23; num25 >= num24; num25 += -1)
								{
									if (Operators.CompareString(array3[num25].sPagina, array3[num25 + 1].sPagina, TextCompare: true) > 0)
									{
										mBlocos mBlocos2 = array3[num25 + 1];
										array3[num25 + 1] = array3[num25];
										array3[num25] = mBlocos2;
									}
									if (Operators.CompareString(array3[num25].sPagina, array3[num25 + 1].sPagina, TextCompare: true) == 0 && array3[num25].iPot > array3[num25 + 1].iPot)
									{
										mBlocos mBlocos2 = array3[num25 + 1];
										array3[num25 + 1] = array3[num25];
										array3[num25] = mBlocos2;
									}
									if (Operators.CompareString(array3[num25].sPagina, array3[num25 + 1].sPagina, TextCompare: true) == 0 && array3[num25].iPot == array3[num25 + 1].iPot && array3[num25].dOrdem > array3[num25 + 1].dOrdem)
									{
										mBlocos mBlocos2 = array3[num25 + 1];
										array3[num25 + 1] = array3[num25];
										array3[num25] = mBlocos2;
									}
									if (Operators.CompareString(array3[num25].sPagina, array3[num25 + 1].sPagina, TextCompare: true) == 0 && array3[num25].iPot == array3[num25 + 1].iPot && array3[num25].dOrdem == array3[num25 + 1].dOrdem && array3[num25].iy < array3[num25 + 1].iy)
									{
										mBlocos mBlocos2 = array3[num25 + 1];
										array3[num25 + 1] = array3[num25];
										array3[num25] = mBlocos2;
									}
									if (Operators.CompareString(array3[num25].sPagina, array3[num25 + 1].sPagina, TextCompare: true) == 0 && array3[num25].iPot == array3[num25 + 1].iPot && array3[num25].dOrdem == array3[num25 + 1].dOrdem && array3[num25].iy == array3[num25 + 1].iy && array3[num25].ix > array3[num25 + 1].ix)
									{
										mBlocos mBlocos2 = array3[num25 + 1];
										array3[num25 + 1] = array3[num25];
										array3[num25] = mBlocos2;
									}
								}
							}
						}
						DeclaracoesGeral._uscPagina.pbPasso();
						if (bCabo && Information.UBound(array4) >= 2 && Information.UBound(array4) > 0)
						{
							int num26 = Information.UBound(array4);
							for (int num27 = 1; num27 <= num26; num27++)
							{
								int num28 = Information.UBound(array4) - 1;
								int num29 = num27;
								for (int num30 = num28; num30 >= num29; num30 += -1)
								{
									if (Operators.CompareString(array4[num30].sNome1.ToString().ToUpper(), array4[num30 + 1].sNome1.ToString().ToUpper(), TextCompare: true) > 0)
									{
										mBlocos mBlocos2 = array4[num30 + 1];
										array4[num30 + 1] = array4[num30];
										array4[num30] = mBlocos2;
									}
									if (Operators.CompareString(array4[num30].sNome1.ToString().ToUpper(), array4[num30 + 1].sNome1.ToString().ToUpper(), TextCompare: true) == 0 && array4[num30].iPot > array4[num30 + 1].iPot)
									{
										mBlocos mBlocos2 = array4[num30 + 1];
										array4[num30 + 1] = array4[num30];
										array4[num30] = mBlocos2;
									}
								}
							}
						}
						DeclaracoesGeral._uscPagina.pbPasso();
						int num31 = Information.UBound(array);
						for (int num32 = 1; num32 <= num31; num32++)
						{
							array[num32].sPagina = array[num32].sPagina.Replace("(", "");
							array[num32].sPagina = array[num32].sPagina.Replace(")", "");
							if (Operators.CompareString(clsTextos.TiraNothing(array[num32].sNomeOriginal), "", TextCompare: true) != 0)
							{
								array[num32].sNome1 = array[num32].sNomeOriginal.ToString().ToUpper();
							}
							dg.Rows.Add(array[num32].sNome1, array[num32].sNome2, array[num32].sAlternativo, array[num32].sTerminais, array[num32].sPainel, array[num32].sTipo, array[num32].sHandle, array[num32].sBloco, array[num32].sPagina, array[num32].iPot, array[num32].ix, array[num32].iy);
						}
						DeclaracoesGeral._uscPagina.pbPasso();
						if (bConexao)
						{
							int num33 = Information.UBound(array2);
							for (int num34 = 1; num34 <= num33; num34++)
							{
								array2[num34].sPagina = array2[num34].sPagina.Replace("(", "");
								array2[num34].sPagina = array2[num34].sPagina.Replace(")", "");
								string[] array5 = array2[num34].sPagina.Split('/');
								array2[num34].sPagina = array5[0];
								if (Operators.CompareString(clsTextos.TiraNothing(array2[num34].sNomeOriginal), "", TextCompare: true) != 0)
								{
									array2[num34].sNome1 = array2[num34].sNomeOriginal.ToString().ToUpper();
								}
								dg.Rows.Add(array2[num34].sNome1, array2[num34].sNome2, array2[num34].sAlternativo, array2[num34].sTerminais, array2[num34].sPainel, array2[num34].sTipo, array2[num34].sHandle, array2[num34].sBloco, array2[num34].sPagina, array2[num34].iPot, array2[num34].ix, array2[num34].iy);
							}
						}
						DeclaracoesGeral._uscPagina.pbPasso();
						if (bJumper)
						{
							int num35 = Information.UBound(array3);
							for (int num36 = 1; num36 <= num35; num36++)
							{
								array3[num36].sPagina = array3[num36].sPagina.Replace("(", "");
								array3[num36].sPagina = array3[num36].sPagina.Replace(")", "");
								string[] array6 = array3[num36].sPagina.Split('/');
								array3[num36].sPagina = array6[0];
								if (Operators.CompareString(clsTextos.TiraNothing(array3[num36].sNomeOriginal), "", TextCompare: true) != 0)
								{
									array3[num36].sNome1 = array3[num36].sNomeOriginal;
								}
								dg.Rows.Add(array3[num36].sNome1, array3[num36].sNome2, array3[num36].sAlternativo, array3[num36].sTerminais, array3[num36].sPainel, array3[num36].sTipo, array3[num36].sHandle, array3[num36].sBloco, array3[num36].sPagina, array3[num36].iPot, array3[num36].ix, array3[num36].iy);
							}
						}
						DeclaracoesGeral._uscPagina.pbPasso();
						if (bCabo)
						{
							int num37 = Information.UBound(array4);
							for (int num38 = 1; num38 <= num37; num38++)
							{
								array4[num38].sPagina = clsTextos.TiraNothing(array4[num38].sPagina);
								array4[num38].sPagina = array4[num38].sPagina.Replace("(", "");
								array4[num38].sPagina = array4[num38].sPagina.Replace(")", "");
								string[] array7 = array4[num38].sPagina.Split('/');
								array4[num38].sPagina = array7[0];
								string text11 = "";
								text11 = ((Operators.CompareString(array4[num38].sNome1.ToString().ToUpper(), DeclaracoesGeral.mMensagem[1, 740].ToString().ToUpper(), TextCompare: true) == 0) ? array4[num38].sNome1.ToString().ToUpper() : array4[num38].sNome1.ToString().ToUpper());
								dg.Rows.Add(text11, "", array4[num38].sAlternativo, array4[num38].sTerminais, array4[num38].sPainel, array4[num38].sTipo, array4[num38].sHandle, array4[num38].sBloco, array4[num38].sPagina, array4[num38].iPot, array4[num38].ix, array4[num38].iy);
							}
						}
						DeclaracoesGeral._uscPagina.pbPasso();
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
						if (dg.RowCount != 0)
						{
							Conversions.ToString(1);
							bool flag5 = false;
							sNome1 = clsTextos.TiraNothing(Conversions.ToString(dg.Rows[0].Cells[0].Value));
							sNome2 = clsTextos.TiraNothing(Conversions.ToString(dg.Rows[0].Cells[1].Value));
							sAlternativo = clsTextos.TiraNothing(Conversions.ToString(dg.Rows[0].Cells[2].Value));
							clsTextos.TiraNothing(Conversions.ToString(dg.Rows[0].Cells[3].Value));
							int num39 = dg.RowCount - 1;
							for (int num40 = 0; num40 <= num39; num40++)
							{
								if (!((Operators.CompareString(dg.Rows[num40].Cells[0].Value.ToString(), sNome1, TextCompare: true) == 0) & (Operators.CompareString(dg.Rows[num40].Cells[1].Value.ToString(), sNome2, TextCompare: true) == 0) & (Operators.CompareString(dg.Rows[num40].Cells[2].Value.ToString(), sAlternativo, TextCompare: true) == 0)))
								{
									flag5 = !flag5;
									sNome1 = Conversions.ToString(dg.Rows[num40].Cells[0].Value);
									sNome2 = Conversions.ToString(dg.Rows[num40].Cells[1].Value);
									sAlternativo = Conversions.ToString(dg.Rows[num40].Cells[2].Value);
									Conversions.ToString(dg.Rows[num40].Cells[4].Value);
								}
								int num41 = 0;
								do
								{
									if (!flag5)
									{
										dg.Rows[num40].Cells[num41].Style.BackColor = Color.White;
										dg.Rows[num40].Cells[num41].Style.ForeColor = Color.Black;
									}
									else
									{
										dg.Rows[num40].Cells[num41].Style.BackColor = Color.LightGoldenrodYellow;
										dg.Rows[num40].Cells[num41].Style.ForeColor = Color.Black;
									}
									num41++;
								}
								while (num41 <= 8);
							}
							DeclaracoesGeral._uscPagina.pbPasso();
							int num42 = dg.RowCount - 1;
							for (int num43 = 0; num43 <= num42; num43++)
							{
								if (Operators.CompareString(dg.Rows[num43].Cells[1].Value.ToString(), "", TextCompare: true) != 0)
								{
									bNome2 = true;
								}
								if (Operators.CompareString(dg.Rows[num43].Cells[2].Value.ToString(), "", TextCompare: true) != 0)
								{
									bAlternativo = true;
								}
								int num44 = Information.UBound(array);
								for (int num45 = 1; num45 <= num44; num45++)
								{
									if (((Operators.CompareString(dg.Rows[num43].Cells[0].Value.ToString(), array[num45].sNome1, TextCompare: true) == 0) & (Operators.CompareString(dg.Rows[num43].Cells[1].Value.ToString(), array[num45].sNome2, TextCompare: true) == 0) & (Operators.CompareString(dg.Rows[num43].Cells[2].Value.ToString(), array[num45].sAlternativo, TextCompare: true) == 0) & (Operators.CompareString(dg.Rows[num43].Cells[4].Value.ToString(), array[num45].sPainel, TextCompare: true) == 0)) && array[num45].bPinta)
									{
										int num46 = 0;
										do
										{
											dg.Rows[num43].Cells[num46].Style.BackColor = Color.LightCoral;
											dg.Rows[num43].Cells[num46].Style.ForeColor = Color.Black;
											num46++;
										}
										while (num46 <= 7);
									}
								}
							}
						}
						DeclaracoesGeral._uscPagina.pbFim();
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
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				throw;
			}
		}
	}

	public static void mostraBloco(string sHandle, int X = 0, int Y = 0)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected Obj, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		clsBlocos.Unhighlight();
		Application.UpdateScreen();
		_ = Application.DocumentManager.MdiActiveDocument.Editor;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Entity val4 = (Entity)Geral.HandleToObject(sHandle);
				try
				{
					if (val4 != null)
					{
						Pagina.AtivaPagina(val4.Layer);
						uscPaginas uscPagina = DeclaracoesGeral._uscPagina;
						Entity val5;
						string pag = (val5 = val4).Layer;
						uscPagina.ativaPaginaAtalho(ref pag);
						val5.Layer = pag;
						Caderno.ZEntity(((DBObject)val4).ObjectId, 50);
						val4.Highlight();
					}
				}
				finally
				{
					((IDisposable)val4)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				Application.UpdateScreen();
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

	public static void ApagaBloco(ref string sHandle)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Obj, but got Unknown
		_ = Application.DocumentManager.MdiActiveDocument.Editor;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Entity val4 = (Entity)Geral.HandleToObject(sHandle);
				try
				{
					if (val4 != null)
					{
						((DBObject)val4).UpgradeOpen();
						((DBObject)val4).Erase();
					}
				}
				finally
				{
					((IDisposable)val4)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				Application.UpdateScreen();
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

	public static void insereBlocoErroFiacao(string layer, double x, double y)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected Obj, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected Obj, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected Obj, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected Obj, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		string text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Cadgraph\\Eletron4\\";
		string text2 = "ErroFiacao";
		ApagaBlocoErroFiacao();
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		_ = Application.DocumentManager.MdiActiveDocument.Editor;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			ObjectId val = ObjectId.Null;
			BlockTable val2 = (BlockTable)topTransaction.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)1);
			if (!((SymbolTable)val2).Has(text2))
			{
				Database val4 = new Database(false, true);
				string text3 = text + text2 + ".dwg";
				val4.ReadDwgFile(text3, FileShare.Read, true, "");
				((DBObject)val2).UpgradeOpen();
				DeclaracoesGeral.bAnularEventos = true;
				val = database.Insert(text2, val4, false);
				((DisposableWrapper)val4).Dispose();
			}
			else
			{
				BlockTableRecord val5 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val2)[text2], (OpenMode)0);
				val = ((DBObject)val5).Id;
			}
			Point3d val6 = new Point3d(x, y, 0.0);
			BlockReference val7 = new BlockReference(val6, val);
			((Entity)val7).Layer = layer;
			val3.AppendEntity((Entity)(object)val7);
			DeclaracoesGeral.bAnularEventos = true;
			topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val7, true);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
			((IDisposable)topTransaction)?.Dispose();
		}
	}

	public static void ApagaBlocoErroFiacao()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)1);
					if (!((SymbolTable)val3).Has("ErroFiacao"))
					{
						return;
					}
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)["ErroFiacao"], (OpenMode)1);
					ObjectIdCollection blockReferenceIds = val4.GetBlockReferenceIds(true, true);
					foreach (object item in blockReferenceIds)
					{
						ObjectId val5 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						BlockReference val6 = (BlockReference)val2.GetObject(val5, (OpenMode)1, false, true);
						((DBObject)val6).Erase();
					}
					((DBObject)val4).Erase(true);
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
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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
