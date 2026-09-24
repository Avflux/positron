using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

[StandardModule]
public sealed class FiacaoExcel
{
	public struct StructureIndiceRelatorio
	{
		public string sFolha;

		public string sDescricao;
	}

	public static StructureIndiceRelatorio[] mIndiceExcel;

	public static int iLinhaInicialRelatorio;

	static FiacaoExcel()
	{
		iLinhaInicialRelatorio = 1;
	}
}
