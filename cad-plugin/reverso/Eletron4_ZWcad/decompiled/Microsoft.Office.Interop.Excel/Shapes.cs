using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Excel;

[ComImport]
[Guid("0002443A-0000-0000-C000-000000000046")]
[TypeIdentifier]
[InterfaceType(2)]
[DefaultMember("_Default")]
[CompilerGenerated]
public interface Shapes : IEnumerable
{
	void _VtblGap1_5();

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(0)]
	[return: MarshalAs(UnmanagedType.Interface)]
	Shape _Default([In][MarshalAs(UnmanagedType.Struct)] object Index);

	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(-4)]
	[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "System.Runtime.InteropServices.CustomMarshalers.EnumeratorToEnumVariantMarshaler, CustomMarshalers, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	new IEnumerator GetEnumerator();

	void _VtblGap2_11();

	// C# has no syntax for parameterized property 'Range'.
	// Its 'property:' attributes below are ignored by the compiler (CS0657).
	[property: DispId(197)]
	[MethodImpl(MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(197)]
	[return: MarshalAs(UnmanagedType.Interface)]
	ShapeRange get_Range([In][MarshalAs(UnmanagedType.Struct)] object Index);
}
