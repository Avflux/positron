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
public class frmRelatorio_MateriaisDWG : Form
{
	public struct ConfRelelatorio
	{
		public short CorLinha;

		public short CorTexto;

		public short CorDoJumper;

		public double TamanhoFonte;

		public short QuantColunas;

		public double AlturaInicial;

		public double DistEntreColunas;

		public double AlturaDoBloco;

		public string sFonte;

		public bool bConcatModelo;

		public bool bConcatFabricante;

		public bool bVisivelCli;
	}

	public struct Colunas
	{
		public string snome;

		public string iTamanhos;
	}

	private IContainer gDJp83pydc5;

	[AccessedThroughProperty("tbFonteBloco")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox Alap8nEAyGn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelCorTexto")]
	private Label YaUp81oStgQ;

	[AccessedThroughProperty("btCorTextoBloco")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button QgUp8lOEX3N;

	[AccessedThroughProperty("LabelTamanhoFonte")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label v1Tp859ewu3;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCorBloco")]
	[CompilerGenerated]
	private Button waNp80ZNZh2;

	[AccessedThroughProperty("LabelQuantColunas")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label ikIp8RaYsgy;

	[AccessedThroughProperty("LabelStiloLinha")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label jKgp8ma2IRq;

	[AccessedThroughProperty("CBFonte")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ComboBox eXop8XwI4HB;

	[AccessedThroughProperty("btExporta")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button vjup8U9xRIi;

	[AccessedThroughProperty("btApagar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button eHKp8y2cLEw;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBColunas")]
	private ComboBox zQap8gY7mTH;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBDistanciaEntreColunas")]
	[CompilerGenerated]
	private Label vopp8AH4f2a;

	[AccessedThroughProperty("TBDisteEntreColunas")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox Gakp8scZBKB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTCancelar")]
	private Button GAmp8BuOYI8;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBAlturaInicialRelatorio")]
	private TextBox Hg8p8Vq0Bpa;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelDistanciaDaRegua")]
	private Label KAip8uVsU4Z;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBAlturaDoBloco")]
	private TextBox EPAp8ES4oqI;

	[AccessedThroughProperty("LBAlturaDoBloco")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label oGep8ZbyFpI;

	[AccessedThroughProperty("GroupBox")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox Uplp8iDGgLj;

	[AccessedThroughProperty("LabelLinhas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label Oa4p8SF5l0G;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip znvp84IrCcY;

	[AccessedThroughProperty("tbNum7")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox p1pp8C6OO8x;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbNum6")]
	private TextBox DJAp8YJjIdS;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbNum5")]
	private TextBox i51p8r7PbcA;

	[CompilerGenerated]
	[AccessedThroughProperty("tbNum1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox KlFp89GWiNl;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbNum2")]
	[CompilerGenerated]
	private TextBox gQup8zKgS8X;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbNum3")]
	private TextBox to3pNW3JtRi;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("tbNum4")]
	private TextBox W40pNpnCscv;

	[AccessedThroughProperty("Label7")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label dMcpNTrXWBH;

	[AccessedThroughProperty("Label6")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label FBspNJs6lbk;

	[AccessedThroughProperty("Label5")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label MQapNhESR7c;

	[AccessedThroughProperty("Label4")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label uh0pNowcIlL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label3")]
	private Label XgKpNGan860;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label2")]
	private Label Iv2pNHs4SN4;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	private Label UcRpNkQDIFo;

	[AccessedThroughProperty("LbTotal")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label NP5pNdlA3Sp;

	[AccessedThroughProperty("GroupBox1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox rLvpNfCFml9;

	[AccessedThroughProperty("GroupBox3")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox oLLpND4upY0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox2")]
	[CompilerGenerated]
	private GroupBox s19pNvZXq0F;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt1")]
	[CompilerGenerated]
	private Button vMhpN6Fr49S;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("TBNome")]
	private TextBox A4xpNtiQajr;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt2")]
	[CompilerGenerated]
	private Button uubpNjXxx3y;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSet")]
	private Button LeqpNLr1ovL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt3")]
	private Button m2upNwFj3sK;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt5")]
	[CompilerGenerated]
	private Button r9hpNxBWD9I;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt4")]
	private Button gEtpNbGpAWx;

	private bool zbmpNMulBBJ;

	private ConfRelelatorio oXPpNOlsAx6;

	private cDadosLM.structureLMRelelatorio[] yHfpNIQBxsh;

	private cDadosLM.indexCODMateriais[] Wo0pN7X9qSa;

	private ColorDialog XlFpNq0qjlW;

	private int h3hpNaCbc4r;

	private bool ISipN8ZZJy5;

	private double p5hpNNoVOPm;

	private string fHhpNFk9WRT;

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

	internal virtual GroupBox GroupBox
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

	internal virtual TextBox tbNum7
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

	internal virtual TextBox tbNum6
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

	internal virtual TextBox tbNum5
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

	internal virtual TextBox tbNum1
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

	internal virtual TextBox tbNum2
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

	internal virtual TextBox tbNum3
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

	internal virtual TextBox tbNum4
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

	internal virtual Label Label7
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

	internal virtual Label Label6
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

	internal virtual Label Label5
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

	internal virtual Label Label4
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

	internal virtual Label Label3
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

	internal virtual Label Label2
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

	internal virtual Label Label1
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

	internal virtual Label LbTotal
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[DebuggerStepThrough]
	private void ecOp8DiD6A5()
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
	public frmRelatorio_MateriaisDWG(cDadosLM.structureLMRelelatorio[] mRelatMateriais, cDadosLM.indexCODMateriais[] mRelCod, bool bConcatModelo, bool bConcatFabricante, bool bVisivelCli, ref int iPainel)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void q9cp8vj1Ro6(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void w3yp86EIeEf(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private short tBkp8tINCrb()
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XIup8jnKLvn(object P_0, KeyPressEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void L4cp8LffR6x(object P_0, KeyPressEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void g8Yp8wuEyH9(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void o29p8xGpimJ(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void J3Sp8b6qQDF(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kPZp8MxuDb4(object P_0, KeyPressEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void rJrp8OS8ZsM(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void yPop8IUWUlJ(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void CalculaPorcento()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void O6tp87lZ5bm(object P_0, KeyEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dFRp8qTKhXt(bool P_0 = false)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NPkp8aeTSJy(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void zxmp88huZUv(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void vYHp8Nq69qQ(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VWap8FMDOUs(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void kimp8QdLCCP(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void SbOp8PkCnaF(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DnGp8cbAVcW()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KHEp8KFWJ4O(ref object P_0, string P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OKhp8eZnJgn(int P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void w3yp828enRh(int P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static frmRelatorio_MateriaisDWG()
	{
		GG5BlYp0wNmlGYMYs7HP.nbcp0gQeUG0();
		MO2qrKTenqBUoy8WQkZt.anJTee6tgpK(MO2qrKTenqBUoy8WQkZt.maqTe1EBRSN);
		M0rSCITellBV2v4UwoKj.anJTee6tgpK(M0rSCITellBV2v4UwoKj.qqxTe5nHZ2U);
	}
}
