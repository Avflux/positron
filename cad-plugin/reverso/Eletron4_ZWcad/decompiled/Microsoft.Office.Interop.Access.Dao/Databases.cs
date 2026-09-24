using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Access.Dao;

[ComImport]
[TypeIdentifier]
[Guid("00000073-0000-0010-8000-00AA006D2EA4")]
[CompilerGenerated]
public interface Databases : _Collection
{
	void _VtblGap1_3();

	[DispId(0)]
	Database this[[In][MarshalAs(UnmanagedType.Struct)] object Item]
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}
}
