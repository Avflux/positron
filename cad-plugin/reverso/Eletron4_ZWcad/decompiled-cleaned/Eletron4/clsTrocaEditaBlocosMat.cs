using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

[StandardModule]
public sealed class clsTrocaEditaBlocosMat
{
	public static structureAtributos[] mAtributos;

	public static List<string> lBlocosAlterados;

	public static List<string> lBlocosExistentesTrocados;

	public static string sBlocosNaoExistentes;

	static clsTrocaEditaBlocosMat()
	{
		lBlocosAlterados = new List<string>();
		lBlocosExistentesTrocados = new List<string>();
		sBlocosNaoExistentes = "";
	}
}
