using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.Geometry;

namespace Eletron4;

[DesignerGenerated]
public class frmRelatorio_DIEnergisaMT : Form
{
	private IContainer DIWwP8WrPv;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgRevisao")]
	private DataGridView ljLwcAkJDn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgEquip")]
	private DataGridView qFnwK9f5qJ;

	[AccessedThroughProperty("btAdicionarRegua")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button CAlwemuuHE;

	[AccessedThroughProperty("ToolTip1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ToolTip DKew2Co9uc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox2")]
	private GroupBox Xxkw3PI2yN;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbCadastro")]
	private RadioButton NGHwnFhWeV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbCrescente")]
	private RadioButton QPlw1DRAk4;

	[CompilerGenerated]
	[AccessedThroughProperty("dgRegua")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView TXbwlfFjYJ;

	[CompilerGenerated]
	[AccessedThroughProperty("btApagaRegua")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button ft3w5X6fXd;

	[CompilerGenerated]
	[AccessedThroughProperty("btJumper")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button uinw0OpVmD;

	[AccessedThroughProperty("btApagarJumper")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button gaqwRVLOli;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagarCabos")]
	[CompilerGenerated]
	private Button klfwm4axTe;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox3")]
	private GroupBox DmSwXCN78n;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox4")]
	private GroupBox senwUJ5Ur0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox5")]
	private GroupBox uNrwyAPe3v;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCabos")]
	private Button ikNwg7gqKw;

	[AccessedThroughProperty("GroupBox6")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox GvfwAThV8U;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagarVeias")]
	private Button PRiwsj8hvR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btVeias")]
	private Button DSnwBFjWfb;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSincroniza")]
	private Button krTwVPpPxA;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ProgressBar1")]
	private ProgressBar PaswuC7esx;

	[AccessedThroughProperty("tbPesquisa")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox JeVwEkOt38;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSeleciona")]
	private Button hBCwZgh3N7;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btVerificar")]
	private Button VTWwiqEWtD;

	[AccessedThroughProperty("btApagarCruzamentos")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button qbuwSBYZXc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbAterrarBlindagem")]
	private CheckBox F3Zw4ZcVJh;

	private DeclaracoesFiacao.structurePnRev[] swewCrq3pY;

	private DeclaracoesFiacao.structureRevisoes[] RZvwYtFHv1;

	private DeclaracoesInterligacao.structureRI[] sGrwrw1ZsA;

	private DeclaracoesInterligacao.structureBornesInseridos[] cxow9BNdPp;

	private string kZrwz4uVL2;

	private int Yu7xWrlfhV;

	private bool gmXxpm7Yl2;

	private bool EY2xTKUE3s;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return ljLwcAkJDn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = dYjwdAvvri;
			DataGridView dataGridView = ljLwcAkJDn;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			ljLwcAkJDn = value;
			dataGridView = ljLwcAkJDn;
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
			return qFnwK9f5qJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Fevw6f7WS2;
			DataGridView dataGridView = qFnwK9f5qJ;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			qFnwK9f5qJ = value;
			dataGridView = qFnwK9f5qJ;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual Button btAdicionarRegua
	{
		[CompilerGenerated]
		get
		{
			return CAlwemuuHE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = F93wb5JZyN;
			Button button = CAlwemuuHE;
			if (button != null)
			{
				button.Click -= value2;
			}
			CAlwemuuHE = value;
			button = CAlwemuuHE;
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
			return Xxkw3PI2yN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Xxkw3PI2yN = value;
		}
	}

	internal virtual RadioButton rbCadastro
	{
		[CompilerGenerated]
		get
		{
			return NGHwnFhWeV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OxSwveTUJ3;
			RadioButton radioButton = NGHwnFhWeV;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			NGHwnFhWeV = value;
			radioButton = NGHwnFhWeV;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton rbCrescente
	{
		[CompilerGenerated]
		get
		{
			return QPlw1DRAk4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			QPlw1DRAk4 = value;
		}
	}

	internal virtual DataGridView dgRegua
	{
		[CompilerGenerated]
		get
		{
			return TXbwlfFjYJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TXbwlfFjYJ = value;
		}
	}

	internal virtual Button btApagaRegua
	{
		[CompilerGenerated]
		get
		{
			return ft3w5X6fXd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = chawM4LuHr;
			Button button = ft3w5X6fXd;
			if (button != null)
			{
				button.Click -= value2;
			}
			ft3w5X6fXd = value;
			button = ft3w5X6fXd;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btJumper
	{
		[CompilerGenerated]
		get
		{
			return uinw0OpVmD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DbJwIkdZpE;
			Button button = uinw0OpVmD;
			if (button != null)
			{
				button.Click -= value2;
			}
			uinw0OpVmD = value;
			button = uinw0OpVmD;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btApagarJumper
	{
		[CompilerGenerated]
		get
		{
			return gaqwRVLOli;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = A0cw7PYFOH;
			Button button = gaqwRVLOli;
			if (button != null)
			{
				button.Click -= value2;
			}
			gaqwRVLOli = value;
			button = gaqwRVLOli;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btApagarCabos
	{
		[CompilerGenerated]
		get
		{
			return klfwm4axTe;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CtLwacH8Am;
			Button button = klfwm4axTe;
			if (button != null)
			{
				button.Click -= value2;
			}
			klfwm4axTe = value;
			button = klfwm4axTe;
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
			return DmSwXCN78n;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DmSwXCN78n = value;
		}
	}

	internal virtual GroupBox GroupBox4
	{
		[CompilerGenerated]
		get
		{
			return senwUJ5Ur0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			senwUJ5Ur0 = value;
		}
	}

	internal virtual GroupBox GroupBox5
	{
		[CompilerGenerated]
		get
		{
			return uNrwyAPe3v;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			uNrwyAPe3v = value;
		}
	}

	internal virtual Button btCabos
	{
		[CompilerGenerated]
		get
		{
			return ikNwg7gqKw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = dPPwqBtCMW;
			Button button = ikNwg7gqKw;
			if (button != null)
			{
				button.Click -= value2;
			}
			ikNwg7gqKw = value;
			button = ikNwg7gqKw;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox6
	{
		[CompilerGenerated]
		get
		{
			return GvfwAThV8U;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			GvfwAThV8U = value;
		}
	}

	internal virtual Button btApagarVeias
	{
		[CompilerGenerated]
		get
		{
			return PRiwsj8hvR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = oG1wN6ugMr;
			Button button = PRiwsj8hvR;
			if (button != null)
			{
				button.Click -= value2;
			}
			PRiwsj8hvR = value;
			button = PRiwsj8hvR;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btVeias
	{
		[CompilerGenerated]
		get
		{
			return DSnwBFjWfb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Hf7w8wjj8Y;
			Button button = DSnwBFjWfb;
			if (button != null)
			{
				button.Click -= value2;
			}
			DSnwBFjWfb = value;
			button = DSnwBFjWfb;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btSincroniza
	{
		[CompilerGenerated]
		get
		{
			return krTwVPpPxA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LinwFlsLLw;
			Button button = krTwVPpPxA;
			if (button != null)
			{
				button.Click -= value2;
			}
			krTwVPpPxA = value;
			button = krTwVPpPxA;
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
			return PaswuC7esx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PaswuC7esx = value;
		}
	}

	internal virtual TextBox tbPesquisa
	{
		[CompilerGenerated]
		get
		{
			return JeVwEkOt38;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = ihSwf2pRD6;
			TextBox textBox = JeVwEkOt38;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			JeVwEkOt38 = value;
			textBox = JeVwEkOt38;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Button btSeleciona
	{
		[CompilerGenerated]
		get
		{
			return hBCwZgh3N7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OBawOU4Y0N;
			Button button = hBCwZgh3N7;
			if (button != null)
			{
				button.Click -= value2;
			}
			hBCwZgh3N7 = value;
			button = hBCwZgh3N7;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btVerificar
	{
		[CompilerGenerated]
		get
		{
			return VTWwiqEWtD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = V6vwLI5iDs;
			Button button = VTWwiqEWtD;
			if (button != null)
			{
				button.Click -= value2;
			}
			VTWwiqEWtD = value;
			button = VTWwiqEWtD;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btApagarCruzamentos
	{
		[CompilerGenerated]
		get
		{
			return qbuwSBYZXc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UQ3wQf2LW4;
			Button button = qbuwSBYZXc;
			if (button != null)
			{
				button.Click -= value2;
			}
			qbuwSBYZXc = value;
			button = qbuwSBYZXc;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox cbAterrarBlindagem
	{
		[CompilerGenerated]
		get
		{
			return F3Zw4ZcVJh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			F3Zw4ZcVJh = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && DIWwP8WrPv != null)
			{
				DIWwP8WrPv.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void e2twGGPHxg()
	{
		DIWwP8WrPv = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		dgRevisao = new DataGridView();
		dgEquip = new DataGridView();
		btAdicionarRegua = new Button();
		FDqpBiUmZij(new ToolTip(DIWwP8WrPv));
		GroupBox2 = new GroupBox();
		rbCadastro = new RadioButton();
		rbCrescente = new RadioButton();
		dgRegua = new DataGridView();
		btApagaRegua = new Button();
		btJumper = new Button();
		btApagarJumper = new Button();
		btApagarCabos = new Button();
		GroupBox3 = new GroupBox();
		btVerificar = new Button();
		GroupBox4 = new GroupBox();
		GroupBox5 = new GroupBox();
		btCabos = new Button();
		GroupBox6 = new GroupBox();
		btVeias = new Button();
		btApagarVeias = new Button();
		btSincroniza = new Button();
		ProgressBar1 = new ProgressBar();
		tbPesquisa = new TextBox();
		btSeleciona = new Button();
		btApagarCruzamentos = new Button();
		cbAterrarBlindagem = new CheckBox();
		((ISupportInitialize)dgRevisao).BeginInit();
		((ISupportInitialize)dgEquip).BeginInit();
		GroupBox2.SuspendLayout();
		((ISupportInitialize)dgRegua).BeginInit();
		GroupBox3.SuspendLayout();
		GroupBox4.SuspendLayout();
		GroupBox5.SuspendLayout();
		GroupBox6.SuspendLayout();
		SuspendLayout();
		dgRevisao.AllowUserToAddRows = false;
		dgRevisao.AllowUserToDeleteRows = false;
		dgRevisao.AllowUserToOrderColumns = true;
		dgRevisao.AllowUserToResizeRows = false;
		dgRevisao.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
		dgRevisao.Size = new Size(385, 133);
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
		dgEquip.Location = new Point(13, 177);
		dgEquip.MultiSelect = false;
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(137, 205);
		dgEquip.TabIndex = 8;
		btAdicionarRegua.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btAdicionarRegua.FlatStyle = FlatStyle.Flat;
		btAdicionarRegua.ForeColor = SystemColors.Control;
		btAdicionarRegua.Image = Resources.BorneAranha_32;
		btAdicionarRegua.Location = new Point(38, 20);
		btAdicionarRegua.Name = "btAdicionarRegua";
		btAdicionarRegua.Size = new Size(40, 42);
		btAdicionarRegua.TabIndex = 15;
		btAdicionarRegua.UseVisualStyleBackColor = true;
		GroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox2.Controls.Add(rbCadastro);
		GroupBox2.Controls.Add(rbCrescente);
		GroupBox2.Location = new Point(7, 389);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(142, 69);
		GroupBox2.TabIndex = 47;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "Ordem Bornes Máscara";
		rbCadastro.AutoSize = true;
		rbCadastro.Location = new Point(6, 42);
		rbCadastro.Name = "rbCadastro";
		rbCadastro.Size = new Size(76, 17);
		rbCadastro.TabIndex = 1;
		rbCadastro.TabStop = true;
		rbCadastro.Text = "rbCadastro";
		rbCadastro.UseVisualStyleBackColor = true;
		rbCrescente.AutoSize = true;
		rbCrescente.Location = new Point(6, 19);
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
		dgRegua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgRegua.BackgroundColor = Color.White;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		dgRegua.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		dgRegua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgRegua.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgRegua.Location = new Point(155, 151);
		dgRegua.MultiSelect = false;
		dgRegua.Name = "dgRegua";
		dgRegua.ReadOnly = true;
		dgRegua.RowHeadersVisible = false;
		dgRegua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRegua.Size = new Size(242, 214);
		dgRegua.TabIndex = 48;
		btApagaRegua.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagaRegua.FlatStyle = FlatStyle.Flat;
		btApagaRegua.ForeColor = SystemColors.Control;
		btApagaRegua.Image = Resources.Delete_32;
		btApagaRegua.Location = new Point(71, 20);
		btApagaRegua.Name = "btApagaRegua";
		btApagaRegua.Size = new Size(40, 42);
		btApagaRegua.TabIndex = 50;
		btApagaRegua.UseVisualStyleBackColor = true;
		btJumper.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btJumper.FlatStyle = FlatStyle.Flat;
		btJumper.ForeColor = SystemColors.Control;
		btJumper.Image = Resources.JumperAranha_32;
		btJumper.Location = new Point(7, 19);
		btJumper.Name = "btJumper";
		btJumper.Size = new Size(40, 42);
		btJumper.TabIndex = 51;
		btJumper.UseVisualStyleBackColor = true;
		btApagarJumper.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagarJumper.FlatStyle = FlatStyle.Flat;
		btApagarJumper.ForeColor = SystemColors.Control;
		btApagarJumper.Image = Resources.Delete_32;
		btApagarJumper.Location = new Point(52, 20);
		btApagarJumper.Name = "btApagarJumper";
		btApagarJumper.Size = new Size(40, 42);
		btApagarJumper.TabIndex = 52;
		btApagarJumper.UseVisualStyleBackColor = true;
		btApagarCabos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagarCabos.FlatStyle = FlatStyle.Flat;
		btApagarCabos.ForeColor = SystemColors.Control;
		btApagarCabos.Image = Resources.Delete_32;
		btApagarCabos.Location = new Point(69, 18);
		btApagarCabos.Name = "btApagarCabos";
		btApagarCabos.Size = new Size(40, 42);
		btApagarCabos.TabIndex = 54;
		btApagarCabos.UseVisualStyleBackColor = true;
		GroupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox3.Controls.Add(btVerificar);
		GroupBox3.Controls.Add(btAdicionarRegua);
		GroupBox3.Controls.Add(btApagaRegua);
		GroupBox3.Location = new Point(155, 389);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(115, 70);
		GroupBox3.TabIndex = 56;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "Réguas de Bornes";
		btVerificar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btVerificar.FlatStyle = FlatStyle.Flat;
		btVerificar.ForeColor = SystemColors.Control;
		btVerificar.Image = Resources.Check;
		btVerificar.Location = new Point(6, 20);
		btVerificar.Name = "btVerificar";
		btVerificar.Size = new Size(36, 42);
		btVerificar.TabIndex = 52;
		btVerificar.UseVisualStyleBackColor = true;
		GroupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox4.Controls.Add(btApagarJumper);
		GroupBox4.Controls.Add(btJumper);
		GroupBox4.Location = new Point(282, 389);
		GroupBox4.Name = "GroupBox4";
		GroupBox4.Size = new Size(115, 70);
		GroupBox4.TabIndex = 57;
		GroupBox4.TabStop = false;
		GroupBox4.Text = "Jumpers";
		GroupBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox5.Controls.Add(btCabos);
		GroupBox5.Controls.Add(btApagarCabos);
		GroupBox5.Location = new Point(155, 464);
		GroupBox5.Name = "GroupBox5";
		GroupBox5.Size = new Size(115, 70);
		GroupBox5.TabIndex = 58;
		GroupBox5.TabStop = false;
		GroupBox5.Text = "Cabos";
		btCabos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btCabos.FlatStyle = FlatStyle.Flat;
		btCabos.ForeColor = SystemColors.Control;
		btCabos.Image = Resources.CaboAranha_32;
		btCabos.Location = new Point(15, 18);
		btCabos.Name = "btCabos";
		btCabos.Size = new Size(40, 42);
		btCabos.TabIndex = 51;
		btCabos.UseVisualStyleBackColor = true;
		GroupBox6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox6.Controls.Add(btVeias);
		GroupBox6.Controls.Add(btApagarVeias);
		GroupBox6.Location = new Point(284, 464);
		GroupBox6.Name = "GroupBox6";
		GroupBox6.Size = new Size(115, 70);
		GroupBox6.TabIndex = 59;
		GroupBox6.TabStop = false;
		GroupBox6.Text = "Veias";
		btVeias.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btVeias.FlatStyle = FlatStyle.Flat;
		btVeias.ForeColor = SystemColors.Control;
		btVeias.Image = Resources.Veias;
		btVeias.Location = new Point(6, 19);
		btVeias.Name = "btVeias";
		btVeias.Size = new Size(40, 42);
		btVeias.TabIndex = 55;
		btVeias.UseVisualStyleBackColor = true;
		btApagarVeias.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagarVeias.FlatStyle = FlatStyle.Flat;
		btApagarVeias.ForeColor = SystemColors.Control;
		btApagarVeias.Image = Resources.Delete_32;
		btApagarVeias.Location = new Point(52, 19);
		btApagarVeias.Name = "btApagarVeias";
		btApagarVeias.Size = new Size(40, 42);
		btApagarVeias.TabIndex = 52;
		btApagarVeias.UseVisualStyleBackColor = true;
		btSincroniza.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btSincroniza.FlatStyle = FlatStyle.Flat;
		btSincroniza.ForeColor = SystemColors.Control;
		btSincroniza.Image = Resources.Sincroniza_32;
		btSincroniza.Location = new Point(36, 489);
		btSincroniza.Name = "btSincroniza";
		btSincroniza.Size = new Size(40, 42);
		btSincroniza.TabIndex = 51;
		btSincroniza.UseVisualStyleBackColor = true;
		ProgressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ProgressBar1.Location = new Point(155, 371);
		ProgressBar1.Name = "ProgressBar1";
		ProgressBar1.Size = new Size(242, 11);
		ProgressBar1.TabIndex = 61;
		tbPesquisa.Location = new Point(12, 151);
		tbPesquisa.Name = "tbPesquisa";
		tbPesquisa.Size = new Size(116, 20);
		tbPesquisa.TabIndex = 62;
		btSeleciona.FlatStyle = FlatStyle.Flat;
		btSeleciona.ForeColor = SystemColors.Control;
		btSeleciona.Image = Resources.Select_16;
		btSeleciona.Location = new Point(132, 151);
		btSeleciona.Name = "btSeleciona";
		btSeleciona.Size = new Size(16, 20);
		btSeleciona.TabIndex = 67;
		btSeleciona.UseVisualStyleBackColor = true;
		btApagarCruzamentos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagarCruzamentos.FlatStyle = FlatStyle.Flat;
		btApagarCruzamentos.ForeColor = SystemColors.Control;
		btApagarCruzamentos.Image = Resources.Delete_32;
		btApagarCruzamentos.Location = new Point(82, 489);
		btApagarCruzamentos.Name = "btApagarCruzamentos";
		btApagarCruzamentos.Size = new Size(36, 42);
		btApagarCruzamentos.TabIndex = 70;
		btApagarCruzamentos.UseVisualStyleBackColor = true;
		cbAterrarBlindagem.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		cbAterrarBlindagem.AutoSize = true;
		cbAterrarBlindagem.Location = new Point(9, 463);
		cbAterrarBlindagem.Name = "cbAterrarBlindagem";
		cbAterrarBlindagem.Size = new Size(139, 17);
		cbAterrarBlindagem.TabIndex = 71;
		cbAterrarBlindagem.Text = "Aterrar Blindagem Colet.";
		cbAterrarBlindagem.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(404, 541);
		Controls.Add(cbAterrarBlindagem);
		Controls.Add(btApagarCruzamentos);
		Controls.Add(btSeleciona);
		Controls.Add(tbPesquisa);
		Controls.Add(ProgressBar1);
		Controls.Add(btSincroniza);
		Controls.Add(GroupBox6);
		Controls.Add(GroupBox5);
		Controls.Add(GroupBox4);
		Controls.Add(GroupBox3);
		Controls.Add(dgRegua);
		Controls.Add(GroupBox2);
		Controls.Add(dgEquip);
		Controls.Add(dgRevisao);
		MaximumSize = new Size(420, 1200);
		MinimumSize = new Size(420, 580);
		Name = "frmRelatorio_DIEnergisaMT";
		ShowInTaskbar = false;
		Text = "Diagrama de Interligação Energisa MT";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		((ISupportInitialize)dgRegua).EndInit();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox4.ResumeLayout(performLayout: false);
		GroupBox5.ResumeLayout(performLayout: false);
		GroupBox6.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return DKew2Co9uc;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		DKew2Co9uc = WithEventsValue;
	}

	public frmRelatorio_DIEnergisaMT()
	{
		swewCrq3pY = new DeclaracoesFiacao.structurePnRev[1];
		RZvwYtFHv1 = new DeclaracoesFiacao.structureRevisoes[1];
		kZrwz4uVL2 = "";
		Yu7xWrlfhV = 0;
		gmXxpm7Yl2 = false;
		EY2xTKUE3s = false;
		try
		{
			if (!Geral.ExisteForm("frmRelatorio_DIEnergisaMT"))
			{
				e2twGGPHxg();
				M7ZwHv8dW4(_0020: false);
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1977]);
				GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1419]);
				GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 788]);
				GroupBox4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1444]);
				GroupBox5.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 514]);
				GroupBox6.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1445]);
				rbCrescente.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1420]);
				rbCadastro.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1421]);
				w8dpBZ0kvSD().SetToolTip(btSeleciona, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1900]));
				w8dpBZ0kvSD().SetToolTip(btApagarCruzamentos, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1901]));
				w8dpBZ0kvSD().SetToolTip(btVerificar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1902]));
				cDadosAccess.carregaDadosDWG();
				Application.ShowModelessDialog((Form)this);
				sGrwrw1ZsA = new DeclaracoesInterligacao.structureRI[1];
				sGrwrw1ZsA[0].Bornes = new DeclaracoesInterligacao.borneRI[1];
				cxow9BNdPp = new DeclaracoesInterligacao.structureBornesInseridos[1];
				formataDGRevisao();
				formataDGEquip();
				rbCrescente.Checked = true;
				cbAterrarBlindagem.Checked = true;
				W1JwkSS5VN();
				M7ZwHv8dW4(_0020: true);
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

	private void M7ZwHv8dW4(bool P_0)
	{
		GroupBox2.Enabled = P_0;
		GroupBox3.Enabled = P_0;
		GroupBox4.Enabled = P_0;
		GroupBox5.Enabled = P_0;
		GroupBox6.Enabled = P_0;
		btSincroniza.Enabled = P_0;
		btSeleciona.Enabled = P_0;
	}

	private void W1JwkSS5VN()
	{
		RZvwYtFHv1 = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			cDadosAccessInterligacao3.CarregaRevisoesCabos4(ref RZvwYtFHv1);
			gmXxpm7Yl2 = true;
			dgRevisao.Rows.Clear();
			gmXxpm7Yl2 = false;
			int num = Information.UBound(RZvwYtFHv1);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				dgRevisao.Rows.Add(RZvwYtFHv1[i].revisao, RZvwYtFHv1[i].criador, RZvwYtFHv1[i].data);
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

	private void dYjwdAvvri(object P_0, EventArgs P_1)
	{
		EY2xTKUE3s = true;
		dgEquip.Rows.Clear();
		EY2xTKUE3s = false;
		if (!gmXxpm7Yl2)
		{
			MfAwD2XVAV(_0020: false);
		}
	}

	private void ihSwf2pRD6(object P_0, KeyEventArgs P_1)
	{
		if (((P_1.KeyValue == 13) | (Operators.CompareString(tbPesquisa.Text.Trim(), "", TextCompare: true) == 0)) && !gmXxpm7Yl2)
		{
			MfAwD2XVAV(_0020: true);
		}
	}

	private void MfAwD2XVAV(bool P_0)
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
			kZrwz4uVL2 = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
			EY2xTKUE3s = true;
			dgEquip.Rows.Clear();
			EY2xTKUE3s = false;
			int num = Information.UBound(swewCrq3pY);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(swewCrq3pY[i].revisao, kZrwz4uVL2, TextCompare: true) == 0)
				{
					string text = Dicionario.BuscaNomeDoPainel(swewCrq3pY[i].painel);
					if (!P_0)
					{
						dgEquip.Rows.Add(swewCrq3pY[i].painel, text);
					}
					else if (text.ToUpper().Contains(tbPesquisa.Text.ToUpper().Trim()))
					{
						dgEquip.Rows.Add(swewCrq3pY[i].painel, text);
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
		swewCrq3pY = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			if (Information.UBound(RZvwYtFHv1) > 0)
			{
				int num = Information.UBound(RZvwYtFHv1);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessInterligacao3.CarregaPnRev(RZvwYtFHv1[i].revisao, ref swewCrq3pY);
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

	private void OxSwveTUJ3(object P_0, EventArgs P_1)
	{
		TucwtswBfc();
	}

	private void Fevw6f7WS2(object P_0, EventArgs P_1)
	{
		TucwtswBfc();
	}

	private void TucwtswBfc()
	{
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			if (dgEquip.SelectedRows.Count == 1)
			{
				M7ZwHv8dW4(_0020: false);
				Yu7xWrlfhV = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
				formataDGRegua();
				sGrwrw1ZsA = new DeclaracoesInterligacao.structureRI[1];
				sGrwrw1ZsA[0].Bornes = new DeclaracoesInterligacao.borneRI[1];
				cDadosAccessInterligacao3.CarregaReguas(kZrwz4uVL2, Yu7xWrlfhV, ref sGrwrw1ZsA);
				cDadosAccessInterligacao3.CarregaReguasPortas(kZrwz4uVL2, Yu7xWrlfhV, ref sGrwrw1ZsA);
				cDadosAccessInterligacao3.CarregaBornesReguas(kZrwz4uVL2, Yu7xWrlfhV, ref sGrwrw1ZsA, rbCadastro.Checked);
				ProgressBar1.Minimum = 0;
				ProgressBar1.Maximum = checked(HrnwjkWgQ8() * 2);
				ProgressBar1.Value = 0;
				ProgressBar1.Step = 1;
				string revisao = kZrwz4uVL2;
				int yu7xWrlfhV = Yu7xWrlfhV;
				ref DeclaracoesInterligacao.structureRI[] mReguas = ref sGrwrw1ZsA;
				ProgressBar ProgressBar = ProgressBar1;
				cDadosAccessInterligacao3.CarregaCabosNosBornesRI(revisao, yu7xWrlfhV, ref mReguas, ref ProgressBar, -1);
				ProgressBar1 = ProgressBar;
				string revisao2 = kZrwz4uVL2;
				int yu7xWrlfhV2 = Yu7xWrlfhV;
				ref DeclaracoesInterligacao.structureRI[] mReguas2 = ref sGrwrw1ZsA;
				ProgressBar = ProgressBar1;
				cDadosAccessInterligacao3.CarregaJumpersNosBornesRI(revisao2, yu7xWrlfhV2, ref mReguas2, ref ProgressBar);
				ProgressBar1 = ProgressBar;
				sCVwxrsTLv();
				l8fwwNoxUf();
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
			M7ZwHv8dW4(_0020: true);
		}
	}

	private int HrnwjkWgQ8()
	{
		int num = 0;
		int num2 = Information.UBound(sGrwrw1ZsA);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				if (!Information.IsNothing(sGrwrw1ZsA[i].Bornes))
				{
					num += sGrwrw1ZsA[i].Bornes.Length - 1;
				}
			}
			return num;
		}
	}

	private void V6vwLI5iDs(object P_0, EventArgs P_1)
	{
		l8fwwNoxUf();
	}

	private void l8fwwNoxUf()
	{
		cxow9BNdPp = new DeclaracoesInterligacao.structureBornesInseridos[1];
		ClsAranha.ContaBornesReguas(Yu7xWrlfhV, ref cxow9BNdPp);
		checked
		{
			int num = dgRegua.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				string right = Conversions.ToString(dgRegua.Rows[i].Cells[1].Value);
				string right2 = Conversions.ToString(dgRegua.Rows[i].Cells[2].Value);
				int num2 = Conversions.ToInteger(dgRegua.Rows[i].Cells[3].Value);
				bool flag = false;
				int num3 = Information.UBound(cxow9BNdPp);
				for (int j = 1; j <= num3; j++)
				{
					if (!((Operators.CompareString(cxow9BNdPp[j].Tag, right, TextCompare: true) == 0) & (Operators.CompareString(cxow9BNdPp[j].NRegua, right2, TextCompare: true) == 0)))
					{
						continue;
					}
					if (num2 != cxow9BNdPp[j].Qtde)
					{
						if ((num2 > cxow9BNdPp[j].Qtde) & (cxow9BNdPp[j].Qtde > 0))
						{
							flag = true;
							dgRegua.Rows[i].Cells[3].Style.BackColor = Color.LightYellow;
						}
					}
					else
					{
						flag = true;
						dgRegua.Rows[i].Cells[3].Style.BackColor = Color.LightCoral;
					}
				}
				if (!flag)
				{
					dgRegua.Rows[i].Cells[3].Style.BackColor = Color.LightGreen;
				}
			}
		}
	}

	private void sCVwxrsTLv()
	{
		if (Information.UBound(sGrwrw1ZsA) == 0)
		{
			return;
		}
		List<int> list = new List<int>();
		try
		{
			int num = Information.UBound(sGrwrw1ZsA);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Information.IsNothing(sGrwrw1ZsA[i].Bornes))
				{
					if (!list.Contains(sGrwrw1ZsA[i].DWG))
					{
						list.Add(sGrwrw1ZsA[i].DWG);
					}
					continue;
				}
				int num2 = Information.UBound(sGrwrw1ZsA[i].Bornes);
				dgRegua.Rows.Add(sGrwrw1ZsA[i].Tipo, sGrwrw1ZsA[i].Tag, sGrwrw1ZsA[i].NRegua, num2);
			}
			string text = "";
			if (list.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<int, string> item in DeclaracoesGeral.dicDWG)
			{
				if (list.Contains(item.Key))
				{
					text = ((Operators.CompareString(text, "", TextCompare: true) == 0) ? item.Value : ("," + item.Value));
				}
			}
			if (list.Count != 1)
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1981], "\r\n"), " "), text), MsgBoxStyle.Information);
			}
			else
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1980], "\r\n"), " "), text), MsgBoxStyle.Information);
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

	private void F93wb5JZyN(object P_0, EventArgs P_1)
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Unknown result type (might be due to invalid IL or missing references)
		//IL_0497: Unknown result type (might be due to invalid IL or missing references)
		//IL_049c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_053a: Unknown result type (might be due to invalid IL or missing references)
		//IL_053f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0543: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			try
			{
				List<string> lPaginasColunas = new List<string>();
				clsDIEnergisaMT.buscaPaginasColuna(ref lPaginasColunas);
				DeclaracoesInterligacao.structureRI structureRI = default;
				if (dgEquip.SelectedRows.Count == 0 || dgRegua.SelectedRows.Count == 0)
				{
					return;
				}
				DeclaracoesGeral.Reguas RH = default;
				if (XDataGeral.LeXDataReguaH(ref RH))
				{
					Point3d ptCol = new Point3d(RH.LarguraBase - 5.0, 280.0, 0.0);
					string text = Conversions.ToString(dgRegua.SelectedRows[0].Cells[1].Value);
					string text2 = Conversions.ToString(dgRegua.SelectedRows[0].Cells[2].Value);
					int num = Information.UBound(sGrwrw1ZsA);
					for (int i = 1; i <= num; i++)
					{
						if ((Operators.CompareString(sGrwrw1ZsA[i].Tag, text, TextCompare: true) == 0) & (Operators.CompareString(sGrwrw1ZsA[i].NRegua, text2, TextCompare: true) == 0))
						{
							structureRI = sGrwrw1ZsA[i];
							break;
						}
					}
					if (Information.UBound(structureRI.Bornes) == 0)
					{
						return;
					}
					int num2 = 0;
					int num3 = 0;
					int num4 = 0;
					bool flag = false;
					Point3d val = new Point3d(RH.Pti.X + 20.0, 265.0, 0.0);
					Point3d ptIns = val;
					num4 = 1;
					List<string> lBornes = new List<string>();
					Point3d pt = default;
					if (clsDIEnergisaMT.reguaExiste(Yu7xWrlfhV, text, text2))
					{
						DeclaracoesInterligacao.PosborneAranha ubn = default;
						if (!clsDIEnergisaMT.BuscaUltimoBorne(Yu7xWrlfhV, text, text2, ref ubn, ref lBornes))
						{
							return;
						}
						Pagina.AtivaPagina(ubn.Pagina);
						num4 = ubn.Posicao;
						ptIns = ubn.PtIns;
						num2 = (int)Math.Round((265.0 - ubn.PtIns.Y) / 5.0);
						if (structureRI.Bornes[1].TipoBorne != 0)
						{
							num2 += 2;
							num3 = 10;
						}
						else
						{
							num2++;
							num3 = 5;
						}
					}
					else if (clsDIEnergisaMT.outraReguaExiste(DeclaracoesGeral.ativo.Pagina, ref pt, num4))
					{
						ptIns = new Point3d(pt.X, pt.Y - 20.0, 0.0);
						num2 = (int)Math.Round((265.0 - ptIns.Y) / 5.0);
						if (num2 >= 40)
						{
							return;
						}
						flag = true;
					}
					int num5 = Information.UBound(structureRI.Bornes);
					int num6 = 1;
					while (true)
					{
						if (num6 <= num5)
						{
							if (!lBornes.Contains(structureRI.Bornes[num6].Borne))
							{
								if (num2 != 0)
								{
									if (!((num2 > 0) & (num2 < 40)))
									{
										if (num2 >= 40)
										{
											num2 = 0;
											string text3 = Pagina.BuscaProximaPaginaValida(DeclaracoesGeral.ativo.Pagina);
											if (Operators.CompareString(text3, "", TextCompare: true) != 0)
											{
												Pagina.AtivaPagina(text3);
											}
											else if (!Pagina.criarUmaNovaPagina())
											{
												goto IL_04f6;
											}
											clsDIEnergisaMT.insereColunasSePrecisar(ref lPaginasColunas, ptCol);
											if (num4 == 1)
											{
												ptIns = val;
											}
										}
									}
									else
									{
										ptIns = new Point3d(ptIns.X, ptIns.Y - (double)num3, 0.0);
									}
								}
								else
								{
									clsDIEnergisaMT.insereColunasSePrecisar(ref lPaginasColunas, ptCol);
								}
								DeclaracoesInterligacao.borneAranha bn = new DeclaracoesInterligacao.borneAranha
								{
									Revisao = kZrwz4uVL2,
									Painel = Yu7xWrlfhV,
									Tag = text,
									NRegua = text2,
									Borne = structureRI.Bornes[num6].Borne,
									TipoBorne = structureRI.Bornes[num6].TipoBorne,
									Ordem = structureRI.Bornes[num6].Ordem,
									Posicao = num4
								};
								string text4 = "";
								text4 = ((bn.TipoBorne == 0) ? "BorneSimples.DWG" : "BorneDuplo.DWG");
								if (!File.Exists(DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\EnergisaMT\\" + text4))
								{
									break;
								}
								if (num2 == 0)
								{
									flag = true;
								}
								if (flag)
								{
									Point3d ptIns2 = new Point3d(ptIns.X - 4.0, ptIns.Y, 0.0);
									clsDIEnergisaMT.InserirReguaDInterlig(ref bn, ptIns2);
								}
								clsDIEnergisaMT.InserirBorneAranha(text4, bn, ptIns);
								flag = false;
								if (bn.TipoBorne != 0)
								{
									if (bn.TipoBorne == 1)
									{
										num2 += 2;
										num3 = 10;
									}
								}
								else
								{
									num2++;
									num3 = 5;
								}
							}
							num6++;
							continue;
						}
						goto IL_04f6;
						IL_04f6:
						DeclaracoesGeral._uscPagina.CarregaPG();
						return;
					}
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 848]), MsgBoxStyle.Exclamation);
				}
				else
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 611]), MsgBoxStyle.Information);
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
				Application.UpdateScreen();
			}
		}
	}

	private void chawM4LuHr(object P_0, EventArgs P_1)
	{
		string tag = Conversions.ToString(dgRegua.SelectedRows[0].Cells[1].Value);
		string nRegua = Conversions.ToString(dgRegua.SelectedRows[0].Cells[2].Value);
		clsDIEnergisaMT.ApagaRegua(kZrwz4uVL2, Yu7xWrlfhV, tag, nRegua);
		Application.UpdateScreen();
	}

	private void OBawOU4Y0N(object P_0, EventArgs P_1)
	{
		string rev = "";
		int painel = 0;
		checked
		{
			if (clsDIEnergisaMT.SelecionaBorne(ref rev, ref painel))
			{
				int num = dgRevisao.RowCount - 1;
				for (int i = 0; i <= num; i++)
				{
					if (!Operators.ConditionalCompareObjectEqual(dgRevisao[0, i].Value, rev, TextCompare: true))
					{
						continue;
					}
					dgRevisao.Rows[i].Selected = true;
					dgRevisao.FirstDisplayedScrollingRowIndex = i;
					int num2 = dgEquip.RowCount - 1;
					for (int j = 0; j <= num2; j++)
					{
						if (Operators.ConditionalCompareObjectEqual(dgEquip[0, j].Value, painel, TextCompare: true))
						{
							dgEquip.Rows[j].Selected = true;
							dgEquip.FirstDisplayedScrollingRowIndex = j;
							break;
						}
					}
					break;
				}
			}
			Application.UpdateScreen();
		}
	}

	private void DbJwIkdZpE(object P_0, EventArgs P_1)
	{
		DeclaracoesInterligacao.borneJ[] mBornesJ = new DeclaracoesInterligacao.borneJ[1];
		DeclaracoesInterligacao.jumper[] mJumpers = new DeclaracoesInterligacao.jumper[1];
		if (!clsDIEnergisaMT.carregaBornesJ(kZrwz4uVL2, Yu7xWrlfhV, ref mBornesJ))
		{
			return;
		}
		clsDIEnergisaMT.buscaJumpers(ref mBornesJ, ref mJumpers, ref sGrwrw1ZsA);
		clsDIEnergisaMT.ApagaJumper(kZrwz4uVL2, Yu7xWrlfhV);
		if (Information.UBound(mJumpers) <= 0)
		{
			return;
		}
		int num = Information.UBound(mJumpers);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (!mJumpers[i].bMesmaPaginaColuna)
			{
				if (!mJumpers[i].bMesmaPaginaColuna)
				{
					clsDIEnergisaMT.desenhaJumper2(kZrwz4uVL2, Yu7xWrlfhV, ref mBornesJ, ref mJumpers, i);
				}
			}
			else
			{
				clsDIEnergisaMT.desenhaJumper1(kZrwz4uVL2, Yu7xWrlfhV, ref mBornesJ, ref mJumpers, i);
			}
		}
		Application.UpdateScreen();
	}

	private void A0cw7PYFOH(object P_0, EventArgs P_1)
	{
		clsDIEnergisaMT.ApagaJumper(kZrwz4uVL2, Yu7xWrlfhV);
		Application.UpdateScreen();
	}

	private void dPPwqBtCMW(object P_0, EventArgs P_1)
	{
		DeclaracoesInterligacao.borneJ[] mBornesJ = new DeclaracoesInterligacao.borneJ[1];
		DeclaracoesInterligacao.caboAranha[] mCabos = new DeclaracoesInterligacao.caboAranha[1];
		List<string> lCabosInseridos = new List<string>();
		if (clsDIEnergisaMT.carregaBornesJ(kZrwz4uVL2, Yu7xWrlfhV, ref mBornesJ))
		{
			clsDIEnergisaMT.carregaCabosInseridos(kZrwz4uVL2, Yu7xWrlfhV, ref lCabosInseridos);
			clsDIEnergisaMT.carregaCabos(kZrwz4uVL2, ref sGrwrw1ZsA, ref mBornesJ, ref mCabos);
			clsDIEnergisaMT.insereCabos(kZrwz4uVL2, Yu7xWrlfhV, ref mCabos, lCabosInseridos, cbAterrarBlindagem.Checked);
			Application.UpdateScreen();
		}
	}

	private void CtLwacH8Am(object P_0, EventArgs P_1)
	{
		clsDIEnergisaMT.ApagaCabos(kZrwz4uVL2, Yu7xWrlfhV);
		clsDIEnergisaMT.ApagaVeias(kZrwz4uVL2, Yu7xWrlfhV);
		Application.UpdateScreen();
	}

	private void Hf7w8wjj8Y(object P_0, EventArgs P_1)
	{
		btVeias.Enabled = false;
		DeclaracoesInterligacao.borneJ[] mBornesJ = new DeclaracoesInterligacao.borneJ[1];
		DeclaracoesInterligacao.caboAranha[] mCabos = new DeclaracoesInterligacao.caboAranha[1];
		List<string> lCabosInseridos = new List<string>();
		DeclaracoesInterligacao.cruzamentoCaboAranha[] mInfoVeias = new DeclaracoesInterligacao.cruzamentoCaboAranha[1];
		if (clsDIEnergisaMT.carregaBornesJ(kZrwz4uVL2, Yu7xWrlfhV, ref mBornesJ))
		{
			clsDIEnergisaMT.AtualizaBornesJ(kZrwz4uVL2, Yu7xWrlfhV, ref mBornesJ);
			clsDIEnergisaMT.carregaCabosInseridosViaVeias(kZrwz4uVL2, Yu7xWrlfhV, ref lCabosInseridos);
			clsDIEnergisaMT.carregaCabosDWG(kZrwz4uVL2, Yu7xWrlfhV, ref mCabos);
			clsDIEnergisaMT.relacionaCabosBornes(Yu7xWrlfhV, ref sGrwrw1ZsA, ref mBornesJ, ref mCabos);
			clsDIEnergisaMT.verificaErro(mCabos);
			clsDIEnergisaMT.insereVeias(kZrwz4uVL2, Yu7xWrlfhV, ref mBornesJ, ref mCabos, ref mInfoVeias, lCabosInseridos);
			clsDIEnergisaMT.insereVeias2(kZrwz4uVL2, Yu7xWrlfhV, ref mBornesJ, ref mCabos, ref mInfoVeias, lCabosInseridos);
			Application.UpdateScreen();
		}
		btVeias.Enabled = true;
	}

	private void oG1wN6ugMr(object P_0, EventArgs P_1)
	{
		clsDIEnergisaMT.ApagaVeias(kZrwz4uVL2, Yu7xWrlfhV);
		Application.UpdateScreen();
	}

	private void LinwFlsLLw(object P_0, EventArgs P_1)
	{
		DeclaracoesInterligacao.caboSync[] mCabosSync = new DeclaracoesInterligacao.caboSync[1];
		DeclaracoesInterligacao.caboSync[] mTodosCabosSync = new DeclaracoesInterligacao.caboSync[1];
		cDadosAccess.carregaDadosDWG();
		clsDIEnergisaMT.carregaTodosCabosDWG(kZrwz4uVL2, ref mCabosSync);
		List<int> lPn = new List<int>();
		int num = Information.UBound(mCabosSync);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (!lPn.Contains(mCabosSync[i].Painel))
			{
				lPn.Add(mCabosSync[i].Painel);
			}
		}
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		cDadosAccessInterligacao3.ApagaCabosRevPn(kZrwz4uVL2, ref lPn);
		cDadosAccessInterligacao3.exportaCabos(kZrwz4uVL2, ref mCabosSync);
		cDadosAccessInterligacao3.leCabos(kZrwz4uVL2, ref mTodosCabosSync);
		clsDIEnergisaMT.LimpaCruzamentoCabos();
		clsDIEnergisaMT.SincronizaCabos(kZrwz4uVL2, mTodosCabosSync);
		cDadosAccessInterligacao3.fechaConexao();
		Application.UpdateScreen();
	}

	private void UQ3wQf2LW4(object P_0, EventArgs P_1)
	{
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1899]), MsgBoxStyle.YesNo | MsgBoxStyle.Question, "Elétron");
		if (msgBoxResult == MsgBoxResult.Yes)
		{
			cDadosAtualizaBanco cDadosAtualizaBanco2 = new cDadosAtualizaBanco();
			cDadosAtualizaBanco2.ApagaAranha4();
			cDadosAtualizaBanco2.fechaConexao();
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
				EY2xTKUE3s = true;
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
				EY2xTKUE3s = false;
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
				dgRegua.Columns.Add("", "#");
				float num = dgRegua.Width - 22;
				dgRegua.Columns[0].Width = 0;
				dgRegua.Columns[0].Visible = false;
				dgRegua.Columns[1].Width = (int)Math.Round(num * 2f / 4f);
				dgRegua.Columns[2].Width = (int)Math.Round((double)num * 1.2 / 4.0);
				dgRegua.Columns[3].Width = (int)Math.Round((double)num * 0.8 / 4.0);
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
}
