using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

[DesignerGenerated]
public class frmDuplicarCaderno : Form
{
	private IContainer saCN8YvElv;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolTip LpeNN7egb0;

	[AccessedThroughProperty("FolderBrowser")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private FolderBrowserDialog i5vNFXjUGa;

	[CompilerGenerated]
	[AccessedThroughProperty("btCriar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button PypNQxnAfE;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbNomeNovoArquivo")]
	private TextBox dbGNPwJQej;

	[CompilerGenerated]
	[AccessedThroughProperty("lbNomeNovoDWG")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label V5VNc7nFnS;

	[AccessedThroughProperty("tbCaderno")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox I7QNKPMeAY;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbNomeDoCaderno")]
	private Label oggNeEPpGK;

	private clsImportarProjetos.mDWG[] brON27MnNV;

	private string l1uN3l6Ecf;

	private List<string> JG2Nn8wCP2;

	private string pE2N1NJmDC;

	private int DJgNlee8Jn;

	private int AAbN5k7gFR;

	internal virtual Button btCriar
	{
		[CompilerGenerated]
		get
		{
			return PypNQxnAfE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DUNNa4L0SB;
			Button button = PypNQxnAfE;
			if (button != null)
			{
				button.Click -= value2;
			}
			PypNQxnAfE = value;
			button = PypNQxnAfE;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbNomeNovoArquivo
	{
		[CompilerGenerated]
		get
		{
			return dbGNPwJQej;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = AVFN7oupXc;
			TextBox textBox = dbGNPwJQej;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			dbGNPwJQej = value;
			textBox = dbGNPwJQej;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Label lbNomeNovoDWG
	{
		[CompilerGenerated]
		get
		{
			return V5VNc7nFnS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			V5VNc7nFnS = value;
		}
	}

	internal virtual TextBox tbCaderno
	{
		[CompilerGenerated]
		get
		{
			return I7QNKPMeAY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			I7QNKPMeAY = value;
		}
	}

	internal virtual Label lbNomeDoCaderno
	{
		[CompilerGenerated]
		get
		{
			return oggNeEPpGK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			oggNeEPpGK = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && saCN8YvElv != null)
			{
				saCN8YvElv.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void DaCNIKn1xI()
	{
		saCN8YvElv = new Container();
		FDqpBiUmZij(new ToolTip(saCN8YvElv));
		aHypBEW66iS(new FolderBrowserDialog());
		btCriar = new Button();
		tbNomeNovoArquivo = new TextBox();
		lbNomeNovoDWG = new Label();
		tbCaderno = new TextBox();
		lbNomeDoCaderno = new Label();
		SuspendLayout();
		btCriar.FlatStyle = FlatStyle.Flat;
		btCriar.ForeColor = SystemColors.Control;
		btCriar.Image = Resources.NovoDWG_32;
		btCriar.Location = new Point(332, 42);
		btCriar.Name = "btCriar";
		btCriar.Size = new Size(40, 50);
		btCriar.TabIndex = 150;
		btCriar.UseVisualStyleBackColor = true;
		tbNomeNovoArquivo.BackColor = Color.White;
		tbNomeNovoArquivo.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbNomeNovoArquivo.Location = new Point(15, 34);
		tbNomeNovoArquivo.Name = "tbNomeNovoArquivo";
		tbNomeNovoArquivo.Size = new Size(299, 20);
		tbNomeNovoArquivo.TabIndex = 190;
		lbNomeNovoDWG.AutoSize = true;
		lbNomeNovoDWG.Location = new Point(12, 16);
		lbNomeNovoDWG.Name = "lbNomeNovoDWG";
		lbNomeNovoDWG.Size = new Size(133, 13);
		lbNomeNovoDWG.TabIndex = 191;
		lbNomeNovoDWG.Text = "lbNome Do Caderno DWG";
		tbCaderno.Location = new Point(15, 81);
		tbCaderno.Name = "tbCaderno";
		tbCaderno.Size = new Size(299, 20);
		tbCaderno.TabIndex = 2;
		lbNomeDoCaderno.AutoSize = true;
		lbNomeDoCaderno.Location = new Point(15, 63);
		lbNomeDoCaderno.Name = "lbNomeDoCaderno";
		lbNomeDoCaderno.Size = new Size(103, 13);
		lbNomeDoCaderno.TabIndex = 192;
		lbNomeDoCaderno.Text = "lbNome Do Caderno";
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(384, 111);
		Controls.Add(lbNomeDoCaderno);
		Controls.Add(tbCaderno);
		Controls.Add(tbNomeNovoArquivo);
		Controls.Add(lbNomeNovoDWG);
		Controls.Add(btCriar);
		MaximizeBox = false;
		MaximumSize = new Size(400, 150);
		MinimumSize = new Size(400, 150);
		Name = "frmDuplicarCaderno";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "frmDuplicar Caderno";
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return LpeNN7egb0;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		LpeNN7egb0 = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return i5vNFXjUGa;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		i5vNFXjUGa = WithEventsValue;
	}

	public frmDuplicarCaderno()
	{
		l1uN3l6Ecf = "";
		JG2Nn8wCP2 = new List<string>();
		pE2N1NJmDC = DeclaracoesGeral.Conf.DirProjeto;
		try
		{
			if (Geral.ExisteForm("frmDuplicarCaderno") || !clsAuxiliar.BancoValido())
			{
				return;
			}
			XDataGeral.LerXDataConfiguracao();
			XDataGeral.LerXDataConfiguracao2();
			DaCNIKn1xI();
			l1uN3l6Ecf = DeclaracoesGeral.Conf.DirProjeto.ToString();
			w8dpBZ0kvSD().SetToolTip(btCriar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1376]));
			cDadosAccessImportarProj cDadosAccessImportarProj2 = new cDadosAccessImportarProj();
			try
			{
				cDadosAccessImportarProj2.CarregaDWGImpProj(ref brON27MnNV);
				int num = Information.UBound(brON27MnNV);
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					JG2Nn8wCP2.Add(brON27MnNV[i].sNome.ToUpper());
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			finally
			{
				cDadosAccessImportarProj2.fechaConexao();
			}
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1377]);
			Application.ShowModelessDialog((Form)this);
			lbNomeNovoDWG.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1939]);
			lbNomeDoCaderno.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1940]);
			btCriar.Enabled = false;
			tbCaderno.Text = DeclaracoesGeral.Conf.Local;
			cDadosAccess.carregaDadosDWG();
			tbNomeNovoArquivo.Text = DeclaracoesGeral.arqAtivo.Nome;
			DxLNqXHnuJ();
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
	}

	private void AVFN7oupXc(object P_0, KeyEventArgs P_1)
	{
		DxLNqXHnuJ();
	}

	private void DxLNqXHnuJ()
	{
		btCriar.Enabled = true;
		string item = tbNomeNovoArquivo.Text.ToUpper();
		if (JG2Nn8wCP2.Contains(item))
		{
			btCriar.Enabled = false;
		}
		item = DeclaracoesGeral.arqAtivo.Path + tbNomeNovoArquivo.Text + ".dwg";
		item = item.ToUpper();
		if (File.Exists(item))
		{
			btCriar.Enabled = false;
		}
	}

	private void DUNNa4L0SB(object P_0, EventArgs P_1)
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		cDadosAccessDWG cDadosAccessDWG2 = new cDadosAccessDWG();
		DJgNlee8Jn = cDadosAccessDWG2.BuscaIndiceArquivo("DWG", DeclaracoesGeral.arqAtivo.Nome);
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		database.SaveAs(mdiActiveDocument.Name, true, (DwgVersion)31, database.SecurityParameters);
		_ = mdiActiveDocument.Editor;
		string text = DeclaracoesGeral.arqAtivo.Path + tbNomeNovoArquivo.Text + ".dwg";
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			database.SaveAs(text, true, (DwgVersion)31, database.SecurityParameters);
			new Database(false, false);
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			val.Abort();
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		string userName = Environment.UserName;
		string text2 = "";
		DateTime sData = Conversions.ToDate(DateTime.Now.ToString());
		string text3 = "DWG";
		string text4 = "DWGH";
		try
		{
			cDadosAccess.carregaDadosDWG();
			if (cDadosAccessDWG2.ExisteArquivo(text4, DeclaracoesGeral.arqAtivo.Nome))
			{
				cDadosAccessDWG2.RecuperaDWG(text3, text4, DeclaracoesGeral.arqAtivo.Nome);
				cDadosAccessDWG2.AtualizaDWG(text3, text2, sData, DeclaracoesGeral.arqAtivo.Nome);
				cDadosAccessDWG2.RemoveDWG(text4, DeclaracoesGeral.arqAtivo.Nome);
				AAbN5k7gFR = cDadosAccessDWG2.BuscaIndiceArquivo("DWG", DeclaracoesGeral.arqAtivo.Nome);
			}
			else
			{
				cDadosAccessDWG2.AdicionaCaderno(text3, AAbN5k7gFR = cDadosAccessDWG2.ProximoIndice(text3), userName, text2, sData);
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
			cDadosAccessDWG2.fechaConexao();
		}
		cDadosAccess.carregaDadosDWG();
		cDadosAccessDuplicaCaderno cDadosAccessDuplicaCaderno2 = new cDadosAccessDuplicaCaderno();
		try
		{
			cDadosAccessDuplicaCaderno2.CopiaFiacao(DJgNlee8Jn, AAbN5k7gFR);
			cDadosAccessDuplicaCaderno2.CopiaContatos4F(DJgNlee8Jn, AAbN5k7gFR);
			cDadosAccessDuplicaCaderno2.CopiaCircuitos4F(DJgNlee8Jn, AAbN5k7gFR);
			cDadosAccessDuplicaCaderno2.CopiaPortas4F(DJgNlee8Jn, AAbN5k7gFR);
			cDadosAccessDuplicaCaderno2.CopiaDispositivos4F(DJgNlee8Jn, AAbN5k7gFR);
			cDadosAccessDuplicaCaderno2.CopiaBornes4F(DJgNlee8Jn, AAbN5k7gFR);
			cDadosAccessDuplicaCaderno2.CopiaJumpers(DJgNlee8Jn, AAbN5k7gFR);
		}
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
		finally
		{
			cDadosAccessDuplicaCaderno2.fechaConexao();
		}
		clsExportImport.ApagaImportadoExportado();
		cDadosAccessMateriais cDadosAccessMateriais2 = new cDadosAccessMateriais();
		try
		{
			clsLM.LMateriais[] mMat = new clsLM.LMateriais[1];
			cDadosAccessMateriais2.LeItensAvulsosDaLM(DJgNlee8Jn, AAbN5k7gFR, ref mMat);
			cDadosAccessMateriais2.AdicionaItensMateriaisIdependentes(AAbN5k7gFR, mMat);
		}
		catch (Exception projectError3)
		{
			ProjectData.SetProjectError(projectError3);
			ProjectData.ClearProjectError();
		}
		finally
		{
			cDadosAccessMateriais2.fechaConexao();
		}
		DeclaracoesGeral.Conf.Local = tbCaderno.Text;
		XDataGeral.GravarXDataConfiguracao();
		Close();
		new frmTrocaPaineis(bAbre: true);
		PointMonitorToolTips.StartMonitor();
	}
}
