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

	internal virtual Button BTCancelar
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

	internal virtual GroupBox GroupBoxxxxxxxxxxxxxxxxxxx
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

	internal virtual Label LabelPainel
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[DebuggerStepThrough]
	private void xb9p7zh1NJ8()
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
	public frmRelatorio_JumpersDWG(DeclaracoesFiacao.structureRelPotencial[] mRelatPotenciais, string sTipoRel, int iPnSel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void wA0pqWTOKre(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ouXpqpqdB3e(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private short cakpqTE1TQC()
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gTJpqJpoqhq(object P_0, KeyPressEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void S07pqhmawYH(object P_0, KeyPressEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void V46pqoTWZQ4(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void jlIpqGf7jFA(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PAYpqHJfZhK(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void CRxpqkN6P2u(object P_0, KeyPressEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static frmRelatorio_JumpersDWG()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
