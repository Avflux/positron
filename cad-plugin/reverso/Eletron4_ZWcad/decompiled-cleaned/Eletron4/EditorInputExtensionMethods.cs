using System;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.EditorInput;

namespace Eletron4;

[StandardModule]
public sealed class EditorInputExtensionMethods
{
	private static Func<Editor, object[], PromptStatus> oNtpQAuLCX;

	static EditorInputExtensionMethods()
	{
		oNtpQAuLCX = cAOpFGLDyg();
	}

	public static PromptStatus Command(this Editor editor, params object[] args)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (editor == null)
		{
			throw new ArgumentNullException("editor");
		}
		return oNtpQAuLCX(editor, args);
	}

	private static Func<Editor, object[], PromptStatus> cAOpFGLDyg()
	{
		MethodInfo method = typeof(Editor).GetMethod("RunCommand", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		ParameterExpression parameterExpression = Expression.Parameter(typeof(Editor), "editor");
		ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object[]), "args");
		return Expression.Lambda<Func<Editor, object[], PromptStatus>>(Expression.Call(parameterExpression, method, parameterExpression2), new ParameterExpression[2] { parameterExpression, parameterExpression2 }).Compile();
	}
}
