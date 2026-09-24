using System;
using System.Collections.Generic;
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
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.Runtime;
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmClonar : Form
{
	private IContainer husmHvir4Q;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btCopiarOrigem")]
	private Button a66mkIvCjN;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	[CompilerGenerated]
	private ToolTip JmDmd6oAp9;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("dgPaineisOrigem")]
	private DataGridView eZ5mfPeCYX;

	[CompilerGenerated]
	[AccessedThroughProperty("TabControl1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TabControl CdwmDvHhfU;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TabPage1")]
	private TabPage pSFmvVtV5k;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TabPage2")]
	[CompilerGenerated]
	private TabPage S4Rm6iGPWS;

	[AccessedThroughProperty("dgPaineisDestino")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView lRgmtojYpt;

	[AccessedThroughProperty("dgRelacaoPaineis")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView P5WmjrQmXC;

	[AccessedThroughProperty("TabPage3")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TabPage qBkmLm9aA6;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgRelacaoPaginas")]
	[CompilerGenerated]
	private DataGridView YEJmwE2xp3;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("dgPaginasDestino")]
	private DataGridView cFhmxpaMtj;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btRelacionarPaginas")]
	private Button lkwmbmbxRx;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox MKImMtexaI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbCompleto")]
	private RadioButton xJLmOABLwq;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbSelecao")]
	private RadioButton nEVmIsoPdD;

	[AccessedThroughProperty("btSelecionar")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button DA2m7feoDG;

	[AccessedThroughProperty("TabPage4")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TabPage niWmqwdrvk;

	[CompilerGenerated]
	[AccessedThroughProperty("TabPage6")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TabPage zrTmaIEb0a;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgTags")]
	[CompilerGenerated]
	private DataGridView dx6m8No7Za;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btImportar")]
	private Button KctmNv4LhI;

	[AccessedThroughProperty("TabPage5")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TabPage iVxmFleHbo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgReguas")]
	private DataGridView RC4mQ49s4t;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbIncluirAutocad")]
	private CheckBox uNrmPx4RGi;

	[AccessedThroughProperty("ProgressBar1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ProgressBar qghmccGN3T;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbTitulos")]
	private CheckBox UnGmKttdXJ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btRepetirPaginas")]
	private Button Hq1meT1GKO;

	[AccessedThroughProperty("btRepetirEquip")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button nKGm2Xwiv8;

	[AccessedThroughProperty("btAdicionarPaginas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button HR1m3x0GJI;

	[AccessedThroughProperty("tbPaginaInicial")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox QDCmnL4o1x;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox4")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox iQDm1IZlP2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox3")]
	[CompilerGenerated]
	private GroupBox WjgmlTMLqg;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbIncremento")]
	private TextBox vVsm5d06gU;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("Label3")]
	private Label KkVm0GmG3X;

	[CompilerGenerated]
	[AccessedThroughProperty("Label4")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label t71mROmVD9;

	[AccessedThroughProperty("GroupBox5")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox f4EmmwecfF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label2")]
	private Label NeCmXjnNKL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btDxDy")]
	private Button V1mmUQp2Ty;

	[AccessedThroughProperty("Label1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label odvmyJ36xl;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDy")]
	[CompilerGenerated]
	private TextBox BODmg6rgI6;

	[CompilerGenerated]
	[AccessedThroughProperty("tbDx")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox eepmAuGfr7;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LabelPN")]
	private Label vZDmsHvgQd;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBNome")]
	private TextBox E8YmBwywR2;

	[CompilerGenerated]
	[AccessedThroughProperty("btInserir")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button uT0mV0H0NK;

	private ObjectIdCollection rhWmuCoU2N;

	private ObjectIdCollection x1rmEXKB4D;

	private Document lgymZk9mmQ;

	private Document xKBmi5dIYo;

	private double cIWmSsuihd;

	private int Wm6m4JAMfD;

	private structureAddPainel[] ApomC4Vd2K;

	private bool O68mYecYQ6;

	private string MXYmrCUv06;

	private bool PASm9FIRAo;

	private string fNbmzAMGpH;

	private int EGXXWXINHr;

	private int rLUXpffcou;

	private object[,] oBBXTa1FnI;

	private object[,] o7qXJlN286;

	private DeclaracoesClonar.structureDispOrigem[] KEBXhQDjyG;

	private List<string> iY5XoVQRVT;

	private List<int> HKpXGYd0X0;

	private List<int> enJXHpMK9n;

	private List<int> Y4AXkdy2Vo;

	private List<int> uqkXdUUkXi;

	private List<int> oRMXfpYJmN;

	private List<string> eP1XDkAEjL;

	private List<string> Fa9XvTMgF7;

	private List<int> itAX6nfgHK;

	private List<string> oTwXtv1S5m;

	private List<string> l9FXj7AEv7;

	private DeclaracoesClonar.structureTitulosPaginas[] WtSXLE2mAu;

	private DeclaracoesClonar.structureRelacaoPaineis[] QNDXwHNs9Y;

	private DeclaracoesClonar.structureRelacaoPaginas[] uBgXxRAlrb;

	private DeclaracoesClonar.structureTagsUsados[] NtRXb2BLqs;

	private DeclaracoesClonar.structureRelesAuxiliares[] nOcXMjbeZF;

	private DeclaracoesClonar.structureRelacaoModelosReles[] Db0XOPg78y;

	private DeclaracoesClonar.structureMascaras[] qSeXIdqIZU;

	private DeclaracoesClonar.structureRelacaoModelosMascara[] NorX7Wq2br;

	private Declaracoes2.StructureModeloDeReguas[] n4PXqFWmdW;

	private Declaracoes2.StructureModeloDeReguas[] BwoXai25qY;

	private Declaracoes2.StructureModeloDeReguas[] O4HX8q2Ye9;

	private DeclaracoesClonar.structureRelacaoModelosRegua[] FkSXNW1U97;

	private DeclaracoesClonar.structureMaterial[] Jp8XFjY02v;

	private DeclaracoesClonar.structureRelacaoMateriais[] mEFXQGVFRa;

	private DeclaracoesClonar.structureRelacaoHandles[] haJXPlbb21;

	private DeclaracoesClonar.structureRelacaoPotenciais[] rqRXc0e9eK;

	private DeclaracoesClonar.structurePlaquetasClonar[] z6nXKJP5yL;

	private DeclaracoesClonar.structureLayoutRapidoClonar[] lIcXeiJewq;

	private DeclaracoesClonar.structureLayoutRapidoClonar[] vEmX2P2NjP;

	private DeclaracoesFiacao.structureAplicacao[] lN5X39yAhc;

	private int tjjXnhnMeM;

	private int VtPX1rsDvB;

	internal virtual Button btCopiarOrigem
	{
		[CompilerGenerated]
		get
		{
			return a66mkIvCjN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FEeRkrKNj3;
			Button button = a66mkIvCjN;
			if (button != null)
			{
				button.Click -= value2;
			}
			a66mkIvCjN = value;
			button = a66mkIvCjN;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgPaineisOrigem
	{
		[CompilerGenerated]
		get
		{
			return eZ5mfPeCYX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			eZ5mfPeCYX = value;
		}
	}

	internal virtual TabControl TabControl1
	{
		[CompilerGenerated]
		get
		{
			return CdwmDvHhfU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TabControlEventHandler value2 = wCqRHBe01K;
			TabControl tabControl = CdwmDvHhfU;
			if (tabControl != null)
			{
				tabControl.Selected -= value2;
			}
			CdwmDvHhfU = value;
			tabControl = CdwmDvHhfU;
			if (tabControl != null)
			{
				tabControl.Selected += value2;
			}
		}
	}

	internal virtual TabPage TabPage1
	{
		[CompilerGenerated]
		get
		{
			return pSFmvVtV5k;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pSFmvVtV5k = value;
		}
	}

	internal virtual TabPage TabPage2
	{
		[CompilerGenerated]
		get
		{
			return S4Rm6iGPWS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			S4Rm6iGPWS = value;
		}
	}

	internal virtual DataGridView dgPaineisDestino
	{
		[CompilerGenerated]
		get
		{
			return lRgmtojYpt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = fcmRndImpD;
			DataGridView dataGridView = lRgmtojYpt;
			if (dataGridView != null)
			{
				dataGridView.MouseDown -= value2;
			}
			lRgmtojYpt = value;
			dataGridView = lRgmtojYpt;
			if (dataGridView != null)
			{
				dataGridView.MouseDown += value2;
			}
		}
	}

	internal virtual DataGridView dgRelacaoPaineis
	{
		[CompilerGenerated]
		get
		{
			return P5WmjrQmXC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DragEventHandler value2 = BH9R1fbpE9;
			DragEventHandler value3 = Cd4Rle1Jd6;
			DataGridViewCellEventHandler value4 = YVXmhgYpgo;
			DataGridView dataGridView = P5WmjrQmXC;
			if (dataGridView != null)
			{
				dataGridView.DragDrop -= value2;
				dataGridView.DragEnter -= value3;
				dataGridView.CellClick -= value4;
			}
			P5WmjrQmXC = value;
			dataGridView = P5WmjrQmXC;
			if (dataGridView != null)
			{
				dataGridView.DragDrop += value2;
				dataGridView.DragEnter += value3;
				dataGridView.CellClick += value4;
			}
		}
	}

	internal virtual TabPage TabPage3
	{
		[CompilerGenerated]
		get
		{
			return qBkmLm9aA6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qBkmLm9aA6 = value;
		}
	}

	internal virtual DataGridView dgRelacaoPaginas
	{
		[CompilerGenerated]
		get
		{
			return YEJmwE2xp3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = sibR50SBZc;
			DataGridView dataGridView = YEJmwE2xp3;
			if (dataGridView != null)
			{
				dataGridView.CellEndEdit -= value2;
			}
			YEJmwE2xp3 = value;
			dataGridView = YEJmwE2xp3;
			if (dataGridView != null)
			{
				dataGridView.CellEndEdit += value2;
			}
		}
	}

	internal virtual DataGridView dgPaginasDestino
	{
		[CompilerGenerated]
		get
		{
			return cFhmxpaMtj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			cFhmxpaMtj = value;
		}
	}

	internal virtual Button btRelacionarPaginas
	{
		[CompilerGenerated]
		get
		{
			return lkwmbmbxRx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = odRR6kJoMy;
			Button button = lkwmbmbxRx;
			if (button != null)
			{
				button.Click -= value2;
			}
			lkwmbmbxRx = value;
			button = lkwmbmbxRx;
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
			return MKImMtexaI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MKImMtexaI = value;
		}
	}

	internal virtual RadioButton rbCompleto
	{
		[CompilerGenerated]
		get
		{
			return xJLmOABLwq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = uM7RYhW4yb;
			RadioButton radioButton = xJLmOABLwq;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			xJLmOABLwq = value;
			radioButton = xJLmOABLwq;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton rbSelecao
	{
		[CompilerGenerated]
		get
		{
			return nEVmIsoPdD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			nEVmIsoPdD = value;
		}
	}

	internal virtual Button btSelecionar
	{
		[CompilerGenerated]
		get
		{
			return DA2m7feoDG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MpsRdu6dRM;
			Button button = DA2m7feoDG;
			if (button != null)
			{
				button.Click -= value2;
			}
			DA2m7feoDG = value;
			button = DA2m7feoDG;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TabPage TabPage4
	{
		[CompilerGenerated]
		get
		{
			return niWmqwdrvk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			niWmqwdrvk = value;
		}
	}

	internal virtual TabPage TabPage6
	{
		[CompilerGenerated]
		get
		{
			return zrTmaIEb0a;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zrTmaIEb0a = value;
		}
	}

	internal virtual DataGridView dgTags
	{
		[CompilerGenerated]
		get
		{
			return dx6m8No7Za;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = pp7Rilteg0;
			DataGridView dataGridView = dx6m8No7Za;
			if (dataGridView != null)
			{
				dataGridView.CellEndEdit -= value2;
			}
			dx6m8No7Za = value;
			dataGridView = dx6m8No7Za;
			if (dataGridView != null)
			{
				dataGridView.CellEndEdit += value2;
			}
		}
	}

	internal virtual Button btImportar
	{
		[CompilerGenerated]
		get
		{
			return KctmNv4LhI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = GxFRw9wU1T;
			Button button = KctmNv4LhI;
			if (button != null)
			{
				button.Click -= value2;
			}
			KctmNv4LhI = value;
			button = KctmNv4LhI;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TabPage TabPage5
	{
		[CompilerGenerated]
		get
		{
			return iVxmFleHbo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			iVxmFleHbo = value;
		}
	}

	internal virtual DataGridView dgReguas
	{
		[CompilerGenerated]
		get
		{
			return RC4mQ49s4t;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = d7JRSnrRvA;
			DataGridView dataGridView = RC4mQ49s4t;
			if (dataGridView != null)
			{
				dataGridView.CellEndEdit -= value2;
			}
			RC4mQ49s4t = value;
			dataGridView = RC4mQ49s4t;
			if (dataGridView != null)
			{
				dataGridView.CellEndEdit += value2;
			}
		}
	}

	internal virtual CheckBox cbIncluirAutocad
	{
		[CompilerGenerated]
		get
		{
			return uNrmPx4RGi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			uNrmPx4RGi = value;
		}
	}

	internal virtual ProgressBar ProgressBar1
	{
		[CompilerGenerated]
		get
		{
			return qghmccGN3T;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qghmccGN3T = value;
		}
	}

	internal virtual CheckBox cbTitulos
	{
		[CompilerGenerated]
		get
		{
			return UnGmKttdXJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			UnGmKttdXJ = value;
		}
	}

	internal virtual Button btRepetirPaginas
	{
		[CompilerGenerated]
		get
		{
			return Hq1meT1GKO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AcpRtoAPOE;
			Button button = Hq1meT1GKO;
			if (button != null)
			{
				button.Click -= value2;
			}
			Hq1meT1GKO = value;
			button = Hq1meT1GKO;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btRepetirEquip
	{
		[CompilerGenerated]
		get
		{
			return nKGm2Xwiv8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = WSLRvdCOX2;
			Button button = nKGm2Xwiv8;
			if (button != null)
			{
				button.Click -= value2;
			}
			nKGm2Xwiv8 = value;
			button = nKGm2Xwiv8;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btAdicionarPaginas
	{
		[CompilerGenerated]
		get
		{
			return HR1m3x0GJI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = dgERjd1tu8;
			Button button = HR1m3x0GJI;
			if (button != null)
			{
				button.Click -= value2;
			}
			HR1m3x0GJI = value;
			button = HR1m3x0GJI;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbPaginaInicial
	{
		[CompilerGenerated]
		get
		{
			return QDCmnL4o1x;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = J0AmpmQFLq;
			TextBox textBox = QDCmnL4o1x;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			QDCmnL4o1x = value;
			textBox = QDCmnL4o1x;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox4
	{
		[CompilerGenerated]
		get
		{
			return iQDm1IZlP2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			iQDm1IZlP2 = value;
		}
	}

	internal virtual GroupBox GroupBox3
	{
		[CompilerGenerated]
		get
		{
			return WjgmlTMLqg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			WjgmlTMLqg = value;
		}
	}

	internal virtual TextBox tbIncremento
	{
		[CompilerGenerated]
		get
		{
			return vVsm5d06gU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = YoBmTstLxw;
			TextBox textBox = vVsm5d06gU;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			vVsm5d06gU = value;
			textBox = vVsm5d06gU;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual Label Label3
	{
		[CompilerGenerated]
		get
		{
			return KkVm0GmG3X;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KkVm0GmG3X = value;
		}
	}

	internal virtual Label Label4
	{
		[CompilerGenerated]
		get
		{
			return t71mROmVD9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			t71mROmVD9 = value;
		}
	}

	internal virtual GroupBox GroupBox5
	{
		[CompilerGenerated]
		get
		{
			return f4EmmwecfF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			f4EmmwecfF = value;
		}
	}

	internal virtual Label Label2
	{
		[CompilerGenerated]
		get
		{
			return NeCmXjnNKL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			NeCmXjnNKL = value;
		}
	}

	internal virtual Button btDxDy
	{
		[CompilerGenerated]
		get
		{
			return V1mmUQp2Ty;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = oj4RLWqbrx;
			Button button = V1mmUQp2Ty;
			if (button != null)
			{
				button.Click -= value2;
			}
			V1mmUQp2Ty = value;
			button = V1mmUQp2Ty;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return odvmyJ36xl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			odvmyJ36xl = value;
		}
	}

	internal virtual TextBox tbDy
	{
		[CompilerGenerated]
		get
		{
			return BODmg6rgI6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			BODmg6rgI6 = value;
		}
	}

	internal virtual TextBox tbDx
	{
		[CompilerGenerated]
		get
		{
			return eepmAuGfr7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			eepmAuGfr7 = value;
		}
	}

	internal virtual Label LabelPN
	{
		[CompilerGenerated]
		get
		{
			return vZDmsHvgQd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			vZDmsHvgQd = value;
		}
	}

	internal virtual TextBox TBNome
	{
		[CompilerGenerated]
		get
		{
			return E8YmBwywR2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = bd4mJ7IOIL;
			TextBox textBox = E8YmBwywR2;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			E8YmBwywR2 = value;
			textBox = E8YmBwywR2;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Button btInserir
	{
		[CompilerGenerated]
		get
		{
			return uT0mV0H0NK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = aLHmGJ3uJJ;
			Button button = uT0mV0H0NK;
			if (button != null)
			{
				button.Click -= value2;
			}
			uT0mV0H0NK = value;
			button = uT0mV0H0NK;
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
			if (disposing && husmHvir4Q != null)
			{
				husmHvir4Q.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void t6LRoYcDxG()
	{
		husmHvir4Q = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
		btCopiarOrigem = new Button();
		FDqpBiUmZij(new ToolTip(husmHvir4Q));
		dgPaineisOrigem = new DataGridView();
		TabControl1 = new TabControl();
		TabPage1 = new TabPage();
		cbIncluirAutocad = new CheckBox();
		GroupBox1 = new GroupBox();
		btSelecionar = new Button();
		rbCompleto = new RadioButton();
		rbSelecao = new RadioButton();
		TabPage2 = new TabPage();
		LabelPN = new Label();
		TBNome = new TextBox();
		btInserir = new Button();
		btRepetirEquip = new Button();
		dgPaineisDestino = new DataGridView();
		dgRelacaoPaineis = new DataGridView();
		TabPage3 = new TabPage();
		GroupBox5 = new GroupBox();
		Label2 = new Label();
		btDxDy = new Button();
		Label1 = new Label();
		tbDy = new TextBox();
		tbDx = new TextBox();
		GroupBox4 = new GroupBox();
		Label3 = new Label();
		tbPaginaInicial = new TextBox();
		btAdicionarPaginas = new Button();
		btRelacionarPaginas = new Button();
		dgPaginasDestino = new DataGridView();
		GroupBox3 = new GroupBox();
		Label4 = new Label();
		tbIncremento = new TextBox();
		btRepetirPaginas = new Button();
		dgRelacaoPaginas = new DataGridView();
		TabPage4 = new TabPage();
		dgTags = new DataGridView();
		TabPage5 = new TabPage();
		dgReguas = new DataGridView();
		TabPage6 = new TabPage();
		cbTitulos = new CheckBox();
		ProgressBar1 = new ProgressBar();
		btImportar = new Button();
		((ISupportInitialize)dgPaineisOrigem).BeginInit();
		TabControl1.SuspendLayout();
		TabPage1.SuspendLayout();
		GroupBox1.SuspendLayout();
		TabPage2.SuspendLayout();
		((ISupportInitialize)dgPaineisDestino).BeginInit();
		((ISupportInitialize)dgRelacaoPaineis).BeginInit();
		TabPage3.SuspendLayout();
		GroupBox5.SuspendLayout();
		GroupBox4.SuspendLayout();
		((ISupportInitialize)dgPaginasDestino).BeginInit();
		GroupBox3.SuspendLayout();
		((ISupportInitialize)dgRelacaoPaginas).BeginInit();
		TabPage4.SuspendLayout();
		((ISupportInitialize)dgTags).BeginInit();
		TabPage5.SuspendLayout();
		((ISupportInitialize)dgReguas).BeginInit();
		TabPage6.SuspendLayout();
		SuspendLayout();
		btCopiarOrigem.FlatStyle = FlatStyle.Flat;
		btCopiarOrigem.ForeColor = SystemColors.Control;
		btCopiarOrigem.Image = Resources.Copy_32;
		btCopiarOrigem.Location = new Point(65, 59);
		btCopiarOrigem.Name = "btCopiarOrigem";
		btCopiarOrigem.Size = new Size(40, 40);
		btCopiarOrigem.TabIndex = 7;
		btCopiarOrigem.UseVisualStyleBackColor = true;
		dgPaineisOrigem.AllowUserToAddRows = false;
		dgPaineisOrigem.AllowUserToDeleteRows = false;
		dgPaineisOrigem.AllowUserToResizeRows = false;
		dgPaineisOrigem.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgPaineisOrigem.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgPaineisOrigem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgPaineisOrigem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPaineisOrigem.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgPaineisOrigem.Location = new Point(199, 6);
		dgPaineisOrigem.Name = "dgPaineisOrigem";
		dgPaineisOrigem.ReadOnly = true;
		dgPaineisOrigem.RowHeadersVisible = false;
		dgPaineisOrigem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPaineisOrigem.Size = new Size(211, 399);
		dgPaineisOrigem.TabIndex = 44;
		TabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TabControl1.Controls.Add(TabPage1);
		TabControl1.Controls.Add(TabPage2);
		TabControl1.Controls.Add(TabPage3);
		TabControl1.Controls.Add(TabPage4);
		TabControl1.Controls.Add(TabPage5);
		TabControl1.Controls.Add(TabPage6);
		TabControl1.Location = new Point(12, 12);
		TabControl1.Name = "TabControl1";
		TabControl1.SelectedIndex = 0;
		TabControl1.Size = new Size(426, 437);
		TabControl1.TabIndex = 45;
		TabPage1.BackColor = SystemColors.ButtonFace;
		TabPage1.Controls.Add(cbIncluirAutocad);
		TabPage1.Controls.Add(GroupBox1);
		TabPage1.Controls.Add(dgPaineisOrigem);
		TabPage1.Location = new Point(4, 22);
		TabPage1.Name = "TabPage1";
		TabPage1.Padding = new Padding(3);
		TabPage1.Size = new Size(418, 411);
		TabPage1.TabIndex = 0;
		TabPage1.Text = "TabPage1";
		cbIncluirAutocad.AutoSize = true;
		cbIncluirAutocad.Location = new Point(12, 226);
		cbIncluirAutocad.Name = "cbIncluirAutocad";
		cbIncluirAutocad.Size = new Size(149, 17);
		cbIncluirAutocad.TabIndex = 46;
		cbIncluirAutocad.Text = "Incluir Elementos Autocad";
		cbIncluirAutocad.UseVisualStyleBackColor = true;
		GroupBox1.Controls.Add(btSelecionar);
		GroupBox1.Controls.Add(rbCompleto);
		GroupBox1.Controls.Add(rbSelecao);
		GroupBox1.Controls.Add(btCopiarOrigem);
		GroupBox1.Location = new Point(6, 6);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(187, 199);
		GroupBox1.TabIndex = 45;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "Tipo de Clonagem";
		btSelecionar.FlatStyle = FlatStyle.Flat;
		btSelecionar.ForeColor = SystemColors.Control;
		btSelecionar.Image = Resources.Select_32;
		btSelecionar.Location = new Point(65, 151);
		btSelecionar.Name = "btSelecionar";
		btSelecionar.Size = new Size(40, 40);
		btSelecionar.TabIndex = 46;
		btSelecionar.UseVisualStyleBackColor = true;
		rbCompleto.AutoSize = true;
		rbCompleto.Location = new Point(6, 36);
		rbCompleto.Name = "rbCompleto";
		rbCompleto.Size = new Size(144, 17);
		rbCompleto.TabIndex = 47;
		rbCompleto.TabStop = true;
		rbCompleto.Text = "Equipamentos Completos";
		rbCompleto.UseVisualStyleBackColor = true;
		rbSelecao.AutoSize = true;
		rbSelecao.Location = new Point(6, 128);
		rbSelecao.Name = "rbSelecao";
		rbSelecao.Size = new Size(138, 17);
		rbSelecao.TabIndex = 46;
		rbSelecao.TabStop = true;
		rbSelecao.Text = "Seleção de Dispositivos";
		rbSelecao.UseVisualStyleBackColor = true;
		TabPage2.BackColor = SystemColors.ButtonFace;
		TabPage2.Controls.Add(LabelPN);
		TabPage2.Controls.Add(TBNome);
		TabPage2.Controls.Add(btInserir);
		TabPage2.Controls.Add(btRepetirEquip);
		TabPage2.Controls.Add(dgPaineisDestino);
		TabPage2.Controls.Add(dgRelacaoPaineis);
		TabPage2.Location = new Point(4, 22);
		TabPage2.Name = "TabPage2";
		TabPage2.Padding = new Padding(3);
		TabPage2.Size = new Size(418, 411);
		TabPage2.TabIndex = 1;
		TabPage2.Text = "TabPage2";
		LabelPN.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		LabelPN.BorderStyle = BorderStyle.Fixed3D;
		LabelPN.Location = new Point(242, 6);
		LabelPN.Name = "LabelPN";
		LabelPN.Size = new Size(125, 17);
		LabelPN.TabIndex = 184;
		LabelPN.Text = "LB Novo Painel";
		LabelPN.TextAlign = ContentAlignment.MiddleCenter;
		TBNome.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		TBNome.Location = new Point(242, 26);
		TBNome.Name = "TBNome";
		TBNome.Size = new Size(125, 20);
		TBNome.TabIndex = 183;
		btInserir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btInserir.FlatStyle = FlatStyle.Flat;
		btInserir.ForeColor = SystemColors.Control;
		btInserir.Image = Resources.Adiciona_32;
		btInserir.Location = new Point(373, 6);
		btInserir.Name = "btInserir";
		btInserir.Size = new Size(39, 40);
		btInserir.TabIndex = 182;
		btInserir.UseVisualStyleBackColor = true;
		btRepetirEquip.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		btRepetirEquip.FlatStyle = FlatStyle.Flat;
		btRepetirEquip.ForeColor = Color.Transparent;
		btRepetirEquip.Image = Resources.Repetir_32;
		btRepetirEquip.Location = new Point(158, 6);
		btRepetirEquip.MaximumSize = new Size(40, 40);
		btRepetirEquip.Name = "btRepetirEquip";
		btRepetirEquip.Size = new Size(40, 40);
		btRepetirEquip.TabIndex = 53;
		btRepetirEquip.UseVisualStyleBackColor = true;
		dgPaineisDestino.AllowDrop = true;
		dgPaineisDestino.AllowUserToAddRows = false;
		dgPaineisDestino.AllowUserToDeleteRows = false;
		dgPaineisDestino.AllowUserToResizeRows = false;
		dgPaineisDestino.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		dgPaineisDestino.BackgroundColor = Color.White;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dgPaineisDestino.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgPaineisDestino.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPaineisDestino.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgPaineisDestino.Location = new Point(242, 52);
		dgPaineisDestino.MultiSelect = false;
		dgPaineisDestino.Name = "dgPaineisDestino";
		dgPaineisDestino.ReadOnly = true;
		dgPaineisDestino.RowHeadersVisible = false;
		dgPaineisDestino.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPaineisDestino.Size = new Size(170, 353);
		dgPaineisDestino.TabIndex = 46;
		dgRelacaoPaineis.AllowDrop = true;
		dgRelacaoPaineis.AllowUserToAddRows = false;
		dgRelacaoPaineis.AllowUserToDeleteRows = false;
		dgRelacaoPaineis.AllowUserToResizeRows = false;
		dgRelacaoPaineis.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgRelacaoPaineis.BackgroundColor = Color.White;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		dgRelacaoPaineis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		dgRelacaoPaineis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgRelacaoPaineis.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgRelacaoPaineis.Location = new Point(6, 52);
		dgRelacaoPaineis.Name = "dgRelacaoPaineis";
		dgRelacaoPaineis.ReadOnly = true;
		dgRelacaoPaineis.RowHeadersVisible = false;
		dgRelacaoPaineis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRelacaoPaineis.Size = new Size(230, 353);
		dgRelacaoPaineis.TabIndex = 45;
		TabPage3.BackColor = SystemColors.ButtonFace;
		TabPage3.Controls.Add(GroupBox5);
		TabPage3.Controls.Add(GroupBox4);
		TabPage3.Controls.Add(btRelacionarPaginas);
		TabPage3.Controls.Add(dgPaginasDestino);
		TabPage3.Controls.Add(GroupBox3);
		TabPage3.Controls.Add(dgRelacaoPaginas);
		TabPage3.Location = new Point(4, 22);
		TabPage3.Name = "TabPage3";
		TabPage3.Padding = new Padding(3);
		TabPage3.Size = new Size(418, 411);
		TabPage3.TabIndex = 2;
		TabPage3.Text = "TabPage3";
		GroupBox5.Controls.Add(Label2);
		GroupBox5.Controls.Add(btDxDy);
		GroupBox5.Controls.Add(Label1);
		GroupBox5.Controls.Add(tbDy);
		GroupBox5.Controls.Add(tbDx);
		GroupBox5.Location = new Point(6, 182);
		GroupBox5.Name = "GroupBox5";
		GroupBox5.Size = new Size(117, 75);
		GroupBox5.TabIndex = 56;
		GroupBox5.TabStop = false;
		GroupBox5.Text = "GroupBox5";
		Label2.AutoSize = true;
		Label2.Location = new Point(7, 48);
		Label2.Name = "Label2";
		Label2.Size = new Size(14, 13);
		Label2.TabIndex = 60;
		Label2.Text = "Y";
		btDxDy.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		btDxDy.FlatStyle = FlatStyle.Flat;
		btDxDy.ForeColor = Color.Transparent;
		btDxDy.Image = Resources.Deslocamento_32;
		btDxDy.Location = new Point(71, 21);
		btDxDy.MaximumSize = new Size(40, 40);
		btDxDy.Name = "btDxDy";
		btDxDy.Size = new Size(40, 40);
		btDxDy.TabIndex = 53;
		btDxDy.UseVisualStyleBackColor = true;
		Label1.AutoSize = true;
		Label1.Location = new Point(7, 23);
		Label1.Name = "Label1";
		Label1.Size = new Size(14, 13);
		Label1.TabIndex = 59;
		Label1.Text = "X";
		tbDy.Location = new Point(27, 45);
		tbDy.Name = "tbDy";
		tbDy.Size = new Size(38, 20);
		tbDy.TabIndex = 58;
		tbDx.Location = new Point(27, 19);
		tbDx.Name = "tbDx";
		tbDx.Size = new Size(38, 20);
		tbDx.TabIndex = 57;
		GroupBox4.Controls.Add(Label3);
		GroupBox4.Controls.Add(tbPaginaInicial);
		GroupBox4.Controls.Add(btAdicionarPaginas);
		GroupBox4.Location = new Point(6, 94);
		GroupBox4.Name = "GroupBox4";
		GroupBox4.Size = new Size(117, 82);
		GroupBox4.TabIndex = 55;
		GroupBox4.TabStop = false;
		GroupBox4.Text = "GroupBox4";
		Label3.Location = new Point(10, 30);
		Label3.Name = "Label3";
		Label3.Size = new Size(40, 20);
		Label3.TabIndex = 56;
		Label3.Text = "Início";
		Label3.TextAlign = ContentAlignment.MiddleLeft;
		tbPaginaInicial.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		tbPaginaInicial.Location = new Point(13, 53);
		tbPaginaInicial.Name = "tbPaginaInicial";
		tbPaginaInicial.Size = new Size(40, 20);
		tbPaginaInicial.TabIndex = 52;
		tbPaginaInicial.TextAlign = HorizontalAlignment.Center;
		btAdicionarPaginas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		btAdicionarPaginas.FlatStyle = FlatStyle.Flat;
		btAdicionarPaginas.ForeColor = Color.Transparent;
		btAdicionarPaginas.Image = Resources.PaginasCrescente_32;
		btAdicionarPaginas.Location = new Point(71, 33);
		btAdicionarPaginas.MaximumSize = new Size(40, 40);
		btAdicionarPaginas.Name = "btAdicionarPaginas";
		btAdicionarPaginas.Size = new Size(40, 40);
		btAdicionarPaginas.TabIndex = 53;
		btAdicionarPaginas.UseVisualStyleBackColor = true;
		btRelacionarPaginas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		btRelacionarPaginas.FlatStyle = FlatStyle.Flat;
		btRelacionarPaginas.ForeColor = Color.Transparent;
		btRelacionarPaginas.Image = Resources.AtribuirDir_32;
		btRelacionarPaginas.Location = new Point(347, 3);
		btRelacionarPaginas.MaximumSize = new Size(40, 40);
		btRelacionarPaginas.Name = "btRelacionarPaginas";
		btRelacionarPaginas.Size = new Size(40, 40);
		btRelacionarPaginas.TabIndex = 50;
		btRelacionarPaginas.UseVisualStyleBackColor = true;
		dgPaginasDestino.AllowDrop = true;
		dgPaginasDestino.AllowUserToAddRows = false;
		dgPaginasDestino.AllowUserToDeleteRows = false;
		dgPaginasDestino.AllowUserToResizeRows = false;
		dgPaginasDestino.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		dgPaginasDestino.BackgroundColor = Color.White;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = SystemColors.Control;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		dgPaginasDestino.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		dgPaginasDestino.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPaginasDestino.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgPaginasDestino.Location = new Point(320, 47);
		dgPaginasDestino.Name = "dgPaginasDestino";
		dgPaginasDestino.ReadOnly = true;
		dgPaginasDestino.RowHeadersVisible = false;
		dgPaginasDestino.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPaginasDestino.Size = new Size(90, 358);
		dgPaginasDestino.TabIndex = 49;
		GroupBox3.Controls.Add(Label4);
		GroupBox3.Controls.Add(tbIncremento);
		GroupBox3.Controls.Add(btRepetirPaginas);
		GroupBox3.Location = new Point(6, 6);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(117, 82);
		GroupBox3.TabIndex = 54;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "GroupBox3";
		Label4.ImageAlign = ContentAlignment.MiddleLeft;
		Label4.Location = new Point(6, 31);
		Label4.Name = "Label4";
		Label4.Size = new Size(68, 20);
		Label4.TabIndex = 57;
		Label4.Text = "Incremento";
		Label4.TextAlign = ContentAlignment.MiddleLeft;
		tbIncremento.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		tbIncremento.Location = new Point(13, 53);
		tbIncremento.Name = "tbIncremento";
		tbIncremento.Size = new Size(40, 20);
		tbIncremento.TabIndex = 53;
		tbIncremento.TextAlign = HorizontalAlignment.Center;
		btRepetirPaginas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		btRepetirPaginas.FlatStyle = FlatStyle.Flat;
		btRepetirPaginas.ForeColor = Color.Transparent;
		btRepetirPaginas.Image = Resources.Repetir_32;
		btRepetirPaginas.Location = new Point(71, 33);
		btRepetirPaginas.MaximumSize = new Size(40, 40);
		btRepetirPaginas.Name = "btRepetirPaginas";
		btRepetirPaginas.Size = new Size(40, 40);
		btRepetirPaginas.TabIndex = 51;
		btRepetirPaginas.UseVisualStyleBackColor = true;
		dgRelacaoPaginas.AllowDrop = true;
		dgRelacaoPaginas.AllowUserToAddRows = false;
		dgRelacaoPaginas.AllowUserToDeleteRows = false;
		dgRelacaoPaginas.AllowUserToResizeRows = false;
		dgRelacaoPaginas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgRelacaoPaginas.BackgroundColor = Color.White;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle5.BackColor = SystemColors.Control;
		dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
		dgRelacaoPaginas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
		dgRelacaoPaginas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgRelacaoPaginas.Location = new Point(129, 6);
		dgRelacaoPaginas.Name = "dgRelacaoPaginas";
		dgRelacaoPaginas.RowHeadersVisible = false;
		dgRelacaoPaginas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRelacaoPaginas.Size = new Size(179, 399);
		dgRelacaoPaginas.TabIndex = 47;
		TabPage4.BackColor = SystemColors.ButtonFace;
		TabPage4.Controls.Add(dgTags);
		TabPage4.Location = new Point(4, 22);
		TabPage4.Name = "TabPage4";
		TabPage4.Padding = new Padding(3);
		TabPage4.Size = new Size(418, 411);
		TabPage4.TabIndex = 3;
		TabPage4.Text = "TabPage4";
		dgTags.AllowDrop = true;
		dgTags.AllowUserToAddRows = false;
		dgTags.AllowUserToDeleteRows = false;
		dgTags.AllowUserToResizeRows = false;
		dgTags.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgTags.BackgroundColor = Color.White;
		dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle6.BackColor = SystemColors.Control;
		dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
		dgTags.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
		dgTags.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgTags.Location = new Point(6, 6);
		dgTags.MultiSelect = false;
		dgTags.Name = "dgTags";
		dgTags.RowHeadersVisible = false;
		dgTags.SelectionMode = DataGridViewSelectionMode.CellSelect;
		dgTags.Size = new Size(406, 399);
		dgTags.TabIndex = 48;
		TabPage5.BackColor = SystemColors.ButtonFace;
		TabPage5.Controls.Add(dgReguas);
		TabPage5.Location = new Point(4, 22);
		TabPage5.Name = "TabPage5";
		TabPage5.Size = new Size(418, 411);
		TabPage5.TabIndex = 5;
		TabPage5.Text = "TabPage5";
		dgReguas.AllowDrop = true;
		dgReguas.AllowUserToAddRows = false;
		dgReguas.AllowUserToDeleteRows = false;
		dgReguas.AllowUserToResizeRows = false;
		dgReguas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgReguas.BackgroundColor = Color.White;
		dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle7.BackColor = SystemColors.Control;
		dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
		dgReguas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
		dgReguas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgReguas.Location = new Point(6, 6);
		dgReguas.MultiSelect = false;
		dgReguas.Name = "dgReguas";
		dgReguas.RowHeadersVisible = false;
		dgReguas.SelectionMode = DataGridViewSelectionMode.CellSelect;
		dgReguas.Size = new Size(406, 399);
		dgReguas.TabIndex = 49;
		TabPage6.BackColor = SystemColors.ButtonFace;
		TabPage6.Controls.Add(cbTitulos);
		TabPage6.Controls.Add(ProgressBar1);
		TabPage6.Controls.Add(btImportar);
		TabPage6.Location = new Point(4, 22);
		TabPage6.Name = "TabPage6";
		TabPage6.Padding = new Padding(3);
		TabPage6.Size = new Size(418, 411);
		TabPage6.TabIndex = 4;
		TabPage6.Text = "TabPage6";
		cbTitulos.AutoSize = true;
		cbTitulos.Location = new Point(139, 64);
		cbTitulos.Name = "cbTitulos";
		cbTitulos.Size = new Size(150, 17);
		cbTitulos.TabIndex = 47;
		cbTitulos.Text = "CopiarTítulos das Páginas";
		cbTitulos.UseVisualStyleBackColor = true;
		ProgressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ProgressBar1.Location = new Point(6, 382);
		ProgressBar1.Name = "ProgressBar1";
		ProgressBar1.Size = new Size(406, 23);
		ProgressBar1.TabIndex = 14;
		btImportar.BackColor = Color.White;
		btImportar.FlatAppearance.BorderColor = Color.Gray;
		btImportar.FlatStyle = FlatStyle.Flat;
		btImportar.ForeColor = SystemColors.Control;
		btImportar.Image = Resources.Clonar_32;
		btImportar.Location = new Point(171, 133);
		btImportar.MaximumSize = new Size(60, 60);
		btImportar.Name = "btImportar";
		btImportar.Size = new Size(60, 60);
		btImportar.TabIndex = 13;
		btImportar.UseVisualStyleBackColor = false;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(454, 461);
		Controls.Add(TabControl1);
		MinimumSize = new Size(470, 500);
		Name = "frmClonar";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Clonar Equipamentos";
		((ISupportInitialize)dgPaineisOrigem).EndInit();
		TabControl1.ResumeLayout(performLayout: false);
		TabPage1.ResumeLayout(performLayout: false);
		TabPage1.PerformLayout();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		TabPage2.ResumeLayout(performLayout: false);
		TabPage2.PerformLayout();
		((ISupportInitialize)dgPaineisDestino).EndInit();
		((ISupportInitialize)dgRelacaoPaineis).EndInit();
		TabPage3.ResumeLayout(performLayout: false);
		GroupBox5.ResumeLayout(performLayout: false);
		GroupBox5.PerformLayout();
		GroupBox4.ResumeLayout(performLayout: false);
		GroupBox4.PerformLayout();
		((ISupportInitialize)dgPaginasDestino).EndInit();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox3.PerformLayout();
		((ISupportInitialize)dgRelacaoPaginas).EndInit();
		TabPage4.ResumeLayout(performLayout: false);
		((ISupportInitialize)dgTags).EndInit();
		TabPage5.ResumeLayout(performLayout: false);
		((ISupportInitialize)dgReguas).EndInit();
		TabPage6.ResumeLayout(performLayout: false);
		TabPage6.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return JmDmd6oAp9;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		JmDmd6oAp9 = WithEventsValue;
	}

	public frmClonar()
	{
		Resize += YPyRrfevCU;
		Wm6m4JAMfD = 0;
		EGXXWXINHr = 0;
		rLUXpffcou = 0;
		iY5XoVQRVT = new List<string>();
		HKpXGYd0X0 = new List<int>();
		enJXHpMK9n = new List<int>();
		Y4AXkdy2Vo = new List<int>();
		uqkXdUUkXi = new List<int>();
		oRMXfpYJmN = new List<int>();
		eP1XDkAEjL = new List<string>();
		Fa9XvTMgF7 = new List<string>();
		itAX6nfgHK = new List<int>();
		oTwXtv1S5m = new List<string>();
		l9FXj7AEv7 = new List<string>();
		tjjXnhnMeM = 0;
		VtPX1rsDvB = 0;
		try
		{
			if (!Geral.ExisteForm("frmClonar"))
			{
				t6LRoYcDxG();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 882]);
				GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 883]);
				GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1452]);
				GroupBox4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1524]);
				GroupBox5.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 419]);
				rbSelecao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 884]);
				rbCompleto.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 885]);
				cbIncluirAutocad.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 482]);
				cbTitulos.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 484]);
				Label3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1525]);
				Label4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1526]);
				LabelPN.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1086]);
				w8dpBZ0kvSD().SetToolTip(btInserir, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1086]));
				TabControl1.TabPages[0].Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 889]);
				TabControl1.TabPages[1].Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 890]);
				TabControl1.TabPages[2].Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 891]);
				TabControl1.TabPages[3].Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 893]);
				TabControl1.TabPages[4].Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 788]);
				TabControl1.TabPages[5].Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 892]);
				w8dpBZ0kvSD().SetToolTip(btRepetirEquip, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1502]));
				w8dpBZ0kvSD().SetToolTip(btRepetirPaginas, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1452]));
				w8dpBZ0kvSD().SetToolTip(btImportar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1453]));
				Application.ShowModelessDialog((Form)this);
				GroupBox1.Enabled = false;
				oBBXTa1FnI = new object[2, 1];
				o7qXJlN286 = new object[2, 1];
				cbIncluirAutocad.Checked = true;
				TabControl1.TabPages[0].Enabled = true;
				TabControl1.TabPages[1].Enabled = false;
				TabControl1.TabPages[2].Enabled = false;
				TabControl1.TabPages[3].Enabled = false;
				TabControl1.TabPages[4].Enabled = false;
				TabControl1.TabPages[5].Enabled = false;
				ref object[,] reference = ref oBBXTa1FnI;
				object mPaineis = reference;
				clsPainel.PaineisDocumento(ref mPaineis, bTopografico: true);
				reference = (object[,])mPaineis;
				epPRXk0gHx();
				FormataDGPaineisOrigem();
				cKhR0ml5Fg();
				AtualizaDGPaineisOrigem();
				Db0XOPg78y = new DeclaracoesClonar.structureRelacaoModelosReles[1];
				NorX7Wq2br = new DeclaracoesClonar.structureRelacaoModelosMascara[1];
				tbDx.Text = "0";
				tbDy.Text = "0";
				sstRGDnEJY();
				Correcao.ApagaXDataTerceiros();
				GroupBox1.Enabled = true;
				rbCompleto.Checked = true;
				btCopiarOrigem.Enabled = true;
				btSelecionar.Enabled = false;
				if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
				{
					Left = 0;
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void sstRGDnEJY()
	{
		Pagina.capturaTitulos();
		WtSXLE2mAu = new DeclaracoesClonar.structureTitulosPaginas[1];
		int num = Information.UBound(DeclaracoesGeral.mTitulos, 2);
		checked
		{
			for (int i = 2; i <= num; i++)
			{
				ref DeclaracoesClonar.structureTitulosPaginas[] wtSXLE2mAu = ref WtSXLE2mAu;
				wtSXLE2mAu = (DeclaracoesClonar.structureTitulosPaginas[])Utils.CopyArray(wtSXLE2mAu, new DeclaracoesClonar.structureTitulosPaginas[Information.UBound(WtSXLE2mAu) + 1 + 1]);
				WtSXLE2mAu[Information.UBound(WtSXLE2mAu)].pagOrigem = Conversions.ToString(DeclaracoesGeral.mTitulos[0, i]);
				WtSXLE2mAu[Information.UBound(WtSXLE2mAu)].Tit1 = Conversions.ToString(DeclaracoesGeral.mTitulos[1, i]);
				WtSXLE2mAu[Information.UBound(WtSXLE2mAu)].Tit2 = Conversions.ToString(DeclaracoesGeral.mTitulos[2, i]);
				WtSXLE2mAu[Information.UBound(WtSXLE2mAu)].Tit3 = Conversions.ToString(DeclaracoesGeral.mTitulos[3, i]);
				WtSXLE2mAu[Information.UBound(WtSXLE2mAu)].Tit4 = Conversions.ToString(DeclaracoesGeral.mTitulos[4, i]);
			}
		}
	}

	private void wCqRHBe01K(object P_0, EventArgs P_1)
	{
		checked
		{
			if (TabControl1.SelectedIndex != 1)
			{
				if (TabControl1.SelectedIndex != 2)
				{
					if (TabControl1.SelectedIndex != 3)
					{
						if (TabControl1.SelectedIndex != 4)
						{
							if (TabControl1.SelectedIndex == 5 && TabControl1.TabPages[5].Enabled)
							{
								A7ORVQTM4N();
								UoYR4OoXLu();
								O4HX8q2Ye9 = new Declaracoes2.StructureModeloDeReguas[1];
								FkSXNW1U97 = new DeclaracoesClonar.structureRelacaoModelosRegua[1];
								JGiRCVbMvK();
							}
						}
						else
						{
							if (TabControl1.TabPages[4].Enabled)
							{
								BwoXai25qY = new Declaracoes2.StructureModeloDeReguas[1];
								DicionarioReguas.LeOsModelosDeRegua(ref BwoXai25qY);
								formataDGReguas();
								HALRE5IqNP();
							}
							TabControl1.TabPages[5].Enabled = true;
						}
					}
					else
					{
						if (!fXmRAdlfuN())
						{
							TabControl1.SelectedIndex = 2;
						}
						if (TabControl1.TabPages[3].Enabled)
						{
							formataDGTags();
							AcLRuKUhhy();
						}
						TabControl1.TabPages[4].Enabled = true;
					}
				}
				else if (TabControl1.TabPages[2].Enabled)
				{
					ApomC4Vd2K = new structureAddPainel[1];
					int num = dgRelacaoPaineis.RowCount - 1;
					for (int i = 0; i <= num; i++)
					{
						if (Operators.ConditionalCompareObjectEqual(dgRelacaoPaineis.Rows[i].Cells[2].Value, 0, TextCompare: true))
						{
							int num2 = Information.UBound(ApomC4Vd2K) + 1;
							ref structureAddPainel[] apomC4Vd2K = ref ApomC4Vd2K;
							apomC4Vd2K = (structureAddPainel[])Utils.CopyArray(apomC4Vd2K, new structureAddPainel[num2 + 1]);
							ApomC4Vd2K[num2].iPN = Wm6m4JAMfD;
							ApomC4Vd2K[num2].sPN = Conversions.ToString(dgRelacaoPaineis.Rows[i].Cells[3].Value);
							dgRelacaoPaineis.Rows[i].Cells[2].Value = Wm6m4JAMfD;
							Wm6m4JAMfD++;
						}
					}
					if (!DHrRgtv4WV())
					{
						TabControl1.SelectedIndex = 1;
					}
					vQoRyPqIs4();
					AtualizaDGRelacaoPaineis();
					FormataDGRelacaoPaginas();
					UFQRs9pqkT();
					tbPaginaInicial.Text = "2";
					tbIncremento.Text = "0";
					FormataDGPaginasDestino();
					s3VRBfbEPL();
					TabControl1.TabPages[3].Enabled = true;
				}
			}
			else if (!TabControl1.TabPages[1].Enabled)
			{
				TabControl1.SelectedIndex = 0;
			}
			else
			{
				if (Information.IsNothing(DeclaracoesGeral.dicPainel))
				{
					cDadosAccess.carregaPainelDicionario();
				}
				foreach (KeyValuePair<int, string> item in DeclaracoesGeral.dicPainel)
				{
					if (Wm6m4JAMfD <= item.Key)
					{
						Wm6m4JAMfD = item.Key + 1;
					}
				}
				NtRXb2BLqs = new DeclaracoesClonar.structureTagsUsados[1];
				clsClonar.carregaTagsUsados(ref NtRXb2BLqs);
				cDadosAccess.carregaPainelDicionario();
				FormataDGRelacaoPaineis();
				AEMRmDX8CE();
				FormataDGPaineisDestino();
				fqNRRn2Ll9();
				if (Operators.CompareString(MXYmrCUv06, DeclaracoesGeral.Conf.DirProjeto, TextCompare: true) == 0)
				{
					btRepetirEquip.Enabled = true;
				}
				else
				{
					btRepetirEquip.Enabled = false;
				}
				TabControl1.TabPages[2].Enabled = true;
			}
			FqMR95obDx();
		}
	}

	private void FEeRkrKNj3(object P_0, EventArgs P_1)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected Obj, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected Obj, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.bAnularEventos = true;
		btCopiarOrigem.Enabled = false;
		KEBXhQDjyG = new DeclaracoesClonar.structureDispOrigem[1];
		rhWmuCoU2N = new ObjectIdCollection();
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		_ = Application.DocumentManager.MdiActiveDocument.Editor;
		cIWmSsuihd = database.Ltscale;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
			BlockTableRecordEnumerator enumerator = default;
			try
			{
				enumerator = val3.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					rhWmuCoU2N.Add(current);
				}
			}
			finally
			{
				((IDisposable)enumerator)?.Dispose();
			}
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			val.Abort();
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		n4PXqFWmdW = new Declaracoes2.StructureModeloDeReguas[1];
		DicionarioReguas.LeOsModelosDeRegua(ref n4PXqFWmdW);
		LONRfIMpV2();
		btCopiarOrigem.Enabled = true;
	}

	private void MpsRdu6dRM(object P_0, EventArgs P_1)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected Obj, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected Obj, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected Obj, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Invalid comparison between Unknown and I4
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Expected Obj, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected Obj, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.bAnularEventos = true;
		PointMonitorToolTips.StopMonitor();
		rhWmuCoU2N = new ObjectIdCollection();
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		cIWmSsuihd = database.Ltscale;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
			MsgBoxResult msgBoxResult;
			do
			{
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				PromptSelectionOptions val4 = new PromptSelectionOptions();
				val4.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 886]);
				PromptSelectionResult selection = editor.GetSelection(val4);
				if ((int)selection.Status != 5100)
				{
					break;
				}
				SelectionSet value = selection.Value;
				ObjectIdCollection val5 = new ObjectIdCollection(value.GetObjectIds());
				foreach (object item in val5)
				{
					ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
					if (!rhWmuCoU2N.Contains(val6))
					{
						rhWmuCoU2N.Add(val6);
					}
				}
				msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 887]), MsgBoxStyle.YesNo, "Elétron");
			}
			while (msgBoxResult == MsgBoxResult.Yes);
			BlockTableRecordEnumerator enumerator2 = default;
			try
			{
				enumerator2 = val3.GetEnumerator();
				short tipo = default;
				while (enumerator2.MoveNext())
				{
					ObjectId current2 = enumerator2.Current;
					Entity val7 = (Entity)current2.GetObject((OpenMode)0);
					try
					{
						if (!val7.Visible)
						{
							BlockReference val8 = (BlockReference)(object)((val7 is BlockReference) ? val7 : null);
							if (val8 != null)
							{
								Declaracoes2.StructureModelo Modelo = default;
								Entity Ent = val7;
								if (XDataDispositivosMaster.LerXDataModelo(ref Ent, ref Modelo))
								{
									rhWmuCoU2N.Add(current2);
								}
							}
						}
						DBText val9 = (DBText)(object)((val7 is DBText) ? val7 : null);
						try
						{
							if (val9 != null)
							{
								string handle = "";
								string THandle = "";
								Entity Ent = (Entity)(object)val9;
								string sOpcionais = "";
								if (XDataInterligacao.lerXDataAuxInterligacao(ref Ent, ref handle, ref tipo, ref THandle, ref sOpcionais) && !rhWmuCoU2N.Contains(current2))
								{
									rhWmuCoU2N.Add(current2);
								}
							}
						}
						finally
						{
							((IDisposable)val9)?.Dispose();
						}
					}
					finally
					{
						((IDisposable)val7)?.Dispose();
					}
				}
			}
			finally
			{
				((IDisposable)enumerator2)?.Dispose();
			}
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			val.Abort();
			Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		n4PXqFWmdW = new Declaracoes2.StructureModeloDeReguas[1];
		DicionarioReguas.LeOsModelosDeRegua(ref n4PXqFWmdW);
		LONRfIMpV2();
		PointMonitorToolTips.StartMonitor();
	}

	private void LONRfIMpV2()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected Obj, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected Obj, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_113a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected Obj, but got Unknown
		//IL_1034: Unknown result type (might be due to invalid IL or missing references)
		//IL_1039: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e68: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_11fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c45: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c72: Unknown result type (might be due to invalid IL or missing references)
		//IL_1084: Unknown result type (might be due to invalid IL or missing references)
		//IL_1089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ecb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1202: Unknown result type (might be due to invalid IL or missing references)
		//IL_120c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1213: Expected Obj, but got Unknown
		//IL_043a: Unknown result type (might be due to invalid IL or missing references)
		//IL_043f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_0550: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_0732: Unknown result type (might be due to invalid IL or missing references)
		//IL_0737: Unknown result type (might be due to invalid IL or missing references)
		//IL_075a: Unknown result type (might be due to invalid IL or missing references)
		//IL_075f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0848: Unknown result type (might be due to invalid IL or missing references)
		//IL_084d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d61: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1898: Unknown result type (might be due to invalid IL or missing references)
		//IL_189f: Expected Obj, but got Unknown
		//IL_23cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_23d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ead: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d9: Expected Obj, but got Unknown
		//IL_1eb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ebc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ec3: Expected Obj, but got Unknown
		//IL_1abc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ac1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ae4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ae9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bce: Unknown result type (might be due to invalid IL or missing references)
		//IL_1948: Unknown result type (might be due to invalid IL or missing references)
		//IL_194d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1970: Unknown result type (might be due to invalid IL or missing references)
		//IL_1975: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1503: Unknown result type (might be due to invalid IL or missing references)
		//IL_1508: Unknown result type (might be due to invalid IL or missing references)
		//IL_152b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1530: Unknown result type (might be due to invalid IL or missing references)
		//IL_16ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1717: Unknown result type (might be due to invalid IL or missing references)
		//IL_171c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1633: Unknown result type (might be due to invalid IL or missing references)
		//IL_1819: Unknown result type (might be due to invalid IL or missing references)
		//IL_1334: Unknown result type (might be due to invalid IL or missing references)
		//IL_1339: Unknown result type (might be due to invalid IL or missing references)
		//IL_135c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1361: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cf9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1461: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f92: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f97: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fba: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e00: Unknown result type (might be due to invalid IL or missing references)
		//IL_20a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_231e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2325: Expected Obj, but got Unknown
		//IL_2188: Unknown result type (might be due to invalid IL or missing references)
		//IL_218d: Unknown result type (might be due to invalid IL or missing references)
		//IL_21b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_21b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_227e: Unknown result type (might be due to invalid IL or missing references)
		//IL_22d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_234e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2396: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.bAnularEventos = true;
		PointMonitorToolTips.StopMonitor();
		KEBXhQDjyG = new DeclaracoesClonar.structureDispOrigem[1];
		int num = 0;
		string[,] array = new string[3, 1];
		x1rmEXKB4D = new ObjectIdCollection();
		cDadosAccess.carregaDadosDWG();
		rKyRUt6AsR();
		if (uqkXdUUkXi.Count == 0)
		{
			return;
		}
		lN5X39yAhc = new DeclaracoesFiacao.structureAplicacao[1];
		DicionarioAplicacao.LeOsTiposDeAplicacoes(ref lN5X39yAhc);
		checked
		{
			if (rbCompleto.Checked)
			{
				z6nXKJP5yL = new DeclaracoesClonar.structurePlaquetasClonar[1];
				lIcXeiJewq = new DeclaracoesClonar.structureLayoutRapidoClonar[1];
				vEmX2P2NjP = new DeclaracoesClonar.structureLayoutRapidoClonar[1];
				int num2 = Information.UBound(QNDXwHNs9Y);
				for (int i = 1; i <= num2; i++)
				{
					string text = QNDXwHNs9Y[i].iPainelOrigem.ToString();
					Declaracoes2.StructurePlaquetas[] mPlaquetas = new Declaracoes2.StructurePlaquetas[1];
					if (DicionarioPlaqueta.LeDicPlaquetas(text, ref mPlaquetas))
					{
						ref DeclaracoesClonar.structurePlaquetasClonar[] reference = ref z6nXKJP5yL;
						reference = (DeclaracoesClonar.structurePlaquetasClonar[])Utils.CopyArray(reference, new DeclaracoesClonar.structurePlaquetasClonar[Information.UBound(z6nXKJP5yL) + 1 + 1]);
						z6nXKJP5yL[Information.UBound(z6nXKJP5yL)].pnOrig = text;
						z6nXKJP5yL[Information.UBound(z6nXKJP5yL)].pnDest = Conversions.ToString(0);
						z6nXKJP5yL[Information.UBound(z6nXKJP5yL)].mPlaquetas = mPlaquetas;
					}
					DeclaracoesEntidades.StructureLayout[] mTags = new DeclaracoesEntidades.StructureLayout[1];
					if (DicionarioLayout.LeDicLayout("P" + text, ref mTags))
					{
						ref DeclaracoesClonar.structureLayoutRapidoClonar[] reference2 = ref lIcXeiJewq;
						reference2 = (DeclaracoesClonar.structureLayoutRapidoClonar[])Utils.CopyArray(reference2, new DeclaracoesClonar.structureLayoutRapidoClonar[Information.UBound(lIcXeiJewq) + 1 + 1]);
						lIcXeiJewq[Information.UBound(lIcXeiJewq)].pnOrig = text;
						lIcXeiJewq[Information.UBound(lIcXeiJewq)].pnDest = Conversions.ToString(0);
						lIcXeiJewq[Information.UBound(lIcXeiJewq)].mLayout = mTags;
					}
					DeclaracoesEntidades.StructureLayout[] mTags2 = new DeclaracoesEntidades.StructureLayout[1];
					if (DicionarioLayout.LeDicLayout("C" + text, ref mTags2))
					{
						ref DeclaracoesClonar.structureLayoutRapidoClonar[] reference3 = ref vEmX2P2NjP;
						reference3 = (DeclaracoesClonar.structureLayoutRapidoClonar[])Utils.CopyArray(reference3, new DeclaracoesClonar.structureLayoutRapidoClonar[Information.UBound(vEmX2P2NjP) + 1 + 1]);
						vEmX2P2NjP[Information.UBound(vEmX2P2NjP)].pnOrig = text;
						vEmX2P2NjP[Information.UBound(vEmX2P2NjP)].pnDest = Conversions.ToString(0);
						vEmX2P2NjP[Information.UBound(vEmX2P2NjP)].mLayout = mTags2;
					}
				}
			}
			lgymZk9mmQ = Application.DocumentManager.MdiActiveDocument;
			EGXXWXINHr = DeclaracoesGeral.arqAtivo.Indice;
			MXYmrCUv06 = DeclaracoesGeral.Conf.DirProjeto;
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
				if (rhWmuCoU2N.Count != 0)
				{
					int painel = default;
					foreach (object item in rhWmuCoU2N)
					{
						ObjectId val3 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						Entity val4 = (Entity)val3.GetObject((OpenMode)0);
						try
						{
							int num3 = 0;
							BlockReference val5 = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
							try
							{
								if (val5 != null)
								{
									Entity ent = (Entity)(object)val5;
									string tipoImportado = "";
									string text2 = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
									string left = text2;
									BlockReference blockRef;
									if (Operators.CompareString(left, "P", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left, "M", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left, "B", TextCompare: true) == 0)
											{
												blockRef = val5;
												object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
												DeclaracoesEntidades.StructureBorne structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
												structureBorne.indexPainel = GfIR36NFkP(structureBorne.IndiceRegua);
												if (uqkXdUUkXi.Contains(structureBorne.indexPainel))
												{
													num3 = Information.UBound(KEBXhQDjyG) + 1;
													ref DeclaracoesClonar.structureDispOrigem[] kEBXhQDjyG = ref KEBXhQDjyG;
													kEBXhQDjyG = (DeclaracoesClonar.structureDispOrigem[])Utils.CopyArray(kEBXhQDjyG, new DeclaracoesClonar.structureDispOrigem[num3 + 1]);
													KEBXhQDjyG[num3].tipo = text2;
													KEBXhQDjyG[num3].ID = ((object)((DBObject)val5).ObjectId/*cast due to constrained. prefix*/).ToString();
													KEBXhQDjyG[num3].handleOrig = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
													KEBXhQDjyG[num3].Nome1 = structureBorne.Numero + structureBorne.NumeroComplem;
													KEBXhQDjyG[num3].Nome2 = "";
													KEBXhQDjyG[num3].Alternativo = "";
													KEBXhQDjyG[num3].Painel = structureBorne.indexPainel;
													KEBXhQDjyG[num3].Pagina = ((Entity)val5).Layer.ToString();
													KEBXhQDjyG[num3].IndexModelo = structureBorne.IndiceRegua;
													KEBXhQDjyG[num3].Material1 = structureBorne.lm;
													KEBXhQDjyG[num3].Material2 = 0;
													if (!iY5XoVQRVT.Contains(((Entity)val5).Layer.ToString()))
													{
														iY5XoVQRVT.Add(((Entity)val5).Layer.ToString());
													}
													if (!Y4AXkdy2Vo.Contains(structureBorne.IndiceRegua))
													{
														Y4AXkdy2Vo.Add(structureBorne.IndiceRegua);
													}
													if (structureBorne.lm > 0 && !oRMXfpYJmN.Contains(structureBorne.lm))
													{
														oRMXfpYJmN.Add(structureBorne.lm);
													}
													x1rmEXKB4D.Add(val3);
													num++;
												}
											}
										}
										else
										{
											blockRef = val5;
											object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
											DeclaracoesEntidades.StructureMascara structureMascara = ((obj2 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj2));
											if (!structureMascara.Complementar && uqkXdUUkXi.Contains(structureMascara.Painel))
											{
												num3 = Information.UBound(KEBXhQDjyG) + 1;
												ref DeclaracoesClonar.structureDispOrigem[] kEBXhQDjyG2 = ref KEBXhQDjyG;
												kEBXhQDjyG2 = (DeclaracoesClonar.structureDispOrigem[])Utils.CopyArray(kEBXhQDjyG2, new DeclaracoesClonar.structureDispOrigem[num3 + 1]);
												KEBXhQDjyG[num3].tipo = text2;
												KEBXhQDjyG[num3].ID = ((object)((DBObject)val5).ObjectId/*cast due to constrained. prefix*/).ToString();
												KEBXhQDjyG[num3].handleOrig = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
												KEBXhQDjyG[num3].Nome1 = structureMascara.Nome1;
												KEBXhQDjyG[num3].Nome2 = structureMascara.Nome2;
												KEBXhQDjyG[num3].Alternativo = structureMascara.Alternativo;
												KEBXhQDjyG[num3].Painel = structureMascara.Painel;
												KEBXhQDjyG[num3].Pagina = ((Entity)val5).Layer.ToString();
												KEBXhQDjyG[num3].IndexModelo = structureMascara.indexModelo;
												KEBXhQDjyG[num3].Material1 = structureMascara.iLM1;
												KEBXhQDjyG[num3].Material2 = structureMascara.iLM2;
												eP1XDkAEjL.Add(((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString());
												if (!iY5XoVQRVT.Contains(((Entity)val5).Layer.ToString()))
												{
													iY5XoVQRVT.Add(((Entity)val5).Layer.ToString());
												}
												if (structureMascara.indexModelo > 0 && !enJXHpMK9n.Contains(structureMascara.indexModelo))
												{
													enJXHpMK9n.Add(structureMascara.indexModelo);
												}
												if (structureMascara.iLM1 > 0 && !oRMXfpYJmN.Contains(structureMascara.iLM1))
												{
													oRMXfpYJmN.Add(structureMascara.iLM1);
												}
												if (structureMascara.iLM2 > 0 && !oRMXfpYJmN.Contains(structureMascara.iLM2))
												{
													oRMXfpYJmN.Add(structureMascara.iLM2);
												}
												x1rmEXKB4D.Add(val3);
												num++;
											}
										}
									}
									else
									{
										blockRef = val5;
										object obj3 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
										DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj3 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj3));
										if (uqkXdUUkXi.Contains(structureDispositivo.Painel))
										{
											num3 = Information.UBound(KEBXhQDjyG) + 1;
											ref DeclaracoesClonar.structureDispOrigem[] kEBXhQDjyG3 = ref KEBXhQDjyG;
											kEBXhQDjyG3 = (DeclaracoesClonar.structureDispOrigem[])Utils.CopyArray(kEBXhQDjyG3, new DeclaracoesClonar.structureDispOrigem[num3 + 1]);
											if (structureDispositivo.Complementar)
											{
												KEBXhQDjyG[num3].tipo = "PC";
											}
											else
											{
												KEBXhQDjyG[num3].tipo = "P";
											}
											KEBXhQDjyG[num3].ID = ((object)((DBObject)val5).ObjectId/*cast due to constrained. prefix*/).ToString();
											KEBXhQDjyG[num3].handleOrig = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
											KEBXhQDjyG[num3].Nome1 = structureDispositivo.Nome1;
											KEBXhQDjyG[num3].Nome2 = structureDispositivo.Nome2;
											KEBXhQDjyG[num3].Alternativo = structureDispositivo.Alternativo;
											KEBXhQDjyG[num3].Painel = structureDispositivo.Painel;
											KEBXhQDjyG[num3].Pagina = ((Entity)val5).Layer.ToString();
											KEBXhQDjyG[num3].IndexModelo = structureDispositivo.indexModelo;
											KEBXhQDjyG[num3].Material1 = structureDispositivo.iLM1;
											KEBXhQDjyG[num3].Material2 = structureDispositivo.iLM2;
											eP1XDkAEjL.Add(((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString());
											if (!iY5XoVQRVT.Contains(((Entity)val5).Layer.ToString()))
											{
												iY5XoVQRVT.Add(((Entity)val5).Layer.ToString());
											}
											if (structureDispositivo.indexModelo > 0 && !HKpXGYd0X0.Contains(structureDispositivo.indexModelo))
											{
												HKpXGYd0X0.Add(structureDispositivo.indexModelo);
											}
											if (structureDispositivo.iLM1 > 0 && !oRMXfpYJmN.Contains(structureDispositivo.iLM1))
											{
												oRMXfpYJmN.Add(structureDispositivo.iLM1);
											}
											if (structureDispositivo.iLM2 > 0 && !oRMXfpYJmN.Contains(structureDispositivo.iLM2))
											{
												oRMXfpYJmN.Add(structureDispositivo.iLM2);
											}
											x1rmEXKB4D.Add(val3);
											num++;
										}
									}
									DeclaracoesTopografico.structureDispTopografico dTpg = default;
									blockRef = val5;
									if (XDataTopografico.lerXDataDispTopografico(ref blockRef, ref dTpg) && uqkXdUUkXi.Contains(dTpg.painel))
									{
										num3 = Information.UBound(KEBXhQDjyG) + 1;
										ref DeclaracoesClonar.structureDispOrigem[] kEBXhQDjyG4 = ref KEBXhQDjyG;
										kEBXhQDjyG4 = (DeclaracoesClonar.structureDispOrigem[])Utils.CopyArray(kEBXhQDjyG4, new DeclaracoesClonar.structureDispOrigem[num3 + 1]);
										KEBXhQDjyG[num3].tipo = "TPGD";
										KEBXhQDjyG[num3].ID = ((object)((DBObject)val5).ObjectId/*cast due to constrained. prefix*/).ToString();
										KEBXhQDjyG[num3].handleOrig = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
										KEBXhQDjyG[num3].Nome1 = dTpg.tag;
										KEBXhQDjyG[num3].Nome2 = "";
										KEBXhQDjyG[num3].Alternativo = dTpg.alternativo;
										KEBXhQDjyG[num3].Painel = dTpg.painel;
										KEBXhQDjyG[num3].Pagina = ((Entity)val5).Layer.ToString();
										KEBXhQDjyG[num3].IndexModelo = 0;
										KEBXhQDjyG[num3].Material1 = 0;
										KEBXhQDjyG[num3].Material2 = 0;
										if (!iY5XoVQRVT.Contains(((Entity)val5).Layer.ToString()))
										{
											iY5XoVQRVT.Add(((Entity)val5).Layer.ToString());
										}
										x1rmEXKB4D.Add(val3);
										num++;
									}
									string tag = "";
									string alternativo = "";
									blockRef = val5;
									tipoImportado = "";
									if (XDataLayout.lerXDataDispLayout(ref blockRef, ref painel, ref tag, ref alternativo, ref tipoImportado) && uqkXdUUkXi.Contains(painel))
									{
										num3 = Information.UBound(KEBXhQDjyG) + 1;
										ref DeclaracoesClonar.structureDispOrigem[] kEBXhQDjyG5 = ref KEBXhQDjyG;
										kEBXhQDjyG5 = (DeclaracoesClonar.structureDispOrigem[])Utils.CopyArray(kEBXhQDjyG5, new DeclaracoesClonar.structureDispOrigem[num3 + 1]);
										KEBXhQDjyG[num3].tipo = "LAYD";
										KEBXhQDjyG[num3].ID = ((object)((DBObject)val5).ObjectId/*cast due to constrained. prefix*/).ToString();
										KEBXhQDjyG[num3].handleOrig = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
										KEBXhQDjyG[num3].Nome1 = tag;
										KEBXhQDjyG[num3].Nome2 = "";
										KEBXhQDjyG[num3].Alternativo = alternativo;
										KEBXhQDjyG[num3].Painel = painel;
										KEBXhQDjyG[num3].Pagina = ((Entity)val5).Layer.ToString();
										KEBXhQDjyG[num3].IndexModelo = 0;
										KEBXhQDjyG[num3].Material1 = 0;
										KEBXhQDjyG[num3].Material2 = 0;
										if (!iY5XoVQRVT.Contains(((Entity)val5).Layer.ToString()))
										{
											iY5XoVQRVT.Add(((Entity)val5).Layer.ToString());
										}
										x1rmEXKB4D.Add(val3);
										num++;
									}
								}
								Polyline pl = (Polyline)(object)((val4 is Polyline) ? val4 : null);
								DeclaracoesEntidades.StructureConexao conex = default;
								if (pl == null)
								{
									continue;
								}
								if (XDataConexao.lerXDataConexao(ref pl, ref conex) && uqkXdUUkXi.Contains(conex.Painel))
								{
									Fa9XvTMgF7.Add(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
									if (conex.Tipo == 3)
									{
										array = (string[,])Utils.CopyArray(array, new string[3, Information.UBound(array, 2) + 1 + 1]);
										array[0, Information.UBound(array, 2)] = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
										array[1, Information.UBound(array, 2)] = conex.Handle;
										array[2, Information.UBound(array, 2)] = Conversions.ToString(1);
									}
								}
								DeclaracoesEntidades.StructureInterligacao ilig = default;
								if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) && (((ilig.Tipo == 1) & uqkXdUUkXi.Contains(ilig.Painel1) & uqkXdUUkXi.Contains(ilig.Painel2)) | ((ilig.Tipo == 2) & ((uqkXdUUkXi.Contains(ilig.Painel1) & (ilig.Painel2 == 0)) | (uqkXdUUkXi.Contains(ilig.Painel2) & (ilig.Painel1 == 0)))) | ((ilig.Tipo == 3) & uqkXdUUkXi.Contains(ilig.Painel2) & (ilig.Painel1 == 0))))
								{
									num3 = Information.UBound(KEBXhQDjyG) + 1;
									ref DeclaracoesClonar.structureDispOrigem[] kEBXhQDjyG6 = ref KEBXhQDjyG;
									kEBXhQDjyG6 = (DeclaracoesClonar.structureDispOrigem[])Utils.CopyArray(kEBXhQDjyG6, new DeclaracoesClonar.structureDispOrigem[num3 + 1]);
									KEBXhQDjyG[num3].tipo = "I";
									KEBXhQDjyG[num3].ID = ((object)((DBObject)pl).ObjectId/*cast due to constrained. prefix*/).ToString();
									KEBXhQDjyG[num3].handleOrig = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
									KEBXhQDjyG[num3].Nome1 = "";
									KEBXhQDjyG[num3].Nome2 = "";
									KEBXhQDjyG[num3].Alternativo = "";
									KEBXhQDjyG[num3].Painel = 0;
									KEBXhQDjyG[num3].Pagina = ((Entity)pl).Layer.ToString();
									KEBXhQDjyG[num3].IndexModelo = 0;
									KEBXhQDjyG[num3].Material1 = 0;
									KEBXhQDjyG[num3].Material2 = 0;
									if (!iY5XoVQRVT.Contains(((Entity)pl).Layer.ToString()))
									{
										iY5XoVQRVT.Add(((Entity)pl).Layer.ToString());
									}
									if (!oTwXtv1S5m.Contains(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString()))
									{
										oTwXtv1S5m.Add(((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString());
									}
									x1rmEXKB4D.Add(val3);
									num++;
								}
							}
							finally
							{
								((IDisposable)val5)?.Dispose();
							}
						}
						finally
						{
							((IDisposable)val4)?.Dispose();
						}
					}
					bool flag;
					do
					{
						flag = false;
						int num4 = Information.UBound(array, 2);
						for (int j = 1; j <= num4; j++)
						{
							if (Conversions.ToDouble(array[2, j]) == 1.0 && !Fa9XvTMgF7.Contains(array[1, j]))
							{
								Fa9XvTMgF7.Remove(array[0, j]);
								array[2, j] = Conversions.ToString(0);
								flag = true;
							}
						}
					}
					while (flag);
					short tipo = default;
					foreach (object item2 in rhWmuCoU2N)
					{
						ObjectId val6 = ((item2 == null) ? default(ObjectId) : ((ObjectId)item2));
						Entity val7 = (Entity)val6.GetObject((OpenMode)0);
						try
						{
							int num5 = 0;
							BlockReference val8 = (BlockReference)(object)((val7 is BlockReference) ? val7 : null);
							try
							{
								if (val8 != null)
								{
									Entity ent = (Entity)(object)val8;
									string tipoImportado = "";
									string text3 = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
									string left2 = text3;
									if (Operators.CompareString(left2, "M", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left2, "A", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left2, "E", TextCompare: true) == 0)
											{
												BlockReference blockRef = val8;
												object obj4 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
												DeclaracoesEntidades.StructurePortas structurePortas = ((obj4 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj4));
												if (eP1XDkAEjL.Contains(structurePortas.HandleDaMascara))
												{
													num5 = Information.UBound(KEBXhQDjyG) + 1;
													ref DeclaracoesClonar.structureDispOrigem[] kEBXhQDjyG7 = ref KEBXhQDjyG;
													kEBXhQDjyG7 = (DeclaracoesClonar.structureDispOrigem[])Utils.CopyArray(kEBXhQDjyG7, new DeclaracoesClonar.structureDispOrigem[num5 + 1]);
													KEBXhQDjyG[num5].tipo = text3;
													KEBXhQDjyG[num5].ID = ((object)((DBObject)val8).ObjectId/*cast due to constrained. prefix*/).ToString();
													KEBXhQDjyG[num5].handleOrig = ((object)((DBObject)val8).Handle/*cast due to constrained. prefix*/).ToString();
													KEBXhQDjyG[num5].Nome1 = structurePortas.Nome1;
													KEBXhQDjyG[num5].Nome2 = structurePortas.Nome2;
													KEBXhQDjyG[num5].Alternativo = structurePortas.Alternativo;
													KEBXhQDjyG[num5].Painel = DpwR7qNCGt(structurePortas.HandleDaMascara);
													KEBXhQDjyG[num5].Pagina = ((Entity)val8).Layer.ToString();
													KEBXhQDjyG[num5].IndexModelo = structurePortas.indiceDoModelo;
													KEBXhQDjyG[num5].Material1 = -1;
													KEBXhQDjyG[num5].Material2 = -1;
													if (!iY5XoVQRVT.Contains(((Entity)val8).Layer.ToString()))
													{
														iY5XoVQRVT.Add(((Entity)val8).Layer.ToString());
													}
													x1rmEXKB4D.Add(val6);
													num++;
												}
											}
										}
										else
										{
											BlockReference blockRef = val8;
											object obj5 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
											DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = ((obj5 == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj5));
											if (eP1XDkAEjL.Contains(structureAuxiliar.HandleBob))
											{
												num5 = Information.UBound(KEBXhQDjyG) + 1;
												ref DeclaracoesClonar.structureDispOrigem[] kEBXhQDjyG8 = ref KEBXhQDjyG;
												kEBXhQDjyG8 = (DeclaracoesClonar.structureDispOrigem[])Utils.CopyArray(kEBXhQDjyG8, new DeclaracoesClonar.structureDispOrigem[num5 + 1]);
												KEBXhQDjyG[num5].tipo = text3;
												KEBXhQDjyG[num5].ID = ((object)((DBObject)val8).ObjectId/*cast due to constrained. prefix*/).ToString();
												KEBXhQDjyG[num5].handleOrig = ((object)((DBObject)val8).Handle/*cast due to constrained. prefix*/).ToString();
												KEBXhQDjyG[num5].Nome1 = structureAuxiliar.Nome1;
												KEBXhQDjyG[num5].Nome2 = structureAuxiliar.Nome2;
												KEBXhQDjyG[num5].Alternativo = structureAuxiliar.Alternativo;
												KEBXhQDjyG[num5].Painel = DpwR7qNCGt(structureAuxiliar.HandleBob);
												KEBXhQDjyG[num5].Pagina = ((Entity)val8).Layer.ToString();
												KEBXhQDjyG[num5].IndexModelo = structureAuxiliar.IndexModelo;
												KEBXhQDjyG[num5].Material1 = -1;
												KEBXhQDjyG[num5].Material2 = -1;
												if (!iY5XoVQRVT.Contains(((Entity)val8).Layer.ToString()))
												{
													iY5XoVQRVT.Add(((Entity)val8).Layer.ToString());
												}
												x1rmEXKB4D.Add(val6);
												num++;
											}
										}
									}
									else
									{
										BlockReference blockRef = val8;
										object obj6 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
										DeclaracoesEntidades.StructureMascara structureMascara2 = ((obj6 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj6));
										if (structureMascara2.Complementar && eP1XDkAEjL.Contains(structureMascara2.HandleMascPrincipal))
										{
											num5 = Information.UBound(KEBXhQDjyG) + 1;
											ref DeclaracoesClonar.structureDispOrigem[] kEBXhQDjyG9 = ref KEBXhQDjyG;
											kEBXhQDjyG9 = (DeclaracoesClonar.structureDispOrigem[])Utils.CopyArray(kEBXhQDjyG9, new DeclaracoesClonar.structureDispOrigem[num5 + 1]);
											KEBXhQDjyG[num5].tipo = "MC";
											KEBXhQDjyG[num5].ID = ((object)((DBObject)val8).ObjectId/*cast due to constrained. prefix*/).ToString();
											KEBXhQDjyG[num5].handleOrig = ((object)((DBObject)val8).Handle/*cast due to constrained. prefix*/).ToString();
											KEBXhQDjyG[num5].Nome1 = structureMascara2.Nome1;
											KEBXhQDjyG[num5].Nome2 = structureMascara2.Nome2;
											KEBXhQDjyG[num5].Alternativo = structureMascara2.Alternativo;
											KEBXhQDjyG[num5].Painel = structureMascara2.Painel;
											KEBXhQDjyG[num5].Pagina = ((Entity)val8).Layer.ToString();
											KEBXhQDjyG[num5].IndexModelo = structureMascara2.indexModelo;
											KEBXhQDjyG[num5].Material1 = structureMascara2.iLM1;
											KEBXhQDjyG[num5].Material2 = structureMascara2.iLM2;
											if (!iY5XoVQRVT.Contains(((Entity)val8).Layer.ToString()))
											{
												iY5XoVQRVT.Add(((Entity)val8).Layer.ToString());
											}
											x1rmEXKB4D.Add(val6);
											num++;
										}
									}
								}
								DBText val9 = (DBText)(object)((val7 is DBText) ? val7 : null);
								if (val9 != null)
								{
									DeclaracoesEntidades.StructureDefinicaoPortas Def = default;
									Entity ent = (Entity)(object)val9;
									bool flag2 = XDataDispositivosMaster.LerXDataDefinicao(ref ent, ref Def);
									val9 = (DBText)ent;
									if (flag2 && eP1XDkAEjL.Contains(Def.HandleDaMascara))
									{
										num5 = Information.UBound(KEBXhQDjyG) + 1;
										ref DeclaracoesClonar.structureDispOrigem[] kEBXhQDjyG10 = ref KEBXhQDjyG;
										kEBXhQDjyG10 = (DeclaracoesClonar.structureDispOrigem[])Utils.CopyArray(kEBXhQDjyG10, new DeclaracoesClonar.structureDispOrigem[num5 + 1]);
										KEBXhQDjyG[num5].tipo = "DEF";
										KEBXhQDjyG[num5].ID = ((object)((DBObject)val9).ObjectId/*cast due to constrained. prefix*/).ToString();
										KEBXhQDjyG[num5].handleOrig = ((object)((DBObject)val9).Handle/*cast due to constrained. prefix*/).ToString();
										KEBXhQDjyG[num5].Nome1 = "";
										KEBXhQDjyG[num5].Nome2 = "";
										KEBXhQDjyG[num5].Alternativo = "";
										KEBXhQDjyG[num5].Painel = -1;
										KEBXhQDjyG[num5].Pagina = ((Entity)val9).Layer.ToString();
										KEBXhQDjyG[num5].IndexModelo = -1;
										KEBXhQDjyG[num5].Material1 = -1;
										KEBXhQDjyG[num5].Material2 = -1;
										if (!iY5XoVQRVT.Contains(((Entity)val9).Layer.ToString()))
										{
											iY5XoVQRVT.Add(((Entity)val9).Layer.ToString());
										}
										x1rmEXKB4D.Add(val6);
										num++;
									}
									string handle = "";
									string THandle = "";
									ent = (Entity)(object)val9;
									string tipoImportado = "";
									flag2 = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle, ref tipo, ref THandle, ref tipoImportado);
									val9 = (DBText)ent;
									if (flag2 && oTwXtv1S5m.Contains(handle))
									{
										num5 = Information.UBound(KEBXhQDjyG) + 1;
										ref DeclaracoesClonar.structureDispOrigem[] kEBXhQDjyG11 = ref KEBXhQDjyG;
										kEBXhQDjyG11 = (DeclaracoesClonar.structureDispOrigem[])Utils.CopyArray(kEBXhQDjyG11, new DeclaracoesClonar.structureDispOrigem[num5 + 1]);
										KEBXhQDjyG[num5].tipo = "TI";
										KEBXhQDjyG[num5].ID = ((object)((DBObject)val9).ObjectId/*cast due to constrained. prefix*/).ToString();
										KEBXhQDjyG[num5].handleOrig = ((object)((DBObject)val9).Handle/*cast due to constrained. prefix*/).ToString();
										KEBXhQDjyG[num5].Nome1 = "";
										KEBXhQDjyG[num5].Nome2 = "";
										KEBXhQDjyG[num5].Alternativo = "";
										KEBXhQDjyG[num5].Painel = -1;
										KEBXhQDjyG[num5].Pagina = ((Entity)val9).Layer.ToString();
										KEBXhQDjyG[num5].IndexModelo = -1;
										KEBXhQDjyG[num5].Material1 = -1;
										KEBXhQDjyG[num5].Material2 = -1;
										x1rmEXKB4D.Add(val6);
										num++;
									}
								}
								Polyline pl2 = (Polyline)(object)((val7 is Polyline) ? val7 : null);
								DeclaracoesEntidades.StructureConexao conex2 = default;
								if (pl2 != null && XDataConexao.lerXDataConexao(ref pl2, ref conex2) && uqkXdUUkXi.Contains(conex2.Painel) && ((conex2.Tipo == 1) | (conex2.Tipo == 2) | (conex2.Tipo == 4) | ((conex2.Tipo == 3) & (Operators.CompareString(conex2.Handle.Trim(), "", TextCompare: true) != 0) & Fa9XvTMgF7.Contains(conex2.Handle))))
								{
									num5 = Information.UBound(KEBXhQDjyG) + 1;
									ref DeclaracoesClonar.structureDispOrigem[] kEBXhQDjyG12 = ref KEBXhQDjyG;
									kEBXhQDjyG12 = (DeclaracoesClonar.structureDispOrigem[])Utils.CopyArray(kEBXhQDjyG12, new DeclaracoesClonar.structureDispOrigem[num5 + 1]);
									KEBXhQDjyG[num5].tipo = "C";
									KEBXhQDjyG[num5].ID = ((object)((DBObject)pl2).ObjectId/*cast due to constrained. prefix*/).ToString();
									KEBXhQDjyG[num5].handleOrig = ((object)((DBObject)pl2).Handle/*cast due to constrained. prefix*/).ToString();
									KEBXhQDjyG[num5].Nome1 = "";
									KEBXhQDjyG[num5].Nome2 = "";
									KEBXhQDjyG[num5].Alternativo = "";
									KEBXhQDjyG[num5].Painel = conex2.Painel;
									KEBXhQDjyG[num5].Pagina = ((Entity)pl2).Layer.ToString();
									KEBXhQDjyG[num5].IndexModelo = 0;
									KEBXhQDjyG[num5].Material1 = 0;
									KEBXhQDjyG[num5].Material2 = 0;
									if (!iY5XoVQRVT.Contains(((Entity)pl2).Layer.ToString()))
									{
										iY5XoVQRVT.Add(((Entity)pl2).Layer.ToString());
									}
									if (!itAX6nfgHK.Contains(conex2.Potencial))
									{
										itAX6nfgHK.Add(conex2.Potencial);
									}
									x1rmEXKB4D.Add(val6);
									num++;
								}
							}
							finally
							{
								((IDisposable)val8)?.Dispose();
							}
						}
						finally
						{
							((IDisposable)val7)?.Dispose();
						}
					}
					short num7 = default;
					int num8 = default;
					int potencial = default;
					short tipo3 = default;
					foreach (object item3 in rhWmuCoU2N)
					{
						ObjectId val10 = ((item3 == null) ? default(ObjectId) : ((ObjectId)item3));
						Entity val11 = (Entity)val10.GetObject((OpenMode)0);
						try
						{
							int num6 = 0;
							BlockReference val12 = (BlockReference)(object)((val11 is BlockReference) ? val11 : null);
							try
							{
								if (val12 != null)
								{
									Declaracoes2.StructureModelo Modelo = default;
									Entity ent = val11;
									if (XDataDispositivosMaster.LerXDataModelo(ref ent, ref Modelo) && eP1XDkAEjL.Contains(Modelo.HandleBob))
									{
										num6 = Information.UBound(KEBXhQDjyG) + 1;
										ref DeclaracoesClonar.structureDispOrigem[] kEBXhQDjyG13 = ref KEBXhQDjyG;
										kEBXhQDjyG13 = (DeclaracoesClonar.structureDispOrigem[])Utils.CopyArray(kEBXhQDjyG13, new DeclaracoesClonar.structureDispOrigem[num6 + 1]);
										KEBXhQDjyG[num6].tipo = "MODELO";
										KEBXhQDjyG[num6].ID = ((object)((DBObject)val12).ObjectId/*cast due to constrained. prefix*/).ToString();
										KEBXhQDjyG[num6].handleOrig = ((object)((DBObject)val12).Handle/*cast due to constrained. prefix*/).ToString();
										KEBXhQDjyG[num6].Nome1 = "";
										KEBXhQDjyG[num6].Nome2 = "";
										KEBXhQDjyG[num6].Alternativo = "";
										KEBXhQDjyG[num6].Painel = -1;
										KEBXhQDjyG[num6].Pagina = ((Entity)val12).Layer.ToString();
										KEBXhQDjyG[num6].IndexModelo = -1;
										KEBXhQDjyG[num6].Material1 = -1;
										KEBXhQDjyG[num6].Material2 = -1;
										if (!iY5XoVQRVT.Contains(((Entity)val12).Layer.ToString()))
										{
											iY5XoVQRVT.Add(((Entity)val12).Layer.ToString());
										}
										x1rmEXKB4D.Add(val10);
										num++;
									}
								}
								DBText val13 = (DBText)(object)((val11 is DBText) ? val11 : null);
								if (val13 != null)
								{
									string handle2 = "";
									int enderecamento = num7;
									short tipo2 = (short)num8;
									bool flag2 = XDataConexao.lerXDataAuxCircuito(ref val13, ref potencial, ref handle2, ref enderecamento, ref tipo2);
									num8 = tipo2;
									num7 = (short)enderecamento;
									if (flag2 && itAX6nfgHK.Contains(potencial) && ((num8 == 1) | (num8 == 2) | (num8 == 3)))
									{
										if (!iY5XoVQRVT.Contains(((Entity)val13).Layer.ToString()))
										{
											iY5XoVQRVT.Add(((Entity)val13).Layer.ToString());
										}
										x1rmEXKB4D.Add(val10);
										num++;
									}
									string handle3 = "";
									if (XDataDispositivo.lerXDataDePara(ref val13, ref handle3, ref tipo3) && iY5XoVQRVT.Contains(((Entity)val13).Layer.ToString()))
									{
										num6 = Information.UBound(KEBXhQDjyG) + 1;
										ref DeclaracoesClonar.structureDispOrigem[] kEBXhQDjyG14 = ref KEBXhQDjyG;
										kEBXhQDjyG14 = (DeclaracoesClonar.structureDispOrigem[])Utils.CopyArray(kEBXhQDjyG14, new DeclaracoesClonar.structureDispOrigem[num6 + 1]);
										KEBXhQDjyG[num6].tipo = "DP";
										KEBXhQDjyG[num6].ID = ((object)((DBObject)val13).ObjectId/*cast due to constrained. prefix*/).ToString();
										KEBXhQDjyG[num6].handleOrig = ((object)((DBObject)val13).Handle/*cast due to constrained. prefix*/).ToString();
										KEBXhQDjyG[num6].Nome1 = "";
										KEBXhQDjyG[num6].Nome2 = "";
										KEBXhQDjyG[num6].Alternativo = "";
										KEBXhQDjyG[num6].Painel = 0;
										KEBXhQDjyG[num6].Pagina = ((Entity)val13).Layer.ToString();
										KEBXhQDjyG[num6].IndexModelo = 0;
										KEBXhQDjyG[num6].Material1 = 0;
										KEBXhQDjyG[num6].Material2 = 0;
										x1rmEXKB4D.Add(val10);
										num++;
									}
								}
								Polyline val14 = (Polyline)(object)((val11 is Polyline) ? val11 : null);
								if (val14 != null && val11.Visible)
								{
									Entity ent = (Entity)(object)val14;
									bool flag2 = XDataDispositivosMaster.LerXDataAuxBornes(ref ent);
									val14 = (Polyline)ent;
									if (flag2 && iY5XoVQRVT.Contains(val11.Layer.ToString()))
									{
										x1rmEXKB4D.Add(val10);
										num++;
									}
								}
								if (cbIncluirAutocad.Checked && val11.Visible && ((DBObject)val11).XData == (ResultBuffer)null && iY5XoVQRVT.Contains(val11.Layer.ToString()))
								{
									x1rmEXKB4D.Add(val10);
									num++;
								}
							}
							finally
							{
								((IDisposable)val12)?.Dispose();
							}
						}
						finally
						{
							((IDisposable)val11)?.Dispose();
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				val.Abort();
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			zkoRDhXIlt();
			PointMonitorToolTips.StartMonitor();
			DeclaracoesGeral.bAnularEventos = false;
			if (num > 0)
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 888]), MsgBoxStyle.Exclamation);
				TabControl1.TabPages[1].Enabled = true;
			}
		}
	}

	private void zkoRDhXIlt()
	{
		nOcXMjbeZF = new DeclaracoesClonar.structureRelesAuxiliares[1];
		HKpXGYd0X0.Sort();
		checked
		{
			foreach (int item in HKpXGYd0X0)
			{
				int iIndiceSelecionado = item;
				Declaracoes2.MModelosDeContatos mModelo = default;
				if (DicionarioContatos.LeUmModeloDeDeDicionarioContatos(iIndiceSelecionado, ref mModelo))
				{
					ref DeclaracoesClonar.structureRelesAuxiliares[] reference = ref nOcXMjbeZF;
					reference = (DeclaracoesClonar.structureRelesAuxiliares[])Utils.CopyArray(reference, new DeclaracoesClonar.structureRelesAuxiliares[Information.UBound(nOcXMjbeZF) + 1 + 1]);
					nOcXMjbeZF[Information.UBound(nOcXMjbeZF)].modelo = mModelo;
					Declaracoes2.StructureContatosAuxiliares[] mCONTATOS = null;
					DicionarioContatos.LeOsContatosAuxiliarDoModeloDoDicionario(ref iIndiceSelecionado, ref mCONTATOS);
					nOcXMjbeZF[Information.UBound(nOcXMjbeZF)].mContatos = mCONTATOS;
					if (mModelo.iLM1 > 0 && !oRMXfpYJmN.Contains(mModelo.iLM1))
					{
						oRMXfpYJmN.Add(mModelo.iLM1);
					}
					if (mModelo.iLM2 > 0 && !oRMXfpYJmN.Contains(mModelo.iLM2))
					{
						oRMXfpYJmN.Add(mModelo.iLM2);
					}
				}
			}
			qSeXIdqIZU = new DeclaracoesClonar.structureMascaras[1];
			enJXHpMK9n.Sort();
			foreach (int item2 in enJXHpMK9n)
			{
				int iIndiceSelecionado2 = item2;
				Declaracoes2.MModeloDeMascara mModelo2 = default;
				if (DicionarioMascaras.LeUmModeloDeDicionarioMascara(iIndiceSelecionado2, ref mModelo2))
				{
					ref DeclaracoesClonar.structureMascaras[] reference2 = ref qSeXIdqIZU;
					reference2 = (DeclaracoesClonar.structureMascaras[])Utils.CopyArray(reference2, new DeclaracoesClonar.structureMascaras[Information.UBound(qSeXIdqIZU) + 1 + 1]);
					qSeXIdqIZU[Information.UBound(qSeXIdqIZU)].modelo = mModelo2;
					Declaracoes2.MModeloDePortas[] mPortas = null;
					DicionarioMascaras.LeAsPortasDoModeloDoDicionario(ref iIndiceSelecionado2, "", ref mPortas);
					qSeXIdqIZU[Information.UBound(qSeXIdqIZU)].mPortas = mPortas;
					if (mModelo2.iLM1 > 0L && !oRMXfpYJmN.Contains((int)mModelo2.iLM1))
					{
						oRMXfpYJmN.Add((int)mModelo2.iLM1);
					}
					if (mModelo2.iLM2 > 0L && !oRMXfpYJmN.Contains((int)mModelo2.iLM2))
					{
						oRMXfpYJmN.Add((int)mModelo2.iLM2);
					}
				}
			}
			Jp8XFjY02v = new DeclaracoesClonar.structureMaterial[1];
			oRMXfpYJmN.Sort();
			cDadosAccessMateriais cDadosAccessMateriais2 = new cDadosAccessMateriais();
			foreach (int item3 in oRMXfpYJmN)
			{
				DeclaracoesClonar.structureMaterial mat = default;
				if (cDadosAccessMateriais2.carregaMaterial(item3, ref mat))
				{
					ref DeclaracoesClonar.structureMaterial[] jp8XFjY02v = ref Jp8XFjY02v;
					jp8XFjY02v = (DeclaracoesClonar.structureMaterial[])Utils.CopyArray(jp8XFjY02v, new DeclaracoesClonar.structureMaterial[Information.UBound(Jp8XFjY02v) + 1 + 1]);
					Jp8XFjY02v[Information.UBound(Jp8XFjY02v)] = mat;
				}
			}
			cDadosAccessMateriais2.fechaConexao();
		}
	}

	private void WSLRvdCOX2(object P_0, EventArgs P_1)
	{
		List<int> list = new List<int>();
		checked
		{
			int num = dgRelacaoPaineis.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgRelacaoPaineis.Rows[i].Selected)
				{
					dgRelacaoPaineis.Rows[i].Cells[2].Value = RuntimeHelpers.GetObjectValue(dgRelacaoPaineis.Rows[i].Cells[0].Value);
					dgRelacaoPaineis.Rows[i].Cells[3].Value = RuntimeHelpers.GetObjectValue(dgRelacaoPaineis.Rows[i].Cells[1].Value);
					list.Add(Conversions.ToInteger(dgRelacaoPaineis.Rows[i].Cells[0].Value));
				}
			}
			int num2 = dgPaineisDestino.Rows.Count - 1;
			for (int j = num2; j >= 0; j += -1)
			{
				if (list.Contains(Conversions.ToInteger(dgPaineisDestino.Rows[j].Cells[0].Value)))
				{
					dgPaineisDestino.Rows.RemoveAt(j);
				}
			}
		}
	}

	private void odRR6kJoMy(object P_0, EventArgs P_1)
	{
		int count = dgRelacaoPaginas.SelectedRows.Count;
		int count2 = dgPaginasDestino.SelectedRows.Count;
		if ((count == 0) | (count2 == 0))
		{
			return;
		}
		int num = -1;
		checked
		{
			int num2 = dgRelacaoPaginas.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (!dgRelacaoPaginas.Rows[i].Selected)
				{
					continue;
				}
				num++;
				int num3 = -1;
				int num4 = dgPaginasDestino.Rows.Count - 1;
				for (int j = 0; j <= num4; j++)
				{
					if (dgPaginasDestino.Rows[j].Selected)
					{
						num3++;
						if (num == num3)
						{
							string value = Conversions.ToString(dgPaginasDestino.Rows[j].Cells[0].Value);
							dgRelacaoPaginas.Rows[i].Cells[1].Value = value;
						}
					}
				}
			}
			verificaPaginaJaExiste();
		}
	}

	private void AcpRtoAPOE(object P_0, EventArgs P_1)
	{
		checked
		{
			int num = dgRelacaoPaginas.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgRelacaoPaginas.Rows[i].Selected)
				{
					string text = Pagina.montaNumeroPagina(Conversions.ToString(dgRelacaoPaginas.Rows[i].Cells[0].Value));
					string text2 = "";
					if (!Versioned.IsNumeric(text))
					{
						string value = text.Substring(0, text.Length - 1);
						text2 = Conversions.ToString(Conversions.ToInteger(value) + Conversions.ToInteger(tbIncremento.Text));
						text2 += text.Substring(text.Length - 1);
					}
					else
					{
						text2 = Conversions.ToString(Conversions.ToInteger(text) + Conversions.ToInteger(tbIncremento.Text));
					}
					dgRelacaoPaginas.Rows[i].Cells[1].Value = Pagina.montaNumeroPagina(text2);
				}
			}
			verificaPaginaJaExiste();
		}
	}

	private void dgERjd1tu8(object P_0, EventArgs P_1)
	{
		if (Operators.CompareString(tbPaginaInicial.Text.Trim(), "", TextCompare: true) == 0)
		{
			return;
		}
		int num = Conversions.ToInteger(tbPaginaInicial.Text);
		checked
		{
			int num2 = dgRelacaoPaginas.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (dgRelacaoPaginas.Rows[i].Selected)
				{
					dgRelacaoPaginas.Rows[i].Cells[1].Value = Pagina.montaNumeroPagina(num.ToString());
					num++;
				}
			}
			verificaPaginaJaExiste();
		}
	}

	private void oj4RLWqbrx(object P_0, EventArgs P_1)
	{
		checked
		{
			int num = dgRelacaoPaginas.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgRelacaoPaginas.Rows[i].Selected)
				{
					dgRelacaoPaginas.Rows[i].Cells[3].Value = tbDx.Text;
					dgRelacaoPaginas.Rows[i].Cells[4].Value = tbDy.Text;
				}
			}
		}
	}

	private void GxFRw9wU1T(object P_0, EventArgs P_1)
	{
		checked
		{
			try
			{
				btImportar.Enabled = false;
				DeclaracoesGeral.bSuspenderEventoExpImpClonar = true;
				CadastraPaineis();
				cDadosAccess.carregaPainelDicionario();
				cDadosAccess.carregaDadosDWG();
				rLUXpffcou = DeclaracoesGeral.arqAtivo.Indice;
				fNbmzAMGpH = DeclaracoesGeral.Conf.DirProjeto;
				if (Operators.CompareString(MXYmrCUv06, fNbmzAMGpH, TextCompare: true) != 0)
				{
					PASm9FIRAo = true;
					O68mYecYQ6 = true;
				}
				else
				{
					PASm9FIRAo = false;
					if (EGXXWXINHr != rLUXpffcou)
					{
						O68mYecYQ6 = true;
					}
					else
					{
						O68mYecYQ6 = false;
					}
				}
				DicionarioReguas.GravaOsModelosDeRegua(O4HX8q2Ye9);
				int num = Information.UBound(uBgXxRAlrb);
				for (int i = 1; i <= num; i++)
				{
					string text = Pagina.CriarLayer(uBgXxRAlrb[i].pagDestino, "", "");
					if ((Operators.CompareString(text, "-1", TextCompare: true) != 0) & (Operators.CompareString(text, "0", TextCompare: true) != 0))
					{
						Pagina.criaCamposFormato("-1", text);
					}
				}
				Pagina.CarregaPaginas();
				Pagina.OrdenaMatrizPaginas();
				Pagina.AtualizaContTotFl();
				DeclaracoesGeral._uscPagina.CarregaPG();
				if (O68mYecYQ6)
				{
					if (O68mYecYQ6)
					{
						if (Information.UBound(lN5X39yAhc) > 0)
						{
							DeclaracoesFiacao.structureAplicacao[] mAplicacao = new DeclaracoesFiacao.structureAplicacao[1];
							DicionarioAplicacao.LeOsTiposDeAplicacoes(ref mAplicacao);
							if (Information.UBound(mAplicacao) == 0)
							{
								DicionarioAplicacao.GravaDicionarioAplicacoes(lN5X39yAhc);
							}
						}
						if (PASm9FIRAo)
						{
							kYKRxBQASo();
						}
						r3CRbVhSUY();
						XwpRMjFpK9();
						SocRO6OqrZ();
						t47RI6rsHN();
					}
				}
				else
				{
					SocRO6OqrZ();
					t47RI6rsHN();
				}
				if (rbCompleto.Checked)
				{
					int num2 = Information.UBound(z6nXKJP5yL);
					for (int j = 1; j <= num2; j++)
					{
						z6nXKJP5yL[j].pnDest = Conversions.ToString(LOiRNA5xMm(Conversions.ToInteger(z6nXKJP5yL[j].pnOrig)));
					}
					int num3 = Information.UBound(lIcXeiJewq);
					for (int k = 1; k <= num3; k++)
					{
						lIcXeiJewq[k].pnDest = Conversions.ToString(LOiRNA5xMm(Conversions.ToInteger(lIcXeiJewq[k].pnOrig)));
					}
					int num4 = Information.UBound(vEmX2P2NjP);
					for (int l = 1; l <= num4; l++)
					{
						vEmX2P2NjP[l].pnDest = Conversions.ToString(LOiRNA5xMm(Conversions.ToInteger(vEmX2P2NjP[l].pnOrig)));
					}
					int num5 = Information.UBound(z6nXKJP5yL);
					bool flag = default;
					for (int m = 1; m <= num5; m++)
					{
						if (Operators.CompareString(z6nXKJP5yL[m].pnOrig, z6nXKJP5yL[m].pnDest, TextCompare: true) == 0)
						{
							continue;
						}
						Declaracoes2.StructurePlaquetas[] mPlaquetas = z6nXKJP5yL[m].mPlaquetas;
						int num6 = Information.UBound(mPlaquetas);
						for (int n = 0; n <= num6; n++)
						{
							if (Operators.CompareString(mPlaquetas[n].Tipo, "D", TextCompare: true) == 0)
							{
								mPlaquetas[n].Handle = bdFRebmV6g(mPlaquetas[n].Handle);
							}
							if (Operators.CompareString(mPlaquetas[n].Tipo, "R", TextCompare: true) == 0)
							{
								mPlaquetas[n].IndiceRegua = k7qRPQdYdK(mPlaquetas[n].IndiceRegua, ref flag);
							}
						}
					}
					int num7 = Information.UBound(z6nXKJP5yL);
					for (int num8 = 1; num8 <= num7; num8++)
					{
						if (Operators.CompareString(z6nXKJP5yL[num8].pnOrig, z6nXKJP5yL[num8].pnDest, TextCompare: true) != 0)
						{
							DicionarioPlaqueta.gravaDicPlaqueta(z6nXKJP5yL[num8].pnDest, ref z6nXKJP5yL[num8].mPlaquetas);
						}
					}
					int num9 = Information.UBound(lIcXeiJewq);
					for (int num10 = 1; num10 <= num9; num10++)
					{
						if (!DicionarioLayout.ExisteDicLayoutPainelTipo(lIcXeiJewq[num10].pnDest, "P"))
						{
							DicionarioLayout.gravaDicLayout("P" + lIcXeiJewq[num10].pnDest, ref lIcXeiJewq[num10].mLayout);
						}
					}
					int num11 = Information.UBound(vEmX2P2NjP);
					for (int num12 = 1; num12 <= num11; num12++)
					{
						if (!DicionarioLayout.ExisteDicLayoutPainelTipo(vEmX2P2NjP[num12].pnDest, "C"))
						{
							DicionarioLayout.gravaDicLayout("C" + vEmX2P2NjP[num12].pnDest, ref vEmX2P2NjP[num12].mLayout);
						}
					}
				}
				clsPortas.SincronizaPortas();
				clsDispositivoAuxiliares.SincronizaContatos();
				clsConexao.sincronizaCircuitos();
				clsDePara.SincronizaDePara(bUpdateProp: false);
				clsInterligacao.SincronizaCruzamentoInterlig();
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 483]), MsgBoxStyle.Exclamation);
				btImportar.Enabled = true;
				Close();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Critical);
				ProjectData.ClearProjectError();
			}
			finally
			{
				DeclaracoesGeral.bSuspenderEventoExpImpClonar = false;
			}
		}
	}

	private void kYKRxBQASo()
	{
		mEFXQGVFRa = new DeclaracoesClonar.structureRelacaoMateriais[1];
		DeclaracoesClonar.structureMaterial[] mat = new DeclaracoesClonar.structureMaterial[1];
		cDadosAccessMateriais cDadosAccessMateriais2 = new cDadosAccessMateriais();
		cDadosAccessMateriais2.CarregaMateriaisStructure(ref mat);
		int num = cDadosAccessMateriais2.BuscaMaiorCodigoInterno();
		cDadosAccessMateriais2.fechaConexao();
		List<int> list = new List<int>();
		int num2 = Information.UBound(Jp8XFjY02v);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				bool flag = true;
				bool flag2 = false;
				int num3 = Information.UBound(mat);
				for (int j = 1; j <= num3; j++)
				{
					if (Jp8XFjY02v[i].CodigoInterno != mat[j].CodigoInterno)
					{
						continue;
					}
					flag2 = true;
					if ((Operators.CompareString(Jp8XFjY02v[i].CodigoCliente, mat[j].CodigoCliente, TextCompare: true) == 0) & (Operators.CompareString(Jp8XFjY02v[i].DescricaoResumida, mat[j].DescricaoResumida, TextCompare: true) == 0) & (Operators.CompareString(Jp8XFjY02v[i].Modelo, mat[j].Modelo, TextCompare: true) == 0) & (Operators.CompareString(Jp8XFjY02v[i].Fabricante, mat[j].Fabricante, TextCompare: true) == 0) & (Operators.CompareString(Jp8XFjY02v[i].DescricaoCompleta, mat[j].DescricaoCompleta, TextCompare: true) == 0))
					{
						if (flag2)
						{
							flag2 = false;
						}
						flag = false;
						ref DeclaracoesClonar.structureRelacaoMateriais[] reference = ref mEFXQGVFRa;
						reference = (DeclaracoesClonar.structureRelacaoMateriais[])Utils.CopyArray(reference, new DeclaracoesClonar.structureRelacaoMateriais[Information.UBound(mEFXQGVFRa) + 1 + 1]);
						mEFXQGVFRa[Information.UBound(mEFXQGVFRa)].CodigoInternoOrigem = Jp8XFjY02v[i].CodigoInterno;
						mEFXQGVFRa[Information.UBound(mEFXQGVFRa)].CodigoInternoDestino = Jp8XFjY02v[i].CodigoInterno;
						break;
					}
				}
				if (flag)
				{
					int num4 = 0;
					if (!flag2)
					{
						num4 = Jp8XFjY02v[i].CodigoInterno;
					}
					else
					{
						num++;
						num4 = num;
					}
					ref DeclaracoesClonar.structureRelacaoMateriais[] reference2 = ref mEFXQGVFRa;
					reference2 = (DeclaracoesClonar.structureRelacaoMateriais[])Utils.CopyArray(reference2, new DeclaracoesClonar.structureRelacaoMateriais[Information.UBound(mEFXQGVFRa) + 1 + 1]);
					mEFXQGVFRa[Information.UBound(mEFXQGVFRa)].CodigoInternoOrigem = Jp8XFjY02v[i].CodigoInterno;
					mEFXQGVFRa[Information.UBound(mEFXQGVFRa)].CodigoInternoDestino = num4;
					Jp8XFjY02v[i].CodigoInterno = num4;
					list.Add(num4);
				}
			}
			cDadosAccessMateriais cDadosAccessMateriais3 = new cDadosAccessMateriais();
			int num5 = Information.UBound(Jp8XFjY02v);
			for (int k = 1; k <= num5; k++)
			{
				if (list.Contains(Jp8XFjY02v[k].CodigoInterno))
				{
					cDadosAccessMateriais3.AdicionaItemMaterial(Jp8XFjY02v[k].CodigoInterno, Jp8XFjY02v[k].CodigoCliente, Jp8XFjY02v[k].Modelo, Jp8XFjY02v[k].Fabricante, Jp8XFjY02v[k].DescricaoResumida, Jp8XFjY02v[k].DescricaoCompleta);
				}
			}
			cDadosAccessMateriais3.fechaConexao();
		}
	}

	private void r3CRbVhSUY()
	{
		bool flag = false;
		Declaracoes2.MModelosDeContatos[] mModelo = null;
		DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref mModelo);
		int num = Information.UBound(nOcXMjbeZF);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				flag = false;
				int num2 = 0;
				int num3 = Information.UBound(mModelo);
				for (int j = 1; j <= num3; j++)
				{
					if (!((Operators.CompareString(nOcXMjbeZF[i].modelo.sNomeModelo, mModelo[j].sNomeModelo, TextCompare: true) == 0) & (Operators.CompareString(nOcXMjbeZF[i].modelo.sTerminaisDoDispositivo, mModelo[j].sTerminaisDoDispositivo, TextCompare: true) == 0)))
					{
						flag = false;
					}
					else
					{
						Declaracoes2.StructureContatosAuxiliares[] mCONTATOS = null;
						DicionarioContatos.LeOsContatosAuxiliarDoModeloDoDicionario(ref mModelo[j].iIndiceModelo, ref mCONTATOS);
						if (Information.UBound(nOcXMjbeZF[i].mContatos) != Information.UBound(mCONTATOS))
						{
							flag = false;
						}
						else
						{
							if (Information.UBound(mCONTATOS) == 0)
							{
								flag = true;
								break;
							}
							int num4 = Information.UBound(mCONTATOS);
							for (int k = 1; k <= num4; k++)
							{
								if (!((nOcXMjbeZF[i].mContatos[k].iIndice == mCONTATOS[k].iIndice) & (Operators.CompareString(nOcXMjbeZF[i].mContatos[k].sT1, mCONTATOS[k].sT1, TextCompare: true) == 0) & (Operators.CompareString(nOcXMjbeZF[i].mContatos[k].sT2, mCONTATOS[k].sT2, TextCompare: true) == 0) & (Operators.CompareString(nOcXMjbeZF[i].mContatos[k].sT3, mCONTATOS[k].sT3, TextCompare: true) == 0) & (nOcXMjbeZF[i].mContatos[k].iT == mCONTATOS[k].iT) & (nOcXMjbeZF[i].mContatos[k].iComportamento == mCONTATOS[k].iComportamento)))
								{
									flag = false;
									break;
								}
								flag = true;
								num2 = j;
							}
						}
					}
					if (flag)
					{
						break;
					}
				}
				if (!flag)
				{
					if (flag)
					{
						continue;
					}
					int iIndiceModelo = nOcXMjbeZF[i].modelo.iIndiceModelo;
					int num5 = 1;
					if (Information.UBound(mModelo) > 0)
					{
						num5 = mModelo[Information.UBound(mModelo)].iIndiceModelo + 1;
					}
					if (PASm9FIRAo)
					{
						if (nOcXMjbeZF[i].modelo.iLM1 > 0)
						{
							nOcXMjbeZF[i].modelo.iLM1 = WG3RKnsvCl(nOcXMjbeZF[i].modelo.iLM1);
						}
						if (nOcXMjbeZF[i].modelo.iLM2 > 0)
						{
							nOcXMjbeZF[i].modelo.iLM2 = WG3RKnsvCl(nOcXMjbeZF[i].modelo.iLM2);
						}
					}
					mModelo = (Declaracoes2.MModelosDeContatos[])Utils.CopyArray(mModelo, new Declaracoes2.MModelosDeContatos[Information.UBound(mModelo) + 1 + 1]);
					mModelo[Information.UBound(mModelo)] = nOcXMjbeZF[i].modelo;
					mModelo[Information.UBound(mModelo)].iIndiceModelo = num5;
					ref DeclaracoesClonar.structureRelacaoModelosReles[] db0XOPg78y = ref Db0XOPg78y;
					db0XOPg78y = (DeclaracoesClonar.structureRelacaoModelosReles[])Utils.CopyArray(db0XOPg78y, new DeclaracoesClonar.structureRelacaoModelosReles[Information.UBound(Db0XOPg78y) + 1 + 1]);
					Db0XOPg78y[Information.UBound(Db0XOPg78y)].indiceOrigem = iIndiceModelo;
					Db0XOPg78y[Information.UBound(Db0XOPg78y)].indiceDestino = num5;
					if (!Information.IsNothing(nOcXMjbeZF[i].mContatos))
					{
						int num6 = Information.UBound(nOcXMjbeZF[i].mContatos);
						int iMaxIndice = nOcXMjbeZF[i].mContatos[num6].iIndice + 1;
						DicionarioContatos.GravaOsContatosAuxiliarDoModeloDoDicionario(num5, ref iMaxIndice, nOcXMjbeZF[i].mContatos);
					}
					continue;
				}
				ref DeclaracoesClonar.structureRelacaoModelosReles[] db0XOPg78y2 = ref Db0XOPg78y;
				db0XOPg78y2 = (DeclaracoesClonar.structureRelacaoModelosReles[])Utils.CopyArray(db0XOPg78y2, new DeclaracoesClonar.structureRelacaoModelosReles[Information.UBound(Db0XOPg78y) + 1 + 1]);
				Db0XOPg78y[Information.UBound(Db0XOPg78y)].indiceOrigem = nOcXMjbeZF[i].modelo.iIndiceModelo;
				Db0XOPg78y[Information.UBound(Db0XOPg78y)].indiceDestino = mModelo[num2].iIndiceModelo;
				if (PASm9FIRAo)
				{
					if (nOcXMjbeZF[i].modelo.iLM1 > 0)
					{
						nOcXMjbeZF[i].modelo.iLM1 = WG3RKnsvCl(nOcXMjbeZF[i].modelo.iLM1);
					}
					if (nOcXMjbeZF[i].modelo.iLM2 > 0)
					{
						nOcXMjbeZF[i].modelo.iLM2 = WG3RKnsvCl(nOcXMjbeZF[i].modelo.iLM2);
					}
				}
			}
			DicionarioContatos.GravaOsModelosDeDispositivosDeDicionario(ref mModelo);
		}
	}

	private void XwpRMjFpK9()
	{
		bool flag = false;
		Declaracoes2.MModeloDeMascara[] mModelo = null;
		DicionarioMascaras.LeOsModelosDeMascaras(ref mModelo, bComplementarModelo: false);
		int num = Information.UBound(qSeXIdqIZU);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				flag = false;
				int num2 = 0;
				int num3 = Information.UBound(mModelo);
				for (int j = 1; j <= num3; j++)
				{
					if (Operators.CompareString(qSeXIdqIZU[i].modelo.sNomeModelo, mModelo[j].sNomeModelo, TextCompare: true) != 0)
					{
						flag = false;
					}
					else
					{
						Declaracoes2.MModeloDePortas[] mPortas = null;
						DicionarioMascaras.LeAsPortasDoModeloDoDicionario(ref mModelo[j].iIndiceModelo, "", ref mPortas);
						if (Information.UBound(qSeXIdqIZU[i].mPortas) != Information.UBound(mPortas))
						{
							flag = false;
						}
						else
						{
							int num4 = Information.UBound(mPortas);
							for (int k = 1; k <= num4; k++)
							{
								if (!((qSeXIdqIZU[i].mPortas[k].IndiceDaPorta == mPortas[k].IndiceDaPorta) & (Operators.CompareString(qSeXIdqIZU[i].mPortas[k].sEFC, mPortas[k].sEFC, TextCompare: true) == 0) & (Operators.CompareString(qSeXIdqIZU[i].mPortas[k].sTerminais, mPortas[k].sTerminais, TextCompare: true) == 0) & (Operators.CompareString(qSeXIdqIZU[i].mPortas[k].sRegua, mPortas[k].sRegua, TextCompare: true) == 0) & (Operators.CompareString(qSeXIdqIZU[i].mPortas[k].sBornes, mPortas[k].sBornes, TextCompare: true) == 0)))
								{
									flag = false;
									break;
								}
								flag = true;
								num2 = j;
							}
						}
					}
					if (flag)
					{
						break;
					}
				}
				if (!flag)
				{
					if (flag)
					{
						continue;
					}
					int iIndiceModelo = qSeXIdqIZU[i].modelo.iIndiceModelo;
					int num5 = 1;
					if (Information.UBound(mModelo) > 0)
					{
						num5 = mModelo[Information.UBound(mModelo)].iIndiceModelo + 1;
					}
					if (PASm9FIRAo)
					{
						if (qSeXIdqIZU[i].modelo.iLM1 > 0L)
						{
							qSeXIdqIZU[i].modelo.iLM1 = WG3RKnsvCl((int)qSeXIdqIZU[i].modelo.iLM1);
						}
						if (qSeXIdqIZU[i].modelo.iLM2 > 0L)
						{
							qSeXIdqIZU[i].modelo.iLM2 = WG3RKnsvCl((int)qSeXIdqIZU[i].modelo.iLM2);
						}
					}
					mModelo = (Declaracoes2.MModeloDeMascara[])Utils.CopyArray(mModelo, new Declaracoes2.MModeloDeMascara[Information.UBound(mModelo) + 1 + 1]);
					mModelo[Information.UBound(mModelo)] = qSeXIdqIZU[i].modelo;
					mModelo[Information.UBound(mModelo)].iIndiceModelo = num5;
					ref DeclaracoesClonar.structureRelacaoModelosMascara[] norX7Wq2br = ref NorX7Wq2br;
					norX7Wq2br = (DeclaracoesClonar.structureRelacaoModelosMascara[])Utils.CopyArray(norX7Wq2br, new DeclaracoesClonar.structureRelacaoModelosMascara[Information.UBound(NorX7Wq2br) + 1 + 1]);
					NorX7Wq2br[Information.UBound(NorX7Wq2br)].indiceOrigem = iIndiceModelo;
					NorX7Wq2br[Information.UBound(NorX7Wq2br)].indiceDestino = num5;
					int num6 = Information.UBound(qSeXIdqIZU[i].mPortas);
					qSeXIdqIZU[i].mPortas[0].MaxIndice = qSeXIdqIZU[i].mPortas[num6].IndiceDaPorta + 1;
					DicionarioMascaras.GravaAsPortasDoModeloDoDicionario(num5, ref qSeXIdqIZU[i].mPortas);
					continue;
				}
				ref DeclaracoesClonar.structureRelacaoModelosMascara[] norX7Wq2br2 = ref NorX7Wq2br;
				norX7Wq2br2 = (DeclaracoesClonar.structureRelacaoModelosMascara[])Utils.CopyArray(norX7Wq2br2, new DeclaracoesClonar.structureRelacaoModelosMascara[Information.UBound(NorX7Wq2br) + 1 + 1]);
				NorX7Wq2br[Information.UBound(NorX7Wq2br)].indiceOrigem = qSeXIdqIZU[i].modelo.iIndiceModelo;
				NorX7Wq2br[Information.UBound(NorX7Wq2br)].indiceDestino = mModelo[num2].iIndiceModelo;
				if (PASm9FIRAo)
				{
					if (qSeXIdqIZU[i].modelo.iLM1 > 0L)
					{
						qSeXIdqIZU[i].modelo.iLM1 = WG3RKnsvCl((int)qSeXIdqIZU[i].modelo.iLM1);
					}
					if (qSeXIdqIZU[i].modelo.iLM2 > 0L)
					{
						qSeXIdqIZU[i].modelo.iLM2 = WG3RKnsvCl((int)qSeXIdqIZU[i].modelo.iLM2);
					}
				}
			}
			DicionarioMascaras.GravaOsModelosDeMascara(mModelo);
		}
	}

	private void SocRO6OqrZ()
	{
		itAX6nfgHK.Sort();
		rqRXc0e9eK = new DeclaracoesClonar.structureRelacaoPotenciais[1];
		foreach (int item in itAX6nfgHK)
		{
			ref DeclaracoesClonar.structureRelacaoPotenciais[] reference = ref rqRXc0e9eK;
			reference = (DeclaracoesClonar.structureRelacaoPotenciais[])Utils.CopyArray(reference, new DeclaracoesClonar.structureRelacaoPotenciais[checked(Information.UBound(rqRXc0e9eK) + 1 + 1)]);
			rqRXc0e9eK[Information.UBound(rqRXc0e9eK)].potencialOrigem = item;
			rqRXc0e9eK[Information.UBound(rqRXc0e9eK)].potencialDestino = XDataConexao.BuscaPotencial();
		}
	}

	private void t47RI6rsHN()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected Obj, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected Obj, but got Unknown
		//IL_1e6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected Obj, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Expected Obj, but got Unknown
		//IL_1867: Unknown result type (might be due to invalid IL or missing references)
		//IL_186d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e88: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ebf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ece: Expected Obj, but got Unknown
		//IL_0506: Unknown result type (might be due to invalid IL or missing references)
		//IL_050b: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0801: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0574: Unknown result type (might be due to invalid IL or missing references)
		//IL_0582: Unknown result type (might be due to invalid IL or missing references)
		//IL_0587: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c93: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c99: Unknown result type (might be due to invalid IL or missing references)
		//IL_18a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c52: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_18b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_18b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_18b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_18be: Unknown result type (might be due to invalid IL or missing references)
		//IL_18c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_18de: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ed: Expected Obj, but got Unknown
		//IL_0ce0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_15e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e91: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e96: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e99: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ea1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ea8: Expected Obj, but got Unknown
		//IL_1189: Unknown result type (might be due to invalid IL or missing references)
		//IL_118e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1485: Unknown result type (might be due to invalid IL or missing references)
		//IL_148a: Unknown result type (might be due to invalid IL or missing references)
		//IL_101b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1020: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b26: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b2d: Expected Obj, but got Unknown
		//IL_131d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1322: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d82: Expected Obj, but got Unknown
		//IL_1dc1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dd8: Expected Obj, but got Unknown
		//IL_1e17: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e1e: Expected Obj, but got Unknown
		DeclaracoesGeral.bAnularEventos = true;
		haJXPlbb21 = new DeclaracoesClonar.structureRelacaoHandles[1];
		l9FXj7AEv7.Clear();
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		xKBmi5dIYo = Application.DocumentManager.MdiActiveDocument;
		IdMapping val = new IdMapping();
		DocumentLock val2 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				_ = Application.DocumentManager.MdiActiveDocument.Editor;
				Transaction val3 = database.TransactionManager.StartTransaction();
				try
				{
					if (O68mYecYQ6)
					{
						database.Ltscale = cIWmSsuihd;
					}
					try
					{
						BlockTable val4 = (BlockTable)val3.GetObject(database.BlockTableId, (OpenMode)0);
						BlockTableRecord val5 = (BlockTableRecord)val3.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
						if (!O68mYecYQ6)
						{
							database.DeepCloneObjects(x1rmEXKB4D, ((DBObject)val5).ObjectId, val, false);
						}
						else
						{
							lgymZk9mmQ.Database.WblockCloneObjects(x1rmEXKB4D, ((DBObject)val5).ObjectId, val, (DuplicateRecordCloning)1, false);
						}
						foreach (object item in val)
						{
							IdPair val6 = ((item == null) ? default(IdPair) : ((IdPair)item));
							ObjectId key = val6.Key;
							ObjectId value = val6.Value;
							if (x1rmEXKB4D.Contains(key))
							{
								Entity val7 = (Entity)val3.GetObject(value, (OpenMode)1);
								try
								{
									double num = 0.0;
									double num2 = 0.0;
									val7.Layer = FdpRaIxVj2(val7.Layer, ref num, ref num2);
									Point3d val8 = new Point3d(0.0, 0.0, 0.0);
									Vector3d vectorTo = val8.GetVectorTo(new Point3d(num, num2, 0.0));
									val7.TransformBy(Matrix3d.Displacement(vectorTo));
								}
								finally
								{
									((IDisposable)val7)?.Dispose();
								}
							}
						}
						ProgressBar1.Minimum = 0;
						ProgressBar1.Maximum = x1rmEXKB4D.Count * 3;
						ProgressBar1.Value = 0;
						ProgressBar1.Step = 1;
						bool flag = default;
						int painel = default;
						foreach (object item2 in val)
						{
							IdPair val9 = ((item2 == null) ? default(IdPair) : ((IdPair)item2));
							ObjectId key2 = val9.Key;
							ObjectId value2 = val9.Value;
							if (!x1rmEXKB4D.Contains(key2))
							{
								continue;
							}
							ProgressBar1.PerformStep();
							Entity val10 = (Entity)val3.GetObject(value2, (OpenMode)1);
							try
							{
								BlockReference val11 = (BlockReference)(object)((val10 is BlockReference) ? val10 : null);
								try
								{
									if (val11 != null)
									{
										Entity ent = (Entity)(object)val11;
										string tipoImportado = "";
										string text = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
										string left = text;
										BlockReference blockRef;
										if (Operators.CompareString(left, "P", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left, "M", TextCompare: true) != 0)
											{
												if (Operators.CompareString(left, "B", TextCompare: true) == 0)
												{
													blockRef = val11;
													object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
													DeclaracoesEntidades.StructureBorne Borne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
													Borne.indexPainel = GfIR36NFkP(Borne.IndiceRegua);
													Borne.IndiceRegua = k7qRPQdYdK(Borne.IndiceRegua, ref flag);
													Borne.indexPainel = LOiRNA5xMm(Borne.indexPainel);
													Borne.NomePainel = Dicionario.BuscaNomeDoPainel(Borne.indexPainel);
													BuscaPainelNovo(Borne.indexPainel, ref Borne.NomePainel);
													Borne.NomeRegua = aS7RcNoOmU(Borne.IndiceRegua);
													if (flag)
													{
														Borne.Numero = "0";
														Borne.Ordem = 0.0;
														tipoImportado = ((object)((DBObject)val11).Handle/*cast due to constrained. prefix*/).ToString();
														clsBornes.EditaUmBorne(ref tipoImportado, "T1", DeclaracoesGeral.Conf.CaracterTerminalIndefinido);
													}
													if (clsBlocos.ExisteAtributo(((object)((DBObject)val11).Handle/*cast due to constrained. prefix*/).ToString(), "PAINEL"))
													{
														tipoImportado = ((object)((DBObject)val11).Handle/*cast due to constrained. prefix*/).ToString();
														clsBornes.EditaUmBorne(ref tipoImportado, "PAINEL", Borne.NomePainel);
														tipoImportado = ((object)((DBObject)val11).Handle/*cast due to constrained. prefix*/).ToString();
														clsBornes.EditaUmBorne(ref tipoImportado, "REGUA", Borne.NomeRegua);
													}
													if (Borne.Visivel != 0)
													{
														if (Borne.Visivel == 1)
														{
															tipoImportado = ((object)((DBObject)val11).Handle/*cast due to constrained. prefix*/).ToString();
															clsBornes.EditaUmBorne(ref tipoImportado, "NOME1", Borne.NomeRegua);
														}
													}
													else
													{
														tipoImportado = ((object)((DBObject)val11).Handle/*cast due to constrained. prefix*/).ToString();
														clsBornes.EditaUmBorne(ref tipoImportado, "NOME1", Borne.NomePainel + DeclaracoesGeral.Conf.SeparadorPainelRegua + Borne.NomeRegua);
													}
													if (PASm9FIRAo && Borne.lm > 0)
													{
														Borne.lm = WG3RKnsvCl(Borne.lm);
													}
													blockRef = val11;
													XDataDispositivosMaster.GravarXDataDispBorne(ref blockRef, ref Borne);
													ent = (Entity)(object)val11;
													if (XDataExpImp.PossuiXDataExportado(ref ent))
													{
														ent = (Entity)(object)val11;
														XDataExpImp.ApagarXDataExportado(ref ent);
													}
												}
											}
											else
											{
												blockRef = val11;
												object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
												DeclaracoesEntidades.StructureMascara Masc = ((obj2 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj2));
												if (!Masc.Complementar)
												{
													Masc.Painel = (short)LOiRNA5xMm(Masc.Painel);
													int num3 = 0;
													num3 = clsClonar.BuscaIndexNaMatriz(ref KEBXhQDjyG, ((object)key2/*cast due to constrained. prefix*/).ToString());
													if (!clsClonar.leTagNaMatriz(ref KEBXhQDjyG, ref Masc.Nome1, ref Masc.Nome2, ref Masc.Alternativo, num3))
													{
														blockRef = val11;
														clsClonar.AlteraNome(ref blockRef, Masc.Nome1, Masc.Nome2, Masc.Alternativo);
													}
													ref DeclaracoesClonar.structureRelacaoHandles[] reference = ref haJXPlbb21;
													reference = (DeclaracoesClonar.structureRelacaoHandles[])Utils.CopyArray(reference, new DeclaracoesClonar.structureRelacaoHandles[Information.UBound(haJXPlbb21) + 1 + 1]);
													haJXPlbb21[Information.UBound(haJXPlbb21)].handleOrigem = KEBXhQDjyG[num3].handleOrig;
													haJXPlbb21[Information.UBound(haJXPlbb21)].handleDestino = ((object)((DBObject)val11).Handle/*cast due to constrained. prefix*/).ToString();
													Masc.iLM1 = 0;
													Masc.iLM2 = 0;
													if (O68mYecYQ6)
													{
														Masc.indexModelo = lknRQYrxEb(Masc.indexModelo);
													}
													Masc.Usuario = Environment.UserName;
													Masc.Data = DateTime.Now.ToString();
													ent = (Entity)(object)val11;
													XDataDispositivosMaster.GravarXDataMascara(ref ent, ref Masc);
													ent = (Entity)(object)val11;
													if (XDataExpImp.PossuiXDataExportado(ref ent))
													{
														ent = (Entity)(object)val11;
														XDataExpImp.ApagarXDataExportado(ref ent);
													}
												}
											}
										}
										else
										{
											blockRef = val11;
											object obj3 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
											DeclaracoesEntidades.StructureDispositivo disp = ((obj3 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj3));
											disp.Painel = (short)LOiRNA5xMm(disp.Painel);
											disp.ChavePrimaria = "";
											int num4 = 0;
											num4 = clsClonar.BuscaIndexNaMatriz(ref KEBXhQDjyG, ((object)key2/*cast due to constrained. prefix*/).ToString());
											if (!clsClonar.leTagNaMatriz(ref KEBXhQDjyG, ref disp.Nome1, ref disp.Nome2, ref disp.Alternativo, num4))
											{
												blockRef = val11;
												clsClonar.AlteraNome(ref blockRef, disp.Nome1, disp.Nome2, disp.Alternativo);
											}
											ref DeclaracoesClonar.structureRelacaoHandles[] reference2 = ref haJXPlbb21;
											reference2 = (DeclaracoesClonar.structureRelacaoHandles[])Utils.CopyArray(reference2, new DeclaracoesClonar.structureRelacaoHandles[Information.UBound(haJXPlbb21) + 1 + 1]);
											haJXPlbb21[Information.UBound(haJXPlbb21)].handleOrigem = KEBXhQDjyG[num4].handleOrig;
											haJXPlbb21[Information.UBound(haJXPlbb21)].handleDestino = ((object)((DBObject)val11).Handle/*cast due to constrained. prefix*/).ToString();
											if (PASm9FIRAo)
											{
												if (disp.Complementar)
												{
													disp.iLM1 = 0;
													disp.iLM2 = 0;
												}
												else
												{
													if (disp.iLM1 > 0)
													{
														disp.iLM1 = WG3RKnsvCl(disp.iLM1);
													}
													if (disp.iLM2 > 0)
													{
														disp.iLM2 = WG3RKnsvCl(disp.iLM2);
													}
												}
											}
											if (O68mYecYQ6)
											{
												if (disp.Complementar)
												{
													disp.indexModelo = 0;
												}
												else
												{
													disp.indexModelo = tI9RF9a2BU(disp.indexModelo);
												}
											}
											disp.Usuario = Environment.UserName;
											disp.Data = DateTime.Now.ToString();
											blockRef = val11;
											XDataDispositivosMaster.GravarXDataDispPrincipal(ref blockRef, ref disp);
											ent = (Entity)(object)val11;
											if (XDataExpImp.PossuiXDataExportado(ref ent))
											{
												ent = (Entity)(object)val11;
												XDataExpImp.ApagarXDataExportado(ref ent);
											}
										}
										DeclaracoesTopografico.structureDispTopografico dTpg = default;
										blockRef = val11;
										if (XDataTopografico.lerXDataDispTopografico(ref blockRef, ref dTpg))
										{
											dTpg.painel = LOiRNA5xMm(dTpg.painel);
											int num5 = 0;
											num5 = clsClonar.BuscaIndexNaMatriz(ref KEBXhQDjyG, ((object)key2/*cast due to constrained. prefix*/).ToString());
											string Nome = "";
											if (!clsClonar.leTagNaMatriz(ref KEBXhQDjyG, ref dTpg.tag, ref Nome, ref dTpg.alternativo, num5))
											{
												blockRef = val11;
												clsClonar.AlteraNome(ref blockRef, dTpg.tag, Nome, dTpg.alternativo);
											}
											blockRef = val11;
											XDataTopografico.GravarXDataDispTopografico(ref blockRef, dTpg);
										}
										string tag = "";
										string alternativo = "";
										blockRef = val11;
										tipoImportado = "";
										if (XDataLayout.lerXDataDispLayout(ref blockRef, ref painel, ref tag, ref alternativo, ref tipoImportado))
										{
											painel = LOiRNA5xMm(painel);
											int num6 = 0;
											num6 = clsClonar.BuscaIndexNaMatriz(ref KEBXhQDjyG, ((object)key2/*cast due to constrained. prefix*/).ToString());
											string Nome2 = "";
											if (!clsClonar.leTagNaMatriz(ref KEBXhQDjyG, ref tag, ref Nome2, ref alternativo, num6))
											{
												blockRef = val11;
												clsClonar.AlteraNome(ref blockRef, tag, Nome2, alternativo);
											}
											blockRef = val11;
											XDataLayout.GravarXDataDispLayout(ref blockRef, painel, tag, alternativo);
										}
									}
									Polyline val12 = (Polyline)(object)((val10 is Polyline) ? val10 : null);
									try
									{
										DeclaracoesEntidades.StructureConexao conex = default;
										if (val12 == null)
										{
											continue;
										}
										Polyline pl = val12;
										Entity ent;
										if (XDataConexao.lerXDataConexao(ref pl, ref conex))
										{
											conex.Potencial = Vt1R2gQwEQ(conex.Potencial);
											conex.Painel = (short)LOiRNA5xMm(conex.Painel);
											int num7 = 0;
											num7 = clsClonar.BuscaIndexNaMatriz(ref KEBXhQDjyG, ((object)key2/*cast due to constrained. prefix*/).ToString());
											ref DeclaracoesClonar.structureRelacaoHandles[] reference3 = ref haJXPlbb21;
											reference3 = (DeclaracoesClonar.structureRelacaoHandles[])Utils.CopyArray(reference3, new DeclaracoesClonar.structureRelacaoHandles[Information.UBound(haJXPlbb21) + 1 + 1]);
											haJXPlbb21[Information.UBound(haJXPlbb21)].handleOrigem = KEBXhQDjyG[num7].handleOrig;
											haJXPlbb21[Information.UBound(haJXPlbb21)].handleDestino = ((object)((DBObject)val12).Handle/*cast due to constrained. prefix*/).ToString();
											conex.Usuario = Environment.UserName;
											conex.Data = DateTime.Now.ToString();
											pl = val12;
											XDataConexao.GravarXDataConexao(ref pl, conex);
											ent = (Entity)(object)val12;
											if (XDataExpImp.PossuiXDataExportado(ref ent))
											{
												ent = (Entity)(object)val12;
												XDataExpImp.ApagarXDataExportado(ref ent);
											}
											if (conex.Tipo == 3)
											{
												clsConexao clsConexao2 = new clsConexao();
												clsConexao2.CriarHatch(((Curve)val12).StartPoint, ((Entity)val12).Layer, ((object)((DBObject)val12).Handle/*cast due to constrained. prefix*/).ToString());
											}
										}
										DeclaracoesEntidades.StructureInterligacao ilig = default;
										pl = val12;
										if (!XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig))
										{
											continue;
										}
										ilig.Painel1 = (short)LOiRNA5xMm(ilig.Painel1);
										ilig.Painel2 = (short)LOiRNA5xMm(ilig.Painel2);
										ilig.Tag_Cabo = "";
										ilig.NumVeia = -1000;
										ilig.NomeVeia = "";
										int num8 = 0;
										num8 = clsClonar.BuscaIndexNaMatriz(ref KEBXhQDjyG, ((object)key2/*cast due to constrained. prefix*/).ToString());
										ref DeclaracoesClonar.structureRelacaoHandles[] reference4 = ref haJXPlbb21;
										reference4 = (DeclaracoesClonar.structureRelacaoHandles[])Utils.CopyArray(reference4, new DeclaracoesClonar.structureRelacaoHandles[Information.UBound(haJXPlbb21) + 1 + 1]);
										haJXPlbb21[Information.UBound(haJXPlbb21)].handleOrigem = KEBXhQDjyG[num8].handleOrig;
										haJXPlbb21[Information.UBound(haJXPlbb21)].handleDestino = ((object)((DBObject)val12).Handle/*cast due to constrained. prefix*/).ToString();
										ilig.Usuario = Environment.UserName;
										ilig.Data = DateTime.Now.ToString();
										if (!((ilig.Tipo == 1) | (ilig.Tipo == 3)))
										{
											if (ilig.Tipo == 2)
											{
												ilig.Handle1 = ilig.handle;
												ilig.Handle2 = ilig.handle;
												pl = val12;
												XDataInterligacao.GravarXDataInterligacao(ref pl, ref ilig, 1);
											}
										}
										else
										{
											pl = val12;
											XDataInterligacao.GravarXDataInterligacao(ref pl, ref ilig, 0);
										}
										ent = (Entity)(object)val12;
										if (XDataExpImp.PossuiXDataExportado(ref ent))
										{
											ent = (Entity)(object)val12;
											XDataExpImp.ApagarXDataExportado(ref ent);
										}
									}
									finally
									{
										((IDisposable)val12)?.Dispose();
									}
								}
								finally
								{
									((IDisposable)val11)?.Dispose();
								}
							}
							finally
							{
								((IDisposable)val10)?.Dispose();
							}
						}
						short num12 = default;
						int num13 = default;
						int potencial = default;
						short tipo2 = default;
						short tipo3 = default;
						foreach (object item3 in val)
						{
							IdPair val13 = ((item3 == null) ? default(IdPair) : ((IdPair)item3));
							ObjectId key3 = val13.Key;
							ObjectId value3 = val13.Value;
							if (!x1rmEXKB4D.Contains(key3))
							{
								continue;
							}
							ProgressBar1.PerformStep();
							Entity val14 = (Entity)val3.GetObject(value3, (OpenMode)1);
							try
							{
								BlockReference val15 = (BlockReference)(object)((val14 is BlockReference) ? val14 : null);
								try
								{
									if (val15 != null)
									{
										Entity ent = (Entity)(object)val15;
										string tipoImportado = "";
										string text2 = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
										string left2 = text2;
										if (Operators.CompareString(left2, "A", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left2, "M", TextCompare: true) != 0)
											{
												if (Operators.CompareString(left2, "E", TextCompare: true) == 0)
												{
													BlockReference blockRef = val15;
													object obj4 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
													DeclaracoesEntidades.StructurePortas Porta = ((obj4 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj4));
													int num9 = 0;
													num9 = clsClonar.BuscaIndexNaMatriz(ref KEBXhQDjyG, ((object)key3/*cast due to constrained. prefix*/).ToString());
													if (!clsClonar.leTagNaMatriz(ref KEBXhQDjyG, ref Porta.Nome1, ref Porta.Nome2, ref Porta.Alternativo, num9))
													{
														blockRef = val15;
														clsClonar.AlteraNome(ref blockRef, Porta.Nome1, Porta.Nome2, Porta.Alternativo);
													}
													ref DeclaracoesClonar.structureRelacaoHandles[] reference5 = ref haJXPlbb21;
													reference5 = (DeclaracoesClonar.structureRelacaoHandles[])Utils.CopyArray(reference5, new DeclaracoesClonar.structureRelacaoHandles[Information.UBound(haJXPlbb21) + 1 + 1]);
													haJXPlbb21[Information.UBound(haJXPlbb21)].handleOrigem = KEBXhQDjyG[num9].handleOrig;
													haJXPlbb21[Information.UBound(haJXPlbb21)].handleDestino = ((object)((DBObject)val15).Handle/*cast due to constrained. prefix*/).ToString();
													Porta.HandleDaMascara = bdFRebmV6g(Porta.HandleDaMascara);
													Porta.chavePrimaria = "";
													if (O68mYecYQ6)
													{
														Porta.indiceDoModelo = lknRQYrxEb(Porta.indiceDoModelo);
													}
													Porta.Usuario = Environment.UserName;
													Porta.Data = DateTime.Now.ToString();
													ent = (Entity)(object)val15;
													XDataDispositivosMaster.GravarXDataPorta(ref ent, ref Porta);
													ent = (Entity)(object)val15;
													if (XDataExpImp.PossuiXDataExportado(ref ent))
													{
														ent = (Entity)(object)val15;
														XDataExpImp.ApagarXDataExportado(ref ent);
													}
												}
											}
											else
											{
												BlockReference blockRef = val15;
												object obj5 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
												DeclaracoesEntidades.StructureMascara Masc2 = ((obj5 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj5));
												if (Masc2.Complementar)
												{
													Masc2.Painel = (short)LOiRNA5xMm(Masc2.Painel);
													int num10 = 0;
													num10 = clsClonar.BuscaIndexNaMatriz(ref KEBXhQDjyG, ((object)key3/*cast due to constrained. prefix*/).ToString());
													if (!clsClonar.leTagNaMatriz(ref KEBXhQDjyG, ref Masc2.Nome1, ref Masc2.Nome2, ref Masc2.Alternativo, num10))
													{
														blockRef = val15;
														clsClonar.AlteraNome(ref blockRef, Masc2.Nome1, Masc2.Nome2, Masc2.Alternativo);
													}
													Masc2.iLM1 = 0;
													Masc2.iLM2 = 0;
													Masc2.indexModelo = 0;
													Masc2.HandleMascPrincipal = bdFRebmV6g(Masc2.HandleMascPrincipal);
													Masc2.Usuario = Environment.UserName;
													Masc2.Data = DateTime.Now.ToString();
													ent = (Entity)(object)val15;
													XDataDispositivosMaster.GravarXDataMascara(ref ent, ref Masc2);
													ent = (Entity)(object)val15;
													if (XDataExpImp.PossuiXDataExportado(ref ent))
													{
														ent = (Entity)(object)val15;
														XDataExpImp.ApagarXDataExportado(ref ent);
													}
												}
											}
										}
										else
										{
											BlockReference blockRef = val15;
											object obj6 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
											DeclaracoesEntidades.StructureAuxiliar Aux = ((obj6 == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj6));
											int num11 = 0;
											num11 = clsClonar.BuscaIndexNaMatriz(ref KEBXhQDjyG, ((object)key3/*cast due to constrained. prefix*/).ToString());
											if (!clsClonar.leTagNaMatriz(ref KEBXhQDjyG, ref Aux.Nome1, ref Aux.Nome2, ref Aux.Alternativo, num11))
											{
												blockRef = val15;
												clsClonar.AlteraNome(ref blockRef, Aux.Nome1, Aux.Nome2, Aux.Alternativo);
											}
											ref DeclaracoesClonar.structureRelacaoHandles[] reference6 = ref haJXPlbb21;
											reference6 = (DeclaracoesClonar.structureRelacaoHandles[])Utils.CopyArray(reference6, new DeclaracoesClonar.structureRelacaoHandles[Information.UBound(haJXPlbb21) + 1 + 1]);
											haJXPlbb21[Information.UBound(haJXPlbb21)].handleOrigem = KEBXhQDjyG[num11].handleOrig;
											haJXPlbb21[Information.UBound(haJXPlbb21)].handleDestino = ((object)((DBObject)val15).Handle/*cast due to constrained. prefix*/).ToString();
											Aux.HandleBob = bdFRebmV6g(Aux.HandleBob);
											if (O68mYecYQ6)
											{
												Aux.IndexModelo = tI9RF9a2BU(Aux.IndexModelo);
											}
											Aux.Usuario = Environment.UserName;
											Aux.Data = DateTime.Now.ToString();
											blockRef = val15;
											XDataDispositivosMaster.GravarXDataDispAuxiliar(ref blockRef, ref Aux);
											ent = (Entity)(object)val15;
											if (XDataExpImp.PossuiXDataExportado(ref ent))
											{
												ent = (Entity)(object)val15;
												XDataExpImp.ApagarXDataExportado(ref ent);
											}
										}
									}
									DBText val16 = (DBText)(object)((val14 is DBText) ? val14 : null);
									try
									{
										if (val16 != null)
										{
											DeclaracoesEntidades.StructureDefinicaoPortas Def = default;
											Entity ent = (Entity)(object)val16;
											if (XDataDispositivosMaster.LerXDataDefinicao(ref ent, ref Def))
											{
												clsClonar.BuscaIndexNaMatriz(ref KEBXhQDjyG, ((object)key3/*cast due to constrained. prefix*/).ToString());
												Def.HandleDaMascara = bdFRebmV6g(Def.HandleDaMascara);
												if (O68mYecYQ6)
												{
													Def.indiceDoModelo = lknRQYrxEb(Def.indiceDoModelo);
												}
												ent = (Entity)(object)val16;
												XDataDispositivosMaster.GravarXDataDefinicao(ref ent, ref Def);
												ent = (Entity)(object)val16;
												if (XDataExpImp.PossuiXDataExportado(ref ent))
												{
													ent = (Entity)(object)val16;
													XDataExpImp.ApagarXDataExportado(ref ent);
												}
											}
											string handle = "";
											DBText val17 = val16;
											int enderecamento = num12;
											short tipo = (short)num13;
											bool flag2 = XDataConexao.lerXDataAuxCircuito(ref val17, ref potencial, ref handle, ref enderecamento, ref tipo);
											num13 = tipo;
											num12 = (short)enderecamento;
											if (flag2)
											{
												potencial = Vt1R2gQwEQ(potencial);
												handle = bdFRebmV6g(handle);
												val17 = val16;
												XDataConexao.GravarXDataAuxCircuito(ref val17, potencial, handle, num12, (short)num13);
												ent = (Entity)(object)val16;
												if (XDataExpImp.PossuiXDataExportado(ref ent))
												{
													ent = (Entity)(object)val16;
													XDataExpImp.ApagarXDataExportado(ref ent);
												}
											}
											string handle2 = "";
											string THandle = "";
											ent = (Entity)(object)val16;
											string tipoImportado = "";
											if (XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle2, ref tipo2, ref THandle, ref tipoImportado))
											{
												int num14 = 0;
												num14 = clsClonar.BuscaIndexNaMatriz(ref KEBXhQDjyG, ((object)key3/*cast due to constrained. prefix*/).ToString());
												ref DeclaracoesClonar.structureRelacaoHandles[] reference7 = ref haJXPlbb21;
												reference7 = (DeclaracoesClonar.structureRelacaoHandles[])Utils.CopyArray(reference7, new DeclaracoesClonar.structureRelacaoHandles[Information.UBound(haJXPlbb21) + 1 + 1]);
												haJXPlbb21[Information.UBound(haJXPlbb21)].handleOrigem = KEBXhQDjyG[num14].handleOrig;
												haJXPlbb21[Information.UBound(haJXPlbb21)].handleDestino = ((object)((DBObject)val16).Handle/*cast due to constrained. prefix*/).ToString();
												ent = (Entity)(object)val16;
												if (XDataExpImp.PossuiXDataExportado(ref ent))
												{
													ent = (Entity)(object)val16;
													XDataExpImp.ApagarXDataExportado(ref ent);
												}
											}
											string handle3 = "";
											val17 = val16;
											if (XDataDispositivo.lerXDataDePara(ref val17, ref handle3, ref tipo3))
											{
												int num15 = 0;
												num15 = clsClonar.BuscaIndexNaMatriz(ref KEBXhQDjyG, ((object)key3/*cast due to constrained. prefix*/).ToString());
												ref DeclaracoesClonar.structureRelacaoHandles[] reference8 = ref haJXPlbb21;
												reference8 = (DeclaracoesClonar.structureRelacaoHandles[])Utils.CopyArray(reference8, new DeclaracoesClonar.structureRelacaoHandles[Information.UBound(haJXPlbb21) + 1 + 1]);
												haJXPlbb21[Information.UBound(haJXPlbb21)].handleOrigem = KEBXhQDjyG[num15].handleOrig;
												haJXPlbb21[Information.UBound(haJXPlbb21)].handleDestino = ((object)((DBObject)val16).Handle/*cast due to constrained. prefix*/).ToString();
											}
										}
									}
									finally
									{
										((IDisposable)val16)?.Dispose();
									}
									Polyline val18 = (Polyline)(object)((val14 is Polyline) ? val14 : null);
									try
									{
										DeclaracoesEntidades.StructureConexao conex2 = default;
										if (val18 == null)
										{
											continue;
										}
										Polyline pl = val18;
										if (XDataConexao.lerXDataConexao(ref pl, ref conex2) && conex2.Tipo == 3)
										{
											conex2.Handle = bdFRebmV6g(conex2.Handle);
											conex2.Usuario = Environment.UserName;
											conex2.Data = DateTime.Now.ToString();
											pl = val18;
											XDataConexao.GravarXDataConexao(ref pl, conex2);
										}
										DeclaracoesEntidades.StructureInterligacao ilig2 = default;
										pl = val18;
										if (!XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig2))
										{
											continue;
										}
										if (ilig2.Tipo == 2)
										{
											ilig2.Handle1 = bdFRebmV6g(ilig2.handle);
											ilig2.Handle2 = ilig2.Handle1;
											if (Operators.CompareString(ilig2.Handle1, "", TextCompare: true) == 0)
											{
												l9FXj7AEv7.Add(((object)((DBObject)val18).Handle/*cast due to constrained. prefix*/).ToString());
											}
										}
										ilig2.Usuario = Environment.UserName;
										ilig2.Data = DateTime.Now.ToString();
										if (!((ilig2.Tipo == 1) | (ilig2.Tipo == 3)))
										{
											if (ilig2.Tipo == 2)
											{
												pl = val18;
												XDataInterligacao.GravarXDataInterligacao(ref pl, ref ilig2, 1);
											}
										}
										else
										{
											pl = val18;
											XDataInterligacao.GravarXDataInterligacao(ref pl, ref ilig2, 0);
										}
									}
									finally
									{
										((IDisposable)val18)?.Dispose();
									}
								}
								finally
								{
									((IDisposable)val15)?.Dispose();
								}
							}
							finally
							{
								((IDisposable)val14)?.Dispose();
							}
						}
						short tipo4 = default;
						short tipo5 = default;
						foreach (object item4 in val)
						{
							IdPair val19 = ((item4 == null) ? default(IdPair) : ((IdPair)item4));
							ObjectId key4 = val19.Key;
							ObjectId value4 = val19.Value;
							if (!x1rmEXKB4D.Contains(key4))
							{
								continue;
							}
							ProgressBar1.PerformStep();
							Entity val20 = (Entity)val3.GetObject(value4, (OpenMode)1);
							try
							{
								BlockReference val21 = (BlockReference)(object)((val20 is BlockReference) ? val20 : null);
								try
								{
									if (val21 != null)
									{
										Entity ent = (Entity)(object)val21;
										string tipoImportado = "";
										string text3 = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
										string left3 = text3;
										if (Operators.CompareString(left3, "E", TextCompare: true) == 0)
										{
											BlockReference blockRef = val21;
											object obj7 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
											DeclaracoesEntidades.StructurePortas Porta2 = ((obj7 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj7));
											if (Operators.CompareString(Porta2.handleDaDefinicao, "", TextCompare: true) != 0)
											{
												Porta2.handleDaDefinicao = bdFRebmV6g(Porta2.handleDaDefinicao);
											}
											Porta2.Usuario = Environment.UserName;
											Porta2.Data = DateTime.Now.ToString();
											ent = (Entity)(object)val21;
											XDataDispositivosMaster.GravarXDataPorta(ref ent, ref Porta2);
										}
										Declaracoes2.StructureModelo Modelo = default;
										ent = (Entity)(object)val21;
										if (XDataDispositivosMaster.LerXDataModelo(ref ent, ref Modelo))
										{
											clsClonar.BuscaIndexNaMatriz(ref KEBXhQDjyG, ((object)key4/*cast due to constrained. prefix*/).ToString());
											Modelo.HandleBob = bdFRebmV6g(Modelo.HandleBob);
											if (Operators.CompareString(Modelo.HandleContatoAux, "", TextCompare: true) != 0)
											{
												Modelo.HandleContatoAux = bdFRebmV6g(Modelo.HandleContatoAux);
											}
											BlockReference blockRef2 = (BlockReference)Geral.HandleToObject(Modelo.HandleBob);
											BlockReference blockRef;
											if (blockRef2 != null)
											{
												object obj8 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
												DeclaracoesEntidades.StructureDispositivo structureDispositivo = ((obj8 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj8));
												blockRef = val21;
												clsClonar.AlteraNome(ref blockRef, structureDispositivo.Nome1, structureDispositivo.Nome2, structureDispositivo.Alternativo);
											}
											if (O68mYecYQ6)
											{
												Modelo.indexModelo = tI9RF9a2BU(Modelo.indexModelo);
											}
											blockRef = val21;
											XDataDispositivosMaster.GravarXDataDispModelo(ref blockRef, ref Modelo);
											ent = (Entity)(object)val21;
											if (XDataExpImp.PossuiXDataExportado(ref ent))
											{
												ent = (Entity)(object)val21;
												XDataExpImp.ApagarXDataExportado(ref ent);
											}
										}
									}
									DBText val22 = (DBText)(object)((val20 is DBText) ? val20 : null);
									try
									{
										if (val22 != null)
										{
											DeclaracoesEntidades.StructureDefinicaoPortas Def2 = default;
											Entity ent = (Entity)(object)val22;
											if (XDataDispositivosMaster.LerXDataDefinicao(ref ent, ref Def2))
											{
												if (Operators.CompareString(Def2.handleDaPorta, "", TextCompare: true) != 0)
												{
													Def2.handleDaPorta = bdFRebmV6g(Def2.handleDaPorta);
												}
												ent = (Entity)(object)val22;
												XDataDispositivosMaster.GravarXDataDefinicao(ref ent, ref Def2);
											}
											string handle4 = "";
											string THandle2 = "";
											ent = (Entity)(object)val22;
											string tipoImportado = "";
											if (XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle4, ref tipo4, ref THandle2, ref tipoImportado))
											{
												val22.TextString = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
												if (!((Entity)val22).Visible)
												{
													((Entity)val22).Visible = true;
												}
												handle4 = bdFRebmV6g(handle4);
												if (Operators.CompareString(THandle2, "", TextCompare: true) != 0)
												{
													THandle2 = bdFRebmV6g(THandle2);
												}
												ent = (Entity)(object)val22;
												XDataInterligacao.GravarXDataAuxInterligacao(ref ent, handle4, tipo4, THandle2);
											}
											string handle5 = "";
											DBText val17 = val22;
											if (XDataDispositivo.lerXDataDePara(ref val17, ref handle5, ref tipo5))
											{
												handle5 = bdFRebmV6g(handle5);
												val17 = val22;
												XDataDispositivo.GravarXDataDePara(ref val17, handle5, tipo5);
											}
										}
									}
									finally
									{
										((IDisposable)val22)?.Dispose();
									}
									Polyline val23 = (Polyline)(object)((val20 is Polyline) ? val20 : null);
									try
									{
										if (val23 == null)
										{
											continue;
										}
										Entity ent = (Entity)(object)val23;
										if (XDataDispositivosMaster.LerXDataAuxBornes(ref ent))
										{
											ent = val20;
											if (XDataExpImp.PossuiXDataExportado(ref ent))
											{
												ent = val20;
												XDataExpImp.ApagarXDataExportado(ref ent);
											}
										}
									}
									finally
									{
										((IDisposable)val23)?.Dispose();
									}
								}
								finally
								{
									((IDisposable)val21)?.Dispose();
								}
							}
							finally
							{
								((IDisposable)val20)?.Dispose();
							}
						}
						if (cbTitulos.Checked)
						{
							BlockTableRecordEnumerator enumerator5 = default;
							try
							{
								enumerator5 = val5.GetEnumerator();
								while (enumerator5.MoveNext())
								{
									ObjectId current5 = enumerator5.Current;
									Entity val24 = (Entity)val3.GetObject(current5, (OpenMode)0);
									try
									{
										DBText val25 = (DBText)(object)((val24 is DBText) ? val24 : null);
										try
										{
											if (!((DisposableWrapper)(object)val25 != (DisposableWrapper)null))
											{
												continue;
											}
											DBText val17 = val25;
											int num16 = XDataGeral.LeXDataTitulo(ref val17);
											if ((num16 > 0) & (num16 < 5))
											{
												((DBObject)val25).UpgradeOpen();
												string text4 = iJsRqbS9Vj(((Entity)val25).Layer.ToString(), num16);
												if (Operators.CompareString(text4, "", TextCompare: true) != 0)
												{
													val25.TextString = text4;
												}
											}
										}
										finally
										{
											((IDisposable)val25)?.Dispose();
										}
									}
									finally
									{
										((IDisposable)val24)?.Dispose();
									}
								}
							}
							finally
							{
								((IDisposable)enumerator5)?.Dispose();
							}
						}
						foreach (string item5 in iY5XoVQRVT)
						{
							bool flag3 = true;
							int num17 = Information.UBound(DeclaracoesGeral.mPaginas, 2);
							for (int i = 1; i <= num17; i++)
							{
								if (Operators.ConditionalCompareObjectEqual(DeclaracoesGeral.mPaginas[0, i], item5, TextCompare: true))
								{
									flag3 = false;
									break;
								}
							}
							if (Operators.CompareString(item5, "0", TextCompare: true) == 0)
							{
								flag3 = false;
							}
							if (flag3)
							{
								Pagina.RemoveLayer(item5);
							}
						}
						foreach (string item6 in l9FXj7AEv7)
						{
							Entity val26 = (Entity)Geral.HandleToObject(item6);
							if (val26 != null)
							{
								((DBObject)val26).UpgradeOpen();
								((DBObject)val26).Erase();
							}
						}
						BlockTableRecordEnumerator enumerator8 = default;
						try
						{
							enumerator8 = val5.GetEnumerator();
							short tipo6 = default;
							while (enumerator8.MoveNext())
							{
								ObjectId current8 = enumerator8.Current;
								Entity val27 = (Entity)val3.GetObject(current8, (OpenMode)0);
								DBText val28 = (DBText)(object)((val27 is DBText) ? val27 : null);
								if ((DisposableWrapper)(object)val28 != (DisposableWrapper)null)
								{
									string handle6 = "";
									string THandle3 = "";
									Entity ent = (Entity)(object)val28;
									string tipoImportado = "";
									bool flag2 = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle6, ref tipo6, ref THandle3, ref tipoImportado);
									val28 = (DBText)ent;
									if (flag2 && l9FXj7AEv7.Contains(handle6))
									{
										((DBObject)val28).UpgradeOpen();
										((DBObject)val28).Erase();
									}
								}
							}
						}
						finally
						{
							((IDisposable)enumerator8)?.Dispose();
						}
						DeclaracoesGeral.bAnularEventos = true;
						val3.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						val3.Abort();
						throw;
					}
					finally
					{
						DeclaracoesGeral.bAnularEventos = false;
					}
				}
				finally
				{
					((IDisposable)val3)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
	}

	private int DpwR7qNCGt(object P_0)
	{
		int result = 0;
		int num = Information.UBound(KEBXhQDjyG);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Operators.ConditionalCompareObjectEqual(KEBXhQDjyG[i].handleOrig, P_0, TextCompare: true))
			{
				result = KEBXhQDjyG[i].Painel;
				break;
			}
		}
		return result;
	}

	private string iJsRqbS9Vj(string P_0, int P_1)
	{
		string result = "";
		string text = qfOR85d3nG(P_0);
		if (Operators.CompareString(text, "0", TextCompare: true) != 0)
		{
			int num = Information.UBound(WtSXLE2mAu);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (Operators.CompareString(WtSXLE2mAu[i].pagOrigem, text, TextCompare: true) == 0)
				{
					switch (P_1)
					{
					case 4:
						result = WtSXLE2mAu[i].Tit4;
						break;
					case 1:
						result = WtSXLE2mAu[i].Tit1;
						break;
					case 2:
						result = WtSXLE2mAu[i].Tit2;
						break;
					case 3:
						result = WtSXLE2mAu[i].Tit3;
						break;
					}
					break;
				}
			}
		}
		return result;
	}

	private string FdpRaIxVj2(string P_0, ref double P_1, ref double P_2)
	{
		string result = "0";
		P_1 = 0.0;
		P_2 = 0.0;
		int num = Information.UBound(uBgXxRAlrb);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(uBgXxRAlrb[i].pagOrigem, P_0, TextCompare: true) == 0)
			{
				result = uBgXxRAlrb[i].pagDestino;
				P_1 = uBgXxRAlrb[i].dx;
				P_2 = uBgXxRAlrb[i].dy;
				break;
			}
		}
		return result;
	}

	private string qfOR85d3nG(string P_0)
	{
		string result = "0";
		int num = Information.UBound(uBgXxRAlrb);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(uBgXxRAlrb[i].pagDestino, P_0, TextCompare: true) == 0)
			{
				result = uBgXxRAlrb[i].pagOrigem;
				break;
			}
		}
		return result;
	}

	private int LOiRNA5xMm(int P_0)
	{
		int result = 0;
		int num = Information.UBound(QNDXwHNs9Y);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (QNDXwHNs9Y[i].iPainelOrigem == P_0)
			{
				result = QNDXwHNs9Y[i].iPainelDestino;
				break;
			}
		}
		return result;
	}

	private int tI9RF9a2BU(int P_0)
	{
		int result = 0;
		int num = Information.UBound(Db0XOPg78y);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Db0XOPg78y[i].indiceOrigem == P_0)
			{
				result = Db0XOPg78y[i].indiceDestino;
				break;
			}
		}
		return result;
	}

	private int lknRQYrxEb(int P_0)
	{
		int result = 0;
		int num = Information.UBound(NorX7Wq2br);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (NorX7Wq2br[i].indiceOrigem == P_0)
			{
				result = NorX7Wq2br[i].indiceDestino;
				break;
			}
		}
		return result;
	}

	private int k7qRPQdYdK(int P_0, ref bool P_1)
	{
		int result = 0;
		int num = Information.UBound(FkSXNW1U97);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (FkSXNW1U97[i].indiceOrigem == P_0)
			{
				result = FkSXNW1U97[i].indiceDestino;
				P_1 = FkSXNW1U97[i].bExistente;
				break;
			}
		}
		return result;
	}

	private string aS7RcNoOmU(int P_0)
	{
		string result = "?";
		int num = Information.UBound(O4HX8q2Ye9);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (O4HX8q2Ye9[i].indexRegua == P_0)
			{
				result = O4HX8q2Ye9[i].nomeRegua;
				break;
			}
		}
		return result;
	}

	private int WG3RKnsvCl(int P_0)
	{
		int result = 0;
		int num = Information.UBound(mEFXQGVFRa);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (mEFXQGVFRa[i].CodigoInternoOrigem == P_0)
			{
				result = mEFXQGVFRa[i].CodigoInternoDestino;
				break;
			}
		}
		return result;
	}

	private string bdFRebmV6g(string P_0)
	{
		string result = "";
		int num = Information.UBound(haJXPlbb21);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(haJXPlbb21[i].handleOrigem, P_0, TextCompare: true) == 0)
			{
				result = haJXPlbb21[i].handleDestino;
				break;
			}
		}
		return result;
	}

	private int Vt1R2gQwEQ(int P_0)
	{
		int result = 0;
		int num = Information.UBound(rqRXc0e9eK);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (rqRXc0e9eK[i].potencialOrigem == P_0)
			{
				result = rqRXc0e9eK[i].potencialDestino;
				break;
			}
		}
		return result;
	}

	private int GfIR36NFkP(int P_0)
	{
		int result = 0;
		int num = Information.UBound(n4PXqFWmdW);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (n4PXqFWmdW[i].indexRegua == P_0)
			{
				result = n4PXqFWmdW[i].indexPainel;
				break;
			}
		}
		return result;
	}

	private void fcmRndImpD(object P_0, MouseEventArgs P_1)
	{
		DataGridView.HitTestInfo hitTestInfo = dgPaineisDestino.HitTest(P_1.X, P_1.Y);
		if (hitTestInfo.RowIndex >= 0)
		{
			DataGridViewRow data = dgPaineisDestino.Rows[hitTestInfo.RowIndex];
			tjjXnhnMeM = hitTestInfo.RowIndex;
			dgPaineisDestino.Rows[tjjXnhnMeM].Selected = true;
			dgPaineisDestino.DoDragDrop(data, DragDropEffects.All);
		}
	}

	private void BH9R1fbpE9(object P_0, DragEventArgs P_1)
	{
		Point point = dgRelacaoPaineis.PointToClient(new Point(P_1.X, P_1.Y));
		DataGridView.HitTestInfo hitTestInfo = dgRelacaoPaineis.HitTest(point.X, point.Y);
		DataGridViewRow dataGridViewRow = (DataGridViewRow)P_1.Data.GetData(typeof(DataGridViewRow));
		if (hitTestInfo.RowIndex >= 0)
		{
			_ = dgPaineisDestino.Rows[tjjXnhnMeM];
			VtPX1rsDvB = hitTestInfo.RowIndex;
			dgRelacaoPaineis.Rows[VtPX1rsDvB].Selected = true;
			dgRelacaoPaineis.Rows[VtPX1rsDvB].Cells[2].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[0].Value);
			dgRelacaoPaineis.Rows[VtPX1rsDvB].Cells[3].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[1].Value);
		}
		dgPaineisDestino.Rows.RemoveAt(tjjXnhnMeM);
	}

	private void Cd4Rle1Jd6(object P_0, DragEventArgs P_1)
	{
		P_1.Effect = DragDropEffects.Copy;
	}

	private void sibR50SBZc(object P_0, DataGridViewCellEventArgs P_1)
	{
		if (P_1.ColumnIndex != 1)
		{
			return;
		}
		string text = Conversions.ToString(dgRelacaoPaginas.Rows[P_1.RowIndex].Cells[P_1.ColumnIndex].Value);
		if (text == null)
		{
			text = "";
		}
		text = text.Trim().ToUpper();
		checked
		{
			if (!(!Versioned.IsNumeric(text) & (Operators.CompareString(text, "", TextCompare: true) != 0)))
			{
				if (Versioned.IsNumeric(text) && Conversions.ToInteger(text) == 0)
				{
					text = "";
				}
			}
			else if (text.Length != 1)
			{
				int num = text.Length - 1;
				for (int i = 1; i <= num; i++)
				{
					if (!Versioned.IsNumeric(Strings.Mid(text, i, 1)))
					{
						text = "";
						break;
					}
				}
			}
			else if (!Versioned.IsNumeric(text))
			{
				text = "";
			}
			if (Operators.CompareString(text, "", TextCompare: true) != 0)
			{
				text = Pagina.montaNumeroPagina(text);
			}
			dgRelacaoPaginas.Rows[P_1.RowIndex].Cells[P_1.ColumnIndex].Value = text;
			verificaPaginaJaExiste();
		}
	}

	public void verificaPaginaJaExiste()
	{
		List<string> list = new List<string>();
		checked
		{
			int num = dgRelacaoPaginas.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (Information.IsNothing(RuntimeHelpers.GetObjectValue(dgRelacaoPaginas.Rows[i].Cells[1].Value)))
				{
					dgRelacaoPaginas.Rows[i].Cells[1].Value = "";
				}
				dgRelacaoPaginas.Rows[i].Cells[1].Style.BackColor = Color.White;
				if (!Operators.ConditionalCompareObjectEqual(dgRelacaoPaginas.Rows[i].Cells[1].Value, "", TextCompare: true))
				{
					if (!list.Contains(Conversions.ToString(dgRelacaoPaginas.Rows[i].Cells[1].Value)))
					{
						list.Add(Conversions.ToString(dgRelacaoPaginas.Rows[i].Cells[1].Value));
					}
					else
					{
						dgRelacaoPaginas.Rows[i].Cells[1].Style.BackColor = Color.LightCoral;
					}
				}
			}
		}
	}

	private void cKhR0ml5Fg()
	{
		int num = Information.UBound(oBBXTa1FnI, 2);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Operators.ConditionalCompareObjectNotEqual(oBBXTa1FnI[1, i], "???", TextCompare: true))
			{
				dgPaineisOrigem.Rows.Add(oBBXTa1FnI[0, i], oBBXTa1FnI[1, i]);
			}
		}
		DataGridViewColumn dataGridViewColumn = dgPaineisOrigem.Columns[1];
		dgPaineisOrigem.Sort(dataGridViewColumn, ListSortDirection.Ascending);
	}

	private void fqNRRn2Ll9()
	{
		foreach (KeyValuePair<int, string> item in DeclaracoesGeral.dicPainel)
		{
			dgPaineisDestino.Rows.Add(item.Key, item.Value);
		}
	}

	private void AEMRmDX8CE()
	{
		int num = Information.UBound(QNDXwHNs9Y);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			dgRelacaoPaineis.Rows.Add(QNDXwHNs9Y[i].iPainelOrigem, QNDXwHNs9Y[i].sPainelOrigem, 0, "");
		}
	}

	private void epPRXk0gHx()
	{
		int num = Information.UBound(oBBXTa1FnI, 2);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			oBBXTa1FnI[1, i] = Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(oBBXTa1FnI[0, i]));
		}
	}

	private void rKyRUt6AsR()
	{
		QNDXwHNs9Y = new DeclaracoesClonar.structureRelacaoPaineis[1];
		int num = 0;
		checked
		{
			int num2 = dgPaineisOrigem.RowCount - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (dgPaineisOrigem.Rows[i].Selected)
				{
					uqkXdUUkXi.Add(Conversions.ToInteger(dgPaineisOrigem.Rows[i].Cells[0].Value));
					num++;
					ref DeclaracoesClonar.structureRelacaoPaineis[] qNDXwHNs9Y = ref QNDXwHNs9Y;
					qNDXwHNs9Y = (DeclaracoesClonar.structureRelacaoPaineis[])Utils.CopyArray(qNDXwHNs9Y, new DeclaracoesClonar.structureRelacaoPaineis[num + 1]);
					QNDXwHNs9Y[num].iPainelOrigem = Conversions.ToInteger(dgPaineisOrigem.Rows[i].Cells[0].Value);
					QNDXwHNs9Y[num].sPainelOrigem = Conversions.ToString(dgPaineisOrigem.Rows[i].Cells[1].Value);
					QNDXwHNs9Y[num].iPainelDestino = 0;
					QNDXwHNs9Y[num].sPainelDestino = "";
				}
			}
		}
	}

	private void vQoRyPqIs4()
	{
		int num = 0;
		checked
		{
			int num2 = dgRelacaoPaineis.RowCount - 1;
			for (int i = 0; i <= num2; i++)
			{
				num++;
				QNDXwHNs9Y[num].iPainelDestino = Conversions.ToInteger(dgRelacaoPaineis.Rows[i].Cells[2].Value);
				QNDXwHNs9Y[num].sPainelDestino = Conversions.ToString(dgRelacaoPaineis.Rows[i].Cells[3].Value);
			}
		}
	}

	private bool DHrRgtv4WV()
	{
		bool result = true;
		checked
		{
			int num = dgRelacaoPaineis.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				if (Operators.ConditionalCompareObjectEqual(dgRelacaoPaineis.Rows[i].Cells[2].Value, 0, TextCompare: true))
				{
					result = false;
					break;
				}
			}
			return result;
		}
	}

	private bool fXmRAdlfuN()
	{
		bool result = true;
		checked
		{
			int num = dgRelacaoPaginas.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(dgRelacaoPaginas.Rows[i].Cells[1].Value, null, "trim", new object[0], null, null, null), "", TextCompare: true))
				{
					result = false;
					break;
				}
			}
			return result;
		}
	}

	private void UFQRs9pqkT()
	{
		iY5XoVQRVT.Sort();
		foreach (string item in iY5XoVQRVT)
		{
			dgRelacaoPaginas.Rows.Add(item, "", Pagina.calculaPaginaDecimal(item), "0", "0");
		}
		DataGridViewColumn dataGridViewColumn = dgRelacaoPaginas.Columns[2];
		dgRelacaoPaginas.Sort(dataGridViewColumn, ListSortDirection.Ascending);
	}

	private void s3VRBfbEPL()
	{
		int num = Information.UBound(DeclaracoesGeral.mPaginas, 2);
		for (int i = 2; i <= num; i = checked(i + 1))
		{
			dgPaginasDestino.Rows.Add(Conversions.ToString(DeclaracoesGeral.mPaginas[0, i]));
		}
	}

	private void A7ORVQTM4N()
	{
		int num = 0;
		uBgXxRAlrb = new DeclaracoesClonar.structureRelacaoPaginas[1];
		checked
		{
			int num2 = dgRelacaoPaginas.RowCount - 1;
			for (int i = 0; i <= num2; i++)
			{
				num++;
				ref DeclaracoesClonar.structureRelacaoPaginas[] reference = ref uBgXxRAlrb;
				reference = (DeclaracoesClonar.structureRelacaoPaginas[])Utils.CopyArray(reference, new DeclaracoesClonar.structureRelacaoPaginas[num + 1]);
				uBgXxRAlrb[num].pagOrigem = Conversions.ToString(dgRelacaoPaginas.Rows[i].Cells[0].Value);
				uBgXxRAlrb[num].pagDestino = Conversions.ToString(dgRelacaoPaginas.Rows[i].Cells[1].Value);
				uBgXxRAlrb[num].dx = Conversions.ToDouble(dgRelacaoPaginas.Rows[i].Cells[3].Value);
				uBgXxRAlrb[num].dy = Conversions.ToDouble(dgRelacaoPaginas.Rows[i].Cells[4].Value);
			}
		}
	}

	private void AcLRuKUhhy()
	{
		int num = Information.UBound(KEBXhQDjyG);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				if (!((Operators.CompareString(KEBXhQDjyG[i].tipo, "P", TextCompare: true) == 0) | (Operators.CompareString(KEBXhQDjyG[i].tipo, "M", TextCompare: true) == 0) | (Operators.CompareString(KEBXhQDjyG[i].tipo, "TPGD", TextCompare: true) == 0) | (Operators.CompareString(KEBXhQDjyG[i].tipo, "LAYD", TextCompare: true) == 0)))
				{
					continue;
				}
				int num2 = LOiRNA5xMm(KEBXhQDjyG[i].Painel);
				string pnDestino = Dicionario.BuscaNomeDoPainel(num2);
				BuscaPainelNovo(num2, ref pnDestino);
				int num3 = -1;
				int num4 = dgTags.RowCount - 1;
				for (int j = 0; j <= num4; j++)
				{
					if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(num2, dgTags.Rows[j].Cells[1].Value, TextCompare: true), Operators.CompareObjectEqual(KEBXhQDjyG[i].Nome1, dgTags.Rows[j].Cells[3].Value, TextCompare: true)), Operators.CompareObjectEqual(KEBXhQDjyG[i].Nome2, dgTags.Rows[j].Cells[4].Value, TextCompare: true)), Operators.CompareObjectEqual(KEBXhQDjyG[i].Alternativo, dgTags.Rows[j].Cells[5].Value, TextCompare: true))))
					{
						num3 = j;
						break;
					}
				}
				if (num3 == -1)
				{
					if (!((Operators.CompareString(KEBXhQDjyG[i].tipo, "P", TextCompare: true) == 0) | (Operators.CompareString(KEBXhQDjyG[i].tipo, "M", TextCompare: true) == 0)))
					{
						if (Operators.CompareString(KEBXhQDjyG[i].tipo, "TPGD", TextCompare: true) != 0)
						{
							if (Operators.CompareString(KEBXhQDjyG[i].tipo, "LAYD", TextCompare: true) == 0)
							{
								dgTags.Rows.Add(0, num2, pnDestino, KEBXhQDjyG[i].Nome1, KEBXhQDjyG[i].Nome2, KEBXhQDjyG[i].Alternativo, 0, i);
							}
						}
						else
						{
							dgTags.Rows.Add(0, num2, pnDestino, KEBXhQDjyG[i].Nome1, KEBXhQDjyG[i].Nome2, KEBXhQDjyG[i].Alternativo, i, 0);
						}
					}
					else
					{
						dgTags.Rows.Add(i, num2, pnDestino, KEBXhQDjyG[i].Nome1, KEBXhQDjyG[i].Nome2, KEBXhQDjyG[i].Alternativo, 0, 0);
					}
				}
				if (yVTRZMLkZm(num2, KEBXhQDjyG[i].Nome1, KEBXhQDjyG[i].Nome2, 1))
				{
					dgTags.Rows[dgTags.RowCount - 1].Cells[3].Style.BackColor = Color.LightCoral;
					dgTags.Rows[dgTags.RowCount - 1].Cells[4].Style.BackColor = Color.LightCoral;
				}
				if (yVTRZMLkZm(num2, KEBXhQDjyG[i].Alternativo, "", 2))
				{
					dgTags.Rows[dgTags.RowCount - 1].Cells[5].Style.BackColor = Color.LightCoral;
				}
			}
		}
	}

	private void HALRE5IqNP()
	{
		Y4AXkdy2Vo.Sort();
		checked
		{
			foreach (int item in Y4AXkdy2Vo)
			{
				int num = Information.UBound(n4PXqFWmdW);
				for (int i = 1; i <= num; i++)
				{
					if (n4PXqFWmdW[i].indexRegua != item)
					{
						continue;
					}
					int num2 = LOiRNA5xMm(n4PXqFWmdW[i].indexPainel);
					string pnDestino = Dicionario.BuscaNomeDoPainel(num2);
					BuscaPainelNovo(num2, ref pnDestino);
					string nomeRegua = n4PXqFWmdW[i].nomeRegua;
					dgReguas.Rows.Add(item, num2, pnDestino, nomeRegua);
					int num3 = Information.UBound(BwoXai25qY);
					for (int j = 1; j <= num3; j++)
					{
						if ((BwoXai25qY[j].indexPainel == num2) & (Operators.CompareString(BwoXai25qY[j].nomeRegua, nomeRegua, TextCompare: true) == 0))
						{
							dgReguas.Rows[dgReguas.Rows.Count - 1].Cells[3].Style.BackColor = Color.LightCoral;
							break;
						}
					}
				}
			}
		}
	}

	private bool yVTRZMLkZm(int P_0, string P_1, string P_2, int P_3)
	{
		bool result = false;
		checked
		{
			switch (P_3)
			{
			case 1:
			{
				int num2 = Information.UBound(NtRXb2BLqs);
				for (int j = 1; j <= num2; j++)
				{
					if ((P_0 == NtRXb2BLqs[j].Painel) & (Operators.CompareString(P_1, NtRXb2BLqs[j].Nome1, TextCompare: true) == 0) & (Operators.CompareString(P_2, NtRXb2BLqs[j].Nome2, TextCompare: true) == 0))
					{
						result = true;
						break;
					}
				}
				break;
			}
			case 2:
			{
				int num = Information.UBound(NtRXb2BLqs);
				for (int i = 1; i <= num; i++)
				{
					if ((P_0 == NtRXb2BLqs[i].Painel) & (Operators.CompareString(P_1, NtRXb2BLqs[i].Alternativo, TextCompare: true) == 0) & (Operators.CompareString(P_1, "", TextCompare: true) != 0))
					{
						result = true;
						break;
					}
				}
				break;
			}
			}
			return result;
		}
	}

	private void pp7Rilteg0(object P_0, DataGridViewCellEventArgs P_1)
	{
		string text = Conversions.ToString(dgTags.Rows[P_1.RowIndex].Cells[P_1.ColumnIndex].Value);
		if (text == null)
		{
			text = "";
		}
		text = text.Trim();
		int rowIndex = P_1.RowIndex;
		int num = Conversions.ToInteger(dgTags.Rows[rowIndex].Cells[0].Value);
		string right = KEBXhQDjyG[num].Nome1 + "/" + KEBXhQDjyG[num].Nome2;
		string text2 = Conversions.ToString(Operators.AddObject(Operators.AddObject(dgTags.Rows[rowIndex].Cells[3].Value, "/"), dgTags.Rows[rowIndex].Cells[4].Value));
		int num2 = Conversions.ToInteger(dgTags.Rows[rowIndex].Cells[1].Value);
		checked
		{
			if (P_1.ColumnIndex == 3)
			{
				dgTags.Rows[rowIndex].Cells[3].Style.BackColor = Color.White;
				dgTags.Rows[rowIndex].Cells[4].Style.BackColor = Color.White;
				int num3 = dgTags.Rows.Count - 1;
				for (int i = 0; i <= num3; i++)
				{
					if (i == rowIndex)
					{
						continue;
					}
					int num4 = Conversions.ToInteger(dgTags.Rows[i].Cells[1].Value);
					if (num2 == num4)
					{
						string left = Conversions.ToString(Operators.AddObject(Operators.AddObject(dgTags.Rows[i].Cells[3].Value, "/"), dgTags.Rows[i].Cells[4].Value));
						if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareString(left, text2, TextCompare: true) == 0, Operators.CompareObjectNotEqual(dgTags.Rows[rowIndex].Cells[3].Value, "", TextCompare: true))))
						{
							dgTags.Rows[rowIndex].Cells[3].Style.BackColor = Color.LightCoral;
							dgTags.Rows[rowIndex].Cells[4].Style.BackColor = Color.LightCoral;
							break;
						}
					}
				}
				if (yVTRZMLkZm(num2, Conversions.ToString(dgTags.Rows[rowIndex].Cells[3].Value), Conversions.ToString(dgTags.Rows[rowIndex].Cells[4].Value), 1))
				{
					dgTags.Rows[rowIndex].Cells[3].Style.BackColor = Color.LightCoral;
					dgTags.Rows[rowIndex].Cells[4].Style.BackColor = Color.LightCoral;
				}
			}
			if (P_1.ColumnIndex == 4)
			{
				dgTags.Rows[rowIndex].Cells[3].Style.BackColor = Color.White;
				dgTags.Rows[rowIndex].Cells[4].Style.BackColor = Color.White;
				int num5 = dgTags.Rows.Count - 1;
				for (int j = 0; j <= num5; j++)
				{
					if (j == rowIndex)
					{
						continue;
					}
					int num6 = Conversions.ToInteger(dgTags.Rows[j].Cells[1].Value);
					if (num2 == num6)
					{
						string left2 = Conversions.ToString(Operators.AddObject(Operators.AddObject(dgTags.Rows[j].Cells[3].Value, "/"), dgTags.Rows[j].Cells[4].Value));
						dgTags.Rows[rowIndex].Cells[3].Style.BackColor = Color.White;
						dgTags.Rows[rowIndex].Cells[4].Style.BackColor = Color.White;
						if ((Operators.CompareString(left2, text2, TextCompare: true) == 0) | (Operators.CompareString(text2, right, TextCompare: true) == 0))
						{
							dgTags.Rows[rowIndex].Cells[3].Style.BackColor = Color.LightCoral;
							dgTags.Rows[rowIndex].Cells[4].Style.BackColor = Color.LightCoral;
							break;
						}
					}
				}
				if (yVTRZMLkZm(num2, Conversions.ToString(dgTags.Rows[rowIndex].Cells[3].Value), Conversions.ToString(dgTags.Rows[rowIndex].Cells[4].Value), 1))
				{
					dgTags.Rows[rowIndex].Cells[3].Style.BackColor = Color.LightCoral;
					dgTags.Rows[rowIndex].Cells[4].Style.BackColor = Color.LightCoral;
				}
			}
			if (!Conversions.ToBoolean(Operators.AndObject(P_1.ColumnIndex == 5, Operators.CompareObjectNotEqual(dgTags.Rows[rowIndex].Cells[5].Value, "", TextCompare: true))))
			{
				dgTags.Rows[rowIndex].Cells[5].Style.BackColor = Color.White;
				return;
			}
			dgTags.Rows[rowIndex].Cells[5].Style.BackColor = Color.White;
			int num7 = dgTags.Rows.Count - 1;
			for (int k = 0; k <= num7; k++)
			{
				if (k == rowIndex)
				{
					continue;
				}
				int num8 = Conversions.ToInteger(dgTags.Rows[k].Cells[1].Value);
				if (num2 == num8)
				{
					string left3 = Conversions.ToString(dgTags.Rows[k].Cells[5].Value);
					if (Operators.ConditionalCompareObjectEqual(left3, dgTags.Rows[rowIndex].Cells[5].Value, TextCompare: true))
					{
						dgTags.Rows[rowIndex].Cells[5].Style.BackColor = Color.LightCoral;
					}
				}
			}
			if (yVTRZMLkZm(num2, Conversions.ToString(dgTags.Rows[rowIndex].Cells[5].Value), "", 2))
			{
				dgTags.Rows[rowIndex].Cells[5].Style.BackColor = Color.LightCoral;
			}
		}
	}

	private void d7JRSnrRvA(object P_0, DataGridViewCellEventArgs P_1)
	{
		string text = Conversions.ToString(dgReguas.Rows[P_1.RowIndex].Cells[P_1.ColumnIndex].Value);
		if (text == null)
		{
			text = "";
		}
		text = text.Trim();
		int rowIndex = P_1.RowIndex;
		int num = Conversions.ToInteger(dgReguas.Rows[rowIndex].Cells[1].Value);
		if (!Conversions.ToBoolean(Operators.AndObject(P_1.ColumnIndex == 3, Operators.CompareObjectNotEqual(dgReguas.Rows[rowIndex].Cells[3].Value, "", TextCompare: true))))
		{
			dgReguas.Rows[rowIndex].Cells[3].Style.BackColor = Color.White;
			return;
		}
		dgReguas.Rows[rowIndex].Cells[3].Style.BackColor = Color.White;
		checked
		{
			int num2 = dgReguas.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (i == rowIndex)
				{
					continue;
				}
				int num3 = Conversions.ToInteger(dgReguas.Rows[i].Cells[1].Value);
				if (num == num3)
				{
					string left = Conversions.ToString(dgReguas.Rows[i].Cells[3].Value);
					if (Operators.ConditionalCompareObjectEqual(left, dgReguas.Rows[rowIndex].Cells[3].Value, TextCompare: true))
					{
						dgReguas.Rows[rowIndex].Cells[3].Style.BackColor = Color.LightCoral;
					}
				}
			}
			int num4 = Information.UBound(BwoXai25qY);
			int num5 = 1;
			while (true)
			{
				if (num5 <= num4)
				{
					if (Conversions.ToBoolean(Operators.AndObject(BwoXai25qY[num5].indexPainel == num, Operators.CompareObjectEqual(BwoXai25qY[num5].nomeRegua, dgReguas.Rows[rowIndex].Cells[3].Value, TextCompare: true))))
					{
						break;
					}
					num5++;
					continue;
				}
				return;
			}
			dgReguas.Rows[rowIndex].Cells[3].Style.BackColor = Color.LightCoral;
		}
	}

	private void UoYR4OoXLu()
	{
		int num = 0;
		int num2 = 0;
		checked
		{
			int num3 = dgTags.Rows.Count - 1;
			for (int i = 0; i <= num3; i++)
			{
				int num4 = Conversions.ToInteger(dgTags.Rows[i].Cells[0].Value);
				int num5 = Conversions.ToInteger(dgTags.Rows[i].Cells[6].Value);
				int num6 = Conversions.ToInteger(dgTags.Rows[i].Cells[7].Value);
				string nome = KEBXhQDjyG[num4].Nome1;
				string nome2 = KEBXhQDjyG[num4].Nome2;
				string alternativo = KEBXhQDjyG[num4].Alternativo;
				string right = "";
				if (dgTags.Rows[i].Cells[3].Style.BackColor == Color.LightCoral)
				{
					num++;
					right = " [" + num + "]";
				}
				string text = "";
				if (dgTags.Rows[i].Cells[5].Style.BackColor == Color.LightCoral)
				{
					num2++;
					text = " [" + num2 + "]";
				}
				if (num4 > 0)
				{
					KEBXhQDjyG[num4].Nome1 = Conversions.ToString(Operators.AddObject(dgTags.Rows[i].Cells[3].Value, right));
					KEBXhQDjyG[num4].Nome2 = clsTextos.TiraNothing(Conversions.ToString(dgTags.Rows[i].Cells[4].Value));
					KEBXhQDjyG[num4].Alternativo = clsTextos.TiraNothing(Conversions.ToString(dgTags.Rows[i].Cells[5].Value)) + text;
				}
				if (num5 > 0)
				{
					KEBXhQDjyG[num5].Nome1 = Conversions.ToString(Operators.AddObject(dgTags.Rows[i].Cells[3].Value, right));
					KEBXhQDjyG[num5].Nome2 = clsTextos.TiraNothing(Conversions.ToString(dgTags.Rows[i].Cells[4].Value));
					KEBXhQDjyG[num5].Alternativo = clsTextos.TiraNothing(Conversions.ToString(dgTags.Rows[i].Cells[5].Value)) + text;
				}
				if (num6 > 0)
				{
					KEBXhQDjyG[num6].Nome1 = Conversions.ToString(Operators.AddObject(dgTags.Rows[i].Cells[3].Value, right));
					KEBXhQDjyG[num6].Nome2 = clsTextos.TiraNothing(Conversions.ToString(dgTags.Rows[i].Cells[4].Value));
					KEBXhQDjyG[num6].Alternativo = clsTextos.TiraNothing(Conversions.ToString(dgTags.Rows[i].Cells[5].Value)) + text;
				}
				int num7 = Information.UBound(KEBXhQDjyG);
				for (int j = 1; j <= num7; j++)
				{
					if (((Operators.CompareString(KEBXhQDjyG[j].tipo, "A", TextCompare: true) == 0) | (Operators.CompareString(KEBXhQDjyG[j].tipo, "E", TextCompare: true) == 0) | (Operators.CompareString(KEBXhQDjyG[j].tipo, "PC", TextCompare: true) == 0) | (Operators.CompareString(KEBXhQDjyG[j].tipo, "MC", TextCompare: true) == 0)) && ((Operators.CompareString(KEBXhQDjyG[j].Nome1, nome, TextCompare: true) == 0) & (Operators.CompareString(KEBXhQDjyG[j].Nome2, nome2, TextCompare: true) == 0) & (Operators.CompareString(KEBXhQDjyG[j].Alternativo, alternativo, TextCompare: true) == 0) & (KEBXhQDjyG[j].Painel == KEBXhQDjyG[num4].Painel)))
					{
						KEBXhQDjyG[j].Nome1 = KEBXhQDjyG[num4].Nome1;
						KEBXhQDjyG[j].Nome2 = KEBXhQDjyG[num4].Nome2;
						KEBXhQDjyG[j].Alternativo = KEBXhQDjyG[num4].Alternativo;
					}
				}
			}
		}
	}

	private void JGiRCVbMvK()
	{
		int num = 0;
		int num2 = BwoXai25qY[0].iMaxIndice;
		int num3 = Information.UBound(BwoXai25qY);
		checked
		{
			for (int i = 1; i <= num3; i++)
			{
				ref Declaracoes2.StructureModeloDeReguas[] o4HX8q2Ye = ref O4HX8q2Ye9;
				o4HX8q2Ye = (Declaracoes2.StructureModeloDeReguas[])Utils.CopyArray(o4HX8q2Ye, new Declaracoes2.StructureModeloDeReguas[Information.UBound(O4HX8q2Ye9) + 1 + 1]);
				O4HX8q2Ye9[Information.UBound(O4HX8q2Ye9)] = BwoXai25qY[i];
			}
			int num4 = dgReguas.Rows.Count - 1;
			for (int j = 0; j <= num4; j++)
			{
				bool flag = false;
				int num5 = Information.UBound(BwoXai25qY);
				for (int k = 1; k <= num5; k++)
				{
					if (Conversions.ToBoolean(Operators.AndObject(BwoXai25qY[k].indexPainel == Conversions.ToInteger(dgReguas.Rows[j].Cells[1].Value), Operators.CompareObjectEqual(BwoXai25qY[k].nomeRegua, dgReguas.Rows[j].Cells[3].Value, TextCompare: true))))
					{
						num = BwoXai25qY[k].indexRegua;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					num2++;
					num = num2;
					ref Declaracoes2.StructureModeloDeReguas[] o4HX8q2Ye2 = ref O4HX8q2Ye9;
					o4HX8q2Ye2 = (Declaracoes2.StructureModeloDeReguas[])Utils.CopyArray(o4HX8q2Ye2, new Declaracoes2.StructureModeloDeReguas[Information.UBound(O4HX8q2Ye9) + 1 + 1]);
					O4HX8q2Ye9[Information.UBound(O4HX8q2Ye9)].indexRegua = num;
					O4HX8q2Ye9[Information.UBound(O4HX8q2Ye9)].indexPainel = Conversions.ToInteger(dgReguas.Rows[j].Cells[1].Value);
					O4HX8q2Ye9[Information.UBound(O4HX8q2Ye9)].nomeRegua = Conversions.ToString(dgReguas.Rows[j].Cells[3].Value);
					O4HX8q2Ye9[Information.UBound(O4HX8q2Ye9)].nomeAlternativo = "";
				}
				ref DeclaracoesClonar.structureRelacaoModelosRegua[] fkSXNW1U = ref FkSXNW1U97;
				fkSXNW1U = (DeclaracoesClonar.structureRelacaoModelosRegua[])Utils.CopyArray(fkSXNW1U, new DeclaracoesClonar.structureRelacaoModelosRegua[Information.UBound(FkSXNW1U97) + 1 + 1]);
				FkSXNW1U97[Information.UBound(FkSXNW1U97)].indiceOrigem = Conversions.ToInteger(dgReguas.Rows[j].Cells[0].Value);
				FkSXNW1U97[Information.UBound(FkSXNW1U97)].indiceDestino = num;
				if (!flag)
				{
					FkSXNW1U97[Information.UBound(FkSXNW1U97)].bExistente = false;
				}
				else
				{
					FkSXNW1U97[Information.UBound(FkSXNW1U97)].bExistente = true;
				}
			}
			O4HX8q2Ye9[0].iMaxIndice = num2;
		}
	}

	public void FormataDGPaineisOrigem()
	{
		checked
		{
			try
			{
				dgPaineisOrigem.Rows.Clear();
				dgPaineisOrigem.Columns.Clear();
				dgPaineisOrigem.Columns.Add("", "");
				dgPaineisOrigem.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 626]));
				float num = dgPaineisOrigem.Width - 22;
				dgPaineisOrigem.Columns[0].Width = 0;
				dgPaineisOrigem.Columns[0].Visible = false;
				dgPaineisOrigem.Columns[1].Width = (int)Math.Round(num);
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

	public void AtualizaDGPaineisOrigem()
	{
		checked
		{
			try
			{
				if (dgPaineisOrigem.Rows.Count != 0)
				{
					float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgPaineisOrigem)) ? ((float)(dgPaineisOrigem.Width - 4)) : ((float)(dgPaineisOrigem.Width - 22)));
					dgPaineisOrigem.Columns[0].Width = 0;
					dgPaineisOrigem.Columns[0].Visible = false;
					dgPaineisOrigem.Columns[1].Width = (int)Math.Round(num);
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

	public void FormataDGPaineisDestino()
	{
		checked
		{
			try
			{
				dgPaineisDestino.Rows.Clear();
				dgPaineisDestino.Columns.Clear();
				dgPaineisDestino.Columns.Add("", "");
				dgPaineisDestino.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 626]));
				float num = dgPaineisDestino.Width - 22;
				dgPaineisDestino.Columns[0].Width = 0;
				dgPaineisDestino.Columns[0].Visible = false;
				dgPaineisDestino.Columns[1].Width = (int)Math.Round(num);
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

	public void AtualizaDGPaineisDestino()
	{
		checked
		{
			try
			{
				if (dgPaineisDestino.Rows.Count != 0)
				{
					float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgPaineisDestino)) ? ((float)(dgPaineisDestino.Width - 4)) : ((float)(dgPaineisDestino.Width - 22)));
					dgPaineisDestino.Columns[0].Width = 0;
					dgPaineisDestino.Columns[0].Visible = false;
					dgPaineisDestino.Columns[1].Width = (int)Math.Round(num);
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

	public void FormataDGRelacaoPaineis()
	{
		try
		{
			dgRelacaoPaineis.Rows.Clear();
			dgRelacaoPaineis.Columns.Clear();
			dgRelacaoPaineis.Columns.Add("", "");
			dgRelacaoPaineis.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 48]));
			dgRelacaoPaineis.Columns.Add("", "");
			dgRelacaoPaineis.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 49]));
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

	public void AtualizaDGRelacaoPaineis()
	{
		checked
		{
			try
			{
				if (dgRelacaoPaineis.Rows.Count != 0)
				{
					float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgRelacaoPaineis)) ? ((float)(dgRelacaoPaineis.Width - 4)) : ((float)(dgRelacaoPaineis.Width - 22)));
					dgRelacaoPaineis.Columns[0].Width = 0;
					dgRelacaoPaineis.Columns[1].Width = (int)Math.Round((double)num * 0.5);
					dgRelacaoPaineis.Columns[2].Width = 0;
					dgRelacaoPaineis.Columns[3].Width = (int)Math.Round((double)num * 0.5);
					dgRelacaoPaineis.Columns[0].Visible = false;
					dgRelacaoPaineis.Columns[1].Visible = true;
					dgRelacaoPaineis.Columns[2].Visible = false;
					dgRelacaoPaineis.Columns[3].Visible = true;
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

	public void FormataDGRelacaoPaginas()
	{
		checked
		{
			try
			{
				dgRelacaoPaginas.Rows.Clear();
				dgRelacaoPaginas.Columns.Clear();
				dgRelacaoPaginas.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 48]));
				dgRelacaoPaginas.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 49]));
				dgRelacaoPaginas.Columns.Add("", "");
				dgRelacaoPaginas.Columns.Add("", "dx");
				dgRelacaoPaginas.Columns.Add("", "dy");
				float num = dgRelacaoPaginas.Width - 22;
				dgRelacaoPaginas.Columns[0].Width = (int)Math.Round(num / 4f);
				dgRelacaoPaginas.Columns[1].Width = (int)Math.Round(num / 4f);
				dgRelacaoPaginas.Columns[2].Width = 0;
				dgRelacaoPaginas.Columns[2].Visible = false;
				dgRelacaoPaginas.Columns[3].Width = (int)Math.Round(num / 4f);
				dgRelacaoPaginas.Columns[4].Width = (int)Math.Round(num / 4f);
				dgRelacaoPaginas.Columns[0].ReadOnly = true;
				dgRelacaoPaginas.Columns[1].ReadOnly = false;
				dgRelacaoPaginas.Columns[2].ReadOnly = true;
				dgRelacaoPaginas.Columns[3].ReadOnly = false;
				dgRelacaoPaginas.Columns[4].ReadOnly = false;
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

	public void AtualizaDGRelacaoPaginas()
	{
		checked
		{
			try
			{
				if (dgRelacaoPaginas.Rows.Count != 0)
				{
					float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgRelacaoPaginas)) ? ((float)(dgRelacaoPaginas.Width - 4)) : ((float)(dgRelacaoPaginas.Width - 22)));
					dgRelacaoPaginas.Columns[0].Width = (int)Math.Round(num / 4f);
					dgRelacaoPaginas.Columns[1].Width = (int)Math.Round(num / 4f);
					dgRelacaoPaginas.Columns[2].Width = 0;
					dgRelacaoPaginas.Columns[2].Visible = false;
					dgRelacaoPaginas.Columns[3].Width = (int)Math.Round(num / 4f);
					dgRelacaoPaginas.Columns[4].Width = (int)Math.Round(num / 4f);
					dgRelacaoPaginas.Columns[0].ReadOnly = true;
					dgRelacaoPaginas.Columns[1].ReadOnly = false;
					dgRelacaoPaginas.Columns[2].ReadOnly = true;
					dgRelacaoPaginas.Columns[3].ReadOnly = false;
					dgRelacaoPaginas.Columns[4].ReadOnly = false;
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

	public void FormataDGPaginasDestino()
	{
		checked
		{
			try
			{
				dgPaginasDestino.Rows.Clear();
				dgPaginasDestino.Columns.Clear();
				dgPaginasDestino.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 684]));
				float num = dgPaginasDestino.Width - 22;
				dgPaineisDestino.Columns[0].Width = (int)Math.Round(num);
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

	public void AtualizaDGPaginasDestino()
	{
		checked
		{
			try
			{
				if (dgPaineisDestino.Rows.Count != 0)
				{
					float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgPaineisDestino)) ? ((float)(dgPaineisDestino.Width - 4)) : ((float)(dgPaineisDestino.Width - 22)));
					dgPaineisDestino.Columns[0].Width = (int)Math.Round(num);
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

	public void formataDGTags()
	{
		checked
		{
			try
			{
				dgTags.Rows.Clear();
				dgTags.Columns.Clear();
				dgTags.Columns.Add("", "");
				dgTags.Columns.Add("", "");
				dgTags.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 626]));
				dgTags.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 627]));
				dgTags.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 628]));
				dgTags.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 629]));
				dgTags.Columns.Add("", "");
				dgTags.Columns.Add("", "");
				float num = dgTags.Width - 22;
				dgTags.Columns[0].Width = 0;
				dgTags.Columns[0].Visible = false;
				dgTags.Columns[1].Width = 0;
				dgTags.Columns[1].Visible = false;
				dgTags.Columns[2].Width = (int)Math.Round(num * 2f / 5f);
				dgTags.Columns[3].Width = (int)Math.Round(num / 5f);
				dgTags.Columns[4].Width = (int)Math.Round(num / 5f);
				dgTags.Columns[5].Width = (int)Math.Round(num / 5f);
				dgTags.Columns[6].Width = 0;
				dgTags.Columns[6].Visible = false;
				dgTags.Columns[7].Width = 0;
				dgTags.Columns[7].Visible = false;
				dgTags.Columns[0].ReadOnly = true;
				dgTags.Columns[1].ReadOnly = true;
				dgTags.Columns[2].ReadOnly = true;
				dgTags.Columns[6].ReadOnly = true;
				dgTags.Columns[7].ReadOnly = true;
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

	public void AtualizaDGTags()
	{
		checked
		{
			try
			{
				if (dgTags.Rows.Count != 0)
				{
					float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgTags)) ? ((float)(dgTags.Width - 4)) : ((float)(dgTags.Width - 22)));
					dgTags.Columns[0].Width = 0;
					dgTags.Columns[0].Visible = false;
					dgTags.Columns[1].Width = 0;
					dgTags.Columns[1].Visible = false;
					dgTags.Columns[2].Width = (int)Math.Round(num * 2f / 5f);
					dgTags.Columns[3].Width = (int)Math.Round(num / 5f);
					dgTags.Columns[4].Width = (int)Math.Round(num / 5f);
					dgTags.Columns[5].Width = (int)Math.Round(num / 5f);
					dgTags.Columns[6].Width = 0;
					dgTags.Columns[6].Visible = false;
					dgTags.Columns[7].Width = 0;
					dgTags.Columns[7].Visible = false;
					dgTags.Columns[0].ReadOnly = true;
					dgTags.Columns[1].ReadOnly = true;
					dgTags.Columns[2].ReadOnly = true;
					dgTags.Columns[6].ReadOnly = true;
					dgTags.Columns[7].ReadOnly = true;
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

	public void formataDGReguas()
	{
		checked
		{
			try
			{
				dgReguas.Rows.Clear();
				dgReguas.Columns.Clear();
				dgReguas.Columns.Add("", "");
				dgReguas.Columns.Add("", "");
				dgReguas.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 626]));
				dgReguas.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1114]));
				float num = dgReguas.Width - 22;
				dgReguas.Columns[0].Width = 0;
				dgReguas.Columns[0].Visible = false;
				dgReguas.Columns[1].Width = 0;
				dgReguas.Columns[1].Visible = false;
				dgReguas.Columns[2].Width = (int)Math.Round(num * 2f / 3f);
				dgReguas.Columns[3].Width = (int)Math.Round(num / 3f);
				dgReguas.Columns[0].ReadOnly = true;
				dgReguas.Columns[1].ReadOnly = true;
				dgReguas.Columns[2].ReadOnly = true;
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

	public void AtualizaDGReguas()
	{
		checked
		{
			try
			{
				if (dgReguas.Rows.Count != 0)
				{
					float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgReguas)) ? ((float)(dgReguas.Width - 4)) : ((float)(dgReguas.Width - 22)));
					dgReguas.Columns[0].Width = 0;
					dgReguas.Columns[0].Visible = false;
					dgReguas.Columns[1].Width = 0;
					dgReguas.Columns[1].Visible = false;
					dgReguas.Columns[2].Width = (int)Math.Round(num * 2f / 3f);
					dgReguas.Columns[3].Width = (int)Math.Round(num / 3f);
					dgReguas.Columns[0].ReadOnly = true;
					dgReguas.Columns[1].ReadOnly = true;
					dgReguas.Columns[2].ReadOnly = true;
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

	private void uM7RYhW4yb(object P_0, EventArgs P_1)
	{
		if (!rbCompleto.Checked)
		{
			btCopiarOrigem.Enabled = false;
			btSelecionar.Enabled = true;
		}
		else
		{
			btCopiarOrigem.Enabled = true;
			btSelecionar.Enabled = false;
		}
	}

	private void YPyRrfevCU(object P_0, EventArgs P_1)
	{
		FqMR95obDx();
	}

	private void FqMR95obDx()
	{
		AtualizaDGRelacaoPaineis();
		AtualizaDGPaineisOrigem();
		AtualizaDGPaginasDestino();
		AtualizaDGPaineisDestino();
		AtualizaDGReguas();
		AtualizaDGRelacaoPaginas();
		AtualizaDGTags();
		UoYR4OoXLu();
	}

	private void fI2Rzkm17A(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void vjdmWT9Pql(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void J0AmpmQFLq(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void YoBmTstLxw(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void bd4mJ7IOIL(object P_0, KeyEventArgs P_1)
	{
		WpMmo2p8EQ();
	}

	private void YVXmhgYpgo(object P_0, DataGridViewCellEventArgs P_1)
	{
		checked
		{
			int num = dgRelacaoPaineis.Rows.Count - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					if (dgRelacaoPaineis.Rows[num2].Selected)
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			TBNome.Text = Conversions.ToString(dgRelacaoPaineis.Rows[num2].Cells[1].Value);
			WpMmo2p8EQ();
		}
	}

	private void WpMmo2p8EQ()
	{
		btInserir.Enabled = true;
		TBNome.Text = TBNome.Text.Trim();
		checked
		{
			if (!DeclaracoesGeral.dicPainel.ContainsValue(TBNome.Text.ToUpper()))
			{
				int num = dgRelacaoPaineis.Rows.Count - 1;
				int num2 = 0;
				while (true)
				{
					if (num2 <= num)
					{
						if (Operators.ConditionalCompareObjectEqual(dgRelacaoPaineis.Rows[num2].Cells[3].Value, TBNome.Text.ToUpper(), TextCompare: true))
						{
							break;
						}
						num2++;
						continue;
					}
					return;
				}
				btInserir.Enabled = false;
			}
			else
			{
				btInserir.Enabled = false;
			}
		}
	}

	private void aLHmGJ3uJJ(object P_0, EventArgs P_1)
	{
		int num = 0;
		checked
		{
			int num2 = dgRelacaoPaineis.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (dgRelacaoPaineis.Rows[i].Selected & btInserir.Enabled)
				{
					if (i >= 6)
					{
						dgRelacaoPaineis.FirstDisplayedScrollingRowIndex = i - 5;
					}
					dgRelacaoPaineis.Rows[i].Cells[2].Value = 0;
					dgRelacaoPaineis.Rows[i].Cells[3].Value = TBNome.Text;
					num = i + 1;
					dgRelacaoPaineis.Rows[i].Selected = false;
					break;
				}
			}
			if (num <= dgRelacaoPaineis.Rows.Count - 1)
			{
				dgRelacaoPaineis.Rows[num].Selected = true;
				TBNome.Text = Conversions.ToString(dgRelacaoPaineis.Rows[num].Cells[1].Value);
			}
			WpMmo2p8EQ();
		}
	}

	public void CadastraPaineis()
	{
		string userName = Environment.UserName;
		string sEditor = "";
		object value = DateTime.Now.ToString();
		cDadosAccessPaineis cDadosAccessPaineis2 = new cDadosAccessPaineis();
		int num = Information.UBound(ApomC4Vd2K);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			cDadosAccessPaineis2.AdicionaPainel("Paineis", ApomC4Vd2K[i].iPN, ApomC4Vd2K[i].sPN, userName, sEditor, Conversions.ToDate(value));
		}
		cDadosAccessPaineis2.fechaConexao();
	}

	public void BuscaPainelNovo(int iPnDestino, ref string pnDestino)
	{
		int num = Information.UBound(ApomC4Vd2K);
		int num2 = 0;
		while (true)
		{
			if (num2 <= num)
			{
				if (iPnDestino == ApomC4Vd2K[num2].iPN)
				{
					break;
				}
				num2 = checked(num2 + 1);
				continue;
			}
			return;
		}
		pnDestino = ApomC4Vd2K[num2].sPN;
	}
}
