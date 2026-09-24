using System;
using System.Collections;
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
public class frmRelatorio_Cabos : Form
{
	private IContainer v5ZpLlb9DOW;

	[AccessedThroughProperty("dgRevisao")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DataGridView gJJpL5OfeTR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgEquip")]
	private DataGridView KTEpL0Ij4Fe;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dgCabos")]
	private DataGridView StwpLRbo7i4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btPesquisar")]
	private Button UfMpLmK85cu;

	[CompilerGenerated]
	[AccessedThroughProperty("btExportaEXCEL")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button f2SpLXJlt6I;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip FkEpLU8gB7c;

	[AccessedThroughProperty("cbComprimento")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox ehxpLyGqBXl;

	[AccessedThroughProperty("cbTrajeto")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private CheckBox o35pLgDPvlK;

	[AccessedThroughProperty("btExportaDWG")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button s80pLAB2lwC;

	[AccessedThroughProperty("btApagar")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button ElEpLs57CR3;

	[AccessedThroughProperty("GroupBox1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox OCvpLB08eYo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BTY")]
	private Button KIJpLVGFDir;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox3")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox uTnpLu7sAWj;

	[AccessedThroughProperty("Label2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label werpLEpD3YG;

	[AccessedThroughProperty("tbTamanhoFonte")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox nqWpLZAH2G3;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbInicioY")]
	[CompilerGenerated]
	private TextBox OhmpLiOb7Nl;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox2")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox XPspLSXfKvw;

	[CompilerGenerated]
	[AccessedThroughProperty("Label1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label trCpL46kL1p;

	[AccessedThroughProperty("GroupBox4")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox KiDpLCsGiI2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbTit3")]
	private TextBox PnypLYMTsOr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tbTit2")]
	private TextBox dN5pLrqM4qt;

	[AccessedThroughProperty("tbTit1")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox daEpL9IqNN8;

	[CompilerGenerated]
	[AccessedThroughProperty("btModeloEletrosul")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button VUxpLz489cb;

	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox5")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox JwSpwWfsAmJ;

	[AccessedThroughProperty("Label14")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label tt7pwpX1dIq;

	[AccessedThroughProperty("Label13")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label R9ZpwTQn2MC;

	[AccessedThroughProperty("Label12")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label ISrpwJfTgd6;

	[CompilerGenerated]
	[AccessedThroughProperty("tbData")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox pFApwh3jdsg;

	[AccessedThroughProperty("Label11")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Label KmXpwoghrqr;

	[AccessedThroughProperty("tbDesc")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox f8KpwGEaEE1;

	[AccessedThroughProperty("tbExec")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox Hh8pwHcRHJG;

	[AccessedThroughProperty("tbRev")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox sdUpwka8jr2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbTipoRel")]
	private ComboBox uEOpwdDZiNu;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btUltimo")]
	private Button NMIpwfpvudm;

	[AccessedThroughProperty("btPrimeiro")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button HXapwDSPXbo;

	[CompilerGenerated]
	[AccessedThroughProperty("btBaixo")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button SnapwvY3F4r;

	[AccessedThroughProperty("btCima")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button V1kpw6uYufM;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox6")]
	private GroupBox v8bpwtuRbvH;

	[AccessedThroughProperty("CKApenasTodosCabos")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private RadioButton UpfpwjAaZUx;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("CKApenasCabosUsados")]
	private RadioButton kKbpwLOkFOM;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("GroupBox7")]
	private GroupBox xn3pwwp5jSi;

	[AccessedThroughProperty("CKRepeteOsCabos")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RadioButton c6DpwxqkoYm;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CKNaoRepeteOsCabos")]
	[CompilerGenerated]
	private RadioButton qlXpwbmgal4;

	private DeclaracoesFiacao.structurePnRev[] q8ApwM1j4SR;

	private DeclaracoesFiacao.structureRevisoes[] K4UpwOeQDfM;

	private DeclaracoesInterligacao.structureCabo[] NZhpwIPE8qw;

	private Relatorios_CabosEnergisaDWG.structureRelatCabosEnergisa[] Hi4pw7tcX8j;

	private Relatorios_CabosChesfDWG.structureRelatCabosChesf[] m5apwqeG6Yh;

	private Relatorios_CabosChesfDWG.structureRelatCabosEDPES[] dS8pwa5Si1M;

	private Relatorios_CabosEnergisaDWG.structureRelatCabosEnergisa[] CaGpw8bQ1Z3;

	private Relatorios_CabosChesfDWG.structureRelatCabosCEMIG_D[] zjspwNyKR7d;

	private string vGqpwFpt3ms;

	private int NFvpwQ9A5f0;

	private string WSypwPsRo0g;

	private bool aLipwcEZUT5;

	private bool oD5pwKNiSsh;

	private DataGridViewCellStyle cgKpweJnlE0;

	private string U7opw2aqakS;

	private List<string> zyfpw3f9rMv;

	private bool Pl1pwnp2uhq;

	internal virtual DataGridView dgRevisao
	{
		[CompilerGenerated]
		get
		{
			return gJJpL5OfeTR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = zulpLwHhO1a;
			DataGridView dataGridView = gJJpL5OfeTR;
			if (dataGridView != null)
			{
				dataGridView.SelectionChanged -= value2;
			}
			gJJpL5OfeTR = value;
			dataGridView = gJJpL5OfeTR;
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
			return KTEpL0Ij4Fe;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KTEpL0Ij4Fe = value;
		}
	}

	internal virtual DataGridView dgCabos
	{
		[CompilerGenerated]
		get
		{
			return StwpLRbo7i4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			StwpLRbo7i4 = value;
		}
	}

	internal virtual Button btPesquisar
	{
		[CompilerGenerated]
		get
		{
			return UfMpLmK85cu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = fxNpLbIyglU;
			Button button = UfMpLmK85cu;
			if (button != null)
			{
				button.Click -= value2;
			}
			UfMpLmK85cu = value;
			button = UfMpLmK85cu;
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
			return f2SpLXJlt6I;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = eKepLOVib5Y;
			Button button = f2SpLXJlt6I;
			if (button != null)
			{
				button.Click -= value2;
			}
			f2SpLXJlt6I = value;
			button = f2SpLXJlt6I;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox cbComprimento
	{
		[CompilerGenerated]
		get
		{
			return ehxpLyGqBXl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ehxpLyGqBXl = value;
		}
	}

	internal virtual CheckBox cbTrajeto
	{
		[CompilerGenerated]
		get
		{
			return o35pLgDPvlK;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			o35pLgDPvlK = value;
		}
	}

	internal virtual Button btExportaDWG
	{
		[CompilerGenerated]
		get
		{
			return s80pLAB2lwC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = J3spLIhqB4N;
			Button button = s80pLAB2lwC;
			if (button != null)
			{
				button.Click -= value2;
			}
			s80pLAB2lwC = value;
			button = s80pLAB2lwC;
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
			return ElEpLs57CR3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = vgPpL7uiOIR;
			Button button = ElEpLs57CR3;
			if (button != null)
			{
				button.Click -= value2;
			}
			ElEpLs57CR3 = value;
			button = ElEpLs57CR3;
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
			return OCvpLB08eYo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			OCvpLB08eYo = value;
		}
	}

	internal virtual Button BTY
	{
		[CompilerGenerated]
		get
		{
			return KIJpLVGFDir;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = r4NpL89xgBZ;
			Button button = KIJpLVGFDir;
			if (button != null)
			{
				button.Click -= value2;
			}
			KIJpLVGFDir = value;
			button = KIJpLVGFDir;
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
			return uTnpLu7sAWj;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			uTnpLu7sAWj = value;
		}
	}

	internal virtual Label Label2
	{
		[CompilerGenerated]
		get
		{
			return werpLEpD3YG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			werpLEpD3YG = value;
		}
	}

	internal virtual TextBox tbTamanhoFonte
	{
		[CompilerGenerated]
		get
		{
			return nqWpLZAH2G3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = bXJpLQbmQIs;
			TextBox textBox = nqWpLZAH2G3;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			nqWpLZAH2G3 = value;
			textBox = nqWpLZAH2G3;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual TextBox tbInicioY
	{
		[CompilerGenerated]
		get
		{
			return OhmpLiOb7Nl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = UqxpLPosSuj;
			TextBox textBox = OhmpLiOb7Nl;
			if (textBox != null)
			{
				textBox.KeyPress -= value2;
			}
			OhmpLiOb7Nl = value;
			textBox = OhmpLiOb7Nl;
			if (textBox != null)
			{
				textBox.KeyPress += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox2
	{
		[CompilerGenerated]
		get
		{
			return XPspLSXfKvw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			XPspLSXfKvw = value;
		}
	}

	internal virtual Label Label1
	{
		[CompilerGenerated]
		get
		{
			return trCpL46kL1p;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			trCpL46kL1p = value;
		}
	}

	internal virtual GroupBox GroupBox4
	{
		[CompilerGenerated]
		get
		{
			return KiDpLCsGiI2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KiDpLCsGiI2 = value;
		}
	}

	internal virtual TextBox tbTit3
	{
		[CompilerGenerated]
		get
		{
			return PnypLYMTsOr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			PnypLYMTsOr = value;
		}
	}

	internal virtual TextBox tbTit2
	{
		[CompilerGenerated]
		get
		{
			return dN5pLrqM4qt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			dN5pLrqM4qt = value;
		}
	}

	internal virtual TextBox tbTit1
	{
		[CompilerGenerated]
		get
		{
			return daEpL9IqNN8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			daEpL9IqNN8 = value;
		}
	}

	internal virtual Button btModeloEletrosul
	{
		[CompilerGenerated]
		get
		{
			return VUxpLz489cb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = vthpLFRwL12;
			Button button = VUxpLz489cb;
			if (button != null)
			{
				button.Click -= value2;
			}
			VUxpLz489cb = value;
			button = VUxpLz489cb;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GroupBox5
	{
		[CompilerGenerated]
		get
		{
			return JwSpwWfsAmJ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			JwSpwWfsAmJ = value;
		}
	}

	internal virtual Label Label14
	{
		[CompilerGenerated]
		get
		{
			return tt7pwpX1dIq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			tt7pwpX1dIq = value;
		}
	}

	internal virtual Label Label13
	{
		[CompilerGenerated]
		get
		{
			return R9ZpwTQn2MC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			R9ZpwTQn2MC = value;
		}
	}

	internal virtual Label Label12
	{
		[CompilerGenerated]
		get
		{
			return ISrpwJfTgd6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ISrpwJfTgd6 = value;
		}
	}

	internal virtual TextBox tbData
	{
		[CompilerGenerated]
		get
		{
			return pFApwh3jdsg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pFApwh3jdsg = value;
		}
	}

	internal virtual Label Label11
	{
		[CompilerGenerated]
		get
		{
			return KmXpwoghrqr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KmXpwoghrqr = value;
		}
	}

	internal virtual TextBox tbDesc
	{
		[CompilerGenerated]
		get
		{
			return f8KpwGEaEE1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			f8KpwGEaEE1 = value;
		}
	}

	internal virtual TextBox tbExec
	{
		[CompilerGenerated]
		get
		{
			return Hh8pwHcRHJG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Hh8pwHcRHJG = value;
		}
	}

	internal virtual TextBox tbRev
	{
		[CompilerGenerated]
		get
		{
			return sdUpwka8jr2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			sdUpwka8jr2 = value;
		}
	}

	internal virtual ComboBox cbTipoRel
	{
		[CompilerGenerated]
		get
		{
			return uEOpwdDZiNu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tAlpLeW4glx;
			ComboBox comboBox = uEOpwdDZiNu;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged -= value2;
			}
			uEOpwdDZiNu = value;
			comboBox = uEOpwdDZiNu;
			if (comboBox != null)
			{
				comboBox.SelectedIndexChanged += value2;
			}
		}
	}

	internal virtual Button btUltimo
	{
		[CompilerGenerated]
		get
		{
			return NMIpwfpvudm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = hTSpL1vq6Ip;
			Button button = NMIpwfpvudm;
			if (button != null)
			{
				button.Click -= value2;
			}
			NMIpwfpvudm = value;
			button = NMIpwfpvudm;
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
			return HXapwDSPXbo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = AywpL2MF85Q;
			Button button = HXapwDSPXbo;
			if (button != null)
			{
				button.Click -= value2;
			}
			HXapwDSPXbo = value;
			button = HXapwDSPXbo;
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
			return SnapwvY3F4r;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = YgDpLnjEF66;
			Button button = SnapwvY3F4r;
			if (button != null)
			{
				button.Click -= value2;
			}
			SnapwvY3F4r = value;
			button = SnapwvY3F4r;
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
			return V1kpw6uYufM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ESypL31VEAX;
			Button button = V1kpw6uYufM;
			if (button != null)
			{
				button.Click -= value2;
			}
			V1kpw6uYufM = value;
			button = V1kpw6uYufM;
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
			return v8bpwtuRbvH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			v8bpwtuRbvH = value;
		}
	}

	internal virtual RadioButton CKApenasTodosCabos
	{
		[CompilerGenerated]
		get
		{
			return UpfpwjAaZUx;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			UpfpwjAaZUx = value;
		}
	}

	internal virtual RadioButton CKApenasCabosUsados
	{
		[CompilerGenerated]
		get
		{
			return kKbpwLOkFOM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			kKbpwLOkFOM = value;
		}
	}

	internal virtual GroupBox GroupBox7
	{
		[CompilerGenerated]
		get
		{
			return xn3pwwp5jSi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			xn3pwwp5jSi = value;
		}
	}

	internal virtual RadioButton CKRepeteOsCabos
	{
		[CompilerGenerated]
		get
		{
			return c6DpwxqkoYm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			c6DpwxqkoYm = value;
		}
	}

	internal virtual RadioButton CKNaoRepeteOsCabos
	{
		[CompilerGenerated]
		get
		{
			return qlXpwbmgal4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			qlXpwbmgal4 = value;
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && v5ZpLlb9DOW != null)
			{
				v5ZpLlb9DOW.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void GnbpLjJGdah()
	{
		v5ZpLlb9DOW = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmRelatorio_Cabos));
		dgRevisao = new DataGridView();
		dgEquip = new DataGridView();
		dgCabos = new DataGridView();
		btPesquisar = new Button();
		btExportaEXCEL = new Button();
		FDqpBiUmZij(new ToolTip(v5ZpLlb9DOW));
		cbComprimento = new CheckBox();
		cbTrajeto = new CheckBox();
		btExportaDWG = new Button();
		btApagar = new Button();
		GroupBox1 = new GroupBox();
		cbTipoRel = new ComboBox();
		BTY = new Button();
		GroupBox3 = new GroupBox();
		Label2 = new Label();
		tbTamanhoFonte = new TextBox();
		tbInicioY = new TextBox();
		GroupBox2 = new GroupBox();
		Label1 = new Label();
		GroupBox4 = new GroupBox();
		tbTit3 = new TextBox();
		tbTit2 = new TextBox();
		tbTit1 = new TextBox();
		btModeloEletrosul = new Button();
		GroupBox5 = new GroupBox();
		tbData = new TextBox();
		tbExec = new TextBox();
		tbRev = new TextBox();
		Label14 = new Label();
		tbDesc = new TextBox();
		Label13 = new Label();
		Label12 = new Label();
		Label11 = new Label();
		btUltimo = new Button();
		btPrimeiro = new Button();
		btBaixo = new Button();
		btCima = new Button();
		GroupBox6 = new GroupBox();
		CKApenasTodosCabos = new RadioButton();
		CKApenasCabosUsados = new RadioButton();
		GroupBox7 = new GroupBox();
		CKRepeteOsCabos = new RadioButton();
		CKNaoRepeteOsCabos = new RadioButton();
		((ISupportInitialize)dgRevisao).BeginInit();
		((ISupportInitialize)dgEquip).BeginInit();
		((ISupportInitialize)dgCabos).BeginInit();
		GroupBox1.SuspendLayout();
		GroupBox3.SuspendLayout();
		GroupBox2.SuspendLayout();
		GroupBox4.SuspendLayout();
		GroupBox5.SuspendLayout();
		GroupBox6.SuspendLayout();
		GroupBox7.SuspendLayout();
		SuspendLayout();
		dgRevisao.AllowUserToAddRows = false;
		dgRevisao.AllowUserToDeleteRows = false;
		dgRevisao.AllowUserToOrderColumns = true;
		dgRevisao.AllowUserToResizeRows = false;
		dgRevisao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgRevisao.BackgroundColor = Color.White;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = SystemColors.Control;
		dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.True;
		dgRevisao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
		dgRevisao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgRevisao.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgRevisao.Location = new Point(12, 12);
		dgRevisao.MultiSelect = false;
		dgRevisao.Name = "dgRevisao";
		dgRevisao.ReadOnly = true;
		dgRevisao.RowHeadersVisible = false;
		dgRevisao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgRevisao.Size = new Size(206, 227);
		dgRevisao.TabIndex = 3;
		dgEquip.AllowUserToAddRows = false;
		dgEquip.AllowUserToDeleteRows = false;
		dgEquip.AllowUserToOrderColumns = true;
		dgEquip.AllowUserToResizeRows = false;
		dgEquip.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
		dgEquip.BackgroundColor = Color.White;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = SystemColors.Control;
		dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		dgEquip.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		dgEquip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgEquip.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgEquip.Location = new Point(224, 12);
		dgEquip.Name = "dgEquip";
		dgEquip.ReadOnly = true;
		dgEquip.RowHeadersVisible = false;
		dgEquip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		dgEquip.Size = new Size(206, 554);
		dgEquip.TabIndex = 8;
		dgCabos.AllowUserToAddRows = false;
		dgCabos.AllowUserToDeleteRows = false;
		dgCabos.AllowUserToResizeRows = false;
		dgCabos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		dgCabos.BackgroundColor = Color.White;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = SystemColors.Control;
		dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
		dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
		dgCabos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
		dgCabos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dgCabos.EditMode = DataGridViewEditMode.EditProgrammatically;
		dgCabos.Location = new Point(436, 12);
		dgCabos.MultiSelect = false;
		dgCabos.Name = "dgCabos";
		dgCabos.ReadOnly = true;
		dgCabos.RowHeadersVisible = false;
		dgCabos.SelectionMode = DataGridViewSelectionMode.CellSelect;
		dgCabos.Size = new Size(436, 574);
		dgCabos.TabIndex = 11;
		btPesquisar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPesquisar.FlatStyle = FlatStyle.Flat;
		btPesquisar.ForeColor = SystemColors.Control;
		btPesquisar.Image = Resources.Pesquisar_32;
		btPesquisar.Location = new Point(16, 557);
		btPesquisar.Name = "btPesquisar";
		btPesquisar.Size = new Size(40, 42);
		btPesquisar.TabIndex = 15;
		btPesquisar.UseVisualStyleBackColor = true;
		btExportaEXCEL.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btExportaEXCEL.FlatStyle = FlatStyle.Flat;
		btExportaEXCEL.ForeColor = SystemColors.Control;
		btExportaEXCEL.Image = Resources.ExportaExcel_20;
		btExportaEXCEL.Location = new Point(159, 557);
		btExportaEXCEL.Name = "btExportaEXCEL";
		btExportaEXCEL.Size = new Size(40, 42);
		btExportaEXCEL.TabIndex = 41;
		btExportaEXCEL.UseVisualStyleBackColor = true;
		cbComprimento.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		cbComprimento.AutoSize = true;
		cbComprimento.Location = new Point(6, 10);
		cbComprimento.Name = "cbComprimento";
		cbComprimento.Size = new Size(99, 17);
		cbComprimento.TabIndex = 42;
		cbComprimento.Text = "cbComprimento";
		cbComprimento.UseVisualStyleBackColor = true;
		cbTrajeto.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		cbTrajeto.AutoSize = true;
		cbTrajeto.Location = new Point(111, 10);
		cbTrajeto.Name = "cbTrajeto";
		cbTrajeto.Size = new Size(71, 17);
		cbTrajeto.TabIndex = 43;
		cbTrajeto.Text = "cbTrajeto";
		cbTrajeto.UseVisualStyleBackColor = true;
		btExportaDWG.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btExportaDWG.FlatStyle = FlatStyle.Flat;
		btExportaDWG.ForeColor = SystemColors.Control;
		btExportaDWG.Image = (Image)componentResourceManager.GetObject("btExportaDWG.Image");
		btExportaDWG.Location = new Point(85, 557);
		btExportaDWG.Name = "btExportaDWG";
		btExportaDWG.Size = new Size(40, 42);
		btExportaDWG.TabIndex = 185;
		btExportaDWG.UseVisualStyleBackColor = true;
		btApagar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btApagar.FlatStyle = FlatStyle.Flat;
		btApagar.ForeColor = SystemColors.Control;
		btApagar.Image = Resources.Delete_32;
		btApagar.Location = new Point(159, 557);
		btApagar.Name = "btApagar";
		btApagar.Size = new Size(40, 42);
		btApagar.TabIndex = 186;
		btApagar.Tag = "";
		btApagar.UseVisualStyleBackColor = true;
		GroupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox1.Controls.Add(cbTipoRel);
		GroupBox1.Location = new Point(12, 305);
		GroupBox1.Name = "GroupBox1";
		GroupBox1.Size = new Size(206, 52);
		GroupBox1.TabIndex = 187;
		GroupBox1.TabStop = false;
		GroupBox1.Text = "Padrão";
		cbTipoRel.FormattingEnabled = true;
		cbTipoRel.Location = new Point(12, 19);
		cbTipoRel.Name = "cbTipoRel";
		cbTipoRel.Size = new Size(183, 21);
		cbTipoRel.TabIndex = 207;
		BTY.FlatStyle = FlatStyle.Flat;
		BTY.ForeColor = SystemColors.Control;
		BTY.Image = Resources.Altura;
		BTY.Location = new Point(52, 12);
		BTY.Name = "BTY";
		BTY.Size = new Size(40, 40);
		BTY.TabIndex = 188;
		BTY.UseVisualStyleBackColor = true;
		GroupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox3.Controls.Add(Label2);
		GroupBox3.Controls.Add(tbTamanhoFonte);
		GroupBox3.Controls.Add(tbInicioY);
		GroupBox3.Controls.Add(BTY);
		GroupBox3.Location = new Point(6, 395);
		GroupBox3.Name = "GroupBox3";
		GroupBox3.Size = new Size(212, 55);
		GroupBox3.TabIndex = 189;
		GroupBox3.TabStop = false;
		GroupBox3.Text = "Configuração";
		Label2.AutoSize = true;
		Label2.Location = new Point(110, 10);
		Label2.Name = "Label2";
		Label2.Size = new Size(39, 13);
		Label2.TabIndex = 192;
		Label2.Text = "Label2";
		tbTamanhoFonte.Location = new Point(110, 29);
		tbTamanhoFonte.Name = "tbTamanhoFonte";
		tbTamanhoFonte.Size = new Size(62, 20);
		tbTamanhoFonte.TabIndex = 193;
		tbTamanhoFonte.TextAlign = HorizontalAlignment.Center;
		tbInicioY.Location = new Point(9, 29);
		tbInicioY.Name = "tbInicioY";
		tbInicioY.Size = new Size(45, 20);
		tbInicioY.TabIndex = 191;
		tbInicioY.TextAlign = HorizontalAlignment.Center;
		GroupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox2.Controls.Add(cbComprimento);
		GroupBox2.Controls.Add(cbTrajeto);
		GroupBox2.Location = new Point(12, 359);
		GroupBox2.Name = "GroupBox2";
		GroupBox2.Size = new Size(206, 31);
		GroupBox2.TabIndex = 190;
		GroupBox2.TabStop = false;
		Label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		Label1.ImageAlign = ContentAlignment.MiddleRight;
		Label1.Location = new Point(755, 589);
		Label1.Name = "Label1";
		Label1.Size = new Size(117, 20);
		Label1.TabIndex = 193;
		Label1.Text = "Total";
		Label1.TextAlign = ContentAlignment.MiddleRight;
		GroupBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox4.Controls.Add(tbTit3);
		GroupBox4.Controls.Add(tbTit2);
		GroupBox4.Controls.Add(tbTit1);
		GroupBox4.Location = new Point(6, 454);
		GroupBox4.Name = "GroupBox4";
		GroupBox4.Size = new Size(212, 101);
		GroupBox4.TabIndex = 194;
		GroupBox4.TabStop = false;
		GroupBox4.Text = "Configuração";
		tbTit3.Location = new Point(9, 73);
		tbTit3.Name = "tbTit3";
		tbTit3.Size = new Size(193, 20);
		tbTit3.TabIndex = 194;
		tbTit3.TextAlign = HorizontalAlignment.Center;
		tbTit2.Location = new Point(9, 47);
		tbTit2.Name = "tbTit2";
		tbTit2.Size = new Size(193, 20);
		tbTit2.TabIndex = 193;
		tbTit2.TextAlign = HorizontalAlignment.Center;
		tbTit1.Location = new Point(9, 21);
		tbTit1.Name = "tbTit1";
		tbTit1.Size = new Size(193, 20);
		tbTit1.TabIndex = 191;
		tbTit1.TextAlign = HorizontalAlignment.Center;
		btModeloEletrosul.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btModeloEletrosul.FlatStyle = FlatStyle.Flat;
		btModeloEletrosul.ForeColor = SystemColors.Control;
		btModeloEletrosul.Image = Resources.ModeloExcel_32;
		btModeloEletrosul.Location = new Point(85, 557);
		btModeloEletrosul.Name = "btModeloEletrosul";
		btModeloEletrosul.Size = new Size(40, 42);
		btModeloEletrosul.TabIndex = 195;
		btModeloEletrosul.UseVisualStyleBackColor = true;
		GroupBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox5.Controls.Add(tbData);
		GroupBox5.Controls.Add(tbExec);
		GroupBox5.Controls.Add(tbRev);
		GroupBox5.Controls.Add(Label14);
		GroupBox5.Controls.Add(tbDesc);
		GroupBox5.Controls.Add(Label13);
		GroupBox5.Controls.Add(Label12);
		GroupBox5.Controls.Add(Label11);
		GroupBox5.Location = new Point(237, 455);
		GroupBox5.Name = "GroupBox5";
		GroupBox5.Size = new Size(212, 101);
		GroupBox5.TabIndex = 196;
		GroupBox5.TabStop = false;
		GroupBox5.Text = "Configuração";
		tbData.Location = new Point(56, 29);
		tbData.Name = "tbData";
		tbData.Size = new Size(81, 20);
		tbData.TabIndex = 192;
		tbData.TextAlign = HorizontalAlignment.Center;
		tbExec.Location = new Point(143, 29);
		tbExec.Name = "tbExec";
		tbExec.Size = new Size(62, 20);
		tbExec.TabIndex = 193;
		tbExec.TextAlign = HorizontalAlignment.Center;
		tbRev.Location = new Point(6, 29);
		tbRev.Name = "tbRev";
		tbRev.Size = new Size(44, 20);
		tbRev.TabIndex = 191;
		tbRev.TextAlign = HorizontalAlignment.Center;
		Label14.AutoSize = true;
		Label14.Location = new Point(3, 54);
		Label14.Name = "Label14";
		Label14.Size = new Size(34, 13);
		Label14.TabIndex = 199;
		Label14.Text = "lDesc";
		tbDesc.Location = new Point(6, 73);
		tbDesc.Name = "tbDesc";
		tbDesc.Size = new Size(199, 20);
		tbDesc.TabIndex = 194;
		tbDesc.TextAlign = HorizontalAlignment.Center;
		Label13.AutoSize = true;
		Label13.Location = new Point(140, 13);
		Label13.Name = "Label13";
		Label13.Size = new Size(36, 13);
		Label13.TabIndex = 198;
		Label13.Text = "lExec.";
		Label12.AutoSize = true;
		Label12.Location = new Point(53, 13);
		Label12.Name = "Label12";
		Label12.Size = new Size(32, 13);
		Label12.TabIndex = 197;
		Label12.Text = "lData";
		Label11.AutoSize = true;
		Label11.Location = new Point(6, 13);
		Label11.Name = "Label11";
		Label11.Size = new Size(29, 13);
		Label11.TabIndex = 195;
		Label11.Text = "lRev";
		btUltimo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btUltimo.Image = Resources.Ultimo_16;
		btUltimo.Location = new Point(369, 576);
		btUltimo.Name = "btUltimo";
		btUltimo.Size = new Size(23, 23);
		btUltimo.TabIndex = 200;
		btUltimo.UseVisualStyleBackColor = true;
		btPrimeiro.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btPrimeiro.Image = Resources.Primeiro_16;
		btPrimeiro.Location = new Point(251, 576);
		btPrimeiro.Name = "btPrimeiro";
		btPrimeiro.Size = new Size(23, 23);
		btPrimeiro.TabIndex = 199;
		btPrimeiro.UseVisualStyleBackColor = true;
		btBaixo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btBaixo.Image = Resources.Baixo_16;
		btBaixo.Location = new Point(330, 576);
		btBaixo.Name = "btBaixo";
		btBaixo.Size = new Size(23, 23);
		btBaixo.TabIndex = 198;
		btBaixo.UseVisualStyleBackColor = true;
		btCima.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		btCima.Image = Resources.Cima_16;
		btCima.Location = new Point(290, 576);
		btCima.Name = "btCima";
		btCima.Size = new Size(23, 23);
		btCima.TabIndex = 197;
		btCima.UseVisualStyleBackColor = true;
		GroupBox6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox6.Controls.Add(CKApenasTodosCabos);
		GroupBox6.Controls.Add(CKApenasCabosUsados);
		GroupBox6.Location = new Point(12, 243);
		GroupBox6.Name = "GroupBox6";
		GroupBox6.Size = new Size(206, 60);
		GroupBox6.TabIndex = 213;
		GroupBox6.TabStop = false;
		GroupBox6.Text = "gbMostrar";
		CKApenasTodosCabos.AutoSize = true;
		CKApenasTodosCabos.Checked = true;
		CKApenasTodosCabos.Location = new Point(12, 17);
		CKApenasTodosCabos.Name = "CKApenasTodosCabos";
		CKApenasTodosCabos.Size = new Size(135, 17);
		CKApenasTodosCabos.TabIndex = 1;
		CKApenasTodosCabos.TabStop = true;
		CKApenasTodosCabos.Text = "CKApenasTodosCabos";
		CKApenasTodosCabos.UseVisualStyleBackColor = true;
		CKApenasCabosUsados.AutoSize = true;
		CKApenasCabosUsados.Location = new Point(12, 37);
		CKApenasCabosUsados.Name = "CKApenasCabosUsados";
		CKApenasCabosUsados.Size = new Size(141, 17);
		CKApenasCabosUsados.TabIndex = 0;
		CKApenasCabosUsados.Text = "CKApenasCabosUsados";
		CKApenasCabosUsados.UseVisualStyleBackColor = true;
		GroupBox7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		GroupBox7.Controls.Add(CKRepeteOsCabos);
		GroupBox7.Controls.Add(CKNaoRepeteOsCabos);
		GroupBox7.Location = new Point(474, 455);
		GroupBox7.Name = "GroupBox7";
		GroupBox7.Size = new Size(212, 101);
		GroupBox7.TabIndex = 214;
		GroupBox7.TabStop = false;
		GroupBox7.Text = "Repetir Cabos em Equipamentos";
		CKRepeteOsCabos.AutoSize = true;
		CKRepeteOsCabos.Checked = true;
		CKRepeteOsCabos.Location = new Point(18, 29);
		CKRepeteOsCabos.Name = "CKRepeteOsCabos";
		CKRepeteOsCabos.Size = new Size(42, 17);
		CKRepeteOsCabos.TabIndex = 3;
		CKRepeteOsCabos.TabStop = true;
		CKRepeteOsCabos.Text = "Sim";
		CKRepeteOsCabos.UseVisualStyleBackColor = true;
		CKNaoRepeteOsCabos.AutoSize = true;
		CKNaoRepeteOsCabos.Location = new Point(18, 62);
		CKNaoRepeteOsCabos.Name = "CKNaoRepeteOsCabos";
		CKNaoRepeteOsCabos.Size = new Size(45, 17);
		CKNaoRepeteOsCabos.TabIndex = 2;
		CKNaoRepeteOsCabos.Text = "Não";
		CKNaoRepeteOsCabos.UseVisualStyleBackColor = true;
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(884, 611);
		Controls.Add(GroupBox7);
		Controls.Add(GroupBox6);
		Controls.Add(btUltimo);
		Controls.Add(btPrimeiro);
		Controls.Add(btBaixo);
		Controls.Add(btCima);
		Controls.Add(GroupBox5);
		Controls.Add(GroupBox4);
		Controls.Add(Label1);
		Controls.Add(GroupBox2);
		Controls.Add(GroupBox3);
		Controls.Add(GroupBox1);
		Controls.Add(btPesquisar);
		Controls.Add(dgCabos);
		Controls.Add(dgEquip);
		Controls.Add(dgRevisao);
		Controls.Add(btExportaEXCEL);
		Controls.Add(btExportaDWG);
		Controls.Add(btModeloEletrosul);
		Controls.Add(btApagar);
		MinimumSize = new Size(900, 650);
		Name = "frmRelatorio_Cabos";
		ShowInTaskbar = false;
		Text = "Lista de Cabos";
		((ISupportInitialize)dgRevisao).EndInit();
		((ISupportInitialize)dgEquip).EndInit();
		((ISupportInitialize)dgCabos).EndInit();
		GroupBox1.ResumeLayout(performLayout: false);
		GroupBox3.ResumeLayout(performLayout: false);
		GroupBox3.PerformLayout();
		GroupBox2.ResumeLayout(performLayout: false);
		GroupBox2.PerformLayout();
		GroupBox4.ResumeLayout(performLayout: false);
		GroupBox4.PerformLayout();
		GroupBox5.ResumeLayout(performLayout: false);
		GroupBox5.PerformLayout();
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
		return FkEpLU8gB7c;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		FkEpLU8gB7c = WithEventsValue;
	}

	public frmRelatorio_Cabos()
	{
		Resize += JEApLcx8mG2;
		q8ApwM1j4SR = new DeclaracoesFiacao.structurePnRev[1];
		K4UpwOeQDfM = new DeclaracoesFiacao.structureRevisoes[1];
		vGqpwFpt3ms = "";
		NFvpwQ9A5f0 = 0;
		WSypwPsRo0g = "";
		aLipwcEZUT5 = false;
		oD5pwKNiSsh = false;
		cgKpweJnlE0 = new DataGridViewCellStyle();
		zyfpw3f9rMv = new List<string>();
		Pl1pwnp2uhq = false;
		try
		{
			if (!Geral.ExisteForm("frmRelatorio_Cabos"))
			{
				GnbpLjJGdah();
				cgKpweJnlE0.BackColor = Color.BlueViolet;
				DeclaracoesGeral.Reguas RH = default;
				XDataGeral.LeXDataReguaH(ref RH);
				tbInicioY.Text = Conversions.ToString(RH.Pti.Y - 5.0);
				Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1409]);
				w8dpBZ0kvSD().SetToolTip(btPesquisar, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1411]));
				cbComprimento.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1412]);
				cbTrajeto.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1413]);
				GroupBox1.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 368]);
				GroupBox2.Text = "";
				GroupBox3.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 111]);
				GroupBox4.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 205]);
				w8dpBZ0kvSD().SetToolTip(BTY, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1598]));
				Label2.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 339]);
				Label11.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 380]);
				Label12.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 65]);
				Label13.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 68]);
				Label14.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 64]);
				GroupBox6.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1723]);
				CKApenasCabosUsados.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1919]);
				CKApenasTodosCabos.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1279]);
				string text = DeclaracoesGeral.mMensagem[1, 1974].ToString().ToLower();
				GroupBox7.Text = text.Substring(0, 1).ToUpper() + text.Substring(1, checked(text.Length - 1));
				CKRepeteOsCabos.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1975]);
				CKNaoRepeteOsCabos.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1976]);
				zyfpw3f9rMv.Clear();
				cDadosAccess.carregaDadosDWG();
				Application.ShowModelessDialog((Form)this);
				formataDGRevisao();
				formataDGEquip();
				formataDGCabosEletron();
				dUQpLLpkiCW();
				cbComprimento.Checked = false;
				cbTrajeto.Checked = false;
				cbTipoRel.Items.Add("ELÉTRON");
				cbTipoRel.Items.Add("ENERGISA");
				cbTipoRel.Items.Add("ELETROSUL");
				cbTipoRel.Items.Add("CHESF");
				cbTipoRel.Items.Add("EDP ES");
				cbTipoRel.Items.Add("TAESA");
				cbTipoRel.Items.Add("CEMIG-D");
				cbTipoRel.Items.Add("ENEL-SP");
				cbTipoRel.SelectedItem = "ELÉTRON";
				U7opw2aqakS = "ELÉTRON";
				tbTamanhoFonte.Text = Conversions.ToString(1.9);
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

