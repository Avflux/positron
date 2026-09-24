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
public class FrmBuscaNuvem : Form
{
	private IContainer kfuhlMXqn7;

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && kfuhlMXqn7 != null)
			{
				kfuhlMXqn7.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void QfQhnVVqZh()
	{
		SuspendLayout();
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.Black;
		BackgroundImage = Resources.NuvemProcurar;
		BackgroundImageLayout = ImageLayout.Center;
		ClientSize = new Size(152, 149);
		DoubleBuffered = true;
		FormBorderStyle = FormBorderStyle.None;
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "FrmBuscaNuvem";
		ShowIcon = false;
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterScreen;
		Text = "FrmBuscaNuvem";
		TopMost = true;
		TransparencyKey = Color.Black;
		ResumeLayout(performLayout: false);
	}

	public FrmBuscaNuvem()
	{
		Load += cQih17bDrl;
		QfQhnVVqZh();
		Application.ShowModelessDialog((Form)this);
		if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
		{
			Left = 200;
			StartPosition = FormStartPosition.CenterScreen;
		}
		Application.DoEvents();
	}

	private void cQih17bDrl(object P_0, EventArgs P_1)
	{
	}
}
