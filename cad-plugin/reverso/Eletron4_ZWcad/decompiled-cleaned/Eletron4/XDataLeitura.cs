using System.Runtime.CompilerServices;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

public class XDataLeitura
{
	public static bool lexDataDaEntity1(ref Entity ent, string sNomexData, int iIndicexData, ref object oValor)
	{
		bool result = false;
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)ent).GetXDataForApplication(sNomexData);
		if (val == null)
		{
			val = ((DBObject)ent).GetXDataForApplication(sNomexData.ToUpper());
			if (val != null)
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
			TypedValue[] array = val.AsArray();
			oValor = RuntimeHelpers.GetObjectValue(array[iIndicexData].Value);
			result = true;
		}
		return result;
	}

	public static bool lexDataDaEntity2(ref Entity ent, string sNomexData, int iIndicexData1, int iIndicexData2, ref object oValor1, ref object oValor2)
	{
		bool result = false;
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)ent).GetXDataForApplication(sNomexData);
		if (val == null)
		{
			val = ((DBObject)ent).GetXDataForApplication(sNomexData.ToUpper());
			if (val != null)
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
			TypedValue[] array = val.AsArray();
			oValor1 = RuntimeHelpers.GetObjectValue(array[iIndicexData1].Value);
			oValor2 = RuntimeHelpers.GetObjectValue(array[iIndicexData2].Value);
			result = true;
		}
		return result;
	}

	public static bool lexDataDaEntity3(ref Entity ent, string sNomexData, int iIndicexData1, int iIndicexData2, int iIndicexData3, ref object oValor1, ref object oValor2, ref object oValor3)
	{
		bool result = false;
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)ent).GetXDataForApplication(sNomexData);
		if (val == null)
		{
			val = ((DBObject)ent).GetXDataForApplication(sNomexData.ToUpper());
			if (val != null)
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
			TypedValue[] array = val.AsArray();
			oValor1 = RuntimeHelpers.GetObjectValue(array[iIndicexData1].Value);
			oValor2 = RuntimeHelpers.GetObjectValue(array[iIndicexData2].Value);
			oValor3 = RuntimeHelpers.GetObjectValue(array[iIndicexData3].Value);
			result = true;
		}
		return result;
	}

	public static bool lexDataDaEntity4(ref Entity ent, string sNomexData, int iIndicexData1, int iIndicexData2, int iIndicexData3, int iIndicexData4, ref object oValor1, ref object oValor2, ref object oValor3, ref object oValor4)
	{
		bool result = false;
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)ent).GetXDataForApplication(sNomexData);
		if (val == null)
		{
			val = ((DBObject)ent).GetXDataForApplication(sNomexData.ToUpper());
			if (val != null)
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
			TypedValue[] array = val.AsArray();
			oValor1 = RuntimeHelpers.GetObjectValue(array[iIndicexData1].Value);
			oValor2 = RuntimeHelpers.GetObjectValue(array[iIndicexData2].Value);
			oValor3 = RuntimeHelpers.GetObjectValue(array[iIndicexData3].Value);
			oValor4 = RuntimeHelpers.GetObjectValue(array[iIndicexData4].Value);
			result = true;
		}
		return result;
	}

	public static bool lexDataDaEntity5(ref Entity ent, string sNomexData, int iIndicexData1, int iIndicexData2, int iIndicexData3, int iIndicexData4, int iIndicexData5, ref object oValor1, ref object oValor2, ref object oValor3, ref object oValor4, ref object oValor5)
	{
		bool result = false;
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)ent).GetXDataForApplication(sNomexData);
		if (val == null)
		{
			val = ((DBObject)ent).GetXDataForApplication(sNomexData.ToUpper());
			if (val != null)
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
			TypedValue[] array = val.AsArray();
			oValor1 = RuntimeHelpers.GetObjectValue(array[iIndicexData1].Value);
			oValor2 = RuntimeHelpers.GetObjectValue(array[iIndicexData2].Value);
			oValor3 = RuntimeHelpers.GetObjectValue(array[iIndicexData3].Value);
			oValor4 = RuntimeHelpers.GetObjectValue(array[iIndicexData4].Value);
			oValor5 = RuntimeHelpers.GetObjectValue(array[iIndicexData5].Value);
			result = true;
		}
		return result;
	}

	public static bool lexDataDaEntity6(ref Entity ent, string sNomexData, int iIndicexData1, int iIndicexData2, int iIndicexData3, int iIndicexData4, int iIndicexData5, int iIndicexData6, ref object oValor1, ref object oValor2, ref object oValor3, ref object oValor4, ref object oValor5, ref object oValor6)
	{
		bool result = false;
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)ent).GetXDataForApplication(sNomexData);
		if (val == null)
		{
			val = ((DBObject)ent).GetXDataForApplication(sNomexData.ToUpper());
			if (val != null)
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
			TypedValue[] array = val.AsArray();
			oValor1 = RuntimeHelpers.GetObjectValue(array[iIndicexData1].Value);
			oValor2 = RuntimeHelpers.GetObjectValue(array[iIndicexData2].Value);
			oValor3 = RuntimeHelpers.GetObjectValue(array[iIndicexData3].Value);
			oValor4 = RuntimeHelpers.GetObjectValue(array[iIndicexData4].Value);
			oValor5 = RuntimeHelpers.GetObjectValue(array[iIndicexData5].Value);
			oValor6 = RuntimeHelpers.GetObjectValue(array[iIndicexData6].Value);
			result = true;
		}
		return result;
	}

	public static bool lexDataDaEntity7(ref Entity ent, string sNomexData, int iIndicexData1, int iIndicexData2, int iIndicexData3, int iIndicexData4, int iIndicexData5, int iIndicexData6, int iIndicexData7, ref object oValor1, ref object oValor2, ref object oValor3, ref object oValor4, ref object oValor5, ref object oValor6, ref object oValor7)
	{
		bool result = false;
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)ent).GetXDataForApplication(sNomexData);
		if (val == null)
		{
			val = ((DBObject)ent).GetXDataForApplication(sNomexData.ToUpper());
			if (val != null)
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
			TypedValue[] array = val.AsArray();
			oValor1 = RuntimeHelpers.GetObjectValue(array[iIndicexData1].Value);
			oValor2 = RuntimeHelpers.GetObjectValue(array[iIndicexData2].Value);
			oValor3 = RuntimeHelpers.GetObjectValue(array[iIndicexData3].Value);
			oValor4 = RuntimeHelpers.GetObjectValue(array[iIndicexData4].Value);
			oValor5 = RuntimeHelpers.GetObjectValue(array[iIndicexData5].Value);
			oValor6 = RuntimeHelpers.GetObjectValue(array[iIndicexData6].Value);
			oValor7 = RuntimeHelpers.GetObjectValue(array[iIndicexData7].Value);
			result = true;
		}
		return result;
	}

	public static bool lexDataDaEntity8(ref Entity ent, string sNomexData, int iIndicexData1, int iIndicexData2, int iIndicexData3, int iIndicexData4, int iIndicexData5, int iIndicexData6, int iIndicexData7, int iIndicexData8, ref object oValor1, ref object oValor2, ref object oValor3, ref object oValor4, ref object oValor5, ref object oValor6, ref object oValor7, ref object oValor8)
	{
		bool result = false;
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)ent).GetXDataForApplication(sNomexData);
		if (val == null)
		{
			val = ((DBObject)ent).GetXDataForApplication(sNomexData.ToUpper());
			if (val != null)
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
			TypedValue[] array = val.AsArray();
			oValor1 = RuntimeHelpers.GetObjectValue(array[iIndicexData1].Value);
			oValor2 = RuntimeHelpers.GetObjectValue(array[iIndicexData2].Value);
			oValor3 = RuntimeHelpers.GetObjectValue(array[iIndicexData3].Value);
			oValor4 = RuntimeHelpers.GetObjectValue(array[iIndicexData4].Value);
			oValor5 = RuntimeHelpers.GetObjectValue(array[iIndicexData5].Value);
			oValor6 = RuntimeHelpers.GetObjectValue(array[iIndicexData6].Value);
			oValor7 = RuntimeHelpers.GetObjectValue(array[iIndicexData7].Value);
			oValor8 = RuntimeHelpers.GetObjectValue(array[iIndicexData8].Value);
			result = true;
		}
		return result;
	}
}
