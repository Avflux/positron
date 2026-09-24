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
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.Windows;
using idK5By1ORRRAapLJQ3M;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmVerificadorProjetoInterligacao : Form
{
	private IContainer YtP2k9LuhW;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip Lv82dyhglJ;

	[AccessedThroughProperty("GroupBoxInterligacao")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox Ys92faP5WY;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btMostraErroVeia")]
	private Button g7U2Dpm3B6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btOcultaErroVeia")]
	private Button JKp2vA6kca;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBoxJumper")]
	private GroupBox Mps261UhAr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btMostraErroJumper")]
	private Button gtG2to8dov;

	[AccessedThroughProperty("btOcultaErroJumper")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button upB2jHFbUf;

	[AccessedThroughProperty("TreeView1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TreeView L6o2La88GC;

	[AccessedThroughProperty("btCorDoErroI")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button Sc72wWZLe2;

	[CompilerGenerated]
	[AccessedThroughProperty("btCorDoErroJ")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button xs22xkA1HQ;

	[AccessedThroughProperty("btCarrega")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button weN2blmgTQ;

	[AccessedThroughProperty("GBAtualiza")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox CiJ2MZGZWb;

	[AccessedThroughProperty("bt5Terminais")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button cRO2ORfT7I;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt9Discrepantes")]
	private Button pSa2IUMq4e;

	[CompilerGenerated]
	[AccessedThroughProperty("bt7Reguas")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button ax727ydYn5;

	[AccessedThroughProperty("bt8intervalos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button B2P2q1kNG3;

	[AccessedThroughProperty("bt1Interligacao")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button rLR2ammBXg;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt6Portas")]
	private Button kEy28kZKX9;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox9")]
	private GroupBox Ghi2NCmrZc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgBornesEditados")]
	private DataGridView x4C2FQsDPj;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox6")]
	private GroupBox HBn2QdSKZm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgReguasSemUso")]
	private DataGridView D3Z2PnNw31;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox5")]
	private GroupBox MJe2cils28;

	[AccessedThroughProperty("dgTerminais")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView Q7F2KRQ0mn;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox7")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox TTl2eybKq4;

	[AccessedThroughProperty("TreeViewBornes")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TreeView Wyw22KHQfZ;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox8")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox k4123BbUFD;

	[AccessedThroughProperty("dgBornes")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView qpP2n2ri6n;

	[AccessedThroughProperty("GB1Interligacao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox AN421eVQvB;

	[AccessedThroughProperty("bt10BornesLM")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button myi2l6AIK6;

	[AccessedThroughProperty("GBEX")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox Oag25gMrR2;

	[AccessedThroughProperty("GroupBox10")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox G5O20edMUQ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TreeViewBornesLM")]
	private TreeView qpR2RClysx;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("bt11Paineis")]
	private Button tfd2m1WKLh;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox11")]
	private GroupBox MUD2XEAYnU;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgPainelApagado")]
	private DataGridView sv42UsjGV2;

	[CompilerGenerated]
	[AccessedThroughProperty("bt12AMao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button d5d2yRMGjs;

	[AccessedThroughProperty("GroupBox12")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox xVR2gnc9Gg;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgAMao")]
	private DataGridView Rns2ApsDQ1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BT13Discrepantes")]
	private Button OG02s5KfVA;

	[AccessedThroughProperty("GroupBox13")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox WXy2BPSHpJ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGDiscrepantes")]
	private DataGridView EEp2V0Noc9;

	[CompilerGenerated]
	[AccessedThroughProperty("BTCorrigirDiscrepante")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button tB82u4HH2Z;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBTag")]
	private Label sn52EKLo1U;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBPNDes")]
	private Label aFZ2ZMtws0;

	[AccessedThroughProperty("LBPNCadastro")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label RUi2iIM91b;

	[CompilerGenerated]
	[AccessedThroughProperty("BT14CabosFaltantes")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button mRI2SceBGo;

	[AccessedThroughProperty("GroupBox14")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox x5Y24uCsPj;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("DGCabosDoBanco")]
	private DataGridView J712CpiMrM;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("BTCorrigeCabos")]
	private Button BL32YKW1Pf;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt15ReguaMascara")]
	private Button Yfp2rgUvVA;

	[AccessedThroughProperty("GroupBox15")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox Ckp29yhFqP;

	[AccessedThroughProperty("dgReguaMascara")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView Kxv2zi36Da;

	private clsVerificadorProjetoInterligacao.StructureJumper[] DBq3WCe4c2;

	private clsVerificadorProjetoInterligacao.StructureJumper[] AIT3peilyC;

	private ClsVerificadorProjetoFiacao._StructureConexao[] TLl3Tb64JD;

	private DeclaracoesEntidades.StructureBorne[] NMc3JFnBaS;

	private ClsVerificadorProjetoFiacao._StructureAnalisePorta[] vTJ3hn9llT;

	private ClsVerificadorProjetoFiacao._StructuremDispositivo[] DuZ3okk8Hh;

	private ClsVerificadorProjetoFiacao._StructuremAuxiliar[] mjD3GIk5FY;

	private List<string> Ntj3HDmrBL;

	private List<string> n8Q3kbOWxr;

	private ColorDialog sEP3dSGtKV;

	private int dM23f4hVwR;

	private int xxJ3DnmHiI;

	private DataGridViewCellStyle mT43v7CK32;

	private DataGridViewCellStyle XSR36apgl1;

	private bool eJK3tCnFyq;

	private bool sJM3j8kR2H;

	private clsBlocos.StructureErros[] b8E3LytR55;

	private structureNomeVeiasErradas[] w9l3w2QBKA;

	private List<string> yx83xxOcMO;

	private structureNomeVeiasEditadar[] sju3bdCB5q;

	private ClsVerificadorProjetoFiacao._StructurefiacaoErro[] Qlj3M7lYrn;

	internal virtual GroupBox GroupBoxInterligacao
	{
		[CompilerGenerated]
		get
		{
			return Ys92faP5WY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Ys92faP5WY = value;
		}
	}

	internal virtual Button btMostraErroVeia
	{
		[CompilerGenerated]
		get
		{
			return g7U2Dpm3B6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tFKe29ay3Z;
			Button button = g7U2Dpm3B6;
			if (button != null)
			{
				button.Click -= value2;
			}
			g7U2Dpm3B6 = value;
			button = g7U2Dpm3B6;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btOcultaErroVeia
	{
		[CompilerGenerated]
		get
		{
			return JKp2vA6kca;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = OJfe3aTN4i;
			Button button = JKp2vA6kca;
			if (button != null)
			{
				button.Click -= value2;
			}
			JKp2vA6kca = value;
			button = JKp2vA6kca;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBoxJumper
	{
		[CompilerGenerated]
		get
		{
			return Mps261UhAr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Mps261UhAr = value;
		}
	}

	internal virtual Button btMostraErroJumper
	{
		[CompilerGenerated]
		get
		{
			return gtG2to8dov;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = cKoeKwlH8N;
			Button button = gtG2to8dov;
			if (button != null)
			{
				button.Click -= value2;
			}
			gtG2to8dov = value;
			button = gtG2to8dov;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btOcultaErroJumper
	{
		[CompilerGenerated]
		get
		{
			return upB2jHFbUf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CRLeeYHp8N;
			Button button = upB2jHFbUf;
			if (button != null)
			{
				button.Click -= value2;
			}
			upB2jHFbUf = value;
			button = upB2jHFbUf;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TreeView TreeView1
	{
		[CompilerGenerated]
		get
		{
			return L6o2La88GC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TreeViewEventHandler value2 = B6qenXYSSI;
			TreeView treeView = L6o2La88GC;
			if (treeView != null)
			{
				treeView.AfterSelect -= value2;
			}
			L6o2La88GC = value;
			treeView = L6o2La88GC;
			if (treeView != null)
			{
				treeView.AfterSelect += value2;
			}
		}
	}

	internal virtual Button btCorDoErroI
	{
		[CompilerGenerated]
		get
		{
			return Sc72wWZLe2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = HtaecV7Qh7;
			Button button = Sc72wWZLe2;
			if (button != null)
			{
				button.Click -= value2;
			}
			Sc72wWZLe2 = value;
			button = Sc72wWZLe2;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btCorDoErroJ
	{
		[CompilerGenerated]
		get
		{
			return xs22xkA1HQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = lGoePCHpnB;
			Button button = xs22xkA1HQ;
			if (button != null)
			{
				button.Click -= value2;
			}
			xs22xkA1HQ = value;
			button = xs22xkA1HQ;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btCarrega
	{
		[CompilerGenerated]
		get
		{
			return weN2blmgTQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = oO9eli2qDX;
			Button button = weN2blmgTQ;
			if (button != null)
			{
				button.Click -= value2;
			}
			weN2blmgTQ = value;
			button = weN2blmgTQ;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GBAtualiza
	{
		[CompilerGenerated]
		get
		{
			return CiJ2MZGZWb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CiJ2MZGZWb = value;
		}
	}

	internal virtual Button bt5Terminais
	{
		[CompilerGenerated]
		get
		{
			return cRO2ORfT7I;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AfQeCJL8EJ;
			Button button = cRO2ORfT7I;
			if (button != null)
			{
				button.Click -= value2;
			}
			cRO2ORfT7I = value;
			button = cRO2ORfT7I;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button bt9Discrepantes
	{
		[CompilerGenerated]
		get
		{
			return pSa2IUMq4e;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MSUezXwYHq;
			Button button = pSa2IUMq4e;
			if (button != null)
			{
				button.Click -= value2;
			}
			pSa2IUMq4e = value;
			button = pSa2IUMq4e;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button bt7Reguas
	{
		[CompilerGenerated]
		get
		{
			return ax727ydYn5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = iiteY7CNZT;
			Button button = ax727ydYn5;
			if (button != null)
			{
				button.Click -= value2;
			}
			ax727ydYn5 = value;
			button = ax727ydYn5;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button bt8intervalos
	{
		[CompilerGenerated]
		get
		{
			return B2P2q1kNG3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RdCerVHlF9;
			Button button = B2P2q1kNG3;
			if (button != null)
			{
				button.Click -= value2;
			}
			B2P2q1kNG3 = value;
			button = B2P2q1kNG3;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button bt1Interligacao
	{
		[CompilerGenerated]
		get
		{
			return rLR2ammBXg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = aXRe4Yj4WV;
			Button button = rLR2ammBXg;
			if (button != null)
			{
				button.Click -= value2;
			}
			rLR2ammBXg = value;
			button = rLR2ammBXg;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button bt6Portas
	{
		[CompilerGenerated]
		get
		{
			return kEy28kZKX9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = RIJe9sYENY;
			Button button = kEy28kZKX9;
			if (button != null)
			{
				button.Click -= value2;
			}
			kEy28kZKX9 = value;
			button = kEy28kZKX9;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox9
	{
		[CompilerGenerated]
		get
		{
			return Ghi2NCmrZc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Ghi2NCmrZc = value;
		}
	}

	internal virtual DataGridView dgBornesEditados
	{
		[CompilerGenerated]
		get
		{
			return x4C2FQsDPj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = BsQeBMN6iG;
			DataGridView dataGridView = x4C2FQsDPj;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
			}
			x4C2FQsDPj = value;
			dataGridView = x4C2FQsDPj;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox6
	{
		[CompilerGenerated]
		get
		{
			return HBn2QdSKZm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			HBn2QdSKZm = value;
		}
	}

	internal virtual DataGridView dgReguasSemUso
	{
		[CompilerGenerated]
		get
		{
			return D3Z2PnNw31;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			D3Z2PnNw31 = value;
		}
	}

	internal virtual GroupBox GroupBox5
	{
		[CompilerGenerated]
		get
		{
			return MJe2cils28;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MJe2cils28 = value;
		}
	}

	internal virtual DataGridView dgTerminais
	{
		[CompilerGenerated]
		get
		{
			return Q7F2KRQ0mn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = kQXeVACKlh;
			DataGridView dataGridView = Q7F2KRQ0mn;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
			}
			Q7F2KRQ0mn = value;
			dataGridView = Q7F2KRQ0mn;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox7
	{
		[CompilerGenerated]
		get
		{
			return TTl2eybKq4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TTl2eybKq4 = value;
		}
	}

	internal virtual TreeView TreeViewBornes
	{
		[CompilerGenerated]
		get
		{
			return Wyw22KHQfZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Wyw22KHQfZ = value;
		}
	}

	internal virtual GroupBox GroupBox8
	{
		[CompilerGenerated]
		get
		{
			return k4123BbUFD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			k4123BbUFD = value;
		}
	}

	internal virtual DataGridView dgBornes
	{
		[CompilerGenerated]
		get
		{
			return qpP2n2ri6n;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = FfneuMwUIq;
			DataGridView dataGridView = qpP2n2ri6n;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
			}
			qpP2n2ri6n = value;
			dataGridView = qpP2n2ri6n;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
			}
		}
	}

	internal virtual GroupBox GB1Interligacao
	{
		[CompilerGenerated]
		get
		{
			return AN421eVQvB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			AN421eVQvB = value;
		}
	}

	internal virtual Button bt10BornesLM
	{
		[CompilerGenerated]
		get
		{
			return myi2l6AIK6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ubM2WxaW09;
			Button button = myi2l6AIK6;
			if (button != null)
			{
				button.Click -= value2;
			}
			myi2l6AIK6 = value;
			button = myi2l6AIK6;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GBEX
	{
		[CompilerGenerated]
		get
		{
			return Oag25gMrR2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Oag25gMrR2 = value;
		}
	}

	internal virtual GroupBox GroupBox10
	{
		[CompilerGenerated]
		get
		{
			return G5O20edMUQ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			G5O20edMUQ = value;
		}
	}

	internal virtual TreeView TreeViewBornesLM
	{
		[CompilerGenerated]
		get
		{
			return qpR2RClysx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qpR2RClysx = value;
		}
	}

	internal virtual Button bt11Paineis
	{
		[CompilerGenerated]
		get
		{
			return tfd2m1WKLh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MOC2pvn45n;
			Button button = tfd2m1WKLh;
			if (button != null)
			{
				button.Click -= value2;
			}
			tfd2m1WKLh = value;
			button = tfd2m1WKLh;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox11
	{
		[CompilerGenerated]
		get
		{
			return MUD2XEAYnU;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MUD2XEAYnU = value;
		}
	}

	internal virtual DataGridView dgPainelApagado
	{
		[CompilerGenerated]
		get
		{
			return sv42UsjGV2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = YcPeEAbXdf;
			DataGridView dataGridView = sv42UsjGV2;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
			}
			sv42UsjGV2 = value;
			dataGridView = sv42UsjGV2;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
			}
		}
	}

	internal virtual Button bt12AMao
	{
		[CompilerGenerated]
		get
		{
			return d5d2yRMGjs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Nyj2TQJP79;
			Button button = d5d2yRMGjs;
			if (button != null)
			{
				button.Click -= value2;
			}
			d5d2yRMGjs = value;
			button = d5d2yRMGjs;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox12
	{
		[CompilerGenerated]
		get
		{
			return xVR2gnc9Gg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			xVR2gnc9Gg = value;
		}
	}

	internal virtual DataGridView dgAMao
	{
		[CompilerGenerated]
		get
		{
			return Rns2ApsDQ1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = w66eZJtgLc;
			DataGridView dataGridView = Rns2ApsDQ1;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
			}
			Rns2ApsDQ1 = value;
			dataGridView = Rns2ApsDQ1;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
			}
		}
	}

	internal virtual Button BT13Discrepantes
	{
		[CompilerGenerated]
		get
		{
			return OG02s5KfVA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = MW32JyOI41;
			Button button = OG02s5KfVA;
			if (button != null)
			{
				button.Click -= value2;
			}
			OG02s5KfVA = value;
			button = OG02s5KfVA;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox13
	{
		[CompilerGenerated]
		get
		{
			return WXy2BPSHpJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			WXy2BPSHpJ = value;
		}
	}

	internal virtual DataGridView DGDiscrepantes
	{
		[CompilerGenerated]
		get
		{
			return EEp2V0Noc9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = qbEe1cYaTx;
			DataGridView dataGridView = EEp2V0Noc9;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
			}
			EEp2V0Noc9 = value;
			dataGridView = EEp2V0Noc9;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
			}
		}
	}

	internal virtual Button BTCorrigirDiscrepante
	{
		[CompilerGenerated]
		get
		{
			return tB82u4HH2Z;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Kgu2GRvwuD;
			Button button = tB82u4HH2Z;
			if (button != null)
			{
				button.Click -= value2;
			}
			tB82u4HH2Z = value;
			button = tB82u4HH2Z;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label LBTag
	{
		[CompilerGenerated]
		get
		{
			return sn52EKLo1U;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			sn52EKLo1U = value;
		}
	}

	internal virtual Label LBPNDes
	{
		[CompilerGenerated]
		get
		{
			return aFZ2ZMtws0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			aFZ2ZMtws0 = value;
		}
	}

	internal virtual Label LBPNCadastro
	{
		[CompilerGenerated]
		get
		{
			return RUi2iIM91b;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			RUi2iIM91b = value;
		}
	}

	internal virtual Button BT14CabosFaltantes
	{
		[CompilerGenerated]
		get
		{
			return mRI2SceBGo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UtH2hGosb0;
			Button button = mRI2SceBGo;
			if (button != null)
			{
				button.Click -= value2;
			}
			mRI2SceBGo = value;
			button = mRI2SceBGo;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox14
	{
		[CompilerGenerated]
		get
		{
			return x5Y24uCsPj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			x5Y24uCsPj = value;
		}
	}

	internal virtual DataGridView DGCabosDoBanco
	{
		[CompilerGenerated]
		get
		{
			return J712CpiMrM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = uVIesDeeDf;
			DataGridView dataGridView = J712CpiMrM;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
			}
			J712CpiMrM = value;
			dataGridView = J712CpiMrM;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
			}
		}
	}

	internal virtual Button BTCorrigeCabos
	{
		[CompilerGenerated]
		get
		{
			return BL32YKW1Pf;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = nK22HNkZuR;
			Button button = BL32YKW1Pf;
			if (button != null)
			{
				button.Click -= value2;
			}
			BL32YKW1Pf = value;
			button = BL32YKW1Pf;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button bt15ReguaMascara
	{
		[CompilerGenerated]
		get
		{
			return Yfp2rgUvVA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = bc42opiHqN;
			Button button = Yfp2rgUvVA;
			if (button != null)
			{
				button.Click -= value2;
			}
			Yfp2rgUvVA = value;
			button = Yfp2rgUvVA;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox15
	{
		[CompilerGenerated]
		get
		{
			return Ckp29yhFqP;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Ckp29yhFqP = value;
		}
	}

	internal virtual DataGridView dgReguaMascara
	{
		[CompilerGenerated]
		get
		{
			return Kxv2zi36Da;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Kxv2zi36Da = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && YtP2k9LuhW != null)
			{
				YtP2k9LuhW.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void ALueQmTvI3()
	{
		YtP2k9LuhW = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
		FDqpBiUmZij(new ToolTip(YtP2k9LuhW));
		TreeView1 = new TreeView();
		GroupBoxInterligacao = new GroupBox();
		btCorDoErroI = new Button();
		btMostraErroVeia = new Button();
		btOcultaErroVeia = new Button();
		GroupBoxJumper = new GroupBox();
		btCorDoErroJ = new Button();
		btMostraErroJumper = new Button();
		btOcultaErroJumper = new Button();
		btCarrega = new Button();
		GBAtualiza = new GroupBox();
		bt5Terminais = new Button();
		bt9Discrepantes = new Button();
		bt7Reguas = new Button();
		bt8intervalos = new Button();
		bt1Interligacao = new Button();
		bt6Portas = new Button();
		GroupBox9 = new GroupBox();
		dgBornesEditados = new DataGridView();
		GroupBox6 = new GroupBox();
		dgReguasSemUso = new DataGridView();
		GroupBox5 = new GroupBox();
		dgTerminais = new DataGridView();
		GroupBox7 = new GroupBox();
		TreeViewBornes = new TreeView();
		GroupBox8 = new GroupBox();
		dgBornes = new DataGridView();
		GB1Interligacao = new GroupBox();
		bt10BornesLM = new Button();
		GBEX = new GroupBox();
		GroupBox12 = new GroupBox();
		dgAMao = new DataGridView();
		GroupBox10 = new GroupBox();
		TreeViewBornesLM = new TreeView();
		GroupBox11 = new GroupBox();
		dgPainelApagado = new DataGridView();
		bt11Paineis = new Button();
		bt12AMao = new Button();
		BT13Discrepantes = new Button();
		GroupBox13 = new GroupBox();
		LBPNCadastro = new Label();
		BTCorrigirDiscrepante = new Button();
		LBPNDes = new Label();
		LBTag = new Label();
		DGDiscrepantes = new DataGridView();
		BT14CabosFaltantes = new Button();
		GroupBox14 = new GroupBox();
		BTCorrigeCabos = new Button();
		DGCabosDoBanco = new DataGridView();
		bt15ReguaMascara = new Button();
		GroupBox15 = new GroupBox();
		dgReguaMascara = new DataGridView();
		GroupBoxInterligacao.SuspendLayout();
		GroupBoxJumper.SuspendLayout();
		GBAtualiza.SuspendLayout();
		GroupBox9.SuspendLayout();
		((ISupportInitialize)dgBornesEditados).BeginInit();
		GroupBox6.SuspendLayout();
		((ISupportInitialize)dgReguasSemUso).BeginInit();
		GroupBox5.SuspendLayout();
		((ISupportInitialize)dgTerminais).BeginInit();
		GroupBox7.SuspendLayout();
		GroupBox8.SuspendLayout();
		((ISupportInitialize)dgBornes).BeginInit();
		GB1Interligacao.SuspendLayout();
		GroupBox12.SuspendLayout();
		((ISupportInitialize)dgAMao).BeginInit();
		GroupBox10.SuspendLayout();
		GroupBox11.SuspendLayout();
		((ISupportInitialize)dgPainelApagado).BeginInit();
		GroupBox13.SuspendLayout();
		((ISupportInitialize)DGDiscrepantes).BeginInit();
		GroupBox14.SuspendLayout();
		((ISupportInitialize)DGCabosDoBanco).BeginInit();
		GroupBox15.SuspendLayout();
		((ISupportInitialize)dgReguaMascara).BeginInit();
		SuspendLayout();
		TreeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		TreeView1.Location = new Point(6, 19);
		TreeView1.Name = "TreeView1";
		TreeView1.Size = new Size(334, 248);
		TreeView1.TabIndex = 189;
		GroupBoxInterligacao.Controls.Add(btCorDoErroI);
		GroupBoxInterligacao.Controls.Add(btMostraErroVeia);
		GroupBoxInterligacao.Controls.Add(btOcultaErroVeia);
		GroupBoxInterligacao.Location = new Point(151, 125);
		GroupBoxInterligacao.Name = "GroupBoxInterligacao";
		GroupBoxInterligacao.Size = new Size(131, 64);
		GroupBoxInterligacao.TabIndex = 188;
		GroupBoxInterligacao.TabStop = false;
		GroupBoxInterligacao.Text = "Interligação";
		btCorDoErroI.BackColor = Color.Cyan;
		btCorDoErroI.Location = new Point(92, 28);
		btCorDoErroI.Name = "btCorDoErroI";
		btCorDoErroI.Size = new Size(23, 20);
		btCorDoErroI.TabIndex = 182;
		btCorDoErroI.UseVisualStyleBackColor = false;
		btMostraErroVeia.FlatStyle = FlatStyle.Flat;
		btMostraErroVeia.ForeColor = SystemColors.Control;
		btMostraErroVeia.Image = Resources.Liga_32;
		btMostraErroVeia.Location = new Point(6, 18);
		btMostraErroVeia.Name = "btMostraErroVeia";
		btMostraErroVeia.Size = new Size(40, 40);
		btMostraErroVeia.TabIndex = 180;
		btMostraErroVeia.UseVisualStyleBackColor = true;
		btOcultaErroVeia.FlatStyle = FlatStyle.Flat;
		btOcultaErroVeia.ForeColor = SystemColors.Control;
		btOcultaErroVeia.Image = Resources.Desliga_32;
		btOcultaErroVeia.Location = new Point(46, 18);
		btOcultaErroVeia.Name = "btOcultaErroVeia";
		btOcultaErroVeia.Size = new Size(40, 40);
		btOcultaErroVeia.TabIndex = 181;
		btOcultaErroVeia.UseVisualStyleBackColor = true;
		GroupBoxJumper.Controls.Add(btCorDoErroJ);
		GroupBoxJumper.Controls.Add(btMostraErroJumper);
		GroupBoxJumper.Controls.Add(btOcultaErroJumper);
		GroupBoxJumper.Location = new Point(12, 125);
		GroupBoxJumper.Name = "GroupBoxJumper";
		GroupBoxJumper.Size = new Size(131, 64);
		GroupBoxJumper.TabIndex = 186;
		GroupBoxJumper.TabStop = false;
		GroupBoxJumper.Text = "Jumper";
		btCorDoErroJ.BackColor = Color.Magenta;
		btCorDoErroJ.Location = new Point(92, 28);
		btCorDoErroJ.Name = "btCorDoErroJ";
		btCorDoErroJ.Size = new Size(23, 20);
		btCorDoErroJ.TabIndex = 182;
		btCorDoErroJ.UseVisualStyleBackColor = false;
		btMostraErroJumper.FlatStyle = FlatStyle.Flat;
		btMostraErroJumper.ForeColor = SystemColors.Control;
		btMostraErroJumper.Image = Resources.Liga_32;
		btMostraErroJumper.Location = new Point(6, 18);
		btMostraErroJumper.Name = "btMostraErroJumper";
		btMostraErroJumper.Size = new Size(40, 40);
		btMostraErroJumper.TabIndex = 180;
		btMostraErroJumper.UseVisualStyleBackColor = true;
		btOcultaErroJumper.FlatStyle = FlatStyle.Flat;
		btOcultaErroJumper.ForeColor = SystemColors.Control;
		btOcultaErroJumper.Image = Resources.Desliga_32;
		btOcultaErroJumper.Location = new Point(46, 18);
		btOcultaErroJumper.Name = "btOcultaErroJumper";
		btOcultaErroJumper.Size = new Size(40, 40);
		btOcultaErroJumper.TabIndex = 181;
		btOcultaErroJumper.UseVisualStyleBackColor = true;
		btCarrega.FlatStyle = FlatStyle.Flat;
		btCarrega.ForeColor = SystemColors.Control;
		btCarrega.Image = Resources.Pesquisar_32;
		btCarrega.Location = new Point(16, 16);
		btCarrega.Name = "btCarrega";
		btCarrega.Size = new Size(40, 40);
		btCarrega.TabIndex = 181;
		btCarrega.Text = "0";
		btCarrega.UseVisualStyleBackColor = true;
		GBAtualiza.Controls.Add(btCarrega);
		GBAtualiza.Location = new Point(288, 125);
		GBAtualiza.Name = "GBAtualiza";
		GBAtualiza.Size = new Size(71, 64);
		GBAtualiza.TabIndex = 190;
		GBAtualiza.TabStop = false;
		bt5Terminais.Location = new Point(127, 12);
		bt5Terminais.Name = "bt5Terminais";
		bt5Terminais.Size = new Size(115, 23);
		bt5Terminais.TabIndex = 196;
		bt5Terminais.Text = "bt5Terminais";
		bt5Terminais.UseVisualStyleBackColor = true;
		bt9Discrepantes.Location = new Point(127, 64);
		bt9Discrepantes.Name = "bt9Discrepantes";
		bt9Discrepantes.Size = new Size(115, 23);
		bt9Discrepantes.TabIndex = 192;
		bt9Discrepantes.Text = "bt9Discrepantes";
		bt9Discrepantes.UseVisualStyleBackColor = true;
		bt7Reguas.Location = new Point(9, 38);
		bt7Reguas.Name = "bt7Reguas";
		bt7Reguas.Size = new Size(115, 23);
		bt7Reguas.TabIndex = 193;
		bt7Reguas.Text = "bt7Reguas";
		bt7Reguas.UseVisualStyleBackColor = true;
		bt8intervalos.Location = new Point(245, 38);
		bt8intervalos.Name = "bt8intervalos";
		bt8intervalos.Size = new Size(115, 23);
		bt8intervalos.TabIndex = 194;
		bt8intervalos.Text = "bt8intervalos";
		bt8intervalos.UseVisualStyleBackColor = true;
		bt1Interligacao.Location = new Point(9, 12);
		bt1Interligacao.Name = "bt1Interligacao";
		bt1Interligacao.Size = new Size(115, 23);
		bt1Interligacao.TabIndex = 191;
		bt1Interligacao.Text = "bt1Interlig";
		bt1Interligacao.UseVisualStyleBackColor = true;
		bt6Portas.Location = new Point(245, 12);
		bt6Portas.Name = "bt6Portas";
		bt6Portas.Size = new Size(115, 23);
		bt6Portas.TabIndex = 195;
		bt6Portas.Text = "bt6Portas";
		bt6Portas.UseVisualStyleBackColor = true;
		GroupBox9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox9.Controls.Add(dgBornesEditados);
		GroupBox9.Location = new Point(510, 163);
		GroupBox9.Name = "GroupBox9";
		GroupBox9.Size = new Size(80, 37);
		GroupBox9.TabIndex = 208;
		GroupBox9.TabStop = false;
		GroupBox9.Text = "GroupBox9";
		dgBornesEditados.AllowUserToAddRows = false;
		dgBornesEditados.AllowUserToDeleteRows = false;
		dgBornesEditados.AllowUserToResizeRows = false;
		dgBornesEditados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgBornesEditados.BackgroundColor = Color.White;
		dgBornesEditados.BorderStyle = BorderStyle.Fixed3D;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgBornesEditados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgBornesEditados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgBornesEditados.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgBornesEditados.Location = new Point(3, 18);
		dgBornesEditados.Name = "dgBornesEditados";
		dgBornesEditados.ReadOnly = true;
		dgBornesEditados.RowHeadersVisible = false;
		dgBornesEditados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgBornesEditados.Size = new Size(74, 13);
		dgBornesEditados.TabIndex = 200;
		GroupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox6.Controls.Add(dgReguasSemUso);
		GroupBox6.Location = new Point(425, 162);
		GroupBox6.Name = "GroupBox6";
		GroupBox6.Size = new Size(80, 37);
		GroupBox6.TabIndex = 209;
		GroupBox6.TabStop = false;
		GroupBox6.Text = "GroupBox6";
		dgReguasSemUso.AllowUserToAddRows = false;
		dgReguasSemUso.AllowUserToDeleteRows = false;
		dgReguasSemUso.AllowUserToResizeRows = false;
		dgReguasSemUso.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgReguasSemUso.BackgroundColor = Color.White;
		dgReguasSemUso.BorderStyle = BorderStyle.Fixed3D;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dgReguasSemUso.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgReguasSemUso.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgReguasSemUso.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgReguasSemUso.Location = new Point(3, 18);
		dgReguasSemUso.Name = "dgReguasSemUso";
		dgReguasSemUso.ReadOnly = true;
		dgReguasSemUso.RowHeadersVisible = false;
		dgReguasSemUso.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgReguasSemUso.Size = new Size(74, 13);
		dgReguasSemUso.TabIndex = 202;
		GroupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox5.Controls.Add(dgTerminais);
		GroupBox5.Location = new Point(424, 123);
		GroupBox5.Name = "GroupBox5";
		GroupBox5.Size = new Size(80, 37);
		GroupBox5.TabIndex = 212;
		GroupBox5.TabStop = false;
		GroupBox5.Text = "GroupBox5";
		dgTerminais.AllowUserToAddRows = false;
		dgTerminais.AllowUserToDeleteRows = false;
		dgTerminais.AllowUserToResizeRows = false;
		dgTerminais.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgTerminais.BackgroundColor = Color.White;
		dgTerminais.BorderStyle = BorderStyle.Fixed3D;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		dgTerminais.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		dgTerminais.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgTerminais.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgTerminais.Location = new Point(3, 18);
		dgTerminais.Name = "dgTerminais";
		dgTerminais.ReadOnly = true;
		dgTerminais.RowHeadersVisible = false;
		dgTerminais.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgTerminais.Size = new Size(74, 13);
		dgTerminais.TabIndex = 199;
		GroupBox7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox7.Controls.Add(TreeViewBornes);
		GroupBox7.Location = new Point(425, 200);
		GroupBox7.Name = "GroupBox7";
		GroupBox7.Size = new Size(80, 37);
		GroupBox7.TabIndex = 210;
		GroupBox7.TabStop = false;
		GroupBox7.Text = "GroupBox7";
		TreeViewBornes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TreeViewBornes.Location = new Point(3, 18);
		TreeViewBornes.Name = "TreeViewBornes";
		TreeViewBornes.Size = new Size(74, 13);
		TreeViewBornes.TabIndex = 190;
		GroupBox8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox8.Controls.Add(dgBornes);
		GroupBox8.Location = new Point(510, 125);
		GroupBox8.Name = "GroupBox8";
		GroupBox8.Size = new Size(80, 37);
		GroupBox8.TabIndex = 211;
		GroupBox8.TabStop = false;
		GroupBox8.Text = "GroupBox8";
		dgBornes.AllowUserToAddRows = false;
		dgBornes.AllowUserToDeleteRows = false;
		dgBornes.AllowUserToResizeRows = false;
		dgBornes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgBornes.BackgroundColor = Color.White;
		dgBornes.BorderStyle = BorderStyle.Fixed3D;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = SystemColors.Control;
		dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		dgBornes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
		dgBornes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgBornes.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgBornes.Location = new Point(3, 18);
		dgBornes.Name = "dgBornes";
		dgBornes.ReadOnly = true;
		dgBornes.RowHeadersVisible = false;
		dgBornes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgBornes.Size = new Size(74, 13);
		dgBornes.TabIndex = 199;
		GB1Interligacao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GB1Interligacao.Controls.Add(TreeView1);
		GB1Interligacao.Location = new Point(12, 188);
		GB1Interligacao.Name = "GB1Interligacao";
		GB1Interligacao.Size = new Size(347, 273);
		GB1Interligacao.TabIndex = 213;
		GB1Interligacao.TabStop = false;
		GB1Interligacao.Text = "GBInter";
		bt10BornesLM.Location = new Point(9, 64);
		bt10BornesLM.Name = "bt10BornesLM";
		bt10BornesLM.Size = new Size(115, 23);
		bt10BornesLM.TabIndex = 214;
		bt10BornesLM.Text = "bt10BornesLM";
		bt10BornesLM.UseVisualStyleBackColor = true;
		GBEX.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GBEX.Location = new Point(11, 123);
		GBEX.Name = "GBEX";
		GBEX.Size = new Size(349, 338);
		GBEX.TabIndex = 215;
		GBEX.TabStop = false;
		GBEX.Text = "GBEX";
		GroupBox12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox12.Controls.Add(dgAMao);
		GroupBox12.Location = new Point(593, 159);
		GroupBox12.Name = "GroupBox12";
		GroupBox12.Size = new Size(80, 37);
		GroupBox12.TabIndex = 197;
		GroupBox12.TabStop = false;
		GroupBox12.Text = "GroupBox12";
		dgAMao.AllowUserToAddRows = false;
		dgAMao.AllowUserToDeleteRows = false;
		dgAMao.AllowUserToResizeRows = false;
		dgAMao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgAMao.BackgroundColor = Color.White;
		dgAMao.BorderStyle = BorderStyle.Fixed3D;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle5.BackColor = SystemColors.Control;
		dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
		dgAMao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
		dgAMao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgAMao.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgAMao.Location = new Point(4, 17);
		dgAMao.Name = "dgAMao";
		dgAMao.ReadOnly = true;
		dgAMao.RowHeadersVisible = false;
		dgAMao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgAMao.Size = new Size(74, 13);
		dgAMao.TabIndex = 201;
		GroupBox10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox10.Controls.Add(TreeViewBornesLM);
		GroupBox10.Location = new Point(509, 201);
		GroupBox10.Name = "GroupBox10";
		GroupBox10.Size = new Size(80, 37);
		GroupBox10.TabIndex = 216;
		GroupBox10.TabStop = false;
		GroupBox10.Text = "GroupBox10";
		TreeViewBornesLM.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TreeViewBornesLM.Location = new Point(3, 18);
		TreeViewBornesLM.Name = "TreeViewBornesLM";
		TreeViewBornesLM.Size = new Size(74, 13);
		TreeViewBornesLM.TabIndex = 190;
		GroupBox11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox11.Controls.Add(dgPainelApagado);
		GroupBox11.Location = new Point(593, 125);
		GroupBox11.Name = "GroupBox11";
		GroupBox11.Size = new Size(80, 37);
		GroupBox11.TabIndex = 196;
		GroupBox11.TabStop = false;
		GroupBox11.Text = "GroupBox11";
		dgPainelApagado.AllowUserToAddRows = false;
		dgPainelApagado.AllowUserToDeleteRows = false;
		dgPainelApagado.AllowUserToResizeRows = false;
		dgPainelApagado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgPainelApagado.BackgroundColor = Color.White;
		dgPainelApagado.BorderStyle = BorderStyle.Fixed3D;
		dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle6.BackColor = SystemColors.Control;
		dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
		dgPainelApagado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
		dgPainelApagado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPainelApagado.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgPainelApagado.Location = new Point(3, 17);
		dgPainelApagado.Name = "dgPainelApagado";
		dgPainelApagado.ReadOnly = true;
		dgPainelApagado.RowHeadersVisible = false;
		dgPainelApagado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPainelApagado.Size = new Size(74, 13);
		dgPainelApagado.TabIndex = 201;
		bt11Paineis.Location = new Point(245, 64);
		bt11Paineis.Name = "bt11Paineis";
		bt11Paineis.Size = new Size(115, 23);
		bt11Paineis.TabIndex = 217;
		bt11Paineis.Text = "bt11Paineis";
		bt11Paineis.UseVisualStyleBackColor = true;
		bt12AMao.Location = new Point(9, 90);
		bt12AMao.Name = "bt12AMao";
		bt12AMao.Size = new Size(115, 23);
		bt12AMao.TabIndex = 218;
		bt12AMao.Text = "bt12AMao";
		bt12AMao.UseVisualStyleBackColor = true;
		BT13Discrepantes.Font = new Font("Microsoft Sans Serif", 7.5f, FontStyle.Regular, GraphicsUnit.Point, 0);
		BT13Discrepantes.Location = new Point(127, 90);
		BT13Discrepantes.Name = "BT13Discrepantes";
		BT13Discrepantes.Size = new Size(115, 23);
		BT13Discrepantes.TabIndex = 219;
		BT13Discrepantes.Text = "BT13Discrepantes";
		BT13Discrepantes.UseVisualStyleBackColor = true;
		GroupBox13.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox13.Controls.Add(LBPNCadastro);
		GroupBox13.Controls.Add(BTCorrigirDiscrepante);
		GroupBox13.Controls.Add(LBPNDes);
		GroupBox13.Controls.Add(LBTag);
		GroupBox13.Controls.Add(DGDiscrepantes);
		GroupBox13.Location = new Point(419, 272);
		GroupBox13.Name = "GroupBox13";
		GroupBox13.Size = new Size(349, 76);
		GroupBox13.TabIndex = 220;
		GroupBox13.TabStop = false;
		GroupBox13.Text = "GroupBox13";
		LBPNCadastro.AutoSize = true;
		LBPNCadastro.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		LBPNCadastro.Location = new Point(212, 15);
		LBPNCadastro.Name = "LBPNCadastro";
		LBPNCadastro.RightToLeft = RightToLeft.No;
		LBPNCadastro.Size = new Size(111, 15);
		LBPNCadastro.TabIndex = 227;
		LBPNCadastro.Text = "Equip. de Cadastro";
		LBPNCadastro.TextAlign = ContentAlignment.MiddleCenter;
		BTCorrigirDiscrepante.Anchor = AnchorStyles.Bottom;
		BTCorrigirDiscrepante.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		BTCorrigirDiscrepante.ForeColor = Color.Red;
		BTCorrigirDiscrepante.Location = new Point(115, 33);
		BTCorrigirDiscrepante.Name = "BTCorrigirDiscrepante";
		BTCorrigirDiscrepante.Size = new Size(116, 35);
		BTCorrigirDiscrepante.TabIndex = 221;
		BTCorrigirDiscrepante.Text = "Corrigir";
		BTCorrigirDiscrepante.UseVisualStyleBackColor = true;
		LBPNDes.AutoSize = true;
		LBPNDes.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		LBPNDes.Location = new Point(85, 15);
		LBPNDes.Name = "LBPNDes";
		LBPNDes.RightToLeft = RightToLeft.No;
		LBPNDes.Size = new Size(112, 15);
		LBPNDes.TabIndex = 226;
		LBPNDes.Text = "Equip. de Desenho";
		LBPNDes.TextAlign = ContentAlignment.MiddleCenter;
		LBTag.AutoSize = true;
		LBTag.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		LBTag.Location = new Point(20, 15);
		LBTag.Name = "LBTag";
		LBTag.RightToLeft = RightToLeft.No;
		LBTag.Size = new Size(43, 15);
		LBTag.TabIndex = 221;
		LBTag.Text = "LBTag";
		LBTag.TextAlign = ContentAlignment.MiddleCenter;
		DGDiscrepantes.AllowUserToAddRows = false;
		DGDiscrepantes.AllowUserToDeleteRows = false;
		DGDiscrepantes.AllowUserToResizeRows = false;
		DGDiscrepantes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DGDiscrepantes.BackgroundColor = Color.White;
		DGDiscrepantes.BorderStyle = BorderStyle.Fixed3D;
		dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle7.BackColor = SystemColors.Control;
		dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
		DGDiscrepantes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
		DGDiscrepantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGDiscrepantes.EditMode = DataGridViewEditMode.EditProgrammatically;
		DGDiscrepantes.Location = new Point(4, 17);
		DGDiscrepantes.Name = "DGDiscrepantes";
		DGDiscrepantes.ReadOnly = true;
		DGDiscrepantes.RowHeadersVisible = false;
		DGDiscrepantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGDiscrepantes.Size = new Size(343, 11);
		DGDiscrepantes.TabIndex = 201;
		BT14CabosFaltantes.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		BT14CabosFaltantes.Location = new Point(245, 90);
		BT14CabosFaltantes.Name = "BT14CabosFaltantes";
		BT14CabosFaltantes.Size = new Size(115, 23);
		BT14CabosFaltantes.TabIndex = 221;
		BT14CabosFaltantes.Text = "BT14CabosFaltantes";
		BT14CabosFaltantes.UseVisualStyleBackColor = true;
		GroupBox14.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox14.Controls.Add(BTCorrigeCabos);
		GroupBox14.Controls.Add(DGCabosDoBanco);
		GroupBox14.Location = new Point(594, 198);
		GroupBox14.Name = "GroupBox14";
		GroupBox14.Size = new Size(124, 80);
		GroupBox14.TabIndex = 222;
		GroupBox14.TabStop = false;
		GroupBox14.Text = "GroupBox14";
		BTCorrigeCabos.Anchor = AnchorStyles.Bottom;
		BTCorrigeCabos.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		BTCorrigeCabos.ForeColor = Color.Red;
		BTCorrigeCabos.Location = new Point(4, 38);
		BTCorrigeCabos.Name = "BTCorrigeCabos";
		BTCorrigeCabos.Size = new Size(116, 35);
		BTCorrigeCabos.TabIndex = 222;
		BTCorrigeCabos.Text = "Corrigir";
		BTCorrigeCabos.UseVisualStyleBackColor = true;
		DGCabosDoBanco.AllowUserToAddRows = false;
		DGCabosDoBanco.AllowUserToDeleteRows = false;
		DGCabosDoBanco.AllowUserToResizeRows = false;
		DGCabosDoBanco.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		DGCabosDoBanco.BackgroundColor = Color.White;
		DGCabosDoBanco.BorderStyle = BorderStyle.Fixed3D;
		dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle8.BackColor = SystemColors.Control;
		dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
		DGCabosDoBanco.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
		DGCabosDoBanco.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		DGCabosDoBanco.EditMode = DataGridViewEditMode.EditProgrammatically;
		DGCabosDoBanco.Location = new Point(4, 17);
		DGCabosDoBanco.Name = "DGCabosDoBanco";
		DGCabosDoBanco.ReadOnly = true;
		DGCabosDoBanco.RowHeadersVisible = false;
		DGCabosDoBanco.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		DGCabosDoBanco.Size = new Size(118, 12);
		DGCabosDoBanco.TabIndex = 201;
		bt15ReguaMascara.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		bt15ReguaMascara.Location = new Point(127, 38);
		bt15ReguaMascara.Name = "bt15ReguaMascara";
		bt15ReguaMascara.Size = new Size(115, 23);
		bt15ReguaMascara.TabIndex = 223;
		bt15ReguaMascara.Text = "bt15ReguaMascara";
		bt15ReguaMascara.UseVisualStyleBackColor = true;
		GroupBox15.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox15.Controls.Add(dgReguaMascara);
		GroupBox15.Location = new Point(426, 237);
		GroupBox15.Name = "GroupBox15";
		GroupBox15.Size = new Size(80, 37);
		GroupBox15.TabIndex = 224;
		GroupBox15.TabStop = false;
		GroupBox15.Text = "GroupBox15";
		dgReguaMascara.AllowUserToAddRows = false;
		dgReguaMascara.AllowUserToDeleteRows = false;
		dgReguaMascara.AllowUserToResizeRows = false;
		dgReguaMascara.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgReguaMascara.BackgroundColor = Color.White;
		dgReguaMascara.BorderStyle = BorderStyle.Fixed3D;
		dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle9.BackColor = SystemColors.Control;
		dataGridViewCellStyle9.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
		dgReguaMascara.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
		dgReguaMascara.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgReguaMascara.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgReguaMascara.Location = new Point(3, 17);
		dgReguaMascara.Name = "dgReguaMascara";
		dgReguaMascara.ReadOnly = true;
		dgReguaMascara.RowHeadersVisible = false;
		dgReguaMascara.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgReguaMascara.Size = new Size(74, 13);
		dgReguaMascara.TabIndex = 201;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(364, 462);
		Controls.Add(GroupBox15);
		Controls.Add(bt15ReguaMascara);
		Controls.Add(GroupBox12);
		Controls.Add(GroupBox14);
		Controls.Add(GroupBox9);
		Controls.Add(BT14CabosFaltantes);
		Controls.Add(GroupBox10);
		Controls.Add(GroupBox13);
		Controls.Add(GroupBox11);
		Controls.Add(BT13Discrepantes);
		Controls.Add(GroupBox8);
		Controls.Add(bt12AMao);
		Controls.Add(bt11Paineis);
		Controls.Add(bt10BornesLM);
		Controls.Add(GroupBox6);
		Controls.Add(GroupBox5);
		Controls.Add(GroupBox7);
		Controls.Add(bt5Terminais);
		Controls.Add(bt9Discrepantes);
		Controls.Add(bt7Reguas);
		Controls.Add(bt8intervalos);
		Controls.Add(bt1Interligacao);
		Controls.Add(bt6Portas);
		Controls.Add(GBAtualiza);
		Controls.Add(GroupBoxInterligacao);
		Controls.Add(GroupBoxJumper);
		Controls.Add(GBEX);
		Controls.Add(GB1Interligacao);
		MaximumSize = new Size(380, 1000);
		MinimumSize = new Size(380, 500);
		Name = "frmVerificadorProjetoInterligacao";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Verificador Projeto";
		GroupBoxInterligacao.ResumeLayout(performLayout: false);
		GroupBoxJumper.ResumeLayout(performLayout: false);
		GBAtualiza.ResumeLayout(performLayout: false);
		GroupBox9.ResumeLayout(performLayout: false);
		((ISupportInitialize)dgBornesEditados).EndInit();
		GroupBox6.ResumeLayout(performLayout: false);
		((ISupportInitialize)dgReguasSemUso).EndInit();
		GroupBox5.ResumeLayout(performLayout: false);
		((ISupportInitialize)dgTerminais).EndInit();
		GroupBox7.ResumeLayout(performLayout: false);
		GroupBox8.ResumeLayout(performLayout: false);
		((ISupportInitialize)dgBornes).EndInit();
		GB1Interligacao.ResumeLayout(performLayout: false);
		GroupBox12.ResumeLayout(performLayout: false);
		((ISupportInitialize)dgAMao).EndInit();
		GroupBox10.ResumeLayout(performLayout: false);
		GroupBox11.ResumeLayout(performLayout: false);
		((ISupportInitialize)dgPainelApagado).EndInit();
		GroupBox13.ResumeLayout(performLayout: false);
		GroupBox13.PerformLayout();
		((ISupportInitialize)DGDiscrepantes).EndInit();
		GroupBox14.ResumeLayout(performLayout: false);
		((ISupportInitialize)DGCabosDoBanco).EndInit();
		GroupBox15.ResumeLayout(performLayout: false);
		((ISupportInitialize)dgReguaMascara).EndInit();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return Lv82dyhglJ;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		Lv82dyhglJ = WithEventsValue;
	}

	public frmVerificadorProjetoInterligacao()
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected Obj, but got Unknown
		FormClosed += [SpecialName] [DebuggerHidden] (object a0, FormClosedEventArgs a1) =>
		{
			Finalize();
		};
		Resize += SRKeiGKfFT;
		Ntj3HDmrBL = new List<string>();
		n8Q3kbOWxr = new List<string>();
		sEP3dSGtKV = new ColorDialog();
		mT43v7CK32 = new DataGridViewCellStyle();
		XSR36apgl1 = new DataGridViewCellStyle();
		eJK3tCnFyq = false;
		sJM3j8kR2H = false;
		yx83xxOcMO = new List<string>();
		checked
		{
			try
			{
				if (!Geral.ExisteForm("frmVerificadorProjetoInterligacao"))
				{
					ALueQmTvI3();
					BT13Discrepantes.Enabled = true;
					DeclaracoesGeral._uscPagina.Quantidade = 12;
					DeclaracoesGeral._uscPagina.pbIniciar();
					string sTipo = "";
					clsBlocos.ApagaERROS(ref sTipo);
					DeclaracoesGeral._uscPagina.pbPasso();
					clsDispositivoAuxiliares.SincronizaContatos(0, bMarcaErros: false);
					DeclaracoesGeral._uscPagina.pbPasso();
					clsPortas.SincronizaPortas(bMarcaErros: false, bProgress: false);
					DeclaracoesGeral._uscPagina.pbPasso();
					clsBlocos.VerificaDuplicados(ref b8E3LytR55, bProgress: false);
					DeclaracoesGeral._uscPagina.pbPasso();
					clsEditarInterligacao.CaboseVeiasDoCadernoDiscrepantes(bPesquisa: true, ref w9l3w2QBKA);
					DeclaracoesGeral._uscPagina.pbPasso();
					CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
					cDadosAccessInterligacao3.LeCabosTodosOsCabos(ref yx83xxOcMO);
					cDadosAccessInterligacao3.FechaConexao();
					DeclaracoesGeral._uscPagina.pbPasso();
					dM23f4hVwR = 6;
					xxJ3DnmHiI = 4;
					DBq3WCe4c2 = new clsVerificadorProjetoInterligacao.StructureJumper[1];
					AIT3peilyC = new clsVerificadorProjetoInterligacao.StructureJumper[1];
					cDadosAccess.carregaDadosDWG();
					DeclaracoesGeral._uscPagina.pbPasso();
					ClsVerificadorProjetoFiacao.buscaPaineisDoDG(ref Ntj3HDmrBL, ref n8Q3kbOWxr);
					DeclaracoesGeral._uscPagina.pbPasso();
					sju3bdCB5q = new structureNomeVeiasEditadar[1];
					clsInterligacao.LeTodasAsVeiasUsadasNoDesenho(ref sju3bdCB5q);
					DeclaracoesGeral._uscPagina.pbPasso();
					GroupBoxJumper.Enabled = true;
					GroupBoxInterligacao.Enabled = true;
					Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1636]);
					GroupBoxJumper.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 549]);
					GroupBoxInterligacao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 508]);
					GB1Interligacao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 508]);
					GroupBox5.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 631]);
					GroupBox6.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1565]);
					GroupBox7.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1563]);
					GroupBox8.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1629]);
					GroupBox9.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1635]);
					GroupBox10.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1564]);
					GroupBox11.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1671]);
					GroupBox12.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1111]);
					GroupBox13.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1678]);
					GroupBox14.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1685]);
					GroupBox15.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1709]);
					bt1Interligacao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1650]);
					bt5Terminais.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 631]);
					bt6Portas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1648]);
					bt7Reguas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1649]);
					bt8intervalos.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1634]);
					bt9Discrepantes.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1635]);
					bt10BornesLM.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1651]);
					bt11Paineis.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1671]);
					bt12AMao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1111]);
					BT13Discrepantes.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1678]);
					BT14CabosFaltantes.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1686]);
					bt15ReguaMascara.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1708]);
					BTCorrigirDiscrepante.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1681]);
					BTCorrigeCabos.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1681]);
					LBTag.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 514]);
					LBPNDes.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1679]);
					LBPNCadastro.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1680]);
					bt1Interligacao.Enabled = false;
					bt5Terminais.Enabled = false;
					bt7Reguas.Enabled = false;
					bt8intervalos.Enabled = false;
					bt6Portas.Enabled = false;
					bt9Discrepantes.Enabled = false;
					bt10BornesLM.Enabled = false;
					bt11Paineis.Enabled = false;
					bt12AMao.Enabled = false;
					BT13Discrepantes.Enabled = false;
					BT14CabosFaltantes.Enabled = false;
					bt15ReguaMascara.Enabled = false;
					GBEX.Visible = false;
					Application.ShowModelessDialog((Form)this);
					DeclaracoesGeral._uscPagina.pbPasso();
					Correcao.ApagaXDataTerceiros();
					DeclaracoesGeral._uscPagina.pbPasso();
					GroupBox5.Location = GBEX.Location;
					GroupBox6.Location = GBEX.Location;
					GroupBox7.Location = GBEX.Location;
					GroupBox8.Location = GBEX.Location;
					GroupBox9.Location = GBEX.Location;
					GroupBox10.Location = GBEX.Location;
					GroupBox11.Location = GBEX.Location;
					GroupBox12.Location = GBEX.Location;
					GroupBox13.Location = GBEX.Location;
					GroupBox14.Location = GBEX.Location;
					GroupBox15.Location = GBEX.Location;
					GroupBox5.Size = GBEX.Size;
					GroupBox6.Size = GBEX.Size;
					GroupBox7.Size = GBEX.Size;
					GroupBox8.Size = GBEX.Size;
					GroupBox9.Size = GBEX.Size;
					GroupBox10.Size = GBEX.Size;
					GroupBox11.Size = GBEX.Size;
					GroupBox12.Size = GBEX.Size;
					GroupBox13.Size = GBEX.Size;
					GroupBox14.Size = GBEX.Size;
					GroupBox15.Size = GBEX.Size;
					DGDiscrepantes.Location = new Point(DGDiscrepantes.Location.X, DGDiscrepantes.Location.Y + 20);
					DGDiscrepantes.Size = new Size(DGDiscrepantes.Size.Width, DGDiscrepantes.Size.Height - 25);
					GroupBox5.Visible = false;
					GroupBox6.Visible = false;
					GroupBox7.Visible = false;
					GroupBox8.Visible = false;
					GroupBox9.Visible = false;
					GroupBox10.Visible = false;
					GroupBox11.Visible = false;
					GroupBox12.Visible = false;
					GroupBox13.Visible = false;
					GroupBox14.Visible = false;
					GroupBox15.Visible = false;
					mT43v7CK32.BackColor = Color.LightCoral;
					XSR36apgl1.BackColor = Color.LightGray;
					DeclaracoesGeral._uscPagina.pbPasso();
					CarregaInterligacao(bProgress: true);
					DeclaracoesGeral._uscPagina.pbPasso();
					if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
					{
						Left = 0;
					}
					DeclaracoesGeral._uscPagina.pbFim();
					sJM3j8kR2H = true;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void lGoePCHpnB(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = sEP3dSGtKV.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			dM23f4hVwR = sEP3dSGtKV.Color.ColorIndex;
			btCorDoErroJ.BackColor = sEP3dSGtKV.Color.ColorValue;
		}
	}

	private void HtaecV7Qh7(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = sEP3dSGtKV.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			xxJ3DnmHiI = sEP3dSGtKV.Color.ColorIndex;
			btCorDoErroI.BackColor = sEP3dSGtKV.Color.ColorValue;
		}
	}

	public void CarregaErros(clsVerificadorProjetoInterligacao.StructureJumper[] mErros, string sRel)
	{
		if (Information.UBound(mErros) < 2)
		{
			return;
		}
		int num = Information.UBound(mErros);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				int num2 = Information.UBound(mErros) - 1;
				int num3 = i;
				for (int j = num2; j >= num3; j += -1)
				{
					if (mErros[j].iPotencial_Veia > mErros[j + 1].iPotencial_Veia)
					{
						clsVerificadorProjetoInterligacao.StructureJumper structureJumper = mErros[j + 1];
						mErros[j + 1] = mErros[j];
						mErros[j] = structureJumper;
					}
				}
			}
		}
	}

	~frmVerificadorProjetoInterligacao()
	{
		clsBlocos.Unhighlight();
		if (!Information.IsNothing(DBq3WCe4c2))
		{
			clsVerificadorProjetoInterligacao.PintaJumper(ref DBq3WCe4c2);
		}
		if (!Information.IsNothing(AIT3peilyC))
		{
			clsVerificadorProjetoInterligacao.PintaInterlig(ref AIT3peilyC);
		}
	}

	private void cKoeKwlH8N(object P_0, EventArgs P_1)
	{
		clsVerificadorProjetoInterligacao.PintaJumper(ref DBq3WCe4c2, dM23f4hVwR);
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
	}

	private void CRLeeYHp8N(object P_0, EventArgs P_1)
	{
		clsVerificadorProjetoInterligacao.PintaJumper(ref DBq3WCe4c2);
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
	}

	private void tFKe29ay3Z(object P_0, EventArgs P_1)
	{
		clsVerificadorProjetoInterligacao.PintaInterlig(ref AIT3peilyC, xxJ3DnmHiI);
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
	}

	private void OJfe3aTN4i(object P_0, EventArgs P_1)
	{
		clsVerificadorProjetoInterligacao.PintaInterlig(ref AIT3peilyC);
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
	}

	private void B6qenXYSSI(object P_0, TreeViewEventArgs P_1)
	{
		if (P_1.Node.ForeColor == Color.Red && P_1.Node.Level == 2)
		{
			clsVerificadorProjetoInterligacao.mostraIndefinidos(P_1.Node.Text);
		}
	}

	private void qbEe1cYaTx(object P_0, DataGridViewCellEventArgs P_1)
	{
		string sPotencial = clsTextos.TiraNothing(Conversions.ToString(DGDiscrepantes.SelectedRows[0].Cells[5].Value)).ToString();
		clsVerificadorProjetoInterligacao.mostraIndefinidos(sPotencial);
	}

	private void oO9eli2qDX(object P_0, EventArgs P_1)
	{
		CarregaInterligacao();
	}

	public void CarregaInterligacao(bool bProgress = false)
	{
		if (Information.UBound(DBq3WCe4c2) > 0)
		{
			clsVerificadorProjetoInterligacao.PintaJumper(ref DBq3WCe4c2);
		}
		if (Information.UBound(AIT3peilyC) > 0)
		{
			clsVerificadorProjetoInterligacao.PintaInterlig(ref AIT3peilyC);
		}
		sJM3j8kR2H = false;
		DBq3WCe4c2 = new clsVerificadorProjetoInterligacao.StructureJumper[1];
		AIT3peilyC = new clsVerificadorProjetoInterligacao.StructureJumper[1];
		TLl3Tb64JD = new ClsVerificadorProjetoFiacao._StructureConexao[1];
		NMc3JFnBaS = new DeclaracoesEntidades.StructureBorne[1];
		vTJ3hn9llT = new ClsVerificadorProjetoFiacao._StructureAnalisePorta[1];
		DuZ3okk8Hh = new ClsVerificadorProjetoFiacao._StructuremDispositivo[1];
		mjD3GIk5FY = new ClsVerificadorProjetoFiacao._StructuremAuxiliar[1];
		List<string> LFiacaoTTDuplicada = new List<string>();
		TreeView1.Nodes.Clear();
		TreeViewBornes.Nodes.Clear();
		TreeViewBornesLM.Nodes.Clear();
		ClsVerificadorProjetoFiacao.buscaDadosDeFiacaoDWG(ref TLl3Tb64JD, ref NMc3JFnBaS, ref vTJ3hn9llT, ref DuZ3okk8Hh, ref mjD3GIk5FY, ref Ntj3HDmrBL, ref n8Q3kbOWxr, ref LFiacaoTTDuplicada, "J");
		clsVerificadorProjetoInterligacao.buscaDadosDoDWG(ref DBq3WCe4c2, ref AIT3peilyC, ref n8Q3kbOWxr);
		clsBlocos.VerificaDuplicados(ref b8E3LytR55, bProgress: false);
		if (TreeView1.Nodes.Count == 0)
		{
			TreeView tree = TreeView1;
			clsVerificadorProjetoInterligacao.carregaTree(ref tree, DBq3WCe4c2, AIT3peilyC, n8Q3kbOWxr, LFiacaoTTDuplicada);
			TreeView1 = tree;
		}
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		if (TreeView1.Nodes.Count == 0)
		{
			TreeView tree = TreeView1;
			ClsVerificadorProjetoFiacao.carregaTree(ref tree, TLl3Tb64JD, LFiacaoTTDuplicada, ref Qlj3M7lYrn);
			TreeView1 = tree;
		}
		if (Information.UBound(TLl3Tb64JD) <= 0)
		{
			GB1Interligacao.Enabled = false;
		}
		else
		{
			GB1Interligacao.Enabled = true;
		}
		if (TreeView1.Nodes.Count > 0)
		{
			GB1Interligacao.Enabled = true;
		}
		DyAe5NAtvi();
		formatadgReguasSemUso();
		unLe0hdK5b();
		AtualizaReguasSemUso();
		bkueRiqG45();
		l6Cemb5IWZ();
		BC3eXFk6iP();
		HLteUkrJM0();
		OdFey77530();
		HifeAOwtAh();
		CarregaCabosDoBanco(sju3bdCB5q);
		TU9egJVMTL();
		bt1Interligacao.Enabled = true;
		bt5Terminais.Enabled = true;
		bt6Portas.Enabled = true;
		bt8intervalos.Enabled = true;
		bt7Reguas.Enabled = true;
		bt9Discrepantes.Enabled = true;
		bt10BornesLM.Enabled = true;
		bt11Paineis.Enabled = true;
		bt12AMao.Enabled = true;
		BT13Discrepantes.Enabled = true;
		BT14CabosFaltantes.Enabled = true;
		bt15ReguaMascara.Enabled = true;
		if (dgTerminais.RowCount == 0)
		{
			bt5Terminais.Enabled = false;
		}
		if (dgBornes.RowCount == 0)
		{
			bt6Portas.Enabled = false;
		}
		if (TreeViewBornes.Nodes.Count == 0)
		{
			bt8intervalos.Enabled = false;
		}
		if (dgReguasSemUso.RowCount == 0)
		{
			bt7Reguas.Enabled = false;
		}
		if (dgBornesEditados.RowCount == 0)
		{
			bt9Discrepantes.Enabled = false;
		}
		if (TreeViewBornesLM.Nodes.Count == 0)
		{
			bt10BornesLM.Enabled = false;
		}
		if (dgPainelApagado.RowCount == 0)
		{
			bt11Paineis.Enabled = false;
		}
		if (dgAMao.RowCount == 0)
		{
			bt12AMao.Enabled = false;
		}
		if (DGDiscrepantes.RowCount == 0)
		{
			BT13Discrepantes.Enabled = false;
		}
		if (DGCabosDoBanco.RowCount == 0)
		{
			BT14CabosFaltantes.Enabled = false;
		}
		if (dgReguaMascara.RowCount == 0)
		{
			bt15ReguaMascara.Enabled = false;
		}
		TreeView1.ExpandAll();
		TreeViewBornes.ExpandAll();
		TreeViewBornesLM.ExpandAll();
		sJM3j8kR2H = true;
		mostraBT(1);
	}

	private void DyAe5NAtvi()
	{
		ClsVerificadorProjetoFiacao._errosPorta[] array = null;
		int num = 0;
		array = new ClsVerificadorProjetoFiacao._errosPorta[1];
		ClsVerificadorProjetoFiacao._errosPorta[] array2 = null;
		int num2 = 0;
		array2 = new ClsVerificadorProjetoFiacao._errosPorta[1];
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		int num3 = Information.UBound(vTJ3hn9llT);
		checked
		{
			for (int i = 0; i <= num3; i++)
			{
				if ((Operators.CompareString(clsTextos.TiraNothing(vTJ3hn9llT[i].sTermM), "", TextCompare: true) != 0) | (Operators.CompareString(clsTextos.TiraNothing(vTJ3hn9llT[i].sTerm), "", TextCompare: true) != 0))
				{
					num++;
					array = (ClsVerificadorProjetoFiacao._errosPorta[])Utils.CopyArray(array, new ClsVerificadorProjetoFiacao._errosPorta[num + 1]);
					array[num].iIndiceMascara = vTJ3hn9llT[i].indexMascara;
					array[num].iIndicePorta = vTJ3hn9llT[i].indexPorta;
					array[num].sEfc = vTJ3hn9llT[i].sEFC;
					array[num].sRegua = vTJ3hn9llT[i].sRegua;
					array[num].sTerBorne = clsTextos.TiraNothing(vTJ3hn9llT[i].sTerm);
					array[num].sNome = vTJ3hn9llT[i].sNomeMascara;
					array[num].sIndefinido = clsTextos.TiraNothing(vTJ3hn9llT[i].sTerm);
					array[num].sDuplicado = "";
					array[num].sHandle = vTJ3hn9llT[i].sHandle;
					string[] array3 = array[num].sTerBorne.Split(',');
					if (Information.UBound(array3) > 0)
					{
						int num4 = Information.UBound(array3);
						for (int j = 0; j <= num4; j++)
						{
							if (Operators.CompareString(array3[j].Trim(), "", TextCompare: true) == 0)
							{
								continue;
							}
							string item = array[num].sNome + "-" + array3[j].Trim();
							if (Operators.CompareString(array3[j].Trim(), DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) != 0)
							{
								if (list.Contains(item))
								{
									ref string sDuplicado = ref array[num].sDuplicado;
									sDuplicado = sDuplicado + array3[j].Trim() + ", ";
								}
								else
								{
									list.Add(item);
								}
							}
							else
							{
								array[num].sIndefinido = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
							}
						}
					}
				}
				if (!((Operators.CompareString(clsTextos.TiraNothing(vTJ3hn9llT[i].sattB), "", TextCompare: true) != 0) | (Operators.CompareString(clsTextos.TiraNothing(vTJ3hn9llT[i].sBorn), "", TextCompare: true) != 0)))
				{
					continue;
				}
				num2++;
				array2 = (ClsVerificadorProjetoFiacao._errosPorta[])Utils.CopyArray(array2, new ClsVerificadorProjetoFiacao._errosPorta[num2 + 1]);
				array2[num2].iIndiceMascara = vTJ3hn9llT[i].indexMascara;
				array2[num2].iIndicePorta = vTJ3hn9llT[i].indexPorta;
				array2[num2].sEfc = vTJ3hn9llT[i].sEFC;
				array2[num2].sRegua = vTJ3hn9llT[i].sRegua;
				array2[num2].sTerBorne = clsTextos.TiraNothing(vTJ3hn9llT[i].sBorn);
				array2[num2].sNome = vTJ3hn9llT[i].sNomeMascara;
				array2[num2].sIndefinido = clsTextos.TiraNothing(vTJ3hn9llT[i].sBorn);
				array2[num2].sDuplicado = "";
				array2[num2].sHandle = vTJ3hn9llT[i].sHandle;
				string[] array4 = array2[num2].sTerBorne.Split(',');
				if (Information.UBound(array4) <= 0)
				{
					continue;
				}
				int num5 = Information.UBound(array4);
				for (int k = 0; k <= num5; k++)
				{
					if (Operators.CompareString(array4[k].Trim(), "", TextCompare: true) == 0)
					{
						continue;
					}
					array4[k] = array4[k].Trim();
					string item2 = array2[num2].sNome + "-" + array2[num2].sRegua + "-" + array4[k].Trim();
					if (Operators.CompareString(array4[k].Trim(), DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) != 0)
					{
						if (list2.Contains(item2))
						{
							ref string sDuplicado2 = ref array2[num2].sDuplicado;
							sDuplicado2 = sDuplicado2 + array4[k].Trim() + ", ";
						}
						else
						{
							list2.Add(item2);
						}
					}
					else
					{
						array2[num2].sIndefinido = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
					}
				}
			}
			formatadgTerminais();
			string left = "";
			string left2 = "";
			int num6 = Information.UBound(array);
			for (int l = 1; l <= num6; l++)
			{
				string left3 = clsTextos.TiraNothing(array[l].sIndefinido);
				if (Operators.CompareString(left3, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) != 0)
				{
					continue;
				}
				if (Operators.CompareString(left, "", TextCompare: true) == 0)
				{
					dgTerminais.Rows.Add(DeclaracoesGeral.mMensagem[1, 1492].ToString().ToUpper(), "", "", "");
					left = DeclaracoesGeral.mMensagem[1, 1492].ToString().ToUpper();
					left = DeclaracoesGeral.mMensagem[1, 1492].ToString().ToUpper();
					int num7 = 0;
					do
					{
						dgTerminais.Rows[dgTerminais.RowCount - 1].Cells[num7].Style = XSR36apgl1;
						num7++;
					}
					while (num7 <= 3);
					dgTerminais.Rows[dgTerminais.Rows.Count - 1].Cells[0].Style.Font = new Font("Arial", 10f, FontStyle.Bold);
				}
				dgTerminais.Rows.Add(array[l].sNome, array[l].sEfc, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, array[l].sHandle);
				dgTerminais.Rows[dgTerminais.RowCount - 1].Cells[2].Style = mT43v7CK32;
			}
			if (dgTerminais.Rows.Count > 0)
			{
				dgTerminais.Rows.Add("", "", "", "");
			}
			int num8 = Information.UBound(array);
			for (int m = 1; m <= num8; m++)
			{
				if (Operators.CompareString(array[m].sDuplicado, "", TextCompare: true) == 0)
				{
					continue;
				}
				if (Operators.CompareString(left2, "", TextCompare: true) == 0)
				{
					dgTerminais.Rows.Add(DeclaracoesGeral.mMensagem[1, 1567].ToString().ToUpper(), "", "", "");
					left2 = DeclaracoesGeral.mMensagem[1, 1567].ToString().ToUpper();
					int num9 = 0;
					do
					{
						dgTerminais.Rows[dgTerminais.RowCount - 1].Cells[num9].Style = XSR36apgl1;
						num9++;
					}
					while (num9 <= 3);
					dgTerminais.Rows[dgTerminais.Rows.Count - 1].Cells[0].Style.Font = new Font("Arial", 10f, FontStyle.Bold);
				}
				dgTerminais.Rows.Add(array[m].sNome, array[m].sEfc, array[m].sDuplicado, array[m].sHandle);
			}
			formatadgBornes();
			string left4 = "";
			string left5 = "";
			int num10 = Information.UBound(array2);
			for (int n = 1; n <= num10; n++)
			{
				string left6 = clsTextos.TiraNothing(array2[n].sIndefinido);
				if (Operators.CompareString(left6, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, TextCompare: true) != 0)
				{
					continue;
				}
				if (Operators.CompareString(left4, "", TextCompare: true) == 0)
				{
					dgBornes.Rows.Add(DeclaracoesGeral.mMensagem[1, 1492].ToString().ToUpper(), "", "", "");
					left4 = DeclaracoesGeral.mMensagem[1, 1492].ToString().ToUpper();
					int num11 = 0;
					do
					{
						dgBornes.Rows[dgBornes.RowCount - 1].Cells[num11].Style = XSR36apgl1;
						num11++;
					}
					while (num11 <= 3);
					dgBornes.Rows[dgBornes.Rows.Count - 1].Cells[0].Style.Font = new Font("Arial", 10f, FontStyle.Bold);
				}
				dgBornes.Rows.Add(array2[n].sNome, array2[n].sEfc, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, array2[n].sHandle);
				dgBornes.Rows[dgBornes.RowCount - 1].Cells[2].Style = mT43v7CK32;
			}
			if (dgBornes.Rows.Count > 0)
			{
				dgBornes.Rows.Add("", "", "", "");
			}
			int num12 = Information.UBound(array2);
			for (int num13 = 1; num13 <= num12; num13++)
			{
				if (Operators.CompareString(array2[num13].sDuplicado, "", TextCompare: true) == 0)
				{
					continue;
				}
				if (Operators.CompareString(left5, "", TextCompare: true) == 0)
				{
					dgBornes.Rows.Add(DeclaracoesGeral.mMensagem[1, 1567].ToString().ToUpper(), "", "", "");
					left5 = DeclaracoesGeral.mMensagem[1, 1567].ToString().ToUpper() + "\r\n";
					int num14 = 0;
					do
					{
						dgBornes.Rows[dgBornes.RowCount - 1].Cells[num14].Style = XSR36apgl1;
						num14++;
					}
					while (num14 <= 3);
					dgBornes.Rows[dgBornes.Rows.Count - 1].Cells[0].Style.Font = new Font("Arial", 10f, FontStyle.Bold);
				}
				dgBornes.Rows.Add(array2[num13].sNome, array2[num13].sEfc, array2[num13].sDuplicado, array2[num13].sHandle);
			}
			AtualizaTerminais();
			AtualizaBornes();
			if (dgTerminais.RowCount == 0)
			{
				dgTerminais.Rows.Clear();
				dgTerminais.Columns.Clear();
			}
			if (dgBornes.RowCount == 0)
			{
				dgBornes.Rows.Clear();
				dgBornes.Columns.Clear();
			}
		}
	}

	private void unLe0hdK5b()
	{
		Declaracoes2.StructureModeloDeReguas[] mModelo = new Declaracoes2.StructureModeloDeReguas[1];
		DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
		int num = 0;
		string text = "???";
		string text2 = "";
		DeclaracoesEntidades.StructureBorne[] array = null;
		array = new DeclaracoesEntidades.StructureBorne[1];
		int num2 = Information.UBound(mModelo);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				num = mModelo[i].indexPainel;
				text2 = mModelo[i].nomeRegua;
				text = Dicionario.BuscaNomeDoPainel(mModelo[i].indexPainel);
				if (!Ntj3HDmrBL.Contains(Conversions.ToString(num)))
				{
					continue;
				}
				array = new DeclaracoesEntidades.StructureBorne[1];
				int num3 = Information.UBound(NMc3JFnBaS);
				for (int j = 0; j <= num3; j++)
				{
					if (NMc3JFnBaS[j].IndiceRegua == mModelo[i].indexRegua)
					{
						int num4 = Information.UBound(array) + 1;
						array = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(array, new DeclaracoesEntidades.StructureBorne[num4 + 1]);
						array[num4] = NMc3JFnBaS[j];
						array[num4].NomePainel = text;
						array[num4].NomeRegua = text2;
					}
				}
				if (Information.UBound(array) == 0)
				{
					int indexRegua = mModelo[i].indexRegua;
					int qSimples = 0;
					int qDuplo = 0;
					DicionarioBorne.LeDicBornesReserva(indexRegua, ref array, ref qSimples, ref qDuplo);
				}
				if (Information.UBound(array) == 0)
				{
					dgReguasSemUso.Rows.Add(text, text2);
				}
			}
		}
	}

	private void bkueRiqG45()
	{
		Declaracoes2.StructureModeloDeReguas[] mModelo = new Declaracoes2.StructureModeloDeReguas[1];
		DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
		ClsVerificadorProjetoFiacao._StructurERROBorne[] array = new ClsVerificadorProjetoFiacao._StructurERROBorne[1];
		int num = 0;
		string text = "???";
		string text2 = "";
		DeclaracoesEntidades.StructureBorne[] array2 = null;
		array2 = new DeclaracoesEntidades.StructureBorne[1];
		int num2 = Information.UBound(mModelo);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				num = mModelo[i].indexPainel;
				text2 = mModelo[i].nomeRegua;
				text = Dicionario.BuscaNomeDoPainel(mModelo[i].indexPainel);
				if (!Ntj3HDmrBL.Contains(Conversions.ToString(num)))
				{
					continue;
				}
				array2 = new DeclaracoesEntidades.StructureBorne[1];
				int num3 = Information.UBound(NMc3JFnBaS);
				for (int j = 0; j <= num3; j++)
				{
					if (NMc3JFnBaS[j].IndiceRegua == mModelo[i].indexRegua)
					{
						int num4 = Information.UBound(array2) + 1;
						array2 = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(array2, new DeclaracoesEntidades.StructureBorne[num4 + 1]);
						array2[num4] = NMc3JFnBaS[j];
						array2[num4].NomePainel = text;
						array2[num4].NomeRegua = text2;
					}
				}
				int indexRegua = mModelo[i].indexRegua;
				int qSimples = 0;
				int qDuplo = 0;
				DicionarioBorne.LeDicBornesReserva(indexRegua, ref array2, ref qSimples, ref qDuplo);
				if (Information.UBound(array2) >= 2)
				{
					DeclaracoesEntidades.StructureBorne structureBorne = default;
					int num5 = Information.UBound(array2);
					for (int k = 1; k <= num5; k++)
					{
						int num6 = Information.UBound(array2) - 1;
						int num7 = k;
						for (int l = num6; l >= num7; l += -1)
						{
							if (array2[l].Ordem > array2[l + 1].Ordem)
							{
								structureBorne = array2[l + 1];
								array2[l + 1] = array2[l];
								array2[l] = structureBorne;
							}
						}
					}
				}
				int num8 = Information.UBound(array2);
				for (int m = 1; m <= num8; m++)
				{
					if (Operators.CompareString(array2[m].Numero, "?", TextCompare: true) == 0)
					{
						int num9 = Information.UBound(array) + 1;
						array = (ClsVerificadorProjetoFiacao._StructurERROBorne[])Utils.CopyArray(array, new ClsVerificadorProjetoFiacao._StructurERROBorne[num9 + 1]);
						array[num9].iPn = num;
						array[num9].sPn = text;
						array[num9].sRegua = text2;
						array[num9].sErro = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
					}
					if (m <= Information.UBound(array2) - 1 && (Versioned.IsNumeric(array2[m].Numero) & Versioned.IsNumeric(array2[m + 1].Numero)) && Conversions.ToDouble(array2[m].Numero) != Conversions.ToDouble(array2[m + 1].Numero) - 1.0)
					{
						int num10 = Information.UBound(array) + 1;
						array = (ClsVerificadorProjetoFiacao._StructurERROBorne[])Utils.CopyArray(array, new ClsVerificadorProjetoFiacao._StructurERROBorne[num10 + 1]);
						array[num10].iPn = num;
						array[num10].sPn = text;
						array[num10].sRegua = text2;
						array[num10].sErro = array2[m].Numero + " a " + array2[m + 1].Numero;
						if (Operators.CompareString(array2[m].Numero, array2[m + 1].Numero, TextCompare: true) != 0)
						{
							array[num10].sErro = array2[m].Numero + " a " + array2[m + 1].Numero;
						}
						else
						{
							array[num10].sErro = Conversions.ToString(Operators.ConcatenateObject(array2[m].Numero + " - ", DeclaracoesGeral.mMensagem[1, 1629]));
						}
					}
				}
			}
			num = -1;
			text2 = "";
			int num11 = -1;
			int num12 = -1;
			TreeViewBornes.Nodes.Clear();
			if (Information.UBound(array) <= 0)
			{
				return;
			}
			int num13 = Information.UBound(array);
			for (int n = 1; n <= num13; n++)
			{
				if (array[n].iPn == num)
				{
					if (Operators.CompareString(array[n].sRegua, text2, TextCompare: true) == 0)
					{
						TreeViewBornes.Nodes[num11].Nodes[num12].Nodes.Add(array[n].sErro);
						continue;
					}
					TreeViewBornes.Nodes[num11].Nodes.Add(array[n].sRegua);
					text2 = array[n].sRegua;
					num12++;
					TreeViewBornes.Nodes[num11].Nodes[num12].Nodes.Add(array[n].sErro);
				}
				else
				{
					num11++;
					num12 = 0;
					TreeViewBornes.Nodes.Add(array[n].sPn);
					TreeViewBornes.Nodes[num11].Nodes.Add(array[n].sRegua);
					num = array[n].iPn;
					text2 = array[n].sRegua;
					TreeViewBornes.Nodes[num11].Nodes[0].Nodes.Add(array[n].sErro);
				}
			}
		}
	}

	private void l6Cemb5IWZ()
	{
		formatadgBornesEditados();
		checked
		{
			if (Information.UBound(NMc3JFnBaS) >= 2)
			{
				int num = Information.UBound(NMc3JFnBaS);
				for (int i = 1; i <= num; i++)
				{
					int num2 = Information.UBound(NMc3JFnBaS) - 1;
					int num3 = i;
					for (int j = num2; j >= num3; j += -1)
					{
						if (NMc3JFnBaS[j].indexPainel > NMc3JFnBaS[j + 1].indexPainel)
						{
							DeclaracoesEntidades.StructureBorne structureBorne = NMc3JFnBaS[j + 1];
							NMc3JFnBaS[j + 1] = NMc3JFnBaS[j];
							NMc3JFnBaS[j] = structureBorne;
						}
						if (NMc3JFnBaS[j].indexPainel == NMc3JFnBaS[j + 1].indexPainel && NMc3JFnBaS[j].IndiceRegua > NMc3JFnBaS[j + 1].IndiceRegua)
						{
							DeclaracoesEntidades.StructureBorne structureBorne = NMc3JFnBaS[j + 1];
							NMc3JFnBaS[j + 1] = NMc3JFnBaS[j];
							NMc3JFnBaS[j] = structureBorne;
						}
						if (NMc3JFnBaS[j].indexPainel == NMc3JFnBaS[j + 1].indexPainel && NMc3JFnBaS[j].IndiceRegua == NMc3JFnBaS[j + 1].IndiceRegua && NMc3JFnBaS[j].Ordem > NMc3JFnBaS[j + 1].Ordem)
						{
							DeclaracoesEntidades.StructureBorne structureBorne = NMc3JFnBaS[j + 1];
							NMc3JFnBaS[j + 1] = NMc3JFnBaS[j];
							NMc3JFnBaS[j] = structureBorne;
						}
					}
				}
			}
			int num4 = Information.UBound(NMc3JFnBaS);
			for (int k = 0; k <= num4; k++)
			{
				if (Operators.CompareString(clsTextos.TiraNothing(NMc3JFnBaS[k].NumeroComplem), "", TextCompare: true) != 0)
				{
					dgBornesEditados.Rows.Add(NMc3JFnBaS[k].NomePainel, NMc3JFnBaS[k].NomeRegua, NMc3JFnBaS[k].Numero, NMc3JFnBaS[k].NumeroComplem, NMc3JFnBaS[k].Handle);
				}
			}
			AtualizaBornesErro();
		}
	}

	private void BC3eXFk6iP()
	{
		ClsVerificadorProjetoFiacao._StructurERROBorne[] array = new ClsVerificadorProjetoFiacao._StructurERROBorne[1];
		int num = Information.UBound(NMc3JFnBaS);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				if (NMc3JFnBaS[i].lm == 0)
				{
					int num2 = Information.UBound(array) + 1;
					array = (ClsVerificadorProjetoFiacao._StructurERROBorne[])Utils.CopyArray(array, new ClsVerificadorProjetoFiacao._StructurERROBorne[num2 + 1]);
					array[num2].iPn = NMc3JFnBaS[i].indexPainel;
					array[num2].sPn = NMc3JFnBaS[i].NomePainel;
					array[num2].sRegua = NMc3JFnBaS[i].NomeRegua;
					array[num2].sErro = NMc3JFnBaS[i].Numero;
				}
			}
			int num3 = -1;
			string text = "";
			int num4 = -1;
			int num5 = -1;
			TreeViewBornesLM.Nodes.Clear();
			if (Information.UBound(array) >= 2)
			{
				int num6 = Information.UBound(array);
				for (int j = 1; j <= num6; j++)
				{
					int num7 = Information.UBound(array) - 1;
					int num8 = j;
					for (int k = num7; k >= num8; k += -1)
					{
						if (Operators.CompareString(array[k].sPn, array[k + 1].sPn, TextCompare: true) > 0)
						{
							ClsVerificadorProjetoFiacao._StructurERROBorne structurERROBorne = array[k + 1];
							array[k + 1] = array[k];
							array[k] = structurERROBorne;
						}
						if (Operators.CompareString(array[k].sPn, array[k + 1].sPn, TextCompare: true) == 0 && Operators.CompareString(array[k].sRegua, array[k + 1].sRegua, TextCompare: true) > 0)
						{
							ClsVerificadorProjetoFiacao._StructurERROBorne structurERROBorne = array[k + 1];
							array[k + 1] = array[k];
							array[k] = structurERROBorne;
						}
					}
				}
			}
			if (Information.UBound(array) <= 1)
			{
				return;
			}
			List<string> list = new List<string>();
			list.Clear();
			int num9 = Information.UBound(array);
			for (int l = 1; l <= num9; l++)
			{
				if (array[l].iPn == num3)
				{
					if (Operators.CompareString(array[l].sRegua, text, TextCompare: true) == 0)
					{
						if (!list.Contains(array[l].sErro))
						{
							list.Add(array[l].sErro);
						}
						continue;
					}
					if (Operators.CompareString(array[l].sRegua, text, TextCompare: true) != 0 && Operators.CompareString(text, "", TextCompare: true) != 0 && list.Count > 0)
					{
						string text2 = montaBornesIndefinidos(list);
						TreeViewBornesLM.Nodes[num4].Nodes[num5].Nodes.Add(text2);
						list.Clear();
						num5++;
					}
					TreeViewBornesLM.Nodes[num4].Nodes.Add(array[l].sRegua);
					text = array[l].sRegua;
					if (!list.Contains(array[l].sErro))
					{
						list.Add(array[l].sErro);
					}
				}
				else
				{
					if (list.Count > 0)
					{
						string text3 = montaBornesIndefinidos(list);
						TreeViewBornesLM.Nodes[num4].Nodes[num5].Nodes.Add(text3);
						list.Clear();
						num5++;
					}
					num4++;
					num5 = 0;
					TreeViewBornesLM.Nodes.Add(array[l].sPn);
					TreeViewBornesLM.Nodes[num4].Nodes.Add(array[l].sRegua);
					num3 = array[l].iPn;
					text = array[l].sRegua;
					if (!list.Contains(array[l].sErro))
					{
						list.Add(array[l].sErro);
					}
				}
			}
		}
	}

	private void HLteUkrJM0()
	{
		formatadgPaineisApagados();
		int num = Information.UBound(NMc3JFnBaS);
		checked
		{
			for (int i = 0; i <= num; i++)
			{
				if (NMc3JFnBaS[i].bPnApagado)
				{
					dgPainelApagado.Rows.Add(Operators.ConcatenateObject(Conversions.ToString(NMc3JFnBaS[i].indexPainel) + " - ", DeclaracoesGeral.mMensagem[1, 1170]), NMc3JFnBaS[i].NomeRegua + NMc3JFnBaS[i].Numero, "Bornes", NMc3JFnBaS[i].Handle);
				}
			}
			int num2 = Information.UBound(vTJ3hn9llT);
			for (int j = 0; j <= num2; j++)
			{
				if (vTJ3hn9llT[j].bPnApagados)
				{
					string sNomeMascara = vTJ3hn9llT[j].sNomeMascara;
					sNomeMascara = sNomeMascara.Replace("???" + DeclaracoesGeral.Conf.SeparadorCruzamento, "");
					dgPainelApagado.Rows.Add(Operators.ConcatenateObject(Conversions.ToString(vTJ3hn9llT[j].iPn) + " - ", DeclaracoesGeral.mMensagem[1, 1170]), sNomeMascara, "Portas", vTJ3hn9llT[j].sHandle);
				}
			}
			int num3 = Information.UBound(DuZ3okk8Hh);
			for (int k = 0; k <= num3; k++)
			{
				if (DuZ3okk8Hh[k].bPnApagados)
				{
					dgPainelApagado.Rows.Add(Operators.ConcatenateObject(Conversions.ToString(DuZ3okk8Hh[k].iPn) + " - ", DeclaracoesGeral.mMensagem[1, 1170]), DuZ3okk8Hh[k].Nome1, "Disporitivos", DuZ3okk8Hh[k].Handle);
				}
			}
			int num4 = Information.UBound(mjD3GIk5FY);
			for (int l = 0; l <= num4; l++)
			{
				if (mjD3GIk5FY[l].bPnApagados)
				{
					dgPainelApagado.Rows.Add(Operators.ConcatenateObject(Conversions.ToString(mjD3GIk5FY[l].iPn) + " - ", DeclaracoesGeral.mMensagem[1, 1170]), mjD3GIk5FY[l].Nome1, "Auxiliares", mjD3GIk5FY[l].Handle);
				}
			}
			AtualizaPaineisApagados();
		}
	}

	private void OdFey77530()
	{
		dgAMao.Rows.Clear();
		dgAMao.Columns.Clear();
		dgAMao.Columns.Add("ERRO", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1111]));
		dgAMao.Columns.Add("Página", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 9]));
		dgAMao.Columns.Add("Handle", "Handle");
		clsBlocos.StructureErros[] array = b8E3LytR55;
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			clsBlocos.StructureErros structureErros = array[i];
			if (Operators.CompareString(clsTextos.TiraNothing(structureErros.sTipo), "", TextCompare: true) != 0)
			{
				dgAMao.Rows.Add(structureErros.sTipo, structureErros.sPagina, structureErros.sHandle);
			}
		}
		AtualizaFeitoAMao();
		eJK3tCnFyq = true;
	}

	private void TU9egJVMTL()
	{
		dgReguaMascara.Rows.Clear();
		dgReguaMascara.Columns.Clear();
		dgReguaMascara.Columns.Add("Indice", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 915]));
		dgReguaMascara.Columns.Add("Modelo", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 654]));
		dgReguaMascara.Columns.Add("Régua", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 984]));
		Declaracoes2.MModeloDeMascara[] mModelo = new Declaracoes2.MModeloDeMascara[1];
		DicionarioMascaras.LeOsModelosDeMascaras(ref mModelo, bComplementarModelo: true);
		int num = Information.UBound(mModelo);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				List<string> list = new List<string>();
				Declaracoes2.MModeloDePortas[] mPortas = new Declaracoes2.MModeloDePortas[1];
				DicionarioMascaras.LeAsPortasDoModeloDoDicionario(ref mModelo[i].iIndiceModelo, mModelo[i].sNomeModelo, ref mPortas);
				int num2 = Information.UBound(mPortas);
				for (int j = 1; j <= num2; j++)
				{
					string right = mPortas[j].sRegua.Replace(";", "");
					List<string> lTerminais = new List<string>();
					Geral.DivideTerminais(ref lTerminais, mPortas[j].sBornes, bRepete: true);
					List<string> lTerminais2 = new List<string>();
					Geral.DivideTerminais(ref lTerminais2, mPortas[j].sRegua, bRepete: true);
					bool flag = false;
					if (lTerminais2.Count > 0)
					{
						if (lTerminais2.Count != lTerminais.Count)
						{
							if ((lTerminais2.Count == 1) & (lTerminais.Count > 1))
							{
								flag = true;
							}
						}
						else
						{
							flag = true;
						}
					}
					if (!flag && Operators.CompareString(mPortas[j].sRegua, right, TextCompare: true) != 0 && !list.Contains(mPortas[j].sRegua))
					{
						list.Add(mPortas[j].sRegua);
					}
				}
				foreach (string item in list)
				{
					dgReguaMascara.Rows.Add(mModelo[i].iIndiceModelo, mModelo[i].sNomeModelo, item);
				}
			}
			AtualizadgReguaMascara();
		}
	}

	private void HifeAOwtAh()
	{
		DGDiscrepantes.Rows.Clear();
		DGDiscrepantes.Columns.Clear();
		DGDiscrepantes.Columns.Add("Tag", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 514]));
		DGDiscrepantes.Columns.Add("PN1 VEIA", "PN1 VEIA");
		DGDiscrepantes.Columns.Add("PN2 VEIA", "PN2 VEIA");
		DGDiscrepantes.Columns.Add("PN1 CABO", "PN1 CABO");
		DGDiscrepantes.Columns.Add("PN2 CABO", "PN2 CABO");
		DGDiscrepantes.Columns.Add("Handle", "Handle");
		int num = 0;
		structureNomeVeiasErradas[] array = w9l3w2QBKA;
		checked
		{
			for (int i = 0; i < array.Length; i++)
			{
				structureNomeVeiasErradas structureNomeVeiasErradas2 = array[i];
				if (Operators.CompareString(clsTextos.TiraNothing(structureNomeVeiasErradas2.sTag), "", TextCompare: true) != 0)
				{
					DGDiscrepantes.Rows.Add(structureNomeVeiasErradas2.sTag, Dicionario.BuscaNomeDoPainel(structureNomeVeiasErradas2.ipn1V), Dicionario.BuscaNomeDoPainel(structureNomeVeiasErradas2.ipn2V), Dicionario.BuscaNomeDoPainel(structureNomeVeiasErradas2.ipn1B), Dicionario.BuscaNomeDoPainel(structureNomeVeiasErradas2.ipn2B), structureNomeVeiasErradas2.sHandle);
					if (structureNomeVeiasErradas2.ipn1V != structureNomeVeiasErradas2.ipn1B)
					{
						DGDiscrepantes.Rows[num].Cells[1].Style.BackColor = Color.LightCoral;
						DGDiscrepantes.Rows[num].Cells[3].Style.BackColor = Color.LightCoral;
					}
					if (structureNomeVeiasErradas2.ipn2V != structureNomeVeiasErradas2.ipn2B)
					{
						DGDiscrepantes.Rows[num].Cells[2].Style.BackColor = Color.LightCoral;
						DGDiscrepantes.Rows[num].Cells[4].Style.BackColor = Color.LightCoral;
					}
					num++;
				}
			}
			AtualizaDiscrepantes();
			eJK3tCnFyq = true;
		}
	}

	public void CarregaCabosDoBanco(structureNomeVeiasEditadar[] mNomesVeias)
	{
		DGCabosDoBanco.Rows.Clear();
		DGCabosDoBanco.Columns.Clear();
		DGCabosDoBanco.Columns.Add("CABO", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 514]));
		DGCabosDoBanco.Columns.Add("VEIA", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1239]));
		DGCabosDoBanco.Columns.Add("Handle", "Handle");
		int num = Information.UBound(mNomesVeias);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (!yx83xxOcMO.Contains(mNomesVeias[i].sTag))
			{
				DGCabosDoBanco.Rows.Add(mNomesVeias[i].sTag, mNomesVeias[i].iIndice, mNomesVeias[i].sFuncaoVeias);
			}
		}
		AtualizaDGCabosDoBanco();
	}

	public void AtualizaDGCabosDoBanco()
	{
		if (DGCabosDoBanco.RowCount <= 0)
		{
			DGCabosDoBanco.Rows.Clear();
			DGCabosDoBanco.Columns.Clear();
			return;
		}
		checked
		{
			double num = DGCabosDoBanco.Width - 4;
			if (haG8HN1M755FJ2bc2NW.ARP1IVj2So(DGCabosDoBanco))
			{
				num = DGCabosDoBanco.Width - 21;
			}
			DGCabosDoBanco.Columns[0].Width = (int)Math.Round(num * 0.8);
			DGCabosDoBanco.Columns[0].Visible = true;
			DGCabosDoBanco.Columns[1].Width = (int)Math.Round(num * 0.2);
			DGCabosDoBanco.Columns[1].Visible = true;
			DGCabosDoBanco.Columns[2].Width = 0;
			DGCabosDoBanco.Columns[2].Visible = false;
			DGCabosDoBanco.MultiSelect = false;
		}
	}

	private void uVIesDeeDf(object P_0, DataGridViewCellEventArgs P_1)
	{
		clsBlocos.Unhighlight();
		string sHandle = clsTextos.TiraNothing(Conversions.ToString(DGCabosDoBanco.SelectedRows[0].Cells[2].Value)).ToString();
		clsBlocos.MostraBloco(sHandle);
	}

	public string montaBornesIndefinidos(List<string> lista)
	{
		string text = "";
		checked
		{
			if (lista.Count != 0)
			{
				bool flag = true;
				bool flag2 = true;
				int num = 0;
				if (lista.Count > 2)
				{
					foreach (string listum in lista)
					{
						if (Versioned.IsNumeric(listum))
						{
							if (!flag2)
							{
								int num2 = Conversions.ToInteger(listum);
								num++;
								if (num2 != num)
								{
									flag = false;
									break;
								}
							}
							else
							{
								flag2 = false;
								num = Conversions.ToInteger(listum);
							}
							continue;
						}
						flag = false;
						break;
					}
				}
				else
				{
					flag = false;
				}
				if (flag)
				{
					return Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject(lista[0] + " ", DeclaracoesGeral.mMensagem[1, 1446]), " "), lista[lista.Count - 1]));
				}
				foreach (string listum2 in lista)
				{
					text = text + listum2 + ", ";
				}
				return text.Substring(0, text.Length - 2);
			}
			return "-";
		}
	}

	private void BsQeBMN6iG(object P_0, DataGridViewCellEventArgs P_1)
	{
		string sHandle = clsTextos.TiraNothing(Conversions.ToString(dgBornesEditados.SelectedRows[0].Cells[4].Value)).ToString();
		clsBlocos.MostraBloco(sHandle);
	}

	private void kQXeVACKlh(object P_0, DataGridViewCellEventArgs P_1)
	{
		clsBlocos.Unhighlight();
		if (dgTerminais.Rows.Count > 0)
		{
			string sHandle = dgTerminais.SelectedRows[0].Cells[3].Value.ToString();
			clsBlocos.MostraBloco(sHandle);
		}
	}

	private void FfneuMwUIq(object P_0, DataGridViewCellEventArgs P_1)
	{
		clsBlocos.Unhighlight();
		if (dgBornes.Rows.Count > 0)
		{
			string sHandle = dgBornes.SelectedRows[0].Cells[3].Value.ToString();
			clsBlocos.MostraBloco(sHandle);
		}
	}

	private void YcPeEAbXdf(object P_0, DataGridViewCellEventArgs P_1)
	{
		clsBlocos.Unhighlight();
		string sHandle = clsTextos.TiraNothing(Conversions.ToString(dgPainelApagado.SelectedRows[0].Cells[3].Value)).ToString();
		clsBlocos.MostraBloco(sHandle);
	}

	private void w66eZJtgLc(object P_0, DataGridViewCellEventArgs P_1)
	{
		clsBlocos.Unhighlight();
		string sHandle = clsTextos.TiraNothing(Conversions.ToString(dgAMao.SelectedRows[0].Cells[2].Value)).ToString();
		clsBlocos.MostraBloco(sHandle);
		AtualizaFeitoAMao();
	}

	public void formatadgBornes()
	{
		dgBornes.Rows.Clear();
		dgBornes.Columns.Clear();
		dgBornes.Columns.Add("Nome", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 987]));
		dgBornes.Columns.Add("EFC", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 264]));
		dgBornes.Columns.Add("Bornes", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 540]));
		dgBornes.Columns.Add("Handle", "Handle");
	}

	public void AtualizaBornes()
	{
		checked
		{
			if (dgBornes.RowCount <= 0)
			{
				dgBornes.Rows.Clear();
				dgBornes.Columns.Clear();
			}
			else
			{
				double num = dgBornes.Width - 4;
				if (haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgBornes))
				{
					num = dgBornes.Width - 21;
				}
				dgBornes.Columns[0].Width = (int)Math.Round(num * 0.4);
				dgBornes.Columns[0].Visible = true;
				dgBornes.Columns[1].Width = (int)Math.Round(num * 0.3);
				dgBornes.Columns[1].Visible = true;
				dgBornes.Columns[2].Width = (int)Math.Round(num * 0.3);
				dgBornes.Columns[2].Visible = true;
				dgBornes.Columns[3].Width = 0;
				dgBornes.Columns[3].Visible = false;
			}
			dgBornes.MultiSelect = false;
		}
	}

	public void formatadgReguasSemUso()
	{
		dgReguasSemUso.Rows.Clear();
		dgReguasSemUso.Columns.Clear();
		dgReguasSemUso.Columns.Add("Painel", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1081]));
		dgReguasSemUso.Columns.Add("Régua", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1425]));
	}

	public void AtualizaReguasSemUso()
	{
		if (dgReguasSemUso.RowCount <= 0)
		{
			dgReguasSemUso.Rows.Clear();
			dgReguasSemUso.Columns.Clear();
			return;
		}
		checked
		{
			double num = dgReguasSemUso.Width - 4;
			if (haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgReguasSemUso))
			{
				num = dgReguasSemUso.Width - 21;
			}
			dgReguasSemUso.Columns[0].Width = (int)Math.Round(num * 0.7);
			dgReguasSemUso.Columns[0].Visible = true;
			dgReguasSemUso.Columns[1].Width = (int)Math.Round(num * 0.3);
			dgReguasSemUso.Columns[1].Visible = true;
			dgReguasSemUso.MultiSelect = false;
		}
	}

	public void formatadgTerminais()
	{
		dgTerminais.Rows.Clear();
		dgTerminais.Columns.Clear();
		dgTerminais.Columns.Add("NOME", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 987]));
		dgTerminais.Columns.Add("EFC", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 264]));
		dgTerminais.Columns.Add("Terminais", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 631]));
		dgTerminais.Columns.Add("Handle", "Handle");
	}

	public void AtualizaTerminais()
	{
		checked
		{
			if (dgTerminais.RowCount <= 0)
			{
				dgTerminais.Rows.Clear();
				dgTerminais.Columns.Clear();
			}
			else
			{
				double num = dgTerminais.Width - 4;
				if (haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgTerminais))
				{
					num = dgTerminais.Width - 21;
				}
				dgTerminais.Columns[0].Width = (int)Math.Round(num * 0.4);
				dgTerminais.Columns[0].Visible = true;
				dgTerminais.Columns[1].Width = (int)Math.Round(num * 0.3);
				dgTerminais.Columns[1].Visible = true;
				dgTerminais.Columns[2].Width = (int)Math.Round(num * 0.3);
				dgTerminais.Columns[2].Visible = true;
				dgTerminais.Columns[3].Width = 0;
				dgTerminais.Columns[3].Visible = false;
				dgTerminais.MultiSelect = false;
			}
			dgBornes.MultiSelect = false;
		}
	}

	public void formatadgBornesEditados()
	{
		dgBornesEditados.Rows.Clear();
		dgBornesEditados.Columns.Clear();
		dgBornesEditados.Columns.Add("Painel", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1081]));
		dgBornesEditados.Columns.Add("Régua", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1425]));
		dgBornesEditados.Columns.Add("Régua", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1429]));
		dgBornesEditados.Columns.Add("Régua", "Errado");
		dgBornesEditados.Columns.Add("Handle", "Handle");
	}

	public void AtualizaBornesErro()
	{
		if (dgBornesEditados.RowCount <= 0)
		{
			dgBornesEditados.Rows.Clear();
			dgBornesEditados.Columns.Clear();
			return;
		}
		checked
		{
			double num = dgBornesEditados.Width - 4;
			if (haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgBornesEditados))
			{
				num = dgBornesEditados.Width - 21;
			}
			dgBornesEditados.Columns[0].Width = (int)Math.Round(num * 0.4);
			dgBornesEditados.Columns[0].Visible = true;
			dgBornesEditados.Columns[1].Width = (int)Math.Round(num * 0.2);
			dgBornesEditados.Columns[1].Visible = true;
			dgBornesEditados.Columns[2].Width = (int)Math.Round(num * 0.2);
			dgBornesEditados.Columns[2].Visible = true;
			dgBornesEditados.Columns[3].Width = (int)Math.Round(num * 0.2);
			dgBornesEditados.Columns[3].Visible = true;
			dgBornesEditados.Columns[4].Width = 0;
			dgBornesEditados.Columns[4].Visible = false;
			dgBornesEditados.MultiSelect = false;
		}
	}

	public void formatadgPaineisApagados()
	{
		dgPainelApagado.Rows.Clear();
		dgPainelApagado.Columns.Clear();
		dgPainelApagado.Columns.Add("Painel", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1005]));
		dgPainelApagado.Columns.Add("Nome", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 987]));
		dgPainelApagado.Columns.Add("Tipo", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 271]));
		dgPainelApagado.Columns.Add("Handle", "Handle");
	}

	public void AtualizaPaineisApagados()
	{
		checked
		{
			if (dgPainelApagado.RowCount <= 0)
			{
				dgPainelApagado.Rows.Clear();
				dgPainelApagado.Columns.Clear();
			}
			else
			{
				double num = dgPainelApagado.Width - 4;
				if (haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgPainelApagado))
				{
					num = dgPainelApagado.Width - 21;
				}
				dgPainelApagado.Columns[0].Width = (int)Math.Round(num * 0.4);
				dgPainelApagado.Columns[0].Visible = true;
				dgPainelApagado.Columns[1].Width = (int)Math.Round(num * 0.3);
				dgPainelApagado.Columns[1].Visible = true;
				dgPainelApagado.Columns[2].Width = (int)Math.Round(num * 0.3);
				dgPainelApagado.Columns[2].Visible = true;
				dgPainelApagado.Columns[3].Width = 0;
				dgPainelApagado.Columns[3].Visible = false;
			}
			dgPainelApagado.MultiSelect = false;
		}
	}

	public void AtualizaFeitoAMao()
	{
		if (dgAMao.RowCount <= 0)
		{
			dgAMao.Rows.Clear();
			dgAMao.Columns.Clear();
			return;
		}
		checked
		{
			double num = dgAMao.Width - 4;
			if (haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgAMao))
			{
				num = dgAMao.Width - 21;
			}
			dgAMao.Columns[0].Width = (int)Math.Round(num * 0.8);
			dgAMao.Columns[0].Visible = true;
			dgAMao.Columns[1].Width = (int)Math.Round(num * 0.2);
			dgAMao.Columns[1].Visible = true;
			dgAMao.Columns[2].Width = 0;
			dgAMao.Columns[2].Visible = false;
			dgAMao.MultiSelect = false;
		}
	}

	public void AtualizaDiscrepantes()
	{
		DGDiscrepantes.ColumnHeadersVisible = false;
		if (DGDiscrepantes.RowCount <= 0)
		{
			DGDiscrepantes.Rows.Clear();
			DGDiscrepantes.Columns.Clear();
			return;
		}
		checked
		{
			double num = DGDiscrepantes.Width - 4;
			if (haG8HN1M755FJ2bc2NW.ARP1IVj2So(DGDiscrepantes))
			{
				num = DGDiscrepantes.Width - 21;
			}
			DGDiscrepantes.Columns[0].Width = (int)Math.Round(num * 0.2);
			DGDiscrepantes.Columns[0].Visible = true;
			DGDiscrepantes.Columns[1].Width = (int)Math.Round(num * 0.2);
			DGDiscrepantes.Columns[1].Visible = true;
			DGDiscrepantes.Columns[2].Width = (int)Math.Round(num * 0.2);
			DGDiscrepantes.Columns[2].Visible = true;
			DGDiscrepantes.Columns[3].Width = (int)Math.Round(num * 0.2);
			DGDiscrepantes.Columns[3].Visible = true;
			DGDiscrepantes.Columns[4].Width = (int)Math.Round(num * 0.2);
			DGDiscrepantes.Columns[4].Visible = true;
			DGDiscrepantes.Columns[5].Width = 0;
			DGDiscrepantes.Columns[5].Visible = false;
			DGDiscrepantes.MultiSelect = false;
		}
	}

	public void AtualizadgReguaMascara()
	{
		if (dgReguaMascara.RowCount <= 0)
		{
			dgReguaMascara.Rows.Clear();
			dgReguaMascara.Columns.Clear();
			return;
		}
		checked
		{
			double num = dgReguaMascara.Width - 4;
			if (haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgReguaMascara))
			{
				num = dgReguaMascara.Width - 21;
			}
			dgReguaMascara.Columns[0].Width = (int)Math.Round(num * 0.2);
			dgReguaMascara.Columns[0].Visible = true;
			dgReguaMascara.Columns[1].Width = (int)Math.Round(num * 0.4);
			dgReguaMascara.Columns[1].Visible = true;
			dgReguaMascara.Columns[2].Width = (int)Math.Round(num * 0.4);
			dgReguaMascara.Columns[2].Visible = true;
			dgReguaMascara.MultiSelect = false;
		}
	}

	private void SRKeiGKfFT(object P_0, EventArgs P_1)
	{
		tqmeSw9lT9();
	}

	private void tqmeSw9lT9()
	{
		if (sJM3j8kR2H)
		{
			AtualizaReguasSemUso();
			AtualizaTerminais();
			AtualizaBornes();
			AtualizaBornesErro();
			AtualizaPaineisApagados();
		}
	}

	public void mostraBT(int iNum)
	{
		GB1Interligacao.Visible = false;
		GB1Interligacao.Visible = false;
		GroupBox5.Visible = false;
		GroupBox8.Visible = false;
		GroupBox7.Visible = false;
		GroupBox6.Visible = false;
		GroupBox9.Visible = false;
		GroupBox10.Visible = false;
		GroupBox11.Visible = false;
		GroupBox12.Visible = false;
		GroupBox13.Visible = false;
		GroupBox14.Visible = false;
		GroupBox15.Visible = false;
		Color backColor = btCarrega.BackColor;
		bt1Interligacao.BackColor = backColor;
		bt5Terminais.BackColor = backColor;
		bt7Reguas.BackColor = backColor;
		bt8intervalos.BackColor = backColor;
		bt6Portas.BackColor = backColor;
		bt9Discrepantes.BackColor = backColor;
		bt10BornesLM.BackColor = backColor;
		bt11Paineis.BackColor = backColor;
		bt12AMao.BackColor = backColor;
		BT13Discrepantes.BackColor = backColor;
		BT14CabosFaltantes.BackColor = backColor;
		bt15ReguaMascara.BackColor = backColor;
		BTCorrigirDiscrepante.Visible = false;
		switch (iNum)
		{
		case 15:
			GroupBox15.Visible = true;
			bt15ReguaMascara.BackColor = Color.LightSlateGray;
			break;
		case 1:
			GB1Interligacao.Visible = true;
			bt1Interligacao.BackColor = Color.LightSlateGray;
			break;
		case 5:
			GroupBox5.Visible = true;
			bt5Terminais.BackColor = Color.LightSlateGray;
			break;
		case 6:
			GroupBox6.Visible = true;
			bt7Reguas.BackColor = Color.LightSlateGray;
			break;
		case 7:
			GroupBox7.Visible = true;
			bt8intervalos.BackColor = Color.LightSlateGray;
			break;
		case 8:
			GroupBox8.Visible = true;
			bt6Portas.BackColor = Color.LightSlateGray;
			break;
		case 9:
			GroupBox9.Visible = true;
			bt9Discrepantes.BackColor = Color.LightSlateGray;
			break;
		case 10:
			GroupBox10.Visible = true;
			bt10BornesLM.BackColor = Color.LightSlateGray;
			break;
		case 11:
			GroupBox11.Visible = true;
			bt11Paineis.BackColor = Color.LightSlateGray;
			break;
		case 12:
			GroupBox12.Visible = true;
			bt12AMao.BackColor = Color.LightSlateGray;
			break;
		case 13:
			GroupBox13.Visible = true;
			BT13Discrepantes.BackColor = Color.LightSlateGray;
			BTCorrigirDiscrepante.Visible = true;
			break;
		case 14:
			GroupBox14.Visible = true;
			BT14CabosFaltantes.BackColor = Color.LightSlateGray;
			break;
		}
		tqmeSw9lT9();
	}

	private void aXRe4Yj4WV(object P_0, EventArgs P_1)
	{
		mostraBT(1);
	}

	private void AfQeCJL8EJ(object P_0, EventArgs P_1)
	{
		mostraBT(5);
	}

	private void iiteY7CNZT(object P_0, EventArgs P_1)
	{
		mostraBT(6);
	}

	private void RdCerVHlF9(object P_0, EventArgs P_1)
	{
		mostraBT(7);
	}

	private void RIJe9sYENY(object P_0, EventArgs P_1)
	{
		mostraBT(8);
	}

	private void MSUezXwYHq(object P_0, EventArgs P_1)
	{
		mostraBT(9);
	}

	private void ubM2WxaW09(object P_0, EventArgs P_1)
	{
		mostraBT(10);
	}

	private void MOC2pvn45n(object P_0, EventArgs P_1)
	{
		mostraBT(11);
	}

	private void Nyj2TQJP79(object P_0, EventArgs P_1)
	{
		mostraBT(12);
		AtualizaFeitoAMao();
	}

	private void MW32JyOI41(object P_0, EventArgs P_1)
	{
		mostraBT(13);
		AtualizaDiscrepantes();
	}

	private void UtH2hGosb0(object P_0, EventArgs P_1)
	{
		mostraBT(14);
		AtualizaDGCabosDoBanco();
	}

	private void bc42opiHqN(object P_0, EventArgs P_1)
	{
		mostraBT(15);
		AtualizadgReguaMascara();
	}

	private void Kgu2GRvwuD(object P_0, EventArgs P_1)
	{
		structureNomeVeiasErradas[] MVeiasErradas = null;
		clsEditarInterligacao.CaboseVeiasDoCadernoDiscrepantes(bPesquisa: false, ref MVeiasErradas);
		w9l3w2QBKA = new structureNomeVeiasErradas[1];
		CarregaInterligacao();
	}

	private void nK22HNkZuR(object P_0, EventArgs P_1)
	{
		clsVerificadorProjetoInterligacao.IndefineCabosNaoExistentes(yx83xxOcMO);
		yx83xxOcMO.Clear();
		sju3bdCB5q = new structureNomeVeiasEditadar[1];
		DGCabosDoBanco.Rows.Clear();
		DGCabosDoBanco.Columns.Clear();
		CarregaInterligacao();
	}
}
