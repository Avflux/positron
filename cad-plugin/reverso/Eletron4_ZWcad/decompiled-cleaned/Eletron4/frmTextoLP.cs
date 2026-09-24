using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Eletron4.My.Resources;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

[DesignerGenerated]
public class frmTextoLP : Form
{
	public struct StructureChaves
	{
		public string sHandle;

		public string chavePri;
	}

	private IContainer S6qpKlRIxo4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("H_BTSelecionaPortas")]
	private Button SCFpK5t3Bjy;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("H_BTInserir")]
	private Button GEhpK0kxjrB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolTip1")]
	private ToolTip txWpKRKU6Vc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("H_tbDistLinha")]
	private TextBox vJdpKmsF4a4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("H_LBDistLinha")]
	private Label EWQpKX8KsUu;

	[AccessedThroughProperty("H_tbFonte")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private TextBox fDZpKUGNBcd;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("H_LBFonte")]
	private Label pB8pKyrcKmZ;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("H_tbLargura")]
	private TextBox KXCpKgcNg8s;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("H_LBLargura")]
	private Label ccHpKASV1Xm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("H_tbOrdenada")]
	private TextBox L30pKsarP8I;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("H_LBY")]
	private Label jthpKBB4Tkn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("H_BTY")]
	private Button B3gpKVDxYGY;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("H_BTApaga")]
	private Button k2LpKu5HtFN;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CB_1_Linhas")]
	private CheckBox aQnpKEDb9lB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RBVertical")]
	private RadioButton z12pKZDZkTq;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RBHorizontal")]
	private RadioButton FGbpKi8AUel;

	[AccessedThroughProperty("GBGeral")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GroupBox chEpKSOhhRp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CB_2_MultiLinhas")]
	private CheckBox ns2pK4K3a3k;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("H_BTSelecionaDefinicoes")]
	private Button MpvpKCW5i18;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RBColuna")]
	private RadioButton K1TpKYkdOVA;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TB_C_XMin")]
	private TextBox KMwpKryYXCV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("C_BTYMin")]
	private Button DxTpK96FujV;

	[AccessedThroughProperty("GBHorizontal")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private GroupBox ettpKz4b1mo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Y_BTYMax")]
	private Button dgJpeWOpNMm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GBVertical")]
	private GroupBox ecmpepvjcZ1;

	[AccessedThroughProperty("V_TBFonte")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox vrEpeTw705k;

	[AccessedThroughProperty("TB_V_MAX")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox o8SpeJHL9EY;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TB_V_Min")]
	private TextBox b7upehhPMMs;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("V_BTSelecionaDefinicoes")]
	private Button lwlpeoyrBnW;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("V_BTInserir")]
	private Button GQ8peGIj6sO;

	[AccessedThroughProperty("V_BTApaga")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Button iMtpeHsWKAS;

	[AccessedThroughProperty("V_LBFonte")]
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Label oZgpekKyhEk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Y_BTYMin")]
	private Button Dj7peddUKZR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("V_BTSelecionaPortas")]
	private Button wxvpef9CkF2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("V_YMax")]
	private Label cgYpeD7wJ31;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("V_YMin")]
	[CompilerGenerated]
	private Label Y7kpevboASv;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GBColuna")]
	[CompilerGenerated]
	private GroupBox yKbpe6J0SvW;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("C_TBFonte")]
	private TextBox b18petAwDug;

	[CompilerGenerated]
	[AccessedThroughProperty("TB_C_XMax")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextBox q2bpejybJUO;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("C_BTYMax")]
	private Button X4jpeLrlYnA;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("C_BTSelecionaDefinicoes")]
	private Button nBppew238X2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("C_BTInserir")]
	private Button PffpexgQcLh;

	[AccessedThroughProperty("C_BTApaga")]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Button yUOpebD8Qf5;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("C_LBFonte")]
	private Label IMtpeM9ZPt0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("C_XMax")]
	private Label apgpeOysaaw;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("C_XMin")]
	private Label u9npeIBoVnc;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	[AccessedThroughProperty("CB_3_MultiLinhas")]
	private CheckBox Gfope7ch66E;

	private StructureChaves[] JVMpeqbEDeZ;

	private Declaracoes2.StructureDescricaoLP[] oR5peaUhdy7;

	private bool sDJpe8qOZOK;

	internal virtual Button H_BTSelecionaPortas
	{
		[CompilerGenerated]
		get
		{
			return SCFpK5t3Bjy;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = yQOpK6ittsq;
			Button button = SCFpK5t3Bjy;
			if (button != null)
			{
				button.Click -= value2;
			}
			SCFpK5t3Bjy = value;
			button = SCFpK5t3Bjy;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button H_BTInserir
	{
		[CompilerGenerated]
		get
		{
			return GEhpK0kxjrB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tFQpKqJ4Y9u;
			Button button = GEhpK0kxjrB;
			if (button != null)
			{
				button.Click -= value2;
			}
			GEhpK0kxjrB = value;
			button = GEhpK0kxjrB;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual TextBox H_tbDistLinha
	{
		[CompilerGenerated]
		get
		{
			return vJdpKmsF4a4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			vJdpKmsF4a4 = value;
		}
	}

	internal virtual Label H_LBDistLinha
	{
		[CompilerGenerated]
		get
		{
			return EWQpKX8KsUu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EWQpKX8KsUu = value;
		}
	}

	internal virtual TextBox H_tbFonte
	{
		[CompilerGenerated]
		get
		{
			return fDZpKUGNBcd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = k3opK3IeuLd;
			TextBox textBox = fDZpKUGNBcd;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			fDZpKUGNBcd = value;
			textBox = fDZpKUGNBcd;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual Label H_LBFonte
	{
		[CompilerGenerated]
		get
		{
			return pB8pKyrcKmZ;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			pB8pKyrcKmZ = value;
		}
	}

	internal virtual TextBox H_tbLargura
	{
		[CompilerGenerated]
		get
		{
			return KXCpKgcNg8s;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KXCpKgcNg8s = value;
		}
	}

	internal virtual Label H_LBLargura
	{
		[CompilerGenerated]
		get
		{
			return ccHpKASV1Xm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ccHpKASV1Xm = value;
		}
	}

	internal virtual TextBox H_tbOrdenada
	{
		[CompilerGenerated]
		get
		{
			return L30pKsarP8I;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			L30pKsarP8I = value;
		}
	}

	internal virtual Label H_LBY
	{
		[CompilerGenerated]
		get
		{
			return jthpKBB4Tkn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			jthpKBB4Tkn = value;
		}
	}

	internal virtual Button H_BTY
	{
		[CompilerGenerated]
		get
		{
			return B3gpKVDxYGY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = v7OpKLbKG97;
			Button button = B3gpKVDxYGY;
			if (button != null)
			{
				button.Click -= value2;
			}
			B3gpKVDxYGY = value;
			button = B3gpKVDxYGY;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button H_BTApaga
	{
		[CompilerGenerated]
		get
		{
			return k2LpKu5HtFN;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TEBpK7kpBmm;
			Button button = k2LpKu5HtFN;
			if (button != null)
			{
				button.Click -= value2;
			}
			k2LpKu5HtFN = value;
			button = k2LpKu5HtFN;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual CheckBox CB_1_Linhas
	{
		[CompilerGenerated]
		get
		{
			return aQnpKEDb9lB;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			aQnpKEDb9lB = value;
		}
	}

	internal virtual RadioButton RBVertical
	{
		[CompilerGenerated]
		get
		{
			return z12pKZDZkTq;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = zbapKPpLBJo;
			RadioButton radioButton = z12pKZDZkTq;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			z12pKZDZkTq = value;
			radioButton = z12pKZDZkTq;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual RadioButton RBHorizontal
	{
		[CompilerGenerated]
		get
		{
			return FGbpKi8AUel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UMEpKQSAsjj;
			RadioButton radioButton = FGbpKi8AUel;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			FGbpKi8AUel = value;
			radioButton = FGbpKi8AUel;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual GroupBox GBGeral
	{
		[CompilerGenerated]
		get
		{
			return chEpKSOhhRp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			chEpKSOhhRp = value;
		}
	}

	internal virtual CheckBox CB_2_MultiLinhas
	{
		[CompilerGenerated]
		get
		{
			return ns2pK4K3a3k;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Xv8pKeDfZvQ;
			CheckBox checkBox = ns2pK4K3a3k;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			ns2pK4K3a3k = value;
			checkBox = ns2pK4K3a3k;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	internal virtual Button H_BTSelecionaDefinicoes
	{
		[CompilerGenerated]
		get
		{
			return MpvpKCW5i18;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = A1GpKaB6gHB;
			Button button = MpvpKCW5i18;
			if (button != null)
			{
				button.Click -= value2;
			}
			MpvpKCW5i18 = value;
			button = MpvpKCW5i18;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual RadioButton RBColuna
	{
		[CompilerGenerated]
		get
		{
			return K1TpKYkdOVA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = UZMpKcAdaDl;
			RadioButton radioButton = K1TpKYkdOVA;
			if (radioButton != null)
			{
				radioButton.CheckedChanged -= value2;
			}
			K1TpKYkdOVA = value;
			radioButton = K1TpKYkdOVA;
			if (radioButton != null)
			{
				radioButton.CheckedChanged += value2;
			}
		}
	}

	internal virtual TextBox TB_C_XMin
	{
		[CompilerGenerated]
		get
		{
			return KMwpKryYXCV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KMwpKryYXCV = value;
		}
	}

	internal virtual Button C_BTYMin
	{
		[CompilerGenerated]
		get
		{
			return DxTpK96FujV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = LPBpKxGrDlp;
			Button button = DxTpK96FujV;
			if (button != null)
			{
				button.Click -= value2;
			}
			DxTpK96FujV = value;
			button = DxTpK96FujV;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GBHorizontal
	{
		[CompilerGenerated]
		get
		{
			return ettpKz4b1mo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ettpKz4b1mo = value;
		}
	}

	internal virtual Button Y_BTYMax
	{
		[CompilerGenerated]
		get
		{
			return dgJpeWOpNMm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = VdLpKM8rN4c;
			Button button = dgJpeWOpNMm;
			if (button != null)
			{
				button.Click -= value2;
			}
			dgJpeWOpNMm = value;
			button = dgJpeWOpNMm;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual GroupBox GBVertical
	{
		[CompilerGenerated]
		get
		{
			return ecmpepvjcZ1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			ecmpepvjcZ1 = value;
		}
	}

	internal virtual TextBox V_TBFonte
	{
		[CompilerGenerated]
		get
		{
			return vrEpeTw705k;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = eJSpKnZ6XED;
			TextBox textBox = vrEpeTw705k;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			vrEpeTw705k = value;
			textBox = vrEpeTw705k;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox TB_V_MAX
	{
		[CompilerGenerated]
		get
		{
			return o8SpeJHL9EY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			o8SpeJHL9EY = value;
		}
	}

	internal virtual TextBox TB_V_Min
	{
		[CompilerGenerated]
		get
		{
			return b7upehhPMMs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			b7upehhPMMs = value;
		}
	}

	internal virtual Button V_BTSelecionaDefinicoes
	{
		[CompilerGenerated]
		get
		{
			return lwlpeoyrBnW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = vdgpK8fTg4r;
			Button button = lwlpeoyrBnW;
			if (button != null)
			{
				button.Click -= value2;
			}
			lwlpeoyrBnW = value;
			button = lwlpeoyrBnW;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button V_BTInserir
	{
		[CompilerGenerated]
		get
		{
			return GQ8peGIj6sO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tFQpKqJ4Y9u;
			Button button = GQ8peGIj6sO;
			if (button != null)
			{
				button.Click -= value2;
			}
			GQ8peGIj6sO = value;
			button = GQ8peGIj6sO;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button V_BTApaga
	{
		[CompilerGenerated]
		get
		{
			return iMtpeHsWKAS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TEBpK7kpBmm;
			Button button = iMtpeHsWKAS;
			if (button != null)
			{
				button.Click -= value2;
			}
			iMtpeHsWKAS = value;
			button = iMtpeHsWKAS;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label V_LBFonte
	{
		[CompilerGenerated]
		get
		{
			return oZgpekKyhEk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			oZgpekKyhEk = value;
		}
	}

	internal virtual Button Y_BTYMin
	{
		[CompilerGenerated]
		get
		{
			return Dj7peddUKZR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = ntspKwfI5h1;
			Button button = Dj7peddUKZR;
			if (button != null)
			{
				button.Click -= value2;
			}
			Dj7peddUKZR = value;
			button = Dj7peddUKZR;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button V_BTSelecionaPortas
	{
		[CompilerGenerated]
		get
		{
			return wxvpef9CkF2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = kfPpKttgtXe;
			Button button = wxvpef9CkF2;
			if (button != null)
			{
				button.Click -= value2;
			}
			wxvpef9CkF2 = value;
			button = wxvpef9CkF2;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label V_YMax
	{
		[CompilerGenerated]
		get
		{
			return cgYpeD7wJ31;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			cgYpeD7wJ31 = value;
		}
	}

	internal virtual Label V_YMin
	{
		[CompilerGenerated]
		get
		{
			return Y7kpevboASv;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			Y7kpevboASv = value;
		}
	}

	internal virtual GroupBox GBColuna
	{
		[CompilerGenerated]
		get
		{
			return yKbpe6J0SvW;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			yKbpe6J0SvW = value;
		}
	}

	internal virtual TextBox C_TBFonte
	{
		[CompilerGenerated]
		get
		{
			return b18petAwDug;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = yf7pK1FesoV;
			TextBox textBox = b18petAwDug;
			if (textBox != null)
			{
				textBox.KeyUp -= value2;
			}
			b18petAwDug = value;
			textBox = b18petAwDug;
			if (textBox != null)
			{
				textBox.KeyUp += value2;
			}
		}
	}

	internal virtual TextBox TB_C_XMax
	{
		[CompilerGenerated]
		get
		{
			return q2bpejybJUO;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			q2bpejybJUO = value;
		}
	}

	internal virtual Button C_BTYMax
	{
		[CompilerGenerated]
		get
		{
			return X4jpeLrlYnA;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = rxFpKOsp3mW;
			Button button = X4jpeLrlYnA;
			if (button != null)
			{
				button.Click -= value2;
			}
			X4jpeLrlYnA = value;
			button = X4jpeLrlYnA;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button C_BTSelecionaDefinicoes
	{
		[CompilerGenerated]
		get
		{
			return nBppew238X2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = eEepKNa78JL;
			Button button = nBppew238X2;
			if (button != null)
			{
				button.Click -= value2;
			}
			nBppew238X2 = value;
			button = nBppew238X2;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button C_BTInserir
	{
		[CompilerGenerated]
		get
		{
			return PffpexgQcLh;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = tFQpKqJ4Y9u;
			Button button = PffpexgQcLh;
			if (button != null)
			{
				button.Click -= value2;
			}
			PffpexgQcLh = value;
			button = PffpexgQcLh;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button C_BTApaga
	{
		[CompilerGenerated]
		get
		{
			return yUOpebD8Qf5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = TEBpK7kpBmm;
			Button button = yUOpebD8Qf5;
			if (button != null)
			{
				button.Click -= value2;
			}
			yUOpebD8Qf5 = value;
			button = yUOpebD8Qf5;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Label C_LBFonte
	{
		[CompilerGenerated]
		get
		{
			return IMtpeM9ZPt0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			IMtpeM9ZPt0 = value;
		}
	}

	internal virtual Label C_XMax
	{
		[CompilerGenerated]
		get
		{
			return apgpeOysaaw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			apgpeOysaaw = value;
		}
	}

	internal virtual Label C_XMin
	{
		[CompilerGenerated]
		get
		{
			return u9npeIBoVnc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			u9npeIBoVnc = value;
		}
	}

	internal virtual CheckBox CB_3_MultiLinhas
	{
		[CompilerGenerated]
		get
		{
			return Gfope7ch66E;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = vhgpK2CeNTB;
			CheckBox checkBox = Gfope7ch66E;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			Gfope7ch66E = value;
			checkBox = Gfope7ch66E;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && S6qpKlRIxo4 != null)
			{
				S6qpKlRIxo4.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void wDapKvmSCTp()
	{
		S6qpKlRIxo4 = new Container();
		H_BTSelecionaPortas = new Button();
		H_BTInserir = new Button();
		FDqpBiUmZij(new ToolTip(S6qpKlRIxo4));
		H_tbDistLinha = new TextBox();
		H_LBDistLinha = new Label();
		H_tbFonte = new TextBox();
		H_LBFonte = new Label();
		H_tbLargura = new TextBox();
		H_LBLargura = new Label();
		H_tbOrdenada = new TextBox();
		H_LBY = new Label();
		H_BTY = new Button();
		H_BTApaga = new Button();
		CB_1_Linhas = new CheckBox();
		RBVertical = new RadioButton();
		RBHorizontal = new RadioButton();
		GBGeral = new GroupBox();
		CB_3_MultiLinhas = new CheckBox();
		RBColuna = new RadioButton();
		CB_2_MultiLinhas = new CheckBox();
		H_BTSelecionaDefinicoes = new Button();
		TB_C_XMin = new TextBox();
		C_BTYMin = new Button();
		GBHorizontal = new GroupBox();
		Y_BTYMax = new Button();
		GBVertical = new GroupBox();
		V_TBFonte = new TextBox();
		TB_V_MAX = new TextBox();
		TB_V_Min = new TextBox();
		V_BTSelecionaDefinicoes = new Button();
		V_BTInserir = new Button();
		V_BTApaga = new Button();
		V_LBFonte = new Label();
		Y_BTYMin = new Button();
		V_BTSelecionaPortas = new Button();
		V_YMax = new Label();
		V_YMin = new Label();
		GBColuna = new GroupBox();
		C_TBFonte = new TextBox();
		TB_C_XMax = new TextBox();
		C_BTYMax = new Button();
		C_BTSelecionaDefinicoes = new Button();
		C_BTInserir = new Button();
		C_BTApaga = new Button();
		C_LBFonte = new Label();
		C_XMax = new Label();
		C_XMin = new Label();
		GBGeral.SuspendLayout();
		GBHorizontal.SuspendLayout();
		GBVertical.SuspendLayout();
		GBColuna.SuspendLayout();
		SuspendLayout();
		H_BTSelecionaPortas.FlatStyle = FlatStyle.Flat;
		H_BTSelecionaPortas.ForeColor = SystemColors.Control;
		H_BTSelecionaPortas.Image = Resources.AtribuirPortas_32;
		H_BTSelecionaPortas.Location = new Point(52, 147);
		H_BTSelecionaPortas.Name = "H_BTSelecionaPortas";
		H_BTSelecionaPortas.Size = new Size(40, 40);
		H_BTSelecionaPortas.TabIndex = 12;
		H_BTSelecionaPortas.UseVisualStyleBackColor = true;
		H_BTInserir.FlatStyle = FlatStyle.Flat;
		H_BTInserir.ForeColor = SystemColors.Control;
		H_BTInserir.Image = Resources.Adiciona_32;
		H_BTInserir.Location = new Point(144, 147);
		H_BTInserir.Name = "H_BTInserir";
		H_BTInserir.Size = new Size(40, 40);
		H_BTInserir.TabIndex = 13;
		H_BTInserir.UseVisualStyleBackColor = true;
		H_tbDistLinha.Location = new Point(6, 26);
		H_tbDistLinha.Name = "H_tbDistLinha";
		H_tbDistLinha.Size = new Size(61, 20);
		H_tbDistLinha.TabIndex = 20;
		H_LBDistLinha.AutoSize = true;
		H_LBDistLinha.Location = new Point(3, 10);
		H_LBDistLinha.Name = "H_LBDistLinha";
		H_LBDistLinha.Size = new Size(64, 13);
		H_LBDistLinha.TabIndex = 19;
		H_LBDistLinha.Text = "LBDistLinha";
		H_tbFonte.Location = new Point(78, 26);
		H_tbFonte.Name = "H_tbFonte";
		H_tbFonte.Size = new Size(61, 20);
		H_tbFonte.TabIndex = 22;
		H_LBFonte.AutoSize = true;
		H_LBFonte.Location = new Point(75, 10);
		H_LBFonte.Name = "H_LBFonte";
		H_LBFonte.Size = new Size(47, 13);
		H_LBFonte.TabIndex = 21;
		H_LBFonte.Text = "LBFonte";
		H_tbLargura.BackColor = SystemColors.ActiveBorder;
		H_tbLargura.Location = new Point(6, 67);
		H_tbLargura.Name = "H_tbLargura";
		H_tbLargura.Size = new Size(132, 20);
		H_tbLargura.TabIndex = 24;
		H_LBLargura.AutoSize = true;
		H_LBLargura.Location = new Point(3, 51);
		H_LBLargura.Name = "H_LBLargura";
		H_LBLargura.Size = new Size(70, 13);
		H_LBLargura.TabIndex = 23;
		H_LBLargura.Text = "H_LBLargura";
		H_tbOrdenada.BackColor = SystemColors.ActiveBorder;
		H_tbOrdenada.Location = new Point(6, 106);
		H_tbOrdenada.Name = "H_tbOrdenada";
		H_tbOrdenada.ReadOnly = true;
		H_tbOrdenada.Size = new Size(132, 20);
		H_tbOrdenada.TabIndex = 26;
		H_LBY.AutoSize = true;
		H_LBY.Location = new Point(3, 90);
		H_LBY.Name = "H_LBY";
		H_LBY.Size = new Size(41, 13);
		H_LBY.TabIndex = 25;
		H_LBY.Text = "H_LBY";
		H_BTY.FlatStyle = FlatStyle.Flat;
		H_BTY.ForeColor = SystemColors.Control;
		H_BTY.Image = Resources.Altura;
		H_BTY.Location = new Point(144, 95);
		H_BTY.Name = "H_BTY";
		H_BTY.Size = new Size(40, 40);
		H_BTY.TabIndex = 27;
		H_BTY.UseVisualStyleBackColor = true;
		H_BTApaga.FlatStyle = FlatStyle.Flat;
		H_BTApaga.ForeColor = SystemColors.Control;
		H_BTApaga.Image = Resources.Delete_32;
		H_BTApaga.Location = new Point(98, 147);
		H_BTApaga.Name = "H_BTApaga";
		H_BTApaga.Size = new Size(40, 40);
		H_BTApaga.TabIndex = 28;
		H_BTApaga.UseVisualStyleBackColor = true;
		CB_1_Linhas.AutoSize = true;
		CB_1_Linhas.Checked = true;
		CB_1_Linhas.CheckState = CheckState.Checked;
		CB_1_Linhas.Location = new Point(28, 52);
		CB_1_Linhas.Name = "CB_1_Linhas";
		CB_1_Linhas.Size = new Size(113, 17);
		CB_1_Linhas.TabIndex = 30;
		CB_1_Linhas.Text = "cbAdiciona Linhas";
		CB_1_Linhas.UseVisualStyleBackColor = true;
		RBVertical.AutoSize = true;
		RBVertical.Location = new Point(6, 82);
		RBVertical.Name = "RBVertical";
		RBVertical.Size = new Size(75, 17);
		RBVertical.TabIndex = 34;
		RBVertical.Text = "RBVertical";
		RBVertical.UseVisualStyleBackColor = true;
		RBHorizontal.AutoSize = true;
		RBHorizontal.Checked = true;
		RBHorizontal.Location = new Point(6, 28);
		RBHorizontal.Name = "RBHorizontal";
		RBHorizontal.Size = new Size(87, 17);
		RBHorizontal.TabIndex = 33;
		RBHorizontal.TabStop = true;
		RBHorizontal.Text = "RBHorizontal";
		RBHorizontal.UseVisualStyleBackColor = true;
		GBGeral.Controls.Add(CB_3_MultiLinhas);
		GBGeral.Controls.Add(RBColuna);
		GBGeral.Controls.Add(RBHorizontal);
		GBGeral.Controls.Add(CB_2_MultiLinhas);
		GBGeral.Controls.Add(CB_1_Linhas);
		GBGeral.Controls.Add(RBVertical);
		GBGeral.Location = new Point(8, 11);
		GBGeral.Name = "GBGeral";
		GBGeral.Size = new Size(163, 191);
		GBGeral.TabIndex = 35;
		GBGeral.TabStop = false;
		GBGeral.Text = "Orientação do Texto";
		CB_3_MultiLinhas.AutoSize = true;
		CB_3_MultiLinhas.Checked = true;
		CB_3_MultiLinhas.CheckState = CheckState.Checked;
		CB_3_MultiLinhas.Location = new Point(28, 162);
		CB_3_MultiLinhas.Name = "CB_3_MultiLinhas";
		CB_3_MultiLinhas.Size = new Size(94, 17);
		CB_3_MultiLinhas.TabIndex = 36;
		CB_3_MultiLinhas.Text = "cbMulti Linhas";
		CB_3_MultiLinhas.UseVisualStyleBackColor = true;
		RBColuna.AutoSize = true;
		RBColuna.Location = new Point(6, 136);
		RBColuna.Name = "RBColuna";
		RBColuna.Size = new Size(89, 17);
		RBColuna.TabIndex = 35;
		RBColuna.Text = "rbListaColuna";
		RBColuna.UseVisualStyleBackColor = true;
		CB_2_MultiLinhas.AutoSize = true;
		CB_2_MultiLinhas.Checked = true;
		CB_2_MultiLinhas.CheckState = CheckState.Checked;
		CB_2_MultiLinhas.Location = new Point(28, 106);
		CB_2_MultiLinhas.Name = "CB_2_MultiLinhas";
		CB_2_MultiLinhas.Size = new Size(94, 17);
		CB_2_MultiLinhas.TabIndex = 30;
		CB_2_MultiLinhas.Text = "cbMulti Linhas";
		CB_2_MultiLinhas.UseVisualStyleBackColor = true;
		H_BTSelecionaDefinicoes.FlatStyle = FlatStyle.Flat;
		H_BTSelecionaDefinicoes.ForeColor = SystemColors.Control;
		H_BTSelecionaDefinicoes.Image = Resources.AtribuirDefinicao_32;
		H_BTSelecionaDefinicoes.Location = new Point(6, 147);
		H_BTSelecionaDefinicoes.Name = "H_BTSelecionaDefinicoes";
		H_BTSelecionaDefinicoes.Size = new Size(40, 40);
		H_BTSelecionaDefinicoes.TabIndex = 140;
		H_BTSelecionaDefinicoes.UseVisualStyleBackColor = true;
		TB_C_XMin.BackColor = SystemColors.ActiveBorder;
		TB_C_XMin.Location = new Point(6, 67);
		TB_C_XMin.Name = "TB_C_XMin";
		TB_C_XMin.ReadOnly = true;
		TB_C_XMin.Size = new Size(132, 20);
		TB_C_XMin.TabIndex = 141;
		C_BTYMin.FlatStyle = FlatStyle.Flat;
		C_BTYMin.ForeColor = SystemColors.Control;
		C_BTYMin.Image = Resources.Largura;
		C_BTYMin.Location = new Point(144, 56);
		C_BTYMin.Name = "C_BTYMin";
		C_BTYMin.Size = new Size(40, 40);
		C_BTYMin.TabIndex = 142;
		C_BTYMin.UseVisualStyleBackColor = true;
		GBHorizontal.Controls.Add(H_tbFonte);
		GBHorizontal.Controls.Add(H_tbDistLinha);
		GBHorizontal.Controls.Add(H_tbLargura);
		GBHorizontal.Controls.Add(H_tbOrdenada);
		GBHorizontal.Controls.Add(H_LBDistLinha);
		GBHorizontal.Controls.Add(H_BTSelecionaDefinicoes);
		GBHorizontal.Controls.Add(H_BTInserir);
		GBHorizontal.Controls.Add(H_BTApaga);
		GBHorizontal.Controls.Add(H_LBFonte);
		GBHorizontal.Controls.Add(H_BTY);
		GBHorizontal.Controls.Add(H_BTSelecionaPortas);
		GBHorizontal.Controls.Add(H_LBLargura);
		GBHorizontal.Controls.Add(H_LBY);
		GBHorizontal.Location = new Point(177, 11);
		GBHorizontal.Name = "GBHorizontal";
		GBHorizontal.Size = new Size(190, 190);
		GBHorizontal.TabIndex = 143;
		GBHorizontal.TabStop = false;
		Y_BTYMax.FlatStyle = FlatStyle.Flat;
		Y_BTYMax.ForeColor = SystemColors.Control;
		Y_BTYMax.Image = Resources.AlturaMax;
		Y_BTYMax.Location = new Point(144, 52);
		Y_BTYMax.Name = "Y_BTYMax";
		Y_BTYMax.Size = new Size(40, 40);
		Y_BTYMax.TabIndex = 141;
		Y_BTYMax.UseVisualStyleBackColor = true;
		GBVertical.Controls.Add(V_TBFonte);
		GBVertical.Controls.Add(TB_V_MAX);
		GBVertical.Controls.Add(TB_V_Min);
		GBVertical.Controls.Add(Y_BTYMax);
		GBVertical.Controls.Add(V_BTSelecionaDefinicoes);
		GBVertical.Controls.Add(V_BTInserir);
		GBVertical.Controls.Add(V_BTApaga);
		GBVertical.Controls.Add(V_LBFonte);
		GBVertical.Controls.Add(Y_BTYMin);
		GBVertical.Controls.Add(V_BTSelecionaPortas);
		GBVertical.Controls.Add(V_YMax);
		GBVertical.Controls.Add(V_YMin);
		GBVertical.Location = new Point(373, 11);
		GBVertical.Name = "GBVertical";
		GBVertical.Size = new Size(190, 190);
		GBVertical.TabIndex = 146;
		GBVertical.TabStop = false;
		V_TBFonte.Location = new Point(6, 26);
		V_TBFonte.Name = "V_TBFonte";
		V_TBFonte.Size = new Size(133, 20);
		V_TBFonte.TabIndex = 22;
		TB_V_MAX.BackColor = SystemColors.ActiveBorder;
		TB_V_MAX.Location = new Point(6, 67);
		TB_V_MAX.Name = "TB_V_MAX";
		TB_V_MAX.Size = new Size(132, 20);
		TB_V_MAX.TabIndex = 24;
		TB_V_Min.BackColor = SystemColors.ActiveBorder;
		TB_V_Min.Location = new Point(6, 106);
		TB_V_Min.Name = "TB_V_Min";
		TB_V_Min.ReadOnly = true;
		TB_V_Min.Size = new Size(132, 20);
		TB_V_Min.TabIndex = 26;
		V_BTSelecionaDefinicoes.FlatStyle = FlatStyle.Flat;
		V_BTSelecionaDefinicoes.ForeColor = SystemColors.Control;
		V_BTSelecionaDefinicoes.Image = Resources.AtribuirDefinicao_32;
		V_BTSelecionaDefinicoes.Location = new Point(6, 147);
		V_BTSelecionaDefinicoes.Name = "V_BTSelecionaDefinicoes";
		V_BTSelecionaDefinicoes.Size = new Size(40, 40);
		V_BTSelecionaDefinicoes.TabIndex = 140;
		V_BTSelecionaDefinicoes.UseVisualStyleBackColor = true;
		V_BTInserir.FlatStyle = FlatStyle.Flat;
		V_BTInserir.ForeColor = SystemColors.Control;
		V_BTInserir.Image = Resources.Adiciona_32;
		V_BTInserir.Location = new Point(144, 147);
		V_BTInserir.Name = "V_BTInserir";
		V_BTInserir.Size = new Size(40, 40);
		V_BTInserir.TabIndex = 13;
		V_BTInserir.UseVisualStyleBackColor = true;
		V_BTApaga.FlatStyle = FlatStyle.Flat;
		V_BTApaga.ForeColor = SystemColors.Control;
		V_BTApaga.Image = Resources.Delete_32;
		V_BTApaga.Location = new Point(98, 147);
		V_BTApaga.Name = "V_BTApaga";
		V_BTApaga.Size = new Size(40, 40);
		V_BTApaga.TabIndex = 28;
		V_BTApaga.UseVisualStyleBackColor = true;
		V_LBFonte.AutoSize = true;
		V_LBFonte.Location = new Point(6, 10);
		V_LBFonte.Name = "V_LBFonte";
		V_LBFonte.Size = new Size(47, 13);
		V_LBFonte.TabIndex = 21;
		V_LBFonte.Text = "LBFonte";
		Y_BTYMin.FlatStyle = FlatStyle.Flat;
		Y_BTYMin.ForeColor = SystemColors.Control;
		Y_BTYMin.Image = Resources.Altura;
		Y_BTYMin.Location = new Point(144, 95);
		Y_BTYMin.Name = "Y_BTYMin";
		Y_BTYMin.Size = new Size(40, 40);
		Y_BTYMin.TabIndex = 27;
		Y_BTYMin.UseVisualStyleBackColor = true;
		V_BTSelecionaPortas.FlatStyle = FlatStyle.Flat;
		V_BTSelecionaPortas.ForeColor = SystemColors.Control;
		V_BTSelecionaPortas.Image = Resources.AtribuirPortas_32;
		V_BTSelecionaPortas.Location = new Point(52, 147);
		V_BTSelecionaPortas.Name = "V_BTSelecionaPortas";
		V_BTSelecionaPortas.Size = new Size(40, 40);
		V_BTSelecionaPortas.TabIndex = 12;
		V_BTSelecionaPortas.UseVisualStyleBackColor = true;
		V_YMax.AutoSize = true;
		V_YMax.Location = new Point(3, 51);
		V_YMax.Name = "V_YMax";
		V_YMax.Size = new Size(47, 13);
		V_YMax.TabIndex = 23;
		V_YMax.Text = "V_YMax";
		V_YMin.AutoSize = true;
		V_YMin.Location = new Point(3, 90);
		V_YMin.Name = "V_YMin";
		V_YMin.Size = new Size(44, 13);
		V_YMin.TabIndex = 25;
		V_YMin.Text = "V_YMin";
		GBColuna.Controls.Add(TB_C_XMin);
		GBColuna.Controls.Add(C_TBFonte);
		GBColuna.Controls.Add(C_BTYMin);
		GBColuna.Controls.Add(TB_C_XMax);
		GBColuna.Controls.Add(C_BTYMax);
		GBColuna.Controls.Add(C_BTSelecionaDefinicoes);
		GBColuna.Controls.Add(C_BTInserir);
		GBColuna.Controls.Add(C_BTApaga);
		GBColuna.Controls.Add(C_LBFonte);
		GBColuna.Controls.Add(C_XMax);
		GBColuna.Controls.Add(C_XMin);
		GBColuna.Location = new Point(569, 12);
		GBColuna.Name = "GBColuna";
		GBColuna.Size = new Size(190, 190);
		GBColuna.TabIndex = 147;
		GBColuna.TabStop = false;
		C_TBFonte.Location = new Point(6, 26);
		C_TBFonte.Name = "C_TBFonte";
		C_TBFonte.Size = new Size(133, 20);
		C_TBFonte.TabIndex = 22;
		TB_C_XMax.BackColor = SystemColors.ActiveBorder;
		TB_C_XMax.Location = new Point(6, 106);
		TB_C_XMax.Name = "TB_C_XMax";
		TB_C_XMax.Size = new Size(132, 20);
		TB_C_XMax.TabIndex = 24;
		C_BTYMax.FlatStyle = FlatStyle.Flat;
		C_BTYMax.ForeColor = SystemColors.Control;
		C_BTYMax.Image = Resources.LarguraMax;
		C_BTYMax.Location = new Point(144, 95);
		C_BTYMax.Name = "C_BTYMax";
		C_BTYMax.Size = new Size(40, 40);
		C_BTYMax.TabIndex = 27;
		C_BTYMax.UseVisualStyleBackColor = true;
		C_BTSelecionaDefinicoes.FlatStyle = FlatStyle.Flat;
		C_BTSelecionaDefinicoes.ForeColor = SystemColors.Control;
		C_BTSelecionaDefinicoes.Image = Resources.AtribuirDefinicao_32;
		C_BTSelecionaDefinicoes.Location = new Point(52, 147);
		C_BTSelecionaDefinicoes.Name = "C_BTSelecionaDefinicoes";
		C_BTSelecionaDefinicoes.Size = new Size(40, 40);
		C_BTSelecionaDefinicoes.TabIndex = 140;
		C_BTSelecionaDefinicoes.UseVisualStyleBackColor = true;
		C_BTInserir.FlatStyle = FlatStyle.Flat;
		C_BTInserir.ForeColor = SystemColors.Control;
		C_BTInserir.Image = Resources.Adiciona_32;
		C_BTInserir.Location = new Point(144, 147);
		C_BTInserir.Name = "C_BTInserir";
		C_BTInserir.Size = new Size(40, 40);
		C_BTInserir.TabIndex = 13;
		C_BTInserir.UseVisualStyleBackColor = true;
		C_BTApaga.FlatStyle = FlatStyle.Flat;
		C_BTApaga.ForeColor = SystemColors.Control;
		C_BTApaga.Image = Resources.Delete_32;
		C_BTApaga.Location = new Point(98, 147);
		C_BTApaga.Name = "C_BTApaga";
		C_BTApaga.Size = new Size(40, 40);
		C_BTApaga.TabIndex = 28;
		C_BTApaga.UseVisualStyleBackColor = true;
		C_LBFonte.AutoSize = true;
		C_LBFonte.Location = new Point(6, 10);
		C_LBFonte.Name = "C_LBFonte";
		C_LBFonte.Size = new Size(47, 13);
		C_LBFonte.TabIndex = 21;
		C_LBFonte.Text = "LBFonte";
		C_XMax.AutoSize = true;
		C_XMax.Location = new Point(3, 90);
		C_XMax.Name = "C_XMax";
		C_XMax.Size = new Size(47, 13);
		C_XMax.TabIndex = 23;
		C_XMax.Text = "C_XMax";
		C_XMin.AutoSize = true;
		C_XMin.Location = new Point(3, 51);
		C_XMin.Name = "C_XMin";
		C_XMin.Size = new Size(44, 13);
		C_XMin.TabIndex = 25;
		C_XMin.Text = "C_XMin";
		AutoScaleDimensions = new SizeF(6f, 13f);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(374, 211);
		Controls.Add(GBColuna);
		Controls.Add(GBVertical);
		Controls.Add(GBHorizontal);
		Controls.Add(GBGeral);
		FormBorderStyle = FormBorderStyle.FixedSingle;
		MaximizeBox = false;
		MaximumSize = new Size(390, 250);
		MinimizeBox = false;
		MinimumSize = new Size(390, 250);
		Name = "frmTextoLP";
		ShowInTaskbar = false;
		StartPosition = FormStartPosition.CenterParent;
		Text = "Textos LP";
		GBGeral.ResumeLayout(performLayout: false);
		GBGeral.PerformLayout();
		GBHorizontal.ResumeLayout(performLayout: false);
		GBHorizontal.PerformLayout();
		GBVertical.ResumeLayout(performLayout: false);
		GBVertical.PerformLayout();
		GBColuna.ResumeLayout(performLayout: false);
		GBColuna.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[SpecialName]
	[CompilerGenerated]
	internal virtual ToolTip w8dpBZ0kvSD()
	{
		return txWpKRKU6Vc;
	}

	[MethodImpl(MethodImplOptions.Synchronized)]
	[SpecialName]
	[CompilerGenerated]
	internal virtual void FDqpBiUmZij(ToolTip WithEventsValue)
	{
		txWpKRKU6Vc = WithEventsValue;
	}

	public frmTextoLP()
	{
		sDJpe8qOZOK = true;
		try
		{
			if (Geral.ExisteForm("frmTextoLP"))
			{
				return;
			}
			wDapKvmSCTp();
			XDataGeral.LerXDataConfiguracao();
			Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1024]);
			H_LBDistLinha.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1025]);
			H_LBFonte.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1026]);
			H_LBLargura.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1027]);
			H_LBY.Text = "Y";
			V_LBFonte.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1026]);
			V_YMin.Text = "Y Min";
			V_YMax.Text = "Y Max";
			C_LBFonte.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1026]);
			C_XMax.Text = "X Max";
			C_XMin.Text = "X Min";
			w8dpBZ0kvSD().SetToolTip(H_BTY, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1029]));
			w8dpBZ0kvSD().SetToolTip(H_BTSelecionaPortas, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1144]));
			w8dpBZ0kvSD().SetToolTip(H_BTSelecionaDefinicoes, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1152]));
			w8dpBZ0kvSD().SetToolTip(H_BTInserir, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1028]));
			w8dpBZ0kvSD().SetToolTip(H_BTApaga, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1143]));
			GBGeral.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1374]);
			RBHorizontal.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 844]);
			RBVertical.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 845]);
			RBColuna.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1911]);
			CB_1_Linhas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 801]);
			CB_2_MultiLinhas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 98]);
			CB_3_MultiLinhas.Text = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 98]);
			double dLinha = Conversions.ToDouble(Conversions.ToString(5));
			double dTexto = DeclaracoesGeral.Conf.FonteCircuito;
			clsTextos.EncontraAlturadoTexto_Linha(ref dLinha, ref dTexto);
			H_tbDistLinha.Text = Conversions.ToString(dLinha);
			H_tbFonte.Text = Conversions.ToString(dTexto);
			V_TBFonte.Text = Conversions.ToString(DeclaracoesGeral.Conf.FonteCircuito);
			C_TBFonte.Text = Conversions.ToString(DeclaracoesGeral.Conf.FonteCircuito);
			H_tbLargura.Text = "";
			H_tbOrdenada.Text = "";
			H_BTInserir.Enabled = false;
			bool flag = false;
			if (!XDataGeral.LerXDataConfiguracaoListaDePontos())
			{
				Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 281]), MsgBoxStyle.Information);
			}
			else if (Operators.CompareString(DeclaracoesGeral.ConfLP.listaDePontos.Trim(), "", TextCompare: true) != 0)
			{
				if (!File.Exists(DeclaracoesGeral.ConfLP.listaDePontos))
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 282]), MsgBoxStyle.Information);
				}
				else if (!Geral.IsFileInUse(DeclaracoesGeral.ConfLP.listaDePontos))
				{
					flag = true;
				}
				else
				{
					Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1495]), MsgBoxStyle.Information);
				}
			}
			if (flag)
			{
				CarregaPortasChaves();
				Application.ShowModelessDialog((Form)this);
				if ((Screen.AllScreens.Length == 1) & (Left > Screen.PrimaryScreen.Bounds.Width))
				{
					Left = 0;
				}
			}
			GBVertical.Location = GBHorizontal.Location;
			GBColuna.Location = GBHorizontal.Location;
			GBVertical.Visible = false;
			GBColuna.Visible = false;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void yQOpK6ittsq(object P_0, EventArgs P_1)
	{
		UbBpKjvhFHV();
	}

	private void kfPpKttgtXe(object P_0, EventArgs P_1)
	{
		UbBpKjvhFHV();
	}

	private void UbBpKjvhFHV()
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected Obj, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected Obj, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Invalid comparison between Unknown and I4
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected Obj, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected Obj, but got Unknown
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected Obj, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Unknown result type (might be due to invalid IL or missing references)
		//IL_0495: Unknown result type (might be due to invalid IL or missing references)
		//IL_0599: Unknown result type (might be due to invalid IL or missing references)
		//IL_059f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
		sDJpe8qOZOK = true;
		PointMonitorToolTips.StopMonitor();
		oR5peaUhdy7 = new Declaracoes2.StructureDescricaoLP[1];
		string text = "";
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			TypedValue[] array = new TypedValue[2];
			array.SetValue((object)new TypedValue(0, (object)"INSERT"), 0);
			array.SetValue((object)new TypedValue(1001, (object)"DISPOSITIVO"), 1);
			SelectionFilter val2 = new SelectionFilter(array);
			PromptSelectionOptions val3 = new PromptSelectionOptions();
			val3.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 622]);
			PromptSelectionResult selection = editor.GetSelection(val3, val2);
			if ((int)selection.Status != 5100)
			{
				return;
			}
			SelectionSet value = selection.Value;
			ObjectIdCollection val4 = new ObjectIdCollection(value.GetObjectIds());
			new ObjectIdCollection();
			new List<double>();
			checked
			{
				Point3d val7;
				foreach (object item in val4)
				{
					ObjectId val5 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
					BlockReference val6 = (BlockReference)val5.GetObject((OpenMode)0);
					Entity ent = (Entity)(object)val6;
					string tipoImportado = "";
					string text2 = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
					val6 = (BlockReference)ent;
					text = text2;
					if (Operators.CompareString(text, "E", TextCompare: true) == 0)
					{
						DeclaracoesEntidades.StructurePortas structurePortas = default;
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
						structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
						if (Operators.CompareString(structurePortas.chavePrimaria.Trim(), "", TextCompare: true) != 0)
						{
							int num = Information.UBound(oR5peaUhdy7) + 1;
							ref Declaracoes2.StructureDescricaoLP[] reference = ref oR5peaUhdy7;
							reference = (Declaracoes2.StructureDescricaoLP[])Utils.CopyArray(reference, new Declaracoes2.StructureDescricaoLP[num + 1]);
							ref Declaracoes2.StructureDescricaoLP reference2 = ref oR5peaUhdy7[num];
							val7 = val6.Position;
							reference2.X = val7.X;
							oR5peaUhdy7[num].point = val6.Position;
							oR5peaUhdy7[num].chavePri = structurePortas.chavePrimaria;
							oR5peaUhdy7[num].sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
							oR5peaUhdy7[num].sDesc = "";
						}
					}
				}
				if (Information.UBound(oR5peaUhdy7) > 0)
				{
					if (Information.UBound(oR5peaUhdy7) >= 2)
					{
						long num2 = Information.UBound(oR5peaUhdy7) - 1;
						for (long num3 = num2; num3 >= 1L; num3 += -1L)
						{
							long num4 = num3;
							for (long num5 = 1L; num5 <= num4; num5++)
							{
								if (oR5peaUhdy7[(int)num5].X > oR5peaUhdy7[(int)(num5 + 1L)].X)
								{
									object chavePri = oR5peaUhdy7[(int)(num5 + 1L)].chavePri;
									oR5peaUhdy7[(int)(num5 + 1L)].chavePri = oR5peaUhdy7[(int)num5].chavePri;
									oR5peaUhdy7[(int)num5].chavePri = Conversions.ToString(chavePri);
									chavePri = oR5peaUhdy7[(int)(num5 + 1L)].point;
									oR5peaUhdy7[(int)(num5 + 1L)].point = oR5peaUhdy7[(int)num5].point;
									ref Declaracoes2.StructureDescricaoLP reference3 = ref oR5peaUhdy7[(int)num5];
									object obj2 = chavePri;
									Point3d point;
									if (obj2 != null)
									{
										point = (Point3d)obj2;
									}
									else
									{
										val7 = default;
										point = val7;
									}
									reference3.point = point;
									chavePri = oR5peaUhdy7[(int)(num5 + 1L)].sHandle;
									oR5peaUhdy7[(int)(num5 + 1L)].sHandle = oR5peaUhdy7[(int)num5].sHandle;
									oR5peaUhdy7[(int)num5].sHandle = Conversions.ToString(chavePri);
									chavePri = oR5peaUhdy7[(int)(num5 + 1L)].X;
									oR5peaUhdy7[(int)(num5 + 1L)].X = oR5peaUhdy7[(int)num5].X;
									oR5peaUhdy7[(int)num5].X = Conversions.ToDouble(chavePri);
								}
							}
						}
					}
					double num6 = 1000.0;
					if (Information.UBound(oR5peaUhdy7) != 1)
					{
						int num7 = Information.UBound(oR5peaUhdy7);
						for (int i = 2; i <= num7; i++)
						{
							double num8 = oR5peaUhdy7[i].X - oR5peaUhdy7[i - 1].X;
							if (num8 < num6)
							{
								num6 = num8;
							}
						}
						H_tbLargura.Text = Conversions.ToString(Math.Round(num6, 1));
					}
					else
					{
						H_tbLargura.Text = Conversions.ToString(40);
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
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
		if (Operators.CompareString(H_tbLargura.Text, "", TextCompare: true) != 0)
		{
			H_BTInserir.Enabled = true;
		}
		PointMonitorToolTips.StartMonitor();
	}

	private void v7OpKLbKG97(object P_0, EventArgs P_1)
	{
		M99pKbwwQyq();
	}

	private void ntspKwfI5h1(object P_0, EventArgs P_1)
	{
		M99pKbwwQyq();
	}

	private void LPBpKxGrDlp(object P_0, EventArgs P_1)
	{
		M99pKbwwQyq();
	}

	private void M99pKbwwQyq()
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Invalid comparison between Unknown and I4
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
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
				TextBox textBox = TB_C_XMin;
				Point3d value = val2.Value;
				textBox.Text = Math.Round(value.X, 2).ToString();
				TextBox textBox2 = H_tbOrdenada;
				value = val2.Value;
				textBox2.Text = Math.Round(value.Y, 2).ToString();
				TextBox textBox3 = TB_V_Min;
				value = val2.Value;
				textBox3.Text = Math.Round(value.Y, 2).ToString();
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

	private void VdLpKM8rN4c(object P_0, EventArgs P_1)
	{
		K1apKIsLh2L();
	}

	private void rxFpKOsp3mW(object P_0, EventArgs P_1)
	{
		K1apKIsLh2L();
	}

	private void K1apKIsLh2L()
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Invalid comparison between Unknown and I4
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
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
				TextBox textBox = TB_V_MAX;
				Point3d value = val2.Value;
				textBox.Text = Math.Round(value.Y, 2).ToString();
				TextBox textBox2 = TB_C_XMax;
				value = val2.Value;
				textBox2.Text = Math.Round(value.X, 2).ToString();
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

	private void TEBpK7kpBmm(object P_0, EventArgs P_1)
	{
		if (oR5peaUhdy7 == null)
		{
			Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 1145]), MsgBoxStyle.Information);
			return;
		}
		clsTextos.ApagaTextoDasPortas(ref oR5peaUhdy7);
		hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
	}

	private void tFQpKqJ4Y9u(object P_0, EventArgs P_1)
	{
		DeclaracoesGeral.bAnularEventos = true;
		clsPortas.BuscaDescricaoDaLP(ref oR5peaUhdy7);
		checked
		{
			if (oR5peaUhdy7 != null)
			{
				double largura = 150.0;
				if (Operators.CompareString(H_tbLargura.Text, "", TextCompare: true) != 0)
				{
					largura = Conversions.ToDouble(H_tbLargura.Text);
				}
				string sHandleultimaline = "";
				string sTipo = "V";
				double ordenadaY = 0.0;
				double ordenadaX = 0.0;
				if (!RBHorizontal.Checked)
				{
					if (!RBVertical.Checked)
					{
						if (RBColuna.Checked)
						{
							sTipo = "L";
							ordenadaY = Conversions.ToDouble(H_tbOrdenada.Text);
							ordenadaX = Conversions.ToDouble(TB_C_XMin.Text);
							if (!CB_3_MultiLinhas.Checked)
							{
								if (!Versioned.IsNumeric(TB_C_XMin.Text))
								{
									return;
								}
								largura = Conversions.ToDouble(TB_C_XMin.Text);
							}
							else
							{
								if (!(Versioned.IsNumeric(TB_C_XMin.Text) & Versioned.IsNumeric(TB_C_XMax.Text)))
								{
									return;
								}
								double num = Conversions.ToDouble(TB_C_XMin.Text) - Conversions.ToDouble(TB_C_XMax.Text);
								if (num <= 0.0)
								{
									num *= -1.0;
								}
								largura = Math.Round(num, 2);
							}
						}
					}
					else
					{
						sTipo = "V";
						ordenadaY = Conversions.ToDouble(H_tbOrdenada.Text);
						ordenadaX = Conversions.ToDouble(TB_C_XMin.Text);
						if (!CB_2_MultiLinhas.Checked)
						{
							if (!Versioned.IsNumeric(TB_V_Min.Text))
							{
								return;
							}
							largura = 0.0;
						}
						else
						{
							if (!(Versioned.IsNumeric(TB_V_Min.Text) & Versioned.IsNumeric(TB_V_MAX.Text)))
							{
								return;
							}
							double num2 = Conversions.ToDouble(TB_V_Min.Text) - Conversions.ToDouble(TB_V_MAX.Text);
							if (num2 <= 0.0)
							{
								num2 *= -1.0;
							}
							largura = Math.Round(num2, 2);
						}
					}
				}
				else
				{
					sTipo = "H";
					ordenadaY = Conversions.ToDouble(H_tbOrdenada.Text);
					ordenadaX = Conversions.ToDouble(TB_C_XMin.Text);
					largura = Conversions.ToDouble(H_tbLargura.Text);
				}
				long num3 = Information.UBound(oR5peaUhdy7);
				for (long num4 = 1L; num4 <= num3; num4++)
				{
					clsTextos.criaMTextoLP(ref oR5peaUhdy7, (int)num4, Conversions.ToDouble(H_tbDistLinha.Text), Conversions.ToDouble(H_tbFonte.Text), largura, ordenadaY, ordenadaX, CB_1_Linhas.Checked, sTipo, CB_2_MultiLinhas.Checked, CB_3_MultiLinhas.Checked, sDJpe8qOZOK, ref sHandleultimaline);
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				}
				string chavePri = oR5peaUhdy7[Information.UBound(oR5peaUhdy7)].chavePri;
				if (CB_1_Linhas.Checked & RBHorizontal.Checked)
				{
					clsTextos.criaLinhaFinalDoTextoLP(ref sHandleultimaline, chavePri, largura);
				}
			}
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
		}
	}

	private void A1GpKaB6gHB(object P_0, EventArgs P_1)
	{
		kIJpKFUskJp();
	}

	private void vdgpK8fTg4r(object P_0, EventArgs P_1)
	{
		kIJpKFUskJp();
	}

	private void eEepKNa78JL(object P_0, EventArgs P_1)
	{
		kIJpKFUskJp();
	}

	private void kIJpKFUskJp()
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected Obj, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected Obj, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Invalid comparison between Unknown and I4
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected Obj, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected Obj, but got Unknown
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected Obj, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected Obj, but got Unknown
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected Obj, but got Unknown
		//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0604: Unknown result type (might be due to invalid IL or missing references)
		//IL_0515: Unknown result type (might be due to invalid IL or missing references)
		//IL_051a: Unknown result type (might be due to invalid IL or missing references)
		sDJpe8qOZOK = false;
		PointMonitorToolTips.StopMonitor();
		oR5peaUhdy7 = new Declaracoes2.StructureDescricaoLP[1];
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
			TypedValue[] array = new TypedValue[1];
			array.SetValue((object)new TypedValue(1001, (object)"Definicao"), 0);
			SelectionFilter val2 = new SelectionFilter(array);
			PromptSelectionOptions val3 = new PromptSelectionOptions();
			val3.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 622]);
			PromptSelectionResult selection = editor.GetSelection(val3, val2);
			if ((int)selection.Status != 5100)
			{
				return;
			}
			SelectionSet value = selection.Value;
			ObjectIdCollection val4 = new ObjectIdCollection(value.GetObjectIds());
			new ObjectIdCollection();
			new List<double>();
			checked
			{
				Point3d val10;
				foreach (object item in val4)
				{
					ObjectId val5 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
					Entity val6 = (Entity)val5.GetObject((OpenMode)0);
					DBText val7 = (DBText)(object)((val6 is DBText) ? val6 : null);
					if (val7 == null)
					{
						continue;
					}
					DeclaracoesEntidades.StructureDefinicaoPortas Def = default;
					Entity Ent = (Entity)(object)val7;
					bool flag = XDataDispositivosMaster.LerXDataDefinicao(ref Ent, ref Def);
					val7 = (DBText)Ent;
					if (!flag)
					{
						continue;
					}
					Entity val8 = (Entity)Geral.HandleToObject(Def.handleDaPorta);
					if (val8 == null)
					{
						continue;
					}
					BlockReference val9 = (BlockReference)(object)((val8 is BlockReference) ? val8 : null);
					if (val9 == null)
					{
						continue;
					}
					Ent = (Entity)(object)val9;
					string tipoImportado = "";
					string text = XDataDispositivo.verificaTipoDispositivo(ref Ent, ref tipoImportado);
					val9 = (BlockReference)Ent;
					string left = text;
					if (Operators.CompareString(left, "E", TextCompare: true) == 0)
					{
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val9);
						DeclaracoesEntidades.StructurePortas structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
						if (Operators.CompareString(structurePortas.chavePrimaria.Trim(), "", TextCompare: true) != 0)
						{
							int num = Information.UBound(oR5peaUhdy7) + 1;
							ref Declaracoes2.StructureDescricaoLP[] reference = ref oR5peaUhdy7;
							reference = (Declaracoes2.StructureDescricaoLP[])Utils.CopyArray(reference, new Declaracoes2.StructureDescricaoLP[num + 1]);
							ref Declaracoes2.StructureDescricaoLP reference2 = ref oR5peaUhdy7[num];
							val10 = val7.Position;
							reference2.Y = val10.Y;
							ref Declaracoes2.StructureDescricaoLP reference3 = ref oR5peaUhdy7[num];
							val10 = val7.Position;
							reference3.X = val10.X;
							oR5peaUhdy7[num].point = val7.Position;
							oR5peaUhdy7[num].chavePri = structurePortas.chavePrimaria;
							oR5peaUhdy7[num].sHandle = ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString();
							oR5peaUhdy7[num].sDesc = "";
						}
					}
				}
				if (Information.UBound(oR5peaUhdy7) > 0)
				{
					if (Information.UBound(oR5peaUhdy7) >= 2)
					{
						long num2 = Information.UBound(oR5peaUhdy7) - 1;
						for (long num3 = num2; num3 >= 1L; num3 += -1L)
						{
							long num4 = num3;
							for (long num5 = 1L; num5 <= num4; num5++)
							{
								if (oR5peaUhdy7[(int)num5].X > oR5peaUhdy7[(int)(num5 + 1L)].X)
								{
									object chavePri = oR5peaUhdy7[(int)(num5 + 1L)].chavePri;
									oR5peaUhdy7[(int)(num5 + 1L)].chavePri = oR5peaUhdy7[(int)num5].chavePri;
									oR5peaUhdy7[(int)num5].chavePri = Conversions.ToString(chavePri);
									chavePri = oR5peaUhdy7[(int)(num5 + 1L)].point;
									oR5peaUhdy7[(int)(num5 + 1L)].point = oR5peaUhdy7[(int)num5].point;
									ref Declaracoes2.StructureDescricaoLP reference4 = ref oR5peaUhdy7[(int)num5];
									object obj2 = chavePri;
									Point3d point;
									if (obj2 != null)
									{
										point = (Point3d)obj2;
									}
									else
									{
										val10 = default;
										point = val10;
									}
									reference4.point = point;
									chavePri = oR5peaUhdy7[(int)(num5 + 1L)].sHandle;
									oR5peaUhdy7[(int)(num5 + 1L)].sHandle = oR5peaUhdy7[(int)num5].sHandle;
									oR5peaUhdy7[(int)num5].sHandle = Conversions.ToString(chavePri);
									chavePri = oR5peaUhdy7[(int)(num5 + 1L)].X;
									oR5peaUhdy7[(int)(num5 + 1L)].X = oR5peaUhdy7[(int)num5].X;
									oR5peaUhdy7[(int)num5].X = Conversions.ToDouble(chavePri);
								}
							}
						}
					}
					double num6 = 1000.0;
					if (Information.UBound(oR5peaUhdy7) != 1)
					{
						int num7 = Information.UBound(oR5peaUhdy7);
						double num8 = default;
						for (int i = 2; i <= num7; i++)
						{
							num8 = oR5peaUhdy7[i].X - oR5peaUhdy7[i - 1].X;
							if (num8 < num6)
							{
								num6 = num8;
							}
						}
						if (num8 == 0.0)
						{
							int num9 = Information.UBound(oR5peaUhdy7);
							for (int j = 2; j <= num9; j++)
							{
								num8 = oR5peaUhdy7[j].Y - oR5peaUhdy7[j - 1].Y;
								if (num8 < num6)
								{
									num6 = num8;
								}
							}
							if (num8 < 1.0)
							{
								num8 *= -1.0;
							}
							num6 = num8;
						}
						H_tbLargura.Text = Conversions.ToString(Math.Round(num6, 1));
					}
					else
					{
						H_tbLargura.Text = Conversions.ToString(40);
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
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
		if (Operators.CompareString(H_tbLargura.Text, "", TextCompare: true) != 0)
		{
			H_BTInserir.Enabled = true;
		}
		PointMonitorToolTips.StartMonitor();
	}

	public void CarregaPortasChaves()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected Obj, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected Obj, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		JVMpeqbEDeZ = new StructureChaves[1];
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					DeclaracoesGeral._uscPagina.Quantidade = clsBlocos.AcadObjectCount();
					DeclaracoesGeral._uscPagina.pbIniciar();
					int num2 = 0;
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
							BlockReference val5 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
							if (val5 != null)
							{
								string tipoImportado = "";
								string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
								if (Operators.CompareString(left, "E", TextCompare: true) == 0)
								{
									BlockReference blockRef = (BlockReference)ent;
									object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									ent = (Entity)(object)blockRef;
									DeclaracoesEntidades.StructurePortas structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
									if (Operators.CompareString(structurePortas.chavePrimaria.Trim(), "", TextCompare: true) != 0)
									{
										num++;
										ref StructureChaves[] jVMpeqbEDeZ = ref JVMpeqbEDeZ;
										jVMpeqbEDeZ = (StructureChaves[])Utils.CopyArray(jVMpeqbEDeZ, new StructureChaves[num + 1]);
										JVMpeqbEDeZ[num].chavePri = structurePortas.chavePrimaria;
										JVMpeqbEDeZ[num].sHandle = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
									}
								}
							}
							num2++;
							if (num2 == 100)
							{
								DeclaracoesGeral._uscPagina.pbPasso(num2);
								num2 = 0;
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					DeclaracoesGeral._uscPagina.pbFim();
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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
	}

	private void UMEpKQSAsjj(object P_0, EventArgs P_1)
	{
		uVapKKOIgP4();
	}

	private void zbapKPpLBJo(object P_0, EventArgs P_1)
	{
		uVapKKOIgP4();
	}

	private void UZMpKcAdaDl(object P_0, EventArgs P_1)
	{
		uVapKKOIgP4();
	}

	private void uVapKKOIgP4()
	{
		CB_1_Linhas.Enabled = true;
		CB_2_MultiLinhas.Enabled = true;
		if (!RBHorizontal.Checked)
		{
			if (!RBVertical.Checked)
			{
				if (RBColuna.Checked)
				{
					GBHorizontal.Visible = false;
					GBVertical.Visible = false;
					GBColuna.Visible = true;
					TB_C_XMin.Text = "";
					TB_C_XMax.Text = "";
				}
			}
			else
			{
				GBHorizontal.Visible = false;
				GBVertical.Visible = true;
				GBColuna.Visible = false;
				TB_V_MAX.Text = "";
				TB_V_Min.Text = "";
			}
		}
		else
		{
			GBHorizontal.Visible = true;
			GBVertical.Visible = false;
			GBColuna.Visible = false;
			H_tbOrdenada.Text = "";
		}
	}

	private void Xv8pKeDfZvQ(object P_0, EventArgs P_1)
	{
		V_YMax.Enabled = CB_2_MultiLinhas.Checked;
		TB_V_MAX.Enabled = CB_2_MultiLinhas.Checked;
		Y_BTYMax.Enabled = CB_2_MultiLinhas.Checked;
	}

	private void vhgpK2CeNTB(object P_0, EventArgs P_1)
	{
		TB_C_XMax.Enabled = CB_3_MultiLinhas.Checked;
		C_XMax.Enabled = CB_3_MultiLinhas.Checked;
		C_BTYMax.Enabled = CB_3_MultiLinhas.Checked;
	}

	private void k3opK3IeuLd(object P_0, KeyEventArgs P_1)
	{
		if (Versioned.IsNumeric(H_tbFonte.Text))
		{
			DeclaracoesGeral.Conf.FonteCircuito = Conversions.ToDouble(H_tbFonte.Text);
			V_TBFonte.Text = Conversions.ToString(DeclaracoesGeral.Conf.FonteCircuito);
			C_TBFonte.Text = Conversions.ToString(DeclaracoesGeral.Conf.FonteCircuito);
		}
	}

	private void eJSpKnZ6XED(object P_0, KeyEventArgs P_1)
	{
		if (Versioned.IsNumeric(V_TBFonte.Text))
		{
			DeclaracoesGeral.Conf.FonteCircuito = Conversions.ToDouble(V_TBFonte.Text);
			H_tbFonte.Text = Conversions.ToString(DeclaracoesGeral.Conf.FonteCircuito);
			C_TBFonte.Text = Conversions.ToString(DeclaracoesGeral.Conf.FonteCircuito);
		}
	}

	private void yf7pK1FesoV(object P_0, KeyEventArgs P_1)
	{
		if (Versioned.IsNumeric(C_TBFonte.Text))
		{
			DeclaracoesGeral.Conf.FonteCircuito = Conversions.ToDouble(C_TBFonte.Text);
			H_tbFonte.Text = Conversions.ToString(DeclaracoesGeral.Conf.FonteCircuito);
			V_TBFonte.Text = Conversions.ToString(DeclaracoesGeral.Conf.FonteCircuito);
		}
	}
}