	private void dUQpLLpkiCW()
	{
		K4UpwOeQDfM = new DeclaracoesFiacao.structureRevisoes[1];
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			cDadosAccessInterligacao3.CarregaRevisoesCabos4(ref K4UpwOeQDfM);
			aLipwcEZUT5 = true;
			dgRevisao.Rows.Clear();
			aLipwcEZUT5 = false;
			int num = Information.UBound(K4UpwOeQDfM);
			for (int i = num; i >= 1; i = checked(i + -1))
			{
				dgRevisao.Rows.Add(K4UpwOeQDfM[i].revisao, K4UpwOeQDfM[i].criador, K4UpwOeQDfM[i].data);
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
			cDadosAccessInterligacao3.fechaConexao();
		}
	}

	private void zulpLwHhO1a(object P_0, EventArgs P_1)
	{
		oD5pwKNiSsh = true;
		dgEquip.Rows.Clear();
		oD5pwKNiSsh = false;
		if (!aLipwcEZUT5)
		{
			JO4pLxWcCtF();
		}
	}

	private void JO4pLxWcCtF()
	{
		CarregaPnRev();
		try
		{
			if (dgRevisao.SelectedRows.Count == 1)
			{
				vGqpwFpt3ms = Conversions.ToString(dgRevisao.SelectedRows[0].Cells[0].Value);
				tbRev.Text = vGqpwFpt3ms;
				oD5pwKNiSsh = true;
				dgEquip.Rows.Clear();
				oD5pwKNiSsh = false;
				int num = Information.UBound(q8ApwM1j4SR);
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					if (Operators.CompareString(q8ApwM1j4SR[i].revisao, vGqpwFpt3ms, TextCompare: true) == 0)
					{
						dgEquip.Rows.Add(q8ApwM1j4SR[i].painel, Dicionario.BuscaNomeDoPainel(q8ApwM1j4SR[i].painel), i);
					}
				}
			}
			AtualizaDGEquip();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void CarregaPnRev()
	{
		q8ApwM1j4SR = new DeclaracoesFiacao.structurePnRev[1];
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		try
		{
			if (Information.UBound(K4UpwOeQDfM) > 0)
			{
				int num = Information.UBound(K4UpwOeQDfM);
				for (int i = num; i >= 1; i = checked(i + -1))
				{
					cDadosAccessInterligacao3.CarregaPnRev(K4UpwOeQDfM[i].revisao, ref q8ApwM1j4SR);
				}
			}
			AtualizaDGRevisao();
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
			cDadosAccessInterligacao3.fechaConexao();
		}
	}

	private void fxNpLbIyglU(object P_0, EventArgs P_1)
	{
		hXJpLM8XJ2G();
	}

	private void hXJpLM8XJ2G()
	{
		List<string> lCabosUsados = new List<string>();
		List<string> lCabos = new List<string>();
		int num = 0;
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		checked
		{
			try
			{
				if (dgEquip.SelectedRows.Count != 0)
				{
					if (!CKApenasCabosUsados.Checked)
					{
						cDadosAccessInterligacao3.LeTodosCabos(ref lCabosUsados);
					}
					else
					{
						cDadosAccessInterligacao3.LeTodosCabosUsados(ref lCabosUsados);
					}
					if (CKNaoRepeteOsCabos.Checked)
					{
						Relatorios_CabosChesfDWG.BuscaCabosDoRelatorioCabosChesf(ref lCabos, vGqpwFpt3ms);
					}
					List<int> list = new List<int>();
					int num2 = dgEquip.RowCount - 1;
					for (int i = 0; i <= num2; i++)
					{
						if (dgEquip.Rows[i].Selected)
						{
							list.Add(Conversions.ToInteger(dgEquip.Rows[i].Cells[0].Value));
						}
					}
					string u7opw2aqakS = U7opw2aqakS;
					if (Operators.CompareString(u7opw2aqakS, "ELÉTRON", TextCompare: true) != 0)
					{
						if (Operators.CompareString(u7opw2aqakS, "ENERGISA", TextCompare: true) != 0)
						{
							if (Operators.CompareString(u7opw2aqakS, "ELETROSUL", TextCompare: true) != 0)
							{
								if (Operators.CompareString(u7opw2aqakS, "CHESF", TextCompare: true) != 0)
								{
									if (Operators.CompareString(u7opw2aqakS, "EDP ES", TextCompare: true) != 0)
									{
										if (Operators.CompareString(u7opw2aqakS, "TAESA", TextCompare: true) != 0)
										{
											if (Operators.CompareString(u7opw2aqakS, "CEMIG-D", TextCompare: true) != 0)
											{
												if (Operators.CompareString(u7opw2aqakS, "ENEL-SP", TextCompare: true) != 0)
												{
													goto IL_0189;
												}
												NZhpwIPE8qw = new DeclaracoesInterligacao.structureCabo[1];
												formataDGCabosENEL();
												cDadosAccessInterligacao3.CarregaCabosENEL(vGqpwFpt3ms, list, ref NZhpwIPE8qw, bRepeteCapo: false, lCabosUsados);
												if (Information.UBound(NZhpwIPE8qw) != 0)
												{
													int num3 = Information.UBound(NZhpwIPE8qw);
													for (int j = 1; j <= num3; j++)
													{
														if (Operators.CompareString(NZhpwIPE8qw[j].Tag, "", TextCompare: true) == 0)
														{
															continue;
														}
														string tag = NZhpwIPE8qw[j].Tag;
														int num4 = 1;
														string text = "";
														int num5 = Strings.Len(tag);
														for (int k = num5; k >= 1; k += -1)
														{
															string expression = Strings.Mid(tag, k, 1);
															if (!Versioned.IsNumeric(expression))
															{
																break;
															}
															if (num4 <= 3)
															{
																text = Strings.Mid(tag, k, 1) + text;
																num4++;
															}
														}
														if (Operators.CompareString(text, "", TextCompare: true) == 0)
														{
															text = tag;
														}
														dgCabos.Rows.Add(text, NZhpwIPE8qw[j].Tag, NZhpwIPE8qw[j].Formacao, NZhpwIPE8qw[j].Origem, NZhpwIPE8qw[j].Destino, NZhpwIPE8qw[j].Funcao, NZhpwIPE8qw[j].Comprimento);
													}
													int num6 = dgCabos.Rows.Count - 2;
													for (int l = num6; l >= 0; l += -1)
													{
														int num7 = l;
														for (int m = 0; m <= num7; m++)
														{
															if (!(Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dgCabos[0, m].Value)) & Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dgCabos[0, m + 1].Value))))
															{
																if (Operators.ConditionalCompareObjectGreater(dgCabos[0, m].Value, dgCabos[0, m + 1].Value, TextCompare: true))
																{
																	int num8 = 0;
																	do
																	{
																		object objectValue = RuntimeHelpers.GetObjectValue(dgCabos[num8, m + 1].Value);
																		dgCabos[num8, m + 1].Value = RuntimeHelpers.GetObjectValue(dgCabos[num8, m].Value);
																		dgCabos[num8, m].Value = RuntimeHelpers.GetObjectValue(objectValue);
																		num8++;
																	}
																	while (num8 <= 6);
																}
															}
															else if (Conversions.ToInteger(dgCabos[0, m].Value) > Conversions.ToInteger(dgCabos[0, m + 1].Value))
															{
																int num9 = 0;
																do
																{
																	object objectValue = RuntimeHelpers.GetObjectValue(dgCabos[num9, m + 1].Value);
																	dgCabos[num9, m + 1].Value = RuntimeHelpers.GetObjectValue(dgCabos[num9, m].Value);
																	dgCabos[num9, m].Value = RuntimeHelpers.GetObjectValue(objectValue);
																	num9++;
																}
																while (num9 <= 6);
															}
														}
													}
													num = dgCabos.RowCount;
													AtualizaDGCabosENEL();
													goto IL_0189;
												}
											}
											else
											{
												CaGpw8bQ1Z3 = new Relatorios_CabosEnergisaDWG.structureRelatCabosEnergisa[1];
												FormataDGCabosCEMIG_D();
												cDadosAccessInterligacao3.CarregaCabosEnergisa(vGqpwFpt3ms, list, ref CaGpw8bQ1Z3, lCabosUsados);
												if (Information.UBound(CaGpw8bQ1Z3) != 0)
												{
													int num10 = Information.UBound(CaGpw8bQ1Z3);
													for (int n = 1; n <= num10; n++)
													{
														if (Operators.CompareString(CaGpw8bQ1Z3[n].Instrucao.Trim(), "", TextCompare: true) == 0)
														{
															CaGpw8bQ1Z3[n].Instrucao = "-";
														}
														if (Operators.CompareString(CaGpw8bQ1Z3[n].sVeiasLivres.Trim(), "0", TextCompare: true) == 0)
														{
															CaGpw8bQ1Z3[n].sVeiasLivres = "-";
														}
														if (Operators.CompareString(CaGpw8bQ1Z3[n].sVeiasUsadas.Trim(), "0", TextCompare: true) == 0)
														{
															CaGpw8bQ1Z3[n].sVeiasUsadas = "-";
														}
													}
													int num11 = Information.UBound(CaGpw8bQ1Z3);
													for (int num12 = 1; num12 <= num11; num12++)
													{
														string text2 = CaGpw8bQ1Z3[num12].Formacao.ToUpper();
														text2 = text2.Replace("(", "");
														text2 = text2.Replace(")", "");
														string[] array = text2.Split('X');
														text2 = clsTextos.TiraNothing(array[1]);
														CaGpw8bQ1Z3[num12].Formacao = text2;
														int num13 = 0;
														if (Versioned.IsNumeric(CaGpw8bQ1Z3[num12].sVeiasUsadas))
														{
															num13 = Conversions.ToInteger(CaGpw8bQ1Z3[num12].sVeiasUsadas);
														}
														if (Versioned.IsNumeric(CaGpw8bQ1Z3[num12].sVeiasLivres))
														{
															num13 += Conversions.ToInteger(CaGpw8bQ1Z3[num12].sVeiasLivres);
														}
														if (Operators.CompareString(clsTextos.TiraNothing(CaGpw8bQ1Z3[num12].sBlindagem).ToUpper(), "SIM", TextCompare: true) != 0)
														{
															CaGpw8bQ1Z3[num12].sObs = "";
														}
														else
														{
															CaGpw8bQ1Z3[num12].sObs = "BLINDADO";
														}
														dgCabos.Rows.Add(vGqpwFpt3ms, "", CaGpw8bQ1Z3[num12].Tag, CaGpw8bQ1Z3[num12].Funcao, CaGpw8bQ1Z3[num12].sPn1, CaGpw8bQ1Z3[num12].sPn2, CaGpw8bQ1Z3[num12].Comprimento, text2, num13, CaGpw8bQ1Z3[num12].sVeiasUsadas, "", CaGpw8bQ1Z3[num12].sObs);
													}
													num = dgCabos.RowCount;
													AtualizaDGCabosCEMIG_D();
													goto IL_0189;
												}
											}
										}
										else
										{
											NZhpwIPE8qw = new DeclaracoesInterligacao.structureCabo[1];
											formataDGCabosTaesa();
											cDadosAccessInterligacao3.CarregaCabosTaesa(vGqpwFpt3ms, list, ref NZhpwIPE8qw, bRepeteCapo: false, lCabosUsados);
											if (Information.UBound(NZhpwIPE8qw) != 0)
											{
												int num14 = 1;
												int num15 = Information.UBound(NZhpwIPE8qw);
												for (int num16 = 1; num16 <= num15; num16++)
												{
													if (NZhpwIPE8qw[num16].Pn1 != NZhpwIPE8qw[num16].Pn2)
													{
														dgCabos.Rows.Add(NZhpwIPE8qw[num16].Tag, NZhpwIPE8qw[num16].Formacao2, NZhpwIPE8qw[num16].Comprimento, NZhpwIPE8qw[num16].Funcao, NZhpwIPE8qw[num16].sDocumentos, NZhpwIPE8qw[num16].sPaginas, NZhpwIPE8qw[num16].AterrarOrigem, NZhpwIPE8qw[num16].Origem, NZhpwIPE8qw[num16].Destino, NZhpwIPE8qw[num16].AterrarDestino, NZhpwIPE8qw[num16].Trajeto, NZhpwIPE8qw[num16].revisao, "");
														num14++;
														num++;
													}
												}
												AtualizaDGCabosTaesa();
												goto IL_0189;
											}
										}
									}
									else
									{
										Hi4pw7tcX8j = new Relatorios_CabosEnergisaDWG.structureRelatCabosEnergisa[1];
										formataDGCabosEdpES();
										cDadosAccessInterligacao3.CarregaCabosEnergisa(vGqpwFpt3ms, list, ref Hi4pw7tcX8j, lCabosUsados);
										int num17 = 0;
										dS8pwa5Si1M = new Relatorios_CabosChesfDWG.structureRelatCabosEDPES[1];
										if (Information.UBound(Hi4pw7tcX8j) != 0)
										{
											int num18 = Information.UBound(Hi4pw7tcX8j);
											for (int num19 = 1; num19 <= num18; num19++)
											{
												if (Operators.CompareString(Hi4pw7tcX8j[num19].Instrucao.Trim(), "", TextCompare: true) == 0)
												{
													Hi4pw7tcX8j[num19].Instrucao = "-";
												}
												if (Operators.CompareString(Hi4pw7tcX8j[num19].sVeiasLivres.Trim(), "0", TextCompare: true) == 0)
												{
													Hi4pw7tcX8j[num19].sVeiasLivres = "-";
												}
												if (Operators.CompareString(Hi4pw7tcX8j[num19].sVeiasUsadas.Trim(), "0", TextCompare: true) == 0)
												{
													Hi4pw7tcX8j[num19].sVeiasUsadas = "-";
												}
											}
											int num20 = Information.UBound(Hi4pw7tcX8j);
											for (int num21 = 1; num21 <= num20; num21++)
											{
												string text3 = "-";
												string formacao = Hi4pw7tcX8j[num21].Formacao;
												formacao = formacao.Replace("(", "");
												formacao = formacao.Replace(")", "");
												dgCabos.Rows.Add(Hi4pw7tcX8j[num21].Tag, Hi4pw7tcX8j[num21].sPn1, Hi4pw7tcX8j[num21].sPn2, Hi4pw7tcX8j[num21].Funcao, formacao, Hi4pw7tcX8j[num21].sVeiasUsadas, Hi4pw7tcX8j[num21].sVeiasLivres, Hi4pw7tcX8j[num21].Instrucao, Hi4pw7tcX8j[num21].sBlindagem, Hi4pw7tcX8j[num21].Comprimento, text3);
												num17++;
												ref Relatorios_CabosChesfDWG.structureRelatCabosEDPES[] reference = ref dS8pwa5Si1M;
												reference = (Relatorios_CabosChesfDWG.structureRelatCabosEDPES[])Utils.CopyArray(reference, new Relatorios_CabosChesfDWG.structureRelatCabosEDPES[num17 + 1]);
												dS8pwa5Si1M[num17].Tag = Hi4pw7tcX8j[num21].Tag;
												dS8pwa5Si1M[num17].sPn1 = Hi4pw7tcX8j[num21].sPn1;
												dS8pwa5Si1M[num17].sPn2 = Hi4pw7tcX8j[num21].sPn2;
												dS8pwa5Si1M[num17].Funcao = Hi4pw7tcX8j[num21].Funcao;
												dS8pwa5Si1M[num17].Formacao = formacao;
												dS8pwa5Si1M[num17].VeiasUsadas = Hi4pw7tcX8j[num21].sVeiasUsadas;
												dS8pwa5Si1M[num17].VeiasLivres = Hi4pw7tcX8j[num21].sVeiasLivres;
												dS8pwa5Si1M[num17].isolacao = Hi4pw7tcX8j[num21].Instrucao;
												dS8pwa5Si1M[num17].Blindado = Hi4pw7tcX8j[num21].sBlindagem;
												dS8pwa5Si1M[num17].Comprimento = Hi4pw7tcX8j[num21].Comprimento;
												dS8pwa5Si1M[num17].sObs = text3;
											}
											num = dgCabos.RowCount;
											AtualizaDGCabosEDPES();
											goto IL_0189;
										}
									}
								}
								else
								{
									NZhpwIPE8qw = new DeclaracoesInterligacao.structureCabo[1];
									formataDGCabosChesf();
									cDadosAccessInterligacao3.CarregaCabos4(vGqpwFpt3ms, list, ref NZhpwIPE8qw, lCabosUsados);
									int num22 = 0;
									m5apwqeG6Yh = new Relatorios_CabosChesfDWG.structureRelatCabosChesf[1];
									if (Information.UBound(NZhpwIPE8qw) != 0)
									{
										int num23 = Information.UBound(NZhpwIPE8qw);
										for (int num24 = 1; num24 <= num23; num24++)
										{
											if (!zyfpw3f9rMv.Contains(NZhpwIPE8qw[num24].Tag) | CKRepeteOsCabos.Checked)
											{
												string text4 = "";
												if (NZhpwIPE8qw[num24].Blindagem)
												{
													text4 = "BL";
												}
												string formacao2 = NZhpwIPE8qw[num24].Formacao2;
												formacao2 = formacao2.Replace("(", "");
												formacao2 = formacao2.Replace(")", "");
												bool flag = true;
												if (CKNaoRepeteOsCabos.Checked && lCabos.Contains(NZhpwIPE8qw[num24].Tag))
												{
													flag = false;
												}
												if (flag)
												{
													dgCabos.Rows.Add(NZhpwIPE8qw[num24].Tag, formacao2, NZhpwIPE8qw[num24].Comprimento, NZhpwIPE8qw[num24].Origem, NZhpwIPE8qw[num24].Destino, text4);
													num22++;
													ref Relatorios_CabosChesfDWG.structureRelatCabosChesf[] reference2 = ref m5apwqeG6Yh;
													reference2 = (Relatorios_CabosChesfDWG.structureRelatCabosChesf[])Utils.CopyArray(reference2, new Relatorios_CabosChesfDWG.structureRelatCabosChesf[num22 + 1]);
													m5apwqeG6Yh[num22].Tag = NZhpwIPE8qw[num24].Tag;
													m5apwqeG6Yh[num22].Bitola = formacao2;
													m5apwqeG6Yh[num22].Comprimento = Conversions.ToString(NZhpwIPE8qw[num24].Comprimento);
													m5apwqeG6Yh[num22].sPn1 = NZhpwIPE8qw[num24].Origem;
													m5apwqeG6Yh[num22].sPn2 = NZhpwIPE8qw[num24].Destino;
													m5apwqeG6Yh[num22].sObs = text4;
												}
											}
										}
										num = dgCabos.RowCount;
										AtualizaDGCabosChesf();
										goto IL_0189;
									}
								}
							}
							else
							{
								NZhpwIPE8qw = new DeclaracoesInterligacao.structureCabo[1];
								formataDGCabosEletrosul();
								cDadosAccessInterligacao3.CarregaCabosEletroSul(vGqpwFpt3ms, list, ref NZhpwIPE8qw, bRepeteCapo: false, lCabosUsados);
								if (Information.UBound(NZhpwIPE8qw) != 0)
								{
									int num25 = 1;
									int num26 = Information.UBound(NZhpwIPE8qw);
									for (int num27 = 1; num27 <= num26; num27++)
									{
										if (NZhpwIPE8qw[num27].Pn1 != NZhpwIPE8qw[num27].Pn2)
										{
											dgCabos.Rows.Add(num25, NZhpwIPE8qw[num27].Tag, NZhpwIPE8qw[num27].Origem, NZhpwIPE8qw[num27].Destino, NZhpwIPE8qw[num27].Funcao, NZhpwIPE8qw[num27].Formacao2, NZhpwIPE8qw[num27].Trajeto, NZhpwIPE8qw[num27].Comprimento);
											num25++;
											num++;
											continue;
										}
										if (num27 != 1)
										{
											dgCabos.Rows.Add("", "", "", "", "", "", "", "");
											num25 = 1;
										}
										dgCabos.Rows.Add(NZhpwIPE8qw[num27].Origem, "", "", "", "", "", "", "");
										dgCabos.Rows[dgCabos.Rows.Count - 1].Cells[0].Style.Font = new System.Drawing.Font("Arial", 10f, FontStyle.Bold);
										int num28 = dgCabos.ColumnCount - 1;
										for (int num29 = 0; num29 <= num28; num29++)
										{
											dgCabos.Rows[dgCabos.Rows.Count - 1].Cells[num29].Style.BackColor = Color.LightGray;
										}
									}
									goto IL_0189;
								}
							}
						}
						else
						{
							Hi4pw7tcX8j = new Relatorios_CabosEnergisaDWG.structureRelatCabosEnergisa[1];
							formataDGCabosEnergisa();
							cDadosAccessInterligacao3.CarregaCabosEnergisa(vGqpwFpt3ms, list, ref Hi4pw7tcX8j, lCabosUsados);
							if (Information.UBound(Hi4pw7tcX8j) != 0)
							{
								int num30 = Information.UBound(Hi4pw7tcX8j);
								for (int num31 = 1; num31 <= num30; num31++)
								{
									if (Operators.CompareString(Hi4pw7tcX8j[num31].sVeiasLivres.Trim(), "0", TextCompare: true) == 0)
									{
										Hi4pw7tcX8j[num31].sVeiasLivres = "-";
									}
									if (Operators.CompareString(Hi4pw7tcX8j[num31].sVeiasUsadas.Trim(), "0", TextCompare: true) == 0)
									{
										Hi4pw7tcX8j[num31].sVeiasUsadas = "-";
									}
									dgCabos.Rows.Add(Hi4pw7tcX8j[num31].Tag, Hi4pw7tcX8j[num31].Funcao, Hi4pw7tcX8j[num31].Formacao, Hi4pw7tcX8j[num31].sVeiasUsadas, Hi4pw7tcX8j[num31].sVeiasLivres, Hi4pw7tcX8j[num31].Comprimento, Hi4pw7tcX8j[num31].sPn1, Hi4pw7tcX8j[num31].sPn2);
								}
								num = dgCabos.RowCount;
								goto IL_0189;
							}
						}
					}
					else
					{
						NZhpwIPE8qw = new DeclaracoesInterligacao.structureCabo[1];
						formataDGCabosEletron();
						cDadosAccessInterligacao3.CarregaCabos4(vGqpwFpt3ms, list, ref NZhpwIPE8qw, lCabosUsados);
						if (Information.UBound(NZhpwIPE8qw) != 0)
						{
							int num32 = Information.UBound(NZhpwIPE8qw);
							for (int num33 = 1; num33 <= num32; num33++)
							{
								dgCabos.Rows.Add(NZhpwIPE8qw[num33].Tag, NZhpwIPE8qw[num33].Formacao2, NZhpwIPE8qw[num33].Funcao, NZhpwIPE8qw[num33].AterrarOrigem, NZhpwIPE8qw[num33].Origem, NZhpwIPE8qw[num33].Destino, NZhpwIPE8qw[num33].AterrarDestino, NZhpwIPE8qw[num33].blindagem2, NZhpwIPE8qw[num33].Comprimento, NZhpwIPE8qw[num33].Trajeto);
							}
							num = dgCabos.RowCount;
							goto IL_0189;
						}
					}
				}
				goto end_IL_0014;
				IL_0189:
				Label1.Text = Conversions.ToString(Operators.ConcatenateObject(Conversions.ToString(num) + " ", DeclaracoesGeral.mMensagem[1, 514]));
				end_IL_0014:;
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
				cDadosAccessInterligacao3.fechaConexao();
			}
			xD2pLK2j6Sj();
		}
	}

	public void formataDGRevisao()
	{
		try
		{
			dgRevisao.Rows.Clear();
			dgRevisao.Columns.Clear();
			dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 752]));
			dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 753]));
			dgRevisao.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 754]));
			AtualizaDGRevisao();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, "Elétron", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			ProjectData.ClearProjectError();
		}
	}

	public void AtualizaDGRevisao()
	{
		checked
		{
			try
			{
				if (dgRevisao.Rows.Count > 0)
				{
					float num = dgRevisao.Width - 22;
					if (!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgRevisao))
					{
						num = dgRevisao.Width - 4;
					}
					dgRevisao.Columns[0].Width = (int)Math.Round(num / 3f);
					dgRevisao.Columns[1].Width = (int)Math.Round(num / 3f);
					dgRevisao.Columns[2].Width = (int)Math.Round(num / 3f);
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

	public void AtualizaDGEquip()
	{
		checked
		{
			try
			{
				if (dgEquip.Rows.Count > 0)
				{
					float num = dgEquip.Width - 22;
					if (!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgEquip))
					{
						num = dgEquip.Width - 4;
					}
					dgEquip.Columns[1].Width = (int)Math.Round(num);
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

	public void formataDGEquip()
	{
		checked
		{
			try
			{
				oD5pwKNiSsh = true;
				dgEquip.Rows.Clear();
				dgEquip.Columns.Clear();
				dgEquip.Columns.Add("", "Indice");
				dgEquip.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 748]));
				dgEquip.Columns.Add("", "ORDEM");
				float num = dgEquip.Width - 22;
				dgEquip.Columns[0].Width = 0;
				dgEquip.Columns[0].Visible = false;
				dgEquip.Columns[1].Width = (int)Math.Round(num);
				dgEquip.Columns[2].Width = 0;
				dgEquip.Columns[2].Visible = false;
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
				oD5pwKNiSsh = false;
			}
		}
	}

	public void formataDGCabosEletron()
	{
		checked
		{
			try
			{
				dgCabos.Rows.Clear();
				dgCabos.Columns.Clear();
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1415]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1285]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1244]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1243]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1241]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1242]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1243]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1414]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1412]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1413]));
				AtualizaDGCabosEletron();
				int num = dgCabos.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgCabos.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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

	public void AtualizaDGCabosEletron()
	{
		checked
		{
			try
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgCabos)) ? ((double)(dgCabos.Width - 4)) : ((double)(dgCabos.Width - 21)));
				int num2 = 14;
				if (!cbComprimento.Checked)
				{
					dgCabos.Columns[8].Visible = false;
					dgCabos.Columns[8].Width = 0;
				}
				else
				{
					dgCabos.Columns[8].Visible = true;
					num2 += 2;
				}
				if (!cbTrajeto.Checked)
				{
					dgCabos.Columns[9].Visible = false;
					dgCabos.Columns[9].Width = 0;
				}
				else
				{
					dgCabos.Columns[9].Visible = true;
					num2 += 4;
				}
				dgCabos.Columns[0].Width = (int)Math.Round(num * 2.0 / (double)num2);
				dgCabos.Columns[1].Width = (int)Math.Round(num * 1.0 / (double)num2);
				dgCabos.Columns[2].Width = (int)Math.Round(num * 4.0 / (double)num2);
				dgCabos.Columns[3].Width = (int)Math.Round(num * 1.0 / (double)num2);
				dgCabos.Columns[4].Width = (int)Math.Round(num * 2.0 / (double)num2);
				dgCabos.Columns[5].Width = (int)Math.Round(num * 2.0 / (double)num2);
				dgCabos.Columns[6].Width = (int)Math.Round(num * 1.0 / (double)num2);
				dgCabos.Columns[7].Width = (int)Math.Round(num * 1.0 / (double)num2);
				if (cbComprimento.Checked)
				{
					dgCabos.Columns[8].Width = (int)Math.Round(num * 2.0 / (double)num2);
				}
				if (cbTrajeto.Checked)
				{
					dgCabos.Columns[9].Width = (int)Math.Round(num * 4.0 / (double)num2);
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

	public void formataDGCabosEnergisa()
	{
		checked
		{
			try
			{
				dgCabos.Rows.Clear();
				dgCabos.Columns.Clear();
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1415]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1244]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1285]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1595]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1596]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1597]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1241]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1242]));
				AtualizaDGCabosEnergisa();
				int num = dgCabos.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgCabos.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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

	public void AtualizaDGCabosEnergisa()
	{
		checked
		{
			try
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgCabos)) ? ((double)(dgCabos.Width - 4)) : ((double)(dgCabos.Width - 21)));
				dgCabos.Columns[0].Width = (int)Math.Round(num * 2.0 / 16.0);
				dgCabos.Columns[1].Width = (int)Math.Round(num * 3.0 / 16.0);
				dgCabos.Columns[2].Width = (int)Math.Round(num * 2.0 / 16.0);
				dgCabos.Columns[3].Width = (int)Math.Round(num * 1.0 / 16.0);
				dgCabos.Columns[4].Width = (int)Math.Round(num * 1.0 / 16.0);
				dgCabos.Columns[5].Width = (int)Math.Round(num * 1.0 / 16.0);
				dgCabos.Columns[6].Width = (int)Math.Round(num * 3.0 / 16.0);
				dgCabos.Columns[7].Width = (int)Math.Round(num * 3.0 / 16.0);
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

	public void formataDGCabosEletrosul()
	{
		checked
		{
			try
			{
				dgCabos.Rows.Clear();
				dgCabos.Columns.Clear();
				dgCabos.Columns.Add("", "#");
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1288]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1241]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1242]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1623]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1285]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1624]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1597]));
				AtualizaDGCabosEletrosul();
				int num = dgCabos.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgCabos.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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

	public void AtualizaDGCabosEletrosul()
	{
		checked
		{
			try
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgCabos)) ? ((double)(dgCabos.Width - 4)) : ((double)(dgCabos.Width - 21)));
				dgCabos.Columns[0].Width = (int)Math.Round(num * 0.13);
				dgCabos.Columns[1].Width = (int)Math.Round(num * 0.1);
				dgCabos.Columns[2].Width = (int)Math.Round(num * 0.1);
				dgCabos.Columns[3].Width = (int)Math.Round(num * 0.1);
				dgCabos.Columns[4].Width = (int)Math.Round(num * 0.3);
				dgCabos.Columns[5].Width = (int)Math.Round(num * 0.1);
				dgCabos.Columns[6].Width = (int)Math.Round(num * 0.1);
				dgCabos.Columns[7].Width = (int)Math.Round(num * 0.07);
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

	public void formataDGCabosChesf()
	{
		checked
		{
			try
			{
				dgCabos.Rows.Clear();
				dgCabos.Columns.Clear();
				dgCabos.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1083].ToString().ToUpper() + "\r\n" + DeclaracoesGeral.mMensagem[1, 1288].ToString().ToUpper());
				dgCabos.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1669].ToString().ToUpper() + "\r\n(mm²)");
				dgCabos.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1246].ToString().ToUpper() + "\r\n(m)");
				dgCabos.Columns.Add("", DeclaracoesGeral.mMensagem[1, 48].ToString().ToUpper());
				dgCabos.Columns.Add("", DeclaracoesGeral.mMensagem[1, 49].ToString().ToUpper());
				dgCabos.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1670].ToString().ToUpper());
				AtualizaDGCabosChesf();
				int num = dgCabos.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgCabos.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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

	public void formataDGCabosEdpES()
	{
		checked
		{
			try
			{
				dgCabos.Rows.Clear();
				dgCabos.Columns.Clear();
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 371]));
				dgCabos.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1241].ToString().ToUpper());
				dgCabos.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1242].ToString().ToUpper());
				dgCabos.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1244].ToString().ToUpper());
				dgCabos.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1285].ToString().ToUpper());
				dgCabos.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1445].ToString().ToUpper() + "\r\n" + DeclaracoesGeral.mMensagem[1, 1798].ToString().ToUpper());
				dgCabos.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1445].ToString().ToUpper() + "\r\n" + DeclaracoesGeral.mMensagem[1, 1799].ToString().ToUpper());
				dgCabos.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1800].ToString().ToUpper() + "\r\n" + DeclaracoesGeral.mMensagem[1, 1801].ToString());
				dgCabos.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1802].ToString().ToUpper());
				dgCabos.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1246].ToString().ToUpper() + "\r\n(m)");
				dgCabos.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1803].ToString().ToUpper());
				AtualizaDGCabosEDPES();
				int num = dgCabos.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgCabos.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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

	public void AtualizaDGCabosChesf()
	{
		checked
		{
			try
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgCabos)) ? ((double)(dgCabos.Width - 4)) : ((double)(dgCabos.Width - 21)));
				dgCabos.Columns[0].Width = (int)Math.Round(num * 0.1);
				dgCabos.Columns[1].Width = (int)Math.Round(num * 0.1);
				dgCabos.Columns[2].Width = (int)Math.Round(num * 0.15);
				dgCabos.Columns[3].Width = (int)Math.Round(num * 0.3);
				dgCabos.Columns[4].Width = (int)Math.Round(num * 0.3);
				dgCabos.Columns[5].Width = (int)Math.Round(num * 0.05);
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

	public void AtualizaDGCabosEDPES()
	{
		checked
		{
			try
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgCabos)) ? ((double)(dgCabos.Width - 4)) : ((double)(dgCabos.Width - 21)));
				dgCabos.Columns[0].Width = (int)Math.Round(num * 0.09);
				dgCabos.Columns[1].Width = (int)Math.Round(num * 0.09);
				dgCabos.Columns[2].Width = (int)Math.Round(num * 0.09);
				dgCabos.Columns[3].Width = (int)Math.Round(num * 0.09);
				dgCabos.Columns[4].Width = (int)Math.Round(num * 0.09);
				dgCabos.Columns[5].Width = (int)Math.Round(num * 0.09);
				dgCabos.Columns[6].Width = (int)Math.Round(num * 0.09);
				dgCabos.Columns[7].Width = (int)Math.Round(num * 0.09);
				dgCabos.Columns[8].Width = (int)Math.Round(num * 0.09);
				dgCabos.Columns[9].Width = (int)Math.Round(num * 0.09);
				dgCabos.Columns[10].Width = (int)Math.Round(num * 0.09);
				foreach (DataGridViewRow item in (IEnumerable)dgCabos.Rows)
				{
					dgCabos.Rows[item.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

	public void formataDGCabosTaesa()
	{
		checked
		{
			try
			{
				dgCabos.Rows.Clear();
				dgCabos.Columns.Clear();
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1288]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1285]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1625]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1244]));
				dgCabos.Columns.Add("", Conversions.ToString(Operators.ConcatenateObject("Nº ", DeclaracoesGeral.mMensagem[1, 373])));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1665]));
				dgCabos.Columns.Add("", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1243], " ("), DeclaracoesGeral.mMensagem[1, 1241]), ")")));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1241]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1242]));
				dgCabos.Columns.Add("", Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1243], " ("), DeclaracoesGeral.mMensagem[1, 1242]), ")")));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1624]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 380]));
				dgCabos.Columns.Add("", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1670]));
				AtualizaDGCabosTaesa();
				int num = dgCabos.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgCabos.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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

	public void AtualizaDGCabosTaesa()
	{
		checked
		{
			try
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgCabos)) ? ((double)(dgCabos.Width - 4)) : ((double)(dgCabos.Width - 21)));
				dgCabos.Columns[0].Width = (int)Math.Round(num * 0.15);
				dgCabos.Columns[1].Width = (int)Math.Round(num * 0.05);
				dgCabos.Columns[2].Width = (int)Math.Round(num * 0.05);
				dgCabos.Columns[3].Width = (int)Math.Round(num * 0.07);
				dgCabos.Columns[4].Width = (int)Math.Round(num * 0.1);
				dgCabos.Columns[5].Width = (int)Math.Round(num * 0.04);
				dgCabos.Columns[6].Width = (int)Math.Round(num * 0.04);
				dgCabos.Columns[7].Width = (int)Math.Round(num * 0.07);
				dgCabos.Columns[8].Width = (int)Math.Round(num * 0.07);
				dgCabos.Columns[9].Width = (int)Math.Round(num * 0.04);
				dgCabos.Columns[10].Width = (int)Math.Round(num * 0.24);
				dgCabos.Columns[11].Width = (int)Math.Round(num * 0.04);
				dgCabos.Columns[12].Width = (int)Math.Round(num * 0.04);
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

	public void FormataDGCabosCEMIG_D()
	{
		checked
		{
			try
			{
				dgCabos.Rows.Clear();
				dgCabos.Columns.Clear();
				dgCabos.Columns.Add("", "REV");
				dgCabos.Columns.Add("", "ETAPA / AMPL.");
				dgCabos.Columns.Add("", "NÚMERO DO CABO");
				dgCabos.Columns.Add("", "FINALIDADE");
				dgCabos.Columns.Add("", "PONTO DE PARTIDA");
				dgCabos.Columns.Add("", "PONTO FINAL   ");
				dgCabos.Columns.Add("", "COMPRIMENTO APROXIMADO (m)");
				dgCabos.Columns.Add("", "BITOLA (mm²)");
				dgCabos.Columns.Add("", "TOTAL CABO");
				dgCabos.Columns.Add("", "OCUPADOS");
				dgCabos.Columns.Add("", "TIPO");
				dgCabos.Columns.Add("", "OBSERVAÇÕES");
				AtualizaDGCabosCEMIG_D();
				int num = dgCabos.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgCabos.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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

	public void AtualizaDGCabosCEMIG_D()
	{
		checked
		{
			try
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgCabos)) ? ((double)(dgCabos.Width - 4)) : ((double)(dgCabos.Width - 21)));
				dgCabos.Columns[0].Width = (int)Math.Round(num / 12.0);
				dgCabos.Columns[1].Width = (int)Math.Round(num / 12.0);
				dgCabos.Columns[2].Width = (int)Math.Round(num / 12.0);
				dgCabos.Columns[3].Width = (int)Math.Round(num / 12.0);
				dgCabos.Columns[4].Width = (int)Math.Round(num / 12.0);
				dgCabos.Columns[5].Width = (int)Math.Round(num / 12.0);
				dgCabos.Columns[6].Width = (int)Math.Round(num / 12.0);
				dgCabos.Columns[7].Width = (int)Math.Round(num / 12.0);
				dgCabos.Columns[8].Width = (int)Math.Round(num / 12.0);
				dgCabos.Columns[9].Width = (int)Math.Round(num / 12.0);
				dgCabos.Columns[10].Width = (int)Math.Round(num / 12.0);
				dgCabos.Columns[11].Width = (int)Math.Round(num / 12.0);
				foreach (DataGridViewRow item in (IEnumerable)dgCabos.Rows)
				{
					dgCabos.Rows[item.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

	public void formataDGCabosENEL()
	{
		checked
		{
			try
			{
				dgCabos.Rows.Clear();
				dgCabos.Columns.Clear();
				dgCabos.Columns.Add("", "ORDEM");
				dgCabos.Columns.Add("", "Nº " + DeclaracoesGeral.mMensagem[1, 1288].ToString().ToUpper());
				dgCabos.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1669].ToString().ToUpper() + " mm²");
				dgCabos.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1241].ToString().ToUpper());
				dgCabos.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1242].ToString().ToUpper());
				dgCabos.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1244].ToString().ToUpper());
				dgCabos.Columns.Add("", DeclaracoesGeral.mMensagem[1, 1246].ToString().ToUpper());
				AtualizaDGCabosENEL();
				int num = dgCabos.Columns.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					dgCabos.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
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

	public void AtualizaDGCabosENEL()
	{
		checked
		{
			try
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dgCabos)) ? ((double)(dgCabos.Width - 4)) : ((double)(dgCabos.Width - 21)));
				dgCabos.Columns[0].Width = 0;
				dgCabos.Columns[0].Visible = false;
				dgCabos.Columns[1].Width = (int)Math.Round(num * 0.15);
				dgCabos.Columns[2].Width = (int)Math.Round(num * 0.1);
				dgCabos.Columns[3].Width = (int)Math.Round(num * 0.22);
				dgCabos.Columns[4].Width = (int)Math.Round(num * 0.22);
				dgCabos.Columns[5].Width = (int)Math.Round(num * 0.21);
				dgCabos.Columns[6].Width = (int)Math.Round(num * 0.1);
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

	private void eKepLOVib5Y(object P_0, EventArgs P_1)
	{
		if (Information.IsNothing(NZhpwIPE8qw) || Information.UBound(NZhpwIPE8qw) == 0)
		{
			return;
		}
		btExportaEXCEL.Enabled = false;
		string u7opw2aqakS = U7opw2aqakS;
		if (Operators.CompareString(u7opw2aqakS, "ELÉTRON", TextCompare: true) != 0)
		{
			if (Operators.CompareString(u7opw2aqakS, "ENERGISA", TextCompare: true) != 0)
			{
				if (Operators.CompareString(u7opw2aqakS, "ELETROSUL", TextCompare: true) != 0)
				{
					if (Operators.CompareString(u7opw2aqakS, "CHESF", TextCompare: true) != 0 && Operators.CompareString(u7opw2aqakS, "EDP ES", TextCompare: true) != 0)
					{
						if (Operators.CompareString(u7opw2aqakS, "TAESA", TextCompare: true) != 0)
						{
							if (Operators.CompareString(u7opw2aqakS, "CEMIG-D", TextCompare: true) != 0)
							{
								if (Operators.CompareString(u7opw2aqakS, "ENEL-SP", TextCompare: true) == 0)
								{
									Relatorios_ExcelComum_ENEL.CriaListaCabos_ENEL_EXCEL("LISTACABOS_ENEL", tbRev.Text, tbData.Text, tbDesc.Text, tbExec.Text, dgCabos);
								}
							}
							else
							{
								Relatorios_ExcelComum_CEMIG_D.preencheIndiceComumExcel("CAPA", "", tbTit1.Text, tbTit2.Text, tbTit3.Text, vGqpwFpt3ms, DeclaracoesGeral.Conf.Local, "1", 7, 42);
								Relatorios_ExcelComum_CEMIG_D.preencheIndiceComumExcel("Lista_Cabos", "", tbTit1.Text, tbTit2.Text, tbTit3.Text, vGqpwFpt3ms, DeclaracoesGeral.Conf.Local, "1", 1, 7);
								Relatorios_ExcelComum_CEMIG_D.CriaListaCabosEletronCEMIG_D_EXCEL("Lista_Cabos", dgCabos);
							}
						}
						else
						{
							NFvpwQ9A5f0 = Conversions.ToInteger(dgEquip.SelectedRows[0].Cells[0].Value);
							WSypwPsRo0g = Conversions.ToString(dgEquip.SelectedRows[0].Cells[1].Value);
							Relatorios_ListaCabosEXCEL.indiceRelatorioCabos[] mIndice = null;
							string sCaminho = "C:\\Program Files\\Eletron4\\MODELOS\\Modelo Cabos Taesa.xls";
							if (!ExcFuncoesExcel.ExisteSheet("CAPA"))
							{
								excExcelCopySheet.AddSheet(sCaminho, "CAPA", "CAPA");
								Relatorios_ExcelComum_Taesa.preencheIndiceComumExcel("CAPA", "", tbTit1.Text, tbTit2.Text, tbTit3.Text, vGqpwFpt3ms, DeclaracoesGeral.Conf.Local, "1", 29, 42);
								excExcelCopySheet.AddSheet(sCaminho, "INFO", "INFO");
								Relatorios_ExcelComum_Taesa.preencheIndiceComumExcel("INFO", "", tbTit1.Text, tbTit2.Text, tbTit3.Text, vGqpwFpt3ms, DeclaracoesGeral.Conf.Local, "2", 1, 6);
							}
							excExcelCopySheet.Delete(WSypwPsRo0g);
							excExcelCopySheet.AddSheet(sCaminho, "CABOS", WSypwPsRo0g);
							Relatorios_ExcelComum_Taesa.preencheIndiceComumExcel(WSypwPsRo0g, "", tbTit1.Text, tbTit2.Text, tbTit3.Text, vGqpwFpt3ms, DeclaracoesGeral.Conf.Local, "2", 1, 6);
							Relatorios_ExcelComum_Taesa.CriaListaCabosEletronTaesaEXCEL(WSypwPsRo0g, dgCabos, vGqpwFpt3ms, DeclaracoesGeral.Conf.Local, tbTit1.Text, tbTit2.Text, tbTit3.Text, ref mIndice);
						}
					}
				}
				else
				{
					bool flag = ExcFuncoesExcel.ExisteSheet("CAPA");
					bool flag2 = false;
					Relatorios_ListaCabosEXCEL.indiceRelatorioCabos[] mIndice2 = null;
					if (!flag)
					{
						Microsoft.Office.Interop.Excel.Application oExcelNew = null;
						Workbook oBook = null;
						Worksheet oSheet = null;
						if (!ExcFuncoesExcel.VerificaExcelAtivo(ref oExcelNew, ref oBook, ref oSheet))
						{
						}
					}
					Relatorios_ListaCabosEXCEL.CriaListaCabosEletronEletrosulEXCEL(dgCabos, vGqpwFpt3ms, DeclaracoesGeral.Conf.Local, tbTit1.Text, tbTit2.Text, tbTit3.Text, ref mIndice2);
					if (flag)
					{
						Relatorios_ExcelComum_EletroSul.preencheIndiceComumExcel(Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1667]), "", tbTit1.Text, tbTit2.Text, tbTit3.Text, vGqpwFpt3ms, DeclaracoesGeral.Conf.Local, "2");
					}
					if (flag)
					{
						flag2 = Relatorios_ListaCabosEXCEL.preencheIndiceCaboExcel(mIndice2, vGqpwFpt3ms);
					}
					if (flag & flag2)
					{
						Relatorios_ExcelComum_EletroSul.AtualizaPaginas(mIndice2);
					}
					if (flag)
					{
						Relatorios_ExcelComum_EletroSul.preencheIndiceComumExcel(Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1668]), "", tbTit1.Text, tbTit2.Text, tbTit3.Text, vGqpwFpt3ms, DeclaracoesGeral.Conf.Local, "1");
					}
				}
			}
		}
		else
		{
			Relatorios_ListaCabosEXCEL.CriaListaCabosEletronEXCEL(NZhpwIPE8qw, cbComprimento.Checked, cbTrajeto.Checked);
		}
		Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1882]), MsgBoxStyle.Information);
		btExportaEXCEL.Enabled = true;
	}

	private void J3spLIhqB4N(object P_0, EventArgs P_1)
	{
		string pag = DeclaracoesGeral.ativo.Pagina;
		string u7opw2aqakS = U7opw2aqakS;
		checked
		{
			if (Operators.CompareString(u7opw2aqakS, "ELÉTRON", TextCompare: true) != 0)
			{
				if (Operators.CompareString(u7opw2aqakS, "ENERGISA", TextCompare: true) != 0)
				{
					if (Operators.CompareString(u7opw2aqakS, "ELETROSUL", TextCompare: true) != 0)
					{
						if (Operators.CompareString(u7opw2aqakS, "CHESF", TextCompare: true) != 0)
						{
							if (Operators.CompareString(u7opw2aqakS, "EDP ES", TextCompare: true) != 0)
							{
								if (Operators.CompareString(u7opw2aqakS, "TAESA", TextCompare: true) != 0 && Operators.CompareString(u7opw2aqakS, "CEMIG-D", TextCompare: true) != 0 && Operators.CompareString(u7opw2aqakS, "ENEL-SP", TextCompare: true) != 0)
								{
								}
							}
							else
							{
								if (Information.IsNothing(dS8pwa5Si1M) || Information.UBound(dS8pwa5Si1M) == 0)
								{
									return;
								}
								int num = 0;
								dS8pwa5Si1M[0].Tag = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 371]);
								dS8pwa5Si1M[0].sPn1 = DeclaracoesGeral.mMensagem[1, 1241].ToString().ToUpper();
								dS8pwa5Si1M[0].sPn2 = DeclaracoesGeral.mMensagem[1, 1242].ToString().ToUpper();
								dS8pwa5Si1M[0].Funcao = DeclaracoesGeral.mMensagem[1, 1244].ToString().ToUpper();
								dS8pwa5Si1M[0].Formacao = DeclaracoesGeral.mMensagem[1, 1285].ToString().ToUpper();
								dS8pwa5Si1M[0].VeiasUsadas = DeclaracoesGeral.mMensagem[1, 1445].ToString().ToUpper() + "\r\n" + DeclaracoesGeral.mMensagem[1, 1798].ToString().ToUpper();
								dS8pwa5Si1M[0].VeiasLivres = DeclaracoesGeral.mMensagem[1, 1445].ToString().ToUpper() + "\r\n" + DeclaracoesGeral.mMensagem[1, 1799].ToString().ToUpper();
								dS8pwa5Si1M[0].isolacao = DeclaracoesGeral.mMensagem[1, 1800].ToString().ToUpper() + "\r\n" + DeclaracoesGeral.mMensagem[1, 1801].ToString();
								dS8pwa5Si1M[0].Blindado = DeclaracoesGeral.mMensagem[1, 1802].ToString().ToUpper();
								dS8pwa5Si1M[0].Comprimento = DeclaracoesGeral.mMensagem[1, 1246].ToString().ToUpper() + "\r\n(m)";
								dS8pwa5Si1M[0].sObs = DeclaracoesGeral.mMensagem[1, 1803].ToString().ToUpper();
								Relatorios_CabosEDPESDWG.ConfigRelatCabosEDPESDWG confRelatCabos = new Relatorios_CabosEDPESDWG.ConfigRelatCabosEDPESDWG
								{
									AlturaInicial = (int)Math.Round(Conversions.ToDouble(tbInicioY.Text)),
									AlturaDoBloco = 10.0,
									CorLinha = 7,
									CorTexto = 4,
									sFonte = "Romans",
									TamanhoFonte = Conversions.ToDouble(tbTamanhoFonte.Text)
								};
								int num2 = Information.UBound(dS8pwa5Si1M);
								for (int i = 1; i <= num2; i++)
								{
									if (Operators.CompareString(dS8pwa5Si1M[num].Tag, "", TextCompare: true) == 0)
									{
										dS8pwa5Si1M[num].Tag = "##B##";
									}
									if (Operators.CompareString(dS8pwa5Si1M[num].sPn1, "", TextCompare: true) == 0)
									{
										dS8pwa5Si1M[num].sPn1 = "##B##";
									}
									if (Operators.CompareString(dS8pwa5Si1M[num].sPn2, "", TextCompare: true) == 0)
									{
										dS8pwa5Si1M[num].sPn2 = "##B##";
									}
									if (Operators.CompareString(dS8pwa5Si1M[num].Funcao, "", TextCompare: true) == 0)
									{
										dS8pwa5Si1M[num].Funcao = "##B##";
									}
									if (Operators.CompareString(dS8pwa5Si1M[num].Formacao, "", TextCompare: true) == 0)
									{
										dS8pwa5Si1M[num].Formacao = "##B##";
									}
									if (Operators.CompareString(dS8pwa5Si1M[num].VeiasUsadas, "", TextCompare: true) == 0)
									{
										dS8pwa5Si1M[num].VeiasUsadas = "##B##";
									}
									if (Operators.CompareString(dS8pwa5Si1M[num].VeiasLivres, "", TextCompare: true) == 0)
									{
										dS8pwa5Si1M[num].VeiasLivres = "##B##";
									}
									if (Operators.CompareString(dS8pwa5Si1M[num].isolacao, "", TextCompare: true) == 0)
									{
										dS8pwa5Si1M[num].isolacao = "##B##";
									}
									if (Operators.CompareString(dS8pwa5Si1M[num].Blindado, "", TextCompare: true) == 0)
									{
										dS8pwa5Si1M[num].Blindado = "##B##";
									}
									if (Operators.CompareString(dS8pwa5Si1M[num].Comprimento, "", TextCompare: true) == 0)
									{
										dS8pwa5Si1M[num].Comprimento = "##B##";
									}
									if (Operators.CompareString(dS8pwa5Si1M[num].sObs, "", TextCompare: true) == 0)
									{
										dS8pwa5Si1M[num].sObs = "##B##";
									}
								}
								Relatorios_CabosEDPESDWG.CriaMatrizDeCabosEDPES_DWG(dS8pwa5Si1M, vGqpwFpt3ms, confRelatCabos);
							}
						}
						else
						{
							if (Information.IsNothing(m5apwqeG6Yh) || Information.UBound(m5apwqeG6Yh) == 0)
							{
								return;
							}
							m5apwqeG6Yh[0].Tag = DeclaracoesGeral.mMensagem[1, 1083].ToString().ToUpper() + "\r\n" + DeclaracoesGeral.mMensagem[1, 1288].ToString().ToUpper();
							m5apwqeG6Yh[0].Bitola = DeclaracoesGeral.mMensagem[1, 1669].ToString().ToUpper() + "\r\n(mm²)";
							m5apwqeG6Yh[0].Comprimento = DeclaracoesGeral.mMensagem[1, 1246].ToString().ToUpper() + "\r\n(m)";
							m5apwqeG6Yh[0].sPn1 = DeclaracoesGeral.mMensagem[1, 48].ToString().ToUpper();
							m5apwqeG6Yh[0].sPn2 = DeclaracoesGeral.mMensagem[1, 49].ToString().ToUpper();
							m5apwqeG6Yh[0].sObs = DeclaracoesGeral.mMensagem[1, 1670].ToString().ToUpper();
							Relatorios_CabosChesfDWG.ConfigRelatCabosChesf confRelatCabos2 = new Relatorios_CabosChesfDWG.ConfigRelatCabosChesf
							{
								DistEntreColunas = 3,
								QuantColunas = 2,
								AlturaInicial = (int)Math.Round(Conversions.ToDouble(tbInicioY.Text)),
								AlturaDoBloco = 9.0,
								CorLinha = 7,
								CorTexto = 7,
								sFonte = "Romans",
								TamanhoFonte = Conversions.ToDouble(tbTamanhoFonte.Text)
							};
							int num3 = Information.UBound(m5apwqeG6Yh);
							for (int j = 1; j <= num3; j++)
							{
								if (Operators.CompareString(m5apwqeG6Yh[j].Tag, "", TextCompare: true) == 0)
								{
									m5apwqeG6Yh[j].Tag = "##B##";
								}
								if (Operators.CompareString(m5apwqeG6Yh[j].Bitola, "", TextCompare: true) == 0)
								{
									m5apwqeG6Yh[j].Bitola = "##B##";
								}
								if (Operators.CompareString(m5apwqeG6Yh[j].Comprimento, "", TextCompare: true) == 0)
								{
									m5apwqeG6Yh[j].Comprimento = "##B##";
								}
								if (Operators.CompareString(m5apwqeG6Yh[j].sPn1, "", TextCompare: true) == 0)
								{
									m5apwqeG6Yh[j].sPn1 = "##B##";
								}
								if (Operators.CompareString(m5apwqeG6Yh[j].sPn2, "", TextCompare: true) == 0)
								{
									m5apwqeG6Yh[j].sPn2 = "##B##";
								}
								if (Operators.CompareString(m5apwqeG6Yh[j].sObs, "", TextCompare: true) == 0)
								{
									m5apwqeG6Yh[j].sObs = "##B##";
								}
								zyfpw3f9rMv.Add(m5apwqeG6Yh[j].Tag);
							}
							Relatorios_CabosChesfDWG.CriaMatrizDeCabosDWGChesf(m5apwqeG6Yh, vGqpwFpt3ms, confRelatCabos2);
						}
					}
				}
				else
				{
					if (Information.IsNothing(Hi4pw7tcX8j) || Information.UBound(Hi4pw7tcX8j) == 0)
					{
						return;
					}
					Hi4pw7tcX8j[0].Tag = DeclaracoesGeral.mMensagem[1, 1415].ToString().ToUpper();
					Hi4pw7tcX8j[0].Funcao = DeclaracoesGeral.mMensagem[1, 1244].ToString().ToUpper();
					Hi4pw7tcX8j[0].Formacao = DeclaracoesGeral.mMensagem[1, 1285].ToString().ToUpper();
					Hi4pw7tcX8j[0].sVeiasUsadas = DeclaracoesGeral.mMensagem[1, 1595].ToString().ToUpper();
					Hi4pw7tcX8j[0].sVeiasLivres = DeclaracoesGeral.mMensagem[1, 1596].ToString().ToUpper();
					Hi4pw7tcX8j[0].Comprimento = DeclaracoesGeral.mMensagem[1, 1597].ToString().ToUpper();
					Hi4pw7tcX8j[0].sPn1 = DeclaracoesGeral.mMensagem[1, 1241].ToString().ToUpper();
					Hi4pw7tcX8j[0].sPn2 = DeclaracoesGeral.mMensagem[1, 1242].ToString().ToUpper();
					Relatorios_CabosEnergisaDWG.ConfigRelatCabosEnergisa confRelatCabos3 = new Relatorios_CabosEnergisaDWG.ConfigRelatCabosEnergisa
					{
						DistEntreColunas = 3,
						QuantColunas = 2,
						AlturaInicial = (int)Math.Round(Conversions.ToDouble(tbInicioY.Text)),
						AlturaDoBloco = 9.3,
						CorLinha = 6,
						CorTexto = 7,
						sFonte = "Romans",
						TamanhoFonte = Conversions.ToDouble(tbTamanhoFonte.Text)
					};
					int num4 = Information.UBound(Hi4pw7tcX8j);
					for (int k = 1; k <= num4; k++)
					{
						if (Operators.CompareString(Hi4pw7tcX8j[k].Tag, "", TextCompare: true) == 0)
						{
							Hi4pw7tcX8j[k].Tag = "##B##";
						}
						if (Operators.CompareString(Hi4pw7tcX8j[k].Funcao, "", TextCompare: true) == 0)
						{
							Hi4pw7tcX8j[k].Funcao = "##B##";
						}
						if (Operators.CompareString(Hi4pw7tcX8j[k].Formacao, "", TextCompare: true) == 0)
						{
							Hi4pw7tcX8j[k].Formacao = "##B##";
						}
						if (Operators.CompareString(Hi4pw7tcX8j[k].sVeiasUsadas, "", TextCompare: true) == 0)
						{
							Hi4pw7tcX8j[k].sVeiasUsadas = "##B##";
						}
						if (Operators.CompareString(Hi4pw7tcX8j[k].sVeiasLivres, "", TextCompare: true) == 0)
						{
							Hi4pw7tcX8j[k].sVeiasLivres = "##B##";
						}
						if (Operators.CompareString(Hi4pw7tcX8j[k].Comprimento, "", TextCompare: true) == 0)
						{
							Hi4pw7tcX8j[k].Comprimento = "##B##";
						}
						if (Operators.CompareString(Hi4pw7tcX8j[k].sPn1, "", TextCompare: true) == 0)
						{
							Hi4pw7tcX8j[k].sPn1 = "##B##";
						}
						if (Operators.CompareString(Hi4pw7tcX8j[k].sPn2, "", TextCompare: true) == 0)
						{
							Hi4pw7tcX8j[k].sPn2 = "##B##";
						}
					}
					Relatorios_CabosEnergisaDWG.CriaMatrizDeCabosDWGEnergisa(Hi4pw7tcX8j, vGqpwFpt3ms, confRelatCabos3);
				}
			}
			if (Operators.CompareString(pag, DeclaracoesGeral.ativo.Pagina, TextCompare: true) != 0)
			{
				Pagina.AtivaPagina(pag);
				DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
			}
		}
	}

	private void vgPpL7uiOIR(object P_0, EventArgs P_1)
	{
		string u7opw2aqakS = U7opw2aqakS;
		if (Operators.CompareString(u7opw2aqakS, "ELÉTRON", TextCompare: true) == 0)
		{
			return;
		}
		if (Operators.CompareString(u7opw2aqakS, "ENERGISA", TextCompare: true) != 0)
		{
			if (Operators.CompareString(u7opw2aqakS, "ELETROSUL", TextCompare: true) == 0)
			{
				return;
			}
			if (Operators.CompareString(u7opw2aqakS, "CHESF", TextCompare: true) != 0)
			{
				if (Operators.CompareString(u7opw2aqakS, "EDP ES", TextCompare: true) != 0)
				{
					if (Operators.CompareString(u7opw2aqakS, "TAESA", TextCompare: true) != 0 && Operators.CompareString(u7opw2aqakS, "CEMIG-D", TextCompare: true) != 0 && Operators.CompareString(u7opw2aqakS, "ENEL-SP", TextCompare: true) == 0)
					{
					}
				}
				else
				{
					Relatorios_CabosEDPESDWG.ApagaRelatorioCabosEDPES(vGqpwFpt3ms);
				}
			}
			else
			{
				Relatorios_CabosChesfDWG.ApagaRelatorioCabosChesf(vGqpwFpt3ms);
				zyfpw3f9rMv.Clear();
			}
		}
		else
		{
			Relatorios_CabosEnergisaDWG.ApagaRelatorioCabosEnergisa(vGqpwFpt3ms);
		}
	}

	private void lLspLq9igxe()
	{
		//IL_04c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_052f: Unknown result type (might be due to invalid IL or missing references)
		string u7opw2aqakS = U7opw2aqakS;
		if (Operators.CompareString(u7opw2aqakS, "ELÉTRON", TextCompare: true) != 0)
		{
			if (Operators.CompareString(u7opw2aqakS, "ENERGISA", TextCompare: true) != 0)
			{
				if (Operators.CompareString(u7opw2aqakS, "ELETROSUL", TextCompare: true) != 0)
				{
					if (Operators.CompareString(u7opw2aqakS, "CHESF", TextCompare: true) != 0)
					{
						if (Operators.CompareString(u7opw2aqakS, "EDP ES", TextCompare: true) != 0)
						{
							if (Operators.CompareString(u7opw2aqakS, "TAESA", TextCompare: true) != 0)
							{
								if (Operators.CompareString(u7opw2aqakS, "CEMIG-D", TextCompare: true) != 0)
								{
									if (Operators.CompareString(u7opw2aqakS, "ENEL-SP", TextCompare: true) == 0)
									{
										GroupBox2.Enabled = false;
										GroupBox3.Enabled = false;
										GroupBox4.Enabled = false;
										GroupBox5.Location = GroupBox4.Location;
										GroupBox5.Visible = true;
										GroupBox5.Enabled = true;
										GroupBox7.Visible = false;
										btModeloEletrosul.Visible = false;
										btExportaEXCEL.Visible = true;
										btExportaDWG.Visible = false;
										btApagar.Visible = false;
										formataDGCabosENEL();
										LTTpLaBLANj(_0020: false);
									}
								}
								else
								{
									GroupBox2.Enabled = false;
									GroupBox3.Enabled = false;
									GroupBox4.Enabled = true;
									GroupBox5.Visible = false;
									GroupBox7.Visible = false;
									btModeloEletrosul.Visible = true;
									btExportaEXCEL.Visible = true;
									btExportaDWG.Visible = false;
									btApagar.Visible = false;
									string sHandle = ((object)DeclaracoesGeral.blockFormatoID.Handle/*cast due to constrained. prefix*/).ToString();
									string left = clsBlocos.LeUmAtributoDeUmBloco(ref sHandle, "SUBESTACAO");
									if (Operators.CompareString(left, "", TextCompare: true) == 0)
									{
										sHandle = ((object)DeclaracoesGeral.blockFormatoID.Handle/*cast due to constrained. prefix*/).ToString();
										left = clsBlocos.LeUmAtributoDeUmBloco(ref sHandle, "SUBESTAÇÃO");
									}
									tbTit1.Text = left;
									tbTit2.Text = "";
									FormataDGCabosCEMIG_D();
									LTTpLaBLANj(_0020: false);
								}
							}
							else
							{
								GroupBox2.Enabled = false;
								GroupBox3.Enabled = false;
								GroupBox4.Enabled = true;
								GroupBox5.Visible = false;
								GroupBox7.Visible = false;
								btModeloEletrosul.Visible = true;
								btExportaEXCEL.Visible = true;
								btExportaDWG.Visible = false;
								btApagar.Visible = false;
								tbTit1.Text = "";
								tbTit2.Text = "";
								tbTit3.Text = "LISTA DE CABOS";
								btModeloEletrosul.Visible = false;
								formataDGCabosTaesa();
								LTTpLaBLANj(_0020: false);
							}
						}
						else
						{
							GroupBox2.Enabled = false;
							GroupBox3.Enabled = true;
							tbInicioY.Text = Conversions.ToString(Relatorios_CabosEDPESDWG.BuscaAlturadaRegua());
							tbTamanhoFonte.Text = Conversions.ToString(2);
							GroupBox4.Enabled = false;
							GroupBox5.Visible = false;
							GroupBox7.Visible = false;
							btModeloEletrosul.Visible = false;
							btExportaEXCEL.Visible = false;
							btExportaDWG.Visible = true;
							btApagar.Visible = true;
							formataDGCabosEdpES();
							LTTpLaBLANj(_0020: false);
						}
					}
					else
					{
						GroupBox2.Enabled = false;
						GroupBox3.Enabled = true;
						GroupBox4.Enabled = false;
						GroupBox5.Visible = false;
						GroupBox7.Location = GroupBox4.Location;
						GroupBox7.Visible = true;
						GroupBox7.Enabled = true;
						btModeloEletrosul.Visible = false;
						btExportaEXCEL.Visible = false;
						btExportaDWG.Visible = true;
						btApagar.Visible = true;
						formataDGCabosChesf();
						LTTpLaBLANj(_0020: false);
					}
				}
				else
				{
					GroupBox2.Enabled = false;
					GroupBox3.Enabled = false;
					GroupBox4.Enabled = true;
					GroupBox5.Visible = false;
					GroupBox7.Visible = false;
					btModeloEletrosul.Visible = true;
					btExportaEXCEL.Visible = true;
					btExportaDWG.Visible = false;
					btApagar.Visible = false;
					tbTit1.Text = "ELETROSUL CENTRAIS ELÉTRICAS S.A.";
					tbTit2.Text = "";
					tbTit3.Text = "LISTA DE CABOS DE FORÇA E CONTROLE";
					formataDGCabosEletrosul();
					LTTpLaBLANj(_0020: true);
				}
			}
			else
			{
				GroupBox2.Enabled = false;
				GroupBox3.Enabled = true;
				GroupBox4.Enabled = false;
				GroupBox5.Visible = false;
				GroupBox7.Visible = false;
				btModeloEletrosul.Visible = false;
				btExportaEXCEL.Visible = false;
				btExportaDWG.Visible = true;
				btApagar.Visible = true;
				formataDGCabosEnergisa();
				LTTpLaBLANj(_0020: false);
			}
		}
		else
		{
			GroupBox2.Enabled = true;
			GroupBox3.Enabled = false;
			GroupBox4.Enabled = false;
			GroupBox5.Visible = false;
			GroupBox7.Visible = false;
			btModeloEletrosul.Visible = false;
			btExportaEXCEL.Visible = true;
			btExportaDWG.Visible = false;
			btApagar.Visible = false;
			formataDGCabosEletron();
			LTTpLaBLANj(_0020: false);
		}
		hXJpLM8XJ2G();
	}

	private void LTTpLaBLANj(bool P_0)
	{
		Size minimumSize = new Size(100, 400);
		DeclaracoesGeral._pspag.MinimumSize = minimumSize;
		if (!P_0)
		{
			btPrimeiro.Visible = false;
			btCima.Visible = false;
			btBaixo.Visible = false;
			btUltimo.Visible = false;
			dgEquip.Size = new Size(dgEquip.Size.Width, dgCabos.Size.Height);
		}
		else
		{
			btPrimeiro.Visible = true;
			btCima.Visible = true;
			btBaixo.Visible = true;
			btUltimo.Visible = true;
			dgEquip.Size = new Size(dgEquip.Size.Width, checked(dgCabos.Size.Height - 20));
		}
	}

	private void r4NpL89xgBZ(object P_0, EventArgs P_1)
	{
		Hide();
		C8lpLN7SHge();
		Show();
	}

	private void C8lpLN7SHge()
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Invalid comparison between Unknown and I4
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			_ = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			PromptPointResult val2 = (PromptPointResult)NewLateBinding.LateGet(editor, null, "GetPoint", new object[1] { Operators.ConcatenateObject("\r\n", DeclaracoesGeral.mMensagem[1, 1029]) }, null, null, null);
			if ((int)((PromptResult)val2).Status != -5002)
			{
				TextBox textBox = tbInicioY;
				Point3d value = val2.Value;
				textBox.Text = Math.Round(value.Y, 1).ToString();
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

	private void vthpLFRwL12(object P_0, EventArgs P_1)
	{
		string u7opw2aqakS = U7opw2aqakS;
		if (Operators.CompareString(u7opw2aqakS, "ELÉTRON", TextCompare: true) == 0 || Operators.CompareString(u7opw2aqakS, "ENERGISA", TextCompare: true) == 0)
		{
			return;
		}
		if (Operators.CompareString(u7opw2aqakS, "ELETROSUL", TextCompare: true) != 0)
		{
			if (Operators.CompareString(u7opw2aqakS, "CHESF", TextCompare: true) == 0 || Operators.CompareString(u7opw2aqakS, "EDP ES", TextCompare: true) == 0 || Operators.CompareString(u7opw2aqakS, "TAESA", TextCompare: true) == 0)
			{
				return;
			}
			if (Operators.CompareString(u7opw2aqakS, "CEMIG-D", TextCompare: true) != 0)
			{
				if (Operators.CompareString(u7opw2aqakS, "ENEL-SP", TextCompare: true) == 0)
				{
				}
			}
			else
			{
				string sCaminho = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Eletron4\\Modelos\\Modelo Lista de Cabos CEMIG-D.xls";
				ExcFuncoesExcel.AbreExcelExterno(sCaminho);
			}
		}
		else
		{
			string sCaminho2 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Eletron4\\Modelos\\Modelo Cabos.xls";
			ExcFuncoesExcel.AbreExcelExterno(sCaminho2);
		}
	}

	private void bXJpLQbmQIs(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void UqxpLPosSuj(object P_0, KeyPressEventArgs P_1)
	{
		short num = checked((short)Strings.Asc(P_1.KeyChar));
		if (SIqPZjplXCyWg3yxBDTH.vXOplgmUZCR(num) == 0)
		{
			P_1.Handled = true;
		}
	}

	private void JEApLcx8mG2(object P_0, EventArgs P_1)
	{
		xD2pLK2j6Sj();
	}

	private void xD2pLK2j6Sj()
	{
		AtualizaDGEquip();
		if (dgCabos.Rows.Count <= 0)
		{
			return;
		}
		string u7opw2aqakS = U7opw2aqakS;
		if (Operators.CompareString(u7opw2aqakS, "ELÉTRON", TextCompare: true) != 0)
		{
			if (Operators.CompareString(u7opw2aqakS, "ENERGISA", TextCompare: true) != 0)
			{
				if (Operators.CompareString(u7opw2aqakS, "ELETROSUL", TextCompare: true) != 0)
				{
					if (Operators.CompareString(u7opw2aqakS, "CHESF", TextCompare: true) != 0)
					{
						if (Operators.CompareString(u7opw2aqakS, "EDP ES", TextCompare: true) != 0)
						{
							if (Operators.CompareString(u7opw2aqakS, "TAESA", TextCompare: true) != 0)
							{
								if (Operators.CompareString(u7opw2aqakS, "CEMIG-D", TextCompare: true) != 0)
								{
									if (Operators.CompareString(u7opw2aqakS, "ENEL-SP", TextCompare: true) == 0)
									{
										AtualizaDGCabosENEL();
									}
								}
								else
								{
									AtualizaDGCabosCEMIG_D();
								}
							}
							else
							{
								AtualizaDGCabosTaesa();
							}
						}
						else
						{
							AtualizaDGCabosEDPES();
						}
					}
					else
					{
						AtualizaDGCabosChesf();
					}
				}
				else
				{
					AtualizaDGCabosEletrosul();
				}
			}
			else
			{
				AtualizaDGCabosEnergisa();
			}
		}
		else
		{
			AtualizaDGCabosEletron();
		}
	}

	private void tAlpLeW4glx(object P_0, EventArgs P_1)
	{
		U7opw2aqakS = cbTipoRel.Text;
		lLspLq9igxe();
	}

	private void AywpL2MF85Q(object P_0, EventArgs P_1)
	{
		if (dgEquip.Rows.Count == 0 || Pl1pwnp2uhq)
		{
			return;
		}
		Pl1pwnp2uhq = true;
		int num = -1000;
		List<string> list = new List<string>();
		checked
		{
			int num2 = dgEquip.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (dgEquip.Rows[i].Selected)
				{
					dgEquip.Rows[i].Cells[2].Value = num;
					list.Add(Conversions.ToString(dgEquip.Rows[i].Cells[0].Value));
					num++;
					dgEquip.Rows[i].Selected = false;
				}
			}
			DataGridView dg = dgEquip;
			ordenar(ref dg);
			dgEquip = dg;
			num = 1;
			int num3 = dgEquip.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				dgEquip.Rows[j].Cells[2].Value = num;
				if (list.Contains(Conversions.ToString(dgEquip.Rows[j].Cells[0].Value)))
				{
					dgEquip.Rows[j].Selected = true;
					dgEquip.FirstDisplayedScrollingRowIndex = 0;
				}
				num++;
			}
			Pl1pwnp2uhq = false;
		}
	}

	private void ESypL31VEAX(object P_0, EventArgs P_1)
	{
		if (dgEquip.Rows.Count == 0 || Pl1pwnp2uhq)
		{
			return;
		}
		Pl1pwnp2uhq = true;
		int num = 0;
		bool flag = true;
		List<string> list = new List<string>();
		checked
		{
			int num2 = dgEquip.Rows.Count - 1;
			int num3 = 0;
			while (true)
			{
				if (num3 <= num2)
				{
					if (dgEquip.Rows[num3].Selected)
					{
						if (num3 == 0)
						{
							break;
						}
						list.Add(Conversions.ToString(dgEquip.Rows[num3].Cells[0].Value));
					}
					num3++;
					continue;
				}
				int num4 = dgEquip.Rows.Count - 1;
				for (int i = 0; i <= num4 && !dgEquip.Rows[i].Selected; i++)
				{
					num = i;
				}
				int num5 = -1000;
				if (num > 0)
				{
					int num6 = num - 1;
					for (int j = 0; j <= num6; j++)
					{
						dgEquip.Rows[j].Cells[2].Value = num5;
					}
				}
				int num7 = dgEquip.Rows.Count - 1;
				for (int k = 0; k <= num7; k++)
				{
					dgEquip.Rows[k].Selected = false;
				}
				num5 = 1000;
				int num8 = num;
				int num9 = dgEquip.Rows.Count - 1;
				for (int l = num8; l <= num9; l++)
				{
					if (!list.Contains(Conversions.ToString(dgEquip.Rows[l].Cells[0].Value)))
					{
						dgEquip.Rows[l].Cells[2].Value = num5;
						num5++;
					}
				}
				DataGridView dg = dgEquip;
				ordenar(ref dg);
				dgEquip = dg;
				num5 = 1;
				int num10 = dgEquip.Rows.Count - 1;
				for (int m = 0; m <= num10; m++)
				{
					dgEquip.Rows[m].Cells[2].Value = num5;
					if (list.Contains(Conversions.ToString(dgEquip.Rows[m].Cells[0].Value)))
					{
						dgEquip.Rows[m].Selected = true;
						if (flag)
						{
							flag = false;
							dgEquip.FirstDisplayedScrollingRowIndex = m;
						}
					}
					num5++;
				}
				break;
			}
			Pl1pwnp2uhq = false;
		}
	}

	private void YgDpLnjEF66(object P_0, EventArgs P_1)
	{
		if (dgEquip.Rows.Count == 0 || Pl1pwnp2uhq)
		{
			return;
		}
		Pl1pwnp2uhq = true;
		int num = 0;
		bool flag = true;
		List<string> list = new List<string>();
		checked
		{
			int num2 = dgEquip.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (dgEquip.Rows[i].Selected)
				{
					num = i;
					list.Add(Conversions.ToString(dgEquip.Rows[i].Cells[0].Value));
				}
			}
			if (num < dgEquip.Rows.Count - 1)
			{
				num++;
				int num3 = -1000;
				int num4 = dgEquip.Rows.Count - 1;
				for (int j = 0; j <= num4; j++)
				{
					if (j > num)
					{
						num3 = 1000;
						num = 1000;
					}
					if (!list.Contains(Conversions.ToString(dgEquip.Rows[j].Cells[0].Value)))
					{
						dgEquip.Rows[j].Cells[2].Value = num3;
						num3++;
					}
				}
				int num5 = dgEquip.Rows.Count - 1;
				for (int k = 0; k <= num5; k++)
				{
					dgEquip.Rows[k].Selected = false;
				}
				DataGridView dg = dgEquip;
				ordenar(ref dg);
				dgEquip = dg;
				num3 = 1;
				int num6 = dgEquip.Rows.Count - 1;
				for (int l = 0; l <= num6; l++)
				{
					dgEquip.Rows[l].Cells[2].Value = num3;
					if (list.Contains(Conversions.ToString(dgEquip.Rows[l].Cells[0].Value)))
					{
						dgEquip.Rows[l].Selected = true;
						if (flag)
						{
							flag = false;
							if (l > 15)
							{
								dgEquip.FirstDisplayedScrollingRowIndex = l - 10;
							}
						}
					}
					num3++;
				}
			}
			Pl1pwnp2uhq = false;
		}
	}

	private void hTSpL1vq6Ip(object P_0, EventArgs P_1)
	{
		if (dgEquip.Rows.Count == 0 || Pl1pwnp2uhq)
		{
			return;
		}
		Pl1pwnp2uhq = true;
		int num = 1000;
		List<string> list = new List<string>();
		checked
		{
			int num2 = dgEquip.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (dgEquip.Rows[i].Selected)
				{
					dgEquip.Rows[i].Cells[2].Value = num;
					list.Add(Conversions.ToString(dgEquip.Rows[i].Cells[0].Value));
					num++;
					dgEquip.Rows[i].Selected = false;
				}
			}
			DataGridView dg = dgEquip;
			ordenar(ref dg);
			dgEquip = dg;
			num = 1;
			int num3 = dgEquip.Rows.Count - 1;
			for (int j = 0; j <= num3; j++)
			{
				dgEquip.Rows[j].Cells[2].Value = num;
				if (list.Contains(Conversions.ToString(dgEquip.Rows[j].Cells[0].Value)))
				{
					dgEquip.Rows[j].Selected = true;
					dgEquip.FirstDisplayedScrollingRowIndex = j;
				}
				num++;
			}
			Pl1pwnp2uhq = false;
		}
	}

	public static void ordenar(ref DataGridView dg)
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
					if (Conversions.ToDouble(dg.Rows[j].Cells[2].Value) > Conversions.ToDouble(dg.Rows[j + 1].Cells[2].Value))
					{
						int num3 = 0;
						do
						{
							object objectValue = RuntimeHelpers.GetObjectValue(dg.Rows[j].Cells[num3].Value);
							dg.Rows[j].Cells[num3].Value = RuntimeHelpers.GetObjectValue(dg.Rows[j + 1].Cells[num3].Value);
							dg.Rows[j + 1].Cells[num3].Value = RuntimeHelpers.GetObjectValue(objectValue);
							num3++;
						}
						while (num3 <= 2);
					}
				}
			}
		}
	}
}
