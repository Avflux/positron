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
public class frmRelatorio_Potenciais : Form
{
	private IContainer YsdpQMOf5eK;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgRevisao")]
	private DataGridView OIfpQOdYp8r;

	[AccessedThroughProperty("dgEquip")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView TW7pQIw5Dh5;

	[CompilerGenerated]
	[AccessedThroughProperty("dgFiacao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView uocpQ7Yj0ha;

	[AccessedThroughProperty("btPesquisar")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button bDYpQqWUQDn;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("dgDWG")]
	private DataGridView aSFpQa3BB7q;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExportaDWG")]
	private Button VyTpQ8uFa56;

	[AccessedThroughProperty("btExportaEXCEL")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button urApQNVTtsS;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip IvvpQFEpNO4;

	[AccessedThroughProperty("cbAlternativo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox cw9pQQqoGFr;

	private DeclaracoesFiacao.structurePnRev[] sKVpQPq3e74;

	private DeclaracoesFiacao.structureRevisoes[] ypvpQcQETAq;

	private int OuZpQKuvkp9;

	private string h0epQejDGYs;

	private int IPUpQ23v5JT;

	private bool qILpQ3L2U6V;

	private bool r9xpQnPSD8i;

	public DeclaracoesFiacao.structureRelPotencial[] mRelPotencial;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return OIfpQOdYp8r;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SKfpQvdZRZR;
			DataGridView dataGridView = OIfpQOdYp8r;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			OIfpQOdYp8r = value;
			dataGridView = OIfpQOdYp8r;
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
			return TW7pQIw5Dh5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TW7pQIw5Dh5 = value;
		}
	}

	internal virtual DataGridView dgFiacao
	{
		[CompilerGenerated]
		get
		{
			return uocpQ7Yj0ha;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			uocpQ7Yj0ha = value;
		}
	}

	internal virtual Button btPesquisar
	{
		[CompilerGenerated]
		get
		{
			return bDYpQqWUQDn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = gHqpQLg87A9;
			Button button = bDYpQqWUQDn;
			if (button != null)
			{
				button.Click -= value2;
			}
			bDYpQqWUQDn = value;
			button = bDYpQqWUQDn;
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
			return aSFpQa3BB7q;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = xdFpQfogMlH;
			DataGridView dataGridView = aSFpQa3BB7q;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			aSFpQa3BB7q = value;
			dataGridView = aSFpQa3BB7q;
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
			return VyTpQ8uFa56;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = YRApQtMby5D;
			Button button = VyTpQ8uFa56;
			if (button != null)
			{
				button.Click -= value2;
			}
			VyTpQ8uFa56 = value;
			button = VyTpQ8uFa56;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btExportaEXCEL
	{
		[CompilerGenerated]
		get
		{
			return urApQNVTtsS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AKVpQjHsyFJ;
			Button button = urApQNVTtsS;
			if (button != null)
			{
				button.Click -= value2;
			}
			urApQNVTtsS = value;
			button = urApQNVTtsS;
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
			return cw9pQQqoGFr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			cw9pQQqoGFr = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && YsdpQMOf5eK != null)
			{
				YsdpQMOf5eK.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void zXlpQdMFX2v()
	{
		YsdpQMOf5eK = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmRelatorio_Potenciais));
		dgRevisao = new DataGridView();
		dgEquip = new DataGridView();
		dgFiacao = new DataGridView();
		btPesquisar = new Button();
		dgDWG = new DataGridView();
		btExportaDWG = new Button();
		btExportaEXCEL = new Button();
		FDqpBiUmZij(new ToolTip(YsdpQMOf5eK));
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
		btExportaDWG.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btExportaDWG.FlatStyle = FlatStyle.Flat;
		btExportaDWG.ForeColor = SystemColors.Control;
		btExportaDWG.Image = (Image)componentResourceManager.GetObject("btExportaDWG.Image");
		btExportaDWG.Location = new Point(174, 458);
		btExportaDWG.Name = "btExportaDWG";
		btExportaDWG.Size = new Size(40, 42);
		btExportaDWG.TabIndex = 40;
		btExportaDWG.UseVisualStyleBackColor = true;
		btExportaEXCEL.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btExportaEXCEL.FlatStyle = FlatStyle.Flat;
		btExportaEXCEL.ForeColor = SystemColors.Control;
		btExportaEXCEL.Image = Resources.ExportaExcel_20;
		btExportaEXCEL.Location = new Point(231, 458);
		btExportaEXCEL.Name = "btExportaEXCEL";
		btExportaEXCEL.Size = new Size(40, 42);
		btExportaEXCEL.TabIndex = 41;
		btExportaEXCEL.UseVisualStyleBackColor = true;
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
		Name = "frmRelatorio_Potenciais";
		ShowInTaskbar = false;
		Text = "Relatório de Potenciais";
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
		return IvvpQFEpNO4;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		IvvpQFEpNO4 = WithEventsValue;
	}

	public frmRelatorio_Potenciais()
	{
		Resize += TlcpQxIbfSt;
		sKVpQPq3e74 = new DeclaracoesFiacao.structurePnRev[1];
		ypvpQcQETAq = new DeclaracoesFiacao.structureRevisoes[1];
		OuZpQKuvkp9 = 0;
		h0epQejDGYs = "";
		IPUpQ23v5JT = 0;
		qILpQ3L2U6V = false;
		r9xpQnPSD8i = false;
		try
		{
			if (!Geral.ExisteForm("frmRelatorio_Potenciais"))
			{
				zXlpQdMFX2v();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 820]);
				cbAlternativo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 785]);
				w8dpBZ0kvSD().SetToolTip(btPesquisar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 775]));
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

	private void xdFpQfogMlH(object P_0, EventArgs P_1)
	{
		qILpQ3L2U6V = true;
		dgRevisao.Rows.Clear();
		qILpQ3L2U6V = false;
		r9xpQnPSD8i = true;
		dgEquip.Rows.Clear();
		r9xpQnPSD8i = false;
		mv3pQD4m7SA();
	}

	private void mv3pQD4m7SA()
	{
		OuZpQKuvkp9 = Conversions.ToInteger(dgDWG.SelectedRows[0].Cells[0].Value);
		ypvpQcQETAq = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			cDadosAccessFiacao2.CarregaRevisoesDwgCorrente(OuZpQKuvkp9, ref ypvpQcQETAq);
			qILpQ3L2U6V = true;
			dgRevisao.Rows.Clear();
			qILpQ3L2U6V = false;
			int num = Information.UBound(ypvpQcQETAq);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				dgRevisao.Rows.Add(ypvpQcQETAq[i].revisao);
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

	private void SKfpQvdZRZR(object P_0, EventArgs P_1)
	{
		r9xpQnPSD8i = true;
		dgEquip.Rows.Clear();
		r9xpQnPSD8i = false;
		if (!qILpQ3L2U6V)
		{
			QVopQ6LQIF9();
		}
	}

	private void QVopQ6LQIF9()
	{
		CarregaPnRev();
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (dgRevisao.SelectedRows.Count != 1)
			{
				return;
			}
			h0epQejDGYs = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
			r9xpQnPSD8i = true;
			dgEquip.Rows.Clear();
			r9xpQnPSD8i = false;
			int num = Information.UBound(sKVpQPq3e74);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(sKVpQPq3e74[i].revisao, h0epQejDGYs, TextCompare: true) == 0)
				{
					dgEquip.Rows.Add(sKVpQPq3e74[i].painel, Dicionario.BuscaNomeDoPainel(sKVpQPq3e74[i].painel));
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

	public void CarregaPnRev()
	{
		sKVpQPq3e74 = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (Information.UBound(ypvpQcQETAq) > 0)
			{
				int num = Information.UBound(ypvpQcQETAq);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessFiacao2.CarregaPnRev(OuZpQKuvkp9, ypvpQcQETAq[i].revisao, ref sKVpQPq3e74);
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

	private void YRApQtMby5D(object P_0, EventArgs P_1)
	{
		if (dgFiacao.RowCount > 0)
		{
			new frmRelatorio_PotenciaisDWG(mRelPotencial, "P", IPUpQ23v5JT);
		}
	}

	private void AKVpQjHsyFJ(object P_0, EventArgs P_1)
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
		string sPainel = Dicionario.BuscaNomeDoPainel(IPUpQ23v5JT);
		if (dgFiacao.RowCount > 0)
		{
			Relatorios_PotenciaisEXCEL.CriaMatrizDePotenciaisEXCEL(mRelPotencial, sPainel);
		}
		btExportaEXCEL.Enabled = true;
		Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1882]), MsgBoxStyle.Information);
	}

	private void gHqpQLg87A9(object P_0, EventArgs P_1)
	{
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		formataDGFiacao();
		if (dgEquip.SelectedRows.Count == 0)
		{
			return;
		}
		IPUpQ23v5JT = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
		int num = 1;
		checked
		{
			try
			{
				DeclaracoesFiacao.structurePotencial[] mPotencial = new DeclaracoesFiacao.structurePotencial[1];
				cDadosAccessFiacao2.CarregaPotenciaisPainel2(OuZpQKuvkp9, h0epQejDGYs, IPUpQ23v5JT, ref mPotencial);
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
						string text5 = mPotencial[i].Secao;
						string text6 = mPotencial[i].Cor;
						bool flag2 = false;
						if ((mPotencial[i - 1].bLink & mPotencial[i].bLink) && mPotencial[i - 1].indexModelo == mPotencial[i].indexModelo && cDadosAccessFiacao2.BornesVizinhos(OuZpQKuvkp9, h0epQejDGYs, IPUpQ23v5JT, mPotencial[i].indexModelo, mPotencial[i - 1].Terminal, mPotencial[i].Terminal))
						{
							text5 = "JUMPER";
							text6 = "";
							flag2 = true;
						}
						string text7 = "";
						string pagina = mPotencial[i - 1].Pagina;
						string pagina2 = mPotencial[i].Pagina;
						text7 = ((Operators.CompareString(pagina, pagina2, TextCompare: true) == 0) ? pagina : (pagina + "; " + pagina2));
						dgFiacao.Rows.Add(text, text2, text3, text4, text5, text6, text7);
						ref DeclaracoesFiacao.structureRelPotencial[] reference = ref mRelPotencial;
						reference = (DeclaracoesFiacao.structureRelPotencial[])Utils.CopyArray(reference, new DeclaracoesFiacao.structureRelPotencial[num + 1]);
						mRelPotencial[num].tag1 = text;
						mRelPotencial[num].term1 = text2;
						mRelPotencial[num].tag2 = text3;
						mRelPotencial[num].term2 = text4;
						mRelPotencial[num].secao = text5;
						mRelPotencial[num].cor = text6;
						mRelPotencial[num].pagina = text7;
						mRelPotencial[num].potencial = num2;
						num++;
						if (flag2)
						{
							dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[4].Style.Font = new Font("Arial", 9f, FontStyle.Bold);
							dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[4].Style.ForeColor = Color.DarkRed;
						}
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
				cDadosAccessFiacao2.fechaConexao();
			}
		}
	}

	private string c42pQwp1G3m(string P_0, string P_1)
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
				r9xpQnPSD8i = true;
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
				r9xpQnPSD8i = false;
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

	private void TlcpQxIbfSt(object P_0, EventArgs P_1)
	{
		uKUpQbUBhcm();
	}

	private void uKUpQbUBhcm()
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
