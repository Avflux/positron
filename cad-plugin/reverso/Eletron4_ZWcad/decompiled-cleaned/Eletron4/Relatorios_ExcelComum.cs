using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public class Relatorios_ExcelComum
{
	public static void BuscaIndiceSSheetExcel(ref Application OExcel, List<string> lExcecao)
	{
		checked
		{
			try
			{
				int num = default;
				FiacaoExcel.mIndiceExcel = new FiacaoExcel.StructureIndiceRelatorio[num + 1];
				if (OExcel.Workbooks.Count <= 0)
				{
					return;
				}
				Workbook activeWorkbook = OExcel.ActiveWorkbook;
				int count = activeWorkbook.Sheets.Count;
				for (int i = 1; i <= count; i++)
				{
					if (!lExcecao.Contains(Conversions.ToString(NewLateBinding.LateGet(activeWorkbook.Worksheets[i], null, "Name", new object[0], null, null, null))))
					{
						num++;
						FiacaoExcel.mIndiceExcel = (FiacaoExcel.StructureIndiceRelatorio[])Utils.CopyArray(FiacaoExcel.mIndiceExcel, new FiacaoExcel.StructureIndiceRelatorio[num + 1]);
						FiacaoExcel.mIndiceExcel[num].sFolha = Conversions.ToString(i);
						FiacaoExcel.mIndiceExcel[num].sDescricao = Conversions.ToString(NewLateBinding.LateGet(activeWorkbook.Worksheets[i], null, "Name", new object[0], null, null, null));
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}
}
