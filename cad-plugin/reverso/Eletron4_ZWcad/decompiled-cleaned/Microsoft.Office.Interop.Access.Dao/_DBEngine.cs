using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Access.Dao;

[ComImport]
[CompilerGenerated]
[Guid("00000021-0000-0010-8000-00AA006D2EA4")]
[DefaultMember("Workspaces")]
[TypeIdentifier]
public interface _DBEngine : _DAO
{
	void _VtblGap1_8();

	[DispId(0)]
	Workspaces Workspaces
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}

	void _VtblGap2_2();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	[DispId(1610809354)]
	void CompactDatabase([In][MarshalAs(UnmanagedType.BStr)] string SrcName, [In][MarshalAs(UnmanagedType.BStr)] string DstName, [Optional][In][MarshalAs(UnmanagedType.Struct)] object DstLocale, [Optional][In][MarshalAs(UnmanagedType.Struct)] object Options, [Optional][In][MarshalAs(UnmanagedType.Struct)] object SrcLocale);
}
