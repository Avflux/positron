using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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
public class frmRelatorio_FiacaoDWG : Form
{
	private IContainer kDYpMFwoPtp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbFonteBloco")]
	private TextBox SAvpMQuG6dh;

	[AccessedThroughProperty("LabelCorTexto")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label yYDpMP8Fajd;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCorTextoBloco")]
	[CompilerGenerated]
	private Button Q7gpMcTNsM5;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelTamanhoFonte")]
	private Label w6VpMKtKH1r;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCorBloco")]
	private Button TcCpMeR3eVQ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelQuantColunas")]
	private Label LIkpM2fIimn;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelStiloLinha")]
	[CompilerGenerated]
	private Label NKMpM3CXtJK;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBFonte")]
	private ComboBox ArTpMnQlcMD;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExporta")]
	[CompilerGenerated]
	private Button vFbpM15Xym8;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagar")]
	private Button V3JpMlJgejw;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CBColunas")]
	private ComboBox GODpM5vKkUg;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("FolderBrowser")]
	private FolderBrowserDialog eFZpM0HRG4H;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBDistanciaEntreColunas")]
	private Label VimpMRfl1Fb;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("TBDisteEntreColunas")]
	private TextBox nxupMmmnKDJ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTCancelar")]
	private Button hXmpMX8OICN;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBAlturaInicialRelatorio")]
	[CompilerGenerated]
	private TextBox BgPpMULS7iI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelDistanciaDaRegua")]
	private Label FXPpMycKHoV;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBAlturaDoBloco")]
	[CompilerGenerated]
	private TextBox pufpMgDZRrm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBAlturaDoBloco")]
	private Label iuKpMALaxQT;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox2")]
	[CompilerGenerated]
	private GroupBox T3qpMsLobxC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt1")]
	private Button sQspMBWAv11;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBNome")]
	private TextBox OWHpMVhV48w;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt2")]
	private Button zoOpMuZotb7;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSet")]
	private Button m8tpMEcJeET;

	[AccessedThroughProperty("bt3")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button Y9apMZ4TGTq;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt5")]
	[CompilerGenerated]
	private Button DjOpMiOfrt0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt4")]
	private Button bkApMS3dUhI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCorDoJumper")]
	private Button UbRpM4huVhK;

	[CompilerGenerated]
	[AccessedThroughProperty("LabelCorDoJumper")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label OCqpMCxXLcy;

	[AccessedThroughProperty("GBCores")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox bPipMYacIkO;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelPainel")]
	[CompilerGenerated]
	private Label gX0pMrYapNS;

	[AccessedThroughProperty("LabelTipoRelatorio")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label T4YpM910Vbj;

	[AccessedThroughProperty("LabelLinhas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label ocXpMzv4Mmb;

	[CompilerGenerated]
	[AccessedThroughProperty("tbTerminal")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox UlXpOWvcylm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBDisp1")]
	private TextBox i7lpOpwiX2U;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBTerm1")]
	private TextBox QGxpOT8ArDv;

	[AccessedThroughProperty("TBDestino1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox iBDpOJVocCw;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBDisp2")]
	private TextBox LL1pOhfZgUh;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBTerm2")]
	private TextBox pNZpOoQsFtx;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("TbDestino2")]
	private TextBox liopOG9m6ml;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBPagina")]
	private TextBox rUPpOHE9HyH;

	[AccessedThroughProperty("TBSecao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox TJUpOkk6y7k;

	[AccessedThroughProperty("TBcor")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox ixupOdVRHhx;

	private bool ecmpOfNMIq1;

	private DeclaracoesFiacao.structureRelFiacao[] OEDpODdHMTJ;

	private string xTrpOvu02GA;

	private int dxipO6BhsKp;

	private string LWdpOtTm7GH;

	private ColorDialog wg8pOj1Tj7a;

	internal virtual TextBox tbFonteBloco
	{
		[CompilerGenerated]
		get
		{
			return SAvpMQuG6dh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = WwapMvYKxxI;
			TextBox textBox = SAvpMQuG6dh;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			SAvpMQuG6dh = value;
			textBox = SAvpMQuG6dh;
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
			return yYDpMP8Fajd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			yYDpMP8Fajd = value;
		}
	}

	internal virtual Button btCorTextoBloco
	{
		[CompilerGenerated]
		get
		{
			return Q7gpMcTNsM5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ewKpMd8Dm6X;
			Button button = Q7gpMcTNsM5;
			if (button != null)
			{
				button.Click -= value2;
			}
			Q7gpMcTNsM5 = value;
			button = Q7gpMcTNsM5;
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
			return w6VpMKtKH1r;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			w6VpMKtKH1r = value;
		}
	}

	internal virtual Button btCorBloco
	{
		[CompilerGenerated]
		get
		{
			return TcCpMeR3eVQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DIBpMkl7jrE;
			Button button = TcCpMeR3eVQ;
			if (button != null)
			{
				button.Click -= value2;
			}
			TcCpMeR3eVQ = value;
			button = TcCpMeR3eVQ;
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
			return LIkpM2fIimn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LIkpM2fIimn = value;
		}
	}

	internal virtual Label LabelStiloLinha
	{
		[CompilerGenerated]
		get
		{
			return NKMpM3CXtJK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			NKMpM3CXtJK = value;
		}
	}

	internal virtual ComboBox CBFonte
	{
		[CompilerGenerated]
		get
		{
			return ArTpMnQlcMD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ArTpMnQlcMD = value;
		}
	}

	internal virtual Button btExporta
	{
		[CompilerGenerated]
		get
		{
			return vFbpM15Xym8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = jyHpMt4KxC5;
			Button button = vFbpM15Xym8;
			if (button != null)
			{
				button.Click -= value2;
			}
			vFbpM15Xym8 = value;
			button = vFbpM15Xym8;
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
			return V3JpMlJgejw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = r5SpMjH8sXc;
			Button button = V3JpMlJgejw;
			if (button != null)
			{
				button.Click -= value2;
			}
			V3JpMlJgejw = value;
			button = V3JpMlJgejw;
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
			return GODpM5vKkUg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			GODpM5vKkUg = value;
		}
	}

	internal virtual Label LBDistanciaEntreColunas
	{
		[CompilerGenerated]
		get
		{
			return VimpMRfl1Fb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			VimpMRfl1Fb = value;
		}
	}

	internal virtual TextBox TBDisteEntreColunas
	{
		[CompilerGenerated]
		get
		{
			return nxupMmmnKDJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = cIIpM6VA6Dn;
			TextBox textBox = nxupMmmnKDJ;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			nxupMmmnKDJ = value;
			textBox = nxupMmmnKDJ;
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
			return hXmpMX8OICN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = JJXpML9npjZ;
			Button button = hXmpMX8OICN;
			if (button != null)
			{
				button.Click -= value2;
			}
			hXmpMX8OICN = value;
			button = hXmpMX8OICN;
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
			return BgPpMULS7iI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			BgPpMULS7iI = value;
		}
	}

	internal virtual Label LabelDistanciaDaRegua
	{
		[CompilerGenerated]
		get
		{
			return FXPpMycKHoV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			FXPpMycKHoV = value;
		}
	}

	internal virtual TextBox TBAlturaDoBloco
	{
		[CompilerGenerated]
		get
		{
			return pufpMgDZRrm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = zmQpMwquDDR;
			TextBox textBox = pufpMgDZRrm;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			pufpMgDZRrm = value;
			textBox = pufpMgDZRrm;
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
			return iuKpMALaxQT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			iuKpMALaxQT = value;
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return T3qpMsLobxC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			T3qpMsLobxC = value;
		}
	}

	internal virtual Button bt1
	{
		[CompilerGenerated]
		get
		{
			return sQspMBWAv11;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CodpMbJEy0h;
			Button button = sQspMBWAv11;
			if (button != null)
			{
				button.Click -= value2;
			}
			sQspMBWAv11 = value;
			button = sQspMBWAv11;
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
			return OWHpMVhV48w;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			OWHpMVhV48w = value;
		}
	}

	internal virtual Button bt2
	{
		[CompilerGenerated]
		get
		{
			return zoOpMuZotb7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = HQ4pMMYS0l0;
			Button button = zoOpMuZotb7;
			if (button != null)
			{
				button.Click -= value2;
			}
			zoOpMuZotb7 = value;
			button = zoOpMuZotb7;
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
			return m8tpMEcJeET;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = HDOpMxGODVn;
			Button button = m8tpMEcJeET;
			if (button != null)
			{
				button.Click -= value2;
			}
			m8tpMEcJeET = value;
			button = m8tpMEcJeET;
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
			return Y9apMZ4TGTq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = eZTpMO8GoyQ;
			Button button = Y9apMZ4TGTq;
			if (button != null)
			{
				button.Click -= value2;
			}
			Y9apMZ4TGTq = value;
			button = Y9apMZ4TGTq;
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
			return DjOpMiOfrt0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FHMpM7EFOtb;
			Button button = DjOpMiOfrt0;
			if (button != null)
			{
				button.Click -= value2;
			}
			DjOpMiOfrt0 = value;
			button = DjOpMiOfrt0;
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
			return bkApMS3dUhI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EF5pMIlItlF;
			Button button = bkApMS3dUhI;
			if (button != null)
			{
				button.Click -= value2;
			}
			bkApMS3dUhI = value;
			button = bkApMS3dUhI;
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
			return UbRpM4huVhK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = t5rpMfmeGta;
			Button button = UbRpM4huVhK;
			if (button != null)
			{
				button.Click -= value2;
			}
			UbRpM4huVhK = value;
			button = UbRpM4huVhK;
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
			return OCqpMCxXLcy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			OCqpMCxXLcy = value;
		}
	}

	internal virtual GroupBox GBCores
	{
		[CompilerGenerated]
		get
		{
			return bPipMYacIkO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			bPipMYacIkO = value;
		}
	}

	internal virtual Label LabelPainel
	{
		[CompilerGenerated]
		get
		{
			return gX0pMrYapNS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			gX0pMrYapNS = value;
		}
	}

	internal virtual Label LabelTipoRelatorio
	{
		[CompilerGenerated]
		get
		{
			return T4YpM910Vbj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			T4YpM910Vbj = value;
		}
	}

	internal virtual Label LabelLinhas
	{
		[CompilerGenerated]
		get
		{
			return ocXpMzv4Mmb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ocXpMzv4Mmb = value;
		}
	}

	internal virtual TextBox tbTerminal
	{
		[CompilerGenerated]
		get
		{
			return UlXpOWvcylm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			UlXpOWvcylm = value;
		}
	}

	internal virtual TextBox TBDisp1
	{
		[CompilerGenerated]
		get
		{
			return i7lpOpwiX2U;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			i7lpOpwiX2U = value;
		}
	}

	internal virtual TextBox TBTerm1
	{
		[CompilerGenerated]
		get
		{
			return QGxpOT8ArDv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			QGxpOT8ArDv = value;
		}
	}

	internal virtual TextBox TBDestino1
	{
		[CompilerGenerated]
		get
		{
			return iBDpOJVocCw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			iBDpOJVocCw = value;
		}
	}

	internal virtual TextBox TBDisp2
	{
		[CompilerGenerated]
		get
		{
			return LL1pOhfZgUh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			LL1pOhfZgUh = value;
		}
	}

	internal virtual TextBox TBTerm2
	{
		[CompilerGenerated]
		get
		{
			return pNZpOoQsFtx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pNZpOoQsFtx = value;
		}
	}

	internal virtual TextBox TbDestino2
	{
		[CompilerGenerated]
		get
		{
			return liopOG9m6ml;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			liopOG9m6ml = value;
		}
	}

	internal virtual TextBox TBPagina
	{
		[CompilerGenerated]
		get
		{
			return rUPpOHE9HyH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rUPpOHE9HyH = value;
		}
	}

	internal virtual TextBox TBSecao
	{
		[CompilerGenerated]
		get
		{
			return TJUpOkk6y7k;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TJUpOkk6y7k = value;
		}
	}

	internal virtual TextBox TBcor
	{
		[CompilerGenerated]
		get
		{
			return ixupOdVRHhx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ixupOdVRHhx = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && kDYpMFwoPtp != null)
			{
				kDYpMFwoPtp.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void h3dpMHXsfBk()
	{
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmRelatorio_FiacaoDWG));
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
		LabelTipoRelatorio = new Label();
		tbTerminal = new TextBox();
		TBDisp1 = new TextBox();
		TBTerm1 = new TextBox();
		TBDestino1 = new TextBox();
		TBDisp2 = new TextBox();
		TBTerm2 = new TextBox();
		TbDestino2 = new TextBox();
		TBPagina = new TextBox();
		TBSecao = new TextBox();
		TBcor = new TextBox();
		GroupBox2.SuspendLayout();
		GBCores.SuspendLayout();
		SuspendLayout();
		btApagar.FlatStyle = FlatStyle.Flat;
		btApagar.ForeColor = SystemColors.Control;
		btApagar.Image = Resources.Delete_32;
		btApagar.Location = new Point(272, 321);
		btApagar.Name = "btApagar";
		btApagar.Size = new Size(40, 42);
		btApagar.TabIndex = 41;
		btApagar.Tag = "";
		btApagar.UseVisualStyleBackColor = true;
		btExporta.FlatStyle = FlatStyle.Flat;
		btExporta.ForeColor = SystemColors.Control;
		btExporta.Image = (Image)componentResourceManager.GetObject("btExporta.Image");
		btExporta.Location = new Point(373, 321);
		btExporta.Name = "btExporta";
		btExporta.Size = new Size(40, 42);
		btExporta.TabIndex = 39;
		btExporta.UseVisualStyleBackColor = true;
		CBColunas.FormattingEnabled = true;
		CBColunas.Location = new Point(357, 49);
		CBColunas.Name = "CBColunas";
		CBColunas.Size = new Size(47, 21);
		CBColunas.TabIndex = 52;
		CBFonte.FormattingEnabled = true;
		CBFonte.Location = new Point(273, 133);
		CBFonte.Name = "CBFonte";
		CBFonte.Size = new Size(130, 21);
		CBFonte.TabIndex = 0;
		LabelStiloLinha.Location = new Point(188, 133);
		LabelStiloLinha.Name = "LabelStiloLinha";
		LabelStiloLinha.Size = new Size(79, 23);
		LabelStiloLinha.TabIndex = 49;
		LabelStiloLinha.Text = "Fonte";
		LabelStiloLinha.TextAlign = ContentAlignment.MiddleLeft;
		LabelQuantColunas.Location = new Point(188, 49);
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
		btCorTextoBloco.Location = new Point(134, 50);
		btCorTextoBloco.Name = "btCorTextoBloco";
		btCorTextoBloco.Size = new Size(47, 25);
		btCorTextoBloco.TabIndex = 1;
		btCorTextoBloco.UseVisualStyleBackColor = false;
		tbFonteBloco.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbFonteBloco.Location = new Point(357, 19);
		tbFonteBloco.Name = "tbFonteBloco";
		tbFonteBloco.Size = new Size(47, 20);
		tbFonteBloco.TabIndex = 27;
		tbFonteBloco.TextAlign = HorizontalAlignment.Center;
		LabelTamanhoFonte.Location = new Point(187, 19);
		LabelTamanhoFonte.Name = "LabelTamanhoFonte";
		LabelTamanhoFonte.Size = new Size(162, 25);
		LabelTamanhoFonte.TabIndex = 36;
		LabelTamanhoFonte.Text = "Tamanho do Fonte";
		LabelTamanhoFonte.TextAlign = ContentAlignment.MiddleLeft;
		btCorBloco.BackColor = SystemColors.ActiveCaption;
		btCorBloco.Location = new Point(134, 19);
		btCorBloco.Name = "btCorBloco";
		btCorBloco.Size = new Size(47, 25);
		btCorBloco.TabIndex = 0;
		btCorBloco.UseVisualStyleBackColor = false;
		LBDistanciaEntreColunas.Location = new Point(188, 79);
		LBDistanciaEntreColunas.Name = "LBDistanciaEntreColunas";
		LBDistanciaEntreColunas.Size = new Size(161, 25);
		LBDistanciaEntreColunas.TabIndex = 65;
		LBDistanciaEntreColunas.Text = "Distância entre Colunas";
		LBDistanciaEntreColunas.TextAlign = ContentAlignment.MiddleLeft;
		TBDisteEntreColunas.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBDisteEntreColunas.Location = new Point(357, 79);
		TBDisteEntreColunas.Name = "TBDisteEntreColunas";
		TBDisteEntreColunas.Size = new Size(47, 20);
		TBDisteEntreColunas.TabIndex = 64;
		TBDisteEntreColunas.TextAlign = HorizontalAlignment.Center;
		BTCancelar.FlatStyle = FlatStyle.Flat;
		BTCancelar.ForeColor = SystemColors.Control;
		BTCancelar.Image = Resources.Stop_32;
		BTCancelar.Location = new Point(322, 321);
		BTCancelar.Name = "BTCancelar";
		BTCancelar.Size = new Size(40, 42);
		BTCancelar.TabIndex = 66;
		BTCancelar.UseVisualStyleBackColor = true;
		TBAlturaInicialRelatorio.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBAlturaInicialRelatorio.Location = new Point(356, 163);
		TBAlturaInicialRelatorio.Name = "TBAlturaInicialRelatorio";
		TBAlturaInicialRelatorio.Size = new Size(47, 20);
		TBAlturaInicialRelatorio.TabIndex = 67;
		TBAlturaInicialRelatorio.TextAlign = HorizontalAlignment.Center;
		LabelDistanciaDaRegua.Location = new Point(188, 163);
		LabelDistanciaDaRegua.Name = "LabelDistanciaDaRegua";
		LabelDistanciaDaRegua.Size = new Size(162, 25);
		LabelDistanciaDaRegua.TabIndex = 68;
		LabelDistanciaDaRegua.Text = "Distância da Régua Horizontal";
		LabelDistanciaDaRegua.TextAlign = ContentAlignment.MiddleLeft;
		TBAlturaDoBloco.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBAlturaDoBloco.Location = new Point(357, 105);
		TBAlturaDoBloco.Name = "TBAlturaDoBloco";
		TBAlturaDoBloco.Size = new Size(47, 20);
		TBAlturaDoBloco.TabIndex = 69;
		TBAlturaDoBloco.TextAlign = HorizontalAlignment.Center;
		LBAlturaDoBloco.Location = new Point(187, 105);
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
		GroupBox2.Location = new Point(12, 304);
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
		TBNome.Size = new Size(99, 20);
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
		btCorDoJumper.Location = new Point(134, 81);
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
		GBCores.Controls.Add(btCorBloco);
		GBCores.Controls.Add(btCorDoJumper);
		GBCores.Controls.Add(btCorTextoBloco);
		GBCores.Controls.Add(LabelLinhas);
		GBCores.Controls.Add(TBAlturaDoBloco);
		GBCores.Controls.Add(LBAlturaDoBloco);
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
		GBCores.Location = new Point(12, 96);
		GBCores.Name = "GBCores";
		GBCores.Size = new Size(418, 202);
		GBCores.TabIndex = 95;
		GBCores.TabStop = false;
		GBCores.Text = "Cores";
		LabelLinhas.ImageAlign = ContentAlignment.TopLeft;
		LabelLinhas.Location = new Point(7, 19);
		LabelLinhas.Name = "LabelLinhas";
		LabelLinhas.Size = new Size(127, 25);
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
		LabelTipoRelatorio.AutoSize = true;
		LabelTipoRelatorio.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		LabelTipoRelatorio.Location = new Point(9, 27);
		LabelTipoRelatorio.Name = "LabelTipoRelatorio";
		LabelTipoRelatorio.Size = new Size(63, 13);
		LabelTipoRelatorio.TabIndex = 97;
		LabelTipoRelatorio.Text = "LabelTipo";
		tbTerminal.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbTerminal.Location = new Point(12, 70);
		tbTerminal.Name = "tbTerminal";
		tbTerminal.Size = new Size(47, 20);
		tbTerminal.TabIndex = 98;
		tbTerminal.TextAlign = HorizontalAlignment.Center;
		TBDisp1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBDisp1.Location = new Point(65, 70);
		TBDisp1.Name = "TBDisp1";
		TBDisp1.Size = new Size(47, 20);
		TBDisp1.TabIndex = 99;
		TBDisp1.TextAlign = HorizontalAlignment.Center;
		TBTerm1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBTerm1.Location = new Point(118, 70);
		TBTerm1.Name = "TBTerm1";
		TBTerm1.Size = new Size(47, 20);
		TBTerm1.TabIndex = 100;
		TBTerm1.TextAlign = HorizontalAlignment.Center;
		TBDestino1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBDestino1.Location = new Point(65, 44);
		TBDestino1.Name = "TBDestino1";
		TBDestino1.Size = new Size(100, 20);
		TBDestino1.TabIndex = 101;
		TBDestino1.TextAlign = HorizontalAlignment.Center;
		TBDisp2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBDisp2.Location = new Point(171, 70);
		TBDisp2.Name = "TBDisp2";
		TBDisp2.Size = new Size(47, 20);
		TBDisp2.TabIndex = 102;
		TBDisp2.TextAlign = HorizontalAlignment.Center;
		TBTerm2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBTerm2.Location = new Point(224, 70);
		TBTerm2.Name = "TBTerm2";
		TBTerm2.Size = new Size(47, 20);
		TBTerm2.TabIndex = 103;
		TBTerm2.TextAlign = HorizontalAlignment.Center;
		TbDestino2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TbDestino2.Location = new Point(171, 44);
		TbDestino2.Name = "TbDestino2";
		TbDestino2.Size = new Size(100, 20);
		TbDestino2.TabIndex = 104;
		TbDestino2.TextAlign = HorizontalAlignment.Center;
		TBPagina.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBPagina.Location = new Point(383, 70);
		TBPagina.Name = "TBPagina";
		TBPagina.Size = new Size(47, 20);
		TBPagina.TabIndex = 107;
		TBPagina.TextAlign = HorizontalAlignment.Center;
		TBSecao.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBSecao.Location = new Point(330, 70);
		TBSecao.Name = "TBSecao";
		TBSecao.Size = new Size(47, 20);
		TBSecao.TabIndex = 106;
		TBSecao.TextAlign = HorizontalAlignment.Center;
		TBcor.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBcor.Location = new Point(277, 70);
		TBcor.Name = "TBcor";
		TBcor.Size = new Size(47, 20);
		TBcor.TabIndex = 105;
		TBcor.TextAlign = HorizontalAlignment.Center;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(441, 391);
		Controls.Add(TBPagina);
		Controls.Add(TBSecao);
		Controls.Add(TBcor);
		Controls.Add(TbDestino2);
		Controls.Add(TBTerm2);
		Controls.Add(TBDisp2);
		Controls.Add(TBDestino1);
		Controls.Add(TBTerm1);
		Controls.Add(TBDisp1);
		Controls.Add(tbTerminal);
		Controls.Add(LabelTipoRelatorio);
		Controls.Add(LabelPainel);
		Controls.Add(GBCores);
		Controls.Add(GroupBox2);
		Controls.Add(btExporta);
		Controls.Add(btApagar);
		Controls.Add(BTCancelar);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "frmRelatorio_FiacaoDWG";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Relatório de Fiação DWG";
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
		return eFZpM0HRG4H;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		eFZpM0HRG4H = WithEventsValue;
	}

	public frmRelatorio_FiacaoDWG(DeclaracoesFiacao.structureRelFiacao[] mFiacao, string sTipoRel, int iPnSel)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected Obj, but got Unknown
		xTrpOvu02GA = "";
		dxipO6BhsKp = 0;
		LWdpOtTm7GH = "";
		wg8pOj1Tj7a = new ColorDialog();
		OEDpODdHMTJ = mFiacao;
		LWdpOtTm7GH = "RelFi_" + sTipoRel;
		xTrpOvu02GA = sTipoRel;
		dxipO6BhsKp = iPnSel;
		h3dpMHXsfBk();
		LabelPainel.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 626], " : "), Dicionario.BuscaNomeDoPainel(iPnSel)));
		if (Operators.CompareString(sTipoRel, "D", TextCompare: true) != 0)
		{
			if (Operators.CompareString(sTipoRel, "R", TextCompare: true) == 0)
			{
				LabelTipoRelatorio.Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1150], DeclaracoesGeral.mMensagem[1, 788]));
			}
		}
		else
		{
			LabelTipoRelatorio.Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1150], DeclaracoesGeral.mMensagem[1, 518]));
		}
		DeclaracoesGeral.Reguas RH = default;
		if (XDataGeral.LeXDataReguaH(ref RH))
		{
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1148]);
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
			if (Operators.CompareString(sTipoRel, "D", TextCompare: true) != 0)
			{
				LabelCorDoJumper.Enabled = true;
				btCorDoJumper.Enabled = true;
			}
			else
			{
				LabelCorDoJumper.Enabled = false;
				btCorDoJumper.Enabled = false;
			}
			tbFonteBloco.Text = "2";
			CBColunas.Items.Clear();
			CBColunas.Items.Add("1");
			CBColunas.Items.Add("2");
			CBColunas.Items.Add("3");
			CBColunas.Text = "2";
			TBAlturaInicialRelatorio.Text = "25";
			TBDisteEntreColunas.Text = Conversions.ToString(6);
			TBAlturaDoBloco.Text = Conversions.ToString(7);
			Color val = Color.FromColorIndex((ColorMethod)194, (short)7);
			btCorBloco.BackColor = val.ColorValue;
			val = Color.FromColorIndex((ColorMethod)194, (short)7);
			btCorTextoBloco.BackColor = val.ColorValue;
			val = Color.FromColorIndex((ColorMethod)194, (short)7);
			btCorDoJumper.BackColor = val.ColorValue;
			tbTerminal.Text = DeclaracoesGeral.mMensagem[1, 771].ToString().ToUpper();
			TBDisp1.Text = DeclaracoesGeral.mMensagem[1, 777].ToString().ToUpper();
			TBTerm1.Text = DeclaracoesGeral.mMensagem[1, 778].ToString().ToUpper();
			TBDisp2.Text = DeclaracoesGeral.mMensagem[1, 779].ToString().ToUpper();
			TBTerm2.Text = DeclaracoesGeral.mMensagem[1, 780].ToString().ToUpper();
			TBcor.Text = DeclaracoesGeral.mMensagem[1, 782].ToString().ToUpper();
			TBSecao.Text = DeclaracoesGeral.mMensagem[1, 781].ToString().ToUpper() + " MM²";
			TBPagina.Text = DeclaracoesGeral.mMensagem[1, 783].ToString().ToUpper();
			TBDestino1.Text = DeclaracoesGeral.mMensagem[1, 432].ToString().ToUpper() + " 1";
			TbDestino2.Text = DeclaracoesGeral.mMensagem[1, 432].ToString().ToUpper() + " 2";
			Declaracoes2.confRelFiacao.CorLinha = 7;
			Declaracoes2.confRelFiacao.CorTexto = 7;
			Declaracoes2.confRelFiacao.CorDoJumper = 7;
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
			cBZpMqfSTt6();
		}
		else
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 611]), MsgBoxStyle.Information);
		}
	}

	private void DIBpMkl7jrE(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = wg8pOj1Tj7a.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			Declaracoes2.confRelFiacao.CorLinha = wg8pOj1Tj7a.Color.ColorIndex;
			btCorBloco.BackColor = wg8pOj1Tj7a.Color.ColorValue;
		}
	}

	private void ewKpMd8Dm6X(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = wg8pOj1Tj7a.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			Declaracoes2.confRelFiacao.CorTexto = wg8pOj1Tj7a.Color.ColorIndex;
			btCorTextoBloco.BackColor = wg8pOj1Tj7a.Color.ColorValue;
		}
	}

	private void t5rpMfmeGta(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = wg8pOj1Tj7a.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			Declaracoes2.confRelFiacao.CorDoJumper = wg8pOj1Tj7a.Color.ColorIndex;
			btCorDoJumper.BackColor = wg8pOj1Tj7a.Color.ColorValue;
		}
	}

	private short u7UpMDr94Di()
	{
		DialogResult dialogResult = wg8pOj1Tj7a.ShowDialog();
		if (dialogResult != DialogResult.OK)
		{
			return 7;
		}
		return wg8pOj1Tj7a.Color.ColorIndex;
	}

	private void WwapMvYKxxI(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void cIIpM6VA6Dn(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void jyHpMt4KxC5(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.bPararRelatorio = false;
		Declaracoes2.confRelFiacao.TamanhoFonte = Conversions.ToDouble(tbFonteBloco.Text);
		checked
		{
			Declaracoes2.confRelFiacao.QuantColunas = (short)Conversions.ToInteger(CBColunas.Text);
			Declaracoes2.confRelFiacao.AlturaInicial = Conversions.ToDouble(TBAlturaInicialRelatorio.Text);
			Declaracoes2.confRelFiacao.sFonte = CBFonte.Text;
			Declaracoes2.confRelFiacao.DistEntreColunas = Conversions.ToDouble(TBDisteEntreColunas.Text);
			Declaracoes2.confRelFiacao.AlturaDoBloco = Conversions.ToDouble(TBAlturaDoBloco.Text);
			OEDpODdHMTJ[0].Terminal = tbTerminal.Text;
			OEDpODdHMTJ[0].Disp1 = TBDisp1.Text;
			OEDpODdHMTJ[0].Term1 = TBTerm1.Text;
			OEDpODdHMTJ[0].Disp2 = TBDisp2.Text;
			OEDpODdHMTJ[0].Term2 = TBTerm2.Text;
			OEDpODdHMTJ[0].Cor12 = TBcor.Text;
			OEDpODdHMTJ[0].Secao12 = TBSecao.Text;
			OEDpODdHMTJ[0].Pagina12 = TBPagina.Text;
			string sDestino = TBDestino1.Text;
			string sDestino2 = TbDestino2.Text;
			int num = Information.UBound(OEDpODdHMTJ);
			for (int i = 0; i <= num; i++)
			{
				if (Operators.CompareString(OEDpODdHMTJ[i].Tag, null, TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Tag = "";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Jumper, null, TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Jumper = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Terminal, null, TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Terminal = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Disp1, null, TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Disp1 = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Term1, null, TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Term1 = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Disp2, null, TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Disp2 = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Term2, null, TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Term2 = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Disp3, null, TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Disp3 = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Term3, null, TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Term3 = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Disp4, null, TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Disp4 = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Term4, null, TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Term4 = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Cor12, null, TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Cor12 = "";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Secao12, null, TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Secao12 = "";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Pagina12, null, TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Pagina12 = "";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Cor34, null, TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Cor34 = "";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Secao34, null, TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Secao34 = "";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Pagina34, null, TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Pagina34 = "";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Cor12, null, TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Cor12 = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Secao12, null, TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Secao12 = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Pagina12, null, TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Pagina12 = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Jumper, "", TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Jumper = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Terminal, "", TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Terminal = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Disp1, "", TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Disp1 = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Term1, "", TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Term1 = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Disp2, "", TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Disp2 = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Term2, "", TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Term2 = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Disp3, "", TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Disp3 = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Term3, "", TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Term3 = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Disp4, "", TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Disp4 = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Term4, "", TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Term4 = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Cor12, "", TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Cor12 = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Secao12, "", TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Secao12 = "##B##";
				}
				if (Operators.CompareString(OEDpODdHMTJ[i].Pagina12, "", TextCompare: true) == 0)
				{
					OEDpODdHMTJ[i].Pagina12 = "##B##";
				}
			}
			if (Operators.CompareString(xTrpOvu02GA, "D", TextCompare: true) == 0)
			{
				Relatorios_FiacaoDWG.CriaRelatorioMatrizFiacaoDispositivoDWG(OEDpODdHMTJ, Declaracoes2.confRelFiacao, xTrpOvu02GA, dxipO6BhsKp, sDestino, sDestino2);
			}
			if (Operators.CompareString(xTrpOvu02GA, "R", TextCompare: true) == 0)
			{
				Relatorios_FiacaoDWG.CriaRelatorioMatrizFiacaoBornesDWG(OEDpODdHMTJ, Declaracoes2.confRelFiacao, xTrpOvu02GA, dxipO6BhsKp, sDestino, sDestino2);
			}
		}
	}

	private void r5SpMjH8sXc(object P_0, EventArgs P_1)
	{
		Relatorios_FiacaoDWG.ApagaRelatorioDeplaquetas(ref xTrpOvu02GA, dxipO6BhsKp);
	}

	private void JJXpML9npjZ(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.bPararRelatorio = true;
		Application.DoEvents();
	}

	private void zmQpMwquDDR(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void HDOpMxGODVn(object P_0, EventArgs P_1)
	{
		if (ecmpOfNMIq1)
		{
			ecmpOfNMIq1 = false;
			cBZpMqfSTt6();
			return;
		}
		ecmpOfNMIq1 = true;
		bt1.Enabled = true;
		bt2.Enabled = true;
		bt3.Enabled = true;
		bt4.Enabled = true;
		bt5.Enabled = true;
	}

	private void CodpMbJEy0h(object P_0, EventArgs P_1)
	{
		if (ecmpOfNMIq1)
		{
			vy9pMNEFeyo(1);
			ecmpOfNMIq1 = false;
		}
		else
		{
			TBNome.Text = "";
			YVWpMa3UXKP(1);
		}
	}

	private void HQ4pMMYS0l0(object P_0, EventArgs P_1)
	{
		if (ecmpOfNMIq1)
		{
			vy9pMNEFeyo(2);
			ecmpOfNMIq1 = false;
		}
		else
		{
			TBNome.Text = "";
			YVWpMa3UXKP(2);
		}
	}

	private void eZTpMO8GoyQ(object P_0, EventArgs P_1)
	{
		if (ecmpOfNMIq1)
		{
			vy9pMNEFeyo(3);
			ecmpOfNMIq1 = false;
		}
		else
		{
			TBNome.Text = "";
			YVWpMa3UXKP(3);
		}
	}

	private void EF5pMIlItlF(object P_0, EventArgs P_1)
	{
		if (ecmpOfNMIq1)
		{
			vy9pMNEFeyo(4);
			ecmpOfNMIq1 = false;
		}
		else
		{
			TBNome.Text = "";
			YVWpMa3UXKP(4);
		}
	}

	private void FHMpM7EFOtb(object P_0, EventArgs P_1)
	{
		if (ecmpOfNMIq1)
		{
			vy9pMNEFeyo(5);
			ecmpOfNMIq1 = false;
		}
		else
		{
			TBNome.Text = "";
			YVWpMa3UXKP(5);
		}
	}

	private void cBZpMqfSTt6()
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
					DataTable dataTable = cDadosAccessComum2.LeConfiguracaoRelatorio("F", LWdpOtTm7GH);
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

	private void YVWpMa3UXKP(int P_0)
	{
		if (!clsAuxiliar.BancoValido())
		{
			return;
		}
		string sComando = "";
		cDadosAccessComum cDadosAccessComum2 = new cDadosAccessComum();
		try
		{
			cDadosAccessComum2.LeConfiguracao(ref sComando, P_0, "F", LWdpOtTm7GH);
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
		vbApM854L7J(ref obj, sComando);
		array = (object[])obj;
		checked
		{
			try
			{
				TBNome.Text = Conversions.ToString(array[num]);
				num++;
				Color val = Color.FromColorIndex((ColorMethod)194, Conversions.ToShort(array[num]));
				btCorBloco.BackColor = val.ColorValue;
				num++;
				Declaracoes2.confRelFiacao.CorLinha = val.ColorIndex;
				val = Color.FromColorIndex((ColorMethod)194, Conversions.ToShort(array[num]));
				btCorTextoBloco.BackColor = val.ColorValue;
				num++;
				Declaracoes2.confRelFiacao.CorTexto = val.ColorIndex;
				if (Operators.CompareString(xTrpOvu02GA, "R", TextCompare: true) != 0)
				{
					val = Color.FromColorIndex((ColorMethod)194, (short)7);
					btCorDoJumper.BackColor = val.ColorValue;
					num++;
					Declaracoes2.confRelFiacao.CorDoJumper = val.ColorIndex;
				}
				else
				{
					val = Color.FromColorIndex((ColorMethod)194, Conversions.ToShort(array[num]));
					btCorDoJumper.BackColor = val.ColorValue;
					num++;
					Declaracoes2.confRelFiacao.CorDoJumper = val.ColorIndex;
				}
				tbFonteBloco.Text = Conversions.ToString(array[num]);
				num++;
				CBColunas.Text = Conversions.ToString(array[num]);
				num++;
				TBDisteEntreColunas.Text = Conversions.ToString(array[num]);
				num++;
				TBAlturaDoBloco.Text = Conversions.ToString(array[num]);
				num++;
				CBFonte.Text = Conversions.ToString(array[num]);
				num++;
				TBAlturaInicialRelatorio.Text = Conversions.ToString(array[num]);
				num++;
				if (array.Count() > 11)
				{
					tbTerminal.Text = Conversions.ToString(array[num]);
					num++;
					TBDisp1.Text = Conversions.ToString(array[num]);
					num++;
					TBTerm1.Text = Conversions.ToString(array[num]);
					num++;
					TBDisp2.Text = Conversions.ToString(array[num]);
					num++;
					TBTerm2.Text = Conversions.ToString(array[num]);
					num++;
					TBcor.Text = Conversions.ToString(array[num]);
					num++;
					TBSecao.Text = Conversions.ToString(array[num]);
					num++;
					TBPagina.Text = Conversions.ToString(array[num]);
					num++;
					TBDestino1.Text = Conversions.ToString(array[num]);
					num++;
					TbDestino2.Text = Conversions.ToString(array[num]);
					num++;
				}
			}
			catch (Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void vbApM854L7J(ref object P_0, string P_1)
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

	private void vy9pMNEFeyo(int P_0)
	{
		if (!clsAuxiliar.BancoValido())
		{
			return;
		}
		string text = "";
		text = TBNome.Text;
		text = text + ";" + Conversions.ToString((int)Declaracoes2.confRelFiacao.CorLinha);
		text = text + ";" + Conversions.ToString((int)Declaracoes2.confRelFiacao.CorTexto);
		text = text + ";" + Conversions.ToString((int)Declaracoes2.confRelFiacao.CorDoJumper);
		text = text + ";" + tbFonteBloco.Text;
		text = text + ";" + CBColunas.Text;
		text = text + ";" + TBDisteEntreColunas.Text;
		text = text + ";" + TBAlturaDoBloco.Text;
		text = text + ";" + CBFonte.Text;
		text = text + ";" + TBAlturaInicialRelatorio.Text;
		text = text + ";" + tbTerminal.Text;
		text = text + ";" + TBDisp1.Text;
		text = text + ";" + TBTerm1.Text;
		text = text + ";" + TBDisp2.Text;
		text = text + ";" + TBTerm2.Text;
		text = text + ";" + TBcor.Text;
		text = text + ";" + TBSecao.Text;
		text = text + ";" + TBPagina.Text;
		text = text + ";" + TBDestino1.Text;
		text = text + ";" + TbDestino2.Text;
		cDadosAccessComum cDadosAccessComum2 = new cDadosAccessComum();
		try
		{
			cDadosAccessComum2.GravaConfiguracao(text, P_0, "F", LWdpOtTm7GH);
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
		cBZpMqfSTt6();
	}
}
