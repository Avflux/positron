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
public class frmRelatorio_Fiacao : Form
{
	private IContainer fRqpblylmyx;

	[AccessedThroughProperty("dgRevisao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView P9Kpb5BZXIq;

	[AccessedThroughProperty("dgEquip")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView mTipb0OSay7;

	[AccessedThroughProperty("dgDisp")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView TCFpbRkaK21;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("dgFiacao")]
	private DataGridView EDkpbm8526J;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btPesquisar")]
	private Button LIepbXcUVt0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbAlternativo")]
	private CheckBox jr3pbUde5aU;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgDWG")]
	private DataGridView LPBpbyO8VIv;

	[AccessedThroughProperty("GroupBox1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox pSQpbgdyU3k;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbReguas")]
	private RadioButton HSQpbAr034O;

	[AccessedThroughProperty("rbDispositivos")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton QiUpbshVjl9;

	[AccessedThroughProperty("GroupBox2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox j7ZpbBsuVuo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbUsados")]
	private RadioButton tKMpbVw7OO9;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbTodos")]
	private RadioButton uBUpbuIAcvY;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExportaDWG")]
	private Button FfgpbESLCXP;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExportaEXCEL")]
	private Button S8rpbZl3tqQ;

	[CompilerGenerated]
	[AccessedThroughProperty("cbLayout")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox u6npbioJCYI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbAlterarOrdem")]
	private CheckBox LrdpbSOlZoD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip wgLpb4PGK4C;

	private DeclaracoesFiacao.structurePnRev[] kHdpbC0cLYi;

	private DeclaracoesFiacao.structureRevisoes[] VAZpbYmLuNv;

	private int BRApbrurRjf;

	private string C8bpb90qTcY;

	private int QgLpbzVhJ9A;

	private string huupMWF9hRN;

	private int hUHpMpnDkp9;

	private bool DZxpMTLJc1j;

	private bool YT7pMJCEAl8;

	private bool CXppMhg2Q32;

	private DeclaracoesFiacao.structureRelFiacao[] IMapMooGMZj;

	private int iY3pMG6LuKI;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return P9Kpb5BZXIq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AospbvKSOkR;
			DataGridView dataGridView = P9Kpb5BZXIq;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			P9Kpb5BZXIq = value;
			dataGridView = P9Kpb5BZXIq;
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
			return mTipb0OSay7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Woqpbtvoicw;
			DataGridView dataGridView = mTipb0OSay7;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			mTipb0OSay7 = value;
			dataGridView = mTipb0OSay7;
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
			return TCFpbRkaK21;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = Euepbe46O57;
			DragEventHandler value3 = Mu9pb2dEQwH;
			DragEventHandler value4 = xbwpb3wBAhx;
			KeyEventHandler value5 = MU3pbnfKgH1;
			DataGridView dataGridView = TCFpbRkaK21;
			if (dataGridView != null)
			{
				dataGridView.MouseDown -= value2;
				dataGridView.DragDrop -= value3;
				dataGridView.DragEnter -= value4;
				dataGridView.KeyDown -= value5;
			}
			TCFpbRkaK21 = value;
			dataGridView = TCFpbRkaK21;
			if (dataGridView != null)
			{
				dataGridView.MouseDown += value2;
				dataGridView.DragDrop += value3;
				dataGridView.DragEnter += value4;
				dataGridView.KeyDown += value5;
			}
		}
	}

	internal virtual DataGridView dgFiacao
	{
		[CompilerGenerated]
		get
		{
			return EDkpbm8526J;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EDkpbm8526J = value;
		}
	}

	internal virtual Button btPesquisar
	{
		[CompilerGenerated]
		get
		{
			return LIepbXcUVt0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = R9dpbbD9Jbg;
			Button button = LIepbXcUVt0;
			if (button != null)
			{
				button.Click -= value2;
			}
			LIepbXcUVt0 = value;
			button = LIepbXcUVt0;
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
			return jr3pbUde5aU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tQqpbNHL9Nq;
			CheckBox checkBox = jr3pbUde5aU;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			jr3pbUde5aU = value;
			checkBox = jr3pbUde5aU;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgDWG
	{
		[CompilerGenerated]
		get
		{
			return LPBpbyO8VIv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QnkpbfvAkNq;
			DataGridView dataGridView = LPBpbyO8VIv;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			LPBpbyO8VIv = value;
			dataGridView = LPBpbyO8VIv;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return pSQpbgdyU3k;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pSQpbgdyU3k = value;
		}
	}

	internal virtual RadioButton rbReguas
	{
		[CompilerGenerated]
		get
		{
			return HSQpbAr034O;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = I9bpb1lWO3n;
			RadioButton radioButton = HSQpbAr034O;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			HSQpbAr034O = value;
			radioButton = HSQpbAr034O;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton rbDispositivos
	{
		[CompilerGenerated]
		get
		{
			return QiUpbshVjl9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = HiMpbjeMrXb;
			RadioButton radioButton = QiUpbshVjl9;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			QiUpbshVjl9 = value;
			radioButton = QiUpbshVjl9;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return j7ZpbBsuVuo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			j7ZpbBsuVuo = value;
		}
	}

	internal virtual RadioButton rbUsados
	{
		[CompilerGenerated]
		get
		{
			return tKMpbVw7OO9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tKMpbVw7OO9 = value;
		}
	}

	internal virtual RadioButton rbTodos
	{
		[CompilerGenerated]
		get
		{
			return uBUpbuIAcvY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			uBUpbuIAcvY = value;
		}
	}

	internal virtual Button btExportaDWG
	{
		[CompilerGenerated]
		get
		{
			return FfgpbESLCXP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = l0wpbw8iOmj;
			Button button = FfgpbESLCXP;
			if (button != null)
			{
				button.Click -= value2;
			}
			FfgpbESLCXP = value;
			button = FfgpbESLCXP;
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
			return S8rpbZl3tqQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = JVgpbxsaP9W;
			Button button = S8rpbZl3tqQ;
			if (button != null)
			{
				button.Click -= value2;
			}
			S8rpbZl3tqQ = value;
			button = S8rpbZl3tqQ;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox cbLayout
	{
		[CompilerGenerated]
		get
		{
			return u6npbioJCYI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = BjxpbFfC75r;
			CheckBox checkBox = u6npbioJCYI;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			u6npbioJCYI = value;
			checkBox = u6npbioJCYI;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox cbAlterarOrdem
	{
		[CompilerGenerated]
		get
		{
			return LrdpbSOlZoD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ny8pbQuJjXS;
			CheckBox checkBox = LrdpbSOlZoD;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			LrdpbSOlZoD = value;
			checkBox = LrdpbSOlZoD;
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
			if (disposing && fRqpblylmyx != null)
			{
				fRqpblylmyx.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void q4lpbdbLUhU()
	{
		fRqpblylmyx = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmRelatorio_Fiacao));
		dgRevisao = new DataGridView();
		dgEquip = new DataGridView();
		dgDisp = new DataGridView();
		dgFiacao = new DataGridView();
		btPesquisar = new Button();
		cbAlternativo = new CheckBox();
		dgDWG = new DataGridView();
		GroupBox1 = new GroupBox();
		rbReguas = new RadioButton();
		rbDispositivos = new RadioButton();
		GroupBox2 = new GroupBox();
		rbUsados = new RadioButton();
		rbTodos = new RadioButton();
		btExportaDWG = new Button();
		btExportaEXCEL = new Button();
		cbLayout = new CheckBox();
		cbAlterarOrdem = new CheckBox();
		FDqpBiUmZij(new ToolTip(fRqpblylmyx));
		((ISupportInitialize)dgRevisao).BeginInit();
		((ISupportInitialize)dgEquip).BeginInit();
		((ISupportInitialize)dgDisp).BeginInit();
		((ISupportInitialize)dgFiacao).BeginInit();
		((ISupportInitialize)dgDWG).BeginInit();
		GroupBox1.SuspendLayout();
		GroupBox2.SuspendLayout();
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
		dgEquip.Size = new Size(155, 201);
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
		dgDisp.Size = new Size(194, 230);
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
		dgFiacao.Size = new Size(684, 505);
		dgFiacao.TabIndex = 11;
		btPesquisar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisar.FlatStyle = FlatStyle.Flat;
		btPesquisar.ForeColor = SystemColors.Control;
		btPesquisar.Image = Resources.Pesquisar_32;
		btPesquisar.Location = new Point(174, 481);
		btPesquisar.Name = "btPesquisar";
		btPesquisar.Size = new Size(40, 42);
		btPesquisar.TabIndex = 15;
		btPesquisar.UseVisualStyleBackColor = true;
		cbAlternativo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		cbAlternativo.AutoSize = true;
		cbAlternativo.Location = new Point(173, 458);
		cbAlternativo.Name = "cbAlternativo";
		cbAlternativo.Size = new Size(76, 17);
		cbAlternativo.TabIndex = 16;
		cbAlternativo.Text = "Alternativo";
		cbAlternativo.UseVisualStyleBackColor = true;
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
		GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox1.Controls.Add(rbReguas);
		GroupBox1.Controls.Add(rbDispositivos);
		GroupBox1.Location = new Point(12, 396);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(155, 60);
		GroupBox1.TabIndex = 18;
		GroupBox1.TabStop = false;
		rbReguas.AutoSize = true;
		rbReguas.Location = new Point(6, 35);
		rbReguas.Name = "rbReguas";
		rbReguas.Size = new Size(113, 17);
		rbReguas.TabIndex = 1;
		rbReguas.TabStop = true;
		rbReguas.Text = "Réguas de Bornes";
		rbReguas.UseVisualStyleBackColor = true;
		rbDispositivos.AutoSize = true;
		rbDispositivos.Location = new Point(6, 15);
		rbDispositivos.Name = "rbDispositivos";
		rbDispositivos.Size = new Size(81, 17);
		rbDispositivos.TabIndex = 0;
		rbDispositivos.TabStop = true;
		rbDispositivos.Text = "Dispositivos";
		rbDispositivos.UseVisualStyleBackColor = true;
		GroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox2.Controls.Add(rbUsados);
		GroupBox2.Controls.Add(rbTodos);
		GroupBox2.Location = new Point(12, 458);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(155, 59);
		GroupBox2.TabIndex = 19;
		GroupBox2.TabStop = false;
		rbUsados.AutoSize = true;
		rbUsados.Location = new Point(6, 35);
		rbUsados.Name = "rbUsados";
		rbUsados.Size = new Size(107, 17);
		rbUsados.TabIndex = 1;
		rbUsados.TabStop = true;
		rbUsados.Text = "Terminais usados";
		rbUsados.UseVisualStyleBackColor = true;
		rbTodos.AutoSize = true;
		rbTodos.Location = new Point(6, 15);
		rbTodos.Name = "rbTodos";
		rbTodos.Size = new Size(113, 17);
		rbTodos.TabIndex = 0;
		rbTodos.TabStop = true;
		rbTodos.Text = "Todos os terminais";
		rbTodos.UseVisualStyleBackColor = true;
		btExportaDWG.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btExportaDWG.FlatStyle = FlatStyle.Flat;
		btExportaDWG.ForeColor = SystemColors.Control;
		btExportaDWG.Image = (Image)componentResourceManager.GetObject("btExportaDWG.Image");
		btExportaDWG.Location = new Point(246, 480);
		btExportaDWG.Name = "btExportaDWG";
		btExportaDWG.Size = new Size(40, 42);
		btExportaDWG.TabIndex = 40;
		btExportaDWG.UseVisualStyleBackColor = true;
		btExportaEXCEL.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btExportaEXCEL.FlatStyle = FlatStyle.Flat;
		btExportaEXCEL.ForeColor = SystemColors.Control;
		btExportaEXCEL.Image = Resources.ExportaExcel_20;
		btExportaEXCEL.Location = new Point(317, 480);
		btExportaEXCEL.Name = "btExportaEXCEL";
		btExportaEXCEL.Size = new Size(40, 42);
		btExportaEXCEL.TabIndex = 41;
		btExportaEXCEL.UseVisualStyleBackColor = true;
		cbLayout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		cbLayout.AutoSize = true;
		cbLayout.Location = new Point(266, 457);
		cbLayout.Name = "cbLayout";
		cbLayout.Size = new Size(92, 17);
		cbLayout.TabIndex = 42;
		cbLayout.Text = "Ordem Layout";
		cbLayout.UseVisualStyleBackColor = true;
		cbAlterarOrdem.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		cbAlterarOrdem.AutoSize = true;
		cbAlterarOrdem.Location = new Point(173, 435);
		cbAlterarOrdem.Name = "cbAlterarOrdem";
		cbAlterarOrdem.Size = new Size(149, 17);
		cbAlterarOrdem.TabIndex = 43;
		cbAlterarOrdem.Text = "Alterar Ordem Dispositivos";
		cbAlterarOrdem.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(1069, 529);
		Controls.Add(cbAlterarOrdem);
		Controls.Add(cbLayout);
		Controls.Add(btExportaEXCEL);
		Controls.Add(btExportaDWG);
		Controls.Add(GroupBox2);
		Controls.Add(GroupBox1);
		Controls.Add(dgDWG);
		Controls.Add(cbAlternativo);
		Controls.Add(btPesquisar);
		Controls.Add(dgFiacao);
		Controls.Add(dgDisp);
		Controls.Add(dgEquip);
		Controls.Add(dgRevisao);
		MinimumSize = new Size(1000, 568);
		Name = "frmRelatorio_Fiacao";
		ShowIcon = false;
		ShowInTaskbar = false;
		Text = "Relatórios de Fiação";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		((ISupportInitialize)dgDisp).EndInit();
		((ISupportInitialize)dgFiacao).EndInit();
		((ISupportInitialize)dgDWG).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return wgLpb4PGK4C;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		wgLpb4PGK4C = WithEventsValue;
	}

	public frmRelatorio_Fiacao()
	{
		Resize += yYHpbcbLyTb;
		kHdpbC0cLYi = new DeclaracoesFiacao.structurePnRev[1];
		VAZpbYmLuNv = new DeclaracoesFiacao.structureRevisoes[1];
		BRApbrurRjf = 0;
		C8bpb90qTcY = "";
		QgLpbzVhJ9A = 0;
		huupMWF9hRN = "";
		hUHpMpnDkp9 = 0;
		DZxpMTLJc1j = false;
		YT7pMJCEAl8 = false;
		CXppMhg2Q32 = false;
		iY3pMG6LuKI = 0;
		try
		{
			if (!Geral.ExisteForm("frmRelatorio_Fiacao"))
			{
				q4lpbdbLUhU();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 590]);
				cbAlterarOrdem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 796]);
				cbAlternativo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 785]);
				cbLayout.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 795]);
				rbDispositivos.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 518]);
				rbReguas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 788]);
				rbTodos.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 792]);
				rbUsados.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 793]);
				w8dpBZ0kvSD().SetToolTip(btPesquisar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 775]));
				cDadosAccess.carregaDadosDWG();
				Application.ShowModelessDialog((Form)this);
				formataDGDWG();
				formataDGRevisao();
				formataDGEquip();
				formataDGDisp();
				AtualizaDGDisp();
				CarregaDGDWG();
				DeclaracoesFiacao.ilinhaCEMIGD = 1;
				FiacaoExcel.mIndiceExcel = new FiacaoExcel.StructureIndiceRelatorio[1];
				cbAlternativo.Checked = false;
				rbDispositivos.Checked = true;
				rbTodos.Checked = true;
				cbLayout.Checked = false;
				cbAlterarOrdem.Checked = false;
				formataDGFiacao();
				AtualizaDGDWG();
				AtualizaDGRevisao();
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

	private void QnkpbfvAkNq(object P_0, EventArgs P_1)
	{
		DZxpMTLJc1j = true;
		dgRevisao.Rows.Clear();
		DZxpMTLJc1j = false;
		YT7pMJCEAl8 = true;
		dgEquip.Rows.Clear();
		YT7pMJCEAl8 = false;
		CXppMhg2Q32 = true;
		dgDisp.Rows.Clear();
		CXppMhg2Q32 = false;
		BHrpbDpQVTU();
	}

	private void BHrpbDpQVTU()
	{
		BRApbrurRjf = Conversions.ToInteger(dgDWG.SelectedRows[0].Cells[0].Value);
		VAZpbYmLuNv = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			cDadosAccessFiacao2.CarregaRevisoesDwgCorrente(BRApbrurRjf, ref VAZpbYmLuNv);
			DZxpMTLJc1j = true;
			dgRevisao.Rows.Clear();
			DZxpMTLJc1j = false;
			int num = Information.UBound(VAZpbYmLuNv);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				dgRevisao.Rows.Add(VAZpbYmLuNv[i].revisao);
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

	private void AospbvKSOkR(object P_0, EventArgs P_1)
	{
		YT7pMJCEAl8 = true;
		dgEquip.Rows.Clear();
		YT7pMJCEAl8 = false;
		CXppMhg2Q32 = true;
		dgDisp.Rows.Clear();
		CXppMhg2Q32 = false;
		if (!DZxpMTLJc1j)
		{
			frupb6bMQY4();
			AtualizaDGEquip();
		}
	}

	private void frupb6bMQY4()
	{
		CarregaPnRev();
		try
		{
			if (dgRevisao.SelectedRows.Count != 1)
			{
				return;
			}
			C8bpb90qTcY = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
			YT7pMJCEAl8 = true;
			dgEquip.Rows.Clear();
			YT7pMJCEAl8 = false;
			int num = Information.UBound(kHdpbC0cLYi);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(kHdpbC0cLYi[i].revisao, C8bpb90qTcY, TextCompare: true) == 0)
				{
					dgEquip.Rows.Add(kHdpbC0cLYi[i].painel, Dicionario.BuscaNomeDoPainel(kHdpbC0cLYi[i].painel));
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
		kHdpbC0cLYi = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (Information.UBound(VAZpbYmLuNv) > 0)
			{
				int num = Information.UBound(VAZpbYmLuNv);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessFiacao2.CarregaPnRev(BRApbrurRjf, VAZpbYmLuNv[i].revisao, ref kHdpbC0cLYi);
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

	private void Woqpbtvoicw(object P_0, EventArgs P_1)
	{
		CXppMhg2Q32 = true;
		formataDGDisp();
		CXppMhg2Q32 = false;
		if (!YT7pMJCEAl8)
		{
			ncCpbLdQ56n();
		}
		AtualizaDGDisp();
	}

	private void HiMpbjeMrXb(object P_0, EventArgs P_1)
	{
		CXppMhg2Q32 = true;
		formataDGDisp();
		AtualizaDGDisp();
		CXppMhg2Q32 = false;
		if (!YT7pMJCEAl8)
		{
			ncCpbLdQ56n();
		}
		if (!rbDispositivos.Checked)
		{
			if (rbReguas.Checked)
			{
				cbLayout.Checked = false;
				cbLayout.Enabled = false;
				btExportaEXCEL.Enabled = true;
			}
		}
		else
		{
			cbAlternativo.Enabled = true;
			cbLayout.Enabled = true;
			btExportaEXCEL.Enabled = true;
		}
	}

	private void ncCpbLdQ56n()
	{
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (dgEquip.SelectedRows.Count != 1)
			{
				return;
			}
			QgLpbzVhJ9A = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
			DeclaracoesFiacao.structureVF[] mDisp = new DeclaracoesFiacao.structureVF[1];
			cDadosAccessFiacao2.CarregaDispTipoIndexModelo(BRApbrurRjf, C8bpb90qTcY, QgLpbzVhJ9A, ref mDisp);
			CXppMhg2Q32 = true;
			dgDisp.Rows.Clear();
			CXppMhg2Q32 = false;
			int num = Information.UBound(mDisp);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (!((Operators.CompareString(mDisp[i].Tipo, "B", TextCompare: true) != 0) & rbDispositivos.Checked))
				{
					if ((Operators.CompareString(mDisp[i].Tipo, "B", TextCompare: true) == 0) & rbReguas.Checked)
					{
						dgDisp.Rows.Add(mDisp[i].Tag, mDisp[i].Alternativo, mDisp[i].Tipo, mDisp[i].IndexModelo.ToString(), mDisp[i].PosOrdem);
					}
				}
				else
				{
					dgDisp.Rows.Add(mDisp[i].Tag, mDisp[i].Alternativo, mDisp[i].Tipo, mDisp[i].IndexModelo.ToString(), mDisp[i].PosOrdem);
				}
			}
			if (cbLayout.Checked)
			{
				DataGridViewColumn dataGridViewColumn = dgDisp.Columns[4];
				dgDisp.Sort(dataGridViewColumn, ListSortDirection.Ascending);
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

	private void l0wpbw8iOmj(object P_0, EventArgs P_1)
	{
		string sTipoRel = "";
		if (rbDispositivos.Checked)
		{
			sTipoRel = "D";
		}
		if (rbReguas.Checked)
		{
			sTipoRel = "R";
		}
		if (dgFiacao.RowCount > 0)
		{
			new frmRelatorio_FiacaoDWG(IMapMooGMZj, sTipoRel, QgLpbzVhJ9A);
		}
	}

	private void JVgpbxsaP9W(object P_0, EventArgs P_1)
	{
		string sTipoRel = "";
		if (rbDispositivos.Checked)
		{
			sTipoRel = "DISP";
		}
		if (rbReguas.Checked)
		{
			sTipoRel = "REGUAS";
		}
		Dicionario.BuscaNomeDoPainel(QgLpbzVhJ9A);
		if (dgFiacao.RowCount > 0)
		{
			new frmRelatorio_Fiacao_Excel(IMapMooGMZj, sTipoRel, QgLpbzVhJ9A, C8bpb90qTcY);
		}
	}

	private void R9dpbbD9Jbg(object P_0, EventArgs P_1)
	{
		hcDpbMZbDMe(_0020: false);
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		formataDGFiacao();
		IMapMooGMZj = new DeclaracoesFiacao.structureRelFiacao[1];
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
					string text2 = Conversions.ToString(dgDisp.Rows[i].Cells[1].Value);
					string text3 = Conversions.ToString(dgDisp.Rows[i].Cells[2].Value);
					int num2 = Conversions.ToInteger(dgDisp.Rows[i].Cells[3].Value);
					if (rbDispositivos.Checked)
					{
						DeclaracoesFiacao.ilinhaCEMIGD = 1;
					}
					DeclaracoesFiacao.structureFiacao[] mfiacao = new DeclaracoesFiacao.structureFiacao[1];
					mfiacao[0].Lig = new DeclaracoesFiacao.structureLigacao[1];
					DeclaracoesFiacao.structureLink[] mLink = new DeclaracoesFiacao.structureLink[1];
					if (!((Operators.CompareString(text3, "A", TextCompare: true) == 0) & (num2 == 0)))
					{
						if (!((Operators.CompareString(text3, "A", TextCompare: true) == 0) & (num2 > 0)))
						{
							if (Operators.CompareString(text3, "E", TextCompare: true) != 0)
							{
								if (Operators.CompareString(text3, "B", TextCompare: true) == 0)
								{
									cDadosAccessFiacao2.CarregaTerminaisRegua(BRApbrurRjf, C8bpb90qTcY, QgLpbzVhJ9A, num2, ref mfiacao);
								}
							}
							else
							{
								cDadosAccessFiacao2.CarregaTerminaisMascara(BRApbrurRjf, C8bpb90qTcY, num2, ref mfiacao);
							}
						}
						else
						{
							cDadosAccessFiacao2.CarregaTerminaisContato(BRApbrurRjf, C8bpb90qTcY, num2, ref mfiacao);
						}
					}
					else
					{
						cDadosAccessFiacao2.CarregaTerminaisDispositivo(BRApbrurRjf, C8bpb90qTcY, QgLpbzVhJ9A, text, ref mfiacao);
					}
					cDadosAccessFiacao2.CarregaLigacoesTerminal(BRApbrurRjf, C8bpb90qTcY, QgLpbzVhJ9A, text, text3, ref mfiacao, ref mLink);
					int num3 = Information.UBound(IMapMooGMZj);
					if (!(cbAlternativo.Checked & (Operators.CompareString(text2, "", TextCompare: true) != 0)))
					{
						dgFiacao.Rows.Add(text);
						IMapMooGMZj[num3].Tag = text;
						IMapMooGMZj[num3].NomeDispositivo = text;
					}
					else
					{
						dgFiacao.Rows.Add(text2);
						IMapMooGMZj[num3].Tag = text2;
						IMapMooGMZj[num3].NomeDispositivo = text;
					}
					dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[0].Style.Font = new Font("Arial", 10f, FontStyle.Bold);
					int num4 = dgFiacao.ColumnCount - 1;
					for (int j = 0; j <= num4; j++)
					{
						dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[j].Style.BackColor = Color.LightGray;
					}
					int num5 = Information.UBound(mfiacao);
					for (int k = 1; k <= num5; k++)
					{
						string text4 = "";
						string text5 = "";
						string text6 = "";
						string text7 = "";
						string text8 = "";
						string text9 = "";
						string text10 = "";
						string text11 = "";
						DeclaracoesFiacao.structureLigacao[] lig = mfiacao[k].Lig;
						ref DeclaracoesFiacao.structureRelFiacao[] iMapMooGMZj = ref IMapMooGMZj;
						iMapMooGMZj = (DeclaracoesFiacao.structureRelFiacao[])Utils.CopyArray(iMapMooGMZj, new DeclaracoesFiacao.structureRelFiacao[Information.UBound(IMapMooGMZj) + 1 + 1]);
						num3 = Information.UBound(IMapMooGMZj);
						if (Information.UBound(lig) != 0)
						{
							if (Information.UBound(lig) != 4)
							{
								if (Information.UBound(lig) != 3)
								{
									if (!((Information.UBound(lig) == 2) & ((Operators.CompareString(text3, "A", TextCompare: true) == 0) | (Operators.CompareString(text3, "E", TextCompare: true) == 0) | ((Operators.CompareString(text3, "B", TextCompare: true) == 0) & (mfiacao[k].TipoBorne == 0)))))
									{
										if (!((Information.UBound(lig) == 2) & ((Operators.CompareString(text3, "B", TextCompare: true) == 0) & (mfiacao[k].TipoBorne == 1))))
										{
											if (Information.UBound(lig) != 1)
											{
												if (Information.UBound(lig) > 4)
												{
													dgFiacao.Rows.Add(mfiacao[k].Terminal, "", DeclaracoesGeral.mMensagem[1, 784], "", "", "", "", "", mfiacao[k].Pagina);
													if (Operators.CompareString(text3, "B", TextCompare: true) == 0)
													{
														string jumper = Rt9pb8bCo2F(mfiacao[k].Terminal, ref mLink);
														IMapMooGMZj[num3].TipoBorne = mfiacao[k].TipoBorne;
														IMapMooGMZj[num3].Jumper = jumper;
													}
													IMapMooGMZj[num3].Terminal = mfiacao[k].Terminal;
													IMapMooGMZj[num3].Pagina12 = mfiacao[k].Pagina;
													IMapMooGMZj[num3].numLigacoes = Information.UBound(lig);
												}
												continue;
											}
											text4 = N6Epba7gva3(lig[1].Tag, lig[1].Alternativo);
											text5 = lig[1].Term;
											text6 = "";
											text7 = "";
											char c = '\0';
											DataGridViewContentAlignment dataGridViewContentAlignment = DataGridViewContentAlignment.NotSet;
											if (Operators.CompareString(text3, "B", TextCompare: true) == 0)
											{
												string value = Conversions.ToString(c);
												V52pb7JmI7Z(ref value, ref dataGridViewContentAlignment, mfiacao[k].Terminal, ref mLink);
												c = Conversions.ToChar(value);
											}
											string secao = lig[1].Secao;
											string cor = lig[1].Cor;
											string text12 = kSepbOpfnuc(mfiacao[k].NRegua, mfiacao[k].Terminal);
											dgFiacao.Rows.Add(text12, c, text4, text5, text6, text7, secao, cor, mfiacao[k].Pagina);
											k7dpbI5HFMf(dataGridViewContentAlignment);
											if (Operators.CompareString(text3, "B", TextCompare: true) == 0)
											{
												string jumper2 = Rt9pb8bCo2F(mfiacao[k].Terminal, ref mLink);
												IMapMooGMZj[num3].TipoBorne = mfiacao[k].TipoBorne;
												IMapMooGMZj[num3].Jumper = jumper2;
											}
											IMapMooGMZj[num3].Terminal = mfiacao[k].Terminal;
											IMapMooGMZj[num3].Disp1 = text4;
											IMapMooGMZj[num3].Term1 = text5;
											IMapMooGMZj[num3].Disp2 = "";
											IMapMooGMZj[num3].Term2 = "";
											IMapMooGMZj[num3].Disp3 = "";
											IMapMooGMZj[num3].Term3 = "";
											IMapMooGMZj[num3].Disp4 = "";
											IMapMooGMZj[num3].Term4 = "";
											IMapMooGMZj[num3].Secao12 = secao;
											IMapMooGMZj[num3].Cor12 = cor;
											IMapMooGMZj[num3].Secao34 = "";
											IMapMooGMZj[num3].Cor34 = "";
											IMapMooGMZj[num3].Pagina12 = mfiacao[k].Pagina;
											IMapMooGMZj[num3].numLigacoes = 1;
										}
										else
										{
											text4 = N6Epba7gva3(lig[1].Tag, lig[1].Alternativo);
											text5 = lig[1].Term;
											text6 = N6Epba7gva3(lig[2].Tag, lig[2].Alternativo);
											text7 = lig[2].Term;
											char c2 = '\0';
											DataGridViewContentAlignment dataGridViewContentAlignment2 = DataGridViewContentAlignment.NotSet;
											if (Operators.CompareString(text3, "B", TextCompare: true) == 0)
											{
												string value = Conversions.ToString(c2);
												bxgpbqomB47(ref value, ref dataGridViewContentAlignment2, mfiacao[k].Terminal, ref mLink, 1);
												c2 = Conversions.ToChar(value);
											}
											string secao2 = lig[1].Secao;
											string cor2 = lig[1].Cor;
											string text13 = kSepbOpfnuc(mfiacao[k].NRegua, mfiacao[k].Terminal);
											dgFiacao.Rows.Add(text13, c2, text4, text5, "", "", secao2, cor2, mfiacao[k].Pagina);
											k7dpbI5HFMf(dataGridViewContentAlignment2);
											string text14 = "";
											DataGridViewContentAlignment dataGridViewContentAlignment3 = DataGridViewContentAlignment.NotSet;
											if (Operators.CompareString(text3, "B", TextCompare: true) == 0)
											{
												bxgpbqomB47(ref text14, ref dataGridViewContentAlignment3, mfiacao[k].Terminal, ref mLink, 2);
											}
											text8 = text6;
											text9 = text7;
											text10 = "";
											text11 = "";
											string secao3 = lig[2].Secao;
											string cor3 = lig[2].Cor;
											dgFiacao.Rows.Add(text13, text14, text8, text9, text10, text11, secao3, cor3, mfiacao[k].Pagina);
											k7dpbI5HFMf(dataGridViewContentAlignment3);
											string jumper3 = Rt9pb8bCo2F(mfiacao[k].Terminal, ref mLink);
											IMapMooGMZj[num3].TipoBorne = mfiacao[k].TipoBorne;
											IMapMooGMZj[num3].Jumper = jumper3;
											IMapMooGMZj[num3].Terminal = mfiacao[k].Terminal;
											IMapMooGMZj[num3].Disp1 = text4;
											IMapMooGMZj[num3].Term1 = text5;
											IMapMooGMZj[num3].Disp2 = "";
											IMapMooGMZj[num3].Term2 = "";
											IMapMooGMZj[num3].Disp3 = text8;
											IMapMooGMZj[num3].Term3 = text9;
											IMapMooGMZj[num3].Disp4 = text10;
											IMapMooGMZj[num3].Term4 = text11;
											IMapMooGMZj[num3].Secao12 = secao2;
											IMapMooGMZj[num3].Cor12 = cor2;
											IMapMooGMZj[num3].Secao34 = secao3;
											IMapMooGMZj[num3].Cor34 = cor3;
											IMapMooGMZj[num3].Pagina12 = mfiacao[k].Pagina;
											IMapMooGMZj[num3].Pagina34 = mfiacao[k].Pagina;
											IMapMooGMZj[num3].numLigacoes = 3;
										}
									}
									else
									{
										text4 = N6Epba7gva3(lig[1].Tag, lig[1].Alternativo);
										text5 = lig[1].Term;
										text6 = N6Epba7gva3(lig[2].Tag, lig[2].Alternativo);
										text7 = lig[2].Term;
										char c3 = '\0';
										DataGridViewContentAlignment dataGridViewContentAlignment4 = DataGridViewContentAlignment.NotSet;
										if (Operators.CompareString(text3, "B", TextCompare: true) == 0)
										{
											string value = Conversions.ToString(c3);
											V52pb7JmI7Z(ref value, ref dataGridViewContentAlignment4, mfiacao[k].Terminal, ref mLink);
											c3 = Conversions.ToChar(value);
										}
										string text15 = lig[1].Secao;
										if (Operators.CompareString(lig[1].Secao, lig[2].Secao, TextCompare: true) != 0)
										{
											text15 = lig[1].Secao + " ; " + lig[2].Secao;
										}
										string text16 = lig[1].Cor;
										if (Operators.CompareString(lig[1].Cor, lig[2].Cor, TextCompare: true) != 0)
										{
											text16 = lig[1].Cor + " ; " + lig[2].Cor;
										}
										string text17 = kSepbOpfnuc(mfiacao[k].NRegua, mfiacao[k].Terminal);
										dgFiacao.Rows.Add(text17, c3, text4, text5, text6, text7, text15, text16, mfiacao[k].Pagina);
										k7dpbI5HFMf(dataGridViewContentAlignment4);
										if (Operators.CompareString(text3, "B", TextCompare: true) == 0)
										{
											string jumper4 = Rt9pb8bCo2F(mfiacao[k].Terminal, ref mLink);
											IMapMooGMZj[num3].TipoBorne = mfiacao[k].TipoBorne;
											IMapMooGMZj[num3].Jumper = jumper4;
										}
										IMapMooGMZj[num3].Terminal = mfiacao[k].Terminal;
										IMapMooGMZj[num3].Disp1 = text4;
										IMapMooGMZj[num3].Term1 = text5;
										IMapMooGMZj[num3].Disp2 = text6;
										IMapMooGMZj[num3].Term2 = text7;
										IMapMooGMZj[num3].Disp3 = "";
										IMapMooGMZj[num3].Term3 = "";
										IMapMooGMZj[num3].Disp4 = "";
										IMapMooGMZj[num3].Term4 = "";
										IMapMooGMZj[num3].Secao12 = text15;
										IMapMooGMZj[num3].Cor12 = text16;
										IMapMooGMZj[num3].Secao34 = "";
										IMapMooGMZj[num3].Cor34 = "";
										IMapMooGMZj[num3].Pagina12 = mfiacao[k].Pagina;
										IMapMooGMZj[num3].numLigacoes = 2;
									}
									continue;
								}
								text4 = N6Epba7gva3(lig[1].Tag, lig[1].Alternativo);
								text5 = lig[1].Term;
								text6 = N6Epba7gva3(lig[2].Tag, lig[2].Alternativo);
								text7 = lig[2].Term;
								char c4 = '\0';
								DataGridViewContentAlignment dataGridViewContentAlignment5 = DataGridViewContentAlignment.NotSet;
								if (Operators.CompareString(text3, "B", TextCompare: true) == 0)
								{
									string value = Conversions.ToString(c4);
									bxgpbqomB47(ref value, ref dataGridViewContentAlignment5, mfiacao[k].Terminal, ref mLink, 1);
									c4 = Conversions.ToChar(value);
								}
								string text18 = lig[1].Secao;
								if (Operators.CompareString(lig[1].Secao, lig[2].Secao, TextCompare: true) != 0)
								{
									text18 = lig[1].Secao + " ; " + lig[2].Secao;
								}
								string text19 = lig[1].Cor;
								if (Operators.CompareString(lig[1].Cor, lig[2].Cor, TextCompare: true) != 0)
								{
									text19 = lig[1].Cor + " ; " + lig[2].Cor;
								}
								string text20 = kSepbOpfnuc(mfiacao[k].NRegua, mfiacao[k].Terminal);
								dgFiacao.Rows.Add(text20, c4, text4, text5, text6, text7, text18, text19, mfiacao[k].Pagina);
								k7dpbI5HFMf(dataGridViewContentAlignment5);
								string text21 = "";
								DataGridViewContentAlignment dataGridViewContentAlignment6 = DataGridViewContentAlignment.NotSet;
								if (Operators.CompareString(text3, "B", TextCompare: true) == 0)
								{
									bxgpbqomB47(ref text21, ref dataGridViewContentAlignment6, mfiacao[k].Terminal, ref mLink, 2);
								}
								text8 = N6Epba7gva3(lig[3].Tag, lig[3].Alternativo);
								text9 = lig[3].Term;
								text10 = "";
								text11 = "";
								string secao4 = lig[3].Secao;
								string cor4 = lig[3].Cor;
								dgFiacao.Rows.Add(text20, text21, text8, text9, text10, text11, secao4, cor4, mfiacao[k].Pagina);
								k7dpbI5HFMf(dataGridViewContentAlignment6);
								if (mfiacao[k].TipoBorne == 0)
								{
									dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[0].Style.BackColor = Color.LightCoral;
								}
								if (Operators.CompareString(text3, "B", TextCompare: true) != 0)
								{
									IMapMooGMZj[num3].Terminal = mfiacao[k].Terminal;
									IMapMooGMZj[num3].Disp1 = text4;
									IMapMooGMZj[num3].Term1 = text5;
									IMapMooGMZj[num3].Disp2 = text6;
									IMapMooGMZj[num3].Term2 = text7;
									IMapMooGMZj[num3].Disp3 = text8;
									IMapMooGMZj[num3].Term3 = text9;
									IMapMooGMZj[num3].Disp4 = text10;
									IMapMooGMZj[num3].Term4 = text11;
									IMapMooGMZj[num3].Secao12 = text18;
									IMapMooGMZj[num3].Cor12 = text19;
									IMapMooGMZj[num3].Secao34 = secao4;
									IMapMooGMZj[num3].Cor34 = cor4;
									IMapMooGMZj[num3].Pagina12 = mfiacao[k].Pagina;
									IMapMooGMZj[num3].numLigacoes = 3;
									continue;
								}
								string jumper5 = Rt9pb8bCo2F(mfiacao[k].Terminal, ref mLink);
								IMapMooGMZj[num3].TipoBorne = mfiacao[k].TipoBorne;
								IMapMooGMZj[num3].Jumper = jumper5;
								if (mfiacao[k].TipoBorne != 1)
								{
									IMapMooGMZj[num3].TipoBorne = 0;
									IMapMooGMZj[num3].Terminal = mfiacao[k].Terminal;
									IMapMooGMZj[num3].Disp1 = text4;
									IMapMooGMZj[num3].Term1 = text5;
									IMapMooGMZj[num3].Disp2 = text6;
									IMapMooGMZj[num3].Term2 = text7;
									IMapMooGMZj[num3].Disp3 = "";
									IMapMooGMZj[num3].Term3 = "";
									IMapMooGMZj[num3].Disp4 = "";
									IMapMooGMZj[num3].Term4 = "";
									IMapMooGMZj[num3].Secao12 = text18;
									IMapMooGMZj[num3].Cor12 = text19;
									IMapMooGMZj[num3].Secao34 = "";
									IMapMooGMZj[num3].Cor34 = "";
									IMapMooGMZj[num3].Pagina12 = mfiacao[k].Pagina;
									IMapMooGMZj[num3].numLigacoes = 2;
									ref DeclaracoesFiacao.structureRelFiacao[] iMapMooGMZj2 = ref IMapMooGMZj;
									iMapMooGMZj2 = (DeclaracoesFiacao.structureRelFiacao[])Utils.CopyArray(iMapMooGMZj2, new DeclaracoesFiacao.structureRelFiacao[Information.UBound(IMapMooGMZj) + 1 + 1]);
									num3 = Information.UBound(IMapMooGMZj);
									IMapMooGMZj[num3].TipoBorne = 0;
									IMapMooGMZj[num3].Terminal = mfiacao[k].Terminal;
									IMapMooGMZj[num3].Disp1 = text8;
									IMapMooGMZj[num3].Term1 = text9;
									IMapMooGMZj[num3].Disp2 = text10;
									IMapMooGMZj[num3].Term2 = text11;
									IMapMooGMZj[num3].Disp3 = "";
									IMapMooGMZj[num3].Term3 = "";
									IMapMooGMZj[num3].Disp4 = "";
									IMapMooGMZj[num3].Term4 = "";
									IMapMooGMZj[num3].Secao12 = secao4;
									IMapMooGMZj[num3].Cor12 = cor4;
									IMapMooGMZj[num3].Secao34 = "";
									IMapMooGMZj[num3].Cor34 = "";
									IMapMooGMZj[num3].Pagina12 = mfiacao[k].Pagina;
									IMapMooGMZj[num3].numLigacoes = 1;
								}
								else
								{
									IMapMooGMZj[num3].Terminal = mfiacao[k].Terminal;
									IMapMooGMZj[num3].Disp1 = text4;
									IMapMooGMZj[num3].Term1 = text5;
									IMapMooGMZj[num3].Disp2 = text6;
									IMapMooGMZj[num3].Term2 = text7;
									IMapMooGMZj[num3].Disp3 = text8;
									IMapMooGMZj[num3].Term3 = text9;
									IMapMooGMZj[num3].Disp4 = text10;
									IMapMooGMZj[num3].Term4 = text11;
									IMapMooGMZj[num3].Secao12 = text18;
									IMapMooGMZj[num3].Cor12 = text19;
									IMapMooGMZj[num3].Secao34 = secao4;
									IMapMooGMZj[num3].Cor34 = cor4;
									IMapMooGMZj[num3].Pagina12 = mfiacao[k].Pagina;
									IMapMooGMZj[num3].numLigacoes = 3;
								}
								continue;
							}
							text4 = N6Epba7gva3(lig[1].Tag, lig[1].Alternativo);
							text5 = lig[1].Term;
							text6 = N6Epba7gva3(lig[2].Tag, lig[2].Alternativo);
							text7 = lig[2].Term;
							char c5 = '\0';
							DataGridViewContentAlignment dataGridViewContentAlignment7 = DataGridViewContentAlignment.NotSet;
							if (Operators.CompareString(text3, "B", TextCompare: true) == 0)
							{
								string value = Conversions.ToString(c5);
								bxgpbqomB47(ref value, ref dataGridViewContentAlignment7, mfiacao[k].Terminal, ref mLink, 1);
								c5 = Conversions.ToChar(value);
							}
							string text22 = lig[1].Secao;
							if (Operators.CompareString(lig[1].Secao, lig[2].Secao, TextCompare: true) != 0)
							{
								text22 = lig[1].Secao + " ; " + lig[2].Secao;
							}
							string text23 = lig[1].Cor;
							if (Operators.CompareString(lig[1].Cor, lig[2].Cor, TextCompare: true) != 0)
							{
								text23 = lig[1].Cor + " ; " + lig[2].Cor;
							}
							string text24 = kSepbOpfnuc(mfiacao[k].NRegua, mfiacao[k].Terminal);
							dgFiacao.Rows.Add(text24, c5, text4, text5, text6, text7, text22, text23, mfiacao[k].Pagina);
							k7dpbI5HFMf(dataGridViewContentAlignment7);
							string text25 = "";
							DataGridViewContentAlignment dataGridViewContentAlignment8 = DataGridViewContentAlignment.NotSet;
							if (Operators.CompareString(text3, "B", TextCompare: true) == 0)
							{
								bxgpbqomB47(ref text25, ref dataGridViewContentAlignment8, mfiacao[k].Terminal, ref mLink, 2);
							}
							text8 = N6Epba7gva3(lig[3].Tag, lig[3].Alternativo);
							text9 = lig[3].Term;
							text10 = N6Epba7gva3(lig[4].Tag, lig[4].Alternativo);
							text11 = lig[4].Term;
							string text26 = lig[3].Secao;
							if (Operators.CompareString(lig[3].Secao, lig[4].Secao, TextCompare: true) != 0)
							{
								text26 = lig[3].Secao + " ; " + lig[4].Secao;
							}
							string text27 = lig[3].Cor;
							if (Operators.CompareString(lig[3].Cor, lig[4].Cor, TextCompare: true) != 0)
							{
								text27 = lig[3].Cor + " ; " + lig[4].Cor;
							}
							dgFiacao.Rows.Add(text24, text25, text8, text9, text10, text11, text26, text27, mfiacao[k].Pagina);
							k7dpbI5HFMf(dataGridViewContentAlignment8);
							if (mfiacao[k].TipoBorne == 0)
							{
								dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[0].Style.BackColor = Color.LightCoral;
							}
							if (Operators.CompareString(text3, "B", TextCompare: true) != 0)
							{
								IMapMooGMZj[num3].Terminal = mfiacao[k].Terminal;
								IMapMooGMZj[num3].Disp1 = text4;
								IMapMooGMZj[num3].Term1 = text5;
								IMapMooGMZj[num3].Disp2 = text6;
								IMapMooGMZj[num3].Term2 = text7;
								IMapMooGMZj[num3].Disp3 = text8;
								IMapMooGMZj[num3].Term3 = text9;
								IMapMooGMZj[num3].Disp4 = text10;
								IMapMooGMZj[num3].Term4 = text11;
								IMapMooGMZj[num3].Secao12 = text22;
								IMapMooGMZj[num3].Cor12 = text23;
								IMapMooGMZj[num3].Secao34 = text26;
								IMapMooGMZj[num3].Cor34 = text27;
								IMapMooGMZj[num3].Pagina12 = mfiacao[k].Pagina;
								IMapMooGMZj[num3].numLigacoes = 4;
								continue;
							}
							string jumper6 = Rt9pb8bCo2F(mfiacao[k].Terminal, ref mLink);
							IMapMooGMZj[num3].TipoBorne = mfiacao[k].TipoBorne;
							IMapMooGMZj[num3].Jumper = jumper6;
							if (mfiacao[k].TipoBorne != 1)
							{
								IMapMooGMZj[num3].TipoBorne = 0;
								IMapMooGMZj[num3].Terminal = mfiacao[k].Terminal;
								IMapMooGMZj[num3].Disp1 = text4;
								IMapMooGMZj[num3].Term1 = text5;
								IMapMooGMZj[num3].Disp2 = text6;
								IMapMooGMZj[num3].Term2 = text7;
								IMapMooGMZj[num3].Disp3 = "";
								IMapMooGMZj[num3].Term3 = "";
								IMapMooGMZj[num3].Disp4 = "";
								IMapMooGMZj[num3].Term4 = "";
								IMapMooGMZj[num3].Secao12 = text22;
								IMapMooGMZj[num3].Cor12 = text23;
								IMapMooGMZj[num3].Secao34 = "";
								IMapMooGMZj[num3].Cor34 = "";
								IMapMooGMZj[num3].Pagina12 = mfiacao[k].Pagina;
								IMapMooGMZj[num3].numLigacoes = 2;
								ref DeclaracoesFiacao.structureRelFiacao[] iMapMooGMZj3 = ref IMapMooGMZj;
								iMapMooGMZj3 = (DeclaracoesFiacao.structureRelFiacao[])Utils.CopyArray(iMapMooGMZj3, new DeclaracoesFiacao.structureRelFiacao[Information.UBound(IMapMooGMZj) + 1 + 1]);
								num3 = Information.UBound(IMapMooGMZj);
								IMapMooGMZj[num3].TipoBorne = 0;
								IMapMooGMZj[num3].Terminal = mfiacao[k].Terminal;
								IMapMooGMZj[num3].Disp1 = text8;
								IMapMooGMZj[num3].Term1 = text9;
								IMapMooGMZj[num3].Disp2 = text10;
								IMapMooGMZj[num3].Term2 = text11;
								IMapMooGMZj[num3].Disp3 = "";
								IMapMooGMZj[num3].Term3 = "";
								IMapMooGMZj[num3].Disp4 = "";
								IMapMooGMZj[num3].Term4 = "";
								IMapMooGMZj[num3].Secao12 = text26;
								IMapMooGMZj[num3].Cor12 = text27;
								IMapMooGMZj[num3].Secao34 = "";
								IMapMooGMZj[num3].Cor34 = "";
								IMapMooGMZj[num3].Pagina12 = mfiacao[k].Pagina;
								IMapMooGMZj[num3].numLigacoes = 2;
							}
							else
							{
								IMapMooGMZj[num3].Terminal = mfiacao[k].Terminal;
								IMapMooGMZj[num3].Disp1 = text4;
								IMapMooGMZj[num3].Term1 = text5;
								IMapMooGMZj[num3].Disp2 = text6;
								IMapMooGMZj[num3].Term2 = text7;
								IMapMooGMZj[num3].Disp3 = text8;
								IMapMooGMZj[num3].Term3 = text9;
								IMapMooGMZj[num3].Disp4 = text10;
								IMapMooGMZj[num3].Term4 = text11;
								IMapMooGMZj[num3].Secao12 = text22;
								IMapMooGMZj[num3].Cor12 = text23;
								IMapMooGMZj[num3].Secao34 = text26;
								IMapMooGMZj[num3].Cor34 = text27;
								IMapMooGMZj[num3].Pagina12 = mfiacao[k].Pagina;
								IMapMooGMZj[num3].numLigacoes = 4;
							}
						}
						else if (Operators.CompareString(text3, "B", TextCompare: true) != 0)
						{
							if (rbTodos.Checked)
							{
								string text28 = kSepbOpfnuc(mfiacao[k].NRegua, mfiacao[k].Terminal);
								dgFiacao.Rows.Add(text28, "", "", "", "", "", "", "", mfiacao[k].Pagina);
								IMapMooGMZj[num3].Terminal = mfiacao[k].Terminal;
								IMapMooGMZj[num3].Pagina12 = mfiacao[k].Pagina;
								IMapMooGMZj[num3].numLigacoes = 0;
							}
						}
						else
						{
							string text29 = "";
							DataGridViewContentAlignment dataGridViewContentAlignment9 = DataGridViewContentAlignment.NotSet;
							V52pb7JmI7Z(ref text29, ref dataGridViewContentAlignment9, mfiacao[k].Terminal, ref mLink);
							if ((Operators.CompareString(text29, "", TextCompare: true) == 0) & rbTodos.Checked)
							{
								dgFiacao.Rows.Add(mfiacao[k].Terminal, "", "", "", "", "", "", "", mfiacao[k].Pagina);
							}
							if (Operators.CompareString(text29, "", TextCompare: true) != 0)
							{
								dgFiacao.Rows.Add(mfiacao[k].Terminal, text29, "", "", "", "", "", "", mfiacao[k].Pagina);
								k7dpbI5HFMf(dataGridViewContentAlignment9);
							}
							string jumper7 = Rt9pb8bCo2F(mfiacao[k].Terminal, ref mLink);
							IMapMooGMZj[num3].Terminal = mfiacao[k].Terminal;
							IMapMooGMZj[num3].TipoBorne = mfiacao[k].TipoBorne;
							IMapMooGMZj[num3].Jumper = jumper7;
							IMapMooGMZj[num3].Pagina12 = mfiacao[k].Pagina;
							IMapMooGMZj[num3].numLigacoes = 0;
						}
					}
					dgFiacao.Rows.Add("");
				}
				DeclaracoesGeral._uscPagina.pbFim();
				LblpbK8TiC8();
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
			hcDpbMZbDMe(_0020: true);
		}
	}

	private void hcDpbMZbDMe(bool P_0)
	{
		btPesquisar.Enabled = P_0;
		GroupBox1.Enabled = P_0;
		GroupBox2.Enabled = P_0;
		cbAlterarOrdem.Enabled = P_0;
		cbAlternativo.Enabled = P_0;
		cbLayout.Enabled = P_0;
		btExportaDWG.Enabled = P_0;
		btExportaEXCEL.Enabled = P_0;
	}

	private string kSepbOpfnuc(string P_0, string P_1)
	{
		if (Information.IsNothing(P_0))
		{
			P_0 = "";
		}
		string text = "";
		text = ((Operators.CompareString(P_0.Trim(), "", TextCompare: true) == 0) ? P_1 : (P_0 + ":" + P_1));
		return text.Trim();
	}

	private void k7dpbI5HFMf(DataGridViewContentAlignment P_0)
	{
		checked
		{
			dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[1].Style.Font = new Font("Arial", 12f, FontStyle.Bold);
			dgFiacao.Rows[dgFiacao.Rows.Count - 1].Cells[1].Style.Alignment = P_0;
		}
	}

	private void V52pb7JmI7Z(ref string P_0, ref DataGridViewContentAlignment P_1, string P_2, ref DeclaracoesFiacao.structureLink[] P_3)
	{
		string left = Rt9pb8bCo2F(P_2, ref P_3);
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

	private void bxgpbqomB47(ref string P_0, ref DataGridViewContentAlignment P_1, string P_2, ref DeclaracoesFiacao.structureLink[] P_3, int P_4)
	{
		string left = Rt9pb8bCo2F(P_2, ref P_3);
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

	private string N6Epba7gva3(string P_0, string P_1)
	{
		string text = "";
		if (!(cbAlternativo.Checked & (Operators.CompareString(P_1, "", TextCompare: true) != 0)))
		{
			return P_0;
		}
		return P_1;
	}

	private string Rt9pb8bCo2F(string P_0, ref DeclaracoesFiacao.structureLink[] P_1)
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
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void AtualizaDGDWG()
	{
		checked
		{
			try
			{
				float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgDWG)) ? ((float)(dgDWG.Width - 5)) : ((float)(dgDWG.Width - 22)));
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
		AtualizaDGDWG();
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
				YT7pMJCEAl8 = true;
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
				YT7pMJCEAl8 = false;
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
				YT7pMJCEAl8 = false;
			}
		}
	}

	public void formataDGDisp()
	{
		checked
		{
			try
			{
				CXppMhg2Q32 = true;
				dgDisp.Rows.Clear();
				dgDisp.Columns.Clear();
				if (!rbDispositivos.Checked)
				{
					if (!rbReguas.Checked)
					{
						dgDisp.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 788]));
					}
					else
					{
						dgDisp.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 788]));
					}
				}
				else
				{
					dgDisp.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 767]));
				}
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
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				CXppMhg2Q32 = false;
			}
		}
	}

	public void AtualizaDGDisp()
	{
		checked
		{
			try
			{
				float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgDisp)) ? ((float)(dgDisp.Width - 5)) : ((float)(dgDisp.Width - 22)));
				if (cbAlternativo.Checked)
				{
					dgDisp.Columns[0].Width = (int)Math.Round(num / 2f);
					dgDisp.Columns[1].Width = (int)Math.Round(num / 2f);
					dgDisp.Columns[1].Visible = true;
				}
				else
				{
					dgDisp.Columns[0].Width = (int)Math.Round(num);
					dgDisp.Columns[1].Width = 0;
					dgDisp.Columns[1].Visible = false;
				}
				dgDisp.Columns[2].Width = 0;
				dgDisp.Columns[2].Visible = false;
				dgDisp.Columns[3].Width = 0;
				dgDisp.Columns[3].Visible = false;
				dgDisp.Columns[4].Width = 0;
				dgDisp.Columns[4].Visible = false;
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
				CXppMhg2Q32 = false;
			}
		}
	}

	private void tQqpbNHL9Nq(object P_0, EventArgs P_1)
	{
		cbLayout.Checked = false;
		checked
		{
			float num = dgDisp.Width - 22;
			if (cbAlternativo.Checked)
			{
				dgDisp.Columns[0].Width = (int)Math.Round(num / 2f);
				dgDisp.Columns[1].Width = (int)Math.Round(num / 2f);
				dgDisp.Columns[1].Visible = true;
				DataGridViewColumn dataGridViewColumn = dgDisp.Columns[1];
				dgDisp.Sort(dataGridViewColumn, ListSortDirection.Ascending);
			}
			else
			{
				dgDisp.Columns[0].Width = (int)Math.Round(num);
				dgDisp.Columns[1].Width = (int)Math.Round(num);
				dgDisp.Columns[1].Visible = false;
				DataGridViewColumn dataGridViewColumn2 = dgDisp.Columns[0];
				dgDisp.Sort(dataGridViewColumn2, ListSortDirection.Ascending);
			}
		}
	}

	private void BjxpbFfC75r(object P_0, EventArgs P_1)
	{
		if (cbLayout.Checked)
		{
			DataGridViewColumn dataGridViewColumn = dgDisp.Columns[4];
			dgDisp.Sort(dataGridViewColumn, ListSortDirection.Ascending);
		}
		else
		{
			DataGridViewColumn dataGridViewColumn2 = dgDisp.Columns[0];
			dgDisp.Sort(dataGridViewColumn2, ListSortDirection.Ascending);
		}
	}

	private void ny8pbQuJjXS(object P_0, EventArgs P_1)
	{
		if (cbAlterarOrdem.Checked)
		{
			GroupBox1.Enabled = false;
			btPesquisar.Enabled = false;
			btExportaDWG.Enabled = false;
			btExportaEXCEL.Enabled = false;
			dgDisp.MultiSelect = false;
			dgDisp.AllowDrop = true;
		}
		else
		{
			GroupBox1.Enabled = true;
			btPesquisar.Enabled = true;
			btExportaDWG.Enabled = true;
			btExportaEXCEL.Enabled = true;
			cbAlternativo.Enabled = true;
			dgDisp.MultiSelect = true;
			dgDisp.AllowDrop = false;
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
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 776]));
				dgFiacao.Columns.Add("", "");
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 777]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 778]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 779]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 780]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 781]));
				if (!(rbDispositivos.Checked | rbReguas.Checked))
				{
					dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 262]));
				}
				else
				{
					dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 782]));
				}
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 783]));
				int num = dgFiacao.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgFiacao.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				float num2 = dgFiacao.Width - 20;
				dgFiacao.Columns[0].Width = (int)Math.Round((double)(num2 * 2f) / 13.5);
				if (rbDispositivos.Checked)
				{
					dgFiacao.Columns[1].Width = 0;
					dgFiacao.Columns[1].Visible = false;
				}
				oS4pbPL51rR();
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

	private void oS4pbPL51rR()
	{
		checked
		{
			if (dgFiacao.Columns.Count == 9)
			{
				double num = 0.0;
				float num2;
				if (rbDispositivos.Checked)
				{
					num2 = dgFiacao.Width;
					num = (double)num2 * 0.5 / 13.5;
				}
				num2 = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgFiacao)) ? ((float)(dgFiacao.Width - 5)) : ((float)(dgFiacao.Width - 22)));
				num2 = (float)((double)num2 + num);
				dgFiacao.Columns[0].Width = (int)Math.Round((double)(num2 * 2f) / 13.5);
				if (!rbDispositivos.Checked)
				{
					dgFiacao.Columns[1].Width = (int)Math.Round((double)num2 * 0.5 / 13.5);
				}
				else
				{
					dgFiacao.Columns[1].Width = 0;
				}
				if (rbDispositivos.Checked | rbReguas.Checked)
				{
					dgFiacao.Columns[2].Width = (int)Math.Round((double)(num2 * 2f) / 13.5);
					dgFiacao.Columns[3].Width = (int)Math.Round((double)(num2 * 2f) / 13.5);
					dgFiacao.Columns[4].Width = (int)Math.Round((double)(num2 * 2f) / 13.5);
					dgFiacao.Columns[5].Width = (int)Math.Round((double)(num2 * 2f) / 13.5);
				}
				dgFiacao.Columns[6].Width = (int)Math.Round((double)num2 / 13.5);
				dgFiacao.Columns[7].Width = (int)Math.Round((double)num2 / 13.5);
				dgFiacao.Columns[8].Width = (int)Math.Round((double)num2 / 13.5);
			}
		}
	}

	private void yYHpbcbLyTb(object P_0, EventArgs P_1)
	{
		LblpbK8TiC8();
	}

	private void LblpbK8TiC8()
	{
		oS4pbPL51rR();
	}

	private void Euepbe46O57(object P_0, MouseEventArgs P_1)
	{
		if (cbAlterarOrdem.Checked)
		{
			DataGridView.HitTestInfo hitTestInfo = dgDisp.HitTest(P_1.X, P_1.Y);
			if (hitTestInfo.RowIndex >= 0)
			{
				DataGridViewRow data = dgDisp.Rows[hitTestInfo.RowIndex];
				iY3pMG6LuKI = hitTestInfo.RowIndex;
				dgDisp.Rows[iY3pMG6LuKI].Selected = true;
				dgDisp.DoDragDrop(data, DragDropEffects.All);
			}
		}
	}

	private void Mu9pb2dEQwH(object P_0, DragEventArgs P_1)
	{
		if (!cbAlterarOrdem.Checked)
		{
			return;
		}
		Point point = dgDisp.PointToClient(new Point(P_1.X, P_1.Y));
		DataGridView.HitTestInfo hitTestInfo = dgDisp.HitTest(point.X, point.Y);
		if (iY3pMG6LuKI == hitTestInfo.RowIndex)
		{
			return;
		}
		DataGridViewRow dataGridViewRow = (DataGridViewRow)P_1.Data.GetData(typeof(DataGridViewRow));
		DataGridViewRow dataGridViewRow2 = (DataGridViewRow)dataGridViewRow.Clone();
		dataGridViewRow2.Cells[0].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[0].Value);
		dataGridViewRow2.Cells[1].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[1].Value);
		dataGridViewRow2.Cells[2].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[2].Value);
		dataGridViewRow2.Cells[3].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[3].Value);
		dataGridViewRow2.Cells[4].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[4].Value);
		if (hitTestInfo.RowIndex == -1)
		{
			dgDisp.Rows.Add(dataGridViewRow2);
			dgDisp.Rows.RemoveAt(iY3pMG6LuKI);
			return;
		}
		dgDisp.Rows.Insert(hitTestInfo.RowIndex, dataGridViewRow2);
		checked
		{
			if (iY3pMG6LuKI > hitTestInfo.RowIndex)
			{
				iY3pMG6LuKI++;
			}
			dgDisp.Rows.RemoveAt(iY3pMG6LuKI);
		}
	}

	private void xbwpb3wBAhx(object P_0, DragEventArgs P_1)
	{
		if (cbAlterarOrdem.Checked)
		{
			P_1.Effect = DragDropEffects.Copy;
		}
	}

	private void MU3pbnfKgH1(object P_0, KeyEventArgs P_1)
	{
		if (!cbAlterarOrdem.Checked)
		{
			return;
		}
		checked
		{
			try
			{
				if (P_1.KeyCode != Keys.Home)
				{
					if (P_1.KeyCode == Keys.End)
					{
						DataGridViewRow dataGridViewRow = dgDisp.SelectedRows[0];
						dgDisp.Rows.RemoveAt(dgDisp.SelectedRows[0].Index);
						dgDisp.Rows.Add(dataGridViewRow);
						dgDisp.Rows[dgDisp.Rows.Count - 1].Selected = true;
						dgDisp.CurrentCell = dgDisp.Rows[dgDisp.Rows.Count - 1].Cells[0];
					}
				}
				else
				{
					DataGridViewRow dataGridViewRow2 = dgDisp.SelectedRows[0];
					dgDisp.Rows.RemoveAt(dgDisp.SelectedRows[0].Index);
					dgDisp.Rows.Insert(0, dataGridViewRow2);
					dgDisp.Rows[0].Selected = true;
					dgDisp.CurrentCell = dgDisp.Rows[0].Cells[0];
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void I9bpb1lWO3n(object P_0, EventArgs P_1)
	{
		btExportaEXCEL.Enabled = true;
	}
}
