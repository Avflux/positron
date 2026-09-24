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
		[CompilerGenerated]
		get
		{
			return Alap8nEAyGn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = XIup8jnKLvn;
			TextBox textBox = Alap8nEAyGn;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			Alap8nEAyGn = value;
			textBox = Alap8nEAyGn;
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
			return YaUp81oStgQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			YaUp81oStgQ = value;
		}
	}

	internal virtual Button btCorTextoBloco
	{
		[CompilerGenerated]
		get
		{
			return QgUp8lOEX3N;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = w3yp86EIeEf;
			Button button = QgUp8lOEX3N;
			if (button != null)
			{
				button.Click -= value2;
			}
			QgUp8lOEX3N = value;
			button = QgUp8lOEX3N;
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
			return v1Tp859ewu3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			v1Tp859ewu3 = value;
		}
	}

	internal virtual Button btCorBloco
	{
		[CompilerGenerated]
		get
		{
			return waNp80ZNZh2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = q9cp8vj1Ro6;
			Button button = waNp80ZNZh2;
			if (button != null)
			{
				button.Click -= value2;
			}
			waNp80ZNZh2 = value;
			button = waNp80ZNZh2;
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
			return ikIp8RaYsgy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ikIp8RaYsgy = value;
		}
	}

	internal virtual Label LabelStiloLinha
	{
		[CompilerGenerated]
		get
		{
			return jKgp8ma2IRq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jKgp8ma2IRq = value;
		}
	}

	internal virtual ComboBox CBFonte
	{
		[CompilerGenerated]
		get
		{
			return eXop8XwI4HB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			eXop8XwI4HB = value;
		}
	}

	internal virtual Button btExporta
	{
		[CompilerGenerated]
		get
		{
			return vjup8U9xRIi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = g8Yp8wuEyH9;
			Button button = vjup8U9xRIi;
			if (button != null)
			{
				button.Click -= value2;
			}
			vjup8U9xRIi = value;
			button = vjup8U9xRIi;
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
			return eHKp8y2cLEw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = o29p8xGpimJ;
			Button button = eHKp8y2cLEw;
			if (button != null)
			{
				button.Click -= value2;
			}
			eHKp8y2cLEw = value;
			button = eHKp8y2cLEw;
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
			return zQap8gY7mTH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = rJrp8OS8ZsM;
			EventHandler value3 = yPop8IUWUlJ;
			ComboBox comboBox = zQap8gY7mTH;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged -= value2;
				comboBox.SelectedValueChanged -= value3;
			}
			zQap8gY7mTH = value;
			comboBox = zQap8gY7mTH;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged += value2;
				comboBox.SelectedValueChanged += value3;
			}
		}
	}

	internal virtual Label LBDistanciaEntreColunas
	{
		[CompilerGenerated]
		get
		{
			return vopp8AH4f2a;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			vopp8AH4f2a = value;
		}
	}

	internal virtual TextBox TBDisteEntreColunas
	{
		[CompilerGenerated]
		get
		{
			return Gakp8scZBKB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = L4cp8LffR6x;
			TextBox textBox = Gakp8scZBKB;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			Gakp8scZBKB = value;
			textBox = Gakp8scZBKB;
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
			return GAmp8BuOYI8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = J3Sp8b6qQDF;
			Button button = GAmp8BuOYI8;
			if (button != null)
			{
				button.Click -= value2;
			}
			GAmp8BuOYI8 = value;
			button = GAmp8BuOYI8;
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
			return Hg8p8Vq0Bpa;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Hg8p8Vq0Bpa = value;
		}
	}

	internal virtual Label LabelDistanciaDaRegua
	{
		[CompilerGenerated]
		get
		{
			return KAip8uVsU4Z;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KAip8uVsU4Z = value;
		}
	}

	internal virtual TextBox TBAlturaDoBloco
	{
		[CompilerGenerated]
		get
		{
			return EPAp8ES4oqI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = kPZp8MxuDb4;
			TextBox textBox = EPAp8ES4oqI;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			EPAp8ES4oqI = value;
			textBox = EPAp8ES4oqI;
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
			return oGep8ZbyFpI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			oGep8ZbyFpI = value;
		}
	}

	internal virtual GroupBox GroupBox
	{
		[CompilerGenerated]
		get
		{
			return Uplp8iDGgLj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Uplp8iDGgLj = value;
		}
	}

	internal virtual Label LabelLinhas
	{
		[CompilerGenerated]
		get
		{
			return Oa4p8SF5l0G;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Oa4p8SF5l0G = value;
		}
	}

	internal virtual TextBox tbNum7
	{
		[CompilerGenerated]
		get
		{
			return p1pp8C6OO8x;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = O6tp87lZ5bm;
			TextBox textBox = p1pp8C6OO8x;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			p1pp8C6OO8x = value;
			textBox = p1pp8C6OO8x;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox tbNum6
	{
		[CompilerGenerated]
		get
		{
			return DJAp8YJjIdS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = O6tp87lZ5bm;
			TextBox textBox = DJAp8YJjIdS;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			DJAp8YJjIdS = value;
			textBox = DJAp8YJjIdS;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox tbNum5
	{
		[CompilerGenerated]
		get
		{
			return i51p8r7PbcA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = O6tp87lZ5bm;
			TextBox textBox = i51p8r7PbcA;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			i51p8r7PbcA = value;
			textBox = i51p8r7PbcA;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox tbNum1
	{
		[CompilerGenerated]
		get
		{
			return KlFp89GWiNl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = O6tp87lZ5bm;
			TextBox textBox = KlFp89GWiNl;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			KlFp89GWiNl = value;
			textBox = KlFp89GWiNl;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox tbNum2
	{
		[CompilerGenerated]
		get
		{
			return gQup8zKgS8X;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = O6tp87lZ5bm;
			TextBox textBox = gQup8zKgS8X;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			gQup8zKgS8X = value;
			textBox = gQup8zKgS8X;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox tbNum3
	{
		[CompilerGenerated]
		get
		{
			return to3pNW3JtRi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = O6tp87lZ5bm;
			TextBox textBox = to3pNW3JtRi;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			to3pNW3JtRi = value;
			textBox = to3pNW3JtRi;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox tbNum4
	{
		[CompilerGenerated]
		get
		{
			return W40pNpnCscv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = O6tp87lZ5bm;
			TextBox textBox = W40pNpnCscv;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			W40pNpnCscv = value;
			textBox = W40pNpnCscv;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Label Label7
	{
		[CompilerGenerated]
		get
		{
			return dMcpNTrXWBH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dMcpNTrXWBH = value;
		}
	}

	internal virtual Label Label6
	{
		[CompilerGenerated]
		get
		{
			return FBspNJs6lbk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			FBspNJs6lbk = value;
		}
	}

	internal virtual Label Label5
	{
		[CompilerGenerated]
		get
		{
			return MQapNhESR7c;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MQapNhESR7c = value;
		}
	}

	internal virtual Label Label4
	{
		[CompilerGenerated]
		get
		{
			return uh0pNowcIlL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			uh0pNowcIlL = value;
		}
	}

	internal virtual Label Label3
	{
		[CompilerGenerated]
		get
		{
			return XgKpNGan860;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			XgKpNGan860 = value;
		}
	}

	internal virtual Label Label2
	{
		[CompilerGenerated]
		get
		{
			return Iv2pNHs4SN4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Iv2pNHs4SN4 = value;
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return UcRpNkQDIFo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			UcRpNkQDIFo = value;
		}
	}

	internal virtual Label LbTotal
	{
		[CompilerGenerated]
		get
		{
			return NP5pNdlA3Sp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			NP5pNdlA3Sp = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return rLvpNfCFml9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rLvpNfCFml9 = value;
		}
	}

	internal virtual GroupBox GroupBox3
	{
		[CompilerGenerated]
		get
		{
			return oLLpND4upY0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			oLLpND4upY0 = value;
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return s19pNvZXq0F;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			s19pNvZXq0F = value;
		}
	}

	internal virtual Button bt1
	{
		[CompilerGenerated]
		get
		{
			return vMhpN6Fr49S;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = zxmp88huZUv;
			Button button = vMhpN6Fr49S;
			if (button != null)
			{
				button.Click -= value2;
			}
			vMhpN6Fr49S = value;
			button = vMhpN6Fr49S;
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
			return A4xpNtiQajr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			A4xpNtiQajr = value;
		}
	}

	internal virtual Button bt2
	{
		[CompilerGenerated]
		get
		{
			return uubpNjXxx3y;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = vYHp8Nq69qQ;
			Button button = uubpNjXxx3y;
			if (button != null)
			{
				button.Click -= value2;
			}
			uubpNjXxx3y = value;
			button = uubpNjXxx3y;
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
			return LeqpNLr1ovL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = NPkp8aeTSJy;
			Button button = LeqpNLr1ovL;
			if (button != null)
			{
				button.Click -= value2;
			}
			LeqpNLr1ovL = value;
			button = LeqpNLr1ovL;
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
			return m2upNwFj3sK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VWap8FMDOUs;
			Button button = m2upNwFj3sK;
			if (button != null)
			{
				button.Click -= value2;
			}
			m2upNwFj3sK = value;
			button = m2upNwFj3sK;
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
			return r9hpNxBWD9I;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SbOp8PkCnaF;
			Button button = r9hpNxBWD9I;
			if (button != null)
			{
				button.Click -= value2;
			}
			r9hpNxBWD9I = value;
			button = r9hpNxBWD9I;
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
			return gEtpNbGpAWx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = kimp8QdLCCP;
			Button button = gEtpNbGpAWx;
			if (button != null)
			{
				button.Click -= value2;
			}
			gEtpNbGpAWx = value;
			button = gEtpNbGpAWx;
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
			if (disposing && gDJp83pydc5 != null)
			{
				gDJp83pydc5.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ecOp8DiD6A5()
	{
		gDJp83pydc5 = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmRelatorio_MateriaisDWG));
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
		GroupBox = new GroupBox();
		LabelLinhas = new Label();
		LbTotal = new Label();
		Label7 = new Label();
		Label6 = new Label();
		Label5 = new Label();
		Label4 = new Label();
		Label3 = new Label();
		Label2 = new Label();
		tbNum7 = new TextBox();
		tbNum6 = new TextBox();
		tbNum5 = new TextBox();
		tbNum1 = new TextBox();
		tbNum2 = new TextBox();
		tbNum3 = new TextBox();
		tbNum4 = new TextBox();
		Label1 = new Label();
		FDqpBiUmZij(new ToolTip(gDJp83pydc5));
		GroupBox1 = new GroupBox();
		GroupBox3 = new GroupBox();
		GroupBox2 = new GroupBox();
		bt1 = new Button();
		TBNome = new TextBox();
		bt2 = new Button();
		btSet = new Button();
		bt3 = new Button();
		bt5 = new Button();
		bt4 = new Button();
		GroupBox.SuspendLayout();
		GroupBox1.SuspendLayout();
		GroupBox3.SuspendLayout();
		GroupBox2.SuspendLayout();
		SuspendLayout();
		btApagar.FlatStyle = FlatStyle.Flat;
		btApagar.ForeColor = SystemColors.Control;
		btApagar.Image = Resources.Delete_32;
		btApagar.Location = new Point(70, 17);
		btApagar.Name = "btApagar";
		btApagar.Size = new Size(40, 42);
		btApagar.TabIndex = 41;
		btApagar.Tag = "";
		btApagar.UseVisualStyleBackColor = true;
		btExporta.FlatStyle = FlatStyle.Flat;
		btExporta.ForeColor = SystemColors.Control;
		btExporta.Image = (Image)componentResourceManager.GetObject("btExporta.Image");
		btExporta.Location = new Point(127, 19);
		btExporta.Name = "btExporta";
		btExporta.Size = new Size(40, 42);
		btExporta.TabIndex = 39;
		btExporta.UseVisualStyleBackColor = true;
		CBColunas.FormattingEnabled = true;
		CBColunas.Location = new Point(176, 110);
		CBColunas.Name = "CBColunas";
		CBColunas.Size = new Size(47, 21);
		CBColunas.TabIndex = 52;
		CBFonte.FormattingEnabled = true;
		CBFonte.Location = new Point(96, 200);
		CBFonte.Name = "CBFonte";
		CBFonte.Size = new Size(126, 21);
		CBFonte.TabIndex = 0;
		LabelStiloLinha.Location = new Point(7, 200);
		LabelStiloLinha.Name = "LabelStiloLinha";
		LabelStiloLinha.Size = new Size(83, 23);
		LabelStiloLinha.TabIndex = 49;
		LabelStiloLinha.Text = "Fonte";
		LabelStiloLinha.TextAlign = ContentAlignment.MiddleLeft;
		LabelQuantColunas.Location = new Point(7, 110);
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
		tbFonteBloco.Location = new Point(176, 80);
		tbFonteBloco.Name = "tbFonteBloco";
		tbFonteBloco.Size = new Size(47, 20);
		tbFonteBloco.TabIndex = 27;
		tbFonteBloco.TextAlign = HorizontalAlignment.Center;
		LabelTamanhoFonte.Location = new Point(6, 80);
		LabelTamanhoFonte.Name = "LabelTamanhoFonte";
		LabelTamanhoFonte.Size = new Size(162, 25);
		LabelTamanhoFonte.TabIndex = 36;
		LabelTamanhoFonte.Text = "Tamanho do Fonte";
		LabelTamanhoFonte.TextAlign = ContentAlignment.MiddleLeft;
		btCorBloco.BackColor = SystemColors.ActiveCaption;
		btCorBloco.Location = new Point(176, 20);
		btCorBloco.Name = "btCorBloco";
		btCorBloco.Size = new Size(47, 25);
		btCorBloco.TabIndex = 0;
		btCorBloco.UseVisualStyleBackColor = false;
		LBDistanciaEntreColunas.Location = new Point(7, 140);
		LBDistanciaEntreColunas.Name = "LBDistanciaEntreColunas";
		LBDistanciaEntreColunas.Size = new Size(161, 25);
		LBDistanciaEntreColunas.TabIndex = 65;
		LBDistanciaEntreColunas.Text = "Distância entre Colunas";
		LBDistanciaEntreColunas.TextAlign = ContentAlignment.MiddleLeft;
		TBDisteEntreColunas.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBDisteEntreColunas.Location = new Point(176, 140);
		TBDisteEntreColunas.Name = "TBDisteEntreColunas";
		TBDisteEntreColunas.Size = new Size(47, 20);
		TBDisteEntreColunas.TabIndex = 64;
		TBDisteEntreColunas.TextAlign = HorizontalAlignment.Center;
		BTCancelar.FlatStyle = FlatStyle.Flat;
		BTCancelar.ForeColor = SystemColors.Control;
		BTCancelar.Image = Resources.Stop_32;
		BTCancelar.Location = new Point(13, 20);
		BTCancelar.Name = "BTCancelar";
		BTCancelar.Size = new Size(40, 42);
		BTCancelar.TabIndex = 66;
		BTCancelar.UseVisualStyleBackColor = true;
		TBAlturaInicialRelatorio.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBAlturaInicialRelatorio.Location = new Point(175, 230);
		TBAlturaInicialRelatorio.Name = "TBAlturaInicialRelatorio";
		TBAlturaInicialRelatorio.Size = new Size(47, 20);
		TBAlturaInicialRelatorio.TabIndex = 67;
		TBAlturaInicialRelatorio.TextAlign = HorizontalAlignment.Center;
		LabelDistanciaDaRegua.Location = new Point(7, 230);
		LabelDistanciaDaRegua.Name = "LabelDistanciaDaRegua";
		LabelDistanciaDaRegua.Size = new Size(162, 25);
		LabelDistanciaDaRegua.TabIndex = 68;
		LabelDistanciaDaRegua.Text = "Distância da Régua Horizontal";
		LabelDistanciaDaRegua.TextAlign = ContentAlignment.MiddleLeft;
		TBAlturaDoBloco.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBAlturaDoBloco.Location = new Point(176, 170);
		TBAlturaDoBloco.Name = "TBAlturaDoBloco";
		TBAlturaDoBloco.Size = new Size(47, 20);
		TBAlturaDoBloco.TabIndex = 69;
		TBAlturaDoBloco.TextAlign = HorizontalAlignment.Center;
		LBAlturaDoBloco.Location = new Point(6, 170);
		LBAlturaDoBloco.Name = "LBAlturaDoBloco";
		LBAlturaDoBloco.Size = new Size(162, 25);
		LBAlturaDoBloco.TabIndex = 70;
		LBAlturaDoBloco.Text = "Altura do Bloco";
		LBAlturaDoBloco.TextAlign = ContentAlignment.MiddleLeft;
		GroupBox.Controls.Add(LabelLinhas);
		GroupBox.Controls.Add(btCorBloco);
		GroupBox.Controls.Add(TBAlturaDoBloco);
		GroupBox.Controls.Add(LBAlturaDoBloco);
		GroupBox.Controls.Add(btCorTextoBloco);
		GroupBox.Controls.Add(TBAlturaInicialRelatorio);
		GroupBox.Controls.Add(LabelCorTexto);
		GroupBox.Controls.Add(LabelDistanciaDaRegua);
		GroupBox.Controls.Add(TBDisteEntreColunas);
		GroupBox.Controls.Add(LabelTamanhoFonte);
		GroupBox.Controls.Add(CBFonte);
		GroupBox.Controls.Add(LabelQuantColunas);
		GroupBox.Controls.Add(CBColunas);
		GroupBox.Controls.Add(LabelStiloLinha);
		GroupBox.Controls.Add(tbFonteBloco);
		GroupBox.Controls.Add(LBDistanciaEntreColunas);
		GroupBox.Location = new Point(8, 8);
		GroupBox.Name = "GroupBox";
		GroupBox.Size = new Size(241, 260);
		GroupBox.TabIndex = 95;
		GroupBox.TabStop = false;
		GroupBox.Text = "GroupBox";
		LabelLinhas.ImageAlign = ContentAlignment.TopLeft;
		LabelLinhas.Location = new Point(7, 20);
		LabelLinhas.Name = "LabelLinhas";
		LabelLinhas.Size = new Size(143, 25);
		LabelLinhas.TabIndex = 95;
		LabelLinhas.Text = "Linhas";
		LabelLinhas.TextAlign = ContentAlignment.MiddleLeft;
		LbTotal.Location = new Point(46, 231);
		LbTotal.Name = "LbTotal";
		LbTotal.Size = new Size(132, 25);
		LbTotal.TabIndex = 202;
		LbTotal.Text = "Total";
		LbTotal.TextAlign = ContentAlignment.MiddleRight;
		Label7.Location = new Point(10, 200);
		Label7.Name = "Label7";
		Label7.Size = new Size(114, 25);
		Label7.TabIndex = 201;
		Label7.Text = "Cliente";
		Label7.TextAlign = ContentAlignment.MiddleLeft;
		Label6.Location = new Point(10, 170);
		Label6.Name = "Label6";
		Label6.Size = new Size(114, 25);
		Label6.TabIndex = 201;
		Label6.Text = "Fabricante";
		Label6.TextAlign = ContentAlignment.MiddleLeft;
		Label5.Location = new Point(10, 140);
		Label5.Name = "Label5";
		Label5.Size = new Size(114, 25);
		Label5.TabIndex = 201;
		Label5.Text = "Modelo";
		Label5.TextAlign = ContentAlignment.MiddleLeft;
		Label4.Location = new Point(10, 110);
		Label4.Name = "Label4";
		Label4.Size = new Size(114, 25);
		Label4.TabIndex = 201;
		Label4.Text = "Descrição";
		Label4.TextAlign = ContentAlignment.MiddleLeft;
		Label3.Location = new Point(10, 80);
		Label3.Name = "Label3";
		Label3.Size = new Size(114, 25);
		Label3.TabIndex = 201;
		Label3.Text = "Tag";
		Label3.TextAlign = ContentAlignment.MiddleLeft;
		Label2.Location = new Point(10, 50);
		Label2.Name = "Label2";
		Label2.Size = new Size(114, 25);
		Label2.TabIndex = 200;
		Label2.Text = "Quantidade";
		Label2.TextAlign = ContentAlignment.MiddleLeft;
		tbNum7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbNum7.Location = new Point(127, 200);
		tbNum7.Name = "tbNum7";
		tbNum7.Size = new Size(51, 20);
		tbNum7.TabIndex = 199;
		tbNum6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbNum6.Location = new Point(127, 170);
		tbNum6.Name = "tbNum6";
		tbNum6.Size = new Size(51, 20);
		tbNum6.TabIndex = 198;
		tbNum5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbNum5.Location = new Point(127, 140);
		tbNum5.Name = "tbNum5";
		tbNum5.Size = new Size(51, 20);
		tbNum5.TabIndex = 197;
		tbNum1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbNum1.Location = new Point(127, 20);
		tbNum1.Name = "tbNum1";
		tbNum1.Size = new Size(51, 20);
		tbNum1.TabIndex = 193;
		tbNum2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbNum2.Location = new Point(127, 50);
		tbNum2.Name = "tbNum2";
		tbNum2.Size = new Size(51, 20);
		tbNum2.TabIndex = 194;
		tbNum3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbNum3.Location = new Point(127, 80);
		tbNum3.Name = "tbNum3";
		tbNum3.Size = new Size(51, 20);
		tbNum3.TabIndex = 195;
		tbNum4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbNum4.Location = new Point(127, 110);
		tbNum4.Name = "tbNum4";
		tbNum4.Size = new Size(51, 20);
		tbNum4.TabIndex = 196;
		Label1.Location = new Point(10, 20);
		Label1.Name = "Label1";
		Label1.Size = new Size(114, 25);
		Label1.TabIndex = 36;
		Label1.Text = "Indice";
		Label1.TextAlign = ContentAlignment.MiddleLeft;
		GroupBox1.Controls.Add(tbNum4);
		GroupBox1.Controls.Add(tbNum3);
		GroupBox1.Controls.Add(tbNum2);
		GroupBox1.Controls.Add(tbNum1);
		GroupBox1.Controls.Add(tbNum5);
		GroupBox1.Controls.Add(tbNum6);
		GroupBox1.Controls.Add(tbNum7);
		GroupBox1.Controls.Add(LbTotal);
		GroupBox1.Controls.Add(Label1);
		GroupBox1.Controls.Add(Label7);
		GroupBox1.Controls.Add(Label6);
		GroupBox1.Controls.Add(Label5);
		GroupBox1.Controls.Add(Label4);
		GroupBox1.Controls.Add(Label3);
		GroupBox1.Controls.Add(Label2);
		GroupBox1.Location = new Point(255, 8);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(186, 260);
		GroupBox1.TabIndex = 96;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "GroupBox1";
		GroupBox3.Controls.Add(BTCancelar);
		GroupBox3.Controls.Add(btApagar);
		GroupBox3.Controls.Add(btExporta);
		GroupBox3.Location = new Point(255, 278);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(186, 76);
		GroupBox3.TabIndex = 97;
		GroupBox3.TabStop = false;
		GroupBox2.Controls.Add(bt1);
		GroupBox2.Controls.Add(TBNome);
		GroupBox2.Controls.Add(bt2);
		GroupBox2.Controls.Add(btSet);
		GroupBox2.Controls.Add(bt3);
		GroupBox2.Controls.Add(bt5);
		GroupBox2.Controls.Add(bt4);
		GroupBox2.Location = new Point(8, 278);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(241, 76);
		GroupBox2.TabIndex = 98;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "GroupBox3";
		bt1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt1.Location = new Point(20, 46);
		bt1.Name = "bt1";
		bt1.Size = new Size(35, 20);
		bt1.TabIndex = 84;
		bt1.Text = "1";
		bt1.UseVisualStyleBackColor = true;
		TBNome.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBNome.Location = new Point(20, 20);
		TBNome.Name = "TBNome";
		TBNome.Size = new Size(159, 20);
		TBNome.TabIndex = 90;
		TBNome.TextAlign = HorizontalAlignment.Center;
		bt2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt2.Location = new Point(62, 46);
		bt2.Name = "bt2";
		bt2.Size = new Size(35, 20);
		bt2.TabIndex = 85;
		bt2.Text = "2";
		bt2.UseVisualStyleBackColor = true;
		btSet.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		btSet.Location = new Point(180, 18);
		btSet.Name = "btSet";
		btSet.Size = new Size(40, 20);
		btSet.TabIndex = 89;
		btSet.Text = "SET";
		btSet.UseVisualStyleBackColor = true;
		bt3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt3.Location = new Point(103, 46);
		bt3.Name = "bt3";
		bt3.Size = new Size(35, 20);
		bt3.TabIndex = 86;
		bt3.Text = "3";
		bt3.UseVisualStyleBackColor = true;
		bt5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt5.Location = new Point(185, 46);
		bt5.Name = "bt5";
		bt5.Size = new Size(35, 20);
		bt5.TabIndex = 88;
		bt5.Text = "5";
		bt5.UseVisualStyleBackColor = true;
		bt4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		bt4.Location = new Point(144, 46);
		bt4.Name = "bt4";
		bt4.Size = new Size(35, 20);
		bt4.TabIndex = 87;
		bt4.Text = "4";
		bt4.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(447, 361);
		Controls.Add(GroupBox2);
		Controls.Add(GroupBox3);
		Controls.Add(GroupBox1);
		Controls.Add(GroupBox);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		MaximumSize = new Size(463, 400);
		MinimizeBox = false;
		MinimumSize = new Size(463, 400);
		Name = "frmRelatorio_MateriaisDWG";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Lista de Materiais DWG";
		GroupBox.ResumeLayout(performLayout: false);
		GroupBox.PerformLayout();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return znvp84IrCcY;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		znvp84IrCcY = WithEventsValue;
	}

	public frmRelatorio_MateriaisDWG(cDadosLM.structureLMRelelatorio[] mRelatMateriais, cDadosLM.indexCODMateriais[] mRelCod, bool bConcatModelo, bool bConcatFabricante, bool bVisivelCli, ref int iPainel)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected Obj, but got Unknown
		XlFpNq0qjlW = new ColorDialog();
		h3hpNaCbc4r = 0;
		ISipN8ZZJy5 = false;
		p5hpNNoVOPm = 0.0;
		fHhpNFk9WRT = "MATERIAIS";
		yHfpNIQBxsh = mRelatMateriais;
		Wo0pN7X9qSa = mRelCod;
		h3hpNaCbc4r = iPainel;
		ecOp8DiD6A5();
		DeclaracoesGeral.Reguas RH = default;
		checked
		{
			if (XDataGeral.LeXDataReguaH(ref RH))
			{
				Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1210], " - "), Dicionario.BuscaNomeDoPainel(h3hpNaCbc4r)));
				GroupBox.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1646]);
				GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1647]);
				GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 382]);
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
				CBColunas.Text = "1";
				TBAlturaInicialRelatorio.Text = "25";
				TBDisteEntreColunas.Text = Conversions.ToString(6);
				TBAlturaDoBloco.Text = Conversions.ToString(7);
				Color val = Color.FromColorIndex((ColorMethod)194, (short)7);
				btCorBloco.BackColor = val.ColorValue;
				val = Color.FromColorIndex((ColorMethod)194, (short)7);
				btCorTextoBloco.BackColor = val.ColorValue;
				oXPpNOlsAx6.CorLinha = 7;
				oXPpNOlsAx6.CorTexto = 7;
				oXPpNOlsAx6.bConcatModelo = bConcatModelo;
				oXPpNOlsAx6.bConcatFabricante = bConcatFabricante;
				oXPpNOlsAx6.bVisivelCli = bVisivelCli;
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
				for (int i = 1; i <= num; i++)
				{
					CBFonte.Items.Add(array[i]);
					if (Operators.CompareString(array[i].ToString().ToUpper(), "ROMANS", TextCompare: true) == 0)
					{
						CBFonte.Text = array[i];
					}
				}
				Label1.Text = mRelatMateriais[0].Index;
				Label2.Text = mRelatMateriais[0].Quantidade;
				Label3.Text = mRelatMateriais[0].Tag;
				Label4.Text = mRelatMateriais[0].Desc;
				Label5.Text = mRelatMateriais[0].sModelo;
				Label6.Text = mRelatMateriais[0].sFabricante;
				Label7.Text = mRelatMateriais[0].CodCli;
				oXPpNOlsAx6.TamanhoFonte = Conversions.ToDouble(tbFonteBloco.Text);
				oXPpNOlsAx6.QuantColunas = (short)Conversions.ToInteger(CBColunas.Text);
				oXPpNOlsAx6.AlturaInicial = Conversions.ToDouble(TBAlturaInicialRelatorio.Text);
				oXPpNOlsAx6.sFonte = CBFonte.Text;
				oXPpNOlsAx6.DistEntreColunas = Conversions.ToDouble(TBDisteEntreColunas.Text);
				oXPpNOlsAx6.AlturaDoBloco = Conversions.ToDouble(TBAlturaDoBloco.Text);
				ISipN8ZZJy5 = true;
				CalculaPorcento();
				DnGp8cbAVcW();
				Label1.Enabled = true;
				tbNum1.Enabled = true;
				Label2.Enabled = true;
				tbNum2.Enabled = true;
				Label3.Enabled = true;
				tbNum3.Enabled = true;
				Label4.Enabled = true;
				tbNum4.Enabled = true;
				Label5.Enabled = true;
				tbNum5.Enabled = true;
				Label6.Enabled = true;
				tbNum6.Enabled = true;
				Label7.Enabled = true;
				tbNum7.Enabled = true;
				if (Operators.CompareString(tbNum1.Text.Trim(), "0", TextCompare: true) == 0)
				{
					Label1.Enabled = false;
					tbNum1.Enabled = false;
				}
				if (Operators.CompareString(tbNum2.Text.Trim(), "0", TextCompare: true) == 0)
				{
					Label2.Enabled = false;
					tbNum2.Enabled = false;
				}
				if (Operators.CompareString(tbNum3.Text.Trim(), "0", TextCompare: true) == 0)
				{
					Label3.Enabled = false;
					tbNum3.Enabled = false;
				}
				if (Operators.CompareString(tbNum4.Text.Trim(), "0", TextCompare: true) == 0)
				{
					Label4.Enabled = false;
					tbNum4.Enabled = false;
				}
				if (Operators.CompareString(tbNum5.Text.Trim(), "0", TextCompare: true) == 0)
				{
					Label5.Enabled = false;
					tbNum5.Enabled = false;
				}
				if (Operators.CompareString(tbNum6.Text.Trim(), "0", TextCompare: true) == 0)
				{
					Label6.Enabled = false;
					tbNum6.Enabled = false;
				}
				if (Operators.CompareString(tbNum7.Text.Trim(), "0", TextCompare: true) == 0)
				{
					Label7.Enabled = false;
					tbNum7.Enabled = false;
				}
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 611]), MsgBoxStyle.Information);
			}
		}
	}

	private void q9cp8vj1Ro6(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = XlFpNq0qjlW.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			oXPpNOlsAx6.CorLinha = XlFpNq0qjlW.Color.ColorIndex;
			btCorBloco.BackColor = XlFpNq0qjlW.Color.ColorValue;
		}
	}

	private void w3yp86EIeEf(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = XlFpNq0qjlW.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			oXPpNOlsAx6.CorTexto = XlFpNq0qjlW.Color.ColorIndex;
			btCorTextoBloco.BackColor = XlFpNq0qjlW.Color.ColorValue;
		}
	}

	private short tBkp8tINCrb()
	{
		DialogResult dialogResult = XlFpNq0qjlW.ShowDialog();
		if (dialogResult != DialogResult.OK)
		{
			return 7;
		}
		return XlFpNq0qjlW.Color.ColorIndex;
	}

	private void XIup8jnKLvn(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void L4cp8LffR6x(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void g8Yp8wuEyH9(object P_0, EventArgs P_1)
	{
		oXPpNOlsAx6.TamanhoFonte = Conversions.ToDouble(tbFonteBloco.Text);
		oXPpNOlsAx6.QuantColunas = checked((short)Conversions.ToInteger(CBColunas.Text));
		oXPpNOlsAx6.AlturaInicial = Conversions.ToDouble(TBAlturaInicialRelatorio.Text);
		oXPpNOlsAx6.sFonte = CBFonte.Text;
		oXPpNOlsAx6.DistEntreColunas = Conversions.ToDouble(TBDisteEntreColunas.Text);
		oXPpNOlsAx6.AlturaDoBloco = Conversions.ToDouble(TBAlturaDoBloco.Text);
		string pag = DeclaracoesGeral.ativo.Pagina;
		dFRp8qTKhXt(_0020: true);
		Relatorios_MateriaisDWG.CriaRelMateriaisDWG1PN(yHfpNIQBxsh, oXPpNOlsAx6, ref h3hpNaCbc4r, Conversions.ToDouble(tbNum1.Text), Conversions.ToDouble(tbNum2.Text), Conversions.ToDouble(tbNum3.Text), Conversions.ToDouble(tbNum4.Text), Conversions.ToDouble(tbNum5.Text), Conversions.ToDouble(tbNum6.Text), Conversions.ToDouble(tbNum7.Text));
		cDadosAccessMateriais cDadosAccessMateriais2 = new cDadosAccessMateriais();
		cDadosAccessMateriais2.AtualizaIndiceLM(ref Wo0pN7X9qSa);
		cDadosAccessMateriais2.fechaConexao();
		if (Operators.CompareString(pag, "", TextCompare: true) != 0)
		{
			Pagina.AtivaPagina(pag);
			DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
		}
	}

	private void o29p8xGpimJ(object P_0, EventArgs P_1)
	{
		Relatorios_MateriaisDWG.ApagaRelatorioMateriaisPainel(ref h3hpNaCbc4r);
	}

	private void J3Sp8b6qQDF(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.bPararRelatorio = true;
		Application.DoEvents();
	}

	private void kPZp8MxuDb4(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void rJrp8OS8ZsM(object P_0, EventArgs P_1)
	{
		oXPpNOlsAx6.QuantColunas = checked((short)Conversions.ToInteger(CBColunas.Text));
		CalculaPorcento();
	}

	private void yPop8IUWUlJ(object P_0, EventArgs P_1)
	{
		oXPpNOlsAx6.QuantColunas = checked((short)Conversions.ToInteger(CBColunas.Text));
		CalculaPorcento();
	}

	public void CalculaPorcento()
	{
		if (ISipN8ZZJy5)
		{
			DeclaracoesGeral.Reguas RH = default;
			XDataGeral.LeXDataReguaH(ref RH);
			p5hpNNoVOPm = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta;
			p5hpNNoVOPm -= oXPpNOlsAx6.DistEntreColunas * (double)checked(oXPpNOlsAx6.QuantColunas + 1);
			p5hpNNoVOPm /= oXPpNOlsAx6.QuantColunas;
			tbNum1.Text = Conversions.ToString(Math.Round(p5hpNNoVOPm * 0.05, 1));
			tbNum2.Text = Conversions.ToString(Math.Round(p5hpNNoVOPm * 0.05, 1));
			tbNum3.Text = Conversions.ToString(Math.Round(p5hpNNoVOPm * 0.2, 1));
			tbNum4.Text = "0";
			tbNum5.Text = "0";
			tbNum6.Text = "0";
			tbNum7.Text = "0";
			double num = 0.4;
			if (!oXPpNOlsAx6.bConcatModelo)
			{
				tbNum5.Text = Conversions.ToString(Math.Round(p5hpNNoVOPm * 0.1, 1));
			}
			else
			{
				num += 0.1;
			}
			if (!oXPpNOlsAx6.bConcatFabricante)
			{
				tbNum6.Text = Conversions.ToString(Math.Round(p5hpNNoVOPm * 0.1, 1));
			}
			else
			{
				num += 0.1;
			}
			if (oXPpNOlsAx6.bVisivelCli)
			{
				tbNum7.Text = Conversions.ToString(Math.Round(p5hpNNoVOPm * 0.1, 1));
			}
			else
			{
				num += 0.1;
			}
			tbNum4.Text = Conversions.ToString(Math.Round(p5hpNNoVOPm * num, 1));
			dFRp8qTKhXt(_0020: true);
		}
	}

	private void O6tp87lZ5bm(object P_0, KeyEventArgs P_1)
	{
		dFRp8qTKhXt();
	}

	private void dFRp8qTKhXt(bool P_0 = false)
	{
		if (!Versioned.IsNumeric(tbNum1.Text))
		{
			tbNum1.Text = Conversions.ToString(0);
		}
		if (!Versioned.IsNumeric(tbNum2.Text))
		{
			tbNum2.Text = Conversions.ToString(0);
		}
		if (!Versioned.IsNumeric(tbNum3.Text))
		{
			tbNum3.Text = Conversions.ToString(0);
		}
		if (!Versioned.IsNumeric(tbNum4.Text))
		{
			tbNum4.Text = Conversions.ToString(0);
		}
		if (!Versioned.IsNumeric(tbNum5.Text))
		{
			tbNum5.Text = Conversions.ToString(0);
		}
		if (!Versioned.IsNumeric(tbNum6.Text))
		{
			tbNum6.Text = Conversions.ToString(0);
		}
		if (!Versioned.IsNumeric(tbNum7.Text))
		{
			tbNum7.Text = Conversions.ToString(0);
		}
		while (true)
		{
			double value = p5hpNNoVOPm - Conversions.ToDouble(tbNum1.Text) - Conversions.ToDouble(tbNum2.Text) - Conversions.ToDouble(tbNum3.Text) - Conversions.ToDouble(tbNum4.Text) - Conversions.ToDouble(tbNum5.Text) - Conversions.ToDouble(tbNum6.Text) - Conversions.ToDouble(tbNum7.Text);
			LbTotal.Text = Conversions.ToString(Math.Round(value, 1));
			value = Math.Round(value, 1);
			if (value == 0.0)
			{
				LbTotal.Text = "";
			}
			if (!(value < 0.0))
			{
				LbTotal.ForeColor = Color.Black;
			}
			else
			{
				LbTotal.ForeColor = Color.Red;
			}
			if (!P_0 || value == 0.0)
			{
				break;
			}
			if (Conversions.ToDouble(tbNum7.Text) == 0.0)
			{
				if (Conversions.ToDouble(tbNum6.Text) == 0.0)
				{
					if (Conversions.ToDouble(tbNum5.Text) == 0.0)
					{
						if (Conversions.ToDouble(tbNum4.Text) == 0.0)
						{
							if (Conversions.ToDouble(tbNum3.Text) != 0.0)
							{
								TextBox textBox;
								(textBox = tbNum3).Text = Conversions.ToString(Conversions.ToDouble(textBox.Text) + value);
							}
						}
						else
						{
							TextBox textBox;
							(textBox = tbNum4).Text = Conversions.ToString(Conversions.ToDouble(textBox.Text) + value);
						}
					}
					else
					{
						TextBox textBox;
						(textBox = tbNum5).Text = Conversions.ToString(Conversions.ToDouble(textBox.Text) + value);
					}
				}
				else
				{
					TextBox textBox;
					(textBox = tbNum6).Text = Conversions.ToString(Conversions.ToDouble(textBox.Text) + value);
				}
			}
			else
			{
				TextBox textBox;
				(textBox = tbNum7).Text = Conversions.ToString(Conversions.ToDouble(textBox.Text) + value);
			}
		}
	}

	private void NPkp8aeTSJy(object P_0, EventArgs P_1)
	{
		if (zbmpNMulBBJ)
		{
			zbmpNMulBBJ = false;
			DnGp8cbAVcW();
			return;
		}
		zbmpNMulBBJ = true;
		bt1.Enabled = true;
		bt2.Enabled = true;
		bt3.Enabled = true;
		bt4.Enabled = true;
		bt5.Enabled = true;
	}

	private void zxmp88huZUv(object P_0, EventArgs P_1)
	{
		if (zbmpNMulBBJ)
		{
			w3yp828enRh(1);
			zbmpNMulBBJ = false;
		}
		else
		{
			TBNome.Text = "";
			OKhp8eZnJgn(1);
		}
		DnGp8cbAVcW();
	}

	private void vYHp8Nq69qQ(object P_0, EventArgs P_1)
	{
		if (zbmpNMulBBJ)
		{
			w3yp828enRh(2);
			zbmpNMulBBJ = false;
		}
		else
		{
			TBNome.Text = "";
			OKhp8eZnJgn(2);
		}
		DnGp8cbAVcW();
	}

	private void VWap8FMDOUs(object P_0, EventArgs P_1)
	{
		if (zbmpNMulBBJ)
		{
			w3yp828enRh(3);
			zbmpNMulBBJ = false;
		}
		else
		{
			TBNome.Text = "";
			OKhp8eZnJgn(3);
		}
		DnGp8cbAVcW();
	}

	private void kimp8QdLCCP(object P_0, EventArgs P_1)
	{
		if (zbmpNMulBBJ)
		{
			w3yp828enRh(4);
			zbmpNMulBBJ = false;
		}
		else
		{
			TBNome.Text = "";
			OKhp8eZnJgn(4);
		}
		DnGp8cbAVcW();
	}

	private void SbOp8PkCnaF(object P_0, EventArgs P_1)
	{
		if (zbmpNMulBBJ)
		{
			w3yp828enRh(5);
			zbmpNMulBBJ = false;
		}
		else
		{
			TBNome.Text = "";
			OKhp8eZnJgn(5);
		}
		DnGp8cbAVcW();
	}

	private void DnGp8cbAVcW()
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
				GroupBox1.Enabled = true;
				cDadosAccessComum cDadosAccessComum2 = new cDadosAccessComum();
				try
				{
					DataTable dataTable = cDadosAccessComum2.LeConfiguracaoRelatorio("F", fHhpNFk9WRT);
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

	private void KHEp8KFWJ4O(ref object P_0, string P_1)
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

	private void OKhp8eZnJgn(int P_0)
	{
		if (!clsAuxiliar.BancoValido())
		{
			return;
		}
		string sComando = "";
		cDadosAccessComum cDadosAccessComum2 = new cDadosAccessComum();
		try
		{
			cDadosAccessComum2.LeConfiguracao(ref sComando, P_0, "F", fHhpNFk9WRT);
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
		KHEp8KFWJ4O(ref obj, sComando);
		array = (object[])obj;
		TBNome.Text = Conversions.ToString(array[1]);
		Color val = Color.FromColorIndex((ColorMethod)194, Conversions.ToShort(array[2]));
		btCorBloco.BackColor = val.ColorValue;
		oXPpNOlsAx6.CorLinha = Conversions.ToShort(array[3]);
		val = Color.FromColorIndex((ColorMethod)194, Conversions.ToShort(array[3]));
		btCorTextoBloco.BackColor = val.ColorValue;
		oXPpNOlsAx6.CorTexto = Conversions.ToShort(array[4]);
		tbFonteBloco.Text = Conversions.ToString(array[4]);
		CBColunas.Text = Conversions.ToString(array[5]);
		TBDisteEntreColunas.Text = Conversions.ToString(array[6]);
		TBAlturaDoBloco.Text = clsUtilitarios.SoNumeros(Conversions.ToString(array[7]));
		CBFonte.Text = Conversions.ToString(array[8]);
		TBAlturaInicialRelatorio.Text = clsUtilitarios.SoNumeros(Conversions.ToString(array[9]));
		tbNum1.Text = clsUtilitarios.SoNumeros(Conversions.ToString(array[10]));
		tbNum2.Text = clsUtilitarios.SoNumeros(Conversions.ToString(array[11]));
		tbNum3.Text = clsUtilitarios.SoNumeros(Conversions.ToString(array[12]));
		tbNum4.Text = clsUtilitarios.SoNumeros(Conversions.ToString(array[13]));
		tbNum5.Text = clsUtilitarios.SoNumeros(Conversions.ToString(array[14]));
		tbNum6.Text = clsUtilitarios.SoNumeros(Conversions.ToString(array[15]));
	}

	private void w3yp828enRh(int P_0)
	{
		if (!clsAuxiliar.BancoValido())
		{
			return;
		}
		string text = "";
		text = TBNome.Text;
		text = text + ";" + Conversions.ToString((int)oXPpNOlsAx6.CorLinha);
		text = text + ";" + Conversions.ToString((int)oXPpNOlsAx6.CorTexto);
		text = text + ";" + tbFonteBloco.Text;
		text = text + ";" + CBColunas.Text;
		text = text + ";" + TBDisteEntreColunas.Text;
		text = text + ";" + TBAlturaDoBloco.Text;
		text = text + ";" + CBFonte.Text;
		text = text + ";" + TBAlturaInicialRelatorio.Text;
		text = text + ";" + tbNum1.Text;
		text = text + ";" + tbNum2.Text;
		text = text + ";" + tbNum3.Text;
		text = text + ";" + tbNum4.Text;
		text = text + ";" + tbNum5.Text;
		text = text + ";" + tbNum6.Text;
		cDadosAccessComum cDadosAccessComum2 = new cDadosAccessComum();
		try
		{
			cDadosAccessComum2.GravaConfiguracao(text, P_0, "F", fHhpNFk9WRT);
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
	}
}
