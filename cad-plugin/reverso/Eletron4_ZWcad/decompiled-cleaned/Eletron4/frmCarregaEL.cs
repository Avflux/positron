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
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;

namespace Eletron4;

[DesignerGenerated]
public class frmCarregaEL : Form
{
	private IContainer fD8hyB22vN;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btRockey")]
	private Button siShgsJAIx;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbRockey")]
	private CheckBox o8yhA1mKu4;

	[AccessedThroughProperty("cbElecKey")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox OcShsEdfrP;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btElecKey")]
	private Button IudhBLWPZa;

	[CompilerGenerated]
	[AccessedThroughProperty("btTrial")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button htahVmZZFZ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btNuvem")]
	private Button VE4hu1Wkon;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbNuvem")]
	private CheckBox Ne4hECcGEc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip OE6hZQqeOk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btNuvemRemover")]
	private Button QVWhiuR1G2;

	internal virtual Button btRockey
	{
		[CompilerGenerated]
		get
		{
			return siShgsJAIx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = iu0h0w68ch;
			Button button = siShgsJAIx;
			if (button != null)
			{
				button.Click -= value2;
			}
			siShgsJAIx = value;
			button = siShgsJAIx;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox cbRockey
	{
		[CompilerGenerated]
		get
		{
			return o8yhA1mKu4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			o8yhA1mKu4 = value;
		}
	}

	internal virtual CheckBox cbElecKey
	{
		[CompilerGenerated]
		get
		{
			return OcShsEdfrP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			OcShsEdfrP = value;
		}
	}

	internal virtual Button btElecKey
	{
		[CompilerGenerated]
		get
		{
			return IudhBLWPZa;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = KQchR2UOec;
			Button button = IudhBLWPZa;
			if (button != null)
			{
				button.Click -= value2;
			}
			IudhBLWPZa = value;
			button = IudhBLWPZa;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btTrial
	{
		[CompilerGenerated]
		get
		{
			return htahVmZZFZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = XgKhUCoAEf;
			Button button = htahVmZZFZ;
			if (button != null)
			{
				button.Click -= value2;
			}
			htahVmZZFZ = value;
			button = htahVmZZFZ;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btNuvem
	{
		[CompilerGenerated]
		get
		{
			return VE4hu1Wkon;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = eDZhmb8vTw;
			Button button = VE4hu1Wkon;
			if (button != null)
			{
				button.Click -= value2;
			}
			VE4hu1Wkon = value;
			button = VE4hu1Wkon;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox cbNuvem
	{
		[CompilerGenerated]
		get
		{
			return Ne4hECcGEc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Ne4hECcGEc = value;
		}
	}

	internal virtual Button btNuvemRemover
	{
		[CompilerGenerated]
		get
		{
			return QVWhiuR1G2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = I38hXp59mH;
			Button button = QVWhiuR1G2;
			if (button != null)
			{
				button.Click -= value2;
			}
			QVWhiuR1G2 = value;
			button = QVWhiuR1G2;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && fD8hyB22vN != null)
			{
				fD8hyB22vN.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void lHOh5W6N4I()
	{
		fD8hyB22vN = new Container();
		btRockey = new Button();
		cbRockey = new CheckBox();
		cbElecKey = new CheckBox();
		btElecKey = new Button();
		btTrial = new Button();
		btNuvem = new Button();
		cbNuvem = new CheckBox();
		FDqpBiUmZij(new ToolTip(fD8hyB22vN));
		btNuvemRemover = new Button();
		SuspendLayout();
		btRockey.BackColor = SystemColors.Control;
		btRockey.FlatStyle = FlatStyle.Flat;
		btRockey.ForeColor = SystemColors.Control;
		btRockey.Image = Resources.Hardlock;
		btRockey.Location = new Point(28, 12);
		btRockey.Name = "btRockey";
		btRockey.Size = new Size(48, 48);
		btRockey.TabIndex = 0;
		btRockey.UseVisualStyleBackColor = false;
		cbRockey.AutoSize = true;
		cbRockey.Location = new Point(12, 66);
		cbRockey.Name = "cbRockey";
		cbRockey.Size = new Size(81, 17);
		cbRockey.TabIndex = 1;
		cbRockey.Text = "CheckBox1";
		cbRockey.UseVisualStyleBackColor = true;
		cbElecKey.AutoSize = true;
		cbElecKey.Location = new Point(105, 66);
		cbElecKey.Name = "cbElecKey";
		cbElecKey.Size = new Size(81, 17);
		cbElecKey.TabIndex = 3;
		cbElecKey.Text = "CheckBox1";
		cbElecKey.UseVisualStyleBackColor = true;
		btElecKey.FlatStyle = FlatStyle.Flat;
		btElecKey.ForeColor = SystemColors.Control;
		btElecKey.Image = Resources.Server;
		btElecKey.Location = new Point(122, 12);
		btElecKey.Name = "btElecKey";
		btElecKey.Size = new Size(48, 48);
		btElecKey.TabIndex = 2;
		btElecKey.UseVisualStyleBackColor = true;
		btTrial.Enabled = false;
		btTrial.Location = new Point(114, 143);
		btTrial.Name = "btTrial";
		btTrial.Size = new Size(95, 23);
		btTrial.TabIndex = 4;
		btTrial.Text = "Trial";
		btTrial.UseVisualStyleBackColor = true;
		btNuvem.FlatStyle = FlatStyle.Flat;
		btNuvem.ForeColor = SystemColors.Control;
		btNuvem.Image = Resources.Nuvem;
		btNuvem.Location = new Point(231, 12);
		btNuvem.Name = "btNuvem";
		btNuvem.Size = new Size(48, 48);
		btNuvem.TabIndex = 5;
		btNuvem.UseVisualStyleBackColor = true;
		cbNuvem.AutoSize = true;
		cbNuvem.Location = new Point(198, 66);
		cbNuvem.Name = "cbNuvem";
		cbNuvem.Size = new Size(81, 17);
		cbNuvem.TabIndex = 6;
		cbNuvem.Text = "CheckBox1";
		cbNuvem.UseVisualStyleBackColor = true;
		btNuvemRemover.FlatStyle = FlatStyle.Flat;
		btNuvemRemover.ForeColor = SystemColors.Control;
		btNuvemRemover.Image = Resources.NuvemDel;
		btNuvemRemover.Location = new Point(278, 63);
		btNuvemRemover.Name = "btNuvemRemover";
		btNuvemRemover.Size = new Size(19, 19);
		btNuvemRemover.TabIndex = 7;
		btNuvemRemover.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(302, 90);
		Controls.Add(btNuvemRemover);
		Controls.Add(cbNuvem);
		Controls.Add(btNuvem);
		Controls.Add(btTrial);
		Controls.Add(cbElecKey);
		Controls.Add(btElecKey);
		Controls.Add(cbRockey);
		Controls.Add(btRockey);
		FormBorderStyle = FormBorderStyle.Fixed3D;
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "frmCarregaEL";
		ShowInTaskbar = false;
		Text = "frmCarregaEL";
		TopMost = true;
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return OE6hZQqeOk;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		OE6hZQqeOk = WithEventsValue;
	}

	public frmCarregaEL()
	{
		try
		{
			if (!Geral.ExisteForm("frmCarregaEL"))
			{
				lHOh5W6N4I();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1531]);
				cbRockey.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1532]);
				cbElecKey.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1532]);
				cbNuvem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1532]);
				w8dpBZ0kvSD().SetToolTip(btRockey, "Hardlock USB");
				w8dpBZ0kvSD().SetToolTip(btElecKey, "Server");
				w8dpBZ0kvSD().SetToolTip(btNuvem, "Nuvem Internet");
				w8dpBZ0kvSD().SetToolTip(btNuvemRemover, "Desinstalar");
				new cProtectNuvem();
				string text = cCheckNuvem.BuscaChaveLicReg("CL3");
				if (Operators.CompareString(text.Trim(), "", TextCompare: true) != 0)
				{
					btNuvemRemover.Enabled = true;
				}
				else
				{
					btNuvemRemover.Enabled = false;
				}
				Application.ShowModalDialog(Application.MainWindow.Handle, (Form)this, false);
				if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
				{
					Left = 0;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void iu0h0w68ch(object P_0, EventArgs P_1)
	{
		if (cbRockey.Checked)
		{
			MySettingsProperty.Settings.LicMode = 1;
			MySettingsProperty.Settings.Save();
		}
		DeclaracoesGeral.LicModeSel = 1;
		Close();
	}

	private void KQchR2UOec(object P_0, EventArgs P_1)
	{
		if (cbElecKey.Checked)
		{
			MySettingsProperty.Settings.LicMode = 2;
			MySettingsProperty.Settings.Save();
		}
		DeclaracoesGeral.LicModeSel = 2;
		Close();
	}

	private void eDZhmb8vTw(object P_0, EventArgs P_1)
	{
		if (cbNuvem.Checked)
		{
			MySettingsProperty.Settings.LicMode = 4;
			MySettingsProperty.Settings.Save();
		}
		DeclaracoesGeral.LicModeSel = 4;
		Close();
	}

	private void I38hXp59mH(object P_0, EventArgs P_1)
	{
		cDadosSQLServerLicenca cDadosSQLServerLicenca2 = new cDadosSQLServerLicenca();
		try
		{
			if (cDadosSQLServerLicenca2.testaConexao())
			{
				FormRegNuvem formRegNuvem = new FormRegNuvem();
				formRegNuvem.ShowDialog();
				if (formRegNuvem.bDesinstalou)
				{
					btNuvemRemover.Enabled = false;
					Close();
				}
			}
			else
			{
				Interaction.MsgBox("O servidor na nuvem não está disponível!", MsgBoxStyle.Information);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		finally
		{
			cDadosSQLServerLicenca2.fechaConexao();
		}
	}

	private void XgKhUCoAEf(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.LicModeSel = 3;
		Close();
	}
}
