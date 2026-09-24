using System.Drawing;
using System.IO;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Runtime;

namespace YhamV21aratNE3b4GFK;

internal class RevJqj1qBkVn9MRpOU0
{
	public static Bitmap tiC18lyNXK(string P_0)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected Obj, but got Unknown
		Bitmap result = null;
		if (Operators.CompareString(P_0.Trim(), "", TextCompare: true) != 0)
		{
			Database val = new Database(false, true);
			val.ReadDwgFile(P_0, FileShare.Read, false, "");
			result = val.ThumbnailBitmap;
			((DisposableWrapper)val).Dispose();
		}
		return result;
	}
}
