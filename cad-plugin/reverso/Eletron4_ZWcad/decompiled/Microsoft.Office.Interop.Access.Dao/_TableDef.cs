using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Microsoft.Office.Interop.Access.Dao;

[ComImport]
[TypeIdentifier]
[DefaultMember("Fields")]
[CompilerGenerated]
[Guid("00000049-0000-0010-8000-00AA006D2EA4")]
public interface _TableDef : _DAO
{
	void _VtblGap1_17();

	[DispId(0)]
	Fields Fields
	{
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		[DispId(0)]
		[return: MarshalAs(UnmanagedType.Interface)]
		get;
	}
}
