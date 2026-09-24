using System;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

public sealed class excEXCEL
{
	[SecurityCritical]
	public static object GetObject(string progID)
	{
		object obj = null;
		object result;
		try
		{
			Guid guid = default;
			try
			{
				XW0TIbiS2I(progID, ref guid);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				dyBT7ePuK3(progID, ref guid);
				ProjectData.ClearProjectError();
			}
			zC0TqSI8We(ref guid, IntPtr.Zero, ref obj);
			result = obj;
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			result = obj;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	[DllImport("ole32.dll", EntryPoint = "CLSIDFromProgIDEx", PreserveSig = false)]
	[SecurityCritical]
	[SuppressUnmanagedCodeSecurity]
	private static extern void XW0TIbiS2I([MarshalAs(UnmanagedType.LPWStr)] string P_0, ref Guid P_1);

	[DllImport("ole32.dll", EntryPoint = "CLSIDFromProgID", PreserveSig = false)]
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	private static extern void dyBT7ePuK3([MarshalAs(UnmanagedType.LPWStr)] string P_0, ref Guid P_1);

	[DllImport("oleaut32.dll", EntryPoint = "GetActiveObject", PreserveSig = false)]
	[SuppressUnmanagedCodeSecurity]
	[SecurityCritical]
	private static extern void zC0TqSI8We(ref Guid P_0, IntPtr P_1, [MarshalAs(UnmanagedType.Interface)] ref object P_2);
}
