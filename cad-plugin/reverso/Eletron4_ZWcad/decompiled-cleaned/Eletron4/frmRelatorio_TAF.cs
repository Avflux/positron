using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmRelatorio_TAF : Form
{
	private IContainer r9IbesO9xE;

	[CompilerGenerated]
	[AccessedThroughProperty("dgRevisao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView xM3b2AYJmN;

	[AccessedThroughProperty("dgEquip")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView XHCb3vRxi3;

	[AccessedThroughProperty("dgRegua")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView xGnbn69sIl;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgFiacao")]
	private DataGridView iXcb1iFgW0;

	[AccessedThroughProperty("btPesquisar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button hKvblVlYMu;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExportaEXCEL")]
	[CompilerGenerated]
	private Button ig3b5XoL0Y;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolTip Yy3b0sPcTp;

	[AccessedThroughProperty("btPositivoInt")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button HD4bRQlEH4;

	private DeclaracoesFiacao.structurePnRev[] bWpbm39IrE;

	private DeclaracoesFiacao.structureRevisoes[] oWsbXsqA9x;

	private string hnfbUVqThe;

	private int Lh0by2LTWD;

	private string AiBbgFXUxd;

	private int Ig8bAjCkf1;

	private bool edhbsP5odt;

	private bool vRqbBLvIfk;

	private bool NvPbVPx9Ps;

	private DeclaracoesEntidades.StructureBorne[] Vh1buAi0Rl;

	private List<string> pJWbEbQVRx;

	private List<string> QFdbZa8mPm;

	private List<string> ib1biYK7t8;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return xM3b2AYJmN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Y8xbIlXcyt;
			DataGridView dataGridView = xM3b2AYJmN;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			xM3b2AYJmN = value;
			dataGridView = xM3b2AYJmN;
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
			return XHCb3vRxi3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = qIcbqcMXRl;
			DataGridView dataGridView = XHCb3vRxi3;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			XHCb3vRxi3 = value;
			dataGridView = XHCb3vRxi3;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgRegua
	{
		[CompilerGenerated]
		get
		{
			return xGnbn69sIl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			xGnbn69sIl = value;
		}
	}

	internal virtual DataGridView dgFiacao
	{
		[CompilerGenerated]
		get
		{
			return iXcb1iFgW0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			iXcb1iFgW0 = value;
		}
	}

	internal virtual Button btPesquisar
	{
		[CompilerGenerated]
		get
		{
			return hKvblVlYMu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = dFBbNRfkrw;
			Button button = hKvblVlYMu;
			if (button != null)
			{
				button.Click -= value2;
			}
			hKvblVlYMu = value;
			button = hKvblVlYMu;
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
			return ig3b5XoL0Y;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OkgbQ43XqE;
			Button button = ig3b5XoL0Y;
			if (button != null)
			{
				button.Click -= value2;
			}
			ig3b5XoL0Y = value;
			button = ig3b5XoL0Y;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btPositivoInt
	{
		[CompilerGenerated]
		get
		{
			return HD4bRQlEH4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = WWPb8Xj3kr;
			Button button = HD4bRQlEH4;
			if (button != null)
			{
				button.Click -= value2;
			}
			HD4bRQlEH4 = value;
			button = HD4bRQlEH4;
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
			if (disposing && r9IbesO9xE != null)
			{
				r9IbesO9xE.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void lGpbMjVdNl()
	{
		r9IbesO9xE = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		dgRevisao = new DataGridView();
		dgEquip = new DataGridView();
		dgRegua = new DataGridView();
		dgFiacao = new DataGridView();
		btPesquisar = new Button();
		btExportaEXCEL = new Button();
		FDqpBiUmZij(new ToolTip(r9IbesO9xE));
		btPositivoInt = new Button();
		((ISupportInitialize)dgRevisao).BeginInit();
		((ISupportInitialize)dgEquip).BeginInit();
		((ISupportInitialize)dgRegua).BeginInit();
		((ISupportInitialize)dgFiacao).BeginInit();
		SuspendLayout();
		dgRevisao.AllowUserToAddRows = false;
		dgRevisao.AllowUserToDeleteRows = false;
		dgRevisao.AllowUserToOrderColumns = true;
		dgRevisao.AllowUserToResizeRows = false;
		dgRevisao.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgRevisao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgRevisao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgRevisao.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgRevisao.Location = new Point(12, 12);
		dgRevisao.MultiSelect = false;
		dgRevisao.Name = "dgRevisao";
		dgRevisao.ReadOnly = true;
		dgRevisao.RowHeadersVisible = false;
		dgRevisao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRevisao.Size = new Size(158, 111);
		dgRevisao.TabIndex = 3;
		dgEquip.AllowUserToAddRows = false;
		dgEquip.AllowUserToDeleteRows = false;
		dgEquip.AllowUserToOrderColumns = true;
		dgEquip.AllowUserToResizeRows = false;
		dgEquip.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgEquip.BackgroundColor = Color.White;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dgEquip.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgEquip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgEquip.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgEquip.Location = new Point(12, 132);
		dgEquip.MultiSelect = false;
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(158, 229);
		dgEquip.TabIndex = 8;
		dgRegua.AllowUserToAddRows = false;
		dgRegua.AllowUserToDeleteRows = false;
		dgRegua.AllowUserToOrderColumns = true;
		dgRegua.AllowUserToResizeRows = false;
		dgRegua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgRegua.BackgroundColor = Color.White;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		dgRegua.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		dgRegua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgRegua.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgRegua.Location = new Point(176, 12);
		dgRegua.Name = "dgRegua";
		dgRegua.ReadOnly = true;
		dgRegua.RowHeadersVisible = false;
		dgRegua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRegua.Size = new Size(138, 300);
		dgRegua.TabIndex = 9;
		dgFiacao.AllowUserToAddRows = false;
		dgFiacao.AllowUserToDeleteRows = false;
		dgFiacao.AllowUserToResizeRows = false;
		dgFiacao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgFiacao.BackgroundColor = Color.White;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = SystemColors.Control;
		dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		dgFiacao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		dgFiacao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgFiacao.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgFiacao.Location = new Point(320, 12);
		dgFiacao.MultiSelect = false;
		dgFiacao.Name = "dgFiacao";
		dgFiacao.ReadOnly = true;
		dgFiacao.RowHeadersVisible = false;
		dgFiacao.SelectionMode = DataGridViewSelectionMode.CellSelect;
		dgFiacao.Size = new Size(552, 357);
		dgFiacao.TabIndex = 11;
		btPesquisar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisar.FlatStyle = FlatStyle.Flat;
		btPesquisar.ForeColor = SystemColors.Control;
		btPesquisar.Image = Resources.Pesquisar_32;
		btPesquisar.Location = new Point(225, 318);
		btPesquisar.Name = "btPesquisar";
		btPesquisar.Size = new Size(40, 43);
		btPesquisar.TabIndex = 15;
		btPesquisar.UseVisualStyleBackColor = true;
		btExportaEXCEL.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btExportaEXCEL.FlatStyle = FlatStyle.Flat;
		btExportaEXCEL.ForeColor = SystemColors.Control;
		btExportaEXCEL.Image = Resources.ExportaExcel_20;
		btExportaEXCEL.Location = new Point(271, 317);
		btExportaEXCEL.Name = "btExportaEXCEL";
		btExportaEXCEL.Size = new Size(40, 42);
		btExportaEXCEL.TabIndex = 41;
		btExportaEXCEL.UseVisualStyleBackColor = true;
		btPositivoInt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPositivoInt.FlatStyle = FlatStyle.Flat;
		btPositivoInt.ForeColor = SystemColors.Control;
		btPositivoInt.Image = Resources.Adiciona_32;
		btPositivoInt.Location = new Point(179, 318);
		btPositivoInt.Name = "btPositivoInt";
		btPositivoInt.Size = new Size(40, 43);
		btPositivoInt.TabIndex = 42;
		btPositivoInt.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(884, 381);
		Controls.Add(btPositivoInt);
		Controls.Add(btExportaEXCEL);
		Controls.Add(btPesquisar);
		Controls.Add(dgFiacao);
		Controls.Add(dgRegua);
		Controls.Add(dgEquip);
		Controls.Add(dgRevisao);
		MinimumSize = new Size(900, 420);
		Name = "frmRelatorio_TAF";
		ShowIcon = false;
		ShowInTaskbar = false;
		Text = "Relatório TAF";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		((ISupportInitialize)dgRegua).EndInit();
		((ISupportInitialize)dgFiacao).EndInit();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return Yy3b0sPcTp;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		Yy3b0sPcTp = WithEventsValue;
	}

	public frmRelatorio_TAF()
	{
		Resize += xifbcwvXAD;
		bWpbm39IrE = new DeclaracoesFiacao.structurePnRev[1];
		oWsbXsqA9x = new DeclaracoesFiacao.structureRevisoes[1];
		hnfbUVqThe = "";
		Lh0by2LTWD = 0;
		AiBbgFXUxd = "";
		Ig8bAjCkf1 = 0;
		edhbsP5odt = false;
		vRqbBLvIfk = false;
		NvPbVPx9Ps = false;
		pJWbEbQVRx = new List<string>();
		QFdbZa8mPm = new List<string>();
		ib1biYK7t8 = new List<string>();
		try
		{
			if (Geral.ExisteForm("frmRelatorio_TAF"))
			{
				return;
			}
			bool flag = false;
			if (!XDataGeral.LerXDataConfiguracaoListaDePontos())
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 281]), MsgBoxStyle.Information);
			}
			else if (Operators.CompareString(DeclaracoesGeral.ConfLP.listaDePontos.Trim(), "", TextCompare: true) != 0)
			{
				if (!File.Exists(DeclaracoesGeral.ConfLP.listaDePontos))
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 282]), MsgBoxStyle.Information);
				}
				else if (!Geral.IsFileInUse(DeclaracoesGeral.ConfLP.listaDePontos))
				{
					flag = true;
				}
				else
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1495]), MsgBoxStyle.Information);
				}
			}
			if (flag)
			{
				lGpbMjVdNl();
				cDadosAccess.carregaDadosDWG();
				Text = Conversions.ToString(Operators.AddObject(Operators.AddObject(DeclaracoesGeral.mMensagem[1, 1928], " >> "), DeclaracoesGeral.arqAtivo.Nome));
				w8dpBZ0kvSD().SetToolTip(btPesquisar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1947]));
				w8dpBZ0kvSD().SetToolTip(btExportaEXCEL, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1948]));
				w8dpBZ0kvSD().SetToolTip(btPositivoInt, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1945]));
				Application.ShowModelessDialog((Form)this);
				formataDGRevisao();
				AtualizaDGRevisao();
				formataDGEquip();
				FormataDGRegua();
				AtualizaDGRegua();
				tYmbOyo0bf();
				formataDGFiacao();
				btPesquisar.Enabled = true;
				btExportaEXCEL.Enabled = true;
				dgRegua.MultiSelect = true;
				dgRegua.AllowDrop = false;
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

	private void tYmbOyo0bf()
	{
		oWsbXsqA9x = new DeclaracoesFiacao.structureRevisoes[1];
		try
		{
			cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
			cDadosAccessFiacao2.CarregaRevisoesDwgCorrente(DeclaracoesGeral.arqAtivo.Indice, ref oWsbXsqA9x);
			cDadosAccessFiacao2.fechaConexao();
			edhbsP5odt = true;
			dgRevisao.Rows.Clear();
			edhbsP5odt = false;
			int num = Information.UBound(oWsbXsqA9x);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				dgRevisao.Rows.Add(oWsbXsqA9x[i].revisao);
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
		}
	}

	private void Y8xbIlXcyt(object P_0, EventArgs P_1)
	{
		vRqbBLvIfk = true;
		dgEquip.Rows.Clear();
		vRqbBLvIfk = false;
		NvPbVPx9Ps = true;
		dgRegua.Rows.Clear();
		NvPbVPx9Ps = false;
		if (!edhbsP5odt)
		{
			uDdb7T2R3R();
			AtualizaDGEquip();
		}
	}

	private void uDdb7T2R3R()
	{
		CarregaPnRev();
		try
		{
			if (dgRevisao.SelectedRows.Count != 1)
			{
				return;
			}
			hnfbUVqThe = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
			vRqbBLvIfk = true;
			dgEquip.Rows.Clear();
			vRqbBLvIfk = false;
			int num = Information.UBound(bWpbm39IrE);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(bWpbm39IrE[i].revisao, hnfbUVqThe, TextCompare: true) == 0)
				{
					dgEquip.Rows.Add(bWpbm39IrE[i].painel, Dicionario.BuscaNomeDoPainel(bWpbm39IrE[i].painel));
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
		}
	}

	public void CarregaPnRev()
	{
		bWpbm39IrE = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (Information.UBound(oWsbXsqA9x) > 0)
			{
				int num = Information.UBound(oWsbXsqA9x);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessFiacao2.CarregaPnRev(DeclaracoesGeral.arqAtivo.Indice, oWsbXsqA9x[i].revisao, ref bWpbm39IrE);
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

	private void qIcbqcMXRl(object P_0, EventArgs P_1)
	{
		NvPbVPx9Ps = true;
		FormataDGRegua();
		X10baV0kx5();
		AtualizaDGRegua();
	}

	private void X10baV0kx5()
	{
		try
		{
			if (dgEquip.SelectedRows.Count != 1)
			{
				return;
			}
			Lh0by2LTWD = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
			DeclaracoesFiacao.structureVF[] mDisp = new DeclaracoesFiacao.structureVF[1];
			cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
			cDadosAccessFiacao2.CarregaDispTipoIndexModelo(DeclaracoesGeral.arqAtivo.Indice, hnfbUVqThe, Lh0by2LTWD, ref mDisp);
			cDadosAccessFiacao2.fechaConexao();
			NvPbVPx9Ps = true;
			dgRegua.Rows.Clear();
			NvPbVPx9Ps = false;
			int num = Information.UBound(mDisp);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(mDisp[i].Tipo, "B", TextCompare: true) == 0)
				{
					dgRegua.Rows.Add(mDisp[i].Tag, mDisp[i].Alternativo, mDisp[i].Tipo, mDisp[i].IndexModelo.ToString(), mDisp[i].PosOrdem);
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
		}
	}

	private void WWPb8Xj3kr(object P_0, EventArgs P_1)
	{
		new frmPositivoInterno();
	}

	private void dFBbNRfkrw(object P_0, EventArgs P_1)
	{
		Vh1buAi0Rl = new DeclaracoesEntidades.StructureBorne[1];
		clsBornes.capturaTodosOsBornesDoDesenho(-1, ref Vh1buAi0Rl);
		pJWbEbQVRx = new List<string>();
		QFdbZa8mPm = new List<string>();
		ib1biYK7t8 = new List<string>();
		int num = Information.UBound(Vh1buAi0Rl);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				if (!Vh1buAi0Rl[i].PosInt_Jumper.StartsWith("PI-"))
				{
					if (!Vh1buAi0Rl[i].PosInt_Jumper.StartsWith("JP-"))
					{
						if (Operators.CompareString(Vh1buAi0Rl[i].PosInt_Jumper, "X", TextCompare: true) == 0)
						{
							ib1biYK7t8.Add(Vh1buAi0Rl[i].Handle);
						}
					}
					else
					{
						QFdbZa8mPm.Add(Vh1buAi0Rl[i].Handle);
					}
				}
				else
				{
					pJWbEbQVRx.Add(Vh1buAi0Rl[i].Handle);
				}
			}
			WRlbFJGh3q(_0020: false);
			cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
			formataDGFiacao();
			DeclaracoesFiacao.structurePortasTAF[] mPortas = new DeclaracoesFiacao.structurePortasTAF[1];
			clsDispositivoMascaras.PesquisaTodasPortas(ref mPortas);
			cDadosExcel cDadosExcel2 = new cDadosExcel();
			cDadosExcel2.BuscaEFCDescricao(ref mPortas);
			cDadosExcel2.fechaConexao();
			try
			{
				int num2 = dgRegua.RowCount - 1;
				for (int j = 0; j <= num2; j++)
				{
					if (!dgRegua.Rows[j].Selected)
					{
						continue;
					}
					string text = Conversions.ToString(dgRegua.Rows[j].Cells[0].Value);
					string text2 = Conversions.ToString(dgRegua.Rows[j].Cells[2].Value);
					int indexRegua = Conversions.ToInteger(dgRegua.Rows[j].Cells[3].Value);
					DeclaracoesFiacao.structureFiacaoTAF[] mfiacao = new DeclaracoesFiacao.structureFiacaoTAF[1];
					mfiacao[0].Lig = new DeclaracoesFiacao.structureLigacaoTAF[1];
					cDadosAccessFiacao2.CarregaTerminaisReguaTAF(DeclaracoesGeral.arqAtivo.Indice, hnfbUVqThe, Lh0by2LTWD, indexRegua, ref mfiacao);
					cDadosAccessFiacao2.CarregaLigacoesTerminalTAF(DeclaracoesGeral.arqAtivo.Indice, hnfbUVqThe, Lh0by2LTWD, text, text2, ref mfiacao);
					dgFiacao.Rows.Add(text);
					dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[0].Style.Font = new System.Drawing.Font("Arial", 10f, FontStyle.Bold);
					int num3 = dgFiacao.ColumnCount - 1;
					for (int k = 0; k <= num3; k++)
					{
						dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[k].Style.BackColor = Color.LightGray;
					}
					int num4 = Information.UBound(mfiacao);
					for (int l = 1; l <= num4; l++)
					{
						DeclaracoesFiacao.structureLigacaoTAF[] lig = mfiacao[l].Lig;
						if (Information.UBound(lig) != 0)
						{
							if (Information.UBound(lig) <= 0)
							{
								continue;
							}
							bool flag = false;
							int num5 = Information.UBound(lig);
							for (int m = 1; m <= num5; m++)
							{
								string tag = lig[m].Tag;
								string term = lig[m].Term;
								string handle = lig[m].Handle;
								string text3 = "";
								string text4 = "";
								string text5 = "";
								string text6 = "";
								string text7 = "";
								int num6 = Information.UBound(mPortas);
								for (int n = 1; n <= num6; n++)
								{
									if (Operators.CompareString(mPortas[n].Handle, handle, TextCompare: true) == 0)
									{
										text3 = mPortas[n].ChavePrimaria;
										text4 = mPortas[n].EFC;
										text5 = mPortas[n].Descricao;
										text6 = mPortas[n].TipoSinal;
										text7 = mPortas[n].Funcao;
										break;
									}
								}
								if (Operators.CompareString(text3, "", TextCompare: true) == 0)
								{
									if (!flag)
									{
										if (!pJWbEbQVRx.Contains(mfiacao[l].Handle))
										{
											if (!QFdbZa8mPm.Contains(mfiacao[l].Handle))
											{
												if (!ib1biYK7t8.Contains(mfiacao[l].Handle))
												{
													dgFiacao.Rows.Add(mfiacao[l].Terminal, "", "", "", "", "", "", "", mfiacao[l].Pagina);
												}
											}
											else
											{
												string text8 = "";
												int num7 = Information.UBound(Vh1buAi0Rl);
												for (int num8 = 1; num8 <= num7; num8++)
												{
													if (Operators.CompareString(Vh1buAi0Rl[num8].Handle, mfiacao[l].Handle, TextCompare: true) == 0)
													{
														text8 = Vh1buAi0Rl[num8].PosInt_Jumper;
														break;
													}
												}
												dgFiacao.Rows.Add(mfiacao[l].Terminal, "", "", "", DeclaracoesGeral.mMensagem[1, 1953].ToString().ToUpper(), "", text8, "", mfiacao[l].Pagina);
											}
										}
										else
										{
											string text9 = "";
											int num9 = Information.UBound(Vh1buAi0Rl);
											for (int num10 = 1; num10 <= num9; num10++)
											{
												if (Operators.CompareString(Vh1buAi0Rl[num10].Handle, mfiacao[l].Handle, TextCompare: true) == 0)
												{
													text9 = Vh1buAi0Rl[num10].PosInt_Jumper;
													break;
												}
											}
											dgFiacao.Rows.Add(mfiacao[l].Terminal, "", "", "", DeclaracoesGeral.mMensagem[1, 1942].ToString().ToUpper(), "", text9, "", mfiacao[l].Pagina);
										}
									}
									flag = true;
									continue;
								}
								if (!pJWbEbQVRx.Contains(mfiacao[l].Handle))
								{
									if (!QFdbZa8mPm.Contains(mfiacao[l].Handle))
									{
										if (!ib1biYK7t8.Contains(mfiacao[l].Handle))
										{
											dgFiacao.Rows.Add(mfiacao[l].Terminal, tag, term, text4, text5, text3, text6, text7, mfiacao[l].Pagina);
										}
										continue;
									}
									string text10 = "";
									int num11 = Information.UBound(Vh1buAi0Rl);
									for (int num12 = 1; num12 <= num11; num12++)
									{
										if (Operators.CompareString(Vh1buAi0Rl[num12].Handle, mfiacao[l].Handle, TextCompare: true) == 0)
										{
											text10 = Vh1buAi0Rl[num12].PosInt_Jumper;
											break;
										}
									}
									if (!flag)
									{
										dgFiacao.Rows.Add(mfiacao[l].Terminal, tag, term, text4, text5, text3, text10, text7, mfiacao[l].Pagina);
										flag = true;
									}
									continue;
								}
								string text11 = "";
								int num13 = Information.UBound(Vh1buAi0Rl);
								for (int num14 = 1; num14 <= num13; num14++)
								{
									if (Operators.CompareString(Vh1buAi0Rl[num14].Handle, mfiacao[l].Handle, TextCompare: true) == 0)
									{
										text11 = Vh1buAi0Rl[num14].PosInt_Jumper;
										break;
									}
								}
								if (!flag)
								{
									dgFiacao.Rows.Add(mfiacao[l].Terminal, "", "", "", DeclaracoesGeral.mMensagem[1, 1942].ToString().ToUpper(), "", text11, "", mfiacao[l].Pagina);
									flag = true;
								}
							}
						}
						else
						{
							if (Operators.CompareString(text2, "B", TextCompare: true) != 0)
							{
								continue;
							}
							if (!pJWbEbQVRx.Contains(mfiacao[l].Handle))
							{
								if (!QFdbZa8mPm.Contains(mfiacao[l].Handle))
								{
									if (!ib1biYK7t8.Contains(mfiacao[l].Handle))
									{
										dgFiacao.Rows.Add(mfiacao[l].Terminal, "", "", "", "", "", "", "", mfiacao[l].Pagina);
									}
									continue;
								}
								string text12 = "";
								int num15 = Information.UBound(Vh1buAi0Rl);
								for (int num16 = 1; num16 <= num15; num16++)
								{
									if (Operators.CompareString(Vh1buAi0Rl[num16].Handle, mfiacao[l].Handle, TextCompare: true) == 0)
									{
										text12 = Vh1buAi0Rl[num16].PosInt_Jumper;
										break;
									}
								}
								dgFiacao.Rows.Add(mfiacao[l].Terminal, "", "", "", DeclaracoesGeral.mMensagem[1, 1953].ToString().ToUpper(), "", text12, "", mfiacao[l].Pagina);
								continue;
							}
							string text13 = "";
							int num17 = Information.UBound(Vh1buAi0Rl);
							for (int num18 = 1; num18 <= num17; num18++)
							{
								if (Operators.CompareString(Vh1buAi0Rl[num18].Handle, mfiacao[l].Handle, TextCompare: true) == 0)
								{
									text13 = Vh1buAi0Rl[num18].PosInt_Jumper;
									break;
								}
							}
							dgFiacao.Rows.Add(mfiacao[l].Terminal, "", "", "", DeclaracoesGeral.mMensagem[1, 1942].ToString().ToUpper(), "", text13, "", mfiacao[l].Pagina);
						}
					}
					dgFiacao.Rows.Add("");
				}
				mjYbKUcq3a();
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
			WRlbFJGh3q(_0020: true);
		}
	}

	private void WRlbFJGh3q(bool P_0)
	{
		btPesquisar.Enabled = P_0;
		btExportaEXCEL.Enabled = P_0;
	}

	private void OkgbQ43XqE(object P_0, EventArgs P_1)
	{
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Worksheet oSheet = null;
		checked
		{
			try
			{
				ExcFuncoesExcel.VerificaExcel(ref oExcelNew, ref oSheet, "TAF");
				oExcelNew.Visible = true;
				ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
				((_Worksheet)oSheet).get_Range((object)"A2", (object)"Z10000").EntireRow.Delete(RuntimeHelpers.GetObjectValue(Missing.Value));
				oSheet.Cells.ClearComments();
				int num = 1;
				string text = "";
				text = "A1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"Terminal Strips");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				text = "B1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"Terminal Blocks");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				text = "C1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"Tag");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				text = "D1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"Terminal");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				text = "E1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"Physical Address");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				text = "F1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"Description");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 40;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				text = "G1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"Key");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				text = "H1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"Type");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				text = "I1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"Function");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				text = "J1";
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)"Page");
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
				num = 2;
				int num2 = 0;
				string text2 = "";
				int num3 = (int)(dgFiacao.RowCount - 1L);
				for (int i = 0; i <= num3; i++)
				{
					string text3 = "";
					if (!(!Information.IsNothing(RuntimeHelpers.GetObjectValue(dgFiacao.Rows[i].Cells[0].Value)) & Information.IsNothing(RuntimeHelpers.GetObjectValue(dgFiacao.Rows[i].Cells[1].Value))))
					{
						text = "A" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text2));
						if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(dgFiacao.Rows[i].Cells[0].Value)))
						{
							text3 = dgFiacao.Rows[i].Cells[0].Value.ToString();
						}
						text = "B" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text3));
						text3 = "";
						if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(dgFiacao.Rows[i].Cells[1].Value)))
						{
							text3 = dgFiacao.Rows[i].Cells[1].Value.ToString();
						}
						text = "C" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text3));
						text3 = "";
						if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(dgFiacao.Rows[i].Cells[2].Value)))
						{
							text3 = dgFiacao.Rows[i].Cells[2].Value.ToString();
						}
						text = "D" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text3));
						text3 = "";
						if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(dgFiacao.Rows[i].Cells[3].Value)))
						{
							text3 = dgFiacao.Rows[i].Cells[3].Value.ToString();
						}
						text = "E" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text3));
						text3 = "";
						if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(dgFiacao.Rows[i].Cells[4].Value)))
						{
							text3 = dgFiacao.Rows[i].Cells[4].Value.ToString();
						}
						text = "F" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text3));
						text3 = "";
						if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(dgFiacao.Rows[i].Cells[5].Value)))
						{
							text3 = dgFiacao.Rows[i].Cells[5].Value.ToString();
						}
						text = "G" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text3));
						text3 = "";
						if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(dgFiacao.Rows[i].Cells[6].Value)))
						{
							text3 = dgFiacao.Rows[i].Cells[6].Value.ToString();
						}
						text = "H" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text3));
						text3 = "";
						if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(dgFiacao.Rows[i].Cells[7].Value)))
						{
							text3 = dgFiacao.Rows[i].Cells[7].Value.ToString();
						}
						text = "I" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text3));
						text3 = "";
						if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(dgFiacao.Rows[i].Cells[8].Value)))
						{
							text3 = dgFiacao.Rows[i].Cells[8].Value.ToString();
						}
						text = "J" + Conversions.ToString(num);
						((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + text3));
						num++;
						num2++;
						if (num2 == 20)
						{
							num2 = 0;
							string cell = "A" + Conversions.ToString(num + 21);
							((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
						}
					}
					else
					{
						text2 = dgFiacao.Rows[i].Cells[0].Value.ToString();
					}
				}
				ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
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
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void AtualizaDGRevisao()
	{
		checked
		{
			try
			{
				float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgRevisao)) ? ((float)(dgRevisao.Width - 5)) : ((float)(dgRevisao.Width - 22)));
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
				vRqbBLvIfk = true;
				dgEquip.Rows.Clear();
				dgEquip.Columns.Clear();
				dgEquip.Columns.Add("", "Indice");
				dgEquip.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 748]));
				int num = dgEquip.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgEquip.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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
				vRqbBLvIfk = false;
			}
		}
	}

	public void AtualizaDGEquip()
	{
		checked
		{
			try
			{
				float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgEquip)) ? ((float)(dgEquip.Width - 5)) : ((float)(dgEquip.Width - 22)));
				dgEquip.Columns[0].Width = 0;
				dgEquip.Columns[0].Visible = false;
				dgEquip.Columns[1].Width = (int)Math.Round(num);
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
				vRqbBLvIfk = false;
			}
		}
	}

	public void FormataDGRegua()
	{
		checked
		{
			try
			{
				NvPbVPx9Ps = true;
				dgRegua.Rows.Clear();
				dgRegua.Columns.Clear();
				dgRegua.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 788]));
				dgRegua.Columns.Add("", "");
				dgRegua.Columns.Add("", "");
				dgRegua.Columns.Add("", "");
				dgRegua.Columns.Add("", "");
				int num = dgRegua.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgRegua.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				DataGridViewColumn dataGridViewColumn = dgRegua.Columns[0];
				dgRegua.Sort(dataGridViewColumn, ListSortDirection.Ascending);
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
				NvPbVPx9Ps = false;
			}
		}
	}

	public void AtualizaDGRegua()
	{
		checked
		{
			try
			{
				float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgRegua)) ? ((float)(dgRegua.Width - 5)) : ((float)(dgRegua.Width - 22)));
				dgRegua.Columns[0].Width = (int)Math.Round(num);
				dgRegua.Columns[1].Width = 0;
				dgRegua.Columns[1].Visible = false;
				dgRegua.Columns[2].Width = 0;
				dgRegua.Columns[2].Visible = false;
				dgRegua.Columns[3].Width = 0;
				dgRegua.Columns[3].Visible = false;
				dgRegua.Columns[4].Width = 0;
				dgRegua.Columns[4].Visible = false;
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
				NvPbVPx9Ps = false;
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
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 540]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 770]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 771]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 264]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 96]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 365]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 271]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1244]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 39]));
				int num = dgFiacao.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgFiacao.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				QDEbPKKYsd();
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

	private void QDEbPKKYsd()
	{
		checked
		{
			if (dgFiacao.Columns.Count == 9)
			{
				double num = 0.0;
				float num2 = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgFiacao)) ? ((float)(dgFiacao.Width - 5)) : ((float)(dgFiacao.Width - 22)));
				num2 = (float)((double)num2 + num);
				dgFiacao.Columns[0].Width = (int)Math.Round(num2 * 1f / 14f);
				dgFiacao.Columns[1].Width = (int)Math.Round(num2 * 1f / 14f);
				dgFiacao.Columns[2].Width = (int)Math.Round(num2 * 1f / 14f);
				dgFiacao.Columns[3].Width = (int)Math.Round(num2 * 1f / 14f);
				dgFiacao.Columns[4].Width = (int)Math.Round(num2 * 4f / 14f);
				dgFiacao.Columns[5].Width = (int)Math.Round(num2 * 2f / 14f);
				dgFiacao.Columns[6].Width = (int)Math.Round(num2 * 1f / 14f);
				dgFiacao.Columns[7].Width = (int)Math.Round(num2 * 2f / 14f);
				dgFiacao.Columns[8].Width = (int)Math.Round(num2 * 1f / 14f);
			}
		}
	}

	private void xifbcwvXAD(object P_0, EventArgs P_1)
	{
		mjYbKUcq3a();
	}

	private void mjYbKUcq3a()
	{
		QDEbPKKYsd();
	}
}
