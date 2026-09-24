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
public class frmRelatorio_PlaquetasDWG : Form
{
	public struct ConfigRelatorioPlaquetas
	{
		public short CorLinha;

		public short CorJumper;

		public short CorTexto;

		public double TamanhoFonte;

		public short QuantColunas;

		public double AlturaInicial;

		public double DistEntreColunas;

		public double AlturaDoBloco;

		public string sFonte;
	}

	private IContainer fyspFMHCYMl;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox2")]
	private GroupBox BCgpFOVp7y2;

	[AccessedThroughProperty("LabelLinhas")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label whtpFIb3X0R;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCorBloco")]
	private Button ykJpF7w2olK;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBAlturaDoBloco")]
	private TextBox PM4pFqUIcZg;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExporta")]
	[CompilerGenerated]
	private Button H69pFaHTqwU;

	[AccessedThroughProperty("btApagar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button dovpF8UT0e3;

	[AccessedThroughProperty("LBAlturaDoBloco")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label m8jpFNjmoKf;

	[AccessedThroughProperty("btCorTextoBloco")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button LkppFFoyUBf;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBAlturaInicialRelatorio")]
	private TextBox tOupFQIBUYw;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelCorTexto")]
	[CompilerGenerated]
	private Label uRQpFPaTL8m;

	[CompilerGenerated]
	[AccessedThroughProperty("LabelDistanciaDaRegua")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label I39pFcCEBRb;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBDisteEntreColunas")]
	[CompilerGenerated]
	private TextBox E8hpFKgJ2RA;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelTamanhoFonte")]
	private Label ga8pFeASJl4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBFonte")]
	private ComboBox GxHpF27XWP2;

	[AccessedThroughProperty("LabelQuantColunas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label HYApF3WjpCd;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBColunas")]
	private ComboBox siipFn8YNdX;

	[CompilerGenerated]
	[AccessedThroughProperty("LabelStiloLinha")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label LvrpF167OFL;

	[AccessedThroughProperty("tbFonteBloco")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox lgNpFl7Iy62;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBDistanciaEntreColunas")]
	private Label Y7ppF5LpDLk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip sp6pF0N4FNE;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btEletronorte")]
	private Button t7FpFR8RZU0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btEletron")]
	private Button Jg4pFmjPluP;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox WCRpFXSDdc0;

	[AccessedThroughProperty("btEletrosul")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button Y22pFUOyNnU;

	[AccessedThroughProperty("GroupBox3")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox y9ZpFyKS2Eg;

	[AccessedThroughProperty("bt1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button ADcpFgbrPIe;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("TBNome")]
	private TextBox VgepFAKA0ov;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("bt2")]
	private Button RqopFspieTB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSet")]
	private Button eaEpFBRmxta;

	[CompilerGenerated]
	[AccessedThroughProperty("bt3")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button pQYpFVOdl80;

	[AccessedThroughProperty("bt5")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button TYBpFuVm6FN;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("bt4")]
	private Button qqMpFEBYOnq;

	[AccessedThroughProperty("btCHESF")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button YRWpFZSIJQB;

	[AccessedThroughProperty("RB_CBA")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton zENpFiwGcbP;

	[AccessedThroughProperty("RB_ABC")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton JyxpFS5ytO2;

	[AccessedThroughProperty("btCTEEP")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button OEwpF4rbAVf;

	[CompilerGenerated]
	[AccessedThroughProperty("RB_Customizada")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton lNMpFCMb733;

	[AccessedThroughProperty("blOrdemSel")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label FkxpFYhjXao;

	private DeclaracoesFiacao.structureRelPlaquetas[] EgrpFrd5siQ;

	private int tSQpF9Uku8V;

	private string TRbpFziHugr;

	private bool LX9pQWkg4oj;

	private ConfigRelatorioPlaquetas s7qpQp2qLtm;

	private ColorDialog GwKpQTajqFQ;

	private int qfppQJoJ8ok;

	private int e1epQhiV78J;

	private double o6wpQoejjlY;

	private double wUgpQGHn0ML;

	private string a7ZpQHDcoay;

	private string Ev7pQk60JvX;

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return BCgpFOVp7y2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			BCgpFOVp7y2 = value;
		}
	}

	internal virtual Label LabelLinhas
	{
		[CompilerGenerated]
		get
		{
			return whtpFIb3X0R;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			whtpFIb3X0R = value;
		}
	}

	internal virtual Button btCorBloco
	{
		[CompilerGenerated]
		get
		{
			return ykJpF7w2olK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CnwpNSBQIsh;
			Button button = ykJpF7w2olK;
			if (button != null)
			{
				button.Click -= value2;
			}
			ykJpF7w2olK = value;
			button = ykJpF7w2olK;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox TBAlturaDoBloco
	{
		[CompilerGenerated]
		get
		{
			return PM4pFqUIcZg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = E87pN91xdYV;
			TextBox textBox = PM4pFqUIcZg;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			PM4pFqUIcZg = value;
			textBox = PM4pFqUIcZg;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual Button btExporta
	{
		[CompilerGenerated]
		get
		{
			return H69pFaHTqwU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = xHGpFho96Wr;
			Button button = H69pFaHTqwU;
			if (button != null)
			{
				button.Click -= value2;
			}
			H69pFaHTqwU = value;
			button = H69pFaHTqwU;
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
			return dovpF8UT0e3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AUFpFoBxSQM;
			Button button = dovpF8UT0e3;
			if (button != null)
			{
				button.Click -= value2;
			}
			dovpF8UT0e3 = value;
			button = dovpF8UT0e3;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label LBAlturaDoBloco
	{
		[CompilerGenerated]
		get
		{
			return m8jpFNjmoKf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m8jpFNjmoKf = value;
		}
	}

	internal virtual Button btCorTextoBloco
	{
		[CompilerGenerated]
		get
		{
			return LkppFFoyUBf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OP7pN4XtIWo;
			Button button = LkppFFoyUBf;
			if (button != null)
			{
				button.Click -= value2;
			}
			LkppFFoyUBf = value;
			button = LkppFFoyUBf;
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
			return tOupFQIBUYw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tOupFQIBUYw = value;
		}
	}

	internal virtual Label LabelCorTexto
	{
		[CompilerGenerated]
		get
		{
			return uRQpFPaTL8m;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			uRQpFPaTL8m = value;
		}
	}

	internal virtual Label LabelDistanciaDaRegua
	{
		[CompilerGenerated]
		get
		{
			return I39pFcCEBRb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			I39pFcCEBRb = value;
		}
	}

	internal virtual TextBox TBDisteEntreColunas
	{
		[CompilerGenerated]
		get
		{
			return E8hpFKgJ2RA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = JRepNrDZr7U;
			TextBox textBox = E8hpFKgJ2RA;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			E8hpFKgJ2RA = value;
			textBox = E8hpFKgJ2RA;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual Label LabelTamanhoFonte
	{
		[CompilerGenerated]
		get
		{
			return ga8pFeASJl4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ga8pFeASJl4 = value;
		}
	}

	internal virtual ComboBox CBFonte
	{
		[CompilerGenerated]
		get
		{
			return GxHpF27XWP2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			GxHpF27XWP2 = value;
		}
	}

	internal virtual Label LabelQuantColunas
	{
		[CompilerGenerated]
		get
		{
			return HYApF3WjpCd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			HYApF3WjpCd = value;
		}
	}

	internal virtual ComboBox CBColunas
	{
		[CompilerGenerated]
		get
		{
			return siipFn8YNdX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			siipFn8YNdX = value;
		}
	}

	internal virtual Label LabelStiloLinha
	{
		[CompilerGenerated]
		get
		{
			return LvrpF167OFL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LvrpF167OFL = value;
		}
	}

	internal virtual TextBox tbFonteBloco
	{
		[CompilerGenerated]
		get
		{
			return lgNpFl7Iy62;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = nTgpNYii8Ga;
			TextBox textBox = lgNpFl7Iy62;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			lgNpFl7Iy62 = value;
			textBox = lgNpFl7Iy62;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual Label LBDistanciaEntreColunas
	{
		[CompilerGenerated]
		get
		{
			return Y7ppF5LpDLk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Y7ppF5LpDLk = value;
		}
	}

	internal virtual Button btEletronorte
	{
		[CompilerGenerated]
		get
		{
			return t7FpFR8RZU0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = obFpFWCGnpF;
			Button button = t7FpFR8RZU0;
			if (button != null)
			{
				button.Click -= value2;
			}
			t7FpFR8RZU0 = value;
			button = t7FpFR8RZU0;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btEletron
	{
		[CompilerGenerated]
		get
		{
			return Jg4pFmjPluP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = wJupNz5okYw;
			Button button = Jg4pFmjPluP;
			if (button != null)
			{
				button.Click -= value2;
			}
			Jg4pFmjPluP = value;
			button = Jg4pFmjPluP;
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
			return WCRpFXSDdc0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			WCRpFXSDdc0 = value;
		}
	}

	internal virtual Button btEletrosul
	{
		[CompilerGenerated]
		get
		{
			return Y22pFUOyNnU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = X0VpFpAh5KS;
			Button button = Y22pFUOyNnU;
			if (button != null)
			{
				button.Click -= value2;
			}
			Y22pFUOyNnU = value;
			button = Y22pFUOyNnU;
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
			return y9ZpFyKS2Eg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			y9ZpFyKS2Eg = value;
		}
	}

	internal virtual Button bt1
	{
		[CompilerGenerated]
		get
		{
			return ADcpFgbrPIe;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TmcpFHmMORU;
			Button button = ADcpFgbrPIe;
			if (button != null)
			{
				button.Click -= value2;
			}
			ADcpFgbrPIe = value;
			button = ADcpFgbrPIe;
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
			return VgepFAKA0ov;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			VgepFAKA0ov = value;
		}
	}

	internal virtual Button bt2
	{
		[CompilerGenerated]
		get
		{
			return RqopFspieTB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = IwJpFkNoeTc;
			Button button = RqopFspieTB;
			if (button != null)
			{
				button.Click -= value2;
			}
			RqopFspieTB = value;
			button = RqopFspieTB;
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
			return eaEpFBRmxta;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TqVpFGY6WaY;
			Button button = eaEpFBRmxta;
			if (button != null)
			{
				button.Click -= value2;
			}
			eaEpFBRmxta = value;
			button = eaEpFBRmxta;
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
			return pQYpFVOdl80;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = xmDpFdUVbHP;
			Button button = pQYpFVOdl80;
			if (button != null)
			{
				button.Click -= value2;
			}
			pQYpFVOdl80 = value;
			button = pQYpFVOdl80;
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
			return TYBpFuVm6FN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = hPypFDdTRS2;
			Button button = TYBpFuVm6FN;
			if (button != null)
			{
				button.Click -= value2;
			}
			TYBpFuVm6FN = value;
			button = TYBpFuVm6FN;
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
			return qqMpFEBYOnq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = C1spFfYO9Fc;
			Button button = qqMpFEBYOnq;
			if (button != null)
			{
				button.Click -= value2;
			}
			qqMpFEBYOnq = value;
			button = qqMpFEBYOnq;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btCHESF
	{
		[CompilerGenerated]
		get
		{
			return YRWpFZSIJQB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = BQ6pFT8Uq5m;
			Button button = YRWpFZSIJQB;
			if (button != null)
			{
				button.Click -= value2;
			}
			YRWpFZSIJQB = value;
			button = YRWpFZSIJQB;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual RadioButton RB_CBA
	{
		[CompilerGenerated]
		get
		{
			return zENpFiwGcbP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = rflpFwm3JOK;
			RadioButton radioButton = zENpFiwGcbP;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			zENpFiwGcbP = value;
			radioButton = zENpFiwGcbP;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton RB_ABC
	{
		[CompilerGenerated]
		get
		{
			return JyxpFS5ytO2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SbCpFLLqOK5;
			RadioButton radioButton = JyxpFS5ytO2;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			JyxpFS5ytO2 = value;
			radioButton = JyxpFS5ytO2;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button btCTEEP
	{
		[CompilerGenerated]
		get
		{
			return OEwpF4rbAVf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = p9KpFJEdD4H;
			Button button = OEwpF4rbAVf;
			if (button != null)
			{
				button.Click -= value2;
			}
			OEwpF4rbAVf = value;
			button = OEwpF4rbAVf;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual RadioButton RB_Customizada
	{
		[CompilerGenerated]
		get
		{
			return lNMpFCMb733;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = XR7pFxmjHYl;
			RadioButton radioButton = lNMpFCMb733;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			lNMpFCMb733 = value;
			radioButton = lNMpFCMb733;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual Label blOrdemSel
	{
		[CompilerGenerated]
		get
		{
			return FkxpFYhjXao;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			FkxpFYhjXao = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && fyspFMHCYMl != null)
			{
				fyspFMHCYMl.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void dZppNZsHeNE()
	{
		fyspFMHCYMl = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmRelatorio_PlaquetasDWG));
		GroupBox2 = new GroupBox();
		RB_Customizada = new RadioButton();
		RB_CBA = new RadioButton();
		RB_ABC = new RadioButton();
		TBAlturaDoBloco = new TextBox();
		TBDisteEntreColunas = new TextBox();
		CBFonte = new ComboBox();
		CBColunas = new ComboBox();
		tbFonteBloco = new TextBox();
		LBAlturaDoBloco = new Label();
		LabelTamanhoFonte = new Label();
		LabelQuantColunas = new Label();
		LabelStiloLinha = new Label();
		LBDistanciaEntreColunas = new Label();
		TBAlturaInicialRelatorio = new TextBox();
		LabelDistanciaDaRegua = new Label();
		LabelLinhas = new Label();
		btCorBloco = new Button();
		btExporta = new Button();
		btApagar = new Button();
		btCorTextoBloco = new Button();
		LabelCorTexto = new Label();
		FDqpBiUmZij(new ToolTip(fyspFMHCYMl));
		btEletronorte = new Button();
		btEletron = new Button();
		GroupBox1 = new GroupBox();
		btEletrosul = new Button();
		GroupBox3 = new GroupBox();
		bt1 = new Button();
		TBNome = new TextBox();
		bt2 = new Button();
		btSet = new Button();
		bt3 = new Button();
		bt5 = new Button();
		bt4 = new Button();
		btCHESF = new Button();
		btCTEEP = new Button();
		blOrdemSel = new Label();
		GroupBox2.SuspendLayout();
		GroupBox1.SuspendLayout();
		GroupBox3.SuspendLayout();
		SuspendLayout();
		GroupBox2.Controls.Add(RB_Customizada);
		GroupBox2.Controls.Add(RB_CBA);
		GroupBox2.Controls.Add(RB_ABC);
		GroupBox2.Controls.Add(TBAlturaDoBloco);
		GroupBox2.Controls.Add(TBDisteEntreColunas);
		GroupBox2.Controls.Add(CBFonte);
		GroupBox2.Controls.Add(CBColunas);
		GroupBox2.Controls.Add(tbFonteBloco);
		GroupBox2.Controls.Add(LBAlturaDoBloco);
		GroupBox2.Controls.Add(LabelTamanhoFonte);
		GroupBox2.Controls.Add(LabelQuantColunas);
		GroupBox2.Controls.Add(LabelStiloLinha);
		GroupBox2.Controls.Add(LBDistanciaEntreColunas);
		GroupBox2.Location = new Point(8, 45);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(238, 175);
		GroupBox2.TabIndex = 98;
		GroupBox2.TabStop = false;
		RB_Customizada.AutoSize = true;
		RB_Customizada.Location = new Point(7, 176);
		RB_Customizada.Name = "RB_Customizada";
		RB_Customizada.Size = new Size(119, 17);
		RB_Customizada.TabIndex = 72;
		RB_Customizada.TabStop = true;
		RB_Customizada.Text = "Ordem Customizada";
		RB_Customizada.UseVisualStyleBackColor = true;
		RB_CBA.AutoSize = true;
		RB_CBA.Location = new Point(7, 156);
		RB_CBA.Name = "RB_CBA";
		RB_CBA.Size = new Size(79, 17);
		RB_CBA.TabIndex = 71;
		RB_CBA.TabStop = true;
		RB_CBA.Text = "Ordem B, A";
		RB_CBA.UseVisualStyleBackColor = true;
		RB_ABC.AutoSize = true;
		RB_ABC.Location = new Point(7, 136);
		RB_ABC.Name = "RB_ABC";
		RB_ABC.Size = new Size(79, 17);
		RB_ABC.TabIndex = 71;
		RB_ABC.TabStop = true;
		RB_ABC.Text = "Ordem A, B";
		RB_ABC.UseVisualStyleBackColor = true;
		TBAlturaDoBloco.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBAlturaDoBloco.Location = new Point(177, 87);
		TBAlturaDoBloco.Name = "TBAlturaDoBloco";
		TBAlturaDoBloco.Size = new Size(52, 20);
		TBAlturaDoBloco.TabIndex = 69;
		TBAlturaDoBloco.TextAlign = HorizontalAlignment.Center;
		TBDisteEntreColunas.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBDisteEntreColunas.Location = new Point(177, 64);
		TBDisteEntreColunas.Name = "TBDisteEntreColunas";
		TBDisteEntreColunas.Size = new Size(52, 20);
		TBDisteEntreColunas.TabIndex = 64;
		TBDisteEntreColunas.TextAlign = HorizontalAlignment.Center;
		CBFonte.FormattingEnabled = true;
		CBFonte.Location = new Point(93, 110);
		CBFonte.Name = "CBFonte";
		CBFonte.Size = new Size(135, 21);
		CBFonte.TabIndex = 0;
		CBColunas.FormattingEnabled = true;
		CBColunas.Location = new Point(177, 39);
		CBColunas.Name = "CBColunas";
		CBColunas.Size = new Size(52, 21);
		CBColunas.TabIndex = 52;
		tbFonteBloco.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbFonteBloco.Location = new Point(177, 16);
		tbFonteBloco.Name = "tbFonteBloco";
		tbFonteBloco.Size = new Size(52, 20);
		tbFonteBloco.TabIndex = 27;
		tbFonteBloco.TextAlign = HorizontalAlignment.Center;
		LBAlturaDoBloco.Location = new Point(7, 86);
		LBAlturaDoBloco.Name = "LBAlturaDoBloco";
		LBAlturaDoBloco.Size = new Size(162, 25);
		LBAlturaDoBloco.TabIndex = 70;
		LBAlturaDoBloco.Text = "Altura do Bloco";
		LBAlturaDoBloco.TextAlign = ContentAlignment.MiddleLeft;
		LabelTamanhoFonte.Location = new Point(7, 16);
		LabelTamanhoFonte.Name = "LabelTamanhoFonte";
		LabelTamanhoFonte.Size = new Size(162, 25);
		LabelTamanhoFonte.TabIndex = 36;
		LabelTamanhoFonte.Text = "Tamanho do Fonte";
		LabelTamanhoFonte.TextAlign = ContentAlignment.MiddleLeft;
		LabelQuantColunas.Location = new Point(8, 39);
		LabelQuantColunas.Name = "LabelQuantColunas";
		LabelQuantColunas.Size = new Size(130, 25);
		LabelQuantColunas.TabIndex = 45;
		LabelQuantColunas.Text = "Quantidede de Colunas";
		LabelQuantColunas.TextAlign = ContentAlignment.MiddleLeft;
		LabelStiloLinha.Location = new Point(8, 109);
		LabelStiloLinha.Name = "LabelStiloLinha";
		LabelStiloLinha.Size = new Size(79, 23);
		LabelStiloLinha.TabIndex = 49;
		LabelStiloLinha.Text = "Fonte";
		LabelStiloLinha.TextAlign = ContentAlignment.MiddleLeft;
		LBDistanciaEntreColunas.Location = new Point(8, 63);
		LBDistanciaEntreColunas.Name = "LBDistanciaEntreColunas";
		LBDistanciaEntreColunas.Size = new Size(161, 25);
		LBDistanciaEntreColunas.TabIndex = 65;
		LBDistanciaEntreColunas.Text = "Distância entre Colunas";
		LBDistanciaEntreColunas.TextAlign = ContentAlignment.MiddleLeft;
		TBAlturaInicialRelatorio.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBAlturaInicialRelatorio.Location = new Point(182, 77);
		TBAlturaInicialRelatorio.Name = "TBAlturaInicialRelatorio";
		TBAlturaInicialRelatorio.Size = new Size(47, 20);
		TBAlturaInicialRelatorio.TabIndex = 67;
		TBAlturaInicialRelatorio.TextAlign = HorizontalAlignment.Center;
		LabelDistanciaDaRegua.Location = new Point(7, 77);
		LabelDistanciaDaRegua.Name = "LabelDistanciaDaRegua";
		LabelDistanciaDaRegua.Size = new Size(162, 25);
		LabelDistanciaDaRegua.TabIndex = 68;
		LabelDistanciaDaRegua.Text = "Distância da Régua Horizontal";
		LabelDistanciaDaRegua.TextAlign = ContentAlignment.MiddleLeft;
		LabelLinhas.ImageAlign = ContentAlignment.TopLeft;
		LabelLinhas.Location = new Point(7, 16);
		LabelLinhas.Name = "LabelLinhas";
		LabelLinhas.Size = new Size(143, 25);
		LabelLinhas.TabIndex = 95;
		LabelLinhas.Text = "Linhas";
		LabelLinhas.TextAlign = ContentAlignment.MiddleLeft;
		btCorBloco.BackColor = SystemColors.ActiveCaption;
		btCorBloco.Location = new Point(182, 14);
		btCorBloco.Name = "btCorBloco";
		btCorBloco.Size = new Size(47, 25);
		btCorBloco.TabIndex = 0;
		btCorBloco.UseVisualStyleBackColor = false;
		btExporta.FlatStyle = FlatStyle.Flat;
		btExporta.ForeColor = SystemColors.Control;
		btExporta.Image = (Image)componentResourceManager.GetObject("btExporta.Image");
		btExporta.Location = new Point(440, 204);
		btExporta.Name = "btExporta";
		btExporta.Size = new Size(40, 42);
		btExporta.TabIndex = 39;
		btExporta.UseVisualStyleBackColor = true;
		btApagar.FlatStyle = FlatStyle.Flat;
		btApagar.ForeColor = SystemColors.Control;
		btApagar.Image = Resources.Delete_32;
		btApagar.Location = new Point(440, 162);
		btApagar.Name = "btApagar";
		btApagar.Size = new Size(40, 42);
		btApagar.TabIndex = 41;
		btApagar.Tag = "";
		btApagar.UseVisualStyleBackColor = true;
		btCorTextoBloco.BackColor = SystemColors.ActiveCaption;
		btCorTextoBloco.Location = new Point(182, 44);
		btCorTextoBloco.Name = "btCorTextoBloco";
		btCorTextoBloco.Size = new Size(47, 25);
		btCorTextoBloco.TabIndex = 1;
		btCorTextoBloco.UseVisualStyleBackColor = false;
		LabelCorTexto.ImageAlign = ContentAlignment.TopLeft;
		LabelCorTexto.Location = new Point(6, 44);
		LabelCorTexto.Name = "LabelCorTexto";
		LabelCorTexto.Size = new Size(143, 25);
		LabelCorTexto.TabIndex = 38;
		LabelCorTexto.Text = "Textos";
		LabelCorTexto.TextAlign = ContentAlignment.MiddleLeft;
		btEletronorte.FlatStyle = FlatStyle.Flat;
		btEletronorte.Font = new Font("Trebuchet MS", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		btEletronorte.ForeColor = Color.DarkBlue;
		btEletronorte.Location = new Point(106, 12);
		btEletronorte.Name = "btEletronorte";
		btEletronorte.Size = new Size(97, 27);
		btEletronorte.TabIndex = 100;
		btEletronorte.Text = "Eletronorte";
		btEletronorte.UseVisualStyleBackColor = true;
		btEletron.FlatStyle = FlatStyle.Flat;
		btEletron.Image = Resources.eletron;
		btEletron.Location = new Point(8, 12);
		btEletron.Name = "btEletron";
		btEletron.Size = new Size(97, 27);
		btEletron.TabIndex = 101;
		btEletron.UseVisualStyleBackColor = true;
		GroupBox1.Controls.Add(LabelLinhas);
		GroupBox1.Controls.Add(btCorBloco);
		GroupBox1.Controls.Add(TBAlturaInicialRelatorio);
		GroupBox1.Controls.Add(LabelCorTexto);
		GroupBox1.Controls.Add(LabelDistanciaDaRegua);
		GroupBox1.Controls.Add(btCorTextoBloco);
		GroupBox1.Location = new Point(252, 45);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(241, 111);
		GroupBox1.TabIndex = 102;
		GroupBox1.TabStop = false;
		btEletrosul.FlatStyle = FlatStyle.Flat;
		btEletrosul.Font = new Font("Trebuchet MS", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		btEletrosul.ForeColor = Color.DarkBlue;
		btEletrosul.Location = new Point(204, 12);
		btEletrosul.Name = "btEletrosul";
		btEletrosul.Size = new Size(97, 27);
		btEletrosul.TabIndex = 104;
		btEletrosul.Text = "Eletrosul";
		btEletrosul.UseVisualStyleBackColor = true;
		GroupBox3.Controls.Add(bt1);
		GroupBox3.Controls.Add(TBNome);
		GroupBox3.Controls.Add(bt2);
		GroupBox3.Controls.Add(btSet);
		GroupBox3.Controls.Add(bt3);
		GroupBox3.Controls.Add(bt5);
		GroupBox3.Controls.Add(bt4);
		GroupBox3.Location = new Point(252, 170);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(175, 79);
		GroupBox3.TabIndex = 105;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "GroupBox3";
		bt1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt1.Location = new Point(9, 46);
		bt1.Name = "bt1";
		bt1.Size = new Size(25, 20);
		bt1.TabIndex = 84;
		bt1.Text = "1";
		bt1.UseVisualStyleBackColor = true;
		TBNome.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBNome.Location = new Point(9, 20);
		TBNome.Name = "TBNome";
		TBNome.Size = new Size(104, 20);
		TBNome.TabIndex = 90;
		TBNome.TextAlign = HorizontalAlignment.Center;
		bt2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt2.Location = new Point(40, 46);
		bt2.Name = "bt2";
		bt2.Size = new Size(25, 20);
		bt2.TabIndex = 85;
		bt2.Text = "2";
		bt2.UseVisualStyleBackColor = true;
		btSet.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		btSet.Location = new Point(119, 19);
		btSet.Name = "btSet";
		btSet.Size = new Size(40, 20);
		btSet.TabIndex = 89;
		btSet.Text = "SET";
		btSet.UseVisualStyleBackColor = true;
		bt3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt3.Location = new Point(71, 46);
		bt3.Name = "bt3";
		bt3.Size = new Size(25, 20);
		bt3.TabIndex = 86;
		bt3.Text = "3";
		bt3.UseVisualStyleBackColor = true;
		bt5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt5.Location = new Point(134, 46);
		bt5.Name = "bt5";
		bt5.Size = new Size(25, 20);
		bt5.TabIndex = 88;
		bt5.Text = "5";
		bt5.UseVisualStyleBackColor = true;
		bt4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt4.Location = new Point(103, 46);
		bt4.Name = "bt4";
		bt4.Size = new Size(25, 20);
		bt4.TabIndex = 87;
		bt4.Text = "4";
		bt4.UseVisualStyleBackColor = true;
		btCHESF.FlatStyle = FlatStyle.Flat;
		btCHESF.Font = new Font("Trebuchet MS", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		btCHESF.ForeColor = Color.DarkBlue;
		btCHESF.Location = new Point(302, 12);
		btCHESF.Name = "btCHESF";
		btCHESF.Size = new Size(97, 27);
		btCHESF.TabIndex = 106;
		btCHESF.Text = "Chesf";
		btCHESF.UseVisualStyleBackColor = true;
		btCTEEP.FlatStyle = FlatStyle.Flat;
		btCTEEP.Font = new Font("Trebuchet MS", 11.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		btCTEEP.ForeColor = Color.DarkBlue;
		btCTEEP.Location = new Point(400, 12);
		btCTEEP.Name = "btCTEEP";
		btCTEEP.Size = new Size(97, 27);
		btCTEEP.TabIndex = 107;
		btCTEEP.Text = "CTEEP";
		btCTEEP.UseVisualStyleBackColor = true;
		blOrdemSel.ImageAlign = ContentAlignment.TopLeft;
		blOrdemSel.Location = new Point(8, 224);
		blOrdemSel.Name = "blOrdemSel";
		blOrdemSel.Size = new Size(238, 25);
		blOrdemSel.TabIndex = 108;
		blOrdemSel.Text = "Textos";
		blOrdemSel.TextAlign = ContentAlignment.MiddleLeft;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(501, 255);
		Controls.Add(blOrdemSel);
		Controls.Add(btCTEEP);
		Controls.Add(btCHESF);
		Controls.Add(GroupBox3);
		Controls.Add(btEletrosul);
		Controls.Add(GroupBox1);
		Controls.Add(btEletronorte);
		Controls.Add(btEletron);
		Controls.Add(GroupBox2);
		Controls.Add(btExporta);
		Controls.Add(btApagar);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "frmRelatorio_PlaquetasDWG";
		ShowInTaskbar = false;
		Text = "Plaquetas";
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox3.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return sp6pF0N4FNE;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		sp6pF0N4FNE = WithEventsValue;
	}

	public frmRelatorio_PlaquetasDWG(DeclaracoesFiacao.structureRelPlaquetas[] mPlaquetas, string sTipoRel, int iPnSel)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Obj, but got Unknown
		tSQpF9Uku8V = 0;
		TRbpFziHugr = "E";
		GwKpQTajqFQ = new ColorDialog();
		qfppQJoJ8ok = 6;
		e1epQhiV78J = 4;
		o6wpQoejjlY = 0.0;
		wUgpQGHn0ML = 10.0;
		a7ZpQHDcoay = "";
		Ev7pQk60JvX = "PLAQ_" + TRbpFziHugr;
		dZppNZsHeNE();
		DeclaracoesGeral.Reguas RH = default;
		checked
		{
			if (XDataGeral.LeXDataReguaH(ref RH))
			{
				tSQpF9Uku8V = iPnSel;
				EgrpFrd5siQ = mPlaquetas;
				EgrpFrd5siQ[0].Indice = DeclaracoesGeral.mMensagem[1, 1154].ToString().ToUpper();
				EgrpFrd5siQ[0].Nome = DeclaracoesGeral.mMensagem[1, 176].ToString().ToUpper();
				EgrpFrd5siQ[0].Modelo = DeclaracoesGeral.mMensagem[1, 654].ToString().ToUpper();
				EgrpFrd5siQ[0].Quant = DeclaracoesGeral.mMensagem[1, 797].ToString().ToUpper();
				EgrpFrd5siQ[0].Desc1 = DeclaracoesGeral.mMensagem[1, 64].ToString().ToUpper();
				EgrpFrd5siQ[0].Desc2 = DeclaracoesGeral.mMensagem[1, 64].ToString().ToUpper();
				EgrpFrd5siQ[0].Desc3 = DeclaracoesGeral.mMensagem[1, 64].ToString().ToUpper();
				EgrpFrd5siQ[0].Painel = DeclaracoesGeral.mMensagem[1, 1081].ToString().ToUpper();
				int num = Information.UBound(EgrpFrd5siQ);
				for (int i = 1; i <= num; i++)
				{
					if (Operators.CompareString(EgrpFrd5siQ[i].Indice, null, TextCompare: true) == 0)
					{
						EgrpFrd5siQ[i].Indice = "0";
					}
					if (Operators.CompareString(EgrpFrd5siQ[i].Nome, null, TextCompare: true) == 0)
					{
						EgrpFrd5siQ[i].Nome = "##B##";
					}
					if (Operators.CompareString(EgrpFrd5siQ[i].Modelo, null, TextCompare: true) == 0)
					{
						EgrpFrd5siQ[i].Modelo = "##B##";
					}
					if (Operators.CompareString(EgrpFrd5siQ[i].Quant, null, TextCompare: true) == 0)
					{
						EgrpFrd5siQ[i].Quant = "1";
					}
					if (Operators.CompareString(EgrpFrd5siQ[i].Desc1, null, TextCompare: true) == 0)
					{
						EgrpFrd5siQ[i].Desc1 = "##B##";
					}
					if (Operators.CompareString(EgrpFrd5siQ[i].Desc2, null, TextCompare: true) == 0)
					{
						EgrpFrd5siQ[i].Desc2 = "##B##";
					}
					if (Operators.CompareString(EgrpFrd5siQ[i].Desc3, null, TextCompare: true) == 0)
					{
						EgrpFrd5siQ[i].Desc3 = "##B##";
					}
					if (Operators.CompareString(EgrpFrd5siQ[i].Painel, null, TextCompare: true) == 0)
					{
						EgrpFrd5siQ[i].Painel = "##B##";
					}
					if (EgrpFrd5siQ[i].Desc1.Contains("|"))
					{
						string[] array = EgrpFrd5siQ[i].Desc1.Split('|');
						EgrpFrd5siQ[i].Desc1 = array[0] + "\r\n" + array[1];
					}
					if (EgrpFrd5siQ[i].Desc2.Contains("|"))
					{
						string[] array2 = EgrpFrd5siQ[i].Desc2.Split('|');
						EgrpFrd5siQ[i].Desc2 = array2[0] + "\r\n" + array2[1];
					}
					if (EgrpFrd5siQ[i].Desc3.Contains("|"))
					{
						string[] array3 = EgrpFrd5siQ[i].Desc3.Split('|');
						EgrpFrd5siQ[i].Desc3 = array3[0] + "\r\n" + array3[1];
					}
				}
				Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 589], " : "), Dicionario.BuscaNomeDoPainel(iPnSel)));
				GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 501]);
				GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 382]);
				LabelTamanhoFonte.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 339]);
				LabelLinhas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 340]);
				LabelCorTexto.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 341]);
				LabelQuantColunas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 342]);
				LabelStiloLinha.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 343]);
				LBAlturaDoBloco.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 344]);
				LBDistanciaEntreColunas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 345]);
				LabelDistanciaDaRegua.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 350]);
				w8dpBZ0kvSD().SetToolTip(btExporta, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 599], " "), DeclaracoesGeral.mMensagem[1, 582])));
				w8dpBZ0kvSD().SetToolTip(btApagar, Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 38], " "), DeclaracoesGeral.mMensagem[1, 582])));
				RB_ABC.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1082], " "), DeclaracoesGeral.mMensagem[1, 1474]));
				RB_CBA.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1082], " "), DeclaracoesGeral.mMensagem[1, 1475]));
				blOrdemSel.Text = "Ex: C; B; A; 3; 2; 1";
				RB_Customizada.Visible = false;
				RB_Customizada.Enabled = false;
				RB_Customizada.Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1733], " 5; 2; ESPECIAL; 00"));
				a7ZpQHDcoay = "5;2;ESPECIAL;00";
				Application.ShowModelessDialog((Form)this);
				btEletron.Focus();
				gJ9pNicC6XH();
				Eletron();
				double num2 = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta;
				e1epQhiV78J = (int)Conversion.Int(num2 / 90.0);
				o6wpQoejjlY = RH.Pti.Y - RH.AltBase;
				double num3 = o6wpQoejjlY - wUgpQGHn0ML - Conversions.ToDouble(TBAlturaInicialRelatorio.Text);
				num3 /= 35.0;
				qfppQJoJ8ok = (int)Conversion.Int(num3);
				if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
				{
					Left = 0;
				}
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 611]), MsgBoxStyle.Information);
			}
		}
	}

	private void gJ9pNicC6XH()
	{
		tbFonteBloco.Text = "2";
		CBColunas.Items.Clear();
		CBColunas.Items.Add("1");
		CBColunas.Items.Add("2");
		CBColunas.Items.Add("3");
		CBColunas.Items.Add("4");
		CBColunas.Items.Add("5");
		CBColunas.Text = "2";
		string[] array = new string[1];
		TBAlturaInicialRelatorio.Text = "25";
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
		TBDisteEntreColunas.Text = Conversions.ToString(6);
		TBAlturaDoBloco.Text = Conversions.ToString(7);
		Color val = Color.FromColorIndex((ColorMethod)194, (short)7);
		btCorBloco.BackColor = val.ColorValue;
		val = Color.FromColorIndex((ColorMethod)194, (short)7);
		btCorTextoBloco.BackColor = val.ColorValue;
		s7qpQp2qLtm.CorLinha = 7;
		s7qpQp2qLtm.CorTexto = 7;
	}

	private void CnwpNSBQIsh(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = GwKpQTajqFQ.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			s7qpQp2qLtm.CorLinha = GwKpQTajqFQ.Color.ColorIndex;
			btCorBloco.BackColor = GwKpQTajqFQ.Color.ColorValue;
		}
	}

	private void OP7pN4XtIWo(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = GwKpQTajqFQ.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			s7qpQp2qLtm.CorTexto = GwKpQTajqFQ.Color.ColorIndex;
			btCorTextoBloco.BackColor = GwKpQTajqFQ.Color.ColorValue;
		}
	}

	private short wHEpNCtTcvf()
	{
		DialogResult dialogResult = GwKpQTajqFQ.ShowDialog();
		if (dialogResult != DialogResult.OK)
		{
			return 7;
		}
		return GwKpQTajqFQ.Color.ColorIndex;
	}

	private void nTgpNYii8Ga(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void JRepNrDZr7U(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void E87pN91xdYV(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void wJupNz5okYw(object P_0, EventArgs P_1)
	{
		blOrdemSel.Text = "";
		RB_ABC.Checked = true;
		RB_Customizada.Checked = false;
		RB_ABC.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1082], " "), DeclaracoesGeral.mMensagem[1, 1474]));
		RB_CBA.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1082], " "), DeclaracoesGeral.mMensagem[1, 1475]));
		blOrdemSel.Text = "Ex: C; B; A; 3; 2; 1";
		gJ9pNicC6XH();
		Eletron();
		jO0pFbR0hCA();
	}

	private void obFpFWCGnpF(object P_0, EventArgs P_1)
	{
		TRbpFziHugr = "N";
		blOrdemSel.Text = "";
		RB_ABC.Checked = false;
		RB_CBA.Checked = true;
		RB_Customizada.Checked = false;
		RB_CBA.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1082], " "), DeclaracoesGeral.mMensagem[1, 1475]));
		gJ9pNicC6XH();
		GvYpFvQsTtD();
		Eletronorte();
		jO0pFbR0hCA();
	}

	private void X0VpFpAh5KS(object P_0, EventArgs P_1)
	{
		blOrdemSel.Text = "";
		RB_ABC.Checked = false;
		RB_CBA.Checked = true;
		RB_Customizada.Checked = false;
		RB_CBA.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1082], " "), DeclaracoesGeral.mMensagem[1, 1475]));
		gJ9pNicC6XH();
		Eletrosul();
		jO0pFbR0hCA();
		blOrdemSel.Text = "Ex: D; D1; A; A1; B; B1; C; C1; E; ... ";
	}

	private void BQ6pFT8Uq5m(object P_0, EventArgs P_1)
	{
		TRbpFziHugr = "C";
		blOrdemSel.Text = "";
		RB_ABC.Checked = true;
		RB_CBA.Checked = false;
		RB_Customizada.Checked = false;
		gJ9pNicC6XH();
		GvYpFvQsTtD();
		Eletronorte();
		jO0pFbR0hCA();
	}

	private void p9KpFJEdD4H(object P_0, EventArgs P_1)
	{
		TRbpFziHugr = "Z";
		blOrdemSel.Text = "";
		RB_Customizada.Checked = true;
		RB_ABC.Checked = false;
		RB_CBA.Checked = false;
		a7ZpQHDcoay = "5;2;ESPECIAL;00";
		GroupBox2.Enabled = false;
		GvYpFvQsTtD();
		jO0pFbR0hCA();
	}

	private void xHGpFho96Wr(object P_0, EventArgs P_1)
	{
		int corLinha = s7qpQp2qLtm.CorLinha;
		int corTexto = s7qpQp2qLtm.CorTexto;
		string text = "ABC";
		if (RB_CBA.Checked)
		{
			text = "CBA";
		}
		checked
		{
			if (!((Operators.CompareString(TRbpFziHugr, "N", TextCompare: true) == 0) | (Operators.CompareString(TRbpFziHugr, "C", TextCompare: true) == 0)))
			{
				if (Operators.CompareString(TRbpFziHugr, "S", TextCompare: true) != 0)
				{
					if (Operators.CompareString(TRbpFziHugr, "E", TextCompare: true) != 0)
					{
						if (Operators.CompareString(TRbpFziHugr, "Z", TextCompare: true) == 0)
						{
							DeclaracoesGeral.bPararRelatorio = false;
							s7qpQp2qLtm.TamanhoFonte = Conversions.ToDouble(tbFonteBloco.Text);
							s7qpQp2qLtm.QuantColunas = (short)Conversions.ToInteger(CBColunas.Text);
							s7qpQp2qLtm.AlturaInicial = Conversions.ToDouble(TBAlturaInicialRelatorio.Text);
							s7qpQp2qLtm.sFonte = CBFonte.Text;
							s7qpQp2qLtm.DistEntreColunas = Conversions.ToDouble(TBDisteEntreColunas.Text);
							s7qpQp2qLtm.AlturaDoBloco = Conversions.ToDouble(TBAlturaDoBloco.Text);
							DeclaracoesGeral.bPararRelatorio = false;
							Relatorios_PlaquetasDWG.ordenaPlaquetasCustomizadas(ref EgrpFrd5siQ, a7ZpQHDcoay);
							Relatorios_PlaquetasELN_DWG.CriaMatrizPlaquetasCTEEP(EgrpFrd5siQ, tSQpF9Uku8V, corLinha, corTexto, qfppQJoJ8ok, e1epQhiV78J, Conversions.ToDouble(TBAlturaInicialRelatorio.Text), bAdicionaVazias: false);
						}
						return;
					}
					DeclaracoesGeral.bPararRelatorio = false;
					s7qpQp2qLtm.TamanhoFonte = Conversions.ToDouble(tbFonteBloco.Text);
					s7qpQp2qLtm.QuantColunas = (short)Conversions.ToInteger(CBColunas.Text);
					s7qpQp2qLtm.AlturaInicial = Conversions.ToDouble(TBAlturaInicialRelatorio.Text);
					s7qpQp2qLtm.sFonte = CBFonte.Text;
					s7qpQp2qLtm.DistEntreColunas = Conversions.ToDouble(TBDisteEntreColunas.Text);
					s7qpQp2qLtm.AlturaDoBloco = Conversions.ToDouble(TBAlturaDoBloco.Text);
					DeclaracoesGeral.bPararRelatorio = false;
					EgrpFrd5siQ[0].Indice = DeclaracoesGeral.mMensagem[1, 1154].ToString().ToUpper();
					EgrpFrd5siQ[0].Quant = DeclaracoesGeral.mMensagem[1, 797].ToString().ToUpper();
					Relatorios_PlaquetasDWG.ordenaPlaquetasEletroNorte(ref EgrpFrd5siQ, text);
					if (s7qpQp2qLtm.QuantColunas > 2)
					{
						EgrpFrd5siQ[0].Quant = DeclaracoesGeral.mMensagem[1, 1218].ToString().ToUpper();
					}
					if (s7qpQp2qLtm.QuantColunas > 4)
					{
						EgrpFrd5siQ[0].Indice = "#";
					}
					Relatorios_PlaquetasDWG.CriaMatrizPlaquetas(EgrpFrd5siQ, s7qpQp2qLtm, tSQpF9Uku8V);
				}
				else
				{
					double num = o6wpQoejjlY - wUgpQGHn0ML - Conversions.ToDouble(TBAlturaInicialRelatorio.Text);
					num /= 35.0;
					qfppQJoJ8ok = (int)Conversion.Int(num);
					DeclaracoesGeral.bPararRelatorio = false;
					Relatorios_PlaquetasDWG.ordenaPlaquetasEletroSul(ref EgrpFrd5siQ, text);
					Relatorios_PlaquetasELN_DWG.CriaMatrizPlaquetasELN(EgrpFrd5siQ, tSQpF9Uku8V, corLinha, corTexto, qfppQJoJ8ok, e1epQhiV78J, Conversions.ToDouble(TBAlturaInicialRelatorio.Text));
				}
			}
			else
			{
				DeclaracoesGeral.bPararRelatorio = false;
				double num2 = o6wpQoejjlY - wUgpQGHn0ML - Conversions.ToDouble(TBAlturaInicialRelatorio.Text);
				num2 /= 35.0;
				qfppQJoJ8ok = (int)Conversion.Int(num2);
				Relatorios_PlaquetasDWG.ordenaPlaquetasEletroNorte(ref EgrpFrd5siQ, text);
				Relatorios_PlaquetasELN_DWG.CriaMatrizPlaquetasELN(EgrpFrd5siQ, tSQpF9Uku8V, corLinha, corTexto, qfppQJoJ8ok, e1epQhiV78J, Conversions.ToDouble(TBAlturaInicialRelatorio.Text));
			}
		}
	}

	private void AUFpFoBxSQM(object P_0, EventArgs P_1)
	{
		Relatorios_PlaquetasDWG.ApagaRelatorioDeplaquetas(tSQpF9Uku8V);
	}

	private void Eletron()
	{
		TRbpFziHugr = "E";
		RB_ABC.Checked = true;
		RB_Customizada.Checked = false;
		GvYpFvQsTtD();
		GroupBox2.Enabled = true;
	}

	private void Eletronorte()
	{
		double num = o6wpQoejjlY - wUgpQGHn0ML - Conversions.ToDouble(TBAlturaInicialRelatorio.Text);
		num /= 35.0;
		qfppQJoJ8ok = checked((int)Conversion.Int(num));
		GroupBox2.Enabled = false;
	}

	private void Eletrosul()
	{
		TRbpFziHugr = "S";
		GvYpFvQsTtD();
		double num = o6wpQoejjlY - wUgpQGHn0ML - Conversions.ToDouble(TBAlturaInicialRelatorio.Text);
		num /= 35.0;
		qfppQJoJ8ok = checked((int)Conversion.Int(num));
		Ev7pQk60JvX = "PLAQ_" + TRbpFziHugr;
		GvYpFvQsTtD();
		GroupBox2.Enabled = false;
	}

	private void TqVpFGY6WaY(object P_0, EventArgs P_1)
	{
		if (LX9pQWkg4oj)
		{
			LX9pQWkg4oj = false;
			GvYpFvQsTtD();
			return;
		}
		LX9pQWkg4oj = true;
		bt1.Enabled = true;
		bt2.Enabled = true;
		bt3.Enabled = true;
		bt4.Enabled = true;
		bt5.Enabled = true;
	}

	private void TmcpFHmMORU(object P_0, EventArgs P_1)
	{
		if (LX9pQWkg4oj)
		{
			g8ZpFjN1Gaq(1);
			LX9pQWkg4oj = false;
			bt1.Enabled = true;
		}
		else
		{
			TBNome.Text = "";
			V8wpF6fEmLF(1);
		}
	}

	private void IwJpFkNoeTc(object P_0, EventArgs P_1)
	{
		if (LX9pQWkg4oj)
		{
			g8ZpFjN1Gaq(2);
			LX9pQWkg4oj = false;
			bt2.Enabled = true;
		}
		else
		{
			TBNome.Text = "";
			V8wpF6fEmLF(2);
		}
	}

	private void xmDpFdUVbHP(object P_0, EventArgs P_1)
	{
		if (LX9pQWkg4oj)
		{
			g8ZpFjN1Gaq(3);
			LX9pQWkg4oj = false;
			bt3.Enabled = true;
		}
		else
		{
			TBNome.Text = "";
			V8wpF6fEmLF(3);
		}
	}

	private void C1spFfYO9Fc(object P_0, EventArgs P_1)
	{
		if (LX9pQWkg4oj)
		{
			g8ZpFjN1Gaq(4);
			LX9pQWkg4oj = false;
			bt4.Enabled = true;
		}
		else
		{
			TBNome.Text = "";
			V8wpF6fEmLF(4);
		}
	}

	private void hPypFDdTRS2(object P_0, EventArgs P_1)
	{
		if (LX9pQWkg4oj)
		{
			g8ZpFjN1Gaq(5);
			LX9pQWkg4oj = false;
			bt5.Enabled = true;
		}
		else
		{
			TBNome.Text = "";
			V8wpF6fEmLF(5);
		}
	}

	private void GvYpFvQsTtD()
	{
		TBNome.Text = "";
		Ev7pQk60JvX = "PLAQ_" + TRbpFziHugr;
		bt1.Enabled = false;
		bt2.Enabled = false;
		bt3.Enabled = false;
		bt4.Enabled = false;
		bt5.Enabled = false;
		checked
		{
			if (!((Operators.CompareString(DeclaracoesGeral.Conf.DirProjeto.Trim(), "", TextCompare: true) == 0) | !File.Exists(DeclaracoesGeral.Conf.DirProjeto)))
			{
				GroupBox1.Enabled = true;
				cDadosAccessComum cDadosAccessComum2 = new cDadosAccessComum();
				try
				{
					DataTable dataTable = cDadosAccessComum2.LeConfiguracaoRelatorio("F", Ev7pQk60JvX);
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
			GroupBox1.Enabled = false;
		}
	}

	private void V8wpF6fEmLF(int P_0)
	{
		if (!clsAuxiliar.BancoValido())
		{
			return;
		}
		string sComando = "";
		cDadosAccessComum cDadosAccessComum2 = new cDadosAccessComum();
		try
		{
			cDadosAccessComum2.LeConfiguracao(ref sComando, P_0, "F", Ev7pQk60JvX);
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
		int num = 1;
		object obj = array;
		XhcpFtNvTMO(ref obj, sComando);
		array = (object[])obj;
		TBNome.Text = Conversions.ToString(array[1]);
		num = 2;
		Color val = Color.FromColorIndex((ColorMethod)194, Conversions.ToShort(array[2]));
		btCorBloco.BackColor = val.ColorValue;
		num = 3;
		s7qpQp2qLtm.CorLinha = val.ColorIndex;
		val = Color.FromColorIndex((ColorMethod)194, Conversions.ToShort(array[3]));
		btCorTextoBloco.BackColor = val.ColorValue;
		num = 4;
		s7qpQp2qLtm.CorTexto = val.ColorIndex;
		tbFonteBloco.Text = Conversions.ToString(array[4]);
		num = 5;
		CBColunas.Text = Conversions.ToString(array[5]);
		num = 6;
		TBDisteEntreColunas.Text = Conversions.ToString(array[6]);
		num = 7;
		TBAlturaDoBloco.Text = Conversions.ToString(array[7]);
		num = 8;
		CBFonte.Text = Conversions.ToString(array[8]);
		num = 9;
		TBAlturaInicialRelatorio.Text = Conversions.ToString(array[9]);
		num = 10;
		checked
		{
			if (Information.UBound(array) <= 9)
			{
				RB_ABC.Checked = true;
				RB_CBA.Checked = false;
			}
			else
			{
				RB_ABC.Checked = Conversions.ToBoolean(array[num]);
				num++;
				RB_CBA.Checked = Conversions.ToBoolean(array[num]);
				num++;
			}
			string tRbpFziHugr = TRbpFziHugr;
			if (Operators.CompareString(tRbpFziHugr, "C", TextCompare: true) != 0)
			{
				if (Operators.CompareString(tRbpFziHugr, "E", TextCompare: true) != 0)
				{
					if (Operators.CompareString(tRbpFziHugr, "s", TextCompare: true) != 0)
					{
						if (Operators.CompareString(tRbpFziHugr, "N", TextCompare: true) != 0)
						{
							if (Operators.CompareString(tRbpFziHugr, "Z", TextCompare: true) == 0)
							{
								btCTEEP.Focus();
							}
						}
						else
						{
							btEletronorte.Focus();
						}
					}
					else
					{
						btEletrosul.Focus();
					}
				}
				else
				{
					btEletron.Focus();
				}
			}
			else
			{
				btCHESF.Focus();
			}
		}
	}

	private void XhcpFtNvTMO(ref object P_0, string P_1)
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

	private void g8ZpFjN1Gaq(int P_0)
	{
		if (!clsAuxiliar.BancoValido())
		{
			return;
		}
		string text = "";
		text = TBNome.Text;
		text = text + ";" + Conversions.ToString((int)s7qpQp2qLtm.CorLinha);
		text = text + ";" + Conversions.ToString((int)s7qpQp2qLtm.CorTexto);
		text = text + ";" + tbFonteBloco.Text;
		text = text + ";" + CBColunas.Text;
		text = text + ";" + TBDisteEntreColunas.Text;
		text = text + ";" + TBAlturaDoBloco.Text;
		text = text + ";" + CBFonte.Text;
		text = text + ";" + TBAlturaInicialRelatorio.Text;
		text = text + ";" + Conversions.ToString(RB_ABC.Checked);
		text = text + ";" + Conversions.ToString(RB_CBA.Checked);
		cDadosAccessComum cDadosAccessComum2 = new cDadosAccessComum();
		try
		{
			cDadosAccessComum2.GravaConfiguracao(text, P_0, "F", Ev7pQk60JvX);
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
		GvYpFvQsTtD();
	}

	private void SbCpFLLqOK5(object P_0, EventArgs P_1)
	{
		jO0pFbR0hCA();
	}

	private void rflpFwm3JOK(object P_0, EventArgs P_1)
	{
		jO0pFbR0hCA();
	}

	private void XR7pFxmjHYl(object P_0, EventArgs P_1)
	{
		jO0pFbR0hCA();
	}

	private void jO0pFbR0hCA()
	{
		blOrdemSel.Text = "";
		if (RB_ABC.Checked)
		{
			blOrdemSel.Text = "Ex: 1; 2; 3; A; B; C; ...";
		}
		if (RB_CBA.Checked)
		{
			blOrdemSel.Text = "Ex: C; B; A; 3; 2; 1; ...";
		}
		if (RB_Customizada.Checked)
		{
			blOrdemSel.Text = "Ex: 5; 2; ESPECIAL; 00";
		}
	}
}
