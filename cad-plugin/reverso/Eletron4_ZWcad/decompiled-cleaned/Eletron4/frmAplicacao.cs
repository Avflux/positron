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
using ZwSoft.ZwCAD.Windows;
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmAplicacao : Form
{
	private IContainer wm5Jr0jLHI;

	[AccessedThroughProperty("dgAplicacao")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView gkbJ9NgvrV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbNome")]
	private TextBox c41JzNPD71;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbSecao")]
	[CompilerGenerated]
	private TextBox gXRhWH0hPt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbCor")]
	private TextBox KLchpMSXNf;

	[CompilerGenerated]
	[AccessedThroughProperty("tbTipoCabo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox ghAhTUfG6x;

	[AccessedThroughProperty("tbIsolacao")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox H7RhJNQFJS;

	[CompilerGenerated]
	[AccessedThroughProperty("btAddApl")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button q3phh4VuiK;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("tbIndex")]
	private TextBox UbihoFB846;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblNome")]
	[CompilerGenerated]
	private Label hK0hGAjRxJ;

	[CompilerGenerated]
	[AccessedThroughProperty("lblSecao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label HLShHRXuIQ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("lblCor")]
	private Label pTyhkVTDOC;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblTipoCabo")]
	[CompilerGenerated]
	private Label Ivnhd1yqf8;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblIsolacao")]
	private Label CWJhfJhIno;

	[AccessedThroughProperty("GroupBox1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox MJxhDjvOcH;

	[AccessedThroughProperty("Label1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label si8hvfxyqX;

	[AccessedThroughProperty("btDelApl")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button k2Mh6AHhpN;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btEditaApl")]
	private Button XyJhtUQgya;

	[CompilerGenerated]
	[AccessedThroughProperty("btPagina")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button o1Nhj4ub6l;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSelecao")]
	private Button TYHhLe40BM;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSiemens")]
	private Button Rmshw8ZTk4;

	[AccessedThroughProperty("btLiga")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button i5qhxRfVto;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btDesliga")]
	private Button lqthbj5B36;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCorApl")]
	private Button huWhMXtvAM;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip FjyhOanjud;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btDesvincular")]
	private Button YdHhIu4Qme;

	[AccessedThroughProperty("btExportaExcel")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button YjOh7VxEbu;

	[AccessedThroughProperty("btImportaExcel")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button KtShqyQ4mc;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("dgPag")]
	private DataGridView i7dhaPj5jK;

	private DeclaracoesFiacao.structureAplicacao[] ICgh8rDvCy;

	private List<int> XsohNgQqGY;

	private List<string> lO9hFtr2V7;

	private int t8uhQ9EtCj;

	private ColorDialog jLchP5nuvi;

	private int nKIhc4MfeT;

	private Dictionary<string, int> l6OhKsj3cs;

	private DeclaracoesFiacao.structureAplicacao[] NoyheZueGQ;

	private List<int> gADh2Wt2uh;

	private int uOCh3xrA3b;

	internal virtual DataGridView dgAplicacao
	{
		[CompilerGenerated]
		get
		{
			return gkbJ9NgvrV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VL4JlaU1oW;
			DataGridView dataGridView = gkbJ9NgvrV;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			gkbJ9NgvrV = value;
			dataGridView = gkbJ9NgvrV;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual TextBox tbNome
	{
		[CompilerGenerated]
		get
		{
			return c41JzNPD71;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			c41JzNPD71 = value;
		}
	}

	internal virtual TextBox tbSecao
	{
		[CompilerGenerated]
		get
		{
			return gXRhWH0hPt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			gXRhWH0hPt = value;
		}
	}

	internal virtual TextBox tbCor
	{
		[CompilerGenerated]
		get
		{
			return KLchpMSXNf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KLchpMSXNf = value;
		}
	}

	internal virtual TextBox tbTipoCabo
	{
		[CompilerGenerated]
		get
		{
			return ghAhTUfG6x;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ghAhTUfG6x = value;
		}
	}

	internal virtual TextBox tbIsolacao
	{
		[CompilerGenerated]
		get
		{
			return H7RhJNQFJS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			H7RhJNQFJS = value;
		}
	}

	internal virtual Button btAddApl
	{
		[CompilerGenerated]
		get
		{
			return q3phh4VuiK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tskJ1cCL4B;
			Button button = q3phh4VuiK;
			if (button != null)
			{
				button.Click -= value2;
			}
			q3phh4VuiK = value;
			button = q3phh4VuiK;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbIndex
	{
		[CompilerGenerated]
		get
		{
			return UbihoFB846;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			UbihoFB846 = value;
		}
	}

	internal virtual Label lblNome
	{
		[CompilerGenerated]
		get
		{
			return hK0hGAjRxJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			hK0hGAjRxJ = value;
		}
	}

	internal virtual Label lblSecao
	{
		[CompilerGenerated]
		get
		{
			return HLShHRXuIQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			HLShHRXuIQ = value;
		}
	}

	internal virtual Label lblCor
	{
		[CompilerGenerated]
		get
		{
			return pTyhkVTDOC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pTyhkVTDOC = value;
		}
	}

	internal virtual Label lblTipoCabo
	{
		[CompilerGenerated]
		get
		{
			return Ivnhd1yqf8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Ivnhd1yqf8 = value;
		}
	}

	internal virtual Label lblIsolacao
	{
		[CompilerGenerated]
		get
		{
			return CWJhfJhIno;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CWJhfJhIno = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return MJxhDjvOcH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MJxhDjvOcH = value;
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return si8hvfxyqX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			si8hvfxyqX = value;
		}
	}

	internal virtual Button btDelApl
	{
		[CompilerGenerated]
		get
		{
			return k2Mh6AHhpN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = efNJ0bbnT2;
			Button button = k2Mh6AHhpN;
			if (button != null)
			{
				button.Click -= value2;
			}
			k2Mh6AHhpN = value;
			button = k2Mh6AHhpN;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btEditaApl
	{
		[CompilerGenerated]
		get
		{
			return XyJhtUQgya;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = rlVJ5f71gi;
			Button button = XyJhtUQgya;
			if (button != null)
			{
				button.Click -= value2;
			}
			XyJhtUQgya = value;
			button = XyJhtUQgya;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btPagina
	{
		[CompilerGenerated]
		get
		{
			return o1Nhj4ub6l;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = vJDJmAnXj6;
			Button button = o1Nhj4ub6l;
			if (button != null)
			{
				button.Click -= value2;
			}
			o1Nhj4ub6l = value;
			button = o1Nhj4ub6l;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btSelecao
	{
		[CompilerGenerated]
		get
		{
			return TYHhLe40BM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PCXJRuWq7Z;
			Button button = TYHhLe40BM;
			if (button != null)
			{
				button.Click -= value2;
			}
			TYHhLe40BM = value;
			button = TYHhLe40BM;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btSiemens
	{
		[CompilerGenerated]
		get
		{
			return Rmshw8ZTk4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NdoJBXfnaY;
			Button button = Rmshw8ZTk4;
			if (button != null)
			{
				button.Click -= value2;
			}
			Rmshw8ZTk4 = value;
			button = Rmshw8ZTk4;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btLiga
	{
		[CompilerGenerated]
		get
		{
			return i5qhxRfVto;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NeJJU9wFQZ;
			Button button = i5qhxRfVto;
			if (button != null)
			{
				button.Click -= value2;
			}
			i5qhxRfVto = value;
			button = i5qhxRfVto;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btDesliga
	{
		[CompilerGenerated]
		get
		{
			return lqthbj5B36;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = wppJgBohZI;
			Button button = lqthbj5B36;
			if (button != null)
			{
				button.Click -= value2;
			}
			lqthbj5B36 = value;
			button = lqthbj5B36;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btCorApl
	{
		[CompilerGenerated]
		get
		{
			return huWhMXtvAM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = df9Jso1mGH;
			Button button = huWhMXtvAM;
			if (button != null)
			{
				button.Click -= value2;
			}
			huWhMXtvAM = value;
			button = huWhMXtvAM;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btDesvincular
	{
		[CompilerGenerated]
		get
		{
			return YdHhIu4Qme;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VWvJXgvLfu;
			Button button = YdHhIu4Qme;
			if (button != null)
			{
				button.Click -= value2;
			}
			YdHhIu4Qme = value;
			button = YdHhIu4Qme;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btExportaExcel
	{
		[CompilerGenerated]
		get
		{
			return YjOh7VxEbu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = vC0JZdG4f4;
			Button button = YjOh7VxEbu;
			if (button != null)
			{
				button.Click -= value2;
			}
			YjOh7VxEbu = value;
			button = YjOh7VxEbu;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btImportaExcel
	{
		[CompilerGenerated]
		get
		{
			return KtShqyQ4mc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = phyJiokJSf;
			Button button = KtShqyQ4mc;
			if (button != null)
			{
				button.Click -= value2;
			}
			KtShqyQ4mc = value;
			button = KtShqyQ4mc;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgPag
	{
		[CompilerGenerated]
		get
		{
			return i7dhaPj5jK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			i7dhaPj5jK = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && wm5Jr0jLHI != null)
			{
				wm5Jr0jLHI.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void QZGJnpqQ6Q()
	{
		wm5Jr0jLHI = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		dgAplicacao = new DataGridView();
		tbNome = new TextBox();
		tbSecao = new TextBox();
		tbCor = new TextBox();
		tbTipoCabo = new TextBox();
		tbIsolacao = new TextBox();
		btAddApl = new Button();
		tbIndex = new TextBox();
		lblNome = new Label();
		lblSecao = new Label();
		lblCor = new Label();
		lblTipoCabo = new Label();
		lblIsolacao = new Label();
		GroupBox1 = new GroupBox();
		Label1 = new Label();
		btDelApl = new Button();
		btEditaApl = new Button();
		btPagina = new Button();
		btSelecao = new Button();
		btSiemens = new Button();
		btLiga = new Button();
		btDesliga = new Button();
		btCorApl = new Button();
		FDqpBiUmZij(new ToolTip(wm5Jr0jLHI));
		btDesvincular = new Button();
		btExportaExcel = new Button();
		btImportaExcel = new Button();
		dgPag = new DataGridView();
		((ISupportInitialize)dgAplicacao).BeginInit();
		GroupBox1.SuspendLayout();
		((ISupportInitialize)dgPag).BeginInit();
		SuspendLayout();
		dgAplicacao.AllowUserToAddRows = false;
		dgAplicacao.AllowUserToDeleteRows = false;
		dgAplicacao.AllowUserToResizeRows = false;
		dgAplicacao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgAplicacao.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgAplicacao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgAplicacao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgAplicacao.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgAplicacao.Location = new Point(12, 12);
		dgAplicacao.MultiSelect = false;
		dgAplicacao.Name = "dgAplicacao";
		dgAplicacao.ReadOnly = true;
		dgAplicacao.RowHeadersVisible = false;
		dgAplicacao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgAplicacao.Size = new Size(510, 312);
		dgAplicacao.TabIndex = 12;
		tbNome.Location = new Point(47, 32);
		tbNome.MaxLength = 150;
		tbNome.Name = "tbNome";
		tbNome.Size = new Size(175, 20);
		tbNome.TabIndex = 2;
		tbSecao.Location = new Point(12, 73);
		tbSecao.MaxLength = 20;
		tbSecao.Name = "tbSecao";
		tbSecao.Size = new Size(95, 20);
		tbSecao.TabIndex = 3;
		tbCor.Location = new Point(129, 73);
		tbCor.MaxLength = 20;
		tbCor.Name = "tbCor";
		tbCor.Size = new Size(93, 20);
		tbCor.TabIndex = 4;
		tbTipoCabo.Location = new Point(12, 114);
		tbTipoCabo.MaxLength = 150;
		tbTipoCabo.Name = "tbTipoCabo";
		tbTipoCabo.Size = new Size(210, 20);
		tbTipoCabo.TabIndex = 5;
		tbIsolacao.Location = new Point(12, 156);
		tbIsolacao.MaxLength = 150;
		tbIsolacao.Name = "tbIsolacao";
		tbIsolacao.Size = new Size(210, 20);
		tbIsolacao.TabIndex = 6;
		btAddApl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btAddApl.FlatStyle = FlatStyle.Flat;
		btAddApl.ForeColor = SystemColors.Control;
		btAddApl.Image = Resources.Adiciona_32;
		btAddApl.Location = new Point(780, 202);
		btAddApl.Name = "btAddApl";
		btAddApl.Size = new Size(40, 40);
		btAddApl.TabIndex = 7;
		btAddApl.UseVisualStyleBackColor = true;
		tbIndex.BackColor = SystemColors.InactiveCaption;
		tbIndex.Location = new Point(12, 32);
		tbIndex.Name = "tbIndex";
		tbIndex.ReadOnly = true;
		tbIndex.Size = new Size(29, 20);
		tbIndex.TabIndex = 1;
		lblNome.AutoSize = true;
		lblNome.Location = new Point(50, 15);
		lblNome.Name = "lblNome";
		lblNome.Size = new Size(35, 13);
		lblNome.TabIndex = 187;
		lblNome.Text = "Nome";
		lblSecao.AutoSize = true;
		lblSecao.Location = new Point(13, 56);
		lblSecao.Name = "lblSecao";
		lblSecao.Size = new Size(38, 13);
		lblSecao.TabIndex = 188;
		lblSecao.Text = "Seção";
		lblCor.AutoSize = true;
		lblCor.Location = new Point(130, 56);
		lblCor.Name = "lblCor";
		lblCor.Size = new Size(23, 13);
		lblCor.TabIndex = 189;
		lblCor.Text = "Cor";
		lblTipoCabo.AutoSize = true;
		lblTipoCabo.Location = new Point(16, 97);
		lblTipoCabo.Name = "lblTipoCabo";
		lblTipoCabo.Size = new Size(71, 13);
		lblTipoCabo.TabIndex = 190;
		lblTipoCabo.Text = "Tipo do Cabo";
		lblIsolacao.AutoSize = true;
		lblIsolacao.Location = new Point(15, 139);
		lblIsolacao.Name = "lblIsolacao";
		lblIsolacao.Size = new Size(47, 13);
		lblIsolacao.TabIndex = 191;
		lblIsolacao.Text = "Isolação";
		GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		GroupBox1.Controls.Add(Label1);
		GroupBox1.Controls.Add(tbCor);
		GroupBox1.Controls.Add(lblIsolacao);
		GroupBox1.Controls.Add(tbNome);
		GroupBox1.Controls.Add(lblTipoCabo);
		GroupBox1.Controls.Add(tbSecao);
		GroupBox1.Controls.Add(lblCor);
		GroupBox1.Controls.Add(tbTipoCabo);
		GroupBox1.Controls.Add(lblSecao);
		GroupBox1.Controls.Add(tbIsolacao);
		GroupBox1.Controls.Add(lblNome);
		GroupBox1.Controls.Add(tbIndex);
		GroupBox1.Location = new Point(593, 5);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(228, 189);
		GroupBox1.TabIndex = 192;
		GroupBox1.TabStop = false;
		Label1.AutoSize = true;
		Label1.Location = new Point(16, 15);
		Label1.Name = "Label1";
		Label1.Size = new Size(14, 13);
		Label1.TabIndex = 192;
		Label1.Text = "#";
		btDelApl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btDelApl.FlatStyle = FlatStyle.Flat;
		btDelApl.ForeColor = SystemColors.Control;
		btDelApl.Image = Resources.Delete_32;
		btDelApl.Location = new Point(684, 202);
		btDelApl.Name = "btDelApl";
		btDelApl.Size = new Size(40, 40);
		btDelApl.TabIndex = 9;
		btDelApl.UseVisualStyleBackColor = true;
		btEditaApl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btEditaApl.FlatStyle = FlatStyle.Flat;
		btEditaApl.ForeColor = SystemColors.Control;
		btEditaApl.Image = Resources.Editar_32;
		btEditaApl.Location = new Point(732, 202);
		btEditaApl.Name = "btEditaApl";
		btEditaApl.Size = new Size(40, 40);
		btEditaApl.TabIndex = 8;
		btEditaApl.UseVisualStyleBackColor = true;
		btPagina.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btPagina.FlatStyle = FlatStyle.Flat;
		btPagina.ForeColor = SystemColors.Control;
		btPagina.Image = Resources.Sel_Paginas_32;
		btPagina.Location = new Point(538, 284);
		btPagina.Name = "btPagina";
		btPagina.Size = new Size(40, 40);
		btPagina.TabIndex = 13;
		btPagina.UseVisualStyleBackColor = true;
		btSelecao.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btSelecao.FlatStyle = FlatStyle.Flat;
		btSelecao.ForeColor = SystemColors.Control;
		btSelecao.Image = Resources.Sel_Conexoes_32;
		btSelecao.Location = new Point(594, 284);
		btSelecao.Name = "btSelecao";
		btSelecao.Size = new Size(40, 40);
		btSelecao.TabIndex = 14;
		btSelecao.UseVisualStyleBackColor = true;
		btSiemens.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btSiemens.ForeColor = SystemColors.Control;
		btSiemens.Image = Resources.Siemens;
		btSiemens.Location = new Point(605, 210);
		btSiemens.Name = "btSiemens";
		btSiemens.Size = new Size(72, 24);
		btSiemens.TabIndex = 10;
		btSiemens.UseVisualStyleBackColor = true;
		btLiga.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btLiga.FlatStyle = FlatStyle.Flat;
		btLiga.ForeColor = SystemColors.Control;
		btLiga.Image = Resources.Liga_32;
		btLiga.Location = new Point(730, 284);
		btLiga.Name = "btLiga";
		btLiga.Size = new Size(40, 40);
		btLiga.TabIndex = 16;
		btLiga.UseVisualStyleBackColor = true;
		btDesliga.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btDesliga.FlatStyle = FlatStyle.Flat;
		btDesliga.ForeColor = SystemColors.Control;
		btDesliga.Image = Resources.Desliga_32;
		btDesliga.Location = new Point(782, 284);
		btDesliga.Name = "btDesliga";
		btDesliga.Size = new Size(40, 40);
		btDesliga.TabIndex = 17;
		btDesliga.UseVisualStyleBackColor = true;
		btCorApl.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btCorApl.BackColor = Color.LimeGreen;
		btCorApl.Location = new Point(764, 294);
		btCorApl.Name = "btCorApl";
		btCorApl.Size = new Size(23, 20);
		btCorApl.TabIndex = 18;
		btCorApl.UseVisualStyleBackColor = false;
		btDesvincular.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btDesvincular.FlatStyle = FlatStyle.Flat;
		btDesvincular.ForeColor = SystemColors.Control;
		btDesvincular.Image = Resources.Desvincular_32;
		btDesvincular.Location = new Point(640, 284);
		btDesvincular.Name = "btDesvincular";
		btDesvincular.Size = new Size(40, 40);
		btDesvincular.TabIndex = 15;
		btDesvincular.UseVisualStyleBackColor = true;
		btExportaExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btExportaExcel.AutoSize = true;
		btExportaExcel.FlatStyle = FlatStyle.Flat;
		btExportaExcel.ForeColor = SystemColors.Control;
		btExportaExcel.Image = Resources.ExportaExcel_20;
		btExportaExcel.Location = new Point(594, 234);
		btExportaExcel.Name = "btExportaExcel";
		btExportaExcel.Size = new Size(40, 48);
		btExportaExcel.TabIndex = 11;
		btExportaExcel.UseVisualStyleBackColor = true;
		btImportaExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btImportaExcel.AutoSize = true;
		btImportaExcel.FlatStyle = FlatStyle.Flat;
		btImportaExcel.ForeColor = SystemColors.Control;
		btImportaExcel.Image = Resources.ImportaExcel_20;
		btImportaExcel.Location = new Point(640, 234);
		btImportaExcel.Name = "btImportaExcel";
		btImportaExcel.Size = new Size(40, 48);
		btImportaExcel.TabIndex = 12;
		btImportaExcel.UseVisualStyleBackColor = true;
		dgPag.AllowUserToAddRows = false;
		dgPag.AllowUserToDeleteRows = false;
		dgPag.AllowUserToResizeRows = false;
		dgPag.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		dgPag.BackgroundColor = Color.White;
		dgPag.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPag.Location = new Point(528, 12);
		dgPag.MultiSelect = false;
		dgPag.Name = "dgPag";
		dgPag.ReadOnly = true;
		dgPag.RowHeadersVisible = false;
		dgPag.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPag.Size = new Size(59, 270);
		dgPag.TabIndex = 193;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(834, 336);
		Controls.Add(dgPag);
		Controls.Add(btDesvincular);
		Controls.Add(btCorApl);
		Controls.Add(btDesliga);
		Controls.Add(btLiga);
		Controls.Add(btSiemens);
		Controls.Add(btSelecao);
		Controls.Add(btPagina);
		Controls.Add(btEditaApl);
		Controls.Add(btDelApl);
		Controls.Add(GroupBox1);
		Controls.Add(btAddApl);
		Controls.Add(dgAplicacao);
		Controls.Add(btImportaExcel);
		Controls.Add(btExportaExcel);
		MinimumSize = new Size(850, 375);
		Name = "frmAplicacao";
		Text = "frmAplicacao";
		((ISupportInitialize)dgAplicacao).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		((ISupportInitialize)dgPag).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return FjyhOanjud;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		FjyhOanjud = WithEventsValue;
	}

	public frmAplicacao()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected Obj, but got Unknown
		Closing += W9FJyAMGZi;
		Resize += uYUJC8Sm2c;
		ICgh8rDvCy = new DeclaracoesFiacao.structureAplicacao[1];
		XsohNgQqGY = new List<int>();
		lO9hFtr2V7 = new List<string>();
		jLchP5nuvi = new ColorDialog();
		l6OhKsj3cs = new Dictionary<string, int>();
		NoyheZueGQ = new DeclaracoesFiacao.structureAplicacao[15];
		gADh2Wt2uh = new List<int>();
		try
		{
			if (!Geral.ExisteForm("frmAplicacao"))
			{
				QZGJnpqQ6Q();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1816]);
				lblNome.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1818]);
				lblSecao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1819]);
				lblCor.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1820]);
				lblTipoCabo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1821]);
				lblIsolacao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1822]);
				w8dpBZ0kvSD().SetToolTip(btSiemens, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1828]));
				w8dpBZ0kvSD().SetToolTip(btDelApl, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1829]));
				w8dpBZ0kvSD().SetToolTip(btEditaApl, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1830]));
				w8dpBZ0kvSD().SetToolTip(btAddApl, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1831]));
				w8dpBZ0kvSD().SetToolTip(btPagina, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1832]));
				w8dpBZ0kvSD().SetToolTip(btSelecao, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1833]));
				w8dpBZ0kvSD().SetToolTip(btLiga, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1834]));
				w8dpBZ0kvSD().SetToolTip(btDesliga, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1835]));
				w8dpBZ0kvSD().SetToolTip(btDesvincular, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1845]));
				Application.ShowModelessDialog((Form)this);
				t8uhQ9EtCj = DicionarioAplicacao.LeOsTiposDeAplicacoes(ref ICgh8rDvCy);
				formataDGAplicacao();
				carregaDGAplicacao();
				HoMJupTZJ5();
				if (dgAplicacao.Rows.Count > 0)
				{
					dgAplicacao.Rows[0].Selected = true;
					dgAplicacao.FirstDisplayedScrollingRowIndex = 0;
				}
				R1KJ4uns5W();
				GJrJS9MPTj();
				clsConexao clsConexao2 = new clsConexao();
				clsConexao2.buscaAplicacoesUsadas(ref XsohNgQqGY, ref lO9hFtr2V7);
				rRxJEN2Ofr();
				CXKJVLR5OM();
				nKIhc4MfeT = 3;
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

	private void tskJ1cCL4B(object P_0, EventArgs P_1)
	{
		checked
		{
			if ((Operators.CompareString(tbNome.Text.Trim(), "", TextCompare: true) != 0) & (Operators.CompareString(tbSecao.Text.Trim(), "", TextCompare: true) != 0) & (Operators.CompareString(tbCor.Text.Trim(), "", TextCompare: true) != 0) & (Operators.CompareString(tbTipoCabo.Text.Trim(), "", TextCompare: true) != 0) & (Operators.CompareString(tbIsolacao.Text.Trim(), "", TextCompare: true) != 0))
			{
				ref DeclaracoesFiacao.structureAplicacao[] iCgh8rDvCy = ref ICgh8rDvCy;
				iCgh8rDvCy = (DeclaracoesFiacao.structureAplicacao[])Utils.CopyArray(iCgh8rDvCy, new DeclaracoesFiacao.structureAplicacao[Information.UBound(ICgh8rDvCy) + 1 + 1]);
				t8uhQ9EtCj++;
				ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].Indice = t8uhQ9EtCj;
				ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].Nome = tbNome.Text.Trim();
				ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].Secao = tbSecao.Text.Trim();
				ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].Cor = tbCor.Text.Trim();
				ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].TipoCabo = tbTipoCabo.Text.Trim();
				ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].Isolacao = tbIsolacao.Text.Trim();
				DicionarioAplicacao.GravaDicionarioAplicacoes(ICgh8rDvCy);
				formataDGAplicacao();
				carregaDGAplicacao();
				dgAplicacao.Rows[dgAplicacao.Rows.Count - 1].Selected = true;
				HoMJupTZJ5();
				clsConexao clsConexao2 = new clsConexao();
				clsConexao2.buscaAplicacoesUsadas(ref XsohNgQqGY, ref lO9hFtr2V7);
				rRxJEN2Ofr();
			}
		}
	}

	private void VL4JlaU1oW(object P_0, EventArgs P_1)
	{
		if (dgAplicacao.SelectedRows.Count == 1)
		{
			tbIndex.Text = dgAplicacao.SelectedRows[0].Cells[0].Value.ToString();
			tbNome.Text = dgAplicacao.SelectedRows[0].Cells[1].Value.ToString();
			tbSecao.Text = dgAplicacao.SelectedRows[0].Cells[2].Value.ToString();
			tbCor.Text = dgAplicacao.SelectedRows[0].Cells[3].Value.ToString();
			tbTipoCabo.Text = dgAplicacao.SelectedRows[0].Cells[4].Value.ToString();
			tbIsolacao.Text = dgAplicacao.SelectedRows[0].Cells[5].Value.ToString();
		}
	}

	private void rlVJ5f71gi(object P_0, EventArgs P_1)
	{
		if (dgAplicacao.SelectedRows.Count == 1)
		{
			MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1826]), MsgBoxStyle.YesNo, "Elétron");
			if (msgBoxResult == MsgBoxResult.Yes)
			{
				dgAplicacao.SelectedRows[0].Cells[0].Value = tbIndex.Text;
				dgAplicacao.SelectedRows[0].Cells[1].Value = tbNome.Text.Trim();
				dgAplicacao.SelectedRows[0].Cells[2].Value = tbSecao.Text.Trim();
				dgAplicacao.SelectedRows[0].Cells[3].Value = tbCor.Text.Trim();
				dgAplicacao.SelectedRows[0].Cells[4].Value = tbTipoCabo.Text.Trim();
				dgAplicacao.SelectedRows[0].Cells[5].Value = tbIsolacao.Text.Trim();
				int indiceApl = Conversions.ToInteger(dgAplicacao.SelectedRows[0].Cells[0].Value);
				carregaMatrizViaDG();
				DicionarioAplicacao.GravaDicionarioAplicacoes(ICgh8rDvCy);
				clsConexao clsConexao2 = new clsConexao();
				clsConexao2.atualizaSecaoCor(indiceApl, tbSecao.Text.Trim(), tbCor.Text.Trim());
				HoMJupTZJ5();
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			}
		}
	}

	private void efNJ0bbnT2(object P_0, EventArgs P_1)
	{
		if (dgAplicacao.SelectedRows.Count != 1)
		{
			return;
		}
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1825]), MsgBoxStyle.YesNo, "Elétron");
		if (msgBoxResult == MsgBoxResult.Yes)
		{
			int indiceApl = Conversions.ToInteger(dgAplicacao.SelectedRows[0].Cells[0].Value);
			dgAplicacao.Rows.Remove(dgAplicacao.SelectedRows[0]);
			carregaMatrizViaDG();
			DicionarioAplicacao.GravaDicionarioAplicacoes(ICgh8rDvCy);
			clsConexao clsConexao2 = new clsConexao();
			clsConexao2.removeAplicacao(indiceApl);
			HoMJupTZJ5();
			if (dgAplicacao.Rows.Count > 0)
			{
				dgAplicacao.Rows[0].Selected = true;
				dgAplicacao.FirstDisplayedScrollingRowIndex = 0;
			}
			t8uhQ9EtCj = ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].Indice;
		}
	}

	private void PCXJRuWq7Z(object P_0, EventArgs P_1)
	{
		if (dgAplicacao.SelectedRows.Count == 1)
		{
			int aplicacao = Conversions.ToInteger(dgAplicacao.SelectedRows[0].Cells[0].Value);
			string secaoA = dgAplicacao.SelectedRows[0].Cells[2].Value.ToString();
			string corA = dgAplicacao.SelectedRows[0].Cells[3].Value.ToString();
			clsConexao clsConexao2 = new clsConexao();
			clsConexao2.editarSecaoCor(4, aplicacao, secaoA, corA);
			clsConexao clsConexao3 = new clsConexao();
			clsConexao3.buscaAplicacoesUsadas(ref XsohNgQqGY, ref lO9hFtr2V7);
			rRxJEN2Ofr();
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		}
	}

	private void vJDJmAnXj6(object P_0, EventArgs P_1)
	{
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1852]), MsgBoxStyle.YesNo);
		if (msgBoxResult == MsgBoxResult.No)
		{
			return;
		}
		List<string> list = new List<string>();
		checked
		{
			int num = dgPag.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgPag.Rows[i].Selected)
				{
					list.Add(Conversions.ToString(dgPag.Rows[i].Cells[0].Value));
				}
			}
			int aplicacao = Conversions.ToInteger(dgAplicacao.SelectedRows[0].Cells[0].Value);
			string secaoA = dgAplicacao.SelectedRows[0].Cells[2].Value.ToString();
			string corA = dgAplicacao.SelectedRows[0].Cells[3].Value.ToString();
			clsConexao clsConexao2 = new clsConexao();
			clsConexao2.editarSecaoCorPaginas(4, list, aplicacao, secaoA, corA);
			clsConexao clsConexao3 = new clsConexao();
			clsConexao3.buscaAplicacoesUsadas(ref XsohNgQqGY, ref lO9hFtr2V7);
			rRxJEN2Ofr();
		}
	}

	private void VWvJXgvLfu(object P_0, EventArgs P_1)
	{
		if (dgAplicacao.SelectedRows.Count == 1)
		{
			MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1836]), MsgBoxStyle.YesNo, "Elétron");
			if (msgBoxResult == MsgBoxResult.Yes)
			{
				int indiceApl = Conversions.ToInteger(dgAplicacao.SelectedRows[0].Cells[0].Value);
				clsConexao clsConexao2 = new clsConexao();
				clsConexao2.removeAplicacao(indiceApl);
				clsConexao clsConexao3 = new clsConexao();
				clsConexao3.buscaAplicacoesUsadas(ref XsohNgQqGY, ref lO9hFtr2V7);
				rRxJEN2Ofr();
			}
		}
	}

	private void NeJJU9wFQZ(object P_0, EventArgs P_1)
	{
		if (dgAplicacao.SelectedRows.Count == 1)
		{
			int indiceApl = Conversions.ToInteger(dgAplicacao.SelectedRows[0].Cells[0].Value);
			clsConexao clsConexao2 = new clsConexao();
			clsConexao2.ativaAplicacao(indiceApl, ref l6OhKsj3cs, nKIhc4MfeT);
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		}
	}

	private void W9FJyAMGZi(object P_0, CancelEventArgs P_1)
	{
		JhTJA98YGy();
	}

	private void wppJgBohZI(object P_0, EventArgs P_1)
	{
		JhTJA98YGy();
	}

	private void JhTJA98YGy()
	{
		if (l6OhKsj3cs.Count > 0)
		{
			clsConexao clsConexao2 = new clsConexao();
			clsConexao2.desativaAplicacao(ref l6OhKsj3cs);
			l6OhKsj3cs = new Dictionary<string, int>();
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		}
	}

	private void df9Jso1mGH(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = jLchP5nuvi.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			nKIhc4MfeT = jLchP5nuvi.Color.ColorIndex;
			btCorApl.BackColor = jLchP5nuvi.Color.ColorValue;
		}
	}

	private void NdoJBXfnaY(object P_0, EventArgs P_1)
	{
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1827]), MsgBoxStyle.YesNo, "Elétron");
		checked
		{
			if (msgBoxResult == MsgBoxResult.Yes)
			{
				int num = 0;
				do
				{
					ref DeclaracoesFiacao.structureAplicacao[] iCgh8rDvCy = ref ICgh8rDvCy;
					iCgh8rDvCy = (DeclaracoesFiacao.structureAplicacao[])Utils.CopyArray(iCgh8rDvCy, new DeclaracoesFiacao.structureAplicacao[Information.UBound(ICgh8rDvCy) + 1 + 1]);
					t8uhQ9EtCj++;
					ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].Indice = t8uhQ9EtCj;
					ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].Nome = NoyheZueGQ[num].Nome;
					ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].Secao = NoyheZueGQ[num].Secao;
					ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].Cor = NoyheZueGQ[num].Cor;
					ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].TipoCabo = NoyheZueGQ[num].TipoCabo;
					ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].Isolacao = NoyheZueGQ[num].Isolacao;
					num++;
				}
				while (num <= 14);
				DicionarioAplicacao.GravaDicionarioAplicacoes(ICgh8rDvCy);
				formataDGAplicacao();
				carregaDGAplicacao();
				dgAplicacao.Rows[dgAplicacao.Rows.Count - 1].Selected = true;
				HoMJupTZJ5();
				clsConexao clsConexao2 = new clsConexao();
				clsConexao2.buscaAplicacoesUsadas(ref XsohNgQqGY, ref lO9hFtr2V7);
				rRxJEN2Ofr();
			}
		}
	}

	private void CXKJVLR5OM()
	{
		NoyheZueGQ[0].Nome = "CIRCUITO DE TENSÃO A";
		NoyheZueGQ[0].Secao = "1,5";
		NoyheZueGQ[0].Cor = "VM";
		NoyheZueGQ[0].TipoCabo = "PVC FLEXÍVEL";
		NoyheZueGQ[0].Isolacao = "750V 70°";
		NoyheZueGQ[1].Nome = "CIRCUITO DE TENSÃO B";
		NoyheZueGQ[1].Secao = "1,5";
		NoyheZueGQ[1].Cor = "AZ";
		NoyheZueGQ[1].TipoCabo = "PVC FLEXÍVEL";
		NoyheZueGQ[1].Isolacao = "750V 70°";
		NoyheZueGQ[2].Nome = "CIRCUITO DE TENSÃO C";
		NoyheZueGQ[2].Secao = "1,5";
		NoyheZueGQ[2].Cor = "BR";
		NoyheZueGQ[2].TipoCabo = "PVC FLEXÍVEL";
		NoyheZueGQ[2].Isolacao = "750V 70°";
		NoyheZueGQ[3].Nome = "CIRCUITO DE TENSÃO N";
		NoyheZueGQ[3].Secao = "1,5";
		NoyheZueGQ[3].Cor = "PT";
		NoyheZueGQ[3].TipoCabo = "PVC FLEXÍVEL";
		NoyheZueGQ[3].Isolacao = "750V 70°";
		NoyheZueGQ[4].Nome = "CIRCUITO DE CORRENTE A";
		NoyheZueGQ[4].Secao = "2,5";
		NoyheZueGQ[4].Cor = "VM";
		NoyheZueGQ[4].TipoCabo = "PVC FLEXÍVEL";
		NoyheZueGQ[4].Isolacao = "750V 70°";
		NoyheZueGQ[5].Nome = "CIRCUITO DE CORRENTE B";
		NoyheZueGQ[5].Secao = "2,5";
		NoyheZueGQ[5].Cor = "AZ";
		NoyheZueGQ[5].TipoCabo = "PVC FLEXÍVEL";
		NoyheZueGQ[5].Isolacao = "750V 70°";
		NoyheZueGQ[6].Nome = "CIRCUITO DE CORRENTE C";
		NoyheZueGQ[6].Secao = "2,5";
		NoyheZueGQ[6].Cor = "BR";
		NoyheZueGQ[6].TipoCabo = "PVC FLEXÍVEL";
		NoyheZueGQ[6].Isolacao = "750V 70°";
		NoyheZueGQ[7].Nome = "CIRCUITO DE CORRENTE N";
		NoyheZueGQ[7].Secao = "2,5";
		NoyheZueGQ[7].Cor = "PT";
		NoyheZueGQ[7].TipoCabo = "PVC FLEXÍVEL";
		NoyheZueGQ[7].Isolacao = "750V 70°";
		NoyheZueGQ[8].Nome = "CIRCUITO DE ALIM. 125VCC(+)";
		NoyheZueGQ[8].Secao = "2,5";
		NoyheZueGQ[8].Cor = "CZ";
		NoyheZueGQ[8].TipoCabo = "PVC FLEXÍVEL";
		NoyheZueGQ[8].Isolacao = "750V 70°";
		NoyheZueGQ[9].Nome = "CIRCUITO DE ALIM. 125VCC(-)";
		NoyheZueGQ[9].Secao = "2,5";
		NoyheZueGQ[9].Cor = "CZ";
		NoyheZueGQ[9].TipoCabo = "PVC FLEXÍVEL";
		NoyheZueGQ[9].Isolacao = "750V 70°";
		NoyheZueGQ[10].Nome = "CIRCUITO DE ALIM. VCA(F)";
		NoyheZueGQ[10].Secao = "2,5";
		NoyheZueGQ[10].Cor = "CZ";
		NoyheZueGQ[10].TipoCabo = "PVC FLEXÍVEL";
		NoyheZueGQ[10].Isolacao = "750V 70°";
		NoyheZueGQ[11].Nome = "CIRCUITO DE ALIM. VCA(F-N)";
		NoyheZueGQ[11].Secao = "2,5";
		NoyheZueGQ[11].Cor = "CZ";
		NoyheZueGQ[11].TipoCabo = "PVC FLEXÍVEL";
		NoyheZueGQ[11].Isolacao = "750V 70°";
		NoyheZueGQ[12].Nome = "CIRCUITO DE CONTROLE";
		NoyheZueGQ[12].Secao = "1,5";
		NoyheZueGQ[12].Cor = "CZ";
		NoyheZueGQ[12].TipoCabo = "PVC FLEXÍVEL";
		NoyheZueGQ[12].Isolacao = "750V 70°";
		NoyheZueGQ[13].Nome = "CIRCUITO DE DISPARO";
		NoyheZueGQ[13].Secao = "2,5";
		NoyheZueGQ[13].Cor = "CZ";
		NoyheZueGQ[13].TipoCabo = "PVC FLEXÍVEL";
		NoyheZueGQ[13].Isolacao = "750V 70°";
		NoyheZueGQ[14].Nome = "ATERRAMENTO";
		NoyheZueGQ[14].Secao = "2,5";
		NoyheZueGQ[14].Cor = "VD/AM";
		NoyheZueGQ[14].TipoCabo = "PVC FLEXÍVEL";
		NoyheZueGQ[14].Isolacao = "750V 70°";
	}

	public void carregaDGAplicacao()
	{
		try
		{
			int num = Information.UBound(ICgh8rDvCy);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				dgAplicacao.Rows.Add(ICgh8rDvCy[i].Indice, ICgh8rDvCy[i].Nome, ICgh8rDvCy[i].Secao, ICgh8rDvCy[i].Cor, ICgh8rDvCy[i].TipoCabo, ICgh8rDvCy[i].Isolacao);
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

	public void carregaMatrizViaDG()
	{
		ICgh8rDvCy = new DeclaracoesFiacao.structureAplicacao[1];
		checked
		{
			int num = dgAplicacao.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				ref DeclaracoesFiacao.structureAplicacao[] iCgh8rDvCy = ref ICgh8rDvCy;
				iCgh8rDvCy = (DeclaracoesFiacao.structureAplicacao[])Utils.CopyArray(iCgh8rDvCy, new DeclaracoesFiacao.structureAplicacao[Information.UBound(ICgh8rDvCy) + 1 + 1]);
				ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].Indice = Conversions.ToInteger(dgAplicacao.Rows[i].Cells[0].Value);
				ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].Nome = dgAplicacao.Rows[i].Cells[1].Value.ToString();
				ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].Secao = dgAplicacao.Rows[i].Cells[2].Value.ToString();
				ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].Cor = dgAplicacao.Rows[i].Cells[3].Value.ToString();
				ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].TipoCabo = dgAplicacao.Rows[i].Cells[4].Value.ToString();
				ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].Isolacao = dgAplicacao.Rows[i].Cells[5].Value.ToString();
			}
		}
	}

	public void formataDGAplicacao()
	{
		checked
		{
			try
			{
				dgAplicacao.Rows.Clear();
				dgAplicacao.Columns.Clear();
				dgAplicacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1817]));
				dgAplicacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1818]));
				dgAplicacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1819]));
				dgAplicacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1820]));
				dgAplicacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1821]));
				dgAplicacao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1822]));
				float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgAplicacao)) ? ((float)(dgAplicacao.Width - 5)) : ((float)(dgAplicacao.Width - 22)));
				dgAplicacao.Columns[0].Width = (int)Math.Round(num * 1f / 10f);
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

	private void HoMJupTZJ5()
	{
		checked
		{
			if ((dgAplicacao.Columns.Count == 6) & (dgAplicacao.Rows.Count > 0))
			{
				float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgAplicacao)) ? ((float)(dgAplicacao.Width - 5)) : ((float)(dgAplicacao.Width - 22)));
				dgAplicacao.Columns[0].Width = (int)Math.Round(num * 1f / 10f);
				dgAplicacao.Columns[1].Width = (int)Math.Round((double)num * 3.5 / 10.0);
				dgAplicacao.Columns[2].Width = (int)Math.Round(num * 1f / 10f);
				dgAplicacao.Columns[3].Width = (int)Math.Round(num * 1f / 10f);
				dgAplicacao.Columns[4].Width = (int)Math.Round(num * 2f / 10f);
				dgAplicacao.Columns[5].Width = (int)Math.Round((double)num * 1.5 / 10.0);
				dgAplicacao.FirstDisplayedScrollingRowIndex = dgAplicacao.Rows.Count - 1;
			}
		}
	}

	private void rRxJEN2Ofr()
	{
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		dataGridViewCellStyle.BackColor = Color.LightCoral;
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		dataGridViewCellStyle2.BackColor = Color.LightGreen;
		checked
		{
			int num = dgAplicacao.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (!XsohNgQqGY.Contains(Conversions.ToInteger(dgAplicacao.Rows[i].Cells[0].Value)))
				{
					dgAplicacao.Rows[i].Cells[0].Style = dataGridViewCellStyle2;
				}
				else
				{
					dgAplicacao.Rows[i].Cells[0].Style = dataGridViewCellStyle;
				}
			}
			int num2 = dgPag.Rows.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				if (!lO9hFtr2V7.Contains(Conversions.ToString(dgPag.Rows[j].Cells[0].Value)))
				{
					dgPag.Rows[j].Cells[0].Style = dataGridViewCellStyle2;
				}
				else
				{
					dgPag.Rows[j].Cells[0].Style = dataGridViewCellStyle;
				}
			}
			dgPag.ClearSelection();
		}
	}

	private void vC0JZdG4f4(object P_0, EventArgs P_1)
	{
		ICgh8rDvCy = new DeclaracoesFiacao.structureAplicacao[1];
		uOCh3xrA3b = 0;
		checked
		{
			int num = dgAplicacao.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgAplicacao.Rows[i].Cells[0].Style.BackColor == Color.LightCoral && Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dgAplicacao.Rows[i].Cells[0].Value)))
				{
					gADh2Wt2uh.Add(Conversions.ToInteger(dgAplicacao.Rows[i].Cells[0].Value));
				}
				if (Operators.ConditionalCompareObjectLess(uOCh3xrA3b, dgAplicacao.Rows[i].Cells[0].Value, TextCompare: true))
				{
					uOCh3xrA3b = Conversions.ToInteger(dgAplicacao.Rows[i].Cells[0].Value);
				}
				ref DeclaracoesFiacao.structureAplicacao[] iCgh8rDvCy = ref ICgh8rDvCy;
				iCgh8rDvCy = (DeclaracoesFiacao.structureAplicacao[])Utils.CopyArray(iCgh8rDvCy, new DeclaracoesFiacao.structureAplicacao[Information.UBound(ICgh8rDvCy) + 1 + 1]);
				ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].Indice = Conversions.ToInteger(dgAplicacao.Rows[i].Cells[0].Value);
				ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].Nome = dgAplicacao.Rows[i].Cells[1].Value.ToString();
				ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].Secao = dgAplicacao.Rows[i].Cells[2].Value.ToString();
				ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].Cor = dgAplicacao.Rows[i].Cells[3].Value.ToString();
				ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].TipoCabo = dgAplicacao.Rows[i].Cells[4].Value.ToString();
				ICgh8rDvCy[Information.UBound(ICgh8rDvCy)].Isolacao = dgAplicacao.Rows[i].Cells[5].Value.ToString();
			}
			Relatorios_PotenciaisEXCELSiemens.ExportaAplicacaoEXCEL(ICgh8rDvCy);
		}
	}

	private void phyJiokJSf(object P_0, EventArgs P_1)
	{
		DeclaracoesFiacao.structureAplicacao[] mAplicacao = new DeclaracoesFiacao.structureAplicacao[1];
		if (!Relatorios_PotenciaisEXCELSiemens.ImportaAplicacaoEXCEL(ref mAplicacao))
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1228]), MsgBoxStyle.Information, "Eletron");
			return;
		}
		List<int> list = new List<int>();
		checked
		{
			foreach (int item in gADh2Wt2uh)
			{
				bool flag = false;
				int num = Information.UBound(mAplicacao);
				for (int i = 0; i <= num; i++)
				{
					if (item == mAplicacao[i].Indice)
					{
						flag = true;
						break;
					}
				}
				if (!flag && !list.Contains(item))
				{
					list.Add(item);
				}
			}
			DicionarioAplicacao.GravaDicionarioAplicacoes(mAplicacao);
			clsConexao clsConexao2 = new clsConexao();
			foreach (int item2 in list)
			{
				clsConexao2.removeAplicacao(item2);
			}
			t8uhQ9EtCj = DicionarioAplicacao.LeOsTiposDeAplicacoes(ref ICgh8rDvCy);
			formataDGAplicacao();
			carregaDGAplicacao();
			HoMJupTZJ5();
			clsConexao2.buscaAplicacoesUsadas(ref XsohNgQqGY, ref lO9hFtr2V7);
			rRxJEN2Ofr();
			int num2 = Information.UBound(ICgh8rDvCy);
			for (int j = 1; j <= num2; j++)
			{
				if (XsohNgQqGY.Contains(ICgh8rDvCy[j].Indice))
				{
					clsConexao2.atualizaSecaoCor(ICgh8rDvCy[j].Indice, ICgh8rDvCy[j].Secao, ICgh8rDvCy[j].Cor);
				}
			}
		}
	}

	private void GJrJS9MPTj()
	{
		try
		{
			dgPag.Columns[0].ReadOnly = false;
			dgPag.MultiSelect = true;
			int num = Information.UBound(DeclaracoesGeral.mPaginas, 2);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				dgPag.Rows.Add(DeclaracoesGeral.mPaginas[0, i]);
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

	private void R1KJ4uns5W()
	{
		dgPag.Rows.Clear();
		dgPag.Columns.Clear();
		dgPag.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1330]));
		checked
		{
			int num = dgPag.Columns.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				dgPag.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
			}
			float num2 = dgPag.Width - 20;
			dgPag.Columns[0].Width = (int)Math.Round(num2);
		}
	}

	private void uYUJC8Sm2c(object P_0, EventArgs P_1)
	{
		viSJY23RoD();
	}

	private void viSJY23RoD()
	{
		HoMJupTZJ5();
	}
}
