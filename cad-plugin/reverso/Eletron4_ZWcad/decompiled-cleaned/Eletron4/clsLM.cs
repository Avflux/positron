using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

public class clsLM
{
	public struct LModFab
	{
		public int indice;

		public string Modelo;

		public string Fabricante;

		public string DescricaoResumida;
	}

	public struct LMateriais
	{
		public string sTipo;

		public int Dwg;

		public int Painel;

		public string TagMat;

		public string TagAlternativo;

		public int indexModelo;

		public int IndiceMaterial;

		public int Quantidade;

		public long lOrdem;

		public long OrdemLay;

		public bool Avulso;

		public string sHandle;

		public int indexLM;
	}

	public struct mBornes
	{
		public int Painel;

		public string TagRegua;

		public string TagAlternativo;

		public int IndexReguaa;

		public int Tipo;

		public int IndiceMaterial;

		public int Quantidade;

		public int Ordemm;

		public int OrdemLay;

		public string sHandle;
	}

	public struct mDisp
	{
		public int Painel;

		public string TagMat;

		public string TagAlt;

		public int indexMaterial;

		public int indexeModelo;

		public int Quantidade;

		public int Ordemm;

		public int OrdemLay;

		public string sHandle;
	}

	public struct mPN
	{
		public int iPainel;

		public string sPainel;
	}

	public struct Ordem
	{
		public int iPainel;

		public string sTag;

		public int iOrdem;

		public int iIndice_LM;

		public int Quantidade;

		public int IndiceMaterial;

		public bool bEncontrado;
	}

