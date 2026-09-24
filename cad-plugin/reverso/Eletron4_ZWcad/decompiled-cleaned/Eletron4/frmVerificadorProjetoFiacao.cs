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
public class frmVerificadorProjetoFiacao : Form
{
	private IContainer T8iKbhRubd;

	[AccessedThroughProperty("ToolTip1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolTip CNLKMunBec;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btCorDoErroF")]
	private Button BP9KOfK5LV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBoxFiacao")]
	private GroupBox TGcKI1Kj4r;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btMostraErroFiação")]
	[CompilerGenerated]
	private Button bIIK7OcM6a;

	[AccessedThroughProperty("btOcultaErroFiação")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button LceKqj4PtS;

	[AccessedThroughProperty("TreeView1")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TreeView F1EKaUiSnF;

	[AccessedThroughProperty("TreeViewBornes")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TreeView HXWK8A2OLp;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgBornes")]
	[CompilerGenerated]
	private DataGridView jPcKNsGA4H;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgTerminais")]
	private DataGridView mEVKF4LCuY;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgAuxiliar")]
	private DataGridView JbhKQE7jD0;

	[AccessedThroughProperty("dgPrincipal")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView aplKP0T9Sa;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("btAtualizar")]
	private Button rrCKcT6Mx0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("dgEquip")]
	private DataGridView kuyKKEgaDc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgBornesEditados")]
	private DataGridView mOGKeoy7KL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgReguasSemUso")]
	private DataGridView lcfK2f3K2x;

	[AccessedThroughProperty("dgFiacaoOrfao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView eI0K3PwqLg;

	[AccessedThroughProperty("bt2Orfao")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button FFqKnsXgcp;

	[AccessedThroughProperty("bt5Terminais")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button gNMK1UJWDc;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("bt6Portas")]
	private Button JwxKlfLWBd;

	[CompilerGenerated]
	[AccessedThroughProperty("bt4Auxiliar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button PtaK57spHV;

	[AccessedThroughProperty("bt3Principal")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button aKGK01ev8i;

	[AccessedThroughProperty("bt1Fiacao")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button nJ7KRB00wO;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox1")]
	[CompilerGenerated]
	private GroupBox DeHKmH9IsR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox2")]
	private GroupBox jHnKXQViB6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox3")]
	private GroupBox NcTKUGIGIh;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox5")]
	private GroupBox m5yKyLK1v4;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox4")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox FIbKgdHEHm;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox8")]
	private GroupBox AjPKAkJsDO;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox7")]
	private GroupBox AZPKs44Gi4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox6")]
	private GroupBox vq5KBYk8kE;

	[AccessedThroughProperty("GroupBox9")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox opgKVZdOHO;

	[AccessedThroughProperty("bt9Discrepantes")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button D1LKuQOKf3;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("bt7Reguas")]
	private Button NmTKE5fMng;

	[AccessedThroughProperty("bt8intervalos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button utfKZNCKH9;

	[AccessedThroughProperty("GroupBox10")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox JFPKibKF79;

	[AccessedThroughProperty("TreeViewBornesLM")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TreeView kjPKSriMLl;

	[AccessedThroughProperty("bt10BornesLM")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button PaXK4yFxxD;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("GBEX")]
	private GroupBox Q8KKCxDeop;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GroupBox11")]
	private GroupBox KxmKYFl7VA;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt11Paineis")]
	private Button oOnKrrx68b;

	[AccessedThroughProperty("dgPainelApagado")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView tNeK9O6yCt;

	[AccessedThroughProperty("GroupBox12")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox Q9jKzprwpo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgAMao")]
	private DataGridView V1DeWvcC5k;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt12AMao")]
	private Button TvlepTmFRS;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox13")]
	private GroupBox usWeT11BAN;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgReguaMascara")]
	private DataGridView PNTeJLTqkS;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bt13ReguaMascara")]
	private Button Jy0ehFxTgu;

	[AccessedThroughProperty("dgPrincipalPotenciais")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView xMTeoguiW5;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btReguaBorneSemUso")]
	private Button D2VeGvKs6w;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTCorrigaBornesDiscrepantes")]
	private Button HrxeHabgdN;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox14")]
	private GroupBox Aucekx1jwO;

	[AccessedThroughProperty("BTCorrigaPortasDiscrepantes")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button pZ1edbYVPH;

	[AccessedThroughProperty("dgPortasDiscrepantes")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private DataGridView dZpefIVc5G;

	[CompilerGenerated]
	[AccessedThroughProperty("bt14PortasDiscrepantes")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button JWleD9lNSC;

	private ClsVerificadorProjetoFiacao._StructureConexao[] rDdevXNNtA;

	private DeclaracoesEntidades.StructureBorne[] c4Le6sxa5V;

	private ClsVerificadorProjetoFiacao._StructureAnalisePorta[] G78etxbxf6;

	private ClsVerificadorProjetoFiacao._StructuremDispositivo[] zvRejlppGf;

	private ClsVerificadorProjetoFiacao._StructuremAuxiliar[] A94eLhaDqZ;

	private Declaracoes2.MModeloDePortas[] n4fewEGaSS;

	private ColorDialog Gjlexvcpwe;

	private int bnDebnRZuM;

	private DataGridViewCellStyle bLMeM4ViM0;

	private DataGridViewCellStyle xXZeOAvJAT;

	private bool y1geIJmXHd;

	private bool Doje7509aG;

	private List<string> Cnbeqqq0yD;

	private List<string> cOWeaBRTRB;

	private List<string> NYCe8hPSTs;

	private clsBlocos.StructureErros[] jhleNuAtKc;

	private ClsVerificadorProjetoFiacao._StructurefiacaoErro[] CfmeFZJ4iM;

	internal virtual Button btCorDoErroF
	{
		[CompilerGenerated]
		get
		{
			return BP9KOfK5LV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = G39c3be3rW;
			Button button = BP9KOfK5LV;
			if (button != null)
			{
				button.Click -= value2;
			}
			BP9KOfK5LV = value;
			button = BP9KOfK5LV;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBoxFiacao
	{
		[CompilerGenerated]
		get
		{
			return TGcKI1Kj4r;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TGcKI1Kj4r = value;
		}
	}

	internal virtual Button btMostraErroFiação
	{
		[CompilerGenerated]
		get
		{
			return bIIK7OcM6a;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = WnWcnJUkps;
			Button button = bIIK7OcM6a;
			if (button != null)
			{
				button.Click -= value2;
			}
			bIIK7OcM6a = value;
			button = bIIK7OcM6a;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button btOcultaErroFiação
	{
		[CompilerGenerated]
		get
		{
			return LceKqj4PtS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UH6c1lkAM9;
			Button button = LceKqj4PtS;
			if (button != null)
			{
				button.Click -= value2;
			}
			LceKqj4PtS = value;
			button = LceKqj4PtS;
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
			return F1EKaUiSnF;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TreeViewEventHandler value2 = k1bcE1G0gP;
			TreeView treeView = F1EKaUiSnF;
			if (treeView != null)
			{
				treeView.AfterSelect -= value2;
			}
			F1EKaUiSnF = value;
			treeView = F1EKaUiSnF;
			if (treeView != null)
			{
				treeView.AfterSelect += value2;
			}
		}
	}

	internal virtual TreeView TreeViewBornes
	{
		[CompilerGenerated]
		get
		{
			return HXWK8A2OLp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			HXWK8A2OLp = value;
		}
	}

	internal virtual DataGridView dgBornes
	{
		[CompilerGenerated]
		get
		{
			return jPcKNsGA4H;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = Hlfc4B0Q8I;
			DataGridView dataGridView = jPcKNsGA4H;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
			}
			jPcKNsGA4H = value;
			dataGridView = jPcKNsGA4H;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
			}
		}
	}

	internal virtual DataGridView dgTerminais
	{
		[CompilerGenerated]
		get
		{
			return mEVKF4LCuY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = fTDcSr8PoA;
			DataGridView dataGridView = mEVKF4LCuY;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
			}
			mEVKF4LCuY = value;
			dataGridView = mEVKF4LCuY;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
			}
		}
	}

	internal virtual DataGridView dgAuxiliar
	{
		[CompilerGenerated]
		get
		{
			return JbhKQE7jD0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = qK7cBUDocy;
			DataGridView dataGridView = JbhKQE7jD0;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
			}
			JbhKQE7jD0 = value;
			dataGridView = JbhKQE7jD0;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
			}
		}
	}

	internal virtual DataGridView dgPrincipal
	{
		[CompilerGenerated]
		get
		{
			return aplKP0T9Sa;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = jsRcswpefk;
			DataGridView dataGridView = aplKP0T9Sa;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
			}
			aplKP0T9Sa = value;
			dataGridView = aplKP0T9Sa;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
			}
		}
	}

	internal virtual Button btAtualizar
	{
		[CompilerGenerated]
		get
		{
			return rrCKcT6Mx0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = FIKcV6Rmpw;
			Button button = rrCKcT6Mx0;
			if (button != null)
			{
				button.Click -= value2;
			}
			rrCKcT6Mx0 = value;
			button = rrCKcT6Mx0;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgEquip
	{
		[CompilerGenerated]
		get
		{
			return kuyKKEgaDc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			kuyKKEgaDc = value;
		}
	}

	internal virtual DataGridView dgBornesEditados
	{
		[CompilerGenerated]
		get
		{
			return mOGKeoy7KL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = vyVcZcvIbJ;
			DataGridView dataGridView = mOGKeoy7KL;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
			}
			mOGKeoy7KL = value;
			dataGridView = mOGKeoy7KL;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
			}
		}
	}

	internal virtual DataGridView dgReguasSemUso
	{
		[CompilerGenerated]
		get
		{
			return lcfK2f3K2x;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			lcfK2f3K2x = value;
		}
	}

	internal virtual DataGridView dgFiacaoOrfao
	{
		[CompilerGenerated]
		get
		{
			return eI0K3PwqLg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = vQXciEj7J5;
			DataGridView dataGridView = eI0K3PwqLg;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
			}
			eI0K3PwqLg = value;
			dataGridView = eI0K3PwqLg;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
			}
		}
	}

	internal virtual Button bt2Orfao
	{
		[CompilerGenerated]
		get
		{
			return FFqKnsXgcp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = r79KTMtQTy;
			Button button = FFqKnsXgcp;
			if (button != null)
			{
				button.Click -= value2;
			}
			FFqKnsXgcp = value;
			button = FFqKnsXgcp;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button bt5Terminais
	{
		[CompilerGenerated]
		get
		{
			return gNMK1UJWDc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = oo9KJpCHeD;
			Button button = gNMK1UJWDc;
			if (button != null)
			{
				button.Click -= value2;
			}
			gNMK1UJWDc = value;
			button = gNMK1UJWDc;
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
			return JwxKlfLWBd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = QYCKGPBgyF;
			Button button = JwxKlfLWBd;
			if (button != null)
			{
				button.Click -= value2;
			}
			JwxKlfLWBd = value;
			button = JwxKlfLWBd;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button bt4Auxiliar
	{
		[CompilerGenerated]
		get
		{
			return PtaK57spHV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = XPFKpSFhPj;
			Button button = PtaK57spHV;
			if (button != null)
			{
				button.Click -= value2;
			}
			PtaK57spHV = value;
			button = PtaK57spHV;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button bt3Principal
	{
		[CompilerGenerated]
		get
		{
			return aKGK01ev8i;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = zFVKWbxmvT;
			Button button = aKGK01ev8i;
			if (button != null)
			{
				button.Click -= value2;
			}
			aKGK01ev8i = value;
			button = aKGK01ev8i;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button bt1Fiacao
	{
		[CompilerGenerated]
		get
		{
			return nJ7KRB00wO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = nDxczlm9a5;
			Button button = nJ7KRB00wO;
			if (button != null)
			{
				button.Click -= value2;
			}
			nJ7KRB00wO = value;
			button = nJ7KRB00wO;
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
			return DeHKmH9IsR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DeHKmH9IsR = value;
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return jHnKXQViB6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jHnKXQViB6 = value;
		}
	}

	internal virtual GroupBox GroupBox3
	{
		[CompilerGenerated]
		get
		{
			return NcTKUGIGIh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			NcTKUGIGIh = value;
		}
	}

	internal virtual GroupBox GroupBox5
	{
		[CompilerGenerated]
		get
		{
			return m5yKyLK1v4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			m5yKyLK1v4 = value;
		}
	}

	internal virtual GroupBox GroupBox4
	{
		[CompilerGenerated]
		get
		{
			return FIbKgdHEHm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			FIbKgdHEHm = value;
		}
	}

	internal virtual GroupBox GroupBox8
	{
		[CompilerGenerated]
		get
		{
			return AjPKAkJsDO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			AjPKAkJsDO = value;
		}
	}

	internal virtual GroupBox GroupBox7
	{
		[CompilerGenerated]
		get
		{
			return AZPKs44Gi4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			AZPKs44Gi4 = value;
		}
	}

	internal virtual GroupBox GroupBox6
	{
		[CompilerGenerated]
		get
		{
			return vq5KBYk8kE;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			vq5KBYk8kE = value;
		}
	}

	internal virtual GroupBox GroupBox9
	{
		[CompilerGenerated]
		get
		{
			return opgKVZdOHO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			opgKVZdOHO = value;
		}
	}

	internal virtual Button bt9Discrepantes
	{
		[CompilerGenerated]
		get
		{
			return D1LKuQOKf3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UgJKHT3oZw;
			Button button = D1LKuQOKf3;
			if (button != null)
			{
				button.Click -= value2;
			}
			D1LKuQOKf3 = value;
			button = D1LKuQOKf3;
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
			return NmTKE5fMng;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = flfKh5Uhfw;
			Button button = NmTKE5fMng;
			if (button != null)
			{
				button.Click -= value2;
			}
			NmTKE5fMng = value;
			button = NmTKE5fMng;
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
			return utfKZNCKH9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CpIKoBdYZt;
			Button button = utfKZNCKH9;
			if (button != null)
			{
				button.Click -= value2;
			}
			utfKZNCKH9 = value;
			button = utfKZNCKH9;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox10
	{
		[CompilerGenerated]
		get
		{
			return JFPKibKF79;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			JFPKibKF79 = value;
		}
	}

	internal virtual TreeView TreeViewBornesLM
	{
		[CompilerGenerated]
		get
		{
			return kjPKSriMLl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			kjPKSriMLl = value;
		}
	}

	internal virtual Button bt10BornesLM
	{
		[CompilerGenerated]
		get
		{
			return PaXK4yFxxD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = c4cKkJJoon;
			Button button = PaXK4yFxxD;
			if (button != null)
			{
				button.Click -= value2;
			}
			PaXK4yFxxD = value;
			button = PaXK4yFxxD;
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
			return Q8KKCxDeop;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Q8KKCxDeop = value;
		}
	}

	internal virtual GroupBox GroupBox11
	{
		[CompilerGenerated]
		get
		{
			return KxmKYFl7VA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KxmKYFl7VA = value;
		}
	}

	internal virtual Button bt11Paineis
	{
		[CompilerGenerated]
		get
		{
			return oOnKrrx68b;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = rVZKdkPIyf;
			Button button = oOnKrrx68b;
			if (button != null)
			{
				button.Click -= value2;
			}
			oOnKrrx68b = value;
			button = oOnKrrx68b;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgPainelApagado
	{
		[CompilerGenerated]
		get
		{
			return tNeK9O6yCt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = OFCcCMgjMH;
			DataGridView dataGridView = tNeK9O6yCt;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
			}
			tNeK9O6yCt = value;
			dataGridView = tNeK9O6yCt;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox12
	{
		[CompilerGenerated]
		get
		{
			return Q9jKzprwpo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Q9jKzprwpo = value;
		}
	}

	internal virtual DataGridView dgAMao
	{
		[CompilerGenerated]
		get
		{
			return V1DeWvcC5k;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = WhccYNZIOb;
			DataGridView dataGridView = V1DeWvcC5k;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
			}
			V1DeWvcC5k = value;
			dataGridView = V1DeWvcC5k;
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
			return TvlepTmFRS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = aNLKfRT8hS;
			Button button = TvlepTmFRS;
			if (button != null)
			{
				button.Click -= value2;
			}
			TvlepTmFRS = value;
			button = TvlepTmFRS;
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
			return usWeT11BAN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			usWeT11BAN = value;
		}
	}

	internal virtual DataGridView dgReguaMascara
	{
		[CompilerGenerated]
		get
		{
			return PNTeJLTqkS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PNTeJLTqkS = value;
		}
	}

	internal virtual Button bt13ReguaMascara
	{
		[CompilerGenerated]
		get
		{
			return Jy0ehFxTgu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = sj3KDps2Kx;
			Button button = Jy0ehFxTgu;
			if (button != null)
			{
				button.Click -= value2;
			}
			Jy0ehFxTgu = value;
			button = Jy0ehFxTgu;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgPrincipalPotenciais
	{
		[CompilerGenerated]
		get
		{
			return xMTeoguiW5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = yS4K6xt0hs;
			DataGridView dataGridView = xMTeoguiW5;
			if (dataGridView != null)
			{
				dataGridView.MouseUp -= value2;
			}
			xMTeoguiW5 = value;
			dataGridView = xMTeoguiW5;
			if (dataGridView != null)
			{
				dataGridView.MouseUp += value2;
			}
		}
	}

	internal virtual Button btReguaBorneSemUso
	{
		[CompilerGenerated]
		get
		{
			return D2VeGvKs6w;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = wFNKjfJWUL;
			Button button = D2VeGvKs6w;
			if (button != null)
			{
				button.Click -= value2;
			}
			D2VeGvKs6w = value;
			button = D2VeGvKs6w;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button BTCorrigaBornesDiscrepantes
	{
		[CompilerGenerated]
		get
		{
			return HrxeHabgdN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = vsNKLQHH7c;
			Button button = HrxeHabgdN;
			if (button != null)
			{
				button.Click -= value2;
			}
			HrxeHabgdN = value;
			button = HrxeHabgdN;
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
			return Aucekx1jwO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Aucekx1jwO = value;
		}
	}

	internal virtual Button BTCorrigaPortasDiscrepantes
	{
		[CompilerGenerated]
		get
		{
			return pZ1edbYVPH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = gG3Kwv0Ena;
			Button button = pZ1edbYVPH;
			if (button != null)
			{
				button.Click -= value2;
			}
			pZ1edbYVPH = value;
			button = pZ1edbYVPH;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual DataGridView dgPortasDiscrepantes
	{
		[CompilerGenerated]
		get
		{
			return dZpefIVc5G;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			DataGridViewCellEventHandler value2 = qoFKx7rRWx;
			DataGridView dataGridView = dZpefIVc5G;
			if (dataGridView != null)
			{
				dataGridView.CellClick -= value2;
			}
			dZpefIVc5G = value;
			dataGridView = dZpefIVc5G;
			if (dataGridView != null)
			{
				dataGridView.CellClick += value2;
			}
		}
	}

	internal virtual Button bt14PortasDiscrepantes
	{
		[CompilerGenerated]
		get
		{
			return JWleD9lNSC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = fQXKvJRE5T;
			Button button = JWleD9lNSC;
			if (button != null)
			{
				button.Click -= value2;
			}
			JWleD9lNSC = value;
			button = JWleD9lNSC;
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
			if (disposing && T8iKbhRubd != null)
			{
				T8iKbhRubd.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void c1Hc2nQSEw()
	{
		T8iKbhRubd = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
		FDqpBiUmZij(new ToolTip(T8iKbhRubd));
		TreeView1 = new TreeView();
		GroupBoxFiacao = new GroupBox();
		btCorDoErroF = new Button();
		btMostraErroFiação = new Button();
		btOcultaErroFiação = new Button();
		dgAuxiliar = new DataGridView();
		dgPrincipal = new DataGridView();
		dgFiacaoOrfao = new DataGridView();
		dgBornes = new DataGridView();
		dgTerminais = new DataGridView();
		TreeViewBornes = new TreeView();
		dgBornesEditados = new DataGridView();
		dgReguasSemUso = new DataGridView();
		btAtualizar = new Button();
		dgEquip = new DataGridView();
		bt2Orfao = new Button();
		bt5Terminais = new Button();
		bt9Discrepantes = new Button();
		bt7Reguas = new Button();
		bt8intervalos = new Button();
		bt6Portas = new Button();
		bt4Auxiliar = new Button();
		bt3Principal = new Button();
		bt1Fiacao = new Button();
		GroupBox1 = new GroupBox();
		dgPrincipalPotenciais = new DataGridView();
		GroupBox12 = new GroupBox();
		dgAMao = new DataGridView();
		GroupBox11 = new GroupBox();
		dgPainelApagado = new DataGridView();
		GroupBox10 = new GroupBox();
		TreeViewBornesLM = new TreeView();
		GroupBox2 = new GroupBox();
		GroupBox3 = new GroupBox();
		GroupBox4 = new GroupBox();
		GroupBox5 = new GroupBox();
		GroupBox8 = new GroupBox();
		GroupBox7 = new GroupBox();
		GroupBox6 = new GroupBox();
		btReguaBorneSemUso = new Button();
		GroupBox9 = new GroupBox();
		BTCorrigaBornesDiscrepantes = new Button();
		bt10BornesLM = new Button();
		GBEX = new GroupBox();
		bt11Paineis = new Button();
		bt12AMao = new Button();
		GroupBox13 = new GroupBox();
		dgReguaMascara = new DataGridView();
		bt13ReguaMascara = new Button();
		GroupBox14 = new GroupBox();
		BTCorrigaPortasDiscrepantes = new Button();
		dgPortasDiscrepantes = new DataGridView();
		bt14PortasDiscrepantes = new Button();
		GroupBoxFiacao.SuspendLayout();
		((ISupportInitialize)dgAuxiliar).BeginInit();
		((ISupportInitialize)dgPrincipal).BeginInit();
		((ISupportInitialize)dgFiacaoOrfao).BeginInit();
		((ISupportInitialize)dgBornes).BeginInit();
		((ISupportInitialize)dgTerminais).BeginInit();
		((ISupportInitialize)dgBornesEditados).BeginInit();
		((ISupportInitialize)dgReguasSemUso).BeginInit();
		((ISupportInitialize)dgEquip).BeginInit();
		GroupBox1.SuspendLayout();
		((ISupportInitialize)dgPrincipalPotenciais).BeginInit();
		GroupBox12.SuspendLayout();
		((ISupportInitialize)dgAMao).BeginInit();
		GroupBox11.SuspendLayout();
		((ISupportInitialize)dgPainelApagado).BeginInit();
		GroupBox10.SuspendLayout();
		GroupBox2.SuspendLayout();
		GroupBox3.SuspendLayout();
		GroupBox4.SuspendLayout();
		GroupBox5.SuspendLayout();
		GroupBox8.SuspendLayout();
		GroupBox7.SuspendLayout();
		GroupBox6.SuspendLayout();
		GroupBox9.SuspendLayout();
		GroupBox13.SuspendLayout();
		((ISupportInitialize)dgReguaMascara).BeginInit();
		GroupBox14.SuspendLayout();
		((ISupportInitialize)dgPortasDiscrepantes).BeginInit();
		SuspendLayout();
		TreeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		TreeView1.Location = new Point(3, 19);
		TreeView1.Name = "TreeView1";
		TreeView1.Size = new Size(138, 243);
		TreeView1.TabIndex = 189;
		GroupBoxFiacao.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		GroupBoxFiacao.Controls.Add(btCorDoErroF);
		GroupBoxFiacao.Controls.Add(btMostraErroFiação);
		GroupBoxFiacao.Controls.Add(btOcultaErroFiação);
		GroupBoxFiacao.Location = new Point(179, 145);
		GroupBoxFiacao.Name = "GroupBoxFiacao";
		GroupBoxFiacao.Size = new Size(350, 64);
		GroupBoxFiacao.TabIndex = 187;
		GroupBoxFiacao.TabStop = false;
		GroupBoxFiacao.Text = "Fiação";
		btCorDoErroF.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		btCorDoErroF.BackColor = Color.LimeGreen;
		btCorDoErroF.Location = new Point(306, 28);
		btCorDoErroF.Name = "btCorDoErroF";
		btCorDoErroF.Size = new Size(23, 20);
		btCorDoErroF.TabIndex = 179;
		btCorDoErroF.UseVisualStyleBackColor = false;
		btMostraErroFiação.FlatStyle = FlatStyle.Flat;
		btMostraErroFiação.ForeColor = SystemColors.Control;
		btMostraErroFiação.Image = Resources.Liga_32;
		btMostraErroFiação.Location = new Point(6, 18);
		btMostraErroFiação.Name = "btMostraErroFiação";
		btMostraErroFiação.Size = new Size(40, 40);
		btMostraErroFiação.TabIndex = 180;
		btMostraErroFiação.UseVisualStyleBackColor = true;
		btOcultaErroFiação.FlatStyle = FlatStyle.Flat;
		btOcultaErroFiação.ForeColor = SystemColors.Control;
		btOcultaErroFiação.Image = Resources.Desliga_32;
		btOcultaErroFiação.Location = new Point(46, 18);
		btOcultaErroFiação.Name = "btOcultaErroFiação";
		btOcultaErroFiação.Size = new Size(40, 40);
		btOcultaErroFiação.TabIndex = 181;
		btOcultaErroFiação.UseVisualStyleBackColor = true;
		dgAuxiliar.AllowUserToAddRows = false;
		dgAuxiliar.AllowUserToDeleteRows = false;
		dgAuxiliar.AllowUserToResizeRows = false;
		dgAuxiliar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgAuxiliar.BackgroundColor = Color.White;
		dgAuxiliar.BorderStyle = BorderStyle.Fixed3D;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgAuxiliar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgAuxiliar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgAuxiliar.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgAuxiliar.Location = new Point(3, 18);
		dgAuxiliar.Name = "dgAuxiliar";
		dgAuxiliar.ReadOnly = true;
		dgAuxiliar.RowHeadersVisible = false;
		dgAuxiliar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgAuxiliar.Size = new Size(77, 18);
		dgAuxiliar.TabIndex = 200;
		dgPrincipal.AllowUserToAddRows = false;
		dgPrincipal.AllowUserToDeleteRows = false;
		dgPrincipal.AllowUserToResizeRows = false;
		dgPrincipal.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgPrincipal.BackgroundColor = Color.White;
		dgPrincipal.BorderStyle = BorderStyle.Fixed3D;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dgPrincipal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgPrincipal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPrincipal.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgPrincipal.Location = new Point(3, 18);
		dgPrincipal.Name = "dgPrincipal";
		dgPrincipal.ReadOnly = true;
		dgPrincipal.RowHeadersVisible = false;
		dgPrincipal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPrincipal.Size = new Size(77, 18);
		dgPrincipal.TabIndex = 201;
		dgFiacaoOrfao.AllowUserToAddRows = false;
		dgFiacaoOrfao.AllowUserToDeleteRows = false;
		dgFiacaoOrfao.AllowUserToResizeRows = false;
		dgFiacaoOrfao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgFiacaoOrfao.BackgroundColor = Color.White;
		dgFiacaoOrfao.BorderStyle = BorderStyle.Fixed3D;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		dgFiacaoOrfao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		dgFiacaoOrfao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgFiacaoOrfao.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgFiacaoOrfao.Location = new Point(3, 18);
		dgFiacaoOrfao.Name = "dgFiacaoOrfao";
		dgFiacaoOrfao.ReadOnly = true;
		dgFiacaoOrfao.RowHeadersVisible = false;
		dgFiacaoOrfao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgFiacaoOrfao.Size = new Size(77, 18);
		dgFiacaoOrfao.TabIndex = 204;
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
		dgBornes.Size = new Size(77, 18);
		dgBornes.TabIndex = 199;
		dgTerminais.AllowUserToAddRows = false;
		dgTerminais.AllowUserToDeleteRows = false;
		dgTerminais.AllowUserToResizeRows = false;
		dgTerminais.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgTerminais.BackgroundColor = Color.White;
		dgTerminais.BorderStyle = BorderStyle.Fixed3D;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle5.BackColor = SystemColors.Control;
		dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
		dgTerminais.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
		dgTerminais.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgTerminais.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgTerminais.Location = new Point(3, 18);
		dgTerminais.Name = "dgTerminais";
		dgTerminais.ReadOnly = true;
		dgTerminais.RowHeadersVisible = false;
		dgTerminais.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgTerminais.Size = new Size(77, 18);
		dgTerminais.TabIndex = 199;
		TreeViewBornes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TreeViewBornes.Location = new Point(3, 18);
		TreeViewBornes.Name = "TreeViewBornes";
		TreeViewBornes.Size = new Size(77, 18);
		TreeViewBornes.TabIndex = 190;
		dgBornesEditados.AllowUserToAddRows = false;
		dgBornesEditados.AllowUserToDeleteRows = false;
		dgBornesEditados.AllowUserToResizeRows = false;
		dgBornesEditados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgBornesEditados.BackgroundColor = Color.White;
		dgBornesEditados.BorderStyle = BorderStyle.Fixed3D;
		dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle6.BackColor = SystemColors.Control;
		dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
		dgBornesEditados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
		dgBornesEditados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgBornesEditados.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgBornesEditados.Location = new Point(3, 18);
		dgBornesEditados.Name = "dgBornesEditados";
		dgBornesEditados.ReadOnly = true;
		dgBornesEditados.RowHeadersVisible = false;
		dgBornesEditados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgBornesEditados.Size = new Size(77, 18);
		dgBornesEditados.TabIndex = 200;
		dgReguasSemUso.AllowUserToAddRows = false;
		dgReguasSemUso.AllowUserToDeleteRows = false;
		dgReguasSemUso.AllowUserToResizeRows = false;
		dgReguasSemUso.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgReguasSemUso.BackgroundColor = Color.White;
		dgReguasSemUso.BorderStyle = BorderStyle.Fixed3D;
		dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle7.BackColor = SystemColors.Control;
		dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
		dgReguasSemUso.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
		dgReguasSemUso.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgReguasSemUso.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgReguasSemUso.Location = new Point(3, 18);
		dgReguasSemUso.Name = "dgReguasSemUso";
		dgReguasSemUso.ReadOnly = true;
		dgReguasSemUso.RowHeadersVisible = false;
		dgReguasSemUso.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgReguasSemUso.Size = new Size(77, 19);
		dgReguasSemUso.TabIndex = 202;
		btAtualizar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btAtualizar.FlatStyle = FlatStyle.Flat;
		btAtualizar.ForeColor = SystemColors.Control;
		btAtualizar.Image = Resources.Pesquisar_32;
		btAtualizar.Location = new Point(71, 437);
		btAtualizar.Name = "btAtualizar";
		btAtualizar.Size = new Size(40, 40);
		btAtualizar.TabIndex = 181;
		btAtualizar.UseVisualStyleBackColor = true;
		dgEquip.AllowUserToAddRows = false;
		dgEquip.AllowUserToDeleteRows = false;
		dgEquip.AllowUserToOrderColumns = true;
		dgEquip.AllowUserToResizeRows = false;
		dgEquip.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgEquip.BackgroundColor = Color.White;
		dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle8.BackColor = SystemColors.Control;
		dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
		dgEquip.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
		dgEquip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgEquip.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgEquip.Location = new Point(12, 12);
		dgEquip.MultiSelect = false;
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(158, 415);
		dgEquip.TabIndex = 182;
		bt2Orfao.Location = new Point(297, 12);
		bt2Orfao.Name = "bt2Orfao";
		bt2Orfao.Size = new Size(115, 23);
		bt2Orfao.TabIndex = 5;
		bt2Orfao.Text = "bt2Orfao";
		bt2Orfao.UseVisualStyleBackColor = true;
		bt5Terminais.Location = new Point(297, 38);
		bt5Terminais.Name = "bt5Terminais";
		bt5Terminais.Size = new Size(115, 23);
		bt5Terminais.TabIndex = 4;
		bt5Terminais.Text = "bt5Terminais";
		bt5Terminais.UseVisualStyleBackColor = true;
		bt9Discrepantes.Location = new Point(297, 90);
		bt9Discrepantes.Name = "bt9Discrepantes";
		bt9Discrepantes.Size = new Size(115, 23);
		bt9Discrepantes.TabIndex = 3;
		bt9Discrepantes.Text = "bt9Discrepantes";
		bt9Discrepantes.UseVisualStyleBackColor = true;
		bt7Reguas.Location = new Point(179, 64);
		bt7Reguas.Name = "bt7Reguas";
		bt7Reguas.Size = new Size(115, 23);
		bt7Reguas.TabIndex = 3;
		bt7Reguas.Text = "bt7Reguas";
		bt7Reguas.UseVisualStyleBackColor = true;
		bt8intervalos.Location = new Point(415, 64);
		bt8intervalos.Name = "bt8intervalos";
		bt8intervalos.Size = new Size(115, 23);
		bt8intervalos.TabIndex = 3;
		bt8intervalos.Text = "bt8intervalos";
		bt8intervalos.UseVisualStyleBackColor = true;
		bt6Portas.Location = new Point(415, 38);
		bt6Portas.Name = "bt6Portas";
		bt6Portas.Size = new Size(115, 23);
		bt6Portas.TabIndex = 3;
		bt6Portas.Text = "bt6Portas";
		bt6Portas.UseVisualStyleBackColor = true;
		bt4Auxiliar.Location = new Point(179, 38);
		bt4Auxiliar.Name = "bt4Auxiliar";
		bt4Auxiliar.Size = new Size(115, 23);
		bt4Auxiliar.TabIndex = 2;
		bt4Auxiliar.Text = "bt4Auxiliar";
		bt4Auxiliar.UseVisualStyleBackColor = true;
		bt3Principal.Location = new Point(415, 12);
		bt3Principal.Name = "bt3Principal";
		bt3Principal.Size = new Size(115, 23);
		bt3Principal.TabIndex = 1;
		bt3Principal.Text = "bt3Principal";
		bt3Principal.UseVisualStyleBackColor = true;
		bt1Fiacao.Location = new Point(179, 12);
		bt1Fiacao.Name = "bt1Fiacao";
		bt1Fiacao.Size = new Size(115, 23);
		bt1Fiacao.TabIndex = 0;
		bt1Fiacao.Text = "1Fiação";
		bt1Fiacao.UseVisualStyleBackColor = true;
		GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox1.Controls.Add(dgPrincipalPotenciais);
		GroupBox1.Controls.Add(TreeView1);
		GroupBox1.Location = new Point(179, 217);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(350, 266);
		GroupBox1.TabIndex = 184;
		GroupBox1.TabStop = false;
		dgPrincipalPotenciais.AllowUserToAddRows = false;
		dgPrincipalPotenciais.AllowUserToDeleteRows = false;
		dgPrincipalPotenciais.AllowUserToResizeRows = false;
		dgPrincipalPotenciais.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
		dgPrincipalPotenciais.BackgroundColor = Color.White;
		dgPrincipalPotenciais.BorderStyle = BorderStyle.Fixed3D;
		dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle9.BackColor = SystemColors.Control;
		dataGridViewCellStyle9.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
		dgPrincipalPotenciais.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
		dgPrincipalPotenciais.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPrincipalPotenciais.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgPrincipalPotenciais.Location = new Point(149, 19);
		dgPrincipalPotenciais.Name = "dgPrincipalPotenciais";
		dgPrincipalPotenciais.ReadOnly = true;
		dgPrincipalPotenciais.RowHeadersVisible = false;
		dgPrincipalPotenciais.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPrincipalPotenciais.Size = new Size(195, 243);
		dgPrincipalPotenciais.TabIndex = 204;
		GroupBox12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox12.Controls.Add(dgAMao);
		GroupBox12.Location = new Point(371, 355);
		GroupBox12.Name = "GroupBox12";
		GroupBox12.Size = new Size(83, 47);
		GroupBox12.TabIndex = 196;
		GroupBox12.TabStop = false;
		GroupBox12.Text = "GroupBox12";
		dgAMao.AllowUserToAddRows = false;
		dgAMao.AllowUserToDeleteRows = false;
		dgAMao.AllowUserToResizeRows = false;
		dgAMao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgAMao.BackgroundColor = Color.White;
		dgAMao.BorderStyle = BorderStyle.Fixed3D;
		dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle10.BackColor = SystemColors.Control;
		dataGridViewCellStyle10.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle10.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
		dgAMao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
		dgAMao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgAMao.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgAMao.Location = new Point(3, 17);
		dgAMao.Name = "dgAMao";
		dgAMao.ReadOnly = true;
		dgAMao.RowHeadersVisible = false;
		dgAMao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgAMao.Size = new Size(77, 18);
		dgAMao.TabIndex = 201;
		GroupBox11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox11.Controls.Add(dgPainelApagado);
		GroupBox11.Location = new Point(369, 299);
		GroupBox11.Name = "GroupBox11";
		GroupBox11.Size = new Size(83, 47);
		GroupBox11.TabIndex = 195;
		GroupBox11.TabStop = false;
		GroupBox11.Text = "GroupBox11";
		dgPainelApagado.AllowUserToAddRows = false;
		dgPainelApagado.AllowUserToDeleteRows = false;
		dgPainelApagado.AllowUserToResizeRows = false;
		dgPainelApagado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgPainelApagado.BackgroundColor = Color.White;
		dgPainelApagado.BorderStyle = BorderStyle.Fixed3D;
		dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle11.BackColor = SystemColors.Control;
		dataGridViewCellStyle11.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle11.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
		dgPainelApagado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
		dgPainelApagado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPainelApagado.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgPainelApagado.Location = new Point(3, 17);
		dgPainelApagado.Name = "dgPainelApagado";
		dgPainelApagado.ReadOnly = true;
		dgPainelApagado.RowHeadersVisible = false;
		dgPainelApagado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPainelApagado.Size = new Size(77, 18);
		dgPainelApagado.TabIndex = 201;
		GroupBox10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox10.Controls.Add(TreeViewBornesLM);
		GroupBox10.Location = new Point(369, 243);
		GroupBox10.Name = "GroupBox10";
		GroupBox10.Size = new Size(83, 47);
		GroupBox10.TabIndex = 194;
		GroupBox10.TabStop = false;
		GroupBox10.Text = "GroupBox10";
		TreeViewBornesLM.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		TreeViewBornesLM.Location = new Point(3, 18);
		TreeViewBornesLM.Name = "TreeViewBornesLM";
		TreeViewBornesLM.Size = new Size(77, 18);
		TreeViewBornesLM.TabIndex = 190;
		GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox2.Controls.Add(dgPrincipal);
		GroupBox2.Location = new Point(191, 243);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(83, 47);
		GroupBox2.TabIndex = 191;
		GroupBox2.TabStop = false;
		GroupBox2.Text = "GroupBox2";
		GroupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox3.Controls.Add(dgAuxiliar);
		GroupBox3.Location = new Point(192, 299);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(83, 47);
		GroupBox3.TabIndex = 192;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "GroupBox3";
		GroupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox4.Controls.Add(dgFiacaoOrfao);
		GroupBox4.Location = new Point(191, 354);
		GroupBox4.Name = "GroupBox4";
		GroupBox4.Size = new Size(83, 47);
		GroupBox4.TabIndex = 193;
		GroupBox4.TabStop = false;
		GroupBox4.Text = "GroupBox4";
		GroupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox5.Controls.Add(dgTerminais);
		GroupBox5.Location = new Point(193, 402);
		GroupBox5.Name = "GroupBox5";
		GroupBox5.Size = new Size(83, 47);
		GroupBox5.TabIndex = 193;
		GroupBox5.TabStop = false;
		GroupBox5.Text = "GroupBox5";
		GroupBox8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox8.Controls.Add(dgBornes);
		GroupBox8.Location = new Point(283, 355);
		GroupBox8.Name = "GroupBox8";
		GroupBox8.Size = new Size(83, 47);
		GroupBox8.TabIndex = 193;
		GroupBox8.TabStop = false;
		GroupBox8.Text = "GroupBox8";
		GroupBox7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox7.Controls.Add(TreeViewBornes);
		GroupBox7.Location = new Point(280, 298);
		GroupBox7.Name = "GroupBox7";
		GroupBox7.Size = new Size(83, 47);
		GroupBox7.TabIndex = 193;
		GroupBox7.TabStop = false;
		GroupBox7.Text = "GroupBox7";
		GroupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox6.Controls.Add(btReguaBorneSemUso);
		GroupBox6.Controls.Add(dgReguasSemUso);
		GroupBox6.Location = new Point(280, 243);
		GroupBox6.Name = "GroupBox6";
		GroupBox6.Size = new Size(83, 86);
		GroupBox6.TabIndex = 193;
		GroupBox6.TabStop = false;
		GroupBox6.Text = "GroupBox6";
		btReguaBorneSemUso.Anchor = AnchorStyles.Bottom;
		btReguaBorneSemUso.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		btReguaBorneSemUso.ForeColor = Color.Red;
		btReguaBorneSemUso.Location = new Point(-15, 43);
		btReguaBorneSemUso.Name = "btReguaBorneSemUso";
		btReguaBorneSemUso.Size = new Size(116, 35);
		btReguaBorneSemUso.TabIndex = 224;
		btReguaBorneSemUso.Text = "Corrigir";
		btReguaBorneSemUso.UseVisualStyleBackColor = true;
		GroupBox9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox9.Controls.Add(BTCorrigaBornesDiscrepantes);
		GroupBox9.Controls.Add(dgBornesEditados);
		GroupBox9.Location = new Point(283, 402);
		GroupBox9.Name = "GroupBox9";
		GroupBox9.Size = new Size(83, 85);
		GroupBox9.TabIndex = 193;
		GroupBox9.TabStop = false;
		GroupBox9.Text = "GroupBox9";
		BTCorrigaBornesDiscrepantes.Anchor = AnchorStyles.Bottom;
		BTCorrigaBornesDiscrepantes.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		BTCorrigaBornesDiscrepantes.ForeColor = Color.Red;
		BTCorrigaBornesDiscrepantes.Location = new Point(-18, 42);
		BTCorrigaBornesDiscrepantes.Name = "BTCorrigaBornesDiscrepantes";
		BTCorrigaBornesDiscrepantes.Size = new Size(116, 35);
		BTCorrigaBornesDiscrepantes.TabIndex = 224;
		BTCorrigaBornesDiscrepantes.Text = "Corrigir";
		BTCorrigaBornesDiscrepantes.UseVisualStyleBackColor = true;
		bt10BornesLM.Location = new Point(179, 90);
		bt10BornesLM.Name = "bt10BornesLM";
		bt10BornesLM.Size = new Size(115, 23);
		bt10BornesLM.TabIndex = 195;
		bt10BornesLM.Text = "bt10BornesLM";
		bt10BornesLM.UseVisualStyleBackColor = true;
		GBEX.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		GBEX.Location = new Point(179, 145);
		GBEX.Name = "GBEX";
		GBEX.Size = new Size(350, 338);
		GBEX.TabIndex = 190;
		GBEX.TabStop = false;
		GBEX.Text = "GBEX";
		bt11Paineis.Location = new Point(179, 116);
		bt11Paineis.Name = "bt11Paineis";
		bt11Paineis.Size = new Size(115, 23);
		bt11Paineis.TabIndex = 196;
		bt11Paineis.Text = "bt11Paineis";
		bt11Paineis.UseVisualStyleBackColor = true;
		bt12AMao.Location = new Point(297, 116);
		bt12AMao.Name = "bt12AMao";
		bt12AMao.Size = new Size(115, 23);
		bt12AMao.TabIndex = 197;
		bt12AMao.Text = "bt12AMao";
		bt12AMao.UseVisualStyleBackColor = true;
		GroupBox13.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox13.Controls.Add(dgReguaMascara);
		GroupBox13.Location = new Point(370, 403);
		GroupBox13.Name = "GroupBox13";
		GroupBox13.Size = new Size(83, 47);
		GroupBox13.TabIndex = 198;
		GroupBox13.TabStop = false;
		GroupBox13.Text = "GroupBox13";
		dgReguaMascara.AllowUserToAddRows = false;
		dgReguaMascara.AllowUserToDeleteRows = false;
		dgReguaMascara.AllowUserToResizeRows = false;
		dgReguaMascara.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgReguaMascara.BackgroundColor = Color.White;
		dgReguaMascara.BorderStyle = BorderStyle.Fixed3D;
		dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle12.BackColor = SystemColors.Control;
		dataGridViewCellStyle12.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle12.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
		dgReguaMascara.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
		dgReguaMascara.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgReguaMascara.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgReguaMascara.Location = new Point(3, 17);
		dgReguaMascara.Name = "dgReguaMascara";
		dgReguaMascara.ReadOnly = true;
		dgReguaMascara.RowHeadersVisible = false;
		dgReguaMascara.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgReguaMascara.Size = new Size(77, 18);
		dgReguaMascara.TabIndex = 201;
		bt13ReguaMascara.Location = new Point(297, 64);
		bt13ReguaMascara.Name = "bt13ReguaMascara";
		bt13ReguaMascara.Size = new Size(115, 23);
		bt13ReguaMascara.TabIndex = 199;
		bt13ReguaMascara.Text = "bt13ReguaMascara";
		bt13ReguaMascara.UseVisualStyleBackColor = true;
		GroupBox14.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox14.Controls.Add(BTCorrigaPortasDiscrepantes);
		GroupBox14.Controls.Add(dgPortasDiscrepantes);
		GroupBox14.Location = new Point(458, 242);
		GroupBox14.Name = "GroupBox14";
		GroupBox14.Size = new Size(83, 85);
		GroupBox14.TabIndex = 201;
		GroupBox14.TabStop = false;
		GroupBox14.Text = "GroupBox14";
		BTCorrigaPortasDiscrepantes.Anchor = AnchorStyles.Bottom;
		BTCorrigaPortasDiscrepantes.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		BTCorrigaPortasDiscrepantes.ForeColor = Color.Red;
		BTCorrigaPortasDiscrepantes.Location = new Point(-18, 42);
		BTCorrigaPortasDiscrepantes.Name = "BTCorrigaPortasDiscrepantes";
		BTCorrigaPortasDiscrepantes.Size = new Size(116, 35);
		BTCorrigaPortasDiscrepantes.TabIndex = 223;
		BTCorrigaPortasDiscrepantes.Text = "Corrigir";
		BTCorrigaPortasDiscrepantes.UseVisualStyleBackColor = true;
		dgPortasDiscrepantes.AllowUserToAddRows = false;
		dgPortasDiscrepantes.AllowUserToDeleteRows = false;
		dgPortasDiscrepantes.AllowUserToResizeRows = false;
		dgPortasDiscrepantes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgPortasDiscrepantes.BackgroundColor = Color.White;
		dgPortasDiscrepantes.BorderStyle = BorderStyle.Fixed3D;
		dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle13.BackColor = SystemColors.Control;
		dataGridViewCellStyle13.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle13.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle13.WrapMode = DataGridViewTriState.True;
		dgPortasDiscrepantes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
		dgPortasDiscrepantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgPortasDiscrepantes.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgPortasDiscrepantes.Location = new Point(3, 18);
		dgPortasDiscrepantes.Name = "dgPortasDiscrepantes";
		dgPortasDiscrepantes.ReadOnly = true;
		dgPortasDiscrepantes.RowHeadersVisible = false;
		dgPortasDiscrepantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgPortasDiscrepantes.Size = new Size(77, 18);
		dgPortasDiscrepantes.TabIndex = 200;
		bt14PortasDiscrepantes.Location = new Point(415, 90);
		bt14PortasDiscrepantes.Name = "bt14PortasDiscrepantes";
		bt14PortasDiscrepantes.Size = new Size(115, 23);
		bt14PortasDiscrepantes.TabIndex = 202;
		bt14PortasDiscrepantes.Text = "bt14Discrepantes";
		bt14PortasDiscrepantes.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(534, 490);
		Controls.Add(bt14PortasDiscrepantes);
		Controls.Add(GroupBox14);
		Controls.Add(bt13ReguaMascara);
		Controls.Add(GroupBox13);
		Controls.Add(GroupBox12);
		Controls.Add(bt12AMao);
		Controls.Add(GroupBox11);
		Controls.Add(bt11Paineis);
		Controls.Add(bt10BornesLM);
		Controls.Add(GroupBox10);
		Controls.Add(GroupBox4);
		Controls.Add(GroupBox3);
		Controls.Add(GroupBox2);
		Controls.Add(bt5Terminais);
		Controls.Add(GroupBox9);
		Controls.Add(bt9Discrepantes);
		Controls.Add(GroupBox6);
		Controls.Add(bt2Orfao);
		Controls.Add(GroupBox7);
		Controls.Add(bt3Principal);
		Controls.Add(GroupBox8);
		Controls.Add(bt7Reguas);
		Controls.Add(GroupBox5);
		Controls.Add(bt8intervalos);
		Controls.Add(bt1Fiacao);
		Controls.Add(bt4Auxiliar);
		Controls.Add(bt6Portas);
		Controls.Add(GroupBox1);
		Controls.Add(GroupBoxFiacao);
		Controls.Add(dgEquip);
		Controls.Add(btAtualizar);
		Controls.Add(GBEX);
		MaximumSize = new Size(550, 1000);
		MinimumSize = new Size(550, 500);
		Name = "frmVerificadorProjetoFiacao";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Verificador Projeto";
		GroupBoxFiacao.ResumeLayout(performLayout: false);
		((ISupportInitialize)dgAuxiliar).EndInit();
		((ISupportInitialize)dgPrincipal).EndInit();
		((ISupportInitialize)dgFiacaoOrfao).EndInit();
		((ISupportInitialize)dgBornes).EndInit();
		((ISupportInitialize)dgTerminais).EndInit();
		((ISupportInitialize)dgBornesEditados).EndInit();
		((ISupportInitialize)dgReguasSemUso).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		((ISupportInitialize)dgPrincipalPotenciais).EndInit();
		GroupBox12.ResumeLayout(performLayout: false);
		((ISupportInitialize)dgAMao).EndInit();
		GroupBox11.ResumeLayout(performLayout: false);
		((ISupportInitialize)dgPainelApagado).EndInit();
		GroupBox10.ResumeLayout(performLayout: false);
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox4.ResumeLayout(performLayout: false);
		GroupBox5.ResumeLayout(performLayout: false);
		GroupBox8.ResumeLayout(performLayout: false);
		GroupBox7.ResumeLayout(performLayout: false);
		GroupBox6.ResumeLayout(performLayout: false);
		GroupBox9.ResumeLayout(performLayout: false);
		GroupBox13.ResumeLayout(performLayout: false);
		((ISupportInitialize)dgReguaMascara).EndInit();
		GroupBox14.ResumeLayout(performLayout: false);
		((ISupportInitialize)dgPortasDiscrepantes).EndInit();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return CNLKMunBec;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		CNLKMunBec = WithEventsValue;
	}

	public frmVerificadorProjetoFiacao()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		FormClosed += [SpecialName] [DebuggerHidden] (object a0, FormClosedEventArgs a1) =>
		{
			Finalize();
		};
		Resize += Pu5crHWVBb;
		Gjlexvcpwe = new ColorDialog();
		bLMeM4ViM0 = new DataGridViewCellStyle();
		xXZeOAvJAT = new DataGridViewCellStyle();
		y1geIJmXHd = false;
		Doje7509aG = false;
		Cnbeqqq0yD = new List<string>();
		cOWeaBRTRB = new List<string>();
		NYCe8hPSTs = new List<string>();
		try
		{
			if (Geral.ExisteForm("frmVerificadorProjetoFiacao"))
			{
				return;
			}
			c1Hc2nQSEw();
			DeclaracoesGeral._uscPagina.Quantidade = 6;
			DeclaracoesGeral._uscPagina.pbIniciar();
			string sTipo = "";
			clsBlocos.ApagaERROS(ref sTipo);
			DeclaracoesGeral._uscPagina.pbPasso();
			clsDispositivoAuxiliares.SincronizaContatos(0, bMarcaErros: false);
			DeclaracoesGeral._uscPagina.pbPasso();
			clsPortas.SincronizaPortas(bMarcaErros: false, bProgress: false);
			DeclaracoesGeral._uscPagina.pbPasso();
			clsBlocos.VerificaDuplicados(ref jhleNuAtKc, bProgress: false);
			DeclaracoesGeral._uscPagina.pbPasso();
			bnDebnRZuM = 3;
			cDadosAccess.carregaDadosDWG();
			rDdevXNNtA = new ClsVerificadorProjetoFiacao._StructureConexao[1];
			c4Le6sxa5V = new DeclaracoesEntidades.StructureBorne[1];
			G78etxbxf6 = new ClsVerificadorProjetoFiacao._StructureAnalisePorta[1];
			zvRejlppGf = new ClsVerificadorProjetoFiacao._StructuremDispositivo[1];
			A94eLhaDqZ = new ClsVerificadorProjetoFiacao._StructuremAuxiliar[1];
			ClsVerificadorProjetoFiacao.buscaPaineisDoDG(ref Cnbeqqq0yD, ref NYCe8hPSTs);
			Declaracoes2.StructureModeloDeReguas[] mModelo = new Declaracoes2.StructureModeloDeReguas[1];
			DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
			int num = Information.UBound(mModelo);
			for (int num2 = 1; num2 <= num; num2 = checked(num2 + 1))
			{
				if (!Cnbeqqq0yD.Contains(Conversions.ToString(mModelo[num2].indexPainel)))
				{
					Cnbeqqq0yD.Add(Conversions.ToString(mModelo[num2].indexPainel));
				}
			}
			DeclaracoesGeral._uscPagina.pbPasso();
			CarregarPaineisDg();
			GroupBoxFiacao.Enabled = true;
			if (Information.UBound(rDdevXNNtA) == 0)
			{
				GroupBoxFiacao.Enabled = false;
			}
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1637]);
			GroupBoxFiacao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 559]);
			GroupBox2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 625]);
			GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 901]);
			GroupBox4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1628]);
			GroupBox5.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 631]);
			GroupBox6.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1565]);
			GroupBox7.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1563]);
			GroupBox8.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1629]);
			GroupBox9.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1635]);
			GroupBox10.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1564]);
			GroupBox11.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1671]);
			GroupBox12.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1111]);
			GroupBox13.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1709]);
			GroupBox14.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1958]);
			bt1Fiacao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 559]);
			bt3Principal.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1631]);
			bt4Auxiliar.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1632]);
			bt2Orfao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1633]);
			bt5Terminais.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 631]);
			bt6Portas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1648]);
			bt7Reguas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1649]);
			bt8intervalos.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1634]);
			bt9Discrepantes.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1635]);
			bt10BornesLM.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1651]);
			bt11Paineis.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1671]);
			bt12AMao.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1111]);
			bt13ReguaMascara.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1708]);
			bt14PortasDiscrepantes.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1958]);
			bt1Fiacao.Enabled = false;
			bt3Principal.Enabled = false;
			bt4Auxiliar.Enabled = false;
			bt2Orfao.Enabled = false;
			bt5Terminais.Enabled = false;
			bt7Reguas.Enabled = false;
			bt8intervalos.Enabled = false;
			bt6Portas.Enabled = false;
			bt9Discrepantes.Enabled = false;
			bt10BornesLM.Enabled = false;
			bt11Paineis.Enabled = false;
			bt12AMao.Enabled = false;
			bt13ReguaMascara.Enabled = false;
			bt14PortasDiscrepantes.Enabled = false;
			w8dpBZ0kvSD().SetToolTip(btCorDoErroF, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1562]));
			GBEX.Visible = false;
			Application.ShowModelessDialog((Form)this);
			DeclaracoesGeral._uscPagina.pbPasso();
			GroupBox2.Location = GBEX.Location;
			GroupBox3.Location = GBEX.Location;
			GroupBox4.Location = GBEX.Location;
			GroupBox5.Location = GBEX.Location;
			GroupBox8.Location = GBEX.Location;
			GroupBox7.Location = GBEX.Location;
			GroupBox6.Location = GBEX.Location;
			GroupBox9.Location = GBEX.Location;
			GroupBox10.Location = GBEX.Location;
			GroupBox11.Location = GBEX.Location;
			GroupBox12.Location = GBEX.Location;
			GroupBox13.Location = GBEX.Location;
			GroupBox14.Location = GBEX.Location;
			GroupBox2.Size = GBEX.Size;
			GroupBox3.Size = GBEX.Size;
			GroupBox4.Size = GBEX.Size;
			GroupBox5.Size = GBEX.Size;
			GroupBox8.Size = GBEX.Size;
			GroupBox7.Size = GBEX.Size;
			GroupBox6.Size = GBEX.Size;
			GroupBox9.Size = GBEX.Size;
			GroupBox10.Size = GBEX.Size;
			GroupBox11.Size = GBEX.Size;
			GroupBox12.Size = GBEX.Size;
			GroupBox13.Size = GBEX.Size;
			GroupBox14.Size = GBEX.Size;
			GroupBox2.Visible = false;
			GroupBox3.Visible = false;
			GroupBox4.Visible = false;
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
			Correcao.ApagaXDataTerceiros();
			DeclaracoesGeral._uscPagina.pbFim();
			bLMeM4ViM0.BackColor = Color.LightCoral;
			xXZeOAvJAT.BackColor = Color.LightGray;
			TreeView1.Nodes.Clear();
			if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
			{
				Left = 0;
			}
			Doje7509aG = true;
			MZsc9Auv63();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void G39c3be3rW(object P_0, EventArgs P_1)
	{
		DialogResult dialogResult = Gjlexvcpwe.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			bnDebnRZuM = Gjlexvcpwe.Color.ColorIndex;
			btCorDoErroF.BackColor = Gjlexvcpwe.Color.ColorValue;
		}
	}

	public void CarregaErros(ClsVerificadorProjetoFiacao._StructureConexao[] mErros, string sRel)
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
						ClsVerificadorProjetoFiacao._StructureConexao structureConexao = mErros[j + 1];
						mErros[j + 1] = mErros[j];
						mErros[j] = structureConexao;
					}
				}
			}
		}
	}

	~frmVerificadorProjetoFiacao()
	{
		clsBlocos.Unhighlight();
		if (!Information.IsNothing(rDdevXNNtA))
		{
			ClsVerificadorProjetoFiacao.PintaFiacao(ref rDdevXNNtA);
		}
	}

	private void WnWcnJUkps(object P_0, EventArgs P_1)
	{
		ClsVerificadorProjetoFiacao.PintaFiacao(ref rDdevXNNtA, bnDebnRZuM);
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
	}

	private void UH6c1lkAM9(object P_0, EventArgs P_1)
	{
		ClsVerificadorProjetoFiacao.PintaFiacao(ref rDdevXNNtA);
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
	}

	private void v0WcllwgoK()
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
				if (!cOWeaBRTRB.Contains(Conversions.ToString(num)))
				{
					continue;
				}
				array = new DeclaracoesEntidades.StructureBorne[1];
				int num3 = Information.UBound(c4Le6sxa5V);
				for (int j = 0; j <= num3; j++)
				{
					if (c4Le6sxa5V[j].IndiceRegua == mModelo[i].indexRegua)
					{
						int num4 = Information.UBound(array) + 1;
						array = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(array, new DeclaracoesEntidades.StructureBorne[num4 + 1]);
						array[num4] = c4Le6sxa5V[j];
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

	private void nXnc5R08lF()
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
				if (!cOWeaBRTRB.Contains(Conversions.ToString(num)))
				{
					continue;
				}
				array2 = new DeclaracoesEntidades.StructureBorne[1];
				int num3 = Information.UBound(c4Le6sxa5V);
				for (int j = 0; j <= num3; j++)
				{
					if (c4Le6sxa5V[j].IndiceRegua == mModelo[i].indexRegua)
					{
						int num4 = Information.UBound(array2) + 1;
						array2 = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(array2, new DeclaracoesEntidades.StructureBorne[num4 + 1]);
						array2[num4] = c4Le6sxa5V[j];
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

	private void QU5c0lgjBd()
	{
		formatadgBornesEditados();
		checked
		{
			if (Information.UBound(c4Le6sxa5V) >= 2)
			{
				int num = Information.UBound(c4Le6sxa5V);
				for (int i = 1; i <= num; i++)
				{
					int num2 = Information.UBound(c4Le6sxa5V) - 1;
					int num3 = i;
					for (int j = num2; j >= num3; j += -1)
					{
						if (c4Le6sxa5V[j].indexPainel > c4Le6sxa5V[j + 1].indexPainel)
						{
							DeclaracoesEntidades.StructureBorne structureBorne = c4Le6sxa5V[j + 1];
							c4Le6sxa5V[j + 1] = c4Le6sxa5V[j];
							c4Le6sxa5V[j] = structureBorne;
						}
						if (c4Le6sxa5V[j].indexPainel == c4Le6sxa5V[j + 1].indexPainel && c4Le6sxa5V[j].IndiceRegua > c4Le6sxa5V[j + 1].IndiceRegua)
						{
							DeclaracoesEntidades.StructureBorne structureBorne = c4Le6sxa5V[j + 1];
							c4Le6sxa5V[j + 1] = c4Le6sxa5V[j];
							c4Le6sxa5V[j] = structureBorne;
						}
						if (c4Le6sxa5V[j].indexPainel == c4Le6sxa5V[j + 1].indexPainel && c4Le6sxa5V[j].IndiceRegua == c4Le6sxa5V[j + 1].IndiceRegua && c4Le6sxa5V[j].Ordem > c4Le6sxa5V[j + 1].Ordem)
						{
							DeclaracoesEntidades.StructureBorne structureBorne = c4Le6sxa5V[j + 1];
							c4Le6sxa5V[j + 1] = c4Le6sxa5V[j];
							c4Le6sxa5V[j] = structureBorne;
						}
					}
				}
			}
			int num4 = Information.UBound(c4Le6sxa5V);
			for (int k = 0; k <= num4; k++)
			{
				if (Operators.CompareString(clsTextos.TiraNothing(c4Le6sxa5V[k].NumeroComplem), "", TextCompare: true) != 0)
				{
					dgBornesEditados.Rows.Add(c4Le6sxa5V[k].NomePainel, c4Le6sxa5V[k].NomeRegua, c4Le6sxa5V[k].Numero, c4Le6sxa5V[k].NumeroComplem, c4Le6sxa5V[k].Handle);
				}
			}
			AtualizaBornesErro();
		}
	}

	private void GijcRTCGe3()
	{
		ClsVerificadorProjetoFiacao._StructurERROBorne[] array = new ClsVerificadorProjetoFiacao._StructurERROBorne[1];
		int num = Information.UBound(c4Le6sxa5V);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				if (c4Le6sxa5V[i].lm == 0)
				{
					int num2 = Information.UBound(array) + 1;
					array = (ClsVerificadorProjetoFiacao._StructurERROBorne[])Utils.CopyArray(array, new ClsVerificadorProjetoFiacao._StructurERROBorne[num2 + 1]);
					array[num2].iPn = c4Le6sxa5V[i].indexPainel;
					array[num2].sPn = c4Le6sxa5V[i].NomePainel;
					array[num2].sRegua = c4Le6sxa5V[i].NomeRegua;
					array[num2].sErro = c4Le6sxa5V[i].Numero;
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

	private void yBNcmOtuQS()
	{
		ClsVerificadorProjetoFiacao._errosPorta[] array = null;
		int num = 0;
		array = new ClsVerificadorProjetoFiacao._errosPorta[1];
		ClsVerificadorProjetoFiacao._errosPorta[] array2 = null;
		int num2 = 0;
		array2 = new ClsVerificadorProjetoFiacao._errosPorta[1];
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		int num3 = Information.UBound(G78etxbxf6);
		checked
		{
			for (int i = 0; i <= num3; i++)
			{
				if ((Operators.CompareString(clsTextos.TiraNothing(G78etxbxf6[i].sTermM), "", TextCompare: true) != 0) | (Operators.CompareString(clsTextos.TiraNothing(G78etxbxf6[i].sTerm), "", TextCompare: true) != 0))
				{
					num++;
					array = (ClsVerificadorProjetoFiacao._errosPorta[])Utils.CopyArray(array, new ClsVerificadorProjetoFiacao._errosPorta[num + 1]);
					array[num].iIndiceMascara = G78etxbxf6[i].indexMascara;
					array[num].iIndicePorta = G78etxbxf6[i].indexPorta;
					array[num].sEfc = G78etxbxf6[i].sEFC;
					array[num].sRegua = G78etxbxf6[i].sRegua;
					array[num].sTerBorne = clsTextos.TiraNothing(G78etxbxf6[i].sTerm);
					array[num].sNome = G78etxbxf6[i].sNomeMascara;
					array[num].sIndefinido = clsTextos.TiraNothing(G78etxbxf6[i].sTerm);
					array[num].sDuplicado = "";
					array[num].sHandle = G78etxbxf6[i].sHandle;
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
				if (!((Operators.CompareString(clsTextos.TiraNothing(G78etxbxf6[i].sattB), "", TextCompare: true) != 0) | (Operators.CompareString(clsTextos.TiraNothing(G78etxbxf6[i].sBorn), "", TextCompare: true) != 0)))
				{
					continue;
				}
				num2++;
				array2 = (ClsVerificadorProjetoFiacao._errosPorta[])Utils.CopyArray(array2, new ClsVerificadorProjetoFiacao._errosPorta[num2 + 1]);
				array2[num2].iIndiceMascara = G78etxbxf6[i].indexMascara;
				array2[num2].iIndicePorta = G78etxbxf6[i].indexPorta;
				array2[num2].sEfc = G78etxbxf6[i].sEFC;
				array2[num2].sRegua = G78etxbxf6[i].sRegua;
				array2[num2].sTerBorne = clsTextos.TiraNothing(G78etxbxf6[i].sBorn);
				array2[num2].sNome = G78etxbxf6[i].sNomeMascara;
				array2[num2].sIndefinido = clsTextos.TiraNothing(G78etxbxf6[i].sBorn);
				array2[num2].sDuplicado = "";
				array2[num2].sHandle = G78etxbxf6[i].sHandle;
				string[] array4 = array2[num2].sTerBorne.Split(',');
				List<string> lTerminais = new List<string>();
				Geral.DivideTerminais(ref lTerminais, array2[num2].sRegua, bRepete: true);
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
				if (Operators.CompareString(left3, DeclaracoesGeral.Conf.CaracterTerminalIndefinido.Trim(), TextCompare: true) != 0)
				{
					continue;
				}
				if (Operators.CompareString(left, "", TextCompare: true) == 0)
				{
					dgTerminais.Rows.Add(DeclaracoesGeral.mMensagem[1, 1492].ToString().ToUpper(), "", "", "");
					left = DeclaracoesGeral.mMensagem[1, 1492].ToString().ToUpper();
					int num7 = 0;
					do
					{
						dgTerminais.Rows[dgTerminais.RowCount - 1].Cells[num7].Style = xXZeOAvJAT;
						num7++;
					}
					while (num7 <= 3);
					dgTerminais.Rows[dgTerminais.Rows.Count - 1].Cells[0].Style.Font = new Font("Arial", 10f, FontStyle.Bold);
				}
				dgTerminais.Rows.Add(array[l].sNome, array[l].sEfc, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, array[l].sHandle);
				dgTerminais.Rows[dgTerminais.RowCount - 1].Cells[2].Style = bLMeM4ViM0;
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
						dgTerminais.Rows[dgTerminais.RowCount - 1].Cells[num9].Style = xXZeOAvJAT;
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
				if (Operators.CompareString(left6, DeclaracoesGeral.Conf.CaracterTerminalIndefinido.Trim(), TextCompare: true) != 0)
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
						dgBornes.Rows[dgBornes.RowCount - 1].Cells[num11].Style = xXZeOAvJAT;
						num11++;
					}
					while (num11 <= 3);
					dgBornes.Rows[dgBornes.Rows.Count - 1].Cells[0].Style.Font = new Font("Arial", 10f, FontStyle.Bold);
				}
				dgBornes.Rows.Add(array2[n].sNome, array2[n].sEfc, DeclaracoesGeral.Conf.CaracterTerminalIndefinido, array2[n].sHandle);
				dgBornes.Rows[dgBornes.RowCount - 1].Cells[2].Style = bLMeM4ViM0;
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
						dgBornes.Rows[dgBornes.RowCount - 1].Cells[num14].Style = xXZeOAvJAT;
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

	private void MbycXLEWI4()
	{
		y1geIJmXHd = false;
		List<string> list = new List<string>();
		string text = "";
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		int num = Information.UBound(zvRejlppGf);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				string text2 = zvRejlppGf[i].sTerminais;
				if (Operators.CompareString(DeclaracoesGeral.Conf.CaracterTerminalIndefinido.Trim(), "", TextCompare: true) != 0)
				{
					text2 = zvRejlppGf[i].sTerminais.Replace(DeclaracoesGeral.Conf.CaracterTerminalIndefinido, "");
				}
				text2 = text2.Replace(" ", "");
				string right = zvRejlppGf[i].sTerminais.Replace(" ", "");
				if (Operators.CompareString(text2, right, TextCompare: true) != 0 && !list2.Contains(zvRejlppGf[i].Handle))
				{
					list2.Add(zvRejlppGf[i].Handle);
				}
				if (zvRejlppGf[i].iLM1 == 0 && zvRejlppGf[i].iLM2 == 0 && !list3.Contains(zvRejlppGf[i].Handle))
				{
					list2.Add(zvRejlppGf[i].Handle);
				}
			}
			formatadgPrincipal();
			new List<string>();
			bool flag = false;
			foreach (string item in list2)
			{
				int num2 = Information.UBound(zvRejlppGf);
				for (int j = 0; j <= num2; j++)
				{
					if (Operators.CompareString(item, zvRejlppGf[j].Handle, TextCompare: true) != 0)
					{
						continue;
					}
					text = Dicionario.BuscaNomeDoPainel(zvRejlppGf[j].Painel);
					string text3 = zvRejlppGf[j].Nome1;
					if (Operators.CompareString(zvRejlppGf[j].Nome2, "", TextCompare: true) != 0)
					{
						text3 = zvRejlppGf[j].Nome1 + "/" + zvRejlppGf[j].Nome2;
					}
					if (!list.Contains(zvRejlppGf[j].Handle))
					{
						string right2 = zvRejlppGf[j].sTerminais;
						if (Operators.CompareString(DeclaracoesGeral.Conf.CaracterTerminalIndefinido.Trim(), "", TextCompare: true) != 0)
						{
							right2 = zvRejlppGf[j].sTerminais.Replace(DeclaracoesGeral.Conf.CaracterTerminalIndefinido, "");
						}
						if (((Operators.CompareString(zvRejlppGf[j].sTerminais, right2, TextCompare: true) != 0) | (zvRejlppGf[j].iLM1 == 0)) && !list.Contains(zvRejlppGf[j].Handle))
						{
							dgPrincipal.Rows.Add(text, text3, zvRejlppGf[j].iLM1, zvRejlppGf[j].sTerminais, zvRejlppGf[j].Handle);
							if (!flag)
							{
								dgPrincipal.FirstDisplayedScrollingRowIndex = dgPrincipal.RowCount - 1;
								flag = true;
							}
							if (zvRejlppGf[j].iLM1 == 0)
							{
								dgPrincipal.Rows[dgPrincipal.RowCount - 1].Cells[2].Style = bLMeM4ViM0;
							}
							if (Operators.CompareString(zvRejlppGf[j].sTerminais, right2, TextCompare: true) != 0)
							{
								dgPrincipal.Rows[dgPrincipal.RowCount - 1].Cells[3].Style = bLMeM4ViM0;
							}
							list.Add(zvRejlppGf[j].Handle);
						}
					}
					if (!flag && dgPrincipal.RowCount > 0)
					{
						dgPrincipal.FirstDisplayedScrollingRowIndex = dgPrincipal.RowCount - 1;
						flag = true;
					}
				}
			}
			AtualizaPrincipal();
		}
	}

	private void XSScUGxu4K()
	{
		List<string> list = new List<string>();
		string text = "";
		y1geIJmXHd = false;
		int num = Information.UBound(A94eLhaDqZ);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				string right = A94eLhaDqZ[i].sTerminais;
				if (Operators.CompareString(DeclaracoesGeral.Conf.CaracterTerminalIndefinido.Trim(), "", TextCompare: true) != 0)
				{
					right = A94eLhaDqZ[i].sTerminais.Replace(DeclaracoesGeral.Conf.CaracterTerminalIndefinido, "");
				}
				if (Operators.CompareString(A94eLhaDqZ[i].sTerminais, right, TextCompare: true) != 0 && !list.Contains(A94eLhaDqZ[i].HandleBob))
				{
					list.Add(A94eLhaDqZ[i].HandleBob);
				}
				if (Operators.CompareString(A94eLhaDqZ[i].sTerminais, A94eLhaDqZ[i].sTerminaisMod, TextCompare: true) != 0 && !list.Contains(A94eLhaDqZ[i].HandleBob))
				{
					list.Add(A94eLhaDqZ[i].HandleBob);
				}
			}
			dgAuxiliar.Rows.Clear();
			dgAuxiliar.Columns.Clear();
			dgAuxiliar.Columns.Add("Painel", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1081]));
			dgAuxiliar.Columns.Add("Nome", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 987]));
			dgAuxiliar.Columns.Add("T1", "T1");
			dgAuxiliar.Columns.Add("T2", "T2");
			dgAuxiliar.Columns.Add("T3", "T3");
			dgAuxiliar.Columns.Add("Tipo", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 660]));
			dgAuxiliar.Columns.Add("Handle", "Handle");
			foreach (string item in list)
			{
				int num2 = Information.UBound(zvRejlppGf);
				for (int j = 0; j <= num2; j++)
				{
					if (Operators.CompareString(item, zvRejlppGf[j].Handle, TextCompare: true) != 0)
					{
						continue;
					}
					text = Dicionario.BuscaNomeDoPainel(zvRejlppGf[j].Painel);
					string text2 = zvRejlppGf[j].Nome1;
					if (Operators.CompareString(zvRejlppGf[j].Nome2, "", TextCompare: true) != 0)
					{
						text2 = zvRejlppGf[j].Nome1 + "/" + zvRejlppGf[j].Nome2;
					}
					int num3 = Information.UBound(A94eLhaDqZ);
					for (int k = 1; k <= num3; k++)
					{
						if (Operators.CompareString(A94eLhaDqZ[k].HandleBob, item, TextCompare: true) != 0)
						{
							continue;
						}
						string[] array = A94eLhaDqZ[k].sTerminais.Split(',');
						string text3 = "";
						if (Information.UBound(array) >= 0)
						{
							text3 = array[0].Trim();
						}
						string text4 = "";
						if (Information.UBound(array) >= 1)
						{
							text4 = array[1].Trim();
						}
						string text5 = "";
						if (Information.UBound(array) >= 2)
						{
							text5 = array[2].Trim();
						}
						string[] array2 = A94eLhaDqZ[k].sTerminaisMod.Split(',');
						string text6 = "";
						if (Information.UBound(array2) >= 0)
						{
							text6 = array2[0].Trim();
						}
						string text7 = "";
						if (Information.UBound(array2) >= 1)
						{
							text7 = array2[1].Trim();
						}
						string text8 = "";
						if (Information.UBound(array2) >= 2)
						{
							text8 = array2[2].Trim();
						}
						string text9 = "";
						switch (A94eLhaDqZ[k].TipoDoContato)
						{
						case 3:
							text9 = "RV";
							break;
						case 1:
							text9 = "NA";
							break;
						case 2:
							text9 = "NF";
							break;
						}
						if (Operators.CompareString(text9, "NA", TextCompare: true) != 0)
						{
							if (Operators.CompareString(text9, "NF", TextCompare: true) != 0)
							{
								if (Operators.CompareString(text9, "RV", TextCompare: true) != 0)
								{
									continue;
								}
								string tipoBlocoUsado = A94eLhaDqZ[k].TipoBlocoUsado;
								if (Operators.CompareString(tipoBlocoUsado, "NA", TextCompare: true) != 0)
								{
									if (Operators.CompareString(tipoBlocoUsado, "NF", TextCompare: true) != 0)
									{
										if (Operators.CompareString(tipoBlocoUsado, "RV", TextCompare: true) == 0 && !((Operators.CompareString(text3, text6, TextCompare: true) == 0) & (Operators.CompareString(text4, text7, TextCompare: true) == 0) & (Operators.CompareString(text5, text8, TextCompare: true) == 0)))
										{
											dgAuxiliar.Rows.Add(text, text2, text3, text4, text5, text9, A94eLhaDqZ[k].Handle);
											if (Operators.CompareString(text3, text6, TextCompare: true) != 0)
											{
												dgAuxiliar.Rows[dgAuxiliar.RowCount - 1].Cells[2].Style = bLMeM4ViM0;
												dgAuxiliar[2, dgAuxiliar.RowCount - 1].ErrorText = "    " + text6;
											}
											if (Operators.CompareString(text4, text7, TextCompare: true) != 0)
											{
												dgAuxiliar.Rows[dgAuxiliar.RowCount - 1].Cells[3].Style = bLMeM4ViM0;
												dgAuxiliar[3, dgAuxiliar.RowCount - 1].ErrorText = "    " + text7;
											}
											if (Operators.CompareString(text5, text8, TextCompare: true) != 0)
											{
												dgAuxiliar.Rows[dgAuxiliar.RowCount - 1].Cells[4].Style = bLMeM4ViM0;
												dgAuxiliar[4, dgAuxiliar.RowCount - 1].ErrorText = "    " + text8;
											}
											y1geIJmXHd = true;
										}
									}
									else if (!((Operators.CompareString(text3, text6, TextCompare: true) == 0) & (Operators.CompareString(text4, text7, TextCompare: true) == 0)))
									{
										dgAuxiliar.Rows.Add(text, text2, text3, text4, text5, text9, A94eLhaDqZ[k].Handle);
										if (Operators.CompareString(text3, text6, TextCompare: true) != 0)
										{
											dgAuxiliar.Rows[dgAuxiliar.RowCount - 1].Cells[2].Style = bLMeM4ViM0;
											dgAuxiliar[2, dgAuxiliar.RowCount - 1].ErrorText = "    " + text6;
										}
										if (Operators.CompareString(text4, text7, TextCompare: true) != 0)
										{
											dgAuxiliar.Rows[dgAuxiliar.RowCount - 1].Cells[3].Style = bLMeM4ViM0;
											dgAuxiliar[3, dgAuxiliar.RowCount - 1].ErrorText = "    " + text7;
										}
										y1geIJmXHd = true;
									}
								}
								else if (!((Operators.CompareString(text3, text6, TextCompare: true) == 0) & (Operators.CompareString(text4, text8, TextCompare: true) == 0)))
								{
									dgAuxiliar.Rows.Add(text, text2, text3, text4, text5, text9, A94eLhaDqZ[k].Handle);
									if (Operators.CompareString(text3, text6, TextCompare: true) != 0)
									{
										dgAuxiliar.Rows[dgAuxiliar.RowCount - 1].Cells[2].Style = bLMeM4ViM0;
										dgAuxiliar[2, dgAuxiliar.RowCount - 1].ErrorText = "    " + text6;
									}
									if (Operators.CompareString(text4, text8, TextCompare: true) != 0)
									{
										dgAuxiliar.Rows[dgAuxiliar.RowCount - 1].Cells[3].Style = bLMeM4ViM0;
										dgAuxiliar[3, dgAuxiliar.RowCount - 1].ErrorText = "    " + text8;
									}
									y1geIJmXHd = true;
								}
							}
							else if (Operators.CompareString(A94eLhaDqZ[k].TipoBlocoUsado, "NF", TextCompare: true) == 0 && !((Operators.CompareString(text3, text6, TextCompare: true) == 0) & (Operators.CompareString(text4, text7, TextCompare: true) == 0) & (Operators.CompareString(text5, "", TextCompare: true) == 0)))
							{
								dgAuxiliar.Rows.Add(text, text2, text3, text4, text5, text9, A94eLhaDqZ[k].Handle);
								if (Operators.CompareString(text3, text6, TextCompare: true) != 0)
								{
									dgAuxiliar.Rows[dgAuxiliar.RowCount - 1].Cells[2].Style = bLMeM4ViM0;
									dgAuxiliar[2, dgAuxiliar.RowCount - 1].ErrorText = "    " + text6;
								}
								if (Operators.CompareString(text4, text7, TextCompare: true) != 0)
								{
									dgAuxiliar.Rows[dgAuxiliar.RowCount - 1].Cells[3].Style = bLMeM4ViM0;
									dgAuxiliar[3, dgAuxiliar.RowCount - 1].ErrorText = "    " + text7;
								}
								if (Operators.CompareString(text5, text8, TextCompare: true) != 0)
								{
									dgAuxiliar.Rows[dgAuxiliar.RowCount - 1].Cells[4].Style = bLMeM4ViM0;
									dgAuxiliar[4, dgAuxiliar.RowCount - 1].ErrorText = "    " + text8;
								}
								y1geIJmXHd = true;
							}
						}
						else if (Operators.CompareString(A94eLhaDqZ[k].TipoBlocoUsado, "NA", TextCompare: true) == 0 && !((Operators.CompareString(text3, text6, TextCompare: true) == 0) & (Operators.CompareString(text4, text7, TextCompare: true) == 0) & (Operators.CompareString(text5, "", TextCompare: true) == 0)))
						{
							dgAuxiliar.Rows.Add(text, text2, text3, text4, text5, text9, A94eLhaDqZ[k].Handle);
							if (Operators.CompareString(text3, text6, TextCompare: true) != 0)
							{
								dgAuxiliar.Rows[dgAuxiliar.RowCount - 1].Cells[2].Style = bLMeM4ViM0;
								dgAuxiliar[2, dgAuxiliar.RowCount - 1].ErrorText = "    " + text6;
							}
							if (Operators.CompareString(text4, text7, TextCompare: true) != 0)
							{
								dgAuxiliar.Rows[dgAuxiliar.RowCount - 1].Cells[3].Style = bLMeM4ViM0;
								dgAuxiliar[3, dgAuxiliar.RowCount - 1].ErrorText = "    " + text7;
							}
							if (Operators.CompareString(text5, text8, TextCompare: true) != 0)
							{
								dgAuxiliar.Rows[dgAuxiliar.RowCount - 1].Cells[4].Style = bLMeM4ViM0;
								dgAuxiliar[4, dgAuxiliar.RowCount - 1].ErrorText = "    " + text8;
							}
							y1geIJmXHd = true;
						}
					}
				}
			}
			AtualizaAuxiliar();
		}
	}

	private void j1ncyyZfGx()
	{
		formatadgPaineisApagados();
		int num = Information.UBound(c4Le6sxa5V);
		checked
		{
			for (int i = 0; i <= num; i++)
			{
				if (c4Le6sxa5V[i].bPnApagado)
				{
					dgPainelApagado.Rows.Add(Operators.ConcatenateObject(Conversions.ToString(c4Le6sxa5V[i].indexPainel) + " - ", DeclaracoesGeral.mMensagem[1, 1170]), c4Le6sxa5V[i].NomeRegua + c4Le6sxa5V[i].Numero, "Bornes", c4Le6sxa5V[i].Handle);
				}
			}
			int num2 = Information.UBound(G78etxbxf6);
			for (int j = 0; j <= num2; j++)
			{
				if (G78etxbxf6[j].bPnApagados)
				{
					string sNomeMascara = G78etxbxf6[j].sNomeMascara;
					sNomeMascara = sNomeMascara.Replace("???" + DeclaracoesGeral.Conf.SeparadorCruzamento, "");
					dgPainelApagado.Rows.Add(Operators.ConcatenateObject(Conversions.ToString(G78etxbxf6[j].iPn) + " - ", DeclaracoesGeral.mMensagem[1, 1170]), sNomeMascara, "Portas", G78etxbxf6[j].sHandle);
				}
			}
			int num3 = Information.UBound(zvRejlppGf);
			for (int k = 0; k <= num3; k++)
			{
				if (zvRejlppGf[k].bPnApagados)
				{
					dgPainelApagado.Rows.Add(Operators.ConcatenateObject(Conversions.ToString(zvRejlppGf[k].iPn) + " - ", DeclaracoesGeral.mMensagem[1, 1170]), zvRejlppGf[k].Nome1, "Disporitivos", zvRejlppGf[k].Handle);
				}
			}
			int num4 = Information.UBound(A94eLhaDqZ);
			for (int l = 0; l <= num4; l++)
			{
				if (A94eLhaDqZ[l].bPnApagados)
				{
					dgPainelApagado.Rows.Add(Operators.ConcatenateObject(Conversions.ToString(A94eLhaDqZ[l].iPn) + " - ", DeclaracoesGeral.mMensagem[1, 1170]), A94eLhaDqZ[l].Nome1, "Auxiliares", A94eLhaDqZ[l].Handle);
				}
			}
			int num5 = Information.UBound(rDdevXNNtA);
			for (int m = 0; m <= num5; m++)
			{
				if (rDdevXNNtA[m].bPnApagado)
				{
					string text = "Derivação";
					if (Operators.CompareString(rDdevXNNtA[m].HandleSup, "OK", TextCompare: true) == 0)
					{
						text = "Circuito";
					}
					dgPainelApagado.Rows.Add(Operators.ConcatenateObject(Conversions.ToString(rDdevXNNtA[m].iPainel) + " - ", DeclaracoesGeral.mMensagem[1, 1170]), text, "Fiação", rDdevXNNtA[m].Handle);
				}
			}
			AtualizaPaineisApagados();
		}
	}

	public void CarregaReguasDiscrepantes(Declaracoes2.MModeloDePortas[] m_PortasDiscr)
	{
		dgPortasDiscrepantes.Rows.Clear();
		dgPortasDiscrepantes.Columns.Clear();
		dgPortasDiscrepantes.Columns.Add("CABO", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 654]));
		dgPortasDiscrepantes.Columns.Add("EFC", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 264]));
		dgPortasDiscrepantes.Columns.Add("TERMINAL", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 771]));
		dgPortasDiscrepantes.Columns.Add("RÉGUA", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 984]));
		dgPortasDiscrepantes.Columns.Add("BORNE", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1429]));
		dgPortasDiscrepantes.Columns.Add("VALOR", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1923]));
		dgPortasDiscrepantes.Columns.Add("Handle", "Handle");
		int num = Information.UBound(m_PortasDiscr);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				dgPortasDiscrepantes.Rows.Add(m_PortasDiscr[i].NomeModelo, m_PortasDiscr[i].sEFC, m_PortasDiscr[i].sTerminais, m_PortasDiscr[i].sRegua, m_PortasDiscr[i].sBornes, m_PortasDiscr[i].HandleDef, m_PortasDiscr[i].HandlePorta);
				if (Operators.CompareString(m_PortasDiscr[i].sTerminais, "", TextCompare: true) != 0)
				{
					dgPortasDiscrepantes.Rows[dgPortasDiscrepantes.RowCount - 1].Cells[2].Style = bLMeM4ViM0;
				}
				if (Operators.CompareString(m_PortasDiscr[i].sRegua, "", TextCompare: true) != 0)
				{
					dgPortasDiscrepantes.Rows[dgPortasDiscrepantes.RowCount - 1].Cells[3].Style = bLMeM4ViM0;
				}
				if (Operators.CompareString(m_PortasDiscr[i].sBornes, "", TextCompare: true) != 0)
				{
					dgPortasDiscrepantes.Rows[dgPortasDiscrepantes.RowCount - 1].Cells[4].Style = bLMeM4ViM0;
				}
			}
			AtualizaDGPortasDiscrepantes();
		}
	}

	public void AtualizaDGPortasDiscrepantes()
	{
		if (dgPortasDiscrepantes.RowCount <= 0)
		{
			dgPortasDiscrepantes.Rows.Clear();
			dgPortasDiscrepantes.Columns.Clear();
			return;
		}
		checked
		{
			double num = dgPortasDiscrepantes.Width - 4;
			if (haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgPortasDiscrepantes))
			{
				num = dgPortasDiscrepantes.Width - 22;
			}
			dgPortasDiscrepantes.Columns[0].Width = (int)Math.Round(num * 0.17);
			dgPortasDiscrepantes.Columns[0].Visible = true;
			dgPortasDiscrepantes.Columns[1].Width = (int)Math.Round(num * 0.16);
			dgPortasDiscrepantes.Columns[1].Visible = true;
			dgPortasDiscrepantes.Columns[2].Width = (int)Math.Round(num * 0.16);
			dgPortasDiscrepantes.Columns[2].Visible = true;
			dgPortasDiscrepantes.Columns[3].Width = (int)Math.Round(num * 0.16);
			dgPortasDiscrepantes.Columns[3].Visible = true;
			dgPortasDiscrepantes.Columns[4].Width = (int)Math.Round(num * 0.16);
			dgPortasDiscrepantes.Columns[4].Visible = true;
			dgPortasDiscrepantes.Columns[5].Width = (int)Math.Round(num * 0.19);
			dgPortasDiscrepantes.Columns[5].Visible = true;
			dgPortasDiscrepantes.Columns[6].Width = 0;
			dgPortasDiscrepantes.Columns[6].Visible = false;
			dgPortasDiscrepantes.MultiSelect = false;
		}
	}

	private void mqVcgNjXuh()
	{
		dgAMao.Rows.Clear();
		dgAMao.Columns.Clear();
		dgAMao.Columns.Add("ERRO", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1111]));
		dgAMao.Columns.Add("Página", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 9]));
		dgAMao.Columns.Add("Handle", "Handle");
		clsBlocos.StructureErros[] array = jhleNuAtKc;
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			clsBlocos.StructureErros structureErros = array[i];
			if (Operators.CompareString(clsTextos.TiraNothing(structureErros.sTipo), "", TextCompare: true) != 0 && cOWeaBRTRB.Contains(structureErros.iPainel))
			{
				dgAMao.Rows.Add(structureErros.sTipo, structureErros.sPagina, structureErros.sHandle);
			}
		}
		AtualizaFeitoAMao();
	}

	private void AC1cAJLSDI()
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

	private void jsRcswpefk(object P_0, DataGridViewCellEventArgs P_1)
	{
		string sHandle = dgPrincipal.SelectedRows[0].Cells[4].Value.ToString();
		clsBlocos.MostraBloco(sHandle);
	}

	private void qK7cBUDocy(object P_0, DataGridViewCellEventArgs P_1)
	{
		string sHandle = dgAuxiliar.SelectedRows[0].Cells[6].Value.ToString();
		clsBlocos.MostraBloco(sHandle);
	}

	public void CarregarPaineisDg()
	{
		formataDGEquip();
		Cnbeqqq0yD.Sort();
		foreach (string item in Cnbeqqq0yD)
		{
			if (!NYCe8hPSTs.Contains(item))
			{
				dgEquip.Rows.Add(item, Dicionario.BuscaNomeDoPainel(Conversions.ToInteger(item)));
			}
		}
		AtualizaDGEquip();
	}

	public void formataDGEquip()
	{
		checked
		{
			try
			{
				dgEquip.Rows.Clear();
				dgEquip.Columns.Clear();
				dgEquip.Columns.Add("", "Indice");
				dgEquip.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 748]));
				int num = dgEquip.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgEquip.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
				dgEquip.MultiSelect = true;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			finally
			{
			}
		}
	}

	public void AtualizaDGEquip()
	{
		checked
		{
			try
			{
				if (dgEquip.RowCount <= 0)
				{
					dgEquip.Rows.Clear();
					dgEquip.Columns.Clear();
					return;
				}
				double a = dgEquip.Width - 4;
				if (haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgEquip))
				{
					a = dgEquip.Width - 22;
				}
				dgEquip.Columns[0].Width = 0;
				dgEquip.Columns[0].Visible = false;
				dgEquip.Columns[1].Width = (int)Math.Round(a);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			finally
			{
			}
		}
	}

	public void formataFiacaoOrfao()
	{
		checked
		{
			try
			{
				dgFiacaoOrfao.Rows.Clear();
				dgFiacaoOrfao.Columns.Clear();
				dgFiacaoOrfao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1081]));
				dgFiacaoOrfao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 428]));
				dgFiacaoOrfao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 9]));
				dgFiacaoOrfao.Columns.Add("", "SHANDLE");
				int num = dgFiacaoOrfao.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgFiacaoOrfao.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			finally
			{
			}
		}
	}

	public void AtualizaFiacaoOrfao()
	{
		if (dgFiacaoOrfao.RowCount <= 0)
		{
			dgFiacaoOrfao.Rows.Clear();
			dgFiacaoOrfao.Columns.Clear();
			return;
		}
		checked
		{
			double num = dgFiacaoOrfao.Width - 4;
			if (haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgFiacaoOrfao))
			{
				num = dgFiacaoOrfao.Width - 21;
			}
			dgFiacaoOrfao.Columns[0].Width = (int)Math.Round(num * 0.5);
			dgFiacaoOrfao.Columns[0].Visible = true;
			dgFiacaoOrfao.Columns[1].Width = (int)Math.Round(num * 0.25);
			dgFiacaoOrfao.Columns[1].Visible = true;
			dgFiacaoOrfao.Columns[2].Width = (int)Math.Round(num * 0.25);
			dgFiacaoOrfao.Columns[2].Visible = true;
			dgFiacaoOrfao.Columns[3].Width = 0;
			dgFiacaoOrfao.Columns[3].Visible = false;
			dgFiacaoOrfao.MultiSelect = false;
		}
	}

	public void formatadgPrincipal()
	{
		dgPrincipal.Rows.Clear();
		dgPrincipal.Columns.Clear();
		dgPrincipal.Columns.Add("Painel", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1081]));
		dgPrincipal.Columns.Add("Nome", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 987]));
		dgPrincipal.Columns.Add("LM", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1084]));
		dgPrincipal.Columns.Add("Terminais", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 631]));
		dgPrincipal.Columns.Add("Handle", "Handle");
	}

	public void AtualizaPrincipal()
	{
		if (dgPrincipal.RowCount <= 0)
		{
			dgPrincipal.Rows.Clear();
			dgPrincipal.Columns.Clear();
			return;
		}
		checked
		{
			double num = dgPrincipal.Width - 4;
			if (haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgPrincipal))
			{
				num = dgPrincipal.Width - 21;
			}
			dgPrincipal.Columns[0].Width = (int)Math.Round(num * 0.3);
			dgPrincipal.Columns[0].Visible = true;
			dgPrincipal.Columns[1].Width = (int)Math.Round(num * 0.3);
			dgPrincipal.Columns[1].Visible = true;
			dgPrincipal.Columns[2].Width = (int)Math.Round(num * 0.1);
			dgPrincipal.Columns[2].Visible = true;
			dgPrincipal.Columns[3].Width = (int)Math.Round(num * 0.3);
			dgPrincipal.Columns[3].Visible = true;
			dgPrincipal.Columns[4].Width = 0;
			dgPrincipal.Columns[4].Visible = false;
			dgPrincipal.MultiSelect = false;
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
				if (!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgBornes))
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

	public void AtualizaAuxiliar()
	{
		if (dgAuxiliar.RowCount <= 0)
		{
			dgAuxiliar.Rows.Clear();
			dgAuxiliar.Columns.Clear();
			return;
		}
		checked
		{
			double num = dgAuxiliar.Width - 4;
			if (haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgAuxiliar))
			{
				num = dgAuxiliar.Width - 21;
			}
			dgAuxiliar.Columns[0].Width = (int)Math.Round(num * 0.28);
			dgAuxiliar.Columns[0].Visible = true;
			dgAuxiliar.Columns[1].Width = (int)Math.Round(num * 0.28);
			dgAuxiliar.Columns[1].Visible = true;
			dgAuxiliar.Columns[2].Width = (int)Math.Round(num * 0.12);
			dgAuxiliar.Columns[2].Visible = true;
			dgAuxiliar.Columns[3].Width = (int)Math.Round(num * 0.12);
			dgAuxiliar.Columns[3].Visible = true;
			dgAuxiliar.Columns[4].Width = (int)Math.Round(num * 0.12);
			dgAuxiliar.Columns[4].Visible = true;
			dgAuxiliar.Columns[5].Width = (int)Math.Round(num * 0.08);
			dgAuxiliar.Columns[5].Visible = true;
			dgAuxiliar.Columns[6].Width = 0;
			dgAuxiliar.Columns[6].Visible = false;
			dgAuxiliar.MultiSelect = false;
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

	public void formatadgBornesEditados()
	{
		dgBornesEditados.Rows.Clear();
		dgBornesEditados.Columns.Clear();
		dgBornesEditados.Columns.Add("Painel", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1081]));
		dgBornesEditados.Columns.Add("Régua", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1425]));
		dgBornesEditados.Columns.Add("Borne", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1429]));
		dgBornesEditados.Columns.Add("Errado", "Errado");
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
				if (!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgPainelApagado))
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

	private void FIKcV6Rmpw(object P_0, EventArgs P_1)
	{
		Color backColor = btAtualizar.BackColor;
		bt1Fiacao.BackColor = backColor;
		bt3Principal.BackColor = backColor;
		bt4Auxiliar.BackColor = backColor;
		bt2Orfao.BackColor = backColor;
		bt5Terminais.BackColor = backColor;
		bt7Reguas.BackColor = backColor;
		bt8intervalos.BackColor = backColor;
		bt6Portas.BackColor = backColor;
		bt9Discrepantes.BackColor = backColor;
		bt10BornesLM.BackColor = backColor;
		bt11Paineis.BackColor = backColor;
		bt12AMao.BackColor = backColor;
		bt13ReguaMascara.BackColor = backColor;
		bt14PortasDiscrepantes.BackColor = backColor;
		mostraBT(1);
		dnHcu2bACp();
		bt1Fiacao.Enabled = true;
		bt3Principal.Enabled = true;
		bt4Auxiliar.Enabled = true;
		bt2Orfao.Enabled = true;
		bt5Terminais.Enabled = true;
		bt6Portas.Enabled = true;
		bt8intervalos.Enabled = true;
		bt7Reguas.Enabled = true;
		bt9Discrepantes.Enabled = true;
		bt10BornesLM.Enabled = true;
		bt11Paineis.Enabled = true;
		bt12AMao.Enabled = true;
		bt13ReguaMascara.Enabled = true;
		bt14PortasDiscrepantes.Enabled = true;
		Doje7509aG = false;
		dgPrincipalPotenciais.Rows.Clear();
		dgPrincipalPotenciais.Columns.Clear();
		Doje7509aG = true;
		if (dgPrincipal.RowCount == 0)
		{
			bt3Principal.Enabled = false;
		}
		if (!y1geIJmXHd)
		{
			bt4Auxiliar.Enabled = false;
		}
		if (dgFiacaoOrfao.RowCount == 0)
		{
			bt2Orfao.Enabled = false;
		}
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
		if (dgReguaMascara.RowCount == 0)
		{
			bt13ReguaMascara.Enabled = false;
		}
		if (dgPortasDiscrepantes.RowCount == 0)
		{
			bt14PortasDiscrepantes.Enabled = false;
		}
	}

	private void dnHcu2bACp()
	{
		if (Information.UBound(rDdevXNNtA) > 0)
		{
			ClsVerificadorProjetoFiacao.PintaFiacao(ref rDdevXNNtA);
		}
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		Doje7509aG = false;
		rDdevXNNtA = new ClsVerificadorProjetoFiacao._StructureConexao[1];
		c4Le6sxa5V = new DeclaracoesEntidades.StructureBorne[1];
		G78etxbxf6 = new ClsVerificadorProjetoFiacao._StructureAnalisePorta[1];
		zvRejlppGf = new ClsVerificadorProjetoFiacao._StructuremDispositivo[1];
		A94eLhaDqZ = new ClsVerificadorProjetoFiacao._StructuremAuxiliar[1];
		List<string> LFiacaoTTDuplicada = new List<string>();
		cOWeaBRTRB.Clear();
		checked
		{
			int num = dgEquip.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				if (dgEquip.Rows[i].Selected)
				{
					cOWeaBRTRB.Add(Conversions.ToString(dgEquip.Rows[i].Cells[0].Value));
				}
			}
			foreach (string nYCe8hPST in NYCe8hPSTs)
			{
				cOWeaBRTRB.Add(nYCe8hPST);
			}
			ClsVerificadorProjetoFiacao.buscaDadosDeFiacaoDWG(ref rDdevXNNtA, ref c4Le6sxa5V, ref G78etxbxf6, ref zvRejlppGf, ref A94eLhaDqZ, ref cOWeaBRTRB, ref NYCe8hPSTs, ref LFiacaoTTDuplicada, "F");
			clsBlocos.VerificaDuplicados(ref jhleNuAtKc, bProgress: false);
			TreeView1.Nodes.Clear();
			if (TreeView1.Nodes.Count == 0)
			{
				TreeView tree = TreeView1;
				ClsVerificadorProjetoFiacao.carregaTree(ref tree, rDdevXNNtA, LFiacaoTTDuplicada, ref CfmeFZJ4iM);
				TreeView1 = tree;
			}
			if (Information.UBound(rDdevXNNtA) <= 0)
			{
				GroupBoxFiacao.Enabled = false;
			}
			else
			{
				GroupBoxFiacao.Enabled = true;
			}
			MbycXLEWI4();
			XSScUGxu4K();
			formataFiacaoOrfao();
			DataGridView withEventsValue = dgFiacaoOrfao;
			ClsVerificadorProjetoFiacao.carregaOrfao(ref withEventsValue, rDdevXNNtA);
			dgFiacaoOrfao = withEventsValue;
			AtualizaFiacaoOrfao();
			n4fewEGaSS = new Declaracoes2.MModeloDePortas[1];
			clsPortas.CarregaTodasAsPortasPortas(ref n4fewEGaSS);
			yBNcmOtuQS();
			formatadgReguasSemUso();
			v0WcllwgoK();
			nXnc5R08lF();
			QU5c0lgjBd();
			GijcRTCGe3();
			j1ncyyZfGx();
			CarregaReguasDiscrepantes(n4fewEGaSS);
			TreeView1.ExpandAll();
			TreeViewBornes.ExpandAll();
			TreeViewBornesLM.ExpandAll();
			mqVcgNjXuh();
			AC1cAJLSDI();
			Doje7509aG = true;
			MZsc9Auv63();
		}
	}

	private void k1bcE1G0gP(object P_0, TreeViewEventArgs P_1)
	{
		DataGridView dg = dgPrincipalPotenciais;
		ClsVerificadorProjetoFiacao.formatadgPotencialSelecionado(ref dg);
		dgPrincipalPotenciais = dg;
		checked
		{
			int num = TreeView1.Nodes.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				int num2 = TreeView1.Nodes[i].Nodes.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					if (TreeView1.Nodes[i].Nodes[j].ForeColor != Color.Black)
					{
						TreeView1.Nodes[i].Nodes[j].BackColor = Color.White;
						TreeView1.Nodes[i].Nodes[j].ForeColor = Color.Black;
					}
				}
			}
			if (!(P_1.Node.ForeColor == Color.Red))
			{
				P_1.Node.ForeColor = Color.White;
				P_1.Node.BackColor = Color.Blue;
				int num3 = TreeView1.Nodes.Count - 1;
				for (int k = 0; k <= num3; k++)
				{
					if (TreeView1.Nodes[k].ForeColor != Color.Black)
					{
						TreeView1.Nodes[k].BackColor = Color.White;
						TreeView1.Nodes[k].ForeColor = Color.Black;
					}
				}
				int num4 = TreeView1.Nodes.Count - 1;
				for (int l = 0; l <= num4; l++)
				{
					int num5 = TreeView1.Nodes[l].Nodes.Count - 1;
					for (int m = 0; m <= num5; m++)
					{
						if ((Operators.CompareString(TreeView1.Nodes[l].Nodes[m].Name, " - 0,5", TextCompare: true) == 0) | (Operators.CompareString(TreeView1.Nodes[l].Nodes[m].Name, " - 0.5", TextCompare: true) == 0))
						{
							TreeView1.Nodes[l].Nodes[m].BackColor = Color.White;
							TreeView1.Nodes[l].Nodes[m].ForeColor = Color.Black;
						}
					}
				}
				Doje7509aG = false;
				dg = dgPrincipalPotenciais;
				ClsVerificadorProjetoFiacao.mostraPotencialSelecionado(ref dg, CfmeFZJ4iM, P_1.Node.Text);
				dgPrincipalPotenciais = dg;
				Doje7509aG = true;
			}
			else if (P_1.Node.Level == 2)
			{
				dgPrincipalPotenciais.Rows.Clear();
				dgPrincipalPotenciais.Columns.Clear();
				ClsVerificadorProjetoFiacao.mostraPotencialErrado(P_1.Node.Text);
			}
		}
	}

	private void vyVcZcvIbJ(object P_0, DataGridViewCellEventArgs P_1)
	{
		string sHandle = clsTextos.TiraNothing(Conversions.ToString(dgBornesEditados.SelectedRows[0].Cells[4].Value)).ToString();
		clsBlocos.MostraBloco(sHandle);
	}

	private void vQXciEj7J5(object P_0, DataGridViewCellEventArgs P_1)
	{
		string sHandle = dgFiacaoOrfao.SelectedRows[0].Cells[3].Value.ToString();
		clsBlocos.MostraBloco(sHandle);
	}

	private void fTDcSr8PoA(object P_0, DataGridViewCellEventArgs P_1)
	{
		clsBlocos.Unhighlight();
		if (dgTerminais.Rows.Count > 0)
		{
			string sHandle = clsTextos.TiraNothing(Conversions.ToString(dgTerminais.SelectedRows[0].Cells[3].Value));
			clsBlocos.MostraBloco(sHandle);
		}
	}

	private void Hlfc4B0Q8I(object P_0, DataGridViewCellEventArgs P_1)
	{
		clsBlocos.Unhighlight();
		if (dgBornes.Rows.Count > 0)
		{
			string sHandle = dgBornes.SelectedRows[0].Cells[3].Value.ToString();
			clsBlocos.MostraBloco(sHandle);
		}
	}

	private void OFCcCMgjMH(object P_0, DataGridViewCellEventArgs P_1)
	{
		clsBlocos.Unhighlight();
		string sHandle = clsTextos.TiraNothing(Conversions.ToString(dgPainelApagado.SelectedRows[0].Cells[3].Value)).ToString();
		clsBlocos.MostraBloco(sHandle);
	}

	private void WhccYNZIOb(object P_0, DataGridViewCellEventArgs P_1)
	{
		clsBlocos.Unhighlight();
		string sHandle = clsTextos.TiraNothing(Conversions.ToString(dgAMao.SelectedRows[0].Cells[2].Value)).ToString();
		clsBlocos.MostraBloco(sHandle);
		AtualizaFeitoAMao();
	}

	private void Pu5crHWVBb(object P_0, EventArgs P_1)
	{
		MZsc9Auv63();
	}

	private void MZsc9Auv63()
	{
		if (Doje7509aG)
		{
			AtualizaReguasSemUso();
			AtualizaBornesErro();
			AtualizaTerminais();
			AtualizaBornes();
			AtualizaAuxiliar();
			AtualizaPrincipal();
			AtualizaDGEquip();
			AtualizaPaineisApagados();
			AtualizaFeitoAMao();
			AtualizadgReguaMascara();
			DataGridView dg = dgPrincipalPotenciais;
			ClsVerificadorProjetoFiacao.AtualizaDGPotencialSelecionado(ref dg);
			dgPrincipalPotenciais = dg;
		}
	}

	public void mostraBT(int iNum)
	{
		GroupBoxFiacao.Visible = false;
		GroupBox1.Visible = false;
		GroupBox2.Visible = false;
		GroupBox3.Visible = false;
		GroupBox4.Visible = false;
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
		Color backColor = btAtualizar.BackColor;
		bt1Fiacao.BackColor = backColor;
		bt3Principal.BackColor = backColor;
		bt4Auxiliar.BackColor = backColor;
		bt2Orfao.BackColor = backColor;
		bt5Terminais.BackColor = backColor;
		bt7Reguas.BackColor = backColor;
		bt8intervalos.BackColor = backColor;
		bt6Portas.BackColor = backColor;
		bt9Discrepantes.BackColor = backColor;
		bt10BornesLM.BackColor = backColor;
		bt11Paineis.BackColor = backColor;
		bt12AMao.BackColor = backColor;
		bt13ReguaMascara.BackColor = backColor;
		bt14PortasDiscrepantes.BackColor = backColor;
		switch (iNum)
		{
		case 14:
			GroupBox14.Visible = true;
			bt14PortasDiscrepantes.BackColor = Color.LightSlateGray;
			AtualizadgReguaMascara();
			break;
		case 1:
			GroupBoxFiacao.Visible = true;
			GroupBox1.Visible = true;
			bt1Fiacao.BackColor = Color.LightSlateGray;
			break;
		case 2:
			GroupBox2.Visible = true;
			bt3Principal.BackColor = Color.LightSlateGray;
			break;
		case 3:
			GroupBox3.Visible = true;
			bt4Auxiliar.BackColor = Color.LightSlateGray;
			break;
		case 4:
			GroupBox4.Visible = true;
			bt2Orfao.BackColor = Color.LightSlateGray;
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
			AtualizaFeitoAMao();
			break;
		case 13:
			GroupBox13.Visible = true;
			bt13ReguaMascara.BackColor = Color.LightSlateGray;
			AtualizadgReguaMascara();
			break;
		}
	}

	private void nDxczlm9a5(object P_0, EventArgs P_1)
	{
		mostraBT(1);
	}

	private void zFVKWbxmvT(object P_0, EventArgs P_1)
	{
		mostraBT(2);
	}

	private void XPFKpSFhPj(object P_0, EventArgs P_1)
	{
		mostraBT(3);
		AtualizaAuxiliar();
	}

	private void r79KTMtQTy(object P_0, EventArgs P_1)
	{
		mostraBT(4);
	}

	private void oo9KJpCHeD(object P_0, EventArgs P_1)
	{
		mostraBT(5);
	}

	private void flfKh5Uhfw(object P_0, EventArgs P_1)
	{
		mostraBT(6);
	}

	private void CpIKoBdYZt(object P_0, EventArgs P_1)
	{
		mostraBT(7);
	}

	private void QYCKGPBgyF(object P_0, EventArgs P_1)
	{
		mostraBT(8);
	}

	private void UgJKHT3oZw(object P_0, EventArgs P_1)
	{
		mostraBT(9);
	}

	private void c4cKkJJoon(object P_0, EventArgs P_1)
	{
		mostraBT(10);
	}

	private void rVZKdkPIyf(object P_0, EventArgs P_1)
	{
		mostraBT(11);
	}

	private void aNLKfRT8hS(object P_0, EventArgs P_1)
	{
		mostraBT(12);
		AtualizaFeitoAMao();
	}

	private void sj3KDps2Kx(object P_0, EventArgs P_1)
	{
		mostraBT(13);
	}

	private void fQXKvJRE5T(object P_0, EventArgs P_1)
	{
		mostraBT(14);
	}

	private void yS4K6xt0hs(object P_0, MouseEventArgs P_1)
	{
		sJJKtadJ5W();
	}

	private void sJJKtadJ5W()
	{
		if (Doje7509aG)
		{
			clsBlocos.Unhighlight();
			if (dgPrincipalPotenciais.Rows.Count > 0)
			{
				string sPotencial = clsTextos.TiraNothing(Conversions.ToString(dgPrincipalPotenciais.SelectedRows[0].Cells[1].Value));
				string sPG = clsTextos.TiraNothing(Conversions.ToString(dgPrincipalPotenciais.SelectedRows[0].Cells[2].Value));
				ClsVerificadorProjetoFiacao.mostraPotencialNaPagina(sPotencial, sPG);
			}
		}
	}

	private void wFNKjfJWUL(object P_0, EventArgs P_1)
	{
		Declaracoes2.StructureModeloDeReguas[] mModelo = new Declaracoes2.StructureModeloDeReguas[1];
		Declaracoes2.StructureModeloDeReguas[] array = new Declaracoes2.StructureModeloDeReguas[1];
		DicionarioReguas.LeOsModelosDeRegua(ref mModelo);
		DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mModelo);
		DeclaracoesGeral._uscPagina.pbIniciar();
		List<string> lReguasUsadas = new List<string>();
		clsReguasDeBornes.EncontraReguasUsadasNoCaderno(ref lReguasUsadas);
		int num = Information.UBound(mModelo);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				if (lReguasUsadas.Contains(Conversions.ToString(mModelo[i].indexPainel) + "," + Conversions.ToString(mModelo[i].indexRegua)))
				{
					int num2 = Information.UBound(array) + 1;
					array = (Declaracoes2.StructureModeloDeReguas[])Utils.CopyArray(array, new Declaracoes2.StructureModeloDeReguas[num2 + 1]);
					array[num2] = mModelo[i];
				}
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			DeclaracoesGeral._uscPagina.pbFim();
			DicionarioReguas.GravaOsModelosDeRegua(array);
			bt7Reguas.Enabled = false;
			dnHcu2bACp();
			mostraBT(1);
		}
	}

	private void vsNKLQHH7c(object P_0, EventArgs P_1)
	{
		checked
		{
			int num = dgBornesEditados.RowCount - 1;
			for (int i = 0; i <= num; i++)
			{
				string sHandle = dgBornesEditados.Rows[i].Cells[4].Value.ToString();
				clsBornes.EditaUmBorne(ref sHandle, "T1", Conversions.ToString(dgBornesEditados.Rows[i].Cells[2].Value));
			}
			bt9Discrepantes.Enabled = false;
			dnHcu2bACp();
			mostraBT(1);
		}
	}

	private void gG3Kwv0Ena(object P_0, EventArgs P_1)
	{
		clsPortas.corrigeAsPortas();
		bt14PortasDiscrepantes.Enabled = false;
		dnHcu2bACp();
		mostraBT(1);
	}

	private void qoFKx7rRWx(object P_0, DataGridViewCellEventArgs P_1)
	{
		clsBlocos.Unhighlight();
		string sHandle = clsTextos.TiraNothing(Conversions.ToString(dgPortasDiscrepantes.SelectedRows[0].Cells[6].Value)).ToString();
		clsBlocos.MostraBloco(sHandle);
	}
}
