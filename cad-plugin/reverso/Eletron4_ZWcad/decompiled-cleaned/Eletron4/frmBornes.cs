using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using VimZUaplUIPJH2tfOAZ9;
using YhamV21aratNE3b4GFK;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.Geometry;
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmBornes : Form
{
	private IContainer FiHlz8G9Ka;

	[AccessedThroughProperty("LbFiltro")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label EPx5WOeKhO;

	[CompilerGenerated]
	[AccessedThroughProperty("TBPesquisa")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox PcA5pbK55X;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGBlocos")]
	[CompilerGenerated]
	private DataGridView Abu5TtSdi0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGReguas")]
	[CompilerGenerated]
	private DataGridView fNV5J0srkf;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btInserirBaixo")]
	private Button X4u5hOPjE8;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("IDWG")]
	private PictureBox Vmq5oOZHPk;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip VC05G6fnTo;

	[AccessedThroughProperty("GroupBox1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox zq05HspcnJ;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox Whp5k0bESb;

	[CompilerGenerated]
	[AccessedThroughProperty("btInserir")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button krx5dF4bO0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btInserirCima")]
	private Button b535fql3G8;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RBBornes")]
	[CompilerGenerated]
	private RadioButton rY35DwSkni;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("RBDispositivos")]
	private RadioButton UJe5vZekjD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btBorneLinhaH")]
	private Button k5O56QttCH;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btApagarLinhas")]
	private Button piE5tWhTvs;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox3")]
	[CompilerGenerated]
	private GroupBox kUY5jCE9Q3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TBInserir")]
	private TextBox J9O5L8H57L;

	[CompilerGenerated]
	[AccessedThroughProperty("LbQuantidade")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label MAk5whQwRb;

	[AccessedThroughProperty("LBDistancia")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label f8q5xnrsCn;

	[AccessedThroughProperty("CKRegua")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox hTk5bWVEdB;

	[AccessedThroughProperty("CKPainel")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox Ekt5M77EmT;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CkTodos")]
	[CompilerGenerated]
	private RadioButton CLQ5OBEIKW;

	[AccessedThroughProperty("ckPrimeiro")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton hHb5IWRd67;

	[AccessedThroughProperty("btBorneLinhaV")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button DrD57VPZEt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label2")]
	private Label WlI5qgKGru;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label1")]
	private Label sq85aTCJ6c;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDy")]
	private TextBox hq458ZqVDG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbDx")]
	private TextBox DPW5Nwn5Wa;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("TBF")]
	private TextBox GdL5FCxKdJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("TBM")]
	private TextBox wgi5QmMsA6;

	[AccessedThroughProperty("TBI")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox A735Po6ycD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbV")]
	private RadioButton MTq5cGLjFV;

	[AccessedThroughProperty("rbH")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton OoY5KPdyRw;

	[AccessedThroughProperty("Label4")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label a5k5e5ECaP;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBI")]
	private Label u5252Sjeio;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBF")]
	[CompilerGenerated]
	private Label SEn53LFTIw;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBM")]
	private Label mBD5nDudFo;

	[AccessedThroughProperty("BTSelecionaBornes")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button YEM517lknf;

	private object[,] N9J5laLDKa;

	private string K5i55JTQ80;

	private Declaracoes2.StructureModeloDeReguas[] O3D50Zjhxu;

	internal virtual Label LbFiltro
	{
		[CompilerGenerated]
		get
		{
			return EPx5WOeKhO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EPx5WOeKhO = value;
		}
	}

	internal virtual TextBox TBPesquisa
	{
		[CompilerGenerated]
		get
		{
			return PcA5pbK55X;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = E0rl1Z1lmX;
			TextBox textBox = PcA5pbK55X;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			PcA5pbK55X = value;
			textBox = PcA5pbK55X;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual DataGridView DGBlocos
	{
		[CompilerGenerated]
		get
		{
			return Abu5TtSdi0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = IHOlPBLgWg;
			KeyEventHandler value3 = qFYlcm6oIC;
			KeyEventHandler value4 = j0klK7DOZ5;
			DataGridView dataGridView = Abu5TtSdi0;
			if (dataGridView != null)
			{
				dataGridView.MouseClick -= value2;
				dataGridView.KeyUp -= value3;
				dataGridView.KeyDown -= value4;
			}
			Abu5TtSdi0 = value;
			dataGridView = Abu5TtSdi0;
			if (dataGridView != null)
			{
				dataGridView.MouseClick += value2;
				dataGridView.KeyUp += value3;
				dataGridView.KeyDown += value4;
			}
		}
	}

	internal virtual DataGridView DGReguas
	{
		[CompilerGenerated]
		get
		{
			return fNV5J0srkf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			fNV5J0srkf = value;
		}
	}

	internal virtual Button btInserirBaixo
	{
		[CompilerGenerated]
		get
		{
			return X4u5hOPjE8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = SsBlR0nJBW;
			Button button = X4u5hOPjE8;
			if (button != null)
			{
				button.Click -= value2;
			}
			X4u5hOPjE8 = value;
			button = X4u5hOPjE8;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual PictureBox IDWG
	{
		[CompilerGenerated]
		get
		{
			return Vmq5oOZHPk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Vmq5oOZHPk = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return zq05HspcnJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			zq05HspcnJ = value;
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return Whp5k0bESb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Whp5k0bESb = value;
		}
	}

	internal virtual Button btInserir
	{
		[CompilerGenerated]
		get
		{
			return krx5dF4bO0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = T5ylXYwBTo;
			Button button = krx5dF4bO0;
			if (button != null)
			{
				button.Click -= value2;
			}
			krx5dF4bO0 = value;
			button = krx5dF4bO0;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btInserirCima
	{
		[CompilerGenerated]
		get
		{
			return b535fql3G8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UpSlmFj0cD;
			Button button = b535fql3G8;
			if (button != null)
			{
				button.Click -= value2;
			}
			b535fql3G8 = value;
			button = b535fql3G8;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual RadioButton RBBornes
	{
		[CompilerGenerated]
		get
		{
			return rY35DwSkni;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = W4qly1qerp;
			RadioButton radioButton = rY35DwSkni;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			rY35DwSkni = value;
			radioButton = rY35DwSkni;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton RBDispositivos
	{
		[CompilerGenerated]
		get
		{
			return UJe5vZekjD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = KUYlUkPYiR;
			RadioButton radioButton = UJe5vZekjD;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			UJe5vZekjD = value;
			radioButton = UJe5vZekjD;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button btBorneLinhaH
	{
		[CompilerGenerated]
		get
		{
			return k5O56QttCH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Sarll2L5sL;
			Button button = k5O56QttCH;
			if (button != null)
			{
				button.Click -= value2;
			}
			k5O56QttCH = value;
			button = k5O56QttCH;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btApagarLinhas
	{
		[CompilerGenerated]
		get
		{
			return piE5tWhTvs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = KOZl06551O;
			Button button = piE5tWhTvs;
			if (button != null)
			{
				button.Click -= value2;
			}
			piE5tWhTvs = value;
			button = piE5tWhTvs;
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
			return kUY5jCE9Q3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			kUY5jCE9Q3 = value;
		}
	}

	internal virtual TextBox TBInserir
	{
		[CompilerGenerated]
		get
		{
			return J9O5L8H57L;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = Eu9lASo2d0;
			TextBox textBox = J9O5L8H57L;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			J9O5L8H57L = value;
			textBox = J9O5L8H57L;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Label LbQuantidade
	{
		[CompilerGenerated]
		get
		{
			return MAk5whQwRb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MAk5whQwRb = value;
		}
	}

	internal virtual Label LBDistancia
	{
		[CompilerGenerated]
		get
		{
			return f8q5xnrsCn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			f8q5xnrsCn = value;
		}
	}

	internal virtual CheckBox CKRegua
	{
		[CompilerGenerated]
		get
		{
			return hTk5bWVEdB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = CKYlu394BZ;
			CheckBox checkBox = hTk5bWVEdB;
			if (checkBox != null)
			{
				checkBox.MouseUp -= value2;
			}
			hTk5bWVEdB = value;
			checkBox = hTk5bWVEdB;
			if (checkBox != null)
			{
				checkBox.MouseUp += value2;
			}
		}
	}

	internal virtual CheckBox CKPainel
	{
		[CompilerGenerated]
		get
		{
			return Ekt5M77EmT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = uiblVWcuXK;
			CheckBox checkBox = Ekt5M77EmT;
			if (checkBox != null)
			{
				checkBox.MouseUp -= value2;
			}
			Ekt5M77EmT = value;
			checkBox = Ekt5M77EmT;
			if (checkBox != null)
			{
				checkBox.MouseUp += value2;
			}
		}
	}

	internal virtual RadioButton CkTodos
	{
		[CompilerGenerated]
		get
		{
			return CLQ5OBEIKW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CLQ5OBEIKW = value;
		}
	}

	internal virtual RadioButton ckPrimeiro
	{
		[CompilerGenerated]
		get
		{
			return hHb5IWRd67;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			hHb5IWRd67 = value;
		}
	}

	internal virtual Button btBorneLinhaV
	{
		[CompilerGenerated]
		get
		{
			return DrD57VPZEt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = sndl5m2np1;
			Button button = DrD57VPZEt;
			if (button != null)
			{
				button.Click -= value2;
			}
			DrD57VPZEt = value;
			button = DrD57VPZEt;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label Label2
	{
		[CompilerGenerated]
		get
		{
			return WlI5qgKGru;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			WlI5qgKGru = value;
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return sq85aTCJ6c;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			sq85aTCJ6c = value;
		}
	}

	internal virtual TextBox tbDy
	{
		[CompilerGenerated]
		get
		{
			return hq458ZqVDG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = AillB2TteM;
			TextBox textBox = hq458ZqVDG;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			hq458ZqVDG = value;
			textBox = hq458ZqVDG;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox tbDx
	{
		[CompilerGenerated]
		get
		{
			return DPW5Nwn5Wa;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = lDsls6uk9x;
			TextBox textBox = DPW5Nwn5Wa;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			DPW5Nwn5Wa = value;
			textBox = DPW5Nwn5Wa;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox TBF
	{
		[CompilerGenerated]
		get
		{
			return GdL5FCxKdJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = Ec3l4p2WYm;
			EventHandler value3 = ubIlryIGsD;
			TextBox textBox = GdL5FCxKdJ;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
				textBox.TextChanged -= value3;
			}
			GdL5FCxKdJ = value;
			textBox = GdL5FCxKdJ;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
				textBox.TextChanged += value3;
			}
		}
	}

	internal virtual TextBox TBM
	{
		[CompilerGenerated]
		get
		{
			return wgi5QmMsA6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = T3ylSV4fhr;
			EventHandler value3 = xZZlY37ybu;
			TextBox textBox = wgi5QmMsA6;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
				textBox.TextChanged -= value3;
			}
			wgi5QmMsA6 = value;
			textBox = wgi5QmMsA6;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
				textBox.TextChanged += value3;
			}
		}
	}

	internal virtual TextBox TBI
	{
		[CompilerGenerated]
		get
		{
			return A735Po6ycD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = QPWli1mMjB;
			EventHandler value3 = VThlCYnRpw;
			TextBox textBox = A735Po6ycD;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
				textBox.TextChanged -= value3;
			}
			A735Po6ycD = value;
			textBox = A735Po6ycD;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
				textBox.TextChanged += value3;
			}
		}
	}

	internal virtual RadioButton rbV
	{
		[CompilerGenerated]
		get
		{
			return MTq5cGLjFV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = noTlZ3fB9R;
			RadioButton radioButton = MTq5cGLjFV;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			MTq5cGLjFV = value;
			radioButton = MTq5cGLjFV;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton rbH
	{
		[CompilerGenerated]
		get
		{
			return OoY5KPdyRw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = qKilEDPDgY;
			RadioButton radioButton = OoY5KPdyRw;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			OoY5KPdyRw = value;
			radioButton = OoY5KPdyRw;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual Label Label4
	{
		[CompilerGenerated]
		get
		{
			return a5k5e5ECaP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			a5k5e5ECaP = value;
		}
	}

	internal virtual Label LBI
	{
		[CompilerGenerated]
		get
		{
			return u5252Sjeio;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			u5252Sjeio = value;
		}
	}

	internal virtual Label LBF
	{
		[CompilerGenerated]
		get
		{
			return SEn53LFTIw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			SEn53LFTIw = value;
		}
	}

	internal virtual Label LBM
	{
		[CompilerGenerated]
		get
		{
			return mBD5nDudFo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mBD5nDudFo = value;
		}
	}

	internal virtual Button BTSelecionaBornes
	{
		[CompilerGenerated]
		get
		{
			return YEM517lknf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Afgl9MMyuK;
			Button button = YEM517lknf;
			if (button != null)
			{
				button.Click -= value2;
			}
			YEM517lknf = value;
			button = YEM517lknf;
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
			if (disposing && FiHlz8G9Ka != null)
			{
				FiHlz8G9Ka.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void VIJlQ0B90h()
	{
		FiHlz8G9Ka = new Container();
		LbFiltro = new Label();
		TBPesquisa = new TextBox();
		DGBlocos = new DataGridView();
		DGReguas = new DataGridView();
		btInserirBaixo = new Button();
		IDWG = new PictureBox();
		FDqpBiUmZij(new ToolTip(FiHlz8G9Ka));
		GroupBox1 = new GroupBox();
		RBBornes = new RadioButton();
		RBDispositivos = new RadioButton();
		btInserirCima = new Button();
		GroupBox2 = new GroupBox();
		rbV = new RadioButton();
		rbH = new RadioButton();
		TBF = new TextBox();
		btBorneLinhaV = new Button();
		TBM = new TextBox();
		TBI = new TextBox();
		btApagarLinhas = new Button();
		btBorneLinhaH = new Button();
		Label4 = new Label();
		LBI = new Label();
		LBF = new Label();
		LBM = new Label();
		btInserir = new Button();
		GroupBox3 = new GroupBox();
		BTSelecionaBornes = new Button();
		Label2 = new Label();
		CkTodos = new RadioButton();
		Label1 = new Label();
		ckPrimeiro = new RadioButton();
		tbDy = new TextBox();
		CKRegua = new CheckBox();
		tbDx = new TextBox();
		CKPainel = new CheckBox();
		TBInserir = new TextBox();
		LbQuantidade = new Label();
		LBDistancia = new Label();
		((ISupportInitialize)DGBlocos).BeginInit();
		((ISupportInitialize)DGReguas).BeginInit();
		((ISupportInitialize)IDWG).BeginInit();
		GroupBox1.SuspendLayout();
		GroupBox2.SuspendLayout();
		GroupBox3.SuspendLayout();
		SuspendLayout();
		LbFiltro.BorderStyle = BorderStyle.Fixed3D;
		LbFiltro.Location = new Point(6, 9);
		LbFiltro.Name = "LbFiltro";
		LbFiltro.Size = new Size(81, 20);
		LbFiltro.TabIndex = 165;
		LbFiltro.Text = "Filtro";
		LbFiltro.TextAlign = ContentAlignment.MiddleCenter;
		TBPesquisa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		TBPesquisa.CharacterCasing = CharacterCasing.Upper;
		TBPesquisa.Location = new Point(93, 9);
		TBPesquisa.Name = "TBPesquisa";
		TBPesquisa.Size = new Size(266, 20);
		TBPesquisa.TabIndex = 164;
		TBPesquisa.TextAlign = HorizontalAlignment.Center;
		DGBlocos.AllowUserToAddRows = false;
		DGBlocos.AllowUserToDeleteRows = false;
		DGBlocos.AllowUserToOrderColumns = true;
		DGBlocos.AllowUserToResizeRows = false;
		DGBlocos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		DGBlocos.BorderStyle = BorderStyle.Fixed3D;
		DGBlocos.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		DGBlocos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGBlocos.Location = new Point(368, 146);
		DGBlocos.MultiSelect = false;
		DGBlocos.Name = "DGBlocos";
		DGBlocos.ReadOnly = true;
		DGBlocos.RowHeadersVisible = false;
		DGBlocos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGBlocos.Size = new Size(229, 211);
		DGBlocos.TabIndex = 157;
		DGReguas.AllowUserToAddRows = false;
		DGReguas.AllowUserToDeleteRows = false;
		DGReguas.AllowUserToOrderColumns = true;
		DGReguas.AllowUserToResizeRows = false;
		DGReguas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DGReguas.BorderStyle = BorderStyle.Fixed3D;
		DGReguas.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		DGReguas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGReguas.Location = new Point(6, 37);
		DGReguas.MultiSelect = false;
		DGReguas.Name = "DGReguas";
		DGReguas.ReadOnly = true;
		DGReguas.RowHeadersVisible = false;
		DGReguas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGReguas.Size = new Size(353, 320);
		DGReguas.TabIndex = 153;
		btInserirBaixo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btInserirBaixo.FlatStyle = FlatStyle.Flat;
		btInserirBaixo.ForeColor = SystemColors.Control;
		btInserirBaixo.Image = Resources.BornesBaixo_32;
		btInserirBaixo.Location = new Point(97, 13);
		btInserirBaixo.Name = "btInserirBaixo";
		btInserirBaixo.Size = new Size(40, 40);
		btInserirBaixo.TabIndex = 151;
		btInserirBaixo.UseVisualStyleBackColor = true;
		IDWG.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		IDWG.BackColor = SystemColors.Desktop;
		IDWG.Location = new Point(368, 9);
		IDWG.Name = "IDWG";
		IDWG.Size = new Size(229, 129);
		IDWG.SizeMode = PictureBoxSizeMode.Zoom;
		IDWG.TabIndex = 150;
		IDWG.TabStop = false;
		GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox1.Controls.Add(RBBornes);
		GroupBox1.Controls.Add(RBDispositivos);
		GroupBox1.Controls.Add(btInserirCima);
		GroupBox1.Controls.Add(btInserirBaixo);
		GroupBox1.Location = new Point(6, 366);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(139, 105);
		GroupBox1.TabIndex = 166;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "GroupBox1";
		RBBornes.AutoSize = true;
		RBBornes.Location = new Point(6, 68);
		RBBornes.Name = "RBBornes";
		RBBornes.Size = new Size(73, 17);
		RBBornes.TabIndex = 154;
		RBBornes.Text = "RBBornes";
		RBBornes.UseVisualStyleBackColor = true;
		RBDispositivos.AutoSize = true;
		RBDispositivos.Checked = true;
		RBDispositivos.Location = new Point(6, 37);
		RBDispositivos.Name = "RBDispositivos";
		RBDispositivos.Size = new Size(96, 17);
		RBDispositivos.TabIndex = 153;
		RBDispositivos.TabStop = true;
		RBDispositivos.Text = "RBDispositivos";
		RBDispositivos.UseVisualStyleBackColor = true;
		btInserirCima.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btInserirCima.FlatStyle = FlatStyle.Flat;
		btInserirCima.ForeColor = SystemColors.Control;
		btInserirCima.Image = Resources.BornesCima_32;
		btInserirCima.Location = new Point(97, 59);
		btInserirCima.Name = "btInserirCima";
		btInserirCima.Size = new Size(40, 40);
		btInserirCima.TabIndex = 152;
		btInserirCima.UseVisualStyleBackColor = true;
		GroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox2.BackColor = SystemColors.Control;
		GroupBox2.Controls.Add(rbV);
		GroupBox2.Controls.Add(rbH);
		GroupBox2.Controls.Add(TBF);
		GroupBox2.Controls.Add(btBorneLinhaV);
		GroupBox2.Controls.Add(TBM);
		GroupBox2.Controls.Add(TBI);
		GroupBox2.Controls.Add(btApagarLinhas);
		GroupBox2.Controls.Add(btBorneLinhaH);
		GroupBox2.Controls.Add(Label4);
		GroupBox2.Controls.Add(LBI);
		GroupBox2.Controls.Add(LBF);
		GroupBox2.Controls.Add(LBM);
		GroupBox2.Location = new Point(148, 366);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(195, 105);
		GroupBox2.TabIndex = 167;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "GroupBox2";
		rbV.AutoSize = true;
		rbV.Location = new Point(20, 39);
		rbV.Name = "rbV";
		rbV.Size = new Size(32, 17);
		rbV.TabIndex = 173;
		rbV.Text = "V";
		rbV.UseVisualStyleBackColor = true;
		rbH.AutoSize = true;
		rbH.Checked = true;
		rbH.Location = new Point(20, 21);
		rbH.Name = "rbH";
		rbH.Size = new Size(33, 17);
		rbH.TabIndex = 172;
		rbH.TabStop = true;
		rbH.Text = "H";
		rbH.UseVisualStyleBackColor = true;
		TBF.Location = new Point(156, 79);
		TBF.Name = "TBF";
		TBF.Size = new Size(31, 20);
		TBF.TabIndex = 164;
		TBF.Text = "0.5";
		TBF.TextAlign = HorizontalAlignment.Center;
		btBorneLinhaV.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btBorneLinhaV.Enabled = false;
		btBorneLinhaV.FlatStyle = FlatStyle.Flat;
		btBorneLinhaV.ForeColor = SystemColors.Control;
		btBorneLinhaV.Image = Resources.BornesLinhaV_32;
		btBorneLinhaV.Location = new Point(80, 14);
		btBorneLinhaV.Name = "btBorneLinhaV";
		btBorneLinhaV.Size = new Size(30, 49);
		btBorneLinhaV.TabIndex = 161;
		btBorneLinhaV.UseVisualStyleBackColor = true;
		TBM.Location = new Point(118, 79);
		TBM.Name = "TBM";
		TBM.Size = new Size(31, 20);
		TBM.TabIndex = 163;
		TBM.Text = "1";
		TBM.TextAlign = HorizontalAlignment.Center;
		TBI.Location = new Point(80, 79);
		TBI.Name = "TBI";
		TBI.Size = new Size(31, 20);
		TBI.TabIndex = 162;
		TBI.Text = "0.5";
		TBI.TextAlign = HorizontalAlignment.Center;
		btApagarLinhas.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagarLinhas.FlatStyle = FlatStyle.Flat;
		btApagarLinhas.ForeColor = SystemColors.Control;
		btApagarLinhas.Image = Resources.Delete_32;
		btApagarLinhas.Location = new Point(134, 16);
		btApagarLinhas.Name = "btApagarLinhas";
		btApagarLinhas.Size = new Size(40, 40);
		btApagarLinhas.TabIndex = 160;
		btApagarLinhas.UseVisualStyleBackColor = true;
		btBorneLinhaH.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btBorneLinhaH.FlatStyle = FlatStyle.Flat;
		btBorneLinhaH.ForeColor = SystemColors.Control;
		btBorneLinhaH.Image = Resources.BornesLinha_32;
		btBorneLinhaH.Location = new Point(66, 25);
		btBorneLinhaH.Name = "btBorneLinhaH";
		btBorneLinhaH.Size = new Size(55, 30);
		btBorneLinhaH.TabIndex = 159;
		btBorneLinhaH.UseVisualStyleBackColor = true;
		Label4.Location = new Point(3, 79);
		Label4.Name = "Label4";
		Label4.Size = new Size(83, 17);
		Label4.TabIndex = 175;
		Label4.Text = "Linetype Scale";
		Label4.TextAlign = ContentAlignment.BottomLeft;
		LBI.Location = new Point(77, 62);
		LBI.Name = "LBI";
		LBI.Size = new Size(39, 17);
		LBI.TabIndex = 174;
		LBI.Text = "Incicio";
		LBI.TextAlign = ContentAlignment.BottomCenter;
		LBF.Location = new Point(152, 62);
		LBF.Name = "LBF";
		LBF.Size = new Size(39, 17);
		LBF.TabIndex = 177;
		LBF.Text = "Fim";
		LBF.TextAlign = ContentAlignment.BottomCenter;
		LBM.Location = new Point(115, 62);
		LBM.Name = "LBM";
		LBM.Size = new Size(39, 17);
		LBM.TabIndex = 176;
		LBM.Text = "Meio";
		LBM.TextAlign = ContentAlignment.BottomCenter;
		btInserir.FlatStyle = FlatStyle.Flat;
		btInserir.ForeColor = SystemColors.Control;
		btInserir.Image = Resources.OK_32;
		btInserir.Location = new Point(206, 58);
		btInserir.Name = "btInserir";
		btInserir.Size = new Size(40, 40);
		btInserir.TabIndex = 151;
		btInserir.UseVisualStyleBackColor = true;
		GroupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		GroupBox3.Controls.Add(BTSelecionaBornes);
		GroupBox3.Controls.Add(Label2);
		GroupBox3.Controls.Add(CkTodos);
		GroupBox3.Controls.Add(Label1);
		GroupBox3.Controls.Add(ckPrimeiro);
		GroupBox3.Controls.Add(tbDy);
		GroupBox3.Controls.Add(CKRegua);
		GroupBox3.Controls.Add(tbDx);
		GroupBox3.Controls.Add(CKPainel);
		GroupBox3.Controls.Add(TBInserir);
		GroupBox3.Controls.Add(LbQuantidade);
		GroupBox3.Controls.Add(btInserir);
		GroupBox3.Controls.Add(LBDistancia);
		GroupBox3.Location = new Point(348, 366);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(249, 105);
		GroupBox3.TabIndex = 168;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "Inserção Múltipla";
		BTSelecionaBornes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		BTSelecionaBornes.FlatStyle = FlatStyle.Flat;
		BTSelecionaBornes.ForeColor = SystemColors.Control;
		BTSelecionaBornes.Image = Resources.Select_32;
		BTSelecionaBornes.Location = new Point(162, 58);
		BTSelecionaBornes.Name = "BTSelecionaBornes";
		BTSelecionaBornes.Size = new Size(40, 40);
		BTSelecionaBornes.TabIndex = 173;
		BTSelecionaBornes.UseVisualStyleBackColor = true;
		Label2.AutoSize = true;
		Label2.Location = new Point(105, 82);
		Label2.Name = "Label2";
		Label2.Size = new Size(14, 13);
		Label2.TabIndex = 3;
		Label2.Text = "Y";
		CkTodos.AutoSize = true;
		CkTodos.Location = new Point(6, 39);
		CkTodos.Name = "CkTodos";
		CkTodos.Size = new Size(104, 17);
		CkTodos.TabIndex = 172;
		CkTodos.TabStop = true;
		CkTodos.Text = "CKTodosVisiveis";
		CkTodos.UseVisualStyleBackColor = true;
		Label1.AutoSize = true;
		Label1.Location = new Point(50, 82);
		Label1.Name = "Label1";
		Label1.Size = new Size(14, 13);
		Label1.TabIndex = 2;
		Label1.Text = "X";
		ckPrimeiro.AutoSize = true;
		ckPrimeiro.Checked = true;
		ckPrimeiro.Location = new Point(6, 21);
		ckPrimeiro.Name = "ckPrimeiro";
		ckPrimeiro.Size = new Size(109, 17);
		ckPrimeiro.TabIndex = 171;
		ckPrimeiro.TabStop = true;
		ckPrimeiro.Text = "CKPrimeiro Visivel";
		ckPrimeiro.UseVisualStyleBackColor = true;
		tbDy.Location = new Point(121, 78);
		tbDy.Name = "tbDy";
		tbDy.Size = new Size(37, 20);
		tbDy.TabIndex = 1;
		CKRegua.AutoSize = true;
		CKRegua.Checked = true;
		CKRegua.CheckState = CheckState.Checked;
		CKRegua.Location = new Point(120, 39);
		CKRegua.Name = "CKRegua";
		CKRegua.Size = new Size(108, 17);
		CKRegua.TabIndex = 170;
		CKRegua.Text = "CKApenasRegua";
		CKRegua.UseVisualStyleBackColor = true;
		tbDx.Location = new Point(66, 78);
		tbDx.Name = "tbDx";
		tbDx.Size = new Size(37, 20);
		tbDx.TabIndex = 0;
		CKPainel.AutoSize = true;
		CKPainel.Checked = true;
		CKPainel.CheckState = CheckState.Checked;
		CKPainel.Location = new Point(120, 21);
		CKPainel.Name = "CKPainel";
		CKPainel.Size = new Size(98, 17);
		CKPainel.TabIndex = 169;
		CKPainel.Text = "CKNomeVisivel";
		CKPainel.UseVisualStyleBackColor = true;
		TBInserir.Location = new Point(10, 78);
		TBInserir.Name = "TBInserir";
		TBInserir.Size = new Size(37, 20);
		TBInserir.TabIndex = 160;
		TBInserir.TextAlign = HorizontalAlignment.Center;
		LbQuantidade.Location = new Point(10, 60);
		LbQuantidade.Name = "LbQuantidade";
		LbQuantidade.Size = new Size(68, 17);
		LbQuantidade.TabIndex = 162;
		LbQuantidade.Text = "LbInserir";
		LbQuantidade.TextAlign = ContentAlignment.BottomLeft;
		LBDistancia.Location = new Point(88, 59);
		LBDistancia.Name = "LBDistancia";
		LBDistancia.Size = new Size(70, 18);
		LBDistancia.TabIndex = 163;
		LBDistancia.Text = "LBDistância";
		LBDistancia.TextAlign = ContentAlignment.BottomLeft;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(604, 475);
		Controls.Add(GroupBox3);
		Controls.Add(GroupBox2);
		Controls.Add(GroupBox1);
		Controls.Add(LbFiltro);
		Controls.Add(TBPesquisa);
		Controls.Add(DGBlocos);
		Controls.Add(DGReguas);
		Controls.Add(IDWG);
		MaximumSize = new Size(620, 1000);
		MinimumSize = new Size(620, 500);
		Name = "frmBornes";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterScreen;
		Text = "Bornes";
		((ISupportInitialize)DGBlocos).EndInit();
		((ISupportInitialize)DGReguas).EndInit();
		((ISupportInitialize)IDWG).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox3.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return VC05G6fnTo;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		VC05G6fnTo = WithEventsValue;
	}

	public frmBornes()
	{
		Resize += fLilgEnDPW;
		K5i55JTQ80 = "";
		try
		{
			if (Geral.ExisteForm("frmBornes") || !clsAuxiliar.BancoValido())
			{
				return;
			}
			cDadosAccess.carregaDadosDWG();
			if (DeclaracoesGeral.arqAtivo.Indice != 0)
			{
				VIJlQ0B90h();
				RBDispositivos.Checked = true;
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 542]);
				w8dpBZ0kvSD().SetToolTip(btBorneLinhaH, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1101]));
				w8dpBZ0kvSD().SetToolTip(btBorneLinhaV, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1465]));
				w8dpBZ0kvSD().SetToolTip(btApagarLinhas, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1102]));
				w8dpBZ0kvSD().SetToolTip(btInserir, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1103]));
				RBDispositivos.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 110]);
				RBBornes.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 540]);
				ckPrimeiro.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1365]);
				CkTodos.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1366]);
				CKPainel.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1367]);
				CKRegua.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1368]);
				GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1478]);
				GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 801]);
				GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1479]);
				LbFiltro.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 272]);
				LbQuantidade.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 797]);
				LBDistancia.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 798]);
				LBI.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1914]);
				LBM.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1915]);
				LBF.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1916]);
				tbDx.Text = "0";
				tbDy.Text = "0";
				TBInserir.Text = "1";
				tbDx.Text = "40";
				tbDx.Enabled = false;
				tbDy.Enabled = false;
				if (!DicionarioBorne.ExisteDicBornesReserva())
				{
					O3D50Zjhxu = new Declaracoes2.StructureModeloDeReguas[1];
					DicionarioReguas.LeOsModelosDeRegua(ref O3D50Zjhxu);
				}
				O3D50Zjhxu = new Declaracoes2.StructureModeloDeReguas[1];
				DicionarioReguas.LeOsModelosDeRegua(ref O3D50Zjhxu);
				DataGridView dg = DGReguas;
				clsReguasDeBornes.carregaAsReguasNoDG(ref dg, O3D50Zjhxu, TBPesquisa.Text.ToString());
				DGReguas = dg;
				CarregaBlocos();
				dg = DGReguas;
				clsReguasDeBornes.AtualizaColunasDGReguaDeBornes(ref dg);
				DGReguas = dg;
				Application.ShowModelessDialog((Form)this);
				if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
				{
					Left = 0;
				}
				btBorneLinhaV.Enabled = true;
				dg = DGReguas;
				clsReguasDeBornes.AtualizaColunasDGReguaDeBornes(ref dg);
				DGReguas = dg;
				dg = DGBlocos;
				OgDlnhXddC(ref dg);
				DGBlocos = dg;
			}
			else
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 331]), MsgBoxStyle.Information);
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public void CarregaBlocos()
	{
		if ((Operators.CompareString(DeclaracoesGeral.Conf.DirSimbologiaEletrica, "", TextCompare: true) != 0) & Directory.Exists(DeclaracoesGeral.Conf.DirSimbologiaEletrica))
		{
			ref object[,] n9J5laLDKa = ref N9J5laLDKa;
			ref object[,] reference = ref n9J5laLDKa;
			object mBlocos = n9J5laLDKa;
			clsDispositivo.CarregaBlocos(ref mBlocos, "B");
			reference = (object[,])mBlocos;
			DataGridView withEventsValue = DGBlocos;
			ref object[,] n9J5laLDKa2 = ref N9J5laLDKa;
			reference = ref n9J5laLDKa2;
			mBlocos = n9J5laLDKa2;
			lb8l3T3LpP(ref withEventsValue, ref mBlocos);
			reference = (object[,])mBlocos;
			DGBlocos = withEventsValue;
			withEventsValue = DGBlocos;
			OgDlnhXddC(ref withEventsValue);
			DGBlocos = withEventsValue;
		}
	}

	private void IHOlPBLgWg(object P_0, MouseEventArgs P_1)
	{
		a3aleGWn8C();
	}

	private void qFYlcm6oIC(object P_0, KeyEventArgs P_1)
	{
		a3aleGWn8C();
	}

	private void j0klK7DOZ5(object P_0, KeyEventArgs P_1)
	{
		a3aleGWn8C();
	}

	private void a3aleGWn8C()
	{
		checked
		{
			int num = DGBlocos.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				if (DGBlocos.Rows[i].Selected)
				{
					K5i55JTQ80 = Conversions.ToString(DGBlocos.Rows[i].Cells[0].Value);
					break;
				}
			}
			Gbdl2l6jce();
		}
	}

	private void Gbdl2l6jce()
	{
		checked
		{
			int num = DGBlocos.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (DGBlocos.Rows[i].Selected)
				{
					IDWG.Image = RevJqj1qBkVn9MRpOU0.tiC18lyNXK(Conversions.ToString(DGBlocos.Rows[i].Cells[1].Value));
				}
			}
		}
	}

	private void lb8l3T3LpP(ref DataGridView P_0, ref object P_1)
	{
		P_0.Rows.Clear();
		P_0.Columns.Clear();
		if (Information.UBound((Array)P_1, 2) <= 0)
		{
			return;
		}
		checked
		{
			try
			{
				bool flag = false;
				P_0.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 118]));
				P_0.Columns.Add("", "Caminho");
				P_0.Columns.Add("", "NomeCompleto");
				if (Information.UBound((Array)P_1, 2) >= 2 && Information.UBound((Array)P_1, 2) > 0)
				{
					int num = Information.UBound((Array)P_1, 2) - 1;
					for (int i = num; i >= 1; i += -1)
					{
						int num2 = i;
						for (int j = 1; j <= num2; j++)
						{
							if (Operators.ConditionalCompareObjectGreater(NewLateBinding.LateIndexGet(P_1, new object[2] { 0, j }, null), NewLateBinding.LateIndexGet(P_1, new object[2]
							{
								0,
								j + 1
							}, null), TextCompare: true))
							{
								int num3 = 0;
								do
								{
									object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(P_1, new object[2]
									{
										num3,
										j + 1
									}, null));
									NewLateBinding.LateIndexSet(P_1, new object[3]
									{
										num3,
										j + 1,
										NewLateBinding.LateIndexGet(P_1, new object[2] { num3, j }, null)
									}, null);
									NewLateBinding.LateIndexSet(P_1, new object[3] { num3, j, objectValue }, null);
									num3++;
								}
								while (num3 <= 2);
							}
						}
					}
				}
				int num4 = Information.UBound((Array)P_1, 2);
				for (int k = 1; k <= num4; k++)
				{
					P_0.Rows.Add(Conversions.ToString(NewLateBinding.LateIndexGet(P_1, new object[2] { 0, k }, null)), Conversions.ToString(NewLateBinding.LateIndexGet(P_1, new object[2] { 1, k }, null)), Conversions.ToString(NewLateBinding.LateIndexGet(P_1, new object[2] { 2, k }, null)));
					flag = true;
				}
				if (flag)
				{
					P_0.Rows[0].Selected = true;
					IDWG.Image = RevJqj1qBkVn9MRpOU0.tiC18lyNXK(Conversions.ToString(P_0.Rows[0].Cells[1].Value));
					OgDlnhXddC(ref P_0);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
			}
		}
	}

	private void OgDlnhXddC(ref DataGridView P_0)
	{
		checked
		{
			if (P_0.RowCount != 0)
			{
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(P_0)) ? ((double)(P_0.Width - 4)) : ((double)(P_0.Width - 21)));
				P_0.Columns[0].Width = (int)Math.Round(a);
				P_0.Columns[1].Width = 0;
				P_0.Columns[2].Width = 0;
				P_0.Columns[0].Visible = true;
				P_0.Columns[1].Visible = false;
				P_0.Columns[2].Visible = false;
				P_0.Columns[0].ReadOnly = false;
				P_0.Columns[1].ReadOnly = false;
				P_0.Columns[2].ReadOnly = false;
				P_0.MultiSelect = false;
			}
		}
	}

	private void E0rl1Z1lmX(object P_0, KeyEventArgs P_1)
	{
		if ((P_1.KeyValue == 13) | (Operators.CompareString(TBPesquisa.Text, "", TextCompare: true) == 0))
		{
			TBPesquisa.Text = TBPesquisa.Text.ToString().ToUpper();
			DataGridView dg = DGReguas;
			clsReguasDeBornes.carregaAsReguasNoDG(ref dg, O3D50Zjhxu, TBPesquisa.Text.ToString());
			DGReguas = dg;
		}
	}

	private void Sarll2L5sL(object P_0, EventArgs P_1)
	{
		if (verificaValores())
		{
			Hide();
			clsLinha.AdricionaLinhaH(Conversions.ToDouble(TBI.Text), Conversions.ToDouble(TBM.Text), Conversions.ToDouble(TBF.Text));
			Show();
		}
	}

	private void sndl5m2np1(object P_0, EventArgs P_1)
	{
		if (verificaValores())
		{
			Hide();
			clsLinha.AdricionaLinhaV(Conversions.ToDouble(TBI.Text), Conversions.ToDouble(TBM.Text), Conversions.ToDouble(TBF.Text));
			Show();
		}
	}

	private void KOZl06551O(object P_0, EventArgs P_1)
	{
		clsLinha.ApagaLinhaAuxBornes(ref DeclaracoesGeral.ativo.Pagina);
	}

	private void SsBlR0nJBW(object P_0, EventArgs P_1)
	{
		int iLm = 0;
		int itipo = 0;
		DataGridViewCell dataGridViewCell = DGReguas.SelectedRows[0].Cells[0];
		int iRegua = Conversions.ToInteger(dataGridViewCell.Value);
		clsBornes.buscaTipoLm(ref iRegua, ref iLm, ref itipo);
		dataGridViewCell.Value = iRegua;
		DeclaracoesEntidades.StructureBorne Borne = default;
		if (DGReguas.SelectedRows.Count > 0)
		{
			Borne.conector = "";
			Borne.IndiceRegua = Conversions.ToInteger(DGReguas.SelectedRows[0].Cells[0].Value);
			Borne.NomePainel = Conversions.ToString(DGReguas.SelectedRows[0].Cells[1].Value);
			Borne.indexPainel = Dicionario.BuscaIndiceDoPainel(Conversions.ToString(DGReguas.SelectedRows[0].Cells[1].Value));
			Borne.NomeRegua = Conversions.ToString(DGReguas.SelectedRows[0].Cells[3].Value);
			Borne.lm = iLm;
			Borne.Numero = Conversions.ToString(0);
			Borne.NumeroComplem = "";
			Borne.Ordem = 0.0;
			Borne.tipo = itipo;
			Borne.Orientacao = "";
			Borne.BlocoLayout = "";
			Borne.PosInt_Jumper = "";
			string text = "";
			string text2 = "";
			if (DGBlocos.SelectedRows.Count > 0)
			{
				text = Conversions.ToString(DGBlocos.SelectedRows[0].Cells[2].Value);
				text2 = Conversions.ToString(DGBlocos.SelectedRows[0].Cells[1].Value);
				clsBornes.insereBorneAutomaticamente(ref Borne, text2, text, RBBornes.Checked, Up: true);
			}
		}
	}

	private void UpSlmFj0cD(object P_0, EventArgs P_1)
	{
		int iLm = 0;
		int itipo = 0;
		DataGridViewCell dataGridViewCell = DGReguas.SelectedRows[0].Cells[0];
		int iRegua = Conversions.ToInteger(dataGridViewCell.Value);
		clsBornes.buscaTipoLm(ref iRegua, ref iLm, ref itipo);
		dataGridViewCell.Value = iRegua;
		DeclaracoesEntidades.StructureBorne Borne = default;
		if (DGReguas.SelectedRows.Count > 0)
		{
			Borne.conector = "";
			Borne.IndiceRegua = Conversions.ToInteger(DGReguas.SelectedRows[0].Cells[0].Value);
			Borne.NomePainel = Conversions.ToString(DGReguas.SelectedRows[0].Cells[1].Value);
			Borne.indexPainel = Dicionario.BuscaIndiceDoPainel(Conversions.ToString(DGReguas.SelectedRows[0].Cells[1].Value));
			Borne.NomeRegua = Conversions.ToString(DGReguas.SelectedRows[0].Cells[3].Value);
			Borne.lm = iLm;
			Borne.Numero = Conversions.ToString(0);
			Borne.NumeroComplem = "";
			Borne.Ordem = 0.0;
			Borne.tipo = itipo;
			Borne.Orientacao = "";
			Borne.Orientacao = "";
			Borne.BlocoLayout = "";
			Borne.PosInt_Jumper = "";
			string text = "";
			string text2 = "";
			if (DGBlocos.SelectedRows.Count > 0)
			{
				text = Conversions.ToString(DGBlocos.SelectedRows[0].Cells[2].Value);
				text2 = Conversions.ToString(DGBlocos.SelectedRows[0].Cells[1].Value);
				clsBornes.insereBorneAutomaticamente(ref Borne, text2, text, RBBornes.Checked, Up: false);
			}
		}
	}

	private void T5ylXYwBTo(object P_0, EventArgs P_1)
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		Hide();
		int iLm = 0;
		int itipo = 0;
		DataGridViewCell dataGridViewCell = DGReguas.SelectedRows[0].Cells[0];
		int iRegua = Conversions.ToInteger(dataGridViewCell.Value);
		clsBornes.buscaTipoLm(ref iRegua, ref iLm, ref itipo);
		dataGridViewCell.Value = iRegua;
		while (true)
		{
			clsBornes.StructureBlocoBorne myBornes = default;
			if (DGReguas.SelectedRows.Count > 0)
			{
				myBornes.conector = "";
				myBornes.IndiceRegua = Conversions.ToInteger(DGReguas.SelectedRows[0].Cells[0].Value);
				myBornes.Painel = Conversions.ToString(DGReguas.SelectedRows[0].Cells[1].Value);
				myBornes.NomeRegua = Conversions.ToString(DGReguas.SelectedRows[0].Cells[3].Value);
				myBornes.LM = iLm;
				myBornes.numero = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
				myBornes.numeroComplem = "";
				myBornes.ordem = 0.0;
				myBornes.tipo = itipo;
				myBornes.Orientacao = "";
				myBornes.Layout = "";
			}
			if (DGBlocos.SelectedRows.Count > 0)
			{
				myBornes.sNomeDoBloco = Conversions.ToString(DGBlocos.SelectedRows[0].Cells[2].Value);
				myBornes.sCaminhoBloco = Conversions.ToString(DGBlocos.SelectedRows[0].Cells[1].Value);
			}
			Point3d point = new Point3d(0.0, 0.0, 0.0);
			int num = Conversions.ToInteger(TBInserir.Text);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				if (i != 1)
				{
					point = new Point3d(point.X + Conversions.ToDouble(tbDx.Text), point.Y - Conversions.ToDouble(tbDy.Text), 0.0);
					clsBornes.InserirBorne(ref myBornes, i, CkTodos.Checked, CKPainel.Checked, CKRegua.Checked, ref point);
					continue;
				}
				if (!(ckPrimeiro.Checked | ckPrimeiro.Checked))
				{
				}
				clsBornes.InserirBorne(ref myBornes, i, bPrimeiro: true, CKPainel.Checked, CKRegua.Checked, ref point);
			}
			if (((point.X == 0.0) & (point.Y == 0.0)) || Conversions.ToInteger(TBInserir.Text) != 1)
			{
				break;
			}
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		}
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		Show();
	}

	private void KUYlUkPYiR(object P_0, EventArgs P_1)
	{
		w8dpBZ0kvSD().SetToolTip(btInserirCima, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1098]));
		w8dpBZ0kvSD().SetToolTip(btInserirBaixo, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1097]));
	}

	private void W4qly1qerp(object P_0, EventArgs P_1)
	{
		w8dpBZ0kvSD().SetToolTip(btInserirCima, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1100]));
		w8dpBZ0kvSD().SetToolTip(btInserirBaixo, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1099]));
	}

	private void fLilgEnDPW(object P_0, EventArgs P_1)
	{
		DataGridView dg = DGReguas;
		clsReguasDeBornes.AtualizaColunasDGReguaDeBornes(ref dg);
		DGReguas = dg;
		dg = DGBlocos;
		OgDlnhXddC(ref dg);
		DGBlocos = dg;
	}

	private void Eu9lASo2d0(object P_0, KeyEventArgs P_1)
	{
		if (Versioned.IsNumeric(TBInserir.Text))
		{
			if (Conversions.ToInteger(TBInserir.Text) <= 1)
			{
				if (Conversions.ToInteger(TBInserir.Text) > 1)
				{
					tbDx.Enabled = true;
					tbDy.Enabled = true;
				}
				else
				{
					TBInserir.Text = "1";
					tbDx.Enabled = false;
					tbDy.Enabled = false;
				}
			}
			else
			{
				tbDx.Enabled = true;
				tbDy.Enabled = true;
			}
		}
		else
		{
			TBInserir.Text = "1";
			tbDx.Enabled = false;
			tbDy.Enabled = false;
		}
	}

	private void lDsls6uk9x(object P_0, KeyEventArgs P_1)
	{
		tbDy.Text = "0";
	}

	private void AillB2TteM(object P_0, KeyEventArgs P_1)
	{
		tbDx.Text = "0";
	}

	private void uiblVWcuXK(object P_0, MouseEventArgs P_1)
	{
		if (CKPainel.Checked)
		{
			CKRegua.Checked = true;
		}
	}

	private void CKYlu394BZ(object P_0, MouseEventArgs P_1)
	{
		if (!CKRegua.Checked)
		{
			CKPainel.Checked = false;
		}
	}

	private void qKilEDPDgY(object P_0, EventArgs P_1)
	{
		btBorneLinhaV.Visible = rbV.Checked;
		btBorneLinhaH.Visible = rbH.Checked;
		TBF.Visible = rbH.Checked;
		LBF.Visible = rbH.Checked;
	}

	private void noTlZ3fB9R(object P_0, EventArgs P_1)
	{
		btBorneLinhaV.Visible = rbV.Checked;
		btBorneLinhaH.Visible = rbH.Checked;
		TBF.Visible = rbH.Checked;
		LBF.Visible = rbH.Checked;
	}

	private void QPWli1mMjB(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void T3ylSV4fhr(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void Ec3l4p2WYm(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	public bool verificaValores()
	{
		bool result = true;
		TBI.BackColor = Color.White;
		TBI.ForeColor = Color.Black;
		TBM.BackColor = Color.White;
		TBM.ForeColor = Color.Black;
		TBF.BackColor = Color.White;
		TBF.ForeColor = Color.Black;
		if (!Versioned.IsNumeric(TBI.Text) | (Operators.CompareString(TBI.Text, "0", TextCompare: true) == 0))
		{
			TBI.BackColor = Color.Red;
			TBI.ForeColor = Color.White;
			result = false;
		}
		if (!Versioned.IsNumeric(TBM.Text) | (Operators.CompareString(TBM.Text, "0", TextCompare: true) == 0))
		{
			TBM.BackColor = Color.Red;
			TBM.ForeColor = Color.White;
			result = false;
		}
		if (!Versioned.IsNumeric(TBF.Text) | (Operators.CompareString(TBF.Text, "0", TextCompare: true) == 0))
		{
			TBF.BackColor = Color.Red;
			TBF.ForeColor = Color.White;
			result = false;
		}
		return result;
	}

	private void VThlCYnRpw(object P_0, EventArgs P_1)
	{
		verificaValores();
	}

	private void xZZlY37ybu(object P_0, EventArgs P_1)
	{
		verificaValores();
	}

	private void ubIlryIGsD(object P_0, EventArgs P_1)
	{
		verificaValores();
	}

	private void Afgl9MMyuK(object P_0, EventArgs P_1)
	{
		Hide();
		int iPainel = 0;
		int iRegua = 0;
		string sNomeBloco = "";
		checked
		{
			if (!clsBornes.SelecioanBorne(ref iPainel, ref iRegua, ref sNomeBloco))
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 100]), MsgBoxStyle.Exclamation);
				Show();
			}
			else
			{
				Show();
				int num = DGReguas.RowCount - 1;
				for (int i = 0; i <= num; i++)
				{
					DGReguas.Rows[i].Selected = false;
				}
				int num2 = DGBlocos.RowCount - 1;
				for (int j = 0; j <= num2; j++)
				{
					DGBlocos.Rows[j].Selected = false;
				}
				int num3 = DGReguas.RowCount - 1;
				for (int k = 0; k <= num3; k++)
				{
					if (Operators.ConditionalCompareObjectEqual(DGReguas.Rows[k].Cells[0].Value, iRegua, TextCompare: true))
					{
						DGReguas.Rows[k].Selected = true;
						if (k >= 3)
						{
							DGReguas.FirstDisplayedScrollingRowIndex = k - 2;
						}
						break;
					}
				}
				if (Operators.CompareString(sNomeBloco, "", TextCompare: true) != 0)
				{
					bool flag = false;
					int num4 = DGBlocos.RowCount - 1;
					for (int l = 0; l <= num4; l++)
					{
						if (DGBlocos.Rows[l].Cells[1].Value.ToString().Contains(sNomeBloco))
						{
							DGBlocos.Rows[l].Selected = true;
							IDWG.Image = RevJqj1qBkVn9MRpOU0.tiC18lyNXK(Conversions.ToString(DGBlocos.Rows[l].Cells[1].Value));
							if (l >= 3)
							{
								DGBlocos.FirstDisplayedScrollingRowIndex = l - 2;
							}
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 848]), MsgBoxStyle.Exclamation);
					}
				}
			}
			clsBlocos.Unhighlight();
		}
	}
}
