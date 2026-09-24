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
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmRelatorio_VeiasCopel : Form
{
	private IContainer i78PDCTyj4;

	[AccessedThroughProperty("dgRevisao")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView BGRPvqnEF9;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgEquip")]
	private DataGridView zkZP6ZMDpa;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgVeias")]
	private DataGridView csbPtqHhHU;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btPesquisar")]
	private Button IWRPjl8ut7;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	[CompilerGenerated]
	private ToolTip q8PPLTGOfJ;

	[AccessedThroughProperty("btExporta")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button iuBPwGLxDx;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagar")]
	private Button LT2Pxeyclq;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTCancelar")]
	private Button tdePbN3EZn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTY")]
	private Button nu5PMOxZY6;

	[AccessedThroughProperty("tbOrdenadaY")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox iw5POt4e0X;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lPTIni")]
	[CompilerGenerated]
	private Label LqtPIj9vAN;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBBlindagem")]
	private CheckBox RSwP7MwROg;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox NNJPqw5NlK;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgTag")]
	private DataGridView mHKPaF45ZD;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("qCabosSel")]
	private Label LI1P8OBknj;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBComprimento")]
	[CompilerGenerated]
	private CheckBox IwGPN8kwg8;

	private DeclaracoesFiacao.structurePnRev[] UIiPFB24ax;

	private DeclaracoesFiacao.structureRevisoes[] wosPQpcepx;

	private clsVeias.StructureVeias[] YwdPPR4f3p;

	private string LWxPcCFUM6;

	private bool yp5PKJoAi6;

	private bool j2EPe1okWC;

	private Declaracoes2.ConfRelatorio d22P2Gb9BG;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return BGRPvqnEF9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = y3gQYcLHUP;
			DataGridView dataGridView = BGRPvqnEF9;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			BGRPvqnEF9 = value;
			dataGridView = BGRPvqnEF9;
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
			return zkZP6ZMDpa;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = OTvQzKHFnZ;
			MouseEventHandler value3 = NpQPWbbZVa;
			DataGridView dataGridView = zkZP6ZMDpa;
			if (dataGridView != null)
			{
				dataGridView.KeyUp -= value2;
				dataGridView.MouseUp -= value3;
			}
			zkZP6ZMDpa = value;
			dataGridView = zkZP6ZMDpa;
			if (dataGridView != null)
			{
				dataGridView.KeyUp += value2;
				dataGridView.MouseUp += value3;
			}
		}
	}

	internal virtual DataGridView dgVeias
	{
		[CompilerGenerated]
		get
		{
			return csbPtqHhHU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			csbPtqHhHU = value;
		}
	}

	internal virtual Button btPesquisar
	{
		[CompilerGenerated]
		get
		{
			return IWRPjl8ut7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = wWCQ9LBU7L;
			Button button = IWRPjl8ut7;
			if (button != null)
			{
				button.Click -= value2;
			}
			IWRPjl8ut7 = value;
			button = IWRPjl8ut7;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btExporta
	{
		[CompilerGenerated]
		get
		{
			return iuBPwGLxDx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = yMHPoMDEo3;
			Button button = iuBPwGLxDx;
			if (button != null)
			{
				button.Click -= value2;
			}
			iuBPwGLxDx = value;
			button = iuBPwGLxDx;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btApagar
	{
		[CompilerGenerated]
		get
		{
			return LT2Pxeyclq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AdnPkt5dD6;
			Button button = LT2Pxeyclq;
			if (button != null)
			{
				button.Click -= value2;
			}
			LT2Pxeyclq = value;
			button = LT2Pxeyclq;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTCancelar
	{
		[CompilerGenerated]
		get
		{
			return tdePbN3EZn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tdePbN3EZn = value;
		}
	}

	internal virtual Button BTY
	{
		[CompilerGenerated]
		get
		{
			return nu5PMOxZY6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = O27PdaI6Aj;
			Button button = nu5PMOxZY6;
			if (button != null)
			{
				button.Click -= value2;
			}
			nu5PMOxZY6 = value;
			button = nu5PMOxZY6;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbOrdenadaY
	{
		[CompilerGenerated]
		get
		{
			return iw5POt4e0X;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			iw5POt4e0X = value;
		}
	}

	internal virtual Label lPTIni
	{
		[CompilerGenerated]
		get
		{
			return LqtPIj9vAN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LqtPIj9vAN = value;
		}
	}

	internal virtual CheckBox CBBlindagem
	{
		[CompilerGenerated]
		get
		{
			return RSwP7MwROg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = cbPPfsEg2W;
			CheckBox checkBox = RSwP7MwROg;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			RSwP7MwROg = value;
			checkBox = RSwP7MwROg;
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
			return NNJPqw5NlK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			NNJPqw5NlK = value;
		}
	}

	internal virtual DataGridView dgTag
	{
		[CompilerGenerated]
		get
		{
			return mHKPaF45ZD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = uBVPTN293T;
			MouseEventHandler value3 = MCqPJdR8c7;
			DataGridView dataGridView = mHKPaF45ZD;
			if (dataGridView != null)
			{
				dataGridView.KeyUp -= value2;
				dataGridView.MouseUp -= value3;
			}
			mHKPaF45ZD = value;
			dataGridView = mHKPaF45ZD;
			if (dataGridView != null)
			{
				dataGridView.KeyUp += value2;
				dataGridView.MouseUp += value3;
			}
		}
	}

	internal virtual Label qCabosSel
	{
		[CompilerGenerated]
		get
		{
			return LI1P8OBknj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LI1P8OBknj = value;
		}
	}

	internal virtual CheckBox CBComprimento
	{
		[CompilerGenerated]
		get
		{
			return IwGPN8kwg8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = cbPPfsEg2W;
			CheckBox checkBox = IwGPN8kwg8;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			IwGPN8kwg8 = value;
			checkBox = IwGPN8kwg8;
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
			if (disposing && i78PDCTyj4 != null)
			{
				i78PDCTyj4.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void WikQ4qIBJQ()
	{
		i78PDCTyj4 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmRelatorio_VeiasCopel));
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		dgRevisao = new DataGridView();
		dgEquip = new DataGridView();
		dgVeias = new DataGridView();
		btPesquisar = new Button();
		FDqpBiUmZij(new ToolTip(i78PDCTyj4));
		btExporta = new Button();
		btApagar = new Button();
		BTCancelar = new Button();
		BTY = new Button();
		tbOrdenadaY = new TextBox();
		lPTIni = new Label();
		CBBlindagem = new CheckBox();
		GroupBox1 = new GroupBox();
		CBComprimento = new CheckBox();
		dgTag = new DataGridView();
		qCabosSel = new Label();
		((ISupportInitialize)dgRevisao).BeginInit();
		((ISupportInitialize)dgEquip).BeginInit();
		((ISupportInitialize)dgVeias).BeginInit();
		GroupBox1.SuspendLayout();
		((ISupportInitialize)dgTag).BeginInit();
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
		dgRevisao.Size = new Size(237, 162);
		dgRevisao.TabIndex = 3;
		dgEquip.AllowUserToAddRows = false;
		dgEquip.AllowUserToDeleteRows = false;
		dgEquip.AllowUserToOrderColumns = true;
		dgEquip.AllowUserToResizeRows = false;
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
		dgEquip.Location = new Point(12, 181);
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(237, 185);
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
		dgVeias.Location = new Point(255, 12);
		dgVeias.MultiSelect = false;
		dgVeias.Name = "dgVeias";
		dgVeias.ReadOnly = true;
		dgVeias.RowHeadersVisible = false;
		dgVeias.SelectionMode = DataGridViewSelectionMode.CellSelect;
		dgVeias.Size = new Size(617, 642);
		dgVeias.TabIndex = 11;
		btPesquisar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisar.FlatStyle = FlatStyle.Flat;
		btPesquisar.ForeColor = SystemColors.Control;
		btPesquisar.Image = Resources.Pesquisar_32;
		btPesquisar.Location = new Point(12, 612);
		btPesquisar.Name = "btPesquisar";
		btPesquisar.Size = new Size(40, 42);
		btPesquisar.TabIndex = 15;
		btPesquisar.UseVisualStyleBackColor = true;
		btExporta.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btExporta.FlatStyle = FlatStyle.Flat;
		btExporta.ForeColor = SystemColors.Control;
		btExporta.Image = (Image)componentResourceManager.GetObject("btExporta.Image");
		btExporta.Location = new Point(207, 612);
		btExporta.Name = "btExporta";
		btExporta.Size = new Size(40, 42);
		btExporta.TabIndex = 191;
		btExporta.UseVisualStyleBackColor = true;
		btApagar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagar.FlatStyle = FlatStyle.Flat;
		btApagar.ForeColor = SystemColors.Control;
		btApagar.Image = Resources.Delete_32;
		btApagar.Location = new Point(77, 612);
		btApagar.Name = "btApagar";
		btApagar.Size = new Size(40, 42);
		btApagar.TabIndex = 192;
		btApagar.Tag = "";
		btApagar.UseVisualStyleBackColor = true;
		BTCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BTCancelar.FlatStyle = FlatStyle.Flat;
		BTCancelar.ForeColor = SystemColors.Control;
		BTCancelar.Image = Resources.Stop_32;
		BTCancelar.Location = new Point(142, 612);
		BTCancelar.Name = "BTCancelar";
		BTCancelar.Size = new Size(40, 42);
		BTCancelar.TabIndex = 193;
		BTCancelar.UseVisualStyleBackColor = true;
		BTY.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BTY.FlatStyle = FlatStyle.Flat;
		BTY.ForeColor = SystemColors.Control;
		BTY.Image = Resources.Altura;
		BTY.Location = new Point(207, 570);
		BTY.Name = "BTY";
		BTY.Size = new Size(40, 40);
		BTY.TabIndex = 210;
		BTY.UseVisualStyleBackColor = true;
		tbOrdenadaY.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		tbOrdenadaY.BackColor = SystemColors.ActiveBorder;
		tbOrdenadaY.Location = new Point(154, 581);
		tbOrdenadaY.Name = "tbOrdenadaY";
		tbOrdenadaY.ReadOnly = true;
		tbOrdenadaY.Size = new Size(47, 20);
		tbOrdenadaY.TabIndex = 209;
		lPTIni.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		lPTIni.AutoSize = true;
		lPTIni.ImageAlign = ContentAlignment.MiddleRight;
		lPTIni.Location = new Point(12, 584);
		lPTIni.Name = "lPTIni";
		lPTIni.Size = new Size(124, 13);
		lPTIni.TabIndex = 208;
		lPTIni.Text = "Ponto inicial do Relatório";
		lPTIni.TextAlign = ContentAlignment.MiddleRight;
		CBBlindagem.AutoSize = true;
		CBBlindagem.Location = new Point(7, 16);
		CBBlindagem.Name = "CBBlindagem";
		CBBlindagem.Size = new Size(89, 17);
		CBBlindagem.TabIndex = 211;
		CBBlindagem.Text = "CBBlindagem";
		CBBlindagem.UseVisualStyleBackColor = true;
		GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox1.Controls.Add(CBComprimento);
		GroupBox1.Controls.Add(CBBlindagem);
		GroupBox1.Location = new Point(12, 510);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(175, 59);
		GroupBox1.TabIndex = 212;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "gbMostrar";
		CBComprimento.AutoSize = true;
		CBComprimento.Location = new Point(7, 36);
		CBComprimento.Name = "CBComprimento";
		CBComprimento.Size = new Size(101, 17);
		CBComprimento.TabIndex = 212;
		CBComprimento.Text = "CBComprimento";
		CBComprimento.UseVisualStyleBackColor = true;
		dgTag.AllowUserToAddRows = false;
		dgTag.AllowUserToDeleteRows = false;
		dgTag.AllowUserToOrderColumns = true;
		dgTag.AllowUserToResizeRows = false;
		dgTag.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgTag.BackgroundColor = Color.White;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = SystemColors.Control;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		dgTag.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		dgTag.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgTag.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgTag.Location = new Point(12, 372);
		dgTag.Name = "dgTag";
		dgTag.ReadOnly = true;
		dgTag.RowHeadersVisible = false;
		dgTag.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgTag.Size = new Size(237, 132);
		dgTag.TabIndex = 213;
		qCabosSel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		qCabosSel.BorderStyle = BorderStyle.Fixed3D;
		qCabosSel.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		qCabosSel.Location = new Point(190, 516);
		qCabosSel.Name = "qCabosSel";
		qCabosSel.Size = new Size(59, 51);
		qCabosSel.TabIndex = 214;
		qCabosSel.Text = "TOT";
		qCabosSel.TextAlign = ContentAlignment.MiddleRight;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(884, 661);
		Controls.Add(qCabosSel);
		Controls.Add(dgTag);
		Controls.Add(GroupBox1);
		Controls.Add(BTY);
		Controls.Add(tbOrdenadaY);
		Controls.Add(lPTIni);
		Controls.Add(btApagar);
		Controls.Add(BTCancelar);
		Controls.Add(btExporta);
		Controls.Add(btPesquisar);
		Controls.Add(dgVeias);
		Controls.Add(dgEquip);
		Controls.Add(dgRevisao);
		MinimumSize = new Size(900, 700);
		Name = "frmRelatorio_VeiasCopel";
		ShowInTaskbar = false;
		Text = "Lista de Veias";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		((ISupportInitialize)dgVeias).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		((ISupportInitialize)dgTag).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return q8PPLTGOfJ;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		q8PPLTGOfJ = WithEventsValue;
	}

	public frmRelatorio_VeiasCopel()
	{
		Resize += zRiPGFBn8n;
		UIiPFB24ax = new DeclaracoesFiacao.structurePnRev[1];
		wosPQpcepx = new DeclaracoesFiacao.structureRevisoes[1];
		LWxPcCFUM6 = "";
		yp5PKJoAi6 = false;
		j2EPe1okWC = false;
		try
		{
			if (!Geral.ExisteForm("frmRelatorio_VeiasCopel"))
			{
				WikQ4qIBJQ();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1921]);
				w8dpBZ0kvSD().SetToolTip(btPesquisar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1411]));
				GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1723]);
				CBBlindagem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 741]);
				CBComprimento.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1246]);
				tbOrdenadaY.Text = Conversions.ToString(25);
				cDadosAccess.carregaDadosDWG();
				Application.ShowModelessDialog((Form)this);
				formataDGRevisao();
				formataDGEquip();
				formataDGVeias();
				E7CQCMMQwX();
				AtualizaDGRevisao();
				AtualizaDGEquip();
				dgVeias.Rows.Clear();
				dgVeias.Columns.Clear();
				tTtPpNxd79();
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

	private void E7CQCMMQwX()
	{
		wosPQpcepx = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			cDadosAccessInterligacao3.CarregaRevisoesCabos4(ref wosPQpcepx);
			yp5PKJoAi6 = true;
			dgRevisao.Rows.Clear();
			yp5PKJoAi6 = false;
			int num = Information.UBound(wosPQpcepx);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				dgRevisao.Rows.Add(wosPQpcepx[i].revisao, wosPQpcepx[i].criador, wosPQpcepx[i].data);
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

	private void y3gQYcLHUP(object P_0, EventArgs P_1)
	{
		j2EPe1okWC = true;
		dgEquip.Rows.Clear();
		j2EPe1okWC = false;
		if (!yp5PKJoAi6)
		{
			WEHQrPqvkL();
		}
	}

	private void WEHQrPqvkL()
	{
		CarregaPnRev();
		try
		{
			if (dgRevisao.SelectedRows.Count != 1)
			{
				return;
			}
			LWxPcCFUM6 = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
			j2EPe1okWC = true;
			dgEquip.Rows.Clear();
			j2EPe1okWC = false;
			int num = Information.UBound(UIiPFB24ax);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(UIiPFB24ax[i].revisao, LWxPcCFUM6, TextCompare: true) == 0)
				{
					dgEquip.Rows.Add(UIiPFB24ax[i].painel, Dicionario.BuscaNomeDoPainel(UIiPFB24ax[i].painel));
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
		UIiPFB24ax = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			if (Information.UBound(wosPQpcepx) > 0)
			{
				int num = Information.UBound(wosPQpcepx);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessInterligacao3.CarregaPnRev(wosPQpcepx[i].revisao, ref UIiPFB24ax);
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

	private void wWCQ9LBU7L(object P_0, EventArgs P_1)
	{
		formataDGVeias();
		List<string> lCabosUnico = new List<string>();
		List<string> lCabos = new List<string>();
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		clsVeias.StructureUmaVeia[] mVeia = new clsVeias.StructureUmaVeia[1];
		cDadosAccessInterligacao3.CarregaFuncoesDaVeias4(LWxPcCFUM6, ref mVeia);
		checked
		{
			try
			{
				YwdPPR4f3p = new clsVeias.StructureVeias[1];
				if (dgEquip.SelectedRows.Count == 0)
				{
					return;
				}
				List<int> list = new List<int>();
				int num = dgEquip.RowCount - 1;
				for (int i = 0; i <= num; i++)
				{
					if (dgEquip.Rows[i].Selected)
					{
						list.Add(Conversions.ToInteger(dgEquip.Rows[i].Cells[0].Value));
					}
				}
				int num2 = dgTag.RowCount - 1;
				for (int j = 0; j <= num2; j++)
				{
					if (dgTag.Rows[j].Selected)
					{
						lCabos.Add(Conversions.ToString(dgTag.Rows[j].Cells[0].Value));
					}
				}
				cDadosAccessInterligacao3.CarregaVeias4Copel(LWxPcCFUM6, ref lCabosUnico, ref lCabos, list, ref YwdPPR4f3p, bSepara: true, CBBlindagem.Checked);
				formataDGVeias();
				if (Information.UBound(YwdPPR4f3p) == 0)
				{
					return;
				}
				string left = "";
				bool flag = false;
				bool flag2 = true;
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(YwdPPR4f3p);
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num3 = Information.UBound(YwdPPR4f3p);
				for (int k = 1; k <= num3; k++)
				{
					if (Operators.CompareString(left, YwdPPR4f3p[k].sTag, TextCompare: true) != 0)
					{
						left = YwdPPR4f3p[k].sTag;
						flag = !flag;
						flag2 = true;
					}
					string text = YwdPPR4f3p[k].sTag;
					string text2 = YwdPPR4f3p[k].sFormacao;
					string sFuncao = YwdPPR4f3p[k].sFuncao;
					string text3 = YwdPPR4f3p[k].sPainel1;
					string text4 = YwdPPR4f3p[k].sPainel2;
					string text5 = YwdPPR4f3p[k].sDiagrama;
					string text6 = YwdPPR4f3p[k].sPagina1;
					string text7 = YwdPPR4f3p[k].dComprimento.ToString();
					if (Operators.CompareString(YwdPPR4f3p[k].sPagina1, YwdPPR4f3p[k].sPagina2, TextCompare: true) != 0)
					{
						text6 = text6 + ", " + YwdPPR4f3p[k].sPagina2;
					}
					if (!flag2)
					{
						text = "";
						text2 = "";
						text3 = "";
						text4 = "";
						text5 = "";
						text7 = "";
					}
					int num4 = 13;
					if (CBComprimento.Checked)
					{
						num4 = 14;
					}
					if (YwdPPR4f3p[k].iPainelSel == 0)
					{
						if (!CBBlindagem.Checked)
						{
							if (!CBComprimento.Checked)
							{
								if (YwdPPR4f3p[k].iIndice > 0)
								{
									dgVeias.Rows.Add(text, text2, sFuncao, YwdPPR4f3p[k].sVeia, text3, YwdPPR4f3p[k].sDisp1, YwdPPR4f3p[k].sBorne1, YwdPPR4f3p[k].sAterrar1, text4, YwdPPR4f3p[k].sDisp2, YwdPPR4f3p[k].sBorne2, YwdPPR4f3p[k].sAterrar2, text5, text6);
								}
							}
							else if (YwdPPR4f3p[k].iIndice > 0)
							{
								dgVeias.Rows.Add(text, text2, sFuncao, YwdPPR4f3p[k].sVeia, text3, YwdPPR4f3p[k].sDisp1, YwdPPR4f3p[k].sBorne1, YwdPPR4f3p[k].sAterrar1, text4, YwdPPR4f3p[k].sDisp2, YwdPPR4f3p[k].sBorne2, YwdPPR4f3p[k].sAterrar2, text5, text6, text7);
							}
						}
						else if (!CBComprimento.Checked)
						{
							dgVeias.Rows.Add(text, text2, sFuncao, YwdPPR4f3p[k].sVeia, text3, YwdPPR4f3p[k].sDisp1, YwdPPR4f3p[k].sBorne1, YwdPPR4f3p[k].sAterrar1, text4, YwdPPR4f3p[k].sDisp2, YwdPPR4f3p[k].sBorne2, YwdPPR4f3p[k].sAterrar2, text5, text6);
						}
						else
						{
							dgVeias.Rows.Add(text, text2, sFuncao, YwdPPR4f3p[k].sVeia, text3, YwdPPR4f3p[k].sDisp1, YwdPPR4f3p[k].sBorne1, YwdPPR4f3p[k].sAterrar1, text4, YwdPPR4f3p[k].sDisp2, YwdPPR4f3p[k].sBorne2, YwdPPR4f3p[k].sAterrar2, text5, text6, text7);
						}
						if (flag)
						{
							DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
							dataGridViewCellStyle.BackColor = Color.AntiqueWhite;
							int num5 = num4;
							for (int l = 0; l <= num5; l++)
							{
								dataGridViewCellStyle.BackColor = Color.AntiqueWhite;
								dgVeias.Rows[dgVeias.Rows.Count - 1].Cells[l].Style = dataGridViewCellStyle;
							}
						}
						flag2 = false;
					}
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				AtualizaDGCabos();
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
				cDadosAccessInterligacao3.FechaConexao();
			}
		}
	}

	private void OTvQzKHFnZ(object P_0, KeyEventArgs P_1)
	{
		tTtPpNxd79();
	}

	private void NpQPWbbZVa(object P_0, MouseEventArgs P_1)
	{
		tTtPpNxd79();
	}

	private void tTtPpNxd79()
	{
		formataDGTag();
		List<string> lCabos = new List<string>();
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		checked
		{
			try
			{
				YwdPPR4f3p = new clsVeias.StructureVeias[1];
				if (dgEquip.SelectedRows.Count == 0)
				{
					return;
				}
				List<int> list = new List<int>();
				int num = dgEquip.RowCount - 1;
				for (int i = 0; i <= num; i++)
				{
					if (dgEquip.Rows[i].Selected)
					{
						list.Add(Conversions.ToInteger(dgEquip.Rows[i].Cells[0].Value));
					}
				}
				cDadosAccessInterligacao3.CarregaVeias4Copel(LWxPcCFUM6, ref lCabos, list, CBBlindagem.Checked);
				formataDGTag();
				formataDGVeias();
				if (lCabos.Count > 0)
				{
					foreach (string item in lCabos)
					{
						dgTag.Rows.Add(item);
					}
				}
				AtualizaDGTag();
				int num2 = dgTag.RowCount - 1;
				for (int j = 0; j <= num2; j++)
				{
					dgTag.Rows[j].Selected = true;
				}
				lvcPhTfHcm();
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
				cDadosAccessInterligacao3.FechaConexao();
			}
		}
	}

	private void uBVPTN293T(object P_0, KeyEventArgs P_1)
	{
		lvcPhTfHcm();
	}

	private void MCqPJdR8c7(object P_0, MouseEventArgs P_1)
	{
		lvcPhTfHcm();
	}

	private void lvcPhTfHcm()
	{
		qCabosSel.Text = "";
		int num = 0;
		checked
		{
			int num2 = dgTag.RowCount - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (dgTag.Rows[i].Selected)
				{
					num++;
				}
			}
			if (num > 0)
			{
				qCabosSel.Text = num.ToString();
			}
		}
	}

	private void yMHPoMDEo3(object P_0, EventArgs P_1)
	{
		if (!Information.IsNothing(YwdPPR4f3p) && Information.UBound(YwdPPR4f3p) != 0)
		{
			string pag = DeclaracoesGeral.ativo.Pagina;
			d22P2Gb9BG.TamanhoFonte = 2.0;
			d22P2Gb9BG.QuantColunas = 1;
			d22P2Gb9BG.AlturaInicial = Conversions.ToDouble(tbOrdenadaY.Text);
			d22P2Gb9BG.sFonte = "ROMANS";
			d22P2Gb9BG.DistEntreColunas = 3.0;
			d22P2Gb9BG.AlturaDoBloco = 7.0;
			Relatorios_VeiasCopelDWG.CriaListaVeiasCOPEL(YwdPPR4f3p, d22P2Gb9BG, CBComprimento.Checked);
			Pagina.AtivaPagina(pag);
			DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
		}
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
			j2EPe1okWC = true;
			dgEquip.Rows.Clear();
			dgEquip.Columns.Clear();
			dgEquip.Columns.Add("", "#");
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
			j2EPe1okWC = false;
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
				j2EPe1okWC = false;
			}
		}
	}

	public void formataDGTag()
	{
		try
		{
			j2EPe1okWC = true;
			dgTag.Rows.Clear();
			dgTag.Columns.Clear();
			dgTag.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1238]));
			AtualizaDGTag();
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
			j2EPe1okWC = false;
		}
	}

	public void AtualizaDGTag()
	{
		checked
		{
			try
			{
				if (dgTag.RowCount != 0)
				{
					double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgTag)) ? ((double)(dgTag.Width - 4)) : ((double)(dgTag.Width - 22)));
					dgTag.Columns[0].Width = (int)Math.Round(a);
					lvcPhTfHcm();
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
				j2EPe1okWC = false;
			}
		}
	}

	public void formataDGVeias()
	{
		try
		{
			dgVeias.Rows.Clear();
			dgVeias.Columns.Clear();
			dgVeias.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 176]));
			dgVeias.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1285]));
			dgVeias.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1430]));
			dgVeias.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1239]));
			dgVeias.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1081]));
			dgVeias.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 518]));
			dgVeias.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1429]));
			dgVeias.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1243]));
			dgVeias.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1081]));
			dgVeias.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 518]));
			dgVeias.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1429]));
			dgVeias.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1243]));
			dgVeias.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 253]));
			dgVeias.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 9]));
			if (CBComprimento.Checked)
			{
				dgVeias.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1246]));
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
				if (dgVeias.RowCount != 0)
				{
					double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgVeias)) ? ((double)(dgVeias.Width - 10)) : ((double)(dgVeias.Width - 25)));
					dgVeias.Columns[0].Width = (int)Math.Round(num * 0.06);
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
					dgVeias.Columns[12].Width = (int)Math.Round(num * 0.137);
					dgVeias.Columns[13].Width = (int)Math.Round(num * 0.055);
					int num2 = 13;
					if (CBComprimento.Checked)
					{
						dgVeias.Columns[12].Width = (int)Math.Round(num * 0.1);
						dgVeias.Columns[13].Width = (int)Math.Round(num * 0.055);
						dgVeias.Columns[14].Width = (int)Math.Round(num * 0.037);
						dgVeias.Columns[14].Visible = true;
						num2 = 14;
					}
					int num3 = num2;
					for (int i = 0; i <= num3; i++)
					{
						dgVeias.Columns[i].Visible = true;
						dgVeias.Columns[i].ReadOnly = false;
					}
					dgVeias.MultiSelect = false;
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

	private void zRiPGFBn8n(object P_0, EventArgs P_1)
	{
		AtualizaDGRevisao();
		AtualizaDGEquip();
		AtualizaDGCabos();
	}

	private void AqDPHnSoRp(object P_0, EventArgs P_1)
	{
		formataDGVeias();
	}

	private void AdnPkt5dD6(object P_0, EventArgs P_1)
	{
		Relatorios_VeiasCopelDWG.ApagaRelatorioDeVeiasCopel("0");
	}

	private void O27PdaI6Aj(object P_0, EventArgs P_1)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected Obj, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Invalid comparison between Unknown and I4
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			DeclaracoesGeral.Reguas RH = default;
			XDataGeral.LeXDataReguaH(ref RH);
			_ = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			PromptPointResult val2 = (PromptPointResult)NewLateBinding.LateGet(editor, null, "GetPoint", new object[1] { Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 688]) }, null, null, null);
			if ((int)((PromptResult)val2).Status == -5002)
			{
				tbOrdenadaY.Text = Conversions.ToString(25);
			}
			else
			{
				TextBox textBox = tbOrdenadaY;
				double num = RH.Pti.Y;
				Point3d value = val2.Value;
				textBox.Text = Conversions.ToString(Math.Round(num - Math.Round(value.Y, 2), 2));
			}
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
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

	private void cbPPfsEg2W(object P_0, EventArgs P_1)
	{
		formataDGVeias();
	}
}
