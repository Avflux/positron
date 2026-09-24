using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmRelatorio_Fiacao_Compacta : Form
{
	private IContainer iykOHNqt1Z;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgRevisao")]
	private DataGridView iKNOkk0hce;

	[CompilerGenerated]
	[AccessedThroughProperty("dgEquip")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView V6COdqq4AH;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgDisp")]
	[CompilerGenerated]
	private DataGridView AMwOf1o7I2;

	[AccessedThroughProperty("dgFiacao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView EgOODaHM1Q;

	[AccessedThroughProperty("btPesquisar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button zg3Ov4oprj;

	[AccessedThroughProperty("dgDWG")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView vOTO6W9ILT;

	[AccessedThroughProperty("btExportaDWG")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button tW0OtZMLCp;

	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolTip SS8OjI2KQ4;

	private DeclaracoesFiacao.structurePnRev[] x3WOL4oRsi;

	private DeclaracoesFiacao.structureRevisoes[] p1aOwCEySu;

	private int xKaOxMtnZR;

	private string GVqObqdDlI;

	private int qXBOMxrjBR;

	private string AeBOOeZxYd;

	private int OyaOIIRnI7;

	private bool KR6O70HBIj;

	private bool wOEOqiLPE7;

	private bool AZSOaTxMTQ;

	private DeclaracoesFiacao.structureRelFiacao[] jEnO8Ocol7;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return iKNOkk0hce;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = YqhMS956gM;
			DataGridView dataGridView = iKNOkk0hce;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			iKNOkk0hce = value;
			dataGridView = iKNOkk0hce;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgEquip
	{
		[CompilerGenerated]
		get
		{
			return V6COdqq4AH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = erCMCPQYd8;
			DataGridView dataGridView = V6COdqq4AH;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			V6COdqq4AH = value;
			dataGridView = V6COdqq4AH;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgDisp
	{
		[CompilerGenerated]
		get
		{
			return AMwOf1o7I2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			AMwOf1o7I2 = value;
		}
	}

	internal virtual DataGridView dgFiacao
	{
		[CompilerGenerated]
		get
		{
			return EgOODaHM1Q;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EgOODaHM1Q = value;
		}
	}

	internal virtual Button btPesquisar
	{
		[CompilerGenerated]
		get
		{
			return zg3Ov4oprj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PapMzyOsyE;
			Button button = zg3Ov4oprj;
			if (button != null)
			{
				button.Click -= value2;
			}
			zg3Ov4oprj = value;
			button = zg3Ov4oprj;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgDWG
	{
		[CompilerGenerated]
		get
		{
			return vOTO6W9ILT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EhPMZRgWeg;
			DataGridView dataGridView = vOTO6W9ILT;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			vOTO6W9ILT = value;
			dataGridView = vOTO6W9ILT;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual Button btExportaDWG
	{
		[CompilerGenerated]
		get
		{
			return tW0OtZMLCp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = zYeM9Tt8jT;
			Button button = tW0OtZMLCp;
			if (button != null)
			{
				button.Click -= value2;
			}
			tW0OtZMLCp = value;
			button = tW0OtZMLCp;
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
			if (disposing && iykOHNqt1Z != null)
			{
				iykOHNqt1Z.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void nm5MEPWxUl()
	{
		iykOHNqt1Z = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmRelatorio_Fiacao_Compacta));
		dgRevisao = new DataGridView();
		dgEquip = new DataGridView();
		dgDisp = new DataGridView();
		dgFiacao = new DataGridView();
		btPesquisar = new Button();
		dgDWG = new DataGridView();
		btExportaDWG = new Button();
		FDqpBiUmZij(new ToolTip(iykOHNqt1Z));
		((ISupportInitialize)dgRevisao).BeginInit();
		((ISupportInitialize)dgEquip).BeginInit();
		((ISupportInitialize)dgDisp).BeginInit();
		((ISupportInitialize)dgFiacao).BeginInit();
		((ISupportInitialize)dgDWG).BeginInit();
		SuspendLayout();
		dgRevisao.AllowUserToAddRows = false;
		dgRevisao.AllowUserToDeleteRows = false;
		dgRevisao.AllowUserToOrderColumns = true;
		dgRevisao.AllowUserToResizeRows = false;
		dgRevisao.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgRevisao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgRevisao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgRevisao.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgRevisao.Location = new Point(277, 12);
		dgRevisao.MultiSelect = false;
		dgRevisao.Name = "dgRevisao";
		dgRevisao.ReadOnly = true;
		dgRevisao.RowHeadersVisible = false;
		dgRevisao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRevisao.Size = new Size(90, 175);
		dgRevisao.TabIndex = 3;
		dgEquip.AllowUserToAddRows = false;
		dgEquip.AllowUserToDeleteRows = false;
		dgEquip.AllowUserToOrderColumns = true;
		dgEquip.AllowUserToResizeRows = false;
		dgEquip.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgEquip.BackgroundColor = Color.White;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dgEquip.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgEquip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgEquip.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgEquip.Location = new Point(12, 193);
		dgEquip.MultiSelect = false;
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(155, 286);
		dgEquip.TabIndex = 8;
		dgDisp.AllowUserToAddRows = false;
		dgDisp.AllowUserToDeleteRows = false;
		dgDisp.AllowUserToOrderColumns = true;
		dgDisp.AllowUserToResizeRows = false;
		dgDisp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgDisp.BackgroundColor = Color.White;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		dgDisp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		dgDisp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgDisp.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgDisp.Location = new Point(173, 193);
		dgDisp.Name = "dgDisp";
		dgDisp.ReadOnly = true;
		dgDisp.RowHeadersVisible = false;
		dgDisp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgDisp.Size = new Size(194, 286);
		dgDisp.TabIndex = 9;
		dgFiacao.AllowUserToAddRows = false;
		dgFiacao.AllowUserToDeleteRows = false;
		dgFiacao.AllowUserToResizeRows = false;
		dgFiacao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgFiacao.BackgroundColor = Color.White;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = SystemColors.Control;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		dgFiacao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		dgFiacao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgFiacao.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgFiacao.Location = new Point(373, 12);
		dgFiacao.MultiSelect = false;
		dgFiacao.Name = "dgFiacao";
		dgFiacao.ReadOnly = true;
		dgFiacao.RowHeadersVisible = false;
		dgFiacao.SelectionMode = DataGridViewSelectionMode.CellSelect;
		dgFiacao.Size = new Size(299, 419);
		dgFiacao.TabIndex = 11;
		btPesquisar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisar.FlatStyle = FlatStyle.Flat;
		btPesquisar.ForeColor = SystemColors.Control;
		btPesquisar.Image = Resources.Pesquisar_32;
		btPesquisar.Location = new Point(459, 438);
		btPesquisar.Name = "btPesquisar";
		btPesquisar.Size = new Size(40, 42);
		btPesquisar.TabIndex = 15;
		btPesquisar.UseVisualStyleBackColor = true;
		dgDWG.AllowUserToAddRows = false;
		dgDWG.AllowUserToDeleteRows = false;
		dgDWG.AllowUserToOrderColumns = true;
		dgDWG.AllowUserToResizeRows = false;
		dgDWG.BackgroundColor = Color.White;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle5.BackColor = SystemColors.Control;
		dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
		dgDWG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
		dgDWG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgDWG.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgDWG.Location = new Point(12, 12);
		dgDWG.MultiSelect = false;
		dgDWG.Name = "dgDWG";
		dgDWG.ReadOnly = true;
		dgDWG.RowHeadersVisible = false;
		dgDWG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgDWG.Size = new Size(259, 175);
		dgDWG.TabIndex = 17;
		btExportaDWG.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btExportaDWG.FlatStyle = FlatStyle.Flat;
		btExportaDWG.ForeColor = SystemColors.Control;
		btExportaDWG.Image = (Image)componentResourceManager.GetObject("btExportaDWG.Image");
		btExportaDWG.Location = new Point(545, 437);
		btExportaDWG.Name = "btExportaDWG";
		btExportaDWG.Size = new Size(40, 42);
		btExportaDWG.TabIndex = 40;
		btExportaDWG.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(684, 491);
		Controls.Add(btExportaDWG);
		Controls.Add(dgDWG);
		Controls.Add(btPesquisar);
		Controls.Add(dgFiacao);
		Controls.Add(dgDisp);
		Controls.Add(dgEquip);
		Controls.Add(dgRevisao);
		MaximumSize = new Size(700, 530);
		MinimumSize = new Size(700, 530);
		Name = "frmRelatorio_Fiacao_Compacta";
		ShowIcon = false;
		ShowInTaskbar = false;
		Text = "Estrutura de Réguas de Bornes";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		((ISupportInitialize)dgDisp).EndInit();
		((ISupportInitialize)dgFiacao).EndInit();
		((ISupportInitialize)dgDWG).EndInit();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return SS8OjI2KQ4;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		SS8OjI2KQ4 = WithEventsValue;
	}

	public frmRelatorio_Fiacao_Compacta()
	{
		Resize += FIvOoqJ4NC;
		x3WOL4oRsi = new DeclaracoesFiacao.structurePnRev[1];
		p1aOwCEySu = new DeclaracoesFiacao.structureRevisoes[1];
		xKaOxMtnZR = 0;
		GVqObqdDlI = "";
		qXBOMxrjBR = 0;
		AeBOOeZxYd = "";
		OyaOIIRnI7 = 0;
		KR6O70HBIj = false;
		wOEOqiLPE7 = false;
		AZSOaTxMTQ = false;
		try
		{
			if (!Geral.ExisteForm("frmRelatorio_Fiacao_Compacta"))
			{
				nm5MEPWxUl();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1657]);
				w8dpBZ0kvSD().SetToolTip(btPesquisar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 775]));
				cDadosAccess.carregaDadosDWG();
				Application.ShowModelessDialog((Form)this);
				formataDGDWG();
				formataDGRevisao();
				formataDGEquip();
				formataDGDisp();
				CarregaDGDWG();
				formataDGFiacao();
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

	private void EhPMZRgWeg(object P_0, EventArgs P_1)
	{
		KR6O70HBIj = true;
		dgRevisao.Rows.Clear();
		KR6O70HBIj = false;
		wOEOqiLPE7 = true;
		dgEquip.Rows.Clear();
		wOEOqiLPE7 = false;
		AZSOaTxMTQ = true;
		dgDisp.Rows.Clear();
		AZSOaTxMTQ = false;
		sGqMiic6f4();
	}

	private void sGqMiic6f4()
	{
		xKaOxMtnZR = Conversions.ToInteger(dgDWG.SelectedRows[0].Cells[0].Value);
		p1aOwCEySu = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			cDadosAccessFiacao2.CarregaRevisoesDwgCorrente(xKaOxMtnZR, ref p1aOwCEySu);
			KR6O70HBIj = true;
			dgRevisao.Rows.Clear();
			KR6O70HBIj = false;
			int num = Information.UBound(p1aOwCEySu);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				dgRevisao.Rows.Add(p1aOwCEySu[i].revisao);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
			cDadosAccessFiacao2.fechaConexao();
		}
		AtualizaDGRevisao();
	}

	private void YqhMS956gM(object P_0, EventArgs P_1)
	{
		wOEOqiLPE7 = true;
		dgEquip.Rows.Clear();
		wOEOqiLPE7 = false;
		AZSOaTxMTQ = true;
		dgDisp.Rows.Clear();
		AZSOaTxMTQ = false;
		if (!KR6O70HBIj)
		{
			EI0M4tJLPx();
		}
	}

	private void EI0M4tJLPx()
	{
		CarregaPnRev();
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (dgRevisao.SelectedRows.Count == 1)
			{
				GVqObqdDlI = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
				wOEOqiLPE7 = true;
				dgEquip.Rows.Clear();
				wOEOqiLPE7 = false;
				int num = Information.UBound(x3WOL4oRsi);
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					if (Operators.CompareString(x3WOL4oRsi[i].revisao, GVqObqdDlI, TextCompare: true) == 0 && cDadosAccessFiacao2.TemReguas(xKaOxMtnZR, GVqObqdDlI, x3WOL4oRsi[i].painel))
					{
						dgEquip.Rows.Add(x3WOL4oRsi[i].painel, Dicionario.BuscaNomeDoPainel(x3WOL4oRsi[i].painel));
					}
				}
			}
			AtualizaDGEquip();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	public void CarregaPnRev()
	{
		x3WOL4oRsi = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (Information.UBound(p1aOwCEySu) > 0)
			{
				int num = Information.UBound(p1aOwCEySu);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessFiacao2.CarregaPnRev(xKaOxMtnZR, p1aOwCEySu[i].revisao, ref x3WOL4oRsi);
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	private void erCMCPQYd8(object P_0, EventArgs P_1)
	{
		AZSOaTxMTQ = true;
		formataDGDisp();
		AZSOaTxMTQ = false;
		if (!wOEOqiLPE7)
		{
			irjMrnDn61();
		}
		AtualizaDGDisp();
	}

	private void xn2MYMqXRc(object P_0, EventArgs P_1)
	{
		AZSOaTxMTQ = true;
		formataDGDisp();
		AZSOaTxMTQ = false;
		if (!wOEOqiLPE7)
		{
			irjMrnDn61();
		}
		AtualizaDGDisp();
	}

	private void irjMrnDn61()
	{
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (dgEquip.SelectedRows.Count != 1)
			{
				return;
			}
			qXBOMxrjBR = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
			DeclaracoesFiacao.structureVF[] mDisp = new DeclaracoesFiacao.structureVF[1];
			cDadosAccessFiacao2.CarregaDispTipoIndexModelo(xKaOxMtnZR, GVqObqdDlI, qXBOMxrjBR, ref mDisp);
			AZSOaTxMTQ = true;
			dgDisp.Rows.Clear();
			AZSOaTxMTQ = false;
			int num = Information.UBound(mDisp);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(mDisp[i].Tipo, "B", TextCompare: true) == 0)
				{
					dgDisp.Rows.Add(mDisp[i].Tag, mDisp[i].Alternativo, mDisp[i].Tipo, mDisp[i].IndexModelo.ToString(), mDisp[i].PosOrdem);
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	private void zYeM9Tt8jT(object P_0, EventArgs P_1)
	{
		if (dgFiacao.RowCount > 0)
		{
			new frmRelatorio_FiacaoDWGCompacta(jEnO8Ocol7, qXBOMxrjBR);
		}
	}

	private void PapMzyOsyE(object P_0, EventArgs P_1)
	{
		CPvOGmqpSF(_0020: false);
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		clsLM.LModFab[] mModFab = null;
		formataDGFiacao();
		jEnO8Ocol7 = new DeclaracoesFiacao.structureRelFiacao[1];
		checked
		{
			try
			{
				DeclaracoesGeral._uscPagina.Quantidade = dgDisp.RowCount - 1;
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num = dgDisp.RowCount - 1;
				for (int i = 0; i <= num; i++)
				{
					DeclaracoesGeral._uscPagina.pbPasso();
					if (!dgDisp.Rows[i].Selected)
					{
						continue;
					}
					string text = Conversions.ToString(dgDisp.Rows[i].Cells[0].Value);
					Conversions.ToString(dgDisp.Rows[i].Cells[1].Value);
					string text2 = Conversions.ToString(dgDisp.Rows[i].Cells[2].Value);
					int indexRegua = Conversions.ToInteger(dgDisp.Rows[i].Cells[3].Value);
					DeclaracoesFiacao.structureFiacao[] mfiacao = new DeclaracoesFiacao.structureFiacao[1];
					mfiacao[0].Lig = new DeclaracoesFiacao.structureLigacao[1];
					DeclaracoesFiacao.structureLink[] mLink = new DeclaracoesFiacao.structureLink[1];
					cDadosAccessFiacao2.CarregaTerminaisRegua(xKaOxMtnZR, GVqObqdDlI, qXBOMxrjBR, indexRegua, ref mfiacao, bIncuiPG: true);
					cDadosLM cDadosLM2 = new cDadosLM();
					cDadosLM2.buscaListaDeFabricanteDoMaterial(ref mModFab);
					cDadosLM2.fechaConexao();
					cDadosAccessFiacao2.CarregaLigacoesTerminal(xKaOxMtnZR, GVqObqdDlI, qXBOMxrjBR, text, text2, ref mfiacao, ref mLink);
					int num2 = Information.UBound(jEnO8Ocol7);
					dgFiacao.Rows.Add(text);
					jEnO8Ocol7[num2].Tag = text;
					dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[0].Style.Font = new Font("Arial", 10f, FontStyle.Bold);
					int num3 = dgFiacao.ColumnCount - 1;
					for (int j = 0; j <= num3; j++)
					{
						dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[j].Style.BackColor = Color.LightGray;
					}
					int num4 = Information.UBound(mfiacao);
					for (int k = 1; k <= num4; k++)
					{
						DeclaracoesFiacao.structureLigacao[] lig = mfiacao[k].Lig;
						ref DeclaracoesFiacao.structureRelFiacao[] reference = ref jEnO8Ocol7;
						reference = (DeclaracoesFiacao.structureRelFiacao[])Utils.CopyArray(reference, new DeclaracoesFiacao.structureRelFiacao[Information.UBound(jEnO8Ocol7) + 1 + 1]);
						num2 = Information.UBound(jEnO8Ocol7);
						jEnO8Ocol7[num2].sLM = clsLM.BuscaModeloLM(mModFab, mfiacao[k].LM);
						if (Information.UBound(lig) != 0)
						{
							char c = '\0';
							DataGridViewContentAlignment dataGridViewContentAlignment = DataGridViewContentAlignment.NotSet;
							if (Operators.CompareString(text2, "B", TextCompare: true) == 0)
							{
								string value = Conversions.ToString(c);
								e1QOTvvlQD(ref value, ref dataGridViewContentAlignment, mfiacao[k].Terminal, ref mLink);
								c = Conversions.ToChar(value);
							}
							string text3 = PRtOW8whtG(mfiacao[k].NRegua, mfiacao[k].Terminal);
							dgFiacao.Rows.Add(text3, c, clsLM.BuscaModeloLM(mModFab, mfiacao[k].LM), mfiacao[k].Pagina);
							NLAOpTrBa8(dataGridViewContentAlignment);
							if (Operators.CompareString(text2, "B", TextCompare: true) == 0)
							{
								string jumper = KfOOhaFOac(mfiacao[k].Terminal, ref mLink);
								jEnO8Ocol7[num2].TipoBorne = mfiacao[k].TipoBorne;
								jEnO8Ocol7[num2].Jumper = jumper;
							}
							jEnO8Ocol7[num2].Terminal = mfiacao[k].Terminal;
							jEnO8Ocol7[num2].Pagina12 = mfiacao[k].Pagina;
							jEnO8Ocol7[num2].numLigacoes = 1;
						}
						else if (Operators.CompareString(text2, "B", TextCompare: true) == 0)
						{
							string text4 = "";
							DataGridViewContentAlignment dataGridViewContentAlignment2 = DataGridViewContentAlignment.NotSet;
							e1QOTvvlQD(ref text4, ref dataGridViewContentAlignment2, mfiacao[k].Terminal, ref mLink);
							if (Operators.CompareString(text4, "", TextCompare: true) == 0)
							{
								dgFiacao.Rows.Add(mfiacao[k].Terminal, text4, clsLM.BuscaModeloLM(mModFab, mfiacao[k].LM), mfiacao[k].Pagina);
							}
							if (Operators.CompareString(text4, "", TextCompare: true) != 0)
							{
								dgFiacao.Rows.Add(mfiacao[k].Terminal, text4, clsLM.BuscaModeloLM(mModFab, mfiacao[k].LM), mfiacao[k].Pagina);
								NLAOpTrBa8(dataGridViewContentAlignment2);
							}
							string jumper2 = KfOOhaFOac(mfiacao[k].Terminal, ref mLink);
							jEnO8Ocol7[num2].Terminal = mfiacao[k].Terminal;
							jEnO8Ocol7[num2].TipoBorne = mfiacao[k].TipoBorne;
							jEnO8Ocol7[num2].Jumper = jumper2;
							jEnO8Ocol7[num2].Pagina12 = mfiacao[k].Pagina;
							jEnO8Ocol7[num2].numLigacoes = 0;
						}
					}
					dgFiacao.Rows.Add("");
					AtualizaDGFiacao();
				}
				DeclaracoesGeral._uscPagina.pbFim();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				cDadosAccessFiacao2.fechaConexao();
			}
			CPvOGmqpSF(_0020: true);
		}
	}

	private string PRtOW8whtG(string P_0, string P_1)
	{
		if (Information.IsNothing(P_0))
		{
			P_0 = "";
		}
		string text = "";
		text = ((Operators.CompareString(P_0.Trim(), "", TextCompare: true) == 0) ? P_1 : (P_0 + ":" + P_1));
		return text.Trim();
	}

	private void NLAOpTrBa8(DataGridViewContentAlignment P_0)
	{
		checked
		{
			dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[1].Style.Font = new Font("Arial", 12f, FontStyle.Bold);
			dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[1].Style.Alignment = P_0;
		}
	}

	private void e1QOTvvlQD(ref string P_0, ref DataGridViewContentAlignment P_1, string P_2, ref DeclaracoesFiacao.structureLink[] P_3)
	{
		string left = KfOOhaFOac(P_2, ref P_3);
		if (Operators.CompareString(left, "U", TextCompare: true) != 0)
		{
			if (Operators.CompareString(left, "D", TextCompare: true) != 0)
			{
				if (Operators.CompareString(left, "UD", TextCompare: true) == 0)
				{
					P_0 = "║";
					P_1 = DataGridViewContentAlignment.MiddleCenter;
				}
			}
			else
			{
				P_0 = "╗";
				P_1 = DataGridViewContentAlignment.BottomCenter;
			}
		}
		else
		{
			P_0 = "╝";
			P_1 = DataGridViewContentAlignment.TopCenter;
		}
	}

	private void pKLOJIQurm(ref string P_0, ref DataGridViewContentAlignment P_1, string P_2, ref DeclaracoesFiacao.structureLink[] P_3, int P_4)
	{
		string left = KfOOhaFOac(P_2, ref P_3);
		switch (P_4)
		{
		case 1:
			if (Operators.CompareString(left, "U", TextCompare: true) != 0)
			{
				if (Operators.CompareString(left, "D", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left, "UD", TextCompare: true) == 0)
					{
						P_0 = "║";
						P_1 = DataGridViewContentAlignment.MiddleCenter;
					}
				}
				else
				{
					P_0 = "╗";
					P_1 = DataGridViewContentAlignment.BottomCenter;
				}
			}
			else
			{
				P_0 = "║";
				P_1 = DataGridViewContentAlignment.MiddleCenter;
			}
			break;
		case 2:
			if (Operators.CompareString(left, "U", TextCompare: true) != 0)
			{
				if (Operators.CompareString(left, "D", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left, "UD", TextCompare: true) == 0)
					{
						P_0 = "║";
						P_1 = DataGridViewContentAlignment.MiddleCenter;
					}
				}
				else
				{
					P_0 = "║";
					P_1 = DataGridViewContentAlignment.MiddleCenter;
				}
			}
			else
			{
				P_0 = "╝";
				P_1 = DataGridViewContentAlignment.TopCenter;
			}
			break;
		}
	}

	private string KfOOhaFOac(string P_0, ref DeclaracoesFiacao.structureLink[] P_1)
	{
		string text = "";
		bool flag = false;
		bool flag2 = false;
		int num = Information.UBound(P_1);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(P_1[i].borne, P_0, TextCompare: true) == 0)
			{
				flag = P_1[i].bUp;
				flag2 = P_1[i].bDown;
				break;
			}
		}
		if (flag)
		{
			text += "U";
		}
		if (flag2)
		{
			text += "D";
		}
		return text;
	}

	public void formataDGDWG()
	{
		try
		{
			dgDWG.Rows.Clear();
			dgDWG.Columns.Clear();
			dgDWG.Columns.Add("", "DWG");
			dgDWG.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 786]));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public void CarregaDGDWG()
	{
		DeclaracoesGeral.arqLogico[] mDWG = new DeclaracoesGeral.arqLogico[1];
		cDadosAccess.carregaDadosTodosDWG(ref mDWG);
		checked
		{
			try
			{
				int num = Information.UBound(mDWG);
				for (int i = 1; i <= num; i++)
				{
					dgDWG.Rows.Add(mDWG[i].Indice, mDWG[i].Nome);
					if (DeclaracoesGeral.arqAtivo.Indice == mDWG[i].Indice)
					{
						dgDWG.Rows[dgDWG.Rows.Count - 1].Selected = true;
					}
				}
				AtualizaDGDWG();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void AtualizaDGDWG()
	{
		checked
		{
			try
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgDWG)) ? ((double)(dgDWG.Width - 4)) : ((double)(dgDWG.Width - 21)));
				dgDWG.Columns[0].Width = (int)Math.Round(num / 5.0);
				dgDWG.Columns[1].Width = (int)Math.Round(num * 4.0 / 5.0);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void formataDGRevisao()
	{
		try
		{
			dgRevisao.Rows.Clear();
			dgRevisao.Columns.Clear();
			dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 752]));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		AtualizaDGRevisao();
	}

	public void AtualizaDGRevisao()
	{
		checked
		{
			try
			{
				float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgRevisao)) ? ((float)(dgRevisao.Width - 4)) : ((float)(dgRevisao.Width - 21)));
				dgRevisao.Columns[0].Width = (int)Math.Round(num);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void formataDGEquip()
	{
		checked
		{
			try
			{
				wOEOqiLPE7 = true;
				dgEquip.Rows.Clear();
				dgEquip.Columns.Clear();
				dgEquip.Columns.Add("", "Indice");
				dgEquip.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 748]));
				int num = dgEquip.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgEquip.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				float num2 = dgEquip.Width - 22;
				dgEquip.Columns[0].Width = 0;
				dgEquip.Columns[0].Visible = false;
				dgEquip.Columns[1].Width = (int)Math.Round(num2);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
				wOEOqiLPE7 = false;
			}
			AtualizaDGEquip();
		}
	}

	public void AtualizaDGEquip()
	{
		checked
		{
			try
			{
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgEquip)) ? ((double)(dgEquip.Width - 4)) : ((double)(dgEquip.Width - 21)));
				dgEquip.Columns[0].Width = 0;
				dgEquip.Columns[0].Visible = false;
				dgEquip.Columns[1].Width = (int)Math.Round(a);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
				wOEOqiLPE7 = false;
			}
		}
	}

	public void formataDGDisp()
	{
		checked
		{
			try
			{
				AZSOaTxMTQ = true;
				dgDisp.Rows.Clear();
				dgDisp.Columns.Clear();
				dgDisp.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 788]));
				dgDisp.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 785]));
				dgDisp.Columns.Add("", "");
				dgDisp.Columns.Add("", "");
				dgDisp.Columns.Add("", "");
				int num = dgDisp.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgDisp.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
				AZSOaTxMTQ = false;
			}
			AtualizaDGDisp();
		}
	}

	public void AtualizaDGDisp()
	{
		checked
		{
			try
			{
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgDisp)) ? ((double)(dgDisp.Width - 4)) : ((double)(dgDisp.Width - 21)));
				dgDisp.Columns[0].Width = (int)Math.Round(a);
				dgDisp.Columns[1].Width = 0;
				dgDisp.Columns[1].Visible = false;
				dgDisp.Columns[2].Width = 0;
				dgDisp.Columns[2].Visible = false;
				dgDisp.Columns[3].Width = 0;
				dgDisp.Columns[3].Visible = false;
				dgDisp.Columns[4].Width = 0;
				dgDisp.Columns[4].Visible = false;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
				AZSOaTxMTQ = false;
			}
		}
	}

	public void formataDGFiacao()
	{
		try
		{
			dgFiacao.Rows.Clear();
			dgFiacao.Columns.Clear();
			dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 776]));
			dgFiacao.Columns.Add("", "");
			dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 262]));
			dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 783]));
			AtualizaDGFiacao();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public void AtualizaDGFiacao()
	{
		checked
		{
			try
			{
				if (dgFiacao.RowCount != 0)
				{
					double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgFiacao)) ? ((double)(dgFiacao.Width - 4)) : ((double)(dgFiacao.Width - 21)));
					num -= 22.0;
					int num2 = dgFiacao.Columns.Count - 1;
					for (int i = 0; i <= num2; i++)
					{
						dgFiacao.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
					}
					dgFiacao.Columns[0].Width = (int)Math.Round(num * 0.2);
					dgFiacao.Columns[1].Width = 22;
					dgFiacao.Columns[2].Width = (int)Math.Round(num * 0.4);
					dgFiacao.Columns[3].Width = (int)Math.Round(num * 0.4);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	private void FIvOoqJ4NC(object P_0, EventArgs P_1)
	{
		AtualizaDGFiacao();
	}

	private void CPvOGmqpSF(bool P_0)
	{
		btPesquisar.Enabled = P_0;
		btExportaDWG.Enabled = P_0;
		dgDisp.Enabled = P_0;
		dgDWG.Enabled = P_0;
		dgEquip.Enabled = P_0;
		dgRevisao.Enabled = P_0;
	}
}
