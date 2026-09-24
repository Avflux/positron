using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmEditorCabos : Form
{
	private IContainer mcj4vsn6X2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("FolderBrowser")]
	private FolderBrowserDialog nBw46gXkSy;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dg")]
	private DataGridView VUU4tl8LZZ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip GyJ4j2D6Gy;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btImportar")]
	private Button XEM4LQMEeB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExportar")]
	private Button L8i4wWxJql;

	[AccessedThroughProperty("GroupBox3")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox ncm4xqDyhR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbT1Var")]
	private TextBox xDB4bH7yQ6;

	[AccessedThroughProperty("tbT3Var")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox OyE4MXsmD6;

	[AccessedThroughProperty("tbT2Var")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox cNc4OsWYEw;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox2")]
	private GroupBox ywG4IZSjgV;

	[AccessedThroughProperty("tbP1Var")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox jn247XPGDK;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbP2Var")]
	[CompilerGenerated]
	private TextBox K4j4qT5oTG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	private GroupBox lT14arsL3V;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbBLVar")]
	private TextBox dsM48TXa5K;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("qTotal")]
	private Label w694NXJQuk;

	[AccessedThroughProperty("btEditarCabo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button ueX4Fqo0g9;

	[AccessedThroughProperty("PNEditar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Panel NSE4QpiSed;

	[CompilerGenerated]
	[AccessedThroughProperty("PNCabos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Panel KOo4PeYfg2;

	[AccessedThroughProperty("btPesquisa")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button tSF4c2kOS2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("_0cbOrigem")]
	private ComboBox Bu44K36wdV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("_1cbDestino")]
	private ComboBox ELE4eTZjGW;

	[CompilerGenerated]
	[AccessedThroughProperty("_2tbCabo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox hrC42OJSyP;

	[AccessedThroughProperty("LbCabo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label omN43WkNGr;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("lbOrigem")]
	private Label FpE4n1INy7;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("_3tbVeia")]
	private TextBox g4Y41O3bkB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbVeia")]
	private Label mYf4lCsLoH;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("_4tbSecao")]
	[CompilerGenerated]
	private TextBox QQb45cZPmh;

	[AccessedThroughProperty("lbSecao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label tdn40WY8BF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbTodos")]
	private RadioButton E4w4RZpnOl;

	[AccessedThroughProperty("rbCaderno")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton vVO4mFDtk6;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbNaoUsados")]
	[CompilerGenerated]
	private RadioButton ltC4Xl0F82;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagarCabos")]
	private Button MtH4UIROj1;

	[AccessedThroughProperty("BtEditar1Cabo")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button upW4yEFXtt;

	[AccessedThroughProperty("_6tbCabosED")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox z8R4g6JToj;

	[AccessedThroughProperty("_5cbBlinED")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ComboBox I8v4Aoepp5;

	[AccessedThroughProperty("_8tbFuncao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox lAY4s9JuSG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("_7cbAterrarED")]
	private ComboBox oU84BeGDbr;

	[AccessedThroughProperty("_9tbComprimento")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox EZc4V4vrD9;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("_10tbTrajeto")]
	private TextBox nem4uU4LY4;

	[CompilerGenerated]
	[AccessedThroughProperty("_6lbCabosED")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label egL4Eb2TaG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("_5lbBlinED")]
	private Label n8s4ZLFKuM;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("_9lbComprimento")]
	private Label A0P4iTpCvG;

	[AccessedThroughProperty("_10lbTrajeto")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label CHN4Sj3AVr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("_8lbFuncao")]
	private Label hqR44avoOl;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("_7lbAterrarED")]
	private Label Fcv4CL91Zc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ProgressBar1")]
	private ProgressBar NX04Y1wcog;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("rbTodosEdicao")]
	private RadioButton j3V4rmMiJF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btAdicionarCabo")]
	private Button Rbx49yJqmZ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbPainel")]
	private CheckBox qgs4zsc7KZ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbCabos")]
	private CheckBox oinCWtTQjJ;

	[CompilerGenerated]
	[AccessedThroughProperty("rbTrajeto")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton wPZCpfde98;

	private bool CesCTrthCe;

	private ClsCabos.StructureCabo[] LJgCJsYr89;

	private ClsCabos.StructureCabo[] NAMCha6FUY;

	private ClsCabos.StructureCabo[] eKhCoKqUTd;

	private string w8bCGslVsP;

	public List<string> lTodosCabos;

	private bool bAQCHJx81r;

	private bool v59Cksrxw0;

	internal virtual DataGridView dg
	{
		[CompilerGenerated]
		get
		{
			return VUU4tl8LZZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = KSpSC2OFfG;
			DataGridView dataGridView = VUU4tl8LZZ;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			VUU4tl8LZZ = value;
			dataGridView = VUU4tl8LZZ;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged += value2;
			}
		}
	}

	internal virtual Button btImportar
	{
		[CompilerGenerated]
		get
		{
			return XEM4LQMEeB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DiGSEbiLno;
			Button button = XEM4LQMEeB;
			if (button != null)
			{
				button.Click -= value2;
			}
			XEM4LQMEeB = value;
			button = XEM4LQMEeB;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btExportar
	{
		[CompilerGenerated]
		get
		{
			return L8i4wWxJql;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UnISuggH3Q;
			Button button = L8i4wWxJql;
			if (button != null)
			{
				button.Click -= value2;
			}
			L8i4wWxJql = value;
			button = L8i4wWxJql;
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
			return ncm4xqDyhR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ncm4xqDyhR = value;
		}
	}

	internal virtual TextBox tbT1Var
	{
		[CompilerGenerated]
		get
		{
			return xDB4bH7yQ6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			xDB4bH7yQ6 = value;
		}
	}

	internal virtual TextBox tbT3Var
	{
		[CompilerGenerated]
		get
		{
			return OyE4MXsmD6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			OyE4MXsmD6 = value;
		}
	}

	internal virtual TextBox tbT2Var
	{
		[CompilerGenerated]
		get
		{
			return cNc4OsWYEw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			cNc4OsWYEw = value;
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return ywG4IZSjgV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ywG4IZSjgV = value;
		}
	}

	internal virtual TextBox tbP1Var
	{
		[CompilerGenerated]
		get
		{
			return jn247XPGDK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jn247XPGDK = value;
		}
	}

	internal virtual TextBox tbP2Var
	{
		[CompilerGenerated]
		get
		{
			return K4j4qT5oTG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			K4j4qT5oTG = value;
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return lT14arsL3V;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			lT14arsL3V = value;
		}
	}

	internal virtual TextBox tbBLVar
	{
		[CompilerGenerated]
		get
		{
			return dsM48TXa5K;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dsM48TXa5K = value;
		}
	}

	internal virtual Label qTotal
	{
		[CompilerGenerated]
		get
		{
			return w694NXJQuk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			w694NXJQuk = value;
		}
	}

	internal virtual Button btEditarCabo
	{
		[CompilerGenerated]
		get
		{
			return ueX4Fqo0g9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PEoS4mx00G;
			Button button = ueX4Fqo0g9;
			if (button != null)
			{
				button.Click -= value2;
			}
			ueX4Fqo0g9 = value;
			button = ueX4Fqo0g9;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Panel PNEditar
	{
		[CompilerGenerated]
		get
		{
			return NSE4QpiSed;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			NSE4QpiSed = value;
		}
	}

	internal virtual Panel PNCabos
	{
		[CompilerGenerated]
		get
		{
			return KOo4PeYfg2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KOo4PeYfg2 = value;
		}
	}

	internal virtual Button btPesquisa
	{
		[CompilerGenerated]
		get
		{
			return tSF4c2kOS2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = hoySVMxDDx;
			Button button = tSF4c2kOS2;
			if (button != null)
			{
				button.Click -= value2;
			}
			tSF4c2kOS2 = value;
			button = tSF4c2kOS2;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual ComboBox _0cbOrigem
	{
		[CompilerGenerated]
		get
		{
			return Bu44K36wdV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = mWNSYsJAoC;
			ComboBox comboBox = Bu44K36wdV;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged -= value2;
			}
			Bu44K36wdV = value;
			comboBox = Bu44K36wdV;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual ComboBox _1cbDestino
	{
		[CompilerGenerated]
		get
		{
			return ELE4eTZjGW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = durSrWuNns;
			ComboBox comboBox = ELE4eTZjGW;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged -= value2;
			}
			ELE4eTZjGW = value;
			comboBox = ELE4eTZjGW;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual TextBox _2tbCabo
	{
		[CompilerGenerated]
		get
		{
			return hrC42OJSyP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = kUBS9k1kcX;
			TextBox textBox = hrC42OJSyP;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			hrC42OJSyP = value;
			textBox = hrC42OJSyP;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Label LbCabo
	{
		[CompilerGenerated]
		get
		{
			return omN43WkNGr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			omN43WkNGr = value;
		}
	}

	internal virtual Label lbOrigem
	{
		[CompilerGenerated]
		get
		{
			return FpE4n1INy7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			FpE4n1INy7 = value;
		}
	}

	internal virtual TextBox _3tbVeia
	{
		[CompilerGenerated]
		get
		{
			return g4Y41O3bkB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = PD5SzQQR22;
			TextBox textBox = g4Y41O3bkB;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			g4Y41O3bkB = value;
			textBox = g4Y41O3bkB;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Label lbVeia
	{
		[CompilerGenerated]
		get
		{
			return mYf4lCsLoH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			mYf4lCsLoH = value;
		}
	}

	internal virtual TextBox _4tbSecao
	{
		[CompilerGenerated]
		get
		{
			return QQb45cZPmh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = Xqj4W0foqh;
			TextBox textBox = QQb45cZPmh;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			QQb45cZPmh = value;
			textBox = QQb45cZPmh;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Label lbSecao
	{
		[CompilerGenerated]
		get
		{
			return tdn40WY8BF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tdn40WY8BF = value;
		}
	}

	internal virtual RadioButton rbTodos
	{
		[CompilerGenerated]
		get
		{
			return E4w4RZpnOl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = HWoSgl9XMo;
			RadioButton radioButton = E4w4RZpnOl;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			E4w4RZpnOl = value;
			radioButton = E4w4RZpnOl;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton rbCaderno
	{
		[CompilerGenerated]
		get
		{
			return vVO4mFDtk6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = riISyMYAnt;
			RadioButton radioButton = vVO4mFDtk6;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			vVO4mFDtk6 = value;
			radioButton = vVO4mFDtk6;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton rbNaoUsados
	{
		[CompilerGenerated]
		get
		{
			return ltC4Xl0F82;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = I27SsJFtcp;
			RadioButton radioButton = ltC4Xl0F82;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			ltC4Xl0F82 = value;
			radioButton = ltC4Xl0F82;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button btApagarCabos
	{
		[CompilerGenerated]
		get
		{
			return MtH4UIROj1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = PIPSBaJb6M;
			Button button = MtH4UIROj1;
			if (button != null)
			{
				button.Click -= value2;
			}
			MtH4UIROj1 = value;
			button = MtH4UIROj1;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BtEditar1Cabo
	{
		[CompilerGenerated]
		get
		{
			return upW4yEFXtt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MfUSS63wIj;
			Button button = upW4yEFXtt;
			if (button != null)
			{
				button.Click -= value2;
			}
			upW4yEFXtt = value;
			button = upW4yEFXtt;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox _6tbCabosED
	{
		[CompilerGenerated]
		get
		{
			return z8R4g6JToj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = DeY4TQOeSw;
			TextBox textBox = z8R4g6JToj;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			z8R4g6JToj = value;
			textBox = z8R4g6JToj;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual ComboBox _5cbBlinED
	{
		[CompilerGenerated]
		get
		{
			return I8v4Aoepp5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = EKX4p22PkT;
			ComboBox comboBox = I8v4Aoepp5;
			if (comboBox != null)
			{
				comboBox.TextChanged -= value2;
			}
			I8v4Aoepp5 = value;
			comboBox = I8v4Aoepp5;
			if (comboBox != null)
			{
				comboBox.TextChanged += value2;
			}
		}
	}

	internal virtual TextBox _8tbFuncao
	{
		[CompilerGenerated]
		get
		{
			return lAY4s9JuSG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = qke4hTf3Zi;
			TextBox textBox = lAY4s9JuSG;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			lAY4s9JuSG = value;
			textBox = lAY4s9JuSG;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual ComboBox _7cbAterrarED
	{
		[CompilerGenerated]
		get
		{
			return oU84BeGDbr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = xPt4JJtMAw;
			ComboBox comboBox = oU84BeGDbr;
			if (comboBox != null)
			{
				comboBox.TextChanged -= value2;
			}
			oU84BeGDbr = value;
			comboBox = oU84BeGDbr;
			if (comboBox != null)
			{
				comboBox.TextChanged += value2;
			}
		}
	}

	internal virtual TextBox _9tbComprimento
	{
		[CompilerGenerated]
		get
		{
			return EZc4V4vrD9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = qYV4oAnLNn;
			TextBox textBox = EZc4V4vrD9;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			EZc4V4vrD9 = value;
			textBox = EZc4V4vrD9;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox _10tbTrajeto
	{
		[CompilerGenerated]
		get
		{
			return nem4uU4LY4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = r814GOqhkB;
			TextBox textBox = nem4uU4LY4;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			nem4uU4LY4 = value;
			textBox = nem4uU4LY4;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Label _6lbCabosED
	{
		[CompilerGenerated]
		get
		{
			return egL4Eb2TaG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			egL4Eb2TaG = value;
		}
	}

	internal virtual Label _5lbBlinED
	{
		[CompilerGenerated]
		get
		{
			return n8s4ZLFKuM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			n8s4ZLFKuM = value;
		}
	}

	internal virtual Label _9lbComprimento
	{
		[CompilerGenerated]
		get
		{
			return A0P4iTpCvG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			A0P4iTpCvG = value;
		}
	}

	internal virtual Label _10lbTrajeto
	{
		[CompilerGenerated]
		get
		{
			return CHN4Sj3AVr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CHN4Sj3AVr = value;
		}
	}

	internal virtual Label _8lbFuncao
	{
		[CompilerGenerated]
		get
		{
			return hqR44avoOl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			hqR44avoOl = value;
		}
	}

	internal virtual Label _7lbAterrarED
	{
		[CompilerGenerated]
		get
		{
			return Fcv4CL91Zc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Fcv4CL91Zc = value;
		}
	}

	internal virtual ProgressBar ProgressBar1
	{
		[CompilerGenerated]
		get
		{
			return NX04Y1wcog;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			NX04Y1wcog = value;
		}
	}

	internal virtual RadioButton rbTodosEdicao
	{
		[CompilerGenerated]
		get
		{
			return j3V4rmMiJF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = HvXSAU64Fx;
			RadioButton radioButton = j3V4rmMiJF;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			j3V4rmMiJF = value;
			radioButton = j3V4rmMiJF;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button btAdicionarCabo
	{
		[CompilerGenerated]
		get
		{
			return Rbx49yJqmZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = y214knDCEf;
			Button button = Rbx49yJqmZ;
			if (button != null)
			{
				button.Click -= value2;
			}
			Rbx49yJqmZ = value;
			button = Rbx49yJqmZ;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox cbPainel
	{
		[CompilerGenerated]
		get
		{
			return qgs4zsc7KZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CUW4ftZTMd;
			CheckBox checkBox = qgs4zsc7KZ;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			qgs4zsc7KZ = value;
			checkBox = qgs4zsc7KZ;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox cbCabos
	{
		[CompilerGenerated]
		get
		{
			return oinCWtTQjJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = GID4dAURpG;
			CheckBox checkBox = oinCWtTQjJ;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			oinCWtTQjJ = value;
			checkBox = oinCWtTQjJ;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton rbTrajeto
	{
		[CompilerGenerated]
		get
		{
			return wPZCpfde98;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = xA74DB8MfS;
			RadioButton radioButton = wPZCpfde98;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			wPZCpfde98 = value;
			radioButton = wPZCpfde98;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && mcj4vsn6X2 != null)
			{
				mcj4vsn6X2.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void vpSSne1lBn()
	{
		mcj4vsn6X2 = new Container();
		aHypBEW66iS(new FolderBrowserDialog());
		dg = new DataGridView();
		FDqpBiUmZij(new ToolTip(mcj4vsn6X2));
		btImportar = new Button();
		btExportar = new Button();
		GroupBox3 = new GroupBox();
		tbT1Var = new TextBox();
		tbT3Var = new TextBox();
		tbT2Var = new TextBox();
		GroupBox2 = new GroupBox();
		tbP1Var = new TextBox();
		tbP2Var = new TextBox();
		GroupBox1 = new GroupBox();
		tbBLVar = new TextBox();
		qTotal = new Label();
		btEditarCabo = new Button();
		PNEditar = new Panel();
		_8lbFuncao = new Label();
		_7lbAterrarED = new Label();
		_6lbCabosED = new Label();
		_5lbBlinED = new Label();
		_9lbComprimento = new Label();
		_10lbTrajeto = new Label();
		_5cbBlinED = new ComboBox();
		_6tbCabosED = new TextBox();
		_10tbTrajeto = new TextBox();
		_8tbFuncao = new TextBox();
		_9tbComprimento = new TextBox();
		_7cbAterrarED = new ComboBox();
		PNCabos = new Panel();
		rbTrajeto = new RadioButton();
		btAdicionarCabo = new Button();
		cbPainel = new CheckBox();
		cbCabos = new CheckBox();
		rbCaderno = new RadioButton();
		btPesquisa = new Button();
		_0cbOrigem = new ComboBox();
		BtEditar1Cabo = new Button();
		_1cbDestino = new ComboBox();
		btApagarCabos = new Button();
		_2tbCabo = new TextBox();
		LbCabo = new Label();
		rbNaoUsados = new RadioButton();
		lbOrigem = new Label();
		_3tbVeia = new TextBox();
		rbTodosEdicao = new RadioButton();
		rbTodos = new RadioButton();
		lbVeia = new Label();
		_4tbSecao = new TextBox();
		lbSecao = new Label();
		ProgressBar1 = new ProgressBar();
		((ISupportInitialize)dg).BeginInit();
		GroupBox3.SuspendLayout();
		GroupBox2.SuspendLayout();
		GroupBox1.SuspendLayout();
		PNEditar.SuspendLayout();
		PNCabos.SuspendLayout();
		SuspendLayout();
		dg.AllowUserToAddRows = false;
		dg.AllowUserToDeleteRows = false;
		dg.AllowUserToOrderColumns = true;
		dg.AllowUserToResizeRows = false;
		dg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dg.BackgroundColor = SystemColors.ButtonHighlight;
		dg.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
		dg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dg.Location = new Point(12, 12);
		dg.Name = "dg";
		dg.ReadOnly = true;
		dg.RowHeadersVisible = false;
		dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dg.Size = new Size(890, 201);
		dg.TabIndex = 117;
		btImportar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btImportar.FlatStyle = FlatStyle.Flat;
		btImportar.ForeColor = SystemColors.Control;
		btImportar.Image = Resources.ImportaExcel_20;
		btImportar.Location = new Point(955, 282);
		btImportar.Name = "btImportar";
		btImportar.Size = new Size(40, 40);
		btImportar.TabIndex = 144;
		btImportar.UseVisualStyleBackColor = true;
		btExportar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btExportar.FlatStyle = FlatStyle.Flat;
		btExportar.ForeColor = SystemColors.Control;
		btExportar.Image = Resources.ExportaExcel_20;
		btExportar.Location = new Point(909, 282);
		btExportar.Name = "btExportar";
		btExportar.Size = new Size(40, 40);
		btExportar.TabIndex = 145;
		btExportar.UseVisualStyleBackColor = true;
		GroupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		GroupBox3.Controls.Add(tbT1Var);
		GroupBox3.Controls.Add(tbT3Var);
		GroupBox3.Controls.Add(tbT2Var);
		GroupBox3.Location = new Point(907, 132);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(85, 105);
		GroupBox3.TabIndex = 177;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "BL";
		tbT1Var.Location = new Point(11, 19);
		tbT1Var.Name = "tbT1Var";
		tbT1Var.Size = new Size(68, 20);
		tbT1Var.TabIndex = 13;
		tbT3Var.Location = new Point(11, 71);
		tbT3Var.Name = "tbT3Var";
		tbT3Var.Size = new Size(68, 20);
		tbT3Var.TabIndex = 12;
		tbT2Var.Location = new Point(11, 45);
		tbT2Var.Name = "tbT2Var";
		tbT2Var.Size = new Size(68, 20);
		tbT2Var.TabIndex = 11;
		GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		GroupBox2.Controls.Add(tbP1Var);
		GroupBox2.Controls.Add(tbP2Var);
		GroupBox2.Location = new Point(907, 55);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(85, 78);
		GroupBox2.TabIndex = 176;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "BL";
		tbP1Var.Location = new Point(10, 19);
		tbP1Var.Name = "tbP1Var";
		tbP1Var.Size = new Size(68, 20);
		tbP1Var.TabIndex = 1;
		tbP2Var.Location = new Point(10, 45);
		tbP2Var.Name = "tbP2Var";
		tbP2Var.Size = new Size(68, 20);
		tbP2Var.TabIndex = 4;
		GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		GroupBox1.Controls.Add(tbBLVar);
		GroupBox1.Location = new Point(907, 6);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(85, 49);
		GroupBox1.TabIndex = 175;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "BL";
		tbBLVar.Location = new Point(10, 19);
		tbBLVar.Name = "tbBLVar";
		tbBLVar.Size = new Size(68, 20);
		tbBLVar.TabIndex = 0;
		qTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		qTotal.BorderStyle = BorderStyle.Fixed3D;
		qTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, 0);
		qTotal.Location = new Point(907, 244);
		qTotal.Name = "qTotal";
		qTotal.Size = new Size(85, 30);
		qTotal.TabIndex = 181;
		qTotal.Text = "Total";
		qTotal.TextAlign = ContentAlignment.MiddleRight;
		btEditarCabo.Enabled = false;
		btEditarCabo.FlatStyle = FlatStyle.Flat;
		btEditarCabo.ForeColor = SystemColors.Control;
		btEditarCabo.Image = Resources.Editar;
		btEditarCabo.Location = new Point(846, 60);
		btEditarCabo.Name = "btEditarCabo";
		btEditarCabo.Size = new Size(40, 40);
		btEditarCabo.TabIndex = 184;
		btEditarCabo.UseVisualStyleBackColor = true;
		PNEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		PNEditar.Controls.Add(_8lbFuncao);
		PNEditar.Controls.Add(_7lbAterrarED);
		PNEditar.Controls.Add(_6lbCabosED);
		PNEditar.Controls.Add(_5lbBlinED);
		PNEditar.Controls.Add(_9lbComprimento);
		PNEditar.Controls.Add(_10lbTrajeto);
		PNEditar.Controls.Add(_5cbBlinED);
		PNEditar.Controls.Add(_6tbCabosED);
		PNEditar.Controls.Add(_10tbTrajeto);
		PNEditar.Controls.Add(_8tbFuncao);
		PNEditar.Controls.Add(_9tbComprimento);
		PNEditar.Controls.Add(_7cbAterrarED);
		PNEditar.Location = new Point(12, 332);
		PNEditar.Name = "PNEditar";
		PNEditar.Size = new Size(891, 53);
		PNEditar.TabIndex = 196;
		_8lbFuncao.BorderStyle = BorderStyle.Fixed3D;
		_8lbFuncao.Location = new Point(179, 3);
		_8lbFuncao.Name = "_8lbFuncao";
		_8lbFuncao.Size = new Size(229, 20);
		_8lbFuncao.TabIndex = 201;
		_8lbFuncao.Text = "Função";
		_8lbFuncao.TextAlign = ContentAlignment.MiddleCenter;
		_7lbAterrarED.BorderStyle = BorderStyle.Fixed3D;
		_7lbAterrarED.Location = new Point(115, 3);
		_7lbAterrarED.Name = "_7lbAterrarED";
		_7lbAterrarED.Size = new Size(58, 20);
		_7lbAterrarED.TabIndex = 200;
		_7lbAterrarED.Text = "Aterrar";
		_7lbAterrarED.TextAlign = ContentAlignment.MiddleCenter;
		_6lbCabosED.BorderStyle = BorderStyle.Fixed3D;
		_6lbCabosED.Location = new Point(69, 3);
		_6lbCabosED.Name = "_6lbCabosED";
		_6lbCabosED.Size = new Size(40, 20);
		_6lbCabosED.TabIndex = 196;
		_6lbCabosED.Text = "Cabos";
		_6lbCabosED.TextAlign = ContentAlignment.MiddleCenter;
		_5lbBlinED.BorderStyle = BorderStyle.Fixed3D;
		_5lbBlinED.Location = new Point(3, 3);
		_5lbBlinED.Name = "_5lbBlinED";
		_5lbBlinED.Size = new Size(60, 20);
		_5lbBlinED.TabIndex = 197;
		_5lbBlinED.Text = "Blindagem";
		_5lbBlinED.TextAlign = ContentAlignment.MiddleCenter;
		_9lbComprimento.BorderStyle = BorderStyle.Fixed3D;
		_9lbComprimento.Location = new Point(414, 3);
		_9lbComprimento.Name = "_9lbComprimento";
		_9lbComprimento.Size = new Size(82, 20);
		_9lbComprimento.TabIndex = 198;
		_9lbComprimento.Text = "Comprimento";
		_9lbComprimento.TextAlign = ContentAlignment.MiddleCenter;
		_10lbTrajeto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		_10lbTrajeto.BorderStyle = BorderStyle.Fixed3D;
		_10lbTrajeto.Location = new Point(502, 3);
		_10lbTrajeto.Name = "_10lbTrajeto";
		_10lbTrajeto.Size = new Size(386, 20);
		_10lbTrajeto.TabIndex = 199;
		_10lbTrajeto.Text = "Trajeto";
		_10lbTrajeto.TextAlign = ContentAlignment.MiddleCenter;
		_5cbBlinED.FormattingEnabled = true;
		_5cbBlinED.Location = new Point(3, 25);
		_5cbBlinED.Name = "_5cbBlinED";
		_5cbBlinED.Size = new Size(60, 21);
		_5cbBlinED.TabIndex = 191;
		_6tbCabosED.Location = new Point(71, 26);
		_6tbCabosED.Name = "_6tbCabosED";
		_6tbCabosED.Size = new Size(40, 20);
		_6tbCabosED.TabIndex = 190;
		_10tbTrajeto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		_10tbTrajeto.Location = new Point(502, 26);
		_10tbTrajeto.Name = "_10tbTrajeto";
		_10tbTrajeto.Size = new Size(386, 20);
		_10tbTrajeto.TabIndex = 195;
		_8tbFuncao.Location = new Point(179, 26);
		_8tbFuncao.Name = "_8tbFuncao";
		_8tbFuncao.Size = new Size(229, 20);
		_8tbFuncao.TabIndex = 192;
		_9tbComprimento.Location = new Point(414, 25);
		_9tbComprimento.Name = "_9tbComprimento";
		_9tbComprimento.Size = new Size(82, 20);
		_9tbComprimento.TabIndex = 194;
		_7cbAterrarED.FormattingEnabled = true;
		_7cbAterrarED.Location = new Point(115, 25);
		_7cbAterrarED.Name = "_7cbAterrarED";
		_7cbAterrarED.Size = new Size(58, 21);
		_7cbAterrarED.TabIndex = 193;
		PNCabos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		PNCabos.Controls.Add(rbTrajeto);
		PNCabos.Controls.Add(btAdicionarCabo);
		PNCabos.Controls.Add(cbPainel);
		PNCabos.Controls.Add(cbCabos);
		PNCabos.Controls.Add(btEditarCabo);
		PNCabos.Controls.Add(rbCaderno);
		PNCabos.Controls.Add(btPesquisa);
		PNCabos.Controls.Add(_0cbOrigem);
		PNCabos.Controls.Add(BtEditar1Cabo);
		PNCabos.Controls.Add(_1cbDestino);
		PNCabos.Controls.Add(btApagarCabos);
		PNCabos.Controls.Add(_2tbCabo);
		PNCabos.Controls.Add(LbCabo);
		PNCabos.Controls.Add(rbNaoUsados);
		PNCabos.Controls.Add(lbOrigem);
		PNCabos.Controls.Add(_3tbVeia);
		PNCabos.Controls.Add(rbTodosEdicao);
		PNCabos.Controls.Add(rbTodos);
		PNCabos.Controls.Add(lbVeia);
		PNCabos.Controls.Add(_4tbSecao);
		PNCabos.Controls.Add(lbSecao);
		PNCabos.Location = new Point(12, 221);
		PNCabos.Name = "PNCabos";
		PNCabos.Size = new Size(891, 105);
		PNCabos.TabIndex = 197;
		rbTrajeto.AutoSize = true;
		rbTrajeto.Location = new Point(374, 31);
		rbTrajeto.Name = "rbTrajeto";
		rbTrajeto.Size = new Size(67, 17);
		rbTrajeto.TabIndex = 200;
		rbTrajeto.Text = "rbTrajeto";
		rbTrajeto.UseVisualStyleBackColor = true;
		btAdicionarCabo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btAdicionarCabo.FlatStyle = FlatStyle.Flat;
		btAdicionarCabo.ForeColor = SystemColors.Control;
		btAdicionarCabo.Image = Resources.Adiciona_32;
		btAdicionarCabo.Location = new Point(800, 60);
		btAdicionarCabo.Name = "btAdicionarCabo";
		btAdicionarCabo.Size = new Size(40, 40);
		btAdicionarCabo.TabIndex = 199;
		btAdicionarCabo.UseVisualStyleBackColor = true;
		cbPainel.AutoSize = true;
		cbPainel.Location = new Point(734, 23);
		cbPainel.Name = "cbPainel";
		cbPainel.Size = new Size(106, 17);
		cbPainel.TabIndex = 185;
		cbPainel.Text = "cbOrdem Paineis";
		cbPainel.UseVisualStyleBackColor = true;
		cbCabos.AutoSize = true;
		cbCabos.Checked = true;
		cbCabos.CheckState = CheckState.Checked;
		cbCabos.Location = new Point(734, 8);
		cbCabos.Name = "cbCabos";
		cbCabos.Size = new Size(102, 17);
		cbCabos.TabIndex = 184;
		cbCabos.Text = "cbOrdem Cabos";
		cbCabos.UseVisualStyleBackColor = true;
		rbCaderno.AutoSize = true;
		rbCaderno.Location = new Point(3, 8);
		rbCaderno.Name = "rbCaderno";
		rbCaderno.Size = new Size(74, 17);
		rbCaderno.TabIndex = 179;
		rbCaderno.Text = "rbCaderno";
		rbCaderno.UseVisualStyleBackColor = true;
		btPesquisa.FlatStyle = FlatStyle.Flat;
		btPesquisa.ForeColor = SystemColors.Control;
		btPesquisa.Image = Resources.Pesquisar_32;
		btPesquisa.Location = new Point(670, 60);
		btPesquisa.Name = "btPesquisa";
		btPesquisa.Size = new Size(40, 40);
		btPesquisa.TabIndex = 146;
		btPesquisa.UseVisualStyleBackColor = true;
		_0cbOrigem.FormattingEnabled = true;
		_0cbOrigem.Location = new Point(5, 81);
		_0cbOrigem.Name = "_0cbOrigem";
		_0cbOrigem.Size = new Size(172, 21);
		_0cbOrigem.TabIndex = 147;
		BtEditar1Cabo.Enabled = false;
		BtEditar1Cabo.FlatStyle = FlatStyle.Flat;
		BtEditar1Cabo.ForeColor = SystemColors.Control;
		BtEditar1Cabo.Image = Resources.Select_32;
		BtEditar1Cabo.Location = new Point(758, 60);
		BtEditar1Cabo.Name = "BtEditar1Cabo";
		BtEditar1Cabo.Size = new Size(40, 40);
		BtEditar1Cabo.TabIndex = 183;
		BtEditar1Cabo.UseVisualStyleBackColor = true;
		_1cbDestino.FormattingEnabled = true;
		_1cbDestino.Location = new Point(189, 81);
		_1cbDestino.Name = "_1cbDestino";
		_1cbDestino.Size = new Size(172, 21);
		_1cbDestino.TabIndex = 148;
		btApagarCabos.Enabled = false;
		btApagarCabos.FlatStyle = FlatStyle.Flat;
		btApagarCabos.ForeColor = SystemColors.Control;
		btApagarCabos.Image = Resources.Delete_32;
		btApagarCabos.Location = new Point(714, 60);
		btApagarCabos.Name = "btApagarCabos";
		btApagarCabos.Size = new Size(40, 40);
		btApagarCabos.TabIndex = 182;
		btApagarCabos.UseVisualStyleBackColor = true;
		_2tbCabo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		_2tbCabo.Location = new Point(374, 81);
		_2tbCabo.Name = "_2tbCabo";
		_2tbCabo.Size = new Size(131, 20);
		_2tbCabo.TabIndex = 149;
		LbCabo.BorderStyle = BorderStyle.Fixed3D;
		LbCabo.Location = new Point(374, 58);
		LbCabo.Name = "LbCabo";
		LbCabo.Size = new Size(131, 20);
		LbCabo.TabIndex = 168;
		LbCabo.Text = "lbCabo";
		LbCabo.TextAlign = ContentAlignment.MiddleCenter;
		rbNaoUsados.AutoSize = true;
		rbNaoUsados.Location = new Point(374, 8);
		rbNaoUsados.Name = "rbNaoUsados";
		rbNaoUsados.Size = new Size(90, 17);
		rbNaoUsados.TabIndex = 180;
		rbNaoUsados.Text = "rbNaoUsados";
		rbNaoUsados.UseVisualStyleBackColor = true;
		lbOrigem.BorderStyle = BorderStyle.Fixed3D;
		lbOrigem.Location = new Point(5, 58);
		lbOrigem.Name = "lbOrigem";
		lbOrigem.Size = new Size(358, 20);
		lbOrigem.TabIndex = 169;
		lbOrigem.Text = "lbOrigem";
		lbOrigem.TextAlign = ContentAlignment.MiddleCenter;
		_3tbVeia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		_3tbVeia.Location = new Point(510, 81);
		_3tbVeia.Name = "_3tbVeia";
		_3tbVeia.Size = new Size(63, 20);
		_3tbVeia.TabIndex = 171;
		rbTodosEdicao.AutoSize = true;
		rbTodosEdicao.Location = new Point(3, 31);
		rbTodosEdicao.Name = "rbTodosEdicao";
		rbTodosEdicao.Size = new Size(200, 17);
		rbTodosEdicao.TabIndex = 178;
		rbTodosEdicao.Text = "Cabos Função, Comprimento, Trajeto";
		rbTodosEdicao.UseVisualStyleBackColor = true;
		rbTodos.AutoSize = true;
		rbTodos.Location = new Point(205, 8);
		rbTodos.Name = "rbTodos";
		rbTodos.Size = new Size(64, 17);
		rbTodos.TabIndex = 178;
		rbTodos.Text = "rbTodos";
		rbTodos.UseVisualStyleBackColor = true;
		lbVeia.BorderStyle = BorderStyle.Fixed3D;
		lbVeia.Location = new Point(510, 58);
		lbVeia.Name = "lbVeia";
		lbVeia.Size = new Size(63, 20);
		lbVeia.TabIndex = 172;
		lbVeia.Text = "lbVeia";
		lbVeia.TextAlign = ContentAlignment.MiddleCenter;
		_4tbSecao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		_4tbSecao.Location = new Point(580, 81);
		_4tbSecao.Name = "_4tbSecao";
		_4tbSecao.Size = new Size(85, 20);
		_4tbSecao.TabIndex = 173;
		lbSecao.BorderStyle = BorderStyle.Fixed3D;
		lbSecao.Location = new Point(580, 58);
		lbSecao.Name = "lbSecao";
		lbSecao.Size = new Size(85, 20);
		lbSecao.TabIndex = 174;
		lbSecao.Text = "lbSeção";
		lbSecao.TextAlign = ContentAlignment.MiddleCenter;
		ProgressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		ProgressBar1.Location = new Point(9, 379);
		ProgressBar1.Name = "ProgressBar1";
		ProgressBar1.Size = new Size(987, 8);
		ProgressBar1.TabIndex = 198;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(1004, 391);
		Controls.Add(ProgressBar1);
		Controls.Add(PNCabos);
		Controls.Add(PNEditar);
		Controls.Add(qTotal);
		Controls.Add(GroupBox3);
		Controls.Add(GroupBox2);
		Controls.Add(GroupBox1);
		Controls.Add(btExportar);
		Controls.Add(dg);
		Controls.Add(btImportar);
		ImeMode = ImeMode.On;
		MinimumSize = new Size(1020, 430);
		Name = "frmEditorCabos";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Editor de Cabos";
		((ISupportInitialize)dg).EndInit();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox3.PerformLayout();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		PNEditar.ResumeLayout(performLayout: false);
		PNEditar.PerformLayout();
		PNCabos.ResumeLayout(performLayout: false);
		PNCabos.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual FolderBrowserDialog I8spBuIa499()
	{
		return nBw46gXkSy;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void aHypBEW66iS(FolderBrowserDialog WithEventsValue)
	{
		nBw46gXkSy = WithEventsValue;
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return GyJ4j2D6Gy;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		GyJ4j2D6Gy = WithEventsValue;
	}

	public frmEditorCabos()
	{
		Resize += t2QSiXfh75;
		CesCTrthCe = false;
		w8bCGslVsP = "T";
		bAQCHJx81r = false;
		v59Cksrxw0 = false;
		if (!Geral.ExisteForm("frmEditorCabos"))
		{
			vpSSne1lBn();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 571]);
			w8dpBZ0kvSD().SetToolTip(btExportar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1168]));
			w8dpBZ0kvSD().SetToolTip(btImportar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1167]));
			GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1232]);
			GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1233]);
			GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1234]);
			tbBLVar.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1232]);
			tbP1Var.Text = "P1";
			tbP2Var.Text = "P2";
			tbT1Var.Text = "T1";
			tbT2Var.Text = "T2";
			tbT3Var.Text = "T3";
			rbCaderno.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1278]);
			rbTodos.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1279]);
			rbNaoUsados.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1280]);
			rbTodosEdicao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1622]);
			rbTrajeto.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1920]);
			LbCabo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1238]);
			lbVeia.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1239]);
			lbSecao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1240]);
			lbOrigem.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1342]);
			cbCabos.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1082], " "), DeclaracoesGeral.mMensagem[1, 514]));
			cbPainel.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1082], " "), DeclaracoesGeral.mMensagem[1, 1085]));
			ProgressBar1.Visible = false;
			_5lbBlinED.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 565]);
			_6lbCabosED.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 514]);
			_7lbAterrarED.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1243]);
			_8lbFuncao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1244]);
			_9lbComprimento.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1246]);
			_10lbTrajeto.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1413]);
			cDadosAccess.carregaDadosDWG();
			_0cbOrigem.Items.Clear();
			_1cbDestino.Items.Clear();
			List<int> lPaineis = new List<int>();
			CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
			cDadosAccessInterligacao3.LeTodosOsPaineisDosCabos(ref lPaineis);
			c01SZbL8qH(ref cDadosAccessInterligacao3);
			cDadosAccessInterligacao3.FechaConexao();
			new List<string>();
			_5cbBlinED.Items.Clear();
			_5cbBlinED.Items.Add(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 19]));
			_5cbBlinED.Items.Add(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 20]));
			_7cbAterrarED.Items.Clear();
			_7cbAterrarED.Items.Add(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 20]));
			_7cbAterrarED.Items.Add(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 429]));
			_7cbAterrarED.Items.Add(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 432]));
			_7cbAterrarED.Items.Add(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1639]));
			Application.ShowModelessDialog((Form)this);
			btExportar.Enabled = true;
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
			CesCTrthCe = true;
			rbCaderno.Checked = true;
			btExportar.Enabled = true;
		}
	}

	private void fQUS1Lru29()
	{
		btImportar.Enabled = false;
		btExportar.Enabled = false;
		dg.Rows.Clear();
		dg.Columns.Clear();
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1241]));
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1242]));
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1238]));
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1244]));
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1246]));
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1248]));
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1797]));
		checked
		{
			int num = dg.Columns.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				dg.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
			}
			XGCSmtbA74();
		}
	}

	private void zIVSlCQ5BM()
	{
		btImportar.Enabled = false;
		btExportar.Enabled = false;
		dg.Rows.Clear();
		dg.Columns.Clear();
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1241]));
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1242]));
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1246]));
		checked
		{
			int num = dg.Columns.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				dg.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
			}
			CjCSU6YKvS();
		}
	}

	private void l4hS5TA0OG()
	{
		btImportar.Enabled = false;
		btExportar.Enabled = false;
		dg.Rows.Clear();
		dg.Columns.Clear();
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 429]));
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 432]));
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1238]));
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1239]));
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1240]));
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 565]));
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 514]));
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1243]));
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1244]));
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1246]));
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1248]));
		dg.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1797]));
		checked
		{
			int num = dg.Columns.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				dg.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
			}
			ldxSXYamjb();
		}
	}

	private void O0lS0GAYkY(string P_0, string P_1, string P_2, string P_3, string P_4, string P_5)
	{
		checked
		{
			try
			{
				string text = "";
				string text2 = "";
				string text3 = "";
				string text4 = "";
				int num = 0;
				bool flag = true;
				if (Operators.CompareString(P_5, "J", TextCompare: true) != 0)
				{
					if (Operators.CompareString(P_5, "P", TextCompare: true) != 0)
					{
						if (Operators.CompareString(P_5, "T", TextCompare: true) != 0)
						{
							if (Operators.CompareString(P_5, "C", TextCompare: true) != 0)
							{
								if (Operators.CompareString(P_5, "N", TextCompare: true) == 0 && !Information.IsNothing(NAMCha6FUY))
								{
									DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(NAMCha6FUY);
									DeclaracoesGeral._uscPagina.pbIniciar();
									int num2 = Information.UBound(NAMCha6FUY);
									for (int i = 1; i <= num2; i++)
									{
										flag = false;
										ksjSR3fFNH(NAMCha6FUY[i].sFormacao, NAMCha6FUY[i].iCabos, ref text, ref text2);
										text3 = Dicionario.BuscaNomeDoPainel(NAMCha6FUY[i].iPn1);
										text4 = Dicionario.BuscaNomeDoPainel(NAMCha6FUY[i].iPn2);
										num = 0;
										if (NAMCha6FUY[i].bBlindagem)
										{
											num = 1;
										}
										bool flag2 = true;
										P_3 = P_3.ToString().ToUpper();
										P_4 = P_4.ToString().ToUpper();
										if ((Dicionario.BuscaIndiceDoPainel(P_3) == 0) | (Operators.CompareString(P_3, "", TextCompare: true) == 0))
										{
											flag2 = false;
										}
										if ((Dicionario.BuscaIndiceDoPainel(P_4) == 0) | (Operators.CompareString(P_4, "", TextCompare: true) == 0))
										{
											flag2 = false;
										}
										if (((Operators.CompareString(P_3, "", TextCompare: true) != 0) & (Operators.CompareString(P_4, "", TextCompare: true) != 0)) && (((Operators.CompareString(text3.ToUpper(), P_3.ToUpper(), TextCompare: true) == 0) & (Operators.CompareString(text4.ToUpper(), P_4.ToUpper(), TextCompare: true) == 0)) | ((Operators.CompareString(text4.ToUpper(), P_3.ToUpper(), TextCompare: true) == 0) & (Operators.CompareString(text3.ToUpper(), P_4.ToUpper(), TextCompare: true) == 0))))
										{
											flag = true;
										}
										if (!flag & !flag2)
										{
											if (!((Operators.CompareString(P_3, "", TextCompare: true) != 0) & (Operators.CompareString(P_4, "", TextCompare: true) != 0)))
											{
												if (Operators.CompareString(P_3, "", TextCompare: true) != 0 && (LikeOperator.LikeString(text3.ToUpper(), "*" + P_3.ToUpper() + "*", CompareMethod.Text) | LikeOperator.LikeString(text4.ToUpper(), "*" + P_3.ToUpper() + "*", CompareMethod.Text)))
												{
													flag = true;
												}
												if (Operators.CompareString(P_4, "", TextCompare: true) != 0 && (LikeOperator.LikeString(text3.ToUpper(), "*" + P_4.ToUpper() + "*", CompareMethod.Text) | LikeOperator.LikeString(text4.ToUpper(), "*" + P_4.ToUpper() + "*", CompareMethod.Text)))
												{
													flag = true;
												}
											}
											else if (LikeOperator.LikeString(text3.ToUpper(), "*" + P_3.ToUpper() + "*", CompareMethod.Text) | LikeOperator.LikeString(text4.ToUpper(), "*" + P_4.ToUpper() + "*", CompareMethod.Text) | LikeOperator.LikeString(text4.ToUpper(), "*" + P_3.ToUpper() + "*", CompareMethod.Text) | LikeOperator.LikeString(text3.ToUpper(), "*" + P_4.ToUpper() + "*", CompareMethod.Text))
											{
												flag = true;
											}
											if ((Operators.CompareString(P_3, "", TextCompare: true) == 0) & (Operators.CompareString(P_4, "", TextCompare: true) == 0))
											{
												flag = true;
											}
										}
										if (flag)
										{
											if (!LikeOperator.LikeString(NAMCha6FUY[i].sTag.ToString().ToUpper(), "*" + P_0.ToUpper() + "*", CompareMethod.Text))
											{
												flag = false;
											}
											else if (!LikeOperator.LikeString(text.ToString().ToUpper(), "*" + P_1.ToUpper() + "*", CompareMethod.Text))
											{
												flag = false;
											}
											else if (!LikeOperator.LikeString(text2.ToString().ToUpper(), "*" + P_2.ToUpper() + "*", CompareMethod.Text))
											{
												flag = false;
											}
										}
										if (flag)
										{
											dg.Rows.Add(text3, text4, NAMCha6FUY[i].sTag, text, text2, num, NAMCha6FUY[i].iCabos, NAMCha6FUY[i].iAterrar, NAMCha6FUY[i].sFuncao, NAMCha6FUY[i].dComprimento, NAMCha6FUY[i].sTrajeto, clsTextos.TiraNothing(NAMCha6FUY[i].sInstrucao));
										}
										DeclaracoesGeral._uscPagina.pbPasso();
									}
									DeclaracoesGeral._uscPagina.pbFim();
									ldxSXYamjb();
									if (cbCabos.Checked)
									{
										DataGridViewColumn dataGridViewColumn = dg.Columns[2];
										dg.Sort(dataGridViewColumn, ListSortDirection.Ascending);
									}
								}
							}
							else if (!Information.IsNothing(eKhCoKqUTd))
							{
								DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(eKhCoKqUTd);
								DeclaracoesGeral._uscPagina.pbIniciar();
								int num3 = Information.UBound(eKhCoKqUTd);
								for (int j = 1; j <= num3; j++)
								{
									flag = false;
									ksjSR3fFNH(eKhCoKqUTd[j].sFormacao, eKhCoKqUTd[j].iCabos, ref text, ref text2);
									text3 = Dicionario.BuscaNomeDoPainel(eKhCoKqUTd[j].iPn1);
									text4 = Dicionario.BuscaNomeDoPainel(eKhCoKqUTd[j].iPn2);
									num = 0;
									if (eKhCoKqUTd[j].bBlindagem)
									{
										num = 1;
									}
									bool flag3 = true;
									P_3 = P_3.ToString().ToUpper();
									P_4 = P_4.ToString().ToUpper();
									if ((Dicionario.BuscaIndiceDoPainel(P_3) == 0) | (Operators.CompareString(P_3, "", TextCompare: true) == 0))
									{
										flag3 = false;
									}
									if ((Dicionario.BuscaIndiceDoPainel(P_4) == 0) | (Operators.CompareString(P_4, "", TextCompare: true) == 0))
									{
										flag3 = false;
									}
									if (((Operators.CompareString(P_3, "", TextCompare: true) != 0) & (Operators.CompareString(P_4, "", TextCompare: true) != 0)) && (((Operators.CompareString(text3.ToUpper(), P_3.ToUpper(), TextCompare: true) == 0) & (Operators.CompareString(text4.ToUpper(), P_4.ToUpper(), TextCompare: true) == 0)) | ((Operators.CompareString(text4.ToUpper(), P_3.ToUpper(), TextCompare: true) == 0) & (Operators.CompareString(text3.ToUpper(), P_4.ToUpper(), TextCompare: true) == 0))))
									{
										flag = true;
									}
									if (!flag & !flag3)
									{
										if (!((Operators.CompareString(P_3, "", TextCompare: true) != 0) & (Operators.CompareString(P_4, "", TextCompare: true) != 0)))
										{
											if (Operators.CompareString(P_3, "", TextCompare: true) != 0 && (LikeOperator.LikeString(text3.ToUpper(), "*" + P_3.ToUpper() + "*", CompareMethod.Text) | LikeOperator.LikeString(text4.ToUpper(), "*" + P_3.ToUpper() + "*", CompareMethod.Text)))
											{
												flag = true;
											}
											if (Operators.CompareString(P_4, "", TextCompare: true) != 0 && (LikeOperator.LikeString(text3.ToUpper(), "*" + P_4.ToUpper() + "*", CompareMethod.Text) | LikeOperator.LikeString(text4.ToUpper(), "*" + P_4.ToUpper() + "*", CompareMethod.Text)))
											{
												flag = true;
											}
										}
										else if (LikeOperator.LikeString(text3.ToUpper(), "*" + P_3.ToUpper() + "*", CompareMethod.Text) | LikeOperator.LikeString(text4.ToUpper(), "*" + P_4.ToUpper() + "*", CompareMethod.Text) | LikeOperator.LikeString(text4.ToUpper(), "*" + P_3.ToUpper() + "*", CompareMethod.Text) | LikeOperator.LikeString(text3.ToUpper(), "*" + P_4.ToUpper() + "*", CompareMethod.Text))
										{
											flag = true;
										}
										if ((Operators.CompareString(P_3, "", TextCompare: true) == 0) & (Operators.CompareString(P_4, "", TextCompare: true) == 0))
										{
											flag = true;
										}
									}
									if (flag)
									{
										if (!LikeOperator.LikeString(eKhCoKqUTd[j].sTag.ToString().ToUpper(), "*" + P_0.ToUpper() + "*", CompareMethod.Text))
										{
											flag = false;
										}
										else if (!LikeOperator.LikeString(text.ToString().ToUpper(), "*" + P_1.ToUpper() + "*", CompareMethod.Text))
										{
											flag = false;
										}
										else if (!LikeOperator.LikeString(text2.ToString().ToUpper(), "*" + P_2.ToUpper() + "*", CompareMethod.Text))
										{
											flag = false;
										}
									}
									if (flag)
									{
										dg.Rows.Add(text3, text4, eKhCoKqUTd[j].sTag, text, text2, num, eKhCoKqUTd[j].iCabos, eKhCoKqUTd[j].iAterrar, eKhCoKqUTd[j].sFuncao, eKhCoKqUTd[j].dComprimento, eKhCoKqUTd[j].sTrajeto, clsTextos.TiraNothing(eKhCoKqUTd[j].sInstrucao));
									}
									DeclaracoesGeral._uscPagina.pbPasso();
								}
								DeclaracoesGeral._uscPagina.pbFim();
								ldxSXYamjb();
								if (cbCabos.Checked)
								{
									DataGridViewColumn dataGridViewColumn2 = dg.Columns[2];
									dg.Sort(dataGridViewColumn2, ListSortDirection.Ascending);
								}
							}
						}
						else if (!Information.IsNothing(LJgCJsYr89))
						{
							DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(LJgCJsYr89);
							DeclaracoesGeral._uscPagina.pbIniciar();
							int num4 = Information.UBound(LJgCJsYr89);
							for (int k = 1; k <= num4; k++)
							{
								flag = false;
								ksjSR3fFNH(LJgCJsYr89[k].sFormacao, LJgCJsYr89[k].iCabos, ref text, ref text2);
								text3 = Dicionario.BuscaNomeDoPainel(LJgCJsYr89[k].iPn1);
								text4 = Dicionario.BuscaNomeDoPainel(LJgCJsYr89[k].iPn2);
								num = 0;
								if (LJgCJsYr89[k].bBlindagem)
								{
									num = 1;
								}
								bool flag4 = true;
								P_3 = P_3.ToString().ToUpper();
								P_4 = P_4.ToString().ToUpper();
								if ((Dicionario.BuscaIndiceDoPainel(P_3) == 0) | (Operators.CompareString(P_3, "", TextCompare: true) == 0))
								{
									flag4 = false;
								}
								if ((Dicionario.BuscaIndiceDoPainel(P_4) == 0) | (Operators.CompareString(P_4, "", TextCompare: true) == 0))
								{
									flag4 = false;
								}
								if (((Operators.CompareString(P_3, "", TextCompare: true) != 0) & (Operators.CompareString(P_4, "", TextCompare: true) != 0)) && (((Operators.CompareString(text3.ToUpper(), P_3.ToUpper(), TextCompare: true) == 0) & (Operators.CompareString(text4.ToUpper(), P_4.ToUpper(), TextCompare: true) == 0)) | ((Operators.CompareString(text4.ToUpper(), P_3.ToUpper(), TextCompare: true) == 0) & (Operators.CompareString(text3.ToUpper(), P_4.ToUpper(), TextCompare: true) == 0))))
								{
									flag = true;
								}
								if (!flag & !flag4)
								{
									if (!((Operators.CompareString(P_3, "", TextCompare: true) != 0) & (Operators.CompareString(P_4, "", TextCompare: true) != 0)))
									{
										if (Operators.CompareString(P_3, "", TextCompare: true) != 0 && (LikeOperator.LikeString(text3.ToUpper(), "*" + P_3.ToUpper() + "*", CompareMethod.Text) | LikeOperator.LikeString(text4.ToUpper(), "*" + P_3.ToUpper() + "*", CompareMethod.Text)))
										{
											flag = true;
										}
										if (Operators.CompareString(P_4, "", TextCompare: true) != 0 && (LikeOperator.LikeString(text3.ToUpper(), "*" + P_4.ToUpper() + "*", CompareMethod.Text) | LikeOperator.LikeString(text4.ToUpper(), "*" + P_4.ToUpper() + "*", CompareMethod.Text)))
										{
											flag = true;
										}
									}
									else if (LikeOperator.LikeString(text3.ToUpper(), "*" + P_3.ToUpper() + "*", CompareMethod.Text) | LikeOperator.LikeString(text4.ToUpper(), "*" + P_4.ToUpper() + "*", CompareMethod.Text) | LikeOperator.LikeString(text4.ToUpper(), "*" + P_3.ToUpper() + "*", CompareMethod.Text) | LikeOperator.LikeString(text3.ToUpper(), "*" + P_4.ToUpper() + "*", CompareMethod.Text))
									{
										flag = true;
									}
									if ((Operators.CompareString(P_3, "", TextCompare: true) == 0) & (Operators.CompareString(P_4, "", TextCompare: true) == 0))
									{
										flag = true;
									}
								}
								if (flag)
								{
									if (!LikeOperator.LikeString(LJgCJsYr89[k].sTag.ToString().ToUpper(), "*" + P_0.ToUpper() + "*", CompareMethod.Text))
									{
										flag = false;
									}
									else if (!LikeOperator.LikeString(text.ToString().ToUpper(), "*" + P_1.ToUpper() + "*", CompareMethod.Text))
									{
										flag = false;
									}
									else if (!LikeOperator.LikeString(text2.ToString().ToUpper(), "*" + P_2.ToUpper() + "*", CompareMethod.Text))
									{
										flag = false;
									}
								}
								if (flag)
								{
									dg.Rows.Add(text3, text4, LJgCJsYr89[k].sTag, text, text2, num, LJgCJsYr89[k].iCabos, LJgCJsYr89[k].iAterrar, LJgCJsYr89[k].sFuncao, LJgCJsYr89[k].dComprimento, LJgCJsYr89[k].sTrajeto);
								}
								DeclaracoesGeral._uscPagina.pbPasso();
							}
							DeclaracoesGeral._uscPagina.pbFim();
							ldxSXYamjb();
							if (cbCabos.Checked)
							{
								DataGridViewColumn dataGridViewColumn3 = dg.Columns[2];
								dg.Sort(dataGridViewColumn3, ListSortDirection.Ascending);
							}
						}
					}
					else if (!Information.IsNothing(LJgCJsYr89))
					{
						DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(LJgCJsYr89);
						DeclaracoesGeral._uscPagina.pbIniciar();
						int num5 = Information.UBound(LJgCJsYr89);
						for (int l = 1; l <= num5; l++)
						{
							ksjSR3fFNH(LJgCJsYr89[l].sFormacao, LJgCJsYr89[l].iCabos, ref text, ref text2);
							if (flag)
							{
								dg.Rows.Add(Dicionario.BuscaNomeDoPainel(LJgCJsYr89[l].iPn1), Dicionario.BuscaNomeDoPainel(LJgCJsYr89[l].iPn2), LJgCJsYr89[l].sTag, LJgCJsYr89[l].sFuncao, LJgCJsYr89[l].dComprimento, LJgCJsYr89[l].sTrajeto, clsTextos.TiraNothing(LJgCJsYr89[l].sInstrucao));
							}
							DeclaracoesGeral._uscPagina.pbPasso();
						}
						DeclaracoesGeral._uscPagina.pbFim();
						XGCSmtbA74();
						if (cbCabos.Checked)
						{
							DataGridViewColumn dataGridViewColumn4 = dg.Columns[2];
							dg.Sort(dataGridViewColumn4, ListSortDirection.Ascending);
						}
					}
				}
				else
				{
					List<string> list = new List<string>();
					if (!Information.IsNothing(LJgCJsYr89))
					{
						DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(LJgCJsYr89);
						DeclaracoesGeral._uscPagina.pbIniciar();
						int num6 = Information.UBound(LJgCJsYr89);
						for (int m = 1; m <= num6; m++)
						{
							flag = false;
							string text5 = "";
							text5 = ((LJgCJsYr89[m].iPn1 < LJgCJsYr89[m].iPn2) ? (Conversions.ToString(LJgCJsYr89[m].iPn1) + "-" + Conversions.ToString(LJgCJsYr89[m].iPn2)) : (Conversions.ToString(LJgCJsYr89[m].iPn2) + "-" + Conversions.ToString(LJgCJsYr89[m].iPn1)));
							if (!list.Contains(text5))
							{
								list.Add(text5);
								text3 = Dicionario.BuscaNomeDoPainel(LJgCJsYr89[m].iPn1);
								text4 = Dicionario.BuscaNomeDoPainel(LJgCJsYr89[m].iPn2);
								dg.Rows.Add(text3, text4, LJgCJsYr89[m].dComprimento);
							}
						}
						DeclaracoesGeral._uscPagina.pbFim();
						CjCSU6YKvS();
						if (cbCabos.Checked)
						{
							DataGridViewColumn dataGridViewColumn5 = dg.Columns[1];
							dg.Sort(dataGridViewColumn5, ListSortDirection.Ascending);
							dataGridViewColumn5 = dg.Columns[0];
							dg.Sort(dataGridViewColumn5, ListSortDirection.Ascending);
						}
					}
				}
				DeclaracoesGeral._uscPagina.pbFim();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
			finally
			{
				qTotal.Text = Conversions.ToString(dg.RowCount);
			}
		}
	}

	private void ksjSR3fFNH(string P_0, int P_1, ref string P_2, ref string P_3)
	{
		if (P_1 != 1)
		{
			if (!Versioned.IsNumeric(P_0))
			{
				string[] array = P_0.Split('x');
				P_2 = Conversions.ToString(1);
				P_3 = array[1].Trim();
			}
			else
			{
				P_2 = Conversions.ToString(1);
				P_3 = P_0;
			}
		}
		else
		{
			string[] array2 = P_0.Split('x');
			P_2 = array2[0].Trim();
			P_3 = array2[1].Trim();
		}
	}

	private void XGCSmtbA74()
	{
		checked
		{
			double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 5)) : ((double)(dg.Width - 22)));
			dg.Columns[0].Width = (int)Math.Round(num * 0.1);
			dg.Columns[1].Width = (int)Math.Round(num * 0.1);
			dg.Columns[2].Width = (int)Math.Round(num * 0.15);
			dg.Columns[3].Width = (int)Math.Round(num * 0.2);
			dg.Columns[4].Width = (int)Math.Round(num * 0.1);
			dg.Columns[5].Width = (int)Math.Round(num * 0.25);
			dg.Columns[6].Width = (int)Math.Round(num * 0.1);
			int num2 = 0;
			do
			{
				dg.Columns[num2].Visible = true;
				dg.Columns[num2].ReadOnly = false;
				num2++;
			}
			while (num2 <= 4);
			dg.MultiSelect = true;
		}
	}

	private void ldxSXYamjb()
	{
		checked
		{
			double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 5)) : ((double)(dg.Width - 22)));
			dg.Columns[0].Width = (int)Math.Round(num * 0.13);
			dg.Columns[1].Width = (int)Math.Round(num * 0.13);
			dg.Columns[2].Width = (int)Math.Round(num * 0.135);
			dg.Columns[3].Width = (int)Math.Round(num * 0.05);
			dg.Columns[4].Width = (int)Math.Round(num * 0.05);
			dg.Columns[5].Width = (int)Math.Round(num * 0.05);
			dg.Columns[6].Width = (int)Math.Round(num * 0.05);
			dg.Columns[7].Width = (int)Math.Round(num * 0.05);
			dg.Columns[8].Width = (int)Math.Round(num * 0.15);
			dg.Columns[9].Width = (int)Math.Round(num * 0.05);
			dg.Columns[10].Width = (int)Math.Round(num * 0.15);
			dg.Columns[11].Width = 0;
			int num2 = 0;
			do
			{
				dg.Columns[num2].Visible = true;
				dg.Columns[num2].ReadOnly = false;
				num2++;
			}
			while (num2 <= 10);
			dg.Columns[11].Visible = false;
			dg.MultiSelect = true;
		}
	}

	private void CjCSU6YKvS()
	{
		checked
		{
			double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 5)) : ((double)(dg.Width - 22)));
			dg.Columns[0].Width = (int)Math.Round(num * 0.35);
			dg.Columns[1].Width = (int)Math.Round(num * 0.35);
			dg.Columns[2].Width = (int)Math.Round(num * 0.3);
			int num2 = 0;
			do
			{
				dg.Columns[num2].Visible = true;
				dg.Columns[num2].ReadOnly = false;
				num2++;
			}
			while (num2 <= 2);
			dg.MultiSelect = true;
		}
	}

	private void riISyMYAnt(object P_0, EventArgs P_1)
	{
		if (!rbCaderno.Checked)
		{
			return;
		}
		cbCabos.Enabled = true;
		wJj4HdDu3G(_0020: false);
		limpaCamposDaPesquisa();
		l4hS5TA0OG();
		w8bCGslVsP = "C";
		CarregaCabosNoDG();
		MostraEdicao(Edita: false);
		if (dg.RowCount > 0 && btEditarCabo.Enabled)
		{
			dg.Rows[0].Selected = false;
		}
		editarOCabo();
		List<string> list = new List<string>();
		int num = Information.UBound(eKhCoKqUTd);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				string item = Dicionario.BuscaNomeDoPainel(eKhCoKqUTd[i].iPn1);
				string item2 = Dicionario.BuscaNomeDoPainel(eKhCoKqUTd[i].iPn2);
				if (!list.Contains(item))
				{
					list.Add(item);
				}
				if (!list.Contains(item2))
				{
					list.Add(item2);
				}
			}
			_0cbOrigem.Items.Clear();
			_1cbDestino.Items.Clear();
			list.Sort();
			int num2 = list.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				_0cbOrigem.Items.Add(list[j]);
				_1cbDestino.Items.Add(list[j]);
			}
			wJj4HdDu3G(_0020: true);
			btPesquisa.Enabled = true;
			btApagarCabos.Enabled = true;
			BtEditar1Cabo.Enabled = false;
			if (dg.RowCount > 0)
			{
				BtEditar1Cabo.Enabled = true;
			}
			btAdicionarCabo.Enabled = true;
		}
	}

	private void HWoSgl9XMo(object P_0, EventArgs P_1)
	{
		if (!rbTodos.Checked)
		{
			return;
		}
		cbCabos.Enabled = true;
		wJj4HdDu3G(_0020: false);
		limpaCamposDaPesquisa();
		l4hS5TA0OG();
		w8bCGslVsP = "T";
		CarregaCabosNoDG();
		MostraEdicao(Edita: false);
		List<string> list = new List<string>();
		int num = Information.UBound(LJgCJsYr89);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				string item = Dicionario.BuscaNomeDoPainel(LJgCJsYr89[i].iPn1);
				string item2 = Dicionario.BuscaNomeDoPainel(LJgCJsYr89[i].iPn2);
				if (!list.Contains(item))
				{
					list.Add(item);
				}
				if (!list.Contains(item2))
				{
					list.Add(item2);
				}
			}
			_0cbOrigem.Items.Clear();
			_1cbDestino.Items.Clear();
			list.Sort();
			int num2 = list.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				_0cbOrigem.Items.Add(list[j]);
				_1cbDestino.Items.Add(list[j]);
			}
			wJj4HdDu3G(_0020: true);
			btPesquisa.Enabled = true;
			btApagarCabos.Enabled = false;
			BtEditar1Cabo.Enabled = false;
			btAdicionarCabo.Enabled = true;
		}
	}

	private void HvXSAU64Fx(object P_0, EventArgs P_1)
	{
		if (rbTodosEdicao.Checked)
		{
			cbCabos.Enabled = true;
			wJj4HdDu3G(_0020: false);
			limpaCamposDaPesquisa();
			fQUS1Lru29();
			w8bCGslVsP = "P";
			CarregaCabosNoDG();
			MostraEdicao(Edita: false);
			wJj4HdDu3G(_0020: true);
			btPesquisa.Enabled = false;
			btApagarCabos.Enabled = false;
			BtEditar1Cabo.Enabled = false;
			btAdicionarCabo.Enabled = false;
		}
	}

	private void I27SsJFtcp(object P_0, EventArgs P_1)
	{
		if (!rbNaoUsados.Checked)
		{
			return;
		}
		cbCabos.Enabled = true;
		wJj4HdDu3G(_0020: false);
		limpaCamposDaPesquisa();
		l4hS5TA0OG();
		w8bCGslVsP = "N";
		CarregaCabosNoDG();
		MostraEdicao(Edita: false);
		if (dg.RowCount > 0 && btEditarCabo.Enabled)
		{
			dg.Rows[0].Selected = false;
		}
		editarOCabo();
		List<string> list = new List<string>();
		int num = Information.UBound(NAMCha6FUY);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			string item = Dicionario.BuscaNomeDoPainel(NAMCha6FUY[i].iPn1);
			string item2 = Dicionario.BuscaNomeDoPainel(NAMCha6FUY[i].iPn2);
			if (!list.Contains(item))
			{
				list.Add(item);
			}
			if (!list.Contains(item2))
			{
				list.Add(item2);
			}
		}
		_0cbOrigem.Items.Clear();
		_1cbDestino.Items.Clear();
		ComboBox Combo = _0cbOrigem;
		Dicionario.CarregaPaineis(ref Combo);
		_0cbOrigem = Combo;
		Combo = _1cbDestino;
		Dicionario.CarregaPaineis(ref Combo);
		_1cbDestino = Combo;
		wJj4HdDu3G(_0020: true);
		btPesquisa.Enabled = true;
		btApagarCabos.Enabled = true;
		BtEditar1Cabo.Enabled = false;
		if (dg.RowCount > 0)
		{
			BtEditar1Cabo.Enabled = true;
		}
		btAdicionarCabo.Enabled = true;
	}

	public void CarregaCabosNoDG()
	{
		cbCabos.Visible = true;
		cbPainel.Visible = true;
		if (Operators.CompareString(w8bCGslVsP, "J", TextCompare: true) != 0)
		{
			if (Operators.CompareString(w8bCGslVsP, "P", TextCompare: true) != 0)
			{
				l4hS5TA0OG();
				O0lS0GAYkY(_2tbCabo.Text, _3tbVeia.Text, _4tbSecao.Text, _0cbOrigem.Text, _1cbDestino.Text, w8bCGslVsP);
				ldxSXYamjb();
			}
			else
			{
				fQUS1Lru29();
				O0lS0GAYkY(_2tbCabo.Text, _3tbVeia.Text, _4tbSecao.Text, _0cbOrigem.Text, _1cbDestino.Text, w8bCGslVsP);
				XGCSmtbA74();
			}
		}
		else
		{
			zIVSlCQ5BM();
			O0lS0GAYkY(_2tbCabo.Text, _3tbVeia.Text, _4tbSecao.Text, _0cbOrigem.Text, _1cbDestino.Text, w8bCGslVsP);
			CjCSU6YKvS();
		}
		if (dg.RowCount > 0)
		{
			btExportar.Enabled = true;
		}
		checked
		{
			if (dg.RowCount > 0)
			{
				int num = dg.RowCount - 1;
				for (int i = 0; i <= num; i++)
				{
					dg.Rows[i].Selected = false;
				}
				dg.Rows[0].Selected = true;
				dg.FirstDisplayedScrollingRowIndex = 0;
			}
		}
	}

	private void PIPSBaJb6M(object P_0, EventArgs P_1)
	{
		MsgBoxResult msgBoxResult = (MsgBoxResult)0;
		if (rbTodos.Checked)
		{
			return;
		}
		if (rbCaderno.Checked)
		{
			msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1451]), MsgBoxStyle.YesNo);
		}
		if (rbNaoUsados.Checked)
		{
			msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1283]), MsgBoxStyle.YesNo);
		}
		if (msgBoxResult != MsgBoxResult.No)
		{
			CDadosAccessInterligacao CDadosAccessInterligacao = new CDadosAccessInterligacao();
			ApagarSelecionados(ref CDadosAccessInterligacao);
			c01SZbL8qH(ref CDadosAccessInterligacao);
			CarregaCabosNoDG();
			CDadosAccessInterligacao.FechaConexao();
			Form form = System.Windows.Forms.Application.OpenForms["frmPesquisaVeiasIndefinidas"];
			if (!Information.IsNothing(form))
			{
				frmPesquisaVeiasIndefinidas frmPesquisaVeiasIndefinidas2 = (frmPesquisaVeiasIndefinidas)form;
				frmPesquisaVeiasIndefinidas2.CarregaNovamenteAsVeias();
			}
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		}
	}

	public void ApagarSelecionados(ref CDadosAccessInterligacao CDadosAccessInterligacao)
	{
		bool flag = false;
		checked
		{
			if (!rbTodos.Checked)
			{
				int num = dg.RowCount - 1;
				for (int i = 0; i <= num; i++)
				{
					if (dg.Rows[i].Selected)
					{
						CDadosAccessInterligacao.RemoveCaboErro(dg.Rows[i].Cells[2].Value.ToString());
						flag = true;
					}
				}
			}
			if (rbCaderno.Checked && flag)
			{
				clsEditarInterligacao.SincronizaVeiasDoCaderno(ref CDadosAccessInterligacao);
			}
		}
	}

	private void hoySVMxDDx(object P_0, EventArgs P_1)
	{
		bAQCHJx81r = true;
		wJj4HdDu3G(_0020: false);
		v59Cksrxw0 = false;
		MostraEdicao(Edita: false);
		CarregaCabosNoDG();
		wJj4HdDu3G(_0020: true);
		bAQCHJx81r = false;
		if ((Operators.CompareString(w8bCGslVsP, "P", TextCompare: true) == 0) | (Operators.CompareString(w8bCGslVsP, "T", TextCompare: true) == 0))
		{
			btApagarCabos.Enabled = false;
			BtEditar1Cabo.Enabled = false;
		}
	}

	private void UnISuggH3Q(object P_0, EventArgs P_1)
	{
		wJj4HdDu3G(_0020: false);
		v59Cksrxw0 = false;
		if (dg.RowCount > 0)
		{
			btExportar.Enabled = true;
		}
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Workbook oBook = null;
		Worksheet oSheet = null;
		if (ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet))
		{
			if (Operators.CompareString(DeclaracoesGeral.companyHardlock.ToUpper(), "CADGRAPH", TextCompare: true) != 0)
			{
				ExcFuncoesExcel.DesativaCalculoExcel(ref oExcelNew);
			}
			if (Operators.CompareString(w8bCGslVsP, "J", TextCompare: true) != 0)
			{
				if (Operators.CompareString(w8bCGslVsP, "P", TextCompare: true) != 0)
				{
					DataGridView withEventsValue = dg;
					ClsCabos.ExportaCabosParaOExcel(ref oSheet, ref withEventsValue, w8bCGslVsP);
					dg = withEventsValue;
				}
				else
				{
					DataGridView withEventsValue = dg;
					ClsCabos.ExportaCabosParcialParaOExcel(ref oSheet, ref withEventsValue, w8bCGslVsP);
					dg = withEventsValue;
				}
			}
			else
			{
				DataGridView withEventsValue = dg;
				ClsCabos.ExportaCabosTrajetoParaOExcel(ref oSheet, ref withEventsValue, w8bCGslVsP);
				dg = withEventsValue;
			}
			ExcFuncoesExcel.AtivaCalculOExcel(ref oExcelNew);
		}
		if (dg.RowCount > 0)
		{
			if (Operators.CompareString(w8bCGslVsP, "T", TextCompare: true) == 0)
			{
				btImportar.Enabled = false;
			}
			else
			{
				btImportar.Enabled = true;
			}
		}
		wJj4HdDu3G(_0020: true);
	}

	private void DiGSEbiLno(object P_0, EventArgs P_1)
	{
		wJj4HdDu3G(_0020: false);
		v59Cksrxw0 = false;
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		cDadosAccessInterligacao3.leNomeFuncaoDasVeias(ref veias.VeiasNomeFuncao);
		Microsoft.Office.Interop.Excel.Application oExcelNew = null;
		Workbook oBook = null;
		Worksheet oSheet = null;
		ClsCabos.NomeVeias nv = new ClsCabos.NomeVeias
		{
			blVar = tbBLVar.Text,
			P1Var = tbP1Var.Text,
			P2Var = tbP2Var.Text,
			T1Var = tbT1Var.Text,
			T2Var = tbT2Var.Text,
			T3Var = tbT3Var.Text
		};
		ClsCabos.CaboDWG[] mCabosDWG = new ClsCabos.CaboDWG[1];
		ClsCabos.CaboDWG[] mCabosEditar = new ClsCabos.CaboDWG[1];
		if (!((Operators.CompareString(w8bCGslVsP, "C", TextCompare: true) == 0) | (Operators.CompareString(w8bCGslVsP, "N", TextCompare: true) == 0) | (Operators.CompareString(w8bCGslVsP, "P", TextCompare: true) == 0)))
		{
			if (Operators.CompareString(w8bCGslVsP, "J", TextCompare: true) == 0 && ExcFuncoesExcel.VerificaExcelAtivoImportar(ref oExcelNew, ref oBook, ref oSheet, bMaximiza: false))
			{
				ClsCabos.CarregaOsCabosDoExcelParaEdicaoParcial2(ref oSheet, ref cDadosAccessInterligacao3);
			}
		}
		else if (ExcFuncoesExcel.VerificaExcelAtivoImportar(ref oExcelNew, ref oBook, ref oSheet, bMaximiza: false))
		{
			ClsCabos.StructureCabo[] mCabos = new ClsCabos.StructureCabo[1];
			List<string> lmListaCabos = new List<string>();
			cDadosAccessInterligacao3.LeNomeDeCabos(ref lmListaCabos);
			if (Operators.CompareString(w8bCGslVsP, "C", TextCompare: true) == 0)
			{
				ClsCabos.CarregaOsCabosDoExcelParaEdicao(ref oSheet, ref mCabos, lmListaCabos, nv, ref mCabosDWG, ref mCabosEditar, eKhCoKqUTd, ref cDadosAccessInterligacao3);
			}
			if (Operators.CompareString(w8bCGslVsP, "N", TextCompare: true) == 0)
			{
				ClsCabos.CarregaOsCabosDoExcelParaEdicao(ref oSheet, ref mCabos, lmListaCabos, nv, ref mCabosDWG, ref mCabosEditar, NAMCha6FUY, ref cDadosAccessInterligacao3);
			}
			if (Operators.CompareString(w8bCGslVsP, "P", TextCompare: true) == 0)
			{
				ClsCabos.CarregaOsCabosDoExcelParaEdicaoParcial(ref oSheet, ref mCabos, lmListaCabos, nv, ref mCabosDWG, ref mCabosEditar, NAMCha6FUY, ref cDadosAccessInterligacao3);
			}
			if (Operators.CompareString(w8bCGslVsP, "C", TextCompare: true) == 0)
			{
				ProgressBar1.Visible = true;
				if (Information.UBound(mCabosEditar) > 0)
				{
					ProgressBar ProgressBar = ProgressBar1;
					clsEditarInterligacao.EditaNomeDeVeiasImportadasDoExcels(ref mCabosEditar, ref ProgressBar, ref cDadosAccessInterligacao3);
					ProgressBar1 = ProgressBar;
				}
				ProgressBar1.Visible = false;
				clsEditarInterligacao.SincronizaVeiasDoCaderno(ref cDadosAccessInterligacao3);
			}
		}
		c01SZbL8qH(ref cDadosAccessInterligacao3);
		if (Operators.CompareString(w8bCGslVsP, "J", TextCompare: true) != 0)
		{
			if (Operators.CompareString(w8bCGslVsP, "P", TextCompare: true) != 0)
			{
				l4hS5TA0OG();
				O0lS0GAYkY(_2tbCabo.Text, _3tbVeia.Text, _4tbSecao.Text, _0cbOrigem.Text, _1cbDestino.Text, w8bCGslVsP);
				ldxSXYamjb();
			}
			else
			{
				fQUS1Lru29();
				O0lS0GAYkY(_2tbCabo.Text, _3tbVeia.Text, _4tbSecao.Text, _0cbOrigem.Text, _1cbDestino.Text, w8bCGslVsP);
				XGCSmtbA74();
			}
		}
		else
		{
			zIVSlCQ5BM();
			O0lS0GAYkY(_2tbCabo.Text, _3tbVeia.Text, _4tbSecao.Text, _0cbOrigem.Text, _1cbDestino.Text, w8bCGslVsP);
			CjCSU6YKvS();
		}
		btExportar.Enabled = true;
		wJj4HdDu3G(_0020: true);
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		if (v59Cksrxw0)
		{
			clsInterligacao.SincronizaCruzamentoInterlig();
		}
		int num = Information.UBound(mCabosEditar);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				int num2 = Information.UBound(veias.VeiasNomeFuncao);
				for (int j = 1; j <= num2; j++)
				{
					if (Operators.CompareString(veias.VeiasNomeFuncao[j].sTag, mCabosEditar[i].sTagOriginal, TextCompare: true) == 0 && Operators.CompareString(mCabosEditar[i].sTagOriginal, mCabosEditar[i].sTagNovo, TextCompare: true) != 0)
					{
						veias.VeiasNomeFuncao[j].sTag = mCabosEditar[i].sTagNovo;
					}
				}
			}
			cDadosAccessInterligacao3.atualizaNomeFuncaoDasVeias(veias.VeiasNomeFuncao);
			cDadosAccessInterligacao3.FechaConexao();
			veias.VeiasNomeFuncao = new clsVeias.StructureUmaVeia[1];
			if (v59Cksrxw0)
			{
				clsUtilitarios.AtualizaTodosOpcionaisDoCabo();
			}
		}
	}

	private void c01SZbL8qH(ref CDadosAccessInterligacao P_0)
	{
		LJgCJsYr89 = new ClsCabos.StructureCabo[1];
		NAMCha6FUY = new ClsCabos.StructureCabo[1];
		eKhCoKqUTd = new ClsCabos.StructureCabo[1];
		DeclaracoesGeral._uscPagina.Quantidade = 3;
		DeclaracoesGeral._uscPagina.pbIniciar();
		DeclaracoesGeral._uscPagina.pbPasso();
		P_0.LeTodosOsCabos(ref LJgCJsYr89, ref lTodosCabos, bProgress: false);
		OrdenammTodosCabos();
		DeclaracoesGeral._uscPagina.pbPasso();
		P_0.LeTodosOsCabosLivres(ref NAMCha6FUY, bProgress: false);
		OrdenammLivresCabos();
		DeclaracoesGeral._uscPagina.pbPasso();
		P_0.LeTodosOsCabosUsadosNesteCaderno(ref eKhCoKqUTd, DeclaracoesGeral.arqAtivo.Indice, bProgress: false);
		OrdenammCadernoCabos();
		DeclaracoesGeral._uscPagina.pbFim();
	}

	public void OrdenammTodosCabos()
	{
		if (Information.IsNothing(LJgCJsYr89))
		{
			return;
		}
		ClsCabos.StructureCabo structureCabo = default;
		if (Information.UBound(LJgCJsYr89) <= 0)
		{
			return;
		}
		int num = Information.UBound(LJgCJsYr89);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				int num2 = Information.UBound(LJgCJsYr89) - 1;
				int num3 = i;
				for (int j = num2; j >= num3; j += -1)
				{
					if (Operators.CompareString(Dicionario.BuscaNomeDoPainel(LJgCJsYr89[j].iPn1), Dicionario.BuscaNomeDoPainel(LJgCJsYr89[j + 1].iPn1), TextCompare: true) > 0)
					{
						structureCabo = LJgCJsYr89[j + 1];
						LJgCJsYr89[j + 1] = LJgCJsYr89[j];
						LJgCJsYr89[j] = structureCabo;
					}
				}
			}
			int num4 = Information.UBound(LJgCJsYr89);
			for (int k = 1; k <= num4; k++)
			{
				int num5 = Information.UBound(LJgCJsYr89) - 1;
				int num6 = k;
				for (int l = num5; l >= num6; l += -1)
				{
					if (Operators.CompareString(Dicionario.BuscaNomeDoPainel(LJgCJsYr89[l].iPn1), Dicionario.BuscaNomeDoPainel(LJgCJsYr89[l + 1].iPn1), TextCompare: true) == 0 && Operators.CompareString(Dicionario.BuscaNomeDoPainel(LJgCJsYr89[l].iPn2), Dicionario.BuscaNomeDoPainel(LJgCJsYr89[l + 1].iPn2), TextCompare: true) > 0)
					{
						structureCabo = LJgCJsYr89[l + 1];
						LJgCJsYr89[l + 1] = LJgCJsYr89[l];
						LJgCJsYr89[l] = structureCabo;
					}
				}
			}
		}
	}

	public void OrdenammLivresCabos()
	{
		if (Information.IsNothing(NAMCha6FUY))
		{
			return;
		}
		ClsCabos.StructureCabo structureCabo = default;
		if (Information.UBound(NAMCha6FUY) <= 0)
		{
			return;
		}
		int num = Information.UBound(NAMCha6FUY);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				int num2 = Information.UBound(NAMCha6FUY) - 1;
				int num3 = i;
				for (int j = num2; j >= num3; j += -1)
				{
					if (Operators.CompareString(Dicionario.BuscaNomeDoPainel(NAMCha6FUY[j].iPn1), Dicionario.BuscaNomeDoPainel(LJgCJsYr89[j + 1].iPn1), TextCompare: true) > 0)
					{
						structureCabo = NAMCha6FUY[j + 1];
						NAMCha6FUY[j + 1] = NAMCha6FUY[j];
						NAMCha6FUY[j] = structureCabo;
					}
				}
			}
			int num4 = Information.UBound(NAMCha6FUY);
			for (int k = 1; k <= num4; k++)
			{
				int num5 = Information.UBound(NAMCha6FUY) - 1;
				int num6 = k;
				for (int l = num5; l >= num6; l += -1)
				{
					if (Operators.CompareString(Dicionario.BuscaNomeDoPainel(NAMCha6FUY[l].iPn1), Dicionario.BuscaNomeDoPainel(NAMCha6FUY[l + 1].iPn1), TextCompare: true) == 0 && Operators.CompareString(Dicionario.BuscaNomeDoPainel(NAMCha6FUY[l].iPn2), Dicionario.BuscaNomeDoPainel(NAMCha6FUY[l + 1].iPn2), TextCompare: true) > 0)
					{
						structureCabo = NAMCha6FUY[l + 1];
						NAMCha6FUY[l + 1] = NAMCha6FUY[l];
						NAMCha6FUY[l] = structureCabo;
					}
				}
			}
		}
	}

	public void OrdenammCadernoCabos()
	{
		if (Information.IsNothing(eKhCoKqUTd))
		{
			return;
		}
		ClsCabos.StructureCabo structureCabo = default;
		if (Information.UBound(eKhCoKqUTd) <= 0)
		{
			return;
		}
		int num = Information.UBound(eKhCoKqUTd);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				int num2 = Information.UBound(eKhCoKqUTd) - 1;
				int num3 = i;
				for (int j = num2; j >= num3; j += -1)
				{
					if (Operators.CompareString(Dicionario.BuscaNomeDoPainel(eKhCoKqUTd[j].iPn1), Dicionario.BuscaNomeDoPainel(eKhCoKqUTd[j + 1].iPn1), TextCompare: true) > 0)
					{
						structureCabo = eKhCoKqUTd[j + 1];
						eKhCoKqUTd[j + 1] = eKhCoKqUTd[j];
						eKhCoKqUTd[j] = structureCabo;
					}
				}
			}
			int num4 = Information.UBound(eKhCoKqUTd);
			for (int k = 1; k <= num4; k++)
			{
				int num5 = Information.UBound(eKhCoKqUTd) - 1;
				int num6 = k;
				for (int l = num5; l >= num6; l += -1)
				{
					if (Operators.CompareString(Dicionario.BuscaNomeDoPainel(eKhCoKqUTd[l].iPn1), Dicionario.BuscaNomeDoPainel(eKhCoKqUTd[l + 1].iPn1), TextCompare: true) == 0 && Operators.CompareString(Dicionario.BuscaNomeDoPainel(eKhCoKqUTd[l].iPn2), Dicionario.BuscaNomeDoPainel(eKhCoKqUTd[l + 1].iPn2), TextCompare: true) > 0)
					{
						structureCabo = eKhCoKqUTd[l + 1];
						eKhCoKqUTd[l + 1] = eKhCoKqUTd[l];
						eKhCoKqUTd[l] = structureCabo;
					}
				}
			}
		}
	}

	private void t2QSiXfh75(object P_0, EventArgs P_1)
	{
		if (!CesCTrthCe)
		{
			return;
		}
		if (!rbTrajeto.Checked)
		{
			if (!rbTodosEdicao.Checked)
			{
				ldxSXYamjb();
			}
			else
			{
				XGCSmtbA74();
			}
		}
		else
		{
			CjCSU6YKvS();
		}
	}

	private void MfUSS63wIj(object P_0, EventArgs P_1)
	{
		if (dg.RowCount != 0)
		{
			v59Cksrxw0 = true;
			btExportar.Enabled = false;
			btImportar.Enabled = false;
			dg.MultiSelect = false;
			_5cbBlinED.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 20]);
			_7cbAterrarED.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 20]);
			MostraEdicao(Edita: true);
		}
	}

	private void PEoS4mx00G(object P_0, EventArgs P_1)
	{
		v59Cksrxw0 = false;
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		cDadosAccessInterligacao3.leNomeFuncaoDasVeias(ref veias.VeiasNomeFuncao);
		string text = "";
		ClsCabos.NomeVeias nv = new ClsCabos.NomeVeias
		{
			blVar = tbBLVar.Text,
			P1Var = tbP1Var.Text,
			P2Var = tbP2Var.Text,
			T1Var = tbT1Var.Text,
			T2Var = tbT2Var.Text,
			T3Var = tbT3Var.Text
		};
		string text2 = Conversions.ToString(dg.SelectedRows[0].Cells[2].Value);
		text = _2tbCabo.Text;
		ClsCabos.CaboDWG[] mCabosDWG = new ClsCabos.CaboDWG[1];
		ClsCabos.CaboDWG[] mCabosEditar = new ClsCabos.CaboDWG[1];
		if ((Operators.CompareString(w8bCGslVsP, "C", TextCompare: true) == 0) | (Operators.CompareString(w8bCGslVsP, "N", TextCompare: true) == 0))
		{
			ClsCabos.StructureCabo mCabos = default;
			List<string> lmListaCabos = new List<string>();
			cDadosAccessInterligacao3.LeNomeDeCabos(ref lmListaCabos);
			if (Operators.CompareString(w8bCGslVsP, "C", TextCompare: true) == 0)
			{
				EditaCaboUnicoDoDG(text2, ref mCabos, lmListaCabos, nv, ref mCabosDWG, ref mCabosEditar, eKhCoKqUTd, ref cDadosAccessInterligacao3);
				ProgressBar1.Visible = true;
				if (Information.UBound(mCabosEditar) > 0)
				{
					ProgressBar ProgressBar = ProgressBar1;
					clsEditarInterligacao.EditaNomeDeVeiasImportadasDoExcels(ref mCabosEditar, ref ProgressBar, ref cDadosAccessInterligacao3);
					ProgressBar1 = ProgressBar;
				}
				ProgressBar1.Visible = false;
				clsEditarInterligacao.SincronizaVeiasDoCaderno(ref cDadosAccessInterligacao3);
			}
			if (Operators.CompareString(w8bCGslVsP, "N", TextCompare: true) == 0)
			{
				EditaCaboUnicoDoDG(text2, ref mCabos, lmListaCabos, nv, ref mCabosDWG, ref mCabosEditar, NAMCha6FUY, ref cDadosAccessInterligacao3);
			}
		}
		c01SZbL8qH(ref cDadosAccessInterligacao3);
		l4hS5TA0OG();
		O0lS0GAYkY(_2tbCabo.Text, _3tbVeia.Text, _4tbSecao.Text, _0cbOrigem.Text, _1cbDestino.Text, w8bCGslVsP);
		ldxSXYamjb();
		btExportar.Enabled = true;
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		MostraEdicao(Edita: false);
		v59Cksrxw0 = false;
		int num = Information.UBound(veias.VeiasNomeFuncao);
		for (int i = 0; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(veias.VeiasNomeFuncao[i].sTag, text2, TextCompare: true) == 0 && Operators.CompareString(text2, text, TextCompare: true) != 0)
			{
				veias.VeiasNomeFuncao[i].sTag = text2;
			}
		}
		cDadosAccessInterligacao3.atualizaNomeFuncaoDasVeias(veias.VeiasNomeFuncao);
		cDadosAccessInterligacao3.FechaConexao();
		if (Information.UBound(mCabosEditar) > 0)
		{
			clsUtilitarios.AtualizaTodosOpcionaisDoCabo();
		}
	}

	public bool EditaCaboUnicoDoDG(string sNomeOriginal, ref ClsCabos.StructureCabo mCabos, List<string> lmListaCabos, ClsCabos.NomeVeias nv, ref ClsCabos.CaboDWG[] mCabosDWG, ref ClsCabos.CaboDWG[] mCabosEditar, ClsCabos.StructureCabo[] mmCadernoCabos, ref CDadosAccessInterligacao cDadosAccessInterligacao)
	{
		bool flag = false;
		List<string> list = new List<string>();
		list.Clear();
		int num = 1;
		string sCabo = sNomeOriginal;
		checked
		{
			if (Operators.CompareString(sNomeOriginal.ToString().ToUpper().Trim(), _2tbCabo.Text, TextCompare: true) != 0)
			{
				num = Information.UBound(mCabosDWG) + 1;
				mCabosDWG = (ClsCabos.CaboDWG[])Utils.CopyArray(mCabosDWG, new ClsCabos.CaboDWG[num + 1]);
				mCabosDWG[num].sTagNovo = _2tbCabo.Text;
				mCabosDWG[num].sTagOriginal = sNomeOriginal;
				mCabosDWG[num].iPn1 = Dicionario.BuscaIndiceDoPainel(_0cbOrigem.Text);
				mCabosDWG[num].iPn2 = Dicionario.BuscaIndiceDoPainel(_1cbDestino.Text);
				sCabo = sNomeOriginal;
			}
			num = Information.UBound(mCabosEditar) + 1;
			mCabosEditar = (ClsCabos.CaboDWG[])Utils.CopyArray(mCabosEditar, new ClsCabos.CaboDWG[num + 1]);
			mCabosEditar[num].sTagNovo = _2tbCabo.Text;
			mCabosEditar[num].sTagOriginal = sNomeOriginal;
			mCabosEditar[num].iPn1 = Dicionario.BuscaIndiceDoPainel(_0cbOrigem.Text);
			mCabosEditar[num].iPn2 = Dicionario.BuscaIndiceDoPainel(_1cbDestino.Text);
			list.Add(_2tbCabo.Text);
			mCabos.iLinha = 1;
			mCabos.iPn1 = Dicionario.BuscaIndiceDoPainel(_0cbOrigem.Text);
			mCabos.iPn2 = Dicionario.BuscaIndiceDoPainel(_1cbDestino.Text);
			mCabos.sTag = _2tbCabo.Text;
			mCabos.sVeias = _3tbVeia.Text;
			mCabos.sSecao = _4tbSecao.Text;
			if (Conversions.ToInteger(_6tbCabosED.Text) != 1)
			{
				mCabos.sFormacao = "1x" + _4tbSecao.Text;
			}
			else
			{
				mCabos.sFormacao = _3tbVeia.Text + "x" + _4tbSecao.Text;
			}
			int num2 = 0;
			string left = _5cbBlinED.Text;
			if (!Operators.ConditionalCompareObjectEqual(left, DeclaracoesGeral.mMensagem[1, 20], TextCompare: true))
			{
				if (Operators.ConditionalCompareObjectEqual(left, DeclaracoesGeral.mMensagem[1, 19], TextCompare: true))
				{
					num2 = 1;
				}
			}
			else
			{
				num2 = 0;
			}
			mCabos.bBlindagem = num2 != 0;
			mCabos.iCabos = Conversions.ToInteger(_6tbCabosED.Text);
			int iAterrar = 0;
			string left2 = _7cbAterrarED.Text.Trim();
			if (!Operators.ConditionalCompareObjectEqual(left2, DeclaracoesGeral.mMensagem[1, 20], TextCompare: true))
			{
				if (!Operators.ConditionalCompareObjectEqual(left2, DeclaracoesGeral.mMensagem[1, 429], TextCompare: true))
				{
					if (!Operators.ConditionalCompareObjectEqual(left2, DeclaracoesGeral.mMensagem[1, 432], TextCompare: true))
					{
						if (Operators.ConditionalCompareObjectEqual(left2, DeclaracoesGeral.mMensagem[1, 1639], TextCompare: true))
						{
							iAterrar = 3;
						}
					}
					else
					{
						iAterrar = 2;
					}
				}
				else
				{
					iAterrar = 1;
				}
			}
			else
			{
				iAterrar = 0;
			}
			mCabos.iAterrar = iAterrar;
			mCabos.sFuncao = _8tbFuncao.Text;
			mCabos.dComprimento = Conversions.ToDouble(_9tbComprimento.Text);
			mCabos.sTrajeto = _10tbTrajeto.Text;
			ClsCabos.StructureCabo cabo = mCabos;
			cDadosAccessInterligacao.RemoveCaboErro(sCabo);
			cabo.sGrupo = clsTextos.TiraNothing(cabo.sGrupo);
			cabo.sCodigo = clsTextos.TiraNothing(cabo.sCodigo);
			cabo.sInstrucao = clsTextos.TiraNothing(cabo.sInstrucao);
			flag = ClsCabos.LancaUmCabo(cabo, nv, ref cDadosAccessInterligacao);
			v59Cksrxw0 = true;
			limpaCamposDaPesquisa();
			return flag;
		}
	}

	private void KSpSC2OFfG(object P_0, EventArgs P_1)
	{
		limpaCamposDaPesquisa();
		if (dg.MultiSelect)
		{
			return;
		}
		if (!rbNaoUsados.Checked)
		{
			_0cbOrigem.Enabled = false;
			_1cbDestino.Enabled = false;
		}
		else
		{
			_0cbOrigem.Enabled = true;
			_1cbDestino.Enabled = true;
		}
		checked
		{
			int num = dg.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				if (!dg.Rows[i].Selected)
				{
					continue;
				}
				_0cbOrigem.Text = dg.Rows[i].Cells[0].Value.ToString();
				_1cbDestino.Text = dg.Rows[i].Cells[1].Value.ToString();
				_2tbCabo.Text = dg.Rows[i].Cells[2].Value.ToString();
				_3tbVeia.Text = dg.Rows[i].Cells[3].Value.ToString();
				_4tbSecao.Text = dg.Rows[i].Cells[4].Value.ToString();
				_5cbBlinED.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 20]);
				if (Operators.CompareString(dg.Rows[i].Cells[5].Value.ToString(), "1", TextCompare: true) == 0)
				{
					_5cbBlinED.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 19]);
				}
				_6tbCabosED.Text = dg.Rows[i].Cells[6].Value.ToString();
				string left = dg.Rows[i].Cells[7].Value.ToString();
				if (Operators.CompareString(left, "0", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left, "1", TextCompare: true) != 0)
					{
						if (Operators.CompareString(left, "2", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left, "3", TextCompare: true) == 0)
							{
								_7cbAterrarED.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1639]);
							}
						}
						else
						{
							_7cbAterrarED.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 432]);
						}
					}
					else
					{
						_7cbAterrarED.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 429]);
					}
				}
				else
				{
					_7cbAterrarED.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 20]);
				}
				_8tbFuncao.Text = dg.Rows[i].Cells[8].Value.ToString();
				_9tbComprimento.Text = dg.Rows[i].Cells[9].Value.ToString();
				_10tbTrajeto.Text = dg.Rows[i].Cells[10].Value.ToString();
			}
		}
	}

	public void MostraEdicao(bool Edita)
	{
		PNEditar.Visible = Edita;
		btEditarCabo.Enabled = false;
		btEditarCabo.Visible = Edita;
		checked
		{
			if (!Edita)
			{
				dg.MultiSelect = true;
				_0cbOrigem.Enabled = true;
				_1cbDestino.Enabled = true;
				btExportar.Enabled = true;
				btImportar.Enabled = false;
				double num = Size.Height - PNCabos.Size.Height - 50;
				PNCabos.Location = new Point(PNCabos.Location.X, (int)Math.Round(num));
				dg.Height = (int)Math.Round(num - 15.0);
			}
			else
			{
				double num2 = Size.Height - PNCabos.Size.Height - PNEditar.Size.Height - 50;
				PNCabos.Location = new Point(PNCabos.Location.X, (int)Math.Round(num2));
				dg.Height = (int)Math.Round(num2 - 15.0);
			}
		}
	}

	public void limpaCamposDaPesquisa()
	{
		if (bAQCHJx81r)
		{
			return;
		}
		if (!v59Cksrxw0)
		{
			_0cbOrigem.Text = "";
			_1cbDestino.Text = "";
			_2tbCabo.Text = "";
			_3tbVeia.Text = "";
			_4tbSecao.Text = "";
			_5cbBlinED.Text = "";
			_6tbCabosED.Text = "";
			_7cbAterrarED.Text = "";
			_8tbFuncao.Text = "";
			_9tbComprimento.Text = "";
			_10tbTrajeto.Text = "";
		}
		else
		{
			if (!_0cbOrigem.Enabled)
			{
				_0cbOrigem.Text = "";
			}
			if (!_1cbDestino.Enabled)
			{
				_1cbDestino.Text = "";
			}
			_2tbCabo.Text = "";
			_3tbVeia.Text = "";
			_4tbSecao.Text = "";
			_5cbBlinED.Text = "";
			_6tbCabosED.Text = "";
			_7cbAterrarED.Text = "";
			_8tbFuncao.Text = "";
			_9tbComprimento.Text = "";
			_10tbTrajeto.Text = "";
		}
		_0cbOrigem.BackColor = Color.White;
		_1cbDestino.BackColor = Color.White;
		_2tbCabo.BackColor = Color.White;
		_3tbVeia.BackColor = Color.White;
		_4tbSecao.BackColor = Color.White;
		_5cbBlinED.BackColor = Color.White;
		_6tbCabosED.BackColor = Color.White;
		_7cbAterrarED.BackColor = Color.White;
		_8tbFuncao.BackColor = Color.White;
		_9tbComprimento.BackColor = Color.White;
		_10tbTrajeto.BackColor = Color.White;
		_0cbOrigem.ForeColor = Color.Black;
		_1cbDestino.ForeColor = Color.Black;
		_2tbCabo.ForeColor = Color.Black;
		_3tbVeia.ForeColor = Color.Black;
		_4tbSecao.ForeColor = Color.Black;
		_5cbBlinED.ForeColor = Color.Black;
		_6tbCabosED.ForeColor = Color.Black;
		_7cbAterrarED.ForeColor = Color.Black;
		_8tbFuncao.ForeColor = Color.Black;
		_9tbComprimento.ForeColor = Color.Black;
		_10tbTrajeto.ForeColor = Color.Black;
	}

	private void mWNSYsJAoC(object P_0, EventArgs P_1)
	{
		if (!v59Cksrxw0)
		{
			return;
		}
		_0cbOrigem.BackColor = Color.White;
		_0cbOrigem.ForeColor = Color.Black;
		if (dg.SelectedRows.Count != 0)
		{
			if (Operators.ConditionalCompareObjectNotEqual(dg.SelectedRows[0].Cells[0].Value, _0cbOrigem.Text, TextCompare: true))
			{
				_0cbOrigem.BackColor = Color.LightGreen;
				_0cbOrigem.ForeColor = Color.Black;
			}
			editarOCabo();
		}
	}

	private void durSrWuNns(object P_0, EventArgs P_1)
	{
		if (!v59Cksrxw0)
		{
			return;
		}
		_1cbDestino.BackColor = Color.White;
		_1cbDestino.ForeColor = Color.Black;
		if (dg.SelectedRows.Count != 0)
		{
			if (Operators.ConditionalCompareObjectNotEqual(dg.SelectedRows[0].Cells[1].Value, _1cbDestino.Text, TextCompare: true))
			{
				_1cbDestino.BackColor = Color.LightGreen;
				_1cbDestino.ForeColor = Color.Black;
			}
			if (Operators.CompareString(_0cbOrigem.Text, _1cbDestino.Text, TextCompare: true) == 0)
			{
				_1cbDestino.BackColor = Color.Red;
				_1cbDestino.ForeColor = Color.White;
			}
			editarOCabo();
		}
	}

	private void kUBS9k1kcX(object P_0, KeyEventArgs P_1)
	{
		if (!v59Cksrxw0)
		{
			return;
		}
		try
		{
			if (btEditarCabo.Visible)
			{
				_2tbCabo.BackColor = Color.White;
				_2tbCabo.ForeColor = Color.Black;
				if (dg.SelectedRows.Count == 1)
				{
					string right = Conversions.ToString(dg.SelectedRows[0].Cells[2].Value);
					if (Operators.CompareString(_2tbCabo.Text, right, TextCompare: true) != 0)
					{
						if (!(lTodosCabos.Contains(_2tbCabo.Text) | (Operators.CompareString(_2tbCabo.Text.Trim(), "", TextCompare: true) == 0)))
						{
							_2tbCabo.BackColor = Color.LightGreen;
							_2tbCabo.ForeColor = Color.Black;
						}
						else
						{
							_2tbCabo.BackColor = Color.Red;
							_2tbCabo.ForeColor = Color.White;
						}
					}
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		editarOCabo();
	}

	private void PD5SzQQR22(object P_0, KeyEventArgs P_1)
	{
		if (!v59Cksrxw0)
		{
			return;
		}
		try
		{
			_3tbVeia.BackColor = Color.White;
			_3tbVeia.ForeColor = Color.Black;
			_3tbVeia.Text = _3tbVeia.Text.Trim();
			if (!((Operators.CompareString(_3tbVeia.Text.Trim(), "", TextCompare: true) == 0) | (Operators.CompareString(_3tbVeia.Text.Trim(), "0", TextCompare: true) == 0)))
			{
				if (!Versioned.IsNumeric(_3tbVeia.Text))
				{
					string text = Strings.Mid(_3tbVeia.Text, Strings.Len(_3tbVeia.Text));
					if ((Operators.CompareString(text.ToUpper(), "P", TextCompare: true) == 0) | (Operators.CompareString(text.ToUpper(), "T", TextCompare: true) == 0))
					{
						goto IL_0191;
					}
					_3tbVeia.BackColor = Color.Red;
					_3tbVeia.ForeColor = Color.White;
				}
				else
				{
					int num = Conversions.ToInteger(_3tbVeia.Text);
					if (num > 0)
					{
						if (Operators.CompareString(_6tbCabosED.Text, "1", TextCompare: true) != 0)
						{
							_6tbCabosED.Text = "1";
							_6tbCabosED.BackColor = Color.LightGreen;
							_6tbCabosED.ForeColor = Color.Black;
						}
						goto IL_0191;
					}
					_3tbVeia.BackColor = Color.Red;
					_3tbVeia.ForeColor = Color.White;
				}
			}
			else
			{
				_3tbVeia.BackColor = Color.Red;
				_3tbVeia.ForeColor = Color.White;
			}
			goto end_IL_000f;
			IL_0191:
			if (Operators.ConditionalCompareObjectNotEqual(dg.SelectedRows[0].Cells[3].Value, _3tbVeia.Text.Trim(), TextCompare: true))
			{
				_3tbVeia.BackColor = Color.LightGreen;
				_3tbVeia.ForeColor = Color.Black;
			}
			end_IL_000f:;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		editarOCabo();
	}

	private void Xqj4W0foqh(object P_0, KeyEventArgs P_1)
	{
		if (!v59Cksrxw0)
		{
			return;
		}
		try
		{
			_4tbSecao.BackColor = Color.White;
			_4tbSecao.ForeColor = Color.Black;
			_4tbSecao.Text = _4tbSecao.Text.Trim();
			if (!((Operators.CompareString(_4tbSecao.Text.Trim(), "", TextCompare: true) == 0) | (Operators.CompareString(_4tbSecao.Text.Trim(), "0", TextCompare: true) == 0)))
			{
				if (!Versioned.IsNumeric(_4tbSecao.Text))
				{
					goto IL_009b;
				}
				int num = Conversions.ToInteger(_4tbSecao.Text);
				if (num > 0)
				{
					goto IL_009b;
				}
				_4tbSecao.BackColor = Color.Red;
				_4tbSecao.ForeColor = Color.White;
			}
			else
			{
				_4tbSecao.BackColor = Color.Red;
				_4tbSecao.ForeColor = Color.White;
			}
			goto end_IL_000f;
			IL_009b:
			if (Operators.ConditionalCompareObjectNotEqual(dg.SelectedRows[0].Cells[4].Value, _4tbSecao.Text.Trim(), TextCompare: true))
			{
				_4tbSecao.BackColor = Color.LightGreen;
				_4tbSecao.ForeColor = Color.Black;
			}
			end_IL_000f:;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		editarOCabo();
	}

	private void EKX4p22PkT(object P_0, EventArgs P_1)
	{
		if (!v59Cksrxw0)
		{
			return;
		}
		_5cbBlinED.BackColor = Color.White;
		_5cbBlinED.ForeColor = Color.Black;
		if (dg.SelectedRows.Count == 0)
		{
			return;
		}
		int num = 0;
		string left = _5cbBlinED.Text.Trim();
		if (!Operators.ConditionalCompareObjectEqual(left, DeclaracoesGeral.mMensagem[1, 20], TextCompare: true))
		{
			if (Operators.ConditionalCompareObjectEqual(left, DeclaracoesGeral.mMensagem[1, 19], TextCompare: true))
			{
				num = 1;
			}
		}
		else
		{
			num = 0;
		}
		if (Operators.ConditionalCompareObjectNotEqual(dg.SelectedRows[0].Cells[5].Value, num, TextCompare: true))
		{
			_5cbBlinED.BackColor = Color.LightGreen;
			_5cbBlinED.ForeColor = Color.Black;
		}
		editarOCabo();
	}

	private void DeY4TQOeSw(object P_0, KeyEventArgs P_1)
	{
		if (v59Cksrxw0)
		{
			_6tbCabosED.BackColor = Color.White;
			_6tbCabosED.ForeColor = Color.Black;
			_6tbCabosED.Text = _6tbCabosED.Text.Trim();
			if (Operators.CompareString(_6tbCabosED.Text.Trim(), "", TextCompare: true) != 0)
			{
				if (!Versioned.IsNumeric(_6tbCabosED.Text))
				{
					_6tbCabosED.BackColor = Color.Red;
					_6tbCabosED.ForeColor = Color.White;
				}
				else
				{
					double num = Conversions.ToDouble(_6tbCabosED.Text);
					if (num >= 0.0)
					{
						if (Operators.CompareString(_6tbCabosED.Text.ToString(), "0.0", TextCompare: true) == 0)
						{
							_6tbCabosED.Text = "0";
						}
						if (num >= 1.0)
						{
							_3tbVeia.Text = "1";
							_3tbVeia.BackColor = Color.LightGreen;
							_3tbVeia.ForeColor = Color.Black;
						}
					}
					if (Operators.ConditionalCompareObjectNotEqual(dg.SelectedRows[0].Cells[6].Value, Conversions.ToDouble(_6tbCabosED.Text), TextCompare: true))
					{
						_6tbCabosED.BackColor = Color.LightGreen;
						_6tbCabosED.ForeColor = Color.Black;
					}
				}
			}
			else
			{
				_6tbCabosED.BackColor = Color.Red;
				_6tbCabosED.ForeColor = Color.White;
			}
		}
		editarOCabo();
	}

	private void xPt4JJtMAw(object P_0, EventArgs P_1)
	{
		if (!v59Cksrxw0)
		{
			return;
		}
		_7cbAterrarED.BackColor = Color.White;
		_7cbAterrarED.ForeColor = Color.Black;
		if (dg.SelectedRows.Count == 0)
		{
			return;
		}
		int num = 0;
		string left = _7cbAterrarED.Text.Trim();
		if (!Operators.ConditionalCompareObjectEqual(left, DeclaracoesGeral.mMensagem[1, 20], TextCompare: true))
		{
			if (!Operators.ConditionalCompareObjectEqual(left, DeclaracoesGeral.mMensagem[1, 429], TextCompare: true))
			{
				if (!Operators.ConditionalCompareObjectEqual(left, DeclaracoesGeral.mMensagem[1, 432], TextCompare: true))
				{
					if (Operators.ConditionalCompareObjectEqual(left, DeclaracoesGeral.mMensagem[1, 1639], TextCompare: true))
					{
						num = 3;
					}
				}
				else
				{
					num = 2;
				}
			}
			else
			{
				num = 1;
			}
		}
		else
		{
			num = 0;
		}
		if (Operators.ConditionalCompareObjectNotEqual(dg.SelectedRows[0].Cells[7].Value, num, TextCompare: true))
		{
			_7cbAterrarED.BackColor = Color.LightGreen;
			_7cbAterrarED.ForeColor = Color.Black;
		}
		editarOCabo();
	}

	private void qke4hTf3Zi(object P_0, KeyEventArgs P_1)
	{
		if (v59Cksrxw0)
		{
			_8tbFuncao.BackColor = Color.White;
			_8tbFuncao.ForeColor = Color.Black;
			if (Operators.ConditionalCompareObjectNotEqual(dg.SelectedRows[0].Cells[8].Value, _8tbFuncao.Text, TextCompare: true))
			{
				_8tbFuncao.BackColor = Color.LightGreen;
				_8tbFuncao.ForeColor = Color.Black;
			}
			editarOCabo();
		}
	}

	private void qYV4oAnLNn(object P_0, KeyEventArgs P_1)
	{
		if (v59Cksrxw0)
		{
			_9tbComprimento.BackColor = Color.White;
			_9tbComprimento.ForeColor = Color.Black;
			_9tbComprimento.Text = _9tbComprimento.Text.Trim();
			if (Operators.CompareString(_9tbComprimento.Text.Trim(), "", TextCompare: true) != 0)
			{
				if (!Versioned.IsNumeric(_9tbComprimento.Text))
				{
					_9tbComprimento.BackColor = Color.Red;
					_9tbComprimento.ForeColor = Color.White;
				}
				else
				{
					double num = Conversions.ToDouble(_9tbComprimento.Text);
					if (num >= 0.0 && Operators.CompareString(_9tbComprimento.Text.ToString(), "0.0", TextCompare: true) == 0)
					{
						_9tbComprimento.Text = "0";
					}
					if (Operators.ConditionalCompareObjectNotEqual(dg.SelectedRows[0].Cells[9].Value, Conversions.ToDouble(_9tbComprimento.Text), TextCompare: true))
					{
						_9tbComprimento.BackColor = Color.LightGreen;
						_9tbComprimento.ForeColor = Color.Black;
					}
				}
			}
			else
			{
				_9tbComprimento.BackColor = Color.Red;
				_9tbComprimento.ForeColor = Color.White;
			}
		}
		editarOCabo();
	}

	private void r814GOqhkB(object P_0, KeyEventArgs P_1)
	{
		if (v59Cksrxw0)
		{
			_10tbTrajeto.BackColor = Color.White;
			_10tbTrajeto.ForeColor = Color.Black;
			if (Operators.ConditionalCompareObjectNotEqual(dg.SelectedRows[0].Cells[10].Value, _10tbTrajeto.Text, TextCompare: true))
			{
				_10tbTrajeto.BackColor = Color.LightGreen;
				_10tbTrajeto.ForeColor = Color.Black;
			}
			editarOCabo();
		}
	}

	public void editarOCabo()
	{
		if (!((_0cbOrigem.BackColor == Color.Red) | (_1cbDestino.BackColor == Color.Red) | (_2tbCabo.BackColor == Color.Red) | (_3tbVeia.BackColor == Color.Red) | (_4tbSecao.BackColor == Color.Red) | (_5cbBlinED.BackColor == Color.Red) | (_6tbCabosED.BackColor == Color.Red) | (_7cbAterrarED.BackColor == Color.Red) | (_8tbFuncao.BackColor == Color.Red) | (_9tbComprimento.BackColor == Color.Red) | (_10lbTrajeto.BackColor == Color.Red)))
		{
			if (!((_0cbOrigem.BackColor == Color.LightGreen) | (_1cbDestino.BackColor == Color.LightGreen) | (_2tbCabo.BackColor == Color.LightGreen) | (_3tbVeia.BackColor == Color.LightGreen) | (_4tbSecao.BackColor == Color.LightGreen) | (_5cbBlinED.BackColor == Color.LightGreen) | (_6tbCabosED.BackColor == Color.LightGreen) | (_7cbAterrarED.BackColor == Color.LightGreen) | (_8tbFuncao.BackColor == Color.LightGreen) | (_9tbComprimento.BackColor == Color.LightGreen) | (_10lbTrajeto.BackColor == Color.LightGreen)))
			{
				btEditarCabo.Enabled = false;
			}
			else
			{
				btEditarCabo.Enabled = true;
			}
		}
		else
		{
			btEditarCabo.Enabled = false;
		}
	}

	private void wJj4HdDu3G(bool P_0)
	{
		if (CesCTrthCe)
		{
			PNCabos.Enabled = P_0;
			PNEditar.Enabled = P_0;
			dg.Enabled = P_0;
		}
	}

	private void y214knDCEf(object P_0, EventArgs P_1)
	{
		Hide();
		new frmAdicionaUmCabo();
		Show();
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		c01SZbL8qH(ref cDadosAccessInterligacao3);
		if (rbNaoUsados.Checked)
		{
			rbNaoUsados.Checked = false;
			rbNaoUsados.Checked = true;
		}
		cDadosAccessInterligacao3.FechaConexao();
	}

	private void GID4dAURpG(object P_0, EventArgs P_1)
	{
		if (!cbCabos.Checked)
		{
			cbPainel.Checked = true;
			return;
		}
		cbPainel.Checked = false;
		CarregaCabosNoDG();
	}

	private void CUW4ftZTMd(object P_0, EventArgs P_1)
	{
		if (!cbPainel.Checked)
		{
			cbCabos.Checked = true;
			return;
		}
		cbCabos.Checked = false;
		CarregaCabosNoDG();
	}

	private void xA74DB8MfS(object P_0, EventArgs P_1)
	{
		if (rbTrajeto.Checked)
		{
			cbPainel.Checked = true;
			cbCabos.Enabled = false;
			wJj4HdDu3G(_0020: false);
			limpaCamposDaPesquisa();
			zIVSlCQ5BM();
			w8bCGslVsP = "J";
			CarregaCabosNoDG();
			MostraEdicao(Edita: false);
			wJj4HdDu3G(_0020: true);
			btPesquisa.Enabled = false;
			btApagarCabos.Enabled = false;
			BtEditar1Cabo.Enabled = false;
			btAdicionarCabo.Enabled = false;
		}
	}
}
