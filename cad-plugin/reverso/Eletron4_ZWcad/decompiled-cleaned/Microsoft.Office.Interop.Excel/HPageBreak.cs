using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel;

[ComImport]
[CompilerGenerated]
[InterfaceType(2)]
[Guid("00024401-0000-0000-C000-000000000046")]
[TypeIdentifier]
public interface HPageBreak
{
	void _VtblGap1_4();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1420)]
	void DragOff([In] XlDirection Direction, [In] int RegionIndex);
}
