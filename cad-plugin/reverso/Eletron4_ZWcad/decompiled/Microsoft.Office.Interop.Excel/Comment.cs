using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel;

[ComImport]
[TypeIdentifier]
[InterfaceType(2)]
[CompilerGenerated]
[Guid("00024427-0000-0000-C000-000000000046")]
public interface Comment
{
	void _VtblGap1_4();

	[DispId(1582)]
	Shape Shape
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1582)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(558)]
	bool Visible
	{
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(558)]
		get;
		[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(558)]
		set;
	}

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(138)]
	[return: MarshalAs(UnmanagedType.BStr)]
	string Text([Optional][In][MarshalAs(UnmanagedType.Struct)] object Text, [Optional][In][MarshalAs(UnmanagedType.Struct)] object Start, [Optional][In][MarshalAs(UnmanagedType.Struct)] object Overwrite);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(117)]
	void Delete();
}
