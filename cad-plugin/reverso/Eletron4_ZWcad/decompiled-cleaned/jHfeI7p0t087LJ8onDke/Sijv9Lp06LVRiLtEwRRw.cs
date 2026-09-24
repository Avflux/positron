using System;
using System.Reflection;

namespace jHfeI7p0t087LJ8onDke;

internal class Sijv9Lp06LVRiLtEwRRw
{
	internal delegate void gZFjhCp0LkTpdy9viFmI(object o);

	internal static Module c1Bp0juBuxC;

	internal static void XE0koMAUGNG(int typemdt)
	{
		Type type = c1Bp0juBuxC.ResolveType(33554432 + typemdt);
		FieldInfo[] fields = type.GetFields();
		foreach (FieldInfo fieldInfo in fields)
		{
			MethodInfo method = (MethodInfo)c1Bp0juBuxC.ResolveMethod(fieldInfo.MetadataToken + 100663296);
			fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
		}
	}

	static Sijv9Lp06LVRiLtEwRRw()
	{
		c1Bp0juBuxC = typeof(Sijv9Lp06LVRiLtEwRRw).Assembly.ManifestModule;
	}
}
