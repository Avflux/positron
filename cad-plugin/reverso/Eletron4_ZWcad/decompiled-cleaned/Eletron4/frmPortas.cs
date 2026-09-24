using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using YhamV21aratNE3b4GFK;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.Geometry;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmPortas : Form
{
	private IContainer nm6pt5jURT6;

	[AccessedThroughProperty("ckPrimeiro")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox aDOpt0BNWlM;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("LBFiltro")]
	private Label mmRptR2hvef;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBPesquisa")]
	private TextBox dqRptm9XXMg;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBDistancia")]
	[CompilerGenerated]
	private Label iiCptXVgmt0;

	[AccessedThroughProperty("LbQuantidade")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label OFDptUwx0tF;

	[AccessedThroughProperty("tbDx")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox fp8ptyD0nIk;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBInserir")]
	[CompilerGenerated]
	private TextBox cgJptgUt3mo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CKAlternativo")]
	private CheckBox QHIptAOES2P;

	[CompilerGenerated]
	[AccessedThroughProperty("CKNomeVisivel")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox oIpptssKG6C;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgBlocos")]
	private DataGridView z5mptBhabWr;

	[CompilerGenerated]
	[AccessedThroughProperty("btSeleciona")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button bjuptVRW5Xy;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgMascaras")]
	[CompilerGenerated]
	private DataGridView z46ptu9yBjT;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btInserir")]
	private Button tKMptEhWbaW;

	[CompilerGenerated]
	[AccessedThroughProperty("iDWG")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PictureBox UNiptZ9d7Go;

	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolTip PDLptiMvj6I;

	[AccessedThroughProperty("GroupBox1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox howptSyGb8C;

	[AccessedThroughProperty("LBFiltroBlocos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label xnApt4jMZ1W;

	[AccessedThroughProperty("TBPesquisaBlocos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox nWVptCCxusq;

	[CompilerGenerated]
	[AccessedThroughProperty("Label2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label hsVptYGqmMH;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label H8FptrJUhh4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDy")]
	private TextBox YEcpt9ClBhC;

	private Declaracoes2.MMascara[] iVaptzBAbpH;

	private object[,] dYgpjWhBvvA;

	private double jBGpjphsW8H;

	private string S1qpjTDsslH;

	private string uebpjJyDZWP;

	private bool BL0pjhvmnW2;

	internal virtual CheckBox ckPrimeiro
	{
		[CompilerGenerated]
		get
		{
			return aDOpt0BNWlM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			aDOpt0BNWlM = value;
		}
	}

	internal virtual Label LBFiltro
	{
		[CompilerGenerated]
		get
		{
			return mmRptR2hvef;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mmRptR2hvef = value;
		}
	}

	internal virtual TextBox TBPesquisa
	{
		[CompilerGenerated]
		get
		{
			return dqRptm9XXMg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = fK0ptPC98Sb;
			TextBox textBox = dqRptm9XXMg;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			dqRptm9XXMg = value;
			textBox = dqRptm9XXMg;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Label LBDistancia
	{
		[CompilerGenerated]
		get
		{
			return iiCptXVgmt0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			iiCptXVgmt0 = value;
		}
	}

	internal virtual Label LbQuantidade
	{
		[CompilerGenerated]
		get
		{
			return OFDptUwx0tF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			OFDptUwx0tF = value;
		}
	}

	internal virtual TextBox tbDx
	{
		[CompilerGenerated]
		get
		{
			return fp8ptyD0nIk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = NZnpt2odoMk;
			KeyPressEventHandler value3 = Nc0pt1ButvU;
			TextBox textBox = fp8ptyD0nIk;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
				textBox.KeyPress -= value3;
			}
			fp8ptyD0nIk = value;
			textBox = fp8ptyD0nIk;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
				textBox.KeyPress += value3;
			}
		}
	}

	internal virtual TextBox TBInserir
	{
		[CompilerGenerated]
		get
		{
			return cgJptgUt3mo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = FV1pteRL3gj;
			KeyPressEventHandler value3 = vbYptnwji50;
			TextBox textBox = cgJptgUt3mo;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
				textBox.KeyPress -= value3;
			}
			cgJptgUt3mo = value;
			textBox = cgJptgUt3mo;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
				textBox.KeyPress += value3;
			}
		}
	}

	internal virtual CheckBox CKAlternativo
	{
		[CompilerGenerated]
		get
		{
			return QHIptAOES2P;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			QHIptAOES2P = value;
		}
	}

	internal virtual CheckBox CKNomeVisivel
	{
		[CompilerGenerated]
		get
		{
			return oIpptssKG6C;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			oIpptssKG6C = value;
		}
	}

	internal virtual DataGridView dgBlocos
	{
		[CompilerGenerated]
		get
		{
			return z5mptBhabWr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = OBOptORgGGS;
			KeyEventHandler value3 = oTPptIereQD;
			KeyEventHandler value4 = Av4pt7P4wbc;
			DataGridView dataGridView = z5mptBhabWr;
			if (dataGridView != null)
			{
				dataGridView.MouseClick -= value2;
				dataGridView.KeyUp -= value3;
				dataGridView.KeyDown -= value4;
			}
			z5mptBhabWr = value;
			dataGridView = z5mptBhabWr;
			if (dataGridView != null)
			{
				dataGridView.MouseClick += value2;
				dataGridView.KeyUp += value3;
				dataGridView.KeyDown += value4;
			}
		}
	}

	internal virtual Button btSeleciona
	{
		[CompilerGenerated]
		get
		{
			return bjuptVRW5Xy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = w7Qpt8RiMv9;
			Button button = bjuptVRW5Xy;
			if (button != null)
			{
				button.Click -= value2;
			}
			bjuptVRW5Xy = value;
			button = bjuptVRW5Xy;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgMascaras
	{
		[CompilerGenerated]
		get
		{
			return z46ptu9yBjT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = XcmptwLG9CF;
			KeyEventHandler value3 = iy5ptxPkUEo;
			KeyEventHandler value4 = Iv8ptbYVDtV;
			DataGridView dataGridView = z46ptu9yBjT;
			if (dataGridView != null)
			{
				dataGridView.MouseClick -= value2;
				dataGridView.KeyUp -= value3;
				dataGridView.KeyDown -= value4;
			}
			z46ptu9yBjT = value;
			dataGridView = z46ptu9yBjT;
			if (dataGridView != null)
			{
				dataGridView.MouseClick += value2;
				dataGridView.KeyUp += value3;
				dataGridView.KeyDown += value4;
			}
		}
	}

	internal virtual Button btInserir
	{
		[CompilerGenerated]
		get
		{
			return tKMptEhWbaW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = YVHptNlmioe;
			Button button = tKMptEhWbaW;
			if (button != null)
			{
				button.Click -= value2;
			}
			tKMptEhWbaW = value;
			button = tKMptEhWbaW;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual PictureBox iDWG
	{
		[CompilerGenerated]
		get
		{
			return UNiptZ9d7Go;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			UNiptZ9d7Go = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return howptSyGb8C;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			howptSyGb8C = value;
		}
	}

	internal virtual Label LBFiltroBlocos
	{
		[CompilerGenerated]
		get
		{
			return xnApt4jMZ1W;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			xnApt4jMZ1W = value;
		}
	}

	internal virtual TextBox TBPesquisaBlocos
	{
		[CompilerGenerated]
		get
		{
			return nWVptCCxusq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = FcwptcaOFdE;
			TextBox textBox = nWVptCCxusq;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			nWVptCCxusq = value;
			textBox = nWVptCCxusq;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Label Label2
	{
		[CompilerGenerated]
		get
		{
			return hsVptYGqmMH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			hsVptYGqmMH = value;
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return H8FptrJUhh4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			H8FptrJUhh4 = value;
		}
	}

	internal virtual TextBox tbDy
	{
		[CompilerGenerated]
		get
		{
			return YEcpt9ClBhC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = YwFpt3JaZCw;
			KeyPressEventHandler value3 = AXqptltyJY3;
			TextBox textBox = YEcpt9ClBhC;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
				textBox.KeyPress -= value3;
			}
			YEcpt9ClBhC = value;
			textBox = YEcpt9ClBhC;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
				textBox.KeyPress += value3;
			}
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && nm6pt5jURT6 != null)
			{
				nm6pt5jURT6.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void wvxptL6DX8d()
	{
		nm6pt5jURT6 = new Container();
		ckPrimeiro = new CheckBox();
		LBFiltro = new Label();
		TBPesquisa = new TextBox();
		LBDistancia = new Label();
		LbQuantidade = new Label();
		tbDx = new TextBox();
		TBInserir = new TextBox();
		CKAlternativo = new CheckBox();
		CKNomeVisivel = new CheckBox();
		dgBlocos = new DataGridView();
		btSeleciona = new Button();
		dgMascaras = new DataGridView();
		btInserir = new Button();
		iDWG = new PictureBox();
		FDqpBiUmZij(new ToolTip(nm6pt5jURT6));
		GroupBox1 = new GroupBox();
		tbDy = new TextBox();
		Label2 = new Label();
		Label1 = new Label();
		LBFiltroBlocos = new Label();
		TBPesquisaBlocos = new TextBox();
		((ISupportInitialize)dgBlocos).BeginInit();
		((ISupportInitialize)dgMascaras).BeginInit();
		((ISupportInitialize)iDWG).BeginInit();
		GroupBox1.SuspendLayout();
		SuspendLayout();
		ckPrimeiro.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		ckPrimeiro.AutoSize = true;
		ckPrimeiro.Checked = true;
		ckPrimeiro.CheckState = CheckState.Checked;
		ckPrimeiro.Location = new Point(5, 22);
		ckPrimeiro.Name = "ckPrimeiro";
		ckPrimeiro.Size = new Size(77, 17);
		ckPrimeiro.TabIndex = 166;
		ckPrimeiro.Text = "CKPrimeiro";
		ckPrimeiro.TextAlign = ContentAlignment.MiddleRight;
		ckPrimeiro.UseVisualStyleBackColor = true;
		LBFiltro.BorderStyle = BorderStyle.Fixed3D;
		LBFiltro.Location = new Point(6, 9);
		LBFiltro.Name = "LBFiltro";
		LBFiltro.Size = new Size(81, 20);
		LBFiltro.TabIndex = 165;
		LBFiltro.Text = "Filtro";
		LBFiltro.TextAlign = ContentAlignment.MiddleCenter;
		TBPesquisa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TBPesquisa.CharacterCasing = CharacterCasing.Upper;
		TBPesquisa.Location = new Point(93, 9);
		TBPesquisa.Name = "TBPesquisa";
		TBPesquisa.Size = new Size(129, 20);
		TBPesquisa.TabIndex = 164;
		TBPesquisa.TextAlign = HorizontalAlignment.Center;
		LBDistancia.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LBDistancia.Location = new Point(75, 42);
		LBDistancia.Name = "LBDistancia";
		LBDistancia.Size = new Size(100, 17);
		LBDistancia.TabIndex = 163;
		LBDistancia.Text = "LBDistância";
		LBDistancia.TextAlign = ContentAlignment.MiddleCenter;
		LbQuantidade.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LbQuantidade.Location = new Point(2, 42);
		LbQuantidade.Name = "LbQuantidade";
		LbQuantidade.Size = new Size(63, 17);
		LbQuantidade.TabIndex = 162;
		LbQuantidade.Text = "LbInserir";
		LbQuantidade.TextAlign = ContentAlignment.MiddleLeft;
		tbDx.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		tbDx.Location = new Point(75, 63);
		tbDx.Name = "tbDx";
		tbDx.Size = new Size(37, 20);
		tbDx.TabIndex = 161;
		tbDx.TextAlign = HorizontalAlignment.Center;
		TBInserir.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TBInserir.Location = new Point(5, 63);
		TBInserir.Name = "TBInserir";
		TBInserir.Size = new Size(37, 20);
		TBInserir.TabIndex = 160;
		TBInserir.TextAlign = HorizontalAlignment.Center;
		CKAlternativo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CKAlternativo.AutoSize = true;
		CKAlternativo.Checked = true;
		CKAlternativo.CheckState = CheckState.Checked;
		CKAlternativo.Location = new Point(75, 454);
		CKAlternativo.Name = "CKAlternativo";
		CKAlternativo.Size = new Size(90, 17);
		CKAlternativo.TabIndex = 159;
		CKAlternativo.Text = "CKAlternativo";
		CKAlternativo.UseVisualStyleBackColor = true;
		CKNomeVisivel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CKNomeVisivel.AutoSize = true;
		CKNomeVisivel.Checked = true;
		CKNomeVisivel.CheckState = CheckState.Checked;
		CKNomeVisivel.Location = new Point(75, 430);
		CKNomeVisivel.Name = "CKNomeVisivel";
		CKNomeVisivel.Size = new Size(100, 17);
		CKNomeVisivel.TabIndex = 158;
		CKNomeVisivel.Text = "CKNomeVisível";
		CKNomeVisivel.UseVisualStyleBackColor = true;
		dgBlocos.AllowUserToAddRows = false;
		dgBlocos.AllowUserToDeleteRows = false;
		dgBlocos.AllowUserToOrderColumns = true;
		dgBlocos.AllowUserToResizeRows = false;
		dgBlocos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		dgBlocos.BorderStyle = BorderStyle.Fixed3D;
		dgBlocos.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgBlocos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgBlocos.Location = new Point(228, 171);
		dgBlocos.MultiSelect = false;
		dgBlocos.Name = "dgBlocos";
		dgBlocos.ReadOnly = true;
		dgBlocos.RowHeadersVisible = false;
		dgBlocos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgBlocos.Size = new Size(247, 222);
		dgBlocos.TabIndex = 157;
		btSeleciona.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btSeleciona.FlatStyle = FlatStyle.Flat;
		btSeleciona.ForeColor = SystemColors.Control;
		btSeleciona.Image = Resources.Select_32;
		btSeleciona.Location = new Point(12, 430);
		btSeleciona.Name = "btSeleciona";
		btSeleciona.Size = new Size(40, 40);
		btSeleciona.TabIndex = 152;
		btSeleciona.Tag = "";
		btSeleciona.UseVisualStyleBackColor = true;
		dgMascaras.AllowUserToAddRows = false;
		dgMascaras.AllowUserToDeleteRows = false;
		dgMascaras.AllowUserToOrderColumns = true;
		dgMascaras.AllowUserToResizeRows = false;
		dgMascaras.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgMascaras.BorderStyle = BorderStyle.Fixed3D;
		dgMascaras.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgMascaras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgMascaras.Location = new Point(6, 39);
		dgMascaras.MultiSelect = false;
		dgMascaras.Name = "dgMascaras";
		dgMascaras.ReadOnly = true;
		dgMascaras.RowHeadersVisible = false;
		dgMascaras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgMascaras.Size = new Size(216, 354);
		dgMascaras.TabIndex = 153;
		btInserir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btInserir.FlatStyle = FlatStyle.Flat;
		btInserir.ForeColor = SystemColors.Control;
		btInserir.Image = Resources.OK_32;
		btInserir.Location = new Point(426, 430);
		btInserir.Name = "btInserir";
		btInserir.Size = new Size(40, 40);
		btInserir.TabIndex = 163;
		btInserir.UseVisualStyleBackColor = true;
		iDWG.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		iDWG.BackColor = SystemColors.Desktop;
		iDWG.Location = new Point(228, 13);
		iDWG.Name = "iDWG";
		iDWG.Size = new Size(247, 129);
		iDWG.SizeMode = PictureBoxSizeMode.Zoom;
		iDWG.TabIndex = 150;
		iDWG.TabStop = false;
		GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		GroupBox1.Controls.Add(tbDy);
		GroupBox1.Controls.Add(Label2);
		GroupBox1.Controls.Add(Label1);
		GroupBox1.Controls.Add(TBInserir);
		GroupBox1.Controls.Add(ckPrimeiro);
		GroupBox1.Controls.Add(LbQuantidade);
		GroupBox1.Controls.Add(tbDx);
		GroupBox1.Controls.Add(LBDistancia);
		GroupBox1.Location = new Point(228, 399);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(181, 93);
		GroupBox1.TabIndex = 167;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "Inserção Múltipla";
		tbDy.Location = new Point(138, 63);
		tbDy.Name = "tbDy";
		tbDy.Size = new Size(37, 20);
		tbDy.TabIndex = 162;
		tbDy.TextAlign = HorizontalAlignment.Center;
		Label2.AutoSize = true;
		Label2.Location = new Point(121, 67);
		Label2.Name = "Label2";
		Label2.Size = new Size(14, 13);
		Label2.TabIndex = 168;
		Label2.Text = "Y";
		Label1.AutoSize = true;
		Label1.Location = new Point(58, 68);
		Label1.Name = "Label1";
		Label1.Size = new Size(14, 13);
		Label1.TabIndex = 167;
		Label1.Text = "X";
		LBFiltroBlocos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		LBFiltroBlocos.BorderStyle = BorderStyle.Fixed3D;
		LBFiltroBlocos.Location = new Point(228, 145);
		LBFiltroBlocos.Name = "LBFiltroBlocos";
		LBFiltroBlocos.Size = new Size(81, 20);
		LBFiltroBlocos.TabIndex = 169;
		LBFiltroBlocos.Text = "Filtro";
		LBFiltroBlocos.TextAlign = ContentAlignment.MiddleCenter;
		TBPesquisaBlocos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		TBPesquisaBlocos.CharacterCasing = CharacterCasing.Upper;
		TBPesquisaBlocos.Location = new Point(315, 145);
		TBPesquisaBlocos.Name = "TBPesquisaBlocos";
		TBPesquisaBlocos.Size = new Size(160, 20);
		TBPesquisaBlocos.TabIndex = 168;
		TBPesquisaBlocos.TextAlign = HorizontalAlignment.Center;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(487, 494);
		Controls.Add(LBFiltroBlocos);
		Controls.Add(TBPesquisaBlocos);
		Controls.Add(GroupBox1);
		Controls.Add(LBFiltro);
		Controls.Add(TBPesquisa);
		Controls.Add(CKAlternativo);
		Controls.Add(CKNomeVisivel);
		Controls.Add(dgBlocos);
		Controls.Add(btSeleciona);
		Controls.Add(dgMascaras);
		Controls.Add(btInserir);
		Controls.Add(iDWG);
		MinimumSize = new Size(503, 515);
		Name = "frmPortas";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Portas";
		((ISupportInitialize)dgBlocos).EndInit();
		((ISupportInitialize)dgMascaras).EndInit();
		((ISupportInitialize)iDWG).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return PDLptiMvj6I;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		PDLptiMvj6I = WithEventsValue;
	}

	public frmPortas()
	{
		LostFocus += HbyptFeayI6;
		Resize += pDvptKh7LWn;
		iVaptzBAbpH = null;
		jBGpjphsW8H = 0.0;
		S1qpjTDsslH = "";
		uebpjJyDZWP = "";
		BL0pjhvmnW2 = true;
		try
		{
			if (Geral.ExisteForm("frmPortas") || !clsAuxiliar.BancoValido())
			{
				return;
			}
			cDadosAccess.carregaDadosDWG();
			if (DeclaracoesGeral.arqAtivo.Indice != 0)
			{
				wvxptL6DX8d();
				uebpjJyDZWP = "1";
				TBInserir.Text = "1";
				tbDx.Text = "40";
				tbDy.Text = "0";
				tbDx.Enabled = false;
				tbDy.Enabled = false;
				jBGpjphsW8H = Width;
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 520]);
				w8dpBZ0kvSD().SetToolTip(btSeleciona, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 906]));
				w8dpBZ0kvSD().SetToolTip(btInserir, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 907]));
				CKNomeVisivel.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 910]);
				CKAlternativo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 911]);
				ckPrimeiro.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1023]);
				LBFiltro.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 272]);
				LBFiltroBlocos.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 272]);
				LbQuantidade.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 797]);
				LBDistancia.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 798]);
				GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 799]);
				clsMascara.CarregaMascaras(ref iVaptzBAbpH);
				DataGridView dg = dgMascaras;
				carregaMascarasNoDG(ref dg, iVaptzBAbpH, TBPesquisa.Text.ToString());
				dgMascaras = dg;
				CarregaBlocos();
				CKAlternativo.Checked = false;
				CKAlternativo.Enabled = false;
				Application.ShowModelessDialog((Form)this);
				if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
				{
					Left = 0;
				}
				BL0pjhvmnW2 = false;
				dg = dgMascaras;
				AtualizaColunasDGMascaraDG(ref dg);
				dgMascaras = dg;
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 331]), MsgBoxStyle.Information);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void CarregaBlocos()
	{
		if ((Operators.CompareString(DeclaracoesGeral.Conf.DirSimbologiaEletrica, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.DirSimbologiaEletrica))
		{
			ref object[,] reference = ref dYgpjWhBvvA;
			ref object[,] reference2 = ref reference;
			object mBlocos = reference;
			clsDispositivo.CarregaBlocos(ref mBlocos, "E");
			reference2 = (object[,])mBlocos;
			DataGridView withEventsValue = dgBlocos;
			ref object[,] reference3 = ref dYgpjWhBvvA;
			reference2 = ref reference3;
			mBlocos = reference3;
			xnAptQ7gZ96(ref withEventsValue, ref mBlocos, TBPesquisaBlocos.Text);
			reference2 = (object[,])mBlocos;
			dgBlocos = withEventsValue;
		}
	}

	private void XcmptwLG9CF(object P_0, MouseEventArgs P_1)
	{
		QnkptMTfsF5();
	}

	private void iy5ptxPkUEo(object P_0, KeyEventArgs P_1)
	{
		QnkptMTfsF5();
	}

	private void Iv8ptbYVDtV(object P_0, KeyEventArgs P_1)
	{
		QnkptMTfsF5();
	}

	private void QnkptMTfsF5()
	{
		CKAlternativo.Enabled = true;
		CKAlternativo.Checked = false;
		CKAlternativo.Enabled = false;
		checked
		{
			int num = dgMascaras.RowCount - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					if (dgMascaras.Rows[num2].Selected)
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			if (Operators.ConditionalCompareObjectNotEqual(dgMascaras.Rows[num2].Cells[7].Value, "", TextCompare: true))
			{
				CKAlternativo.Enabled = true;
				CKAlternativo.Checked = true;
			}
		}
	}

	private void OBOptORgGGS(object P_0, MouseEventArgs P_1)
	{
		DPDptqKYGU0();
	}

	private void oTPptIereQD(object P_0, KeyEventArgs P_1)
	{
		DPDptqKYGU0();
	}

	private void Av4pt7P4wbc(object P_0, KeyEventArgs P_1)
	{
		DPDptqKYGU0();
	}

	private void DPDptqKYGU0()
	{
		checked
		{
			int num = dgBlocos.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgBlocos.Rows[i].Selected)
				{
					S1qpjTDsslH = Conversions.ToString(dgBlocos.Rows[i].Cells[0].Value);
					break;
				}
			}
			gaoptae7500();
		}
	}

	private void gaoptae7500()
	{
		checked
		{
			int num = dgBlocos.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgBlocos.Rows[i].Selected)
				{
					iDWG.Image = RevJqj1qBkVn9MRpOU0.tiC18lyNXK(Conversions.ToString(dgBlocos.Rows[i].Cells[1].Value));
				}
			}
		}
	}

	private void w7Qpt8RiMv9(object P_0, EventArgs P_1)
	{
		PointMonitorToolTips.StopMonitor();
		Hide();
		DeclaracoesEntidades.StructurePortas portaE = default;
		int iPainel = 0;
		string left = clsPortas.selecionaUmaPorta(ref portaE, ref iPainel);
		checked
		{
			if (Operators.CompareString(portaE.Tipo, "E", TextCompare: true) == 0)
			{
				int num = dgMascaras.RowCount - 1;
				for (int i = 0; i <= num; i++)
				{
					dgMascaras.Rows[i].Selected = false;
				}
				int num2 = dgBlocos.RowCount - 1;
				for (int j = 0; j <= num2; j++)
				{
					dgBlocos.Rows[j].Selected = false;
				}
				int num3 = dgMascaras.RowCount - 1;
				for (int k = 0; k <= num3; k++)
				{
					if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(dgMascaras.Rows[k].Cells[2].Value, iPainel, TextCompare: true), Operators.CompareObjectEqual(dgMascaras.Rows[k].Cells[4].Value, portaE.indiceDoModelo, TextCompare: true)), Operators.CompareObjectEqual(dgMascaras.Rows[k].Cells[5].Value, portaE.Nome1, TextCompare: true)), Operators.CompareObjectEqual(dgMascaras.Rows[k].Cells[6].Value, portaE.Nome2, TextCompare: true)), Operators.CompareObjectEqual(dgMascaras.Rows[k].Cells[7].Value, portaE.Alternativo, TextCompare: true))))
					{
						dgMascaras.Rows[k].Selected = true;
						dgMascaras.FirstDisplayedScrollingRowIndex = k;
						break;
					}
				}
				int num4 = dgBlocos.RowCount - 1;
				for (int l = 0; l <= num4; l++)
				{
					if (Operators.ConditionalCompareObjectEqual(left, dgBlocos.Rows[l].Cells[2].Value, TextCompare: true))
					{
						dgBlocos.Rows[l].Selected = true;
						dgBlocos.FirstDisplayedScrollingRowIndex = l;
						break;
					}
				}
				gaoptae7500();
			}
			Show();
			PointMonitorToolTips.StartMonitor();
		}
	}

	private void YVHptNlmioe(object P_0, EventArgs P_1)
	{
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		if (!((Conversions.ToInteger(TBInserir.Text) > 1) & (Conversions.ToInteger(tbDx.Text) == 0) & (Conversions.ToInteger(tbDy.Text) == 0)))
		{
			Declaracoes2.MPorta myBL = default;
			try
			{
				if (!((Conversions.ToDouble(TBInserir.Text) > 1.0) & (Conversions.ToDouble(tbDx.Text) == 0.0) & (Conversions.ToDouble(tbDy.Text) == 0.0)))
				{
					PointMonitorToolTips.StopMonitor();
					Hide();
					if (dgMascaras.SelectedRows.Count > 0)
					{
						myBL.sPainel = Conversions.ToString(dgMascaras.SelectedRows[0].Cells[1].Value);
						myBL.iPainel = Conversions.ToInteger(dgMascaras.SelectedRows[0].Cells[2].Value);
						myBL.sHandle = Conversions.ToString(dgMascaras.SelectedRows[0].Cells[3].Value);
						myBL.iIndiceModelo = Conversions.ToInteger(dgMascaras.SelectedRows[0].Cells[4].Value);
						myBL.sNome1 = Conversions.ToString(dgMascaras.SelectedRows[0].Cells[5].Value);
						myBL.sNome2 = Conversions.ToString(dgMascaras.SelectedRows[0].Cells[6].Value);
						myBL.sAlternativo = Conversions.ToString(dgMascaras.SelectedRows[0].Cells[7].Value);
					}
					if (dgBlocos.SelectedRows.Count > 0)
					{
						myBL.sNomeDoBloco = Conversions.ToString(dgBlocos.SelectedRows[0].Cells[2].Value);
						myBL.sCaminhoBloco = Conversions.ToString(dgBlocos.SelectedRows[0].Cells[1].Value);
					}
					Point3d val = new Point3d(0.0, 0.0, 0.0);
					double num = 0.0;
					double num2 = 0.0;
					bool bNomeVisivel = CKNomeVisivel.Checked;
					int num3 = Conversions.ToInteger(TBInserir.Text);
					for (int i = 1; i <= num3; i = checked(i + 1))
					{
						val = clsPortas.InserirPorta(myBL, bNomeVisivel, CKAlternativo.Checked, Conversions.ToString(i), val);
						if (!((val.X == 0.0) & (val.Y == 0.0) & (val.Z == 0.0)))
						{
							num = Conversions.ToDouble(tbDx.Text);
							num2 = Conversions.ToDouble(tbDy.Text);
							if (!Information.IsNothing(val))
							{
								val = new Point3d(val.X + num, val.Y - num2, 0.0);
							}
							if (ckPrimeiro.Checked)
							{
								bNomeVisivel = false;
							}
							continue;
						}
						break;
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
		Show();
		PointMonitorToolTips.StartMonitor();
	}

	private void HbyptFeayI6(object P_0, EventArgs P_1)
	{
		checked
		{
			int num = dgMascaras.Rows.Count - 1;
			int num2 = default;
			for (int i = 0; i <= num; i++)
			{
				if (dgMascaras.Rows[i].Selected)
				{
					num2 = i;
					break;
				}
			}
			int num3 = dgMascaras.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				if (j == num2)
				{
					dgMascaras.Rows[j].Selected = true;
					if (j >= 3)
					{
						dgMascaras.FirstDisplayedScrollingRowIndex = j - 2;
					}
				}
			}
		}
	}

	private void xnAptQ7gZ96(ref DataGridView P_0, ref object P_1, string P_2)
	{
		if (Information.UBound((Array)P_1, 2) == 0)
		{
			return;
		}
		checked
		{
			try
			{
				bool flag = false;
				P_0.Rows.Clear();
				P_0.Columns.Clear();
				P_0.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 997]));
				P_0.Columns.Add("", "Caminho");
				P_0.Columns.Add("", "NomeCompleto");
				P_0.ColumnHeadersVisible = false;
				double a = P_0.Width - 20;
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
				btInserir.Enabled = false;
				int num4 = Information.UBound((Array)P_1, 2);
				for (int k = 1; k <= num4; k++)
				{
					if (LikeOperator.LikeString(NewLateBinding.LateIndexGet(P_1, new object[2] { 0, k }, null).ToString().ToUpper(), "*" + P_2.ToUpper() + "*", CompareMethod.Text))
					{
						P_0.Rows.Add(Conversions.ToString(NewLateBinding.LateIndexGet(P_1, new object[2] { 0, k }, null)), Conversions.ToString(NewLateBinding.LateIndexGet(P_1, new object[2] { 1, k }, null)), Conversions.ToString(NewLateBinding.LateIndexGet(P_1, new object[2] { 2, k }, null)));
						flag = true;
					}
				}
				if (!flag)
				{
					iDWG.Image = null;
					return;
				}
				P_0.Rows[0].Selected = true;
				iDWG.Image = RevJqj1qBkVn9MRpOU0.tiC18lyNXK(Conversions.ToString(P_0.Rows[0].Cells[1].Value));
				btInserir.Enabled = true;
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

	private void fK0ptPC98Sb(object P_0, KeyEventArgs P_1)
	{
		if ((P_1.KeyValue == 13) | (Operators.CompareString(TBPesquisa.Text, "", TextCompare: true) == 0))
		{
			DataGridView dg = dgMascaras;
			carregaMascarasNoDG(ref dg, iVaptzBAbpH, TBPesquisa.Text.ToString());
			dgMascaras = dg;
			dg = dgMascaras;
			AtualizaColunasDGMascaraDG(ref dg);
			dgMascaras = dg;
		}
	}

	private void FcwptcaOFdE(object P_0, KeyEventArgs P_1)
	{
		if ((P_1.KeyValue == 13) | (Operators.CompareString(TBPesquisaBlocos.Text, "", TextCompare: true) == 0))
		{
			DataGridView withEventsValue = dgBlocos;
			ref object[,] reference = ref dYgpjWhBvvA;
			object obj = reference;
			xnAptQ7gZ96(ref withEventsValue, ref obj, TBPesquisaBlocos.Text);
			reference = (object[,])obj;
			dgBlocos = withEventsValue;
			withEventsValue = dgBlocos;
			AtualizaColunasDGBlocosAuxiliares(ref withEventsValue);
			dgBlocos = withEventsValue;
		}
	}

	private void pDvptKh7LWn(object P_0, EventArgs P_1)
	{
		if (BL0pjhvmnW2)
		{
			return;
		}
		DataGridView dg = dgMascaras;
		AtualizaColunasDGMascaraDG(ref dg);
		dgMascaras = dg;
		dg = dgBlocos;
		AtualizaColunasDGBlocosAuxiliares(ref dg);
		dgBlocos = dg;
		checked
		{
			int num = dgMascaras.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgMascaras.Rows[i].Selected)
				{
					dgMascaras.FirstDisplayedScrollingRowIndex = i;
					break;
				}
			}
			int num2 = dgBlocos.RowCount - 1;
			int num3 = 0;
			while (true)
			{
				if (num3 <= num2)
				{
					if (dgBlocos.Rows[num3].Selected)
					{
						break;
					}
					num3++;
					continue;
				}
				return;
			}
			dgBlocos.FirstDisplayedScrollingRowIndex = num3;
		}
	}

	private void FV1pteRL3gj(object P_0, KeyEventArgs P_1)
	{
		if (Versioned.IsNumeric(TBInserir.Text))
		{
			if (Conversions.ToInteger(TBInserir.Text) <= 1)
			{
				if (Conversions.ToInteger(TBInserir.Text) > 1)
				{
					tbDx.Enabled = true;
					tbDy.Enabled = true;
				}
				else
				{
					TBInserir.Text = "1";
					tbDx.Enabled = false;
					tbDy.Enabled = false;
				}
			}
			else
			{
				tbDx.Enabled = true;
				tbDy.Enabled = true;
			}
		}
		else
		{
			TBInserir.Text = "1";
		}
	}

	private void NZnpt2odoMk(object P_0, KeyEventArgs P_1)
	{
		if (Operators.CompareString(tbDx.Text, "0", TextCompare: true) != 0)
		{
			tbDy.Text = "0";
		}
	}

	private void YwFpt3JaZCw(object P_0, KeyEventArgs P_1)
	{
		if (Operators.CompareString(tbDy.Text, "0", TextCompare: true) != 0)
		{
			tbDx.Text = "0";
		}
	}

	public static void carregaMascarasNoDG(ref DataGridView dg, Declaracoes2.MMascara[] mMasc, string sPesquisa)
	{
		checked
		{
			try
			{
				if (mMasc == null)
				{
					return;
				}
				Declaracoes2.MMascara mMascara = default;
				if (Information.UBound(mMasc) >= 2 && Information.UBound(mMasc) > 0)
				{
					int num = Information.UBound(mMasc) - 2;
					for (int i = num; i >= 1; i += -1)
					{
						int num2 = i;
						for (int j = 1; j <= num2; j++)
						{
							if (Operators.CompareString(mMasc[j].sNome1, mMasc[j + 1].sNome1, TextCompare: true) > 0)
							{
								mMascara = mMasc[j + 1];
								mMasc[j + 1] = mMasc[j];
								mMasc[j] = mMascara;
							}
							if (Operators.CompareString(mMasc[j].sPainel, mMasc[j + 1].sPainel, TextCompare: true) > 0)
							{
								mMascara = mMasc[j + 1];
								mMasc[j + 1] = mMasc[j];
								mMasc[j] = mMascara;
							}
						}
					}
				}
				dg.Rows.Clear();
				dg.Columns.Clear();
				if (Information.UBound(mMasc) <= 0)
				{
					return;
				}
				dg.Columns.Add("Máscara", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 524]));
				dg.Columns.Add("Painel", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1005]));
				dg.Columns.Add("IndicePainel", "");
				dg.Columns.Add("Handle", "");
				dg.Columns.Add("IndiceModelo", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 999]));
				dg.Columns.Add("Nome1", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1001]));
				dg.Columns.Add("Nome2", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1002]));
				dg.Columns.Add("Nome3", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1003]));
				dg.Columns.Add("Painel", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1005]));
				dg.Columns.Add("Máscara", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 524]));
				dg.Columns.Add("Alternativo", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 629]));
				dg.ColumnHeadersVisible = true;
				int num3 = Information.UBound(mMasc);
				for (int k = 1; k <= num3; k++)
				{
					if (Operators.CompareString(mMasc[k].sTipo, "P", TextCompare: true) != 0)
					{
						continue;
					}
					string text = "";
					text = mMasc[k].sNome1;
					if (Operators.CompareString(mMasc[k].sNome2, "", TextCompare: true) != 0)
					{
						if (Operators.CompareString(text, "", TextCompare: true) != 0)
						{
							text += "/";
						}
						text += mMasc[k].sNome2;
					}
					if (LikeOperator.LikeString(text.ToString().ToUpper(), "*" + sPesquisa.ToUpper() + "*", CompareMethod.Text) | LikeOperator.LikeString(mMasc[k].sNome3.ToString().ToUpper(), "*" + sPesquisa.ToUpper() + "*", CompareMethod.Text) | LikeOperator.LikeString(mMasc[k].sPainel.ToUpper(), "*" + sPesquisa.ToUpper() + "*", CompareMethod.Text))
					{
						dg.Rows.Add(text, mMasc[k].sPainel, mMasc[k].iPainel, mMasc[k].sHandle, mMasc[k].iIndiceModelo, mMasc[k].sNome1, mMasc[k].sNome2, mMasc[k].sNome3, mMasc[k].sPainel, text, mMasc[k].sNome3);
					}
				}
				foreach (DataGridViewRow item in (IEnumerable)dg.Rows)
				{
					dg.Rows[item.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

	public static void AtualizaColunasDGMascaraDG(ref DataGridView dg)
	{
		if (dg.RowCount == 0)
		{
			return;
		}
		checked
		{
			double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
			bool flag = false;
			int num2 = dg.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (Operators.ConditionalCompareObjectNotEqual(dg.Rows[i].Cells[10].Value, "", TextCompare: true))
				{
					flag = true;
					break;
				}
			}
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			if (!flag)
			{
				num3 = num * 0.5;
				num4 = num * 0.5;
				num5 = 0.0;
			}
			else
			{
				num3 = num * 0.4;
				num4 = num * 0.3;
				num5 = num * 0.3;
			}
			dg.Columns[0].Width = 0;
			dg.Columns[1].Width = 0;
			dg.Columns[2].Width = 0;
			dg.Columns[3].Width = 0;
			dg.Columns[4].Width = 0;
			dg.Columns[5].Width = 0;
			dg.Columns[6].Width = 0;
			dg.Columns[7].Width = 0;
			dg.Columns[8].Width = (int)Math.Round(num3);
			dg.Columns[9].Width = (int)Math.Round(num4);
			dg.Columns[10].Width = (int)Math.Round(num5);
			dg.Columns[0].Visible = false;
			dg.Columns[1].Visible = false;
			dg.Columns[2].Visible = false;
			dg.Columns[3].Visible = false;
			dg.Columns[4].Visible = false;
			dg.Columns[5].Visible = false;
			dg.Columns[6].Visible = false;
			dg.Columns[7].Visible = false;
			dg.Columns[8].Visible = true;
			dg.Columns[9].Visible = true;
			dg.Columns[10].Visible = false;
			if (flag)
			{
				dg.Columns[10].Visible = true;
			}
			dg.Columns[0].ReadOnly = false;
			dg.Columns[1].ReadOnly = false;
			dg.Columns[2].ReadOnly = false;
			dg.Columns[3].ReadOnly = false;
			dg.Columns[4].ReadOnly = false;
			dg.Columns[5].ReadOnly = false;
			dg.Columns[6].ReadOnly = false;
			dg.Columns[7].ReadOnly = false;
			dg.Columns[8].ReadOnly = false;
			dg.Columns[9].ReadOnly = false;
			dg.Columns[10].ReadOnly = false;
			dg.MultiSelect = false;
		}
	}

	public static void AtualizaColunasDGBlocosAuxiliares(ref DataGridView dg)
	{
		checked
		{
			if (dg.RowCount != 0)
			{
				dg.ColumnHeadersVisible = true;
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
				dg.ColumnHeadersVisible = false;
				dg.Columns[0].Width = (int)Math.Round(a);
				dg.Columns[1].Width = 0;
				dg.Columns[0].Visible = true;
				dg.Columns[1].Visible = false;
				dg.Columns[0].ReadOnly = false;
				dg.Columns[1].ReadOnly = false;
				dg.MultiSelect = false;
			}
		}
	}

	private void vbYptnwji50(object P_0, KeyPressEventArgs P_1)
	{
		if (Strings.Asc(P_1.KeyChar) != 8 && ((Strings.Asc(P_1.KeyChar) < 48) | (Strings.Asc(P_1.KeyChar) > 57)))
		{
			P_1.Handled = true;
		}
	}

	private void Nc0pt1ButvU(object P_0, KeyPressEventArgs P_1)
	{
		if (Strings.Asc(P_1.KeyChar) != 8 && ((Strings.Asc(P_1.KeyChar) < 48) | (Strings.Asc(P_1.KeyChar) > 57)))
		{
			P_1.Handled = true;
		}
	}

	private void AXqptltyJY3(object P_0, KeyPressEventArgs P_1)
	{
		if (Strings.Asc(P_1.KeyChar) != 8 && ((Strings.Asc(P_1.KeyChar) < 48) | (Strings.Asc(P_1.KeyChar) > 57)))
		{
			P_1.Handled = true;
		}
	}
}
