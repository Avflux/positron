using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

public class clsLinha
{
	public struct StructureLinhaBornes
	{
		public string term;

		public string Handle;

		public Point3d InsertionPoint;

		public Point3d ptIni;

		public Point3d ptFim;

		public long Potencial;

		public int IndexRegua;

		public bool btitulo;

		public Point3d ptMeio;

		public double x;

		public double y;
	}

	public struct LigacaoDosBornes
	{
		public int indece;

		public double iX;

		public double iY;
	}

	public static void AdricionaLinhaH(double dI, double dM, double dF)
	{
		CriaEstiloDeLinha();
		clsBornes.BornesTipo[] BornesTipo = new clsBornes.BornesTipo[1];
		StructureLinhaBornes[] LinhaBorne = new StructureLinhaBornes[1];
		SELCarregaosBornesDaPaginaH(ref LinhaBorne, DeclaracoesGeral.ativo.Pagina, ref BornesTipo);
		LigacaoDosBornes[] array = new LigacaoDosBornes[1];
		DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(LinhaBorne);
		DeclaracoesGeral._uscPagina.pbIniciar();
		int num = 1;
		int num2 = Information.UBound(LinhaBorne);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				if (LinhaBorne[i].btitulo)
				{
					num++;
				}
				LinhaBorne[i].IndexRegua += num;
			}
			int num3 = Information.UBound(LinhaBorne);
			for (int j = 1; j <= num3; j++)
			{
				bool flag = true;
				int num4 = Information.UBound(array);
				for (int k = 0; k <= num4; k++)
				{
					if ((LinhaBorne[j].IndexRegua == array[k].indece) & (Math.Round(LinhaBorne[j].InsertionPoint.Y, 2) == array[k].iY))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					int num5 = Information.UBound(array) + 1;
					array = (LigacaoDosBornes[])Utils.CopyArray(array, new LigacaoDosBornes[num5 + 1]);
					array[num5].indece = LinhaBorne[j].IndexRegua;
					array[num5].iY = Math.Round(LinhaBorne[j].InsertionPoint.Y, 5);
					array[num5].iX = Math.Round(LinhaBorne[j].InsertionPoint.X, 5);
				}
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			DeclaracoesGeral._uscPagina.pbFim();
			DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(array);
			DeclaracoesGeral._uscPagina.pbIniciar();
			int num6 = Information.UBound(array);
			for (int l = 1; l <= num6; l++)
			{
				StructureLinhaBornes[] CriarLinhaBorne = new StructureLinhaBornes[1];
				carregaLinhaNovaH(array[l].indece, array[l].iY, ref LinhaBorne, ref CriarLinhaBorne);
				InsereAsLinhasH(ref CriarLinhaBorne, DeclaracoesGeral.ativo.Pagina, dI, dM, dF);
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	public static void AdricionaLinhaV(double dI, double dM, double dF)
	{
		clsBornes.BornesTipo[] BornesTipo = new clsBornes.BornesTipo[1];
		CriaEstiloDeLinha();
		StructureLinhaBornes[] LinhaBorne = new StructureLinhaBornes[1];
		SELCarregaosBornesDaPaginaV(ref LinhaBorne, DeclaracoesGeral.ativo.Pagina, ref BornesTipo);
		LigacaoDosBornes[] array = new LigacaoDosBornes[1];
		DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(LinhaBorne);
		DeclaracoesGeral._uscPagina.pbIniciar();
		int num = 1;
		int num2 = Information.UBound(LinhaBorne);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				if (LinhaBorne[i].btitulo)
				{
					num++;
				}
				LinhaBorne[i].IndexRegua += num;
			}
			int num3 = Information.UBound(LinhaBorne);
			for (int j = 1; j <= num3; j++)
			{
				bool flag = true;
				int num4 = Information.UBound(array);
				for (int k = 0; k <= num4; k++)
				{
					if ((LinhaBorne[j].IndexRegua == array[k].indece) & (Math.Round(LinhaBorne[j].InsertionPoint.X, 5) == array[k].iX))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					int num5 = Information.UBound(array) + 1;
					array = (LigacaoDosBornes[])Utils.CopyArray(array, new LigacaoDosBornes[num5 + 1]);
					array[num5].indece = LinhaBorne[j].IndexRegua;
					array[num5].iY = Math.Round(LinhaBorne[j].InsertionPoint.Y, 5);
					array[num5].iX = Math.Round(LinhaBorne[j].InsertionPoint.X, 5);
				}
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			DeclaracoesGeral._uscPagina.pbFim();
			DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(array);
			DeclaracoesGeral._uscPagina.pbIniciar();
			int num6 = Information.UBound(array);
			for (int l = 1; l <= num6; l++)
			{
				StructureLinhaBornes[] CriarLinhaBorne = new StructureLinhaBornes[1];
				carregaLinhaNovaV(array[l].indece, array[l].iX, LinhaBorne, ref CriarLinhaBorne);
				InsereAsLinhasV(ref CriarLinhaBorne, DeclaracoesGeral.ativo.Pagina, BornesTipo, dI, dM, dF);
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	public static bool BuscaBornesDaPagina(BlockReference Bloco, ref Point3d xIni, ref Point3d xFim, string sLinha)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected Obj, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected Obj, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected Obj, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected Obj, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Expected Obj, but got Unknown
		//IL_0e1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dde: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df7: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0887: Unknown result type (might be due to invalid IL or missing references)
		//IL_088c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0507: Unknown result type (might be due to invalid IL or missing references)
		//IL_050c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0466: Unknown result type (might be due to invalid IL or missing references)
		//IL_046b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a76: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c10: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c19: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Unknown result type (might be due to invalid IL or missing references)
		//IL_052d: Unknown result type (might be due to invalid IL or missing references)
		//IL_047d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c49: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0715: Unknown result type (might be due to invalid IL or missing references)
		//IL_071a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Unknown result type (might be due to invalid IL or missing references)
		//IL_054e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0494: Unknown result type (might be due to invalid IL or missing references)
		//IL_0499: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0734: Unknown result type (might be due to invalid IL or missing references)
		//IL_0739: Unknown result type (might be due to invalid IL or missing references)
		//IL_0562: Unknown result type (might be due to invalid IL or missing references)
		//IL_0567: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0900: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d45: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d73: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_074b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0750: Unknown result type (might be due to invalid IL or missing references)
		//IL_057b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0580: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0404: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae7: Unknown result type (might be due to invalid IL or missing references)
		//IL_091c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0921: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0762: Unknown result type (might be due to invalid IL or missing references)
		//IL_0767: Unknown result type (might be due to invalid IL or missing references)
		//IL_059c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04de: Unknown result type (might be due to invalid IL or missing references)
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0422: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b01: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b06: Unknown result type (might be due to invalid IL or missing references)
		//IL_093d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0942: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0781: Unknown result type (might be due to invalid IL or missing references)
		//IL_0786: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Unknown result type (might be due to invalid IL or missing references)
		//IL_043b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0956: Unknown result type (might be due to invalid IL or missing references)
		//IL_095b: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05db: Unknown result type (might be due to invalid IL or missing references)
		//IL_044f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_096f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0974: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0988: Unknown result type (might be due to invalid IL or missing references)
		//IL_098d: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0608: Unknown result type (might be due to invalid IL or missing references)
		//IL_060d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0621: Unknown result type (might be due to invalid IL or missing references)
		//IL_0626: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b81: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0801: Unknown result type (might be due to invalid IL or missing references)
		//IL_0642: Unknown result type (might be due to invalid IL or missing references)
		//IL_0647: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_081b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0820: Unknown result type (might be due to invalid IL or missing references)
		//IL_0663: Unknown result type (might be due to invalid IL or missing references)
		//IL_0668: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a01: Unknown result type (might be due to invalid IL or missing references)
		//IL_083a: Unknown result type (might be due to invalid IL or missing references)
		//IL_083f: Unknown result type (might be due to invalid IL or missing references)
		//IL_067c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0681: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0851: Unknown result type (might be due to invalid IL or missing references)
		//IL_0856: Unknown result type (might be due to invalid IL or missing references)
		//IL_0695: Unknown result type (might be due to invalid IL or missing references)
		//IL_069a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0868: Unknown result type (might be due to invalid IL or missing references)
		//IL_086d: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dc: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		List<string> list = new List<string>();
		List<ObjectId> list2 = new List<ObjectId>();
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
					try
					{
						BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val4.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val5 = (Entity)current.GetObject((OpenMode)0);
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								if (val6 == null)
								{
									continue;
								}
								string tipoImportado = "";
								Entity ent = (Entity)(object)val6;
								string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
								val6 = (BlockReference)ent;
								string left = text;
								if ((Operators.CompareString(left, "B", TextCompare: true) == 0) | ((Operators.CompareString(tipoImportado, "B", TextCompare: true) == 0) & (Operators.CompareString(left, "I", TextCompare: true) == 0)))
								{
									if (!list.Contains(val6.Name.ToString()))
									{
										list.Add(val6.Name.ToString());
									}
									list2.Add(((DBObject)val6).ObjectId);
								}
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						BlockTableRecordEnumerator enumerator3 = default;
						foreach (string item in list)
						{
							if (Operators.CompareString(item, Bloco.Name, TextCompare: true) != 0)
							{
								continue;
							}
							result = true;
							if (!((SymbolTable)val3).Has(item))
							{
								continue;
							}
							BlockTableRecord val7 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[item], (OpenMode)0);
							double num = 1000000.0;
							double num2 = -1000000.0;
							double num3 = 1000000.0;
							double num4 = -1000000.0;
							try
							{
								enumerator3 = val7.GetEnumerator();
								while (enumerator3.MoveNext())
								{
									ObjectId current3 = enumerator3.Current;
									Entity val8 = (Entity)current3.GetObject((OpenMode)0);
									Polyline val9 = (Polyline)(object)((val8 is Polyline) ? val8 : null);
									if (val9 != null)
									{
										int num5 = val9.NumberOfVertices - 1;
										for (int i = 0; i <= num5; i++)
										{
											Point2d point2dAt = val9.GetPoint2dAt(i);
											if (point2dAt.X < num)
											{
												num = point2dAt.X;
											}
											if (point2dAt.X > num2)
											{
												num2 = point2dAt.X;
											}
											if (point2dAt.Y < num3)
											{
												num3 = point2dAt.Y;
											}
											if (point2dAt.Y > num4)
											{
												num4 = point2dAt.Y;
											}
										}
									}
									Line val10 = (Line)(object)((val8 is Line) ? val8 : null);
									Point3d val11;
									if (val10 != null)
									{
										val11 = val10.StartPoint;
										if (val11.X < num)
										{
											val11 = val10.StartPoint;
											num = val11.X;
										}
										val11 = val10.EndPoint;
										if (val11.X < num)
										{
											val11 = val10.EndPoint;
											num = val11.X;
										}
										val11 = val10.StartPoint;
										if (val11.X > num2)
										{
											val11 = val10.StartPoint;
											num2 = val11.X;
										}
										val11 = val10.EndPoint;
										if (val11.X > num2)
										{
											val11 = val10.EndPoint;
											num2 = val11.X;
										}
										val11 = val10.StartPoint;
										if (val11.Y < num3)
										{
											val11 = val10.StartPoint;
											num3 = val11.Y;
										}
										val11 = val10.EndPoint;
										if (val11.Y < num3)
										{
											val11 = val10.EndPoint;
											num3 = val11.Y;
										}
										val11 = val10.StartPoint;
										if (val11.Y > num4)
										{
											val11 = val10.StartPoint;
											num4 = val11.Y;
										}
										val11 = val10.EndPoint;
										if (val11.Y > num4)
										{
											val11 = val10.EndPoint;
											num4 = val11.Y;
										}
									}
									Circle val12 = (Circle)(object)((val8 is Circle) ? val8 : null);
									if (val12 != null)
									{
										val11 = val12.Center;
										if (val11.X + val12.Radius < num)
										{
											val11 = val12.Center;
											num = val11.X + val12.Radius;
										}
										val11 = val12.Center;
										if (val11.X + val12.Radius > num2)
										{
											val11 = val12.Center;
											num2 = val11.X + val12.Radius;
										}
										val11 = val12.Center;
										if (val11.Y < num3)
										{
											val11 = val12.Center;
											num3 = val11.Y;
										}
										val11 = val12.Center;
										if (val11.Y > num4)
										{
											val11 = val12.Center;
											num4 = val11.Y;
										}
										val11 = val12.Center;
										if (val11.X - val12.Radius < num)
										{
											val11 = val12.Center;
											num = val11.X - val12.Radius;
										}
										val11 = val12.Center;
										if (val11.X - val12.Radius > num2)
										{
											val11 = val12.Center;
											num2 = val11.X - val12.Radius;
										}
										val11 = val12.Center;
										if (val11.Y < num3)
										{
											val11 = val12.Center;
											num3 = val11.Y;
										}
										val11 = val12.Center;
										if (val11.Y > num4)
										{
											val11 = val12.Center;
											num4 = val11.Y;
										}
										val11 = val12.Center;
										if (val11.X < num)
										{
											val11 = val12.Center;
											num = val11.X;
										}
										val11 = val12.Center;
										if (val11.X > num2)
										{
											val11 = val12.Center;
											num2 = val11.X;
										}
										val11 = val12.Center;
										if (val11.Y - val12.Radius < num3)
										{
											val11 = val12.Center;
											num3 = val11.Y - val12.Radius;
										}
										val11 = val12.Center;
										if (val11.Y - val12.Radius > num4)
										{
											val11 = val12.Center;
											num4 = val11.Y - val12.Radius;
										}
										val11 = val12.Center;
										if (val11.X < num)
										{
											val11 = val12.Center;
											num = val11.X;
										}
										val11 = val12.Center;
										if (val11.X > num2)
										{
											val11 = val12.Center;
											num2 = val11.X;
										}
										val11 = val12.Center;
										if (val11.Y + val12.Radius < num3)
										{
											val11 = val12.Center;
											num3 = val11.Y + val12.Radius;
										}
										val11 = val12.Center;
										if (val11.Y + val12.Radius > num4)
										{
											val11 = val12.Center;
											num4 = val11.Y + val12.Radius;
										}
									}
									Arc val13 = (Arc)(object)((val8 is Arc) ? val8 : null);
									if (val13 != null)
									{
										val11 = val13.Center;
										if (val11.X + val13.Radius < num)
										{
											val11 = val13.Center;
											num = val11.X + val13.Radius;
										}
										val11 = val13.Center;
										if (val11.X + val13.Radius > num2)
										{
											val11 = val13.Center;
											num2 = val11.X + val13.Radius;
										}
										val11 = val13.Center;
										if (val11.Y < num3)
										{
											val11 = val13.Center;
											num3 = val11.Y;
										}
										val11 = val13.Center;
										if (val11.Y > num4)
										{
											val11 = val13.Center;
											num4 = val11.Y;
										}
										val11 = val13.Center;
										if (val11.X - val13.Radius < num)
										{
											val11 = val13.Center;
											num = val11.X - val13.Radius;
										}
										val11 = val13.Center;
										if (val11.X - val13.Radius > num2)
										{
											val11 = val13.Center;
											num2 = val11.X - val13.Radius;
										}
										val11 = val13.Center;
										if (val11.Y < num3)
										{
											val11 = val13.Center;
											num3 = val11.Y;
										}
										val11 = val13.Center;
										if (val11.Y > num4)
										{
											val11 = val13.Center;
											num4 = val11.Y;
										}
										val11 = val13.Center;
										if (val11.X < num)
										{
											val11 = val13.Center;
											num = val11.X;
										}
										val11 = val13.Center;
										if (val11.X > num2)
										{
											val11 = val13.Center;
											num2 = val11.X;
										}
										val11 = val13.Center;
										if (val11.Y - val13.Radius < num3)
										{
											val11 = val13.Center;
											num3 = val11.Y - val13.Radius;
										}
										val11 = val13.Center;
										if (val11.Y - val13.Radius > num4)
										{
											val11 = val13.Center;
											num4 = val11.Y - val13.Radius;
										}
										val11 = val13.Center;
										if (val11.X < num)
										{
											val11 = val13.Center;
											num = val11.X;
										}
										val11 = val13.Center;
										if (val11.X > num2)
										{
											val11 = val13.Center;
											num2 = val11.X;
										}
										val11 = val13.Center;
										if (val11.Y + val13.Radius < num3)
										{
											val11 = val13.Center;
											num3 = val11.Y + val13.Radius;
										}
										val11 = val13.Center;
										if (val11.Y + val13.Radius > num4)
										{
											val11 = val13.Center;
											num4 = val11.Y + val13.Radius;
										}
									}
									Hatch val14 = (Hatch)(object)((val8 is Hatch) ? val8 : null);
									if (val14 != null)
									{
										Extents3d value = ((Drawable)val14).Bounds.Value;
										val11 = value.MinPoint;
										if (val11.X < num)
										{
											value = ((Drawable)val14).Bounds.Value;
											val11 = value.MinPoint;
											num = val11.X;
										}
										value = ((Drawable)val14).Bounds.Value;
										val11 = value.MaxPoint;
										if (val11.X > num2)
										{
											value = ((Drawable)val14).Bounds.Value;
											val11 = value.MaxPoint;
											num2 = val11.X;
										}
										value = ((Drawable)val14).Bounds.Value;
										val11 = value.MinPoint;
										if (val11.Y < num3)
										{
											value = ((Drawable)val14).Bounds.Value;
											val11 = value.MinPoint;
											num3 = val11.Y;
										}
										value = ((Drawable)val14).Bounds.Value;
										val11 = value.MaxPoint;
										if (val11.Y > num4)
										{
											value = ((Drawable)val14).Bounds.Value;
											val11 = value.MaxPoint;
											num4 = val11.Y;
										}
									}
									DBPoint val15 = (DBPoint)(object)((val8 is DBPoint) ? val8 : null);
									if (val15 != null)
									{
										val11 = val15.Position;
										if (val11.X < num)
										{
											val11 = val15.Position;
											num = val11.X;
										}
										val11 = val15.Position;
										if (val11.X > num2)
										{
											val11 = val15.Position;
											num2 = val11.X;
										}
										val11 = val15.Position;
										if (val11.Y < num3)
										{
											val11 = val15.Position;
											num3 = val11.Y;
										}
										val11 = val15.Position;
										if (val11.Y > num4)
										{
											val11 = val15.Position;
											num4 = val11.Y;
										}
									}
								}
							}
							finally
							{
								((IDisposable)enumerator3)?.Dispose();
							}
							if (Operators.CompareString(sLinha, "H", TextCompare: true) != 0)
							{
								double num6 = (num2 + num) / 2.0;
								xIni = new Point3d(num6, 0.0 - num3, 0.0);
								xFim = new Point3d(num6, 0.0 - num4, 0.0);
							}
							else
							{
								double num7 = (num4 + num3) / 2.0;
								xIni = new Point3d(num, num7, 0.0);
								xFim = new Point3d(num2, num7, 0.0);
							}
							break;
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
			return result;
		}
	}

	public static long SELCarregaosBornesDaPaginaH(ref StructureLinhaBornes[] LinhaBorne, string sPagina, ref clsBornes.BornesTipo[] BornesTipo)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected Obj, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected Obj, but got Unknown
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Expected Obj, but got Unknown
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Expected Obj, but got Unknown
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03eb: Expected Obj, but got Unknown
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Invalid comparison between Unknown and I4
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_0440: Expected Obj, but got Unknown
		//IL_0440: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected Obj, but got Unknown
		//IL_077e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0784: Unknown result type (might be due to invalid IL or missing references)
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_047d: Expected Obj, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_0502: Unknown result type (might be due to invalid IL or missing references)
		//IL_0509: Expected Obj, but got Unknown
		//IL_0549: Unknown result type (might be due to invalid IL or missing references)
		//IL_054e: Unknown result type (might be due to invalid IL or missing references)
		//IL_056b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0570: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05de: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0617: Unknown result type (might be due to invalid IL or missing references)
		//IL_061c: Unknown result type (might be due to invalid IL or missing references)
		//IL_062f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0634: Unknown result type (might be due to invalid IL or missing references)
		//IL_064e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0653: Unknown result type (might be due to invalid IL or missing references)
		//IL_0663: Unknown result type (might be due to invalid IL or missing references)
		//IL_0668: Unknown result type (might be due to invalid IL or missing references)
		//IL_067b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0680: Unknown result type (might be due to invalid IL or missing references)
		//IL_069a: Unknown result type (might be due to invalid IL or missing references)
		//IL_069f: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0720: Unknown result type (might be due to invalid IL or missing references)
		//IL_0725: Unknown result type (might be due to invalid IL or missing references)
		//IL_0738: Unknown result type (might be due to invalid IL or missing references)
		//IL_073d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0757: Unknown result type (might be due to invalid IL or missing references)
		//IL_075c: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		BornesTipo = new clsBornes.BornesTipo[1];
		BornesTipo[0].Nome = "";
		long num2 = 0L;
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
					DeclaracoesGeral._uscPagina.Quantidade = clsBlocos.AcadObjectCount();
					DeclaracoesGeral._uscPagina.pbIniciar();
					int num3 = 0;
					List<string> list = new List<string>();
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
							if (Operators.CompareString(ent.Layer, sPagina, TextCompare: true) == 0)
							{
								string tipoImportado = "";
								string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
								if ((Operators.CompareString(left, "B", TextCompare: true) == 0) | ((Operators.CompareString(tipoImportado, "B", TextCompare: true) == 0) & (Operators.CompareString(left, "I", TextCompare: true) == 0)))
								{
									DeclaracoesEntidades.StructureBorne structureBorne = default;
									BlockReference blockRef = (BlockReference)ent;
									object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									ent = (Entity)(object)blockRef;
									object obj2 = obj;
									structureBorne = ((obj2 == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj2));
									BlockReference val5 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
									if (!list.Contains(val5.Name))
									{
										list.Add(val5.Name);
										Point3d xIni = new Point3d(0.0, 0.0, 0.0);
										Point3d xFim = new Point3d(0.0, 0.0, 0.0);
										if (BuscaBornesDaPagina(val5, ref xIni, ref xFim, "H"))
										{
											if (Operators.CompareString(BornesTipo[num].Nome, "", TextCompare: true) != 0)
											{
												num++;
											}
											BornesTipo = (clsBornes.BornesTipo[])Utils.CopyArray(BornesTipo, new clsBornes.BornesTipo[num + 1]);
											BornesTipo[num].Nome = val5.Name;
											BornesTipo[num].iIni = xIni;
											BornesTipo[num].iFim = xFim;
										}
									}
								}
							}
							num3++;
							if (num3 == 100)
							{
								DeclaracoesGeral._uscPagina.pbPasso(num3);
								num3 = 0;
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					DeclaracoesGeral._uscPagina.pbFim();
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
			DocumentLock val6 = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database2 = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val7 = database2.TransactionManager.StartTransaction();
				try
				{
					BlockTable val8 = (BlockTable)val7.GetObject(database2.BlockTableId, (OpenMode)0);
					_ = (BlockTableRecord)val7.GetObject(((SymbolTable)val8)[BlockTableRecord.ModelSpace], (OpenMode)1);
					Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
					TypedValue[] array = new TypedValue[5];
					array.SetValue((object)new TypedValue(0, (object)"INSERT"), 0);
					array.SetValue((object)new TypedValue(-4, (object)"<OR"), 1);
					array.SetValue((object)new TypedValue(1001, (object)"DISPOSITIVO"), 2);
					array.SetValue((object)new TypedValue(1001, (object)"IMPORTADO"), 3);
					array.SetValue((object)new TypedValue(-4, (object)"OR>"), 4);
					SelectionFilter val9 = new SelectionFilter(array);
					PromptSelectionOptions val10 = new PromptSelectionOptions();
					val10.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1370]);
					PromptSelectionResult selection = editor.GetSelection(val10, val9);
					if (unchecked((int)selection.Status) == 5100)
					{
						SelectionSet value = selection.Value;
						ObjectIdCollection val11 = new ObjectIdCollection(value.GetObjectIds());
						new ObjectIdCollection();
						new List<double>();
						foreach (object item in val11)
						{
							ObjectId val12 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							Entity ent2 = (Entity)val12.GetObject((OpenMode)0);
							if (Operators.CompareString(ent2.Layer, DeclaracoesGeral.ativo.Pagina, TextCompare: true) != 0)
							{
								continue;
							}
							BlockReference val13 = (BlockReference)(object)((ent2 is BlockReference) ? ent2 : null);
							if (val13 == null)
							{
								continue;
							}
							string tipoImportado2 = "";
							string left2 = XDataDispositivo.verificaTipoDispositivo(ref ent2, ref tipoImportado2);
							if ((Operators.CompareString(left2, "B", TextCompare: true) == 0) | ((Operators.CompareString(tipoImportado2, "B", TextCompare: true) == 0) & (Operators.CompareString(left2, "I", TextCompare: true) == 0)))
							{
								DeclaracoesEntidades.StructureBorne structureBorne2 = default;
								BlockReference blockRef = (BlockReference)ent2;
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								ent2 = (Entity)(object)blockRef;
								object obj3 = obj;
								structureBorne2 = ((obj3 == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj3));
								BlockReference val14 = (BlockReference)(object)((ent2 is BlockReference) ? ent2 : null);
								Point3d val15 = new Point3d(0.0, 0.0, 0.0);
								Point3d val16 = new Point3d(0.0, 0.0, 0.0);
								if (H9gThl5vQ0(val14.Name, BornesTipo, ref val15, ref val16))
								{
									int num4 = Information.UBound(LinhaBorne) + 1;
									LinhaBorne = (StructureLinhaBornes[])Utils.CopyArray(LinhaBorne, new StructureLinhaBornes[num4 + 1]);
									ref StructureLinhaBornes reference = ref LinhaBorne[num4];
									Point3d position = val14.Position;
									double x = position.X;
									position = val14.Position;
									reference.InsertionPoint = new Point3d(x, position.Y, 0.0);
									LinhaBorne[num4].Handle = ((object)((DBObject)ent2).Handle/*cast due to constrained. prefix*/).ToString();
									ref StructureLinhaBornes reference2 = ref LinhaBorne[num4];
									position = val14.Position;
									double num5 = position.X + val15.X;
									position = val14.Position;
									reference2.ptIni = new Point3d(num5, position.Y + val15.Y, 0.0);
									ref StructureLinhaBornes reference3 = ref LinhaBorne[num4];
									position = val14.Position;
									double num6 = position.X + val16.X;
									position = val14.Position;
									reference3.ptFim = new Point3d(num6, position.Y + val16.Y, 0.0);
									LinhaBorne[num4].IndexRegua = structureBorne2.IndiceRegua;
									ref StructureLinhaBornes reference4 = ref LinhaBorne[num4];
									string sHandle = ((object)((DBObject)ent2).Handle/*cast due to constrained. prefix*/).ToString();
									reference4.btitulo = clsBlocos.AtributoVisivelDeUmBloco(ref sHandle, "NOME1");
									LinhaBorne[num4].x = val15.X;
									LinhaBorne[num4].y = val15.Y;
									ref StructureLinhaBornes reference5 = ref LinhaBorne[num4];
									position = val14.Position;
									double num7 = position.X + val15.X;
									position = val14.Position;
									reference5.ptMeio = new Point3d(num7, position.Y + val15.Y, 0.0);
									num2++;
								}
							}
						}
						if (num2 > 0L)
						{
							StructureLinhaBornes structureLinhaBornes = default;
							if (Information.UBound(LinhaBorne) >= 2 && Information.UBound(LinhaBorne) > 0)
							{
								int num8 = Information.UBound(LinhaBorne);
								for (int i = 1; i <= num8; i++)
								{
									int num9 = Information.UBound(LinhaBorne) - 1;
									int num10 = i;
									for (int j = num9; j >= num10; j += -1)
									{
										if (LinhaBorne[j].IndexRegua > LinhaBorne[j + 1].IndexRegua)
										{
											structureLinhaBornes = LinhaBorne[j + 1];
											LinhaBorne[j + 1] = LinhaBorne[j];
											LinhaBorne[j] = structureLinhaBornes;
										}
										if (LinhaBorne[j].IndexRegua == LinhaBorne[j + 1].IndexRegua && LinhaBorne[j].InsertionPoint.Y > LinhaBorne[j + 1].InsertionPoint.Y)
										{
											structureLinhaBornes = LinhaBorne[j + 1];
											LinhaBorne[j + 1] = LinhaBorne[j];
											LinhaBorne[j] = structureLinhaBornes;
										}
										if (LinhaBorne[j].IndexRegua == LinhaBorne[j + 1].IndexRegua && LinhaBorne[j].InsertionPoint.Y == LinhaBorne[j + 1].InsertionPoint.Y && LinhaBorne[j].InsertionPoint.X > LinhaBorne[j + 1].InsertionPoint.X)
										{
											structureLinhaBornes = LinhaBorne[j + 1];
											LinhaBorne[j + 1] = LinhaBorne[j];
											LinhaBorne[j] = structureLinhaBornes;
										}
									}
								}
							}
						}
						DeclaracoesGeral.bAnularEventos = true;
						val7.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
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
			return num2;
		}
	}

	public static long SELCarregaosBornesDaPaginaV(ref StructureLinhaBornes[] LinhaBorne, string sPagina, ref clsBornes.BornesTipo[] BornesTipo)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected Obj, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected Obj, but got Unknown
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Expected Obj, but got Unknown
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0425: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_043e: Expected Obj, but got Unknown
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0445: Expected Obj, but got Unknown
		//IL_0470: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Invalid comparison between Unknown and I4
		//IL_0493: Unknown result type (might be due to invalid IL or missing references)
		//IL_049a: Expected Obj, but got Unknown
		//IL_049a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected Obj, but got Unknown
		//IL_0791: Unknown result type (might be due to invalid IL or missing references)
		//IL_0797: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d7: Expected Obj, but got Unknown
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_055c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0563: Expected Obj, but got Unknown
		//IL_05a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0611: Unknown result type (might be due to invalid IL or missing references)
		//IL_0616: Unknown result type (might be due to invalid IL or missing references)
		//IL_0621: Unknown result type (might be due to invalid IL or missing references)
		//IL_0626: Unknown result type (might be due to invalid IL or missing references)
		//IL_0638: Unknown result type (might be due to invalid IL or missing references)
		//IL_063d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0662: Unknown result type (might be due to invalid IL or missing references)
		//IL_0667: Unknown result type (might be due to invalid IL or missing references)
		//IL_0686: Unknown result type (might be due to invalid IL or missing references)
		//IL_068b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0696: Unknown result type (might be due to invalid IL or missing references)
		//IL_069b: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_06da: Unknown result type (might be due to invalid IL or missing references)
		//IL_06df: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_074d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0752: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		BornesTipo = new clsBornes.BornesTipo[1];
		BornesTipo[0].Nome = "";
		long num2 = 0L;
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
					DeclaracoesGeral._uscPagina.Quantidade = clsBlocos.AcadObjectCount();
					DeclaracoesGeral._uscPagina.pbIniciar();
					int num3 = 0;
					List<string> list = new List<string>();
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
							if (Operators.CompareString(ent.Layer, sPagina, TextCompare: true) == 0)
							{
								string tipoImportado = "";
								string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
								if ((Operators.CompareString(left, "B", TextCompare: true) == 0) | ((Operators.CompareString(tipoImportado, "B", TextCompare: true) == 0) & (Operators.CompareString(left, "I", TextCompare: true) == 0)))
								{
									DeclaracoesEntidades.StructureBorne structureBorne = default;
									BlockReference blockRef = (BlockReference)ent;
									object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									ent = (Entity)(object)blockRef;
									object obj2 = obj;
									structureBorne = ((obj2 == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj2));
									BlockReference val5 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
									if (!list.Contains(val5.Name))
									{
										list.Add(val5.Name);
										Point3d xIni = new Point3d(0.0, 0.0, 0.0);
										Point3d xFim = new Point3d(0.0, 0.0, 0.0);
										if (BuscaBornesDaPagina(val5, ref xIni, ref xFim, "V"))
										{
											if (Operators.CompareString(BornesTipo[num].Nome, "", TextCompare: true) != 0)
											{
												num++;
											}
											BornesTipo = (clsBornes.BornesTipo[])Utils.CopyArray(BornesTipo, new clsBornes.BornesTipo[num + 1]);
											BornesTipo[num].Nome = val5.Name;
											xIni = new Point3d(Math.Round(xIni.X, 5), Math.Round(xIni.Y, 5), 0.0);
											xFim = new Point3d(Math.Round(xFim.X, 5), Math.Round(xFim.Y, 5), 0.0);
											BornesTipo[num].iIni = xIni;
											BornesTipo[num].iFim = xFim;
										}
									}
								}
							}
							num3++;
							if (num3 == 100)
							{
								DeclaracoesGeral._uscPagina.pbPasso(num3);
								num3 = 0;
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
					DeclaracoesGeral._uscPagina.pbFim();
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
			DocumentLock val6 = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database2 = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val7 = database2.TransactionManager.StartTransaction();
				try
				{
					BlockTable val8 = (BlockTable)val7.GetObject(database2.BlockTableId, (OpenMode)0);
					_ = (BlockTableRecord)val7.GetObject(((SymbolTable)val8)[BlockTableRecord.ModelSpace], (OpenMode)1);
					Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
					TypedValue[] array = new TypedValue[5];
					array.SetValue((object)new TypedValue(0, (object)"INSERT"), 0);
					array.SetValue((object)new TypedValue(-4, (object)"<OR"), 1);
					array.SetValue((object)new TypedValue(1001, (object)"DISPOSITIVO"), 2);
					array.SetValue((object)new TypedValue(1001, (object)"IMPORTADO"), 3);
					array.SetValue((object)new TypedValue(-4, (object)"OR>"), 4);
					SelectionFilter val9 = new SelectionFilter(array);
					PromptSelectionOptions val10 = new PromptSelectionOptions();
					val10.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1370]);
					PromptSelectionResult selection = editor.GetSelection(val10, val9);
					if (unchecked((int)selection.Status) == 5100)
					{
						SelectionSet value = selection.Value;
						ObjectIdCollection val11 = new ObjectIdCollection(value.GetObjectIds());
						new ObjectIdCollection();
						new List<double>();
						foreach (object item in val11)
						{
							ObjectId val12 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							Entity ent2 = (Entity)val12.GetObject((OpenMode)0);
							if (Operators.CompareString(ent2.Layer, DeclaracoesGeral.ativo.Pagina, TextCompare: true) != 0)
							{
								continue;
							}
							BlockReference val13 = (BlockReference)(object)((ent2 is BlockReference) ? ent2 : null);
							if (val13 == null)
							{
								continue;
							}
							string tipoImportado2 = "";
							string left2 = XDataDispositivo.verificaTipoDispositivo(ref ent2, ref tipoImportado2);
							if ((Operators.CompareString(left2, "B", TextCompare: true) == 0) | ((Operators.CompareString(tipoImportado2, "B", TextCompare: true) == 0) & (Operators.CompareString(left2, "I", TextCompare: true) == 0)))
							{
								DeclaracoesEntidades.StructureBorne structureBorne2 = default;
								BlockReference blockRef = (BlockReference)ent2;
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								ent2 = (Entity)(object)blockRef;
								object obj3 = obj;
								structureBorne2 = ((obj3 == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj3));
								BlockReference val14 = (BlockReference)(object)((ent2 is BlockReference) ? ent2 : null);
								Point3d val15 = new Point3d(0.0, 0.0, 0.0);
								Point3d val16 = new Point3d(0.0, 0.0, 0.0);
								if (H9gThl5vQ0(val14.Name, BornesTipo, ref val15, ref val16))
								{
									int num4 = Information.UBound(LinhaBorne) + 1;
									LinhaBorne = (StructureLinhaBornes[])Utils.CopyArray(LinhaBorne, new StructureLinhaBornes[num4 + 1]);
									ref StructureLinhaBornes reference = ref LinhaBorne[num4];
									Point3d position = val14.Position;
									double x = position.X;
									position = val14.Position;
									reference.InsertionPoint = new Point3d(x, position.Y, 0.0);
									LinhaBorne[num4].term = structureBorne2.Numero;
									LinhaBorne[num4].Handle = ((object)((DBObject)ent2).Handle/*cast due to constrained. prefix*/).ToString();
									ref StructureLinhaBornes reference2 = ref LinhaBorne[num4];
									position = val14.Position;
									double x2 = position.X;
									position = val14.Position;
									reference2.ptIni = new Point3d(x2, position.Y + val15.Y, 0.0);
									ref StructureLinhaBornes reference3 = ref LinhaBorne[num4];
									position = val14.Position;
									double x3 = position.X;
									position = val14.Position;
									reference3.ptFim = new Point3d(x3, position.Y - val16.Y, 0.0);
									LinhaBorne[num4].x = val15.X;
									LinhaBorne[num4].y = val15.Y;
									LinhaBorne[num4].IndexRegua = structureBorne2.IndiceRegua;
									ref StructureLinhaBornes reference4 = ref LinhaBorne[num4];
									string sHandle = ((object)((DBObject)ent2).Handle/*cast due to constrained. prefix*/).ToString();
									reference4.btitulo = clsBlocos.AtributoVisivelDeUmBloco(ref sHandle, "NOME1");
									num2++;
								}
							}
						}
						if (num2 > 0L)
						{
							StructureLinhaBornes structureLinhaBornes = default;
							if (Information.UBound(LinhaBorne) >= 2 && Information.UBound(LinhaBorne) > 0)
							{
								int num5 = Information.UBound(LinhaBorne);
								for (int i = 1; i <= num5; i++)
								{
									int num6 = Information.UBound(LinhaBorne) - 1;
									int num7 = i;
									for (int j = num6; j >= num7; j += -1)
									{
										if (LinhaBorne[j].IndexRegua > LinhaBorne[j + 1].IndexRegua)
										{
											structureLinhaBornes = LinhaBorne[j + 1];
											LinhaBorne[j + 1] = LinhaBorne[j];
											LinhaBorne[j] = structureLinhaBornes;
										}
										if (LinhaBorne[j].IndexRegua == LinhaBorne[j + 1].IndexRegua && LinhaBorne[j].InsertionPoint.X > LinhaBorne[j + 1].InsertionPoint.X)
										{
											structureLinhaBornes = LinhaBorne[j + 1];
											LinhaBorne[j + 1] = LinhaBorne[j];
											LinhaBorne[j] = structureLinhaBornes;
										}
										if (LinhaBorne[j].IndexRegua == LinhaBorne[j + 1].IndexRegua && LinhaBorne[j].InsertionPoint.X == LinhaBorne[j + 1].InsertionPoint.X && LinhaBorne[j].InsertionPoint.Y < LinhaBorne[j + 1].InsertionPoint.Y)
										{
											structureLinhaBornes = LinhaBorne[j + 1];
											LinhaBorne[j + 1] = LinhaBorne[j];
											LinhaBorne[j] = structureLinhaBornes;
										}
									}
								}
							}
						}
						DeclaracoesGeral.bAnularEventos = true;
						val7.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
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
			return num2;
		}
	}

	private static bool H9gThl5vQ0(string P_0, clsBornes.BornesTipo[] P_1, ref Point3d P_2, ref Point3d P_3)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		int num = Information.UBound(P_1);
		for (int i = 0; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(P_1[i].Nome, P_0, TextCompare: true) == 0)
			{
				P_2 = P_1[i].iIni;
				P_3 = P_1[i].iFim;
				result = true;
				break;
			}
		}
		return result;
	}

	public static void carregaLinhaNovaH(int IndexRegua, double y, ref StructureLinhaBornes[] LinhaEntreBornes, ref StructureLinhaBornes[] CriarLinhaBorne)
	{
		CriarLinhaBorne = new StructureLinhaBornes[1];
		int num = Information.UBound(LinhaEntreBornes);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				if ((LinhaEntreBornes[i].IndexRegua == IndexRegua) & (Math.Round(LinhaEntreBornes[i].InsertionPoint.Y, 5) == Math.Round(y, 5)))
				{
					int num2 = Information.UBound(CriarLinhaBorne) + 1;
					CriarLinhaBorne = (StructureLinhaBornes[])Utils.CopyArray(CriarLinhaBorne, new StructureLinhaBornes[num2 + 1]);
					CriarLinhaBorne[num2] = LinhaEntreBornes[i];
					LinhaEntreBornes[i].IndexRegua = 0;
				}
			}
			StructureLinhaBornes structureLinhaBornes = default;
			if (Information.UBound(CriarLinhaBorne) < 2)
			{
				return;
			}
			int num3 = Information.UBound(CriarLinhaBorne);
			for (int j = 1; j <= num3; j++)
			{
				int num4 = Information.UBound(CriarLinhaBorne) - 1;
				int num5 = j;
				for (int k = num4; k >= num5; k += -1)
				{
					if (Math.Round(CriarLinhaBorne[k].InsertionPoint.X, 5) > Math.Round(CriarLinhaBorne[k + 1].InsertionPoint.X, 5))
					{
						structureLinhaBornes = CriarLinhaBorne[k + 1];
						CriarLinhaBorne[k + 1] = CriarLinhaBorne[k];
						CriarLinhaBorne[k] = structureLinhaBornes;
					}
				}
			}
		}
	}

	public static void carregaLinhaNovaV(int IndexRegua, double y, StructureLinhaBornes[] LinhaEntreBornes, ref StructureLinhaBornes[] CriarLinhaBorne)
	{
		CriarLinhaBorne = new StructureLinhaBornes[1];
		int num = Information.UBound(LinhaEntreBornes);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				if ((LinhaEntreBornes[i].IndexRegua == IndexRegua) & (Math.Round(LinhaEntreBornes[i].InsertionPoint.X, 5) == y))
				{
					int num2 = Information.UBound(CriarLinhaBorne) + 1;
					CriarLinhaBorne = (StructureLinhaBornes[])Utils.CopyArray(CriarLinhaBorne, new StructureLinhaBornes[num2 + 1]);
					CriarLinhaBorne[num2] = LinhaEntreBornes[i];
				}
			}
			StructureLinhaBornes structureLinhaBornes = default;
			if (Information.UBound(CriarLinhaBorne) < 2)
			{
				return;
			}
			int num3 = Information.UBound(CriarLinhaBorne);
			for (int j = 1; j <= num3; j++)
			{
				int num4 = Information.UBound(CriarLinhaBorne) - 1;
				int num5 = j;
				for (int k = num4; k >= num5; k += -1)
				{
					if (Math.Round(CriarLinhaBorne[k].InsertionPoint.Y, 5) < Math.Round(CriarLinhaBorne[k + 1].InsertionPoint.Y, 5))
					{
						structureLinhaBornes = CriarLinhaBorne[k + 1];
						CriarLinhaBorne[k + 1] = CriarLinhaBorne[k];
						CriarLinhaBorne[k] = structureLinhaBornes;
					}
				}
			}
		}
	}

	public static void InsereAsLinhasH(ref StructureLinhaBornes[] LinhaBorne, string sPagina, double dI, double dM, double dF)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04da: Unknown result type (might be due to invalid IL or missing references)
		//IL_04df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0513: Unknown result type (might be due to invalid IL or missing references)
		//IL_0518: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Expected Obj, but got Unknown
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_054e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0553: Unknown result type (might be due to invalid IL or missing references)
		//IL_0588: Unknown result type (might be due to invalid IL or missing references)
		//IL_058d: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
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
					bool flag = true;
					bool flag2 = false;
					bool flag3 = false;
					bool flag4 = false;
					Point3d val5 = new Point3d(0.0, 0.0, 0.0);
					Point3d val6 = new Point3d(0.0, 0.0, 0.0);
					int num = 0;
					string text = "I";
					int num2 = Information.UBound(LinhaBorne);
					for (num = 1; num <= num2; num++)
					{
						while (true)
						{
							flag4 = false;
							if (!flag)
							{
								double num3 = clsBornes.BuscaTamanhodoBorneH(LinhaBorne[num].Handle, 2);
								text = "M";
								if (Information.UBound(LinhaBorne) != 1)
								{
									if (flag2)
									{
										val5 = new Point3d(LinhaBorne[num + 1].ptFim.X, LinhaBorne[num].ptFim.Y, 0.0);
										val6 = new Point3d(LinhaBorne[num + 1].ptFim.X + 5.0, LinhaBorne[num].ptFim.Y, 0.0);
										text = "F";
									}
									else
									{
										val5 = new Point3d(LinhaBorne[num].ptFim.X, LinhaBorne[num].ptFim.Y, 0.0);
										val6 = new Point3d(LinhaBorne[num + 1].ptIni.X, LinhaBorne[num + 1].ptIni.Y, 0.0);
									}
								}
								else
								{
									val5 = new Point3d(LinhaBorne[num].ptFim.X, LinhaBorne[num].ptFim.Y, 0.0);
									val6 = new Point3d(LinhaBorne[num].ptFim.X + num3, LinhaBorne[num].ptFim.Y, 0.0);
								}
							}
							else
							{
								text = "I";
								double num4 = clsBornes.BuscaTamanhodoBorneH(LinhaBorne[num].Handle, 1);
								if (Information.UBound(LinhaBorne) != 1)
								{
									val5 = new Point3d(LinhaBorne[num].ptIni.X - num4, LinhaBorne[num].ptIni.Y, 0.0);
									val6 = new Point3d(LinhaBorne[num].ptIni.X, LinhaBorne[num].ptIni.Y, 0.0);
								}
								else
								{
									val5 = new Point3d(LinhaBorne[num].ptIni.X - num4, LinhaBorne[num].ptIni.Y, 0.0);
									val6 = new Point3d(LinhaBorne[num].ptIni.X, LinhaBorne[num].ptIni.Y, 0.0);
								}
								flag = false;
								flag4 = true;
							}
							double[] array = new double[3];
							double[] array2 = new double[3];
							array[0] = val5[0];
							array[1] = val5[1];
							array[2] = 0.0;
							array2[0] = val6[0];
							array2[1] = val6[1];
							array2[2] = 0.0;
							Polyline pl = new Polyline();
							((Entity)pl).SetDatabaseDefaults();
							Point2d val7 = new Point2d(array[0], array[1]);
							Point2d val8 = new Point2d(array2[0], array2[1]);
							((Entity)pl).ColorIndex = DeclaracoesGeral.Conf.CorConexao;
							pl.AddVertexAt(0, val7, 0.0, 0.0, 0.0);
							pl.AddVertexAt(1, val8, 0.0, 0.0, 0.0);
							string left = text;
							if (Operators.CompareString(left, "I", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "M", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left, "F", TextCompare: true) == 0)
									{
										((Entity)pl).LinetypeScale = dF;
									}
								}
								else
								{
									((Entity)pl).LinetypeScale = dM;
								}
							}
							else
							{
								((Entity)pl).LinetypeScale = dI;
							}
							((Entity)pl).Layer = sPagina;
							((Entity)pl).LineWeight = (LineWeight)30;
							((Entity)pl).Linetype = "DASHDOT";
							val4.AppendEntity((Entity)(object)pl);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)pl, true);
							XDataDispositivosMaster.GravarXDataAuxBornes(ref pl);
							if (flag3)
							{
								break;
							}
							if (!flag4)
							{
								if (LinhaBorne[num].IndexRegua != LinhaBorne[num].IndexRegua)
								{
									flag = true;
								}
								if ((LinhaBorne[num].IndexRegua == LinhaBorne[num].IndexRegua) & (LinhaBorne[num].ptFim.X != LinhaBorne[num].ptFim.X))
								{
									flag = true;
								}
								if (num != Information.UBound(LinhaBorne) - 1)
								{
									goto IL_028c;
								}
								flag2 = true;
								flag3 = true;
							}
						}
						break;
						IL_028c:;
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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

	public static void InsereAsLinhasV(ref StructureLinhaBornes[] LinhaBorne, string sPagina, clsBornes.BornesTipo[] BornesTipo, double dI, double dM, double dF)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Unknown result type (might be due to invalid IL or missing references)
		//IL_0455: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Unknown result type (might be due to invalid IL or missing references)
		//IL_0495: Unknown result type (might be due to invalid IL or missing references)
		//IL_0507: Unknown result type (might be due to invalid IL or missing references)
		//IL_050c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0543: Unknown result type (might be due to invalid IL or missing references)
		//IL_0548: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Expected Obj, but got Unknown
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
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
					bool flag = true;
					bool flag2 = false;
					bool flag3 = false;
					Point3d val5 = new Point3d(0.0, 0.0, 0.0);
					Point3d val6 = new Point3d(0.0, 0.0, 0.0);
					int num = 0;
					string text = "I";
					int num2 = Information.UBound(LinhaBorne);
					for (num = 1; num <= num2; num++)
					{
						while (true)
						{
							flag3 = false;
							if (!flag)
							{
								text = "M";
								double num3 = clsBornes.BuscaTamanhodoBorneV(LinhaBorne[num].Handle, 2);
								if (Information.UBound(LinhaBorne) != num)
								{
									if (num == Information.UBound(LinhaBorne))
									{
										text = "F";
										val5 = new Point3d(LinhaBorne[num + 1].ptFim.X, LinhaBorne[num].ptFim.Y, 0.0);
										val6 = new Point3d(LinhaBorne[num + 1].ptFim.X, LinhaBorne[num].ptFim.Y - 5.0, 0.0);
									}
									else
									{
										val5 = new Point3d(LinhaBorne[num].ptFim.X + LinhaBorne[num].x, LinhaBorne[num].ptFim.Y - LinhaBorne[num].y * 2.0, 0.0);
										val6 = new Point3d(LinhaBorne[num + 1].ptIni.X + LinhaBorne[num].x, LinhaBorne[num + 1].ptIni.Y, 0.0);
									}
								}
								else
								{
									double num4 = clsBornes.BuscaTamanhodoBorneMeioH(LinhaBorne[num].Handle, 2);
									double num5 = clsBornes.BuscaTamanhodoBorneV(LinhaBorne[num].Handle, 2);
									val5 = new Point3d(LinhaBorne[num].ptFim.X + num4, LinhaBorne[num].ptFim.Y - num5 / 2.0, 0.0);
									val6 = new Point3d(LinhaBorne[num].ptIni.X + num4, LinhaBorne[num].ptIni.Y - num3, 0.0);
								}
							}
							else
							{
								text = "I";
								double num6 = clsBornes.BuscaTamanhodoBorneH(LinhaBorne[num].Handle, 1);
								clsBornes.BuscaTamanhodoBorneV(LinhaBorne[num].Handle, 2);
								if (num == 1)
								{
									val5 = new Point3d(LinhaBorne[num].ptIni.X - num6 - 1.0, LinhaBorne[num].ptIni.Y, 0.0);
									val6 = new Point3d(LinhaBorne[num].ptFim.X + 1.0, LinhaBorne[num].ptIni.Y, 0.0);
								}
								flag = false;
								flag3 = true;
							}
							double[] array = new double[3];
							double[] array2 = new double[3];
							array[0] = val5[0];
							array[1] = val5[1];
							array[2] = 0.0;
							array2[0] = val6[0];
							array2[1] = val6[1];
							array2[2] = 0.0;
							Polyline pl = new Polyline();
							((Entity)pl).SetDatabaseDefaults();
							Point2d val7 = new Point2d(array[0], array[1]);
							Point2d val8 = new Point2d(array2[0], array2[1]);
							((Entity)pl).ColorIndex = DeclaracoesGeral.Conf.CorConexao;
							pl.AddVertexAt(0, val7, 0.0, 0.0, 0.0);
							pl.AddVertexAt(1, val8, 0.0, 0.0, 0.0);
							string left = text;
							if (Operators.CompareString(left, "I", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "M", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left, "F", TextCompare: true) == 0)
									{
										((Entity)pl).LinetypeScale = dF;
									}
								}
								else
								{
									((Entity)pl).LinetypeScale = dM;
								}
							}
							else
							{
								((Entity)pl).LinetypeScale = dI;
							}
							((Entity)pl).Layer = sPagina;
							((Entity)pl).LineWeight = (LineWeight)30;
							((Entity)pl).Linetype = "DASHDOT";
							if (val7.Y - val8.Y < 15.0)
							{
								((Entity)pl).LinetypeScale = 0.5;
							}
							val4.AppendEntity((Entity)(object)pl);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)pl, true);
							XDataDispositivosMaster.GravarXDataAuxBornes(ref pl);
							if (num == Information.UBound(LinhaBorne) - 1 || flag2)
							{
								break;
							}
							if (!flag3)
							{
								if (LinhaBorne[num].IndexRegua != LinhaBorne[num].IndexRegua)
								{
									flag = true;
								}
								if ((LinhaBorne[num].IndexRegua == LinhaBorne[num].IndexRegua) & (LinhaBorne[num].ptFim.X != LinhaBorne[num].ptFim.X))
								{
									flag = true;
								}
								if (num != Information.UBound(LinhaBorne) - 1)
								{
									goto IL_02c6;
								}
								flag2 = true;
							}
						}
						break;
						IL_02c6:;
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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

	public static void ApagaLinhaAuxBornes(ref string sPagina)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected Obj, but got Unknown
		try
		{
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
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
								if (Operators.CompareString(Ent.Layer.ToString(), sPagina, TextCompare: true) == 0 && XDataDispositivosMaster.LerXDataAuxBornes(ref Ent))
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
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						val2.Abort();
						ProjectData.ClearProjectError();
					}
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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
		finally
		{
		}
	}

	public static void CriaEstiloDeLinha()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				LinetypeTable val3 = (LinetypeTable)val2.GetObject(database.LinetypeTableId, (OpenMode)0);
				string text = "DashDot";
				if (!((SymbolTable)val3).Has(text))
				{
					database.LoadLineTypeFile(text, "acadiso.lin");
					database.Ltscale = 1.0;
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

	public static void ApagaLinhaErro(List<string> lErros)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected Obj, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
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
								Entity val5 = (Entity)val2.GetObject(current, (OpenMode)1);
								if (lErros.Contains(((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString()))
								{
									((DBObject)val5).UpgradeOpen();
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
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						val2.Abort();
						ProjectData.ClearProjectError();
					}
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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
		finally
		{
		}
	}
}
