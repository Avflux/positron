using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

[DesignerGenerated]
public class FormGerarChave : Form
{
	private IContainer wJN13DDyde;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PictureBox1")]
	[CompilerGenerated]
	private PictureBox IhC1nQiRgA;

	[CompilerGenerated]
	[AccessedThroughProperty("btRegistrar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button djo112s4Ld;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label2")]
	private Label lwQ1l1rpTN;

	[CompilerGenerated]
	[AccessedThroughProperty("tbCodigo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox zKI15L8qhJ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label1")]
	private Label HSU10Krfd3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbChave")]
	private TextBox iu21Rhi4tH;

	[CompilerGenerated]
	[AccessedThroughProperty("PictureBox2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PictureBox Wjk1mrpKD5;

	internal virtual PictureBox PictureBox1
	{
		[CompilerGenerated]
		get
		{
			return IhC1nQiRgA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			IhC1nQiRgA = value;
		}
	}

	internal virtual Button btRegistrar
	{
		[CompilerGenerated]
		get
		{
			return djo112s4Ld;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PNL12Q6D74;
			Button button = djo112s4Ld;
			if (button != null)
			{
				button.Click -= value2;
			}
			djo112s4Ld = value;
			button = djo112s4Ld;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label Label2
	{
		[CompilerGenerated]
		get
		{
			return lwQ1l1rpTN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			lwQ1l1rpTN = value;
		}
	}

	internal virtual TextBox tbCodigo
	{
		[CompilerGenerated]
		get
		{
			return zKI15L8qhJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zKI15L8qhJ = value;
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return HSU10Krfd3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			HSU10Krfd3 = value;
		}
	}

	internal virtual TextBox tbChave
	{
		[CompilerGenerated]
		get
		{
			return iu21Rhi4tH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			iu21Rhi4tH = value;
		}
	}

	internal virtual PictureBox PictureBox2
	{
		[CompilerGenerated]
		get
		{
			return Wjk1mrpKD5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Wjk1mrpKD5 = value;
		}
	}

	public FormGerarChave()
	{
		Load += vFy1eg3qf9;
		qBD1KDnyhG();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && wJN13DDyde != null)
			{
				wJN13DDyde.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void qBD1KDnyhG()
	{
		btRegistrar = new Button();
		Label2 = new Label();
		tbCodigo = new TextBox();
		Label1 = new Label();
		tbChave = new TextBox();
		PictureBox2 = new PictureBox();
		((ISupportInitialize)PictureBox2).BeginInit();
		SuspendLayout();
		btRegistrar.Location = new Point(171, 198);
		btRegistrar.Name = "btRegistrar";
		btRegistrar.Size = new Size(117, 23);
		btRegistrar.TabIndex = 11;
		btRegistrar.Text = "Registrar";
		btRegistrar.UseVisualStyleBackColor = true;
		Label2.AutoSize = true;
		Label2.Location = new Point(12, 147);
		Label2.Name = "Label2";
		Label2.Size = new Size(230, 13);
		Label2.TabIndex = 10;
		Label2.Text = "Código para Ativação informado pela Cadgraph";
		tbCodigo.Location = new Point(12, 163);
		tbCodigo.Name = "tbCodigo";
		tbCodigo.Size = new Size(434, 20);
		tbCodigo.TabIndex = 9;
		Label1.AutoSize = true;
		Label1.Location = new Point(12, 94);
		Label1.Name = "Label1";
		Label1.Size = new Size(149, 13);
		Label1.TabIndex = 8;
		Label1.Text = "Chave (enviar para Cadgraph)";
		tbChave.Location = new Point(12, 110);
		tbChave.Name = "tbChave";
		tbChave.Size = new Size(434, 20);
		tbChave.TabIndex = 7;
		PictureBox2.Image = Resources.Security;
		PictureBox2.Location = new Point(194, 12);
		PictureBox2.Name = "PictureBox2";
		PictureBox2.Size = new Size(64, 67);
		PictureBox2.TabIndex = 12;
		PictureBox2.TabStop = false;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(458, 232);
		Controls.Add(tbChave);
		Controls.Add(tbCodigo);
		Controls.Add(PictureBox2);
		Controls.Add(btRegistrar);
		Controls.Add(Label2);
		Controls.Add(Label1);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "FormGerarChave";
		Text = "É necessário informar o código de ativação!";
		TopMost = true;
		((ISupportInitialize)PictureBox2).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void vFy1eg3qf9(object P_0, EventArgs P_1)
	{
		CProtect cProtect = new CProtect();
		tbChave.Text = "=>" + cProtect.GerarChave() + "<=";
	}

	private void PNL12Q6D74(object P_0, EventArgs P_1)
	{
		if (tbCodigo.Text.Length >= 10)
		{
			MySettingsProperty.Settings.Codigo = tbCodigo.Text.Trim();
			CProtect cProtect = new CProtect();
			MySettingsProperty.Settings.DCode = cProtect.CriptografarDH(Conversions.ToString(DateAndTime.DateValue(Conversions.ToString(DateAndTime.Now.Date)).ToOADate()));
			MySettingsProperty.Settings.HCode = cProtect.CriptografarDH(Conversions.ToString(DateAndTime.Now.Hour));
			MySettingsProperty.Settings.Save();
			Close();
		}
		else
		{
			Interaction.MsgBox("É necessário inserir o Código de Ativação informado pela Cadgraph!", MsgBoxStyle.Information);
		}
	}
}
