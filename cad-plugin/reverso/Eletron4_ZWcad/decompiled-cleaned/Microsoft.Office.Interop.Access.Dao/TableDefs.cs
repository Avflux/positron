using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Access.Dao;

[ComImport]
[CompilerGenerated]
[Guid("0000004B-0000-0010-8000-00AA006D2EA4")]
[TypeIdentifier]
public interface TableDefs : _DynaCollection
{
	void _VtblGap1_5();

	[DispId(0)]
	TableDef this[[In][MarshalAs(UnmanagedType.Struct)] object Item]
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}
}
