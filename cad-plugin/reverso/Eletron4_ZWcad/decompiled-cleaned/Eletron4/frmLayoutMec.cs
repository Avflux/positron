using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmLayoutMec : Form
{
	private IContainer mURpHtFNufJ;

	[CompilerGenerated]
	[AccessedThroughProperty("dgRevisao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView tXfpHjRRstJ;

	[AccessedThroughProperty("dgEquip")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView mMnpHL2d2QL;

	[AccessedThroughProperty("dgDisp")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView kdrpHwA6KrN;

	[AccessedThroughProperty("cbAlternativo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox oQ8pHxU6ybt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgDWG")]
	private DataGridView kO3pHbrr1xq;

	[AccessedThroughProperty("GroupBox1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox OmipHMnAMXX;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbReguas")]
	private RadioButton WFipHOhrXRL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbDispositivos")]
	private RadioButton ef2pHIf9Edi;

	[AccessedThroughProperty("btInserir")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button pnBpH7cZ7SE;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip MLSpHqUXWmP;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgBornes")]
	private DataGridView EPhpHaXcl1o;

	[AccessedThroughProperty("GroupBox4")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox juJpH8Ej3MF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PictureBox1")]
	private PictureBox omApHNs2wBZ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PictureBox2")]
	private PictureBox oSepHF4RYIP;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbVertical")]
	private RadioButton nPipHQXQT8D;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbhorizontal")]
	private RadioButton vTLpHPZx7ec;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("tbBlocoLayoutMec")]
	private TextBox Bc4pHc1gnq2;

	[AccessedThroughProperty("btSelecionaBlocoTopo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button Jy3pHKUJoGU;

	[AccessedThroughProperty("btSalvar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button irXpHeuPU1a;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox pXNpH2J09Bs;

	[AccessedThroughProperty("GroupBox3")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox GKhpH3eJZpt;

	[AccessedThroughProperty("cbDireitaOuCima")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox VknpHnVg4tX;

	[AccessedThroughProperty("cbEsquerdaOuBaixo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox j4tpH1uh9sf;

	[AccessedThroughProperty("CKPlaquetas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox To8pHljCrfm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTCriaTabela")]
	private Button ENkpH51Wd5w;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CKNomeVisivel")]
	private CheckBox nYlpH0VYBTO;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTCriaListaNomes")]
	private Button ijxpHRac7MS;

	[AccessedThroughProperty("GroupBox6")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox KympHmkIU66;

	[AccessedThroughProperty("CKNumero")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox xGupHXgEyuI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBTotal")]
	private Label YngpHUs4P8l;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTAtualizar")]
	private Button SjwpHyDG3pK;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox7")]
	private GroupBox TwCpHgc9T1Y;

	[AccessedThroughProperty("rbOrdemLayout")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton CKVpHA6Id8p;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbOrdemLM")]
	private RadioButton JwKpHs3IlAA;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("rbOrdemPlaquetas")]
	private RadioButton KfCpHBov78V;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTApagaRegua")]
	private Button fI7pHVnHqW3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CKIncluirRetangulo")]
	private CheckBox S10pHu8HicR;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("TBTamanho")]
	private TextBox T9tpHEVDwIA;

	[AccessedThroughProperty("Fonte")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label Q1EpHZjbIWF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBFonte")]
	private TextBox rbypHiw66c4;

	[AccessedThroughProperty("LBMargem")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label PTEpHSJ1pT4;

	private DeclaracoesFiacao.structurePnRev[] C4OpH4343jm;

	private DeclaracoesFiacao.structureRevisoes[] pf4pHCxRbUa;

	private int yespHYOtfwc;

	private string yj4pHrmEcFc;

	private int mRIpH9aB9rR;

	private bool VkipHzo7Cbq;

	private bool H6RpkWE2hSK;

	private bool WdUpkpVgBFH;

	private bool ShEpkTr7pjo;

	private bool K0jpkJwrOYf;

	private bool AT7pkhogPti;

	private string vjgpkoXVmx4;

	private DataGridViewCellStyle rIWpkGx8hTd;

	private DataGridViewCellStyle LOIpkHK8HrA;

	private DataGridViewCellStyle hY2pkkUVnqD;

	private int pRvpkdrjyCd;

	private List<string> K75pkfY3irQ;

	private int nZVpkDypB5E;

	private clsLayoutMec.StructurePlaquetasPainel[] M01pkvbkJrb;

	private clsLayoutMec.StructureLmPainel[] OX1pk6ICCBE;

	private bool h3dpktq9jJC;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return tXfpHjRRstJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = GLLpGR8oLqO;
			DataGridView dataGridView = tXfpHjRRstJ;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			tXfpHjRRstJ = value;
			dataGridView = tXfpHjRRstJ;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgEquip
	{
		[CompilerGenerated]
		get
		{
			return mMnpHL2d2QL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = BBOpGXOb7mX;
			DataGridView dataGridView = mMnpHL2d2QL;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			mMnpHL2d2QL = value;
			dataGridView = mMnpHL2d2QL;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgDisp
	{
		[CompilerGenerated]
		get
		{
			return kdrpHwA6KrN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = zGZpGgZshhZ;
			MouseEventHandler value3 = JRFpGCoqlcI;
			DataGridViewCellEventHandler value4 = eMLpHpuELCH;
			DataGridView dataGridView = kdrpHwA6KrN;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
				dataGridView.MouseUp -= value3;
				dataGridView.CellDoubleClick -= value4;
			}
			kdrpHwA6KrN = value;
			dataGridView = kdrpHwA6KrN;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
				dataGridView.MouseUp += value3;
				dataGridView.CellDoubleClick += value4;
			}
		}
	}

	internal virtual CheckBox cbAlternativo
	{
		[CompilerGenerated]
		get
		{
			return oQ8pHxU6ybt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = xQ9pGuwsfei;
			CheckBox checkBox = oQ8pHxU6ybt;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			oQ8pHxU6ybt = value;
			checkBox = oQ8pHxU6ybt;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgDWG
	{
		[CompilerGenerated]
		get
		{
			return kO3pHbrr1xq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = M8GpG5xgMp1;
			DataGridView dataGridView = kO3pHbrr1xq;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			kO3pHbrr1xq = value;
			dataGridView = kO3pHbrr1xq;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return OmipHMnAMXX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			OmipHMnAMXX = value;
		}
	}

	internal virtual RadioButton rbReguas
	{
		[CompilerGenerated]
		get
		{
			return WFipHOhrXRL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			WFipHOhrXRL = value;
		}
	}

	internal virtual RadioButton rbDispositivos
	{
		[CompilerGenerated]
		get
		{
			return ef2pHIf9Edi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tdjpGU3c1OB;
			RadioButton radioButton = ef2pHIf9Edi;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			ef2pHIf9Edi = value;
			radioButton = ef2pHIf9Edi;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button btInserir
	{
		[CompilerGenerated]
		get
		{
			return pnBpH7cZ7SE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DqgpGVxjI2H;
			Button button = pnBpH7cZ7SE;
			if (button != null)
			{
				button.Click -= value2;
			}
			pnBpH7cZ7SE = value;
			button = pnBpH7cZ7SE;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgBornes
	{
		[CompilerGenerated]
		get
		{
			return EPhpHaXcl1o;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = JTupGYoBoJZ;
			KeyEventHandler value3 = lfvpHhhkWky;
			DataGridView dataGridView = EPhpHaXcl1o;
			if (dataGridView != null)
			{
				dataGridView.MouseUp -= value2;
				dataGridView.KeyUp -= value3;
			}
			EPhpHaXcl1o = value;
			dataGridView = EPhpHaXcl1o;
			if (dataGridView != null)
			{
				dataGridView.MouseUp += value2;
				dataGridView.KeyUp += value3;
			}
		}
	}

	internal virtual GroupBox GroupBox4
	{
		[CompilerGenerated]
		get
		{
			return juJpH8Ej3MF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			juJpH8Ej3MF = value;
		}
	}

	internal virtual PictureBox PictureBox1
	{
		[CompilerGenerated]
		get
		{
			return omApHNs2wBZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			omApHNs2wBZ = value;
		}
	}

	internal virtual PictureBox PictureBox2
	{
		[CompilerGenerated]
		get
		{
			return oSepHF4RYIP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			oSepHF4RYIP = value;
		}
	}

	internal virtual RadioButton rbVertical
	{
		[CompilerGenerated]
		get
		{
			return nPipHQXQT8D;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TxApGzTaQrV;
			RadioButton radioButton = nPipHQXQT8D;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			nPipHQXQT8D = value;
			radioButton = nPipHQXQT8D;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton rbhorizontal
	{
		[CompilerGenerated]
		get
		{
			return vTLpHPZx7ec;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = C0KpHWoXvsA;
			RadioButton radioButton = vTLpHPZx7ec;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			vTLpHPZx7ec = value;
			radioButton = vTLpHPZx7ec;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual TextBox tbBlocoLayoutMec
	{
		[CompilerGenerated]
		get
		{
			return Bc4pHc1gnq2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Bc4pHc1gnq2 = value;
		}
	}

	internal virtual Button btSelecionaBlocoTopo
	{
		[CompilerGenerated]
		get
		{
			return Jy3pHKUJoGU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SSopGsEEWsq;
			Button button = Jy3pHKUJoGU;
			if (button != null)
			{
				button.Click -= value2;
			}
			Jy3pHKUJoGU = value;
			button = Jy3pHKUJoGU;
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
			return irXpHeuPU1a;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AI3pGBF70mU;
			Button button = irXpHeuPU1a;
			if (button != null)
			{
				button.Click -= value2;
			}
			irXpHeuPU1a = value;
			button = irXpHeuPU1a;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return pXNpH2J09Bs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pXNpH2J09Bs = value;
		}
	}

	internal virtual GroupBox GroupBox3
	{
		[CompilerGenerated]
		get
		{
			return GKhpH3eJZpt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			GKhpH3eJZpt = value;
		}
	}

	internal virtual CheckBox cbDireitaOuCima
	{
		[CompilerGenerated]
		get
		{
			return VknpHnVg4tX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Gf7pGrVI8Pg;
			CheckBox checkBox = VknpHnVg4tX;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			VknpHnVg4tX = value;
			checkBox = VknpHnVg4tX;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox cbEsquerdaOuBaixo
	{
		[CompilerGenerated]
		get
		{
			return j4tpH1uh9sf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = wSTpG9HTnho;
			CheckBox checkBox = j4tpH1uh9sf;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			j4tpH1uh9sf = value;
			checkBox = j4tpH1uh9sf;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox CKPlaquetas
	{
		[CompilerGenerated]
		get
		{
			return To8pHljCrfm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = oadpGSNtLCE;
			CheckBox checkBox = To8pHljCrfm;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			To8pHljCrfm = value;
			checkBox = To8pHljCrfm;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button BTCriaTabela
	{
		[CompilerGenerated]
		get
		{
			return ENkpH51Wd5w;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ItDpHTVWB6p;
			Button button = ENkpH51Wd5w;
			if (button != null)
			{
				button.Click -= value2;
			}
			ENkpH51Wd5w = value;
			button = ENkpH51Wd5w;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox CKNomeVisivel
	{
		[CompilerGenerated]
		get
		{
			return nYlpH0VYBTO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			nYlpH0VYBTO = value;
		}
	}

	internal virtual Button BTCriaListaNomes
	{
		[CompilerGenerated]
		get
		{
			return ijxpHRac7MS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = mnnpHJ5Vxhf;
			Button button = ijxpHRac7MS;
			if (button != null)
			{
				button.Click -= value2;
			}
			ijxpHRac7MS = value;
			button = ijxpHRac7MS;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox6
	{
		[CompilerGenerated]
		get
		{
			return KympHmkIU66;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KympHmkIU66 = value;
		}
	}

	internal virtual CheckBox CKNumero
	{
		[CompilerGenerated]
		get
		{
			return xGupHXgEyuI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CSKpG4rU2hF;
			CheckBox checkBox = xGupHXgEyuI;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			xGupHXgEyuI = value;
			checkBox = xGupHXgEyuI;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual Label LBTotal
	{
		[CompilerGenerated]
		get
		{
			return YngpHUs4P8l;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			YngpHUs4P8l = value;
		}
	}

	internal virtual Button BTAtualizar
	{
		[CompilerGenerated]
		get
		{
			return SjwpHyDG3pK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = x2rpHoYEw58;
			Button button = SjwpHyDG3pK;
			if (button != null)
			{
				button.Click -= value2;
			}
			SjwpHyDG3pK = value;
			button = SjwpHyDG3pK;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox7
	{
		[CompilerGenerated]
		get
		{
			return TwCpHgc9T1Y;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TwCpHgc9T1Y = value;
		}
	}

	internal virtual RadioButton rbOrdemLayout
	{
		[CompilerGenerated]
		get
		{
			return CKVpHA6Id8p;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FqtpHkbXqes;
			RadioButton radioButton = CKVpHA6Id8p;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			CKVpHA6Id8p = value;
			radioButton = CKVpHA6Id8p;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton rbOrdemLM
	{
		[CompilerGenerated]
		get
		{
			return JwKpHs3IlAA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OaxpHHRJakx;
			RadioButton radioButton = JwKpHs3IlAA;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			JwKpHs3IlAA = value;
			radioButton = JwKpHs3IlAA;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton rbOrdemPlaquetas
	{
		[CompilerGenerated]
		get
		{
			return KfCpHBov78V;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = zsEpHdFvcHF;
			RadioButton radioButton = KfCpHBov78V;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			KfCpHBov78V = value;
			radioButton = KfCpHBov78V;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button BTApagaRegua
	{
		[CompilerGenerated]
		get
		{
			return fI7pHVnHqW3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = g5jpHf5IM8W;
			Button button = fI7pHVnHqW3;
			if (button != null)
			{
				button.Click -= value2;
			}
			fI7pHVnHqW3 = value;
			button = fI7pHVnHqW3;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox CKIncluirRetangulo
	{
		[CompilerGenerated]
		get
		{
			return S10pHu8HicR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			S10pHu8HicR = value;
		}
	}

	internal virtual TextBox TBTamanho
	{
		[CompilerGenerated]
		get
		{
			return T9tpHEVDwIA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = tjopHDMknuB;
			TextBox textBox = T9tpHEVDwIA;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			T9tpHEVDwIA = value;
			textBox = T9tpHEVDwIA;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual Label Fonte
	{
		[CompilerGenerated]
		get
		{
			return Q1EpHZjbIWF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Q1EpHZjbIWF = value;
		}
	}

	internal virtual TextBox TBFonte
	{
		[CompilerGenerated]
		get
		{
			return rbypHiw66c4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			rbypHiw66c4 = value;
		}
	}

	internal virtual Label LBMargem
	{
		[CompilerGenerated]
		get
		{
			return PTEpHSJ1pT4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PTEpHSJ1pT4 = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && mURpHtFNufJ != null)
			{
				mURpHtFNufJ.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ohHpGlSZj7r()
	{
		mURpHtFNufJ = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmLayoutMec));
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		dgRevisao = new DataGridView();
		dgEquip = new DataGridView();
		dgDisp = new DataGridView();
		cbAlternativo = new CheckBox();
		dgDWG = new DataGridView();
		GroupBox1 = new GroupBox();
		rbReguas = new RadioButton();
		rbDispositivos = new RadioButton();
		btInserir = new Button();
		FDqpBiUmZij(new ToolTip(mURpHtFNufJ));
		dgBornes = new DataGridView();
		GroupBox4 = new GroupBox();
		btSalvar = new Button();
		tbBlocoLayoutMec = new TextBox();
		btSelecionaBlocoTopo = new Button();
		PictureBox1 = new PictureBox();
		PictureBox2 = new PictureBox();
		rbVertical = new RadioButton();
		rbhorizontal = new RadioButton();
		GroupBox2 = new GroupBox();
		CKNomeVisivel = new CheckBox();
		CKPlaquetas = new CheckBox();
		GroupBox3 = new GroupBox();
		Fonte = new Label();
		TBFonte = new TextBox();
		cbDireitaOuCima = new CheckBox();
		cbEsquerdaOuBaixo = new CheckBox();
		BTCriaTabela = new Button();
		BTCriaListaNomes = new Button();
		GroupBox6 = new GroupBox();
		TBTamanho = new TextBox();
		CKIncluirRetangulo = new CheckBox();
		BTAtualizar = new Button();
		CKNumero = new CheckBox();
		LBMargem = new Label();
		LBTotal = new Label();
		GroupBox7 = new GroupBox();
		rbOrdemPlaquetas = new RadioButton();
		rbOrdemLayout = new RadioButton();
		rbOrdemLM = new RadioButton();
		BTApagaRegua = new Button();
		((ISupportInitialize)dgRevisao).BeginInit();
		((ISupportInitialize)dgEquip).BeginInit();
		((ISupportInitialize)dgDisp).BeginInit();
		((ISupportInitialize)dgDWG).BeginInit();
		GroupBox1.SuspendLayout();
		((ISupportInitialize)dgBornes).BeginInit();
		GroupBox4.SuspendLayout();
		((ISupportInitialize)PictureBox1).BeginInit();
		((ISupportInitialize)PictureBox2).BeginInit();
		GroupBox2.SuspendLayout();
		GroupBox3.SuspendLayout();
		GroupBox6.SuspendLayout();
		GroupBox7.SuspendLayout();
		SuspendLayout();
		dgRevisao.AllowUserToAddRows = false;
		dgRevisao.AllowUserToDeleteRows = false;
		dgRevisao.AllowUserToOrderColumns = true;
		dgRevisao.AllowUserToResizeRows = false;
		dgRevisao.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		dgRevisao.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgRevisao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgRevisao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgRevisao.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgRevisao.Location = new Point(11, 231);
		dgRevisao.MultiSelect = false;
		dgRevisao.Name = "dgRevisao";
		dgRevisao.ReadOnly = true;
		dgRevisao.RowHeadersVisible = false;
		dgRevisao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRevisao.Size = new Size(280, 102);
		dgRevisao.TabIndex = 3;
		dgEquip.AllowUserToAddRows = false;
		dgEquip.AllowUserToDeleteRows = false;
		dgEquip.AllowUserToOrderColumns = true;
		dgEquip.AllowUserToResizeRows = false;
		dgEquip.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgEquip.BackgroundColor = Color.White;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dgEquip.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgEquip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgEquip.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgEquip.Location = new Point(12, 339);
		dgEquip.MultiSelect = false;
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(279, 213);
		dgEquip.TabIndex = 8;
		dgDisp.AllowUserToAddRows = false;
		dgDisp.AllowUserToDeleteRows = false;
		dgDisp.AllowUserToOrderColumns = true;
		dgDisp.AllowUserToResizeRows = false;
		dgDisp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		dgDisp.BackgroundColor = Color.White;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		dgDisp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		dgDisp.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgDisp.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgDisp.Location = new Point(296, 12);
		dgDisp.MultiSelect = false;
		dgDisp.Name = "dgDisp";
		dgDisp.ReadOnly = true;
		dgDisp.RowHeadersVisible = false;
		dgDisp.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgDisp.Size = new Size(161, 540);
		dgDisp.TabIndex = 9;
		cbAlternativo.AutoSize = true;
		cbAlternativo.Location = new Point(6, 9);
		cbAlternativo.Name = "cbAlternativo";
		cbAlternativo.Size = new Size(76, 17);
		cbAlternativo.TabIndex = 16;
		cbAlternativo.Text = "Alternativo";
		cbAlternativo.UseVisualStyleBackColor = true;
		dgDWG.AllowUserToAddRows = false;
		dgDWG.AllowUserToDeleteRows = false;
		dgDWG.AllowUserToOrderColumns = true;
		dgDWG.AllowUserToResizeRows = false;
		dgDWG.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		dgDWG.BackgroundColor = Color.White;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = SystemColors.Control;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		dgDWG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		dgDWG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgDWG.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgDWG.Location = new Point(11, 12);
		dgDWG.MultiSelect = false;
		dgDWG.Name = "dgDWG";
		dgDWG.ReadOnly = true;
		dgDWG.RowHeadersVisible = false;
		dgDWG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgDWG.Size = new Size(280, 216);
		dgDWG.TabIndex = 17;
		GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		GroupBox1.Controls.Add(rbReguas);
		GroupBox1.Controls.Add(rbDispositivos);
		GroupBox1.Location = new Point(463, 7);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(161, 55);
		GroupBox1.TabIndex = 18;
		GroupBox1.TabStop = false;
		rbReguas.AutoSize = true;
		rbReguas.Location = new Point(6, 35);
		rbReguas.Name = "rbReguas";
		rbReguas.Size = new Size(113, 17);
		rbReguas.TabIndex = 1;
		rbReguas.Text = "Réguas de Bornes";
		rbReguas.UseVisualStyleBackColor = true;
		rbDispositivos.AutoSize = true;
		rbDispositivos.Checked = true;
		rbDispositivos.Location = new Point(6, 15);
		rbDispositivos.Name = "rbDispositivos";
		rbDispositivos.Size = new Size(81, 17);
		rbDispositivos.TabIndex = 0;
		rbDispositivos.TabStop = true;
		rbDispositivos.Text = "Dispositivos";
		rbDispositivos.UseVisualStyleBackColor = true;
		btInserir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btInserir.FlatStyle = FlatStyle.Flat;
		btInserir.ForeColor = SystemColors.Control;
		btInserir.Image = (Image)componentResourceManager.GetObject("btInserir.Image");
		btInserir.Location = new Point(575, 562);
		btInserir.Name = "btInserir";
		btInserir.Size = new Size(42, 42);
		btInserir.TabIndex = 40;
		btInserir.UseVisualStyleBackColor = true;
		dgBornes.AllowUserToAddRows = false;
		dgBornes.AllowUserToDeleteRows = false;
		dgBornes.AllowUserToResizeRows = false;
		dgBornes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		dgBornes.BackgroundColor = Color.White;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle5.BackColor = SystemColors.Control;
		dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
		dgBornes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
		dgBornes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgBornes.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgBornes.Location = new Point(463, 391);
		dgBornes.Name = "dgBornes";
		dgBornes.ReadOnly = true;
		dgBornes.RowHeadersVisible = false;
		dgBornes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgBornes.Size = new Size(161, 141);
		dgBornes.TabIndex = 43;
		dgBornes.Visible = false;
		GroupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		GroupBox4.Controls.Add(btSalvar);
		GroupBox4.Controls.Add(tbBlocoLayoutMec);
		GroupBox4.Controls.Add(btSelecionaBlocoTopo);
		GroupBox4.Location = new Point(11, 557);
		GroupBox4.Name = "GroupBox4";
		GroupBox4.Size = new Size(446, 49);
		GroupBox4.TabIndex = 47;
		GroupBox4.TabStop = false;
		GroupBox4.Text = "Bloco";
		btSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btSalvar.FlatStyle = FlatStyle.Flat;
		btSalvar.ForeColor = SystemColors.Control;
		btSalvar.Image = (Image)componentResourceManager.GetObject("btSalvar.Image");
		btSalvar.Location = new Point(417, 17);
		btSalvar.Name = "btSalvar";
		btSalvar.Size = new Size(22, 22);
		btSalvar.TabIndex = 163;
		btSalvar.UseVisualStyleBackColor = true;
		tbBlocoLayoutMec.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		tbBlocoLayoutMec.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbBlocoLayoutMec.Location = new Point(10, 19);
		tbBlocoLayoutMec.Name = "tbBlocoLayoutMec";
		tbBlocoLayoutMec.Size = new Size(368, 20);
		tbBlocoLayoutMec.TabIndex = 161;
		btSelecionaBlocoTopo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btSelecionaBlocoTopo.FlatStyle = FlatStyle.Flat;
		btSelecionaBlocoTopo.ForeColor = SystemColors.Control;
		btSelecionaBlocoTopo.Image = (Image)componentResourceManager.GetObject("btSelecionaBlocoTopo.Image");
		btSelecionaBlocoTopo.Location = new Point(384, 17);
		btSelecionaBlocoTopo.Name = "btSelecionaBlocoTopo";
		btSelecionaBlocoTopo.Size = new Size(22, 22);
		btSelecionaBlocoTopo.TabIndex = 162;
		btSelecionaBlocoTopo.UseVisualStyleBackColor = true;
		PictureBox1.BackgroundImage = (Image)componentResourceManager.GetObject("PictureBox1.BackgroundImage");
		PictureBox1.BackgroundImageLayout = ImageLayout.None;
		PictureBox1.Location = new Point(105, 22);
		PictureBox1.Name = "PictureBox1";
		PictureBox1.Size = new Size(24, 24);
		PictureBox1.TabIndex = 48;
		PictureBox1.TabStop = false;
		PictureBox2.BackgroundImage = (Image)componentResourceManager.GetObject("PictureBox2.BackgroundImage");
		PictureBox2.BackgroundImageLayout = ImageLayout.None;
		PictureBox2.Location = new Point(33, 22);
		PictureBox2.Name = "PictureBox2";
		PictureBox2.Size = new Size(24, 24);
		PictureBox2.TabIndex = 49;
		PictureBox2.TabStop = false;
		rbVertical.AutoSize = true;
		rbVertical.Location = new Point(16, 27);
		rbVertical.Name = "rbVertical";
		rbVertical.Size = new Size(14, 13);
		rbVertical.TabIndex = 52;
		rbVertical.TabStop = true;
		rbVertical.UseVisualStyleBackColor = true;
		rbhorizontal.AutoSize = true;
		rbhorizontal.Location = new Point(87, 27);
		rbhorizontal.Name = "rbhorizontal";
		rbhorizontal.Size = new Size(14, 13);
		rbhorizontal.TabIndex = 51;
		rbhorizontal.TabStop = true;
		rbhorizontal.UseVisualStyleBackColor = true;
		GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		GroupBox2.Controls.Add(cbAlternativo);
		GroupBox2.Location = new Point(463, 61);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(161, 34);
		GroupBox2.TabIndex = 52;
		GroupBox2.TabStop = false;
		CKNomeVisivel.AutoSize = true;
		CKNomeVisivel.Checked = true;
		CKNomeVisivel.CheckState = CheckState.Checked;
		CKNomeVisivel.Location = new Point(6, 12);
		CKNomeVisivel.Name = "CKNomeVisivel";
		CKNomeVisivel.Size = new Size(87, 17);
		CKNomeVisivel.TabIndex = 42;
		CKNomeVisivel.Text = "Nome Visivel";
		CKNomeVisivel.UseVisualStyleBackColor = true;
		CKPlaquetas.AutoSize = true;
		CKPlaquetas.Location = new Point(6, 34);
		CKPlaquetas.Name = "CKPlaquetas";
		CKPlaquetas.Size = new Size(104, 17);
		CKPlaquetas.TabIndex = 43;
		CKPlaquetas.Text = "Incluir Plaquetas";
		CKPlaquetas.UseVisualStyleBackColor = true;
		GroupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		GroupBox3.Controls.Add(rbVertical);
		GroupBox3.Controls.Add(Fonte);
		GroupBox3.Controls.Add(rbhorizontal);
		GroupBox3.Controls.Add(TBFonte);
		GroupBox3.Controls.Add(PictureBox1);
		GroupBox3.Controls.Add(PictureBox2);
		GroupBox3.Controls.Add(cbDireitaOuCima);
		GroupBox3.Controls.Add(cbEsquerdaOuBaixo);
		GroupBox3.Location = new Point(463, 274);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(161, 111);
		GroupBox3.TabIndex = 53;
		GroupBox3.TabStop = false;
		Fonte.Location = new Point(112, 58);
		Fonte.Name = "Fonte";
		Fonte.Size = new Size(43, 19);
		Fonte.TabIndex = 164;
		Fonte.Text = "Fonte";
		Fonte.TextAlign = ContentAlignment.MiddleRight;
		TBFonte.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBFonte.Location = new Point(128, 78);
		TBFonte.Multiline = true;
		TBFonte.Name = "TBFonte";
		TBFonte.Size = new Size(27, 18);
		TBFonte.TabIndex = 163;
		TBFonte.Text = "2";
		cbDireitaOuCima.AutoSize = true;
		cbDireitaOuCima.Location = new Point(6, 65);
		cbDireitaOuCima.Name = "cbDireitaOuCima";
		cbDireitaOuCima.Size = new Size(56, 17);
		cbDireitaOuCima.TabIndex = 16;
		cbDireitaOuCima.Text = "Direita";
		cbDireitaOuCima.UseVisualStyleBackColor = true;
		cbEsquerdaOuBaixo.AutoSize = true;
		cbEsquerdaOuBaixo.Location = new Point(6, 85);
		cbEsquerdaOuBaixo.Name = "cbEsquerdaOuBaixo";
		cbEsquerdaOuBaixo.Size = new Size(71, 17);
		cbEsquerdaOuBaixo.TabIndex = 42;
		cbEsquerdaOuBaixo.Text = "Esquerda";
		cbEsquerdaOuBaixo.UseVisualStyleBackColor = true;
		BTCriaTabela.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		BTCriaTabela.FlatStyle = FlatStyle.Flat;
		BTCriaTabela.ForeColor = SystemColors.Control;
		BTCriaTabela.Image = Resources.ListaMec_32;
		BTCriaTabela.Location = new Point(527, 562);
		BTCriaTabela.Name = "BTCriaTabela";
		BTCriaTabela.Size = new Size(42, 42);
		BTCriaTabela.TabIndex = 40;
		BTCriaTabela.UseVisualStyleBackColor = true;
		BTCriaListaNomes.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		BTCriaListaNomes.FlatStyle = FlatStyle.Flat;
		BTCriaListaNomes.ForeColor = SystemColors.Control;
		BTCriaListaNomes.Image = Resources.ListaLayout_32;
		BTCriaListaNomes.Location = new Point(479, 562);
		BTCriaListaNomes.Name = "BTCriaListaNomes";
		BTCriaListaNomes.Size = new Size(42, 42);
		BTCriaListaNomes.TabIndex = 54;
		BTCriaListaNomes.UseVisualStyleBackColor = true;
		GroupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		GroupBox6.Controls.Add(TBTamanho);
		GroupBox6.Controls.Add(CKIncluirRetangulo);
		GroupBox6.Controls.Add(BTAtualizar);
		GroupBox6.Controls.Add(CKNumero);
		GroupBox6.Controls.Add(LBMargem);
		GroupBox6.Controls.Add(CKNomeVisivel);
		GroupBox6.Controls.Add(CKPlaquetas);
		GroupBox6.Location = new Point(463, 166);
		GroupBox6.Name = "GroupBox6";
		GroupBox6.Size = new Size(161, 106);
		GroupBox6.TabIndex = 55;
		GroupBox6.TabStop = false;
		TBTamanho.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TBTamanho.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		TBTamanho.Location = new Point(129, 80);
		TBTamanho.Multiline = true;
		TBTamanho.Name = "TBTamanho";
		TBTamanho.Size = new Size(27, 18);
		TBTamanho.TabIndex = 162;
		TBTamanho.Text = "0.0";
		CKIncluirRetangulo.AutoSize = true;
		CKIncluirRetangulo.Location = new Point(6, 82);
		CKIncluirRetangulo.Name = "CKIncluirRetangulo";
		CKIncluirRetangulo.Size = new Size(122, 17);
		CKIncluirRetangulo.TabIndex = 60;
		CKIncluirRetangulo.Text = "Contornar Plaquetas";
		CKIncluirRetangulo.UseVisualStyleBackColor = true;
		BTAtualizar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BTAtualizar.FlatStyle = FlatStyle.Flat;
		BTAtualizar.ForeColor = SystemColors.Control;
		BTAtualizar.Image = Resources.Sincroniza_32;
		BTAtualizar.Location = new Point(124, 18);
		BTAtualizar.Name = "BTAtualizar";
		BTAtualizar.Size = new Size(30, 30);
		BTAtualizar.TabIndex = 59;
		BTAtualizar.UseVisualStyleBackColor = true;
		CKNumero.AutoSize = true;
		CKNumero.Location = new Point(6, 54);
		CKNumero.Name = "CKNumero";
		CKNumero.Size = new Size(94, 17);
		CKNumero.TabIndex = 56;
		CKNumero.Text = "Incluir Numero";
		CKNumero.UseVisualStyleBackColor = true;
		LBMargem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		LBMargem.Location = new Point(54, 60);
		LBMargem.Name = "LBMargem";
		LBMargem.Size = new Size(102, 19);
		LBMargem.TabIndex = 57;
		LBMargem.Text = "margem";
		LBMargem.TextAlign = ContentAlignment.MiddleRight;
		LBTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		LBTotal.Location = new Point(463, 534);
		LBTotal.Name = "LBTotal";
		LBTotal.Size = new Size(161, 19);
		LBTotal.TabIndex = 57;
		LBTotal.Text = "Total";
		LBTotal.TextAlign = ContentAlignment.MiddleRight;
		GroupBox7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		GroupBox7.Controls.Add(rbOrdemPlaquetas);
		GroupBox7.Controls.Add(rbOrdemLayout);
		GroupBox7.Controls.Add(rbOrdemLM);
		GroupBox7.Location = new Point(463, 94);
		GroupBox7.Name = "GroupBox7";
		GroupBox7.Size = new Size(161, 73);
		GroupBox7.TabIndex = 58;
		GroupBox7.TabStop = false;
		rbOrdemPlaquetas.AutoSize = true;
		rbOrdemPlaquetas.Location = new Point(6, 49);
		rbOrdemPlaquetas.Name = "rbOrdemPlaquetas";
		rbOrdemPlaquetas.Size = new Size(112, 17);
		rbOrdemPlaquetas.TabIndex = 61;
		rbOrdemPlaquetas.Text = "rbOrdemPlaquetas";
		rbOrdemPlaquetas.UseVisualStyleBackColor = true;
		rbOrdemLayout.AutoSize = true;
		rbOrdemLayout.Checked = true;
		rbOrdemLayout.Location = new Point(6, 29);
		rbOrdemLayout.Name = "rbOrdemLayout";
		rbOrdemLayout.Size = new Size(97, 17);
		rbOrdemLayout.TabIndex = 59;
		rbOrdemLayout.TabStop = true;
		rbOrdemLayout.Text = "rbOrdemLayout";
		rbOrdemLayout.UseVisualStyleBackColor = true;
		rbOrdemLM.AutoSize = true;
		rbOrdemLM.Location = new Point(6, 9);
		rbOrdemLM.Name = "rbOrdemLM";
		rbOrdemLM.Size = new Size(80, 17);
		rbOrdemLM.TabIndex = 60;
		rbOrdemLM.Text = "rbOrdemLM";
		rbOrdemLM.UseVisualStyleBackColor = true;
		BTApagaRegua.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		BTApagaRegua.FlatStyle = FlatStyle.Flat;
		BTApagaRegua.ForeColor = SystemColors.Control;
		BTApagaRegua.Image = Resources.Delete_32;
		BTApagaRegua.Location = new Point(531, 548);
		BTApagaRegua.Name = "BTApagaRegua";
		BTApagaRegua.Size = new Size(40, 40);
		BTApagaRegua.TabIndex = 59;
		BTApagaRegua.Tag = "";
		BTApagaRegua.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(631, 611);
		Controls.Add(GroupBox7);
		Controls.Add(BTApagaRegua);
		Controls.Add(BTCriaListaNomes);
		Controls.Add(GroupBox4);
		Controls.Add(BTCriaTabela);
		Controls.Add(btInserir);
		Controls.Add(dgDWG);
		Controls.Add(dgDisp);
		Controls.Add(dgEquip);
		Controls.Add(dgRevisao);
		Controls.Add(GroupBox2);
		Controls.Add(GroupBox1);
		Controls.Add(GroupBox6);
		Controls.Add(dgBornes);
		Controls.Add(GroupBox3);
		Controls.Add(LBTotal);
		MaximumSize = new Size(800, 1000);
		MinimumSize = new Size(585, 650);
		Name = "frmLayoutMec";
		ShowInTaskbar = false;
		Text = "Layout Mecânico";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		((ISupportInitialize)dgDisp).EndInit();
		((ISupportInitialize)dgDWG).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		((ISupportInitialize)dgBornes).EndInit();
		GroupBox4.ResumeLayout(performLayout: false);
		GroupBox4.PerformLayout();
		((ISupportInitialize)PictureBox1).EndInit();
		((ISupportInitialize)PictureBox2).EndInit();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox3.PerformLayout();
		GroupBox6.ResumeLayout(performLayout: false);
		GroupBox6.PerformLayout();
		GroupBox7.ResumeLayout(performLayout: false);
		GroupBox7.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return MLSpHqUXWmP;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		MLSpHqUXWmP = WithEventsValue;
	}

	public frmLayoutMec()
	{
		Resize += oHtpHGk5awG;
		C4OpH4343jm = new DeclaracoesFiacao.structurePnRev[1];
		pf4pHCxRbUa = new DeclaracoesFiacao.structureRevisoes[1];
		yespHYOtfwc = 0;
		yj4pHrmEcFc = "";
		mRIpH9aB9rR = 0;
		VkipHzo7Cbq = false;
		H6RpkWE2hSK = false;
		WdUpkpVgBFH = false;
		ShEpkTr7pjo = false;
		K0jpkJwrOYf = false;
		AT7pkhogPti = false;
		vjgpkoXVmx4 = "";
		rIWpkGx8hTd = new DataGridViewCellStyle();
		LOIpkHK8HrA = new DataGridViewCellStyle();
		hY2pkkUVnqD = new DataGridViewCellStyle();
		pRvpkdrjyCd = 1;
		K75pkfY3irQ = new List<string>();
		nZVpkDypB5E = 1;
		h3dpktq9jJC = false;
		try
		{
			if (!Geral.ExisteForm("frmLayoutMec"))
			{
				ohHpGlSZj7r();
				rbOrdemLayout.Checked = true;
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 867]);
				cbAlternativo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 785]);
				rbOrdemLayout.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 795]);
				rbOrdemLM.Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1082], DeclaracoesGeral.mMensagem[1, 1084]));
				rbOrdemPlaquetas.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1082], " "), DeclaracoesGeral.mMensagem[1, 1764]));
				rbDispositivos.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 518]);
				rbReguas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 788]);
				GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1577]);
				GroupBox4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 824]);
				w8dpBZ0kvSD().SetToolTip(btInserir, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 840]));
				w8dpBZ0kvSD().SetToolTip(btSelecionaBlocoTopo, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1353]));
				w8dpBZ0kvSD().SetToolTip(btSalvar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 841]));
				w8dpBZ0kvSD().SetToolTip(rbhorizontal, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 844]));
				w8dpBZ0kvSD().SetToolTip(rbVertical, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 845]));
				w8dpBZ0kvSD().SetToolTip(BTCriaListaNomes, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1695]));
				w8dpBZ0kvSD().SetToolTip(BTCriaTabela, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1696]));
				cbDireitaOuCima.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1578]);
				cbEsquerdaOuBaixo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1579]);
				CKNomeVisivel.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 649]);
				CKPlaquetas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1694]);
				CKNumero.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1692]);
				CKIncluirRetangulo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1888]);
				LBMargem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1913]);
				GroupBox3.Visible = false;
				BTApagaRegua.Visible = false;
				BTApagaRegua.Location = new Point(BTCriaTabela.Location.X, BTCriaTabela.Location.Y);
				TBTamanho.Text = Conversions.ToString(0.5);
				TBFonte.Text = Conversions.ToString(1.5);
				rIWpkGx8hTd.BackColor = Color.LightCoral;
				LOIpkHK8HrA.BackColor = Color.LightGreen;
				hY2pkkUVnqD.BackColor = Color.Brown;
				cDadosAccess.carregaDadosDWG();
				CKPlaquetas.Enabled = false;
				Application.ShowModelessDialog((Form)this);
				CarregaDGDWG();
				rbDispositivos.Checked = true;
				cbAlternativo.Checked = false;
				rbOrdemLayout.Checked = true;
				rbVertical.Checked = true;
				cbDireitaOuCima.Checked = false;
				cbEsquerdaOuBaixo.Checked = false;
				if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
				{
					Left = 0;
				}
				rbOrdemLM.Enabled = clsLayoutMec.ExistePlaquetaLM(mRIpH9aB9rR);
				rbOrdemPlaquetas.Enabled = clsLayoutMec.TemPlaquetas(mRIpH9aB9rR);
				if (!rbOrdemLM.Enabled)
				{
					CKNumero.Checked = false;
				}
				if (!rbOrdemLayout.Enabled)
				{
					CKPlaquetas.Checked = false;
				}
				DESELECIONA(true);
				clsLayoutMec.AtualizaOsTextosAntigos();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void M8GpG5xgMp1(object P_0, EventArgs P_1)
	{
		VkipHzo7Cbq = true;
		dgRevisao.Rows.Clear();
		VkipHzo7Cbq = false;
		H6RpkWE2hSK = true;
		dgEquip.Rows.Clear();
		H6RpkWE2hSK = false;
		WdUpkpVgBFH = true;
		dgDisp.Rows.Clear();
		WdUpkpVgBFH = false;
		ShEpkTr7pjo = true;
		dgBornes.Rows.Clear();
		ShEpkTr7pjo = false;
		rL5pG0DlxOb();
	}

	private void rL5pG0DlxOb()
	{
		yespHYOtfwc = Conversions.ToInteger(dgDWG.SelectedRows[0].Cells[0].Value);
		pf4pHCxRbUa = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			cDadosAccessFiacao2.CarregaRevisoesDwgCorrente(yespHYOtfwc, ref pf4pHCxRbUa);
			formataDGRevisao();
			int num = Information.UBound(pf4pHCxRbUa);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				dgRevisao.Rows.Add(pf4pHCxRbUa[i].revisao);
			}
			atualizaRevisao();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		finally
		{
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	private void GLLpGR8oLqO(object P_0, EventArgs P_1)
	{
		rbOrdemLM.Enabled = false;
		rbOrdemPlaquetas.Enabled = false;
		if (!VkipHzo7Cbq)
		{
			YCgpGmfjmkR();
		}
	}

	private void YCgpGmfjmkR()
	{
		rbOrdemLM.Enabled = false;
		rbOrdemPlaquetas.Enabled = false;
		CarregaPnRev();
		try
		{
			if (dgRevisao.SelectedRows.Count != 1)
			{
				return;
			}
			yj4pHrmEcFc = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
			formataDGEquip();
			int num = Information.UBound(C4OpH4343jm);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(C4OpH4343jm[i].revisao, yj4pHrmEcFc, TextCompare: true) == 0)
				{
					mRIpH9aB9rR = C4OpH4343jm[i].painel;
					dgEquip.Rows.Add(C4OpH4343jm[i].painel, Dicionario.BuscaNomeDoPainel(C4OpH4343jm[i].painel));
				}
			}
			AtualizaEquip();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		finally
		{
		}
	}

	public void CarregaPnRev()
	{
		C4OpH4343jm = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (Information.UBound(pf4pHCxRbUa) > 0)
			{
				int num = Information.UBound(pf4pHCxRbUa);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessFiacao2.CarregaPnRev(yespHYOtfwc, pf4pHCxRbUa[i].revisao, ref C4OpH4343jm);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		finally
		{
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	private void BBOpGXOb7mX(object P_0, EventArgs P_1)
	{
		WdUpkpVgBFH = true;
		dgDisp.Rows.Clear();
		WdUpkpVgBFH = false;
		ShEpkTr7pjo = true;
		dgBornes.Rows.Clear();
		ShEpkTr7pjo = false;
		if (!H6RpkWE2hSK)
		{
			tHVpGyfsea0();
		}
		FdwpGZjmHh8();
		h3dpktq9jJC = true;
		AtualizaDG_LM_PLAQUETAS();
		h3dpktq9jJC = false;
		DESELECIONA(false);
	}

	private void tdjpGU3c1OB(object P_0, EventArgs P_1)
	{
		if (!rbDispositivos.Checked)
		{
			if (rbReguas.Checked)
			{
				WdUpkpVgBFH = true;
				formataDGDisp();
				formataDGBornes();
				WdUpkpVgBFH = false;
				if (!H6RpkWE2hSK)
				{
					tHVpGyfsea0();
				}
				GroupBox3.Visible = true;
				wDrpGAYVxuh();
				dgBornes.Visible = rbReguas.Checked;
				LBTotal.Visible = rbReguas.Checked;
				BTCriaListaNomes.Visible = false;
				BTCriaTabela.Visible = false;
				BTApagaRegua.Visible = true;
			}
			return;
		}
		WdUpkpVgBFH = true;
		formataDGDisp();
		WdUpkpVgBFH = false;
		if (!H6RpkWE2hSK)
		{
			tHVpGyfsea0();
		}
		GroupBox3.Visible = false;
		ShEpkTr7pjo = true;
		dgBornes.Rows.Clear();
		ShEpkTr7pjo = false;
		BTCriaListaNomes.Visible = true;
		BTCriaTabela.Visible = true;
		BTApagaRegua.Visible = false;
		AtualizaDGDisp();
		dgBornes.Visible = rbReguas.Checked;
		LBTotal.Visible = rbReguas.Checked;
		FdwpGZjmHh8();
		DESELECIONA(false);
		if (!rbOrdemLM.Enabled)
		{
			CKNumero.Checked = false;
		}
		if (!rbOrdemLayout.Enabled)
		{
			CKPlaquetas.Checked = false;
		}
		CKPlaquetas.Enabled = rbOrdemPlaquetas.Enabled;
		CKNumero.Enabled = rbOrdemLM.Enabled;
	}

	private void tHVpGyfsea0()
	{
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		checked
		{
			try
			{
				if (dgEquip.SelectedRows.Count == 1)
				{
					mRIpH9aB9rR = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
					DeclaracoesFiacao.structureVF[] mDisp = new DeclaracoesFiacao.structureVF[1];
					cDadosAccessFiacao2.CarregaDispTipoIndexModelo(yespHYOtfwc, yj4pHrmEcFc, mRIpH9aB9rR, ref mDisp, bAdicionaDispSemFiacao: true);
					K0jpkJwrOYf = clsLayoutMec.CarregaPlaquetasDoPainel(ref M01pkvbkJrb, mRIpH9aB9rR);
					CKPlaquetas.Enabled = K0jpkJwrOYf;
					WdUpkpVgBFH = true;
					dgDisp.Rows.Clear();
					WdUpkpVgBFH = false;
					int num = Information.UBound(mDisp);
					for (int i = 1; i <= num; i++)
					{
						string text = "";
						if (Information.UBound(M01pkvbkJrb) > 0)
						{
							int num2 = Information.UBound(M01pkvbkJrb);
							for (int j = 1; j <= num2; j++)
							{
								if ((Conversions.ToDouble(M01pkvbkJrb[j].Painel) == (double)mRIpH9aB9rR) & (Operators.CompareString(M01pkvbkJrb[j].Disp, mDisp[i].Tag, TextCompare: true) == 0))
								{
									text = M01pkvbkJrb[j].Etiq;
									break;
								}
							}
						}
						if (!((Operators.CompareString(mDisp[i].Tipo, "B", TextCompare: true) != 0) & rbDispositivos.Checked))
						{
							if ((Operators.CompareString(mDisp[i].Tipo, "B", TextCompare: true) == 0) & rbReguas.Checked)
							{
								dgDisp.Rows.Add(mDisp[i].Tag, mDisp[i].Alternativo, mDisp[i].Tipo, mDisp[i].IndexModelo.ToString(), mDisp[i].PosOrdem.ToString(), "", 0, "");
							}
							continue;
						}
						dgDisp.Rows.Add(mDisp[i].Tag, mDisp[i].Alternativo, mDisp[i].Tipo, mDisp[i].IndexModelo.ToString(), mDisp[i].PosOrdem.ToString(), mDisp[i].BlocoLayout, mDisp[i].Indice, text, 0, 0, 0, mDisp[i].PosOrdem, mDisp[i].Handle);
						int num3 = 0;
						do
						{
							dgDisp.Rows[dgDisp.RowCount - 1].Cells[num3].Style = LOIpkHK8HrA;
							num3++;
						}
						while (num3 <= 7);
					}
					yumpGEpKaeY();
					DESELECIONA(false);
					AtualizaDGDisp();
					if (rbDispositivos.Checked && dgDisp.Rows.Count > 0)
					{
						dgDisp.Rows[0].Selected = true;
						dgDisp.Rows[0].Selected = false;
					}
				}
				wHFpHvihism();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				cDadosAccessFiacao2.fechaConexao();
			}
		}
	}

	private void zGZpGgZshhZ(object P_0, EventArgs P_1)
	{
		if (ShEpkTr7pjo || dgDisp.SelectedRows.Count == 0)
		{
			return;
		}
		checked
		{
			if (!rbDispositivos.Checked)
			{
				if (!rbReguas.Checked)
				{
					return;
				}
				ShEpkTr7pjo = true;
				dgBornes.Rows.Clear();
				ShEpkTr7pjo = false;
				DeclaracoesFiacao.structureFiacao[] mfiacao = new DeclaracoesFiacao.structureFiacao[1];
				cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
				int indexRegua = Conversions.ToInteger(dgDisp.SelectedRows[0].Cells[3].Value);
				cDadosAccessFiacao2.CarregaTerminaisRegua(yespHYOtfwc, yj4pHrmEcFc, mRIpH9aB9rR, indexRegua, ref mfiacao, bIncuiPG: false, bTodosOsBornes: true);
				cDadosAccessFiacao2.fechaConexao();
				List<string> list = new List<string>();
				string regua = Conversions.ToString(dgDisp.SelectedRows[0].Cells[0].Value);
				clsLayoutMec.CarregaBornesInseridos(mRIpH9aB9rR, regua, list);
				if (Information.UBound(mfiacao) > 0)
				{
					int num = Information.UBound(mfiacao);
					for (int i = 1; i <= num; i++)
					{
						dgBornes.Rows.Add(mfiacao[i].Terminal, mfiacao[i].TipoBorne, mfiacao[i].BlocoLayout, mfiacao[i].Indice);
						dgBornes.Rows[dgBornes.RowCount - 1].Cells[0].Style = LOIpkHK8HrA;
						dgBornes.Rows[dgBornes.RowCount - 1].Cells[2].Style = LOIpkHK8HrA;
						if (list.Contains(mfiacao[i].Terminal))
						{
							dgBornes.Rows[dgBornes.RowCount - 1].Cells[0].Style = rIWpkGx8hTd;
							dgBornes.Rows[dgBornes.RowCount - 1].Cells[2].Style = rIWpkGx8hTd;
							dgBornes.Rows[dgBornes.RowCount - 1].Selected = false;
						}
					}
				}
				wDrpGAYVxuh();
			}
			else
			{
				tbBlocoLayoutMec.Text = Conversions.ToString(dgDisp.SelectedRows[0].Cells[5].Value);
				vjgpkoXVmx4 = clsLayoutMec.BuscaHandleDoDispLayout(mRIpH9aB9rR, Conversions.ToString(dgDisp.SelectedRows[0].Cells[0].Value));
			}
		}
	}

	public void AtualizaDG_LM_PLAQUETAS()
	{
		if (!h3dpktq9jJC)
		{
			return;
		}
		clsLayoutMec.CarregaPlaquetasDoPainel(ref M01pkvbkJrb, mRIpH9aB9rR);
		clsLayoutMec.CarregaLmDoPainel(ref OX1pk6ICCBE, mRIpH9aB9rR);
		clsLayoutMec.AtualizaOsTextosAntigos();
		checked
		{
			int num = dgDisp.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				int num2 = Information.UBound(M01pkvbkJrb);
				for (int j = 1; j <= num2; j++)
				{
					if (Operators.ConditionalCompareObjectEqual(dgDisp.Rows[i].Cells[0].Value, M01pkvbkJrb[j].Disp, TextCompare: true))
					{
						dgDisp.Rows[i].Cells[7].Value = M01pkvbkJrb[j].Etiq;
						dgDisp.Rows[i].Cells[10].Value = M01pkvbkJrb[j].indice_OrdemPL;
					}
				}
				int num3 = Information.UBound(OX1pk6ICCBE);
				for (int k = 1; k <= num3; k++)
				{
					if (Operators.ConditionalCompareObjectEqual(dgDisp.Rows[i].Cells[0].Value, OX1pk6ICCBE[k].Disp, TextCompare: true))
					{
						dgDisp.Rows[i].Cells[9].Value = OX1pk6ICCBE[k].indice_OrdemLM;
					}
				}
				Application.DoEvents();
			}
			rbOrdemLM.Enabled = false;
			rbOrdemPlaquetas.Enabled = false;
			if (OX1pk6ICCBE.Count() > 1)
			{
				rbOrdemLM.Enabled = true;
			}
			if (M01pkvbkJrb.Count() > 1)
			{
				rbOrdemPlaquetas.Enabled = true;
			}
			CKPlaquetas.Enabled = rbOrdemPlaquetas.Enabled;
			CKNumero.Enabled = rbOrdemLM.Enabled;
		}
	}

	private void wDrpGAYVxuh()
	{
		checked
		{
			float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgBornes)) ? ((float)(dgBornes.Width - 4)) : ((float)(dgBornes.Width - 21)));
			dgBornes.Columns[0].Width = (int)Math.Round((double)num * 0.3);
			dgBornes.Columns[1].Width = 0;
			dgBornes.Columns[1].Visible = false;
			dgBornes.Columns[2].Width = (int)Math.Round((double)num * 0.7);
			dgBornes.Columns[2].Visible = true;
			dgBornes.Columns[3].Width = 0;
			dgBornes.Columns[3].Visible = false;
			if (dgDisp.SelectedRows.Count == 0)
			{
				dgDisp.Rows[0].Selected = true;
			}
			if (dgBornes.RowCount <= 0)
			{
				return;
			}
			List<string> list = new List<string>();
			string regua = Conversions.ToString(dgDisp.SelectedRows[0].Cells[0].Value);
			clsLayoutMec.CarregaBornesInseridos(mRIpH9aB9rR, regua, list);
			int num2 = dgBornes.RowCount - 1;
			for (int i = 0; i <= num2; i++)
			{
				dgBornes.Rows[i].Cells[0].Style = LOIpkHK8HrA;
				dgBornes.Rows[i].Cells[2].Style = LOIpkHK8HrA;
				dgBornes.Rows[i].Selected = true;
				if (list.Contains(Conversions.ToString(dgBornes.Rows[i].Cells[0].Value)))
				{
					dgBornes.Rows[i].Cells[0].Style = rIWpkGx8hTd;
					dgBornes.Rows[i].Cells[2].Style = rIWpkGx8hTd;
					dgBornes.Rows[i].Selected = false;
				}
			}
		}
	}

	private void SSopGsEEWsq(object P_0, EventArgs P_1)
	{
		if (!((Operators.CompareString(DeclaracoesGeral.Conf.dirSimbologiaLayout, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.dirSimbologiaLayout)))
		{
			tbBlocoLayoutMec.Text = "";
			return;
		}
		tbBlocoLayoutMec.BackColor = Color.White;
		DeclaracoesGeral.gsCaminhoBloco = DeclaracoesGeral.Conf.dirSimbologiaLayout;
		frmVisualizarBloco frmVisualizarBloco2 = new frmVisualizarBloco();
		Application.ShowModalDialog((Form)frmVisualizarBloco2);
		if (Operators.CompareString(DeclaracoesGeral.gsCaminhoBloco, "", TextCompare: true) != 0)
		{
			tbBlocoLayoutMec.Text = DeclaracoesGeral.gsCaminhoBloco;
			btSalvar.Enabled = true;
		}
	}

	private void AI3pGBF70mU(object P_0, EventArgs P_1)
	{
		if (!rbReguas.Checked)
		{
			if (dgDisp.SelectedRows.Count != 0)
			{
				dgDisp.SelectedRows[0].Cells[5].Value = tbBlocoLayoutMec.Text;
				int indice = Conversions.ToInteger(dgDisp.SelectedRows[0].Cells[6].Value);
				cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
				cDadosAccessFiacao2.AtualizaBlocoLayout(indice, tbBlocoLayoutMec.Text);
				cDadosAccessFiacao2.fechaConexao();
			}
			return;
		}
		cDadosAccessFiacao cDadosAccessFiacao3 = new cDadosAccessFiacao();
		checked
		{
			int num = dgBornes.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgBornes.Rows[i].Selected)
				{
					dgBornes.Rows[i].Cells[2].Value = tbBlocoLayoutMec.Text;
					int indice2 = Conversions.ToInteger(dgBornes.Rows[i].Cells[3].Value);
					cDadosAccessFiacao3.AtualizaBlocoLayoutReguas(indice2, tbBlocoLayoutMec.Text);
				}
			}
			cDadosAccessFiacao3.fechaConexao();
		}
	}

	private void DqgpGVxjI2H(object P_0, EventArgs P_1)
	{
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f9: Expected Obj, but got Unknown
		//IL_0b18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b48: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d33: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d38: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0605: Unknown result type (might be due to invalid IL or missing references)
		//IL_060a: Unknown result type (might be due to invalid IL or missing references)
		//IL_060e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0613: Unknown result type (might be due to invalid IL or missing references)
		//IL_0853: Unknown result type (might be due to invalid IL or missing references)
		//IL_0858: Unknown result type (might be due to invalid IL or missing references)
		//IL_085c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0861: Unknown result type (might be due to invalid IL or missing references)
		//IL_0878: Unknown result type (might be due to invalid IL or missing references)
		//IL_087d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0881: Unknown result type (might be due to invalid IL or missing references)
		//IL_0886: Unknown result type (might be due to invalid IL or missing references)
		//IL_0898: Unknown result type (might be due to invalid IL or missing references)
		//IL_089d: Unknown result type (might be due to invalid IL or missing references)
		//IL_08af: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08da: Unknown result type (might be due to invalid IL or missing references)
		//IL_08df: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a48: Unknown result type (might be due to invalid IL or missing references)
		//IL_062c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0631: Unknown result type (might be due to invalid IL or missing references)
		//IL_063f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0644: Unknown result type (might be due to invalid IL or missing references)
		//IL_0659: Unknown result type (might be due to invalid IL or missing references)
		//IL_065e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0662: Unknown result type (might be due to invalid IL or missing references)
		//IL_0670: Unknown result type (might be due to invalid IL or missing references)
		//IL_0675: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0800: Unknown result type (might be due to invalid IL or missing references)
		//IL_0805: Unknown result type (might be due to invalid IL or missing references)
		//IL_081c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0821: Unknown result type (might be due to invalid IL or missing references)
		//IL_0825: Unknown result type (might be due to invalid IL or missing references)
		//IL_082a: Unknown result type (might be due to invalid IL or missing references)
		//IL_083c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0841: Unknown result type (might be due to invalid IL or missing references)
		//IL_090b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0910: Unknown result type (might be due to invalid IL or missing references)
		//IL_0914: Unknown result type (might be due to invalid IL or missing references)
		//IL_0919: Unknown result type (might be due to invalid IL or missing references)
		//IL_092d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0932: Unknown result type (might be due to invalid IL or missing references)
		//IL_0936: Unknown result type (might be due to invalid IL or missing references)
		//IL_093b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0950: Unknown result type (might be due to invalid IL or missing references)
		//IL_0955: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a60: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a67: Expected Obj, but got Unknown
		//IL_0d4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5a: Expected Obj, but got Unknown
		//IL_0be9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c33: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c45: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e90: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ecc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ede: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f28: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b92: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0caa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0caf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ccc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ceb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e59: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df1: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		if (dgDisp.SelectedRows.Count == 0)
		{
			return;
		}
		WindowState = FormWindowState.Minimized;
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		int num = 0;
		checked
		{
			if (!rbDispositivos.Checked)
			{
				string regua = Conversions.ToString(dgDisp.SelectedRows[0].Cells[0].Value);
				DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
				try
				{
					Database database = Application.DocumentManager.MdiActiveDocument.Database;
					_ = Application.DocumentManager.MdiActiveDocument.Editor;
					Transaction val2 = database.TransactionManager.StartTransaction();
					try
					{
						int num2 = 0;
						BlockReference val3 = null;
						string text = tbBlocoLayoutMec.Text;
						bool flag = true;
						bool flag2 = true;
						if (!File.Exists(DeclaracoesGeral.Conf.dirSimbologiaLayout + text))
						{
							flag = true;
						}
						hY2pkkUVnqD.BackColor = Color.RosyBrown;
						int num3 = dgBornes.RowCount - 1;
						for (int i = 0; i <= num3; i++)
						{
							if (dgBornes.Rows[i].Selected)
							{
								dgBornes.Rows[i].Cells[0].Style = LOIpkHK8HrA;
								dgBornes.Rows[i].Cells[2].Style = LOIpkHK8HrA;
								dgBornes[0, i].ErrorText = "";
								dgBornes[2, i].ErrorText = "";
								if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(NewLateBinding.LateGet(dgBornes.Rows[i].Cells[2].Value, null, "trim", new object[0], null, null, null), "", TextCompare: true), flag)))
								{
									dgBornes.Rows[i].Cells[2].Value = tbBlocoLayoutMec.Text;
								}
								if (!File.Exists(Conversions.ToString(Operators.AddObject(DeclaracoesGeral.Conf.dirSimbologiaLayout, dgBornes.Rows[i].Cells[2].Value))))
								{
									flag2 = false;
									dgBornes.Rows[i].Cells[0].Style = hY2pkkUVnqD;
									dgBornes.Rows[i].Cells[2].Style = hY2pkkUVnqD;
									dgBornes[2, i].ErrorText = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1838]);
								}
							}
						}
						bool flag3 = true;
						if (!flag2)
						{
							int num4 = dgBornes.RowCount - 1;
							for (int j = 0; j <= num4; j++)
							{
								if (dgBornes.Rows[j].Selected)
								{
									dgBornes.Rows[j].Selected = false;
									if (dgBornes.Rows[j].Cells[0].Style.BackColor == Color.RosyBrown && flag3)
									{
										dgBornes.FirstDisplayedScrollingRowIndex = j;
										flag3 = false;
									}
								}
							}
						}
						if (flag2)
						{
							Point3d val4 = new Point3d(0.0, 0.0, 0.0);
							Point3d val5 = new Point3d(0.0, 0.0, 0.0);
							new Point3d(0.0, 0.0, 0.0);
							double num5 = 0.5;
							string text2 = "";
							int num6 = dgBornes.RowCount - 1;
							int num7 = 0;
							while (true)
							{
								if (num7 <= num6)
								{
									if (dgBornes.Rows[num7].Selected)
									{
										num2++;
										if (Operators.ConditionalCompareObjectLess(dgBornes.Rows[num7].Cells[1].Value, 2, TextCompare: true))
										{
											num++;
										}
										string borne = Conversions.ToString(dgBornes.Rows[num7].Cells[0].Value);
										int num8 = Conversions.ToInteger(dgBornes.Rows[num7].Cells[1].Value);
										text = (Operators.ConditionalCompareObjectEqual(dgBornes.Rows[num7].Cells[2].Value, "", TextCompare: true) ? tbBlocoLayoutMec.Text : Conversions.ToString(dgBornes.Rows[num7].Cells[2].Value));
										Extents3d value;
										Point3d val6;
										if (num2 != 1)
										{
											if (!((val4.X == 0.0) & (val4.Y == 0.0)))
											{
												double num9 = 0.0;
												double num10 = 0.0;
												if (!rbVertical.Checked)
												{
													value = ((Drawable)val3).Bounds.Value;
													val6 = value.MaxPoint;
													double num11 = val6.X;
													value = ((Drawable)val3).Bounds.Value;
													val6 = value.MinPoint;
													num9 = num11 - val6.X;
													num10 = 0.0;
												}
												else
												{
													num9 = 0.0;
													value = ((Drawable)val3).Bounds.Value;
													val6 = value.MaxPoint;
													double num12 = val6.Y;
													value = ((Drawable)val3).Bounds.Value;
													val6 = value.MinPoint;
													num10 = num12 - val6.Y;
												}
												val6 = val3.Position;
												double num13 = val6.X + num9;
												val6 = val3.Position;
												Point3d ptIns = new Point3d(num13, val6.Y - num10, 0.0);
												ObjectId val7 = clsLayoutMec.InserirOutroBorneLayout(text, ptIns, mRIpH9aB9rR, regua, borne, num8);
												if (val7.IsValid)
												{
													val3 = (BlockReference)val2.GetObject(val7, (OpenMode)1);
													if (!(rbVertical.Checked & (num8 < 2)))
													{
														if (!(cbDireitaOuCima.Checked & (num8 < 2)))
														{
															if (cbEsquerdaOuBaixo.Checked & (num8 < 2))
															{
																value = ((Drawable)val3).Bounds.Value;
																val6 = value.MaxPoint;
																double num14 = val6.X;
																value = ((Drawable)val3).Bounds.Value;
																val6 = value.MinPoint;
																val5 = new Point3d(num14, val6.Y - num5, 0.0);
															}
														}
														else
														{
															value = ((Drawable)val3).Bounds.Value;
															val6 = value.MaxPoint;
															double num15 = val6.X;
															value = ((Drawable)val3).Bounds.Value;
															val6 = value.MaxPoint;
															val5 = new Point3d(num15, val6.Y + num5, 0.0);
														}
													}
													else if (!cbDireitaOuCima.Checked)
													{
														if (cbEsquerdaOuBaixo.Checked & (num8 < 2))
														{
															value = ((Drawable)val3).Bounds.Value;
															val6 = value.MinPoint;
															double num16 = val6.X - num5;
															value = ((Drawable)val3).Bounds.Value;
															val6 = value.MinPoint;
															val5 = new Point3d(num16, val6.Y, 0.0);
														}
													}
													else
													{
														value = ((Drawable)val3).Bounds.Value;
														val6 = value.MaxPoint;
														double num17 = val6.X + num5;
														value = ((Drawable)val3).Bounds.Value;
														val6 = value.MinPoint;
														val5 = new Point3d(num17, val6.Y, 0.0);
													}
												}
											}
											else
											{
												double num18 = 0.0;
												double num19 = 0.0;
												text2 = Conversions.ToString(dgBornes.Rows[num7].Cells[0].Value);
												if (!rbVertical.Checked)
												{
													value = ((Drawable)val3).Bounds.Value;
													val6 = value.MaxPoint;
													double num20 = val6.X;
													value = ((Drawable)val3).Bounds.Value;
													val6 = value.MinPoint;
													num18 = num20 - val6.X;
													num19 = 0.0;
												}
												else
												{
													num18 = 0.0;
													value = ((Drawable)val3).Bounds.Value;
													val6 = value.MaxPoint;
													double num21 = val6.Y;
													value = ((Drawable)val3).Bounds.Value;
													val6 = value.MinPoint;
													num19 = num21 - val6.Y;
												}
												val6 = val3.Position;
												double num22 = val6.X + num18;
												val6 = val3.Position;
												Point3d ptIns2 = new Point3d(num22, val6.Y - num19, 0.0);
												ObjectId val8 = clsLayoutMec.InserirOutroBorneLayout(text, ptIns2, mRIpH9aB9rR, regua, borne, num8);
												if (val8.IsValid)
												{
													val3 = (BlockReference)val2.GetObject(val8, (OpenMode)1);
													if (!rbVertical.Checked)
													{
														if (!(cbDireitaOuCima.Checked & (num8 < 2)))
														{
															if (cbEsquerdaOuBaixo.Checked & (num8 < 2))
															{
																value = ((Drawable)val3).Bounds.Value;
																val6 = value.MinPoint;
																double num23 = val6.X;
																value = ((Drawable)val3).Bounds.Value;
																val6 = value.MinPoint;
																val4 = new Point3d(num23, val6.Y - num5, 0.0);
															}
														}
														else
														{
															value = ((Drawable)val3).Bounds.Value;
															val6 = value.MinPoint;
															double num24 = val6.X;
															value = ((Drawable)val3).Bounds.Value;
															val6 = value.MaxPoint;
															val4 = new Point3d(num24, val6.Y + num5, 0.0);
														}
													}
													else if (!(cbDireitaOuCima.Checked & (num8 < 2)))
													{
														if (cbEsquerdaOuBaixo.Checked & (num8 < 2))
														{
															value = ((Drawable)val3).Bounds.Value;
															val6 = value.MinPoint;
															double num25 = val6.X - num5;
															value = ((Drawable)val3).Bounds.Value;
															val6 = value.MaxPoint;
															val4 = new Point3d(num25, val6.Y, 0.0);
														}
													}
													else
													{
														value = ((Drawable)val3).Bounds.Value;
														val6 = value.MaxPoint;
														double num26 = val6.X + num5;
														value = ((Drawable)val3).Bounds.Value;
														val6 = value.MaxPoint;
														val4 = new Point3d(num26, val6.Y, 0.0);
													}
													if (cbDireitaOuCima.Checked | cbEsquerdaOuBaixo.Checked)
													{
														clsLayoutMec.CriarNumeroDoPrimeiroBorne(val3, text2, rbVertical.Checked, cbDireitaOuCima.Checked, mRIpH9aB9rR, regua, Conversions.ToString(0), 2, Conversions.ToDouble(TBFonte.Text));
													}
												}
											}
										}
										else
										{
											ObjectId val9 = clsLayoutMec.InserirPrimeiroBorneLayout(text, mRIpH9aB9rR, regua, borne, num8, rbVertical.Checked, Conversions.ToDouble(TBFonte.Text));
											if (val9.IsValid)
											{
												val3 = (BlockReference)val2.GetObject(val9, (OpenMode)1);
												text2 = Conversions.ToString(dgBornes.Rows[num7].Cells[0].Value);
												if (!rbVertical.Checked)
												{
													if (!(cbDireitaOuCima.Checked & (num8 < 2)))
													{
														if (cbEsquerdaOuBaixo.Checked & (num8 < 2))
														{
															value = ((Drawable)val3).Bounds.Value;
															val6 = value.MinPoint;
															double num27 = val6.X;
															value = ((Drawable)val3).Bounds.Value;
															val6 = value.MinPoint;
															val4 = new Point3d(num27, val6.Y - num5, 0.0);
														}
													}
													else
													{
														value = ((Drawable)val3).Bounds.Value;
														val6 = value.MinPoint;
														double num28 = val6.X;
														value = ((Drawable)val3).Bounds.Value;
														val6 = value.MaxPoint;
														val4 = new Point3d(num28, val6.Y + num5, 0.0);
													}
												}
												else if (!(cbDireitaOuCima.Checked & (num8 < 2)))
												{
													if (cbEsquerdaOuBaixo.Checked & (num8 < 2))
													{
														value = ((Drawable)val3).Bounds.Value;
														val6 = value.MinPoint;
														double num29 = val6.X - num5;
														value = ((Drawable)val3).Bounds.Value;
														val6 = value.MaxPoint;
														val4 = new Point3d(num29, val6.Y, 0.0);
													}
												}
												else
												{
													value = ((Drawable)val3).Bounds.Value;
													val6 = value.MaxPoint;
													double num30 = val6.X + num5;
													value = ((Drawable)val3).Bounds.Value;
													val6 = value.MaxPoint;
													val4 = new Point3d(num30, val6.Y, 0.0);
												}
												if ((cbDireitaOuCima.Checked | cbEsquerdaOuBaixo.Checked) & (num8 < 2))
												{
													clsLayoutMec.CriarNumeroDoPrimeiroBorne(val3, text2, rbVertical.Checked, cbDireitaOuCima.Checked, mRIpH9aB9rR, regua, Conversions.ToString(0), 2, Conversions.ToDouble(TBFonte.Text));
												}
											}
										}
										if (Information.IsNothing(val3))
										{
											break;
										}
									}
									num7++;
									continue;
								}
								if (val4 != val5)
								{
									clsLayoutMec.AdicionaQuantidadeDosBornes(val4, val5, Conversions.ToString(num), rbVertical.Checked, cbDireitaOuCima.Checked, mRIpH9aB9rR, regua, Conversions.ToString(0), 2, Conversions.ToDouble(TBFonte.Text));
								}
								int num31 = dgBornes.RowCount - 1;
								for (int k = num31; k >= 0; k += -1)
								{
									if (dgBornes.Rows[k].Selected)
									{
										dgBornes.Rows[k].Cells[0].Style = rIWpkGx8hTd;
										dgBornes.Rows[k].Cells[2].Style = rIWpkGx8hTd;
										dgBornes.Rows[k].Selected = false;
									}
								}
								break;
							}
							DeclaracoesGeral.bAnularEventos = true;
							val2.Commit();
							DeclaracoesGeral.bAnularEventos = false;
							goto IL_12d0;
						}
						Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 848]), MsgBoxStyle.Exclamation);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						val2.Abort();
						throw;
					}
					finally
					{
						((IDisposable)val2)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
			}
			else
			{
				string tag = Conversions.ToString(dgDisp.SelectedRows[0].Cells[0].Value);
				string alternativo = Conversions.ToString(dgDisp.SelectedRows[0].Cells[1].Value);
				string sEtiqueta = Conversions.ToString(dgDisp.SelectedRows[0].Cells[7].Value);
				string text3 = tbBlocoLayoutMec.Text;
				string sHandle = clsTextos.TiraNothing(Conversions.ToString(dgDisp.SelectedRows[0].Cells[12].Value));
				if (File.Exists(DeclaracoesGeral.Conf.dirSimbologiaLayout + text3))
				{
					sHandle = clsLayoutMec.InserirBlocoDispLayout(mRIpH9aB9rR, tag, alternativo, text3, cbAlternativo.Checked, sEtiqueta, CKPlaquetas.Checked, CKNomeVisivel.Checked, sHandle);
					int num32 = 0;
					do
					{
						if (Operators.CompareString(sHandle, "", TextCompare: true) != 0)
						{
							dgDisp.SelectedRows[0].Cells[num32].Style = rIWpkGx8hTd;
						}
						num32++;
					}
					while (num32 <= 7);
					dgDisp.SelectedRows[0].Selected = false;
					if (CKIncluirRetangulo.Checked)
					{
						clsLayoutMec.CriaRetanguloNoAtributo(ref sHandle, Conversions.ToDouble(TBTamanho.Text));
					}
					goto IL_11d4;
				}
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 848]), MsgBoxStyle.Exclamation);
			}
			goto IL_1072;
		}
		IL_11d4:
		checked
		{
			if (rbDispositivos.Checked)
			{
				int num33 = dgDisp.Rows.Count - 1;
				for (int l = 0; l <= num33; l++)
				{
					if (!(dgDisp.Rows[l].Cells[0].Style.BackColor == Color.LightCoral))
					{
						dgDisp.Rows[l].Selected = true;
						dgDisp.FirstDisplayedScrollingRowIndex = l;
						break;
					}
					dgDisp.Rows[l].Selected = false;
				}
			}
			goto IL_1072;
		}
		IL_1072:
		WindowState = FormWindowState.Normal;
		PointMonitorToolTips.StartMonitor();
		return;
		IL_12d0:
		wDrpGAYVxuh();
		goto IL_11d4;
	}

	public void formataDGDWG()
	{
		try
		{
			dgDWG.Rows.Clear();
			dgDWG.Columns.Clear();
			dgDWG.Columns.Add("", "DWG");
			dgDWG.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 786]));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void CarregaDGDWG()
	{
		DeclaracoesGeral.arqLogico[] mDWG = new DeclaracoesGeral.arqLogico[1];
		cDadosAccess.carregaDadosTodosDWG(ref mDWG);
		checked
		{
			try
			{
				formataDGDWG();
				int num = Information.UBound(mDWG);
				for (int i = 1; i <= num; i++)
				{
					dgDWG.Rows.Add(mDWG[i].Indice, mDWG[i].Nome);
					if (DeclaracoesGeral.arqAtivo.Indice == mDWG[i].Indice)
					{
						dgDWG.Rows[dgDWG.Rows.Count - 1].Selected = true;
					}
				}
				AtualizaDWG();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void formataDGRevisao()
	{
		checked
		{
			try
			{
				dgRevisao.Rows.Clear();
				dgRevisao.Columns.Clear();
				dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 752]));
				float num = dgRevisao.Width - 4;
				dgRevisao.Columns[0].Width = (int)Math.Round(num);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void formataDGEquip()
	{
		checked
		{
			try
			{
				H6RpkWE2hSK = true;
				dgEquip.Rows.Clear();
				dgEquip.Columns.Clear();
				dgEquip.Columns.Add("", "Indice");
				dgEquip.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 748]));
				int num = dgEquip.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgEquip.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				float num2 = dgEquip.Width - 4;
				dgEquip.Columns[0].Width = 0;
				dgEquip.Columns[0].Visible = false;
				dgEquip.Columns[1].Width = (int)Math.Round(num2);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				H6RpkWE2hSK = false;
			}
		}
	}

	public void formataDGBornes()
	{
		checked
		{
			try
			{
				ShEpkTr7pjo = true;
				dgBornes.Rows.Clear();
				dgBornes.Columns.Clear();
				dgBornes.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 540]));
				dgBornes.Columns.Add("", "TIPO");
				dgBornes.Columns.Add("", "BlocoLayout");
				dgBornes.Columns.Add("", "IndiceBanco");
				int num = dgBornes.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgBornes.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgBornes)) ? ((double)(dgBornes.Width - 4)) : ((double)(dgBornes.Width - 21)));
				dgBornes.Columns[0].Width = (int)Math.Round(a);
				dgBornes.Columns[1].Width = 0;
				dgBornes.Columns[1].Visible = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				ShEpkTr7pjo = false;
			}
		}
	}

	private void xQ9pGuwsfei(object P_0, EventArgs P_1)
	{
		bool flag = false;
		yj4pHrmEcFc = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
		mRIpH9aB9rR = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
		checked
		{
			if (cbAlternativo.Checked)
			{
				int num = dgDisp.RowCount - 1;
				for (int i = num; i >= 0; i += -1)
				{
					if (Operators.ConditionalCompareObjectNotEqual(dgDisp.Rows[i].Cells[1].Value, "", TextCompare: true))
					{
						flag = true;
					}
				}
				cbAlternativo.Checked = flag;
			}
			AtualizaDGDisp();
		}
	}

	private void yumpGEpKaeY()
	{
		if (dgDisp.Rows.Count <= 0)
		{
			return;
		}
		if (!rbOrdemLM.Checked)
		{
			if (!rbOrdemPlaquetas.Checked)
			{
				if (rbOrdemLayout.Checked)
				{
					Xj6pGiYbkxJ(11);
				}
			}
			else
			{
				Xj6pGiYbkxJ(10);
			}
		}
		else
		{
			Xj6pGiYbkxJ(9);
		}
		AtualizaDGDisp();
		if (dgDisp.SelectedRows.Count > 0)
		{
			dgDisp.Rows[0].Selected = true;
			dgDisp.Rows[0].Selected = false;
		}
	}

	private void FdwpGZjmHh8()
	{
		checked
		{
			try
			{
				if (dgEquip.SelectedRows.Count != 1 || !rbDispositivos.Checked)
				{
					return;
				}
				mRIpH9aB9rR = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
				K75pkfY3irQ.Clear();
				clsLayoutMec.CarregaDispositivosInseridos(mRIpH9aB9rR, K75pkfY3irQ);
				int num = dgDisp.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					int num2 = 0;
					do
					{
						dgDisp.Rows[i].Cells[num2].Style = LOIpkHK8HrA;
						num2++;
					}
					while (num2 <= 7);
					dgDisp.Rows[i].Selected = false;
					if (K75pkfY3irQ.Contains(Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(mRIpH9aB9rR) + "-", dgDisp.Rows[i].Cells[0].Value))))
					{
						int num3 = 0;
						do
						{
							dgDisp.Rows[i].Cells[num3].Style = rIWpkGx8hTd;
							num3++;
						}
						while (num3 <= 7);
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
			}
		}
	}

	private void Xj6pGiYbkxJ(int P_0)
	{
		DataGridViewColumn dataGridViewColumn = dgDisp.Columns[P_0];
		dgDisp.Sort(dataGridViewColumn, ListSortDirection.Ascending);
		OrdenaColunas(P_0);
	}

	public void OrdenaColunas(int iIndice)
	{
		if (dgDisp.Rows.Count < 2)
		{
			return;
		}
		checked
		{
			int num = dgDisp.Rows.Count - 2;
			for (int i = num; i >= 0; i += -1)
			{
				int num2 = i;
				for (int j = 0; j <= num2; j++)
				{
					int num3 = 0;
					num3 = (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dgDisp[iIndice, j].Value)) ? Conversions.ToInteger(dgDisp[iIndice, j].Value) : 0);
					int num4 = 0;
					num4 = (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dgDisp[iIndice, j + 1].Value)) ? Conversions.ToInteger(dgDisp[iIndice, j + 1].Value) : 0);
					if (num3 > num4)
					{
						int num5 = 0;
						do
						{
							object objectValue = RuntimeHelpers.GetObjectValue(dgDisp[num5, j + 1].Value);
							dgDisp[num5, j + 1].Value = RuntimeHelpers.GetObjectValue(dgDisp[num5, j].Value);
							dgDisp[num5, j].Value = RuntimeHelpers.GetObjectValue(objectValue);
							num5++;
						}
						while (num5 <= 12);
					}
				}
			}
		}
	}

	public void RemoveColocaE(bool bRemover)
	{
		checked
		{
			int num = dgDisp.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (!bRemover)
				{
					dgDisp.Rows[i].Cells[10].Value = Operators.ConcatenateObject("E", dgDisp.Rows[i].Cells[10].Value);
					continue;
				}
				dgDisp.Rows[i].Cells[10].Value = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(dgDisp.Rows[i].Cells[10].Value, null, "Replace", new object[2] { "E", "" }, null, null, null));
			}
		}
	}

	private void oadpGSNtLCE(object P_0, EventArgs P_1)
	{
		AtualizaDGDisp();
		CKIncluirRetangulo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1888]);
		CKIncluirRetangulo.Enabled = false;
		TBTamanho.Enabled = false;
		if (CKPlaquetas.Checked)
		{
			CKNumero.Checked = false;
			CKIncluirRetangulo.Enabled = true;
			TBTamanho.Enabled = true;
			CKIncluirRetangulo.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1888], " "), DeclaracoesGeral.mMensagem[1, 582]));
		}
	}

	private void CSKpG4rU2hF(object P_0, EventArgs P_1)
	{
		AtualizaDGDisp();
		CKIncluirRetangulo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1888]);
		CKIncluirRetangulo.Enabled = false;
		TBTamanho.Enabled = false;
		if (CKNumero.Checked)
		{
			CKPlaquetas.Checked = false;
			CKIncluirRetangulo.Enabled = true;
			TBTamanho.Enabled = true;
			CKIncluirRetangulo.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1888], " "), DeclaracoesGeral.mMensagem[1, 1084]));
		}
	}

	private void JRFpGCoqlcI(object P_0, MouseEventArgs P_1)
	{
		DESELECIONA(false);
	}

	private void JTupGYoBoJZ(object P_0, MouseEventArgs P_1)
	{
		DESELECIONA(false);
	}

	public void DESELECIONA(object bCarregando = false)
	{
		if (Conversions.ToBoolean(Operators.AndObject(dgDWG.SelectedRows.Count > 0, Operators.CompareObjectEqual(bCarregando, true, TextCompare: true))))
		{
			dgDWG.Rows[0].Selected = true;
		}
		checked
		{
			int num = dgDisp.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if ((dgDisp.Rows[i].Cells[0].Style.BackColor == Color.LightCoral) & dgDisp.Rows[i].Selected)
				{
					dgDisp.Rows[i].Selected = false;
				}
			}
			int num2 = 0;
			int num3 = dgBornes.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				if ((dgBornes.Rows[j].Cells[0].Style.BackColor == Color.LightCoral) & dgBornes.Rows[j].Selected)
				{
					dgBornes.Rows[j].Selected = false;
				}
				if (Operators.ConditionalCompareObjectLess(dgBornes.Rows[j].Cells[1].Value, 2, TextCompare: true))
				{
					num2++;
				}
			}
			LBTotal.Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1462], num2));
		}
	}

	private void Gf7pGrVI8Pg(object P_0, EventArgs P_1)
	{
		if (cbDireitaOuCima.Checked)
		{
			cbEsquerdaOuBaixo.Checked = false;
		}
	}

	private void wSTpG9HTnho(object P_0, EventArgs P_1)
	{
		if (cbEsquerdaOuBaixo.Checked)
		{
			cbDireitaOuCima.Checked = false;
		}
	}

	private void TxApGzTaQrV(object P_0, EventArgs P_1)
	{
		cbDireitaOuCima.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1578]);
		cbEsquerdaOuBaixo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1579]);
	}

	private void C0KpHWoXvsA(object P_0, EventArgs P_1)
	{
		cbDireitaOuCima.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1580]);
		cbEsquerdaOuBaixo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1581]);
	}

	private void eMLpHpuELCH(object P_0, DataGridViewCellEventArgs P_1)
	{
		vjgpkoXVmx4 = clsLayoutMec.BuscaHandleDoDispLayout(mRIpH9aB9rR, Conversions.ToString(dgDisp.SelectedRows[0].Cells[0].Value));
		if (Operators.CompareString(vjgpkoXVmx4, "", TextCompare: true) != 0)
		{
			clsBlocos.MostraBloco(vjgpkoXVmx4);
		}
	}

	private void ItDpHTVWB6p(object P_0, EventArgs P_1)
	{
		//IL_040a: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Unknown result type (might be due to invalid IL or missing references)
		//IL_061d: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c1: Unknown result type (might be due to invalid IL or missing references)
		if (dgDisp.SelectedRows.Count == 0)
		{
			return;
		}
		checked
		{
			int num = dgDisp.RowCount - 1;
			for (int i = num; i >= 0 && !(dgDisp.Rows[i].Cells[0].Style.BackColor == Color.LightCoral); i += -1)
			{
			}
			Hide();
			mRIpH9aB9rR = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
			clsLayoutMec.StructurePlaquetas[] mPlaquetasRel = new clsLayoutMec.StructurePlaquetas[1];
			clsLayoutMec.pesquisaPlaquetasDesenho(ref mPlaquetasRel, mRIpH9aB9rR, cbAlternativo.Checked);
			K0jpkJwrOYf = clsLayoutMec.CarregaPlaquetasDoPainel(ref M01pkvbkJrb, mRIpH9aB9rR);
			int num2 = Information.UBound(mPlaquetasRel);
			for (int j = 1; j <= num2; j++)
			{
				clsLayoutMec.StructurePlaquetasPainel[] m01pkvbkJrb = M01pkvbkJrb;
				for (int k = 0; k < m01pkvbkJrb.Length; k++)
				{
					clsLayoutMec.StructurePlaquetasPainel structurePlaquetasPainel = m01pkvbkJrb[k];
					if ((Operators.CompareString(mPlaquetasRel[j].Painel, structurePlaquetasPainel.Painel, TextCompare: true) == 0) & (Operators.CompareString(mPlaquetasRel[j].Disp, structurePlaquetasPainel.Disp, TextCompare: true) == 0))
					{
						mPlaquetasRel[j].indice_OrdemPL = structurePlaquetasPainel.indice_OrdemPL;
						mPlaquetasRel[j].Etiq = structurePlaquetasPainel.Etiq;
						break;
					}
				}
			}
			clsLayoutMec.CarregaLmDoPainel(ref OX1pk6ICCBE, mRIpH9aB9rR);
			int num3 = Information.UBound(mPlaquetasRel);
			for (int l = 1; l <= num3; l++)
			{
				clsLayoutMec.StructureLmPainel[] oX1pk6ICCBE = OX1pk6ICCBE;
				for (int m = 0; m < oX1pk6ICCBE.Length; m++)
				{
					clsLayoutMec.StructureLmPainel structureLmPainel = oX1pk6ICCBE[m];
					if ((Operators.CompareString(mPlaquetasRel[l].Painel, structureLmPainel.Painel, TextCompare: true) == 0) & (Operators.CompareString(mPlaquetasRel[l].Disp, structureLmPainel.Disp, TextCompare: true) == 0))
					{
						mPlaquetasRel[l].indice_OrdemLM = structureLmPainel.indice_OrdemLM;
						break;
					}
				}
			}
			int num4 = Information.UBound(mPlaquetasRel);
			for (int n = 1; n <= num4; n++)
			{
				int num5 = dgDisp.Rows.Count - 1;
				for (int num6 = 0; num6 <= num5; num6++)
				{
					if (Operators.ConditionalCompareObjectEqual(dgDisp.Rows[num6].Cells[0].Value, mPlaquetasRel[n].Disp, TextCompare: true))
					{
						if (Operators.CompareString(mPlaquetasRel[n].Etiq, "", TextCompare: true) == 0)
						{
							mPlaquetasRel[n].Etiq = Conversions.ToString(dgDisp.Rows[num6].Cells[7].Value);
						}
						mPlaquetasRel[n].indice_OrdemLM = Conversions.ToInteger(dgDisp.Rows[num6].Cells[9].Value);
						mPlaquetasRel[n].indice_OrdemPL = Conversions.ToInteger(dgDisp.Rows[num6].Cells[10].Value);
						mPlaquetasRel[n].indice_OrdemLAY = Conversions.ToInteger(dgDisp.Rows[num6].Cells[11].Value);
						break;
					}
				}
			}
			if (!rbOrdemLayout.Checked)
			{
				if (!rbOrdemLM.Checked)
				{
					if (rbOrdemPlaquetas.Checked)
					{
						ordenaPlaquetas("PLA", ref mPlaquetasRel);
						nZVpkDypB5E = 2;
					}
				}
				else
				{
					ordenaPlaquetas("LM", ref mPlaquetasRel);
					nZVpkDypB5E = 0;
				}
			}
			else
			{
				ordenaPlaquetas("LAY", ref mPlaquetasRel);
				nZVpkDypB5E = 1;
			}
			if (CKPlaquetas.Checked | CKNumero.Checked)
			{
				clsLayoutMec.ApagaRetanguloDisp(mRIpH9aB9rR);
			}
			DeclaracoesGeral.Reguas RH = default;
			DeclaracoesGeral.Reguas RH2 = default;
			XDataGeral.LeXDataReguaH(ref RH);
			XDataGeral.LeXDataReguaV(ref RH2);
			Point3d pt = clsBlocos.retornaUmPonto();
			Point3d val = pt;
			clsLayoutMec.ApagaTabelaLayout(mRIpH9aB9rR);
			if (pt.Y > 0.0)
			{
				double num7 = 0.0;
				Dicionario.CriaTableStyleRelatorios("romans", 0.1, 0.1);
				if (Information.UBound(mPlaquetasRel) > 0)
				{
					num7 = clsLayoutMec.CriaTabelaLayout(bTitulo: true, ref pt, 0, mRIpH9aB9rR, "", "", cbAlternativo.Checked, nZVpkDypB5E);
				}
				int num8 = Information.UBound(mPlaquetasRel);
				for (int num9 = 1; num9 <= num8; num9++)
				{
					num7 = clsLayoutMec.CriaTabelaLayout(bTitulo: false, ref pt, mPlaquetasRel[num9].indice_OrdemLM, mRIpH9aB9rR, mPlaquetasRel[num9].Disp, mPlaquetasRel[num9].Etiq, cbAlternativo.Checked, nZVpkDypB5E);
					if ((pt.Y - 5.0 < RH.AltBase) & (num9 != Information.UBound(mPlaquetasRel)))
					{
						pt = (K0jpkJwrOYf ? new Point3d(pt.X + num7 + 5.0, val.Y, 0.0) : new Point3d(pt.X + num7 + 5.0, val.Y, 0.0));
						num7 = clsLayoutMec.CriaTabelaLayout(bTitulo: true, ref pt, 0, mRIpH9aB9rR, "", "", cbAlternativo.Checked, nZVpkDypB5E);
					}
				}
			}
			Show();
		}
	}

	public void ordenaPlaquetas(string stipo, ref clsLayoutMec.StructurePlaquetas[] mPlaquetasRel)
	{
		if (Information.UBound(mPlaquetasRel) <= 0)
		{
			return;
		}
		checked
		{
			int num = Information.UBound(mPlaquetasRel) - 1;
			for (int i = num; i >= 1; i += -1)
			{
				int num2 = i;
				for (int j = 1; j <= num2; j++)
				{
					if (Operators.CompareString(stipo, "LAY", TextCompare: true) != 0)
					{
						if (Operators.CompareString(stipo, "LM", TextCompare: true) != 0)
						{
							if (Operators.CompareString(stipo, "PLA", TextCompare: true) == 0 && mPlaquetasRel[j].indice_OrdemPL > mPlaquetasRel[j + 1].indice_OrdemPL)
							{
								clsLayoutMec.StructurePlaquetas structurePlaquetas = mPlaquetasRel[j + 1];
								mPlaquetasRel[j + 1] = mPlaquetasRel[j];
								mPlaquetasRel[j] = structurePlaquetas;
							}
						}
						else if (mPlaquetasRel[j].indice_OrdemLM > mPlaquetasRel[j + 1].indice_OrdemLM)
						{
							clsLayoutMec.StructurePlaquetas structurePlaquetas2 = mPlaquetasRel[j + 1];
							mPlaquetasRel[j + 1] = mPlaquetasRel[j];
							mPlaquetasRel[j] = structurePlaquetas2;
						}
					}
					else if (mPlaquetasRel[j].indice_OrdemLAY > mPlaquetasRel[j + 1].indice_OrdemLAY)
					{
						clsLayoutMec.StructurePlaquetas structurePlaquetas3 = mPlaquetasRel[j + 1];
						mPlaquetasRel[j + 1] = mPlaquetasRel[j];
						mPlaquetasRel[j] = structurePlaquetas3;
					}
				}
			}
		}
	}

	private void mnnpHJ5Vxhf(object P_0, EventArgs P_1)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		if (dgDisp.SelectedRows.Count == 0)
		{
			return;
		}
		PointMonitorToolTips.StopMonitor();
		clsLayoutMec.StructureDisps[] mNomes = new clsLayoutMec.StructureDisps[1];
		try
		{
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			Hide();
			if (clsLayoutMec.SelecionaBornesParaEdicao(ref mNomes))
			{
				clsLayoutMec.ApagaOsTextosAntigos(ref mNomes, mRIpH9aB9rR);
				Point3d pt = clsBlocos.retornaUmPonto();
				clsLayoutMec.AdicionaOTexto(ref pt, ref mNomes, mRIpH9aB9rR);
				int num = Information.UBound(mNomes);
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					clsBlocos.AtributoVisivelInvidivel(ref mNomes[i].Handle, "NOME1", bliga: false);
				}
			}
			Show();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		PointMonitorToolTips.StartMonitor();
	}

	public void AtualizaDGDispInseridos(int iPN, string sTag, string sAlt)
	{
		FdwpGZjmHh8();
		checked
		{
			int num = dgDisp.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (!(dgDisp.Rows[i].Cells[0].Style.BackColor == Color.LightCoral))
				{
					dgDisp.Rows[i].Selected = true;
					dgDisp.FirstDisplayedScrollingRowIndex = i;
					break;
				}
				dgDisp.Rows[i].Selected = false;
			}
		}
	}

	public void AtualizadgBornesInseridos(int iPN, string sRegua, string sBorne)
	{
		string left = Conversions.ToString(dgDisp.SelectedRows[0].Cells[0].Value);
		if (!((mRIpH9aB9rR == iPN) & (Operators.CompareString(left, sRegua, TextCompare: true) == 0)))
		{
			return;
		}
		checked
		{
			int num = dgBornes.Rows.Count - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(dgBornes.Rows[num2].Cells[0].Value, sBorne, TextCompare: true), dgBornes.Rows[num2].Cells[0].Style.BackColor == Color.LightCoral)))
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			dgBornes.Rows[num2].Cells[0].Style = LOIpkHK8HrA;
			dgBornes.Rows[num2].Cells[2].Style = LOIpkHK8HrA;
			dgBornes.Rows[num2].Selected = false;
		}
	}

	private void lfvpHhhkWky(object P_0, KeyEventArgs P_1)
	{
		LBTotal.Text = Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1462], dgBornes.SelectedRows.Count));
	}

	private void x2rpHoYEw58(object P_0, EventArgs P_1)
	{
		if (dgEquip.Columns.Count == 0)
		{
			return;
		}
		List<string> listHandle = new List<string>();
		clsLayoutMec.CarregaPlaquetasDoPainel(ref M01pkvbkJrb, mRIpH9aB9rR);
		mRIpH9aB9rR = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
		clsLayoutMec.ApagaRetanguloDisp(mRIpH9aB9rR);
		if (CKPlaquetas.Checked)
		{
			clsLayoutMec.EditaPlaquetasLayoutMec(ref listHandle, M01pkvbkJrb, mRIpH9aB9rR);
		}
		if (CKNumero.Checked)
		{
			clsLayoutMec.EditaLmLayoutMec(ref listHandle, OX1pk6ICCBE, mRIpH9aB9rR);
		}
		checked
		{
			if (!rbDispositivos.Checked)
			{
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(M01pkvbkJrb);
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num = Information.UBound(M01pkvbkJrb);
				for (int i = 1; i <= num; i++)
				{
					string text = "";
					bool bLiga = false;
					if (CKPlaquetas.Checked)
					{
						text = M01pkvbkJrb[i].Etiq;
					}
					if (CKNumero.Checked)
					{
						text = M01pkvbkJrb[i].indice_OrdemPL.ToString();
						int num2 = Information.UBound(OX1pk6ICCBE);
						for (int j = 1; j <= num2; j++)
						{
							if (Operators.CompareString(M01pkvbkJrb[i].Disp, OX1pk6ICCBE[j].Disp, TextCompare: true) == 0)
							{
								text = Conversions.ToString(OX1pk6ICCBE[j].indice_OrdemLM);
								break;
							}
						}
					}
					if (Operators.CompareString(text, "", TextCompare: true) == 0)
					{
						text = "#B#";
					}
					else
					{
						bLiga = true;
					}
					clsLayoutMec.AtualizaETQDasReguas(mRIpH9aB9rR, text, M01pkvbkJrb[i].Disp, bLiga, CKPlaquetas.Checked, CKNumero.Checked, CKIncluirRetangulo.Checked, Conversions.ToDouble(TBTamanho.Text));
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				foreach (string item in listHandle)
				{
					string sHandle = item;
					if (CKIncluirRetangulo.Checked)
					{
						clsLayoutMec.CriaRetanguloNoAtributo(ref sHandle, Conversions.ToDouble(TBTamanho.Text));
						clsLayoutMec.CriaRetanguloNoAtributo(ref sHandle, Conversions.ToDouble(TBTamanho.Text));
					}
				}
				DeclaracoesGeral._uscPagina.pbFim();
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			}
			else
			{
				if (!CKPlaquetas.Checked & !CKNumero.Checked)
				{
					clsLayoutMec.LimpaLMPlaquetasDisp(mRIpH9aB9rR);
				}
				clsLayoutMec.CarregaPlaquetasDoPainel(ref M01pkvbkJrb, mRIpH9aB9rR);
				clsLayoutMec.CarregaLmDoPainel(ref OX1pk6ICCBE, mRIpH9aB9rR);
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(M01pkvbkJrb);
				DeclaracoesGeral._uscPagina.pbIniciar();
				clsLayoutMec.AtualizaNOMEDoBloco(mRIpH9aB9rR, CKNomeVisivel.Checked);
				clsLayoutMec.AtualizaOsTextosAntigos();
			}
			wHFpHvihism();
			fNmpH6A7GcL();
			foreach (string item2 in listHandle)
			{
				string sHandle2 = item2;
				if (CKIncluirRetangulo.Checked)
				{
					clsLayoutMec.CriaRetanguloNoAtributo(ref sHandle2, Conversions.ToDouble(TBTamanho.Text));
				}
			}
			DeclaracoesGeral._uscPagina.pbFim();
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		}
	}

	public void atualizaRevisao()
	{
		checked
		{
			if (dgRevisao.Columns.Count != 0)
			{
				double a = dgRevisao.Width - 21;
				if (!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgRevisao))
				{
					a = dgRevisao.Width - 4;
				}
				dgRevisao.Columns[0].Width = (int)Math.Round(a);
			}
		}
	}

	public void AtualizaDWG()
	{
		checked
		{
			if (dgDWG.Columns.Count != 0)
			{
				double a = dgDWG.Width - 21 - 40;
				if (!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgDWG))
				{
					a = dgDWG.Width - 4 - 40;
				}
				dgDWG.Columns[0].Width = 40;
				dgDWG.Columns[1].Width = (int)Math.Round(a);
			}
		}
	}

	public void AtualizaEquip()
	{
		checked
		{
			if (dgEquip.Columns.Count != 0)
			{
				double a = dgEquip.Width - 21;
				if (!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgEquip))
				{
					a = dgEquip.Width - 4;
				}
				dgEquip.Columns[0].Width = 0;
				dgEquip.Columns[0].Visible = false;
				dgEquip.Columns[1].Width = (int)Math.Round(a);
			}
		}
	}

	public void formataDGDisp()
	{
		checked
		{
			try
			{
				WdUpkpVgBFH = true;
				dgDisp.Rows.Clear();
				dgDisp.Columns.Clear();
				if (!rbDispositivos.Checked)
				{
					dgDisp.Columns.Add("", Conversions.ToString(Operators.ConcatenateObject("", DeclaracoesGeral.mMensagem[1, 788])));
				}
				else
				{
					dgDisp.Columns.Add("", Conversions.ToString(Operators.ConcatenateObject("", DeclaracoesGeral.mMensagem[1, 767])));
				}
				dgDisp.Columns.Add("", Conversions.ToString(Operators.ConcatenateObject("", DeclaracoesGeral.mMensagem[1, 785])));
				dgDisp.Columns.Add("", "2-Tipo");
				dgDisp.Columns.Add("", "3-IndexMod");
				dgDisp.Columns.Add("", "4-PosOrdem");
				dgDisp.Columns.Add("", "5-Layout");
				dgDisp.Columns.Add("", "6-Indice");
				dgDisp.Columns.Add("", "7-VALOR PL");
				dgDisp.Columns.Add("", "8-Handle");
				dgDisp.Columns.Add("", "9-INDEX LM");
				dgDisp.Columns.Add("", "10-INDEX PL");
				dgDisp.Columns.Add("", "11-INDEX Layout");
				dgDisp.Columns.Add("", "12-Handle");
				int num = dgDisp.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgDisp.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				AtualizaDGDisp();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				ProjectData.ClearProjectError();
			}
			finally
			{
				WdUpkpVgBFH = false;
			}
		}
	}

	public void AtualizaDGDisp()
	{
		checked
		{
			if (dgDisp.Columns.Count != 0)
			{
				double num = dgDisp.Width - 21;
				if (!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgDisp))
				{
					num = dgDisp.Width - 4;
				}
				if (cbAlternativo.Checked)
				{
					dgDisp.Columns[0].Width = (int)Math.Round(num / 2.0);
					dgDisp.Columns[1].Width = (int)Math.Round(num / 2.0);
					dgDisp.Columns[1].Visible = true;
				}
				else
				{
					dgDisp.Columns[0].Width = (int)Math.Round(num);
					dgDisp.Columns[1].Width = 0;
					dgDisp.Columns[1].Visible = false;
				}
				dgDisp.Columns[2].Width = 0;
				dgDisp.Columns[2].Visible = false;
				dgDisp.Columns[3].Width = 0;
				dgDisp.Columns[3].Visible = false;
				dgDisp.Columns[4].Width = 0;
				dgDisp.Columns[4].Visible = false;
				dgDisp.Columns[5].Width = 0;
				dgDisp.Columns[5].Visible = false;
				dgDisp.Columns[6].Width = 0;
				dgDisp.Columns[6].Visible = false;
				dgDisp.Columns[7].Width = 0;
				dgDisp.Columns[7].Visible = false;
				dgDisp.Columns[8].Width = 0;
				dgDisp.Columns[8].Visible = false;
				dgDisp.Columns[9].Width = 0;
				dgDisp.Columns[9].Visible = false;
				dgDisp.Columns[10].Width = 0;
				dgDisp.Columns[10].Visible = false;
				dgDisp.Columns[11].Width = 0;
				dgDisp.Columns[11].Visible = false;
				dgDisp.Columns[12].Width = 0;
				dgDisp.Columns[12].Visible = false;
			}
		}
	}

	private void oHtpHGk5awG(object P_0, EventArgs P_1)
	{
		atualizaRevisao();
		AtualizaDWG();
		AtualizaEquip();
		AtualizaDGDisp();
	}

	private void OaxpHHRJakx(object P_0, EventArgs P_1)
	{
		if (!rbOrdemLM.Enabled)
		{
			CKNumero.Checked = false;
		}
		CKNumero.Enabled = rbOrdemLM.Enabled;
		if (pRvpkdrjyCd != 2)
		{
			yumpGEpKaeY();
			pRvpkdrjyCd = 2;
			if (rbOrdemLM.Enabled)
			{
				FdwpGZjmHh8();
			}
		}
		nZVpkDypB5E = 0;
	}

	private void FqtpHkbXqes(object P_0, EventArgs P_1)
	{
		if (!rbOrdemLayout.Enabled)
		{
			CKPlaquetas.Checked = false;
		}
		CKPlaquetas.Enabled = rbOrdemPlaquetas.Enabled;
		if (pRvpkdrjyCd != 1)
		{
			yumpGEpKaeY();
			pRvpkdrjyCd = 1;
			FdwpGZjmHh8();
		}
		nZVpkDypB5E = 1;
	}

	private void zsEpHdFvcHF(object P_0, EventArgs P_1)
	{
		if (pRvpkdrjyCd != 3)
		{
			yumpGEpKaeY();
			pRvpkdrjyCd = 3;
			if (rbOrdemPlaquetas.Enabled)
			{
				FdwpGZjmHh8();
			}
		}
		nZVpkDypB5E = 2;
	}

	private void g5jpHf5IM8W(object P_0, EventArgs P_1)
	{
		string regua = Conversions.ToString(dgDisp.SelectedRows[0].Cells[0].Value);
		clsLayoutMec.ApagaReguaSelecionada(mRIpH9aB9rR, regua);
		string sRegua = Conversions.ToString(dgDisp.SelectedRows[0].Cells[0].Value);
		checked
		{
			int num = dgBornes.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				string sBorne = Conversions.ToString(dgBornes.Rows[i].Cells[0].Value);
				AtualizadgBornesInseridos(mRIpH9aB9rR, sRegua, sBorne);
				dgBornes.Rows[i].Selected = true;
				dgBornes.FirstDisplayedScrollingRowIndex = 0;
			}
		}
	}

	private void tjopHDMknuB(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void wHFpHvihism()
	{
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (dgEquip.SelectedRows.Count == 1)
			{
				mRIpH9aB9rR = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
				DeclaracoesFiacao.structureVF[] mDisp = new DeclaracoesFiacao.structureVF[1];
				cDadosAccessFiacao2.CarregaDispTipoIndexModelo(yespHYOtfwc, yj4pHrmEcFc, mRIpH9aB9rR, ref mDisp, bAdicionaDispSemFiacao: true);
				clsLayoutMec.atualizaNomesAuternativoDispositivos(mRIpH9aB9rR, ref mDisp, cbAlternativo.Checked);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		finally
		{
			cDadosAccessFiacao2.fechaConexao();
		}
	}

	private void fNmpH6A7GcL()
	{
		cDadosAccessFiacao cDadosAccessFiacao2 = new cDadosAccessFiacao();
		try
		{
			if (dgEquip.SelectedRows.Count == 1)
			{
				mRIpH9aB9rR = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
				DeclaracoesFiacao.structureVF[] mDisp = new DeclaracoesFiacao.structureVF[1];
				cDadosAccessFiacao2.CarregaDispTipoIndexModelo(yespHYOtfwc, yj4pHrmEcFc, mRIpH9aB9rR, ref mDisp, bAdicionaDispSemFiacao: true);
				clsLayoutMec.MarcaDispositivosUsados(dgDisp, ref mDisp, mRIpH9aB9rR);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
		finally
		{
			cDadosAccessFiacao2.fechaConexao();
		}
	}
}
