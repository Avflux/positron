using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using VimZUaplUIPJH2tfOAZ9;
using ZwSoft.ZwCAD.ApplicationServices;

namespace Eletron4;

[DesignerGenerated]
public class frmRelatorio_EstatisticaFiacao : Form
{
	private IContainer VKaFPsb3ye;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgRevisao")]
	private DataGridView SXuFcaTdxq;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("dgEquip")]
	private DataGridView UqRFKf6TbP;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btPesquisar")]
	[CompilerGenerated]
	private Button riwFeqlbCM;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgDWG")]
	private DataGridView S3XF2UY4xi;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip NASF3Rm7uo;

	[AccessedThroughProperty("GroupBox1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox v4AFntIv3f;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label7")]
	private Label EmPF1bET6E;

	[AccessedThroughProperty("Label6")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label tPFFlPuL34;

	[AccessedThroughProperty("Label5")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label RYgF5rYqHt;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("Label4")]
	private Label ll8F0nOAOj;

	[CompilerGenerated]
	[AccessedThroughProperty("Label3")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label s4JFROsIuN;

	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label rjtFmsEfJ0;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label MaeFXWZxbs;

	[AccessedThroughProperty("tbCB")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox BhYFUtAlPF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbPB")]
	[CompilerGenerated]
	private TextBox vYCFyNBPP4;

	[AccessedThroughProperty("tbPC")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox yKtFgkjbI7;

	[AccessedThroughProperty("tbBB")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox iETFAdFhcM;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbCC")]
	private TextBox lr7FsS5Jls;

	[CompilerGenerated]
	[AccessedThroughProperty("tbPP")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox BZqFBmhhYD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDisp")]
	private TextBox lR1FVS31SN;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgFiacao")]
	[CompilerGenerated]
	private DataGridView iRRFulOqUN;

	[AccessedThroughProperty("btCopiar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button TAtFEncAKH;

	[AccessedThroughProperty("btSalvar")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button RfrFZDXFR8;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label8")]
	[CompilerGenerated]
	private Label yuBFieCN42;

	[CompilerGenerated]
	[AccessedThroughProperty("tbQCON")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox jstFSxnIrL;

	private DeclaracoesFiacao.structurePnRev[] ThLF4OHJ9J;

	private DeclaracoesFiacao.structureRevisoes[] e6uFCPiv5h;

	private int fXUFYOS7hp;

	private string cqeFr09sMC;

	private int oGdF9PwIgH;

	private bool nc0FzZjseh;

	private bool PpBQW4Ihcf;

	public DeclaracoesFiacao.structureRelPotencial[] mRelPotencial;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return SXuFcaTdxq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = vJtFjj7ZOx;
			DataGridView dataGridView = SXuFcaTdxq;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			SXuFcaTdxq = value;
			dataGridView = SXuFcaTdxq;
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
			return UqRFKf6TbP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RcPFxTUYJ5;
			DataGridView dataGridView = UqRFKf6TbP;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			UqRFKf6TbP = value;
			dataGridView = UqRFKf6TbP;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual Button btPesquisar
	{
		[CompilerGenerated]
		get
		{
			return riwFeqlbCM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PUQFwmlb2q;
			Button button = riwFeqlbCM;
			if (button != null)
			{
				button.Click -= value2;
			}
			riwFeqlbCM = value;
			button = riwFeqlbCM;
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
			return S3XF2UY4xi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RgaF6drDb2;
			DataGridView dataGridView = S3XF2UY4xi;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			S3XF2UY4xi = value;
			dataGridView = S3XF2UY4xi;
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
			return v4AFntIv3f;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			v4AFntIv3f = value;
		}
	}

	internal virtual Label Label7
	{
		[CompilerGenerated]
		get
		{
			return EmPF1bET6E;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EmPF1bET6E = value;
		}
	}

	internal virtual Label Label6
	{
		[CompilerGenerated]
		get
		{
			return tPFFlPuL34;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tPFFlPuL34 = value;
		}
	}

	internal virtual Label Label5
	{
		[CompilerGenerated]
		get
		{
			return RYgF5rYqHt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			RYgF5rYqHt = value;
		}
	}

	internal virtual Label Label4
	{
		[CompilerGenerated]
		get
		{
			return ll8F0nOAOj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ll8F0nOAOj = value;
		}
	}

	internal virtual Label Label3
	{
		[CompilerGenerated]
		get
		{
			return s4JFROsIuN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			s4JFROsIuN = value;
		}
	}

	internal virtual Label Label2
	{
		[CompilerGenerated]
		get
		{
			return rjtFmsEfJ0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rjtFmsEfJ0 = value;
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return MaeFXWZxbs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MaeFXWZxbs = value;
		}
	}

	internal virtual TextBox tbCB
	{
		[CompilerGenerated]
		get
		{
			return BhYFUtAlPF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = GyKFNUFEJ0;
			TextBox textBox = BhYFUtAlPF;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			BhYFUtAlPF = value;
			textBox = BhYFUtAlPF;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual TextBox tbPB
	{
		[CompilerGenerated]
		get
		{
			return vYCFyNBPP4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = Oe3F8qWLGl;
			TextBox textBox = vYCFyNBPP4;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			vYCFyNBPP4 = value;
			textBox = vYCFyNBPP4;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual TextBox tbPC
	{
		[CompilerGenerated]
		get
		{
			return yKtFgkjbI7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = yGXFaKSNkW;
			TextBox textBox = yKtFgkjbI7;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			yKtFgkjbI7 = value;
			textBox = yKtFgkjbI7;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual TextBox tbBB
	{
		[CompilerGenerated]
		get
		{
			return iETFAdFhcM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = xJxFqouOvJ;
			TextBox textBox = iETFAdFhcM;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			iETFAdFhcM = value;
			textBox = iETFAdFhcM;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual TextBox tbCC
	{
		[CompilerGenerated]
		get
		{
			return lr7FsS5Jls;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = MAJF7LnoOt;
			TextBox textBox = lr7FsS5Jls;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			lr7FsS5Jls = value;
			textBox = lr7FsS5Jls;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual TextBox tbPP
	{
		[CompilerGenerated]
		get
		{
			return BZqFBmhhYD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = AALFIocoeD;
			TextBox textBox = BZqFBmhhYD;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			BZqFBmhhYD = value;
			textBox = BZqFBmhhYD;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual TextBox tbDisp
	{
		[CompilerGenerated]
		get
		{
			return lR1FVS31SN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = o0qFO86fQq;
			TextBox textBox = lR1FVS31SN;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			lR1FVS31SN = value;
			textBox = lR1FVS31SN;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual DataGridView dgFiacao
	{
		[CompilerGenerated]
		get
		{
			return iRRFulOqUN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			iRRFulOqUN = value;
		}
	}

	internal virtual Button btCopiar
	{
		[CompilerGenerated]
		get
		{
			return TAtFEncAKH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MAGFMwkat7;
			Button button = TAtFEncAKH;
			if (button != null)
			{
				button.Click -= value2;
			}
			TAtFEncAKH = value;
			button = TAtFEncAKH;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btSalvar
	{
		[CompilerGenerated]
		get
		{
			return RfrFZDXFR8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Il7FbHS2dD;
			Button button = RfrFZDXFR8;
			if (button != null)
			{
				button.Click -= value2;
			}
			RfrFZDXFR8 = value;
			button = RfrFZDXFR8;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label Label8
	{
		[CompilerGenerated]
		get
		{
			return yuBFieCN42;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			yuBFieCN42 = value;
		}
	}

	internal virtual TextBox tbQCON
	{
		[CompilerGenerated]
		get
		{
			return jstFSxnIrL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jstFSxnIrL = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && VKaFPsb3ye != null)
			{
				VKaFPsb3ye.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void mvTFv7NxGb()
	{
		VKaFPsb3ye = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		dgRevisao = new DataGridView();
		dgEquip = new DataGridView();
		btPesquisar = new Button();
		dgDWG = new DataGridView();
		FDqpBiUmZij(new ToolTip(VKaFPsb3ye));
		GroupBox1 = new GroupBox();
		Label7 = new Label();
		Label6 = new Label();
		Label5 = new Label();
		Label4 = new Label();
		Label3 = new Label();
		Label2 = new Label();
		Label1 = new Label();
		tbCB = new TextBox();
		tbPB = new TextBox();
		tbPC = new TextBox();
		tbBB = new TextBox();
		tbCC = new TextBox();
		tbPP = new TextBox();
		tbDisp = new TextBox();
		dgFiacao = new DataGridView();
		btCopiar = new Button();
		btSalvar = new Button();
		Label8 = new Label();
		tbQCON = new TextBox();
		((ISupportInitialize)dgRevisao).BeginInit();
		((ISupportInitialize)dgEquip).BeginInit();
		((ISupportInitialize)dgDWG).BeginInit();
		GroupBox1.SuspendLayout();
		((ISupportInitialize)dgFiacao).BeginInit();
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
		dgEquip.Size = new Size(138, 307);
		dgEquip.TabIndex = 8;
		btPesquisar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisar.FlatStyle = FlatStyle.Flat;
		btPesquisar.ForeColor = SystemColors.Control;
		btPesquisar.Image = Resources.Pesquisar_32;
		btPesquisar.Location = new Point(12, 458);
		btPesquisar.Name = "btPesquisar";
		btPesquisar.Size = new Size(40, 42);
		btPesquisar.TabIndex = 15;
		btPesquisar.UseVisualStyleBackColor = true;
		dgDWG.AllowUserToAddRows = false;
		dgDWG.AllowUserToDeleteRows = false;
		dgDWG.AllowUserToOrderColumns = true;
		dgDWG.AllowUserToResizeRows = false;
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
		dgDWG.Location = new Point(12, 12);
		dgDWG.MultiSelect = false;
		dgDWG.Name = "dgDWG";
		dgDWG.ReadOnly = true;
		dgDWG.RowHeadersVisible = false;
		dgDWG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgDWG.Size = new Size(234, 175);
		dgDWG.TabIndex = 17;
		GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		GroupBox1.Controls.Add(Label7);
		GroupBox1.Controls.Add(Label6);
		GroupBox1.Controls.Add(Label5);
		GroupBox1.Controls.Add(Label4);
		GroupBox1.Controls.Add(Label3);
		GroupBox1.Controls.Add(Label2);
		GroupBox1.Controls.Add(Label1);
		GroupBox1.Controls.Add(tbCB);
		GroupBox1.Controls.Add(tbPB);
		GroupBox1.Controls.Add(tbPC);
		GroupBox1.Controls.Add(tbBB);
		GroupBox1.Controls.Add(tbCC);
		GroupBox1.Controls.Add(tbPP);
		GroupBox1.Controls.Add(tbDisp);
		GroupBox1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		GroupBox1.Location = new Point(255, 12);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(221, 215);
		GroupBox1.TabIndex = 18;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "GroupBox1";
		Label7.AutoSize = true;
		Label7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Label7.Location = new Point(6, 189);
		Label7.Name = "Label7";
		Label7.Size = new Size(39, 13);
		Label7.TabIndex = 13;
		Label7.Text = "Label7";
		Label6.AutoSize = true;
		Label6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Label6.Location = new Point(6, 163);
		Label6.Name = "Label6";
		Label6.Size = new Size(39, 13);
		Label6.TabIndex = 12;
		Label6.Text = "Label6";
		Label5.AutoSize = true;
		Label5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Label5.Location = new Point(6, 137);
		Label5.Name = "Label5";
		Label5.Size = new Size(39, 13);
		Label5.TabIndex = 11;
		Label5.Text = "Label5";
		Label4.AutoSize = true;
		Label4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Label4.Location = new Point(6, 111);
		Label4.Name = "Label4";
		Label4.Size = new Size(39, 13);
		Label4.TabIndex = 10;
		Label4.Text = "Label4";
		Label3.AutoSize = true;
		Label3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Label3.Location = new Point(6, 85);
		Label3.Name = "Label3";
		Label3.Size = new Size(39, 13);
		Label3.TabIndex = 9;
		Label3.Text = "Label3";
		Label2.AutoSize = true;
		Label2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Label2.Location = new Point(6, 59);
		Label2.Name = "Label2";
		Label2.Size = new Size(39, 13);
		Label2.TabIndex = 8;
		Label2.Text = "Label2";
		Label1.AutoSize = true;
		Label1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Label1.Location = new Point(6, 33);
		Label1.Name = "Label1";
		Label1.Size = new Size(39, 13);
		Label1.TabIndex = 7;
		Label1.Text = "Label1";
		tbCB.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbCB.Location = new Point(140, 186);
		tbCB.Name = "tbCB";
		tbCB.Size = new Size(71, 21);
		tbCB.TabIndex = 6;
		tbPB.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbPB.Location = new Point(140, 160);
		tbPB.Name = "tbPB";
		tbPB.Size = new Size(71, 21);
		tbPB.TabIndex = 5;
		tbPC.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbPC.Location = new Point(140, 134);
		tbPC.Name = "tbPC";
		tbPC.Size = new Size(71, 21);
		tbPC.TabIndex = 4;
		tbBB.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbBB.Location = new Point(140, 108);
		tbBB.Name = "tbBB";
		tbBB.Size = new Size(71, 21);
		tbBB.TabIndex = 3;
		tbCC.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbCC.Location = new Point(140, 82);
		tbCC.Name = "tbCC";
		tbCC.Size = new Size(71, 21);
		tbCC.TabIndex = 2;
		tbPP.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbPP.Location = new Point(140, 56);
		tbPP.Name = "tbPP";
		tbPP.Size = new Size(71, 21);
		tbPP.TabIndex = 1;
		tbDisp.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbDisp.Location = new Point(140, 30);
		tbDisp.Name = "tbDisp";
		tbDisp.Size = new Size(71, 21);
		tbDisp.TabIndex = 0;
		dgFiacao.AllowUserToAddRows = false;
		dgFiacao.AllowUserToDeleteRows = false;
		dgFiacao.AllowUserToResizeRows = false;
		dgFiacao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
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
		dgFiacao.Location = new Point(255, 281);
		dgFiacao.Name = "dgFiacao";
		dgFiacao.ReadOnly = true;
		dgFiacao.RowHeadersVisible = false;
		dgFiacao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgFiacao.Size = new Size(221, 186);
		dgFiacao.TabIndex = 19;
		btCopiar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btCopiar.FlatStyle = FlatStyle.Flat;
		btCopiar.ForeColor = SystemColors.Control;
		btCopiar.Image = Resources.Copy_32;
		btCopiar.Location = new Point(62, 461);
		btCopiar.Name = "btCopiar";
		btCopiar.Size = new Size(40, 40);
		btCopiar.TabIndex = 36;
		btCopiar.UseVisualStyleBackColor = true;
		btSalvar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btSalvar.FlatStyle = FlatStyle.Flat;
		btSalvar.ForeColor = SystemColors.Control;
		btSalvar.Image = Resources.Salvar_32;
		btSalvar.Location = new Point(406, 230);
		btSalvar.Name = "btSalvar";
		btSalvar.Size = new Size(45, 45);
		btSalvar.TabIndex = 37;
		btSalvar.UseVisualStyleBackColor = true;
		Label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Label8.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Label8.Location = new Point(255, 482);
		Label8.Name = "Label8";
		Label8.Size = new Size(172, 18);
		Label8.TabIndex = 38;
		Label8.Text = "Label8";
		Label8.TextAlign = ContentAlignment.MiddleRight;
		tbQCON.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		tbQCON.BackColor = SystemColors.Menu;
		tbQCON.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbQCON.Location = new Point(433, 479);
		tbQCON.Name = "tbQCON";
		tbQCON.Size = new Size(43, 21);
		tbQCON.TabIndex = 14;
		tbQCON.TextAlign = HorizontalAlignment.Center;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(484, 512);
		Controls.Add(tbQCON);
		Controls.Add(Label8);
		Controls.Add(btSalvar);
		Controls.Add(btCopiar);
		Controls.Add(dgFiacao);
		Controls.Add(GroupBox1);
		Controls.Add(dgDWG);
		Controls.Add(btPesquisar);
		Controls.Add(dgEquip);
		Controls.Add(dgRevisao);
		MaximumSize = new Size(500, 1000);
		MinimumSize = new Size(500, 550);
		Name = "frmRelatorio_EstatisticaFiacao";
		ShowInTaskbar = false;
		Text = "Estatística de Fiação";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		((ISupportInitialize)dgDWG).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		((ISupportInitialize)dgFiacao).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return NASF3Rm7uo;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		NASF3Rm7uo = WithEventsValue;
	}

	public frmRelatorio_EstatisticaFiacao()
	{
		Resize += l7xFFhGF6c;
		ThLF4OHJ9J = new DeclaracoesFiacao.structurePnRev[1];
		e6uFCPiv5h = new DeclaracoesFiacao.structureRevisoes[1];
		fXUFYOS7hp = 0;
		cqeFr09sMC = "";
		oGdF9PwIgH = 0;
		nc0FzZjseh = false;
		PpBQW4Ihcf = false;
		try
		{
			if (!Geral.ExisteForm("frmRelatorio_EstatisticaFiacao"))
			{
				mvTFv7NxGb();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1482]);
				w8dpBZ0kvSD().SetToolTip(btPesquisar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 775]));
				GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1483]);
				Label1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1484]);
				Label2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1485]);
				Label3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1486]);
				Label4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1487]);
				Label5.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1488]);
				Label6.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1489]);
				Label7.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1490]);
				Label8.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1537]);
				cDadosAccess.carregaDadosDWG();
				Application.ShowModelessDialog((Form)this);
				formataDGDWG();
				formataDGRevisao();
				formataDGEquip();
				formataDGFiacao();
				CarregaDGDWG();
				tbQCON.Text = "";
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

	private void RgaF6drDb2(object P_0, EventArgs P_1)
	{
		nc0FzZjseh = true;
		dgRevisao.Rows.Clear();
		nc0FzZjseh = false;
		PpBQW4Ihcf = true;
		dgEquip.Rows.Clear();
		PpBQW4Ihcf = false;
		fYDFtCyLay();
		tbQCON.Text = "";
	}

	private void fYDFtCyLay()
	{
		fXUFYOS7hp = Conversions.ToInteger(dgDWG.SelectedRows[0].Cells[0].Value);
		e6uFCPiv5h = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			cDadosAccessFiacao2.CarregaRevisoesDwgCorrente(fXUFYOS7hp, ref e6uFCPiv5h);
			nc0FzZjseh = true;
			dgRevisao.Rows.Clear();
			nc0FzZjseh = false;
			int num = Information.UBound(e6uFCPiv5h);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				dgRevisao.Rows.Add(e6uFCPiv5h[i].revisao);
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

	private void vJtFjj7ZOx(object P_0, EventArgs P_1)
	{
		PpBQW4Ihcf = true;
		dgEquip.Rows.Clear();
		PpBQW4Ihcf = false;
		if (!nc0FzZjseh)
		{
			o4kFLTEqK5();
		}
		tbQCON.Text = "";
	}

	private void o4kFLTEqK5()
	{
		CarregaPnRev();
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (dgRevisao.SelectedRows.Count != 1)
			{
				return;
			}
			cqeFr09sMC = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
			PpBQW4Ihcf = true;
			dgEquip.Rows.Clear();
			PpBQW4Ihcf = false;
			int num = Information.UBound(ThLF4OHJ9J);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(ThLF4OHJ9J[i].revisao, cqeFr09sMC, TextCompare: true) == 0)
				{
					dgEquip.Rows.Add(ThLF4OHJ9J[i].painel, Dicionario.BuscaNomeDoPainel(ThLF4OHJ9J[i].painel));
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
		tbQCON.Text = "";
		ThLF4OHJ9J = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (Information.UBound(e6uFCPiv5h) > 0)
			{
				int num = Information.UBound(e6uFCPiv5h);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessFiacao2.CarregaPnRev(fXUFYOS7hp, e6uFCPiv5h[i].revisao, ref ThLF4OHJ9J);
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

	private void PUQFwmlb2q(object P_0, EventArgs P_1)
	{
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		formataDGFiacao();
		if (dgEquip.SelectedRows.Count == 0)
		{
			return;
		}
		oGdF9PwIgH = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
		DeclaracoesFiacao.structureEstatFiacao[] array = new DeclaracoesFiacao.structureEstatFiacao[1];
		tbQCON.Text = "";
		int num = 0;
		checked
		{
			try
			{
				DeclaracoesFiacao.structurePotencial[] mPotencial = new DeclaracoesFiacao.structurePotencial[1];
				cDadosAccessFiacao2.CarregaPotenciaisPainelEstat(fXUFYOS7hp, cqeFr09sMC, oGdF9PwIgH, ref mPotencial);
				if (Information.UBound(mPotencial) < 2)
				{
					return;
				}
				int num2 = 0;
				int num3 = Information.UBound(mPotencial);
				for (int i = 1; i <= num3; i++)
				{
					int potencial = mPotencial[i].Potencial;
					if (num2 == potencial)
					{
						string tag = mPotencial[i - 1].Tag;
						int posicaoNum = mPotencial[i - 1].PosicaoNum;
						string tag2 = mPotencial[i].Tag;
						int posicaoNum2 = mPotencial[i].PosicaoNum;
						bool flag = false;
						if ((mPotencial[i - 1].bLink & mPotencial[i].bLink) && mPotencial[i - 1].indexModelo == mPotencial[i].indexModelo && cDadosAccessFiacao2.BornesVizinhos(fXUFYOS7hp, cqeFr09sMC, oGdF9PwIgH, mPotencial[i].indexModelo, mPotencial[i - 1].Terminal, mPotencial[i].Terminal))
						{
							flag = true;
						}
						if (flag)
						{
							continue;
						}
						num++;
						string secao = mPotencial[i].Secao;
						string cor = mPotencial[i].Cor;
						int num4 = 0;
						int num5 = Information.UBound(array);
						for (int j = 1; j <= num5; j++)
						{
							if ((Operators.CompareString(array[j].secao, secao, TextCompare: true) == 0) & (Operators.CompareString(array[j].cor, cor, TextCompare: true) == 0))
							{
								num4 = j;
								break;
							}
						}
						if (num4 == 0)
						{
							num4 = Information.UBound(array) + 1;
							array = (DeclaracoesFiacao.structureEstatFiacao[])Utils.CopyArray(array, new DeclaracoesFiacao.structureEstatFiacao[num4 + 1]);
							array[num4].secao = secao;
							array[num4].cor = cor;
						}
						if (Operators.CompareString(tag, tag2, TextCompare: true) != 0)
						{
							if (posicaoNum != posicaoNum2)
							{
								if (!(((posicaoNum == 3) & (posicaoNum2 == 2)) | ((posicaoNum == 2) & (posicaoNum2 == 3))))
								{
									if (!(((posicaoNum == 3) & (posicaoNum2 == 1)) | ((posicaoNum == 1) & (posicaoNum2 == 3))))
									{
										if (((posicaoNum == 2) & (posicaoNum2 == 1)) | ((posicaoNum == 1) & (posicaoNum2 == 2)))
										{
											array[num4].comprimento += Conversions.ToDouble(tbCB.Text);
										}
									}
									else
									{
										array[num4].comprimento += Conversions.ToDouble(tbPB.Text);
									}
								}
								else
								{
									array[num4].comprimento += Conversions.ToDouble(tbPC.Text);
								}
								continue;
							}
							switch (posicaoNum)
							{
							case 1:
								array[num4].comprimento += Conversions.ToDouble(tbBB.Text);
								break;
							case 3:
								array[num4].comprimento += Conversions.ToDouble(tbPP.Text);
								break;
							case 2:
								array[num4].comprimento += Conversions.ToDouble(tbCC.Text);
								break;
							}
						}
						else
						{
							array[num4].comprimento += Conversions.ToDouble(tbDisp.Text);
						}
					}
					else
					{
						num2 = potencial;
					}
				}
				int num6 = Information.UBound(array);
				for (int k = 1; k <= num6; k++)
				{
					dgFiacao.Rows.Add(array[k].secao, array[k].cor, Math.Round(array[k].comprimento, 1));
				}
				tbQCON.Text = num.ToString();
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

	private void RcPFxTUYJ5(object P_0, EventArgs P_1)
	{
		if (!PpBQW4Ihcf && dgEquip.Rows.Count != 0)
		{
			string numberDecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			oGdF9PwIgH = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
			cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
			string valor = "";
			long num = 0L;
			num = cDadosAccessFiacao2.ExisteItemPreferencias(fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_DISP", ref valor);
			if (num <= 0L)
			{
				tbDisp.Text = "0" + numberDecimalSeparator + "05";
			}
			else
			{
				tbDisp.Text = valor;
			}
			num = cDadosAccessFiacao2.ExisteItemPreferencias(fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_PP", ref valor);
			if (num <= 0L)
			{
				tbPP.Text = "0" + numberDecimalSeparator + "5";
			}
			else
			{
				tbPP.Text = valor;
			}
			num = cDadosAccessFiacao2.ExisteItemPreferencias(fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_CC", ref valor);
			if (num <= 0L)
			{
				tbCC.Text = "0" + numberDecimalSeparator + "5";
			}
			else
			{
				tbCC.Text = valor;
			}
			num = cDadosAccessFiacao2.ExisteItemPreferencias(fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_BB", ref valor);
			if (num <= 0L)
			{
				tbBB.Text = "1" + numberDecimalSeparator + "5";
			}
			else
			{
				tbBB.Text = valor;
			}
			num = cDadosAccessFiacao2.ExisteItemPreferencias(fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_PC", ref valor);
			if (num <= 0L)
			{
				tbPC.Text = "1" + numberDecimalSeparator + "5";
			}
			else
			{
				tbPC.Text = valor;
			}
			num = cDadosAccessFiacao2.ExisteItemPreferencias(fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_PB", ref valor);
			if (num <= 0L)
			{
				tbPB.Text = "2" + numberDecimalSeparator + "0";
			}
			else
			{
				tbPB.Text = valor;
			}
			num = cDadosAccessFiacao2.ExisteItemPreferencias(fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_CB", ref valor);
			if (num <= 0L)
			{
				tbCB.Text = "1" + numberDecimalSeparator + "5";
			}
			else
			{
				tbCB.Text = valor;
			}
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	private void Il7FbHS2dD(object P_0, EventArgs P_1)
	{
		if (dgEquip.SelectedRows.Count != 0)
		{
			oGdF9PwIgH = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
			cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
			string valor = "";
			long num = 0L;
			num = cDadosAccessFiacao2.ExisteItemPreferencias(fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_DISP", ref valor);
			valor = tbDisp.Text.Trim();
			if (num <= 0L)
			{
				cDadosAccessFiacao2.AdicionaItemPreferencias(fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_DISP", valor);
			}
			else
			{
				cDadosAccessFiacao2.AtualizaItemPreferencias(num, fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_DISP", valor);
			}
			num = cDadosAccessFiacao2.ExisteItemPreferencias(fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_PP", ref valor);
			valor = tbPP.Text.Trim();
			if (num <= 0L)
			{
				cDadosAccessFiacao2.AdicionaItemPreferencias(fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_PP", valor);
			}
			else
			{
				cDadosAccessFiacao2.AtualizaItemPreferencias(num, fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_PP", valor);
			}
			num = cDadosAccessFiacao2.ExisteItemPreferencias(fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_CC", ref valor);
			valor = tbCC.Text.Trim();
			if (num <= 0L)
			{
				cDadosAccessFiacao2.AdicionaItemPreferencias(fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_CC", valor);
			}
			else
			{
				cDadosAccessFiacao2.AtualizaItemPreferencias(num, fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_CC", valor);
			}
			num = cDadosAccessFiacao2.ExisteItemPreferencias(fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_BB", ref valor);
			valor = tbBB.Text.Trim();
			if (num <= 0L)
			{
				cDadosAccessFiacao2.AdicionaItemPreferencias(fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_BB", valor);
			}
			else
			{
				cDadosAccessFiacao2.AtualizaItemPreferencias(num, fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_BB", valor);
			}
			num = cDadosAccessFiacao2.ExisteItemPreferencias(fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_PC", ref valor);
			valor = tbPC.Text.Trim();
			if (num <= 0L)
			{
				cDadosAccessFiacao2.AdicionaItemPreferencias(fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_PC", valor);
			}
			else
			{
				cDadosAccessFiacao2.AtualizaItemPreferencias(num, fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_PC", valor);
			}
			num = cDadosAccessFiacao2.ExisteItemPreferencias(fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_PB", ref valor);
			valor = tbPB.Text.Trim();
			if (num <= 0L)
			{
				cDadosAccessFiacao2.AdicionaItemPreferencias(fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_PB", valor);
			}
			else
			{
				cDadosAccessFiacao2.AtualizaItemPreferencias(num, fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_PB", valor);
			}
			num = cDadosAccessFiacao2.ExisteItemPreferencias(fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_CB", ref valor);
			valor = tbCB.Text.Trim();
			if (num <= 0L)
			{
				cDadosAccessFiacao2.AdicionaItemPreferencias(fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_CB", valor);
			}
			else
			{
				cDadosAccessFiacao2.AtualizaItemPreferencias(num, fXUFYOS7hp, oGdF9PwIgH, "COMP_MEDIO_CB", valor);
			}
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	private void MAGFMwkat7(object P_0, EventArgs P_1)
	{
		checked
		{
			try
			{
				string text = "";
				if (dgFiacao.RowCount > 0)
				{
					short num = (short)(dgFiacao.RowCount - 1);
					for (short num2 = 0; num2 <= num; num2 = (short)unchecked(num2 + 1))
					{
						string text2 = Conversions.ToString(dgFiacao.Rows[num2].Cells[0].Value);
						string text3 = Conversions.ToString(dgFiacao.Rows[num2].Cells[1].Value);
						string text4 = Conversions.ToString(dgFiacao.Rows[num2].Cells[2].Value);
						text4 = text4.Replace(".", ",");
						text = text + text2 + "\t" + text3 + "\t" + text4 + "\r\n";
					}
					Clipboard.SetText(text);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
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
				PpBQW4Ihcf = true;
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
				PpBQW4Ihcf = false;
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
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 781]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 782]));
				dgFiacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1246]));
				float num = dgFiacao.Width - 20;
				dgFiacao.Columns[0].Width = (int)Math.Round(num / 4f);
				dgFiacao.Columns[1].Width = (int)Math.Round(num / 4f);
				dgFiacao.Columns[2].Width = (int)Math.Round(num * 2f / 4f);
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

	private void o0qFO86fQq(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void AALFIocoeD(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void MAJF7LnoOt(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void xJxFqouOvJ(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void yGXFaKSNkW(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void Oe3F8qWLGl(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void GyKFNUFEJ0(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void l7xFFhGF6c(object P_0, EventArgs P_1)
	{
		CshFQwhire();
	}

	private void CshFQwhire()
	{
		checked
		{
			if (dgFiacao.Columns.Count == 3)
			{
				float num = dgFiacao.Width - 20;
				dgFiacao.Columns[0].Width = (int)Math.Round(num / 4f);
				dgFiacao.Columns[1].Width = (int)Math.Round(num / 4f);
				dgFiacao.Columns[2].Width = (int)Math.Round(num * 2f / 4f);
			}
		}
	}
}
