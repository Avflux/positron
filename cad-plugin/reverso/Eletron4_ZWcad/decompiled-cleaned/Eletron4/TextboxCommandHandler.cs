using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using Eletron4.My;
using ZwSoft.Windows;

namespace Eletron4;

public class TextboxCommandHandler : ICommand
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EventHandler Cwvp1N3ewNg;

	public event EventHandler CanExecuteChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = Cwvp1N3ewNg;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref Cwvp1N3ewNg, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = Cwvp1N3ewNg;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref Cwvp1N3ewNg, value2, eventHandler2);
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
		RibbonTextBox val = (RibbonTextBox)((parameter is RibbonTextBox) ? parameter : null);
		if (val != null)
		{
			DeclaracoesGeral.ativoRibbon.Cor = val.TextValue;
			MySettingsProperty.Settings.Cor = DeclaracoesGeral.ativoRibbon.Cor.ToString();
			MySettingsProperty.Settings.Save();
		}
	}

	void ICommand.Execute(object parameter)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Execute
		this.Execute(parameter);
	}
}
