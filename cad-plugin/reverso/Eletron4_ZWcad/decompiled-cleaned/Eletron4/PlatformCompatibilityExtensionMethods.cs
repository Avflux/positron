using System;
using System.Reflection;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;

namespace Eletron4;

[StandardModule]
public sealed class PlatformCompatibilityExtensionMethods
{
	private static MethodInfo otNpnScKVZa;

	private static MethodInfo J7apn4LOiBx;

	static PlatformCompatibilityExtensionMethods()
	{
		otNpnScKVZa = null;
		J7apn4LOiBx = null;
		Type[] array = null;
		Type[] array2 = null;
		if (IntPtr.Size <= 4)
		{
			array = new Type[5]
			{
				typeof(Entity),
				typeof(Intersect),
				typeof(Point3dCollection),
				typeof(int),
				typeof(int)
			};
			array2 = new Type[6]
			{
				typeof(Entity),
				typeof(Intersect),
				typeof(Plane),
				typeof(Point3dCollection),
				typeof(int),
				typeof(int)
			};
		}
		else
		{
			array = new Type[5]
			{
				typeof(Entity),
				typeof(Intersect),
				typeof(Point3dCollection),
				typeof(long),
				typeof(long)
			};
			array2 = new Type[6]
			{
				typeof(Entity),
				typeof(Intersect),
				typeof(Plane),
				typeof(Point3dCollection),
				typeof(long),
				typeof(long)
			};
		}
		otNpnScKVZa = typeof(Entity).GetMethod("IntersectWith", BindingFlags.Instance | BindingFlags.Public, null, array, null);
		J7apn4LOiBx = typeof(Entity).GetMethod("IntersectWith", BindingFlags.Instance | BindingFlags.Public, null, array2, null);
	}

	public static int IntersectWith(this Entity entity, Entity other, Intersect intersectType, Point3dCollection points)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		int count = points.Count;
		object[] array = null;
		array = ((IntPtr.Size > 4) ? new object[5] { other, intersectType, points, 0L, 0L } : new object[5] { other, intersectType, points, 0, 0 });
		otNpnScKVZa.Invoke(entity, BindingFlags.Static | BindingFlags.NonPublic, null, array, null);
		return checked(points.Count - count);
	}

	public static int IntersectWith(this Entity entity, Entity other, Intersect intersectType, Plane plane, Point3dCollection points)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		int count = points.Count;
		object[] array = null;
		array = ((IntPtr.Size > 4) ? new object[6] { other, intersectType, plane, points, 0L, 0L } : new object[6] { other, intersectType, plane, points, 0, 0 });
		J7apn4LOiBx.Invoke(null, BindingFlags.Static | BindingFlags.NonPublic, null, array, null);
		return checked(points.Count - count);
	}

	public static int IntersectWith(this Entity entity, Entity other, Intersect intersectType, Point3dCollection points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		int count = points.Count;
		object[] array = null;
		array = ((IntPtr.Size > 4) ? new object[5]
		{
			other,
			intersectType,
			points,
			thisGsMarker.ToInt64(),
			otherGsMarker.ToInt64()
		} : new object[5]
		{
			other,
			intersectType,
			points,
			thisGsMarker.ToInt32(),
			otherGsMarker.ToInt32()
		});
		otNpnScKVZa.Invoke(entity, BindingFlags.Static | BindingFlags.NonPublic, null, array, null);
		return checked(points.Count - count);
	}

	public static int IntersectWith(this Entity entity, Entity other, Intersect intersectType, Plane plane, Point3dCollection points, IntPtr thisGsMarker, IntPtr otherGsMarker)
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		int count = points.Count;
		object[] array = null;
		array = ((IntPtr.Size > 4) ? new object[6]
		{
			other,
			intersectType,
			plane,
			points,
			thisGsMarker.ToInt64(),
			otherGsMarker.ToInt64()
		} : new object[6]
		{
			other,
			intersectType,
			plane,
			points,
			thisGsMarker.ToInt32(),
			otherGsMarker.ToInt32()
		});
		J7apn4LOiBx.Invoke(null, BindingFlags.Static | BindingFlags.NonPublic, null, array, null);
		return checked(points.Count - count);
	}
}
