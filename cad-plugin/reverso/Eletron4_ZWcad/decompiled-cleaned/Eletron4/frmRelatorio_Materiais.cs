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
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmRelatorio_Materiais : Form
{
	private IContainer GqQpajl8yWB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgEquipamentos")]
	private DataGridView fRopaL7DyGW;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btPesquisar")]
	private Button jJWpawciHnE;

	[AccessedThroughProperty("btExportaDWG")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button NS4pax20Fcx;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btExportaEXCEL")]
	[CompilerGenerated]
	private Button paApabXLy0I;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	[CompilerGenerated]
	private ToolTip lmppaMApu93;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lbMultiplicador")]
	private Label nptpaOtFhyN;

	[CompilerGenerated]
	[AccessedThroughProperty("tbMultiplicador")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox wiYpaIhUIJZ;

	[AccessedThroughProperty("GroupBox1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox UdCpa7RyJlL;

	[AccessedThroughProperty("ckCodCli")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox SGFpaq1unHJ;

	[AccessedThroughProperty("ckMesclarFabricante")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox OqRpaa4otnv;

	[AccessedThroughProperty("ckMesclarModelo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox X7Qpa8bDZr2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox2")]
	[CompilerGenerated]
	private GroupBox HVxpaNRuSkD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbIndice")]
	private TextBox fMdpaFQaSul;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("tbQuant")]
	private TextBox WfKpaQ4UqWv;

	[AccessedThroughProperty("tbTag")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox fGQpaPyOFf0;

	[AccessedThroughProperty("tbDesc")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox Ld5pach3BNJ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbMod")]
	private TextBox jUgpaKux6d4;

	[AccessedThroughProperty("tbCod")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox M9Qpae5HkmZ;

	[AccessedThroughProperty("tbFab")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox gLlpa2qQ2Np;

	[AccessedThroughProperty("lbTitulos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label lhSpa3tLVZP;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("ckMultPNDetalhado")]
	private CheckBox l91panIN7oC;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("dgListaMateriais")]
	private DataGridView oL0pa1IlawI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgOrdem")]
	private DataGridView MQKpal5P4l4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btDesagrupar")]
	private Button u5hpa5otjIT;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btSalvaOrdem")]
	private Button WR4pa0wPt5w;

	[AccessedThroughProperty("btLayout")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button vFspaRUxLnG;

	[AccessedThroughProperty("btCima")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button DWwpamd2fx3;

	[AccessedThroughProperty("btBaixo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button tmupaXSCm8I;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btUltimo")]
	[CompilerGenerated]
	private Button LTtpaUNvyiC;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btPrimeiro")]
	private Button xeVpayNY7wK;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox3")]
	private GroupBox HwcpagwHZtZ;

	[CompilerGenerated]
	[AccessedThroughProperty("CBMultiselecao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CheckBox rfCpaAOghQs;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RBResumida")]
	private RadioButton xaTpasYvgUs;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RBCompleta")]
	private RadioButton ywlpaBk0CPZ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btApagarDWG")]
	private Button In3paVXqj6C;

	[AccessedThroughProperty("GroupBox4")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox addpauNVIwW;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTY")]
	[CompilerGenerated]
	private Button vmtpaEDnmGR;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("tbOrdenadaY")]
	private TextBox qCqpaZWOrlV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lPTIni")]
	private Label yE9paimd0NX;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox5")]
	private GroupBox a2NpaSIIrxF;

	[AccessedThroughProperty("ckExcel2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton Dsypa4kptny;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ckDWG2")]
	[CompilerGenerated]
	private RadioButton QCvpaCrtphG;

	private cDadosLM.structureLMRelelatorio[] Pk1paY7xAmn;

	private cDadosLM.indexCODMateriais[] THXparyRhRU;

	private int TDjpa9XgJFk;

	private string g9tpazCIEIQ;

	private string[,] qm3p8W7hv4t;

	private bool rNAp8pXyJhm;

	private cDadosLM.structureOrdemDispLM[] VVSp8T8uyHj;

	private bool TYAp8J6HKN8;

	private List<string> xyEp8hmNnKa;

	private bool ccsp8oYUGpg;

	private int MEKp8GZ0rpb;

	private int K0Sp8HmEWJm;

	private int KJ6p8klQ5aE;

	private int OKgp8dKLsOu;

	private int B2Op8f9oZjy;

	internal virtual DataGridView dgEquipamentos
	{
		[CompilerGenerated]
		get
		{
			return fRopaL7DyGW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = jbepqXUHPNp;
			EventHandler value3 = SqFpqUrVVjm;
			DataGridView dataGridView = fRopaL7DyGW;
			if (dataGridView != null)
			{
				dataGridView.MouseClick -= value2;
				dataGridView.SelectionChanged -= value3;
			}
			fRopaL7DyGW = value;
			dataGridView = fRopaL7DyGW;
			if (dataGridView != null)
			{
				dataGridView.MouseClick += value2;
				dataGridView.SelectionChanged += value3;
			}
		}
	}

	internal virtual Button btPesquisar
	{
		[CompilerGenerated]
		get
		{
			return jJWpawciHnE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = sU4pq5JpQQR;
			Button button = jJWpawciHnE;
			if (button != null)
			{
				button.Click -= value2;
			}
			jJWpawciHnE = value;
			button = jJWpawciHnE;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btExportaDWG
	{
		[CompilerGenerated]
		get
		{
			return NS4pax20Fcx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = De4pq0wdi78;
			Button button = NS4pax20Fcx;
			if (button != null)
			{
				button.Click -= value2;
			}
			NS4pax20Fcx = value;
			button = NS4pax20Fcx;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btExportaEXCEL
	{
		[CompilerGenerated]
		get
		{
			return paApabXLy0I;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Pw5pqRF4yEU;
			Button button = paApabXLy0I;
			if (button != null)
			{
				button.Click -= value2;
			}
			paApabXLy0I = value;
			button = paApabXLy0I;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label lbMultiplicador
	{
		[CompilerGenerated]
		get
		{
			return nptpaOtFhyN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			nptpaOtFhyN = value;
		}
	}

	internal virtual TextBox tbMultiplicador
	{
		[CompilerGenerated]
		get
		{
			return wiYpaIhUIJZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = zSCpqACDQ3i;
			TextBox textBox = wiYpaIhUIJZ;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			wiYpaIhUIJZ = value;
			textBox = wiYpaIhUIJZ;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox1
	{
		[CompilerGenerated]
		get
		{
			return UdCpa7RyJlL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			UdCpa7RyJlL = value;
		}
	}

	internal virtual CheckBox ckCodCli
	{
		[CompilerGenerated]
		get
		{
			return SGFpaq1unHJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RrPpqV6CfHu;
			CheckBox checkBox = SGFpaq1unHJ;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			SGFpaq1unHJ = value;
			checkBox = SGFpaq1unHJ;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox ckMesclarFabricante
	{
		[CompilerGenerated]
		get
		{
			return OqRpaa4otnv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Nsipq98nO0Y;
			CheckBox checkBox = OqRpaa4otnv;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			OqRpaa4otnv = value;
			checkBox = OqRpaa4otnv;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual CheckBox ckMesclarModelo
	{
		[CompilerGenerated]
		get
		{
			return X7Qpa8bDZr2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Vv6pqrjPwAY;
			CheckBox checkBox = X7Qpa8bDZr2;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			X7Qpa8bDZr2 = value;
			checkBox = X7Qpa8bDZr2;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return HVxpaNRuSkD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			HVxpaNRuSkD = value;
		}
	}

	internal virtual TextBox tbIndice
	{
		[CompilerGenerated]
		get
		{
			return fMdpaFQaSul;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			fMdpaFQaSul = value;
		}
	}

	internal virtual TextBox tbQuant
	{
		[CompilerGenerated]
		get
		{
			return WfKpaQ4UqWv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			WfKpaQ4UqWv = value;
		}
	}

	internal virtual TextBox tbTag
	{
		[CompilerGenerated]
		get
		{
			return fGQpaPyOFf0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			fGQpaPyOFf0 = value;
		}
	}

	internal virtual TextBox tbDesc
	{
		[CompilerGenerated]
		get
		{
			return Ld5pach3BNJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Ld5pach3BNJ = value;
		}
	}

	internal virtual TextBox tbMod
	{
		[CompilerGenerated]
		get
		{
			return jUgpaKux6d4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jUgpaKux6d4 = value;
		}
	}

	internal virtual TextBox tbCod
	{
		[CompilerGenerated]
		get
		{
			return M9Qpae5HkmZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			M9Qpae5HkmZ = value;
		}
	}

	internal virtual TextBox tbFab
	{
		[CompilerGenerated]
		get
		{
			return gLlpa2qQ2Np;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			gLlpa2qQ2Np = value;
		}
	}

	internal virtual Label lbTitulos
	{
		[CompilerGenerated]
		get
		{
			return lhSpa3tLVZP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			lhSpa3tLVZP = value;
		}
	}

	internal virtual CheckBox ckMultPNDetalhado
	{
		[CompilerGenerated]
		get
		{
			return l91panIN7oC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = dy6pqua5o7u;
			CheckBox checkBox = l91panIN7oC;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			l91panIN7oC = value;
			checkBox = l91panIN7oC;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual DataGridView dgListaMateriais
	{
		[CompilerGenerated]
		get
		{
			return oL0pa1IlawI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = nP1pq4TuwLk;
			DragEventHandler value3 = TRDpqC6FU7B;
			DragEventHandler value4 = m1ApqY2HIuu;
			DataGridView dataGridView = oL0pa1IlawI;
			if (dataGridView != null)
			{
				dataGridView.MouseDown -= value2;
				dataGridView.DragEnter -= value3;
				dataGridView.DragDrop -= value4;
			}
			oL0pa1IlawI = value;
			dataGridView = oL0pa1IlawI;
			if (dataGridView != null)
			{
				dataGridView.MouseDown += value2;
				dataGridView.DragEnter += value3;
				dataGridView.DragDrop += value4;
			}
		}
	}

	internal virtual DataGridView dgOrdem
	{
		[CompilerGenerated]
		get
		{
			return MQKpal5P4l4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = KJxpqZIUAA5;
			DragEventHandler value3 = eVhpqiq3HXy;
			DragEventHandler value4 = FPWpqScPECI;
			DataGridView dataGridView = MQKpal5P4l4;
			if (dataGridView != null)
			{
				dataGridView.MouseDown -= value2;
				dataGridView.DragEnter -= value3;
				dataGridView.DragDrop -= value4;
			}
			MQKpal5P4l4 = value;
			dataGridView = MQKpal5P4l4;
			if (dataGridView != null)
			{
				dataGridView.MouseDown += value2;
				dataGridView.DragEnter += value3;
				dataGridView.DragDrop += value4;
			}
		}
	}

	internal virtual Button btDesagrupar
	{
		[CompilerGenerated]
		get
		{
			return u5hpa5otjIT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Jd4pqznryRo;
			Button button = u5hpa5otjIT;
			if (button != null)
			{
				button.Click -= value2;
			}
			u5hpa5otjIT = value;
			button = u5hpa5otjIT;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btSalvaOrdem
	{
		[CompilerGenerated]
		get
		{
			return WR4pa0wPt5w;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = l4VpaWjlNPo;
			Button button = WR4pa0wPt5w;
			if (button != null)
			{
				button.Click -= value2;
			}
			WR4pa0wPt5w = value;
			button = WR4pa0wPt5w;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btLayout
	{
		[CompilerGenerated]
		get
		{
			return vFspaRUxLnG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ybZpapLj871;
			Button button = vFspaRUxLnG;
			if (button != null)
			{
				button.Click -= value2;
			}
			vFspaRUxLnG = value;
			button = vFspaRUxLnG;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btCima
	{
		[CompilerGenerated]
		get
		{
			return DWwpamd2fx3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = kJypaJOMRmr;
			Button button = DWwpamd2fx3;
			if (button != null)
			{
				button.Click -= value2;
			}
			DWwpamd2fx3 = value;
			button = DWwpamd2fx3;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btBaixo
	{
		[CompilerGenerated]
		get
		{
			return tmupaXSCm8I;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RfJpahh2fqX;
			Button button = tmupaXSCm8I;
			if (button != null)
			{
				button.Click -= value2;
			}
			tmupaXSCm8I = value;
			button = tmupaXSCm8I;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btUltimo
	{
		[CompilerGenerated]
		get
		{
			return LTtpaUNvyiC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = HvUpaoZYPkx;
			Button button = LTtpaUNvyiC;
			if (button != null)
			{
				button.Click -= value2;
			}
			LTtpaUNvyiC = value;
			button = LTtpaUNvyiC;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btPrimeiro
	{
		[CompilerGenerated]
		get
		{
			return xeVpayNY7wK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = y97paTywJWT;
			Button button = xeVpayNY7wK;
			if (button != null)
			{
				button.Click -= value2;
			}
			xeVpayNY7wK = value;
			button = xeVpayNY7wK;
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
			return HwcpagwHZtZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			HwcpagwHZtZ = value;
		}
	}

	internal virtual CheckBox CBMultiselecao
	{
		[CompilerGenerated]
		get
		{
			return rfCpaAOghQs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = cXQpaGUsTFh;
			CheckBox checkBox = rfCpaAOghQs;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			rfCpaAOghQs = value;
			checkBox = rfCpaAOghQs;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton RBResumida
	{
		[CompilerGenerated]
		get
		{
			return xaTpasYvgUs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = uuIpakXP0Uf;
			RadioButton radioButton = xaTpasYvgUs;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			xaTpasYvgUs = value;
			radioButton = xaTpasYvgUs;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton RBCompleta
	{
		[CompilerGenerated]
		get
		{
			return ywlpaBk0CPZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = hqBpaHC61tu;
			RadioButton radioButton = ywlpaBk0CPZ;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			ywlpaBk0CPZ = value;
			radioButton = ywlpaBk0CPZ;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button btApagarDWG
	{
		[CompilerGenerated]
		get
		{
			return In3paVXqj6C;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = j1Epa6RtRJQ;
			Button button = In3paVXqj6C;
			if (button != null)
			{
				button.Click -= value2;
			}
			In3paVXqj6C = value;
			button = In3paVXqj6C;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox4
	{
		[CompilerGenerated]
		get
		{
			return addpauNVIwW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			addpauNVIwW = value;
		}
	}

	internal virtual Button BTY
	{
		[CompilerGenerated]
		get
		{
			return vmtpaEDnmGR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Yqypat99uY0;
			Button button = vmtpaEDnmGR;
			if (button != null)
			{
				button.Click -= value2;
			}
			vmtpaEDnmGR = value;
			button = vmtpaEDnmGR;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox tbOrdenadaY
	{
		[CompilerGenerated]
		get
		{
			return qCqpaZWOrlV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qCqpaZWOrlV = value;
		}
	}

	internal virtual Label lPTIni
	{
		[CompilerGenerated]
		get
		{
			return yE9paimd0NX;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			yE9paimd0NX = value;
		}
	}

	internal virtual GroupBox GroupBox5
	{
		[CompilerGenerated]
		get
		{
			return a2NpaSIIrxF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			a2NpaSIIrxF = value;
		}
	}

	internal virtual RadioButton ckExcel2
	{
		[CompilerGenerated]
		get
		{
			return Dsypa4kptny;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Wm2pafAYYQj;
			RadioButton radioButton = Dsypa4kptny;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			Dsypa4kptny = value;
			radioButton = Dsypa4kptny;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton ckDWG2
	{
		[CompilerGenerated]
		get
		{
			return QCvpaCrtphG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = hMTpavHJfPB;
			RadioButton radioButton = QCvpaCrtphG;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			QCvpaCrtphG = value;
			radioButton = QCvpaCrtphG;
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
			if (disposing && GqQpajl8yWB != null)
			{
				GqQpajl8yWB.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void uhOpqlKtUUo()
	{
		GqQpajl8yWB = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmRelatorio_Materiais));
		dgEquipamentos = new DataGridView();
		btPesquisar = new Button();
		btExportaDWG = new Button();
		btExportaEXCEL = new Button();
		FDqpBiUmZij(new ToolTip(GqQpajl8yWB));
		lbMultiplicador = new Label();
		tbMultiplicador = new TextBox();
		GroupBox1 = new GroupBox();
		ckCodCli = new CheckBox();
		ckMesclarFabricante = new CheckBox();
		ckMesclarModelo = new CheckBox();
		GroupBox2 = new GroupBox();
		RBResumida = new RadioButton();
		RBCompleta = new RadioButton();
		tbIndice = new TextBox();
		tbQuant = new TextBox();
		tbTag = new TextBox();
		tbDesc = new TextBox();
		tbMod = new TextBox();
		tbCod = new TextBox();
		tbFab = new TextBox();
		lbTitulos = new Label();
		ckMultPNDetalhado = new CheckBox();
		dgListaMateriais = new DataGridView();
		dgOrdem = new DataGridView();
		btDesagrupar = new Button();
		btSalvaOrdem = new Button();
		btLayout = new Button();
		btCima = new Button();
		btBaixo = new Button();
		btUltimo = new Button();
		btPrimeiro = new Button();
		GroupBox3 = new GroupBox();
		CBMultiselecao = new CheckBox();
		btApagarDWG = new Button();
		GroupBox4 = new GroupBox();
		BTY = new Button();
		tbOrdenadaY = new TextBox();
		lPTIni = new Label();
		GroupBox5 = new GroupBox();
		ckExcel2 = new RadioButton();
		ckDWG2 = new RadioButton();
		((ISupportInitialize)dgEquipamentos).BeginInit();
		GroupBox1.SuspendLayout();
		GroupBox2.SuspendLayout();
		((ISupportInitialize)dgListaMateriais).BeginInit();
		((ISupportInitialize)dgOrdem).BeginInit();
		GroupBox3.SuspendLayout();
		GroupBox4.SuspendLayout();
		GroupBox5.SuspendLayout();
		SuspendLayout();
		dgEquipamentos.AllowUserToAddRows = false;
		dgEquipamentos.AllowUserToDeleteRows = false;
		dgEquipamentos.AllowUserToOrderColumns = true;
		dgEquipamentos.AllowUserToResizeRows = false;
		dgEquipamentos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgEquipamentos.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgEquipamentos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgEquipamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgEquipamentos.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgEquipamentos.Location = new Point(5, 5);
		dgEquipamentos.MultiSelect = false;
		dgEquipamentos.Name = "dgEquipamentos";
		dgEquipamentos.ReadOnly = true;
		dgEquipamentos.RowHeadersVisible = false;
		dgEquipamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquipamentos.Size = new Size(144, 370);
		dgEquipamentos.TabIndex = 8;
		btPesquisar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btPesquisar.FlatStyle = FlatStyle.Flat;
		btPesquisar.ForeColor = SystemColors.Control;
		btPesquisar.Image = Resources.Pesquisar_32;
		btPesquisar.Location = new Point(775, 358);
		btPesquisar.Name = "btPesquisar";
		btPesquisar.Size = new Size(40, 42);
		btPesquisar.TabIndex = 15;
		btPesquisar.UseVisualStyleBackColor = true;
		btExportaDWG.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btExportaDWG.FlatStyle = FlatStyle.Flat;
		btExportaDWG.ForeColor = SystemColors.Control;
		btExportaDWG.Image = (Image)componentResourceManager.GetObject("btExportaDWG.Image");
		btExportaDWG.Location = new Point(891, 358);
		btExportaDWG.Name = "btExportaDWG";
		btExportaDWG.Size = new Size(40, 42);
		btExportaDWG.TabIndex = 40;
		btExportaDWG.UseVisualStyleBackColor = true;
		btExportaEXCEL.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btExportaEXCEL.FlatStyle = FlatStyle.Flat;
		btExportaEXCEL.ForeColor = SystemColors.Control;
		btExportaEXCEL.Image = Resources.Excel_32;
		btExportaEXCEL.Location = new Point(833, 358);
		btExportaEXCEL.Name = "btExportaEXCEL";
		btExportaEXCEL.Size = new Size(40, 42);
		btExportaEXCEL.TabIndex = 41;
		btExportaEXCEL.UseVisualStyleBackColor = true;
		lbMultiplicador.Location = new Point(6, 21);
		lbMultiplicador.Name = "lbMultiplicador";
		lbMultiplicador.Size = new Size(150, 22);
		lbMultiplicador.TabIndex = 142;
		lbMultiplicador.Text = "lbFator de Multiplicação";
		tbMultiplicador.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbMultiplicador.Location = new Point(162, 19);
		tbMultiplicador.Name = "tbMultiplicador";
		tbMultiplicador.Size = new Size(57, 20);
		tbMultiplicador.TabIndex = 141;
		GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox1.Controls.Add(lbMultiplicador);
		GroupBox1.Controls.Add(tbMultiplicador);
		GroupBox1.Location = new Point(458, 105);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(238, 49);
		GroupBox1.TabIndex = 143;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "gbMultiplicador de Típicos";
		ckCodCli.AutoSize = true;
		ckCodCli.Location = new Point(160, 64);
		ckCodCli.Name = "ckCodCli";
		ckCodCli.Size = new Size(82, 17);
		ckCodCli.TabIndex = 150;
		ckCodCli.Text = "ckCodigoCli";
		ckCodCli.UseVisualStyleBackColor = true;
		ckMesclarFabricante.AutoSize = true;
		ckMesclarFabricante.Location = new Point(160, 42);
		ckMesclarFabricante.Name = "ckMesclarFabricante";
		ckMesclarFabricante.Size = new Size(125, 17);
		ckMesclarFabricante.TabIndex = 152;
		ckMesclarFabricante.Text = "ckMesclarFabricante";
		ckMesclarFabricante.UseVisualStyleBackColor = true;
		ckMesclarModelo.AutoSize = true;
		ckMesclarModelo.Location = new Point(160, 19);
		ckMesclarModelo.Name = "ckMesclarModelo";
		ckMesclarModelo.Size = new Size(110, 17);
		ckMesclarModelo.TabIndex = 151;
		ckMesclarModelo.Text = "ckMesclarModelo";
		ckMesclarModelo.UseVisualStyleBackColor = true;
		GroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox2.Controls.Add(RBResumida);
		GroupBox2.Controls.Add(RBCompleta);
		GroupBox2.Controls.Add(ckMesclarFabricante);
		GroupBox2.Controls.Add(ckMesclarModelo);
		GroupBox2.Controls.Add(ckCodCli);
		GroupBox2.Location = new Point(382, 335);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(370, 87);
		GroupBox2.TabIndex = 153;
		GroupBox2.TabStop = false;
		RBResumida.AutoSize = true;
		RBResumida.Location = new Point(11, 41);
		RBResumida.Name = "RBResumida";
		RBResumida.Size = new Size(87, 17);
		RBResumida.TabIndex = 154;
		RBResumida.Text = "RBResumida";
		RBResumida.UseVisualStyleBackColor = true;
		RBCompleta.AutoSize = true;
		RBCompleta.Checked = true;
		RBCompleta.Location = new Point(11, 18);
		RBCompleta.Name = "RBCompleta";
		RBCompleta.Size = new Size(84, 17);
		RBCompleta.TabIndex = 153;
		RBCompleta.TabStop = true;
		RBCompleta.Text = "RBCompleta";
		RBCompleta.UseVisualStyleBackColor = true;
		tbIndice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		tbIndice.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbIndice.Location = new Point(385, 309);
		tbIndice.Name = "tbIndice";
		tbIndice.Size = new Size(50, 20);
		tbIndice.TabIndex = 154;
		tbQuant.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		tbQuant.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbQuant.Location = new Point(441, 309);
		tbQuant.Name = "tbQuant";
		tbQuant.Size = new Size(70, 20);
		tbQuant.TabIndex = 155;
		tbTag.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		tbTag.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbTag.Location = new Point(517, 309);
		tbTag.Name = "tbTag";
		tbTag.Size = new Size(70, 20);
		tbTag.TabIndex = 156;
		tbDesc.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		tbDesc.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbDesc.Location = new Point(593, 309);
		tbDesc.Name = "tbDesc";
		tbDesc.Size = new Size(70, 20);
		tbDesc.TabIndex = 157;
		tbMod.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		tbMod.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbMod.Location = new Point(669, 309);
		tbMod.Name = "tbMod";
		tbMod.Size = new Size(70, 20);
		tbMod.TabIndex = 158;
		tbCod.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		tbCod.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbCod.Location = new Point(821, 309);
		tbCod.Name = "tbCod";
		tbCod.Size = new Size(104, 20);
		tbCod.TabIndex = 160;
		tbFab.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		tbFab.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		tbFab.Location = new Point(745, 309);
		tbFab.Name = "tbFab";
		tbFab.Size = new Size(70, 20);
		tbFab.TabIndex = 159;
		lbTitulos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		lbTitulos.Location = new Point(387, 289);
		lbTitulos.Name = "lbTitulos";
		lbTitulos.Size = new Size(124, 17);
		lbTitulos.TabIndex = 162;
		lbTitulos.Text = "lbTitulos";
		ckMultPNDetalhado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		ckMultPNDetalhado.AutoSize = true;
		ckMultPNDetalhado.Location = new Point(7, 20);
		ckMultPNDetalhado.Name = "ckMultPNDetalhado";
		ckMultPNDetalhado.Size = new Size(122, 17);
		ckMultPNDetalhado.TabIndex = 151;
		ckMultPNDetalhado.Text = "ckMultPNDetalhado";
		ckMultPNDetalhado.UseVisualStyleBackColor = true;
		dgListaMateriais.AllowDrop = true;
		dgListaMateriais.AllowUserToAddRows = false;
		dgListaMateriais.AllowUserToDeleteRows = false;
		dgListaMateriais.AllowUserToResizeRows = false;
		dgListaMateriais.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgListaMateriais.BackgroundColor = Color.White;
		dgListaMateriais.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgListaMateriais.Location = new Point(382, 5);
		dgListaMateriais.MultiSelect = false;
		dgListaMateriais.Name = "dgListaMateriais";
		dgListaMateriais.RowHeadersVisible = false;
		dgListaMateriais.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgListaMateriais.Size = new Size(612, 281);
		dgListaMateriais.TabIndex = 177;
		dgOrdem.AllowDrop = true;
		dgOrdem.AllowUserToAddRows = false;
		dgOrdem.AllowUserToDeleteRows = false;
		dgOrdem.AllowUserToResizeRows = false;
		dgOrdem.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgOrdem.BackgroundColor = Color.White;
		dgOrdem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgOrdem.Location = new Point(155, 5);
		dgOrdem.MultiSelect = false;
		dgOrdem.Name = "dgOrdem";
		dgOrdem.RowHeadersVisible = false;
		dgOrdem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgOrdem.Size = new Size(192, 265);
		dgOrdem.TabIndex = 180;
		btDesagrupar.Enabled = false;
		btDesagrupar.Location = new Point(5, 44);
		btDesagrupar.Name = "btDesagrupar";
		btDesagrupar.Size = new Size(109, 23);
		btDesagrupar.TabIndex = 182;
		btDesagrupar.Text = "btDesagrupar";
		btDesagrupar.UseVisualStyleBackColor = true;
		btSalvaOrdem.FlatStyle = FlatStyle.Flat;
		btSalvaOrdem.ForeColor = SystemColors.Control;
		btSalvaOrdem.Image = Resources.Salvar_;
		btSalvaOrdem.Location = new Point(140, 48);
		btSalvaOrdem.Name = "btSalvaOrdem";
		btSalvaOrdem.Size = new Size(40, 42);
		btSalvaOrdem.TabIndex = 185;
		btSalvaOrdem.UseVisualStyleBackColor = true;
		btLayout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btLayout.Location = new Point(5, 72);
		btLayout.Name = "btLayout";
		btLayout.Size = new Size(109, 23);
		btLayout.TabIndex = 182;
		btLayout.Text = "btLayout";
		btLayout.UseVisualStyleBackColor = true;
		btCima.Anchor = AnchorStyles.Left;
		btCima.Image = Resources.Cima_16;
		btCima.Location = new Point(352, 124);
		btCima.Name = "btCima";
		btCima.Size = new Size(23, 23);
		btCima.TabIndex = 186;
		btCima.UseVisualStyleBackColor = true;
		btBaixo.Anchor = AnchorStyles.Left;
		btBaixo.Image = Resources.Baixo_16;
		btBaixo.Location = new Point(352, 153);
		btBaixo.Name = "btBaixo";
		btBaixo.Size = new Size(23, 23);
		btBaixo.TabIndex = 187;
		btBaixo.UseVisualStyleBackColor = true;
		btUltimo.Anchor = AnchorStyles.Left;
		btUltimo.Image = Resources.Ultimo_16;
		btUltimo.Location = new Point(353, 182);
		btUltimo.Name = "btUltimo";
		btUltimo.Size = new Size(23, 23);
		btUltimo.TabIndex = 189;
		btUltimo.UseVisualStyleBackColor = true;
		btPrimeiro.Anchor = AnchorStyles.Left;
		btPrimeiro.Image = Resources.Primeiro_16;
		btPrimeiro.Location = new Point(353, 95);
		btPrimeiro.Name = "btPrimeiro";
		btPrimeiro.Size = new Size(23, 23);
		btPrimeiro.TabIndex = 188;
		btPrimeiro.UseVisualStyleBackColor = true;
		GroupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox3.Controls.Add(CBMultiselecao);
		GroupBox3.Controls.Add(btDesagrupar);
		GroupBox3.Controls.Add(btLayout);
		GroupBox3.Controls.Add(btSalvaOrdem);
		GroupBox3.Location = new Point(155, 272);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(192, 103);
		GroupBox3.TabIndex = 190;
		GroupBox3.TabStop = false;
		CBMultiselecao.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		CBMultiselecao.AutoSize = true;
		CBMultiselecao.Location = new Point(7, 12);
		CBMultiselecao.Name = "CBMultiselecao";
		CBMultiselecao.Size = new Size(81, 17);
		CBMultiselecao.TabIndex = 186;
		CBMultiselecao.Text = "CheckBox1";
		CBMultiselecao.UseVisualStyleBackColor = true;
		btApagarDWG.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		btApagarDWG.FlatStyle = FlatStyle.Flat;
		btApagarDWG.ForeColor = SystemColors.Control;
		btApagarDWG.Image = Resources.Delete_32;
		btApagarDWG.Location = new Point(949, 358);
		btApagarDWG.Name = "btApagarDWG";
		btApagarDWG.Size = new Size(40, 42);
		btApagarDWG.TabIndex = 194;
		btApagarDWG.UseVisualStyleBackColor = true;
		GroupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox4.Controls.Add(BTY);
		GroupBox4.Controls.Add(tbOrdenadaY);
		GroupBox4.Controls.Add(lPTIni);
		GroupBox4.Location = new Point(113, 157);
		GroupBox4.Name = "GroupBox4";
		GroupBox4.Size = new Size(191, 103);
		GroupBox4.TabIndex = 195;
		GroupBox4.TabStop = false;
		BTY.FlatStyle = FlatStyle.Flat;
		BTY.ForeColor = SystemColors.Control;
		BTY.Image = Resources.Altura;
		BTY.Location = new Point(124, 39);
		BTY.Name = "BTY";
		BTY.Size = new Size(40, 40);
		BTY.TabIndex = 210;
		BTY.UseVisualStyleBackColor = true;
		tbOrdenadaY.BackColor = SystemColors.ActiveBorder;
		tbOrdenadaY.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		tbOrdenadaY.ForeColor = SystemColors.MenuText;
		tbOrdenadaY.Location = new Point(48, 53);
		tbOrdenadaY.Name = "tbOrdenadaY";
		tbOrdenadaY.ReadOnly = true;
		tbOrdenadaY.Size = new Size(61, 20);
		tbOrdenadaY.TabIndex = 209;
		tbOrdenadaY.Text = "20";
		tbOrdenadaY.TextAlign = HorizontalAlignment.Center;
		lPTIni.AutoSize = true;
		lPTIni.ImageAlign = ContentAlignment.MiddleRight;
		lPTIni.Location = new Point(7, 17);
		lPTIni.Name = "lPTIni";
		lPTIni.Size = new Size(124, 13);
		lPTIni.TabIndex = 208;
		lPTIni.Text = "Ponto inicial do Relatório";
		lPTIni.TextAlign = ContentAlignment.MiddleRight;
		GroupBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox5.Controls.Add(ckExcel2);
		GroupBox5.Controls.Add(ckDWG2);
		GroupBox5.Controls.Add(ckMultPNDetalhado);
		GroupBox5.Location = new Point(5, 376);
		GroupBox5.Name = "GroupBox5";
		GroupBox5.Size = new Size(342, 49);
		GroupBox5.TabIndex = 196;
		GroupBox5.TabStop = false;
		ckExcel2.AutoSize = true;
		ckExcel2.Checked = true;
		ckExcel2.Location = new Point(279, 19);
		ckExcel2.Name = "ckExcel2";
		ckExcel2.Size = new Size(51, 17);
		ckExcel2.TabIndex = 155;
		ckExcel2.TabStop = true;
		ckExcel2.Text = "Excel";
		ckExcel2.UseVisualStyleBackColor = true;
		ckDWG2.AutoSize = true;
		ckDWG2.Location = new Point(221, 19);
		ckDWG2.Name = "ckDWG2";
		ckDWG2.Size = new Size(52, 17);
		ckDWG2.TabIndex = 154;
		ckDWG2.Text = "DWG";
		ckDWG2.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(1002, 428);
		Controls.Add(GroupBox5);
		Controls.Add(GroupBox4);
		Controls.Add(GroupBox3);
		Controls.Add(btUltimo);
		Controls.Add(dgOrdem);
		Controls.Add(GroupBox1);
		Controls.Add(btPrimeiro);
		Controls.Add(dgListaMateriais);
		Controls.Add(btBaixo);
		Controls.Add(lbTitulos);
		Controls.Add(btCima);
		Controls.Add(tbCod);
		Controls.Add(GroupBox2);
		Controls.Add(tbFab);
		Controls.Add(tbMod);
		Controls.Add(tbIndice);
		Controls.Add(tbQuant);
		Controls.Add(btExportaDWG);
		Controls.Add(tbTag);
		Controls.Add(tbDesc);
		Controls.Add(btPesquisar);
		Controls.Add(dgEquipamentos);
		Controls.Add(btApagarDWG);
		Controls.Add(btExportaEXCEL);
		MinimumSize = new Size(1018, 400);
		Name = "frmRelatorio_Materiais";
		ShowInTaskbar = false;
		Text = " ";
		((ISupportInitialize)dgEquipamentos).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox1.PerformLayout();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		((ISupportInitialize)dgListaMateriais).EndInit();
		((ISupportInitialize)dgOrdem).EndInit();
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox3.PerformLayout();
		GroupBox4.ResumeLayout(performLayout: false);
		GroupBox4.PerformLayout();
		GroupBox5.ResumeLayout(performLayout: false);
		GroupBox5.PerformLayout();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return lmppaMApu93;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		lmppaMApu93 = WithEventsValue;
	}

	public frmRelatorio_Materiais()
	{
		Resize += Qr6pqB15Q0U;
		Pk1paY7xAmn = null;
		THXparyRhRU = null;
		TDjpa9XgJFk = 0;
		g9tpazCIEIQ = "";
		qm3p8W7hv4t = null;
		rNAp8pXyJhm = false;
		VVSp8T8uyHj = null;
		TYAp8J6HKN8 = false;
		xyEp8hmNnKa = new List<string>();
		ccsp8oYUGpg = false;
		MEKp8GZ0rpb = 0;
		K0Sp8HmEWJm = 0;
		KJ6p8klQ5aE = 0;
		OKgp8dKLsOu = 0;
		B2Op8f9oZjy = 0;
		try
		{
			if (!Geral.ExisteForm("frmRelatorio_Materiais"))
			{
				uhOpqlKtUUo();
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1207]);
				GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1208]);
				lbMultiplicador.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1209]);
				ckMesclarModelo.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1212]);
				ckMesclarFabricante.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1213]);
				ckCodCli.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1163]);
				ckMultPNDetalhado.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1224]);
				CBMultiselecao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 14]);
				btDesagrupar.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1275]);
				btLayout.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 795]);
				RBCompleta.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 247]);
				RBResumida.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 246]);
				lPTIni.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1908]);
				GroupBox1.Visible = false;
				w8dpBZ0kvSD().SetToolTip(btPesquisar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1211]));
				w8dpBZ0kvSD().SetToolTip(btExportaDWG, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1214]));
				w8dpBZ0kvSD().SetToolTip(btExportaEXCEL, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1215]));
				w8dpBZ0kvSD().SetToolTip(btSalvaOrdem, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1477]));
				w8dpBZ0kvSD().SetToolTip(BTY, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1598]));
				Pk1paY7xAmn = new cDadosLM.structureLMRelelatorio[1];
				GroupBox2.Text = "";
				Application.ShowModelessDialog((Form)this);
				tbMultiplicador.Text = Conversions.ToString(1);
				x0npqmuPsyI();
				lbTitulos.Text = DeclaracoesGeral.mMensagem[1, 1219].ToString();
				tbIndice.Text = DeclaracoesGeral.mMensagem[1, 915].ToString();
				tbQuant.Text = DeclaracoesGeral.mMensagem[1, 1218].ToString();
				tbTag.Text = DeclaracoesGeral.mMensagem[1, 176].ToString();
				tbDesc.Text = DeclaracoesGeral.mMensagem[1, 64].ToString();
				tbMod.Text = DeclaracoesGeral.mMensagem[1, 654].ToString();
				tbFab.Text = DeclaracoesGeral.mMensagem[1, 1169].ToString();
				tbCod.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1163]);
				GroupBox4.Location = new Point(GroupBox3.Location.X, GroupBox3.Location.Y);
				GroupBox4.Visible = false;
				btSalvaOrdem.Enabled = false;
				dgOrdem.Rows.Clear();
				dgOrdem.Columns.Clear();
				tbMultiplicador.Enabled = false;
				dgEquipamentos.MultiSelect = false;
				tbCod.Visible = false;
				ckExcel2.Visible = false;
				ckDWG2.Visible = false;
				btExportaDWG.Enabled = true;
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

	private void sU4pq5JpQQR(object P_0, EventArgs P_1)
	{
		btPesquisar.Enabled = false;
		xyEp8hmNnKa.Clear();
		checked
		{
			int num = dgOrdem.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgOrdem.Rows[i].Cells[0].Style.BackColor == Color.LightCoral)
				{
					xyEp8hmNnKa.Add(dgOrdem.Rows[i].Cells[1].Value.ToString());
				}
			}
			mZGpqsaJEfm();
			int num2 = 0;
			THXparyRhRU = new cDadosLM.indexCODMateriais[1];
			int num3 = Information.UBound(Pk1paY7xAmn);
			for (int j = 1; j <= num3; j++)
			{
				num2++;
				ref cDadosLM.indexCODMateriais[] tHXparyRhRU = ref THXparyRhRU;
				tHXparyRhRU = (cDadosLM.indexCODMateriais[])Utils.CopyArray(tHXparyRhRU, new cDadosLM.indexCODMateriais[num2 + 1]);
				THXparyRhRU[num2].indexLM = Conversions.ToInteger(Pk1paY7xAmn[j].IndexLM);
				THXparyRhRU[num2].indice = j;
			}
			btPesquisar.Enabled = true;
			verificaNumeracao();
			DataGridView dg = dgListaMateriais;
			Attt(ref dg);
			dgListaMateriais = dg;
		}
	}

	public void verificaNumeracao()
	{
		if (!(ckMultPNDetalhado.Checked & ckDWG2.Checked))
		{
			return;
		}
		int num = Relatorios_MateriaisDWG.BuscaMaiorIndiceRelatorioMateriais(ref TDjpa9XgJFk);
		checked
		{
			if (num > -1)
			{
				int num2 = dgListaMateriais.Rows.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					num++;
					dgListaMateriais.Rows[i].Cells[0].Value = num;
				}
			}
		}
	}

	private void De4pq0wdi78(object P_0, EventArgs P_1)
	{
		string pag = DeclaracoesGeral.ativo.Pagina;
		checked
		{
			if (ckMultPNDetalhado.Checked)
			{
				int num = dgListaMateriais.ColumnCount - 1;
				for (int i = num; i >= 0; i += -1)
				{
					if (!dgListaMateriais.Columns[i].Visible)
					{
						dgListaMateriais.Columns.RemoveAt(i);
					}
				}
				if (dgEquipamentos.RowCount > 0)
				{
					ConfRelelatorioMulti confRelMateriais = new ConfRelelatorioMulti
					{
						TamanhoFonte = 1.5,
						QuantColunas = 1,
						AlturaInicial = Conversions.ToDouble(tbOrdenadaY.Text) - 5.0,
						sFonte = "Romans",
						DistEntreColunas = 0.0,
						AlturaDoBloco = 7.0
					};
					TDjpa9XgJFk = 0;
					Relatorios_MateriaisMULTI_DWG.CriaRelMateriaisDWG(dgListaMateriais, confRelMateriais, ref TDjpa9XgJFk, MEKp8GZ0rpb);
				}
			}
			else
			{
				if (dgListaMateriais.Rows.Count == 0)
				{
					return;
				}
				ReCarregaMatriz(dgListaMateriais, ref Pk1paY7xAmn);
				Pk1paY7xAmn[0].Index = tbIndice.Text;
				Pk1paY7xAmn[0].Quantidade = tbQuant.Text;
				Pk1paY7xAmn[0].Tag = tbTag.Text;
				Pk1paY7xAmn[0].Desc = tbDesc.Text;
				Pk1paY7xAmn[0].sModelo = tbMod.Text;
				Pk1paY7xAmn[0].sFabricante = tbFab.Text;
				Pk1paY7xAmn[0].CodCli = tbCod.Text;
				if (Information.UBound(Pk1paY7xAmn) > 0)
				{
					new frmRelatorio_MateriaisDWG(Pk1paY7xAmn, THXparyRhRU, ckMesclarModelo.Checked, ckMesclarFabricante.Checked, ckCodCli.Checked, ref TDjpa9XgJFk);
				}
			}
			if (Operators.CompareString(pag, DeclaracoesGeral.ativo.Pagina, TextCompare: true) != 0)
			{
				Pagina.AtivaPagina(pag);
				DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
			}
		}
	}

	private void Pw5pqRF4yEU(object P_0, EventArgs P_1)
	{
		if (dgListaMateriais.Rows.Count == 0)
		{
			return;
		}
		btExportaEXCEL.Enabled = false;
		cDadosAccessMateriais cDadosAccessMateriais2 = new cDadosAccessMateriais();
		checked
		{
			if (!ckMultPNDetalhado.Checked)
			{
				ReCarregaMatriz(dgListaMateriais, ref Pk1paY7xAmn);
				Pk1paY7xAmn[0].Index = tbIndice.Text;
				Pk1paY7xAmn[0].Quantidade = tbQuant.Text;
				Pk1paY7xAmn[0].Tag = tbTag.Text;
				Pk1paY7xAmn[0].Desc = tbDesc.Text;
				Pk1paY7xAmn[0].sModelo = tbMod.Text;
				Pk1paY7xAmn[0].sFabricante = tbFab.Text;
				Pk1paY7xAmn[0].CodCli = tbCod.Text;
				if (Information.UBound(Pk1paY7xAmn) > 0)
				{
					Relatorios_MateriaisEXCEL.CriaMatrizDeMateriaisEXCEL(Pk1paY7xAmn, THXparyRhRU, g9tpazCIEIQ, ckMesclarModelo.Checked, ckMesclarFabricante.Checked, ckCodCli.Checked);
				}
				cDadosAccessMateriais2.AtualizaIndiceLM(ref THXparyRhRU);
			}
			else
			{
				int num = dgListaMateriais.ColumnCount - 1;
				for (int i = num; i >= 0; i += -1)
				{
					if (!dgListaMateriais.Columns[i].Visible)
					{
						dgListaMateriais.Columns.RemoveAt(i);
					}
				}
				if (dgEquipamentos.RowCount > 0)
				{
					Relatorios_MateriaisEXCEL.CriaMatrizDeMateriaisMEXCEL(dgListaMateriais, g9tpazCIEIQ, ckMesclarModelo.Checked, ckMesclarFabricante.Checked, ckCodCli.Checked);
				}
				cDadosAccessMateriais2.AtualizaIndiceLM(ref THXparyRhRU);
			}
			cDadosAccessMateriais2.fechaConexao();
			btExportaEXCEL.Enabled = true;
		}
	}

	private void x0npqmuPsyI()
	{
		cDadosLM cDadosLM2 = new cDadosLM();
		int[] Paineis = new int[1];
		cDadosLM2.CarregaDadosPaineisLM(ref Paineis);
		dgListaMateriais.Rows.Clear();
		dgListaMateriais.Columns.Clear();
		try
		{
			if (Information.UBound(Paineis) > 0)
			{
				formataDGEquip();
				int num = Information.UBound(Paineis);
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					dgEquipamentos.Rows.Add(Paineis[i], Dicionario.BuscaNomeDoPainel(Paineis[i]));
				}
				CorrigeDGEquip();
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
			cDadosLM2.fechaConexao();
		}
	}

	private void jbepqXUHPNp(object P_0, MouseEventArgs P_1)
	{
	}

	private void SqFpqUrVVjm(object P_0, EventArgs P_1)
	{
		CarregaDispositivo();
	}

	public void CarregaDispositivo()
	{
		if (btSalvaOrdem.Enabled && dgOrdem.Rows.Count > 0)
		{
			MsgBoxResult msgBoxResult = Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1707]), MsgBoxStyle.YesNo);
			if (msgBoxResult == MsgBoxResult.Yes)
			{
				b0UpqEFCg6t();
			}
		}
		CBMultiselecao.Checked = false;
		if (!ckDWG2.Checked)
		{
			bJypqybm1Qo();
			vhtpqg6jHT4();
			btSalvaOrdem.Enabled = false;
			btDesagrupar.Enabled = false;
			dgOrdem.MultiSelect = false;
			TYAp8J6HKN8 = false;
		}
		if (ckDWG2.Checked)
		{
			MaximoSelecionados();
		}
	}

	private void bJypqybm1Qo()
	{
		cDadosLM cDadosLM2 = new cDadosLM();
		checked
		{
			try
			{
				int num = dgEquipamentos.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (dgEquipamentos.Rows[i].Selected)
					{
						TDjpa9XgJFk = Conversions.ToInteger(dgEquipamentos.Rows[i].Cells[0].Value);
						cDadosLM2.CarregaDadosOrdemDispositivos(ref VVSp8T8uyHj, DeclaracoesGeral.arqAtivo.Indice, TDjpa9XgJFk);
						formataDGOrdem();
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
				dgListaMateriais.Rows.Clear();
				dgListaMateriais.Columns.Clear();
				cDadosLM2.fechaConexao();
			}
		}
	}

	private void vhtpqg6jHT4()
	{
		dgOrdem.Rows.Clear();
		dgOrdem.Columns.Clear();
		string left = "";
		checked
		{
			int num = dgEquipamentos.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgEquipamentos.Rows[i].Selected)
				{
					if (Operators.CompareString(left, "", TextCompare: true) != 0)
					{
						left = "";
						break;
					}
					if (Operators.CompareString(left, "", TextCompare: true) == 0)
					{
						left = Conversions.ToString(dgEquipamentos.Rows[i].Cells[1].Value);
					}
				}
			}
			if (Operators.CompareString(left, "", TextCompare: true) == 0)
			{
				g9tpazCIEIQ = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1084]);
				rNAp8pXyJhm = true;
				formataDGOrdem();
			}
			else
			{
				g9tpazCIEIQ = left;
				rNAp8pXyJhm = false;
				if (!ckMultPNDetalhado.Checked)
				{
					formataDGOrdem();
					CarregaGDOrdem(ref VVSp8T8uyHj);
				}
			}
			btSalvaOrdem.Enabled = false;
		}
	}

	public void formataDGEquip()
	{
		checked
		{
			try
			{
				dgEquipamentos.Rows.Clear();
				dgEquipamentos.Columns.Clear();
				float num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgEquipamentos)) ? ((float)(dgEquipamentos.Width - 4)) : ((float)(dgEquipamentos.Width - 21)));
				dgEquipamentos.Columns.Add("", "Indice");
				dgEquipamentos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 748]));
				dgEquipamentos.Columns[0].Width = 0;
				dgEquipamentos.Columns[0].Visible = false;
				dgEquipamentos.Columns[1].Width = (int)Math.Round(num);
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

	public void CorrigeDGEquip()
	{
		checked
		{
			try
			{
				double a = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgEquipamentos)) ? ((double)(dgEquipamentos.Width - 4)) : ((double)(dgEquipamentos.Width - 21)));
				dgEquipamentos.Columns[0].Width = 0;
				dgEquipamentos.Columns[0].Visible = false;
				dgEquipamentos.Columns[1].Width = (int)Math.Round(a);
				dgEquipamentos.MultiSelect = true;
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

	private void zSCpqACDQ3i(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	public void CarregaGDDisp(ref cDadosLM.structureDispLM[] sDisp)
	{
		try
		{
			if (Information.UBound(sDisp) > 0)
			{
				int num = Information.UBound(sDisp);
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					dgOrdem.Rows.Add(sDisp[i].Indice, sDisp[i].iDWG, sDisp[i].iPainel, sDisp[i].sTag, sDisp[i].iIndiceMaterial, sDisp[i].iQuantidade, sDisp[i].lOrdem, sDisp[i].bAvulso, sDisp[i].sDestino, sDisp[i].sDescDestino, sDisp[i].sAlternativo, sDisp[i].sHandle);
				}
				dgOrdem.Rows[0].Selected = true;
				Redimensionar();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	private void mZGpqsaJEfm()
	{
		clsLM.Ordem[] array = new clsLM.Ordem[1];
		bool flag = false;
		checked
		{
			int num = dgEquipamentos.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgEquipamentos.Rows[i].Selected)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				return;
			}
			DataGridView dg;
			if (!ckMultPNDetalhado.Checked)
			{
				int num2 = -1;
				int num3 = 0;
				int num4 = dgOrdem.Rows.Count - 1;
				for (int j = 0; j <= num4; j++)
				{
					array = (clsLM.Ordem[])Utils.CopyArray(array, new clsLM.Ordem[j + 1]);
					array[j].sTag = Conversions.ToString(dgOrdem.Rows[j].Cells[1].Value);
					array[j].iIndice_LM = Conversions.ToInteger(dgOrdem.Rows[j].Cells[2].Value);
					if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectNotEqual(num2, dgOrdem.Rows[j].Cells[2].Value, TextCompare: true), dgOrdem.Rows[j].Cells[2].Style.BackColor == Color.LightCoral)))
					{
						num2 = Conversions.ToInteger(dgOrdem.Rows[j].Cells[2].Value);
						num3++;
					}
					array[j].iOrdem = num3;
					array[j].Quantidade = Conversions.ToInteger(dgOrdem.Rows[j].Cells[4].Value);
				}
				dg = dgEquipamentos;
				CarregaDadosDispositivosSel(ref dg, ref Pk1paY7xAmn, ref THXparyRhRU, Conversions.ToInteger(tbMultiplicador.Text), xyEp8hmNnKa, array);
				dgEquipamentos = dg;
				if (rNAp8pXyJhm)
				{
					ordenaTagDoRelatorio(ref Pk1paY7xAmn);
				}
				formataDGListaMateriais();
				CarregaGDDisp(ref Pk1paY7xAmn, tbMod.Text, tbFab.Text);
				Pk1paY7xAmn[0].Index = tbIndice.Text;
				Pk1paY7xAmn[0].Quantidade = tbQuant.Text;
				Pk1paY7xAmn[0].Tag = tbTag.Text;
				Pk1paY7xAmn[0].Desc = tbDesc.Text;
				Pk1paY7xAmn[0].sModelo = tbMod.Text;
				Pk1paY7xAmn[0].sFabricante = tbFab.Text;
				Pk1paY7xAmn[0].CodCli = tbCod.Text;
				Redimensionar();
				return;
			}
			cDadosLM cDadosLM2 = new cDadosLM();
			dg = dgEquipamentos;
			cDadosLM2.CarregaDadosDispositivosMultiplosPN(ref dg, ref qm3p8W7hv4t, ref THXparyRhRU, Conversions.ToInteger(tbMultiplicador.Text));
			dgEquipamentos = dg;
			cDadosLM2.fechaConexao();
			if (rNAp8pXyJhm)
			{
				ordenaTagDoMultiRelatorio(ref qm3p8W7hv4t);
			}
			formataDGListaMateriaisMulti(qm3p8W7hv4t);
			CarregaGDMDispositivos(ref qm3p8W7hv4t, tbMod.Text, tbFab.Text);
			if (ckMesclarModelo.Checked | ckMesclarFabricante.Checked)
			{
				int num5 = dgListaMateriais.Rows.Count - 1;
				for (int k = 0; k <= num5; k++)
				{
					string text = clsTextos.TiraNothing(dgListaMateriais.Rows[k].Cells[2].Value.ToString()) + "\r\n";
					if (ckMesclarModelo.Checked)
					{
						text = text + clsTextos.TiraNothing(tbMod.Text) + ": " + clsTextos.TiraNothing(Conversions.ToString(dgListaMateriais.Rows[k].Cells[3].Value)) + "\r\n";
					}
					if (ckMesclarFabricante.Checked)
					{
						text = text + clsTextos.TiraNothing(tbFab.Text) + ": " + clsTextos.TiraNothing(Conversions.ToString(dgListaMateriais.Rows[k].Cells[4].Value));
					}
					dgListaMateriais.Rows[k].Cells[2].Value = text;
				}
			}
			RedimensionarMListaMateriais(qm3p8W7hv4t);
			Redimensionar();
		}
	}

	public void CarregaDadosDispositivosSel(ref DataGridView dg, ref cDadosLM.structureLMRelelatorio[] mLM, ref cDadosLM.indexCODMateriais[] mCod, int iMultiplicador, List<string> lDivideDispositivos, clsLM.Ordem[] sOrdem)
	{
		checked
		{
			try
			{
				mCod = new cDadosLM.indexCODMateriais[1];
				mLM = new cDadosLM.structureLMRelelatorio[1];
				DeclaracoesClonar.structureMaterial[] mat = new DeclaracoesClonar.structureMaterial[1];
				cDadosAccessMateriais cDadosAccessMateriais2 = new cDadosAccessMateriais();
				cDadosAccessMateriais2.CarregaMateriaisStructure(ref mat);
				cDadosAccessMateriais2.fechaConexao();
				bool flag = false;
				int num = Information.UBound(sOrdem);
				for (int i = 0; i <= num; i++)
				{
					flag = true;
					int num2 = Information.UBound(mLM);
					for (int j = 1; j <= num2; j++)
					{
						if (Conversions.ToDouble(mLM[j].sOrdem) == (double)sOrdem[i].iOrdem)
						{
							ref string tag = ref mLM[j].Tag;
							tag = tag + ", " + sOrdem[i].sTag;
							ref string quantidade = ref mLM[j].Quantidade;
							quantidade = Conversions.ToString(Conversions.ToDouble(quantidade) + (double)sOrdem[i].Quantidade);
							flag = false;
						}
					}
					if (!flag)
					{
						continue;
					}
					int num3 = Information.UBound(mLM) + 1;
					mLM = (cDadosLM.structureLMRelelatorio[])Utils.CopyArray(mLM, new cDadosLM.structureLMRelelatorio[num3 + 1]);
					mLM[num3].IndexLM = Conversions.ToString(sOrdem[i].iIndice_LM);
					mLM[num3].sOrdem = Conversions.ToString(sOrdem[i].iOrdem);
					mLM[num3].Tag = sOrdem[i].sTag;
					mLM[num3].Quantidade = Conversions.ToString(sOrdem[i].Quantidade);
					mLM[num3].Index = Conversions.ToString(0);
					sOrdem[i].iOrdem = -1;
					int num4 = Information.UBound(mat);
					for (int k = 0; k <= num4; k++)
					{
						if ((double)mat[k].CodigoInterno == Conversions.ToDouble(mLM[num3].IndexLM))
						{
							mLM[num3].sFabricante = mat[k].Fabricante;
							mLM[num3].sModelo = mat[k].Modelo;
							mLM[num3].CodCli = mat[k].CodigoCliente;
							mLM[num3].Desc = "";
							mLM[num3].DescResumida = mat[k].DescricaoResumida;
							mLM[num3].DescCompleta = mat[k].DescricaoCompleta;
							break;
						}
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				throw;
			}
		}
	}

	public void formataDGListaMateriais()
	{
		checked
		{
			try
			{
				dgListaMateriais.Rows.Clear();
				dgListaMateriais.Columns.Clear();
				dgListaMateriais.Columns.Add("#", tbIndice.Text);
				dgListaMateriais.Columns.Add("Quant", tbQuant.Text);
				dgListaMateriais.Columns.Add("TAG", tbTag.Text);
				dgListaMateriais.Columns.Add("DESC", tbDesc.Text);
				dgListaMateriais.Columns.Add("MOD", tbMod.Text);
				dgListaMateriais.Columns.Add("FAB", tbFab.Text);
				dgListaMateriais.Columns.Add("COD", tbCod.Text);
				dgListaMateriais.Columns.Add("INDEXLM", "");
				Redimensionar();
				int num = dgListaMateriais.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgListaMateriais.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
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

	public void formataDGOrdem()
	{
		try
		{
			dgOrdem.Rows.Clear();
			dgOrdem.Columns.Clear();
			if (!rNAp8pXyJhm)
			{
				dgOrdem.Columns.Add("#", "#");
				dgOrdem.Columns.Add("TAG", tbTag.Text);
				dgOrdem.Columns.Add("COD", "MAT");
				dgOrdem.Columns.Add("Ordem", "Ordem");
				dgOrdem.Columns.Add("Quantidade", "Quantidade");
				dgOrdem.Columns.Add("OrdemLay", "OrdemLay");
				RedimensionarOrdem();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void CarregaGDDisp(ref cDadosLM.structureLMRelelatorio[] sDisp, string sModelo, string sFabricante)
	{
		try
		{
			if (Information.UBound(sDisp) <= 0)
			{
				return;
			}
			int num = Information.UBound(sDisp);
			for (int i = 1; i <= num; i = checked(i + 1))
			{
				sDisp[i].Desc = sDisp[i].DescResumida + " ";
				if (RBCompleta.Checked)
				{
					sDisp[i].Desc = sDisp[i].DescCompleta + " ";
				}
				if (ckMesclarModelo.Checked)
				{
					sDisp[i].Desc = sDisp[i].Desc + "\r\n" + sModelo + ": " + sDisp[i].sModelo.Trim();
				}
				if (ckMesclarFabricante.Checked && Operators.CompareString(clsTextos.TiraNothing(sDisp[i].sFabricante.Trim()), "", TextCompare: true) != 0)
				{
					sDisp[i].Desc = sDisp[i].Desc + "\r\n" + sFabricante + ": " + clsTextos.TiraNothing(sDisp[i].sFabricante.Trim());
				}
				if (Operators.CompareString(sDisp[i].Tag, null, TextCompare: true) != 0)
				{
					dgListaMateriais.Rows.Add(i, sDisp[i].Quantidade, sDisp[i].Tag, sDisp[i].Desc, sDisp[i].sModelo, sDisp[i].sFabricante, sDisp[i].CodCli, sDisp[i].IndexLM);
				}
			}
			dgListaMateriais.Rows[0].Selected = true;
			Redimensionar();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void CarregaGDOrdem(ref cDadosLM.structureOrdemDispLM[] sDisp)
	{
		try
		{
			if (Information.UBound(sDisp) > 0)
			{
				int num = Information.UBound(sDisp);
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					dgOrdem.Rows.Add(sDisp[i].Indice, sDisp[i].sTag, sDisp[i].iIndiceMaterial, sDisp[i].lOrdem, sDisp[i].quantidade, sDisp[i].OrdemLay);
				}
				dgOrdem.Rows[0].Selected = true;
				RedimensionarOrdem();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void formataDGListaMateriaisMulti(string[,] mLMP)
	{
		checked
		{
			try
			{
				dgListaMateriais.Rows.Clear();
				dgListaMateriais.Columns.Clear();
				mLMP[0, 0] = tbIndice.Text.ToUpper();
				mLMP[1, 0] = tbTag.Text.ToUpper();
				mLMP[2, 0] = tbDesc.Text.ToUpper();
				mLMP[3, 0] = tbMod.Text.ToUpper();
				mLMP[4, 0] = tbFab.Text.ToUpper();
				mLMP[5, 0] = tbCod.Text.ToUpper();
				mLMP[6, 0] = tbIndice.Text.ToUpper();
				mLMP[Information.UBound(mLMP), 0] = DeclaracoesGeral.mMensagem[1, 1080].ToString().ToUpper();
				dgListaMateriais.Columns.Add(mLMP[0, 0], mLMP[0, 0]);
				dgListaMateriais.Columns.Add(mLMP[1, 0], mLMP[1, 0]);
				dgListaMateriais.Columns.Add(mLMP[2, 0], mLMP[2, 0]);
				dgListaMateriais.Columns.Add(mLMP[3, 0], mLMP[3, 0]);
				dgListaMateriais.Columns.Add(mLMP[4, 0], mLMP[4, 0]);
				dgListaMateriais.Columns.Add(mLMP[5, 0], mLMP[5, 0]);
				dgListaMateriais.Columns.Add(mLMP[6, 0], mLMP[6, 0]);
				int num = Information.UBound(mLMP);
				for (int i = 7; i <= num; i++)
				{
					dgListaMateriais.Columns.Add(mLMP[i, 0], mLMP[i, 0]);
				}
				RedimensionarMListaMateriais(mLMP);
				Redimensionar();
				int num2 = dgListaMateriais.Columns.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					dgListaMateriais.Columns[j].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
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

	public void CarregaGDMDispositivos(ref string[,] mDisp, string sModelo, string sFabricante)
	{
		checked
		{
			try
			{
				if (Information.UBound(mDisp, 2) > 0)
				{
					int num = Information.UBound(mDisp, 2) - 1;
					for (int i = 0; i <= num; i++)
					{
						dgListaMateriais.Rows.Add();
					}
				}
				int count = dgListaMateriais.Rows.Count;
				for (int j = 1; j <= count; j++)
				{
					int num2 = dgListaMateriais.ColumnCount - 1;
					for (int k = 0; k <= num2; k++)
					{
						string text = mDisp[k, j];
						if (k == 1)
						{
							string[] array = text.Split(',');
							List<string> list = new List<string>();
							text = "";
							if (Information.UBound(array) >= 0)
							{
								int num3 = Information.UBound(array);
								for (int l = 0; l <= num3; l++)
								{
									if (!list.Contains(array[l]))
									{
										text = ((Operators.CompareString(text, "", TextCompare: true) == 0) ? (text + array[l]) : (text + ", " + array[l]));
										list.Add(array[l]);
									}
								}
							}
						}
						dgListaMateriais.Rows[j - 1].Cells[k].Value = text;
					}
				}
				dgListaMateriais.Rows[0].Selected = true;
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

	public void ReCarregaMatriz(DataGridView dg, ref cDadosLM.structureLMRelelatorio[] mLM)
	{
		checked
		{
			try
			{
				mLM = new cDadosLM.structureLMRelelatorio[1];
				int num = dg.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					int num2 = i + 1;
					mLM = (cDadosLM.structureLMRelelatorio[])Utils.CopyArray(mLM, new cDadosLM.structureLMRelelatorio[num2 + 1]);
					mLM[num2].Index = Conversions.ToString(num2);
					mLM[num2].Quantidade = Conversions.ToString(dg.Rows[i].Cells[1].Value);
					mLM[num2].Tag = Conversions.ToString(dg.Rows[i].Cells[2].Value);
					mLM[num2].Desc = Conversions.ToString(dg.Rows[i].Cells[3].Value);
					mLM[num2].sModelo = Conversions.ToString(dg.Rows[i].Cells[4].Value);
					mLM[num2].sFabricante = Conversions.ToString(dg.Rows[i].Cells[5].Value);
					mLM[num2].CodCli = Conversions.ToString(dg.Rows[i].Cells[6].Value);
					mLM[num2].IndexLM = Conversions.ToString(num2);
				}
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

	public void ReCarregaMatriz2(DataGridView dg, ref cDadosLM.structureLMRelelatorio[] mLM, bool bMod, bool bFab, bool bCli)
	{
		checked
		{
			try
			{
				mLM = new cDadosLM.structureLMRelelatorio[1];
				int num = dg.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					int num2 = i + 1;
					mLM = (cDadosLM.structureLMRelelatorio[])Utils.CopyArray(mLM, new cDadosLM.structureLMRelelatorio[num2 + 1]);
					mLM[num2].Index = Conversions.ToString(num2);
					mLM[num2].Quantidade = Conversions.ToString(dg.Rows[i].Cells[0].Value);
					mLM[num2].Tag = Conversions.ToString(dg.Rows[i].Cells[1].Value);
					mLM[num2].Desc = Conversions.ToString(dg.Rows[i].Cells[2].Value);
					if (num2 == 1)
					{
						mLM[0].Index = dg.Columns[0].HeaderText;
						mLM[0].Quantidade = dg.Columns[0].HeaderText;
						mLM[0].Tag = dg.Columns[1].HeaderText;
						mLM[0].Desc = dg.Columns[2].HeaderText;
						mLM[0].CodCli = "";
						mLM[0].DescCompleta = "";
						mLM[0].DescResumida = "";
						mLM[0].sModelo = "";
						mLM[0].sFabricante = "";
						mLM[0].sOrdem = "";
						mLM[0].sD1 = "";
						mLM[0].sD2 = "";
						mLM[0].sD3 = "";
						mLM[0].sD4 = "";
						mLM[0].sD5 = "";
						mLM[0].sD6 = "";
						mLM[0].sD7 = "";
						mLM[0].sD8 = "";
						mLM[0].sD9 = "";
						mLM[0].sD10 = "";
						mLM[0].IndexLM = "";
					}
					mLM[num2].CodCli = "";
					mLM[num2].DescCompleta = "";
					mLM[num2].DescResumida = "";
					mLM[num2].sModelo = "";
					mLM[num2].sFabricante = "";
					mLM[num2].sOrdem = "";
					mLM[num2].sD1 = "";
					mLM[num2].sD2 = "";
					mLM[num2].sD3 = "";
					mLM[num2].sD4 = "";
					mLM[num2].sD5 = "";
					mLM[num2].sD6 = "";
					mLM[num2].sD7 = "";
					mLM[num2].sD8 = "";
					mLM[num2].sD9 = "";
					mLM[num2].sD10 = "";
					int num3 = 2;
					if (!bMod)
					{
						num3++;
						mLM[num2].sModelo = Conversions.ToString(dg.Rows[i].Cells[num3].Value);
						if (num2 == 1)
						{
							mLM[0].sModelo = dg.Columns[3].HeaderText;
						}
					}
					if (!bFab)
					{
						num3++;
						mLM[num2].sFabricante = Conversions.ToString(dg.Rows[i].Cells[num3].Value);
						if (num2 == 1)
						{
							mLM[0].sFabricante = dg.Columns[4].HeaderText;
						}
					}
					if (bCli)
					{
						num3++;
						mLM[num2].CodCli = Conversions.ToString(dg.Rows[i].Cells[num3].Value);
						if (num2 == 1)
						{
							mLM[0].CodCli = dg.Columns[5].HeaderText;
						}
					}
					mLM[num2].IndexLM = Conversions.ToString(num2);
					if (!ckMultPNDetalhado.Checked)
					{
						continue;
					}
					num3++;
					if (num3 < dg.Columns.Count)
					{
						mLM[num2].sD1 = Conversions.ToString(dg.Rows[i].Cells[num3].Value);
						if (num2 == 1)
						{
							mLM[0].sD1 = dg.Columns[num3].HeaderText;
						}
					}
					num3++;
					if (num3 < dg.Columns.Count)
					{
						mLM[num2].sD2 = Conversions.ToString(dg.Rows[i].Cells[num3].Value);
						if (num2 == 1)
						{
							mLM[0].sD2 = dg.Columns[num3].HeaderText;
						}
					}
					num3++;
					if (num3 < dg.Columns.Count)
					{
						mLM[num2].sD3 = Conversions.ToString(dg.Rows[i].Cells[num3].Value);
						if (num2 == 1)
						{
							mLM[0].sD3 = dg.Columns[num3].HeaderText;
						}
					}
					num3++;
					if (num3 < dg.Columns.Count)
					{
						mLM[num2].sD4 = Conversions.ToString(dg.Rows[i].Cells[num3].Value);
						if (num2 == 1)
						{
							mLM[0].sD4 = dg.Columns[num3].HeaderText;
						}
					}
					num3++;
					if (num3 < dg.Columns.Count)
					{
						mLM[num2].sD5 = Conversions.ToString(dg.Rows[i].Cells[num3].Value);
						if (num2 == 1)
						{
							mLM[0].sD5 = dg.Columns[num3].HeaderText;
						}
					}
					num3++;
					if (num3 < dg.Columns.Count)
					{
						mLM[num2].sD6 = Conversions.ToString(dg.Rows[i].Cells[num3].Value);
						if (num2 == 1)
						{
							mLM[0].sD6 = dg.Columns[num3].HeaderText;
						}
					}
					num3++;
					if (num3 < dg.Columns.Count)
					{
						mLM[num2].sD7 = Conversions.ToString(dg.Rows[i].Cells[num3].Value);
						if (num2 == 1)
						{
							mLM[0].sD7 = dg.Columns[num3].HeaderText;
						}
					}
					num3++;
					if (num3 < dg.Columns.Count)
					{
						mLM[num2].sD8 = Conversions.ToString(dg.Rows[i].Cells[num3].Value);
						if (num2 == 1)
						{
							mLM[0].sD8 = dg.Columns[num3].HeaderText;
						}
					}
					num3++;
					if (num3 < dg.Columns.Count)
					{
						mLM[num2].sD9 = Conversions.ToString(dg.Rows[i].Cells[num3].Value);
						if (num2 == 1)
						{
							mLM[0].sD9 = dg.Columns[num3].HeaderText;
						}
					}
					num3++;
					if (num3 < dg.Columns.Count)
					{
						mLM[num2].sD10 = Conversions.ToString(dg.Rows[i].Cells[num3].Value);
						if (num2 == 1)
						{
							mLM[0].sD10 = dg.Columns[num3].HeaderText;
						}
					}
					num3++;
					mLM[num2].Quantidade = Conversions.ToString(dg.Rows[i].Cells[num3].Value);
					if (num2 == 1)
					{
						mLM[0].Quantidade = dg.Columns[num3].HeaderText;
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
		}
	}

	public void Redimensionar()
	{
		if (dgListaMateriais.Rows.Count == 0)
		{
			return;
		}
		checked
		{
			double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgListaMateriais)) ? ((double)(dgListaMateriais.Width - 4)) : ((double)(dgListaMateriais.Width - 21)));
			if (!ckMultPNDetalhado.Checked)
			{
				dgListaMateriais.Columns[0].Width = (int)Math.Round(num * 0.07);
				dgListaMateriais.Columns[0].Visible = true;
				dgListaMateriais.Columns[1].Width = (int)Math.Round(num * 0.05);
				dgListaMateriais.Columns[1].Visible = true;
				dgListaMateriais.Columns[2].Width = (int)Math.Round(num * 0.23);
				dgListaMateriais.Columns[2].Visible = true;
				double num2 = 0.35;
				if (ckMesclarModelo.Checked)
				{
					num2 += 0.1;
				}
				if (ckMesclarFabricante.Checked)
				{
					num2 += 0.1;
				}
				if (!ckCodCli.Checked)
				{
					num2 += 0.1;
				}
				dgListaMateriais.Columns[3].Width = (int)Math.Round(num * num2);
				dgListaMateriais.Columns[3].Visible = true;
				if (ckMesclarModelo.Checked)
				{
					dgListaMateriais.Columns[4].Visible = false;
				}
				else
				{
					dgListaMateriais.Columns[4].Width = (int)Math.Round(num * 0.1);
					dgListaMateriais.Columns[4].Visible = true;
				}
				if (ckMesclarFabricante.Checked)
				{
					dgListaMateriais.Columns[5].Visible = false;
				}
				else
				{
					dgListaMateriais.Columns[5].Width = (int)Math.Round(num * 0.1);
					dgListaMateriais.Columns[5].Visible = true;
				}
				if (!ckCodCli.Checked)
				{
					dgListaMateriais.Columns[6].Visible = false;
				}
				else
				{
					dgListaMateriais.Columns[6].Width = (int)Math.Round(num * 0.1);
					dgListaMateriais.Columns[6].Visible = true;
				}
				if (!ckMultPNDetalhado.Checked)
				{
					dgListaMateriais.Columns[7].Width = 0;
					dgListaMateriais.Columns[7].Visible = false;
				}
				RedimensionarOrdem();
				return;
			}
			double num3 = 0.0;
			dgListaMateriais.Columns[0].Width = (int)Math.Round(num * 0.05);
			dgListaMateriais.Columns[0].Visible = true;
			dgListaMateriais.Columns[1].Width = (int)Math.Round(num * 0.1);
			dgListaMateriais.Columns[1].Visible = true;
			dgListaMateriais.Columns[2].Width = (int)Math.Round(num * 0.15);
			dgListaMateriais.Columns[2].Visible = true;
			dgListaMateriais.Columns[3].Width = (int)Math.Round(num * 0.15);
			dgListaMateriais.Columns[3].Visible = true;
			if (!ckMesclarModelo.Checked)
			{
				dgListaMateriais.Columns[3].Width = (int)Math.Round(num * 0.1);
				dgListaMateriais.Columns[3].Visible = true;
			}
			else
			{
				dgListaMateriais.Columns[3].Width = 0;
				dgListaMateriais.Columns[3].Visible = false;
			}
			if (!ckMesclarFabricante.Checked)
			{
				dgListaMateriais.Columns[4].Width = (int)Math.Round(num * 0.1);
				dgListaMateriais.Columns[4].Visible = true;
			}
			else
			{
				dgListaMateriais.Columns[4].Width = 0;
				dgListaMateriais.Columns[4].Visible = false;
			}
			int num4 = 5;
			if (!ckCodCli.Checked)
			{
				dgListaMateriais.Columns[5].Width = 0;
				dgListaMateriais.Columns[5].Visible = false;
				num4 = 5;
			}
			else
			{
				dgListaMateriais.Columns[5].Width = (int)Math.Round(num * 0.1);
				dgListaMateriais.Columns[5].Visible = true;
				num4 = 6;
			}
			dgListaMateriais.Columns[6].Width = 0;
			dgListaMateriais.Columns[6].Visible = false;
			int num5 = dgListaMateriais.ColumnCount - 7;
			num3 = 0.0;
			int num6 = num4;
			for (int i = 0; i <= num6; i++)
			{
				num3 += (double)dgListaMateriais.Columns[i].Width;
			}
			int num7 = dgListaMateriais.ColumnCount - 1;
			for (int j = 7; j <= num7; j++)
			{
				dgListaMateriais.Columns[j].Width = (int)Math.Round((num - num3) / (double)num5);
			}
		}
	}

	public void RedimensionarOrdem()
	{
		checked
		{
			if (dgOrdem.Rows.Count != 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgOrdem)) ? ((double)(dgOrdem.Width - 4)) : ((double)(dgOrdem.Width - 21)));
				dgOrdem.Columns[0].Width = 0;
				dgOrdem.Columns[0].Visible = false;
				dgOrdem.Columns[1].Width = (int)Math.Round(num * 0.7);
				dgOrdem.Columns[1].Visible = true;
				dgOrdem.Columns[2].Width = (int)Math.Round(num * 0.3);
				dgOrdem.Columns[2].Visible = true;
				dgOrdem.Columns[3].Width = 0;
				dgOrdem.Columns[3].Visible = false;
				dgOrdem.Columns[4].Width = 0;
				dgOrdem.Columns[4].Visible = false;
				dgOrdem.Columns[5].Width = 0;
				dgOrdem.Columns[5].Visible = false;
			}
		}
	}

	public void RedimensionarMListaMateriais(string[,] mLMP)
	{
		checked
		{
			if (dgListaMateriais.Rows.Count != 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgListaMateriais)) ? ((double)(dgListaMateriais.Width - 4)) : ((double)(dgListaMateriais.Width - 21)));
				_ = dgListaMateriais.ColumnCount;
				dgListaMateriais.Columns[0].Width = (int)Math.Round(num * 0.05);
				dgListaMateriais.Columns[0].Visible = true;
				double num2 = 0.3;
				dgListaMateriais.Columns[1].Width = (int)Math.Round(num * num2);
				dgListaMateriais.Columns[1].Visible = true;
				dgListaMateriais.Columns[2].Width = (int)Math.Round(num * num2);
				dgListaMateriais.Columns[2].Visible = true;
				double num3 = 45.0;
				int num4 = 0;
				if (!ckMesclarModelo.Checked)
				{
					num4++;
				}
				if (!ckMesclarFabricante.Checked)
				{
					num4++;
				}
				if (ckCodCli.Checked)
				{
					num4++;
				}
				num4 += Information.UBound(mLMP) - 6;
				num3 /= (double)num4;
				num3 /= 100.0;
				if (ckMesclarModelo.Checked)
				{
					dgListaMateriais.Columns[3].Visible = false;
				}
				else
				{
					dgListaMateriais.Columns[3].Width = (int)Math.Round(num * num3);
					dgListaMateriais.Columns[3].Visible = true;
				}
				if (ckMesclarFabricante.Checked)
				{
					dgListaMateriais.Columns[4].Visible = false;
				}
				else
				{
					dgListaMateriais.Columns[4].Width = (int)Math.Round(num * num3);
					dgListaMateriais.Columns[4].Visible = true;
				}
				if (!ckCodCli.Checked)
				{
					dgListaMateriais.Columns[5].Visible = false;
				}
				else
				{
					dgListaMateriais.Columns[5].Width = (int)Math.Round(num * num3);
					dgListaMateriais.Columns[5].Visible = true;
				}
				dgListaMateriais.Columns[6].Visible = false;
				int num5 = Information.UBound(mLMP);
				for (int i = 7; i <= num5; i++)
				{
					dgListaMateriais.Columns[i].Width = (int)Math.Round(num * num3);
					dgListaMateriais.Columns[i].Visible = true;
				}
			}
		}
	}

	private void Qr6pqB15Q0U(object P_0, EventArgs P_1)
	{
		if (!ckMultPNDetalhado.Checked)
		{
			Redimensionar();
		}
		Redimensionar();
	}

	private void RrPpqV6CfHu(object P_0, EventArgs P_1)
	{
		tbCod.Visible = true;
		if (!ckCodCli.Checked)
		{
			tbCod.Visible = false;
		}
		dgListaMateriais.Rows.Clear();
		dgListaMateriais.Columns.Clear();
	}

	private void dy6pqua5o7u(object P_0, EventArgs P_1)
	{
		vhtpqg6jHT4();
		if (!ckMultPNDetalhado.Checked)
		{
			btExportaDWG.Enabled = true;
			rNAp8pXyJhm = false;
			dgOrdem.Rows.Clear();
			dgOrdem.Columns.Clear();
			GroupBox3.Visible = true;
			GroupBox4.Visible = false;
			ckExcel2.Checked = true;
			ckExcel2.Visible = false;
			ckDWG2.Visible = false;
			btExportaDWG.Enabled = true;
			btExportaEXCEL.Enabled = true;
		}
		else
		{
			btExportaDWG.Enabled = false;
			rNAp8pXyJhm = true;
			dgOrdem.Rows.Clear();
			dgOrdem.Columns.Clear();
			GroupBox3.Visible = false;
			GroupBox4.Visible = true;
			ckExcel2.Visible = true;
			ckDWG2.Visible = true;
			ckExcel2.Checked = true;
		}
		dgEquipamentos.MultiSelect = rNAp8pXyJhm;
		dgListaMateriais.Rows.Clear();
		dgListaMateriais.Columns.Clear();
		GroupBox4.Enabled = false;
		tbMultiplicador.Enabled = true;
		if (!ckMultPNDetalhado.Checked)
		{
			tbMultiplicador.Enabled = false;
		}
	}

	private void b0UpqEFCg6t()
	{
		CBMultiselecao.Checked = false;
		int num = 0;
		checked
		{
			int num2 = dgOrdem.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				num++;
				dgOrdem.Rows[i].Cells[3].Value = num;
			}
			cDadosLM cDadosLM2 = new cDadosLM();
			int num3 = dgOrdem.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				int indice = Conversions.ToInteger(dgOrdem.Rows[j].Cells[0].Value);
				int ordem = Conversions.ToInteger(dgOrdem.Rows[j].Cells[3].Value);
				cDadosLM2.AtualizaDadosOrdemDispositivos(indice, ordem);
			}
			cDadosLM2.fechaConexao();
		}
	}

	private void KJxpqZIUAA5(object P_0, MouseEventArgs P_1)
	{
		if (TYAp8J6HKN8)
		{
			return;
		}
		DataGridView.HitTestInfo hitTestInfo = dgOrdem.HitTest(P_1.X, P_1.Y);
		if (hitTestInfo.RowIndex >= 0)
		{
			DataGridViewRow data = dgOrdem.Rows[hitTestInfo.RowIndex];
			K0Sp8HmEWJm = 2;
			KJ6p8klQ5aE = hitTestInfo.RowIndex;
			dgOrdem.Rows[KJ6p8klQ5aE].Selected = true;
			dgOrdem.DoDragDrop(data, DragDropEffects.All);
		}
		KJ6p8klQ5aE = 0;
		checked
		{
			int num = dgOrdem.Rows.Count - 1;
			int num2 = 0;
			while (true)
			{
				if (num2 <= num)
				{
					if (dgOrdem.Rows[num2].Selected)
					{
						break;
					}
					num2++;
					continue;
				}
				return;
			}
			KJ6p8klQ5aE = num2;
		}
	}

	private void eVhpqiq3HXy(object P_0, DragEventArgs P_1)
	{
		P_1.Effect = DragDropEffects.Copy;
	}

	private void FPWpqScPECI(object P_0, DragEventArgs P_1)
	{
		Point point = dgOrdem.PointToClient(new Point(P_1.X, P_1.Y));
		DataGridView.HitTestInfo hitTestInfo = dgOrdem.HitTest(point.X, point.Y);
		if (KJ6p8klQ5aE == hitTestInfo.RowIndex)
		{
			return;
		}
		DataGridViewRow dataGridViewRow = (DataGridViewRow)P_1.Data.GetData(typeof(DataGridViewRow));
		DataGridViewRow dataGridViewRow2 = (DataGridViewRow)dataGridViewRow.Clone();
		dataGridViewRow2.Cells[0].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[0].Value);
		int rowIndex = hitTestInfo.RowIndex;
		checked
		{
			if (rowIndex > -1)
			{
				if (rowIndex < 0)
				{
					return;
				}
				dgOrdem.Rows.Insert(rowIndex, dataGridViewRow.Cells[0].Value, dataGridViewRow.Cells[1].Value, dataGridViewRow.Cells[2].Value, dataGridViewRow.Cells[3].Value, dataGridViewRow.Cells[4].Value);
				_ = dgOrdem.SelectedRows[0].Index;
				if (KJ6p8klQ5aE > rowIndex)
				{
					KJ6p8klQ5aE++;
				}
				dgOrdem.Rows.RemoveAt(KJ6p8klQ5aE);
			}
			dgListaMateriais.Rows.Clear();
			dgListaMateriais.Columns.Clear();
			btSalvaOrdem.Enabled = true;
		}
	}

	private void nP1pq4TuwLk(object P_0, MouseEventArgs P_1)
	{
		DataGridView.HitTestInfo hitTestInfo = dgListaMateriais.HitTest(P_1.X, P_1.Y);
		if (hitTestInfo.RowIndex >= 0)
		{
			DataGridViewRow data = dgListaMateriais.Rows[hitTestInfo.RowIndex];
			OKgp8dKLsOu = 2;
			B2Op8f9oZjy = hitTestInfo.RowIndex;
			dgListaMateriais.Rows[B2Op8f9oZjy].Selected = true;
			dgListaMateriais.DoDragDrop(data, DragDropEffects.All);
		}
		B2Op8f9oZjy = 0;
		checked
		{
			int num = dgListaMateriais.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgListaMateriais.Rows[i].Selected)
				{
					B2Op8f9oZjy = i;
					break;
				}
			}
			int num2 = dgListaMateriais.Rows.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				dgListaMateriais.Rows[j].Cells[0].Value = j + 1;
			}
		}
	}

	private void TRDpqC6FU7B(object P_0, DragEventArgs P_1)
	{
		P_1.Effect = DragDropEffects.Copy;
		btSalvaOrdem.Enabled = true;
	}

	private void m1ApqY2HIuu(object P_0, DragEventArgs P_1)
	{
		Point point = dgListaMateriais.PointToClient(new Point(P_1.X, P_1.Y));
		DataGridView.HitTestInfo hitTestInfo = dgListaMateriais.HitTest(point.X, point.Y);
		if (B2Op8f9oZjy == hitTestInfo.RowIndex)
		{
			return;
		}
		DataGridViewRow dataGridViewRow = (DataGridViewRow)P_1.Data.GetData(typeof(DataGridViewRow));
		DataGridViewRow dataGridViewRow2 = (DataGridViewRow)dataGridViewRow.Clone();
		dataGridViewRow2.Cells[0].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[0].Value);
		int rowIndex = hitTestInfo.RowIndex;
		if (rowIndex <= -1 || rowIndex < 0)
		{
			return;
		}
		checked
		{
			if (!ckMultPNDetalhado.Checked)
			{
				dgListaMateriais.Rows.Insert(rowIndex, dataGridViewRow.Cells[0].Value, dataGridViewRow.Cells[1].Value, dataGridViewRow.Cells[2].Value, dataGridViewRow.Cells[3].Value, dataGridViewRow.Cells[4].Value, dataGridViewRow.Cells[5].Value, dataGridViewRow.Cells[6].Value, dataGridViewRow.Cells[7].Value);
			}
			else
			{
				dgListaMateriais.Rows.Insert(rowIndex);
				int num = dgListaMateriais.ColumnCount - 1;
				for (int i = 0; i <= num; i++)
				{
					dgListaMateriais.Rows[rowIndex].Cells[i].Value = RuntimeHelpers.GetObjectValue(dataGridViewRow.Cells[i].Value);
				}
			}
			_ = dgListaMateriais.SelectedRows[0].Index;
			if (B2Op8f9oZjy > rowIndex)
			{
				B2Op8f9oZjy++;
			}
			dgListaMateriais.Rows.RemoveAt(B2Op8f9oZjy);
		}
	}

	public void ordenaTagDoRelatorio(ref cDadosLM.structureLMRelelatorio[] sDispLM)
	{
		checked
		{
			try
			{
				if (Information.UBound(sDispLM) <= 0)
				{
					return;
				}
				int num = Information.UBound(sDispLM);
				for (int i = 1; i <= num; i++)
				{
					string[] array = sDispLM[i].Tag.Split(',');
					bool flag = false;
					if (Information.UBound(array) <= 1)
					{
						continue;
					}
					if (Information.UBound(array) >= 2)
					{
						int num2 = Information.UBound(array);
						for (int j = 1; j <= num2; j++)
						{
							int num3 = Information.UBound(array) - 1;
							for (int k = num3; k >= 1; k += -1)
							{
								if (Operators.CompareString(array[k], array[k + 1], TextCompare: true) > 0)
								{
									string text = array[k + 1];
									array[k + 1] = array[k];
									array[k] = text;
									flag = true;
								}
							}
						}
					}
					if (flag)
					{
						string text2 = "";
						int num4 = Information.UBound(array);
						for (int l = 0; l <= num4; l++)
						{
							text2 = ((Operators.CompareString(text2, "", TextCompare: true) == 0) ? array[l].Trim() : (text2 + ", " + array[l].Trim()));
						}
						if (Operators.CompareString(sDispLM[i].Tag, text2, TextCompare: true) != 0)
						{
							sDispLM[i].Tag = text2;
						}
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void ordenaTagDoMultiRelatorio(ref string[,] sDispLM)
	{
		checked
		{
			try
			{
				if (Information.UBound(sDispLM, 2) <= 0)
				{
					return;
				}
				int num = Information.UBound(sDispLM, 2);
				for (int i = 1; i <= num; i++)
				{
					string text = sDispLM[1, i];
					string[] array = text.Split(',');
					bool flag = false;
					if (Information.UBound(array) >= 1)
					{
						int num2 = Information.UBound(array);
						for (int j = 1; j <= num2; j++)
						{
							int num3 = Information.UBound(array) - 1;
							for (int k = num3; k >= 1; k += -1)
							{
								if (Operators.CompareString(array[k], array[k + 1], TextCompare: true) > 0)
								{
									string text2 = array[k + 1];
									array[k + 1] = array[k];
									array[k] = text2;
									flag = true;
								}
							}
						}
					}
					if (flag)
					{
						string text3 = "";
						int num4 = Information.UBound(array);
						for (int l = 0; l <= num4; l++)
						{
							text3 = ((Operators.CompareString(text3, "", TextCompare: true) == 0) ? array[l].Trim() : (text3 + ", " + array[l].Trim()));
						}
						if (Operators.CompareString(sDispLM[1, i], text3, TextCompare: true) != 0)
						{
							sDispLM[1, i] = text3;
						}
					}
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void Vv6pqrjPwAY(object P_0, EventArgs P_1)
	{
		dgListaMateriais.Rows.Clear();
		dgListaMateriais.Columns.Clear();
	}

	private void Nsipq98nO0Y(object P_0, EventArgs P_1)
	{
		dgListaMateriais.Rows.Clear();
		dgListaMateriais.Columns.Clear();
	}

	private void Jd4pqznryRo(object P_0, EventArgs P_1)
	{
		checked
		{
			int num = dgOrdem.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgOrdem.Rows[i].Selected)
				{
					int num2 = dgOrdem.Columns.Count - 1;
					for (int j = 0; j <= num2; j++)
					{
						dgOrdem.Rows[i].Cells[j].Style.BackColor = Color.LightCoral;
						dgOrdem.Rows[i].Cells[j].Style.ForeColor = Color.Black;
					}
				}
			}
			dgOrdem.MultiSelect = false;
			TYAp8J6HKN8 = false;
			btDesagrupar.Enabled = true;
			btSalvaOrdem.Enabled = true;
		}
	}

	private void l4VpaWjlNPo(object P_0, EventArgs P_1)
	{
		if (dgOrdem.Rows.Count > 0)
		{
			b0UpqEFCg6t();
		}
		btSalvaOrdem.Enabled = false;
		btDesagrupar.Enabled = false;
	}

	private void ybZpapLj871(object P_0, EventArgs P_1)
	{
		checked
		{
			if (dgOrdem.Rows.Count != 0)
			{
				DataGridView dg = dgOrdem;
				ordenar(ref dg, 5);
				dgOrdem = dg;
				int num = 1;
				int num2 = dgOrdem.Rows.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					dgOrdem.Rows[i].Cells[3].Value = num;
					num++;
				}
				btSalvaOrdem.Enabled = true;
			}
		}
	}

	private void y97paTywJWT(object P_0, EventArgs P_1)
	{
		if (dgOrdem.Rows.Count == 0 || ccsp8oYUGpg)
		{
			return;
		}
		ccsp8oYUGpg = true;
		int num = -1000;
		List<string> list = new List<string>();
		checked
		{
			int num2 = dgOrdem.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (dgOrdem.Rows[i].Selected)
				{
					dgOrdem.Rows[i].Cells[3].Value = num;
					list.Add(Conversions.ToString(dgOrdem.Rows[i].Cells[0].Value));
					num++;
					dgOrdem.Rows[i].Selected = false;
				}
			}
			DataGridView dg = dgOrdem;
			ordenar(ref dg, 3);
			dgOrdem = dg;
			num = 1;
			int num3 = dgOrdem.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				dgOrdem.Rows[j].Cells[3].Value = num;
				if (list.Contains(Conversions.ToString(dgOrdem.Rows[j].Cells[0].Value)))
				{
					dgOrdem.Rows[j].Selected = true;
					dgOrdem.FirstDisplayedScrollingRowIndex = 0;
				}
				num++;
			}
			ccsp8oYUGpg = false;
			btSalvaOrdem.Enabled = true;
		}
	}

	private void kJypaJOMRmr(object P_0, EventArgs P_1)
	{
		if (dgOrdem.Rows.Count == 0 || ccsp8oYUGpg)
		{
			return;
		}
		ccsp8oYUGpg = true;
		int num = 0;
		bool flag = true;
		List<string> list = new List<string>();
		checked
		{
			int num2 = dgOrdem.Rows.Count - 1;
			int num3 = 0;
			while (true)
			{
				if (num3 <= num2)
				{
					if (dgOrdem.Rows[num3].Selected)
					{
						if (num3 == 0)
						{
							break;
						}
						list.Add(Conversions.ToString(dgOrdem.Rows[num3].Cells[0].Value));
					}
					num3++;
					continue;
				}
				int num4 = dgOrdem.Rows.Count - 1;
				for (int i = 0; i <= num4 && !dgOrdem.Rows[i].Selected; i++)
				{
					num = i;
				}
				int num5 = -1000;
				if (num > 0)
				{
					int num6 = num - 1;
					for (int j = 0; j <= num6; j++)
					{
						dgOrdem.Rows[j].Cells[3].Value = num5;
					}
				}
				int num7 = dgOrdem.Rows.Count - 1;
				for (int k = 0; k <= num7; k++)
				{
					dgOrdem.Rows[k].Selected = false;
				}
				num5 = 1000;
				int num8 = num;
				int num9 = dgOrdem.Rows.Count - 1;
				for (int l = num8; l <= num9; l++)
				{
					if (!list.Contains(Conversions.ToString(dgOrdem.Rows[l].Cells[0].Value)))
					{
						dgOrdem.Rows[l].Cells[3].Value = num5;
						num5++;
					}
				}
				DataGridView dg = dgOrdem;
				ordenar(ref dg, 3);
				dgOrdem = dg;
				num5 = 1;
				int num10 = dgOrdem.Rows.Count - 1;
				for (int m = 0; m <= num10; m++)
				{
					dgOrdem.Rows[m].Cells[3].Value = num5;
					if (list.Contains(Conversions.ToString(dgOrdem.Rows[m].Cells[0].Value)))
					{
						dgOrdem.Rows[m].Selected = true;
						if (flag)
						{
							flag = false;
							dgOrdem.FirstDisplayedScrollingRowIndex = m;
						}
					}
					num5++;
				}
				break;
			}
			ccsp8oYUGpg = false;
			btSalvaOrdem.Enabled = true;
		}
	}

	private void RfJpahh2fqX(object P_0, EventArgs P_1)
	{
		if (dgOrdem.Rows.Count == 0 || ccsp8oYUGpg)
		{
			return;
		}
		ccsp8oYUGpg = true;
		int num = 0;
		bool flag = true;
		List<string> list = new List<string>();
		checked
		{
			int num2 = dgOrdem.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (dgOrdem.Rows[i].Selected)
				{
					num = i;
					list.Add(Conversions.ToString(dgOrdem.Rows[i].Cells[0].Value));
				}
			}
			if (num < dgOrdem.Rows.Count - 1)
			{
				num++;
				int num3 = -1000;
				int num4 = dgOrdem.Rows.Count - 1;
				for (int j = 0; j <= num4; j++)
				{
					if (j > num)
					{
						num3 = 1000;
						num = 1000;
					}
					if (!list.Contains(Conversions.ToString(dgOrdem.Rows[j].Cells[0].Value)))
					{
						dgOrdem.Rows[j].Cells[3].Value = num3;
						num3++;
					}
				}
				int num5 = dgOrdem.Rows.Count - 1;
				for (int k = 0; k <= num5; k++)
				{
					dgOrdem.Rows[k].Selected = false;
				}
				DataGridView dg = dgOrdem;
				ordenar(ref dg, 3);
				dgOrdem = dg;
				num3 = 1;
				int num6 = dgOrdem.Rows.Count - 1;
				for (int l = 0; l <= num6; l++)
				{
					dgOrdem.Rows[l].Cells[3].Value = num3;
					if (list.Contains(Conversions.ToString(dgOrdem.Rows[l].Cells[0].Value)))
					{
						dgOrdem.Rows[l].Selected = true;
						if (flag)
						{
							flag = false;
							dgOrdem.FirstDisplayedScrollingRowIndex = l;
						}
					}
					num3++;
				}
			}
			ccsp8oYUGpg = false;
			btSalvaOrdem.Enabled = true;
		}
	}

	private void HvUpaoZYPkx(object P_0, EventArgs P_1)
	{
		if (dgOrdem.Rows.Count == 0 || ccsp8oYUGpg)
		{
			return;
		}
		ccsp8oYUGpg = true;
		int num = 1000;
		List<string> list = new List<string>();
		checked
		{
			int num2 = dgOrdem.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (dgOrdem.Rows[i].Selected)
				{
					dgOrdem.Rows[i].Cells[3].Value = num;
					list.Add(Conversions.ToString(dgOrdem.Rows[i].Cells[0].Value));
					num++;
					dgOrdem.Rows[i].Selected = false;
				}
			}
			DataGridView dg = dgOrdem;
			ordenar(ref dg, 3);
			dgOrdem = dg;
			num = 1;
			int num3 = dgOrdem.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				dgOrdem.Rows[j].Cells[3].Value = num;
				if (list.Contains(Conversions.ToString(dgOrdem.Rows[j].Cells[0].Value)))
				{
					dgOrdem.Rows[j].Selected = true;
					dgOrdem.FirstDisplayedScrollingRowIndex = j;
				}
				num++;
			}
			ccsp8oYUGpg = false;
			btSalvaOrdem.Enabled = true;
		}
	}

	public static void ordenar(ref DataGridView dg, int indice)
	{
		checked
		{
			if (dg.Rows.Count - 1 < 1)
			{
				return;
			}
			int num = dg.Rows.Count - 2;
			for (int i = 0; i <= num; i++)
			{
				int num2 = dg.Rows.Count - 2;
				for (int j = num2; j >= 0; j += -1)
				{
					if (Conversions.ToDouble(dg.Rows[j].Cells[indice].Value) > Conversions.ToDouble(dg.Rows[j + 1].Cells[indice].Value))
					{
						int num3 = 0;
						do
						{
							object objectValue = RuntimeHelpers.GetObjectValue(dg.Rows[j].Cells[num3].Value);
							dg.Rows[j].Cells[num3].Value = RuntimeHelpers.GetObjectValue(dg.Rows[j + 1].Cells[num3].Value);
							dg.Rows[j + 1].Cells[num3].Value = RuntimeHelpers.GetObjectValue(objectValue);
							num3++;
						}
						while (num3 <= 5);
					}
				}
			}
		}
	}

	private void cXQpaGUsTFh(object P_0, EventArgs P_1)
	{
		checked
		{
			if (!CBMultiselecao.Checked)
			{
				dgOrdem.MultiSelect = false;
				TYAp8J6HKN8 = false;
			}
			else
			{
				if (dgOrdem.Rows.Count == 0)
				{
					return;
				}
				int num = -1;
				int num2 = dgOrdem.Rows.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					if (dgOrdem.Rows[i].Selected)
					{
						num = i;
						break;
					}
				}
				dgOrdem.MultiSelect = true;
				TYAp8J6HKN8 = true;
				btDesagrupar.Enabled = true;
				if (num > -1)
				{
					dgOrdem.Rows[num].Selected = true;
				}
			}
		}
	}

	private void hqBpaHC61tu(object P_0, EventArgs P_1)
	{
		if (RBCompleta.Checked)
		{
			dgListaMateriais.Rows.Clear();
			dgListaMateriais.Columns.Clear();
		}
	}

	private void uuIpakXP0Uf(object P_0, EventArgs P_1)
	{
		if (RBResumida.Checked)
		{
			dgListaMateriais.Rows.Clear();
			dgListaMateriais.Columns.Clear();
		}
	}

	private void dWJpaddZUhD(object P_0, EventArgs P_1)
	{
	}

	private void Wm2pafAYYQj(object P_0, EventArgs P_1)
	{
		if (ckExcel2.Checked)
		{
			btExportaEXCEL.Enabled = true;
			btExportaDWG.Enabled = false;
			btApagarDWG.Enabled = false;
			GroupBox4.Enabled = false;
		}
	}

	private void uArpaDWBJjf(object P_0, EventArgs P_1)
	{
	}

	private void hMTpavHJfPB(object P_0, EventArgs P_1)
	{
		if (ckDWG2.Checked)
		{
			MaximoSelecionados();
			btExportaEXCEL.Enabled = false;
			btExportaDWG.Enabled = true;
			btApagarDWG.Enabled = true;
			GroupBox4.Enabled = true;
		}
	}

	public void MaximoSelecionados()
	{
		int num = -1;
		MEKp8GZ0rpb = 0;
		checked
		{
			int num2 = dgEquipamentos.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (dgEquipamentos.Rows[i].Selected)
				{
					if (num == -1)
					{
						num = i;
					}
					if (MEKp8GZ0rpb >= 10)
					{
						dgEquipamentos.Rows[i].Selected = false;
					}
					else
					{
						MEKp8GZ0rpb++;
					}
				}
			}
			if (num > -1)
			{
				dgEquipamentos.FirstDisplayedScrollingRowIndex = num;
			}
		}
	}

	private void j1Epa6RtRJQ(object P_0, EventArgs P_1)
	{
		Relatorios_MateriaisDWG.ApagaTodoRelatorioMateriais();
		verificaNumeracao();
	}

	private void Yqypat99uY0(object P_0, EventArgs P_1)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Invalid comparison between Unknown and I4
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			_ = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			PromptPointResult val2 = (PromptPointResult)NewLateBinding.LateGet(editor, null, "GetPoint", new object[1] { Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 688]) }, null, null, null);
			if ((int)((PromptResult)val2).Status != -5002)
			{
				DeclaracoesGeral.Reguas RH = default;
				XDataGeral.LeXDataReguaH(ref RH);
				double num = RH.Pti.Y;
				Point3d value = val2.Value;
				double value2 = num - value.Y;
				tbOrdenadaY.Text = Math.Round(value2, 2).ToString();
			}
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			val.Abort();
			throw;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		PointMonitorToolTips.StartMonitor();
	}

	public static void Attt(ref DataGridView dg)
	{
		if (dg.RowCount <= 0)
		{
			return;
		}
		double num = dg.Columns[2].Width;
		checked
		{
			if (haG8HN1M755FJ2bc2NW.Na8179sVA9(dg))
			{
				do
				{
					num--;
					dg.Columns[2].Width = (int)Math.Round(num);
					Application.DoEvents();
				}
				while (haG8HN1M755FJ2bc2NW.Na8179sVA9(dg));
				return;
			}
			do
			{
				num++;
				dg.Columns[2].Width = (int)Math.Round(num);
				Application.DoEvents();
			}
			while (!haG8HN1M755FJ2bc2NW.Na8179sVA9(dg));
			num--;
			dg.Columns[2].Width = (int)Math.Round(num);
		}
	}
}
