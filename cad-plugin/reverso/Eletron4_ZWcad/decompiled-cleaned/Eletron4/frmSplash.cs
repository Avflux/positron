using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;

namespace Eletron4;

[DesignerGenerated]
public class frmSplash : Form
{
	private IContainer BZupKDcYxWJ;

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && BZupKDcYxWJ != null)
			{
				BZupKDcYxWJ.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void tV0pKdvZnaa()
	{
		SuspendLayout();
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.Blue;
		BackgroundImage = Resources.SplashEL26;
		BackgroundImageLayout = ImageLayout.Center;
		ClientSize = new Size(625, 506);
		DoubleBuffered = true;
		FormBorderStyle = FormBorderStyle.None;
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "frmSplash";
		ShowIcon = false;
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterScreen;
		TopMost = true;
		TransparencyKey = Color.Blue;
		ResumeLayout(performLayout: false);
	}

	public frmSplash()
	{
		Load += QBSpKfO7uUV;
		tV0pKdvZnaa();
		Application.ShowModelessDialog((Form)this);
		if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
		{
			Left = 200;
			StartPosition = FormStartPosition.CenterScreen;
		}
	}

	private void QBSpKfO7uUV(object P_0, EventArgs P_1)
	{
	}
}
