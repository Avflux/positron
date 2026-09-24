using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
public class frmEditaBornesSelecao : Form
{
	private IContainer b02ZK2pFfH;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("FolderBrowser")]
	private FolderBrowserDialog jlQZe3WY9E;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	[CompilerGenerated]
	private ToolTip chSZ2vuObq;

	[AccessedThroughProperty("btSelecionarBornes")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button arKZ3k6FfO;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btSalvar")]
	private Button NFUZnORyia;

	[CompilerGenerated]
	[AccessedThroughProperty("dgBornesSel")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView GReZ1Sjsso;

	[AccessedThroughProperty("LabelPainel")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label d8yZlwVTRQ;

	[AccessedThroughProperty("lbBornesReserva")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label aPHZ5OMKxy;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("dgBornesReserva")]
	private DataGridView YIrZ07ZWjE;

	[AccessedThroughProperty("btLigarBornes")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button AQPZRHm9lg;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btOcultarBornes")]
	[CompilerGenerated]
	private Button YkGZm491PV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox hAAZXUPmRn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbOrdemXY")]
	private RadioButton exMZUQv4JS;

	[AccessedThroughProperty("rbOrdemSelecao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton n6oZyr7jcA;

	[AccessedThroughProperty("rbOrdemYX")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton nLvZgbnfs7;

	private int X22ZADxny7;

	private DeclaracoesEntidades.StructureBorne[] eVAZsF3BCQ;

	private Declaracoes2.StructureModeloDeReguas[] mwKZBkw0rh;

	private DeclaracoesEntidades.StructureBorne[] sGcZVvXwda;

	private DeclaracoesEntidades.StructureBorne[] mgyZuL1h46;

	private double C9EZEDiUJ3;

	private DeclaracoesEntidades.StructureBorne[] fTTZZORBk3;

	private int hXOZiZhxlX;

	private int zDvZSWGb9U;

	internal virtual Button btSelecionarBornes
	{
		[CompilerGenerated]
		get
		{
			return arKZ3k6FfO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = E9sZIjGO65;
			Button button = arKZ3k6FfO;
			if (button != null)
			{
				button.Click -= value2;
			}
			arKZ3k6FfO = value;
			button = arKZ3k6FfO;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btSalvar
	{
		[CompilerGenerated]
		get
		{
			return NFUZnORyia;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = JgWZ73HjFn;
			Button button = NFUZnORyia;
			if (button != null)
			{
				button.Click -= value2;
			}
			NFUZnORyia = value;
			button = NFUZnORyia;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgBornesSel
	{
		[CompilerGenerated]
		get
		{
			return GReZ1Sjsso;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = AphZMCLbqh;
			DragEventHandler value3 = i36ZFC60kf;
			DragEventHandler value4 = MdBZQbY4Mf;
			DataGridView dataGridView = GReZ1Sjsso;
			if (dataGridView != null)
			{
				dataGridView.CellEndEdit -= value2;
				dataGridView.DragDrop -= value3;
				dataGridView.DragEnter -= value4;
			}
			GReZ1Sjsso = value;
			dataGridView = GReZ1Sjsso;
			if (dataGridView != null)
			{
				dataGridView.CellEndEdit += value2;
				dataGridView.DragDrop += value3;
				dataGridView.DragEnter += value4;
			}
		}
	}

	internal virtual Label LabelPainel
	{
		[CompilerGenerated]
		get
		{
			return d8yZlwVTRQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			d8yZlwVTRQ = value;
		}
	}

	internal virtual Label lbBornesReserva
	{
		[CompilerGenerated]
		get
		{
			return aPHZ5OMKxy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			aPHZ5OMKxy = value;
		}
	}

	internal virtual DataGridView dgBornesReserva
	{
		[CompilerGenerated]
		get
		{
			return YIrZ07ZWjE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = gZiZNj7omX;
			DataGridView dataGridView = YIrZ07ZWjE;
			if (dataGridView != null)
			{
				dataGridView.MouseDown -= value2;
			}
			YIrZ07ZWjE = value;
			dataGridView = YIrZ07ZWjE;
			if (dataGridView != null)
			{
				dataGridView.MouseDown += value2;
			}
		}
	}

	internal virtual Button btLigarBornes
	{
		[CompilerGenerated]
		get
		{
			return AQPZRHm9lg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = G39ZaSe7A2;
			Button button = AQPZRHm9lg;
			if (button != null)
			{
				button.Click -= value2;
			}
			AQPZRHm9lg = value;
			button = AQPZRHm9lg;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btOcultarBornes
	{
		[CompilerGenerated]
		get
		{
			return YkGZm491PV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = m9uZqQrLHB;
			Button button = YkGZm491PV;
			if (button != null)
			{
				button.Click -= value2;
			}
			YkGZm491PV = value;
			button = YkGZm491PV;
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
			return hAAZXUPmRn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			hAAZXUPmRn = value;
		}
	}

	internal virtual RadioButton rbOrdemXY
	{
		[CompilerGenerated]
		get
		{
			return exMZUQv4JS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = cr3ZPSqGS1;
			RadioButton radioButton = exMZUQv4JS;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			exMZUQv4JS = value;
			radioButton = exMZUQv4JS;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton rbOrdemSelecao
	{
		[CompilerGenerated]
		get
		{
			return n6oZyr7jcA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = htvZcYgpKa;
			RadioButton radioButton = n6oZyr7jcA;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			n6oZyr7jcA = value;
			radioButton = n6oZyr7jcA;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton rbOrdemYX
	{
		[CompilerGenerated]
		get
		{
			return nLvZgbnfs7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			nLvZgbnfs7 = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && b02ZK2pFfH != null)
			{
				b02ZK2pFfH.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void c5kZbZjrPs()
	{
		b02ZK2pFfH = new Container();
		aHypBEW66iS(new FolderBrowserDialog());
		FDqpBiUmZij(new ToolTip(b02ZK2pFfH));
		btSelecionarBornes = new Button();
		btSalvar = new Button();
		dgBornesSel = new DataGridView();
		LabelPainel = new Label();
		lbBornesReserva = new Label();
		dgBornesReserva = new DataGridView();
		btLigarBornes = new Button();
		btOcultarBornes = new Button();
		GroupBox1 = new GroupBox();
		rbOrdemYX = new RadioButton();
		rbOrdemXY = new RadioButton();
		rbOrdemSelecao = new RadioButton();
		((ISupportInitialize)dgBornesSel).BeginInit();
		((ISupportInitialize)dgBornesReserva).BeginInit();
		GroupBox1.SuspendLayout();
		SuspendLayout();
		btSelecionarBornes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btSelecionarBornes.FlatStyle = FlatStyle.Flat;
		btSelecionarBornes.ForeColor = SystemColors.Control;
		btSelecionarBornes.Image = Resources.Select_32;
		btSelecionarBornes.Location = new Point(201, 452);
		btSelecionarBornes.Name = "btSelecionarBornes";
		btSelecionarBornes.Size = new Size(40, 40);
		btSelecionarBornes.TabIndex = 153;
		btSelecionarBornes.UseVisualStyleBackColor = true;
		btSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btSalvar.Enabled = false;
		btSalvar.FlatStyle = FlatStyle.Flat;
		btSalvar.ForeColor = SystemColors.Control;
		btSalvar.Image = Resources.Salvar_32;
		btSalvar.Location = new Point(249, 452);
		btSalvar.Name = "btSalvar";
		btSalvar.Size = new Size(40, 40);
		btSalvar.TabIndex = 178;
		btSalvar.UseVisualStyleBackColor = true;
		dgBornesSel.AllowDrop = true;
		dgBornesSel.AllowUserToAddRows = false;
		dgBornesSel.AllowUserToDeleteRows = false;
		dgBornesSel.AllowUserToResizeRows = false;
		dgBornesSel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgBornesSel.BackgroundColor = Color.White;
		dgBornesSel.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgBornesSel.Location = new Point(12, 29);
		dgBornesSel.MultiSelect = false;
		dgBornesSel.Name = "dgBornesSel";
		dgBornesSel.RowHeadersVisible = false;
		dgBornesSel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgBornesSel.Size = new Size(149, 324);
		dgBornesSel.TabIndex = 179;
		LabelPainel.BorderStyle = BorderStyle.Fixed3D;
		LabelPainel.ImageAlign = ContentAlignment.MiddleLeft;
		LabelPainel.Location = new Point(12, 9);
		LabelPainel.Name = "LabelPainel";
		LabelPainel.Size = new Size(149, 17);
		LabelPainel.TabIndex = 180;
		LabelPainel.Text = "LabelPainel";
		LabelPainel.TextAlign = ContentAlignment.MiddleCenter;
		lbBornesReserva.BorderStyle = BorderStyle.Fixed3D;
		lbBornesReserva.ImageAlign = ContentAlignment.MiddleLeft;
		lbBornesReserva.Location = new Point(167, 9);
		lbBornesReserva.Name = "lbBornesReserva";
		lbBornesReserva.Size = new Size(149, 17);
		lbBornesReserva.TabIndex = 182;
		lbBornesReserva.Text = "lbBornesReserva";
		lbBornesReserva.TextAlign = ContentAlignment.MiddleCenter;
		dgBornesReserva.AllowDrop = true;
		dgBornesReserva.AllowUserToAddRows = false;
		dgBornesReserva.AllowUserToDeleteRows = false;
		dgBornesReserva.AllowUserToResizeRows = false;
		dgBornesReserva.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgBornesReserva.BackgroundColor = Color.White;
		dgBornesReserva.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgBornesReserva.Location = new Point(167, 29);
		dgBornesReserva.MultiSelect = false;
		dgBornesReserva.Name = "dgBornesReserva";
		dgBornesReserva.RowHeadersVisible = false;
		dgBornesReserva.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgBornesReserva.Size = new Size(149, 324);
		dgBornesReserva.TabIndex = 181;
		btLigarBornes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btLigarBornes.FlatStyle = FlatStyle.Flat;
		btLigarBornes.ForeColor = SystemColors.Control;
		btLigarBornes.Image = Resources.Liga_32;
		btLigarBornes.Location = new Point(86, 452);
		btLigarBornes.Name = "btLigarBornes";
		btLigarBornes.Size = new Size(40, 40);
		btLigarBornes.TabIndex = 184;
		btLigarBornes.UseVisualStyleBackColor = true;
		btOcultarBornes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btOcultarBornes.FlatStyle = FlatStyle.Flat;
		btOcultarBornes.ForeColor = SystemColors.Control;
		btOcultarBornes.Image = Resources.Desliga_32;
		btOcultarBornes.Location = new Point(38, 452);
		btOcultarBornes.Name = "btOcultarBornes";
		btOcultarBornes.Size = new Size(40, 40);
		btOcultarBornes.TabIndex = 183;
		btOcultarBornes.UseVisualStyleBackColor = true;
		GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox1.Controls.Add(rbOrdemYX);
		GroupBox1.Controls.Add(rbOrdemXY);
		GroupBox1.Controls.Add(rbOrdemSelecao);
		GroupBox1.Location = new Point(12, 359);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(304, 87);
		GroupBox1.TabIndex = 185;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "Ordem";
		rbOrdemYX.AutoSize = true;
		rbOrdemYX.Location = new Point(10, 42);
		rbOrdemYX.Name = "rbOrdemYX";
		rbOrdemYX.Size = new Size(79, 17);
		rbOrdemYX.TabIndex = 3;
		rbOrdemYX.Text = "rbOrdemYX";
		rbOrdemYX.UseVisualStyleBackColor = true;
		rbOrdemXY.AutoSize = true;
		rbOrdemXY.Location = new Point(10, 22);
		rbOrdemXY.Name = "rbOrdemXY";
		rbOrdemXY.Size = new Size(79, 17);
		rbOrdemXY.TabIndex = 0;
		rbOrdemXY.Text = "rbOrdemXY";
		rbOrdemXY.UseVisualStyleBackColor = true;
		rbOrdemSelecao.AutoSize = true;
		rbOrdemSelecao.Location = new Point(10, 62);
		rbOrdemSelecao.Name = "rbOrdemSelecao";
		rbOrdemSelecao.Size = new Size(104, 17);
		rbOrdemSelecao.TabIndex = 2;
		rbOrdemSelecao.Text = "rbOrdemSelecao";
		rbOrdemSelecao.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(324, 500);
		Controls.Add(GroupBox1);
		Controls.Add(btLigarBornes);
		Controls.Add(btOcultarBornes);
		Controls.Add(lbBornesReserva);
		Controls.Add(dgBornesReserva);
		Controls.Add(LabelPainel);
		Controls.Add(dgBornesSel);
		Controls.Add(btSelecionarBornes);
		Controls.Add(btSalvar);
		MaximizeBox = false;
		MaximumSize = new Size(340, 1400);
		MinimizeBox = false;
		MinimumSize = new Size(340, 400);
		Name = "frmEditaBornesSelecao";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Editor de Bornes";
		((ISupportInitialize)dgBornesSel).EndInit();
		((ISupportInitialize)dgBornesReserva).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return jlQZe3WY9E;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		jlQZe3WY9E = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return chSZ2vuObq;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		chSZ2vuObq = WithEventsValue;
	}

	public frmEditaBornesSelecao()
	{
		Resize += ivJZ8y1Lvq;
		X22ZADxny7 = 0;
		eVAZsF3BCQ = null;
		sGcZVvXwda = null;
		mgyZuL1h46 = null;
		C9EZEDiUJ3 = 0.0;
		fTTZZORBk3 = null;
		hXOZiZhxlX = 0;
		zDvZSWGb9U = 0;
		if (Geral.ExisteForm("frmEditaBornesSelecao") || !clsAuxiliar.BancoValido())
		{
			return;
		}
		cDadosAccess.carregaDadosDWG();
		if (DeclaracoesGeral.arqAtivo.Indice != 0)
		{
			c5kZbZjrPs();
			LabelPainel.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1081], " / "), DeclaracoesGeral.mMensagem[1, 984]));
			lbBornesReserva.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1384]);
			mwKZBkw0rh = new Declaracoes2.StructureModeloDeReguas[1];
			DicionarioReguas.LeOsModelosDeRegua(ref mwKZBkw0rh);
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1147]);
			w8dpBZ0kvSD().SetToolTip(btSelecionarBornes, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1345]));
			w8dpBZ0kvSD().SetToolTip(btSalvar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1089]));
			w8dpBZ0kvSD().SetToolTip(btOcultarBornes, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1503]));
			w8dpBZ0kvSD().SetToolTip(btLigarBornes, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1504]));
			GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1603]);
			rbOrdemXY.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1599]);
			rbOrdemYX.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1600]);
			rbOrdemSelecao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1347]);
			btSalvar.Enabled = false;
			rbOrdemXY.Checked = true;
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

	private void AphZMCLbqh(object P_0, DataGridViewCellEventArgs P_1)
	{
		clsTextos.TiraNothing(Conversions.ToString(dgBornesSel.Rows[P_1.RowIndex].Cells[P_1.ColumnIndex].Value)).Trim();
		bool flag = false;
		double num = 0.0;
		checked
		{
			int num2 = dgBornesSel.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				dgBornesSel.Rows[i].Cells[1].Style.BackColor = Color.White;
				dgBornesSel.Rows[i].Cells[1].Style.ForeColor = Color.Black;
			}
			int num3 = dgBornesSel.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				if (Operators.CompareString(dgBornesSel.Rows[j].Cells[1].Value.ToString(), "?", TextCompare: true) == 0)
				{
					dgBornesSel.Rows[j].Cells[1].Value = "0";
				}
			}
			int num4 = dgBornesSel.Rows.Count - 1;
			for (int k = 0; k <= num4; k++)
			{
				Conversions.ToString(dgBornesSel.Rows[k].Cells[1].Value);
				int num5 = k + 1;
				int num6 = dgBornesSel.Rows.Count - 1;
				for (int l = num5; l <= num6; l++)
				{
					if ((Operators.CompareString(dgBornesSel.Rows[k].Cells[1].Value.ToString(), dgBornesSel.Rows[l].Cells[1].Value.ToString(), TextCompare: true) == 0) & (Operators.CompareString(dgBornesSel.Rows[k].Cells[1].Value.ToString(), "0", TextCompare: true) != 0))
					{
						dgBornesSel.Rows[l].Cells[1].Style.BackColor = Color.LightCoral;
						dgBornesSel.Rows[l].Cells[1].Style.ForeColor = Color.Black;
						flag = true;
					}
				}
			}
			int num7 = dgBornesSel.Rows.Count - 1;
			for (int m = 0; m <= num7; m++)
			{
				int num8 = Information.UBound(eVAZsF3BCQ);
				for (int n = 0; n <= num8; n++)
				{
					if (Operators.ConditionalCompareObjectEqual(dgBornesSel.Rows[P_1.RowIndex].Cells[1].Value, eVAZsF3BCQ[n].Numero, TextCompare: true))
					{
						num = eVAZsF3BCQ[n].Ordem;
					}
					if (Operators.ConditionalCompareObjectEqual(dgBornesSel.Rows[m].Cells[1].Value, eVAZsF3BCQ[n].Numero, TextCompare: true))
					{
						if (!Operators.ConditionalCompareObjectEqual(eVAZsF3BCQ[n].pagina, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
						{
							dgBornesSel.Rows[m].Cells[1].Style.BackColor = Color.LightCoral;
							dgBornesSel.Rows[m].Cells[1].Style.ForeColor = Color.Black;
							flag = true;
						}
						else
						{
							dgBornesSel.Rows[m].Cells[1].Style.BackColor = Color.White;
							dgBornesSel.Rows[m].Cells[1].Style.ForeColor = Color.Black;
							dgBornesSel.Rows[m].Cells[7].Value = eVAZsF3BCQ[n].tipo;
							dgBornesSel.Rows[m].Cells[8].Value = eVAZsF3BCQ[n].lm;
						}
					}
				}
				if (Strings.Len(dgBornesSel.Rows[m].Cells[1].Value.ToString()) > 10)
				{
					dgBornesSel.Rows[m].Cells[1].Style.BackColor = Color.LightCoral;
					dgBornesSel.Rows[m].Cells[1].Style.ForeColor = Color.Black;
					flag = true;
				}
			}
			string right = Conversions.ToString(dgBornesSel.SelectedRows[0].Cells[1].Value);
			int num9 = dgBornesReserva.Rows.Count - 1;
			for (int num10 = 0; num10 <= num9; num10++)
			{
				if (Operators.ConditionalCompareObjectEqual(dgBornesReserva.Rows[num10].Cells[1].Value, right, TextCompare: true))
				{
					dgBornesReserva.Rows.RemoveAt(num10);
					break;
				}
			}
			DataGridView dg = dgBornesReserva;
			AtualizaColunasDGBornes(ref dg);
			dgBornesReserva = dg;
			dgBornesSel.Rows[P_1.RowIndex].Cells[6].Value = num;
			if (flag)
			{
				btSalvar.Enabled = false;
			}
			else
			{
				btSalvar.Enabled = true;
			}
		}
	}

	public static void carregaOsBornesSelecionadosNoDG(ref DataGridView dg, clsBornes.ordemBornes[] mBornes, List<string> sHandleBornes)
	{
		checked
		{
			try
			{
				dg.Rows.Clear();
				dg.Columns.Clear();
				if (mBornes == null || Information.UBound(mBornes) == 0)
				{
					return;
				}
				formataDgBornes(ref dg);
				dg.ColumnHeadersVisible = true;
				if (Information.UBound(mBornes) > 0)
				{
					int num = Information.UBound(mBornes);
					for (int i = 1; i <= num; i++)
					{
						dg.Rows.Add(mBornes[i].indexRegua, mBornes[i].Nome, mBornes[i].Alternativo, mBornes[i].sHandle, mBornes[i].dX, mBornes[i].dY, mBornes[i].Ordem, mBornes[i].Tipo, mBornes[i].Lm, mBornes[i].iOrdemSelecao, mBornes[i].Nome, mBornes[i].Layout, mBornes[i].Orientacao);
						sHandleBornes.Add(mBornes[i].sHandle);
					}
				}
				int num2 = dg.Rows.Count - 1;
				int num3 = 0;
				while (true)
				{
					if (num3 <= num2)
					{
						if (!dg.Rows[num3].Selected)
						{
							break;
						}
						num3++;
						continue;
					}
					return;
				}
				dg.FirstDisplayedScrollingRowIndex = num3;
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

	private static void dNNZOmrKcv(ref DataGridView P_0, bool P_1, bool P_2, bool P_3)
	{
		checked
		{
			if (P_1 && P_0.Rows.Count - 1 >= 1)
			{
				int num = P_0.Rows.Count - 2;
				for (int i = 0; i <= num; i++)
				{
					int num2 = P_0.Rows.Count - 2;
					for (int j = num2; j >= 0; j += -1)
					{
						int num3 = Conversions.ToInteger(P_0.Rows[j].Cells[9].Value);
						int num4 = Conversions.ToInteger(P_0.Rows[j + 1].Cells[9].Value);
						if (num3 > num4)
						{
							int num5 = 0;
							do
							{
								object objectValue = RuntimeHelpers.GetObjectValue(P_0.Rows[j].Cells[num5].Value);
								P_0.Rows[j].Cells[num5].Value = RuntimeHelpers.GetObjectValue(P_0.Rows[j + 1].Cells[num5].Value);
								P_0.Rows[j + 1].Cells[num5].Value = RuntimeHelpers.GetObjectValue(objectValue);
								num5++;
							}
							while (num5 <= 12);
						}
					}
				}
			}
			if (P_3)
			{
				int num6 = P_0.Rows.Count - 2;
				for (int k = 0; k <= num6; k++)
				{
					int num7 = P_0.Rows.Count - 2;
					for (int l = num7; l >= 0; l += -1)
					{
						int num8 = Conversions.ToInteger(P_0.Rows[l].Cells[4].Value);
						int num9 = Conversions.ToInteger(P_0.Rows[l + 1].Cells[4].Value);
						int num10 = Conversions.ToInteger(P_0.Rows[l].Cells[5].Value);
						int num11 = Conversions.ToInteger(P_0.Rows[l + 1].Cells[5].Value);
						if (num8 > num9)
						{
							int num12 = 0;
							do
							{
								object objectValue2 = RuntimeHelpers.GetObjectValue(P_0.Rows[l].Cells[num12].Value);
								P_0.Rows[l].Cells[num12].Value = RuntimeHelpers.GetObjectValue(P_0.Rows[l + 1].Cells[num12].Value);
								P_0.Rows[l + 1].Cells[num12].Value = RuntimeHelpers.GetObjectValue(objectValue2);
								num12++;
							}
							while (num12 <= 12);
						}
						if (num8 == num9 && num10 < num11)
						{
							int num13 = 0;
							do
							{
								object objectValue3 = RuntimeHelpers.GetObjectValue(P_0.Rows[l].Cells[num13].Value);
								P_0.Rows[l].Cells[num13].Value = RuntimeHelpers.GetObjectValue(P_0.Rows[l + 1].Cells[num13].Value);
								P_0.Rows[l + 1].Cells[num13].Value = RuntimeHelpers.GetObjectValue(objectValue3);
								num13++;
							}
							while (num13 <= 12);
						}
					}
				}
			}
			if (!P_2)
			{
				return;
			}
			int num14 = P_0.Rows.Count - 2;
			for (int m = 0; m <= num14; m++)
			{
				int num15 = P_0.Rows.Count - 2;
				for (int n = num15; n >= 0; n += -1)
				{
					int num16 = Conversions.ToInteger(P_0.Rows[n].Cells[4].Value);
					int num17 = Conversions.ToInteger(P_0.Rows[n + 1].Cells[4].Value);
					int num18 = Conversions.ToInteger(P_0.Rows[n].Cells[5].Value);
					int num19 = Conversions.ToInteger(P_0.Rows[n + 1].Cells[5].Value);
					if (num18 < num19)
					{
						int num20 = 0;
						do
						{
							object objectValue4 = RuntimeHelpers.GetObjectValue(P_0.Rows[n].Cells[num20].Value);
							P_0.Rows[n].Cells[num20].Value = RuntimeHelpers.GetObjectValue(P_0.Rows[n + 1].Cells[num20].Value);
							P_0.Rows[n + 1].Cells[num20].Value = RuntimeHelpers.GetObjectValue(objectValue4);
							num20++;
						}
						while (num20 <= 12);
					}
					if (num18 == num19 && num16 > num17)
					{
						int num21 = 0;
						do
						{
							object objectValue5 = RuntimeHelpers.GetObjectValue(P_0.Rows[n].Cells[num21].Value);
							P_0.Rows[n].Cells[num21].Value = RuntimeHelpers.GetObjectValue(P_0.Rows[n + 1].Cells[num21].Value);
							P_0.Rows[n + 1].Cells[num21].Value = RuntimeHelpers.GetObjectValue(objectValue5);
							num21++;
						}
						while (num21 <= 12);
					}
				}
			}
		}
	}

	public static void carregaOsBornesReservaNoDG(ref DataGridView dg, DataGridView dgSel, DeclaracoesEntidades.StructureBorne[] mBornes)
	{
		checked
		{
			try
			{
				dg.Rows.Clear();
				dg.Columns.Clear();
				if (mBornes == null || Information.UBound(mBornes) == 0)
				{
					return;
				}
				formataDgBornes(ref dg);
				dg.ColumnHeadersVisible = true;
				if (Information.UBound(mBornes) > 0)
				{
					int num = Information.UBound(mBornes);
					for (int i = 1; i <= num; i++)
					{
						int num2 = dgSel.Rows.Count - 1;
						int num3 = 0;
						while (true)
						{
							if (num3 <= num2)
							{
								if (Operators.ConditionalCompareObjectEqual(mBornes[i].pagina, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true) && Operators.ConditionalCompareObjectEqual(dgSel.Rows[num3].Cells[1].Value, mBornes[i].Numero, TextCompare: true))
								{
									break;
								}
								num3++;
								continue;
							}
							if (Operators.ConditionalCompareObjectEqual(mBornes[i].pagina, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
							{
								dg.Rows.Add(mBornes[i].IndiceRegua, mBornes[i].Numero, mBornes[i].Alternativo, "", 0, 0, mBornes[i].Ordem, mBornes[i].tipo, mBornes[i].lm, 0, mBornes[i].Numero, mBornes[i].BlocoLayout, mBornes[i].Orientacao);
							}
							break;
						}
					}
				}
				int num4 = dg.Rows.Count - 1;
				for (int j = 0; j <= num4; j++)
				{
					if (!dg.Rows[j].Selected)
					{
						dg.FirstDisplayedScrollingRowIndex = j;
						break;
					}
				}
				AtualizaColunasDGBornes(ref dg);
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

	public static void formataDgBornes(ref DataGridView dg)
	{
		dg.Columns.Add("IndiceRegua", "#");
		dg.Columns.Add("Numero", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1083]));
		dg.Columns.Add("Alternativo", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 10]));
		dg.Columns.Add("sHandle", "sHandle");
		dg.Columns.Add("dX", "dX");
		dg.Columns.Add("dY", "dY");
		dg.Columns.Add("Ordem", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1082]));
		dg.Columns.Add("Tipo", "Tipo");
		dg.Columns.Add("Lm", "LM");
		dg.Columns.Add("Ordem", "Ordem");
		dg.Columns.Add("NumeroOri", "NumeroOri");
		dg.Columns.Add("BlocoLayout", "BlocoLayout");
		dg.Columns.Add("Orientação", "Orientação");
	}

	public static void AtualizaColunasDGBornes(ref DataGridView dg)
	{
		if (dg.RowCount == 0)
		{
			return;
		}
		foreach (DataGridViewRow item in (IEnumerable)dg.Rows)
		{
			dg.Rows[item.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		}
		checked
		{
			double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
			dg.Columns[0].Width = (int)Math.Round(num * 0.0);
			dg.Columns[1].Width = (int)Math.Round(num);
			dg.Columns[2].Width = 0;
			dg.Columns[3].Width = 0;
			dg.Columns[4].Width = 0;
			dg.Columns[5].Width = 0;
			dg.Columns[6].Width = 0;
			dg.Columns[7].Width = 0;
			dg.Columns[8].Width = 0;
			dg.Columns[9].Width = 0;
			dg.Columns[10].Width = 0;
			dg.Columns[11].Width = 0;
			dg.Columns[12].Width = 0;
			dg.Columns[0].Visible = false;
			dg.Columns[1].Visible = true;
			dg.Columns[2].Visible = false;
			dg.Columns[3].Visible = false;
			dg.Columns[4].Visible = false;
			dg.Columns[5].Visible = false;
			dg.Columns[6].Visible = false;
			dg.Columns[7].Visible = false;
			dg.Columns[8].Visible = false;
			dg.Columns[9].Visible = false;
			dg.Columns[10].Visible = false;
			dg.Columns[11].Visible = false;
			dg.Columns[12].Visible = false;
			int num2 = 0;
			do
			{
				dg.Columns[num2].ReadOnly = true;
				num2++;
			}
			while (num2 <= 12);
			dg.Columns[1].ReadOnly = false;
		}
	}

	private void E9sZIjGO65(object P_0, EventArgs P_1)
	{
		PointMonitorToolTips.StopMonitor();
		List<string> sHandleBornes = new List<string>();
		checked
		{
			DataGridView dg;
			try
			{
				LabelPainel.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1081], " / "), DeclaracoesGeral.mMensagem[1, 984]));
				lbBornesReserva.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1384]);
				dgBornesSel.Rows.Clear();
				dgBornesSel.Columns.Clear();
				dgBornesReserva.Rows.Clear();
				dgBornesReserva.Columns.Clear();
				eVAZsF3BCQ = new DeclaracoesEntidades.StructureBorne[1];
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				Hide();
				clsBornes.ordemBornes[] BornesSelecionadas = null;
				if (clsBornes.SelecionaBornesParaEdicao(ref BornesSelecionadas, ref X22ZADxny7, ref C9EZEDiUJ3))
				{
					dg = dgBornesSel;
					carregaOsBornesSelecionadosNoDG(ref dg, BornesSelecionadas, sHandleBornes);
					dgBornesSel = dg;
					dg = dgBornesSel;
					dNNZOmrKcv(ref dg, rbOrdemSelecao.Checked, rbOrdemXY.Checked, rbOrdemYX.Checked);
					dgBornesSel = dg;
					int num = dgBornesSel.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (Operators.CompareString(dgBornesSel.Rows[i].Cells[1].Value.ToString(), "?", TextCompare: true) == 0)
						{
							dgBornesSel.Rows[i].Cells[1].Value = "0";
						}
					}
					dg = dgBornesSel;
					AtualizaColunasDGBornes(ref dg);
					dgBornesSel = dg;
					eVAZsF3BCQ = new DeclaracoesEntidades.StructureBorne[1];
					int iMaiorOrdem = 0;
					clsBornes.capturaOutrosBornesDoDesenhoNaoSel(X22ZADxny7, ref eVAZsF3BCQ, sHandleBornes, ref iMaiorOrdem);
					fTTZZORBk3 = new DeclaracoesEntidades.StructureBorne[1];
					int x22ZADxny = X22ZADxny7;
					ref DeclaracoesEntidades.StructureBorne[] mBornes = ref fTTZZORBk3;
					int qSimples = 0;
					int qDuplo = 0;
					DicionarioBorne.LeDicBornesReserva(x22ZADxny, ref mBornes, ref qSimples, ref qDuplo);
					int x22ZADxny2 = X22ZADxny7;
					ref DeclaracoesEntidades.StructureBorne[] mBornes2 = ref eVAZsF3BCQ;
					qDuplo = 0;
					qSimples = 0;
					DicionarioBorne.LeDicBornesReserva(x22ZADxny2, ref mBornes2, ref qDuplo, ref qSimples);
					int num2 = Information.UBound(eVAZsF3BCQ);
					for (int j = 1; j <= num2; j++)
					{
						if (C9EZEDiUJ3 < eVAZsF3BCQ[j].Ordem)
						{
							C9EZEDiUJ3 = eVAZsF3BCQ[j].Ordem;
						}
					}
					string sRegua = "";
					ref int x22ZADxny3 = ref X22ZADxny7;
					string sAlternativo = "";
					int iPainel = DicionarioBorne.BuscaPainelDoBorneNoDicionario(ref x22ZADxny3, ref sRegua, ref sAlternativo);
					LabelPainel.Text = Dicionario.BuscaNomeDoPainel(iPainel) + " / " + sRegua;
				}
				Show();
				dg = dgBornesSel;
				AtualizaColunasDGBornes(ref dg);
				dgBornesSel = dg;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			if (eVAZsF3BCQ.Count() > 0)
			{
				dg = dgBornesReserva;
				carregaOsBornesReservaNoDG(ref dg, dgBornesSel, eVAZsF3BCQ);
				dgBornesReserva = dg;
				dg = dgBornesReserva;
				AtualizaColunasDGBornes(ref dg);
				dgBornesReserva = dg;
				if (dgBornesReserva.Rows.Count - 1 < 0)
				{
					dgBornesReserva.Rows.Clear();
					dgBornesReserva.Columns.Clear();
				}
			}
			dg = dgBornesReserva;
			AtualizaColunasDGBornes(ref dg);
			dgBornesReserva = dg;
			if (dgBornesSel.Rows.Count > 0)
			{
				dgBornesSel.Rows[0].Selected = true;
				dgBornesSel.FirstDisplayedScrollingRowIndex = 0;
			}
			if (dgBornesReserva.Rows.Count > 0)
			{
				dgBornesReserva.Rows[0].Selected = true;
				dgBornesReserva.FirstDisplayedScrollingRowIndex = 0;
			}
			PointMonitorToolTips.StartMonitor();
		}
	}

	private void JgWZ73HjFn(object P_0, EventArgs P_1)
	{
		dgBornesReserva.Visible = true;
		lbBornesReserva.Visible = true;
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		btSalvar.Enabled = false;
		checked
		{
			int num = dgBornesSel.Rows.Count - 1;
			for (int i = num; i >= 0; i += -1)
			{
				if (Operators.ConditionalCompareObjectEqual(dgBornesSel.Rows[i].Cells[1].Value, dgBornesSel.Rows[i].Cells[10].Value, TextCompare: true))
				{
					dgBornesSel.Rows.RemoveAt(i);
				}
			}
			int num2 = dgBornesSel.Rows.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				int ordem = Conversions.ToInteger(dgBornesSel.Rows[j].Cells[6].Value);
				int x22ZADxny = X22ZADxny7;
				DataGridViewCell dataGridViewCell;
				string numBorne = Conversions.ToString((dataGridViewCell = dgBornesSel.Rows[j].Cells[1]).Value);
				bool flag = DicionarioBorne.BuscaBornesReserva(x22ZADxny, ref numBorne, ref ordem);
				dataGridViewCell.Value = numBorne;
				if (!flag)
				{
					C9EZEDiUJ3++;
					dgBornesSel.Rows[j].Cells[6].Value = C9EZEDiUJ3;
				}
				else
				{
					dgBornesSel.Rows[j].Cells[6].Value = ordem;
				}
				if (Operators.CompareString(dgBornesSel.Rows[j].Cells[1].Value.ToString(), "0", TextCompare: true) == 0)
				{
					dgBornesSel.Rows[j].Cells[6].Value = 0;
				}
			}
			SalvarAlteracoes();
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			dgBornesSel.Rows.Clear();
			dgBornesSel.Columns.Clear();
			LabelPainel.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1081], "/"), DeclaracoesGeral.mMensagem[1, 984]));
			dgBornesReserva.Rows.Clear();
			dgBornesReserva.Columns.Clear();
		}
	}

	private void m9uZqQrLHB(object P_0, EventArgs P_1)
	{
		MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1506]), MsgBoxStyle.YesNo, "Elétron");
		if (msgBoxResult == MsgBoxResult.Yes)
		{
			clsBornes.ocultarBornesSelecionados();
		}
	}

	private void G39ZaSe7A2(object P_0, EventArgs P_1)
	{
		clsBornes.ligarBornesPagina(DeclaracoesGeral.ativo.Pagina);
	}

	public void SalvarAlteracoes()
	{
		mgyZuL1h46 = new DeclaracoesEntidades.StructureBorne[1];
		checked
		{
			int num = dgBornesSel.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				string left = Conversions.ToString(dgBornesSel.Rows[i].Cells[3].Value);
				if (Operators.CompareString(left, "", TextCompare: true) != 0)
				{
					int num2 = Information.UBound(mgyZuL1h46) + 1;
					ref DeclaracoesEntidades.StructureBorne[] reference = ref mgyZuL1h46;
					reference = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(reference, new DeclaracoesEntidades.StructureBorne[num2 + 1]);
					string numero = Conversions.ToString(dgBornesSel.Rows[i].Cells[1].Value);
					if (Operators.CompareString(dgBornesSel.Rows[i].Cells[1].Value.ToString(), "0", TextCompare: true) == 0)
					{
						numero = "?";
					}
					mgyZuL1h46[num2].Numero = numero;
					mgyZuL1h46[num2].Alternativo = clsTextos.TiraNothing(Conversions.ToString(dgBornesSel.Rows[i].Cells[2].Value));
					mgyZuL1h46[num2].Handle = Conversions.ToString(dgBornesSel.Rows[i].Cells[3].Value);
					mgyZuL1h46[num2].Ordem = Conversions.ToDouble(dgBornesSel.Rows[i].Cells[6].Value);
					mgyZuL1h46[num2].tipo = Conversions.ToInteger(dgBornesSel.Rows[i].Cells[7].Value);
					mgyZuL1h46[num2].lm = Conversions.ToInteger(dgBornesSel.Rows[i].Cells[8].Value);
					mgyZuL1h46[num2].BlocoLayout = Conversions.ToString(dgBornesSel.Rows[i].Cells[11].Value);
					mgyZuL1h46[num2].Orientacao = Conversions.ToString(dgBornesSel.Rows[i].Cells[12].Value);
				}
			}
			sGcZVvXwda = new DeclaracoesEntidades.StructureBorne[1];
			int x22ZADxny = X22ZADxny7;
			ref DeclaracoesEntidades.StructureBorne[] mBornes = ref sGcZVvXwda;
			int qSimples = 0;
			int qDuplo = 0;
			DicionarioBorne.LeDicBornesReserva(x22ZADxny, ref mBornes, ref qSimples, ref qDuplo);
			sGcZVvXwda = new DeclaracoesEntidades.StructureBorne[1];
			int num3 = dgBornesReserva.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				int num4 = Information.UBound(sGcZVvXwda) + 1;
				ref DeclaracoesEntidades.StructureBorne[] reference2 = ref sGcZVvXwda;
				reference2 = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(reference2, new DeclaracoesEntidades.StructureBorne[num4 + 1]);
				sGcZVvXwda[num4].Numero = Conversions.ToString(dgBornesReserva.Rows[j].Cells[1].Value);
				sGcZVvXwda[num4].Alternativo = clsTextos.TiraNothing(Conversions.ToString(dgBornesReserva.Rows[j].Cells[2].Value));
				sGcZVvXwda[num4].Ordem = Conversions.ToDouble(dgBornesReserva.Rows[j].Cells[6].Value);
				sGcZVvXwda[num4].tipo = Conversions.ToInteger(dgBornesReserva.Rows[j].Cells[7].Value);
				sGcZVvXwda[num4].lm = Conversions.ToInteger(dgBornesReserva.Rows[j].Cells[8].Value);
				sGcZVvXwda[num4].BlocoLayout = Conversions.ToString(dgBornesReserva.Rows[j].Cells[11].Value);
				sGcZVvXwda[num4].Orientacao = Conversions.ToString(dgBornesReserva.Rows[j].Cells[12].Value);
			}
			int x22ZADxny2 = X22ZADxny7;
			ref DeclaracoesEntidades.StructureBorne[] mBornes2 = ref sGcZVvXwda;
			qDuplo = 0;
			qSimples = 0;
			DicionarioBorne.LeDicBornesReservaEXTRAS(x22ZADxny2, ref mBornes2, ref qDuplo, ref qSimples);
			DicionarioBorne.gravaDicBornesReserva(X22ZADxny7, ref sGcZVvXwda);
			clsBornes.EditarOsTodosOsBornesDasReguasSelecionada(mgyZuL1h46);
			btSalvar.Enabled = false;
		}
	}

	private void ivJZ8y1Lvq(object P_0, EventArgs P_1)
	{
		DataGridView dg = dgBornesSel;
		AtualizaColunasDGBornes(ref dg);
		dgBornesSel = dg;
		dg = dgBornesReserva;
		AtualizaColunasDGBornes(ref dg);
		dgBornesReserva = dg;
	}

	private void gZiZNj7omX(object P_0, MouseEventArgs P_1)
	{
		DataGridView.HitTestInfo hitTestInfo = dgBornesReserva.HitTest(P_1.X, P_1.Y);
		if (hitTestInfo.RowIndex >= 0)
		{
			DataGridViewRow data = dgBornesReserva.Rows[hitTestInfo.RowIndex];
			hXOZiZhxlX = hitTestInfo.RowIndex;
			dgBornesReserva.Rows[hXOZiZhxlX].Selected = true;
			dgBornesReserva.DoDragDrop(data, DragDropEffects.All);
		}
	}

	private void i36ZFC60kf(object P_0, DragEventArgs P_1)
	{
		Point point = dgBornesSel.PointToClient(new Point(P_1.X, P_1.Y));
		DataGridView.HitTestInfo hitTestInfo = dgBornesSel.HitTest(point.X, point.Y);
		DataGridViewRow dataGridViewRow = (DataGridViewRow)P_1.Data.GetData(typeof(DataGridViewRow));
		if (hitTestInfo.RowIndex >= 0)
		{
			_ = dgBornesReserva.Rows[hXOZiZhxlX];
			zDvZSWGb9U = hitTestInfo.RowIndex;
			dgBornesReserva.Rows.Add(dgBornesSel.Rows[zDvZSWGb9U].Cells[0].Value, dgBornesSel.Rows[zDvZSWGb9U].Cells[1].Value, dgBornesSel.Rows[zDvZSWGb9U].Cells[2].Value, "", 0, 0, dgBornesSel.Rows[zDvZSWGb9U].Cells[6].Value, dgBornesSel.Rows[zDvZSWGb9U].Cells[7].Value, dgBornesSel.Rows[zDvZSWGb9U].Cells[8].Value, dgBornesSel.Rows[zDvZSWGb9U].Cells[9].Value, dgBornesSel.Rows[zDvZSWGb9U].Cells[10].Value, dgBornesSel.Rows[zDvZSWGb9U].Cells[11].Value, dgBornesSel.Rows[zDvZSWGb9U].Cells[12].Value);
			dgBornesSel.Rows[zDvZSWGb9U].Selected = true;
			dgBornesSel.Rows[zDvZSWGb9U].Cells[1].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[1].Value);
			dgBornesSel.Rows[zDvZSWGb9U].Cells[1].Style.BackColor = Color.White;
			dgBornesSel.Rows[zDvZSWGb9U].Cells[1].Style.ForeColor = Color.Black;
			dgBornesSel.Rows[zDvZSWGb9U].Cells[7].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[7].Value);
			dgBornesSel.Rows[zDvZSWGb9U].Cells[8].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[8].Value);
			dgBornesSel.Rows[zDvZSWGb9U].Cells[9].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[9].Value);
			dgBornesSel.Rows[zDvZSWGb9U].Cells[11].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[11].Value);
			dgBornesSel.Rows[zDvZSWGb9U].Cells[12].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[12].Value);
			btSalvar.Enabled = true;
		}
		dgBornesReserva.Rows.RemoveAt(hXOZiZhxlX);
		checked
		{
			if (dgBornesReserva.Rows.Count - 1 >= 1)
			{
				int num = dgBornesReserva.Rows.Count - 2;
				for (int i = 0; i <= num; i++)
				{
					int num2 = dgBornesReserva.Rows.Count - 2;
					for (int j = num2; j >= 0; j += -1)
					{
						int num3 = Conversions.ToInteger(dgBornesReserva.Rows[j].Cells[6].Value);
						int num4 = Conversions.ToInteger(dgBornesReserva.Rows[j + 1].Cells[6].Value);
						if (num3 > num4)
						{
							int num5 = 0;
							do
							{
								object objectValue = RuntimeHelpers.GetObjectValue(dgBornesReserva.Rows[j].Cells[num5].Value);
								dgBornesReserva.Rows[j].Cells[num5].Value = RuntimeHelpers.GetObjectValue(dgBornesReserva.Rows[j + 1].Cells[num5].Value);
								dgBornesReserva.Rows[j + 1].Cells[num5].Value = RuntimeHelpers.GetObjectValue(objectValue);
								num5++;
							}
							while (num5 <= 12);
						}
					}
				}
			}
			int num6 = dgBornesReserva.Rows.Count - 1;
			for (int k = 0; k <= num6; k++)
			{
				if (Operators.ConditionalCompareObjectEqual(dgBornesReserva.Rows[k].Cells[1].Value, "0", TextCompare: true))
				{
					dgBornesReserva.Rows.RemoveAt(k);
					break;
				}
			}
			DataGridView dg = dgBornesReserva;
			AtualizaColunasDGBornes(ref dg);
			dgBornesReserva = dg;
		}
	}

	private void MdBZQbY4Mf(object P_0, DragEventArgs P_1)
	{
		P_1.Effect = DragDropEffects.Copy;
	}

	private void cr3ZPSqGS1(object P_0, EventArgs P_1)
	{
		DataGridView withEventsValue = dgBornesSel;
		dNNZOmrKcv(ref withEventsValue, rbOrdemSelecao.Checked, rbOrdemXY.Checked, rbOrdemYX.Checked);
		dgBornesSel = withEventsValue;
	}

	private void htvZcYgpKa(object P_0, EventArgs P_1)
	{
		DataGridView withEventsValue = dgBornesSel;
		dNNZOmrKcv(ref withEventsValue, rbOrdemSelecao.Checked, rbOrdemXY.Checked, rbOrdemYX.Checked);
		dgBornesSel = withEventsValue;
	}
}
