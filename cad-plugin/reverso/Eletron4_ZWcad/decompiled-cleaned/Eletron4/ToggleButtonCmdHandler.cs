using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using Eletron4.My.Resources;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.Windows;
using ZwSoft.ZwCAD.ApplicationServices.Core;

namespace Eletron4;

public class ToggleButtonCmdHandler : ICommand
{
	private Version Q4gp1qaTRYo;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private EventHandler nP3p1alSAWb;

	public event EventHandler CanExecuteChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = nP3p1alSAWb;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref nP3p1alSAWb, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = nP3p1alSAWb;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref nP3p1alSAWb, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public ToggleButtonCmdHandler()
	{
		Q4gp1qaTRYo = Application.Version;
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
		RibbonToggleButton val = (RibbonToggleButton)((parameter is RibbonToggleButton) ? parameter : null);
		if (!((Operators.CompareString(((RibbonCommandItem)val).CommandParameter.ToString(), "InfoOn ", TextCompare: true) == 0) | (Operators.CompareString(((RibbonCommandItem)val).CommandParameter.ToString(), "InfoOff ", TextCompare: true) == 0)))
		{
			return;
		}
		int num = 1;
		if (Q4gp1qaTRYo.Major >= 20)
		{
			num = Conversions.ToInteger(Application.GetSystemVariable("COLORTHEME"));
		}
		Bitmap image = null;
		if (num != 0)
		{
			if (num == 1)
			{
				if (!Operators.ConditionalCompareObjectEqual(((RibbonCommandItem)val).CommandParameter, "InfoOn ", TextCompare: true))
				{
					image = Resources.InformationOn_32;
					((RibbonCommandItem)val).CommandParameter = "InfoOn ";
				}
				else
				{
					image = Resources.InformationOff_32;
					((RibbonCommandItem)val).CommandParameter = "InfoOff ";
				}
			}
		}
		else if (!Operators.ConditionalCompareObjectEqual(((RibbonCommandItem)val).CommandParameter, "InfoOn ", TextCompare: true))
		{
			image = Resources.InformationOn_32_Dark;
			((RibbonCommandItem)val).CommandParameter = "InfoOn ";
		}
		else
		{
			image = Resources.InformationOff_32_Dark;
			((RibbonCommandItem)val).CommandParameter = "InfoOff ";
		}
		Ribbon ribbon = new Ribbon();
		((RibbonItem)val).LargeImage = ribbon.getBitmap(image);
		Application.DocumentManager.MdiActiveDocument.SendStringToExecute("\u001b" + ((RibbonCommandItem)val).CommandParameter.ToString(), true, false, true);
	}

	void ICommand.Execute(object parameter)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Execute
		this.Execute(parameter);
	}
}
