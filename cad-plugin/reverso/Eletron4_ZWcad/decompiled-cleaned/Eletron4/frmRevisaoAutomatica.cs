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
using VimZUaplUIPJH2tfOAZ9;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.Colors;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Runtime;
using ZwSoft.ZwCAD.Windows;
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmRevisaoAutomatica : Form
{
	private IContainer C7ZPYyWiAe;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip maMPrvS9fU;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbRev")]
	private TextBox WsdP9Svb9t;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbRevisao")]
	private Label lGSPzTWjnV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btInserirRevisao")]
	private Button G8bcWX6OPq;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ckEditaRevSimp")]
	private CheckBox zjZcp8tTIt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox CwLcTHaQFB;

	[AccessedThroughProperty("btInsereNuvem")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button zhQcJT8KO5;

	[AccessedThroughProperty("GroupBox3")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox R8wchINNIr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbRaio")]
	private Label gBmcoUZXbF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbRaio")]
	private TextBox bOfcGQcwd4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btAtribuiNuvem")]
	private Button VTRcH1jxBP;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox2")]
	private GroupBox edZcknGu2u;

	[CompilerGenerated]
	[AccessedThroughProperty("dgRevisoes")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView sKDcdwuBsv;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagarTodos")]
	[CompilerGenerated]
	private Button TTdcfXPnNM;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GBPaginas")]
	private GroupBox dvvcDF7KyY;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgPaginas")]
	private DataGridView V01cvGtv0Z;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTLiga")]
	private Button dI5c6vPwAX;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTDesliga")]
	private Button HiEctR3dtc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btEditaRevisao")]
	private Button WO4cjWsCNR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCorBloco")]
	private Button gtecLrA0pV;

	private ColorDialog wnUcww7sOg;

	private int yOicxfBmGb;

	private List<string> c3tcbin7qF;

	internal virtual TextBox tbRev
	{
		[CompilerGenerated]
		get
		{
			return WsdP9Svb9t;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = JVDPsEHj8Z;
			KeyEventHandler value3 = eHTPBVeebj;
			TextBox textBox = WsdP9Svb9t;
			if (textBox != null)
			{
				textBox.TextChanged -= value2;
				textBox.KeyUp -= value3;
			}
			WsdP9Svb9t = value;
			textBox = WsdP9Svb9t;
			if (textBox != null)
			{
				textBox.TextChanged += value2;
				textBox.KeyUp += value3;
			}
		}
	}

	internal virtual Label lbRevisao
	{
		[CompilerGenerated]
		get
		{
			return lGSPzTWjnV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			lGSPzTWjnV = value;
		}
	}

	internal virtual Button btInserirRevisao
	{
		[CompilerGenerated]
		get
		{
			return G8bcWX6OPq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = aGBPnaKi6j;
			Button button = G8bcWX6OPq;
			if (button != null)
			{
				button.Click -= value2;
			}
			G8bcWX6OPq = value;
			button = G8bcWX6OPq;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox ckEditaRevSimp
	{
		[CompilerGenerated]
		get
		{
			return zjZcp8tTIt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zjZcp8tTIt = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return CwLcTHaQFB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CwLcTHaQFB = value;
		}
	}

	internal virtual Button btInsereNuvem
	{
		[CompilerGenerated]
		get
		{
			return zhQcJT8KO5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IklP0oKSbt;
			Button button = zhQcJT8KO5;
			if (button != null)
			{
				button.Click -= value2;
			}
			zhQcJT8KO5 = value;
			button = zhQcJT8KO5;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox3
	{
		[CompilerGenerated]
		get
		{
			return R8wchINNIr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			R8wchINNIr = value;
		}
	}

	internal virtual Label lbRaio
	{
		[CompilerGenerated]
		get
		{
			return gBmcoUZXbF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			gBmcoUZXbF = value;
		}
	}

	internal virtual TextBox tbRaio
	{
		[CompilerGenerated]
		get
		{
			return bOfcGQcwd4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = xwWPmoGYwE;
			TextBox textBox = bOfcGQcwd4;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			bOfcGQcwd4 = value;
			textBox = bOfcGQcwd4;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual Button btAtribuiNuvem
	{
		[CompilerGenerated]
		get
		{
			return VTRcH1jxBP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LHMPRmGxwk;
			Button button = VTRcH1jxBP;
			if (button != null)
			{
				button.Click -= value2;
			}
			VTRcH1jxBP = value;
			button = VTRcH1jxBP;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return edZcknGu2u;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			edZcknGu2u = value;
		}
	}

	internal virtual DataGridView dgRevisoes
	{
		[CompilerGenerated]
		get
		{
			return sKDcdwuBsv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = hQQPXY3Xoe;
			DataGridView dataGridView = sKDcdwuBsv;
			if (dataGridView != null)
			{
				dataGridView.MouseUp -= value2;
			}
			sKDcdwuBsv = value;
			dataGridView = sKDcdwuBsv;
			if (dataGridView != null)
			{
				dataGridView.MouseUp += value2;
			}
		}
	}

	internal virtual Button btApagarTodos
	{
		[CompilerGenerated]
		get
		{
			return TTdcfXPnNM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TqqP5iaAUR;
			Button button = TTdcfXPnNM;
			if (button != null)
			{
				button.Click -= value2;
			}
			TTdcfXPnNM = value;
			button = TTdcfXPnNM;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GBPaginas
	{
		[CompilerGenerated]
		get
		{
			return dvvcDF7KyY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = mqIPC7eISt;
			GroupBox groupBox = dvvcDF7KyY;
			if (groupBox != null)
			{
				groupBox.Enter -= value2;
			}
			dvvcDF7KyY = value;
			groupBox = dvvcDF7KyY;
			if (groupBox != null)
			{
				groupBox.Enter += value2;
			}
		}
	}

	internal virtual DataGridView dgPaginas
	{
		[CompilerGenerated]
		get
		{
			return V01cvGtv0Z;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = kBjPUyJBDx;
			MouseEventHandler value3 = YNgPy7yw8Y;
			DataGridView dataGridView = V01cvGtv0Z;
			if (dataGridView != null)
			{
				dataGridView.MouseClick -= value2;
				dataGridView.MouseUp -= value3;
			}
			V01cvGtv0Z = value;
			dataGridView = V01cvGtv0Z;
			if (dataGridView != null)
			{
				dataGridView.MouseClick += value2;
				dataGridView.MouseUp += value3;
			}
		}
	}

	internal virtual Button BTLiga
	{
		[CompilerGenerated]
		get
		{
			return dI5c6vPwAX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = eKAPg8vjQr;
			Button button = dI5c6vPwAX;
			if (button != null)
			{
				button.Click -= value2;
			}
			dI5c6vPwAX = value;
			button = dI5c6vPwAX;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTDesliga
	{
		[CompilerGenerated]
		get
		{
			return HiEctR3dtc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = YBOPA7ddmD;
			Button button = HiEctR3dtc;
			if (button != null)
			{
				button.Click -= value2;
			}
			HiEctR3dtc = value;
			button = HiEctR3dtc;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btEditaRevisao
	{
		[CompilerGenerated]
		get
		{
			return WO4cjWsCNR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UhjP1D7tDH;
			Button button = WO4cjWsCNR;
			if (button != null)
			{
				button.Click -= value2;
			}
			WO4cjWsCNR = value;
			button = WO4cjWsCNR;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btCorBloco
	{
		[CompilerGenerated]
		get
		{
			return gtecLrA0pV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CFKPVyXbsR;
			Button button = gtecLrA0pV;
			if (button != null)
			{
				button.Click -= value2;
			}
			gtecLrA0pV = value;
			button = gtecLrA0pV;
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
			if (disposing && C7ZPYyWiAe != null)
			{
				C7ZPYyWiAe.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void e28P32l4bg()
	{
		C7ZPYyWiAe = new Container();
		FDqpBiUmZij(new ToolTip(C7ZPYyWiAe));
		tbRev = new TextBox();
		lbRevisao = new Label();
		btInserirRevisao = new Button();
		ckEditaRevSimp = new CheckBox();
		GroupBox1 = new GroupBox();
		btCorBloco = new Button();
		btEditaRevisao = new Button();
		GroupBox3 = new GroupBox();
		btAtribuiNuvem = new Button();
		lbRaio = new Label();
		tbRaio = new TextBox();
		btInsereNuvem = new Button();
		GroupBox2 = new GroupBox();
		BTLiga = new Button();
		BTDesliga = new Button();
		dgRevisoes = new DataGridView();
		btApagarTodos = new Button();
		GBPaginas = new GroupBox();
		dgPaginas = new DataGridView();
		GroupBox1.SuspendLayout();
		GroupBox3.SuspendLayout();
		GroupBox2.SuspendLayout();
		((ISupportInitialize)dgRevisoes).BeginInit();
		GBPaginas.SuspendLayout();
		((ISupportInitialize)dgPaginas).BeginInit();
		SuspendLayout();
		tbRev.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbRev.Location = new Point(12, 32);
		tbRev.Name = "tbRev";
		tbRev.Size = new Size(58, 20);
		tbRev.TabIndex = 41;
		tbRev.TextAlign = HorizontalAlignment.Center;
		lbRevisao.Location = new Point(5, 7);
		lbRevisao.Name = "lbRevisao";
		lbRevisao.Size = new Size(65, 19);
		lbRevisao.TabIndex = 42;
		lbRevisao.Text = "lbRevisao";
		lbRevisao.TextAlign = ContentAlignment.MiddleLeft;
		btInserirRevisao.FlatStyle = FlatStyle.Flat;
		btInserirRevisao.ForeColor = SystemColors.Control;
		btInserirRevisao.Image = Resources.Triangulo_32;
		btInserirRevisao.Location = new Point(150, 21);
		btInserirRevisao.Name = "btInserirRevisao";
		btInserirRevisao.Size = new Size(40, 40);
		btInserirRevisao.TabIndex = 44;
		btInserirRevisao.UseVisualStyleBackColor = true;
		ckEditaRevSimp.AutoSize = true;
		ckEditaRevSimp.Location = new Point(6, 169);
		ckEditaRevSimp.Name = "ckEditaRevSimp";
		ckEditaRevSimp.Size = new Size(129, 17);
		ckEditaRevSimp.TabIndex = 169;
		ckEditaRevSimp.Text = "ckPreencher Revisão";
		ckEditaRevSimp.UseVisualStyleBackColor = true;
		GroupBox1.Controls.Add(btCorBloco);
		GroupBox1.Controls.Add(btEditaRevisao);
		GroupBox1.Controls.Add(tbRev);
		GroupBox1.Controls.Add(lbRevisao);
		GroupBox1.Controls.Add(btInserirRevisao);
		GroupBox1.Location = new Point(6, 7);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(200, 70);
		GroupBox1.TabIndex = 170;
		GroupBox1.TabStop = false;
		btCorBloco.BackColor = SystemColors.ActiveCaption;
		btCorBloco.Location = new Point(76, 29);
		btCorBloco.Name = "btCorBloco";
		btCorBloco.Size = new Size(26, 25);
		btCorBloco.TabIndex = 175;
		btCorBloco.UseVisualStyleBackColor = false;
		btEditaRevisao.FlatStyle = FlatStyle.Flat;
		btEditaRevisao.ForeColor = SystemColors.Control;
		btEditaRevisao.Image = Resources.Editar;
		btEditaRevisao.Location = new Point(104, 21);
		btEditaRevisao.Name = "btEditaRevisao";
		btEditaRevisao.Size = new Size(40, 40);
		btEditaRevisao.TabIndex = 45;
		btEditaRevisao.UseVisualStyleBackColor = true;
		GroupBox3.Controls.Add(btAtribuiNuvem);
		GroupBox3.Controls.Add(lbRaio);
		GroupBox3.Controls.Add(tbRaio);
		GroupBox3.Controls.Add(btInsereNuvem);
		GroupBox3.Location = new Point(6, 83);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(200, 70);
		GroupBox3.TabIndex = 174;
		GroupBox3.TabStop = false;
		btAtribuiNuvem.FlatStyle = FlatStyle.Flat;
		btAtribuiNuvem.ForeColor = SystemColors.Control;
		btAtribuiNuvem.Image = Resources.CloudSet_32;
		btAtribuiNuvem.Location = new Point(150, 15);
		btAtribuiNuvem.Name = "btAtribuiNuvem";
		btAtribuiNuvem.Size = new Size(40, 40);
		btAtribuiNuvem.TabIndex = 176;
		btAtribuiNuvem.UseVisualStyleBackColor = true;
		lbRaio.Location = new Point(5, 7);
		lbRaio.Name = "lbRaio";
		lbRaio.Size = new Size(40, 19);
		lbRaio.TabIndex = 175;
		lbRaio.Text = "Raio";
		lbRaio.TextAlign = ContentAlignment.MiddleLeft;
		tbRaio.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbRaio.Location = new Point(8, 29);
		tbRaio.Name = "tbRaio";
		tbRaio.Size = new Size(90, 20);
		tbRaio.TabIndex = 172;
		tbRaio.TextAlign = HorizontalAlignment.Center;
		btInsereNuvem.FlatStyle = FlatStyle.Flat;
		btInsereNuvem.ForeColor = SystemColors.Control;
		btInsereNuvem.Image = Resources.Cloud_32;
		btInsereNuvem.Location = new Point(104, 15);
		btInsereNuvem.Name = "btInsereNuvem";
		btInsereNuvem.Size = new Size(40, 40);
		btInsereNuvem.TabIndex = 170;
		btInsereNuvem.UseVisualStyleBackColor = true;
		GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox2.Controls.Add(BTLiga);
		GroupBox2.Controls.Add(BTDesliga);
		GroupBox2.Controls.Add(dgRevisoes);
		GroupBox2.Controls.Add(btApagarTodos);
		GroupBox2.Location = new Point(210, 7);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(153, 188);
		GroupBox2.TabIndex = 172;
		GroupBox2.TabStop = false;
		BTLiga.Anchor = AnchorStyles.Right;
		BTLiga.FlatStyle = FlatStyle.Flat;
		BTLiga.ForeColor = SystemColors.Control;
		BTLiga.Image = Resources.Liga_32;
		BTLiga.Location = new Point(116, 36);
		BTLiga.Name = "BTLiga";
		BTLiga.Size = new Size(30, 40);
		BTLiga.TabIndex = 47;
		BTLiga.UseVisualStyleBackColor = true;
		BTDesliga.Anchor = AnchorStyles.Right;
		BTDesliga.FlatStyle = FlatStyle.Flat;
		BTDesliga.ForeColor = SystemColors.Control;
		BTDesliga.Image = Resources.Desliga_32;
		BTDesliga.Location = new Point(116, 76);
		BTDesliga.Name = "BTDesliga";
		BTDesliga.Size = new Size(30, 40);
		BTDesliga.TabIndex = 46;
		BTDesliga.UseVisualStyleBackColor = true;
		dgRevisoes.AllowUserToAddRows = false;
		dgRevisoes.AllowUserToDeleteRows = false;
		dgRevisoes.AllowUserToOrderColumns = true;
		dgRevisoes.AllowUserToResizeRows = false;
		dgRevisoes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgRevisoes.BackgroundColor = SystemColors.ButtonHighlight;
		dgRevisoes.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgRevisoes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgRevisoes.Location = new Point(6, 13);
		dgRevisoes.MultiSelect = false;
		dgRevisoes.Name = "dgRevisoes";
		dgRevisoes.ReadOnly = true;
		dgRevisoes.RowHeadersVisible = false;
		dgRevisoes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRevisoes.Size = new Size(102, 167);
		dgRevisoes.TabIndex = 45;
		btApagarTodos.Anchor = AnchorStyles.Right;
		btApagarTodos.FlatStyle = FlatStyle.Flat;
		btApagarTodos.ForeColor = SystemColors.Control;
		btApagarTodos.Image = Resources.Delete_32;
		btApagarTodos.Location = new Point(109, 120);
		btApagarTodos.Name = "btApagarTodos";
		btApagarTodos.Size = new Size(40, 40);
		btApagarTodos.TabIndex = 15;
		btApagarTodos.UseVisualStyleBackColor = true;
		GBPaginas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GBPaginas.Controls.Add(dgPaginas);
		GBPaginas.Location = new Point(367, 7);
		GBPaginas.Name = "GBPaginas";
		GBPaginas.Size = new Size(113, 188);
		GBPaginas.TabIndex = 173;
		GBPaginas.TabStop = false;
		dgPaginas.AllowUserToAddRows = false;
		dgPaginas.AllowUserToDeleteRows = false;
		dgPaginas.AllowUserToOrderColumns = true;
		dgPaginas.AllowUserToResizeRows = false;
		dgPaginas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgPaginas.BackgroundColor = SystemColors.ButtonHighlight;
		dgPaginas.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgPaginas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPaginas.Location = new Point(2, 13);
		dgPaginas.Name = "dgPaginas";
		dgPaginas.ReadOnly = true;
		dgPaginas.RowHeadersVisible = false;
		dgPaginas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPaginas.Size = new Size(103, 169);
		dgPaginas.TabIndex = 45;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(484, 201);
		Controls.Add(GroupBox3);
		Controls.Add(GBPaginas);
		Controls.Add(GroupBox2);
		Controls.Add(GroupBox1);
		Controls.Add(ckEditaRevSimp);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		MaximumSize = new Size(500, 1200);
		MinimizeBox = false;
		MinimumSize = new Size(500, 240);
		Name = "frmRevisaoAutomatica";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Revisão Automática";
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox3.PerformLayout();
		GroupBox2.ResumeLayout(performLayout: false);
		((ISupportInitialize)dgRevisoes).EndInit();
		GBPaginas.ResumeLayout(performLayout: false);
		((ISupportInitialize)dgPaginas).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return maMPrvS9fU;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		maMPrvS9fU = WithEventsValue;
	}

	public frmRevisaoAutomatica()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected Obj, but got Unknown
		wnUcww7sOg = new ColorDialog();
		yOicxfBmGb = 1;
		c3tcbin7qF = new List<string>();
		try
		{
			if (!Geral.ExisteForm("frmRevisaoAutomatica"))
			{
				e28P32l4bg();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1583]);
				w8dpBZ0kvSD().SetToolTip(btInserirRevisao, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1584]));
				w8dpBZ0kvSD().SetToolTip(btApagarTodos, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1585]));
				lbRevisao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 62]);
				lbRaio.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1806]);
				ckEditaRevSimp.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 61]);
				tbRev.Text = "";
				w8dpBZ0kvSD().SetToolTip(btInsereNuvem, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1711]));
				w8dpBZ0kvSD().SetToolTip(btAtribuiNuvem, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1712]));
				fB0PuJnG1i();
				if (c3tcbin7qF.Count > 0)
				{
					tbRev.Text = c3tcbin7qF[0];
				}
				string left = Geral.CADVersion();
				if (Operators.CompareString(left, "?", TextCompare: true) != 0 && Operators.CompareString(left, "A_2010", TextCompare: true) != 0 && Operators.CompareString(left, "A_2011", TextCompare: true) != 0 && Operators.CompareString(left, "A_2012", TextCompare: true) != 0 && Operators.CompareString(left, "A_2013", TextCompare: true) != 0 && Operators.CompareString(left, "A_2014", TextCompare: true) != 0)
				{
					btInsereNuvem.Enabled = true;
				}
				else
				{
					btInsereNuvem.Enabled = false;
				}
				tbRaio.Text = "5";
				Application.ShowModelessDialog((Form)this);
				if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
				{
					Left = 0;
				}
				atualizaDG();
				GBPaginas.Visible = false;
				Size size = new Size(380, 210);
				Size = size;
				if (dgRevisoes.RowCount > 0)
				{
					tbRev.Text = Conversions.ToString(dgRevisoes.Rows[checked(dgRevisoes.RowCount - 1)].Cells[0].Value);
					XGQPS71hBf(tbRev.Text);
					N7QPEFE9t9(tbRev.Text, ref yOicxfBmGb);
				}
				AutoSize = true;
				BTLiga.Location = BTDesliga.Location;
				BTLiga.Visible = false;
				BTDesliga.Visible = true;
				btEditaRevisao.Enabled = false;
				AtivaLampadas(tbRev.Text);
				MostraCorDoBloco(yOicxfBmGb);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void aGBPnaKi6j(object P_0, EventArgs P_1)
	{
		if (Operators.CompareString(tbRev.Text.Trim(), "", TextCompare: true) != 0)
		{
			double dAltFonte = 1.4;
			BlocoRev blocoRev = new BlocoRev();
			blocoRev.CriarBlocoRev(tbRev.Text, yOicxfBmGb, dAltFonte);
			if (ckEditaRevSimp.Checked)
			{
				Pagina.AtualizaRevSimplificada(DeclaracoesGeral.ativo.Pagina, tbRev.Text);
			}
			FormataDG();
			fB0PuJnG1i();
			XGQPS71hBf(tbRev.Text);
			MostraCorDoBloco(yOicxfBmGb);
			AtivaLampadas(tbRev.Text);
			N7QPEFE9t9(tbRev.Text, ref yOicxfBmGb);
			if (btEditaRevisao.Enabled)
			{
				EditaRev();
			}
		}
	}

	public void MostraCorDoBloco(int iCorSel)
	{
		Color val = Color.FromColorIndex((ColorMethod)194, checked((short)iCorSel));
		btCorBloco.BackColor = val.ColorValue;
	}

	private void UhjP1D7tDH(object P_0, EventArgs P_1)
	{
		EditaRev();
	}

	public void EditaRev()
	{
		if (dgRevisoes.RowCount == 0)
		{
			return;
		}
		checked
		{
			if (dgRevisoes.SelectedRows.Count > 0)
			{
				if (ckEditaRevSimp.Checked)
				{
					AtualizaRevSimplificadaDasPáginas(Conversions.ToString(dgRevisoes.SelectedRows[0].Cells[0].Value), tbRev.Text);
				}
				EditaRevisoesAutomaticas(Conversions.ToString(dgRevisoes.SelectedRows[0].Cells[0].Value), tbRev.Text, ref yOicxfBmGb);
				fB0PuJnG1i();
				if (dgRevisoes.RowCount > 0)
				{
					int num = dgRevisoes.RowCount - 1;
					for (int i = num; i >= 0; i += -1)
					{
						if (Operators.ConditionalCompareObjectEqual(dgRevisoes.Rows[i].Cells[0].Value, tbRev.Text, TextCompare: true))
						{
							dgRevisoes.Rows[i].Selected = true;
							tbRev.Text = Conversions.ToString(dgRevisoes.Rows[i].Cells[0].Value);
							N7QPEFE9t9(tbRev.Text, ref yOicxfBmGb);
							break;
						}
					}
				}
			}
			btEditaRevisao.Enabled = false;
		}
	}

	public static void AtualizaRevSimplificadaDasPáginas(string sValorAntigo, string sValor)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
							try
							{
								DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
								try
								{
									if ((DisposableWrapper)(object)val6 != (DisposableWrapper)null)
									{
										DBText val7 = val6;
										int num = XDataGeral.LeXDataTitulo(ref val7);
										if (num == 8 && Operators.CompareString(val6.TextString.ToUpper(), sValorAntigo.ToUpper(), TextCompare: true) == 0)
										{
											((DBObject)val6).UpgradeOpen();
											val6.TextString = sValor;
										}
									}
								}
								finally
								{
									((IDisposable)val6)?.Dispose();
								}
							}
							finally
							{
								((IDisposable)val5)?.Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					val2.Abort();
					throw;
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)database)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void EditaRevisoesAutomaticas(string sRevSel, string sNovaRev, ref int iCorSel)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
						string rev = "";
						int iCor = 1;
						if (!XDataGeral.LeXDataRevisaoAutomatica(ref ent, ref rev, ref iCor) || Operators.CompareString(sRevSel.ToUpper(), rev.ToUpper(), TextCompare: true) != 0)
						{
							continue;
						}
						((DBObject)ent).UpgradeOpen();
						BlockReference val5 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
						if (val5 == null)
						{
							Polyline val6 = (Polyline)(object)((ent is Polyline) ? ent : null);
							if (val6 != null)
							{
								((DBObject)val6).UpgradeOpen();
								((Entity)val6).ColorIndex = iCorSel;
								XDataGeral.gravarXDataRevisaoAutomatica(ref ent, sNovaRev, iCorSel);
							}
						}
						else if (Operators.CompareString(val5.Name.ToUpper(), "REVISAO", TextCompare: true) != 0)
						{
							XDataGeral.gravarXDataRevisaoAutomatica(ref ent, sNovaRev, iCorSel);
							string sHandle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							AtualizaCorValorDaRevisao(ref sHandle, "REV", sNovaRev, iCorSel);
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				val2.Abort();
				throw;
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void AtualizaCorValorDaRevisao(ref string sHandle, string sAttributo, string sValor, int iCorSel)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected Obj, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Entity val4 = (Entity)Geral.HandleToObject(sHandle);
				if (val4 != null)
				{
					BlockReference val5 = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
					if (val5 != null)
					{
						new DBObjectCollection();
						DBObject val6 = val2.GetObject(val5.BlockTableRecord, (OpenMode)1);
						BlockTableRecord val7 = (BlockTableRecord)(object)((val6 is BlockTableRecord) ? val6 : null);
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val7.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val8 = (Entity)val2.GetObject(current, (OpenMode)1);
								try
								{
									Polyline val9 = (Polyline)(object)((val8 is Polyline) ? val8 : null);
									if (val9 == null)
									{
										DBText val10 = (DBText)(object)((val8 is DBText) ? val8 : null);
										if (!((DisposableWrapper)(object)val10 != (DisposableWrapper)null))
										{
											AttributeCollection attributeCollection = val5.AttributeCollection;
											foreach (object item in attributeCollection)
											{
												ObjectId val11 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
												AttributeReference val12 = (AttributeReference)val11.GetObject((OpenMode)1);
												if (Operators.CompareString(val12.Tag.ToUpper(), sAttributo.ToUpper(), TextCompare: true) == 0)
												{
													((DBObject)val12).UpgradeOpen();
													((DBText)val12).TextString = sValor;
													((Entity)val12).ColorIndex = iCorSel;
													((DBText)val12).AdjustAlignment(database);
													((Entity)val12).Draw();
												}
											}
										}
										else
										{
											((DBObject)val10).UpgradeOpen();
											val10.TextString = sValor;
											((Entity)val10).ColorIndex = iCorSel;
										}
									}
									else
									{
										((DBObject)val9).UpgradeOpen();
										((Entity)val9).ColorIndex = iCorSel;
									}
								}
								finally
								{
									((IDisposable)val8)?.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
					}
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private void WuRPl2YPUi(object P_0, DataGridViewCellMouseEventArgs P_1)
	{
		tbRev.Text = Conversions.ToString(dgRevisoes.SelectedRows[0].Cells[0].Value);
	}

	private void TqqP5iaAUR(object P_0, EventArgs P_1)
	{
		List<string> list = new List<string>();
		checked
		{
			int num = dgRevisoes.RowCount - 1;
			for (int i = num; i >= 0; i += -1)
			{
				if (dgRevisoes.Rows[i].Selected)
				{
					if (Operators.ConditionalCompareObjectEqual(tbRev.Text, dgRevisoes.Rows[i].Cells[0].Value, TextCompare: true))
					{
						tbRev.Text = "";
					}
					list.Add(Conversions.ToString(dgRevisoes.Rows[i].Cells[0].Value));
				}
			}
			apagaRevisoesAutomaticas(list);
			fB0PuJnG1i();
			atualizaDG();
			if (Operators.CompareString(tbRev.Text, "", TextCompare: true) == 0 && dgRevisoes.RowCount > 0)
			{
				tbRev.Text = Conversions.ToString(dgRevisoes.Rows[0].Cells[0].Value);
				dgRevisoes.Rows[0].Selected = true;
			}
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			N7QPEFE9t9(tbRev.Text, ref yOicxfBmGb);
		}
	}

	public void AtualizaRevisao()
	{
		fB0PuJnG1i();
		atualizaDG();
	}

	public static void apagaRevisoesAutomaticas(List<string> lApagara)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
						string rev = "";
						int iCor = 0;
						if (XDataGeral.LeXDataRevisaoAutomatica(ref ent, ref rev, ref iCor) && lApagara.Contains(rev))
						{
							((DBObject)ent).UpgradeOpen();
							((DBObject)ent).Erase();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				val2.Abort();
				throw;
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void LigaRevisoesAutomaticas(string sRevSel)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
						string rev = "";
						int iCor = 1;
						if (XDataGeral.LeXDataRevisaoAutomatica(ref ent, ref rev, ref iCor) && Operators.CompareString(sRevSel, rev, TextCompare: true) == 0)
						{
							((DBObject)ent).UpgradeOpen();
							ent.Visible = true;
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				val2.Abort();
				throw;
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private void IklP0oKSbt(object P_0, EventArgs P_1)
	{
		if (Operators.CompareString(tbRev.Text.Trim(), "", TextCompare: true) != 0)
		{
			bool flag = false;
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			clsCloud.add(tbRev.Text, ckEditaRevSimp.Checked, Conversions.ToDouble(tbRaio.Text), yOicxfBmGb);
			if (!c3tcbin7qF.Contains(tbRev.Text))
			{
				c3tcbin7qF.Add(tbRev.Text);
				flag = true;
			}
			fB0PuJnG1i();
			if (flag)
			{
				FormataDG();
				BIZP4ka05E(c3tcbin7qF);
				XGQPS71hBf(tbRev.Text);
			}
			N7QPEFE9t9(tbRev.Text, ref yOicxfBmGb);
			AtivaLampadas(tbRev.Text);
		}
	}

	private void LHMPRmGxwk(object P_0, EventArgs P_1)
	{
		if (Operators.CompareString(tbRev.Text.Trim(), "", TextCompare: true) == 0)
		{
			return;
		}
		bool flag = false;
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		if (clsCloud.SelecionaUmaCloud(tbRev.Text, ckEditaRevSimp.Checked, yOicxfBmGb))
		{
			if (!c3tcbin7qF.Contains(tbRev.Text))
			{
				c3tcbin7qF.Add(tbRev.Text);
				flag = true;
			}
			fB0PuJnG1i();
			if (flag)
			{
				FormataDG();
				BIZP4ka05E(c3tcbin7qF);
				XGQPS71hBf(tbRev.Text);
			}
			N7QPEFE9t9(tbRev.Text, ref yOicxfBmGb);
			AtivaLampadas(tbRev.Text);
		}
	}

	private void xwWPmoGYwE(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void hQQPXY3Xoe(object P_0, MouseEventArgs P_1)
	{
		tbRev.Text = Conversions.ToString(dgRevisoes.SelectedRows[0].Cells[0].Value);
		N7QPEFE9t9(tbRev.Text, ref yOicxfBmGb);
		AtivaLampadas(tbRev.Text);
		MostraCorDoBloco(yOicxfBmGb);
	}

	private void kBjPUyJBDx(object P_0, MouseEventArgs P_1)
	{
		mostraPagina();
	}

	private void YNgPy7yw8Y(object P_0, MouseEventArgs P_1)
	{
		mostraPagina();
	}

	public void mostraPagina()
	{
		if (dgPaginas.RowCount != 0 && dgPaginas.SelectedRows.Count > 0)
		{
			Pagina.AtivaPagina(Conversions.ToString(dgPaginas.SelectedRows[0].Cells[0].Value));
			uscPaginas uscPagina = DeclaracoesGeral._uscPagina;
			DataGridViewCell dataGridViewCell;
			string pag = Conversions.ToString((dataGridViewCell = dgPaginas.SelectedRows[0].Cells[0]).Value);
			uscPagina.ativaPaginaAtalho(ref pag);
			dataGridViewCell.Value = pag;
		}
	}

	private void eKAPg8vjQr(object P_0, EventArgs P_1)
	{
		checked
		{
			int num = dgRevisoes.RowCount - 1;
			for (int i = num; i >= 0; i += -1)
			{
				if (dgRevisoes.Rows[i].Selected)
				{
					LigaRevisoesAutomaticas(Conversions.ToString(dgRevisoes.Rows[i].Cells[0].Value));
					AtivaLampadas(Conversions.ToString(dgRevisoes.Rows[i].Cells[0].Value));
				}
			}
		}
	}

	private void YBOPA7ddmD(object P_0, EventArgs P_1)
	{
		checked
		{
			int num = dgRevisoes.RowCount - 1;
			for (int i = num; i >= 0; i += -1)
			{
				if (dgRevisoes.Rows[i].Selected)
				{
					DesligaRevisoesAutomaticas(Conversions.ToString(dgRevisoes.Rows[i].Cells[0].Value));
					AtivaLampadas(Conversions.ToString(dgRevisoes.Rows[i].Cells[0].Value));
				}
			}
		}
	}

	public static void DesligaRevisoesAutomaticas(string sRevSel)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
						string rev = "";
						int iCor = 1;
						if (XDataGeral.LeXDataRevisaoAutomatica(ref ent, ref rev, ref iCor) && Operators.CompareString(sRevSel, rev, TextCompare: true) == 0)
						{
							((DBObject)ent).UpgradeOpen();
							ent.Visible = false;
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				val2.Abort();
				throw;
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private void JVDPsEHj8Z(object P_0, EventArgs P_1)
	{
		btEditaRevisao.Enabled = false;
		checked
		{
			int num = dgRevisoes.RowCount - 1;
			for (int i = num; i >= 0; i += -1)
			{
				if (dgRevisoes.Rows[i].Selected && Operators.ConditionalCompareObjectNotEqual(tbRev.Text, dgRevisoes.Rows[i].Cells[0].Value, TextCompare: true))
				{
					btEditaRevisao.Enabled = true;
				}
			}
		}
	}

	private void eHTPBVeebj(object P_0, KeyEventArgs P_1)
	{
		btEditaRevisao.Enabled = false;
		yOicxfBmGb = wXNPZu5bZe(tbRev.Text);
		MostraCorDoBloco(yOicxfBmGb);
		btEditaRevisao.Enabled = true;
	}

	private void CFKPVyXbsR(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = wnUcww7sOg.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			yOicxfBmGb = wnUcww7sOg.Color.ColorIndex;
			btCorBloco.BackColor = wnUcww7sOg.Color.ColorValue;
			btEditaRevisao.Enabled = true;
		}
	}

	private void fB0PuJnG1i()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected Obj, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected Obj, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Obj, but got Unknown
		c3tcbin7qF.Clear();
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
			BlockTableRecordEnumerator enumerator = default;
			try
			{
				enumerator = val3.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					Entity ent = (Entity)val.GetObject(current, (OpenMode)0);
					string rev = "";
					if (XDataGeral.LeXDataRevisaoAutomatica(ref ent, ref rev, ref yOicxfBmGb) && !c3tcbin7qF.Contains(rev))
					{
						c3tcbin7qF.Add(rev);
					}
				}
			}
			finally
			{
				((IDisposable)enumerator)?.Dispose();
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
		FormataDG();
		BIZP4ka05E(c3tcbin7qF);
	}

	public void AtivaLampadas(string sRevSel)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
						string rev = "";
						if (XDataGeral.LeXDataRevisaoAutomatica(ref ent, ref rev, ref yOicxfBmGb) && Operators.CompareString(sRevSel, rev, TextCompare: true) == 0)
						{
							if (ent.Visible)
							{
								BTDesliga.Visible = true;
								BTLiga.Visible = false;
							}
							else
							{
								BTDesliga.Visible = false;
								BTLiga.Visible = true;
							}
							break;
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				val2.Abort();
				throw;
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private bool N7QPEFE9t9(string P_0, ref int P_1)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected Obj, but got Unknown
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected Obj, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected Obj, but got Unknown
		bool flag = false;
		List<string> list = new List<string>();
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
			BlockTableRecordEnumerator enumerator = default;
			try
			{
				enumerator = val3.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					Entity ent = (Entity)val.GetObject(current, (OpenMode)0);
					string rev = "";
					int iCor = 1;
					if (XDataGeral.LeXDataRevisaoAutomatica(ref ent, ref rev, ref iCor) && Operators.CompareString(P_0, rev, TextCompare: true) == 0)
					{
						P_1 = iCor;
						if (!list.Contains(ent.Layer))
						{
							list.Add(ent.Layer);
							flag = true;
						}
					}
				}
			}
			finally
			{
				((IDisposable)enumerator)?.Dispose();
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
		FormataDGPaginas();
		if (!flag)
		{
			GBPaginas.Visible = false;
			Size size = new Size(380, 210);
			Size = size;
		}
		else
		{
			Size size2 = new Size(500, 210);
			Size = size2;
			GBPaginas.Visible = true;
			WVdPip57sC(list);
		}
		return flag;
	}

	private int wXNPZu5bZe(string P_0)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected Obj, but got Unknown
		int result = 1;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
			BlockTableRecordEnumerator enumerator = default;
			try
			{
				enumerator = val3.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					Entity ent = (Entity)val.GetObject(current, (OpenMode)0);
					string rev = "";
					int iCor = 1;
					if (XDataGeral.LeXDataRevisaoAutomatica(ref ent, ref rev, ref iCor) && Operators.CompareString(P_0, rev, TextCompare: true) == 0)
					{
						result = iCor;
					}
				}
			}
			finally
			{
				((IDisposable)enumerator)?.Dispose();
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
		return result;
	}

	public void FormataDGPaginas()
	{
		try
		{
			dgPaginas.Rows.Clear();
			dgPaginas.Columns.Clear();
			dgPaginas.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 8]));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void WVdPip57sC(List<string> P_0)
	{
		try
		{
			P_0.Sort();
			foreach (string item in P_0)
			{
				dgPaginas.Rows.Add(item);
			}
			atualizaDGPaginas();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
			ProjectData.ClearProjectError();
		}
	}

	public void atualizaDGPaginas()
	{
		checked
		{
			if (dgPaginas.Columns.Count > 0)
			{
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgPaginas)) ? ((double)(dgPaginas.Width - 4)) : ((double)(dgPaginas.Width - 21)));
				dgPaginas.Columns[0].Width = (int)Math.Round(a);
			}
		}
	}

	private void XGQPS71hBf(string P_0)
	{
		checked
		{
			int num = dgRevisoes.RowCount - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					dgRevisoes.Rows[num2].Selected = false;
					if (Operators.ConditionalCompareObjectEqual(dgRevisoes.Rows[num2].Cells[0].Value, P_0, TextCompare: true))
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			dgRevisoes.Rows[num2].Selected = true;
			dgRevisoes.FirstDisplayedScrollingRowIndex = num2;
		}
	}

	public void FormataDG()
	{
		try
		{
			dgRevisoes.Rows.Clear();
			dgRevisoes.Columns.Clear();
			dgRevisoes.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 62]));
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void BIZP4ka05E(List<string> P_0)
	{
		try
		{
			P_0.Sort();
			foreach (string item in P_0)
			{
				dgRevisoes.Rows.Add(item);
			}
			atualizaDG();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
			ProjectData.ClearProjectError();
		}
	}

	public void atualizaDG()
	{
		checked
		{
			if (dgRevisoes.Columns.Count > 0)
			{
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgRevisoes)) ? ((double)(dgRevisoes.Width - 4)) : ((double)(dgRevisoes.Width - 21)));
				dgRevisoes.Columns[0].Width = (int)Math.Round(a);
			}
		}
	}

	private void mqIPC7eISt(object P_0, EventArgs P_1)
	{
	}
}
