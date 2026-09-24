using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;

namespace Eletron4;

[DesignerGenerated]
public class WNuvem : Form
{
	private IContainer UPy3sGL0NT;

	[AccessedThroughProperty("Label2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label lbG3B81Bc1;

	internal virtual Label Label2
	{
		[CompilerGenerated]
		get
		{
			return lbG3B81Bc1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			lbG3B81Bc1 = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && UPy3sGL0NT != null)
			{
				UPy3sGL0NT.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void xgk3ASLduJ()
	{
		Label2 = new Label();
		SuspendLayout();
		Label2.AutoSize = true;
		Label2.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label2.Location = new Point(12, 18);
		Label2.Name = "Label2";
		Label2.Size = new Size(435, 40);
		Label2.TabIndex = 2;
		Label2.Text = "A LICENÇA FOI REMOVIDA DESTE COMPUTADOR!\r\nFECHE O AUTOCAD/BRICSCAD.";
		Label2.TextAlign = ContentAlignment.MiddleCenter;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.DarkSalmon;
		ClientSize = new Size(458, 66);
		Controls.Add(Label2);
		MaximizeBox = false;
		MaximumSize = new Size(474, 105);
		MinimizeBox = false;
		MinimumSize = new Size(474, 105);
		Name = "WNuvem";
		StartPosition = FormStartPosition.CenterScreen;
		Text = "WNuvem";
		TopMost = true;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public WNuvem()
	{
		xgk3ASLduJ();
		Text = "Elétron";
		Label2.Text = "A LICENÇA FOI REMOVIDA DESTE COMPUTADOR!\r\nFECHE O AUTOCAD.";
		Application.ShowModalDialog(Application.MainWindow.Handle, (Form)this, false);
	}
}
