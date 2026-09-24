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

namespace Eletron4;

[DesignerGenerated]
public class frmRelatorio_Jumpers : Form
{
	private IContainer aC1p7Un3tiI;

	[AccessedThroughProperty("dgRevisao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView TvPp7y4sURb;

	[CompilerGenerated]
	[AccessedThroughProperty("dgEquip")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView o3vp7gForCs;

	[AccessedThroughProperty("dgFiacao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView kOJp7AENgFG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btPesquisar")]
	private Button Faxp7sLgbK9;

	[AccessedThroughProperty("dgDWG")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView gBpp7Bbucml;

	[AccessedThroughProperty("btExportaEXCEL")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button tQ4p7VhKDV9;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip MGFp7uOa37s;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExportaDWG")]
	private Button MoMp7EAft7a;

	[AccessedThroughProperty("cbAlternativo")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox Fknp7ZOCJCI;

	private DeclaracoesFiacao.structurePnRev[] iT5p7ixeIvG;

	private DeclaracoesFiacao.structureRevisoes[] KE6p7S9S8QP;

	private int YHgp74KW1kM;

	private string Hqbp7CxHIsM;

	private int asJp7YagZlL;

	private bool HOGp7rKPofi;

	private bool fAup79l4YEV;

	public DeclaracoesFiacao.structureRelPotencial[] mRelPotencial;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return TvPp7y4sURb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MZap7nSkTSi;
			DataGridView dataGridView = TvPp7y4sURb;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			TvPp7y4sURb = value;
			dataGridView = TvPp7y4sURb;
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
			return o3vp7gForCs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			o3vp7gForCs = value;
		}
	}

	internal virtual DataGridView dgFiacao
	{
		[CompilerGenerated]
		get
		{
			return kOJp7AENgFG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			kOJp7AENgFG = value;
		}
	}

	internal virtual Button btPesquisar
	{
		[CompilerGenerated]
		get
		{
			return Faxp7sLgbK9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = oQSp70YfoUO;
			Button button = Faxp7sLgbK9;
			if (button != null)
			{
				button.Click -= value2;
			}
			Faxp7sLgbK9 = value;
			button = Faxp7sLgbK9;
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
			return gBpp7Bbucml;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = YWHp72PZhdJ;
			DataGridView dataGridView = gBpp7Bbucml;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			gBpp7Bbucml = value;
			dataGridView = gBpp7Bbucml;
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
			return tQ4p7VhKDV9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = jufp75HJBml;
			Button button = tQ4p7VhKDV9;
			if (button != null)
			{
				button.Click -= value2;
			}
			tQ4p7VhKDV9 = value;
			button = tQ4p7VhKDV9;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btExportaDWG
	{
		[CompilerGenerated]
		get
		{
			return MoMp7EAft7a;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MvWp7l0qm8r;
			Button button = MoMp7EAft7a;
			if (button != null)
			{
				button.Click -= value2;
			}
			MoMp7EAft7a = value;
			button = MoMp7EAft7a;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox cbAlternativo
	{
		[CompilerGenerated]
		get
		{
			return Fknp7ZOCJCI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Fknp7ZOCJCI = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && aC1p7Un3tiI != null)
			{
				aC1p7Un3tiI.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void TT9p7eTF7cX()
	{
		aC1p7Un3tiI = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmRelatorio_Jumpers));
		dgRevisao = new DataGridView();
		dgEquip = new DataGridView();
		dgFiacao = new DataGridView();
		btPesquisar = new Button();
		dgDWG = new DataGridView();
		btExportaEXCEL = new Button();
		FDqpBiUmZij(new ToolTip(aC1p7Un3tiI));
		btExportaDWG = new Button();
		cbAlternativo = new CheckBox();
		((ISupportInitialize)dgRevisao).BeginInit();
		((ISupportInitialize)dgEquip).BeginInit();
		((ISupportInitialize)dgFiacao).BeginInit();
		((ISupportInitialize)dgDWG).BeginInit();
		SuspendLayout();
		dgRevisao.AllowUserToAddRows = false;
		dgRevisao.AllowUserToDeleteRows = false;
		dgRevisao.AllowUserToOrderColumns = true;
		dgRevisao.AllowUserToResizeRows = false;
		dgRevisao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
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
		dgRevisao.Location = new Point(12, 193);
		dgRevisao.MultiSelect = false;
		dgRevisao.Name = "dgRevisao";
		dgRevisao.ReadOnly = true;
		dgRevisao.RowHeadersVisible = false;
		dgRevisao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRevisao.Size = new Size(90, 249);
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
		dgEquip.Location = new Point(108, 193);
		dgEquip.MultiSelect = false;
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(163, 249);
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
		dgFiacao.Size = new Size(595, 488);
		dgFiacao.TabIndex = 11;
		btPesquisar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisar.FlatStyle = FlatStyle.Flat;
		btPesquisar.ForeColor = SystemColors.Control;
		btPesquisar.Image = Resources.Pesquisar_32;
		btPesquisar.Location = new Point(108, 459);
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
		btExportaEXCEL.FlatStyle = FlatStyle.Flat;
		btExportaEXCEL.ForeColor = SystemColors.Control;
		btExportaEXCEL.Image = Resources.ExportaExcel_20;
		btExportaEXCEL.Location = new Point(231, 458);
		btExportaEXCEL.Name = "btExportaEXCEL";
		btExportaEXCEL.Size = new Size(40, 42);
		btExportaEXCEL.TabIndex = 41;
		btExportaEXCEL.UseVisualStyleBackColor = true;
		btExportaDWG.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btExportaDWG.FlatStyle = FlatStyle.Flat;
		btExportaDWG.ForeColor = SystemColors.Control;
		btExportaDWG.Image = (Image)componentResourceManager.GetObject("btExportaDWG.Image");
		btExportaDWG.Location = new Point(174, 458);
		btExportaDWG.Name = "btExportaDWG";
		btExportaDWG.Size = new Size(40, 42);
		btExportaDWG.TabIndex = 40;
		btExportaDWG.UseVisualStyleBackColor = true;
		cbAlternativo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		cbAlternativo.AutoSize = true;
		cbAlternativo.Location = new Point(12, 472);
		cbAlternativo.Name = "cbAlternativo";
		cbAlternativo.Size = new Size(76, 17);
		cbAlternativo.TabIndex = 42;
		cbAlternativo.Text = "Alternativo";
		cbAlternativo.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(884, 512);
		Controls.Add(cbAlternativo);
		Controls.Add(btExportaEXCEL);
		Controls.Add(btExportaDWG);
		Controls.Add(dgDWG);
		Controls.Add(btPesquisar);
		Controls.Add(dgFiacao);
		Controls.Add(dgEquip);
		Controls.Add(dgRevisao);
		MinimumSize = new Size(900, 550);
		Name = "frmRelatorio_Jumpers";
		ShowInTaskbar = false;
		Text = "Lista de Jumpers";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		((ISupportInitialize)dgFiacao).EndInit();
		((ISupportInitialize)dgDWG).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return MGFp7uOa37s;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		MGFp7uOa37s = WithEventsValue;
	}

	public frmRelatorio_Jumpers()
	{
		Resize += BtIp7mItM6t;
		iT5p7ixeIvG = new DeclaracoesFiacao.structurePnRev[1];
		KE6p7S9S8QP = new DeclaracoesFiacao.structureRevisoes[1];
		YHgp74KW1kM = 0;
		Hqbp7CxHIsM = "";
		asJp7YagZlL = 0;
		HOGp7rKPofi = false;
		fAup79l4YEV = false;
		try
		{
			if (!Geral.ExisteForm("frmRelatorio_Jumpers"))
			{
				TT9p7eTF7cX();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 898]);
				cbAlternativo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 785]);
				w8dpBZ0kvSD().SetToolTip(btPesquisar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1410]));
				cDadosAccess.carregaDadosDWG();
				Application.ShowModelessDialog((Form)this);
				formataDGDWG();
				formataDGRevisao();
				formataDGEquip();
				formataDGFiacao();
				CarregaDGDWG();
				cbAlternativo.Checked = false;
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

	private void YWHp72PZhdJ(object P_0, EventArgs P_1)
	{
		HOGp7rKPofi = true;
		dgRevisao.Rows.Clear();
		HOGp7rKPofi = false;
		fAup79l4YEV = true;
		dgEquip.Rows.Clear();
		fAup79l4YEV = false;
		Sryp73Bj9th();
	}

	private void Sryp73Bj9th()
	{
		YHgp74KW1kM = Conversions.ToInteger(dgDWG.SelectedRows[0].Cells[0].Value);
		KE6p7S9S8QP = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessJumper cDadosAccessJumper2 = new cDadosAccessJumper();
		try
		{
			cDadosAccessJumper2.CarregaRevisoesDwgCorrente(YHgp74KW1kM, ref KE6p7S9S8QP);
			HOGp7rKPofi = true;
			dgRevisao.Rows.Clear();
			HOGp7rKPofi = false;
			int num = Information.UBound(KE6p7S9S8QP);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				dgRevisao.Rows.Add(KE6p7S9S8QP[i].revisao);
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
			cDadosAccessJumper2.fechaConexao();
		}
	}

	private void MZap7nSkTSi(object P_0, EventArgs P_1)
	{
		fAup79l4YEV = true;
		dgEquip.Rows.Clear();
		fAup79l4YEV = false;
		if (!HOGp7rKPofi)
		{
			hyVp71vXLVU();
		}
	}

	private void hyVp71vXLVU()
	{
		CarregaPnRev();
		try
		{
			if (dgRevisao.SelectedRows.Count != 1)
			{
				return;
			}
			Hqbp7CxHIsM = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
			fAup79l4YEV = true;
			dgEquip.Rows.Clear();
			fAup79l4YEV = false;
			int num = Information.UBound(iT5p7ixeIvG);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(iT5p7ixeIvG[i].revisao, Hqbp7CxHIsM, TextCompare: true) == 0)
				{
					dgEquip.Rows.Add(iT5p7ixeIvG[i].painel, Dicionario.BuscaNomeDoPainel(iT5p7ixeIvG[i].painel));
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

	public void CarregaPnRev()
	{
		iT5p7ixeIvG = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessJumper cDadosAccessJumper2 = new cDadosAccessJumper();
		try
		{
			if (Information.UBound(KE6p7S9S8QP) > 0)
			{
				int num = Information.UBound(KE6p7S9S8QP);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessJumper2.CarregaPnRev(YHgp74KW1kM, KE6p7S9S8QP[i].revisao, ref iT5p7ixeIvG);
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
			cDadosAccessJumper2.fechaConexao();
		}
	}

	private void MvWp7l0qm8r(object P_0, EventArgs P_1)
	{
		if (dgFiacao.RowCount > 0)
		{
			new frmRelatorio_JumpersDWG(mRelPotencial, "J", asJp7YagZlL);
		}
	}

	private void jufp75HJBml(object P_0, EventArgs P_1)
	{
		if (dgFiacao.Rows.Count == 0)
		{
			return;
		}
		btExportaEXCEL.Enabled = false;
		mRelPotencial[0].tag1 = DeclaracoesGeral.mMensagem[1, 777].ToString().ToUpper();
		mRelPotencial[0].term1 = DeclaracoesGeral.mMensagem[1, 778].ToString().ToUpper();
		mRelPotencial[0].tag2 = DeclaracoesGeral.mMensagem[1, 779].ToString().ToUpper();
		mRelPotencial[0].term2 = DeclaracoesGeral.mMensagem[1, 780].ToString().ToUpper();
		mRelPotencial[0].cor = DeclaracoesGeral.mMensagem[1, 782].ToString().ToUpper();
		mRelPotencial[0].secao = DeclaracoesGeral.mMensagem[1, 781].ToString().ToUpper();
		mRelPotencial[0].pagina = DeclaracoesGeral.mMensagem[1, 783].ToString().ToUpper();
		int num = Information.UBound(mRelPotencial);
		for (int i = 0; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(mRelPotencial[i].tag1, null, TextCompare: true) == 0)
			{
				mRelPotencial[i].tag1 = "";
			}
			if (Operators.CompareString(mRelPotencial[i].tag2, null, TextCompare: true) == 0)
			{
				mRelPotencial[i].tag2 = "";
			}
			if (Operators.CompareString(mRelPotencial[i].term1, null, TextCompare: true) == 0)
			{
				mRelPotencial[i].term1 = "";
			}
			if (Operators.CompareString(mRelPotencial[i].term2, null, TextCompare: true) == 0)
			{
				mRelPotencial[i].term2 = "";
			}
			if (Operators.CompareString(mRelPotencial[i].cor, null, TextCompare: true) == 0)
			{
				mRelPotencial[i].cor = "";
			}
			if (Operators.CompareString(mRelPotencial[i].pagina, null, TextCompare: true) == 0)
			{
				mRelPotencial[i].pagina = "";
			}
			if (Operators.CompareString(mRelPotencial[i].secao, null, TextCompare: true) == 0)
			{
				mRelPotencial[i].secao = "";
			}
		}
		string sPainel = Dicionario.BuscaNomeDoPainel(asJp7YagZlL);
		if (dgFiacao.RowCount > 0)
		{
			Relatorios_JumpersEXCEL.CriaMatrizDePotenciaisEXCEL(mRelPotencial, sPainel);
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1882]), MsgBoxStyle.Information);
		}
		btExportaEXCEL.Enabled = true;
	}

	private void oQSp70YfoUO(object P_0, EventArgs P_1)
	{
		cDadosAccessJumper cDadosAccessJumper2 = new cDadosAccessJumper();
		formataDGFiacao();
		if (dgEquip.SelectedRows.Count == 0)
		{
			return;
		}
		asJp7YagZlL = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
		int num = 1;
		checked
		{
			try
			{
				DeclaracoesFiacao.structurePotencial[] mPotencial = new DeclaracoesFiacao.structurePotencial[1];
				cDadosAccessJumper2.CarregaPotenciaisPainel2(YHgp74KW1kM, Hqbp7CxHIsM, asJp7YagZlL, ref mPotencial);
				if (Information.UBound(mPotencial) < 2)
				{
					return;
				}
				int num2 = 0;
				bool flag = false;
				int num3 = Information.UBound(mPotencial);
				for (int i = 1; i <= num3; i++)
				{
					int potencial = mPotencial[i].Potencial;
					if (num2 == potencial)
					{
						flag = true;
						string text = "";
						if (cbAlternativo.Checked)
						{
							text = ((Operators.CompareString(mPotencial[i - 1].Alternativo, "", TextCompare: true) != 0) ? mPotencial[i - 1].Alternativo : mPotencial[i - 1].Tag);
						}
						else
						{
							text = mPotencial[i - 1].Tag;
						}
						string text2 = "";
						text2 = ((Operators.CompareString(mPotencial[i - 1].NRegua, "", TextCompare: true) == 0) ? mPotencial[i - 1].Terminal : (mPotencial[i - 1].NRegua + ":" + mPotencial[i - 1].Terminal));
						string text3 = "";
						if (cbAlternativo.Checked)
						{
							text3 = ((Operators.CompareString(mPotencial[i].Alternativo, "", TextCompare: true) != 0) ? mPotencial[i].Alternativo : mPotencial[i].Tag);
						}
						else
						{
							text3 = mPotencial[i].Tag;
						}
						string text4 = "";
						text4 = ((Operators.CompareString(mPotencial[i].NRegua, "", TextCompare: true) == 0) ? mPotencial[i].Terminal : (mPotencial[i].NRegua + ":" + mPotencial[i].Terminal));
						string secao = mPotencial[i].Secao;
						string cor = mPotencial[i].Cor;
						string text5 = "";
						string pagina = mPotencial[i - 1].Pagina;
						string pagina2 = mPotencial[i].Pagina;
						text5 = ((Operators.CompareString(pagina, pagina2, TextCompare: true) == 0) ? pagina : (pagina + "; " + pagina2));
						dgFiacao.Rows.Add(text, text2, text3, text4, secao, cor, text5);
						ref DeclaracoesFiacao.structureRelPotencial[] reference = ref mRelPotencial;
						reference = (DeclaracoesFiacao.structureRelPotencial[])Utils.CopyArray(reference, new DeclaracoesFiacao.structureRelPotencial[num + 1]);
						mRelPotencial[num].tag1 = text;
						mRelPotencial[num].term1 = text2;
						mRelPotencial[num].tag2 = text3;
						mRelPotencial[num].term2 = text4;
						mRelPotencial[num].secao = secao;
						mRelPotencial[num].cor = cor;
						mRelPotencial[num].pagina = text5;
						mRelPotencial[num].potencial = num2;
						num++;
						continue;
					}
					num2 = potencial;
					if (flag)
					{
						dgFiacao.Rows.Add("");
						int num4 = dgFiacao.ColumnCount - 1;
						for (int j = 0; j <= num4; j++)
						{
							dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[j].Style.BackColor = Color.LightGray;
						}
						dgFiacao.Rows[dgFiacao.Rows.Count - 1].Height = (int)Math.Round((double)dgFiacao.Rows[dgFiacao.Rows.Count - 1].Height / 3.0);
					}
					flag = false;
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
				cDadosAccessJumper2.fechaConexao();
			}
		}
	}

	private string ljgp7R8ROQf(string P_0, string P_1)
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
		}
	}

	public void formataDGRevisao()
	{
		checked
		{
			try
			{
				dgRevisao.Rows.Clear();
				dgRevisao.Columns.Clear();
				dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 752]));
				float num = dgRevisao.Width - 22;
				dgRevisao.Columns[0].Width = (int)Math.Round(num);
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
				fAup79l4YEV = true;
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
				fAup79l4YEV = false;
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
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 778]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 779]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 780]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 781]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 782]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 783]));
				int num = dgFiacao.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgFiacao.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				float num2 = dgFiacao.Width - 20;
				dgFiacao.Columns[0].Width = (int)Math.Round(num2 * 2f / 12f);
				dgFiacao.Columns[1].Width = (int)Math.Round(num2 * 2f / 12f);
				dgFiacao.Columns[2].Width = (int)Math.Round(num2 * 2f / 12f);
				dgFiacao.Columns[3].Width = (int)Math.Round(num2 * 2f / 12f);
				dgFiacao.Columns[4].Width = (int)Math.Round((double)num2 * 1.5 / 12.0);
				dgFiacao.Columns[5].Width = (int)Math.Round(num2 / 12f);
				dgFiacao.Columns[6].Width = (int)Math.Round((double)num2 * 1.5 / 12.0);
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

	private void BtIp7mItM6t(object P_0, EventArgs P_1)
	{
		uopp7XepXxj();
	}

	private void uopp7XepXxj()
	{
		checked
		{
			if (dgFiacao.Columns.Count == 7)
			{
				float num = dgFiacao.Width - 20;
				dgFiacao.Columns[0].Width = (int)Math.Round(num * 2f / 12f);
				dgFiacao.Columns[1].Width = (int)Math.Round(num * 2f / 12f);
				dgFiacao.Columns[2].Width = (int)Math.Round(num * 2f / 12f);
				dgFiacao.Columns[3].Width = (int)Math.Round(num * 2f / 12f);
				dgFiacao.Columns[4].Width = (int)Math.Round((double)num * 1.5 / 12.0);
				dgFiacao.Columns[5].Width = (int)Math.Round(num / 12f);
				dgFiacao.Columns[6].Width = (int)Math.Round((double)num * 1.5 / 12.0);
			}
		}
	}
}
