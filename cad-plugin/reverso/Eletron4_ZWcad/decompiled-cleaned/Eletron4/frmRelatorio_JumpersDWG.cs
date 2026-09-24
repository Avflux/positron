using System;
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
using ZwSoft.ZwCAD.Colors;
using ZwSoft.ZwCAD.Windows;

namespace Eletron4;

[DesignerGenerated]
public class frmRelatorio_JumpersDWG : Form
{
	public struct ConfRelelatorio
	{
		public short CorLinha;

		public short CorTexto;

		public double TamanhoFonte;

		public short QuantColunas;

		public double AlturaInicial;

		public double DistEntreColunas;

		public double AlturaDoBloco;

		public string sFonte;

		public string TAG;

		public string Disp1;

		public string Term1;

		public string Disp2;

		public string Term2;

		public string Cor;

		public string Secao;

		public string Pagina;
	}

	private IContainer h95pqdO9WFq;

	[AccessedThroughProperty("tbFonteBloco")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox rOqpqf0lBw5;

	[AccessedThroughProperty("LabelCorTexto")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label FPspqDpKey1;

	[AccessedThroughProperty("btCorTextoBloco")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button wxepqvppmHp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelTamanhoFonte")]
	private Label Eh2pq6vN0d4;

	[CompilerGenerated]
	[AccessedThroughProperty("btCorBloco")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button AAHpqt9xaof;

	[AccessedThroughProperty("LabelQuantColunas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label ghwpqj8qHh0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelStiloLinha")]
	private Label fHvpqL0twHB;

	[AccessedThroughProperty("CBFonte")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ComboBox DoJpqwKDvq9;

	[CompilerGenerated]
	[AccessedThroughProperty("btExporta")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button HNSpqxu7wT2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagar")]
	private Button e4fpqbVc4k4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBColunas")]
	private ComboBox H8FpqMiopFn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBDistanciaEntreColunas")]
	private Label ohjpqO94AHo;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBDisteEntreColunas")]
	[CompilerGenerated]
	private TextBox vKOpqIBUaUo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTCancelar")]
	private Button VYopq7K9rO7;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBAlturaInicialRelatorio")]
	private TextBox slopqqLXOVG;

	[AccessedThroughProperty("LabelDistanciaDaRegua")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label OBLpqao8P5Y;

	[CompilerGenerated]
	[AccessedThroughProperty("TBAlturaDoBloco")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox dBapq8CxovX;

	[AccessedThroughProperty("LBAlturaDoBloco")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label eAvpqNY0Bxp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBoxxxxxxxxxxxxxxxxxxx")]
	private GroupBox pQ4pqFbuVLe;

	[CompilerGenerated]
	[AccessedThroughProperty("LabelPainel")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label yg5pqQUid02;

	[CompilerGenerated]
	[AccessedThroughProperty("LabelLinhas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label I9spqPm6nJO;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip OQ5pqcsk5M3;

	private bool YAJpqK24Fi3;

	private ConfRelelatorio AqXpqe3HgIW;

	private DeclaracoesFiacao.structureRelPotencial[] xNTpq2oKGlE;

	private string Hyrpq3uWt3C;

	private int N7ypqnptfC7;

	private ColorDialog Ssapq1v4r3a;

	internal virtual TextBox tbFonteBloco
	{
		[CompilerGenerated]
		get
		{
			return rOqpqf0lBw5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = gTJpqJpoqhq;
			TextBox textBox = rOqpqf0lBw5;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			rOqpqf0lBw5 = value;
			textBox = rOqpqf0lBw5;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual Label LabelCorTexto
	{
		[CompilerGenerated]
		get
		{
			return FPspqDpKey1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			FPspqDpKey1 = value;
		}
	}

	internal virtual Button btCorTextoBloco
	{
		[CompilerGenerated]
		get
		{
			return wxepqvppmHp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ouXpqpqdB3e;
			Button button = wxepqvppmHp;
			if (button != null)
			{
				button.Click -= value2;
			}
			wxepqvppmHp = value;
			button = wxepqvppmHp;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label LabelTamanhoFonte
	{
		[CompilerGenerated]
		get
		{
			return Eh2pq6vN0d4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Eh2pq6vN0d4 = value;
		}
	}

	internal virtual Button btCorBloco
	{
		[CompilerGenerated]
		get
		{
			return AAHpqt9xaof;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = wA0pqWTOKre;
			Button button = AAHpqt9xaof;
			if (button != null)
			{
				button.Click -= value2;
			}
			AAHpqt9xaof = value;
			button = AAHpqt9xaof;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label LabelQuantColunas
	{
		[CompilerGenerated]
		get
		{
			return ghwpqj8qHh0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ghwpqj8qHh0 = value;
		}
	}

	internal virtual Label LabelStiloLinha
	{
		[CompilerGenerated]
		get
		{
			return fHvpqL0twHB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			fHvpqL0twHB = value;
		}
	}

	internal virtual ComboBox CBFonte
	{
		[CompilerGenerated]
		get
		{
			return DoJpqwKDvq9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DoJpqwKDvq9 = value;
		}
	}

	internal virtual Button btExporta
	{
		[CompilerGenerated]
		get
		{
			return HNSpqxu7wT2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = V46pqoTWZQ4;
			Button button = HNSpqxu7wT2;
			if (button != null)
			{
				button.Click -= value2;
			}
			HNSpqxu7wT2 = value;
			button = HNSpqxu7wT2;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btApagar
	{
		[CompilerGenerated]
		get
		{
			return e4fpqbVc4k4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = jlIpqGf7jFA;
			Button button = e4fpqbVc4k4;
			if (button != null)
			{
				button.Click -= value2;
			}
			e4fpqbVc4k4 = value;
			button = e4fpqbVc4k4;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual ComboBox CBColunas
	{
		[CompilerGenerated]
		get
		{
			return H8FpqMiopFn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			H8FpqMiopFn = value;
		}
	}

	internal virtual Label LBDistanciaEntreColunas
	{
		[CompilerGenerated]
		get
		{
			return ohjpqO94AHo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ohjpqO94AHo = value;
		}
	}

	internal virtual TextBox TBDisteEntreColunas
	{
		[CompilerGenerated]
		get
		{
			return vKOpqIBUaUo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = S07pqhmawYH;
			TextBox textBox = vKOpqIBUaUo;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			vKOpqIBUaUo = value;
			textBox = vKOpqIBUaUo;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual Button BTCancelar
	{
		[CompilerGenerated]
		get
		{
			return VYopq7K9rO7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PAYpqHJfZhK;
			Button button = VYopq7K9rO7;
			if (button != null)
			{
				button.Click -= value2;
			}
			VYopq7K9rO7 = value;
			button = VYopq7K9rO7;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox TBAlturaInicialRelatorio
	{
		[CompilerGenerated]
		get
		{
			return slopqqLXOVG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			slopqqLXOVG = value;
		}
	}

	internal virtual Label LabelDistanciaDaRegua
	{
		[CompilerGenerated]
		get
		{
			return OBLpqao8P5Y;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			OBLpqao8P5Y = value;
		}
	}

	internal virtual TextBox TBAlturaDoBloco
	{
		[CompilerGenerated]
		get
		{
			return dBapq8CxovX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = CRxpqkN6P2u;
			TextBox textBox = dBapq8CxovX;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			dBapq8CxovX = value;
			textBox = dBapq8CxovX;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual Label LBAlturaDoBloco
	{
		[CompilerGenerated]
		get
		{
			return eAvpqNY0Bxp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			eAvpqNY0Bxp = value;
		}
	}

	internal virtual GroupBox GroupBoxxxxxxxxxxxxxxxxxxx
	{
		[CompilerGenerated]
		get
		{
			return pQ4pqFbuVLe;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pQ4pqFbuVLe = value;
		}
	}

	internal virtual Label LabelPainel
	{
		[CompilerGenerated]
		get
		{
			return yg5pqQUid02;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			yg5pqQUid02 = value;
		}
	}

	internal virtual Label LabelLinhas
	{
		[CompilerGenerated]
		get
		{
			return I9spqPm6nJO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			I9spqPm6nJO = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && h95pqdO9WFq != null)
			{
				h95pqdO9WFq.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void xb9p7zh1NJ8()
	{
		h95pqdO9WFq = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmRelatorio_JumpersDWG));
		btApagar = new Button();
		btExporta = new Button();
		CBColunas = new ComboBox();
		CBFonte = new ComboBox();
		LabelStiloLinha = new Label();
		LabelQuantColunas = new Label();
		LabelCorTexto = new Label();
		btCorTextoBloco = new Button();
		tbFonteBloco = new TextBox();
		LabelTamanhoFonte = new Label();
		btCorBloco = new Button();
		LBDistanciaEntreColunas = new Label();
		TBDisteEntreColunas = new TextBox();
		BTCancelar = new Button();
		TBAlturaInicialRelatorio = new TextBox();
		LabelDistanciaDaRegua = new Label();
		TBAlturaDoBloco = new TextBox();
		LBAlturaDoBloco = new Label();
		GroupBoxxxxxxxxxxxxxxxxxxx = new GroupBox();
		LabelLinhas = new Label();
		LabelPainel = new Label();
		FDqpBiUmZij(new ToolTip(h95pqdO9WFq));
		GroupBoxxxxxxxxxxxxxxxxxxx.SuspendLayout();
		SuspendLayout();
		btApagar.FlatStyle = FlatStyle.Flat;
		btApagar.ForeColor = SystemColors.Control;
		btApagar.Image = Resources.Delete_32;
		btApagar.Location = new Point(53, 261);
		btApagar.Name = "btApagar";
		btApagar.Size = new Size(40, 42);
		btApagar.TabIndex = 41;
		btApagar.Tag = "";
		btApagar.UseVisualStyleBackColor = true;
		btExporta.FlatStyle = FlatStyle.Flat;
		btExporta.ForeColor = SystemColors.Control;
		btExporta.Image = (Image)componentResourceManager.GetObject("btExporta.Image");
		btExporta.Location = new Point(135, 261);
		btExporta.Name = "btExporta";
		btExporta.Size = new Size(40, 42);
		btExporta.TabIndex = 39;
		btExporta.UseVisualStyleBackColor = true;
		CBColunas.FormattingEnabled = true;
		CBColunas.Location = new Point(177, 116);
		CBColunas.Name = "CBColunas";
		CBColunas.Size = new Size(47, 21);
		CBColunas.TabIndex = 52;
		CBFonte.FormattingEnabled = true;
		CBFonte.Location = new Point(93, 200);
		CBFonte.Name = "CBFonte";
		CBFonte.Size = new Size(130, 21);
		CBFonte.TabIndex = 0;
		LabelStiloLinha.Location = new Point(8, 200);
		LabelStiloLinha.Name = "LabelStiloLinha";
		LabelStiloLinha.Size = new Size(79, 23);
		LabelStiloLinha.TabIndex = 49;
		LabelStiloLinha.Text = "Fonte";
		LabelStiloLinha.TextAlign = ContentAlignment.MiddleLeft;
		LabelQuantColunas.Location = new Point(8, 116);
		LabelQuantColunas.Name = "LabelQuantColunas";
		LabelQuantColunas.Size = new Size(130, 25);
		LabelQuantColunas.TabIndex = 45;
		LabelQuantColunas.Text = "Quantidede de Colunas";
		LabelQuantColunas.TextAlign = ContentAlignment.MiddleLeft;
		LabelCorTexto.ImageAlign = ContentAlignment.TopLeft;
		LabelCorTexto.Location = new Point(6, 50);
		LabelCorTexto.Name = "LabelCorTexto";
		LabelCorTexto.Size = new Size(143, 25);
		LabelCorTexto.TabIndex = 38;
		LabelCorTexto.Text = "Textos";
		LabelCorTexto.TextAlign = ContentAlignment.MiddleLeft;
		btCorTextoBloco.BackColor = SystemColors.ActiveCaption;
		btCorTextoBloco.Location = new Point(176, 50);
		btCorTextoBloco.Name = "btCorTextoBloco";
		btCorTextoBloco.Size = new Size(47, 25);
		btCorTextoBloco.TabIndex = 1;
		btCorTextoBloco.UseVisualStyleBackColor = false;
		tbFonteBloco.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbFonteBloco.Location = new Point(177, 86);
		tbFonteBloco.Name = "tbFonteBloco";
		tbFonteBloco.Size = new Size(47, 20);
		tbFonteBloco.TabIndex = 27;
		tbFonteBloco.TextAlign = HorizontalAlignment.Center;
		LabelTamanhoFonte.Location = new Point(7, 86);
		LabelTamanhoFonte.Name = "LabelTamanhoFonte";
		LabelTamanhoFonte.Size = new Size(162, 25);
		LabelTamanhoFonte.TabIndex = 36;
		LabelTamanhoFonte.Text = "Tamanho do Fonte";
		LabelTamanhoFonte.TextAlign = ContentAlignment.MiddleLeft;
		btCorBloco.BackColor = SystemColors.ActiveCaption;
		btCorBloco.Location = new Point(176, 19);
		btCorBloco.Name = "btCorBloco";
		btCorBloco.Size = new Size(47, 25);
		btCorBloco.TabIndex = 0;
		btCorBloco.UseVisualStyleBackColor = false;
		LBDistanciaEntreColunas.Location = new Point(8, 146);
		LBDistanciaEntreColunas.Name = "LBDistanciaEntreColunas";
		LBDistanciaEntreColunas.Size = new Size(161, 25);
		LBDistanciaEntreColunas.TabIndex = 65;
		LBDistanciaEntreColunas.Text = "Distância entre Colunas";
		LBDistanciaEntreColunas.TextAlign = ContentAlignment.MiddleLeft;
		TBDisteEntreColunas.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBDisteEntreColunas.Location = new Point(177, 146);
		TBDisteEntreColunas.Name = "TBDisteEntreColunas";
		TBDisteEntreColunas.Size = new Size(47, 20);
		TBDisteEntreColunas.TabIndex = 64;
		TBDisteEntreColunas.TextAlign = HorizontalAlignment.Center;
		BTCancelar.FlatStyle = FlatStyle.Flat;
		BTCancelar.ForeColor = SystemColors.Control;
		BTCancelar.Image = Resources.Stop_32;
		BTCancelar.Location = new Point(104, 427);
		BTCancelar.Name = "BTCancelar";
		BTCancelar.Size = new Size(40, 42);
		BTCancelar.TabIndex = 66;
		BTCancelar.UseVisualStyleBackColor = true;
		TBAlturaInicialRelatorio.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBAlturaInicialRelatorio.Location = new Point(176, 230);
		TBAlturaInicialRelatorio.Name = "TBAlturaInicialRelatorio";
		TBAlturaInicialRelatorio.Size = new Size(47, 20);
		TBAlturaInicialRelatorio.TabIndex = 67;
		TBAlturaInicialRelatorio.TextAlign = HorizontalAlignment.Center;
		LabelDistanciaDaRegua.Location = new Point(8, 230);
		LabelDistanciaDaRegua.Name = "LabelDistanciaDaRegua";
		LabelDistanciaDaRegua.Size = new Size(162, 25);
		LabelDistanciaDaRegua.TabIndex = 68;
		LabelDistanciaDaRegua.Text = "Distância da Régua Horizontal";
		LabelDistanciaDaRegua.TextAlign = ContentAlignment.MiddleLeft;
		TBAlturaDoBloco.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBAlturaDoBloco.Location = new Point(177, 172);
		TBAlturaDoBloco.Name = "TBAlturaDoBloco";
		TBAlturaDoBloco.Size = new Size(47, 20);
		TBAlturaDoBloco.TabIndex = 69;
		TBAlturaDoBloco.TextAlign = HorizontalAlignment.Center;
		LBAlturaDoBloco.Location = new Point(7, 172);
		LBAlturaDoBloco.Name = "LBAlturaDoBloco";
		LBAlturaDoBloco.Size = new Size(162, 25);
		LBAlturaDoBloco.TabIndex = 70;
		LBAlturaDoBloco.Text = "Altura do Bloco";
		LBAlturaDoBloco.TextAlign = ContentAlignment.MiddleLeft;
		GroupBoxxxxxxxxxxxxxxxxxxx.Controls.Add(LabelLinhas);
		GroupBoxxxxxxxxxxxxxxxxxxx.Controls.Add(btCorBloco);
		GroupBoxxxxxxxxxxxxxxxxxxx.Controls.Add(TBAlturaDoBloco);
		GroupBoxxxxxxxxxxxxxxxxxxx.Controls.Add(btExporta);
		GroupBoxxxxxxxxxxxxxxxxxxx.Controls.Add(btApagar);
		GroupBoxxxxxxxxxxxxxxxxxxx.Controls.Add(LBAlturaDoBloco);
		GroupBoxxxxxxxxxxxxxxxxxxx.Controls.Add(btCorTextoBloco);
		GroupBoxxxxxxxxxxxxxxxxxxx.Controls.Add(TBAlturaInicialRelatorio);
		GroupBoxxxxxxxxxxxxxxxxxxx.Controls.Add(LabelCorTexto);
		GroupBoxxxxxxxxxxxxxxxxxxx.Controls.Add(LabelDistanciaDaRegua);
		GroupBoxxxxxxxxxxxxxxxxxxx.Controls.Add(TBDisteEntreColunas);
		GroupBoxxxxxxxxxxxxxxxxxxx.Controls.Add(LabelTamanhoFonte);
		GroupBoxxxxxxxxxxxxxxxxxxx.Controls.Add(CBFonte);
		GroupBoxxxxxxxxxxxxxxxxxxx.Controls.Add(LabelQuantColunas);
		GroupBoxxxxxxxxxxxxxxxxxxx.Controls.Add(CBColunas);
		GroupBoxxxxxxxxxxxxxxxxxxx.Controls.Add(LabelStiloLinha);
		GroupBoxxxxxxxxxxxxxxxxxxx.Controls.Add(tbFonteBloco);
		GroupBoxxxxxxxxxxxxxxxxxxx.Controls.Add(LBDistanciaEntreColunas);
		GroupBoxxxxxxxxxxxxxxxxxxx.Location = new Point(12, 25);
		GroupBoxxxxxxxxxxxxxxxxxxx.Name = "GroupBoxxxxxxxxxxxxxxxxxxx";
		GroupBoxxxxxxxxxxxxxxxxxxx.Size = new Size(238, 312);
		GroupBoxxxxxxxxxxxxxxxxxxx.TabIndex = 95;
		GroupBoxxxxxxxxxxxxxxxxxxx.TabStop = false;
		LabelLinhas.ImageAlign = ContentAlignment.TopLeft;
		LabelLinhas.Location = new Point(7, 19);
		LabelLinhas.Name = "LabelLinhas";
		LabelLinhas.Size = new Size(143, 25);
		LabelLinhas.TabIndex = 95;
		LabelLinhas.Text = "Linhas";
		LabelLinhas.TextAlign = ContentAlignment.MiddleLeft;
		LabelPainel.AutoSize = true;
		LabelPainel.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		LabelPainel.Location = new Point(9, 9);
		LabelPainel.Name = "LabelPainel";
		LabelPainel.Size = new Size(73, 13);
		LabelPainel.TabIndex = 96;
		LabelPainel.Text = "LabelPainel";
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(260, 345);
		Controls.Add(LabelPainel);
		Controls.Add(GroupBoxxxxxxxxxxxxxxxxxxx);
		Controls.Add(BTCancelar);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "frmRelatorio_JumpersDWG";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Relatório de Potenciais DWG";
		GroupBoxxxxxxxxxxxxxxxxxxx.ResumeLayout(performLayout: false);
		GroupBoxxxxxxxxxxxxxxxxxxx.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return OQ5pqcsk5M3;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		OQ5pqcsk5M3 = WithEventsValue;
	}

	public frmRelatorio_JumpersDWG(DeclaracoesFiacao.structureRelPotencial[] mRelatPotenciais, string sTipoRel, int iPnSel)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Obj, but got Unknown
		Hyrpq3uWt3C = "";
		N7ypqnptfC7 = 0;
		Ssapq1v4r3a = new ColorDialog();
		xNTpq2oKGlE = mRelatPotenciais;
		Hyrpq3uWt3C = sTipoRel;
		N7ypqnptfC7 = iPnSel;
		xb9p7zh1NJ8();
		LabelPainel.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 626], " : "), Dicionario.BuscaNomeDoPainel(iPnSel)));
		DeclaracoesGeral.Reguas RH = default;
		if (XDataGeral.LeXDataReguaH(ref RH))
		{
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 898]);
			LabelTamanhoFonte.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 339]);
			LabelLinhas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 340]);
			LabelCorTexto.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 341]);
			LabelQuantColunas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 342]);
			LabelStiloLinha.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 343]);
			LBAlturaDoBloco.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 344]);
			LBDistanciaEntreColunas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 345]);
			LabelDistanciaDaRegua.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 350]);
			tbFonteBloco.Text = "2";
			CBColunas.Items.Clear();
			CBColunas.Items.Add("1");
			CBColunas.Items.Add("2");
			CBColunas.Items.Add("3");
			CBColunas.Items.Add("4");
			CBColunas.Items.Add("5");
			CBColunas.Items.Add("6");
			CBColunas.Text = "2";
			if (Operators.CompareString(sTipoRel, "C", TextCompare: true) == 0)
			{
				CBColunas.Text = "4";
			}
			TBAlturaInicialRelatorio.Text = "25";
			TBDisteEntreColunas.Text = Conversions.ToString(6);
			TBAlturaDoBloco.Text = Conversions.ToString(7);
			Color val = Color.FromColorIndex((ColorMethod)194, (short)7);
			btCorBloco.BackColor = val.ColorValue;
			val = Color.FromColorIndex((ColorMethod)194, (short)7);
			btCorTextoBloco.BackColor = val.ColorValue;
			AqXpqe3HgIW.CorLinha = 7;
			AqXpqe3HgIW.CorTexto = 7;
			Application.ShowModelessDialog((Form)this);
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
			string[] array = new string[1];
			array = (string[])Relatorios_GeralDWG.CapturaOsTextStyle();
			CBFonte.Items.Clear();
			CBFonte.Text = array[1].ToString();
			int num = Information.UBound(array);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				CBFonte.Items.Add(array[i]);
				if (Operators.CompareString(array[i].ToString().ToUpper(), "ROMANS", TextCompare: true) == 0)
				{
					CBFonte.Text = array[i];
				}
			}
		}
		else
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 611]), MsgBoxStyle.Information);
		}
	}

