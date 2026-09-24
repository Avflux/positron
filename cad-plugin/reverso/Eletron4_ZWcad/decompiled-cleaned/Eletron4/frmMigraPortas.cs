using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmMigraPortas : Form
{
	private IContainer VpmpDlaVeGf;

	[AccessedThroughProperty("gbDe")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox jempD5mbLRo;

	[AccessedThroughProperty("dg")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView b7NpD0hn0pJ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbAlternativo")]
	private TextBox CgApDRTLIEJ;

	[CompilerGenerated]
	[AccessedThroughProperty("LBPainel")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label IcCpDmtH4Ej;

	[AccessedThroughProperty("LBNome1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label d7xpDXbVICP;

	[AccessedThroughProperty("tbNome2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox x2UpDUVbSq1;

	[AccessedThroughProperty("LBNome2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label OPEpDyF0Sea;

	[CompilerGenerated]
	[AccessedThroughProperty("tbNome1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox f2vpDg79D6I;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBAlternativo")]
	private Label RjjpDAAex4a;

	[CompilerGenerated]
	[AccessedThroughProperty("BTMigra")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button RBdpDsX6Xp2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTSeleciona")]
	private Button HoapDB6xOQW;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolTip DV7pDVcDrZZ;

	[CompilerGenerated]
	[AccessedThroughProperty("TBPainelNovo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox xuKpDuN7eG9;

	[AccessedThroughProperty("TBPainel")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox vP0pDE0Csn1;

	[AccessedThroughProperty("tbAlternativoNovo")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox gCApDZMN1dn;

	[AccessedThroughProperty("tbNomeNovo2")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox FLopDiqNXh1;

	[AccessedThroughProperty("tbNomeNovo1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox PoOpDSa5eKR;

	[CompilerGenerated]
	[AccessedThroughProperty("gbPara")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox APlpD4JctHm;

	private Declaracoes2.MMascara[] g2ppDCu3AtM;

	private DeclaracoesEntidades.StructurePortas[] TAtpDY1UGlB;

	private bool CpopDrjhTyZ;

	internal virtual GroupBox gbDe
	{
		[CompilerGenerated]
		get
		{
			return jempD5mbLRo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jempD5mbLRo = value;
		}
	}

	internal virtual DataGridView dg
	{
		[CompilerGenerated]
		get
		{
			return b7NpD0hn0pJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellMouseEventHandler value2 = TSnpD2QtPPE;
			KeyEventHandler value3 = DTCpD3LlAvy;
			KeyEventHandler value4 = oCXpDnkhS5c;
			DataGridView dataGridView = b7NpD0hn0pJ;
			if (dataGridView != null)
			{
				dataGridView.CellMouseUp -= value2;
				dataGridView.KeyDown -= value3;
				dataGridView.KeyUp -= value4;
			}
			b7NpD0hn0pJ = value;
			dataGridView = b7NpD0hn0pJ;
			if (dataGridView != null)
			{
				dataGridView.CellMouseUp += value2;
				dataGridView.KeyDown += value3;
				dataGridView.KeyUp += value4;
			}
		}
	}

	internal virtual TextBox tbAlternativo
	{
		[CompilerGenerated]
		get
		{
			return CgApDRTLIEJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CgApDRTLIEJ = value;
		}
	}

	internal virtual Label LBPainel
	{
		[CompilerGenerated]
		get
		{
			return IcCpDmtH4Ej;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			IcCpDmtH4Ej = value;
		}
	}

	internal virtual Label LBNome1
	{
		[CompilerGenerated]
		get
		{
			return d7xpDXbVICP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			d7xpDXbVICP = value;
		}
	}

	internal virtual TextBox tbNome2
	{
		[CompilerGenerated]
		get
		{
			return x2UpDUVbSq1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			x2UpDUVbSq1 = value;
		}
	}

	internal virtual Label LBNome2
	{
		[CompilerGenerated]
		get
		{
			return OPEpDyF0Sea;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			OPEpDyF0Sea = value;
		}
	}

	internal virtual TextBox tbNome1
	{
		[CompilerGenerated]
		get
		{
			return f2vpDg79D6I;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			f2vpDg79D6I = value;
		}
	}

	internal virtual Label LBAlternativo
	{
		[CompilerGenerated]
		get
		{
			return RjjpDAAex4a;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			RjjpDAAex4a = value;
		}
	}

	internal virtual Button BTMigra
	{
		[CompilerGenerated]
		get
		{
			return RBdpDsX6Xp2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Hd9pDeQDdxT;
			Button button = RBdpDsX6Xp2;
			if (button != null)
			{
				button.Click -= value2;
			}
			RBdpDsX6Xp2 = value;
			button = RBdpDsX6Xp2;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTSeleciona
	{
		[CompilerGenerated]
		get
		{
			return HoapDB6xOQW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SiLpDcZOGw9;
			Button button = HoapDB6xOQW;
			if (button != null)
			{
				button.Click -= value2;
			}
			HoapDB6xOQW = value;
			button = HoapDB6xOQW;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox TBPainelNovo
	{
		[CompilerGenerated]
		get
		{
			return xuKpDuN7eG9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			xuKpDuN7eG9 = value;
		}
	}

	internal virtual TextBox TBPainel
	{
		[CompilerGenerated]
		get
		{
			return vP0pDE0Csn1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			vP0pDE0Csn1 = value;
		}
	}

	internal virtual TextBox tbAlternativoNovo
	{
		[CompilerGenerated]
		get
		{
			return gCApDZMN1dn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			gCApDZMN1dn = value;
		}
	}

	internal virtual TextBox tbNomeNovo2
	{
		[CompilerGenerated]
		get
		{
			return FLopDiqNXh1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			FLopDiqNXh1 = value;
		}
	}

	internal virtual TextBox tbNomeNovo1
	{
		[CompilerGenerated]
		get
		{
			return PoOpDSa5eKR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PoOpDSa5eKR = value;
		}
	}

	internal virtual GroupBox gbPara
	{
		[CompilerGenerated]
		get
		{
			return APlpD4JctHm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			APlpD4JctHm = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && VpmpDlaVeGf != null)
			{
				VpmpDlaVeGf.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void qUapDP3BuyB()
	{
		VpmpDlaVeGf = new Container();
		gbDe = new GroupBox();
		TBPainel = new TextBox();
		tbAlternativo = new TextBox();
		tbNome2 = new TextBox();
		tbNome1 = new TextBox();
		LBPainel = new Label();
		BTSeleciona = new Button();
		LBNome1 = new Label();
		LBNome2 = new Label();
		LBAlternativo = new Label();
		TBPainelNovo = new TextBox();
		tbAlternativoNovo = new TextBox();
		tbNomeNovo2 = new TextBox();
		tbNomeNovo1 = new TextBox();
		BTMigra = new Button();
		dg = new DataGridView();
		FDqpBiUmZij(new ToolTip(VpmpDlaVeGf));
		gbPara = new GroupBox();
		gbDe.SuspendLayout();
		((ISupportInitialize)dg).BeginInit();
		gbPara.SuspendLayout();
		SuspendLayout();
		gbDe.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		gbDe.Controls.Add(TBPainel);
		gbDe.Controls.Add(tbAlternativo);
		gbDe.Controls.Add(tbNome2);
		gbDe.Controls.Add(tbNome1);
		gbDe.Controls.Add(LBPainel);
		gbDe.Controls.Add(BTSeleciona);
		gbDe.Controls.Add(LBNome1);
		gbDe.Controls.Add(LBNome2);
		gbDe.Controls.Add(LBAlternativo);
		gbDe.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		gbDe.Location = new Point(12, 12);
		gbDe.Name = "gbDe";
		gbDe.Size = new Size(565, 63);
		gbDe.TabIndex = 15;
		gbDe.TabStop = false;
		gbDe.Text = "DE";
		TBPainel.Enabled = false;
		TBPainel.Location = new Point(372, 34);
		TBPainel.Name = "TBPainel";
		TBPainel.Size = new Size(136, 20);
		TBPainel.TabIndex = 148;
		tbAlternativo.Enabled = false;
		tbAlternativo.Location = new Point(250, 34);
		tbAlternativo.Name = "tbAlternativo";
		tbAlternativo.Size = new Size(116, 20);
		tbAlternativo.TabIndex = 27;
		tbNome2.Enabled = false;
		tbNome2.Location = new Point(128, 34);
		tbNome2.Name = "tbNome2";
		tbNome2.Size = new Size(116, 20);
		tbNome2.TabIndex = 25;
		tbNome1.Enabled = false;
		tbNome1.Location = new Point(6, 34);
		tbNome1.Name = "tbNome1";
		tbNome1.Size = new Size(116, 20);
		tbNome1.TabIndex = 24;
		LBPainel.AutoSize = true;
		LBPainel.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		LBPainel.Location = new Point(372, 18);
		LBPainel.Name = "LBPainel";
		LBPainel.Size = new Size(49, 13);
		LBPainel.TabIndex = 26;
		LBPainel.Text = "LBPainel";
		BTSeleciona.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		BTSeleciona.FlatStyle = FlatStyle.Flat;
		BTSeleciona.ForeColor = SystemColors.Control;
		BTSeleciona.Image = Resources.Select_32;
		BTSeleciona.Location = new Point(514, 18);
		BTSeleciona.Name = "BTSeleciona";
		BTSeleciona.Size = new Size(40, 40);
		BTSeleciona.TabIndex = 138;
		BTSeleciona.UseVisualStyleBackColor = true;
		LBNome1.AutoSize = true;
		LBNome1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		LBNome1.Location = new Point(6, 18);
		LBNome1.Name = "LBNome1";
		LBNome1.Size = new Size(54, 13);
		LBNome1.TabIndex = 28;
		LBNome1.Text = "LBNome1";
		LBNome2.AutoSize = true;
		LBNome2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		LBNome2.Location = new Point(128, 18);
		LBNome2.Name = "LBNome2";
		LBNome2.Size = new Size(54, 13);
		LBNome2.TabIndex = 29;
		LBNome2.Text = "LBNome2";
		LBAlternativo.AutoSize = true;
		LBAlternativo.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		LBAlternativo.Location = new Point(250, 18);
		LBAlternativo.Name = "LBAlternativo";
		LBAlternativo.Size = new Size(70, 13);
		LBAlternativo.TabIndex = 30;
		LBAlternativo.Text = "LBAlternativo";
		TBPainelNovo.Enabled = false;
		TBPainelNovo.Location = new Point(372, 23);
		TBPainelNovo.Name = "TBPainelNovo";
		TBPainelNovo.Size = new Size(136, 20);
		TBPainelNovo.TabIndex = 149;
		tbAlternativoNovo.Enabled = false;
		tbAlternativoNovo.Location = new Point(250, 23);
		tbAlternativoNovo.Name = "tbAlternativoNovo";
		tbAlternativoNovo.Size = new Size(116, 20);
		tbAlternativoNovo.TabIndex = 144;
		tbNomeNovo2.Enabled = false;
		tbNomeNovo2.Location = new Point(128, 23);
		tbNomeNovo2.Name = "tbNomeNovo2";
		tbNomeNovo2.Size = new Size(116, 20);
		tbNomeNovo2.TabIndex = 142;
		tbNomeNovo1.Enabled = false;
		tbNomeNovo1.Location = new Point(6, 22);
		tbNomeNovo1.Name = "tbNomeNovo1";
		tbNomeNovo1.Size = new Size(116, 20);
		tbNomeNovo1.TabIndex = 141;
		BTMigra.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		BTMigra.FlatStyle = FlatStyle.Flat;
		BTMigra.ForeColor = SystemColors.Control;
		BTMigra.Image = Resources.OK_32;
		BTMigra.Location = new Point(514, 9);
		BTMigra.Name = "BTMigra";
		BTMigra.Size = new Size(40, 40);
		BTMigra.TabIndex = 139;
		BTMigra.UseVisualStyleBackColor = true;
		dg.AllowUserToAddRows = false;
		dg.AllowUserToDeleteRows = false;
		dg.AllowUserToResizeRows = false;
		dg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dg.BackgroundColor = Color.White;
		dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dg.Location = new Point(12, 141);
		dg.MultiSelect = false;
		dg.Name = "dg";
		dg.ReadOnly = true;
		dg.RowHeadersVisible = false;
		dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dg.Size = new Size(563, 158);
		dg.TabIndex = 19;
		gbPara.Controls.Add(TBPainelNovo);
		gbPara.Controls.Add(tbAlternativoNovo);
		gbPara.Controls.Add(tbNomeNovo1);
		gbPara.Controls.Add(BTMigra);
		gbPara.Controls.Add(tbNomeNovo2);
		gbPara.Location = new Point(12, 81);
		gbPara.Name = "gbPara";
		gbPara.Size = new Size(565, 53);
		gbPara.TabIndex = 20;
		gbPara.TabStop = false;
		gbPara.Text = "PARA";
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(584, 311);
		Controls.Add(gbPara);
		Controls.Add(dg);
		Controls.Add(gbDe);
		MaximizeBox = false;
		MaximumSize = new Size(600, 1000);
		MinimizeBox = false;
		MinimumSize = new Size(600, 350);
		Name = "frmMigraPortas";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Migrar Porta";
		gbDe.ResumeLayout(performLayout: false);
		gbDe.PerformLayout();
		((ISupportInitialize)dg).EndInit();
		gbPara.ResumeLayout(performLayout: false);
		gbPara.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return DV7pDVcDrZZ;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		DV7pDVcDrZZ = WithEventsValue;
	}

	public frmMigraPortas()
	{
		Resize += mZVpDKfTXZw;
		CpopDrjhTyZ = true;
		DataGridView withEventsValue;
		try
		{
			if (Geral.ExisteForm("frmMigraPotras") || !clsAuxiliar.BancoValido())
			{
				return;
			}
			cDadosAccess.carregaDadosDWG();
			if (DeclaracoesGeral.arqAtivo.Indice == 0)
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 331]), MsgBoxStyle.Information);
				return;
			}
			qUapDP3BuyB();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 539]);
			gbDe.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 48]);
			gbPara.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 49]);
			LBPainel.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 626]);
			LBNome1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 627]);
			LBNome2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 628]);
			LBAlternativo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 629]);
			w8dpBZ0kvSD().SetToolTip(BTSeleciona, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1144]));
			w8dpBZ0kvSD().SetToolTip(BTMigra, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 539]));
			clsMascara.CarregaMascaras(ref g2ppDCu3AtM);
			withEventsValue = dg;
			carregaMascarasNoDG(ref withEventsValue, g2ppDCu3AtM, bPrincipal: true);
			dg = withEventsValue;
			Application.ShowModelessDialog((Form)this);
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
			CpopDrjhTyZ = false;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		withEventsValue = dg;
		AtualizaColunasDGMascaras(ref withEventsValue, bPrincipal: false);
		dg = withEventsValue;
	}

	private void SiLpDcZOGw9(object P_0, EventArgs P_1)
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected Obj, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected Obj, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Invalid comparison between Unknown and I4
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected Obj, but got Unknown
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected Obj, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Expected Obj, but got Unknown
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Expected Obj, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Expected Obj, but got Unknown
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		TAtpDY1UGlB = new DeclaracoesEntidades.StructurePortas[1];
		DataGridView withEventsValue = dg;
		carregaMascarasNoDG(ref withEventsValue, g2ppDCu3AtM, bPrincipal: true);
		dg = withEventsValue;
		withEventsValue = dg;
		AtualizaColunasDGMascaras(ref withEventsValue, bPrincipal: false);
		dg = withEventsValue;
		string text = "";
		int num = 0;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			TypedValue[] array = new TypedValue[2];
			array.SetValue((object)new TypedValue(0, (object)"INSERT"), 0);
			array.SetValue((object)new TypedValue(1001, (object)"DISPOSITIVO"), 1);
			SelectionFilter val2 = new SelectionFilter(array);
			PromptSelectionOptions val3 = new PromptSelectionOptions();
			val3.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 622]);
			PromptSelectionResult selection = editor.GetSelection(val3, val2);
			if ((int)selection.Status != 5100)
			{
				return;
			}
			SelectionSet value = selection.Value;
			ObjectIdCollection val4 = new ObjectIdCollection(value.GetObjectIds());
			new ObjectIdCollection();
			new List<double>();
			int num2 = 0;
			checked
			{
				foreach (object item in val4)
				{
					ObjectId val5 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
					BlockReference val6 = (BlockReference)val5.GetObject((OpenMode)0);
					Entity ent = (Entity)(object)val6;
					string tipoImportado = "";
					string text2 = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
					val6 = (BlockReference)ent;
					text = text2;
					if (Operators.CompareString(text, "E", TextCompare: true) == 0)
					{
						DeclaracoesEntidades.StructurePortas structurePortas = default;
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
						structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
						Point3d position;
						if (structurePortas.indiceDoModelo != 0 && num2 == 0)
						{
							position = val6.Position;
							num2 = (int)Math.Round(position.X);
							num = structurePortas.indiceDoModelo;
						}
						position = val6.Position;
						if (position.X < (double)num2)
						{
							num = structurePortas.indiceDoModelo;
							position = val6.Position;
							num2 = (int)Math.Round(position.X);
						}
					}
				}
				if (num != 0)
				{
					foreach (object item2 in val4)
					{
						ObjectId val7 = ((item2 == null) ? default(ObjectId) : ((ObjectId)item2));
						BlockReference val8 = (BlockReference)val7.GetObject((OpenMode)0);
						Entity ent = (Entity)(object)val8;
						string text2 = "";
						string tipoImportado = XDataDispositivo.verificaTipoDispositivo(ref ent, ref text2);
						val8 = (BlockReference)ent;
						text = tipoImportado;
						if (Operators.CompareString(text, "E", TextCompare: true) != 0)
						{
							continue;
						}
						DeclaracoesEntidades.StructurePortas structurePortas2 = default;
						object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val8);
						structurePortas2 = ((obj2 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj2));
						if (structurePortas2.indiceDoModelo != 0)
						{
							if (Information.UBound(TAtpDY1UGlB) == 0)
							{
								tbNome1.Text = structurePortas2.Nome1;
								tbNome2.Text = structurePortas2.Nome2;
								tbAlternativo.Text = structurePortas2.Alternativo;
								TBPainel.Text = clsMascara.BuscaPainel(structurePortas2.HandleDaMascara);
							}
							if (num == structurePortas2.indiceDoModelo)
							{
								int num3 = Information.UBound(TAtpDY1UGlB) + 1;
								ref DeclaracoesEntidades.StructurePortas[] tAtpDY1UGlB = ref TAtpDY1UGlB;
								tAtpDY1UGlB = (DeclaracoesEntidades.StructurePortas[])Utils.CopyArray(tAtpDY1UGlB, new DeclaracoesEntidades.StructurePortas[num3 + 1]);
								TAtpDY1UGlB[num3] = structurePortas2;
							}
						}
					}
					if (Information.UBound(TAtpDY1UGlB) > 0 && Information.UBound(TAtpDY1UGlB) >= 2)
					{
						long num4 = Information.UBound(TAtpDY1UGlB) - 1;
						for (long num5 = num4; num5 >= 1L; num5 += -1L)
						{
							long num6 = num5;
							for (long num7 = 1L; num7 <= num6; num7++)
							{
								if (TAtpDY1UGlB[(int)num7].indiceDaPorta > TAtpDY1UGlB[(int)(num7 + 1L)].indiceDaPorta)
								{
									DeclaracoesEntidades.StructurePortas structurePortas3 = TAtpDY1UGlB[(int)(num7 + 1L)];
									TAtpDY1UGlB[(int)(num7 + 1L)] = TAtpDY1UGlB[(int)num7];
									TAtpDY1UGlB[(int)num7] = structurePortas3;
								}
							}
						}
					}
					withEventsValue = dg;
					carregaMascarasNoDG(ref withEventsValue, g2ppDCu3AtM, bPrincipal: true);
					dg = withEventsValue;
					int num8 = dg.Rows.Count - 1;
					for (int i = num8; i >= 0; i += -1)
					{
						if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(dg.Rows[i].Cells[0].Value, tbNome1.Text, TextCompare: true), Operators.CompareObjectEqual(dg.Rows[i].Cells[1].Value, tbNome2.Text, TextCompare: true)), Operators.CompareObjectEqual(dg.Rows[i].Cells[2].Value, tbAlternativo.Text, TextCompare: true)), Operators.CompareObjectEqual(dg.Rows[i].Cells[3].Value, TBPainel.Text, TextCompare: true))))
						{
							dg.Rows.RemoveAt(i);
						}
					}
					int num9 = dg.Rows.Count - 1;
					for (int j = num9; j >= 0; j += -1)
					{
						dg.Rows[j].Selected = false;
					}
					tbNomeNovo1.Text = "";
					tbNomeNovo2.Text = "";
					tbAlternativoNovo.Text = "";
					TBPainelNovo.Text = "";
				}
				withEventsValue = dg;
				AtualizaColunasDGMascaras(ref withEventsValue, bPrincipal: false);
				dg = withEventsValue;
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			val.Abort();
			throw;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		PointMonitorToolTips.StartMonitor();
	}

	private void mZVpDKfTXZw(object P_0, EventArgs P_1)
	{
		if (!CpopDrjhTyZ)
		{
			DataGridView withEventsValue = dg;
			AtualizaColunasDGMascaras(ref withEventsValue, bPrincipal: false);
			dg = withEventsValue;
		}
	}

	private void Hd9pDeQDdxT(object P_0, EventArgs P_1)
	{
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected Obj, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected Obj, but got Unknown
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		_ = Application.DocumentManager.MdiActiveDocument.Editor;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
			try
			{
				if (Information.UBound(TAtpDY1UGlB) > 0)
				{
					int num = Information.UBound(TAtpDY1UGlB);
					for (int i = 1; i <= num; i++)
					{
						clsPortas.IndefineUmaPorta(TAtpDY1UGlB[i].HandleBloco, bLimpaTudo: true);
						ObjectId val2 = Geral.HandleToID(TAtpDY1UGlB[i].HandleBloco);
						if (!val2.IsValid)
						{
							continue;
						}
						Entity ent = (Entity)val.GetObject(val2, (OpenMode)0);
						if (ent != null)
						{
							DeclaracoesEntidades.StructurePortas structurePortas = default;
							string tipoImportado = "";
							if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "E", TextCompare: true) == 0)
							{
								BlockReference blockRef = (BlockReference)ent;
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								ent = (Entity)(object)blockRef;
								structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
								structurePortas.Nome1 = Conversions.ToString(dg.SelectedRows[0].Cells[0].Value);
								structurePortas.Nome2 = Conversions.ToString(dg.SelectedRows[0].Cells[1].Value);
								structurePortas.Alternativo = Conversions.ToString(dg.SelectedRows[0].Cells[2].Value);
								structurePortas.indiceDaPorta = 0;
								structurePortas.handleDaDefinicao = "";
								structurePortas.chavePrimaria = "";
								structurePortas.HandleDaMascara = Conversions.ToString(dg.SelectedRows[0].Cells[5].Value);
								structurePortas.HandleBloco = "";
								structurePortas.indiceDoModelo = Conversions.ToInteger(dg.SelectedRows[0].Cells[7].Value);
								tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.PreencheOsNomesDeUmBloco(ref tipoImportado, structurePortas.Nome1, structurePortas.Nome2, structurePortas.Alternativo);
								tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.EditaUmAtributoDeUmBloco(ref tipoImportado, "MODELO", "");
								XDataDispositivosMaster.GravarXDataPorta(ref ent, ref structurePortas);
							}
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				tbNome1.Text = "";
				tbNome2.Text = "";
				tbAlternativo.Text = "";
				TBPainel.Text = "";
				tbNomeNovo1.Text = "";
				tbNomeNovo2.Text = "";
				tbAlternativoNovo.Text = "";
				TBPainelNovo.Text = "";
				int num2 = dg.Rows.Count - 1;
				for (int j = num2; j >= 0; j += -1)
				{
					dg.Rows[j].Selected = false;
				}
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
			DataGridView withEventsValue = dg;
			carregaMascarasNoDG(ref withEventsValue, g2ppDCu3AtM, bPrincipal: true);
			dg = withEventsValue;
			withEventsValue = dg;
			AtualizaColunasDGMascaras(ref withEventsValue, bPrincipal: false);
			dg = withEventsValue;
			PointMonitorToolTips.StartMonitor();
		}
	}

	private void TSnpD2QtPPE(object P_0, DataGridViewCellMouseEventArgs P_1)
	{
		Ll2pD1vWhRu();
	}

	private void DTCpD3LlAvy(object P_0, KeyEventArgs P_1)
	{
		Ll2pD1vWhRu();
	}

	private void oCXpDnkhS5c(object P_0, KeyEventArgs P_1)
	{
		Ll2pD1vWhRu();
	}

	private void Ll2pD1vWhRu()
	{
		if (dg.SelectedRows.Count > 0)
		{
			tbNomeNovo1.Text = Conversions.ToString(dg.SelectedRows[0].Cells[0].Value);
			tbNomeNovo2.Text = Conversions.ToString(dg.SelectedRows[0].Cells[1].Value);
			tbAlternativoNovo.Text = Conversions.ToString(dg.SelectedRows[0].Cells[2].Value);
			TBPainelNovo.Text = Conversions.ToString(dg.SelectedRows[0].Cells[3].Value);
		}
	}

	public static void carregaMascarasNoDG(ref DataGridView dg, Declaracoes2.MMascara[] mMasc, bool bPrincipal)
	{
		checked
		{
			try
			{
				dg.Rows.Clear();
				dg.Columns.Clear();
				dg.Columns.Add("Máscara", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1001]));
				dg.Columns.Add("Máscara", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1002]));
				dg.Columns.Add("Máscara", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1004]));
				dg.Columns.Add("Painel", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1005]));
				dg.Columns.Add("Página", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 993]));
				dg.Columns.Add("Handle", "");
				dg.Columns.Add("Tipo", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 995]));
				dg.Columns.Add("Index", "Index");
				dg.ColumnHeadersVisible = true;
				object[,] array = null;
				array = new object[5, 1];
				object mPaineis = array;
				cDadosAccess.carregaDadosPNs(ref mPaineis, "Paineis");
				array = (object[,])mPaineis;
				if (Information.UBound(mMasc) > 0)
				{
					int num = Information.UBound(mMasc);
					for (int i = 1; i <= num; i++)
					{
						mMasc[i].sPainel = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
						int num2 = Information.UBound(array, 2);
						for (int j = 1; j <= num2; j++)
						{
							if (Operators.ConditionalCompareObjectEqual(array[0, j], mMasc[i].iPainel, TextCompare: true))
							{
								mMasc[i].sPainel = Conversions.ToString(array[1, j]);
								break;
							}
						}
						if (bPrincipal)
						{
							dg.Rows.Add(mMasc[i].sNome1, mMasc[i].sNome2, mMasc[i].sNome3, mMasc[i].sPainel, mMasc[i].sPagina, mMasc[i].sHandle, mMasc[i].sTipo, mMasc[i].iIndiceModelo);
						}
						else if (Operators.CompareString(mMasc[i].sTipo, "P", TextCompare: true) == 0)
						{
							dg.Rows.Add(mMasc[i].sNome1, mMasc[i].sNome2, mMasc[i].sNome3, mMasc[i].sPainel, mMasc[i].sPagina, mMasc[i].sHandle, "", mMasc[i].iIndiceModelo);
						}
					}
				}
				int num3 = dg.Rows.Count - 1;
				for (int k = num3; k >= 0; k += -1)
				{
					if (Operators.ConditionalCompareObjectNotEqual(dg.Rows[k].Cells[6].Value, "P", TextCompare: true))
					{
						dg.Rows.RemoveAt(k);
					}
				}
				AtualizaColunasDGMascaras(ref dg, bPrincipal);
				foreach (DataGridViewRow item in (IEnumerable)dg.Rows)
				{
					dg.Rows[item.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				AtualizaColunasDGMascaras(ref dg, bPrincipal);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
		}
	}

	public static void AtualizaColunasDGMascaras(ref DataGridView dg, bool bPrincipal)
	{
		if (dg.RowCount == 0)
		{
			return;
		}
		checked
		{
			double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
			bool flag = false;
			bool flag2 = false;
			int num2 = dg.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (Operators.ConditionalCompareObjectNotEqual(dg.Rows[i].Cells[1].Value, "", TextCompare: true))
				{
					flag = true;
				}
				if (Operators.ConditionalCompareObjectNotEqual(dg.Rows[i].Cells[2].Value, "", TextCompare: true))
				{
					flag2 = true;
				}
			}
			int num3 = 1;
			if (flag)
			{
				num3++;
			}
			if (flag2)
			{
				num3++;
			}
			if (!bPrincipal)
			{
				dg.Columns[0].Width = (int)Math.Round(num * (0.5 / (double)num3));
				dg.Columns[1].Width = (int)Math.Round(num * (0.5 / (double)num3));
				dg.Columns[2].Width = (int)Math.Round(num * (0.5 / (double)num3));
				dg.Columns[3].Width = (int)Math.Round(num * 0.3);
				dg.Columns[4].Width = (int)Math.Round(num * 0.2);
				dg.Columns[5].Width = 0;
				dg.Columns[6].Width = 0;
				dg.Columns[7].Width = 0;
			}
			else
			{
				dg.Columns[0].Width = (int)Math.Round(num * (0.5 / (double)num3));
				dg.Columns[1].Width = (int)Math.Round(num * (0.5 / (double)num3));
				dg.Columns[2].Width = (int)Math.Round(num * (0.5 / (double)num3));
				dg.Columns[3].Width = (int)Math.Round(num * 0.25);
				dg.Columns[4].Width = (int)Math.Round(num * 0.15);
				dg.Columns[5].Width = 0;
				dg.Columns[6].Width = (int)Math.Round(num * 0.1);
				dg.Columns[7].Width = 0;
			}
			dg.Columns[0].Visible = true;
			dg.Columns[1].Visible = false;
			dg.Columns[2].Visible = false;
			if (flag)
			{
				dg.Columns[1].Visible = true;
			}
			if (flag2)
			{
				dg.Columns[2].Visible = true;
			}
			dg.Columns[3].Visible = true;
			dg.Columns[4].Visible = true;
			dg.Columns[5].Visible = false;
			if (!bPrincipal)
			{
				dg.Columns[6].Visible = false;
			}
			else
			{
				dg.Columns[6].Visible = true;
			}
			dg.Columns[7].Visible = false;
			dg.Columns[0].ReadOnly = false;
			dg.Columns[1].ReadOnly = false;
			dg.Columns[2].ReadOnly = false;
			dg.Columns[3].ReadOnly = false;
			dg.Columns[4].ReadOnly = false;
			dg.Columns[5].ReadOnly = false;
			dg.Columns[6].ReadOnly = false;
			dg.Columns[7].ReadOnly = false;
			dg.MultiSelect = false;
		}
	}
}
