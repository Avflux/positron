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
public class frmRelatorio_Veias : Form
{
	private IContainer i6TpP7ZoBU8;

	[AccessedThroughProperty("dgRevisao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView Bg6pPqWDwGI;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgEquip")]
	[CompilerGenerated]
	private DataGridView AHwpPaexYZb;

	[AccessedThroughProperty("dgVeias")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView JLrpP8V0bo3;

	[AccessedThroughProperty("btPesquisar")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button t8gpPN7E1XF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExportaEXCEL")]
	private Button y1qpPF4dQkZ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip SZPpPQZ8eXG;

	[AccessedThroughProperty("qTotal")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label oRFpPPgHsXE;

	[AccessedThroughProperty("RBSeparPaineis")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton FFBpPcKhTkf;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RBSheetDiferente")]
	private RadioButton sgTpPK4ASpV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CKAgrupar")]
	private CheckBox OcjpPee8uu9;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox jJipP2vWYnk;

	[AccessedThroughProperty("GroupBox2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox OPfpP37slk2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RBFuncaoCabo")]
	[CompilerGenerated]
	private RadioButton xmLpPnRNXVc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RBFuncaoVeia")]
	private RadioButton PJJpP1rFUut;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox3")]
	private GroupBox G5qpPl8t1H4;

	[AccessedThroughProperty("CKBlindagem")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox LUipP5liLwJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBComprimento")]
	[CompilerGenerated]
	private CheckBox OcWpP0Dm6lQ;

	private DeclaracoesFiacao.structurePnRev[] IYTpPR30NJq;

	private DeclaracoesFiacao.structureRevisoes[] KqIpPmjJ7cj;

	private clsVeias.StructureVeias[] BntpPX2HQES;

	private string I5OpPUXXG7v;

	private bool toMpPy9ghj3;

	private bool f8cpPgrtxC2;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return Bg6pPqWDwGI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = lAupPLTGpkL;
			DataGridView dataGridView = Bg6pPqWDwGI;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			Bg6pPqWDwGI = value;
			dataGridView = Bg6pPqWDwGI;
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
			return AHwpPaexYZb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			AHwpPaexYZb = value;
		}
	}

	internal virtual DataGridView dgVeias
	{
		[CompilerGenerated]
		get
		{
			return JLrpP8V0bo3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			JLrpP8V0bo3 = value;
		}
	}

	internal virtual Button btPesquisar
	{
		[CompilerGenerated]
		get
		{
			return t8gpPN7E1XF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = bqipPxovkmF;
			Button button = t8gpPN7E1XF;
			if (button != null)
			{
				button.Click -= value2;
			}
			t8gpPN7E1XF = value;
			button = t8gpPN7E1XF;
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
			return y1qpPF4dQkZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = M0upPbCK5oS;
			Button button = y1qpPF4dQkZ;
			if (button != null)
			{
				button.Click -= value2;
			}
			y1qpPF4dQkZ = value;
			button = y1qpPF4dQkZ;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label qTotal
	{
		[CompilerGenerated]
		get
		{
			return oRFpPPgHsXE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			oRFpPPgHsXE = value;
		}
	}

	internal virtual RadioButton RBSeparPaineis
	{
		[CompilerGenerated]
		get
		{
			return FFBpPcKhTkf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			FFBpPcKhTkf = value;
		}
	}

	internal virtual RadioButton RBSheetDiferente
	{
		[CompilerGenerated]
		get
		{
			return sgTpPK4ASpV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			sgTpPK4ASpV = value;
		}
	}

	internal virtual CheckBox CKAgrupar
	{
		[CompilerGenerated]
		get
		{
			return OcjpPee8uu9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AeipPO1FRvi;
			CheckBox checkBox = OcjpPee8uu9;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			OcjpPee8uu9 = value;
			checkBox = OcjpPee8uu9;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return jJipP2vWYnk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jJipP2vWYnk = value;
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return OPfpP37slk2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			OPfpP37slk2 = value;
		}
	}

	internal virtual RadioButton RBFuncaoCabo
	{
		[CompilerGenerated]
		get
		{
			return xmLpPnRNXVc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = cj2pPIiepbj;
			RadioButton radioButton = xmLpPnRNXVc;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			xmLpPnRNXVc = value;
			radioButton = xmLpPnRNXVc;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton RBFuncaoVeia
	{
		[CompilerGenerated]
		get
		{
			return PJJpP1rFUut;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PJJpP1rFUut = value;
		}
	}

	internal virtual GroupBox GroupBox3
	{
		[CompilerGenerated]
		get
		{
			return G5qpPl8t1H4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			G5qpPl8t1H4 = value;
		}
	}

	internal virtual CheckBox CKBlindagem
	{
		[CompilerGenerated]
		get
		{
			return LUipP5liLwJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LUipP5liLwJ = value;
		}
	}

	internal virtual CheckBox CBComprimento
	{
		[CompilerGenerated]
		get
		{
			return OcWpP0Dm6lQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			OcWpP0Dm6lQ = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && i6TpP7ZoBU8 != null)
			{
				i6TpP7ZoBU8.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ElapPt0SCaB()
	{
		i6TpP7ZoBU8 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		dgRevisao = new DataGridView();
		dgEquip = new DataGridView();
		dgVeias = new DataGridView();
		btPesquisar = new Button();
		btExportaEXCEL = new Button();
		FDqpBiUmZij(new ToolTip(i6TpP7ZoBU8));
		qTotal = new Label();
		RBSeparPaineis = new RadioButton();
		RBSheetDiferente = new RadioButton();
		CKAgrupar = new CheckBox();
		GroupBox1 = new GroupBox();
		GroupBox2 = new GroupBox();
		RBFuncaoCabo = new RadioButton();
		RBFuncaoVeia = new RadioButton();
		GroupBox3 = new GroupBox();
		CBComprimento = new CheckBox();
		CKBlindagem = new CheckBox();
		((ISupportInitialize)dgRevisao).BeginInit();
		((ISupportInitialize)dgEquip).BeginInit();
		((ISupportInitialize)dgVeias).BeginInit();
		GroupBox1.SuspendLayout();
		GroupBox2.SuspendLayout();
		GroupBox3.SuspendLayout();
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
		dgRevisao.Location = new Point(12, 12);
		dgRevisao.MultiSelect = false;
		dgRevisao.Name = "dgRevisao";
		dgRevisao.ReadOnly = true;
		dgRevisao.RowHeadersVisible = false;
		dgRevisao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRevisao.Size = new Size(206, 162);
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
		dgEquip.Location = new Point(12, 180);
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(206, 165);
		dgEquip.TabIndex = 8;
		dgVeias.AllowUserToAddRows = false;
		dgVeias.AllowUserToDeleteRows = false;
		dgVeias.AllowUserToResizeRows = false;
		dgVeias.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgVeias.BackgroundColor = Color.White;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		dgVeias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		dgVeias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgVeias.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgVeias.Location = new Point(224, 12);
		dgVeias.MultiSelect = false;
		dgVeias.Name = "dgVeias";
		dgVeias.ReadOnly = true;
		dgVeias.RowHeadersVisible = false;
		dgVeias.SelectionMode = DataGridViewSelectionMode.CellSelect;
		dgVeias.Size = new Size(648, 586);
		dgVeias.TabIndex = 11;
		btPesquisar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisar.FlatStyle = FlatStyle.Flat;
		btPesquisar.ForeColor = SystemColors.Control;
		btPesquisar.Image = Resources.Pesquisar_32;
		btPesquisar.Location = new Point(12, 556);
		btPesquisar.Name = "btPesquisar";
		btPesquisar.Size = new Size(40, 42);
		btPesquisar.TabIndex = 15;
		btPesquisar.UseVisualStyleBackColor = true;
		btExportaEXCEL.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btExportaEXCEL.FlatStyle = FlatStyle.Flat;
		btExportaEXCEL.ForeColor = SystemColors.Control;
		btExportaEXCEL.Image = Resources.ExportaExcel_20;
		btExportaEXCEL.Location = new Point(81, 556);
		btExportaEXCEL.Name = "btExportaEXCEL";
		btExportaEXCEL.Size = new Size(40, 42);
		btExportaEXCEL.TabIndex = 41;
		btExportaEXCEL.UseVisualStyleBackColor = true;
		qTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		qTotal.BorderStyle = BorderStyle.Fixed3D;
		qTotal.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		qTotal.Location = new Point(174, 576);
		qTotal.Name = "qTotal";
		qTotal.Size = new Size(44, 22);
		qTotal.TabIndex = 182;
		qTotal.Text = "Tot";
		qTotal.TextAlign = ContentAlignment.MiddleCenter;
		RBSeparPaineis.AutoSize = true;
		RBSeparPaineis.Checked = true;
		RBSeparPaineis.Location = new Point(22, 31);
		RBSeparPaineis.Name = "RBSeparPaineis";
		RBSeparPaineis.Size = new Size(102, 17);
		RBSeparPaineis.TabIndex = 186;
		RBSeparPaineis.TabStop = true;
		RBSeparPaineis.Text = "RBSeparPaineis";
		RBSeparPaineis.UseVisualStyleBackColor = true;
		RBSheetDiferente.AutoSize = true;
		RBSheetDiferente.Location = new Point(22, 50);
		RBSheetDiferente.Name = "RBSheetDiferente";
		RBSheetDiferente.Size = new Size(111, 17);
		RBSheetDiferente.TabIndex = 187;
		RBSheetDiferente.Text = "RBSheetDiferente";
		RBSheetDiferente.UseVisualStyleBackColor = true;
		CKAgrupar.AutoSize = true;
		CKAgrupar.Location = new Point(13, 12);
		CKAgrupar.Name = "CKAgrupar";
		CKAgrupar.Size = new Size(77, 17);
		CKAgrupar.TabIndex = 188;
		CKAgrupar.Text = "CKAgrupar";
		CKAgrupar.UseVisualStyleBackColor = true;
		GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox1.Controls.Add(CKAgrupar);
		GroupBox1.Controls.Add(RBSeparPaineis);
		GroupBox1.Controls.Add(RBSheetDiferente);
		GroupBox1.Location = new Point(12, 409);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(206, 75);
		GroupBox1.TabIndex = 189;
		GroupBox1.TabStop = false;
		GroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox2.Controls.Add(RBFuncaoCabo);
		GroupBox2.Controls.Add(RBFuncaoVeia);
		GroupBox2.Location = new Point(12, 486);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(206, 64);
		GroupBox2.TabIndex = 190;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "GB2Mostrar";
		RBFuncaoCabo.AutoSize = true;
		RBFuncaoCabo.Checked = true;
		RBFuncaoCabo.Location = new Point(22, 15);
		RBFuncaoCabo.Name = "RBFuncaoCabo";
		RBFuncaoCabo.Size = new Size(101, 17);
		RBFuncaoCabo.TabIndex = 186;
		RBFuncaoCabo.TabStop = true;
		RBFuncaoCabo.Text = "RBFuncaoCabo";
		RBFuncaoCabo.UseVisualStyleBackColor = true;
		RBFuncaoVeia.AutoSize = true;
		RBFuncaoVeia.Location = new Point(22, 34);
		RBFuncaoVeia.Name = "RBFuncaoVeia";
		RBFuncaoVeia.Size = new Size(97, 17);
		RBFuncaoVeia.TabIndex = 187;
		RBFuncaoVeia.Text = "RBFuncaoVeia";
		RBFuncaoVeia.UseVisualStyleBackColor = true;
		GroupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox3.Controls.Add(CBComprimento);
		GroupBox3.Controls.Add(CKBlindagem);
		GroupBox3.Location = new Point(12, 349);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(206, 60);
		GroupBox3.TabIndex = 213;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "gbMostrar";
		CBComprimento.AutoSize = true;
		CBComprimento.Location = new Point(6, 37);
		CBComprimento.Name = "CBComprimento";
		CBComprimento.Size = new Size(101, 17);
		CBComprimento.TabIndex = 213;
		CBComprimento.Text = "CBComprimento";
		CBComprimento.UseVisualStyleBackColor = true;
		CKBlindagem.AutoSize = true;
		CKBlindagem.Checked = true;
		CKBlindagem.CheckState = CheckState.Checked;
		CKBlindagem.Location = new Point(7, 16);
		CKBlindagem.Name = "CKBlindagem";
		CKBlindagem.Size = new Size(89, 17);
		CKBlindagem.TabIndex = 211;
		CKBlindagem.Text = "CKBlindagem";
		CKBlindagem.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(884, 611);
		Controls.Add(GroupBox3);
		Controls.Add(GroupBox2);
		Controls.Add(GroupBox1);
		Controls.Add(qTotal);
		Controls.Add(btExportaEXCEL);
		Controls.Add(btPesquisar);
		Controls.Add(dgVeias);
		Controls.Add(dgEquip);
		Controls.Add(dgRevisao);
		MinimumSize = new Size(900, 650);
		Name = "frmRelatorio_Veias";
		ShowInTaskbar = false;
		Text = "Lista de Veias";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		((ISupportInitialize)dgVeias).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox3.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return SZPpPQZ8eXG;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		SZPpPQZ8eXG = WithEventsValue;
	}

	public frmRelatorio_Veias()
	{
		Resize += sAUpPMrMRCb;
		IYTpPR30NJq = new DeclaracoesFiacao.structurePnRev[1];
		KqIpPmjJ7cj = new DeclaracoesFiacao.structureRevisoes[1];
		I5OpPUXXG7v = "";
		toMpPy9ghj3 = false;
		f8cpPgrtxC2 = false;
		try
		{
			if (!Geral.ExisteForm("frmRelatorio_Veias"))
			{
				ElapPt0SCaB();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 895]);
				w8dpBZ0kvSD().SetToolTip(btPesquisar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1411]));
				CKAgrupar.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1313]);
				RBSeparPaineis.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1314]);
				RBSheetDiferente.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1315]);
				GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1723]);
				RBFuncaoCabo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1724]);
				RBFuncaoVeia.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1725]);
				GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1723]);
				CKBlindagem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 741]);
				CBComprimento.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1246]);
				cDadosAccess.carregaDadosDWG();
				Application.ShowModelessDialog((Form)this);
				formataDGRevisao();
				formataDGEquip();
				formataDGCabos();
				R96pPjkCH8F();
				qTotal.Text = "";
				AtualizaDGRevisao();
				AtualizaDGEquip();
				dgVeias.Rows.Clear();
				dgVeias.Columns.Clear();
				CKAgrupar.Checked = false;
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

	private void R96pPjkCH8F()
	{
		KqIpPmjJ7cj = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			cDadosAccessInterligacao3.CarregaRevisoesCabos4(ref KqIpPmjJ7cj);
			toMpPy9ghj3 = true;
			dgRevisao.Rows.Clear();
			toMpPy9ghj3 = false;
			int num = Information.UBound(KqIpPmjJ7cj);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				dgRevisao.Rows.Add(KqIpPmjJ7cj[i].revisao, KqIpPmjJ7cj[i].criador, KqIpPmjJ7cj[i].data);
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
			cDadosAccessInterligacao3.fechaConexao();
		}
	}

	private void lAupPLTGpkL(object P_0, EventArgs P_1)
	{
		f8cpPgrtxC2 = true;
		dgEquip.Rows.Clear();
		f8cpPgrtxC2 = false;
		if (!toMpPy9ghj3)
		{
			daopPwGj1wA();
		}
	}

	private void daopPwGj1wA()
	{
		CarregaPnRev();
		try
		{
			if (dgRevisao.SelectedRows.Count != 1)
			{
				return;
			}
			I5OpPUXXG7v = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
			f8cpPgrtxC2 = true;
			dgEquip.Rows.Clear();
			f8cpPgrtxC2 = false;
			int num = Information.UBound(IYTpPR30NJq);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(IYTpPR30NJq[i].revisao, I5OpPUXXG7v, TextCompare: true) == 0)
				{
					dgEquip.Rows.Add(IYTpPR30NJq[i].painel, Dicionario.BuscaNomeDoPainel(IYTpPR30NJq[i].painel));
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
		IYTpPR30NJq = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			if (Information.UBound(KqIpPmjJ7cj) > 0)
			{
				int num = Information.UBound(KqIpPmjJ7cj);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessInterligacao3.CarregaPnRev(KqIpPmjJ7cj[i].revisao, ref IYTpPR30NJq);
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
			cDadosAccessInterligacao3.fechaConexao();
		}
	}

	private void bqipPxovkmF(object P_0, EventArgs P_1)
	{
		qTotal.Text = "";
		formataDGCabos();
		List<string> lCabosUnico = new List<string>();
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		int num = 13;
		if (CBComprimento.Checked)
		{
			num = 14;
		}
		clsVeias.StructureUmaVeia[] mVeia = new clsVeias.StructureUmaVeia[1];
		cDadosAccessInterligacao3.CarregaFuncoesDaVeias4(I5OpPUXXG7v, ref mVeia);
		checked
		{
			try
			{
				BntpPX2HQES = new clsVeias.StructureVeias[1];
				if (dgEquip.SelectedRows.Count == 0)
				{
					return;
				}
				List<int> list = new List<int>();
				if (CKAgrupar.Checked)
				{
					formataDGCabos();
					int num2 = dgEquip.RowCount - 1;
					for (int i = 0; i <= num2; i++)
					{
						if (dgEquip.Rows[i].Selected)
						{
							list.Clear();
							list.Add(Conversions.ToInteger(dgEquip.Rows[i].Cells[0].Value));
							cDadosAccessInterligacao3.CarregaVeias4(I5OpPUXXG7v, ref lCabosUnico, list, ref BntpPX2HQES, bSepara: true, CKBlindagem.Checked);
						}
					}
					if (Information.UBound(BntpPX2HQES) == 0)
					{
						return;
					}
					string left = "";
					bool flag = false;
					bool flag2 = true;
					DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(BntpPX2HQES);
					DeclaracoesGeral._uscPagina.pbIniciar();
					if (RBFuncaoVeia.Checked)
					{
						int num3 = Information.UBound(BntpPX2HQES);
						for (int j = 1; j <= num3; j++)
						{
							int num4 = Information.UBound(mVeia);
							for (int k = 1; k <= num4; k++)
							{
								if (Operators.CompareString(BntpPX2HQES[j].sTag, mVeia[k].sTag, TextCompare: true) == 0 && BntpPX2HQES[j].iIndice == mVeia[k].iIndice)
								{
									BntpPX2HQES[j].sFuncao = mVeia[k].sFuncao;
								}
							}
						}
					}
					int num5 = Information.UBound(BntpPX2HQES);
					for (int l = 1; l <= num5; l++)
					{
						if (Operators.CompareString(left, BntpPX2HQES[l].sTag, TextCompare: true) != 0)
						{
							left = BntpPX2HQES[l].sTag;
							flag = !flag;
							flag2 = true;
						}
						string text = clsTextos.TiraNothing(BntpPX2HQES[l].sTag);
						string text2 = clsTextos.TiraNothing(BntpPX2HQES[l].sFormacao);
						string text3 = clsTextos.TiraNothing(BntpPX2HQES[l].sFuncao);
						string text4 = clsTextos.TiraNothing(BntpPX2HQES[l].sPainel1);
						string text5 = clsTextos.TiraNothing(BntpPX2HQES[l].sPainel2);
						string text6 = clsTextos.TiraNothing(BntpPX2HQES[l].sDiagrama);
						string text7 = clsTextos.TiraNothing(BntpPX2HQES[l].sPagina1);
						string text8 = clsTextos.TiraNothing(Conversions.ToString(BntpPX2HQES[l].dComprimento));
						if (Operators.CompareString(clsTextos.TiraNothing(BntpPX2HQES[l].sPagina1), clsTextos.TiraNothing(BntpPX2HQES[l].sPagina2), TextCompare: true) != 0)
						{
							if (Operators.CompareString(clsTextos.TiraNothing(BntpPX2HQES[l].sPagina1), "", TextCompare: true) == 0)
							{
								if (Operators.CompareString(clsTextos.TiraNothing(BntpPX2HQES[l].sPagina2), "", TextCompare: true) != 0)
								{
									text7 += clsTextos.TiraNothing(BntpPX2HQES[l].sPagina2);
								}
							}
							else
							{
								text7 = text7 + ", " + clsTextos.TiraNothing(BntpPX2HQES[l].sPagina2);
							}
						}
						if (!flag2)
						{
							text = "";
							text2 = "";
							text4 = "";
							text5 = "";
							text6 = "";
							text8 = "";
							if (!RBFuncaoVeia.Checked)
							{
								text3 = "";
							}
						}
						if (BntpPX2HQES[l].iPainelSel == 0)
						{
							if (!CBComprimento.Checked)
							{
								dgVeias.Rows.Add(text, text2, text3, BntpPX2HQES[l].sVeia, text4, BntpPX2HQES[l].sDisp1, BntpPX2HQES[l].sBorne1, BntpPX2HQES[l].sAterrar1, text5, BntpPX2HQES[l].sDisp2, BntpPX2HQES[l].sBorne2, BntpPX2HQES[l].sAterrar2, text6, text7);
							}
							else
							{
								dgVeias.Rows.Add(text, text2, text3, BntpPX2HQES[l].sVeia, text4, BntpPX2HQES[l].sDisp1, BntpPX2HQES[l].sBorne1, BntpPX2HQES[l].sAterrar1, text5, BntpPX2HQES[l].sDisp2, BntpPX2HQES[l].sBorne2, BntpPX2HQES[l].sAterrar2, text6, text7, text8);
							}
							if (flag)
							{
								DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
								dataGridViewCellStyle.BackColor = Color.AntiqueWhite;
								int num6 = num;
								for (int m = 0; m <= num6; m++)
								{
									dataGridViewCellStyle.BackColor = Color.AntiqueWhite;
									dgVeias.Rows[dgVeias.Rows.Count - 1].Cells[m].Style = dataGridViewCellStyle;
								}
							}
							flag2 = false;
						}
						else if (l != Information.UBound(BntpPX2HQES) && BntpPX2HQES[l + 1].iPainelSel == 0)
						{
							string text9 = Dicionario.BuscaNomeDoPainel(BntpPX2HQES[l].iPainelSel);
							if (!CBComprimento.Checked)
							{
								dgVeias.Rows.Add("", "", text9, "", "", "", "", "", "", "", "", "", "", "");
							}
							else
							{
								dgVeias.Rows.Add("", "", text9, "", "", "", "", "", "", "", "", "", "", "", "");
							}
							DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
							dataGridViewCellStyle2.BackColor = Color.LightBlue;
							if (dgVeias.Rows.Count > 0)
							{
								int num7 = num;
								for (int n = 0; n <= num7; n++)
								{
									dgVeias.Rows[dgVeias.RowCount - 1].Cells[n].Style = dataGridViewCellStyle2;
								}
							}
						}
						DeclaracoesGeral._uscPagina.pbPasso();
					}
					AtualizaDGCabos();
					DeclaracoesGeral._uscPagina.pbFim();
				}
				else
				{
					int num8 = dgEquip.RowCount - 1;
					for (int num9 = 0; num9 <= num8; num9++)
					{
						if (dgEquip.Rows[num9].Selected)
						{
							list.Add(Conversions.ToInteger(dgEquip.Rows[num9].Cells[0].Value));
						}
					}
					cDadosAccessInterligacao3.CarregaVeias4(I5OpPUXXG7v, ref lCabosUnico, list, ref BntpPX2HQES, bSepara: true, CKBlindagem.Checked);
					formataDGCabos();
					if (RBFuncaoVeia.Checked)
					{
						int num10 = Information.UBound(BntpPX2HQES);
						for (int num11 = 1; num11 <= num10; num11++)
						{
							int num12 = Information.UBound(mVeia);
							for (int num13 = 1; num13 <= num12; num13++)
							{
								if (Operators.CompareString(BntpPX2HQES[num11].sTag, "", TextCompare: true) != 0 && Operators.CompareString(BntpPX2HQES[num11].sTag, mVeia[num13].sTag, TextCompare: true) == 0 && BntpPX2HQES[num11].iIndice == mVeia[num13].iIndice)
								{
									BntpPX2HQES[num11].sFuncao = "";
									if (Operators.CompareString(mVeia[num13].sFuncao, "", TextCompare: true) != 0)
									{
										BntpPX2HQES[num11].sFuncao = mVeia[num13].sFuncao;
									}
								}
							}
						}
					}
					if (Information.UBound(BntpPX2HQES) == 0)
					{
						return;
					}
					string left2 = "";
					bool flag3 = false;
					bool flag4 = true;
					DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(BntpPX2HQES);
					DeclaracoesGeral._uscPagina.pbIniciar();
					int num14 = Information.UBound(BntpPX2HQES);
					for (int num15 = 1; num15 <= num14; num15++)
					{
						if (Operators.CompareString(left2, BntpPX2HQES[num15].sTag, TextCompare: true) != 0)
						{
							left2 = BntpPX2HQES[num15].sTag;
							flag3 = !flag3;
							flag4 = true;
						}
						string text10 = clsTextos.TiraNothing(BntpPX2HQES[num15].sTag);
						string text11 = clsTextos.TiraNothing(BntpPX2HQES[num15].sFormacao);
						string text12 = clsTextos.TiraNothing(BntpPX2HQES[num15].sFuncao);
						string text13 = clsTextos.TiraNothing(BntpPX2HQES[num15].sPainel1);
						string text14 = clsTextos.TiraNothing(BntpPX2HQES[num15].sPainel2);
						string text15 = clsTextos.TiraNothing(BntpPX2HQES[num15].sDiagrama);
						string text16 = clsTextos.TiraNothing(BntpPX2HQES[num15].sPagina1);
						string text17 = clsTextos.TiraNothing(Conversions.ToString(BntpPX2HQES[num15].dComprimento));
						if (Operators.CompareString(BntpPX2HQES[num15].sPagina1, BntpPX2HQES[num15].sPagina2, TextCompare: true) != 0)
						{
							if (Operators.CompareString(BntpPX2HQES[num15].sPagina1, "", TextCompare: true) == 0)
							{
								if (Operators.CompareString(BntpPX2HQES[num15].sPagina2, "", TextCompare: true) != 0)
								{
									text16 += BntpPX2HQES[num15].sPagina2;
								}
							}
							else
							{
								text16 = text16 + ", " + BntpPX2HQES[num15].sPagina2;
							}
						}
						if (!flag4)
						{
							text10 = "";
							text11 = "";
							text13 = "";
							text14 = "";
							text15 = "";
							text17 = "";
							if (!RBFuncaoVeia.Checked)
							{
								text12 = "";
							}
						}
						if (BntpPX2HQES[num15].iPainelSel == 0)
						{
							if (!CBComprimento.Checked)
							{
								dgVeias.Rows.Add(text10, text11, text12, BntpPX2HQES[num15].sVeia, text13, BntpPX2HQES[num15].sDisp1, BntpPX2HQES[num15].sBorne1, BntpPX2HQES[num15].sAterrar1, text14, BntpPX2HQES[num15].sDisp2, BntpPX2HQES[num15].sBorne2, BntpPX2HQES[num15].sAterrar2, text15, text16);
							}
							else
							{
								dgVeias.Rows.Add(text10, text11, text12, BntpPX2HQES[num15].sVeia, text13, BntpPX2HQES[num15].sDisp1, BntpPX2HQES[num15].sBorne1, BntpPX2HQES[num15].sAterrar1, text14, BntpPX2HQES[num15].sDisp2, BntpPX2HQES[num15].sBorne2, BntpPX2HQES[num15].sAterrar2, text15, text16, text17);
							}
							if (flag3)
							{
								DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
								dataGridViewCellStyle3.BackColor = Color.AntiqueWhite;
								int num16 = num;
								for (int num17 = 0; num17 <= num16; num17++)
								{
									dataGridViewCellStyle3.BackColor = Color.AntiqueWhite;
									dgVeias.Rows[dgVeias.Rows.Count - 1].Cells[num17].Style = dataGridViewCellStyle3;
								}
							}
							flag4 = false;
						}
						DeclaracoesGeral._uscPagina.pbPasso();
					}
					AtualizaDGCabos();
					DeclaracoesGeral._uscPagina.pbFim();
				}
				qTotal.Text = lCabosUnico.Count.ToString();
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
				cDadosAccessInterligacao3.FechaConexao();
			}
		}
	}

	private void M0upPbCK5oS(object P_0, EventArgs P_1)
	{
		btExportaEXCEL.Enabled = false;
		if (Information.IsNothing(BntpPX2HQES) || Information.UBound(BntpPX2HQES) == 0)
		{
			return;
		}
		if (CKAgrupar.Checked)
		{
			if (RBSeparPaineis.Checked)
			{
				Relatorios_ListaVeiasEXCEL.CriaListaVeiasEXCELSeparaPainel(BntpPX2HQES, RBFuncaoVeia.Checked, CBComprimento.Checked);
			}
			if (RBSheetDiferente.Checked)
			{
				Relatorios_ListaVeiasEXCEL.CriaListaVeiasEXCELSeparaSheet(BntpPX2HQES, RBFuncaoVeia.Checked, CBComprimento.Checked);
			}
		}
		else
		{
			Relatorios_ListaVeiasEXCEL.CriaListaVeiasEXCEL(BntpPX2HQES, RBFuncaoVeia.Checked, CBComprimento.Checked);
		}
		btExportaEXCEL.Enabled = true;
	}

	public void formataDGRevisao()
	{
		try
		{
			dgRevisao.Rows.Clear();
			dgRevisao.Columns.Clear();
			dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 752]));
			dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 753]));
			dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 754]));
			AtualizaDGRevisao();
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
				if (dgRevisao.RowCount != 0)
				{
					double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgRevisao)) ? ((double)(dgRevisao.Width - 4)) : ((double)(dgRevisao.Width - 25)));
					dgRevisao.Columns[0].Width = (int)Math.Round(num / 3.0);
					dgRevisao.Columns[1].Width = (int)Math.Round(num / 3.0);
					dgRevisao.Columns[2].Width = (int)Math.Round(num / 3.0);
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

	public void formataDGEquip()
	{
		try
		{
			f8cpPgrtxC2 = true;
			dgEquip.Rows.Clear();
			dgEquip.Columns.Clear();
			dgEquip.Columns.Add("", "Indice");
			dgEquip.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 748]));
			AtualizaDGEquip();
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
			f8cpPgrtxC2 = false;
		}
	}

	public void AtualizaDGEquip()
	{
		checked
		{
			try
			{
				if (dgEquip.RowCount != 0)
				{
					double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgEquip)) ? ((double)(dgEquip.Width - 4)) : ((double)(dgEquip.Width - 22)));
					dgEquip.Columns[0].Width = 0;
					dgEquip.Columns[0].Visible = false;
					dgEquip.Columns[1].Width = (int)Math.Round(a);
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
				f8cpPgrtxC2 = false;
			}
		}
	}

	public void formataDGCabos()
	{
		try
		{
			dgVeias.Rows.Clear();
			dgVeias.Columns.Clear();
			dgVeias.Columns.Add("", DeclaracoesGeral.mMensagem[1, 176].ToString().ToUpper());
			dgVeias.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1285].ToString().ToUpper());
			dgVeias.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1430].ToString().ToUpper());
			dgVeias.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1239].ToString().ToUpper());
			dgVeias.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1081].ToString().ToUpper());
			dgVeias.Columns.Add("", DeclaracoesGeral.mMensagem[1, 518].ToString().ToUpper());
			dgVeias.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1429].ToString().ToUpper());
			dgVeias.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1243].ToString().ToUpper());
			dgVeias.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1081].ToString().ToUpper());
			dgVeias.Columns.Add("", DeclaracoesGeral.mMensagem[1, 518].ToString().ToUpper());
			dgVeias.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1429].ToString().ToUpper());
			dgVeias.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1243].ToString().ToUpper());
			dgVeias.Columns.Add("", DeclaracoesGeral.mMensagem[1, 253].ToString().ToUpper());
			dgVeias.Columns.Add("", DeclaracoesGeral.mMensagem[1, 9].ToString().ToUpper());
			if (CBComprimento.Checked)
			{
				dgVeias.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1246].ToString().ToUpper());
			}
			AtualizaDGCabos();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void AtualizaDGCabos()
	{
		checked
		{
			try
			{
				if (dgVeias.RowCount == 0)
				{
					return;
				}
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgVeias)) ? ((double)(dgVeias.Width - 10)) : ((double)(dgVeias.Width - 25)));
				dgVeias.Columns[0].Width = (int)Math.Round(num * 0.066);
				dgVeias.Columns[1].Width = (int)Math.Round(num * 0.066);
				dgVeias.Columns[2].Width = (int)Math.Round(num * 0.202);
				dgVeias.Columns[3].Width = (int)Math.Round(num * 0.038);
				dgVeias.Columns[4].Width = (int)Math.Round(num * 0.066);
				dgVeias.Columns[5].Width = (int)Math.Round(num * 0.055);
				dgVeias.Columns[6].Width = (int)Math.Round(num * 0.044);
				dgVeias.Columns[7].Width = (int)Math.Round(num * 0.055);
				dgVeias.Columns[8].Width = (int)Math.Round(num * 0.066);
				dgVeias.Columns[9].Width = (int)Math.Round(num * 0.055);
				dgVeias.Columns[10].Width = (int)Math.Round(num * 0.044);
				dgVeias.Columns[11].Width = (int)Math.Round(num * 0.055);
				if (!CBComprimento.Checked)
				{
					dgVeias.Columns[12].Width = (int)Math.Round(num * 0.137);
					dgVeias.Columns[13].Width = (int)Math.Round(num * 0.055);
					int num2 = 0;
					do
					{
						dgVeias.Columns[num2].Visible = true;
						dgVeias.Columns[num2].ReadOnly = false;
						num2++;
					}
					while (num2 <= 13);
				}
				else
				{
					dgVeias.Columns[12].Width = (int)Math.Round(num * 0.1);
					dgVeias.Columns[13].Width = (int)Math.Round(num * 0.046);
					dgVeias.Columns[14].Width = (int)Math.Round(num * 0.046);
					int num3 = 0;
					do
					{
						dgVeias.Columns[num3].Visible = true;
						dgVeias.Columns[num3].ReadOnly = false;
						num3++;
					}
					while (num3 <= 14);
				}
				dgVeias.MultiSelect = false;
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

	private void sAUpPMrMRCb(object P_0, EventArgs P_1)
	{
		AtualizaDGRevisao();
		AtualizaDGEquip();
		AtualizaDGCabos();
	}

	private void AeipPO1FRvi(object P_0, EventArgs P_1)
	{
		if (!CKAgrupar.Checked)
		{
			RBSeparPaineis.Enabled = false;
			RBSheetDiferente.Enabled = false;
			qTotal.Text = "";
			formataDGCabos();
		}
		else
		{
			RBSeparPaineis.Enabled = true;
			RBSheetDiferente.Enabled = true;
			RBSeparPaineis.Checked = true;
			qTotal.Text = "";
			formataDGCabos();
		}
	}

	private void cj2pPIiepbj(object P_0, EventArgs P_1)
	{
		formataDGCabos();
	}
}
