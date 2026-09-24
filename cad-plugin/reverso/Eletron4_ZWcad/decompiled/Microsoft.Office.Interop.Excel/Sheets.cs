using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel;

[ComImport]
[Guid("000208D7-0000-0000-C000-000000000046")]
[CompilerGenerated]
[TypeIdentifier]
public interface Sheets : IEnumerable
{
	void _VtblGap1_3();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[LCIDConversion(4)]
	[DispId(181)]
	[return: MarshalAs(UnmanagedType.IDispatch)]
	object Add([Optional][In][MarshalAs(UnmanagedType.Struct)] object Before, [Optional][In][MarshalAs(UnmanagedType.Struct)] object After, [Optional][In][MarshalAs(UnmanagedType.Struct)] object Count, [Optional][In][MarshalAs(UnmanagedType.Struct)] object Type);

	void _VtblGap2_1();

	[DispId(118)]
	int Count
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(118)]
		get;
	}

	void _VtblGap3_4();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-4)]
	[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	new IEnumerator GetEnumerator();

	void _VtblGap4_7();

	[IndexerName("_Default")]
	[DispId(0)]
	object this[[In][MarshalAs(UnmanagedType.Struct)] object Index]
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(0)]
		[return: MarshalAs(UnmanagedType.IDispatch)]
		get;
	}
}
