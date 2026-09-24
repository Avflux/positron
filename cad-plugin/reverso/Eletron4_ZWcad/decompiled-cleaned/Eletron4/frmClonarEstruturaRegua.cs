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
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

[DesignerGenerated]
public class frmClonarEstruturaRegua : Form
{
	public struct StructureReguaOriginal
	{
		public int IOrdem;

		public string SBorne;

		public int ITipo;

		public int ILM;

		public string SOrientacao;

		public string SLayout;
	}

	private IContainer t3HoJTExxB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("FolderBrowser")]
	private FolderBrowserDialog DwXohSByyy;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip yAxooQ0IDK;

	[AccessedThroughProperty("DGReguasOrigem")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView fnBoGJawC4;

	[AccessedThroughProperty("LabelCadernoOrigem")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label D2woH8tSAt;

	[AccessedThroughProperty("LabelCadernoDestino")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label GOYoky8KhU;

	[AccessedThroughProperty("DGReguasDestino")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView zLuodr73xi;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LbFiltro2")]
	private Label Kp2of2xQqC;

	[AccessedThroughProperty("TBPesquisaDestino")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox h8JoDuy9QX;

	[AccessedThroughProperty("LbFiltro")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label jtXovfQqux;

	[AccessedThroughProperty("TBPesquisaOrigem")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox b0xo6JVjFw;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("BTColar")]
	private Button w7potZr6fw;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTAtualizarOrigem")]
	[CompilerGenerated]
	private Button bxJojsARap;

	[AccessedThroughProperty("BTAtualizarDestino")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button yFSoLLny3I;

	[AccessedThroughProperty("LabelCadernoDestino0")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label Xx2ownLRmi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelCadernoOrigem0")]
	[CompilerGenerated]
	private Label TF4ox6Ux7b;

	public StructureReguaOriginal[] MReguaSelecionadaOrigem;

	public Declaracoes2.StructureModeloDeReguas[] MModeloDeReguasOrigem;

	public StructureReguaOriginal[] MReguasDestino;

	public Declaracoes2.StructureModeloDeReguas[] MModeloDeReguasDestino;

	public DeclaracoesEntidades.StructureBorne[] MBornesOrigem;

	public DeclaracoesEntidades.StructureBorne[] MBornesDestino;

	public int IDWGO;

	public int IDWGD;

	internal virtual DataGridView DGReguasOrigem
	{
		[CompilerGenerated]
		get
		{
			return fnBoGJawC4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = h0Qop1Jcy3;
			DataGridView dataGridView = fnBoGJawC4;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			fnBoGJawC4 = value;
			dataGridView = fnBoGJawC4;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual Label LabelCadernoOrigem
	{
		[CompilerGenerated]
		get
		{
			return D2woH8tSAt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			D2woH8tSAt = value;
		}
	}

	internal virtual Label LabelCadernoDestino
	{
		[CompilerGenerated]
		get
		{
			return GOYoky8KhU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			GOYoky8KhU = value;
		}
	}

	internal virtual DataGridView DGReguasDestino
	{
		[CompilerGenerated]
		get
		{
			return zLuodr73xi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zLuodr73xi = value;
		}
	}

	internal virtual Label LbFiltro2
	{
		[CompilerGenerated]
		get
		{
			return Kp2of2xQqC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Kp2of2xQqC = value;
		}
	}

	internal virtual TextBox TBPesquisaDestino
	{
		[CompilerGenerated]
		get
		{
			return h8JoDuy9QX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = epAhCbJUFw;
			TextBox textBox = h8JoDuy9QX;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			h8JoDuy9QX = value;
			textBox = h8JoDuy9QX;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Label LbFiltro
	{
		[CompilerGenerated]
		get
		{
			return jtXovfQqux;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jtXovfQqux = value;
		}
	}

	internal virtual TextBox TBPesquisaOrigem
	{
		[CompilerGenerated]
		get
		{
			return b0xo6JVjFw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = w17h4JxRYx;
			TextBox textBox = b0xo6JVjFw;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			b0xo6JVjFw = value;
			textBox = b0xo6JVjFw;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Button BTColar
	{
		[CompilerGenerated]
		get
		{
			return w7potZr6fw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = eumoWqLEfh;
			Button button = w7potZr6fw;
			if (button != null)
			{
				button.Click -= value2;
			}
			w7potZr6fw = value;
			button = w7potZr6fw;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTAtualizarOrigem
	{
		[CompilerGenerated]
		get
		{
			return bxJojsARap;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AbmhYiQybR;
			Button button = bxJojsARap;
			if (button != null)
			{
				button.Click -= value2;
			}
			bxJojsARap = value;
			button = bxJojsARap;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTAtualizarDestino
	{
		[CompilerGenerated]
		get
		{
			return yFSoLLny3I;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = gpshrxtWdh;
			Button button = yFSoLLny3I;
			if (button != null)
			{
				button.Click -= value2;
			}
			yFSoLLny3I = value;
			button = yFSoLLny3I;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label LabelCadernoDestino0
	{
		[CompilerGenerated]
		get
		{
			return Xx2ownLRmi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Xx2ownLRmi = value;
		}
	}

	internal virtual Label LabelCadernoOrigem0
	{
		[CompilerGenerated]
		get
		{
			return TF4ox6Ux7b;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TF4ox6Ux7b = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && t3HoJTExxB != null)
			{
				t3HoJTExxB.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void LachSd2Y89()
	{
		t3HoJTExxB = new Container();
		aHypBEW66iS(new FolderBrowserDialog());
		FDqpBiUmZij(new ToolTip(t3HoJTExxB));
		DGReguasOrigem = new DataGridView();
		LabelCadernoOrigem = new Label();
		LabelCadernoDestino = new Label();
		DGReguasDestino = new DataGridView();
		LbFiltro2 = new Label();
		TBPesquisaDestino = new TextBox();
		LbFiltro = new Label();
		TBPesquisaOrigem = new TextBox();
		BTColar = new Button();
		BTAtualizarOrigem = new Button();
		BTAtualizarDestino = new Button();
		LabelCadernoDestino0 = new Label();
		LabelCadernoOrigem0 = new Label();
		((ISupportInitialize)DGReguasOrigem).BeginInit();
		((ISupportInitialize)DGReguasDestino).BeginInit();
		SuspendLayout();
		DGReguasOrigem.AllowDrop = true;
		DGReguasOrigem.AllowUserToAddRows = false;
		DGReguasOrigem.AllowUserToDeleteRows = false;
		DGReguasOrigem.AllowUserToResizeRows = false;
		DGReguasOrigem.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		DGReguasOrigem.BackgroundColor = Color.White;
		DGReguasOrigem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGReguasOrigem.Location = new Point(12, 83);
		DGReguasOrigem.MultiSelect = false;
		DGReguasOrigem.Name = "DGReguasOrigem";
		DGReguasOrigem.RowHeadersVisible = false;
		DGReguasOrigem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGReguasOrigem.Size = new Size(202, 316);
		DGReguasOrigem.TabIndex = 179;
		LabelCadernoOrigem.BorderStyle = BorderStyle.Fixed3D;
		LabelCadernoOrigem.ImageAlign = ContentAlignment.MiddleLeft;
		LabelCadernoOrigem.Location = new Point(12, 23);
		LabelCadernoOrigem.Name = "LabelCadernoOrigem";
		LabelCadernoOrigem.Size = new Size(161, 24);
		LabelCadernoOrigem.TabIndex = 180;
		LabelCadernoOrigem.Text = "LabelPainel";
		LabelCadernoOrigem.TextAlign = ContentAlignment.MiddleCenter;
		LabelCadernoDestino.BorderStyle = BorderStyle.Fixed3D;
		LabelCadernoDestino.ImageAlign = ContentAlignment.MiddleLeft;
		LabelCadernoDestino.Location = new Point(230, 22);
		LabelCadernoDestino.Name = "LabelCadernoDestino";
		LabelCadernoDestino.Size = new Size(161, 25);
		LabelCadernoDestino.TabIndex = 182;
		LabelCadernoDestino.Text = "lbBornesReserva";
		LabelCadernoDestino.TextAlign = ContentAlignment.MiddleCenter;
		DGReguasDestino.AllowDrop = true;
		DGReguasDestino.AllowUserToAddRows = false;
		DGReguasDestino.AllowUserToDeleteRows = false;
		DGReguasDestino.AllowUserToResizeRows = false;
		DGReguasDestino.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		DGReguasDestino.BackgroundColor = Color.White;
		DGReguasDestino.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGReguasDestino.Location = new Point(230, 83);
		DGReguasDestino.Name = "DGReguasDestino";
		DGReguasDestino.RowHeadersVisible = false;
		DGReguasDestino.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGReguasDestino.Size = new Size(202, 262);
		DGReguasDestino.TabIndex = 181;
		LbFiltro2.BorderStyle = BorderStyle.Fixed3D;
		LbFiltro2.Location = new Point(230, 54);
		LbFiltro2.Name = "LbFiltro2";
		LbFiltro2.Size = new Size(60, 20);
		LbFiltro2.TabIndex = 186;
		LbFiltro2.Text = "Filtro";
		LbFiltro2.TextAlign = ContentAlignment.MiddleCenter;
		TBPesquisaDestino.CharacterCasing = CharacterCasing.Upper;
		TBPesquisaDestino.Location = new Point(296, 54);
		TBPesquisaDestino.Name = "TBPesquisaDestino";
		TBPesquisaDestino.Size = new Size(95, 20);
		TBPesquisaDestino.TabIndex = 185;
		TBPesquisaDestino.TextAlign = HorizontalAlignment.Center;
		LbFiltro.BorderStyle = BorderStyle.Fixed3D;
		LbFiltro.Location = new Point(12, 53);
		LbFiltro.Name = "LbFiltro";
		LbFiltro.Size = new Size(60, 20);
		LbFiltro.TabIndex = 188;
		LbFiltro.Text = "lbFiltro";
		LbFiltro.TextAlign = ContentAlignment.MiddleCenter;
		TBPesquisaOrigem.CharacterCasing = CharacterCasing.Upper;
		TBPesquisaOrigem.Location = new Point(78, 53);
		TBPesquisaOrigem.Name = "TBPesquisaOrigem";
		TBPesquisaOrigem.Size = new Size(95, 20);
		TBPesquisaOrigem.TabIndex = 187;
		TBPesquisaOrigem.TextAlign = HorizontalAlignment.Center;
		BTColar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BTColar.FlatStyle = FlatStyle.Flat;
		BTColar.ForeColor = SystemColors.Control;
		BTColar.Image = Resources.Paste_32;
		BTColar.Location = new Point(310, 359);
		BTColar.Name = "BTColar";
		BTColar.Size = new Size(40, 40);
		BTColar.TabIndex = 190;
		BTColar.UseVisualStyleBackColor = true;
		BTAtualizarOrigem.FlatStyle = FlatStyle.Flat;
		BTAtualizarOrigem.ForeColor = SystemColors.Control;
		BTAtualizarOrigem.Image = Resources.Update_32;
		BTAtualizarOrigem.Location = new Point(178, 31);
		BTAtualizarOrigem.Name = "BTAtualizarOrigem";
		BTAtualizarOrigem.Size = new Size(36, 36);
		BTAtualizarOrigem.TabIndex = 191;
		BTAtualizarOrigem.UseVisualStyleBackColor = true;
		BTAtualizarDestino.FlatStyle = FlatStyle.Flat;
		BTAtualizarDestino.ForeColor = SystemColors.Control;
		BTAtualizarDestino.Image = Resources.Update_32;
		BTAtualizarDestino.Location = new Point(397, 31);
		BTAtualizarDestino.Name = "BTAtualizarDestino";
		BTAtualizarDestino.Size = new Size(36, 36);
		BTAtualizarDestino.TabIndex = 192;
		BTAtualizarDestino.UseVisualStyleBackColor = true;
		LabelCadernoDestino0.ImageAlign = ContentAlignment.MiddleLeft;
		LabelCadernoDestino0.Location = new Point(230, 1);
		LabelCadernoDestino0.Name = "LabelCadernoDestino0";
		LabelCadernoDestino0.Size = new Size(161, 20);
		LabelCadernoDestino0.TabIndex = 194;
		LabelCadernoDestino0.Text = "lbBornesReserva";
		LabelCadernoDestino0.TextAlign = ContentAlignment.MiddleCenter;
		LabelCadernoOrigem0.ImageAlign = ContentAlignment.MiddleLeft;
		LabelCadernoOrigem0.Location = new Point(12, 2);
		LabelCadernoOrigem0.Name = "LabelCadernoOrigem0";
		LabelCadernoOrigem0.Size = new Size(161, 19);
		LabelCadernoOrigem0.TabIndex = 193;
		LabelCadernoOrigem0.Text = "LabelPainel";
		LabelCadernoOrigem0.TextAlign = ContentAlignment.MiddleCenter;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(442, 411);
		Controls.Add(LabelCadernoDestino0);
		Controls.Add(LabelCadernoOrigem0);
		Controls.Add(BTAtualizarDestino);
		Controls.Add(BTAtualizarOrigem);
		Controls.Add(BTColar);
		Controls.Add(LbFiltro);
		Controls.Add(TBPesquisaOrigem);
		Controls.Add(LbFiltro2);
		Controls.Add(TBPesquisaDestino);
		Controls.Add(LabelCadernoDestino);
		Controls.Add(DGReguasDestino);
		Controls.Add(LabelCadernoOrigem);
		Controls.Add(DGReguasOrigem);
		MaximizeBox = false;
		MaximumSize = new Size(458, 800);
		MinimizeBox = false;
		MinimumSize = new Size(458, 450);
		Name = "frmClonarEstruturaRegua";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Editor de Bornes";
		((ISupportInitialize)DGReguasOrigem).EndInit();
		((ISupportInitialize)DGReguasDestino).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return DwXohSByyy;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		DwXohSByyy = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return yAxooQ0IDK;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		yAxooQ0IDK = WithEventsValue;
	}

	public frmClonarEstruturaRegua()
	{
		Resize += zaaoTsCQKG;
		MReguaSelecionadaOrigem = null;
		MModeloDeReguasOrigem = null;
		MReguasDestino = null;
		MModeloDeReguasDestino = null;
		MBornesOrigem = null;
		MBornesDestino = null;
		IDWGO = 0;
		IDWGD = 0;
		if (Geral.ExisteForm("frmClonarEstruturaRegua") || !clsAuxiliar.BancoValido())
		{
			return;
		}
		cDadosAccess.carregaDadosDWG();
		if (DeclaracoesGeral.arqAtivo.Indice != 0)
		{
			LachSd2Y89();
			MReguaSelecionadaOrigem = new StructureReguaOriginal[1];
			MModeloDeReguasOrigem = new Declaracoes2.StructureModeloDeReguas[1];
			MReguasDestino = new StructureReguaOriginal[1];
			MModeloDeReguasDestino = new Declaracoes2.StructureModeloDeReguas[1];
			zmqhz6InDq(ref MBornesOrigem, ref MModeloDeReguasOrigem, _0020: false);
			zmqhz6InDq(ref MBornesDestino, ref MModeloDeReguasDestino, _0020: true);
			DicionarioReguas.LeOsModelosDeRegua(ref MModeloDeReguasOrigem);
			int IPainel = 0;
			int IRegua = 0;
			DataGridView dg = DGReguasOrigem;
			CarregaPaineiseReguasNoDGClonar(ref dg, MModeloDeReguasOrigem, MBornesOrigem, TBPesquisaOrigem.Text.ToString(), IDWGO, IDWGD, ref IPainel, ref IRegua);
			DGReguasOrigem = dg;
			dg = DGReguasOrigem;
			AtualizaDgPaineisReguas(ref dg);
			DGReguasOrigem = dg;
			MModeloDeReguasDestino = MModeloDeReguasOrigem;
			dg = DGReguasDestino;
			CarregaPaineiseReguasNoDGClonar(ref dg, MModeloDeReguasDestino, MBornesDestino, TBPesquisaOrigem.Text.ToString(), IDWGO, IDWGD, ref IPainel, ref IRegua);
			DGReguasDestino = dg;
			dg = DGReguasDestino;
			AtualizaDgPaineisReguas(ref dg);
			DGReguasDestino = dg;
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1588]);
			LbFiltro.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 272]);
			LbFiltro2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 272]);
			cDadosAccess.carregaDadosDWG();
			IDWGO = DeclaracoesGeral.arqAtivo.Indice;
			IDWGD = DeclaracoesGeral.arqAtivo.Indice;
			LabelCadernoOrigem.Text = DeclaracoesGeral.arqAtivo.Nome;
			LabelCadernoDestino.Text = DeclaracoesGeral.arqAtivo.Nome;
			LabelCadernoOrigem0.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 429]);
			LabelCadernoDestino0.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 432]);
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

	public static void CarregaPaineiseReguasNoDGClonar(ref DataGridView dg, Declaracoes2.StructureModeloDeReguas[] mMODELO, DeclaracoesEntidades.StructureBorne[] mBornesTodos, string sPesquisa, int iDWGO, int IDWGC, ref int IPainel, ref int IRegua)
	{
		checked
		{
			try
			{
				dg.Rows.Clear();
				dg.Columns.Clear();
				if (mMODELO == null || Information.UBound(mMODELO) <= 0)
				{
					return;
				}
				dg.Columns.Add("IndicePainel", "#");
				dg.Columns.Add("Painel", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1081]));
				dg.Columns.Add("indiceRegua", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1081]));
				dg.Columns.Add("Regua", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1043]));
				dg.ColumnHeadersVisible = true;
				int num = Information.UBound(mMODELO);
				for (int i = 1; i <= num; i++)
				{
					string text = "";
					string text2 = "";
					int num2 = Information.UBound(mBornesTodos);
					for (int j = 1; j <= num2; j++)
					{
						if (mBornesTodos[j].IndiceRegua == mMODELO[i].indexRegua)
						{
							text = mBornesTodos[j].NomeRegua;
							text2 = mBornesTodos[j].NomePainel;
						}
					}
					if (!(LikeOperator.LikeString(text2.ToString().ToUpper(), "*" + sPesquisa.ToUpper() + "*", CompareMethod.Text) | LikeOperator.LikeString(text.ToUpper(), "*" + sPesquisa.ToUpper() + "*", CompareMethod.Text)) || !((Operators.CompareString(text.Trim(), "", TextCompare: true) != 0) | (Operators.CompareString(text2.Trim(), "", TextCompare: true) != 0)))
					{
						continue;
					}
					bool flag = true;
					if (iDWGO == IDWGC && ((IPainel == mMODELO[i].indexPainel) & (IRegua == mMODELO[i].indexRegua)))
					{
						flag = false;
					}
					if (flag)
					{
						dg.Rows.Add(mMODELO[i].indexPainel, text2, mMODELO[i].indexRegua, text);
						if (IPainel == 0)
						{
							IPainel = mMODELO[i].indexPainel;
							IRegua = mMODELO[i].indexRegua;
						}
					}
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

	public void AtualizaDgPaineisReguas(ref DataGridView dg)
	{
		checked
		{
			if (dg.RowCount <= 0)
			{
				dg.Rows.Clear();
				dg.Columns.Clear();
			}
			else if (dg.RowCount != 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
				dg.Columns[0].Width = 0;
				dg.Columns[1].Width = (int)Math.Round(num * 0.5);
				dg.Columns[2].Width = 0;
				dg.Columns[3].Width = (int)Math.Round(num * 0.5);
				dg.Columns[0].Visible = false;
				dg.Columns[1].Visible = true;
				dg.Columns[2].Visible = false;
				dg.Columns[3].Visible = true;
				dg.Columns[0].ReadOnly = true;
				dg.Columns[1].ReadOnly = true;
				dg.Columns[2].ReadOnly = true;
				dg.Columns[3].ReadOnly = true;
			}
		}
	}

	private void w17h4JxRYx(object P_0, KeyEventArgs P_1)
	{
		if ((P_1.KeyValue == 13) | (Operators.CompareString(TBPesquisaOrigem.Text, "", TextCompare: true) == 0))
		{
			TBPesquisaOrigem.Enabled = false;
			int IPainel = 0;
			int IRegua = 0;
			DataGridView dg = DGReguasOrigem;
			CarregaPaineiseReguasNoDGClonar(ref dg, MModeloDeReguasOrigem, MBornesOrigem, TBPesquisaOrigem.Text.ToString(), IDWGO, IDWGD, ref IPainel, ref IRegua);
			DGReguasOrigem = dg;
			dg = DGReguasOrigem;
			AtualizaDgPaineisReguas(ref dg);
			DGReguasOrigem = dg;
			TBPesquisaOrigem.Enabled = true;
			TBPesquisaOrigem.Focus();
		}
	}

	private void epAhCbJUFw(object P_0, KeyEventArgs P_1)
	{
		if (((P_1.KeyValue == 13) | (Operators.CompareString(TBPesquisaDestino.Text, "", TextCompare: true) == 0)) && ((P_1.KeyValue == 13) | (Operators.CompareString(TBPesquisaDestino.Text, "", TextCompare: true) == 0)))
		{
			TBPesquisaDestino.Enabled = false;
			int IPainel = 0;
			int IRegua = 0;
			DataGridView dg = DGReguasDestino;
			CarregaPaineiseReguasNoDGClonar(ref dg, MModeloDeReguasDestino, MBornesDestino, TBPesquisaDestino.Text.ToString(), IDWGO, IDWGD, ref IPainel, ref IRegua);
			DGReguasDestino = dg;
			dg = DGReguasDestino;
			AtualizaDgPaineisReguas(ref dg);
			DGReguasDestino = dg;
			TBPesquisaDestino.Enabled = true;
			TBPesquisaDestino.Focus();
		}
	}

	private void AbmhYiQybR(object P_0, EventArgs P_1)
	{
		if (clsAuxiliar.BancoValido())
		{
			cDadosAccess.carregaDadosDWG();
			if (DeclaracoesGeral.arqAtivo.Indice != 0)
			{
				LabelCadernoOrigem.Text = DeclaracoesGeral.arqAtivo.Nome;
				LabelCadernoDestino.Text = DeclaracoesGeral.arqAtivo.Nome;
				MReguaSelecionadaOrigem = new StructureReguaOriginal[1];
				MModeloDeReguasOrigem = new Declaracoes2.StructureModeloDeReguas[1];
				MReguasDestino = new StructureReguaOriginal[1];
				MModeloDeReguasDestino = new Declaracoes2.StructureModeloDeReguas[1];
				zmqhz6InDq(ref MBornesOrigem, ref MModeloDeReguasOrigem, _0020: false);
				zmqhz6InDq(ref MBornesDestino, ref MModeloDeReguasDestino, _0020: true);
				int IPainel = 0;
				int IRegua = 0;
				DataGridView dg = DGReguasOrigem;
				CarregaPaineiseReguasNoDGClonar(ref dg, MModeloDeReguasOrigem, MBornesOrigem, TBPesquisaOrigem.Text.ToString(), IDWGO, IDWGD, ref IPainel, ref IRegua);
				DGReguasOrigem = dg;
				dg = DGReguasOrigem;
				AtualizaDgPaineisReguas(ref dg);
				DGReguasOrigem = dg;
				dg = DGReguasDestino;
				CarregaPaineiseReguasNoDGClonar(ref dg, MModeloDeReguasDestino, MBornesDestino, TBPesquisaDestino.Text.ToString(), IDWGO, IDWGD, ref IPainel, ref IRegua);
				DGReguasDestino = dg;
				dg = DGReguasDestino;
				AtualizaDgPaineisReguas(ref dg);
				DGReguasDestino = dg;
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 331]), MsgBoxStyle.Information);
			}
		}
	}

	private void gpshrxtWdh(object P_0, EventArgs P_1)
	{
		wSNh9grVUx();
	}

	private void wSNh9grVUx()
	{
		if (!clsAuxiliar.BancoValido())
		{
			return;
		}
		cDadosAccess.carregaDadosDWG();
		if (DeclaracoesGeral.arqAtivo.Indice != 0)
		{
			cDadosAccess.carregaDadosDWG();
			IDWGD = DeclaracoesGeral.arqAtivo.Indice;
			LabelCadernoDestino.Text = DeclaracoesGeral.arqAtivo.Nome;
			MReguasDestino = new StructureReguaOriginal[1];
			MModeloDeReguasDestino = new Declaracoes2.StructureModeloDeReguas[1];
			zmqhz6InDq(ref MBornesDestino, ref MModeloDeReguasDestino, _0020: true);
			int IPainel = 0;
			if (DGReguasOrigem.SelectedRows.Count > 0)
			{
				IPainel = Conversions.ToInteger(DGReguasOrigem.SelectedRows[0].Cells[0].Value);
			}
			int IRegua = 0;
			if (DGReguasOrigem.SelectedRows.Count > 0)
			{
				IRegua = Conversions.ToInteger(DGReguasOrigem.SelectedRows[0].Cells[2].Value);
			}
			DataGridView dg = DGReguasDestino;
			CarregaPaineiseReguasNoDGClonar(ref dg, MModeloDeReguasDestino, MBornesDestino, TBPesquisaDestino.Text.ToString(), IDWGO, IDWGD, ref IPainel, ref IRegua);
			DGReguasDestino = dg;
			dg = DGReguasDestino;
			AtualizaDgPaineisReguas(ref dg);
			DGReguasDestino = dg;
		}
		else
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 331]), MsgBoxStyle.Information);
		}
	}

	private static void zmqhz6InDq(ref DeclaracoesEntidades.StructureBorne[] P_0, ref Declaracoes2.StructureModeloDeReguas[] P_1, bool P_2)
	{
		P_0 = new DeclaracoesEntidades.StructureBorne[1];
		P_1 = new Declaracoes2.StructureModeloDeReguas[1];
		DicionarioReguas.LeOsModelosDeRegua(ref P_1);
		clsBornes.capturaTodosOsBornesDoDesenho(-1, ref P_0);
		DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(P_1);
		DeclaracoesGeral._uscPagina.pbIniciar();
		int num = 0;
		int num2 = Information.UBound(P_1);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				int indexRegua = P_1[i].indexRegua;
				int qSimples = 0;
				int qDuplo = 0;
				DicionarioBorne.LeDicBornesReserva(indexRegua, ref P_0, ref qSimples, ref qDuplo);
				num++;
				if (num == 100)
				{
					DeclaracoesGeral._uscPagina.pbPasso(num);
					num = 0;
				}
			}
			DeclaracoesGeral._uscPagina.pbFim();
			List<int> list = new List<int>();
			int num3 = Information.UBound(P_1);
			for (int j = 1; j <= num3; j++)
			{
				bool flag = true;
				int num4 = Information.UBound(P_0);
				for (int k = 1; k <= num4; k++)
				{
					if (P_0[k].IndiceRegua == P_1[j].indexRegua)
					{
						P_0[k].indexPainel = P_1[j].indexPainel;
						P_0[k].NomeRegua = P_1[j].nomeRegua;
						P_0[k].NomePainel = Dicionario.BuscaNomeDoPainel(P_1[j].indexPainel);
						flag = false;
					}
				}
				if (P_2 && flag)
				{
					list.Add(P_1[j].indexRegua);
				}
			}
			if (list.Count != 0)
			{
				foreach (int item in list)
				{
					int num5 = Information.UBound(P_1);
					for (int l = 1; l <= num5; l++)
					{
						if (item == P_1[l].indexRegua)
						{
							P_0 = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(P_0, new DeclaracoesEntidades.StructureBorne[Information.UBound(P_0) + 1 + 1]);
							P_0[Information.UBound(P_0)].IndiceRegua = item;
							P_0[Information.UBound(P_0)].NomeRegua = P_1[l].nomeRegua;
							P_0[Information.UBound(P_0)].indexPainel = P_1[l].indexPainel;
							P_0[Information.UBound(P_0)].NomePainel = Dicionario.BuscaNomeDoPainel(P_1[l].indexPainel);
						}
					}
				}
			}
			if (Information.UBound(P_0) < 1)
			{
				return;
			}
			int num6 = Information.UBound(P_0) - 2;
			for (int m = 0; m <= num6; m++)
			{
				int num7 = Information.UBound(P_0) - 2;
				for (int n = num7; n >= 0; n += -1)
				{
					if (P_0[n].IndiceRegua > P_0[n + 1].IndiceRegua)
					{
						DeclaracoesEntidades.StructureBorne structureBorne = P_0[n];
						P_0[n] = P_0[n + 1];
						P_0[n + 1] = structureBorne;
					}
					if (P_0[n].IndiceRegua == P_0[n + 1].IndiceRegua && P_0[n].Ordem > P_0[n + 1].Ordem)
					{
						DeclaracoesEntidades.StructureBorne structureBorne2 = P_0[n];
						P_0[n] = P_0[n + 1];
						P_0[n + 1] = structureBorne2;
					}
				}
			}
		}
	}

	private void eumoWqLEfh(object P_0, EventArgs P_1)
	{
		cDadosAccess.carregaDadosDWG();
		IDWGD = DeclaracoesGeral.arqAtivo.Indice;
		checked
		{
			if (Operators.CompareString(LabelCadernoOrigem.Text, LabelCadernoDestino.Text, TextCompare: true) != 0 || IDWGO == IDWGD)
			{
				DeclaracoesGeral._uscPagina.Quantidade = DGReguasDestino.Rows.Count - 1;
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num = DGReguasDestino.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (DGReguasDestino.Rows[i].Selected)
					{
						bool flag = false;
						int num2 = Conversions.ToInteger(DGReguasDestino.Rows[i].Cells[2].Value);
						string nomeRegua = Conversions.ToString(DGReguasDestino.Rows[i].Cells[3].Value);
						int indexPainel = Conversions.ToInteger(DGReguasDestino.Rows[i].Cells[0].Value);
						Conversions.ToString(DGReguasDestino.Rows[i].Cells[1].Value);
						DeclaracoesEntidades.StructureBorne[] mBornes = new DeclaracoesEntidades.StructureBorne[1];
						DeclaracoesEntidades.StructureBorne[] array = new DeclaracoesEntidades.StructureBorne[1];
						int num3 = Information.UBound(MBornesDestino);
						for (int j = 0; j <= num3; j++)
						{
							if (MBornesDestino[j].IndiceRegua == num2 && !Information.IsNothing(MBornesDestino[j].Numero))
							{
								int num4 = Information.UBound(array) + 1;
								array = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(array, new DeclaracoesEntidades.StructureBorne[num4 + 1]);
								array[num4] = MBornesDestino[j];
								array[num4].Ordem = MBornesDestino[j].Ordem + 50000.0;
							}
						}
						List<string> list = new List<string>();
						int num5 = Information.UBound(MReguaSelecionadaOrigem);
						for (int k = 0; k <= num5; k++)
						{
							bool flag2 = true;
							int num6 = Information.UBound(array);
							for (int l = 0; l <= num6; l++)
							{
								if (Operators.CompareString(array[l].conector, "#ADD#", TextCompare: true) != 0 && Operators.CompareString(array[l].Numero, MReguaSelecionadaOrigem[k].SBorne, TextCompare: true) == 0)
								{
									array[l].Ordem = MReguaSelecionadaOrigem[k].IOrdem;
									array[l].conector = "#ADD#";
									flag2 = false;
									break;
								}
							}
							if (flag2 & !flag)
							{
								list.Add(Conversions.ToString(k));
							}
						}
						if (list.Count != 0)
						{
							foreach (string item in list)
							{
								int num7 = Information.UBound(array) + 1;
								array = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(array, new DeclaracoesEntidades.StructureBorne[num7 + 1]);
								array[num7].Ordem = MReguaSelecionadaOrigem[Conversions.ToInteger(item)].IOrdem;
								array[num7].IndiceRegua = num2;
								array[num7].lm = MReguaSelecionadaOrigem[Conversions.ToInteger(item)].ILM;
								array[num7].tipo = MReguaSelecionadaOrigem[Conversions.ToInteger(item)].ITipo;
								array[num7].Numero = MReguaSelecionadaOrigem[Conversions.ToInteger(item)].SBorne;
								array[num7].indexPainel = indexPainel;
								array[num7].NomeRegua = nomeRegua;
								array[num7].Handle = "";
								array[num7].conector = "";
								array[num7].Orientacao = MReguaSelecionadaOrigem[Conversions.ToInteger(item)].SOrientacao;
								array[num7].BlocoLayout = MReguaSelecionadaOrigem[Conversions.ToInteger(item)].SLayout;
							}
						}
						if (Information.UBound(array) >= 1)
						{
							int num8 = Information.UBound(array) - 1;
							for (int m = 0; m <= num8; m++)
							{
								int num9 = Information.UBound(array) - 1;
								for (int n = num9; n >= 0; n += -1)
								{
									if (array[n].Ordem > array[n + 1].Ordem)
									{
										DeclaracoesEntidades.StructureBorne structureBorne = array[n];
										array[n] = array[n + 1];
										array[n + 1] = structureBorne;
									}
								}
							}
							int num10 = Information.UBound(array);
							for (int num11 = 0; num11 <= num10; num11++)
							{
								array[num11].Ordem = num11;
							}
						}
						int num12 = Information.UBound(array);
						for (int num13 = 1; num13 <= num12; num13++)
						{
							if (Operators.CompareString(array[num13].Handle, "", TextCompare: true) != 0)
							{
								clsBornes.MudaOrdemDeUmBorne(array[num13].Handle, (int)Math.Round(array[num13].Ordem));
								continue;
							}
							int num14 = Information.UBound(mBornes) + 1;
							mBornes = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(mBornes, new DeclaracoesEntidades.StructureBorne[num14 + 1]);
							mBornes[num14] = array[num13];
						}
						DicionarioBorne.gravaDicBornesReserva(num2, ref mBornes);
					}
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 483]), MsgBoxStyle.Exclamation);
				DeclaracoesGeral._uscPagina.pbFim();
			}
			else
			{
				MsgBoxResult msgBoxResult = Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1592], "\r\n"), DeclaracoesGeral.mMensagem[1, 1593]), MsgBoxStyle.YesNo, "Elétron");
				if (msgBoxResult == MsgBoxResult.Yes)
				{
					wSNh9grVUx();
				}
			}
		}
	}

	private void h0Qop1Jcy3(object P_0, EventArgs P_1)
	{
		int num = 0;
		MReguaSelecionadaOrigem = new StructureReguaOriginal[1];
		checked
		{
			if (DGReguasOrigem.SelectedRows.Count > 0)
			{
				int num2 = Conversions.ToInteger(DGReguasOrigem.SelectedRows[0].Cells[2].Value);
				if (Information.UBound(MBornesOrigem) > 0)
				{
					int num3 = Information.UBound(MBornesOrigem);
					for (int i = 1; i <= num3; i++)
					{
						if (num2 == MBornesOrigem[i].IndiceRegua)
						{
							num++;
							ref StructureReguaOriginal[] mReguaSelecionadaOrigem = ref MReguaSelecionadaOrigem;
							mReguaSelecionadaOrigem = (StructureReguaOriginal[])Utils.CopyArray(mReguaSelecionadaOrigem, new StructureReguaOriginal[num + 1]);
							MReguaSelecionadaOrigem[num].IOrdem = (int)Math.Round(MBornesOrigem[i].Ordem);
							MReguaSelecionadaOrigem[num].SBorne = MBornesOrigem[i].Numero;
							MReguaSelecionadaOrigem[num].ITipo = MBornesOrigem[i].tipo;
							MReguaSelecionadaOrigem[num].ILM = MBornesOrigem[i].lm;
							MReguaSelecionadaOrigem[num].SOrientacao = MBornesOrigem[i].Orientacao;
							MReguaSelecionadaOrigem[num].SLayout = MBornesOrigem[i].BlocoLayout;
						}
					}
				}
				if (num - 1 >= 1)
				{
					int num4 = num - 2;
					for (int j = 0; j <= num4; j++)
					{
						int num5 = num - 2;
						for (int k = num5; k >= 0; k += -1)
						{
							if (MReguaSelecionadaOrigem[k].IOrdem > MReguaSelecionadaOrigem[k + 1].IOrdem)
							{
								StructureReguaOriginal structureReguaOriginal = MReguaSelecionadaOrigem[k];
								MReguaSelecionadaOrigem[k] = MReguaSelecionadaOrigem[k + 1];
								MReguaSelecionadaOrigem[k + 1] = structureReguaOriginal;
							}
						}
					}
				}
			}
			if (num != 0)
			{
				BTColar.Enabled = true;
			}
			else
			{
				BTColar.Enabled = false;
			}
			DataGridView dg;
			if (IDWGO == IDWGD)
			{
				int IPainel = 0;
				if (DGReguasOrigem.SelectedRows.Count > 0)
				{
					IPainel = Conversions.ToInteger(DGReguasOrigem.SelectedRows[0].Cells[0].Value);
				}
				int IRegua = 0;
				if (DGReguasOrigem.SelectedRows.Count > 0)
				{
					IRegua = Conversions.ToInteger(DGReguasOrigem.SelectedRows[0].Cells[2].Value);
				}
				dg = DGReguasDestino;
				CarregaPaineiseReguasNoDGClonar(ref dg, MModeloDeReguasDestino, MBornesDestino, TBPesquisaDestino.Text.ToString(), IDWGO, IDWGD, ref IPainel, ref IRegua);
				DGReguasDestino = dg;
				dg = DGReguasDestino;
				AtualizaDgPaineisReguas(ref dg);
				DGReguasDestino = dg;
			}
			dg = DGReguasOrigem;
			AtualizaDgPaineisReguas(ref dg);
			DGReguasOrigem = dg;
		}
	}

	private void zaaoTsCQKG(object P_0, EventArgs P_1)
	{
		DataGridView dg = DGReguasOrigem;
		AtualizaDgPaineisReguas(ref dg);
		DGReguasOrigem = dg;
		dg = DGReguasDestino;
		AtualizaDgPaineisReguas(ref dg);
		DGReguasDestino = dg;
	}
}
