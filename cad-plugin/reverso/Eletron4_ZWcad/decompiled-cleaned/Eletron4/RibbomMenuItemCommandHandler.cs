using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.Windows;
using ZwSoft.ZwCAD.ApplicationServices.Core;

namespace Eletron4;

public class RibbomMenuItemCommandHandler : ICommand
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EventHandler vGHp1FRVtWF;

	public event EventHandler CanExecuteChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = vGHp1FRVtWF;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref vGHp1FRVtWF, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = vGHp1FRVtWF;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref vGHp1FRVtWF, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public bool CanExecute(object parameter)
	{
		return true;
	}

	bool ICommand.CanExecute(object parameter)
	{
		//ILSpy generated this explicit interface implementation from .override directive in CanExecute
		return this.CanExecute(parameter);
	}

	public void Execute(object parameter)
	{
		RibbonMenuItem val = (RibbonMenuItem)((parameter is RibbonMenuItem) ? parameter : null);
		if (Operators.CompareString(((RibbonCommandItem)val).CommandParameter.ToString(), "", TextCompare: true) != 0)
		{
			Application.DocumentManager.MdiActiveDocument.SendStringToExecute("\u001b" + ((RibbonCommandItem)val).CommandParameter.ToString(), true, false, true);
		}
	}

	void ICommand.Execute(object parameter)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Execute
		this.Execute(parameter);
	}
}
