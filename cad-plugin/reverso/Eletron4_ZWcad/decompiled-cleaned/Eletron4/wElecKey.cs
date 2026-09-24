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
public class wElecKey : Form
{
	private IContainer aoF3yi1ZHV;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label pqB3gWYoxK;

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return pqB3gWYoxK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pqB3gWYoxK = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && aoF3yi1ZHV != null)
			{
				aoF3yi1ZHV.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void wFt3U3Eu1g()
	{
		Label1 = new Label();
		SuspendLayout();
		Label1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label1.Location = new Point(12, 19);
		Label1.Name = "Label1";
		Label1.Size = new Size(374, 40);
		Label1.TabIndex = 0;
		Label1.Text = "Servidor de Licenças Elétron está indisponível!";
		Label1.TextAlign = ContentAlignment.MiddleCenter;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		BackColor = SystemColors.Highlight;
		ClientSize = new Size(398, 79);
		Controls.Add(Label1);
		MaximizeBox = false;
		MaximumSize = new Size(414, 118);
		MinimizeBox = false;
		MinimumSize = new Size(414, 118);
		Name = "wElecKey";
		StartPosition = FormStartPosition.CenterScreen;
		Text = "wElecKey";
		TopMost = true;
		ResumeLayout(performLayout: false);
	}

	public wElecKey()
	{
		wFt3U3Eu1g();
		Text = "Elétron";
		Label1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1533]);
		Application.ShowModalDialog(Application.MainWindow.Handle, (Form)this, false);
	}
}
