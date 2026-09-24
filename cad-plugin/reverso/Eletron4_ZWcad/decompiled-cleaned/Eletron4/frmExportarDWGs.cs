using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SAHkZEpGH6TdnaWjq6F;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmExportarDWGs : Form
{
	public struct mPaginaEX
	{
		public string sPG;

		public string sPGA;

		public string sRev;
	}

	private IContainer FctC45MXrt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("FolderBrowser")]
	private FolderBrowserDialog G2oCCFXfhR;

	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolTip qe6CYxTLPt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dg")]
	private DataGridView vHgCrnZTt6;

	[AccessedThroughProperty("GroupBox3")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox lRFC9N4rNY;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("CBVersao")]
	private ComboBox O7hCzuIefI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox yN8YWMsu1L;

	[AccessedThroughProperty("TbCaminho")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox CGFYpV7pyp;

	[AccessedThroughProperty("GroupBox2")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox CbDYTh1DvX;

	[CompilerGenerated]
	[AccessedThroughProperty("LBQuantCaracter")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label x27YJuME9n;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("Label5")]
	private Label GM8Yh5RQAg;

	[AccessedThroughProperty("Label2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label GQwYoxncyG;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CKRev")]
	[CompilerGenerated]
	private CheckBox iuXYGjwfjS;

	[AccessedThroughProperty("TBZeros")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox V4OYHeRl7C;

	[AccessedThroughProperty("TBTracoRev")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox bROYkTpNGs;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("Label4")]
	private Label jj2YdJMism;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBTracoPagina")]
	[CompilerGenerated]
	private TextBox Da8YfITLAT;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBNome")]
	private TextBox zF6YDwOeDu;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label1")]
	private Label V0PYvjbBlY;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CKNome")]
	private CheckBox qqKY6X4AET;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSelecionaDiretorio")]
	[CompilerGenerated]
	private Button M9jYtE0r3R;

	[AccessedThroughProperty("btExportarDWG")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button KOaYjtxsw8;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ProgressBar1")]
	private ProgressBar auBYL1nveF;

	[AccessedThroughProperty("rbAlternativo")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton OkpYw9t2sp;

	[AccessedThroughProperty("rbPagina")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton V2sYx6lWRh;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTCancelar")]
	[CompilerGenerated]
	private Button gQsYbD5RbI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ckExplodir")]
	private CheckBox XDmYMQPVgL;

	public bool bExportar;

	private mPaginaEX[] Pv8YObAp69;

	public string sVersao;

	internal virtual DataGridView dg
	{
		[CompilerGenerated]
		get
		{
			return vHgCrnZTt6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			vHgCrnZTt6 = value;
		}
	}

	internal virtual GroupBox GroupBox3
	{
		[CompilerGenerated]
		get
		{
			return lRFC9N4rNY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			lRFC9N4rNY = value;
		}
	}

	internal virtual ComboBox CBVersao
	{
		[CompilerGenerated]
		get
		{
			return O7hCzuIefI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			O7hCzuIefI = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return yN8YWMsu1L;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			yN8YWMsu1L = value;
		}
	}

	internal virtual TextBox TbCaminho
	{
		[CompilerGenerated]
		get
		{
			return CGFYpV7pyp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CGFYpV7pyp = value;
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return CbDYTh1DvX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CbDYTh1DvX = value;
		}
	}

	internal virtual Label LBQuantCaracter
	{
		[CompilerGenerated]
		get
		{
			return x27YJuME9n;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			x27YJuME9n = value;
		}
	}

	internal virtual Label Label5
	{
		[CompilerGenerated]
		get
		{
			return GM8Yh5RQAg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			GM8Yh5RQAg = value;
		}
	}

	internal virtual Label Label2
	{
		[CompilerGenerated]
		get
		{
			return GQwYoxncyG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			GQwYoxncyG = value;
		}
	}

	internal virtual CheckBox CKRev
	{
		[CompilerGenerated]
		get
		{
			return iuXYGjwfjS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = vAfCZoC30H;
			CheckBox checkBox = iuXYGjwfjS;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			iuXYGjwfjS = value;
			checkBox = iuXYGjwfjS;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual TextBox TBZeros
	{
		[CompilerGenerated]
		get
		{
			return V4OYHeRl7C;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			V4OYHeRl7C = value;
		}
	}

	internal virtual TextBox TBTracoRev
	{
		[CompilerGenerated]
		get
		{
			return bROYkTpNGs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			bROYkTpNGs = value;
		}
	}

	internal virtual Label Label4
	{
		[CompilerGenerated]
		get
		{
			return jj2YdJMism;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jj2YdJMism = value;
		}
	}

	internal virtual TextBox TBTracoPagina
	{
		[CompilerGenerated]
		get
		{
			return Da8YfITLAT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Da8YfITLAT = value;
		}
	}

	internal virtual TextBox TBNome
	{
		[CompilerGenerated]
		get
		{
			return zF6YDwOeDu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zF6YDwOeDu = value;
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return V0PYvjbBlY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			V0PYvjbBlY = value;
		}
	}

	internal virtual CheckBox CKNome
	{
		[CompilerGenerated]
		get
		{
			return qqKY6X4AET;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = KyWCEvrDNt;
			CheckBox checkBox = qqKY6X4AET;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			qqKY6X4AET = value;
			checkBox = qqKY6X4AET;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button btSelecionaDiretorio
	{
		[CompilerGenerated]
		get
		{
			return M9jYtE0r3R;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = mA6Cy1Hcev;
			Button button = M9jYtE0r3R;
			if (button != null)
			{
				button.Click -= value2;
			}
			M9jYtE0r3R = value;
			button = M9jYtE0r3R;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btExportarDWG
	{
		[CompilerGenerated]
		get
		{
			return KOaYjtxsw8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = N66CgS0Nop;
			Button button = KOaYjtxsw8;
			if (button != null)
			{
				button.Click -= value2;
			}
			KOaYjtxsw8 = value;
			button = KOaYjtxsw8;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual ProgressBar ProgressBar1
	{
		[CompilerGenerated]
		get
		{
			return auBYL1nveF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			auBYL1nveF = value;
		}
	}

	internal virtual RadioButton rbAlternativo
	{
		[CompilerGenerated]
		get
		{
			return OkpYw9t2sp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Cj5CSSUSJY;
			RadioButton radioButton = OkpYw9t2sp;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			OkpYw9t2sp = value;
			radioButton = OkpYw9t2sp;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton rbPagina
	{
		[CompilerGenerated]
		get
		{
			return V2sYx6lWRh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			V2sYx6lWRh = value;
		}
	}

	internal virtual Button BTCancelar
	{
		[CompilerGenerated]
		get
		{
			return gQsYbD5RbI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = S6mCAQx9X9;
			Button button = gQsYbD5RbI;
			if (button != null)
			{
				button.Click -= value2;
			}
			gQsYbD5RbI = value;
			button = gQsYbD5RbI;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox ckExplodir
	{
		[CompilerGenerated]
		get
		{
			return XDmYMQPVgL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = vAfCZoC30H;
			CheckBox checkBox = XDmYMQPVgL;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			XDmYMQPVgL = value;
			checkBox = XDmYMQPVgL;
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
			if (disposing && FctC45MXrt != null)
			{
				FctC45MXrt.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void EORCUuXXXK()
	{
		FctC45MXrt = new Container();
		aHypBEW66iS(new FolderBrowserDialog());
		FDqpBiUmZij(new ToolTip(FctC45MXrt));
		dg = new DataGridView();
		GroupBox3 = new GroupBox();
		CBVersao = new ComboBox();
		GroupBox1 = new GroupBox();
		TbCaminho = new TextBox();
		btSelecionaDiretorio = new Button();
		GroupBox2 = new GroupBox();
		rbAlternativo = new RadioButton();
		rbPagina = new RadioButton();
		LBQuantCaracter = new Label();
		Label5 = new Label();
		Label2 = new Label();
		CKRev = new CheckBox();
		TBZeros = new TextBox();
		TBTracoRev = new TextBox();
		Label4 = new Label();
		TBTracoPagina = new TextBox();
		TBNome = new TextBox();
		Label1 = new Label();
		CKNome = new CheckBox();
		ckExplodir = new CheckBox();
		btExportarDWG = new Button();
		ProgressBar1 = new ProgressBar();
		BTCancelar = new Button();
		((ISupportInitialize)dg).BeginInit();
		GroupBox3.SuspendLayout();
		GroupBox1.SuspendLayout();
		GroupBox2.SuspendLayout();
		SuspendLayout();
		dg.AllowUserToAddRows = false;
		dg.AllowUserToDeleteRows = false;
		dg.AllowUserToResizeRows = false;
		dg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dg.BackgroundColor = Color.White;
		dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dg.Location = new Point(262, 12);
		dg.MultiSelect = false;
		dg.Name = "dg";
		dg.ReadOnly = true;
		dg.RowHeadersVisible = false;
		dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dg.Size = new Size(180, 324);
		dg.TabIndex = 24;
		GroupBox3.Controls.Add(CBVersao);
		GroupBox3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		GroupBox3.Location = new Point(12, 271);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(156, 49);
		GroupBox3.TabIndex = 22;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "Versão DWG";
		CBVersao.FormattingEnabled = true;
		CBVersao.Location = new Point(6, 19);
		CBVersao.Name = "CBVersao";
		CBVersao.Size = new Size(146, 21);
		CBVersao.TabIndex = 0;
		GroupBox1.Controls.Add(TbCaminho);
		GroupBox1.Controls.Add(btSelecionaDiretorio);
		GroupBox1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		GroupBox1.Location = new Point(12, 12);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(239, 65);
		GroupBox1.TabIndex = 21;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "Exportar para:";
		TbCaminho.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TbCaminho.Location = new Point(6, 19);
		TbCaminho.Multiline = true;
		TbCaminho.Name = "TbCaminho";
		TbCaminho.Size = new Size(187, 36);
		TbCaminho.TabIndex = 2;
		btSelecionaDiretorio.FlatStyle = FlatStyle.Flat;
		btSelecionaDiretorio.ForeColor = SystemColors.Control;
		btSelecionaDiretorio.Image = Resources.Folder;
		btSelecionaDiretorio.Location = new Point(193, 14);
		btSelecionaDiretorio.Name = "btSelecionaDiretorio";
		btSelecionaDiretorio.Size = new Size(45, 45);
		btSelecionaDiretorio.TabIndex = 26;
		btSelecionaDiretorio.UseVisualStyleBackColor = true;
		GroupBox2.Controls.Add(rbAlternativo);
		GroupBox2.Controls.Add(rbPagina);
		GroupBox2.Controls.Add(LBQuantCaracter);
		GroupBox2.Controls.Add(Label5);
		GroupBox2.Controls.Add(Label2);
		GroupBox2.Controls.Add(CKRev);
		GroupBox2.Controls.Add(TBZeros);
		GroupBox2.Controls.Add(TBTracoRev);
		GroupBox2.Controls.Add(Label4);
		GroupBox2.Controls.Add(TBTracoPagina);
		GroupBox2.Controls.Add(TBNome);
		GroupBox2.Controls.Add(Label1);
		GroupBox2.Controls.Add(CKNome);
		GroupBox2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		GroupBox2.Location = new Point(12, 83);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(240, 156);
		GroupBox2.TabIndex = 20;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "Formação do Nome";
		rbAlternativo.AutoSize = true;
		rbAlternativo.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		rbAlternativo.Location = new Point(27, 92);
		rbAlternativo.Name = "rbAlternativo";
		rbAlternativo.Size = new Size(75, 17);
		rbAlternativo.TabIndex = 29;
		rbAlternativo.Text = "Alternativo";
		rbAlternativo.UseVisualStyleBackColor = true;
		rbPagina.AutoSize = true;
		rbPagina.Checked = true;
		rbPagina.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		rbPagina.Location = new Point(27, 75);
		rbPagina.Name = "rbPagina";
		rbPagina.Size = new Size(58, 17);
		rbPagina.TabIndex = 28;
		rbPagina.TabStop = true;
		rbPagina.Text = "Página";
		rbPagina.UseVisualStyleBackColor = true;
		LBQuantCaracter.AutoSize = true;
		LBQuantCaracter.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		LBQuantCaracter.Location = new Point(148, 86);
		LBQuantCaracter.Name = "LBQuantCaracter";
		LBQuantCaracter.Size = new Size(82, 13);
		LBQuantCaracter.TabIndex = 19;
		LBQuantCaracter.Text = "# de caracteres";
		Label5.AutoSize = true;
		Label5.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label5.Location = new Point(86, 121);
		Label5.Name = "Label5";
		Label5.Size = new Size(22, 24);
		Label5.TabIndex = 18;
		Label5.Text = "+";
		Label2.AutoSize = true;
		Label2.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label2.Location = new Point(5, 79);
		Label2.Name = "Label2";
		Label2.Size = new Size(22, 24);
		Label2.TabIndex = 11;
		Label2.Text = "+";
		CKRev.AutoSize = true;
		CKRev.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		CKRev.Location = new Point(114, 127);
		CKRev.Name = "CKRev";
		CKRev.Size = new Size(65, 17);
		CKRev.TabIndex = 10;
		CKRev.Text = "Revisão";
		CKRev.UseVisualStyleBackColor = true;
		TBZeros.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBZeros.Location = new Point(117, 81);
		TBZeros.Multiline = true;
		TBZeros.Name = "TBZeros";
		TBZeros.Size = new Size(26, 24);
		TBZeros.TabIndex = 12;
		TBTracoRev.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBTracoRev.Location = new Point(28, 123);
		TBTracoRev.Multiline = true;
		TBTracoRev.Name = "TBTracoRev";
		TBTracoRev.Size = new Size(52, 24);
		TBTracoRev.TabIndex = 9;
		Label4.AutoSize = true;
		Label4.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label4.Location = new Point(5, 122);
		Label4.Name = "Label4";
		Label4.Size = new Size(22, 24);
		Label4.TabIndex = 8;
		Label4.Text = "+";
		TBTracoPagina.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBTracoPagina.Location = new Point(193, 42);
		TBTracoPagina.Multiline = true;
		TBTracoPagina.Name = "TBTracoPagina";
		TBTracoPagina.Size = new Size(39, 24);
		TBTracoPagina.TabIndex = 7;
		TBNome.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBNome.Location = new Point(9, 42);
		TBNome.Multiline = true;
		TBNome.Name = "TBNome";
		TBNome.Size = new Size(163, 24);
		TBNome.TabIndex = 5;
		Label1.AutoSize = true;
		Label1.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		Label1.Location = new Point(173, 42);
		Label1.Name = "Label1";
		Label1.Size = new Size(22, 24);
		Label1.TabIndex = 3;
		Label1.Text = "+";
		CKNome.AutoSize = true;
		CKNome.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		CKNome.Location = new Point(9, 19);
		CKNome.Name = "CKNome";
		CKNome.Size = new Size(54, 17);
		CKNome.TabIndex = 0;
		CKNome.Text = "Nome";
		CKNome.UseVisualStyleBackColor = true;
		ckExplodir.AutoSize = true;
		ckExplodir.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		ckExplodir.Location = new Point(21, 245);
		ckExplodir.Name = "ckExplodir";
		ckExplodir.Size = new Size(63, 17);
		ckExplodir.TabIndex = 10;
		ckExplodir.Text = "Explodir";
		ckExplodir.UseVisualStyleBackColor = true;
		btExportarDWG.FlatStyle = FlatStyle.Flat;
		btExportarDWG.ForeColor = SystemColors.Control;
		btExportarDWG.Image = Resources.ExportaDWG_32;
		btExportarDWG.Location = new Point(207, 271);
		btExportarDWG.Name = "btExportarDWG";
		btExportarDWG.Size = new Size(45, 45);
		btExportarDWG.TabIndex = 27;
		btExportarDWG.UseVisualStyleBackColor = true;
		ProgressBar1.Location = new Point(12, 326);
		ProgressBar1.Name = "ProgressBar1";
		ProgressBar1.Size = new Size(240, 10);
		ProgressBar1.TabIndex = 23;
		BTCancelar.FlatStyle = FlatStyle.Flat;
		BTCancelar.ForeColor = SystemColors.Control;
		BTCancelar.Image = Resources.Stop_32;
		BTCancelar.Location = new Point(170, 272);
		BTCancelar.Name = "BTCancelar";
		BTCancelar.Size = new Size(40, 42);
		BTCancelar.TabIndex = 28;
		BTCancelar.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(454, 341);
		Controls.Add(ckExplodir);
		Controls.Add(BTCancelar);
		Controls.Add(btExportarDWG);
		Controls.Add(dg);
		Controls.Add(ProgressBar1);
		Controls.Add(GroupBox3);
		Controls.Add(GroupBox1);
		Controls.Add(GroupBox2);
		ImeMode = ImeMode.On;
		MaximumSize = new Size(470, 1360);
		MinimumSize = new Size(470, 380);
		Name = "frmExportarDWGs";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Exportar DWG";
		((ISupportInitialize)dg).EndInit();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return G2oCCFXfhR;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		G2oCCFXfhR = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return qe6CYxTLPt;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		qe6CYxTLPt = WithEventsValue;
	}

	public frmExportarDWGs()
	{
		Resize += cnACiRWEit;
		bExportar = true;
		if (!Geral.ExisteForm("frmExportarDWGs"))
		{
			EORCUuXXXK();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 140]);
			GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1307]);
			GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1308]);
			GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1309]);
			rbAlternativo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 10]);
			rbPagina.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 9]);
			LBQuantCaracter.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1310]);
			CKNome.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 987]);
			CKRev.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 62]);
			ckExplodir.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1790]);
			CarregaPG();
			CKNome.Checked = true;
			rbPagina.Checked = true;
			CKRev.Checked = false;
			TBTracoRev.Enabled = false;
			TBTracoPagina.Text = "-";
			TBZeros.Text = "0";
			TBTracoRev.Text = "-R";
			Application.ShowModelessDialog((Form)this);
			WxuCuQiS3h();
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
		}
	}

	private void mA6Cy1Hcev(object P_0, EventArgs P_1)
	{
		if (!DIYCsUsIaP())
		{
		}
	}

	private void N66CgS0Nop(object P_0, EventArgs P_1)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected I4, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0683: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f2: Unknown result type (might be due to invalid IL or missing references)
		if (!Correcao.corrigeTextStyles())
		{
			return;
		}
		string pag = DeclaracoesGeral.ativo.Pagina;
		btExportarDWG.Enabled = false;
		bool flag = ckExplodir.Checked;
		string text = "";
		string text2 = "";
		bool bMensagem = true;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		double ltscale = database.Ltscale;
		int iUnit = (int)database.Insunits;
		if (Operators.CompareString(TbCaminho.Text, "", TextCompare: true) == 0)
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 611]), MsgBoxStyle.Information);
			if (!DIYCsUsIaP())
			{
				return;
			}
		}
		sVersao = CBVersao.Text;
		DwgVersion val = (DwgVersion)31;
		string left = sVersao;
		if (Operators.CompareString(left, "AutoCAD 2018", TextCompare: true) != 0)
		{
			val = ((Operators.CompareString(left, "AutoCAD 2013", TextCompare: true) == 0) ? ((DwgVersion)31) : ((DwgVersion)33));
		}
		else
		{
			val = (DwgVersion)33;
		}
		bExportar = true;
		int num = Conversions.ToInteger(TBZeros.Text);
		string text3 = "";
		int num2 = num;
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				text3 += "0";
			}
			string text4 = "";
			if (CKNome.Checked)
			{
				text4 = TBTracoPagina.Text.Trim();
			}
			string text5 = "";
			int num3 = 2;
			int num4 = dg.Rows.Count - 1;
			for (int j = 0; j <= num4; j++)
			{
				if (dg.Rows[j].Selected)
				{
					num3++;
				}
			}
			ProgressBar1.Minimum = 0;
			ProgressBar1.Maximum = num3;
			ProgressBar1.Value = 0;
			ProgressBar1.Step = 1;
			Revisao.capturaRevisoesCompletas();
			Revisao.capturaRevisoesSimplificadas();
			ProgressBar1.Increment(1);
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			Application.UpdateScreen();
			if (flag)
			{
				KmXZg6powIdvncpZAnk.PISpx4jbBk();
			}
			Database newDb = Application.DocumentManager.MdiActiveDocument.Database;
			ExportarPG.PurgeDatabase(ref newDb);
			int num5 = dg.Rows.Count - 1;
			for (int k = 0; k <= num5; k++)
			{
				if (!bExportar)
				{
					break;
				}
				if (!dg.Rows[k].Selected)
				{
					continue;
				}
				if (Operators.ConditionalCompareObjectNotEqual(dg.Rows[k].Cells[0].Value, null, TextCompare: true))
				{
					string text6 = Conversions.ToString(dg.Rows[k].Cells[2].Value);
					if (flag)
					{
						KmXZg6powIdvncpZAnk.kOHp6XhTCZ(text6);
					}
					if (Operators.CompareString(TbCaminho.Text, "", TextCompare: true) != 0)
					{
						text = TbCaminho.Text;
					}
					if (CKNome.Checked)
					{
						text += TBNome.Text;
					}
					if (!((num == 0) | (Strings.Len(text6) >= num)))
					{
						text5 = Strings.Mid(text3, 1, num - Strings.Len(text6)) + text6;
						if (rbAlternativo.Checked)
						{
							text5 = Conversions.ToString(Operators.ConcatenateObject(Strings.Mid(text3, 1, num - Strings.Len(RuntimeHelpers.GetObjectValue(dg.Rows[k].Cells[0].Value))), dg.Rows[k].Cells[0].Value));
						}
					}
					else
					{
						text5 = text6;
						if (rbAlternativo.Checked)
						{
							text5 = Conversions.ToString(dg.Rows[k].Cells[0].Value);
						}
					}
					text = text + text4 + text5;
					int num6 = Information.UBound(DeclaracoesGeral.mRevCompleta);
					for (int l = 1; l <= num6; l++)
					{
						if (Operators.CompareString(text6, DeclaracoesGeral.mRevCompleta[l].Pagina, TextCompare: true) == 0)
						{
							text2 = DeclaracoesGeral.mRevCompleta[l].Revisao;
							break;
						}
					}
					if (Operators.CompareString(text2, "", TextCompare: true) == 0)
					{
						int num7 = Information.UBound(DeclaracoesGeral.mRevSimplificada, 2);
						for (int m = 1; m <= num7; m++)
						{
							if (Operators.ConditionalCompareObjectEqual(text6, DeclaracoesGeral.mRevSimplificada[0, m], TextCompare: true) && Operators.CompareString(text2, "", TextCompare: true) == 0)
							{
								text2 = Conversions.ToString(DeclaracoesGeral.mRevSimplificada[1, m]);
								break;
							}
						}
					}
					if (CKRev.Checked)
					{
						text = text + TBTracoRev.Text + text2;
					}
					text += ".dwg";
					Pagina.AtivaPagina(Conversions.ToString(dg.Rows[k].Cells[0].Value));
					uscPaginas uscPagina = DeclaracoesGeral._uscPagina;
					DataGridViewCell dataGridViewCell;
					string pag2 = Conversions.ToString((dataGridViewCell = dg.Rows[k].Cells[0]).Value);
					uscPagina.ativaPaginaAtalho(ref pag2);
					dataGridViewCell.Value = pag2;
					ProgressBar1.Increment(1);
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
					Application.UpdateScreen();
					ExportarPG.ExportaPaginaDWG(ltscale, iUnit, text6, Conversions.ToString(num3), text, val, TBNome.Text, CBVersao.Text, ref bExportar, bMensagem);
					if (flag)
					{
						KmXZg6powIdvncpZAnk.B87pdnUnMO(text, val);
					}
					KmXZg6powIdvncpZAnk.xdmpfY6Fg7(text, val);
					KmXZg6powIdvncpZAnk.vbOpDVnOD8(text, val);
					KmXZg6powIdvncpZAnk.Tnapj8Vx74(text, val);
					if (flag)
					{
						KmXZg6powIdvncpZAnk.Xh6ptgg8r5();
					}
					bMensagem = false;
				}
				dg.Rows[k].Selected = false;
				if (k > 5)
				{
					dg.FirstDisplayedScrollingRowIndex = k - 6;
				}
			}
			ProgressBar1.Increment(1);
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			Application.UpdateScreen();
			if (flag)
			{
				KmXZg6powIdvncpZAnk.TUOpOC13mF();
			}
			ProgressBar1.Value = 0;
			Pagina.AtivaPagina(pag);
			DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
			btExportarDWG.Enabled = true;
		}
	}

	private void S6mCAQx9X9(object P_0, EventArgs P_1)
	{
		checked
		{
			int num = dg.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				dg.Rows[i].Selected = false;
			}
			btExportarDWG.Enabled = true;
		}
	}

	public void CarregaPG()
	{
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		_ = mdiActiveDocument.Database;
		string nomeDWG = "";
		string caminho = "";
		Geral.extraiNomeCaminhoDwg(mdiActiveDocument.Name, ref nomeDWG, ref caminho);
		if (Operators.CompareString(TBNome.Text, "", TextCompare: true) == 0)
		{
			TBNome.Text = nomeDWG;
		}
		if (Operators.CompareString(TbCaminho.Text, "", TextCompare: true) == 0)
		{
			TbCaminho.Text = caminho;
		}
		CBVersao.Items.Clear();
		CBVersao.Text = "";
		string text = Geral.MostrarVersaoDWGMaisRecente();
		string left = text;
		if (Operators.CompareString(left, "AC1032", TextCompare: true) != 0 && Operators.CompareString(left, "AC1033", TextCompare: true) != 0 && Operators.CompareString(left, "AC1034", TextCompare: true) != 0)
		{
			if (Operators.CompareString(left, "AC1027", TextCompare: true) == 0 || Operators.CompareString(left, "AC1028", TextCompare: true) == 0 || Operators.CompareString(left, "AC1029", TextCompare: true) == 0 || Operators.CompareString(left, "AC1030", TextCompare: true) == 0 || Operators.CompareString(left, "AC1031", TextCompare: true) == 0)
			{
				CBVersao.Items.Add("AutoCAD 2013");
				CBVersao.Text = "AutoCAD 2013";
			}
		}
		else
		{
			CBVersao.Items.Add("AutoCAD 2018");
			CBVersao.Items.Add("AutoCAD 2013");
			CBVersao.Text = "AutoCAD 2018";
		}
		int num = 0;
		Pv8YObAp69 = new mPaginaEX[1];
		int num2 = Information.UBound(DeclaracoesGeral.mPaginas, 2);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				if (Operators.CompareString(DeclaracoesGeral.mPaginas[0, i].ToString().Trim(), "", TextCompare: true) != 0)
				{
					num = Information.UBound(Pv8YObAp69) + 1;
					ref mPaginaEX[] pv8YObAp = ref Pv8YObAp69;
					pv8YObAp = (mPaginaEX[])Utils.CopyArray(pv8YObAp, new mPaginaEX[num + 1]);
					Pv8YObAp69[num].sPG = Conversions.ToString(DeclaracoesGeral.mPaginas[0, i]);
					Pv8YObAp69[num].sRev = " ";
					Pv8YObAp69[num].sPGA = "";
					if (rbAlternativo.Checked)
					{
						Pv8YObAp69[num].sPGA = Conversions.ToString(DeclaracoesGeral.mPaginas[4, i]);
					}
				}
			}
			Revisao.capturaRevisoesCompletas();
			int num3 = Information.UBound(Pv8YObAp69);
			for (int j = 1; j <= num3; j++)
			{
				int num4 = Information.UBound(DeclaracoesGeral.mRevCompleta);
				for (int k = 1; k <= num4; k++)
				{
					if (Operators.CompareString(Pv8YObAp69[j].sPG, DeclaracoesGeral.mRevCompleta[k].Pagina, TextCompare: true) == 0)
					{
						Pv8YObAp69[j].sRev = DeclaracoesGeral.mRevCompleta[k].Revisao;
						break;
					}
				}
			}
			Revisao.capturaRevisoesSimplificadas();
			int num5 = Information.UBound(Pv8YObAp69);
			for (int l = 1; l <= num5; l++)
			{
				int num6 = Information.UBound(DeclaracoesGeral.mRevSimplificada, 2);
				for (int m = 1; m <= num6; m++)
				{
					if (Operators.ConditionalCompareObjectEqual(Pv8YObAp69[l].sPG, DeclaracoesGeral.mRevSimplificada[0, m], TextCompare: true) && Operators.CompareString(Pv8YObAp69[l].sRev.Trim(), "", TextCompare: true) == 0)
					{
						Pv8YObAp69[l].sRev = Conversions.ToString(DeclaracoesGeral.mRevSimplificada[1, m]);
						break;
					}
				}
			}
			if (Information.UBound(Pv8YObAp69) >= 2 && Information.UBound(Pv8YObAp69) > 0)
			{
				int num7 = Information.UBound(Pv8YObAp69) - 1;
				for (int n = num7; n >= 1; n += -1)
				{
					int num8 = n;
					for (int num9 = 1; num9 <= num8; num9++)
					{
						if (Pagina.calculaPaginaDecimal(Pv8YObAp69[num9].sPG) > Pagina.calculaPaginaDecimal(Pv8YObAp69[num9 + 1].sPG))
						{
							mPaginaEX mPaginaEX2 = default;
							mPaginaEX2 = Pv8YObAp69[num9 + 1];
							Pv8YObAp69[num9 + 1] = Pv8YObAp69[num9];
							Pv8YObAp69[num9] = mPaginaEX2;
						}
					}
				}
			}
			i0aCBTMgrw();
			iqmCVk2Z0M();
		}
	}

	private bool DIYCsUsIaP()
	{
		I8spBuIa499().Description = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1306]);
		I8spBuIa499().RootFolder = Environment.SpecialFolder.MyComputer;
		I8spBuIa499().ShowNewFolderButton = false;
		if (I8spBuIa499().ShowDialog() != DialogResult.OK)
		{
			return false;
		}
		string text = I8spBuIa499().SelectedPath;
		if (Operators.CompareString(Strings.Mid(text, Strings.Len(text), Strings.Len(text)), "\\", TextCompare: true) != 0)
		{
			text += "\\";
		}
		TbCaminho.Text = text;
		return true;
	}

	private void i0aCBTMgrw()
	{
		dg.Rows.Clear();
		dg.Columns.Clear();
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 9]));
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 380]));
		dg.Columns.Add("Layer", "Layer");
		checked
		{
			int num = dg.Columns.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				dg.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
			}
			WxuCuQiS3h();
		}
	}

	private void iqmCVk2Z0M()
	{
		try
		{
			dg.MultiSelect = true;
			int num = Information.UBound(DeclaracoesGeral.mPaginas, 2);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(Pv8YObAp69[i].sPGA.ToString().Trim(), "", TextCompare: true) == 0)
				{
					dg.Rows.Add(Pv8YObAp69[i].sPG, Pv8YObAp69[i].sRev, Pv8YObAp69[i].sPG);
				}
				else
				{
					dg.Rows.Add(Pv8YObAp69[i].sPGA, Pv8YObAp69[i].sRev, Pv8YObAp69[i].sPG);
				}
			}
			dg.Columns[0].ReadOnly = true;
			dg.Columns[1].ReadOnly = true;
			WxuCuQiS3h();
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

	private void WxuCuQiS3h()
	{
		checked
		{
			if (dg.RowCount != 0)
			{
				float num = 0f;
				num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((float)(dg.Width - 4)) : ((float)(dg.Width - 20)));
				dg.Columns[0].Width = (int)Math.Round(num * 3f / 5f);
				dg.Columns[1].Width = (int)Math.Round(num * 2f / 5f);
				dg.Columns[2].Width = 0;
				dg.Columns[2].Visible = true;
			}
		}
	}

	private void KyWCEvrDNt(object P_0, EventArgs P_1)
	{
		if (!CKNome.Checked)
		{
			TBNome.Enabled = false;
			rbPagina.Checked = true;
		}
		else
		{
			TBNome.Enabled = true;
		}
	}

	private void vAfCZoC30H(object P_0, EventArgs P_1)
	{
		if (!CKRev.Checked)
		{
			TBTracoRev.Enabled = false;
		}
		else
		{
			TBTracoRev.Enabled = true;
		}
	}

	private void cnACiRWEit(object P_0, EventArgs P_1)
	{
		WxuCuQiS3h();
	}

	private void Cj5CSSUSJY(object P_0, EventArgs P_1)
	{
		CarregaPG();
	}
}
