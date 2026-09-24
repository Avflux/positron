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
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.Runtime;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmJumper : Form
{
	private IContainer CappGjF6Kww;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbPainel")]
	private ComboBox PJspGLGTJqu;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbPotencial")]
	private TextBox RKwpGwdd4eq;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbReterPotencial")]
	private CheckBox hCFpGxprHMD;

	[AccessedThroughProperty("btSelecionar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button GVtpGbceWdH;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btJumper")]
	[CompilerGenerated]
	private Button KBipGM6Hwoq;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btEnderecamento")]
	private Button c26pGO4no3j;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btEditar")]
	private Button NcspGIw8K1Y;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private Label xxqpG75G54R;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label2")]
	[CompilerGenerated]
	private Label t5ipGq9qjSp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox TD0pGa8PP1y;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip dhxpG89XUoR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox2")]
	private GroupBox gpVpGN42q97;

	[AccessedThroughProperty("rbOrdemInsercao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton BYwpGFsYhyf;

	[AccessedThroughProperty("rbOrdemPaginas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton LUapGQykttG;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btFundir")]
	[CompilerGenerated]
	private Button YxJpGPwhDhV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btJumperU")]
	private Button wb8pGcoOJO5;

	[AccessedThroughProperty("btJumperD")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button zCtpGKiV1ZC;

	[AccessedThroughProperty("btJumperL")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button mF7pGeoyLoQ;

	[AccessedThroughProperty("btJumperR")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button O0vpG2YhVN2;

	[AccessedThroughProperty("btSelecionarPainel")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button QgQpG3BkEZc;

	private DeclaracoesEntidades.StructureConexao pjkpGnTmDE8;

	private string beMpG1UUX8G;

	internal virtual ComboBox cbPainel
	{
		[CompilerGenerated]
		get
		{
			return PJspGLGTJqu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RRBpG6xNLmM;
			ComboBox comboBox = PJspGLGTJqu;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged -= value2;
			}
			PJspGLGTJqu = value;
			comboBox = PJspGLGTJqu;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual TextBox tbPotencial
	{
		[CompilerGenerated]
		get
		{
			return RKwpGwdd4eq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			RKwpGwdd4eq = value;
		}
	}

	internal virtual CheckBox cbReterPotencial
	{
		[CompilerGenerated]
		get
		{
			return hCFpGxprHMD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = nZ1pGtpMjdA;
			CheckBox checkBox = hCFpGxprHMD;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			hCFpGxprHMD = value;
			checkBox = hCFpGxprHMD;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button btSelecionar
	{
		[CompilerGenerated]
		get
		{
			return GVtpGbceWdH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RN8pGTcTdeh;
			Button button = GVtpGbceWdH;
			if (button != null)
			{
				button.Click -= value2;
			}
			GVtpGbceWdH = value;
			button = GVtpGbceWdH;
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
			return KBipGM6Hwoq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TcqpGhn8GnH;
			Button button = KBipGM6Hwoq;
			if (button != null)
			{
				button.Click -= value2;
			}
			KBipGM6Hwoq = value;
			button = KBipGM6Hwoq;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btEnderecamento
	{
		[CompilerGenerated]
		get
		{
			return c26pGO4no3j;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = b6jpGfSaDGa;
			Button button = c26pGO4no3j;
			if (button != null)
			{
				button.Click -= value2;
			}
			c26pGO4no3j = value;
			button = c26pGO4no3j;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btEditar
	{
		[CompilerGenerated]
		get
		{
			return NcspGIw8K1Y;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ta0pGDKbVs4;
			Button button = NcspGIw8K1Y;
			if (button != null)
			{
				button.Click -= value2;
			}
			NcspGIw8K1Y = value;
			button = NcspGIw8K1Y;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return xxqpG75G54R;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			xxqpG75G54R = value;
		}
	}

	internal virtual Label Label2
	{
		[CompilerGenerated]
		get
		{
			return t5ipGq9qjSp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			t5ipGq9qjSp = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return TD0pGa8PP1y;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TD0pGa8PP1y = value;
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return gpVpGN42q97;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			gpVpGN42q97 = value;
		}
	}

	internal virtual RadioButton rbOrdemInsercao
	{
		[CompilerGenerated]
		get
		{
			return BYwpGFsYhyf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			BYwpGFsYhyf = value;
		}
	}

	internal virtual RadioButton rbOrdemPaginas
	{
		[CompilerGenerated]
		get
		{
			return LUapGQykttG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LUapGQykttG = value;
		}
	}

	internal virtual Button btFundir
	{
		[CompilerGenerated]
		get
		{
			return YxJpGPwhDhV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = XGJpGvk5Ge1;
			Button button = YxJpGPwhDhV;
			if (button != null)
			{
				button.Click -= value2;
			}
			YxJpGPwhDhV = value;
			button = YxJpGPwhDhV;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btJumperU
	{
		[CompilerGenerated]
		get
		{
			return wb8pGcoOJO5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = vtwpGoYuYOP;
			Button button = wb8pGcoOJO5;
			if (button != null)
			{
				button.Click -= value2;
			}
			wb8pGcoOJO5 = value;
			button = wb8pGcoOJO5;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btJumperD
	{
		[CompilerGenerated]
		get
		{
			return zCtpGKiV1ZC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = S3mpGGjkItW;
			Button button = zCtpGKiV1ZC;
			if (button != null)
			{
				button.Click -= value2;
			}
			zCtpGKiV1ZC = value;
			button = zCtpGKiV1ZC;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btJumperL
	{
		[CompilerGenerated]
		get
		{
			return mF7pGeoyLoQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NNipGk7cemY;
			Button button = mF7pGeoyLoQ;
			if (button != null)
			{
				button.Click -= value2;
			}
			mF7pGeoyLoQ = value;
			button = mF7pGeoyLoQ;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btJumperR
	{
		[CompilerGenerated]
		get
		{
			return O0vpG2YhVN2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = e6npGHNqsRX;
			Button button = O0vpG2YhVN2;
			if (button != null)
			{
				button.Click -= value2;
			}
			O0vpG2YhVN2 = value;
			button = O0vpG2YhVN2;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btSelecionarPainel
	{
		[CompilerGenerated]
		get
		{
			return QgQpG3BkEZc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = e7NpGJuucvE;
			Button button = QgQpG3BkEZc;
			if (button != null)
			{
				button.Click -= value2;
			}
			QgQpG3BkEZc = value;
			button = QgQpG3BkEZc;
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
			if (disposing && CappGjF6Kww != null)
			{
				CappGjF6Kww.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void KX4pGpwwVFM()
	{
		CappGjF6Kww = new Container();
		cbPainel = new ComboBox();
		tbPotencial = new TextBox();
		cbReterPotencial = new CheckBox();
		btSelecionar = new Button();
		btJumper = new Button();
		btEnderecamento = new Button();
		btEditar = new Button();
		Label1 = new Label();
		Label2 = new Label();
		GroupBox1 = new GroupBox();
		btFundir = new Button();
		FDqpBiUmZij(new ToolTip(CappGjF6Kww));
		GroupBox2 = new GroupBox();
		rbOrdemInsercao = new RadioButton();
		rbOrdemPaginas = new RadioButton();
		btJumperU = new Button();
		btJumperD = new Button();
		btJumperL = new Button();
		btJumperR = new Button();
		btSelecionarPainel = new Button();
		GroupBox1.SuspendLayout();
		GroupBox2.SuspendLayout();
		SuspendLayout();
		cbPainel.FormattingEnabled = true;
		cbPainel.Location = new Point(12, 29);
		cbPainel.Name = "cbPainel";
		cbPainel.Size = new Size(208, 21);
		cbPainel.TabIndex = 8;
		tbPotencial.BackColor = Color.Gainsboro;
		tbPotencial.Location = new Point(12, 76);
		tbPotencial.Name = "tbPotencial";
		tbPotencial.ReadOnly = true;
		tbPotencial.Size = new Size(67, 20);
		tbPotencial.TabIndex = 10;
		cbReterPotencial.AutoSize = true;
		cbReterPotencial.Location = new Point(127, 76);
		cbReterPotencial.Name = "cbReterPotencial";
		cbReterPotencial.Size = new Size(99, 17);
		cbReterPotencial.TabIndex = 11;
		cbReterPotencial.Text = "Reter Potencial";
		cbReterPotencial.UseVisualStyleBackColor = true;
		btSelecionar.FlatStyle = FlatStyle.Flat;
		btSelecionar.ForeColor = SystemColors.Control;
		btSelecionar.Image = Resources.Select_32;
		btSelecionar.Location = new Point(85, 63);
		btSelecionar.Name = "btSelecionar";
		btSelecionar.Size = new Size(40, 40);
		btSelecionar.TabIndex = 12;
		btSelecionar.Text = "\\";
		btSelecionar.UseVisualStyleBackColor = true;
		btJumper.FlatStyle = FlatStyle.Flat;
		btJumper.ForeColor = SystemColors.Control;
		btJumper.Image = Resources.Jumper_32;
		btJumper.Location = new Point(212, 192);
		btJumper.Name = "btJumper";
		btJumper.Size = new Size(40, 40);
		btJumper.TabIndex = 13;
		btJumper.UseVisualStyleBackColor = true;
		btEnderecamento.FlatStyle = FlatStyle.Flat;
		btEnderecamento.ForeColor = SystemColors.Control;
		btEnderecamento.Image = Resources.EditaDePara;
		btEnderecamento.Location = new Point(13, 7);
		btEnderecamento.Name = "btEnderecamento";
		btEnderecamento.Size = new Size(40, 40);
		btEnderecamento.TabIndex = 14;
		btEnderecamento.UseVisualStyleBackColor = true;
		btEditar.FlatStyle = FlatStyle.Flat;
		btEditar.ForeColor = SystemColors.Control;
		btEditar.Image = Resources.Editar;
		btEditar.Location = new Point(72, 7);
		btEditar.Name = "btEditar";
		btEditar.Size = new Size(40, 40);
		btEditar.TabIndex = 15;
		btEditar.UseVisualStyleBackColor = true;
		Label1.AutoSize = true;
		Label1.Location = new Point(12, 9);
		Label1.Name = "Label1";
		Label1.Size = new Size(108, 13);
		Label1.TabIndex = 17;
		Label1.Text = "Equipamentos/Painel";
		Label2.AutoSize = true;
		Label2.Location = new Point(12, 57);
		Label2.Name = "Label2";
		Label2.Size = new Size(51, 13);
		Label2.TabIndex = 18;
		Label2.Text = "Potencial";
		GroupBox1.Controls.Add(btFundir);
		GroupBox1.Controls.Add(btEditar);
		GroupBox1.Controls.Add(btEnderecamento);
		GroupBox1.Location = new Point(8, 185);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(182, 57);
		GroupBox1.TabIndex = 20;
		GroupBox1.TabStop = false;
		btFundir.FlatStyle = FlatStyle.Flat;
		btFundir.ForeColor = SystemColors.Control;
		btFundir.Image = Resources.FundirCircuitos_32;
		btFundir.Location = new Point(128, 7);
		btFundir.Name = "btFundir";
		btFundir.Size = new Size(40, 40);
		btFundir.TabIndex = 17;
		btFundir.UseVisualStyleBackColor = true;
		GroupBox2.Controls.Add(rbOrdemInsercao);
		GroupBox2.Controls.Add(rbOrdemPaginas);
		GroupBox2.Location = new Point(8, 109);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(112, 70);
		GroupBox2.TabIndex = 22;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "Ordenar por";
		rbOrdemInsercao.AutoSize = true;
		rbOrdemInsercao.Location = new Point(7, 42);
		rbOrdemInsercao.Name = "rbOrdemInsercao";
		rbOrdemInsercao.Size = new Size(66, 17);
		rbOrdemInsercao.TabIndex = 24;
		rbOrdemInsercao.TabStop = true;
		rbOrdemInsercao.Text = "Inserção";
		rbOrdemInsercao.UseVisualStyleBackColor = true;
		rbOrdemPaginas.AutoSize = true;
		rbOrdemPaginas.Location = new Point(7, 19);
		rbOrdemPaginas.Name = "rbOrdemPaginas";
		rbOrdemPaginas.Size = new Size(63, 17);
		rbOrdemPaginas.TabIndex = 23;
		rbOrdemPaginas.TabStop = true;
		rbOrdemPaginas.Text = "Páginas";
		rbOrdemPaginas.UseVisualStyleBackColor = true;
		btJumperU.FlatStyle = FlatStyle.Flat;
		btJumperU.ForeColor = SystemColors.Control;
		btJumperU.Image = Resources.JumperU_32;
		btJumperU.Location = new Point(168, 99);
		btJumperU.Name = "btJumperU";
		btJumperU.Size = new Size(40, 40);
		btJumperU.TabIndex = 23;
		btJumperU.UseVisualStyleBackColor = true;
		btJumperD.FlatStyle = FlatStyle.Flat;
		btJumperD.ForeColor = SystemColors.Control;
		btJumperD.Image = Resources.JumperD_32;
		btJumperD.Location = new Point(168, 139);
		btJumperD.Name = "btJumperD";
		btJumperD.Size = new Size(40, 40);
		btJumperD.TabIndex = 24;
		btJumperD.UseVisualStyleBackColor = true;
		btJumperL.FlatStyle = FlatStyle.Flat;
		btJumperL.ForeColor = SystemColors.Control;
		btJumperL.Image = Resources.JumperL_32;
		btJumperL.Location = new Point(127, 116);
		btJumperL.Name = "btJumperL";
		btJumperL.Size = new Size(40, 40);
		btJumperL.TabIndex = 25;
		btJumperL.UseVisualStyleBackColor = true;
		btJumperR.FlatStyle = FlatStyle.Flat;
		btJumperR.ForeColor = SystemColors.Control;
		btJumperR.Image = Resources.JumperR_32;
		btJumperR.Location = new Point(212, 116);
		btJumperR.Name = "btJumperR";
		btJumperR.Size = new Size(40, 40);
		btJumperR.TabIndex = 26;
		btJumperR.UseVisualStyleBackColor = true;
		btSelecionarPainel.FlatStyle = FlatStyle.Flat;
		btSelecionarPainel.ForeColor = SystemColors.Control;
		btSelecionarPainel.Image = Resources.Select_32;
		btSelecionarPainel.Location = new Point(221, 14);
		btSelecionarPainel.Name = "btSelecionarPainel";
		btSelecionarPainel.Size = new Size(40, 40);
		btSelecionarPainel.TabIndex = 12;
		btSelecionarPainel.Text = "\\";
		btSelecionarPainel.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(261, 253);
		Controls.Add(btJumperR);
		Controls.Add(btJumperL);
		Controls.Add(btJumperD);
		Controls.Add(btJumperU);
		Controls.Add(GroupBox2);
		Controls.Add(GroupBox1);
		Controls.Add(Label2);
		Controls.Add(Label1);
		Controls.Add(btJumper);
		Controls.Add(btSelecionarPainel);
		Controls.Add(btSelecionar);
		Controls.Add(cbReterPotencial);
		Controls.Add(tbPotencial);
		Controls.Add(cbPainel);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "frmJumper";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Jumper Externo";
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return dhxpG89XUoR;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		dhxpG89XUoR = WithEventsValue;
	}

	public frmJumper()
	{
		beMpG1UUX8G = "";
		try
		{
			if (Geral.ExisteForm("frmJumper") || !clsAuxiliar.BancoValido())
			{
				return;
			}
			cDadosAccess.carregaDadosDWG();
			if (DeclaracoesGeral.arqAtivo.Indice != 0)
			{
				KX4pGpwwVFM();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 703]);
				Label1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 626]);
				Label2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 685]);
				cbReterPotencial.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 683]);
				rbOrdemPaginas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 684]);
				rbOrdemInsercao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 692]);
				GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 698]);
				w8dpBZ0kvSD().SetToolTip(btSelecionarPainel, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1949]));
				w8dpBZ0kvSD().SetToolTip(btJumper, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 704]));
				w8dpBZ0kvSD().SetToolTip(btJumperU, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 704]));
				w8dpBZ0kvSD().SetToolTip(btSelecionar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 705]));
				w8dpBZ0kvSD().SetToolTip(btEnderecamento, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 706]));
				w8dpBZ0kvSD().SetToolTip(btEditar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 707]));
				w8dpBZ0kvSD().SetToolTip(btFundir, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 708]));
				cbReterPotencial.Checked = false;
				rbOrdemPaginas.Checked = true;
				tbPotencial.Text = "0";
				ComboBox Combo = cbPainel;
				Dicionario.CarregaPaineis(ref Combo);
				cbPainel = Combo;
				Application.ShowModelessDialog((Form)this);
				if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
				{
					Left = 0;
				}
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

	private void RN8pGTcTdeh(object P_0, EventArgs P_1)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected Obj, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Invalid comparison between Unknown and I4
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected Obj, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		cbReterPotencial.Checked = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			try
			{
				BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				PromptEntityOptions val3 = new PromptEntityOptions("");
				val3.SetRejectMessage(Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 709])));
				((PromptOptions)val3).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 710]));
				val3.AddAllowedClass(typeof(Polyline), true);
				PromptEntityResult entity = editor.GetEntity(val3);
				if ((int)((PromptResult)entity).Status != -5002)
				{
					ObjectId objectId = entity.ObjectId;
					Polyline pl = (Polyline)objectId.GetObject((OpenMode)0);
					pjkpGnTmDE8 = default;
					if (XDataConexao.lerXDataConexao(ref pl, ref pjkpGnTmDE8) && pjkpGnTmDE8.Tipo == 4)
					{
						tbPotencial.Text = Conversions.ToString(pjkpGnTmDE8.Potencial);
						cbPainel.Text = Dicionario.BuscaNomeDoPainel(pjkpGnTmDE8.Painel);
						if (pjkpGnTmDE8.Enderecamento != 1)
						{
							if (pjkpGnTmDE8.Enderecamento == 2)
							{
								rbOrdemInsercao.Checked = true;
							}
						}
						else
						{
							rbOrdemPaginas.Checked = true;
						}
						beMpG1UUX8G = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
						cbReterPotencial.Checked = true;
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				val.Abort();
				ProjectData.ClearProjectError();
			}
			finally
			{
				mdiActiveDocument.SendStringToExecute("\u001b", true, false, false);
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		PointMonitorToolTips.StartMonitor();
	}

	private void e7NpGJuucvE(object P_0, EventArgs P_1)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected Obj, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected Obj, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected Obj, but got Unknown
		PointMonitorToolTips.StopMonitor();
		cbReterPotencial.Checked = false;
		Point3d ptInsert = default;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		_ = Application.DocumentManager.MdiActiveDocument.Editor;
		PointMonitorToolTips.StopMonitor();
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			ObjectId val2 = clsDispositivo.selDispositivoPrincipal(ref ptInsert, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1949]));
			if (!val2.IsNull)
			{
				Entity val3 = (Entity)val.GetObject(val2, (OpenMode)0);
				BlockReference val4 = (BlockReference)(object)((val3 is BlockReference) ? val3 : null);
				if (!Information.IsDBNull(val4))
				{
					if (Information.IsNothing(DeclaracoesGeral.dicPainel))
					{
						cDadosAccess.carregaPainelDicionario();
					}
					Entity ent = (Entity)(object)val4;
					string tipoImportado = "";
					string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
					val4 = (BlockReference)ent;
					string left = text;
					if ((Operators.CompareString(left, "E", TextCompare: true) == 0) | (Operators.CompareString(left, "B", TextCompare: true) == 0))
					{
						Dictionary<int, string> dicPainel = DeclaracoesGeral.dicPainel;
						ent = (Entity)(object)val4;
						short key = XDataDispositivo.BuscaPainelDispositivo(ref ent);
						val4 = (BlockReference)ent;
						string text2 = dicPainel[key];
						cbPainel.Text = text2;
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
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
		Application.DocumentManager.MdiActiveDocument.SendStringToExecute("\u001b", true, false, false);
		PointMonitorToolTips.StartMonitor();
	}

	private void TcqpGhn8GnH(object P_0, EventArgs P_1)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected Obj, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Invalid comparison between Unknown and I4
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Expected Obj, but got Unknown
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Expected Obj, but got Unknown
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Expected Obj, but got Unknown
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Invalid comparison between Unknown and I4
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d6: Invalid comparison between Unknown and I4
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Invalid comparison between Unknown and I4
		//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_04de: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f0: Expected Obj, but got Unknown
		//IL_04f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		//IL_050b: Expected Obj, but got Unknown
		//IL_050f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0759: Unknown result type (might be due to invalid IL or missing references)
		//IL_0779: Unknown result type (might be due to invalid IL or missing references)
		//IL_077e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0564: Unknown result type (might be due to invalid IL or missing references)
		//IL_0584: Unknown result type (might be due to invalid IL or missing references)
		//IL_0589: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		PromptPointOptions val = new PromptPointOptions("");
		DeclaracoesEntidades.StructureConexao conex = new DeclaracoesEntidades.StructureConexao
		{
			Tipo = 4,
			Aplicacao = 0,
			Nome = "",
			Handle = "",
			Tensao = "",
			Funcao = "",
			Jumper = "JUMPER",
			Usuario = Environment.UserName,
			Data = DateTime.Now.ToString(),
			Painel = checked((short)DeclaracoesGeral.ativo.Painel)
		};
		if (!rbOrdemPaginas.Checked)
		{
			if (rbOrdemInsercao.Checked)
			{
				conex.Enderecamento = 2;
			}
		}
		else
		{
			conex.Enderecamento = 1;
		}
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		((PromptOptions)val).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 688]));
		PromptPointResult point = editor.GetPoint(val);
		Point3d value;
		clsConexao clsConexao2;
		if ((int)((PromptResult)point).Status != -5002)
		{
			value = point.Value;
			string sTipo = "";
			int Potencial = 0;
			string Handle = "";
			string Secao = "";
			string Cor = "";
			int Aplicacao = 0;
			bool bpossuiRB = false;
			clsConexao2 = new clsConexao();
			Point3d pt = value;
			int num = default;
			short Painel = checked((short)num);
			bool flag = clsConexao2.verificaDispConex(pt, ref sTipo, ref Painel, ref Potencial, ref Handle, ref Secao, ref Cor, ref Aplicacao, ref bpossuiRB);
			num = Painel;
			if (flag)
			{
				string left = sTipo;
				if (Operators.CompareString(left, "E", TextCompare: true) != 0 && Operators.CompareString(left, "B", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left, "C", TextCompare: true) == 0 || Operators.CompareString(left, "J", TextCompare: true) == 0)
					{
						conex.Disp1 = false;
						goto IL_0209;
					}
					if (Operators.CompareString(left, "P", TextCompare: true) == 0 || Operators.CompareString(left, "A", TextCompare: true) == 0)
					{
						Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1403]), MsgBoxStyle.Exclamation);
					}
				}
				else if (num == conex.Painel)
				{
					if (!((Operators.CompareString(sTipo, "E", TextCompare: true) == 0) & !bpossuiRB))
					{
						conex.Disp1 = true;
						goto IL_0209;
					}
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1402]), MsgBoxStyle.Exclamation);
				}
				else
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 690]), MsgBoxStyle.Exclamation);
				}
			}
			else
			{
				conex.Disp1 = false;
				if (Operators.CompareString(sTipo, "I", TextCompare: true) != 0)
				{
					goto IL_0209;
				}
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 711]), MsgBoxStyle.Exclamation);
			}
		}
		goto IL_0917;
		IL_0917:
		PointMonitorToolTips.StartMonitor();
		return;
		IL_0209:
		Point2d val2 = value.Convert2d((PlanarEntity)new Plane());
		Polyline pl = new Polyline();
		((Entity)pl).SetDatabaseDefaults();
		((Entity)pl).ColorIndex = DeclaracoesGeral.Conf.CorConexao;
		pl.AddVertexAt(0, val2, 0.0, 0.0, 0.0);
		pl.AddVertexAt(1, val2, 0.0, 0.0, 0.0);
		DocumentLock val3 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val4 = database.TransactionManager.StartTransaction();
			try
			{
				int num2 = 1;
				try
				{
					short Painel2 = default;
					while (true)
					{
						Entity ent = (Entity)(object)pl;
						JigConexao jigConexao = new JigConexao(ref ent, num2);
						pl = (Polyline)ent;
						JigConexao jigConexao2 = jigConexao;
						hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
						PromptResult val5 = editor.Drag((Jig)(object)jigConexao2);
						PromptStatus status = val5.Status;
						if ((int)status == -5002)
						{
							if (pl.NumberOfVertices == 1)
							{
								break;
							}
						}
						else
						{
							if ((int)status == -5001)
							{
								break;
							}
							if ((int)status == 5100)
							{
								Point2d point2dAt = pl.GetPoint2dAt(checked(pl.NumberOfVertices - 1));
								pl.GetPoint2dAt(0);
								if (num2 == 1)
								{
									pl.AddVertexAt(pl.NumberOfVertices, point2dAt, 0.0, 0.0, 0.0);
									num2 = 1;
									continue;
								}
							}
						}
						Point3d point3dAt = pl.GetPoint3dAt(checked(pl.NumberOfVertices - 1));
						string sTipo2 = "";
						int Potencial2 = 0;
						string Handle2 = "";
						string Secao2 = "";
						string Cor2 = "";
						int Aplicacao2 = 0;
						bool bpossuiRB2 = false;
						if (clsConexao2.verificaDispConex(point3dAt, ref sTipo2, ref Painel2, ref Potencial2, ref Handle2, ref Secao2, ref Cor2, ref Aplicacao2, ref bpossuiRB2))
						{
							string left2 = sTipo2;
							if (Operators.CompareString(left2, "E", TextCompare: true) != 0 && Operators.CompareString(left2, "B", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left2, "C", TextCompare: true) != 0 && Operators.CompareString(left2, "J", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left2, "P", TextCompare: true) == 0 || Operators.CompareString(left2, "A", TextCompare: true) == 0)
									{
										Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1403]), MsgBoxStyle.Exclamation);
									}
									break;
								}
								conex.Disp2 = false;
							}
							else
							{
								if (Painel2 != conex.Painel)
								{
									Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 690]), MsgBoxStyle.Exclamation);
									break;
								}
								if ((Operators.CompareString(sTipo2, "E", TextCompare: true) == 0) & !bpossuiRB2)
								{
									Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1402]), MsgBoxStyle.Exclamation);
									break;
								}
								conex.Disp2 = true;
							}
						}
						else
						{
							conex.Disp2 = false;
							if (Operators.CompareString(sTipo2, "I", TextCompare: true) == 0)
							{
								Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 711]), MsgBoxStyle.Exclamation);
								break;
							}
						}
						if (!cbReterPotencial.Checked)
						{
							conex.Potencial = XDataConexao.BuscaPotencial();
							tbPotencial.Text = conex.Potencial.ToString();
							conex.Secao = DeclaracoesGeral.ativoRibbon.Secao;
							conex.Cor = DeclaracoesGeral.ativoRibbon.Cor;
							conex.Aplicacao = 0;
						}
						else
						{
							if (Conversions.ToInteger(tbPotencial.Text) <= 0)
							{
								break;
							}
							conex.Potencial = pjkpGnTmDE8.Potencial;
							conex.Secao = pjkpGnTmDE8.Secao;
							conex.Cor = pjkpGnTmDE8.Cor;
							conex.Aplicacao = pjkpGnTmDE8.Aplicacao;
							conex.Enderecamento = pjkpGnTmDE8.Enderecamento;
							conex.Painel = pjkpGnTmDE8.Painel;
						}
						cbReterPotencial.Checked = true;
						pjkpGnTmDE8 = default;
						pjkpGnTmDE8 = conex;
						BlockTable val6 = (BlockTable)val4.GetObject(database.BlockTableId, (OpenMode)0);
						BlockTableRecord val7 = (BlockTableRecord)val4.GetObject(((SymbolTable)val6)[BlockTableRecord.ModelSpace], (OpenMode)1);
						val7.AppendEntity((Entity)(object)pl);
						DeclaracoesGeral.bAnularEventos = true;
						val4.AddNewlyCreatedDBObject((DBObject)(object)pl, true);
						XDataConexao.GravarXDataConexao(ref pl, conex);
						if (!conex.Disp1)
						{
							DBText val8 = clsConexao2.criarTextoDePara(conex, pl, DeclaracoesGeral.ativo.Pagina, 1);
							val7.AppendEntity((Entity)(object)val8);
							DeclaracoesGeral.bAnularEventos = true;
							val4.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
							XDataConexao.GravarXDataAuxCircuito(ref val8, conex.Potencial, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString(), conex.Enderecamento, 2);
						}
						if (!conex.Disp2)
						{
							DBText val9 = clsConexao2.criarTextoDePara(conex, pl, DeclaracoesGeral.ativo.Pagina, 2);
							val7.AppendEntity((Entity)(object)val9);
							DeclaracoesGeral.bAnularEventos = true;
							val4.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
							XDataConexao.GravarXDataAuxCircuito(ref val9, conex.Potencial, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString(), conex.Enderecamento, 3);
						}
						break;
					}
					DeclaracoesGeral.bAnularEventos = true;
					val4.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					((DisposableWrapper)pl).Dispose();
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					val4.Abort();
					Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
					ProjectData.ClearProjectError();
				}
				finally
				{
					clsConexao.sincronizaCircuitos();
					mdiActiveDocument.SendStringToExecute("\u001b", true, false, false);
				}
			}
			finally
			{
				((IDisposable)val4)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val3)?.Dispose();
		}
		goto IL_0917;
	}

	private void vtwpGoYuYOP(object P_0, EventArgs P_1)
	{
		HHepGdF3mlF("U");
	}

	private void S3mpGGjkItW(object P_0, EventArgs P_1)
	{
		HHepGdF3mlF("D");
	}

	private void e6npGHNqsRX(object P_0, EventArgs P_1)
	{
		HHepGdF3mlF("R");
	}

	private void NNipGk7cemY(object P_0, EventArgs P_1)
	{
		HHepGdF3mlF("L");
	}

	private void HHepGdF3mlF(string P_0)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected Obj, but got Unknown
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Invalid comparison between Unknown and I4
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected Obj, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Expected Obj, but got Unknown
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Expected Obj, but got Unknown
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0401: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Unknown result type (might be due to invalid IL or missing references)
		//IL_040a: Invalid comparison between Unknown and I4
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_044a: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bb: Invalid comparison between Unknown and I4
		//IL_04c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c7: Invalid comparison between Unknown and I4
		//IL_0580: Unknown result type (might be due to invalid IL or missing references)
		//IL_058b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0592: Expected Obj, but got Unknown
		//IL_059b: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ad: Expected Obj, but got Unknown
		//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		PromptPointOptions val = new PromptPointOptions("");
		DeclaracoesEntidades.StructureConexao conex = new DeclaracoesEntidades.StructureConexao
		{
			Tipo = 4,
			Aplicacao = 0,
			Nome = "",
			Handle = "",
			Tensao = "",
			Funcao = "",
			Jumper = "JUMPER",
			Usuario = Environment.UserName,
			Data = DateTime.Now.ToString(),
			Painel = checked((short)DeclaracoesGeral.ativo.Painel)
		};
		if (!rbOrdemPaginas.Checked)
		{
			if (rbOrdemInsercao.Checked)
			{
				conex.Enderecamento = 2;
			}
		}
		else
		{
			conex.Enderecamento = 1;
		}
		cbReterPotencial.Checked = false;
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		((PromptOptions)val).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 688]));
		PromptPointResult point = editor.GetPoint(val);
		if ((int)((PromptResult)point).Status != -5002)
		{
			Point3d value = point.Value;
			string sTipo = "";
			int Potencial = 0;
			string Handle = "";
			string Secao = "";
			string Cor = "";
			int Aplicacao = 0;
			bool bpossuiRB = false;
			clsConexao clsConexao2 = new clsConexao();
			Point3d pt = value;
			int num = default;
			short Painel = checked((short)num);
			bool flag = clsConexao2.verificaDispConex(pt, ref sTipo, ref Painel, ref Potencial, ref Handle, ref Secao, ref Cor, ref Aplicacao, ref bpossuiRB);
			num = Painel;
			if (flag)
			{
				string left = sTipo;
				if (Operators.CompareString(left, "E", TextCompare: true) != 0 && Operators.CompareString(left, "B", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left, "C", TextCompare: true) != 0 && Operators.CompareString(left, "J", TextCompare: true) != 0 && (Operators.CompareString(left, "P", TextCompare: true) == 0 || Operators.CompareString(left, "A", TextCompare: true) == 0))
					{
						Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1403]), MsgBoxStyle.Exclamation);
					}
				}
				else if (num == conex.Painel)
				{
					if (!((Operators.CompareString(sTipo, "E", TextCompare: true) == 0) & !bpossuiRB))
					{
						conex.Disp1 = true;
						Point2d val2 = value.Convert2d((PlanarEntity)new Plane());
						Polyline val3 = new Polyline();
						((Entity)val3).SetDatabaseDefaults();
						((Entity)val3).ColorIndex = DeclaracoesGeral.Conf.CorConexao;
						val3.AddVertexAt(0, val2, 0.0, 0.0, 0.0);
						val3.AddVertexAt(1, val2, 0.0, 0.0, 0.0);
						val3.AddVertexAt(2, val2, 0.0, 0.0, 0.0);
						val3.AddVertexAt(3, val2, 0.0, 0.0, 0.0);
						DocumentLock val4 = Application.DocumentManager.MdiActiveDocument.LockDocument();
						try
						{
							Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
							Database database = Application.DocumentManager.MdiActiveDocument.Database;
							Transaction val5 = database.TransactionManager.StartTransaction();
							try
							{
								int tipo = 6;
								if (Operators.CompareString(P_0, "U", TextCompare: true) != 0)
								{
									if (Operators.CompareString(P_0, "D", TextCompare: true) != 0)
									{
										if (Operators.CompareString(P_0, "R", TextCompare: true) != 0)
										{
											if (Operators.CompareString(P_0, "L", TextCompare: true) == 0)
											{
												tipo = 9;
											}
										}
										else
										{
											tipo = 8;
										}
									}
									else
									{
										tipo = 7;
									}
								}
								else
								{
									tipo = 6;
								}
								try
								{
									Entity ent = (Entity)(object)val3;
									JigConexao jigConexao = new JigConexao(ref ent, tipo);
									val3 = (Polyline)ent;
									JigConexao jigConexao2 = jigConexao;
									hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
									PromptResult val6 = editor.Drag((Jig)(object)jigConexao2);
									PromptStatus status = val6.Status;
									if ((int)status != -5002)
									{
										if ((int)status == -5001)
										{
											goto IL_0669;
										}
										if ((int)status == 5100)
										{
										}
									}
									Point3d point3dAt = val3.GetPoint3dAt(checked(val3.NumberOfVertices - 1));
									string sTipo2 = "";
									int Potencial2 = 0;
									string Handle2 = "";
									string Secao2 = "";
									string Cor2 = "";
									int Aplicacao2 = 0;
									bool bpossuiRB2 = false;
									short Painel2 = default;
									if (clsConexao2.verificaDispConex(point3dAt, ref sTipo2, ref Painel2, ref Potencial2, ref Handle2, ref Secao2, ref Cor2, ref Aplicacao2, ref bpossuiRB2))
									{
										string left2 = sTipo2;
										if (Operators.CompareString(left2, "E", TextCompare: true) != 0 && Operators.CompareString(left2, "B", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left2, "C", TextCompare: true) == 0 || Operators.CompareString(left2, "J", TextCompare: true) == 0)
											{
												conex.Disp2 = false;
												goto IL_0518;
											}
											if (Operators.CompareString(left2, "P", TextCompare: true) == 0 || Operators.CompareString(left2, "A", TextCompare: true) == 0)
											{
												Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1403]), MsgBoxStyle.Exclamation);
											}
										}
										else if (Painel2 == conex.Painel)
										{
											if (!((Operators.CompareString(sTipo2, "E", TextCompare: true) == 0) & !bpossuiRB2))
											{
												conex.Disp2 = true;
												goto IL_0518;
											}
											Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1402]), MsgBoxStyle.Exclamation);
										}
										else
										{
											Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 690]), MsgBoxStyle.Exclamation);
										}
									}
									goto IL_0669;
									IL_0669:
									DeclaracoesGeral.bAnularEventos = true;
									val5.Commit();
									DeclaracoesGeral.bAnularEventos = false;
									((DisposableWrapper)val3).Dispose();
									goto end_IL_03ba;
									IL_0518:
									if (!cbReterPotencial.Checked)
									{
										conex.Potencial = XDataConexao.BuscaPotencial();
										tbPotencial.Text = conex.Potencial.ToString();
										conex.Secao = DeclaracoesGeral.ativoRibbon.Secao;
										conex.Cor = DeclaracoesGeral.ativoRibbon.Cor;
										cbReterPotencial.Checked = false;
										BlockTable val7 = (BlockTable)val5.GetObject(database.BlockTableId, (OpenMode)0);
										BlockTableRecord val8 = (BlockTableRecord)val5.GetObject(((SymbolTable)val7)[BlockTableRecord.ModelSpace], (OpenMode)1);
										val8.AppendEntity((Entity)(object)val3);
										DeclaracoesGeral.bAnularEventos = true;
										val5.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
										XDataConexao.GravarXDataConexao(ref val3, conex);
									}
									goto IL_0669;
									end_IL_03ba:;
								}
								catch (Exception ex)
								{
									ProjectData.SetProjectError(ex);
									Exception ex2 = ex;
									val5.Abort();
									Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
									ProjectData.ClearProjectError();
								}
								finally
								{
									clsConexao.sincronizaCircuitos();
									mdiActiveDocument.SendStringToExecute("\u001b", true, false, false);
								}
							}
							finally
							{
								((IDisposable)val5)?.Dispose();
							}
						}
						finally
						{
							((IDisposable)val4)?.Dispose();
						}
					}
					else
					{
						Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1402]), MsgBoxStyle.Exclamation);
					}
				}
				else
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 690]), MsgBoxStyle.Exclamation);
				}
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1459]), MsgBoxStyle.Exclamation);
			}
		}
		PointMonitorToolTips.StartMonitor();
	}

	private void b6jpGfSaDGa(object P_0, EventArgs P_1)
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected Obj, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected Obj, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected Obj, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(beMpG1UUX8G, "", TextCompare: true) == 0)
		{
			return;
		}
		clsConexao.ApagarTextosAuxiliaresCircuito(DeclaracoesGeral.ativo.Pagina, beMpG1UUX8G);
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					Entity val5 = (Entity)Geral.HandleToObject(beMpG1UUX8G);
					if (val5 != null)
					{
						Polyline val6 = (Polyline)(object)((val5 is Polyline) ? val5 : null);
						if (val6 != null)
						{
							clsConexao clsConexao2 = new clsConexao();
							if (!pjkpGnTmDE8.Disp1)
							{
								DBText val7 = clsConexao2.criarTextoDePara(pjkpGnTmDE8, val6, DeclaracoesGeral.ativo.Pagina, 1);
								val4.AppendEntity((Entity)(object)val7);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val7, true);
								XDataConexao.GravarXDataAuxCircuito(ref val7, pjkpGnTmDE8.Potencial, beMpG1UUX8G, pjkpGnTmDE8.Enderecamento, 2);
							}
							if (!pjkpGnTmDE8.Disp2)
							{
								DBText val8 = clsConexao2.criarTextoDePara(pjkpGnTmDE8, val6, DeclaracoesGeral.ativo.Pagina, 2);
								val4.AppendEntity((Entity)(object)val8);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
								XDataConexao.GravarXDataAuxCircuito(ref val8, pjkpGnTmDE8.Potencial, beMpG1UUX8G, pjkpGnTmDE8.Enderecamento, 3);
							}
						}
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					val2.Abort();
					Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
					ProjectData.ClearProjectError();
				}
				finally
				{
					clsConexao.sincronizaCircuitos();
					mdiActiveDocument.SendStringToExecute("\u001b", true, false, false);
				}
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

	private void ta0pGDKbVs4(object P_0, EventArgs P_1)
	{
		DeclaracoesEntidades.StructureConexao conex = new DeclaracoesEntidades.StructureConexao
		{
			Potencial = pjkpGnTmDE8.Potencial,
			Nome = "",
			Usuario = Environment.UserName,
			Data = DateTime.Now.ToString()
		};
		if (!rbOrdemPaginas.Checked)
		{
			if (rbOrdemInsercao.Checked)
			{
				conex.Enderecamento = 2;
			}
		}
		else
		{
			conex.Enderecamento = 1;
		}
		clsConexao clsConexao2 = new clsConexao();
		clsConexao2.editarDadosCircuitoDerivacaoJumper(conex);
		clsConexao2.editarTextoAuxiliarTipo123(conex);
		clsConexao.sincronizaCircuitos();
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
	}

	private void XGJpGvk5Ge1(object P_0, EventArgs P_1)
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected Obj, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Invalid comparison between Unknown and I4
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected Obj, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Expected Obj, but got Unknown
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Invalid comparison between Unknown and I4
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Expected Obj, but got Unknown
		//IL_0398: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		DeclaracoesEntidades.StructureConexao conex = default;
		DeclaracoesEntidades.StructureConexao conex2 = default;
		cbReterPotencial.Checked = false;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				try
				{
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
					PromptEntityOptions val4 = new PromptEntityOptions("");
					val4.SetRejectMessage(Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 709])));
					((PromptOptions)val4).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 710]));
					val4.AddAllowedClass(typeof(Polyline), true);
					PromptEntityResult entity = editor.GetEntity(val4);
					if ((int)((PromptResult)entity).Status == -5002)
					{
						goto IL_033a;
					}
					ObjectId objectId = entity.ObjectId;
					Polyline pl = (Polyline)objectId.GetObject((OpenMode)0);
					if (!XDataConexao.lerXDataConexao(ref pl, ref conex) || conex.Tipo != 4)
					{
						goto IL_033a;
					}
					if (!(conex.Disp1 & conex.Disp2))
					{
						cbPainel.Text = Dicionario.BuscaNomeDoPainel(conex.Painel);
						val4 = new PromptEntityOptions("");
						val4.SetRejectMessage(Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 709])));
						((PromptOptions)val4).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 713]));
						val4.AddAllowedClass(typeof(Polyline), true);
						entity = editor.GetEntity(val4);
						if ((int)((PromptResult)entity).Status == -5002)
						{
							goto IL_033a;
						}
						objectId = entity.ObjectId;
						Polyline pl2 = (Polyline)objectId.GetObject((OpenMode)0);
						if (!XDataConexao.lerXDataConexao(ref pl2, ref conex2) || conex2.Tipo != 4)
						{
							goto IL_033a;
						}
						if (!(conex2.Disp1 & conex2.Disp2))
						{
							if (Operators.CompareString(((Entity)pl).Layer, ((Entity)pl2).Layer, TextCompare: true) != 0 || (!(((Curve)pl).StartPoint == ((Curve)pl2).StartPoint) && !(((Curve)pl).StartPoint == ((Curve)pl2).EndPoint) && !(((Curve)pl).EndPoint == ((Curve)pl2).StartPoint) && !(((Curve)pl).EndPoint == ((Curve)pl2).EndPoint)))
							{
								if (conex.Painel == conex2.Painel)
								{
									int potencial = conex2.Potencial;
									conex2.Potencial = conex.Potencial;
									conex2.Nome = "";
									conex2.Secao = conex.Secao;
									conex2.Cor = conex.Cor;
									conex2.Aplicacao = conex.Aplicacao;
									conex2.Enderecamento = conex.Enderecamento;
									conex2.Usuario = Environment.UserName;
									conex2.Data = DateTime.Now.ToString();
									clsConexao clsConexao2 = new clsConexao();
									clsConexao2.trocarPotencial(potencial, conex2);
									clsConexao2.trocarPotencialTextoAuxiliar(potencial, conex2);
									clsConexao.sincronizaCircuitos();
								}
								else
								{
									Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 714]), MsgBoxStyle.Critical);
								}
								goto IL_033a;
							}
							Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1739]));
						}
						else
						{
							Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1740]));
						}
					}
					else
					{
						Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1740]));
					}
					goto end_IL_009a;
					IL_033a:
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					end_IL_009a:;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					val2.Abort();
					Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
					ProjectData.ClearProjectError();
				}
				finally
				{
					mdiActiveDocument.SendStringToExecute("\u001b", true, false, false);
				}
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
		PointMonitorToolTips.StartMonitor();
	}

	private void RRBpG6xNLmM(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.ativo.Painel = Dicionario.BuscaIndiceDoPainel(cbPainel.Text);
		cbReterPotencial.Checked = false;
	}

	private void nZ1pGtpMjdA(object P_0, EventArgs P_1)
	{
		if (!cbReterPotencial.Checked)
		{
			tbPotencial.Text = "0";
			cbPainel.Enabled = true;
			beMpG1UUX8G = "";
		}
	}
}
