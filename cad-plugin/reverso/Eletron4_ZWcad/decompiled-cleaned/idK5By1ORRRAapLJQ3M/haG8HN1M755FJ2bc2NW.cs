using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace idK5By1ORRRAapLJQ3M;

[StandardModule]
internal sealed class haG8HN1M755FJ2bc2NW
{
	public static bool ARP1IVj2So(DataGridView P_0)
	{
		bool result = false;
		if (P_0.RowCount > 0 && P_0.RowCount > 0)
		{
			foreach (object control in P_0.Controls)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(control);
				if ((object)objectValue.GetType() == typeof(VScrollBar))
				{
					VScrollBar vScrollBar = (VScrollBar)objectValue;
					if (vScrollBar.Visible)
					{
						result = true;
						break;
					}
				}
			}
		}
		return result;
	}

	public static bool Na8179sVA9(DataGridView P_0)
	{
		bool result = false;
		if (P_0.RowCount > 0 && P_0.RowCount > 0)
		{
			foreach (object control in P_0.Controls)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(control);
				if ((object)objectValue.GetType() == typeof(HScrollBar))
				{
					HScrollBar hScrollBar = (HScrollBar)objectValue;
					if (hScrollBar.Visible)
					{
						result = true;
						break;
					}
				}
			}
		}
		return result;
	}
}
