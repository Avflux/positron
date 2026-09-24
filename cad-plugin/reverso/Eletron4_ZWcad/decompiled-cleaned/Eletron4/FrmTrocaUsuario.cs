using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;

namespace Eletron4;

[DesignerGenerated]
public class FrmTrocaUsuario : Form
{
	private IContainer Hduc7gsIt5;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolTip za3cqyxCtQ;

	[AccessedThroughProperty("FolderBrowser")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private FolderBrowserDialog LrJcaCo3HY;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox eOhc8NxZUE;

	[AccessedThroughProperty("tbData")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox tdEcNHrr3h;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("tbUser")]
	private TextBox gdjcF5qEUG;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btMudaUserData")]
	private Button t8PcQ1tKfE;

	[CompilerGenerated]
	[AccessedThroughProperty("ckData")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox rFacPXVHnh;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ckUsuario")]
	private CheckBox IWHccfIPYi;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox2")]
	private GroupBox ucscKYRkwv;

	[CompilerGenerated]
	[AccessedThroughProperty("CKBanco")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox YFkcev2uDR;

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return eOhc8NxZUE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			eOhc8NxZUE = value;
		}
	}

	internal virtual TextBox tbData
	{
		[CompilerGenerated]
		get
		{
			return tdEcNHrr3h;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tdEcNHrr3h = value;
		}
	}

	internal virtual TextBox tbUser
	{
		[CompilerGenerated]
		get
		{
			return gdjcF5qEUG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			gdjcF5qEUG = value;
		}
	}

	internal virtual Button btMudaUserData
	{
		[CompilerGenerated]
		get
		{
			return t8PcQ1tKfE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = jfVcI4heQL;
			Button button = t8PcQ1tKfE;
			if (button != null)
			{
				button.Click -= value2;
			}
			t8PcQ1tKfE = value;
			button = t8PcQ1tKfE;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox ckData
	{
		[CompilerGenerated]
		get
		{
			return rFacPXVHnh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rFacPXVHnh = value;
		}
	}

	internal virtual CheckBox ckUsuario
	{
		[CompilerGenerated]
		get
		{
			return IWHccfIPYi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			IWHccfIPYi = value;
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return ucscKYRkwv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ucscKYRkwv = value;
		}
	}

	internal virtual CheckBox CKBanco
	{
		[CompilerGenerated]
		get
		{
			return YFkcev2uDR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			YFkcev2uDR = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && Hduc7gsIt5 != null)
			{
				Hduc7gsIt5.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void OITcMsvPhF()
	{
		Hduc7gsIt5 = new Container();
		FDqpBiUmZij(new ToolTip(Hduc7gsIt5));
		aHypBEW66iS(new FolderBrowserDialog());
		GroupBox1 = new GroupBox();
		ckData = new CheckBox();
		ckUsuario = new CheckBox();
		tbData = new TextBox();
		tbUser = new TextBox();
		btMudaUserData = new Button();
		GroupBox2 = new GroupBox();
		CKBanco = new CheckBox();
		GroupBox1.SuspendLayout();
		GroupBox2.SuspendLayout();
		SuspendLayout();
		GroupBox1.Controls.Add(ckData);
		GroupBox1.Controls.Add(ckUsuario);
		GroupBox1.Controls.Add(tbData);
		GroupBox1.Controls.Add(tbUser);
		GroupBox1.Location = new Point(8, 20);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(279, 72);
		GroupBox1.TabIndex = 187;
		GroupBox1.TabStop = false;
		ckData.AutoSize = true;
		ckData.Checked = true;
		ckData.CheckState = CheckState.Checked;
		ckData.Location = new Point(6, 43);
		ckData.Name = "ckData";
		ckData.Size = new Size(49, 17);
		ckData.TabIndex = 192;
		ckData.Text = "Data";
		ckData.UseVisualStyleBackColor = true;
		ckUsuario.AutoSize = true;
		ckUsuario.Checked = true;
		ckUsuario.CheckState = CheckState.Checked;
		ckUsuario.Location = new Point(6, 15);
		ckUsuario.Name = "ckUsuario";
		ckUsuario.Size = new Size(62, 17);
		ckUsuario.TabIndex = 191;
		ckUsuario.Text = "Usuário";
		ckUsuario.UseVisualStyleBackColor = true;
		tbData.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbData.Location = new Point(74, 41);
		tbData.Name = "tbData";
		tbData.Size = new Size(197, 20);
		tbData.TabIndex = 187;
		tbUser.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbUser.Location = new Point(74, 15);
		tbUser.Name = "tbUser";
		tbUser.Size = new Size(197, 20);
		tbUser.TabIndex = 186;
		btMudaUserData.FlatStyle = FlatStyle.Flat;
		btMudaUserData.ForeColor = SystemColors.Control;
		btMudaUserData.Image = Resources.Restaura_32;
		btMudaUserData.Location = new Point(129, 150);
		btMudaUserData.Name = "btMudaUserData";
		btMudaUserData.Size = new Size(36, 36);
		btMudaUserData.TabIndex = 190;
		btMudaUserData.UseVisualStyleBackColor = true;
		GroupBox2.Controls.Add(CKBanco);
		GroupBox2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		GroupBox2.Location = new Point(8, 104);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(279, 40);
		GroupBox2.TabIndex = 22;
		GroupBox2.TabStop = false;
		CKBanco.AutoSize = true;
		CKBanco.Checked = true;
		CKBanco.CheckState = CheckState.Checked;
		CKBanco.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		CKBanco.Location = new Point(6, 13);
		CKBanco.Name = "CKBanco";
		CKBanco.Size = new Size(106, 17);
		CKBanco.TabIndex = 192;
		CKBanco.Text = "Banco de Dados";
		CKBanco.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(294, 194);
		Controls.Add(btMudaUserData);
		Controls.Add(GroupBox1);
		Controls.Add(GroupBox2);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		MaximumSize = new Size(310, 300);
		MinimizeBox = false;
		Name = "FrmTrocaUsuario";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Muda Usuário e Data";
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return za3cqyxCtQ;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		za3cqyxCtQ = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return LrJcaCo3HY;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		LrJcaCo3HY = WithEventsValue;
	}

	[DllImport("user32", CharSet = CharSet.Ansi, EntryPoint = "SetFocus", ExactSpelling = true, SetLastError = true)]
	private static extern IntPtr vHicOpIWJS(IntPtr P_0);

	public FrmTrocaUsuario()
	{
		try
		{
			OITcMsvPhF();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1786]);
			ckUsuario.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1789]);
			ckData.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 65]);
			CKBanco.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1788]);
			CKBanco.Checked = true;
			GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1787]);
			GroupBox2.Text = "";
			Application.ShowModelessDialog((Form)this);
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
			tbUser.Text = Environment.UserName;
			tbData.Text = DateTime.Now.ToString();
			if (!clsAuxiliar.BancoValido())
			{
				CKBanco.Checked = false;
				CKBanco.Enabled = false;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void jfVcI4heQL(object P_0, EventArgs P_1)
	{
		UserDataEL.UserData(tbUser.Text, tbData.Text, ckUsuario.Checked, ckData.Checked, CKBanco.Checked);
		Close();
	}
}
