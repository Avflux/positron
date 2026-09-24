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
public class frmRelatorio_DIEnergisaMS : Form
{
	private IContainer MyCLPEq9lK;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgRevisao")]
	private DataGridView plULcTN3KU;

	[AccessedThroughProperty("dgEquip")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView HjFLKfjXvy;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btAdicionarRegua")]
	private Button NbxLew2p9N;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip J6nL2khgZk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox2")]
	private GroupBox MehL3risDj;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbCadastro")]
	private RadioButton NUGLnptuOZ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbCrescente")]
	[CompilerGenerated]
	private RadioButton jaXL1No1PZ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgRegua")]
	private DataGridView oLALlZG55w;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox rA5L5XLn7C;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rb1")]
	private RadioButton wj5L09hbeV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagaRegua")]
	private Button QcWLRvET7H;

	[AccessedThroughProperty("btJumper")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button hBFLmZ9MoU;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagarJumper")]
	private Button EDhLXq3pOs;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagarCabos")]
	private Button C5ZLUaUUXR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox3")]
	private GroupBox wmBLyGdcXm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox4")]
	private GroupBox THlLgDN9TQ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox5")]
	[CompilerGenerated]
	private GroupBox E7aLAAl3ub;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCabos")]
	[CompilerGenerated]
	private Button hAcLsvwi8P;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox6")]
	private GroupBox qvoLBUtfdd;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagarVeias")]
	private Button UAqLVgZeV7;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btVeias")]
	private Button jxILuwGaUq;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btSincroniza")]
	private Button dMHLERAuCM;

	[AccessedThroughProperty("rb3")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton vKiLZaOSE4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ProgressBar1")]
	private ProgressBar veRLiRH6eJ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbPesquisa")]
	private TextBox WArLS0waTR;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btSeleciona")]
	private Button y2gL48INxR;

	[CompilerGenerated]
	[AccessedThroughProperty("btVerificar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button DIQLCuGVli;

	[AccessedThroughProperty("btApagarCruzamentos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button iUtLY65lKx;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbAterrarBlindagem")]
	private CheckBox EieLrQ51va;

	private DeclaracoesFiacao.structurePnRev[] hbhL95t3Lt;

	private DeclaracoesFiacao.structureRevisoes[] JTPLzFiiWg;

	private DeclaracoesInterligacao.structureRI[] sHXwWbN77q;

	private DeclaracoesInterligacao.structureBornesInseridos[] ncZwpyZ3rI;

	private string s5OwTXryGm;

	private int ksowJIpiNZ;

	private bool gR2whMp1HS;

	private bool uQmwo9bLmH;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return plULcTN3KU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Lo3LdMYQV9;
			DataGridView dataGridView = plULcTN3KU;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			plULcTN3KU = value;
			dataGridView = plULcTN3KU;
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
			return HjFLKfjXvy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = bPHL6tpdpX;
			DataGridView dataGridView = HjFLKfjXvy;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			HjFLKfjXvy = value;
			dataGridView = HjFLKfjXvy;
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
			return NbxLew2p9N;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ACsLb5Exxw;
			Button button = NbxLew2p9N;
			if (button != null)
			{
				button.Click -= value2;
			}
			NbxLew2p9N = value;
			button = NbxLew2p9N;
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
			return MehL3risDj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MehL3risDj = value;
		}
	}

	internal virtual RadioButton rbCadastro
	{
		[CompilerGenerated]
		get
		{
			return NUGLnptuOZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = bIULvZ9wCr;
			RadioButton radioButton = NUGLnptuOZ;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			NUGLnptuOZ = value;
			radioButton = NUGLnptuOZ;
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
			return jaXL1No1PZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jaXL1No1PZ = value;
		}
	}

	internal virtual DataGridView dgRegua
	{
		[CompilerGenerated]
		get
		{
			return oLALlZG55w;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			oLALlZG55w = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return rA5L5XLn7C;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rA5L5XLn7C = value;
		}
	}

	internal virtual RadioButton rb1
	{
		[CompilerGenerated]
		get
		{
			return wj5L09hbeV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			wj5L09hbeV = value;
		}
	}

	internal virtual Button btApagaRegua
	{
		[CompilerGenerated]
		get
		{
			return QcWLRvET7H;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = C0ILMVN17F;
			Button button = QcWLRvET7H;
			if (button != null)
			{
				button.Click -= value2;
			}
			QcWLRvET7H = value;
			button = QcWLRvET7H;
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
			return hBFLmZ9MoU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = yP5LI757Ud;
			Button button = hBFLmZ9MoU;
			if (button != null)
			{
				button.Click -= value2;
			}
			hBFLmZ9MoU = value;
			button = hBFLmZ9MoU;
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
			return EDhLXq3pOs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = jJAL7DPqOd;
			Button button = EDhLXq3pOs;
			if (button != null)
			{
				button.Click -= value2;
			}
			EDhLXq3pOs = value;
			button = EDhLXq3pOs;
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
			return C5ZLUaUUXR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = faBLaeBIrw;
			Button button = C5ZLUaUUXR;
			if (button != null)
			{
				button.Click -= value2;
			}
			C5ZLUaUUXR = value;
			button = C5ZLUaUUXR;
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
			return wmBLyGdcXm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			wmBLyGdcXm = value;
		}
	}

	internal virtual GroupBox GroupBox4
	{
		[CompilerGenerated]
		get
		{
			return THlLgDN9TQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			THlLgDN9TQ = value;
		}
	}

	internal virtual GroupBox GroupBox5
	{
		[CompilerGenerated]
		get
		{
			return E7aLAAl3ub;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			E7aLAAl3ub = value;
		}
	}

	internal virtual Button btCabos
	{
		[CompilerGenerated]
		get
		{
			return hAcLsvwi8P;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = l0fLqtRO3b;
			Button button = hAcLsvwi8P;
			if (button != null)
			{
				button.Click -= value2;
			}
			hAcLsvwi8P = value;
			button = hAcLsvwi8P;
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
			return qvoLBUtfdd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qvoLBUtfdd = value;
		}
	}

	internal virtual Button btApagarVeias
	{
		[CompilerGenerated]
		get
		{
			return UAqLVgZeV7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = YaULNQOj9Q;
			Button button = UAqLVgZeV7;
			if (button != null)
			{
				button.Click -= value2;
			}
			UAqLVgZeV7 = value;
			button = UAqLVgZeV7;
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
			return jxILuwGaUq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = JVhL84tvE9;
			Button button = jxILuwGaUq;
			if (button != null)
			{
				button.Click -= value2;
			}
			jxILuwGaUq = value;
			button = jxILuwGaUq;
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
			return dMHLERAuCM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = dM4LFjPXwk;
			Button button = dMHLERAuCM;
			if (button != null)
			{
				button.Click -= value2;
			}
			dMHLERAuCM = value;
			button = dMHLERAuCM;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual RadioButton rb3
	{
		[CompilerGenerated]
		get
		{
			return vKiLZaOSE4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			vKiLZaOSE4 = value;
		}
	}

	internal virtual ProgressBar ProgressBar1
	{
		[CompilerGenerated]
		get
		{
			return veRLiRH6eJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			veRLiRH6eJ = value;
		}
	}

	internal virtual TextBox tbPesquisa
	{
		[CompilerGenerated]
		get
		{
			return WArLS0waTR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = S3jLfddyKW;
			TextBox textBox = WArLS0waTR;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			WArLS0waTR = value;
			textBox = WArLS0waTR;
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
			return y2gL48INxR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Eg4LO7Panw;
			Button button = y2gL48INxR;
			if (button != null)
			{
				button.Click -= value2;
			}
			y2gL48INxR = value;
			button = y2gL48INxR;
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
			return DIQLCuGVli;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = iQnLLoSj9W;
			Button button = DIQLCuGVli;
			if (button != null)
			{
				button.Click -= value2;
			}
			DIQLCuGVli = value;
			button = DIQLCuGVli;
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
			return iUtLY65lKx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ujSLQN2PoA;
			Button button = iUtLY65lKx;
			if (button != null)
			{
				button.Click -= value2;
			}
			iUtLY65lKx = value;
			button = iUtLY65lKx;
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
			return EieLrQ51va;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EieLrQ51va = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && MyCLPEq9lK != null)
			{
				MyCLPEq9lK.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void kIcLGpBXxM()
	{
		MyCLPEq9lK = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		dgRevisao = new DataGridView();
		dgEquip = new DataGridView();
		btAdicionarRegua = new Button();
		FDqpBiUmZij(new ToolTip(MyCLPEq9lK));
		GroupBox2 = new GroupBox();
		rbCadastro = new RadioButton();
		rbCrescente = new RadioButton();
		dgRegua = new DataGridView();
		GroupBox1 = new GroupBox();
		rb3 = new RadioButton();
		rb1 = new RadioButton();
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
		GroupBox1.SuspendLayout();
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
		dgRegua.Size = new Size(242, 162);
		dgRegua.TabIndex = 48;
		GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox1.Controls.Add(rb3);
		GroupBox1.Controls.Add(rb1);
		GroupBox1.Location = new Point(155, 336);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(242, 49);
		GroupBox1.TabIndex = 49;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "Posição";
		rb3.AutoSize = true;
		rb3.Location = new Point(129, 20);
		rb3.Name = "rb3";
		rb3.Size = new Size(40, 17);
		rb3.TabIndex = 52;
		rb3.TabStop = true;
		rb3.Text = "rb3";
		rb3.UseVisualStyleBackColor = true;
		rb1.AutoSize = true;
		rb1.Location = new Point(17, 19);
		rb1.Name = "rb1";
		rb1.Size = new Size(40, 17);
		rb1.TabIndex = 50;
		rb1.TabStop = true;
		rb1.Text = "rb1";
		rb1.UseVisualStyleBackColor = true;
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
		ProgressBar1.Location = new Point(155, 319);
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
		Controls.Add(GroupBox1);
		Controls.Add(dgRegua);
		Controls.Add(GroupBox2);
		Controls.Add(dgEquip);
		Controls.Add(dgRevisao);
		MaximumSize = new Size(420, 1200);
		MinimumSize = new Size(420, 580);
		Name = "frmRelatorio_DIEnergisaMS";
		ShowInTaskbar = false;
		Text = "Diagrama de Interligação Energisa MS";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		((ISupportInitialize)dgRegua).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
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
		return J6nL2khgZk;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		J6nL2khgZk = WithEventsValue;
	}

	public frmRelatorio_DIEnergisaMS()
	{
		hbhL95t3Lt = new DeclaracoesFiacao.structurePnRev[1];
		JTPLzFiiWg = new DeclaracoesFiacao.structureRevisoes[1];
		s5OwTXryGm = "";
		ksowJIpiNZ = 0;
		gR2whMp1HS = false;
		uQmwo9bLmH = false;
		try
		{
			if (!Geral.ExisteForm("frmRelatorio_DIEnergisaMS"))
			{
				kIcLGpBXxM();
				W6tLHJnCKe(_0020: false);
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1523]);
				GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1439]);
				GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1419]);
				GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 788]);
				GroupBox4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1444]);
				GroupBox5.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 514]);
				GroupBox6.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1445]);
				rbCrescente.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1420]);
				rbCadastro.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1421]);
				rb1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 384]);
				rb3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 386]);
				w8dpBZ0kvSD().SetToolTip(btSeleciona, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1900]));
				w8dpBZ0kvSD().SetToolTip(btApagarCruzamentos, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1901]));
				w8dpBZ0kvSD().SetToolTip(btVerificar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1902]));
				cDadosAccess.carregaDadosDWG();
				Application.ShowModelessDialog((Form)this);
				sHXwWbN77q = new DeclaracoesInterligacao.structureRI[1];
				sHXwWbN77q[0].Bornes = new DeclaracoesInterligacao.borneRI[1];
				ncZwpyZ3rI = new DeclaracoesInterligacao.structureBornesInseridos[1];
				formataDGRevisao();
				formataDGEquip();
				rbCrescente.Checked = true;
				rb1.Checked = true;
				cbAterrarBlindagem.Checked = true;
				kYTLk2eLop();
				W6tLHJnCKe(_0020: true);
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

	private void W6tLHJnCKe(bool P_0)
	{
		GroupBox1.Enabled = P_0;
		GroupBox2.Enabled = P_0;
		GroupBox3.Enabled = P_0;
		GroupBox4.Enabled = P_0;
		GroupBox5.Enabled = P_0;
		GroupBox6.Enabled = P_0;
		btSincroniza.Enabled = P_0;
		btSeleciona.Enabled = P_0;
	}

	private void kYTLk2eLop()
	{
		JTPLzFiiWg = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			cDadosAccessInterligacao3.CarregaRevisoesCabos4(ref JTPLzFiiWg);
			gR2whMp1HS = true;
			dgRevisao.Rows.Clear();
			gR2whMp1HS = false;
			int num = Information.UBound(JTPLzFiiWg);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				dgRevisao.Rows.Add(JTPLzFiiWg[i].revisao, JTPLzFiiWg[i].criador, JTPLzFiiWg[i].data);
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

	private void Lo3LdMYQV9(object P_0, EventArgs P_1)
	{
		uQmwo9bLmH = true;
		dgEquip.Rows.Clear();
		uQmwo9bLmH = false;
		if (!gR2whMp1HS)
		{
			sQxLDj2SyA(_0020: false);
		}
	}

	private void S3jLfddyKW(object P_0, KeyEventArgs P_1)
	{
		if (((P_1.KeyValue == 13) | (Operators.CompareString(tbPesquisa.Text.Trim(), "", TextCompare: true) == 0)) && !gR2whMp1HS)
		{
			sQxLDj2SyA(_0020: true);
		}
	}

	private void sQxLDj2SyA(bool P_0)
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
			s5OwTXryGm = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
			uQmwo9bLmH = true;
			dgEquip.Rows.Clear();
			uQmwo9bLmH = false;
			int num = Information.UBound(hbhL95t3Lt);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(hbhL95t3Lt[i].revisao, s5OwTXryGm, TextCompare: true) == 0)
				{
					string text = Dicionario.BuscaNomeDoPainel(hbhL95t3Lt[i].painel);
					if (!P_0)
					{
						dgEquip.Rows.Add(hbhL95t3Lt[i].painel, text);
					}
					else if (text.ToUpper().Contains(tbPesquisa.Text.ToUpper().Trim()))
					{
						dgEquip.Rows.Add(hbhL95t3Lt[i].painel, text);
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
		hbhL95t3Lt = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			if (Information.UBound(JTPLzFiiWg) > 0)
			{
				int num = Information.UBound(JTPLzFiiWg);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessInterligacao3.CarregaPnRev(JTPLzFiiWg[i].revisao, ref hbhL95t3Lt);
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

	private void bIULvZ9wCr(object P_0, EventArgs P_1)
	{
		hFLLtSHjZQ();
	}

	private void bPHL6tpdpX(object P_0, EventArgs P_1)
	{
		hFLLtSHjZQ();
	}

	private void hFLLtSHjZQ()
	{
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			if (dgEquip.SelectedRows.Count == 1)
			{
				W6tLHJnCKe(_0020: false);
				ksowJIpiNZ = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
				formataDGRegua();
				sHXwWbN77q = new DeclaracoesInterligacao.structureRI[1];
				sHXwWbN77q[0].Bornes = new DeclaracoesInterligacao.borneRI[1];
				cDadosAccessInterligacao3.CarregaReguas(s5OwTXryGm, ksowJIpiNZ, ref sHXwWbN77q);
				cDadosAccessInterligacao3.CarregaReguasPortas(s5OwTXryGm, ksowJIpiNZ, ref sHXwWbN77q);
				cDadosAccessInterligacao3.CarregaBornesReguas(s5OwTXryGm, ksowJIpiNZ, ref sHXwWbN77q, rbCadastro.Checked);
				ProgressBar1.Minimum = 0;
				ProgressBar1.Maximum = checked(T84Lj17CEX() * 2);
				ProgressBar1.Value = 0;
				ProgressBar1.Step = 1;
				string revisao = s5OwTXryGm;
				int painel = ksowJIpiNZ;
				ref DeclaracoesInterligacao.structureRI[] mReguas = ref sHXwWbN77q;
				ProgressBar ProgressBar = ProgressBar1;
				cDadosAccessInterligacao3.CarregaCabosNosBornesRI(revisao, painel, ref mReguas, ref ProgressBar, -1);
				ProgressBar1 = ProgressBar;
				string revisao2 = s5OwTXryGm;
				int painel2 = ksowJIpiNZ;
				ref DeclaracoesInterligacao.structureRI[] mReguas2 = ref sHXwWbN77q;
				ProgressBar = ProgressBar1;
				cDadosAccessInterligacao3.CarregaJumpersNosBornesRI(revisao2, painel2, ref mReguas2, ref ProgressBar);
				ProgressBar1 = ProgressBar;
				jbLLxTxLxn();
				BbLLwrcXSf();
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
			W6tLHJnCKe(_0020: true);
		}
	}

	private int T84Lj17CEX()
	{
		int num = 0;
		int num2 = Information.UBound(sHXwWbN77q);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				if (!Information.IsNothing(sHXwWbN77q[i].Bornes))
				{
					num += sHXwWbN77q[i].Bornes.Length - 1;
				}
			}
			return num;
		}
	}

	private void iQnLLoSj9W(object P_0, EventArgs P_1)
	{
		BbLLwrcXSf();
	}

	private void BbLLwrcXSf()
	{
		ncZwpyZ3rI = new DeclaracoesInterligacao.structureBornesInseridos[1];
		ClsAranha.ContaBornesReguas(ksowJIpiNZ, ref ncZwpyZ3rI);
		checked
		{
			int num = dgRegua.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				string right = Conversions.ToString(dgRegua.Rows[i].Cells[1].Value);
				string right2 = Conversions.ToString(dgRegua.Rows[i].Cells[2].Value);
				int num2 = Conversions.ToInteger(dgRegua.Rows[i].Cells[3].Value);
				bool flag = false;
				int num3 = Information.UBound(ncZwpyZ3rI);
				for (int j = 1; j <= num3; j++)
				{
					if (!((Operators.CompareString(ncZwpyZ3rI[j].Tag, right, TextCompare: true) == 0) & (Operators.CompareString(ncZwpyZ3rI[j].NRegua, right2, TextCompare: true) == 0)))
					{
						continue;
					}
					if (num2 != ncZwpyZ3rI[j].Qtde)
					{
						if ((num2 > ncZwpyZ3rI[j].Qtde) & (ncZwpyZ3rI[j].Qtde > 0))
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

	private void jbLLxTxLxn()
	{
		if (Information.UBound(sHXwWbN77q) == 0)
		{
			return;
		}
		List<int> list = new List<int>();
		try
		{
			int num = Information.UBound(sHXwWbN77q);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Information.IsNothing(sHXwWbN77q[i].Bornes))
				{
					if (!list.Contains(sHXwWbN77q[i].DWG))
					{
						list.Add(sHXwWbN77q[i].DWG);
					}
					continue;
				}
				int num2 = Information.UBound(sHXwWbN77q[i].Bornes);
				dgRegua.Rows.Add(sHXwWbN77q[i].Tipo, sHXwWbN77q[i].Tag, sHXwWbN77q[i].NRegua, num2);
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

	private void ACsLb5Exxw(object P_0, EventArgs P_1)
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0547: Unknown result type (might be due to invalid IL or missing references)
		//IL_0548: Unknown result type (might be due to invalid IL or missing references)
		//IL_056f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0574: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0592: Unknown result type (might be due to invalid IL or missing references)
		//IL_0594: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fa: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			try
			{
				List<string> lPaginasColunas = new List<string>();
				clsDIEnergisaMS.buscaPaginasColuna(ref lPaginasColunas);
				DeclaracoesInterligacao.structureRI structureRI = default;
				if (dgEquip.SelectedRows.Count == 0 || dgRegua.SelectedRows.Count == 0)
				{
					return;
				}
				DeclaracoesGeral.Reguas RH = default;
				if (XDataGeral.LeXDataReguaH(ref RH))
				{
					Point3d ptCol = new Point3d(RH.Pti.X + (RH.LarguraBase - RH.Pti.X) / 2.0 - 10.0, 272.0, 0.0);
					Point3d ptCol2 = new Point3d(RH.Pti.X + (RH.LarguraBase - RH.Pti.X) - 10.0, 272.0, 0.0);
					string text = Conversions.ToString(dgRegua.SelectedRows[0].Cells[1].Value);
					string text2 = Conversions.ToString(dgRegua.SelectedRows[0].Cells[2].Value);
					int num = Information.UBound(sHXwWbN77q);
					for (int i = 1; i <= num; i++)
					{
						if ((Operators.CompareString(sHXwWbN77q[i].Tag, text, TextCompare: true) == 0) & (Operators.CompareString(sHXwWbN77q[i].NRegua, text2, TextCompare: true) == 0))
						{
							structureRI = sHXwWbN77q[i];
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
					bool bInsereNomeRegua = false;
					Point3d val = new Point3d(RH.Pti.X + 10.0, 246.0, 0.0);
					Point3d val2 = new Point3d(RH.Pti.X + (RH.LarguraBase - RH.Pti.X) / 2.0, 246.0, 0.0);
					Point3d ptIns = default;
					if (!rb1.Checked)
					{
						if (rb3.Checked)
						{
							ptIns = val2;
							num4 = 3;
						}
					}
					else
					{
						ptIns = val;
						num4 = 1;
					}
					List<string> lBornes = new List<string>();
					Point3d pt = default;
					if (clsDIEnergisaMS.reguaExiste(ksowJIpiNZ, text, text2))
					{
						DeclaracoesInterligacao.PosborneAranha ubn = default;
						if (!clsDIEnergisaMS.BuscaUltimoBorne(ksowJIpiNZ, text, text2, ref ubn, ref lBornes))
						{
							return;
						}
						Pagina.AtivaPagina(ubn.Pagina);
						num4 = ubn.Posicao;
						ptIns = ubn.PtIns;
						num2 = (int)Math.Round((246.0 - ubn.PtIns.Y) / 5.0);
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
					else if (clsDIEnergisaMS.outraReguaExiste(DeclaracoesGeral.ativo.Pagina, ref pt, num4))
					{
						ptIns = new Point3d(pt.X, pt.Y - 20.0, 0.0);
						num2 = (int)Math.Round((246.0 - ptIns.Y) / 5.0);
						if (num2 >= 40)
						{
							return;
						}
						bInsereNomeRegua = true;
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
											num4 += 2;
											if (num4 == 5)
											{
												num4 = 1;
												string text3 = Pagina.BuscaProximaPaginaValida(DeclaracoesGeral.ativo.Pagina);
												if (Operators.CompareString(text3, "", TextCompare: true) != 0)
												{
													Pagina.AtivaPagina(text3);
												}
												else if (!Pagina.criarUmaNovaPagina())
												{
													goto IL_05df;
												}
												clsDIEnergisaMS.insereColunasSePrecisar(ref lPaginasColunas, ptCol, ptCol2);
											}
											if (num4 == 1)
											{
												ptIns = val;
											}
											else if (num4 == 3)
											{
												ptIns = val2;
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
									clsDIEnergisaMS.insereColunasSePrecisar(ref lPaginasColunas, ptCol, ptCol2);
								}
								DeclaracoesInterligacao.borneAranha bn = new DeclaracoesInterligacao.borneAranha
								{
									Revisao = s5OwTXryGm,
									Painel = ksowJIpiNZ,
									Tag = text,
									NRegua = text2,
									Borne = structureRI.Bornes[num6].Borne,
									TipoBorne = structureRI.Bornes[num6].TipoBorne,
									Ordem = structureRI.Bornes[num6].Ordem,
									Posicao = num4
								};
								string text4 = "";
								text4 = ((bn.TipoBorne == 0) ? "BorneSimples.DWG" : "BorneDuplo.DWG");
								if (!File.Exists(DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Interligação\\Energisa\\" + text4))
								{
									break;
								}
								if (num2 == 0)
								{
									bInsereNomeRegua = true;
								}
								clsDIEnergisaMS.InserirBorneAranha(text4, bn, ptIns, bInsereNomeRegua);
								bInsereNomeRegua = false;
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
						goto IL_05df;
						IL_05df:
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

	private void C0ILMVN17F(object P_0, EventArgs P_1)
	{
		string tag = Conversions.ToString(dgRegua.SelectedRows[0].Cells[1].Value);
		string nRegua = Conversions.ToString(dgRegua.SelectedRows[0].Cells[2].Value);
		clsDIEnergisaMS.ApagaRegua(s5OwTXryGm, ksowJIpiNZ, tag, nRegua);
		Application.UpdateScreen();
	}

	private void Eg4LO7Panw(object P_0, EventArgs P_1)
	{
		string rev = "";
		int painel = 0;
		checked
		{
			if (clsDIEnergisaMS.SelecionaBorne(ref rev, ref painel))
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

	private void yP5LI757Ud(object P_0, EventArgs P_1)
	{
		DeclaracoesInterligacao.borneJ[] mBornesJ = new DeclaracoesInterligacao.borneJ[1];
		DeclaracoesInterligacao.jumper[] mJumpers = new DeclaracoesInterligacao.jumper[1];
		if (!clsDIEnergisaMS.carregaBornesJ(s5OwTXryGm, ksowJIpiNZ, ref mBornesJ))
		{
			return;
		}
		clsDIEnergisaMS.buscaJumpers(ref mBornesJ, ref mJumpers, ref sHXwWbN77q);
		clsDIEnergisaMS.ApagaJumper(s5OwTXryGm, ksowJIpiNZ);
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
					clsDIEnergisaMS.desenhaJumper2(s5OwTXryGm, ksowJIpiNZ, ref mBornesJ, ref mJumpers, i);
				}
			}
			else
			{
				clsDIEnergisaMS.desenhaJumper1(s5OwTXryGm, ksowJIpiNZ, ref mBornesJ, ref mJumpers, i);
			}
		}
		Application.UpdateScreen();
	}

	private void jJAL7DPqOd(object P_0, EventArgs P_1)
	{
		clsDIEnergisaMS.ApagaJumper(s5OwTXryGm, ksowJIpiNZ);
		Application.UpdateScreen();
	}

	private void l0fLqtRO3b(object P_0, EventArgs P_1)
	{
		DeclaracoesInterligacao.borneJ[] mBornesJ = new DeclaracoesInterligacao.borneJ[1];
		DeclaracoesInterligacao.caboAranha[] mCabos = new DeclaracoesInterligacao.caboAranha[1];
		List<string> lCabosInseridos = new List<string>();
		if (clsDIEnergisaMS.carregaBornesJ(s5OwTXryGm, ksowJIpiNZ, ref mBornesJ))
		{
			clsDIEnergisaMS.carregaCabosInseridos(s5OwTXryGm, ksowJIpiNZ, ref lCabosInseridos);
			clsDIEnergisaMS.carregaCabos(s5OwTXryGm, ref sHXwWbN77q, ref mBornesJ, ref mCabos);
			clsDIEnergisaMS.insereCabos(s5OwTXryGm, ksowJIpiNZ, ref mCabos, lCabosInseridos, cbAterrarBlindagem.Checked);
			Application.UpdateScreen();
		}
	}

	private void faBLaeBIrw(object P_0, EventArgs P_1)
	{
		clsDIEnergisaMS.ApagaCabos(s5OwTXryGm, ksowJIpiNZ);
		clsDIEnergisaMS.ApagaVeias(s5OwTXryGm, ksowJIpiNZ);
		Application.UpdateScreen();
	}

	private void JVhL84tvE9(object P_0, EventArgs P_1)
	{
		btVeias.Enabled = false;
		DeclaracoesInterligacao.borneJ[] mBornesJ = new DeclaracoesInterligacao.borneJ[1];
		DeclaracoesInterligacao.caboAranha[] mCabos = new DeclaracoesInterligacao.caboAranha[1];
		List<string> lCabosInseridos = new List<string>();
		DeclaracoesInterligacao.cruzamentoCaboAranha[] mInfoVeias = new DeclaracoesInterligacao.cruzamentoCaboAranha[1];
		if (clsDIEnergisaMS.carregaBornesJ(s5OwTXryGm, ksowJIpiNZ, ref mBornesJ))
		{
			clsDIEnergisaMS.AtualizaBornesJ(s5OwTXryGm, ksowJIpiNZ, ref mBornesJ);
			clsDIEnergisaMS.carregaCabosInseridosViaVeias(s5OwTXryGm, ksowJIpiNZ, ref lCabosInseridos);
			clsDIEnergisaMS.carregaCabosDWG(s5OwTXryGm, ksowJIpiNZ, ref mCabos);
			clsDIEnergisaMS.relacionaCabosBornes(ksowJIpiNZ, ref sHXwWbN77q, ref mBornesJ, ref mCabos);
			clsDIEnergisaMS.verificaErro(mCabos);
			clsDIEnergisaMS.insereVeias(s5OwTXryGm, ksowJIpiNZ, ref mBornesJ, ref mCabos, ref mInfoVeias, lCabosInseridos);
			clsDIEnergisaMS.insereVeias2(s5OwTXryGm, ksowJIpiNZ, ref mBornesJ, ref mCabos, ref mInfoVeias, lCabosInseridos);
			Application.UpdateScreen();
		}
		btVeias.Enabled = true;
	}

	private void YaULNQOj9Q(object P_0, EventArgs P_1)
	{
		clsDIEnergisaMS.ApagaVeias(s5OwTXryGm, ksowJIpiNZ);
		Application.UpdateScreen();
	}

	private void dM4LFjPXwk(object P_0, EventArgs P_1)
	{
		DeclaracoesInterligacao.caboSync[] mCabosSync = new DeclaracoesInterligacao.caboSync[1];
		DeclaracoesInterligacao.caboSync[] mTodosCabosSync = new DeclaracoesInterligacao.caboSync[1];
		cDadosAccess.carregaDadosDWG();
		clsDIEnergisaMS.carregaTodosCabosDWG(s5OwTXryGm, ref mCabosSync);
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
		cDadosAccessInterligacao3.ApagaCabosRevPn(s5OwTXryGm, ref lPn);
		cDadosAccessInterligacao3.exportaCabos(s5OwTXryGm, ref mCabosSync);
		cDadosAccessInterligacao3.leCabos(s5OwTXryGm, ref mTodosCabosSync);
		clsDIEnergisaMS.LimpaCruzamentoCabos();
		clsDIEnergisaMS.SincronizaCabos(s5OwTXryGm, mTodosCabosSync);
		cDadosAccessInterligacao3.fechaConexao();
		Application.UpdateScreen();
	}

	private void ujSLQN2PoA(object P_0, EventArgs P_1)
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
				uQmwo9bLmH = true;
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
				uQmwo9bLmH = false;
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
