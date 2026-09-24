using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
public class frmRelatorio_FiacaoDWGCompacta : Form
{
	private IContainer mQbMtYtcPP;

	[AccessedThroughProperty("tbFonteBloco")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox ybgMj5sIHD;

	[AccessedThroughProperty("LabelCorTexto")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label c82ML1fu8C;

	[AccessedThroughProperty("btCorTextoBloco")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button eAZMwpLwdc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelTamanhoFonte")]
	private Label te9MxEjrS5;

	[AccessedThroughProperty("btCorBloco")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button GXWMbL0Ikr;

	[AccessedThroughProperty("LabelQuantColunas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label qgCMMgHNkL;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelStiloLinha")]
	[CompilerGenerated]
	private Label yKlMO6GsRQ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBFonte")]
	[CompilerGenerated]
	private ComboBox cvGMIpcQ2O;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExporta")]
	private Button bkCM7Sj3x2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagar")]
	[CompilerGenerated]
	private Button yb2MqH0JEK;

	[AccessedThroughProperty("CBColunas")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ComboBox tYMMawR3S4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("FolderBrowser")]
	private FolderBrowserDialog tRGM8XiNE6;

	[AccessedThroughProperty("LBDistanciaEntreColunas")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label xQ6MNXoYiT;

	[CompilerGenerated]
	[AccessedThroughProperty("TBDisteEntreColunas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox XnPMFpsv9C;

	[AccessedThroughProperty("BTCancelar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button BE1MQTELff;

	[CompilerGenerated]
	[AccessedThroughProperty("TBAlturaInicialRelatorio")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox sSaMPOrr3k;

	[AccessedThroughProperty("LabelDistanciaDaRegua")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label ssHMcSiXEK;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBAlturaDoBloco")]
	private TextBox xbCMKLqbsm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBAlturaDoBloco")]
	private Label YxAMeE9CfZ;

	[AccessedThroughProperty("GroupBox2")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox BOKM25rJJj;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt1")]
	private Button TXRM3Wanhw;

	[AccessedThroughProperty("TBNome")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox qC6MnqWsjX;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt2")]
	private Button SqvM16950q;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSet")]
	[CompilerGenerated]
	private Button H5TMlPGkjP;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt3")]
	private Button uIcM5E5Ux9;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt5")]
	private Button qoEM0Bi230;

	[AccessedThroughProperty("bt4")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button nfSMR2gqlD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCorDoJumper")]
	private Button AMMMmrIHyq;

	[CompilerGenerated]
	[AccessedThroughProperty("LabelCorDoJumper")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label kTMMXPya4h;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GBCores")]
	[CompilerGenerated]
	private GroupBox Et1MUBMlgS;

	[AccessedThroughProperty("LabelPainel")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label zHeMyatTKb;

	[AccessedThroughProperty("LabelLinhas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label yAWMg25GGV;

	private bool wOiMAvDcDt;

	private DeclaracoesFiacao.structureRelFiacao[] dGOMsU3slG;

	private int P1ZMBv1vNm;

	private ColorDialog O6KMVIs5Kf;

	private string MQiMu9Yl9N;

	internal virtual TextBox tbFonteBloco
	{
		[CompilerGenerated]
		get
		{
			return ybgMj5sIHD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = OqJb9gdFaQ;
			TextBox textBox = ybgMj5sIHD;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			ybgMj5sIHD = value;
			textBox = ybgMj5sIHD;
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
			return c82ML1fu8C;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			c82ML1fu8C = value;
		}
	}

	internal virtual Button btCorTextoBloco
	{
		[CompilerGenerated]
		get
		{
			return eAZMwpLwdc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = pHsbCcelL3;
			Button button = eAZMwpLwdc;
			if (button != null)
			{
				button.Click -= value2;
			}
			eAZMwpLwdc = value;
			button = eAZMwpLwdc;
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
			return te9MxEjrS5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			te9MxEjrS5 = value;
		}
	}

	internal virtual Button btCorBloco
	{
		[CompilerGenerated]
		get
		{
			return GXWMbL0Ikr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Pbrb4qhA74;
			Button button = GXWMbL0Ikr;
			if (button != null)
			{
				button.Click -= value2;
			}
			GXWMbL0Ikr = value;
			button = GXWMbL0Ikr;
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
			return qgCMMgHNkL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qgCMMgHNkL = value;
		}
	}

	internal virtual Label LabelStiloLinha
	{
		[CompilerGenerated]
		get
		{
			return yKlMO6GsRQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			yKlMO6GsRQ = value;
		}
	}

	internal virtual ComboBox CBFonte
	{
		[CompilerGenerated]
		get
		{
			return cvGMIpcQ2O;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			cvGMIpcQ2O = value;
		}
	}

	internal virtual Button btExporta
	{
		[CompilerGenerated]
		get
		{
			return bkCM7Sj3x2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AVZMWiGh7t;
			Button button = bkCM7Sj3x2;
			if (button != null)
			{
				button.Click -= value2;
			}
			bkCM7Sj3x2 = value;
			button = bkCM7Sj3x2;
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
			return yb2MqH0JEK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = WsGMpEPGUd;
			Button button = yb2MqH0JEK;
			if (button != null)
			{
				button.Click -= value2;
			}
			yb2MqH0JEK = value;
			button = yb2MqH0JEK;
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
			return tYMMawR3S4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tYMMawR3S4 = value;
		}
	}

	internal virtual Label LBDistanciaEntreColunas
	{
		[CompilerGenerated]
		get
		{
			return xQ6MNXoYiT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			xQ6MNXoYiT = value;
		}
	}

	internal virtual TextBox TBDisteEntreColunas
	{
		[CompilerGenerated]
		get
		{
			return XnPMFpsv9C;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = udobz5VJrE;
			TextBox textBox = XnPMFpsv9C;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			XnPMFpsv9C = value;
			textBox = XnPMFpsv9C;
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
			return BE1MQTELff;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = GdmMTmVdgt;
			Button button = BE1MQTELff;
			if (button != null)
			{
				button.Click -= value2;
			}
			BE1MQTELff = value;
			button = BE1MQTELff;
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
			return sSaMPOrr3k;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			sSaMPOrr3k = value;
		}
	}

	internal virtual Label LabelDistanciaDaRegua
	{
		[CompilerGenerated]
		get
		{
			return ssHMcSiXEK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ssHMcSiXEK = value;
		}
	}

	internal virtual TextBox TBAlturaDoBloco
	{
		[CompilerGenerated]
		get
		{
			return xbCMKLqbsm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = NKTMJOdy3T;
			TextBox textBox = xbCMKLqbsm;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			xbCMKLqbsm = value;
			textBox = xbCMKLqbsm;
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
			return YxAMeE9CfZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			YxAMeE9CfZ = value;
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return BOKM25rJJj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			BOKM25rJJj = value;
		}
	}

	internal virtual Button bt1
	{
		[CompilerGenerated]
		get
		{
			return TXRM3Wanhw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = kEiMoJrRRh;
			Button button = TXRM3Wanhw;
			if (button != null)
			{
				button.Click -= value2;
			}
			TXRM3Wanhw = value;
			button = TXRM3Wanhw;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox TBNome
	{
		[CompilerGenerated]
		get
		{
			return qC6MnqWsjX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qC6MnqWsjX = value;
		}
	}

	internal virtual Button bt2
	{
		[CompilerGenerated]
		get
		{
			return SqvM16950q;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NmwMGkxq5x;
			Button button = SqvM16950q;
			if (button != null)
			{
				button.Click -= value2;
			}
			SqvM16950q = value;
			button = SqvM16950q;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btSet
	{
		[CompilerGenerated]
		get
		{
			return H5TMlPGkjP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RClMhUmRcP;
			Button button = H5TMlPGkjP;
			if (button != null)
			{
				button.Click -= value2;
			}
			H5TMlPGkjP = value;
			button = H5TMlPGkjP;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button bt3
	{
		[CompilerGenerated]
		get
		{
			return uIcM5E5Ux9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DdCMHUnoJq;
			Button button = uIcM5E5Ux9;
			if (button != null)
			{
				button.Click -= value2;
			}
			uIcM5E5Ux9 = value;
			button = uIcM5E5Ux9;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button bt5
	{
		[CompilerGenerated]
		get
		{
			return qoEM0Bi230;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = mtJMdNFvGO;
			Button button = qoEM0Bi230;
			if (button != null)
			{
				button.Click -= value2;
			}
			qoEM0Bi230 = value;
			button = qoEM0Bi230;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button bt4
	{
		[CompilerGenerated]
		get
		{
			return nfSMR2gqlD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = zOOMkgQHoY;
			Button button = nfSMR2gqlD;
			if (button != null)
			{
				button.Click -= value2;
			}
			nfSMR2gqlD = value;
			button = nfSMR2gqlD;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btCorDoJumper
	{
		[CompilerGenerated]
		get
		{
			return AMMMmrIHyq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = JJFbYRODcS;
			Button button = AMMMmrIHyq;
			if (button != null)
			{
				button.Click -= value2;
			}
			AMMMmrIHyq = value;
			button = AMMMmrIHyq;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label LabelCorDoJumper
	{
		[CompilerGenerated]
		get
		{
			return kTMMXPya4h;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			kTMMXPya4h = value;
		}
	}

	internal virtual GroupBox GBCores
	{
		[CompilerGenerated]
		get
		{
			return Et1MUBMlgS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Et1MUBMlgS = value;
		}
	}

	internal virtual Label LabelPainel
	{
		[CompilerGenerated]
		get
		{
			return zHeMyatTKb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zHeMyatTKb = value;
		}
	}

	internal virtual Label LabelLinhas
	{
		[CompilerGenerated]
		get
		{
			return yAWMg25GGV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			yAWMg25GGV = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && mQbMtYtcPP != null)
			{
				mQbMtYtcPP.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void UwRbSHyeXp()
	{
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmRelatorio_FiacaoDWGCompacta));
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
		aHypBEW66iS(new FolderBrowserDialog());
		LBDistanciaEntreColunas = new Label();
		TBDisteEntreColunas = new TextBox();
		BTCancelar = new Button();
		TBAlturaInicialRelatorio = new TextBox();
		LabelDistanciaDaRegua = new Label();
		TBAlturaDoBloco = new TextBox();
		LBAlturaDoBloco = new Label();
		GroupBox2 = new GroupBox();
		bt1 = new Button();
		TBNome = new TextBox();
		bt2 = new Button();
		btSet = new Button();
		bt3 = new Button();
		bt5 = new Button();
		bt4 = new Button();
		btCorDoJumper = new Button();
		LabelCorDoJumper = new Label();
		GBCores = new GroupBox();
		LabelLinhas = new Label();
		LabelPainel = new Label();
		GroupBox2.SuspendLayout();
		GBCores.SuspendLayout();
		SuspendLayout();
		btApagar.FlatStyle = FlatStyle.Flat;
		btApagar.ForeColor = SystemColors.Control;
		btApagar.Image = Resources.Delete_32;
		btApagar.Location = new Point(24, 411);
		btApagar.Name = "btApagar";
		btApagar.Size = new Size(40, 42);
		btApagar.TabIndex = 41;
		btApagar.Tag = "";
		btApagar.UseVisualStyleBackColor = true;
		btExporta.FlatStyle = FlatStyle.Flat;
		btExporta.ForeColor = SystemColors.Control;
		btExporta.Image = (Image)componentResourceManager.GetObject("btExporta.Image");
		btExporta.Location = new Point(194, 411);
		btExporta.Name = "btExporta";
		btExporta.Size = new Size(40, 42);
		btExporta.TabIndex = 39;
		btExporta.UseVisualStyleBackColor = true;
		CBColunas.FormattingEnabled = true;
		CBColunas.Location = new Point(176, 148);
		CBColunas.Name = "CBColunas";
		CBColunas.Size = new Size(47, 21);
		CBColunas.TabIndex = 52;
		CBFonte.FormattingEnabled = true;
		CBFonte.Location = new Point(92, 232);
		CBFonte.Name = "CBFonte";
		CBFonte.Size = new Size(130, 21);
		CBFonte.TabIndex = 0;
		LabelStiloLinha.Location = new Point(7, 232);
		LabelStiloLinha.Name = "LabelStiloLinha";
		LabelStiloLinha.Size = new Size(79, 23);
		LabelStiloLinha.TabIndex = 49;
		LabelStiloLinha.Text = "Fonte";
		LabelStiloLinha.TextAlign = ContentAlignment.MiddleLeft;
		LabelQuantColunas.Location = new Point(7, 148);
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
		tbFonteBloco.Location = new Point(176, 118);
		tbFonteBloco.Name = "tbFonteBloco";
		tbFonteBloco.Size = new Size(47, 20);
		tbFonteBloco.TabIndex = 27;
		tbFonteBloco.TextAlign = HorizontalAlignment.Center;
		LabelTamanhoFonte.Location = new Point(6, 118);
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
		LBDistanciaEntreColunas.Location = new Point(7, 178);
		LBDistanciaEntreColunas.Name = "LBDistanciaEntreColunas";
		LBDistanciaEntreColunas.Size = new Size(161, 25);
		LBDistanciaEntreColunas.TabIndex = 65;
		LBDistanciaEntreColunas.Text = "Distância entre Colunas";
		LBDistanciaEntreColunas.TextAlign = ContentAlignment.MiddleLeft;
		TBDisteEntreColunas.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBDisteEntreColunas.Location = new Point(176, 178);
		TBDisteEntreColunas.Name = "TBDisteEntreColunas";
		TBDisteEntreColunas.Size = new Size(47, 20);
		TBDisteEntreColunas.TabIndex = 64;
		TBDisteEntreColunas.TextAlign = HorizontalAlignment.Center;
		BTCancelar.FlatStyle = FlatStyle.Flat;
		BTCancelar.ForeColor = SystemColors.Control;
		BTCancelar.Image = Resources.Stop_32;
		BTCancelar.Location = new Point(109, 411);
		BTCancelar.Name = "BTCancelar";
		BTCancelar.Size = new Size(40, 42);
		BTCancelar.TabIndex = 66;
		BTCancelar.UseVisualStyleBackColor = true;
		TBAlturaInicialRelatorio.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBAlturaInicialRelatorio.Location = new Point(175, 262);
		TBAlturaInicialRelatorio.Name = "TBAlturaInicialRelatorio";
		TBAlturaInicialRelatorio.Size = new Size(47, 20);
		TBAlturaInicialRelatorio.TabIndex = 67;
		TBAlturaInicialRelatorio.TextAlign = HorizontalAlignment.Center;
		LabelDistanciaDaRegua.Location = new Point(7, 262);
		LabelDistanciaDaRegua.Name = "LabelDistanciaDaRegua";
		LabelDistanciaDaRegua.Size = new Size(162, 25);
		LabelDistanciaDaRegua.TabIndex = 68;
		LabelDistanciaDaRegua.Text = "Distância da Régua Horizontal";
		LabelDistanciaDaRegua.TextAlign = ContentAlignment.MiddleLeft;
		TBAlturaDoBloco.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBAlturaDoBloco.Location = new Point(176, 204);
		TBAlturaDoBloco.Name = "TBAlturaDoBloco";
		TBAlturaDoBloco.Size = new Size(47, 20);
		TBAlturaDoBloco.TabIndex = 69;
		TBAlturaDoBloco.TextAlign = HorizontalAlignment.Center;
		LBAlturaDoBloco.Location = new Point(6, 204);
		LBAlturaDoBloco.Name = "LBAlturaDoBloco";
		LBAlturaDoBloco.Size = new Size(162, 25);
		LBAlturaDoBloco.TabIndex = 70;
		LBAlturaDoBloco.Text = "Altura do Bloco";
		LBAlturaDoBloco.TextAlign = ContentAlignment.MiddleLeft;
		GroupBox2.Controls.Add(bt1);
		GroupBox2.Controls.Add(TBNome);
		GroupBox2.Controls.Add(bt2);
		GroupBox2.Controls.Add(btSet);
		GroupBox2.Controls.Add(bt3);
		GroupBox2.Controls.Add(bt5);
		GroupBox2.Controls.Add(bt4);
		GroupBox2.Location = new Point(13, 330);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(238, 75);
		GroupBox2.TabIndex = 92;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "GroupBox2";
		bt1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt1.Location = new Point(11, 46);
		bt1.Name = "bt1";
		bt1.Size = new Size(35, 23);
		bt1.TabIndex = 84;
		bt1.Text = "1";
		bt1.UseVisualStyleBackColor = true;
		TBNome.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBNome.Location = new Point(11, 20);
		TBNome.Name = "TBNome";
		TBNome.Size = new Size(84, 20);
		TBNome.TabIndex = 90;
		TBNome.TextAlign = HorizontalAlignment.Center;
		bt2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt2.Location = new Point(55, 46);
		bt2.Name = "bt2";
		bt2.Size = new Size(35, 23);
		bt2.TabIndex = 85;
		bt2.Text = "2";
		bt2.UseVisualStyleBackColor = true;
		btSet.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		btSet.Location = new Point(182, 17);
		btSet.Name = "btSet";
		btSet.Size = new Size(40, 23);
		btSet.TabIndex = 89;
		btSet.Text = "SET";
		btSet.UseVisualStyleBackColor = true;
		bt3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt3.Location = new Point(99, 46);
		bt3.Name = "bt3";
		bt3.Size = new Size(35, 23);
		bt3.TabIndex = 86;
		bt3.Text = "3";
		bt3.UseVisualStyleBackColor = true;
		bt5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt5.Location = new Point(187, 46);
		bt5.Name = "bt5";
		bt5.Size = new Size(35, 23);
		bt5.TabIndex = 88;
		bt5.Text = "5";
		bt5.UseVisualStyleBackColor = true;
		bt4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt4.Location = new Point(143, 46);
		bt4.Name = "bt4";
		bt4.Size = new Size(35, 23);
		bt4.TabIndex = 87;
		bt4.Text = "4";
		bt4.UseVisualStyleBackColor = true;
		btCorDoJumper.BackColor = SystemColors.ActiveCaption;
		btCorDoJumper.Location = new Point(176, 81);
		btCorDoJumper.Name = "btCorDoJumper";
		btCorDoJumper.Size = new Size(47, 25);
		btCorDoJumper.TabIndex = 93;
		btCorDoJumper.UseVisualStyleBackColor = false;
		LabelCorDoJumper.ImageAlign = ContentAlignment.TopLeft;
		LabelCorDoJumper.Location = new Point(6, 81);
		LabelCorDoJumper.Name = "LabelCorDoJumper";
		LabelCorDoJumper.Size = new Size(143, 25);
		LabelCorDoJumper.TabIndex = 94;
		LabelCorDoJumper.Text = "Jumper";
		LabelCorDoJumper.TextAlign = ContentAlignment.MiddleLeft;
		GBCores.Controls.Add(LabelLinhas);
		GBCores.Controls.Add(btCorBloco);
		GBCores.Controls.Add(btCorDoJumper);
		GBCores.Controls.Add(TBAlturaDoBloco);
		GBCores.Controls.Add(LBAlturaDoBloco);
		GBCores.Controls.Add(btCorTextoBloco);
		GBCores.Controls.Add(TBAlturaInicialRelatorio);
		GBCores.Controls.Add(LabelCorTexto);
		GBCores.Controls.Add(LabelDistanciaDaRegua);
		GBCores.Controls.Add(LabelCorDoJumper);
		GBCores.Controls.Add(TBDisteEntreColunas);
		GBCores.Controls.Add(LabelTamanhoFonte);
		GBCores.Controls.Add(CBFonte);
		GBCores.Controls.Add(LabelQuantColunas);
		GBCores.Controls.Add(CBColunas);
		GBCores.Controls.Add(LabelStiloLinha);
		GBCores.Controls.Add(tbFonteBloco);
		GBCores.Controls.Add(LBDistanciaEntreColunas);
		GBCores.Location = new Point(13, 30);
		GBCores.Name = "GBCores";
		GBCores.Size = new Size(238, 298);
		GBCores.TabIndex = 95;
		GBCores.TabStop = false;
		GBCores.Text = "Cores";
		LabelLinhas.ImageAlign = ContentAlignment.TopLeft;
		LabelLinhas.Location = new Point(7, 19);
		LabelLinhas.Name = "LabelLinhas";
		LabelLinhas.Size = new Size(143, 25);
		LabelLinhas.TabIndex = 95;
		LabelLinhas.Text = "Linhas";
		LabelLinhas.TextAlign = ContentAlignment.MiddleLeft;
		LabelPainel.AutoSize = true;
		LabelPainel.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		LabelPainel.Location = new Point(10, 9);
		LabelPainel.Name = "LabelPainel";
		LabelPainel.Size = new Size(73, 13);
		LabelPainel.TabIndex = 96;
		LabelPainel.Text = "LabelPainel";
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(264, 461);
		Controls.Add(LabelPainel);
		Controls.Add(GBCores);
		Controls.Add(GroupBox2);
		Controls.Add(btExporta);
		Controls.Add(btApagar);
		Controls.Add(BTCancelar);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		MaximumSize = new Size(280, 500);
		MinimizeBox = false;
		MinimumSize = new Size(280, 500);
		Name = "frmRelatorio_FiacaoDWGCompacta";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Relatório de Bornes ELS";
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		GBCores.ResumeLayout(performLayout: false);
		GBCores.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return tRGM8XiNE6;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		tRGM8XiNE6 = WithEventsValue;
	}

	public frmRelatorio_FiacaoDWGCompacta(DeclaracoesFiacao.structureRelFiacao[] mFiacao, int iPnSel)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected Obj, but got Unknown
		P1ZMBv1vNm = 0;
		O6KMVIs5Kf = new ColorDialog();
		MQiMu9Yl9N = "RelFiaELS";
		dGOMsU3slG = mFiacao;
		int num = Information.UBound(dGOMsU3slG);
		checked
		{
			for (int i = 0; i <= num; i++)
			{
				if (Operators.CompareString(dGOMsU3slG[i].Tag, null, TextCompare: true) == 0)
				{
					dGOMsU3slG[i].Tag = "";
				}
				if (Operators.CompareString(dGOMsU3slG[i].Jumper, null, TextCompare: true) == 0)
				{
					dGOMsU3slG[i].Jumper = "##B##";
				}
				if (Operators.CompareString(dGOMsU3slG[i].Terminal, null, TextCompare: true) == 0)
				{
					dGOMsU3slG[i].Terminal = "##B##";
				}
				if (Operators.CompareString(dGOMsU3slG[i].Disp1, null, TextCompare: true) == 0)
				{
					dGOMsU3slG[i].Disp1 = "##B##";
				}
				if (Operators.CompareString(dGOMsU3slG[i].Term1, null, TextCompare: true) == 0)
				{
					dGOMsU3slG[i].Term1 = "##B##";
				}
				if (Operators.CompareString(dGOMsU3slG[i].Disp2, null, TextCompare: true) == 0)
				{
					dGOMsU3slG[i].Disp2 = "##B##";
				}
				if (Operators.CompareString(dGOMsU3slG[i].Term2, null, TextCompare: true) == 0)
				{
					dGOMsU3slG[i].Term2 = "##B##";
				}
				if (Operators.CompareString(dGOMsU3slG[i].Disp3, null, TextCompare: true) == 0)
				{
					dGOMsU3slG[i].Disp3 = "##B##";
				}
				if (Operators.CompareString(dGOMsU3slG[i].Term3, null, TextCompare: true) == 0)
				{
					dGOMsU3slG[i].Term3 = "##B##";
				}
				if (Operators.CompareString(dGOMsU3slG[i].Disp4, null, TextCompare: true) == 0)
				{
					dGOMsU3slG[i].Disp4 = "##B##";
				}
				if (Operators.CompareString(dGOMsU3slG[i].Term4, null, TextCompare: true) == 0)
				{
					dGOMsU3slG[i].Term4 = "##B##";
				}
				if (Operators.CompareString(dGOMsU3slG[i].Cor12, null, TextCompare: true) == 0)
				{
					dGOMsU3slG[i].Cor12 = "";
				}
				if (Operators.CompareString(dGOMsU3slG[i].Secao12, null, TextCompare: true) == 0)
				{
					dGOMsU3slG[i].Secao12 = "";
				}
				if (Operators.CompareString(dGOMsU3slG[i].Pagina12, null, TextCompare: true) == 0)
				{
					dGOMsU3slG[i].Pagina12 = "";
				}
				if (Operators.CompareString(dGOMsU3slG[i].Cor34, null, TextCompare: true) == 0)
				{
					dGOMsU3slG[i].Cor34 = "";
				}
				if (Operators.CompareString(dGOMsU3slG[i].Secao34, null, TextCompare: true) == 0)
				{
					dGOMsU3slG[i].Secao34 = "";
				}
				if (Operators.CompareString(dGOMsU3slG[i].Pagina34, null, TextCompare: true) == 0)
				{
					dGOMsU3slG[i].Pagina34 = "";
				}
				if (Operators.CompareString(dGOMsU3slG[i].Cor12, dGOMsU3slG[i].Cor34, TextCompare: true) == 0)
				{
					dGOMsU3slG[i].Cor34 = "";
				}
				if (Operators.CompareString(dGOMsU3slG[i].Secao12, dGOMsU3slG[i].Secao34, TextCompare: true) == 0)
				{
					dGOMsU3slG[i].Secao34 = "";
				}
				if (Operators.CompareString(dGOMsU3slG[i].Pagina12, dGOMsU3slG[i].Pagina34, TextCompare: true) == 0)
				{
					dGOMsU3slG[i].Pagina34 = "";
				}
				if (Operators.CompareString(dGOMsU3slG[i].Cor12, null, TextCompare: true) == 0)
				{
					dGOMsU3slG[i].Cor12 = "##B##";
				}
				if (Operators.CompareString(dGOMsU3slG[i].Secao12, null, TextCompare: true) == 0)
				{
					dGOMsU3slG[i].Secao12 = "##B##";
				}
				if (Operators.CompareString(dGOMsU3slG[i].Pagina12, null, TextCompare: true) == 0)
				{
					dGOMsU3slG[i].Pagina12 = "##B##";
				}
			}
			int num2 = Information.UBound(dGOMsU3slG);
			for (int j = 0; j <= num2; j++)
			{
				if (Operators.CompareString(dGOMsU3slG[j].Secao12, dGOMsU3slG[j].Secao34, TextCompare: true) == 0)
				{
					dGOMsU3slG[j].Secao34 = "";
				}
				if (Operators.CompareString(dGOMsU3slG[j].Cor12, dGOMsU3slG[j].Cor34, TextCompare: true) == 0)
				{
					dGOMsU3slG[j].Cor34 = "";
				}
				if (Operators.CompareString(dGOMsU3slG[j].Pagina12, dGOMsU3slG[j].Pagina34, TextCompare: true) == 0)
				{
					dGOMsU3slG[j].Pagina34 = "";
				}
			}
			P1ZMBv1vNm = iPnSel;
			UwRbSHyeXp();
			LabelPainel.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 626], " : "), Dicionario.BuscaNomeDoPainel(iPnSel)));
			DeclaracoesGeral.Reguas RH = default;
			if (XDataGeral.LeXDataReguaH(ref RH))
			{
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1657]);
				GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 382]);
				LabelTamanhoFonte.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 339]);
				LabelLinhas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 340]);
				LabelCorTexto.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 341]);
				LabelCorDoJumper.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1149]);
				LabelQuantColunas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 342]);
				LabelStiloLinha.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 343]);
				LBAlturaDoBloco.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 344]);
				LBDistanciaEntreColunas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 345]);
				LabelDistanciaDaRegua.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 350]);
				LabelCorDoJumper.Enabled = true;
				btCorDoJumper.Enabled = true;
				tbFonteBloco.Text = "2";
				CBColunas.Items.Clear();
				CBColunas.Items.Add("1");
				CBColunas.Items.Add("2");
				CBColunas.Items.Add("3");
				CBColunas.Items.Add("4");
				CBColunas.Items.Add("5");
				CBColunas.Items.Add("6");
				CBColunas.Text = "2";
				CBColunas.Text = "5";
				TBAlturaInicialRelatorio.Text = "25";
				TBDisteEntreColunas.Text = Conversions.ToString(6);
				TBAlturaDoBloco.Text = Conversions.ToString(7);
				Color val = Color.FromColorIndex((ColorMethod)194, (short)7);
				btCorBloco.BackColor = val.ColorValue;
				val = Color.FromColorIndex((ColorMethod)194, (short)7);
				btCorTextoBloco.BackColor = val.ColorValue;
				val = Color.FromColorIndex((ColorMethod)194, (short)7);
				btCorDoJumper.BackColor = val.ColorValue;
				Declaracoes2.confRelFiacao.CorLinha = 7;
				Declaracoes2.confRelFiacao.CorTexto = 7;
				Application.ShowModelessDialog((Form)this);
				if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
				{
					Left = 0;
				}
				string[] array = new string[1];
				array = (string[])Relatorios_GeralDWG.CapturaOsTextStyle();
				CBFonte.Items.Clear();
				CBFonte.Text = array[1].ToString();
				int num3 = Information.UBound(array);
				for (int k = 1; k <= num3; k++)
				{
					CBFonte.Items.Add(array[k]);
					if (Operators.CompareString(array[k].ToString().ToUpper(), "ROMANS", TextCompare: true) == 0)
					{
						CBFonte.Text = array[k];
					}
				}
				pX6Mf4j7TO();
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 611]), MsgBoxStyle.Information);
			}
		}
	}

	private void Pbrb4qhA74(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = O6KMVIs5Kf.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			Declaracoes2.confRelFiacao.CorLinha = O6KMVIs5Kf.Color.ColorIndex;
			btCorBloco.BackColor = O6KMVIs5Kf.Color.ColorValue;
		}
	}

	private void pHsbCcelL3(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = O6KMVIs5Kf.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			Declaracoes2.confRelFiacao.CorTexto = O6KMVIs5Kf.Color.ColorIndex;
			btCorTextoBloco.BackColor = O6KMVIs5Kf.Color.ColorValue;
		}
	}

