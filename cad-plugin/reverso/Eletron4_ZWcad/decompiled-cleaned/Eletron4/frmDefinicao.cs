using System;
using System.Collections;
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
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmDefinicao : Form
{
	public struct mItensSelecionadosDG
	{
		public int IndicePorta;

		public string EFC;

		public string Terminais;

		public string regua;

		public string Bornes;

		public string IndiceModelo;

		public string HandleDaMascara;

		public string HandleDaPorta;

		public string HandleDef;

		public string PgPorta;

		public string PgDef;
	}

	private IContainer xxpujq5LJ9;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgPortas")]
	private DataGridView ztEuLjIjs9;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBFiltro")]
	private Label Xsquwx4lNB;

	[CompilerGenerated]
	[AccessedThroughProperty("TBPesquisa")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox s0PuxTv4Qb;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgMascaras")]
	private DataGridView llUubQsHGf;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtAtribuiMPortas")]
	private Button on3uM1A8nM;

	[AccessedThroughProperty("BtAtribuiMDefinicoes")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button li1uOuSDjn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTAtribuiDefAPaginaCorrente")]
	private Button HRAuIpmXGP;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("BTLimpaDefinicoes")]
	private Button deQu7fUqXO;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTConstroiLink")]
	private Button igHuqWF19k;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip S3vuaNXTwh;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btSeleciona")]
	private Button l56u8Ak5aQ;

	[AccessedThroughProperty("GroupBox1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox gFWuNrqEs5;

	[AccessedThroughProperty("GroupBox2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox TdxuFXRn5c;

	[AccessedThroughProperty("RB3")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton oRvuQ6fhdn;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("RB1")]
	private RadioButton qgHuPKHCGZ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RB2")]
	private RadioButton PqwucEMhNy;

	private Declaracoes2.MMascara[] MB5uKirial;

	private Declaracoes2.MModeloDePortas[] W1JuegHw5h;

	private DeclaracoesEntidades.StructurePortas li4u2ETF3v;

	public Declaracoes2.MModeloDePortas[] mPortas_DefUsadas;

	public string[,] PortasUsadas;

	public bool bInicializacao;

	public int indicePainelSel;

	private ArrayList Maju3Cc37h;

	private ArrayList zeHunA7Hj1;

	internal virtual DataGridView dgPortas
	{
		[CompilerGenerated]
		get
		{
			return ztEuLjIjs9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = NfruDjShWg;
			MouseEventHandler value3 = ySZu63HlZW;
			KeyEventHandler value4 = Nyfut3SJKF;
			DataGridView dataGridView = ztEuLjIjs9;
			if (dataGridView != null)
			{
				dataGridView.MouseDoubleClick -= value2;
				dataGridView.MouseClick -= value3;
				dataGridView.KeyUp -= value4;
			}
			ztEuLjIjs9 = value;
			dataGridView = ztEuLjIjs9;
			if (dataGridView != null)
			{
				dataGridView.MouseDoubleClick += value2;
				dataGridView.MouseClick += value3;
				dataGridView.KeyUp += value4;
			}
		}
	}

	internal virtual Label LBFiltro
	{
		[CompilerGenerated]
		get
		{
			return Xsquwx4lNB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Xsquwx4lNB = value;
		}
	}

	internal virtual TextBox TBPesquisa
	{
		[CompilerGenerated]
		get
		{
			return s0PuxTv4Qb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = sqjup8QaLG;
			TextBox textBox = s0PuxTv4Qb;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			s0PuxTv4Qb = value;
			textBox = s0PuxTv4Qb;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual DataGridView dgMascaras
	{
		[CompilerGenerated]
		get
		{
			return llUubQsHGf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = jW1uWahxCs;
			DataGridView dataGridView = llUubQsHGf;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			llUubQsHGf = value;
			dataGridView = llUubQsHGf;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual Button BtAtribuiMPortas
	{
		[CompilerGenerated]
		get
		{
			return on3uM1A8nM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CXLuJVs1IN;
			Button button = on3uM1A8nM;
			if (button != null)
			{
				button.Click -= value2;
			}
			on3uM1A8nM = value;
			button = on3uM1A8nM;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BtAtribuiMDefinicoes
	{
		[CompilerGenerated]
		get
		{
			return li1uOuSDjn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Wb4uhcbOjR;
			Button button = li1uOuSDjn;
			if (button != null)
			{
				button.Click -= value2;
			}
			li1uOuSDjn = value;
			button = li1uOuSDjn;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTAtribuiDefAPaginaCorrente
	{
		[CompilerGenerated]
		get
		{
			return HRAuIpmXGP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = h9huoAb70U;
			Button button = HRAuIpmXGP;
			if (button != null)
			{
				button.Click -= value2;
			}
			HRAuIpmXGP = value;
			button = HRAuIpmXGP;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTLimpaDefinicoes
	{
		[CompilerGenerated]
		get
		{
			return deQu7fUqXO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = rmquHZ1POf;
			Button button = deQu7fUqXO;
			if (button != null)
			{
				button.Click -= value2;
			}
			deQu7fUqXO = value;
			button = deQu7fUqXO;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTConstroiLink
	{
		[CompilerGenerated]
		get
		{
			return igHuqWF19k;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Dq4ukqAFgm;
			Button button = igHuqWF19k;
			if (button != null)
			{
				button.Click -= value2;
			}
			igHuqWF19k = value;
			button = igHuqWF19k;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btSeleciona
	{
		[CompilerGenerated]
		get
		{
			return l56u8Ak5aQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = T9Vuditmrd;
			Button button = l56u8Ak5aQ;
			if (button != null)
			{
				button.Click -= value2;
			}
			l56u8Ak5aQ = value;
			button = l56u8Ak5aQ;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return gFWuNrqEs5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			gFWuNrqEs5 = value;
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return TdxuFXRn5c;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TdxuFXRn5c = value;
		}
	}

	internal virtual RadioButton RB3
	{
		[CompilerGenerated]
		get
		{
			return oRvuQ6fhdn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			oRvuQ6fhdn = value;
		}
	}

	internal virtual RadioButton RB1
	{
		[CompilerGenerated]
		get
		{
			return qgHuPKHCGZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qgHuPKHCGZ = value;
		}
	}

	internal virtual RadioButton RB2
	{
		[CompilerGenerated]
		get
		{
			return PqwucEMhNy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PqwucEMhNy = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && xxpujq5LJ9 != null)
			{
				xxpujq5LJ9.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void VYJVzNlHwl()
	{
		xxpujq5LJ9 = new Container();
		dgPortas = new DataGridView();
		LBFiltro = new Label();
		TBPesquisa = new TextBox();
		dgMascaras = new DataGridView();
		BtAtribuiMPortas = new Button();
		BtAtribuiMDefinicoes = new Button();
		BTAtribuiDefAPaginaCorrente = new Button();
		BTLimpaDefinicoes = new Button();
		BTConstroiLink = new Button();
		FDqpBiUmZij(new ToolTip(xxpujq5LJ9));
		btSeleciona = new Button();
		GroupBox1 = new GroupBox();
		GroupBox2 = new GroupBox();
		RB3 = new RadioButton();
		RB1 = new RadioButton();
		RB2 = new RadioButton();
		((ISupportInitialize)dgPortas).BeginInit();
		((ISupportInitialize)dgMascaras).BeginInit();
		GroupBox1.SuspendLayout();
		GroupBox2.SuspendLayout();
		SuspendLayout();
		dgPortas.AllowUserToAddRows = false;
		dgPortas.AllowUserToDeleteRows = false;
		dgPortas.AllowUserToResizeRows = false;
		dgPortas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgPortas.BackgroundColor = Color.White;
		dgPortas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPortas.Location = new Point(265, 8);
		dgPortas.MultiSelect = false;
		dgPortas.Name = "dgPortas";
		dgPortas.ReadOnly = true;
		dgPortas.RowHeadersVisible = false;
		dgPortas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPortas.Size = new Size(507, 334);
		dgPortas.TabIndex = 19;
		LBFiltro.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		LBFiltro.BorderStyle = BorderStyle.Fixed3D;
		LBFiltro.Location = new Point(55, 405);
		LBFiltro.Name = "LBFiltro";
		LBFiltro.Size = new Size(81, 20);
		LBFiltro.TabIndex = 151;
		LBFiltro.Text = "Filtro";
		LBFiltro.TextAlign = ContentAlignment.MiddleCenter;
		TBPesquisa.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		TBPesquisa.CharacterCasing = CharacterCasing.Upper;
		TBPesquisa.Location = new Point(142, 405);
		TBPesquisa.Name = "TBPesquisa";
		TBPesquisa.Size = new Size(117, 20);
		TBPesquisa.TabIndex = 150;
		TBPesquisa.TextAlign = HorizontalAlignment.Center;
		dgMascaras.AllowUserToAddRows = false;
		dgMascaras.AllowUserToDeleteRows = false;
		dgMascaras.AllowUserToOrderColumns = true;
		dgMascaras.AllowUserToResizeRows = false;
		dgMascaras.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgMascaras.BorderStyle = BorderStyle.Fixed3D;
		dgMascaras.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgMascaras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgMascaras.Location = new Point(9, 12);
		dgMascaras.MultiSelect = false;
		dgMascaras.Name = "dgMascaras";
		dgMascaras.ReadOnly = true;
		dgMascaras.RowHeadersVisible = false;
		dgMascaras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgMascaras.Size = new Size(250, 375);
		dgMascaras.TabIndex = 149;
		BtAtribuiMPortas.Anchor = AnchorStyles.Left;
		BtAtribuiMPortas.FlatStyle = FlatStyle.Flat;
		BtAtribuiMPortas.ForeColor = SystemColors.Control;
		BtAtribuiMPortas.Image = Resources.AtribuirPortas_32;
		BtAtribuiMPortas.Location = new Point(6, 28);
		BtAtribuiMPortas.Name = "BtAtribuiMPortas";
		BtAtribuiMPortas.Size = new Size(40, 40);
		BtAtribuiMPortas.TabIndex = 138;
		BtAtribuiMPortas.UseVisualStyleBackColor = true;
		BtAtribuiMDefinicoes.Anchor = AnchorStyles.Left;
		BtAtribuiMDefinicoes.FlatStyle = FlatStyle.Flat;
		BtAtribuiMDefinicoes.ForeColor = SystemColors.Control;
		BtAtribuiMDefinicoes.Image = Resources.AtribuirDefinicao_32;
		BtAtribuiMDefinicoes.Location = new Point(52, 28);
		BtAtribuiMDefinicoes.Name = "BtAtribuiMDefinicoes";
		BtAtribuiMDefinicoes.Size = new Size(40, 40);
		BtAtribuiMDefinicoes.TabIndex = 139;
		BtAtribuiMDefinicoes.UseVisualStyleBackColor = true;
		BTAtribuiDefAPaginaCorrente.Anchor = AnchorStyles.Left;
		BTAtribuiDefAPaginaCorrente.FlatStyle = FlatStyle.Flat;
		BTAtribuiDefAPaginaCorrente.ForeColor = SystemColors.Control;
		BTAtribuiDefAPaginaCorrente.Image = Resources.AtribuirDefinicaoPG_32;
		BTAtribuiDefAPaginaCorrente.Location = new Point(98, 28);
		BTAtribuiDefAPaginaCorrente.Name = "BTAtribuiDefAPaginaCorrente";
		BTAtribuiDefAPaginaCorrente.Size = new Size(40, 40);
		BTAtribuiDefAPaginaCorrente.TabIndex = 152;
		BTAtribuiDefAPaginaCorrente.UseVisualStyleBackColor = true;
		BTLimpaDefinicoes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		BTLimpaDefinicoes.FlatStyle = FlatStyle.Flat;
		BTLimpaDefinicoes.ForeColor = SystemColors.Control;
		BTLimpaDefinicoes.Image = Resources.Apagador_32;
		BTLimpaDefinicoes.Location = new Point(246, 27);
		BTLimpaDefinicoes.Name = "BTLimpaDefinicoes";
		BTLimpaDefinicoes.Size = new Size(40, 40);
		BTLimpaDefinicoes.TabIndex = 153;
		BTLimpaDefinicoes.UseVisualStyleBackColor = true;
		BTConstroiLink.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		BTConstroiLink.FlatStyle = FlatStyle.Flat;
		BTConstroiLink.ForeColor = SystemColors.Control;
		BTConstroiLink.Image = Resources.Restaura_32;
		BTConstroiLink.Location = new Point(732, 375);
		BTConstroiLink.Name = "BTConstroiLink";
		BTConstroiLink.Size = new Size(40, 40);
		BTConstroiLink.TabIndex = 154;
		BTConstroiLink.UseVisualStyleBackColor = true;
		btSeleciona.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btSeleciona.FlatStyle = FlatStyle.Flat;
		btSeleciona.ForeColor = SystemColors.Control;
		btSeleciona.Image = Resources.Select_32;
		btSeleciona.Location = new Point(9, 393);
		btSeleciona.Name = "btSeleciona";
		btSeleciona.Size = new Size(40, 40);
		btSeleciona.TabIndex = 155;
		btSeleciona.Tag = "";
		btSeleciona.UseVisualStyleBackColor = true;
		GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox1.Controls.Add(BtAtribuiMPortas);
		GroupBox1.Controls.Add(BtAtribuiMDefinicoes);
		GroupBox1.Controls.Add(BTAtribuiDefAPaginaCorrente);
		GroupBox1.Location = new Point(265, 348);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(151, 85);
		GroupBox1.TabIndex = 156;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "_Atribuir";
		GroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox2.Controls.Add(RB3);
		GroupBox2.Controls.Add(RB1);
		GroupBox2.Controls.Add(RB2);
		GroupBox2.Controls.Add(BTLimpaDefinicoes);
		GroupBox2.Location = new Point(422, 348);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(301, 85);
		GroupBox2.TabIndex = 157;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "_Indefinir";
		RB3.Anchor = AnchorStyles.Left;
		RB3.AutoSize = true;
		RB3.Location = new Point(16, 59);
		RB3.Name = "RB3";
		RB3.Size = new Size(76, 17);
		RB3.TabIndex = 156;
		RB3.TabStop = true;
		RB3.Text = "_Definição";
		RB3.UseVisualStyleBackColor = true;
		RB1.Anchor = AnchorStyles.Left;
		RB1.AutoSize = true;
		RB1.Checked = true;
		RB1.Location = new Point(16, 19);
		RB1.Name = "RB1";
		RB1.Size = new Size(86, 17);
		RB1.TabIndex = 155;
		RB1.TabStop = true;
		RB1.Text = "_por seleção";
		RB1.UseVisualStyleBackColor = true;
		RB2.Anchor = AnchorStyles.Left;
		RB2.AutoSize = true;
		RB2.Location = new Point(16, 39);
		RB2.Name = "RB2";
		RB2.Size = new Size(118, 17);
		RB2.TabIndex = 154;
		RB2.TabStop = true;
		RB2.Text = "_Porta Selecionada";
		RB2.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(784, 441);
		Controls.Add(GroupBox2);
		Controls.Add(GroupBox1);
		Controls.Add(btSeleciona);
		Controls.Add(BTConstroiLink);
		Controls.Add(LBFiltro);
		Controls.Add(TBPesquisa);
		Controls.Add(dgMascaras);
		Controls.Add(dgPortas);
		MaximizeBox = false;
		MinimizeBox = false;
		MinimumSize = new Size(800, 480);
		Name = "frmDefinicao";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Atribuir Definição";
		((ISupportInitialize)dgPortas).EndInit();
		((ISupportInitialize)dgMascaras).EndInit();
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
		return S3vuaNXTwh;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		S3vuaNXTwh = WithEventsValue;
	}

	public frmDefinicao()
	{
		Resize += AcqufNNeU4;
		li4u2ETF3v = default;
		bInicializacao = true;
		indicePainelSel = 0;
		Maju3Cc37h = new ArrayList();
		zeHunA7Hj1 = new ArrayList();
		checked
		{
			try
			{
				if (Geral.ExisteForm("frmDefinicao") || !clsAuxiliar.BancoValido())
				{
					return;
				}
				cDadosAccess.carregaDadosDWG();
				if (DeclaracoesGeral.arqAtivo.Indice != 0)
				{
					VYJVzNlHwl();
					Maju3Cc37h.Clear();
					zeHunA7Hj1.Clear();
					GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1751]);
					GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1752]);
					RB1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1753]);
					RB2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1754]);
					RB3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1755]);
					clsMascara.CarregaMascaras(ref MB5uKirial);
					DataGridView dg = dgMascaras;
					carregaMascarasNoDG(ref dg, MB5uKirial, TBPesquisa.Text.ToString());
					dgMascaras = dg;
					dg = dgMascaras;
					bool flag = AtualizaColunasDGMascaraDG(ref dg);
					dgMascaras = dg;
					if (flag)
					{
						dgMascaras.Width += 50;
						dgPortas.Width -= 50;
						dgPortas.Location = new Point(dgPortas.Location.X + 50, dgPortas.Location.Y);
					}
					if (dgMascaras.RowCount > 0)
					{
						dgMascaras.Rows[0].Selected = false;
						int iIndiceSelecionado = Conversions.ToInteger(dgMascaras.Rows[0].Cells[4].Value);
						string sNomeModelo = Conversions.ToString(dgMascaras.Rows[0].Cells[0].Value);
						DicionarioMascaras.LeAsPortasDoModeloDoDicionario(ref iIndiceSelecionado, sNomeModelo, ref W1JuegHw5h);
						clsDispositivoMascaras.PesquisaTodasAsPortasEDefinicoesUsadas(ref mPortas_DefUsadas);
						AdicionaHandlesUsados(ref W1JuegHw5h, ref mPortas_DefUsadas);
						dg = dgPortas;
						clsDispositivoMascaras.carregaContatosNoDGDefinicao(ref dg, ref W1JuegHw5h, bPintaDG: true, indicePainelSel);
						dgPortas = dg;
						dg = dgPortas;
						AtualizaColunasDGPortasDefinicao(ref dg);
						dgPortas = dg;
					}
					Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1107]);
					LBFiltro.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 272]);
					w8dpBZ0kvSD().SetToolTip(BtAtribuiMPortas, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1009]));
					w8dpBZ0kvSD().SetToolTip(BtAtribuiMDefinicoes, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1010]));
					w8dpBZ0kvSD().SetToolTip(BTAtribuiDefAPaginaCorrente, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1011]));
					w8dpBZ0kvSD().SetToolTip(BTLimpaDefinicoes, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1012]));
					w8dpBZ0kvSD().SetToolTip(BTConstroiLink, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1013]));
					w8dpBZ0kvSD().SetToolTip(btSeleciona, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1134]));
					Application.ShowModelessDialog((Form)this);
					if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
					{
						Left = 0;
					}
					bInicializacao = false;
					dg = dgPortas;
					AtualizaColunasDGPortasDefinicao(ref dg);
					dgPortas = dg;
					dg = dgMascaras;
					AtualizaColunasDGMascaraDG(ref dg);
					dgMascaras = dg;
					C1UuvCIWXG();
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
	}

	private void jW1uWahxCs(object P_0, EventArgs P_1)
	{
		SEYuTE2oh6(_0020: false);
		if (!bInicializacao)
		{
			DataGridView withEventsValue = dgPortas;
			AtualizaColunasDGPortasDefinicao(ref withEventsValue);
			dgPortas = withEventsValue;
		}
		C1UuvCIWXG();
	}

	private void sqjup8QaLG(object P_0, KeyEventArgs P_1)
	{
		if ((P_1.KeyValue == 13) | (Operators.CompareString(TBPesquisa.Text, "", TextCompare: true) == 0))
		{
			DataGridView dg = dgMascaras;
			carregaMascarasNoDG(ref dg, MB5uKirial, TBPesquisa.Text.ToString());
			dgMascaras = dg;
			dg = dgMascaras;
			AtualizaColunasDGMascaraDG(ref dg);
			dgMascaras = dg;
			SEYuTE2oh6(_0020: false);
		}
	}

	private void SEYuTE2oh6(bool P_0)
	{
		int[] array = new int[1];
		checked
		{
			if (P_0)
			{
				int num = dgPortas.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (dgPortas.Rows[i].Selected)
					{
						int num2 = Information.UBound(array) + 1;
						array = (int[])Utils.CopyArray(array, new int[num2 + 1]);
						array[num2] = Conversions.ToInteger(dgPortas.Rows[i].Cells[0].Value);
					}
				}
			}
			dgPortas.Rows.Clear();
			dgPortas.Columns.Clear();
			if (dgMascaras.SelectedRows.Count == 1)
			{
				int iIndiceSelecionado = Conversions.ToInteger(dgMascaras.SelectedRows[0].Cells[4].Value);
				string text = Conversions.ToString(dgMascaras.SelectedRows[0].Cells[5].Value);
				indicePainelSel = Conversions.ToInteger(dgMascaras.SelectedRows[0].Cells[2].Value);
				if (Operators.ConditionalCompareObjectNotEqual(dgMascaras.SelectedRows[0].Cells[6].Value, "", TextCompare: true))
				{
					text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dgMascaras.SelectedRows[0].Cells[5].Value, "/"), dgMascaras.SelectedRows[0].Cells[6].Value));
				}
				DicionarioMascaras.LeAsPortasDoModeloDoDicionario(ref iIndiceSelecionado, text, ref W1JuegHw5h);
				AdicionaHandlesUsados(ref W1JuegHw5h, ref mPortas_DefUsadas);
				DataGridView dg = dgPortas;
				clsDispositivoMascaras.carregaContatosNoDGDefinicao(ref dg, ref W1JuegHw5h, bPintaDG: true, indicePainelSel);
				dgPortas = dg;
				int indice = iIndiceSelecionado;
				string sNome = text;
				dg = dgPortas;
				clsPortas.MarcaOsContatosUsadosNoDG(indice, sNome, ref dg, ref mPortas_DefUsadas, indicePainelSel);
				dgPortas = dg;
				dg = dgPortas;
				AtualizaColunasDGPortasDefinicao(ref dg);
				dgPortas = dg;
			}
			if (!P_0)
			{
				return;
			}
			int num3 = dgPortas.Rows.Count - 1;
			for (int j = num3; j >= 0; j += -1)
			{
				int num4 = Information.UBound(array);
				for (int k = num4; k >= 1; k += -1)
				{
					if (Operators.CompareString(dgPortas.Rows[j].Cells[0].Value.ToString(), array[k].ToString(), TextCompare: true) == 0)
					{
						dgPortas.Rows[j].Selected = true;
						if (k == 1)
						{
							dgPortas.FirstDisplayedScrollingRowIndex = j;
						}
					}
				}
			}
		}
	}

	public void AdicionaHandlesUsados(ref Declaracoes2.MModeloDePortas[] mPORTAS, ref Declaracoes2.MModeloDePortas[] mPortasUsadas)
	{
		int num = Information.UBound(mPORTAS);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				mPORTAS[i].HandlePorta = "";
				mPORTAS[i].HandleDef = "";
			}
			int num2 = Information.UBound(mPortasUsadas);
			for (int j = 1; j <= num2; j++)
			{
				int num3 = Information.UBound(mPORTAS);
				for (int k = 1; k <= num3; k++)
				{
					if (mPORTAS[k].IndiceModelo == mPortasUsadas[j].IndiceModelo && Operators.CompareString(mPORTAS[k].NomeModelo, mPortasUsadas[j].NomeModelo, TextCompare: true) == 0 && indicePainelSel == mPortasUsadas[j].IndicePN && mPORTAS[k].IndiceDaPorta == mPortasUsadas[j].IndiceDaPorta)
					{
						ref string handlePorta = ref mPORTAS[k].HandlePorta;
						handlePorta = handlePorta + mPortasUsadas[j].HandlePorta + "|";
						ref string handleDef = ref mPORTAS[k].HandleDef;
						handleDef = handleDef + mPortasUsadas[j].HandleDef + "|";
						break;
					}
				}
			}
		}
	}

	private void CXLuJVs1IN(object P_0, EventArgs P_1)
	{
		PointMonitorToolTips.StopMonitor();
		int num = 1;
		bool flag = false;
		object[,] array = null;
		array = new object[6, 1]
		{
			{ "HANDLE DA PORTA" },
			{ "X" },
			{ "Y" },
			{ "INDICE DA PORTA" },
			{ DeclaracoesGeral.Conf.CaracterTerminalIndefinido },
			{ DeclaracoesGeral.Conf.CaracterTerminalIndefinido }
		};
		checked
		{
			try
			{
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				string left = "";
				int num2 = dgPortas.Rows.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					if (!dgPortas.Rows[i].Selected)
					{
						continue;
					}
					if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(dgPortas.Rows[i].Cells[8].Value, null, "trim", new object[0], null, null, null), "", TextCompare: true))
					{
						left = Conversions.ToString(Operators.AddObject(left, Operators.ConcatenateObject(dgPortas.Rows[i].Cells[8].Value, "; ")));
					}
					string text = Conversions.ToString(dgPortas.Rows[i].Cells[10].Value);
					if (Operators.CompareString(text, null, TextCompare: true) == 0)
					{
						text = "";
					}
					string[] array2 = text.Split('|');
					int num3 = Information.UBound(array2);
					for (int j = 0; j <= num3; j++)
					{
						if (Operators.CompareString(array2[j].Trim(), "", TextCompare: true) != 0)
						{
							array = (object[,])Utils.CopyArray(array, new object[6, num + 1]);
							array[0, num] = array2[j].Trim();
							array[1, num] = "E";
							num++;
						}
					}
				}
				if (Operators.CompareString(left, "", TextCompare: true) == 0)
				{
					goto IL_0237;
				}
				MsgBoxResult msgBoxResult = MsgBoxResult.No;
				msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 964]), MsgBoxStyle.YesNo, "Elétron");
				if (msgBoxResult != MsgBoxResult.No)
				{
					flag = true;
					goto IL_0237;
				}
				goto end_IL_006b;
				IL_0237:
				object[,] array3 = null;
				array3 = new object[6, 1]
				{
					{ "HANDLE DA PORTA" },
					{ "X" },
					{ "Y" },
					{ "INDICE DA PORTA" },
					{ DeclaracoesGeral.Conf.CaracterTerminalIndefinido },
					{ DeclaracoesGeral.Conf.CaracterTerminalIndefinido }
				};
				bool flag2 = false;
				mItensSelecionadosDG[] array4 = null;
				array4 = new mItensSelecionadosDG[1];
				int num4 = -1;
				string text2 = "";
				string sNome = "";
				string sNome2 = "";
				string sAlternativo = "";
				int num5 = dgMascaras.Rows.Count - 1;
				for (int k = 0; k <= num5; k++)
				{
					if (dgMascaras.Rows[k].Selected)
					{
						num4 = Conversions.ToInteger(dgMascaras.Rows[k].Cells[4].Value);
						text2 = Conversions.ToString(dgMascaras.Rows[k].Cells[0].Value);
						sNome = Conversions.ToString(dgMascaras.Rows[k].Cells[5].Value);
						sNome2 = Conversions.ToString(dgMascaras.Rows[k].Cells[6].Value);
						sAlternativo = Conversions.ToString(dgMascaras.Rows[k].Cells[7].Value);
						flag2 = true;
						break;
					}
				}
				int num6 = dgPortas.Rows.Count - 1;
				for (int l = 0; l <= num6; l++)
				{
					if (dgPortas.Rows[l].Selected)
					{
						int num7 = Information.UBound(array4) + 1;
						array4 = (mItensSelecionadosDG[])Utils.CopyArray(array4, new mItensSelecionadosDG[num7 + 1]);
						array4[num7].IndicePorta = Conversions.ToInteger(dgPortas.Rows[l].Cells[0].Value);
						array4[num7].IndiceModelo = Conversions.ToString(num4);
						array4[num7].EFC = Conversions.ToString(dgPortas.Rows[l].Cells[2].Value);
						array4[num7].Terminais = Conversions.ToString(dgPortas.Rows[l].Cells[3].Value);
						array4[num7].regua = Conversions.ToString(dgPortas.Rows[l].Cells[4].Value);
						array4[num7].Bornes = Conversions.ToString(dgPortas.Rows[l].Cells[5].Value);
						array4[num7].PgPorta = Conversions.ToString(dgPortas.Rows[l].Cells[8].Value);
						array4[num7].PgDef = Conversions.ToString(dgPortas.Rows[l].Cells[9].Value);
						array4[num7].HandleDaPorta = Conversions.ToString(dgPortas.Rows[l].Cells[10].Value);
						array4[num7].HandleDef = Conversions.ToString(dgPortas.Rows[l].Cells[11].Value);
						array4[num7].HandleDaMascara = "";
						flag2 = true;
					}
				}
				if (flag2)
				{
					flag2 = false;
					bool bDiferente = false;
					Hide();
					clsPortas.SelecionaPortas(ref array3, num4, sNome, sNome2, sAlternativo, ref flag2, ref bDiferente);
					if (flag2)
					{
						Show();
						if (!(bDiferente & !flag2))
						{
							if (flag2)
							{
								if (Information.UBound(array3, 2) > 0)
								{
									int num8 = Information.UBound(array3, 2);
									for (int m = 1; m <= num8; m++)
									{
										clsPortas.IndefineUmaPorta(Conversions.ToString(array3[0, m]), bLimpaTudo: false);
										array3[1, m] = "E";
									}
									clsPortas.RemoveUmaHandle(ref array3, ref mPortas_DefUsadas);
								}
								if (dgMascaras.SelectedRows.Count == 1)
								{
									int indice = Conversions.ToInteger(dgMascaras.SelectedRows[0].Cells[4].Value);
									string text3 = Conversions.ToString(dgMascaras.SelectedRows[0].Cells[5].Value);
									if (Operators.ConditionalCompareObjectNotEqual(dgMascaras.SelectedRows[0].Cells[6].Value, "", TextCompare: true))
									{
										text3 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dgMascaras.SelectedRows[0].Cells[5].Value, "/"), dgMascaras.SelectedRows[0].Cells[6].Value));
									}
									string sNome3 = text3;
									DataGridView dg = dgPortas;
									clsPortas.MarcaOsContatosUsadosNoDG(indice, sNome3, ref dg, ref mPortas_DefUsadas, indicePainelSel);
									dgPortas = dg;
									dg = dgPortas;
									AtualizaColunasDGPortasDefinicao(ref dg);
									dgPortas = dg;
								}
								if (flag)
								{
									if (Information.UBound(array, 2) > 0)
									{
										int num9 = Information.UBound(array, 2);
										for (int n = 1; n <= num9; n++)
										{
											if (Operators.ConditionalCompareObjectNotEqual(array[0, n], "", TextCompare: true))
											{
												clsPortas.IndefineUmaPorta(Conversions.ToString(array[0, n]), bLimpaTudo: false);
											}
										}
										clsPortas.RemoveUmaHandle(ref array, ref mPortas_DefUsadas);
									}
									if (dgMascaras.SelectedRows.Count == 1)
									{
										int indice2 = Conversions.ToInteger(dgMascaras.SelectedRows[0].Cells[4].Value);
										string text4 = Conversions.ToString(dgMascaras.SelectedRows[0].Cells[5].Value);
										if (Operators.ConditionalCompareObjectNotEqual(dgMascaras.SelectedRows[0].Cells[6].Value, "", TextCompare: true))
										{
											text4 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dgMascaras.SelectedRows[0].Cells[5].Value, "/"), dgMascaras.SelectedRows[0].Cells[6].Value));
										}
										string sNome4 = text4;
										DataGridView dg = dgPortas;
										clsPortas.MarcaOsContatosUsadosNoDG(indice2, sNome4, ref dg, ref mPortas_DefUsadas, indicePainelSel);
										dgPortas = dg;
										dg = dgPortas;
										AtualizaColunasDGPortasDefinicao(ref dg);
										dgPortas = dg;
									}
								}
								clsPortas.AtribuiPortas(text2, ref array3, ref array4, ref mPortas_DefUsadas, indicePainelSel);
								SEYuTE2oh6(_0020: true);
							}
							else
							{
								Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 962]));
							}
						}
						else
						{
							Interaction.MsgBox(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 961], text2));
						}
					}
					else
					{
						Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 963]));
						Show();
					}
				}
				else
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 960]));
				}
				end_IL_006b:;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			PointMonitorToolTips.StartMonitor();
		}
	}

	private void Wb4uhcbOjR(object P_0, EventArgs P_1)
	{
		PointMonitorToolTips.StopMonitor();
		string text = "";
		checked
		{
			try
			{
				object[,] array = null;
				array = new object[4, 1]
				{
					{ "HANDLE DA PORTA" },
					{ "T" },
					{ "Y" },
					{ "Y" }
				};
				int num = dgPortas.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (dgPortas.Rows[i].Selected)
					{
						if (Operators.CompareString(text, "", TextCompare: true) != 0)
						{
							text = text + text + "; ";
						}
						text = Conversions.ToString(Operators.AddObject(text, dgPortas.Rows[i].Cells[9].Value));
						break;
					}
				}
				if (Operators.CompareString(text, "", TextCompare: true) == 0)
				{
					goto IL_00d8;
				}
				MsgBoxResult msgBoxResult = MsgBoxResult.No;
				msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1188]), MsgBoxStyle.YesNo, "Elétron");
				if (msgBoxResult != MsgBoxResult.No)
				{
					int num2 = 0;
					string text2 = "";
					string text3 = "";
					int num3 = dgPortas.Rows.Count - 1;
					for (int j = 0; j <= num3; j++)
					{
						if (!dgPortas.Rows[j].Selected)
						{
							continue;
						}
						if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(dgPortas.Rows[j].Cells[9].Value, null, "trim", new object[0], null, null, null), "", TextCompare: true))
						{
							if (Operators.CompareString(text2, "", TextCompare: true) != 0)
							{
								text2 = text2 + text2 + "; ";
							}
							text2 = Conversions.ToString(dgPortas.Rows[j].Cells[9].Value);
							text3 = Conversions.ToString(dgPortas.Rows[j].Cells[11].Value);
							dgPortas.Rows[j].Cells[9].Value = "";
							dgPortas.Rows[j].Cells[11].Value = "";
						}
						if (Operators.CompareString(text3, null, TextCompare: true) == 0)
						{
							text3 = "";
						}
						string[] array2 = text3.Split('|');
						int num4 = Information.UBound(array2);
						for (int k = 0; k <= num4; k++)
						{
							text3 = array2[k].Trim();
							if (Operators.CompareString(text3, "", TextCompare: true) == 0)
							{
								continue;
							}
							bool flag = true;
							int num5 = Information.UBound(array, 2);
							for (int l = 0; l <= num5; l++)
							{
								if (Operators.ConditionalCompareObjectEqual(text3, array[0, l], TextCompare: true))
								{
									flag = false;
								}
							}
							if (flag)
							{
								array = (object[,])Utils.CopyArray(array, new object[4, num2 + 1]);
								array[0, num2] = text3;
								array[1, num2] = "T";
								clsPortas.IndefineUmaDefinicao(text3);
								num2++;
							}
						}
					}
					clsPortas.RemoveUmaHandle(ref array, ref mPortas_DefUsadas);
					goto IL_00d8;
				}
				goto end_IL_000b;
				IL_00d8:
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				object[,] array3 = null;
				array3 = new object[4, 1]
				{
					{ "HANDLE DA PORTA" },
					{ "T= Texto" },
					{ "X" },
					{ "Y" }
				};
				bool flag2 = false;
				mItensSelecionadosDG[] array4 = null;
				array4 = new mItensSelecionadosDG[1];
				int num6 = -1;
				string smodelo = "";
				string handleDaMascara = "";
				int num7 = dgMascaras.Rows.Count - 1;
				for (int m = 0; m <= num7; m++)
				{
					if (dgMascaras.Rows[m].Selected)
					{
						num6 = Conversions.ToInteger(dgMascaras.Rows[m].Cells[4].Value);
						smodelo = Conversions.ToString(dgMascaras.Rows[m].Cells[0].Value);
						handleDaMascara = Conversions.ToString(dgMascaras.Rows[m].Cells[3].Value);
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 965]));
					return;
				}
				flag2 = false;
				int num8 = dgPortas.Rows.Count - 1;
				for (int n = 0; n <= num8; n++)
				{
					if (dgPortas.Rows[n].Selected)
					{
						int num9 = Information.UBound(array4) + 1;
						array4 = (mItensSelecionadosDG[])Utils.CopyArray(array4, new mItensSelecionadosDG[num9 + 1]);
						array4[num9].IndicePorta = Conversions.ToInteger(dgPortas.Rows[n].Cells[0].Value);
						array4[num9].IndiceModelo = Conversions.ToString(num6);
						array4[num9].EFC = Conversions.ToString(dgPortas.Rows[n].Cells[2].Value);
						array4[num9].Terminais = Conversions.ToString(dgPortas.Rows[n].Cells[3].Value);
						array4[num9].regua = Conversions.ToString(dgPortas.Rows[n].Cells[4].Value);
						array4[num9].Bornes = Conversions.ToString(dgPortas.Rows[n].Cells[5].Value);
						array4[num9].PgPorta = Conversions.ToString(dgPortas.Rows[n].Cells[8].Value);
						array4[num9].PgDef = Conversions.ToString(dgPortas.Rows[n].Cells[9].Value);
						array4[num9].HandleDaPorta = Conversions.ToString(dgPortas.Rows[n].Cells[10].Value);
						array4[num9].HandleDef = Conversions.ToString(dgPortas.Rows[n].Cells[11].Value);
						array4[num9].HandleDaMascara = handleDaMascara;
						flag2 = true;
					}
				}
				Hide();
				clsPortas.SelecionaPortasOuDefinicao(ref array3, "T");
				Show();
				if (Information.UBound(array, 2) > 0)
				{
					clsPortas.RemoveUmaHandle(ref array, ref mPortas_DefUsadas);
				}
				int num10 = Information.UBound(array, 2);
				for (int num11 = 0; num11 <= num10; num11++)
				{
					if (Operators.ConditionalCompareObjectNotEqual(array[0, num11], "", TextCompare: true))
					{
						clsPortas.IndefineUmaDefinicao(Conversions.ToString(array[0, num11]));
					}
				}
				if (Information.UBound(array3, 2) > 0)
				{
					clsPortas.RemoveUmaHandle(ref array3, ref mPortas_DefUsadas);
					clsPortas.InserePaginaAsDefinicoes(ref array3, ref array4);
					clsPortas.AtribuiDefinicao(smodelo, ref array3, ref array4, ref mPortas_DefUsadas);
				}
				if (Information.UBound(array3, 2) > 0)
				{
					SEYuTE2oh6(_0020: true);
				}
				end_IL_000b:;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			PointMonitorToolTips.StartMonitor();
		}
	}

	private void h9huoAb70U(object P_0, EventArgs P_1)
	{
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Expected Obj, but got Unknown
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Expected Obj, but got Unknown
		//IL_0365: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Expected Obj, but got Unknown
		BTAtribuiDefAPaginaCorrente.Enabled = false;
		BtAtribuiMDefinicoes.Enabled = false;
		BtAtribuiMPortas.Enabled = false;
		BTConstroiLink.Enabled = false;
		BTLimpaDefinicoes.Enabled = false;
		btSeleciona.Enabled = false;
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		bool flag = false;
		object[,] array = null;
		array = new object[7, 1]
		{
			{ "IndicePorta" },
			{ "EFC" },
			{ "Terminais" },
			{ "regua" },
			{ "Bornes" },
			{ "IndiceModelo" },
			{ "HandleDaPorta" }
		};
		int num = -1;
		string text = "";
		string text2 = "";
		checked
		{
			int num2 = dgMascaras.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (dgMascaras.Rows[i].Selected)
				{
					num = Conversions.ToInteger(dgMascaras.Rows[i].Cells[4].Value);
					text = Conversions.ToString(dgMascaras.Rows[i].Cells[0].Value);
					text2 = Conversions.ToString(dgMascaras.Rows[i].Cells[3].Value);
					flag = true;
					break;
				}
			}
			int num3 = dgPortas.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				int num4 = Information.UBound(array, 2) + 1;
				array = (object[,])Utils.CopyArray(array, new object[7, num4 + 1]);
				array[0, num4] = RuntimeHelpers.GetObjectValue(dgPortas.Rows[j].Cells[0].Value);
				array[1, num4] = RuntimeHelpers.GetObjectValue(dgPortas.Rows[j].Cells[2].Value);
				array[2, num4] = RuntimeHelpers.GetObjectValue(dgPortas.Rows[j].Cells[3].Value);
				array[3, num4] = RuntimeHelpers.GetObjectValue(dgPortas.Rows[j].Cells[4].Value);
				array[4, num4] = RuntimeHelpers.GetObjectValue(dgPortas.Rows[j].Cells[5].Value);
				array[5, num4] = num;
				array[6, num4] = text2;
				flag = true;
			}
			if (flag)
			{
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
								Entity Ent = (Entity)val2.GetObject(current, (OpenMode)0);
								if (Ent == null || Operators.CompareString(Ent.Layer, DeclaracoesGeral.ativo.Pagina, TextCompare: true) != 0)
								{
									continue;
								}
								DBText val5 = (DBText)(object)((Ent is DBText) ? Ent : null);
								if (val5 == null)
								{
									continue;
								}
								DeclaracoesEntidades.StructureDefinicaoPortas Def = default;
								XDataDispositivosMaster.LerXDataDefinicao(ref Ent, ref Def);
								if (Def.Nome == null)
								{
									if (Operators.CompareString(nLkuGyAknC(Strings.Trim(val5.TextString)), "", TextCompare: true) == 0)
									{
										continue;
									}
									string textString = val5.TextString;
									int num5 = Information.UBound(array, 2);
									for (int k = 1; k <= num5; k++)
									{
										if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(array[5, k], num, TextCompare: true), Operators.CompareObjectEqual(Operators.ConcatenateObject(Operators.ConcatenateObject("(", array[1, k]), ")"), textString, TextCompare: true))))
										{
											Def.HandleDaMascara = Conversions.ToString(array[6, k]);
											Def.handleDaPorta = "";
											Def.indiceDaPorta = Conversions.ToInteger(array[0, k]);
											Def.indiceDoModelo = Conversions.ToInteger(array[5, k]);
											XDataDispositivosMaster.GravarXDataDefinicao(ref Ent, ref Def);
										}
									}
									continue;
								}
								int num6 = Information.UBound(array, 2);
								for (int l = 1; l <= num6; l++)
								{
									if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(array[5, l], Def.indiceDoModelo, TextCompare: true), Operators.CompareObjectEqual(array[0, l], Def.indiceDaPorta, TextCompare: true))))
									{
										((DBObject)val5).UpgradeOpen();
										val5.TextString = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.Conf.PrefixoCruzInterno, array[1, l]), DeclaracoesGeral.Conf.SufixoCruzInterno));
										break;
									}
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
				clsPortas.SincronizaPortas();
				if (dgMascaras.RowCount > 0)
				{
					clsDispositivoMascaras.PesquisaTodasAsPortasEDefinicoesUsadas(ref mPortas_DefUsadas);
					int[] array2 = new int[1];
					int num7 = dgPortas.Rows.Count - 1;
					for (int m = 0; m <= num7; m++)
					{
						if (dgPortas.Rows[m].Selected)
						{
							int num8 = Information.UBound(array2) + 1;
							array2 = (int[])Utils.CopyArray(array2, new int[num8 + 1]);
							array2[num8] = Conversions.ToInteger(dgPortas.Rows[m].Cells[0].Value);
						}
					}
					int indice = num;
					string sNome = text;
					DataGridView dg = dgPortas;
					clsPortas.MarcaOsContatosUsadosNoDG(indice, sNome, ref dg, ref mPortas_DefUsadas, indicePainelSel);
					dgPortas = dg;
					dg = dgPortas;
					AtualizaColunasDGPortasDefinicao(ref dg);
					dgPortas = dg;
					int num9 = dgPortas.Rows.Count - 1;
					for (int n = num9; n >= 0; n += -1)
					{
						int num10 = Information.UBound(array2);
						for (int num11 = num10; num11 >= 1; num11 += -1)
						{
							if (Operators.CompareString(dgPortas.Rows[n].Cells[0].Value.ToString(), array2[num11].ToString(), TextCompare: true) == 0)
							{
								dgPortas.Rows[n].Selected = true;
								if (num11 == 1)
								{
									dgPortas.FirstDisplayedScrollingRowIndex = n;
								}
							}
						}
					}
				}
			}
			BTAtribuiDefAPaginaCorrente.Enabled = true;
			BtAtribuiMDefinicoes.Enabled = true;
			BtAtribuiMPortas.Enabled = true;
			BTConstroiLink.Enabled = true;
			BTLimpaDefinicoes.Enabled = true;
			btSeleciona.Enabled = true;
		}
	}

	private string nLkuGyAknC(string P_0)
	{
		string result = "";
		P_0 = Strings.Trim(P_0);
		int num = Strings.Len(P_0);
		if (Operators.CompareString(Strings.Trim(Strings.Mid(P_0, 1, 1)), "(", TextCompare: true) == 0 && Operators.CompareString(Strings.Trim(Strings.Mid(P_0, num, num)), ")", TextCompare: true) == 0)
		{
			result = P_0;
		}
		return result;
	}

	private void rmquHZ1POf(object P_0, EventArgs P_1)
	{
		object[,] array = null;
		array = new object[4, 1]
		{
			{ "HANDLE DA PORTA" },
			{ "Tipo E= Porta | T= Texto" },
			{ "X" },
			{ "Y" }
		};
		int[] array2 = new int[1];
		checked
		{
			int num = dgPortas.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgPortas.Rows[i].Selected)
				{
					int num2 = Information.UBound(array2) + 1;
					array2 = (int[])Utils.CopyArray(array2, new int[num2 + 1]);
					array2[num2] = i;
				}
			}
			if (!RB1.Checked)
			{
				if (!RB2.Checked)
				{
					if (RB3.Checked)
					{
						int num3 = 0;
						foreach (object item in zeHunA7Hj1)
						{
							object objectValue = RuntimeHelpers.GetObjectValue(item);
							num3++;
							array = (object[,])Utils.CopyArray(array, new object[4, num3 + 1]);
							array[0, num3] = RuntimeHelpers.GetObjectValue(objectValue);
							array[1, num3] = "T";
							array[2, num3] = 0;
							array[3, num3] = 0;
						}
						if (Information.UBound(array, 2) > 0)
						{
							int num4 = Information.UBound(array, 2);
							for (int j = 1; j <= num4; j++)
							{
								if (Operators.ConditionalCompareObjectEqual(array[1, j], "T", TextCompare: true))
								{
									clsPortas.IndefineUmaDefinicao(Conversions.ToString(array[0, j]));
								}
							}
							clsPortas.RemoveUmaHandle(ref array, ref mPortas_DefUsadas);
						}
					}
				}
				else
				{
					int num5 = 0;
					foreach (object item2 in Maju3Cc37h)
					{
						object objectValue2 = RuntimeHelpers.GetObjectValue(item2);
						num5++;
						array = (object[,])Utils.CopyArray(array, new object[4, num5 + 1]);
						array[0, num5] = RuntimeHelpers.GetObjectValue(objectValue2);
						array[1, num5] = "E";
						array[2, num5] = 0;
						array[3, num5] = 0;
					}
					if (Information.UBound(array, 2) > 0)
					{
						int num6 = Information.UBound(array, 2);
						for (int k = 1; k <= num6; k++)
						{
							if (Operators.ConditionalCompareObjectEqual(array[1, k], "E", TextCompare: true))
							{
								clsPortas.IndefineUmaPorta(Conversions.ToString(array[0, k]), bLimpaTudo: false);
							}
						}
						clsPortas.RemoveUmaHandle(ref array, ref mPortas_DefUsadas);
					}
				}
			}
			else
			{
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				PointMonitorToolTips.StopMonitor();
				Hide();
				clsPortas.SelecionaPortasOuDefinicao(ref array, "ALL");
				if (Information.UBound(array, 2) > 0)
				{
					int num7 = Information.UBound(array, 2);
					for (int l = 1; l <= num7; l++)
					{
						if (Operators.ConditionalCompareObjectEqual(array[1, l], "E", TextCompare: true))
						{
							clsPortas.IndefineUmaPorta(Conversions.ToString(array[0, l]), bLimpaTudo: false);
						}
						if (Operators.ConditionalCompareObjectEqual(array[1, l], "T", TextCompare: true))
						{
							clsPortas.IndefineUmaDefinicao(Conversions.ToString(array[0, l]));
						}
					}
					clsPortas.RemoveUmaHandle(ref array, ref mPortas_DefUsadas);
				}
			}
			if (dgMascaras.SelectedRows.Count == 1)
			{
				int indice = Conversions.ToInteger(dgMascaras.SelectedRows[0].Cells[4].Value);
				string text = Conversions.ToString(dgMascaras.SelectedRows[0].Cells[5].Value);
				if (Operators.ConditionalCompareObjectNotEqual(dgMascaras.SelectedRows[0].Cells[6].Value, "", TextCompare: true))
				{
					text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(dgMascaras.SelectedRows[0].Cells[5].Value, "/"), dgMascaras.SelectedRows[0].Cells[6].Value));
				}
				string sNome = text;
				DataGridView dg = dgPortas;
				clsPortas.MarcaOsContatosUsadosNoDG(indice, sNome, ref dg, ref mPortas_DefUsadas, indicePainelSel);
				dgPortas = dg;
				dg = dgPortas;
				AtualizaColunasDGPortasDefinicao(ref dg);
				dgPortas = dg;
			}
			int num8 = dgPortas.Rows.Count - 1;
			for (int m = 0; m <= num8; m++)
			{
				int num9 = Information.UBound(array2);
				for (int n = 1; n <= num9; n++)
				{
					if ((double)m == Conversions.ToDouble(array2[n].ToString()))
					{
						dgPortas.Rows[m].Selected = true;
						if (n == 1)
						{
							dgPortas.FirstDisplayedScrollingRowIndex = array2[n];
						}
					}
				}
			}
			if (RB1.Checked)
			{
				Show();
			}
			PointMonitorToolTips.StartMonitor();
			C1UuvCIWXG();
		}
	}

	private void Dq4ukqAFgm(object P_0, EventArgs P_1)
	{
		BTAtribuiDefAPaginaCorrente.Enabled = false;
		BtAtribuiMDefinicoes.Enabled = false;
		BtAtribuiMPortas.Enabled = false;
		BTConstroiLink.Enabled = false;
		BTLimpaDefinicoes.Enabled = false;
		btSeleciona.Enabled = false;
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		clsPortas.SincronizaPortas();
		checked
		{
			if (dgMascaras.RowCount > 0)
			{
				clsDispositivoMascaras.PesquisaTodasAsPortasEDefinicoesUsadas(ref mPortas_DefUsadas);
				int[] array = new int[1];
				int num = dgPortas.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (dgPortas.Rows[i].Selected)
					{
						int num2 = Information.UBound(array) + 1;
						array = (int[])Utils.CopyArray(array, new int[num2 + 1]);
						array[num2] = Conversions.ToInteger(dgPortas.Rows[i].Cells[0].Value);
					}
				}
				int num3 = -1;
				string text = "";
				int num4 = dgMascaras.Rows.Count - 1;
				for (int j = 0; j <= num4; j++)
				{
					if (dgMascaras.Rows[j].Selected)
					{
						num3 = Conversions.ToInteger(dgMascaras.Rows[j].Cells[4].Value);
						text = Conversions.ToString(dgMascaras.Rows[j].Cells[0].Value);
						break;
					}
				}
				int indice = num3;
				string sNome = text;
				DataGridView dg = dgPortas;
				clsPortas.MarcaOsContatosUsadosNoDG(indice, sNome, ref dg, ref mPortas_DefUsadas, indicePainelSel);
				dgPortas = dg;
				dg = dgPortas;
				AtualizaColunasDGPortasDefinicao(ref dg);
				dgPortas = dg;
				int num5 = dgPortas.Rows.Count - 1;
				for (int k = num5; k >= 0; k += -1)
				{
					int num6 = Information.UBound(array);
					for (int l = num6; l >= 1; l += -1)
					{
						if (Operators.CompareString(dgPortas.Rows[k].Cells[0].Value.ToString(), array[l].ToString(), TextCompare: true) == 0)
						{
							dgPortas.Rows[k].Selected = true;
							if (l == 1)
							{
								dgPortas.FirstDisplayedScrollingRowIndex = k;
							}
						}
					}
				}
			}
			BTAtribuiDefAPaginaCorrente.Enabled = true;
			BtAtribuiMDefinicoes.Enabled = true;
			BtAtribuiMPortas.Enabled = true;
			BTConstroiLink.Enabled = true;
			BTLimpaDefinicoes.Enabled = true;
			btSeleciona.Enabled = true;
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
				if (mMasc == null || Information.UBound(mMasc) <= 0)
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
				dg.Columns.Add("Alternativo", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1003]));
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
					if (LikeOperator.LikeString(text.ToString().ToUpper(), "*" + sPesquisa.ToUpper() + "*", CompareMethod.Text) | LikeOperator.LikeString(mMasc[k].sPainel.ToUpper(), "*" + sPesquisa.ToUpper() + "*", CompareMethod.Text))
					{
						dg.Rows.Add(text, mMasc[k].sPainel, mMasc[k].iPainel, mMasc[k].sHandle, mMasc[k].iIndiceModelo, mMasc[k].sNome1, mMasc[k].sNome2, mMasc[k].sNome3, mMasc[k].sPainel, text, mMasc[k].sNome3);
					}
				}
				foreach (DataGridViewRow item in (IEnumerable)dg.Rows)
				{
					dg.Rows[item.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				int num4 = dg.Rows.Count - 1;
				for (int l = 0; l <= num4; l++)
				{
					int num5 = 0;
					do
					{
						if (Operators.ConditionalCompareObjectEqual(dg.Rows[l].Cells[num5].Value, null, TextCompare: true) && !Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dg.Rows[l].Cells[num5].Value)))
						{
							dg.Rows[l].Cells[num5].Value = "";
						}
						num5++;
					}
					while (num5 <= 10);
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

	private void T9Vuditmrd(object P_0, EventArgs P_1)
	{
		int iPainel = 0;
		BlockReference ent = null;
		li4u2ETF3v.HandleBloco = "";
		clsPortas.selecionaUmaPortaInserida(ref li4u2ETF3v, ref iPainel, ref ent);
		checked
		{
			if (iPainel > 0)
			{
				int num = dgMascaras.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (!Operators.ConditionalCompareObjectEqual(iPainel, dgMascaras.Rows[i].Cells[2].Value, TextCompare: true) || !Operators.ConditionalCompareObjectEqual(li4u2ETF3v.indiceDoModelo, dgMascaras.Rows[i].Cells[4].Value, TextCompare: true) || !Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(li4u2ETF3v.Nome1, dgMascaras.Rows[i].Cells[5].Value, TextCompare: true), Operators.CompareObjectEqual(li4u2ETF3v.Nome2, dgMascaras.Rows[i].Cells[6].Value, TextCompare: true))))
					{
						continue;
					}
					dgMascaras.CurrentCell = dgMascaras.Rows[i].Cells[8];
					dgMascaras.Rows[i].Selected = true;
					if (!((li4u2ETF3v.indiceDaPorta > 0) & (dgPortas.Rows.Count >= 1)))
					{
						continue;
					}
					int num2 = dgPortas.Rows.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						if (Operators.ConditionalCompareObjectEqual(li4u2ETF3v.indiceDaPorta, dgPortas.Rows[j].Cells[0].Value, TextCompare: true))
						{
							dgPortas.Rows[j].Selected = true;
							dgPortas.CurrentCell = dgPortas.Rows[j].Cells[0];
							dgPortas.FirstDisplayedScrollingRowIndex = j;
							break;
						}
					}
				}
			}
			C1UuvCIWXG();
		}
	}

	public static bool AtualizaColunasDGMascaraDG(ref DataGridView dg)
	{
		bool flag = false;
		checked
		{
			if (dg.RowCount != 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
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
					num4 = num * 0.35;
					num5 = num * 0.25;
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
			return flag;
		}
	}

	public static void AtualizaColunasDGPortasDefinicao(ref DataGridView dgPortas)
	{
		checked
		{
			if (dgPortas.RowCount != 0)
			{
				dgPortas.ColumnHeadersVisible = true;
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgPortas)) ? ((double)(dgPortas.Width - 4)) : ((double)(dgPortas.Width - 21)));
				dgPortas.Columns[0].Width = (int)Math.Round(num * 0.08);
				dgPortas.Columns[1].Width = 0;
				dgPortas.Columns[2].Width = (int)Math.Round(num * 0.18);
				dgPortas.Columns[3].Width = (int)Math.Round(num * 0.2);
				dgPortas.Columns[4].Width = (int)Math.Round(num * 0.15);
				dgPortas.Columns[5].Width = (int)Math.Round(num * 0.15);
				dgPortas.Columns[6].Width = 0;
				dgPortas.Columns[7].Width = 0;
				dgPortas.Columns[8].Width = (int)Math.Round(num * 0.12);
				dgPortas.Columns[9].Width = (int)Math.Round(num * 0.12);
				dgPortas.Columns[10].Width = 0;
				dgPortas.Columns[11].Width = 0;
				dgPortas.Columns[0].Visible = true;
				dgPortas.Columns[1].Visible = false;
				dgPortas.Columns[2].Visible = true;
				dgPortas.Columns[3].Visible = true;
				dgPortas.Columns[4].Visible = true;
				dgPortas.Columns[5].Visible = true;
				dgPortas.Columns[6].Visible = false;
				dgPortas.Columns[7].Visible = false;
				dgPortas.Columns[8].Visible = true;
				dgPortas.Columns[9].Visible = true;
				dgPortas.Columns[10].Visible = false;
				dgPortas.Columns[11].Visible = false;
				dgPortas.Columns[0].ReadOnly = false;
				dgPortas.Columns[1].ReadOnly = false;
				dgPortas.Columns[2].ReadOnly = false;
				dgPortas.Columns[3].ReadOnly = false;
				dgPortas.Columns[4].ReadOnly = false;
				dgPortas.Columns[5].ReadOnly = false;
				dgPortas.Columns[6].ReadOnly = false;
				dgPortas.Columns[7].ReadOnly = false;
				dgPortas.Columns[8].ReadOnly = false;
				dgPortas.Columns[9].ReadOnly = false;
				dgPortas.Columns[10].ReadOnly = false;
				dgPortas.Columns[11].ReadOnly = false;
				dgPortas.MultiSelect = true;
			}
			else
			{
				dgPortas.Rows.Clear();
				dgPortas.Columns.Clear();
			}
		}
	}

	private void AcqufNNeU4(object P_0, EventArgs P_1)
	{
		if (!bInicializacao)
		{
			DataGridView withEventsValue = dgPortas;
			AtualizaColunasDGPortasDefinicao(ref withEventsValue);
			dgPortas = withEventsValue;
		}
	}

	private void NfruDjShWg(object P_0, MouseEventArgs P_1)
	{
		int num = 0;
		DataGridView.HitTestInfo hitTestInfo = dgPortas.HitTest(P_1.X, P_1.Y);
		if (hitTestInfo.RowIndex < 0)
		{
			return;
		}
		DataGridViewRow data = dgPortas.Rows[hitTestInfo.RowIndex];
		num = hitTestInfo.RowIndex;
		dgPortas.Rows[num].Selected = true;
		dgPortas.DoDragDrop(data, DragDropEffects.All);
		string text = "";
		if (hitTestInfo.ColumnIndex == 8)
		{
			text = Conversions.ToString(dgPortas.Rows[num].Cells[10].Value);
			text = text.Replace("|", "");
			if (Operators.CompareString(text, "", TextCompare: true) != 0)
			{
				clsBlocos.MostraBloco(text);
			}
		}
		if (hitTestInfo.ColumnIndex == 9)
		{
			text = Conversions.ToString(dgPortas.Rows[num].Cells[11].Value);
			text = text.Replace("|", "");
			if (Operators.CompareString(text, "", TextCompare: true) != 0)
			{
				clsBlocos.MostraBloco(text);
			}
		}
	}

	private void C1UuvCIWXG()
	{
		RB2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1754]);
		RB3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1755]);
		if (bInicializacao)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		string text = "";
		Maju3Cc37h.Clear();
		zeHunA7Hj1.Clear();
		checked
		{
			int num3 = dgPortas.Rows.Count - 1;
			for (int i = 0; i <= num3; i++)
			{
				if (!dgPortas.Rows[i].Selected)
				{
					continue;
				}
				if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(dgPortas.Rows[i].Cells[8].Value, null, "trim", new object[0], null, null, null), "", TextCompare: true))
				{
					text = Conversions.ToString(NewLateBinding.LateGet(dgPortas.Rows[i].Cells[10].Value, null, "trim", new object[0], null, null, null));
					text = text.Replace("|", "");
					if (Operators.CompareString(text, "", TextCompare: true) != 0)
					{
						Maju3Cc37h.Add(text);
						num++;
					}
				}
				if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(dgPortas.Rows[i].Cells[9].Value, null, "trim", new object[0], null, null, null), "", TextCompare: true))
				{
					text = Conversions.ToString(NewLateBinding.LateGet(dgPortas.Rows[i].Cells[11].Value, null, "trim", new object[0], null, null, null));
					text = text.Replace("|", "");
					if (Operators.CompareString(text, "", TextCompare: true) != 0)
					{
						zeHunA7Hj1.Add(text);
						num2++;
					}
				}
			}
			if (num <= 0)
			{
				RB2.Enabled = false;
			}
			else
			{
				RB2.Enabled = true;
				if (num != 1)
				{
					RB2.Text = Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(num) + " - ", DeclaracoesGeral.mMensagem[1, 1754]));
				}
				else
				{
					RB2.Text = Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(num) + " - ", DeclaracoesGeral.mMensagem[1, 1758]));
				}
			}
			if (num2 <= 0)
			{
				RB3.Enabled = false;
			}
			else
			{
				RB3.Enabled = true;
				if (num2 != 1)
				{
					RB3.Text = Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(num2) + " - ", DeclaracoesGeral.mMensagem[1, 1755]));
				}
				else
				{
					RB3.Text = Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(num2) + " - ", DeclaracoesGeral.mMensagem[1, 1759]));
				}
			}
			if (num == 0 && RB2.Checked)
			{
				RB1.Checked = true;
			}
			if (num2 == 0 && RB3.Checked)
			{
				RB1.Checked = true;
			}
		}
	}

	private void ySZu63HlZW(object P_0, MouseEventArgs P_1)
	{
		C1UuvCIWXG();
	}

	private void Nyfut3SJKF(object P_0, KeyEventArgs P_1)
	{
		C1UuvCIWXG();
	}
}
