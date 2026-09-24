using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using ZwSoft.ZwCAD.ApplicationServices;

namespace Eletron4;

[DesignerGenerated]
public class frmConfiguracaoBDProjeto : Form
{
	private IContainer EocyKOwA0X;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbProjeto")]
	private TextBox OAwyetVO7s;

	[AccessedThroughProperty("SelProj")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button pN5y2ISikQ;

	internal virtual TextBox tbProjeto
	{
		[CompilerGenerated]
		get
		{
			return OAwyetVO7s;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			OAwyetVO7s = value;
		}
	}

	internal virtual Button SelProj
	{
		[CompilerGenerated]
		get
		{
			return pN5y2ISikQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = YX7yPFeedB;
			Button button = pN5y2ISikQ;
			if (button != null)
			{
				button.Click -= value2;
			}
			pN5y2ISikQ = value;
			button = pN5y2ISikQ;
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
			if (disposing && EocyKOwA0X != null)
			{
				EocyKOwA0X.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void AyMyQbAE6H()
	{
		tbProjeto = new TextBox();
		SelProj = new Button();
		SuspendLayout();
		tbProjeto.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		tbProjeto.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbProjeto.Location = new Point(12, 12);
		tbProjeto.Multiline = true;
		tbProjeto.Name = "tbProjeto";
		tbProjeto.Size = new Size(323, 68);
		tbProjeto.TabIndex = 3;
		SelProj.Anchor = AnchorStyles.Right;
		SelProj.FlatStyle = FlatStyle.Flat;
		SelProj.ForeColor = SystemColors.Control;
		SelProj.Image = Resources.Database_32;
		SelProj.Location = new Point(341, 27);
		SelProj.Name = "SelProj";
		SelProj.Size = new Size(36, 36);
		SelProj.TabIndex = 4;
		SelProj.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(384, 91);
		Controls.Add(tbProjeto);
		Controls.Add(SelProj);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		MaximumSize = new Size(1000, 400);
		MinimizeBox = false;
		MinimumSize = new Size(400, 130);
		Name = "frmConfiguracaoBDProjeto";
		ShowInTaskbar = false;
		Text = "frmConfiguracaoBDProjeto";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	public frmConfiguracaoBDProjeto()
	{
		if (Operators.CompareString(DeclaracoesGeral.Conf.Banco, "SV", TextCompare: true) != 0)
		{
			if (!Geral.ExisteForm("frmConfiguracaoBDProjeto"))
			{
				AyMyQbAE6H();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 107]);
				tbProjeto.Text = DeclaracoesGeral.Conf.DirProjeto;
				Application.ShowModelessDialog((Form)this);
				if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
				{
					Left = 0;
				}
			}
		}
		else
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1970]), MsgBoxStyle.Information, "Eletron");
		}
	}

	private void YX7yPFeedB(object P_0, EventArgs P_1)
	{
		try
		{
			Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
			openFileDialog.Title = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 237]);
			if (Operators.CompareString(DeclaracoesGeral.Conf.Banco, "A", TextCompare: true) != 0)
			{
				if (Operators.CompareString(DeclaracoesGeral.Conf.Banco, "S", TextCompare: true) == 0)
				{
					openFileDialog.Filter = "SQLite (*.db)|*.db";
					openFileDialog.DefaultExt = ".db";
				}
			}
			else
			{
				openFileDialog.Filter = "Access (*.accdb; *.mdb)|*.accdb;*.mdb";
				openFileDialog.DefaultExt = ".accdb";
			}
			openFileDialog.FileName = "";
			openFileDialog.RestoreDirectory = true;
			openFileDialog.Multiselect = false;
			openFileDialog.ValidateNames = true;
			if (openFileDialog.ShowDialog().Value)
			{
				tbProjeto.Text = openFileDialog.FileName;
				DeclaracoesGeral.Conf.DirProjeto = tbProjeto.Text.ToString().Trim();
				XDataGeral.GravarXDataConfiguracao2();
				PointMonitorToolTips.StopMonitor();
				if (Operators.CompareString(DeclaracoesGeral.Conf.DirProjeto, "", TextCompare: true) != 0 && File.Exists(DeclaracoesGeral.Conf.DirProjeto))
				{
					ACorrecaoBD.CorrigeBD();
					cDadosAccess.carregaPainelDicionario();
					PointMonitorToolTips.StartMonitor();
				}
				yKiycL7IZh();
				if (Information.IsNothing(DeclaracoesGeral.dicPainel))
				{
					cDadosAccess.carregaPainelDicionario();
				}
				cDadosAccess.carregaDWGDicionario();
				Close();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		finally
		{
		}
	}

	private void yKiycL7IZh()
	{
		string dWG = "DWG";
		string userName = Environment.UserName;
		DateTime sData = Conversions.ToDate(DateTime.Now.ToString());
		cDadosAccess.carregaDadosDWG();
		try
		{
			if (DeclaracoesGeral.arqAtivo.Indice <= 0)
			{
				if (DeclaracoesGeral.arqAtivo.Indice == 0)
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 323]), MsgBoxStyle.Information, "Eletron");
				}
			}
			else
			{
				cDadosAccessDWG cDadosAccessDWG2 = new cDadosAccessDWG();
				cDadosAccessDWG2.AtualizaValores(dWG, userName, sData);
				cDadosAccessDWG2.fechaConexao();
				cDadosAccess.carregaDadosDWG();
				cDadosAccess.carregaDWGDicionario();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical, "Eletron");
			ProjectData.ClearProjectError();
		}
		finally
		{
		}
	}
}
