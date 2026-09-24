using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel;

[ComImport]
[Guid("000208D8-0000-0000-C000-000000000046")]
[CompilerGenerated]
[TypeIdentifier]
public interface _Worksheet
{
	void _VtblGap1_11();

	[DispId(110)]
	string Name
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(110)]
		[return: MarshalAs(UnmanagedType.BStr)]
		get;
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(110)]
		[param: In]
		[param: MarshalAs(UnmanagedType.BStr)]
		set;
	}

	void _VtblGap2_7();

	[DispId(998)]
	PageSetup PageSetup
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(998)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	void _VtblGap3_13();

	[DispId(1377)]
	Shapes Shapes
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1377)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	void _VtblGap4_10();

	[DispId(238)]
	Range Cells
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(238)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	void _VtblGap5_42();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[LCIDConversion(2)]
	[DispId(211)]
	void Paste([Optional][In][MarshalAs(UnmanagedType.Struct)] object Destination, [Optional][In][MarshalAs(UnmanagedType.Struct)] object Link);

	void _VtblGap6_4();

	// C# has no syntax for parameterized property 'Range'.
	// Its 'property:' attributes below are ignored by the compiler (CS0657).
	[property: DispId(197)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(197)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Range get_Range([In][MarshalAs(UnmanagedType.Struct)] object Cell1, [Optional][In][MarshalAs(UnmanagedType.Struct)] object Cell2);

	void _VtblGap7_17();

	[DispId(1418)]
	HPageBreaks HPageBreaks
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1418)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	[DispId(1419)]
	VPageBreaks VPageBreaks
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(1419)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	void _VtblGap8_21();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[LCIDConversion(7)]
	[DispId(1928)]
	void PasteSpecial([Optional][In][MarshalAs(UnmanagedType.Struct)] object Format, [Optional][In][MarshalAs(UnmanagedType.Struct)] object Link, [Optional][In][MarshalAs(UnmanagedType.Struct)] object DisplayAsIcon, [Optional][In][MarshalAs(UnmanagedType.Struct)] object IconFileName, [Optional][In][MarshalAs(UnmanagedType.Struct)] object IconIndex, [Optional][In][MarshalAs(UnmanagedType.Struct)] object IconLabel, [Optional][In][MarshalAs(UnmanagedType.Struct)] object NoHTMLFormatting);
}
