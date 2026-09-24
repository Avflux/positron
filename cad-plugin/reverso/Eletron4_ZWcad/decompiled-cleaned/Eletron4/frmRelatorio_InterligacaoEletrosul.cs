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
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmRelatorio_InterligacaoEletrosul : Form
{
	private IContainer hit7vuOurS;

	[AccessedThroughProperty("dgRevisao")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView sFY76a4Jt2;

	[AccessedThroughProperty("dgEquip")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView g6V7tompPc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgInterlig")]
	private DataGridView YBL7jPKfho;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btPesquisar")]
	private Button qPJ7LIrF4J;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExportaEXCEL")]
	[CompilerGenerated]
	private Button yBG7wUj8SC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip roY7xjE0Nm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbFuncao")]
	private CheckBox qdX7bX39Cb;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbDocumento")]
	private CheckBox pIO7MCVNnY;

	[CompilerGenerated]
	[AccessedThroughProperty("tbLinhas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox tfQ7OmDpCZ;

	[AccessedThroughProperty("Label1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label pvt7IoOAN5;

	[AccessedThroughProperty("GroupBox1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox dKC776cc21;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("rbTexto")]
	private RadioButton w047qowIB3;

	[AccessedThroughProperty("rbGrafico")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton MkZ7arwdPh;

	[AccessedThroughProperty("GroupBox2")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox pWH781Kw5a;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbCadastro")]
	[CompilerGenerated]
	private RadioButton YNr7NCp9Ha;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbCrescente")]
	[CompilerGenerated]
	private RadioButton RRs7FR4RSC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgRegua")]
	private DataGridView kcw7QSx45Z;

	[AccessedThroughProperty("cbVeiasReserva")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox YL47PSo8Mq;

	[AccessedThroughProperty("cbVazio")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox ack7ccJvYj;

	[CompilerGenerated]
	[AccessedThroughProperty("tbOpcional")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox cP97Kbe7aX;

	[CompilerGenerated]
	[AccessedThroughProperty("cbAlterarOrdem")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox XPw7eoOFYF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ProgressBar1")]
	private ProgressBar gQo72uSH85;

	[CompilerGenerated]
	[AccessedThroughProperty("tbPesquisa")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox HAu73iauOw;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbFormacao")]
	[CompilerGenerated]
	private CheckBox Ucy7nBVK5M;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbTrajeto")]
	[CompilerGenerated]
	private CheckBox Eu0715RFUY;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GBOpcionais")]
	private GroupBox DNg7lQ1QsX;

	private DeclaracoesFiacao.structurePnRev[] vnc75VlqqW;

	private DeclaracoesFiacao.structureRevisoes[] aOH70W7Un4;

	private DeclaracoesInterligacao.structureRI[] kMQ7Rp8xwf;

	private DeclaracoesInterligacao.reservaRI[] hHK7mOiwor;

	private DeclaracoesInterligacao.reservaRI[] F5E7XKZp7b;

	private string prx7U2RPRN;

	private int upw7y9mTPm;

	private bool ncX7gM2i0Z;

	private bool cfe7AiIusf;

	private int URe7sHSMmb;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return sFY76a4Jt2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = wVIIYeBTPO;
			DataGridView dataGridView = sFY76a4Jt2;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			sFY76a4Jt2 = value;
			dataGridView = sFY76a4Jt2;
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
			return g6V7tompPc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = loDIzC6brU;
			DataGridView dataGridView = g6V7tompPc;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			g6V7tompPc = value;
			dataGridView = g6V7tompPc;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgInterlig
	{
		[CompilerGenerated]
		get
		{
			return YBL7jPKfho;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			YBL7jPKfho = value;
		}
	}

	internal virtual Button btPesquisar
	{
		[CompilerGenerated]
		get
		{
			return qPJ7LIrF4J;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = vuW7pK91NJ;
			Button button = qPJ7LIrF4J;
			if (button != null)
			{
				button.Click -= value2;
			}
			qPJ7LIrF4J = value;
			button = qPJ7LIrF4J;
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
			return yBG7wUj8SC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = asc7JM3rOq;
			Button button = yBG7wUj8SC;
			if (button != null)
			{
				button.Click -= value2;
			}
			yBG7wUj8SC = value;
			button = yBG7wUj8SC;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox cbFuncao
	{
		[CompilerGenerated]
		get
		{
			return qdX7bX39Cb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qdX7bX39Cb = value;
		}
	}

	internal virtual CheckBox cbDocumento
	{
		[CompilerGenerated]
		get
		{
			return pIO7MCVNnY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pIO7MCVNnY = value;
		}
	}

	internal virtual TextBox tbLinhas
	{
		[CompilerGenerated]
		get
		{
			return tfQ7OmDpCZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = EV17dC5BCZ;
			TextBox textBox = tfQ7OmDpCZ;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			tfQ7OmDpCZ = value;
			textBox = tfQ7OmDpCZ;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return pvt7IoOAN5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pvt7IoOAN5 = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return dKC776cc21;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dKC776cc21 = value;
		}
	}

	internal virtual RadioButton rbTexto
	{
		[CompilerGenerated]
		get
		{
			return w047qowIB3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			w047qowIB3 = value;
		}
	}

	internal virtual RadioButton rbGrafico
	{
		[CompilerGenerated]
		get
		{
			return MkZ7arwdPh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MkZ7arwdPh = value;
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return pWH781Kw5a;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pWH781Kw5a = value;
		}
	}

	internal virtual RadioButton rbCadastro
	{
		[CompilerGenerated]
		get
		{
			return YNr7NCp9Ha;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			YNr7NCp9Ha = value;
		}
	}

	internal virtual RadioButton rbCrescente
	{
		[CompilerGenerated]
		get
		{
			return RRs7FR4RSC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			RRs7FR4RSC = value;
		}
	}

	internal virtual DataGridView dgRegua
	{
		[CompilerGenerated]
		get
		{
			return kcw7QSx45Z;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = TBy7hbJCTE;
			DragEventHandler value3 = Aad7odQ0JW;
			DragEventHandler value4 = aJS7G5ZtAM;
			DataGridView dataGridView = kcw7QSx45Z;
			if (dataGridView != null)
			{
				dataGridView.MouseDown -= value2;
				dataGridView.DragDrop -= value3;
				dataGridView.DragEnter -= value4;
			}
			kcw7QSx45Z = value;
			dataGridView = kcw7QSx45Z;
			if (dataGridView != null)
			{
				dataGridView.MouseDown += value2;
				dataGridView.DragDrop += value3;
				dataGridView.DragEnter += value4;
			}
		}
	}

	internal virtual CheckBox cbVeiasReserva
	{
		[CompilerGenerated]
		get
		{
			return YL47PSo8Mq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			YL47PSo8Mq = value;
		}
	}

	internal virtual CheckBox cbVazio
	{
		[CompilerGenerated]
		get
		{
			return ack7ccJvYj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = bKP7fECgav;
			CheckBox checkBox = ack7ccJvYj;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			ack7ccJvYj = value;
			checkBox = ack7ccJvYj;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual TextBox tbOpcional
	{
		[CompilerGenerated]
		get
		{
			return cP97Kbe7aX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			cP97Kbe7aX = value;
		}
	}

	internal virtual CheckBox cbAlterarOrdem
	{
		[CompilerGenerated]
		get
		{
			return XPw7eoOFYF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = dSV7HoVmFJ;
			CheckBox checkBox = XPw7eoOFYF;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			XPw7eoOFYF = value;
			checkBox = XPw7eoOFYF;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual ProgressBar ProgressBar1
	{
		[CompilerGenerated]
		get
		{
			return gQo72uSH85;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			gQo72uSH85 = value;
		}
	}

	internal virtual TextBox tbPesquisa
	{
		[CompilerGenerated]
		get
		{
			return HAu73iauOw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = yngIrLOv50;
			TextBox textBox = HAu73iauOw;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			HAu73iauOw = value;
			textBox = HAu73iauOw;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual CheckBox cbFormacao
	{
		[CompilerGenerated]
		get
		{
			return Ucy7nBVK5M;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Ucy7nBVK5M = value;
		}
	}

	internal virtual CheckBox cbTrajeto
	{
		[CompilerGenerated]
		get
		{
			return Eu0715RFUY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Eu0715RFUY = value;
		}
	}

	internal virtual GroupBox GBOpcionais
	{
		[CompilerGenerated]
		get
		{
			return DNg7lQ1QsX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DNg7lQ1QsX = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && hit7vuOurS != null)
			{
				hit7vuOurS.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ohbI4H9Ccy()
	{
		hit7vuOurS = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		dgRevisao = new DataGridView();
		dgEquip = new DataGridView();
		dgInterlig = new DataGridView();
		btPesquisar = new Button();
		btExportaEXCEL = new Button();
		FDqpBiUmZij(new ToolTip(hit7vuOurS));
		cbFuncao = new CheckBox();
		cbDocumento = new CheckBox();
		tbLinhas = new TextBox();
		Label1 = new Label();
		GroupBox1 = new GroupBox();
		rbTexto = new RadioButton();
		rbGrafico = new RadioButton();
		GroupBox2 = new GroupBox();
		rbCadastro = new RadioButton();
		rbCrescente = new RadioButton();
		dgRegua = new DataGridView();
		cbVeiasReserva = new CheckBox();
		cbVazio = new CheckBox();
		tbOpcional = new TextBox();
		cbAlterarOrdem = new CheckBox();
		ProgressBar1 = new ProgressBar();
		tbPesquisa = new TextBox();
		cbFormacao = new CheckBox();
		cbTrajeto = new CheckBox();
		GBOpcionais = new GroupBox();
		((ISupportInitialize)dgRevisao).BeginInit();
		((ISupportInitialize)dgEquip).BeginInit();
		((ISupportInitialize)dgInterlig).BeginInit();
		GroupBox1.SuspendLayout();
		GroupBox2.SuspendLayout();
		((ISupportInitialize)dgRegua).BeginInit();
		GBOpcionais.SuspendLayout();
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
		dgRevisao.Size = new Size(336, 133);
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
		dgEquip.Location = new Point(12, 177);
		dgEquip.MultiSelect = false;
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(155, 313);
		dgEquip.TabIndex = 8;
		dgInterlig.AllowUserToAddRows = false;
		dgInterlig.AllowUserToDeleteRows = false;
		dgInterlig.AllowUserToResizeRows = false;
		dgInterlig.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgInterlig.BackgroundColor = Color.White;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		dgInterlig.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		dgInterlig.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgInterlig.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgInterlig.Location = new Point(354, 12);
		dgInterlig.MultiSelect = false;
		dgInterlig.Name = "dgInterlig";
		dgInterlig.ReadOnly = true;
		dgInterlig.RowHeadersVisible = false;
		dgInterlig.SelectionMode = DataGridViewSelectionMode.CellSelect;
		dgInterlig.Size = new Size(653, 637);
		dgInterlig.TabIndex = 11;
		btPesquisar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisar.FlatStyle = FlatStyle.Flat;
		btPesquisar.ForeColor = SystemColors.Control;
		btPesquisar.Image = Resources.Pesquisar_32;
		btPesquisar.Location = new Point(204, 607);
		btPesquisar.Name = "btPesquisar";
		btPesquisar.Size = new Size(40, 42);
		btPesquisar.TabIndex = 15;
		btPesquisar.UseVisualStyleBackColor = true;
		btExportaEXCEL.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btExportaEXCEL.FlatStyle = FlatStyle.Flat;
		btExportaEXCEL.ForeColor = SystemColors.Control;
		btExportaEXCEL.Image = Resources.ExportaExcel_20;
		btExportaEXCEL.Location = new Point(280, 606);
		btExportaEXCEL.Name = "btExportaEXCEL";
		btExportaEXCEL.Size = new Size(40, 43);
		btExportaEXCEL.TabIndex = 41;
		btExportaEXCEL.UseVisualStyleBackColor = true;
		cbFuncao.AutoSize = true;
		cbFuncao.Location = new Point(6, 63);
		cbFuncao.Name = "cbFuncao";
		cbFuncao.Size = new Size(74, 17);
		cbFuncao.TabIndex = 42;
		cbFuncao.Text = "cbFuncao";
		cbFuncao.UseVisualStyleBackColor = true;
		cbDocumento.AutoSize = true;
		cbDocumento.Location = new Point(6, 41);
		cbDocumento.Name = "cbDocumento";
		cbDocumento.Size = new Size(93, 17);
		cbDocumento.TabIndex = 43;
		cbDocumento.Text = "cbDocumento";
		cbDocumento.UseVisualStyleBackColor = true;
		tbLinhas.Location = new Point(105, 166);
		tbLinhas.Name = "tbLinhas";
		tbLinhas.Size = new Size(60, 20);
		tbLinhas.TabIndex = 44;
		Label1.AutoSize = true;
		Label1.Location = new Point(3, 169);
		Label1.Name = "Label1";
		Label1.Size = new Size(76, 13);
		Label1.TabIndex = 45;
		Label1.Text = "Linhas/Página";
		GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox1.Controls.Add(rbTexto);
		GroupBox1.Controls.Add(rbGrafico);
		GroupBox1.Location = new Point(12, 581);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(152, 68);
		GroupBox1.TabIndex = 46;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "Jumper Externo";
		rbTexto.AutoSize = true;
		rbTexto.Location = new Point(14, 45);
		rbTexto.Name = "rbTexto";
		rbTexto.Size = new Size(61, 17);
		rbTexto.TabIndex = 3;
		rbTexto.TabStop = true;
		rbTexto.Text = "rbTexto";
		rbTexto.UseVisualStyleBackColor = true;
		rbGrafico.AutoSize = true;
		rbGrafico.Location = new Point(14, 22);
		rbGrafico.Name = "rbGrafico";
		rbGrafico.Size = new Size(68, 17);
		rbGrafico.TabIndex = 2;
		rbGrafico.TabStop = true;
		rbGrafico.Text = "rbGrafico";
		rbGrafico.UseVisualStyleBackColor = true;
		GroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox2.Controls.Add(rbCadastro);
		GroupBox2.Controls.Add(rbCrescente);
		GroupBox2.Location = new Point(12, 499);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(152, 76);
		GroupBox2.TabIndex = 47;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "Ordem Bornes Máscara";
		rbCadastro.AutoSize = true;
		rbCadastro.Location = new Point(14, 46);
		rbCadastro.Name = "rbCadastro";
		rbCadastro.Size = new Size(76, 17);
		rbCadastro.TabIndex = 1;
		rbCadastro.TabStop = true;
		rbCadastro.Text = "rbCadastro";
		rbCadastro.UseVisualStyleBackColor = true;
		rbCrescente.AutoSize = true;
		rbCrescente.Location = new Point(14, 22);
		rbCrescente.Name = "rbCrescente";
		rbCrescente.Size = new Size(82, 17);
		rbCrescente.TabIndex = 0;
		rbCrescente.TabStop = true;
		rbCrescente.Text = "rbCrescente";
		rbCrescente.UseVisualStyleBackColor = true;
		dgRegua.AllowUserToAddRows = false;
		dgRegua.AllowUserToDeleteRows = false;
		dgRegua.AllowUserToOrderColumns = true;
		dgRegua.AllowUserToResizeRows = false;
		dgRegua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgRegua.BackgroundColor = Color.White;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = SystemColors.Control;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		dgRegua.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		dgRegua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgRegua.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgRegua.Location = new Point(173, 177);
		dgRegua.Name = "dgRegua";
		dgRegua.ReadOnly = true;
		dgRegua.RowHeadersVisible = false;
		dgRegua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRegua.Size = new Size(175, 208);
		dgRegua.TabIndex = 48;
		cbVeiasReserva.AutoSize = true;
		cbVeiasReserva.Location = new Point(6, 145);
		cbVeiasReserva.Name = "cbVeiasReserva";
		cbVeiasReserva.Size = new Size(104, 17);
		cbVeiasReserva.TabIndex = 49;
		cbVeiasReserva.Text = "cbVeiasReserva";
		cbVeiasReserva.UseVisualStyleBackColor = true;
		cbVazio.AutoSize = true;
		cbVazio.Location = new Point(6, 107);
		cbVazio.Name = "cbVazio";
		cbVazio.Size = new Size(64, 17);
		cbVazio.TabIndex = 51;
		cbVazio.Text = "cbVazio";
		cbVazio.UseVisualStyleBackColor = true;
		tbOpcional.Location = new Point(105, 103);
		tbOpcional.Name = "tbOpcional";
		tbOpcional.Size = new Size(60, 20);
		tbOpcional.TabIndex = 50;
		cbAlterarOrdem.AutoSize = true;
		cbAlterarOrdem.Location = new Point(173, 153);
		cbAlterarOrdem.Name = "cbAlterarOrdem";
		cbAlterarOrdem.Size = new Size(90, 17);
		cbAlterarOrdem.TabIndex = 52;
		cbAlterarOrdem.Text = "Alterar Ordem";
		cbAlterarOrdem.UseVisualStyleBackColor = true;
		ProgressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		ProgressBar1.Location = new Point(173, 388);
		ProgressBar1.Name = "ProgressBar1";
		ProgressBar1.Size = new Size(175, 12);
		ProgressBar1.TabIndex = 61;
		tbPesquisa.Location = new Point(12, 151);
		tbPesquisa.Name = "tbPesquisa";
		tbPesquisa.Size = new Size(155, 20);
		tbPesquisa.TabIndex = 63;
		cbFormacao.AutoSize = true;
		cbFormacao.Location = new Point(6, 19);
		cbFormacao.Name = "cbFormacao";
		cbFormacao.Size = new Size(85, 17);
		cbFormacao.TabIndex = 64;
		cbFormacao.Text = "cbFormação";
		cbFormacao.UseVisualStyleBackColor = true;
		cbTrajeto.AutoSize = true;
		cbTrajeto.Location = new Point(6, 85);
		cbTrajeto.Name = "cbTrajeto";
		cbTrajeto.Size = new Size(71, 17);
		cbTrajeto.TabIndex = 65;
		cbTrajeto.Text = "cbTrajeto";
		cbTrajeto.UseVisualStyleBackColor = true;
		GBOpcionais.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GBOpcionais.Controls.Add(cbFormacao);
		GBOpcionais.Controls.Add(cbTrajeto);
		GBOpcionais.Controls.Add(cbFuncao);
		GBOpcionais.Controls.Add(cbDocumento);
		GBOpcionais.Controls.Add(tbLinhas);
		GBOpcionais.Controls.Add(Label1);
		GBOpcionais.Controls.Add(cbVeiasReserva);
		GBOpcionais.Controls.Add(tbOpcional);
		GBOpcionais.Controls.Add(cbVazio);
		GBOpcionais.Location = new Point(173, 407);
		GBOpcionais.Name = "GBOpcionais";
		GBOpcionais.Size = new Size(175, 195);
		GBOpcionais.TabIndex = 66;
		GBOpcionais.TabStop = false;
		GBOpcionais.Text = "GroupBox3";
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(1019, 661);
		Controls.Add(GBOpcionais);
		Controls.Add(btExportaEXCEL);
		Controls.Add(btPesquisar);
		Controls.Add(tbPesquisa);
		Controls.Add(ProgressBar1);
		Controls.Add(cbAlterarOrdem);
		Controls.Add(dgRegua);
		Controls.Add(GroupBox2);
		Controls.Add(GroupBox1);
		Controls.Add(dgInterlig);
		Controls.Add(dgEquip);
		Controls.Add(dgRevisao);
		MinimumSize = new Size(1035, 550);
		Name = "frmRelatorio_InterligacaoEletrosul";
		ShowInTaskbar = false;
		Text = "Relatório de Interligação";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		((ISupportInitialize)dgInterlig).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		((ISupportInitialize)dgRegua).EndInit();
		GBOpcionais.ResumeLayout(performLayout: false);
		GBOpcionais.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return roY7xjE0Nm;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		roY7xjE0Nm = WithEventsValue;
	}

	public frmRelatorio_InterligacaoEletrosul()
	{
		Resize += lKN7kLvBbN;
		vnc75VlqqW = new DeclaracoesFiacao.structurePnRev[1];
		aOH70W7Un4 = new DeclaracoesFiacao.structureRevisoes[1];
		prx7U2RPRN = "";
		upw7y9mTPm = 0;
		ncX7gM2i0Z = false;
		cfe7AiIusf = false;
		URe7sHSMmb = 0;
		try
		{
			if (!Geral.ExisteForm("frmRelatorio_InterligacaoEletrosul"))
			{
				ohbI4H9Ccy();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1416]);
				w8dpBZ0kvSD().SetToolTip(btPesquisar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1411]));
				cbFormacao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1285]);
				cbFuncao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1244]);
				cbVeiasReserva.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1434]);
				cbVazio.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1841]);
				cbTrajeto.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1248]);
				cbAlterarOrdem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1326]);
				GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1418]);
				GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1419]);
				GBOpcionais.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1322]);
				rbCrescente.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1420]);
				rbCadastro.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1421]);
				rbGrafico.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1422]);
				rbTexto.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1423]);
				Label1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1424]);
				cDadosAccess.carregaDadosDWG();
				Application.ShowModelessDialog((Form)this);
				kMQ7Rp8xwf = new DeclaracoesInterligacao.structureRI[1];
				kMQ7Rp8xwf[0].Bornes = new DeclaracoesInterligacao.borneRI[1];
				hHK7mOiwor = new DeclaracoesInterligacao.reservaRI[1];
				F5E7XKZp7b = new DeclaracoesInterligacao.reservaRI[1];
				formataDGRevisao();
				formataDGEquip();
				formataDGInterlig();
				AtualizaDGInterlig();
				cbFormacao.Checked = false;
				cbDocumento.Checked = true;
				cbFuncao.Checked = true;
				cbVeiasReserva.Checked = true;
				cbTrajeto.Checked = false;
				rbCrescente.Checked = true;
				rbGrafico.Checked = true;
				tbLinhas.Text = "58";
				cbVazio.Checked = true;
				cbVazio.Checked = false;
				cbAlterarOrdem.Checked = false;
				dgRegua.MultiSelect = true;
				dgRegua.AllowDrop = false;
				zx4ICrqQ7P();
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

	private void zx4ICrqQ7P()
	{
		aOH70W7Un4 = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			cDadosAccessInterligacao3.CarregaRevisoesCabos4(ref aOH70W7Un4);
			ncX7gM2i0Z = true;
			dgRevisao.Rows.Clear();
			ncX7gM2i0Z = false;
			int num = Information.UBound(aOH70W7Un4);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				dgRevisao.Rows.Add(aOH70W7Un4[i].revisao, aOH70W7Un4[i].criador, aOH70W7Un4[i].data);
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

	private void wVIIYeBTPO(object P_0, EventArgs P_1)
	{
		cfe7AiIusf = true;
		dgEquip.Rows.Clear();
		cfe7AiIusf = false;
		if (!ncX7gM2i0Z)
		{
			QtOI9ehBFa(_0020: false);
		}
	}

	private void yngIrLOv50(object P_0, KeyEventArgs P_1)
	{
		if (((P_1.KeyValue == 13) | (Operators.CompareString(tbPesquisa.Text.Trim(), "", TextCompare: true) == 0)) && !ncX7gM2i0Z)
		{
			QtOI9ehBFa(_0020: true);
		}
	}

	private void QtOI9ehBFa(bool P_0)
	{
		if (!P_0)
		{
			tbPesquisa.Text = "";
		}
		CarregaPnRev();
		try
		{
			if (dgRevisao.SelectedRows.Count != 1)
			{
				return;
			}
			prx7U2RPRN = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
			cfe7AiIusf = true;
			dgEquip.Rows.Clear();
			cfe7AiIusf = false;
			int num = Information.UBound(vnc75VlqqW);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(vnc75VlqqW[i].revisao, prx7U2RPRN, TextCompare: true) == 0)
				{
					string text = Dicionario.BuscaNomeDoPainel(vnc75VlqqW[i].painel);
					if (!P_0)
					{
						dgEquip.Rows.Add(vnc75VlqqW[i].painel, text);
					}
					else if (text.ToUpper().Contains(tbPesquisa.Text.ToUpper().Trim()))
					{
						dgEquip.Rows.Add(vnc75VlqqW[i].painel, text);
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
		vnc75VlqqW = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			if (Information.UBound(aOH70W7Un4) > 0)
			{
				int num = Information.UBound(aOH70W7Un4);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessInterligacao3.CarregaPnRev(aOH70W7Un4[i].revisao, ref vnc75VlqqW);
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

	private void loDIzC6brU(object P_0, EventArgs P_1)
	{
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			if (dgEquip.SelectedRows.Count == 1)
			{
				upw7y9mTPm = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
				kMQ7Rp8xwf = new DeclaracoesInterligacao.structureRI[1];
				kMQ7Rp8xwf[0].Bornes = new DeclaracoesInterligacao.borneRI[1];
				cDadosAccessInterligacao3.CarregaReguas(prx7U2RPRN, upw7y9mTPm, ref kMQ7Rp8xwf);
				cDadosAccessInterligacao3.CarregaReguasPortas(prx7U2RPRN, upw7y9mTPm, ref kMQ7Rp8xwf);
				formataDGRegua();
				BJ37WFrIUt();
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

	private void BJ37WFrIUt()
	{
		if (Information.UBound(kMQ7Rp8xwf) == 0)
		{
			return;
		}
		bool flag = false;
		checked
		{
			try
			{
				int num = Information.UBound(kMQ7Rp8xwf);
				for (int i = 1; i <= num; i++)
				{
					dgRegua.Rows.Add(kMQ7Rp8xwf[i].Tipo, kMQ7Rp8xwf[i].Tag, kMQ7Rp8xwf[i].NRegua, i);
					Color backColor = ((!flag) ? Color.White : Color.LightGray);
					flag = !flag;
					int num2 = dgRegua.ColumnCount - 1;
					for (int j = 0; j <= num2; j++)
					{
						dgRegua.Rows[dgRegua.Rows.Count - 1].Cells[j].Style.BackColor = backColor;
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

	private void vuW7pK91NJ(object P_0, EventArgs P_1)
	{
		if (cbVazio.Checked & (Operators.CompareString(tbOpcional.Text.Trim(), "", TextCompare: true) == 0))
		{
			cbVazio.Checked = false;
		}
		List<int> list = new List<int>();
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		checked
		{
			try
			{
				formataDGInterlig();
				AtualizaDGInterlig();
				if (dgEquip.SelectedRows.Count == 0)
				{
					return;
				}
				upw7y9mTPm = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
				cDadosAccessInterligacao3.CarregaBornesReguas(prx7U2RPRN, upw7y9mTPm, ref kMQ7Rp8xwf, rbCadastro.Checked);
				ProgressBar1.Minimum = 0;
				ProgressBar1.Maximum = frH7TkHCXo() * 2;
				ProgressBar1.Value = 0;
				ProgressBar1.Step = 1;
				string revisao = prx7U2RPRN;
				int painel = upw7y9mTPm;
				ref DeclaracoesInterligacao.structureRI[] mReguas = ref kMQ7Rp8xwf;
				ProgressBar ProgressBar = ProgressBar1;
				cDadosAccessInterligacao3.CarregaCabosNosBornesRI(revisao, painel, ref mReguas, ref ProgressBar, -1);
				ProgressBar1 = ProgressBar;
				string revisao2 = prx7U2RPRN;
				int painel2 = upw7y9mTPm;
				ref DeclaracoesInterligacao.structureRI[] mReguas2 = ref kMQ7Rp8xwf;
				ProgressBar = ProgressBar1;
				cDadosAccessInterligacao3.CarregaJumpersNosBornesRI(revisao2, painel2, ref mReguas2, ref ProgressBar);
				ProgressBar1 = ProgressBar;
				if (cbVeiasReserva.Checked)
				{
					hHK7mOiwor = new DeclaracoesInterligacao.reservaRI[1];
					F5E7XKZp7b = new DeclaracoesInterligacao.reservaRI[1];
					cDadosAccessInterligacao3.CarregaVeiasReserva(prx7U2RPRN, upw7y9mTPm, ref hHK7mOiwor, ref F5E7XKZp7b, bELS: true);
				}
				string right = "][";
				int num = dgRegua.RowCount - 1;
				for (int i = 0; i <= num; i++)
				{
					if (!dgRegua.Rows[i].Selected)
					{
						continue;
					}
					int num2 = Conversions.ToInteger(dgRegua.Rows[i].Cells[3].Value);
					string tipo = kMQ7Rp8xwf[num2].Tipo;
					string text = "";
					if (Operators.CompareString(tipo, "B", TextCompare: true) != 0)
					{
						if (Operators.CompareString(tipo, "E", TextCompare: true) == 0)
						{
							text = kMQ7Rp8xwf[num2].NRegua;
						}
					}
					else
					{
						text = kMQ7Rp8xwf[num2].Tag;
					}
					if (Operators.CompareString(text, right, TextCompare: true) != 0)
					{
						if (dgInterlig.Rows.Count > 0)
						{
							dgInterlig.Rows.Add("", "", "", "", "", "", "", "", "", 0);
						}
						dgInterlig.Rows.Add(text, "", "", "", "", "", "", "", "", 0);
						dgInterlig.Rows[dgInterlig.Rows.Count - 1].Cells[0].Style.Font = new Font("Arial", 10f, FontStyle.Bold);
						int num3 = dgInterlig.ColumnCount - 1;
						for (int j = 0; j <= num3; j++)
						{
							dgInterlig.Rows[dgInterlig.Rows.Count - 1].Cells[j].Style.BackColor = Color.LightGray;
						}
					}
					string right2 = "";
					right = text;
					if (Information.IsNothing(kMQ7Rp8xwf[num2].Bornes))
					{
						if (!list.Contains(kMQ7Rp8xwf[num2].DWG))
						{
							list.Add(kMQ7Rp8xwf[num2].DWG);
						}
						continue;
					}
					int num4 = Information.UBound(kMQ7Rp8xwf[num2].Bornes);
					for (int k = 1; k <= num4; k++)
					{
						string borne = kMQ7Rp8xwf[num2].Bornes[k].Borne;
						int tipoBorne = kMQ7Rp8xwf[num2].Bornes[k].TipoBorne;
						string text2 = "";
						string text3 = "";
						string text4 = "";
						string text5 = "";
						string text6 = "";
						string text7 = "";
						string text8 = "";
						string text9 = "";
						string text10 = "";
						string text11 = "";
						if (!((Information.UBound(kMQ7Rp8xwf[num2].Bornes[k].cabos) == 0) & (Information.UBound(kMQ7Rp8xwf[num2].Bornes[k].jumpers) == 0)))
						{
							if (Information.UBound(kMQ7Rp8xwf[num2].Bornes[k].cabos) > 0)
							{
								int num5 = Information.UBound(kMQ7Rp8xwf[num2].Bornes[k].cabos);
								for (int l = 1; l <= num5; l++)
								{
									text3 = (kMQ7Rp8xwf[num2].Bornes[k].cabos[l].Blindagem ? ("(" + kMQ7Rp8xwf[num2].Bornes[k].cabos[l].Formacao + ")") : kMQ7Rp8xwf[num2].Bornes[k].cabos[l].Formacao);
									if (Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].cabos[l].NomeVeia, "", TextCompare: true) != 0)
									{
										text2 = ((kMQ7Rp8xwf[num2].Bornes[k].cabos[l].Cabos > 1) ? kMQ7Rp8xwf[num2].Bornes[k].cabos[l].Tag_Cabo : (kMQ7Rp8xwf[num2].Bornes[k].cabos[l].Tag_Cabo + " (" + kMQ7Rp8xwf[num2].Bornes[k].cabos[l].NomeVeia + ")"));
									}
									else
									{
										text2 = ((text3.StartsWith("1x") | text3.StartsWith("1X")) ? kMQ7Rp8xwf[num2].Bornes[k].cabos[l].Tag_Cabo : (kMQ7Rp8xwf[num2].Bornes[k].cabos[l].Tag_Cabo + "-" + kMQ7Rp8xwf[num2].Bornes[k].cabos[l].Veia));
									}
									if (kMQ7Rp8xwf[num2].Bornes[k].cabos[l].Cabos > 1)
									{
										text3 = kMQ7Rp8xwf[num2].Bornes[k].cabos[l].Cabos + "x" + text3;
									}
									text5 = kMQ7Rp8xwf[num2].Bornes[k].cabos[l].sPainelDest;
									if (Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].cabos[l].NReguaDest, "", TextCompare: true) != 0)
									{
										text4 = ((Operators.CompareString(text5, kMQ7Rp8xwf[num2].Bornes[k].cabos[l].TagDest, TextCompare: true) != 0) ? (kMQ7Rp8xwf[num2].Bornes[k].cabos[l].TagDest + "/" + kMQ7Rp8xwf[num2].Bornes[k].cabos[l].NReguaDest) : kMQ7Rp8xwf[num2].Bornes[k].cabos[l].NReguaDest);
									}
									else
									{
										text4 = kMQ7Rp8xwf[num2].Bornes[k].cabos[l].TagDest;
									}
									text6 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
									if (Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].cabos[l].BorneDest, "0", TextCompare: true) != 0)
									{
										text6 = kMQ7Rp8xwf[num2].Bornes[k].cabos[l].BorneDest;
									}
									text7 = kMQ7Rp8xwf[num2].Bornes[k].cabos[l].Funcao;
									text8 = kMQ7Rp8xwf[num2].Bornes[k].cabos[l].DocOrigem + "/" + kMQ7Rp8xwf[num2].Bornes[k].cabos[l].PaginaOrigem;
									if (kMQ7Rp8xwf[num2].Bornes[k].cabos[l].Veia > 0)
									{
										text9 = kMQ7Rp8xwf[num2].Bornes[k].cabos[l].DocDest + "/" + kMQ7Rp8xwf[num2].Bornes[k].cabos[l].PaginaDest;
									}
									if (!((Operators.CompareString(text8, text9, TextCompare: true) == 0) | (Operators.CompareString(text9, "", TextCompare: true) == 0)))
									{
										if ((Operators.CompareString(text8, text9, TextCompare: true) != 0) & (Operators.CompareString(text9, "", TextCompare: true) != 0))
										{
											text10 = text8 + ", " + text9;
										}
									}
									else
									{
										text10 = text8;
									}
									if (((Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].cabos[l].DocOrigem, "", TextCompare: true) != 0) & (Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].cabos[l].DocDest, "", TextCompare: true) != 0)) && Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].cabos[l].DocOrigem, kMQ7Rp8xwf[num2].Bornes[k].cabos[l].DocDest, TextCompare: true) == 0 && Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].cabos[l].PaginaOrigem, kMQ7Rp8xwf[num2].Bornes[k].cabos[l].PaginaDest, TextCompare: true) != 0)
									{
										text10 = text8 + ", " + kMQ7Rp8xwf[num2].Bornes[k].cabos[l].PaginaDest;
									}
									text11 = kMQ7Rp8xwf[num2].Bornes[k].cabos[l].Trajetos;
									dgInterlig.Rows.Add(borne, "", text2, text3, text5, text4, text6, text10, text7, tipoBorne, text11, "");
									if (Operators.CompareString(borne, right2, TextCompare: true) == 0)
									{
										dgInterlig.Rows[dgInterlig.Rows.Count - 1].Cells[0].Style.ForeColor = Color.White;
									}
									right2 = borne;
								}
							}
							if (!rbTexto.Checked)
							{
								if (!rbGrafico.Checked)
								{
									continue;
								}
								int num6 = Information.UBound(kMQ7Rp8xwf[num2].Bornes[k].cabos);
								if (Information.UBound(kMQ7Rp8xwf[num2].Bornes[k].jumpers) <= 0)
								{
									continue;
								}
								string text12 = "";
								string text13 = "";
								string text14 = "";
								int num7 = Information.UBound(kMQ7Rp8xwf[num2].Bornes[k].jumpers);
								for (int m = 1; m <= num7; m++)
								{
									if (!((k == 1) & kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].bEntra))
									{
										if (!(kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].bEntra & (k > 1)))
										{
											if (!(kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].bSai & (k < Information.UBound(kMQ7Rp8xwf[num2].Bornes))))
											{
												if (kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].bSai & (k == Information.UBound(kMQ7Rp8xwf[num2].Bornes)))
												{
													num6++;
													text12 = ((Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].NRegua, "", TextCompare: true) != 0) ? kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].NRegua : kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].Tag);
													text13 = kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].Borne;
													text14 = kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].Pagina;
													dgInterlig.Rows.Add(borne, "", "JUMPER", "", "", text12, text13, text14, "", tipoBorne);
													if (Operators.CompareString(borne, right2, TextCompare: true) == 0)
													{
														dgInterlig.Rows[dgInterlig.Rows.Count - 1].Cells[0].Style.ForeColor = Color.White;
													}
													right2 = borne;
												}
											}
											else if (!((Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].Tag, kMQ7Rp8xwf[num2].Tag, TextCompare: true) == 0) & (Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].NRegua, kMQ7Rp8xwf[num2].NRegua, TextCompare: true) == 0) & (Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].Borne, kMQ7Rp8xwf[num2].Bornes[k + 1].Borne, TextCompare: true) == 0)))
											{
												num6++;
												text12 = ((Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].NRegua, "", TextCompare: true) != 0) ? kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].NRegua : kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].Tag);
												text13 = kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].Borne;
												text14 = kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].Pagina;
												dgInterlig.Rows.Add(borne, "", "JUMPER", "", "", text12, text13, text14, "", tipoBorne);
												if (Operators.CompareString(borne, right2, TextCompare: true) == 0)
												{
													dgInterlig.Rows[dgInterlig.Rows.Count - 1].Cells[0].Style.ForeColor = Color.White;
												}
												right2 = borne;
											}
										}
										else if (!((Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].Tag, kMQ7Rp8xwf[num2].Tag, TextCompare: true) == 0) & (Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].NRegua, kMQ7Rp8xwf[num2].NRegua, TextCompare: true) == 0) & (Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].Borne, kMQ7Rp8xwf[num2].Bornes[k - 1].Borne, TextCompare: true) == 0)))
										{
											num6++;
											text12 = ((Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].NRegua, "", TextCompare: true) != 0) ? kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].NRegua : kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].Tag);
											text13 = kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].Borne;
											text14 = kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].Pagina;
											dgInterlig.Rows.Add(borne, "", "JUMPER", "", "", text12, text13, text14, "", tipoBorne);
											if (Operators.CompareString(borne, right2, TextCompare: true) == 0)
											{
												dgInterlig.Rows[dgInterlig.Rows.Count - 1].Cells[0].Style.ForeColor = Color.White;
											}
											right2 = borne;
										}
									}
									else
									{
										num6++;
										text12 = ((Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].NRegua, "", TextCompare: true) != 0) ? kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].NRegua : kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].Tag);
										text13 = kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].Borne;
										text14 = kMQ7Rp8xwf[num2].Bornes[k].jumpers[m].Pagina;
										dgInterlig.Rows.Add(borne, "", "JUMPER", "", "", text12, text13, text14, "", tipoBorne);
										if (Operators.CompareString(borne, right2, TextCompare: true) == 0)
										{
											dgInterlig.Rows[dgInterlig.Rows.Count - 1].Cells[0].Style.ForeColor = Color.White;
										}
										right2 = borne;
									}
								}
								bool flag = false;
								bool flag2 = false;
								int num8 = Information.UBound(kMQ7Rp8xwf[num2].Bornes[k].jumpers);
								for (int n = 1; n <= num8; n++)
								{
									if (!(kMQ7Rp8xwf[num2].Bornes[k].jumpers[n].bEntra & (k > 1)))
									{
										if ((kMQ7Rp8xwf[num2].Bornes[k].jumpers[n].bSai & (k < Information.UBound(kMQ7Rp8xwf[num2].Bornes))) && ((Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].jumpers[n].Tag, kMQ7Rp8xwf[num2].Tag, TextCompare: true) == 0) & (Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].jumpers[n].NRegua, kMQ7Rp8xwf[num2].NRegua, TextCompare: true) == 0) & (Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].jumpers[n].Borne, kMQ7Rp8xwf[num2].Bornes[k + 1].Borne, TextCompare: true) == 0)))
										{
											flag2 = true;
										}
									}
									else if ((Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].jumpers[n].Tag, kMQ7Rp8xwf[num2].Tag, TextCompare: true) == 0) & (Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].jumpers[n].NRegua, kMQ7Rp8xwf[num2].NRegua, TextCompare: true) == 0) & (Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].jumpers[n].Borne, kMQ7Rp8xwf[num2].Bornes[k - 1].Borne, TextCompare: true) == 0))
									{
										flag = true;
									}
								}
								if (num6 == 0)
								{
									dgInterlig.Rows.Add(borne, "", "", "", "", "", "", "", "", tipoBorne);
									num6 = 1;
								}
								if (!(flag & !flag2))
								{
									if (!(!flag & flag2))
									{
										if (flag & flag2)
										{
											int num9 = num6 - 1;
											for (int num10 = 0; num10 <= num9; num10++)
											{
												dgInterlig.Rows[dgInterlig.Rows.Count - 1 - num10].Cells[1].Value = "║";
												dgInterlig.Rows[dgInterlig.Rows.Count - 1 - num10].Cells[1].Style.Font = new Font("Arial", 12f, FontStyle.Bold);
												dgInterlig.Rows[dgInterlig.Rows.Count - 1 - num10].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
											}
										}
									}
									else
									{
										dgInterlig.Rows[dgInterlig.Rows.Count - 1].Cells[1].Value = "╗";
										dgInterlig.Rows[dgInterlig.Rows.Count - 1].Cells[1].Style.Font = new Font("Arial", 12f, FontStyle.Bold);
										dgInterlig.Rows[dgInterlig.Rows.Count - 1].Cells[1].Style.Alignment = DataGridViewContentAlignment.BottomCenter;
									}
								}
								else
								{
									dgInterlig.Rows[dgInterlig.Rows.Count - 1 - (num6 - 1)].Cells[1].Value = "╝";
									dgInterlig.Rows[dgInterlig.Rows.Count - 1 - (num6 - 1)].Cells[1].Style.Font = new Font("Arial", 12f, FontStyle.Bold);
									dgInterlig.Rows[dgInterlig.Rows.Count - 1 - (num6 - 1)].Cells[1].Style.Alignment = DataGridViewContentAlignment.TopCenter;
								}
							}
							else
							{
								if (Information.UBound(kMQ7Rp8xwf[num2].Bornes[k].jumpers) <= 0)
								{
									continue;
								}
								string text15 = "";
								string text16 = "";
								string text17 = "";
								int num11 = Information.UBound(kMQ7Rp8xwf[num2].Bornes[k].jumpers);
								for (int num12 = 1; num12 <= num11; num12++)
								{
									text15 = ((Operators.CompareString(kMQ7Rp8xwf[num2].Bornes[k].jumpers[num12].NRegua, "", TextCompare: true) != 0) ? kMQ7Rp8xwf[num2].Bornes[k].jumpers[num12].NRegua : kMQ7Rp8xwf[num2].Bornes[k].jumpers[num12].Tag);
									text16 = kMQ7Rp8xwf[num2].Bornes[k].jumpers[num12].Borne;
									text17 = kMQ7Rp8xwf[num2].Bornes[k].jumpers[num12].Pagina;
									dgInterlig.Rows.Add(borne, "", "JUMPER", "", "", text15, text16, text17, "", tipoBorne);
									if (Operators.CompareString(borne, right2, TextCompare: true) == 0)
									{
										dgInterlig.Rows[dgInterlig.Rows.Count - 1].Cells[0].Style.ForeColor = Color.White;
									}
									right2 = borne;
								}
							}
						}
						else
						{
							dgInterlig.Rows.Add(borne, "", text2, text3, text5, text4, text6, text8, text7, tipoBorne, text11, "");
							if (Operators.CompareString(borne, right2, TextCompare: true) == 0)
							{
								dgInterlig.Rows[dgInterlig.Rows.Count - 1].Cells[0].Style.ForeColor = Color.White;
							}
							right2 = borne;
						}
					}
				}
				if (cbVeiasReserva.Checked)
				{
					if (Information.UBound(hHK7mOiwor) >= 2)
					{
						int num13 = Information.UBound(hHK7mOiwor);
						for (int num14 = 1; num14 <= num13; num14++)
						{
							int num15 = Information.UBound(hHK7mOiwor) - 1;
							int num16 = num14;
							for (int num17 = num15; num17 >= num16; num17 += -1)
							{
								if (Operators.CompareString(hHK7mOiwor[num17].Tag, hHK7mOiwor[num17 + 1].Tag, TextCompare: true) > 0)
								{
									DeclaracoesInterligacao.reservaRI reservaRI = hHK7mOiwor[num17 + 1];
									hHK7mOiwor[num17 + 1] = hHK7mOiwor[num17];
									hHK7mOiwor[num17] = reservaRI;
								}
							}
						}
					}
					dgInterlig.Rows.Add("", "", "", "", "", "", "", "", "", 0, "");
					if (!cbFormacao.Checked)
					{
						dgInterlig.Rows.Add("", "", DeclaracoesGeral.mMensagem[1, 1434].ToString().ToUpper(), "", DeclaracoesGeral.mMensagem[1, 1454], DeclaracoesGeral.mMensagem[1, 1455], "", "", "", 0, "");
					}
					else
					{
						dgInterlig.Rows.Add("", "", DeclaracoesGeral.mMensagem[1, 1434].ToString().ToUpper(), DeclaracoesGeral.mMensagem[1, 1454], DeclaracoesGeral.mMensagem[1, 1455], "", "", "", "", 0, "");
					}
					int num18 = dgInterlig.ColumnCount - 1;
					for (int num19 = 0; num19 <= num18; num19++)
					{
						dgInterlig.Rows[dgInterlig.Rows.Count - 1].Cells[num19].Style.Font = new Font("Arial", 9f, FontStyle.Bold);
						dgInterlig.Rows[dgInterlig.Rows.Count - 1].Cells[num19].Style.BackColor = Color.LightGreen;
					}
					int num20 = Information.UBound(hHK7mOiwor);
					for (int num21 = 1; num21 <= num20; num21++)
					{
						string text18 = montaVeias(hHK7mOiwor[num21].lveias);
						hHK7mOiwor[num21].Veias = text18;
						if (!cbFormacao.Checked)
						{
							dgInterlig.Rows.Add("", "", hHK7mOiwor[num21].Tag, "", text18, hHK7mOiwor[num21].sPainelDest, "", "", "", 0, "");
						}
						else
						{
							dgInterlig.Rows.Add("", "", hHK7mOiwor[num21].Tag, text18, hHK7mOiwor[num21].sPainelDest, "", "", "", "", 0, "");
						}
					}
				}
				AtualizaDGInterlig();
				string text19 = "";
				if (list.Count <= 0)
				{
					return;
				}
				foreach (KeyValuePair<int, string> item in DeclaracoesGeral.dicDWG)
				{
					if (list.Contains(item.Key))
					{
						text19 = ((Operators.CompareString(text19, "", TextCompare: true) == 0) ? item.Value : ("," + item.Value));
					}
				}
				if (list.Count != 1)
				{
					Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1981], "\r\n"), " "), text19), MsgBoxStyle.Information);
				}
				else
				{
					Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1980], "\r\n"), " "), text19), MsgBoxStyle.Information);
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
				ProgressBar1.Value = 0;
			}
		}
	}

	private int frH7TkHCXo()
	{
		int num = 0;
		int num2 = Information.UBound(kMQ7Rp8xwf);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				if (!Information.IsNothing(kMQ7Rp8xwf[i].Bornes))
				{
					num += kMQ7Rp8xwf[i].Bornes.Length - 1;
				}
			}
			return num;
		}
	}

	public string montaVeias(List<string> lista)
	{
		string text = "";
		checked
		{
			if (lista.Count != 0)
			{
				bool flag = true;
				bool flag2 = true;
				int num = 0;
				if (lista.Count > 2)
				{
					foreach (string listum in lista)
					{
						if (Versioned.IsNumeric(listum))
						{
							if (!flag2)
							{
								int num2 = Conversions.ToInteger(listum);
								num++;
								if (num2 != num)
								{
									flag = false;
									break;
								}
							}
							else
							{
								flag2 = false;
								num = Conversions.ToInteger(listum);
							}
							continue;
						}
						flag = false;
						break;
					}
				}
				else
				{
					flag = false;
				}
				if (flag)
				{
					return Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject(lista[0] + " ", DeclaracoesGeral.mMensagem[1, 1446]), " "), lista[lista.Count - 1]));
				}
				foreach (string listum2 in lista)
				{
					text = text + listum2 + ", ";
				}
				return text.Substring(0, text.Length - 2);
			}
			return "-";
		}
	}

	private void asc7JM3rOq(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.bPararRelatorio = false;
		if (dgInterlig.RowCount == 0)
		{
			return;
		}
		btExportaEXCEL.Enabled = false;
		int num = 0;
		Relatorios_InterligacaoExcelEletroSul.structureRelInterligacao[] array = new Relatorios_InterligacaoExcelEletroSul.structureRelInterligacao[1];
		checked
		{
			int num2 = dgInterlig.RowCount - 1;
			for (int i = 0; i <= num2 && !(dgInterlig.Rows[i].Cells[1].Style.BackColor == Color.LightGreen); i++)
			{
				string left = clsTextos.TiraNothing(Conversions.ToString(dgInterlig.Rows[i].Cells[0].Value));
				if (Operators.CompareString(left, "", TextCompare: true) != 0)
				{
					num++;
					array = (Relatorios_InterligacaoExcelEletroSul.structureRelInterligacao[])Utils.CopyArray(array, new Relatorios_InterligacaoExcelEletroSul.structureRelInterligacao[num + 1]);
					array[num].TagRegua = clsTextos.TiraNothing(dgInterlig.Rows[i].Cells[0].Value.ToString());
					array[num].Jumper = clsTextos.TiraNothing(Conversions.ToString(dgInterlig.Rows[i].Cells[1].Value));
					array[num].TagCabo_Veia = clsTextos.TiraNothing(Conversions.ToString(dgInterlig.Rows[i].Cells[2].Value));
					array[num].Formacao = clsTextos.TiraNothing(Conversions.ToString(dgInterlig.Rows[i].Cells[3].Value));
					array[num].Destino = clsTextos.TiraNothing(Conversions.ToString(dgInterlig.Rows[i].Cells[4].Value));
					array[num].Régua = clsTextos.TiraNothing(Conversions.ToString(dgInterlig.Rows[i].Cells[5].Value));
					array[num].Borne = clsTextos.TiraNothing(Conversions.ToString(dgInterlig.Rows[i].Cells[6].Value));
					array[num].Documento = clsTextos.TiraNothing(Conversions.ToString(dgInterlig.Rows[i].Cells[7].Value));
					array[num].Funcao = clsTextos.TiraNothing(Conversions.ToString(dgInterlig.Rows[i].Cells[8].Value));
					array[num].TipoBorne = Conversions.ToInteger(dgInterlig.Rows[i].Cells[9].Value);
					array[num].Trajeto = clsTextos.TiraNothing(Conversions.ToString(dgInterlig.Rows[i].Cells[10].Value));
					if (dgInterlig.Rows[i].Cells[1].Style.BackColor == Color.LightGray)
					{
						array[num].TipoBorne = -10;
					}
				}
			}
			if (dgInterlig.RowCount > 0)
			{
				new frmRelatorio_InterligacaoEletroSul_Excel(prx7U2RPRN, array, upw7y9mTPm, Conversions.ToString(Conversions.ToInteger(tbLinhas.Text)), cbFormacao.Checked, cbFuncao.Checked, cbDocumento.Checked, tbOpcional.Text, cbVazio.Checked, cbTrajeto.Checked, cbVeiasReserva.Checked, hHK7mOiwor, F5E7XKZp7b);
			}
			btExportaEXCEL.Enabled = true;
		}
	}

	private void TBy7hbJCTE(object P_0, MouseEventArgs P_1)
	{
		if (dgRegua.AllowDrop)
		{
			DataGridView.HitTestInfo hitTestInfo = dgRegua.HitTest(P_1.X, P_1.Y);
			if (hitTestInfo.RowIndex >= 0)
			{
				DataGridViewRow data = dgRegua.Rows[hitTestInfo.RowIndex];
				URe7sHSMmb = hitTestInfo.RowIndex;
				dgRegua.Rows[URe7sHSMmb].Selected = true;
				dgRegua.DoDragDrop(data, DragDropEffects.All);
			}
		}
	}

	private void Aad7odQ0JW(object P_0, DragEventArgs P_1)
	{
		Point point = dgRegua.PointToClient(new Point(P_1.X, P_1.Y));
		DataGridView.HitTestInfo hitTestInfo = dgRegua.HitTest(point.X, point.Y);
		DataGridViewRow dataGridViewRow = (DataGridViewRow)P_1.Data.GetData(typeof(DataGridViewRow));
		DataGridViewRow dataGridViewRow2 = (DataGridViewRow)dataGridViewRow.Clone();
		dataGridViewRow2.Cells[0].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[0].Value);
		dataGridViewRow2.Cells[1].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[1].Value);
		dataGridViewRow2.Cells[2].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[2].Value);
		dataGridViewRow2.Cells[3].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[3].Value);
		if (hitTestInfo.RowIndex == -1)
		{
			dgRegua.Rows.Add(dataGridViewRow2);
			dgRegua.Rows.RemoveAt(URe7sHSMmb);
			return;
		}
		dgRegua.Rows.Insert(hitTestInfo.RowIndex, dataGridViewRow2);
		checked
		{
			if (URe7sHSMmb > hitTestInfo.RowIndex)
			{
				URe7sHSMmb++;
			}
			dgRegua.Rows.RemoveAt(URe7sHSMmb);
		}
	}

	private void aJS7G5ZtAM(object P_0, DragEventArgs P_1)
	{
		P_1.Effect = DragDropEffects.Copy;
	}

	private void dSV7HoVmFJ(object P_0, EventArgs P_1)
	{
		if (cbAlterarOrdem.Checked)
		{
			btPesquisar.Enabled = false;
			btExportaEXCEL.Enabled = false;
			dgRegua.MultiSelect = false;
			dgRegua.AllowDrop = true;
		}
		else
		{
			btPesquisar.Enabled = true;
			btExportaEXCEL.Enabled = true;
			dgRegua.MultiSelect = true;
			dgRegua.AllowDrop = false;
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
				dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 753]));
				dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 754]));
				float num = dgRevisao.Width - 22;
				dgRevisao.Columns[0].Width = (int)Math.Round(num / 3f);
				dgRevisao.Columns[1].Width = (int)Math.Round(num / 3f);
				dgRevisao.Columns[2].Width = (int)Math.Round(num / 3f);
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
				cfe7AiIusf = true;
				dgEquip.Rows.Clear();
				dgEquip.Columns.Clear();
				dgEquip.Columns.Add("", "Indice");
				dgEquip.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 748]));
				float num = dgEquip.Width - 22;
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
				cfe7AiIusf = false;
			}
		}
	}

	public void formataDGRegua()
	{
		checked
		{
			try
			{
				dgRegua.Rows.Clear();
				dgRegua.Columns.Clear();
				dgRegua.Columns.Add("", "Tipo");
				dgRegua.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 110]));
				dgRegua.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 924]));
				dgRegua.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 924]));
				float num = dgRegua.Width - 22;
				dgRegua.Columns[0].Width = 0;
				dgRegua.Columns[0].Visible = false;
				dgRegua.Columns[1].Width = (int)Math.Round(num * 2f / 3f);
				dgRegua.Columns[2].Width = (int)Math.Round(num / 3f);
				dgRegua.Columns[3].Width = 0;
				dgRegua.Columns[3].Visible = false;
				int num2 = dgRegua.Columns.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					dgRegua.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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

	public void formataDGInterlig()
	{
		try
		{
			dgInterlig.Rows.Clear();
			dgInterlig.Columns.Clear();
			dgInterlig.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1425]));
			dgInterlig.Columns.Add("", "");
			dgInterlig.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1426]));
			dgInterlig.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1427]));
			dgInterlig.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1428]));
			dgInterlig.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1425]));
			dgInterlig.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1429]));
			dgInterlig.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1431]));
			dgInterlig.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1430]));
			dgInterlig.Columns.Add("", "");
			dgInterlig.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1248]));
			dgInterlig.Columns.Add("", tbOpcional.Text);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void AtualizaDGInterlig()
	{
		checked
		{
			try
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgInterlig)) ? ((double)(dgInterlig.Width - 4)) : ((double)(dgInterlig.Width - 21)));
				num -= 30.0;
				double num2 = 7.0;
				dgInterlig.Columns[9].Width = 0;
				dgInterlig.Columns[9].Visible = false;
				dgInterlig.Columns[3].Width = 0;
				dgInterlig.Columns[3].Visible = false;
				if (cbFormacao.Checked)
				{
					dgInterlig.Columns[3].Visible = true;
					num2++;
				}
				dgInterlig.Columns[7].Width = 0;
				dgInterlig.Columns[7].Visible = false;
				if (cbDocumento.Checked)
				{
					dgInterlig.Columns[7].Visible = true;
					num2 += 2.0;
				}
				dgInterlig.Columns[8].Width = 0;
				dgInterlig.Columns[8].Visible = false;
				if (cbFuncao.Checked)
				{
					dgInterlig.Columns[8].Visible = true;
					num2 += 3.0;
				}
				dgInterlig.Columns[10].Width = 0;
				dgInterlig.Columns[10].Visible = false;
				if (cbTrajeto.Checked)
				{
					dgInterlig.Columns[10].Visible = true;
					num2 += 3.0;
				}
				dgInterlig.Columns[11].Width = 0;
				dgInterlig.Columns[11].Visible = false;
				if (cbVazio.Checked)
				{
					dgInterlig.Columns[11].Visible = true;
					num2++;
				}
				dgInterlig.Columns[0].Width = (int)Math.Round(num * 1.0 / num2);
				dgInterlig.Columns[1].Width = 30;
				dgInterlig.Columns[2].Width = (int)Math.Round(num * 2.0 / num2);
				dgInterlig.Columns[4].Width = (int)Math.Round(num * 2.0 / num2);
				dgInterlig.Columns[5].Width = (int)Math.Round(num * 1.0 / num2);
				dgInterlig.Columns[6].Width = (int)Math.Round(num * 1.0 / num2);
				if (cbFormacao.Checked)
				{
					dgInterlig.Columns[3].Width = (int)Math.Round(num * 1.0 / num2);
				}
				if (cbDocumento.Checked)
				{
					dgInterlig.Columns[7].Width = (int)Math.Round(num * 2.0 / num2);
				}
				if (cbFuncao.Checked)
				{
					dgInterlig.Columns[8].Width = (int)Math.Round(num * 3.0 / num2);
				}
				if (cbTrajeto.Checked)
				{
					dgInterlig.Columns[10].Width = (int)Math.Round(num * 3.0 / num2);
				}
				if (cbVazio.Checked)
				{
					dgInterlig.Columns[11].Width = (int)Math.Round(num * 1.0 / num2);
				}
				int num3 = dgInterlig.Columns.Count - 1;
				for (int i = 0; i <= num3; i++)
				{
					dgInterlig.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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

	private void lKN7kLvBbN(object P_0, EventArgs P_1)
	{
		jRA7DqqpQO();
	}

	private void EV17dC5BCZ(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void bKP7fECgav(object P_0, EventArgs P_1)
	{
		if (!cbVazio.Checked)
		{
			tbOpcional.Enabled = false;
			tbOpcional.Text = "";
		}
		else
		{
			tbOpcional.Enabled = true;
		}
	}

	private void jRA7DqqpQO()
	{
		if (dgInterlig.Columns.Count > 0)
		{
			AtualizaDGInterlig();
		}
	}
}
