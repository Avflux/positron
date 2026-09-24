using System;
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
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmRelatorio_Diferencial : Form
{
	private IContainer D1vpwEqdjMf;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgRevisao1")]
	private DataGridView IwXpwZTHfVU;

	[AccessedThroughProperty("dgEquip")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView PZ6pwi9Lkf0;

	[AccessedThroughProperty("dgFiacao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView rjfpwSQCMo9;

	[AccessedThroughProperty("btPesquisar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button WI7pw4oWqL9;

	[CompilerGenerated]
	[AccessedThroughProperty("dgDWG")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView Uj0pwCCSbh8;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btExportaEXCEL")]
	private Button Fe9pwYqplJn;

	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolTip vYDpwrH9yEC;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgRevisao2")]
	[CompilerGenerated]
	private DataGridView bVupw9TdPwK;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbExcluir")]
	private CheckBox W1FpwzdEWf6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbAlternativo")]
	private CheckBox zu7pxWSwHIE;

	private DeclaracoesFiacao.structurePnRev[] fNxpxpLUY7u;

	private DeclaracoesFiacao.structureRevisoes[] QBQpxTqckiS;

	private DeclaracoesFiacao.structureRevisoes[] asgpxJL4YM5;

	private int XeDpxhsaEVk;

	private string veMpxoPU0eb;

	private string R4DpxGKJDhV;

	private int uEUpxHft9Oj;

	private bool C16pxk4uYgx;

	private bool hmZpxd0tMh1;

	private bool RompxfnKDnm;

	private DeclaracoesFiacao.structureRelPotencial[] MWLpxDDuEw4;

	private DeclaracoesFiacao.structureRelPotencial[] NwMpxv2Zj0R;

	private bool W6jpx6yY8iU;

	internal virtual DataGridView dgRevisao1
	{
		[CompilerGenerated]
		get
		{
			return IwXpwZTHfVU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Ee4pw06EXPW;
			DataGridView dataGridView = IwXpwZTHfVU;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			IwXpwZTHfVU = value;
			dataGridView = IwXpwZTHfVU;
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
			return PZ6pwi9Lkf0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PZ6pwi9Lkf0 = value;
		}
	}

	internal virtual DataGridView dgFiacao
	{
		[CompilerGenerated]
		get
		{
			return rjfpwSQCMo9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rjfpwSQCMo9 = value;
		}
	}

	internal virtual Button btPesquisar
	{
		[CompilerGenerated]
		get
		{
			return WI7pw4oWqL9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OeXpwUWcdiY;
			Button button = WI7pw4oWqL9;
			if (button != null)
			{
				button.Click -= value2;
			}
			WI7pw4oWqL9 = value;
			button = WI7pw4oWqL9;
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
			return Uj0pwCCSbh8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = wGopwlp2Vvi;
			DataGridView dataGridView = Uj0pwCCSbh8;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			Uj0pwCCSbh8 = value;
			dataGridView = Uj0pwCCSbh8;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual Button btExportaEXCEL
	{
		[CompilerGenerated]
		get
		{
			return Fe9pwYqplJn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Ollpwu0VCBk;
			Button button = Fe9pwYqplJn;
			if (button != null)
			{
				button.Click -= value2;
			}
			Fe9pwYqplJn = value;
			button = Fe9pwYqplJn;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgRevisao2
	{
		[CompilerGenerated]
		get
		{
			return bVupw9TdPwK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = kNepwmGv1wj;
			DataGridView dataGridView = bVupw9TdPwK;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			bVupw9TdPwK = value;
			dataGridView = bVupw9TdPwK;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual CheckBox cbExcluir
	{
		[CompilerGenerated]
		get
		{
			return W1FpwzdEWf6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			W1FpwzdEWf6 = value;
		}
	}

	internal virtual CheckBox cbAlternativo
	{
		[CompilerGenerated]
		get
		{
			return zu7pxWSwHIE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = yDxpwy6XWrA;
			CheckBox checkBox = zu7pxWSwHIE;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			zu7pxWSwHIE = value;
			checkBox = zu7pxWSwHIE;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && D1vpwEqdjMf != null)
			{
				D1vpwEqdjMf.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void OpSpw1oy3IT()
	{
		D1vpwEqdjMf = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		dgRevisao1 = new DataGridView();
		dgEquip = new DataGridView();
		dgFiacao = new DataGridView();
		btPesquisar = new Button();
		dgDWG = new DataGridView();
		btExportaEXCEL = new Button();
		FDqpBiUmZij(new ToolTip(D1vpwEqdjMf));
		dgRevisao2 = new DataGridView();
		cbExcluir = new CheckBox();
		cbAlternativo = new CheckBox();
		((ISupportInitialize)dgRevisao1).BeginInit();
		((ISupportInitialize)dgEquip).BeginInit();
		((ISupportInitialize)dgFiacao).BeginInit();
		((ISupportInitialize)dgDWG).BeginInit();
		((ISupportInitialize)dgRevisao2).BeginInit();
		SuspendLayout();
		dgRevisao1.AllowUserToAddRows = false;
		dgRevisao1.AllowUserToDeleteRows = false;
		dgRevisao1.AllowUserToOrderColumns = true;
		dgRevisao1.AllowUserToResizeRows = false;
		dgRevisao1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgRevisao1.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgRevisao1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgRevisao1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgRevisao1.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgRevisao1.Location = new Point(12, 193);
		dgRevisao1.MultiSelect = false;
		dgRevisao1.Name = "dgRevisao1";
		dgRevisao1.ReadOnly = true;
		dgRevisao1.RowHeadersVisible = false;
		dgRevisao1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRevisao1.Size = new Size(90, 142);
		dgRevisao1.TabIndex = 3;
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
		dgEquip.Location = new Point(108, 193);
		dgEquip.MultiSelect = false;
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(163, 242);
		dgEquip.TabIndex = 8;
		dgFiacao.AllowUserToAddRows = false;
		dgFiacao.AllowUserToDeleteRows = false;
		dgFiacao.AllowUserToResizeRows = false;
		dgFiacao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgFiacao.BackgroundColor = Color.White;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		dgFiacao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		dgFiacao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgFiacao.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgFiacao.Location = new Point(277, 12);
		dgFiacao.MultiSelect = false;
		dgFiacao.Name = "dgFiacao";
		dgFiacao.ReadOnly = true;
		dgFiacao.RowHeadersVisible = false;
		dgFiacao.SelectionMode = DataGridViewSelectionMode.CellSelect;
		dgFiacao.Size = new Size(595, 514);
		dgFiacao.TabIndex = 11;
		btPesquisar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisar.FlatStyle = FlatStyle.Flat;
		btPesquisar.ForeColor = SystemColors.Control;
		btPesquisar.Image = Resources.Pesquisar_32;
		btPesquisar.Location = new Point(108, 484);
		btPesquisar.Name = "btPesquisar";
		btPesquisar.Size = new Size(40, 42);
		btPesquisar.TabIndex = 15;
		btPesquisar.UseVisualStyleBackColor = true;
		dgDWG.AllowUserToAddRows = false;
		dgDWG.AllowUserToDeleteRows = false;
		dgDWG.AllowUserToOrderColumns = true;
		dgDWG.AllowUserToResizeRows = false;
		dgDWG.BackgroundColor = Color.White;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = SystemColors.Control;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		dgDWG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
		btExportaEXCEL.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btExportaEXCEL.Enabled = false;
		btExportaEXCEL.FlatStyle = FlatStyle.Flat;
		btExportaEXCEL.ForeColor = SystemColors.Control;
		btExportaEXCEL.Image = Resources.ExportaExcel_20;
		btExportaEXCEL.Location = new Point(229, 484);
		btExportaEXCEL.Name = "btExportaEXCEL";
		btExportaEXCEL.Size = new Size(40, 42);
		btExportaEXCEL.TabIndex = 41;
		btExportaEXCEL.UseVisualStyleBackColor = true;
		dgRevisao2.AllowUserToAddRows = false;
		dgRevisao2.AllowUserToDeleteRows = false;
		dgRevisao2.AllowUserToOrderColumns = true;
		dgRevisao2.AllowUserToResizeRows = false;
		dgRevisao2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		dgRevisao2.BackgroundColor = Color.White;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle5.BackColor = SystemColors.Control;
		dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
		dgRevisao2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
		dgRevisao2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgRevisao2.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgRevisao2.Location = new Point(12, 341);
		dgRevisao2.MultiSelect = false;
		dgRevisao2.Name = "dgRevisao2";
		dgRevisao2.ReadOnly = true;
		dgRevisao2.RowHeadersVisible = false;
		dgRevisao2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRevisao2.Size = new Size(90, 94);
		dgRevisao2.TabIndex = 43;
		cbExcluir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		cbExcluir.AutoSize = true;
		cbExcluir.Location = new Point(12, 441);
		cbExcluir.Name = "cbExcluir";
		cbExcluir.Size = new Size(210, 17);
		cbExcluir.TabIndex = 44;
		cbExcluir.Text = "_Excluir Mudança Layout e Tipo Borne";
		cbExcluir.UseVisualStyleBackColor = true;
		cbAlternativo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		cbAlternativo.AutoSize = true;
		cbAlternativo.Location = new Point(12, 464);
		cbAlternativo.Name = "cbAlternativo";
		cbAlternativo.Size = new Size(113, 17);
		cbAlternativo.TabIndex = 45;
		cbAlternativo.Text = "_Nome Alternativo";
		cbAlternativo.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(884, 538);
		Controls.Add(cbAlternativo);
		Controls.Add(cbExcluir);
		Controls.Add(dgRevisao2);
		Controls.Add(btExportaEXCEL);
		Controls.Add(dgDWG);
		Controls.Add(btPesquisar);
		Controls.Add(dgFiacao);
		Controls.Add(dgEquip);
		Controls.Add(dgRevisao1);
		MinimumSize = new Size(900, 550);
		Name = "frmRelatorio_Diferencial";
		ShowInTaskbar = false;
		Text = "Relatório de Diferencial";
		((ISupportInitialize)dgRevisao1).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		((ISupportInitialize)dgFiacao).EndInit();
		((ISupportInitialize)dgDWG).EndInit();
		((ISupportInitialize)dgRevisao2).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return vYDpwrH9yEC;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		vYDpwrH9yEC = WithEventsValue;
	}

	public frmRelatorio_Diferencial()
	{
		Resize += fl3pwBWKkuK;
		fNxpxpLUY7u = new DeclaracoesFiacao.structurePnRev[1];
		QBQpxTqckiS = new DeclaracoesFiacao.structureRevisoes[1];
		asgpxJL4YM5 = new DeclaracoesFiacao.structureRevisoes[1];
		XeDpxhsaEVk = 0;
		veMpxoPU0eb = "";
		R4DpxGKJDhV = "";
		uEUpxHft9Oj = 0;
		C16pxk4uYgx = false;
		hmZpxd0tMh1 = false;
		RompxfnKDnm = false;
		W6jpx6yY8iU = true;
		try
		{
			if (!Geral.ExisteForm("frmRelatorio_Diferencial"))
			{
				OpSpw1oy3IT();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 821]);
				w8dpBZ0kvSD().SetToolTip(btPesquisar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 775]));
				cbExcluir.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1869]);
				cbAlternativo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1311]);
				cDadosAccess.carregaDadosDWG();
				cbExcluir.Checked = true;
				Application.ShowModelessDialog((Form)this);
				formataDGDWG();
				formataDGRevisao1();
				formataDGRevisao2();
				formataDGEquip();
				formataDGFiacao();
				CarregaDGDWG();
				cbAlternativo.Enabled = false;
				if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
				{
					Left = 0;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void wGopwlp2Vvi(object P_0, EventArgs P_1)
	{
		C16pxk4uYgx = true;
		dgRevisao1.Rows.Clear();
		C16pxk4uYgx = false;
		hmZpxd0tMh1 = true;
		dgRevisao2.Rows.Clear();
		hmZpxd0tMh1 = false;
		RompxfnKDnm = true;
		dgEquip.Rows.Clear();
		RompxfnKDnm = false;
		bkcpw5DNVOs();
	}

	private void bkcpw5DNVOs()
	{
		XeDpxhsaEVk = Conversions.ToInteger(dgDWG.SelectedRows[0].Cells[0].Value);
		QBQpxTqckiS = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			cDadosAccessFiacao2.CarregaRevisoesDwgCorrente(XeDpxhsaEVk, ref QBQpxTqckiS);
			C16pxk4uYgx = true;
			dgRevisao1.Rows.Clear();
			C16pxk4uYgx = false;
			int num = Information.UBound(QBQpxTqckiS);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				C16pxk4uYgx = true;
				dgRevisao1.Rows.Add(QBQpxTqckiS[i].revisao, QBQpxTqckiS[i].data);
				C16pxk4uYgx = false;
			}
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
	}

	private void Ee4pw06EXPW(object P_0, EventArgs P_1)
	{
		hmZpxd0tMh1 = true;
		dgRevisao2.Rows.Clear();
		hmZpxd0tMh1 = false;
		RompxfnKDnm = true;
		dgEquip.Rows.Clear();
		RompxfnKDnm = false;
		if (!hmZpxd0tMh1)
		{
			nSxpwRu2qES();
		}
	}

	private void nSxpwRu2qES()
	{
		XeDpxhsaEVk = Conversions.ToInteger(dgDWG.SelectedRows[0].Cells[0].Value);
		if (dgRevisao1.SelectedRows.Count == 0)
		{
			return;
		}
		DateTime data = Conversions.ToDate(dgRevisao1.SelectedRows[0].Cells[1].Value);
		asgpxJL4YM5 = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			cDadosAccessFiacao2.CarregaRevisoesAnterioresDwgCorrente(XeDpxhsaEVk, ref asgpxJL4YM5, data);
			hmZpxd0tMh1 = true;
			dgRevisao2.Rows.Clear();
			hmZpxd0tMh1 = false;
			int num = Information.UBound(asgpxJL4YM5);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				dgRevisao2.Rows.Add(asgpxJL4YM5[i].revisao, asgpxJL4YM5[i].data);
			}
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
	}

	private void kNepwmGv1wj(object P_0, EventArgs P_1)
	{
		RompxfnKDnm = true;
		dgEquip.Rows.Clear();
		RompxfnKDnm = false;
		OkkpwX5FGir();
	}

	private void OkkpwX5FGir()
	{
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		List<int> list3 = new List<int>();
		CarregaPnRev();
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		checked
		{
			try
			{
				if (!((dgRevisao1.SelectedRows.Count == 1) & (dgRevisao2.SelectedRows.Count == 1)))
				{
					return;
				}
				veMpxoPU0eb = Conversions.ToString(dgRevisao1.SelectedRows[0].Cells[0].Value);
				R4DpxGKJDhV = Conversions.ToString(dgRevisao2.SelectedRows[0].Cells[0].Value);
				RompxfnKDnm = true;
				dgEquip.Rows.Clear();
				RompxfnKDnm = false;
				int num = Information.UBound(fNxpxpLUY7u);
				for (int i = 1; i <= num; i++)
				{
					if (Operators.CompareString(fNxpxpLUY7u[i].revisao, veMpxoPU0eb, TextCompare: true) == 0)
					{
						list.Add(fNxpxpLUY7u[i].painel);
					}
					if (Operators.CompareString(fNxpxpLUY7u[i].revisao, R4DpxGKJDhV, TextCompare: true) == 0)
					{
						list2.Add(fNxpxpLUY7u[i].painel);
					}
				}
				int num2 = Information.UBound(fNxpxpLUY7u);
				for (int j = 1; j <= num2; j++)
				{
					if ((list.Contains(fNxpxpLUY7u[j].painel) & list2.Contains(fNxpxpLUY7u[j].painel)) && !list3.Contains(fNxpxpLUY7u[j].painel))
					{
						list3.Add(fNxpxpLUY7u[j].painel);
					}
				}
				int num3 = Information.UBound(fNxpxpLUY7u);
				for (int k = 1; k <= num3; k++)
				{
					if (list3.Contains(fNxpxpLUY7u[k].painel))
					{
						dgEquip.Rows.Add(fNxpxpLUY7u[k].painel, Dicionario.BuscaNomeDoPainel(fNxpxpLUY7u[k].painel));
						list3.Remove(fNxpxpLUY7u[k].painel);
					}
				}
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
		}
	}

	public void CarregaPnRev()
	{
		fNxpxpLUY7u = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (Information.UBound(QBQpxTqckiS) > 0)
			{
				int num = Information.UBound(QBQpxTqckiS);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessFiacao2.CarregaPnRev(XeDpxhsaEVk, QBQpxTqckiS[i].revisao, ref fNxpxpLUY7u);
				}
			}
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
	}

	private void OeXpwUWcdiY(object P_0, EventArgs P_1)
	{
		NxVpwgiFvB1();
	}

	private void yDxpwy6XWrA(object P_0, EventArgs P_1)
	{
		if (dgFiacao.RowCount != 0)
		{
			NxVpwgiFvB1();
		}
	}

	private void NxVpwgiFvB1()
	{
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		formataDGFiacao();
		if (dgEquip.SelectedRows.Count == 0)
		{
			return;
		}
		uEUpxHft9Oj = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
		W6jpx6yY8iU = cbExcluir.Checked;
		bool flag = false;
		checked
		{
			try
			{
				DeclaracoesFiacao.structurePotencial[] mPotencial = new DeclaracoesFiacao.structurePotencial[1];
				DeclaracoesFiacao.structurePotencial[] mPotencial2 = new DeclaracoesFiacao.structurePotencial[1];
				cDadosAccessFiacao2.CarregaPotDiferencialPainel(XeDpxhsaEVk, veMpxoPU0eb, uEUpxHft9Oj, ref mPotencial);
				cDadosAccessFiacao2.CarregaPotDiferencialPainel(XeDpxhsaEVk, R4DpxGKJDhV, uEUpxHft9Oj, ref mPotencial2);
				if ((Information.UBound(mPotencial) < 2) & (Information.UBound(mPotencial2) < 2))
				{
					return;
				}
				DeclaracoesFiacao.structureDiferencial[] array = new DeclaracoesFiacao.structureDiferencial[1];
				DeclaracoesFiacao.structureDiferencial[] array2 = new DeclaracoesFiacao.structureDiferencial[1];
				int num = 0;
				int num2 = Information.UBound(mPotencial);
				for (int i = 1; i <= num2; i++)
				{
					int potencial = mPotencial[i].Potencial;
					if (num == potencial)
					{
						string tag = mPotencial[i - 1].Tag;
						string alternativo = mPotencial[i - 1].Alternativo;
						if (Operators.CompareString(alternativo.Trim(), "", TextCompare: true) != 0)
						{
							flag = true;
						}
						string text = "";
						text = ((Operators.CompareString(mPotencial[i - 1].NRegua, "", TextCompare: true) == 0) ? mPotencial[i - 1].Terminal : (mPotencial[i - 1].NRegua + ":" + mPotencial[i - 1].Terminal));
						string tag2 = mPotencial[i].Tag;
						string alternativo2 = mPotencial[i].Alternativo;
						if (Operators.CompareString(alternativo2.Trim(), "", TextCompare: true) != 0)
						{
							flag = true;
						}
						string text2 = "";
						text2 = ((Operators.CompareString(mPotencial[i].NRegua, "", TextCompare: true) == 0) ? mPotencial[i].Terminal : (mPotencial[i].NRegua + ":" + mPotencial[i].Terminal));
						string text3 = mPotencial[i].Secao;
						string cor = mPotencial[i].Cor;
						if ((mPotencial[i - 1].bLink & mPotencial[i].bLink) && mPotencial[i - 1].indexModelo == mPotencial[i].indexModelo && cDadosAccessFiacao2.BornesVizinhos(XeDpxhsaEVk, veMpxoPU0eb, uEUpxHft9Oj, mPotencial[i].indexModelo, mPotencial[i - 1].Terminal, mPotencial[i].Terminal))
						{
							text3 = "JUMPER";
							cor = "";
						}
						string text4 = "";
						string pagina = mPotencial[i - 1].Pagina;
						string pagina2 = mPotencial[i].Pagina;
						text4 = ((Operators.CompareString(pagina, pagina2, TextCompare: true) == 0) ? pagina : (pagina + ";" + pagina2));
						int num3 = Information.UBound(array) + 1;
						array = (DeclaracoesFiacao.structureDiferencial[])Utils.CopyArray(array, new DeclaracoesFiacao.structureDiferencial[num3 + 1]);
						array[num3].Tag1 = tag;
						array[num3].Tag2 = tag2;
						array[num3].Alt1 = alternativo;
						array[num3].Alt2 = alternativo2;
						array[num3].Terminal1 = text;
						array[num3].Terminal2 = text2;
						array[num3].PosicaoNum1 = mPotencial[i - 1].PosicaoNum;
						array[num3].PosicaoNum2 = mPotencial[i].PosicaoNum;
						array[num3].TipoBorne1 = mPotencial[i - 1].TipoBorne;
						array[num3].TipoBorne2 = mPotencial[i].TipoBorne;
						array[num3].Cor = cor;
						array[num3].Pagina = text4;
						array[num3].Secao = xHgpwAhg69V(text3);
					}
					else
					{
						num = potencial;
					}
				}
				int num4 = Information.UBound(mPotencial2);
				for (int j = 1; j <= num4; j++)
				{
					int potencial2 = mPotencial2[j].Potencial;
					if (num == potencial2)
					{
						string tag3 = mPotencial2[j - 1].Tag;
						string alternativo3 = mPotencial2[j - 1].Alternativo;
						if (Operators.CompareString(alternativo3.Trim(), "", TextCompare: true) != 0)
						{
							flag = true;
						}
						string text5 = "";
						text5 = ((Operators.CompareString(mPotencial2[j - 1].NRegua, "", TextCompare: true) == 0) ? mPotencial2[j - 1].Terminal : (mPotencial2[j - 1].NRegua + ":" + mPotencial2[j - 1].Terminal));
						string tag4 = mPotencial2[j].Tag;
						string alternativo4 = mPotencial2[j].Alternativo;
						if (Operators.CompareString(alternativo4.Trim(), "", TextCompare: true) != 0)
						{
							flag = true;
						}
						string text6 = "";
						text6 = ((Operators.CompareString(mPotencial2[j].NRegua, "", TextCompare: true) == 0) ? mPotencial2[j].Terminal : (mPotencial2[j].NRegua + ":" + mPotencial2[j].Terminal));
						string text7 = mPotencial2[j].Secao;
						string cor2 = mPotencial2[j].Cor;
						if ((mPotencial2[j - 1].bLink & mPotencial2[j].bLink) && mPotencial2[j - 1].indexModelo == mPotencial2[j].indexModelo && cDadosAccessFiacao2.BornesVizinhos(XeDpxhsaEVk, R4DpxGKJDhV, uEUpxHft9Oj, mPotencial2[j].indexModelo, mPotencial2[j - 1].Terminal, mPotencial2[j].Terminal))
						{
							text7 = "JUMPER";
							cor2 = "";
						}
						string text8 = "";
						string pagina3 = mPotencial2[j - 1].Pagina;
						string pagina4 = mPotencial2[j].Pagina;
						text8 = ((Operators.CompareString(pagina3, pagina4, TextCompare: true) == 0) ? pagina3 : (pagina3 + ";" + pagina4));
						int num5 = Information.UBound(array2) + 1;
						array2 = (DeclaracoesFiacao.structureDiferencial[])Utils.CopyArray(array2, new DeclaracoesFiacao.structureDiferencial[num5 + 1]);
						array2[num5].Tag1 = tag3;
						array2[num5].Tag2 = tag4;
						array2[num5].Alt1 = alternativo3;
						array2[num5].Alt2 = alternativo4;
						array2[num5].Terminal1 = text5;
						array2[num5].Terminal2 = text6;
						array2[num5].PosicaoNum1 = mPotencial2[j - 1].PosicaoNum;
						array2[num5].PosicaoNum2 = mPotencial2[j].PosicaoNum;
						array2[num5].TipoBorne1 = mPotencial2[j - 1].TipoBorne;
						array2[num5].TipoBorne2 = mPotencial2[j].TipoBorne;
						array2[num5].Cor = cor2;
						array2[num5].Pagina = text8;
						array2[num5].Secao = xHgpwAhg69V(text7);
					}
					else
					{
						num = potencial2;
					}
				}
				MWLpxDDuEw4 = new DeclaracoesFiacao.structureRelPotencial[1];
				int num6 = 1;
				NwMpxv2Zj0R = new DeclaracoesFiacao.structureRelPotencial[1];
				int num7 = 1;
				dgFiacao.Rows.Add(DeclaracoesGeral.mMensagem[1, 822]);
				dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[0].Style.Font = new Font("Arial", 10f, FontStyle.Bold);
				int num8 = dgFiacao.ColumnCount - 1;
				for (int k = 0; k <= num8; k++)
				{
					dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[k].Style.BackColor = Color.LightGray;
				}
				int num9 = Information.UBound(array);
				for (int l = 1; l <= num9; l++)
				{
					bool flag2 = true;
					bool flag3 = false;
					int num10 = Information.UBound(array2);
					for (int m = 1; m <= num10; m++)
					{
						if (!((Operators.CompareString(array[l].Tag1, array2[m].Tag1, TextCompare: true) == 0) & (Operators.CompareString(array[l].Alt1, array2[m].Alt1, TextCompare: true) == 0) & (Operators.CompareString(array[l].Terminal1, array2[m].Terminal1, TextCompare: true) == 0) & (Operators.CompareString(array[l].Tag2, array2[m].Tag2, TextCompare: true) == 0) & (Operators.CompareString(array[l].Alt2, array2[m].Alt2, TextCompare: true) == 0) & (Operators.CompareString(array[l].Terminal2, array2[m].Terminal2, TextCompare: true) == 0)))
						{
							if (!((Operators.CompareString(array[l].Tag1, array2[m].Tag2, TextCompare: true) == 0) & (Operators.CompareString(array[l].Alt1, array2[m].Alt2, TextCompare: true) == 0) & (Operators.CompareString(array[l].Terminal1, array2[m].Terminal2, TextCompare: true) == 0) & (Operators.CompareString(array[l].Tag2, array2[m].Tag1, TextCompare: true) == 0) & (Operators.CompareString(array[l].Alt2, array2[m].Alt1, TextCompare: true) == 0) & (Operators.CompareString(array[l].Terminal2, array2[m].Terminal1, TextCompare: true) == 0)))
							{
								continue;
							}
							if ((Operators.CompareString(array[l].Secao, array2[m].Secao, TextCompare: true) == 0) & (Operators.CompareString(array[l].Cor, array2[m].Cor, TextCompare: true) == 0))
							{
								if (W6jpx6yY8iU)
								{
									flag2 = false;
								}
								else if ((array[l].PosicaoNum1 == array2[m].PosicaoNum2) & (array[l].PosicaoNum2 == array2[m].PosicaoNum1) & (array[l].TipoBorne1 == array2[m].TipoBorne2) & (array[l].TipoBorne2 == array2[m].TipoBorne1))
								{
									flag2 = false;
								}
							}
							if (flag2)
							{
								dgFiacao.Rows.Add(array[l].Tag1, array[l].Alt1, array[l].Terminal1, array[l].Tag2, array[l].Alt2, array[l].Terminal2, array[l].Secao, array[l].Cor, array[l].Pagina);
								ref DeclaracoesFiacao.structureRelPotencial[] mWLpxDDuEw = ref MWLpxDDuEw4;
								mWLpxDDuEw = (DeclaracoesFiacao.structureRelPotencial[])Utils.CopyArray(mWLpxDDuEw, new DeclaracoesFiacao.structureRelPotencial[num6 + 1]);
								MWLpxDDuEw4[num6].tag1 = array[l].Tag1;
								MWLpxDDuEw4[num6].alt1 = array[l].Alt1;
								MWLpxDDuEw4[num6].term1 = array[l].Terminal1;
								MWLpxDDuEw4[num6].tag2 = array[l].Tag2;
								MWLpxDDuEw4[num6].alt2 = array[l].Alt2;
								MWLpxDDuEw4[num6].term2 = array[l].Terminal2;
								MWLpxDDuEw4[num6].secao = array[l].Secao;
								MWLpxDDuEw4[num6].cor = array[l].Cor;
								MWLpxDDuEw4[num6].pagina = array[l].Pagina;
								num6++;
								flag3 = true;
							}
							break;
						}
						if ((Operators.CompareString(array[l].Secao, array2[m].Secao, TextCompare: true) == 0) & (Operators.CompareString(array[l].Cor, array2[m].Cor, TextCompare: true) == 0))
						{
							if (W6jpx6yY8iU)
							{
								flag2 = false;
							}
							else if ((array[l].PosicaoNum1 == array2[m].PosicaoNum1) & (array[l].PosicaoNum2 == array2[m].PosicaoNum2) & (array[l].TipoBorne1 == array2[m].TipoBorne1) & (array[l].TipoBorne2 == array2[m].TipoBorne2))
							{
								flag2 = false;
							}
						}
						if (flag2)
						{
							dgFiacao.Rows.Add(array[l].Tag1, array[l].Alt1, array[l].Terminal1, array[l].Tag2, array[l].Alt2, array[l].Terminal2, array[l].Secao, array[l].Cor, array[l].Pagina);
							ref DeclaracoesFiacao.structureRelPotencial[] mWLpxDDuEw2 = ref MWLpxDDuEw4;
							mWLpxDDuEw2 = (DeclaracoesFiacao.structureRelPotencial[])Utils.CopyArray(mWLpxDDuEw2, new DeclaracoesFiacao.structureRelPotencial[num6 + 1]);
							MWLpxDDuEw4[num6].tag1 = array[l].Tag1;
							MWLpxDDuEw4[num6].alt1 = array[l].Alt1;
							MWLpxDDuEw4[num6].term1 = array[l].Terminal1;
							MWLpxDDuEw4[num6].tag2 = array[l].Tag2;
							MWLpxDDuEw4[num6].alt2 = array[l].Alt2;
							MWLpxDDuEw4[num6].term2 = array[l].Terminal2;
							MWLpxDDuEw4[num6].secao = array[l].Secao;
							MWLpxDDuEw4[num6].cor = array[l].Cor;
							MWLpxDDuEw4[num6].pagina = array[l].Pagina;
							num6++;
							flag3 = true;
						}
						break;
					}
					if (flag2 & !flag3)
					{
						dgFiacao.Rows.Add(array[l].Tag1, array[l].Alt1, array[l].Terminal1, array[l].Tag2, array[l].Alt2, array[l].Terminal2, array[l].Secao, array[l].Cor, array[l].Pagina);
						ref DeclaracoesFiacao.structureRelPotencial[] mWLpxDDuEw3 = ref MWLpxDDuEw4;
						mWLpxDDuEw3 = (DeclaracoesFiacao.structureRelPotencial[])Utils.CopyArray(mWLpxDDuEw3, new DeclaracoesFiacao.structureRelPotencial[num6 + 1]);
						MWLpxDDuEw4[num6].tag1 = array[l].Tag1;
						MWLpxDDuEw4[num6].alt1 = array[l].Alt1;
						MWLpxDDuEw4[num6].term1 = array[l].Terminal1;
						MWLpxDDuEw4[num6].tag2 = array[l].Tag2;
						MWLpxDDuEw4[num6].alt2 = array[l].Alt2;
						MWLpxDDuEw4[num6].term2 = array[l].Terminal2;
						MWLpxDDuEw4[num6].secao = array[l].Secao;
						MWLpxDDuEw4[num6].cor = array[l].Cor;
						MWLpxDDuEw4[num6].pagina = array[l].Pagina;
						num6++;
					}
				}
				dgFiacao.Rows.Add("");
				dgFiacao.Rows.Add(DeclaracoesGeral.mMensagem[1, 823]);
				dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[0].Style.Font = new Font("Arial", 10f, FontStyle.Bold);
				int num11 = dgFiacao.ColumnCount - 1;
				for (int n = 0; n <= num11; n++)
				{
					dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[n].Style.BackColor = Color.LightGray;
				}
				int num12 = Information.UBound(array2);
				for (int num13 = 1; num13 <= num12; num13++)
				{
					bool flag4 = true;
					bool flag5 = false;
					int num14 = Information.UBound(array);
					for (int num15 = 1; num15 <= num14; num15++)
					{
						if (!((Operators.CompareString(array[num15].Tag1, array2[num13].Tag1, TextCompare: true) == 0) & (Operators.CompareString(array[num15].Alt1, array2[num13].Alt1, TextCompare: true) == 0) & (Operators.CompareString(array[num15].Terminal1, array2[num13].Terminal1, TextCompare: true) == 0) & (Operators.CompareString(array[num15].Tag2, array2[num13].Tag2, TextCompare: true) == 0) & (Operators.CompareString(array[num15].Alt2, array2[num13].Alt2, TextCompare: true) == 0) & (Operators.CompareString(array[num15].Terminal2, array2[num13].Terminal2, TextCompare: true) == 0)))
						{
							if (!((Operators.CompareString(array[num15].Tag1, array2[num13].Tag2, TextCompare: true) == 0) & (Operators.CompareString(array[num15].Alt1, array2[num13].Alt2, TextCompare: true) == 0) & (Operators.CompareString(array[num15].Terminal1, array2[num13].Terminal2, TextCompare: true) == 0) & (Operators.CompareString(array[num15].Tag2, array2[num13].Tag1, TextCompare: true) == 0) & (Operators.CompareString(array[num15].Alt2, array2[num13].Alt1, TextCompare: true) == 0) & (Operators.CompareString(array[num15].Terminal2, array2[num13].Terminal1, TextCompare: true) == 0)))
							{
								continue;
							}
							if ((Operators.CompareString(array[num15].Secao, array2[num13].Secao, TextCompare: true) == 0) & (Operators.CompareString(array[num15].Cor, array2[num13].Cor, TextCompare: true) == 0))
							{
								if (W6jpx6yY8iU)
								{
									flag4 = false;
								}
								else if ((array[num15].PosicaoNum1 == array2[num13].PosicaoNum2) & (array[num15].PosicaoNum2 == array2[num13].PosicaoNum1) & (array[num15].TipoBorne1 == array2[num13].TipoBorne2) & (array[num15].TipoBorne2 == array2[num13].TipoBorne1))
								{
									flag4 = false;
								}
							}
							if (flag4)
							{
								dgFiacao.Rows.Add(array2[num13].Tag1, array2[num13].Alt1, array2[num13].Terminal1, array2[num13].Tag2, array2[num13].Alt2, array2[num13].Terminal2, array2[num13].Secao, array2[num13].Cor, array2[num13].Pagina);
								ref DeclaracoesFiacao.structureRelPotencial[] nwMpxv2Zj0R = ref NwMpxv2Zj0R;
								nwMpxv2Zj0R = (DeclaracoesFiacao.structureRelPotencial[])Utils.CopyArray(nwMpxv2Zj0R, new DeclaracoesFiacao.structureRelPotencial[num7 + 1]);
								NwMpxv2Zj0R[num7].tag1 = array2[num13].Tag1;
								NwMpxv2Zj0R[num7].alt1 = array2[num13].Alt1;
								NwMpxv2Zj0R[num7].term1 = array2[num13].Terminal1;
								NwMpxv2Zj0R[num7].tag2 = array2[num13].Tag2;
								NwMpxv2Zj0R[num7].alt2 = array2[num13].Alt2;
								NwMpxv2Zj0R[num7].term2 = array2[num13].Terminal2;
								NwMpxv2Zj0R[num7].secao = array2[num13].Secao;
								NwMpxv2Zj0R[num7].cor = array2[num13].Cor;
								NwMpxv2Zj0R[num7].pagina = array2[num13].Pagina;
								num7++;
								flag5 = true;
							}
							break;
						}
						if ((Operators.CompareString(array[num15].Secao, array2[num13].Secao, TextCompare: true) == 0) & (Operators.CompareString(array[num15].Cor, array2[num13].Cor, TextCompare: true) == 0))
						{
							if (W6jpx6yY8iU)
							{
								flag4 = false;
							}
							else if ((array[num15].PosicaoNum1 == array2[num13].PosicaoNum1) & (array[num15].PosicaoNum2 == array2[num13].PosicaoNum2) & (array[num15].TipoBorne1 == array2[num13].TipoBorne1) & (array[num15].TipoBorne2 == array2[num13].TipoBorne2))
							{
								flag4 = false;
							}
						}
						if (flag4)
						{
							dgFiacao.Rows.Add(array2[num13].Tag1, array2[num13].Alt1, array2[num13].Terminal1, array2[num13].Tag2, array2[num13].Alt2, array2[num13].Terminal2, array2[num13].Secao, array2[num13].Cor, array2[num13].Pagina);
							ref DeclaracoesFiacao.structureRelPotencial[] nwMpxv2Zj0R2 = ref NwMpxv2Zj0R;
							nwMpxv2Zj0R2 = (DeclaracoesFiacao.structureRelPotencial[])Utils.CopyArray(nwMpxv2Zj0R2, new DeclaracoesFiacao.structureRelPotencial[num7 + 1]);
							NwMpxv2Zj0R[num7].tag1 = array2[num13].Tag1;
							NwMpxv2Zj0R[num7].alt1 = array2[num13].Alt1;
							NwMpxv2Zj0R[num7].term1 = array2[num13].Terminal1;
							NwMpxv2Zj0R[num7].tag2 = array2[num13].Tag2;
							NwMpxv2Zj0R[num7].alt2 = array2[num13].Alt2;
							NwMpxv2Zj0R[num7].term2 = array2[num13].Terminal2;
							NwMpxv2Zj0R[num7].secao = array2[num13].Secao;
							NwMpxv2Zj0R[num7].cor = array2[num13].Cor;
							NwMpxv2Zj0R[num7].pagina = array2[num13].Pagina;
							num7++;
							flag5 = true;
						}
						break;
					}
					if (flag4 & !flag5)
					{
						dgFiacao.Rows.Add(array2[num13].Tag1, array2[num13].Alt1, array2[num13].Terminal1, array2[num13].Tag2, array2[num13].Alt2, array2[num13].Terminal2, array2[num13].Secao, array2[num13].Cor, array2[num13].Pagina);
						ref DeclaracoesFiacao.structureRelPotencial[] nwMpxv2Zj0R3 = ref NwMpxv2Zj0R;
						nwMpxv2Zj0R3 = (DeclaracoesFiacao.structureRelPotencial[])Utils.CopyArray(nwMpxv2Zj0R3, new DeclaracoesFiacao.structureRelPotencial[num7 + 1]);
						NwMpxv2Zj0R[num7].tag1 = array2[num13].Tag1;
						NwMpxv2Zj0R[num7].alt1 = array2[num13].Alt1;
						NwMpxv2Zj0R[num7].term1 = array2[num13].Terminal1;
						NwMpxv2Zj0R[num7].tag2 = array2[num13].Tag2;
						NwMpxv2Zj0R[num7].alt2 = array2[num13].Alt2;
						NwMpxv2Zj0R[num7].term2 = array2[num13].Terminal2;
						NwMpxv2Zj0R[num7].secao = array2[num13].Secao;
						NwMpxv2Zj0R[num7].cor = array2[num13].Cor;
						NwMpxv2Zj0R[num7].pagina = array2[num13].Pagina;
						num7++;
					}
				}
				if (!flag)
				{
					cbAlternativo.Checked = false;
				}
				cbAlternativo.Enabled = flag;
				AtualizaDGFiacao(cbAlternativo.Checked);
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
			btExportaEXCEL.Enabled = false;
			if ((Information.UBound(MWLpxDDuEw4) > 0) | (Information.UBound(NwMpxv2Zj0R) > 0))
			{
				btExportaEXCEL.Enabled = true;
			}
		}
	}

	private string xHgpwAhg69V(string P_0)
	{
		checked
		{
			if (Versioned.IsNumeric(P_0))
			{
				string text = P_0;
				if (text.Contains(".") | text.Contains(","))
				{
					while (true)
					{
						string left = Strings.Mid(text, Strings.Len(text), Strings.Len(text));
						if (Operators.CompareString(left, "0", TextCompare: true) != 0)
						{
							break;
						}
						text = Strings.Mid(text, 1, Strings.Len(text) - 1);
						left = Strings.Mid(text, Strings.Len(text), Strings.Len(text));
						if ((Operators.CompareString(left, ".", TextCompare: true) == 0) | (Operators.CompareString(left, ",", TextCompare: true) == 0))
						{
							text = Strings.Mid(text, 1, Strings.Len(text) - 1);
							break;
						}
					}
					P_0 = text;
				}
			}
			return P_0;
		}
	}

	private string b6upwsLS1cr(string P_0, string P_1)
	{
		string text = "";
		text = ((Operators.CompareString(P_0.Trim(), "", TextCompare: true) == 0) ? P_1 : (P_0 + ":" + P_1));
		return text.Trim();
	}

	public void formataDGDWG()
	{
		checked
		{
			try
			{
				dgDWG.Rows.Clear();
				dgDWG.Columns.Clear();
				dgDWG.Columns.Add("", "DWG");
				dgDWG.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 786]));
				float num = dgDWG.Width - 22;
				dgDWG.Columns[0].Width = (int)Math.Round(num / 5f);
				dgDWG.Columns[1].Width = (int)Math.Round(num * 4f / 5f);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
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
				C16pxk4uYgx = true;
				int num = Information.UBound(mDWG);
				for (int i = 1; i <= num; i++)
				{
					dgDWG.Rows.Add(mDWG[i].Indice, mDWG[i].Nome);
					if (DeclaracoesGeral.arqAtivo.Indice == mDWG[i].Indice)
					{
						dgDWG.Rows[dgDWG.Rows.Count - 1].Selected = true;
					}
				}
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
				C16pxk4uYgx = false;
			}
		}
	}

	public void formataDGRevisao1()
	{
		checked
		{
			try
			{
				dgRevisao1.Rows.Clear();
				dgRevisao1.Columns.Clear();
				dgRevisao1.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 752]));
				dgRevisao1.Columns.Add("", "DATA");
				float num = dgRevisao1.Width - 22;
				dgRevisao1.Columns[0].Width = (int)Math.Round(num);
				dgRevisao1.Columns[1].Width = 0;
				dgRevisao1.Columns[1].Visible = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void formataDGRevisao2()
	{
		checked
		{
			try
			{
				dgRevisao2.Rows.Clear();
				dgRevisao2.Columns.Clear();
				dgRevisao2.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 752]));
				dgRevisao2.Columns.Add("", "DATA");
				float num = dgRevisao2.Width - 22;
				dgRevisao2.Columns[0].Width = (int)Math.Round(num);
				dgRevisao2.Columns[1].Width = 0;
				dgRevisao2.Columns[1].Visible = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void formataDGEquip()
	{
		checked
		{
			try
			{
				RompxfnKDnm = true;
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
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				RompxfnKDnm = false;
			}
		}
	}

	public void formataDGFiacao()
	{
		checked
		{
			try
			{
				dgFiacao.Rows.Clear();
				dgFiacao.Columns.Clear();
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 777]));
				dgFiacao.Columns.Add("", Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 629], "1")));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 778]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 779]));
				dgFiacao.Columns.Add("", Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 629], "2")));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 780]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 781]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 782]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 783]));
				int num = dgFiacao.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgFiacao.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void AtualizaDGFiacao(bool bAlternativo)
	{
		checked
		{
			try
			{
				if (dgFiacao.RowCount == 0)
				{
					return;
				}
				float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgFiacao)) ? ((float)(dgFiacao.Width - 5)) : ((float)(dgFiacao.Width - 22)));
				int num2 = 0;
				do
				{
					dgFiacao.Columns[num2].Visible = true;
					dgFiacao.Columns[num2].ReadOnly = false;
					num2++;
				}
				while (num2 <= 8);
				if (bAlternativo)
				{
					if (bAlternativo)
					{
						dgFiacao.Columns[0].Width = (int)Math.Round(num * 2f / 14f);
						dgFiacao.Columns[1].Width = (int)Math.Round((double)num * 1.5 / 14.0);
						dgFiacao.Columns[2].Width = (int)Math.Round((double)num * 1.5 / 14.0);
						dgFiacao.Columns[3].Width = (int)Math.Round(num * 2f / 14f);
						dgFiacao.Columns[4].Width = (int)Math.Round((double)num * 1.5 / 14.0);
						dgFiacao.Columns[5].Width = (int)Math.Round((double)num * 1.5 / 14.0);
						dgFiacao.Columns[6].Width = (int)Math.Round((double)num * 1.5 / 14.0);
						dgFiacao.Columns[7].Width = (int)Math.Round(num / 14f);
						dgFiacao.Columns[8].Width = (int)Math.Round((double)num * 1.5 / 14.0);
					}
				}
				else
				{
					dgFiacao.Columns[1].Visible = false;
					dgFiacao.Columns[4].Visible = false;
					dgFiacao.Columns[0].Width = (int)Math.Round(num * 2f / 12f);
					dgFiacao.Columns[1].Width = 0;
					dgFiacao.Columns[2].Width = (int)Math.Round(num * 2f / 12f);
					dgFiacao.Columns[3].Width = (int)Math.Round(num * 2f / 12f);
					dgFiacao.Columns[4].Width = 0;
					dgFiacao.Columns[5].Width = (int)Math.Round(num * 2f / 12f);
					dgFiacao.Columns[6].Width = (int)Math.Round((double)num * 1.5 / 12.0);
					dgFiacao.Columns[7].Width = (int)Math.Round(num / 12f);
					dgFiacao.Columns[8].Width = (int)Math.Round((double)num * 1.5 / 12.0);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void fl3pwBWKkuK(object P_0, EventArgs P_1)
	{
		CdRpwVXfSRB();
	}

	private void CdRpwVXfSRB()
	{
		AtualizaDGFiacao(cbAlternativo.Checked);
	}

	private void Ollpwu0VCBk(object P_0, EventArgs P_1)
	{
		btExportaEXCEL.Enabled = false;
		MWLpxDDuEw4[0].tag1 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 777]);
		MWLpxDDuEw4[0].term1 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 778]);
		MWLpxDDuEw4[0].tag2 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 779]);
		MWLpxDDuEw4[0].term2 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 780]);
		MWLpxDDuEw4[0].cor = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 782]);
		MWLpxDDuEw4[0].secao = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 781]);
		MWLpxDDuEw4[0].pagina = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 783]);
		MWLpxDDuEw4[0].alt1 = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 629], "1"));
		MWLpxDDuEw4[0].alt2 = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 629], "2"));
		string sPainel = Dicionario.BuscaNomeDoPainel(uEUpxHft9Oj);
		if (dgFiacao.RowCount > 0)
		{
			Relatorios_DiferencialEXCEL.CriaMatrizDeDiferenciaisEXCEL(MWLpxDDuEw4, NwMpxv2Zj0R, sPainel, cbAlternativo.Checked);
		}
		btExportaEXCEL.Enabled = true;
		Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1882]), MsgBoxStyle.Information);
	}
}
