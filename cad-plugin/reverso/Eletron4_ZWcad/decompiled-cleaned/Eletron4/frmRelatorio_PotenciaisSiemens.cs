using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmRelatorio_PotenciaisSiemens : Form
{
	private IContainer EdNaQBh7Bs;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("_2_dgRevisao")]
	private DataGridView xLnaPf9Hvj;

	[AccessedThroughProperty("_3_dgEquip")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView PHdacRsWqq;

	[AccessedThroughProperty("_5_dgFiacao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView Y1UaKoilKp;

	[AccessedThroughProperty("btPesquisar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button LJDaeQQAat;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("_1_dgDWG")]
	private DataGridView SKpa2e2XUu;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExportaSiemens")]
	private Button Nsia3JqtFZ;

	[AccessedThroughProperty("ToolTip1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolTip WnKan3d4IK;

	[AccessedThroughProperty("cbAlternativo")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox Mysa1meQXv;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox4")]
	private GroupBox IwEalllVN0;

	[AccessedThroughProperty("RB_Dispositivos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton H6Sa5HDs8m;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RB_Reguas")]
	private RadioButton MbPa07ToUq;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("_4_dgReguas")]
	private DataGridView rPkaRM04ZB;

	private DeclaracoesFiacao.structurePnRev[] eQramFH8Ft;

	private DeclaracoesFiacao.structureRevisoes[] fEIaXZhsJv;

	private DeclaracoesFiacao.structureAplicacao[] G6kaUKk615;

	private StructureBorneAplicacao[] X9Pay3FpJi;

	private DeclaracoesFiacao.StructureLinks[] qroagc8tNe;

	private int vETaAHHO4F;

	private string ACZasdbfBg;

	private int S1IaBhiUlR;

	private bool DohaVTwM96;

	private bool NXRauyiLbd;

	public DeclaracoesFiacao.structureRelPotencialSiemens[] mRelPotencialSiemens;

	public StructureBorneAplicacao[] mRelReguasSiemens;

	internal virtual DataGridView _2_dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return xLnaPf9Hvj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = HMtatwZckK;
			DataGridView dataGridView = xLnaPf9Hvj;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			xLnaPf9Hvj = value;
			dataGridView = xLnaPf9Hvj;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView _3_dgEquip
	{
		[CompilerGenerated]
		get
		{
			return PHdacRsWqq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = JKQaah831u;
			DataGridView dataGridView = PHdacRsWqq;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			PHdacRsWqq = value;
			dataGridView = PHdacRsWqq;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView _5_dgFiacao
	{
		[CompilerGenerated]
		get
		{
			return Y1UaKoilKp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Y1UaKoilKp = value;
		}
	}

	internal virtual Button btPesquisar
	{
		[CompilerGenerated]
		get
		{
			return LJDaeQQAat;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = emXaL00E1U;
			Button button = LJDaeQQAat;
			if (button != null)
			{
				button.Click -= value2;
			}
			LJDaeQQAat = value;
			button = LJDaeQQAat;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView _1_dgDWG
	{
		[CompilerGenerated]
		get
		{
			return SKpa2e2XUu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UfSaNnPLhQ;
			DataGridView dataGridView = SKpa2e2XUu;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			SKpa2e2XUu = value;
			dataGridView = SKpa2e2XUu;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual Button btExportaSiemens
	{
		[CompilerGenerated]
		get
		{
			return Nsia3JqtFZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = M8ea7jL55P;
			Button button = Nsia3JqtFZ;
			if (button != null)
			{
				button.Click -= value2;
			}
			Nsia3JqtFZ = value;
			button = Nsia3JqtFZ;
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
			return Mysa1meQXv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Mysa1meQXv = value;
		}
	}

	internal virtual GroupBox GroupBox4
	{
		[CompilerGenerated]
		get
		{
			return IwEalllVN0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			IwEalllVN0 = value;
		}
	}

	internal virtual RadioButton RB_Dispositivos
	{
		[CompilerGenerated]
		get
		{
			return H6Sa5HDs8m;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = GfYaqmt5B8;
			RadioButton radioButton = H6Sa5HDs8m;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			H6Sa5HDs8m = value;
			radioButton = H6Sa5HDs8m;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton RB_Reguas
	{
		[CompilerGenerated]
		get
		{
			return MbPa07ToUq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MbPa07ToUq = value;
		}
	}

	internal virtual DataGridView _4_dgReguas
	{
		[CompilerGenerated]
		get
		{
			return rPkaRM04ZB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rPkaRM04ZB = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && EdNaQBh7Bs != null)
			{
				EdNaQBh7Bs.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void dD9a6SO6gm()
	{
		EdNaQBh7Bs = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
		_2_dgRevisao = new DataGridView();
		_3_dgEquip = new DataGridView();
		_5_dgFiacao = new DataGridView();
		btPesquisar = new Button();
		_1_dgDWG = new DataGridView();
		btExportaSiemens = new Button();
		FDqpBiUmZij(new ToolTip(EdNaQBh7Bs));
		cbAlternativo = new CheckBox();
		GroupBox4 = new GroupBox();
		RB_Dispositivos = new RadioButton();
		RB_Reguas = new RadioButton();
		_4_dgReguas = new DataGridView();
		((ISupportInitialize)_2_dgRevisao).BeginInit();
		((ISupportInitialize)_3_dgEquip).BeginInit();
		((ISupportInitialize)_5_dgFiacao).BeginInit();
		((ISupportInitialize)_1_dgDWG).BeginInit();
		GroupBox4.SuspendLayout();
		((ISupportInitialize)_4_dgReguas).BeginInit();
		SuspendLayout();
		_2_dgRevisao.AllowUserToAddRows = false;
		_2_dgRevisao.AllowUserToDeleteRows = false;
		_2_dgRevisao.AllowUserToOrderColumns = true;
		_2_dgRevisao.AllowUserToResizeRows = false;
		_2_dgRevisao.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		_2_dgRevisao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		_2_dgRevisao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle2.BackColor = SystemColors.Window;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
		_2_dgRevisao.DefaultCellStyle = dataGridViewCellStyle2;
		_2_dgRevisao.EditMode = DataGridViewEditMode.EditProgrammatically;
		_2_dgRevisao.Location = new Point(12, 193);
		_2_dgRevisao.MultiSelect = false;
		_2_dgRevisao.Name = "_2_dgRevisao";
		_2_dgRevisao.ReadOnly = true;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		_2_dgRevisao.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
		_2_dgRevisao.RowHeadersVisible = false;
		_2_dgRevisao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		_2_dgRevisao.Size = new Size(260, 129);
		_2_dgRevisao.TabIndex = 3;
		_3_dgEquip.AllowUserToAddRows = false;
		_3_dgEquip.AllowUserToDeleteRows = false;
		_3_dgEquip.AllowUserToOrderColumns = true;
		_3_dgEquip.AllowUserToResizeRows = false;
		_3_dgEquip.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		_3_dgEquip.BackgroundColor = Color.White;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = SystemColors.Control;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		_3_dgEquip.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		_3_dgEquip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle5.BackColor = SystemColors.Window;
		dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
		_3_dgEquip.DefaultCellStyle = dataGridViewCellStyle5;
		_3_dgEquip.EditMode = DataGridViewEditMode.EditProgrammatically;
		_3_dgEquip.Location = new Point(12, 328);
		_3_dgEquip.MultiSelect = false;
		_3_dgEquip.Name = "_3_dgEquip";
		_3_dgEquip.ReadOnly = true;
		dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle6.BackColor = SystemColors.Control;
		dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
		_3_dgEquip.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
		_3_dgEquip.RowHeadersVisible = false;
		_3_dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		_3_dgEquip.Size = new Size(150, 131);
		_3_dgEquip.TabIndex = 8;
		_5_dgFiacao.AllowUserToAddRows = false;
		_5_dgFiacao.AllowUserToDeleteRows = false;
		_5_dgFiacao.AllowUserToResizeRows = false;
		_5_dgFiacao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		_5_dgFiacao.BackgroundColor = Color.White;
		dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle7.BackColor = SystemColors.Control;
		dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
		_5_dgFiacao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
		_5_dgFiacao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		_5_dgFiacao.EditMode = DataGridViewEditMode.EditProgrammatically;
		_5_dgFiacao.Location = new Point(277, 12);
		_5_dgFiacao.MultiSelect = false;
		_5_dgFiacao.Name = "_5_dgFiacao";
		_5_dgFiacao.ReadOnly = true;
		_5_dgFiacao.RowHeadersVisible = false;
		_5_dgFiacao.SelectionMode = DataGridViewSelectionMode.CellSelect;
		_5_dgFiacao.Size = new Size(756, 525);
		_5_dgFiacao.TabIndex = 11;
		btPesquisar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisar.FlatStyle = FlatStyle.Flat;
		btPesquisar.ForeColor = SystemColors.Control;
		btPesquisar.Image = Resources.Pesquisar_32;
		btPesquisar.Location = new Point(162, 17);
		btPesquisar.Name = "btPesquisar";
		btPesquisar.Size = new Size(40, 42);
		btPesquisar.TabIndex = 15;
		btPesquisar.UseVisualStyleBackColor = true;
		_1_dgDWG.AllowUserToAddRows = false;
		_1_dgDWG.AllowUserToDeleteRows = false;
		_1_dgDWG.AllowUserToOrderColumns = true;
		_1_dgDWG.AllowUserToResizeRows = false;
		_1_dgDWG.BackgroundColor = Color.White;
		dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle8.BackColor = SystemColors.Control;
		dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
		_1_dgDWG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
		_1_dgDWG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		_1_dgDWG.EditMode = DataGridViewEditMode.EditProgrammatically;
		_1_dgDWG.Location = new Point(12, 12);
		_1_dgDWG.MultiSelect = false;
		_1_dgDWG.Name = "_1_dgDWG";
		_1_dgDWG.ReadOnly = true;
		_1_dgDWG.RowHeadersVisible = false;
		_1_dgDWG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		_1_dgDWG.Size = new Size(260, 175);
		_1_dgDWG.TabIndex = 17;
		btExportaSiemens.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btExportaSiemens.FlatStyle = FlatStyle.Flat;
		btExportaSiemens.ForeColor = SystemColors.Control;
		btExportaSiemens.Image = Resources.ExportaExcel_20;
		btExportaSiemens.Location = new Point(208, 17);
		btExportaSiemens.Name = "btExportaSiemens";
		btExportaSiemens.Size = new Size(40, 42);
		btExportaSiemens.TabIndex = 41;
		btExportaSiemens.UseVisualStyleBackColor = true;
		cbAlternativo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		cbAlternativo.AutoSize = true;
		cbAlternativo.Location = new Point(20, 400);
		cbAlternativo.Name = "cbAlternativo";
		cbAlternativo.Size = new Size(76, 17);
		cbAlternativo.TabIndex = 42;
		cbAlternativo.Text = "Alternativo";
		cbAlternativo.UseVisualStyleBackColor = true;
		cbAlternativo.Visible = false;
		GroupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox4.Controls.Add(RB_Dispositivos);
		GroupBox4.Controls.Add(RB_Reguas);
		GroupBox4.Controls.Add(btPesquisar);
		GroupBox4.Controls.Add(btExportaSiemens);
		GroupBox4.Location = new Point(12, 466);
		GroupBox4.Name = "GroupBox4";
		GroupBox4.Size = new Size(259, 71);
		GroupBox4.TabIndex = 150;
		GroupBox4.TabStop = false;
		RB_Dispositivos.AutoSize = true;
		RB_Dispositivos.Checked = true;
		RB_Dispositivos.Location = new Point(13, 19);
		RB_Dispositivos.Name = "RB_Dispositivos";
		RB_Dispositivos.Size = new Size(90, 17);
		RB_Dispositivos.TabIndex = 0;
		RB_Dispositivos.TabStop = true;
		RB_Dispositivos.Text = "rbDispositivos";
		RB_Dispositivos.UseVisualStyleBackColor = true;
		RB_Reguas.AutoSize = true;
		RB_Reguas.Location = new Point(13, 42);
		RB_Reguas.Name = "RB_Reguas";
		RB_Reguas.Size = new Size(71, 17);
		RB_Reguas.TabIndex = 2;
		RB_Reguas.Text = "rbRéguas";
		RB_Reguas.UseVisualStyleBackColor = true;
		_4_dgReguas.AllowUserToAddRows = false;
		_4_dgReguas.AllowUserToDeleteRows = false;
		_4_dgReguas.AllowUserToOrderColumns = true;
		_4_dgReguas.AllowUserToResizeRows = false;
		_4_dgReguas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		_4_dgReguas.BackgroundColor = Color.White;
		dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle9.BackColor = SystemColors.Control;
		dataGridViewCellStyle9.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
		_4_dgReguas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
		_4_dgReguas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle10.BackColor = SystemColors.Window;
		dataGridViewCellStyle10.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle10.ForeColor = SystemColors.ControlText;
		dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
		_4_dgReguas.DefaultCellStyle = dataGridViewCellStyle10;
		_4_dgReguas.EditMode = DataGridViewEditMode.EditProgrammatically;
		_4_dgReguas.Location = new Point(167, 328);
		_4_dgReguas.MultiSelect = false;
		_4_dgReguas.Name = "_4_dgReguas";
		_4_dgReguas.ReadOnly = true;
		dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle11.BackColor = SystemColors.Control;
		dataGridViewCellStyle11.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		dataGridViewCellStyle11.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
		_4_dgReguas.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
		_4_dgReguas.RowHeadersVisible = false;
		_4_dgReguas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		_4_dgReguas.Size = new Size(105, 131);
		_4_dgReguas.TabIndex = 151;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(1045, 549);
		Controls.Add(_4_dgReguas);
		Controls.Add(GroupBox4);
		Controls.Add(cbAlternativo);
		Controls.Add(_1_dgDWG);
		Controls.Add(_5_dgFiacao);
		Controls.Add(_3_dgEquip);
		Controls.Add(_2_dgRevisao);
		MinimumSize = new Size(900, 550);
		Name = "frmRelatorio_PotenciaisSiemens";
		ShowInTaskbar = false;
		Text = "Relatório de Potenciais Siemens";
		((ISupportInitialize)_2_dgRevisao).EndInit();
		((ISupportInitialize)_3_dgEquip).EndInit();
		((ISupportInitialize)_5_dgFiacao).EndInit();
		((ISupportInitialize)_1_dgDWG).EndInit();
		GroupBox4.ResumeLayout(performLayout: false);
		GroupBox4.PerformLayout();
		((ISupportInitialize)_4_dgReguas).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return WnKan3d4IK;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		WnKan3d4IK = WithEventsValue;
	}

	public frmRelatorio_PotenciaisSiemens()
	{
		Resize += OD3aO7uKVZ;
		eQramFH8Ft = new DeclaracoesFiacao.structurePnRev[1];
		fEIaXZhsJv = new DeclaracoesFiacao.structureRevisoes[1];
		X9Pay3FpJi = new StructureBorneAplicacao[1];
		qroagc8tNe = new DeclaracoesFiacao.StructureLinks[1];
		vETaAHHO4F = 0;
		ACZasdbfBg = "";
		S1IaBhiUlR = 0;
		DohaVTwM96 = false;
		NXRauyiLbd = false;
		try
		{
			if (!Geral.ExisteForm("frmRelatorio_PotenciaisSiemens"))
			{
				dD9a6SO6gm();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1851]);
				cbAlternativo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 785]);
				w8dpBZ0kvSD().SetToolTip(btPesquisar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 775]));
				RB_Dispositivos.Text = "EQUIP EQUIP";
				RB_Reguas.Text = "BORNES";
				cDadosAccess.carregaDadosDWG();
				Application.ShowModelessDialog((Form)this);
				_1_formataDGDWG();
				_2_formataDGRevisao();
				_3_formataDGEquip();
				_4_formataDGReguas();
				_5_FormataDGFiacao();
				CarregaDGDWG();
				cbAlternativo.Checked = false;
				_1_AtualizaDGDWG();
				_2_AtualizaDGRevisao();
				_3_AtualizaDGEquip();
				_4_AtualizaDGReguas();
				if (RB_Dispositivos.Checked)
				{
					_5_AtualizaDGFiacao();
				}
				if (RB_Reguas.Checked)
				{
					_5_AtualizaDGTodasAsReguas();
				}
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

	private void HMtatwZckK(object P_0, EventArgs P_1)
	{
		NXRauyiLbd = true;
		_3_dgEquip.Rows.Clear();
		NXRauyiLbd = false;
		if (!DohaVTwM96)
		{
			O9qajL8wFx();
		}
	}

	private void O9qajL8wFx()
	{
		CarregaPnRev();
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (_2_dgRevisao.SelectedRows.Count == 1)
			{
				ACZasdbfBg = Conversions.ToString(_2_dgRevisao.SelectedRows[0].Cells[0].Value);
				NXRauyiLbd = true;
				_3_dgEquip.Rows.Clear();
				NXRauyiLbd = false;
				int num = Information.UBound(eQramFH8Ft);
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					if (Operators.CompareString(eQramFH8Ft[i].revisao, ACZasdbfBg, TextCompare: true) == 0)
					{
						_3_dgEquip.Rows.Add(eQramFH8Ft[i].painel, Dicionario.BuscaNomeDoPainel(eQramFH8Ft[i].painel));
					}
				}
			}
			_3_AtualizaDGEquip();
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
		eQramFH8Ft = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (Information.UBound(fEIaXZhsJv) > 0)
			{
				int num = Information.UBound(fEIaXZhsJv);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessFiacao2.CarregaPnRev(vETaAHHO4F, fEIaXZhsJv[i].revisao, ref eQramFH8Ft);
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

	private void emXaL00E1U(object P_0, EventArgs P_1)
	{
		btExportaSiemens.Enabled = false;
		if (RB_Dispositivos.Checked)
		{
			vdIaw6iMeT();
		}
		checked
		{
			if (RB_Reguas.Checked)
			{
				List<string> list = new List<string>();
				int num = _4_dgReguas.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (_4_dgReguas.Rows[i].Selected)
					{
						list.Add(Conversions.ToString(_4_dgReguas.Rows[i].Cells[0].Value));
					}
				}
				yhRabf13b4(list);
				RRvaFSkwF2(ref qroagc8tNe);
			}
			if (_5_dgFiacao.Rows.Count == 0)
			{
				_5_dgFiacao.Rows.Clear();
				_5_dgFiacao.Columns.Clear();
			}
			btExportaSiemens.Enabled = true;
		}
	}

	private void vdIaw6iMeT()
	{
		if (_3_dgEquip.SelectedRows.Count == 0)
		{
			return;
		}
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		_5_FormataDGFiacao();
		DicionarioAplicacao.carregaDicAplicacao();
		G6kaUKk615 = new DeclaracoesFiacao.structureAplicacao[1];
		DicionarioAplicacao.LeOsTiposDeAplicacoes(ref G6kaUKk615);
		if (_3_dgEquip.SelectedRows.Count == 0)
		{
			return;
		}
		S1IaBhiUlR = Conversions.ToInteger(_3_dgEquip.SelectedRows[0].Cells[0].Value);
		Relatorios_DistribuicaoPot.StructurePotenciais[] mPotenciais = new Relatorios_DistribuicaoPot.StructurePotenciais[1];
		cDadosAccessRelPot cDadosAccessRelPot2 = new cDadosAccessRelPot();
		try
		{
			cDadosAccessRelPot2.CarregaPotenciaisRelatorio(vETaAHHO4F, ACZasdbfBg, S1IaBhiUlR, ref mPotenciais);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		cDadosAccessRelPot2.fechaConexao();
		int num = 1;
		checked
		{
			try
			{
				int num2 = -1;
				string text = "";
				DeclaracoesFiacao.structurePotencial[] mPotencial = new DeclaracoesFiacao.structurePotencial[1];
				cDadosAccessFiacao2.CarregaPotenciaisPainel2(vETaAHHO4F, ACZasdbfBg, S1IaBhiUlR, ref mPotencial);
				if (Information.UBound(mPotencial) < 2)
				{
					return;
				}
				int num3 = 0;
				int num4 = Information.UBound(mPotencial);
				for (int i = 1; i <= num4; i++)
				{
					int potencial = mPotencial[i].Potencial;
					if (num3 == potencial)
					{
						string text2 = "";
						if (cbAlternativo.Checked)
						{
							text2 = ((Operators.CompareString(mPotencial[i - 1].Alternativo, "", TextCompare: true) != 0) ? mPotencial[i - 1].Alternativo : mPotencial[i - 1].Tag);
						}
						else
						{
							text2 = mPotencial[i - 1].Tag;
						}
						string text3 = "";
						text3 = ((Operators.CompareString(mPotencial[i - 1].NRegua, "", TextCompare: true) == 0) ? mPotencial[i - 1].Terminal : (mPotencial[i - 1].NRegua + ":" + mPotencial[i - 1].Terminal));
						string text4 = "";
						if (cbAlternativo.Checked)
						{
							text4 = ((Operators.CompareString(mPotencial[i].Alternativo, "", TextCompare: true) != 0) ? mPotencial[i].Alternativo : mPotencial[i].Tag);
						}
						else
						{
							text4 = mPotencial[i].Tag;
						}
						string text5 = "";
						text5 = ((Operators.CompareString(mPotencial[i].NRegua, "", TextCompare: true) == 0) ? mPotencial[i].Terminal : (mPotencial[i].NRegua + ":" + mPotencial[i].Terminal));
						string text6 = mPotencial[i].Secao;
						string text7 = mPotencial[i].Cor;
						bool flag = false;
						if ((mPotencial[i - 1].bLink & mPotencial[i].bLink) && mPotencial[i - 1].indexModelo == mPotencial[i].indexModelo && cDadosAccessFiacao2.BornesVizinhos(vETaAHHO4F, ACZasdbfBg, S1IaBhiUlR, mPotencial[i].indexModelo, mPotencial[i - 1].Terminal, mPotencial[i].Terminal))
						{
							text6 = "LINK";
							text7 = "";
							flag = true;
						}
						string pagina = mPotencial[i - 1].Pagina;
						string pagina2 = mPotencial[i].Pagina;
						string orientacao = mPotencial[i - 1].Orientacao;
						string orientacao2 = mPotencial[i].Orientacao;
						string text8 = "";
						if (DeclaracoesGeral.dicAplicacao.Count > 0 && DeclaracoesGeral.dicAplicacao.ContainsKey(mPotencial[i].Aplicacao))
						{
							text8 = DeclaracoesGeral.dicAplicacao[mPotencial[i].Aplicacao];
						}
						if (num2 != mPotencial[num].Potencial)
						{
							text = "";
							Relatorios_DistribuicaoPot.StructurePotenciais[] array = mPotenciais;
							for (int j = 0; j < array.Length; j++)
							{
								Relatorios_DistribuicaoPot.StructurePotenciais structurePotenciais = array[j];
								if (structurePotenciais.iPotencial == mPotencial[num].Potencial)
								{
									text = structurePotenciais.sNome;
									break;
								}
							}
						}
						_5_dgFiacao.Rows.Add(text2, text3, orientacao, text4, text5, orientacao2, text7, text6, "", "", text, text8, pagina + "; " + pagina2);
						ref DeclaracoesFiacao.structureRelPotencialSiemens[] reference = ref mRelPotencialSiemens;
						reference = (DeclaracoesFiacao.structureRelPotencialSiemens[])Utils.CopyArray(reference, new DeclaracoesFiacao.structureRelPotencialSiemens[num + 1]);
						mRelPotencialSiemens[num].tag1 = text2;
						mRelPotencialSiemens[num].term1 = text3;
						mRelPotencialSiemens[num].tag2 = text4;
						mRelPotencialSiemens[num].term2 = text5;
						mRelPotencialSiemens[num].secao = text6;
						mRelPotencialSiemens[num].cor = text7;
						mRelPotencialSiemens[num].pagina1 = pagina;
						mRelPotencialSiemens[num].pagina2 = pagina2;
						mRelPotencialSiemens[num].potencial = num3;
						mRelPotencialSiemens[num].ori1 = orientacao;
						mRelPotencialSiemens[num].ori2 = orientacao2;
						mRelPotencialSiemens[num].Aplicacao = text8;
						num++;
						if (flag)
						{
							_5_dgFiacao.Rows[_5_dgFiacao.Rows.Count - 1].Cells[4].Style.Font = new Font("Arial", 9f, FontStyle.Bold);
							_5_dgFiacao.Rows[_5_dgFiacao.Rows.Count - 1].Cells[4].Style.ForeColor = Color.DarkRed;
						}
					}
					else
					{
						num3 = potencial;
					}
				}
				_5_AtualizaDGFiacao();
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

	private void OIwaxZLC3Q()
	{
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		if (_3_dgEquip.SelectedRows.Count == 0)
		{
			return;
		}
		S1IaBhiUlR = Conversions.ToInteger(_3_dgEquip.SelectedRows[0].Cells[0].Value);
		try
		{
			X9Pay3FpJi = new StructureBorneAplicacao[1];
			mRelReguasSiemens = new StructureBorneAplicacao[1];
			new List<string>();
			_4_formataDGReguas();
			int dwgCorrente = vETaAHHO4F;
			string aCZasdbfBg = ACZasdbfBg;
			int s1IaBhiUlR = S1IaBhiUlR;
			DataGridView dg = _4_dgReguas;
			cDadosAccessFiacao2.CarregaTodasReguasDG(dwgCorrente, aCZasdbfBg, s1IaBhiUlR, ref dg);
			_4_dgReguas = dg;
			_4_AtualizaDGReguas();
			_5_AtualizaDGTodasAsReguas();
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

	private void yhRabf13b4(List<string> P_0)
	{
		if (_3_dgEquip.SelectedRows.Count == 0)
		{
			return;
		}
		_5_FormataDGReguas();
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		S1IaBhiUlR = Conversions.ToInteger(_3_dgEquip.SelectedRows[0].Cells[0].Value);
		int num = 1;
		checked
		{
			try
			{
				X9Pay3FpJi = new StructureBorneAplicacao[1];
				mRelReguasSiemens = new StructureBorneAplicacao[1];
				cDadosAccessFiacao2.CarregaPotenciaisReguas(vETaAHHO4F, ACZasdbfBg, S1IaBhiUlR, P_0, ref X9Pay3FpJi);
				StructureBorneAplicacao[] x9Pay3FpJi = (from X in X9Pay3FpJi
					orderby X.Regua, X.ordem
					select X).ToArray();
				X9Pay3FpJi = x9Pay3FpJi;
				if (Information.UBound(X9Pay3FpJi) < 1)
				{
					return;
				}
				int num2 = Information.UBound(X9Pay3FpJi);
				for (int num3 = 1; num3 <= num2; num3++)
				{
					if (P_0.Contains(X9Pay3FpJi[num3].Regua))
					{
						_5_dgFiacao.Rows.Add(X9Pay3FpJi[num3].Regua, X9Pay3FpJi[num3].Terminal, X9Pay3FpJi[num3].modelo, X9Pay3FpJi[num3].Fabricante);
						ref StructureBorneAplicacao[] reference = ref mRelReguasSiemens;
						reference = (StructureBorneAplicacao[])Utils.CopyArray(reference, new StructureBorneAplicacao[num + 1]);
						mRelReguasSiemens[num].Regua = X9Pay3FpJi[num3].Regua;
						mRelReguasSiemens[num].Terminal = X9Pay3FpJi[num3].Terminal;
						mRelReguasSiemens[num].modelo = X9Pay3FpJi[num3].modelo;
						mRelReguasSiemens[num].Fabricante = X9Pay3FpJi[num3].Fabricante;
						num++;
					}
				}
				_5_AtualizaDGTodasAsReguas();
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

	private string XJgaM65oll(string P_0, string P_1)
	{
		string text = "";
		text = ((Operators.CompareString(clsTextos.TiraNothing(P_0).Trim(), "", TextCompare: true) == 0) ? clsTextos.TiraNothing(P_0).Trim() : (P_0 + ":" + P_1));
		return text.Trim();
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
					_1_dgDWG.Rows.Add(mDWG[i].Indice, mDWG[i].Nome);
					if (DeclaracoesGeral.arqAtivo.Indice == mDWG[i].Indice)
					{
						_1_dgDWG.Rows[_1_dgDWG.Rows.Count - 1].Selected = true;
					}
				}
				_1_AtualizaDGDWG();
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

	private void OD3aO7uKVZ(object P_0, EventArgs P_1)
	{
		NOuaIeBAwI();
	}

	private void NOuaIeBAwI()
	{
		_5_AtualizaDGFiacao();
		_5_AtualizaDGTodasAsReguas();
	}

	private void M8ea7jL55P(object P_0, EventArgs P_1)
	{
		if (_5_dgFiacao.Rows.Count == 0)
		{
			return;
		}
		btExportaSiemens.Enabled = false;
		if (!RB_Dispositivos.Checked)
		{
			if (RB_Reguas.Checked)
			{
				Relatorios_PotenciaisEXCELSiemens.ExportaReguasSiemensEXCEL(mRelReguasSiemens);
				Relatorios_PotenciaisEXCELSiemens.ExportaLinksSiemensEXCEL(qroagc8tNe);
			}
		}
		else
		{
			string sPainel = Dicionario.BuscaNomeDoPainel(S1IaBhiUlR);
			string local = DeclaracoesGeral.Conf.Local;
			Relatorios_PotenciaisEXCELSiemens.ExportaPotenciaisSiemensEXCEL(mRelPotencialSiemens, G6kaUKk615, local, sPainel);
		}
		btExportaSiemens.Enabled = true;
	}

	private void GfYaqmt5B8(object P_0, EventArgs P_1)
	{
		btExportaSiemens.Enabled = RB_Dispositivos.Checked;
		if (RB_Dispositivos.Checked)
		{
			_3_dgEquip.Size = new Size(260, _3_dgEquip.Height);
			_4_dgReguas.Visible = false;
			_3_AtualizaDGEquip();
			_5_dgFiacao.Rows.Clear();
			_5_dgFiacao.Columns.Clear();
		}
		if (RB_Reguas.Checked)
		{
			OIwaxZLC3Q();
			_3_dgEquip.Size = new Size(150, _3_dgEquip.Height);
			_4_dgReguas.Visible = true;
			_3_AtualizaDGEquip();
			_4_AtualizaDGReguas();
			_5_dgFiacao.Rows.Clear();
			_5_dgFiacao.Columns.Clear();
		}
	}

	private void JKQaah831u(object P_0, EventArgs P_1)
	{
		btExportaSiemens.Enabled = RB_Dispositivos.Checked;
		if (RB_Dispositivos.Checked)
		{
			_5_dgFiacao.Rows.Clear();
			_5_dgFiacao.Columns.Clear();
		}
		if (RB_Reguas.Checked)
		{
			_4_formataDGReguas();
			OIwaxZLC3Q();
			_5_dgFiacao.Rows.Clear();
			_5_dgFiacao.Columns.Clear();
		}
	}

	private void SLta8qweeL()
	{
		vETaAHHO4F = Conversions.ToInteger(_1_dgDWG.SelectedRows[0].Cells[0].Value);
		fEIaXZhsJv = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			cDadosAccessFiacao2.CarregaRevisoesDwgCorrente(vETaAHHO4F, ref fEIaXZhsJv);
			DohaVTwM96 = true;
			_2_dgRevisao.Rows.Clear();
			DohaVTwM96 = false;
			int num = Information.UBound(fEIaXZhsJv);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				_2_dgRevisao.Rows.Add(fEIaXZhsJv[i].revisao);
			}
			_2_AtualizaDGRevisao();
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

	private void UfSaNnPLhQ(object P_0, EventArgs P_1)
	{
		DohaVTwM96 = true;
		_2_dgRevisao.Rows.Clear();
		DohaVTwM96 = false;
		NXRauyiLbd = true;
		_3_dgEquip.Rows.Clear();
		NXRauyiLbd = false;
		SLta8qweeL();
	}

	public void _1_formataDGDWG()
	{
		try
		{
			_1_dgDWG.Rows.Clear();
			_1_dgDWG.Columns.Clear();
			_1_dgDWG.Columns.Add("", "DWG");
			_1_dgDWG.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 786]));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void _2_formataDGRevisao()
	{
		try
		{
			_2_dgRevisao.Rows.Clear();
			_2_dgRevisao.Columns.Clear();
			_2_dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 752]));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void _3_formataDGEquip()
	{
		checked
		{
			try
			{
				NXRauyiLbd = true;
				_3_dgEquip.Rows.Clear();
				_3_dgEquip.Columns.Clear();
				_3_dgEquip.Columns.Add("", "Indice");
				_3_dgEquip.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 748]));
				int num = _3_dgEquip.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					_3_dgEquip.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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
				NXRauyiLbd = false;
			}
		}
	}

	public void _4_formataDGReguas()
	{
		try
		{
			_4_dgReguas.Rows.Clear();
			_4_dgReguas.Columns.Clear();
			_4_dgReguas.Columns.Add("", DeclaracoesGeral.mMensagem[1, 984].ToString());
			_4_dgReguas.Columns.Add("", "#");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void _5_FormataDGFiacao()
	{
		checked
		{
			try
			{
				_5_dgFiacao.Rows.Clear();
				_5_dgFiacao.Columns.Clear();
				_5_dgFiacao.Columns.Add("", "EQUIP");
				_5_dgFiacao.Columns.Add("", "PINO");
				_5_dgFiacao.Columns.Add("", "Dir.");
				_5_dgFiacao.Columns.Add("", "EQUIP2");
				_5_dgFiacao.Columns.Add("", "PINO2");
				_5_dgFiacao.Columns.Add("", "Dir.2");
				_5_dgFiacao.Columns.Add("", "COR");
				_5_dgFiacao.Columns.Add("", "BITOLA");
				_5_dgFiacao.Columns.Add("", "ROUTING");
				_5_dgFiacao.Columns.Add("", "PADRÃO");
				_5_dgFiacao.Columns.Add("", "POTENCIAL");
				_5_dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1623]));
				_5_dgFiacao.Columns.Add("", "PÁGINA");
				int num = _5_dgFiacao.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					_5_dgFiacao.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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

	public void _5_FormataDGReguas()
	{
		checked
		{
			try
			{
				_5_dgFiacao.Rows.Clear();
				_5_dgFiacao.Columns.Clear();
				_5_dgFiacao.Columns.Add("", DeclaracoesGeral.mMensagem[1, 984].ToString().ToUpper());
				_5_dgFiacao.Columns.Add("", DeclaracoesGeral.mMensagem[1, 771].ToString().ToUpper());
				_5_dgFiacao.Columns.Add("", DeclaracoesGeral.mMensagem[1, 808].ToString().ToUpper());
				_5_dgFiacao.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1169].ToString().ToUpper());
				int num = _5_dgFiacao.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					_5_dgFiacao.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				_5_AtualizaDGFiacao();
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

	public void _1_AtualizaDGDWG()
	{
		checked
		{
			try
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(_1_dgDWG)) ? ((double)(_1_dgDWG.Width - 4)) : ((double)(_1_dgDWG.Width - 21)));
				_1_dgDWG.Columns[0].Width = (int)Math.Round(num * 0.2);
				_1_dgDWG.Columns[1].Width = (int)Math.Round(num * 0.8);
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

	public void _2_AtualizaDGRevisao()
	{
		checked
		{
			try
			{
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(_2_dgRevisao)) ? ((double)(_2_dgRevisao.Width - 4)) : ((double)(_2_dgRevisao.Width - 21)));
				_2_dgRevisao.Columns[0].Width = (int)Math.Round(a);
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

	public void _3_AtualizaDGEquip()
	{
		checked
		{
			try
			{
				if (_3_dgEquip.RowCount != 0)
				{
					double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(_3_dgEquip)) ? ((double)(_3_dgEquip.Width - 4)) : ((double)(_3_dgEquip.Width - 21)));
					_3_dgEquip.Columns[0].Width = 0;
					_3_dgEquip.Columns[0].Visible = false;
					_3_dgEquip.Columns[1].Width = (int)Math.Round(a);
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
				NXRauyiLbd = false;
			}
		}
	}

	public void _4_AtualizaDGReguas()
	{
		checked
		{
			try
			{
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(_4_dgReguas)) ? ((double)(_4_dgReguas.Width - 4)) : ((double)(_4_dgReguas.Width - 21)));
				_4_dgReguas.Columns[0].Width = (int)Math.Round(a);
				_4_dgReguas.Columns[1].Width = 0;
				_4_dgReguas.Columns[0].Visible = true;
				_4_dgReguas.Columns[1].Visible = false;
				_4_dgReguas.MultiSelect = true;
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

	public void _5_AtualizaDGFiacao()
	{
		checked
		{
			try
			{
				if (RB_Dispositivos.Checked && _5_dgFiacao.RowCount != 0)
				{
					double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(_5_dgFiacao)) ? ((double)(_5_dgFiacao.Width - 4)) : ((double)(_5_dgFiacao.Width - 22)));
					int num2 = _5_dgFiacao.Columns.Count - 1;
					for (int i = 0; i <= num2; i++)
					{
						_5_dgFiacao.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
					}
					_5_dgFiacao.Columns[0].Width = (int)Math.Round(num * 0.085);
					_5_dgFiacao.Columns[1].Width = (int)Math.Round(num * 0.068);
					_5_dgFiacao.Columns[2].Width = (int)Math.Round(num * 0.059);
					_5_dgFiacao.Columns[3].Width = (int)Math.Round(num * 0.085);
					_5_dgFiacao.Columns[4].Width = (int)Math.Round(num * 0.068);
					_5_dgFiacao.Columns[5].Width = (int)Math.Round(num * 0.059);
					_5_dgFiacao.Columns[6].Width = (int)Math.Round(num * 0.059);
					_5_dgFiacao.Columns[7].Width = (int)Math.Round(num * 0.059);
					_5_dgFiacao.Columns[8].Width = (int)Math.Round(num * 0.068);
					_5_dgFiacao.Columns[9].Width = (int)Math.Round(num * 0.068);
					_5_dgFiacao.Columns[10].Width = (int)Math.Round(num * 0.118);
					_5_dgFiacao.Columns[11].Width = (int)Math.Round(num * 0.136);
					_5_dgFiacao.Columns[12].Width = (int)Math.Round(num * 0.068);
					int num3 = _5_dgFiacao.Columns.Count - 1;
					for (int j = 0; j <= num3; j++)
					{
						_5_dgFiacao.Columns[j].Visible = true;
						_5_dgFiacao.Columns[j].ReadOnly = false;
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

	public void _5_AtualizaDGTodasAsReguas()
	{
		checked
		{
			try
			{
				if (RB_Reguas.Checked && _5_dgFiacao.RowCount != 0)
				{
					double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(_5_dgFiacao)) ? ((double)(_5_dgFiacao.Width - 4)) : ((double)(_5_dgFiacao.Width - 22)));
					int num2 = _5_dgFiacao.Columns.Count - 1;
					for (int i = 0; i <= num2; i++)
					{
						_5_dgFiacao.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
					}
					_5_dgFiacao.Columns[0].Width = (int)Math.Round(num * 0.25);
					_5_dgFiacao.Columns[1].Width = (int)Math.Round(num * 0.25);
					_5_dgFiacao.Columns[2].Width = (int)Math.Round(num * 0.25);
					_5_dgFiacao.Columns[3].Width = (int)Math.Round(num * 0.25);
					int num3 = _5_dgFiacao.Columns.Count - 1;
					for (int j = 0; j <= num3; j++)
					{
						_5_dgFiacao.Columns[j].Visible = true;
						_5_dgFiacao.Columns[j].ReadOnly = false;
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

	private void RRvaFSkwF2(ref DeclaracoesFiacao.StructureLinks[] P_0)
	{
		int num = 0;
		P_0 = new DeclaracoesFiacao.StructureLinks[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		clsLM.LModFab[] mModFab = null;
		checked
		{
			try
			{
				DeclaracoesGeral._uscPagina.Quantidade = _4_dgReguas.RowCount - 1;
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num2 = _4_dgReguas.RowCount - 1;
				for (int i = 0; i <= num2; i++)
				{
					DeclaracoesGeral._uscPagina.pbPasso();
					if (!_4_dgReguas.Rows[i].Selected)
					{
						continue;
					}
					string text = Conversions.ToString(_4_dgReguas.Rows[i].Cells[0].Value);
					string tipo = "B";
					int indexRegua = Conversions.ToInteger(_4_dgReguas.Rows[i].Cells[1].Value);
					DeclaracoesFiacao.structureFiacao[] mfiacao = new DeclaracoesFiacao.structureFiacao[1];
					mfiacao[0].Lig = new DeclaracoesFiacao.structureLigacao[1];
					DeclaracoesFiacao.structureLinkSiemens[] mLinks = new DeclaracoesFiacao.structureLinkSiemens[1];
					cDadosAccessFiacao2.CarregaTerminaisRegua(vETaAHHO4F, ACZasdbfBg, S1IaBhiUlR, indexRegua, ref mfiacao, bIncuiPG: true);
					cDadosLM cDadosLM2 = new cDadosLM();
					cDadosLM2.buscaListaDeFabricanteDoMaterial(ref mModFab);
					cDadosLM2.fechaConexao();
					cDadosAccessFiacao2.CarregaLigacoesTerminalSIEMENS(vETaAHHO4F, ACZasdbfBg, S1IaBhiUlR, text, tipo, ref mfiacao, ref mLinks);
					string left = verificaTipoDosBornes(ref mLinks);
					if (Operators.CompareString(left, "N", TextCompare: true) != 0)
					{
						if (Operators.CompareString(left, "NL", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left, "A", TextCompare: true) == 0)
							{
								OrdenarAZ(ref mLinks);
							}
						}
						else
						{
							OrdenarNumAZ(ref mLinks);
						}
					}
					else
					{
						OrdenarAZ(ref mLinks);
					}
					DeclaracoesFiacao.structureLinkSiemens[] array = mLinks;
					for (int j = 0; j < array.Length; j++)
					{
						DeclaracoesFiacao.structureLinkSiemens structureLinkSiemens = array[j];
						if (Operators.CompareString(clsTextos.TiraNothing(structureLinkSiemens.borne), "", TextCompare: true) != 0 && Operators.CompareString(structureLinkSiemens.Regua, text, TextCompare: true) == 0)
						{
							if (!(structureLinkSiemens.bDown & !structureLinkSiemens.bUp))
							{
								P_0[num].sBorne2 = structureLinkSiemens.borne;
								P_0[num].iQuant++;
								continue;
							}
							num++;
							P_0 = (DeclaracoesFiacao.StructureLinks[])Utils.CopyArray(P_0, new DeclaracoesFiacao.StructureLinks[num + 1]);
							P_0[num].sRegua = structureLinkSiemens.Regua;
							P_0[num].iQuant = 1;
							P_0[num].sBorne1 = structureLinkSiemens.borne;
							P_0[num].sModelo = Conversions.ToString(structureLinkSiemens.iRegua);
						}
					}
				}
				int num3 = Information.UBound(P_0);
				for (int k = 1; k <= num3; k++)
				{
					clsLM.LModFab[] array2 = mModFab;
					for (int l = 0; l < array2.Length; l++)
					{
						clsLM.LModFab lModFab = array2[l];
						if (Operators.CompareString(lModFab.indice.ToString(), P_0[k].sModelo, TextCompare: true) == 0)
						{
							P_0[k].sModelo = lModFab.Modelo;
							break;
						}
					}
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
		}
	}

	public string verificaTipoDosBornes(ref DeclaracoesFiacao.structureLinkSiemens[] mLinks)
	{
		string text = "N";
		int num = Information.UBound(mLinks);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				string text2 = mLinks[i].borne;
				if (Operators.CompareString(text2, "?", TextCompare: true) == 0)
				{
					text2 = Conversions.ToString(0);
				}
				if (Versioned.IsNumeric(text2))
				{
					continue;
				}
				string expression = Strings.Mid(text2, 1, Strings.Len(text2) - 1);
				if (Versioned.IsNumeric(expression) & (Operators.CompareString(text, "A", TextCompare: true) != 0))
				{
					string text3 = Strings.Mid(text2, Strings.Len(text2), 1);
					if ((((Strings.Asc(text3) >= 48) & (Strings.Asc(text3) <= 57)) | ((Strings.Asc(text3) >= 65) & (Strings.Asc(text3) <= 90))) & (Operators.CompareString(text, "A", TextCompare: true) != 0))
					{
						text = "NL";
					}
				}
				if (!Versioned.IsNumeric(Strings.Mid(text2, 1, Strings.Len(text2) - 1)) & !Versioned.IsNumeric(Strings.Mid(text2, Strings.Len(text2), 1)))
				{
					text = "A";
				}
			}
			return text;
		}
	}

	public void OrdenarAZ(ref DeclaracoesFiacao.structureLinkSiemens[] mLinks)
	{
		checked
		{
			if (Information.UBound(mLinks) > 0)
			{
				int num = Information.UBound(mLinks);
				for (int i = 1; i <= num; i++)
				{
					int num2 = Information.UBound(mLinks) - 1;
					int num3 = i;
					for (int j = num2; j >= num3; j += -1)
					{
						if (Operators.CompareString(mLinks[j].Regua, mLinks[j + 1].Regua, TextCompare: true) > 0)
						{
							DeclaracoesFiacao.structureLinkSiemens structureLinkSiemens = mLinks[j + 1];
							mLinks[j + 1] = mLinks[j];
							mLinks[j] = structureLinkSiemens;
						}
						if (Operators.CompareString(mLinks[j].Regua, mLinks[j + 1].Regua, TextCompare: true) == 0 && Conversions.ToDouble(mLinks[j].borne) > Conversions.ToDouble(mLinks[j + 1].borne))
						{
							DeclaracoesFiacao.structureLinkSiemens structureLinkSiemens = mLinks[j + 1];
							mLinks[j + 1] = mLinks[j];
							mLinks[j] = structureLinkSiemens;
						}
					}
				}
			}
			int num4 = Information.UBound(mLinks);
			for (int k = 1; k <= num4; k++)
			{
				mLinks[k].iOrdem = k;
			}
		}
	}

	public void OrdenarNumAZ(ref DeclaracoesFiacao.structureLinkSiemens[] mLinks)
	{
		checked
		{
			if (Information.UBound(mLinks) > 0)
			{
				int num = Information.UBound(mLinks);
				for (int i = 1; i <= num; i++)
				{
					string borne = mLinks[i].borne;
					if (!(Versioned.IsNumeric(Strings.Mid(borne, 1, borne.Length - 1)) & (Strings.Asc(Strings.Mid(borne, borne.Length, 1)) >= 65) & (Strings.Asc(Strings.Mid(borne, borne.Length, 1)) <= 90)))
					{
						if (!(Versioned.IsNumeric(Strings.Mid(borne, 1, borne.Length - 1)) & (Strings.Asc(Strings.Mid(borne, borne.Length, 1)) >= 97) & (Strings.Asc(Strings.Mid(borne, borne.Length, 1)) <= 122)))
						{
							mLinks[i].sOrdem = borne;
							continue;
						}
						double num2 = Conversions.ToDouble(Strings.Mid(borne, 1, borne.Length - 1));
						borne = borne.ToUpper();
						num2 += (double)Strings.Asc(Strings.Mid(borne, borne.Length, 1)) / 101.0;
						mLinks[i].sOrdem = Conversions.ToString(num2);
					}
					else
					{
						double num3 = Conversions.ToDouble(Strings.Mid(borne, 1, borne.Length - 1));
						num3 += (double)Strings.Asc(Strings.Mid(borne, borne.Length, 1)) / 100.0;
						mLinks[i].sOrdem = Conversions.ToString(num3);
					}
				}
				int num4 = Information.UBound(mLinks);
				for (int j = 1; j <= num4; j++)
				{
					int num5 = Information.UBound(mLinks) - 1;
					int num6 = j;
					for (int k = num5; k >= num6; k += -1)
					{
						string text = mLinks[k].sOrdem;
						string text2 = mLinks[k + 1].sOrdem;
						if (Operators.CompareString(text, "?", TextCompare: true) == 0)
						{
							text = Conversions.ToString(0);
						}
						if (Operators.CompareString(text2, "?", TextCompare: true) == 0)
						{
							text2 = Conversions.ToString(0);
						}
						if (!(Versioned.IsNumeric(text) & Versioned.IsNumeric(text2)))
						{
							if (Operators.CompareString(text, text2, TextCompare: true) > 0)
							{
								DeclaracoesFiacao.structureLinkSiemens structureLinkSiemens = mLinks[k + 1];
								mLinks[k + 1] = mLinks[k];
								mLinks[k] = structureLinkSiemens;
							}
						}
						else if (Conversions.ToDouble(text) > Conversions.ToDouble(text2))
						{
							DeclaracoesFiacao.structureLinkSiemens structureLinkSiemens = mLinks[k + 1];
							mLinks[k + 1] = mLinks[k];
							mLinks[k] = structureLinkSiemens;
						}
					}
					DeclaracoesGeral._uscPagina.pbPasso();
				}
			}
			int num7 = Information.UBound(mLinks);
			for (int l = 1; l <= num7; l++)
			{
				mLinks[l].iOrdem = l;
				mLinks[l].sOrdem = Conversions.ToString(l);
			}
		}
	}
}