	public static void CompilaListaDeMateriais()
	{
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected Obj, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Expected Obj, but got Unknown
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected Obj, but got Unknown
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected Obj, but got Unknown
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected Obj, but got Unknown
		//IL_053c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0543: Expected Obj, but got Unknown
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected Obj, but got Unknown
		//IL_062b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0630: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bb: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			try
			{
				bool flag = true;
				MsgBoxResult msgBoxResult = Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1229], "\r\n"), DeclaracoesGeral.mMensagem[1, 1230]), MsgBoxStyle.YesNoCancel, "Elétron");
				if (msgBoxResult == MsgBoxResult.Cancel)
				{
					return;
				}
				if (msgBoxResult == MsgBoxResult.No)
				{
					flag = false;
				}
				cDadosAccess.carregaDadosDWG();
				cDadosAccessMateriais cDadosAccessMateriais2 = new cDadosAccessMateriais();
				Ordem[] OrdemLM = new Ordem[1];
				if (flag)
				{
					cDadosAccessMateriais2.CarregaOrdemEmMateriais(ref OrdemLM);
				}
				cDadosAccessMateriais2.RemoveMateriaisLista(DeclaracoesGeral.arqAtivo.Indice);
				cDadosAccessMateriais2.fechaConexao();
				LMateriais[] mMateriais = new LMateriais[1];
				mBornes[] array = new mBornes[1];
				mDisp[] array2 = new mDisp[1];
				mDisp[] array3 = new mDisp[1];
				cDadosLM cDadosLM2 = new cDadosLM();
				cDadosLM2.AtualizaLMBaseadoNosDWGsCadastrados();
				cDadosLM2.fechaConexao();
				Declaracoes2.MModelosDeContatos[] array4 = null;
				array4 = new Declaracoes2.MModelosDeContatos[1];
				DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref array4);
				Declaracoes2.MModeloDeMascara[] mModelo = new Declaracoes2.MModeloDeMascara[1];
				DicionarioMascaras.LeOsModelosDeMascaras(ref mModelo, bComplementarModelo: true);
				Declaracoes2.StructureModeloDeReguas[] mModelo2 = new Declaracoes2.StructureModeloDeReguas[1];
				DicionarioReguas.LeOsModelosDeRegua(ref mModelo2);
				new List<int>();
				long num = 10000L;
				string text = "";
				int num2 = 0;
				DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
				try
				{
					Database database = Application.DocumentManager.MdiActiveDocument.Database;
					Transaction val2 = database.TransactionManager.StartTransaction();
					try
					{
						BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
						BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
						DeclaracoesGeral._uscPagina.Quantidade = clsBlocos.AcadObjectCount();
						DeclaracoesGeral._uscPagina.pbIniciar();
						int num3 = 0;
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val4.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								num3++;
								if (num3 == 100)
								{
									DeclaracoesGeral._uscPagina.pbPasso(num3);
									num3 = 0;
								}
								Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								if (val6 == null)
								{
									continue;
								}
								Entity ent = (Entity)(object)val6;
								string tipoImportado = "";
								string text2 = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
								val6 = (BlockReference)ent;
								string text3 = text2;
								string left = text3;
								BlockReference blockRef;
								object obj;
								if (Operators.CompareString(left, "B", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left, "P", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left, "M", TextCompare: true) != 0)
										{
											continue;
										}
										blockRef = (BlockReference)val5;
										obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
										val5 = (Entity)(object)blockRef;
										object obj2 = obj;
										DeclaracoesEntidades.StructureMascara structureMascara = ((obj2 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj2));
										if (structureMascara.Complementar)
										{
											continue;
										}
										int num4 = Information.UBound(mModelo);
										for (int i = 1; i <= num4; i++)
										{
											if (mModelo[i].iIndiceModelo == structureMascara.indexModelo)
											{
												structureMascara.iLM1 = (int)mModelo[i].iLM1;
												structureMascara.iLM2 = (int)mModelo[i].iLM2;
												break;
											}
										}
										num2 = Information.UBound(array3) + 1;
										array3 = (mDisp[])Utils.CopyArray(array3, new mDisp[num2 + 1]);
										array3[num2].Ordemm = (int)num;
										num++;
										array3[num2].Painel = structureMascara.Painel;
										array3[num2].Quantidade = 1;
										array3[num2].indexMaterial = structureMascara.iLM1;
										array3[num2].indexeModelo = structureMascara.indexModelo;
										text = structureMascara.Nome1;
										if (Operators.CompareString(structureMascara.Nome2, "", TextCompare: true) != 0)
										{
											text = structureMascara.Nome1 + "/" + structureMascara.Nome2;
										}
										array3[num2].TagMat = text;
										array3[num2].OrdemLay = BuscaOrdemEquipamento(structureMascara.Painel, text);
										array3[num2].TagAlt = structureMascara.Alternativo;
										array3[num2].sHandle = "";
										if (structureMascara.iLM2 > 0)
										{
											num2 = Information.UBound(array3) + 1;
											array3 = (mDisp[])Utils.CopyArray(array3, new mDisp[num2 + 1]);
											array3[num2].Ordemm = (int)num;
											num++;
											array3[num2].Painel = structureMascara.Painel;
											array3[num2].Quantidade = 1;
											array3[num2].indexMaterial = structureMascara.iLM2;
											array3[num2].indexeModelo = structureMascara.indexModelo;
											text = structureMascara.Nome1;
											if (Operators.CompareString(structureMascara.Nome2, "", TextCompare: true) != 0)
											{
												text = structureMascara.Nome1 + "/" + structureMascara.Nome2;
											}
											array3[num2].TagMat = text;
											array3[num2].OrdemLay = BuscaOrdemEquipamento(structureMascara.Painel, text);
											array3[num2].TagAlt = structureMascara.Alternativo;
											array3[num2].sHandle = "";
										}
										continue;
									}
									blockRef = (BlockReference)val5;
									obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									val5 = (Entity)(object)blockRef;
									object obj3 = obj;
									DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj3 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj3));
									if (structureDispositivo.Complementar)
									{
										continue;
									}
									if (structureDispositivo.indexModelo > 0)
									{
										int num5 = Information.UBound(array4);
										for (int j = 1; j <= num5; j++)
										{
											if (array4[j].iIndiceModelo == structureDispositivo.indexModelo)
											{
												structureDispositivo.iLM1 = array4[j].iLM1;
												structureDispositivo.iLM2 = array4[j].iLM2;
												break;
											}
										}
									}
									num2 = Information.UBound(array2) + 1;
									array2 = (mDisp[])Utils.CopyArray(array2, new mDisp[num2 + 1]);
									array2[num2].Ordemm = (int)num;
									num++;
									array2[num2].Painel = structureDispositivo.Painel;
									array2[num2].indexMaterial = structureDispositivo.iLM1;
									array2[num2].indexeModelo = structureDispositivo.indexModelo;
									array2[num2].Quantidade = 1;
									array2[num2].TagMat = "";
									array2[num2].sHandle = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
									text = structureDispositivo.Nome1;
									if (Operators.CompareString(structureDispositivo.Nome2, "", TextCompare: true) != 0)
									{
										text = structureDispositivo.Nome1 + "/" + structureDispositivo.Nome2;
									}
									array2[num2].TagMat = text;
									array2[num2].TagAlt = structureDispositivo.Alternativo;
									array2[num2].OrdemLay = BuscaOrdemEquipamento(structureDispositivo.Painel, text);
									if (structureDispositivo.iLM2 > 0)
									{
										num2 = Information.UBound(array2) + 1;
										array2 = (mDisp[])Utils.CopyArray(array2, new mDisp[num2 + 1]);
										array2[num2].Ordemm = (int)num;
										num++;
										array2[num2].Painel = structureDispositivo.Painel;
										array2[num2].Quantidade = 1;
										array2[num2].indexMaterial = structureDispositivo.iLM2;
										array2[num2].indexeModelo = structureDispositivo.indexModelo;
										text = structureDispositivo.Nome1;
										if (Operators.CompareString(structureDispositivo.Nome2, "", TextCompare: true) != 0)
										{
											text = structureDispositivo.Nome1 + "/" + structureDispositivo.Nome2;
										}
										array2[num2].TagMat = text;
										array2[num2].OrdemLay = BuscaOrdemEquipamento(structureDispositivo.Painel, text);
										array2[num2].TagAlt = structureDispositivo.Alternativo;
										array2[num2].sHandle = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
									}
									continue;
								}
								blockRef = (BlockReference)val5;
								obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								val5 = (Entity)(object)blockRef;
								object obj4 = obj;
								DeclaracoesEntidades.StructureBorne structureBorne = ((obj4 == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj4));
								bool flag2 = true;
								int num6 = Information.UBound(mModelo2);
								for (int k = 1; k <= num6; k++)
								{
									if (mModelo2[k].indexRegua == structureBorne.IndiceRegua)
									{
										structureBorne.NomeRegua = mModelo2[k].nomeRegua;
										structureBorne.Alternativo = mModelo2[k].nomeAlternativo;
										structureBorne.indexPainel = mModelo2[k].indexPainel;
										break;
									}
								}
								int num7 = Information.UBound(array);
								for (int l = 1; l <= num7; l++)
								{
									if (array[l].Painel == structureBorne.indexPainel && Operators.CompareString(array[l].TagRegua, structureBorne.NomeRegua, TextCompare: true) == 0 && array[l].Tipo == structureBorne.tipo && array[l].IndiceMaterial == structureBorne.lm)
									{
										array[l].Quantidade++;
										flag2 = false;
										break;
									}
								}
								if (flag2 && structureBorne.indexPainel != 0)
								{
									num2 = Information.UBound(array) + 1;
									array = (mBornes[])Utils.CopyArray(array, new mBornes[num2 + 1]);
									array[num2].Painel = structureBorne.indexPainel;
									array[num2].TagRegua = clsTextos.TiraNothing(structureBorne.NomeRegua);
									array[num2].TagAlternativo = clsTextos.TiraNothing(structureBorne.Alternativo);
									array[num2].IndexReguaa = structureBorne.IndiceRegua;
									array[num2].Tipo = structureBorne.tipo;
									array[num2].IndiceMaterial = structureBorne.lm;
									array[num2].Quantidade++;
									array[num2].Ordemm = (int)num;
									num++;
									array[num2].OrdemLay = BuscaOrdemEquipamento(structureBorne.indexPainel, structureBorne.NomeRegua);
									array[num2].sHandle = "BORNE";
								}
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						DeclaracoesGeral._uscPagina.pbFim();
						DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(array2) + Information.UBound(array3) + Information.UBound(array);
						DeclaracoesGeral._uscPagina.pbIniciar();
						int num8 = Information.UBound(array2);
						for (int m = 1; m <= num8; m++)
						{
							num2 = Information.UBound(mMateriais) + 1;
							mMateriais = (LMateriais[])Utils.CopyArray(mMateriais, new LMateriais[num2 + 1]);
							mMateriais[num2].sTipo = "D";
							mMateriais[num2].Dwg = DeclaracoesGeral.arqAtivo.Indice;
							mMateriais[num2].Painel = array2[m].Painel;
							mMateriais[num2].TagMat = array2[m].TagMat;
							mMateriais[num2].TagAlternativo = array2[m].TagAlt;
							mMateriais[num2].IndiceMaterial = array2[m].indexMaterial;
							mMateriais[num2].indexModelo = array2[m].indexeModelo;
							mMateriais[num2].Quantidade = array2[m].Quantidade;
							mMateriais[num2].lOrdem = num;
							num++;
							mMateriais[num2].OrdemLay = array2[m].OrdemLay;
							mMateriais[num2].Avulso = false;
							if (array2[m].indexeModelo != 0)
							{
								mMateriais[num2].sHandle = "";
							}
							else
							{
								mMateriais[num2].sHandle = array2[m].sHandle;
							}
							num3++;
							if (num3 == 100)
							{
								DeclaracoesGeral._uscPagina.pbPasso(num3);
								num3 = 0;
							}
						}
						int num9 = Information.UBound(array3);
						for (int n = 1; n <= num9; n++)
						{
							num2 = Information.UBound(mMateriais) + 1;
							mMateriais = (LMateriais[])Utils.CopyArray(mMateriais, new LMateriais[num2 + 1]);
							mMateriais[num2].sTipo = "D";
							mMateriais[num2].Dwg = DeclaracoesGeral.arqAtivo.Indice;
							mMateriais[num2].Painel = array3[n].Painel;
							mMateriais[num2].TagMat = array3[n].TagMat;
							mMateriais[num2].TagAlternativo = array3[n].TagAlt;
							mMateriais[num2].IndiceMaterial = array3[n].indexMaterial;
							mMateriais[num2].indexModelo = array3[n].indexeModelo;
							mMateriais[num2].Quantidade = array3[n].Quantidade;
							mMateriais[num2].lOrdem = num;
							num++;
							mMateriais[num2].OrdemLay = array3[n].OrdemLay;
							mMateriais[num2].Avulso = false;
							mMateriais[num2].sHandle = "";
							num3++;
							if (num3 == 100)
							{
								DeclaracoesGeral._uscPagina.pbPasso(num3);
								num3 = 0;
							}
						}
						if (Information.UBound(mMateriais) >= 2 && Information.UBound(mMateriais) > 0)
						{
							int num10 = Information.UBound(mMateriais);
							for (int num11 = 1; num11 <= num10; num11++)
							{
								int num12 = Information.UBound(mMateriais) - 1;
								int num13 = num11;
								for (int num14 = num12; num14 >= num13; num14 += -1)
								{
									if (mMateriais[num14].Painel > mMateriais[num14 + 1].Painel)
									{
										LMateriais lMateriais = mMateriais[num14 + 1];
										mMateriais[num14 + 1] = mMateriais[num14];
										mMateriais[num14] = lMateriais;
									}
									if (mMateriais[num14].Painel == mMateriais[num14 + 1].Painel && mMateriais[num14].IndiceMaterial > mMateriais[num14 + 1].IndiceMaterial)
									{
										LMateriais lMateriais = mMateriais[num14 + 1];
										mMateriais[num14 + 1] = mMateriais[num14];
										mMateriais[num14] = lMateriais;
									}
									if (mMateriais[num14].Painel == mMateriais[num14 + 1].Painel && mMateriais[num14].IndiceMaterial == mMateriais[num14 + 1].IndiceMaterial && Operators.CompareString(mMateriais[num14].TagMat, mMateriais[num14 + 1].TagMat, TextCompare: true) > 0)
									{
										LMateriais lMateriais = mMateriais[num14 + 1];
										mMateriais[num14 + 1] = mMateriais[num14];
										mMateriais[num14] = lMateriais;
									}
								}
							}
						}
						DeclaracoesEntidades.StructureBorne[] array5 = null;
						array5 = new DeclaracoesEntidades.StructureBorne[1];
						int num15 = Information.UBound(mModelo2);
						for (int num16 = 1; num16 <= num15; num16++)
						{
							DicionarioBorne.LeDicBornesReservaTodos(mModelo2[num16].indexRegua, ref array5);
						}
						int num17 = Information.UBound(array5);
						for (int num18 = 1; num18 <= num17; num18++)
						{
							bool flag3 = true;
							int num19 = Information.UBound(array);
							for (int num20 = 1; num20 <= num19; num20++)
							{
								if (array[num20].IndexReguaa == array5[num18].IndiceRegua && array[num20].Tipo == array5[num18].tipo && array[num20].IndiceMaterial == array5[num18].lm)
								{
									flag3 = false;
									break;
								}
							}
							if (!(flag3 & (array5[num18].IndiceRegua > 0)))
							{
								continue;
							}
							string tagRegua = "";
							int painel = 0;
							int num21 = Information.UBound(mModelo2);
							for (int num22 = 1; num22 <= num21; num22++)
							{
								if (mModelo2[num22].indexRegua == array5[num18].IndiceRegua)
								{
									tagRegua = mModelo2[num22].nomeRegua;
									painel = mModelo2[num22].indexPainel;
									break;
								}
							}
							num2 = Information.UBound(array) + 1;
							array = (mBornes[])Utils.CopyArray(array, new mBornes[num2 + 1]);
							array[num2].TagRegua = tagRegua;
							array[num2].Painel = painel;
							array[num2].IndexReguaa = array5[num18].IndiceRegua;
							array5[num18].IndiceRegua = 0;
							array[num2].Tipo = array5[num18].tipo;
							array[num2].IndiceMaterial = array5[num18].lm;
							array[num2].Quantidade = 1;
							array[num2].Ordemm = 0;
							array[num2].OrdemLay = 0;
							array[num2].sHandle = "";
							array[num2].TagAlternativo = "";
						}
						int num23 = Information.UBound(array);
						for (int num24 = 1; num24 <= num23; num24++)
						{
							int num25 = Information.UBound(array5);
							for (int num26 = 1; num26 <= num25; num26++)
							{
								if (array[num24].IndexReguaa == array5[num26].IndiceRegua && array[num24].Tipo == array5[num26].tipo && array[num24].IndiceMaterial == array5[num26].lm)
								{
									array[num24].Quantidade++;
								}
							}
						}
						if (Information.UBound(array) >= 2 && Information.UBound(array) > 0)
						{
							int num27 = Information.UBound(array);
							for (int num28 = 1; num28 <= num27; num28++)
							{
								int num29 = Information.UBound(array) - 1;
								int num30 = num28;
								for (int num31 = num29; num31 >= num30; num31 += -1)
								{
									if (array[num31].IndiceMaterial > array[num31 + 1].IndiceMaterial)
									{
										mBornes mBornes2 = array[num31 + 1];
										array[num31 + 1] = array[num31];
										array[num31] = mBornes2;
									}
									if (array[num31].IndiceMaterial == array[num31 + 1].IndiceMaterial && array[num31].Painel > array[num31 + 1].Painel)
									{
										mBornes mBornes2 = array[num31 + 1];
										array[num31 + 1] = array[num31];
										array[num31] = mBornes2;
									}
									if (array[num31].IndiceMaterial == array[num31 + 1].IndiceMaterial && array[num31].Painel == array[num31 + 1].Painel && Operators.CompareString(array[num31].TagRegua, array[num31 + 1].TagRegua, TextCompare: true) > 0)
									{
										mBornes mBornes2 = array[num31 + 1];
										array[num31 + 1] = array[num31];
										array[num31] = mBornes2;
									}
								}
							}
						}
						int num32 = Information.UBound(array);
						for (int num33 = 1; num33 <= num32; num33++)
						{
							num2 = Information.UBound(mMateriais) + 1;
							mMateriais = (LMateriais[])Utils.CopyArray(mMateriais, new LMateriais[num2 + 1]);
							mMateriais[num2].sTipo = "Z";
							mMateriais[num2].Dwg = DeclaracoesGeral.arqAtivo.Indice;
							mMateriais[num2].Painel = array[num33].Painel;
							mMateriais[num2].TagMat = array[num33].TagRegua;
							mMateriais[num2].TagAlternativo = array[num33].TagAlternativo;
							mMateriais[num2].indexModelo = array[num33].IndexReguaa;
							mMateriais[num2].IndiceMaterial = array[num33].IndiceMaterial;
							mMateriais[num2].Quantidade = array[num33].Quantidade;
							mMateriais[num2].lOrdem = num;
							num++;
							mMateriais[num2].OrdemLay = array[num33].OrdemLay;
							mMateriais[num2].Avulso = false;
							mMateriais[num2].sHandle = array[num33].sHandle;
							num3++;
							if (num3 == 100)
							{
								DeclaracoesGeral._uscPagina.pbPasso(num3);
								num3 = 0;
							}
						}
						DeclaracoesGeral._uscPagina.pbFim();
						if (Information.UBound(mMateriais) >= 2)
						{
							long num34 = Information.UBound(mMateriais);
							for (long num35 = 1L; num35 <= num34; num35++)
							{
								mMateriais[(int)num35].lOrdem = num35;
							}
						}
						if (Information.UBound(mMateriais) >= 2 && Information.UBound(mMateriais) > 0)
						{
							int num36 = Information.UBound(mMateriais);
							for (int num37 = 1; num37 <= num36; num37++)
							{
								int num38 = Information.UBound(mMateriais) - 1;
								int num39 = num37;
								for (int num40 = num38; num40 >= num39; num40 += -1)
								{
									if (mMateriais[num40].lOrdem > mMateriais[num40 + 1].lOrdem)
									{
										LMateriais lMateriais = mMateriais[num40 + 1];
										mMateriais[num40 + 1] = mMateriais[num40];
										mMateriais[num40] = lMateriais;
									}
								}
							}
						}
						int num41 = Information.UBound(mMateriais);
						for (int num42 = 1; num42 <= num41; num42++)
						{
							int num43 = Information.UBound(mMateriais) - 1;
							int num44 = num42;
							for (int num45 = num43; num45 >= num44; num45 += -1)
							{
								if (mMateriais[num42].Painel > mMateriais[num45 + 1].Painel)
								{
									LMateriais lMateriais = mMateriais[num45 + 1];
									mMateriais[num45 + 1] = mMateriais[num45];
									mMateriais[num45] = lMateriais;
								}
								if (mMateriais[num42].Painel == mMateriais[num45 + 1].Painel && mMateriais[num45].IndiceMaterial > mMateriais[num45 + 1].IndiceMaterial)
								{
									LMateriais lMateriais = mMateriais[num45 + 1];
									mMateriais[num45 + 1] = mMateriais[num45];
									mMateriais[num45] = lMateriais;
								}
								if (mMateriais[num42].Painel == mMateriais[num45 + 1].Painel && mMateriais[num45].IndiceMaterial == mMateriais[num45 + 1].IndiceMaterial && Operators.CompareString(mMateriais[num45].TagMat, mMateriais[num45 + 1].TagMat, TextCompare: true) > 0)
								{
									LMateriais lMateriais = mMateriais[num45 + 1];
									mMateriais[num45 + 1] = mMateriais[num45];
									mMateriais[num45] = lMateriais;
								}
								if (mMateriais[num42].Painel == mMateriais[num45 + 1].Painel && mMateriais[num45].IndiceMaterial == mMateriais[num45 + 1].IndiceMaterial && Operators.CompareString(mMateriais[num45].TagMat, mMateriais[num45 + 1].TagMat, TextCompare: true) == 0 && Operators.CompareString(mMateriais[num45].TagAlternativo, mMateriais[num45 + 1].TagAlternativo, TextCompare: true) > 0)
								{
									LMateriais lMateriais = mMateriais[num45 + 1];
									mMateriais[num45 + 1] = mMateriais[num45];
									mMateriais[num45] = lMateriais;
								}
							}
						}
						if (Information.UBound(mMateriais) >= 2)
						{
							long num46 = Information.UBound(mMateriais);
							for (long num47 = 1L; num47 <= num46; num47++)
							{
								mMateriais[(int)num47].lOrdem = num47;
							}
						}
						if (flag)
						{
							int num48 = Information.UBound(mMateriais);
							for (int num49 = 1; num49 <= num48; num49++)
							{
								mMateriais[num49].lOrdem += 10000L;
							}
							int num50 = Information.UBound(mMateriais);
							for (int num51 = 1; num51 <= num50; num51++)
							{
								int num52 = Information.UBound(OrdemLM);
								for (int num53 = 1; num53 <= num52; num53++)
								{
									if (mMateriais[num51].Painel == OrdemLM[num53].iPainel && Operators.CompareString(mMateriais[num51].TagMat, OrdemLM[num53].sTag, TextCompare: true) == 0 && mMateriais[num51].IndiceMaterial == OrdemLM[num53].IndiceMaterial && !OrdemLM[num53].bEncontrado)
									{
										mMateriais[num51].lOrdem = OrdemLM[num53].iOrdem;
										OrdemLM[num53].bEncontrado = true;
									}
								}
							}
						}
						cDadosAccessMateriais cDadosAccessMateriais3 = new cDadosAccessMateriais();
						cDadosAccessMateriais3.CapturaMateriaisAvulso(ref mMateriais);
						if (Information.UBound(mMateriais) >= 2 && Information.UBound(mMateriais) > 0)
						{
							int num54 = Information.UBound(mMateriais);
							for (int num55 = 1; num55 <= num54; num55++)
							{
								int num56 = Information.UBound(mMateriais) - 1;
								int num57 = num55;
								for (int num58 = num56; num58 >= num57; num58 += -1)
								{
									if (mMateriais[num58].lOrdem > mMateriais[num58 + 1].lOrdem)
									{
										LMateriais lMateriais = mMateriais[num58 + 1];
										mMateriais[num58 + 1] = mMateriais[num58];
										mMateriais[num58] = lMateriais;
									}
								}
							}
						}
						if (Information.UBound(mMateriais) >= 2 && Information.UBound(mMateriais) > 0)
						{
							List<int> list = new List<int>();
							int num59 = Information.UBound(mMateriais);
							for (int num60 = 1; num60 <= num59; num60++)
							{
								if (!list.Contains(mMateriais[num60].Painel))
								{
									list.Add(mMateriais[num60].Painel);
								}
							}
							foreach (int item in list)
							{
								long num61 = 1L;
								int num62 = Information.UBound(mMateriais);
								for (int num63 = 1; num63 <= num62; num63++)
								{
									if (mMateriais[num63].Painel == item)
									{
										mMateriais[num63].lOrdem = num61;
										num61++;
									}
								}
							}
						}
						cDadosAccessMateriais3.RemoveItemMaterial(mMateriais);
						cDadosAccessMateriais3.fechaConexao();
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
				throw;
			}
			finally
			{
			}
		}
	}

	public static int BuscaOrdemEquipamento(int painelSel, string sEquip)
	{
		int result = 10000;
		List<string> list = new List<string>();
		checked
		{
			if (DicionarioLayout.ExisteDicLayoutPainel(Conversions.ToString(painelSel)))
			{
				DeclaracoesEntidades.StructureLayout[] mTags = new DeclaracoesEntidades.StructureLayout[1];
				if (DicionarioLayout.LeDicLayout("P" + painelSel, ref mTags))
				{
					DeclaracoesEntidades.StructureLayout[] array = mTags;
					for (int i = 0; i < array.Length; i++)
					{
						DeclaracoesEntidades.StructureLayout structureLayout = array[i];
						if (!list.Contains(structureLayout.Tag))
						{
							list.Add(structureLayout.Tag);
						}
					}
				}
				DeclaracoesEntidades.StructureLayout[] mTags2 = new DeclaracoesEntidades.StructureLayout[1];
				if (DicionarioLayout.LeDicLayout("C" + painelSel, ref mTags2))
				{
					DeclaracoesEntidades.StructureLayout[] array2 = mTags2;
					for (int j = 0; j < array2.Length; j++)
					{
						DeclaracoesEntidades.StructureLayout structureLayout2 = array2[j];
						if (!list.Contains(structureLayout2.Tag))
						{
							list.Add(structureLayout2.Tag);
						}
					}
				}
			}
			if (list.Count > 0)
			{
				int num = list.Count - 1;
				for (int k = 0; k <= num; k++)
				{
					if (Operators.CompareString(sEquip, list[k], TextCompare: true) == 0)
					{
						result = k;
						break;
					}
				}
			}
			return result;
		}
	}

	public static void PaineisDocumentoLM(ref mPN[] mPaineisLM)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected Obj, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Obj, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected Obj, but got Unknown
		bool flag = true;
		int num = 0;
		int num2 = 0;
		string sTipo = "";
		mPaineisLM = new mPN[1];
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
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
							num = 0;
							num2 = 0;
							int Potencial = 0;
							XDataDispositivo.xDataPaineis(ent, ref sTipo, ref num, ref num2, ref Potencial);
							if (num != 0)
							{
								flag = true;
								int num3 = Information.UBound(mPaineisLM);
								for (int i = 1; i <= num3; i++)
								{
									if (mPaineisLM[i].iPainel == num)
									{
										flag = false;
										break;
									}
								}
								if (flag)
								{
									int num4 = Information.UBound(mPaineisLM) + 1;
									mPaineisLM = (mPN[])Utils.CopyArray(mPaineisLM, new mPN[num4 + 1]);
									mPaineisLM[num4].iPainel = num;
									mPaineisLM[num4].sPainel = Dicionario.BuscaNomeDoPainel(num);
								}
							}
							if (num2 == 0)
							{
								continue;
							}
							flag = true;
							int num5 = Information.UBound(mPaineisLM);
							for (int j = 1; j <= num5; j++)
							{
								if (mPaineisLM[j].iPainel == num2)
								{
									flag = false;
									break;
								}
							}
							if (flag)
							{
								int num6 = Information.UBound(mPaineisLM) + 1;
								mPaineisLM = (mPN[])Utils.CopyArray(mPaineisLM, new mPN[num6 + 1]);
								mPaineisLM[num6].iPainel = num2;
								mPaineisLM[num6].sPainel = Dicionario.BuscaNomeDoPainel(num2);
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
	}

	public static string BuscaModeloLM(LModFab[] mModFab, int iLm)
	{
		string result = "";
		if (iLm > 0)
		{
			int num = Information.UBound(mModFab);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (mModFab[i].indice == iLm)
				{
					result = mModFab[i].Modelo;
					break;
				}
			}
		}
		return result;
	}
}
