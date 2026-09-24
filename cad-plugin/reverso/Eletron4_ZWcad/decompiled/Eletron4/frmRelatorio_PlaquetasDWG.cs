using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.Windows;
using zgryP3p0xulXcIZvObyh;

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
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Label LabelLinhas
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btCorBloco
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual TextBox TBAlturaDoBloco
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btExporta
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btApagar
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Label LBAlturaDoBloco
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btCorTextoBloco
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual TextBox TBAlturaInicialRelatorio
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Label LabelCorTexto
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Label LabelDistanciaDaRegua
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual TextBox TBDisteEntreColunas
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Label LabelTamanhoFonte
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual ComboBox CBFonte
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Label LabelQuantColunas
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual ComboBox CBColunas
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Label LabelStiloLinha
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual TextBox tbFonteBloco
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Label LBDistanciaEntreColunas
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btEletronorte
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btEletron
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btEletrosul
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual GroupBox GroupBox3
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button bt1
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual TextBox TBNome
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button bt2
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btSet
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button bt3
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button bt5
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button bt4
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btCHESF
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual RadioButton RB_CBA
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual RadioButton RB_ABC
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Button btCTEEP
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual RadioButton RB_Customizada
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	internal virtual Label blOrdemSel
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			return null;
		}
		[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[DebuggerStepThrough]
	private void dZppNZsHeNE()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.Synchronized | MethodImplOptions.NoInlining)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public frmRelatorio_PlaquetasDWG(DeclaracoesFiacao.structureRelPlaquetas[] mPlaquetas, string sTipoRel, int iPnSel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gJ9pNicC6XH()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CnwpNSBQIsh(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OP7pN4XtIWo(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private short wHEpNCtTcvf()
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void nTgpNYii8Ga(object P_0, KeyPressEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JRepNrDZr7U(object P_0, KeyPressEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void E87pN91xdYV(object P_0, KeyPressEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wJupNz5okYw(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void obFpFWCGnpF(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void X0VpFpAh5KS(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void BQ6pFT8Uq5m(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void p9KpFJEdD4H(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xHGpFho96Wr(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void AUFpFoBxSQM(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Eletron()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Eletronorte()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Eletrosul()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TqVpFGY6WaY(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TmcpFHmMORU(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void IwJpFkNoeTc(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void xmDpFdUVbHP(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void C1spFfYO9Fc(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hPypFDdTRS2(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void GvYpFvQsTtD()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void V8wpF6fEmLF(int P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XhcpFtNvTMO(ref object P_0, string P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void g8ZpFjN1Gaq(int P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SbCpFLLqOK5(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rflpFwm3JOK(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XR7pFxmjHYl(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jO0pFbR0hCA()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static frmRelatorio_PlaquetasDWG()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
