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
public class frmRelatorio_PotenciaisDWG : Form
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

	private IContainer HTZpQA16C5v;

	[AccessedThroughProperty("tbFonteBloco")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox BEZpQs95dE2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelCorTexto")]
	private Label pB7pQBH5wCJ;

	[AccessedThroughProperty("btCorTextoBloco")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button PASpQVA7D0I;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelTamanhoFonte")]
	[CompilerGenerated]
	private Label lS3pQuVvV5F;

	[AccessedThroughProperty("btCorBloco")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button n6vpQEwcDD8;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelQuantColunas")]
	private Label G7spQZTexAF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelStiloLinha")]
	private Label u6GpQiKg7M8;

	[AccessedThroughProperty("CBFonte")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ComboBox TRGpQSkNEL8;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExporta")]
	private Button vs4pQ4qn7jD;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagar")]
	[CompilerGenerated]
	private Button VsHpQCeJiPt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBColunas")]
	private ComboBox TWkpQYj4CGs;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBDistanciaEntreColunas")]
	private Label RejpQrZtLVX;

	[AccessedThroughProperty("TBDisteEntreColunas")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox sHWpQ9kBMAj;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTCancelar")]
	[CompilerGenerated]
	private Button UoipQz3YaTn;

	[AccessedThroughProperty("TBAlturaInicialRelatorio")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox pGWpPWEcLq2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelDistanciaDaRegua")]
	[CompilerGenerated]
	private Label j8PpPpZwiLw;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBAlturaDoBloco")]
	private TextBox aIQpPTNpmaK;

	[AccessedThroughProperty("LBAlturaDoBloco")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label QiTpPJa8MNY;

	[AccessedThroughProperty("GroupBoxxxxxxxxxxxxxxxxxxx")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox A1epPh8jmR8;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelPainel")]
	private Label vigpPoiadhR;

	[CompilerGenerated]
	[AccessedThroughProperty("LabelLinhas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label c7XpPGDMdvN;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	[CompilerGenerated]
	private ToolTip q2PpPHhsHvt;

	private bool ghepPkmHExs;

	private ConfRelelatorio kUSpPdm8mck;

	private DeclaracoesFiacao.structureRelPotencial[] knbpPfyxTwi;

	private string NkhpPDxx4gl;

	private int QDJpPvGASba;

	private ColorDialog n9ipP6VrSOS;

	internal virtual TextBox tbFonteBloco
	{
		[CompilerGenerated]
		get
		{
			return BEZpQs95dE2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = kEvpQRgJAbC;
			TextBox textBox = BEZpQs95dE2;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			BEZpQs95dE2 = value;
			textBox = BEZpQs95dE2;
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
			return pB7pQBH5wCJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pB7pQBH5wCJ = value;
		}
	}

	internal virtual Button btCorTextoBloco
	{
		[CompilerGenerated]
		get
		{
			return PASpQVA7D0I;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = F2kpQ5VbqMJ;
			Button button = PASpQVA7D0I;
			if (button != null)
			{
				button.Click -= value2;
			}
			PASpQVA7D0I = value;
			button = PASpQVA7D0I;
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
			return lS3pQuVvV5F;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			lS3pQuVvV5F = value;
		}
	}

	internal virtual Button btCorBloco
	{
		[CompilerGenerated]
		get
		{
			return n6vpQEwcDD8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = kEEpQlx3tOn;
			Button button = n6vpQEwcDD8;
			if (button != null)
			{
				button.Click -= value2;
			}
			n6vpQEwcDD8 = value;
			button = n6vpQEwcDD8;
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
			return G7spQZTexAF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			G7spQZTexAF = value;
		}
	}

	internal virtual Label LabelStiloLinha
	{
		[CompilerGenerated]
		get
		{
			return u6GpQiKg7M8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			u6GpQiKg7M8 = value;
		}
	}

	internal virtual ComboBox CBFonte
	{
		[CompilerGenerated]
		get
		{
			return TRGpQSkNEL8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TRGpQSkNEL8 = value;
		}
	}

	internal virtual Button btExporta
	{
		[CompilerGenerated]
		get
		{
			return vs4pQ4qn7jD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = s6QpQXCV8Or;
			Button button = vs4pQ4qn7jD;
			if (button != null)
			{
				button.Click -= value2;
			}
			vs4pQ4qn7jD = value;
			button = vs4pQ4qn7jD;
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
			return VsHpQCeJiPt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = L8QpQUY3d5f;
			Button button = VsHpQCeJiPt;
			if (button != null)
			{
				button.Click -= value2;
			}
			VsHpQCeJiPt = value;
			button = VsHpQCeJiPt;
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
			return TWkpQYj4CGs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TWkpQYj4CGs = value;
		}
	}

	internal virtual Label LBDistanciaEntreColunas
	{
		[CompilerGenerated]
		get
		{
			return RejpQrZtLVX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			RejpQrZtLVX = value;
		}
	}

	internal virtual TextBox TBDisteEntreColunas
	{
		[CompilerGenerated]
		get
		{
			return sHWpQ9kBMAj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = AP9pQmMpZS7;
			TextBox textBox = sHWpQ9kBMAj;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			sHWpQ9kBMAj = value;
			textBox = sHWpQ9kBMAj;
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
			return UoipQz3YaTn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ETFpQyyn9tU;
			Button button = UoipQz3YaTn;
			if (button != null)
			{
				button.Click -= value2;
			}
			UoipQz3YaTn = value;
			button = UoipQz3YaTn;
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
			return pGWpPWEcLq2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pGWpPWEcLq2 = value;
		}
	}

	internal virtual Label LabelDistanciaDaRegua
	{
		[CompilerGenerated]
		get
		{
			return j8PpPpZwiLw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			j8PpPpZwiLw = value;
		}
	}

	internal virtual TextBox TBAlturaDoBloco
	{
		[CompilerGenerated]
		get
		{
			return aIQpPTNpmaK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = ghopQgBc7iy;
			TextBox textBox = aIQpPTNpmaK;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			aIQpPTNpmaK = value;
			textBox = aIQpPTNpmaK;
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
			return QiTpPJa8MNY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			QiTpPJa8MNY = value;
		}
	}

	internal virtual GroupBox GroupBoxxxxxxxxxxxxxxxxxxx
	{
		[CompilerGenerated]
		get
		{
			return A1epPh8jmR8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			A1epPh8jmR8 = value;
		}
	}

	internal virtual Label LabelPainel
	{
		[CompilerGenerated]
		get
		{
			return vigpPoiadhR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			vigpPoiadhR = value;
		}
	}

	internal virtual Label LabelLinhas
	{
		[CompilerGenerated]
		get
		{
			return c7XpPGDMdvN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			c7XpPGDMdvN = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && HTZpQA16C5v != null)
			{
				HTZpQA16C5v.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void zJlpQ1ZOwJl()
	{
		HTZpQA16C5v = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmRelatorio_PotenciaisDWG));
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
		FDqpBiUmZij(new ToolTip(HTZpQA16C5v));
		GroupBoxxxxxxxxxxxxxxxxxxx.SuspendLayout();
		SuspendLayout();
		btApagar.FlatStyle = FlatStyle.Flat;
		btApagar.ForeColor = SystemColors.Control;
		btApagar.Image = Resources.Delete_32;
		btApagar.Location = new Point(52, 256);
		btApagar.Name = "btApagar";
		btApagar.Size = new Size(40, 42);
		btApagar.TabIndex = 41;
		btApagar.Tag = "";
		btApagar.UseVisualStyleBackColor = true;
		btExporta.FlatStyle = FlatStyle.Flat;
		btExporta.ForeColor = SystemColors.Control;
		btExporta.Image = (Image)componentResourceManager.GetObject("btExporta.Image");
		btExporta.Location = new Point(134, 256);
		btExporta.Name = "btExporta";
		btExporta.Size = new Size(40, 42);
		btExporta.TabIndex = 39;
		btExporta.UseVisualStyleBackColor = true;
		CBColunas.FormattingEnabled = true;
		CBColunas.Location = new Point(176, 111);
		CBColunas.Name = "CBColunas";
		CBColunas.Size = new Size(47, 21);
		CBColunas.TabIndex = 52;
		CBFonte.FormattingEnabled = true;
		CBFonte.Location = new Point(92, 195);
		CBFonte.Name = "CBFonte";
		CBFonte.Size = new Size(130, 21);
		CBFonte.TabIndex = 0;
		LabelStiloLinha.Location = new Point(7, 195);
		LabelStiloLinha.Name = "LabelStiloLinha";
		LabelStiloLinha.Size = new Size(79, 23);
		LabelStiloLinha.TabIndex = 49;
		LabelStiloLinha.Text = "Fonte";
		LabelStiloLinha.TextAlign = ContentAlignment.MiddleLeft;
		LabelQuantColunas.Location = new Point(7, 111);
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
		tbFonteBloco.Location = new Point(176, 81);
		tbFonteBloco.Name = "tbFonteBloco";
		tbFonteBloco.Size = new Size(47, 20);
		tbFonteBloco.TabIndex = 27;
		tbFonteBloco.TextAlign = HorizontalAlignment.Center;
		LabelTamanhoFonte.Location = new Point(6, 81);
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
		LBDistanciaEntreColunas.Location = new Point(7, 141);
		LBDistanciaEntreColunas.Name = "LBDistanciaEntreColunas";
		LBDistanciaEntreColunas.Size = new Size(161, 25);
		LBDistanciaEntreColunas.TabIndex = 65;
		LBDistanciaEntreColunas.Text = "Distância entre Colunas";
		LBDistanciaEntreColunas.TextAlign = ContentAlignment.MiddleLeft;
		TBDisteEntreColunas.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBDisteEntreColunas.Location = new Point(176, 141);
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
		TBAlturaInicialRelatorio.Location = new Point(175, 225);
		TBAlturaInicialRelatorio.Name = "TBAlturaInicialRelatorio";
		TBAlturaInicialRelatorio.Size = new Size(47, 20);
		TBAlturaInicialRelatorio.TabIndex = 67;
		TBAlturaInicialRelatorio.TextAlign = HorizontalAlignment.Center;
		LabelDistanciaDaRegua.Location = new Point(7, 225);
		LabelDistanciaDaRegua.Name = "LabelDistanciaDaRegua";
		LabelDistanciaDaRegua.Size = new Size(162, 25);
		LabelDistanciaDaRegua.TabIndex = 68;
		LabelDistanciaDaRegua.Text = "Distância da Régua Horizontal";
		LabelDistanciaDaRegua.TextAlign = ContentAlignment.MiddleLeft;
		TBAlturaDoBloco.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBAlturaDoBloco.Location = new Point(176, 167);
		TBAlturaDoBloco.Name = "TBAlturaDoBloco";
		TBAlturaDoBloco.Size = new Size(47, 20);
		TBAlturaDoBloco.TabIndex = 69;
		TBAlturaDoBloco.TextAlign = HorizontalAlignment.Center;
		LBAlturaDoBloco.Location = new Point(6, 167);
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
		GroupBoxxxxxxxxxxxxxxxxxxx.Size = new Size(238, 305);
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
		ClientSize = new Size(260, 339);
		Controls.Add(LabelPainel);
		Controls.Add(GroupBoxxxxxxxxxxxxxxxxxxx);
		Controls.Add(BTCancelar);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "frmRelatorio_PotenciaisDWG";
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
		return q2PpPHhsHvt;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		q2PpPHhsHvt = WithEventsValue;
	}

	public frmRelatorio_PotenciaisDWG(DeclaracoesFiacao.structureRelPotencial[] mRelatPotenciais, string sTipoRel, int iPnSel)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Obj, but got Unknown
		NkhpPDxx4gl = "";
		QDJpPvGASba = 0;
		n9ipP6VrSOS = new ColorDialog();
		knbpPfyxTwi = mRelatPotenciais;
		NkhpPDxx4gl = sTipoRel;
		QDJpPvGASba = iPnSel;
		zJlpQ1ZOwJl();
		LabelPainel.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 626], " : "), Dicionario.BuscaNomeDoPainel(iPnSel)));
		DeclaracoesGeral.Reguas RH = default;
		if (XDataGeral.LeXDataReguaH(ref RH))
		{
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 820]);
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
			kUSpPdm8mck.CorLinha = 7;
			kUSpPdm8mck.CorTexto = 7;
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

	private void kEEpQlx3tOn(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = n9ipP6VrSOS.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			kUSpPdm8mck.CorLinha = n9ipP6VrSOS.Color.ColorIndex;
			btCorBloco.BackColor = n9ipP6VrSOS.Color.ColorValue;
		}
	}

	private void F2kpQ5VbqMJ(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = n9ipP6VrSOS.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			kUSpPdm8mck.CorTexto = n9ipP6VrSOS.Color.ColorIndex;
			btCorTextoBloco.BackColor = n9ipP6VrSOS.Color.ColorValue;
		}
	}

	private short fELpQ0JTXFL()
	{
		DialogResult dialogResult = n9ipP6VrSOS.ShowDialog();
		if (dialogResult != DialogResult.OK)
		{
			return 7;
		}
		return n9ipP6VrSOS.Color.ColorIndex;
	}

	private void kEvpQRgJAbC(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void AP9pQmMpZS7(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void s6QpQXCV8Or(object P_0, EventArgs P_1)
	{
		kUSpPdm8mck.TamanhoFonte = Conversions.ToDouble(tbFonteBloco.Text);
		kUSpPdm8mck.QuantColunas = checked((short)Conversions.ToInteger(CBColunas.Text));
		kUSpPdm8mck.AlturaInicial = Conversions.ToDouble(TBAlturaInicialRelatorio.Text);
		kUSpPdm8mck.sFonte = CBFonte.Text;
		kUSpPdm8mck.DistEntreColunas = Conversions.ToDouble(TBDisteEntreColunas.Text);
		kUSpPdm8mck.AlturaDoBloco = Conversions.ToDouble(TBAlturaDoBloco.Text);
		knbpPfyxTwi[0].tag1 = DeclaracoesGeral.mMensagem[1, 777].ToString().ToUpper();
		knbpPfyxTwi[0].term1 = DeclaracoesGeral.mMensagem[1, 778].ToString().ToUpper();
		knbpPfyxTwi[0].tag2 = DeclaracoesGeral.mMensagem[1, 779].ToString().ToUpper();
		knbpPfyxTwi[0].term2 = DeclaracoesGeral.mMensagem[1, 780].ToString().ToUpper();
		knbpPfyxTwi[0].cor = DeclaracoesGeral.mMensagem[1, 782].ToString().ToUpper();
		knbpPfyxTwi[0].secao = DeclaracoesGeral.mMensagem[1, 781].ToString().ToUpper();
		knbpPfyxTwi[0].pagina = DeclaracoesGeral.mMensagem[1, 783].ToString().ToUpper();
		Relatorios_PotenciaisDWG.CriaMatrizDePotenciaisDWG(knbpPfyxTwi, kUSpPdm8mck, "P", QDJpPvGASba);
	}

	private void L8QpQUY3d5f(object P_0, EventArgs P_1)
	{
		Relatorios_PotenciaisDWG.ApagaRelatorioPotencial(ref NkhpPDxx4gl, QDJpPvGASba);
	}

	private void ETFpQyyn9tU(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.bPararRelatorio = true;
		Application.DoEvents();
	}

	private void ghopQgBc7iy(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}
}
