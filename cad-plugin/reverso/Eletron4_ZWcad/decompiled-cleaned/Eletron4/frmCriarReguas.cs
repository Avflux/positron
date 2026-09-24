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
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmCriarReguas : Form
{
	private IContainer t0GV1UhPJx;

	[AccessedThroughProperty("FolderBrowser")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private FolderBrowserDialog kZkVlnIgcc;

	[AccessedThroughProperty("dgReguas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView YLcV5QsO82;

	[AccessedThroughProperty("ToolTip1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolTip FWeV0TMj5H;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("tbRegua")]
	private TextBox IV7VRwg0X7;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtEditaRegua")]
	[CompilerGenerated]
	private Button MZtVmSDWFd;

	[AccessedThroughProperty("BtApagaRegua")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button GN3VXKpw67;

	[AccessedThroughProperty("BtAdicionaRegua")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button qiiVU2rKUx;

	[AccessedThroughProperty("GroupBox2")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox L74Vy2ZSm5;

	[AccessedThroughProperty("TBAlternativo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox pLBVgWMrhp;

	[AccessedThroughProperty("lbAlternativo")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label v71VACLFkk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgPaineis")]
	private DataGridView X4IVsps7Lk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LbFiltro")]
	private Label EcLVB9nygR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBPesquisa")]
	private TextBox JQpVV6wuph;

	[AccessedThroughProperty("btUsados")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button LVWVugEffQ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelQuantidade")]
	private Label HZQVE60YPd;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagaReguasSemBornes")]
	[CompilerGenerated]
	private Button X3UVZuNbOA;

	private Declaracoes2.StructureModeloDeReguas[] OdEVibPPw3;

	private bool s8LVSyIQnT;

	private int mwoV4gD173;

	private string leoVCNec73;

	private string fKfVYsxh1U;

	private int iISVrdDosS;

	private string AFaV9embDX;

	internal virtual DataGridView dgReguas
	{
		[CompilerGenerated]
		get
		{
			return YLcV5QsO82;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = HAiVN3wseM;
			DataGridViewCellEventHandler value3 = hfdVFnv92w;
			DataGridView dataGridView = YLcV5QsO82;
			if (dataGridView != null)
			{
				dataGridView.MouseUp -= value2;
				dataGridView.CellClick -= value3;
			}
			YLcV5QsO82 = value;
			dataGridView = YLcV5QsO82;
			if (dataGridView != null)
			{
				dataGridView.MouseUp += value2;
				dataGridView.CellClick += value3;
			}
		}
	}

	internal virtual TextBox tbRegua
	{
		[CompilerGenerated]
		get
		{
			return IV7VRwg0X7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = u0PVIYvsol;
			EventHandler value3 = RqXV3XKY1E;
			TextBox textBox = IV7VRwg0X7;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
				textBox.Leave -= value3;
			}
			IV7VRwg0X7 = value;
			textBox = IV7VRwg0X7;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
				textBox.Leave += value3;
			}
		}
	}

	internal virtual Button BtEditaRegua
	{
		[CompilerGenerated]
		get
		{
			return MZtVmSDWFd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = eE3VaP3EGs;
			Button button = MZtVmSDWFd;
			if (button != null)
			{
				button.Click -= value2;
			}
			MZtVmSDWFd = value;
			button = MZtVmSDWFd;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BtApagaRegua
	{
		[CompilerGenerated]
		get
		{
			return GN3VXKpw67;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = KJdV8rnoZm;
			Button button = GN3VXKpw67;
			if (button != null)
			{
				button.Click -= value2;
			}
			GN3VXKpw67 = value;
			button = GN3VXKpw67;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BtAdicionaRegua
	{
		[CompilerGenerated]
		get
		{
			return qiiVU2rKUx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FAnVqqFS4X;
			Button button = qiiVU2rKUx;
			if (button != null)
			{
				button.Click -= value2;
			}
			qiiVU2rKUx = value;
			button = qiiVU2rKUx;
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
			return L74Vy2ZSm5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			L74Vy2ZSm5 = value;
		}
	}

	internal virtual TextBox TBAlternativo
	{
		[CompilerGenerated]
		get
		{
			return pLBVgWMrhp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = TAMV7JuRLs;
			EventHandler value3 = X3vVnRQj53;
			TextBox textBox = pLBVgWMrhp;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
				textBox.Leave -= value3;
			}
			pLBVgWMrhp = value;
			textBox = pLBVgWMrhp;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
				textBox.Leave += value3;
			}
		}
	}

	internal virtual Label lbAlternativo
	{
		[CompilerGenerated]
		get
		{
			return v71VACLFkk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			v71VACLFkk = value;
		}
	}

	internal virtual DataGridView dgPaineis
	{
		[CompilerGenerated]
		get
		{
			return X4IVsps7Lk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = BSwVPaZyBx;
			DataGridView dataGridView = X4IVsps7Lk;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			X4IVsps7Lk = value;
			dataGridView = X4IVsps7Lk;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual Label LbFiltro
	{
		[CompilerGenerated]
		get
		{
			return EcLVB9nygR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EcLVB9nygR = value;
		}
	}

	internal virtual TextBox TBPesquisa
	{
		[CompilerGenerated]
		get
		{
			return JQpVV6wuph;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = oELVcWFRWn;
			TextBox textBox = JQpVV6wuph;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			JQpVV6wuph = value;
			textBox = JQpVV6wuph;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Button btUsados
	{
		[CompilerGenerated]
		get
		{
			return LVWVugEffQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = KaoVex4TUC;
			Button button = LVWVugEffQ;
			if (button != null)
			{
				button.Click -= value2;
			}
			LVWVugEffQ = value;
			button = LVWVugEffQ;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label LabelQuantidade
	{
		[CompilerGenerated]
		get
		{
			return HZQVE60YPd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			HZQVE60YPd = value;
		}
	}

	internal virtual Button btApagaReguasSemBornes
	{
		[CompilerGenerated]
		get
		{
			return X3UVZuNbOA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = zTkV2VZvrK;
			Button button = X3UVZuNbOA;
			if (button != null)
			{
				button.Click -= value2;
			}
			X3UVZuNbOA = value;
			button = X3UVZuNbOA;
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
			if (disposing && t0GV1UhPJx != null)
			{
				t0GV1UhPJx.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void RkNVOxucqX()
	{
		t0GV1UhPJx = new Container();
		aHypBEW66iS(new FolderBrowserDialog());
		dgReguas = new DataGridView();
		FDqpBiUmZij(new ToolTip(t0GV1UhPJx));
		dgPaineis = new DataGridView();
		tbRegua = new TextBox();
		BtEditaRegua = new Button();
		BtApagaRegua = new Button();
		BtAdicionaRegua = new Button();
		GroupBox2 = new GroupBox();
		btApagaReguasSemBornes = new Button();
		TBAlternativo = new TextBox();
		lbAlternativo = new Label();
		LbFiltro = new Label();
		TBPesquisa = new TextBox();
		btUsados = new Button();
		LabelQuantidade = new Label();
		((ISupportInitialize)dgReguas).BeginInit();
		((ISupportInitialize)dgPaineis).BeginInit();
		GroupBox2.SuspendLayout();
		SuspendLayout();
		dgReguas.AllowUserToAddRows = false;
		dgReguas.AllowUserToDeleteRows = false;
		dgReguas.AllowUserToOrderColumns = true;
		dgReguas.AllowUserToResizeRows = false;
		dgReguas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		dgReguas.BackgroundColor = SystemColors.ButtonHighlight;
		dgReguas.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgReguas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgReguas.Location = new Point(194, 5);
		dgReguas.Name = "dgReguas";
		dgReguas.ReadOnly = true;
		dgReguas.RowHeadersVisible = false;
		dgReguas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgReguas.Size = new Size(186, 226);
		dgReguas.TabIndex = 117;
		dgPaineis.AllowUserToAddRows = false;
		dgPaineis.AllowUserToDeleteRows = false;
		dgPaineis.AllowUserToOrderColumns = true;
		dgPaineis.AllowUserToResizeRows = false;
		dgPaineis.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgPaineis.BackgroundColor = SystemColors.ButtonHighlight;
		dgPaineis.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dgPaineis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPaineis.Location = new Point(3, 53);
		dgPaineis.Name = "dgPaineis";
		dgPaineis.ReadOnly = true;
		dgPaineis.RowHeadersVisible = false;
		dgPaineis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPaineis.Size = new Size(185, 301);
		dgPaineis.TabIndex = 148;
		tbRegua.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbRegua.Location = new Point(6, 36);
		tbRegua.Name = "tbRegua";
		tbRegua.Size = new Size(172, 20);
		tbRegua.TabIndex = 145;
		BtEditaRegua.FlatStyle = FlatStyle.Flat;
		BtEditaRegua.ForeColor = SystemColors.Control;
		BtEditaRegua.Image = Resources.Editar;
		BtEditaRegua.Location = new Point(50, 72);
		BtEditaRegua.Name = "BtEditaRegua";
		BtEditaRegua.Size = new Size(40, 40);
		BtEditaRegua.TabIndex = 144;
		BtEditaRegua.UseVisualStyleBackColor = true;
		BtApagaRegua.FlatStyle = FlatStyle.Flat;
		BtApagaRegua.ForeColor = SystemColors.Control;
		BtApagaRegua.Image = Resources.Delete_32;
		BtApagaRegua.Location = new Point(96, 71);
		BtApagaRegua.Name = "BtApagaRegua";
		BtApagaRegua.Size = new Size(40, 40);
		BtApagaRegua.TabIndex = 142;
		BtApagaRegua.Tag = "";
		BtApagaRegua.UseVisualStyleBackColor = true;
		BtAdicionaRegua.FlatStyle = FlatStyle.Flat;
		BtAdicionaRegua.ForeColor = SystemColors.Control;
		BtAdicionaRegua.Image = Resources.Adiciona_32;
		BtAdicionaRegua.Location = new Point(4, 71);
		BtAdicionaRegua.Name = "BtAdicionaRegua";
		BtAdicionaRegua.Size = new Size(40, 40);
		BtAdicionaRegua.TabIndex = 143;
		BtAdicionaRegua.UseVisualStyleBackColor = true;
		GroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		GroupBox2.Controls.Add(btApagaReguasSemBornes);
		GroupBox2.Controls.Add(TBAlternativo);
		GroupBox2.Controls.Add(lbAlternativo);
		GroupBox2.Controls.Add(tbRegua);
		GroupBox2.Controls.Add(BtApagaRegua);
		GroupBox2.Controls.Add(BtAdicionaRegua);
		GroupBox2.Controls.Add(BtEditaRegua);
		GroupBox2.Location = new Point(194, 237);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(186, 117);
		GroupBox2.TabIndex = 148;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "GroupBox2";
		btApagaReguasSemBornes.FlatStyle = FlatStyle.Flat;
		btApagaReguasSemBornes.ForeColor = SystemColors.Control;
		btApagaReguasSemBornes.Image = Resources.Apagador_32;
		btApagaReguasSemBornes.Location = new Point(142, 71);
		btApagaReguasSemBornes.Name = "btApagaReguasSemBornes";
		btApagaReguasSemBornes.Size = new Size(40, 40);
		btApagaReguasSemBornes.TabIndex = 149;
		btApagaReguasSemBornes.Tag = "";
		btApagaReguasSemBornes.UseVisualStyleBackColor = true;
		TBAlternativo.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBAlternativo.Location = new Point(91, 36);
		TBAlternativo.Name = "TBAlternativo";
		TBAlternativo.Size = new Size(87, 20);
		TBAlternativo.TabIndex = 147;
		lbAlternativo.Location = new Point(93, 16);
		lbAlternativo.Name = "lbAlternativo";
		lbAlternativo.Size = new Size(71, 17);
		lbAlternativo.TabIndex = 148;
		lbAlternativo.Text = "Alternativo";
		LbFiltro.BorderStyle = BorderStyle.Fixed3D;
		LbFiltro.Location = new Point(3, 30);
		LbFiltro.Name = "LbFiltro";
		LbFiltro.Size = new Size(81, 20);
		LbFiltro.TabIndex = 167;
		LbFiltro.Text = "Filtro";
		LbFiltro.TextAlign = ContentAlignment.MiddleCenter;
		TBPesquisa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TBPesquisa.CharacterCasing = CharacterCasing.Upper;
		TBPesquisa.Location = new Point(90, 30);
		TBPesquisa.Name = "TBPesquisa";
		TBPesquisa.Size = new Size(98, 20);
		TBPesquisa.TabIndex = 166;
		TBPesquisa.TextAlign = HorizontalAlignment.Center;
		btUsados.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btUsados.Location = new Point(156, 5);
		btUsados.Name = "btUsados";
		btUsados.Size = new Size(32, 19);
		btUsados.TabIndex = 169;
		btUsados.Text = "- - -";
		btUsados.UseVisualStyleBackColor = true;
		LabelQuantidade.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		LabelQuantidade.BorderStyle = BorderStyle.Fixed3D;
		LabelQuantidade.ImageAlign = ContentAlignment.MiddleLeft;
		LabelQuantidade.Location = new Point(3, 5);
		LabelQuantidade.Name = "LabelQuantidade";
		LabelQuantidade.Size = new Size(147, 19);
		LabelQuantidade.TabIndex = 168;
		LabelQuantidade.Text = "Label1";
		LabelQuantidade.TextAlign = ContentAlignment.MiddleCenter;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(384, 361);
		Controls.Add(btUsados);
		Controls.Add(LabelQuantidade);
		Controls.Add(LbFiltro);
		Controls.Add(TBPesquisa);
		Controls.Add(dgReguas);
		Controls.Add(dgPaineis);
		Controls.Add(GroupBox2);
		ImeMode = ImeMode.On;
		MinimumSize = new Size(340, 400);
		Name = "frmCriarReguas";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "meGerenciador de Reguas de Bornes";
		((ISupportInitialize)dgReguas).EndInit();
		((ISupportInitialize)dgPaineis).EndInit();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return kZkVlnIgcc;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		kZkVlnIgcc = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return FWeV0TMj5H;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		FWeV0TMj5H = WithEventsValue;
	}

	public frmCriarReguas()
	{
		Resize += xj1VKvRd5o;
		s8LVSyIQnT = false;
		mwoV4gD173 = 0;
		leoVCNec73 = "";
		fKfVYsxh1U = "";
		iISVrdDosS = 0;
		AFaV9embDX = "";
		if (Geral.ExisteForm("frmCriarReguas") || !clsAuxiliar.BancoValido())
		{
			return;
		}
		cDadosAccess.carregaDadosDWG();
		if (DeclaracoesGeral.arqAtivo.Indice != 0)
		{
			RkNVOxucqX();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1041]);
			lbAlternativo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1004]);
			GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 987]);
			LbFiltro.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 272]);
			lbAlternativo.Visible = false;
			TBAlternativo.Visible = false;
			w8dpBZ0kvSD().SetToolTip(BtAdicionaRegua, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1051]));
			w8dpBZ0kvSD().SetToolTip(BtEditaRegua, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1052]));
			w8dpBZ0kvSD().SetToolTip(BtApagaRegua, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1053]));
			w8dpBZ0kvSD().SetToolTip(btApagaReguasSemBornes, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1369]));
			OdEVibPPw3 = new Declaracoes2.StructureModeloDeReguas[1];
			DicionarioReguas.LeOsModelosDeRegua(ref OdEVibPPw3);
			DataGridView dg = dgPaineis;
			clsReguasDeBornes.carregaOsPaineisEmUsoNoDG(ref dg, OdEVibPPw3, 0, TBPesquisa.Text);
			dgPaineis = dg;
			dg = dgPaineis;
			OrdenaDG(ref dg);
			dgPaineis = dg;
			LabelQuantidade.Text = Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(dgPaineis.Rows.Count) + " ", DeclaracoesGeral.mMensagem[1, 1081]));
			if (checked(dgReguas.Rows.Count - 1) > 0)
			{
				dgReguas.Rows[0].Selected = true;
			}
			Application.ShowModelessDialog((Form)this);
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
			LabelQuantidade.Text = Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(dgPaineis.Rows.Count) + " ", DeclaracoesGeral.mMensagem[1, 1081]));
		}
		else
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 331]), MsgBoxStyle.Information);
		}
	}

	private void u0PVIYvsol(object P_0, KeyEventArgs P_1)
	{
		TextBox tbNome = tbRegua;
		clsTextos.NomeValido(ref tbNome);
		tbRegua = tbNome;
		DataGridView dg = dgReguas;
		ExisteNomeDaRegua(ref dg, bInicio: false);
		dgReguas = dg;
	}

	private void TAMV7JuRLs(object P_0, KeyEventArgs P_1)
	{
		TextBox tbNome = TBAlternativo;
		clsTextos.NomeValido(ref tbNome);
		TBAlternativo = tbNome;
		DataGridView dg = dgReguas;
		ExisteNomeDaRegua(ref dg, bInicio: false);
		dgReguas = dg;
	}

	public bool ExisteNomeDaRegua(ref DataGridView dg, bool bInicio)
	{
		bool flag = false;
		checked
		{
			try
			{
				tbRegua.BackColor = Color.White;
				tbRegua.ForeColor = Color.Black;
				TBAlternativo.BackColor = Color.White;
				TBAlternativo.ForeColor = Color.Black;
				w8dpBZ0kvSD().SetToolTip(tbRegua, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1114]));
				string text = "";
				string text2 = "";
				if (!bInicio)
				{
					int num = dg.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						text = Conversions.ToString(dg.Rows[i].Cells[1].Value);
						text2 = Conversions.ToString(dg.Rows[i].Cells[2].Value);
						if (Operators.CompareString(tbRegua.Text.ToString().ToUpper(), "", TextCompare: true) == 0)
						{
							flag = true;
							w8dpBZ0kvSD().SetToolTip(tbRegua, "");
						}
						if (Operators.CompareString(text.ToUpper(), tbRegua.Text.ToString().ToUpper(), TextCompare: true) == 0)
						{
							flag = true;
							tbRegua.BackColor = Color.LightCoral;
							w8dpBZ0kvSD().SetToolTip(tbRegua, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1115]));
						}
						if ((Operators.CompareString(TBAlternativo.Text, text2, TextCompare: true) == 0) & (Operators.CompareString(text2.Trim(), "", TextCompare: true) != 0))
						{
							flag = true;
							TBAlternativo.BackColor = Color.LightCoral;
							w8dpBZ0kvSD().SetToolTip(TBAlternativo, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1116]));
						}
					}
					BtEditaRegua.Enabled = false;
					BtApagaRegua.Enabled = false;
					BtAdicionaRegua.Enabled = true;
					if (flag)
					{
						BtAdicionaRegua.Enabled = false;
						BtEditaRegua.Enabled = false;
					}
					int num2 = dg.Rows.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						if (dg.Rows[j].Selected)
						{
							if (Operators.CompareString(tbRegua.Text, "", TextCompare: true) != 0)
							{
								BtEditaRegua.Enabled = true;
							}
							BtApagaRegua.Enabled = true;
							break;
						}
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			return flag;
		}
	}

	private void FAnVqqFS4X(object P_0, EventArgs P_1)
	{
		checked
		{
			try
			{
				DataGridView dg = dgReguas;
				bool flag = ExisteNomeDaRegua(ref dg, bInicio: false);
				dgReguas = dg;
				if (!flag)
				{
					bool flag2 = true;
					leoVCNec73 = tbRegua.Text;
					string right = "";
					int num = dgPaineis.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (dgPaineis.Rows[i].Selected)
						{
							iISVrdDosS = Conversions.ToInteger(dgPaineis.Rows[i].Cells[0].Value);
							right = Conversions.ToString(dgPaineis.Rows[i].Cells[1].Value);
							break;
						}
					}
					if (iISVrdDosS == 0 || Operators.CompareString(leoVCNec73.Trim(), "", TextCompare: true) == 0)
					{
						return;
					}
					OdEVibPPw3 = new Declaracoes2.StructureModeloDeReguas[1];
					DicionarioReguas.LeOsModelosDeRegua(ref OdEVibPPw3);
					if (flag2)
					{
						int num2 = Information.UBound(OdEVibPPw3) + 1;
						ref Declaracoes2.StructureModeloDeReguas[] odEVibPPw = ref OdEVibPPw3;
						odEVibPPw = (Declaracoes2.StructureModeloDeReguas[])Utils.CopyArray(odEVibPPw, new Declaracoes2.StructureModeloDeReguas[num2 + 1]);
						OdEVibPPw3[num2].indexRegua = OdEVibPPw3[0].iMaxIndice + 1;
						OdEVibPPw3[num2].nomeRegua = tbRegua.Text;
						OdEVibPPw3[num2].nomeAlternativo = TBAlternativo.Text;
						OdEVibPPw3[num2].indexPainel = iISVrdDosS;
						DicionarioReguas.GravaOsModelosDeRegua(OdEVibPPw3);
						dg = dgReguas;
						clsReguasDeBornes.carregaAsReguasDoPainelNoDG(ref dg, OdEVibPPw3, iISVrdDosS);
						dgReguas = dg;
					}
					int num3 = 0;
					DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
					dataGridViewCellStyle.BackColor = Color.Aquamarine;
					int num4 = dgPaineis.Rows.Count - 1;
					for (num3 = 0; num3 <= num4; num3++)
					{
						if (dgPaineis.Rows[num3].Selected)
						{
							dgPaineis[1, num3].Style = dataGridViewCellStyle;
							dgPaineis.Rows[num3].Cells[2].Value = 0;
							dgPaineis.Rows[num3].Selected = true;
							break;
						}
					}
					int num5 = dgReguas.Rows.Count - 1;
					for (int j = 0; j <= num5; j++)
					{
						dgReguas.Rows[j].Selected = false;
						if (Operators.ConditionalCompareObjectEqual(tbRegua.Text, dgReguas.Rows[j].Cells[1].Value, TextCompare: true))
						{
							dgReguas.Rows[j].Selected = true;
						}
					}
					dg = dgPaineis;
					OrdenaDG(ref dg);
					dgPaineis = dg;
					LabelQuantidade.Text = Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(dgPaineis.Rows.Count) + " ", DeclaracoesGeral.mMensagem[1, 1081]));
					int num6 = dgPaineis.Rows.Count - 1;
					for (int k = 0; k <= num6; k++)
					{
						if (Operators.ConditionalCompareObjectEqual(dgPaineis.Rows[k].Cells[1].Value, right, TextCompare: true))
						{
							dgPaineis.Rows[k].Selected = true;
							dgPaineis.FirstDisplayedScrollingRowIndex = k;
							break;
						}
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			BtAdicionaRegua.Enabled = true;
			tbRegua.Text = "";
		}
	}

	private void eE3VaP3EGs(object P_0, EventArgs P_1)
	{
		checked
		{
			try
			{
				if (s8LVSyIQnT || dgReguas.SelectedRows.Count == 0)
				{
					return;
				}
				bool flag = false;
				leoVCNec73 = tbRegua.Text;
				fKfVYsxh1U = TBAlternativo.Text;
				string right = "";
				int num = dgPaineis.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (dgPaineis.Rows[i].Selected)
					{
						iISVrdDosS = Conversions.ToInteger(dgPaineis.Rows[i].Cells[0].Value);
						right = Conversions.ToString(dgPaineis.Rows[i].Cells[1].Value);
						break;
					}
				}
				int num2 = dgReguas.Rows.Count - 1;
				int num3 = 0;
				int num5 = default;
				while (true)
				{
					if (num3 <= num2)
					{
						if (dgReguas.Rows[num3].Selected || !Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(dgReguas.Rows[num3].Cells[1].Value, leoVCNec73, TextCompare: true), Operators.CompareObjectEqual(dgReguas.Rows[num3].Cells[2].Value, fKfVYsxh1U, TextCompare: true)), Operators.CompareObjectEqual(dgReguas.Rows[num3].Cells[4].Value, dgPaineis.SelectedRows[0].Cells[1].Value, TextCompare: true))))
						{
							num3++;
							continue;
						}
						break;
					}
					if (iISVrdDosS == 0 || Operators.CompareString(leoVCNec73.Trim(), "", TextCompare: true) == 0)
					{
						break;
					}
					OdEVibPPw3 = new Declaracoes2.StructureModeloDeReguas[1];
					DicionarioReguas.LeOsModelosDeRegua(ref OdEVibPPw3);
					int num4 = Information.UBound(OdEVibPPw3);
					for (int j = 1; j <= num4; j++)
					{
						if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(OdEVibPPw3[j].indexPainel == iISVrdDosS, Operators.CompareObjectEqual(OdEVibPPw3[j].nomeRegua, dgReguas.SelectedRows[0].Cells[1].Value, TextCompare: true)), Operators.CompareObjectEqual(OdEVibPPw3[j].nomeAlternativo, dgReguas.SelectedRows[0].Cells[2].Value, TextCompare: true))))
						{
							flag = true;
							num5 = j;
							break;
						}
					}
					DataGridView dg;
					if (flag)
					{
						OdEVibPPw3[num5].nomeRegua = tbRegua.Text;
						OdEVibPPw3[num5].nomeAlternativo = TBAlternativo.Text;
						DicionarioReguas.GravaOsModelosDeRegua(OdEVibPPw3);
						dg = dgReguas;
						clsReguasDeBornes.carregaAsReguasDoPainelNoDG(ref dg, OdEVibPPw3, iISVrdDosS);
						dgReguas = dg;
						dgReguas.MultiSelect = true;
						int num6 = dgReguas.Rows.Count - 1;
						for (int k = 0; k <= num6; k++)
						{
							dgReguas.Rows[k].Selected = false;
							if (Operators.ConditionalCompareObjectEqual(tbRegua.Text, dgReguas.Rows[k].Cells[1].Value, TextCompare: true))
							{
								dgReguas.Rows[k].Selected = true;
							}
						}
						clsBornes.EditarOsBornesDasReguasSelecionada(OdEVibPPw3, num5);
					}
					jX3VQOX3vd();
					dg = dgPaineis;
					OrdenaDG(ref dg);
					dgPaineis = dg;
					LabelQuantidade.Text = Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(dgPaineis.Rows.Count) + " ", DeclaracoesGeral.mMensagem[1, 1081]));
					int num7 = dgPaineis.Rows.Count - 1;
					for (int l = 0; l <= num7; l++)
					{
						if (Operators.ConditionalCompareObjectEqual(dgPaineis.Rows[l].Cells[1].Value, right, TextCompare: true))
						{
							dgPaineis.Rows[l].Selected = true;
							break;
						}
					}
					break;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			clsUtilitarios.CorrigePainelET1DosBornes();
		}
	}

	private void KJdV8rnoZm(object P_0, EventArgs P_1)
	{
		Declaracoes2.StructureModeloDeReguas[] array = new Declaracoes2.StructureModeloDeReguas[1];
		OdEVibPPw3 = new Declaracoes2.StructureModeloDeReguas[1];
		int indexRegua = 0;
		MsgBoxResult msgBoxResult = Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1138], leoVCNec73), DeclaracoesGeral.mMensagem[1, 1139]), MsgBoxStyle.YesNo, "Eletron");
		if (msgBoxResult == MsgBoxResult.No)
		{
			return;
		}
		string right = "";
		checked
		{
			int num = dgPaineis.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgPaineis.Rows[i].Selected)
				{
					iISVrdDosS = Conversions.ToInteger(dgPaineis.SelectedRows[0].Cells[0].Value);
					right = Conversions.ToString(dgPaineis.SelectedRows[0].Cells[1].Value);
					break;
				}
			}
			DicionarioReguas.LeOsModelosDeRegua(ref OdEVibPPw3);
			bool flag = true;
			int num2 = Information.UBound(OdEVibPPw3);
			for (int j = 1; j <= num2; j++)
			{
				flag = true;
				int num3 = dgReguas.Rows.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					if (dgReguas.Rows[k].Selected && Operators.ConditionalCompareObjectEqual(OdEVibPPw3[j].indexRegua, dgReguas.Rows[k].Cells[0].Value, TextCompare: true))
					{
						flag = false;
						indexRegua = Conversions.ToInteger(dgReguas.Rows[k].Cells[0].Value);
						break;
					}
				}
				if (flag)
				{
					int num4 = Information.UBound(array) + 1;
					array = (Declaracoes2.StructureModeloDeReguas[])Utils.CopyArray(array, new Declaracoes2.StructureModeloDeReguas[num4 + 1]);
					array[0].iMaxIndice = OdEVibPPw3[0].iMaxIndice;
					array[num4] = OdEVibPPw3[j];
				}
			}
			DicionarioReguas.GravaOsModelosDeRegua(array);
			clsBornes.ApagaOsBornesDasReguasExcluidas(array);
			DeclaracoesEntidades.StructureBorne[] array2 = null;
			array2 = new DeclaracoesEntidades.StructureBorne[1];
			DicionarioBorne.gravaDicBornesReserva(indexRegua, ref array2);
			DicionarioReguas.LeOsModelosDeRegua(ref OdEVibPPw3);
			DataGridView dg = dgPaineis;
			clsReguasDeBornes.carregaOsPaineisEmUsoNoDG(ref dg, OdEVibPPw3, 0, TBPesquisa.Text);
			dgPaineis = dg;
			if (dgReguas.Rows.Count - 1 > 0)
			{
				dgReguas.Rows[0].Selected = true;
			}
			jX3VQOX3vd();
			int num5 = dgPaineis.Rows.Count - 1;
			for (int l = 0; l <= num5; l++)
			{
				if (Operators.ConditionalCompareObjectEqual(dgPaineis.Rows[l].Cells[1].Value, right, TextCompare: true))
				{
					dgPaineis.Rows[l].Selected = true;
					break;
				}
			}
			dg = dgPaineis;
			OrdenaDG(ref dg);
			dgPaineis = dg;
			LabelQuantidade.Text = Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(dgPaineis.Rows.Count) + " ", DeclaracoesGeral.mMensagem[1, 1081]));
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		}
	}

	public static void OrdenaDG(ref DataGridView dg)
	{
		if (dg.RowCount <= 0)
		{
			return;
		}
		DataGridViewColumn dataGridViewColumn = dg.Columns[2];
		dg.Sort(dataGridViewColumn, ListSortDirection.Ascending);
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		dataGridViewCellStyle.BackColor = Color.LightCoral;
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		dataGridViewCellStyle2.BackColor = Color.White;
		checked
		{
			int num = dg.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (!Operators.ConditionalCompareObjectEqual(dg.Rows[i].Cells[2].Value, 0, TextCompare: true))
				{
					dg[1, i].Style = dataGridViewCellStyle2;
				}
				else
				{
					dg[1, i].Style = dataGridViewCellStyle;
				}
			}
		}
	}

	private void HAiVN3wseM(object P_0, MouseEventArgs P_1)
	{
		jX3VQOX3vd();
	}

	private void hfdVFnv92w(object P_0, DataGridViewCellEventArgs P_1)
	{
		jX3VQOX3vd();
	}

	private void jX3VQOX3vd()
	{
		checked
		{
			try
			{
				int num = 0;
				int num2 = dgReguas.Rows.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					if (dgReguas.Rows[i].Selected)
					{
						num++;
					}
				}
				if (dgReguas.Rows.Count != 0)
				{
					BtAdicionaRegua.Enabled = false;
					BtApagaRegua.Enabled = true;
					BtEditaRegua.Enabled = true;
					s8LVSyIQnT = false;
					if (num <= 1)
					{
						if (dgReguas.Rows.Count > 0)
						{
							int num3 = dgReguas.Rows.Count - 1;
							for (int j = 0; j <= num3; j++)
							{
								if (dgReguas.Rows[j].Selected)
								{
									mwoV4gD173 = Conversions.ToInteger(dgReguas.Rows[j].Cells[0].Value);
									leoVCNec73 = Conversions.ToString(dgReguas.Rows[j].Cells[1].Value);
									fKfVYsxh1U = Conversions.ToString(dgReguas.Rows[j].Cells[2].Value);
									iISVrdDosS = Conversions.ToInteger(dgReguas.Rows[j].Cells[3].Value);
									AFaV9embDX = Conversions.ToString(dgReguas.Rows[j].Cells[4].Value);
									tbRegua.Text = leoVCNec73;
									TBAlternativo.Text = fKfVYsxh1U;
								}
							}
						}
					}
					else
					{
						s8LVSyIQnT = true;
						tbRegua.Text = "";
						mwoV4gD173 = 0;
						leoVCNec73 = "";
						fKfVYsxh1U = "";
						AFaV9embDX = "";
						iISVrdDosS = 0;
					}
					DataGridView dg = dgReguas;
					ExisteNomeDaRegua(ref dg, bInicio: true);
					dgReguas = dg;
				}
				else
				{
					BtAdicionaRegua.Enabled = true;
					BtApagaRegua.Enabled = false;
					BtEditaRegua.Enabled = false;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void BSwVPaZyBx(object P_0, EventArgs P_1)
	{
		CarregaReguas();
		BtAdicionaRegua.Enabled = false;
		BtApagaRegua.Enabled = false;
		BtEditaRegua.Enabled = false;
		if (dgReguas.RowCount > 0)
		{
			DataGridView dg = dgReguas;
			ExisteNomeDaRegua(ref dg, bInicio: true);
			dgReguas = dg;
		}
		tbRegua.Text = "";
		TBAlternativo.Text = "";
	}

	public void CarregaReguas()
	{
		if (dgPaineis.RowCount <= 0)
		{
			return;
		}
		checked
		{
			int num = dgPaineis.Rows.Count - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					if (dgPaineis.Rows[num2].Selected)
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			iISVrdDosS = Conversions.ToInteger(dgPaineis.Rows[num2].Cells[0].Value);
			DataGridViewCell dataGridViewCell = dgPaineis.Rows[num2].Cells[2];
			DataGridView dg = dgReguas;
			int num3 = clsReguasDeBornes.carregaAsReguasDoPainelNoDG(ref dg, OdEVibPPw3, iISVrdDosS);
			dgReguas = dg;
			dataGridViewCell.Value = num3;
		}
	}

	private void oELVcWFRWn(object P_0, KeyEventArgs P_1)
	{
		if ((P_1.KeyValue == 13) | (Operators.CompareString(TBPesquisa.Text, "", TextCompare: true) == 0))
		{
			DataGridView dg = dgPaineis;
			clsReguasDeBornes.carregaOsPaineisEmUsoNoDG(ref dg, OdEVibPPw3, 0, TBPesquisa.Text);
			dgPaineis = dg;
			dg = dgPaineis;
			OrdenaDG(ref dg);
			dgPaineis = dg;
			LabelQuantidade.Text = Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(dgPaineis.Rows.Count) + " ", DeclaracoesGeral.mMensagem[1, 1081]));
		}
	}

	private void xj1VKvRd5o(object P_0, EventArgs P_1)
	{
		checked
		{
			if (dgPaineis.ColumnCount > 0)
			{
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgPaineis)) ? ((double)(dgPaineis.Width - 4)) : ((double)(dgPaineis.Width - 21)));
				dgPaineis.Columns[1].Width = (int)Math.Round(a);
				if (dgReguas.Rows.Count - 1 > 0)
				{
					a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgReguas)) ? ((double)(dgReguas.Width - 4)) : ((double)(dgReguas.Width - 21)));
					dgReguas.Columns[1].Width = (int)Math.Round(a);
				}
			}
		}
	}

	private void KaoVex4TUC(object P_0, EventArgs P_1)
	{
		DataGridView dg = dgPaineis;
		clsReguasDeBornes.carregaOsPaineisEmUsoNoDG(ref dg, OdEVibPPw3, 0, TBPesquisa.Text);
		dgPaineis = dg;
		dg = dgPaineis;
		OrdenaDG(ref dg);
		dgPaineis = dg;
		LabelQuantidade.Text = Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(dgPaineis.Rows.Count) + " ", DeclaracoesGeral.mMensagem[1, 1081]));
	}

	private void zTkV2VZvrK(object P_0, EventArgs P_1)
	{
		MsgBoxResult msgBoxResult = Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1369], "\r\n"), DeclaracoesGeral.mMensagem[1, 1283]), MsgBoxStyle.YesNo);
		if (msgBoxResult == MsgBoxResult.No)
		{
			return;
		}
		Declaracoes2.StructureModeloDeReguas[] mModelo = new Declaracoes2.StructureModeloDeReguas[1];
		OdEVibPPw3 = new Declaracoes2.StructureModeloDeReguas[1];
		DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
		DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mModelo);
		DeclaracoesGeral._uscPagina.pbIniciar();
		List<string> lReguasUsadas = new List<string>();
		clsReguasDeBornes.EncontraReguasUsadasNoCaderno(ref lReguasUsadas);
		int num = Information.UBound(mModelo);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				if (lReguasUsadas.Contains(Conversions.ToString(mModelo[i].indexPainel) + "," + Conversions.ToString(mModelo[i].indexRegua)))
				{
					int num2 = Information.UBound(OdEVibPPw3) + 1;
					ref Declaracoes2.StructureModeloDeReguas[] odEVibPPw = ref OdEVibPPw3;
					odEVibPPw = (Declaracoes2.StructureModeloDeReguas[])Utils.CopyArray(odEVibPPw, new Declaracoes2.StructureModeloDeReguas[num2 + 1]);
					OdEVibPPw3[num2] = mModelo[i];
				}
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			DeclaracoesGeral._uscPagina.pbFim();
			DicionarioReguas.GravaOsModelosDeRegua(OdEVibPPw3);
			DataGridView dg = dgPaineis;
			clsReguasDeBornes.carregaOsPaineisEmUsoNoDG(ref dg, OdEVibPPw3, 0, TBPesquisa.Text);
			dgPaineis = dg;
			dg = dgPaineis;
			OrdenaDG(ref dg);
			dgPaineis = dg;
			if (dgPaineis.Rows.Count > 0)
			{
				dgPaineis.Rows[0].Selected = true;
			}
		}
	}

	private void RqXV3XKY1E(object P_0, EventArgs P_1)
	{
		tbRegua.Text = tbRegua.Text.Trim();
	}

	private void X3vVnRQj53(object P_0, EventArgs P_1)
	{
		TBAlternativo.Text = TBAlternativo.Text.Trim();
	}
}
