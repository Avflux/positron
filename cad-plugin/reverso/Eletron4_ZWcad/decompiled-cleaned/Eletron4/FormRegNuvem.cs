using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Eletron4;

[DesignerGenerated]
public class FormRegNuvem : Form
{
	private IContainer IheTFQuyAy;

	[AccessedThroughProperty("btDesregistraNuvem")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button UtiTQBrBtl;

	[AccessedThroughProperty("btRegistraNuvem")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button KR9TPsrNlU;

	[AccessedThroughProperty("Label7")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label XOSTcFp83R;

	[CompilerGenerated]
	[AccessedThroughProperty("tbLicenca")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox FDJTKneCME;

	[AccessedThroughProperty("Label6")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label mIuTe57vYb;

	[CompilerGenerated]
	[AccessedThroughProperty("tbEmail")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox fBYT2oE6lj;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("cbDesinstalarAutomatico")]
	private CheckBox NwvT3qbrCI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool RnhTnbCGtu;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool pMET1GgwFT;

	private int jokTlUjId2;

	private int vDST5gE3kO;

	internal virtual Button btDesregistraNuvem
	{
		[CompilerGenerated]
		get
		{
			return UtiTQBrBtl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = n3xTNhEENI;
			Button button = UtiTQBrBtl;
			if (button != null)
			{
				button.Click -= value2;
			}
			UtiTQBrBtl = value;
			button = UtiTQBrBtl;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btRegistraNuvem
	{
		[CompilerGenerated]
		get
		{
			return KR9TPsrNlU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = uTcT8eEMmM;
			Button button = KR9TPsrNlU;
			if (button != null)
			{
				button.Click -= value2;
			}
			KR9TPsrNlU = value;
			button = KR9TPsrNlU;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label Label7
	{
		[CompilerGenerated]
		get
		{
			return XOSTcFp83R;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			XOSTcFp83R = value;
		}
	}

	internal virtual TextBox tbLicenca
	{
		[CompilerGenerated]
		get
		{
			return FDJTKneCME;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			FDJTKneCME = value;
		}
	}

	internal virtual Label Label6
	{
		[CompilerGenerated]
		get
		{
			return mIuTe57vYb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mIuTe57vYb = value;
		}
	}

	internal virtual TextBox tbEmail
	{
		[CompilerGenerated]
		get
		{
			return fBYT2oE6lj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			fBYT2oE6lj = value;
		}
	}

	internal virtual CheckBox cbDesinstalarAutomatico
	{
		[CompilerGenerated]
		get
		{
			return NwvT3qbrCI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			NwvT3qbrCI = value;
		}
	}

	public bool bDesinstalou
	{
		[CompilerGenerated]
		get
		{
			return RnhTnbCGtu;
		}
		[CompilerGenerated]
		set
		{
			RnhTnbCGtu = value;
		}
	}

	public bool bInstalou
	{
		[CompilerGenerated]
		get
		{
			return pMET1GgwFT;
		}
		[CompilerGenerated]
		set
		{
			pMET1GgwFT = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && IheTFQuyAy != null)
			{
				IheTFQuyAy.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void bXMTaPKBsH()
	{
		btDesregistraNuvem = new Button();
		btRegistraNuvem = new Button();
		Label7 = new Label();
		tbLicenca = new TextBox();
		Label6 = new Label();
		tbEmail = new TextBox();
		cbDesinstalarAutomatico = new CheckBox();
		SuspendLayout();
		btDesregistraNuvem.Location = new Point(167, 96);
		btDesregistraNuvem.Name = "btDesregistraNuvem";
		btDesregistraNuvem.Size = new Size(124, 23);
		btDesregistraNuvem.TabIndex = 30;
		btDesregistraNuvem.Text = "Desinstalar Licença";
		btDesregistraNuvem.UseVisualStyleBackColor = true;
		btRegistraNuvem.Location = new Point(59, 96);
		btRegistraNuvem.Name = "btRegistraNuvem";
		btRegistraNuvem.Size = new Size(102, 23);
		btRegistraNuvem.TabIndex = 29;
		btRegistraNuvem.Text = "Instalar Licença";
		btRegistraNuvem.UseVisualStyleBackColor = true;
		Label7.AutoSize = true;
		Label7.Location = new Point(7, 40);
		Label7.Name = "Label7";
		Label7.Size = new Size(45, 13);
		Label7.TabIndex = 28;
		Label7.Text = "Licença";
		tbLicenca.Location = new Point(58, 37);
		tbLicenca.Name = "tbLicenca";
		tbLicenca.Size = new Size(288, 20);
		tbLicenca.TabIndex = 27;
		Label6.AutoSize = true;
		Label6.Location = new Point(11, 14);
		Label6.Name = "Label6";
		Label6.Size = new Size(36, 13);
		Label6.TabIndex = 26;
		Label6.Text = "E-Mail";
		tbEmail.Location = new Point(58, 11);
		tbEmail.Name = "tbEmail";
		tbEmail.Size = new Size(185, 20);
		tbEmail.TabIndex = 25;
		cbDesinstalarAutomatico.AutoSize = true;
		cbDesinstalarAutomatico.Location = new Point(59, 63);
		cbDesinstalarAutomatico.Name = "cbDesinstalarAutomatico";
		cbDesinstalarAutomatico.Size = new Size(239, 17);
		cbDesinstalarAutomatico.TabIndex = 33;
		cbDesinstalarAutomatico.Text = "Desinstalar Automaticamente ao Fechar CAD";
		cbDesinstalarAutomatico.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(362, 131);
		Controls.Add(cbDesinstalarAutomatico);
		Controls.Add(btDesregistraNuvem);
		Controls.Add(btRegistraNuvem);
		Controls.Add(Label7);
		Controls.Add(tbLicenca);
		Controls.Add(Label6);
		Controls.Add(tbEmail);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		Name = "FormRegNuvem";
		StartPosition = FormStartPosition.Manual;
		Text = "Instalar Licença da Nuvem";
		TopMost = true;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public FormRegNuvem()
	{
		bDesinstalou = false;
		bInstalou = false;
		jokTlUjId2 = 2;
		vDST5gE3kO = 0;
		bXMTaPKBsH();
		new cProtectNuvem();
		vDST5gE3kO = DateAndTime.Now.Millisecond;
		string text = cCheckNuvem.BuscaChaveLicReg("CL3");
		if (Operators.CompareString(text.Trim(), "", TextCompare: true) != 0)
		{
			btRegistraNuvem.Enabled = false;
			btDesregistraNuvem.Enabled = true;
			tbLicenca.Text = text;
			tbEmail.Text = cCheckNuvem.BuscaChaveLicReg("CL2");
			cbDesinstalarAutomatico.Checked = MySettingsProperty.Settings.DesinstalarAut;
			tbEmail.Enabled = false;
			tbLicenca.Enabled = false;
		}
		else
		{
			btRegistraNuvem.Enabled = true;
			btDesregistraNuvem.Enabled = false;
			tbLicenca.Text = MySettingsProperty.Settings.LicCloud;
			tbEmail.Text = MySettingsProperty.Settings.EmailCloud;
			cbDesinstalarAutomatico.Checked = MySettingsProperty.Settings.DesinstalarAut;
			tbEmail.Enabled = true;
			tbLicenca.Enabled = true;
		}
	}

	private void uTcT8eEMmM(object P_0, EventArgs P_1)
	{
		if (tbEmail.Text.Contains("@"))
		{
			if (Operators.CompareString(tbLicenca.Text.Trim(), "", TextCompare: true) != 0)
			{
				cCheckNuvem cCheckNuvem2 = new cCheckNuvem();
				bInstalou = cCheckNuvem2.RegistraNuvem(tbLicenca.Text.Trim(), tbEmail.Text.Trim());
				MySettingsProperty.Settings.LicCloud = tbLicenca.Text;
				MySettingsProperty.Settings.EmailCloud = tbEmail.Text;
				MySettingsProperty.Settings.DesinstalarAut = cbDesinstalarAutomatico.Checked;
				MySettingsProperty.Settings.Save();
				Close();
			}
			else
			{
				Interaction.MsgBox("Informe uma licença válida!", MsgBoxStyle.Information);
			}
		}
		else
		{
			Interaction.MsgBox("Informe um email válido!", MsgBoxStyle.Information);
		}
	}

	private void n3xTNhEENI(object P_0, EventArgs P_1)
	{
		MySettingsProperty.Settings.LicCloud = tbLicenca.Text;
		MySettingsProperty.Settings.EmailCloud = tbEmail.Text;
		MySettingsProperty.Settings.DesinstalarAut = cbDesinstalarAutomatico.Checked;
		MySettingsProperty.Settings.Save();
		cCheckNuvem cCheckNuvem2 = new cCheckNuvem();
		bDesinstalou = cCheckNuvem2.DesregistraNuvem();
		Close();
	}
}