	private void JJFbYRODcS(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = O6KMVIs5Kf.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			Declaracoes2.confRelFiacao.CorDoJumper = O6KMVIs5Kf.Color.ColorIndex;
			btCorDoJumper.BackColor = O6KMVIs5Kf.Color.ColorValue;
		}
	}

	private short t4gbrhTjLm()
	{
		DialogResult dialogResult = O6KMVIs5Kf.ShowDialog();
		if (dialogResult != DialogResult.OK)
		{
			return 7;
		}
		return O6KMVIs5Kf.Color.ColorIndex;
	}

	private void OqJb9gdFaQ(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void udobz5VJrE(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void AVZMWiGh7t(object P_0, EventArgs P_1)
	{
		Declaracoes2.confRelFiacao.TamanhoFonte = Conversions.ToDouble(tbFonteBloco.Text);
		Declaracoes2.confRelFiacao.QuantColunas = checked((short)Conversions.ToInteger(CBColunas.Text));
		Declaracoes2.confRelFiacao.AlturaInicial = Conversions.ToDouble(TBAlturaInicialRelatorio.Text);
		Declaracoes2.confRelFiacao.sFonte = CBFonte.Text;
		Declaracoes2.confRelFiacao.DistEntreColunas = Conversions.ToDouble(TBDisteEntreColunas.Text);
		Declaracoes2.confRelFiacao.AlturaDoBloco = Conversions.ToDouble(TBAlturaDoBloco.Text);
		dGOMsU3slG[0].Terminal = DeclaracoesGeral.mMensagem[1, 771].ToString().ToUpper();
		dGOMsU3slG[0].Disp1 = DeclaracoesGeral.mMensagem[1, 777].ToString().ToUpper();
		dGOMsU3slG[0].Term1 = DeclaracoesGeral.mMensagem[1, 778].ToString().ToUpper();
		dGOMsU3slG[0].Disp2 = DeclaracoesGeral.mMensagem[1, 779].ToString().ToUpper();
		dGOMsU3slG[0].Term2 = DeclaracoesGeral.mMensagem[1, 780].ToString().ToUpper();
		dGOMsU3slG[0].Cor12 = DeclaracoesGeral.mMensagem[1, 782].ToString().ToUpper();
		dGOMsU3slG[0].Secao12 = DeclaracoesGeral.mMensagem[1, 781].ToString().ToUpper() + " MM²";
		dGOMsU3slG[0].Pagina12 = DeclaracoesGeral.mMensagem[1, 783].ToString().ToUpper();
		Relatorios_FiacaoDWGCompacta.CriaRelatorioMatrizFiacaoBornesCompactoDWG(dGOMsU3slG, Declaracoes2.confRelFiacao, "EB", P1ZMBv1vNm);
	}

	private void WsGMpEPGUd(object P_0, EventArgs P_1)
	{
		string sTipoRelatotio = "EB";
		Relatorios_FiacaoDWG.ApagaRelatorioDeplaquetas(ref sTipoRelatotio, P1ZMBv1vNm);
	}

	private void GdmMTmVdgt(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.bPararRelatorio = true;
		Application.DoEvents();
	}

	private void NKTMJOdy3T(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void RClMhUmRcP(object P_0, EventArgs P_1)
	{
		if (wOiMAvDcDt)
		{
			wOiMAvDcDt = false;
			pX6Mf4j7TO();
			return;
		}
		wOiMAvDcDt = true;
		bt1.Enabled = true;
		bt2.Enabled = true;
		bt3.Enabled = true;
		bt4.Enabled = true;
		bt5.Enabled = true;
	}

	private void kEiMoJrRRh(object P_0, EventArgs P_1)
	{
		if (wOiMAvDcDt)
		{
			rsVM6Fqqe9(1);
			wOiMAvDcDt = false;
		}
		else
		{
			TBNome.Text = "";
			JUhMDByRWD(1);
		}
	}

	private void NmwMGkxq5x(object P_0, EventArgs P_1)
	{
		if (wOiMAvDcDt)
		{
			rsVM6Fqqe9(2);
			wOiMAvDcDt = false;
		}
		else
		{
			TBNome.Text = "";
			JUhMDByRWD(2);
		}
	}

	private void DdCMHUnoJq(object P_0, EventArgs P_1)
	{
		if (wOiMAvDcDt)
		{
			rsVM6Fqqe9(3);
			wOiMAvDcDt = false;
		}
		else
		{
			TBNome.Text = "";
			JUhMDByRWD(3);
		}
	}

	private void zOOMkgQHoY(object P_0, EventArgs P_1)
	{
		if (wOiMAvDcDt)
		{
			rsVM6Fqqe9(4);
			wOiMAvDcDt = false;
		}
		else
		{
			TBNome.Text = "";
			JUhMDByRWD(4);
		}
	}

	private void mtJMdNFvGO(object P_0, EventArgs P_1)
	{
		if (wOiMAvDcDt)
		{
			rsVM6Fqqe9(5);
			wOiMAvDcDt = false;
		}
		else
		{
			TBNome.Text = "";
			JUhMDByRWD(5);
		}
	}

	private void pX6Mf4j7TO()
	{
		TBNome.Text = "";
		bt1.Enabled = false;
		bt2.Enabled = false;
		bt3.Enabled = false;
		bt4.Enabled = false;
		bt5.Enabled = false;
		checked
		{
			if (!((Operators.CompareString(DeclaracoesGeral.Conf.DirProjeto.Trim(), "", TextCompare: true) == 0) | !File.Exists(DeclaracoesGeral.Conf.DirProjeto)))
			{
				GroupBox2.Enabled = true;
				cDadosAccessComum cDadosAccessComum2 = new cDadosAccessComum();
				try
				{
					DataTable dataTable = cDadosAccessComum2.LeConfiguracaoRelatorio("F", MQiMu9Yl9N);
					if (Information.IsNothing(dataTable))
					{
						return;
					}
					int num = dataTable.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						object left = dataTable.Rows[i][0];
						if (!Operators.ConditionalCompareObjectEqual(left, 1, TextCompare: true))
						{
							if (!Operators.ConditionalCompareObjectEqual(left, 2, TextCompare: true))
							{
								if (!Operators.ConditionalCompareObjectEqual(left, 3, TextCompare: true))
								{
									if (!Operators.ConditionalCompareObjectEqual(left, 4, TextCompare: true))
									{
										if (Operators.ConditionalCompareObjectEqual(left, 5, TextCompare: true))
										{
											bt5.Enabled = true;
										}
									}
									else
									{
										bt4.Enabled = true;
									}
								}
								else
								{
									bt3.Enabled = true;
								}
							}
							else
							{
								bt2.Enabled = true;
							}
						}
						else
						{
							bt1.Enabled = true;
						}
					}
					return;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
					return;
				}
				finally
				{
					cDadosAccessComum2.fechaConexao();
				}
			}
			GroupBox2.Enabled = false;
		}
	}

	private void JUhMDByRWD(int P_0)
	{
		if (!clsAuxiliar.BancoValido())
		{
			return;
		}
		string sComando = "";
		cDadosAccessComum cDadosAccessComum2 = new cDadosAccessComum();
		try
		{
			cDadosAccessComum2.LeConfiguracao(ref sComando, P_0, "F", MQiMu9Yl9N);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		finally
		{
			cDadosAccessComum2.fechaConexao();
		}
		object[] array = new object[1];
		object obj = array;
		kETMvDeNqG(ref obj, sComando);
		array = (object[])obj;
		TBNome.Text = Conversions.ToString(array[1]);
		Color val = Color.FromColorIndex((ColorMethod)194, Conversions.ToShort(array[2]));
		btCorBloco.BackColor = val.ColorValue;
		Declaracoes2.confRelFiacao.CorLinha = val.ColorIndex;
		val = Color.FromColorIndex((ColorMethod)194, Conversions.ToShort(array[3]));
		btCorTextoBloco.BackColor = val.ColorValue;
		Declaracoes2.confRelFiacao.CorTexto = val.ColorIndex;
		val = Color.FromColorIndex((ColorMethod)194, Conversions.ToShort(array[4]));
		btCorDoJumper.BackColor = val.ColorValue;
		Declaracoes2.confRelFiacao.CorDoJumper = val.ColorIndex;
		tbFonteBloco.Text = Conversions.ToString(array[5]);
		CBColunas.Text = Conversions.ToString(array[6]);
		TBDisteEntreColunas.Text = Conversions.ToString(array[7]);
		TBAlturaDoBloco.Text = Conversions.ToString(array[8]);
		CBFonte.Text = Conversions.ToString(array[9]);
		TBAlturaInicialRelatorio.Text = Conversions.ToString(array[10]);
	}

	private void kETMvDeNqG(ref object P_0, string P_1)
	{
		string text = "";
		string text2 = P_1 + ";";
		int num = Strings.Len(text2);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				string text3 = Strings.Mid(text2, i, 1);
				if (Operators.CompareString(text3, ";", TextCompare: true) != 0)
				{
					text += text3;
				}
				if (Operators.CompareString(text3, ";", TextCompare: true) == 0)
				{
					short num2 = (short)(Information.UBound((Array)P_0) + 1);
					P_0 = Utils.CopyArray((Array)P_0, new object[num2 + 1]);
					NewLateBinding.LateIndexSet(P_0, new object[2] { num2, text }, null);
					text = "";
				}
			}
		}
	}

	private void rsVM6Fqqe9(int P_0)
	{
		if (!clsAuxiliar.BancoValido())
		{
			return;
		}
		string text = TBNome.Text;
		text = text + ";" + Conversions.ToString((int)Declaracoes2.confRelFiacao.CorLinha);
		text = text + ";" + Conversions.ToString((int)Declaracoes2.confRelFiacao.CorTexto);
		text = text + ";" + Conversions.ToString((int)Declaracoes2.confRelFiacao.CorDoJumper);
		text = text + ";" + tbFonteBloco.Text;
		text = text + ";" + CBColunas.Text;
		text = text + ";" + TBDisteEntreColunas.Text;
		text = text + ";" + TBAlturaDoBloco.Text;
		text = text + ";" + CBFonte.Text;
		text = text + ";" + TBAlturaInicialRelatorio.Text;
		cDadosAccessComum cDadosAccessComum2 = new cDadosAccessComum();
		try
		{
			cDadosAccessComum2.GravaConfiguracao(text, P_0, "F", MQiMu9Yl9N);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		finally
		{
			cDadosAccessComum2.fechaConexao();
		}
		pX6Mf4j7TO();
	}
}
