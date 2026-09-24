using System;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

public class clsApagar
{
	public static void ApagarDerivados(ref Entity ent)
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected Obj, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Entity obj = ent;
			Polyline pl = (Polyline)(object)((obj is Polyline) ? obj : null);
			if (pl == null)
			{
				string tipoImportado = "";
				string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
				string left = text;
				if (Operators.CompareString(left, "P", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left, "A", TextCompare: true) != 0)
					{
						if (Operators.CompareString(left, "M", TextCompare: true) == 0)
						{
							clsMascara.ApagaAMascara(ent);
						}
					}
					else
					{
						clsDispositivoAuxiliares.limpaInsercaoTabela(((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString());
					}
					return;
				}
				BlockReference blockRef = (BlockReference)ent;
				object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
				ent = (Entity)(object)blockRef;
				if (((obj2 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj2)).indexModelo <= 0)
				{
					clsDispositivo.promoveComplementar(ent);
				}
				else
				{
					clsDispositivo.ApagaContatosModeloDispositivo(ent);
				}
			}
			else
			{
				DeclaracoesEntidades.StructureInterligacao ilig = default;
				if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) && ilig.Tipo == 2)
				{
					clsInterligacao.ApagarPL(ilig.handle);
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
