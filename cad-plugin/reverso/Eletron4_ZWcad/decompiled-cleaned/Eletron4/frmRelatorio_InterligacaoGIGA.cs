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
public class frmRelatorio_InterligacaoGIGA : Form
{
	private IContainer AkUqgCTHOH;

	[AccessedThroughProperty("dgRevisao")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView xI3qAnM8xQ;

	[AccessedThroughProperty("dgEquip")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView PaGqsnJXS4;

	[AccessedThroughProperty("dgVeias")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView HN1qB1gF90;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btPesquisar")]
	private Button u2QqVmEmrn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExportaEXCEL")]
	private Button zySquPoJpX;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip hLsqEU8Ykk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("qTotal")]
	private Label rsXqZNNELs;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgEquip2")]
	private DataGridView cEfqiwK3Eq;

	[AccessedThroughProperty("LbFiltro")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label z38qSt5qRf;

	[AccessedThroughProperty("TBPesquisa")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox ddZq4mJUt6;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LbFiltro1")]
	[CompilerGenerated]
	private Label WpsqCXlNJ0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBPesquisa2")]
	[CompilerGenerated]
	private TextBox F0iqYS0b7B;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgCor")]
	private DataGridView PH9qr7qRxZ;

	[AccessedThroughProperty("tbNumCabo")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox NEQq9FljHf;

	[CompilerGenerated]
	[AccessedThroughProperty("btColar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button USKqzdGg6B;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbCor")]
	private TextBox u0aaWIbWbX;

	[AccessedThroughProperty("BTAdicionaCor")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button oWqapdUjS6;

	[AccessedThroughProperty("BTApagaCor")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button TUsaTnStNb;

	[CompilerGenerated]
	[AccessedThroughProperty("lbCabo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label dLBaJ6yObF;

	private DeclaracoesFiacao.structurePnRev[] cytahUkjpN;

	private DeclaracoesFiacao.structureRevisoes[] h7Oao2OtHp;

	private clsVeias.StructureVeiasgIGA[] C3IaG3WtKH;

	private clsVeias.InterGIGA[] S5oaHJDW3I;

	private string RKTak1viFY;

	private bool F7hadLNwUy;

	private bool F60afw5jsd;

	private string GMCaDe1EIk;

	private string exjavQkbLv;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return xI3qAnM8xQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = a5OqP7NxNT;
			DataGridView dataGridView = xI3qAnM8xQ;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			xI3qAnM8xQ = value;
			dataGridView = xI3qAnM8xQ;
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
			return PaGqsnJXS4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SF0qlFU3ns;
			KeyEventHandler value3 = bWnq5uOT3Z;
			MouseEventHandler value4 = pRkq01k74Y;
			DataGridView dataGridView = PaGqsnJXS4;
			if (dataGridView != null)
			{
				dataGridView.SizeChanged -= value2;
				dataGridView.KeyUp -= value3;
				dataGridView.MouseUp -= value4;
			}
			PaGqsnJXS4 = value;
			dataGridView = PaGqsnJXS4;
			if (dataGridView != null)
			{
				dataGridView.SizeChanged += value2;
				dataGridView.KeyUp += value3;
				dataGridView.MouseUp += value4;
			}
		}
	}

	internal virtual DataGridView dgVeias
	{
		[CompilerGenerated]
		get
		{
			return HN1qB1gF90;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			HN1qB1gF90 = value;
		}
	}

	internal virtual Button btPesquisar
	{
		[CompilerGenerated]
		get
		{
			return u2QqVmEmrn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AnHqe18H0i;
			Button button = u2QqVmEmrn;
			if (button != null)
			{
				button.Click -= value2;
			}
			u2QqVmEmrn = value;
			button = u2QqVmEmrn;
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
			return zySquPoJpX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VAfq2ICA35;
			Button button = zySquPoJpX;
			if (button != null)
			{
				button.Click -= value2;
			}
			zySquPoJpX = value;
			button = zySquPoJpX;
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
			return rsXqZNNELs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rsXqZNNELs = value;
		}
	}

	internal virtual DataGridView dgEquip2
	{
		[CompilerGenerated]
		get
		{
			return cEfqiwK3Eq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			cEfqiwK3Eq = value;
		}
	}

	internal virtual Label LbFiltro
	{
		[CompilerGenerated]
		get
		{
			return z38qSt5qRf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			z38qSt5qRf = value;
		}
	}

	internal virtual TextBox TBPesquisa
	{
		[CompilerGenerated]
		get
		{
			return ddZq4mJUt6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = AEUqc1hAcL;
			TextBox textBox = ddZq4mJUt6;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			ddZq4mJUt6 = value;
			textBox = ddZq4mJUt6;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Label LbFiltro1
	{
		[CompilerGenerated]
		get
		{
			return WpsqCXlNJ0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			WpsqCXlNJ0 = value;
		}
	}

	internal virtual TextBox TBPesquisa2
	{
		[CompilerGenerated]
		get
		{
			return F0iqYS0b7B;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = F7LqnBD068;
			TextBox textBox = F0iqYS0b7B;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			F0iqYS0b7B = value;
			textBox = F0iqYS0b7B;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual DataGridView dgCor
	{
		[CompilerGenerated]
		get
		{
			return PH9qr7qRxZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PH9qr7qRxZ = value;
		}
	}

	internal virtual TextBox tbNumCabo
	{
		[CompilerGenerated]
		get
		{
			return NEQq9FljHf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			NEQq9FljHf = value;
		}
	}

	internal virtual Button btColar
	{
		[CompilerGenerated]
		get
		{
			return USKqzdGg6B;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = lCWqRd8XEj;
			Button button = USKqzdGg6B;
			if (button != null)
			{
				button.Click -= value2;
			}
			USKqzdGg6B = value;
			button = USKqzdGg6B;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbCor
	{
		[CompilerGenerated]
		get
		{
			return u0aaWIbWbX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			u0aaWIbWbX = value;
		}
	}

	internal virtual Button BTAdicionaCor
	{
		[CompilerGenerated]
		get
		{
			return oWqapdUjS6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = lqyqmToTOH;
			Button button = oWqapdUjS6;
			if (button != null)
			{
				button.Click -= value2;
			}
			oWqapdUjS6 = value;
			button = oWqapdUjS6;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTApagaCor
	{
		[CompilerGenerated]
		get
		{
			return TUsaTnStNb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = lnCqXJvBop;
			Button button = TUsaTnStNb;
			if (button != null)
			{
				button.Click -= value2;
			}
			TUsaTnStNb = value;
			button = TUsaTnStNb;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label lbCabo
	{
		[CompilerGenerated]
		get
		{
			return dLBaJ6yObF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dLBaJ6yObF = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && AkUqgCTHOH != null)
			{
				AkUqgCTHOH.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void SAjqFc5goN()
	{
		AkUqgCTHOH = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		dgRevisao = new DataGridView();
		dgEquip = new DataGridView();
		dgVeias = new DataGridView();
		btPesquisar = new Button();
		btExportaEXCEL = new Button();
		FDqpBiUmZij(new ToolTip(AkUqgCTHOH));
		qTotal = new Label();
		dgEquip2 = new DataGridView();
		LbFiltro = new Label();
		TBPesquisa = new TextBox();
		LbFiltro1 = new Label();
		TBPesquisa2 = new TextBox();
		dgCor = new DataGridView();
		tbNumCabo = new TextBox();
		btColar = new Button();
		tbCor = new TextBox();
		BTAdicionaCor = new Button();
		BTApagaCor = new Button();
		lbCabo = new Label();
		((ISupportInitialize)dgRevisao).BeginInit();
		((ISupportInitialize)dgEquip).BeginInit();
		((ISupportInitialize)dgVeias).BeginInit();
		((ISupportInitialize)dgEquip2).BeginInit();
		((ISupportInitialize)dgCor).BeginInit();
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
		dgRevisao.Size = new Size(191, 162);
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
		dgEquip.Location = new Point(12, 207);
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(167, 172);
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
		dgVeias.Location = new Point(360, 12);
		dgVeias.MultiSelect = false;
		dgVeias.Name = "dgVeias";
		dgVeias.ReadOnly = true;
		dgVeias.RowHeadersVisible = false;
		dgVeias.SelectionMode = DataGridViewSelectionMode.CellSelect;
		dgVeias.Size = new Size(412, 367);
		dgVeias.TabIndex = 11;
		btPesquisar.FlatStyle = FlatStyle.Flat;
		btPesquisar.ForeColor = SystemColors.Control;
		btPesquisar.Image = Resources.Pesquisar_32;
		btPesquisar.Location = new Point(262, 382);
		btPesquisar.Name = "btPesquisar";
		btPesquisar.Size = new Size(40, 42);
		btPesquisar.TabIndex = 15;
		btPesquisar.UseVisualStyleBackColor = true;
		btExportaEXCEL.FlatStyle = FlatStyle.Flat;
		btExportaEXCEL.ForeColor = SystemColors.Control;
		btExportaEXCEL.Image = Resources.ExportaExcel_20;
		btExportaEXCEL.Location = new Point(312, 382);
		btExportaEXCEL.Name = "btExportaEXCEL";
		btExportaEXCEL.Size = new Size(40, 42);
		btExportaEXCEL.TabIndex = 41;
		btExportaEXCEL.UseVisualStyleBackColor = true;
		qTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		qTotal.BorderStyle = BorderStyle.Fixed3D;
		qTotal.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
		qTotal.Location = new Point(550, 385);
		qTotal.Name = "qTotal";
		qTotal.Size = new Size(222, 22);
		qTotal.TabIndex = 182;
		qTotal.Text = "Tot";
		qTotal.TextAlign = ContentAlignment.MiddleCenter;
		dgEquip2.AllowUserToAddRows = false;
		dgEquip2.AllowUserToDeleteRows = false;
		dgEquip2.AllowUserToOrderColumns = true;
		dgEquip2.AllowUserToResizeRows = false;
		dgEquip2.BackgroundColor = Color.White;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = SystemColors.Control;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		dgEquip2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		dgEquip2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgEquip2.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgEquip2.Location = new Point(187, 207);
		dgEquip2.Name = "dgEquip2";
		dgEquip2.ReadOnly = true;
		dgEquip2.RowHeadersVisible = false;
		dgEquip2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip2.Size = new Size(167, 172);
		dgEquip2.TabIndex = 189;
		LbFiltro.BorderStyle = BorderStyle.Fixed3D;
		LbFiltro.Location = new Point(12, 184);
		LbFiltro.Name = "LbFiltro";
		LbFiltro.Size = new Size(70, 20);
		LbFiltro.TabIndex = 191;
		LbFiltro.Text = "lbFiltro";
		LbFiltro.TextAlign = ContentAlignment.MiddleCenter;
		TBPesquisa.CharacterCasing = CharacterCasing.Upper;
		TBPesquisa.Location = new Point(87, 184);
		TBPesquisa.Name = "TBPesquisa";
		TBPesquisa.Size = new Size(92, 20);
		TBPesquisa.TabIndex = 190;
		TBPesquisa.TextAlign = HorizontalAlignment.Center;
		LbFiltro1.BorderStyle = BorderStyle.Fixed3D;
		LbFiltro1.Location = new Point(187, 184);
		LbFiltro1.Name = "LbFiltro1";
		LbFiltro1.Size = new Size(70, 20);
		LbFiltro1.TabIndex = 193;
		LbFiltro1.Text = "lbFiltro";
		LbFiltro1.TextAlign = ContentAlignment.MiddleCenter;
		TBPesquisa2.CharacterCasing = CharacterCasing.Upper;
		TBPesquisa2.Location = new Point(262, 184);
		TBPesquisa2.Name = "TBPesquisa2";
		TBPesquisa2.Size = new Size(92, 20);
		TBPesquisa2.TabIndex = 192;
		TBPesquisa2.TextAlign = HorizontalAlignment.Center;
		dgCor.AllowUserToAddRows = false;
		dgCor.AllowUserToDeleteRows = false;
		dgCor.AllowUserToOrderColumns = true;
		dgCor.AllowUserToResizeRows = false;
		dgCor.BackgroundColor = Color.White;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle5.BackColor = SystemColors.Control;
		dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
		dgCor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
		dgCor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgCor.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgCor.Location = new Point(209, 38);
		dgCor.MultiSelect = false;
		dgCor.Name = "dgCor";
		dgCor.ReadOnly = true;
		dgCor.RowHeadersVisible = false;
		dgCor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgCor.Size = new Size(99, 136);
		dgCor.TabIndex = 194;
		tbNumCabo.CharacterCasing = CharacterCasing.Upper;
		tbNumCabo.Location = new Point(113, 387);
		tbNumCabo.Name = "tbNumCabo";
		tbNumCabo.Size = new Size(40, 20);
		tbNumCabo.TabIndex = 195;
		tbNumCabo.TextAlign = HorizontalAlignment.Center;
		btColar.FlatStyle = FlatStyle.Flat;
		btColar.ForeColor = SystemColors.Control;
		btColar.Image = Resources.Paste_32;
		btColar.Location = new Point(312, 122);
		btColar.Name = "btColar";
		btColar.Size = new Size(40, 40);
		btColar.TabIndex = 197;
		btColar.UseVisualStyleBackColor = true;
		tbCor.CharacterCasing = CharacterCasing.Upper;
		tbCor.Location = new Point(209, 12);
		tbCor.Name = "tbCor";
		tbCor.Size = new Size(99, 20);
		tbCor.TabIndex = 198;
		tbCor.TextAlign = HorizontalAlignment.Center;
		BTAdicionaCor.FlatStyle = FlatStyle.Flat;
		BTAdicionaCor.ForeColor = SystemColors.Control;
		BTAdicionaCor.Image = Resources.Adiciona_32;
		BTAdicionaCor.Location = new Point(312, 1);
		BTAdicionaCor.Name = "BTAdicionaCor";
		BTAdicionaCor.Size = new Size(40, 40);
		BTAdicionaCor.TabIndex = 200;
		BTAdicionaCor.UseVisualStyleBackColor = true;
		BTApagaCor.FlatStyle = FlatStyle.Flat;
		BTApagaCor.ForeColor = SystemColors.Control;
		BTApagaCor.Image = Resources.Delete_32;
		BTApagaCor.Location = new Point(312, 76);
		BTApagaCor.Name = "BTApagaCor";
		BTApagaCor.Size = new Size(40, 40);
		BTApagaCor.TabIndex = 199;
		BTApagaCor.Tag = "";
		BTApagaCor.UseVisualStyleBackColor = true;
		lbCabo.BorderStyle = BorderStyle.Fixed3D;
		lbCabo.Location = new Point(12, 387);
		lbCabo.Name = "lbCabo";
		lbCabo.Size = new Size(95, 20);
		lbCabo.TabIndex = 191;
		lbCabo.Text = "lb Inicio do Cabo ";
		lbCabo.TextAlign = ContentAlignment.MiddleCenter;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(784, 431);
		Controls.Add(BTAdicionaCor);
		Controls.Add(BTApagaCor);
		Controls.Add(tbCor);
		Controls.Add(btColar);
		Controls.Add(tbNumCabo);
		Controls.Add(dgCor);
		Controls.Add(LbFiltro1);
		Controls.Add(TBPesquisa2);
		Controls.Add(lbCabo);
		Controls.Add(LbFiltro);
		Controls.Add(TBPesquisa);
		Controls.Add(dgEquip2);
		Controls.Add(qTotal);
		Controls.Add(btExportaEXCEL);
		Controls.Add(btPesquisar);
		Controls.Add(dgVeias);
		Controls.Add(dgEquip);
		Controls.Add(dgRevisao);
		MinimumSize = new Size(800, 470);
		Name = "frmRelatorio_InterligacaoGIGA";
		ShowInTaskbar = false;
		Text = "Lista de Interligação GIGA";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		((ISupportInitialize)dgVeias).EndInit();
		((ISupportInitialize)dgEquip2).EndInit();
		((ISupportInitialize)dgCor).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return hLsqEU8Ykk;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		hLsqEU8Ykk = WithEventsValue;
	}

	public frmRelatorio_InterligacaoGIGA()
	{
		Resize += dtcq3WTxh6;
		cytahUkjpN = new DeclaracoesFiacao.structurePnRev[1];
		h7Oao2OtHp = new DeclaracoesFiacao.structureRevisoes[1];
		RKTak1viFY = "";
		F7hadLNwUy = false;
		F60afw5jsd = false;
		GMCaDe1EIk = "";
		exjavQkbLv = "";
		try
		{
			if (!Geral.ExisteForm("frmRelatorio_InterligacaoGIGA"))
			{
				SAjqFc5goN();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1609]);
				w8dpBZ0kvSD().SetToolTip(btPesquisar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1612]));
				w8dpBZ0kvSD().SetToolTip(BTAdicionaCor, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1613], "\r\n"), DeclaracoesGeral.mMensagem[1, 1614])));
				w8dpBZ0kvSD().SetToolTip(BTApagaCor, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1615]));
				w8dpBZ0kvSD().SetToolTip(btColar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1616]));
				lbCabo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1611]);
				LbFiltro.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 272]);
				LbFiltro1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 272]);
				cDadosAccess.carregaDadosDWG();
				Application.ShowModelessDialog((Form)this);
				formataDGRevisao();
				DataGridView dg = dgEquip;
				formataDGEquip(ref dg);
				dgEquip = dg;
				formataDGCabos();
				yMCqQxWxKm();
				qTotal.Text = "";
				tbNumCabo.Text = Conversions.ToString(1);
				AtualizaDGRevisao();
				dg = dgEquip;
				AtualizaDGEquip(ref dg);
				dgEquip = dg;
				btExportaEXCEL.Enabled = false;
				SBbq1CHxUt(_0020: true);
				dgVeias.Rows.Clear();
				dgVeias.Columns.Clear();
				EtIqUV4Jg4();
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

	private void yMCqQxWxKm()
	{
		h7Oao2OtHp = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			cDadosAccessInterligacao3.CarregaRevisoesCabos4(ref h7Oao2OtHp);
			F7hadLNwUy = true;
			dgRevisao.Rows.Clear();
			F7hadLNwUy = false;
			int num = Information.UBound(h7Oao2OtHp);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				dgRevisao.Rows.Add(h7Oao2OtHp[i].revisao, h7Oao2OtHp[i].criador, h7Oao2OtHp[i].data);
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

	private void a5OqP7NxNT(object P_0, EventArgs P_1)
	{
		F60afw5jsd = true;
		dgEquip.Rows.Clear();
		F60afw5jsd = false;
		if (!F7hadLNwUy)
		{
			dCsqKXnJ3J(_0020: false);
		}
	}

	private void AEUqc1hAcL(object P_0, KeyEventArgs P_1)
	{
		if ((P_1.KeyValue == 13) | (Operators.CompareString(TBPesquisa.Text.Trim(), "", TextCompare: true) == 0))
		{
			if (!F7hadLNwUy)
			{
				dCsqKXnJ3J(_0020: true);
			}
			SBbq1CHxUt(_0020: true);
		}
	}

	private void dCsqKXnJ3J(bool P_0)
	{
		if (!P_0)
		{
			TBPesquisa.Text = "";
		}
		CarregaPnRev();
		try
		{
			if (dgRevisao.SelectedRows.Count != 1)
			{
				return;
			}
			RKTak1viFY = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
			F60afw5jsd = true;
			dgEquip.Rows.Clear();
			F60afw5jsd = false;
			int num = Information.UBound(cytahUkjpN);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(cytahUkjpN[i].revisao, RKTak1viFY, TextCompare: true) == 0)
				{
					string text = Dicionario.BuscaNomeDoPainel(cytahUkjpN[i].painel);
					if (!P_0)
					{
						dgEquip.Rows.Add(cytahUkjpN[i].painel, text);
					}
					else if (text.ToUpper().Contains(TBPesquisa.Text.ToUpper().Trim()))
					{
						dgEquip.Rows.Add(cytahUkjpN[i].painel, text);
					}
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
		cytahUkjpN = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			if (Information.UBound(h7Oao2OtHp) > 0)
			{
				int num = Information.UBound(h7Oao2OtHp);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessInterligacao3.CarregaPnRev(h7Oao2OtHp[i].revisao, ref cytahUkjpN);
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

	private void AnHqe18H0i(object P_0, EventArgs P_1)
	{
		qTotal.Text = "";
		btExportaEXCEL.Enabled = false;
		btPesquisar.Enabled = false;
		if (Operators.CompareString(tbNumCabo.Text, "", TextCompare: true) == 0)
		{
			tbNumCabo.Text = Conversions.ToString(1);
		}
		int num = Conversions.ToInteger(tbNumCabo.Text);
		List<string> lCabosUnico = new List<string>();
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		int num2 = 0;
		int num3 = 0;
		S5oaHJDW3I = new clsVeias.InterGIGA[1];
		List<string> list = new List<string>();
		int i = 0;
		checked
		{
			int num4 = dgCor.RowCount - 1;
			int num5 = dgCor.RowCount - 1;
			for (int j = 0; j <= num5; j++)
			{
				list.Add(Conversions.ToString(dgCor.Rows[j].Cells[0].Value));
			}
			try
			{
				if (list.Count != 0)
				{
					C3IaG3WtKH = new clsVeias.StructureVeiasgIGA[1];
					if ((dgEquip.SelectedRows.Count == 0) | (dgEquip2.SelectedRows.Count == 0))
					{
						return;
					}
					formataDGCabos();
					int iPN = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
					int iPN2 = Conversions.ToInteger(dgEquip2.SelectedRows[0].Cells[0].Value);
					GMCaDe1EIk = Conversions.ToString(dgEquip.SelectedRows[0].Cells[1].Value);
					exjavQkbLv = Conversions.ToString(dgEquip2.SelectedRows[0].Cells[1].Value);
					cDadosAccessInterligacao3.CarregaVeiasGIGA(RKTak1viFY, ref lCabosUnico, iPN, iPN2, ref C3IaG3WtKH);
					if (Information.UBound(C3IaG3WtKH) == 0)
					{
						return;
					}
					DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(C3IaG3WtKH);
					DeclaracoesGeral._uscPagina.pbIniciar();
					bool flag = false;
					int num6 = Information.UBound(C3IaG3WtKH);
					for (int k = 1; k <= num6; k++)
					{
						if (Operators.CompareString(C3IaG3WtKH[k].sDisp1, "", TextCompare: true) != 0)
						{
							num2++;
							ref clsVeias.InterGIGA[] s5oaHJDW3I = ref S5oaHJDW3I;
							s5oaHJDW3I = (clsVeias.InterGIGA[])Utils.CopyArray(s5oaHJDW3I, new clsVeias.InterGIGA[num2 + 1]);
							S5oaHJDW3I[num2].iIndice = i;
							S5oaHJDW3I[num2].sTag1 = C3IaG3WtKH[k].sDisp1 + "-" + C3IaG3WtKH[k].sBorne1;
							S5oaHJDW3I[num2].sCor = list[i];
							i++;
							if (i > num4)
							{
								i = 0;
							}
							S5oaHJDW3I[num2].sTag2 = C3IaG3WtKH[k].sDisp2 + "-" + C3IaG3WtKH[k].sBorne2;
							S5oaHJDW3I[num2].sPG = C3IaG3WtKH[k].sPagina1;
							S5oaHJDW3I[num2].sD1 = C3IaG3WtKH[k].sDisp1;
							S5oaHJDW3I[num2].sD2 = C3IaG3WtKH[k].sDisp2;
							S5oaHJDW3I[num2].sB1 = C3IaG3WtKH[k].sBorne1;
							S5oaHJDW3I[num2].sB1 = C3IaG3WtKH[k].sBorne2;
							if (Operators.CompareString(C3IaG3WtKH[k].sPagina1, C3IaG3WtKH[k].sPagina2, TextCompare: true) != 0)
							{
								ref string sPG = ref S5oaHJDW3I[num2].sPG;
								sPG = sPG + ", " + C3IaG3WtKH[k].sPagina2;
							}
							flag = true;
						}
					}
					if (flag)
					{
						for (; i < num4 + 1; i++)
						{
							num2++;
							ref clsVeias.InterGIGA[] s5oaHJDW3I2 = ref S5oaHJDW3I;
							s5oaHJDW3I2 = (clsVeias.InterGIGA[])Utils.CopyArray(s5oaHJDW3I2, new clsVeias.InterGIGA[num2 + 1]);
							S5oaHJDW3I[num2].iIndice = i;
							S5oaHJDW3I[num2].sTag1 = "";
							S5oaHJDW3I[num2].sTag2 = "";
							S5oaHJDW3I[num2].sPG = "";
							S5oaHJDW3I[num2].sCor = list[i];
						}
						DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
						dataGridViewCellStyle.BackColor = Color.LightBlue;
						int num7 = Information.UBound(S5oaHJDW3I);
						for (int l = 1; l <= num7; l++)
						{
							if (S5oaHJDW3I[l].iIndice == 0)
							{
								num3++;
								if (l > 1)
								{
									dgVeias.Rows.Add("", "", "", "");
								}
								dgVeias.Rows.Add("INTERLIGAÇÃO", "", "", "");
								int num8 = 0;
								do
								{
									dgVeias.Rows[dgVeias.RowCount - 1].Cells[num8].Style = dataGridViewCellStyle;
									num8++;
								}
								while (num8 <= 3);
								dgVeias.Rows.Add("CABO:", "CABO " + Conversions.ToString(num), "", "");
								num++;
								int num9 = 0;
								do
								{
									dgVeias.Rows[dgVeias.RowCount - 1].Cells[num9].Style = dataGridViewCellStyle;
									num9++;
								}
								while (num9 <= 3);
								dgVeias.Rows.Add("TAG.:" + GMCaDe1EIk, DeclaracoesGeral.mMensagem[1, 1569].ToString().ToUpper(), "TAG.:" + exjavQkbLv, "FL.:");
								int num10 = 0;
								do
								{
									dgVeias.Rows[dgVeias.RowCount - 1].Cells[num10].Style = dataGridViewCellStyle;
									num10++;
								}
								while (num10 <= 3);
							}
							dgVeias.Rows.Add(S5oaHJDW3I[l].sTag1, S5oaHJDW3I[l].sCor, S5oaHJDW3I[l].sTag2, S5oaHJDW3I[l].sPG);
						}
					}
					AtualizaDGCabos();
					DeclaracoesGeral._uscPagina.pbFim();
					qTotal.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1610], " "), num3));
					if (num3 > 0)
					{
						btExportaEXCEL.Enabled = true;
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
				cDadosAccessInterligacao3.FechaConexao();
			}
			btPesquisar.Enabled = true;
		}
	}

	private void VAfq2ICA35(object P_0, EventArgs P_1)
	{
		btExportaEXCEL.Enabled = false;
		if (!Information.IsNothing(S5oaHJDW3I) && Information.UBound(S5oaHJDW3I) != 0)
		{
			if (Operators.CompareString(tbNumCabo.Text, "", TextCompare: true) == 0)
			{
				tbNumCabo.Text = Conversions.ToString(1);
			}
			string sNomeSheet = GMCaDe1EIk + "/" + exjavQkbLv;
			clsVeias.InterGIGA[] s5oaHJDW3I = S5oaHJDW3I;
			int iQuantLinhas = checked(dgCor.RowCount - 1);
			TextBox textBox;
			string sNumCabo = (textBox = tbNumCabo).Text;
			Relatorios_GIGA.CriaListaVeiasEXCELGIGA(sNomeSheet, s5oaHJDW3I, iQuantLinhas, ref sNumCabo, ref GMCaDe1EIk, ref exjavQkbLv);
			textBox.Text = sNumCabo;
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1882]), MsgBoxStyle.Information);
			btExportaEXCEL.Enabled = true;
		}
	}

	public void formataDGCabos()
	{
		try
		{
			dgVeias.Rows.Clear();
			dgVeias.Columns.Clear();
			dgVeias.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 518]));
			dgVeias.Columns.Add("", "Cor");
			dgVeias.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 518]));
			dgVeias.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 9]));
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
					dgVeias.Columns[0].Width = (int)Math.Round(num * 0.3);
					dgVeias.Columns[1].Width = (int)Math.Round(num * 0.2);
					dgVeias.Columns[2].Width = (int)Math.Round(num * 0.3);
					dgVeias.Columns[3].Width = (int)Math.Round(num * 0.2);
					int num2 = 0;
					do
					{
						dgVeias.Columns[num2].Visible = true;
						dgVeias.Columns[num2].ReadOnly = false;
						num2++;
					}
					while (num2 <= 3);
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

	private void dtcq3WTxh6(object P_0, EventArgs P_1)
	{
		AtualizaDGRevisao();
		DataGridView dg = dgEquip;
		AtualizaDGEquip(ref dg);
		dgEquip = dg;
		AtualizaDGCabos();
	}

	private void F7LqnBD068(object P_0, KeyEventArgs P_1)
	{
		if (((P_1.KeyValue == 13) | (Operators.CompareString(TBPesquisa.Text.Trim(), "", TextCompare: true) == 0)) && !F7hadLNwUy)
		{
			SBbq1CHxUt(_0020: true);
		}
	}

	private void SBbq1CHxUt(bool P_0)
	{
		if (!P_0)
		{
			TBPesquisa2.Text = "";
		}
		DataGridView dg = dgEquip2;
		formataDGEquip(ref dg);
		dgEquip2 = dg;
		try
		{
			if (dgRevisao.SelectedRows.Count == 1)
			{
				RKTak1viFY = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
				F60afw5jsd = true;
				dgEquip2.Rows.Clear();
				F60afw5jsd = false;
				int num = Information.UBound(cytahUkjpN);
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					if (Operators.CompareString(cytahUkjpN[i].revisao, RKTak1viFY, TextCompare: true) != 0)
					{
						continue;
					}
					string text = Dicionario.BuscaNomeDoPainel(cytahUkjpN[i].painel);
					if (!P_0)
					{
						if (Operators.ConditionalCompareObjectNotEqual(dgEquip.SelectedRows[0].Cells[0].Value, cytahUkjpN[i].painel, TextCompare: true))
						{
							dgEquip2.Rows.Add(cytahUkjpN[i].painel, text);
						}
					}
					else if (text.ToUpper().Contains(TBPesquisa2.Text.ToUpper().Trim()) && Operators.ConditionalCompareObjectNotEqual(dgEquip.SelectedRows[0].Cells[0].Value, cytahUkjpN[i].painel, TextCompare: true))
					{
						dgEquip2.Rows.Add(cytahUkjpN[i].painel, text);
					}
				}
			}
			dg = dgEquip2;
			AtualizaDGEquip(ref dg);
			dgEquip2 = dg;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void SF0qlFU3ns(object P_0, EventArgs P_1)
	{
		SBbq1CHxUt(_0020: false);
	}

	private void bWnq5uOT3Z(object P_0, KeyEventArgs P_1)
	{
		SBbq1CHxUt(_0020: false);
	}

	private void pRkq01k74Y(object P_0, MouseEventArgs P_1)
	{
		SBbq1CHxUt(_0020: false);
	}

	private void lCWqRd8XEj(object P_0, EventArgs P_1)
	{
		string text = Clipboard.GetText();
		if (Operators.CompareString(Strings.Trim(text), "", TextCompare: true) == 0)
		{
			return;
		}
		checked
		{
			if (Strings.Asc(Strings.Mid(text, Strings.Len(text) - 1, 1)) != 13)
			{
				text += "\r\n";
			}
			string[] array = text.Split('\r');
			formataDgCor();
			List<string> list = new List<string>();
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text2 = array2[i];
				text2 = text2.ToString().Trim();
				if (Operators.CompareString(text2.Trim(), "", TextCompare: true) != 0 && !list.Contains(text2))
				{
					dgCor.Rows.Add(text2);
					list.Add(text2);
				}
			}
			AtualizaDGCor();
			s1lqyugrjQ();
		}
	}

	private void lqyqmToTOH(object P_0, EventArgs P_1)
	{
		List<string> list = new List<string>();
		checked
		{
			int num = dgCor.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				list.Add(Conversions.ToString(dgCor.Rows[i].Cells[0].Value));
			}
			if (dgCor.RowCount == 0)
			{
				formataDgCor();
			}
			if (Operators.CompareString(tbCor.Text.Trim(), "", TextCompare: true) != 0)
			{
				string[] array = tbCor.Text.Split(';');
				string[] array2 = array;
				for (int j = 0; j < array2.Length; j++)
				{
					string text = array2[j];
					text = text.ToString().Trim();
					if (Operators.CompareString(text.Trim(), "", TextCompare: true) != 0 && !list.Contains(text))
					{
						dgCor.Rows.Add(text);
						list.Add(text);
					}
				}
				AtualizaDGCor();
				s1lqyugrjQ();
			}
			if (dgCor.RowCount == 0)
			{
				dgCor.Rows.Clear();
				dgCor.Columns.Clear();
			}
		}
	}

	private void lnCqXJvBop(object P_0, EventArgs P_1)
	{
		if (dgCor.RowCount == 0)
		{
			return;
		}
		string right = Conversions.ToString(dgCor.SelectedRows[0].Cells[0].Value);
		checked
		{
			int num = dgCor.Rows.Count - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					if (Operators.ConditionalCompareObjectEqual(dgCor.Rows[num2].Cells[0].Value, right, TextCompare: true))
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			dgCor.Rows.RemoveAt(num2);
			AtualizaDGCor();
			s1lqyugrjQ();
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

	public void formataDGEquip(ref DataGridView dg)
	{
		try
		{
			F60afw5jsd = true;
			dg.Rows.Clear();
			dg.Columns.Clear();
			dg.Columns.Add("", "Indice");
			dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 748]));
			AtualizaDGEquip(ref dg);
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
			F60afw5jsd = false;
		}
	}

	public void AtualizaDGEquip(ref DataGridView dg)
	{
		checked
		{
			try
			{
				if (dg.RowCount != 0)
				{
					double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 25)));
					dg.Columns[0].Width = (int)Math.Round(num * 0.4);
					dg.Columns[1].Width = (int)Math.Round(num * 0.6);
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
				F60afw5jsd = false;
			}
		}
	}

	public void formataDgCor()
	{
		dgCor.Rows.Clear();
		dgCor.Columns.Clear();
		dgCor.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 497]));
	}

	public void AtualizaDGCor()
	{
		checked
		{
			if (dgCor.RowCount != 0)
			{
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgCor)) ? ((double)(dgCor.Width - 5)) : ((double)(dgCor.Width - 22)));
				dgCor.Columns[0].Width = (int)Math.Round(a);
				dgCor.Columns[0].Visible = true;
				dgCor.Columns[0].ReadOnly = false;
				dgCor.MultiSelect = false;
			}
		}
	}

	private void EtIqUV4Jg4()
	{
		if (!clsAuxiliar.BancoValido())
		{
			return;
		}
		string sComando = "";
		checked
		{
			int num = dgCor.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				sComando = Conversions.ToString(Operators.AddObject(sComando, Operators.ConcatenateObject(dgCor.Rows[i].Cells[0].Value, ";")));
			}
			cDadosAccessComum cDadosAccessComum2 = new cDadosAccessComum();
			try
			{
				cDadosAccessComum2.LeConfiguracao(ref sComando, 1, "R", "GIGA");
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
				cDadosAccessComum2.fechaConexao();
			}
			string[] array = sComando.Split(';');
			formataDgCor();
			List<string> list = new List<string>();
			string[] array2 = array;
			for (int j = 0; j < array2.Length; j++)
			{
				string text = array2[j];
				text = text.ToString().Trim();
				if (Operators.CompareString(text.Trim(), "", TextCompare: true) != 0 && !list.Contains(text))
				{
					dgCor.Rows.Add(text);
					list.Add(text);
				}
			}
			AtualizaDGCor();
		}
	}

	private void s1lqyugrjQ()
	{
		if (!clsAuxiliar.BancoValido())
		{
			return;
		}
		string text = "";
		checked
		{
			int num = dgCor.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				text = Conversions.ToString(Operators.AddObject(text, Operators.ConcatenateObject(dgCor.Rows[i].Cells[0].Value, ";")));
			}
			cDadosAccessComum cDadosAccessComum2 = new cDadosAccessComum();
			try
			{
				cDadosAccessComum2.GravaConfiguracao(text, 1, "R", "GIGA");
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
				cDadosAccessComum2.fechaConexao();
			}
		}
	}
}
