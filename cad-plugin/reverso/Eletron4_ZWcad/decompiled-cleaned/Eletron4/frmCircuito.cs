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
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.Runtime;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmCircuito : Form
{
	private IContainer cXX0yAICOp;

	[AccessedThroughProperty("btDesliga")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button jdi0gFtV9P;

	[CompilerGenerated]
	[AccessedThroughProperty("cbPainel")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ComboBox x7R0AUh2sO;

	[AccessedThroughProperty("tbNomeCircuito")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox uHG0sUwK3l;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbPotencial")]
	private TextBox f6l0BKQnbw;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbReterPotencial")]
	private CheckBox Lxm0Vyy1nS;

	[CompilerGenerated]
	[AccessedThroughProperty("btSelecionar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button nrm0uj7dj3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCircuito")]
	private Button tSH0EJJvQP;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btEnderecamento")]
	private Button PoI0Zxmj27;

	[AccessedThroughProperty("btEditar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button i4T0ipDYau;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btLiga")]
	private Button JV80S1ARc2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label1")]
	private Label jGq04bqbAx;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label2")]
	private Label BTd0CgNEk2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label3")]
	private Label jk40YeIeDd;

	[AccessedThroughProperty("GroupBox1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox zts0rGg2Qm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip okN09uT5kt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox2")]
	private GroupBox o9V0zTeiha;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbOrdemInsercao")]
	private RadioButton FAnRWTYlt0;

	[AccessedThroughProperty("rbOrdemPaginas")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton r6rRpUI02v;

	[AccessedThroughProperty("btFundir")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button DaNRT14G80;

	private DeclaracoesEntidades.StructureConexao rH1RJBDaUb;

	private string woFRhrpVkM;

	internal virtual Button btDesliga
	{
		[CompilerGenerated]
		get
		{
			return jdi0gFtV9P;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = i8J0Re5xOJ;
			Button button = jdi0gFtV9P;
			if (button != null)
			{
				button.Click -= value2;
			}
			jdi0gFtV9P = value;
			button = jdi0gFtV9P;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual ComboBox cbPainel
	{
		[CompilerGenerated]
		get
		{
			return x7R0AUh2sO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = h410XfBu7b;
			ComboBox comboBox = x7R0AUh2sO;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged -= value2;
			}
			x7R0AUh2sO = value;
			comboBox = x7R0AUh2sO;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual TextBox tbNomeCircuito
	{
		[CompilerGenerated]
		get
		{
			return uHG0sUwK3l;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			uHG0sUwK3l = value;
		}
	}

	internal virtual TextBox tbPotencial
	{
		[CompilerGenerated]
		get
		{
			return f6l0BKQnbw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			f6l0BKQnbw = value;
		}
	}

	internal virtual CheckBox cbReterPotencial
	{
		[CompilerGenerated]
		get
		{
			return Lxm0Vyy1nS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = mAJ0UGUcI4;
			CheckBox checkBox = Lxm0Vyy1nS;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			Lxm0Vyy1nS = value;
			checkBox = Lxm0Vyy1nS;
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
			return nrm0uj7dj3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ogf0nvKSHM;
			Button button = nrm0uj7dj3;
			if (button != null)
			{
				button.Click -= value2;
			}
			nrm0uj7dj3 = value;
			button = nrm0uj7dj3;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btCircuito
	{
		[CompilerGenerated]
		get
		{
			return tSH0EJJvQP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = GL501NHets;
			Button button = tSH0EJJvQP;
			if (button != null)
			{
				button.Click -= value2;
			}
			tSH0EJJvQP = value;
			button = tSH0EJJvQP;
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
			return PoI0Zxmj27;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = gMR0lAFwDW;
			Button button = PoI0Zxmj27;
			if (button != null)
			{
				button.Click -= value2;
			}
			PoI0Zxmj27 = value;
			button = PoI0Zxmj27;
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
			return i4T0ipDYau;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = zbI05ekdI6;
			Button button = i4T0ipDYau;
			if (button != null)
			{
				button.Click -= value2;
			}
			i4T0ipDYau = value;
			button = i4T0ipDYau;
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
			return JV80S1ARc2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SRv00H8VKm;
			Button button = JV80S1ARc2;
			if (button != null)
			{
				button.Click -= value2;
			}
			JV80S1ARc2 = value;
			button = JV80S1ARc2;
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
			return jGq04bqbAx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jGq04bqbAx = value;
		}
	}

	internal virtual Label Label2
	{
		[CompilerGenerated]
		get
		{
			return BTd0CgNEk2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			BTd0CgNEk2 = value;
		}
	}

	internal virtual Label Label3
	{
		[CompilerGenerated]
		get
		{
			return jk40YeIeDd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jk40YeIeDd = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return zts0rGg2Qm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zts0rGg2Qm = value;
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return o9V0zTeiha;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			o9V0zTeiha = value;
		}
	}

	internal virtual RadioButton rbOrdemInsercao
	{
		[CompilerGenerated]
		get
		{
			return FAnRWTYlt0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			FAnRWTYlt0 = value;
		}
	}

	internal virtual RadioButton rbOrdemPaginas
	{
		[CompilerGenerated]
		get
		{
			return r6rRpUI02v;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			r6rRpUI02v = value;
		}
	}

	internal virtual Button btFundir
	{
		[CompilerGenerated]
		get
		{
			return DaNRT14G80;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = rYG0mBWkkl;
			Button button = DaNRT14G80;
			if (button != null)
			{
				button.Click -= value2;
			}
			DaNRT14G80 = value;
			button = DaNRT14G80;
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
			if (disposing && cXX0yAICOp != null)
			{
				cXX0yAICOp.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void V8Z0355q9J()
	{
		cXX0yAICOp = new Container();
		btDesliga = new Button();
		cbPainel = new ComboBox();
		tbNomeCircuito = new TextBox();
		tbPotencial = new TextBox();
		cbReterPotencial = new CheckBox();
		btSelecionar = new Button();
		btCircuito = new Button();
		btEnderecamento = new Button();
		btEditar = new Button();
		btLiga = new Button();
		Label1 = new Label();
		Label2 = new Label();
		Label3 = new Label();
		GroupBox1 = new GroupBox();
		btFundir = new Button();
		FDqpBiUmZij(new ToolTip(cXX0yAICOp));
		GroupBox2 = new GroupBox();
		rbOrdemInsercao = new RadioButton();
		rbOrdemPaginas = new RadioButton();
		GroupBox1.SuspendLayout();
		GroupBox2.SuspendLayout();
		SuspendLayout();
		btDesliga.FlatStyle = FlatStyle.Flat;
		btDesliga.ForeColor = SystemColors.Control;
		btDesliga.Image = Resources.Desliga_32;
		btDesliga.Location = new Point(13, 53);
		btDesliga.Name = "btDesliga";
		btDesliga.Size = new Size(40, 40);
		btDesliga.TabIndex = 7;
		btDesliga.UseVisualStyleBackColor = true;
		cbPainel.FormattingEnabled = true;
		cbPainel.Location = new Point(12, 29);
		cbPainel.Name = "cbPainel";
		cbPainel.Size = new Size(213, 21);
		cbPainel.TabIndex = 8;
		tbNomeCircuito.Location = new Point(126, 76);
		tbNomeCircuito.Name = "tbNomeCircuito";
		tbNomeCircuito.Size = new Size(99, 20);
		tbNomeCircuito.TabIndex = 9;
		tbPotencial.BackColor = Color.Gainsboro;
		tbPotencial.Location = new Point(12, 76);
		tbPotencial.Name = "tbPotencial";
		tbPotencial.ReadOnly = true;
		tbPotencial.Size = new Size(67, 20);
		tbPotencial.TabIndex = 10;
		cbReterPotencial.AutoSize = true;
		cbReterPotencial.Location = new Point(127, 162);
		cbReterPotencial.Name = "cbReterPotencial";
		cbReterPotencial.Size = new Size(99, 17);
		cbReterPotencial.TabIndex = 11;
		cbReterPotencial.Text = "Reter Potencial";
		cbReterPotencial.UseVisualStyleBackColor = true;
		btSelecionar.FlatStyle = FlatStyle.Flat;
		btSelecionar.ForeColor = SystemColors.Control;
		btSelecionar.Image = Resources.Select_32;
		btSelecionar.Location = new Point(126, 109);
		btSelecionar.Name = "btSelecionar";
		btSelecionar.Size = new Size(40, 40);
		btSelecionar.TabIndex = 12;
		btSelecionar.UseVisualStyleBackColor = true;
		btCircuito.FlatStyle = FlatStyle.Flat;
		btCircuito.ForeColor = SystemColors.Control;
		btCircuito.Image = Resources.OK_32;
		btCircuito.Location = new Point(185, 109);
		btCircuito.Name = "btCircuito";
		btCircuito.Size = new Size(40, 40);
		btCircuito.TabIndex = 13;
		btCircuito.UseVisualStyleBackColor = true;
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
		btEditar.Location = new Point(88, 7);
		btEditar.Name = "btEditar";
		btEditar.Size = new Size(40, 40);
		btEditar.TabIndex = 15;
		btEditar.UseVisualStyleBackColor = true;
		btLiga.FlatStyle = FlatStyle.Flat;
		btLiga.ForeColor = SystemColors.Control;
		btLiga.Image = Resources.Liga_32;
		btLiga.Location = new Point(88, 53);
		btLiga.Name = "btLiga";
		btLiga.Size = new Size(40, 40);
		btLiga.TabIndex = 16;
		btLiga.UseVisualStyleBackColor = true;
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
		Label3.AutoSize = true;
		Label3.Location = new Point(123, 57);
		Label3.Name = "Label3";
		Label3.Size = new Size(88, 13);
		Label3.TabIndex = 19;
		Label3.Text = "Nome do Circuito";
		GroupBox1.Controls.Add(btFundir);
		GroupBox1.Controls.Add(btEditar);
		GroupBox1.Controls.Add(btDesliga);
		GroupBox1.Controls.Add(btEnderecamento);
		GroupBox1.Controls.Add(btLiga);
		GroupBox1.Location = new Point(8, 185);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(217, 98);
		GroupBox1.TabIndex = 20;
		GroupBox1.TabStop = false;
		btFundir.FlatStyle = FlatStyle.Flat;
		btFundir.ForeColor = SystemColors.Control;
		btFundir.Image = Resources.FundirCircuitos_32;
		btFundir.Location = new Point(163, 7);
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
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(238, 290);
		Controls.Add(GroupBox2);
		Controls.Add(GroupBox1);
		Controls.Add(Label3);
		Controls.Add(Label2);
		Controls.Add(Label1);
		Controls.Add(btCircuito);
		Controls.Add(btSelecionar);
		Controls.Add(cbReterPotencial);
		Controls.Add(tbPotencial);
		Controls.Add(tbNomeCircuito);
		Controls.Add(cbPainel);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "frmCircuito";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Circuitos";
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
		return okN09uT5kt;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		okN09uT5kt = WithEventsValue;
	}

	public frmCircuito()
	{
		woFRhrpVkM = "";
		try
		{
			if (Geral.ExisteForm("frmCircuito") || !clsAuxiliar.BancoValido())
			{
				return;
			}
			cDadosAccess.carregaDadosDWG();
			if (DeclaracoesGeral.arqAtivo.Indice != 0)
			{
				V8Z0355q9J();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 676]);
				Label1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 626]);
				Label2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 685]);
				Label3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 686]);
				cbReterPotencial.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 683]);
				rbOrdemPaginas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 684]);
				rbOrdemInsercao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 692]);
				GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 698]);
				w8dpBZ0kvSD().SetToolTip(btCircuito, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 677]));
				w8dpBZ0kvSD().SetToolTip(btSelecionar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 678]));
				w8dpBZ0kvSD().SetToolTip(btEnderecamento, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 679]));
				w8dpBZ0kvSD().SetToolTip(btEditar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 680]));
				w8dpBZ0kvSD().SetToolTip(btLiga, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 682]));
				w8dpBZ0kvSD().SetToolTip(btDesliga, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 681]));
				w8dpBZ0kvSD().SetToolTip(btFundir, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 606]));
				cbReterPotencial.Checked = false;
				rbOrdemPaginas.Checked = true;
				tbPotencial.Text = "0";
				tbNomeCircuito.Text = "";
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

	private void ogf0nvKSHM(object P_0, EventArgs P_1)
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
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
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
				val3.SetRejectMessage(Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 696])));
				((PromptOptions)val3).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 695]));
				val3.AddAllowedClass(typeof(Polyline), true);
				PromptEntityResult entity = editor.GetEntity(val3);
				if ((int)((PromptResult)entity).Status != -5002)
				{
					ObjectId objectId = entity.ObjectId;
					Polyline pl = (Polyline)objectId.GetObject((OpenMode)0);
					rH1RJBDaUb = default;
					if (!XDataConexao.lerXDataConexao(ref pl, ref rH1RJBDaUb))
					{
						return;
					}
					if (rH1RJBDaUb.Tipo == 1)
					{
						tbPotencial.Text = Conversions.ToString(rH1RJBDaUb.Potencial);
						tbNomeCircuito.Text = rH1RJBDaUb.Nome;
						cbPainel.Text = Dicionario.BuscaNomeDoPainel(rH1RJBDaUb.Painel);
						if (rH1RJBDaUb.Enderecamento != 1)
						{
							if (rH1RJBDaUb.Enderecamento == 2)
							{
								rbOrdemInsercao.Checked = true;
							}
						}
						else
						{
							rbOrdemPaginas.Checked = true;
						}
						woFRhrpVkM = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
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

	private void GL501NHets(object P_0, EventArgs P_1)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected Obj, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Invalid comparison between Unknown and I4
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Expected Obj, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Expected Obj, but got Unknown
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Expected Obj, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Invalid comparison between Unknown and I4
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_039a: Invalid comparison between Unknown and I4
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Invalid comparison between Unknown and I4
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d4: Expected Obj, but got Unknown
		//IL_04dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ef: Expected Obj, but got Unknown
		//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Unknown result type (might be due to invalid IL or missing references)
		//IL_0569: Unknown result type (might be due to invalid IL or missing references)
		//IL_056e: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e5: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		PromptPointOptions val = new PromptPointOptions("");
		DeclaracoesEntidades.StructureConexao conex = new DeclaracoesEntidades.StructureConexao
		{
			Tipo = 1,
			Aplicacao = 0,
			Handle = "",
			Tensao = "",
			Funcao = "",
			Jumper = "",
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
		string sTipo;
		clsConexao clsConexao2;
		if ((int)((PromptResult)point).Status != -5002)
		{
			value = point.Value;
			sTipo = "";
			int Potencial = 0;
			string Handle = "";
			string Secao = "";
			string Cor = "";
			int Aplicacao = 0;
			clsConexao2 = new clsConexao();
			Point3d pt = value;
			int num = default;
			short Painel = checked((short)num);
			bool bpossuiRB = false;
			bool flag = clsConexao2.verificaDispConex(pt, ref sTipo, ref Painel, ref Potencial, ref Handle, ref Secao, ref Cor, ref Aplicacao, ref bpossuiRB);
			num = Painel;
			if (flag)
			{
				string left = sTipo;
				if (Operators.CompareString(left, "P", TextCompare: true) != 0 && Operators.CompareString(left, "A", TextCompare: true) != 0 && Operators.CompareString(left, "E", TextCompare: true) != 0 && Operators.CompareString(left, "B", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left, "C", TextCompare: true) == 0 || Operators.CompareString(left, "J", TextCompare: true) == 0)
					{
						conex.Disp1 = false;
						goto IL_01e5;
					}
				}
				else
				{
					if (num == conex.Painel)
					{
						conex.Disp1 = true;
						goto IL_01e5;
					}
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 690]), MsgBoxStyle.Exclamation);
				}
			}
			else
			{
				conex.Disp1 = false;
				if (Operators.CompareString(sTipo, "I", TextCompare: true) != 0)
				{
					goto IL_01e5;
				}
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 712]), MsgBoxStyle.Exclamation);
			}
		}
		goto IL_0923;
		IL_0923:
		PointMonitorToolTips.StartMonitor();
		return;
		IL_01e5:
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
						bool flag = false;
						if (clsConexao2.verificaDispConex(point3dAt, ref sTipo2, ref Painel2, ref Potencial2, ref Handle2, ref Secao2, ref Cor2, ref Aplicacao2, ref flag))
						{
							string left2 = sTipo2;
							if (Operators.CompareString(left2, "P", TextCompare: true) != 0 && Operators.CompareString(left2, "A", TextCompare: true) != 0 && Operators.CompareString(left2, "E", TextCompare: true) != 0 && Operators.CompareString(left2, "B", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left2, "C", TextCompare: true) != 0 && Operators.CompareString(left2, "J", TextCompare: true) != 0)
								{
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
								conex.Disp2 = true;
							}
						}
						else
						{
							conex.Disp2 = false;
							if (Operators.CompareString(sTipo, "I", TextCompare: true) == 0)
							{
								Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 712]), MsgBoxStyle.Exclamation);
								break;
							}
						}
						if (!(conex.Disp1 & conex.Disp2))
						{
							if (!cbReterPotencial.Checked)
							{
								conex.Potencial = XDataConexao.BuscaPotencial();
								tbPotencial.Text = conex.Potencial.ToString();
								conex.Secao = DeclaracoesGeral.ativoRibbon.Secao;
								conex.Cor = DeclaracoesGeral.ativoRibbon.Cor;
								conex.Aplicacao = 0;
								conex.Nome = tbNomeCircuito.Text.Trim();
							}
							else
							{
								if (Conversions.ToInteger(tbPotencial.Text) <= 0)
								{
									break;
								}
								conex.Potencial = rH1RJBDaUb.Potencial;
								conex.Secao = rH1RJBDaUb.Secao;
								conex.Cor = rH1RJBDaUb.Cor;
								conex.Aplicacao = rH1RJBDaUb.Aplicacao;
								conex.Enderecamento = rH1RJBDaUb.Enderecamento;
								conex.Nome = rH1RJBDaUb.Nome;
								conex.Painel = rH1RJBDaUb.Painel;
							}
							cbReterPotencial.Checked = true;
							rH1RJBDaUb = default;
							rH1RJBDaUb = conex;
							BlockTable val6 = (BlockTable)val4.GetObject(database.BlockTableId, (OpenMode)0);
							BlockTableRecord val7 = (BlockTableRecord)val4.GetObject(((SymbolTable)val6)[BlockTableRecord.ModelSpace], (OpenMode)1);
							val7.AppendEntity((Entity)(object)pl);
							DeclaracoesGeral.bAnularEventos = true;
							val4.AddNewlyCreatedDBObject((DBObject)(object)pl, true);
							XDataConexao.GravarXDataConexao(ref pl, conex);
							if (Operators.CompareString(conex.Nome.Trim(), "", TextCompare: true) == 0)
							{
								conex.Nome = " ";
							}
							DBText val8 = clsConexao2.criarTextoCircuito(conex, pl, DeclaracoesGeral.ativo.Pagina);
							val7.AppendEntity((Entity)(object)val8);
							DeclaracoesGeral.bAnularEventos = true;
							val4.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
							XDataConexao.GravarXDataAuxCircuito(ref val8, conex.Potencial, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString(), conex.Enderecamento, 1);
							if (!conex.Disp1)
							{
								DBText val9 = clsConexao2.criarTextoDePara(conex, pl, DeclaracoesGeral.ativo.Pagina, 1);
								val7.AppendEntity((Entity)(object)val9);
								DeclaracoesGeral.bAnularEventos = true;
								val4.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
								XDataConexao.GravarXDataAuxCircuito(ref val9, conex.Potencial, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString(), conex.Enderecamento, 2);
							}
							if (!conex.Disp2)
							{
								DBText val10 = clsConexao2.criarTextoDePara(conex, pl, DeclaracoesGeral.ativo.Pagina, 2);
								val7.AppendEntity((Entity)(object)val10);
								DeclaracoesGeral.bAnularEventos = true;
								val4.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
								XDataConexao.GravarXDataAuxCircuito(ref val10, conex.Potencial, ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString(), conex.Enderecamento, 3);
							}
						}
						else
						{
							Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 691]), MsgBoxStyle.Exclamation);
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
		goto IL_0923;
	}

	private void gMR0lAFwDW(object P_0, EventArgs P_1)
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected Obj, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected Obj, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected Obj, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(woFRhrpVkM, "", TextCompare: true) == 0)
		{
			return;
		}
		clsConexao.ApagarTextosAuxiliaresCircuito(DeclaracoesGeral.ativo.Pagina, woFRhrpVkM);
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
					Entity val5 = (Entity)Geral.HandleToObject(woFRhrpVkM);
					if (val5 != null)
					{
						Polyline val6 = (Polyline)(object)((val5 is Polyline) ? val5 : null);
						if (val6 != null)
						{
							clsConexao clsConexao2 = new clsConexao();
							if (Operators.CompareString(rH1RJBDaUb.Nome.Trim(), "", TextCompare: true) == 0)
							{
								rH1RJBDaUb.Nome = " ";
							}
							DBText val7 = clsConexao2.criarTextoCircuito(rH1RJBDaUb, val6, DeclaracoesGeral.ativo.Pagina);
							val4.AppendEntity((Entity)(object)val7);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val7, true);
							XDataConexao.GravarXDataAuxCircuito(ref val7, rH1RJBDaUb.Potencial, ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString(), rH1RJBDaUb.Enderecamento, 1);
							if (!rH1RJBDaUb.Disp1)
							{
								DBText val8 = clsConexao2.criarTextoDePara(rH1RJBDaUb, val6, DeclaracoesGeral.ativo.Pagina, 1);
								val4.AppendEntity((Entity)(object)val8);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
								XDataConexao.GravarXDataAuxCircuito(ref val8, rH1RJBDaUb.Potencial, woFRhrpVkM, rH1RJBDaUb.Enderecamento, 2);
							}
							if (!rH1RJBDaUb.Disp2)
							{
								DBText val9 = clsConexao2.criarTextoDePara(rH1RJBDaUb, val6, DeclaracoesGeral.ativo.Pagina, 2);
								val4.AppendEntity((Entity)(object)val9);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
								XDataConexao.GravarXDataAuxCircuito(ref val9, rH1RJBDaUb.Potencial, woFRhrpVkM, rH1RJBDaUb.Enderecamento, 3);
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

	private void zbI05ekdI6(object P_0, EventArgs P_1)
	{
		DeclaracoesEntidades.StructureConexao conex = new DeclaracoesEntidades.StructureConexao
		{
			Potencial = rH1RJBDaUb.Potencial,
			Nome = tbNomeCircuito.Text.Trim(),
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

	private void SRv00H8VKm(object P_0, EventArgs P_1)
	{
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		clsConexao clsConexao2 = new clsConexao();
		clsConexao2.ligarTextoAuxiliar(DeclaracoesGeral.ativo.Pagina);
	}

	private void i8J0Re5xOJ(object P_0, EventArgs P_1)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected Obj, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected Obj, but got Unknown
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Invalid comparison between Unknown and I4
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected Obj, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				try
				{
					TypedValue[] array = new TypedValue[2];
					array.SetValue((object)new TypedValue(0, (object)"TEXT"), 0);
					array.SetValue((object)new TypedValue(1001, (object)"AUXCONEXAO"), 1);
					SelectionFilter val4 = new SelectionFilter(array);
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
					PromptSelectionOptions val5 = new PromptSelectionOptions();
					val5.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 697]);
					PromptSelectionResult selection = editor.GetSelection(val5, val4);
					if ((int)selection.Status == 5100)
					{
						SelectionSet value = selection.Value;
						ObjectIdCollection val6 = new ObjectIdCollection(value.GetObjectIds());
						foreach (object item in val6)
						{
							ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							Entity val8 = (Entity)val7.GetObject((OpenMode)1);
							val8.Visible = false;
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

	private void rYG0mBWkkl(object P_0, EventArgs P_1)
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
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected Obj, but got Unknown
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Invalid comparison between Unknown and I4
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected Obj, but got Unknown
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
					val4.SetRejectMessage(Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 696])));
					((PromptOptions)val4).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 695]));
					val4.AddAllowedClass(typeof(Polyline), true);
					PromptEntityResult entity = editor.GetEntity(val4);
					if ((int)((PromptResult)entity).Status != -5002)
					{
						ObjectId objectId = entity.ObjectId;
						Polyline pl = (Polyline)objectId.GetObject((OpenMode)0);
						if (XDataConexao.lerXDataConexao(ref pl, ref conex) && conex.Tipo == 1)
						{
							cbPainel.Text = Dicionario.BuscaNomeDoPainel(conex.Painel);
							val4 = new PromptEntityOptions("");
							val4.SetRejectMessage(Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 696])));
							((PromptOptions)val4).Message = Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 700]));
							val4.AddAllowedClass(typeof(Polyline), true);
							entity = editor.GetEntity(val4);
							if ((int)((PromptResult)entity).Status != -5002)
							{
								objectId = entity.ObjectId;
								Polyline pl2 = (Polyline)objectId.GetObject((OpenMode)0);
								if (XDataConexao.lerXDataConexao(ref pl2, ref conex2) && conex2.Tipo == 1)
								{
									if (conex.Painel == conex2.Painel)
									{
										int potencial = conex2.Potencial;
										conex2.Potencial = conex.Potencial;
										conex2.Nome = conex.Nome;
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
										Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 699]), MsgBoxStyle.Critical);
									}
								}
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

	private void h410XfBu7b(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.ativo.Painel = Dicionario.BuscaIndiceDoPainel(cbPainel.Text);
		cbReterPotencial.Checked = false;
	}

	private void mAJ0UGUcI4(object P_0, EventArgs P_1)
	{
		if (!cbReterPotencial.Checked)
		{
			tbPotencial.Text = "0";
			tbNomeCircuito.Text = "";
			cbPainel.Enabled = true;
			woFRhrpVkM = "";
		}
	}
}
