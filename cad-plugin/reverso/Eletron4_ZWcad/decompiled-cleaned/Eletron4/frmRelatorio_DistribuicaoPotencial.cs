using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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
public class frmRelatorio_DistribuicaoPotencial : Form
{
	private IContainer q6YpxeTYl48;

	[AccessedThroughProperty("dgRevisaoF")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView GtFpx2ZyniY;

	[CompilerGenerated]
	[AccessedThroughProperty("dgEquipamentos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView rc2px39nJi5;

	[AccessedThroughProperty("dgDWG")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView ltNpxnwho2e;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip Txmpx1Q9veJ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgBlocos")]
	private DataGridView GK2pxlbaZMe;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("dgTagInter")]
	private DataGridView hnupx5S97sm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgTag")]
	private DataGridView LqOpx0Ponww;

	[AccessedThroughProperty("dgPotenciais")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView RXOpxRRGHBt;

	[CompilerGenerated]
	[AccessedThroughProperty("btInserir")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button cx8pxmSOi0V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagar")]
	[CompilerGenerated]
	private Button gFjpxX3ydwu;

	[AccessedThroughProperty("tbRelatorio")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox cP5pxUsPpwd;

	[AccessedThroughProperty("ComboRevisaoI")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ComboBox LZGpxytLsDW;

	[AccessedThroughProperty("tbRevisãoI")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox rdNpxga6HLt;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTY")]
	[CompilerGenerated]
	private Button SOPpxAnkvf4;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbOrdenada")]
	[CompilerGenerated]
	private TextBox FpGpxscoKCo;

	[AccessedThroughProperty("lbY")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label zVWpxBIjYui;

	public double minAltura;

	private DeclaracoesFiacao.structurePnRev[] TgqpxVs11jd;

	private DeclaracoesFiacao.structureRevisoes[] SuQpxuX8AkW;

	private DeclaracoesFiacao.structureRevisoes[] OKepxEiP5ZD;

	private object[,] odTpxZ6oXnf;

	private int QVLpxiMd2aK;

	private string vm8pxSG1mdc;

	private string v71px4idkaq;

	private int as7pxCH7149;

	private int SfwpxY5XdNt;

	private string cSppxrC5ZLU;

	private int shmpx9bXxT3;

	private double MkKpxz7ox88;

	private double dWmpbWAKL6F;

	private double oFdpbpkG9WS;

	private bool XtcpbT11hZg;

	private string b1hpbJJADOO;

	private string AF2pbh5emvd;

	private double NZ9pboNT3uw;

	private int S1fpbGlxKVY;

	private string rItpbHyb73h;

	private string NQopbkZ4BCD;

	internal virtual DataGridView dgRevisaoF
	{
		[CompilerGenerated]
		get
		{
			return GtFpx2ZyniY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OswpxxhJqU5;
			DataGridView dataGridView = GtFpx2ZyniY;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			GtFpx2ZyniY = value;
			dataGridView = GtFpx2ZyniY;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgEquipamentos
	{
		[CompilerGenerated]
		get
		{
			return rc2px39nJi5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = fs1pxbTlOAn;
			MouseEventHandler value3 = SMkpxM26Zqa;
			DataGridView dataGridView = rc2px39nJi5;
			if (dataGridView != null)
			{
				dataGridView.KeyUp -= value2;
				dataGridView.MouseClick -= value3;
			}
			rc2px39nJi5 = value;
			dataGridView = rc2px39nJi5;
			if (dataGridView != null)
			{
				dataGridView.KeyUp += value2;
				dataGridView.MouseClick += value3;
			}
		}
	}

	internal virtual DataGridView dgDWG
	{
		[CompilerGenerated]
		get
		{
			return ltNpxnwho2e;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = iwnpxwEI1UL;
			DataGridView dataGridView = ltNpxnwho2e;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			ltNpxnwho2e = value;
			dataGridView = ltNpxnwho2e;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgBlocos
	{
		[CompilerGenerated]
		get
		{
			return GK2pxlbaZMe;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = uXZpxqARPOJ;
			DataGridView dataGridView = GK2pxlbaZMe;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			GK2pxlbaZMe = value;
			dataGridView = GK2pxlbaZMe;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgTagInter
	{
		[CompilerGenerated]
		get
		{
			return hnupx5S97sm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			hnupx5S97sm = value;
		}
	}

	internal virtual DataGridView dgTag
	{
		[CompilerGenerated]
		get
		{
			return LqOpx0Ponww;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = cdqpx7uwWG3;
			DataGridView dataGridView = LqOpx0Ponww;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			LqOpx0Ponww = value;
			dataGridView = LqOpx0Ponww;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgPotenciais
	{
		[CompilerGenerated]
		get
		{
			return RXOpxRRGHBt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = zCTpxOHnYwC;
			MouseEventHandler value3 = yjqpxICb6eB;
			DataGridView dataGridView = RXOpxRRGHBt;
			if (dataGridView != null)
			{
				dataGridView.KeyUp -= value2;
				dataGridView.MouseClick -= value3;
			}
			RXOpxRRGHBt = value;
			dataGridView = RXOpxRRGHBt;
			if (dataGridView != null)
			{
				dataGridView.KeyUp += value2;
				dataGridView.MouseClick += value3;
			}
		}
	}

	internal virtual Button btInserir
	{
		[CompilerGenerated]
		get
		{
			return cx8pxmSOi0V;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = eMkpx8ZCDFl;
			Button button = cx8pxmSOi0V;
			if (button != null)
			{
				button.Click -= value2;
			}
			cx8pxmSOi0V = value;
			button = cx8pxmSOi0V;
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
			return gFjpxX3ydwu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = chepxNHkjTj;
			Button button = gFjpxX3ydwu;
			if (button != null)
			{
				button.Click -= value2;
			}
			gFjpxX3ydwu = value;
			button = gFjpxX3ydwu;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbRelatorio
	{
		[CompilerGenerated]
		get
		{
			return cP5pxUsPpwd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			cP5pxUsPpwd = value;
		}
	}

	internal virtual ComboBox ComboRevisaoI
	{
		[CompilerGenerated]
		get
		{
			return LZGpxytLsDW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LZGpxytLsDW = value;
		}
	}

	internal virtual TextBox tbRevisãoI
	{
		[CompilerGenerated]
		get
		{
			return rdNpxga6HLt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rdNpxga6HLt = value;
		}
	}

	internal virtual Button BTY
	{
		[CompilerGenerated]
		get
		{
			return SOPpxAnkvf4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = JqtpxKkM0JO;
			Button button = SOPpxAnkvf4;
			if (button != null)
			{
				button.Click -= value2;
			}
			SOPpxAnkvf4 = value;
			button = SOPpxAnkvf4;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbOrdenada
	{
		[CompilerGenerated]
		get
		{
			return FpGpxscoKCo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			FpGpxscoKCo = value;
		}
	}

	internal virtual Label lbY
	{
		[CompilerGenerated]
		get
		{
			return zVWpxBIjYui;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zVWpxBIjYui = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && q6YpxeTYl48 != null)
			{
				q6YpxeTYl48.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void d3SpxtanACk()
	{
		q6YpxeTYl48 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		dgRevisaoF = new DataGridView();
		dgEquipamentos = new DataGridView();
		dgDWG = new DataGridView();
		FDqpBiUmZij(new ToolTip(q6YpxeTYl48));
		dgBlocos = new DataGridView();
		dgTagInter = new DataGridView();
		dgTag = new DataGridView();
		dgPotenciais = new DataGridView();
		btInserir = new Button();
		btApagar = new Button();
		tbRelatorio = new TextBox();
		ComboRevisaoI = new ComboBox();
		tbRevisãoI = new TextBox();
		BTY = new Button();
		tbOrdenada = new TextBox();
		lbY = new Label();
		((ISupportInitialize)dgRevisaoF).BeginInit();
		((ISupportInitialize)dgEquipamentos).BeginInit();
		((ISupportInitialize)dgDWG).BeginInit();
		((ISupportInitialize)dgBlocos).BeginInit();
		((ISupportInitialize)dgTagInter).BeginInit();
		((ISupportInitialize)dgTag).BeginInit();
		((ISupportInitialize)dgPotenciais).BeginInit();
		SuspendLayout();
		dgRevisaoF.AllowUserToAddRows = false;
		dgRevisaoF.AllowUserToDeleteRows = false;
		dgRevisaoF.AllowUserToOrderColumns = true;
		dgRevisaoF.AllowUserToResizeRows = false;
		dgRevisaoF.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		dgRevisaoF.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgRevisaoF.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgRevisaoF.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgRevisaoF.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgRevisaoF.Location = new Point(277, 6);
		dgRevisaoF.MultiSelect = false;
		dgRevisaoF.Name = "dgRevisaoF";
		dgRevisaoF.ReadOnly = true;
		dgRevisaoF.RowHeadersVisible = false;
		dgRevisaoF.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRevisaoF.Size = new Size(139, 98);
		dgRevisaoF.TabIndex = 3;
		dgEquipamentos.AllowUserToAddRows = false;
		dgEquipamentos.AllowUserToDeleteRows = false;
		dgEquipamentos.AllowUserToOrderColumns = true;
		dgEquipamentos.AllowUserToResizeRows = false;
		dgEquipamentos.BackgroundColor = Color.White;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dgEquipamentos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgEquipamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgEquipamentos.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgEquipamentos.Location = new Point(6, 155);
		dgEquipamentos.MultiSelect = false;
		dgEquipamentos.Name = "dgEquipamentos";
		dgEquipamentos.ReadOnly = true;
		dgEquipamentos.RowHeadersVisible = false;
		dgEquipamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquipamentos.Size = new Size(217, 147);
		dgEquipamentos.TabIndex = 8;
		dgDWG.AllowUserToAddRows = false;
		dgDWG.AllowUserToDeleteRows = false;
		dgDWG.AllowUserToOrderColumns = true;
		dgDWG.AllowUserToResizeRows = false;
		dgDWG.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		dgDWG.BackgroundColor = Color.White;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		dgDWG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		dgDWG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgDWG.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgDWG.Location = new Point(6, 6);
		dgDWG.MultiSelect = false;
		dgDWG.Name = "dgDWG";
		dgDWG.ReadOnly = true;
		dgDWG.RowHeadersVisible = false;
		dgDWG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgDWG.Size = new Size(260, 143);
		dgDWG.TabIndex = 17;
		dgBlocos.AllowUserToAddRows = false;
		dgBlocos.AllowUserToDeleteRows = false;
		dgBlocos.AllowUserToOrderColumns = true;
		dgBlocos.AllowUserToResizeRows = false;
		dgBlocos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgBlocos.BorderStyle = BorderStyle.Fixed3D;
		dgBlocos.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgBlocos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgBlocos.Location = new Point(659, 398);
		dgBlocos.MultiSelect = false;
		dgBlocos.Name = "dgBlocos";
		dgBlocos.ReadOnly = true;
		dgBlocos.RowHeadersVisible = false;
		dgBlocos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgBlocos.Size = new Size(485, 166);
		dgBlocos.TabIndex = 161;
		dgTagInter.AllowUserToAddRows = false;
		dgTagInter.AllowUserToDeleteRows = false;
		dgTagInter.AllowUserToOrderColumns = true;
		dgTagInter.AllowUserToResizeRows = false;
		dgTagInter.BackgroundColor = Color.White;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = SystemColors.Control;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		dgTagInter.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		dgTagInter.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgTagInter.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgTagInter.Location = new Point(659, 12);
		dgTagInter.MultiSelect = false;
		dgTagInter.Name = "dgTagInter";
		dgTagInter.ReadOnly = true;
		dgTagInter.RowHeadersVisible = false;
		dgTagInter.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgTagInter.Size = new Size(485, 380);
		dgTagInter.TabIndex = 163;
		dgTag.AllowUserToAddRows = false;
		dgTag.AllowUserToDeleteRows = false;
		dgTag.AllowUserToOrderColumns = true;
		dgTag.AllowUserToResizeRows = false;
		dgTag.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgTag.BackgroundColor = Color.White;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle5.BackColor = SystemColors.Control;
		dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
		dgTag.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
		dgTag.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgTag.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgTag.Location = new Point(234, 174);
		dgTag.MultiSelect = false;
		dgTag.Name = "dgTag";
		dgTag.ReadOnly = true;
		dgTag.RowHeadersVisible = false;
		dgTag.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgTag.Size = new Size(182, 346);
		dgTag.TabIndex = 162;
		dgPotenciais.AllowUserToAddRows = false;
		dgPotenciais.AllowUserToDeleteRows = false;
		dgPotenciais.AllowUserToOrderColumns = true;
		dgPotenciais.AllowUserToResizeRows = false;
		dgPotenciais.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgPotenciais.BackgroundColor = Color.White;
		dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle6.BackColor = SystemColors.Control;
		dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
		dgPotenciais.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
		dgPotenciais.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPotenciais.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgPotenciais.Location = new Point(6, 308);
		dgPotenciais.MultiSelect = false;
		dgPotenciais.Name = "dgPotenciais";
		dgPotenciais.ReadOnly = true;
		dgPotenciais.RowHeadersVisible = false;
		dgPotenciais.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPotenciais.Size = new Size(216, 262);
		dgPotenciais.TabIndex = 164;
		btInserir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btInserir.FlatStyle = FlatStyle.Flat;
		btInserir.ForeColor = SystemColors.Control;
		btInserir.Image = Resources.OK_32;
		btInserir.Location = new Point(376, 528);
		btInserir.Name = "btInserir";
		btInserir.Size = new Size(40, 42);
		btInserir.TabIndex = 165;
		btInserir.UseVisualStyleBackColor = true;
		btApagar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btApagar.FlatStyle = FlatStyle.Flat;
		btApagar.ForeColor = SystemColors.Control;
		btApagar.Image = Resources.Delete_32;
		btApagar.Location = new Point(330, 528);
		btApagar.Name = "btApagar";
		btApagar.Size = new Size(40, 42);
		btApagar.TabIndex = 166;
		btApagar.UseVisualStyleBackColor = true;
		tbRelatorio.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		tbRelatorio.BackColor = SystemColors.Menu;
		tbRelatorio.BorderStyle = BorderStyle.None;
		tbRelatorio.Location = new Point(235, 155);
		tbRelatorio.Name = "tbRelatorio";
		tbRelatorio.Size = new Size(181, 13);
		tbRelatorio.TabIndex = 167;
		tbRelatorio.Text = "Sequência dos Terminais";
		tbRelatorio.TextAlign = HorizontalAlignment.Center;
		ComboRevisaoI.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		ComboRevisaoI.FormattingEnabled = true;
		ComboRevisaoI.Location = new Point(277, 128);
		ComboRevisaoI.Name = "ComboRevisaoI";
		ComboRevisaoI.Size = new Size(140, 21);
		ComboRevisaoI.TabIndex = 169;
		tbRevisãoI.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		tbRevisãoI.BackColor = SystemColors.Menu;
		tbRevisãoI.BorderStyle = BorderStyle.None;
		tbRevisãoI.Location = new Point(297, 110);
		tbRevisãoI.Name = "tbRevisãoI";
		tbRevisãoI.Size = new Size(120, 13);
		tbRevisãoI.TabIndex = 170;
		tbRevisãoI.Text = "Revisão Interligação";
		tbRevisãoI.TextAlign = HorizontalAlignment.Center;
		BTY.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		BTY.FlatStyle = FlatStyle.Flat;
		BTY.ForeColor = SystemColors.Control;
		BTY.Image = Resources.Altura;
		BTY.Location = new Point(297, 529);
		BTY.Name = "BTY";
		BTY.Size = new Size(40, 40);
		BTY.TabIndex = 171;
		BTY.UseVisualStyleBackColor = true;
		tbOrdenada.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		tbOrdenada.BackColor = SystemColors.ActiveBorder;
		tbOrdenada.Location = new Point(256, 540);
		tbOrdenada.Name = "tbOrdenada";
		tbOrdenada.ReadOnly = true;
		tbOrdenada.Size = new Size(44, 20);
		tbOrdenada.TabIndex = 173;
		lbY.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		lbY.AutoSize = true;
		lbY.Location = new Point(232, 543);
		lbY.Name = "lbY";
		lbY.Size = new Size(27, 13);
		lbY.TabIndex = 172;
		lbY.Text = "LBY";
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(424, 576);
		Controls.Add(tbOrdenada);
		Controls.Add(lbY);
		Controls.Add(BTY);
		Controls.Add(tbRevisãoI);
		Controls.Add(ComboRevisaoI);
		Controls.Add(tbRelatorio);
		Controls.Add(btApagar);
		Controls.Add(btInserir);
		Controls.Add(dgPotenciais);
		Controls.Add(dgTagInter);
		Controls.Add(dgTag);
		Controls.Add(dgBlocos);
		Controls.Add(dgDWG);
		Controls.Add(dgEquipamentos);
		Controls.Add(dgRevisaoF);
		MaximumSize = new Size(650, 1000);
		MinimumSize = new Size(440, 540);
		Name = "frmRelatorio_DistribuicaoPotencial";
		ShowInTaskbar = false;
		Text = "Distribuição de Potenciais";
		((ISupportInitialize)dgRevisaoF).EndInit();
		((ISupportInitialize)dgEquipamentos).EndInit();
		((ISupportInitialize)dgDWG).EndInit();
		((ISupportInitialize)dgBlocos).EndInit();
		((ISupportInitialize)dgTagInter).EndInit();
		((ISupportInitialize)dgTag).EndInit();
		((ISupportInitialize)dgPotenciais).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return Txmpx1Q9veJ;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		Txmpx1Q9veJ = WithEventsValue;
	}

	public frmRelatorio_DistribuicaoPotencial()
	{
		Resize += SxUpxcib8V3;
		TgqpxVs11jd = new DeclaracoesFiacao.structurePnRev[1];
		SuQpxuX8AkW = new DeclaracoesFiacao.structureRevisoes[1];
		OKepxEiP5ZD = new DeclaracoesFiacao.structureRevisoes[1];
		QVLpxiMd2aK = 0;
		vm8pxSG1mdc = "";
		v71px4idkaq = "";
		as7pxCH7149 = 0;
		SfwpxY5XdNt = 0;
		cSppxrC5ZLU = "";
		shmpx9bXxT3 = 1;
		MkKpxz7ox88 = 2.0;
		dWmpbWAKL6F = 7.0;
		XtcpbT11hZg = false;
		b1hpbJJADOO = "D";
		AF2pbh5emvd = "D";
		NZ9pboNT3uw = 20.0;
		S1fpbGlxKVY = 0;
		rItpbHyb73h = "D1";
		NQopbkZ4BCD = "D";
		try
		{
			if (Geral.ExisteForm("frmRelatorio_DistribuicaoPotencial"))
			{
				return;
			}
			if (Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaRelatorios.Trim(), "", TextCompare: true) == 0)
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1443]), MsgBoxStyle.Information);
				new frmConfiguracaoGeral();
				return;
			}
			if (!((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaRelatorios, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Potenciais")))
			{
				string prompt = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1324], DeclaracoesGeral.Conf.dirSimbologiaRelatorios));
				Interaction.MsgBox(prompt, MsgBoxStyle.Information);
				return;
			}
			ref object[,] reference = ref odTpxZ6oXnf;
			ref object[,] reference2 = ref reference;
			object mBlocos = reference;
			Relatorios_DistribuicaoPot.CarregaBlocos(ref mBlocos, "B");
			reference2 = (object[,])mBlocos;
			if (Information.UBound(odTpxZ6oXnf, 2) == 0)
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1325]), MsgBoxStyle.Information);
				return;
			}
			d3SpxtanACk();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1438]);
			cDadosAccess.carregaDadosDWG();
			tbRelatorio.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1321]);
			tbRevisãoI.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1328]);
			lbY.Text = "Y";
			shmpx9bXxT3 = 1;
			CarregaDGDWG();
			DataGridView withEventsValue = dgBlocos;
			ref object[,] reference3 = ref odTpxZ6oXnf;
			reference2 = ref reference3;
			mBlocos = reference3;
			qu2pxjdsmis(ref withEventsValue, ref mBlocos);
			reference2 = (object[,])mBlocos;
			dgBlocos = withEventsValue;
			withEventsValue = dgBlocos;
			k19pxLy0jO7(ref withEventsValue);
			dgBlocos = withEventsValue;
			Application.ShowModelessDialog((Form)this);
			DeclaracoesGeral.Reguas RH = default;
			XDataGeral.LeXDataReguaH(ref RH);
			DeclaracoesGeral.Reguas RH2 = default;
			XDataGeral.LeXDataReguaV(ref RH2);
			tbOrdenada.Text = Conversions.ToString(Math.Round(RH.Pti.Y - 26.0, 2));
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		if (!Caderno.ExisteFormato())
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 76]), MsgBoxStyle.Critical);
			Close();
		}
		else
		{
			AtualizaDGDWG();
			AtualizaDGRevisaoF();
			AtualizaDGEquip();
			AtualizaDGPotenciais();
			AtualizaDGTag();
		}
		XtcpbT11hZg = true;
	}

	private void qu2pxjdsmis(ref DataGridView P_0, ref object P_1)
	{
		P_0.Rows.Clear();
		P_0.Columns.Clear();
		if (Information.UBound((Array)P_1, 2) <= 0)
		{
			return;
		}
		checked
		{
			try
			{
				bool flag = false;
				P_0.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 997]));
				P_0.Columns.Add("", "Caminho");
				P_0.Columns.Add("", "NomeCompleto");
				if (Information.UBound((Array)P_1, 2) >= 2 && Information.UBound((Array)P_1, 2) > 0)
				{
					int num = Information.UBound((Array)P_1, 2) - 1;
					for (int i = num; i >= 1; i += -1)
					{
						int num2 = i;
						for (int j = 1; j <= num2; j++)
						{
							if (Operators.ConditionalCompareObjectGreater(NewLateBinding.LateIndexGet(P_1, new object[2] { 0, j }, null), NewLateBinding.LateIndexGet(P_1, new object[2]
							{
								0,
								j + 1
							}, null), TextCompare: true))
							{
								int num3 = 0;
								do
								{
									object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(P_1, new object[2]
									{
										num3,
										j + 1
									}, null));
									NewLateBinding.LateIndexSet(P_1, new object[3]
									{
										num3,
										j + 1,
										NewLateBinding.LateIndexGet(P_1, new object[2] { num3, j }, null)
									}, null);
									NewLateBinding.LateIndexSet(P_1, new object[3] { num3, j, objectValue }, null);
									num3++;
								}
								while (num3 <= 2);
							}
						}
					}
				}
				int num4 = Information.UBound((Array)P_1, 2);
				for (int k = 1; k <= num4; k++)
				{
					P_0.Rows.Add(Conversions.ToString(NewLateBinding.LateIndexGet(P_1, new object[2] { 0, k }, null)), Conversions.ToString(NewLateBinding.LateIndexGet(P_1, new object[2] { 1, k }, null)), Conversions.ToString(NewLateBinding.LateIndexGet(P_1, new object[2] { 2, k }, null)));
					flag = true;
				}
				if (flag)
				{
					P_0.Rows[0].Selected = true;
					k19pxLy0jO7(ref P_0);
				}
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

	private void k19pxLy0jO7(ref DataGridView P_0)
	{
		checked
		{
			if (P_0.RowCount != 0)
			{
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(P_0)) ? ((double)(P_0.Width - 4)) : ((double)(P_0.Width - 21)));
				P_0.Columns[0].Width = (int)Math.Round(a);
				P_0.Columns[1].Width = 0;
				P_0.Columns[2].Width = 0;
				P_0.Columns[0].Visible = true;
				P_0.Columns[1].Visible = false;
				P_0.Columns[2].Visible = false;
				P_0.Columns[0].ReadOnly = false;
				P_0.Columns[1].ReadOnly = false;
				P_0.Columns[2].ReadOnly = false;
				P_0.MultiSelect = false;
			}
		}
	}

	public void CarregaDGDWG()
	{
		if (shmpx9bXxT3 != 1)
		{
			return;
		}
		DeclaracoesGeral.arqLogico[] mDWG = new DeclaracoesGeral.arqLogico[1];
		cDadosAccessRelPot cDadosAccessRelPot2 = new cDadosAccessRelPot();
		cDadosAccessRelPot2.CarregaDadosTodosDWGFiacao(ref mDWG);
		cDadosAccessRelPot2.fechaConexao();
		checked
		{
			try
			{
				if (Information.UBound(mDWG) <= 0)
				{
					return;
				}
				formataDGDWG();
				int num = Information.UBound(mDWG);
				for (int i = 1; i <= num; i++)
				{
					dgDWG.Rows.Add(mDWG[i].Indice, mDWG[i].Nome);
					if (i == 1)
					{
						dgDWG.Rows[dgDWG.Rows.Count - 1].Selected = true;
					}
				}
				AtualizaDGDWG();
				CarregaDGRevisoes();
				shmpx9bXxT3++;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void CarregaDGRevisoes()
	{
		if (shmpx9bXxT3 != 2)
		{
			return;
		}
		checked
		{
			shmpx9bXxT3++;
			dgRevisaoF.Rows.Clear();
			ComboRevisaoI.Items.Clear();
			dgEquipamentos.Rows.Clear();
			dgPotenciais.Rows.Clear();
			dgTag.Rows.Clear();
			dgTagInter.Rows.Clear();
			if (dgDWG.SelectedRows.Count == 0)
			{
				dgDWG.Rows[0].Selected = true;
			}
			QVLpxiMd2aK = Conversions.ToInteger(dgDWG.SelectedRows[0].Cells[0].Value);
			SuQpxuX8AkW = new DeclaracoesFiacao.structureRevisoes[1];
			try
			{
				cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
				cDadosAccessFiacao2.CarregaRevisoesDwgCorrente(QVLpxiMd2aK, ref SuQpxuX8AkW);
				cDadosAccessFiacao2.fechaConexao();
				if (Information.UBound(SuQpxuX8AkW) > 0)
				{
					formataDGRevisaoF();
				}
				vm8pxSG1mdc = "";
				int num = Information.UBound(SuQpxuX8AkW);
				for (int i = num; i >= 1; i += -1)
				{
					dgRevisaoF.Rows.Add(SuQpxuX8AkW[i].revisao);
					if (Operators.CompareString(vm8pxSG1mdc, "", TextCompare: true) == 0)
					{
						vm8pxSG1mdc = SuQpxuX8AkW[i].revisao;
						dgRevisaoF.Rows[0].Selected = true;
					}
				}
				AtualizaDGRevisaoF();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
			OKepxEiP5ZD = new DeclaracoesFiacao.structureRevisoes[1];
			CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
			try
			{
				OKepxEiP5ZD = new DeclaracoesFiacao.structureRevisoes[1];
				cDadosAccessInterligacao3.CarregaRevisoesDwgIligCorrente(QVLpxiMd2aK, ref OKepxEiP5ZD);
				ComboRevisaoI.Items.Clear();
				v71px4idkaq = "";
				int num2 = Information.UBound(OKepxEiP5ZD);
				for (int j = num2; j >= 1; j += -1)
				{
					ComboRevisaoI.Items.Add(OKepxEiP5ZD[j].revisao);
					if (Operators.CompareString(v71px4idkaq, "", TextCompare: true) == 0)
					{
						v71px4idkaq = OKepxEiP5ZD[j].revisao;
					}
					ComboRevisaoI.Text = v71px4idkaq;
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				throw;
			}
			finally
			{
				cDadosAccessInterligacao3.FechaConexao();
			}
			CarregaEquipamentos();
		}
	}

	public void CarregaEquipamentos()
	{
		if (shmpx9bXxT3 != 3)
		{
			return;
		}
		checked
		{
			shmpx9bXxT3++;
			dgEquipamentos.Rows.Clear();
			dgPotenciais.Rows.Clear();
			dgTag.Rows.Clear();
			dgTagInter.Rows.Clear();
			TgqpxVs11jd = new DeclaracoesFiacao.structurePnRev[1];
			try
			{
				vm8pxSG1mdc = "";
				v71px4idkaq = "";
				int num = dgRevisaoF.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (dgRevisaoF.Rows[i].Selected)
					{
						vm8pxSG1mdc = Conversions.ToString(dgRevisaoF.Rows[i].Cells[0].Value);
						break;
					}
				}
				v71px4idkaq = ComboRevisaoI.Text;
				if (Operators.CompareString(vm8pxSG1mdc, "", TextCompare: true) != 0)
				{
					cDadosAccessRelPot cDadosAccessRelPot2 = new cDadosAccessRelPot();
					cDadosAccessRelPot2.CarregaPnRevRelatPot(QVLpxiMd2aK, vm8pxSG1mdc, ref TgqpxVs11jd);
					cDadosAccessRelPot2.fechaConexao();
					if (Information.UBound(TgqpxVs11jd) > 0)
					{
						formataDGEquip();
					}
					int num2 = Information.UBound(TgqpxVs11jd);
					for (int j = 1; j <= num2; j++)
					{
						if (Operators.CompareString(TgqpxVs11jd[j].revisao, vm8pxSG1mdc, TextCompare: true) == 0)
						{
							dgEquipamentos.Rows.Add(TgqpxVs11jd[j].painel, Dicionario.BuscaNomeDoPainel(TgqpxVs11jd[j].painel));
							if (j == 1)
							{
								dgEquipamentos.Rows[0].Selected = true;
								as7pxCH7149 = TgqpxVs11jd[j].painel;
							}
						}
					}
					AtualizaDGEquip();
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
			CarregaDGPotenciais();
		}
	}

	public void CarregaDGPotenciais()
	{
		if (shmpx9bXxT3 != 4)
		{
			return;
		}
		checked
		{
			shmpx9bXxT3++;
			dgPotenciais.Rows.Clear();
			dgTag.Rows.Clear();
			dgTagInter.Rows.Clear();
			try
			{
				Relatorios_DistribuicaoPot.StructurePotenciais[] mPotenciais = new Relatorios_DistribuicaoPot.StructurePotenciais[1];
				cDadosAccessRelPot cDadosAccessRelPot2 = new cDadosAccessRelPot();
				cDadosAccessRelPot2.CarregaPotenciaisRelatorio(QVLpxiMd2aK, vm8pxSG1mdc, as7pxCH7149, ref mPotenciais);
				cDadosAccessRelPot2.fechaConexao();
				if (mPotenciais.Count() > 0)
				{
					formataDGPotenciais();
				}
				int num = mPotenciais.Length - 1;
				for (int i = 1; i <= num; i++)
				{
					dgPotenciais.Rows.Add(mPotenciais[i].iPotencial, mPotenciais[i].sNome);
					if (i == 1)
					{
						AtualizaDGPotenciais();
					}
				}
				if (dgPotenciais.Rows.Count - 1 >= 1)
				{
					int num2 = dgPotenciais.Rows.Count - 2;
					for (int j = 0; j <= num2; j++)
					{
						int num3 = dgPotenciais.Rows.Count - 2;
						int num4 = j;
						for (int k = num3; k >= num4; k += -1)
						{
							if (Operators.ConditionalCompareObjectGreater(dgPotenciais.Rows[k].Cells[1].Value, dgPotenciais.Rows[k + 1].Cells[1].Value, TextCompare: true))
							{
								int num5 = Conversions.ToInteger(dgPotenciais.Rows[k].Cells[0].Value);
								dgPotenciais.Rows[k].Cells[0].Value = RuntimeHelpers.GetObjectValue(dgPotenciais.Rows[k + 1].Cells[0].Value);
								dgPotenciais.Rows[k + 1].Cells[0].Value = num5;
								string value = Conversions.ToString(dgPotenciais.Rows[k].Cells[1].Value);
								dgPotenciais.Rows[k].Cells[1].Value = RuntimeHelpers.GetObjectValue(dgPotenciais.Rows[k + 1].Cells[1].Value);
								dgPotenciais.Rows[k + 1].Cells[1].Value = value;
							}
						}
					}
				}
				if (dgPotenciais.Rows.Count - 1 > 0)
				{
					dgPotenciais.Rows[0].Selected = false;
					formataDGTag();
				}
				AtualizaDGPotenciais();
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

	public void CarregaDGTags()
	{
		if (shmpx9bXxT3 != 5)
		{
			return;
		}
		checked
		{
			shmpx9bXxT3++;
			dgTag.Rows.Clear();
			try
			{
				if (dgPotenciais.SelectedRows.Count == 1)
				{
					SfwpxY5XdNt = Conversions.ToInteger(dgPotenciais.SelectedRows[0].Cells[0].Value);
					Relatorios_DistribuicaoPot.StructureTag[] mTag = new Relatorios_DistribuicaoPot.StructureTag[1];
					cDadosAccessRelPot cDadosAccessRelPot2 = new cDadosAccessRelPot();
					_ = (List<string>)cDadosAccessRelPot2.carregaTag1Relatorio(QVLpxiMd2aK, vm8pxSG1mdc, SfwpxY5XdNt, ref mTag);
					cDadosAccessRelPot2.fechaConexao();
					formataDGTag();
					int num = Information.UBound(mTag);
					for (int i = 1; i <= num; i++)
					{
						dgTag.Rows.Add(mTag[i].sTag, mTag[i].Terminal, mTag[i].Pagina, mTag[i].Indice, mTag[i].Tipo, mTag[i].Handle, mTag[i].POTENCIAL, mTag[i].sRegua);
					}
					AtualizaDGTag();
				}
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

	public void CarregaDGTagsInter()
	{
		cSppxrC5ZLU = "";
		checked
		{
			if (shmpx9bXxT3 == 6)
			{
				shmpx9bXxT3++;
				try
				{
					if (dgTag.SelectedRows.Count == 1)
					{
						cSppxrC5ZLU = Conversions.ToString(dgTag.SelectedRows[0].Cells[5].Value);
						Relatorios_DistribuicaoPot.StructureTag[] mTag = new Relatorios_DistribuicaoPot.StructureTag[1];
						cDadosAccessRelPot cDadosAccessRelPot2 = new cDadosAccessRelPot();
						_ = (List<string>)cDadosAccessRelPot2.carregaTag2Relatorio(QVLpxiMd2aK, vm8pxSG1mdc, v71px4idkaq, cSppxrC5ZLU, ref mTag);
						cDadosAccessRelPot2.fechaConexao();
						formataDGTagInter();
						dgTagInter.Rows.Clear();
						int num = Information.UBound(mTag);
						for (int i = 1; i <= num; i++)
						{
							dgTagInter.Rows.Add(mTag[i].sTag, mTag[i].Terminal, mTag[i].Pagina, mTag[i].Indice, mTag[i].Tipo, mTag[i].Handle, mTag[i].POTENCIAL, mTag[i].Indice, mTag[i].sPainel, mTag[i].sRegua);
						}
						AtualizaDGTagInter();
					}
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
			AtualizaDGTagInter();
		}
	}

	private void iwnpxwEI1UL(object P_0, EventArgs P_1)
	{
		checked
		{
			int num = dgDWG.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgDWG.Rows[i].Selected && QVLpxiMd2aK != Conversions.ToInteger(dgDWG.Rows[i].Cells[0].Value))
				{
					shmpx9bXxT3 = 2;
					QVLpxiMd2aK = Conversions.ToInteger(dgDWG.Rows[i].Cells[0].Value);
					CarregaDGRevisoes();
				}
			}
		}
	}

	private void OswpxxhJqU5(object P_0, EventArgs P_1)
	{
		checked
		{
			int num = dgRevisaoF.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgRevisaoF.Rows[i].Selected && Operators.ConditionalCompareObjectNotEqual(vm8pxSG1mdc, dgRevisaoF.Rows[i].Cells[0].Value, TextCompare: true))
				{
					vm8pxSG1mdc = Conversions.ToString(dgRevisaoF.Rows[i].Cells[0].Value);
					shmpx9bXxT3 = 3;
					CarregaEquipamentos();
				}
			}
		}
	}

	private void fs1pxbTlOAn(object P_0, KeyEventArgs P_1)
	{
		checked
		{
			int num = dgEquipamentos.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgEquipamentos.Rows[i].Selected && Operators.ConditionalCompareObjectNotEqual(as7pxCH7149, dgEquipamentos.Rows[i].Cells[0].Value, TextCompare: true))
				{
					as7pxCH7149 = Conversions.ToInteger(dgEquipamentos.Rows[i].Cells[0].Value);
					shmpx9bXxT3 = 4;
					CarregaDGPotenciais();
				}
			}
		}
	}

	private void SMkpxM26Zqa(object P_0, EventArgs P_1)
	{
		checked
		{
			int num = dgEquipamentos.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgEquipamentos.Rows[i].Selected && Operators.ConditionalCompareObjectNotEqual(as7pxCH7149, dgEquipamentos.Rows[i].Cells[0].Value, TextCompare: true))
				{
					as7pxCH7149 = Conversions.ToInteger(dgEquipamentos.Rows[i].Cells[0].Value);
					shmpx9bXxT3 = 4;
					CarregaDGPotenciais();
				}
			}
		}
	}

	private void zCTpxOHnYwC(object P_0, KeyEventArgs P_1)
	{
		if (!XtcpbT11hZg)
		{
			return;
		}
		formataDGTag();
		checked
		{
			int num = dgPotenciais.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgPotenciais.Rows[i].Selected)
				{
					SfwpxY5XdNt = Conversions.ToInteger(dgPotenciais.Rows[i].Cells[0].Value);
					shmpx9bXxT3 = 5;
					CarregaDGTags();
				}
			}
		}
	}

	private void yjqpxICb6eB(object P_0, EventArgs P_1)
	{
		if (!XtcpbT11hZg)
		{
			return;
		}
		formataDGTag();
		checked
		{
			int num = dgPotenciais.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgPotenciais.Rows[i].Selected)
				{
					SfwpxY5XdNt = Conversions.ToInteger(dgPotenciais.Rows[i].Cells[0].Value);
					shmpx9bXxT3 = 5;
					CarregaDGTags();
				}
			}
		}
	}

	private void cdqpx7uwWG3(object P_0, EventArgs P_1)
	{
		checked
		{
			int num = dgTag.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgTag.Rows[i].Selected && Operators.ConditionalCompareObjectNotEqual(cSppxrC5ZLU, dgTag.Rows[i].Cells[5].Value, TextCompare: true))
				{
					cSppxrC5ZLU = Conversions.ToString(dgTag.Rows[i].Cells[5].Value);
					shmpx9bXxT3 = 6;
					CarregaDGTagsInter();
				}
			}
		}
	}

	private void uXZpxqARPOJ(object P_0, EventArgs P_1)
	{
		shmpx9bXxT3 = 7;
	}

	private string b1QpxaWEyiR(string P_0, string P_1)
	{
		string text = "";
		text = ((Operators.CompareString(P_0.Trim(), "", TextCompare: true) == 0) ? P_1 : (P_0 + ":" + P_1));
		return text.Trim();
	}

	public void formataDGDWG()
	{
		try
		{
			dgDWG.Rows.Clear();
			dgDWG.Columns.Clear();
			dgDWG.Columns.Add("", "");
			dgDWG.Columns.Add("", Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 786], "     ")));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void formataDGRevisaoF()
	{
		try
		{
			dgRevisaoF.Rows.Clear();
			dgRevisaoF.Columns.Clear();
			dgRevisaoF.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1329]));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void formataDGEquip()
	{
		checked
		{
			try
			{
				dgEquipamentos.Rows.Clear();
				dgEquipamentos.Columns.Clear();
				dgEquipamentos.Columns.Add("", "Indice");
				dgEquipamentos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 748]));
				int num = dgEquipamentos.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgEquipamentos.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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
	}

	public void formataDGPotenciais()
	{
		checked
		{
			try
			{
				dgPotenciais.Rows.Clear();
				dgPotenciais.Columns.Clear();
				dgPotenciais.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 685]));
				dgPotenciais.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 513]));
				int num = dgPotenciais.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgPotenciais.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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
	}

	public void formataDGTag()
	{
		checked
		{
			try
			{
				dgTag.Rows.Clear();
				dgTag.Columns.Clear();
				dgTag.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 770]));
				dgTag.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1332]));
				dgTag.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1330]));
				dgTag.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1331]));
				dgTag.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 271]));
				dgTag.Columns.Add("", "Handle1");
				dgTag.Columns.Add("", "Potencial1");
				dgTag.Columns.Add("", "NRegua");
				int num = dgTag.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgTag.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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
	}

	public void formataDGTagInter()
	{
		checked
		{
			try
			{
				dgTagInter.Rows.Clear();
				dgTagInter.Columns.Clear();
				dgTagInter.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 770]));
				dgTagInter.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1156]));
				dgTagInter.Columns.Add("", "Pg");
				dgTagInter.Columns.Add("", "Indice");
				dgTagInter.Columns.Add("", "Tipo");
				dgTagInter.Columns.Add("", "Handle");
				dgTagInter.Columns.Add("", "Potencial");
				dgTagInter.Columns.Add("", "Indice");
				dgTagInter.Columns.Add("", "PN");
				dgTagInter.Columns.Add("", "Régua");
				int num = dgTagInter.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgTagInter.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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
	}

	public void AtualizaDGDWG()
	{
		checked
		{
			if (dgDWG.RowCount != 0)
			{
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgDWG)) ? ((double)(dgDWG.Width - 54)) : ((double)(dgDWG.Width - 71)));
				dgDWG.Columns[0].Width = 50;
				dgDWG.Columns[1].Width = (int)Math.Round(a);
				dgDWG.MultiSelect = false;
			}
		}
	}

	public void AtualizaDGRevisaoF()
	{
		checked
		{
			if (dgRevisaoF.RowCount != 0)
			{
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgRevisaoF)) ? ((double)(dgRevisaoF.Width - 4)) : ((double)(dgRevisaoF.Width - 21)));
				dgRevisaoF.Columns[0].Width = (int)Math.Round(a);
				dgRevisaoF.MultiSelect = false;
			}
		}
	}

	public void AtualizaDGEquip()
	{
		checked
		{
			if (dgEquipamentos.RowCount != 0)
			{
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgEquipamentos)) ? ((double)(dgEquipamentos.Width - 4)) : ((double)(dgEquipamentos.Width - 21)));
				dgEquipamentos.Columns[0].Width = 0;
				dgEquipamentos.Columns[0].Visible = false;
				dgEquipamentos.Columns[1].Width = (int)Math.Round(a);
				dgEquipamentos.MultiSelect = false;
			}
		}
	}

	public void AtualizaDGPotenciais()
	{
		checked
		{
			if (dgPotenciais.RowCount != 0)
			{
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgPotenciais)) ? ((double)(dgPotenciais.Width - 4)) : ((double)(dgPotenciais.Width - 21)));
				dgPotenciais.Columns[0].Width = 0;
				dgPotenciais.Columns[0].Visible = false;
				dgPotenciais.Columns[1].Width = (int)Math.Round(a);
				dgPotenciais.MultiSelect = false;
			}
		}
	}

	public void AtualizaDGTag()
	{
		checked
		{
			if (dgTag.RowCount != 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgTag)) ? ((double)(dgTag.Width - 4)) : ((double)(dgTag.Width - 21)));
				dgTag.Columns[0].Width = (int)Math.Round(num * 0.4);
				dgTag.Columns[1].Width = (int)Math.Round(num * 0.3);
				dgTag.Columns[2].Width = (int)Math.Round(num * 0.3);
				dgTag.Columns[3].Width = 0;
				dgTag.Columns[3].Visible = false;
				dgTag.Columns[4].Width = 0;
				dgTag.Columns[4].Visible = false;
				dgTag.Columns[5].Width = 0;
				dgTag.Columns[5].Visible = false;
				dgTag.Columns[6].Width = 0;
				dgTag.Columns[6].Visible = false;
				dgTag.Columns[7].Width = 0;
				dgTag.Columns[7].Visible = false;
				dgTag.MultiSelect = false;
			}
			else
			{
				dgTag.Rows.Clear();
				dgTag.Columns.Clear();
			}
		}
	}

	public void AtualizaDGTagInter()
	{
		checked
		{
			if (dgTagInter.RowCount != 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgTagInter)) ? ((double)(dgTagInter.Width - 4)) : ((double)(dgTagInter.Width - 21)));
				dgTagInter.Columns[0].Width = (int)Math.Round(num / 10.0);
				dgTagInter.Columns[1].Width = (int)Math.Round(num / 10.0);
				dgTagInter.Columns[2].Width = (int)Math.Round(num / 10.0);
				dgTagInter.Columns[3].Width = (int)Math.Round(num / 10.0);
				dgTagInter.Columns[4].Width = (int)Math.Round(num / 10.0);
				dgTagInter.Columns[5].Width = (int)Math.Round(num / 10.0);
				dgTagInter.Columns[6].Width = (int)Math.Round(num / 10.0);
				dgTagInter.Columns[7].Width = (int)Math.Round(num / 10.0);
				dgTagInter.Columns[8].Width = (int)Math.Round(num / 10.0);
				dgTagInter.Columns[9].Width = (int)Math.Round(num / 10.0);
				dgTagInter.MultiSelect = false;
			}
			else
			{
				dgTagInter.Rows.Clear();
				dgTagInter.Columns.Clear();
			}
		}
	}

	private void eMkpx8ZCDFl(object P_0, EventArgs P_1)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected Obj, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Invalid comparison between Unknown and I4
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0499: Unknown result type (might be due to invalid IL or missing references)
		//IL_049e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b7: Unknown result type (might be due to invalid IL or missing references)
		b1hpbJJADOO = "D";
		AF2pbh5emvd = "D";
		NZ9pboNT3uw = 20.0;
		S1fpbGlxKVY = 0;
		v71px4idkaq = ComboRevisaoI.Text;
		DeclaracoesGeral._uscPagina.pbFim();
		checked
		{
			try
			{
				int num = 0;
				Relatorios_DistribuicaoPot.StructurePontos[] array = new Relatorios_DistribuicaoPot.StructurePontos[1];
				Hide();
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				Point3d Point = new Point3d(0.0, 0.0, 0.0);
				Point3d PointBloco = new Point3d(0.0, 0.0, 0.0);
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				PromptPointResult val = (PromptPointResult)NewLateBinding.LateGet(editor, null, "GetPoint", new object[1] { Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 1339]) }, null, null, null);
				if (unchecked((int)((PromptResult)val).Status) != -5002)
				{
					Point3d value = val.Value;
					Point = new Point3d(Math.Round(value.X, 0), Math.Round(Point.Y, 0), 0.0);
					Relatorios_DistribuicaoPot.ApagaDistribuicaoPotenciais(vm8pxSG1mdc, ref QVLpxiMd2aK, ref SfwpxY5XdNt);
					DeclaracoesGeral.Reguas RH = default;
					XDataGeral.LeXDataReguaH(ref RH);
					DeclaracoesGeral.Reguas RH2 = default;
					XDataGeral.LeXDataReguaV(ref RH2);
					minAltura = Math.Round(RH.AltBase + 30.0, 0);
					oFdpbpkG9WS = Conversions.ToDouble(tbOrdenada.Text) - 19.187;
					value = val.Value;
					Point = new Point3d(Math.Round(value.X, 3), Math.Round(oFdpbpkG9WS, 3), 0.0);
					Relatorios_DistribuicaoPot.StructurePosicaoBlocos[] posBlocosADD = new Relatorios_DistribuicaoPot.StructurePosicaoBlocos[1];
					string sCaminho = Conversions.ToString(dgBlocos.SelectedRows[0].Cells[1].Value);
					string sBloco = Conversions.ToString(dgBlocos.SelectedRows[0].Cells[0].Value);
					Relatorios_DistribuicaoPot.StructureBloco bloco = default;
					GEZpxP6ZGSR(ref bloco);
					int num2 = dgTag.Rows.Count - 1;
					for (int i = 0; i <= num2; i++)
					{
						if (dgTag.RowCount <= 0)
						{
							continue;
						}
						if (i >= 3)
						{
							dgTag.FirstDisplayedScrollingRowIndex = i - 2;
						}
						dgTag.Rows[i].Selected = true;
						lKypxFtiC1s(ref bloco);
						Relatorios_DistribuicaoPot.CarregaNomeDosBlocos(i, ref bloco.sTipo, ref sCaminho, ref sBloco);
						if (i == 0)
						{
							bloco.sNome = Conversions.ToString(dgPotenciais.SelectedRows[0].Cells[1].Value);
						}
						CarregaDGTagsInter();
						if (dgTagInter.RowCount != 0)
						{
							bloco.bMostraPainel = true;
							S1fpbGlxKVY = dgTagInter.RowCount;
						}
						else
						{
							bloco.bMostraPainel = false;
							S1fpbGlxKVY = 0;
						}
						Relatorios_DistribuicaoPot.insereUmBlocoDoRelatorioDePotenciais(sCaminho, MkKpxz7ox88, sBloco, AF2pbh5emvd, bloco, ref Point, ref PointBloco, ref posBlocosADD);
						Application.UpdateScreen();
						if (bloco.bMostraPainel)
						{
							num++;
							array = (Relatorios_DistribuicaoPot.StructurePontos[])Utils.CopyArray(array, new Relatorios_DistribuicaoPot.StructurePontos[num + 1]);
							array[num].sNome = Conversions.ToString(dgTag.Rows[i].Cells[0].Value);
							array[num].sT1 = Conversions.ToString(dgTag.Rows[i].Cells[1].Value);
							PointBloco = new Point3d(PointBloco.X, PointBloco.Y + 2.0, 0.0);
							array[num].pt = PointBloco;
							array[num].sSentido = AF2pbh5emvd;
						}
						if (Operators.CompareString(AF2pbh5emvd, "D", TextCompare: true) != 0)
						{
							if (!(Point.Y + MkKpxz7ox88 + dWmpbWAKL6F > oFdpbpkG9WS))
							{
								if (i < dgTag.Rows.Count - 1)
								{
									Relatorios_DistribuicaoPot.insereLinhadORelatorioDePotenciais(0.0 - dWmpbWAKL6F, MkKpxz7ox88, ref AF2pbh5emvd, bloco, ref Point);
								}
							}
							else if (i < dgTag.Rows.Count - 1)
							{
								Relatorios_DistribuicaoPot.insereUmLinhaRelPotRetorno(dWmpbWAKL6F, MkKpxz7ox88, ref AF2pbh5emvd, ref b1hpbJJADOO, NZ9pboNT3uw, bloco, ref Point);
							}
						}
						else if (!(Point.Y + MkKpxz7ox88 + dWmpbWAKL6F < minAltura))
						{
							if (i < dgTag.Rows.Count - 1)
							{
								Relatorios_DistribuicaoPot.insereLinhadORelatorioDePotenciais(dWmpbWAKL6F, MkKpxz7ox88, ref AF2pbh5emvd, bloco, ref Point);
							}
						}
						else if (i < dgTag.Rows.Count - 1)
						{
							Relatorios_DistribuicaoPot.insereUmLinhaRelPotRetorno(dWmpbWAKL6F, MkKpxz7ox88, ref AF2pbh5emvd, ref b1hpbJJADOO, NZ9pboNT3uw, bloco, ref Point);
						}
						bloco.bPrimeiro = false;
						Application.UpdateScreen();
					}
					int num3 = num;
					for (int j = num3; j >= 1; j += -1)
					{
						int num4 = dgTag.Rows.Count - 1;
						for (int k = 0; k <= num4; k++)
						{
							if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(array[j].sNome, dgTag.Rows[k].Cells[0].Value, TextCompare: true), Operators.CompareObjectEqual(array[j].sT1, dgTag.Rows[k].Cells[1].Value, TextCompare: true))))
							{
								dgTag.Rows[k].Selected = true;
								ImupxQnB3EY(ref bloco);
								AdicionaInterligacaoInter(bloco, array[j].sSentido, array[j].pt, ref posBlocosADD, dgTagInter.Rows.Count);
								break;
							}
						}
					}
					if (dgTag.Rows.Count > 0)
					{
						dgTag.Rows[0].Selected = true;
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			Show();
			if (dgTag.Rows.Count - 1 > 0)
			{
				dgTag.FirstDisplayedScrollingRowIndex = 0;
			}
		}
	}

	private void chepxNHkjTj(object P_0, EventArgs P_1)
	{
		Relatorios_DistribuicaoPot.ApagaDistribuicaoPotenciais(vm8pxSG1mdc, ref QVLpxiMd2aK, ref SfwpxY5XdNt);
		Application.UpdateScreen();
	}

	public void AdicionaInterligacaoInter(Relatorios_DistribuicaoPot.StructureBloco Bloco, string sSentido, Point3d ptini, ref Relatorios_DistribuicaoPot.StructurePosicaoBlocos[] posBlocosADD, int quantidade)
	{
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_051e: Unknown result type (might be due to invalid IL or missing references)
		//IL_056b: Unknown result type (might be due to invalid IL or missing references)
		//IL_056d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac0: Unknown result type (might be due to invalid IL or missing references)
		bool flag = false;
		bool flag2 = false;
		double dDeslocamento_X = 20.0;
		if (Operators.CompareString(sSentido, "D", TextCompare: true) == 0)
		{
			ptini = new Point3d(ptini.X, ptini.Y - 4.0, 0.0);
		}
		if (Operators.CompareString(sSentido, "U", TextCompare: true) == 0)
		{
			ptini = new Point3d(ptini.X, ptini.Y - 4.0, 0.0);
		}
		int num = 1;
		checked
		{
			do
			{
				if (Operators.CompareString(NQopbkZ4BCD, "D", TextCompare: true) != 0)
				{
					if (calculaDistandiaLateralValida(ref ptini, minAltura, ref posBlocosADD, "E" + num, sSentido, ref dDeslocamento_X, quantidade, ref rItpbHyb73h, "D"))
					{
						flag2 = true;
						break;
					}
					if (calculaDistandiaLateralValida(ref ptini, minAltura, ref posBlocosADD, "D" + num, sSentido, ref dDeslocamento_X, quantidade, ref rItpbHyb73h, "D"))
					{
						flag2 = true;
						break;
					}
				}
				else
				{
					if (calculaDistandiaLateralValida(ref ptini, minAltura, ref posBlocosADD, "D" + num, sSentido, ref dDeslocamento_X, quantidade, ref rItpbHyb73h, "D"))
					{
						flag2 = true;
						break;
					}
					if (calculaDistandiaLateralValida(ref ptini, minAltura, ref posBlocosADD, "E" + num, sSentido, ref dDeslocamento_X, quantidade, ref rItpbHyb73h, "D"))
					{
						flag2 = true;
						break;
					}
				}
				num++;
			}
			while (num <= 10);
			if (!flag2)
			{
				return;
			}
			if (Operators.CompareString(Strings.Mid(rItpbHyb73h, 1, 1), "D", TextCompare: true) != 0)
			{
				NQopbkZ4BCD = "D";
			}
			else
			{
				NQopbkZ4BCD = "E";
			}
			Relatorios_DistribuicaoPot.StructureBloco structureBloco = Bloco;
			string sCaminho = "";
			string sBloco = "";
			Point3d PointBloco = new Point3d(0.0, 0.0, 0.0);
			dgTagInter.Rows[0].Selected = true;
			lKypxFtiC1s(ref structureBloco);
			Point3d Point = new Point3d(ptini.X + dDeslocamento_X, ptini.Y, 0.0);
			int num2 = dgTagInter.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				dgTagInter.Rows[i].Selected = true;
				structureBloco.sNome = Conversions.ToString(dgTagInter.SelectedRows[0].Cells[0].Value);
				structureBloco.sT1 = Conversions.ToString(dgTagInter.SelectedRows[0].Cells[1].Value);
				structureBloco.sTipo = Conversions.ToString(dgTagInter.SelectedRows[0].Cells[4].Value);
				structureBloco.sHandle = Conversions.ToString(dgTagInter.SelectedRows[0].Cells[5].Value);
				structureBloco.sRegua = Conversions.ToString(dgTagInter.SelectedRows[0].Cells[9].Value);
				structureBloco.sPn = structureBloco.sPn;
				structureBloco.sCorr = "?";
				structureBloco.sCorrComp = "";
				structureBloco.sDispComp = "";
				if (Operators.CompareString(clsTextos.TiraNothing(Conversions.ToString(dgTagInter.SelectedRows[0].Cells[9].Value)), "", TextCompare: true) != 0)
				{
					structureBloco.sRegua = Conversions.ToString(dgTagInter.SelectedRows[0].Cells[9].Value);
				}
				else
				{
					structureBloco.sRegua = Conversions.ToString(dgTagInter.SelectedRows[0].Cells[0].Value);
				}
				if (i != 0)
				{
					flag = false;
					structureBloco.bMostraPainel = false;
				}
				else
				{
					string sBloco2 = "";
					Relatorios_DistribuicaoPot.StructureBloco structureBloco2 = structureBloco;
					structureBloco2.sTipo = rItpbHyb73h;
					Relatorios_DistribuicaoPot.CarregaNomeDosBlocos(-1, ref structureBloco2.sTipo, ref sCaminho, ref sBloco2);
					Point3d Point2 = new Point3d(ptini.X, ptini.Y, 0.0);
					if (Point.Y + MkKpxz7ox88 + dWmpbWAKL6F < minAltura)
					{
						flag2 = false;
						dDeslocamento_X = 20.0;
						rItpbHyb73h = Strings.Mid(rItpbHyb73h, 1, 1) + "1";
						int num3 = 1;
						do
						{
							if (Operators.CompareString(NQopbkZ4BCD, "D", TextCompare: true) != 0)
							{
								if (calculaDistandiaLateralValida(ref Point, minAltura, ref posBlocosADD, "E" + num3, sSentido, ref dDeslocamento_X, quantidade, ref rItpbHyb73h, "D"))
								{
									flag2 = true;
									rItpbHyb73h = "E" + num3;
									break;
								}
								if (calculaDistandiaLateralValida(ref Point, minAltura, ref posBlocosADD, "D" + num3, sSentido, ref dDeslocamento_X, quantidade, ref rItpbHyb73h, "D"))
								{
									flag2 = true;
									rItpbHyb73h = "D" + num3;
									break;
								}
							}
							else
							{
								if (calculaDistandiaLateralValida(ref Point, minAltura, ref posBlocosADD, "D" + num3, sSentido, ref dDeslocamento_X, quantidade, ref rItpbHyb73h, "D"))
								{
									flag2 = true;
									rItpbHyb73h = "D" + num3;
									break;
								}
								if (calculaDistandiaLateralValida(ref Point, minAltura, ref posBlocosADD, "E" + num3, sSentido, ref dDeslocamento_X, quantidade, ref rItpbHyb73h, "D"))
								{
									flag2 = true;
									rItpbHyb73h = "E" + num3;
									break;
								}
							}
							num3++;
						}
						while (num3 <= 10);
						if (Operators.CompareString(Strings.Mid(rItpbHyb73h, 1, 1), "D", TextCompare: true) != 0)
						{
							NQopbkZ4BCD = "D";
						}
						else
						{
							NQopbkZ4BCD = "E";
						}
						b1hpbJJADOO = Strings.Mid(rItpbHyb73h, 1, 1) + "1";
					}
					Relatorios_DistribuicaoPot.insereUmLinhaRelPotDeslocamento(dWmpbWAKL6F, MkKpxz7ox88, "D", b1hpbJJADOO, dDeslocamento_X, Bloco, ref Point2);
					flag = true;
					sSentido = "D";
					Point = Point2;
					structureBloco.bMostraPainel = true;
				}
				if (!flag)
				{
					Relatorios_DistribuicaoPot.CarregaNomeDosBlocos(-1, ref structureBloco.sTipo, ref sCaminho, ref sBloco);
				}
				else
				{
					string sTipo = "B";
					Relatorios_DistribuicaoPot.CarregaNomeDosBlocos(-1, ref sTipo, ref sCaminho, ref sBloco);
					flag = false;
				}
				Relatorios_DistribuicaoPot.insereUmBlocoDoRelatorioDePotenciais(sCaminho, MkKpxz7ox88, sBloco, "D", structureBloco, ref Point, ref PointBloco, ref posBlocosADD);
				if (Operators.CompareString(sSentido, "D", TextCompare: true) != 0)
				{
					if (Operators.CompareString(sSentido, "U", TextCompare: true) != 0)
					{
						if (Operators.CompareString(sSentido, "S", TextCompare: true) == 0)
						{
							Point = new Point3d(Point.X, Point.Y + 11.0, 0.0);
							if (i < dgTagInter.Rows.Count - 1)
							{
								Relatorios_DistribuicaoPot.insereUmLinhaRelPot2(dWmpbWAKL6F, MkKpxz7ox88, ref sSentido, structureBloco, ref Point);
							}
							Point = new Point3d(Point.X, Point.Y + 7.0, 0.0);
							sSentido = "S";
						}
					}
					else if (!(Point.Y + MkKpxz7ox88 + dWmpbWAKL6F > minAltura))
					{
						sSentido = "S";
						if (!(Point.Y + MkKpxz7ox88 + dWmpbWAKL6F < minAltura))
						{
							Point = new Point3d(Point.X, Point.Y + 7.0, 0.0);
							if (i < dgTagInter.Rows.Count - 1)
							{
								Relatorios_DistribuicaoPot.insereLinhadORelatorioDePotenciais(dWmpbWAKL6F, MkKpxz7ox88, ref sSentido, structureBloco, ref Point);
							}
							Point = new Point3d(Point.X, Point.Y - 2.0, 0.0);
						}
						else
						{
							flag2 = false;
							dDeslocamento_X = 20.0;
							rItpbHyb73h = Strings.Mid(rItpbHyb73h, 1, 1) + "1";
							int num4 = 1;
							do
							{
								if (Operators.CompareString(NQopbkZ4BCD, "D", TextCompare: true) != 0)
								{
									if (calculaDistandiaLateralValida(ref Point, minAltura, ref posBlocosADD, "E" + num4, sSentido, ref dDeslocamento_X, quantidade, ref rItpbHyb73h, "U"))
									{
										flag2 = true;
										rItpbHyb73h = "E" + num4;
										break;
									}
									if (calculaDistandiaLateralValida(ref Point, minAltura, ref posBlocosADD, "D" + num4, sSentido, ref dDeslocamento_X, quantidade, ref rItpbHyb73h, "U"))
									{
										flag2 = true;
										rItpbHyb73h = "D" + num4;
										break;
									}
								}
								else
								{
									if (calculaDistandiaLateralValida(ref Point, minAltura, ref posBlocosADD, "D" + num4, sSentido, ref dDeslocamento_X, quantidade, ref rItpbHyb73h, "U"))
									{
										flag2 = true;
										rItpbHyb73h = "D" + num4;
										break;
									}
									if (calculaDistandiaLateralValida(ref Point, minAltura, ref posBlocosADD, "E" + num4, sSentido, ref dDeslocamento_X, quantidade, ref rItpbHyb73h, "U"))
									{
										flag2 = true;
										rItpbHyb73h = "E" + num4;
										break;
									}
								}
								num4++;
							}
							while (num4 <= 10);
							if (Operators.CompareString(Strings.Mid(rItpbHyb73h, 1, 1), "D", TextCompare: true) != 0)
							{
								NQopbkZ4BCD = "D";
							}
							else
							{
								NQopbkZ4BCD = "E";
							}
							if (i < dgTagInter.Rows.Count - 1)
							{
								Relatorios_DistribuicaoPot.insereUmLinhaRelPotRetorno(dWmpbWAKL6F, MkKpxz7ox88, ref sSentido, ref b1hpbJJADOO, dDeslocamento_X, structureBloco, ref Point);
								sSentido = "S";
							}
						}
						sSentido = "S";
					}
					else
					{
						Point = new Point3d(Point.X, Point.Y + 2.0, 0.0);
						if (i < dgTagInter.Rows.Count - 1)
						{
							Relatorios_DistribuicaoPot.insereUmLinhaRelPot2(dWmpbWAKL6F, MkKpxz7ox88, ref sSentido, structureBloco, ref Point);
						}
						Point = new Point3d(Point.X, Point.Y - 2.0, 0.0);
					}
					continue;
				}
				if (!(Point.Y + MkKpxz7ox88 + dWmpbWAKL6F < minAltura))
				{
					if (i < dgTagInter.Rows.Count - 1)
					{
						Relatorios_DistribuicaoPot.insereLinhadORelatorioDePotenciais(dWmpbWAKL6F, MkKpxz7ox88, ref sSentido, structureBloco, ref Point);
					}
					continue;
				}
				flag2 = false;
				dDeslocamento_X = 20.0;
				rItpbHyb73h = Strings.Mid(rItpbHyb73h, 1, 1) + "1";
				int num5 = 1;
				do
				{
					if (Operators.CompareString(NQopbkZ4BCD, "D", TextCompare: true) != 0)
					{
						if (calculaDistandiaLateralValida(ref Point, minAltura, ref posBlocosADD, "E" + num5, sSentido, ref dDeslocamento_X, quantidade, ref rItpbHyb73h, "U", bRetorno: true))
						{
							flag2 = true;
							rItpbHyb73h = "E" + num5;
							break;
						}
						if (calculaDistandiaLateralValida(ref Point, minAltura, ref posBlocosADD, "D" + num5, sSentido, ref dDeslocamento_X, quantidade, ref rItpbHyb73h, "U", bRetorno: true))
						{
							flag2 = true;
							rItpbHyb73h = "D" + num5;
							break;
						}
					}
					else
					{
						if (calculaDistandiaLateralValida(ref Point, minAltura, ref posBlocosADD, "D" + num5, sSentido, ref dDeslocamento_X, quantidade, ref rItpbHyb73h, "U", bRetorno: true))
						{
							flag2 = true;
							rItpbHyb73h = "D" + num5;
							break;
						}
						if (calculaDistandiaLateralValida(ref Point, minAltura, ref posBlocosADD, "E" + num5, sSentido, ref dDeslocamento_X, quantidade, ref rItpbHyb73h, "U", bRetorno: true))
						{
							flag2 = true;
							rItpbHyb73h = "E" + num5;
							break;
						}
					}
					num5++;
				}
				while (num5 <= 10);
				if (Operators.CompareString(Strings.Mid(rItpbHyb73h, 1, 1), "D", TextCompare: true) != 0)
				{
					NQopbkZ4BCD = "D";
				}
				else
				{
					NQopbkZ4BCD = "E";
				}
				if (i < dgTagInter.Rows.Count - 1)
				{
					Relatorios_DistribuicaoPot.insereUmLinhaRelPotRetorno(dWmpbWAKL6F, MkKpxz7ox88, ref sSentido, ref b1hpbJJADOO, dDeslocamento_X, structureBloco, ref Point);
					sSentido = "S";
				}
			}
		}
	}

	public static bool calculaDistandiaLateralValida(ref Point3d ptIni, double minAltura, ref Relatorios_DistribuicaoPot.StructurePosicaoBlocos[] posBlocosADD, string LadoD_E, string sSentido, ref double dDeslocamento_X, int quantidade, ref string sTipoBloco, string U_D, bool bRetorno = false)
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		bool result = true;
		sTipoBloco = LadoD_E;
		string left = Strings.Mid(LadoD_E, 1, 1);
		if (Operators.CompareString(left, "D", TextCompare: true) != 0)
		{
			if (Operators.CompareString(left, "E", TextCompare: true) == 0)
			{
				dDeslocamento_X = 0.0 - 20.0 * Conversions.ToDouble(Strings.Mid(LadoD_E, 2, 1));
			}
		}
		else
		{
			dDeslocamento_X = 20.0 * Conversions.ToDouble(Strings.Mid(LadoD_E, 2, 1));
		}
		double num = 0.0;
		num = ((Operators.CompareString(U_D, "D", TextCompare: true) == 0) ? 7.0 : 11.0);
		Point3d pt = new Point3d(0.0, 0.0, 0.0);
		if (bRetorno)
		{
			pt = new Point3d(ptIni.X + dDeslocamento_X, ptIni.Y + 2.0, 0.0);
			if (Relatorios_DistribuicaoPot.ExistePontoNaLista(ref posBlocosADD, pt))
			{
				result = false;
				goto IL_01fa;
			}
		}
		for (int i = 0; i <= quantidade; i = checked(i + 1))
		{
			if (i > 0)
			{
				num = ((Operators.CompareString(Strings.Mid(LadoD_E, 1, 1), "D", TextCompare: true) == 0) ? (num + 9.0) : (num + 9.0));
			}
			if (Operators.CompareString(U_D, "D", TextCompare: true) == 0)
			{
				pt = new Point3d(ptIni.X + dDeslocamento_X, ptIni.Y - num, 0.0);
			}
			if (Operators.CompareString(U_D, "U", TextCompare: true) == 0)
			{
				pt = new Point3d(ptIni.X + dDeslocamento_X, ptIni.Y + num, 0.0);
			}
			if (Relatorios_DistribuicaoPot.ExistePontoNaLista(ref posBlocosADD, pt))
			{
				result = false;
				break;
			}
		}
		goto IL_01fa;
		IL_01fa:
		return result;
	}

	private void lKypxFtiC1s(ref Relatorios_DistribuicaoPot.StructureBloco P_0)
	{
		P_0.sTipo = Conversions.ToString(dgTag.SelectedRows[0].Cells[4].Value);
		P_0.sNome = Conversions.ToString(dgTag.SelectedRows[0].Cells[0].Value);
		P_0.sRegua = Conversions.ToString(dgTag.SelectedRows[0].Cells[0].Value);
		P_0.sCorr = "?";
		P_0.sCorrComp = " ";
		P_0.sDispComp = " ";
		P_0.sT2 = " ";
		P_0.sT1 = Conversions.ToString(dgTag.SelectedRows[0].Cells[1].Value);
		P_0.sHandle = Conversions.ToString(dgTag.SelectedRows[0].Cells[5].Value);
	}

	private void ImupxQnB3EY(ref Relatorios_DistribuicaoPot.StructureBloco P_0)
	{
		P_0.sTipo = Conversions.ToString(dgTagInter.SelectedRows[0].Cells[4].Value);
		P_0.sNome = Conversions.ToString(dgTagInter.SelectedRows[0].Cells[0].Value);
		if (Operators.CompareString(clsTextos.TiraNothing(Conversions.ToString(dgTagInter.SelectedRows[0].Cells[9].Value)), "", TextCompare: true) != 0)
		{
			P_0.sRegua = Conversions.ToString(dgTagInter.SelectedRows[0].Cells[9].Value);
		}
		else
		{
			P_0.sRegua = Conversions.ToString(dgTagInter.SelectedRows[0].Cells[0].Value);
		}
		P_0.sCorr = "?";
		P_0.sCorrComp = "";
		P_0.sDispComp = "";
		P_0.sT1 = Conversions.ToString(dgTagInter.SelectedRows[0].Cells[1].Value);
		P_0.sT2 = " ";
		P_0.sHandle = Conversions.ToString(dgTagInter.SelectedRows[0].Cells[5].Value);
		P_0.sPn = Conversions.ToString(dgTagInter.SelectedRows[0].Cells[8].Value);
	}

	private void GEZpxP6ZGSR(ref Relatorios_DistribuicaoPot.StructureBloco P_0)
	{
		P_0.iDwg = QVLpxiMd2aK;
		P_0.sRevisao = vm8pxSG1mdc;
		P_0.iPn = Conversions.ToInteger(dgEquipamentos.SelectedRows[0].Cells[0].Value);
		P_0.sPn = Conversions.ToString(dgEquipamentos.SelectedRows[0].Cells[1].Value);
		P_0.iPot = Conversions.ToInteger(dgPotenciais.SelectedRows[0].Cells[0].Value);
		P_0.sT1 = " ";
		P_0.sT2 = " ";
		P_0.bPrimeiro = true;
		P_0.sTipo = " ";
		P_0.sRegua = " ";
		P_0.Eletron = 4;
	}

	private void SxUpxcib8V3(object P_0, EventArgs P_1)
	{
		AtualizaDGDWG();
		AtualizaDGRevisaoF();
		AtualizaDGEquip();
		AtualizaDGPotenciais();
		AtualizaDGTag();
	}

	private void JqtpxKkM0JO(object P_0, EventArgs P_1)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Invalid comparison between Unknown and I4
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			_ = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			PromptPointResult val2 = (PromptPointResult)NewLateBinding.LateGet(editor, null, "GetPoint", new object[1] { Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 1029]) }, null, null, null);
			if ((int)((PromptResult)val2).Status != -5002)
			{
				TextBox textBox = tbOrdenada;
				Point3d value = val2.Value;
				textBox.Text = Math.Round(value.Y, 2).ToString();
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
}