	private void wA0pqWTOKre(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = Ssapq1v4r3a.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			AqXpqe3HgIW.CorLinha = Ssapq1v4r3a.Color.ColorIndex;
			btCorBloco.BackColor = Ssapq1v4r3a.Color.ColorValue;
		}
	}

	private void ouXpqpqdB3e(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = Ssapq1v4r3a.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			AqXpqe3HgIW.CorTexto = Ssapq1v4r3a.Color.ColorIndex;
			btCorTextoBloco.BackColor = Ssapq1v4r3a.Color.ColorValue;
		}
	}

	private short cakpqTE1TQC()
	{
		DialogResult dialogResult = Ssapq1v4r3a.ShowDialog();
		if (dialogResult != DialogResult.OK)
		{
			return 7;
		}
		return Ssapq1v4r3a.Color.ColorIndex;
	}

	private void gTJpqJpoqhq(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void S07pqhmawYH(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void V46pqoTWZQ4(object P_0, EventArgs P_1)
	{
		AqXpqe3HgIW.TamanhoFonte = Conversions.ToDouble(tbFonteBloco.Text);
		AqXpqe3HgIW.QuantColunas = checked((short)Conversions.ToInteger(CBColunas.Text));
		AqXpqe3HgIW.AlturaInicial = Conversions.ToDouble(TBAlturaInicialRelatorio.Text);
		AqXpqe3HgIW.sFonte = CBFonte.Text;
		AqXpqe3HgIW.DistEntreColunas = Conversions.ToDouble(TBDisteEntreColunas.Text);
		AqXpqe3HgIW.AlturaDoBloco = Conversions.ToDouble(TBAlturaDoBloco.Text);
		xNTpq2oKGlE[0].tag1 = DeclaracoesGeral.mMensagem[1, 777].ToString().ToUpper();
		xNTpq2oKGlE[0].term1 = DeclaracoesGeral.mMensagem[1, 778].ToString().ToUpper();
		xNTpq2oKGlE[0].tag2 = DeclaracoesGeral.mMensagem[1, 779].ToString().ToUpper();
		xNTpq2oKGlE[0].term2 = DeclaracoesGeral.mMensagem[1, 780].ToString().ToUpper();
		xNTpq2oKGlE[0].cor = DeclaracoesGeral.mMensagem[1, 782].ToString().ToUpper();
		xNTpq2oKGlE[0].secao = DeclaracoesGeral.mMensagem[1, 781].ToString().ToUpper();
		xNTpq2oKGlE[0].pagina = DeclaracoesGeral.mMensagem[1, 783].ToString().ToUpper();
		Relatorios_JumpersDWG.CriaMatrizDePotenciaisDWG(xNTpq2oKGlE, AqXpqe3HgIW, "J", N7ypqnptfC7);
	}

	private void jlIpqGf7jFA(object P_0, EventArgs P_1)
	{
		Relatorios_JumpersDWG.ApagaRelatorioPotencial(ref Hyrpq3uWt3C, N7ypqnptfC7);
	}

	private void PAYpqHJfZhK(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.bPararRelatorio = true;
		Application.DoEvents();
	}

	private void CRxpqkN6P2u(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}
}
